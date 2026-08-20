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
- 도형 제거
- 도형 숨기기
- 도형 순서 변경
- interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 레이아웃 서식
- SVG로 도형
- 도형을 SVG로
- 도형 정렬
- 도형 뒤집기
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 프레젠테이션 도형을 식별, 복제, 제거, 숨기기, 순서 재정렬, 내보내기, 정렬 및 뒤집는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for C++는 슬라이드의 도형을 순서가 지정된 [IShapeCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/)으로 나타냅니다. 이 컬렉션은 도형을 찾고 수정하는 위치이자 도형의 쌓임 순서의 원천이며, 인덱스 `0`은 가장 뒤쪽 도형, 마지막 인덱스는 가장 앞쪽 도형을 의미합니다.

이 문서는 해당 모델을 따릅니다. 먼저 도형을 신뢰할 수 있게 식별하는 방법을 설명하고, 복제, 제거, 숨기기 및 재정렬 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준 서식, SVG 내보내기, 정렬 및 뒤집기 설정을 다룹니다. 각 예제는 독립적이므로 워크플로우에 필요한 작업만 사용할 수 있습니다.

## **도형 식별 및 찾기**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만 안정적인 식별자는 아닙니다. 도형을 추가, 제거 또는 재정렬하면 인덱스가 변경될 수 있습니다. 프레젠테이션이 작성·관리되는 방식에 따라 식별자를 선택하십시오.

- [Name](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_name/)은 개발자가 제어하는 템플릿에 유용하며 PowerPoint 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집 가능하고 고유성을 보장하지 않으므로 코드가 이름에 의존한다면 명명 규칙을 정하십시오.
- [AlternativeText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_alternativetext/)는 접근성 설명이나 작성자가 제공한 태그가 이미 도형을 식별하는 경우에 유용합니다. 사용자에게 표시되며 현지화되거나 접근성을 위해 재작성될 수 있지만 고유성을 보장하지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 은밀히 재사용하지 마십시오.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_officeinteropshapeid/)는 슬라이드 내에서 고유한 읽기 전용 식별자로 PowerPoint interop에서 사용하는 도형 ID와 일치합니다. PowerPoint와 연동하거나 도형 수명 동안 명확한 참조가 필요할 때 사용하십시오. 복제되거나 재생성된 도형은 다른 도형이며 자체 ID를 받습니다.

관련 [UniqueId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_uniqueid/) 속성은 프레젠테이션 범위이지만 애드인용으로 설계되었으며 재할당될 수 있습니다. 영구적인 외부 키로 다루어서는 안 됩니다. 장기적인 식별이 필요하다면 애플리케이션 데이터에 매핑을 보관하고 예상 도형이 여전히 존재하는지 검증하십시오.

다음 예제는 `Name`으로 검색하고 슬라이드 범위의 interop ID를 보고합니다. 템플릿에 기대하는 도형이 없을 경우, 코드는 잘못된 객체를 계속 사용하지 않고 해당 결과를 보고합니다.

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

작업이 특정 도형 유형에 국한되는 경우, 해당 인터페이스를 확인한 뒤 타입별 멤버를 사용하십시오. 이 예제는 이름이 지정된 객체가 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)인지 확인한 뒤 텍스트와 대체 텍스트를 업데이트합니다.

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

## **도형 컬렉션 수정**

추가, 복제, 제거 및 재정렬 메서드는 컬렉션에 즉시 적용됩니다. 작업으로 도형 수 또는 순서가 바뀌면, 해당 작업 이전에 캡처한 인덱스에 의존하지 마십시오.

### **도형 복제**

[AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addclone/)은 독립적인 사본을 만들고 대상 컬렉션에 추가합니다. [InsertClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/insertclone/) 역시 사본을 만들지만 지정한 z‑order 인덱스에 배치합니다. 좌표만 받는 오버로드는 크기를 변경하지 않고 복제본을 이동하고, 너비와 높이를 받는 오버로드는 크기도 조정할 수 있습니다.

예제는 대상 슬라이드를 만들고 라벨이 붙은 사각형을 앞쪽에 복제한 뒤, 두 번째 복제본을 뒤쪽에 삽입합니다. 두 복제본 중 어느 하나를 변경해도 원본 도형은 영향을 받지 않습니다.

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

복제는 도형의 내용과 서식을 복사하며, 이름과 대체 텍스트도 포함합니다. 해당 값들이 고유해야 한다면 복제본에 새로운 논리 식별자를 할당하십시오. 복잡한 도형이 사용하는 리소스는 프레젠테이션이 처리하지만, 복제본은 새로운 컬렉션 항목이며 새로운 도형 ID를 가집니다.

### **도형 제거**

[Remove](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/remove/)은 특정 도형 객체를 컬렉션에서 삭제합니다. 인덱스를 사용한 반복 중에 여러 일치 항목을 제거할 경우, 남은 인덱스가 유효하도록 끝에서부터 순회하십시오.

예제는 지정된 이름을 가진 모든 도형을 제거합니다. 고정된 컬렉션 항목이 아니라 현재 인덱스의 도형을 읽으며, 불필요하게 형 변환하지 않습니다.

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

제거 후에는 도형 수와 이후 도형들의 인덱스가 변경됩니다. 영향을 받지 않은 도형에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 연결선, 애니메이션 및 기타 프레젠테이션 기능이 제거된 객체를 참조할 수 있음을 고려하십시오; 보이는 도형을 제거하면 슬라이드 외관 이상의 변화가 발생할 수 있습니다.

### **도형 숨기기**

[Hidden](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/set_hidden/)을 `true`로 설정하면 도형이 컬렉션에 그대로 남지만 일반 슬라이드 쇼에서는 표시되지 않습니다. 인덱스, 서식, 내용은 코드에서 계속 접근 가능하므로, 나중에 복원될 수 있는 선택적 요소에 적합합니다.

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

숨기기는 삭제 또는 보안이 아닙니다. 사용자가 또는 코드가 발견·숨김 해제할 수 있으며, 프레젠테이션 파일에 계속 포함됩니다.

### **Z‑Order 변경**

겹치는 도형은 컬렉션 순서대로 그려집니다. [Reorder](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/reorder/)은 복제하지 않고 기존 도형을 대상 인덱스로 이동합니다. 인덱스 `0`은 뒤쪽, `Count - 1`은 앞쪽을 의미합니다.

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

예제에서는 사각형을 먼저 만들고 처음에는 타원 뒤에 배치합니다. 최종 인덱스로 이동하면 앞쪽에 위치합니다. 모든 관련 도형을 추가·복제한 뒤에 Z‑order를 최종 조정하십시오. 이러한 작업은 새 컬렉션 항목을 추가하거나 삽입하면서 의도한 스택을 바꿀 수 있기 때문입니다.

## **레이아웃 슬라이드의 도형 검사**

일반 슬라이드, 레이아웃 슬라이드, 마스터 슬라이드는 각각 별도의 도형 컬렉션을 가집니다. 레이아웃 컬렉션의 도형은 일반 슬라이드에 동일한 위치에 있더라도 동일 객체가 아닙니다. 레이아웃이 제공하는 서식을 이해하거나 변경해야 할 때 레이아웃 도형을 검사하십시오.

다음 예제는 각 레이아웃 도형의 [FillFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_fillformat/)과 [LineFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_lineformat/)을 읽으며, 모든 도형이 `AutoShape`이라고 가정하지 않습니다.

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

레이아웃을 편집하면 이를 사용하는 여러 슬라이드에 영향을 미칩니다. 레이아웃 도형을 변경하기 전에 일반 슬라이드가 해당 객체를 상속받는지 혹은 로컬 오버라이드가 있는지 확인하고, 해당 레이아웃을 사용하는 모든 슬라이드를 테스트하십시오.

## **도형을 SVG로 내보내기**

[WriteAsSvg](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/writeassvg/)는 단일 도형의 렌더링된 내용을 스트림에 기록합니다. 결과에는 도형 자체만 포함되며 전체 슬라이드 배경이나 인접 도형은 포함되지 않습니다.

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

렌더링 중에는 프레젠테이션을 열어 두십시오. 출력은 도형의 서식과 폰트·이미지와 같은 리소스에 따라 달라집니다. 전체 구성이 필요하면 개별 도형이 아니라 슬라이드를 내보내십시오. 스트림은 호출자가 소유하므로 반드시 닫거나 해제해야 합니다.

## **도형 정렬**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/ko/cpp/aspose.slides.util/slideutil/alignshapes/) 오버로드는 모든 도형 또는 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shapesalignmenttype/)은 가장자리, 중앙선 또는 배치 모드를 지정합니다. `alignToSlide`를 `true`로 설정하면 슬라이드 가장자리를 기준으로, `false`이면 선택된 도형끼리 상대적으로 정렬합니다.

예제는 세 도형을 슬라이드 상단 가장자리에 정렬합니다. 반환된 도형 참조는 정렬 직전에 현재 인덱스로 변환됩니다.

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

정렬은 위치만 변경하고 Z‑order는 바꾸지 않습니다. 상대 정렬은 보통 최소 두 개의 도형이 필요하고, 수평·수직 배치는 간격을 정의할 충분한 도형이 필요합니다. 메서드 호출 전에 컬렉션을 수정했다면 인덱스를 다시 계산하십시오.

## **도형 뒤집기**

[ShapeFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shapeframe/) 클래스는 위치, 크기, 수평·수직 뒤집기 설정 및 회전을 저장합니다. `FlipH`와 `FlipV` 값은 [NullableBool](https://reference.aspose.com/slides/ko/cpp/aspose.slides/nullablebool/)을 사용하며: `True`는 뒤집기 활성화, `False`는 비활성화, `NotDefined`는 지정되지 않음(기본 상태)입니다.

아래 입력 프레젠테이션에는 뒤집히지 않은 도형이 하나 포함되어 있습니다.

![The shape before flipping](shape_to_be_flipped.png)

예제는 다른 모든 프레임 값을 보존하고 두 뒤집기 설정만 교체합니다. 이는 새로운 [Frame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/set_frame/)을 할당하면 전체 프레임이 교체되기 때문에 중요합니다.

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

저장된 도형은 위치·크기·회전을 유지한 채 가로와 세로가 모두 거울 반전됩니다.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 도형 식별자로 사용해도 될까?**

컬렉션이 변하지 않을 단기간 처리에만 사용하십시오. 작성된 템플릿에서는 검증된 `Name` 또는 `AlternativeText` 규칙을, 슬라이드 범위 interop 작업에서는 `OfficeInteropShapeId`를 선호합니다.

**도형을 숨기면 Z‑order에서 제거되나요?**

아니요. 숨긴 도형은 동일 인덱스에 그대로 남으며, 찾기·재정렬·편집·다시 표시가 가능합니다.

**복제된 도형이 다른 도형 앞에 나타난 이유는?**

`AddClone`은 복제본을 컬렉션 끝에 추가하므로 Z‑order의 앞쪽에 배치됩니다. 초기 인덱스를 지정하려면 `InsertClone`을 사용하거나 모든 도형 추가 후 `Reorder`로 위치를 조정하십시오.