---
title: 在 JavaScript 中變更備註頁尺寸與方向
linktitle: 備註頁尺寸
type: docs
weight: 10
url: /zh-hant/nodejs-java/notes-size/
keywords:
- 備註頁尺寸
- 備註方向
- 橫向備註
- 直向備註
- 講義尺寸
- PowerPoint
- 簡報
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js（透過 Java）中讀取與變更備註頁尺寸，切換方向，驗證已儲存的尺寸，並將備註或講義匯出為 PDF 與影像。"
---
## **概述**

使用 [Presentation.getNotesSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getnotessize/) 來存取簡報的備註頁設定。它會傳回一個 [NotesSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notessize/) 物件，其 [setSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notessize/setsize/) 方法可設定頁面的尺寸。雖然設定物件本身無法被取代，但您可以透過此方法指派新的尺寸。

寬度與高度使用 **點數** (points) 指定，每英寸 72 點。例如，900 × 600 點等於 12.5 × 8⅓ 英吋。這些設定套用於整個簡報，而非單一投影片的備註。

| 設定 | 目的 |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getnotessize/) | 控制備註頁尺寸與匯出講義時使用的頁面尺寸。 |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getslidesize/) | 透過 [SlideSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesize/) 控制一般簡報投影片的尺寸。 |

變更任一設定不會自動影響另一個設定。變更備註頁的方向也不會旋轉一般投影片。請參閱 [Slide Size](/slides/zh-hant/nodejs-java/slide-size/) 以調整一般投影片的尺寸。

以下範例使用現有的 `sample.pptx`。對於匯出範例，請使用至少包含一張含有講者備註的投影片的簡報。每個範例皆可獨立執行。

## **閱讀備註頁尺寸與方向**

讀取寬度與高度並比較以判斷方向：較寬的頁面為橫向，較高的頁面為直向，尺寸相等則為方形頁面。此範例會以點數印出實際尺寸，且不假設標準紙張大小。

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **切換為橫向而不變更紙張大小**

若僅要變更方向，只需交換現有的寬度與高度。此作法可保留兩側的長度，包括自訂紙張大小的長度。下方的條件會避免已為橫向的頁面被切換回直向，並且對方形頁面不做變更。

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

對於直向方向，當 `size.getWidth() > size.getHeight()` 時使用相同的指派方式。除非您也想變更紙張大小，否則不要以 A4 或 Letter 尺寸取代。

## **設定與驗證自訂備註頁尺寸**

同時指派兩個尺寸，然後使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/save/) 來寫入簡報。此範例設定 900 × 600 點的橫向頁面，將其儲存為 PPTX，並再次開啟已儲存的檔案以檢查持續的值。比較允許 0.01 點的浮點容差；此容差並不保證所有檔案格式皆具精確度。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

預期結果為 `900 x 600 points` 與 `Size preserved: true`。檢查新開啟的簡報可驗證已儲存的檔案，而非僅檢查記憶體中的設定。

## **匯出備註與講義**

頁面尺寸定義備註或講義版面的可用區域。它們本身不會自行啟用這些版面配置：仍需設定匯出選項。一般投影片的匯出仍然使用投影片尺寸。

### **匯出備註至 PDF 與 PNG**

將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notescommentslayoutingoptions/) 指派給 [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 以在 PDF 中包含備註。此範例亦使用 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getImage) 和 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/renderingoptions/) 將第一張含備註的投影片渲染為 PNG。

[BottomTruncated](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notespositions/) 模式會將備註保留在單一頁面；無法容納的備註會被截斷。PDF 使用 900 × 600 點的頁面。以下使用的 1 × 1 影像比例下，PNG 為 900 × 600 像素。點數描述頁面幾何；像素則描述光柵輸出，其尺寸亦受渲染比例影響。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

對於含有長備註的 PDF 匯出，使用 [BottomFull](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notespositions/) 可視需要新增頁面。請勿在上述單投影片影像呼叫中使用此模式，因為它不支援。調整大小後，檢查輸出是否有被截斷的備註以及現有 notes‑master 物件的放置；僅變更頁面尺寸並不保證所有內容都能容納。更多備註匯出資訊請參閱 [Convert PowerPoint to PDF with Notes](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf-with-notes/)。

### **匯出講義至 PDF**

使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/handoutlayoutingoptions/) 於單一頁面上放置多張投影片縮圖。以下範例設定 900 × 600 點的頁面，並使用 [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/handouttype/) 以每頁最多排列四張投影片的方式。水平預設會控制投影片排序；頁面方向則取決於其寬度與高度。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

變更頁面大小會調整講義格線的可用區域，但不會變更來源投影片的尺寸。要取得講義影像，請使用帶有講義版面的 [Presentation.getImages](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getimages/)，而非單一投影片的影像方法。在 Aspose.Slides 中，簡報層級的講義渲染會使用備註頁尺寸，而單一投影片的影像呼叫不會產生講義頁面。更多版面配置請參閱 [Handout Mode](/slides/zh-hant/nodejs-java/convert-powerpoint-in-handout-mode/)。

## **檢視器、匯出與列印時的頁面尺寸**

將儲存的簡報尺寸、匯出的頁面尺寸與列印的紙張尺寸分別保持不同：

- **Presentation viewers:** 觀賞器可以使用自己的版面規則顯示或列印備註。若其他應用程式儲存檔案，請重新開啟並再次檢查尺寸；該應用程式的格式轉換可能會將其正規化。
- **Export formats:** 上述備註與講義 PDF 範例使用已設定的頁面尺寸。光柵影像使用整數像素尺寸與渲染比例，因此小數點的點數值可能在影像輸出時被四捨五入。匯出一般投影片時不會套用備註頁尺寸。
- **Printer drivers:** 紙張選取、自動旋轉與縮放到頁面等設定可能會改變實體輸出，而不會變更儲存在簡報或 PDF 中的尺寸。若使用特定紙張大小，請對應列印機設定並檢查列印預覽。

## **FAQ**

**我可以只為單一投影片設定備註尺寸嗎？**

備註頁尺寸是簡報層級的設定。各投影片可以有不同的備註內容，但此屬性不會為每張投影片提供獨立的頁面尺寸。

**為什麼變更備註方向卻沒有影響投影片？**

備註頁與一般投影片的尺寸是相互獨立的。若想調整投影片本身的尺寸，請使用一般投影片的尺寸設定。

**為什麼我儲存或列印的結果尺寸不同？**

首先重新開啟已儲存的簡報並比較其備註尺寸。若尺寸已變更，請檢查是否在其他應用程式中儲存或轉換檔案時更改了頁面設定。若未變更，則檢查匯出版面、影像比例、觀賞器設定與列印機的紙張選取。