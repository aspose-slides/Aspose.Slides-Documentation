---
title: 在 Android 上格式化 PowerPoint 文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/androidjava/text-formatting/
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
- 文本制表
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化和样式设置。自定义字体、颜色、对齐方式等。"
---

## **突出显示文本**
Method [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) has been added to [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) interface and [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) class.

它允许使用文本示例通过背景颜色高亮文本片段，类似于 PowerPoint 2019 中的“文本突出显示颜色”工具。

下面的代码片段演示了如何使用此功能：
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // 突出显示所有单词 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// 突出显示所有单独的 'the' 出现
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

Aspose 提供了一个简单的[免费在线 PowerPoint 编辑服务](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **使用正则表达式高亮文本**
Method [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) has been added to [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) interface and [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) class.

它允许使用正则表达式通过背景颜色高亮文本片段，类似于 PowerPoint 2019 中的“文本突出显示颜色”工具。

下面的代码片段演示了如何使用此功能：
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // 突出显示所有 10 个符号或更长的单词
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **设置文本背景颜色**
Aspose.Slides 允许您为文本的背景指定首选颜色。

以下 Java 代码演示了如何为整段文本设置背景颜色：
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Black");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Red ");

    Portion portion3 = new Portion("Black");
    portion3.getPortionFormat().setFontBold(NullableBool.True);

    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);

    pres.save("text.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

Presentation presentation = new Presentation("text.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    StreamSupport.stream(autoShape.getTextFrame().getParagraphs().spliterator(), false)
            .map(p -> p.getPortions())
            .forEach(c -> c.forEach(ic -> ic.getPortionFormat().getHighlightColor().setColor(Color.BLUE)));

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


以下 Java 代码演示了如何仅为文本的一部分设置背景颜色：
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Black");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Red ");

    Portion portion3 = new Portion("Black");
    portion3.getPortionFormat().setFontBold(NullableBool.True);
    
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    
    pres.save("text.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

Presentation presentation = new Presentation("text.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    Optional<IPortion> redPortion = StreamSupport.stream(autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false)
            .filter(p -> p.getText().contains("Red"))
            .findFirst();

    if(redPortion.isPresent())
        redPortion.get().getPortionFormat().getHighlightColor().setColor(Color.RED);

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **对齐文本段落**
文本格式是创建任何文档或演示文稿时的关键要素。我们知道 Aspose.Slides for Android via Java 支持向幻灯片添加文本，但在本主题中，我们将了解如何在幻灯片中控制文本段落的对齐方式。请按照以下步骤使用 Aspose.Slides for Android via Java 对齐文本段落：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 使用其索引获取幻灯片的引用。
3. 访问幻灯片中的占位符形状，并将其类型转换为 [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape)。
4. 从 [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) 暴露的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#getTextFrame--) 中获取需要对齐的 Paragraph。
5. 对 Paragraph 进行对齐。段落可以对齐到右、左、居中或两端对齐。
6. 将修改后的演示文稿写入 PPTX 文件。

以下给出上述步骤的实现代码。
```java
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 在幻灯片中访问第一个和第二个占位符，并将其强制转换为 AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // 更改两个占位符中的文本
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // 获取占位符的第一段落
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // 将文本段落对齐到居中
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    //Writing 将演示文稿写入为 PPTX 文件
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **设置文本透明度**
本文演示了如何使用 Aspose.Slides for Android via Java 为任意文本形状设置透明度属性。请按照以下步骤设置文本透明度：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 获取幻灯片的引用。
3. 设置阴影颜色。
4. 将演示文稿写入 PPTX 文件。

以下给出上述步骤的实现代码。
```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - transparency is: "+ (shadowColor.getAlpha() / 255f) * 100);

    // 将透明度设置为零百分比
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **设置文本字符间距**
Aspose.Slides 允许您设置文本框中字母之间的间距。通过调整字符间距，您可以改变一行或一块文本的视觉密度。

以下 Java 代码演示了如何为一行文本扩展间距并为另一行文本收紧间距：
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // 展开
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // 紧缩

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **管理段落的字体属性**
演示文稿通常包含文本和图像。文本可以以多种方式进行格式化，以突出显示特定章节和单词，或符合公司样式。文本格式化帮助用户改变演示内容的外观和感受。本文展示了如何使用 Aspose.Slides for Android via Java 配置幻灯片中段落文本的字体属性。使用 Aspose.Slides for Android via Java 管理段落的字体属性的步骤如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 访问幻灯片中的占位符形状，并将其类型转换为 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)。
1. 从 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) 暴露的 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) 中获取 [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame)。
1. 对段落进行两端对齐。
1. 访问段落的文本 Portion。
1. 使用 FontData 定义字体，并相应地设置 Portion 的字体。
   1. 将字体设为粗体。
   1. 将字体设为斜体。
1. 使用 [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion) 对象暴露的 [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) 设置字体颜色。
1. 将修改后的演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以下给出上述步骤的实现代码。它接受一个未做任何装饰的演示文稿，并在其中一张幻灯片上格式化字体。
```java
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // 使用幻灯片位置访问幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 访问幻灯片中的第一个和第二个占位符，并将其强制转换为 AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // 访问第一段落
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // 访问第一个文本片段
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // 定义新字体
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // 为 Portion 分配新字体
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // 设置字体为粗体
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // 设置字体为斜体
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // 设置字体颜色
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // 将 PPTX 写入磁盘
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **管理文本的字体族**
Portion 用于在段落中保存具有相似格式的文本。本文展示了如何使用 Aspose.Slides for Android via Java 创建包含文本的文本框，然后定义特定的字体以及字体族的其他属性。创建文本框并设置其中文本的字体属性的步骤如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 使用索引获取幻灯片的引用。
3. 向幻灯片添加类型为 [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) 的 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)。
4. 移除与该 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) 关联的填充样式。
5. 访问 AutoShape 的 TextFrame。
6. 向 TextFrame 添加一些文本。
7. 访问与 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) 关联的 Portion 对象。
8. 为该 [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion) 定义要使用的字体。
9. 使用 Portion 对象暴露的相关属性设置其他字体属性，如粗体、斜体、下划线、颜色和高度。
10. 将修改后的演示文稿写入 PPTX 文件。

以下给出上述步骤的实现代码。
```java
// 实例化 Presentation 对象
Presentation pres = new Presentation();
try {

    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加一个矩形类型的 AutoShape
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

    // 将 PPTX 写入磁盘 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **设置文本的字体大小**
Aspose.Slides 允许您为段落中已有的文本以及以后可能添加的文本选择首选的字体大小。

以下 Java 代码演示了如何为段落中的文本设置字体大小：
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // 获取第一个形状，例如。
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // 获取第一段落，例如。
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // 将段落中所有文本片段的默认字号设置为 20 磅。
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // 将段落中当前文本片段的字号设置为 20 磅。
        for(IPortion portion : paragraph.getPortions())
        {
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **设置文本旋转**
Aspose.Slides for Android via Java 允许开发者旋转文本。文本可以设置为 [Horizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal)、[Vertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical)、[Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270)、[WordArtVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical)、[EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical)、[MongolianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical) 或 [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft)。要旋转任意 TextFrame 的文本，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任意形状。
4. 访问 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)。
5. [旋转文本](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-)。
6. 将文件保存到磁盘。

以下给出实现代码。
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加矩形类型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // 为矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // 访问文本框
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // 为文本框创建 Paragraph 对象
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // 为段落创建 Portion 对象
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // 保存演示文稿
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **为 TextFrame 设置自定义旋转角度**
Aspose.Slides for Android via Java 现在支持为 TextFrame 设置自定义旋转角度。在本主题中，我们通过示例展示如何在 Aspose.Slides 中设置 RotationAngle 属性。新方法 [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) 和 [getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--) 已添加到 [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) 和 [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) 接口，允许为 TextFrame 设置自定义旋转角度。要设置 RotationAngle，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 在幻灯片上添加图表。
3. [设置 RotationAngle 属性](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-)。
4. 将演示文稿写入 PPTX 文件。

下面的示例演示了如何设置 RotationAngle 属性。
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加矩形类型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // 为矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 访问文本框
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // 为文本框创建 Paragraph 对象
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 为段落创建 Portion 对象
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // 保存演示文稿
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **段落的行间距**
Aspose.Slides 在 [`ParagraphFormat`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraphFormat) 下提供了 `SpaceAfter`、`SpaceBefore` 和 `SpaceWithin` 属性，允许您管理段落的行间距。这三个属性的使用方式如下：

* 要以百分比指定段落的行间距，请使用正值。
* 要以磅值指定段落的行间距，请使用负值。

例如，您可以通过将 `SpaceBefore` 属性设为 -16 来为段落应用 16pt 的行间距。

下面是为特定段落指定行间距的步骤：

1. 加载包含带有文本的 AutoShape 的演示文稿。
2. 通过索引获取幻灯片的引用。
3. 访问 TextFrame。
4. 访问 Paragraph。
5. 设置 Paragraph 的属性。
6. 保存演示文稿。

以下 Java 代码演示了如何为段落指定行间距：
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 通过索引获取幻灯片的引用
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 访问 TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // 访问 Paragraph
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // 设置 Paragraph 的属性
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // 保存演示文稿
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **为 TextFrame 设置 AutofitType 属性**
在本主题中，我们将探讨文本框的不同格式化属性。本文介绍了如何为文本框设置 AutofitType 属性、文本锚点以及在演示文稿中旋转文本。Aspose.Slides for Android via Java 允许开发者为任意文本框设置 AutofitType 属性。AutofitType 可以设置为 [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) 或 [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape)。如果设置为 [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal)，形状保持不变，文本会自动调整而不改变形状；如果设置为 [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape)，则形状会被修改以仅容纳所需的文本。要为文本框设置 AutofitType 属性，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任意形状。
4. 访问 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)。
5. [设置 TextFrame 的 AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-)。
6. 将文件保存到磁盘。

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加矩形类型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // 为矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 访问文本框
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // 为文本框创建 Paragraph 对象
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 为段落创建 Portion 对象
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // 保存演示文稿
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **为 TextFrame 设置锚点**
Aspose.Slides for Android via Java 允许开发者为任意 TextFrame 设置锚点。TextAnchorType 指定文本在形状中的放置位置。锚点类型可设置为 [Top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top)、[Center](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center)、[Bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom)、[Justified](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) 或 [Distributed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed)。要为任意 TextFrame 设置锚点，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任意形状。
4. 访问 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)。
5. [设置 TextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-)。
6. 将文件保存到磁盘。

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加矩形类型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // 为矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // 访问文本框
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // 为文本框创建 Paragraph 对象
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // 为段落创建 Portion 对象
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // 保存演示文稿
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **演示文稿中的 Tabs 和 EffectiveTabs**
所有文本制表位均以像素为单位。

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**图：2 个显式制表符和 2 个默认制表符**|

- EffectiveTabs.ExplicitTabCount（本例中为 2）属性等于 Tabs.Count。
- EffectiveTabs 集合包含所有制表位（来自 Tabs 集合和默认制表位）。
- EffectiveTabs.ExplicitTabCount（本例中为 2）属性等于 Tabs.Count。
- EffectiveTabs.DefaultTabSize（294）属性显示默认制表位之间的距离（本例中的第 3 和第 4 个）。
- EffectiveTabs.GetTabByIndex(index)，当 index = 0 时返回第一个显式制表位（Position = 731），index = 1 时返回第二个制表位（Position = 1241）。如果尝试使用 index = 2，则返回第一个默认制表位（Position = 1470），依此类推。
- EffectiveTabs.GetTabAfterPosition(pos) 用于获取某段文本之后的下一个制表位。例如有文本 “Hello World!”。要渲染该文本，需要先知道从哪里开始绘制 “World!”。首先计算 “Hello” 的像素长度，并将该值传入 GetTabAfterPosition，即可获得绘制 “World!” 的下一个制表位位置。

## **设置默认文本样式**
如果您需要一次性为演示文稿中所有文本元素应用相同的默认文本格式，则可以使用 [IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/) 接口的 `getDefaultTextStyle` 方法并设置首选的格式。下面的代码示例演示了如何为新演示文稿中所有幻灯片的文本设置默认粗体字体（14 pt）。
```java
Presentation presentation = new Presentation();
try {
    // 获取顶层段落格式。
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("DefaultTextStyle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **提取带有全大写效果的文本**
在 PowerPoint 中，应用 **All Caps** 字体效果后，即使原始输入为小写，幻灯片上也会以大写形式显示。当使用 Aspose.Slides 检索此类文本时，库会返回原始输入的文本。为处理此情况，请检查 [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/)——如果其值为 `All`，则将返回的字符串转换为大写，以便输出与幻灯片显示一致。

假设我们在 sample2.pptx 的第一页上有如下文本框。

![The All Caps effect](all_caps_effect.png)

下面的代码示例演示了如何提取带有 **All Caps** 效果的文本：
```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    IPortion textPortion = paragraph.getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```


输出：
```text
原始文本: Hello, Aspose!
全大写效果: HELLO, ASPOSE!
```


## **常见问题**

**如何修改幻灯片中表格的文本？**

要修改幻灯片中表格的文本，需要使用 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 接口。您可以遍历表格中的所有单元格，访问每个单元格的 `TextFrame` 和 `ParagraphFormat` 属性，从而更改其文本。

**如何为 PowerPoint 幻灯片中的文本应用渐变色？**

要为文本应用渐变色，请使用 [BasePortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/) 中的 `getFillFormat` 方法。将 `FillFormat` 设置为 `Gradient`，并定义渐变的起始颜色和结束颜色，以及方向、透明度等属性，以在文本上创建渐变效果。