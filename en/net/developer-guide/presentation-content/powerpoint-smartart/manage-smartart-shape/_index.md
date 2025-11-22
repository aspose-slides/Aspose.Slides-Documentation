---
title: Manage SmartArt Graphics in Presentations in .NET
linktitle: SmartArt Graphics
type: docs
weight: 20
url: /net/manage-smartart-shape/
keywords:
- SmartArt object
- SmartArt graphic
- SmartArt style
- SmartArt color
- create SmartArt
- add SmartArt
- edit SmartArt
- change SmartArt
- access SmartArt
- SmartArt layout type
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Automate PowerPoint SmartArt creation, editing, and styling in .NET using Aspose.Slides, featuring concise code examples and performance-focused guidance."
---

## **Create SmartArt Shape**
Aspose.Slides for .NET now facilitates to add custom SmartArt shapes in their slides from scratch. Aspose.Slides for .NET has provided the simplest API to create SmartArt shapes in an easiest way. To create a SmartArt shape in a slide, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add a SmartArt shape by setting it LayoutType.
- Write the modified presentation as a PPTX file.

```c#
// Instantiate the presentation
using (Presentation pres = new Presentation())
{

    // Access the presentation slide
    ISlide slide = pres.Slides[0];

    // Add Smart Art Shape
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Saving presentation
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Access SmartArt Shape in Slide**
The following code will be used to access the SmartArt shapes added in presentation slide. In sample code we will traverse through every shape inside the slide and check if it is a SmartArt shape. If shape is of SmartArt type then we will typecast that to SmartArt instance.

```c#
// Load the desired the presentation
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Traverse through every shape inside first slide
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Check if shape is of SmartArt type
        if (shape is ISmartArt)
        {
            // Typecast shape to SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```



## **Access SmartArt Shape with Particular Layout Type**
The following sample code will help to access the SmartArt shape with particular LayoutType. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the SmartArt shape is added.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Check the SmartArt shape with particular LayoutType and perform what is required to be done afterwards.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Traverse through every shape inside first slide
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Check if shape is of SmartArt type
        if (shape is ISmartArt)
        {
            // Typecast shape to SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Checking SmartArt Layout
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```



## **Change SmartArt Shape Style**
The following sample code will help to access the SmartArt shape with particular LayoutType.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Find the SmartArt shape with particular Style.
- Set the new Style for the SmartArt shape.
- Save the Presentation.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Traverse through every shape inside first slide
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Check if shape is of SmartArt type
        if (shape is ISmartArt)
        {
            // Typecast shape to SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Checking SmartArt style
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Changing SmartArt Style
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Saving Presentation
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```



## **Change SmartArt Shape Color Style**
In this example, we will learn to change the color style for any SmartArt shape. In the following sample code will access the SmartArt shape with particular color style and will change its style.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Find the SmartArt shape with particular Color Style.
- Set the new Color Style for the SmartArt shape.
- Save the Presentation.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Traverse through every shape inside first slide
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Check if shape is of SmartArt type
        if (shape is ISmartArt)
        {
            // Typecast shape to SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Checking SmartArt color type
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Changing SmartArt color type
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Saving Presentation
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Can I animate SmartArt as a single object?**

Yes. SmartArt is a shape, so you can apply [standard animations](/slides/net/powerpoint-animation/) via the animations API (entrance, exit, emphasis, motion paths) just like for other shapes.

**How can I find a specific SmartArt on a slide if I don’t know its internal ID?**

Set and use the Alternative Text (AltText) and search for the shape by that value—this is a recommended way to locate the target shape.

**Can I group SmartArt with other shapes?**

Yes. You can group SmartArt with other shapes (pictures, tables, etc.) and then [manipulate the group](/slides/net/group/).

**How do I get an image of a specific SmartArt (e.g., for a preview or report)?**

Export a thumbnail/image of the shape; the library can [render individual shapes](/slides/net/create-shape-thumbnails/) to raster files (PNG/JPG/TIFF).

**Will the SmartArt appearance be preserved when converting the whole presentation to PDF?**

Yes. The rendering engine targets high fidelity for [PDF export](/slides/net/convert-powerpoint-to-pdf/), with a range of quality and compatibility options.
