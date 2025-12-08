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
description: "Learn how to quickly install Aspose.Slides for Java. Step-by-step guide, system requirements, and code samples — start working with PowerPoint presentations today!"
---

## **Overview**

The Installation guide explains how to add Aspose.Slides for Java to your project environment. It shows how to reference the library from Maven Central or download the offline JAR package, and points out where to find checksum files so you can verify integrity. By the end of the section you should be ready to include Aspose.Slides in your build pipeline and run a simple “Hello, World” presentation to confirm everything is configured correctly.

Aspose.Slides for Java does not require Microsoft PowerPoint. It programmatically generates the necessary presentation files. However, to view the generated presentations, you may need Microsoft PowerPoint or another presentation viewer.

## **Install and Configure Java**

Java is a popular programming language that allows you to run programs on many platforms. For information about installing and configuring Java on any operating system, visit https://java.com/.

## **Install Aspose.Slides for Java from the Maven Repository**

Aspose hosts all Java APIs in its [Maven repositories](https://releases.aspose.com/java/repo/com/aspose/). You can integrate the [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) API directly into your Maven projects with minimal configuration.

1. **Specify Maven Repository Configuration**

   Specify the Aspose Maven repository configuration/location in your pom.xml like this:

``` xml
<repositories>
    <repository>
        <id>AsposeJavaAPI</id>
        <name>Aspose Java API</name>
        <url>https://releases.aspose.com/java/repo/</url>
    </repository>
</repositories>
```
2. **Define Aspose.Slides for Java API Dependency**

   Define Aspose.Slides for Java API dependency in your pom.xml this way:

``` xml
<dependencies>
    <dependency>
        <groupId>com.aspose</groupId>
        <artifactId>aspose-slides</artifactId>
        <version>XX.XX</version>
        <classifier>jdk16</classifier>
    </dependency>
    <dependency>
        <groupId>com.aspose</groupId>
        <artifactId>aspose-slides</artifactId>
        <version>XX.XX</version>
        <classifier>javadoc</classifier>
    </dependency>
</dependencies>
```

The Aspose.Slides for Java dependency will then be defined in your Maven project.

## **FAQ**

**How can I verify that Aspose.Slides is integrated correctly?**

Build your project, instantiate a blank [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) and save it under a new name. If the file is created without throwing exceptions, the library has been integrated successfully.

**How can I limit memory consumption when processing large presentations?**

Raise JVM memory limits only as high as needed, and close each [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) instance in a `finally` block to release the cache promptly. This prevents out‑of‑memory errors and keeps overall memory usage predictable during batch operations.

**Can I exclude unwanted export formats to shrink the final JAR size?**

Current Aspose.Slides releases are shipped as a single monolithic library, so you cannot disable specific exporters such as PDF or SVG at build time.
