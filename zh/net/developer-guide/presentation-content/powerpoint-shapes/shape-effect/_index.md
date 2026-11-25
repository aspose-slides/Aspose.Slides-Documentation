---
title: 在 .NET 中为演示文稿应用形状效果
linktitle: 形状效果
type: docs
weight: 30
url: /zh/net/shape-effect/
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
description: "使用 Aspose.Slides for .NET 将高级形状效果应用于您的 PPT 和 PPTX 文件——在几秒钟内创建引人注目、专业的幻灯片。"
---
## **介绍**

虽然 PowerPoint 中的效果可用于使形状突出，但它们不同于 [填充](/slides/zh/net/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，你可以在形状上创建逼真的反射，扩散形状的发光等。

![形状效果](shape-effect.png)

PowerPoint 提供六种可应用于形状的效果。你可以对一个形状应用一种或多种效果。

某些效果组合比其他组合更好看。因此，PowerPoint 在 **预设** 下提供了选项。预设选项本质上是两种或多种效果的已知美观组合。这样，通过选择预设，你无需浪费时间测试或组合不同的效果来寻找合适的搭配。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) 类下提供属性和方法，允许你在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for .NET 支持形状的外部和内部阴影。你可以自定义它们的颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影可以使卡片或面板在幻灯片背景上突出。阴影延伸超过形状的边缘，营造出形状悬浮在幻灯片之上的感觉。调整其颜色、方向、距离和模糊半径，以匹配模板的光照和样式。

下面的 C# 代码演示如何对矩形应用 [外部阴影效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/)：

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

在复现模板的视觉样式时，使用内部阴影可以为卡片或面板提供凹陷的外观。外部阴影延伸到形状之外，使其看起来凸起，而内部阴影则对其边缘内部进行阴影处理。

调用 [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)，然后配置 [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/)。较大的数值会产生更柔和的边缘。

下面的 C# 示例创建一个浅蓝色卡片，带有深灰色内部阴影，并将其保存为 PPTX 文件：

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

要移除内部阴影，请在形状的 effect format 上调用 [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/)。

### **应用、更改和移除预设阴影**

调用 [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) 并将 [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) 设置为命名的 [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/)。要切换样式，请在同一形状上更改预设。调用 [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) 可以在保留填充和轮廓的同时移除阴影。

此示例在每个阶段保留矩形的副本。两个阴影均偏移 10 点。225° 的方向使第一个阴影位于矩形的左上方，45° 的方向使第二个阴影位于右下方。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| 原始 | 第一个预设 | 第二个预设 | 移除后 |
| :---: | :---: | :---: | :---: |
| ![无阴影](preset_shadow_original.png) | ![左上投影阴影](preset_shadow_top_left.png) | ![右下投影阴影](preset_shadow_bottom_right.png) | ![移除后无阴影](preset_shadow_removed.png) |

## **应用反射效果**

在 Aspose.Slides for .NET 中应用反射效果时，你可以为形状添加类似镜面的反射，并调整距离、透明度和大小等参数。此效果通过为形状提供更精致、专业的外观来提升演示文稿的美感。使用简短代码即可轻松实现，可快速在多个元素上应用，保持设计的一致性。

下面的 C# 代码演示如何对形状应用 [反射效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/)：

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

## **应用发光效果**

在 Aspose.Slides for .NET 中为形状应用发光效果时，你可以在形状周围添加柔和、发光的光晕，并调整颜色和大小等属性。此效果有助于突出形状，并为演示文稿增添吸引人、醒目的视觉元素。只需少量代码即可轻松实现，提升幻灯片的整体外观。

下面的 C# 代码演示如何对形状应用 [发光效果](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/)：

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

![发光效果](glow_effect.png)

## **应用柔化边缘效果**

在 Aspose.Slides for .NET 中应用柔化边缘效果时，你可以在形状的边缘创建平滑、模糊的过渡。此效果带来更柔和、精致的外观，适用于需要细腻、柔软外观的设计。你可以轻松调整半径等参数，以在演示文稿的各种形状上实现所需效果。

下面的 C# 代码演示如何对形状应用 [柔化边缘](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/)：

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

## **应用模糊效果**

使用形状模糊可以柔化形状的填充和轮廓，同时保持形状可编辑。对形状的 effect format 调用 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/)。半径以点（1/72 英寸）为单位：使用非负值，较大的值会产生更强的模糊。半径为零时外观保持不变。

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) 设置控制效果的可见范围。设为 `false` 时，模糊被裁剪到原始绘制范围（包括轮廓）。设为 `true` 时，模糊可以超出该范围。此设置均不会改变形状的位置或尺寸。

下面的比较在所有情况下使用相同的填充、轮廓和形状尺寸。顶部行使用 `grow = false`；底部行使用 `grow = true`。

![原始矩形与模糊半径为5和15点的比较，grow禁用和启用](shape_blur_comparison.png)

下面的 C# 示例创建一个橙色矩形，带深蓝色轮廓，应用 5 点模糊，然后再次调用 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) 将其更新为 15 点模糊。它保存了两种模糊状态，然后调用 [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) 并保存没有模糊的形状。

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

形状模糊会同时作用于填充和轮廓。柔化边缘效果会淡化形状的边缘，而阴影模糊仅软化阴影。图像变换效果作用于图像内容；本例直接对形状的 effect format 应用模糊，而无需将形状转换为图像。

## **常见问题**

**我可以对同一形状应用多个效果吗？**

是的，你可以在单个形状上组合不同的效果，如阴影、反射和发光，以创建更具动感的外观。

**我可以对哪些形状应用效果？**

你可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

是的，你可以对组合形状应用效果。该效果将应用于整个组合。