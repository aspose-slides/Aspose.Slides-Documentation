---
title: Shape Formatting
type: docs
weight: 20
url: /cpp/shape-formatting/
---

## **Format Line**
Using Aspose.Slides for C++ developers can add different kinds of shapes to their slides like line, rectangle. All of these shapes are made up of lines and Aspose.Slides for C++ allows developers to control the format of these lines of the shapes. This is what we are going to discuss in this topic. One such line style is the Join Style supported by MS-PowerPoint 2007. This topic also discusses how to set this style with Aspose.Slides for C++. It is possible to change the format settings of the lines with which a shape is obtained. For example, you can change the width of the line, modify the color of the line, apply different kinds of styles on the lines etc. To understand the use of this feature, please follow the steps below:

- Create an instance of [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Color of the shape lines.
- Set the Width of the shape lines.
- Set the Line Style of the shape lines to one of the styles offered by Aspose.Slides for C++.
- Set the [Dash Style](https://apireference.aspose.com/slides/cpp/namespace/aspose.slides#a7eaad354a35a3b567a7327d625be3c6e) of the shape lines to one of the styles offered by Aspose.Slides for C++.
- Write the modified presentation as a PPTX file.

In the example given below, we have selected an AutoShape of Rectangle type whose lines are formatted using Aspose.Slides for C++ .

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormatLines-FormatLines.cpp" >}}


## **Format Join Style**
Join Style is the style of the outer corners of the shape. They are of three types.

- Mitter
- Bevel
- Round

In the example given below, we will create three rectangles with each of the Join Style mentioned above and show the resulting output of the code.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormatJoinStyles-FormatJoinStyles.cpp" >}}

## **Gradient Fill**
Aspose.Slides for C++ supports different features while filling shapes in slides in topics in upcoming topics we will cover how we can Filling Shapes with pattern, gradient, pictures , solid colors. In this topic, we will discuss about gradient effects by describing the use of two colors with gradient effects offered by Aspose.Slides for C++. To fill a shape with a gradient of two colors, GradientStops can be used. Please follow the steps below to achieve this:

- Create an instance of [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Fill Type of the Shape to Gradient.
- Add two desired colors with the defined position using Add methods exposed by GradientStops collection associated with GradientFormat class.
- Write the modified presentation as a PPTX file.

In the example given below, we have selected the ellipse shape for the demonstration purpose.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillShapesGradient-FillShapesGradient.cpp" >}}
## **Pattern Fill**
This topic covers about patterns that can also be used by developers to fill their shapes in more attractive styles. Aspose.Slides for C++ offers more than 45 pre-defined pattern styles that can be used by developers to enrich their presentations. To fill a shape with some pattern using Aspose.Slides for C++, please follow the steps below:

- Create an instance of [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Fill Type of the Shape to Pattern.
- Set the Pattern Style of the Shape.
- Set the [Background Color ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#af55b6343b7bd80d0ad95070e96b8766e)of the [PatternFormat](https://apireference.aspose.com/slides/cpp/class/aspose.slides.pattern_format).
- Set the [Foreground Color ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#a4121d8c2233df4b90cbfd6ea4c312cbe)of the [PatternFormat](https://apireference.aspose.com/slides/cpp/class/aspose.slides.pattern_format).
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillShapesPattern-FillShapesPattern.cpp" >}}
## **Picture Fill**
In our previous topics, we have discussed about using pre-defined gradient and pattern styles to fill shapes. But, what if a developer needs to fill a shape with an image of his own choice? Well, to answer this question, Aspose.Slides for C++ gives full freedom to its users to fill a shape with any desired image. In this topic, we will discuss that how can this be achieved. To fill a shape with a picture using Aspose.Slides for C++, please follow the steps below:

- Create an instance of [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Fill Type of the Shape to Picture.
- Set the Picture Fill Mode to Tile.
- Create an IPPImage object using an image that will be used to fill the Shape.
- Set the Picture.Image property of the PictureFillFormat object to the IPPImage object created in above step.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillShapesPicture-FillShapesPicture.cpp" >}}
## **Solid Color Fill**
In this topic, we will discuss that how can developers fill their shapes with solid colors. A solid color is in fact a plain color without any kind of effects like gradient, pattern etc. Aspose.Slides for C++ provides the simplest API to perform this task. To fill a shape with some solid color using Aspose.Slides for C++, please follow the steps below:

- Create an instance of [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Fill Type of the Shape to Solid.
- Set the color of the Shape.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillShapeswithSolidColor-FillShapeswithSolidColor.cpp" >}}

## **Rotate Shapes**
Aspose.Slides for C++ allows developers to you rotate shapes as well in this topic, we will see how developers can rotate their shapes. Rotating a shape using Aspose.Slides for C++ is as easy as ABC. To rotate a shape added to the slide, please follow the steps below:

- Create an instance of [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Obtain the reference of a slide by using its Index.
- Add a Shape to the slide.
- Rotate the Shape to some degrees.
- Write the modified presentation as a PPTX file.

In the example given below, we have rotated a rectangle shape to 90 degrees for the demonstration purpose.

``` cpp
// Instantiate Presentation class that represents the PPTX
auto pres = System::MakeObject<Presentation>();
// Get the first slide
auto sld = pres->get_Slides()->idx_get(0);

// Add autoshape of rectangle type
auto shp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 150.0f, 75.0f, 150.0f);

// Rotate the shape to 90 degree
shp->set_Rotation(90.0f);

// Write the PPTX file to disk
pres->Save(u"RectShpRot_out.pptx", SaveFormat::Pptx);
```

## **Add 3D Bevel Effect**
Aspose.Slides for C++ now supports adding 3D bevel effects to a shape. This could be done by setting ThreeDFormat properties of a shape programatically. In this topic, we will see with example how to set the 3D Bevel Effects to a shape in Aspose.Slides. In order to set the ThreeDFormat properties. Please follow the steps below:

1. Create an instance of [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Add a shape on slide.
1. Set ThreeDFormat properties of shape.
1. Write the presentation to disk.
   In the example given below, we have applied 3D bevel effects on a shape.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ApplyBevelEffects-ApplyBevelEffects.cpp" >}}


## **Adding 3D Rotation Effect**
Aspose.Slides for C++ now supports adding 3D Rotation effects to a shape. This could be done by setting ThreeDFormat properties of a shape programatically. In this topic, we will see with example how to set the 3D Rotation Effects to a shape in Aspose.Slides. In order to set the ThreeDFormat properties. Please follow the steps below:

1. Create an instance of [Presentation class](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Add a shape on slide.
1. Set ThreeDFormat properties of CameraType and LightType properties to shape.
1. Write the presentation to disk.
   In the example given below, we have applied 3D Rotation effects on a shape.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Apply3DRotationEffectOnShape-Apply3DRotationEffectOnShape.cpp" >}}



## **Set AlternativeText Property**
Aspose.Slides for C++ allows developers to set AlternateText of any shape. To set the AlternateText of a shape, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Access the first slide.
1. Add any shape to the slide.
1. Do some work with the newly added shape.
1. Traverse through shapes to find a shape.
1. Set the AlternativeText.
1. Save file to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}
