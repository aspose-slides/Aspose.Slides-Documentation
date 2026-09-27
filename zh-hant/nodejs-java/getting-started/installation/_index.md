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
description: "在 Windows、Linux 與 macOS 上，透過 npm 安裝適用於 Node.js via Java 的 Aspose.Slides：所需的 JDK、Python 與 C++ 建置工具、npm 指令，以及用以驗證安裝的第一支腳本。"
---
## **概述**

本文說明如何在 Windows、Linux 與 macOS 上透過 Java 為 Node.js 安裝 Aspose.Slides，以及如何驗證安裝是否成功。

Aspose.Slides for Node.js via Java 以 `aspose.slides.via.java` 套件在 npm 上發佈。它透過 [`java`](https://github.com/joeferner/node-java) 套件在 Java 虛擬機中執行 Aspose.Slides，該套件是 npm 在安裝過程中於您的電腦編譯的原生 Node.js 附加元件。因此，除了 Node.js 之外，安裝還需要：

- **Java Development Kit (JDK) 8 或更新版本。** 僅有 Java 執行時環境不足：建置需要 JDK 的標頭檔。
- **Python 3**，此為建置工具 [node-gyp](https://github.com/nodejs/node-gyp) 所使用的。
- **C++ 建置工具鏈**，適用於您的作業系統。

## **安裝前置條件**

### **Windows**

1. 安裝 [Node.js](https://nodejs.org/en/download) 20 或更新版本。
2. 安裝 JDK，例如 [Eclipse Temurin](https://adoptium.net/)，並將 `JAVA_HOME` 環境變數設定為其安裝目錄。建置會使用 `JAVA_HOME` 所指向的 JDK。
3. 安裝 [Python 3](https://www.python.org/downloads/)。
4. 安裝 [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) 並選取 **Desktop development with C++** 工作負載。保留工作負載的預設元件，其中包含 **MSVC v143 - VS 2022 C++ x64/x86 build tools** 以及 **Windows 11 SDK**。Visual Studio 2026 無法使用：`java` 套件編譯所使用的 node-gyp 版本不支援它。

### **Linux**

安裝 Node.js 20 或更新版本，可從 [nodejs.org](https://nodejs.org/en/download) 或您的發行版套件來源取得。接著安裝 JDK、Python 3 與 C++ 建置工具。在 Debian 與 Ubuntu 上：

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

在 Linux 上，建置會自動偵測已安裝的 JDK，無需額外設定。如果系統安裝了多個 JDK，請將 `JAVA_HOME` 設為您欲使用的那一個。

### **macOS**

安裝 Node.js 20 或更新版本、JDK，以及包含 Python 3 與 C++ 編譯器的 Xcode 命令列工具。請參考 [Troubleshooting Installation](/slides/zh-hant/nodejs-java/troubleshooting-installation/) 以取得 macOS 的特定說明。

## **Install from npm**

建立專案資料夾並安裝套件：

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm 會下載 Aspose.Slides 並編譯 `java` 橋接程式，這可能需要幾分鐘。若編譯失敗，請參考 [Troubleshooting Installation](/slides/zh-hant/nodejs-java/troubleshooting-installation/)。

## **Check the Installation**

在專案資料夾中建立名為 *hello.js* 的檔案，內容如下。它會建立簡報、在第一張投影片新增文字方塊，並將結果儲存為 *hello.pptx*：

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

// Aspose.Slides 在 Java 虛擬機中執行，會使 Node.js 持續執行，因此需明確結束行程。
process.exit(0);
```

執行腳本：

```bash
node hello.js
```

如果在專案資料夾中出現 *hello.pptx*，則表示安裝成功。執行 Aspose.Slides 的 Java 虛擬機會阻止 Node.js 自行退出，這也是腳本以 `process.exit(0)` 結束的原因。[Create Presentations](/slides/zh-hant/nodejs-java/create-presentation/) 會說明此程式碼。

## **Install from a ZIP Archive**

此套件亦提供與 npm 套件相同內容的 ZIP 壓縮檔。若要從壓縮檔安裝，請執行以下步驟：

1. 安裝如前所述的作業系統前置條件。
2. 從 [Aspose.Slides for Node.js via Java download page](https://releases.aspose.com/slides/nodejs-java/) 下載壓縮檔。
3. 建立專案資料夾：

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. 將壓縮檔解壓縮至專案資料夾內名為 *aspose.slides.via.java* 的子資料夾，使壓縮檔中的 *package.json* 位於 *hello-slides/aspose.slides.via.java/package.json*。
5. 從該資料夾安裝套件：

    ```bash
    npm install ./aspose.slides.via.java
    ```

npm 會安裝套件相依的 `java` 橋接程式並編譯，與 npm 套件的安裝流程相同。

依照 [Check the Installation](#check-the-installation) 中的說明檢查安裝。

## **FAQ**

**是否有免費版或試用限制？**

是的。若未取得授權，Aspose.Slides 會以評估模式執行：會在每張儲存的投影片上加上評估浮水印，且會截斷從簡報讀取的文字。若要移除這些限制，請套用有效的 [license](/slides/zh-hant/nodejs-java/licensing/) 授權。

**為何腳本在完成後未退出？**

`java` 套件會在 Node.js 行程內啟動 Java 虛擬機，而該虛擬機會讓行程持續執行。當腳本完成工作時，請呼叫 `process.exit`。