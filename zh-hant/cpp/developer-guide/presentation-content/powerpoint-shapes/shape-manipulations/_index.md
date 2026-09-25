---
title: 在 C++ 中管理簡報圖形
linktitle: 圖形操作
type: docs
weight: 40
url: /zh-hant/cpp/shape-manipulations/
keywords:
- PowerPoint 圖形
- 簡報圖形
- 投影片上的圖形
- 尋找圖形
- 複製圖形
- 移除圖形
- 隱藏圖形
- 變更圖形順序
- 取得 interop 圖形 ID
- 圖形替代文字
- 圖形調整點
- 預設圖形調整
- 圖形幾何
- 圖形版面格式
- 圖形為 SVG
- 圖形轉 SVG
- 對齊圖形
- 翻轉圖形
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 識別、調整、複製、移除、隱藏、重新排序、匯出、對齊與翻轉簡報圖形。"
---
## **概述**

Aspose.Slides for C++ 會將投影片上的圖形表示為有序的 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/)。此集合既是您尋找與修改圖形的地方，也是它們堆疊順序的來源：索引 `0` 為最背面的圖形，最後一個索引則為最前面的圖形。

本篇文章遵循此模型。首先說明如何可靠地識別圖形並修改預設的圖形調整點，接著示範如何複製、移除、隱藏與重新排序圖形。最後的章節涵蓋版面層級的格式設定、SVG 匯出、對齊與翻轉設定。每個範例皆獨立，您可僅使用工作流程所需的操作。

## **識別與尋找圖形**

在處理已知檔案時，集合索引相當方便，但它們並非穩定的識別子。新增、移除或重新排序圖形都可能改變其索引。請依照簡報的編寫與維護方式選擇適當的識別子：

- [Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_name/) 在開發者控制的模板中很有用，且可在 PowerPoint 的「選取窗格」中直接檢視。名稱可編輯且不保證唯一，若程式碼依賴名稱，請建立命名慣例。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_alternativetext/) 在已提供可存取性說明或作者自訂標籤的情況下很有用。此文字會對使用者可見，可能會本地化或為可存取性重新撰寫，亦不保證唯一。請勿將有意義的可存取性文字悄悄改作資料庫鍵值。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_officeinteropshapeid/) 為唯讀識別子，於投影片內唯一，對應 PowerPoint 互通使用的圖形 ID。當與 PowerPoint 整合或需要在圖形生命週期內取得明確參照時使用。被複製或重新建立的圖形視為不同圖形，會取得自己的 ID。

相關的 [UniqueId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_uniqueid/) 屬性是簡報範圍的，但僅供外掛使用，且可能被重新指派。不要將它當作永久的外部鍵。若需要長期辨識，請在應用程式資料中保留對映，並驗證預期的圖形仍然存在。

若要閱讀並更新 alternative text 的標題與說明，請參考 [Manage Alternative Text Titles and Descriptions](/slides/zh-hant/cpp/presentation-accessibility/)。使用 alternative text 向讀者說明視覺內容的意義，並將其與程式碼用來尋找圖形的名稱分開管理。

以下範例以 `Name` 為條件搜尋，並回報投影片範圍的 interop ID。當模板未包含預期的圖形時，程式會回報此結果，而不會繼續使用錯誤的物件。

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

當操作特定於圖形類型時，請先檢查介面再使用類型專屬的成員。此範例僅在命名的物件為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 時更新文字與 alternative text。

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

## **識別與修改預設圖形調整**

預設幾何圖形可能會公開調整點，用以控制如角落大小、箭頭比例或弧度等特性。可透過唯讀的 [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igeometryshape/get_adjustments/) 集合存取。集合本身由圖形提供，但每個 [IAdjustValue](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iadjustvalue/) 含有可變更的值。

不要只依賴固定的集合索引。遍歷所有調整並檢查唯讀的 [IAdjustValue::get_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iadjustvalue/get_type/) 屬性，其 [ShapeAdjustmentType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapeadjustmenttype/) 值描述此調整控制的內容。唯讀的 [IAdjustValue::get_Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iadjustvalue/get_name/) 屬性提供額外的識別資訊，當同一語意類型出現多次時特別有用。

使用與調整語意相符的值屬性：

| 調整類型 | 目的 | 要變更的值 |
|---|---|---|
| `CornerSize` | 圓角的大小 | [RawValue](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | 箭尾的粗細 | `RawValue` |
| `ArrowheadLength` | 箭頭的長度 | `RawValue` |
| `ArrowheadWidth` | 箭頭的寬度 | `RawValue` |
| `StartAngle` | 扇形或弧線的起始角度 | [AngleValue](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | 扇形或弧線的結束角度 | `AngleValue` |

`Type` 與 `Name` 無法指派。`RawValue` 為預設幾何單位的可讀寫整數，`AngleValue` 為度數的可讀寫角度。調整的數量、順序、意義與有效範圍取決於預設的 [ShapeType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igeometryshape/get_shapetype/)。對於某一預設有效的值，於另一預設可能無效或產生不同效果。

當 `Type` 為 `ShapeAdjustmentType::Custom` 時，API 不會辨識標準語意。請檢查 `Name`、預設類型與現有值，除非已知預期的意義與範圍，否則保持調整不變。即使是已識別的類型，若同一類型出現多次，也請先確認再選擇值。[Connector](/slides/zh-hant/cpp/connector/) 文章示範了連接線彎曲調整的情況。

以下完整範例建立三種預設圖形的預設與修改版本。它遍歷每個調整，回報 `Name` 與 `Type`，以 `RawValue` 變更尺寸相關值，以 `AngleValue` 變更角度，並儲存結果。左側保留預設幾何；右側則顯示調整後的圓角矩形、四向箭頭與扇形。

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// 為預設和調整後的圖形欄位新增標題。
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

在變更值之前先檢查語意類型，可使程式碼明確表達意圖，避免假設特定集合索引在不同預設圖形中具有相同意義。

## **修改圖形集合**

新增、複製、移除與重新排序方法會立即作用於集合。若某個操作改變了圖形的數量或順序，請勿再依賴該操作前取得的索引。

### **複製圖形**

[AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addclone/) 會建立獨立的副本並附加至目標集合的末端。[InsertClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/insertclone/) 也會建立副本，但會放置在指定的 Z 軸索引位置。接受座標的 overload 會在不改變大小的情況下移動副本；接受寬度與高度的 overload 則可同時調整大小。

此範例建立目標投影片，將標記矩形複製至前端，並在背端插入第二個副本。對任一副本的變更皆不會影響來源圖形。

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

複製會將圖形的內容與格式一起複製，包括其名稱與 alternative text。若這些值必須唯一，請為副本指派新的邏輯識別子。複雜圖形使用的資源由簡報處理，但副本仍為新的集合項目，擁有新的圖形身分。

### **移除圖形**

[Remove](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/remove/) 會從其集合中刪除特定的圖形物件。若在索引迭代過程中移除多個相符項目，請從集合末端向前遍歷，以確保每個剩餘索引仍然有效。

此範例移除所有具指定名稱的圖形。它讀取目前的索引圖形，而非固定的集合項目，亦未不必要地轉型圖形。

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

移除後，圖形計數與後續圖形的索引皆會變更。對未受影響的圖形的參照比儲存的索引更可靠。亦請考慮連接線、動畫與其他可能參照已移除物件的簡報功能；移除可見圖形可能會改變超出投影片外觀的項目。

### **隱藏圖形**

將 [Hidden](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/set_hidden/) 設為 `true` 會保留圖形於集合中，但阻止其在一般投影片放映時顯示。其索引、格式與內容仍可供程式碼存取，因此隱藏適用於可能稍後復原的可選元素。

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

隱藏並非刪除或安全保護。使用者或程式碼仍能發現並取消隱藏，且它仍是簡報檔的一部份。

### **變更 Z 軸順序**

重疊的圖形會依集合順序繪製。[Reorder](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/reorder/) 會將現有圖形移動至目標索引，且不會產生副本。索引 `0` 為最背面；`Count - 1` 為最前面。

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

矩形最先建立，最初位於橢圓之後。將它移動至最後索引即可放到前面。請在加入或複製所有相關圖形後最後確認 Z 軸順序，因為這些操作會在集合中新增或插入項目，可能改變預期的堆疊。

## **檢查版面投影片上的圖形**

普通投影片、版面投影片與母片投影片各自擁有獨立的圖形集合。版面集合中的圖形並非與普通投影片上相同位置圖形的同一物件。當您需要了解或變更版面提供的格式時，請檢查版面圖形。

以下範例讀取每個版面圖形的 [FillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_fillformat/) 與 [LineFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_lineformat/)，且不假設每個圖形都是 `AutoShape`。

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

編輯版面可能會影響使用該版面的多個投影片。變更版面圖形前，請先確認普通投影片是繼承該物件，還是已有本地覆寫，並測試所有使用該版面的投影片。

## **將圖形匯出為 SVG**

[WriteAsSvg](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/writeassvg/) 會將單一圖形的渲染內容寫入串流。結果僅包含該圖形本身，不會包含整張投影片的背景或相鄰圖形。

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

渲染時請保持簡報開啟。輸出取決於圖形的格式以及字型、圖片等資源。若需要整個構圖，請匯出投影片而非單一圖形。呼叫端負責擁有並關閉或釋放串流。

## **對齊圖形**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.util/slideutil/alignshapes/) 的 overload 可對齊全部圖形或指定的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapesalignmenttype/) 指定要對齊的邊緣、中心線或分布模式。將 `alignToSlide` 設為 `true` 以使用投影片邊緣；設為 `false` 則相對於彼此對齊所選圖形。

此範例將三個圖形對齊至投影片的上緣。對齊前會立即將回傳的圖形參考轉換為目前的索引。

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

對齊會變更位置，而非 Z 軸順序。相對對齊通常需要至少兩個圖形，水平或垂直分布則需要足夠的圖形以定義間距。若在呼叫方法前修改了集合，請重新計算索引。

## **翻轉圖形**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定，以及旋轉角度。其 `FlipH` 與 `FlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/nullablebool/)：`True` 表示啟用翻轉，`False` 表示停用，`NotDefined` 則保留未指定/預設狀態。

下面的輸入簡報包含一個未翻轉的圖形。

![The shape before flipping](shape_to_be_flipped.png)

範例保留其他所有框架值，僅取代兩個翻轉設定。這很重要，因為指派新的 [Frame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/set_frame/) 會取代整個框架。

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

儲存的圖形會水平與垂直鏡像，同時保留其位置、大小與旋轉。

![The shape after flipping](flipped_shape.png)

## **常見問題**

**我可以將集合索引當作圖形識別子嗎？**

僅在集合在使用索引前不會變動的短暫處理情境下可行。對於作者化的模板，建議使用已驗證的 `Name` 或 `AlternativeText` 約定；對於投影片範圍的互通工作，則使用 `OfficeInteropShapeId`。

**隱藏圖形會從 Z 軸順序中移除嗎？**

不會。隱藏的圖形仍保留在集合中，索引不變。它仍可被尋找、重新排序、編輯或再次顯示。

**為什麼複製的圖形會出現在另一圖形的前面？**

`AddClone` 會將副本附加至集合的末端，也就是 Z 軸的前面。若要指定初始索引，可使用 `InsertClone`，或在加入所有圖形後使用 `Reorder`。

**我可以使用固定索引來辨識預設圖形調整嗎？**

僅在已驗證特定預設與集合布局後方可。建議遍歷 `IGeometryShape::get_Adjustments` 並檢查 `IAdjustValue::get_Type`；若同一語意類型出現多次，請使用 `IAdjustValue::get_Name` 作為額外資訊。