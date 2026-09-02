---
title: 在 PHP 中將簡報投影片轉換為影像
linktitle: 投影片轉影像
type: docs
weight: 35
url: /zh-hant/php-java/convert-slide/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，將 PPT、PPTX 與 ODP 檔案的投影片轉換為影像 — 快速、高品質的渲染，並附有清晰的程式碼範例。"
---
## **簡介**

Aspose.Slides for PHP via Java 讓您能輕鬆將 PowerPoint 與 OpenDocument 簡報投影片轉換成各種影像格式，包括 BMP、PNG、JPG（JPEG）、GIF 等。

要將投影片轉換為影像，請遵循以下步驟：

1. 定義所需的轉換設定，並使用以下任一方式選取要匯出的投影片：
    - 使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/) 類別，或
    - 使用 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/renderingoptions/) 類別。
2. 呼叫 [getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getImage) 方法產生投影片影像。

在 Aspose.Slides for PHP via Java 中，[IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 是一個允許您處理以像素資料定義之影像的類別。您可以使用此類別將影像儲存為多種格式（BMP、JPG、PNG 等）。

## **將投影片轉換為位圖並以 PNG 儲存影像**

您可以將投影片轉換為位圖物件，並直接在應用程式中使用。或者，您也可以先將投影片轉換為位圖，然後將影像儲存為 JPEG 或其他您偏好的格式。

以下程式碼示範如何將簡報的第一張投影片轉換為位圖物件，並以 PNG 格式儲存影像：

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // 將簡報的第一張投影片轉換為位圖。
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // 以 PNG 格式儲存影像。
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **以自訂大小將投影片轉換為影像**

您可能需要取得特定尺寸的影像。使用 [getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getImage) 的重載，您可以將投影片轉換為具有指定寬度與高度的影像。

以下範例程式碼示範如何完成此操作：

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // 將簡報的第一張投影片以指定尺寸轉換為位圖。
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // 以 JPEG 格式儲存影像。
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **將含有註解與評論的投影片轉換為影像**

某些投影片可能包含註解與評論。

Aspose.Slides 提供兩個類別[TiffOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/)和[RenderingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/renderingoptions/)——可讓您控制簡報投影片轉換為影像的呈現方式。兩個類別皆包含 `setSlidesLayoutOptions` 方法，讓您在將投影片轉換為影像時，設定註解與評論的呈現方式。

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notescommentslayoutingoptions/) 類別，您可以指定在最終影像中註解與評論的首選位置。

以下程式碼示範如何將含有註解與評論的投影片轉換為影像：

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // 設定筆記的位置。
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // 設定註解的位置。
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // 設定註解區域的寬度。
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // 設定註解區域的顏色。

    // 建立渲染選項。
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // 將簡報的第一張投影片轉換為影像。
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // 以 GIF 格式儲存影像。
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 

在任何投影片轉影像的轉換過程中，[setNotesPosition](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 方法無法套用 `BottomFull`（指定註解位置），因為註解文字可能過長，導致無法在指定的影像大小內完整顯示。

{{% /alert %}} 

## **使用 TIFF 選項將投影片轉換為影像**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/) 類別允許您透過設定大小、解析度、色盤等參數，對最終的 TIFF 影像進行更精細的控制。

以下程式碼示範使用 TIFF 選項輸出解析度為 300 DPI、尺寸為 2160 × 2800 的黑白影像的轉換流程：

```php
// 載入簡報檔案。
$presentation = new Presentation("sample.pptx");
try {
    // 取得簡報的第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 設定輸出 TIFF 影像的參數。
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // 設定影像尺寸。
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // 設定像素格式（黑白）。
    $options->setDpiX(300);                                              // 設定水平解析度。
    $options->setDpiY(300);                                              // 設定垂直解析度。
    
    // 使用指定的選項將投影片轉換為影像。
    $image = $slide->getImage($options);
    try {
        // 以 TIFF 格式儲存影像。
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 

在 JDK 9 之前的版本中，並不保證支援 TIFF。

{{% /alert %}} 

## **將所有投影片轉換為影像**

Aspose.Slides 允許您將簡報中的所有投影片全部轉換為影像，等同於將整個簡報轉換為一系列影像檔案。

以下範例程式碼示範如何在 PHP 中將簡報的所有投影片轉換為影像：

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // 將簡報逐張投影片渲染為影像。
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // 控制隱藏投影片（不渲染隱藏的投影片）。
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // 將投影片轉換為影像。
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // 以 JPEG 格式儲存影像。
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **彩色表情符號呈現**

{{% alert title="Note" color="warning" %}} 
在將簡報投影片轉換為影像時，若要正確呈現彩色表情符號，必須在執行轉換的系統上安裝並可使用簡報中使用的表情符號字型。例如，簡報使用 **Segoe UI Emoji** 而系統缺少此字型，則輸出的影像可能只能以單色方式顯示表情符號。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援渲染含有動畫的投影片？**

不支援，`getImage` 方法僅儲存投影片的靜態影像，不會包含動畫。

**隱藏的投影片可以匯出為影像嗎？**

可以，隱藏的投影片可與一般投影片一樣處理，只需確保它們包含在處理迴圈中。

**影像可以儲存陰影與效果嗎？**

可以，Aspose.Slides 在將投影片儲存為影像時支援渲染陰影、透明度以及其他圖形效果。