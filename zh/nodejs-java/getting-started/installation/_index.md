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
description: "了解如何快速安装 Aspose.Slides。分步指南、系统要求和代码示例——今天就开始使用 PowerPoint 演示文稿！"
---

Aspose.Slides for Node.js via Java 是跨平台的 API，可在任何平台（Windows、Linux 和 MacOS）上使用，只要已安装 `Node.js` 和 [`java`](https://www.npmjs.com/package/java) 桥接。

## **从 NPM 安装**

您可以轻松从 [NPM](https://www.npmjs.com/) 安装 Aspose.Slides for Node.js via Java。

1. 创建一个新文件夹并使用以下命令初始化新项目：
```
	$ npm init
```

2. 填写 title 和 version 字段（其余字段保持默认值）。
3. 使用以下命令安装 Aspose.Slides for Node.js via Java：
	```
	$ npm install aspose.slides.via.java
	```


如果在安装过程中遇到任何问题，请参阅此 [文章](/slides/zh/nodejs-java/troubleshooting-installation/)。

**使用示例**：

在项目文件夹中创建名为 `hello.js` 的文件，并添加以下示例代码：
```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```


## **从 ZIP 存档安装**

要从 ZIP 存档安装并使用 Aspose.Slides for Node.js via Java，请改为遵循以下说明：

### **Windows**

1. 安装 JDK8 并配置 `JAVA_HOME` 环境变量。
1. 安装 Node.js (https://nodejs.org/en/download/) 并将 node.exe 添加到 `PATH`。
1. 安装 node-gyp。
1. 安装 Windows Build Tools。
1. 安装 [`java`](https://www.npmjs.com/package/java) 桥接，并以管理员身份在命令提示符中运行以下命令：
```bash
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install -g node-gyp

$ npm install --global --production windows-build-tools

$ npm install java
```

6. [下载 Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) 并将其解压到 `aspose.slides.nodejs/node_modules/aspose.slides.via.java`。
7. 在 `aspose.slides.nodejs` 文件夹中创建名为 `hello.js` 的文件，并使用以下示例代码：
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

8. 现在在命令提示符下运行 `node hello.js` 以执行它。

### **Linux**

1. 安装 Node.js (https://nodejs.org/en/download/)。
1. 为 Linux 安装 JDK8 并配置 `JAVA_HOME` 环境变量。
1. 安装 python 2.x
1. 安装 [`java`](https://www.npmjs.com/package/java) 桥接。您可以在终端中运行以下命令：
```bash
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install java
```

5. [下载 Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) 并将其解压到 `aspose.slides.nodejs/node_modules/aspose.slides.via.java`。
6. 在 `aspose.slides.nodejs` 文件夹中使用此示例代码创建名为 `hello.js` 的测试文件：
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

7. 现在在命令提示符下运行 `node hello.js` 以执行它。

### **Mac**

1. 安装 Node.js (https://nodejs.org/en/download/)。
1. 为 Mac 安装 JDK8 并配置 `JAVA_HOME` 环境变量。
1. 使用根权限修改 `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` 中的 JVMCapabilities 部分。`jdk1.8.x_xxx.jdk` 取决于您的 JDK 版本。修改后应如下所示：
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
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```

7. 下载 Aspose.Slides for Node.js via Java 并将其解压到 `aspose.slides.nodejs/node_modules/aspose.slides.via.java`。
8. 在 `aspose.slides.nodejs` 文件夹中使用此示例代码创建名为 `hello.js` 的测试文件：
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

9. 现在在命令提示符下运行 `node hello.js` 以执行它。

{{% alert color="primary" %}}
如果在安装 Aspose.Slides for Node.js via Java 时遇到编译错误，请使用以下 [文章](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/)。
{{% /alert %}}

## **常见问题**

**是否有免费版或试用限制？**

是的，默认情况下，Aspose.Slides 处于评估模式，会添加水印并可能存在其他限制。要移除这些限制，您需要应用有效的 [许可证](/slides/zh/nodejs-java/licensing/)。