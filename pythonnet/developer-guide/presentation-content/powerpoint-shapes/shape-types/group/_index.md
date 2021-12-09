---
title: Group
type: docs
weight: 40
url: /pythonnet/group/
keywords: "Group shape, PowerPoint shape, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add group shape to PowerPoint presentation in Python"
---

## **Add Group Shape**
Aspose.Slides support working with group shapes on slides. This feature helps developers support richer presentations. Aspose.Slides for Python via .NET supports adding or accessing group shapes. It is possible to add shapes to an added group shape to populate it or access any property of group shape. To add a group shape to a slide using Aspose.Slides for Python via .NET:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Index
1. Add a group shape to the slide.
1. Add the shapes to the added group shape.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.

```py
import aspose.slides as slides

# Instantiate Prseetation class 
with slides.Presentation() as pres:
    # Get the first slide 
    sld = pres.slides[0]

    # Accessing the shape collection of slides 
    slideShapes = sld.shapes

    # Adding a group shape to the slide 
    groupShape = slideShapes.add_group_shape()

    # Adding shapes inside added group shape 
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Adding group shape frame 
    groupShape.frame = slides.ShapeFrame(100, 300, 500, 40, -1, -1, 0)

    # Write the PPTX file to disk 
    pres.save("GroupShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Access AltText Property**
This topic shows simple steps, complete with code examples, for adding a group shape and accessing AltText property of group shapes on slides. To access AltText of a group shape in a slide using Aspose.Slides for Python via .NET:

1. Instantiate `Presentation` class that represents PPTX file.
1. Obtain the reference of a slide by using its Index.
1. Accessing the shape collection of slides.
1. Accessing the group shape.
1. Accessing the AltText property.

The example below accesses alternative text of group shape.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents PPTX file
with slides.Presentation(path + "AltText.pptx") as pres:

    # Get the first slide
    sld = pres.slides[0]

    for i in range(len(sld.shapes)):
        # Accessing the shape collection of slides
        shape = sld.shapes[i]

        if type(shape) is slides.GroupShape:
            # Accessing the group shape.
            for j in range(len(shape.shapes)):
                # Accessing the AltText property
                print(shape.shapes[j].alternative_text)
```

