---
title: 在 .NET 中的演示文稿中应用形状效果
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
description: "使用 Aspose.Slides for .NET 将高级形状效果应用于您的 PPT 和 PPTX 文件——在几秒钟内创建惊艳、专业的幻灯片。"
---
## **Introduction**

在 PowerPoint 中，效果可用于使形状突出，但它们不同于 [填充](/slides/zh/net/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射、扩展形状的发光等。

![形状效果](shape-effect.png)

PowerPoint 提供了六种可应用于形状的效果。您可以对形状应用一种或多种效果。

某些效果组合比其他组合更好看。为此，PowerPoint 在 **Preset** 下提供了选项。Preset 选项本质上是已知的好看的两种或更多效果的组合。这样，通过选择预设，您无需浪费时间测试或组合不同的效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) 类中提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **Apply a Shadow Effect**

Aspose.Slides for .NET 支持形状的外阴影和内阴影。您可以自定义它们的颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **Apply an Outer Shadow**

使用外阴影使卡片或面板在幻灯片背景中脱颖而出。阴影延伸到形状边缘之外，营造形状悬浮在幻灯片上的感觉。调整颜色、方向、距离和模糊半径，使其符合模板的光照和样式。

下面的 C# 代码展示了如何将 [outer shadow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) 应用于矩形：

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

#### **Control the Shadow Direction When a Shape Rotates**

默认情况下，[RotateShadowWithShape](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/rotateshadowwithshape/) 为 `true`，因此阴影随形状旋转。若希望不同旋转角度的形状看起来光源方向相同，请将该属性设为 `false` 并为它们的阴影设置相同的 [Direction](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/direction/)。

示例创建了两个带有向右偏移灰色阴影（`Direction = 0`）的箭头。随后复制幻灯片并将两个箭头顺时针旋转 90°。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var before = presentation.Slides[0];

var left = before.Shapes.AddAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
left.FillFormat.FillType = FillType.Solid;
left.FillFormat.SolidFillColor.Color = Color.SteelBlue;
left.LineFormat.FillFormat.FillType = FillType.NoFill;

left.EffectFormat.EnableOuterShadowEffect();
var shadow = left.EffectFormat.OuterShadowEffect;
shadow.ShadowColor.Color = Color.Gray;
shadow.Direction = 0;
shadow.Distance = 42;
shadow.BlurRadius = 0;
shadow.RotateShadowWithShape = true;

var right = before.Shapes.AddClone(left);
right.X = 395;
right.EffectFormat.OuterShadowEffect.RotateShadowWithShape = false;

var after = presentation.Slides.AddClone(before);
foreach (var arrow in after.Shapes)
    arrow.Rotation = 90;

presentation.Save("arrow_shadows.pptx", SaveFormat.Pptx);
```

在第二张幻灯片中，左侧箭头的阴影向下投射，而右侧箭头的阴影仍向右。两个阴影的方向均保持为 0°。

![PowerPoint 在 90° 旋转前后的渲染。两个阴影均起始在右侧。旋转后，左侧箭头的阴影移到下方，右侧箭头的阴影仍在右侧。](arrow-shadow-rotation.png)

### **Apply an Inner Shadow**

在复刻模板的视觉样式时，使用内阴影为卡片或面板创建凹陷效果。外阴影延伸到形状外部，使其看起来高起；而内阴影则在边缘内部进行遮暗。

调用 [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)，然后配置 [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/)。数值越大，边缘越柔和。

下面的 C# 示例创建了一个浅蓝色卡片，带有深灰色内阴影，并保存为 PPTX 文件：

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

![带有内阴影的浅蓝色矩形](inner_shadow_effect.png)

要移除内阴影，请在形状的 effect format 上调用 [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/)。

### **Apply, Change, and Remove a Preset Shadow**

调用 [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) 并将 [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) 设置为已命名的 [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/)。要切换样式，只需在同一形状上更改预设。调用 [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) 可在保留填充和轮廓的同时移除阴影。

此示例在每个阶段保留矩形的副本。两个阴影均偏移 10 点。225° 的方向将第一个阴影放在矩形的左上方，45° 的方向将第二个阴影放在右下方。

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

| 原始 | 第一个预设 | 第二个预设 | 删除后 |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Apply a Reflection Effect**

要在 Aspose.Slides for .NET 中应用反射效果，您可以为形状添加镜面反射，并调整距离、透明度和尺寸等参数。此效果通过为形状增添更精致、专业的外观来提升演示文稿的美感。使用简短代码即可轻松实现，可在多个元素上快速应用，实现一致的设计。

下面的 C# 代码展示了如何将 [reflection effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) 应用于形状：

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

## **Apply a Glow Effect**

要在 Aspose.Slides for .NET 中为形状应用发光效果，您可以在形状周围添加柔和的光环，并调整颜色和大小等属性。此效果帮助形状突出，并为演示文稿增添吸引人的视觉元素。只需少量代码即可实现，提升整体幻灯片的观感。

下面的 C# 代码展示了如何将 [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) 应用于形状：

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

## **Apply a Soft Edges Effect**

要在 Aspose.Slides for .NET 中应用柔化边缘效果，您可以在形状的边缘创建平滑、模糊的过渡。此效果使外观更为细腻、精致，适用于需要柔和外观的设计。您可以轻松调节半径等参数，以在演示文稿的各种形状上实现所需效果。

下面的 C# 代码展示了如何将 [soft edges](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) 应用于形状：

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

## **Apply a Blur Effect**

使用形状模糊可以在保持形状可编辑的情况下柔化其填充和轮廓。对形状的 effect format 调用 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/)。半径以点为单位（1/72 英寸）：使用非负值，值越大模糊程度越强。半径为零时外观保持不变。

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) 设置控制效果的可见边界。设为 `false` 时，模糊被裁剪至原始绘制边界（包括轮廓）；设为 `true` 时，模糊可以超出这些边界。两种设置均不改变形状的位置或尺寸。

下面的对比使用相同的填充、轮廓和形状尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![原始矩形与模糊半径为 5 和 15 点的对比，分别在禁用和启用 grow 时的效果](shape_blur_comparison.png)

下面的 C# 示例创建了一个橙色矩形，带深蓝色轮廓，先应用 5 点模糊，然后再次调用 [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) 将模糊半径改为 15 点，并分别保存两种模糊状态。随后调用 [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) 并保存无模糊的形状。

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

形状模糊同时影响填充和轮廓。柔化边缘效果仅淡化形状边缘，而阴影模糊仅软化阴影本身。图像转换效果作用于图像内容；本示例直接在形状的 effect format 上应用模糊，而不将形状转换为图像。

## **FAQ**

**Can I apply multiple effects to the same shape?**

是的，您可以在单个形状上组合不同的效果，例如阴影、反射和发光，以创建更具动感的外观。

**What shapes can I apply effects to?**

您可以对多种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**Can I apply effects to grouped shapes?**

是的，您可以对组合形状应用效果，效果将作用于整个组。