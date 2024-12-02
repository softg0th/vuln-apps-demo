FROM amazoncorretto:17-alpine-jdk
WORKDIR /app
COPY . .
RUN ./gradlew clean build -x test -Pversion=1.0.0
EXPOSE 8080
CMD ["java", "-jar", "./build/libs/orm-0.0.1-SNAPSHOT.jar"]

