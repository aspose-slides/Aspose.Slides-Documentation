---
title: Format PowerPoint Shapes in Python
linktitle: Shape Formatting
type: docs
weight: 20
url: /python-net/shape-formatting/
keywords:
- format shape
- format line
- format join style
- gradient fill
- pattern fill
- picture fill
- texture fill
- solid color fill
- shape transparency
- rotate shape
- 3d bevel effect
- 3d rotation effect
- reset formatting
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Learn how to format PowerPoint shapes in Python using Aspose.Slides—set fill, line, and effect styles for PPT, PPTX, and ODP files with precision and full control."
---

## **Overview**

In PowerPoint, you can add shapes to slides. Since shapes are made up of lines, you can format them by modifying or applying effects to their outlines. Additionally, you can format shapes by specifying settings that control how their interiors are filled.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python provides classes and properties that allow you to format shapes using the same options available in PowerPoint.

## **Format Lines**

Using Aspose.Slides, you can specify a custom line style for a shape. The following steps outline the procedure:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) to the slide.
1. Set the [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) of the shape.
1. Set the line width.
1. Set the [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) of the shape.
1. Set the line color for the shape.
1. Save the modified presentation as a PPTX file.

The following Python code demonstrates how to format a rectangle `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of the Rectangle type.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Set the fill color for the rectangle shape.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Apply formatting to the rectangle's lines.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Set the color for the rectangle's line.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Save the PPTX file to disk.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The formatted lines in the presentation](formatted-lines.png)

## **Format Join Styles**

Here are the three join type options:

* Round
* Miter
* Bevel

By default, when PowerPoint joins two lines at an angle (such as at a shape’s corner), it uses the **Round** setting. However, if you're drawing a shape with sharp angles, you may prefer the **Miter** option.

![The join style in the presentation](join-style-powerpoint.png)

The following Python code demonstrates how three rectangles (as shown in the image above) were created using the Miter, Bevel, and Round join type settings:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:

	# Get the first slide.
	slide = presentation.slides[0]

	# Add three auto shapes of the Rectangle type.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Set the fill color for each rectangle shape.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Set the line width.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Set the color for each rectangle's line.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Set the join style.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Add text to each rectangle.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Save the PPTX file to disk.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Gradient Fill**

In PowerPoint, Gradient Fill is a formatting option that allows you to apply a continuous blend of colors to a shape. For example, you can apply two or more colors in a way that one gradually fades into another.

Here’s how to apply a gradient fill to a shape using Aspose.Slides:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) to the slide.
1. Set the shape's [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) to `GRADIENT`.
1. Add your two preferred colors with defined positions using the `add` methods of the `gradient_stops` collection exposed by the [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) class.
1. Save the modified presentation as a PPTX file.

The following Python code demonstrates how to apply a gradient fill effect to an ellipse:

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of the Ellipse type.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Apply gradient formatting to the ellipse.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Set the direction of the gradient.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Add two gradient stops.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Save the PPTX file to disk.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The ellipse with gradient fill](gradient-fill.png)

## **Pattern Fill**

In PowerPoint, Pattern Fill is a formatting option that lets you apply a two-color design—such as dots, stripes, crosshatches, or checks—to a shape. You can choose custom colors for the pattern’s foreground and background.

Aspose.Slides provides over 45 predefined pattern styles that you can apply to shapes to enhance the visual appeal of your presentations. Even after selecting a predefined pattern, you can still specify the exact colors it should use.

Here's how to apply a pattern fill to a shape using Aspose.Slides:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) to the slide.
1. Set the shape’s [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) to `PATTERN`.
1. Choose a pattern style from the predefined options.
1. Set the [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) of the pattern.
1. Set the [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) of the pattern.
1. Save the modified presentation as a PPTX file.

The following Python code demonstrates how to apply a pattern fill to a rectangle:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of the Rectangle type.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Set the fill type to Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Set the pattern style.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Set the pattern background and foreground colors.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Save the PPTX file to disk.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The rectangle with pattern fill](pattern-fill.png)

## **Picture Fill**

In PowerPoint, Picture Fill is a formatting option that allows you to insert an image inside a shape—effectively using the image as the shape's background.

Here’s how to use Aspose.Slides to apply a picture fill to a shape:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) to the slide.
1. Set the shape's [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) to `PICTURE`.
1. Set the picture fill mode to `TILE` (or another preferred mode).
1. Create an [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) object from the image you want to use.
1. Assign this image to the `picture.image` property of the shape’s `picture_fill_format`.
1. Save the modified presentation as a PPTX file.

Let's say we have a "lotus.png" file with the following picture:

![The lotus picture](lotus.png)

The following Python code demonstrates how to fill a shape with the picture:

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of the Rectangle type.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Set the fill type to Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Set the picture fill mode.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Load an image and add it to the presentation resources.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Set the picture.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Save the PPTX file to disk.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

If you want to set a tiled picture as a texture and customize the tiling behavior, you can use the following properties of the [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) class:

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Sets the picture fill mode—either `TILE` or `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Specifies the alignment of the tiles within the shape.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Controls whether the tile is flipped horizontally, vertically, or both.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Sets the horizontal offset of the tile (in points) from the shape’s origin.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Sets the vertical offset of the tile (in points) from the shape’s origin.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Defines the horizontal scale of the tile as a percentage.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Defines the vertical scale of the tile as a percentage.

The following code sample shows how to add a rectangle shape with a tiled picture fill and configure tile options:

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:

    # Get the first slide.
    first_slide = presentation.slides[0]

    # Add a rectangle auto shape.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Set the fill type of the shape to Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Load the image and add it to the presentation resources.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Assign the image to the shape.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Configure the picture fill mode and tiling properties.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Save the PPTX file to disk.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The tile options](tile-options.png)

## **Solid Color Fill**

In PowerPoint, Solid Color Fill is a formatting option that fills a shape with a single, uniform color. This plain background color is applied without any gradients, textures, or patterns.

To apply a solid color fill to a shape using Aspose.Slides, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) to the slide.
1. Set the shape’s [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) to `SOLID`.
1. Assign your preferred fill color to the shape.
1. Save the modified presentation as a PPTX file.

The following Python code demonstrates how to apply a solid color fill to a rectangle in a PowerPoint slide:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of the Rectangle type.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Set the fill type to Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Set the fill color.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Save the PPTX file to disk.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The shape with solid color fill](solid-color-fill.png)

## **Set Transparency**

In PowerPoint, when you apply a solid color, gradient, picture, or texture fill to shapes, you can also set a transparency level to control the opacity of the fill. A higher transparency value makes the shape more see-through, allowing the background or underlying objects to be partially visible.

Aspose.Slides lets you set the transparency level by adjusting the alpha value in the color used for the fill. Here’s how to do it:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) to the slide.
1. Set the fill type to `SOLID`.
1. Use `Color.from_argb` to define a color with transparency (the `alpha` component controls transparency).
1. Save the presentation.

The following Python code demonstrates how to apply a transparent fill color to a rectangle:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]
    
    # Add a solid rectangle auto shape.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Add a transparent rectangle auto shape over the solid shape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The transparent shape](shape-transparency.png)

## **Rotate Shapes**

Aspose.Slides lets you rotate shapes in PowerPoint presentations. This can be useful when positioning visual elements with specific alignment or design needs.

To rotate a shape on a slide, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) to the slide.
1. Set the shape’s `rotation` property to the desired angle.
1. Save the presentation.

The following Python code demonstrates how to rotate a shape by 5 degrees:

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of the Rectangle type.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Rotate the shape by 5 degrees.
    shape.rotation = 5

    # Save the PPTX file to disk.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The shape rotation](shape-rotation.png)

## **Add 3D Bevel Effects**

Aspose.Slides allows you to apply 3D bevel effects to shapes by configuring their [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) properties.

To add 3D bevel effects to a shape, follow these steps:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) to the slide.
1. Configure the shape’s [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) to define bevel settings.
1. Save the presentation.

The following Python code shows how to apply 3D bevel effects to a shape:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Add a shape to the slide.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Set the shape's ThreeDFormat properties.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Save the presentation as a PPTX file.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The 3D bevel effect](3D-bevel-effect.png)

## **Add 3D Rotation Effects**

Aspose.Slides allows you to apply 3D rotation effects to shapes by configuring their [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) properties.

To apply 3D rotation to a shape:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) to the slide.
1. Set the shape's [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) and [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) to define the 3D rotation.
1. Save the presentation.

The following Python code demonstrates how to apply 3D rotation effects to a shape:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Save the presentation as a PPTX file.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The 3D rotation effect](3D-rotation-effect.png)

## **Reset Formatting**

The following Python code shows how to reset the formatting of a slide and revert the position, size, and formatting of all shapes with placeholders on the [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) to their default settings:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Reset each shape on the slide that has a placeholder on the layout.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Does shape formatting affect the final presentation file size?**

Only minimally. Embedded images and media occupy most of the file space, while shape parameters such as colors, effects, and gradients are stored as metadata and add virtually no extra size.

**How can I detect shapes on a slide that share identical formatting so I can group them?**

Compare each shape’s key formatting properties—fill, line, and effect settings. If all corresponding values match, treat their styles as identical and logically group those shapes, which simplifies later style management.

**Can I save a set of custom shape styles to a separate file for reuse in other presentations?**

Yes. Store sample shapes with the desired styles in a template slide deck or a .POTX template file. When creating a new presentation, open the template, clone the styled shapes you need, and re‑apply their formatting wherever required.
