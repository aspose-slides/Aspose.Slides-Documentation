---
title: Manage SmartArt in PowerPoint Presentations Using Python
linktitle: Manage SmartArt
type: docs
weight: 10
url: /python-net/manage-smartart/
keywords:
- SmartArt
- SmartArt text
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

SmartArt is a PowerPoint diagram made from nodes, node shapes, and a layout. With Aspose.Slides for Python via .NET, you can create SmartArt, read text from its nodes, change its layout, inspect hidden nodes, configure organization chart layouts, and create picture organization charts.

## **Get Text from a SmartArt Object**

A SmartArt node can contain one or more shapes. To read text from the node shapes, iterate through [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/), then read the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) returned by [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/).

The example requires a presentation with at least one slide and a SmartArt object as the first shape on that slide. It prints each available text frame to the console.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **Change the Layout Type of a SmartArt Object**

The SmartArt layout controls how nodes are arranged and connected. The following example creates a SmartArt object with the [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` value, changes it to the `BASIC_PROCESS` value, and saves the presentation. The position and size passed to [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) are measured in points. Set [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) to change the layout.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Check Whether a SmartArt Node Is Hidden**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) indicates whether the node is hidden in the SmartArt data model. Hidden nodes can exist in the structure even when the selected layout does not display them as visible diagram elements.

The following example adds a node to a SmartArt object that uses the [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` value and checks the added node's hidden state. It prints a message if the node is hidden and saves the diagram.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **Get or Set the Organization Chart Layout**

For SmartArt diagrams that use an organization chart layout, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) defines how child nodes are arranged under a parent node. For example, you can set child nodes to hang from the left, right, or both sides, depending on the selected [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/).

The following example creates an organization chart and sets the layout for the first node to the [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` value. The zero-based index `0` selects the first top-level node; its child nodes use the selected arrangement. The modified presentation is then saved.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Create a Picture Organization Chart**

A picture organization chart is a SmartArt layout designed for hierarchy diagrams that include image placeholders. Use the [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` value when adding the SmartArt object to a slide. This example saves a diagram with image placeholders; it does not populate the placeholders with images.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Convert Legacy Diagrams to Groups of Shapes**

When modernizing an existing presentation, you may need to update an organization chart originally created in PowerPoint 97–2003. Aspose.Slides represents these legacy diagrams as [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) objects. Use [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) to convert a diagram into a group of shapes so that you can edit individual visual elements. See the [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) for details.

Conversion adds a new group to the shape collection without removing the original diagram. After successful conversion, remove the original with [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) to avoid duplicate content. Collect the legacy diagrams into a list before converting them so that adding and removing shapes does not disrupt iteration.

The following example opens a presentation, searches every slide, converts the diagrams to groups of shapes, and saves the updated presentation as PPTX.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

The saved presentation contains editable groups of shapes in place of the converted legacy diagrams, with no original diagrams left alongside them. Open the PPTX in PowerPoint to edit individual elements within each group, such as their text, fill, or position.

## **FAQ**

**Does SmartArt support mirroring or reversing for RTL languages?**

Yes. The [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) property switches the diagram direction from left-to-right to right-to-left, or back, when the selected SmartArt layout supports reversal.

**How can I copy SmartArt to the same slide or to another presentation while preserving formatting?**

You can [clone the SmartArt shape](/slides/python-net/shape-manipulations/) with [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) or [clone the whole slide](/slides/python-net/clone-slides/) that contains the SmartArt. Both approaches preserve size, position, and formatting.

**How do I render SmartArt to a raster image for preview or web export?**

[Render the slide](/slides/python-net/convert-powerpoint-to-png/) or the whole presentation to PNG or JPEG. SmartArt is rendered as part of the slide.

**How can I find a specific SmartArt object on a slide if there are several?**

Set a distinctive [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) or [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) value on the SmartArt shape, search for that value in [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), and then check that the matching shape is a [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).
