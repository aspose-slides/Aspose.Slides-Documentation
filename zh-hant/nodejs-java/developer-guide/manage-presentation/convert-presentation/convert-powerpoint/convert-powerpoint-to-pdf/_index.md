---
title: 使用 Aspose.Slides for Node.js 在 JavaScript 中將 PPT 與 PPTX 轉換為 PDF（含進階功能）
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- PowerPoint 轉 PDF
- 簡報 轉 PDF
- PPT 轉 PDF
- 轉換 PPT 為 PDF
- PPTX 轉 PDF
- 轉換 PPTX 為 PDF
- 儲存 PowerPoint 為 PDF
- 儲存 PPT 為 PDF
- 儲存 PPTX 為 PDF
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
## **概覽**

在 JavaScript 中將 PowerPoint 與 OpenDocument 簡報（PPT、PPTX、ODP 等）轉換為 PDF 格式具有多項優勢，包括在不同裝置間的相容性以及保留簡報的版面配置與格式。本文指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、為 PDF 檔案設定密碼保護、偵測字型取代、選取特定投影片進行轉換，以及套用符合性標準至輸出文件。

## **PowerPoint 轉 PDF 轉換**

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別，然後使用 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) 方法將簡報另存為 PDF。 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別公開了 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) 方法，通常用於將簡報轉換為 PDF。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java 會將其 API 資訊與版本號插入輸出文件。例如，在將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」形式的值。**注意**，您無法指示 Aspose.Slides 更改或移除這些資訊。
{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整個簡報轉換為 PDF
* 從簡報中選擇特定投影片轉換為 PDF

Aspose.Slides 將簡報匯出為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換過程中會精確呈現元素與屬性，包括：

* 影像
* 文字方塊和圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁腳
* 項目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 至 PDF 轉換程序使用預設選項。此情況下，Aspose.Slides 會嘗試以最佳設定與最高品質層級將提供的簡報轉換為 PDF。

以下範例載入簡報，並使用預設匯出設定將所有可見投影片儲存為 PDF。

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
Aspose 提供免費的線上 [**PowerPoint to PDF 轉換器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，示範簡報轉 PDF 的轉換流程。您可以使用此轉換器執行測試，以即時體驗此處所述的步驟。
{{% /alert %}}

## **使用選項將 PowerPoint 轉換為 PDF**

Aspose.Slides 提供自訂選項—位於 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 類別下的屬性—讓您客製化最終的 PDF、以密碼鎖定 PDF，或指定轉換流程的執行方式。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

使用自訂轉換選項，您可以定義點陣圖影像的首選品質設定、指定如何處理中繼檔案、設定文字的壓縮等級、配置影像 DPI，等等。

以下範例將簡報匯出為 PDF 1.5，JPEG 品質設定為 90，影像解析度設定為 300 DPI，中繼檔案儲存為 PNG，並使用 Flate 文字壓縮。

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

### **自動選取影像壓縮**

當簡報包含大量照片或螢幕擷圖時，縮小匯出 PDF 的大小可使其更易於透過電子郵件或下載。於 PDF 匯出時，將 `true` 傳入 [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) 以自動為每張影像選擇最適合的壓縮演算法。

以下範例載入現有簡報，啟用自動影像壓縮選擇，並將其儲存為 PDF 文件。所有其他 PDF 匯出設定皆保留預設值。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

此選項會為每張影像選擇壓縮演算法。降低傳遞給 [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) 的值會降低 JPEG 影像品質，而降低傳遞給 [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) 的值則允許影像降採樣至較低解析度，可能減少細節。啟用自動壓縮選擇本身不會降低上述任一設定。

選擇影像壓縮演算法會需要額外的處理時間與記憶體。大小縮減取決於簡報的影像與匯出設定；無法保證每份簡報皆能達到固定的縮減比例。

### **將嵌入的 OLE 檔案保留為 PDF 附件**

如果簡報中嵌入了 Excel 活頁簿，您可能希望 PDF 收件者能同時取得該活頁簿的資料並檢視投影片。將 `true` 傳入 [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 以將嵌入的 OLE 檔案保留為產生的 PDF 附件。

預設值為 `false`：OLE 物件的預覽圖像或圖示會在 PDF 頁面上呈現，但其嵌入檔案不會以附件形式包含。將此選項設為 `true` 會額外包含檔案資料。預覽僅保留為視覺呈現；附件則允許收件者單獨開啟或儲存嵌入檔案。OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

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

要檢查結果：

1. 在支援檔案附件的檢視器（例如 Adobe Acrobat Reader）中開啟匯出的 PDF。
2. 開啟檢視器的 **附件** 面板，定位嵌入的活頁簿。
3. 將附件儲存並於 Excel 中開啟以檢查其資料，或若檢視器允許直接開啟則直接開啟。PDF 頁面的預覽與附件分離。

{{% alert color="info" title="Note" %}}
PDF/A 標準對附件施加限制：PDF/A-1禁止嵌入檔案，PDF/A-2僅允許 PDF/A 附件，而 PDF/A-3則允許其他檔案類型，包括 Excel 活頁簿。這些是標準的要求，並非 Aspose.Slides 的特定限制。本範例使用預設的 PDF 合規設定，未示範 PDF/A 匯出。
{{% /alert %}}

### **將包含隱藏投影片的 PowerPoint 轉換為 PDF**

如果簡報包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 類別中的 [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) 方法，將隱藏投影片納入產生的 PDF 頁面中。

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

以下範例將簡報匯出為需要密碼 `password` 才能開啟的 PDF。存取權限允許列印，包括高品質列印。

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

### **偵測字型取代**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 類別下提供 [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) 方法，使您能在簡報轉 PDF 的過程中偵測字型取代。

以下範例將簡報匯出為 PDF，並在主控台印出字型取代警告。僅在匯出時替換了不可用字型時才會印出警告。

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
欲取得關於字型取代的更多資訊，請參閱 [Font Substitution](/slides/zh-hant/nodejs-java/font-substitution/) 文章。
{{% /alert %}}

### **處理沒有專屬粗體字型的字體**

即使字型沒有專屬粗體字形，簡報仍可對文字套用粗體格式。文字會透過合成粗體（synthetic bolding）以人工增厚常規字型來顯示粗體效果。若此文字在 PDF 中顯得過於粗重或與預期外觀不同，請嘗試將 `true` 傳入 [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)。此選項會在 PDF 匯出時將受影響的文字以點陣圖形式呈現，對某些字型可改善其外觀。預設值為 `false`。

範例簡報包含兩個文字方塊：一個為普通文字，另一個對同一字型（無專屬粗體）套用粗體格式。以下範例載入此簡報，啟用不支援的字型樣式點陣化，並將其匯出為 PDF：

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

以下預覽顯示停用與啟用選項的輸出。此範例中，停用時粗體文字筆畫較粗；啟用後筆畫較細，普通文字保持不變。請在為您的簡報選擇設定前比較兩者結果。

| 停用選項 (`false`，預設) | 啟用選項 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在此範例中，啟用此選項會僅將粗體文字轉為點陣圖：該文字無法在未使用 OCR 的情況下被選取、複製或搜尋，且在 800% 放大時邊緣較為柔和。普通文字仍可搜尋。停用此選項時，兩段文字皆保持為文字。

此選項會在字型沒有專屬粗體字形時，將粗體格式的文字點陣化。[Font substitution](/slides/zh-hant/nodejs-java/font-substitution/) 則會在原始字型不可用時選擇其他字型。

## **從 PowerPoint 轉換選取的投影片為 PDF**

以下範例將簡報的第 1 與第 3 張投影片匯出為 PDF。此陣列中的投影片編號為從 1 起算，且輸入的簡報必須至少包含三張投影片。

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

以下範例將簡報的第一張投影片複製至新簡報，並設定投影片尺寸為 612 × 792 點（8.5 × 11 吋）。它會縮放投影片內容以適應尺寸，並將單一投影片匯出為 PDF。

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

    // 移除新簡報建立時的空白投影片。
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **在備註投影片檢視中將 PowerPoint 轉換為 PDF**

以下範例將簡報匯出為 PDF，將每張投影片的講者備註置於投影片下方。請使用包含講者備註的簡報以檢視結果。

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

## **PDF 的無障礙與合規標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以使用以下任一合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下程式碼示範根據不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 轉換流程：

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
Aspose.Slides 支援 PDF 轉換操作，允許您將 PDF 檔案轉換為常見檔案格式。您可以執行 [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/)、[PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/)、以及 [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) 轉換。另外，也支援將 PDF 轉換為特定格式——[PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)。
{{% /alert %}}

> **注意：** 在匯出為 PDF/UA 時，Aspose.Slides 會將複雜圖形（如 SmartArt、圖表與公式）視為單一圖形。個別路徑元素不會保留為獨立內容，可能被標記為雜訊；僅為整體圖形提供替代文字。

## **常見問題**

**我可以一次批次將多個 PowerPoint 檔案轉換為 PDF 嗎？**  
是的，Aspose.Slides 支援將多個 PPT 或 PPTX 檔案批次轉換為 PDF。您可以遍歷檔案，並以程式方式套用轉換程序。

**是否可以為轉換後的 PDF 設定密碼保護？**  
是的。使用 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 類別在轉換過程中設定密碼並定義存取權限。

**如何在 PDF 中包含隱藏投影片？**  
在 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 類別中將 `true` 傳入 [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/)，即可在產生的 PDF 中包含隱藏投影片。

**Aspose.Slides 能否在 PDF 中保持高影像品質？**  
是的，您可以使用 [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/)、[setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) 等方法在 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 類別中控制影像品質，以確保 PDF 中的影像保持高品質。

**Aspose.Slides 是否支援 PDF/A 合規標準？**  
是的，Aspose.Slides 允許您匯出符合[各種標準](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A1a、PDF/A1b 與 PDF/UA，確保您的文件符合無障礙與保存需求。

## **其他資源**

- [Aspose.Slides for Node.js via Java 文件](/slides/zh-hant/nodejs-java/)
- [Aspose.Slides for Node.js via Java API 參考](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/conversion)