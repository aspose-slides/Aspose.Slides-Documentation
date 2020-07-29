---
title: Filling a Shape
type: docs
weight: 30
url: /java/filling-a-shape/
---

## **Filling a Shape with Gradient**
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
## **Filling a Shape with Pattern**
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
## **Filling a Shape with Picture**
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
## **Filling a Shape with Solid Color**
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

