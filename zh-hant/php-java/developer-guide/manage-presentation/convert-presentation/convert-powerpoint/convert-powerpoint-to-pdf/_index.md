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
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速程式碼範例與進階轉換選項。"
---
## **概觀**

在 PHP 中將 PowerPoint 簡報（PPT、PPTX、ODP 等）轉換為 PDF 格式具有多項優勢，包括在不同裝置間的相容性以及保留簡報的版面配置與格式。本指南說明如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、為 PDF 檔案設定密碼保護、偵測字型取代、選擇特定投影片進行轉換，以及對輸出文件套用符合性標準。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，只需將檔名作為參數傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation)類別，然後使用`save`方法將簡報另存為 PDF。[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation)類別公開的`save`方法通常用於將簡報轉換為 PDF。

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for PHP via Java 會將其 API 資訊與版本號插入輸出文件。例如，當將簡報轉換為 PDF 時，Aspose.Slides 會在「Application」欄位填入「*Aspose.Slides*」，在「PDF Producer」欄位填入「*Aspose.Slides v XX.XX*」的形式。**注意**，您無法指示 Aspose.Slides 更改或移除這些資訊。
{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整個簡報為 PDF
* 從簡報中選取特定投影片為 PDF

Aspose.Slides 匯出簡報為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換過程中會精確呈現以下元素與屬性：

* 影像
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 项目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 流程使用預設選項。此情況下，Aspose.Slides 會以最佳設定、最高品質層級將提供的簡報轉換為 PDF。

以下程式碼示範如何將簡報（PPT、PPTX、ODP 等）轉換為 PDF：

```php
# 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
$presentation = new Presentation("PowerPoint.pptx");
try {
    #    將簡報儲存為 PDF。
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose 提供免費的線上[**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pdf)，示範簡報轉 PDF 的流程。您可以使用此轉換器執行測試，以實作此處說明的程序。
{{% /alert %}}

## **使用選項將 PowerPoint 轉 PDF**

Aspose.Slides 提供自訂選項——位於[PdfOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PdfOptions)類別下的屬性——讓您自訂產生的 PDF、以密碼鎖定 PDF，或指定轉換程序的執行方式。

### **使用自訂選項將 PowerPoint 轉 PDF**

透過自訂轉換選項，您可以為點陣影像設定偏好的品質、指定圖形檔的處理方式、設定文字的壓縮等級、配置影像的 DPI，等等。

以下程式碼示範如何使用多個自訂選項將 PowerPoint 簡報轉換為 PDF：

```php
# 實例化 PdfOptions 類別。
$pdfOptions = new PdfOptions();

# 設定 JPG 影像的品質。
$pdfOptions->setJpegQuality(90);

# 設定影像的 DPI。
$pdfOptions->setSufficientResolution(300);

# 設定圖形檔的行為。
$pdfOptions->setSaveMetafilesAsPng(true);

# 設定文字內容的壓縮等級。
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# 定義 PDF 符合性模式。
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # 將簡報儲存為 PDF 文件。
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **將 PowerPoint 轉 PDF（含隱藏投影片）**

若簡報包含隱藏投影片，您可以使用[PdfOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PdfOptions)類別的[setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides)方法，將隱藏投影片納入產生的 PDF 頁面。

以下程式碼示範如何在轉換為 PDF 時包含隱藏投影片：

```php
# 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # 實例化 PdfOptions 類別。
    $pdfOptions = new PdfOptions();

    # 新增隱藏投影片。
    $pdfOptions->setShowHiddenSlides(true);

    # 將簡報儲存為 PDF。
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **將 PowerPoint 轉為受密碼保護的 PDF**

以下程式碼示範如何使用[PdfOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pdfoptions/)類別的保護參數，將 PowerPoint 簡報轉換為受密碼保護的 PDF：

```php
# 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # 實例化 PdfOptions 類別。
    $pdfOptions = new PdfOptions();

    # 設定 PDF 密碼與存取權限。
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # 將簡報儲存為 PDF。
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **偵測字型取代**

Aspose.Slides 在[PdfOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pdfoptions/)類別下提供[setWarningCallback](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveoptions/#setWarningCallback)方法，讓您在簡報轉 PDF 的過程中偵測字型取代情況。

以下程式碼示範如何偵測字型取代：

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// 設定 PDF 選項中的警告回呼。
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
$presentation = new Presentation("sample.pptx");
try {
    // 將簡報儲存為 PDF。
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 
欲了解更多關於字型取代的資訊，請參閱[Font Substitution](/slides/zh-hant/php-java/font-substitution/)文章。
{{% /alert %}} 

## **將 PowerPoint 中的選定投影片轉 PDF**

以下程式碼示範如何僅將 PowerPoint 簡報中的特定投影片轉換為 PDF：

```php
# 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # 設定投影片編號陣列。
    $slides = array(1, 3);

    # 將簡報儲存為 PDF。
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **使用自訂投影片尺寸將 PowerPoint 轉 PDF**

以下程式碼示範如何使用指定的投影片尺寸將 PowerPoint 簡報轉換為 PDF：

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
$presentation = new Presentation("SelectedSlides.pptx");

# 建立一個調整過投影片尺寸的新簡報。
$resizedPresentation = new Presentation();

try {
    # 設定自訂投影片尺寸。
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # 從原始簡報複製第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # 將調整大小的簡報儲存為包含備註的 PDF。
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **在備註投影片視圖下將 PowerPoint 轉 PDF**

以下程式碼示範如何將 PowerPoint 簡報轉換為包含備註的 PDF：

```php
# 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # 設定帶備註版面的 PDF 選項。
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # 將簡報儲存為包含備註的 PDF。
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **PDF 的無障礙與符合性標準**

Aspose.Slides 允許您使用符合[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)的轉換程序。您可以使用以下任一符合性標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

以下程式碼示範根據不同符合性標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

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

{{% alert title="Note" color="warning" %}} 
Aspose.Slides 支援 PDF 轉換作業，讓您可將 PDF 檔案轉換為常見的檔案格式。您可以執行[PDF 轉 HTML](https://products.aspose.com/slides/zh-hant/php-java/conversion/pdf-to-html/)、[PDF 轉影像](https://products.aspose.com/slides/zh-hant/php-java/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/zh-hant/php-java/conversion/pdf-to-jpg/)、以及[PDF 轉 PNG](https://products.aspose.com/slides/zh-hant/php-java/conversion/pdf-to-png/)等轉換。其他針對特定格式的 PDF 轉換—[PDF 轉 SVG](https://products.aspose.com/slides/zh-hant/php-java/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/zh-hant/php-java/conversion/pdf-to-tiff/)、以及[PDF 轉 XML](https://products.aspose.com/slides/zh-hant/php-java/conversion/pdf-to-xml/)—亦受到支援。
{{% /alert %}}

> **注意：** 匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能會被標記為雜項；僅為整體圖形提供替代文字。

## **常見問題集**

**我可以一次批次將多個 PowerPoint 檔案轉換為 PDF 嗎？**  
可以，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以透過程式迭代檔案並套用轉換程序。

**轉換後的 PDF 可以設定密碼保護嗎？**  
當然可以。使用[PdfOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pdfoptions/)類別在轉換過程中設定密碼與存取權限。

**如何在 PDF 中包含隱藏投影片？**  
在[PdfOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pdfoptions/)類別中使用`setShowHiddenSlides`方法，即可在產生的 PDF 中包含隱藏投影片。

**Aspose.Slides 能在 PDF 中維持高影像品質嗎？**  
能。您可以使用`setJpegQuality`與`setSufficientResolution`等方法，於[PdfOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pdfoptions/)類別中控制影像品質，確保 PDF 中的影像保持高品質。

**Aspose.Slides 支援 PDF/A 符合性標準嗎？**  
支援。Aspose.Slides 允許您匯出符合 PDF/A1a、PDF/A1b 以及 PDF/UA 等多種標準的 PDF，確保文件符合無障礙與保存需求。

## **其他資源**

- [Aspose.Slides for PHP via Java 文件](/slides/zh-hant/php-java/)
- [Aspose.Slides for PHP via Java API 參考](https://reference.aspose.com/slides/zh-hant/php-java/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/zh-hant/conversion)