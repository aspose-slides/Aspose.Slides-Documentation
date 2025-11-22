---
title: 管理文本框
type: docs
weight: 20
url: /zh/net/manage-textbox/
keywords:
- 文本框
- 文本框架
- 添加文本
- 更新文本
- 带超链接的文本框
- PowerPoint
- 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "使用 C# 或 .NET 在 PowerPoint 演示文稿中管理文本框或文本框架"
---

幻灯片上的文本通常位于文本框或形状中。因此，要向幻灯片添加文本，必须先添加一个文本框，然后在文本框中放入文本。

为了让您能够添加可容纳文本的形状，Aspose.Slides for .NET 提供了 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) 接口。

{{% alert title="Note" color="warning" %}} 

Aspose.Slides 还提供了 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) 接口，以便您向幻灯片添加形状。然而，并非所有通过 `IShape` 接口添加的形状都能容纳文本。通过 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) 接口添加的形状通常包含文本。

因此，当处理已有的形状并希望向其添加文本时，您可能需要检查并确认它是通过 `IAutoShape` 接口进行强制转换的。只有这样，您才能使用 `IAutoShape` 下的属性 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe)。请参阅本页的 [Update Text](https://docs.aspose.com/slides/net/manage-textbox/#update-text) 部分。

{{% /alert %}}

## **在幻灯片上创建文本框**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  
2. 通过索引获取第一张幻灯片的引用。  
3. 在幻灯片的指定位置添加一个 `ShapeType` 为 `Rectangle` 的 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) 对象，并获取新添加的 `IAutoShape` 对象的引用。  
4. 为 `IAutoShape` 对象添加 `TextFrame` 属性，以容纳文本。在以下示例中，我们添加的文本为 *Aspose TextBox*。  
5. 最后，通过 `Presentation` 对象写入 PPTX 文件。  

下面的 C# 代码实现了上述步骤，演示了如何向幻灯片添加文本：
```c#
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

Aspose.Slides 提供了来自 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 接口的 [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) 属性，允许您检查形状并识别文本框。

![Text box and shape](istextbox.png)

下面的 C# 代码展示了如何检查某个形状是否被创建为文本框：
```c#
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


请注意，如果您仅使用 [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/) 接口的 `AddAutoShape` 方法添加自动形状，则该自动形状的 `IsTextBox` 属性将返回 `false`。但在使用 `AddTextFrame` 方法或 `Text` 属性向自动形状添加文本后，`IsTextBox` 属性会返回 `true`。
```cs
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


## **在文本框中添加列**

Aspose.Slides 提供了来自 [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) 接口和 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类的 [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) 和 [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) 属性，允许您在文本框中添加列。您可以指定文本框的列数，然后指定列之间的点距。

下面的 C# 代码演示了上述操作：
```c#
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


## **在文本帧中添加列**

Aspose.Slides for .NET 提供了来自 [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) 接口的 [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) 属性，可用于在文本帧中添加列。通过该属性，您可以指定文本帧中期望的列数。

下面的 C# 代码展示了如何在文本帧内部添加列：
```c#
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
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
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

Aspose.Slides 允许您更改或更新文本框中包含的文本，或更新演示文稿中所有的文本。

下面的 C# 代码演示了将演示文稿中所有文本更新或更改的操作：
```c#
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
                   foreach (IPortion portion in paragraph.Portions) //遍历段落中的每个文本块
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


## **添加带超链接的文本框**

您可以在文本框中插入链接。单击该文本框时，会打开相应链接。

1. 创建 `Presentation` 类的实例。  
2. 通过索引获取第一张幻灯片的引用。  
3. 在幻灯片的指定位置添加一个 `ShapeType` 为 `Rectangle` 的 `AutoShape` 对象，并获取新添加的 AutoShape 对象的引用。  
4. 为 `AutoShape` 对象添加一个 `TextFrame`，其默认文本为 *Aspose TextBox*。  
5. 实例化 `IHyperlinkManager` 类。  
6. 将 `IHyperlinkManager` 对象分配给您希望在 `TextFrame` 中设置的特定文本片段的 [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) 属性。  
7. 最后，通过 `Presentation` 对象写入 PPTX 文件。  

下面的 C# 代码实现了上述步骤，演示了如何向幻灯片添加带超链接的文本框：
```c#
// 实例化表示 PPTX 的 Presentation 类
Presentation pptxPresentation = new Presentation();

// Gets the first slide in the presentation
ISlide slide = pptxPresentation.Slides[0];

// Adds an AutoShape object with type set as Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Casts the shape to AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Accesses the ITextFrame property associated with the AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Adds some text to the frame
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Sets the Hyperlink for the portion text
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Saves the PPTX Presentation
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**在使用母版幻灯片时，文本框和文本占位符有什么区别？**

[占位符](/slides/zh/net/manage-placeholder/) 继承自 [母版](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) 的样式/位置，并且可以在 [布局](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) 上被覆盖，而普通文本框是特定幻灯片上的独立对象，切换布局时不会改变。

**如何在不影响图表、表格和 SmartArt 中文本的情况下，对整个演示文稿执行批量文本替换？**

将遍历范围限制在具有文本框的自动形状上，并通过单独遍历其集合或跳过这些对象类型，排除嵌入的对象（如 [图表](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)、[表格](https://reference.aspose.com/slides/net/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)）。