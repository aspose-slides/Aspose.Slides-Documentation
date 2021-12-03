---
title: Manage Placeholder
type: docs
weight: 10
url: /pythonnet/manage-placeholder/
keywords: "Placeholder, Placeholder text, Prompt text, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Change Placeholder text and prompt text in PowerPoint presentations in Python"
---

## **Change Text in a Placeholder**
Using [Aspose.Slides for Python via .NET](/slides/pythonnet/), developers can also find and modify a specific Placeholder present in a slide. In this topic, we are going to demonstrate with the help of an example that how the text contained inside a Placeholder can be replaced or modified using Aspose.Slides for Python via .NET. The following two steps will be used to modify text in Placeholder.

Step 1: Create a Slide Containing a Placeholder

First of all, create a presentation file with a slide containing a Placeholder. You can create this presentation either MS PowerPoint. This is just the demonstration of replacing text in a Placeholder, so, you can create this presentation by yourself. This presentation will be used in the next step and the text in its Placeholder will be replaced.

Step 2: Replace Text of the Placeholder

To replace the text of a Placeholder, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Iterate through the Shapes and find the Placeholder shapes.
- Typecast the Placeholder shape to AutoShape and change the text using the TextFrame associated with the AutoShape.
- Write the modified presentation as a [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents PPTX
with slides.Presentation(path + "ReplacingText.pptx") as pres:
    # Access first slide
    sld = pres.slides[0]

    # Iterate through shapes to find the placeholder
    for shp in sld.shapes:
        if shp.placeholder != None:
            # Change the text of each placeholder
            shp.text_frame.text = "This is Placeholder"

    # Save the PPTX to Disk
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Set Prompt Text in a Placeholder**
As we know that Standard and pre-built layouts contain placeholders with default text like **Click to add a title** or **Click to add subtitle**. Using Aspose.Slides you can add prompt text manually by accessing the default placeholders.

The code snippet below shows how to use this feature:

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation2.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.slide.shapes: # iterate through the slide
        if shape.placeholder != None and type(shape) is slides.AutoShape:
            text = ""
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE: #PowerPoint displays "Click to add title". 
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE: #add subtitle.
                text = "Add Subtitle"

            shape.text_frame.text = text

            print("Placeholder with text: {text}".format(text = text))

    pres.save("Placeholders_PromptText.pptx", slides.export.SaveFormat.PPTX)
```

