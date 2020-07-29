---
title: Add, Access and Manage SmartArt Shape
type: docs
weight: 10
url: /java/add-access-and-manage-smartart-shape/
---

## **Add and Access the SmartArt shape**
{{% alert color="primary" %}} 

Aspose.Slides for Java facilitates to add custom SmartArt shapes in their slides from scratch. In this topic, we will explain how developers can create and access SmartArt shapes using Aspose.Slides for Java.

{{% /alert %}} 
### **Creating a SmartArt Shape**
Aspose.Slides for Java has provided an API to create SmartArt shapes. To create a SmartArt shape in a slide, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add a SmartArt shape by setting it LayoutType.
1. Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-CreatingASmartArtShape-CreatingASmartArtShape.java" >}}

|![todo:image_alt_text](http://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape added to the slide**|
### **Accessing the SmartArt shape in the Slide**
The following code will be used to access the SmartArt shapes added in presentation slide. In sample code we will traverse through every shape inside the slide and check if it is a SmartArt shape. If shape is of SmartArt type then we will typecast that to **SmartArt** instance.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-CreatingASmartArtShape-CreatingASmartArtShape.java" >}}
### **Creating Picture Organization Chart**
Aspose.Slides for Java provides a simple API for creating and PictureOrganization charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.PictureOrganizationChart).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-OrganizationChart-OrganizationChart.java" >}}
## **Managing SmartArt Style and Color Layouts**
{{% alert color="primary" %}} 

In this article we will further look in to managing SmartArt shapes added in presentation slides programmatically using Aspose.Slides for Java.

{{% /alert %}} 
### **Accessing SmartArt Shape with particular Layout type**
Aspose.Slides for Java has provided the simplest API to manage the SmartArt shapes in an easiest way. The following sample code will help to access the SmartArt shape with particular **LayoutType**. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the SmartArt shape is added.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
1. Check the SmartArt shape with particular LayoutType and perform what is required to be done afterwards

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-AccessingSmartArtShapeWithParticularLayoutType-AccessingSmartArtShapeWithParticularLayoutType.java" >}}

|![todo:image_alt_text](http://i.imgur.com/qL8tyM8.png)|
| :- |
|**Figure: Source SmartArt shape**|
### **Changing SmartArt Shape Style**
Aspose.Slides for Java has provided an API to manage the SmartArt shapes. The following sample code will help to access the SmartArt shape with particular **LayoutType**.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
1. Find the SmartArt shape with particular Style.
1. Set the new Style for the SmartArt shape.
1. Save the Presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-ChangingSmartArtShapeStyle-ChangingSmartArtShapeStyle.java" >}}

|![todo:image_alt_text](http://i.imgur.com/63ZwK41.png)|
| :- |
|**Figure: SmartArt shape with changed Style**|
### **Changing SmartArt Shape Color Style**
In this example, we will learn to change the color style for any SmartArt shape. In the following sample code will access the SmartArt shape with particular color style and will change its style.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
1. Find the SmartArt shape with particular Color Style.
1. Set the new Color Style for the SmartArt shape.
1. Save the Presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-ChangingSmartArtShapeColorStyle-ChangingSmartArtShapeColorStyle.java" >}}

|![todo:image_alt_text](http://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure: SmartArt shape with changed Color Style**|
## **Exploring SmartArt Properties**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports managing the SmartArt. In this topic, we will see with example for how to work with SmartArt in Aspose.Slides.

{{% /alert %}} 
### **Changing Text On SmartArt Node**
In order to change text on SmartArt node. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Add SmartArt on slide.
- Obtain the reference of a node by using its Index.
- Set text on node.
- Write the presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-ChangingTextOnSmartArtNode-ChangingTextOnSmartArtNode.java" >}}
### **Changing Layout type of any SmartArt**
In order to change the layout type of SmartArt. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add SmartArt BasicBlockList.
1. Change LayoutType to BasicProcess.
1. Write the presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-ChangingTextOnSmartArtNode-ChangingTextOnSmartArtNode.java" >}}
### **Checking Hidden Property Of SmartArt**
In order to check the hidden property of any node of SmartArt. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Add SmartArt RadialCycle.
1. Add node on SmartArt.
1. Check isHidden property.
1. Write the presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-CheckingHiddenPropertyOfSmartArt-CheckingHiddenPropertyOfSmartArt.java" >}}

{{% alert color="primary" %}} 

Method [ISmartArtNode.isHidden()](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ismartartnode/methods/isHidden\(\)/) returns true if this node is a hidden node in the data model.

{{% /alert %}} 
### **Get or Set the state of the SmartArt regarding left-to-right or right-to-left**
In order to change orientation of SmartArt. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Add SmartArt on slide.
- Get or Set the state of SmartArt Diagram.
- Write the presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-GetOrSetTheStateOfTheSmartArtRegardingLeftToRightOrRightToLeft-GetOrSetTheStateOfTheSmartArtRegardingLeftToRightOrRightToLeft.java" >}}
### **Get or Set the organization chart type associated with current node**
Methods [ISmartArtNode.getOrganizationChartLayout()](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ismartartnode/methods/getOrganizationChartLayout\(\)/), [setOrganizationChartLayout(int)](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ismartartnode/methods/setOrganizationChartLayout\(int\)/) allow get or sets organization chart type associated with current node. In order to get or set organization chart type. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Add SmartArt on slide.
- Get or Set the organization chart type.
- Write the presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-GetOrSetTheStateOfTheSmartArtRegardingLeftToRightOrRightToLeft-GetOrSetTheStateOfTheSmartArtRegardingLeftToRightOrRightToLeft.java" >}}
### **Get Text from SmartArt**
Now TextFrame property has been added to ISmartArtShape interface and SmartArtShape class respectively. This property allows you to get all text from SmartArt if it has not only nodes text. The following sample code will help you to get text from SmartArt node.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-GetTextFromSmartArtNode-GetTextFromSmartArtNode.java" >}}
### **Support for setting custom position for child nodes in SmartArt**
Now Aspose.Slides for Java support for setting SmartArtShape X and Y properties. The code snippet below shows how to set custom SmartArtShape position, size and rotation also please note that adding new nodes causes a recalculation of the positions and sizes of all nodes. Also with custom position settings, user may set the nodes as per requirements.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.java" >}}
