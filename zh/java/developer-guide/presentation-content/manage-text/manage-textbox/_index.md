---
title: 使用 Java 管理演示文稿中的文本框
linktitle: 管理文本框
type: docs
weight: 20
url: /zh/java/manage-textbox/
keywords:
- 文本框
- 文本帧
- 添加文本
- 更新文本
- 创建文本框
- 检查文本框
- 添加文本列
- 添加超链接
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "Aspose.Slides for Java 让您轻松在 PowerPoint 和 OpenDocument 文件中创建、编辑和克隆文本框，提升演示文稿自动化。"
---
## **简介**

幻灯片上的文本通常位于文本框或形状中。因此，要在幻灯片上添加文本，需要先添加一个文本框，然后在文本框中放入文本。Aspose.Slides for Java 提供了 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IAutoShape) 接口，允许您添加包含文本的形状。

{{% alert title="Info" color="info" %}}

Aspose.Slides 还提供了 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IShape) 接口，可用于向幻灯片添加形状。但是，通过 `IShape` 接口添加的并非所有形状都能容纳文本。而通过 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IAutoShape) 接口添加的形状可能包含文本。 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

因此，当处理需要添加文本的形状时，您可能需要检查并确认该形状是通过 `IAutoShape` 接口转换的。只有这样，您才能使用 `IAutoShape` 下的属性 [TextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/TextFrame)。请参阅本页的 [Update Text](https://docs.aspose.com/slides/zh/java/manage-textbox/#update-text) 部分。 

{{% /alert %}}

## **在幻灯片上创建文本框**

在幻灯片上创建文本框，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。 
2. 获取新建演示文稿中第一张幻灯片的引用。 
3. 在幻灯片指定位置添加一个 `ShapeType` 设置为 `Rectangle` 的 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IAutoShape) 对象，并获取新添加的 `IAutoShape` 对象的引用。 
4. 为该 `IAutoShape` 对象添加 `TextFrame` 属性，以容纳文本。在下面的示例中，我们添加的文本为 *Aspose TextBox*。 
5. 最后，通过 `Presentation` 对象写入 PPTX 文件。 

以下 Java 代码实现了上述步骤，演示了如何向幻灯片添加文本：

```java
import com.aspose.slides.*;

// 实例化 Presentation
Presentation pres = new Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加类型为 Rectangle 的 AutoShape
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 向矩形添加 TextFrame
    ashp.addTextFrame(" ");

    // 访问文本框
    ITextFrame txtFrame = ashp.getTextFrame();

    // 为文本框创建 Paragraph 对象
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

Aspose.Slides 提供了来自 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/) 接口的 [isTextBox](https://reference.aspose.com/slides/zh/java/com.aspose.slides/autoshape/#isTextBox--) 方法，允许您检查形状并识别文本框。

![Text box and shape](istextbox.png)

下面的 Java 代码展示了如何检查形状是否被创建为文本框： 

```java
import com.aspose.slides.*;

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

请注意，如果仅使用 [IShapeCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapecollection/) 接口的 `addAutoShape` 方法添加自动形状，则该自动形状的 `isTextBox` 方法将返回 `false`。但是，在使用 `addTextFrame` 方法或 `setText` 方法向自动形状添加文本后，`isTextBox` 属性将返回 `true`。

```java
import com.aspose.slides.*;

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

## **查找拥有 TextFrame 的形状**

在通用的文本处理代码中，您可能会收到一个 [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/) 实例，但并不知道它所属的演示文稿对象。使用 [ITextFrame.getParentShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/#getParentShape--) 方法可以返回拥有该文本框的 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/)。

对于属于 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/) 或其他包含文本的形状的文本框，`ITextFrame.getParentShape` 返回所有者，而 `ITextFrame.getParentCell` 返回 `null`。这两个方法提供只读导航，调用它们不会更改所有权。访问形状前，请始终检查返回值是否为 `null`。

有关完整示例（包括识别形状和表格单元格所有者以及与 SmartArt 节点关联的形状），请参阅 [Search and Replace Text](/slides/zh/java/search-and-replace-text/)。

## **向文本框添加列**

Aspose.Slides 提供了来自 [ITextFrameFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ITextFrameFormat) 接口和 [TextFrameFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/TextFrameFormat) 类的 [ColumnCount](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) 和 [ColumnSpacing](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) 属性，允许您向文本框添加列。您可以指定文本框的列数并设置列间的点数间距。

下面的 Java 代码演示了该操作： 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加类型为 Rectangle 的 AutoShape
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

    // 指定列之间的间距
    format.setColumnSpacing(10);

    // 保存演示文稿
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **向 TextFrame 添加列**
Aspose.Slides for Java 提供了来自 [ITextFrameFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ITextFrameFormat) 接口的 [ColumnCount](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) 属性，允许在文本框中添加列。通过此属性，您可以指定文本框中所需的列数。 

以下 Java 代码展示了如何在 TextFrame 中添加列：

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **更新文本**

Aspose.Slides 允许您更改或更新文本框中的文本，或更新演示文稿中所有文本。

下面的 Java 代码演示了更新演示文稿中所有文本的操作：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //检查形状是否支持文本框 (IAutoShape)。 
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

您可以在文本框内插入链接。单击文本框时，用户将被引导打开该链接。 

 将带链接的文本框添加到幻灯片，请按以下步骤操作：

1. 创建 `Presentation` 类的实例。 
2. 获取新建演示文稿中第一张幻灯片的引用。 
3. 在幻灯片指定位置添加 `ShapeType` 设置为 `Rectangle` 的 `AutoShape` 对象，并获取新添加的 AutoShape 对象的引用。 
4. 为该 `AutoShape` 对象添加一个 `TextFrame`，其默认文本为 *Aspose TextBox*。 
5. 实例化 `IHyperlinkManager` 类。 
6. 将 `IHyperlinkManager` 对象分配给与您在 `TextFrame` 中选定部分关联的 [HyperlinkClick](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Shape#getHyperlinkClick--) 属性。 
7. 最后，通过 `Presentation` 对象写入 PPTX 文件。 

以下 Java 代码实现了上述步骤，演示了如何向幻灯片添加带超链接的文本框：

```java
import com.aspose.slides.*;

// 实例化一个表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加类型为 Rectangle 的 AutoShape 对象
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // 将形状转换为 AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // 访问与 AutoShape 关联的 ITextFrame 属性
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // 向框添加一些文本
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // 为 Portion 文本设置超链接
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // 保存 PPTX 演示文稿
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常见问题解答**

**在使用母版幻灯片时，文本框和文本占位符有什么区别？**

[占位符](/slides/zh/java/manage-placeholder/) 会从 [母版](https://reference.aspose.com/slides/zh/java/com.aspose.slides/masterslide/) 继承样式/位置，并且可以在 [布局](https://reference.aspose.com/slides/zh/java/com.aspose.slides/layoutslide/) 上进行覆盖，而普通文本框是特定幻灯片上的独立对象，切换布局时不会改变。

**如何在不影响图表、表格和 SmartArt 中的文本的情况下，对整个演示文稿执行批量文本替换？**

遍历仅包含文本框的自动形状，排除嵌入对象（如 [图表](https://reference.aspose.com/slides/zh/java/com.aspose.slides/chart/)、[表格](https://reference.aspose.com/slides/zh/java/com.aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/smartart/)），或分别遍历它们的集合并跳过这些对象类型。