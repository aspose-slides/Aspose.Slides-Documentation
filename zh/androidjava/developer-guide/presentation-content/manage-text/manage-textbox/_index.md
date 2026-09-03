---
title: "在 Android 上管理演示文稿文本框"
linktitle: "管理文本框"
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
description: "使用 Aspose.Slides for Android via Java 在 PowerPoint 和 OpenDocument 演示文稿中创建、识别、格式化和更新文本框。"
---
## **介绍**

在 Aspose.Slides for Android via Java 中，幻灯片文本存储在属于形状的文本框中。 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/) 接口表示最常见的承载文本的形状，并通过 [IAutoShape.getTextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) 方法公开其文本。

{{% alert color="info" title="Note" %}}
每个自动形状都实现了 [IShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/)，但并非所有形状都是自动形状或支持文本框。在处理现有演示文稿时，在访问其文本之前，请先检查形状是否实现了 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
{{% /alert %}}

## **在幻灯片上创建文本框**

要创建文本框，向幻灯片添加自动形状，在其文本框中添加文本，然后保存演示文稿。下面的示例创建了一个矩形文本框：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

传递给 [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) 的坐标和尺寸以点为单位。 [IAutoShape.addTextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 使用提供的文本初始化文本框。

## **检查文本框形状**

使用 [IAutoShape.isTextBox](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/#isTextBox--) 方法来判断自动形状是否被视为文本框。当演示文稿同时包含承载文本的自动形状和纯图形自动形状时，这非常有用。

![文本框和形状](istextbox.png)

下面的示例检查演示文稿中的每个自动形状：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

新添加的自动形状在包含非空文本之前不会被视为文本框。可以通过 [IAutoShape.addTextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 或 [ITextFrame.setText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) 提供该文本。添加或分配空字符串会导致 [IAutoShape.isTextBox](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/#isTextBox--) 返回 `false`：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

前两次调用打印 `true`；后两次打印 `false`。

## **查找拥有文本框的形状**

通用的文本处理代码可能会收到一个 [ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/)，但不知道它属于哪个演示对象。使用只读的 [ITextFrame.getParentShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#getParentShape--) 方法可以返回其所属的 [IShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/)。

对于由自动形状或其他承载文本的形状拥有的文本框， [ITextFrame.getParentShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#getParentShape--) 返回所有者，而 [ITextFrame.getParentCell](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#getParentCell--) 返回 `null`。在访问返回值之前请先检查它。要识别形状和表格单元格所有者（包括与 SmartArt 节点关联的形状），请参阅 [Search and Replace Text](/slides/zh/androidjava/search-and-replace-text/)。

## **向文本框添加列**

[ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) 方法将文本框划分为若干列，而 [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) 方法以点为单位设置列间间距。这两个设置均属于 [ITextFrameFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/)，可以通过现有文本框的文本框进行更改。文本在同一形状内部的列之间重新换行；不会继续流入其他形状。

下面的示例创建了一个三列文本框，列间距为 10 点，保存演示文稿并从输出文件中读取存储的设置：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **从单独列中提取文本**

使用 [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) 可以检索现有文本框中每个可视列分配的文本。该方法按列的阅读顺序返回每列一个字符串。单列文本框返回仅包含一个元素的数组，空列则表示为空字符串。返回的字符串仅包含纯文本；不会保留段落级别的格式。

这在以下场景中很有用：

- 在保留基于列的阅读顺序的同时提取文本。
- 索引或比较多列幻灯片的内容。
- 将每列导出到单独的文件、数据库字段或其他目标。
- 检查在更改列数（使用 [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-)）、列间距（使用 [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-)）、字体或文本框大小后，文本是如何重新分布的。

该方法报告当前 [ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/) 内部的文本分布；不会自动在不同形状或文本框之间流动文本。列的分布可能受可用字体和其他文本布局设置的影响，因此在结果一致性很重要时，请确保所需字体可用。

下面的示例加载演示文稿，找到第一个带有文本框的多列自动形状，读取其配置的列数，并将每列的文本写入单独的文件。没有提供文本框的形状将被跳过。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **更新文本**

要在整个演示文稿中更新文本，遍历幻灯片和形状，选择自动形状，然后编辑其文本段落。在段落级别工作可以同时更改文本和字符格式。

下面的示例将自动形状文本中所有出现的 `years` 替换为 `months`，并将受影响的段落加粗：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此遍历仅更新自动形状中的文本。存储在表格、图表、SmartArt 或组合形状中的文本需要遍历这些对象各自的集合。

## **添加带超链接的文本框**

可以将超链接分配给特定的文本段落，这样只有该文本会作为可点击链接。使用 [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) 将该段落与外部 URL 关联。

下面的示例创建带链接的文本并保存到演示文稿：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**文本框与母版或布局幻灯片上的文本占位符有何区别？**

[placeholder](/slides/zh/androidjava/manage-placeholder/) 可以继承其位置和格式自 [master slide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/masterslide/) 或 [layout slide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/layoutslide/)。普通文本框是创建所在幻灯片上的独立形状，在布局更改时不会获得占位符行为。

**如何在不更改图表、表格或 SmartArt 中文本的情况下替换文本？**

将遍历限制在实现了 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/) 的形状，如 “更新文本” 示例所示。图表、表格和 SmartArt 将文本存储在各自的对象模型中，因此不会被该循环修改。