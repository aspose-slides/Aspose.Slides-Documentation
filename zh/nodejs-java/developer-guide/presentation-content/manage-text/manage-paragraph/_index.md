---
title: 在 JavaScript 中管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- 添加文本
- 添加段落
- 管理文本
- 管理段落
- 管理项目符号
- 段落缩进
- 悬挂缩进
- 段落项目符号
- 编号列表
- 项目符号列表
- 段落属性
- 导入 HTML
- 文本转 HTML
- 段落转 HTML
- 段落转图像
- 文本转图像
- 导出段落
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 创建和格式化段落、文本段、项目符号、编号列表、缩进、HTML 内容以及段落图像。"
---
## **概述**

Aspose.Slides for Node.js via Java 将文本表示为文本框、段落和文本段的层次结构：

* [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 表示形状中的文本容器，并提供对其段落集合的访问。
* [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 表示文本框中的一个段落，并提供对其文本段和段落级格式的访问。
* [Portion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/) 表示段落中的一个文本运行。每个文本段可以拥有自己的文本和字符级格式。

因此，一个段落可以通过使用多个文本段来包含具有不同字体、颜色、大小和其他格式的文本。

## **创建和格式化段落**

### **使用多个文本段创建段落**

以下步骤创建一个包含三个段落、每个段落包含三个文本段的文本框：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 在幻灯片上添加一个矩形的 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
5. 使用默认段落，并向文本框再添加两个 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 对象。
6. 为每个段落添加足够的 [Portion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/) 对象，使其包含三个文本段。默认段落已包含一个空的文本段。
7. 为每个文本段设置文本。
8. 通过 [Portion.getPortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/getportionformat/) 应用字符级格式。
9. 保存修改后的演示文稿。

以下 JavaScript 示例演示了这些步骤：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **创建项目符号和编号列表**

### **创建项目符号或编号列表**

项目符号和编号使相关项目更易于浏览。在 Aspose.Slides 中，列表设置通过 [BulletFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/) 定义。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 在选定的幻灯片上添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
5. 从文本框中移除默认段落。
6. 为符号项目符号创建一个 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/)。
7. 将 [BulletFormat.setType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/settype/) 设置为 [BulletType.Symbol](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bullettype/) 并指定项目符号字符。
8. 设置段落文本、缩进、项目符号颜色和项目符号高度。
9. 将段落添加到文本框中。
10. 创建第二个段落，并将 [BulletFormat.setType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/settype/) 设置为 [BulletType.Numbered](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bullettype/)。
11. 配置编号项目符号样式并将段落添加到文本框中。
12. 保存演示文稿。

以下 JavaScript 示例创建了符号项目符号和编号项目符号：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **使用图片项目符号**

图片项目符号允许使用自定义图像而不是符号或数字。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/) 并访问其 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
4. 从文本框中移除默认段落。
5. 加载项目符号图像并将其作为 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/) 添加到演示文稿的图像集合中。
6. 创建一个 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 并设置其文本。
7. 将 [BulletFormat.setType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/settype/) 设置为 [BulletType.Picture](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bullettype/)。
8. 通过 [BulletFormat.getPicture](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/getpicture/) 分配图像并设置项目符号高度。
9. 将段落添加到文本框中。
10. 保存修改后的演示文稿。

以下 JavaScript 示例创建了图片项目符号：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **创建多级列表**

通过设置 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setdepth/) 将段落放置在列表的不同层级。顶层的深度为 `0`。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 并访问一个幻灯片。
2. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/) 并清除其文本框中的默认段落。
3. 创建四个段落并配置它们的项目符号符号。
4. 将它们的 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setdepth/) 值设置为 `0`、`1`、`2` 和 `3`。
5. 将段落添加到文本框并保存演示文稿。

以下 JavaScript 示例创建了四级项目符号列表：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **自定义编号列表起始值**

使用 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 设置编号段落的起始数字。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 并向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
2. 清除形状的文本框中的默认段落。
3. 创建三个编号段落。
4. 为相应的段落将 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 设置为 `2`、`3` 和 `7`。
5. 将段落添加到文本框并保存演示文稿。

以下 JavaScript 示例为每个段落分配自定义起始编号：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制段落布局和结束属性**

### **设置首行缩进**

使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 控制段落的首行缩进。此方法仅移动相对于段落左边距的第一行。正值会将首行向右移动，而其余行保持与段落正文对齐。

当需要移动整个段落时使用 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)。当只需移动首行时使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/)。

下面的示例创建了多个段落，并应用不同的 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 值，以演示首行缩进如何影响段落布局。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 在幻灯片上添加一个矩形的 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 并移除默认段落。
5. 创建多个段落并为它们设置不同的 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 值。
6. 将段落添加到文本框。
7. 保存修改后的演示文稿。

以下代码演示如何设置段落缩进：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![段落的首行缩进](first_line_indent.png)

### **设置悬挂缩进**

悬挂缩进是一种段落布局，其中第一行位于其余行的左侧。在 Aspose.Slides 中，可使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 实现此效果。传入负值可将第一行相对于段落正文向左移动。

实际上，[ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 定义段落正文的左侧位置，而 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 定义第一行相对于该边距的位置。要创建悬挂缩进，需要向 `setMarginLeft` 传入正值，并向 `setIndent` 传入负值。

此格式在参考文献、引用、词汇表条目以及其他需要换行后行对齐至段落正文而非首行首字符的段落中非常有用。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 在幻灯片上添加一个矩形的 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 并移除默认段落。
5. 创建段落，并为每个段落向 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 传入正值。
6. 向 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 传入负值以创建悬挂缩进效果。
7. 将段落添加到文本框。
8. 保存修改后的演示文稿。

以下代码演示如何为段落设置悬挂缩进：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![段落的悬挂缩进](hanging_indent.png)

### **设置段落结束运行属性**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) 控制段落结束标记的格式。下面的示例为第二段的结束标记分配字体大小和拉丁字体：

1. 创建或加载一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 并访问一个幻灯片。
2. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/) 并清除其默认段落。
3. 创建两个段落并向其添加文本段。
4. 为第二段的结束标记创建一个 [PortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portionformat/)。
5. 设置 [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) 和 [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setLatinFont)。
6. 使用 [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) 分配该格式并保存演示文稿。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **导入和导出段落内容**

### **将 HTML 文本导入段落**

使用 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) 将 HTML 标记转换为文本框中的段落和文本段。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 访问一个幻灯片并添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
3. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 并清除其默认段落。
4. 定义或读取源 HTML 字符串。
5. 将 HTML 字符串传递给 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/)。
6. 保存修改后的演示文稿。

以下 JavaScript 示例将 HTML 导入文本框：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **将段落文本导出为 HTML**

使用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) 将选定范围的段落导出为 HTML。

1. 创建或加载一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 实例。
2. 访问幻灯片并找到包含文本的 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
3. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
4. 调用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) ，传入起始段落索引和要导出的段落数量。
5. 将返回的 HTML 字符串写入文件。

以下独立的 JavaScript 示例创建一个文本形状并导出其所有段落：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **将段落渲染为图像**

[Paragraph.getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/#getImage) 直接渲染单个段落并返回一个 [IImage]。使用 [IImage.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/#save) 将结果保存到文件。无需渲染包含的形状或手动裁剪位图。

如果在父集合中未找到段落、没有有效的渲染边界或无法渲染，[Paragraph.getImage] 可能返回 `null`。在保存之前检查结果，并在使用完毕后释放返回的图像。

#### **以默认比例渲染段落**

以下文本框包含三个段落：

![包含三个段落的文本框](paragraph_to_image_input.png)

以下示例以默认比例渲染常规文本形状中的第二段，并以 PNG 格式保存返回的图像。`finally` 块确保正确释放图像。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

结果：

![段落图像](paragraph_to_image_output.png)

#### **在表格单元格中缩放渲染段落**

使用接受 `scaleX` 和 `scaleY` 参数的 [Paragraph.getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/#getImage) 重载来设置水平和垂直缩放因子。以下示例创建一个表格，在其第一个单元格中以默认宽高的两倍渲染段落，并将结果保存为 PNG 图像。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

比例因子为 `1` 时保持该轴的默认像素大小。例如，两个因子均为 `2` 会生成宽高约为默认尺寸两倍的图像，像素数量约为四倍。更大的因子通常能在放大或高分辨率输出时产生更清晰的文字，但也会增加内存使用和文件大小。低于 `1` 的因子会生成细节较少的较小图像。使用相等的因子可保持段落的宽高比；不同的水平和垂直因子会分别拉伸输出。

当输出必须包含形状的填充、边框或其他视觉上下文时，使用 [Shape.getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getImage) 渲染整个形状仍然有用。若只需段落图像，请使用 [Paragraph.getImage]。

## **常见问题**

**我可以完全禁用文本框内的自动换行吗？**

可以。将 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframeformat/setwraptext/) 设置为禁用换行，使行在文本框边缘处不换行。

**如何获取特定段落在幻灯片上的精确边界？**

使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/getrect/) 获取段落的边界矩形。[Portion.getRect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/#getRect) 提供单个文本段的边界。

**段落对齐（左、右、居中或两端对齐）在哪里控制？**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setalignment/) 是段落级别的设置，适用于整个段落，而不受单个文本段格式的影响。

**我可以为段落的一部分设置校对语言吗？**

可以。为各个文本段设置 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)，这样一个段落可以包含多种语言的文本。