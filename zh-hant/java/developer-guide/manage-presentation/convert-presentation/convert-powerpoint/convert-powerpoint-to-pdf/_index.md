---
title: 在 Java 中將 PPT 與 PPTX 轉換為 PDF（包含進階功能）
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/java/convert-powerpoint-to-pdf/
keywords:
- 轉換 PowerPoint
- 轉換投影片
- PowerPoint 轉 PDF
- 投影片 轉 PDF
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
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides 將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速程式範例與進階轉換選項。"
---
## **概述**

在 Java 中將 PowerPoint 投影片（PPT、PPTX、ODP 等）轉換為 PDF 格式具有多項優勢，包括在不同裝置間的相容性以及保留投影片的版面配置與格式。本指南示範如何將投影片轉換為 PDF 文件、使用各種選項來控制影像品質、包含隱藏投影片、為 PDF 檔案設定密碼保護、偵測字型取代、選取特定投影片進行轉換，以及套用合規標準於輸出文件。

## **PowerPoint 轉 PDF 的轉換**

使用 Aspose.Slides，您可以將以下格式的投影片轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將投影片轉換為 PDF，將檔名作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別，然後使用 `save` 方法將投影片另存為 PDF。[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別提供的 `save` 方法通常用於將投影片轉換為 PDF。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java 會將其 API 資訊與版本號插入輸出文件。例如，在將投影片轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」形式的值。**注意**，您無法指示 Aspose.Slides 更改或移除這些資訊。

{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整份投影片至 PDF
* 投影片中的特定頁面至 PDF

Aspose.Slides 匯出投影片為 PDF，確保產生的 PDF 與原始投影片高度一致。轉換過程中會精確呈現以下元素與屬性：

* 圖片
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 項目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 流程使用預設選項。在此情況下，Aspose.Slides 會以最高品質的最佳設定將提供的投影片轉換為 PDF。

以下程式碼示範如何將投影片（PPT、PPTX、ODP 等）轉換為 PDF：

```java
import com.aspose.slides.*;

// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // 將投影片儲存為 PDF。
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

Aspose 提供免費的線上 [**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pdf)，可示範投影片轉 PDF 的流程。您可以使用此轉換器執行測試，以即時驗證本文所述的實作步驟。

{{% /alert %}}

## **使用選項將 PowerPoint 轉換為 PDF**

Aspose.Slides 提供自訂選項—位於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/) 類別下的屬性—讓您自訂產生的 PDF、為 PDF 設定密碼，或指定轉換流程的執行方式。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

透過自訂轉換選項，您可以定義光柵影像的首選品質設定、指定圖形檔的處理方式、設定文字的壓縮等級、設定影像的 DPI，等等。

下方程式碼範例示範如何使用多項自訂選項將 PowerPoint 投影片轉換為 PDF：

```java
import com.aspose.slides.*;

// 實例化 PdfOptions 類別。
PdfOptions pdfOptions = new PdfOptions();

// 設定 JPG 圖像的品質。
pdfOptions.setJpegQuality((byte)90);

// 設定圖像的 DPI。
pdfOptions.setSufficientResolution(300);

// 設定圖形檔的行為。
pdfOptions.setSaveMetafilesAsPng(true);

// 設定文字內容的壓縮等級。
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// 定義 PDF 合規模式。
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // 將投影片儲存為 PDF 文件。
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **使用隱藏投影片將 PowerPoint 轉換為 PDF**

若投影片中包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/) 類別的 [setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 方法，將隱藏投影片作為頁面包含在產生的 PDF 中。

以下程式碼示範如何在轉換 PDF 時包含隱藏投影片：

```java
import com.aspose.slides.*;

// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // 實例化 PdfOptions 類別。
    PdfOptions pdfOptions = new PdfOptions();

    // 新增隱藏投影片。
    pdfOptions.setShowHiddenSlides(true);

    // 將投影片儲存為 PDF。
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **將 PowerPoint 轉換為受密碼保護的 PDF**

以下程式碼示範如何使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/) 類別的保護參數，將 PowerPoint 投影片轉換為受密碼保護的 PDF：

```java
import com.aspose.slides.*;

// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // 實例化 PdfOptions 類別。
    PdfOptions pdfOptions = new PdfOptions();

    // 設定 PDF 密碼與存取權限。
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // 將投影片儲存為 PDF。
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **偵測字型取代**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/) 類別下提供 [setWarningCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 方法，讓您在投影片轉 PDF 的過程中偵測字型取代情況。

以下程式碼示範如何偵測字型取代：

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
    Presentation presentation = new Presentation("sample.pptx");

    // 在 PDF 選項中設定警告回呼。
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // 將投影片儲存為 PDF。
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// 警告回呼的實作。
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

欲了解在渲染過程中取得字型取代回呼的更多資訊，請參閱 [Getting Warning Callbacks for Fonts Substitution](/slides/zh-hant/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

欲取得有關字型取代的更多資訊，請參閱 [Font Substitution](/slides/zh-hant/java/font-substitution/) 文章。

{{% /alert %}} 

## **將 PowerPoint 中的特定投影片轉換為 PDF**

以下程式碼示範如何僅將 PowerPoint 投影片中的特定頁面轉換為 PDF：

```java
import com.aspose.slides.*;

// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // 設定投影片編號的陣列。
    int[] slides = { 1, 3 };

    // 將投影片儲存為 PDF。
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **使用自訂投影片大小將 PowerPoint 轉換為 PDF**

以下程式碼示範如何使用指定的投影片大小將 PowerPoint 投影片轉換為 PDF：

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
Presentation presentation = new Presentation("SelectedSlides.pptx");

// 建立一個具有調整後投影片尺寸的新投影片。
Presentation resizedPresentation = new Presentation();

try {
    // 設定自訂投影片尺寸。
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // 從原始投影片複製第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 移除新投影片在建立時自帶的空白投影片。
    resizedPresentation.getSlides().removeAt(1);

    // 將調整尺寸的投影片儲存為 PDF。
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **在備註投影片視圖中將 PowerPoint 轉換為 PDF**

以下程式碼示範如何將包含備註的 PowerPoint 投影片轉換為 PDF：

```java
import com.aspose.slides.*;

// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // 設定帶備註版面的 PDF 選項。
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // 將投影片儲存為含備註的 PDF。
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF 的可存取性與合規標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以使用以下合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下程式碼示範一個根據不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides 支援 PDF 轉換作業，讓您能將 PDF 檔案轉換為常見格式。您可以執行 [PDF 轉 HTML](https://products.aspose.com/slides/zh-hant/java/conversion/pdf-to-html/)、[PDF 轉影像](https://products.aspose.com/slides/zh-hant/java/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/zh-hant/java/conversion/pdf-to-jpg/)、以及 [PDF 轉 PNG](https://products.aspose.com/slides/zh-hant/java/conversion/pdf-to-png/) 的轉換。其他針對特殊格式的 PDF 轉換作業—[PDF 轉 SVG](https://products.aspose.com/slides/zh-hant/java/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/zh-hant/java/conversion/pdf-to-tiff/)、以及 [PDF 轉 XML](https://products.aspose.com/slides/zh-hant/java/conversion/pdf-to-xml/)—亦受到支援。

{{% /alert %}}

> **注意：** 在匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表和公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能會被標記為偽影；僅為整個圖形提供替代文字。

## **常見問題**

### 可以一次批次將多個 PowerPoint 檔案轉換為 PDF 嗎？

可以，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以在程式中遍歷檔案並套用轉換流程。

### 能否為轉換後的 PDF 設定密碼保護？

當然可以。使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/) 類別在轉換過程中設定密碼與存取權限。

### 如何在 PDF 中包含隱藏投影片？

在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/) 類別中使用 `setShowHiddenSlides` 方法，即可在產生的 PDF 中加入隱藏投影片。

### Aspose.Slides 能否在 PDF 中維持高影像品質？

能。您可以使用 `setJpegQuality`、`setSufficientResolution` 等方法（位於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/) 類別）控制影像品質，確保 PDF 中的影像保持高品質。

### Aspose.Slides 是否支援 PDF/A 合規標準？

支援。Aspose.Slides 可匯出符合 [各種標準](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A1a、PDF/A1b 與 PDF/UA，確保文件符合可存取性與存檔需求。

## **其他資源**

- [Aspose.Slides for Java 文件](/slides/zh-hant/java/)
- [Aspose.Slides for Java API 參考]https://reference.aspose.com/slides/zh-hant/java/
- [Aspose 免費線上轉換器]https://products.aspose.app/slides/zh-hant/conversion