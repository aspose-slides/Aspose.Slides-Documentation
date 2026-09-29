---
title: "在 Java 中自訂 PowerPoint 字型"
linktitle: "自訂字型"
type: docs
weight: 20
url: /zh-hant/java/custom-font/
keywords:
- "字型"
- "自訂字型"
- "外部字型"
- "載入字型"
- "管理字型"
- "字型資料夾"
- "PowerPoint"
- "OpenDocument"
- "簡報"
- "Java"
- "Aspose.Slides"
description: "使用 Aspose.Slides for Java 在 PowerPoint 投影片中自訂字型，讓您的簡報在任何裝置上都保持清晰且一致。"
---
## **概述**

Aspose.Slides 允許您在簡報中使用自訂字型，而無需在作業系統上安裝它們。您可以從自訂資料夾載入字型、透過文件層級字型來源為特定簡報提供字型，或直接從二進位資料載入外部字型。

載入的字型會在簡報渲染或匯出時使用，例如匯出為 PDF、圖片以及其他支援的格式。這可確保在不同環境中簡報的輸出保持一致。本文亦說明如何檢查 Aspose.Slides 使用的字型資料夾，以及在使用外部字型後如何清除字型快取。

註冊自訂字型以供渲染與將字型嵌入 PPTX 檔案是分開的動作。如果必須將字型儲存在簡報本身，請明確使用字型嵌入功能。

簡報佈景主題可以為不同的書寫系統參照不同的字型族。這些對應會儲存字型名稱，但不會安裝或載入字型檔案。請參閱[腳本特定佈景字型](/slides/zh-hant/java/script-specific-font-mappings/)以管理對應，並使用下列載入選項讓參照的字型可供一致渲染。

{{% alert color="info" title="Note" %}}
Aspose Slides 允許您使用[loadExternalFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)方法載入以下字型：

* TrueType (.ttf) 和 TrueType Collection (.ttc) 字型。參閱[TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType (.otf) 字型。參閱[OpenType](https://en.wikipedia.org/wiki/OpenType)。
{{% /alert %}}

## **載入自訂字型**

Aspose.Slides 允許您載入簡報中使用的字型，而無需在系統上安裝它們。這會影響匯出結果，例如 PDF、圖片及其他支援的格式，使產生的文件在不同環境中保持一致。字型會從自訂目錄載入。

1. 指定一個或多個包含字型檔案的資料夾。
2. 呼叫靜態[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)方法，從這些資料夾載入字型。
3. 載入並渲染/匯出簡報。
4. 呼叫[FontsLoader.clearCache](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsloader/#clearCache--)以清除字型快取。

以下程式碼範例示範字型載入流程：

```java
import com.aspose.slides.*;

// 定義包含自訂字型檔案的資料夾。
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// 從指定的資料夾載入自訂字型。
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // 使用已載入的字型渲染/匯出簡報（例如 PDF、圖片或其他格式）。
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 工作完成後清除字型快取。
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)會將額外的資料夾加入字型搜尋路徑，但不會改變字型初始化的順序。字型會依下列順序初始化：

1. 作業系統的預設字型路徑。
1. 透過[FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsloader/)載入的路徑。
{{%/alert %}}

## **取得自訂字型資料夾**

Aspose.Slides 提供[getFontFolders](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsloader/#getFontFolders--) 方法，讓您查找字型資料夾。此方法會返回透過 `LoadExternalFonts` 方法加入的資料夾以及系統字型資料夾。

以下 Java 程式碼示範如何使用[getFontFolders](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsloader/#getFontFolders--)：

```java
import com.aspose.slides.*;

// 此行輸出搜尋字型檔案的資料夾。
// 這些資料夾是透過 LoadExternalFonts 方法加入的以及系統字型資料夾。
String[] fontFolders = FontsLoader.getFontFolders();
```

## **指定簡報使用的自訂字型**

Aspose.Slides 提供[setDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 屬性，讓您指定將在簡報中使用的外部字型。

以下 Java 程式碼示範如何使用[setDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 屬性：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // 對簡報進行處理
    // CustomFont1、CustomFont2 與來自 assets\fonts & global\fonts 資料夾及其子資料夾的字型可供簡報使用
} finally {
    if (pres != null) pres.dispose();
}
```

## **外部管理字型**

Aspose.Slides 提供[loadExternalFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，讓您從二進位資料載入外部字型。

以下 Java 程式碼示範以位元組陣列載入字型的流程：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // 外部字型在簡報生命週期內已載入
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **常見問題**

### 自訂字型會影響所有格式的匯出 (PDF、PNG、SVG、HTML) 嗎？

會。已連結的字型會在所有匯出格式的渲染器中使用。

### 自訂字型會自動嵌入產生的 PPTX 嗎？

不會。為渲染註冊字型與將字型嵌入 PPTX 是不同的動作。如需將字型內嵌於簡報檔案，必須使用明確的[嵌入功能](/slides/zh-hant/java/embedded-font/)。

### 可以控制當自訂字型缺少某些字形時的備援行為嗎？

可以。請設定[字型取代](/slides/zh-hant/java/font-substitution/)、[取代規則](/slides/zh-hant/java/font-replacement/)與[備援字型集合](/slides/zh-hant/java/fallback-font/)，以明確定義當請求的字形缺失時要使用哪個字型。

### 在 Linux/Docker 容器中可以不安裝字型就使用嗎？

部分可以。Aspose.Slides 可以從您自己的資料夾或位元組陣列使用字型，而不必全域安裝，但 Java 的字型支援仍需要映像中至少安裝一個字型。若缺少任何字型，載入會失敗，錯誤訊息為「Fontconfig head is null, check your fonts or fonts configuration」。請參閱[部署字型](/slides/zh-hant/java/deploy-fonts/)。

### 授權方面——可以在不受限制的情況下嵌入任何自訂字型嗎？

您必須自行負責字型授權的合規性。授權條款各不相同，有些授權禁止嵌入或商業使用。分發輸出前，請務必檢視字型的最終使用者授權協議 (EULA)。