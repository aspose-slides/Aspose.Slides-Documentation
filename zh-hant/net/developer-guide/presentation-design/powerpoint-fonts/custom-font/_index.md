---
title: 在 .NET 中自訂 PowerPoint 字體
linktitle: 自訂字體
type: docs
weight: 20
url: /zh-hant/net/custom-font/
keywords:
- 字體
- 自訂字體
- 外部字體
- 載入字體
- 管理字體
- 字體資料夾
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: 使用 Aspose.Slides for .NET 在 PowerPoint 投影片中自訂字體，確保您的簡報在任何裝置上都保持清晰且一致。
---
## **概述**

Aspose.Slides 允許您在簡報中使用自訂字體，而無需在作業系統上安裝它們。您可以從自訂資料夾載入字體、透過文件層級的字體來源為特定簡報提供字體，或直接從二進位資料載入外部字體。

載入的字體會在簡報渲染或匯出時使用，例如匯出為 PDF、影像及其他受支援的格式。這有助於在不同環境中保持簡報輸出的相容性。本文亦說明如何檢查 Aspose.Slides 使用的字體資料夾，以及在使用外部字體後如何清除字體快取。

為渲染註冊自訂字體與將字體嵌入 PPTX 檔案是分開的步驟。如果必須將字體儲存在簡報本身內，請明確使用字體嵌入功能。

{{% alert color="primary" %}} 

Aspose Slides 允許您使用[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/loadexternalfonts/) 方法載入以下字體：

* TrueType（.ttf）與 TrueType Collection（.ttc）字體。請參考[TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType（.otf）字體。請參考[OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **載入自訂字體**

Aspose.Slides 允許您在簡報中使用未安裝於系統的字體。這會影響匯出結果——如 PDF、影像及其他受支援的格式——使產生的文件在不同環境下保持一致。字體會從自訂目錄載入。

1. 指定一個或多個包含字體檔案的資料夾。
2. 呼叫靜態[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/loadexternalfonts/) 方法，從這些資料夾載入字體。
3. 載入並渲染/匯出簡報。
4. 呼叫[FontsLoader.ClearCache](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/clearcache/) 以清除字體快取。

以下程式碼範例示範了字體載入流程：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 定義包含自訂字體檔案的資料夾。
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// 從指定的資料夾載入自訂字體。
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// 使用已載入的字體渲染/匯出簡報（例如 PDF、影像或其他格式）。
presentation.Save("output.pdf", SaveFormat.Pdf);

// 工作完成後清除字體快取。
FontsLoader.ClearCache();
```

{{% alert color="info" title="注意" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/loadexternalfonts/) 會將額外的資料夾加入字體搜尋路徑，但不會改變字體初始化的順序。字體的初始化順序如下：

1. 預設作業系統字體路徑。  
2. 透過[FontsLoader](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/) 載入的路徑。

{{%/alert %}}

## **取得自訂字體資料夾**
Aspose.Slides 提供[GetFontFolders](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/getfontfolders/) 方法，以讓您查詢字體資料夾。此方法會回傳透過 `LoadExternalFonts` 方法加入的資料夾以及系統字體資料夾。

以下 C# 程式碼示範如何使用[GetFontFolders](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/getfontfolders/)：

```c#
using Aspose.Slides;

// 此行輸出檢查字體檔案的資料夾。
// 這些資料夾是透過 LoadExternalFonts 方法加入的以及系統字體資料夾。
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **指定簡報使用的自訂字體**
Aspose.Slides 提供[DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/documentlevelfontsources/) 屬性，讓您指定在簡報中使用的外部字體。

以下 C# 程式碼示範如何使用[DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/documentlevelfontsources/) 屬性：

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // 對簡報進行操作
    // CustomFont1、CustomFont2，以及來自 assets\fonts 與 global\fonts 資料夾及其子資料夾的字體均可供簡報使用
}
```

## **外部管理字體**

Aspose.Slides 提供[LoadExternalFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) 方法，以讓您從二進位資料載入外部字體。

以下 C# 程式碼示範如何使用位元組陣列載入字體：

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // 外部字體在簡報生命週期內已載入
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **常見問題**

**自訂字體是否會影響所有格式的匯出（PDF、PNG、SVG、HTML）？**

是。已連結的字體會在所有匯出格式的渲染器中使用。

**自訂字體會自動嵌入產生的 PPTX 檔案嗎？**

不會。為渲染註冊字體與將字體嵌入 PPTX 是不同的操作。若需要字體隨簡報檔案一起攜帶，必須使用明確的[嵌入功能](/slides/zh-hant/net/embedded-font/)。

**當自訂字體缺少特定字形時，我能控制備援行為嗎？**

可以。請設定[字體取代](/slides/zh-hant/net/font-substitution/)、[取代規則](/slides/zh-hant/net/font-replacement/)與[備援字體集合](/slides/zh-hant/net/fallback-font/)，以明確定義在找不到所需字形時使用哪個字體。

**我可以在 Linux/Docker 容器中使用字體而不需系統安裝嗎？**

可以。指向您自己的字體資料夾或從位元組陣列載入字體，即可避免對容器映像中的系統字體目錄有任何依賴。

> **Linux/Docker 注意事項**：呼叫`FontsLoader.LoadExternalFonts` 時，請確保`directories` 陣列中的每個條目皆為非空且指向存在的目錄。若用於組成字體路徑的環境變數未定義或為空，Aspose.Slides 可能會把空值當作完整路徑解析，導致`System.ArgumentException`。

**授權方面如何？我可以無限制地嵌入任何自訂字體嗎？**

您必須自行負責字體授權合規。授權條款各異，部分授權禁止嵌入或商業使用。發佈輸出前，請務必閱讀字體的最終使用者授權協議（EULA）。