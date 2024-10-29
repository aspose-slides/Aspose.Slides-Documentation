---
title: 管理字体 - PowerPoint Java API
linktitle: 管理字体
type: docs
weight: 10
url: /zh/androidjava/manage-fonts/
description: 演示文稿通常包含文本和图像。本文展示了如何使用 PowerPoint Java API 配置幻灯片上文本段落的字体属性。
---

## **管理字体相关属性**
{{% alert color="primary" %}} 

演示文稿通常包含文本和图像。文本可以以多种方式格式化，以突出特定的部分和单词或遵循企业风格。文本格式化帮助用户改变演示内容的外观和感觉。本文展示了如何通过 Java 使用 Aspose.Slides for Android 来配置幻灯片上文本段落的字体属性。

{{% /alert %}} 

使用 Aspose.Slides for Android 通过 Java 管理段落的字体属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
1. 通过使用索引获取幻灯片的引用。
1. 访问幻灯片中的 [Placeholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Placeholder) 形状并将其类型转换为 [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape)。
1. 从 [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape) 暴露的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) 中获取 [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Paragraph)。
1. 对段落进行对齐。
1. 访问 [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Paragraph) 的文本 [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion)。
1. 使用 [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/FontData) 定义字体，并相应地设置文本 [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) 的 **Font**。
   1. 将字体设置为粗体。
   1. 将字体设置为斜体。
1. 使用 [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) 对象暴露的 [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/FillFormat) 设置字体颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

上述步骤的实现如下。它接收一个未装饰的演示文稿并格式化其中一张幻灯片上的字体。接下来的截图显示了输入文件以及代码片段如何改变它。代码改变了字体、颜色和字体样式。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**图：输入文件中的文本**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**图：格式更新后的相同文本**|

```java
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// 使用幻灯片位置访问幻灯片
	ISlide slide = pres.getSlides().get_Item(0);

	// 访问幻灯片中的第一个和第二个占位符，并将其类型转换为 AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// 访问第一个段落
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// 对段落进行对齐
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// 访问第一个部分
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// 定义新字体
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// 将新字体分配给部分
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// 将字体设置为粗体
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// 将字体设置为斜体
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// 设置字体颜色
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// 将 PPTX 保存到磁盘
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **设置文本字体属性**
{{% alert color="primary" %}} 

如 **管理字体相关属性** 中提到的， [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) 用于在段落中持有具有相似格式样式的文本。本文展示了如何通过 Java 使用 Aspose.Slides for Android 创建一个文本框并设置一些文本，然后定义特定的字体以及字体家族类别的其他各种属性。

{{% /alert %}} 

要创建一个文本框并设置其中文本的字体属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
1. 通过使用索引获取幻灯片的引用。
1. 向幻灯片添加一个类型为 **Rectangle** 的 [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape)。
1. 移除与 [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape) 相关的填充样式。
1. 访问与 [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape) 相关的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame)。
1. 向 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) 添加一些文本。
1. 访问与 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) 相关的 [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) 对象。
1. 定义要用于 [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) 的字体。
1. 使用 [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) 对象暴露的相关属性设置其他字体属性，如粗体、斜体、下划线、颜色和高度。
1. 将修改后的演示文稿写入为 PPTX 文件。

上述步骤的实现如下。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**图：通过 Java 使用 Aspose.Slides for Android 设置的一些字体属性的文本**|

```java
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation();
try {
	// 获取第一张幻灯片
	ISlide sld = pres.getSlides().get_Item(0);
	
	// 添加一个矩形类型的 AutoShape
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// 移除与 AutoShape 相关的任何填充样式
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// 访问与 AutoShape 相关的 TextFrame
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// 访问与 TextFrame 相关的 Portion
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// 为 Portion 设置字体
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// 设置字体的粗体属性
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// 设置字体的斜体属性
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// 设置字体的下划线属性
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// 设置字体的高度
	port.getPortionFormat().setFontHeight(25);
	
	// 设置字体的颜色
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// 将演示文稿保存到磁盘
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```