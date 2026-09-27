---
title: 管理 Node.js via .NET 中的演示文稿文本
linktitle: 管理文本
type: docs
weight: 50
url: /zh/nodejs-net/manage-text/
keywords:
- 文本
- 文本框
- 添加文本
- 更改文本
- 格式化文本
- 字体大小
- 粗体文本
- 文本框架
- 段落
- 片段
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides for Node.js via .NET 向幻灯片添加文本框，然后更改其文本、字体大小和粗体样式。"
---
## **概述**

在 Aspose.Slides 中，幻灯片上的文本属于形状。自动形状（例如矩形）具有文本框；文本框包含段落，每个段落包含文本片段，即具有相同格式的文本运行。您可以通过文本框更改文本，通过片段的格式更改字体。

本文向幻灯片添加一个文本框并保存演示文稿。然后打开保存的文件并更改文本框的文本、字体大小和粗体样式。

示例需要按照[安装](/slides/zh/nodejs-net/installation/)中描述的方式设置项目。将每个示例保存为项目文件夹中的 `.js` 文件，并在该文件夹中使用 `node` 运行。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET 没有自己的 API 参考。它使用 camelCase 名称镜像 Aspose.Slides for .NET API，因此本文中的 API 链接指向 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) 中对应的类和成员。
{{% /alert %}}

## **添加文本框**

要添加文本框，使用 [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) 方法向幻灯片添加自动形状，并使用 [addTextFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/addtextframe/) 方法为其添加文本。以下示例向新演示文稿的第一张幻灯片添加一个矩形，并将演示文稿保存为 `text-box.pptx`：

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 位置 (x, y) 和大小 (宽度, 高度) 的单位是点。
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

`text-box.pptx` 幻灯片包含一个宽 500 点、高 80 点的矩形，文本为默认字体和大小的“Quarterly report”。下一个示例会更改此文本框。

## **更改文本及其格式**

以下示例打开前面示例创建的 `text-box.pptx`，并获取第一张幻灯片上的第一个形状。图片、表格等形状没有文本框，因此示例在使用形状的 [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/) 之前，会检查该形状是否为 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)。随后执行以下操作：

1. 通过文本框的 [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) 属性替换文本。之后，文本框只包含一个段落，其中只有一个片段。  
2. 从 [paragraphs](https://reference.aspose.com/slides/net/aspose.slides/textframe/paragraphs/) 和 [portions](https://reference.aspose.com/slides/net/aspose.slides/paragraph/portions/) 集合中获取该片段，并读取其 [portionFormat](https://reference.aspose.com/slides/net/aspose.slides/portion/portionformat/)。  
3. 设置 [fontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)（以点为单位的字体大小）和 [fontBold](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontbold/)，后者接受一个 [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 值。

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

`text-box-updated.pptx` 中的文本框显示为“Quarterly report: third quarter”，为粗体 32 点字号。由于新文本为单个片段，这两个格式属性会应用于全部文本。未授权情况下，每次保存都会添加评估水印。由于 `text-box.pptx` 本身已在评估模式下保存，`text-box-updated.pptx` 因此包含两个水印；请参阅 [评估 Aspose.Slides](/slides/zh/nodejs-net/evaluate-aspose-slides/)。

## **常见问题**

**为什么 `fontBold` 接受 `NullableBool` 值而不是 `true` 或 `false`？**

片段可以不定义某个属性，从段落、形状或幻灯片的版式和母版继承该属性。`NullableBool.NotDefined` 表示“继承”，而 `NullableBool.True` 和 `NullableBool.False` 则覆盖继承值。直接赋值 `true` 或 `false` 会导致错误。出于同样的原因，当片段继承其字体大小时，`fontHeight` 会返回 `NaN`。

**如何更改文本颜色？**

设置片段格式的填充：将 `FillType.Solid` 赋给 `portionFormat.fillFormat.fillType`，随后将颜色（例如 `"#FF0000"`）赋给 `portionFormat.fillFormat.solidFillColor.color`。在导入的名称中加入 `FillType`。

**如何仅格式化文本的一部分？**

格式化作用于片段，因此请将该文本部分放入单独的片段中。使用 `Portion.CreatePortionFromText` 创建片段，将其通过段落的 `portions` 集合的 `add` 方法追加到段落中，然后设置新片段的 `portionFormat`。在导入的名称中加入 `Portion`。

**为什么读取文本时返回 “… text has been truncated due to evaluation version limitation” ?**

在未授权情况下，Aspose.Slides 只返回您读取的任何较长文本的前五个字符（例如 `textFrame.text`），随后附加该提示。您写入的文本会完整保存。请按照 [授权](/slides/zh/nodejs-net/licensing/) 中的说明应用许可证，以读取完整文本。