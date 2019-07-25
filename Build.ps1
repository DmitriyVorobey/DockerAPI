docker build -t dockerapi . 
docker run --name dockerapi --rm -it -p 5001:5001 dockerapi