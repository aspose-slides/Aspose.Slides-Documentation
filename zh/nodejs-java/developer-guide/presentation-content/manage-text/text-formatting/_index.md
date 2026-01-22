---
title: 在 JavaScript 中格式化 PowerPoint 文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/nodejs-java/text-formatting/
keywords:
- 突出显示文本
- 正则表达式
- 对齐段落
- 文本样式
- 文本背景
- 文本透明度
- 字符间距
- 字体属性
- 字体系列
- 文本旋转
- 旋转角度
- 文本框
- 行间距
- 自动适应属性
- 文本框锚点
- 文本制表符
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 和 Aspose.Slides for Node.js 在 PowerPoint 和 OpenDocument 演示文稿中格式化和美化文本。自定义字体、颜色、对齐方式等。"
---

## **突出显示文本**

Method [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-) has been added to [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) class and [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) class.

它允许使用文本示例通过背景色突出显示文本部分，类似于 PowerPoint 2019 中的文本突出显示颜色工具。

下面的代码片段演示了如何使用此功能：
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var textHighlightingOptions = new aspose.slides.TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("title", java.getStaticFieldValue("java.awt.Color", "BLUE"));// 突出显示所有单词 'important'
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), textHighlightingOptions);// 突出显示所有单独出现的 'the' 
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

Aspose 提供了一个简单的，[免费在线 PowerPoint 编辑服务](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **使用正则表达式突出显示文本**

Method [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-) has been added to [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) class and [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) class.

它允许使用正则表达式通过背景色突出显示文本部分，类似于 PowerPoint 2019 中的文本突出显示颜色工具。

下面的代码片段演示了如何使用此功能：
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var options = new aspose.slides.TextHighlightingOptions();
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.getStaticFieldValue("java.awt.Color", "YELLOW"), options);// 突出显示所有长度为10个字符或更长的单词
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置文本背景颜色**

Aspose.Slides allows you to specify your preferred color for the background of a text.

Aspose.Slides 允许您为文本的背景指定首选颜色。

以下 JavaScript 代码演示如何为整段文本设置背景颜色：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
const pres = new aspose.slides.Presentation("text.pptx");
try {
    const slide = pres.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    if (autoShape.getTextFrame() != null) {
        const paragraphs = autoShape.getTextFrame().getParagraphs();
        const paragraphCount = paragraphs.size();
        for (let i = 0; i < paragraphCount; i++) {
            const portions = paragraphs.get_Item(i).getPortions();
            const portionCount = portions.size();
            for (let j = 0; j < portionCount; j++) {
                const portion = portions.get_Item(j);
                portion.getPortionFormat().getHighlightColor().setColor(Color.BLUE);
            }
        }
    }
    pres.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


以下 JavaScript 代码演示如何仅为文本的一部分设置背景颜色：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
var presentation = new aspose.slides.Presentation("text.pptx");
try {
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var redPortion = java.callStaticMethodSync("StreamSupport", "stream", autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false).filter(p -> p.getText().contains("Red")).findFirst();
    if (redPortion.isPresent()) {
        redPortion.get().getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    presentation.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **对齐文本段落**

Text formatting is one of the key elements while creating any kind of documents or presentations. We know that Aspose.Slides for Node.js via Java supports adding text to slides but in this topic, we will see that how can we control the alignment of the text paragraphs in a slide. Please follow the steps below to align text paragraphs using Aspose.Slides for Node.js via Java:

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 使用索引获取幻灯片的引用。
3. 访问幻灯片中存在的占位符形状并将其强制转换为 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。
4. 从 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) 暴露的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getTextFrame--) 中获取需要对齐的 Paragraph。
5. 对 Paragraph 进行对齐。Paragraph 可以对齐到右、左、居中和两端对齐。
6. 将修改后的演示文稿写入 PPTX 文件。

下面给出上述步骤的实现示例。
```javascript
// 实例化一个表示 PPTX 文件的 Presentation 对象
var pres = new aspose.slides.Presentation("ParagraphsAlignment.pptx");
try {
    // 访问第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 访问幻灯片中的第一个和第二个占位符并将其强制转换为 AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // 修改两个占位符中的文本
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");
    // 获取占位符的第一个段落
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // 将文本段落居中对齐
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    // 将演示文稿写入 PPTX 文件
    pres.save("Centeralign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置文本透明度**

This article demonstrates how to set transparency property to any text shape using Aspose.Slides for Node.js via Java. In order to set the transparency to text. Please follow the steps below:

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 获取幻灯片的引用。
3. 设置阴影颜色。
4. 将演示文稿写入 PPTX 文件。

下面给出上述步骤的实现示例。
```javascript
var pres = new aspose.slides.Presentation("transparency.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();
    var outerShadowEffect = effects.getOuterShadowEffect();
    var shadowColor = outerShadowEffect.getShadowColor().getColor();
    console.log((shadowColor.toString() + " - transparency is: ") + ((shadowColor.getAlpha() / 255.0) * 100));
    // 将透明度设置为零百分比
    outerShadowEffect.getShadowColor().setColor(java.newInstanceSync("java.awt.Color", shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));
    pres.save("transparency-2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置文本字符间距**

Aspose.Slides allows you to set the space between letters in a textbox. This way, you get to adjust the visual density of a line or block of text by expanding or condensing the spacing between characters.

以下 JavaScript 代码演示如何为一行文本扩大间距以及为另一行文本压缩间距：
```javascript
var presentation = new aspose.slides.Presentation("in.pptx");
var textBox1 = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var textBox2 = presentation.getSlides().get_Item(0).getShapes().get_Item(1);
textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20);// 展开
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2);// 压缩
presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **管理段落的字体属性**

Presentations usually contain both text and images. The text can be formatted in a various ways, either to highlight specific sections and words, or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for Node.js via Java to configure the font properties of paragraphs of text on slides. To manage font properties of a paragraph using Aspose.Slides for Node.js via Java:

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 使用索引获取幻灯片的引用。
3. 访问幻灯片中的占位符形状并将其强制转换为 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。
4. 从 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) 暴露的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) 中获取 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame)。
5. 对段落进行两端对齐。
6. 访问段落的文本 Portion。
7. 使用 FontData 定义字体并相应地设置文本 Portion 的 Font。
   - 将字体设为粗体。
   - 将字体设为斜体。
8. 使用 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) 对象暴露的 [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#getFillFormat--) 设置字体颜色。
9. 将修改后的演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

下面给出上述步骤的实现示例。它采用一个未装饰的演示文稿并格式化其中一张幻灯片上的字体。
```javascript
// 实例化一个表示 PPTX 文件的 Presentation 对象
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // 使用幻灯片位置访问幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 访问幻灯片中的第一个和第二个占位符并将其强制转换为 AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // 访问第一个段落
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // 访问第一个 Portion
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // 定义新字体
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // 将新字体分配给 Portion
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // 将字体设置为粗体
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // 将字体设置为斜体
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // 设置字体颜色
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // 将 PPTX 写入磁盘
    pres.save("WelcomeFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **管理文本的字体系列**

A portion is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for Node.js via Java to create a textbox with some text and then define a particular font, and various other properties of the font family category. To create a textbox and set font properties of the text in it:

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 使用索引获取幻灯片的引用。
3. 将类型为 [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) 的 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) 添加到幻灯片。
4. 移除与该 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) 关联的填充样式。
5. 访问 AutoShape 的 TextFrame。
6. 向 TextFrame 添加一些文本。
7. 访问与该 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) 关联的 Portion 对象。
8. 为该 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) 定义要使用的字体。
9. 使用 Portion 对象暴露的相关属性设置粗体、斜体、下划线、颜色和高度等其他字体属性。
10. 将修改后的演示文稿写入 PPTX 文件。

下面给出上述步骤的实现示例。
```javascript
// 实例化 Presentation 对象
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加一个矩形类型的 AutoShape
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // 移除与 AutoShape 关联的任何填充样式
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 访问与 AutoShape 关联的 TextFrame
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // 访问与 TextFrame 关联的 Portion
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // 为 Portion 设置字体
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // 将字体设置为粗体
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // 将字体设置为斜体
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // 将字体设置为下划线
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // 设置字体高度
    port.getPortionFormat().setFontHeight(25);
    // 设置字体颜色
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // 将 PPTX 写入磁盘
    pres.save("SetTextFontProperties_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置文本字体大小**

Aspose.Slides allows you to choose your preferred font size for existing text in a paragraph and other texts that may be added to the paragraph later.

以下 JavaScript 代码演示如何为段落中的文本设置字体大小：
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // 获取第一个形状，例如。
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        var autoShape = shape;
        // 获取第一个段落，例如。
        var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
        // 为段落中所有文本块设置默认字体大小为20 pt。
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
        // 为段落中当前的文本块设置字体大小为20 pt。
        for (let i = 0; i < paragraph.getPortions().getCount(); i++) {
            let portion = paragraph.getPortions().get_Item(i);
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **设置文本旋转**

Aspose.Slides for Node.js via Java allows developers to rotate the text. Text could be set to appear as [Horizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#MongolianVertical) or [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). To rotate the text of any TextFrame, please follow the steps below:

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任意形状。
4. 访问 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。
5. [Rotate the text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setTextVerticalType-byte-)。
6. 将文件保存到磁盘。

```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加矩形类型的 AutoShape
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // 向矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 访问 TextFrame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // 为 TextFrame 创建 Paragraph 对象
    var para = txtFrame.getParagraphs().get_Item(0);
    // 为段落创建 Portion 对象
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 保存演示文稿
    pres.save("RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置 TextFrame 的自定义旋转角度**

Aspose.Slides for Node.js via Java now supports, Setting custom rotation angle for textframe. In this topic, we will see with example how to set the RotationAngle property in Aspose.Slides. The new methods [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) and [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--) have been added to [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) classs, allows to set the custom rotation angle for textframe. In order to set the RotationAngle, Please follow the steps below:

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 在幻灯片上添加图表。
3. [Set RotationAngle property](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-)。
4. 将演示文稿写入 PPTX 文件。

下面的示例演示如何设置 RotationAngle 属性。
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加矩形类型的 AutoShape
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // 向矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 访问 TextFrame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);
    // 为 TextFrame 创建 Paragraph 对象
    var para = txtFrame.getParagraphs().get_Item(0);
    // 为段落创建 Portion 对象
    var portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 保存演示文稿
    pres.save(resourcesOutputPath + "RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **段落行间距**

Aspose.Slides provides properties under [`ParagraphFormat`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat)—`SpaceAfter`, `SpaceBefore` and `SpaceWithin`—that allow you to manage the line spacing for a paragraph. The three properties are used this way:

* 要以百分比指定段落的行间距，请使用正值。 
* 要以磅指定段落的行间距，请使用负值。

例如，您可以将 `SpaceBefore` 属性设置为 -16，以实现 16pt 的段落行间距。

以下是为特定段落指定行间距的步骤：

1. 加载包含带有文本的 AutoShape 的演示文稿。
2. 通过索引获取幻灯片的引用。
3. 访问 TextFrame。
4. 访问 Paragraph。
5. 设置 Paragraph 属性。
6. 保存演示文稿。

以下 JavaScript 代码演示如何为段落指定行间距：
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // 通过索引获取幻灯片的引用
    var sld = pres.getSlides().get_Item(0);
    // 访问 TextFrame
    var tf1 = sld.getShapes().get_Item(0).getTextFrame();
    // 访问段落
    var para = tf1.getParagraphs().get_Item(0);
    // 设置段落属性
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    // 保存演示文稿
    pres.save("LineSpacing_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置 TextFrame 的 AutofitType 属性**

In this topic, we will explore the different formatting properties of text frame. This article covers how to Set the AutofitType property of text frame, anchor of text and rotating the text in presentation. Aspose.Slides for Node.js via Java allows developers to set AutofitType property of any text frame. AutofitType could be set to [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) or [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape). If set to [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) then shape will remain the same whereas the text will be adjusted without causing the shape to change itself whereas If AutofitType is set to [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape), then shape will be modified such that only required text is contained in it. To set the AutofitType property of a text frame, please follow the steps below:

1. 创建 [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)class.
2. 访问第一张幻灯片。
3. 向幻灯片添加任意形状。
4. 访问 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。
5. [Set the AutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType-byte-) of the TextFrame。
6. 将文件保存到磁盘。

```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加矩形类型的 AutoShape
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 150);
    // 向矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 访问 TextFrame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // 为 TextFrame 创建 Paragraph 对象
    var para = txtFrame.getParagraphs().get_Item(0);
    // 为段落创建 Portion 对象
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 保存演示文稿
    pres.save(resourcesOutputPath + "formatText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置 TextFrame 的锚点**

Aspose.Slides for Node.js via Java allows developers to Anchor of any TextFrame. TextAnchorType specifies that where is that text placed in the shape. AnchorType could be set to [Top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Justified) or [Distributed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Distributed). To set Anchor of any TextFrame, please follow the steps below:

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类。
2. 访问第一张幻灯片。
3. 向幻灯片添加任意形状。
4. 访问 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。
5. [Set TextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAnchoringType-byte-) of the TextFrame。
6. 将文件保存到磁盘。

```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加矩形类型的 AutoShape
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // 向矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 访问 TextFrame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(aspose.slides.TextAnchorType.Bottom);
    // 为 TextFrame 创建 Paragraph 对象
    var para = txtFrame.getParagraphs().get_Item(0);
    // 为段落创建 Portion 对象
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 保存演示文稿
    pres.save("AnchorText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **演示文稿中的制表符和 EffectiveTabs**

所有文本制表位均以像素为单位。

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2 Explicit Tabs and 2 Default Tabs**|
- EffectiveTabs.ExplicitTabCount（本例中为 2）属性等于 Tabs.Count。
- EffectiveTabs 集合包含所有制表位（来自 Tabs 集合和默认制表位）。
- EffectiveTabs.ExplicitTabCount（本例中为 2）属性等于 Tabs.Count。
- EffectiveTabs.DefaultTabSize（294）属性显示默认制表位之间的距离（本例中第 3 与第 4 个）。
- EffectiveTabs.GetTabByIndex(index) 当 index = 0 时返回第一个显式制表位（Position = 731），index = 1 返回第二个制表位（Position = 1241）。如果尝试使用 index = 2，则返回第一个默认制表位（Position = 1470），依此类推。
- EffectiveTabs.GetTabAfterPosition(pos) 用于获取某段文本之后的下一个制表位。例如有文本：“Hello World!”。要渲染该文本，需要先计算 “Hello” 的像素宽度，然后调用 GetTabAfterPosition 并传入该值，即可获得绘制 “world!” 的下一个制表位位置。

## **设置默认文本样式**

如果需要一次性为演示文稿的所有文本元素应用相同的默认文本格式，则可以使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的 `getDefaultTextStyle` 方法并设置首选的格式。下面的代码示例演示如何为新演示文稿中所有幻灯片的文本设置默认的粗体字体（14 pt）。
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 获取顶层段落格式。
    var paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);
    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    }
    presentation.save("DefaultTextStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **提取带全大写效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果会使幻灯片上的文本显示为大写，即使原始输入为小写。使用 Aspose.Slides 检索此类文本段时，库会返回原始输入的文本。为处理此情况，请检查 [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/)——如果它指示 `All`，则将返回的字符串转换为大写，以便输出与幻灯片上看到的效果一致。

假设我们在 sample2.pptx 文件的第一张幻灯片上有如下文本框。

![全大写效果](all_caps_effect.png)

下面的代码示例演示如何提取带 **All Caps** 效果的文本：
```js
var presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var autoShape = slide.getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    var textPortion = paragraph.getPortions().get_Item(0);

    console.log("Original text:", textPortion.getText());

    var textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == aspose.slides.TextCapType.All) {
        var text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect:", text);
    }
} finally {
    presentation.dispose();
}
```


Output:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **常见问题**

**如何在幻灯片的表格中修改文本？**

要在幻灯片的表格中修改文本，需要使用 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 对象。可以遍历表格中的所有单元格，通过访问每个单元格的 `TextFrame` 和 `ParagraphFormat` 属性来更改各单元格的文本。

**如何在 PowerPoint 幻灯片的文本上应用渐变颜色？**

要为文本应用渐变颜色，可在 [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) 中使用 Fill Format 属性。将 Fill Format 设置为 `Gradient`，并定义渐变的起始颜色和结束颜色，以及方向、透明度等其他属性，以在文本上创建渐变效果。