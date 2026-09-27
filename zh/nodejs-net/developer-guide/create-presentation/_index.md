---
title: 在 Node.js via .NET 中创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/nodejs-net/create-presentation/
keywords:
- 创建演示文稿
- 新建演示文稿
- 创建 PowerPoint
- 创建 PPTX
- 添加文本框
- 添加幻灯片
- 幻灯片大小
- 宽屏
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via .NET 在 JavaScript 中创建 PowerPoint 演示文稿：添加文本框和幻灯片，设置 16:9 幻灯片大小，并将结果保存为 PPTX。"
---
## **概述**

本文展示了如何使用 Aspose.Slides for Node.js via .NET 创建演示文稿、在其第一张幻灯片上添加文本框，并将结果保存为 PPTX 文件。同时演示了如何添加更多幻灯片以及如何将演示文稿切换为宽屏（16:9）幻灯片。

示例需要在 [Installation](/slides/zh/nodejs-net/installation/) 中描述的项目设置。将每个示例保存为项目文件夹中的 `.js` 文件，并使用 `node` 从该文件夹运行，例如 `node create-presentation.js`。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET 没有自己的 API 参考文档。它使用驼峰式命名镜像 Aspose.Slides for .NET API，因此本文中的 API 链接指向 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) 中的对应类和成员。
{{% /alert %}}

## **使用文本框创建演示文稿**

要创建演示文稿并在其第一张幻灯片上放置文本框，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。新演示文稿默认包含一张空幻灯片。  
2. 从 [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) 集合中获取该幻灯片。该包中的集合使用 `get(index)` 读取，索引从 0 开始。  
3. 使用 [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) 方法添加矩形，并设置其 [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/) 的 [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/)。  
4. 使用 [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法并传入 `SaveFormat.Pptx` 值保存演示文稿。  
5. 在 `finally` 块中调用 `dispose`，以释放支撑演示文稿的 .NET 资源。

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 位置 (x, y) 和大小 (宽度, 高度) 使用点为单位。
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

脚本会在项目文件夹中写入 `new-presentation.pptx`。该文件包含一张幻灯片，幻灯片上有一个填充的矩形，其左上角距幻灯片左边和顶部各 50 点，矩形宽 400 点、高 100 点，文本居中显示。1 点等于 1/72 英寸。未授权情况下，Aspose.Slides 还会在幻灯片上添加评估水印；详情请参阅 [Licensing](/slides/zh/nodejs-net/licensing/)。

## **添加幻灯片**

新演示文稿默认有一张幻灯片。若要添加更多幻灯片，请向 `slides` 集合的 [addEmptySlide](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addemptyslide/) 方法传入布局幻灯片。[layoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) 集合的 [getByType](https://reference.aspose.com/slides/net/aspose.slides/layoutslidecollection/getbytype/) 方法返回指定 [SlideLayoutType](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/) 的第一个布局。

以下示例使用 Blank 布局添加两张幻灯片：

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

脚本会输出 `Slide count: 3` 并生成 `three-slides.pptx`。新幻灯片会在第一张之后追加，且不包含任何形状。新创建的演示文稿始终拥有 Blank 布局，但从文件打开的演示文稿可能没有请求的布局类型；此时 `getByType` 会返回 `null`，因此在使用前需检查返回结果。

## **设置幻灯片大小**

新演示文稿使用 4:3 幻灯片，尺寸为 720 × 540 点（10 × 7.5 英寸）。若要改为宽屏幻灯片，请调用演示文稿的 [slideSize](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) 的 [setSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) 方法，传入 [SlideSizeType](https://reference.aspose.com/slides/net/aspose.slides/slidesizetype/) 值和 [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) 值。缩放类型决定 Aspose.Slides 对已有形状的处理方式；`DoNotScale` 表示保持原样，适用于尚未添加内容的演示文稿。

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

脚本输出 `Slide size: 960 x 540 points`（即 13.33 × 7.5 英寸），并生成 `widescreen.pptx`。`SlideSizeType.OnScreen16x9` 也采用 16:9 比例，但尺寸更小，为 720 × 405 点。

## **常见问题**

**位置和尺寸以什么单位衡量？**

以点为单位。1 英寸等于 72 点，因此默认的 4:3 幻灯片为 720 × 540 点，16:9 宽屏幻灯片为 960 × 540 点。

**可以将新演示文稿保存为何种格式？**

可以使用 [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) 枚举的任意值，例如 `SaveFormat.Ppt`（PowerPoint 97–2003）、`SaveFormat.Odp`（OpenDocument）或 `SaveFormat.Pdf`。PDF 输出请参阅 [Convert PowerPoint to PDF](/slides/zh/nodejs-net/convert-powerpoint-to-pdf/)。

**为什么保存的演示文稿中会包含 “Evaluation only” 文本？**

未授权情况下，Aspose.Slides 会在保存的幻灯片上添加评估水印。按照 [Licensing](/slides/zh/nodejs-net/licensing/) 中的说明应用许可证即可去除。

**为什么需要调用 `dispose`？**

`Presentation` 对象由 .NET 对象支撑，该对象占用内存和其他资源。调用 `dispose` 可在不再需要演示文稿时立即释放这些资源，在 `finally` 块中调用还能在出现错误时确保资源被释放。