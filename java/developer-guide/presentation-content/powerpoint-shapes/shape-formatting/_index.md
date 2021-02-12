---
title: Shape Formatting
type: docs
weight: 20
url: /java/shape-formatting/
---



## **Fill Shape with Gradient**
To fill a shape with a gradient of two colors, **GradientStops** can be used. Please follow the steps below to achieve this:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IShape](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IShape) to the slide.
- Set the Fill Type of the Shape to Gradient.
- Add two desired colors with the defined position using Add methods exposed by GradientStops collection associated with GradientFormat class.
- Write the modified presentation as a PPTX file

In the example given below, we have selected the ellipse shape for the demonstration purpose.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-FillingShapesWithGradient-FillingShapesWithGradient.java" >}}


The above code snippet adds an ellipse (filled with a gradient made up of two colors) to the slide as shown below:

|![todo:image_alt_text](http://i.imgur.com/x4e8d4Q.jpg)|
| :- |
|**Figure: Ellipse filled with gradient of two colors**|

## **Fill Shape with Pattern**
{{% alert color="primary" %}} 

This topic covers about patterns that can also be used by developers to fill their shapes in more attractive styles. Aspose.Slides for Java offers more than 45 pre-defined pattern styles that can be used by developers to enrich their presentations.

{{% /alert %}} 

To fill a shape with some pattern using Aspose.Slides for Java, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IShape](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IShape) to the slide.
- Set the Fill Type of the Shape to Pattern.
- Set the Pattern Style of the Shape.
- Set the Background Color of the PatternFormat.
- Set the Foreground Color of the PatternFormat.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-FillingShapesWithPattern-FillingShapesWithPattern.java" >}}


The above code snippet adds a rectangle shape (filled with Trellis pattern style) to the slide as shown below:

|![todo:image_alt_text](http://i.imgur.com/LoLy73l.jpg)|
| :- |
|**Figure: Rectangle filled with Trellis pattern style**|

## **Fill Shape with Picture**
{{% alert color="primary" %}} 

In our previous topics, we have discussed about using pre-defined gradient and pattern styles to fill shapes. But, what if a developer needs to fill a shape with an image of his own choice? Well, to answer this question, Aspose.Slides for Java gives full freedom to its users to fill a shape with any desired image. In this topic, we will discuss that how can this be achieved.

{{% /alert %}} 

To fill a shape with a picture using Aspose.Slides for Java, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IShape](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IShape) to the slide.
- Set the Fill Type of the Shape to Picture.
- Set the Picture Fill Mode to Tile.
- Create an IPPImage object using an image that will be used to fill the Shape.
- Set the Picture.Image property of the [PictureFillFormat](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/PictureFillFormat) object to the IPPImage object created in above step.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-FillingShapesWithPicture-FillingShapesWithPicture.java" >}}

|![todo:image_alt_text](http://i.imgur.com/qnUEXeT.jpg)|
| :- |
|**Figure: An Arrow Shaped Line added to the slide**|

## **Fill Shape with Solid Color**
{{% alert color="primary" %}} 

In this topic, we will discuss that how can developers fill their shapes with solid colors. A solid color is in fact a plain color without any kind of effects like gradient, pattern etc. Aspose.Slides for Java provides the simplest API to perform this task.

{{% /alert %}} 

To fill a shape with some solid color using Aspose.Slides for Java, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IShape](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IShape) to the slide.
- Set the Fill Type of the Shape to Solid.
- Set the color of the Shape.
- Write the modified presentation as a PPTX file.
  The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-FillingShapesWithSolidColor-FillingShapesWithSolidColor.java" >}}

|![todo:image_alt_text](http://i.imgur.com/OGGmIny.jpg)|
| :- |
|**Figure: Rectangle filled with Solid yellow color**|




## **StretchOff Property**
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

## **Lines Formatting**
{{% alert color="primary" %}} 

In our previous topics, we have demonstrated that developers can add different kinds of shapes to their slides like line, rectangle etc. All of these shapes are made up of lines and Aspose.Slides for Java allows developers to control the format of these lines of the shapes. This is what we are going to discuss in this topic.

{{% /alert %}} {{% alert color="primary" %}} 

One such line style is the **Join Style** supported by MS-PowerPoint 2007. This topic also discusses how to set this style with Aspose.Slides for Java.

{{% /alert %}} 

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

## **Join Styles Formatting**
Join Style is the style of the outer corners of the shape. They are of three types.

- Mitter
- Bevel
- Round

In the example given below, we will create three rectangles with each of the Join Style mentioned above and show the resulting output of the code.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-FormattingTheJoinStyles-FormattingTheJoinStyles.java" >}}

|![todo:image_alt_text](http://i.imgur.com/QgXTgA9.png)|
| :- |
|**Figure: Formatted Lines of Rectangles with Join Styles**|




## **Apply 3D Bevel Effects on Shape**
{{% alert color="primary" %}} 

Aspose.Slides for Java supports adding 3D bevel effects to a shape. This could be done by setting **ThreeDFormat** properties of a shape programatically. In this topic, we will see with example how to set the 3D Bevel Effects to a shape in Aspose.Slides.

{{% /alert %}} 

In order to set the ThreeDFormat properties. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Add a shape on slide.
- Set ThreeDFormat properties of shape.
- Write the presentation as a PPTX file.

In the example given below, we have applied 3D bevel effects on a shape.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-Adding3DBavelEffectsToShape-Adding3DBavelEffectsToShape.java" >}}


## **Set Alternative Text to Shape**
Aspose.Slides for Java allows developers to set AlternateText of any shape. To set the AlternateText of a shape, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Access the first slide.
- Add any shape to the slide.
- Do some work with the newly added shape.
- Traverse through shapes to find an shape.
- Set the AlternativeText.
- Save file to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-SettingTheAlternativeTextPropertyOfShapes-SettingTheAlternativeTextPropertyOfShapes.java" >}}

