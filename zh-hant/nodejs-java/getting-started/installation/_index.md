---
title: 安裝
type: docs
weight: 70
url: /zh-hant/nodejs-java/installation/
keywords:
- 安裝 Aspose.Slides
- 下載 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安裝
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何快速安裝 Aspose.Slides。逐步指南、系統需求與程式碼範例——立即開始使用 PowerPoint 簡報！"
---
## **簡介**

Aspose.Slides for Node.js via Java 是跨平台 API，可在任何安裝了 `Node.js` 和 [`java`](https://www.npmjs.com/package/java) 橋接的平台（Windows、Linux 和 macOS）上使用。

## **從 NPM 安裝**

您可以輕鬆從 [NPM](https://www.npmjs.com/) 安裝 Aspose.Slides for Node.js via Java。

1. 建立新資料夾，並使用以下指令初始化新專案：
	```
	$ npm init
```
	
2. 填寫標題和版本欄位（其餘欄位保留預設值）。

3. 使用以下指令安裝 Aspose.Slides for Node.js via Java：
	```
	$ npm install aspose.slides.via.java
```

如果在安裝過程中遇到任何問題，請參考此 [文章](/slides/zh-hant/nodejs-java/troubleshooting-installation/)。 

**使用範例**：

在您的專案資料夾中建立名為 `hello.js` 的檔案，並加入以下範例程式碼：

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **從 ZIP 壓縮檔安裝**

若要從 ZIP 壓縮檔安裝並使用 Aspose.Slides for Node.js via Java，請改為遵循以下說明：

### **Windows**

1. 安裝 JDK8 並設定 `JAVA_HOME` 環境變數。
1. 安裝 Node.js (https://nodejs.org/en/download/) 並將 node.exe 加入 `PATH`。
1. 安裝 node-gyp。
1. 安裝 Windows Build Tools。
1. 安裝 [`java`](https://www.npmjs.com/package/java) 橋接，並在命令提示字元以管理員身分執行以下指令：
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
```
6. [下載 Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/zh-hant/nodejs-java/) 並解壓縮至 `aspose.slides.nodejs/node_modules/aspose.slides.via.java`。
7. 在 `aspose.slides.nodejs` 資料夾中建立名為 `hello.js` 的檔案，使用以下範例程式碼：
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
8. 現在在命令提示字元執行 `node hello.js` 以執行它。

### **Linux**

1. 安裝 Node.js (https://nodejs.org/en/download/)。
1. 為 Linux 安裝 JDK8 並設定 `JAVA_HOME` 環境變數。
1. 安裝 python 2.x
1. 安裝 [`java`](https://www.npmjs.com/package/java) 橋接。您可以在終端機執行以下指令：
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
```
5. [下載 Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/zh-hant/nodejs-java/) 並解壓縮至 `aspose.slides.nodejs/node_modules/aspose.slides.via.java`。
6. 在 `aspose.slides.nodejs` 資料夾中使用此範例程式碼建立名為 `hello.js` 的測試檔案：
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. 現在在命令提示字元執行 `node hello.js` 以執行它。

### **Mac**

1. 安裝 Node.js (https://nodejs.org/en/download/)。
1. 為 Mac 安裝 JDK8 並設定 `JAVA_HOME` 環境變數。
1. Modify JVMCapabilities 段落於 `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist`，需具管理員權限。`jdk1.8.x_xxx.jdk` 依您的 JDK 版本而定。請將其設定為如下所示：
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
4. 安裝 python 2.x（如果尚未安裝）。
5. 安裝 Xcode Command Line Tools。
6. 安裝 [`java`](https://www.npmjs.com/package/java) 橋接。您可以在終端機執行以下指令：
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
```
7. 下載 Aspose.Slides for Node.js via Java 並將其解壓縮到 `aspose.slides.nodejs/node_modules/aspose.slides.via.java`。
8. 在 `aspose.slides.nodejs` 資料夾中使用此範例程式碼建立名為 `hello.js` 的測試檔案：
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. 現在在命令提示字元執行 `node hello.js` 以執行它。

{{% alert color="primary" %}}

如果在安裝 Aspose.Slides for Node.js via Java 時遇到編譯錯誤，請使用以下 [文章](https://docs.aspose.com/slides/zh-hant/nodejs-java/troubleshooting-installation/)。

{{% /alert %}}

## **常見問題**

**有免費版或試用限制嗎？**

是的，預設情況下，Aspose.Slides 以評估模式運行，會加上浮水印並可能有其他限制。若要解除限制，您需要套用有效的 [授權](/slides/zh-hant/nodejs-java/licensing/)。