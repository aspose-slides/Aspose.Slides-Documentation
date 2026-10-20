---
title: 在 Android 上將 PPT 與 PPTX 轉換為 PDF [包含進階功能]
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/androidjava/convert-powerpoint-to-pdf/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 Java 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速程式碼範例和進階轉換選項。"
---
## **概述**

在 Android 上將 PowerPoint 簡報（PPT、PPTX、ODP 等）轉換為 PDF 格式具有多項優勢，包括在不同裝置之間的相容性以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、以密碼保護 PDF 檔案、偵測字型替代、選取特定投影片進行轉換，以及對輸出文件套用合規標準。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，請將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別，然後使用 [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法將簡報另存為 PDF。 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別公開了通常用於將簡報轉換為 PDF 的 [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java 會將其 API 資訊和版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」形式的值。**注意**，您無法指示 Aspose.Slides 更改或移除這些資訊。
{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整份簡報為 PDF
* 只選擇投影片為 PDF

Aspose.Slides 會將簡報匯出為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換時會準確呈現以下元素與屬性：

* 影像
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 项目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換程序使用預設選項。在此情況下，Aspose.Slides 會嘗試以最佳設定在最高品質層級下將提供的簡報轉換為 PDF。

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
Aspose 提供一個免費的線上 [**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/conversion/ppt-to-pdf) 來示範簡報轉 PDF 的流程。您可以使用此轉換器進行測試，以實作本文件中描述的程序。
{{% /alert %}}

## **使用選項將 PowerPoint 轉換為 PDF**

Aspose.Slides 提供自訂選項——位於 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別下的屬性——讓您自訂產生的 PDF、以密碼鎖定 PDF，或指定轉換過程的執行方式。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

使用自訂轉換選項，您可以定義點陣圖的品質設定、指定中繼檔的處理方式、設定文字壓縮等級、設定影像 DPI 等。

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

### **自動選擇影像壓縮**

當簡報包含大量照片或螢幕截圖時，縮小匯出 PDF 的大小可以讓傳送或下載更容易。呼叫 [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) 並傳入 `true`，即可在 PDF 匯出期間自動為每張影像選擇最適合的壓縮演算法。

以下範例載入既有簡報，啟用自動影像壓縮選擇，並將其儲存為 PDF 文件。所有其他 PDF 匯出設定保留其預設值。

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

此選項會為每張影像選擇壓縮演算法。降低傳入 [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) 的值會降低 JPEG 影像品質；降低傳入 [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) 的值會使影像降採樣至較低解析度，從而減少細節。啟用自動壓縮選擇本身不會降低上述任一設定。

選擇影像壓縮演算法會需要額外的處理時間與記憶體。縮小幅度取決於簡報的影像與匯出設定；無法保證每份簡報皆有固定的縮小比例。

### **將嵌入的 OLE 檔案保留為 PDF 附件**

如果簡報內嵌了 Excel 活頁簿，您可能希望 PDF 接收者同時能存取該活頁簿的資料。呼叫 [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) 並傳入 `true`，即可在產生的 PDF 中保留嵌入的 OLE 檔案作為附件。

預設值為 `false`：PDF 頁面上僅顯示 OLE 物件的預覽圖或圖示，未將嵌入檔案作為附件包含。將此選項設為 `true` 會額外加入檔案資料。預覽仍為視覺表示；附件則允許接收者另行開啟或儲存嵌入檔案。OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

以下範例載入已內嵌 Excel 活頁簿的簡報，並將其匯出為附帶活頁簿的 PDF。

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
3. 儲存附件並以 Excel 開啟以檢視資料，或直接在檢視器允許的情況下開啟。PDF 頁面上的預覽與附件是分開的。

{{% alert color="info" title="Note" %}}
PDF/A 標準對附件有嚴格限制：PDF/A-1 禁止嵌入檔案，PDF/A-2 只允許 PDF/A 附件，PDF/A-3 允許其他檔案類型（包括 Excel 活頁簿）。這些限制屬於標準本身，而非 Aspose.Slides 的限制。本範例使用預設的 PDF 合規設定，未示範 PDF/A 匯出。
{{% /alert %}}

### **使用隱藏投影片將 PowerPoint 轉換為 PDF**

若簡報包含隱藏投影片，您可以使用 [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 方法（屬於 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別）將隱藏投影片納入產生的 PDF 頁面。

以下範例將簡報匯出為 PDF，並包含所有隱藏投影片。

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

### **偵測字型替代**

Aspose.Slides 提供 [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 方法（屬於 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別），讓您在簡報轉 PDF 的過程中偵測字型替代情形。

以下範例將簡報匯出為 PDF，並將字型替代警告輸出至主控台。僅在匯出期間發生不可用字型替代時才會印出警告。

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
欲取得更多字型替代資訊，請參閱 [字型替代](/slides/zh-hant/androidjava/font-substitution/) 文章。
{{% /alert %}} 

### **處理沒有專屬粗體字型的字體**

即使字型本身沒有專屬的粗體樣式，簡報仍可能對文字套用粗體格式。此時會使用合成粗體（synthetic bolding）人工加粗字形。若在 PDF 中此文字顯得過於粗重或與預期外觀不同，請嘗試呼叫 [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) 並傳入 `true`。此選項會在 PDF 匯出時將受影響的文字以點陣圖方式呈現，對某些字型可改善外觀。預設值為 `false`。

範例簡報包含兩個文字方塊：一個為普通文字，另一個則對同一字型套用粗體格式，但該字型沒有專屬粗體字型。以下範例載入簡報，啟用不支援粗體字型的光柵化，並將其匯出為 PDF：

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

以下預覽顯示停用與啟用狀態的輸出差異。在此範例中，停用選項時粗體文字筆劃較粗；啟用選項時筆劃較細，普通文字則未受影響。請比較結果後再為您的簡報決定是否使用此設定。

| 選項停用（`false`，預設） | 選項啟用（`true`） |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在此範例中，啟用選項僅將粗體文字轉為點陣圖：它無法被選取、複製或在未使用 OCR 的情況下搜尋，且在 800% 放大時邊緣較為柔和。普通文字仍保持可搜尋。停用選項時，兩段文字皆保持為文字。

此選項會對字型沒有專屬粗體樣式時的粗體文字進行光柵化。[字型替代](/slides/zh-hant/androidjava/font-substitution/) 則會在原始字型不可用時選擇其他字型。

## **將 PowerPoint 中選取的投影片轉換為 PDF**

以下範例將簡報的第 1 與第 3 張投影片匯出為 PDF。陣列中的投影片編號採用從 1 開始的索引，且輸入的簡報必須至少包含三張投影片。

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

以下範例將簡報的第一張投影片複製到新簡報，並將投影片尺寸設定為 612 × 792 點（8.5 × 11 吋）。它會縮放投影片內容以適應尺寸，並將此單一投影片匯出為 PDF。

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

    // 移除新簡報建立時產生的空白投影片
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **在備註投影片檢視中將 PowerPoint 轉換為 PDF**

以下範例將簡報匯出為 PDF，並在每張投影片下方放置講者備註。請使用包含講者備註的簡報以查看結果。

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

## **PDF 的可存取性與合規標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以使用以下任一合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

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

{{% alert color="info" title="Note" %}}
Aspose.Slides 支援 PDF 轉換操作，讓您可將 PDF 檔案轉換為熱門檔案格式。您可以執行 [PDF 轉 HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)、[PDF 轉影像](https://products.aspose.com/slides/java/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)、以及 [PDF 轉 PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) 的轉換。其他針對特殊格式的 PDF 轉換操作亦受支援，包括 [PDF 轉 SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)、與 [PDF 轉 XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)。
{{% /alert %}}

> **注意：** 匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會以獨立內容保留，可能會被標示為雜訊；僅為整體圖形提供替代文字。

## **常見問題**

**我可以批次將多個 PowerPoint 檔案轉換為 PDF 嗎？**

可以，Aspose.Slides 支援將多個 PPT 或 PPTX 檔案批次轉換為 PDF。您可以在程式中遍歷檔案並套用轉換程序。

**是否可以對轉換後的 PDF 設置密碼保護？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別在轉換過程中設定密碼與存取權限。

**如何在 PDF 中包含隱藏投影片？**

在 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別中呼叫 [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 並傳入 `true`，即可在產生的 PDF 中包含隱藏投影片。

**Aspose.Slides 能否在 PDF 中保持高影像品質？**

可以，您可以使用 [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) 與 [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) 等方法，在 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 類別中控制影像品質，以確保 PDF 中的影像保持高品質。

**Aspose.Slides 是否支援 PDF/A 合規標準？**

支援，Aspose.Slides 允許您匯出符合 [各種標準](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/)（包括 PDF/A1a、PDF/A1b 與 PDF/UA）的 PDF，確保文件符合可存取性與保存需求。

## **其他資源**

- [Aspose.Slides for Android via Java 文件](/slides/zh-hant/androidjava/)
- [Aspose.Slides for Android via Java API 參考](https://reference.aspose.com/slides/androidjava/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/conversion)