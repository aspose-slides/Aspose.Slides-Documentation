---
title: 安装
type: docs
weight: 70
url: /java/installation/
---

{{% alert color="primary" %}} 

Aspose.Slides for Java 不需要 Microsoft PowerPoint。它以编程方式生成所需的演示文稿文件。然而，要查看生成的演示文稿，您可能需要使用 PowerPoint 或演示文稿查看器。 

{{% /alert %}} 

## **安装和配置 Java**
Java 是一种流行的编程语言，允许您在许多平台上运行程序。 

有关在任何操作系统上安装和配置 Java 的信息，请访问 https://java.com/。

## **从 Maven 仓库安装 Aspose.Slides for Java**
Aspose 在 [Maven 仓库](https://releases.aspose.com/java/repo/com/aspose/) 上托管所有 Java API。您可以通过简单的配置直接在 Maven 项目中使用 [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) API。

1. **指定 Maven 仓库配置**

   在您的 Maven pom.xml 中以如下方式指定 Aspose Maven 仓库配置/位置：

``` xml
<repositories>
    <repository>
        <id>AsposeJavaAPI</id>
        <name>Aspose Java API</name>
        <url>https://releases.aspose.com/java/repo/</url>
    </repository>
</repositories>
```
2. **定义 Aspose.Slides for Java API 依赖关系**

   在您的 pom.xml 中以如下方式定义 Aspose.Slides for Java API 依赖关系：

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

Aspose.Slides for Java 依赖关系将随后在您的 Maven 项目中定义。