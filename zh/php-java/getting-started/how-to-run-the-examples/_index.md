---
title: 如何运行示例
type: docs
weight: 140
url: /zh/php-java/how-to-run-the-examples/
---

## **从 GitHub 下载**
所有 Aspose.Slides for PHP via Java 的示例都托管在 [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) 上。你可以使用你喜欢的 Github 客户端克隆该仓库，或者从 [这里](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) 下载 ZIP 文件。

将 ZIP 文件的内容提取到你计算机上的任意文件夹中。所有示例位于 **Examples** 文件夹中。

![todo:image_alt_text](examples_directory.png)

## **将示例导入 IDE**
该项目使用 Maven 构建系统。任何现代 IDE 都可以轻松打开或导入该项目及其依赖项。下面我们将向你展示如何使用流行的 IDE 构建和运行示例。

### **IntelliJ IDEA**
点击 **文件** 菜单，然后选择 **打开**。浏览到项目文件夹，并选择 **pom.xml** 文件。

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

它将自动打开项目并下载依赖关系。从项目选项卡中，浏览 **src/main/java** 文件夹中的示例。要运行示例，只需右键单击该文件并选择“运行 ..”，示例将被执行，输出将在内置控制台输出窗口中显示。

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
点击 **文件** 菜单并选择 **导入**。选择 **Maven** - 现有 Maven 项目。

![todo:image_alt_text](eclipse_import.png)

浏览到你从 GitHub 克隆或下载的文件夹，并选择 **pom.xml** 文件。它将自动打开项目并下载依赖关系。从包资源管理器选项卡中，浏览 **src/main/java** 文件夹中的示例。要运行示例，只需右键单击该文件并选择 **作为** - **Java 应用程序运行**，示例将被执行，输出将在内置控制台输出窗口中显示。

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
点击 **文件** 菜单并选择 **打开项目**。浏览到你从 GitHub 克隆或下载的文件夹。**Examples** 文件夹的图标将显示它是一个 Maven 项目。选择 Examples 并打开它。

![todo:image_alt_text](netbeans_openproject.png)

它将自动打开项目并下载依赖关系。从项目选项卡中，浏览 **源代码包** 中的示例。要运行示例，只需右键单击该文件并选择 **运行文件**，示例将被执行，输出将在内置控制台输出窗口中显示。

![todo:image_alt_text](netbeans_run_example.png)

## **将 Aspose.Slides 库添加到 Maven 本地库**
当你将 **Aspose.Slides 示例** 项目导入 IDE 时，Maven 会自动从 [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/) 下载 aspose.slides JAR 文件。如果你没有互联网访问权，你可以手动将 JAR 添加到你的本地库中。

### **mvn install**
下载 [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/)，提取并将 aspose.slides-version.jar 复制到其他地方，例如 C 盘。执行以下命令：

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

现在，**aspose.slides** JAR 已复制到你的 Maven 本地库中。

### **pom.xml**
安装后，只需在 pom.xml 中声明**aspose.slides** 坐标。在repositories选项卡中添加以下仓库，并在dependencies选项卡中添加依赖项。

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
构建它，现在 **aspose.slides** JAR 可以从你的 Maven 本地库中检索。

## **贡献**
如果你想添加或改进一个示例，我们鼓励你为该项目做贡献。该仓库中的所有示例和展示项目都是开源的，可以在你自己的应用程序中自由使用。

要贡献，你可以分叉该仓库，编辑源代码并提交拉取请求。我们将审查更改，如果发现有帮助，则将其包含在仓库中。