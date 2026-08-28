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
- 幻灯片转 EMF
- 幻灯片转 PNG
- 幻灯片转 JPEG
- 幻灯片转位图
- 幻灯片转 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中将 PPT、PPTX 和 ODP 演示文稿的幻灯片转换为 PNG、JPEG、GIF、TIFF、EMF 等图像格式。"
---
## **简介**

Aspose.Slides for PHP via Java 可以将 PowerPoint 和 OpenDocument 演示文稿中的单个幻灯片渲染为 PNG、JPEG、GIF、TIFF 等图像格式。

要将幻灯片转换为图像，请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类加载演示文稿。
2. 选择要渲染的幻灯片。
3. 如有必要，使用 [RenderingOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tiffoptions/) 类配置渲染。
4. 调用 [Slide::getImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#getImage) 方法。它返回一个 [IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 对象。
5. 调用 [IImage::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/#save) 方法，并使用 [ImageFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imageformat/) 值指定输出格式。

## **将幻灯片转换为 PNG 图像**

最简单的转换使用默认渲染设置。生成的 [IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 对象可以在内存中处理或保存为文件。

以下 PHP 示例渲染第一张幻灯片并将其保存为 PNG 图像：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **使用自定义尺寸将幻灯片转换为图像**

使用接受 [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) 值的 [Slide::getImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#getImage) 重载，以精确的像素尺寸渲染幻灯片。

以下示例创建一个 1820 × 1040 的 JPEG 图像：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **将带备注和评论的幻灯片转换为图像**

默认情况下，幻灯片图像不包含备注或评论。将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notescommentslayoutingoptions/) 对象传递给 [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) 方法，以控制备注和评论的显示位置。

以下示例在幻灯片下方放置截断的备注，在右侧放置评论：

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
在幻灯片转图像的转换中，不要将 [BottomFull](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notespositions/) 传递给 [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 方法。备注的文本可能超出固定图像尺寸的容纳范围。请改用 [BottomTruncated](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notespositions/)。
{{% /alert %}}

## **使用 TIFF 选项将幻灯片转换为图像**

[TiffOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tiffoptions/) 类允许您控制渲染的 TIFF 图像的大小、分辨率和其他属性。

以下示例将第一张幻灯片以 2160 × 2880 的大小、300 DPI 渲染为 TIFF 图像：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
在 Java 9 之前的版本中不保证对 TIFF 的支持。
{{% /alert %}}

## **将所有幻灯片转换为图像**

遍历幻灯片集合，将整个演示文稿转换为一系列图像。除非显式跳过，否则会包括隐藏幻灯片。

以下示例以水平和垂直比例因子为 2 的方式将每张幻灯片渲染为 JPEG 图像：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **创建增强型图元文件（EMF）输出**

增强型图元文件（EMF）在需要将基于矢量的图形与 Microsoft Office 或其他支持 Windows 元文件的 Windows 应用程序交换时非常有用。与基于像素的图像不同，EMF 可以保留矢量绘图操作，在缩放时不会出现同样的清晰度损失。但 EMF 主要是一种针对具备 Windows 元文件支持的应用程序的兼容格式，而非通用的交换格式。此外，复杂的幻灯片内容（例如位图图像和某些效果）可能会以光栅化元素的形式存储在矢量元文件容器中。

### **将幻灯片导出为 EMF**

[Slide::writeAsEmf](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#writeAsEmf) 方法将幻灯片写入目标流，以 EMF 格式保存。以下示例加载演示文稿，选择第一张幻灯片，并将其写入 EMF 文件流：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

调用方拥有传递给 [Slide::writeAsEmf](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#writeAsEmf) 的流，并负责在上述示例中关闭该流。

### **将 SVG 图像转换为 EMF 并添加到演示文稿**

使用 [SvgImage::writeAsEmf](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/#writeAsEmf) 将 SVG 内容转换为 EMF。生成的字节可以通过 [ImageCollection::addImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagecollection/#addImage) 添加到演示文稿，并使用 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/#addPictureFrame) 放置在幻灯片上。

以下示例从 SVG 标记创建一个 [SvgImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/)，将其转换为内存中的 EMF，插入到第一张幻灯片，并保存演示文稿：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/#writeAsEmf) 不会获取目标流的所有权。[ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) 将所有生成的数据存储在内存中，因此在调用 `toByteArray` 之前无需重置位置。流关闭后返回的字节数组仍然有效。

EMF 生成功能在所选的 Aspose.Slides for PHP via Java 以及 JDK 配置支持的操作系统上可用，但当字体或图形依赖不可用时，不同平台的渲染结果可能会有所差异。请安装源内容使用的字体或配置合适的替代方案，遵循 Aspose.Slides for PHP via Java 的 [平台要求](/slides/zh/php-java/system-requirements/)，并在目标 EMF 消费应用中验证结果。Linux 与 macOS 应用往往对 Windows 元文件的显示和编辑支持有限或不一致。

## **彩色表情符号渲染**

{{% alert title="Note" color="info" %}}
在将演示文稿幻灯片转换为图像时正确渲染彩色表情符号，需要在执行转换的系统上安装并可用演示文稿中使用的表情符号字体。例如，若演示文稿使用 **Segoe UI Emoji** 且该字体缺失，输出图像中的表情符号可能会以单色显示。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 是否支持渲染带动画的幻灯片？**

否。[Slide::getImage] 方法渲染幻灯片的静态图像，不导出动画。

**隐藏的幻灯片可以导出为图像吗？**

可以。隐藏幻灯片可以像普通幻灯片一样渲染。请在处理循环中包含它们，如上面的示例所示。

**幻灯片图像是否保留阴影和其他效果？**

可以。Aspose.Slides 在幻灯片图像中渲染阴影、透明度以及其他受支持的图形效果。