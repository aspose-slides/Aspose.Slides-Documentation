---
title: Manage SmartArt Shape Nodes in Presentations Using Python
linktitle: SmartArt Shape Node
type: docs
weight: 30
url: /python-net/manage-smartart-shape-node/
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
description: "Manage SmartArt shape nodes in PPT, PPTX and ODP with Aspose.Slides for Python via .NET. Get clear code samples and tips to streamline your presentations."
---

## **Add SmartArt Node**
Aspose.Slides for Python via .NET has provided the simplest API to manage the SmartArt shapes in an easiest way. The following sample code will help to add node and child node inside SmartArt shape.

- Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Add a new Node in SmartArt shape NodeCollection and set the text in TextFrame.
- Now, Add a Child Node in newly added SmartArt Node and set the text in TextFrame.
- Save the Presentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:

        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Adding a new SmartArt Node
            node1 = shape.all_nodes.add_node()
            # Adding text
            node1.text_frame.text = "Test"

            # Adding new child node in parent node. It  will be added in the end of collection
            new_node = node1.child_nodes.add_node()

            # Adding text
            new_node.text_frame.text = "New Node Added"

    # Saving Presentation
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Add SmartArt Node at Specific Position**
In the following sample code we have explained how to add the child nodes belonging to respective nodes of SmartArt shape at particular position.

- Create an instance of `Presentation` class.
- Obtain the reference of first slide by using its Index.
- Add a StackedList type SmartArt shape in accessed slide.
- Access the first node in added SmartArt shape.
- Now, add the Child Node for selected Node at position 2 and set its text.
- Save the Presentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Creating a presentation instance
with slides.Presentation() as pres:
    # Access the presentation slide
    slide = pres.slides[0]

    # Add Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Accessing the SmartArt node at index 0
    node = smart.all_nodes[0]

    # Adding new child node at position 2 in parent node
    chNode = node.child_nodes.add_node_by_position(2)

    # Add text
    chNode.text_frame.text = "Sample text Added"

    # save Presentation
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Access SmartArt Node**
The following sample code will help to access nodes inside SmartArt shape. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the SmartArt shape is added.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.

- Obtain the reference of first slide by using its Index.

- Traverse through every shape inside first slide.

- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.

- Traverse through all Nodes inside SmartArt Shape.

- Access and display information like SmartArt Node position, level and Text.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Traverse through all nodes inside SmartArt
            for i in range(len(shape.all_nodes)):
                # Accessing SmartArt node at index i
                node = shape.all_nodes[i]

                # Printing the SmartArt node parameters
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
  ```

  


## **Access SmartArt Child Node**
The following sample code will help to access the child nodes belonging to respective nodes of SmartArt shape.

- Create an instance of PresentationEx class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArtEx if it is SmartArt.
- Traverse through all Nodes inside SmartArt Shape.
- For every selected SmartArt shape Node, traverse through all Child Nodes inside particular node.
- Access and display information like Child Node position, level and Text.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Traverse through all nodes inside SmartArt
            for node0 in shape.all_nodes:
                # Traversing through the child nodes
                for j in range(len(node0.child_nodes)):
                    # Accessing the child node in SmartArt node
                    node = node0.child_nodes[j]

                    # Printing the SmartArt child node parameters
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```



## **Access SmartArt Child Node at Specific Position**
In this example, we will learn to access the child nodes at some particular position belonging to respective nodes of SmartArt shape.

- Create an instance of `Presentation` class.
- Obtain the reference of first slide by using its Index.
- Add a StackedList type SmartArt shape.
- Access the added SmartArt shape.
- Access the node at index 0 for accessed SmartArt shape.
- Now, access the Child Node at position 1 for accessed SmartArt node using GetNodeByPosition() method.
- Access and display information like Child Node position, level and Text.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Instantiate the presentation
with slides.Presentation() as pres:
    # Accessing the first slide
    slide = pres.slides[0]
    # Adding the SmartArt shape in first slide
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Accessing the SmartArt  node at index 0
    node = smart.all_nodes[0]
    # Accessing the child node at position 1 in parent node
    position = 1
    chNode = node.child_nodes[position] 
    # Printing the SmartArt child node parameters
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```



## **Remove SmartArt Node**
In this example, we will learn to remove the nodes inside SmartArt shape.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Check if the SmartArt has more than 0 nodes.
- Select the SmartArt node to be deleted.
- Now, remove the selected node using RemoveNode() method* Save the Presentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Typecast shape to SmartArtEx
            if len(shape.all_nodes) > 0:
                # Accessing SmartArt node at index 0
                node = shape.all_nodes[0]

                # Removing the selected node
                shape.all_nodes.remove_node(node)

    # save Presentation
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Remove SmartArt Node at Specific Position**
In this example, we will learn to remove the nodes inside SmartArt shape at particular position.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Select the SmartArt shape node at index 0.
- Now, check if the selected SmartArt node has more than 2 child nodes.
- Now, remove the node at Position 1 using RemoveNodeByPosition() method.
- Save the Presentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Typecast shape to SmartArt
            if len(shape.all_nodes) > 0:
                # Accessing SmartArt node at index 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Removing the child node at position 1
                    node.child_nodes.remove_node(1)

    # save Presentation
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Set Custom Position for Child Node in SmartArt**
Now Aspose.Slides for Python via .NET support for setting SmartArtShape X and Y properties. The code snippet below shows how to set custom SmartArtShape position, size and rotation also please note that adding new nodes causes a recalculation of the positions and sizes of all nodes.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# Move SmartArt shape to new position
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# Change SmartArt shape's widths
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# Change SmartArt shape's height
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# Change SmartArt shape's rotation
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```



## **Check Assistant Node**
In the following sample code we will investigate how to identify Assistant Nodes in the SmartArt nodes collection and changing them.

- Create an instance of PresentationEx class and load the presentation with SmartArt Shape.
- Obtain the reference of second slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArtEx if it is SmartArt.
- Traverse through all nodes inside SmartArt shape and check if they are Assistant Nodes.
- Change the status of Assistant Node to normal node.
- Save the Presentation.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Creating a presentation instance
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Traversing through all nodes of SmartArt shape
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Check if node is Assitant node
                if node.is_assistant:
                    # Setting Assitant node to false and making it normal node
                    node.is_assistant = False
    # save Presentation
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Set Node's Fill Format**
Aspose.Slides for Python via .NET makes it possible to add custom SmartArt shapes and set their fill formats. This article explains how to create and access SmartArt shapes and set their fill format using Aspose.Slides for Python via .NET.

Please follow the steps below:

- Create an instance of the `Presentation` class.
- Obtain the reference of a slide using its index.
- Add a SmartArt shape by setting its LayoutType.
- Set the FillFormat for the SmartArt shape nodes.
- Write the modified presentation as a PPTX file.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Accessing the slide
    slide = presentation.slides[0]

    # Adding SmartArt shape and nodes
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Setting node fill color
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Saving Presentation
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Generate Thumbnail of SmartArt Child Node**
Developers can generate a thumbnail of Child node of a SmartArt by following the steps below:

1. Instantiate `Presentation` class that represents the PPTX file.
1. Add SmartArt.
1. Obtain the reference of a node by using its Index
1. Get the thumbnail image.
1. Save the thumbnail image in any desired image format.

The example below generating a thumbnail of SmartArt child node

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Instantiate Presentation class that represents the PPTX file 
with slides.Presentation() as presentation: 
    # Add SmartArt 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Obtain the reference of a node by using its Index  
    node = smart.nodes[1]

    # Get thumbnail
    with node.shapes[0].get_image() as bmp:
        # save thumbnail
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **FAQ**

**Is SmartArt animation supported?**

Yes. SmartArt is treated as a regular shape, so you can [apply standard animations](/slides/python-net/shape-animation/) (entrance, exit, emphasis, motion paths) and adjust timing. You can also animate shapes inside SmartArt nodes when needed.

**How can I reliably locate a specific SmartArt on a slide if its internal ID is unknown?**

Assign and search by [alternative text](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/). Setting a distinctive AltText on the SmartArt lets you find it programmatically without relying on internal identifiers.

**Will the SmartArt appearance be preserved when converting the presentation to PDF?**

Yes. Aspose.Slides renders SmartArt with high visual fidelity during [PDF export](/slides/python-net/convert-powerpoint-to-pdf/), preserving layout, colors, and effects.

**Can I extract an image of the entire SmartArt (for previews or reports)?**

Yes. You can render a SmartArt shape to [raster formats](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/get_image/) or to [SVG](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/write_as_svg/) for scalable vector output, making it suitable for thumbnails, reports, or web use.
