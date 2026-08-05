---
title: 在 Android 上將簡報投影片轉換為影像
linktitle: 投影片轉影像
type: docs
weight: 35
url: /zh-hant/androidjava/convert-slide/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 將 PPT、PPTX 與 ODP 簡報投影片轉換為影像——快速、高品質的渲染，並提供清晰的 Java 程式碼範例。"
---
## **簡介**

Aspose.Slides for Android via Java 使您能輕鬆將 PowerPoint 與 OpenDocument 簡報投影片轉換為多種影像格式，包括 BMP、PNG、JPG（JPEG）、GIF 等。

若要將投影片轉換為影像，請依循以下步驟：

1. 使用以下方式定義所需的轉換設定並選取要匯出的投影片：
    - 使用 [ITiffOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiffoptions/) 介面，或
    - 使用 [IRenderingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/irenderingoptions/) 介面。
2. 透過呼叫 [getImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#getImage--) 方法產生投影片影像。

在 Aspose.Slides for Android via Java 中，[IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 是一個介面，可讓您處理以像素資料定義的影像。您可以使用此介面將影像儲存為各種格式（BMP、JPG、PNG 等）。

## **將投影片轉換為位圖並以 PNG 儲存影像**

您可以將投影片轉換為位圖物件並直接在應用程式中使用。或者，您也可以先將投影片轉換為位圖，然後將影像儲存為 JPEG 或其他您偏好的格式。

以下程式碼示範如何將簡報的第一張投影片轉換為位圖物件，並以 PNG 格式儲存影像：

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 將簡報中的第一張投影片轉換為位圖。
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // 以 PNG 格式儲存影像。
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **將投影片轉換為自訂尺寸的影像**

您可能需要取得特定尺寸的影像。使用 [getImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) 的重載，您可以將投影片轉換為具有指定寬度與高度的影像。

以下範例程式碼示範如何操作：

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 將簡報中的第一張投影片以指定大小轉換為位圖。
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // 以 JPEG 格式儲存影像。
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **將含註解與備註的投影片轉換為影像**

某些投影片可能包含備註與評論。

Aspose.Slides 提供兩個介面——[ITiffOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiffoptions/) 和 [IRenderingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/irenderingoptions/)——讓您能控制簡報投影片轉換為影像的渲染方式。兩個介面皆包含 `setSlidesLayoutOptions` 方法，該方法可在將投影片轉換為影像時設定備註與評論的渲染方式。

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notescommentslayoutingoptions/) 類別，您可以指定備註與評論在最終影像中的顯示位置。

以下程式碼示範如何將含備註與評論的投影片轉換為影像：

```java 
float scaleX = 2;
float scaleY = scaleX;

// 載入簡報檔案。
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // 設定備註的位置。
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // 設定評論的位置。
    notesCommentsOptions.setCommentsAreaWidth(500);                         // 設定評論區域的寬度。
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // 設定評論區域的顏色。

    // 建立渲染選項。
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // 將簡報的第一張投影片轉換為影像。
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // 以 GIF 格式儲存影像。
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
在任何投影片轉影像的轉換過程中，[setNotesPosition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) 方法無法套用 `BottomFull`（指定備註位置），因為備註文字可能過長，導致無法適配於指定的影像大小。 
{{% /alert %}} 

## **使用 TIFF 選項將投影片轉換為影像**

[ITiffOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiffoptions/) 介面提供更細緻的控制，可讓您指定尺寸、解析度、色彩調色盤等參數，以自訂最終的 TIFF 影像。

以下程式碼示範使用 TIFF 選項將影像輸出為 300 DPI、尺寸為 2160 × 2800 的黑白圖像：

```java 
// 載入簡報檔案。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 從簡報中取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 設定輸出 TIFF 影像的參數。
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // 設定影像尺寸。
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // 設定像素格式（黑白）。
    tiffOptions.setDpiX(300);                                        // 設定水平解析度。
    tiffOptions.setDpiY(300);                                        // 設定垂直解析度。

    // 使用指定的選項將投影片轉換為影像。
    IImage image = slide.getImage(tiffOptions);

    try {
        // 以 TIFF 格式儲存影像。
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **將全部投影片轉換為影像**

Aspose.Slides 允許您將簡報中的所有投影片轉換為影像，等同於將整個簡報轉換為一系列影像。

以下範例程式碼示範如何在 Java 中將簡報的所有投影片轉換為影像：

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 將簡報逐張投影片渲染為影像。
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // 控制隱藏投影片（不渲染隱藏投影片）。
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // 將投影片轉換為影像。
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // 以 JPEG 格式儲存影像。
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
在將簡報投影片轉換為影像時，若要正確呈現彩色表情符號，必須在執行轉換的系統上安裝並可使用簡報中使用的表情符號字型。例如，若簡報使用 **Segoe UI Emoji** 且系統缺少此字型，表情符號可能會以單色方式顯示於輸出影像中。 
{{% /alert %}} 

## **常見問題**

**Aspose.Slides 是否支援渲染包含動畫的投影片？**  
不會，`getImage` 方法僅儲存投影片的靜態影像，不包含動畫。

**隱藏的投影片可以匯出為影像嗎？**  
可以，隱藏的投影片可像一般投影片一樣處理。只要確保它們包含在處理迴圈中即可。

**影像可否儲存陰影與效果？**  
可以，Aspose.Slides 支援在將投影片儲存為影像時渲染陰影、透明度與其他圖形效果。