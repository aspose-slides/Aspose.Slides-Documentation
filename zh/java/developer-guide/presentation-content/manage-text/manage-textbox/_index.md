---
title: 管理文本框
type: docs
weight: 20
url: /zh/java/manage-textbox/
description: 使用Java在PowerPoint幻灯片上创建文本框。在PowerPoint幻灯片中使用Java添加文本框或文本框架中的列。使用Java在PowerPoint幻灯片中添加带超链接的文本框。
---


幻灯片上的文本通常存在于文本框或形状中。因此，要向幻灯片添加文本，您必须添加一个文本框，然后在文本框中放入一些文本。Aspose.Slides for Java提供了[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)接口，允许您添加一个包含文本的形状。

{{% alert title="信息" color="info" %}}

Aspose.Slides还提供了[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)接口，允许您向幻灯片添加形状。但是，并非所有通过`IShape`接口添加的形状都可以包含文本。而通过[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)接口添加的形状可能包含文本。 

{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

因此，当处理您想要添加文本的形状时，您可能想要检查并确认它是通过`IAutoShape`接口进行转换的。只有这样，您才能使用[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)，这是`IAutoShape`下的一个属性。请参见本页面上的[更新文本](https://docs.aspose.com/slides/java/manage-textbox/#update-text)部分。 

{{% /alert %}}

## **在幻灯片上创建文本框**

在幻灯片上创建文本框，请按照以下步骤操作：

1. 创建[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例。 
2. 获取新创建的演示文稿中第一张幻灯片的引用。 
3. 在幻灯片上添加一个[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)对象，设置[ShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setShapeType-int-)为`Rectangle`，并在指定位置获取新添加的`IAutoShape`对象的引用。 
4. 向`IAutoShape`对象添加一个将包含文本的`TextFrame`属性。在下面的示例中，我们添加了以下文本：*Aspose TextBox*
5. 最后，通过`Presentation`对象写入PPTX文件。 

以下Java代码是上述步骤的实现，展示了如何向幻灯片添加文本：

```java
// 实例化Presentation
Presentation pres = new Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加类型设置为Rectangle的AutoShape
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 向矩形添加TextFrame
    ashp.addTextFrame(" ");

    // 访问文本框
    ITextFrame txtFrame = ashp.getTextFrame();

    // 创建文本框的段落对象
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 创建段落的部分对象
    IPortion portion = para.getPortions().get_Item(0);

    // 设置文本
    portion.setText("Aspose TextBox");

    // 将演示文稿保存在磁盘上
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **检查文本框形状**

Aspose.Slides提供了[isTextBox()](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#isTextBox--)属性（来自[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/)类），允许您检查形状并找到文本框。

![文本框和形状](istextbox.png)

以下Java代码展示了如何检查形状是否是作为文本框创建的： 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ForEach.shape(pres, (shape, slide, index) ->
    {
        if (shape instanceof AutoShape)
        {
            AutoShape autoShape = (AutoShape)shape;
            System.out.println(autoShape.isTextBox() ? "形状是文本框" : "形状不是文本框");
        }
    });
} finally {
    if (pres != null) pres.dispose();
}
```

## **在文本框中添加列**

Aspose.Slides提供了[ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-)和[ColumnSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-)属性（来自[ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat)接口和[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)类），允许您向文本框添加列。您可以指定文本框中的列数，并设置列之间的间距（以点为单位）。 

以下Java代码演示了描述的操作： 

```java
Presentation pres = new Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加类型设置为Rectangle的AutoShape
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // 向矩形添加TextFrame
    aShape.addTextFrame("所有这些列都限制在一个文本容器内 - " +
            "您可以添加或删除文本，新的或剩余的文本会自动调整 " +
            "以流动在容器内。不过，您不能让文本从一个容器流到另一个容器 - " +
            "我们告诉您PowerPoint的文本列选项是有限的！");

    // 获取TextFrame的文本格式
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // 指定TextFrame中的列数
    format.setColumnCount(3);

    // 指定列之间的间距
    format.setColumnSpacing(10);

    // 保存演示文稿
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **在文本框架中添加列**
Aspose.Slides for Java提供了[ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-)属性（来自[ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat)接口），允许您在文本框架中添加列。通过此属性，您可以指定文本框架中首选的列数。 

以下Java代码展示了如何在文本框架内添加一列：

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("所有这些列都被强制保持在单个文本容器内 - " +
            "您可以添加或删除文本 - 新的或剩余的文本会自动调整 " +
            "以保持在容器内。您不能让文本从一个容器溢出到另一个容器， - " +
            "因为PowerPoint的文本列选项是有限的！");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **更新文本**

Aspose.Slides允许您更改或更新文本框中包含的文本或演示文稿中包含的所有文本。 

以下Java代码演示了更新或更改演示文稿中所有文本的操作：

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //检查形状是否支持文本框（IAutoShape）。 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //遍历文本框中的段落
                {
                    for (IPortion portion : paragraph.getPortions()) //遍历段落中的每个部分
                    {
                        portion.setText(portion.getText().replace("years", "months")); //更改文本
                        portion.getPortionFormat().setFontBold(NullableBool.True); //更改格式
                    }
                }
            }
        }
    }

    //保存修改后的演示文稿
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **添加带超链接的文本框** 

您可以在文本框内插入链接。当文本框被点击时，用户将被引导打开链接。 

要添加一个包含链接的文本框，请按照以下步骤操作：

1. 创建`Presentation`类的实例。 
2. 获取新创建的演示文稿中第一张幻灯片的引用。 
3. 在幻灯片上添加一个`AutoShape`对象，设置`ShapeType`为`Rectangle`，并获取新添加的AutoShape对象的引用。
4. 向`AutoShape`对象添加一个包含*Aspose TextBox*作为其默认文本的`TextFrame`。 
5. 实例化`IHyperlinkManager`类。 
6. 将`IHyperlinkManager`对象分配给您首选的`TextFrame`部分的[HyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getHyperlinkClick--)属性。 
7. 最后，通过`Presentation`对象写入PPTX文件。 

以下Java代码是上述步骤的实现，展示了如何向幻灯片添加带有超链接的文本框：

```java
// 实例化表示PPTX的Presentation类
Presentation pres = new Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加类型设置为Rectangle的AutoShape对象
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // 将形状转换为AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // 访问与AutoShape关联的ITextFrame属性
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // 向框架添加一些文本
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // 设置部分文本的超链接
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // 保存PPTX演示文稿
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```