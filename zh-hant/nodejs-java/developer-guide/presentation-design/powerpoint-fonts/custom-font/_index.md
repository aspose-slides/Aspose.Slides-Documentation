---
title: 在 JavaScript 中自訂 PowerPoint 字型
linktitle: 自訂字型
type: docs
weight: 20
url: /zh-hant/nodejs-java/custom-font/
keywords:
- 字型
- 自訂字型
- 外部字型
- 載入字型
- 管理字型
- 字型資料夾
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 以及 Aspose.Slides for Node.js（透過 Java）在 PowerPoint 投影片中自訂字型，讓您的簡報在任何裝置上都保持清晰且一致。"
---
## **概述**

Aspose.Slides 允許您在簡報中使用自訂字型，而無需在作業系統上安裝它們。您可以從自訂資料夾載入字型、透過文件層級的字型來源為特定簡報提供字型，或直接從二進位資料載入外部字型。

載入的字型會在簡報呈現或匯出時使用，例如匯出為 PDF、影像及其他支援的格式。這有助於在不同環境中保持簡報輸出的相容性。本文亦說明如何檢查 Aspose.Slides 使用的字型資料夾，以及在使用外部字型後如何清除字型快取。

註冊自訂字型以供渲染，與將字型嵌入 PPTX 檔案是分開的操作。若必須將字型儲存於簡報內部，請明確使用字型嵌入功能。

簡報主題可以為各個書寫系統參照不同的字型系列。這些對映僅存放字型名稱，並不會安裝或載入字型檔案。請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/nodejs-java/script-specific-font-mappings/) 以管理對映，並使用下方的載入選項，使參照的字型可用於一致的呈現。

{{% alert color="info" title="Note" %}}
Aspose Slides 允許您使用 [loadExternalFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法載入這些字型：

* TrueType (.ttf) 與 TrueType Collection (.ttc) 字型。請參閱 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType (.otf) 字型。請參閱 [OpenType](https://en.wikipedia.org/wiki/OpenType)。
{{% /alert %}}

## **載入自訂字型**

Aspose.Slides 允許您在系統上不安裝字型的情況下載入簡報中使用的字型。這會影響匯出輸出——如 PDF、影像以及其他支援的格式——使產生的文件在各環境中保持一致。字型是從自訂目錄載入的。

1. 指定一個或多個包含字型檔案的資料夾。
2. 呼叫靜態的 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) 方法，從這些資料夾載入字型。
3. 載入並呈現/匯出簡報。
4. 呼叫 [FontsLoader.clearCache](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/clearcache/) 以清除字型快取。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 定義包含自訂字型檔案的資料夾。
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// 從指定的資料夾載入自訂字型。
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // 使用載入的字型呈現/匯出簡報（例如 PDF、影像或其他格式）。
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 完成工作後清除字型快取。
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) 會將額外的資料夾加入字型搜尋路徑，但不會變更字型初始化順序。字型會依以下順序初始化：

1. 預設作業系統字型路徑。
1. 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/) 載入的路徑。
{{%/alert %}}

## **取得自訂字型資料夾**

Aspose.Slides 提供 [getFontFolders](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) 方法，讓您找出字型資料夾。此方法會回傳透過 `LoadExternalFonts` 方法加入的資料夾以及系統字型資料夾。

此 JavaScript 程式碼示範如何使用 [getFontFolders](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/#getFontFolders--)：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 此行輸出搜尋字型檔案的資料夾。
// 這些是透過 LoadExternalFonts 方法加入的資料夾以及系統字型資料夾。
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **指定簡報使用的自訂字型**

Aspose.Slides 提供 [setDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) 屬性，讓您指定將與簡報一起使用的外部字型。

此 JavaScript 程式碼示範如何使用 [setDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) 屬性：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // 處理簡報
    // CustomFont1、CustomFont2，以及來自 assets\fonts 與 global\fonts 資料夾及其子資料夾的字型均可供簡報使用
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **外部管理字型**

Aspose.Slides 提供 [loadExternalFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，讓您從二進位資料載入外部字型。

此 JavaScript 程式碼示範 byte 陣列字型載入流程：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // 簡報生命週期內已載入外部字型
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **常見問題**

### 自訂字型是否會影響所有格式的匯出 (PDF、PNG、SVG、HTML)？

是。連結的字型會由轉譯器在所有匯出格式中使用。

### 自訂字型是否會自動嵌入到產生的 PPTX 中？

不。註冊字型以供渲染，與將字型嵌入 PPTX 並非同一件事。若需要將字型內嵌於簡報檔案，必須使用明確的 [embedding features](/slides/zh-hant/nodejs-java/embedded-font/)。

### 當自訂字型缺少特定字形時，我可以控制備援行為嗎？

可以。請設定 [font substitution](/slides/zh-hant/nodejs-java/font-substitution/)、[replacement rules](/slides/zh-hant/nodejs-java/font-replacement/) 與 [fallback sets](/slides/zh-hant/nodejs-java/fallback-font/)，以明確指定在請求的字形缺失時使用哪一個字型。

### 我可以在 Linux/Docker 容器中使用字型而不必全系統安裝嗎？

可以。指向您自己的字型資料夾或從 byte 陣列載入字型。這樣即可移除容器映像中對系統字型目錄的任何依賴。

### 關於授權—我可以在不受限制的情況下嵌入任何自訂字型嗎？

您須自行負責字型授權的合規性。授權條款各有不同，有些授權禁止嵌入或商業使用。發布輸出前請務必檢查字型的終端使用者授權協議 (EULA)。