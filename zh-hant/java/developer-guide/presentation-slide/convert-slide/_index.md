---
title: 在 Java 中將簡報投影片轉換為圖像
linktitle: 投影片轉圖像
type: docs
weight: 35
url: /zh-hant/java/convert-slide/
keywords:
- 轉換投影片
- 匯出投影片
- 投影片轉圖像
- 將投影片另存為圖像
- 投影片轉 PNG
- 投影片轉 JPEG
- 投影片轉點陣圖
- 投影片轉 TIFF
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中將 PPT、PPTX 和 ODP 投影片轉換為圖像——快速、高品質的渲染，並提供清晰的程式碼範例。"
---
## **簡介**

Aspose.Slides for Java 讓您輕鬆將 PowerPoint 與 OpenDocument 簡報投影片轉換為各種圖像格式，包括 BMP、PNG、JPG（JPEG）、GIF 等等。

要將投影片轉換為圖像，請依照以下步驟：

1. 定義所需的轉換設定，並使用下列介面選取要匯出的投影片：
    - [ITiffOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiffoptions/) 介面，或
    - [IRenderingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/irenderingoptions/) 介面。
2. 呼叫 [getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) 方法產生投影片圖像。

在 Aspose.Slides for Java 中，[IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 是一個介面，允許您操作由像素資料定義的圖像。您可以使用此介面將圖像儲存為多種格式（BMP、JPG、PNG 等）。

## **將投影片轉換為點陣圖並以 PNG 儲存圖像**

您可以將投影片轉換為點陣圖物件，直接在應用程式中使用。或者，您也可以先將投影片轉換為點陣圖，然後以 JPEG 或其他喜好的格式儲存圖像。

以下程式碼示範如何將簡報的第一張投影片轉換為點陣圖物件，並以 PNG 格式儲存圖像：

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 將簡報中的第一張投影片轉換為點陣圖。
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // 以 PNG 格式儲存圖像。
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **使用自訂尺寸將投影片轉換為圖像**

您可能需要取得特定尺寸的圖像。使用 [getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) 的重載，您可以將投影片轉換為具有指定寬度與高度的圖像。

以下範例程式碼示範如何做到這一點：

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 將簡報中的第一張投影片以指定尺寸轉換為點陣圖。
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // 以 JPEG 格式儲存圖像。
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **將含有備註與評論的投影片轉換為圖像**

有些投影片可能包含備註與評論。

Aspose.Slides 提供兩個介面——[ITiffOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiffoptions/) 與 [IRenderingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/irenderingoptions/)——讓您控制簡報投影片轉換為圖像的方式。這兩個介面皆包含 `setSlidesLayoutOptions` 方法，可在將投影片轉換為圖像時設定備註與評論的呈現方式。

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/notescommentslayoutingoptions/) 類別，您可以指定備註與評論在最終圖像中的首選位置。

以下程式碼示範如何將含有備註與評論的投影片轉換為圖像：

```java 
float scaleX = 2;
float scaleY = scaleX;

// 載入簡報檔案。
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // 設定備註的位置。
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // 設定評論的位置。
    notesCommentsOptions.setCommentsAreaWidth(500);                         // 設定評論區的寬度。
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // 設定評論區的顏色。

    // 建立呈現選項。
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // 將簡報的第一張投影片轉換為圖像。
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // 以 GIF 格式儲存圖像。
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

在任何投影片轉圖像的過程中，`setNotesPosition` 方法無法套用 `BottomFull`（用於指定備註位置），因為備註文字可能過長，導致無法在指定的圖像尺寸內完整呈現。

{{% /alert %}} 

## **使用 TIFF 選項將投影片轉換為圖像**

[ITiffOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiffoptions/) 介面提供更高的控制度，允許您在產生 TIFF 圖像時指定大小、解析度、色彩調色盤等參數。

以下程式碼示範使用 TIFF 選項輸出 300 DPI、尺寸為 2160 × 2800 的黑白圖像的轉換流程：

```java 
// 載入簡報檔案。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 從簡報中取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 設定輸出 TIFF 圖像的參數。
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // 設定圖像尺寸。
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // 設定像素格式（黑白）。
    tiffOptions.setDpiX(300);                                        // 設定水平解析度。
    tiffOptions.setDpiY(300);                                        // 設定垂直解析度。

    // 使用指定的選項將投影片轉換為圖像。
    IImage image = slide.getImage(tiffOptions);

    try {
        // 以 TIFF 格式儲存圖像。
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

在 JDK 9 以前的版本中不保證支援 TIFF。

{{% /alert %}} 

## **將所有投影片轉換為圖像**

Aspose.Slides 允許您將簡報中的所有投影片轉換為圖像，等同於將整個簡報轉換為一系列圖像。

以下範例程式碼示範如何在 Java 中將簡報的所有投影片轉換為圖像：

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 將簡報逐張投影片渲染為圖像。
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // 控制隱藏投影片（不渲染隱藏的投影片）。
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // 將投影片轉換為圖像。
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // 以 JPEG 格式儲存圖像。
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
} 
```

## **彩色表情符號渲染**

{{% alert title="Note" color="warning" %}} 
在將簡報投影片轉換為圖像時正確渲染彩色表情符號，必須在執行轉換的系統上安裝並可使用簡報中使用的表情符號字型。例如，若簡報使用 **Segoe UI Emoji**，但系統缺少此字型，則輸出圖像中的表情符號可能會以單色顯示。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援渲染帶有動畫的投影片？**

不支援，`getImage` 方法僅儲存投影片的靜態圖像，不包含動畫。

**是否可以將隱藏的投影片匯出為圖像？**

可以，隱藏的投影片可與一般投影片同樣處理，只需確保它們包含在處理迴圈中。

**圖像儲存時可以包含陰影與效果嗎？**

可以，Aspose.Slides 在將投影片儲存為圖像時支援渲染陰影、透明度及其他圖形效果。