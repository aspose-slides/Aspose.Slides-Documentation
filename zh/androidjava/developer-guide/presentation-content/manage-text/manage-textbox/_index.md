---
title: 管理 Android 上演示文稿中的文本框
linktitle: 管理文本框
type: docs
weight: 20
url: /zh/androidjava/manage-textbox/
keywords:
- 文本框
- 文本框架
- 添加文本
- 更新文本
- 创建文本框
- 检查文本框
- 添加文本列
- 添加超链接
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java 让您能够轻松在 PowerPoint 和 OpenDocument 文件中创建、编辑和克隆文本框，提升演示文稿自动化。"
---

幻灯片上的文本通常存在于文本框或形状中。因此，要在幻灯片上添加文本，必须先添加文本框，然后在文本框中放入一些文本。Aspose.Slides for Android via Java 提供了 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) 接口，允许您添加包含文本的形状。

{{% alert title="Info" color="info" %}}
Aspose.Slides 还提供了 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) 接口，允许您向幻灯片添加形状。然而，并非所有通过 `IShape` 接口添加的形状都能容纳文本。但通过 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) 接口添加的形状可以包含文本。
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
因此，在处理需要添加文本的形状时，您可能需要检查并确认它是通过 `IAutoShape` 接口转换的。只有这样，您才能使用位于 `IAutoShape` 下的属性 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)。请参阅本页的 [Update Text](https://docs.aspose.com/slides/androidjava/manage-textbox/#update-text) 部分。
{{% /alert %}}

## **在幻灯片上创建文本框**

要在幻灯片上创建文本框，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 获取新建演示文稿中第一张幻灯片的引用。 
3. 在幻灯片的指定位置添加一个 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) 对象，并使用 [ShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) 设置为 `Rectangle`，然后获取新添加的 `IAutoShape` 对象的引用。
4. 向 `IAutoShape` 对象添加 `TextFrame` 属性以容纳文本。在下面的示例中，我们添加了以下文本：*Aspose TextBox*
5. 最后，通过 `Presentation` 对象写入 PPTX 文件。 

下面的 Java 代码——上述步骤的实现——演示了如何向幻灯片添加文本：
```java
// 实例化 Presentation
Presentation pres = new Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加 AutoShape，类型设为 Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 向矩形添加 TextFrame
    ashp.addTextFrame(" ");

    // 访问文本框架
    ITextFrame txtFrame = ashp.getTextFrame();

    // 为文本框架创建 Paragraph 对象
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // 为段落创建 Portion 对象
    IPortion portion = para.getPortions().get_Item(0);

    // 设置文本
    portion.setText("Aspose TextBox");

    // 将演示文稿保存到磁盘
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **检查文本框形状**

Aspose.Slides 提供了来自 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) 接口的 [isTextBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#isTextBox--) 方法，允许您检查形状并识别文本框。

![Text box and shape](istextbox.png)

下面的 Java 代码展示了如何检查形状是否被创建为文本框： 
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```


请注意，如果仅使用 [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) 接口的 `addAutoShape` 方法添加自动形状，则该自动形状的 `isTextBox` 方法将返回 `false`。但在使用 `addTextFrame` 方法或 `setText` 方法向自动形状添加文本后，`isTextBox` 属性会返回 `true`。
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() 返回 false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() 返回 true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() 返回 false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() 返回 true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() 返回 false
shape3.addTextFrame("");
// shape3.isTextBox() 返回 false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() 返回 false
shape4.getTextFrame().setText("");
// shape4.isTextBox() 返回 false
```


## **向文本框添加列**

Aspose.Slides 提供了 [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) 和 [ColumnSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) 属性（来自 [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) 接口和 [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) 类），允许您在文本框中添加列。您可以指定文本框的列数并设置列间的点距间距。

下面的 Java 代码演示了上述操作： 
```java
Presentation pres = new Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加 AutoShape，类型设为 Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // 向矩形添加 TextFrame
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // 获取 TextFrame 的文本格式
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // 指定 TextFrame 中的列数
    format.setColumnCount(3);

    // 指定列间的间距
    format.setColumnSpacing(10);

    // 保存演示文稿
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **向文本框架添加列**
Aspose.Slides for Android via Java 提供了 [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) 属性（来自 [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) 接口），允许在文本框架中添加列。通过此属性，您可以指定文本框架中所需的列数。

下面的 Java 代码展示了如何在文本框架中添加列：
```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
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

Aspose.Slides 允许您更改或更新文本框中的文本或演示文稿中所有文本。

下面的 Java 代码演示了在演示文稿中更新或更改所有文本的操作：
```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //检查形状是否支持文本框 (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //遍历文本框中的段落
                {
                    for (IPortion portion : paragraph.getPortions()) //遍历段落中的每个 Portion
                    {
                        portion.setText(portion.getText().replace("years", "months")); //更改文本
                        portion.getPortionFormat().setFontBold(NullableBool.True); //更改格式
                    }
                }
            }
        }
    }

    //保存已修改的演示文稿
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **添加带超链接的文本框** 

您可以在文本框中插入链接。单击文本框时，用户将被引导打开该链接。 

要添加包含链接的文本框，请按照以下步骤操作：

1. 创建 `Presentation` 类的实例。 
2. 获取新建演示文稿中第一张幻灯片的引用。 
3. 在幻灯片的指定位置添加一个 `AutoShape` 对象，并将 `ShapeType` 设置为 `Rectangle`，然后获取新添加的 AutoShape 对象的引用。
4. 向 `AutoShape` 对象添加一个 `TextFrame`，其默认文本为 *Aspose TextBox*。 
5. 实例化 `IHyperlinkManager` 类。 
6. 将 `IHyperlinkManager` 对象分配给与 `TextFrame` 中您选择的部分关联的 [HyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) 属性。
7. 最后，通过 `Presentation` 对象写入 PPTX 文件。 

下面的 Java 代码——上述步骤的实现——演示了如何向幻灯片添加带超链接的文本框：
```java
// 实例化一个表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加一个类型为 Rectangle 的 AutoShape 对象
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // 将形状强制转换为 AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // 访问与 AutoShape 关联的 ITextFrame 属性
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // 向框中添加一些文本
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // 为该 Portion 文本设置超链接
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // 保存 PPTX 演示文稿
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**在使用母版幻灯片时，文本框和文本占位符有什么区别？**

一个 [placeholder](/slides/zh/androidjava/manage-placeholder/) 继承自 [master](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/) 的样式/位置，并可以在 [layouts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) 上被覆盖，而普通文本框是特定幻灯片上的独立对象，在切换布局时不会改变。

**如何在演示文稿中批量替换文本而不影响图表、表格和 SmartArt 中的文本？**

将遍历限制在具有文本框的自动形状上，并通过单独遍历或跳过这些对象类型，排除嵌入对象（[charts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/)、[tables](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/)）。