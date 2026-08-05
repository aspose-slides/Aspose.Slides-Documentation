---
title: 在 PHP 中将演示文稿幻灯片转换为图像
linktitle: 幻灯片转图像
type: docs
weight: 35
url: /zh/php-java/convert-slide/
keywords:
- 转换幻灯片
- 导出幻灯片
- 幻灯片转图像
- 将幻灯片保存为图像
- 幻灯片转 PNG
- 幻灯片转 JPEG
- 幻灯片转位图
- 幻灯片转 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 将 PPT、PPTX 和 ODP 幻灯片转换为图像——快速、高质量渲染，并附有清晰的代码示例。"
---
## **介绍**

Aspose.Slides for PHP via Java 使您能够轻松将 PowerPoint 和 OpenDocument 演示文稿幻灯片转换为各种图像格式，包括 BMP、PNG、JPG（JPEG）、GIF 等。

要将幻灯片转换为图像，请按以下步骤操作：

1. 使用以下方式定义所需的转换设置并选择要导出的幻灯片：
    - 使用 [TiffOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tiffoptions/) 类，或
    - 使用 [RenderingOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/renderingoptions/) 类。
2. 通过调用 [getImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#getImage) 方法生成幻灯片图像。

在 Aspose.Slides for PHP via Java 中，`[IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/)` 是一个允许您处理像素数据定义的图像的类。您可以使用此类将图像保存为多种格式（BMP、JPG、PNG 等）。

## **将幻灯片转换为位图并以 PNG 保存图像**

您可以将幻灯片转换为位图对象并直接在应用程序中使用。或者，您可以先将幻灯片转换为位图，然后将图像保存为 JPEG 或其他首选格式。

以下代码演示如何将演示文稿的第一张幻灯片转换为位图对象，然后以 PNG 格式保存图像：

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // 将演示文稿中的第一张幻灯片转换为位图。
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // 以 PNG 格式保存图像。
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **将幻灯片转换为自定义尺寸的图像**

您可能需要获取特定尺寸的图像。使用 [getImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#getImage) 的重载，您可以将幻灯片转换为具有特定宽度和高度的图像。

以下示例代码演示如何实现：

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // 将演示文稿中的第一张幻灯片转换为具有指定尺寸的位图。
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // 以 JPEG 格式保存图像。
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **将包含备注和批注的幻灯片转换为图像**

某些幻灯片可能包含备注和批注。

Aspose.Slides 提供了两个类[TiffOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tiffoptions/) 和 [RenderingOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/renderingoptions/)——允许您控制演示文稿幻灯片渲染为图像的方式。这两个类都包含 `setSlidesLayoutOptions` 方法，可在将幻灯片转换为图像时配置备注和批注的渲染。

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notescommentslayoutingoptions/) 类，您可以指定在生成的图像中备注和批注的首选位置。

以下代码演示如何将包含备注和批注的幻灯片转换为图像：

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // 设置备注的位置。
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // 设置批注的位置。
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // 设置批注区域的宽度。
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // 设置批注区域的颜色。

    // 创建渲染选项。
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // 将演示文稿的第一张幻灯片转换为图像。
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // 以 GIF 格式保存图像。
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
在任何幻灯片转图像的过程中，`[setNotesPosition](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)` 方法无法使用 `BottomFull`（指定备注位置），因为备注文字可能过大，导致无法适应指定的图像尺寸。
{{% /alert %}} 

## **使用 TIFF 选项将幻灯片转换为图像**

[TiffOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tiffoptions/) 类通过允许您指定尺寸、分辨率、颜色调色板等参数，为生成的 TIFF 图像提供更高的控制度。

以下代码演示了使用 TIFF 选项将图像输出为 300 DPI 分辨率、尺寸为 2160 × 2800 的黑白图像的转换过程：

```php
// 加载演示文稿文件。
$presentation = new Presentation("sample.pptx");
try {
    // 获取演示文稿中的第一张幻灯片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 配置输出 TIFF 图像的设置。
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // 设置图像尺寸。
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // 设置像素格式（黑白）。
    $options->setDpiX(300);                                              // 设置水平分辨率。
    $options->setDpiY(300);                                              // 设置垂直分辨率。
    
    // 使用指定的选项将幻灯片转换为图像。
    $image = $slide->getImage($options);
    try {
        // 以 TIFF 格式保存图像。
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
在 JDK 9 之前的版本中不保证对 TIFF 的支持。
{{% /alert %}} 

## **将所有幻灯片转换为图像**

Aspose.Slides 允许您将演示文稿中的所有幻灯片转换为图像，从而将整个演示文稿转换为一系列图像。

以下示例代码演示如何在 PHP 中将演示文稿的所有幻灯片转换为图像：

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // 逐张渲染演示文稿为图像。
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // 控制隐藏幻灯片（不渲染隐藏的幻灯片）。
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // 将幻灯片转换为图像。
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // 以 JPEG 格式保存图像。
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **彩色表情符号渲染**

{{% alert title="Note" color="warning" %}} 
在将演示文稿幻灯片转换为图像时，要正确渲染彩色表情符号，演示文稿中使用的表情符号字体必须已安装并在执行转换的系统上可用。例如，如果演示文稿使用 **Segoe UI Emoji** 字体但该字体缺失，则输出图像中的表情符号可能会以单色显示。
{{% /alert %}}

## **常见问题解答**

**Aspose.Slides 是否支持渲染带动画的幻灯片？**

不，`getImage` 方法仅保存幻灯片的静态图像，不包括动画。

**隐藏的幻灯片可以导出为图像吗？**

可以，隐藏的幻灯片可以像普通幻灯片一样进行处理。只需确保它们包含在处理循环中即可。

**图像可以保存阴影和效果吗？**

可以，Aspose.Slides 在将幻灯片保存为图像时支持渲染阴影、透明度和其他图形效果。