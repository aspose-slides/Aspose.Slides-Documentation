---
title: 管理文本框
type: docs
weight: 20
url: /zh/net/manage-textbox/
keywords: "文本框, 文本框架, 添加文本框, 带超链接的文本框, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中向 PowerPoint 演示文稿添加文本框或文本框架"
---

幻灯片上的文本通常存在于文本框或形状中。因此，要向幻灯片添加文本，您必须先添加一个文本框，然后在文本框中放入一些文本。

为了允许您添加一个可以容纳文本的形状，Aspose.Slides for .NET 提供了 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) 接口。

{{% alert title="注意" color="warning" %}}

Aspose.Slides 还提供了 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) 接口，允许您向幻灯片添加形状。然而，并不是通过 `IShape` 接口添加的所有形状都可以容纳文本。通过 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) 接口添加的形状通常包含文本。

因此，在处理您要添加文本的现有形状时，您可能需要检查并确认它是通过 `IAutoShape` 接口进行转换的。只有这样，您才能与 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) 进行交互，这是 `IAutoShape` 下的一个属性。请参阅本页上的 [更新文本](https://docs.aspose.com/slides/net/manage-textbox/#update-text) 部分。

{{% /alert %}}

## **在幻灯片上创建文本框**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过其索引获取第一张幻灯片的引用。
3. 在幻灯片的指定位置添加一个 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) 对象，并将 [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) 设置为 `Rectangle`，并获取新添加的 `IAutoShape` 对象的引用。
4. 向 `IAutoShape` 对象添加一个包含文本的 `TextFrame` 属性。在下面的示例中，我们添加了以下文本：*Aspose 文本框*
5. 最后，通过 `Presentation` 对象写入 PPTX 文件。

以下 C# 代码——上述步骤的实现——向您展示了如何向幻灯片添加文本：

```c#
// 实例化 PresentationEx
using (Presentation pres = new Presentation())
{

    // 获取演示文稿中的第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加类型设置为矩形的 AutoShape
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 向矩形添加 TextFrame
    ashp.AddTextFrame(" ");

    // 访问文本框
    ITextFrame txtFrame = ashp.TextFrame;

    // 为文本框创建段落对象
    IParagraph para = txtFrame.Paragraphs[0];

    // 为段落创建一个 Portion 对象
    IPortion portion = para.Portions[0];

    // 设置文本
    portion.Text = "Aspose 文本框";

    // 将演示文稿保存到磁盘
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **检查文本框形状**

Aspose.Slides 提供了 [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) 属性（来自 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) 类）允许您检查形状并找到文本框。

![文本框和形状](istextbox.png)

以下 C# 代码向您展示了如何检查一个形状是否作为文本框创建：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(pres, (shape, slide, index) =>
    {
        if (shape is AutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "形状是文本框" : "形状不是文本框");
        }
    });
}
```

## **在文本框中添加列**

Aspose.Slides 提供了 [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) 和 [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) 属性（来自 [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) 接口和 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类），允许您向文本框添加列。您可以指定文本框中的列数，然后指定列之间的间距（单位为点）。

以下 C# 代码演示了所述操作：

```c#
using (Presentation presentation = new Presentation())
{
	// 获取演示文稿中的第一张幻灯片
	ISlide slide = presentation.Slides[0];

	// 添加类型设置为矩形的 AutoShape
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// 向矩形添加 TextFrame
	aShape.AddTextFrame("所有这些列都被限制在一个单一的文本容器内 -- " +
	"您可以添加或删除文本，新的或剩余的文本会自动调整 " +
	"以在容器内流动。然而，您无法让文本从一个容器流动到另一个容器 -- " +
	"我们告诉您 PowerPoint 的文本列选项是有限的！");

	// 获取文本框的文本格式
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// 指定 TextFrame 中的列数
	format.ColumnCount = 3;

	// 指定列之间的间距
	format.ColumnSpacing = 10;

	// 保存演示文稿
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **在文本框架中添加列**

Aspose.Slides for .NET 提供了 [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) 属性（来自 [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) 接口），允许您在文本框架中添加列。通过该属性，您可以指定文本框架中所需的列数。

以下 C# 代码向您展示了如何在文本框架中添加列：

```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "所有这些列都被强制保留在单个文本容器内 -- " +
                                "您可以添加或删除文本 - 新的或剩余的文本会自动调整 " +
                                "以保持在容器内。然而，您无法让文本从一个容器溢出到另一个容器，" +
                                "因为 PowerPoint 的文本列选项是有限的！";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
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

Aspose.Slides 允许您更改或更新文本框中包含的文本或演示文稿中包含的所有文本。

以下 C# 代码演示了一个操作，其中更新或更改演示文稿中的所有文本：

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) // 检查形状是否支持文本框 (IAutoShape)
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) // 遍历文本框中的段落
               {
                   foreach (IPortion portion in paragraph.Portions) // 遍历段落中的每个部分
                   {
                       portion.Text = portion.Text.Replace("years", "months"); // 更改文本
                       portion.PortionFormat.FontBold = NullableBool.True; // 更改格式
                   }
               }
           }
       }
   }
  
   // 保存修改后的演示文稿
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **添加带超链接的文本框**

您可以在文本框中插入链接。当单击文本框时，用户将被引导打开该链接。

1. 创建一个 `Presentation` 类的实例。
2. 通过其索引获取第一张幻灯片的引用。
3. 在幻灯片的指定位置添加一个 `AutoShape` 对象，`ShapeType` 设置为 `Rectangle`，并获取新添加的 AutoShape 对象的引用。
4. 向 `AutoShape` 对象添加一个包含 *Aspose 文本框* 作为其默认文本的 `TextFrame`。
5. 实例化 `IHyperlinkManager` 类。
6. 将 `IHyperlinkManager` 对象分配给与您首选的 `TextFrame` 部分相关的 [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) 属性。
7. 最后，通过 `Presentation` 对象写入 PPTX 文件。

以下 C# 代码——上述步骤的实现——向您展示了如何向幻灯片添加带超链接的文本框：

```c#
// 实例化一个表示 PPTX 的 Presentation 类
Presentation pptxPresentation = new Presentation();

// 获取演示文稿中的第一张幻灯片
ISlide slide = pptxPresentation.Slides[0];

// 添加类型设置为矩形的 AutoShape 对象
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// 将形状转换为 AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// 访问与 AutoShape 相关的 ITextFrame 属性
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// 向框中添加一些文本
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// 为文本部分设置超链接
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// 保存 PPTX 演示文稿
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```