---
title: Manage Placeholders in Presentations with Python
linktitle: Manage Placeholders
type: docs
weight: 10
url: /python-net/manage-placeholder/
keywords:
- placeholder
- text placeholder 
- image placeholder
- chart placeholder
- prompt text
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Effortlessly manage placeholders in Aspose.Slides for Python via .NET: replace text, customize prompts & set image transparency in PowerPoint and OpenDocument."
---

## **Change Text in Placeholder**

Using [Aspose.Slides for Python via .NET](/slides/python-net/), you can find and modify placeholders on slides in presentations. Aspose.Slides allows you to make changes to the text in a placeholder.

**Prerequisite**: You need a presentation that contains a placeholder. You can create such a presentation in the standard Microsoft PowerPoint app.

This is how you use Aspose.Slides to replace the text in the placeholder in that presentation:

1. Instantiate the [`Presentation`](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and pass the presentation as an argument.
2. Get a slide reference through its index.
3. Iterate through the shapes to find the placeholder.
4. Typecast the placeholder shape to an [`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) and change the text using the [`TextFrame`](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) associated with the [`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
5. Save the modified presentation.

This Python code shows how to change the text in a placeholder:

```python
import aspose.slides as slides

# Instantiates a Presentation class
with slides.Presentation(path + "ReplacingText.pptx") as pres:
    # Accesses the first slide
    sld = pres.slides[0]

    # Iterates through shapes to find the placeholder
    for shp in sld.shapes:
        if shp.placeholder != None:
            # Changes the text in each placeholder
            shp.text_frame.text = "This is Placeholder"

    # Saves the presentation to disk
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Set Prompt Text in a Placeholder**
Standard and pre-built layouts contain placeholder prompt texts such as ***Click to add a title*** or ***Click to add a subtitle***. Using Aspose.Slides, you can insert your preferred prompt texts into placeholder layouts.

This Python code shows you how to set the prompt text in a placeholder:

```python
import aspose.slides as slides

with slides.Presentation(path + "Presentation2.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.slide.shapes: # Iterates through the slide
        if shape.placeholder != None and type(shape) is slides.AutoShape:
            text = ""
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE: # PowerPoint displays "Click to add title". 
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE: # Adds subtitle.
                text = "Add Subtitle"

            shape.text_frame.text = text

            print("Placeholder with text: {text}".format(text = text))

    pres.save("Placeholders_PromptText.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Placeholder Image Transparency**

Aspose.Slides allows you to set the transparency of the background image in a text placeholder. By adjusting the transparency of the picture in such a frame, you can make the text or the image stand out (depending on the text's and picture's colors).

This Python code shows you how to set the transparency for a picture background (inside a shape):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoShape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    
    autoShape.fill_format.fill_type = slides.FillType.PICTURE
    with open("image.png", "rb") as in_file:
        autoShape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(in_file)

        autoShape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        autoShape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)

```

