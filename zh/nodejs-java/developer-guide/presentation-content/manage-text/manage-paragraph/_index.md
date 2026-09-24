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
- 添加文字
- 添加段落
- 管理文字
- 管理段落
- 管理项目符号
- 段落缩进
- 悬挂缩进
- 段落项目符号
- 编号列表
- 项目符号列表
- 段落属性
- 导入 HTML
- 文字转 HTML
- 段落转 HTML
- 段落转图像
- 文字转图像
- 导出段落
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 创建和格式化段落、段落块、项目符号、编号列表、缩进、HTML 内容以及段落图像。"
---
## **概述**

Aspose.Slides for Node.js via Java 将文本表示为文本框、段落和段落块的层次结构：

* [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 表示形状中的文本容器，并提供对其段落集合的访问。
* [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 表示文本框中的一个段落，并提供对其段落块和段落级格式的访问。
* [Portion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/) 表示段落中的一次文字运行。每个段落块可以拥有自己的文字和字符级格式。

因此，一个段落可以通过使用多个段落块来包含不同字体、颜色、大小和其他格式的文本。

## **创建并格式化段落**

### **创建包含多个段落块的段落**

以下步骤创建一个文本框，其中包含三个段落，每个段落包含三个段落块：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 向幻灯片添加一个矩形的 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
5. 使用默认段落并向文本框再添加两个 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 对象。
6. 为每个段落添加足够的 [Portion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/) 对象，使其包含三个段落块。默认段落已经包含一个空的段落块。
7. 设置每个段落块的文本。
8. 通过 [Portion.getPortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/getportionformat/) 应用字符级格式。
9. 保存修改后的演示文稿。

下面的 JavaScript 示例实现了上述步骤：

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

项目符号和编号可以让相关条目更易于浏览。在 Aspose.Slides 中，列表设置通过 [BulletFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/) 定义。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 向选定的幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
5. 从文本框中移除默认段落。
6. 为符号项目符号创建一个 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/)。
7. 将 [BulletFormat.setType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/settype/) 设置为 [BulletType.Symbol](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bullettype/)，并指定项目符号字符。
8. 设置段落文本、缩进、项目符号颜色和项目符号高度。
9. 将段落添加到文本框。
10. 创建第二个段落，并将 [BulletFormat.setType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/settype/) 设置为 [BulletType.Numbered](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bullettype/)。
11. 配置编号项目符号样式并将段落添加到文本框。
12. 保存演示文稿。

下面的 JavaScript 示例创建了一个符号项目符号和一个编号项目符号：

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

图片项目符号允许使用自定义图像替代符号或数字。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)，并访问其 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
4. 从文本框中移除默认段落。
5. 加载项目符号图像并将其作为 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/) 添加到演示文稿的图像集合中。
6. 创建一个 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 并设置其文本。
7. 将 [BulletFormat.setType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/settype/) 设置为 [BulletType.Picture](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bullettype/)。
8. 通过 [BulletFormat.getPicture](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/getpicture/) 指定图像，并设置项目符号高度。
9. 将段落添加到文本框。
10. 保存修改后的演示文稿。

下面的 JavaScript 示例创建了一个图片项目符号：

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

将 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setdepth/) 设置为不同的深度，以在列表中放置不同层级的段落。顶层深度为 `0`。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 并访问一张幻灯片。
2. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)，并清除其文本框中的默认段落。
3. 创建四个段落并配置它们的项目符号符号。
4. 将它们的 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setdepth/) 值分别设置为 `0`、`1`、`2`、`3`。
5. 将段落添加到文本框并保存演示文稿。

下面的 JavaScript 示例创建了一个四级项目符号列表：

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

### **为编号列表项设置自定义起始值**

使用 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 设置编号段落的起始编号。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 并向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
2. 清除形状文本框中的默认段落。
3. 创建三个编号段落。
4. 对相应段落调用 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 并分别设置为 `2`、`3`、`7`。
5. 将段落添加到文本框并保存演示文稿。

下面的 JavaScript 示例为每个段落分配了自定义起始编号：

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

使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 控制段落的首行缩进。该方法仅移动段落左侧边距相对的第一行。正值将第一行向右移动，而其余行保持与段落正文对齐。

需要整体移动段落时使用 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)。只想移动第一行时使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/)。

下面的示例创建了多个段落，并对它们应用不同的 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 值，以演示首行缩进对段落布局的影响。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形的 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 并移除默认段落。
5. 创建若干段落，并为它们设置不同的 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 值。
6. 将段落添加到文本框。
7. 保存修改后的演示文稿。

以下代码演示了如何设置段落缩进：

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

悬挂缩进是一种段落布局，首行位于其余行的左侧。在 Aspose.Slides 中，可通过 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 实现。传入负值即可使首行相对于段落正文向左移动。

实际使用中，[ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 定义段落正文的左侧位置，而 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 定义首行相对于该边距的位置。要创建悬挂缩进，请对 `setMarginLeft` 传入正值，对 `setIndent` 传入负值。

此类格式常用于参考文献、词条、术语表等，需要换行文本在段落正文下方对齐的场景。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形的 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 并移除默认段落。
5. 为每个段落调用 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 传入正值。
6. 对 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 传入负值，以产生悬挂缩进效果。
7. 将段落添加到文本框。
8. 保存修改后的演示文稿。

以下代码演示了如何为段落设置悬挂缩进：

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

### **设置段落结束属性**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) 控制段落结束标记的格式。以下示例为第二个段落的结束标记分配了字体大小和拉丁字体：

1. 创建或加载一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)，并访问一张幻灯片。
2. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)，并清除其默认段落。
3. 创建两个段落并向其中添加文字段落块。
4. 为第二个段落的结束标记创建一个 [PortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portionformat/)。
5. 调用 [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) 和 [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setLatinFont)。
6. 使用 [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) 应用该格式并保存演示文稿。

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

## **统计渲染行数**

使用 [Paragraph.getLinesCount](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/#getLinesCount) 可以统计段落在文本布局后占用的行数，包括自动换行。这在检查演示文稿模板中的文字长度和布局时非常有用。

段落是 [TextFrame.getParagraphs](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#getParagraphs) 中的一个项目，可能会占用多行渲染的空间。段落内部的显式换行会强制另起一行，而不会产生新的段落。自动换行则根据可用宽度生成行，而不会在文本中插入显式换行符。因此，仅统计段落数或换行符字符并不能得到渲染行数。

下面的示例创建一个文本形状，统计其行数，随后缩窄形状并用更短的字符串替换文本。示例启用了换行并禁用了自动适应，以便形状宽度控制换行，而不会自动缩小文字或调整形状大小。形状尺寸使用点（pt）为单位。最后，示例再添加一个段落，并对整个文本框的行数求和。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

使用上述文本和尺寸，缩窄形状会增加行数，而用短字符串替换文本会减少行数。确切的计数会受到字体可用性与替换、字体大小、页边距、缩进、换行和自动适应设置等因素的影响。检查模板时请使用目标环境的字体和布局设置。

仅凭行数并不能判断文本是否溢出容器。可用高度、行高、段落及行间距以及自动适应行为同样重要；即使是一行文字，在关闭换行的情况下也可能超过可用宽度。

## **导入与导出段落内容**

### **将 HTML 文本导入段落**

使用 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) 可将 HTML 标记转换为文本框中的段落和段落块。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 访问一张幻灯片并添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
3. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 并清除默认段落。
4. 定义或读取源 HTML 字符串。
5. 将 HTML 字符串传递给 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/)。
6. 保存修改后的演示文稿。

下面的 JavaScript 示例将 HTML 导入到文本框中：

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

使用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) 可将选定范围的段落导出为 HTML。

1. 创建或加载一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 实例。
2. 访问幻灯片并找到包含文本的 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
3. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
4. 调用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) 并传入起始段落索引和要导出的段落数量。
5. 将返回的 HTML 字符串写入文件。

下面的自包含 JavaScript 示例创建了一个文本形状并导出其所有段落：

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

[Paragraph.getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/#getImage) 直接渲染单个段落并返回一个 [IImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/)。使用 [IImage.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/#save) 将结果保存为文件。无需渲染包含的形状或手动裁剪位图。

如果段落未在其父集合中找到、没有有效的渲染边界，或无法渲染，[Paragraph.getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/#getImage) 可能返回 `null`。在保存之前请检查返回值，并在使用后释放图像资源。

#### **以默认比例渲染段落**

下面的文本框包含三个段落：

![包含三个段落的文本框](paragraph_to_image_input.png)

以下示例在默认比例下渲染第二段落，并以 PNG 格式保存返回的图像。`finally` 块确保图像被正确释放。

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

#### **在表格单元格中以缩放比例渲染段落**

使用接受 `scaleX` 和 `scaleY` 参数的 [Paragraph.getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/#getImage) 重载，可设置水平和垂直缩放因子。下面的示例创建一个表格，在其第一个单元格中以两倍默认宽高渲染段落，并将结果保存为 PNG 图像。

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

缩放因子为 `1` 时保持该轴的默认像素尺寸。例如，两个因子均设为 `2` 会生成宽高约为默认尺寸两倍的图像，像素数量约为四倍。更大的因子通常会在放大或高分辨率输出时产生更清晰的文字，但也会增加内存占用和文件大小。因子小于 `1` 会生成更小、细节更少的图像。使用相同的因子可保持段落的宽高比；不同的水平和垂直因子会独立拉伸输出。

在需要保留形状填充、边框或其他视觉上下文时，使用 [Shape.getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getImage) 渲染整个形状仍然有用。若仅需段落图像，请使用 [Paragraph.getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/#getImage)。

## **常见问题**

**我可以完全禁用文本框内的自动换行吗？**

可以。将 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframeformat/setwraptext/) 设置为禁用换行，以便行不会在文本框边缘断开。

**如何获取特定段落在幻灯片上的准确边界？**

使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/getrect/) 获取段落的边界矩形。[Portion.getRect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/#getRect) 提供单个段落块的边界。

**段落的对齐方式（左、右、居中或两端对齐）在哪里控制？**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setalignment/) 是段落级别的设置，适用于整个段落，独立于单个段落块的格式。

**我可以为段落的部分文字设置校对语言吗？**

可以。为单个段落块调用 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)，即可在同一段落中包含多种语言的文字。