---
title: Line
type: docs
weight: 10
url: /java/Line/
---


## **Overview**
{{% alert color="primary" %}} 

Aspose.Slides for Java supports adding different kinds of shapes to the slides. In this topic, we will start working with shapes by adding lines to the slides. Using Aspose.Slides for Java, developers can not only create simple lines, but some fancy lines can also be drawn on the slides.

{{% /alert %}} 

## **Add Plain Line to Slide**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using **addAutoShape** method exposed by Shapes object.
- Write the modified presentation as a PPTX file

In the example given below, we have added a line to the first slide of the presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingPlainLineToSlide-AddingPlainLineToSlide.java" >}}




|![todo:image_alt_text](http://i.imgur.com/jMTtJhB.jpg)|
| :- |
|**Figure: Line shape added to the slide**|

## **Add Arrow Shaped Line to Slide**
The line created in the above section is a very simple one. However, Aspose.Slides for Java also allows developers to configure some properties of the line to make it look more appealing. Let's try to configure few properties of a line to make it look like an arrow. Please follow the steps below to do so:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using **addAutoShape** method exposed by Shapes object.
- Set the Line Style to one of the styles as offered by Aspose.Slides for Java.
- Set the Width of the line.
- Set the Dash Style of the line to one of the styles offered by Aspose.Slides for Java.
- Set the Arrow Head Style and Length of the start point of the line.
- Set the Arrow Head Style and Length of the end point of the line.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingArrowShapedLineToSlide-AddingArrowShapedLineToSlide.java" >}}

|![todo:image_alt_text](http://i.imgur.com/TNh84me.png)|
| :- |
|**Figure: An Arrow Shaped Line added to the slide**|

