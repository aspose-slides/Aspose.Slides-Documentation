---
title: 文本格式化
type: docs
weight: 50
url: /androidjava/text-formatting/
keywords:
- 突出显示文本
- 正则表达式
- 对齐文本段落
- 文本透明度
- 段落字体属性
- 字体系列
- 文本旋转
- 自定义角度旋转
- 文本框
- 行间距
- 自动调整属性
- 文本框锚点
- 文本制表符
- 默认文本样式
- Java
- Aspose.Slides for Android via Java
description: "在Java中管理和操作文本及文本框属性"
---

## **突出显示文本**
方法 [highlightText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) 已添加到 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) 接口和 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) 类。

它允许使用文本样本以背景颜色突出显示文本部分，类似于 PowerPoint 2019 中的文本突出显示颜色工具。

以下代码片段显示如何使用此功能：

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

Aspose 提供一个简单的 [免费在线 PowerPoint 编辑服务](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **使用正则表达式突出显示文本**

方法 [highlightRegex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) 已添加到 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) 接口和 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) 类。

它允许使用正则表达式以背景颜色突出显示文本部分，类似于 PowerPoint 2019 中的文本突出显示颜色工具。

以下代码片段显示如何使用此功能：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // 突出显示所有字符数为 10 或更长的单词
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置文本背景颜色**

Aspose.Slides 允许您为文本的背景指定首选颜色。

以下 Java 代码展示了如何为整个文本设置背景颜色：

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("黑色");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" 红色 ");

    Portion portion3 = new Portion("黑色");
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

这段 Java 代码展示了如何为文本中的某一部分设置背景颜色：

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("黑色");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" 红色 ");

    Portion portion3 = new Portion("黑色");
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
            .filter(p -> p.getText().contains("红色"))
            .findFirst();

    if(redPortion.isPresent())
        redPortion.get().getPortionFormat().getHighlightColor().setColor(Color.RED);

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **对齐文本段落**

文本格式化是在创建任何文档或演示文稿时的关键元素。我们知道 Aspose.Slides for Android via Java 支持将文本添加到幻灯片，但在本主题中，我们将看到如何控制幻灯片中文本段落的对齐方式。请按照以下步骤使用 Aspose.Slides for Android via Java 对齐文本段落：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 访问幻灯片中存在的占位符形状并将其强制转换为 [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape)。
4. 从 [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) 曝露的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#getTextFrame--) 中获取需要对齐的段落。
5. 对齐段落。段落可以对齐到右、左、居中和两端对齐。
6. 将修改后的演示文稿写入 PPTX 文件。

以上步骤的实施如下所示。

```java
// 实例化代表 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 访问幻灯片中的第一个和第二个占位符并将其强制转换为 AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // 更改两个占位符中的文本
    tf1.setText("由 Aspose 居中对齐");
    tf2.setText("由 Aspose 居中对齐");

    // 获取占位符的第一个段落
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // 将文本段落对齐到中心
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    //将演示文稿写入 PPTX 文件
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置文本透明度**
本文演示了如何使用 Aspose.Slides for Android via Java 设置任意文本形状的透明度属性。要为文本设置透明度，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 获取幻灯片的引用。
3. 设置阴影颜色
4. 将演示文稿写入 PPTX 文件。

以上步骤的实施如下所示。

```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - 透明度为: "+ (shadowColor.getAlpha() / 255f) * 100);

    // 将透明度设置为零百分比
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置文本的字符间距**

Aspose.Slides 允许您设置文本框中字母之间的间距。通过这种方式，您可以通过扩展或收缩字符之间的间距来调整文本行或块的视觉密度。

以下 Java 代码展示了如何扩展一行文本的间距并收缩另一行的间距：

```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // 扩展
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // 收缩

presentation.save("out.pptx", SaveFormat.Pptx);
```

## **管理段落的字体属性**

演示文稿通常包含文本和图像。文本可以以多种方式进行格式化，要么突出特定部分和单词，要么符合企业样式。文本格式化帮助用户改变演示文稿内容的外观和感觉。本文展示了如何使用 Aspose.Slides for Android via Java 来配置幻灯片上文本段落的字体属性。要使用 Aspose.Slides for Android via Java 管理段落的字体属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 访问幻灯片中的占位符形状并将其强制转换为 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)。
4. 从 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) 曝露的 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) 中获取段落。
5. 对齐段落。
6. 访问段落的文本部分。
7. 使用 FontData 定义字体并相应地设置文本部分的字体。
   1. 设置字体为粗体。
   2. 设置字体为斜体。
8. 使用 [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) 曝露的属性设置字体颜色。
9. 将修改后的演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以下是上述步骤的实施。它接受一个未修饰的演示文稿并格式化其中一个幻灯片的字体。

```java
// 实例化代表 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // 通过幻灯片位置访问幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 访问幻灯片中的第一个和第二个占位符并将其强制转换为 AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // 访问第一个段落
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // 访问第一个部分
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // 定义新字体
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // 将新字体分配给部分
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

    //将 PPTX 写入磁盘
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **管理文本的字体系列**
一个部分用于在段落中保存具有相似格式样式的文本。本文展示了如何使用 Aspose.Slides for Android via Java 创建一个文本框并定义特定字体及其他各种字体系列属性。要创建文本框并设置其中文本的字体属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) 类型的 [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle)。
4. 删除与 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) 相关的填充样式。
5. 访问 AutoShape 的 TextFrame。
6. 向 TextFrame 添加一些文本。
7. 访问与 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) 相关的 Portion 对象。
8. 为 [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion) 定义要使用的字体。
9. 使用相关属性设置粗体、斜体、下划线、颜色和高度等其他字体属性。
10. 将修改后的演示文稿写入 PPTX 文件。

以下是上述步骤的实施。

```java
// 实例化 Presentation
Presentation pres = new Presentation();
try {

    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加一个矩形类型的 AutoShape
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // 删除与 AutoShape 相关的任何填充样式
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 访问与 AutoShape 相关的 TextFrame
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose 文本框");

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

    // 将 PPTX 写入磁盘 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置文本的字体大小**

Aspose.Slides 允许您为段落中现有文本和可能稍后添加到段落中的其他文本选择首选字体大小。

以下 Java 代码展示了如何为段落中包含的文本设置字体大小：

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // 获取第一个形状，例如。
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // 获取第一个段落，例如。
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // 将当前段落中所有文本部分的默认字体大小设置为 20 磅。 
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // 将当前段落中当前文本部分的字体大小设置为 20 磅。 
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

Aspose.Slides for Android via Java 允许开发者旋转文本。文本可以设置为 [Horizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Horizontal)、[Vertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical)、[Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#Vertical270)、[WordArtVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVertical)、[EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#EastAsianVertical)、[MongolianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#MongolianVertical) 或 [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft)。要旋转任何 TextFrame 的文本，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任何形状。
4. 访问 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)。
5. [旋转文本](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-)。
6. 将文件保存到磁盘。

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加矩形类型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // 向矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // 访问文本框
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // 创建文本框的段落对象
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // 为段落创建部分对象
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("一只敏捷的棕色狐狸跳过懒狗。一只敏捷的棕色狐狸跳过懒狗。");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // 保存演示文稿
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置文本框的自定义旋转角度**
Aspose.Slides for Android via Java 现在支持为文本框设置自定义旋转角度。在本主题中，我们将通过示例看到如何在 Aspose.Slides 中设置 RotationAngle 属性。新方法 [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) 和 [getRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#getRotationAngle--) 已添加到 [IChartTextBlockFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartTextBlockFormat) 和 [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) 接口，可以设置文本框的自定义旋转角度。为了设置 RotationAngle，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 在幻灯片上添加图表。
3. [设置 RotationAngle 属性](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-)。
4. 将演示文稿写入 PPTX 文件。

在下面的示例中，我们设置 RotationAngle 属性。

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加矩形类型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // 向矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 访问文本框
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // 创建文本框的段落对象
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 为段落创建部分对象
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("文本旋转示例。");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // 保存演示文稿
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落行间距**
Aspose.Slides 提供了 [`ParagraphFormat`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IParagraphFormat) 下的属性——`SpaceAfter`、`SpaceBefore` 和 `SpaceWithin`，允许您管理段落的行间距。这三个属性的用法如下：

* 要以百分比指定段落的行间距，请使用正值。 
* 要以磅数指定段落的行间距，请使用负值。

例如，您可以通过将 `SpaceBefore` 属性设置为 -16 来为段落应用 16pt 的行间距。

以下 Java 代码展示了如何为特定段落指定行间距：

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 通过索引获取幻灯片的引用
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 访问文本框
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // 访问段落
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // 设置段落属性
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
在本主题中，我们将探讨文本框的不同格式属性。本文涵盖了如何设置文本框的 AutofitType 属性、文本的锚点以及在演示文稿中旋转文本。Aspose.Slides for Android via Java 允许开发者设置任何文本框的 AutofitType 属性。AutofitType 可以设置为 [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal) 或 [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape)。如果设置为 [Normal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Normal)，则形状将保持不变，而文本将自动调整而不会改变形状本身；而如果 AutofitType 设置为 [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAutofitType#Shape)，则形状将被修改，以确保只包含所需的文本。要设置文本框的 AutofitType 属性，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任何形状。
4. 访问 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)。
5. [设置 TextFrame 的 AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-)。
6. 将文件保存到磁盘。

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加矩形类型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // 向矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 访问文本框
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // 创建文本框的段落对象
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 为段落创建部分对象
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("一只敏捷的棕色狐狸跳过懒狗。一只敏捷的棕色狐狸跳过懒狗。");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // 保存演示文稿
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置 TextFrame 的锚点**
Aspose.Slides for Android via Java 允许开发者为任何 TextFrame 设置锚点。TextAnchorType 指定文本在形状中的位置。锚点类型可以设置为 [Top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Top)、[Center](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Center)、[Bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Bottom)、[Justified](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Justified) 或 [Distributed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextAnchorType#Distributed)。要设置任何 TextFrame 的锚点，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任何形状。
4. 访问 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)。
5. [设置 TextFrame 的 TextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-)。
6. 将文件保存到磁盘。

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加矩形类型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // 向矩形添加 TextFrame
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // 访问文本框
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // 创建文本框的段落对象
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // 为段落创建部分对象
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("一只敏捷的棕色狐狸跳过懒狗。一只敏捷的棕色狐狸跳过懒狗。");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // 保存演示文稿
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **演示中的制表符和有效制表符**
所有文本制表符以像素为单位给出。

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**图：2 个显式制表符和 2 个默认制表符**|
- EffectiveTabs.ExplicitTabCount（在我们的例子中为 2）属性等于 Tabs.Count。
- EffectiveTabs 集合包括所有制表符（来自 Tabs 集合和默认制表符）。
- EffectiveTabs.ExplicitTabCount（在我们的例子中为 2）属性等于 Tabs.Count。
- EffectiveTabs.DefaultTabSize（294）属性显示默认制表符之间的距离（在我们的示例中为 3 和 4）。
- EffectiveTabs.GetTabByIndex(index) 使用索引 = 0 将返回第一个显式制表符（位置 = 731），索引 = 1 - 第二个制表符（位置 = 1241）。如果您尝试使用索引 = 2 获取下一个制表符，它将返回第一个默认制表符（位置 = 1470）等。
- EffectiveTabs.GetTabAfterPosition(pos) 用于获取某些文本之后的下一个制表符。例如，您有文本：“Hello World！”。要呈现这样的文本，您应该知道从哪里开始绘制“world！”首先，您应该计算“Hello”的像素长度，并使用此值调用 GetTabAfterPosition。您将获得开始绘制“world！”的下一个制表位置。

## **设置默认文本样式**

如果您需要一次性将相同的默认文本格式应用于演示文稿的所有文本元素，则可以使用 [IPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/) 接口中的 `getDefaultTextStyle` 方法并设置首选格式。以下代码示例显示如何为新演示文稿中的所有幻灯片上的文本设置默认粗体字体（14 磅）。

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