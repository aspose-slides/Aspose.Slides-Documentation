---
title: Manage SmartArt Shape Node
type: docs
weight: 30
url: /java/manage-smartart-shape-node/
---

## **Add SmartArt Shape Node**
Aspose.Slides for Java has provided an API to manage the SmartArt shapes. The following sample code will help to add node and child node inside SmartArt shape.

1. Create an instance of Presentation class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
1. Add a new **Node** in SmartArt shape **NodeCollection** and set the text in TextFrame.
1. Now, Add a **Child Node** in newly added SmartArt Node and set the text in TextFrame
1. Save the Presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-AddingSmartArtShapeNodes-AddingSmartArtShapeNodes.java" >}}

## **Add SmartArt Shape Node at Specific Position**
In the following sample code we have explained how to add the child nodes belonging to respective nodes of SmartArt shape at particular position.

1. Create an instance of Presentation class.
1. Obtain the reference of first slide by using its Index.
1. Add a **StackedList** type SmartArt shape in accessed slide.
1. Access the first node in added SmartArt shape
1. Now, add the **Child Node** for selected **Node** at position 2 and set its text.
1. Save the Presentation

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-AddingSmartArtShapeNodeAtSpecificPosition-AddingSmartArtShapeNodeAtSpecificPosition.java" >}}


## **Remove SmartArt Shape Node**
In this example, we will learn to remove the nodes inside SmartArt shape.

1. Create an instance of Presentation class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
1. Check if the SmartArt has more than 0 nodes.
1. Select the SmartArt node to be deleted.
1. Now, remove the selected node using **RemoveNode()** method.
1. Save the Presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-RemoveSmartArtShapeNode-RemoveSmartArtShapeNode.java" >}}


## **Remove SmartArt Shape Node at Specific Position**
In this example, we will learn to remove the nodes inside SmartArt shape at particular position.

1. Create an instance of Presentation class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
1. Select the SmartArt shape node at index 0.
1. Now, check if the selected SmartArt node has more than 2 child nodes.
1. Now, remove the node at **Position 1** using **RemoveNodeByPosition()** method.
1. Save the Presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-RemoveSmartArtShapeNodeAtSpecificPosition-RemoveSmartArtShapeNodeAtSpecificPosition.java" >}}


## **Access SmartArt Shape Node**
Aspose.Slides for Java has provided an API to manage the SmartArt shapes. The following sample code will help to access nodes inside SmartArt shape. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the SmartArt shape is added.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
1. Traverse through all **Nodes** inside SmartArt Shape.
1. Access and display information like SmartArt Node position, level and Text.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-AccessingSmartArtShapeNodes-AccessingSmartArtShapeNodes.java" >}}


## **Access SmartArt Shape Child Node**
Aspose.Slides for Java has provided an API to manage the SmartArt shapes in an easiest way. The following sample code will help to access the child nodes belonging to respective nodes of SmartArt shape.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
1. Traverse through all **Nodes** inside SmartArt Shape.
1. For every selected SmartArt shape **Node**, traverse through all **Child Nodes** inside particular node.
1. Access and display information like **Child Node** position, level and Text.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-AccessingSmartArtShapeChildNodes-AccessingSmartArtShapeChildNodes.java" >}}


## **Access SmartArt Shape Child Node at Specific Position**
In this example, we will learn to access the child nodes at some particular position belonging to respective nodes of SmartArt shape.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of first slide by using its Index.
1. Add a **StackedList** type SmartArt shape.
1. Access the added SmartArt shape.
1. Access the node at index 0 for accessed SmartArt shape.
1. Now, access the **Child Node** at position 1 for accessed SmartArt node using **GetNodeByPosition()** method.
1. Access and display information like **Child Node** position, level and Text.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-AccessingSmartArtShapeChildNodeAtSpecificPosition-AccessingSmartArtShapeChildNodeAtSpecificPosition.java" >}}


## **Check Assistant Node in SmartArt Shapes**
{{% alert color="primary" %}} 

In this article we will further investigate features of SmartArt shapes added in presentation slides programmatically using Aspose.Slides for Java.

{{% /alert %}} 

We will use the following source SmartArt shape for our investigation in different sections of this article.

|![todo:image_alt_text](http://i.imgur.com/FItwczY.png)|
| :- |
|**Figure: Source SmartArt shape in slide**|
In the following sample code we will investigate how to identify **Assistant Nodes** in the SmartArt nodes collection and changing them.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of second slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
1. Traverse through all nodes inside SmartArt shape and check if they are **Assistant Nodes**.
1. Change the status of Assistant Node to normal node.
1. Save the Presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-CheckingAssistantNodesInSmartArtShapes-CheckingAssistantNodesInSmartArtShapes.java" >}}

|![todo:image_alt_text](http://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure: Assistant Nodes Changed in SmartArt shape inside slide**|

## **Change Text on SmartArt Node**
In order to change text on SmartArt node. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Add SmartArt on slide.
- Obtain the reference of a node by using its Index.
- Set text on node.
- Write the presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-ChangingTextOnSmartArtNode-ChangingTextOnSmartArtNode.java" >}}


## **Set Fill Format for SmartArt Node**
{{% alert color="primary" %}} 

Aspose.Slides for Java makes it possible to add custom SmartArt shapes and set their fill format. This article explains how to create and access SmartArt shapes and set their fill format using Aspose.Slides for Java.

{{% /alert %}} 

Aspose.Slides for Java provides a simple API for creating SmartArt shapes and set their node fill format. Please follow the steps below:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide using its index.
1. Add a SmartArt shape by setting its **LayoutType**.
1. Set the **FillFormat** for the SmartArt shape nodes.
1. Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-SettingFillFormatForSmartArtNode-SettingFillFormatForSmartArtNode.java" >}}

## **Set Custom Position for Child SmartArt Node**
Now Aspose.Slides for Java support for setting SmartArtShape X and Y properties. The code snippet below shows how to set custom SmartArtShape position, size and rotation also please note that adding new nodes causes a recalculation of the positions and sizes of all nodes. Also with custom position settings, user may set the nodes as per requirements.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.java" >}}


## **Get or Set Organization Chart Type of SmartArt Node**
Methods [ISmartArtNode.getOrganizationChartLayout()](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ismartartnode/methods/getOrganizationChartLayout\(\)/), [setOrganizationChartLayout(int)](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ismartartnode/methods/setOrganizationChartLayout\(int\)/) allow get or sets organization chart type associated with current node. In order to get or set organization chart type. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Add SmartArt on slide.
- Get or Set the organization chart type.
- Write the presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-GetOrSetTheStateOfTheSmartArtRegardingLeftToRightOrRightToLeft-GetOrSetTheStateOfTheSmartArtRegardingLeftToRightOrRightToLeft.java" >}}


