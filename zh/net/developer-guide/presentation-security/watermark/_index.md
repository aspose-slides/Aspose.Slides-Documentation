---
title: 在 C# 中向演示文稿添加水印
linktitle: 水印
type: docs
weight: 40
url: /zh/net/watermark/
keywords:
- 水印
- 文本水印
- 图片水印
- 添加水印
- 更改水印
- 移除水印
- 删除水印
- 向演示文稿添加水印
- 向 PPT 添加水印
- 向 PPTX 添加水印
- 向 ODP 添加水印
- 从演示文稿移除水印
- 从 PPT 移除水印
- 从 PPTX 移除水印
- 从 ODP 移除水印
- 从演示文稿删除水印
- 从 PPT 删除水印
- 从 PPTX 删除水印
- 从 ODP 删除水印
- PowerPoint
- OpenDocument
- 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "了解如何在 C# 中管理 PowerPoint 和 OpenDocument 演示文稿中的文本和图片水印，以指示草稿、机密信息、版权等。"
---

## **概述**

**水印** 在演示文稿中是用于幻灯片或整个演示文稿的文字或图像标记。通常，水印用于指示演示文稿是草稿（例如 “Draft” 水印），包含机密信息（例如 “Confidential” 水印），指定所属公司（例如 “Company Name” 水印），标识演示文稿作者等。水印通过表明不应复制演示文稿来帮助防止版权侵权。水印可用于 PowerPoint 和 OpenDocument 演示文稿格式。在 Aspose.Slides 中，您可以向 PowerPoint PPT、PPTX 和 OpenDocument ODP 文件格式添加水印。

在[**Aspose.Slides**](https://products.aspose.com/slides/net/)，有多种方式在 PowerPoint 或 OpenDocument 文档中创建水印并修改其设计和行为。共同点是，要添加文字水印，应使用[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 接口；要添加图片水印，则使用[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) 类或用图像填充水印形状。`PictureFrame` 实现了[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) 接口，允许您使用形状对象的所有灵活设置。由于 `ITextFrame` 不是形状且其设置受限，它被包装成[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) 对象。

水印的应用方式有两种：应用于单个幻灯片或应用于所有演示文稿幻灯片。幻灯片母版用于将水印应用于所有幻灯片——水印被添加到幻灯片母版，在母版中完成全部设计，并应用到所有幻灯片，而不会影响对单个幻灯片上水印的修改权限。

水印通常被视为不可被其他用户编辑。为防止水印（或更确切地说其父形状）被编辑，Aspose.Slides 提供了形状锁定功能。可以在普通幻灯片或幻灯片母版上锁定特定形状。当水印形状在幻灯片母版上被锁定时，它将在所有演示文稿幻灯片上被锁定。

您可以为水印设置名称，以便将来需要删除时，通过名称在幻灯片的形状集合中找到它。

水印的设计方式可以多种多样；但通常有一些共同特征，如居中对齐、旋转、前置位置等。下面的示例将演示如何在实际中使用这些特性。

## **文字水印**

### **向幻灯片添加文字水印**

要在 PPT、PPTX 或 ODP 中添加文字水印，首先可以向幻灯片添加一个形状，然后向该形状添加文字框。文字框由[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) 接口表示。该类型未继承自[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)，后者拥有丰富的属性用于灵活定位水印。因此，[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) 对象被包装在[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 对象中。要向形状添加水印文字，请使用[AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) 方法，如下所示。
```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// 将水印添加到幻灯片。
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


{{% alert color="primary" title="另请参阅" %}} 
- [如何使用 TextFrame 类？](/slides/zh/net/text-formatting/)
{{% /alert %}}

### **向演示文稿添加文字水印**

如果要向整个演示文稿（即一次性全部幻灯片）添加文字水印，请将其添加到[MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/)。其余逻辑与向单个幻灯片添加水印相同——创建一个[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 对象，然后使用[AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) 方法将水印添加进去。
```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// 将水印添加到母版幻灯片。
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


{{% alert color="primary" title="另请参阅" %}} 
- [如何使用幻灯片母版？](/slides/zh/net/slide-master/)
{{% /alert %}}

### **设置水印形状透明度**

默认情况下，矩形形状带有填充色和线条颜色。这意味着添加水印时，可能会出现实心背景或边框，进而干扰幻灯片内容。为确保水印保持低调且不影响演示的视觉设计，您可以将形状完全透明。

以下代码行通过移除填充色和边框色使形状透明：
```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```


### **设置文字水印的字体**

在将文字水印应用到幻灯片之前，先自定义其外观，使其与整体设计协调。您可以更改字体类型和大小，以确保水印既易读又美观。自定义字体还有助于强化品牌形象或匹配演示风格。

下面的代码片段演示了如何通过选择特定的拉丁字体并设置适当的字体高度来调整水印的字体设置：
```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```


### **设置水印文字颜色**

在应用水印之前，需要确保文字颜色设置得当，使其与幻灯片内容融合而不至于喧宾夺主。通过调整颜色的透明度（alpha）以及红、绿、蓝分量，您可以创建一种细微、半透明的水印，使其可见却不突兀。这种方式有助于在保护内容的同时，将注意力保持在主要演示上。

要设置水印文字的颜色，请使用以下代码：
```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```


### **居中文本水印**

将文本水印居中可以显著提升演示的整体美感，确保水印在幻灯片尺寸变化时始终保持对称位置。这不仅使幻灯片更具专业感，还能避免水印干扰主要内容。

下面的代码片段演示了如何计算幻灯片的中心位置并将文本水印放置在该位置：
```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


下图展示了最终效果。

![文本水印](text_watermark.png)

## **图片水印**

### **向演示文稿添加图片水印**

在许多情况下，图片水印能够提供独特的品牌元素或比文字水印更具视觉吸引力的替代方案。添加水印之前，请确保图像文件已准备好（例如 PNG 以支持透明）。下面的示例演示如何从文件系统加载图像，添加到演示文稿，然后使用形状的填充属性将其作为水印应用。
```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```


## **防止水印被编辑**

如果需要防止水印被编辑，请在形状上使用[IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock) 属性。使用此属性，您可以保护形状免于被选中、调整大小、重新定位、与其他元素组合、锁定其文字编辑等：
```cs
// 锁定水印形状，防止修改。
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```


## **将水印置于前面**

在 Aspose.Slides 中，形状的 Z 顺序可以通过[IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder) 方法设置。为此，需要从演示文稿的幻灯片列表中调用该方法，并传入形状引用及其顺序号。这样即可将形状置于前面或发送到幻灯片的背后。当需要将水印置于演示文稿前方时，此功能尤其有用：
```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```


## **设置水印旋转角度**

调整水印的旋转角度可以显著提升演示的视觉冲击力和低调感。例如，对角线水印相比水平或垂直水印更不突兀，同时仍能提供强有力的版权保护。下面的示例根据幻灯片尺寸计算合适的角度，使水印沿对角线排列。此动态计算确保无论幻灯片大小如何，水印始终保持有效。
```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```


## **为水印设置名称**

Aspose.Slides 允许您为形状设置名称。通过使用形状名称，您可以在将来访问该形状以进行修改或删除。要为水印形状设置名称，请将其赋值给[IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) 属性：
```cs
watermarkShape.Name = "watermark";
```


## **删除水印**

要删除水印形状，请使用[IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) 属性在幻灯片形状集合中找到它。然后，将水印形状传入[IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) 方法：
```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```


## **实时示例**

您可以尝试 Aspose.Slides 免费的[添加水印](https://products.aspose.app/slides/watermark)和[删除水印](https://products.aspose.app/slides/watermark/remove-watermark)在线工具。

![用于添加和删除水印的在线工具](online_tools.png)

## **常见问题**

**什么是水印，为什么要使用它？**

水印是叠加在幻灯片上的文字或图像，用于保护知识产权、提升品牌识别度或防止演示文稿被未经授权使用。

**我可以将水印添加到演示文稿的所有幻灯片吗？**

是的，Aspose.Slides 允许您以编程方式向演示文稿的每一张幻灯片添加水印。您可以遍历所有幻灯片并逐个应用水印设置。

**如何调整水印的透明度？**

您可以通过修改形状的填充设置（[FillFormat](https://reference.aspose.com/slides/net/aspose.slides/shape/fillformat/)）来调整水印的透明度，从而确保水印细腻且不会分散幻灯片内容的注意力。

**支持哪些图像格式作为水印？**

Aspose.Slides 支持多种图像格式，如 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自定义文字水印的字体和样式吗？**

可以，您可以选择任意字体、大小和样式，以匹配演示文稿的设计并保持品牌一致性。

**如何更改水印的位置或方向？**

您可以通过编程方式修改形状的坐标、大小和旋转属性，从而调整水印的位置和方向。