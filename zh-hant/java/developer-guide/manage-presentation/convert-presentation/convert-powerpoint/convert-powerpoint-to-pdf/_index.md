---
title: 在 Java 中將 PPT 和 PPTX 轉換為 PDF（包含進階功能）
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速程式碼範例與進階轉換選項。"
---
## **概述**

在 Java 中將 PowerPoint 簡報 (PPT、PPTX、ODP 等) 轉換為 PDF 格式提供了多種優點，包括在不同裝置之間的相容性以及保留簡報的版面配置和格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、對 PDF 檔案設定密碼保護、偵測字型替換、選取特定投影片進行轉換，以及對輸出文件套用合規標準。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，只需將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別，然後使用 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法將簡報儲存為 PDF。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別公開了通常用於將簡報轉換為 PDF 的 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java 會在輸出文件中插入其 API 資訊與版本號。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」形式的值。**注意**，您無法指示 Aspose.Slides 更改或移除這些資訊。
{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整個簡報轉為 PDF
* 從簡報中選取特定投影片轉為 PDF

Aspose.Slides 將簡報匯出為 PDF，確保產生的 PDF 與原始簡報高度匹配。轉換過程中會準確呈現元素與屬性，包括：

* 圖像
* 文字方塊和圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 項目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換流程使用預設選項。在此情況下，Aspose.Slides 會嘗試使用最佳設定與最高品質層級將提供的簡報轉換為 PDF。

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
Aspose 提供免費的線上[**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，示範簡報轉 PDF 的轉換過程。您可以使用此轉換器執行測試，以即時體驗此處描述的步驟。
{{% /alert %}}

## **使用選項將 PowerPoint 轉換為 PDF**

Aspose.Slides 提供自訂選項——位於 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 類別下的屬性——讓您自訂產生的 PDF、以密碼鎖定 PDF，或指定轉換流程的執行方式。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

使用自訂的轉換選項，您可設定光柵圖像的偏好品質、指定如何處理中繪圖檔、設定文字的壓縮等級、配置圖像的 DPI，等等。

以下範例將簡報匯出為 PDF 1.5，JPEG 品質設定為 90，圖像解析度設定為 300 DPI，中繪圖檔儲存為 PNG，並使用 Flate 文字壓縮。

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

### **將內嵌 OLE 檔案保留為 PDF 附件**

如果簡報內嵌了 Excel 活頁簿，您可能希望 PDF 接收者能同時存取該活頁簿的資料與檢視投影片。請以 `true` 呼叫 [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-)，將內嵌 OLE 檔案保留為產生的 PDF 附件。

預設值為 `false`：OLE 物件的預覽圖像或圖示會在 PDF 頁面上呈現，但其內嵌檔案不會作為附件加入。將此選項設為 `true` 會額外包含檔案資料。預覽仍為視覺呈現；附件讓接收者可以單獨開啟或儲存內嵌檔案。OLE 物件不會在 PDF 頁面上變為可互動的 Excel 工作表。

以下範例載入已內嵌 Excel 活頁簿的簡報，並將其匯出為附帶該活頁簿的 PDF。

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

1. 在支援檔案附件的檢視器（例如 Adobe Acrobat Reader）中開啟匯出的 PDF。
2. 開啟檢視器的 **Attachments** 面板，找到內嵌的活頁簿。
3. 將附件儲存並在 Excel 中開啟以檢視其資料，或在檢視器允許時直接開啟。PDF 頁面上的預覽與附件是分開的。

{{% alert color="info" title="Note" %}}
PDF/A 標準對附件有限制：PDF/A-1 禁止內嵌檔案，PDF/A-2 只允許 PDF/A 附件，而 PDF/A-3 則允許其他檔案類型，包括 Excel 活頁簿。這些是標準的要求，並非 Aspose.Slides 的限制。此範例使用預設的 PDF 合規設定，未示範 PDF/A 匯出。
{{% /alert %}}

### **使用隱藏投影片將 PowerPoint 轉換為 PDF**

如果簡報包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 類別中的 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 方法，將隱藏投影片納入產生的 PDF 中作為頁面。

以下範例匯出簡報為 PDF，並包含所有隱藏投影片。

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

以下範例將簡報匯出為需要密碼 `password` 才能開啟的 PDF。其存取權限允許列印，包括高品質列印。

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

### **偵測字型替換**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 類別下提供 [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 方法，讓您能在簡報轉 PDF 的過程中偵測字型替換。

以下範例將簡報匯出為 PDF，並將字型替換警告列印至主控台。僅在匯出過程中因缺少字型而進行替換時才會列印警告。

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
欲了解更多關於字型替換的資訊，請參閱 [Font Substitution](/slides/zh-hant/java/font-substitution/) 文章。
{{% /alert %}}

### **處理沒有專用粗體字型的字型**

即使字型沒有專用的粗體字型，簡報仍可對文字套用粗體格式。文字會透過合成粗體（synthetic bolding）來人工加粗常規字形。如果這樣的文字在 PDF 中顯得過於沉重或與預期外觀不符，請以 `true` 呼叫 [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-)。此選項會在 PDF 匯出時將受影響的文字以點陣圖方式呈現，並可能改善某些字型的外觀。預設值為 `false`。

範例簡報包含兩個文字方塊：一個為普通文字，另一個對同一字型套用粗體格式，但該字型沒有專用粗體字型。以下範例載入簡報，啟用不支援字型樣式的點陣化，並將其匯出為 PDF：

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

以下預覽顯示停用與啟用選項的輸出差異。在此範例中，停用選項時粗體文字的筆畫較粗；啟用選項後筆畫較細，普通文字保持不變。請在為簡報選擇設定前比較兩者結果。

| 停用選項 (`false`，預設) | 啟用選項 (`true`) |
|---|---|
| ![PDF（未啟用不支援字型樣式點陣化）](unsupported-bold-disabled.png) | ![PDF（啟用不支援字型樣式點陣化）](unsupported-bold-enabled.png) |

在此範例中，啟用此選項會將僅粗體文字轉換為點陣圖：它無法被選取、複製或在未使用 OCR 的情況下搜尋，且在 800% 放大時邊緣顯得較柔和。普通文字仍可被搜尋。停用選項時，兩段文字皆保持為文字。

此選項會將字型缺乏專用粗體字型的粗體文字點陣化。[Font substitution](/slides/zh-hant/java/font-substitution/) 則會在原字型不可用時選擇其他字型。

## **將 PowerPoint 中選取的投影片轉換為 PDF**

以下範例將簡報中的第 1 與第 3 張投影片匯出為 PDF。此陣列中的投影片編號以 1 為起始，且輸入簡報必須至少包含三張投影片。

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

## **使用自訂投影片尺寸將 PowerPoint 轉換為 PDF**

以下範例將簡報的第一張投影片複製到一個新簡報，該簡報的投影片尺寸為 612 × 792 點（8.5 × 11 吋）。它會將投影片內容縮放以適應尺寸，並將單一投影片匯出為 PDF。

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

    // 移除新簡報建立時產生的空投影片。
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **在備註投影片檢視中將 PowerPoint 轉換為 PDF**

以下範例將簡報匯出為 PDF，將每張投影片的講者備註放置於投影片下方。請使用包含講者備註的簡報以觀察結果。

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

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以以以下任一合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下程式碼示範根據不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 轉換流程：

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
Aspose.Slides 支援 PDF 轉換操作，讓您能將 PDF 檔案轉換為常見的檔案格式。您可以執行 [PDF 轉 HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)、[PDF 轉圖像](https://products.aspose.com/slides/java/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)、以及 [PDF 轉 PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) 轉換。其他針對特殊格式的 PDF 轉換操作——[PDF 轉 SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)、以及 [PDF 轉 XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)——亦受到支援。
{{% /alert %}}

> **注意：** 匯出為 PDF/UA 時，Aspose.Slides 會將諸如 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為分離的內容，可能會被標記為雜項；僅為整個圖形提供替代文字。

## **常見問題**

**我可以批次將多個 PowerPoint 檔案轉換為 PDF 嗎？**

是的，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以以程式方式遍歷檔案並套用轉換程序。

**是否可以對轉換後的 PDF 設定密碼保護？**

可以。請使用 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 類別在轉換過程中設定密碼並定義存取權限。

**如何在 PDF 中包含隱藏投影片？**

在 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 類別中以 `true` 呼叫 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-)，即可將隱藏投影片納入產生的 PDF。

**Aspose.Slides 能在 PDF 中保持高影像品質嗎？**

可以，您可透過 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 類別中的 [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) 與 [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) 等方法，控制 PDF 中影像的品質，以確保高品質的圖像。

**Aspose.Slides 支援 PDF/A 合規標準嗎？**

是的，Aspose.Slides 允許您匯出符合[各種標準](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/)的 PDF，包括 PDF/A1a、PDF/A1b 與 PDF/UA，確保您的文件符合可及性與保存需求。

## **其他資源**

- [Aspose.Slides for Java 文件](/slides/zh-hant/java/)
- [Aspose.Slides for Java API 參考](https://reference.aspose.com/slides/java/)
- [Aspose 免費線上轉換工具](https://products.aspose.app/slides/conversion)