---
title: Adding Shape to the Slide
type: docs
weight: 20
url: /java/adding-shape-to-the-slide/
---

## **Adding Line Shape to the Slide**
{{% alert color="primary" %}} 

Aspose.Slides for Java supports adding different kinds of shapes to the slides. In this topic, we will start working with shapes by adding lines to the slides. Using Aspose.Slides for Java, developers can not only create simple lines, but some fancy lines can also be drawn on the slides.

{{% /alert %}} 
### **Adding Plain Line to the Slide**
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
### **Adding Arrow Shaped Line to the Slide**
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
## **Adding Ellipse Shape to the Slide**
{{% alert color="primary" %}} 

In this topic, we will introduce developers about adding ellipse shapes to their slides using Aspose.Slides for Java. Aspose.Slides for Java provides an easier set of APIs to draw different kinds of shapes with just a few lines of code.

{{% /alert %}} 
### **Adding Simple Ellipse to the Slide**
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
### **Adding Formatted Ellipse to the Slide**
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
## **Adding Rectangle Shape to the Slide**
{{% alert color="primary" %}} 

Like previous topics, this one is also about adding a shape and this time the shape we will discuss about is **Rectangle**. In this topic, we have described that how developers can add simple or formatted rectangles to their slides using Aspose.Slides for Java.

{{% /alert %}} 
### **Adding Simple Rectangle to the Slide**
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
### **Adding Formatted Rectangle to the Slide**
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
## **Adding 3D Bavel effects to the Shape**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports adding 3D bevel effects to a shape. This could be done by setting **ThreeDFormat** properties of a shape programatically. In this topic, we will see with example how to set the 3D Bevel Effects to a shape in Aspose.Slides.

{{% /alert %}} 
### **Applying 3D Bevel Effects on a shape**
In order to set the ThreeDFormat properties. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Add a shape on slide.
- Set ThreeDFormat properties of shape.
- Write the presentation as a PPTX file.

In the example given below, we have applied 3D bevel effects on a shape.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-Adding3DBavelEffectsToShape-Adding3DBavelEffectsToShape.java" >}}
## **Adding Group Shape to the Slide**
{{% alert color="primary" %}} 

Aspose.Slides supports working with group shapes on slides. This feature helps developers support richer presentations. Aspose.Slides for Java supports adding and inserting group shapes. It is possible to add shapes to an added group shape to populate it.

This topic shows simple steps, complete with code examples, for adding a group shape and inserting shapes into group shapes on slides.

{{% /alert %}} 

To add a group shape to a slide using Aspose.Slides for Java:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add a group shape to the slide.
1. Add the shapes to the added group shape.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingGroupShapesToSlide-AddingGroupShapesToSlide.java" >}}
## **Add StretchOff Property**
The Properties StretchOffsetLeft, StretchOffsetTop, StretchOffsetRight and StretchOffsetBottom has been added to IPictureFillFormat interface and PictureFillFormat class respectively. These properties specify a fill rectangle. When stretching of an image is specified, a source rectangle is scaled to fit the specified fill rectangle. Each edge of the fill rectangle is defined by a percentage offset from the corresponding edge of the shape's bounding box. A positive percentage specifies an inset, while a negative percentage specifies an outset.

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its index.
- Add an AutoShape of Rectangle type.
- Create Image.
- Set shape's fill type.
- Set shape's picture fill mode.
- Add Set image to fill the shape.
- Specify image offsets from the corresponding edge of the shape's bounding box
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddStretchOffsetForImageFill-AddStretchOffsetForImageFill.java" >}}
## **Formatting Lines of the Shapes**
{{% alert color="primary" %}} 

In our previous topics, we have demonstrated that developers can add different kinds of shapes to their slides like line, rectangle etc. All of these shapes are made up of lines and Aspose.Slides for Java allows developers to control the format of these lines of the shapes. This is what we are going to discuss in this topic.

{{% /alert %}} {{% alert color="primary" %}} 

One such line style is the **Join Style** supported by MS-PowerPoint 2007. This topic also discusses how to set this style with Aspose.Slides for Java.

{{% /alert %}} 
### **Formatting the Lines of Shapes**
It is possible to change the format settings of the lines with which a shape is obtained. For example, you can change the width of the line, modify the color of the line, apply different kinds of styles on the lines etc.

To understand the use of this feature, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IShape](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IShape) to the slide.
- Set the Color of the shape lines.
- Set the Width of the shape lines.
- Set the Line Style of the shape lines to one of the styles offered by Aspose.Slides for Java.
- Set the Dash Style of the shape lines to one of the styles offered by Aspose.Slides for Java.
- Write the modified presentation as a PPTX file.

In the example given below, we have selected an **AutoShape** of **Rectangle** type whose lines are formatted using Aspose.Slides for Java.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-FormattingTheLinesOfShapes-FormattingTheLinesOfShapes.java" >}}


The above code snippet produces a rectangle shape with formatted lines to the slide as shown below:

|![todo:image_alt_text](http://i.imgur.com/yIBPXlw.jpg)|
| :- |
|**Figure: A Rectangle with Formatted Lines**|
### **Formatting the Join Styles**
Join Style is the style of the outer corners of the shape. They are of three types.

- Mitter
- Bevel
- Round

In the example given below, we will create three rectangles with each of the Join Style mentioned above and show the resulting output of the code.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-FormattingTheJoinStyles-FormattingTheJoinStyles.java" >}}

|![todo:image_alt_text](http://i.imgur.com/QgXTgA9.png)|
| :- |
|**Figure: Formatted Lines of Rectangles with Join Styles**|

