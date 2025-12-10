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
- 发光效果
- 柔化边缘效果
- 效果格式
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 对 PPT 和 PPTX 文件进行高级形状效果转换——在几秒钟内创建惊艳、专业的幻灯片。"
---

## **概述**

PowerPoint 中的效果可用于使形状突出，但它们不同于[填充](/slides/zh/net/shape-formatting/#gradient-fill)或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射、扩散形状的发光等。

<img src="shape-effect.png" alt="形状效果" style="zoom:50%;" />

PowerPoint 提供六种可应用于形状的效果。您可以对形状应用一种或多种效果。

某些效果组合比其他组合更好看。因此，PowerPoint 在 **预设** 下提供了选项。预设选项本质上是两个或多个效果的已知好看组合。通过选择预设，您无需浪费时间测试或组合不同的效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) 类中提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

要在 Aspose.Slides for .NET 中对形状应用阴影效果，您可以轻松调整颜色、模糊半径和方向等参数。这使您的形状更具动感和专业外观，增加深度和焦点。通过使用简单的代码片段，您可以在多个形状上应用这些效果，提升演示文稿的整体视觉吸引力。

下面的 C# 代码展示了如何对矩形应用[外阴影效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/)。
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


![阴影效果](shadow_effect.png)

## **应用反射效果**

要在 Aspose.Slides for .NET 中应用反射效果，您可以为形状添加类似镜面的反射，调整距离、透明度和大小等参数。此效果通过为形状提供更精致和高雅的外观来提升演示文稿的美感。使用简单的代码即可轻松实现，可快速在多个元素上应用，以实现一致的设计。

下面的 C# 代码展示了如何对形状应用[反射效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/)。
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


![反射效果](reflection_effect.png)

## **应用发光效果**

要在 Aspose.Slides for .NET 中对形状应用发光效果，您可以在形状周围添加柔和的光晕，并调整颜色和大小等属性。此效果有助于使形状突出，并为演示文稿增添吸引人、醒目的视觉元素。仅需少量代码即可轻松实现，提升幻灯片的整体外观。

下面的 C# 代码展示了如何对形状应用[发光效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/)。
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```


![发光效果](glow_effect.png)

## **应用柔化边缘效果**

要在 Aspose.Slides for .NET 中应用柔化边缘效果，您可以在形状的边缘创建平滑、模糊的过渡。此效果增添更细腻、精致的外观，非常适合需要柔和外观的设计。您可以轻松调整半径等参数，以在演示文稿中的各种形状上实现所需效果。

下面的 C# 代码展示了如何对形状应用[柔化边缘](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/)。
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```


![柔化边缘效果](soft_edges_effect.png)

## **常见问题**

**我可以对同一形状应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，如阴影、反射和发光，以创建更具动感的外观。

**我可以对哪些形状应用效果？**

您可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

是的，您可以对组合形状应用效果。该效果将应用于整个组。