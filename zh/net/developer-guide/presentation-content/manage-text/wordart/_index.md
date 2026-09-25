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
- 反射效果
- 辉光效果
- WordArt 变形
- 3D 效果
- 外部阴影效果
- 内部阴影效果
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中创建和自定义 WordArt 效果。此分步指南帮助开发者使用 C# 为演示文稿添加专业文本。"
---
## **概述**

WordArt 效果可让您使用填充、描边、阴影、反射、辉光、变形和 3D 格式化来美化文本。本文介绍如何使用 Aspose.Slides for .NET 在未安装 Microsoft Office 的情况下，在 PowerPoint 演示文稿中创建和自定义这些效果。

## **创建简单的WordArt模板并将其应用于文本**

以下示例通过设置文本、字体、图案填充和描边来构建一个简单的 WordArt 样式。

每个示例都会创建一个新演示文稿并在其第一张幻灯片上添加一个矩形；无需输入文件。第一个示例将文本设置为 “Aspose.Slides”。形状的位置和尺寸以点为单位：

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

将字体设置为 36 点的 Arial Black，以便更明显地显示格式：

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

应用 [SmallGrid](https://reference.aspose.com/slides/zh/net/aspose.slides/patternstyle/) 图案，前景为深橙色、背景为白色，然后添加宽度为 1 点的黑色文本描边：

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

生成的文本：

![简易WordArt模板](WordArt_template.png)

## **应用其他WordArt效果**

以下示例演示如何对文本应用阴影、反射、辉光、变形和 3D 效果。

### **应用外部阴影效果**

外部阴影通过在文本后方放置阴影来增加深度。您可以自定义其颜色、方向、距离、模糊半径、比例和倾斜。

此示例调用 [EnableOuterShadowEffect](https://reference.aspose.com/slides/zh/net/aspose.slides/effectformat/enableoutershadoweffect/) 并设置黑色阴影，模糊半径为 4 点，方向为 230 度，距离为 30 点。比例值为 100 可保持阴影大小，水平倾斜将其倾斜 20 度。Alpha 变换将不透明度设置为 32%：

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
```

生成的文本：

![外部阴影效果](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 同时使用外部阴影和预设阴影时，仅应用外部阴影。
- 同时使用外部阴影和内部阴影时，效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果会加倍；而在 PowerPoint 2007 中，仅应用外部阴影。
{{% /alert %}}

### **应用反射效果**

反射会创建文本的镜像副本。通过调整位置、比例、模糊和不透明度来控制其外观。

此示例调用 [EnableReflectionEffect](https://reference.aspose.com/slides/zh/net/aspose.slides/effectformat/enablereflectioneffect/) 并将反射垂直翻转，比例为 -100%。使用 0.5 点的模糊半径和 4.72 点的距离。不透明度在反射沿着位置 0% 到 60% 之间从 60% 下降到 0.9%：

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
```

生成的文本：

![反射效果](reflection_effect.png)

### **应用辉光效果**

辉光在文本周围添加柔和的彩色轮廓。通过调整颜色、不透明度和半径来控制效果。

此示例调用 [EnableGlowEffect](https://reference.aspose.com/slides/zh/net/aspose.slides/effectformat/enablegloweffect/) 并应用红色辉光，透明度为 54%，半径为 7 点：

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

生成的文本：

![辉光效果](glow_effect.png)

### **应用WordArt变形**

WordArt 变形可以弯曲、拉伸或扭曲一段文本。

将 [Transform](https://reference.aspose.com/slides/zh/net/aspose.slides/textframeformat/transform/) 设置为 [ArchUpPour](https://reference.aspose.com/slides/zh/net/aspose.slides/textshapetype/) 可使整个文本框向上弧形：

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

生成的文本：

![WordArt变形](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET 提供了一组预定义的 [变形类型](https://reference.aspose.com/slides/zh/net/aspose.slides/textshapetype/)。
{{% /alert %}}

### **对形状和文本应用3D效果**

您可以对形状或其文本应用 3D 效果。斜角、挤压、光照和摄像机设置决定最终外观。

下面的示例使用 [ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/threedformat/) 为矩形添加圆形斜角、橙色挤压和深红色轮廓。斜角尺寸、挤压高度、轮廓宽度和深度均以点为单位。使用塑料材质、围绕 Z 轴旋转 40 度的平衡光照以及透视摄像机来定义外观：

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
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
```

生成的形状：

![形状3D效果](shape_3D_effect.png)

此示例通过 [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/textframeformat/threedformat/) 对文本应用类似的 3D 格式。较小的斜角塑造字母边缘，而挤压和光照则为文本提供深度：

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
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
```

生成的文本：

![文本3D效果](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
将 3D 效果应用于文本或其形状以及这些效果之间的交互受特定规则约束。考虑包含文本的形状场景时，3D 效果包括对象的 3D 表示以及其所在的场景。

- 如果形状和文本都设置了场景，则以形状的场景为主，文本的场景被忽略。
- 如果形状没有自己的场景但有 3D 表示，则使用文本的场景。
- 如果形状根本没有 3D 效果，则视为平面，仅对文本应用 3D 效果。

这些行为与 [ThreeDFormat.LightRig](https://reference.aspose.com/slides/zh/net/aspose.slides/threedformat/lightrig/) 和 [ThreeDFormat.Camera](https://reference.aspose.com/slides/zh/net/aspose.slides/threedformat/camera/) 属性有关。
{{% /alert %}}

若希望在保持形状的 3D 格式的同时让文本保持平坦可读，请参阅 [Keep Text Flat on a 3D Shape](/slides/zh/net/3d-presentation/)，了解两种设置的对比以及完整的 C# 示例。

## **常见问题**

**我可以在不同字体或脚本（例如阿拉伯语、中文）中使用 WordArt 效果吗？**

是的，Aspose.Slides for .NET 支持 Unicode，适用于所有主流字体和脚本。阴影、填充和描边等 WordArt 效果可在任何语言下应用，尽管字体的可用性和渲染可能取决于系统字体。

**我可以将 WordArt 效果应用于母版幻灯片元素吗？**

可以，您可以对母版幻灯片上的形状（包括标题占位符、页脚或背景文本）应用 WordArt 效果。对母版布局的更改会反映到所有关联的幻灯片中。

**WordArt 效果会影响演示文稿的文件大小吗？**

会略有影响。阴影、辉光和渐变填充等 WordArt 效果会因为额外的格式化元数据而稍微增大文件大小，但差异通常可以忽略不计。

**我可以在不保存演示文稿的情况下预览 WordArt 效果的结果吗？**

可以，您可以使用 [ISlide.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/getimage/) 将包含 WordArt 的幻灯片渲染为图像（如 PNG、JPEG），或使用 [IShape.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/getimage/) 单独渲染形状。这使您能够在内存中或屏幕上预览效果，而无需保存或导出完整的演示文稿。