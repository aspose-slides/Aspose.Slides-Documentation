---
title: 在 .NET 中对演示文稿应用形状效果
linktitle: 形状效果
type: docs
weight: 30
url: /zh/net/shape-effect/
keywords:
- 形状效果
- 阴影效果
- 反射效果
- 辉光效果
- 柔化边缘效果
- 效果格式
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将您的 PPT 和 PPTX 文件转换为高级形状效果——在几秒钟内创建引人注目、专业的幻灯片。"
---
## **介绍**

虽然 PowerPoint 中的效果可以用于使形状突出，但它们不同于 [填充](/slides/zh/net/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射，扩散形状的发光等。

![形状效果](shape-effect.png)

PowerPoint 提供了六种可应用于形状的效果。您可以对一个形状应用一个或多个效果。

某些效果组合看起来比其他组合更好。为此，PowerPoint 在 **预设** 下提供了选项。预设选项本质上是已知的、好看的两种或多种效果的组合。通过选择预设，您无需浪费时间测试或组合不同的效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) 类下提供了属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for .NET 支持形状的外部和内部阴影。您可以自定义它们的颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影可以使卡片或面板在幻灯片背景中突出。阴影延伸到形状边缘之外，产生形状悬浮在幻灯片上的感觉。调整其颜色、方向、距离和模糊半径，以匹配模板的光照和样式。

以下 C# 代码示例演示如何对矩形应用 [外部阴影效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/):

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

### **应用内部阴影**

在复现模板的视觉样式时，使用内部阴影可以为卡片或面板提供凹陷的外观。外部阴影延伸到形状之外，使其看起来突出，而内部阴影则在其边缘内部进行遮蔽。

调用 [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)，然后配置 [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/)。较大的数值会产生更柔和的边缘。

以下 C# 示例创建一个浅蓝色卡片，带有深灰色内部阴影，并将其保存为 PPTX 文件:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![带内部阴影的浅蓝色矩形](inner_shadow_effect.png)

要移除内部阴影，请在形状的 EffectFormat 上调用 [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/)。

## **应用反射效果**

在 Aspose.Slides for .NET 中应用反射效果时，您可以为形状添加类似镜面的反射，并调整距离、透明度和大小等参数。该效果通过为形状提供更精致、优雅的外观来提升演示文稿的美感。只需简单代码即可轻松实现，可在多个元素间快速应用，实现一致的设计。

以下 C# 代码示例演示如何对形状应用 [反射效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/):

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **应用辉光效果**

在 Aspose.Slides for .NET 中为形状应用辉光效果时，您可以在形状周围添加柔和、发光的光晕，并调整颜色和大小等属性。此效果有助于使形状突出，并为演示文稿添加吸引人的视觉元素。只需少量代码即可轻松实现，提升幻灯片的整体外观。

以下 C# 代码示例演示如何对形状应用 [辉光效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/):

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![辉光效果](glow_effect.png)

## **应用柔化边缘效果**

在 Aspose.Slides for .NET 中应用柔化边缘效果时，您可以在形状的边缘周围创建平滑、模糊的过渡。该效果赋予更微妙、精致的外观，非常适合需要柔和外观的设计。您可以轻松调整半径等参数，在演示文稿中的各类形状上实现理想的效果。

以下 C# 代码示例演示如何对形状应用 [柔化边缘](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/):

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

是的，您可以在同一形状上组合不同的效果，例如阴影、反射和辉光，以创建更具动感的外观。

**我可以对哪些形状应用效果？**

您可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

是的，您可以对组合形状应用效果。该效果将应用于整个组合。