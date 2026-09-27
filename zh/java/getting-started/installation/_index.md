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
description: "从 Aspose 的 Maven 仓库或通过 JAR 文件安装 Aspose.Slides for Java，设置 Linux 前置条件，并使用第一个程序检查安装是否成功。"
---
## **概述**

本文说明了如何将 Aspose.Slides for Java 添加到项目中。Aspose.Slides for Java 发布在 Aspose 自己的 Maven 仓库，而不是 Maven Central，因此 Maven 项目必须声明该仓库。您也可以下载 JAR 文件并自行放入类路径。两种方式最终都会运行一个简短的程序，以确认库能够正常工作。

Aspose.Slides for Java 并不需要 Microsoft PowerPoint。它会以编程方式生成所需的演示文件。不过，要查看生成的演示文稿，您可能需要 Microsoft PowerPoint 或其他演示查看器。

## **先决条件**

- Java 开发工具包（JDK）。本文的项目和命令需要 JDK 11 或更高版本。在 JDK 11 上，检查安装的程序会打印以 "WARNING: An illegal reflective access operation has occurred" 开头的警告；该警告不影响结果，可忽略。
- [Apache Maven](https://maven.apache.org/install.html)，如果您使用 Maven 方式。
- 在 Linux 上，需要 fontconfig 库以及至少一个已安装的字体。参见 [Linux](#linux)。

## **从 Maven 仓库安装**

Aspose 将其 Java 库托管在自己的 [Maven repository](https://releases.aspose.com/java/repo/com/aspose/)。要在 Maven 项目中使用 [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)，请向 *pom.xml* 添加两条条目。

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
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

需要 `jdk16` 分类器：它选择库的 Java SE 版本。将 `26.9` 替换为 [仓库](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) 中列出的最新版本。仓库在每个 JAR 旁边发布 SHA-1 校验文件，Maven 在下载库时会进行校验。

### **检查安装**

要使用新项目检查设置：

1. 为项目创建一个文件夹，并在其中保存此 *pom.xml*：

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

   除了仓库和依赖项之外，此 *pom.xml* 还设置了要编译的 Java 发行版，指定了 `mvn exec:java` 将运行的类，并固定了编译器插件，因为某些默认使用的旧插件会忽略 `maven.compiler.release` 设置。

2. 将 [Create Presentations](/slides/zh/java/create-presentation/) 中的第一个示例保存为 *src/main/java/HelloSlides.java*。

3. 在项目文件夹中运行：

   ```bash
   mvn compile exec:java
   ```

Maven 下载 Aspose.Slides for Java，编译程序并运行它。程序会在项目文件夹中保存 *new_presentation.pptx*。

## **在不使用 Maven 的情况下使用 JAR 文件**

1. 从仓库的 [version folder](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) 下载 *aspose-slides-26.9-jdk16.jar*。如需其他版本，请在 [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) 中打开相应文件夹，下载以 *-jdk16.jar* 结尾的文件。

2. 将 [Create Presentations](/slides/zh/java/create-presentation/) 中的第一个示例保存为 *HelloSlides.java*，与 JAR 文件放在同一文件夹中。

3. 在该文件夹中运行：

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

JDK 会编译并运行该单源文件，程序会在文件夹中保存 *new_presentation.pptx*。在您自己的应用程序中，请将 JAR 文件添加到构建工具或 IDE 的类路径中。

## **Linux**

Aspose.Slides for Java 使用 Java 的字体支持；在 Linux 上这需要 fontconfig 库以及至少一个已安装的字体。若缺少这些，保存演示文稿会出现错误 “Fontconfig head is null, check your fonts or fonts configuration”。最小化的服务器和容器镜像可能都缺少这些组件，例如官方的 Ubuntu 容器镜像就没有。

在 Debian 和 Ubuntu 上，可使用以下命令安装 JDK、Maven、fontconfig 和 DejaVu 字体：

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

还必须安装您演示文稿中使用的字体或合适的替代字体，以确保文本能够正确呈现。

## **常见问题**

### 如何验证 Aspose.Slides 已正确集成？

构建项目，实例化一个空的 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)，并使用新名称保存。如果文件创建而未抛出异常，则库已成功集成。

### 在处理大型演示文稿时，如何限制内存消耗？

仅将 JVM 内存限制提升到所需的水平，并在 `finally` 块中对每个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 实例调用 [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--)，以及时释放缓存。这可防止内存不足错误，并在批处理操作期间保持总体内存使用可预测。

### 是否可以排除不需要的导出格式以减小最终 JAR 大小？

当前的 Aspose.Slides 发行版以单一整体库形式提供，无法在构建时禁用特定的导出器（如 PDF 或 SVG）。