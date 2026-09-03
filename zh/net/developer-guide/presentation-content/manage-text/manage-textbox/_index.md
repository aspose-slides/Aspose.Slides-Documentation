---
title: 在 .NET 中管理演示文稿中的文本框
linktitle: 管理文本框
type: docs
weight: 20
url: /zh/net/manage-textbox/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建、识别、格式化和更新文本框。"
---
## **简介**

在 Aspose.Slides for .NET 中，幻灯片文本存储在属于形状的文本框中。 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/) 接口表示最常见的承载文本的形状，并通过 [IAutoShape.TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/textframe/) 属性公开其文本。

{{% alert color="info" title="Note" %}}
每个自动形状实现 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/)，但并非所有形状都是自动形状或支持文本框。在处理现有演示文稿时，在访问其文本之前，请检查形状是否实现 `IAutoShape`。
{{% /alert %}}

## **在幻灯片上创建文本框**

要创建文本框，需要向幻灯片添加自动形状，向其文本框添加文本，然后保存演示文稿。以下示例创建一个矩形文本框：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

传递给 [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addautoshape/) 的坐标和尺寸以点为单位。 [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/addtextframe/) 使用提供的文本初始化文本框。

## **检查文本框形状**

使用 [AutoShape.IsTextBox](https://reference.aspose.com/slides/zh/net/aspose.slides/autoshape/istextbox/) 属性可确定自动形状是否被视为文本框。当演示文稿同时包含承载文本的自动形状和纯图形自动形状时，这非常有用。

![文本框和形状](istextbox.png)

以下示例检查演示文稿中的每个自动形状：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

新添加的自动形状在包含非空文本之前不被视为文本框。您可以通过 [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/addtextframe/) 或 [ITextFrame.Text](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/text/) 提供该文本。添加或分配空字符串会使 `IsTextBox` 保持为 `false`：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

前两次调用打印 `True`；后两次打印 `False`。

## **查找拥有文本框的形状**

通用文本处理代码可能会收到一个 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/)，但不知道它属于哪个演示文稿对象。使用只读的 [ITextFrame.ParentShape](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/parentshape/) 属性可返回其所属的 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/)。

对于由自动形状或其他承载文本的形状拥有的文本框，`ParentShape` 包含所有者，而 [ITextFrame.ParentCell](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/parentcell/) 为 `null`。在访问之前请检查返回值。要识别形状和表格单元格所有者（包括与 SmartArt 节点关联的形状），请参阅 [Search and Replace Text](/slides/zh/net/search-and-replace-text/)。

## **向文本框添加列**

[ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/columncount/) 属性将文本框划分为多列，而 [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/columnspacing/) 设置列间的间距（单位为点）。这两个设置属于 [ITextFrameFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/)，可通过已有文本框的文本框进行更改。文本在同一形状的列之间重新流动；不会继续流入其他形状。

以下示例创建一个三列文本框，列间距为 10 点，保存演示文稿，并从输出文件中读取存储的设置：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **从各列提取文本**

使用 [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/zh/net/aspose.slides/textframe/splittextbycolumns/) 可检索现有文本框中分配给每个可视列的文本。该方法按列顺序返回每列的字符串。单列文本框返回仅含一个元素的数组，空列则表示为空字符串。返回的字符串仅包含纯文本；不保留部分级别的格式。

在以下情况下此功能非常有用：

- 在保留列阅读顺序的同时提取文本。
- 索引或比较多列幻灯片的内容。
- 将每列导出到单独的文件、数据库字段或其他目标。
- 检查在更改 [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/columncount/)、[ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/columnspacing/)、字体或文本框大小后，文本如何重新分布。

该方法报告当前 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 中分布的文本；不会自动在不同形状或文本框之间流动文本。列分布可能受可用字体和其他文本布局设置的影响，因此在一致性结果很重要时，请确保所需字体可用。

以下示例加载演示文稿，查找第一个具有多列文本框的自动形状，读取其配置的列数，并将每列的文本写入单独的文件。没有文本框的形状将被跳过。

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **更新文本**

要在整个演示文稿中更新文本，遍历幻灯片和形状，选择自动形状，然后编辑其文本部分。在部分级别进行操作可同时更改文本和字符格式。

以下示例将自动形状文本中所有 `years` 替换为 `months`，并将受影响的部分加粗：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

此遍历仅更新自动形状中的文本。表格、图表、SmartArt 或组合形状中的文本需要遍历这些对象的各自集合。

## **添加带超链接的文本框**

超链接可以分配给特定的文本部分，仅该文本可作为可点击链接。使用 [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/zh/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) 将该部分关联到外部 URL。

以下示例创建带链接的文本并将其保存到演示文稿：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **常见问题**

**文本框和母版或布局幻灯片上的文本占位符有什么区别？**

[placeholder](/slides/zh/net/manage-placeholder/) 可以从 [master slide](https://reference.aspose.com/slides/zh/net/aspose.slides/masterslide/) 或 [layout slide](https://reference.aspose.com/slides/zh/net/aspose.slides/layoutslide/) 继承其位置和格式。普通文本框是创建所在幻灯片上的独立形状，布局更改时不会获得占位符行为。

**如何在不更改图表、表格或 SmartArt 中文本的情况下替换文本？**

将遍历限制在实现了 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/) 的形状上，如“更新文本”示例所示。图表、表格和 SmartArt 在各自的对象模型中存储文本，因此不会被该循环修改。