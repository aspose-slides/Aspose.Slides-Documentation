---
title: Manage Placeholder
type: docs
weight: 10
url: /net/manage-placeholder/
keywords: "Placeholder, Placeholder text, Prompt text, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Change Placeholder text and prompt text in PowerPoint presentations in C# or .NET"
---

## **Change Text in Placeholder**
Using [Aspose.Slides for .NET](/slides/net/), you can find and modify placeholders on slides in presentations. Aspose.Slides allows you to make changes to the text in a placeholder.

**Prerequisite**: You need a presentation that contains a placeholder. You can create such a presentation in the standard Microsoft PowerPoint app.

This is how you use Aspose.Slides to replace the text in the placeholder in that presentation:

1. Instantiate the [`Presentation`](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class and pass the presentation as an argument.
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

This C# code shows you how to set the transparency for a picture background (inside a shape): xxx

```c#

```

