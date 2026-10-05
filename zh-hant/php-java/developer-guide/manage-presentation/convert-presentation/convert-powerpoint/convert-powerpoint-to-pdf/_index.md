---
title: 在 PHP 中將 PPT 與 PPTX 轉換為 PDF [包含進階功能]
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
- 匯出 PPT 為 PDF
- 匯出 PPTX 為 PDF
- 附件
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，並提供快速程式碼範例與進階轉換選項。"
---
## **概觀**

將 PowerPoint 簡報 (PPT、PPTX、ODP 等) 轉換為 PDF 格式的 PHP 解決方案具有多項優點，包括在不同裝置間的相容性以及保留簡報的版面配置與格式。 本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、以密碼保護 PDF、偵測字型替換、選取特定投影片進行轉換，以及對輸出文件套用合規標準。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別，然後使用 [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) 方法將簡報儲存為 PDF。 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 類別提供的 [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) 方法通常用於將簡報轉換為 PDF。

{{% alert color="info" title="Note" %}}

Aspose.Slides for PHP via Java 會將其 API 資訊和版本號插入輸出文件。 例如，在將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入 "*Aspose.Slides*"，在 PDF Producer 欄位填入 "*Aspose.Slides v XX.XX*" 形式的值。 **注意** 您無法指示 Aspose.Slides 更改或移除這些資訊。

{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整個簡報為 PDF
* 從簡報中挑選特定投影片為 PDF

Aspose.Slides 將簡報匯出為 PDF，確保產生的 PDF 與原始簡報高度吻合。 轉換過程中會正確呈現以下元素與屬性：

* 影像
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 首頁與頁尾
* 项目符號
* 表格

## **將 PowerPoint 轉為 PDF**

標準的 PowerPoint 轉 PDF 轉換程序使用預設選項。 在此情況下，Aspose.Slides 會使用最佳設定、最高品質層級將提供的簡報轉換為 PDF。

以下範例載入簡報，並使用預設匯出設定將所有可見投影片儲存為 PDF。

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

Aspose 提供免費線上 [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) 以示範簡報轉 PDF 的流程。 您可以使用此轉換器進行測試，實際體驗此處描述的步驟。

{{% /alert %}}

## **使用選項將 PowerPoint 轉為 PDF**

Aspose.Slides 提供自訂選項 — 位於 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 類別下的屬性 — 讓您自訂輸出 PDF、以密碼鎖定 PDF，或指定轉換過程的執行方式。

### **使用自訂選項將 PowerPoint 轉為 PDF**

使用自訂轉換選項，您可以定義點陣圖影像的品質設定、指定 Metafile 的處理方式、設定文字的壓縮等級、配置影像 DPI，等等。

以下範例將簡報匯出為 PDF 1.5，JPEG 品質設定為 90，影像解析度設定為 300 DPI，Metafile 以 PNG 儲存，並使用 Flate 文字壓縮。

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

### **將嵌入式 OLE 檔案保留為 PDF 附件**

如果簡報內含嵌入的 Excel 工作簿，您可能希望 PDF 接收者能存取該工作簿的資料，同時瀏覽投影片。 呼叫 [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) 並傳入 `true`，即可在產生的 PDF 中將嵌入式 OLE 檔案保留為附件。

預設值為 `false`：OLE 物件的預覽影像或圖示會在 PDF 頁面上呈現，但其嵌入檔案不會作為附件包含。 將此選項設為 `true` 會額外包含檔案資料。 預覽仍為視覺呈現；附件則允許接收者另行開啟或儲存嵌入檔案。 OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

以下範例載入已包含嵌入式 Excel 工作簿的簡報，並將其匯出為附帶工作簿的 PDF。

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

1. 在支援檔案附件的檢視器（如 Adobe Acrobat Reader）中開啟匯出的 PDF。
2. 開啟檢視器的 **Attachments** 面板，找到嵌入的工作簿。
3. 儲存附件並在 Excel 中開啟以檢查資料，或在檢視器允許的情況下直接開啟。 PDF 頁面的預覽與附件是分開的。

{{% alert color="info" title="Note" %}}

PDF/A 標準對附件有規範：PDF/A-1 禁止嵌入檔案，PDF/A-2 僅允許 PDF/A 附件，PDF/A-3 允許其他檔案類型（包括 Excel 工作簿）。 這些限制來源於標準本身，而非 Aspose.Slides 的限制。 本範例使用預設的 PDF 合規設定，未示範 PDF/A 匯出。

{{% /alert %}}

### **將隱藏投影片包含於 PDF**

如果簡報包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 類別的 [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 方法，將隱藏投影片作為頁面包含在產生的 PDF 中。

以下範例將簡報匯出為 PDF，並包含任何隱藏投影片。

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

### **將 PowerPoint 轉為受密碼保護的 PDF**

以下範例將簡報匯出為需要密碼 `password` 才能開啟的 PDF。 存取權限允許列印，包括高品質列印。

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

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 類別下提供 [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) 方法，讓您在簡報轉 PDF 的過程中偵測字型替換。

以下範例將簡報匯出為 PDF，並將字型替換警告輸出至主控台。 只有在匯出期間發生無法使用的字型被替換時，才會列印警告。

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

如需取得更多字型替換資訊，請參閱 [Font Substitution](/slides/zh-hant/php-java/font-substitution/) 文章。

{{% /alert %}} 

## **將選取的投影片從 PowerPoint 轉為 PDF**

以下範例將簡報的第 1 與第 3 張投影片匯出為 PDF。 此陣列中的投影片編號採用一基索引，且輸入的簡報至少須包含三張投影片。

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

## **使用自訂投影片大小將 PowerPoint 轉為 PDF**

以下範例將簡報的第一張投影片複製到新簡報，並將投影片大小設定為 612 × 792 點（8.5 × 11 吋）。 它會縮放投影片內容以符合尺寸，並將單一投影片匯出為 PDF。

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

    // 移除新簡報建立時產生的空白投影片。
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **在備註投影片檢視中將 PowerPoint 轉為 PDF**

以下範例將簡報匯出為 PDF，並將每張投影片的講者備註放在投影片下方。 使用包含講者備註的簡報以觀看結果。

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

## **PDF 的可近性與合規標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。 您可以使用下列任一合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下程式碼示範依不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

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

Aspose.Slides 支援 PDF 轉換操作，允許您將 PDF 檔案轉換為常見檔案格式。 您可執行 [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)、以及 [PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) 轉換。 其他針對專門格式的 PDF 轉換操作 — [PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)、以及 [PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — 亦受到支援。

{{% /alert %}}

> **注意:** 在匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。 個別路徑元素不會保留為獨立內容，可能會被標記為雜項；替代文字僅提供給整個圖形。

## **常見問題**

**我可以批次將多個 PowerPoint 檔案轉換為 PDF 嗎？**

是的，Aspose.Slides 支援將多個 PPT 或 PPTX 檔案批次轉換為 PDF。 您可以遍歷檔案並以程式方式執行轉換程序。

**是否可以對轉換後的 PDF 設置密碼保護？**

是的。 使用 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 類別在轉換過程中設定密碼並定義存取權限。

**如何在 PDF 中包含隱藏投影片？**

在 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 類別中呼叫 [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 並傳入 `true`，即可在產生的 PDF 中包含隱藏投影片。

**Aspose.Slides 能在 PDF 中保持高影像品質嗎？**

可以，您可使用如 [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setJpegQuality) 與 [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSufficientResolution) 等方法，在 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) 類別中控制影像品質，以確保 PDF 中的影像保持高品質。

**Aspose.Slides 是否支援 PDF/A 合規標準？**

是的，Aspose.Slides 允許您匯出符合 [various standards](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A1a、PDF/A1b 與 PDF/UA，確保文件符合可近性與存檔要求。

## **其他資源**

- [Aspose.Slides for PHP via Java 說明文件](/slides/zh-hant/php-java/)
- [Aspose.Slides for PHP via Java API 參考文件](https://reference.aspose.com/slides/php-java/)
- [Aspose 免費線上轉換工具](https://products.aspose.app/slides/conversion)