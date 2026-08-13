---
title: 在 C++ 中為簡報新增水印
linktitle: 水印
type: docs
weight: 40
url: /zh-hant/cpp/watermark/
keywords:
- 水印
- 文字水印
- 圖片水印
- 新增水印
- 更改水印
- 移除水印
- 刪除水印
- 新增水印至 PPT
- 新增水印至 PPTX
- 新增水印至 ODP
- 從 PPT 移除水印
- 從 PPTX 移除水印
- 從 ODP 移除水印
- 從 PPT 刪除水印
- 從 PPTX 刪除水印
- 從 ODP 刪除水印
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 C++ 中管理 PowerPoint 與 OpenDocument 簡報的文字與圖片水印，以標示草稿、機密資訊、版權等。"
---
## **簡介**

**水印** 在簡報中是用於投影片或整個簡報的文字或圖片印章。通常，水印用來表示簡報為草稿（例如「Draft」水印）、含有機密資訊（例如「Confidential」水印）、屬於哪家公司（例如「Company Name」水印）、標示簡報作者等。水印可透過標示簡報不應被複製，來防止版權侵害。PowerPoint 與 OpenOffice 簡報格式皆支援水印。於 Aspose.Slides 中，您可以為 PowerPoint PPT、PPTX 以及 OpenOffice ODP 檔案格式加入水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/cpp/)，有多種方法可在 PowerPoint 或 OpenOffice 文件中建立水印，並修改其設計與行為。共通點是：若要加入文字水印，請使用 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 介面；若要加入圖片水印，請使用 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/) 類別或以圖片填充水印形狀。`PictureFrame` 實作了 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 介面，允許您使用形狀物件的所有彈性設定。由於 `ITextFrame` 不是形狀且其設定較受限，會被包裝成 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 物件。

水印的套用方式有兩種：套用於單一投影片或套用於所有投影片。使用投影片母版（Slide Master）即可將水印套用至所有投影片——水印加入至投影片母版，於母版上完成設計，然後套用至所有投影片，且不影響個別投影片對水印的修改權限。

水印通常被視為不允許其他使用者編輯。為防止水印（或更確切說是水印的父形狀）被編輯，Aspose.Slides 提供形狀鎖定功能。可在普通投影片或投影片母版上鎖定特定形狀。當水印形狀於投影片母版上被鎖定時，所有投影片的該形狀皆會被鎖定。

您可以為水印設定名稱，以便日後若要刪除時，能依名稱在投影片的形狀集合中找到它。

水印的設計方式多樣；不過，水印通常具有置中對齊、旋轉、前置等共通特徵。以下範例將說明如何運用這些特性。

## **文字水印**

### **將文字水印加入投影片**

要在 PPT、PPTX 或 ODP 中加入文字水印，您可以先在投影片上新增一個形狀，然後在該形狀中加入文字框。文字框由 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 介面表示。此類型未繼承自 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/)，後者提供廣泛的屬性以彈性定位水印。因此，會將 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 物件包裝在 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 物件中。要將水印文字加入形狀，請使用下列示範的 [AddTextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/addtextframe/) 方法。

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

{{% alert color="info" title="另請參閱" %}} 
- [How to Use the TextFrame Class](/slides/zh-hant/cpp/text-formatting/)
{{% /alert %}}

### **將文字水印加入整份簡報**

若要一次為整份簡報（即全部投影片）加入文字水印，請將其加入至 [MasterSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/masterslide/)。其餘邏輯與在單一投影片加入水印相同——建立一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 物件，然後使用 [AddTextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/addtextframe/) 方法將水印加入其中。

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

{{% alert color="info" title="另請參閱" %}} 
- [How to Use the Slide Master](/slides/zh-hant/cpp/slide-master/)
{{% /alert %}}

### **設定水印形狀透明度**

預設情況下，矩形形狀會套用填充色與線條色。以下程式碼可使形狀變為透明。

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

### **設定文字水印的字型**

您可以如以下示範更改文字水印的字型。

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

### **設定水印文字顏色**

若要設定水印文字的顏色，請使用下列程式碼：

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

### **置中文字水印**

可將水印置中於投影片，請執行以下步驟：

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

下圖顯示最終結果。

![文字水印](text_watermark.png)

## **圖片水印**

### **將圖片水印加入簡報**

若要在簡報投影片中加入圖片水印，您可以執行以下操作：

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

## **防止水印被編輯**

若需要防止水印被編輯，請於形狀上使用 [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/get_autoshapelock/) 方法。透過此屬性，您可以保護形狀不被選取、調整大小、重新定位、與其他元素群組、鎖定文字編輯，等等：

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

// 鎖定水印形狀以防止修改
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **將水印移至最前面**

在 Aspose.Slides 中，可透過 [IShapeCollection::Reorder](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/reorder/) 方法設定形狀的 Z 軸順序。您需要從簡報的投影片集合呼叫此方法，並將形狀參考與其排序號傳入。如此即可將形狀移至最前面或送至投影片背後。此功能在需要將水印置於簡報前層時特別有用：

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

## **設定水印旋轉角度**

以下程式碼示範如何調整水印的旋轉角度，使其斜跨投影片：

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

## **為水印設定名稱**

Aspose.Slides 允許您為形狀設定名稱。透過名稱，未來可依名稱存取、修改或刪除該形狀。若要為水印形狀設定名稱，請呼叫 [IAutoShape::set_Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/set_name/) 方法：

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

## **移除水印**

若要移除水印形狀，請先使用 [IAutoShape::get_Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_name/) 方法在投影片形狀集合中找出該形狀，然後將其傳入 [IShapeCollection::Remove](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/remove/) 方法：

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

## **線上範例**

您可以試用 **Aspose.Slides 免費**的 [Add Watermark](https://products.aspose.app/slides/zh-hant/watermark) 與 [Remove Watermark](https://products.aspose.app/slides/zh-hant/watermark/remove-watermark) 線上工具。

![線上工具：加入與移除水印](online_tools.png)

## **常見問題**

### 什麼是水印，為什麼要使用它？

水印是套用在投影片上的文字或圖片覆蓋層，可協助保護智慧財產、提升品牌辨識度，或防止簡報未經授權的使用。

### 我可以將水印加入簡報的所有投影片嗎？

可以，Aspose.Slides 允許您以程式方式為簡報中的每一張投影片加入水印。您只需遍歷所有投影片，逐一套用水印設定。

### 如何調整水印的透明度？

您可以透過修改形狀的填充設定（[FillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/get_fillformat/)）來調整透明度，讓水印呈現柔和且不會分散投影片內容的注意力。

### 支援哪些圖片格式作為水印？

Aspose.Slides 支援多種圖片格式，例如 PNG、JPEG、GIF、BMP、SVG 等。

### 我可以自訂文字水印的字型與樣式嗎？

可以，您可以選擇任意字型、字體大小與樣式，以符合簡報的設計風格並維持品牌一致性。

### 如何變更水印的位置或方向？

您可以以程式方式修改形狀的座標、大小與旋轉屬性，來調整水印的位置與方向。