---
title: C++에서 PowerPoint 도형 서식 지정
linktitle: 도형 서식 지정
type: docs
weight: 20
url: /ko/cpp/shape-formatting/
keywords:
- 도형 서식 지정
- 선 서식 지정
- 스케치 효과
- 스케치 도형 선
- 조인 스타일 서식 지정
- 그라디언트 채우기
- 패턴 채우기
- 그림 채우기
- 텍스처 채우기
- 단색 채우기
- 도형 투명도
- 흑백 도형 렌더링
- 회색조 도형 렌더링
- 도형 회전
- 3D 베벨 효과
- 3D 회전 효과
- 서식 초기화
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint 도형을 서식 지정하는 방법을 배우세요—PPT 및 PPTX 파일에 대해 채우기, 선 및 효과 스타일을 정밀하고 완벽하게 제어할 수 있습니다."
---
## **소개**

PowerPoint에서 도형의 윤곽선, 채우기 및 효과를 조정하여 형식을 지정합니다. Aspose.Slides for C++를 사용하면 투명도, 회전 및 3D 서식 등을 프로그래밍 방식으로 제어할 수 있습니다.

![PowerPoint에서 도형 서식 옵션](format-shape-powerpoint.png)

Aspose.Slides for C++는 PowerPoint에서 사용할 수 있는 동일한 옵션을 사용하여 도형을 서식 지정할 수 있는 인터페이스와 메서드를 제공합니다.

## **선 서식 지정**

[IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/)을 사용하여 도형의 윤곽선을 제어합니다. 이 예제는 파란색 점선 윤곽선을 가진 채우기되지 않은 사각형을 만듭니다. [ILineFormat::set_Style](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_style/)은 굵은-얇은 복합 선을 선택하고, [ILineFormat::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/)은 너비를 7 포인트로 설정하며, [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/)은 대시 패턴을 선택합니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![프레젠테이션에서 서식이 지정된 선](formatted-lines.png)

### **사용자 지정 선 대시 패턴 설정**

미리 정의된 선 스타일이 필요한 대시 길이와 간격을 제공하지 않을 경우, 예를 들어 브랜드 윤곽선이나 기술 다이어그램에 사용하려면 [ILineFormat::set_CustomDashPattern](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_customdashpattern/)을 사용합니다. 패턴을 지정하면 대시 스타일이 자동으로 [LineDashStyle::Custom](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/)으로 변경됩니다.

배열 항목은 대시와 간격 길이를 번갈아 가며, 대시부터 시작합니다. 각 값은 선 너비의 배수입니다: `{ 4, 2 }`를 3 포인트 너비에 적용하면 12 포인트 대시 뒤에 6 포인트 간격이 생깁니다. 유한하고 음수가 아닌 값을 쌍으로 사용하여 완전한 대시‑간격 세그먼트를 정의합니다. 예제에서는 모든 대시와 간격이 보이도록 양수를 사용했습니다.

이 예제는 동일한 길이와 평평한 캡을 가진 파란색 선 다섯 개를 만듭니다. 처음 세 개는 3 포인트 너비에서 패턴을 비교합니다. 네 번째는 첫 번째 패턴을 두 배 너비로 반복하여 대시와 간격 길이를 모두 두 배로 늘립니다. 다섯 번째는 사용자 지정 패턴에서 실선으로 전환합니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(600, 300, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto patterns = std::array<ArrayPtr<float>, 5>{
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 1, 2 }),
    MakeArray<float>({ 6, 2, 1, 2 }),
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 4, 2 })
};

for (auto i = 0; i < patterns.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 50, 50 + i * 50, 500, 0);
    line->get_LineFormat()->set_Width(i == 3 ? 6 : 3);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_CapStyle(LineCapStyle::Flat);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_CustomDashPattern(patterns[i]);
}

// Return the last line to a solid style.
slide->get_Shape(4)->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);

presentation->Save(u"custom_dash_patterns.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

미리 정의된 대시 스타일로 돌아가려면 [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/)에 [LineDashStyle::Dash](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/)을 전달하십시오. 선택된 스타일이 선의 외관을 제어합니다.

PowerPoint에서 위에서 아래 순서로 나타난 결과: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; 및 **Solid, 3 pt**.

![PowerPoint에서 세 개의 사용자 지정 대시 패턴, 첫 번째 패턴을 사용한 더 넓은 선, 실선](custom-dash-patterns.png)


### **선 캡 설정**

[ILineFormat::set_CapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_capstyle/)을 사용하여 열린 선의 끝을 설정합니다. [LineCapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linecapstyle/) 열거형은 세 가지 명시적 캡 스타일을 제공합니다:

- `Flat`: 스트로크가 끝점에서 멈춥니다.
- `Round`: 반원형 캡이 선 너비의 절반만큼 끝점을 넘어 확장됩니다.
- `Square`: 정사각형 캡이 선 너비의 절반만큼 끝점을 넘어 확장됩니다.

열거형에는 `NotDefined`도 포함되어 있으며, 이는 캡 스타일이 명시적으로 할당되지 않았음을 의미합니다.

캡은 선 끝에 기호를 추가하는 화살표 머리와, 선 세그먼트 사이의 모서리를 제어하는 조인과는 다릅니다. 이 예제에서는 [ILineFormat::set_BeginArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_beginarrowheadstyle/)와 [ILineFormat::set_EndArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_endarrowheadstyle/)을 사용하여 화살표 머리를 비활성화하고 캡 모양만 비교합니다.

다음 예제는 서로 동일한 수평선 세 개를 만들며, 각각 20 포인트 너비입니다. 위에서 아래 순서대로 평평한 캡, 둥근 캡, 정사각형 캡을 사용합니다. 끝점은 동일한 수평 좌표를 가지며, 둥근 캡과 정사각형 캡은 각 끝점에서 10 포인트씩 늘어납니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 240, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto capStyles = std::array<LineCapStyle, 3>{ LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square };

for (auto i = 0; i < capStyles.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 100, 50 + i * 70, 300, 0);
    line->get_LineFormat()->set_Width(20);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);
    line->get_LineFormat()->set_CapStyle(capStyles[i]);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
}

presentation->Save(u"line_caps.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPoint에서 위에서 아래 순서대로 나타난 결과: **Flat**, **Round**, **Square**.

![PowerPoint에서 동일한 굵은 선에 평평한, 둥근 및 정사각형 캡 적용](line-caps.png)

## **도형 선에 스케치 효과 적용**

스케치 효과는 도형 선을 손으로 그린 것처럼 보이게 합니다. [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/)으로 선 설정에 접근하고, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/)으로 스케치 설정에 접근한 뒤, [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/)을 사용하여 [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) 열거형에서 값을 선택합니다.

다음 C++ 코드는 [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) 효과를 적용하고, 명시적으로 할당된 값을 읽으며, [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/)으로 효과를 제거하는 방법을 보여줍니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();
sketchFormat->set_SketchType(LineSketchType::Curved);
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

[ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/)이 반환하는 값은 도형에 직접 할당된 설정을 나타냅니다. 선 서식이 테마, 마스터 슬라이드 또는 레이아웃 슬라이드에서 상속될 수 있는 경우, [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/)을 사용하고, [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/)에 접근한 뒤, [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/)을 읽습니다. 유효 값은 상속이 해결된 후 실제 적용된 서식을 반영합니다. 이 예제는 첫 번째 슬라이드에 최소 하나의 도형이 있는 기존 프레젠테이션이 필요하며 두 값을 모두 출력합니다:

```cpp
#include <DOM/ILineFormat.h>
#include <DOM/ILineFormatEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISketchFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto lineFormat = shape->get_LineFormat();
auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);
presentation->Dispose();
```

## **조인 스타일 서식 지정**

다음은 세 가지 조인 타입 옵션입니다:

* Round
* Miter
* Bevel

조인 스타일은 두 윤곽선 세그먼트가 모서리에서 어떻게 연결되는지를 제어합니다. 둥근 모서리에는 **Round**, 뾰족한 모서리에는 **Miter**, 평평한 모서리에는 **Bevel**을 사용합니다.

![프레젠테이션에서 조인 스타일](join-style-powerpoint.png)

이 예제는 파란색 윤곽선(15 포인트)으로 된 검은색 사각형 세 개를 만들고, 각각 [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/)을 사용해 [LineJoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/)의 miter, bevel, round 값을 할당하여 모서리가 어떻게 그려지는지 비교합니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto miterShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto bevelShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto roundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

miterShape->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
bevelShape->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
roundShape->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

miterShape->get_LineFormat()->set_Width(15);
bevelShape->get_LineFormat()->set_Width(15);
roundShape->get_LineFormat()->set_Width(15);

miterShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
bevelShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
roundShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

miterShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
bevelShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
roundShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

miterShape->get_TextFrame()->set_Text(u"Miter Join Style");
bevelShape->get_TextFrame()->set_Text(u"Bevel Join Style");
roundShape->get_TextFrame()->set_Text(u"Round Join Style");

presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **날카로운 모서리에서 Miter 조인 제한**

[ILineFormat::set_MiterLimit](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_miterlimit/)을 [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/)이 [LineJoinStyle::Miter](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/)로 설정된 상태에서 사용하면 날카로운 모서리가 얼마나 멀리 뻗을 수 있는지를 제한합니다.

제한은 조인의 내부와 외부 모서리 사이 거리를 선 너비로 나눈 비율입니다. 예를 들어 값 `8`은 선 너비의 최대 8배까지 miter 길이를 허용합니다; 이는 포인트 단위 측정이 아니라 비율입니다. 모서리가 제한을 초과하면 PowerPoint는 해당 모서리에서 베벨 조인을 사용합니다. 제한을 크게 하면 더 뾰족한 점을 만들 수 있습니다. 이 설정은 miter 조인에만 적용되며, 모서리가 두 제한 모두 내에 있을 때는 눈에 보이는 효과가 없습니다.

이 예제는 윤곽선이 20 포인트인 동일한 채우기되지 않은 삼각형 두 개를 만듭니다. 왼쪽 삼각형은 제한 `2`를, 오른쪽은 `8`을 사용합니다. 각 삼각형은 가로 80 포인트, 세로 160 포인트이며, 위쪽 모서리의 miter‑length‑to‑line‑width 비율은 약 `4.12`입니다. 따라서 PowerPoint는 왼쪽 꼭짓점을 베벨링하고 오른쪽 꼭짓점을 그대로 유지합니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 320, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto miterLimits = std::array<float, 2>{ 2.0f, 8.0f };

for (auto i = 0; i < miterLimits.size(); i++)
{
    auto triangle = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 90 + i * 240, 110, 80, 160);
    triangle->get_FillFormat()->set_FillType(FillType::NoFill);
    triangle->get_LineFormat()->set_Width(20);
    triangle->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    triangle->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    triangle->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
    triangle->get_LineFormat()->set_MiterLimit(miterLimits[i]);
}

presentation->Save(u"miter_limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPoint 결과: 왼쪽 **Miter limit 2**, 오른쪽 **miter limit 8**.

![PowerPoint에서 Miter limit 2인 베벨 꼭짓점과 Miter limit 8인 뾰족한 꼭짓점](miter-limits.png)

## **그라디언트 채우기**

그라디언트 채우기는 도형 전체에 색상을 혼합합니다. 이 예제는 [IFillFormat::get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_gradientformat/)을 사용해 45도 각도로 빨간색에서 보라색으로 선형 그라디언트를 적용해 타원을 채웁니다. [IGradientStopCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/igradientstopcollection/add/) 메서드는 그라디언트 시작점과 끝점(0 및 1)에 색상 정지를 배치합니다. 기존 정지를 지워 두 색상만 사용되도록 합니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);
shape->get_FillFormat()->get_GradientFormat()->set_LinearGradientAngle(45);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Clear();
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![그라디언트 채우기가 적용된 타원](gradient-fill.png)

그라디언트가 내보낸 이미지에서 PowerPoint와 다르게 보이는 경우, [Choose a Gradient Rendering Style](/slides/ko/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) 를 참조하십시오. 프레젠테이션에 저장된 그라디언트 채우기를 변경하지 않고 렌더링 스타일만 선택할 수 있습니다.

### **선형 그라디언트 각도 설정**

[IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/)을 사용해 [GradientShape::Linear](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/) 채우기의 방향을 제어합니다. 각도는 도 단위이며 시계 방향으로 증가합니다: `0`은 좌→우, `90`은 위→아래, `180`은 우→좌, `270`은 아래→위. 소수 각도도 지원됩니다. `[0, 360)` 범위 밖의 유한 각도는 한 바퀴로 정규화됩니다; 예를 들어 `-45`는 `315`가 되고 `360`은 `0`이 됩니다.

이 예제는 동일한 빨강, 초록, 파랑 정지를 `0`, `0.5`, `1` 위치에 배치한 직사각형 여섯 개를 만들고, 스케일을 비활성화해 각도를 직사각형 비율과 무관하게 비교합니다. 왼쪽에서 오른쪽으로 첫 번째 행은 `0`, `45`, `90`도, 두 번째 행은 `135`, `180`, `270`도 입니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto angles = std::array<float, 6>{ 0, 45, 90, 135, 180, 270 };

for (auto i = 0; i < angles.size(); i++)
{
    auto x = 30 + (i % 3) * 230;
    auto y = 30 + (i / 3) * 190;

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 200, 150);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::False);
    gradient->set_LinearGradientAngle(angles[i]);
}

presentation->Save(u"linear_gradient_angles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPoint 결과:

![위 행에 0, 45, 90도, 아래 행에 135, 180, 270도 선형 그라디언트](linear-gradient-angles.png)

### **도형에 선형 그라디언트 스케일 적용**

[IGradientFormat::set_LinearGradientScaled](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientscaled/)은 [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) 값을 받습니다. `False`로 명시적으로 설정하면 도형 비율이 바뀌어도 기하학적 그라디언트 각도가 유지되고, `True`로 설정하면 그라디언트가 도형의 너비와 높이에 따라 스케일됩니다. 스케일이 활성화된 경우 비정사각형 도형에서 보이는 각도는 할당된 각도와 다를 수 있습니다.

다음 예제는 `45`도 각도와 앞 예제와 동일한 색상 정지를 사용합니다. 왼쪽 열은 `False`, 오른쪽 열은 `True`를 사용합니다. 각 열에는 넓은 직사각형 위에 높은 직사각형이 있습니다. 두 번째 직사각형의 너비와 높이를 변경하여 채우기가 크기 조정에 어떻게 반응하는지 보여줍니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 460, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto scalingOptions = std::array<NullableBool, 2>{ NullableBool::False, NullableBool::True };

for (auto column = 0; column < scalingOptions.size(); column++)
{
    for (auto row = 0; row < 2; row++)
    {
        auto x = 30 + column * 360;
        auto y = row == 0 ? 30 : 150;

        auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 300, 90);
        shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
        shape->get_FillFormat()->set_FillType(FillType::Gradient);

        auto gradient = shape->get_FillFormat()->get_GradientFormat();
        gradient->set_GradientShape(GradientShape::Linear);
        gradient->get_GradientStops()->Clear();
        gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
        gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
        gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
        gradient->set_LinearGradientAngle(45);
        gradient->set_LinearGradientScaled(scalingOptions[column]);

        if (row == 1)
        {
            shape->set_Width(90);
            shape->set_Height(280);
        }
    }
}

presentation->Save(u"linear_gradient_scaling.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPoint 결과, 좌측은 스케일 비활성화, 우측은 스케일 활성화:

![45도 그라디언트를 적용한 넓은 직사각형과 높은 직사각형, 좌측 LinearGradientScaled False, 우측 True 비교](linear-gradient-scaling.png)

스케일이 비활성화되면 두 직사각형 모두 대각선 색상 띠가 동일한 방향을 유지합니다. 스케일이 활성화되면 띠가 도형 비율에 맞게 늘어납니다. 이는 템플릿의 그라디언트를 다른 크기의 도형에 적용할 때 도움이 됩니다. 정사각형에서는 스케일을 활성화해도 이 `45`도 그라디언트의 외관이 바뀌지 않습니다.

각도와 스케일 설정은 선형 그라디언트에만 적용되며, [GradientShape::Radial] 또는 [GradientShape::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/) 채우기는 제어하지 않습니다.

### **그라디언트 방향과 각도 결합**

[IGradientFormat::set_GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_gradientdirection/)은 [GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/gradientdirection/) 열거형에서 그라디언트 스타일을 선택합니다; 숫자 각도의 대체가 아닙니다. 선형 그라디언트의 경우, 코너 스타일이 색상이 분배되는 영역을 바꿀 수 있지만 [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/)에 할당된 각도는 변하지 않습니다. 각도 또는 스케일을 비교할 때는 방향을 그대로 유지하십시오.

다음 예제는 같은 설정을 순서를 바꿔 적용합니다. 두 직사각형은 동일한 외관을 가지며, 방향을 각도 전에 적용하든 후에 적용하든 결과는 변하지 않습니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30 + i * 140, 320, 100);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::True);

    if (i == 0)
    {
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
        gradient->set_LinearGradientAngle(30);
    }
    else
    {
        gradient->set_LinearGradientAngle(30);
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
    }
}

presentation->Save(u"linear_gradient_direction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **패턴 채우기**

패턴 채우기는 점, 줄무늬 또는 격자와 같은 두 색상 디자인을 적용합니다. 이 예제는 [IPatternFormat::set_PatternStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/set_patternstyle/)을 사용해 격자 패턴을 선택합니다. [IPatternFormat::get_BackColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/)은 밝은 회색 배경을 제공하고, [IPatternFormat::get_ForeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/)은 노란색 패턴 색을 제공합니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Pattern);
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![패턴 채우기가 적용된 직사각형](pattern-fill.png)

## **그림 채우기**

그림 채우기는 도형 내부에 이미지를 사용합니다. 이 예제는 로컬 이미지가 필요하며, [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/)을 사용해 프레젠테이션 이미지 컬렉션에 로드합니다. [IPictureFillFormat::set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/)을 타일 모드로 설정하면 이미지가 직사각형 안에서 반복됩니다. 아래는 사용된 원본 이미지입니다:

![연꽃 그림](lotus.png)

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

auto image = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(image);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(presentationImage);

presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
image->Dispose();
presentation->Dispose();
```

결과:

![그림 채우기가 적용된 도형](picture-fill.png)

### **텍스처로 그림을 타일링**

그림을 텍스처로 타일링하고 타일링 동작을 사용자 지정하려면 [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) 인터페이스와 [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) 클래스의 다음 메서드를 사용할 수 있습니다:

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): 그림 채우기 모드를 `Tile` 또는 `Stretch`로 설정합니다.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): 도형 내에서 타일 정렬을 지정합니다.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): 타일을 가로, 세로 또는 둘 다 뒤집을지 제어합니다.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): 도형 원점에서 타일의 가로 오프셋(포인트)을 설정합니다.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): 도형 원점에서 타일의 세로 오프셋(포인트)을 설정합니다.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): 타일의 가로 스케일을 백분율로 정의합니다.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): 타일의 세로 스케일을 백분율로 정의합니다.

이 예제는 로컬 이미지를 필요로 하며, 원본 크기의 50%로 반복하도록 [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/)을 구성합니다. `-32` 포인트 오프셋은 타일을 가로 및 세로로 이동시키고, 오른쪽 아래 정렬 및 양방향 플립은 반복 텍스처 배치를 결정합니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);

auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
shape->get_FillFormat()->set_FillType(FillType::Picture);

auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);

auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

presentation->Save(u"tile.pptx", SaveFormat::Pptx);
sourceImage->Dispose();
presentation->Dispose();
```

결과:

![타일 옵션](tile-options.png)

## **단색 채우기**

단색 채우기는 도형에 단일 고른 색을 적용합니다. 이 예제는 [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/)을 단색 채우기 모드로 설정하고, [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/)을 통해 노란색을 할당한 뒤, 직사각형을 프레젠테이션에 저장합니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![단색 채우기가 적용된 도형](solid-color-fill.png)

## **슬라이드 배경을 도형 채우기로 사용**

슬라이드 배경과 일치하도록 도형을 설정하려면 [IAutoShape::set_UseBackgroundFill](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/set_usebackgroundfill/)을 사용합니다. 예를 들어 템플릿 슬라이드에서 사용할 수 있습니다. 먼저 [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/)을 [FillType::NotDefined](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)으로 설정해 명시적인 채우기를 제거합니다. 이렇게 하면 도형이 스타일 채우기가 아니라 슬라이드 배경을 사용합니다. 플래그만 활성화해도 기존 명시적 채우기는 제거되지 않습니다.

이는 [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)과 다릅니다. 배경 채우기는 도형 뒤에 있는 객체를 슬라이드 배경 영역으로 가립니다만, NoFill은 해당 객체를 그대로 보여줍니다. 그라디언트는 도형 내부가 아니라 슬라이드에 맞춰 정렬됩니다.

다음 예제는 슬라이드에서 상속된 마스터 배경을 만들고, 세 개의 직사각형 뒤에 마젠타 밴드를 배치합니다. 왼쪽 직사각형은 배경을 사용하고, 가운데 직사각형은 채우기가 없으며, 오른쪽 직사각형은 배경 채우기에서 명시적인 주황색 채우기로 전환합니다.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

// 마스터에서 그라디언트를 상속합니다.
slide->get_Background()->set_Type(BackgroundType::NotDefined);
slide->get_LayoutSlide()->get_Background()->set_Type(BackgroundType::NotDefined);
auto background = slide->get_LayoutSlide()->get_MasterSlide()->get_Background();
background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Gradient);
auto gradient = background->get_FillFormat()->get_GradientFormat();
gradient->set_GradientShape(GradientShape::Linear);
gradient->set_LinearGradientAngle(0);
gradient->get_GradientStops()->Clear();
gradient->get_GradientStops()->Add(0, Color::get_DarkBlue());
gradient->get_GradientStops()->Add(1, Color::get_LightSkyBlue());

// 이 객체를 먼저 추가하면 사각형 뒤에 나타납니다.
auto band = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Magenta());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto backgroundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
backgroundShape->get_FillFormat()->set_FillType(FillType::NotDefined);
backgroundShape->set_UseBackgroundFill(true);

auto noFillShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
noFillShape->get_FillFormat()->set_FillType(FillType::NoFill);

auto explicitShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
explicitShape->get_FillFormat()->set_FillType(FillType::NotDefined);
explicitShape->set_UseBackgroundFill(true);

// 명시적 채우기를 적용하기 전에 배경 채우기를 비활성화합니다.
explicitShape->set_UseBackgroundFill(false);
explicitShape->get_FillFormat()->set_FillType(FillType::Solid);
explicitShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

presentation->Save(u"background_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과, 왼쪽부터 오른쪽 순서: **배경 채우기**, **채우기 없음**, **명시적 채우기**. 마젠타 밴드는 왼쪽과 오른쪽 직사각형에 가려지지만 가운데 직사각형을 통해 보입니다.

![배경 채우기, 채우기 없음 및 명시적 주황색 채우기가 마젠타 밴드 위에 적용된 모습](background-fill.png)

동일한 동작은 슬라이드에 직접 정의된 배경이나 레이아웃에서 상속된 배경에도 적용됩니다. 도형은 해결된 슬라이드 배경을 사용합니다; 예제에서는 슬라이드와 레이아웃 배경을 모두 정의하지 않아 마스터가 제공하도록 했습니다.

## **투명도 설정**

단색 채우기의 경우 색상의 알파 구성 요소가 불투명도를 제어합니다: 0은 완전 투명, 255는 완전 불투명합니다. 이 예제는 알파 값 128을 사용해 노란색 직사각형을 약 50% 투명하게 만들어 아래에 있는 직사각형이 보이도록 합니다. 색상은 [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/)을 통해 할당됩니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const int alpha = 128;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, Color::get_Yellow()));

presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![투명도가 적용된 도형](shape-transparency.png)

## **도형 회전**

[IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/)을 사용해 슬라이드 평면에서 도형을 회전합니다. 각도는 도 단위이며, 이 예제는 직사각형을 시계 방향으로 5도 회전시키고 프레젠테이션을 저장합니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->set_Rotation(5);

presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![도형 회전](shape-rotation.png)

## **3D 베벨 효과 추가**

[IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/)을 사용해 도형에 깊이와 베벨 가장자리를 부여합니다. 이 예제는 초록색 타원에 주황색 윤곽선을 만들고, [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/)을 4 포인트로 설정한 뒤, [IThreeDFormat::get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/)을 통해 폭과 높이가 6 포인트인 원형 상단 베벨을 적용합니다. 정면 직각 카메라와 삼점 조명이 베벨을 뚜렷하게 보이게 합니다.

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);
shape->get_ThreeDFormat()->set_Depth(4);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![3D 베벨 효과](3D-bevel-effect.png)

## **3D 회전 효과 추가**

도형의 3D 뷰는 카메라 설정으로 제어됩니다. 이 예제는 [ICamera::SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/)을 사용해 위도, 경도, 회전 각도를 각각 40, 35, 20도 로 설정합니다. [ICamera::set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/)을 통해 등각 카메라를 선택하고, [ILightRig::set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/)을 통해 균형 조명을 선택한 뒤, 서식이 적용된 직사각형을 저장합니다.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
autoShape->get_TextFrame()->set_Text(u"Hello, Aspose!");
autoShape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
autoShape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
autoShape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![3D 회전 효과](3D-rotation-effect.png)

## **도형의 흑백 렌더링 제어**

[IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) 메서드는 프레젠테이션을 흑백 모드로 보거나 처리할 때 개별 도형이 어떻게 렌더링되는지를 지정합니다. 이 메서드만으로 흑백 표시가 활성화되는 것은 아니며, 일반 색상 모드에서 도형의 채우기, 선 또는 기타 서식을 변경하지도 않습니다.

[BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) 열거형의 값을 사용해 원하는 동작을 선택합니다. 예를 들어 `Automatic`은 렌더링 애플리케이션이 변환을 선택하도록 하고, `Gray`와 `LightGray`는 회색을 사용하며, `BlackWhite`는 검은색과 흰색만, `Black`과 `White`는 단일 색을 강제하고, `Color`는 일반 색을 유지하며, `Hidden`은 흑백 모드에서 도형을 생략합니다. `NotDefined`는 도형 수준 모드가 지정되지 않았음을 의미합니다.

이 예제는 주황색 직사각형을 만들고 [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/)을 `Gray`로 설정합니다. 저장된 도형은 일반 색상 표시에서는 주황색 채우기를 유지하고, 흑백 표시를 지원하는 애플리케이션에서는 회색으로 표시됩니다:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

일반 색상 모드에서는 직사각형이 주황색 채우기를 유지합니다. 흑백 표시 워크플로에서는 모드가 `Gray`로 설정되어 있기 때문에 회색으로 표시됩니다. 이를 통해 전체 색상 슬라이드를 유지하면서 인쇄, 미리 보기 또는 흑백 표시 설정을 따르는 다른 워크플로에 대해 별도 외관을 정의할 수 있습니다.

## **서식 초기화**

[ISlide::Reset](https://reference.aspose.com/slides/cpp/aspose.slides/islide/reset/)을 사용해 레이아웃 플레이스홀더와 연결된 슬라이드 플레이스홀더의 위치, 크기 및 서식을 복원합니다. 이 예제는 레이아웃에 연결된 플레이스홀더가 있는 기존 프레젠테이션이 필요하며, 저장하기 전에 모든 슬라이드를 초기화합니다. 해당 레이아웃 플레이스홀더가 없는 도형은 초기화되지 않습니다.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**도형 서식이 최종 프레젠테이션 파일 크기에 영향을 줍니까?**

색상, 선 스타일 및 효과 설정은 일반적으로 삽입된 이미지와 미디어에 비해 거의 데이터를 추가하지 않습니다. 그림 채우기는 이미지가 프레젠테이션에 저장되기 때문에 파일 크기를 증가시킬 수 있습니다.

**동일한 서식을 공유하는 도형을 감지하여 그룹화하려면 어떻게 해야 합니까?**

각 도형의 주요 서식 속성(채우기, 선, 효과 설정)을 비교하십시오. 모든 해당 값이 일치하면 스타일을 동일하게 간주하고 논리적으로 도형을 그룹화하면 이후 스타일 관리가 간편해집니다.

**맞춤형 도형 스타일 세트를 별도 파일에 저장하여 다른 프레젠테이션에서 재사용할 수 있습니까?**

예. 원하는 스타일이 적용된 샘플 도형을 템플릿 슬라이드 파일이나 .POTX 템플릿에 저장합니다. 새 프레젠테이션을 만들 때 템플릿을 열고 필요한 스타일 도형을 복제한 뒤 필요한 곳에 서식을 다시 적용합니다.