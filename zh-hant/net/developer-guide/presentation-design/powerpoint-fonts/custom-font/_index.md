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
description: "使用 Aspose.Slides for .NET 在 PowerPoint 投影片中自訂字型，使您的簡報在任何裝置上都保持清晰且一致。"
---
## **概述**

Aspose.Slides 允許您在簡報中使用自訂字型，而無需在作業系統上安裝它們。您可以從自訂資料夾載入字型，透過文件層級的字型來源為特定簡報提供字型，或直接從二進位資料載入外部字型。

載入的字型會在簡報呈現或匯出時使用，例如匯出為 PDF、影像或其他受支援的格式。這有助於在不同環境中保持簡報輸出的相容性。本文亦說明如何檢視 Aspose.Slides 使用的字型資料夾，以及在使用外部字型後如何清除字型快取。

為呈現註冊自訂字型與將字型嵌入 PPTX 檔案是分開的程序。如果必須將字型儲存在簡報本身，請明確使用字型嵌入功能。

簡報主題可以為個別書寫系統參照不同的字型族。這些對應僅儲存字型名稱，並不會安裝或載入字型檔案。請參閱 [特定腳本主題字型](/slides/zh-hant/net/script-specific-font-mappings/) 以管理這些對應，並使用以下載入選項使參照的字型可用於一致的呈現。

{{% alert color="info" title="Note" %}}
Aspose Slides 允許您使用 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/loadexternalfonts/) 方法載入這些字型：

* TrueType (.ttf) 與 TrueType Collection (.ttc) 字型。請參閱 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType (.otf) 字型。請參閱 [OpenType](https://en.wikipedia.org/wiki/OpenType)。
{{% /alert %}}

## **載入自訂字型**

Aspose.Slides 允許您在簡報中使用自訂字型，而無需在系統上安裝它們。這會影響匯出結果——例如 PDF、影像與其他受支援的格式——使產生的文件在不同環境中看起來保持一致。字型會從自訂目錄載入。

1. 指定一個或多個包含字型檔案的資料夾。
2. 呼叫靜態的 [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/loadexternalfonts/) 方法，從這些資料夾載入字型。
3. 載入並呈現/匯出簡報。
4. 呼叫 [FontsLoader.ClearCache](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/clearcache/) 以清除字型快取。

以下程式碼範例示範了字型載入的流程：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 定義包含自訂字型檔案的資料夾。
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// 從指定的資料夾載入自訂字型。
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// 使用已載入的字型呈現/匯出簡報（例如 PDF、影像或其他格式）。
presentation.Save("output.pdf", SaveFormat.Pdf);

// 工作完成後清除字型快取。
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/loadexternalfonts/) 會將額外的資料夾加入字型搜尋路徑，但不會變更字型初始化的順序。字型的初始化順序如下：

1. 作業系統的預設字型路徑。
1. 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/) 載入的路徑。
{{%/alert %}}

## **取得自訂字型資料夾**

Aspose.Slides 提供 [GetFontFolders](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/getfontfolders/) 方法，讓您取得已加入的字型資料夾。此方法會回傳透過 `LoadExternalFonts` 方法加入的資料夾以及系統字型資料夾。

以下 C# 程式碼示範如何使用 [GetFontFolders](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/getfontfolders/)：

```c#
using Aspose.Slides;

// 此行輸出已檢查字型檔案的資料夾。
// 這些資料夾是透過 LoadExternalFonts 方法加入的以及系統字型資料夾。
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **指定與簡報一起使用的自訂字型**

Aspose.Slides 提供 [DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/documentlevelfontsources/) 屬性，讓您指定簡報將使用的外部字型。

以下 C# 程式碼示範如何使用 [DocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/documentlevelfontsources/) 屬性：

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // 在簡報上工作
    // CustomFont1、CustomFont2 以及來自 assets\fonts 與 global\fonts 資料夾及其子資料夾的字型均可在簡報中使用
}
```

## **外部管理字型**

Aspose.Slides 提供 [LoadExternalFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) 方法，允許您從二進位資料載入外部字型。

以下 C# 程式碼示範以位元組陣列載入字型的過程：

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // 簡報生命週期期間已載入的外部字型
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **常見問題**

**自訂字型會影響所有格式（PDF、PNG、SVG、HTML）的匯出嗎？**

會。已連結的字型會在所有匯出格式的渲染程序中使用。

**自訂字型會自動嵌入產生的 PPTX 中嗎？**

不會。為渲染註冊字型與將字型嵌入 PPTX 是不同的動作。如需將字型內嵌於簡報檔案，必須使用明確的[嵌入功能](/slides/zh-hant/net/embedded-font/)。

**如果自訂字型缺少某些字形，能否控制備援行為？**

可以。請設定[字型替代](/slides/zh-hant/net/font-substitution/)、[取代規則](/slides/zh-hant/net/font-replacement/)和[備援集合](/slides/zh-hant/net/fallback-font/)，以明確定義在請求的字形缺失時使用哪個字型。

**能否在 Linux/Docker 容器中使用字型而不需要系統範圍安裝？**

能。只要指向您自己的字型資料夾或從位元組陣列載入字型，即可避免對容器映像中的系統字型目錄產生任何依賴。

> **Linux/Docker 注意事項**：呼叫 `FontsLoader.LoadExternalFonts` 時，請確保 `directories` 陣列中的每個條目皆包含指向現有目錄的非空路徑。若用於組合字型路徑的環境變數未定義或為空，Aspose.Slides 可能會嘗試將空值解析為完整路徑，導致 `System.ArgumentException`。

**授權問題—是否可以在沒有限制的情況下嵌入任何自訂字型？**

您必須自行負責字型授權的合規性。授權條款各異，有些授權禁止嵌入或商業使用。分發輸出前，請務必檢查字型的最終使用者授權協議 (EULA)。