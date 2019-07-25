FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 8080/tcp
ENV ASPNETCORE_URLS https://*:8080

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
RUN echo $(ls)
COPY ["DockerAPI/DockerAPI.csproj", "DockerAPI/"]
RUN dotnet restore "DockerAPI/DockerAPI.csproj"
COPY . .
WORKDIR "/src/DockerAPI"
RUN dotnet build "DockerAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DockerAPI.csproj" -c Release -o /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerAPI.dll"]