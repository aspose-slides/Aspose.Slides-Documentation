---
title: 在 Node.js via .NET 中将演示文稿幻灯片转换为图像
linktitle: 幻灯片转图像
type: docs
weight: 40
url: /zh/nodejs-net/convert-slide/
keywords:
- 转换幻灯片
- 幻灯片转图像
- 幻灯片转 PNG
- 将幻灯片保存为图像
- 渲染幻灯片
- 幻灯片缩略图
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via .NET 在 JavaScript 中将 PPTX、PPT 和 ODP 演示文稿的幻灯片渲染为 PNG 图像，可按比例因子或精确像素大小渲染。"
---
## **概述**

Aspose.Slides for Node.js via .NET 将 PowerPoint 和 OpenDocument 演示文稿的幻灯片渲染为图像，例如在网页上显示幻灯片预览。本文展示了两种选择图像尺寸的方法：相对于幻灯片大小的比例因子，以及像素单位的精确尺寸。这两个示例均保存为 PNG 文件。

这些示例需要在项目文件夹中放置一个名为 `sample.pptx` 的演示文稿，该文件夹已在[安装](/slides/zh/nodejs-net/installation/)中设置。任何 PowerPoint 演示文稿均可使用。将每个示例保存为项目文件夹中的 `.js` 文件，并使用 `node` 在该文件夹中运行它。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET 没有自己的 API 参考文档。它以 camelCase 名称镜像 Aspose.Slides for .NET API，因此本文中的 API 链接指向 [Aspose.Slides for .NET API 参考](https://reference.aspose.com/slides/zh/net/) 中相应的类和成员。
{{% /alert %}}

要将幻灯片转换为图像，请按以下步骤操作：

1. 使用[Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/presentation/) 构造函数打开演示文稿。  
1. 使用 `get(index)` 从 [slides](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/slides/zh/) 集合获取幻灯片。索引从 0 开始。  
1. 使用 `getImageWithScale` 或 `getImageWithImageSize` 渲染幻灯片。在 .NET API 参考文档中，两者都是 [Slide.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/getimage/) 的重载。它们返回与 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 对应的图像对象。  
1. 使用其 [save](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/save/) 方法和一个 [ImageFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/imageformat/) 值保存图像，然后调用其 `dispose` 方法。

## **将每张幻灯片转换为 PNG 图像**

`getImageWithScale` 接受水平和垂直比例因子。在比例为 1 时，幻灯片的一个点对应图像的一个像素。下面的示例以比例 2 渲染每张幻灯片：

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// 比例为 1 时，每点渲染为一个像素；2 时宽度和高度加倍。
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

脚本为每张幻灯片写入一个文件，`slide_1.png`、`slide_2.png` 等，从 1 开始编号。对于分辨率为 16:9、幻灯片尺寸为 960 × 540 点的演示文稿，每张图像为 1920 × 1080 像素。隐藏的幻灯片也会被渲染；如需跳过它们，请检查幻灯片的 [hidden](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/hidden/) 属性。每个图像在各自的 `finally` 块中被释放，以在渲染下一张幻灯片前释放资源。没有许可证时，图像还会显示评估水印；参见[授权](/slides/zh/nodejs-net/licensing/)。

## **将幻灯片转换为指定尺寸的图像**

`getImageWithImageSize` 接受一个包含像素单位 `width` 和 `height` 的对象。下面的示例将第一张幻灯片渲染为宽度 1280 像素，并根据幻灯片尺寸计算高度，以保持幻灯片的宽高比：

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

[slideSize.size](https://reference.aspose.com/slides/zh/net/aspose.slides/slidesize/size/) 属性返回幻灯片的宽度和高度（单位为点）。对于 16:9 演示文稿，脚本打印 `Saved a 1280 x 720 image` 并写入 `slide_1_1280px.png`；对于 4:3 演示文稿，图像为 1280 × 960 像素。

## **常见问题**

**为什么没有参数的 `getImage` 返回的图像如此小？**

如果不传入参数，`getImage` 会以幻灯片大小的 20%（以点为单位）渲染幻灯片，因此 960 × 540 点的幻灯片会变成 192 × 108 像素的图像。请使用 `getImageWithScale` 或 `getImageWithImageSize` 来选择尺寸。

**如何保存 JPEG 或其他图像格式？**

向图像的 `save` 方法传入另一个 `ImageFormat` 值，例如 `image.save("slide_1.jpg", ImageFormat.Jpeg)`。格式取决于 `ImageFormat` 值，而不是文件扩展名，请保持两者一致。

**为什么在 Linux 上图像中的文字显示不同？**

Aspose.Slides 只能使用渲染幻灯片的机器上已安装的字体。当演示文稿使用的字体缺失时（例如在典型的 Linux 服务器上缺少 Calibri），Aspose.Slides 会使用已安装的其他字体来代替，这可能导致文字外观以及换行位置发生变化。请安装演示文稿使用的字体，以在 Windows 上获得相同的图像效果。

**为什么 `getThumbnailWithImageSize` 会因 TypeError 而失败？**

包的 README 使用了 `getThumbnailWithImageSize`，但该包并没有 `getThumbnail` 方法。请改用 `getImageWithImageSize`；它接受相同的 `{ width, height }` 参数。