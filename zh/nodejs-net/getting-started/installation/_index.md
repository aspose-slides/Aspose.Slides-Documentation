---
title: 安装
type: docs
weight: 70
url: /nodejs-net/installation/
keySlides: "下载 Aspose.Slides，安装 Aspose.Slides，Aspose.Slides 安装，Windows，macOS，Linux，Javascript，Node.js"
description: "在 Windows、Linux 或 macOS 上通过 .NET 安装 Aspose.Slides for Node.js"
---

Aspose.Slides for Node.js via .NET 是一个独立于平台的 API，可以在安装了 `Node.js` 和 `edge-js` 桥接的任何平台（Windows、Linux 和 macOS）上使用。

## **从 NPM 安装**

你可以通过以下命令轻松从 [NPM](https://www.npmjs.com/) 安装 Aspose.Slides for Node.js via .NET：
```
$ npm install aspose.slides.via.net
```
如果在安装过程中遇到任何问题，请参考 https://www.npmjs.com/package/edge-js。

## **从 ZIP 文件安装**

要从 ZIP 文件安装和使用 Aspose.Slides for Node.js via .NET，请按照以下说明进行：

### **Windows**

1. 安装 .NET6 或更高版本。
2. 安装 Node.js (https://nodejs.org/en/download/) 并将 node.exe 添加到 `PATH`。
3. 安装 edge-js。
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [下载 Aspose.Slides for Node.js via .NET](https://releases.aspose.com/slides/nodejs-net/) 并将其解压到 `aspose.slides.nodejs/node_modules/aspose.slides.via.net`。
7. 使用以下示例代码在 `aspose.slides.nodejs.net` 文件夹中创建一个名为 `hello.js` 的文件：

```javascript
// 导入 Aspose.Slides 模块以进行 PowerPoint 文件操作
const asposeSlides = require('aspose.slides.via.net');

// 从 asposeSlides 添加必要的类
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// 创建并保存一个空演示文稿以演示基本功能
function createEmptyPresentation() {
	
    // 初始化一个新的空演示文稿
    var emptyPresentation = new Presentation();
    
    // 以 PPTX 格式保存空演示文稿
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // 释放与演示文稿相关的资源
    emptyPresentation.dispose();
}

createEmptyPresentation(); // 执行函数以创建空演示文稿
```

8. 现在在命令提示符下运行 `node hello.js` 来执行它。

### **Linux**

1. 安装 .NET6 或更高版本。
2. 安装 Node.js (https://nodejs.org/en/download/) 并将 node.exe 添加到 `PATH`。
3. 安装 edge-js。
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [下载 Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-net/) 并将其解压到 `aspose.slides.nodejs/node_modules/aspose.slides.via.net`。
6. 在 `aspose.slides.nodejs.net` 文件夹中使用此示例代码创建一个名为 `hello.js` 的测试文件：

```javascript
// 导入 Aspose.Slides 模块以进行 PowerPoint 文件操作
const asposeSlides = require('aspose.slides.via.net');

// 从 asposeSlides 添加必要的类
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// 创建并保存一个空演示文稿以演示基本功能
function createEmptyPresentation() {
	
    // 初始化一个新的空演示文稿
    var emptyPresentation = new Presentation();
    
    // 以 PPTX 格式保存空演示文稿
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // 释放与演示文稿相关的资源
    emptyPresentation.dispose();
}

createEmptyPresentation(); // 执行函数以创建空演示文稿
```
7. 现在在命令提示符下运行 `node hello.js` 来执行它。

### **Mac**

1. 安装 .NET6 或更高版本。
2. 安装 Node.js (https://nodejs.org/en/download/) 并将 node.exe 添加到 `PATH`。
3. 安装 edge-js。

```
$ mkdir aspose.slides.nodejs.net
 
$ cd aspose.slides.nodejs.net
 
$ npm install edge-js
```

```javascript
// 导入 Aspose.Slides 模块以进行 PowerPoint 文件操作
const asposeSlides = require('aspose.slides.via.net');

// 从 asposeSlides 添加必要的类
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// 创建并保存一个空演示文稿以演示基本功能
function createEmptyPresentation() {
	
    // 初始化一个新的空演示文稿
    var emptyPresentation = new Presentation();
    
    // 以 PPTX 格式保存空演示文稿
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // 释放与演示文稿相关的资源
    emptyPresentation.dispose();
}

createEmptyPresentation(); // 执行函数以创建空演示文稿
```
9. 现在在命令提示符下运行 `node hello.js` 来执行它。