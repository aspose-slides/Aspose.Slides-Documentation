---
title: Shape Manipulations
type: docs
weight: 40
url: /net/shape-manipulations/
keywords: "PowerPoint shape, shape on slide, find shape, clone shape, remove shape, hide shape, change shape order, get interlop shape ID, shape alternative text, shape layout formats, shape as SVG, align shape, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Manipulate PowerPoint shapes in C# or .NET"
---

## **Find Shape in Slide**
This topic will describe a simple technique to make it easier for developers to find a specific shape on a slide without using its internal Id. It is important to know that PowerPoint Presentation files do not have any way to identify shapes on a slide except an internal unique Id. It seems to be difficult for developers to find a shape using its internal unique Id. All shapes added to the slides have some Alt Text. We suggest developers to use alternative text for finding a specific shape. You can use MS PowerPoint to define the alternative text for objects which you are planning to change in the future.

After setting the alternative text of any desired shape, you can then open that presentation using Aspose.Slides for .NET and iterate through all shapes added to a slide. During each iteration, you can check the alternative text of the shape and the shape with the matching alternative text would be the shape required by you. To demonstrate this technique in a better way, we have created a method, [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) that does the trick to find a specific shape in a slide and then simply returns that shape.

```c#
public static void Run()
{
    // Instantiate a Presentation class that represents the presentation file
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Alternative text of the shape to be found
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Method implementation to find a shape in a slide using its alternative text
public static IShape FindShape(ISlide slide, string alttext)
{
    // Iterating through all shapes inside the slide
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // If the alternative text of the slide matches with the required one then
        // Return the shape
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```



## **Clone Shape**
To clone a shape to a slide using Aspose.Slides for .NET:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its index.
1. Access the source slide shape collection.
1. Add new slide to the presentation.
1. Clone shapes from the source slide shape collection to the new slide.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.

```c#
// Instantiate Presentation class
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Write the PPTX file to disk
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```



## **Remove Shape**
Aspose.Slides for .NET allows developers to remove any shape. To remove the shape from any slide, please follow the steps below:

1. Create an instance of `Presentation` class.
1. Access the first slide.
1. Find the shape with specific AlternativeText.
1. Remove the shape.
1. Save file to disk.

```c#
// Create Presentation object
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = pres.Slides[0];

// Add autoshape of rectangle type
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Save presentation to disk
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```



## **Hide Shape**
Aspose.Slides for .NET allows developers to hide any shape. To hide the shape from any slide, please follow the steps below:

1. Create an instance of `Presentation` class.
1. Access the first slide.
1. Find the shape with specific AlternativeText.
1. Hide the shape.
1. Save file to disk.

```c#
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = pres.Slides[0];

// Add autoshape of rectangle type
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Save presentation to disk
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```



## **Change Shapes Order**
Aspose.Slides for .NET allows developers to reorder the shapes. Reordering the shape specifies which shape is on the front or which shape is at the back. To reorder the shape from any slide, please follow the steps below:

1. Create an instance of `Presentation` class.
1. Access the first slide.
1. Add a shape.
1. Add some text in shape's text frame.
1. Add another shape with the same co-ordinates.
1. Reorder the shapes.
1. Save file to disk.

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```


## **Get Interop Shape ID**
Aspose.Slides for .NET allows developers to get a unique shape identifier in slide scope in contrast to the UniqueId property, which allows obtaining a unique identifier in presentation scope. Property OfficeInteropShapeId was added to IShape interfaces and Shape class respectively. The value returned by OfficeInteropShapeId property corresponds to the value of the Id of the Microsoft.Office.Interop.PowerPoint.Shape object. Below is a sample code is given.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Getting unique shape identifier in slide scope
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```



## **Set Alternative Text for Shape**
Aspose.Slides for .NET allows developers to set AlternateText of any shape. 
Shapes in a presentation could be distinguished by the AlternativeText or Shape Name property. 
AlternativeText property could be read or set by using Aspose.Slides as well as Microsoft PowerPoint. 
By using this property, you can tag a shape and can perform different operations as Removing a shape, 
Hiding a shape or Reordering shapes on a slide.
To set the AlternateText of a shape, please follow the steps below:

1. Create an instance of `Presentation` class.
1. Access the first slide.
1. Add any shape to the slide.
1. Do some work with the newly added shape.
1. Traverse through shapes to find a shape.
1. Set the AlternativeText.
1. Save file to disk.

```c#
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = pres.Slides[0];

// Add autoshape of rectangle type
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// Save presentation to disk
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```




## **Access Layout Formats for Shape**
 Aspose.Slides for .NET provides a simple API to access layout formats for a shape. This article demonstrates how you can access layout formats.

Below sample code is given.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **Render Shape as SVG**
Now Aspose.Slides for .NET support for rendering a shape as svg. WriteAsSvg method (and its overload) has been added to Shape class and IShape interface. This method allows to save content of the shape as an SVG file. Code snippet below shows how to export slide's shape to an SVG file.

```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```

## **Align Shape**

Through the [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index) overloaded method, you can 

* align shapes relative to a slide's margins. See Example 1. 
* align shapes relative to each other. See Example 2. 

The [ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) enumeration defines the available alignment options.

**Example 1**

This C# code shows you how to align shapes with indices 1,2 and 4 along the border at the top of a slide:
Source code below aligns shapes with indices 1,2 and 4 along the top border of the slide. 

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

**Example 2**

This C# code shows you how to align an entire collection of shapes relative to the bottom shape in the collection:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **Flip Properties**

In Aspose.Slides, the [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) class provides control over horizontal and vertical mirroring of shapes via its `FlipH` and `FlipV` properties. Both properties are of type [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/), allowing values of `True` to indicate a flip, `False` for no flip, or `NotDefined` to use default behavior. These values are accessible from a shape’s [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/). 

To modify the flip settings, a new [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) instance is constructed with the shape’s current position and size, the desired values for `FlipH` and `FlipV`, and the rotation angle. Assigning this instance to the shape’s [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) and saving the presentation applies the mirror transformations and commits them to the output file.

Let’s say we have a sample.pptx file in which the first slide contains a single shape with default flip settings, as shown below.

![The shape to be flipped](shape_to_be_flipped.png)

The following code example retrieves the shape’s current flip properties and flips it both horizontally and vertically.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Retrieve the horizontal flip property of the shape.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Retrieve the vertical flip property of the shape.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    shape.Frame = new ShapeFrame(
        shape.Frame.X, shape.Frame.Y,
        shape.Frame.Width, shape.Frame.Height, 
        NullableBool.True, NullableBool.True, // Flip the shape horizontally and vertically.
        0);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

The result:

![The flipped shape](flipped_shape.png)
