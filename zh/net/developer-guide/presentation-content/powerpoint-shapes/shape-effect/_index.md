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
- 柔和边缘效果
- 效果格式
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 对 PPT 和 PPTX 文件进行高级形状效果转换——在几秒钟内创建引人注目、专业的幻灯片。"
---
## **介绍**

PowerPoint 中的效果可用于突出显示形状，但它们不同于[填充](/slides/zh/net/shape-formatting/#gradient-fill)或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射，扩散形状的辉光等。

![形状效果](shape-effect.png)

PowerPoint 提供六种可应用于形状的效果。您可以对一个形状应用一种或多种效果。

某些效果组合比其他组合更好看。因此，PowerPoint 在 **Preset** 下提供了选项。Preset 选项本质上是两种或多种效果的已知好看组合。这样，通过选择预设，您无需浪费时间测试或组合不同的效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) 类下提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for .NET 支持形状的外部和内部阴影。您可以自定义其颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影可以使卡片或面板在幻灯片背景上更突出。阴影延伸至形状边缘之外，给人形状悬浮在幻灯片上的感觉。调整其颜色、方向、距离和模糊半径以匹配模板的光照和样式。

以下 C# 代码演示如何对矩形应用 [外部阴影效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/)：

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

在复制模板的视觉样式时，使用内部阴影可为卡片或面板提供凹陷效果。外部阴影延伸至形状外部，使其看起来凸起，而内部阴影则在其边缘内部着色。

调用 [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)，然后配置 [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/)。较大的值会产生更柔和的边缘。

以下 C# 示例创建一个浅蓝色卡片，带有深灰色内部阴影，并将其保存为 PPTX 文件：

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

在 Aspose.Slides for .NET 中应用反射效果时，您可以为形状添加类似镜面的反射，并调整距离、透明度和大小等参数。此效果通过为形状提供更精致、专业的外观来提升演示文稿的美感。使用简单的代码即可轻松实现，可快速在多个元素上应用，实现一致的设计。

以下 C# 代码演示如何对形状应用 [反射效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/)：

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

在 Aspose.Slides for .NET 中为形状应用辉光效果时，您可以在形状周围添加柔和的光晕，并调整颜色和大小等属性。此效果有助于突出形状，使演示文稿更具吸引力和视觉冲击力。只需少量代码即可实现，提升整体幻灯片的观感。

以下 C# 代码演示如何对形状应用 [辉光效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/)：

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

## **应用柔和边缘效果**

在 Aspose.Slides for .NET 中应用柔和边缘效果时，您可以在形状的边缘周围创建平滑的模糊过渡。此效果为设计增添更细腻、精致的外观，适合需要柔和外观的场景。您可以轻松调整半径等参数，以在演示文稿的各种形状上实现理想效果。

以下 C# 代码演示如何对形状应用 [柔和边缘](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/)：

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

![柔和边缘效果](soft_edges_effect.png)

## **应用模糊效果**

使用形状模糊可以在保持形状可编辑的同时软化其填充和轮廓。对形状的 EffectFormat 调用 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) 即可。半径的单位为点（1/72 英寸），使用非负值，数值越大模糊越强。半径为零时外观保持不变。

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) 设置控制效果的可见范围。`false` 时，模糊被裁剪到原始绘制边界（包括轮廓）；`true` 时，模糊可以超出这些边界。两种设置都不会改变形状的位置或尺寸。

下面的对比在整个示例中使用相同的填充、轮廓和形状尺寸。上排使用 `grow = false`，下排使用 `grow = true`。

![原始矩形与模糊半径5和15点的比较（grow 禁用和启用）](shape_blur_comparison.png)

以下 C# 示例创建一个橙色矩形，带深蓝色轮廓，先应用 5 点模糊，然后再次调用 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) 将其更新为 15 点模糊。它分别保存两个模糊状态，然后调用 [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) 并保存无模糊的形状。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

形状模糊同时影响填充和轮廓。柔和边缘效果仅淡化形状的边缘，而阴影模糊仅软化阴影本身。图像转换效果作用于图像内容；本示例直接对形状的 EffectFormat 应用模糊，而无需将形状转换为图像。

## **常见问题**

**我可以在同一个形状上应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，如阴影、反射和辉光，以实现更具动感的外观。

**哪些形状可以应用效果？**

您可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

可以，效果会应用于整个组合。