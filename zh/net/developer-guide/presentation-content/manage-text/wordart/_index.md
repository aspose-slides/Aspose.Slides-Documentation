---
title: 在 .NET 中创建和应用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh/net/wordart/
keywords:
- WordArt
- 创建 WordArt
- WordArt 模板
- WordArt 效果
- 阴影效果
- 显示效果
- 辉光效果
- WordArt 变形
- 3D 效果
- 外部阴影效果
- 内部阴影效果
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中创建和定制 WordArt 效果。本分步指南帮助开发人员使用 C# 为演示文稿添加专业文本。"
---
## **概述**

WordArt 效果让您可以向 PowerPoint 演示文稿添加视觉上吸引人、样式化的文本。借助 Aspose.Slides for .NET，开发人员可以以编程方式创建、定制和管理 WordArt，就像在 Microsoft PowerPoint 中一样——无需安装 Office。本文概述了在 .NET 中使用 WordArt 的方法，包括如何应用文本变形、填充样式、轮廓、阴影以及其他格式选项，以使您的演示内容更具表现力和吸引力。WordArt 允许您将文本视为图形对象。它由应用于文本的效果或特殊修改组成，使文本更具吸引力或更醒目。

## **创建一个简单的 WordArt 模板并将其应用于文本**

在本节中，我们将探讨如何使用 Aspose.Slides for .NET 创建一个简单的 WordArt 模板并将其应用于文本。WordArt 提供了一种简便的方法，可通过引人注目的视觉效果和样式提升文本外观。通过学习创建和使用 WordArt 的基本步骤，您可以轻松将这些技术应用于任何项目，使演示更生动、令人难忘。

首先，我们使用以下 C# 代码创建普通文本：

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

现在，我们使用以下代码将文本的字体高度设置为更大的数值，以使效果更显著：

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";

    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
}
```

在这里，我们使用以下代码将 SmallGrid 图案填充应用于文本，并使用宽度为 1 的黑色文本边框：

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
}
```

生成的文本：

![简单的 WordArt 模板](WordArt_template.png)

## **应用其他 WordArt 效果**

除了基本的变形，Aspose.Slides for .NET 还允许您应用多种高级 WordArt 效果来增强文本的外观。这些包括轮廓、填充、阴影、反射和辉光效果。通过组合这些功能，您可以创建在演示中脱颖而出的引人注目文本样式。本节演示如何使用简洁的代码示例以编程方式应用这些效果。

### **应用外部阴影效果**

外部阴影效果通过在文本轮廓后添加阴影，使文本更突出，营造出深度感和与背景的分离感。Aspose.Slides for .NET 让您可以轻松在 WordArt 文本上应用和定制外部阴影。在本节中，您将学习如何设置阴影颜色、方向、距离、模糊半径等，以实现所需的视觉冲击。

下面的 C# 代码片段为上述创建的文本应用阴影效果。

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
}
```

生成的文本：

![外部阴影效果](outer_shadow_effect.png)

{{% alert color="info" %}} 
- 当同时使用 OuterShadow 和 PresetShadow 时，仅会应用 OuterShadow 效果。
- 如果同时使用 OuterShadow 和 InnerShadow，最终效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果会加倍；而在 PowerPoint 2007 中，仅会应用 OuterShadow 效果。
{{% /alert %}}

### **应用反射效果**

在本节中，我们将探讨如何使用 Aspose.Slides for .NET 在幻灯片中应用反射效果。反射效果可以为文本或形状提供时尚现代的外观，帮助关键元素突出，并为演示增添层次感。通过了解应用和定制这些效果的过程，您可以轻松根据设计需求和品牌要求进行调整。

使用以下 C# 代码示例为文本添加反射效果：

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

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
}
```

生成的文本：

![反射效果](reflection_effect.png)

### **应用辉光效果**

在本节中，我们将探讨如何使用 Aspose.Slides for .NET 为文本应用辉光效果。辉光效果可以通过发光的轮廓使文本更加突出，提升幻灯片的视觉吸引力。通过调整颜色和强度等设置，您可以轻松将辉光效果定制为符合设计和品牌需求，确保演示中的关键点吸引观众注意。

使用以下代码为文本应用辉光效果，使其发光或突出：

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
}
```

生成的文本：

![辉光效果](glow_effect.png)

### **应用 WordArt 变形**

在本节中，我们将探讨如何使用 Aspose.Slides for .NET 在 WordArt 中使用变形。变形可以弯曲、拉伸或扭曲文本，创建独特且视觉冲击力强的效果。掌握这些技术后，您可以轻松将文本形状和样式定制为符合品牌或创意构想，确保演示既引人注目又精致。

使用以下代码通过 `Transform` 属性（适用于整段文本）应用变形：

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
}
```

生成的文本：

![WordArt 变形效果](transform_effect.png)

{{% alert color="info" %}} 
Aspose.Slides for .NET 提供了一组预定义的[转换类型](https://reference.aspose.com/slides/zh/net/aspose.slides/textshapetype/)。
{{% /alert %}} 

### **为形状和文本应用 3D 效果**

创建逼真且引人注目的视觉效果可以显著提升演示的影响力。在本节中，我们将探讨如何使用 Aspose.Slides for .NET 为形状应用三维（3D）效果。通过操控深度、角度和光照等参数，您可以生成令人印象深刻的 3D 变形，立即吸引观众注意。无论是细微的高光还是戏剧性的幻象，这些功能都提供了灵活的方法来提升设计，并以更具吸引力的方式传达理念。

使用以下示例代码为形状设置 3D 效果：

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.TextFrame.Text = "Aspose.Slides";

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
}
```

生成的形状：

![形状 3D 效果](shape_3D_effect.png)

使用以下示例代码为文本设置 3D 效果：

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
}
```

生成的文本：

![文本 3D 效果](text_3D_effect.png)

{{% alert color="info" %}} 
将 3D 效果应用于文本或其形状——以及这些效果之间的交互——受特定规则约束。考虑一个包含文本及其所在形状的场景。3D 效果包括对象的 3D 表示以及其所在的场景。

- 如果形状和文本都设置了场景，则以形状的场景为优先，文本的场景被忽略。
- 如果形状没有自己的场景但具有 3D 表示，则使用文本的场景。
- 如果形状根本没有 3D 效果，则视为平面，仅对文本应用 3D 效果。

这些行为与[ThreeDFormat.LightRig](https://reference.aspose.com/slides/zh/net/aspose.slides/threedformat/lightrig/)和[ThreeDFormat.Camera](https://reference.aspose.com/slides/zh/net/aspose.slides/threedformat/camera/)属性相关。
{{% /alert %}} 

## **FAQ**

### 我可以将 WordArt 效果用于不同的字体或文字系统（例如阿拉伯文、中文）吗？

可以，Aspose.Slides for .NET 支持 Unicode 并兼容所有主流字体和文字系统。无论语言为何，阴影、填充和轮廓等 WordArt 效果均可应用，只是字体的可用性和渲染可能取决于系统字体。

### 我可以将 WordArt 效果应用于母版幻灯片元素吗？

可以，您可以将 WordArt 效果应用于母版幻灯片上的形状，包括标题占位符、页脚或背景文字。对母版布局所做的更改会在所有关联的幻灯片中体现。

### WordArt 效果会影响演示文件大小吗？

会有轻微影响。阴影、辉光和渐变填充等 WordArt 效果可能会因新增的格式元数据略微增大文件大小，但差异通常可以忽略不计。

### 我可以在不保存演示文稿的情况下预览 WordArt 效果的结果吗？

可以，您可以使用 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/) 或 [ISlide](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/) 接口的 `GetImage` 方法将包含 WordArt 的幻灯片渲染为图像（如 PNG、JPEG），从而在内存或屏幕上预览效果，无需先保存或导出完整的演示文稿。