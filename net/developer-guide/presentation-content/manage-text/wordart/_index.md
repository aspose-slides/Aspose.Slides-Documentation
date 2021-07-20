---
title: WordArt
type: docs
weight: 231
url: /net/wordart/
---

## **About WordArt?**
WordArt or Word Art is a feature that allows you to apply effects to texts to make them stand out. With WordArt, for example, you can outline a text or fill it with a color (or gradient), add 3D effects to it, etc. You also get to skew, bend, and stretch the shape of a text. 

{{% alert color="primary" %}} 

WordArt allows you to treat a text as you would a graphical object. In general, WordArt consists of effects or special modifications made to texts to make them more attractive or noticeable. 

{{% /alert %}} 

**WordArt in Microsoft PowerPoint**

To use WordArt in Microsoft PowerPoint, you have to select one of the predefined WordArt templates. A WordArt template is a set of effects that gets applied to a text or its shape. 

**WordArt in Aspose.Slides**

In Aspose.Slides for .NET 20.10, we implemented support for WordArt and made improvements to the feature in subsequent Aspose.Slides for .NET releases. 

With Aspose.Slides for .NET, you can easily create your own WordArt template (one effect or combination of effects) in C# and apply it to texts. 

## Creating a Simple WordArt Template and Applying It to a Text

**Using Aspose.Slides** 

First, we create a simple text using this C# code: 

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
Now, we set the text’s font height to a bigger value to make the effect more noticeable through this code:

``` csharp 
FontData fontData = new FontData("Arial Black");
portion.PortionFormat.LatinFont = fontData;
portion.PortionFormat.FontHeight = 36;
```

**Using Microsoft PowerPoint**

Go to the WordArt effects menu in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

From the menu on the right, you can choose a predefined WordArt effect. From the menu on the left, you can specify the settings for a new WordArt. 

These are some of the available parameters or options:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

Here, we apply the SmallGrid pattern color to the text and add a 1-width black text border using this code:

``` csharp 
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
            
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

The resulting text:

![todo:image_alt_text](image-20200930114108-4.png)

## Applying Other WordArt Effects

**Using Microsoft PowerPoint**

From the program’s interface, you can apply these effects to a text, text block, shape, or similar element:

![todo:image_alt_text](image-20200930114129-5.png)

For example, Shadow, Reflection, and Glow effects can be applied to a text; 3D Format and 3D Rotation effects can be applied to a text block; Soft Edges property can be applied to a Shape Object (it still has an effect when no 3D Format property is set). 

### Applying Shadow Effects

Here, we intend to set the properties relating to a text only. We apply the shadow effect to a text using this code in C#:

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

 With PresetShadow, you can apply a shadow for a text (using preset values). 

**Using Microsoft PowerPoint**

In PowerPoint, you can use one type of shadow. Here’s an example:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides actually allows you to apply two types of shadows at once: InnerShadow and PresetShadow.

**Notes:**

- When OuterShadow and PresetShadow are used together, only the OuterShadow effect gets applied. 
- If OuterShadow and InnerShadow get used simultaneously, the resulting or applied effect depends on the PowerPoint version. For instance, in PowerPoint 2013, the effect gets doubled. But in PowerPoint 2007, the OuterShadow effect gets applied. 

### Applying Display to Texts

We add display to the text through this code sample in C#:

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

### Applying Glow Effect to Texts

We apply the glow effect to the text to make it shine or stand out using this code:

``` csharp 
portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

The result of the operation:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

You can change the parameters for shadow, display, and glow. The effects’ properties get set on each portion of the text separately. 

{{% /alert %}} 

### Using Transformations in WordArt

We use the Transform property (inherent in the entire block of text) through this code:
``` csharp 
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

The result:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Both Microsoft PowerPoint and Aspose.Slides for .NET provide a certain number of predefined transformation types. 

{{% /alert %}} 

**Using PowerPoint**

To access predefined transformation types, go through: **Format** -> **TextEffect** -> **Transform**

**Using Aspose.Slides**

To select a transformation type, use the TextShapeType enum. 

### Applying 3D effects to Texts and Shapes

We set a 3D effect to a text shape using this sample code:

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

The resulting text and its shape:

![todo:image_alt_text](image-20200930114816-9.png)

We apply a 3D effect to the text with this C# code:

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

The result of the operation:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

The application of 3D effects to texts or their shapes and interactions between effects are based on certain rules. 

Consider a scene for a text and the shape containing that text. The 3D effect contains 3D object representation and the scene on which the object got placed. 

- When the scene is set for both the figure and the text, the figure scene gets the higher priority—the text scene is ignored. 
- When the figure lacks its own scene but has 3D representation, the text scene is used. 
- Otherwise—when the shape originally has no 3D effect—the shape is flat and the 3D effect only gets applied to the text. 

 These descriptions are connected to the ThreeDFormat.getLightRig() and ThreeDFormat.getCamera() methods.

{{% /alert %}} 

## **Apply Outer Shadow Effects to Texts**
Aspose.Slides for .NET provides the [**IOuterShadow**](https://apireference.aspose.com/net/slides/aspose.slides.effects/ioutershadow) and [**IInnerShadow**](https://apireference.aspose.com/net/slides/aspose.slides.effects/iinnershadow) classes that allow you to apply shadow effects to a text carried by TextFrame. Go through these steps:

<<<<<<< HEAD
```c#
// Instantiate a PPTX class
=======
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
2. Obtain the reference of a slide by using its index.
3. Add an AutoShape of Rectangle type to the slide.
4. Access the TextFrame associated with the AutoShape.
5. Set the FillType of the AutoShape to NoFill.
6. Instantiate OuterShadow class
7. Set the BlurRadius of the shadow.
8. Set the Direction of the shadow
9. Set the Distance of the shadow.
10. Set the RectanglelAlign to TopLeft.
11. Set the PresetColor of the shadow to Black.
12. Write the presentation as a PPTX file.

This sample code in C#—an implementation of the steps above—shows you how to apply the outer shadow effect to a text:

```c#
>>>>>>> master
using (Presentation pres = new Presentation())
{

    // Get reference of the slide
    ISlide sld = pres.Slides[0];

    // Add an AutoShape of Rectangle type
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Add TextFrame to the Rectangle
    ashp.AddTextFrame("Aspose TextBox");

    // Disable shape fill in case we want to get shadow of text
    ashp.FillFormat.FillType = FillType.NoFill;

    // Add outer shadow and set all necessary parameters
    ashp.EffectFormat.EnableOuterShadowEffect();
    IOuterShadow shadow = ashp.EffectFormat.OuterShadowEffect;
    shadow.BlurRadius = 4.0;
    shadow.Direction = 45;
    shadow.Distance = 3;
    shadow.RectangleAlign = RectangleAlignment.TopLeft;
    shadow.ShadowColor.PresetColor = PresetColor.Black;

    //Write the presentation to disk
    pres.Save("pres_out.pptx", SaveFormat.Pptx);
}
```


## **Apply Inner Shadow Effect to Shapes**
Go through these steps:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
2. Get a reference of the slide.
3. Add an AutoShape of the Rectangle type.
4. Enable InnerShadowEffect.
5. Set all the necessary parameters.
6. Set the ColorType as Scheme.
7. Set the Scheme Color.
8. Write the presentation as a [PPTX](https://wiki.fileformat.com/presentation/pptx/) file.

This sample code (based on the steps above) shows you how to add a connector between two shapes in C#:

```c#
<<<<<<< HEAD
// Create an instance of Presentation class
Presentation presentation = new Presentation();
            
// Get reference of a slide
ISlide slide = presentation.Slides[0];
=======
using(Presentation presentation = new Presentation())
{
    // Get reference of a slide
    ISlide slide = presentation.Slides[0];
>>>>>>> master

    // Add an AutoShape of Rectangle type
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.FillFormat.FillType = FillType.NoFill;

    // Add TextFrame to the Rectangle
    ashp.AddTextFrame("Aspose TextBox");
    IPortion port = ashp.TextFrame.Paragraphs[0].Portions[0];
    IPortionFormat pf = port.PortionFormat;
    pf.FontHeight = 50;

    // Enable InnerShadowEffect    
    IEffectFormat ef = pf.EffectFormat;
    ef.EnableInnerShadowEffect();

    // Set all necessary parameters
    ef.InnerShadowEffect.BlurRadius = 8.0;
    ef.InnerShadowEffect.Direction = 90.0F;
    ef.InnerShadowEffect.Distance = 6.0;
    ef.InnerShadowEffect.ShadowColor.B = 189;

    // Set ColorType as Scheme
    ef.InnerShadowEffect.ShadowColor.ColorType = ColorType.Scheme;

    // Set Scheme Color
    ef.InnerShadowEffect.ShadowColor.SchemeColor = SchemeColor.Accent1;

<<<<<<< HEAD
// Save Presentation
presentation.Save("WordArt_out.pptx", SaveFormat.Pptx);
=======
    // Save Presentation
    presentation.Save("WordArt_out.pptx", SaveFormat.Pptx);
}
>>>>>>> master
```

