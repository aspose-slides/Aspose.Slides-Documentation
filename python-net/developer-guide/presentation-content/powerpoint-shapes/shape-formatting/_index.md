---
title: Shape Formatting
type: docs
weight: 20
url: /python-net/shape-formatting/
keywords: "Format shape, format lines, format join styles, gradient fill, pattern fill, picture fill, solid color fill, rotate shapes, 3d bevel effects, 3d rotation effect, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Format shape in PowerPoint presentation in Python"
---

## **Format Lines**
Using Aspose.Slides for Python via .NET developers can add different kinds of shapes to their slides like line, rectangle. All of these shapes are made up of lines and Aspose.Slides for Python via .NET allows developers to control the format of these lines of the shapes. This is what we are going to discuss in this topic. One such line style is the Join Style supported by MS-PowerPoint 2007. This topic also discusses how to set this style with Aspose.Slides for Python via .NET. It is possible to change the format settings of the lines with which a shape is obtained. For example, you can change the width of the line, modify the color of the line, apply different kinds of styles on the lines etc. To understand the use of this feature, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Color of the shape lines.
- Set the Width of the shape lines.
- Set the Line Style of the shape lines to one of the styles offered by Aspose.Slides for Python via .NET.
- Set the [Dash Style](http://www.aspose.com/api/net/slides/aspose.slides/linedashstyle) of the shape lines to one of the styles offered by Aspose.Slides for Python via .NET.
- Write the modified presentation as a PPTX file.

In the example given below, we have selected an AutoShape of Rectangle type whose lines are formatted using Aspose.Slides for Python via .NET .

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Set the fill color of the rectangle shape
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.white

    # Apply some formatting on the line of the rectangle
    shp.line_format.style = slides.LineStyle.THICK_THIN
    shp.line_format.width = 7
    shp.line_format.dash_style = slides.LineDashStyle.DASH

    # Set the color of the line of rectangle
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    #Write the PPTX file to disk
    pres.save("RectShpLn_out-1.pptx", slides.export.SaveFormat.PPTX)
```


## **Format Join Styles**
Join Style is the style of the outer corners of the shape. They are of three types.

- Mitter
- Bevel
- Round

In the example given below, we will create three rectangles with each of the Join Style mentioned above and show the resulting output of the code.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
	# Get the first slide
	sld = pres.slides[0]

	# Add three autoshapes of rectangle type
	shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 150, 75)
	shp2 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 150, 75)
	shp3 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 150, 75)

	# Set the fill color of the rectangle shape
	shp1.fill_format.fill_type = slides.FillType.SOLID
	shp1.fill_format.solid_fill_color.color = draw.Color.black
	shp2.fill_format.fill_type = slides.FillType.SOLID
	shp2.fill_format.solid_fill_color.color = draw.Color.black
	shp3.fill_format.fill_type = slides.FillType.SOLID
	shp3.fill_format.solid_fill_color.color = draw.Color.black

	# Set the line width
	shp1.line_format.width = 15
	shp2.line_format.width = 15
	shp3.line_format.width = 15

	# Set the color of the line of rectangle
	shp1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shp2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shp3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Set the Join style
	shp1.line_format.join_style = slides.LineJoinStyle.MITER
	shp2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shp3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Add text to each rectangle
	shp1.text_frame.text = "This is Miter Join style"
	shp2.text_frame.text = "This is Bevel Join style"
	shp3.text_frame.text = "This is Round Join style"

	#Write the PPTX file to disk
	pres.save("RectShpLnJoin_out-2.pptx", slides.export.SaveFormat.PPTX)
```


## **Gradient Fill**
Aspose.Slides for Python via .NET supports different features while filling shapes in slides in topics in upcoming topics we will cover how we can Filling Shapes with pattern, gradient, pictures , solid colors. In this topic, we will discuss about gradient effects by describing the use of two colors with gradient effects offered by Aspose.Slides for Python via .NET. To fill a shape with a gradient of two colors, GradientStops can be used. Please follow the steps below to achieve this:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Fill Type of the Shape to Gradient.
- Add two desired colors with the defined position using Add methods exposed by GradientStops collection associated with GradientFormat class.
- Write the modified presentation as a PPTX file.

In the example given below, we have selected the ellipse shape for the demonstration purpose.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of ellipse type
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 75, 150)

    # Apply some gradiant formatting to ellipse shape
    shp.fill_format.fill_type = slides.FillType.GRADIENT
    shp.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Set the Gradient Direction
    shp.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Add two Gradiant Stops
    shp.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shp.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    #Write the PPTX file to disk
    pres.save("EllipseShpGrad_out-3.pptx", slides.export.SaveFormat.PPTX)
```


## **Pattern Fill**
This topic covers about patterns that can also be used by developers to fill their shapes in more attractive styles. Aspose.Slides for Python via .NET offers more than 45 pre-defined pattern styles that can be used by developers to enrich their presentations. To fill a shape with some pattern using Aspose.Slides for Python via .NET, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Fill Type of the Shape to Pattern.
- Set the Pattern Style of the Shape.
- Set the [Background Color ](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/backcolor)of the [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat).
- Set the [Foreground Color ](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/forecolor)of the [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat).
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Set the fill type to Pattern
    shp.fill_format.fill_type = slides.FillType.PATTERN

    # Set the pattern style
    shp.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Set the pattern back and fore colors
    shp.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shp.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    #Write the PPTX file to disk
    pres.save("RectShpPatt_out-4.pptx", slides.export.SaveFormat.PPTX)
```


## **Picture Fill**
In our previous topics, we have discussed about using pre-defined gradient and pattern styles to fill shapes. But, what if a developer needs to fill a shape with an image of his own choice? Well, to answer this question, Aspose.Slides for Python via .NET gives full freedom to its users to fill a shape with any desired image. In this topic, we will discuss that how can this be achieved. To fill a shape with a picture using Aspose.Slides for Python via .NET, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Fill Type of the Shape to Picture.
- Set the Picture Fill Mode to Tile.
- Create an IPPImage object using an image that will be used to fill the Shape.
- Set the Picture.Image property of the PictureFillFormat object to the IPPImage object created in above step.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate PrseetationEx class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)


    # Set the fill type to Picture
    shp.fill_format.fill_type = slides.FillType.PICTURE

    # Set the picture fill mode
    shp.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Set the picture
    img = draw.Bitmap(path + "Tulips.jpg")
    imgx = pres.images.add_image(img)
    shp.fill_format.picture_fill_format.picture.image = imgx

    #Write the PPTX file to disk
    pres.save("RectShpPic_out-5.pptx", slides.export.SaveFormat.PPTX)
```


## **Solid Color Fill**
In this topic, we will discuss that how can developers fill their shapes with solid colors. A solid color is in fact a plain color without any kind of effects like gradient, pattern etc. Aspose.Slides for Python via .NET provides the simplest API to perform this task. To fill a shape with some solid color using Aspose.Slides for Python via .NET, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an IShape to the slide.
- Set the Fill Type of the Shape to Solid.
- Set the color of the Shape.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Get the first slide
    slide = presentation.slides[0]

    # Add autoshape of rectangle type
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Set the fill type to Solid
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Set the color of the rectangle
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    #Write the PPTX file to disk
    presentation.save("RectShpSolid_out-6.pptx", slides.export.SaveFormat.PPTX)
```



## **Rotate Shapes**
Aspose.Slides for Python via .NET allows developers to you rotate shapes as well in this topic, we will see how developers can rotate their shapes. Rotating a shape using Aspose.Slides for Python via .NET is as easy as ABC. To rotate a shape added to the slide, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add a Shape to the slide.
- Rotate the Shape to some degrees.
- Write the modified presentation as a PPTX file.

In the example given below, we have rotated a rectangle shape to 90 degrees for the demonstration purpose.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Rotate the shape to 90 degree
    shp.rotation = 90

    # Write the PPTX file to disk
    pres.save("RectShpRot_out-7.pptx", slides.export.SaveFormat.PPTX)
```


## **Add 3D Bevel Effects**
Aspose.Slides for Python via .NET now supports adding 3D bevel effects to a shape. This could be done by setting ThreeDFormat properties of a shape programatically. In this topic, we will see with example how to set the 3D Bevel Effects to a shape in Aspose.Slides. In order to set the ThreeDFormat properties. Please follow the steps below:

1. Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Add a shape on slide.
1. Set ThreeDFormat properties of shape.
1. Write the presentation to disk.
   In the example given below, we have applied 3D bevel effects on a shape.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Create an instance of Presentation class
with slides.Presentation() as pres:
    slide = pres.slides[0]

    # Add a shape on slide
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 30, 30, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    format = shape.line_format.fill_format
    format.fill_type = slides.FillType.SOLID
    format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Set three_dformat properties of shape
    shape.three_dformat.depth = 4
    shape.three_dformat.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_dformat.bevel_top.height = 6
    shape.three_dformat.bevel_top.width = 6
    shape.three_dformat.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_dformat.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_dformat.light_rig.direction = slides.LightingDirection.TOP

    # Write the presentation as a PPTX file
    pres.save("Bavel_out-8.pptx", slides.export.SaveFormat.PPTX)
```


## **Add 3D Rotation Effect**
Aspose.Slides for Python via .NET now supports adding 3D Rotation effects to a shape. This could be done by setting ThreeDFormat properties of a shape programatically. In this topic, we will see with example how to set the 3D Rotation Effects to a shape in Aspose.Slides. In order to set the ThreeDFormat properties. Please follow the steps below:

1. Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Add a shape on slide.
1. Set ThreeDFormat properties of CameraType and LightType properties to shape.
1. Write the presentation to disk.
   In the example given below, we have applied 3D Rotation effects on a shape.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Create an instance of Presentation class
with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 200, 200)

    autoShape.three_dformat.depth = 6
    autoShape.three_dformat.camera.set_rotation(40, 35, 20)
    autoShape.three_dformat.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_dformat.light_rig.light_type = slides.LightRigPresetType.BALANCED

    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.LINE, 30, 300, 200, 200)
    autoShape.three_dformat.depth = 6
    autoShape.three_dformat.camera.set_rotation(0, 35, 20)
    autoShape.three_dformat.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_dformat.light_rig.light_type = slides.LightRigPresetType.BALANCED

            
    pres.save("Rotation_out-9.pptx", slides.export.SaveFormat.PPTX)
```

