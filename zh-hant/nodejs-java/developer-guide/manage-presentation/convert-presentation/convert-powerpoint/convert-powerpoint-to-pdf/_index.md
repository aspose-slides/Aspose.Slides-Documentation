---
title: 在 JavaScript 中將 PPT 與 PPTX 轉換為 PDF（包含進階功能）
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/nodejs-java/convert-powerpoint-to-pdf/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速程式範例與進階轉換選項。"
---
## **概觀**

在 JavaScript 中將 PowerPoint 與 OpenDocument 簡報（PPT、PPTX、ODP 等）轉換為 PDF 格式可提供多種優勢，包括在不同裝置間的相容性以及保留簡報的版面配置與格式。本文指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、以密碼保護 PDF 檔案、偵測字型替換、選擇特定投影片進行轉換，以及對輸出文件套用合規標準。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，請將檔案名稱作為引數傳遞給 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別，然後使用 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) 方法將簡報儲存為 PDF。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別公開的 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) 方法通常用於將簡報轉換為 PDF。

{{% alert color="info" title="Note" %}}

Aspose.Slides for Node.js via Java 會將其 API 資訊與版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 **Application** 欄位填入 "*Aspose.Slides*"，在 **PDF Producer** 欄位填入 "*Aspose.Slides v XX.XX*" 形式的值。**注意**，您無法指示 Aspose.Slides 變更或移除這些資訊。

{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整份簡報至 PDF
* 簡報中的特定投影片至 PDF

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

標準的 PowerPoint 轉 PDF 轉換流程使用預設選項。在此情況下，Aspose.Slides 會以最高品質等級的最佳設定將提供的簡報轉換為 PDF。

以下範例載入簡報並使用預設匯出設定將所有可見投影片儲存為 PDF。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose 提供免費的線上 [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，可示範簡報至 PDF 的轉換流程。您可以使用此轉換器執行測試，實作本文所述程序。

{{% /alert %}}

## **使用選項將 PowerPoint 轉換為 PDF**

Aspose.Slides 提供自訂選項——位於 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 類別下的屬性——讓您自訂產生的 PDF、以密碼鎖定 PDF，或指定轉換過程的行為。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

使用自訂轉換選項，您可以為點陣圖影像定義偏好的品質設定、指定中繼圖的處理方式、設定文字的壓縮等級、設定影像的 DPI 等。

以下範例將簡報匯出為 PDF 1.5，JPEG 品質設定為 90，影像解析度設定為 300 DPI，中繼圖以 PNG 儲存，並使用 Flate 文字壓縮。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **將嵌入的 OLE 檔案保留為 PDF 附件**

如果簡報中包含嵌入的 Excel 活頁簿，您可能希望 PDF 接收者也能存取該活頁簿的資料，同時檢視投影片。呼叫 [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 並傳入 `true`，即可將嵌入的 OLE 檔案保留為 PDF 附件。

預設值為 `false`：PDF 頁面上僅呈現 OLE 物件的預覽影像或圖示，嵌入檔案不會作為附件加入。將此選項設為 `true` 會額外包含檔案資料。預覽仍為視覺表示；附件則允許接收者另行開啟或儲存嵌入檔案。OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

以下範例載入已包含嵌入 Excel 活頁簿的簡報，並將其匯出為附帶活頁簿的 PDF。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

檢查結果：

1. 在支援附件的檢視器（如 Adobe Acrobat Reader）中開啟匯出的 PDF。
2. 開啟檢視器的 **Attachments** 面板，找到嵌入的活頁簿。
3. 儲存附件並以 Excel 開啟以檢視資料，或直接在檢視器允許時開啟。PDF 頁面上的預覽與附件是分開的。

{{% alert color="info" title="Note" %}}

PDF/A 標準對附件有限制：PDF/A-1 禁止嵌入檔案，PDF/A-2 僅允許 PDF/A 附件，PDF/A-3 允許其他檔案類型（包括 Excel 活頁簿）。這些是標準的要求，並非 Aspose.Slides 的限制。此範例使用預設的 PDF 合規設定，未示範 PDF/A 匯出。

{{% /alert %}}

### **將 PowerPoint 轉換為包含隱藏投影片的 PDF**

如果簡報包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 類別的 [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) 方法，將隱藏投影片加入產生的 PDF 之中。

以下範例將簡報匯出為 PDF，並包含所有隱藏投影片。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **將 PowerPoint 轉換為受密碼保護的 PDF**

以下範例將簡報匯出為需要密碼 `password` 才能開啟的 PDF，且存取權限允許列印（包括高品質列印）。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **偵測字型替換**

Aspose.Slides 提供位於 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 類別下的 [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) 方法，讓您在簡報轉 PDF 的過程中偵測字型替換。

以下範例將簡報匯出為 PDF，並將字型替換警告列印至主控台。僅當匯出期間出現無法使用的字型被替換時才會列印警告。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

欲取得更多字型替換資訊，請參閱 [Font Substitution](/slides/zh-hant/nodejs-java/font-substitution/) 文章。

{{% /alert %}} 

### **處理沒有專屬粗體字型的字型**

即使字型本身沒有專屬的粗體字型，簡報仍可對文字套用粗體格式。此時文字會透過合成粗體（synthetic bolding）加粗。若合成粗體在 PDF 中顯示過重或與預期外觀不符，請嘗試呼叫 [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 並傳入 `true`。此選項會在 PDF 匯出時將受影響的文字以點陣圖方式呈現，對某些字型的外觀可有所改善。預設值為 `false`。

範例簡報包含兩個文字方塊：一個為普通文字，另一個為相同字型但套用粗體格式，而該字型沒有專屬粗體字型。以下範例載入簡報，啟用不支援字型樣式的點陣化，並將其匯出為 PDF：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

以下預覽顯示停用與啟用時的輸出差異。此範例中，停用時粗體文字的筆劃較重；啟用後筆劃較輕，普通文字則保持不變。請比較結果後再決定在您的簡報中使用哪種設定。

| 停用選項 (`false`，預設) | 啟用選項 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在此範例中，啟用選項僅把粗體文字轉為點陣圖：無法選取、複製或以 OCR 方式搜尋，且在 800% 放大時邊緣較為柔和。普通文字仍可搜尋。停用時，兩段文字皆保持可搜尋的文字。

此選項會在字型沒有專屬粗體字型時，將粗體格式的文字點陣化。[Font substitution](/slides/zh-hant/nodejs-java/font-substitution/) 則會在原字型不可用時改用其他字型。

## **將選取的投影片從 PowerPoint 轉換為 PDF**

以下範例將簡報的第 1 與第 3 張投影片匯出為 PDF。陣列中的投影片編號為一位制，且輸入簡報必須至少包含三張投影片。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **使用自訂投影片尺寸將 PowerPoint 轉換為 PDF**

以下範例將簡報的第一張投影片複製到一個新的簡報，投影片尺寸為 612 × 792 點（8.5 × 11 吋）。它會將投影片內容縮放以適應，並將單一投影片匯出為 PDF。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 移除新簡報建立時所產生的空白投影片。
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **在備註投影片檢視下將 PowerPoint 轉換為 PDF**

以下範例將簡報匯出為 PDF，並將每張投影片的講者備註置於投影片下方。請使用包含講者備註的簡報以觀察結果。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF 的可及性與合規標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以使用以下合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下程式碼示範了依不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose.Slides 支援 PDF 轉換操作，讓您可以將 PDF 檔案轉換為常見檔案格式。您可以執行 [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/)、[PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/)、以及 [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) 的轉換。其他針對專門格式的 PDF 轉換操作——如 [PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)——亦受到支援。

{{% /alert %}}

> **注意：** 在匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能被標記為雜訊；僅對整體圖形提供替代文字。

## **常見問題集**

**我可以一次大量將多個 PowerPoint 檔案批次轉換為 PDF 嗎？**

可以，Aspose.Slides 支援將多個 PPT 或 PPTX 檔案批次轉換為 PDF。您可以在程式中遍歷檔案並套用轉換程序。

**能否對轉換後的 PDF 設定密碼保護？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 類別設定密碼與存取權限，即可在轉換過程中實現。

**如何在 PDF 中包含隱藏投影片？**

在 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 類別中呼叫 [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) 並傳入 `true`，即可在產生的 PDF 中包含隱藏投影片。

**Aspose.Slides 能否在 PDF 中維持高影像品質？**

可以，您可使用 [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) 與 [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) 等方法，在 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 中控制影像品質，確保 PDF 中的影像維持高品質。

**Aspose.Slides 是否支援 PDF/A 合規標準？**

可以，Aspose.Slides 允許您匯出符合 [各種標準](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A1a、PDF/A1b 與 PDF/UA，確保您的文件符合可及性與存檔需求。

## **其他資源**

- [Aspose.Slides for Node.js via Java 文件](/slides/zh-hant/nodejs-java/)
- [Aspose.Slides for Node.js via Java API 參考](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose 免費線上轉換工具](https://products.aspose.app/slides/conversion)