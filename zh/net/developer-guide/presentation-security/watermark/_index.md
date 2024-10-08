---
title: 水印
type: docs
weight: 40
url: /net/watermark/
keywords:
- 水印
- 添加水印
- 文字水印
- 图片水印
- PowerPoint
- 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中向 PowerPoint 演示文稿添加文字和图片水印"
---

## **关于水印**

**水印**是演示文稿中用于幻灯片或所有演示文稿幻灯片的文本或图片印记。通常，水印用于指示演示文稿是草稿（例如，“草稿”水印）、包含机密信息（例如，“机密”水印）、指定属于哪家公司（例如，“公司名称”水印）、识别演示文稿作者等。水印通过表明演示文稿不应被复制来帮助防止版权侵犯。水印在 PowerPoint 和 OpenOffice 演示文稿格式中都被使用。在 Aspose.Slides 中，您可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/net/) 中，您可以以多种方式在 PowerPoint 或 OpenOffice 文档中创建水印并修改其设计和行为。共同的方面是，添加文本水印时，您应该使用 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 接口，而要添加图片水印，则使用 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) 类或用图片填充水印形状。`PictureFrame` 实现了 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) 接口，使您可以使用形状对象的所有灵活设置。由于 `ITextFrame` 不是形状，其设置是有限的，因此它被包装在一个 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) 对象中。

水印可以应用于两种方式：单个幻灯片或所有演示文稿幻灯片。幻灯片母版用于将水印应用于所有演示文稿幻灯片——水印被添加到幻灯片母版中，在那里完全设计，并应用于所有幻灯片，而不影响对单个幻灯片上水印的修改权限。

水印通常被认为是其他用户不可编辑的。为了防止水印（或者更确切地说，是水印的父形状）被编辑，Aspose.Slides 提供了形状锁定功能。特定的形状可以在正常幻灯片或幻灯片母版上被锁定。当水印形状在幻灯片母版上被锁定时，它将在所有演示文稿幻灯片上被锁定。

您可以为水印设置一个名称，以便将来如果您想删除它，您可以通过名称在幻灯片的形状中找到它。

您可以以任何方式设计水印；然而，水印通常具有一些共同特征，如居中对齐、旋转、前景位置等。我们将在下面的示例中考虑如何使用这些特征。

## **文本水印**

### **向幻灯片添加文本水印**

要在 PPT、PPTX 或 ODP 中添加文本水印，您可以首先在幻灯片上添加一个形状，然后将文本框添加到此形状中。文本框由 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) 接口表示。此类型没有从 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 继承，而后者具有用于以灵活方式定位水印的广泛属性集。因此， [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) 对象被包装在一个 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 对象中。要将水印文本添加到形状中，请使用 [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) 方法，如下所示。

```cs
string watermarkText = "机密";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="另见" %}} 
- [如何使用 TextFrame 类](/slides/net/text-formatting/)
{{% /alert %}}

### **向演示文稿添加文本水印**

如果您想向整个演示文稿（即一次性所有幻灯片）添加文本水印，请将其添加到 [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/)。剩下的逻辑与向单个幻灯片添加水印时相同——创建一个 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 对象，然后使用 [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) 方法将水印添加到其中。

```cs
string watermarkText = "机密";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="另见" %}} 
- [如何使用幻灯片母版](/slides/net/slide-master/)
{{% /alert %}}

### **设置水印形状透明度**

默认情况下，矩形形状的填充和线条颜色已排序。以下代码行使形状透明。

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **设置文本水印的字体**

您可以按如下所示更改文本水印的字体。

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **设置水印文本颜色**

要设置水印文本的颜色，请使用以下代码：

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **将文本水印居中**

可以将水印居中放置在幻灯片上，您可以执行以下操作：

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

下图显示了最终结果。

![文本水印](text_watermark.png)

## **图片水印**

### **向演示文稿添加图片水印**

要向演示文稿幻灯片添加图片水印，您可以执行以下操作：

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **锁定水印以防编辑**

如果需要防止水印被编辑，请在形状上使用 [IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock) 属性。使用此属性，您可以保护形状不被选择、调整大小、重新定位、与其他元素组合、锁定文本不被编辑等：

```cs
// 锁定水印形状以防修改
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **将水印置于最前**

在 Aspose.Slides 中，可以通过 [IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder) 方法设置形状的 Z 顺序。为此，您需要从演示文稿幻灯片列表调用此方法，并将形状引用和其顺序号传递给该方法。通过这种方式，可以将形状带到前面或将其发送到幻灯片的后面。如果您需要将水印放置在演示文稿前面，此功能尤其有用：

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **设置水印旋转**

以下是如何调整水印旋转以使其对角放置在幻灯片上的代码示例：

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **为水印设置名称**

Aspose.Slides 允许您设置形状的名称。通过使用形状名称，您可以在将来访问它以进行修改或删除。要为水印形状设置名称，请将其分配给 [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) 属性：

```cs
watermarkShape.Name = "watermark";
```

## **删除水印**

要删除水印形状，请使用 [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) 属性在幻灯片形状中找到它。然后，将水印形状传递给 [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) 方法：

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

您可以查看 **Aspose.Slides 免费** [添加水印](https://products.aspose.app/slides/watermark) 和 [删除水印](https://products.aspose.app/slides/watermark/remove-watermark) 在线工具。

![在线添加和删除水印的工具](online_tools.png)