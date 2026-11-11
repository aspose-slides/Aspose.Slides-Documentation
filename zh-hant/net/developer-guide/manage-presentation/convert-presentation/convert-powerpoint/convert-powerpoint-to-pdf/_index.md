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
- 簡報轉 PDF
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
description: 在 .NET 中使用 Aspose.Slides 將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速的 C# 程式碼範例與進階轉換選項。
---
## **概觀**

將 PowerPoint 簡報（PPT、PPTX、ODP 等）轉換為 C# 中的 PDF 格式提供了多項優點，包括跨裝置相容性以及保留簡報的版面配置和格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制圖像品質、包含隱藏投影片、為 PDF 檔案設定密碼保護、偵測字體替換、選擇特定投影片進行轉換，以及將合規標準套用於輸出文件。

## **PowerPoint 轉 PDF 的轉換**

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，請將檔案名稱作為參數傳遞給[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)類別，然後使用[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)方法將簡報另存為 PDF。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)類別公開了通常用於將簡報轉換為 PDF 的[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)方法。

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET 會將其 API 資訊和版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」形式的值。**注意**，您無法指示 Aspose.Slides 更改或移除這些資訊。
{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整個簡報為 PDF
* 從簡報中選取特定投影片為 PDF

Aspose.Slides 將簡報匯出為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換過程中會準確呈現各種元素和屬性，包括：

* 圖像
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 項目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換程序使用預設選項。在此情況下，Aspose.Slides 會嘗試以最佳設定及最高品質層級將提供的簡報轉換為 PDF。

以下範例載入簡報，並使用預設匯出設定將所有可見投影片儲存為 PDF。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose 提供一個免費的線上[**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，示範簡報轉 PDF 的轉換過程。您可以使用此轉換器進行測試，以即時執行此處描述的步驟。
{{% /alert %}}

## **將 PowerPoint 轉換為 PDF 時的選項**

Aspose.Slides 提供自訂選項——位於[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)類別下的屬性——讓您自訂產生的 PDF、以密碼鎖定 PDF，或指定轉換程序的執行方式。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

使用自訂的轉換選項，您可以定義光柵影像的首選品質設定、指定圖形檔的處理方式、設定文字的壓縮等級、配置影像的 DPI，等等。

以下範例將簡報匯出為 PDF 1.5，JPEG 品質設定為 90，影像解析度設定為 300 DPI，將圖形檔儲存為 PNG，並使用 Flate 文字壓縮。

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

> **注意**：透過將 `PdfOptions.SufficientResolution` 設為較高的值（例如 `300`），您可以在轉換為 PDF 時提升文字陰影與反射效果的呈現品質。這會產生更接近 Microsoft PowerPoint 外觀的 PDF 輸出。

### **自動選擇圖像壓縮**

當簡報包含大量照片或螢幕截圖時，縮小匯出 PDF 的大小可以更方便寄送或下載。將[PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/)設為 `true`，即可在 PDF 匯出期間自動為每張影像選擇最適合的壓縮演算法。

以下範例載入現有簡報，啟用自動圖像壓縮選擇，並將其儲存為 PDF 文件。所有其他 PDF 匯出設定保持預設值。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

此選項會為每張影像選擇壓縮演算法。降低[JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/)會降低 JPEG 影像品質，而降低[SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/)則允許影像降採樣至較低解析度，可能減少細節。啟用自動壓縮選擇本身不會降低上述任一設定。

選擇圖像壓縮演算法會增加處理時間與記憶體需求。大小縮減取決於簡報的影像與匯出設定；無法保證每個簡報都有固定的縮減比例。

### **將嵌入的 OLE 檔案保留為 PDF 附件**

如果簡報中嵌入了 Excel 活頁簿，您可能希望 PDF 接收者能存取該活頁簿的資料，同時檢視投影片。將[PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/)設為 `true`，即可在產生的 PDF 中將嵌入的 OLE 檔案保留為附件。

預設值為 `false`：OLE 物件的預覽圖像或圖示會在 PDF 頁面上呈現，但其嵌入的檔案不會作為附件加入。將此選項設為 `true` 會額外包含檔案資料。預覽仍為視覺呈現；附件允許接收者另行開啟或儲存嵌入的檔案。OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

以下範例載入已包含嵌入 Excel 活頁簿的簡報，並將其匯出為帶有該活頁簿附件的 PDF。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

要檢查結果：

1. 在支援檔案附件的檢視器（例如 Adobe Acrobat Reader）中開啟匯出的 PDF。  
2. 開啟檢視器的 **Attachments** 面板並找到嵌入的活頁簿。  
3. 儲存該附件並以 Excel 開啟以檢視其資料，或在檢視器允許時直接開啟。PDF 頁面上的預覽與附件是分開的。

{{% alert color="info" title="Note" %}}
PDF/A 標準對附件有限制：PDF/A-1 禁止嵌入檔案，PDF/A-2 只允許 PDF/A 附件，PDF/A-3 允許其他檔案類型，包括 Excel 活頁簿。這些是標準的要求，而非 Aspose.Slides 的特殊限制。本範例使用預設的 PDF 合規設定，未示範 PDF/A 匯出。
{{% /alert %}}

### **將 PowerPoint 轉換為 PDF 並包含隱藏投影片**

如果簡報包含隱藏投影片，您可以使用[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)類別中的[ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/)屬性，將隱藏投影片包含為產生 PDF 的頁面。

以下範例將簡報匯出為 PDF，並包括所有隱藏投影片。

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

### **偵測字體替換**

Aspose.Slides 在[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)類別下提供[WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/)屬性，使您能在簡報轉 PDF 的過程中偵測字體替換。

以下範例將簡報匯出為 PDF 並將字體替換警告輸出到主控台。僅在匯出期間有不可用字體被替換時才會印出警告。

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
欲取得更多關於字體替換的資訊，請參閱[Font Substitution](/slides/zh-hant/net/font-substitution/)文章。
{{% /alert %}} 

### **處理沒有專屬粗體字型的字體**

即使字型沒有專屬的粗體樣式，簡報仍可對文字套用粗體格式。文字會透過合成粗體（synthetic bold）使常規字形人工加粗。若此文字在 PDF 中顯得過於沉重或與預期外觀不同，請嘗試將[PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/)設為 `true`。此選項會在 PDF 匯出時將受影響的文字以點陣圖方式呈現，可能改善某些字型的外觀。其預設值為 `false`。

範例簡報包含兩個文字方塊：一個是常規文字，另一個對同一字型套用粗體格式，但該字型沒有專屬的粗體字型。以下範例載入簡報，啟用對不支援粗體字型樣式的光柵化，並匯出為 PDF：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

以下預覽顯示停用與啟用之輸出差異。在此範例中，停用該選項時粗體文字的筆畫較粗。啟用後，筆畫較細；常規文字則保持不變。請比較結果後再為您的簡報選擇設定。

| 停用選項 (`false`，預設) | 啟用選項 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在此範例中，啟用該選項會將僅粗體文字轉為點陣圖：無法選取、複製或在未使用 OCR 時搜尋，且在 800% 放大時邊緣較為柔和。常規文字仍可搜尋。停用選項時，兩段文字皆保持為文字。

此選項會在字型沒有專屬粗體字型時，將粗體格式的文字光柵化。[Font substitution](/slides/zh-hant/net/font-substitution/)則會在原字型不可用時選擇其他字型。

## **將 PowerPoint 中選取的投影片轉換為 PDF**

以下範例將簡報的第 1 與第 3 張投影片匯出為 PDF。此陣列中的投影片編號以 1 為起點，且輸入的簡報必須至少包含三張投影片。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **將 PowerPoint 轉換為 PDF（自訂投影片大小）**

以下範例將簡報的第一張投影片複製到新簡報，並設定投影片大小為 612 × 792 點（8.5 × 11 吋）。它會將投影片內容縮放以適合尺寸，並將單一投影片匯出為 PDF。

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

以下範例將簡報匯出為 PDF，將每張投影片的講者備註放在投影片下方。請使用包含講者備註的簡報以查看結果。

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

## **PDF 的可存取性與合規標準**

Aspose.Slides 允許您使用符合[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)的轉換程序。您可以使用以下任一合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b**、以及**PDF/UA**。

此 C# 程式碼示範根據不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 轉換程序：

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
Aspose.Slides 支援 PDF 轉換操作，允許您將 PDF 檔案轉換為常見的檔案格式。您可以執行[PDF 轉 HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF 轉圖像](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)、以及[PDF 轉 PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/)等轉換。其他針對專門格式的 PDF 轉換操作——[PDF 轉 SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)、以及[PDF 轉 XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)——亦受到支援。
{{% /alert %}}

> **注意**：匯出為 PDF/UA 時，Aspose.Slides 會將複雜圖形（如 SmartArt、圖表與公式）視為單一圖形。個別路徑元素不會保留為獨立內容，可能被標記為雜訊；僅為整體圖形提供替代文字。

## **常見問題**

**我可以一次批次將多個 PowerPoint 檔案轉換為 PDF 嗎？**

是的，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以以程式方式遍歷檔案並套用轉換程序。

**是否可以為轉換後的 PDF 設定密碼保護？**

是的。請使用[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)類別，在轉換過程中設定密碼並定義存取權限。

**如何在 PDF 中包含隱藏投影片？**

將[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)類別中的[ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/)屬性設為 `true`，即可在產生的 PDF 中包含隱藏投影片。

**Aspose.Slides 能在 PDF 中維持高影像品質嗎？**

是的，您可透過在[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)類別中設定[JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/)與[SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/)等屬性，確保 PDF 中的影像具有高品質。

**Aspose.Slides 支援 PDF/A 合規標準嗎？**

是的，Aspose.Slides 允許您匯出符合多種標準的 PDF，包括 PDF/A1a、PDF/A1b 以及 PDF/UA，確保文件符合可存取性與檔案保存需求。

## **其他資源**

- [Aspose.Slides for .NET 文件](/slides/zh-hant/net/)
- [Aspose.Slides for .NET API 參考](https://reference.aspose.com/slides/net/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/conversion)

相關功能： [匯出簡報為 PDF](/slides/zh-hant/features/pdf-export/)。