---
title: Installation
type: docs
weight: 70
url: /java/installation/
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java does not require Microsoft PowerPoint. It generates the needed presentation files programmatically. However, to view a generated presentation, you may have to use a PowerPoint or presentation viewer.

{{% /alert %}} 

## **Installing and Configuring Java**
Java is a popular programming language that allows you to run programs on many platforms. 

For information on installing and configuring Java on any operating system, go to https://java.com/.

## **Installing Aspose.Slides for PHP via Java from Maven Repository**
Aspose hosts all Java APIs on [Maven repositories](https://releases.aspose.com/java/repo/com/aspose/). You can use [Aspose.Slides for PHP via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) API directly in your Maven projects with simple configurations.

1. **Specify Maven Repository Configuration**

   Specify Aspose Maven Repository configuration/location in your Maven pom.xml this way:

``` xml
<repositories>
    <repository>
        <id>AsposeJavaAPI</id>
        <name>Aspose Java API</name>
        <url>https://releases.aspose.com/java/repo/</url>
    </repository>
</repositories>
```
2. **Define Aspose.Slides for PHP via Java API Dependency**

   Define Aspose.Slides for PHP via Java API dependency in your pom.xml this way:

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

Aspose.Slides for PHP via Java dependency will then be defined in your Maven project.

