---
title: Manage SmartArt
type: docs
weight: 10
url: /java/manage-smartart/
---

## **Get Text from SmartArt**
Now TextFrame property has been added to ISmartArtShape interface and SmartArtShape class respectively. This property allows you to get all text from SmartArt if it has not only nodes text. The following sample code will help you to get text from SmartArt node.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-GetTextFromSmartArtNode-GetTextFromSmartArtNode.java" >}}

## **Get or Set SmartArt State**
In order to change orientation of SmartArt. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Add SmartArt on slide.
- Get or Set the state of SmartArt Diagram.
- Write the presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-GetOrSetTheStateOfTheSmartArtRegardingLeftToRightOrRightToLeft-GetOrSetTheStateOfTheSmartArtRegardingLeftToRightOrRightToLeft.java" >}}

## **Change Layout Type of SmartArt**
In order to change the layout type of SmartArt. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add SmartArt BasicBlockList.
1. Change LayoutType to BasicProcess.
1. Write the presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-SmartArt-ChangingTextOnSmartArtNode-ChangingTextOnSmartArtNode.java" >}}

## **Access SmartArt Shape with Particular Layout Type**
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


## **Change Hidden Property of SmartArt**
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

