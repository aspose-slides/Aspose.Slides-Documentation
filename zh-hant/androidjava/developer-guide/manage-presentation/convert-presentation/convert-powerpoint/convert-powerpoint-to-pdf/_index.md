---
title: 在 Android 上將 PPT 與 PPTX 轉換為 PDF[包含進階功能]
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
- 附件
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 Java 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，並提供快速程式碼範例與進階轉換選項。"
---
## **概述**

在 Android 上將 PowerPoint 簡報（PPT、PPTX、ODP 等）轉換為 PDF 格式具有多項優勢，包括跨裝置相容性以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF，使用各種選項控制影像品質、包含隱藏投影片、以密碼保護 PDF 檔案、偵測字型替代、選取特定投影片進行轉換，以及套用合規標準於輸出文件。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，請將檔名作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別，然後使用 [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法將簡報儲存為 PDF。 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別提供的 [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法通常用於將簡報轉換為 PDF。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java 會將其 API 資訊與版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 **Application** 欄位填入「*Aspose.Slides*」，在 **PDF Producer** 欄位填入「*Aspose.Slides v XX.XX*」形式的值。**注意** 您無法指示 Aspose.Slides 更改或移除這些資訊。
{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整份簡報為 PDF
* 簡報中的特定投影片為 PDF

Aspose.Slides 會將簡報匯出為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換時會正確呈現以下元素與屬性：

* 圖像
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 列表項目
* 表格

## **將 PowerPoint 轉為 PDF**

標準的 PowerPoint 轉 PDF 轉換程序使用預設選項。在此情況下，Aspose.Slides 會嘗試使用最佳設定與最高品質等級將提供的簡報轉換為 PDF。

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
Aspose 提供一個免費的線上 [**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，可示範簡報轉 PDF 的過程。您可使用此轉換器執行測試，以即時驗證此處說明的程序。
{{% /alert %}}

## **使用選項將 PowerPoint 轉為 PDF**

Aspose.Slides 透過 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別提供自訂選項（屬性），讓您自訂產生的 PDF、以密碼鎖定 PDF，或指定轉換程序的執行方式。

### **使用自訂選項將 PowerPoint 轉為 PDF**

透過自訂轉換選項，您可以定義光柵影像的品質設定、指定圖形檔的處理方式、設定文字的壓縮等級、設定影像的 DPI，等等。

以下範例將簡報匯出為 PDF 1.5，JPEG 品質設定為 90，影像解析度設定為 300 DPI，將圖形檔儲存為 PNG，並使用 Flate 文字壓縮。

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

### **將嵌入的 OLE 檔案保留為 PDF 附件**

如果簡報內嵌了 Excel 活頁簿，您可能希望 PDF 收件者同時能存取該活頁簿的資料與投影片。請呼叫 [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) 並傳入 `true`，即可在產生的 PDF 中保留嵌入的 OLE 檔案作為附件。

預設值為 `false`：PDF 頁面上會顯示 OLE 物件的預覽圖或圖示，但不會將嵌入的檔案包含為附件。將此選項設為 `true` 會額外加入檔案資料。預覽仍為視覺呈現；附件則讓收件者可另行開啟或儲存嵌入檔案。OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

以下範例載入已包含嵌入 Excel 活頁簿的簡報，並將其匯出為附帶活頁簿的 PDF。

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

檢查結果的步驟：

1. 使用支援檔案附件的檢視器（例如 Adobe Acrobat Reader）開啟匯出的 PDF。
2. 開啟檢視器的 **Attachments** 面板，找到嵌入的活頁簿。
3. 儲存附件並在 Excel 中開啟以檢查資料，或直接在支援的檢視器中開啟。PDF 頁面的預覽與附件是分開的。

{{% alert color="info" title="Note" %}}
PDF/A 標準對附件有特定限制：PDF/A‑1 禁止嵌入檔案，PDF/A‑2 僅允許 PDF/A 附件，PDF/A‑3 允許其他檔案類型（包括 Excel 活頁簿）。這些是標準本身的要求，非 Aspose.Slides 的限制。此範例使用預設的 PDF 合規設定，未示範 PDF/A 匯出。
{{% /alert %}}

### **使用隱藏投影片將 PowerPoint 轉為 PDF**

如果簡報包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別的 [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 方法，將隱藏投影片亦列為 PDF 中的頁面。

以下範例將簡報匯出為 PDF，包含所有隱藏投影片。

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

### **將 PowerPoint 轉為受密碼保護的 PDF**

以下範例將簡報匯出為需要密碼 `password` 才能開啟的 PDF，且存取權限允許列印，包括高品質列印。

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

### **偵測字型替代**

Aspose.Slides 於 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別提供 [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 方法，讓您在簡報轉 PDF 的過程中偵測字型替代情況。

以下範例將簡報匯出為 PDF，並將字型替代警告輸出至主控台。只有在匯出時遭遇不可用字型而被替代時才會印出警告。

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
欲取得更多字型替代資訊，請參閱 [Font Substitution](/slides/zh-hant/androidjava/font-substitution/) 文章。
{{% /alert %}}

### **處理沒有專用粗體字型的字體**

即使字體本身沒有專用的粗體字型，簡報仍可能對文字套用粗體格式。此時會透過合成粗體（synthetic bolding）使常規字形變粗。若合成粗體在 PDF 中顯得過於沉重或與預期外觀不符，可嘗試呼叫 [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) 並傳入 `true`。此選項會在 PDF 匯出時將受影響的文字以點陣圖方式呈現，對某些字體可改善外觀。預設值為 `false`。

範例簡報包含兩個文字方塊：一個為常規文字，另一個對同一字體套用粗體格式，但該字體沒有專用粗體字型。以下範例載入簡報，啟用不支援字型樣式的點陣化，並將其匯出為 PDF：

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

以下預覽顯示關閉與開啟選項的結果。範例中，關閉選項時粗體文字的筆畫較重；開啟選項後筆畫較輕，常規文字保持不變。請比較結果後再決定使用哪種設定。

| **選項關閉** (`false`，預設) | **選項開啟** (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在此範例中，開啟選項僅將粗體文字轉為位圖：無法選取、複製或在未使用 OCR 時搜尋其文字，且在 800% 放大下邊緣較為柔和。常規文字仍可搜尋。關閉選項時，兩段文字皆保持為文字。

此選項會在字體缺乏專用粗體字型時，將粗體格式的文字點陣化。[Font substitution](/slides/zh-hant/androidjava/font-substitution/) 則會在原字型不存在時改用其他字型。

## **將選取的投影片從 PowerPoint 轉為 PDF**

以下範例將簡報的第 1、3 張投影片匯出為 PDF。陣列中的投影片編號採用一基索引，且輸入簡報必須至少包含三張投影片。

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

## **使用自訂投影片尺寸將 PowerPoint 轉為 PDF**

以下範例將簡報的第一張投影片複製到新簡報，並設定投影片尺寸為 612 × 792 點（8.5 × 11 吋）。它會縮放投影片內容以適應尺寸，然後將單一投影片匯出為 PDF。

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

    // 移除新建立的簡報所產生的空白投影片。
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **在備註投影片視圖中將 PowerPoint 轉為 PDF**

以下範例將簡報匯出為 PDF，並在每張投影片下方放置演講者備註。請使用包含演講者備註的簡報以查看結果。

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

## **PDF 的可及性與相容性標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以依照以下合規標準匯出 PowerPoint 為 PDF：**PDF/A‑1a**、**PDF/A‑1b** 與 **PDF/UA**。

以下程式碼示範根據不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

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
Aspose.Slides 支援 PDF 轉換操作，您可將 PDF 檔案轉換為常見格式。支援的轉換包括 [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)、以及 [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) 等。亦支援將 PDF 轉為專屬格式，如 [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)、以及 [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)。
{{% /alert %}}

> **注意：** 在匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表、公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能被標記為雜項；僅為整體圖形提供替代文字。

## **常見問題**

**是否可以批次將多個 PowerPoint 檔案轉換為 PDF？**

是的，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以在程式中迭代檔案並套用轉換程序。

**是否可以為轉換後的 PDF 設定密碼保護？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別在轉換過程中設定密碼與存取權限。

**如何在 PDF 中包含隱藏投影片？**

在 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別中呼叫 [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 並傳入 `true`，即可在產生的 PDF 中包含隱藏投影片。

**Aspose.Slides 能否在 PDF 中保留高影像品質？**

可以，您可使用 [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) 與 [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) 等方法，在 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 中控制影像品質，確保 PDF 中的影像保持高品質。

**Aspose.Slides 是否支援 PDF/A 合規標準？**

是的，Aspose.Slides 允許您匯出符合 [各種標準](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A‑1a、PDF/A‑1b 與 PDF/UA，確保文件符合可及性與歸檔需求。

## **其他資源**

- [Aspose.Slides for Android via Java 文件](/slides/zh-hant/androidjava/)
- [Aspose.Slides for Android via Java API 參考](https://reference.aspose.com/slides/androidjava/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/conversion)