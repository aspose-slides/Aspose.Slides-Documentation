---
title: 在 JavaScript 中將簡報投影片轉換為圖像
linktitle: 投影片轉圖像
type: docs
weight: 35
url: /zh-hant/nodejs-java/convert-slide/
keywords:
- 轉換投影片
- 匯出投影片
- 投影片轉圖像
- 將投影片儲存為圖像
- 投影片轉 EMF
- 投影片轉 PNG
- 投影片轉 JPEG
- 投影片轉位圖
- 投影片轉 TIFF
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中將 PPT、PPTX 和 ODP 簡報的投影片轉換為 PNG、JPEG、GIF、TIFF、EMF 以及其他圖像格式。"
---
## **簡介**

Aspose.Slides for Node.js via Java 可以將 PowerPoint 與 OpenDocument 簡報的單一投影片渲染為 PNG、JPEG、GIF、TIFF 以及其他影像格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別載入簡報。
2. 選取您想要渲染的投影片。
3. 如有需要，可使用 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/) 類別設定渲染。
4. 呼叫 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getImage) 方法。它會傳回一個 [IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 物件。
5. 呼叫 [IImage.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/#save) 方法，並使用 [ImageFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imageformat/) 的值指定輸出格式。

## **將投影片轉換為 PNG 影像**

最簡單的轉換使用預設的渲染設定。產生的 [IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 物件可在記憶體中處理或儲存為檔案。

以下 JavaScript 範例會渲染第一張投影片，並將其儲存為 PNG 影像：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **以自訂尺寸將投影片轉換為影像**

使用接受 `java.awt.Dimension` 參數的 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getImage) 多載，以使用精確的像素尺寸渲染投影片。

以下範例會建立 1820 × 1040 的 JPEG 影像：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **將含備註與評論的投影片轉換為影像**

預設情況下，投影片影像不會包含備註或評論。可將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notescommentslayoutingoptions/) 物件傳遞給 [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) 方法，以控制備註與評論的顯示位置。

以下範例會將截斷的備註放在投影片下方，並將評論放在右側：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
在投影片轉影像的過程中，請勿傳遞 [BottomFull](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notespositions/) 給 [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 方法。備註的文字可能超過固定影像大小的容納範圍。請改用 [BottomTruncated](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notespositions/)。
{{% /alert %}}

## **使用 TIFF 選項將投影片轉換為影像**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/) 類別可讓您控制渲染後 TIFF 影像的尺寸、解析度以及其他屬性。

以下範例會將第一張投影片渲染為 2160 × 2880、300 DPI 的 TIFF 影像：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
在 JDK 9 之前的 Java 版本中，無法保證支援 TIFF。
{{% /alert %}}

## **將所有投影片轉換為影像**

遍歷投影片集合，將整個簡報轉換為一系列影像。除非明確跳過，否則隱藏投影片也會被包含在內。

以下範例會將每張投影片以水平與垂直倍率 2 渲染為 JPEG 影像：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **產生增強型圖形檔（EMF）輸出**

增強型圖形檔 (EMF) 在需要與 Microsoft Office 或其他支援 Windows 圖形檔的 Windows 應用程式交換向量圖形時很有用。與像素影像不同，EMF 能保留向量繪圖操作，縮放時不會失去銳利度。然而，EMF 主要是一種供具備 Windows 圖形檔支援的應用程式使用的相容格式，並非通用的交換格式。此外，複雜的投影片內容，如點陣圖和某些效果，可能會以光柵化元素儲存在向量圖形檔容器中。

### **將投影片匯出為 EMF**

[Slide.writeAsEmf](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#writeAsEmf) 方法會以 EMF 格式將投影片寫入目標串流。以下範例載入簡報，選取第一張投影片，並將其寫入 EMF 檔案串流：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

呼叫端擁有傳遞給 [Slide.writeAsEmf](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#writeAsEmf) 的串流，並負責依照上例關閉該串流。

### **將 SVG 影像轉換為 EMF 並加入簡報**

使用 [SvgImage.writeAsEmf](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/#writeAsEmf) 可將 SVG 內容轉換為 EMF。產生的位元組可透過 [ImageCollection.addImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagecollection/#addImage) 加入簡報，並使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) 放置於投影片上。

以下範例會從 SVG 標記建立 [SvgImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/)，將其轉換為記憶體中的 EMF，將該圖形檔插入第一張投影片，並儲存簡報：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgimage/#writeAsEmf) 不會取得目的地串流的所有權。`java.io.ByteArrayOutputStream` 會在記憶體中儲存所有產生的資料，因而在呼叫 `toByteArray` 前不需要重設位置。即使串流已關閉，回傳的位元組陣列仍然有效。

EMF 產生功能在所選擇的 Aspose.Slides for Node.js via Java 與 JDK 設定所支援的作業系統上皆可使用，但若缺少字型或圖形相依項，跨平台的渲染結果可能會有所差異。請安裝來源內容所使用的字型或設定適當的替代字型，並遵循 Aspose.Slides for Node.js via Java 的 [平台需求](/slides/zh-hant/nodejs-java/system-requirements/)，以驗證在目標 EMF 使用應用程式中的結果。Linux 與 macOS 應用程式通常對顯示與編輯 Windows 圖形檔的支援有限或不一致。

## **彩色表情符號渲染**

{{% alert title="Note" color="info" %}}
在將簡報投影片轉換為影像時，如欲正確呈現彩色表情符號，必須在執行轉換的系統上安裝簡報中使用的表情符號字型。例如，若簡報使用 **Segoe UI Emoji**，但系統缺少該字型，則輸出影像中的表情符號可能會以單色顯示。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援渲染含動畫的投影片？**

不支援。[Slide.getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getImage) 方法會渲染投影片的靜態影像，且不會匯出動畫。

**隱藏的投影片可以匯出為影像嗎？**

可以。隱藏投影片可像一般投影片一樣渲染。只要在處理迴圈中包含它們，如上例所示。

**投影片影像會保留陰影和其他效果嗎？**

會。Aspose.Slides 會在投影片影像中呈現陰影、透明度以及其他支援的圖形效果。