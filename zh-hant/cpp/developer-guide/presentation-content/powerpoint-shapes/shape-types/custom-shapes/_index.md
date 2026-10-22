---
title: 在 C++ 中自訂簡報形狀
linktitle: 自訂形狀
type: docs
weight: 20
url: /zh-hant/cpp/custom-shape/
keywords:
- 自訂形狀
- 新增形狀
- 建立形狀
- 變更形狀
- 形狀幾何
- 幾何路徑
- 路徑點
- 編輯點
- 新增點
- 移除點
- 編輯操作
- 曲線角
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 簡報中建立與自訂形狀：幾何路徑、曲線角、複合形狀。"
---
## **概述**

本篇文章說明如何透過編輯點與幾何路徑編輯形狀的幾何形狀，以自訂 Aspose.Slides 中的簡報形狀。它展示了如何使用 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) 及 [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) 來修改現有形狀、執行基本路徑編輯操作、加入或移除點，並將更新後的幾何套用回形狀。  
它也示範了如何建立自訂與組合形狀、構建帶有曲線角的形狀，以及判斷形狀幾何是否為閉合。

## **使用編輯點變更形狀**

在 PowerPoint 中，您可以使用 **編輯點** 來修改正方形：

* 將角向內或向外移動。
* 調整該點的曲率。
* 新增點。

編輯點讓您能修改形狀的輪廓，或以現有形狀為基礎建立新形狀。

## **形狀編輯技巧**

![overview_image](custom_shape_0.png)

編輯 PowerPoint 形狀時，請記住以下概念：

* 形狀（或其路徑）可以是閉合或開放的。
* 形狀的路徑由錨點透過線段相連組成。
* 線段可以是直線或曲線。錨點與控制手柄決定其形狀。
* 錨點可分為角點、直點或平滑點：
  * 在角點，相鄰的線段可在一個角度相接。
  * 在平滑點，兩個控制手柄對齊且距離錨點相等。
  * 在直點，兩個控制手柄仍對齊，但距離錨點可能不同。
* 移動錨點或調整其手柄會改變形狀的輪廓。

若要透過編輯點編輯 PowerPoint 形狀，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) 類別與 [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) 介面。

* 一個 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) 實例代表 [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) 物件的幾何路徑。
* 若要從 [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) 實例取得 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)，您可以使用 [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) 方法。
* 若要為形狀設定 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)，您可以使用以下方法：[IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/)（單一路徑的形狀）以及 [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/)（多路徑的形狀）。
* 若要新增線段，您可以使用 [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) 下的各種方法。
* 使用 [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) 與 [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) 方法，您可以設定幾何路徑的外觀。
* 使用 [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) 方法，您可以取得 [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) 的幾何路徑，形式為路徑線段陣列。

## **簡易編輯操作**

使用以下方法編輯幾何路徑。接受索引的重載會在路徑線段陣列中以零為基礎的索引位置插入線段。

| 操作 | 方法 |
| --- | --- |
| 附加或插入直線。 | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| 附加或插入具有兩個控制點與終點的三次貝茲曲線。 | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| 附加或插入具有一個控制點與終點的二次貝茲曲線。 | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| 附加具有指定尺寸與角度（度）的橢圓弧。 | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| 透過將終點連回起始點來關閉目前圖形。 | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| 設定圖形的起始點。 | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| 移除位於零基礎索引的線段。 | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **為形狀新增自訂點**

此範例使用 [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) 在矩形形狀中插入兩個點，並以 [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) 套用編輯後的路徑。座標是相對於形狀的本地座標：兩個新點皆位於中心，距左側 100 點、距上方 50 點。線段索引 1 與 4 分別將它們放置於上緣與下緣，將這些邊緣向內拉。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto geometryPath = shape->GetGeometryPaths()->idx_get(0);
geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);

shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **從形狀移除點**

此範例透過使用 [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) 移除零基礎索引 2 的線段，以變更心形輪廓。再以 [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) 套用修改後的路徑，即可更新形狀的輪廓。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f);

auto path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);

shape->SetGeometryPath(path);
```

![example2_image](custom_shape_2.png)

## **建立自訂形狀**

此範例使用 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) 建立五角星。交替的外徑與內徑分別為 100 點與 50 點，用以定義星角與凹陷；每 72 度一步將五個星角均勻分布。路徑以 [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) 關閉，並使用 [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) 套用至矩形形狀，取代其輪廓。

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/math.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto points = System::MakeObject<List<PointF>>();

auto outerRadius = 100.0f;
auto innerRadius = 50.0f;
auto angleStep = 72;

for (auto angle = -90; angle < 270; angle += angleStep)
{
    auto radians = angle * (Math::PI / 180.f);
    auto x = outerRadius * Math::Cos(radians);
    auto y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math::Cos(radians);
    y = innerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

auto starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (auto i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, outerRadius * 2, outerRadius * 2);
shape->SetGeometryPath(starPath);
```

![example3_image](custom_shape_3.png)

## **建立複合自訂形狀**

此範例為形狀的上部與下部三分之一定義兩個閉合的 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) 物件。透過 [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) 同時套用兩條路徑，即可產生在中部三分之一留下空隙的單一複合形狀。

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto topPath = System::MakeObject<GeometryPath>();
topPath->MoveTo(0.0f, 0.0f);
topPath->LineTo(shape->get_Width(), 0.0f);
topPath->LineTo(shape->get_Width(), shape->get_Height() / 3);
topPath->LineTo(0.0f, shape->get_Height() / 3);
topPath->CloseFigure();

auto bottomPath = System::MakeObject<GeometryPath>();
bottomPath->MoveTo(0.0f, shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```

![example4_image](custom_shape_4.png)

## **建立帶曲線角的自訂形狀**

此範例將直線段與 [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) 結合，以建立具有向內曲線角的形狀。每個角的大小設定弧的寬度與高度（單位為點），且 -90 度的掃描角會繪製逆時針四分之一橢圓。完成的路徑以 [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) 套用，最後將簡報另存為 PPTX 格式。

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto shapeX = 20.f;
auto shapeY = 20.f;
auto shapeWidth = 300.f;
auto shapeHeight = 200.f;

auto leftTopSize = 50.f;
auto rightTopSize = 20.f;
auto rightBottomSize = 40.f;
auto leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto topLeft = PointF(leftTopSize, 0.0f);
auto topRight = PointF(shapeWidth - rightTopSize, 0.0f);
auto rightBottom = PointF(shapeWidth, shapeHeight - rightBottomSize);
auto bottomLeft = PointF(leftBottomSize, shapeHeight);
auto leftTop = PointF(0.0f, leftTopSize);

auto geometryPath = System::MakeObject<GeometryPath>();
geometryPath->MoveTo(topLeft);
geometryPath->LineTo(topRight);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(rightBottom);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(bottomLeft);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(leftTop);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);
geometryPath->CloseFigure();

shape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **檢查形狀幾何是否為閉合**

以下輔助程式會檢查每個非空的幾何路徑是否以閉合線段結束。它讀取 [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/)，並將最後一條線段的 [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) 與 [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/) 進行比較。若不存在非空路徑則回傳 false。此檢查僅比對每條路徑的最後指令，並未檢查路徑內的每個子圖形。範例會對矩形輸出 `True`。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IPathSegment.h>
#include <DOM/PathCommandType.h>

using namespace Aspose::Slides;
using namespace System;

auto isGeometryClosed = [](SharedPtr<IGeometryShape> geometryShape)
{
    auto hasNonemptyPath = false;
    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto segments = geometryPath->get_PathData();
        if (segments->get_Length() == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        auto lastSegment = segments->idx_get(segments->get_Length() - 1);
        if (lastSegment->get_PathCommand() != PathCommandType::Close)
        {
            return false;
        }
    }
    return hasNonemptyPath;
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
Console::WriteLine(isGeometryClosed(shape));
```

## **擷取與檢查形狀元素**

使用 [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) 可將現有形狀以包含路徑點與點類型的元素形式檢查。將每個回傳的 [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) 轉型為 [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/)，即可讀取由 [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) 與 [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/) 回傳的陣列。此表示方式有助於輪廓分析或將幾何傳遞給自訂繪圖工具。

此範例開啟簡報，直接在第一張投影片上找到第一個幾何形狀，並將其路徑線段輸出。請使用包含直線與曲線線段的形狀之簡報，以觀察兩種輸出。它不會搜尋群組內的形狀。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IShapeElement.h>
#include <DOM/ShapeElement.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IGeometryShape> shape;
for (auto&& candidate : slide->get_Shapes())
{
    shape = AsCast<IGeometryShape>(candidate);
    if (shape != nullptr)
    {
        break;
    }
}
if (shape == nullptr)
{
    Console::WriteLine(u"No geometry shape found on the first slide.");
    return;
}

for (auto&& element : shape->CreateShapeElements())
{
    auto shapeElement = ExplicitCast<ShapeElement>(element);
    auto points = shapeElement->get_PathPoints();
    auto types = shapeElement->get_PathTypes();
    Console::WriteLine(u"Shape element:");

    for (auto i = 0; i < points->get_Length(); i++)
    {
        auto pointType = types[i] & 0x07; // 保留線段類型，排除旗標。
        switch (pointType)
        {
            case 0:
                Console::WriteLine(u"Start figure at {0}", points[i]);
                break;
            case 1:
                Console::WriteLine(u"Line to {0}", points[i]);
                break;
            case 3:
                Console::WriteLine(u"Cubic Bezier: controls {0}, {1}; end {2}", points[i], points[i + 1], points[i + 2]);
                i += 2; // Consume both control points and the endpoint.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

這些陣列依索引對應：`points[i]` 為座標點，`types[i]` 描述其角色。類型 `0` 代表開始一個圖形，類型 `1` 從前一點畫線至當前點。三次貝茲線段從前一終點開始，使用連續三個類型為 `3` 的項目：兩個控制點接著新的終點。迴圈會同時消費這三個項目，並檢查終點是否閉合。

點類型同時包含旗標。使用 `0x07` 掩碼即可識別線段類型，並另行測試 `0x80` 以偵測閉合子路徑。例如，`129`（`0x81`）代表閉合子路徑的線段終點，`131`（`0x83`）代表閉合的貝茲終點。僅比對原始值為 `1` 或 `3` 會遺漏這些情況。其他旗標，如虛線 (`0x10`) 與標記 (`0x20`)，不會改變基礎線段類型。

**座標與變換。** 點的單位為 point（1/72 英吋），X 向右遞增，Y 向下遞增。對於未群組的形狀，擷取的座標已包含由 [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) 與 [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) 回傳的位置，並反映其當前的寬度與高度。例如，位於 `(100, 200)`、尺寸為 `120 × 80` 的未旋轉矩形，其輪廓界限為 `(100, 200)`–`(220, 280)`。請勿再次添加形狀位置。應減去其 X 與 Y，以取得相對於未旋轉框架的座標。

擷取的點不會套用透過 [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) 設定的旋轉，也不會套用水平與垂直翻轉。若要重現顯示的輪廓，需在形狀中心周圍套用這些變換。對於群組形狀，亦需考慮群組的座標映射與變換；不要假設擷取的點已是最終渲染在投影片上的座標，或在子形狀框架已反映的情況下再次套用平移或縮放。

**檢查與編輯的差異。** 擷取的陣列描述輪廓，對其變更不會更新原始形狀。當您的分析或繪圖程式需要點/類型陣列時，可採用此方式。若需要在形狀本地座標系統中的幾何指令或想編輯其幾何，請使用 [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/)。編輯後的路徑可透過 [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) 或 [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) 套用。

## **將 GeometryPath 轉換為 GraphicsPath**

目前的 Aspose.Slides for C++ 公開 API 未提供幾何路徑與圖形路徑之間的轉換。若要檢查輪廓，請如上文所述使用形狀元素。若要編輯形狀，請使用幾何路徑並將更新後的路徑套用至形狀。

## **常見問答**

**什麼情況下更換幾何後填充與輪廓會怎樣？**

樣式仍保留於形狀上；僅輪廓會改變。填充與輪廓會自動套用至新的幾何。

**如何正確地連同其幾何一起旋轉自訂形狀？**

使用形狀的 [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) 方法；幾何會隨形狀一起旋轉，因為它繫結於形狀自身的座標系統。

**是否可以將自訂形狀轉換為圖像，以「鎖定」結果？**

可以。將所需的 [投影片](/slides/zh-hant/cpp/convert-powerpoint-to-png/) 區域或 [形狀](/slides/zh-hant/cpp/shape-thumbnails/) 本身匯出為點陣圖格式；這可簡化後續處理複雜幾何的工作。