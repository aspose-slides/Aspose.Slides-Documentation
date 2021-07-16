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

```c#
// Instantiate Prseetation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add autoshape of rectangle type
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Set the fill color of the rectangle shape
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.White;

    // Apply some formatting on the line of the rectangle
    shp.LineFormat.Style = LineStyle.ThickThin;
    shp.LineFormat.Width = 7;
    shp.LineFormat.DashStyle = LineDashStyle.Dash;

    // Set the color of the line of rectangle
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    //Write the PPTX file to disk
    pres.Save("RectShpLn_out.pptx", SaveFormat.Pptx);
}
```


## **Format Join Styles**
Join Style is the style of the outer corners of the shape. They are of three types.

- Mitter
- Bevel
- Round

In the example given below, we will create three rectangles with each of the Join Style mentioned above and show the resulting output of the code.

```c#
// Instantiate Prseetation class that represents the PPTX
using (Presentation pres = new Presentation())
{

	// Get the first slide
	ISlide sld = pres.Slides[0];

	// Add three autoshapes of rectangle type
	IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
	IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
	IShape shp3 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

	// Set the fill color of the rectangle shape
	shp1.FillFormat.FillType = FillType.Solid;
	shp1.FillFormat.SolidFillColor.Color = Color.Black;
	shp2.FillFormat.FillType = FillType.Solid;
	shp2.FillFormat.SolidFillColor.Color = Color.Black;
	shp3.FillFormat.FillType = FillType.Solid;
	shp3.FillFormat.SolidFillColor.Color = Color.Black;

	// Set the line width
	shp1.LineFormat.Width = 15;
	shp2.LineFormat.Width = 15;
	shp3.LineFormat.Width = 15;

	// Set the color of the line of rectangle
	shp1.LineFormat.FillFormat.FillType = FillType.Solid;
	shp1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	shp2.LineFormat.FillFormat.FillType = FillType.Solid;
	shp2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	shp3.LineFormat.FillFormat.FillType = FillType.Solid;
	shp3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	// Set the Join Style
	shp1.LineFormat.JoinStyle = LineJoinStyle.Miter;
	shp2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
	shp3.LineFormat.JoinStyle = LineJoinStyle.Round;

	// Add text to each rectangle
	((IAutoShape)shp1).TextFrame.Text = "This is Miter Join Style";
	((IAutoShape)shp2).TextFrame.Text = "This is Bevel Join Style";
	((IAutoShape)shp3).TextFrame.Text = "This is Round Join Style";

	//Write the PPTX file to disk
	pres.Save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
}
```


## **Gradient Fill**
Aspose.Slides for .NET supports different features while filling shapes in slides in topics in upcoming topics we will cover how we can Filling Shapes with pattern, gradient, pictures , solid colors. In this topic, we will discuss about gradient effects by describing the use of two colors with gradient effects offered by Aspose.Slides for .NET. To fill a shape with a gradient of two colors, GradientStops can be used. Please follow the steps below to achieve this:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Fill Type of the Shape to Gradient.
- Add two desired colors with the defined position using Add methods exposed by GradientStops collection associated with GradientFormat class.
- Write the modified presentation as a PPTX file.

In the example given below, we have selected the ellipse shape for the demonstration purpose.

```c#
// Instantiate Prseetation class that represents the PPTX// Instantiate Prseetation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add autoshape of ellipse type
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // Apply some gradiant formatting to ellipse shape
    shp.FillFormat.FillType = FillType.Gradient;
    shp.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Set the Gradient Direction
    shp.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Add two Gradiant Stops
    shp.FillFormat.GradientFormat.GradientStops.Add((float)1.0, PresetColor.Purple);
    shp.FillFormat.GradientFormat.GradientStops.Add((float)0, PresetColor.Red);

    //Write the PPTX file to disk
    pres.Save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
}
```


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

```c#
// Instantiate Prseetation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add autoshape of rectangle type
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Set the fill type to Pattern
    shp.FillFormat.FillType = FillType.Pattern;

    // Set the pattern style
    shp.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Set the pattern back and fore colors
    shp.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shp.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    //Write the PPTX file to disk
    pres.Save("RectShpPatt_out.pptx", SaveFormat.Pptx);
}
```


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

```c#
// Instantiate PrseetationEx class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add autoshape of rectangle type
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);


    // Set the fill type to Picture
    shp.FillFormat.FillType = FillType.Picture;

    // Set the picture fill mode
    shp.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Set the picture
    System.Drawing.Image img = (System.Drawing.Image)new Bitmap("Tulips.jpg");
    IPPImage imgx = pres.Images.AddImage(img);
    shp.FillFormat.PictureFillFormat.Picture.Image = imgx;

    //Write the PPTX file to disk
    pres.Save("RectShpPic_out.pptx", SaveFormat.Pptx);
```


## **Solid Color Fill**
In this topic, we will discuss that how can developers fill their shapes with solid colors. A solid color is in fact a plain color without any kind of effects like gradient, pattern etc. Aspose.Slides for .NET provides the simplest API to perform this task. To fill a shape with some solid color using Aspose.Slides for .NET, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Fill Type of the Shape to Solid.
- Set the color of the Shape.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();

// Get the first slide
ISlide slide = presentation.Slides[0];

// Add autoshape of rectangle type
IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

// Set the fill type to Solid
shape.FillFormat.FillType = FillType.Solid;

// Set the color of the rectangle
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

//Write the PPTX file to disk
presentation.Save("RectShpSolid_out.pptx", SaveFormat.Pptx);
```



## **Rotate Shapes**
Aspose.Slides for .NET allows developers to you rotate shapes as well in this topic, we will see how developers can rotate their shapes. Rotating a shape using Aspose.Slides for .NET is as easy as ABC. To rotate a shape added to the slide, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add a Shape to the slide.
- Rotate the Shape to some degrees.
- Write the modified presentation as a PPTX file.

In the example given below, we have rotated a rectangle shape to 90 degrees for the demonstration purpose.

```c#
// Instantiate PrseetationEx class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add autoshape of rectangle type
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // Rotate the shape to 90 degree
    shp.Rotation = 90;

    // Write the PPTX file to disk
    pres.Save("RectShpRot_out.pptx", SaveFormat.Pptx);
}
```


## **Add 3D Bevel Effects**
Aspose.Slides for .NET now supports adding 3D bevel effects to a shape. This could be done by setting ThreeDFormat properties of a shape programatically. In this topic, we will see with example how to set the 3D Bevel Effects to a shape in Aspose.Slides. In order to set the ThreeDFormat properties. Please follow the steps below:

1. Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Add a shape on slide.
1. Set ThreeDFormat properties of shape.
1. Write the presentation to disk.
   In the example given below, we have applied 3D bevel effects on a shape.

```c#
// Create an instance of Presentation class
Presentation pres = new Presentation();
ISlide slide = pres.Slides[0];

// Add a shape on slide
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
ILineFillFormat format = shape.LineFormat.FillFormat;
format.FillType = FillType.Solid;
format.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;

// Set ThreeDFormat properties of shape
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

// Write the presentation as a PPTX file
pres.Save("Bavel_out.pptx", SaveFormat.Pptx);
```


## **Add 3D Rotation Effect**
Aspose.Slides for .NET now supports adding 3D Rotation effects to a shape. This could be done by setting ThreeDFormat properties of a shape programatically. In this topic, we will see with example how to set the 3D Rotation Effects to a shape in Aspose.Slides. In order to set the ThreeDFormat properties. Please follow the steps below:

1. Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Add a shape on slide.
1. Set ThreeDFormat properties of CameraType and LightType properties to shape.
1. Write the presentation to disk.
   In the example given below, we have applied 3D Rotation effects on a shape.

```c#
// Create an instance of Presentation class
Presentation pres = new Presentation();
IShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);

autoShape.ThreeDFormat.Depth = 6;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Line, 30, 300, 200, 200);
autoShape.ThreeDFormat.Depth = 6;
autoShape.ThreeDFormat.Camera.SetRotation(0, 35, 20);
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

          
pres.Save("Rotation_out.pptx", SaveFormat.Pptx);
```

