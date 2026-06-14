---
title: 安裝
type: docs
weight: 70
url: /zh-hant/nodejs-net/installation/
keywords:
- 下載 Aspose.Slides
- 安裝 Aspose.Slides
- Aspose.Slides 安裝
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "在 Windows、Linux 或 macOS 上安裝 Aspose.Slides for Node.js via .NET"
---
Aspose.Slides for Node.js via .NET 是跨平台的 API，可在任何安裝了 `Node.js` 與 `edge-js` 橋接的平台（Windows、Linux 與 MacOS）上使用。

## **從 NPM 安裝**

您可以透過以下指令輕鬆從 [NPM](https://www.npmjs.com/) 安裝 Aspose.Slides for Node.js via .NET：
```
$ npm install aspose.slides.via.net
```
如果在安裝過程中遇到任何問題，請參考 https://www.npmjs.com/package/edge-js。

## **從 ZIP 壓縮檔安裝**

若要從 ZIP 壓縮檔安裝並使用 Aspose.Slides for Node.js via .NET，請改依照下列說明操作：

### **Windows**

1. 安裝 .NET6 或以上版本。  
2. 安裝 Node.js (https://nodejs.org/en/download/) 並將 node.exe 加入 `PATH`。  
3. 安裝 edge-js。  
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```  
6. [下載 Aspose.Slides for Node.js via .NET](https://releases.aspose.com/slides/zh-hant/nodejs-net/) 並將其解壓縮至 `aspose.slides.nodejs/node_modules/aspose.slides.via.net`。  
7. 在 `aspose.slides.nodejs.net` 資料夾中建立名為 `hello.js` 的檔案，並使用以下範例程式碼：  

```javascript
// 匯入用於 PowerPoint 檔案操作的 Aspose.Slides 模組
const asposeSlides = require('aspose.slides.via.net');

// 加入來自 asposeSlides 的必要類別
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// 建立並儲存一個空的簡報以展示基本功能
function createEmptyPresentation() {
	
    // 初始化一個新的空簡報
    var emptyPresentation = new Presentation();
    
    // 以 PPTX 格式儲存空簡報
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // 釋放與簡報相關的資源
    emptyPresentation.dispose();
}

createEmptyPresentation(); // 執行函式以建立空簡報
```

8. 現在在命令提示字元中執行 `node hello.js` 以執行它。

### **Linux**

1. 安裝 .NET6 或以上版本。  
2. 安裝 Node.js (https://nodejs.org/en/download/) 並將 node.exe 加入 `PATH`。  
3. 安裝 edge-js。  
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```  
5. [下載 Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/zh-hant/nodejs-net/) 並將其解壓縮至 `aspose.slides.nodejs/node_modules/aspose.slides.via.net`。  
6. 在 `aspose.slides.nodejs.net` 資料夾中建立名為 `hello.js` 的測試檔，並使用以下範例程式碼：  

```javascript
// 匯入用於 PowerPoint 檔案操作的 Aspose.Slides 模組
const asposeSlides = require('aspose.slides.via.net');

// 從 asposeSlides 加入必要的類別
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// 建立並儲存空簡報以示範基本功能
function createEmptyPresentation() {
	
    // 初始化一個新的空簡報
    var emptyPresentation = new Presentation();
    
    // 以 PPTX 格式儲存空簡報
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // 釋放與簡報相關的資源
    emptyPresentation.dispose();
}

createEmptyPresentation(); // 執行函式以建立空簡報
```

7. 現在在命令提示字元中執行 `node hello.js` 以執行它。

### **Mac**

1. 安裝 .NET6 或以上版本。  
2. 安裝 Node.js (https://nodejs.org/en/download/) 並將 node.exe 加入 `PATH`。  
3. 安裝 edge-js。  

$ mkdir aspose.slides.nodejs.net  
$ cd aspose.slides.nodejs.net  
$ npm install edge-js  
```

```javascript
// Import the Aspose.Slides module for PowerPoint file manipulation
const asposeSlides = require('aspose.slides.via.net');

// Add necessary classes from the asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Create and save an empty presentation to demonstrate basic functionality
function createEmptyPresentation() {
    
    // Initialize a new empty presentation
    var emptyPresentation = new Presentation();
    
    // Save the empty presentation in PPTX format
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Release resources associated with the presentation
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Execute the function to create an empty presentation
9. 現在在命令提示字元中執行 `node hello.js` 以執行它。