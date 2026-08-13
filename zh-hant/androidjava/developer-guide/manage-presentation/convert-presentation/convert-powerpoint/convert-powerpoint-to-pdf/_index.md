---
title: 在 Android 上將 PPT 和 PPTX 轉換為 PDF [包含進階功能]
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/androidjava/convert-powerpoint-to-pdf/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- PowerPoint 轉 PDF
- 簡報 轉 PDF
- PPT 轉 PDF
- 轉換 PPT 為 PDF
- PPTX 轉 PDF
- 轉換 PPTX 為 PDF
- 將 PowerPoint 儲存為 PDF
- 將 PPT 儲存為 PDF
- 將 PPTX 儲存為 PDF
- 匯出 PPT 為 PDF
- 匯出 PPTX 為 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 Java 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，並提供快速程式碼範例與進階轉換選項。"
---
## **概述**

在 Android 上將 PowerPoint 簡報（PPT、PPTX、ODP 等）轉換為 PDF 格式具有多項優勢，包括跨裝置相容性以及保留簡報的佈局與格式。本指南說明如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、為 PDF 設定密碼保護、偵測字型替換、選取特定投影片進行轉換，並將合規標準套用於輸出文件。

## **PowerPoint to PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

若要將簡報轉換為 PDF，將檔名作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類，然後使用 `save` 方法將簡報另存為 PDF。[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類公開的 `save` 方法通常用於將簡報轉換為 PDF。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Android via Java 會將其 API 資訊與版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」並在 PDF Producer 欄位以「*Aspose.Slides v XX.XX*」的形式寫入版本資訊。**注意**，您無法指示 Aspose.Slides 更改或移除這些資訊。

{{% /alert %}}

Aspose.Slides 可讓您轉換：

* 整個簡報為 PDF
* 只選取簡報中的特定投影片為 PDF

Aspose.Slides 會將簡報匯出為 PDF，確保產生的 PDF 與原始簡報高度相似。轉換過程中會正確呈現以下元素與屬性：

* 圖像
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁腳
* 项目符號
* 表格

## **Convert PowerPoint to PDF**

標準的 PowerPoint 轉 PDF 轉換流程使用預設選項。在此情況下，Aspose.Slides 會以最高品質設定嘗試將提供的簡報轉換為 PDF。

以下程式碼示範如何將簡報（PPT、PPTX、ODP 等）轉換為 PDF：

```java
import com.aspose.slides.*;

// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // 將簡報另存為 PDF。
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

Aspose 提供免費線上 **PowerPoint 轉 PDF 轉換器**（https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pdf），可示範簡報到 PDF 的轉換流程。您可使用此轉換器測試本說明中的實作方式。

{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides 提供自訂選項—位於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfoptions/) 類下的屬性—讓您自訂輸出 PDF、以密碼鎖定 PDF，或指定轉換流程的執行方式。

### **Convert PowerPoint to PDF with Custom Options**

使用自訂轉換選項，您可以為點陣圖設定偏好的品質、指定如何處理中繪圖檔、為文字設定壓縮層級、為影像設定 DPI 等等。

以下程式碼示範如何以多項自訂選項將 PowerPoint 簡報轉換為 PDF：

```java
import com.aspose.slides.*;

// 實例化 PdfOptions 類別。
PdfOptions pdfOptions = new PdfOptions();

// 設定 JPG 圖像的品質。
pdfOptions.setJpegQuality((byte)90);

// 設定圖像的 DPI。
pdfOptions.setSufficientResolution(300);

/// 設定中繪圖檔的行為。
pdfOptions.setSaveMetafilesAsPng(true);

// 設定文字內容的壓縮等級。
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// 定義 PDF 合規模式。
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // 將簡報另存為 PDF 文件。
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convert PowerPoint to PDF with Hidden Slides**

如果簡報包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfoptions/) 類的 [setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 方法，將隱藏投影片納入輸出 PDF 的頁面。

以下程式碼示範如何在轉換 PDF 時包含隱藏投影片：

```java
import com.aspose.slides.*;

// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // 實例化 PdfOptions 類別。
    PdfOptions pdfOptions = new PdfOptions();

    // 加入隱藏投影片。
    pdfOptions.setShowHiddenSlides(true);

    // 將簡報另存為 PDF。
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convert PowerPoint to Password Protected PDF**

以下程式碼示範如何使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfoptions/) 類的保護參數，將 PowerPoint 簡報轉換為受密碼保護的 PDF：

```java
import com.aspose.slides.*;

// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // 實例化 PdfOptions 類別。
    PdfOptions pdfOptions = new PdfOptions();

    // 設定 PDF 密碼與存取權限。
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // 將簡報另存為 PDF。
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detect Font Substitutions**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfoptions/) 類下提供 [setWarningCallback](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 方法，讓您在簡報轉 PDF 的過程中偵測字型替換。

以下程式碼示範如何偵測字型替換：

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
    Presentation presentation = new Presentation("sample.pptx");

    // 在 PDF 選項中設定警告回呼。
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // 將簡報另存為 PDF。
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
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

欲取得更多關於字型替換的資訊，請參閱 [Font Substitution](/slides/zh-hant/androidjava/font-substitution/) 文章。

{{% /alert %}} 

## **Convert Selected Slides from PowerPoint to PDF**

以下程式碼示範如何只將 PowerPoint 簡報中的特定投影片轉換為 PDF：

```java
import com.aspose.slides.*;

// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // 設定投影片編號陣列。
    int[] slides = { 1, 3 };

    // 將簡報另存為 PDF。
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Convert PowerPoint to PDF with Custom Slide Size**

以下程式碼示範如何以指定的投影片大小將 PowerPoint 簡報轉換為 PDF：

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
Presentation presentation = new Presentation("SelectedSlides.pptx");

// 建立一個具調整投影片尺寸的新簡報。
Presentation resizedPresentation = new Presentation();

try {
    // 設定自訂投影片尺寸。
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // 從原始簡報克隆第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 移除新簡報所建立的空白投影片。
    resizedPresentation.getSlides().removeAt(1);

    // 將調整尺寸的簡報另存為 PDF。
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convert PowerPoint to PDF in Notes Slide View**

以下程式碼示範如何將 PowerPoint 簡報轉換為包含備註的 PDF：

```java
import com.aspose.slides.*;

// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // 使用註記版面配置設定 PDF 選項。
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // 將簡報另存為含註記的 PDF。
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Accessibility and Compliance Standards for PDF**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以使用以下合規標準匯出 PowerPoint 文件為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下程式碼示範依不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

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

Aspose.Slides 支援 PDF 轉換操作，讓您可將 PDF 檔案轉換為常見格式。您可以執行 [PDF to HTML](https://products.aspose.com/slides/zh-hant/java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/zh-hant/java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/zh-hant/java/conversion/pdf-to-jpg/)、以及 [PDF to PNG](https://products.aspose.com/slides/zh-hant/java/conversion/pdf-to-png/) 轉換。亦支援其他專業格式的轉換—[PDF to SVG](https://products.aspose.com/slides/zh-hant/java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/zh-hant/java/conversion/pdf-to-tiff/)、以及 [PDF to XML](https://products.aspose.com/slides/zh-hant/java/conversion/pdf-to-xml/)。

{{% /alert %}}

> **Note:** 在匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能會被標記為雜訊；僅為整體圖形提供替代文字。

## **FAQ**

### 可以一次批次將多個 PowerPoint 檔案轉換為 PDF 嗎？

可以，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以在程式中遍歷檔案並套用轉換流程。

### 可以為轉換後的 PDF 設定密碼保護嗎？

完全可以。使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfoptions/) 類設定密碼與存取權限，即可在轉換過程中加入保護。

### 如何在 PDF 中包含隱藏投影片？

在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfoptions/) 類中使用 `setShowHiddenSlides` 方法，即可將隱藏投影片納入產生的 PDF。

### Aspose.Slides 能否在 PDF 中維持高影像品質？

能。您可以使用 `setJpegQuality`、`setSufficientResolution` 等方法於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfoptions/) 類中調整，確保 PDF 中的影像保有高品質。

### Aspose.Slides 是否支援 PDF/A 合規標準？

支援。Aspose.Slides 允許您匯出符合 PDF/A1a、PDF/A1b 以及 PDF/UA 等多種標準的 PDF，確保文件符合無障礙與存檔需求。

## **Additional Resources**

- [Aspose.Slides for Android via Java Documentation](/slides/zh-hant/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/zh-hant/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/zh-hant/conversion)