---
title: 在 .NET 中將 PPT 和 PPTX 轉換為 PDF [包含進階功能]
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
- 附件
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，並提供快速的 C# 程式碼範例與進階轉換選項。"
---
## **Overview**

在 C# 中將 PowerPoint 簡報 (PPT、PPTX、ODP 等) 轉換為 PDF 格式具有多項優勢，包括跨設備相容性以及保留簡報的版面配置和格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、對 PDF 檔案設定密碼保護、偵測字型替換、選取特定投影片進行轉換，以及套用合規標準於輸出文件。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，請將檔名作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別，然後使用 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法將簡報儲存為 PDF。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別公開了通常用於將簡報轉換為 PDF 的 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法。

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET 會將其 API 資訊和版本號插入輸出文件。例如，在將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」形式的值。**注意** 您無法指示 Aspose.Slides 更改或移除這些資訊於輸出文件中。{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整個簡報轉為 PDF
* 從簡報中挑選特定投影片轉為 PDF

Aspose.Slides 匯出簡報至 PDF，確保產生的 PDF 與原始簡報高度相符。轉換過程中會正確呈現各種元素與屬性，包括：

* 圖片
* 文字方塊和圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 項目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換流程使用預設選項。在此情況下，Aspose.Slides 會嘗試使用最佳設定及最高品質層級將提供的簡報轉換為 PDF。

以下範例載入一個簡報，並使用預設匯出設定將所有可見投影片儲存為 PDF。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose 提供免費的線上 [**PowerPoint to PDF 轉換器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，展示簡報轉 PDF 的過程。您可以使用此轉換器執行測試，以即時體驗此處所述的步驟。{{% /alert %}}

## **使用選項將 PowerPoint 轉換為 PDF**

Aspose.Slides 提供自訂選項——位於 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 類別下的屬性——讓您自訂產生的 PDF、以密碼鎖定 PDF，或指定轉換流程的執行方式。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

使用自訂轉換選項，您可以為點陣圖設定偏好的品質、指定中繼檔的處理方式、設定文字的壓縮等級、配置影像的 DPI，等等。

以下範例將簡報匯出為 PDF 1.5，JPEG 品質設定為 90，影像解析度設定為 300 DPI，中繼檔保存為 PNG，並使用 Flate 文字壓縮。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **將嵌入的 OLE 檔案保留為 PDF 附件**

若簡報內嵌入 Excel 活頁簿，您可能希望 PDF 接收者能夠存取該活頁簿的資料，同時瀏覽投影片。將 [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) 設為 `true`，即可在產生的 PDF 中保留嵌入的 OLE 檔案作為附件。

預設值為 `false`：OLE 物件的預覽圖像或圖示會在 PDF 頁面上呈現，但其嵌入檔案不會作為附件加入。將此選項設為 `true` 會額外加入檔案資料。預覽仍僅為視覺呈現；附件則允許接收者單獨開啟或儲存嵌入的檔案。OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

以下範例載入已包含嵌入式 Excel 活頁簿的簡報，並將其匯出為附帶活頁簿的 PDF。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

檢查結果：

1. 在支援檔案附件的檢視器（如 Adobe Acrobat Reader）中開啟匯出的 PDF。
2. 開啟檢視器的 **Attachments** 面板，找到嵌入的活頁簿。
3. 儲存該附件並在 Excel 中開啟以檢視其資料，或在檢視器允許時直接開啟。PDF 頁面的預覽與附件是分離的。

{{% alert color="info" title="Note" %}}
PDF/A 標準對附件有限制：PDF/A-1 禁止嵌入檔案，PDF/A-2 僅允許 PDF/A 附件，PDF/A-3 允許其他檔案類型，包括 Excel 活頁簿。這些是標準的要求，並非 Aspose.Slides 的限制。此範例使用預設的 PDF 合規設定，未示範 PDF/A 匯出。{{% /alert %}}

### **將隱藏投影片也轉換為 PDF**

若簡報包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 類別的 [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) 屬性，將隱藏投影片納入產生的 PDF 頁面中。

以下範例將簡報匯出為 PDF，並包含所有隱藏投影片。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **將 PowerPoint 轉換為受密碼保護的 PDF**

以下範例將簡報匯出為需要密碼 `password` 才能開啟的 PDF。存取權限允許列印，包括高品質列印。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **偵測字型替換**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 類別下提供 [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) 屬性，使您能在簡報轉 PDF 的過程中偵測字型替換。

以下範例將簡報匯出為 PDF，並將字型替換警告輸出至主控台。僅在匯出時有無法使用的字型被替換時才會印出警告。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
欲了解更多關於字型替換的資訊，請參閱 [Font Substitution](/slides/zh-hant/net/font-substitution/) 文章。{{% /alert %}} 

## **將 PowerPoint 中選取的投影片轉換為 PDF**

以下範例將簡報的第 1 張與第 3 張投影片匯出為 PDF。此陣列中的投影片編號以 1 為起點，且輸入的簡報必須至少包含三張投影片。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **使用自訂投影片大小將 PowerPoint 轉換為 PDF**

以下範例將簡報的第一張投影片複製到新簡報，並設定投影片大小為 612 × 792 points（8.5 × 11 吋）。它會縮放投影片內容以適應尺寸，並將單一投影片匯出為 PDF。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **在備註投影片檢視中將 PowerPoint 轉換為 PDF**

以下範例將簡報匯出為 PDF，將每張投影片的講者備註置於投影片下方。請使用含有講者備註的簡報以觀察結果。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PDF 的無障礙與合規標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以依據以下任一合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下 C# 程式碼示範依不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 轉換流程：

```csharp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides 支援 PDF 轉換操作，讓您能將 PDF 檔案轉換為常見格式。您可以執行 [PDF 轉 HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF 轉影像](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)、[PDF 轉 PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) 等轉換。其他針對專屬格式的 PDF 轉換—[PDF 轉 SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)、[PDF 轉 XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)——亦受到支援。{{% /alert %}}

> **注意:** 匯出為 PDF/UA 時，Aspose.Slides 將諸如 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能被標記為雜項；替代文字僅提供給整體圖形。

## **FAQ**

**我可以一次批量將多個 PowerPoint 檔案轉換為 PDF 嗎？**

是的，Aspose.Slides 支援將多個 PPT 或 PPTX 檔案批次轉換為 PDF。您可以在程式中迭代檔案並套用轉換程序。

**是否可以為轉換後的 PDF 設定密碼保護？**

是的。使用 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 類別在轉換過程中設定密碼並定義存取權限。

**如何在 PDF 中包含隱藏投影片？**

將 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 類別的 [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) 屬性設為 `true`，即可在產生的 PDF 中包含隱藏投影片。

**Aspose.Slides 能在 PDF 中維持高影像品質嗎？**

是的，您可以透過設定 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 類別的 [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) 與 [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) 等屬性，以確保 PDF 中的影像具備高品質。

**Aspose.Slides 是否支援 PDF/A 合規標準？**

是的，Aspose.Slides 允許您匯出符合各種標準的 PDF，包括 PDF/A1a、PDF/A1b 與 PDF/UA，確保文件符合無障礙與存檔需求。

## **Additional Resources**

- [Aspose.Slides for .NET 文件](/slides/zh-hant/net/)
- [Aspose.Slides for .NET API 參考](https://reference.aspose.com/slides/net/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/conversion)