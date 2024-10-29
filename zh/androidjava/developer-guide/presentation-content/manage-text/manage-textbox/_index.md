---
title: 管理文本框
type: docs
weight: 20
url: /zh/androidjava/manage-textbox/
description: 使用 Java 在 PowerPoint 幻灯片上创建文本框。在 PowerPoint 幻灯片中使用 Java 在文本框或文本框架中添加列。使用 Java 在 PowerPoint 幻灯片中添加带超链接的文本框。
---


幻灯片上的文本通常存在于文本框或形状中。因此，要向幻灯片添加文本，您必须添加一个文本框，然后在文本框内放入一些文本。Aspose.Slides for Android via Java 提供了 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) 接口，允许您添加一个包含文本的形状。

{{% alert title="信息" color="info" %}}

Aspose.Slides 还提供了 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) 接口，允许您向幻灯片添加形状。然而，并非所有通过 `IShape` 接口添加的形状都可以包含文本。但通过 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) 接口添加的形状可能包含文本。

{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

因此，当处理一个您希望添加文本的形状时，您可能想要检查并确认它是通过 `IAutoShape` 接口转换的。只有这样，您才能使用 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)，这是 `IAutoShape` 下的一个属性。请查看本页面上的 [更新文本](https://docs.aspose.com/slides/androidjava/manage-textbox/#update-text) 部分。

{{% /alert %}}

## **在幻灯片上创建文本框**

要在幻灯片上创建文本框，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 获取新创建的演示文稿中的第一张幻灯片的引用。 
3. 添加一个 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) 对象，将 [ShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) 设置为 `Rectangle`，并在幻灯片上的指定位置获取新添加的 `IAutoShape` 对象的引用。
4. 向 `IAutoShape` 对象添加一个 `TextFrame` 属性，该属性将包含文本。在下面的示例中，我们添加了这段文本：*Aspose 文本框*
5. 最后，通过 `Presentation` 对象写入 PPTX 文件。 

以下 Java 代码——上述步骤的实现——向您展示了如何在幻灯片中添加文本：

```java
// 实例化 Presentation
Presentation pres = new Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加类型设置为矩形的 AutoShape
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 向矩形添加 TextFrame
    ashp.addTextFrame(" ");

    // 访问文本框
    ITextFrame txtFrame = ashp.getTextFrame();

    // 为文本框创建段落对象
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 为段落创建一个 Portion 对象
    IPortion portion = para.getPortions().get_Item(0);

    // 设置文本
    portion.setText("Aspose 文本框");

    // 保存演示文稿到磁盘
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **检查文本框形状**

Aspose.Slides 提供 [isTextBox()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#isTextBox--) 属性（来自 [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) 类），允许您检查形状并查找文本框。

![文本框和形状](istextbox.png)

以下 Java 代码向您展示了如何检查一个形状是否作为文本框创建： 

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

Aspose.Slides 提供 [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) 和 [ColumnSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) 属性（来自 [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) 接口和 [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) 类），允许您向文本框添加列。您可以指定文本框中的列数，并设置列之间的间距（以点为单位）。

以下 Java 代码演示了该操作： 

```java
Presentation pres = new Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加类型设置为矩形的 AutoShape
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // 向矩形添加 TextFrame
    aShape.addTextFrame("所有这些列都被限制在一个文本容器内 -- " +
            "您可以添加或删除文本，而新文本或剩余文本会自动调整 " +
            "以在容器内流动。然而，您不能让文本从一个容器 " +
            "流到另一个容器 -- 我们告诉过您，PowerPoint 的文本列选项是有限的！");

    // 获取 TextFrame 的文本格式
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // 指定 TextFrame 中的列数
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
Aspose.Slides for Android via Java 提供 [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) 属性（来自 [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) 接口），允许您在文本框架中添加列。通过该属性，您可以指定文本框架中您首选的列数。

以下 Java 代码向您展示了如何在文本框架内添加一列：

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("所有这些列都被强制保留在单个文本容器内 -- " +
            "您可以添加或删除文本 - 新文本或剩余文本会自动调整 " +
            "以保留在容器内。您不能让文本从一个容器溢出到另一个容器 " +
            "不过 -- 因为 PowerPoint 的文本列选项是有限的！");
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

Aspose.Slides 允许您更改或更新文本框中包含的文本或演示文稿中包含的所有文本。

以下 Java 代码演示了一个操作，其中演示文稿中的所有文本被更新或更改：

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // 检查形状是否支持文本框 (IAutoShape)。 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // 迭代文本框中的段落
                {
                    for (IPortion portion : paragraph.getPortions()) // 迭代段落中的每个部分
                    {
                        portion.setText(portion.getText().replace("years", "months")); // 更改文本
                        portion.getPortionFormat().setFontBold(NullableBool.True); // 更改格式
                    }
                }
            }
        }
    }

    // 保存修改后的演示文稿
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **添加带超链接的文本框** 

您可以在文本框内插入链接。当点击文本框时，用户将被引导打开链接。

要添加一个包含链接的文本框，请按照以下步骤操作：

1. 创建 `Presentation` 类的实例。 
2. 获取新创建的演示文稿中的第一张幻灯片的引用。 
3. 添加一个 `AutoShape` 对象，将 `ShapeType` 设置为 `Rectangle` 并在幻灯片上的指定位置获取新添加的 AutoShape 对象的引用。
4. 向 `AutoShape` 对象添加一个 `TextFrame`，其默认文本为 *Aspose 文本框*。 
5. 实例化 `IHyperlinkManager` 类。 
6. 将 `IHyperlinkManager` 对象分配给与您首选的 `TextFrame` 部分关联的 [HyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) 属性。
7. 最后，通过 `Presentation` 对象写入 PPTX 文件。 

以下 Java 代码——上述步骤的实现——向您展示了如何向幻灯片添加带有超链接的文本框：

```java
// 实例化一个表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加类型设置为矩形的 AutoShape 对象
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // 将形状转换为 AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // 访问与 AutoShape 关联的 ITextFrame 属性
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // 向框架添加一些文本
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // 为部分文本设置超链接
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // 保存 PPTX 演示文稿
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```