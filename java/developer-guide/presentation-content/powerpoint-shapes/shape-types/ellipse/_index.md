---
title: Ellipse
type: docs
weight: 10
url: /java/ellipse/
---

## **Overview**
{{% alert color="primary" %}} 

In this topic, we will introduce developers about adding ellipse shapes to their slides using Aspose.Slides for Java. Aspose.Slides for Java provides an easier set of APIs to draw different kinds of shapes with just a few lines of code.

{{% /alert %}} 

## **Add Simple Ellipse to Slide**
To add a simple ellipse to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Ellipse type using AddAutoShape method exposed by IShapes object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added an ellipse to the first slide

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingSimpleEllipseInTheSlide-AddingSimpleEllipseInTheSlide.java" >}}




|![todo:image_alt_text](http://i.imgur.com/RBLQ71G.png)|
| :- |
|**Figure: Simple ellipse added to the slide**|

## **Add Formatted Ellipse to Slide**
To add a better formatted ellipse to a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Ellipse type using AddAutoShape method exposed by IShapes object.
- Set the Fill Type of the Ellipse to Solid.
- Set the Color of the Ellipse using SolidFillColor.Color property as exposed by FillFormat object associated with the IShape object.
- Set the Color of the lines of the Ellipse.
- Set the Width of the lines of the Ellipse.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a formatted ellipse to the first slide of the presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingFormattedEllipseInTheSlide-AddingFormattedEllipseInTheSlide.java" >}}

|![todo:image_alt_text](http://i.imgur.com/7Xo2fDq.png)|
| :- |
|**Figure: Formatted ellipse added to the slide**|
