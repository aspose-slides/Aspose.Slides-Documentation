---
title: 在 .NET 中自訂 PowerPoint 字型
linktitle: 自訂字型
type: docs
weight: 20
url: /zh-hant/net/custom-font/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 投影片中自訂字型，以確保簡報在任何裝置上皆保持清晰且一致。"
---
## **概觀**

Aspose.Slides 允許您在簡報中使用自訂字型，而無需在作業系統上安裝它們。您可以從自訂資料夾載入字型，透過文件層級的字型來源為特定簡報提供字型，或直接從二進位資料載入外部字型。

已載入的字型會在簡報呈現或匯出時使用，例如匯出為 PDF、影像及其他支援的格式。這有助於在不同環境中保持簡報輸出的一致性。本文亦說明如何檢查 Aspose.Slides 使用的字型資料夾，以及在使用外部字型後如何清除字型快取。

為渲染註冊自訂字型與將字型嵌入 PPTX 檔案是分開的作業。如果必須將字型儲存在簡報本身內，請明確使用字型嵌入功能。

{{% alert color="primary" %}} 
Aspose Slides 允許您使用 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/loadexternalfonts/) 方法載入以下字型：

* TrueType（.ttf）與 TrueType Collection（.ttc）字型。請參閱 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType（.otf）字型。請參閱 [OpenType](https://en.wikipedia.org/wiki/OpenType)。
{{% /alert %}}

## **載入自訂字型**

Aspose.Slides 允許您在簡報中使用未安裝於系統的字型。這會影響匯出結果──例如 PDF、影像及其他支援的格式──使產出的文件在不同環境中保持一致。字型會從自訂目錄載入。

1. 指定一個或多個包含字型檔案的資料夾。
2. 呼叫靜態 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/loadexternalfonts/) 方法，從這些資料夾載入字型。
3. 載入並呈現/匯出簡報。
4. 呼叫 [FontsLoader.ClearCache](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/clearcache/) 以清除字型快取。

以下程式碼範例示範字型載入流程：

```cs
// 定義包含自訂字型檔案的資料夾。
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// 從指定的資料夾載入自訂字型。
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// 使用已載入的字型來呈現/匯出簡報（例如 PDF、影像或其他格式）。
presentation.Save("output.pdf", SaveFormat.Pdf);

// 工作完成後清除字型快取。
FontsLoader.ClearCache();
```

{{% alert color="info" title="注意" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/loadexternalfonts/) 會將額外資料夾加入字型搜尋路徑，但不會改變字型的初始化順序。  
字型會依以下順序初始化：

1. 作業系統的預設字型路徑。
1. 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/) 載入的路徑。
{{%/alert %}}

## **取得自訂字型資料夾**
Aspose.Slides 提供 [GetFontFolders](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/getfontfolders/) 方法，以協助您找出字型資料夾。此方法會回傳透過 `LoadExternalFonts` 方法新增的資料夾以及系統字型資料夾。

以下 C# 程式碼示範如何使用 [GetFontFolders](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/getfontfolders/)：

```c#
 // 此行輸出檢查字型檔案的資料夾。
 // 這些資料夾是透過 LoadExternalFonts 方法新增的以及系統字型資料夾。
 string[] fontFolders = FontsLoader.GetFontFolders();
```

## **為簡報指定使用的自訂字型**
Aspose.Slides 提供 [DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/documentlevelfontsources/) 屬性，讓您指定將在簡報中使用的外部字型。

以下 C# 程式碼示範如何使用 [DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/documentlevelfontsources/) 屬性：

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // 處理簡報
    // CustomFont1、CustomFont2 以及來自 assets\fonts 與 global\fonts 資料夾及其子資料夾的字型皆可在簡報中使用
}
```

## **外部管理字型**

Aspose.Slides 提供 [LoadExternalFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) 方法，讓您從二進位資料載入外部字型。

以下 C# 程式碼示範以位元組陣列載入字型的流程：

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // 簡報生命週期內載入的外部字型
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **常見問題**

**自訂字型會影響所有格式（PDF、PNG、SVG、HTML）的匯出嗎？**

會。已連結的字型會在所有匯出格式的渲染器中使用。

**自訂字型會自動嵌入產生的 PPTX 嗎？**

不會。為渲染註冊字型與將字型嵌入 PPTX 並非同一件事。如果需要將字型內嵌於簡報檔案，必須使用明確的[嵌入功能](/slides/zh-hant/net/embedded-font/)。

**當自訂字型缺少某些字形時，我可以控制回退行為嗎？**

可以。請設定[字型置換](/slides/zh-hant/net/font-substitution/)、[取代規則](/slides/zh-hant/net/font-replacement/)及[回退集合](/slides/zh-hant/net/fallback-font/)，以明確指定在缺少請求字形時使用哪個字型。

**我能在 Linux/Docker 容器中使用字型而不必在系統層面安裝嗎？**

可以。指向您自己的字型資料夾或從位元組陣列載入字型，即可移除對容器映像系統字型目錄的任何依賴。

**關於授權——我可以無限制地嵌入任何自訂字型嗎？**

您必須自行負責字型授權的合規性。授權條款各有不同，有些授權禁止嵌入或商業使用。發佈輸出前，務必檢閱字型的終端使用者授權合約（EULA）。