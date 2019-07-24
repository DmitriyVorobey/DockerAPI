docker build -t dockerapi . --no-cache
docker run -d -p 8080:80 --name dockerapi dockerapi