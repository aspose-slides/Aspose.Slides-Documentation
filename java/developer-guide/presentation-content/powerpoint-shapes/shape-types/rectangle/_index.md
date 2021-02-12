---
title: Rectangle
type: docs
weight: 10
url: /java/rectangle/
---



## **Overview**
{{% alert color="primary" %}} 

Like previous topics, this one is also about adding a shape and this time the shape we will discuss about is **Rectangle**. In this topic, we have described that how developers can add simple or formatted rectangles to their slides using Aspose.Slides for Java.

{{% /alert %}} 

## **Add Simple Rectangle to Slide**
To add a simple rectangle to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an IAutoShape of Rectangle type using AddAutoShape method exposed by IShapes object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a simple rectangle to the first slide of the presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingSimpleRectangleInTheSlide-AddingSimpleRectangleInTheSlide.java" >}}

|![todo:image_alt_text](http://i.imgur.com/lcmxIBM.png)|
| :- |
|**Figure: Simple rectangle added to the slide**|

## **Add Formatted Rectangle to Slide**
To add a formatted rectangle to a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an IAutoShape of Rectangle type using AddAutoShape method exposed by IShapes object.
- Set the Fill Type of the Rectangle to Solid.
- Set the Color of the Rectangle using SolidFillColor.Color property as exposed by FillFormat object associated with the IShape object.
- Set the Color of the lines of the Rectangle.
- Set the Width of the lines of the Rectangle.
- Write the modified presentation as PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingFormattedRectangleToSlide-AddingFormattedRectangleToSlide.java" >}}

|![todo:image_alt_text](http://i.imgur.com/ZmDhTmP.png)|
| :- |
|**Figure: Formatted rectangle added to the slide**|
