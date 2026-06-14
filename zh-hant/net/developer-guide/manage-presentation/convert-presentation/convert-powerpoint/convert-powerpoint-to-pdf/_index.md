---
title: 在 .NET 中將 PPT 和 PPTX 轉換為 PDF（包含進階功能）
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
- 轉換 PPT 為 PDF
- PPTX 轉 PDF
- 轉換 PPTX 為 PDF
- 將 PowerPoint 保存為 PDF
- 將 PPT 保存為 PDF
- 將 PPTX 保存為 PDF
- 匯出 PPT 為 PDF
- 匯出 PPTX 為 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速的 C# 程式碼範例和進階轉換選項。"
---
## **概述**

在 C# 中將 PowerPoint 簡報（PPT、PPTX、ODP 等）轉換為 PDF 格式具有多項優勢，包括在不同裝置間的相容性以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制圖像品質、包含隱藏投影片、為 PDF 檔案設定密碼保護、偵測字型替換、選取特定投影片進行轉換，以及套用合規標準於輸出文件。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，將檔案名稱作為參數傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/)類別，然後使用[Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/)方法將簡報儲存為 PDF。[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/)類別公開的[Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/)方法通常用於將簡報轉換為 PDF。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for .NET 會將其 API 資訊與版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」形式的值。**注意** 您無法指示 Aspose.Slides 更改或移除這些資訊。

{{% /alert %}}

Aspose.Slides 允許您：

* 將整個簡報轉換為 PDF
* 將簡報中的特定投影片轉換為 PDF

Aspose.Slides 匯出簡報為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換過程中會正確呈現以下元素與屬性：

* 圖片
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 项目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換程序使用預設選項。在此情況下，Aspose.Slides 會以最佳設定及最高品質等級將提供的簡報轉換為 PDF。

以下 C# 程式碼示範如何將簡報（PPT、PPTX、ODP 等）轉換為 PDF：

```c#
// 建立表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
using var presentation = new Presentation("PowerPoint.ppt");

// 將簡報儲存為 PDF。
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose 提供免費的線上[**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pdf)，示範簡報轉 PDF 的流程。您可使用此轉換器進行即時測試，以驗證本文所述步驟。

{{% /alert %}}

## **將 PowerPoint 轉換為 PDF（含選項）**

Aspose.Slides 透過 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 類別提供自訂選項，您可以自訂輸出 PDF、設定密碼保護，或指定轉換流程的執行方式。

### **將 PowerPoint 轉換為 PDF（自訂選項）**

使用自訂轉換選項，您可以設定點陣圖的品質、指定如何處理中繼檔、設定文字壓縮等級、配置圖像 DPI 等。

以下程式碼範例示範如何使用多項自訂選項將 PowerPoint 簡報轉換為 PDF：

```c#
// 建立 PdfOptions 類別的實例。
var pdfOptions = new PdfOptions
{
    // 設定 JPG 圖片的品質。
    JpegQuality = 90,

    // 設定圖片的 DPI。
    SufficientResolution = 300,

    // 設定中繼檔的處理方式。
    SaveMetafilesAsPng = true,

    // 設定文字內容的壓縮等級。
    TextCompression = PdfTextCompression.Flate,

    // 定義 PDF 合規模式。
    Compliance = PdfCompliance.Pdf15
};

// 建立表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
using var presentation = new Presentation("PowerPoint.pptx");

// 將簡報儲存為 PDF 文件。
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **將 PowerPoint 轉換為 PDF（含隱藏投影片）**

若簡報包含隱藏投影片，可使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 類別的 [ShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/showhiddenslides/) 屬性，將隱藏投影片作為頁面包含於產生的 PDF 中。

以下 C# 程式碼示範如何在 PDF 中包含隱藏投影片：

```c#
// 建立表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
using var presentation = new Presentation("PowerPoint.pptx");

// 建立 PdfOptions 類別的實例。
var pdfOptions = new PdfOptions();

// 加入隱藏投影片。
pdfOptions.ShowHiddenSlides = true;

// 將簡報儲存為 PDF。
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **將 PowerPoint 轉換為受密碼保護的 PDF**

以下 C# 程式碼示範如何使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 類別的保護參數，將 PowerPoint 簡報轉換為受密碼保護的 PDF：

```c#
// 建立表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
using var presentation = new Presentation("PowerPoint.pptx");

// 建立 PdfOptions 類別的實例。
var pdfOptions = new PdfOptions();

// 設定 PDF 密碼與存取權限。
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// 將簡報儲存為 PDF。
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **偵測字型替換**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 類別下提供 [WarningCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveoptions/warningcallback/) 屬性，讓您在簡報轉 PDF 的過程中偵測字型替換。

以下 C# 程式碼示範如何偵測字型替換：

```c#
public static void Main()
{
    // 建立表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。 
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

{{%  alert color="primary"  %}} 

欲取得渲染過程中字型替換的回呼資訊，請參閱[取得字型替換警告回呼](/slides/zh-hant/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

欲進一步了解字型替換，請參閱[字型替換](/slides/zh-hant/net/font-substitution/) 文章。

{{% /alert %}} 

## **將 PowerPoint 中選取的投影片轉換為 PDF**

以下 C# 程式碼示範如何僅將 PowerPoint 簡報的特定投影片轉換為 PDF：

```c#
// 建立表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
using var presentation = new Presentation("PowerPoint.pptx");

// 設定投影片編號陣列。
int[] slides = { 1, 3 };

// 將簡報儲存為 PDF。
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **將 PowerPoint 轉換為 PDF（自訂投影片尺寸）**

以下 C# 程式碼示範如何以指定的投影片尺寸將 PowerPoint 簡報轉換為 PDF：

```c#
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

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **將 PowerPoint 轉換為 PDF（含備註投影片檢視）**

以下 C# 程式碼示範如何將包含備註的 PowerPoint 簡報轉換為 PDF：

```c#
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

## **PDF 的可及性與合規標準**

Aspose.Slides 支援符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序，您可使用以下合規標準匯出 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下 C# 程式碼示範依不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

```c#
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

{{% alert title="注意" color="warning" %}} 

Aspose.Slides 支援 PDF 轉換操作，允許您將 PDF 檔案轉換為多種常見格式。您可以執行[PDF 轉 HTML](https://products.aspose.com/slides/zh-hant/net/conversion/pdf-to-html/)、[PDF 轉圖像](https://products.aspose.com/slides/zh-hant/net/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/zh-hant/net/conversion/pdf-to-jpg/)、以及[PDF 轉 PNG](https://products.aspose.com/slides/zh-hant/net/conversion/pdf-to-png/) 轉換。其他專屬格式的 PDF 轉換亦受支援，包括[PDF 轉 SVG](https://products.aspose.com/slides/zh-hant/net/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/zh-hant/net/conversion/pdf-to-tiff/)、以及[PDF 轉 XML](https://products.aspose.com/slides/zh-hant/net/conversion/pdf-to-xml/)。

{{% /alert %}}

> **注意：** 匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能被標記為雜訊；僅為整體圖形提供替代文字。

## **常見問題**

**我可以一次批次將多個 PowerPoint 檔案轉換為 PDF 嗎？**

是的，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以以程式方式遍歷檔案並套用轉換程序。

**是否可以為轉換後的 PDF 設定密碼保護？**

絕對可以。使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 類別在轉換過程中設定密碼及存取權限。

**如何在 PDF 中包含隱藏投影片？**

將 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 類別的 `ShowHiddenSlides` 屬性設為 `true` 即可在產生的 PDF 中包含隱藏投影片。

**Aspose.Slides 能否在 PDF 中保留高圖像品質？**

可以，您可透過設定 `JpegQuality`、`SufficientResolution` 等屬性於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 以確保 PDF 中的圖像保持高品質。

**Aspose.Slides 是否支援 PDF/A 合規標準？**

是的，Aspose.Slides 可匯出符合 PDF/A1a、PDF/A1b 與 PDF/UA 等多種標準的 PDF，確保文件符合可及性與存檔需求。

## **其他資源**

- [Aspose.Slides for .NET 文件](/slides/zh-hant/net/)
- [Aspose.Slides for .NET API 參考](https://reference.aspose.com/slides/zh-hant/net/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/zh-hant/conversion)