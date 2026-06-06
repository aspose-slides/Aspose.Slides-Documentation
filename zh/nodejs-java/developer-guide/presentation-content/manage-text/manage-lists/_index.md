---
title: 使用 JavaScript 在演示文稿中管理项目符号和编号列表
linktitle: 管理列表
type: docs
weight: 60
url: /zh/nodejs-java/manage-lists/
keywords:
- 项目符号
- 项目符号列表
- 编号列表
- 符号项目符号
- 图片项目符号
- 自定义项目符号
- 多级列表
- 创建项目符号
- 添加项目符号
- 添加列表
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号、图片、多级和编号列表。"
---
## **概览**

Aspose.Slides for Node.js via Java 允许您在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号列表和编号列表。列表项是一个段落，其项目符号设置通过段落格式进行控制。

使用 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 类访问段落级别的列表设置。主要入口是 `Paragraph.getParagraphFormat().getBullet()`，它返回一个 [BulletFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/) 对象。通过该对象，您可以设置项目符号的类型、符号、图片、颜色、大小、编号样式以及起始编号。

本文展示了如何：

- 创建带自定义符号的项目符号列表
- 创建图片项目符号
- 通过设置段落深度创建多级列表
- 创建编号列表
- 检查并更改现有演示文稿中的列表格式

## **创建项目符号列表**

要创建项目符号列表，向 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 中添加 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 对象，并将 `BulletFormat.setType` 设置为 [BulletType.Symbol](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bullettype/)。随后可以使用 `BulletFormat.setChar`、`BulletFormat.getColor` 和 `BulletFormat.setHeight` 来控制项目符号的外观。

以下 JavaScript 代码演示了如何在幻灯片中创建项目符号列表：

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![符号项目符号](symbol_bullets.png)

## **创建编号列表**

当项目的顺序重要时使用编号列表。将 `BulletFormat.setType` 设置为 [BulletType.Numbered](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bullettype/)。您还可以使用 `BulletFormat.setNumberedBulletStyle` 选择编号格式，或在列表应从非 1 的值开始时使用 `BulletFormat.setNumberedBulletStartWith`。

以下 JavaScript 代码展示了如何在幻灯片中创建编号列表：

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![编号项目符号](numbered_bullets.png)

## **创建图片项目符号**

Aspose.Slides 允许您将常规项目符号符号替换为图像。图片项目符号最适合使用在小尺寸下仍可辨识的简洁图像，如图标或小型透明 PNG 文件。

{{% alert color="primary" %}}
理想情况下，如果您计划用图像替换常规项目符号，最好选择具有透明背景的简洁图形。这类图像可作为自定义项目符号使用效果良好。

请注意，图像会被缩小到非常小的尺寸。因此，我们强烈建议选择在列表中用作项目符号时仍保持清晰且视觉有效的图像。
{{% /alert %}}

要创建图片项目符号，使用 `Presentation.getImages().addImage` 将图像添加到 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)，并将返回的 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/) 对象分配给 `BulletFormat.getPicture().setImage`。在分配图像之前，将 `BulletFormat.setType` 设置为 [BulletType.Picture](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bullettype/)。

假设我们有一个 "image.png"：

![用于项目符号的图片](picture_for_bullets.png)

以下 JavaScript 代码展示了如何在幻灯片中创建图片项目符号：

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

结果：

![图片项目符号](picture_bullets.png)

## **创建多级列表**

使用 `ParagraphFormat.setDepth` 将列表项放置在不同级别。级别 0 为顶级，级别 1 为其下的嵌套，以此类推。

以下 JavaScript 代码展示了如何创建多级项目符号列表：

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![多级列表](multilevel_list.png)

## **更改现有列表**

要在现有演示文稿中更改列表格式，访问目标段落并更新其 `ParagraphFormat.getBullet` 设置。创建列表时使用的相同属性也可用于检查或修改从 PPT、PPTX 或 ODP 文件加载的列表。

以下 JavaScript 代码将文本框中的第一段落更改为使用编号列表样式：

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Can bulleted and numbered lists be exported to PDF or images?**

是的。Aspose.Slides 在目标格式支持相应的文本布局和项目符号特性时，会保留列表格式。

**Can I edit lists in existing presentations?**

是的。加载演示文稿，访问目标段落，检查或更新其 `ParagraphFormat.getBullet` 设置，然后保存演示文稿。

**Can lists contain non-Latin text?**

是的。列表项文本可以包含 Unicode 字符，您可以在多语言演示文稿中创建列表。请确保演示文稿使用的字体支持所需的字符。