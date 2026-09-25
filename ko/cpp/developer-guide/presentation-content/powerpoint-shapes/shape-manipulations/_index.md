---
title: C++에서 프레젠테이션 도형 관리
linktitle: 도형 조작
type: docs
weight: 40
url: /ko/cpp/shape-manipulations/
keywords:
- PowerPoint 도형
- 프레젠테이션 도형
- 슬라이드의 도형
- 도형 찾기
- 도형 복제
- 도형 삭제
- 도형 숨기기
- 도형 순서 변경
- Interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 조정 포인트
- 미리 정의된 도형 조정
- 도형 기하학
- 도형 레이아웃 형식
- SVG 형태의 도형
- 도형을 SVG로
- 도형 정렬
- 도형 뒤집기
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 프레젠테이션 도형을 식별, 조정, 복제, 삭제, 숨기기, 순서 변경, 내보내기, 정렬 및 뒤집는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for C++는 슬라이드의 도형을 정렬된 [IShapeCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/) 로 나타냅니다. 컬렉션은 도형을 찾고 수정할 수 있는 위치이자, 쌓임 순서의 원천이며, 인덱스 `0` 은 가장 뒤쪽 도형이고 마지막 인덱스는 가장 앞쪽 도형을 의미합니다.

이 문서는 해당 모델을 따릅니다. 먼저 도형을 신뢰성 있게 식별하고 미리 정의된 도형 조정 포인트를 수정하는 방법을 설명하고, 이어서 도형을 복제, 삭제, 숨기기 및 순서를 변경하는 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준 서식, SVG 내보내기, 정렬 및 뒤집기 설정을 다룹니다. 각 예제는 독립적이므로 워크플로에 필요한 작업만 사용할 수 있습니다.

## **도형 식별 및 찾기**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만 안정적인 식별자는 아닙니다. 도형을 추가·삭제·재정렬하면 인덱스가 변경될 수 있습니다. 프레젠테이션이 어떻게 작성·관리되는지에 따라 식별자를 선택하십시오.

- [Name](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_name/) 은 개발자가 제어하는 템플릿에 유용하며 PowerPoint 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집할 수 있지만 고유성을 보장하지 않으므로 코드에서 이름에 의존한다면 명명 규칙을 정하십시오.
- [AlternativeText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_alternativetext/) 은 접근성 설명이나 작성자가 지정한 태그가 이미 도형을 식별하는 경우에 유용합니다. 사용자가 볼 수 있고 현지화되거나 접근성을 위해 재작성될 수 있지만 고유성을 보장하지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 조용히 재사용하지 마십시오.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_officeinteropshapeid/) 은 읽기 전용 식별자로 슬라이드 내에서 고유하며 PowerPoint interop에서 사용되는 도형 ID와 일치합니다. PowerPoint와 통합하거나 도형 수명 동안 명확한 참조가 필요할 때 사용하십시오. 복제되거나 다시 생성된 도형은 다른 도형이며 자체 ID를 가집니다.

관련된 [UniqueId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_uniqueid/) 속성은 프레젠테이션 범위를 갖지만 애드인용으로 설계되었으며 재할당될 수 있습니다. 영구적인 외부 키로 취급해서는 안 됩니다. 장기적인 식별이 필요하다면 애플리케이션 데이터에 매핑을 보관하고 기대하는 도형이 여전히 존재하는지 확인하십시오.

대체 텍스트 제목과 설명을 읽고 업데이트하는 실용적인 예제는 [Manage Alternative Text Titles and Descriptions](/slides/ko/cpp/presentation-accessibility/) 를 참조하십시오. 대체 텍스트는 시각적 의미를 독자에게 설명하기 위해 사용하고, 코드에서 도형을 찾는 데 사용되는 이름과는 별도로 관리하십시오.

다음 예제는 `Name` 으로 검색하고 슬라이드 범위의 interop ID 를 보고합니다. 템플릿에 기대하는 도형이 없을 경우, 코드는 잘못된 객체를 계속 사용하는 대신 해당 결과를 보고합니다.

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

도형 유형에 따라 작업이 특정한 경우, 타입‑특정 멤버를 사용하기 전에 인터페이스를 확인하십시오. 이 예제는 명명된 객체가 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 인 경우에만 텍스트와 대체 텍스트를 업데이트합니다.

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

## **미리 정의된 도형 조정 수정**

미리 정의된 기하학 도형은 모서리 크기, 화살표 비율, 호 각도와 같은 기능을 제어하는 조정 포인트를 노출할 수 있습니다. 읽기 전용 [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/ko/cpp/aspose.slides/igeometryshape/get_adjustments/) 컬렉션을 통해 접근합니다. 컬렉션 자체는 도형이 제공하지만, 각 [IAdjustValue](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iadjustvalue/) 는 변경 가능한 값을 포함합니다.

고정된 컬렉션 인덱스에만 의존하지 마십시오. 조정을 순회하면서 읽기 전용 [IAdjustValue::get_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iadjustvalue/get_type/) 속성을 확인하십시오. 이 속성의 [ShapeAdjustmentType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shapeadjustmenttype/) 값은 조정이 제어하는 기능을 설명합니다. 읽기 전용 [IAdjustValue::get_Name](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iadjustvalue/get_name/) 속성은 추가 식별 정보를 제공하며, 같은 의미 유형을 가진 조정이 여러 개 있는 경우에 특히 유용합니다.

조정 의미에 맞는 값 속성을 사용하십시오:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | 라운드 모서리 크기 | [RawValue](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | 화살표 꼬리 두께 | `RawValue` |
| `ArrowheadLength` | 화살표 머리 길이 | `RawValue` |
| `ArrowheadWidth` | 화살표 머리 너비 | `RawValue` |
| `StartAngle` | 파이 또는 호의 시작 각도 | [AngleValue](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | 파이 또는 호의 끝 각도 | `AngleValue` |

`Type` 과 `Name` 은 할당할 수 없습니다. `RawValue` 는 미리 정의된 도형의 고유 기하학 단위에서 읽기/쓰기 정수이며, `AngleValue` 는 도° 단위의 읽기/쓰기 각도입니다. 조정의 개수, 순서, 의미 및 유효 범위는 미리 정의된 [ShapeType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/igeometryshape/get_shapetype/) 에 따라 달라집니다. 한 프리셋에 유효한 값이 다른 프리셋에서는 무효이거나 다른 효과를 가질 수 있습니다.

`Type` 이 `ShapeAdjustmentType::Custom` 인 경우, API는 표준 의미를 인식하지 못합니다. `Name`, 프리셋 유형 및 기존 값을 검사하고 기대 의미와 범위를 알지 못한다면 조정을 변경하지 마십시오. 인식된 유형이라도 동일한 유형이 여러 번 나타나는지 확인한 뒤 값을 선택하십시오. [Connector](/slides/ko/cpp/connector/) 문서에서는 커넥터 굽힘 조정 상황을 보여줍니다.

다음 완전한 예제는 세 개의 미리 정의된 도형에 대해 기본 및 수정된 버전을 생성합니다. 모든 조정을 순회하면서 `Name` 과 `Type` 을 보고, `RawValue` 로 크기 관련 값을, `AngleValue` 로 각도를 변경하고 결과를 저장합니다. 왼쪽 열은 기본 기하학을 유지하고, 오른쪽 열은 조정된 라운드 사각형, 4방향 화살표 및 파이를 보여줍니다.

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

// 기본 및 조정된 도형 열에 대한 헤더를 추가합니다.
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

값을 변경하기 전에 의미 유형을 확인하면 코드가 의도를 명확히 밝히고 다른 프리셋 도형에서 동일한 컬렉션 인덱스가 같은 의미를 가진다고 가정하는 실수를 방지합니다.

## **도형 컬렉션 수정**

추가, 복제, 삭제 및 재정렬 메서드는 컬렉션에 즉시 적용됩니다. 작업이 도형 수나 순서를 변경한다면, 해당 작업 이전에 캡처한 인덱스에 의존하지 마십시오.

### **도형 복제**

[AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addclone/) 은 독립적인 복사본을 만들고 대상 컬렉션에 추가합니다. [InsertClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/insertclone/) 도 복사본을 만들지만 지정된 z‑order 인덱스에 배치합니다. 좌표를 받는 오버로드는 크기를 변경하지 않고 복제본을 이동하고, 너비와 높이를 받는 오버로드는 크기도 조정할 수 있습니다.

예제는 대상 슬라이드를 만들고 라벨이 있는 사각형을 앞쪽에 복제한 뒤, 두 번째 복제본을 뒤쪽에 삽입합니다. 두 복제본 중 어느 하나를 변경해도 원본 도형은 영향을 받지 않습니다.

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

복제는 도형의 내용과 서식을 복사하며, 이름 및 대체 텍스트도 복사됩니다. 이러한 값이 고유해야 한다면 복제본에 새로운 논리 식별자를 할당하십시오. 복잡한 도형이 사용하는 리소스는 프레젠테이션에서 관리되지만 복제본은 새로운 컬렉션 항목이며 새로운 도형 ID 를 가집니다.

### **도형 삭제**

[Remove](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/remove/) 은 특정 도형 객체를 컬렉션에서 삭제합니다. 인덱스 순회 중에 여러 일치를 삭제해야 할 경우, 남은 인덱스가 유효하도록 끝에서부터 탐색하십시오.

이 예제는 지정된 이름을 가진 모든 도형을 삭제합니다. 고정된 컬렉션 항목이 아니라 현재 인덱스된 도형을 읽으며, 불필요한 캐스팅도 하지 않습니다.

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

삭제 후에는 도형 수와 이후 도형들의 인덱스가 변경됩니다. 영향을 받지 않은 도형에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 커넥터, 애니메이션 및 기타 프레젠테이션 기능이 삭제된 객체를 참조할 수 있으니, 보이는 도형을 삭제하면 슬라이드 외관 이상으로 영향을 줄 수 있음을 고려하십시오.

### **도형 숨기기**

[Hidden](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/set_hidden/) 을 `true` 로 설정하면 도형이 컬렉션에 남아 있지만 일반 슬라이드 쇼에서는 표시되지 않습니다. 인덱스, 서식, 내용은 코드에서 여전히 사용 가능하므로, 나중에 복원할 수 있는 선택적 요소에 적합합니다.

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

숨기기는 삭제나 보안이 아닙니다. 사용자는 물론 코드도 여전히 객체를 검색하고 다시 표시할 수 있으며, 파일 내에 지속됩니다.

### **Z‑Order 변경**

겹치는 도형은 컬렉션 순서대로 그려집니다. [Reorder](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/reorder/) 은 기존 도형을 복제하지 않고 대상 인덱스로 이동합니다. 인덱스 `0` 은 뒤쪽, `Count - 1` 은 앞쪽을 의미합니다.

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

사각형을 먼저 만들면 처음에는 타원 뒤에 위치합니다. 최종 인덱스로 이동시키면 앞쪽에 배치됩니다. 모든 관련 도형을 추가·복제한 뒤에 z‑order 를 최종 결정하십시오. 이러한 작업은 새로운 컬렉션 항목을 추가하거나 삽입하면서 스택을 변경할 수 있기 때문입니다.

## **레이아웃 슬라이드의 도형 검사**

일반 슬라이드, 레이아웃 슬라이드, 마스터 슬라이드는 각각 별도의 도형 컬렉션을 가집니다. 레이아웃 컬렉션의 도형은 동일한 위치에 있는 일반 슬라이드의 도형과 동일 객체가 아닙니다. 레이아웃이 제공하는 서식을 이해하거나 변경해야 할 때 레이아웃 도형을 검사하십시오.

다음 예제는 각 레이아웃 도형의 [FillFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_fillformat/) 과 [LineFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_lineformat/) 을 읽으며, 모든 도형이 `AutoShape` 인 것으로 가정하지 않습니다.

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

레이아웃을 편집하면 이를 사용하는 여러 슬라이드에 영향을 미칩니다. 레이아웃 도형을 변경하기 전에 일반 슬라이드가 해당 객체를 상속하거나 로컬 오버라이드가 있는지 확인하고, 해당 레이아웃을 사용하는 모든 슬라이드를 테스트하십시오.

## **도형을 SVG 로 내보내기**

[WriteAsSvg](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/writeassvg/) 은 하나의 도형을 렌더링한 내용을 스트림에 기록합니다. 결과에는 도형 자체만 포함되며 슬라이드 전체 배경이나 인접 도형은 포함되지 않습니다.

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

렌더링하는 동안 프레젠테이션을 열어 두십시오. 출력은 도형 서식과 폰트·이미지와 같은 리소스에 따라 달라집니다. 전체 구성을 원한다면 개별 도형이 아닌 슬라이드를 내보내십시오. 호출자는 스트림을 소유하며 스트림을 닫거나 폐기해야 합니다.

## **도형 정렬**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/ko/cpp/aspose.slides.util/slideutil/alignshapes/) 오버로드는 모든 도형이나 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shapesalignmenttype/) 은 가장자리, 중앙선 또는 배치 모드를 지정합니다. `alignToSlide` 를 `true` 로 설정하면 슬라이드 가장자리를 기준으로, `false` 로 설정하면 선택된 도형들 간의 상대 정렬을 수행합니다.

이 예제는 세 도형을 슬라이드 상단 가장자리에 정렬합니다. 반환된 도형 참조는 정렬 직전에 현재 인덱스로 변환됩니다.

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

정렬은 위치를 바꾸지만 z‑order 를 변경하지는 않습니다. 상대 정렬은 보통 두 개 이상의 도형이 필요하고, 수평·수직 배치는 충분한 도형 수가 있어야 간격을 정의할 수 있습니다. 메서드 호출 전에 컬렉션을 수정했다면 인덱스를 다시 계산하십시오.

## **도형 뒤집기**

[ShapeFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shapeframe/) 클래스는 위치, 크기, 수평·수직 뒤집기 설정 및 회전을 저장합니다. `FlipH` 와 `FlipV` 값은 [NullableBool](https://reference.aspose.com/slides/ko/cpp/aspose.slides/nullablebool/) 을 사용하며, `True` 는 뒤집기 활성화, `False` 는 비활성화, `NotDefined` 는 지정되지 않은/기본 상태를 유지합니다.

아래 입력 프레젠테이션에는 뒤집히지 않은 도형 하나가 포함되어 있습니다.

![The shape before flipping](shape_to_be_flipped.png)

예제는 다른 모든 프레임 값을 보존하고 두 뒤집기 설정만 교체합니다. 이는 새로운 [Frame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/set_frame/) 을 할당하면 전체 프레임이 교체되기 때문에 중요합니다.

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

저장된 도형은 수평·수직으로 각각 거울 반사되면서 위치·크기·회전은 그대로 유지됩니다.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 도형 식별자로 사용해도 될까요?**

컬렉션이 인덱스 사용 전까지 변경되지 않을 짧은 처리 과정에만 사용하십시오. 작성된 템플릿에서는 검증된 `Name` 또는 `AlternativeText` 규칙을, 슬라이드 범위의 interop 작업에서는 `OfficeInteropShapeId` 를 선호합니다.

**도형을 숨기면 z‑order 에서 제거되나요?**

아니요. 숨긴 도형은 동일 인덱스에 그대로 남아 있으며, 찾아서 재정렬·편집·다시 표시할 수 있습니다.

**복제된 도형이 다른 도형 앞에 나타난 이유는?**

`AddClone` 은 복제본을 컬렉션 끝에 추가하므로 z‑order 의 앞쪽에 배치됩니다. 초기 인덱스를 지정하려면 `InsertClone` 을 사용하거나 모든 도형 추가 후 `Reorder` 로 위치를 조정하십시오.

**고정 인덱스로 미리 정의된 도형 조정을 식별해도 될까요?**

정확한 프리셋과 컬렉션 레이아웃을 검증한 후에만 가능합니다. 가능한 한 `IGeometryShape::get_Adjustments` 를 순회하며 `IAdjustValue::get_Type` 을 확인하고, 동일 의미 유형이 여러 번 나타날 경우 `IAdjustValue::get_Name` 을 추가 정보로 활용하십시오.