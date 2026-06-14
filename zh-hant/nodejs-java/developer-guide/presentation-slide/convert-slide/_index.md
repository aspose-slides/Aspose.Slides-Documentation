---
title: 在 JavaScript 中將簡報投影片轉換為影像
linktitle: 投影片轉影像
type: docs
weight: 35
url: /zh-hant/nodejs-java/convert-slide/
keywords:
- 轉換投影片
- 匯出投影片
- 投影片轉影像
- 將投影片儲存為影像
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
description: "使用 Aspose.Slides for Node.js via Java 在 JavaScript 中將 PPT、PPTX 與 ODP 投影片轉換為影像 — 速度快、品質高，並提供清晰的程式碼範例。"
---
## **簡介**

Aspose.Slides for Node.js via Java 讓您輕鬆將 PowerPoint 與 OpenDocument 簡報投影片轉換為各種影像格式，包括 BMP、PNG、JPG（JPEG）、GIF 等。

若要將投影片轉換為影像，請依下列步驟操作：

1. 定義所需的轉換設定，並使用以下方式選取要匯出的投影片：
    - [TiffOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/) 類別，或
    - [RenderingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/renderingoptions/) 類別。
2. 呼叫 [getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getImage) 方法產生投影片影像。

在 Aspose.Slides for Node.js via Java 中，[IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 是一個允許您使用像素資料處理影像的類別。您可以使用此類別將影像儲存為多種格式（BMP、JPG、PNG 等）。

## **將投影片轉換為位圖並以 PNG 儲存影像**

您可以將投影片轉換為位圖物件並直接在應用程式中使用。或者，您也可以先將投影片轉換為位圖，然後將影像儲存為 JPEG 或其他首選格式。

以下 JavaScript 程式碼示範如何將簡報的第一張投影片轉換為位圖物件，並以 PNG 格式儲存影像：

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 將簡報的第一張投影片轉換為位圖。
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // 以 PNG 格式儲存影像。
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **將投影片轉換為自訂尺寸的影像**

您可能需要取得特定尺寸的影像。透過 [getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getImage) 的重載，您可以將投影片轉換為具有指定寬度與高度的影像。

以下範例程式碼說明如何執行此操作：

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 將簡報的第一張投影片以指定尺寸轉換為位圖。
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // 以 JPEG 格式儲存影像。
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **將含註記與評論的投影片轉換為影像**

某些投影片可能包含註記與評論。

Aspose.Slides 提供兩個類別——[TiffOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/) 與 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/renderingoptions/)——讓您能夠控制將簡報投影片渲染為影像的行為。這兩個類別都包含 `setSlidesLayoutOptions` 方法，該方法可讓您在將投影片轉換為影像時，設定註記與評論的渲染方式。

透過 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notescommentslayoutingoptions/) 類別，您可以指定註記與評論在最終影像中的首選位置。

以下 JavaScript 程式碼示範如何轉換含有註記與評論的投影片：

```js
const scaleX = 2;
const scaleY = scaleX;

// Load a presentation file.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // 設定註記的位置。
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // 設定評論的位置。
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // 設定評論區域的寬度。
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // 設定評論區域的顏色。

    // 建立渲染選項。
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // 將簡報的第一張投影片轉換為影像。
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // 以 GIF 格式儲存影像。
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

在任何投影片轉影像的轉換過程中，[setNotesPosition](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 方法無法套用 `BottomFull`（指定註記位置），因為註記文字可能過長，導致無法在指定的影像尺寸內完整顯示。

{{% /alert %}} 

## **使用 TIFF 選項將投影片轉換為影像**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/) 類別允許您透過設定尺寸、解析度、色彩調色盤等參數，對最終的 TIFF 影像進行更精細的控制。

以下 JavaScript 程式碼示範如何使用 TIFF 選項輸出一張 300 DPI、尺寸為 2160 × 2800 的黑白影像：

```js
// 載入簡報檔案。
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // 取得簡報的第一張投影片。
    let slide = presentation.getSlides().get_Item(0);

    // 設定輸出 TIFF 影像的參數。
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // 設定影像尺寸。
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // 設定像素格式（黑白）。
    tiffOptions.setDpiX(300);                                                          // 設定水平解析度。
    tiffOptions.setDpiY(300);                                                          // 設定垂直解析度。

    // 使用指定的選項將投影片轉換為影像。
    let image = slide.getImage(tiffOptions);
    try {
        // 以 TIFF 格式儲存影像。
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

在 JDK 9 之前的版本不保證支援 TIFF。

{{% /alert %}} 

## **將全部投影片轉換為影像**

Aspose.Slides 允許您將簡報中的所有投影片轉換為影像，從而將整個簡報轉換為一系列影像。

以下範例程式碼示範如何在 JavaScript 中將簡報的所有投影片轉換為影像：

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 逐張投影片將簡報渲染為影像。
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // 控制隱藏投影片（不渲染隱藏的投影片）。
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // 將投影片轉換為影像。
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // 以 JPEG 格式儲存影像。
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Aspose.Slides 是否支援渲染具有動畫的投影片？**

不支援，`getImage` 方法僅儲存投影片的靜態影像，不包含動畫。

**隱藏的投影片可以匯出為影像嗎？**

可以，隱藏的投影片可像一般投影片一樣處理，只要確保它們被包含在處理迴圈中。

**影像可以儲存陰影和效果嗎？**

可以，Aspose.Slides 在將投影片儲存為影像時支援渲染陰影、透明度以及其他圖形效果。