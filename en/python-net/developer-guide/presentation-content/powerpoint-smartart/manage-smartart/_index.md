---
title: Manage SmartArt in PowerPoint Presentations Using Python
linktitle: Manage SmartArt
type: docs
weight: 10
url: /python-net/manage-smartart/
keywords:
- SmartArt
- text from SmartArt
- layout type
- hidden property
- organization chart
- picture organization chart
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Learn to build and edit PowerPoint SmartArt with Aspose.Slides for Python via .NET using clear code samples that speed up slide design and automation."
---

## **Overview**

This guide shows how to create and manipulate SmartArt in Aspose.Slides for Python. You’ll learn how to extract text from SmartArt (including [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) content inside node shapes), add SmartArt to slides and switch its layout, detect and handle hidden nodes, configure organization-chart layouts, and build picture organization charts—all with concise, copy-pasteable Python examples that open a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), work with slides and SmartArt nodes, and save results to PPTX. 

## **Get Text from SmartArt**

The `text_frame` property of the [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) allows you to retrieve all text from a SmartArt shape—not just the text contained in its nodes. The following sample code shows how to get text from a SmartArt node.

```py
import aspose.slides as slides

with slides.Presentation("SmartArt.pptx") as presentation:
    slide = presentation.slides[0]
    smart_art = slide.shapes[0]

    for smart_art_node in smart_art.all_nodes:
        for node_shape in smart_art_node.shapes:
            if node_shape.text_frame is not None:
                print(node_shape.text_frame.text)
```

## **Change the SmartArt Layout Type**

To change the SmartArt layout type, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add a SmartArt shape with the `BASIC_BLOCK_LIST` layout.
1. Change its layout to `BASIC_PROCESS`.
1. Save the presentation as a PPTX file.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the BASIC_BLOCK_LIST layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Change the layout type to BASIC_PROCESS.
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # Save the presentation.
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Check the Hidden Property of SmartArt**

The `SmartArtNode.is_hidden` property returns `True` if the node is hidden in the data model. To check whether a SmartArt node is hidden, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Add a SmartArt shape with the `RADIAL_CYCLE` layout.
1. Add a node to the SmartArt.
1. Check the `is_hidden` property.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the RADIAL_CYCLE layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # Add a node to the SmartArt.
    node = smart.all_nodes.add_node()

    # Check the is_hidden property.
    if node.is_hidden:
        print("The node is hidden.")
```

## **Get or Set the Organization Chart Type**

The `SmartArtNode.organization_chart_layout` property gets or sets the organization chart type associated with the current node. To get or set the organization chart type, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Add a SmartArt shape to the slide.
1. Get or set the organization chart type.
1. Save the presentation as a PPTX file.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the ORGANIZATION_CHART layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # Set the organization chart type.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # Save the presentation.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Create a Picture Organization Chart**

Aspose.Slides for Python provides a simple API for creating picture organization charts easily. To create a chart on a slide:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to the slide by its index.
1. Add a chart with default data of the desired type.
1. Save the modified presentation as a PPTX file.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```
