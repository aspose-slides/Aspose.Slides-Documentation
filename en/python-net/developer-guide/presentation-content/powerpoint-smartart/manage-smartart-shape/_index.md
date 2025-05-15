---
title: Manage SmartArt Graphics in Presentations Using Python
linktitle: SmartArt Graphics
type: docs
weight: 20
url: /python-net/manage-smartart-shape/
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
- Python
- Aspose.Slides
description: "Automate PowerPoint SmartArt creation, editing, and styling in Python via .NET using Aspose.Slides, featuring concise code examples and performance-focused guidance."
---

## **Create SmartArt Shape**
Aspose.Slides for Python via .NET now facilitates to add custom SmartArt shapes in their slides from scratch. Aspose.Slides for Python via .NET has provided the simplest API to create SmartArt shapes in an easiest way. To create a SmartArt shape in a slide, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
- Obtain the reference of a slide by using its Index.
- Add a SmartArt shape by setting it LayoutType.
- Write the modified presentation as a PPTX file.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Instantiate the presentation
with slides.Presentation() as pres:
    # Access the presentation slide
    slide = pres.slides[0]

    # Add Smart Art Shape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Saving presentation
    pres.save("SimpleSmartArt_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Access SmartArt Shape in Slide**
The following code will be used to access the SmartArt shapes added in presentation slide. In sample code we will traverse through every shape inside the slide and check if it is a SmartArt shape. If shape is of SmartArt type then we will typecast that to SmartArt instance.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "SmartArt.pptx") as pres:

    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Typecast shape to SmartArtEx
            print("Shape Name:" + shape.name)
```



## **Access SmartArt Shape with Particular Layout Type**
The following sample code will help to access the SmartArt shape with particular LayoutType. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the SmartArt shape is added.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Check the SmartArt shape with particular LayoutType and perform what is required to be done afterwards.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Traverse through every shape inside first slide
    for shape in presentation.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Checking SmartArt Layout
            if shape.layout == art.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do some thing here....")
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

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Traverse through every shape inside first slide
    for shape in presentation.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Checking SmartArt style
            if shape.quick_style == art.SmartArtQuickStyleType.SIMPLE_FILL:
                # Changing SmartArt Style
                smart.quick_style = art.SmartArtQuickStyleType.CARTOON

    # Saving Presentation
    presentation.save("ChangeSmartArtStyle_out.pptx", slides.export.SaveFormat.PPTX)
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

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Traverse through every shape inside first slide
    for shape in presentation.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Checking SmartArt color type
            if shape.color_style == art.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Changing SmartArt color type
                shape.color_style = art.SmartArtColorType.COLORFUL_ACCENT_COLORS

    # Saving Presentation
    presentation.save("ChangeSmartArtColorStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

