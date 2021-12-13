---
title: Manage SmartArt
type: docs
weight: 10
url: /python-net/manage-smartart/
keywords: "SmartArt, text from SmartArt, Organization type chart, Picture organization chart, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "SmartArt and organization type chart in PowerPoint presentations in Python"
---

## **Get Text from SmartArt**
Now TextFrame property has been added to ISmartArtShape interface and SmartArtShape class respectively. This property allows you to get all text from SmartArt if it has not only nodes text. The following sample code will help you to get text from SmartArt node.

```py
import aspose.slides as slides

with slides.Presentation(path + "SmartArt.pptx") as pres:
    slide = pres.slides[0]
    smartArt = slide.shapes[0]

    for smartArtNode in smartArt.all_nodes:
        for nodeShape in smartArtNode.shapes:
            if nodeShape.text_frame != None:
                print(nodeShape.text_frame.text)
```



## **Change Layout Type of SmartArt**
In order to change the layout type of SmartArt. Please follow the steps below:

- Create an instance of `Presentation` class.
- Obtain the reference of a slide by using its Index.
- Add SmartArt BasicBlockList.
- Change LayoutType to BasicProcess.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Add SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Change LayoutType to BasicProcess
    smart.layout = art.SmartArtLayoutType.BASIC_PROCESS
    # Saving Presentation
    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Check Hidden Property of SmartArt**
Please note Method com.aspose.slides.ISmartArtNode.isHidden() returns true if this node is a hidden node in the data model. In order to check the hidden property of any node of SmartArt. Please follow the steps below:

- Create an instance of `Presentation` class.
- Add SmartArt RadialCycle.
- Add node on SmartArt.
- Check isHidden property.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Add SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.RADIAL_CYCLE)
    # Add node on SmartArt 
    node = smart.all_nodes.add_node()
    # Check isHidden property
    if node.is_hidden:
        print("hidden")
        # Do some actions or notifications
    # Saving Presentation
    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Get or Set Organization Chart Type**
Methods com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) allow get or sets organization chart type associated with current node. In order to get or set organization chart type. Please follow the steps below:

- Create an instance of `Presentation` class.
- Add SmartArt on slide.
- Get or Set the organization chart type.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Add SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.ORGANIZATION_CHART)
    # Get or Set the organization chart type 
    smart.nodes[0].organization_chart_layout = art.OrganizationChartLayoutType.LEFT_HANGING
    # Saving Presentation
    presentation.save("OrganizeChartLayoutType_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Create Picture Organization Chart**
Aspose.Slides for Python via .NET provides a simple API for creating and PictureOrganization charts in an easy way. To create a chart on a slide:

1. Create an instance of the `Presentation` class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.PictureOrganizationChart).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as pres:
    smartArt = pres.slides[0].shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    pres.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```



