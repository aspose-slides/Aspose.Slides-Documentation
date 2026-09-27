---
title: 评估 Aspose.Slides
type: docs
weight: 120
url: /zh/nodejs-net/evaluate-aspose-slides/
keywords:
- 评估 Aspose.Slides
- 评估版
- 评估水印
- 试用限制
- 临时许可证
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET 的评估版有哪些限制，附带展示这两项限制以及如何通过许可证移除它们的脚本。"
---
## **概述**

Aspose.Slides for Node.js via .NET 的评估版与授权版使用相同的 npm 包。没有许可证时，它以评估模式运行：所有功能均可使用，但保存的演示文稿以及大多数导出文件会带有水印，且代码读取的文本会被截断。本文描述了这些限制并展示了如何移除它们。

## **评估限制**

**每张幻灯片都有评估水印。** 当在没有许可证的情况下保存演示文稿时，Aspose.Slides 会在保存文件的每张幻灯片中部添加一个文本框。该文本框被锁定，内容为 “Evaluation only.”，后面跟产品行和版权行。水印写入保存的文件，而不是写入内存中的演示文稿，打开演示文稿时不会自动添加水印。然而，已在评估模式下保存的文件已经包含该文本框，重新打开并再次保存时会在每张幻灯片上添加第二个水印。

相同的水印也会在导出为 PDF、XPS 或 HTML，或将幻灯片渲染为图像时呈现。如果渲染的演示文稿已经在评估模式下保存，则图像会同时显示已保存的水印和渲染的水印。

**读取文本时被截断。** 通过文本框、段落或片段的 `text` 属性读取的文本会被截取为前五个字符，后跟提示 “… text has been truncated due to evaluation version limitation.”。长度为五个字符或以下的文本会完整返回。此行为适用于每张幻灯片，甚至包括刚刚由代码赋值的文本。Markdown 和 HTML5 导出同样会被截断。

代码写入的文本会完整保存：PPTX 文件、PDF 页面和幻灯片图像中均包含完整文本。

## **在脚本中查看限制**

以下脚本展示了这两种限制。它假设您已按照 [Installation](/slides/zh/nodejs-net/installation/) 的说明安装了包，并在项目文件夹中运行它。脚本在第一张幻灯片添加一个带句子的矩形，读取该句子，保存为 `evaluation.pptx`，然后重新打开文件统计幻灯片上的形状数量。

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // 没有许可证时，仅返回前五个字符。
    console.log("Text read back:", rectangle.textFrame.text);

    // 保存时会在文件的每张幻灯片上添加评估水印。
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // 此幻灯片现在包含矩形和水印文本框。
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

没有许可证时，脚本会输出：

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

第二个形状是水印文本框。打开 `evaluation.pptx` 可看到矩形中的完整句子以及幻灯片中部的水印。

## **移除限制**

要移除这两项限制，请在创建任何 `Presentation` 对象之前先应用许可证。请参阅 [Licensing](/slides/zh/nodejs-net/licensing/) 了解如何应用许可证文件。

{{% alert color="success" title="Tip" %}}
要在购买之前测试 Aspose.Slides 且不受评估限制影响，可申请免费的 **30 天临时许可证**。详情请参阅 [How to get a Temporary License?](https://purchase.aspose.com/temporary-license)。
{{% /alert %}}

## **常见问题**

**评估模式会限制幻灯片数量吗？**

不会。演示文稿的创建、打开和保存均保留全部幻灯片。水印和文本截断会对每张幻灯片同等适用。

**为什么导出的幻灯片图像会出现两次水印？**

因为在渲染之前，演示文稿已经以评估模式保存，文件中已包含一个水印文本框，渲染时在没有许可证的情况下又会再绘制一个水印，从而出现双重水印。

**在评估模式下，我可以检查代码生成的文本是否正确吗？**

可以。打开已保存的文件或导出的 PDF，里面包含完整的文本。只有代码读取回来的文本，以及 Markdown 或 HTML5 输出会被截断。