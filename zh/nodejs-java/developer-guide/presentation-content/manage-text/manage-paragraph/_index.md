---
title: 管理 JavaScript 中的 PowerPoint 文本段落
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
description: "使用 Aspose.Slides for Node.js（通过 Java），在 PPT、PPTX 和 ODP 演示文稿中通过 JavaScript 优化段落的对齐、间距和样式。"
---

Aspose.Slides 提供了处理 PowerPoint 文本、段落和部分所需的所有类，适用于 Java。

* Aspose.Slides 提供了 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) 类，以便您添加表示段落的对象。`TextFame` 对象可以包含一个或多个段落（每个段落通过回车创建）。
* Aspose.Slides 提供了 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 类，以便您添加表示部分的对象。`Paragraph` 对象可以包含一个或多个部分（文本部分对象的集合）。
* Aspose.Slides 提供了 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) 类，以便您添加表示文本及其格式属性的对象。

`Paragraph` 对象能够通过其底层的 `Portion` 对象处理具有不同格式属性的文本。

## **添加包含多个部分的多个段落**

以下步骤演示如何添加一个包含 3 个段落且每个段落包含 3 个部分的文本框：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)。
4. 获取与该 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) 关联的 ITextFrame。
5. 创建两个 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 对象并将它们添加到 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) 的 `IParagraphs` 集合中。
6. 为每个新 `Paragraph` 创建三个 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) 对象（默认 Paragraph 创建两个 Portion 对象），并将每个 `Portion` 对象添加到相应 `Paragraph` 的 IPortion 集合中。
7. 为每个部分设置一些文本。
8. 使用 `Portion` 对象公开的格式属性为每个部分应用您偏好的格式功能。
9. 保存修改后的演示文稿。

```javascript
// 实例化一个表示 PPTX 文件的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加矩形类型的 AutoShape
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // 访问 AutoShape 的 TextFrame
    var tf = ashp.getTextFrame();
    // 创建具有不同文本格式的段落和部分
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

项目符号列表帮助您快速高效地组织和展示信息。使用项目符号的段落更易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向选定的幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)。
4. 访问该自动形状的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 将段落的 bullet `Type` 设置为 `Symbol` 并设置项目符号字符。
8. 设置段落的 `Text`。
9. 为项目符号设置段落的 `Indent`。
10. 为项目符号设置颜色。
11. 为项目符号设置高度。
12. 将新段落添加到 `TextFrame` 的段落集合中。
13. 添加第二个段落并重复步骤 7 到 13 中的过程。
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
    // 删除默认段落
    txtFrm.getParagraphs().removeAt(0);
    // 创建段落
    var para = new aspose.slides.Paragraph();
    // 设置段落项目符号样式和符号
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // 设置段落文本
    para.setText("Welcome to Aspose.Slides");
    // 设置项目符号缩进
    para.getParagraphFormat().setIndent(25);
    // 设置项目符号颜色
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// 设置 IsBulletHardColor 为 true 以使用自定义项目符号颜色
    // 设置项目符号高度
    para.getParagraphFormat().getBullet().setHeight(100);
    // 将段落添加到文本框
    txtFrm.getParagraphs().add(para);
    // 创建第二个段落
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
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// 设置 IsBulletHardColor 为 true 以使用自定义项目符号颜色
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

图片列表帮助您快速高效地组织和展示信息。图片段落易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)。
4. 访问该自动形状的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 在 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 中加载图像。
8. 将项目符号类型设置为 [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 并设置图像。
9. 设置段落的 `Text`。
10. 为项目符号设置段落的 `Indent`。
11. 为项目符号设置颜色。
12. 为项目符号设置高度。
13. 将新段落添加到 `TextFrame` 的段落集合中。
14. 添加第二个段落并根据前述步骤重复操作。
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
    // 访问 AutoShape 的 TextFrame
    var textFrame = autoShape.getTextFrame();
    // 删除默认段落
    textFrame.getParagraphs().removeAt(0);
    // 创建新段落
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // 设置段落项目符号样式和图像
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // 设置项目符号高度
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // 将段落添加到 TextFrame
    textFrame.getParagraphs().add(paragraph);
    // 将演示文稿另存为 PPTX 文件
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // 将演示文稿另存为 PPT 文件
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **管理多级项目符号**

多级项目符号帮助您快速高效地组织和展示信息。多级项目符号易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 在新幻灯片中添加一个 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)。
4. 访问该自动形状的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 类创建第一个段落实例，并将深度设置为 0。
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
    // 访问已创建 AutoShape 的文本框
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
    // 将演示文稿写入为 PPTX 文件
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **管理带自定义编号列表的段落**

[BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) 类提供了 [NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) 属性等，可帮助您管理带自定义编号或格式的段落。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 访问包含该段落的幻灯片。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)。
4. 访问该自动形状的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 类创建第一个段落实例，并将 [NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) 设置为 2。
7. 通过 `Paragraph` 类创建第二个段落实例，并将 `NumberedBulletStartWith` 设置为 3。
8. 通过 `Paragraph` 类创建第三个段落实例，并将 `NumberedBulletStartWith` 设置为 7。
9. 将新段落添加到 `TextFrame` 的段落集合中。
10. 保存修改后的演示文稿。

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 访问已创建自动形状的文本框
    var textFrame = shape.getTextFrame();
    // 删除默认的已存在段落
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


## **设置段落缩进**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。  
1. 通过索引访问相应幻灯片的引用。  
1. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)。  
1. 向矩形自动形状添加一个带有三个段落的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)。  
1. 隐藏矩形的线条。  
1. 通过段落的 BulletOffset 属性为每个 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 设置缩进。  
1. 将修改后的演示文稿写入为 PPT 文件。

```javascript
// 实例化 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加矩形形状
    var rect = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 150);
    // 向矩形添加 TextFrame
    var tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
    // 设置文本以适应形状
    tf.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // 隐藏矩形的线条
    rect.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    // 获取 TextFrame 中的第一段落并设置其缩进
    var para1 = tf.getParagraphs().get_Item(0);
    // 设置段落项目符号样式和符号
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para1.getParagraphFormat().setDepth(2);
    para1.getParagraphFormat().setIndent(30);
    // 获取 TextFrame 中的第二段落并设置其缩进
    var para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar(8226);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para2.getParagraphFormat().setDepth(2);
    para2.getParagraphFormat().setIndent(40);
    // 获取 TextFrame 中的第三段落并设置其缩进
    var para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para3.getParagraphFormat().setDepth(2);
    para3.getParagraphFormat().setIndent(50);
    // 将演示文稿写入磁盘
    pres.save("InOutDent_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置段落悬挂缩进**

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 250, 550, 150);
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Example");
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Set Hanging Indent for Paragraph");
    var para3 = new aspose.slides.Paragraph();
    para3.setText("This code shows you how to set the hanging indent for a paragraph: ");
    para2.getParagraphFormat().setMarginLeft(10.0);
    para3.getParagraphFormat().setMarginLeft(20.0);
    autoShape.getTextFrame().getParagraphs().add(para1);
    autoShape.getTextFrame().getParagraphs().add(para2);
    autoShape.getTextFrame().getParagraphs().add(para3);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **管理段落结束运行属性**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。  
1. 通过位置获取包含该段落的幻灯片的引用。  
1. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)。  
1. 向矩形添加一个带有两个段落的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)。  
1. 为段落设置 `FontHeight` 和字体类型。  
1. 为段落设置 End 属性。  
1. 将修改后的演示文稿写入为 PPTX 文件。

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

Aspose.Slides 为将 HTML 文本导入段落提供了增强的支持。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引访问相应幻灯片的引用。  
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)。  
4. 添加并访问 `AutoShape` 的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)。  
5. 删除 `TextFrame` 中的默认段落。  
6. 在 TextReader 中读取源 HTML 文件。  
7. 通过 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 类创建第一个段落实例。  
8. 将读取的 TextReader 中的 HTML 内容添加到 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/)。  
9. 保存修改后的演示文稿。

```javascript
// 创建空的演示文稿实例
var pres = new aspose.slides.Presentation();
try {
    // 访问演示文稿的默认第一页
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
    // 将 HTML 流读取器的文本添加到文本框中
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

Aspose.Slides 为将段落中的文本导出为 HTML 提供了增强的支持。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例并加载所需的演示文稿。  
2. 通过索引访问相应幻灯片的引用。  
3. 访问包含要导出为 HTML 的文本的形状。  
4. 访问该形状的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)。  
5. 创建一个 `StreamWriter` 实例并添加新的 HTML 文件。  
6. 为 StreamWriter 提供起始索引并导出您偏好的段落。

```javascript
// 加载演示文稿文件
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // 访问演示文稿的默认第一页
    var slide = pres.getSlides().get_Item(0);
    // 所需的索引
    var index = 0;
    // 访问已添加的形状
    var ashape = slide.getShapes().get_Item(index);
    // 创建输出 HTML 文件
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // 将首段提取为 HTML
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

在本节中，我们将通过两个示例演示如何将由 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 类表示的文本段落保存为图像。这两个示例都包括使用 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 类的 `getImage` 方法获取包含段落的形状图像，计算段落在形状中的边界，并将其导出为位图图像。这些方法使您能够从 PowerPoint 演示文稿中提取特定文本部分并将其保存为单独的图像，便于在各种场景中进一步使用。

假设我们有一个名为 sample.pptx 的演示文稿文件，包含一张幻灯片，其中第一个形状是一个包含三个段落的文本框。

![包含三个段落的文本框](paragraph_to_image_input.png)

**示例 1**

在本示例中，我们获取第二个段落的图像。为此，我们从演示文稿的第一张幻灯片中提取形状的图像，然后计算该形状文本框中第二个段落的边界。随后将段落重新绘制到新的位图图像中，并以 PNG 格式保存。该方法在需要将特定段落保存为单独图像且保持文本的精确尺寸和格式时特别有用。
```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 将形状保存为内存中的位图。
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

    // 计算第二段的边界。
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

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


结果：

![段落图像](paragraph_to_image_output.png)

**示例 2**

在本示例中，我们在前一种方法的基础上为段落图像添加了缩放因子。首先从演示文稿中提取形状并以 `2` 的缩放因子保存为图像，这在导出段落时可获得更高分辨率的输出。随后在考虑缩放的情况下计算段落的边界。缩放在需要更高细节图像的场景（例如用于高质量印刷材料）中特别有用。
```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 将形状保存为内存中的位图并使用缩放。
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

    // 计算第二段的边界。
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

**我能完全禁用文本框内的换行吗？**

可以。使用文本框的换行设置（[setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/)）将换行关闭，即可防止文本在框边缘换行。

**如何获取特定段落在幻灯片上的精确边界？**

您可以检索段落（甚至单个部分）的边界矩形，以了解其在幻灯片上的确切位置和大小。

**段落的对齐方式（左/右/居中/两端对齐）在哪里控制？**

[setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) 是 [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/) 中针对段落级别的设置方法；它适用于整个段落，而不受各部分单独格式的影响。

**我能为段落的某一部分（例如单词）设置拼写检查语言吗？**

可以。语言在部分级别设置（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)），因此一个段落中可以并存多种语言。