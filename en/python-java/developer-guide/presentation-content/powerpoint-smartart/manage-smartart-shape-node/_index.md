---
title: Manage SmartArt Shape Nodes in Presentations Using Python
linktitle: SmartArt Shape Node
type: docs
weight: 30
url: /python-java/manage-smartart-shape-node/
keywords:
- SmartArt node
- child node
- add node
- node position
- access node
- remove node
- custom position
- assistant node
- fill format
- render node
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Manage SmartArt shape nodes in PPT and PPTX with Aspose.Slides for Python via Java. Get clear code samples and tips to streamline your presentations."
---

## **Overview**

SmartArt graphics in PowerPoint presentations are organized through nodes that contain text and define the structure of the diagram. Aspose.Slides allows you to work with these SmartArt nodes programmatically: add new nodes and child nodes, insert child nodes at a specific position, access existing nodes, and read their text, level, and position.

This article explains how to manage SmartArt shape nodes. It shows how to remove nodes, work with child nodes by index or position, change an assistant node to a normal node, adjust the position, size, and rotation of SmartArt node shapes, set node fill formats, and generate a thumbnail image for a SmartArt child node.

## **Add a SmartArt Node**
Aspose.Slides for Python via Java provides an API to manage SmartArt shapes. The following example adds a node and a child node to a SmartArt shape.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) instance.
1. [Add a new node](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnodecollection/#addNode) to the SmartArt shape’s [node collection](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes) and set its text through [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).
1. [Add](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnodecollection/#addNode) a [child node](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getChildNodes) to the new node and set its text through [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).
1. Save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Add a SmartArt Node at a Specific Position**
The following example adds a child node at a specific position in a SmartArt node.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get the first slide by its index.
1. Add a [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) shape with the [StackedList](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/#StackedList) layout to the slide.
1. Access the first node in the added SmartArt shape.
1. Add a child node to the selected node at position 2 using [addNodeByPosition](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) and set its text.
1. Save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Access a SmartArt Node**
The following example accesses nodes in a SmartArt shape. The layout returned by [getLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getLayout) is read-only and is set when the SmartArt shape is added.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) instance.
1. Iterate through all [nodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes) in the SmartArt shape.
1. Read and display each SmartArt node’s position, level, and text.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```


## **Access a SmartArt Child Node**
The following example accesses the child nodes of each node in a SmartArt shape.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) instance.
1. Iterate through all [nodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes) in the SmartArt shape.
1. For each node, iterate through its [child nodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getChildNodes).
1. Read and display the [child node](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getChildNodes) position, level, and text.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **Access a SmartArt Child Node at a Specific Position**
The following example accesses a child node at a specific index in its parent node’s collection.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get the first slide by its index.
1. Add a SmartArt shape with the [StackedList](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/#StackedList) layout.
1. Access the added SmartArt shape.
1. Access the node at index 0 in the SmartArt shape.
1. Access the child node at index 1 using [get_Item](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnodecollection/#get_Item).
1. Read and display the [child node](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getChildNodes) position, level, and text.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **Remove a SmartArt Node**
The following example removes a node from a SmartArt shape.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) instance.
1. Check that the [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) shape contains at least one node.
1. Select the SmartArt node to be deleted.
1. Remove the selected node using [removeNode](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnodecollection/#removeNode).
1. Save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Remove a SmartArt Node from a Specific Position**
The following example removes a child node at a specific index in a SmartArt node’s collection.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) instance.
1. Access the SmartArt node at index 0 if it exists.
1. Check that the selected SmartArt node has at least two child nodes.
1. Remove the child node at index 1 using [removeNode](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnodecollection/#removeNode).
1. Save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set a Custom Position for a Child Node in a SmartArt Object**
Aspose.Slides for Python via Java supports setting the position of a [SmartArtShape](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/) using [setX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setX) and [setY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setY). The following example sets a custom position, size, and rotation for SmartArt node shapes. Adding new nodes recalculates the positions and sizes of all nodes. Custom positioning lets you arrange nodes as required.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Check an Assistant Node**
{{% alert color="info" title="Note" %}} 

This section explores SmartArt shapes added to presentation slides programmatically using Aspose.Slides for Python via Java.

{{% /alert %}} 

The following source SmartArt shape is used in this example.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure: Source SmartArt shape on a slide**|

The following example identifies assistant nodes in a SmartArt node collection and changes them to normal nodes.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) instance.
1. Iterate through all nodes in the SmartArt shape and check whether they are [Assistant Nodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isAssistant).
1. Change each assistant node to a normal node.
1. Save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure: Assistant nodes changed in a SmartArt shape on a slide**|

## **Set a Node's Fill Format**
Aspose.Slides for Python via Java makes it possible to add custom SmartArt shapes and set their fill format. This article explains how to create and access SmartArt shapes and set their fill format using Aspose.Slides for Python via Java.

Please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get a slide by its index.
1. Add a [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) shape with the [ClosedChevronProcess](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess) layout.
1. Set the [FillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getFillFormat) for the SmartArt shape nodes.
1. Write the modified presentation as a PPTX file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Generate a Thumbnail of a SmartArt Child Node**
To generate a thumbnail of a SmartArt child node, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. [Add a SmartArt shape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt).
1. Get a node by its index.
1. Get the thumbnail image.
1. Save the thumbnail image in any desired image format.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Is SmartArt animation supported?**

Yes. SmartArt is treated as a regular shape, so you can [apply standard animations](/slides/python-java/shape-animation/) (entrance, exit, emphasis, motion paths) and adjust timing. You can also animate shapes inside SmartArt nodes when needed.

**How can I reliably locate a specific SmartArt on a slide if its internal ID is unknown?**

Assign and search by [alternative text](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText). Setting distinctive alternative text on the SmartArt lets you find it programmatically without relying on internal identifiers.

**Will the SmartArt appearance be preserved when converting the presentation to PDF?**

Yes. Aspose.Slides renders SmartArt with high visual fidelity during [PDF export](/slides/python-java/convert-powerpoint-to-pdf/), preserving layout, colors, and effects.

**Can I extract an image of the entire SmartArt (for previews or reports)?**

Yes. You can render a SmartArt shape to [raster formats](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) or to [SVG](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#writeAsSvgToBytes) for scalable vector output, making it suitable for thumbnails, reports, or web use.
