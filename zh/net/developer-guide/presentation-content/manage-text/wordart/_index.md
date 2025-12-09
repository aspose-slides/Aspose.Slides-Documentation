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
- 发光效果
- WordArt 变换
- 3D 效果
- 外部阴影效果
- 内部阴影效果
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中创建和自定义 WordArt 效果。此分步指南帮助开发人员使用 C# 在演示文稿中添加专业文本。"
---

## **概述**

WordArt 效果可让您在 PowerPoint 演示文稿中添加视觉上吸引人、样式化的文字。使用 Aspose.Slides for .NET，开发人员可以像在 Microsoft PowerPoint 中一样以编程方式创建、定制和管理 WordArt——无需安装 Office。本文概述了在 .NET 中使用 WordArt 的方法，包括如何应用文字变换、填充样式、轮廓、阴影以及其他格式化选项，使您的演示内容更具表现力和吸引力。WordArt 允许您将文字视为图形对象。它由对文字应用的效果或特殊修改组成，使文字更具吸引力或突出。

## **创建简单的 WordArt 模板并将其应用于文字**

在本节中，我们将探讨如何使用 Aspose.Slides for .NET 创建简单的 WordArt 模板并将其应用于文字。WordArt 提供了一种简便的方法，通过醒目的视觉效果和样式来增强文字外观。通过学习创建和使用 WordArt 的基本步骤，您可以轻松将这些技术适用于任何项目，使演示更生动、更令人难忘。

首先，我们使用以下 C# 代码创建简单文字：
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```


现在，使用以下代码将文字的字体高度设置为更大值，以使效果更明显：
```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```


在这里，我们使用以下代码将 SmallGrid 图案填充应用于文字，并添加宽度为 1 的黑色文字边框：
```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```


生成的文字：

![简单的 WordArt 模板](WordArt_template.png)

## **应用其他 WordArt 效果**

除了基本变换外，Aspose.Slides for .NET 还允许您应用各种高级 WordArt 效果，以提升文字外观。这些包括轮廓、填充、阴影、反射和发光效果。通过组合这些功能，您可以创建在演示中脱颖而出的吸睛文字样式。本节演示如何使用简洁的代码示例以编程方式应用这些效果。

### **应用外部阴影效果**

外部阴影效果通过在文字轮廓后添加阴影，使文字更突出，营造出深度感并将其与背景区分开来。Aspose.Slides for .NET 让您可以轻松在 WordArt 文字上应用和定制外部阴影。在本节中，您将学习如何设置阴影颜色、方向、距离、模糊半径等，以实现所需的视觉冲击。

以下 C# 代码片段将阴影效果应用于上述创建的文字。
```cs
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
```


生成的文字：

![外部阴影效果](outer_shadow_effect.png)

{{% alert color="primary" %}} 
- 当同时使用 OuterShadow 和 PresetShadow 时，仅应用 OuterShadow 效果。
- 如果同时使用 OuterShadow 和 InnerShadow，最终效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中效果会叠加，而在 PowerPoint 2007 中仅应用 OuterShadow 效果。
{{% /alert %}}

### **应用反射效果**

在本节中，我们将探讨如何使用 Aspose.Slides for .NET 在幻灯片中应用反射效果。反射效果是一种为文字或形状赋予时尚现代外观的有效方式，帮助关键元素突出并为演示增添深度。通过了解应用和定制这些效果的过程，您可以轻松将其调整以符合设计需求和品牌要求。

使用以下 C# 示例代码为文字添加反射效果：
```cs
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


生成的文字：

![反射效果](reflection_effect.png)

### **应用发光效果**

在本节中，我们将探讨如何使用 Aspose.Slides for .NET 为文字应用发光效果。发光效果可以通过发光轮廓使文字更突出，提升幻灯片的视觉吸引力。通过调整颜色和强度等设置，您可以轻松将发光效果定制为符合设计和品牌需求，确保演示中的关键点捕获观众注意力。

使用以下代码为文字应用发光效果，使其闪耀或突出：
```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```


生成的文字：

![发光效果](glow_effect.png)

### **应用 WordArt 变换**

在本节中，我们将探讨如何使用 Aspose.Slides for .NET 在 WordArt 中使用变换。变换允许您弯曲、拉伸或扭曲文字，创造独特且视觉冲击力强的效果。掌握这些技术后，您可以轻松将文字形状和样式定制为符合品牌或创意愿景，确保呈现出引人入胜且精致的演示。

使用以下代码通过 `Transform` 属性（适用于整段文字）进行变换：
```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```


生成的文字：

![WordArt 变换效果](transform_effect.png)

{{% alert color="primary" %}} 
Aspose.Slides for .NET 提供了一套预定义的[变换类型](https://reference.aspose.com/slides/net/aspose.slides/textshapetype/)。
{{% /alert %}} 

### **对形状和文字应用 3D 效果**

创建逼真且引人注目的视觉效果可以显著提升演示的冲击力。在本节中，我们将探讨如何使用 Aspose.Slides for .NET 对形状应用三维（3D）效果。通过操作深度、角度和光照等参数，您可以生成令人印象深刻的 3D 变换，立即抓住观众的注意力。无论是微妙的高光还是戏剧性的幻象，这些功能都提供了灵活的方式来提升设计，并以更具吸引力的方式传达理念。

使用以下示例代码为形状设置 3D 效果：
```cs
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


生成的形状：

![形状 3D 效果](shape_3D_effect.png)

使用以下示例代码为文字设置 3D 效果：
```cs
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


生成的文字：

![文字 3D 效果](text_3D_effect.png)

{{% alert color="primary" %}} 
对文字或其所在形状应用 3D 效果——以及这些效果之间的交互——遵循特定规则。考虑一个同时涉及文字和包含该文字的形状的场景。3D 效果包括对象的 3D 表现以及放置该对象的场景。

- 如果对形状和文字都设置了场景，则以形状的场景为优先，文字的场景将被忽略。
- 如果形状没有自己的场景但具有 3D 表现，则使用文字的场景。
- 如果形状根本没有 3D 效果，则视为平面，仅对文字应用 3D 效果。

这些行为与[ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/lightrig/)和[ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/camera/)属性有关。
{{% /alert %}} 

## **常见问题**

**我可以在不同字体或文字系统（如阿拉伯语、中文）中使用 WordArt 效果吗？**

可以，Aspose.Slides for .NET 支持 Unicode，并适用于所有主流字体和文字系统。无论语言如何，都可以应用阴影、填充和轮廓等 WordArt 效果，尽管字体可用性和渲染可能取决于系统字体。

**我可以将 WordArt 效果应用于母版幻灯片元素吗？**

可以，您可以对母版幻灯片上的形状（包括标题占位符、页脚或背景文字）应用 WordArt 效果。对母版布局的更改将会反映到所有关联的幻灯片中。

**WordArt 效果会影响演示文稿的文件大小吗？**

会有轻微影响。阴影、发光和渐变填充等 WordArt 效果可能会因附加的格式元数据略微增加文件大小，但差异通常可以忽略不计。

**我能在不保存演示文稿的情况下预览 WordArt 效果的结果吗？**

可以，您可以使用 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 或 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) 接口的 `GetImage` 方法将包含 WordArt 的幻灯片渲染为图像（如 PNG、JPEG），从而在内存或屏幕上预览效果，而无需保存或导出完整的演示文稿。