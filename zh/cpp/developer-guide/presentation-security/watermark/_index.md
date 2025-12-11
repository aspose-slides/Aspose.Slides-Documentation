---
title: 在 C++ 中为演示文稿添加水印
linktitle: 水印
type: docs
weight: 40
url: /zh/cpp/watermark/
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
- C++
- Aspose.Slides
description: "在 C++ 中管理 PowerPoint 和 OpenDocument 演示文稿的文字和图片水印，以标示草稿、机密信息、版权等。"
---

## **概述**

**水印** 在演示文稿中是用于幻灯片或整套幻灯片的文字或图像印记。通常，水印用于表明演示文稿是草稿（例如 “Draft” 水印），包含机密信息（例如 “Confidential” 水印），指明所属公司（例如 “Company Name” 水印），标识演示文稿作者等。水印通过指示演示文稿不应被复制，从而帮助防止版权侵权。水印可用于 PowerPoint 和 OpenOffice 演示文稿格式。在 Aspose.Slides 中，您可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) 中，有多种方式可以在 PowerPoint 或 OpenOffice 文档中创建水印并修改其设计和行为。共同点是：若要添加文字水印，应使用 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 接口；若要添加图片水印，则使用 [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) 类或以图片填充水印形状。`PictureFrame` 实现了 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 接口，因而可以使用形状对象的所有灵活设置。由于 `ITextFrame` 不是形状且其设置受限，它被包装成一个 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 对象。

水印的应用方式有两种：对单个幻灯片或对全部幻灯片。使用幻灯片母版（Slide Master）可以将水印应用到所有幻灯片——水印被添加到幻灯片母版并在此完整设计，然后自动应用到所有幻灯片，而不会影响对单个幻灯片上水印的修改权限。

水印通常被视为不允许其他用户编辑。为防止水印（或更确切地说是水印的父形状）被编辑，Aspose.Slides 提供形状锁定功能。可以在普通幻灯片或幻灯片母版上锁定特定形状。当在幻灯片母版上锁定水印形状时，它将在所有幻灯片上被锁定。

您可以为水印设置名称，以便将来想要删除时能够通过名称在幻灯片的形状集合中找到它。

水印的设计方式多种多样；不过，水印通常具有一些共同特征，如居中对齐、旋转、置于前置等。下面的示例将展示如何在代码中实现这些效果。

## **文字水印**

### **向单个幻灯片添加文字水印**

要在 PPT、PPTX 或 ODP 中添加文字水印，首先向幻灯片添加一个形状，然后向该形状添加文本框。文本框由 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 接口表示。该类型没有继承自 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)，后者提供了丰富的属性用于灵活定位水印。因此，[ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 对象被包装在 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) 对象中。要向形状添加水印文字，使用如下所示的 [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) 方法。
```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```


{{% alert color="primary" title="另见" %}} 
- [如何使用 TextFrame 类](/slides/zh/cpp/text-formatting/)
{{% /alert %}}

### **向整个演示文稿添加文字水印**

如果要一次性向整个演示文稿（即全部幻灯片）添加文字水印，请将其添加到 [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) 中。其余逻辑与向单个幻灯片添加水印相同——创建一个 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) 对象，然后使用 [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) 方法将水印添加进去。
```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```


{{% alert color="primary" title="另见" %}} 
- [如何使用幻灯片母版](/slides/zh/cpp/slide-master/)
{{% /alert %}}

### **设置水印形状的透明度**

默认情况下，矩形形状带有填充色和线条颜色。以下代码将形状设为透明。
```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```


### **为文字水印设置字体**

您可以按以下方式更改文字水印的字体。
```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```


### **设置水印文字颜色**

要设置水印文字的颜色，请使用以下代码：
```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```


### **将文字水印居中**

可以将水印居中显示，做法如下：
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


下面的图片展示了最终效果。

![文字水印](text_watermark.png)

## **图片水印**

### **向演示文稿添加图片水印**

要向演示文稿幻灯片添加图片水印，请按下面的步骤操作：
```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```


## **锁定水印防止编辑**

如果需要防止水印被编辑，请在形状上使用 [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/) 方法。通过此属性，您可以保护形状不被选中、调整大小、重新定位、与其他元素组合、锁定其文字编辑等：
```cpp
// 将水印形状锁定，防止修改
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```


## **将水印置于前端**

在 Aspose.Slides 中，形状的 Z 顺序可以通过 [IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/) 方法设置。您需要从演示文稿的幻灯片列表调用此方法，并传入形状引用及其顺序号。这样即可将形状置于前端或发送到幻灯片后方。该功能在需要将水印放在演示文稿前端时尤为有用：
```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```


## **设置水印旋转角度**

下面的代码示例演示了如何调整水印的旋转，使其斜向跨越幻灯片：
```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```


## **为水印设置名称**

Aspose.Slides 允许为形状设置名称。使用形状名称，您可以在以后访问它以进行修改或删除。要为水印形状设置名称，请调用 [IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/) 方法：
```cpp
watermarkShape->set_Name(u"watermark");
```


## **删除水印**

要删除水印形状，请使用 [IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/) 方法在幻灯片形状中定位它，然后将该形状传入 [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) 方法：
```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```


## **在线示例**

您可以尝试 Aspose.Slides 免费的在线工具 **Add Watermark** 和 **Remove Watermark**：
- [添加水印](https://products.aspose.app/slides/watermark)
- [删除水印](https://products.aspose.app/slides/watermark/remove-watermark)

![用于添加和删除水印的在线工具](online_tools.png)

## **常见问题**

**什么是水印，为什么要使用它？**

水印是覆盖在幻灯片上的文字或图像，用于保护知识产权、提升品牌识别度或防止演示文稿被未授权使用。

**我可以将水印添加到演示文稿的所有幻灯片吗？**

可以，Aspose.Slides 允许通过代码为演示文稿中的每一张幻灯片逐个或统一添加水印。

**如何调整水印的透明度？**

您可以通过修改形状的填充设置（[FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_fillformat/)）来调整透明度，使水印柔和且不干扰幻灯片内容。

**支持哪些图片格式作为水印？**

Aspose.Slides 支持多种图片格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自定义文字水印的字体和样式吗？**

可以，您可以选择任意字体、大小和样式，以匹配演示文稿的设计并保持品牌一致性。

**如何更改水印的位置或方向？**

您可以通过编程方式修改形状的坐标、尺寸和旋转属性来调整水印的位置和方向。