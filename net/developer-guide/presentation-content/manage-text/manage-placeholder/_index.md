---
title: Manage Placeholder
type: docs
weight: 10
url: /net/manage-placeholder/
---

## **Change Text in a Placeholder**
Using [Aspose.Slides for .NET](/slides/net/), developers can also find and modify a specific Placeholder present in a slide. In this topic, we are going to demonstrate with the help of an example that how the text contained inside a Placeholder can be replaced or modified using Aspose.Slides for .NET. The following two steps will be used to modify text in Placeholder.

Step 1: Create a Slide Containing a Placeholder

First of all, create a presentation file with a slide containing a Placeholder. You can create this presentation either MS PowerPoint. This is just the demonstration of replacing text in a Placeholder, so, you can create this presentation by yourself. This presentation will be used in the next step and the text in its Placeholder will be replaced.

Step 2: Replace Text of the Placeholder

To replace the text of a Placeholder, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Iterate through the Shapes and find the Placeholder shapes.
- Typecast the Placeholder shape to AutoShape and change the text using the TextFrame associated with the AutoShape.
- Write the modified presentation as a [PPTX ](https://wiki.fileformat.com/presentation/pptx/)file.

```c#
// Instantiate Presentation class that represents PPTX// Instantiate Presentation class that represents PPTX
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Access first slide
    ISlide sld = pres.Slides[0];

    // Iterate through shapes to find the placeholder
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Change the text of each placeholder
            ((IAutoShape)shp).TextFrame.Text = "This is Placeholder";
        }

    // Save the PPTX to Disk
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Set Prompt Text in a Placeholder**
As we know that Standard and pre-built layouts contain placeholders with default text like **Click to add a title** or **Click to add subtitle**. Using Aspose.Slides you can add prompt text manually by accessing the default placeholders.

The code snippet below shows how to use this feature:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // iterate through the slide
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) //PowerPoint displays "Click to add title". 
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) //add subtitle.
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

