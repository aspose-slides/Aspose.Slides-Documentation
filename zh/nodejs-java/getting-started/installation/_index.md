---
title: 安装
type: docs
weight: 70
url: /nodejs-java/installation/
keySlides: "下载 Aspose.Slides, 安装 Aspose.Slides, Aspose.Slides 安装, Windows, macOS, Linux, Javascript, Node.js"
description: "在 Windows、Linux 或 macOS 上通过 Java 安装 Aspose.Slides for Node.js"
---

Aspose.Slides for Node.js via Java 是一个平台无关的 API，可以在任何安装了 `Node.js` 和 [`java`](https://www.npmjs.com/package/java) 桥接的 платформе（Windows、Linux 和 MacOS）上使用。

## **从 NPM 安装**

您可以轻松地通过 [NPM](https://www.npmjs.com/) 安装 Aspose.Slides for Node.js via Java。

创建一个新文件夹并使用以下命令初始化一个新项目：
```
$ npm init
```
填写标题和版本字段（将其余字段保留为默认值）

使用以下命令安装 Aspose.Slides for Node.js via Java：
```
$ npm install aspose.slides.via.java
```

如果您在安装过程中遇到任何问题，请参考这篇 [文章](/nodejs-java/troubleshooting-installation/)。

## **从 ZIP 归档安装**

要从 ZIP 归档安装和使用 Aspose.Slides for Node.js via Java，请遵循以下说明：

### **Windows**

1. 安装 JDK8 并配置 `JAVA_HOME` 环境变量。
1. 安装 Node.js (https://nodejs.org/en/download/) 并将 node.exe 添加到 `PATH`。
1. 安装 node-gyp。
1. 安装 Windows Build Tools。
1. 安装 [`java`](https://www.npmjs.com/package/java) 桥接，并以管理员身份在命令提示符下运行以下命令：
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install -g node-gyp

$ npm install --global --production windows-build-tools

$ npm install java
```
6. [下载 Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) 并将其解压到 `aspose.slides.nodejs/node_modules/aspose.slides.via.java`。
7. 使用以下示例代码在 `aspose.slides.nodejs` 文件夹中创建一个名为 `hello.js` 的文件：

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("幻灯片标题");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("完成");
```

8. 现在在命令提示符下运行 `node hello.js` 以执行它。

### **Linux**

1. 安装 Node.js (https://nodejs.org/en/download/)。
1. 为 Linux 安装 JDK8 并配置 `JAVA_HOME` 环境变量。
1. 安装 python 2.x。
1. 安装 [`java`](https://www.npmjs.com/package/java) 桥接。您可以在终端中运行以下命令：
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install java
```
5. [下载 Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) 并将其解压到 `aspose.slides.nodejs/node_modules/aspose.slides.via.java`。
6. 在 `aspose.slides.nodejs` 文件夹中使用以下示例代码创建一个名为 `hello.js` 的测试文件：

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("幻灯片标题");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("完成");
```
7. 现在在命令提示符下运行 `node hello.js` 以执行它。

### **Mac**

1. 安装 Node.js (https://nodejs.org/en/download/)。
1. 为 Mac 安装 JDK8 并配置 `JAVA_HOME` 环境变量。
1. 修改 `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` 中的 JVMCapabilities 部分，需使用根权限。`jdk1.8.x_xxx.jdk` 取决于您的 jdk 版本。使其看起来像这样：
```xml
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
4. 安装 python 2.x（如果尚未安装）。
5. 安装 Xcode 命令行工具。
6. 安装 [`java`](https://www.npmjs.com/package/java) 桥接。您可以在终端中运行以下命令：
```
$ mkdir aspose.slides.nodejs
 
$ cd aspose.slides.nodejs
 
$ npm install java
```
7. 下载 Aspose.Slides for Node.js via Java 并将其解压到 `aspose.slides.nodejs/node_modules/aspose.slides.via.java`。
8. 在 `aspose.slides.nodejs` 文件夹中使用以下示例代码创建一个名为 `hello.js` 的测试文件：

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("幻灯片标题");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("完成");
```
9. 现在在命令提示符下运行 `node hello.js` 以执行它。


{{% alert color="primary" %}}

如果您在通过 Java 安装 Aspose.Slides for Node.js 的过程中遇到编译错误，请使用下列 [文章](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/)。

{{% /alert %}}