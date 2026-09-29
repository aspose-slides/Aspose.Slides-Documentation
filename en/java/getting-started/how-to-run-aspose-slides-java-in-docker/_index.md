---
title: Run Aspose.Slides for Java in Docker
linktitle: Docker
type: docs
weight: 150
url: /java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker container
- multi-stage build
- container image
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- fonts
- PDF conversion
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Build and run an Aspose.Slides for Java application in Docker: a multi-stage Dockerfile on the official Maven and Eclipse Temurin images, the Linux libraries and fonts that Aspose.Slides needs, and how to copy the generated files to your machine."
---

## **Overview**

This article shows how to run Aspose.Slides for Java in a Docker container. You build a small Maven project that creates a presentation with a text box and converts it to PDF, package it with a multi-stage Dockerfile on the official Maven and Eclipse Temurin images, run it, and copy the generated files to your machine. The article also explains what Aspose.Slides needs in a Linux image besides Java, and ends with variants for Alpine Linux and for images that install Java from the distribution's packages.

You only need Docker on your machine. The JDK and Maven are part of the build image, so you do not have to install them. To install Docker, see [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Choose the Base Images**

The Dockerfile in this article uses two official images from Docker Hub:

- [maven](https://hub.docker.com/_/maven) with the tag `3.9-eclipse-temurin-21` builds the application. It contains Apache Maven 3.9 and the Eclipse Temurin JDK 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) with the tag `21-jre` runs it. It contains the Eclipse Temurin Java 21 runtime on Ubuntu, without the JDK and Maven.

Aspose.Slides for Java draws text with Java's font support, which on Linux needs the fontconfig and FreeType libraries and at least one installed font. The Eclipse Temurin images already contain fontconfig, FreeType, and the DejaVu fonts, so the Dockerfile in this article installs no packages. In an image without any font, saving a presentation stops with the error "Fontconfig head is null, check your fonts or fonts configuration". If you build on another base image, see [Use Another Base Image](#use-another-base-image).

## **Create the Project**

Create a folder named *hello-slides-docker* and add the following files to it.

*pom.xml* declares Aspose's Maven repository and the Aspose.Slides for Java dependency, as described in [Installation](/slides/java/installation/); Aspose.Slides for Java is not published in Maven Central, so the repository entry is required. The `finalName` element names the application JAR file *hello-slides.jar*, and the [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) copies the dependencies of the application to *target/lib* when Maven packages it. Set the Aspose.Slides version to the latest one listed in the [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/).

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
    </properties>

    <repositories>
        <repository>
            <id>AsposeJavaAPI</id>
            <name>Aspose Java API</name>
            <url>https://releases.aspose.com/java/repo/</url>
        </repository>
    </repositories>

    <dependencies>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides</artifactId>
            <version>26.9</version>
            <classifier>jdk16</classifier>
        </dependency>
    </dependencies>

    <build>
        <finalName>hello-slides</finalName>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-dependency-plugin</artifactId>
                <version>3.11.0</version>
                <executions>
                    <execution>
                        <phase>package</phase>
                        <goals>
                            <goal>copy-dependencies</goal>
                        </goals>
                        <configuration>
                            <outputDirectory>${project.build.directory}/lib</outputDirectory>
                        </configuration>
                    </execution>
                </executions>
            </plugin>
        </plugins>
    </build>
</project>
```

*src/main/java/HelloSlides.java* creates a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), adds a rectangle with text to its first slide, and saves the presentation twice with the [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) method: as PPTX and as PDF. Both files go to the *output* folder under the working directory. The program then lists the fonts that Aspose.Slides replaces when it renders the presentation, using [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--), so you can see whether the container has the fonts that the presentation uses.

```java
import com.aspose.slides.*;
import java.io.File;

public class HelloSlides {
    public static void main(String[] args) {
        File outputFolder = new File("output");
        outputFolder.mkdirs();

        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello from a Docker container!");

            String pptxPath = new File(outputFolder, "hello.pptx").getPath();
            String pdfPath = new File(outputFolder, "hello.pdf").getPath();
            presentation.save(pptxPath, SaveFormat.Pptx);
            presentation.save(pdfPath, SaveFormat.Pdf);

            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                System.out.println("Font substitution: " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
            }

            System.out.println("Saved " + pptxPath + " and " + pdfPath);
        } finally {
            presentation.dispose();
        }
    }
}
```

*.dockerignore* keeps the *target* folder of a local build, and the output of earlier runs, out of the Docker build context, so the image is built from the source files only.

```text
target/
output/
```

## **Write the Dockerfile**

Add a file named *Dockerfile* to the *hello-slides-docker* folder:

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

The file has two stages:

- **The build stage** starts from the Maven image. It copies *pom.xml* first and runs `mvn dependency:go-offline`, which downloads Aspose.Slides for Java and the Maven plugins, so Docker reuses that layer as long as *pom.xml* does not change. It then copies the source code and runs `mvn package`, which compiles the program into *target/hello-slides.jar* and copies the Aspose.Slides JAR file to *target/lib*. The `-B` option runs Maven in non-interactive (batch) mode.
- **The runtime stage** starts from the smaller Java runtime image and copies in only the application JAR file and the *lib* folder. It creates the *output* folder, gives it to `ubuntu`, the non-root user that the Ubuntu-based image defines, and runs the application as that user. The class path `hello-slides.jar:lib/*` contains the application and every JAR file in *lib*; Java expands the `*` itself.

The project is compiled for Java 11 (the `maven.compiler.release` property), so the runtime stage can use a newer Java version. For example, to run the application on Java 25, change the image of the runtime stage to `eclipse-temurin:25-jre`.

## **Build and Run the Container**

Open a terminal in the *hello-slides-docker* folder. Build the image, then run a container from it:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

The first build downloads the base images, the Maven plugins, and Aspose.Slides for Java, so it takes several minutes; later builds reuse them. The container runs the application and stops. It prints:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

The first line shows that the text uses Calibri, the default font of a new presentation, and that Calibri is not installed in the image, so Aspose.Slides drew the text with DejaVu Sans. The text in the PDF is real, selectable text in that font. Without a license, Aspose.Slides also adds an evaluation watermark to every slide it saves; see [Licensing](/slides/java/licensing/).

## **Copy the Output to Your Machine**

The files are in the */app/output* folder of the stopped container. Copy them to an *output* folder on your machine, then remove the container:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

These two commands work the same way in Bash, PowerShell, and the Windows Command Prompt.

On Linux, you can instead mount a folder of your machine into the container, so the application writes its files there directly:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

The `--user` option runs the application with your user and group IDs, so it can write to the folder you created and the files belong to you. `--rm` removes the container when it stops.

## **Run on Alpine Linux**

Eclipse Temurin is also available as an image based on Alpine Linux, which is smaller. It contains fontconfig, FreeType, and the DejaVu fonts as well, so the application needs no additional packages there either. To use it, replace the runtime stage in *Dockerfile* (everything from the second `FROM` line) with:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

The Alpine image has no `ubuntu` user, so this stage creates a user named `app` with `adduser` and runs the application as that user. Build, run, and copy the output with the same commands as above. The application prints the same two lines.

## **Use Another Base Image**

If your image installs Java from the packages of the Linux distribution instead, install Java's font libraries and a font along with it. On Debian and Ubuntu, the `openjdk-21-jre-headless` package lists fontconfig, FreeType, and HarfBuzz only as recommended packages, so `apt-get install --no-install-recommends` leaves them out, and the application stops with an `UnsatisfiedLinkError` for `libfontmanager.so`. This runtime stage installs Java 21, the libraries, and the DejaVu fonts on Debian 13, and creates a non-root user named `app`:

```dockerfile
FROM debian:trixie
RUN apt-get update \
    && apt-get install -y --no-install-recommends openjdk-21-jre-headless libfontconfig1 libfreetype6 libharfbuzz0b fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN useradd --create-home app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

The same stage works on Ubuntu 26.04 with `FROM ubuntu:26.04`.

## **FAQ**

**Saving the presentation stops with "Fontconfig head is null, check your fonts or fonts configuration". What is missing?**

A font. Java's font support found no installed font in the image. Install a font package, for example `fonts-dejavu-core` on Debian and Ubuntu, as in [Use Another Base Image](#use-another-base-image). [Deploy Fonts](/slides/java/deploy-fonts/) lists other font packages.

**The application stops with an UnsatisfiedLinkError for libfontmanager.so. What is missing?**

A native library of Java's font support; the message names the file that could not be loaded, for example `libharfbuzz.so.0`. This happens when Java is installed from the distribution's packages without their recommended packages. Install the libraries listed in [Use Another Base Image](#use-another-base-image).

**Why is the text in the PDF in a different font than in PowerPoint?**

The fonts that the presentation uses are not installed in the image, so Aspose.Slides draws the text with a substitute font. The application's output names each replaced font. [Deploy Fonts](/slides/java/deploy-fonts/) explains how to install fonts in the image or load them from the application folder.

**How much memory can the application use in the container?**

By default, Java limits its heap to a quarter of the memory available to the container, for example to about 250 MB when you start the container with `docker run -m 1g`. To process large presentations, raise the share with the `MaxRAMPercentage` option, for example `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. Java then prints a "Picked up JAVA_TOOL_OPTIONS" line before the output of the application.

**Do I need a JDK or Maven on my machine?**

No. The build stage compiles the application inside the Maven image. You need a JDK and Maven only if you also want to build and run the application outside Docker; see [Installation](/slides/java/installation/).
