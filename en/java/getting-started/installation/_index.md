---
title: Installation
type: docs
weight: 70
url: /java/installation/
keywords:
- install Aspose.Slides
- download Aspose.Slides
- use Aspose.Slides
- Aspose.Slides installation
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Install Aspose.Slides for Java from Aspose's Maven repository or as a JAR file, set up the Linux prerequisites, and check the installation with a first program."
---

## **Overview**

This article explains how to add Aspose.Slides for Java to a project. Aspose.Slides for Java is published in Aspose's own Maven repository, not in Maven Central, so a Maven project has to declare that repository. You can also download the JAR file and put it on the class path yourself. Both routes end with a short program that confirms the library works.

Aspose.Slides for Java does not require Microsoft PowerPoint. It programmatically generates the necessary presentation files. However, to view the generated presentations, you may need Microsoft PowerPoint or another presentation viewer.

## **Prerequisites**

- A Java Development Kit (JDK). The project and the commands in this article need JDK 11 or later. On JDK 11, the program that checks the installation prints a warning that begins with "WARNING: An illegal reflective access operation has occurred"; it does not affect the result and can be ignored.
- [Apache Maven](https://maven.apache.org/install.html), if you use the Maven route.
- On Linux, the fontconfig library and at least one installed font. See [Linux](#linux).

## **Install from the Maven Repository**

Aspose hosts its Java libraries in its own [Maven repository](https://releases.aspose.com/java/repo/com/aspose/). To use [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) in a Maven project, add two entries to your *pom.xml*.

1. **Declare the Aspose Maven repository.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Add the Aspose.Slides for Java dependency.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

The `jdk16` classifier is required: it selects the Java SE build of the library. Replace `26.9` with the latest version listed in the [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). The repository publishes a SHA-1 checksum file next to each JAR, which Maven checks when it downloads the library.

### **Check the Installation**

To check the setup with a new project:

1. Create a folder for the project and save this *pom.xml* in it:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
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
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   Besides the repository and the dependency, this *pom.xml* sets the Java release to compile for, names the class that `mvn exec:java` runs, and pins the compiler plugin, because the older plugin that some Maven installations use by default ignores the `maven.compiler.release` setting.

2. Save the first example in [Create Presentations](/slides/java/create-presentation/) as *src/main/java/HelloSlides.java*.

3. In the project folder, run:

   ```bash
   mvn compile exec:java
   ```

Maven downloads Aspose.Slides for Java, compiles the program, and runs it. The program saves *new_presentation.pptx* in the project folder.

## **Use the JAR File without Maven**

1. Download *aspose-slides-26.9-jdk16.jar* from the [version folder](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) in the repository. For another version, open its folder in the [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) and download the file that ends in *-jdk16.jar*.
2. Save the first example in [Create Presentations](/slides/java/create-presentation/) as *HelloSlides.java* in the same folder as the JAR file.
3. In that folder, run:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

The JDK compiles and runs the single source file, and the program saves *new_presentation.pptx* in the folder. In your own application, add the JAR file to the class path in your build tool or IDE.

## **Linux**

Aspose.Slides for Java uses Java's font support, which on Linux needs the fontconfig library and at least one installed font. Without them, saving a presentation fails with the error "Fontconfig head is null, check your fonts or fonts configuration". Minimal server and container images can lack both; the official Ubuntu container image, for example, has neither.

On Debian and Ubuntu, this command installs a JDK, Maven, fontconfig, and the DejaVu fonts:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

The fonts used in your presentations, or suitable substitutes, must also be installed for text to render correctly.

## **FAQ**

### How can I verify that Aspose.Slides is integrated correctly?

Build your project, instantiate a blank [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) and save it under a new name. If the file is created without throwing exceptions, the library has been integrated successfully.

### How can I limit memory consumption when processing large presentations?

Raise JVM memory limits only as high as needed, and call [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) on each [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) instance in a `finally` block to release the cache promptly. This prevents out‑of‑memory errors and keeps overall memory usage predictable during batch operations.

### Can I exclude unwanted export formats to shrink the final JAR size?

Current Aspose.Slides releases are shipped as a single monolithic library, so you cannot disable specific exporters such as PDF or SVG at build time.
