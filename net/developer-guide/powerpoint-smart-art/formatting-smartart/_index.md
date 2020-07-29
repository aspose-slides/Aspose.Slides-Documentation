---
title: Formatting SmartArt
type: docs
weight: 20
url: /net/formatting-smartart/
---

## **Formatting SmartArt**
### **Accessing SmartArt Shape with particular Layout type**
The following sample code will help to access the SmartArt shape with particular LayoutType. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the SmartArt shape is added.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Check the SmartArt shape with particular LayoutType and perform what is required to be done afterwards.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SmartArts-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cs" >}}
### **Changing SmartArt Shape Style**
The following sample code will help to access the SmartArt shape with particular LayoutType.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Find the SmartArt shape with particular Style.
- Set the new Style for the SmartArt shape.
- Save the Presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SmartArts-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cs" >}}
### **Changing SmartArt Shape Color Style**
In this example, we will learn to change the color style for any SmartArt shape. In the following sample code will access the SmartArt shape with particular color style and will change its style.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Find the SmartArt shape with particular Color Style.
- Set the new Color Style for the SmartArt shape.
- Save the Presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SmartArts-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cs" >}}
### **Accessing SmartArt Nodes and Child Nodes**
In this article we will further look in to managing SmartArt shapes added in presentation slides programmatically using Aspose.Slides for .NET.
#### **Accessing Nodes**
The following sample code will help to access nodes inside SmartArt shape. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the SmartArt shape is added.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Traverse through all Nodes inside SmartArt Shape.
- Access and display information like SmartArt Node position, level and Text.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SmartArts-AccessSmartArt-AccessSmartArt.cs" >}}


#### **Accessing Child Nodes**
The following sample code will help to access the child nodes belonging to respective nodes of SmartArt shape.

- Create an instance of PresentationEx class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArtEx if it is SmartArt.
- Traverse through all Nodes inside SmartArt Shape.
- For every selected SmartArt shape Node, traverse through all Child Nodes inside particular node.
- Access and display information like Child Node position, level and Text.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SmartArts-AccessChildNodes-AccessChildNodes.cs" >}}
#### **Accessing Child Node at Specific Position**
In this example, we will learn to access the child nodes at some particular position belonging to respective nodes of SmartArt shape.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of first slide by using its Index.
- Add a StackedList type SmartArt shape.
- Access the added SmartArt shape.
- Access the node at index 0 for accessed SmartArt shape.
- Now, access the Child Node at position 1 for accessed SmartArt node using GetNodeByPosition() method.
- Access and display information like Child Node position, level and Text.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SmartArts-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cs" >}}
### **Add and Remove SmartArt Nodes and Child Nodes**
In this article we will further look in to managing SmartArt shapes added in presentation slides programmatically using Aspose.Slides for .NET. Aspose.Slides for .NET has provided the simplest API not only to add or Remove SmartArt Shape Node but also features like add or Remove SmartArt Shape Node at Specific position.
#### **Adding Node at Specific Position**
In the following sample code we have explained how to add the child nodes belonging to respective nodes of SmartArt shape at particular position.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of first slide by using its Index.
- Add a StackedList type SmartArt shape in accessed slide.
- Access the first node in added SmartArt shape.
- Now, add the Child Node for selected Node at position 2 and set its text.
- Save the Presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SmartArts-AddNodesSpecificPosition-AddNodesSpecificPosition.cs" >}}
#### **Removing Node**
In this example, we will learn to remove the nodes inside SmartArt shape.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Check if the SmartArt has more than 0 nodes.
- Select the SmartArt node to be deleted.
- Now, remove the selected node using RemoveNode() method.
- Save the Presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SmartArts-RemoveNode-RemoveNode.cs" >}}
#### **Removing Node at Specific Position**
In this example, we will learn to remove the nodes inside SmartArt shape at particular position.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Select the SmartArt shape node at index 0.
- Now, check if the selected SmartArt node has more than 2 child nodes.
- Now, remove the node at Position 1 using RemoveNodeByPosition() method.
- Save the Presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SmartArts-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cs" >}}
#### **Checking Assistant Node**
In the following sample code we will investigate how to identify Assistant Nodes in the SmartArt nodes collection and changing them.

- Create an instance of PresentationEx class and load the presentation with SmartArt Shape.
- Obtain the reference of second slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArtEx if it is SmartArt.
- Traverse through all nodes inside SmartArt shape and check if they are Assistant Nodes.
- Change the status of Assistant Node to normal node.
- Save the Presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SmartArts-AssistantNode-AssistantNode.cs" >}}
#### **Setting a Node's Fill Format**
Aspose.Slides for .NET makes it possible to add custom SmartArt shapes and set their fill formats. This article explains how to create and access SmartArt shapes and set their fill format using Aspose.Slides for .NET.

Please follow the steps below:

- Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide using its index.
- Add a SmartArt shape by setting its LayoutType.
- Set the FillFormat for the SmartArt shape nodes.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-SmartArts-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cs" >}}



