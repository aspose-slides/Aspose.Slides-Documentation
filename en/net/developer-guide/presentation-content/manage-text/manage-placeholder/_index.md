---
title: Manage Presentation Placeholders in .NET
linktitle: Manage Placeholders
type: docs
weight: 10
url: /net/manage-placeholder/
keywords:
- placeholder
- text placeholder 
- image placeholder
- chart placeholder
- prompt text
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Effortlessly manage placeholders in Aspose.Slides for .NET: replace text, customize prompts & set image transparency in PowerPoint and OpenDocument."
---

## **Change Text in Placeholder**
Using [Aspose.Slides for .NET](/slides/net/), you can find and modify placeholders on slides in presentations. Aspose.Slides allows you to make changes to the text in a placeholder.

**Prerequisite**: You need a presentation that contains a placeholder. You can create such a presentation in the standard Microsoft PowerPoint app.

This is how you use Aspose.Slides to replace the text in the placeholder in that presentation:

1. Instantiate the [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) class and pass the presentation as an argument.
2. Get a slide reference through its index.
3. Iterate through the shapes to find the placeholder.
4. Typecast the placeholder shape to an [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) and change the text using the [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/) associated with the [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/). 
5. Save the modified presentation.

This C# code shows how to change the text in a placeholder:

```c#
// Instantiates a Presentation class
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Accesses the first slide
    ISlide sld = pres.Slides[0];

    // Iterates through shapes to find the placeholder
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Changes the text in each placeholder
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // Saves the presentation to disk
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Set Prompt Text in Placeholder**
Standard and pre-built layouts contain placeholder prompt texts such as ***Click to add a title*** or ***Click to add a subtitle***. Using Aspose.Slides, you can insert your preferred prompt texts into placeholder layouts.

This C# code shows you how to set the prompt text in a placeholder:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Iterates through the slide
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint displays "Click to add title"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Adds subtitle
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Set Placeholder Image Transparency**

Aspose.Slides allows you to set the transparency of the background image in a text placeholder. By adjusting the transparency of the picture in such a frame, you can make the text or the image stand out (depending on the text's and picture's colors).

This C# code shows you how to set the transparency for a picture background (inside a shape):

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **FAQ**

**What is a base placeholder, and how is it different from a local shape on a slide?**

A base placeholder is the original shape on a layout or master that the slide’s shape inherits from—type, position, and some formatting come from it. A local shape is independent; if there’s no base placeholder, inheritance doesn’t apply.

**How can I update all titles or captions across a presentation without iterating over every slide?**

Edit the corresponding placeholder on the layout or the master. Slides based on those layouts/that master will automatically inherit the change.

**How do I control the standard header/footer placeholders—date & time, slide number, and footer text?**

Use the HeaderFooter managers at the appropriate scope (normal slides, layouts, master, notes/handouts) to turn those placeholders on or off and to set their content.
