---
title: 在 Android 上將 PPT 和 PPTX 轉換為 PDF（包含進階功能）
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/androidjava/convert-powerpoint-to-pdf/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- PowerPoint 轉 PDF
- 簡報轉 PDF
- PPT 轉 PDF
- 轉換 PPT 為 PDF
- PPTX 轉 PDF
- 轉換 PPTX 為 PDF
- 將 PowerPoint 儲存為 PDF
- 將 PPT 儲存為 PDF
- 將 PPTX 儲存為 PDF
- 匯出 PPT 為 PDF
- 匯出 PPTX 為 PDF
- 附件
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android，在 Java 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速程式碼範例與進階轉換選項。"
---
## **概覽**

在 Android 上將 PowerPoint 簡報（PPT、PPTX、ODP 等）轉換為 PDF 格式具備多項優勢，包括在不同裝置間的相容性以及保留簡報的版面配置與格式。本指南說明如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、為 PDF 檔案設定密碼保護、偵測字體置換、選擇特定投影片進行轉換，並於輸出文件套用合規標準。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，請將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別，然後使用 [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法將簡報另存為 PDF。 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別公開的 [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法通常用於將簡報轉換為 PDF。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java 會將其 API 資訊與版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」形式的值。**注意** 您無法指示 Aspose.Slides 更改或移除這些資訊。
{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整份簡報為 PDF
* 簡報中的特定投影片為 PDF

Aspose.Slides 將簡報匯出為 PDF，確保產生的 PDF 與原始簡報高度相似。轉換過程中會精確還原元素與屬性，包括：

* 影像
* 文字方塊與圖形
* 文字格式設定
* 段落格式設定
* 超連結
* 頁首與頁尾
* 項目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換流程使用預設選項。在此情況下，Aspose.Slides 會以最佳設定及最高品質層級嘗試將提供的簡報轉換為 PDF。

以下範例載入簡報，並使用預設匯出設定將所有可見投影片儲存為 PDF。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose 提供一個免費的線上 [**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，示範簡報轉 PDF 的轉換流程。您可以使用此轉換器進行測試，以實時體驗此處描述的步驟。
{{% /alert %}}

## **使用選項將 PowerPoint 轉換為 PDF**

Aspose.Slides 提供自訂選項——位於 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別下的屬性，讓您自訂輸出 PDF、以密碼鎖定 PDF，或指定轉換流程的執行方式。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

使用自訂轉換選項，您可以定義光柵影像的品質設定、指定圖形檔的處理方式、設定文字的壓縮等級、配置影像的 DPI，等等。

以下範例將簡報匯出為 PDF 1.5，JPEG 品質設定為 90，影像解析度設定為 300 DPI，圖形檔另存為 PNG，並使用 Flate 文字壓縮。

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **保留內嵌 OLE 檔案為 PDF 附件**

如果簡報內含內嵌的 Excel 活頁簿，您可能希望 PDF 接收者能存取該活頁簿的資料，同時檢視投影片。呼叫 [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) 並傳入 `true`，即可在產生的 PDF 中保留內嵌 OLE 檔案作為附件。

預設值為 `false`：PDF 頁面上會呈現 OLE 物件的預覽圖或圖示，但不會將其內嵌檔案作為附件包含。將此選項設為 `true` 會額外加入檔案資料。預覽仍僅為視覺呈現；附件允許接收者另行開啟或儲存內嵌檔案。OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

以下範例載入已包含內嵌 Excel 活頁簿的簡報，並將其匯出為附帶該活頁簿的 PDF。

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

檢查結果：

1. 在支援附件功能的檢視器（例如 Adobe Acrobat Reader）中開啟匯出的 PDF。
2. 開啟檢視器的 **Attachments**（附件）面板，找到內嵌的活頁簿。
3. 將附件儲存並在 Excel 中開啟以檢視其資料，或若檢視器允許直接開啟則直接開啟。PDF 頁面的預覽與附件是分開的。

{{% alert color="info" title="Note" %}}
PDF/A 標準對附件有嚴格限制：PDF/A-1 禁止內嵌檔案，PDF/A-2 僅允許 PDF/A 附件，PDF/A-3 允許其他檔案類型，包括 Excel 活頁簿。這些限制屬於標準本身，而非 Aspose.Slides 特有的限制。此範例使用預設的 PDF 合規設定，未示範 PDF/A 匯出。
{{% /alert %}}

### **將 PowerPoint 轉換為包含隱藏投影片的 PDF**

如果簡報包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別的 [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 方法，將隱藏投影片納入產生的 PDF 頁面中。

以下範例將簡報匯出為 PDF，且包含所有隱藏投影片。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **將 PowerPoint 轉換為受密碼保護的 PDF**

以下範例將簡報匯出為需要密碼 `password` 才能開啟的 PDF。存取權限允許列印，包括高品質列印。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **偵測字體置換**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別下提供 [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 方法，使您能在簡報轉 PDF 的過程中偵測字體置換。

以下範例將簡報匯出為 PDF，並將字體置換警告輸出至主控台。僅在匯出時因缺少字體而進行置換時才會打印警告。

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
欲取得更多關於字體置換的資訊，請參閱 [字體置換](/slides/zh-hant/androidjava/font-substitution/) 文章。
{{% /alert %}} 

## **將選取的投影片從 PowerPoint 轉換為 PDF**

以下範例將簡報中的第 1 與第 3 張投影片匯出為 PDF。此陣列中的投影片編號以 1 為起點，且輸入簡報必須至少包含三張投影片。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **使用自訂投影片大小將 PowerPoint 轉換為 PDF**

以下範例將簡報的第一張投影片複製到一個新簡報，並設定投影片尺寸為 612 × 792 點（8.5 × 11 吋）。它會縮放投影片內容以符合尺寸，然後將單一投影片匯出為 PDF。

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 移除新簡報建立時所產生的空白投影片。
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **在備註投影片檢視中將 PowerPoint 轉換為 PDF**

以下範例將簡報匯出為 PDF，於每張投影片下方放置其演講者備註。請使用含有備註的簡報以觀察結果。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF 的可及性與合規標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以依以下合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下程式碼展示根據不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

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

{{% alert color="info" title="Note" %}}
Aspose.Slides 支援 PDF 轉換操作，允許您將 PDF 檔案轉換為常見格式。您可以執行 [PDF 轉 HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)、[PDF 轉影像](https://products.aspose.com/slides/java/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)、以及 [PDF 轉 PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) 轉換。其他針對特定格式的 PDF 轉換——[PDF 轉 SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)、以及 [PDF 轉 XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)——亦受支援。
{{% /alert %}}

> **注意:** 匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表、公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能被標記為雜訊；替代文字僅提供給整個圖形。

## **常見問題**

**我可以批次將多個 PowerPoint 檔案轉換為 PDF 嗎？**

是的，Aspose.Slides 支援將多個 PPT 或 PPTX 檔案批次轉換為 PDF。您可以在程式中遍歷檔案並套用轉換流程。

**能否對轉換後的 PDF 設定密碼保護？**

是的。使用 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別在轉換過程中設定密碼並定義存取權限。

**如何在 PDF 中包含隱藏投影片？**

在 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別中呼叫 [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 並傳入 `true`，即可將隱藏投影片納入產生的 PDF。

**Aspose.Slides 能在 PDF 中保留高影像品質嗎？**

是的，您可以使用 [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) 與 [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) 等方法，在 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別中設定，以確保 PDF 中的影像具備高品質。

**Aspose.Slides 是否支援 PDF/A 合規標準？**

是的，Aspose.Slides 允許您匯出符合 [各種標準](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/)（包括 PDF/A1a、PDF/A1b 與 PDF/UA）的 PDF，確保文件符合可及性與保存需求。

## **其他資源**

- [Aspose.Slides for Android via Java 文件](/slides/zh-hant/androidjava/)
- [Aspose.Slides for Android via Java API 參考文件](https://reference.aspose.com/slides/androidjava/)
- [Aspose 免費線上轉換工具](https://products.aspose.app/slides/conversion)