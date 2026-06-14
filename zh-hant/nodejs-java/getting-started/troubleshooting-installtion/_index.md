---
title: Aspose.Slides for Node.js via Java 安裝故障排除
linktitle: 故障排除安裝
type: docs
weight: 75
url: /zh-hant/nodejs-java/troubleshooting-installation/
keywords:
- 下載 Aspose.Slides
- 安裝 Aspose.Slides
- 故障排除安裝
- 版本需求
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "排除 Aspose.Slides for Node.js via Java 安裝問題，修復常見錯誤與相依性，確保 PPT、PPTX 與 ODP 能順利運作。"
---
## **簡介**

當使用 `npm` [安裝](/slides/zh-hant/nodejs-java/installation/) `aspose.slides.via.java` 時，可能會在 `java` 與 `node-gyp` 模組的編譯過程中發生錯誤。我們已更深入地調查這些錯誤，並找出對已安裝程式與套件版本的具體需求。

## **版本需求**

1. 針對 Node.js 12 及更早版本：
   - Python 版本不得高於 3.10。
   - 對於 Windows，建議安裝 Visual Studio Build Tools，版本不高於 2017。
   - npm java 套件版本：0.12.1。

2. 針對 Node.js 13：
   - 與 Node.js 12 的需求相同。

3. 針對 Node.js 14：
   - Python 3.10。
   - npm java 套件版本：0.14.0。

4. 針對 Node.js 15：
   - Python 3.12。
   - npm java 套件版本：0.14.0。

5. 針對 Node.js 16 及更新版本：
   - Python 3.12。
   - npm java 套件版本：0.14.0。

**請依照以下說明安裝所需程式。**

### **在 Unix 上安裝**

- 安裝 [Node.js](https://nodejs.org/en/download)。
- 安裝 [Python](https://devguide.python.org/versions/)。
- 安裝 Java (JDK 1.8)。
- 安裝適當的 C/C++ 編譯器工具鏈，例如 [GCC](https://gcc.gnu.org)。

### **在 macOS 上安裝**

- 安裝 [Node.js](https://nodejs.org/en/download)。
- 安裝 [Python](https://devguide.python.org/versions)。
- 安裝 Java (JDK 1.8) 並以 root 權限修改 /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist 中的 JVMCapabilities 區段。jdk1.8.x_xxx.jdk 依您的 JDK 版本而異。請將其調整為如下所示：
```
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
- 透過執行 `xcode-select --install` 以單獨安裝 `Xcode Command Line Tools`。-- OR -- 或者，如果您已安裝 [完整的 Xcode](https://developer.apple.com/xcode/download/) ，可在選單 `Xcode -> Open Developer Tool -> More Developer Tools...` 中安裝 Command Line Tools。

### **在 Windows 上安裝**

- 安裝 [Node.js](https://nodejs.org/en/download)。
- 從 [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation) 安裝 [Python](https://devguide.python.org/versions/)。
- 安裝 Java (JDK 1.8)。
- 安裝 [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools)（若使用早於 VS2019 的版本，請使用「Visual C++ build tools」；否則請選取「Desktop development with C++」工作負載，或安裝 [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) 並使用「Desktop development with C++」工作負載）。
- 確保 Node.js、Python 與 Java 已加入 PATH 環境變數。

## **在 Node.js 14 及更新版本上安裝 Aspose.Slides for Node.js via Java**

只需使用以下指令：
```
npm i aspose.slides.via.java
```

## **在 Node.js 12 或 13 版上安裝 Aspose.Slides for Node.js via Java**

Aspose.Slides for Node.js via Java 需要手動安裝。請使用以下指令：

- 針對 Node.js 12：
```
npm i java@0.12.1
```
- 針對 Node.js 13：
```
npm i java@0.13.0
```

之後，下載 [aspose.slides.via.java](https://releases.aspose.com/slides/zh-hant/nodejs-java/) 並解壓縮至 `node_modules/aspose.slides.via.java` 資料夾。

## **驗證安裝**

要驗證安裝，請在專案根目錄建立一個名為 `index.js` 的檔案，內容如下：
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

使用指令 `node index.js` 執行此檔案。

## **其他資訊**

本文無法涵蓋所有可能的問題。由於問題多因 `java` 與 `node-gyp` 模組的編譯所致，以下連結也很有幫助：
- [java 安裝](https://www.npmjs.com/package/java#installation) 
- [node-gyp 安裝](https://www.npmjs.com/package/node-gyp#installation)