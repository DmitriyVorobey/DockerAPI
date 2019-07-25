docker build -t dockerapi . --no-cache
docker run --name dockerapi --rm -it -p 8080:80 dockerapi