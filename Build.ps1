
Write-Host "Starting s3 service locally..."
start powershell {docker-compose up}
Start-Sleep -Seconds 2

Write-Host "Starting web service locally..."
start powershell {cd DockerAPI; dotnet run "DockerAPI.csproj"}

Start-Sleep -Seconds 5
Write-Host "Preparing integration tests..."
Start-Sleep -Seconds 5
Write-Host "Running integration tests..."
dotnet test "DockerAPI.Tests/DockerAPI.Tests.csproj"