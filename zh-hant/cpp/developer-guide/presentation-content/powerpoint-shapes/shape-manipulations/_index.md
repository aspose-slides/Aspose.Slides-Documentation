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
- 刪除圖形
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
description: "了解如何使用 Aspose.Slides for C++ 識別、調整、複製、刪除、隱藏、重新排序、匯出、對齊及翻轉簡報圖形。"
---
## **概述**

Aspose.Slides for C++ 將投影片上的圖形表示為有序的 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/)。此集合同時是尋找與修改圖形的所在，也是它們堆疊順序的來源：索引 `0` 為最背面的圖形，而最後一個索引則是最前面的圖形。

本文遵循此模型。首先說明如何可靠地識別圖形並修改預設的圖形調整點，接著示範如何複製、刪除、隱藏與重新排序圖形。最後的章節涵蓋版面層級的格式設定、SVG 匯出、對齊以及翻轉設定。每個範例皆相互獨立，您可以只使用工作流程中需要的操作。

## **識別與尋找圖形**

在處理已知檔案時，集合索引相當方便，但它們並非穩定的識別子。新增、移除或重新排序圖形都會改變其索引。請依照投影片的製作與維護方式選擇識別子：

- [Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_name/) 適用於開發者掌控的範本，且可在 PowerPoint 的「選取窗格」中輕鬆檢查。名稱可以編輯，但不保證唯一，所以如果程式碼依賴名稱，請建立命名慣例。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_alternativetext/) 適用於已提供可及性描述或作者標籤以辨識圖形的情況。此文字會顯示給使用者，可能會本地化或為可及性重新撰寫，且同樣不保證唯一。請勿將有意義的可及性文字靜默地當作資料庫鍵使用。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_officeinteropshapeid/) 為唯讀識別子，在同一投影片內唯一，且對應 PowerPoint interop 使用的圖形 ID。當與 PowerPoint 整合或需要在圖形生命週期內取得明確參照時使用。已複製或重新建立的圖形會是不同的圖形，會取得自己的 ID。

相關的 [UniqueId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_uniqueid/) 屬性具有整份簡報的範圍，但僅供外掛使用，且可能被重新指派。它不應被視為永久的外部鍵。若長期身份辨識至關重要，請在應用程式資料中保留映射，並驗證預期的圖形仍然存在。

以下範例透過 `Name` 進行搜尋，並回報投影片範圍的 interop ID。當範本未包含預期圖形時，程式會回報該結果而非持續使用錯誤的物件。

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

當操作特定於圖形類型時，請在使用型別特定成員前先檢查介面。此範例僅在命名的物件是 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 時，才更新文字與替代文字。

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

預設幾何圖形可以公開調整點，以控制角落大小、箭頭比例或弧度等特徵。透過唯讀的 [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igeometryshape/get_adjustments/) 集合存取它們。集合本身由圖形提供，但每個 [IAdjustValue](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iadjustvalue/) 含有可變更的值。

請不要只依賴固定的集合索引。遍歷所有調整項目，並檢查唯讀的 [IAdjustValue::get_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iadjustvalue/get_type/) 屬性，其 [ShapeAdjustmentType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapeadjustmenttype/) 值說明此調整控制什麼。唯讀的 [IAdjustValue::get_Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iadjustvalue/get_name/) 屬性提供額外的識別資訊，當同一語意類型出現多次時特別有用。

使用與調整意義相符的值屬性：

| 調整類型 | 目的 | 要變更的值 |
|---|---|---|
| `CornerSize` | 圓角的大小 | [RawValue](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | 箭頭尾部的粗細 | `RawValue` |
| `ArrowheadLength` | 箭頭頭部的長度 | `RawValue` |
| `ArrowheadWidth` | 箭頭頭部的寬度 | `RawValue` |
| `StartAngle` | 饋形或弧形的起始角度 | [AngleValue](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | 饋形或弧形的結束角度 | `AngleValue` |

`Type` 與 `Name` 無法指派。`RawValue` 為預設幾何單位的讀寫整數，而 `AngleValue` 為以度為單位的讀寫角度。調整的數量、順序、意義與有效範圍皆取決於預設的 [ShapeType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igeometryshape/get_shapetype/)。對一個預設有效的值，對另一個預設可能無效或產生不同效果。

當 `Type` 為 `ShapeAdjustmentType::Custom` 時，API 無法辨識標準語意。請檢查 `Name`、預設類型與現有值，除非明確知道其意義與範圍，否則保持調整不變。即使是已辨識的類型，也要先確認同一類型是否出現多次再選擇值。[Connector](/slides/zh-hant/cpp/connector/) 文章說明了連線彎曲調整的情況。

以下完整範例建立三個預設圖形的預設與修改版本。它遍歷每個調整項目，回報其 `Name` 與 `Type`，透過 `RawValue` 變更尺寸相關值，透過 `AngleValue` 變更角度，並儲存結果。左欄保留預設幾何，右欄則顯示已調整的圓角矩形、四向箭頭與餅形。

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

// 為預設與已調整的圖形欄位新增標題。
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

在變更值之前先檢查語意類型，可使程式碼對其意圖保持明確，並避免假設特定集合索引在不同預設圖形間具有相同意義。

## **修改圖形集合**

新增、複製、刪除與重新排序方法會立即作用於集合。若操作改變了圖形的數量或順序，請勿繼續依賴事先取得的索引。

### **複製圖形**

[AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addclone/) 會建立獨立的副本並將其附加至目標集合的末端。[InsertClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/insertclone/) 也會建立副本，但會放置在指定的 Z 軸索引位置。接受座標的重載會在不改變尺寸的前提下移動副本；接受寬度與高度的重載則可同時調整尺寸。

此範例建立目的投影片，將帶標籤的矩形複製到前方，並在背後插入第二個副本。對任一副本的變更都不會影響來源圖形。

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

複製會將圖形的內容與格式（包括名稱與替代文字）一併複製。若這些值必須唯一，請為副本指派新的邏輯識別子。複雜圖形使用的資源由簡報負責處理，但副本仍是集合中新項目，擁有新的圖形身分。

### **刪除圖形**

[Remove](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/remove/) 會從其所在集合中刪除特定圖形物件。於索引迭代期間刪除多個符合條件的圖形時，請從集合尾端開始遍歷，以保持剩餘索引的有效性。

此範例刪除所有具有指定名稱的圖形。它讀取當前的索引圖形，而非固定的集合項目，且不會不必要地轉型圖形。

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

刪除後，圖形總數以及之後圖形的索引皆會改變。對未受影響的圖形保有的參照比保存的索引更可靠。也請考慮連線、動畫及其他可能參照被刪除物件的簡報功能；刪除可見圖形可能會改變投影片的外觀之外的更多內容。

### **隱藏圖形**

將 [Hidden](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/set_hidden/) 設為 `true` 會保留圖形於集合中，但不會在一般投影片放映時顯示。其索引、格式與內容仍可供程式碼存取，因此隱藏適用於可能日後復原的可選元素。

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

隱藏並非刪除或安全機制。使用者或程式碼仍可發現並取消隱藏，且圖形仍屬於簡報檔案的一部份。

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

矩形最先建立，起初位於橢圓之後。將其移至最後一個索引後即會出現在前方。請在加入或複製所有相關圖形之後再最終確定 Z 軸順序，因為這些操作會在集合中追加或插入新項目，可能會改變原本的堆疊。

## **檢查版面投影片上的圖形**

普通投影片、版面投影片與母片皆擁有各自的圖形集合。版面集合中的圖形並非與普通投影片上位置相同的圖形同一物件。當您需要了解或變更版面提供的格式時，請檢查版面圖形。

以下範例讀取每個版面圖形的 [FillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_fillformat/) 與 [LineFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_lineformat/)，且不假設每個圖形皆為 `AutoShape`。

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

編輯版面可能會影響使用該版面的多張投影片。變更版面圖形前，請先確認普通投影片是繼承該物件或有本地覆寫，並測試所有使用該版面的投影片。

## **將圖形匯出為 SVG**

[WriteAsSvg](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/writeassvg/) 會將單一圖形的渲染內容寫入串流。結果僅包含該圖形，而不會包含整張投影片的背景或相鄰圖形。

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

在渲染期間請保持簡報開啟。輸出內容取決於圖形的格式以及字型、影像等資源。若需要整個版面，請匯出投影片而非單一圖形。呼叫方負責擁有串流並必須關閉或釋放它。

## **對齊圖形**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.util/slideutil/alignshapes/) 的多個重載可對全部圖形或選取的集合索引進行對齊。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapesalignmenttype/) 指定邊緣、中心線或分布模式。將 `alignToSlide` 設為 `true` 會使用投影片邊緣；設為 `false` 則會相對於彼此對齊選取的圖形。

此範例將三個圖形對齊至投影片的上緣。對齊前會立即將回傳的圖形參照轉換為目前的索引。

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

對齊會改變位置，而非 Z 軸順序。相對對齊通常至少需要兩個圖形，而水平或垂直分布則需要足夠的圖形來定義間距。若在呼叫方法前修改了集合，請重新計算索引。

## **翻轉圖形**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapeframe/) 類別儲存位置、尺寸、水平與垂直翻轉設定，以及旋轉角度。其 `FlipH` 與 `FlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/nullablebool/)：`True` 代表啟用翻轉，`False` 代表停用，`NotDefined` 則保留未指定/預設狀態。

下方的輸入簡報包含一個未翻轉的圖形。

![翻轉前的圖形](shape_to_be_flipped.png)

此範例保留其他所有框架值，僅取代兩個翻轉設定。這點很重要，因為指派新的 [Frame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/set_frame/) 會取代整個框架。

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

儲存後的圖形會水平與垂直鏡像，且保持其位置、尺寸與旋轉。

![翻轉後的圖形](flipped_shape.png)

## **常見問與答**

**我可以使用集合索引作為圖形識別子嗎？**

僅在集合不會在使用索引前變動的短暫處理情境下可行。對於製作的範本，建議使用已驗證的 `Name` 或 `AlternativeText` 慣例；對於投影片範圍的 interop 作業，則使用 `OfficeInteropShapeId`。

**隱藏圖形會將它從 Z 軸順序中移除嗎？**

不會。隱藏的圖形仍保留在集合中且索引不變。它仍然可以被找到、重新排序、編輯或再度顯示。

**為什麼複製的圖形會出現在另一個圖形的前面？**

`AddClone` 會將副本附加至集合的末端，而末端代表 Z 軸的最前面。可使用 `InsertClone` 指定初始索引，或在加入所有圖形後使用 `Reorder` 調整順序。

**我可以使用固定索引來識別預設圖形調整嗎？**

僅在已驗證確切的預設與集合布局後才可。建議遍歷 `IGeometryShape::get_Adjustments` 並檢查 `IAdjustValue::get_Type`；若同一語意類型出現多次，請使用 `IAdjustValue::get_Name` 作為補充資訊。