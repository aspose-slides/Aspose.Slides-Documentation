---
title: Manage SmartArt Shape
type: docs
weight: 20
url: /net/manage-smartart-shape/
---

## **Create SmartArt Shape**
Aspose.Slides for .NET now facilitates to add custom SmartArt shapes in their slides from scratch. Aspose.Slides for .NET has provided the simplest API to create SmartArt shapes in an easiest way. To create a SmartArt shape in a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add a SmartArt shape by setting it LayoutType.
- Write the modified presentation as a PPTX file.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_SmartArts();

// Create directory if it is not already present.
bool IsExists = System.IO.Directory.Exists(dataDir);
if (!IsExists)
    System.IO.Directory.CreateDirectory(dataDir);
// Instantiate the presentation
using (Presentation pres = new Presentation())
{

    // Access the presentation slide
    ISlide slide = pres.Slides[0];

    // Add Smart Art Shape
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Saving presentation
    pres.Save(dataDir + "SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Access SmartArt Shape in Slide**
The following code will be used to access the SmartArt shapes added in presentation slide. In sample code we will traverse through every shape inside the slide and check if it is a SmartArt shape. If shape is of SmartArt type then we will typecast that to SmartArt instance.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_SmartArts();

// Load the desired the presentation
using (Presentation pres = new Presentation(dataDir + "AccessSmartArtShape.pptx"))
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

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Check the SmartArt shape with particular LayoutType and perform what is required to be done afterwards.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_SmartArts();

using (Presentation presentation = new Presentation(dataDir + "AccessSmartArtShape.pptx"))
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

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Find the SmartArt shape with particular Style.
- Set the new Style for the SmartArt shape.
- Save the Presentation.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_SmartArts();

using (Presentation presentation = new Presentation(dataDir + "AccessSmartArtShape.pptx"))
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
    presentation.Save(dataDir + "ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```



## **Change SmartArt Shape Color Style**
In this example, we will learn to change the color style for any SmartArt shape. In the following sample code will access the SmartArt shape with particular color style and will change its style.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Find the SmartArt shape with particular Color Style.
- Set the new Color Style for the SmartArt shape.
- Save the Presentation.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_SmartArts();

using (Presentation presentation = new Presentation(dataDir + "AccessSmartArtShape.pptx"))
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
    presentation.Save(dataDir + "ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

