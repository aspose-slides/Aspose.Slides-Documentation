---
title: 在 Java 中將 PPT 與 PPTX 轉換為 PDF（包含進階功能）
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/java/convert-powerpoint-to-pdf/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- PowerPoint 轉 PDF
- 簡報 轉 PDF
- PPT 轉 PDF
- 將 PPT 轉換為 PDF
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
description: "使用 Aspose.Slides 在 Java 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速程式範例與進階轉換選項。"
---
## **概覽**

在 Java 中將 PowerPoint 簡報 (PPT、PPTX、ODP 等) 轉換為 PDF 格式可帶來多項優勢，包括在不同裝置之間的相容性，以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、為 PDF 設定密碼保護、偵測字型替代、選擇特定投影片進行轉換，並將合規標準套用至輸出文件。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別，然後使用 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法將簡報儲存為 PDF。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別提供的 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法通常用於將簡報轉換為 PDF。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java 會將其 API 資訊與版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」的形式。**注意**，您無法指示 Aspose.Slides 更改或移除這些資訊。
{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整個簡報轉換為 PDF
* 從簡報中選擇特定投影片轉換為 PDF

Aspose.Slides 會將簡報匯出為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換過程中會正確呈現以下元素與屬性：

* 影像
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 项目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換流程使用預設選項。在此情況下，Aspose.Slides 嘗試以最高品質設定將提供的簡報轉換為 PDF。

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
Aspose 提供免費的線上 [**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/conversion/ppt-to-pdf) 示範簡報轉 PDF 的流程。您可以使用此轉換器測試此處說明的實作程序。
{{% /alert %}}

## **使用選項將 PowerPoint 轉換為 PDF**

Aspose.Slides 提供自訂選項—屬於 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 類別的屬性—讓您自訂產生的 PDF、為 PDF 設定密碼，或指定轉換過程的行為。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

透過自訂轉換選項，您可以定義光柵影像的品質設定、指定圖形檔的處理方式、設定文字的壓縮等級、配置影像 DPI，等等。

以下範例將簡報匯出為 PDF 1.5，JPEG 品質設定為 90，影像解析度設定為 300 DPI，圖形檔以 PNG 儲存，並使用 Flate 文字壓縮。

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

當簡報包含大量照片或螢幕截圖時，減小匯出 PDF 的大小可讓郵件或下載更為便利。呼叫 [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) 並傳入 `true`，即可在 PDF 匯出過程中自動為每張影像選擇最合適的壓縮演算法。

以下範例載入現有簡報，啟用自動影像壓縮選擇，並將其儲存為 PDF。所有其他 PDF 匯出設定皆保留預設值。

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

此選項會為每張影像選擇壓縮演算法。降低傳入 [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) 的值會降低 JPEG 影像品質；降低傳入 [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) 的值則會將影像降採樣至較低解析度，從而減少細節。啟用自動壓縮選擇本身不會降低上述任一設定。

選擇影像壓縮演算法會增加額外的處理時間與記憶體需求。大小減少幅度取決於簡報內的影像與匯出設定；無法保證每個簡報皆有固定的縮減量。

### **將嵌入的 OLE 檔案保留為 PDF 附件**

如果簡報中嵌入了 Excel 活頁簿，您可能希望 PDF 接收者能同時存取工作簿資料與檢視投影片。呼叫 [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) 並傳入 `true`，即可將嵌入的 OLE 檔案保留為產生的 PDF 附件。

預設值為 `false`：OLE 物件的預覽圖或圖示會在 PDF 頁面上呈現，但其嵌入檔案不會作為附件加入。將此選項設為 `true` 後，會額外將檔案資料加入附件。預覽仍保留為視覺呈現；附件則允許接收者另行開啟或存檔。OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

以下範例載入已嵌入 Excel 活頁簿的簡報，並在匯出成 PDF 時將活頁簿作為附件加入。

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

檢查結果方法：

1. 使用支援附件的 PDF 檢視器（例如 Adobe Acrobat Reader）開啟匯出的 PDF。
2. 開啟檢視器的 **Attachments** 面板，找到嵌入的活頁簿。
3. 儲存附件並以 Excel 開啟檢查其資料，或在檢視器允許時直接開啟。PDF 頁面上的預覽與附件是分離的。

{{% alert color="info" title="Note" %}}
PDF/A 標準對附件有限制：PDF/A-1 禁止嵌入檔案，PDF/A-2 只允許 PDF/A 附件，PDF/A-3 允許其他檔案類型（包括 Excel 活頁簿）。這些限制屬於標準本身，而非 Aspose.Slides 的限制。本範例使用預設的 PDF 合規設定，未示範 PDF/A 匯出。
{{% /alert %}}

### **將 PowerPoint 轉換為包含隱藏投影片的 PDF**

如果簡報中有隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 類別的 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 方法，將隱藏投影片一併作為頁面匯入產生的 PDF。

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

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 類別下提供 [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 方法，讓您在簡報轉 PDF 的過程中偵測字型替代情況。

以下範例將簡報匯出為 PDF，並將字型替代警告輸出至主控台。僅當匯出時因缺少字型而進行替代時，才會印出警告。

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
欲取得更多字型替代資訊，請參閱 [Font Substitution](/slides/zh-hant/java/font-substitution/) 文章。
{{% /alert %}} 

### **處理沒有專用粗體字型的字體**

即使字體本身沒有專用的粗體樣式，簡報仍可能對文字套用粗體格式。此時文字會透過合成粗體 (synthetic bolding) 方式顯示，即人工加粗常規字形。若在 PDF 中此粗體文字看起來過於沉重或與預期外觀不符，可嘗試呼叫 [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) 並傳入 `true`。此選項會在 PDF 匯出時將受影響的文字以點陣圖方式渲染，對某些字體可改善其外觀。預設值為 `false`。

範例簡報包含兩個文字方塊：一個為普通文字，另一個對同一字體套用粗體格式，但該字體沒有專用的粗體字型。以下示例載入此簡報，啟用對不支援字體樣式的光柵化，並匯出為 PDF：

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

以下預覽顯示關閉與開啟選項的輸出差異。此例中，關閉選項時粗體文字的筆劃較粗；開啟選項時筆劃較輕，普通文字則保持不變。請比較結果後再決定在您的簡報中使用哪種設定。

| 關閉選項 (`false`，預設) | 開啟選項 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在此範例中，開啟選項僅會將粗體文字轉為點陣圖：它無法被選取、複製，或在未經 OCR 的情況下搜尋，且在 800% 放大時邊緣較為柔和。普通文字仍保持可搜尋。關閉選項時，兩段文字皆以文字形式保留。

此選項會對字體沒有專用粗體字型的粗體文字進行點陣化。[Font substitution](/slides/zh-hant/java/font-substitution/) 則會在原字體不可用時改用其他字體。

## **將選取的投影片從 PowerPoint 轉換為 PDF**

以下範例將簡報的第 1 與第 3 張投影片匯出為 PDF。陣列中的投影片編號採用從 1 開始計數，輸入的簡報必須至少包含三張投影片。

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

以下範例將簡報的第一張投影片複製到新簡報，並將投影片尺寸設定為 612 × 792 點（8.5 × 11 吋）。它會縮放投影片內容以適應尺寸，並將單一投影片匯出為 PDF。

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

    // 移除新建立的簡報中空白的投影片。
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **在備註投影片檢視中將 PowerPoint 轉換為 PDF**

以下範例將簡報匯出為 PDF，並在每張投影片下方放置該投影片的講者備註。請使用包含講者備註的簡報以查看結果。

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

## **PDF 的無障礙與合規標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以使用以下任一合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 以及 **PDF/UA**。

以下程式碼示範了根據不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

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
Aspose.Slides 支援 PDF 轉換作業，讓您能將 PDF 檔案轉換為常見格式。您可以執行 [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)、以及 [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) 轉換。其他專屬格式的 PDF 轉換—[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)、以及 [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—亦受到支援。
{{% /alert %}}

> **注意：** 在匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能會被標記為雜訊；僅會為整體圖形提供替代文字。

## **常見問題**

**我可以批次將多個 PowerPoint 檔案轉換為 PDF 嗎？**

可以，Aspose.Slides 支援將多個 PPT 或 PPTX 檔案批次轉換為 PDF。您可以在程式中迭代檔案並套用轉換程序。

**是否可以為轉換後的 PDF 設定密碼保護？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 類別在轉換過程中設定密碼與存取權限。

**如何在 PDF 中包含隱藏投影片？**

在 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 類別中呼叫 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 並傳入 `true`，即可在產生的 PDF 中包含隱藏投影片。

**Aspose.Slides 能否在 PDF 中保持高影像品質？**

可以，您可以使用 [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) 與 [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) 等方法，在 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 中控制影像品質，確保 PDF 中的影像保持高品質。

**Aspose.Slides 是否支援 PDF/A 合規標準？**

可以，Aspose.Slides 允許您匯出符合 [various standards](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A1a、PDF/A1b 與 PDF/UA，確保文件符合無障礙與存檔需求。

## **其他資源**

- [Aspose.Slides for Java Documentation](/slides/zh-hant/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)