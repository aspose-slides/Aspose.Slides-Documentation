---
title: 安装
type: docs
weight: 70
url: /zh/java/installation/
keywords:
- 安装 Aspose.Slides
- 下载 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安装
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "从 Aspose 的 Maven 仓库或以 JAR 文件方式安装 Aspose.Slides for Java，设置 Linux 前置条件，并通过第一个程序检查安装情况。"
---
## **概述**

本文说明如何在项目中添加 Aspose.Slides for Java。Aspose.Slides for Java 发布在 Aspose 自有的 Maven 仓库，而不是 Maven Central，因此 Maven 项目必须声明该仓库。您也可以下载 JAR 文件并自行放入类路径。两种方式最终都会运行一个简短的程序，以确认库能够正常工作。

Aspose.Slides for Java 不需要 Microsoft PowerPoint。它可通过编程方式生成所需的演示文稿文件。不过，要查看生成的演示文稿，可能需要 Microsoft PowerPoint 或其他演示文稿查看器。

## **先决条件**

- Java 开发工具包 (JDK)。本文中的项目和命令需要 JDK 11 或更高版本。在 JDK 11 上，检查安装的程序会打印一条以 “WARNING: An illegal reflective access operation has occurred” 开头的警告；该警告不影响结果，可忽略。
- [Apache Maven](https://maven.apache.org/install.html)，如果您使用 Maven 方式。
- 在 Linux 上，需要 fontconfig 库以及至少一种已安装的字体。参见 [Linux](#linux)。

## **从 Maven 仓库安装**

Aspose 在其自己的 [Maven 仓库](https://releases.aspose.com/java/repo/com/aspose/) 中托管其 Java 库。要在 Maven 项目中使用 [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)，请在 *pom.xml* 中添加两个条目。

1. **声明 Aspose Maven 仓库。**
   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
```

2. **添加 Aspose.Slides for Java 依赖项。**
   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

`jdk8` 分类器是必需的：它选择库的 Java SE 构建。将 `26.10` 替换为 [仓库](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) 中列出的最新版本。该仓库会在每个 JAR 旁边发布 SHA-1 校验文件，Maven 在下载库时会检查该校验文件。

### **检查安装**

要使用新项目检查设置：

1. 为项目创建一个文件夹，并将此 *pom.xml* 保存到该文件夹中：
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
               <version>26.10</version>
               <classifier>jdk8</classifier>
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

   除了仓库和依赖项之外，此 *pom.xml* 设置了要编译的 Java 发行版，指定了 `mvn exec:java` 要运行的类，并固定了编译器插件，因为某些 Maven 安装默认使用的旧插件会忽略 `maven.compiler.release` 设置。
2. 将 [创建演示文稿](/slides/zh/java/create-presentation/) 中的第一个示例保存为 *src/main/java/HelloSlides.java*。
3. 在项目文件夹中运行：
   ```bash
   mvn compile exec:java
   ```

Maven 下载 Aspose.Slides for Java，编译程序并运行它。程序会将 *new_presentation.pptx* 保存在项目文件夹中。

## **在不使用 Maven 的情况下使用 JAR 文件**

- 从仓库中的 [版本文件夹](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) 下载 *aspose-slides-26.10-jdk8.jar*。若需其他版本，请在 [仓库](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) 中打开对应文件夹，下载以 *-jdk8.jar* 结尾的文件。
- 将 [创建演示文稿](/slides/zh/java/create-presentation/) 中的第一个示例保存为 *HelloSlides.java*，并放在与 JAR 文件相同的文件夹中。
- 在该文件夹中运行：
   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

JDK 会编译并运行该单个源文件，程序会将 *new_presentation.pptx* 保存到该文件夹中。在您自己的应用程序中，请在构建工具或 IDE 中将 JAR 文件添加到类路径。

## **Linux**

Aspose.Slides for Java 使用 Java 的字体支持，在 Linux 上需要 fontconfig 库和至少一种已安装的字体。若缺少这些，保存演示文稿时会出现错误 “Fontconfig head is null, check your fonts or fonts configuration”。精简的服务器和容器镜像可能都不包含这些，例如官方的 Ubuntu 容器镜像就没有。

在 Debian 和 Ubuntu 上，可使用以下命令安装 JDK、Maven、fontconfig 和 DejaVu 字体：
```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

您演示文稿中使用的字体或适当的替代字体也必须已安装，文本才能正确渲染。

## **常见问题**

### 如何验证 Aspose.Slides 已正确集成？

构建您的项目，实例化一个空的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 并以新名称保存。如果文件创建成功且未抛出异常，则说明库已成功集成。

### 在处理大型演示文稿时，如何限制内存消耗？

仅将 JVM 内存限制提升到所需的最高值，并在 `finally` 块中对每个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 实例调用 [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) 以及时释放缓存。此做法可防止内存不足错误，并在批量操作期间保持总体内存使用可预测。

### 我能排除不需要的导出格式以减小最终 JAR 大小吗？

当前的 Aspose.Slides 发行版以单一的整体库形式提供，因此在构建时无法禁用特定的导出器（如 PDF 或 SVG）。