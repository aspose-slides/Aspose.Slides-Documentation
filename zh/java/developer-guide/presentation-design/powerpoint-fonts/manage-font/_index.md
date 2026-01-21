---
title: 使用 Java 管理演示文稿中的字体
linktitle: 管理字体
type: docs
weight: 10
url: /zh/java/manage-fonts/
keywords:
- 管理字体
- 字体属性
- 段落
- 文本格式化
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides 控制字体：嵌入、替换并加载自定义字体，确保 PPT、PPTX 和 ODP 演示文稿保持清晰、品牌安全且一致。"
---

## **管理字体相关属性**
{{% alert color="primary" %}} 

演示文稿通常包含文本和图像。文本可以以多种方式进行格式化，以突出特定章节和单词，或遵循公司样式。文本格式化帮助用户改变演示内容的外观和感觉。本文展示如何使用 Aspose.Slides for Java 配置幻灯片上文本段落的字体属性。

{{% /alert %}} 

要使用 Aspose.Slides for Java 管理段落的字体属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
1. 通过使用索引获取幻灯片的引用。
1. 访问幻灯片中的 [Placeholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) 形状，并将其强制转换为 [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/)。
1. 从 [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) 所暴露的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) 中获取 [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/)。
1. 对段落进行两端对齐。
1. 访问 [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) 的文本 [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/)。
1. 使用 [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/) 定义字体，并相应地设置文本 [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) 的 **Font**。
   1. 将字体设为粗体。
   1. 将字体设为斜体。
1. 使用由 [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) 对象暴露的 [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) 设置字体颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

上述步骤的实现如下。它采用一个未装饰的演示文稿并对其中一张幻灯片的字体进行格式化。下面的截图展示了输入文件以及代码片段如何改变它。代码会更改字体、颜色和字体样式。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**图：输入文件中的文本**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**图：相同文本的更新后格式**|
```java
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// 使用幻灯片位置访问幻灯片
	ISlide slide = pres.getSlides().get_Item(0);

	// 访问幻灯片中的第一个和第二个占位符并将其强制转换为 AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// 访问第一个段落
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// 对段落进行两端对齐
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

如 **Managing Font Related Properties** 中所述，使用 [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) 来在段落中保存具有相似格式样式的文本。本文展示如何使用 Aspose.Slides for Java 创建一个带有文本的文本框，然后定义特定的字体以及字体族类别的其他各种属性。

{{% /alert %}} 

要创建文本框并设置其中文本的字体属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
1. 通过使用索引获取幻灯片的引用。
1. 向幻灯片添加类型为 **Rectangle** 的 [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/)。
1. 移除与 [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) 关联的填充样式。
1. 访问 [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/)。
1. 向 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) 添加一些文本。
1. 访问与 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) 关联的 [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) 对象。
1. 定义用于该 [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) 的字体。
1. 使用 [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) 对象暴露的相关属性设置其他字体属性，如粗体、斜体、下划线、颜色和高度。
1. 将修改后的演示文稿写入为 PPTX 文件。

上述步骤的实现如下。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**图：文本使用 Aspose.Slides for Java 设置的一些字体属性**|
```java
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation();
try {
	// 获取第一张幻灯片
	ISlide sld = pres.getSlides().get_Item(0);
	
	// 添加矩形类型的 AutoShape
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// 移除与 AutoShape 关联的任何填充样式
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// 访问与 AutoShape 关联的 TextFrame
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// 访问与 TextFrame 关联的 Portion
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
