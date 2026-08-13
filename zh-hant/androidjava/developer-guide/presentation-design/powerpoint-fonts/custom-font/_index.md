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
description: "使用 Aspose.Slides for Android 以 Java 自訂 PowerPoint 投影片的字型，確保您的簡報在任何裝置上都保持清晰一致。"
---
## **概觀**

Aspose.Slides 允許您在簡報中使用自訂字型，而無需在作業系統上安裝它們。您可以從自訂資料夾載入字型，透過文件層級字型來源為特定簡報提供字型，或直接從二進位資料載入外部字型。

載入的字型會在簡報轉譯或匯出時使用，例如匯出為 PDF、影像及其他支援的格式。這有助於在不同環境中保持簡報輸出的相容性。本文還說明如何檢查 Aspose.Slides 使用的字型資料夾，以及在使用外部字型後如何清除字型快取。

註冊自訂字型以供轉譯使用與將字型嵌入 PPTX 檔案是分開的。如果必須將字型儲存於簡報本身，請明確使用字型嵌入功能。

{{% alert color="info" %}} 

Aspose Slides 允許您使用 [loadExternalFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法載入這些字型：

* TrueType (.ttf) 和 TrueType Collection (.ttc) 字型。請參閱 [TrueType](https://en.wikipedia.org/wiki/TrueType)。

* OpenType (.otf) 字型。請參閱 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **載入自訂字型**

Aspose.Slides 允許您在不安裝字型至系統的情況下載入簡報中使用的字型。這會影響匯出結果──例如 PDF、影像及其他支援的格式──使產生的文件在各環境中保持一致。字型會從自訂目錄載入。

1. 指定一個或多個包含字型檔案的資料夾。
2. 呼叫靜態的 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法，從這些資料夾載入字型。
3. 載入並轉譯/匯出簡報。
4. 呼叫 [FontsLoader.clearCache](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontsLoader#clearCache--) 以清除字型快取。

以下程式碼範例展示字型載入的過程：

```java
import com.aspose.slides.*;

// 定義包含自訂字型檔案的資料夾。
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// 從指定的資料夾載入自訂字型。
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // 使用已載入的字型轉譯/匯出簡報（例如 PDF、影像或其他格式）。
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 工作完成後清除字型快取。
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="備註" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 會將額外的資料夾加入字型搜尋路徑，但不會變更字型的初始化順序。  
字型會依以下順序初始化：

1. 預設的作業系統字型路徑。  
1. 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/) 載入的路徑。

{{%/alert %}}

## **取得自訂字型資料夾**
Aspose.Slides 提供 [getFontFolders](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) 方法，讓您找出字型資料夾。此方法會回傳透過 `LoadExternalFonts` 方法加入的資料夾以及系統字型資料夾。

以下 Java 程式碼示範如何使用 [getFontFolders](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/#getFontFolders--)：

```java
import com.aspose.slides.*;

// 這行會輸出搜尋字型檔案的資料夾。
// 這些是透過 LoadExternalFonts 方法加入的資料夾以及系統字型資料夾。
String[] fontFolders = FontsLoader.getFontFolders();
```

## **指定簡報使用的自訂字型**
Aspose.Slides 提供 [setDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 屬性，讓您指定將在簡報中使用的外部字型。

以下 Java 程式碼示範如何使用 [setDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 屬性：

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
    // 與簡報互動
    // CustomFont1、CustomFont2，以及來自 assets\fonts & global\fonts 資料夾及其子資料夾的字型皆可於簡報中使用
} finally {
    if (pres != null) pres.dispose();
}
```

## **從外部管理字型**

Aspose.Slides 提供 [loadExternalFont](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，讓您從二進位資料載入外部字型。

以下 Java 程式碼示範使用位元組陣列載入字型的過程：

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
        // 簡報生命週期內載入的外部字型
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **常見問題**

### 自訂字型會影響所有格式的匯出嗎（PDF、PNG、SVG、HTML）？

會。連結的字型會由轉譯器在所有匯出格式中使用。

### 自訂字型會自動嵌入至最終的 PPTX 嗎？

不會。將字型註冊供轉譯使用與將其嵌入 PPTX 並不相同。如果需要將字型隨簡報檔案一起攜帶，必須使用明確的[嵌入功能](/slides/zh-hant/androidjava/embedded-font/)。

### 當自訂字型缺少特定字形時，我能控制備援行為嗎？

可以。請設定[字型替代](/slides/zh-hant/androidjava/font-substitution/)、[替換規則](/slides/zh-hant/androidjava/font-replacement/)以及[備援字型集合](/slides/zh-hant/androidjava/fallback-font/)，以明確定義在請求的字形缺失時使用哪個字型。

### 我能在 Linux/Docker container 中使用字型而不需在系統層面安裝嗎？

可以。只要指向您自己的字型資料夾或從位元組陣列載入字型，即可移除容器映像檔對系統字型目錄的任何依賴。

### 關於授權——我可以在不受限制的情況下嵌入任何自訂字型嗎？

您需自行負責字型授權的合規性。授權條款各有不同，部分授權禁止嵌入或商業使用。發佈輸出前務必檢視字型的最終使用者授權協議 (EULA)。