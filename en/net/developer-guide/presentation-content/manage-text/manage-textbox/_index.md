---
title: Manage Text Boxes in Presentations in .NET
linktitle: Manage Text Box
type: docs
weight: 20
url: /net/manage-textbox/
keywords:
- text box
- text frame
- add text
- update text
- create text box
- check text box
- add text column
- add hyperlink
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET makes it easy to create, edit, and clone text boxes in PowerPoint and OpenDocument files, enhancing your presentation automation."
---

Texts on slides typically exist in text boxes or shapes. Therefore, to add text to a slide, you have to add a textbox first and then put some text inside the textbox. 

To allow you add a shape that can hold text, Aspose.Slides for .NET provides the [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) interface. 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides also provides the [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) interface to allow you to add shapes to slides. However, not all shapes added through the `IShape` interface can hold text. Shapes added through the [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) interface typically contain text. 

Therefore, when dealing with an existing shape to which you want to add text, you may want to check and confirm that it was cast through the `IAutoShape` interface. Only then will you be able to work with [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe), which is a property under `IAutoShape`. See the [Update Text](https://docs.aspose.com/slides/net/manage-textbox/#update-text) section on this page. 

{{% /alert %}}

## **Create a Text Box on a Slide**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class. 
2. Get the first slide's reference through its index. 
3. Add an [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) object with [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) set as `Rectangle` at a specified position on the slide and obtain the reference for the newly added `IAutoShape` object. 
4. Add a `TextFrame` property to the `IAutoShape` object that will contain a text. In the example below, we added this text: *Aspose TextBox*
5. Finally, write the PPTX file through the `Presentation` object. 

This C# code—an implementation of the steps above—shows you how to add text to a slide:

```c#
// Instantiates PresentationEx
using (Presentation pres = new Presentation())
{

    // Gets the first slide in the presentation
    ISlide sld = pres.Slides[0];

    // Adds an AutoShape with type set as Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Adds TextFrame to the Rectangle
    ashp.AddTextFrame(" ");

    // Accesses the text frame
    ITextFrame txtFrame = ashp.TextFrame;

    // Creates the Paragraph object for text frame
    IParagraph para = txtFrame.Paragraphs[0];

    // Creates a Portion object for the paragraph
    IPortion portion = para.Portions[0];

    // Sets the text
    portion.Text = "Aspose TextBox";

    // Saves the presentation to disk
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Check for a Text Box Shape**

Aspose.Slides provides the [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) property from the [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) interface, allowing you to examine shapes and identify text boxes.

![Text box and shape](istextbox.png)

This C# code shows you how to check whether a shape was created as a text box: 

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

Note that if you simply add an autoshape using the `AddAutoShape` method from the [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/) interface, the `IsTextBox` property of the autoshape will return `false`. However, after you add text to the autoshape using the `AddTextFrame` method or the `Text` property, the `IsTextBox` property returns `true`.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox is false
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox is true

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox is false
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox is true

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox is false
    shape3.AddTextFrame("");
    // shape3.IsTextBox is false

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox is false
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox is false
}
```

## **Add Columns to a Text Box**

Aspose.Slides provides the [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) and [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) properties (from the [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) interface and [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) class) to allow you to add columns to textboxes. You get to specify the number of columns in a text box and then specify the spacing in points between columns. 

This code in C# demonstrates the described operation: 

```c#
using (Presentation presentation = new Presentation())
{
	// Gets the first slide in the presentation
	ISlide slide = presentation.Slides[0];

	// Add an AutoShape with type set as Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Add TextFrame to the Rectangle
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Gets the text format of TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Specifies the number of columns in TextFrame
	format.ColumnCount = 3;

	// Specifies the spacing between columns
	format.ColumnSpacing = 10;

	// Saves the presentation
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```


## **Add Columns to a Text Frame**
Aspose.Slides for .NET provides the [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) property (from the [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) interface) that allows you to add columns in text frames. Through this property, you can specify your preferred number of columns in a text frame. 

 This C# code shows you how to add a column inside a text frame:

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

## **Update Text**

Aspose.Slides allows you to change or update the text contained in a text box or all the texts contained in a presentation. 

This C# code demonstrates an operation where all the texts in a presentation are updated or changed:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Checks if shape supports text frame (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Iterates through paragraphs in text frame
               {
                   foreach (IPortion portion in paragraph.Portions) //Iterates through each portion in paragraph
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Changes text
                       portion.PortionFormat.FontBold = NullableBool.True; //Changes formatting
                   }
               }
           }
       }
   }
  
   //Saves the modified presentation
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Add a Text Box with a Hyperlink** 

You can insert a link inside a textbox. When the textbox is clicked, users are directed to open the link. 

1. Create an instance of the `Presentation` class. 
2. Get the first slide's reference through its index.  
3. Add an `AutoShape` object with `ShapeType` set as `Rectangle` at a specified position on the slide and obtain a reference of the newly added AutoShape object.
4. Add a `TextFrame` to the `AutoShape` object that contains *Aspose TextBox* as its default text. 
5. Instantiate the `IHyperlinkManager` class. 
6. Assign the `IHyperlinkManager` object to the [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) property associated with your preferred portion of the `TextFrame`. 
7. Finally, write the PPTX file through the `Presentation` object. 

This C# code—an implementation of the steps above—shows you how to add a text box with a hyperlink to a slide:

```c#
// Instantiates a Presentation class that represents a PPTX
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

**What’s the difference between a text box and a text placeholder when working with master slides?**

A [placeholder](/slides/net/manage-placeholder/) inherits style/position from the [master](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) and can be overridden on [layouts](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/), whereas a regular text box is an independent object on a specific slide and doesn’t change when you switch layouts.

**How can I perform a bulk text replacement across the presentation without touching text inside charts, tables, and SmartArt?**

Limit your iteration to auto-shapes that have text frames and exclude embedded objects ([charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) by traversing their collections separately or skipping those object types.
