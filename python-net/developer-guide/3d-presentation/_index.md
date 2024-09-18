---
title: 3D Presentation
type: docs
weight: 232
url: /python-net/3d-presentation/
keywords:
- 3D
- 3D PowerPoint
- 3D presentation
- 3D rotation
- 3D depth
- 3D extrusion
- 3D gradient
- 3D text
- PowerPoint presentation
- Python
- Aspose.Slides for Python via .NET
description: "3D PowerPoint presentation in Python"
---


## Overview
How do you usually create a 3D PowerPoint presentation?
Microsoft PowerPoint enables to create 3D presentations in terms that we may add 3D models there, apply 3D effects on shapes, 
create 3D text, upload 3D graphics into presentation, create PowerPoint 3D animations. 

Creating 3D effects makes a big impact into improving your presentation to a 3D presentation, and may be the easiest implementation of 3D presentation. 
Since Aspose.Slides 20.9 version, a new **cross-platform 3D engine** has been added. The new 3D engine enables 
to export and rasterize shapes and text with 3D effects. In the previous versions, 
Slides shapes with 3D effects applied, had been rendered flat. But, now it’s possible to 
render shapes with a **full-fledged 3D**.
Moreover, now it’s possible to create shapes with 3D effects via Slides public API.

In Aspose.Slides API, to make 
a shape become a PowerPoint 3D shape use [IShape.ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) property, 
which inherits the features of [IThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat) interface:
- [BevelBottom](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
and [BevelTop](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): set bevel to the shape, define bevel type (e.g. Angle, Circle, SoftRound), define height and width of bevel.
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): is used to imitate camera movements around the object. In other words, by setting came rotation, zoom and other properties - you may entertain with your 
shapes as with the 3D model in PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
and [ContourWidth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): set contour properties to make the shape look like 3D PowerPoint shape.
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/), 
[extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
and [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): are used to make the shape three-dimension, which means to convert a 2D shape into a 3D shape, 
by setting its depth or extrusing it.
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): can create a light effect on a 3D shape. The logic of this property is closed to Camera, you can set the rotation of the light 
in relation to the #D shape and choose the light type.
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): setting the type of 3D shape material can bring more alive effect into it. The property provides a set of predefined materials, like: 
Metal, Plastic, Powder, Matte, etc.  

All 3D features can be applied to both shapes and text. Let us see how to access the properties mentioned above and then look on them in details step by step:
```py 
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")

    presentation.save("sandbox_3d.pptx", slides.export.SaveFormat.PPTX)
```

The rendered thumbnail looks like that:

![todo:image_alt_text](img_01_01.png)

## 3D Rotation
It's possible to rotate PowerPoint 3D shapes in 3D plane, which brings more interactivity. To rotate 3D shape in PowerPoint, you usually use the following menu:

![todo:image_alt_text](img_02_01.png)

In Aspose.Slides API 3D shape rotation can be managed using [camera](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) property:

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... set other 3D scene parameters

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## 3D Depth and Extrusion
To bring the third dimension to your shape and make it a 3D shape, use [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
and [extrusion_color.color](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) properties:

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... set other 3D scene parameters

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

Usually, you use Depth menu in PowerPoint to set Depth for PowerPoint 3D shape:

![todo:image_alt_text](img_02_02.png)


## 3D Gradient
Gradient can be used to fill the color of PowerPoint 3D shape. Let us create a shape with gradient fill color and apply a 3D effect on it:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)
   
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

And here is the result:

![todo:image_alt_text](img_02_03.png)

Except a gradient fill color, its possible to fill shapes with an image:
```py
with open("image.png", "rb") as image_file: 
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... setup 3D: shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion* properties

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```


That's how it looks like:

![todo:image_alt_text](img_02_04.png)

## 3D Text (WordArt)
Aspose.Slides allows to apply 3D on text too. For creating a 3D text its possible to use WordArt transform effect:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D text"
   
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID
   
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128
   
    text_frame_format = shape.text_frame.text_frame_format
    # setup "Arch Up" WordArt transform effect
    text_frame_format.transform = slides.TextShapeType.ARCH_UP

    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text3d.png")

    presentation.save("text3d.pptx", slides.export.SaveFormat.PPTX)
```

Here is the result:

![todo:image_alt_text](img_02_05.png)


## Not Supported - Coming Soon
The following PowerPoint 3D features are not supported yet: 
- Bevel
- Material
- Contour
- Lighting

We continue to improve our 3D Engine, and these features are the subject of further implementation.

 

