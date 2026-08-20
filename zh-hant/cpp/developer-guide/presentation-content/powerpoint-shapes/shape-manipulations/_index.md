---
title: 使用 C++ 管理簡報形狀
linktitle: 形狀操作
type: docs
weight: 40
url: /zh-hant/cpp/shape-manipulations/
keywords:
- PowerPoint 形狀
- 簡報形狀
- 投影片上的形狀
- 尋找形狀
- 複製形狀
- 移除形狀
- 隱藏形狀
- 變更形狀順序
- 取得 interop 形狀 ID
- 形狀替代文字
- 形狀版面格式
- 形狀轉為 SVG
- 形狀匯出為 SVG
- 對齊形狀
- 翻轉形狀
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 識別、複製、移除、隱藏、重新排序、匯出、對齊以及翻轉簡報形狀。"
---
## **概觀**

Aspose.Slides for C++ 將投影片上的形狀表示為有序的 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/)。此集合同時是您尋找與修改形狀的地方，也是它們堆疊順序的來源：索引 `0` 為最背面的形狀，而最後的索引為最前面的形狀。

本文遵循此模型。首先說明如何可靠地識別形狀，接著展示如何複製、移除、隱藏以及重新排序形狀。最後的章節涵蓋版面層級的格式設定、SVG 匯出、對齊與翻轉設定。每個範例皆獨立，您可以僅使用工作流程所需的操作。

## **識別與尋找形狀**

在處理已知檔案時，集合索引相當方便，但它不是穩定的識別碼。新增、移除或重新排序形狀都會改變其索引。請依據簡報的撰寫與維護方式選擇合適的識別碼：

- [Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_name/) 對開發人員控制的範本很有用，且可在 PowerPoint 的「選取窗格」中輕鬆檢查。名稱可以編輯，但不保證唯一，若程式碼依賴名稱，請建立命名慣例。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_alternativetext/) 在已有可及性描述或作者提供的標籤已辨識形狀時很有用。它對使用者可見，可能會本地化或為可及性重新撰寫，且不保證唯一。請勿悄悄將有意義的可及性文字作為資料庫鍵。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_officeinteropshapeid/) 為唯讀標識符，在投影片內唯一，對應 PowerPoint 互通使用的形狀 ID。於與 PowerPoint 整合或需要在形狀生命週期內取得明確參照時使用。被複製或重新建立的形狀視為不同形狀，會取得自己的 ID。

相關的 [UniqueId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_uniqueid/) 屬性是簡報層級的，但其設計給外掛使用，且可能被重新指派。不要將其視為永久的外部鍵。若長期身分識別很重要，請將對應關係保存在應用程式資料中，並驗證預期的形狀仍然存在。

以下範例依 `Name` 搜尋，並回報投影片層級的 interop ID。若範本未包含預期的形狀，程式會回報此結果，而不會繼續使用錯誤的物件。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

當操作僅適用於特定形狀類型時，請先檢查介面再使用類型專屬成員。此範例僅在具名物件為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 時，才更新文字與替代文字。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **修改形狀集合**

新增、複製、移除與重新排序方法會立即作用於集合。若某個操作改變了形狀的數量或順序，請勿繼續依賴該操作之前取得的索引。

### **複製形狀**

[AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addclone/) 建立獨立的副本並附加至目標集合。[InsertClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/insertclone/) 也會建立副本，但會放置在指定的 Z 順序索引。接受座標的重載會在不改變大小的情況下移動複製品；接受寬度與高度的重載則可同時調整大小。

範例建立目標投影片，將標記矩形複製至前方，並在後方插入第二個複製品。對任一複製品的變更不會影響來源形狀。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

複製會將形狀的內容與格式一起複製，包括名稱與替代文字。當這些值必須唯一時，請為複製品指定新的邏輯識別碼。複雜形狀使用的資源由簡報負責管理，但複製品仍是具有新形狀身分的新集合項目。

### **移除形狀**

[Remove](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/remove/) 從其集合中刪除特定形狀物件。於索引迭代時若要移除多個符合項目，請從末端往前遍歷，以確保剩餘索引仍然有效。

此範例移除所有具指定名稱的形狀。它讀取目前的索引形狀，而非固定的集合項目，且不會不必要地轉型形狀。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

移除後，形狀數量與後續形狀的索引會改變。對未受影響形狀的參照比已儲存的索引更可靠。同時也要考慮連接線、動畫及其他可能參照被移除物件的簡報功能；移除可見形狀可能會影響不只投影片的外觀。

### **隱藏形狀**

將 [Hidden](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/set_hidden/) 設為 `true` 會保留形狀於集合中，但阻止其在一般投影片放映時顯示。其索引、格式與內容仍可供程式使用，因此隱藏適用於日後可能還原的可選元件。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

隱藏並非刪除或安全機制。使用者或程式仍可發現並取消隱藏，且它仍是簡報檔案的一部份。

### **變更 Z 順序**

重疊的形狀會依集合順序繪製。[Reorder](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/reorder/) 在不複製的情況下將現有形狀移動至目標索引。索引 `0` 為最背面；`Count - 1` 為最前面。

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

矩形最先建立，最初位於橢圓後方。將其移至最後索引即會置於前方。請在加入或複製所有相關形狀後再完成 Z 順序，因為這些操作會附加或插入新集合項目，可能改變原本的堆疊順序。

## **檢查版面投影片上的形狀**

普通投影片、版面投影片與母片都有各自的形狀集合。版面集合中的形狀與普通投影片上位置相同的形狀並非同一物件。當需要了解或變更版面所提供的格式時，請檢查版面形狀。

以下範例讀取每個版面形狀的 [FillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_fillformat/) 與 [LineFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_lineformat/)，而不假設所有形狀皆為 `AutoShape`。

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

編輯版面可能會影響使用該版面的多張投影片。變更版面形狀前，請確定普通投影片是繼承該物件或有本機覆寫，並測試所有使用該版面的投影片。

## **將形狀匯出為 SVG**

[WriteAsSvg](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/writeassvg/) 將單一形狀的渲染內容寫入串流。結果僅包含該形狀，而非整張投影片的背景或相鄰形狀。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

渲染時請保持簡報開啟。輸出受形狀格式以及字型、圖像等資源影響。若需要整個組成，請匯出投影片而非單一形狀。呼叫端負責管理串流，必須關閉或釋放它。

## **對齊形狀**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.util/slideutil/alignshapes/) 的重載可對全部形狀或選取的集合索引進行對齊。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapesalignmenttype/) 指定邊緣、中心線或分布模式。將 `alignToSlide` 設為 `true` 以使用投影片邊緣；設為 `false` 則使選取的形狀彼此對齊。

此範例將三個形狀對齊至投影片的上緣。回傳的形狀參考會在對齊前立即轉換為目前的索引。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

對齊會變更位置，而非 Z 順序。相對對齊通常需要至少兩個形狀，水平或垂直分布則需足夠的形狀以定義間距。若在呼叫方法前修改集合，請重新計算索引。

## **翻轉形狀**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定以及旋轉。其 `FlipH` 與 `FlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/nullablebool/)：`True` 表示啟用翻轉，`False` 表示停用，`NotDefined` 保持未指定/預設狀態。

以下的輸入簡報包含一個未翻轉的形狀。

![翻轉前的形狀](shape_to_be_flipped.png)

範例保留其他所有框架值，僅替換兩個翻轉設定。這點很重要，因為指派新的 [Frame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/set_frame/) 會取代整個框架。

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

儲存的形狀會水平與垂直鏡像，同時保留其位置、大小與旋轉。

![翻轉後的形狀](flipped_shape.png)

## **常見問題**

**我應該使用集合索引作為形狀識別碼嗎？**

僅在集合在使用索引前不會變動的短暫處理情境下使用。對於自行撰寫的範本，建議使用經驗證的 `Name` 或 `AlternativeText` 慣例；對於投影片層級的互通工作，則使用 `OfficeInteropShapeId`。

**隱藏形狀會將其從 Z 順序中移除嗎？**

不會。隱藏的形狀仍保留於集合中且索引不變。它仍可被找到、重新排序、編輯或再次顯示。

**為什麼複製的形狀會出現在另一個形狀前面？**

`AddClone` 會將複製品附加至集合的末端，也就是 Z 順序的最前端。可使用 `InsertClone` 來指定初始索引，或在全部形狀加入後使用 `Reorder`。