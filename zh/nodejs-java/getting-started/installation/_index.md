---
title: 安装
type: docs
weight: 70
url: /zh/nodejs-java/installation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "从 npm 在 Windows、Linux 和 macOS 上为 Node.js via Java 安装 Aspose.Slides：它所需的 JDK、Python 和 C++ 构建工具、npm 命令以及用于检查安装的首个脚本。"
---
## **概述**

本文说明如何在 Windows、Linux 和 macOS 上通过 Java 为 Node.js 安装 Aspose.Slides，以及如何检查安装是否成功。

Aspose.Slides for Node.js via Java 以 npm 上的 `aspose.slides.via.java` 包形式分发。它通过 [`java`](https://github.com/joeferner/node-java) 包在 Java 虚拟机中运行 Aspose.Slides，该包是一个原生 Node.js 插件，npm 会在安装期间在你的电脑上编译它。因此，除了 Node.js 外，安装还需要：

- **Java Development Kit (JDK) 8 或更高版本。**仅有 Java 运行时不足以完成构建：编译过程需要 JDK 的头文件。
- **Python 3**，构建工具 [node-gyp](https://github.com/nodejs/node-gyp) 需要使用它。
- **适用于你的操作系统的 C++ 构建工具链**。

## **安装先决条件**

### **Windows**

1. 安装 [Node.js](https://nodejs.org/en/download) 20 或更高版本。
2. 安装 JDK，例如 [Eclipse Temurin](https://adoptium.net/)，并将 `JAVA_HOME` 环境变量设置为其安装目录。构建过程会使用 `JAVA_HOME` 指向的 JDK。
3. 安装 [Python 3](https://www.python.org/downloads/)。
4. 安装 [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe)，并选择 **Desktop development with C++** 工作负载。保留该工作负载的默认组件，其中包括 **MSVC v143 - VS 2022 C++ x64/x86 build tools** 和 **Windows 11 SDK**。Visual Studio 2026 不可用：`java` 包编译使用的 node-gyp 版本无法识别它。

### **Linux**

从 [nodejs.org](https://nodejs.org/en/download) 或发行版的包源安装 Node.js 20 或更高版本。随后安装 JDK、Python 3 和 C++ 构建工具。在 Debian 和 Ubuntu 上：

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

在 Linux 上，构建会自动发现已安装的 JDK，无需额外配置。如果安装了多个 JDK，请将 `JAVA_HOME` 设置为想要使用的那个。

### **macOS**

安装 Node.js 20 或更高版本、JDK 和 Xcode 命令行工具，后者包含 Python 3 和 C++ 编译器。有关 macOS 特定说明，请参阅 [Troubleshooting Installation](/slides/zh/nodejs-java/troubleshooting-installation/)。

## **从 npm 安装**

创建项目文件夹并安装包：

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm 会下载 Aspose.Slides 并编译 `java` 桥接，这可能需要几分钟。如果编译失败，请参阅 [Troubleshooting Installation](/slides/zh/nodejs-java/troubleshooting-installation/)。

## **检查安装**

在项目文件夹中创建名为 *hello.js* 的文件，内容如下。它会创建一个演示文稿，在第一张幻灯片上添加一个文本框，并将结果保存为 *hello.pptx*：

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides 在 Java 虚拟机中运行，该虚拟机会保持 Node.js 进程运行，因此需要显式结束进程。
process.exit(0);
```

运行脚本：

```bash
node hello.js
```

如果 *hello.pptx* 出现在项目文件夹中，则说明安装成功。运行 Aspose.Slides 的 Java 虚拟机会阻止 Node.js 自动退出，这也是脚本以 `process.exit(0)` 结束的原因。[Create Presentations](/slides/zh/nodejs-java/create-presentation/) 对代码进行了说明。

## **从 ZIP 存档安装**

该包也提供与 npm 包相同内容的 ZIP 存档。使用该存档进行安装的步骤如下：

1. 按上述说明为你的操作系统安装先决条件。
2. 从 [Aspose.Slides for Node.js via Java download page](https://releases.aspose.com/slides/nodejs-java/) 下载存档。
3. 创建项目文件夹：

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. 将存档解压到项目文件夹内名为 *aspose.slides.via.java* 的子文件夹中，使得存档的 *package.json* 位于 *hello-slides/aspose.slides.via.java/package.json*。
5. 从该文件夹安装包：

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm 会安装该包依赖的 `java` 桥接并编译它，行为与 npm 包相同。

6. 按照 [Check the Installation](#check-the-installation) 中的说明检查安装。

## **常见问题**

**是否有免费版或试用限制？**

是的。未提供许可证时，Aspose.Slides 以评估模式运行：它会在每个保存的幻灯片上添加评估水印，并截断从演示文稿读取的文本。要消除这些限制，请使用有效的 [license](/slides/zh/nodejs-java/licensing/)。

**为什么脚本完成后没有退出？**

`java` 包会在 Node.js 进程内部启动一个 Java 虚拟机，该虚拟机会保持进程运行。当脚本完成工作后，请调用 `process.exit`。