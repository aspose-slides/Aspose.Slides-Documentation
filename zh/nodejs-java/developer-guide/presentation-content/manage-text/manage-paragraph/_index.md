---
title: 在 JavaScript 中管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh/nodejs-java/manage-paragraph/
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
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "通过 Aspose.Slides for Node.js（基于 Java）掌握段落格式化——在 PPT、PPTX 和 ODP 演示文稿中优化对齐、间距和样式（JavaScript）。"
---
Aspose.Slides 提供了在 Java 中处理 PowerPoint 文本、段落和片段所需的所有类。

* Aspose.Slides 提供了 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 类，允许您添加表示段落的对象。`TextFame` 对象可以包含一个或多个段落（每个段落通过回车创建）。
* Aspose.Slides 提供了 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 类，允许您添加表示片段的对象。`Paragraph` 对象可以包含一个或多个片段（文本片段对象的集合）。
* Aspose.Slides 提供了 [Portion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/) 类，允许您添加表示文本及其格式属性的对象。

`Paragraph` 对象能够通过其底层的 `Portion` 对象处理具有不同格式属性的文本。

## **添加包含多个片段的多个段落**

以下步骤演示如何添加一个包含 3 个段落且每个段落包含 3 个片段的文本框：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相关幻灯片的引用。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 获取与 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/) 关联的 ITextFrame。
5. 创建两个 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 对象，并将它们添加到 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 的 `IParagraphs` 集合中。
6. 为每个新 `Paragraph` 创建三个 [Portion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/) 对象（默认 Paragraph 为两个 Portion 对象），并将每个 `Portion` 对象添加到相应 `Paragraph` 的 IPortion 集合中。
7. 为每个片段设置一些文本。
8. 使用 `Portion` 对象公开的格式属性，为每个片段应用您首选的格式设置。
9. 保存修改后的演示文稿。

```javascript
// 实例化一个表示 PPTX 文件的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加一个矩形类型的 AutoShape
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // 访问 AutoShape 的 TextFrame
    var tf = ashp.getTextFrame();
    // 创建具有不同文本格式的段落和片段
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // 将 PPTX 写入磁盘
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **管理段落项目符号**

项目符号列表帮助您快速高效地组织和呈现信息。使用项目符号的段落更易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相关幻灯片的引用。
3. 向选定的幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 访问 AutoShape 的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 将段落的项目符号 `Type` 设置为 `Symbol`，并设置项目符号字符。
8. 设置段落的 `Text`。
9. 为项目符号设置段落的 `Indent`。
10. 设置项目符号的颜色。
11. 设置项目符号的高度。
12. 将新段落添加到 `TextFrame` 的段落集合中。
13. 添加第二个段落并重复步骤 7 至 12 中的过程。
14. 保存演示文稿。

```javascript
// 实例化一个表示 PPTX 文件的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加并访问 AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 访问 AutoShape 的文本框
    var txtFrm = aShp.getTextFrame();
    // 移除默认段落
    txtFrm.getParagraphs().removeAt(0);
    // 创建段落
    var para = new aspose.slides.Paragraph();
    // 设置段落的项目符号样式和符号
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // 设置段落文本
    para.setText("Welcome to Aspose.Slides");
    // 设置项目符号缩进
    para.getParagraphFormat().setIndent(25);
    // 设置项目符号颜色
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// 将 IsBulletHardColor 设置为 true 以使用自定义项目符号颜色
    // 设置项目符号高度
    para.getParagraphFormat().getBullet().setHeight(100);
    // 将段落添加到文本框
    txtFrm.getParagraphs().add(para);
    // 创建第二段落
    var para2 = new aspose.slides.Paragraph();
    // 设置段落项目符号类型和样式
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // 添加段落文本
    para2.setText("This is numbered bullet");
    // 设置项目符号缩进
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// 将 IsBulletHardColor 设置为 true 以使用自定义项目符号颜色
    // 设置项目符号高度
    para2.getParagraphFormat().getBullet().setHeight(100);
    // 将段落添加到文本框
    txtFrm.getParagraphs().add(para2);
    // 保存修改后的演示文稿
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **管理图片项目符号**

项目符号列表帮助您快速高效地组织和呈现信息。图片段落易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相关幻灯片的引用。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 访问 AutoShape 的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 在 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/) 中加载图像。
8. 将项目符号类型设置为 [Picture](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/) 并设定图像。
9. 设置段落的 `Text`。
10. 为项目符号设置段落的 `Indent`。
11. 设置项目符号的颜色。
12. 设置项目符号的高度。
13. 将新段落添加到 `TextFrame` 的段落集合中。
14. 添加第二个段落并重复上述步骤。
15. 保存修改后的演示文稿。

```javascript
// 实例化一个表示 PPTX 文件的 Presentation 类
var presentation = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var slide = presentation.getSlides().get_Item(0);
    // 实例化用于项目符号的图像
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 添加并访问 AutoShape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 访问 AutoShape 的文本框
    var textFrame = autoShape.getTextFrame();
    // 移除默认段落
    textFrame.getParagraphs().removeAt(0);
    // 创建新段落
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // 设置段落的项目符号样式和图像
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // 设置项目符号高度
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // 将段落添加到文本框
    textFrame.getParagraphs().add(paragraph);
    // 将演示文稿保存为 PPTX 文件
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // 将演示文稿保存为 PPT 文件
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **管理多级项目符号**

项目符号列表帮助您快速高效地组织和呈现信息。多级项目符号易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相关幻灯片的引用。
3. 在新幻灯片中添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 访问 AutoShape 的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 类创建第一个段落实例，并将深度设置为 0。
7. 通过 `Paragraph` 类创建第二个段落实例，并将深度设置为 1。
8. 通过 `Paragraph` 类创建第三个段落实例，并将深度设置为 2。
9. 通过 `Paragraph` 类创建第四个段落实例，并将深度设置为 3。
10. 将新段落添加到 `TextFrame` 的段落集合中。
11. 保存修改后的演示文稿。

```javascript
// 实例化一个表示 PPTX 文件的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加并访问 AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 访问创建的 AutoShape 的文本框
    var text = aShp.addTextFrame("");
    // 清除默认段落
    text.getParagraphs().clear();
    // 添加第一段落
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 设置项目符号级别
    para1.getParagraphFormat().setDepth(0);
    // 添加第二段落
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 设置项目符号级别
    para2.getParagraphFormat().setDepth(1);
    // 添加第三段落
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 设置项目符号级别
    para3.getParagraphFormat().setDepth(2);
    // 添加第四段落
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 设置项目符号级别
    para4.getParagraphFormat().setDepth(3);
    // 将段落添加到集合中
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // 将演示文稿保存为 PPTX 文件
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **管理具有自定义编号列表的段落**

[BulletFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/) 类提供了 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) 属性等，可用于管理具有自定义编号或格式的段落。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 访问包含该段落的幻灯片。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 访问 AutoShape 的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 类创建第一个段落实例，并将 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) 设置为 2。
7. 通过 `Paragraph` 类创建第二个段落实例，并将 `NumberedBulletStartWith` 设置为 3。
8. 通过 `Paragraph` 类创建第三个段落实例，并将 `NumberedBulletStartWith` 设置为 7。
9. 将新段落添加到 `TextFrame` 的段落集合中。
10. 保存修改后的演示文稿。

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 访问创建的 AutoShape 的文本框
    var textFrame = shape.getTextFrame();
    // 移除默认的已有段落
    textFrame.getParagraphs().removeAt(0);
    // 第一个列表
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **为段落设置首行缩进**

使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 方法可控制段落的首行缩进。该方法仅移动相对于段落左侧边距的第一行。正值会将首行向右移动，而其余行保持与段落正文对齐。

在需要移动整段时使用 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setmarginleft/)。仅需移动首行时使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/)。

下面的示例创建了多个段落，并对它们应用不同的缩进值，以演示首行缩进对段落布局的影响。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 向形状添加一个空的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 并移除默认段落。
5. 创建多个段落并为它们设置不同的 [Indent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 值。
6. 将段落添加到文本框中。
7. 保存修改后的演示文稿。

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

结果：

![段落的首行缩进](first_line_indent.png)

## **为段落设置悬挂缩进**

悬挂缩进是一种段落布局，其中第一行相对于其余行向左开始。在 Aspose.Slides 中，可使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 方法实现此效果。将缩进设为负值，即可使第一行相对于段落正文向左移动。

在实际使用中，[ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 定义段落正文的左侧位置，而 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 定义第一行相对于该左侧边距的位置。要实现悬挂缩进，需将 `MarginLeft` 设为正值，将 `Indent` 设为负值。

此格式在参考文献、词汇表条目等需要第二行及之后的行对齐到段落正文下方的场景中非常有用。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 向形状添加一个空的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 并移除默认段落。
5. 为每个段落设置正的 [MarginLeft](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) 值。
6. 设置负的 [Indent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setindent/) 值以创建悬挂缩进效果。
7. 将段落添加到文本框中。
8. 保存修改后的演示文稿。

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

结果：

![段落的悬挂缩进](hanging_indent.png)

## **管理段落的结束运行属性**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过位置获取包含该段落的幻灯片的引用。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 向矩形添加一个包含两个段落的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
5. 设置段落的 `FontHeight` 和字体类型。
6. 为段落设置 End 属性。
7. 将修改后的演示文稿写入为 PPTX 文件。

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **将 HTML 文本导入段落**

Aspose.Slides 提供了增强的 HTML 文本导入到段落的支持。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相关幻灯片的引用。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
4. 添加并访问 `AutoShape` 的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的默认段落。
6. 使用 TextReader 读取源 HTML 文件。
7. 通过 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 类创建第一个段落实例。
8. 将读取的 TextReader 中的 HTML 文件内容添加到 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphcollection/) 中。
9. 保存修改后的演示文稿。

```javascript
// 创建空的演示文稿实例
var pres = new aspose.slides.Presentation();
try {
    // 访问演示文稿的默认第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加 AutoShape 以容纳 HTML 内容
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 向形状添加文本框
    ashape.addTextFrame("");
    // 清除已添加文本框中的所有段落
    ashape.getTextFrame().getParagraphs().clear();
    // 使用流读取器加载 HTML 文件
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // 将 HTML 流读取器中的文本添加到文本框
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // 保存演示文稿
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **将段落文本导出为 HTML**

Aspose.Slides 提供了增强的将段落中的文本导出为 HTML 的支持。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例并加载所需的演示文稿。
2. 通过索引访问相关幻灯片的引用。
3. 访问将要导出为 HTML 的文本所在的形状。
4. 访问该形状的 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。
5. 创建 `StreamWriter` 实例并添加新的 HTML 文件。
6. 为 StreamWriter 提供起始索引并导出您选择的段落。

```javascript
// 加载演示文稿文件
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // 访问演示文稿的默认第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 所需索引
    var index = 0;
    // 访问已添加的形状
    var ashape = slide.getShapes().get_Item(index);
    // 创建输出 HTML 文件
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // 将第一段落提取为 HTML
    // 通过提供段落起始索引和要复制的段落总数，将段落数据写入 HTML
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **将段落保存为图像**

在本节中，我们将展示两个示例，演示如何将由 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 类表示的文本段落保存为图像。这些示例都包括使用 [Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/) 类的 `getImage` 方法获取包含段落的形状图像，计算段落在形状中文本框的边界，并将其导出为位图图像。这些方法可帮助您从 PowerPoint 演示文稿中提取特定文本并保存为独立图像，以便在各种场景中进一步使用。

假设我们有一个名为 sample.pptx 的演示文稿，只有一张幻灯片，第一 个形状是包含三个段落的文本框。

![包含三个段落的文本框](paragraph_to_image_input.png)

**示例 1**

在此示例中，我们获取第二个段落的图像。为此，我们先从演示文稿的第一张幻灯片中提取形状图像，然后计算该形状文本框中第二个段落的边界。随后将该段落重新绘制到新的位图图像中，并以 PNG 格式保存。此方法在需要将特定段落单独保存为图像且保持文本的精确尺寸和格式时特别有用。

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 将形状保存到内存中为位图。
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // 从内存创建形状位图。
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // 计算第二段落的边界。
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // 计算输出图像的坐标和尺寸（最小大小 - 1x1 像素）。
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // 裁剪形状位图，仅获取段落位图。
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

结果：

![段落图像](paragraph_to_image_output.png)

**示例 2**

在此示例中，我们在前一种方法的基础上为段落图像添加了缩放因子。形状从演示文稿中提取，并以 `2` 的缩放因子保存为图像，从而在导出段落时获得更高分辨率的输出。随后在考虑缩放的情况下计算段落边界。缩放在需要更高细节的图像时非常有用，例如用于高质量印刷材料。

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 将形状以缩放方式保存为内存中的位图。
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // 从内存创建形状位图。
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // 计算第二段落的边界。
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // 计算输出图像的坐标和尺寸（最小尺寸为 1x1 像素）。
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // 裁剪形状位图，仅获取段落位图。
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **常见问题**

**我可以完全禁用文本框内的自动换行吗？**

可以。使用文本框的换行设置 ([setWrapText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframeformat/setwraptext/)) 将换行关闭，行就不会在框边缘处断开。

**如何获取特定段落在幻灯片上的精确边界？**

您可以检索段落（甚至单个片段）的边界矩形，以了解其在幻灯片上的精确位置和尺寸。

**段落的对齐方式（左/右/居中/两端对齐）在哪里进行控制？**

[setAlignment](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/setalignment/) 是 [ParagraphFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraphformat/) 中的段落级设置方法；它适用于整个段落，不受单个片段格式的影响。

**我可以仅为段落的一部分（例如一个单词）设置拼写检查语言吗？**

可以。语言在片段级别设置 ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setLanguageId))，因此一个段落中可以共存多种语言。