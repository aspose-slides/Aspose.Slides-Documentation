---
title: 水印
type: docs
weight: 40
url: /cpp/watermark/
keywords:
- 水印
- 添加水印
- 文字水印
- 图片水印
- PowerPoint
- 演示
- C++
- Aspose.Slides for C++
description: "在 C++ 中向 PowerPoint 演示文稿添加文本和图像水印"
---

## **关于水印**

在演示文稿中，**水印**是用于幻灯片或所有演示幻灯片中的文本或图像印记。通常，水印用于指示演示文稿是草稿（例如“草稿”水印）、它包含机密信息（例如“机密”水印）、指定它属于哪家公司（例如“公司名称”水印）、识别演示文稿作者等。水印有助于防止版权侵犯，表明不应复制该演示文稿。水印在 PowerPoint 和 OpenOffice 演示格式中均有使用。在 Aspose.Slides 中，您可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) 中，您可以通过多种方式在 PowerPoint 或 OpenOffice 文档中创建水印并修改其设计和行为。共同的方面是，要添加文本水印，您应使用 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 接口，而要添加图像水印，则使用 [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) 类或用图像填充水印形状。`PictureFrame` 实现了 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 接口，允许您使用形状对象的所有灵活设置。由于 `ITextFrame` 不是形状，其设置有限，因此它被封装在 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 对象中。

水印可以应用于两种方式：单个幻灯片或所有演示幻灯片。使用幻灯片母版可以将水印应用于所有演示幻灯片——水印添加到幻灯片母版上，在那里完全设计，并应用于所有幻灯片，而不会影响单个幻灯片上修改水印的权限。

水印通常被认为不允许其他用户进行编辑。为了防止水印（或更确切地说，水印的父形状）被编辑，Aspose.Slides 提供了形状锁定功能。可以在普通幻灯片或幻灯片母版上锁定特定形状。当水印形状在幻灯片母版上被锁定时，它将在所有演示幻灯片上被锁定。

您可以为水印设置名称，以便在将来希望删除它时，可以通过名称在幻灯片的形状中找到它。

您可以以任何方式设计水印；然而，水印通常具有一些共通特性，如居中对齐、旋转、前置位置等。我们将在下面的示例中考虑如何使用这些功能。

## **文本水印**

### **向幻灯片添加文本水印**

要在 PPT、PPTX 或 ODP 中添加文本水印，您可以先向幻灯片添加一个形状，然后在该形状上添加文本框。文本框由 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 接口表示。该类型不继承自 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)，后者具有广泛的属性集，可以灵活定位水印。因此，[ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 对象被封装在 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) 对象中。要将水印文本添加到形状，请使用 [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) 方法，如下所示。

```cpp
auto watermarkText = u"机密";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="另请参见" %}} 
- [如何使用 TextFrame 类](/slides/cpp/text-formatting/)
{{% /alert %}}

### **向演示文稿添加文本水印**

如果要将文本水印添加到整个演示文稿（即一次添加到所有幻灯片），请将其添加到 [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/)。其余逻辑与向单个幻灯片添加水印时相同——创建一个 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) 对象，然后使用 [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) 方法将水印添加到该对象。

```cpp
auto watermarkText = u"机密";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="另请参见" %}} 
- [如何使用幻灯片母版](/slides/cpp/slide-master/)
{{% /alert %}}

### **设置水印形状透明度**

默认情况下，矩形形状具有填充和线条颜色。以下代码行使形状透明。

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **设置文本水印的字体**

您可以如以下所示更改文本水印的字体。

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **设置水印文本颜色**

要设置水印文本的颜色，请使用以下代码：

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **将文本水印居中**

可以将水印居中放置在幻灯片上，为此，您可以执行以下操作：

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

下图显示最终效果。

![文本水印](text_watermark.png)

## **图像水印**

### **向演示文稿添加图像水印**

要向演示文稿幻灯片添加图像水印，您可以执行以下操作：

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **锁定水印以防编辑**

如果需要防止水印被编辑，请在形状上使用 [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/) 方法。通过该属性，您可以保护形状不被选择、调整大小、重新定位、与其他元素分组、锁定其文本不被编辑等：

```cpp
// 锁定水印形状以防修改
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **将水印置于前面**

在 Aspose.Slides 中，可以通过 [IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/) 方法设置形状的 Z 顺序。为此，您需要从演示文稿幻灯片列表中调用此方法，并将形状引用及其顺序号传递给该方法。这样，可以将形状置于前面或发送到幻灯片的后面。此功能尤其适用于需要将水印放在演示文稿前面的情况：

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **设置水印旋转**

以下是如何调整水印的旋转以使其斜对幻灯片的代码示例：

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **为水印设置名称**

Aspose.Slides 允许您设置形状的名称。使用形状名称，您可以在将来访问它以进行修改或删除。要设置水印形状的名称，请将其分配给 [IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/) 方法：

```cpp
watermarkShape->set_Name(u"水印");
```

## **移除水印**

要移除水印形状，请使用 [IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/) 方法在幻灯片形状中找到它。然后，将水印形状传递给 [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) 方法：

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"水印", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **实时示例**

您可以查看 **Aspose.Slides 免费** [添加水印](https://products.aspose.app/slides/watermark) 和 [移除水印](https://products.aspose.app/slides/watermark/remove-watermark) 在线工具。

![添加和移除水印的在线工具](online_tools.png)