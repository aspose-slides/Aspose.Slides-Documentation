---
title: 在 JavaScript 中将演示文稿幻灯片转换为图像
linktitle: 幻灯片转图像
type: docs
weight: 35
url: /zh/nodejs-java/convert-slide/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中将 PPT、PPTX 和 ODP 演示文稿的幻灯片转换为 PNG、JPEG、GIF、TIFF、EMF 以及其他图像格式。"
---
## **介绍**

Aspose.Slides for Node.js via Java 可以将 PowerPoint 和 OpenDocument 演示文稿中的单个幻灯片渲染为 PNG、JPEG、GIF、TIFF 等图像格式。

要将幻灯片转换为图像，请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类加载演示文稿。
2. 选择要渲染的幻灯片。
3. 如有必要，使用 [RenderingOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/) 类配置渲染参数。
4. 调用 [Slide.getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#getImage) 方法。它返回一个 [IImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/) 对象。
5. 调用 [IImage.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/#save) 方法，并使用 [ImageFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/imageformat/) 值指定输出格式。

## **将幻灯片转换为 PNG 图像**

最简单的转换使用默认渲染设置。生成的 [IImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/) 对象可以在内存中处理或保存到文件。

下面的 JavaScript 示例渲染第一张幻灯片并将其保存为 PNG 图像：

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

## **按自定义尺寸将幻灯片转换为图像**

使用接受 `java.awt.Dimension` 参数的 [Slide.getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#getImage) 重载，以精确的像素尺寸渲染幻灯片。

下面的示例创建一个 1820 × 1040 的 JPEG 图像：

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

## **将带备注和批注的幻灯片转换为图像**

默认情况下，幻灯片图像不包含备注或批注。将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notescommentslayoutingoptions/) 对象传递给 [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) 方法，以控制备注和批注的显示位置。

下面的示例将在幻灯片下方放置截断的备注，在右侧放置批注：

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
在进行幻灯片转图像转换时，请不要将 [BottomFull](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notespositions/) 传递给 [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 方法。备注的文字可能超出固定图像尺寸。请改用 [BottomTruncated](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notespositions/)。
{{% /alert %}}

## **使用 TIFF 选项将幻灯片转换为图像**

[TiffOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/) 类可让您控制渲染的 TIFF 图像的大小、分辨率等属性。

下面的示例以 300 DPI 将第一张幻灯片渲染为 2160 × 2880 的 TIFF 图像：

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
在 JDK 9 之前的 Java 版本中，TIFF 支持不可保证。
{{% /alert %}}

## **将所有幻灯片转换为图像**

遍历幻灯片集合，可将整个演示文稿转换为一系列图像。除非显式跳过，否则隐藏的幻灯片也会被包含。

下面的示例以水平和垂直比例因子 2 渲染每张幻灯片为 JPEG 图像：

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

## **创建增强型图元文件输出**

增强型图元文件（EMF）在需要将基于矢量的图形与 Microsoft Office 或其他支持 Windows 图元文件的 Windows 应用程序交换时非常有用。与基于像素的图像不同，EMF 可以保留可在不失真情况下缩放的矢量绘图操作。不过，EMF 主要是针对具备 Windows 图元文件支持的应用程序的兼容格式，而非通用的互换格式。此外，复杂的幻灯片内容（例如位图图像和某些效果）可能会以光栅化元素的形式存储在矢量图元文件容器中。

### **将幻灯片导出为 EMF**

[Slide.writeAsEmf](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#writeAsEmf) 方法将幻灯片以 EMF 格式写入目标流。下面的示例加载演示文稿，选择第一张幻灯片，并将其写入 EMF 文件流：

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

调用方拥有传递给 [Slide.writeAsEmf](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#writeAsEmf) 的流，并负责在如上所示后关闭该流。

### **将 SVG 图像转换为 EMF 并添加到演示文稿**

使用 [SvgImage.writeAsEmf](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgimage/#writeAsEmf) 将 SVG 内容转换为 EMF。生成的字节可通过 [ImageCollection.addImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/imagecollection/#addImage) 添加到演示文稿，并使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) 放置在幻灯片上。

下面的示例从 SVG 标记创建 [SvgImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgimage/)，将其转换为内存中的 EMF，插入第一张幻灯片，并保存演示文稿：

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

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgimage/#writeAsEmf) 不会获取目标流的所有权。`java.io.ByteArrayOutputStream` 将所有生成的数据存储在内存中，无需在调用 `toByteArray` 前重置位置。流关闭后返回的字节数组仍然有效。

EMF 生成功能在所选的 Aspose.Slides for Node.js via Java 及其 JDK 配置支持的操作系统上可用，但当字体或图形依赖不可用时，不同平台的渲染结果可能有所差异。请安装源内容使用的字体或配置合适的替代方案，遵循 Aspose.Slides for Node.js via Java 的 [平台要求](/slides/zh/nodejs-java/system-requirements/)，并在目标 EMF 消费应用中验证结果。Linux 和 macOS 应用通常对 Windows 图元文件的显示和编辑支持有限或不一致。

## **彩色表情符号渲染**

{{% alert title="Note" color="info" %}}
在将演示文稿幻灯片转换为图像时，如需正确渲染彩色表情符号，必须在执行转换的系统上安装并提供演示文稿使用的表情符号字体。例如，演示文稿使用 **Segoe UI Emoji**，但系统缺少该字体时，表情符号可能会以单色形式显示在输出图像中。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 是否支持渲染带动画的幻灯片？**

不支持。[Slide.getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#getImage) 方法渲染幻灯片的静态图像，不会导出动画。

**可以将隐藏的幻灯片导出为图像吗？**

可以。隐藏的幻灯片可以像普通幻灯片一样渲染。请在处理循环中包含它们，如上例所示。

**幻灯片图像会保留阴影和其他效果吗？**

会。Aspose.Slides 在幻灯片图像中渲染阴影、透明度以及其他受支持的图形效果。