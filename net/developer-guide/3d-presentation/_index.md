---
title: 3D Presentation
type: docs
weight: 232
url: /net/3d-presentation/
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
a shape become a PowerPoint 3D shape use [IShape.ThreeDFormat](https://apireference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) property, 
which inherits the features of [IThreeDFormat](https://apireference.aspose.com/slides/net/aspose.slides/ithreedformat) interface:
- [BevelBottom](https://apireference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) 
and [BevelTop](https://apireference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): set bevel to the shape, define bevel type (e.g. Angle, Circle, SoftRound), define height and width of bevel.
- [Camera](https://apireference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): is used to imitate camera movements around the object. In other words, by setting came rotation, zoom and other properties - you may entertain with your 
shapes as with the 3D model in PowerPoint.
- [ContourColor](https://apireference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) 
and [ContourWidth](https://apireference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): set contour properties to make the shape look like 3D PowerPoint shape.
- [Depth](https://apireference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth), 
[ExtrusionColor](https://apireference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 
and [ExtrusionHeight](https://apireference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): are used to make the shape three-dimension, which means to convert a 2D shape into a 3D shape, 
by setting its depth or extrusing it.
- [LightRig](https://apireference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): can create a light effect on a 3D shape. The logic of this property is closed to Camera, you can set the rotation of the light 
in relation to the #D shape and choose the light type.
- [Material](https://apireference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): setting the type of 3D shape material can bring more alive effect into it. The property provides a set of predefined materials, like: 
Metal, Plastic, Powder, Matte, etc.  

All 3D features can be applied to both shapes and text. Let us see how to access the properties mentioned above and then look on them in details step by step:
``` csharp 
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.TextFrame.Text = "3D";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;
    
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.Material = MaterialPresetType.Powder; 
    shape.ThreeDFormat.ExtrusionHeight = 100;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;
    
    pres.Slides[0].GetThumbnail(2, 2).Save("sample_3d.png");
    pres.Save("sandbox_3d.pptx", SaveFormat.Pptx);
}
```

The rendered thumbnail looks like that:

![todo:image_alt_text](img_01_01.png)

## 3D Rotation
It's possible to rotate PowerPoint 3D shapes in 3D plane, which brings more interactivity. To rotate 3В shape in PowerPoint, you usually use the following menu:

![todo:image_alt_text](img_02_01.png)

In Aspose.Slides API 3D shape rotation can be managed using [IThreeDFormat.Camera](https://apireference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) property:

``` csharp
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... set other 3D scene parameters
pres.Slides[0].GetThumbnail(2, 2).Save("sample_3d.png");
```

## 3D Depth and Extrusion
To bring the third dimension to your shape and make it a 3D shape, use [IThreeDFormat.ExtrusionHeight](https://apireference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 
and [IThreeDFormat.ExtrusionColor.Color](https://apireference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) properties:

``` csharp
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... set other 3D scene parameters
pres.Slides[0].GetThumbnail(2, 2).Save("sample_3d.png");
```

Usually, you use Depth menu in PowerPoint to set Depth for PowerPoint 3D shape:

![todo:image_alt_text](img_02_02.png)


## 3D Gradient
Gradient can be used to fill the color of PowerPoint 3D shape. Let us create a shape with gradient fill color and apply a 3D effect on it:

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.TextFrame.Text = "3D Gradient";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
    shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);
   
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.ExtrusionHeight = 150;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
   
    pres.Slides[0].GetThumbnail(2, 2).Save("sample_3d.png");
}
```

And here is the result:

![todo:image_alt_text](img_02_03.png)
  
Except a gradient fill color, its possible to fill shapes with an image:
``` csharp
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = pres.Images.AddImage(File.ReadAllBytes("image.jpg"));
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// .. setup 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* properties
pres.Slides[0].GetThumbnail(2, 2).Save("sample_3d.png");
```


That's how it looks like:

![todo:image_alt_text](img_02_04.png)

## 3D Text (WordArt)
Aspose.Slides allows to apply 3D on text too. For creating a 3D text its possible to use WordArt transform effect:

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.TextFrame.Text = "3D Text";
   
    Portion portion = (Portion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;
   
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;
   
    ITextFrame textFrame = shape.TextFrame;
    // setup "Arch Up" WordArt transform effect
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUp;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
    textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;
    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
   
    pres.Slides[0].GetThumbnail(2, 2).Save("text3d.png");
    pres.Save("text3d.pptx", SaveFormat.Pptx);
}
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

 

