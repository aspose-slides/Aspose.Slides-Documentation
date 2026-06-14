---
title: 在 Android 上自訂 PowerPoint 字型
linktitle: 自訂字型
type: docs
weight: 20
url: /zh-hant/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 及 Java 在 PowerPoint 投影片中自訂字型，確保您的簡報在任何裝置上皆保持清晰且一致。"
---
## **概觀**

Aspose.Slides 允許您在簡報中使用自訂字型，而無需在作業系統上安裝它們。您可以從自訂資料夾載入字型，透過文件層級的字型來源為特定簡報提供字型，或直接從二進位資料載入外部字型。

載入的字型會在簡報渲染或匯出時使用，例如匯出為 PDF、影像及其他支援的格式。此機制有助於在不同環境中保持簡報輸出的一致性。本文亦說明如何檢查 Aspose.Slides 使用的字型資料夾，以及在使用外部字型後如何清除字型快取。

註冊自訂字型供渲染使用與將字型嵌入 PPTX 檔案是分開的。如需將字型儲存在簡報本身內，請明確使用字型嵌入功能。

{{% alert color="primary" %}} 

Aspose Slides 允許您使用 [loadExternalFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法載入這些字型：

* TrueType（.ttf）與 TrueType Collection（.ttc）字型。請參考 [TrueType](https://en.wikipedia.org/wiki/TrueType)。

* OpenType（.otf）字型。請參考 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **載入自訂字型**

Aspose.Slides 允許您在簡報中載入使用的字型，而無需在系統上安裝它們。這會影響匯出結果—例如 PDF、影像及其他支援的格式—使產生的文件在不同環境中保持一致。字型從自訂目錄載入。

1. 指定一個或多個包含字型檔案的資料夾。  
2. 呼叫靜態的 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法，從這些資料夾載入字型。  
3. 載入並渲染/匯出簡報。  
4. 呼叫 [FontsLoader.clearCache](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontsLoader#clearCache--) 以清除字型快取。

以下程式碼範例示範字型載入流程：

```java
// 定義包含自訂字型檔案的資料夾。
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// 從指定的資料夾載入自訂字型。
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // 使用載入的字型渲染/匯出簡報（例如 PDF、影像或其他格式）。
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 工作完成後清除字型快取。
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 會將額外的資料夾加入字型搜尋路徑，但不會改變字型初始化的順序。  
字型的初始化順序如下：

1. 系統預設的作業系統字型路徑。  
1. 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/) 加載的路徑。

{{%/alert %}}

## **取得自訂字型資料夾**

Aspose.Slides 提供 [getFontFolders](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) 方法，讓您取得字型資料夾。此方法會回傳透過 `LoadExternalFonts` 方法加入的資料夾以及系統字型資料夾。

此 Java 程式碼示範如何使用 [getFontFolders](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/#getFontFolders--)：

```java
// 此行輸出搜尋字型檔案的資料夾。
// 這些資料夾是透過 LoadExternalFonts 方法加入的以及系統字型資料夾。
String[] fontFolders = FontsLoader.getFontFolders();
```

## **指定簡報使用的自訂字型**

Aspose.Slides 提供 [setDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 屬性，讓您指定簡報將使用的外部字型。

此 Java 程式碼示範如何使用 [setDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 屬性：

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // 對簡報進行操作
    // CustomFont1、CustomFont2，以及來自 assets\fonts 與 global\fonts 資料夾及其子資料夾的字型皆可在簡報中使用
} finally {
    if (pres != null) pres.dispose();
}
```

## **在外部管理字型**

Aspose.Slides 提供 [loadExternalFont](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，讓您從二進位資料載入外部字型。

此 Java 程式碼示範以位元組陣列載入字型的過程：

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // 外部字型在簡報的生命週期內已載入
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

**自訂字型會影響所有格式的匯出嗎（PDF、PNG、SVG、HTML）？**

會。已連結的字型會在渲染器中被所有匯出格式使用。

**自訂字型會自動嵌入產生的 PPTX 中嗎？**

不會。為渲染註冊字型與將字型嵌入 PPTX 並非同一件事。若需將字型包含在簡報檔案中，必須使用明確的[嵌入功能](/slides/zh-hant/androidjava/embedded-font/)。

**當自訂字型缺少某些字形時，我能控制備援行為嗎？**

可以。請設定 [font substitution](/slides/zh-hant/androidjava/font-substitution/)、[replacement rules](/slides/zh-hant/androidjava/font-replacement/) 與 [fallback sets](/slides/zh-hant/androidjava/fallback-font/)，以明確定義在請求的字形缺失時使用哪一個字型。

**我可以在 Linux/Docker 容器中使用字型而不需在系統層面安裝嗎？**

可以。指向您自己的字型資料夾或從位元組陣列載入字型。這樣即可移除容器映像檔中對系統字型目錄的任何依賴。

**關於授權——我可以無限制地嵌入任何自訂字型嗎？**

您必須自行負責字型授權的合規性。授權條款各有不同，有些授權禁止嵌入或商業使用。請在發佈輸出之前，務必檢視字型的 EULA。