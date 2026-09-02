---
title: .NET 中的演示文稿文本框管理
linktitle: 文本框管理
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
description: "Aspose.Slides for .NET 让您轻松在 PowerPoint 和 OpenDocument 文件中创建、编辑和克隆文本框，提升演示文稿自动化水平。"
---
## **介绍**

幻灯片上的文本通常存在于文本框或形状中。因此，要向幻灯片添加文本，必须先添加一个文本框，然后在文本框中放入一些文本。

为了让您添加能够容纳文本的形状，Aspose.Slides for .NET 提供了 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape) 接口。

{{% alert title="Note" color="warning" %}} 

Aspose.Slides 还提供了 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape) 接口，以便您向幻灯片添加形状。然而，通过 `IShape` 接口添加的并非所有形状都能容纳文本。通过 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape) 接口添加的形状通常包含文本。

因此，在处理想要添加文本的现有形状时，您可能需要检查并确认该形状是通过 `IAutoShape` 接口进行强制转换的。只有这样，您才能使用位于 `IAutoShape` 下的 [TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/properties/textframe) 属性。请参阅本页的 [Update Text](https://docs.aspose.com/slides/zh/net/manage-textbox/#update-text) 部分。

{{% /alert %}}

## **在幻灯片上创建文本框**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。  
2. 通过索引获取第一张幻灯片的引用。  
3. 在幻灯片的指定位置添加一个将 `ShapeType` 设置为 `Rectangle` 的 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape) 对象，并获取新添加的 `IAutoShape` 对象的引用。  
4. 为该 `IAutoShape` 对象添加 `TextFrame` 属性以容纳文本。下面的示例中，我们添加了这段文本：*Aspose TextBox*。  
5. 最后，通过 `Presentation` 对象写入 PPTX 文件。  

以下 C# 代码实现了上述步骤，展示了如何向幻灯片添加文本：

```c#
using Aspose.Slides;

// 实例化 PresentationEx
using (Presentation pres = new Presentation())
{

    // 获取演示文稿中的第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加一个类型为 Rectangle 的 AutoShape
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 向矩形添加 TextFrame
    ashp.AddTextFrame(" ");

    // 访问文本框架
    ITextFrame txtFrame = ashp.TextFrame;

    // 为文本框架创建 Paragraph 对象
    IParagraph para = txtFrame.Paragraphs[0];

    // 为段落创建 Portion 对象
    IPortion portion = para.Portions[0];

    // 设置文本
    portion.Text = "Aspose TextBox";

    // 将演示文稿保存到磁盘
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **检查文本框形状**

Aspose.Slides 提供了来自 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/) 接口的 [IsTextBox](https://reference.aspose.com/slides/zh/net/aspose.slides/autoshape/istextbox/) 属性，允许您检查形状并识别文本框。

![文本框和形状](istextbox.png)

以下 C# 代码展示了如何检查形状是否被创建为文本框：

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```

请注意，如果您仅使用来自 [IShapeCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/) 接口的 `AddAutoShape` 方法添加自动形状，则该自动形状的 `IsTextBox` 属性将返回 `false`。但在使用 `AddTextFrame` 方法或 `Text` 属性向该自动形状添加文本后，`IsTextBox` 属性将返回 `true`。

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox 为 false
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox 为 true

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox 为 false
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox 为 true

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox 为 false
    shape3.AddTextFrame("");
    // shape3.IsTextBox 为 false

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox 为 false
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox 为 false
}
```

## **查找拥有文本框的形状**

在通用文本处理代码中，您可能只收到一个 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/)，但并不知道它所属的演示文稿对象。使用 [ITextFrame.ParentShape](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/parentshape/) 属性可返回其所属的 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/)。

对于属于 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/) 或其他包含文本的形状的文本框，`ITextFrame.ParentShape` 已设置且 `ITextFrame.ParentCell` 为 `null`。这两个属性都是只读的导航属性，读取它们不会改变所有权。在访问形状之前，请始终检查返回值是否为 `null`。

有关完整示例（包括识别形状和表格单元格所有者，以及与 SmartArt 节点关联的形状），请参阅 [Search and Replace Text](/slides/zh/net/search-and-replace-text/)。

## **向文本框添加列**

Aspose.Slides 提供了来自 [ITextFrameFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat) 接口和 [TextFrameFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/textframeformat) 类的 [ColumnCount](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/properties/columncount) 与 [ColumnSpacing](https://reference.aspose.com/slides/zh/net/aspose.slides/textframeformat/properties/columnspacing) 属性，允许您向文本框中添加列。您可以指定文本框中的列数以及列间的点距。

下面的 C# 代码演示了该操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// 获取演示文稿中的第一张幻灯片
	ISlide slide = presentation.Slides[0];

	// 添加一个类型为 Rectangle 的 AutoShape
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// 向矩形添加 TextFrame
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// 获取 TextFrame 的文本格式
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// 指定 TextFrame 中的列数
	format.ColumnCount = 3;

	// 指定列之间的间距
	format.ColumnSpacing = 10;

	// 保存演示文稿
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **向文本框架添加列**

Aspose.Slides for .NET 提供了来自 [ITextFrameFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat) 接口的 [ColumnCount](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/properties/columncount) 属性，允许您在文本框架中添加列。通过此属性，您可以指定文本框架中所需的列数。

以下 C# 代码展示了如何在文本框架中添加列：

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **更新文本**

Aspose.Slides 允许您更改或更新文本框中的文本，甚至可以更新整个演示文稿中所有的文本。

下面的 C# 代码演示了对演示文稿中所有文本进行更新或更改的操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //检查形状是否支持文本框 (IAutoShape)。
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //遍历文本框中的段落
               {
                   foreach (IPortion portion in paragraph.Portions) //遍历段落中的每个部分
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //更改文本
                       portion.PortionFormat.FontBold = NullableBool.True; //更改格式
                   }
               }
           }
       }
   }
  
   //保存修改后的演示文稿
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **向文本框添加超链接**

您可以在文本框内部插入链接。单击该文本框时，用户将打开链接。

1. 创建 `Presentation` 类的实例。  
2. 通过索引获取第一张幻灯片的引用。  
3. 在幻灯片的指定位置添加一个将 `ShapeType` 设置为 `Rectangle` 的 `AutoShape` 对象，并获取新添加的 AutoShape 对象的引用。  
4. 为该 `AutoShape` 对象添加一个 `TextFrame`，其默认文本为 *Aspose TextBox*。  
5. 实例化 `IHyperlinkManager` 类。  
6. 将 `IHyperlinkManager` 对象分配给与您在 `TextFrame` 中选定部分关联的 [HyperlinkClick](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/properties/hyperlinkclick) 属性。  
7. 最后，通过 `Presentation` 对象写入 PPTX 文件。  

以下 C# 代码实现了上述步骤，展示了如何向幻灯片添加带超链接的文本框：

```c#
using Aspose.Slides;

// 实例化一个表示 PPTX 的 Presentation 类
Presentation pptxPresentation = new Presentation();

// 获取演示文稿中的第一张幻灯片
ISlide slide = pptxPresentation.Slides[0];

// 添加一个类型为 Rectangle 的 AutoShape 对象
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// 将形状强制转换为 AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// 访问与 AutoShape 关联的 ITextFrame 属性
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// 向框中添加一些文本
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// 为该文本段设置超链接
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// 保存 PPTX 演示文稿
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **常见问题**

**在使用母版幻灯片时，文本框和文本占位符有什么区别？**

[占位符](/slides/zh/net/manage-placeholder/) 继承自 [母版](/slides/zh/net/aspose.slides/masterslide/) 的样式/位置，并且可以在 [布局](/slides/zh/net/aspose.slides/layoutslide/) 上被覆盖，而普通文本框是特定幻灯片上的独立对象，切换布局时不会改变。

**如何在整个演示文稿中进行批量文本替换，同时不影响图表、表格和SmartArt中的文本？**

通过遍历仅包含文本框架的自动形状，并排除嵌入的对象（[图表](/slides/zh/net/aspose.slides.charts/chart/)、[表格](/slides/zh/net/aspose.slides/table/)、[SmartArt](/slides/zh/net/aspose.slides.smartart/smartart/)），分别遍历它们的集合或跳过这些对象类型即可。