---
title: 在 .NET 中对演示文稿应用形状效果
linktitle: 形状效果
type: docs
weight: 30
url: /zh/net/shape-effect
keywords:
- 形状效果
- 阴影效果
- 反射效果
- 光晕效果
- 柔和边缘效果
- 效果格式
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 对 PPT 和 PPTX 文件进行高级形状效果转换——在几秒钟内创建引人注目、专业的幻灯片。"
---

## **概述**

虽然 PowerPoint 中的效果可以使形状突出，但它们不同于 [填充](/slides/zh/net/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的倒影、扩散形状的光晕等。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

PowerPoint 提供了六种可应用于形状的效果。您可以对一个形状应用一种或多种效果。

某些效果组合看起来比其他组合更好。为此，PowerPoint 在 **Preset** 下提供了选项。Preset 选项本质上是已知的、外观良好的两种或多种效果组合。通过选择预设，您无需花时间测试或组合不同的效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) 类下提供属性和方法，允许您在 PowerPoint 演示文稿的形状上应用相同的效果。

## **应用阴影效果**

要在 Aspose.Slides for .NET 中对形状应用阴影效果，您可以轻松调整颜色、模糊半径和方向等参数。这会使您的形状更具动态感和专业外观，增加深度和焦点。通过简单的代码片段，您可以在多个形状上应用这些效果，提升演示文稿的整体视觉吸引力。

以下 C# 代码演示如何对矩形应用 [外部阴影效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/)：
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```


![Shadow effect](shadow_effect.png)

## **应用反射效果**

要在 Aspose.Slides for .NET 中应用反射效果，您可以为形状添加镜面反射，并调整距离、透明度和大小等参数。此效果通过为形状提供更精致、专业的外观来提升演示文稿的美感。使用简单的代码即可实现，能够快速在多个元素上统一应用，保持一致的设计风格。

以下 C# 代码演示如何对形状应用 [反射效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/)：
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```


![Reflection effect](reflection_effect.png)

## **应用光晕效果**

要在 Aspose.Slides for .NET 中对形状应用光晕效果，您可以在形状周围添加柔和、发光的光环，并调整颜色和大小等属性。此效果帮助形状突出，并为您的演示文稿增添吸引眼球的视觉元素。实现简单，代码量少，可提升幻灯片的整体外观。

以下 C# 代码演示如何对形状应用 [光晕效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/)：
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```


![Glow effect](glow_effect.png)

## **应用柔和边缘效果**

要在 Aspose.Slides for .NET 中应用柔和边缘效果，您可以在形状的边缘创建平滑、模糊的过渡。此效果为设计增添更细腻、精致的外观，非常适合需要柔和外观的设计。您可以轻松调整半径等参数，以在演示文稿的各种形状上实现所需效果。

以下 C# 代码演示如何对形状应用 [柔和边缘](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/)：
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```


![Soft edges effect](soft_edges_effect.png)

## **常见问题**

**我可以对同一个形状应用多个效果吗？**

可以，您可以将阴影、反射、光晕等不同效果组合在同一个形状上，以创建更动态的外观。

**我可以对哪些形状应用效果？**

您可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

可以，您可以对组合形状应用效果，效果将作用于整个组合。