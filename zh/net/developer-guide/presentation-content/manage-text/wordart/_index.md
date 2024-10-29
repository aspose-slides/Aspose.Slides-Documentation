---
title: WordArt
type: docs
weight: 110
url: /zh/net/wordart/
keywords: "WordArt, Word Art, 创建 WordArt, WordArt 模板, WordArt 效果, 阴影效果, 显示效果, 发光效果, WordArt 变换, 3D 效果, 外部阴影效果, 内部阴影效果, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 Aspose.Slides for .NET 中添加、操作和管理 PowerPoint 演示文稿中的 WordArt 和效果"
---

## **关于 WordArt?**
WordArt 或 Word Art 是一项功能，允许您对文本应用效果，使其更突出。例如，使用 WordArt，您可以勾勒出文本或用颜色（或渐变）填充它，为其添加 3D 效果等。您还可以扭曲、弯曲和拉伸文本形状。 

{{% alert color="primary" %}} 

WordArt 允许您将文本视为图形对象。WordArt 由对文本进行的效果或特殊修改组成，以使其更具吸引力或更醒目。 

{{% /alert %}} 

**Microsoft PowerPoint 中的 WordArt**

要在 Microsoft PowerPoint 中使用 WordArt，您必须选择预定义的 WordArt 模板之一。WordArt 模板是一组应用于文本或其形状的效果。 

**Aspose.Slides 中的 WordArt**

在 Aspose.Slides for .NET 20.10 中，我们实现了对 WordArt 的支持，并在随后的 Aspose.Slides for .NET 版本中对该功能进行了改进。 

使用 Aspose.Slides for .NET，您可以轻松在 C# 中创建自己的 WordArt 模板（一个效果或效果组合）并应用于文本。 

## 创建简单的 WordArt 模板并将其应用于文本

**使用 Aspose.Slides** 

首先，我们使用以下 C# 代码创建简单文本： 

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
现在，我们通过以下代码将文本的字体高度设置为更大的值，以使效果更明显：

``` csharp 
FontData fontData = new FontData("Arial Black");
portion.PortionFormat.LatinFont = fontData;
portion.PortionFormat.FontHeight = 36;
```

**使用 Microsoft PowerPoint**

在 Microsoft PowerPoint 中转到 WordArt 效果菜单：

![todo:image_alt_text](image-20200930113926-1.png)

在右侧菜单中，您可以选择预定义的 WordArt 效果。在左侧菜单中，您可以指定新的 WordArt 设置。 

以下是一些可用的参数或选项：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

在这里，我们将 SmallGrid 图案颜色应用于文本，并使用以下代码添加 1 像素宽的黑色文本边框：

``` csharp 
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
            
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

结果文本：

![todo:image_alt_text](image-20200930114108-4.png)

## 应用其他 WordArt 效果

**使用 Microsoft PowerPoint**

从程序界面，您可以将这些效果应用于文本、文本块、形状或类似元素：

![todo:image_alt_text](image-20200930114129-5.png)

例如，阴影、反射和发光效果可以应用于文本；3D 格式和 3D 旋转效果可以应用于文本块；软边缘属性可以应用于形状对象（在未设置 3D 格式属性时，仍然有效）。 

### 应用阴影效果

在这里，我们打算仅设置与文本相关的属性。我们使用以下 C# 代码将阴影效果应用于文本：

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

Aspose.Slides API 支持三种类型的阴影：OuterShadow、InnerShadow 和 PresetShadow。 

 使用 PresetShadow，您可以为文本应用阴影（使用预设值）。 

**使用 Microsoft PowerPoint**

在 PowerPoint 中，您可以使用一种类型的阴影。以下是一个示例：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 实际上允许您同时应用两种类型的阴影：InnerShadow 和 PresetShadow。

**注意：**

- 当同时使用 OuterShadow 和 PresetShadow 时，仅应用 OuterShadow 效果。 
- 如果同时使用 OuterShadow 和 InnerShadow，则结果或应用效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果会加倍。但在 PowerPoint 2007 中，应用的是 OuterShadow 效果。 

### 将显示应用于文本

我们通过以下 C# 示例代码为文本添加显示：

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

### 为文本应用发光效果

我们使用以下代码将发光效果应用于文本，使其闪亮或突出：

``` csharp 
portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

操作的结果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

您可以更改阴影、显示和发光的参数。效果的属性会单独设置在文本的每个部分上。 

{{% /alert %}} 

### 在 WordArt 中使用变换

我们通过以下代码使用文本块的 Transform 属性：
``` csharp 
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

结果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint 和 Aspose.Slides for .NET 都提供了一定数量的预定义变换类型。 

{{% /alert %}} 

**使用 PowerPoint**

要访问预定义的变换类型，请转到： **格式** -> **文本效果** -> **变换**

**使用 Aspose.Slides**

要选择变换类型，请使用 TextShapeType 枚举。 

### 为文本和形状应用 3D 效果

我们使用以下示例代码为文本形状设置 3D 效果：

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

结果文本及其形状：

![todo:image_alt_text](image-20200930114816-9.png)

我们使用以下 C# 代码为文本应用 3D 效果：

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

操作的结果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

将 3D 效果应用于文本或其形状以及效果之间的相互作用基于某些规则。 

考虑一个文本的场景和包含该文本的形状。3D 效果包含 3D 对象表示和放置对象的场景。 

- 当为形状和文本都设置场景时，形状场景具有更高的优先级——文本场景将被忽略。 
- 当形状没有自己的场景但有 3D 表示时，将使用文本场景。 
- 否则——当形状原本没有 3D 效果时——形状是平面的，而 3D 效果仅应用于文本。 

这些描述与 [ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/properties/lightrig) 和 [ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/properties/camera) 属性相关。

{{% /alert %}} 

## **将外部阴影效果应用于文本**
Aspose.Slides for .NET 提供 [**IOuterShadow**](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow) 和 [**IInnerShadow**](https://reference.aspose.com/slides/net/aspose.slides.effects/iinnershadow) 类，允许您对由 TextFrame 支持的文本应用阴影效果。遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 使用其索引获取幻灯片的引用。
3. 向幻灯片添加一个矩形类型的 AutoShape。
4. 访问与 AutoShape 关联的 TextFrame。
5. 将 AutoShape 的 FillType 设置为 NoFill。
6. 实例化 OuterShadow 类
7. 设置阴影的 BlurRadius。
8. 设置阴影的 Direction。
9. 设置阴影的 Distance。
10. 将 RectangleAlign 设置为 TopLeft。
11. 将阴影的 PresetColor 设置为黑色。
12. 将演示文稿写为 PPTX 文件。

以下 C# 示例代码展示了如何对文本应用外部阴影效果：

```c#
using (Presentation pres = new Presentation())
{

    // 获取幻灯片的引用
    ISlide sld = pres.Slides[0];

    // 添加一个矩形类型的 AutoShape
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 向矩形添加 TextFrame
    ashp.AddTextFrame("Aspose TextBox");

    // 禁用形状填充以获取文本阴影
    ashp.FillFormat.FillType = FillType.NoFill;

    // 添加外部阴影并设置所有必要参数
    ashp.EffectFormat.EnableOuterShadowEffect();
    IOuterShadow shadow = ashp.EffectFormat.OuterShadowEffect;
    shadow.BlurRadius = 4.0;
    shadow.Direction = 45;
    shadow.Distance = 3;
    shadow.RectangleAlign = RectangleAlignment.TopLeft;
    shadow.ShadowColor.PresetColor = PresetColor.Black;

    //将演示文稿写入磁盘
    pres.Save("pres_out.pptx", SaveFormat.Pptx);
}
```


## **为形状应用内部阴影效果**
请遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 获取幻灯片的引用。
3. 添加一个矩形类型的 AutoShape。
4. 启用 InnerShadowEffect。
5. 设置所有必要的参数。
6. 将 ColorType 设置为 Scheme。
7. 设置 Scheme 颜色。
8. 将演示文稿写为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以下示例代码（基于上述步骤）展示了如何在 C# 中添加两个形状之间的连接器：

```c#
using(Presentation presentation = new Presentation())
{
    // 获取幻灯片的引用
    ISlide slide = presentation.Slides[0];

    // 添加一个矩形类型的 AutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.FillFormat.FillType = FillType.NoFill;

    // 向矩形添加 TextFrame
    ashp.AddTextFrame("Aspose TextBox");
    IPortion port = ashp.TextFrame.Paragraphs[0].Portions[0];
    IPortionFormat pf = port.PortionFormat;
    pf.FontHeight = 50;

    // 启用 InnerShadowEffect    
    IEffectFormat ef = pf.EffectFormat;
    ef.EnableInnerShadowEffect();

    // 设置所有必要参数
    ef.InnerShadowEffect.BlurRadius = 8.0;
    ef.InnerShadowEffect.Direction = 90.0F;
    ef.InnerShadowEffect.Distance = 6.0;
    ef.InnerShadowEffect.ShadowColor.B = 189;

    // 将 ColorType 设置为 Scheme
    ef.InnerShadowEffect.ShadowColor.ColorType = ColorType.Scheme;

    // 设置 Scheme 颜色
    ef.InnerShadowEffect.ShadowColor.SchemeColor = SchemeColor.Accent1;

    // 保存演示文稿
    presentation.Save("WordArt_out.pptx", SaveFormat.Pptx);
}
```