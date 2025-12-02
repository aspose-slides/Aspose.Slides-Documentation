---
title: 在演示文稿中使用 JavaScript 管理字体
linktitle: 管理字体
type: docs
weight: 10
url: /zh/nodejs-java/manage-fonts/
keywords:
- 管理字体
- 字体属性
- 段落
- 文本格式化
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 控制字体：嵌入、替换并加载自定义字体，以保持 PPT、PPTX 和 ODP 演示文稿的清晰和一致。"
---

## **管理字体相关属性**
{{% alert color="primary" %}} 

演示文稿通常包含文本和图像。文本可以以多种方式进行格式化，以突出显示特定的章节和单词，或符合公司样式。文本格式化帮助用户改变演示内容的外观和感受。本文展示了如何使用 Aspose.Slides for Node.js via Java 配置幻灯片上文本段落的字体属性。

{{% /alert %}} 

使用 Aspose.Slides for Node.js via Java 管理段落的字体属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 访问幻灯片中的 [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Placeholder) 形状，并将其强制转换为 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape)。
1. 从 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) 提供的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) 中获取 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Paragraph)。
1. 对段落进行两端对齐。
1. 访问 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Paragraph) 的文本 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion)。
1. 使用 [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/FontData) 定义字体，并相应地设置文本 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) 的 **Font**。
   1. 将字体设置为粗体。
   1. 将字体设置为斜体。
1. 使用 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) 对象提供的 [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/FillFormat) 设置字体颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下给出上述步骤的实现示例。它获取一个未经修饰的演示文稿，并在其中一张幻灯片上格式化字体。下面的截图展示了输入文件以及代码片段如何更改它。代码更改了字体、颜色和字体样式。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**图例：输入文件中的文本**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**图例：相同文本的更新后格式**|
```javascript
// 实例化一个表示 PPTX 文件的 Presentation 对象
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // 使用幻灯片位置访问幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 访问幻灯片中的第一个和第二个占位符，并将其强制转换为 AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // 访问第一个段落
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // 两端对齐段落
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // 访问第一个 Portion
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // 定义新字体
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // 将新字体分配给 Portion
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
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // 将 PPTX 保存到磁盘
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置文本字体属性**
{{% alert color="primary" %}} 

如 **管理字体相关属性** 中所述，[Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) 用于在段落中保存具有相似格式的文本。本文展示了如何使用 Aspose.Slides for Node.js via Java 创建一个包含文本的文本框，然后定义特定的字体以及字体族类别的各种其他属性。

{{% /alert %}} 

创建文本框并设置其中文本的字体属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 向幻灯片添加类型为 **Rectangle** 的 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape)。
1. 移除与 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) 关联的填充样式。
1. 访问 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) 的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame)。
1. 向 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) 添加一些文本。
1. 访问与 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) 关联的 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) 对象。
1. 为 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) 定义要使用的字体。
1. 使用 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) 对象提供的相关属性，设置其他字体属性，如粗体、斜体、下划线、颜色和高度。
1. 将修改后的演示文稿写入为 PPTX 文件。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**图例：由 Aspose.Slides for Node.js via Java 设置的带有部分字体属性的文本**|
```javascript
// 实例化一个表示 PPTX 文件的 Presentation 对象
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加矩形类型的 AutoShape
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // 移除与 AutoShape 关联的所有填充样式
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
    // 设置字体的颜色
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // 将演示文稿保存到磁盘
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
