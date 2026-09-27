---
title: API 参考
type: docs
weight: 50
url: /zh/nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET 由 Aspose.Slides for .NET API 参考文档记录。了解 .NET 类和成员名称如何映射到 JavaScript。"
---
## **概述**

Aspose.Slides for Node.js via .NET 没有自己的 API 参考。该包在 JavaScript 中以相同的名称公开 Aspose.Slides for .NET 的类，成员名称采用 camelCase，因此 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) 文档了其类、成员和枚举。

## **将 .NET 名称映射到 JavaScript**

要使用在 .NET API 参考中找到的成员，请遵循以下规则：

- **类和枚举保持其 .NET 名称**，枚举值亦然：`Presentation`、`ShapeType.Rectangle`、`SaveFormat.Pdf`。从包中导入它们：`const { Presentation, SaveFormat } = require("aspose.slides.via.net");`。
- **属性和方法首字母小写。** `Presentation.Slides` 变为 `presentation.slides`，`ShapeCollection.AddAutoShape` 变为 `shapes.addAutoShape`。属性仍为属性：读取和赋值时不使用括号。
- **集合项通过 `get(index)` 读取**，项目数量通过 `count` 获取：`presentation.slides.get(0)` 而不是 `presentation.Slides[0]`。
- **某些重载拥有独立的名称。**例如，`Slide.GetImage(Size)` 重载对应 `slide.getImageWithImageSize({ width, height })`。其他则共享同一方法并使用可选的尾随参数：`presentation.save(path, format, options, slides)` 覆盖多个 `Presentation.Save` 重载，`new Presentation(null, buffer)` 从 `Buffer` 打开演示文稿。每个类对应包的 `lib` 文件夹下的一个文件（例如 `node_modules/aspose.slides.via.net/lib/Slide.js`），可在其中查找确切名称。
- **完成后使用 `dispose` 释放演示文稿**；JavaScript 没有 `using` 语句。

该包并未包装所有 .NET 成员。如果 .NET API 参考中的成员在类文件中缺失，则在 JavaScript 中不可用。

## **示例**

以下脚本使用上述规则。每行注释显示对应的 .NET 调用。它在第一张幻灯片上添加一个带文字的矩形，将幻灯片渲染为 960 × 540 像素的 PNG 图像，并将演示文稿保存为 PDF。请在已按照 [Installation](/slides/zh/nodejs-net/installation/) 安装包的项目文件夹中运行。

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

该脚本会在当前文件夹写入 `slide.png` 和 `slide.pdf`。两者均显示带文字的矩形。未授权时，它们还会显示评估水印；请参阅 [Licensing](/slides/zh/nodejs-net/licensing/)。

有关此处使用的成员的详细信息，请参阅 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)、[ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/)、[TextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) 和 [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) 在 Aspose.Slides for .NET API 参考中的文档。