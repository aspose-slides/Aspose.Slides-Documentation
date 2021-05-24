---
title: Installation
type: docs
weight: 70
url: /java/installation/
---

{{% alert color="primary" %}} 

Aspose.Slides for Java does not require having Microsoft PowerPoint installed and generates the presentation files programmatically. However, you may need a PowerPoint viewer installed to view the generated presentation but it is not the requirement of Aspose.Slides for Java.

{{% /alert %}} 
## **System Requirements**
### **Operating Systems**
Aspose.Slides for Java supports any operating system that runs the Java runtime including, but not limited:

- Microsoft Windows desktop and server operating systems
- Linux (Ubuntu, openSUSE, CentOS and others)
- Unix
- Mac OS X
### **Java Versions**
Aspose.Slides for Java supports the following Java versions:

- J2SE 6.0 (1.6)
- J2SE 7.0 (1.7)
- J2SE 8.0 (1.8)
- JDK9
- JDK10
- JDK11


## **Installing Aspose.Slides for Java from Maven Repository**
Aspose hosts all Java APIs on [Maven repository](https://repository.aspose.com/repo/com/aspose/). You can easily use [Aspose.Slides for Java](https://repository.aspose.com/repo/com/aspose/aspose-slides/) API directly in your Maven Projects with simple configurations.
### **Specify Maven Repository Configuration**
First, you need to specify Aspose Maven Repository configuration / location in your Maven pom.xml as follows:

``` java
 <repositories>
    <repository>
        <id>AsposeJavaAPI</id>
        <name>Aspose Java API</name>
        <url>https://repository.aspose.com/repo/</url>
    </repository>
</repositories>
```
### **Define Aspose.Slides for Java API Dependency**
Then define Aspose.Slides for Java API dependency in your pom.xml as follows:

``` java
 <dependencies>
    <dependency>
        <groupId>com.aspose</groupId>
        <artifactId>aspose-slides</artifactId>
        <version>20.1</version>
        <classifier>jdk16</classifier>
    </dependency>
    <dependency>
        <groupId>com.aspose</groupId>
        <artifactId>aspose-slides</artifactId>
        <version>20.1</version>
        <classifier>javadoc</classifier>
    </dependency>
</dependencies>
```

After performing the above steps, Aspose.Slides for Java dependency will finally be defined in your Maven Project.


