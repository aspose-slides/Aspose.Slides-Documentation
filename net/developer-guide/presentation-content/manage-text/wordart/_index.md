---
title: WordArt
type: docs
weight: 231
url: /net/wordart/
---

## **WordArt API**
WordArt is any kind of effect that changes the visual appearance of the text. Here are some of the effects, that can be applied to the text as a WordArt: 
shadows, outlines, colors, gradients, curved style, 3D effects and others. Skewing, bending, stretching the shape of the text can be also called a WordArt.
WordArt effects are not a limited list of effects, but an approach of modifying regular text to make it more attractive for users.

Microsoft has added support of WordArt as a text modifying feature to Office products, giving a life to it for all PowerPoint presentation formats.

Aspose.Slides API supports WordArt since 20.10 version. In PowerPoint, you usually choose one of the predefined WordArt templates, which is a set of effects 
applied to the text or its shapes.
In Aspose.Slides, it is possible to create your own WordArt programmatically, combining any effects altogether. Let us create a new WordArt with Aspose.Slides for .NET, 
comparing each step with the same step in PowerPoint.We will start with the simplest example and move to the most complicated way of displaying text.

First, let's create a simple text:

``` csharp 
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    Portion portion = (Portion)textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```
Set text font height bigger to make the future effect more visible:

``` csharp 
FontData fontData = new FontData("Arial Black");
portion.PortionFormat.LatinFont = fontData;
portion.PortionFormat.FontHeight = 36;
```

This is how WordArt effects menu looks in PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)


On the right, its possible to choose a ready-made WordArt effect. On the left side you can set settings for creating a new WordArt effect. 
WordArt API in Aspose.Slides is not a set of ready-made solutions, but a way to create your own WordArt. 
Therefore, you need to operate the low-lever part of the PowerPoint "WordArt Styles" menu:

![todo:image_alt_text](image-20200930114015-3.png)

Let us set the “SmallGrid” pattern color to the text and a 1-width black text border:

``` csharp 
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
            
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Here is a resulting text:

![todo:image_alt_text](image-20200930114108-4.png)

Now let's take a look on the effects that can be applied to the text via PowerPoint UI:

![todo:image_alt_text](image-20200930114129-5.png)

On the low level, the effect above may be applied to text, text block, shape or other element. For example, Shadow, Reflection and Glow effects are applied to the text. 
3D Format and 3D Rotation effects are applied to the text block. Soft Edges property is usually applied to a Shape object 
(Note: it has an effect when none of the 3D Format properties are set).

Let us set the properties that relate to the text only. Set shadow effect to the text:

``` csharp 
portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 65;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4.73;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 2;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

Aspose.Slides API supports three types of shadows: OuterShadow, InnerShadow, and PresetShadow. 
With PresetShadow you may set shadow for the text, using preset values. In PowerPoint you usually use one type of shadow only, 
however in Aspsoe.Slides API it is possible to set two types of shadows at once: InnerShadow and PresetShadow. 

Here is an example:

![todo:image_alt_text](image-20200930114225-6.png)

Note, if OuterShadow and PresetShadow are set together, only OuterShadow effect will be applied. 
While using OuterShadow and InnerShadow simultaneously, the effect applied will depend on the version of PowerPoint. 
For PowerPoint 2013 the effect will double, for 2007 - OuterShadow will be applied.

Let's try to add display to the text:

``` csharp 
portion.PortionFormat.EffectFormat.EnableReflectionEffect();
portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5; 
portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72; 
portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f; 
portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f; 
portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90; 
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100; 
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;   
```  
 
Set glow effect to the text, to make it shine:

``` csharp 
portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```  

Here is the result:

![todo:image_alt_text](image-20200930114621-7.png)

You may change the parameters of shadow, display and glow in your way. Note, that the effect properties are set on each text portion separately.

Let's set Transform property, that is inherent in the entire block of text:
``` csharp 
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

The result is the following:

![todo:image_alt_text](image-20200930114712-8.png)

Both PowerPoint and Aspose.Slides API have a number of predefined transformation types. 
In PowerPoint, you may see them via such menu: Format-> TextEffect-> Transform. In Aspose.Slides, you may use TextShapeType enum to choose them.

Let's move on to 3D effects for the text and its shape. Let's set a 3D effect to the text shape:

``` csharp 
autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelTop.Height = 12.5;
autoShape.ThreeDFormat.BevelTop.Width = 11;

autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
autoShape.ThreeDFormat.ExtrusionHeight = 6;

autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
autoShape.ThreeDFormat.ContourWidth = 1.5;

autoShape.ThreeDFormat.Depth = 3;

autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

The resulting effect will look like the following:

![todo:image_alt_text](image-20200930114816-9.png)

Now let's apply 3D effect to the text:

``` csharp 
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Now, the resulting WordArt will look this way:

![todo:image_alt_text](image-20200930114905-10.png)

Note, that 3D effects have some specific rules how they are applied to the text and its shapes, as well as the way they affect each other with other effects.
For example, there is a scene for the text and the shape containing it. 
3D effect contains object 3D representation and the scene on which this object is placed.  
If the scene is set for both the figure and the text, 
the figure scene will have a higher priority (i.e. the text scene will be ignored). 
If the figure does not have its own scene, 
but have 3D representation - the text scene will be used. Otherwise (when the shape has no 3D effect at all), the shape will be flat and the 
3D effect will only be applied to the text. Please note that the scene is related to the ThreeDFormat.getLightRig() 
and ThreeDFormat.getCamera() methods.



Aspose.Slides for .NET provides 
[**IOuterShadow**](https://apireference.aspose.com/net/slides/aspose.slides.effects/ioutershadow) and
 [**IInnerShadow**](https://apireference.aspose.com/net/slides/aspose.slides.effects/iinnershadow) classes 
 in order to apply shadow effects on the text carried by TextFrame. These classes are available in the [**Aspose.Slides.Effects**](https://apireference.aspose.com/net/slides/aspose.slides.effects/) namespace and provides a number of properties for handling the shadow effects.
## **Apply Outer Shadow to WordArt**
Please follow the steps below to apply shadow effects on the text in a [PPTX](https://wiki.fileformat.com/presentation/pptx/) presentation using Aspose.Slides for .NET :

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Rectangle type to the slide.
- Access the TextFrame associated with the AutoShape.
- Set the FillType of the AutoShape to NoFill.
- Instantiate OuterShadow class
- Set the BlurRadius of the shadow.
- Set the Direction of the shadow
- Set the Distance of the shadow.
- Set the RectanglelAlign to TopLeft.
- Set the PresetColor of the shadow to Black.
- Write the presentation as a PPTX file.

The implementation of the above steps is given below.



{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-ShadowEffects-ShadowEffects.cs" >}}
## **Apply Inner Shadow to WordArt**
Aspose.Slides for .NET could be used to apply WordArt Effects on Text. Every WordArt effect has a scheme, for example Accent1, Accent3. In this topic, we will see with examples for how to work with WordArt in Aspose.Slides. In order to apply the scheme of any WordArt. Please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Get reference of a slide.
- Add an AutoShape of Rectangle type.
- Enable InnerShadowEffect.
- Set all necessary parameters.
- Set ColorType as Scheme.
- Set Scheme Color.
- Write the presentation as a [PPTX](https://wiki.fileformat.com/presentation/pptx/) file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-ApplyOuterShadow-ApplyOuterShadow.cs" >}}
