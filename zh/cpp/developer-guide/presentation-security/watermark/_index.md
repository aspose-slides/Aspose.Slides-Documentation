---
title: 在 C++ 中为演示文稿添加水印
linktitle: 水印
type: docs
weight: 40
url: /zh/cpp/watermark/
keywords:
- 水印
- 文本水印
- 图像水印
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
description: "在 C++ 中管理 PowerPoint 和 OpenDocument 演示文稿的文本和图像水印，以标示草稿、机密信息、版权等。"
---
## **简介**

**水印** 在演示文稿中是用于幻灯片或整个演示文稿的文本或图像印记。通常，水印用于指示演示文稿是草稿（例如 “Draft” 水印）、包含机密信息（例如 “Confidential” 水印）、注明所属公司（例如 “Company Name” 水印）、标识演示文稿作者等。水印通过表明演示文稿不应被复制，帮助防止版权侵权。水印可用于 PowerPoint 和 OpenOffice 演示文稿格式。在 Aspose.Slides 中，您可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh/cpp/) 中，有多种方式可以在 PowerPoint 或 OpenOffice 文档中创建水印并修改其外观和行为。共同点是，添加文本水印应使用 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 接口，添加图像水印则使用 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pictureframe/) 类或将水印形状填充为图像。`PictureFrame` 实现了 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/) 接口，允许您使用形状对象的所有灵活设置。由于 `ITextFrame` 不是形状且其设置受限，它会被包装成一个 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/) 对象。

水印有两种应用方式：应用于单个幻灯片或应用于所有幻灯片。使用幻灯片母版（Slide Master）可将水印应用于所有幻灯片——水印添加到幻灯片母版，在母版上完整设计后，自动应用到所有幻灯片，且不会影响对单个幻灯片上水印的修改权限。

水印通常被视为不允许其他用户编辑。为防止水印（或更确切地说是水印的父形状）被编辑，Aspose.Slides 提供了形状锁定功能。可以在普通幻灯片或幻灯片母版上锁定特定形状。当在幻灯片母版上锁定水印形状时，它将在所有幻灯片上被锁定。

您可以为水印设置名称，以便以后通过名称在幻灯片的形状集合中查找并删除它。

水印的设计方式多种多样；不过，水印通常具有居中、旋转、置于前面等共性特征。下面的示例将演示如何使用这些特性。

## **文本水印**

### **向幻灯片添加文本水印**

要在 PPT、PPTX 或 ODP 中添加文本水印，您可以先向幻灯片添加一个形状，然后向该形状添加文本框。文本框由 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 接口表示。该类型未继承自 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/)，后者提供了用于灵活定位水印的丰富属性。因此，`ITextFrame` 对象会被包装在一个 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/) 对象中。要向形状添加水印文本，请使用如下所示的 [AddTextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/addtextframe/) 方法。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/zh/cpp/text-formatting/)
{{% /alert %}}

### **向整个演示文稿添加文本水印**

如果要一次性向整个演示文稿（即所有幻灯片）添加文本水印，请将其添加到 [MasterSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/masterslide/) 中。其余逻辑与向单个幻灯片添加水印相同——创建一个 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/) 对象，然后使用 [AddTextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/addtextframe/) 方法将水印添加进去。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="See also" %}} 
- [How to Use the Slide Master](/slides/zh/cpp/slide-master/)
{{% /alert %}}

### **设置水印形状的透明度**

默认情况下，矩形形状带有填充颜色和线条颜色。下面的代码将形状设置为透明。

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **为文本水印设置字体**

您可以按下面的示例更改文本水印的字体。

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **设置水印文本颜色**

要设置水印文本的颜色，请使用以下代码：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **居中文本水印**

可以将水印居中显示在幻灯片上，代码如下：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

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

![The text watermark](text_watermark.png)

## **图像水印**

### **向演示文稿添加图像水印**

要在演示文稿幻灯片中添加图像水印，您可以按如下方式操作：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **锁定水印以防编辑**

如果需要防止水印被编辑，请对形状使用 [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/get_autoshapelock/) 方法。通过此属性，您可以保护形状不被选中、调整大小、重新定位、与其他元素分组、锁定其文本编辑等：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// 锁定水印形状以防止修改
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **将水印置于前面**

在 Aspose.Slides 中，可通过 [IShapeCollection::Reorder](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/reorder/) 方法设置形状的 Z 顺序。您需要在演示文稿的幻灯片列表上调用此方法，并将形状引用及其顺序号传入。这样即可将形状置于前面或置于幻灯片背面。当需要将水印放在演示文稿的前面时，此功能尤为有用：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **设置水印旋转角度**

以下代码示例演示了如何调整水印的旋转，使其以对角线方式跨越幻灯片：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **为水印设置名称**

Aspose.Slides 允许您为形状设置名称。利用形状名称，您以后可以通过名称访问并修改或删除该形状。要为水印形状设置名称，请调用 [IAutoShape::set_Name](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/set_name/) 方法：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **删除水印**

要删除水印形状，请使用 [IAutoShape::get_Name](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_name/) 方法在幻灯片形状中找到它，然后将该水印形状传入 [IShapeCollection::Remove](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/remove/) 方法：

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **实时示例**

您可以尝试 Aspose.Slides 免费的在线工具 **Add Watermark** 和 **Remove Watermark**：

![Online tools to add and remove watermarks](online_tools.png)

## **常见问题**

### 什么是水印，为什么要使用它？

水印是覆盖在幻灯片上的文本或图像，用于保护知识产权、提升品牌识别度或防止演示文稿被未授权使用。

### 能否一次性向演示文稿的所有幻灯片添加水印？

可以，Aspose.Slides 允许您通过代码遍历所有幻灯片并分别应用水印，从而实现批量添加。

### 如何调整水印的透明度？

您可以通过修改形状的填充设置（[FillFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/get_fillformat/)）来调节水印的透明度，使其既不显眼又能起到保护作用。

### 支持哪些图像格式作为水印？

Aspose.Slides 支持多种图像格式，例如 PNG、JPEG、GIF、BMP、SVG 等。

### 是否可以自定义文本水印的字体和样式？

可以，您可以选择任意字体、字号和样式，以匹配演示文稿的设计并保持品牌一致性。

### 如何更改水印的位置或方向？

可以通过编程方式修改形状的坐标、大小和旋转属性，从而调整水印的具体位置和朝向。