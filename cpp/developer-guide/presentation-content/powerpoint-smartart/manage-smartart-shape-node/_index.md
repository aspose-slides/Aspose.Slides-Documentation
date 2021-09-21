---
title: Manage SmartArt Shape Node
type: docs
weight: 30
url: /cpp/manage-smartart-shape-node/
---



## **Add SmartArt Node**
Aspose.Slides for C++ has provided the simplest API to manage the SmartArt shapes in an easiest way. The following sample code will help to add node and child node inside SmartArt shape.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Add a new Node in SmartArt shape NodeCollection and set the text in TextFrame.
- Now, Add a Child Node in newly added SmartArt Node and set the text in TextFrame.
- Save the Presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **Add SmartArt Node at Specific Position**
In the following sample code we have explained how to add the child nodes belonging to respective nodes of SmartArt shape at particular position.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of first slide by using its Index.
- Add a StackedList type SmartArt shape in accessed slide.
- Access the first node in added SmartArt shape.
- Now, add the Child Node for selected Node at position 2 and set its text.
- Save the Presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}


## **Access SmartArt Node**
The following sample code will help to access nodes inside SmartArt shape. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the SmartArt shape is added.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Traverse through all Nodes inside SmartArt Shape.
- Access and display information like SmartArt Node position, level and Text.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **Access SmartArt Child Node**
The following sample code will help to access the child nodes belonging to respective nodes of SmartArt shape.

- Create an instance of PresentationEx class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArtEx if it is SmartArt.
- Traverse through all Nodes inside SmartArt Shape.
- For every selected SmartArt shape Node, traverse through all Child Nodes inside particular node.
- Access and display information like Child Node position, level and Text.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Access SmartArt Child Node at Specific Position**
In this example, we will learn to access the child nodes at some particular position belonging to respective nodes of SmartArt shape.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of first slide by using its Index.
- Add a StackedList type SmartArt shape.
- Access the added SmartArt shape.
- Access the node at index 0 for accessed SmartArt shape.
- Now, access the Child Node at position 1 for accessed SmartArt node using GetNodeByPosition() method.
- Access and display information like Child Node position, level and Text.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **Remove SmartArt Node**
In this example, we will learn to remove the nodes inside SmartArt shape.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Check if the SmartArt has more than 0 nodes.
- Select the SmartArt node to be deleted.
- Now, remove the selected node using RemoveNode() method* Save the Presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Remove SmartArt Node at Specific Position**
In this example, we will learn to remove the nodes inside SmartArt shape at particular position.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Select the SmartArt shape node at index 0.
- Now, check if the selected SmartArt node has more than 2 child nodes.
- Now, remove the node at Position 1 using RemoveNodeByPosition() method.
- Save the Presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}


## **Set Custom Position for SmartArt Child Node**
Now Aspose.Slides for .NET support for setting SmartArtShape X and Y properties. The code snippet below shows how to set custom SmartArtShape position, size and rotation also please note that adding new nodes causes a recalculation of the positions and sizes of all nodes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}


## **Check Assistant Node**
In the following sample code we will investigate how to identify Assistant Nodes in the SmartArt nodes collection and changing them.

- Create an instance of PresentationEx class and load the presentation with SmartArt Shape.
- Obtain the reference of second slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArtEx if it is SmartArt.
- Traverse through all nodes inside SmartArt shape and check if they are Assistant Nodes.
- Change the status of Assistant Node to normal node.
- Save the Presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Set Node's Fill Format**
Aspose.Slides for C++ makes it possible to add custom SmartArt shapes and set their fill formats. This article explains how to create and access SmartArt shapes and set their fill format using Aspose.Slides for C++.

Please follow the steps below:

- Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide using its index.
- Add a SmartArt shape by setting its LayoutType.
- Set the FillFormat for the SmartArt shape nodes.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}


## **Generate Thumbnail of SmartArt Child Node**
Developers can generate a thumbnail of Child node of a SmartArt by following the steps below:

1. Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class that represents the PPTX file.
1. Add SmartArt.
1. Obtain the reference of a node by using its Index
1. Get the thumbnail image.
1. Save the thumbnail image in any desired image format.

The example below generating a thumbnail of SmartArt child node

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtChildNoteThumbnail-CreateSmartArtChildNoteThumbnail.cpp" >}}
