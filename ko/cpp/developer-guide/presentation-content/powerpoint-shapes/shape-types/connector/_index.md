---
title: C++를 사용하여 프레젠테이션에서 커넥터 관리
linktitle: 커넥터
type: docs
weight: 10
url: /ko/cpp/connector/
keywords:
- 커넥터
- 커넥터 유형
- 커넥터 포인트
- 커넥터 라인
- 커넥터 각도
- 연결 사이트
- 조정점
- 도형 연결
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 직선, 굽은 및 곡선 PowerPoint 커넥터를 추가, 연결, 재경로 설정, 조정 및 검사하는 방법을 배웁니다."
---
## **개요**

커넥터는 두 도형 중 하나가 이동할 때에도 두 도형에 계속 연결될 수 있는 선입니다. 끝부분은 PowerPoint에서 녹색 점으로 표시되는 연결 지점에 연결됩니다. 일부 굽은 및 곡선 커넥터는 주황색 점으로 표시되는 조정점을 제공하여 개별 커넥터 구간의 위치를 제어합니다.

Aspose.Slides는 커넥터를 [IConnector](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iconnector/) 인터페이스를 통해 나타냅니다. 커넥터를 생성하고, 끝을 도형에 연결하고, 연결 지점을 선택하고, 경로를 재설정하며, 조정점이 있는 커넥터의 기하학을 수정할 수 있습니다.

## **커넥터 유형**

[ShapeType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shapetype/) 열거형에는 직선, 굽은, 곡선 커넥터 사전 설정이 포함됩니다. 아래 표는 사용 가능한 커넥터 기하학과 각 사전 설정에 정의된 조정점 수를 보여줍니다.

| 커넥터 | 이미지 | 조정점 수 |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

조정점의 수와 의미는 선택된 커넥터 사전 설정에 따라 달라집니다. 서로 다른 커넥터 유형이 동일한 컬렉션 레이아웃을 제공한다고 가정하지 마십시오.

## **두 도형 연결**

[IShapeCollection::AddConnector](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addconnector/)을 사용하여 커넥터를 추가하고, [IConnector::set_StartShapeConnectedTo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iconnector/set_startshapeconnectedto/)와 [IConnector::set_EndShapeConnectedTo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iconnector/set_endshapeconnectedto/)를 호출하여 양쪽 끝을 연결합니다. 두 끝이 모두 연결된 후, [IConnector::Reroute](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iconnector/reroute/)가 도형 사이의 최단 경로를 선택합니다.

다음 예제는 타원과 사각형을 굽은 커넥터로 연결합니다:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto ellipse = shapes->AddAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
auto rectangle = shapes->AddAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
auto connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

connector->set_StartShapeConnectedTo(ellipse);
connector->set_EndShapeConnectedTo(rectangle);
connector->Reroute();

presentation->Save(u"connected-shapes.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}

`IConnector::Reroute`를 호출하면 [IConnector::set_StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iconnector/set_startshapeconnectionsiteindex/)와 [IConnector::set_EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iconnector/set_endshapeconnectionsiteindex/) 값이 변경될 수 있습니다. 해당 사이트가 고정되어 있어야 한다면 재경로 설정 후에 특정 연결 지점을 지정하십시오.

{{% /alert %}}

## **연결 지점 선택**

연결 가능한 각 도형은 [IShape::get_ConnectionSiteCount](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_connectionsitecount/)를 통해 자신의 사이트 수를 보고합니다. 도형의 기하학에 따라 사이트 수가 다르므로, 커넥터 끝에 할당하기 전에 선호하는 0 기반 사이트 인덱스를 확인하십시오.

다음 예제는 해당 사이트가 존재할 때 타원에 특정 사이트를 연결합니다:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto ellipse = shapes->AddAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
auto rectangle = shapes->AddAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
auto connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

connector->set_StartShapeConnectedTo(ellipse);
connector->set_EndShapeConnectedTo(rectangle);

int32_t preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse->get_ConnectionSiteCount())
{
    connector->set_StartShapeConnectionSiteIndex(preferredSiteIndex);
}
else
{
    Console::WriteLine(u"The ellipse has only {0} connection sites.", ellipse->get_ConnectionSiteCount());
}

presentation->Save(u"specific-connection-site.pptx", SaveFormat::Pptx);
```

## **커넥터 포인트 조정**

조정점을 가진 커넥터는 [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/ko/cpp/aspose.slides/igeometryshape/get_adjustments/)를 통해 노출됩니다. 각 [IAdjustValue](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iadjustvalue/)를 검사하고, 값을 변경하기 전에 해당 [IAdjustValue::get_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iadjustvalue/get_type/)을 확인하십시오. 사전 설정 도형 조정에 대한 일반 규칙은 [Shape Manipulation](/slides/ko/cpp/shape-manipulations/)에 설명되어 있습니다.

커넥터 조정의 수, 순서, 의미 및 유효값 범위는 커넥터 사전 설정에 따라 다릅니다. `IAdjustValue::get_Type`이 반환하는 유형은 읽기 전용이며, 원시 조정값은 쓰기 가능합니다. 동일한 의미 유형이 여러 개 존재할 경우 추가 식별을 위해 읽기 전용 [IAdjustValue::get_Name](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iadjustvalue/get_name/) 메서드를 사용할 수 있습니다.

### **장애물 우회**

다음 레이아웃에서 `ShapeType::BentConnector5` 커넥터가 두 도형 사이를 연결하면서 세 번째 도형을 통과합니다:

![connector-obstruction](connector-obstruction.png)

이 코드는 방해받는 커넥터를 생성합니다:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

shapes->AddAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_StartShapeConnectionSiteIndex(2);

presentation->Save(u"connector-obstruction.pptx", SaveFormat::Pptx);
```

수직 굽힘을 이동하면 경로가 변경되어 커넥터가 장애물을 우회합니다:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

컬렉션 인덱스 `1`이 항상 수직 굽힘을 의미한다고 가정하는 대신, 이 예제는 `ShapeAdjustmentType::ConnectorBendPositionY`를 검색하고 예상 의미 유형이 존재할 때만 변경합니다:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

shapes->AddAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_StartShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    Console::WriteLine(u"{0}: type = {1}, raw value = {2}", adjustment->get_Name(), static_cast<int32_t>(adjustment->get_Type()), adjustment->get_RawValue());
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend->set_RawValue(60000);
    presentation->Save(u"connector-obstruction-fixed.pptx", SaveFormat::Pptx);
}
```

`ShapeType::BentConnector5`는 두 개의 `ShapeAdjustmentType::ConnectorBendPositionX` 조정과 하나의 `ShapeAdjustmentType::ConnectorBendPositionY` 조정을 가집니다. 필요한 유형이 여러 번 나타나면 `IAdjustValue::get_Name`과 해당 사전 설정의 알려진 기하학을 확인한 후 선택하십시오. 조정이 `ShapeAdjustmentType::Custom`을 반환하면 의미와 범위를 사전 설정에 따라 간주하고 해당 계약이 확정될 때까지 변경하지 마십시오.

## **조정값을 커넥터 기하학에 연결**

굽은 커넥터의 경우, 조정값을 사용하여 개별 구간의 위치를 추정할 수 있습니다. 이러한 계산은 커넥터 사전 설정에 따라 다릅니다:

- `ShapeType::BentConnector4`는 일반적으로 하나의 `ShapeAdjustmentType::ConnectorBendPositionX`와 하나의 `ShapeAdjustmentType::ConnectorBendPositionY` 조정을 노출합니다.
- 이러한 굽힘 위치에 대해 `RawValue / 100000.0f`는 아래 예제에서 사용된 커넥터 프레임 너비 또는 높이의 비율을 생성합니다.
- 커넥터 프레임은 회전되거나 뒤집힐 수 있으므로, 프레임 좌표를 슬라이드 좌표와 비교하기 전에 변환해야 합니다.

다음 예제는 먼저 `IAdjustValue::get_Type`을 사용하여 조정을 식별합니다. 컬렉션 인덱스를 휴대형 식별자로 사용하지 않습니다.

### **회전되지 않은 커넥터**

초기 레이아웃에는 `ShapeType::BentConnector4`로 연결된 두 개의 텍스트 도형이 있습니다:

![connector-shape-complex](connector-shape-complex.png)

이 예제는 커넥터를 검사하고 수평 및 수직 굽힘 조정을 가져옵니다:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
sourceShape->get_TextFrame()->set_Text(u"From");
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
targetShape->get_TextFrame()->set_Text(u"To");
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Crimson());
lineFormat->set_Width(3);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    Console::WriteLine(u"{0}: type = {1}, raw value = {2}", adjustment->get_Name(), static_cast<int32_t>(adjustment->get_Type()), adjustment->get_RawValue());
}
```

두 굽힘을 모두 변경하려면 각 기대 유형을 찾아 두 값을 모두 찾은 후에만 수정하십시오:

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend->set_RawValue(horizontalBend->get_RawValue() + 20000);
    verticalBend->set_RawValue(verticalBend->get_RawValue() + 200000);
    presentation->Save(u"connector-adjusted.pptx", SaveFormat::Pptx);
}
```

그 결과 수평 및 수직 구간이 이동한 커넥터가 나타납니다:

![connector-adjusted-1](connector-adjusted-1.png)

의미 유형이 확인되면 값을 커넥터 프레임 좌표로 변환할 수 있습니다. 이 예제는 두 굽힘 조정이 제어하는 수직 구간 위에 얇은 사각형을 그립니다:

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    float x = connector->get_X() + connector->get_Width() * horizontalBend->get_RawValue() / 100000.0f;
    float y = connector->get_Y();
    float height = connector->get_Height() * verticalBend->get_RawValue() / 100000.0f;
    shapes->AddAutoShape(ShapeType::Rectangle, x, y, 1, height);
    presentation->Save(u"connector-segment-guide.pptx", SaveFormat::Pptx);
}
```

가이드 도형은 계산된 구간을 표시합니다:

![connector-adjusted-2](connector-adjusted-2.png)

### **회전 또는 뒤집힌 커넥터**

동일한 커넥터 기하학이 수직으로 배치될 때, [IShape::get_Frame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_frame/), [IShapeFrame::get_FlipH](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapeframe/get_fliph/), [IShapeFrame::get_FlipV](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapeframe/get_flipv/) 값이 커넥터‑프레임 좌표를 슬라이드 좌표로 변환하는 방식에 영향을 줍니다.

이 예제는 수직으로 배치된 커넥터를 생성하고 조정합니다:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
sourceShape->get_TextFrame()->set_Text(u"From");
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
targetShape->get_TextFrame()->set_Text(u"To 1");
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_MediumAquamarine());
lineFormat->set_Width(3);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(3);

auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        adjustment->set_RawValue(adjustment->get_RawValue() + 20000);
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        adjustment->set_RawValue(adjustment->get_RawValue() + 200000);
    }
}

presentation->Save(u"vertical-connector-adjusted.pptx", SaveFormat::Pptx);
```

조정된 커넥터는 도형 사이에 수직으로 표시됩니다:

![connector-adjusted-3](connector-adjusted-3.png)

임의의 회전 각도 `alpha`에 대해, 커넥터‑프레임 점 `(x, y)`를 프레임 중심 `(x0, y0)` 주위로 회전시키면:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

다음 코드는 이 예제에서 사용된 90도 방향을 처리하고 해당 커넥터 구간 위에 빨간 가이드를 그립니다:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeFrame.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(3);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend->set_RawValue(horizontalBend->get_RawValue() + 20000);
    verticalBend->set_RawValue(verticalBend->get_RawValue() + 200000);

    float x = connector->get_X();
    float y = connector->get_Y();
    auto frame = connector->get_Frame();
    if (frame->get_FlipH() == NullableBool::True)
    {
        x += connector->get_Width();
    }
    if (frame->get_FlipV() == NullableBool::True)
    {
        y += connector->get_Height();
    }

    x += connector->get_Width() * horizontalBend->get_RawValue() / 100000.0f;
    float rotatedX = frame->get_CenterX() - y + frame->get_CenterY();
    float rotatedY = x - frame->get_CenterX() + frame->get_CenterY();
    float segmentWidth = connector->get_Height() * verticalBend->get_RawValue() / 100000.0f;
    auto guide = shapes->AddAutoShape(ShapeType::Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    auto guideLineFillFormat = guide->get_LineFormat()->get_FillFormat();
    guideLineFillFormat->set_FillType(FillType::Solid);
    guideLineFillFormat->get_SolidFillColor()->set_Color(Color::get_Red());

    presentation->Save(u"rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
}
```

좌표 변환 후 빨간 가이드는 계산된 구간을 표시합니다:

![connector-adjusted-4](connector-adjusted-4.png)

이 공식은 예제에 사용된 사전 설정을 설명할 뿐, 보편적인 커넥터 모델을 의미하지 않습니다. 다른 사전 설정에 동일한 계산을 적용하기 전에 조정 유형, 프레임 방향 및 값 범위를 반드시 확인하십시오.

## **커넥터 방향 각도 찾기**

직선 커넥터의 방향은 가로·세로 크기와 수평·수직 뒤집기를 적용하여 계산할 수 있습니다. 다음 예제는 슬라이드 좌표계에서 양의 가로 축을 기준으로 시계 방향 각도를 반환합니다:

```cpp
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeFrame.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/math.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);
auto frame = connector->get_Frame();

bool flipH = frame->get_FlipH() == NullableBool::True;
bool flipV = frame->get_FlipV() == NullableBool::True;
float deltaX = connector->get_Width() * (flipH ? -1 : 1);
float deltaY = connector->get_Height() * (flipV ? -1 : 1);
double angle = Math::Atan2(deltaY, deltaX) * 180.0 / Math::PI;

if (angle < 0)
{
    angle += 360;
}

Console::WriteLine(u"Connector direction: {0:F2} degrees", angle);
```

## **FAQ**

**커넥터가 도형에 연결될 수 있는지 어떻게 확인합니까?**

도형의 `IShape::get_ConnectionSiteCount` 값을 확인하십시오. 양수이면 도형이 연결 지점을 노출한다는 의미입니다. 커넥터 끝에 할당하기 전에 선택한 사이트 인덱스를 검증하십시오.

**컬렉션 인덱스로 커넥터 조정을 식별할 수 있나요?**

인덱스는 알려진 커넥터 사전 설정 및 컬렉션 레이아웃에 한해서만 의미가 있습니다. 값을 수정하기 전에 `IAdjustValue::get_Type`을 확인하고, 동일 의미 유형이 여러 번 나타나는 경우 `IAdjustValue::get_Name`을 추가 정보로 활용하십시오.

**연결된 도형이 삭제되면 어떻게 됩니까?**

해당 커넥터 끝이 분리됩니다. 커넥터는 슬라이드에 남아 있으며, 삭제하거나 자유선으로 배치하거나 다른 도형에 다시 연결할 수 있습니다.

**슬라이드 복사 시 커넥터 연결이 유지됩니까?**

연결된 도형이 슬라이드와 함께 복사될 경우 일반적으로 연결이 유지됩니다. 커넥터만 복사되고 대상 도형 중 하나가 없으면 영향을 받은 끝을 다시 연결해야 합니다.