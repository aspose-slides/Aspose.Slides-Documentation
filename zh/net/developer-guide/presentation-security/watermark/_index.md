---
title: 在 .NET 中向演示文稿添加水印
linktitle: 水印
type: docs
weight: 40
url: /zh/net/watermark/
keywords:
- 水印
- 文字水印
- 图片水印
- 添加水印
- 更改水印
- 移除水印
- 删除水印
- 向 PPT 添加水印
- 向 PPTX 添加水印
- 向 ODP 添加水印
- 从 PPT 移除水印
- 从 PPTX 移除水印
- 从 ODP 移除水印
- 从 PPT 删除水印
- 从 PPTX 删除水印
- 从 ODP 删除水印
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中管理 PowerPoint 和 OpenDocument 演示文稿的文字和图片水印，以标示草稿、机密信息、版权等。"
---
## **介绍**

**水印** 在演示文稿中是用于幻灯片或整个演示文稿的文字或图片标记。通常，水印用于指示演示文稿是草稿（例如 “Draft” 水印）、包含机密信息（例如 “Confidential” 水印）、标明所属公司（例如 “Company Name” 水印）、标识演示文稿作者等。水印通过表明演示文稿不应被复制，帮助防止版权侵权。水印可用于 PowerPoint 和 OpenDocument 演示文稿格式。在 Aspose.Slides 中，您可以向 PowerPoint PPT、PPTX 和 OpenDocument ODP 文件格式添加水印。

在[**Aspose.Slides**](https://products.aspose.com/slides/zh/net/)中，有多种方法可以在 PowerPoint 或 OpenDocument 文档中创建水印并修改其设计和行为。共同点是，要添加文字水印，您应使用[ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/)接口；要添加图片水印，则使用[PictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/pictureframe/)类或使用图片填充水印形状。`PictureFrame` 实现了[IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape)接口，允许您使用形状对象的所有灵活设置。由于 `ITextFrame` 不是形状且其设置有限，它被包装成一个[IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape)对象。

水印的应用方式有两种：应用于单个幻灯片或应用于所有演示文稿幻灯片。使用幻灯片母版（Slide Master）可将水印应用于所有幻灯片——水印被添加到幻灯片母版，在母版中完整设计后，应用到所有幻灯片且不影响对单个幻灯片上水印的修改权限。

水印通常被视为其他用户无法编辑的内容。为防止水印（或更准确地说其父形状）被编辑，Aspose.Slides 提供了形状锁定功能。可以在普通幻灯片或幻灯片母版上锁定特定形状。当水印形状在幻灯片母版上被锁定时，它将在所有演示文稿幻灯片上被锁定。

您可以为水印设置名称，以便将来需要删除时可以通过名称在幻灯片的形状集合中找到它。

您可以以任何方式设计水印；不过，水印通常具有一些共同特征，例如居中对齐、旋转、置于前面等。我们将在下面的示例中考虑如何使用这些特性。

## **文字水印**

### **向幻灯片添加文字水印**

要在 PPT、PPTX 或 ODP 中添加文字水印，您可以先向幻灯片添加形状，然后向该形状添加文本框。文本框由[ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe)接口表示。该类型未继承自[IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/)，后者拥有一整套用于灵活定位水印的属性。因此，[ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe)对象被包装在[IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)对象中。要向形状添加水印文本，请使用[AddTextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/methods/addtextframe)方法，如下所示。

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// 将水印添加到幻灯片。
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="另见" %}} 
- [How to Use the TextFrame Class?](/slides/zh/net/text-formatting/)
{{% /alert %}}

### **向演示文稿添加文字水印**

如果要为整个演示文稿（即一次性所有幻灯片）添加文字水印，请将其添加到[MasterSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/masterslide/)。其余逻辑与向单个幻灯片添加水印相同——创建一个[IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)对象，然后使用[AddTextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/methods/addtextframe)方法将水印添加进去。

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// 将水印添加到母版幻灯片。
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="另见" %}} 
- [How to Use the Slide Master?](/slides/zh/net/slide-master/)
{{% /alert %}}

### **设置水印形状透明度**

默认情况下，矩形形状带有填充颜色和线条颜色。这意味着添加水印时可能会出现实心背景或边框，进而分散幻灯片内容的注意力。为了确保水印保持低调且不干扰演示文稿的视觉设计，您可以将形状完全透明。

下面的代码通过去除填充和边框颜色将形状设为透明：

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **设置文字水印的字体**

在将文字水印应用到幻灯片之前，先自定义其外观以与整体设计相协调非常重要。您可以更改字体类型和大小，以确保水印既易读又美观。自定义字体还可以帮助强化品牌标识或仅仅匹配演示文稿的风格。

下面的代码片段演示了如何通过选择特定的拉丁字体并设置合适的字体高度来调整水印的字体设置：

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **设置水印文字颜色**

在应用水印之前，务必确保文字颜色设置得当，使其与幻灯片内容和谐融合且不至于喧宾夺主。通过调整透明度（Alpha）以及红、绿、蓝分量，您可以创建一种细腻、半透明的水印，既可见又不突兀。这种做法有助于在保护内容的同时保持观众对主体演示的关注。

要设置水印文字的颜色，请使用以下代码：

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **居中文字水印**

正确地将文字水印居中可以显著提升演示文稿的整体美感，确保水印在幻灯片尺寸变化时保持对称定位。这不仅让幻灯片看起来更专业，还能确保水印不会干扰幻灯片的主要内容。

下面的代码片段演示了如何计算幻灯片的中心位置并相应地放置文字水印：

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

下图显示了最终效果。

![文字水印](text_watermark.png)

## **图片水印**

### **向演示文稿添加图片水印**

在许多情况下，图片水印可以提供独特的品牌元素或比文字水印更具视觉吸引力的替代方案。添加水印之前，请确保图像文件已准备就绪（例如 PNG 以支持透明度）。下面的示例演示了如何从文件系统加载图像、将其添加到演示文稿中，然后使用形状的填充属性将其用作水印。

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **防止水印被编辑**

如果需要防止水印被编辑，请在形状上使用[IAutoShape.ShapeLock](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/properties/shapelock)属性。通过此属性，您可以保护形状不被选中、调整大小、重新定位、与其他元素组合、锁定其文字编辑等：

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// 锁定水印形状，防止修改。
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **将水印置于前面**

在 Aspose.Slides 中，可以通过[IShapeCollection.Reorder](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/reorder/#reorder)方法设置形状的 Z 顺序。为此，需从演示文稿的幻灯片列表调用此方法，并将形状引用及其顺序号传入。这样就可以将形状置于前面或发送到幻灯片的后面。当需要将水印放在演示文稿前面时，此功能尤为实用：

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **设置水印旋转角度**

调整水印的旋转角度可以显著提升演示文稿的视觉冲击力和低调感。例如，对角线水印相对不那么突兀，同时仍能提供强有力的内容保护。下面的示例根据幻灯片尺寸计算合适的角度，使水印沿对角线放置。此动态计算确保无论幻灯片大小如何，水印都保持有效。

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **为水印设置名称**

Aspose.Slides 允许您为形状设置名称。使用形状名称，您以后可以通过名称访问它，以进行修改或删除。要为水印形状设置名称，请将其分配给[IAutoShape.Name](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/properties/name)属性：

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **删除水印**

要删除水印形状，请使用[IAutoShape.Name](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/properties/name)属性在幻灯片形状中找到它。然后，将水印形状传入[IShapeCollection.Remove](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/remove/)方法：

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **实时示例**

您可以尝试 Aspose.Slides 免费的[Add Watermark](https://products.aspose.app/slides/zh/watermark)和[Remove Watermark](https://products.aspose.app/slides/zh/watermark/remove-watermark)在线工具。

![用于添加和删除水印的在线工具](online_tools.png)

## **常见问题**

### 什么是水印，为什么要使用它？

水印是覆盖在幻灯片上的文字或图片，用于保护知识产权、提升品牌识别度或防止演示文稿未经授权使用。

### 我可以为演示文稿的所有幻灯片添加水印吗？

可以，Aspose.Slides 允许您以编程方式为演示文稿中的每一张幻灯片添加水印。您可以遍历所有幻灯片并逐个应用水印设置。

### 如何调整水印的透明度？

您可以通过修改形状的填充设置（[FillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/fillformat/)）来调整水印的透明度，从而确保水印低调且不分散幻灯片内容的注意力。

### 支持哪些图像格式作为水印？

Aspose.Slides 支持多种图像格式，例如 PNG、JPEG、GIF、BMP、SVG 等。

### 我可以自定义文字水印的字体和样式吗？

可以，您可以选择任意字体、大小和样式，以匹配演示文稿的设计并保持品牌一致性。

### 如何更改水印的位置或方向？

您可以通过编程方式修改形状的坐标、大小和旋转属性，从而调整水印的位置和方向。