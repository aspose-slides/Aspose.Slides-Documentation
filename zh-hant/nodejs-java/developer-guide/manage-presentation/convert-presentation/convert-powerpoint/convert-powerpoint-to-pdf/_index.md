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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js，將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速程式範例與進階轉換選項。"
---
## **概述**

在 JavaScript 中將 PowerPoint 與 OpenDocument 簡報（PPT、PPTX、ODP 等）轉換為 PDF 格式具有多項優勢，包括在不同裝置上的相容性以及保留簡報的版面配置和格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、對 PDF 檔案設定密碼保護、偵測字型替換、選擇特定投影片進行轉換，並將合規標準套用到輸出文件。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別，然後使用 `save` 方法將簡報另存為 PDF。[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別提供 `save` 方法，通常用於將簡報轉換為 PDF。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for Node.js via Java 會將其 API 資訊與版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」的形式。**注意**，您無法指示 Aspose.Slides 更改或移除這些資訊。

{{% /alert %}}

Aspose.Slides 允許您進行以下轉換：

* 整個簡報轉換為 PDF
* 特定投影片從簡報轉換為 PDF

Aspose.Slides 將簡報匯出為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換過程中會精確呈現以下元素與屬性，包括：

* 圖片
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 項目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換程序使用預設選項。在此情況下，Aspose.Slides 會嘗試以最佳設定及最高品質將提供的簡報轉換為 PDF。

以下程式碼示範如何將簡報（PPT、PPTX、ODP 等）轉換為 PDF：

```js
// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // 將簡報儲存為 PDF。
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose 提供免費的線上 [**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pdf)，示範簡報轉 PDF 的轉換流程。您可以使用此轉換器進行測試，以實作此處所述的程序。

{{% /alert %}}

## **使用選項將 PowerPoint 轉換為 PDF**

Aspose.Slides 提供自訂選項——位於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pdfoptions/) 類別下的屬性，讓您能自訂產生的 PDF、以密碼鎖定 PDF，或指定轉換流程的執行方式。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

透過自訂轉換選項，您可以定義光柵圖像的品質設定、指定中繪圖檔的處理方式、設定文字的壓縮等級、配置圖像的 DPI，等等。

以下程式碼範例示範如何使用多項自訂選項將 PowerPoint 簡報轉換為 PDF。

```js
// 建立 PdfOptions 類別的實例。
let pdfOptions = new aspose.slides.PdfOptions();

// 設定 JPG 圖片的品質。
pdfOptions.setJpegQuality(java.newByte(90));

// 設定圖像的 DPI。
pdfOptions.setSufficientResolution(300);

// 設定中繪檔的行為。
pdfOptions.setSaveMetafilesAsPng(true);

// 設定文字內容的壓縮等級。
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// 定義 PDF 合規模式。
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // 將簡報儲存為 PDF 文件。
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **使用隱藏投影片將 PowerPoint 轉換為 PDF**

如果簡報包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PdfOptions) 類別中的 [setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) 方法，將隱藏投影片納入產生的 PDF 之頁面中。

以下 JavaScript 程式碼示範如何在轉換為 PDF 時包含隱藏投影片：

```js
// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // 建立 PdfOptions 類別的實例。
    let pdfOptions = new aspose.slides.PdfOptions();

    // 加入隱藏投影片。
    pdfOptions.setShowHiddenSlides(true);

    // 將簡報儲存為 PDF。
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **將 PowerPoint 轉換為受密碼保護的 PDF**

以下 JavaScript 程式碼示範如何使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PdfOptions) 類別的保護參數，將 PowerPoint 簡報轉換為受密碼保護的 PDF：

```js
// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // 建立 PdfOptions 類別的實例。
    let pdfOptions = new aspose.slides.PdfOptions();

    // 設定 PDF 密碼與存取權限。
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // 將簡報儲存為 PDF。
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **偵測字型替換**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PdfOptions) 類別下提供 [setWarningCallback](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) 方法，使您能在簡報轉 PDF 的過程中偵測字型替換。

以下 JavaScript 程式碼示範如何偵測字型替換：

```js
// 在 PDF 選項中設定警告回呼。
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
let presentation = new aspose.slides.Presentation("sample.pptx");

// 將簡報儲存為 PDF。
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 

欲取得關於字型替換的更多資訊，請參閱 [字型替換](/slides/zh-hant/nodejs-java/font-substitution/) 文章。

{{% /alert %}} 

## **將 PowerPoint 中選取的投影片轉換為 PDF**

以下 JavaScript 程式碼示範如何僅將 PowerPoint 簡報中的特定投影片轉換為 PDF：

```js
// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // 設定投影片編號陣列。
    let slides = java.newArray("int", [1, 3]);

    // 將簡報儲存為 PDF。
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **使用自訂投影片大小將 PowerPoint 轉換為 PDF**

以下 JavaScript 程式碼示範如何使用指定的投影片大小將 PowerPoint 簡報轉換為 PDF：

```js
const slideWidth = 612;
const slideHeight = 792;

// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// 建立具有調整後投影片尺寸的新簡報。
let resizedPresentation = new aspose.slides.Presentation();

try {
    // 設定自訂投影片尺寸。
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // 從原始簡報複製第一張投影片。
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 將調整大小的簡報儲存為含備註的 PDF。
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **在備註投影片檢視中將 PowerPoint 轉換為 PDF**

以下 JavaScript 程式碼示範如何將 PowerPoint 簡報轉換為包含備註的 PDF：

```js
// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // 以附註版面配置設定 PDF 選項。
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // 將簡報儲存為含備註的 PDF。
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF 的可及性與合規標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以使用以下任一合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 以及 **PDF/UA**。

以下 JavaScript 程式碼示範依不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 轉換流程：

```js
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

{{% alert title="注意" color="warning" %}} 

Aspose.Slides 支援 PDF 轉換作業，可將 PDF 檔案轉換為常用的檔案格式。您可以執行 [PDF 轉 HTML](https://products.aspose.com/slides/zh-hant/nodejs-java/conversion/pdf-to-html/)、[PDF 轉 JPG](https://products.aspose.com/slides/zh-hant/nodejs-java/conversion/pdf-to-jpg/)、以及 [PDF 轉 PNG](https://products.aspose.com/slides/zh-hant/nodejs-java/conversion/pdf-to-png/) 轉換。其他針對特殊格式的 PDF 轉換作業 —— 如 [PDF 轉 SVG](https://products.aspose.com/slides/zh-hant/nodejs-java/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/zh-hant/nodejs-java/conversion/pdf-to-tiff/) —— 亦受到支援。

{{% /alert %}}

> **注意:** 匯出為 PDF/UA 時，Aspose.Slides 會將諸如 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能會被標記為雜訊；替代文字僅提供給整個圖形。

## **常見問題**

**我可以批次將多個 PowerPoint 檔案轉換為 PDF 嗎？**

是的，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以以程式方式遍歷檔案並套用轉換程序。

**是否可以為轉換後的 PDF 設定密碼保護？**

絕對可以。使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PdfOptions) 類別在轉換過程中設定密碼並定義存取權限。

**如何在 PDF 中包含隱藏投影片？**

使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PdfOptions) 類別的 `setShowHiddenSlides` 方法，即可將隱藏投影片納入產生的 PDF。

**Aspose.Slides 能在 PDF 中保持高影像品質嗎？**

可以，您可以透過使用 `setJpegQuality` 與 `setSufficientResolution` 等方法於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PdfOptions) 類別中，確保 PDF 中的影像保持高品質。

**Aspose.Slides 支援 PDF/A 合規標準嗎？**

是的，Aspose.Slides 允許您匯出符合各種標準的 PDF，包括 PDF/A1a、PDF/A1b 以及 PDF/UA，確保文件符合可及性與存檔需求。

## **其他資源**

- [Aspose.Slides for Node.js via Java 文件說明](/slides/zh-hant/nodejs-java/)
- [Aspose.Slides for Node.js via Java API 參考](https://reference.aspose.com/slides/zh-hant/nodejs-java/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/zh-hant/conversion)