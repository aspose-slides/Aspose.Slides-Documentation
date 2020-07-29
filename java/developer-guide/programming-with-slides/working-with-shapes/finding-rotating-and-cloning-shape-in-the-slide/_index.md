---
title: Finding, Rotating and Cloning Shape in the Slide
type: docs
weight: 40
url: /java/finding-rotating-and-cloning-shape-in-the-slide/
---

## **Finding a Shape in the Slide**
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
## **Rotating Shapes**
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
## **Cloning Shapes in Slides**
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
## **Creating Shape Thumbnails**
{{% alert color="primary" %}} 

Aspose.Slides for Java is used to create presentation files where each page is a slides. These slides can be viewed by opening the presentation files using Microsoft PowerPoint. But sometimes, developers may need to view the images of the shapes separately in an image viewer. In such cases, Aspose.Slides for Java helps you generate thumbnail images of the slide shapes. How to use this feature is described in this article.

{{% /alert %}} 

This article explains how to generate slide thumbnails in different ways:
### **Generating Shape Thumbnail from a Slide**
To generate a shape thumbnail from any slide using Aspose.Slides for Java:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. Get the shape thumbnail image of the referenced slide on default scale.
1. Save the thumbnail image to any desired image format.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-GeneratingShapeThumbnailFromASlide-GeneratingShapeThumbnailFromASlide.java" >}}
### **Generating a Thumbnail from a Slide with User Defined Scaling Factor**
To generate the shape thumbnail of any slide using Aspose.Slides for Java:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. Get the thumbnail image of the referenced slide with user defined dimensions.
1. Save the thumbnail image in any desired image format.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-GeneratingAThumbnailFromASlideWithUserDefinedScalingFactor-GeneratingAThumbnailFromASlideWithUserDefinedScalingFactor.java" >}}
### **Generating a Shape Thumbnail in the Bounds of a Shape's Appearance**
This method for creating thumbnails of shapes allows developers to generate a thumbnail in the bounds of the shape's appearance. It takes into account all the shape effects. The generated shape thumbnail is restricted by the slide bounds. To generate a thumbnail of any slide shape in bound of its appearance, use following sample code:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. Get the thumbnail image of the referenced slide with shape bounds as appearance.
1. Save the thumbnail image in any desired image format.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-GeneratingAShapeThumbnailInTheBoundsOfAShapesAppearance-GeneratingAShapeThumbnailInTheBoundsOfAShapesAppearance.java" >}}
### **Generating a thumbnail of SmartArt child node**
Developers can generate a thumbnail of Child node of a SmartArt by following the steps below:

1. Instantiate [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class that represents the PPTX file.
1. Add SmartArt.
1. Obtain the reference of a node by using its Index.
1. Get the thumbnail image.
1. Save the thumbnail image in any desired image format.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-GeneratingAThumbnailOfSmartArtChildNode-GeneratingAThumbnailOfSmartArtChildNode.java" >}}
### **Render Shape as SVG**
Now Aspose.Slides for Java support for rendering a shape as svg. WriteAsSvg method (and its overload) has been added to Shape class and IShape interface. This method allows to save content of the shape as an SVG file. Code snippet below shows how to export slide's shape to an SVG file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ExportShapeToSVG-ExportShapeToSVG.java" >}}
## **Managing Shape Properties**
{{% alert color="primary" %}} 

In this topic, we will explore the different properties of shapes. Shapes in a presentation could be distinguished by the AlternativeText or Shape Name property. AlternativeText property could be read or set by using Aspose.Slides as well as Microsoft Powerpoint. By using this property, you can tag a shape and can perform different operations as Removing a shape, Hiding a shape or Reordering shapes on a slide.

{{% /alert %}} 
### **Setting the AlternativeText property of shapes**
Aspose.Slides for Java allows developers to set AlternateText of any shape. To set the AlternateText of a shape, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Access the first slide.
- Add any shape to the slide.
- Do some work with the newly added shape.
- Traverse through shapes to find an shape.
- Set the AlternativeText.
- Save file to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-SettingTheAlternativeTextPropertyOfShapes-SettingTheAlternativeTextPropertyOfShapes.java" >}}
### **Removing Shape from a slide**
Aspose.Slides for Java allows developers to remove any shape. To remove the shape from any slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Access the first slide.
- Find the shape with specific AlternativeText.
- Remove the shape.
- Save file to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-RemovingShapeFromASlide-RemovingShapeFromASlide.java" >}}
### **Getting Interop Shape ID**
Aspose.Slides for Java allows developers to getting unique shape identifier in slide scope in contrast to the UniqueId property, which allows obtaining a unique identifier in presentation scope. Property OfficeInteropShapeId was added to IShape interfaces and Shape class respectively. The value returned by OfficeInteropShapeId property corresponds to the value of the Id of the Microsoft.Office.Interop.PowerPoint.Shape object. Below is sample code given.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-InterLopShapeId-InterLopShapeId.java" >}}
### **Hiding the shapes from slide**
Aspose.Slides for Java allows developers to hide any shape. To hide the shape from any slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Access the first slide.
- Find the shape with specific AlternativeText.
- Hide the shape.
- Save file to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-HidingTheShapesFromSlide-HidingTheShapesFromSlide.java" >}}
### **Changing order of shapes**
Aspose.Slides for Java allows developers to reorder the shapes. Reordering the shape specifies which shape is on front or which shape is at the back. To reorder the shape from any slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Access the first slide.
- Add a shape.
- Add some text in shape's text frame.
- Add another shape with same co-ordinates.
- Reorder the shapes.
- Save file to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ChangingOrderOfShapes-ChangingOrderOfShapes.java" >}}
### **Access Layout Formats For Shape**
Aspose.Slides for Java provides a simple API to access layout formats for a shape. This article demonstrates how you can access layout formats.

Below sample code is given.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-AccessLayoutFormats-AccessLayoutFormats.java" >}}
## **Calculating Connector Line Angle**
{{% alert color="primary" %}} 

In this topic we will learn how to calculate the angle of connector line added in slide using Aspose.Slides for Java.

{{% /alert %}} 
### **Finding The Angle Of Connector Lines**
In order to calculate the angle for connector line, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation.
- Obtain the reference of a slide by using its Index.
- Access the Connector Line shape.
- Use the line width, height, shape frame height and shape frame width to calculate the angle.

In the example given below, we have calculated the angle for connector line shape in slide.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-ShapesNew-CalculatingConnectorLineAngle-.java" >}}
## **Connecting shapes using Connectors**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports connecting shapes using connectors layout. In this topic, we will see with example for how to connect two shapes using Connectors in Aspose.Slides.

{{% /alert %}} 

The connectors can be connected to shapes in two ways:
### **Connecting shapes using connectors**
In order to add a connector shape for joining two shapes. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add two add AutoShape's in selected slide using AddAutoShape method exposed by Shapes object.
- Add Connector using **AddConnector** method exposed by Shapes object by defining Connector Type.
- Join the added shape using connectors.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ConnectingShapesUsingConnectors-ConnectingShapesUsingConnectors.java" >}}

{{% alert color="primary" %}} 

Method com.aspose.slides.IConnector.reroute() reroutes connector so that it take the shortest possible path between the shapes it connect. To do this, the reroute() method may change the StartShapeConnectionSiteIndex and EndShapeConnectionSiteIndex.

{{% /alert %}} 
### **Connecting Shape with connector on desired connection site**
In order to add a connector shape for joining two shapes. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add two add AutoShape's in selected slide using AddAutoShape method exposed by Shapes object.
- Add Connector using **AddConnector** method exposed by Shapes object by defining Connector Type.
- Join the added shape using connectors.
- Setting the desired connection site on shape for connector.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ConnectingShapeWithConnectorOnDesiredConnectionSite-ConnectingShapeWithConnectorOnDesiredConnectionSite.java" >}}
