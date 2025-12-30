---
title: 如何运行示例
type: docs
weight: 140
url: /zh/php-java/how-to-run-the-examples/
keywords:
- 示例
- 软件要求
- GitHub
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "快速运行 Aspose.Slides for PHP via Java 示例：克隆仓库，恢复包，然后构建并测试 PPT、PPTX 和 ODP 功能。"
---

## **从 GitHub 下载**
所有 Aspose.Slides for PHP via Java 的示例都托管在 [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java)。您可以使用喜欢的 Github 客户端克隆仓库，或从 [这里](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) 下载 ZIP 文件。

将 ZIP 文件的内容解压到计算机上的任意文件夹。所有示例位于 **Examples** 文件夹中。

![todo:image_alt_text](examples_directory.png)

## **将示例导入 IDE**
该项目使用 Maven 构建系统。任何现代 IDE 都可以轻松打开或导入项目及其依赖项。以下展示了如何使用流行的 IDE 构建并运行示例。

### **IntelliJ IDEA**
单击 **File** 菜单并选择 **Open**。浏览到项目文件夹并选择 **pom.xml** 文件。

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

它会打开项目并自动下载依赖项。在 Project 选项卡中，浏览 **src/main/java** 文件夹中的示例。要运行示例，只需右键单击文件并选择 “Run ..”，示例将执行，输出将在内置的控制台窗口中显示。

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
单击 **File** 菜单并选择 **Import**。选择 **Maven** - Existing Maven Projects。

![todo:image_alt_text](eclipse_import.png)

浏览到您从 GitHub 克隆或下载的文件夹并选择 **pom.xml** 文件。它会打开项目并自动下载依赖项。在 Package Explorer 选项卡中，浏览 **src/main/java** 文件夹中的示例。要运行示例，只需右键单击文件并选择 **Run As** - **Java Application**，示例将执行，输出将在内置的控制台窗口中显示。

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
单击 **File** 菜单并选择 **Open Project**。浏览到您从 GitHub 克隆或下载的文件夹。**Examples** 文件夹的图标会显示它是 Maven 项目。选择 Examples 并打开。

![todo:image_alt_text](netbeans_openproject.png)

它会打开项目并自动下载依赖项。在 Projects 选项卡中，浏览 **source packages** 中的示例。要运行示例，只需右键单击文件并选择 **Run File**，示例将执行，输出将在内置的控制台窗口中显示。

![todo:image_alt_text](netbeans_run_example.png)

## **将 Aspose.Slides 库添加到 Maven 本地仓库**
将 **Aspose.Slides Examples** 项目导入 IDE 时，Maven 会自动从 [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/) 下载 aspose.slides JAR 文件。如果无法访问互联网，您可以手动将 JAR 添加到本地仓库。

### **mvn install**
下载 [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/)，解压后将 aspose.slides-version.jar 复制到其他位置，例如 C 盘。执行以下命令：
```php

```

mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```php

```


现在，**aspose.slides** JAR 已复制到您的 Maven 本地仓库。

### **pom.xml**
安装后，只需在 pom.xml 中声明 **aspose.slides** 坐标。在 repositories 节点中添加以下仓库，在 dependencies 节点中添加相应的依赖。
``` xml
<repository>
    <id>aspose-maven-repository</id>
    <url>http://repository.aspose.com/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>18.6</version>
    <classifier>jdk16</classifier>
</dependency>
```php

```


### **完成**
构建项目后，**aspose.slides** JAR 将从您的 Maven 本地仓库中获取。

## **贡献**
如果您想添加或改进示例，欢迎为项目做出贡献。此仓库中的所有示例和展示项目均为开源，您可以自由地在自己的应用中使用。

要贡献，您可以 fork 该仓库，编辑源代码并提交 Pull Request。我们会审查更改，并在有价值的情况下将其合并到仓库中。