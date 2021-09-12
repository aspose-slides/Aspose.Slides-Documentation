---
title: Manage TextBox
type: docs
weight: 20
url: /net/manage-textbox/
keywords: "Textbox, Text frame, Add textbox, Textbox with hyperlink, C#, Csharp, Aspose.Slides for .NET"
description: "Add textbox or text frame to PowerPoint presentations in C# or ,NET"
---

## **Create TextBox on Slide**
Using Aspose.Slides for .NET, developers can create TextBox on a Slide in the Presentation. All you have to do is to add an AutoShape of Rectangle type and call the AddTextFrame method exposed by AutoShapeEX object. Please follow the steps below to create TextBox by using Aspose.Slides for .NET API:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Obtain the reference of the first slide in the presentation which is created on the instantiation of Presentation.
- Add an [IAutoShape](https://apireference.aspose.com/net/slides/aspose.slides/iautoshape) with [ShapeType](https://apireference.aspose.com/net/slides/aspose.slides/igeometryshape/properties/shapetype) as Rectangle at a specified position of the slide and obtain the reference of that newly added IAutoShape object.
- Add a TextFrame to the AutoShape containing Aspose TextBox as default text.
- Finally, write the [PPTX ](https://wiki.fileformat.com/presentation/pptx/)file using the Presentation object.

The implementation of the above steps is demonstrated below in an example.

```c#
// Instantiate PresentationEx// Instantiate PresentationEx
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add an AutoShape of Rectangle type
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Add TextFrame to the Rectangle
    ashp.AddTextFrame(" ");

    // Accessing the text frame
    ITextFrame txtFrame = ashp.TextFrame;

    // Create the Paragraph object for text frame
    IParagraph para = txtFrame.Paragraphs[0];

    // Create Portion object for paragraph
    IPortion portion = para.Portions[0];

    // Set Text
    portion.Text = "Aspose TextBox";

    // Save the presentation to disk
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Add Column In TextBoxes**
Using Aspose.Slides for .NET, developers can add column in text boxes on a Slide in the Presentation, property ColumnCount and ColumnSpacing has been added to [ITextFrameFormat ](https://apireference.aspose.com/net/slides/aspose.slides/itextframeformat)interface and [TextFrameFormat](https://apireference.aspose.com/net/slides/aspose.slides/textframeformat) class respectively. These properties specify the number of columns in the textbox and set an amount of spacing in points between columns.

The implementation is demonstrated below in an example.

```c#
using (Presentation presentation = new Presentation())
{
	// Get the first slide of presentation
	ISlide slide = presentation.Slides[0];

	// Add an AutoShape of Rectangle type
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Add TextFrame to the Rectangle
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Get text format of TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Specify number of columns in TextFrame
	format.ColumnCount = 3;

	// Specify spacing between columns
	format.ColumnSpacing = 10;

	// Save created presentation
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```


## **Add Columns In Text Frame**
Using Aspose.Slides for .NET, developers can add columns in text frames on a Slide in the Presentation. **ColumnCount** property has been added to **[ITextFrameFormat](https://apireference.aspose.com/net/slides/aspose.slides/itextframeformat)** interface. This property specifies the number of columns in the text frame.

The implementation is demonstrated below in an example.

```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are limited to be within a single text container -- " +
                                "you can add or delete text and the new or remaining text automatically adjusts " +
                                "itself to flow within the container. You cannot have text flow from one container " +
                                "to other though -- we told you PowerPoint's column options for text are limited!";
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



## **Create TextBox with Hyperlink**
In this topic, we will create a TextBox with a Hyperlink. You will have to instantiate [IHyperlinkManager](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkmanager) class and assign it to the desired portion of the TextFrame associated with the TextBox. Please follow the steps below to create a TextBox with Hyperlink by using Aspose.Slides for .NET API:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Obtain the reference of the first slide in the presentation which is created on instantiation of Presentation.
- Add an AutoShape with ShapeType as Rectangle at a specified position of the slide and obtain the reference of that newly added AutoShape object.
- Add a TextFrame to the AutoShape containing Aspose TextBox as default text.
- Instantiate the IHyperlinkManager class.
- Assign the IHyperlinkManager object to the HLinkClick property associated with the desired portion of the TextFrame.
- Finally, write the PPTX file using the Presentation object.

The implementation of the above steps is demonstrated below in an example.

```c#
// Instantiate a Presentation class that represents a PPTX
Presentation pptxPresentation = new Presentation();

// Get first slide
ISlide slide = pptxPresentation.Slides[0];

// Add an AutoShape of Rectangle Type
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Cast the shape to AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Access ITextFrame associated with the AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Add some text to the frame
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Set Hyperlink for the portion text
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");
// Save the PPTX Presentation
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

