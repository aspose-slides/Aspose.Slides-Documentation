---
title: 在 PHP 中將 PPT 和 PPTX 轉換為 PDF（包含高階功能）
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/php-java/convert-powerpoint-to-pdf/
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
- 將 PPT 匯出為 PDF
- 將 PPTX 匯出為 PDF
- 附件
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速程式碼範例與高階轉換選項。"
---
## **概覽**

在 PHP 中將 PowerPoint 簡報 (PPT、PPTX、ODP 等) 轉換為 PDF 格式具有多項優勢，包括在不同裝置間的相容性以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、對 PDF 檔案設定密碼保護、偵測字型替換、選擇特定投影片進行轉換，並對輸出文件套用相符性標準。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別，然後使用 [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) 方法將簡報儲存為 PDF。 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別公開了 [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) 方法，通常用於將簡報轉換為 PDF。

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java 會在輸出文件中插入其 API 資訊和版本號。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」形式的值。**注意**，您無法指示 Aspose.Slides 更改或移除這些資訊。
{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整份簡報為 PDF
* 從簡報中挑選特定投影片轉換為 PDF

Aspose.Slides 會將簡報匯出為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換過程中會精確呈現各種元素與屬性，包括：

* 圖片
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 項目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換過程使用預設選項。在此情況下，Aspose.Slides 會嘗試以最佳設定及最高品質等級將提供的簡報轉換為 PDF。

以下範例會載入簡報，並使用預設匯出設定將所有可見投影片儲存為 PDF。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose 提供一個免費的線上 [**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/conversion/ppt-to-pdf) 可示範簡報轉 PDF 的過程。您可以使用此轉換器執行測試，以即時執行此處描述的程序。
{{% /alert %}}

## **將 PowerPoint 轉換為 PDF（含選項）**

Aspose.Slides 提供自訂選項——位於 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 類別下的屬性——讓您自訂產生的 PDF、使用密碼鎖定 PDF，或指定轉換流程的方式。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

使用自訂轉換選項，您可以定義光柵影像的首選品質設定、指定中繼檔的處理方式、設定文字的壓縮等級、配置影像的 DPI，等等。

以下範例將簡報匯出為 PDF 1.5，JPEG 品質設定為 90，影像解析度設定為 300 DPI，中繼檔儲存為 PNG，並使用 Flate 文字壓縮。

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **將嵌入的 OLE 檔案保留為 PDF 附件**

如果簡報中嵌入了 Excel 活頁簿，您可能希望 PDF 接收者能夠存取該活頁簿的資料，同時瀏覽投影片。呼叫 [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 並傳入 `true`，即可在產生的 PDF 中將嵌入的 OLE 檔案保留為附件。

預設值為 `false`：OLE 物件的預覽影像或圖示會在 PDF 頁面上呈現，但其嵌入檔案不會作為附件包含。將此選項設為 `true` 則會額外加入檔案資料。預覽仍為視覺呈現；附件允許接收者另行開啟或儲存嵌入的檔案。OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

以下範例載入已包含嵌入 Excel 活頁簿的簡報，並將其匯出為帶有活頁簿附件的 PDF。

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

檢查結果：

1. 在支援檔案附件的檢視器（例如 Adobe Acrobat Reader）中開啟匯出的 PDF。  
2. 開啟檢視器的 **附件** 面板，並找到嵌入的活頁簿。  
3. 將附件儲存並於 Excel 中開啟以檢視其資料，或在檢視器允許時直接開啟。PDF 頁面的預覽與附件分開。

{{% alert color="info" title="Note" %}}
PDF/A 標準對附件設有限制：PDF/A-1 禁止嵌入檔案，PDF/A-2 僅允許 PDF/A 附件，PDF/A-3 允許其他檔案類型，包括 Excel 活頁簿。這些是標準的要求，並非 Aspose.Slides 特有的限制。本範例使用預設的 PDF 相符性設定，未示範 PDF/A 匯出。
{{% /alert %}}

### **將 PowerPoint 轉換為 PDF（含隱藏投影片）**

如果簡報包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 類別的 [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) 方法，將隱藏投影片納入產生的 PDF 頁面中。

以下範例將簡報匯出為 PDF，並包含所有隱藏投影片。

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **將 PowerPoint 轉換為受密碼保護的 PDF**

以下範例將簡報匯出為需使用密碼 `password` 開啟的 PDF。存取權限允許列印，包括高品質列印。

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **偵測字型替換**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 類別下提供 [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) 方法，讓您在簡報轉 PDF 的過程中偵測字型替換。

以下範例將簡報匯出為 PDF，並將字型替換警告輸出至主控台。僅在匯出時替換了不可用字型時才會顯示警告。

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
如需更多關於字型替換的資訊，請參閱 [字型替換](/slides/zh-hant/php-java/font-substitution/) 文章。
{{% /alert %}}

### **處理沒有專屬粗體字型的字體**

簡報即使字型沒有專屬粗體字形，也可以套用粗體格式。文字仍可能透過合成粗體（synthetic bolding）呈現為粗體，即人工加粗普通字形。若此文字在 PDF 中顯得過重或與預期外觀不同，請嘗試呼叫 [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 並傳入 `true`。此選項會在 PDF 匯出時將受影響的文字以點陣圖方式呈現，可能改善某些字型的顯示。預設值為 `false`。

範例簡報包含兩個文字方塊：一個為普通文字，另一個對同一字型（未具備專屬粗體字形）套用粗體格式。以下範例載入簡報，啟用不支援字體樣式的點陣化，並將其匯出為 PDF：

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

以下預覽顯示停用與啟用選項的輸出結果。在此範例中，停用選項時粗體文字的筆畫較粗；啟用選項後，筆畫較細；普通文字保持不變。請在為簡報選擇設定前，先比較這兩種結果。

| 停用選項 (`false`，預設) | 啟用選項 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在此範例中，啟用選項會將僅粗體文字轉為點陣圖：該文字無法被選取、複製或以文字搜尋（除非使用 OCR），且在 800% 放大時邊緣較柔和。普通文字仍可搜尋。停用選項時，兩段文字皆保留為文字。

此選項會在字型沒有專屬粗體字形時，將粗體格式的文字點陣化。[字型替換](/slides/zh-hant/php-java/font-substitution/) 則會在原始字型不可用時選擇其他字型。

## **將 PowerPoint 中選取的投影片轉換為 PDF**

以下範例將簡報中的第 1 及第 3 張投影片匯出為 PDF。此陣列中的投影片編號以 1 為起始，且輸入的簡報必須至少包含三張投影片。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **使用自訂投影片大小將 PowerPoint 轉換為 PDF**

以下範例將簡報的第一張投影片複製到新簡報，並將投影片大小設定為 612 × 792 點（8.5 × 11 吋）。它會縮放投影片內容以符合尺寸，並將單張投影片匯出為 PDF。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // 移除新簡報建立時所產生的空白投影片。
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **在備註投影片檢視中將 PowerPoint 轉換為 PDF**

以下範例將簡報匯出為 PDF，並將每張投影片的講者備註放置於投影片下方。請使用包含講者備註的簡報以查看效果。

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **PDF 的無障礙與相符性標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines（**WCAG**）](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換流程。您可以使用以下任一相符性標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

此程式碼示範一個根據不同相符性標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides 支援 PDF 轉換操作，允許您將 PDF 檔案轉換為常用格式。您可以執行 [PDF 轉 HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)、[PDF 轉 圖像](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)、以及 [PDF 轉 PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) 轉換。其他轉換到特殊格式的 PDF 操作——[PDF 轉 SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)、以及 [PDF 轉 XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)——亦受支援。
{{% /alert %}}

> **注意:** 匯出為 PDF/UA 時，Aspose.Slides 會將諸如 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能被標記為雜項；僅為整個圖形提供替代文字。

## **常見問題**

**是否可以批次將多個 PowerPoint 檔案轉換為 PDF？**  
是的，Aspose.Slides 支援將多個 PPT 或 PPTX 檔案批次轉換為 PDF。您可以程式化遍歷檔案並套用轉換程序。

**是否可以對轉換後的 PDF 設定密碼保護？**  
是的。請使用 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 類別在轉換過程中設定密碼並定義存取權限。

**如何在 PDF 中包含隱藏投影片？**  
在 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 類別中呼叫 [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) 並傳入 `true`，即可在產生的 PDF 中包含隱藏投影片。

**Aspose.Slides 能否在 PDF 中保持高影像品質？**  
是的，您可以使用 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 類別中的 [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) 與 [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) 等方法，以確保 PDF 中的影像具有高品質。

**Aspose.Slides 是否支援 PDF/A 相符性標準？**  
是的，Aspose.Slides 允許您匯出符合 [各種標準](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A1a、PDF/A1b 與 PDF/UA，確保您的文件符合無障礙與保存需求。

## **其他資源**

- [Aspose.Slides for PHP via Java 文件](/slides/zh-hant/php-java/)
- [Aspose.Slides for PHP via Java API 參考](https://reference.aspose.com/slides/php-java/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/conversion)