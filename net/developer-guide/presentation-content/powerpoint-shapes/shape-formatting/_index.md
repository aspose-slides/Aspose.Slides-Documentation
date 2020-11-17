---
title: Shape Formatting
type: docs
weight: 20
url: /net/shape-formatting/
---

## **Format Lines**
Using Aspose.Slides for .NET developers can add different kinds of shapes to their slides like line, rectangle. All of these shapes are made up of lines and Aspose.Slides for .NET allows developers to control the format of these lines of the shapes. This is what we are going to discuss in this topic. One such line style is the Join Style supported by MS-PowerPoint 2007. This topic also discusses how to set this style with Aspose.Slides for .NET. It is possible to change the format settings of the lines with which a shape is obtained. For example, you can change the width of the line, modify the color of the line, apply different kinds of styles on the lines etc. To understand the use of this feature, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Color of the shape lines.
- Set the Width of the shape lines.
- Set the Line Style of the shape lines to one of the styles offered by Aspose.Slides for .NET.
- Set the [Dash Style](http://www.aspose.com/api/net/slides/aspose.slides/linedashstyle) of the shape lines to one of the styles offered by Aspose.Slides for .NET.
- Write the modified presentation as a PPTX file.

In the example given below, we have selected an AutoShape of Rectangle type whose lines are formatted using Aspose.Slides for .NET .

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-FormatLines-FormatLines.cs" >}}
## **Format Join Styles**
Join Style is the style of the outer corners of the shape. They are of three types.

- Mitter
- Bevel
- Round

In the example given below, we will create three rectangles with each of the Join Style mentioned above and show the resulting output of the code.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-FormatJoinStyles-FormatJoinStyles.cs" >}}
## **Gradient Fill**
Aspose.Slides for .NET supports different features while filling shapes in slides in topics in upcoming topics we will cover how we can Filling Shapes with pattern, gradient, pictures , solid colors. In this topic, we will discuss about gradient effects by describing the use of two colors with gradient effects offered by Aspose.Slides for .NET. To fill a shape with a gradient of two colors, GradientStops can be used. Please follow the steps below to achieve this:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Fill Type of the Shape to Gradient.
- Add two desired colors with the defined position using Add methods exposed by GradientStops collection associated with GradientFormat class.
- Write the modified presentation as a PPTX file.

In the example given below, we have selected the ellipse shape for the demonstration purpose.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-FillShapesGradient-FillShapesGradient.cs" >}}
## **Pattern Fill**
This topic covers about patterns that can also be used by developers to fill their shapes in more attractive styles. Aspose.Slides for .NET offers more than 45 pre-defined pattern styles that can be used by developers to enrich their presentations. To fill a shape with some pattern using Aspose.Slides for .NET, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Fill Type of the Shape to Pattern.
- Set the Pattern Style of the Shape.
- Set the [Background Color ](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/backcolor)of the [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat).
- Set the [Foreground Color ](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/forecolor)of the [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat).
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-FillShapesPattern-FillShapesPattern.cs" >}}
## **Picture Fill**
In our previous topics, we have discussed about using pre-defined gradient and pattern styles to fill shapes. But, what if a developer needs to fill a shape with an image of his own choice? Well, to answer this question, Aspose.Slides for .NET gives full freedom to its users to fill a shape with any desired image. In this topic, we will discuss that how can this be achieved. To fill a shape with a picture using Aspose.Slides for .NET, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Fill Type of the Shape to Picture.
- Set the Picture Fill Mode to Tile.
- Create an IPPImage object using an image that will be used to fill the Shape.
- Set the Picture.Image property of the PictureFillFormat object to the IPPImage object created in above step.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-FillShapesPicture-FillShapesPicture.cs" >}}
## **Solid Color Fill**
In this topic, we will discuss that how can developers fill their shapes with solid colors. A solid color is in fact a plain color without any kind of effects like gradient, pattern etc. Aspose.Slides for .NET provides the simplest API to perform this task. To fill a shape with some solid color using Aspose.Slides for .NET, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Fill Type of the Shape to Solid.
- Set the color of the Shape.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.



{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-FillShapeswithSolidColor-FillShapeswithSolidColor.cs" >}}
## **Rotate Shapes**
Aspose.Slides for .NET allows developers to you rotate shapes as well in this topic, we will see how developers can rotate their shapes. Rotating a shape using Aspose.Slides for .NET is as easy as ABC. To rotate a shape added to the slide, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add a Shape to the slide.
- Rotate the Shape to some degrees.
- Write the modified presentation as a PPTX file.

In the example given below, we have rotated a rectangle shape to 90 degrees for the demonstration purpose.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-RotatingShapes-RotatingShapes.cs" >}}
## **Add 3D Bevel Effects**
Aspose.Slides for .NET now supports adding 3D bevel effects to a shape. This could be done by setting ThreeDFormat properties of a shape programatically. In this topic, we will see with example how to set the 3D Bevel Effects to a shape in Aspose.Slides. In order to set the ThreeDFormat properties. Please follow the steps below:

1. Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Add a shape on slide.
1. Set ThreeDFormat properties of shape.
1. Write the presentation to disk.
   In the example given below, we have applied 3D bevel effects on a shape.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-ApplyBevelEffects-ApplyBevelEffects.cs" >}}
## **Add 3D Rotation Effect**
Aspose.Slides for .NET now supports adding 3D Rotation effects to a shape. This could be done by setting ThreeDFormat properties of a shape programatically. In this topic, we will see with example how to set the 3D Rotation Effects to a shape in Aspose.Slides. In order to set the ThreeDFormat properties. Please follow the steps below:

1. Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Add a shape on slide.
1. Set ThreeDFormat properties of CameraType and LightType properties to shape.
1. Write the presentation to disk.
   In the example given below, we have applied 3D Rotation effects on a shape.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-Apply3DRotationEffectOnShape-Apply3DRotationEffecrOnShapes.cs" >}}
