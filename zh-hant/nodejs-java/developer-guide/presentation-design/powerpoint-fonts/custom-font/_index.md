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
description: "使用 JavaScript 與 Aspose.Slides for Node.js（透過 Java）自訂 PowerPoint 簡報的字型，讓您的簡報在任何裝置上都保持清晰且一致。"
---
## **概述**

Aspose.Slides 允許您在簡報中使用自訂字型，而不必在作業系統上安裝它們。您可以從自訂資料夾載入字型，透過文件層級的字型來源為特定簡報提供字型，或直接從二進位資料載入外部字型。

載入的字型會在簡報渲染或匯出時使用，例如匯出為 PDF、影像及其他支援格式。這可確保簡報輸出在不同環境下保持一致。本文亦說明如何檢查 Aspose.Slides 使用的字型資料夾，以及在使用外部字型後如何清除字型快取。

註冊自訂字型以供渲染與將字型嵌入 PPTX 檔案是分開的動作。若需要將字型儲存在簡報本身，請明確使用字型嵌入功能。

{{% alert color="primary" %}} 

Aspose Slides 允許您使用 [loadExternalFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法載入以下字型：

* TrueType (.ttf) 與 TrueType Collection (.ttc) 字型。請參閱 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType (.otf) 字型。請參閱 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **載入自訂字型**

Aspose.Slides 允許您在簡報中使用未安裝於系統的字型。這會影響匯出結果（如 PDF、影像及其他支援格式），使產出的文件在各環境中保持一致。字型會從自訂目錄載入。

1. 指定一個或多個包含字型檔案的資料夾。  
2. 呼叫靜態 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) 方法，從這些資料夾載入字型。  
3. 載入並渲染/匯出簡報。  
4. 呼叫 [FontsLoader.clearCache](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/clearcache/) 以清除字型快取。

以下程式碼範例示範字型載入流程：

```js
// 定義包含自訂字型檔案的資料夾。
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// 從指定的資料夾載入自訂字型。
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // 使用已載入的字型渲染/匯出簡報（例如 PDF、影像或其他格式）。
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 完成工作後清除字型快取。
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="注意" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) 會將其他資料夾加入字型搜尋路徑，但不會改變字型初始化順序。  
字型的初始化順序如下：

1. 作業系統的預設字型路徑。  
1. 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/) 載入的路徑。

{{%/alert %}}

## **取得自訂字型資料夾**
Aspose.Slides 提供 [getFontFolders](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) 方法，讓您找出字型資料夾。此方法會回傳透過 `LoadExternalFonts` 方法加入的資料夾以及系統字型資料夾。

以下 JavaScript 程式碼示範如何使用 [getFontFolders](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/#getFontFolders--)：

```javascript
// 此行輸出搜尋字型檔案的資料夾。
// 這些資料夾是透過 LoadExternalFonts 方法加入的以及系統字型資料夾。
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **指定在簡報中使用的自訂字型**
Aspose.Slides 提供 [setDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) 屬性，讓您指定將與簡報一起使用的外部字型。

以下 JavaScript 程式碼示範如何使用 [setDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) 屬性：

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // 對簡報進行操作
    // CustomFont1、CustomFont2，以及來自 assets\fonts 與 global\fonts 資料夾及其子資料夾的字型皆可供簡報使用
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **外部管理字型**

Aspose.Slides 提供 [loadExternalFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，讓您從二進位資料載入外部字型。

以下 JavaScript 程式碼示範以位元組陣列載入字型的流程：

```javascript
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

**自訂字型會影響所有格式的匯出（PDF、PNG、SVG、HTML）嗎？**

會。已連結的字型會在所有匯出格式的渲染程序中使用。

**自訂字型會自動嵌入產生的 PPTX 中嗎？**

不會。為渲染註冊的字型與將字型嵌入 PPTX 並非同一件事。若需要將字型儲存在簡報檔案內，必須使用明確的[嵌入功能](/slides/zh-hant/nodejs-java/embedded-font/)。

**當自訂字型缺少某些字形時，我可以控制回退行為嗎？**

可以。請設定[字型替代](/slides/zh-hant/nodejs-java/font-substitution/)、[替換規則](/slides/zh-hant/nodejs-java/font-replacement/) 與[回退集合](/slides/zh-hant/nodejs-java/fallback-font/)，以明確決定缺字形時使用哪個字型。

**我可以在 Linux/Docker 容器中使用字型而不必全系統安裝嗎？**

可以。指向您自己的字型資料夾或從位元組陣列載入字型，即可移除對容器映像系統字型目錄的依賴。

**授權方面—我可以無限制地嵌入任何自訂字型嗎？**

您必須自行負責字型授權合規。授權條款各異；有些授權禁止嵌入或商業使用。發布輸出前，請務必查閱字型的使用者授權合約（EULA）。