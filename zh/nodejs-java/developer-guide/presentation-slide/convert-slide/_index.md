---
title: 使用 JavaScript 将演示文稿幻灯片转换为图像
linktitle: 幻灯片转图像
type: docs
weight: 35
url: /zh/nodejs-java/convert-slide/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 JavaScript 中将 PPT、PPTX 和 ODP 幻灯片转换为图像 —— 快速、高质量渲染并提供清晰的代码示例。"
---
## **简介**

Aspose.Slides for Node.js via Java 让您轻松将 PowerPoint 和 OpenDocument 演示文稿幻灯片转换为各种图像格式，包括 BMP、PNG、JPG（JPEG）、GIF 等。

要将幻灯片转换为图像，请按以下步骤操作：

1. 使用以下方式定义所需的转换设置并选择要导出的幻灯片：
    - [TiffOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/) 类，或
    - [RenderingOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/renderingoptions/) 类。
2. 调用 [getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#getImage) 方法生成幻灯片图像。

在 Aspose.Slides for Node.js via Java 中，[IImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/) 是一个允许您处理像素数据定义的图像的类。您可以使用此类将图像保存为多种格式（BMP、JPG、PNG 等）。

## **将幻灯片转换为位图并以 PNG 保存图像**

您可以将幻灯片转换为位图对象并直接在应用程序中使用。或者，您可以将幻灯片转换为位图，然后以 JPEG 或其他任何首选格式保存图像。

下面的 JavaScript 代码演示如何将演示文稿的第一张幻灯片转换为位图对象，然后以 PNG 格式保存图像：

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 将演示文稿的第一张幻灯片转换为位图。
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // 以 PNG 格式保存图像。
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **将幻灯片转换为自定义尺寸的图像**

您可能需要获取特定尺寸的图像。通过使用 [getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#getImage) 的重载，您可以将幻灯片转换为具有特定宽度和高度的图像。

以下示例代码演示如何实现：

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 将演示文稿的第一张幻灯片转换为指定大小的位图。
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // 以 JPEG 格式保存图像。
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **将带有备注和批注的幻灯片转换为图像**

某些幻灯片可能包含备注和批注。

Aspose.Slides 提供了两个类——[TiffOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/) 和 [RenderingOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/renderingoptions/)——可让您控制演示文稿幻灯片渲染为图像的方式。这两个类都包含 `setSlidesLayoutOptions` 方法，允许您在将幻灯片转换为图像时配置备注和批注的渲染。

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notescommentslayoutingoptions/) 类，您可以指定在生成的图像中备注和批注的首选位置。

下面的 JavaScript 代码演示如何将带有备注和批注的幻灯片转换为图像：

```js
const scaleX = 2;
const scaleY = scaleX;

// 加载演示文稿文件。
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // 设置备注的位置。
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // 设置批注的位置。
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // 设置批注区域的宽度。
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // 设置批注区域的颜色。

    // 创建渲染选项。
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // 将演示文稿的第一张幻灯片转换为图像。
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // 以 GIF 格式保存图像。
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
在任何幻灯片转图像的转换过程中，[setNotesPosition](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 方法无法使用 `BottomFull`（用于指定备注位置），因为备注文本可能过大，导致无法适应指定的图像尺寸。
{{% /alert %}} 

## **使用 TIFF 选项将幻灯片转换为图像**

[TiffOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/) 类通过允许您指定尺寸、分辨率、颜色调色板等参数，提供对生成的 TIFF 图像的更强控制。

下面的 JavaScript 代码演示了使用 TIFF 选项将图像输出为分辨率 300 DPI、尺寸为 2160 × 2800 的黑白图像的转换过程：

```js
// 加载演示文稿文件。
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // 获取演示文稿中的第一张幻灯片。
    let slide = presentation.getSlides().get_Item(0);

    // 配置输出 TIFF 图像的设置。
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // 设置图像尺寸。
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // 设置像素格式（黑白）。
    tiffOptions.setDpiX(300);                                                          // 设置水平分辨率。
    tiffOptions.setDpiY(300);                                                          // 设置垂直分辨率。

    // 使用指定选项将幻灯片转换为图像。
    let image = slide.getImage(tiffOptions);
    try {
        // 以 TIFF 格式保存图像。
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
在 JDK 9 之前的版本中不保证支持 TIFF。
{{% /alert %}} 

## **将所有幻灯片转换为图像**

Aspose.Slides 允许您将演示文稿中的所有幻灯片转换为图像，从而实现将整个演示文稿转换为一系列图像。

以下示例代码演示如何在 JavaScript 中将演示文稿的所有幻灯片转换为图像：

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 将演示文稿逐张幻灯片渲染为图像。
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // 控制隐藏的幻灯片（不渲染隐藏的幻灯片）。
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // 将幻灯片转换为图像。
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // 以 JPEG 格式保存图像。
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **彩色表情符号渲染**

{{% alert title="Note" color="warning" %}} 
在将演示文稿幻灯片转换为图像时正确渲染彩色表情符号，需要在执行转换的系统上安装并可用演示文稿中使用的表情符号字体。例如，如果演示文稿使用 **Segoe UI Emoji**，但该字体缺失，则输出图像中的表情符号可能会显示为单色。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 是否支持渲染带动画的幻灯片？**

不，`getImage` 方法仅保存幻灯片的静态图像，不包含动画。

**可以导出隐藏的幻灯片为图像吗？**

可以，隐藏的幻灯片可以像普通幻灯片一样处理。只需确保它们包含在处理循环中即可。

**可以将图像保存为带有阴影和效果吗？**

可以，Aspose.Slides 支持在将幻灯片保存为图像时渲染阴影、透明度和其他图形效果。