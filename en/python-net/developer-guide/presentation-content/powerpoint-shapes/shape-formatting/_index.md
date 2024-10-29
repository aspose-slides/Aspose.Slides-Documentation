---
title: Shape Formatting
type: docs
weight: 20
url: /python-net/shape-formatting/
keywords: "Format shape, format lines, format join styles, gradient fill, pattern fill, picture fill, solid color fill, rotate shapes, 3d bevel effects, 3d rotation effect, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Format shape in PowerPoint presentation in Python"
---

In PowerPoint, you can add shapes to slides. Since shapes are made of up lines, you can format shapes by modifying or applying certain effects to their constituent lines. Additionally, you can format shapes by specifying settings that determine how they (the area in them) are filled. 

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides for Python via .NET** provides interfaces and properties that allow you to format shapes based on known options in PowerPoint. 

## **Format Lines**

Using Aspose.Slides, you can specify your preferred line style for a shape. These steps outline such a procedure:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Add an [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) to the slide.
4. Set a color for the shape lines.
5. Set the width for the shape lines.
6. Set the [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) for the shape line
7. Set the [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) for the shape line. 
8. Write the modified presentation as a PPTX file.

This Python code demonstrates an operation where we formatted a rectangle `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates a Prseetation class that represents a PPTX file
with slides.Presentation() as pres:
    # Gets the first slide
    sld = pres.slides[0]

    # Adds a rectangle autoshape
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Sets the fill color for the rectangle shape
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.white

    # Applies some formatting on the rectangle's lines
    shp.line_format.style = slides.LineStyle.THICK_THIN
    shp.line_format.width = 7
    shp.line_format.dash_style = slides.LineDashStyle.DASH

    # Sets the color for the rectangle's line
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Writes the PPTX file to disk
    pres.save("RectShpLn_out-1.pptx", slides.export.SaveFormat.PPTX)
```

## **Format Join Styles**

These are the 3 join type options:

* Round
* Miter
* Bevel

By default, when PowerPoint joins two lines at an angle (or a shape's corner), it uses the **Round** setting. However, if you are looking to draw a shape with very sharp angles, you may want to select **Miter**.

![join-style-powerpoint](join-style-powerpoint.png)

This Python code demonstrates an operation where 3 rectangles (the image above) were created with the Miter, Bevel, and Round join type settings:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates a Prseetation class that represents a PPTX file
with slides.Presentation() as pres:
	# Gets the first slide
	sld = pres.slides[0]

	# Adds 3 rectangle autoshapes
	shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 150, 75)
	shp2 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 150, 75)
	shp3 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 150, 75)

	# Sets the fill color for the rectangle shape
	shp1.fill_format.fill_type = slides.FillType.SOLID
	shp1.fill_format.solid_fill_color.color = draw.Color.black
	shp2.fill_format.fill_type = slides.FillType.SOLID
	shp2.fill_format.solid_fill_color.color = draw.Color.black
	shp3.fill_format.fill_type = slides.FillType.SOLID
	shp3.fill_format.solid_fill_color.color = draw.Color.black

	# Sets the line's width
	shp1.line_format.width = 15
	shp2.line_format.width = 15
	shp3.line_format.width = 15

	# Sets the color for the rectangle's line
	shp1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shp2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shp3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Sets the Join Style
	shp1.line_format.join_style = slides.LineJoinStyle.MITER
	shp2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shp3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Adds text to each rectangle
	shp1.text_frame.text = "This is Miter Join style"
	shp2.text_frame.text = "This is Bevel Join style"
	shp3.text_frame.text = "This is Round Join style"

	# Writes the PPTX file to disk
	pres.save("RectShpLnJoin_out-2.pptx", slides.export.SaveFormat.PPTX)
```


## **Gradient Fill**
In PowerPoint, Gradient Fill is a formatting option that allows you to apply a continuous blend of colors to a shape. For example, you can apply a two or more colors in a setup where one color gradually fades and changes into another color. 

This is how you use Aspose.Slides to apply a gradient fill to a shape:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Add an [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) to the slide.
4. Set the Shape's [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) to `Gradient`.
5. Add your 2 preferred colors with defined positions using the `Add` methods exposed by the `GradientStops` collection associated with `GradientFormat` class.
6. Write the modified presentation as a PPTX file.

This Python code demonstrates an operation where the gradient fill effect was used on an ellipse:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates a presentation class that represents a presentation file
with slides.Presentation() as pres:
    # Gets the first slide
    sld = pres.slides[0]

    # Adds an ellipse autoshape
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 75, 150)

    # Applies the gradient formatting to the ellipse
    shp.fill_format.fill_type = slides.FillType.GRADIENT
    shp.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Sets the direction of the gradient
    shp.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Adds 2 Gradiant Stops
    shp.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shp.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Writes the PPTX file to disk
    pres.save("EllipseShpGrad_out-3.pptx", slides.export.SaveFormat.PPTX)
```


## **Pattern Fill**
In PowerPoint, Pattern Fill is a formatting option that allows you to apply a two-color design comprising of dots, stripes, cross-hatches, or checks to a shape. Additionally, you get to select your preferred colors for your pattern's foreground and background. 

Aspose.Slides provides over 45 predefined styles that can be used to format shapes and enrich presentations. Even after you choose a predefined pattern, you can still specify the colors the pattern must contain.

This is how you use Aspose.Slides to apply a pattern fill to a shape:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Add an [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) to the slide.
4. Set the Shape's [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) to `Pattern`.
5. Set your preferred pattern style for the shape. 
6. Set the Background Color  for the [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/).
7. Set the Foreground Color  for the [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/).
8. Write the modified presentation as a PPTX file.

This Python code demonstrates an operation where a pattern fill was used to beautify a rectangle: 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates a presentation class that represents a presentation file
with slides.Presentation() as pres:
    # Gets the first slide
    sld = pres.slides[0]

    # Adds a rectangle autoshape
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Sets the fill type to Pattern
    shp.fill_format.fill_type = slides.FillType.PATTERN

    # Sets the pattern style
    shp.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Sets the pattern back and fore colors
    shp.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shp.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    #Writes the PPTX file to disk
    pres.save("RectShpPatt_out-4.pptx", slides.export.SaveFormat.PPTX)
```


## **Picture Fill**
In PowerPoint, Picture Fill is a formatting option that allows you to place a picture inside a shape. Essentially, you get to use a picture as a shape's background. 

This is how you use Aspose.Slides to fill a shape with a picture:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Add an [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) to the slide.
4. Set the Shape's [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) to `Picture`.
5. Set the Picture Fill Mode to Tile.
6. Create an `IPPImage` object using the image that will be used to fill the shape.
7. Set the `Picture.Image` property of the `PictureFillFormat` object to the recently created `IPPImage`.
8. Write the modified presentation as a PPTX file.

This Python code shows you how to fill a shape with a picture:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates a Prseetation class that represents a PPTX file
with slides.Presentation() as pres:
    # Gets the first slide
    sld = pres.slides[0]

    # Adds a rectangle autoshape
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)


    # Sets the fill type to Picture
    shp.fill_format.fill_type = slides.FillType.PICTURE

    # Sets the picture fill mode
    shp.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Sets the picture
    img = draw.Bitmap(path + "Tulips.jpg")
    imgx = pres.images.add_image(img)
    shp.fill_format.picture_fill_format.picture.image = imgx

    # Writes the PPTX file to disk
    pres.save("RectShpPic_out-5.pptx", slides.export.SaveFormat.PPTX)
```


## **Solid Color Fill**
In PowerPoint, Solid Color Fill is a formatting option that allows you to fill a shape with a single color. The chosen color is typically a plain color. The color gets applied to the shape background with any special effects or modifications. 

This is how you use Aspose.Slides to apply solid color fill to a shape:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Add an [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) to the slide.
4. Set the Shape's [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) to `Solid`.
5. Set your preferred color for the Shape.
6. Write the modified presentation as a PPTX file.

This Python code shows you how to apply the solid color fill to a box in PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Gets the first slide
    slide = presentation.slides[0]

    # Adds a rectangle autoshape
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Sets the fill type to Solid
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Sets the color for the rectangle
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Writes the PPTX file to disk
    presentation.save("RectShpSolid_out-6.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Transparency**

In PowerPoint, when you fill shapes with solid colors, gradients, pictures, or textures, you can specify the transparency level that determines the opacity of a fill. This way, for example, if you set a low transparency level, the slide object or background behind (the shape) shows through. 

Aspose.Slides allows you to set the transparency level for a shape this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Add an [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) to the slide.
4. Use `Color.FromArgb` with the alpha component set.
5. Save the object as a PowerPoint file. 

This python code demonstrates the process:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # Adds a solid shape
    solidShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 75, 175, 75, 150)

    # Adds a transparent shape over solid
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("ShapeTransparentOverSolid_out.pptx", slides.export.SaveFormat.PPTX)

```

## **Rotate Shapes**
Aspose.Slides allows you to rotate a shape added to a slide this way: 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Add an [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) to the slide.
4. Rotate the shape by the needed degrees. 
5. Write the modified presentation as a PPTX file.

This Python code shows you how to rotate a shape by 90 degrees:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Gets the first slide
    sld = pres.slides[0]

    # Adds a rectangle autoshape
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Rotates the shape by 90 degrees
    shp.rotation = 90

    # Writes the PPTX file to disk
    pres.save("RectShpRot_out-7.pptx", slides.export.SaveFormat.PPTX)
```


## **Add 3D Bevel Effects**
Aspose.Slides for Python via .NET allows you to 3D bevel effects to a shape by modifying its [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) properties this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Add an [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) to the slide.
4. Set your preferred parameters for the shape's [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) properties. 
5. Write the presentation to disk.

This Python code shows you how to add 3D bevel effects to a shape:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Creates an instance of the Presentation class
with slides.Presentation() as pres:
    slide = pres.slides[0]

    # Adds a shape tp the slide
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 30, 30, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    format = shape.line_format.fill_format
    format.fill_type = slides.FillType.SOLID
    format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Sets the shape's ThreeDFormat properties
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Writes the presentation as a PPTX file
    pres.save("Bavel_out-8.pptx", slides.export.SaveFormat.PPTX)
```


## **Add 3D Rotation Effect**
Aspose.Slides allows you to apply 3D rotation effects to a shape by modifying its [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) properties this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Add an [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) to the slide.
4. Specify your preferred figures for CameraType and LightType.
5. Write the presentation to disk. 

This Python code shows you how to apply 3D rotation effects to a shape:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Creates an instance of the Presentation class
with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 200, 200)

    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(40, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.LINE, 30, 300, 200, 200)
    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(0, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

            
    pres.save("Rotation_out-9.pptx", slides.export.SaveFormat.PPTX)
```

## **Reset Formatting**

This Python code shows you how to reset the formatting in a slide and revert the position, size and formatting of every shape that has a placeholder on [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) to their defaults:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    for slide in pres.slides:
        # each shape on the slide that has a placeholder on the layout will be reverted
        slide.reset()
```

