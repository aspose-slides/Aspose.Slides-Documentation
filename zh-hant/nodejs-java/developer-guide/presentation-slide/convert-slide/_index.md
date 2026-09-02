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
description: "使用 Aspose.Slides for Node.js via Java 在 JavaScript 中將 PPT、PPTX 與 ODP 投影片轉換為影像 — 快速、高品質的渲染，並提供清晰的程式碼範例。"
---
## **簡介**

Aspose.Slides for Node.js via Java 讓您能輕鬆將 PowerPoint 與 OpenDocument 簡報投影片轉換為各種影像格式，包括 BMP、PNG、JPG（JPEG）、GIF 等。

若要將投影片轉換為影像，請依照以下步驟：

1. 定義所需的轉換設定，並使用以下方式選取要匯出的投影片：
    - 使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/) 類別，或
    - 使用 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/renderingoptions/) 類別。
2. 呼叫 [getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getImage) 方法產生投影片影像。

在 Aspose.Slides for Node.js via Java 中，[IImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/) 是一個允許您處理由像素資料定義之影像的類別。您可以使用此類別將影像儲存為多種格式（BMP、JPG、PNG 等）。

## **將投影片轉換為位圖並以 PNG 儲存影像**

您可以將投影片轉換為位圖物件，直接在應用程式中使用。或者，您也可以先將投影片轉換為位圖，然後以 JPEG 或其他您偏好的格式儲存影像。

以下 JavaScript 程式碼示範如何將簡報的第一張投影片轉換為位圖物件，並以 PNG 格式儲存影像：

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 將簡報中的第一張投影片轉換為位圖。
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

您可能需要取得特定尺寸的影像。使用 [getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getImage) 的重載，您可以將投影片轉換為具有特定寬度與高度的影像。

以下範例程式碼示範如何操作：

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 將簡報中的第一張投影片轉換為指定尺寸的位圖。
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

## **將包含備註與評論的投影片轉換為影像**

某些投影片可能包含備註與評論。

Aspose.Slides 提供兩個類別——[TiffOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/) 與 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/renderingoptions/)——讓您能控制簡報投影片轉換為影像的渲染方式。這兩個類別皆包含 `setSlidesLayoutOptions` 方法，您可透過它在將投影片轉換為影像時設定備註與評論的渲染方式。

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notescommentslayoutingoptions/) 類別，您可以指定備註與評論在最終影像中的首選位置。

以下 JavaScript 程式碼示範如何將包含備註與評論的投影片轉換：

```js
const scaleX = 2;
const scaleY = scaleX;

// Load a presentation file.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // 設定備註的位置。
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

{{% alert title="注意" color="warning" %}} 
在任何投影片轉影像的轉換過程中，[setNotesPosition](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 方法無法套用 `BottomFull`（指定備註的位置），因為備註文字可能過長，無法容納於指定的影像尺寸內。
{{% /alert %}} 

## **使用 TIFF 選項將投影片轉換為影像**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/) 類別透過允許您指定尺寸、解析度、色彩調色板等參數，提供對最終 TIFF 影像更精細的控制。

以下 JavaScript 程式碼示範使用 TIFF 選項輸出解析度 300 DPI、尺寸 2160 × 2800 的黑白影像的轉換流程：

```js
// 載入簡報檔案。
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // 從簡報取得第一張投影片。
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

{{% alert title="注意" color="warning" %}} 
在 JDK 9 之前的版本中，TIFF 支援並無法保證。
{{% /alert %}} 

## **將所有投影片轉換為影像**

Aspose.Slides 允許您將簡報中的所有投影片轉換為影像，等同於將整個簡報轉換成一系列影像。

以下範例程式碼示範如何在 JavaScript 中將簡報的所有投影片轉換為影像：

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 將簡報逐張投影片渲染為影像。
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

## **彩色表情符號渲染**

{{% alert title="注意" color="warning" %}} 
在將簡報投影片轉換為影像時，若要正確呈現彩色表情符號，簡報中使用的表情符號字型必須已安裝並在執行轉換的系統上可使用。例如，若簡報使用 **Segoe UI Emoji** 但系統缺少此字型，則輸出影像中的表情符號可能會以單色顯示。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援呈現帶有動畫的投影片？**

不會，`getImage` 方法僅儲存投影片的靜態影像，不包含動畫。

**隱藏的投影片可以匯出為影像嗎？**

可以，隱藏的投影片可與一般投影片一樣處理，只需確保在處理迴圈中包含它們。

**影像可以儲存陰影和效果嗎？**

可以，Aspose.Slides 在將投影片儲存為影像時支援渲染陰影、透明度及其他圖形效果。