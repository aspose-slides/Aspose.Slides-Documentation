---
title: Shape Manipulations
type: docs
weight: 30
url: /java/shape-manipulations/
---

## **Get Interop Shape ID**
Aspose.Slides for Java allows developers to getting unique shape identifier in slide scope in contrast to the UniqueId property, which allows obtaining a unique identifier in presentation scope. Property OfficeInteropShapeId was added to IShape interfaces and Shape class respectively. The value returned by OfficeInteropShapeId property corresponds to the value of the Id of the Microsoft.Office.Interop.PowerPoint.Shape object. Below is sample code given.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-InterLopShapeId-InterLopShapeId.java" >}}

## **Find Shape**
{{% alert color="primary" %}} 

It is important to know that PowerPoint Presentation files do not have any way to identify shapes on a slide except an internal unique Id. It seems to be difficult for developers to find a shape using its internal unique Id. This topic will describe a simple technique to make it easier for developers to find a specific shape on a slide without using its internal Id.

{{% /alert %}} 

All shapes added to the slides have some **Alt Text**. We suggest developers to use alternative text for finding a specific shape. You can use MS PowerPoint to define the alternative text for objects which you are planning to change in the future as shown below:

|![todo:image_alt_text](http://i.imgur.com/M8OAaEf.png)|
| :- |
|**Figure: Setting alternative text of a shape using MS PowerPoint**|
After setting the alternative text of any desired shape, you can then open that presentation using Aspose.Slides for Java and iterate through all shapes added to a slide. During each iteration, you can check the alternative text of the shape and the shape with the matching alternative text would be the shape required by you.

To demonstrate this technique in a better way, we have created a method, **FindShape** that does the trick to find a specific shape in a slide and then simply returns that shape.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-FindShapeInSlide-FindShapeInSlide.java" >}}


Now you can use the above **FindShape** method to find a shape with a particular alternative text on a given slide as shown below:


{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-ShapesNew-FindingAShapeInASlide-CallingFindShapeMethod.java" >}}

## **Clone Shape**
{{% alert color="primary" %}} 

Aspose.Slides supports copying/cloning slide shapes within slides. This feature helps developers clone shapes that inherit all the properties of the source shape instead of creating a new shape from scratch and setting the properties. Aspose.Slides for Java supports adding and inserting cloned shapes.

This topic shows the simple steps, complete with code examples, for cloning shapes with in slide by adding and inserting on slides.

{{% /alert %}} 

To clone a shape to a slide using Aspose.Slides for Java:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its index.
1. Access the source slide shape collection.
1. Add new slide to the presentation.
1. Clone shapes from the source slide shape collection to the new slide.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-RotatingShapes-RotatingShapes.java" >}}

## **Remove Shape**
Aspose.Slides for Java allows developers to remove any shape. To remove the shape from any slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Access the first slide.
- Find the shape with specific AlternativeText.
- Remove the shape.
- Save file to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-RemovingShapeFromASlide-RemovingShapeFromASlide.java" >}}

## **Hide Shape**
Aspose.Slides for Java allows developers to hide any shape. To hide the shape from any slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Access the first slide.
- Find the shape with specific AlternativeText.
- Hide the shape.
- Save file to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-HidingTheShapesFromSlide-HidingTheShapesFromSlide.java" >}}

## **Rotate Shape**
{{% alert color="primary" %}} 

This topic is also the part of the series of the topics about formatting shapes. In this topic, we will discuss that how can developers rotate their shapes using Aspose.Slides for Java.

{{% /alert %}} 

Rotating a shape using Aspose.Slides for Java is as easy as ABC. To rotate a shape added to the slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add a Shape to the slide.
- Rotate the Shape to some degrees.
- Write the modified presentation as a PPTX file.
  In the example given below, we have rotated a rectangle shape to 90 degrees for the demonstration purpose.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-RotatingShapes-RotatingShapes.java" >}}

|![todo:image_alt_text](http://i.imgur.com/xQkoqyp.jpg)|
| :- |
|**Figure: Rectangle rotated to 90 degrees**|

## **Change Shape Order**
Aspose.Slides for Java allows developers to reorder the shapes. Reordering the shape specifies which shape is on front or which shape is at the back. To reorder the shape from any slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Access the first slide.
- Add a shape.
- Add some text in shape's text frame.
- Add another shape with same co-ordinates.
- Reorder the shapes.
- Save file to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ChangingOrderOfShapes-ChangingOrderOfShapes.java" >}}

## **Access Shape Layout Formats**
Aspose.Slides for Java provides a simple API to access layout formats for a shape. This article demonstrates how you can access layout formats.

Below sample code is given.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-AccessLayoutFormats-AccessLayoutFormats.java" >}}
