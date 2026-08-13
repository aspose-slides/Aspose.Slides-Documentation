---
title: 在 .NET 中將 PPT 與 PPTX 轉換為 PDF [包含進階功能]
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/net/convert-powerpoint-to-pdf/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- PowerPoint 轉 PDF
- 簡報 轉 PDF
- PPT 轉 PDF
- 將 PPT 轉換為 PDF
- PPTX 轉 PDF
- 將 PPTX 轉換為 PDF
- 將 PowerPoint 儲存為 PDF
- 將 PPT 儲存為 PDF
- 將 PPTX 儲存為 PDF
- 匯出 PPT 為 PDF
- 匯出 PPTX 為 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速的 C# 程式範例與進階轉換選項。"
---
## **概述**

在 C# 中將 PowerPoint 簡報 (PPT、PPTX、ODP 等) 轉換為 PDF 格式具備多項優勢，包括在不同裝置間的相容性以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、對 PDF 檔案設定密碼保護、偵測字型替代、選取特定投影片進行轉換，以及套用合規標準於輸出文件。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別，然後使用 [Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法將簡報儲存為 PDF。[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別提供 [Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法，通常用於將簡報轉換為 PDF。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET 會將其 API 資訊與版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」的格式。**注意** 您無法指示 Aspose.Slides 更改或移除這些資訊於輸出文件中。

{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整個簡報轉換為 PDF
* 簡報的特定投影片轉換為 PDF

Aspose.Slides 匯出簡報為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換過程中會正確呈現以下元素與屬性：

* 影像
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 項目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換流程使用預設選項。在此情況下，Aspose.Slides 會嘗試使用最佳設定與最高品質層級將提供的簡報轉換為 PDF。

以下 C# 程式碼示範如何將簡報 (PPT、PPTX、ODP 等) 轉換為 PDF：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
using var presentation = new Presentation("PowerPoint.ppt");

// 將簡報儲存為 PDF。
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Aspose 提供免費的線上 [**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pdf)，示範簡報轉 PDF 的轉換流程。您可以使用此轉換器執行測試，以即時實作此處描述的程序。

{{% /alert %}}

## **將 PowerPoint 轉換為 PDF 並使用選項**

Aspose.Slides 提供自訂選項—位於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 類別下的屬性—讓您自訂產生的 PDF、以密碼鎖定 PDF，或指定轉換流程的執行方式。

### **將 PowerPoint 轉換為 PDF 並使用自訂選項**

使用自訂轉換選項，您可以定義光柵影像的品質設定、指定中繼檔的處理方式、設定文字的壓縮等級、配置影像的 DPI，等等。

以下程式碼範例示範如何使用多項自訂選項將 PowerPoint 簡報轉換為 PDF：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化 PdfOptions 類別。
var pdfOptions = new PdfOptions
{
    // 設定 JPG 影像的品質。
    JpegQuality = 90,

    // 設定影像的 DPI。
    SufficientResolution = 300,

    // 設定中繼檔的行為。
    SaveMetafilesAsPng = true,

    // 設定文字內容的壓縮等級。
    TextCompression = PdfTextCompression.Flate,

    // 定義 PDF 合規模式。
    Compliance = PdfCompliance.Pdf15
};

// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
using var presentation = new Presentation("PowerPoint.pptx");

// 將簡報儲存為 PDF 文件。
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **將 PowerPoint 轉換為 PDF 包含隱藏投影片**

如果簡報包含隱藏投影片，您可以使用來自 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 類別的 [ShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/showhiddenslides/) 屬性，將隱藏投影片納入產生的 PDF 頁面。

以下 C# 程式碼說明如何將隱藏投影片一併轉換為 PDF：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
using var presentation = new Presentation("PowerPoint.pptx");

// 實例化 PdfOptions 類別。
var pdfOptions = new PdfOptions();

// 加入隱藏投影片。
pdfOptions.ShowHiddenSlides = true;

// 将简报保存为 PDF。
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **將 PowerPoint 轉換為受密碼保護的 PDF**

以下 C# 程式碼示範如何使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 類別的保護參數，將 PowerPoint 簡報轉換為受密碼保護的 PDF：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
using var presentation = new Presentation("PowerPoint.pptx");

// 實例化 PdfOptions 類別。
var pdfOptions = new PdfOptions();

// 設定 PDF 密碼和存取權限。
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// 將簡報儲存為 PDF。
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **偵測字型替代**

Aspose.Slides 提供位於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 類別下的 [WarningCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveoptions/warningcallback/) 屬性，使您能在簡報轉 PDF 的過程中偵測字型替代情況。

以下 C# 程式碼示範如何偵測字型替代：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。 
    using var presentation = new Presentation("sample.pptx");

    // 設定 PDF 選項中的警告回呼。
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // 將簡報儲存為 PDF。
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// 警告回呼的實作。
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

欲取得有關在渲染過程中接收字型替代回呼的更多資訊，請參閱 [取得字型替代的警告回呼](/slides/zh-hant/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

欲了解更多字型替代資訊，請參閱 [字型替代](/slides/zh-hant/net/font-substitution/) 文章。

{{% /alert %}} 

## **將 PowerPoint 中選取的投影片轉換為 PDF**

以下 C# 程式碼示範如何僅將 PowerPoint 簡報中的特定投影片轉換為 PDF：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
using var presentation = new Presentation("PowerPoint.pptx");

// 設定投影片編號陣列。
int[] slides = { 1, 3 };

// 將簡報儲存為 PDF。
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **將 PowerPoint 轉換為 PDF 並使用自訂投影片大小**

以下 C# 程式碼示範如何使用指定的投影片大小將 PowerPoint 簡報轉換為 PDF：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);

// Save the resized presentation as a PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **將 PowerPoint 轉換為包含筆記的 PDF (Notes Slide View)**

以下 C# 程式碼示範如何將 PowerPoint 簡報轉換為包含筆記的 PDF：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 載入 PowerPoint 簡報。
using var presentation = new Presentation("NotesFile.pptx");

// 設定 PDF 選項以使用備註版面配置。
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// 將簡報儲存為包含備註的 PDF。
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PDF 的無障礙與合規標準**

Aspose.Slides 允許您使用符合[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以使用以下任一合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下 C# 程式碼示範根據不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides 支援 PDF 轉換操作，允許您將 PDF 檔案轉換為常見的檔案格式。您可以執行 [PDF to HTML](https://products.aspose.com/slides/zh-hant/net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/zh-hant/net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/zh-hant/net/conversion/pdf-to-jpg/)、以及 [PDF to PNG](https://products.aspose.com/slides/zh-hant/net/conversion/pdf-to-png/) 轉換。其他針對特定格式的 PDF 轉換操作—[PDF to SVG](https://products.aspose.com/slides/zh-hant/net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/zh-hant/net/conversion/pdf-to-tiff/)、和 [PDF to XML](https://products.aspose.com/slides/zh-hant/net/conversion/pdf-to-xml/)—亦受支援。

{{% /alert %}}

> **注意：** 在匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表和公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能被標記為雜訊；僅對整個圖形提供替代文字。

## **常見問題**

### 我可以批次將多個 PowerPoint 檔案轉換為 PDF 嗎？

是的，Aspose.Slides 支援將多個 PPT 或 PPTX 檔案批次轉換為 PDF。您可以在程式中遍歷檔案並套用轉換程序。

### 是否可以對轉換後的 PDF 設定密碼保護？

當然可以。使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 類別在轉換過程中設定密碼與存取權限。

### 如何在 PDF 中包含隱藏投影片？

在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 類別中將 `ShowHiddenSlides` 屬性設為 `true` 即可在產生的 PDF 中包含隱藏投影片。

### Aspose.Slides 能否在 PDF 中維持高影像品質？

可以，您可透過在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 中設定 `JpegQuality`、`SufficientResolution` 等屬性，以確保 PDF 中的影像具備高品質。

### Aspose.Slides 是否支援 PDF/A 合規標準？

是的，Aspose.Slides 允許您匯出符合各種標準的 PDF，包括 PDF/A1a、PDF/A1b 與 PDF/UA，確保文件符合無障礙與歸檔需求。

## **其他資源**

- [Aspose.Slides for .NET 文件](/slides/zh-hant/net/)
- [Aspose.Slides for .NET API 參考](https://reference.aspose.com/slides/zh-hant/net/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/zh-hant/conversion)