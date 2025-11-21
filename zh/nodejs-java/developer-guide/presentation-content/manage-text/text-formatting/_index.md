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
- 字体族
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
description: "了解如何使用 Aspose.Slides for Node.js via Java 在 PowerPoint 和 OpenDocument 演示文稿中格式化和设置文本样式。通过强大的 JavaScript 示例代码自定义字体、颜色、对齐方式等。"
---

## **突出显示文本**

已向 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) 类添加了方法 [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-)，并已向 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) 类添加了该方法。

它允许使用文本示例通过背景颜色突出显示文本部分，类似于 PowerPoint 2019 中的“文本突出显示颜色”工具。

下面的代码片段展示了如何使用此功能：
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var textHighlightingOptions = new aspose.slides.TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("title", java.getStaticFieldValue("java.awt.Color", "BLUE"));// 突出显示所有 'important' 单词
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), textHighlightingOptions);// 突出显示所有单独的 'the' 出现
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
Aspose 提供了一个简单的、[免费在线 PowerPoint 编辑服务](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **使用正则表达式突出显示文本**

已向 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) 类添加了方法 [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-)，并已向 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) 类添加了该方法。

它允许使用正则表达式通过背景颜色突出显示文本部分，类似于 PowerPoint 2019 中的“文本突出显示颜色”工具。

下面的代码片段展示了如何使用此功能：
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var options = new aspose.slides.TextHighlightingOptions();
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.getStaticFieldValue("java.awt.Color", "YELLOW"), options);// 突出显示所有长度为 10 个字符或更长的单词
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置文本背景颜色**

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


以下 JavaScript 代码演示如何仅为文本的部分设置背景颜色：
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

文本格式是创建任何文档或演示文稿时的关键要素。我们知道 Aspose.Slides for Node.js via Java 支持向幻灯片添加文本，但在本主题中，我们将了解如何控制幻灯片中文本段落的对齐方式。请按照以下步骤使用 Aspose.Slides for Node.js via Java 对齐文本段落：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 使用索引获取幻灯片的引用。  
3. 访问幻灯片中的占位符形状并将其强制转换为 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。  
4. 从 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) 暴露的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getTextFrame--) 中获取需要对齐的 Paragraph。  
5. 对 Paragraph 进行对齐。段落可对齐到右、左、居中或两端对齐。  
6. 将修改后的演示文稿写入 PPTX 文件。

下面给出上述步骤的实现示例。
```javascript
// 实例化一个表示 PPTX 文件的 Presentation 对象
var pres = new aspose.slides.Presentation("ParagraphsAlignment.pptx");
try {
    // 访问第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 访问幻灯片中的第一个和第二个占位符，并将其强制转换为 AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // 更改两个占位符中的文本
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");
    // 获取占位符的第一段落
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // 将文本段落居中对齐
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    // 将演示文稿写入为 PPTX 文件
    pres.save("Centeralign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置文本透明度**

本文演示了如何使用 Aspose.Slides for Node.js via Java 为任意文本形状设置透明度属性。请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
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


## **设置字符间距**

Aspose.Slides 允许您设置文本框中字母之间的间距。通过调整字符间距，您可以改变一行或一段文字的视觉密度。

以下 JavaScript 代码演示如何为一行文本扩大间距、为另一行文本压缩间距：
```javascript
var presentation = new aspose.slides.Presentation("in.pptx");
var textBox1 = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var textBox2 = presentation.getSlides().get_Item(0).getShapes().get_Item(1);
textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20);// 展开
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2);// 压缩
presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **管理段落的字体属性**

演示文稿通常包含文本和图像。文本可以通过多种方式进行格式化，以突出显示特定部分或符合企业样式。文本格式化帮助用户改变演示内容的外观。本篇文章展示如何使用 Aspose.Slides for Node.js via Java 配置幻灯片上段落文本的字体属性。采用以下步骤管理段落的字体属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
1. 使用索引获取幻灯片的引用。  
1. 访问幻灯片中的占位符形状并将其强制转换为 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。  
1. 从 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) 暴露的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) 中获取 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame)。  
1. 对段落进行两端对齐。  
1. 访问段落的文本 Portion。  
1. 使用 FontData 定义字体，并相应设置 Portion 的 Font。  
   1. 将字体设为粗体。  
   1. 将字体设为斜体。  
1. 使用 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) 对象暴露的 [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#getFillFormat--) 设置字体颜色。  
1. 将修改后的演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

下面给出上述步骤的实现示例。它接受一个未做任何装饰的演示文稿，并对其中一张幻灯片的字体进行格式化。
```javascript
// 实例化一个表示 PPTX 文件的 Presentation 对象
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // 使用幻灯片位置访问幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 访问幻灯片中的第一个和第二个占位符，并将其强制转换为 AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // 获取第一段落
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // 获取第一段文本片段
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // 定义新字体
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // 将新字体分配给文本片段
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // 将字体设为粗体
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // 将字体设为斜体
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


## **管理文本的字体族**

Portion 用于在段落中保存具有相同格式的文本。本篇文章展示如何使用 Aspose.Slides for Node.js via Java 创建带有文本的文本框，并为其定义特定字体及其他字体族属性。操作步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 使用索引获取幻灯片的引用。  
3. 向幻灯片添加类型为 [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) 的 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。  
4. 移除与该 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) 关联的填充样式。  
5. 访问 AutoShape 的 TextFrame。  
6. 向 TextFrame 添加文本。  
7. 访问与该 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) 关联的 Portion 对象。  
8. 为该 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) 定义使用的字体。  
9. 使用 Portion 对象暴露的相关属性设置粗体、斜体、下划线、颜色和高度等其他字体属性。  
10. 将修改后的演示文稿写入 PPTX 文件。

下面给出上述步骤的实现示例。
```javascript
// 实例化 Presentation 对象
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加矩形类型的 AutoShape
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
    // 设置字体的粗体属性
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // 设置字体的斜体属性
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // 设置字体的下划线属性
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // 设置字体的高度
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


## **设置文本字号**

Aspose.Slides 允许您为段落中已存在的文本以及日后可能添加的文本选择首选字号。

以下 JavaScript 代码展示如何为段落中的文本设置字号：
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // 获取第一个形状，例如。
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        var autoShape = shape;
        // 获取第一段落，例如。
        var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
        // 将段落中所有文本片段的默认字体大小设置为 20 磅。
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
        // 将段落中当前文本片段的字体大小设置为 20 磅。
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

Aspose.Slides for Node.js via Java 允许开发者旋转文本。文本可设置为 [Horizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Horizontal)、[Vertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical)、[Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical270)、[WordArtVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVertical)、[EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#EastAsianVertical)、[MongolianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#MongolianVertical) 或 [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft)。要旋转任意 TextFrame 的文本，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 访问第一张幻灯片。  
3. 向幻灯片添加任意形状。  
4. 访问该形状的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。  
5. [旋转文本](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setTextVerticalType-byte-)。  
6. 将文件保存到磁盘。

下面给出实现示例。
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加矩形类型的 AutoShape
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // 为矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 访问文本框
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // 为文本框创建 Paragraph 对象
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


## **为 TextFrame 设置自定义旋转角度**

Aspose.Slides for Node.js via Java 现在支持为 TextFrame 设置自定义旋转角度。本文将通过示例说明如何在 Aspose.Slides 中设置 RotationAngle 属性。已在 [ChartTextBlockFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartTextBlockFormat) 和 [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) 类中添加了新方法 [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) 与 [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--)，以便为 TextFrame 设置自定义旋转角度。设置 RotationAngle，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 在幻灯片上添加图表。  
3. [设置 RotationAngle 属性](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-)。  
4. 将演示文稿写入 PPTX 文件。

下面的示例演示了如何设置 RotationAngle 属性。
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加矩形类型的 AutoShape
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // 为矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 访问文本框
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);
    // 为文本框创建 Paragraph 对象
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

Aspose.Slides 在 [`ParagraphFormat`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat) 下提供了 `SpaceAfter`、`SpaceBefore` 与 `SpaceWithin` 三个属性，可用于管理段落的行间距。这三个属性的使用方式如下：

* 若要以百分比指定段落的行间距，请使用正数值。  
* 若要以磅值指定段落的行间距，请使用负数值。

例如，将 `SpaceBefore` 属性设为 -16 即可为段落应用 16pt 的行间距。

以下步骤演示如何为特定段落指定行间距：

1. 加载包含带有文本的 AutoShape 的演示文稿。  
2. 通过索引获取幻灯片的引用。  
3. 访问 TextFrame。  
4. 访问 Paragraph。  
5. 设置 Paragraph 的属性。  
6. 保存演示文稿。

下面的 JavaScript 代码展示如何为段落指定行间距：
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // 根据索引获取幻灯片的引用
    var sld = pres.getSlides().get_Item(0);
    // 访问 TextFrame
    var tf1 = sld.getShapes().get_Item(0).getTextFrame();
    // 访问 Paragraph
    var para = tf1.getParagraphs().get_Item(0);
    // 设置 Paragraph 的属性
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


## **为 TextFrame 设置 AutofitType 属性**

本主题探讨 TextFrame 的不同格式化属性。本文介绍如何设置 TextFrame 的 AutofitType、文本锚点以及在演示文稿中旋转文本。Aspose.Slides for Node.js via Java 允许开发者为任意 TextFrame 设置 AutofitType 属性。AutofitType 可设为 [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) 或 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape)。设为 [Normal] 时，形状保持不变，文本自行适配；设为 [Shape] 时，形状会被调整以仅容纳所需文本。要设置 TextFrame 的 AutofitType，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 访问第一张幻灯片。  
3. 向幻灯片添加任意形状。  
4. 访问该形状的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。  
5. [设置 AutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType-byte-)。  
6. 将文件保存到磁盘。

下面给出实现示例。
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加矩形类型的 AutoShape
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 150);
    // 为矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 访问文本框
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // 为文本框创建 Paragraph 对象
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

Aspose.Slides for Node.js via Java 允许开发者为任意 TextFrame 设置锚点。TextAnchorType 指定文本在形状中的放置位置。锚点类型可设置为 [Top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Top)、[Center](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Center)、[Bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Bottom)、[Justified](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Justified) 或 [Distributed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Distributed)。要设置任意 TextFrame 的锚点，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 访问第一张幻灯片。  
3. 向幻灯片添加任意形状。  
4. 访问该形状的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。  
5. [设置 TextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAnchoringType-byte-)。  
6. 将文件保存到磁盘。

下面给出实现示例。
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加矩形类型的 AutoShape
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // 为矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // 访问文本框
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(aspose.slides.TextAnchorType.Bottom);
    // 为文本框创建 Paragraph 对象
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


## **Presentation 中的 Tabs 与 EffectiveTabs**

所有文本制表符均以像素为单位。

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**图例：2 个显式制表符和 2 个默认制表符**|

- EffectiveTabs.ExplicitTabCount（本例为 2）等于 Tabs.Count。  
- EffectiveTabs 集合包含所有制表符（包括 Tabs 集合中的以及默认制表符）。  
- EffectiveTabs.ExplicitTabCount（本例为 2）等于 Tabs.Count。  
- EffectiveTabs.DefaultTabSize（294）属性显示默认制表符之间的距离（本例中的第 3 与第 4 个制表符）。  
- 调用 EffectiveTabs.GetTabByIndex(index)，当 index=0 时返回第一个显式制表符（Position=731），index=1 时返回第二个显式制表符（Position=1241）。若 index=2 则返回第一个默认制表符（Position=1470），依此类推。  
- EffectiveTabs.GetTabAfterPosition(pos) 用于获取指定文本之后的下一个制表位。例如文本为 “Hello World!”。在渲染该文本前，需要先计算 “Hello” 的像素宽度，然后使用该值调用 GetTabAfterPosition，以获取绘制 “world!” 的下一个制表位置。

## **设置默认文本样式**

如果需要一次性为演示文稿中的所有文本元素应用相同的默认文本格式，可使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的 `getDefaultTextStyle` 方法并设置首选格式。下面的代码示例展示如何为新演示文稿中所有幻灯片的文本设置默认的粗体（14 pt）字体：
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 获取顶级段落格式。
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


## **提取带有 All-Caps 效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果后，即使原始文本是小写，幻灯片上也会显示为大写。当使用 Aspose.Slides 检索此类文本片段时，库会返回其原始输入形式。为保持输出与幻灯片显示一致，需要检查 [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/)——如果其值为 `All`，则将返回的字符串转换为大写。

假设在 sample2.pptx 文件的第一张幻灯片上有如下文本框：

![The All Caps effect](all_caps_effect.png)

下面的代码示例展示如何提取带有 **All Caps** 效果的文本：
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


输出：
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**如何修改幻灯片中表格的文本？**

要修改幻灯片中表格的文本，需要使用 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 对象。可以遍历表格的所有单元格，通过访问每个单元格的 `TextFrame` 和 `ParagraphFormat` 属性来更改相应的文本。

**如何在 PowerPoint 幻灯片中的文本上应用渐变颜色？**

要为文本应用渐变颜色，请在 [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) 中使用 Fill Format 属性。将 Fill Format 设置为 `Gradient`，并定义渐变的起始颜色和结束颜色，以及方向、透明度等其他属性，以实现文本的渐变效果。