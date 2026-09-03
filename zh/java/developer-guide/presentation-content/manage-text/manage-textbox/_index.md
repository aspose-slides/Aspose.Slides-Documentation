---
title: 使用 Java 管理演示文稿中的文本框
linktitle: 管理文本框
type: docs
weight: 20
url: /zh/java/manage-textbox/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 和 OpenDocument 演示文稿中创建、识别、格式化和更新文本框。"
---
## **介绍**

在 Aspose.Slides for Java 中，幻灯片文本存储在属于形状的文本框中。 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/) 接口表示最常见的承载文本的形状，并通过 [IAutoShape.getTextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/#getTextFrame--) 方法公开其文本。

{{% alert color="info" title="注意" %}}
每个自动形状实现了 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/)，但并非所有形状都是自动形状或支持文本框。在处理现有演示文稿时，访问其文本前请先检查形状是否实现了 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
{{% /alert %}}

## **在幻灯片上创建文本框**

要创建文本框，需要向幻灯片添加一个自动形状，在其文本框中添加文本，然后保存演示文稿。下面的示例创建了一个矩形文本框：

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

传递给 [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) 的坐标和尺寸使用点 (point) 为单位。 [IAutoShape.addTextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 使用提供的文本初始化文本框。

## **检查文本框形状**

使用 [IAutoShape.isTextBox](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/#isTextBox--) 方法可确定自动形状是否被视为文本框。当演示文稿同时包含承载文本的自动形状和纯图形自动形状时，这非常有用。

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

新添加的自动形状在包含非空文本之前不被视为文本框。可以通过 [IAutoShape.addTextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) 或 [ITextFrame.setText](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/#setText-java.lang.String-) 提供该文本。将空字符串添加或赋值会使 [IAutoShape.isTextBox](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/#isTextBox--) 返回 `false`：

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

前两个调用打印 `true`，后两个打印 `false`。

## **查找拥有文本框的形状**

通用的文本处理代码可能只收到一个 [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/)，而不知道它属于哪个演示对象。使用只读的 [ITextFrame.getParentShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/#getParentShape--) 方法可回溯到拥有它的 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/)。

对于由自动形状或其他承载文本的形状拥有的文本框， [ITextFrame.getParentShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/#getParentShape--) 返回拥有者，而 [ITextFrame.getParentCell](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/#getParentCell--) 返回 `null`。在访问前请检查返回值。若需识别形状和表格单元格的拥有者（包括与 SmartArt 节点关联的形状），请参阅 [搜索并替换文本](/slides/zh/java/search-and-replace-text/)。

## **向文本框添加列**

[ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) 方法将文本框划分为多列，而 [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) 方法设置列间距（单位为点）。这两个设置均属于 [ITextFrameFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/)，可通过现有文本框的文本框进行更改。列内文本在同一形状内重新流动，不会继续到其他形状。

下面的示例创建了一个三列文本框，列间距为 10 点，保存演示文稿后再从输出文件读取存储的设置：

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

## **从各列中提取文本**

使用 [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/#splitTextByColumns--) 可以获取现有文本框中每个可视列分配的文本。该方法按列的阅读顺序返回每列的字符串。单列文本框返回仅包含一个元素的数组，空列则用空字符串表示。返回的字符串仅包含纯文本，不保留段落级别的格式。

这在以下场景中非常有用：

- 在保持列顺序的同时提取文本。
- 为多列幻灯片建立索引或比较内容。
- 将每列导出到单独的文件、数据库字段或其他目标。
- 检查在使用 [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) 更改列数、使用 [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) 更改间距、修改字体或文本框大小后文本的重新分布情况。

该方法仅报告当前 [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/) 中的文本分布；它不会自动在不同形状或文本框之间流动文本。列的分布可能受可用字体和其他排版设置影响，因此在对结果一致性有要求时请确保所需字体已就绪。

下面的示例加载演示文稿，找到第一个具有多列文本框的自动形状，读取其配置的列数，并将每列的文本写入单独的文件。没有文本框的形状将被跳过。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
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

要在整个演示文稿中更新文本，请遍历幻灯片和形状，挑选自动形状，然后编辑其文本段落。在段落层面进行操作可同时更改文本和字符格式。

下面的示例将自动形状文本中所有 `years` 替换为 `months`，并将受影响的段落加粗：

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

此遍历仅更新自动形状中的文本。表格、图表、SmartArt 或组合形状中的文本需要遍历这些对象各自的集合。

## **添加带超链接的文本框**

超链接可以分配给特定的文本段落，仅该段落会作为可点击链接。使用 [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) 将段落与外部 URL 关联。

下面的示例创建了带链接的文本并将其保存到演示文稿中：

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

[占位符](/slides/zh/java/manage-placeholder/) 可以从 [母版幻灯片](https://reference.aspose.com/slides/zh/java/com.aspose.slides/masterslide/)或 [布局幻灯片](https://reference.aspose.com/slides/zh/java/com.aspose.slides/layoutslide/) 继承位置和格式。普通文本框是创建所在幻灯片上的独立形状，布局变化时不会获得占位符的行为。

**如何在不更改图表、表格或 SmartArt 中的文本的情况下替换文本？**

如 “更新文本” 示例所示，仅遍历实现了 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/) 的形状。图表、表格和 SmartArt 将文本存储在各自的对象模型中，因而不会被该循环修改。