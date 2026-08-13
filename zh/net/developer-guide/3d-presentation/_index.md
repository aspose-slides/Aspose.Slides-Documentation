---
title: 使用 .NET 在演示文稿中创建 3D 效果
linktitle: 3D 演示文稿
type: docs
weight: 232
url: /zh/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 演示文稿
- 3D 旋转
- 3D 深度
- 3D 拉伸
- 3D 渐变
- 3D 文本
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中为 PowerPoint 形状和文本应用并渲染 3D 效果。配置相机、光照、材质、拉伸、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for .NET 可以创建、编辑、保留和渲染类似 PowerPoint 的形状和文本的 3D 格式化。本文章介绍旋转、拉伸、倒角、光照、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" %}}
本文介绍 PowerPoint 形状和文本的 3D 格式化效果，而非插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/properties/threedformat) 属性为形状应用 3D 格式化。该属性公开 [IThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat)，用于控制该形状的 3D 场景。

对于文本，使用 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/properties/threedformat) 属性。这会将 3D 格式化应用于文本框，而不是形状本体。

最重要的属性包括：

| Property | 控制内容 | 使用时机 |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/camera) | 视点、预设相机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [LightRig](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/lightrig) | 光照预设、方向和光源旋转。 | 更改 3D 表面上高光和阴影的显示方式。 |
| [Material](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/material) | 表面材质，如平面、哑光、塑料或金属。 | 使相同的几何形状呈现更平坦、柔和、光亮或金属感。 |
| [ExtrusionHeight](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/extrusionheight) | 形状从正面向后延伸的距离。 | 将平面形状转换为可见的厚实 3D 对象。 |
| [ExtrusionColor](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 拉伸侧面的颜色。 | 使深度可见或将侧面颜色与正面填充保持一致。 |
| [Depth](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D 格式化使用的额外 3D 深度。 | 微调形状或文本的深度，尤其在结合倒角和材质设置时。 |
| [BevelTop](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/beveltop) 和 [BevelBottom](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/bevelbottom) | 正面和背面上的凸起或圆角边缘。 | 添加柔化或模塑的边缘，而不是锐利的平面。 |
| [ContourColor](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/contourcolor) 和 [ContourWidth](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D 对象的轮廓线。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

形状通常需要四类设置才能呈现出逼真的 3D 效果：

- 相机设置，因为默认的正视图可能会隐藏拉伸效果。
- 光照设置，因为光照使各面和侧面可辨。
- 材质设置，因为表面影响光线的渲染方式。
- 拉伸或深度设置，因为平面形状需要厚度。

下面的示例创建一个矩形，在其正面添加文本，应用 3D 格式化，将演示文稿保存为 PPTX，并将幻灯片渲染为 PNG 图像。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

渲染后的幻灯片图像显示矩形为一个厚实的 3D 块：

![渲染的蓝色 3D 矩形，正面有白色 3D 文本](img_01_01.png)

## **使用相机旋转形状**

在 PowerPoint 中，3D 旋转通过“3-D 旋转”面板进行配置。X、Y、Z 旋转值对应于通过相机 API 设置的旋转。

![PowerPoint 3-D 旋转面板，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，使用 [IThreeDFormat.Camera](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/camera) 设置相机类型和旋转：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

当需要改变观看者看到对象的角度时使用相机。它不会改变幻灯片上 2D 形状的几何形状，而是更改 PowerPoint 和 Aspose.Slides 渲染时使用的 3D 视点。

## **添加拉伸和深度**

拉伸通过使形状在正面后方延伸，使其看起来更厚。在 PowerPoint 中，深度控件设置可见的厚度，颜色控件设置侧面的颜色。

![PowerPoint 深度控件映射到拉伸颜色和拉伸高度属性](img_02_02.png)

使用 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/extrusionheight) 设置厚度，使用 [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/extrusioncolor) 设置侧面颜色：

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

当需要直接使用 PowerPoint 的深度值或将深度与倒角、材质和文本效果结合使用时，请使用 [IThreeDFormat.Depth](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/depth)。在许多形状场景中，`ExtrusionHeight` 更直观，因为它直接表示可见的拉伸厚度。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化与形状填充无关。您可以在正面应用纯色、渐变、图案或图片填充，同时仍使用相同的相机、光照、材质和拉伸设置。

以下示例对形状应用渐变填充，并对侧面使用更深的拉伸颜色：

```csharp
using System.Drawing;
using Aspose.Slides;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

![渲染的 3D 矩形，蓝到橙的渐变填充和橙色拉伸](img_02_03.png)

如果要使用图片填充，请将图像添加到演示文稿并分配给形状填充：

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

![渲染的 3D 矩形，正面使用照片填充，侧面为橙色拉伸](img_02_04.png)

## **对文本应用 3D 格式化**

形状的 3D 格式化影响形状本体。文本的 3D 格式化影响文本框。当需要对字母本身进行拉伸、材质、光照和相机设置的类似 WordArt 的效果时，这非常有用。

以下示例创建带有图案填充的文本，应用 WordArt 变换，并在 [ITextFrameFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat) 上配置 3D 设置：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

![渲染的 3D 文本，带有拱形 WordArt 变换、橙色图案填充和深色拉伸](img_02_05.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式化。当渲染或导出为固定布局格式时，3D 场景会光栅化或绘制为 2D 的输出结果。渲染幻灯片为 [PNG](/slides/zh/net/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/net/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/net/convert-powerpoint-to-html/) 或为 [video conversion](/slides/zh/net/convert-powerpoint-to-video/) 生成帧时，均适用此行为。

请注意以下要点：

- 导出的图像和 PDF 不具备交互性，导出后对象无法被观看者旋转。
- 最终外观取决于相机、光照、材质、拉伸、填充以及幻灯片缩放的组合。
- 如果需要检查继承或基于主题的格式化值，请阅读 [effective shape properties](/slides/zh/net/shape-effective-properties/)。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果会被渲染，而不是以可编辑的 3D 设置保存。

## **常见问题**

### Aspose.Slides 能否创建交互式 3D 演示文稿？

Aspose.Slides 为形状和文本创建并渲染 PowerPoint 的 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为观看者可旋转的交互式 3D 场景。在 PPTX 中，只要格式支持，3D 格式化仍可在 PowerPoint 中编辑。

### 3D 模型与 3D 效果有什么区别？

3D 模型是插入演示文稿的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、拉伸、倒角、光照和材质。本文讨论的正是 3D 效果。

### 可见的 3D 形状需要哪些设置？

至少需要设置相机旋转以及拉伸或深度中的任意一个。实际使用时，还应设置光照和材质，以便渲染的面拥有清晰的高光和阴影。

### 我可以将 3D 效果同时应用于形状和文本吗？

可以。对形状本体使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/properties/threedformat)，对文本使用 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/properties/threedformat)。

### 将 3D 效果导出为图像、PDF、HTML 或视频帧时会显示吗？

会。Aspose.Slides 在生成幻灯片图像、PDF 输出、HTML 输出以及用于视频转换的帧时会渲染 3D 效果。导出结果包含渲染后的外观，而不是可编辑的 3D 对象。

### 在继承和主题设置应用后，我能读取最终的 3D 值吗？

可以。使用在 [Shape Effective Properties](/slides/zh/net/shape-effective-properties/) 中描述的有效格式化 API 读取最终的相机、光照、倒角以及相关的 3D 值。