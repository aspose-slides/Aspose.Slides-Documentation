---
title: 系统要求
type: docs
weight: 60
url: /zh/java/system-requirements/
keywords:
- 系统要求
- 受支持的平台
- Java 版本
- JDK
- JRE
- fontconfig
- 字体
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在安装 Aspose.Slides for Java 之前检查其需求：受支持的 Java 版本和操作系统，以及 Linux 所需的字体库和字体。"
---
## **介绍**

Aspose.Slides for Java 是一个独立的库：它不需要 Microsoft PowerPoint 或 Microsoft Office。它是一个单独的 JAR 文件，发布在 Aspose 的 Maven 仓库中。该 JAR 文件仅包含 Java 类和资源，没有本机库，并且声明不依赖其他库。因此，同一个文件可以在所有支持的 Java 运行时可用的操作系统和处理器上运行。

本文列出了受支持的 Java 版本和操作系统以及 Linux 所需的字体库和字体，并以一个检查您环境的简短程序结束。要将库添加到项目，请参阅[安装](/slides/zh/java/installation/)。

## **受支持的 Java 版本**

Aspose.Slides for Java 可以在 Java 8 或更高版本上运行，使用 JDK 或 JRE。这包括长期支持的 Java 8、11、17、21 和 25，以及后续的 Java 26、27 等版本。Java 运行时可以来自任何供应商，例如 Eclipse Temurin、Amazon Corretto、Oracle 或 Linux 发行版的 OpenJDK 包。

Aspose.Slides 在这些版本上无需任何 JVM 选项，例如 `--add-opens`。在 Java 11 上，JVM 会打印一条以 “WARNING: An illegal reflective access operation has occurred” 开头的警告；该警告不影响结果。

{{% alert color="warning" title="Warning" %}}
Java 6 和 Java 7 已不再推荐使用。Aspose.Slides for Java 26.9 仍可在其上运行，但会打印弃用警告。从 26.10 版起，最低要求为 Java 8，Java 6 和 Java 7 将不再受支持。
{{% /alert %}}

Maven 项目以及[安装](/slides/zh/java/installation/)中的命令需要 JDK 11 或更高版本。使用 Java 8 时，请参照[检查您的设置](#check-your-setup)编译并运行程序。

## **受支持的操作系统**

因为 JAR 文件不含本机代码，Aspose.Slides for Java 可在 Windows、Linux 和 macOS 上运行，支持 Java 运行时能够兼容的任何处理器架构，例如 x64 和 ARM64。Windows 上唯一的需求是 Java 运行时。Linux 上，Java 的字体支持还需要[Linux](#linux)中描述的字体库和字体。

## **Linux**

Aspose.Slides for Java 依赖 Java 运行时的字体支持来布局和绘制文本。在 Linux 上，这需要 fontconfig 库和至少一种已安装的字体。官方的 Linux 发行版容器镜像通常都没有这些组件。缺少它们时，[创建演示文稿](/slides/zh/java/create-presentation/)中的第一个示例在保存演示文稿时会失败，留下空文件，并报告以下错误：

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

官方的 `eclipse-temurin` 容器镜像（针对 Ubuntu 和 Alpine Linux）已经包含 fontconfig 和 DejaVu 字体，因此无需额外安装。在其他系统上，请安装下面列出的软件包。Debian、Ubuntu 和 Red Hat 的命令使用 `sudo`；在 Dockerfile 中，请在 `RUN` 指令中直接运行而不使用 `sudo`。DejaVu 字体已足以使 Aspose.Slides 正常运行；演示文稿使用的字体请参见[字体](#fonts)。

### **Debian 和 Ubuntu**

如果使用默认的 `apt-get` 设置从 Debian 或 Ubuntu 包安装 Java（如[安装](/slides/zh/java/installation/#linux)中的命令所示），Java 包会同时安装 fontconfig 库、DejaVu 字体以及这些 Java 包所需的 HarfBuzz 库，除此之外无需其他操作。

使用其他来源的 Java 运行时（例如 Eclipse Temurin 压缩包）时，请安装 fontconfig 和 DejaVu 字体：

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile 通常会安装 Debian 或 Ubuntu 的 Java 包，例如 `openjdk-21-jdk-headless` 或 `default-jdk-headless`，并使用 `--no-install-recommends` 选项，导致 fontconfig、DejaVu 字体和 HarfBuzz 都被跳过。请使用上面的命令安装 fontconfig 和 DejaVu 字体，并同时安装 HarfBuzz：

```bash
sudo apt-get install -y libharfbuzz0b
```

如果缺少 HarfBuzz，这些 Java 包会提示 `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`，并因 `UnsatisfiedLinkError`（报告 `libharfbuzz.so.0` 无法打开）而保存失败。

### **Red Hat Enterprise Linux**

Red Hat Enterprise Linux 的 `java-<version>-openjdk-headless` 包不安装 fontconfig 库。请同时安装 fontconfig 和 DejaVu 字体：

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

完整的 `java-<version>-openjdk` 包会将 fontconfig 和字体作为依赖一起安装，Amazon Linux 2023 的 Amazon Corretto 包（如 `java-21-amazon-corretto-headless`）亦是如此。

### **Alpine Linux**

在基于 Alpine Linux 的 Dockerfile 中，安装 fontconfig 和 DejaVu 字体：

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

在当前的 Alpine 发行版中，`ttf-dejavu` 会安装 `font-dejavu` 包。请使用 `openjdk<version>-jre` 或 `openjdk<version>-jdk` 包（例如 `openjdk25-jdk`）来安装 Java。Alpine Linux 的 `openjdk<version>-jre-headless` 包不包含 Java 的字体库，使用这些包时即使已安装字体，程序也会因 `UnsatisfiedLinkError: no fontmanager in system library path` 而失败。

### **字体**

为了让文本使用正确的字体和度量，需要在系统上安装演示文稿使用的字体或合适的替代字体，或在应用程序中加载这些字体。请参阅[部署字体](/slides/zh/java/deploy-fonts/)、[字体替换](/slides/zh/java/font-substitution/)和[自定义字体](/slides/zh/java/custom-font/)。

## **检查您的设置**

为了验证库及其依赖是否已就绪，请运行一个保存演示文稿并将幻灯片渲染为图像的程序。保存和渲染均使用 Java 运行时的字体支持，而这正是上述 Linux 要求提供的。

将下面的代码保存为 *CheckSetup.java*，放在包含 Aspose.Slides JAR 文件的文件夹中。要下载 JAR 文件，请参阅[在不使用 Maven 时使用 JAR 文件](/slides/zh/java/installation/#use-the-jar-file-without-maven)。

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // 在第一张幻灯片上添加一个带文本的矩形并保存演示文稿。
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // 以每点一个像素的比例渲染幻灯片并保存图像。
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

使用 JDK 11 或更高版本，在该文件夹中运行以下命令。如果您的 JAR 文件名不同，请相应修改命令中的名称。

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

使用 Java 8，或在仅有 JRE 的系统上，请使用 JDK 中的 `javac` 编译程序后再运行生成的类。在 Linux 和 macOS 上，执行：

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

在 Windows 上，执行相同的 `javac` 命令后，使用分号作为类路径分隔符运行类。请保留引号，以免 PowerShell 将分号视为命令结束符：`java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

该程序向第一张幻灯片添加一个带文本的矩形，并使用[save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)方法将演示文稿保存为 *hello.pptx*。随后使用[getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-)渲染幻灯片，并使用[IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-)将结果保存为 *hello.png*，格式为[ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/)。比例因子为 1 时，每点渲染一个像素，因此默认的 720 × 540 点幻灯片会生成 720 × 540 像素的图像，文本可见于矩形内部。未授权时，这两个文件都会带有评估水印；请参阅[授权](/slides/zh/java/licensing/)。如果缺少某项要求，程序会按照[Linux](#linux)中描述的错误之一停止。

## **开发工具**

您可以使用任何受支持 Java 版本的 JDK 构建使用 Aspose.Slides 的应用程序。按照[安装](/slides/zh/java/installation/)中的说明使用 Aspose 的 Maven 仓库和 Apache Maven，或使用任何能够使用 Maven 仓库的构建工具。也可以手动将 JAR 文件加入 IDE 或构建工具的类路径。

## **常见问题**

**我是否需要安装 Microsoft PowerPoint 才能进行转换和渲染？**

不需要，PowerPoint 并非必需。Aspose.Slides 是一个用于[创建](/slides/zh/java/create-presentation/)、修改、[转换](/slides/zh/java/convert-presentation/)和[渲染](/slides/zh/java/convert-powerpoint-to-png/)演示文稿的独立引擎。

**Aspose.Slides for Java 在 Linux 服务器上是否需要显示器或桌面环境？**

不需要。Aspose.Slides 不依赖 X 服务器或显示器，因而可以在服务器和容器中运行。Linux 上仅需满足[Linux](#linux)中描述的字体库和字体。

**渲染正确需要哪些字体？**

演示文稿使用的字体或合适的[替代字体](/slides/zh/java/font-substitution/)必须可用。在 Linux 和 macOS 上，安装演示文稿所需的字体包可确保渲染一致。

**为什么自定义字体在 Linux 上显示为回退或缺失的文本？**

如果字体文件的 name 表条目不一致或损坏，Linux 的字体匹配栈（FreeType/fontconfig）可能会选中无效记录，从而导致字体未解析。使用包含修正 name 表的字体版本或安装一致的替代字体即可解决此问题。