---
title: C++ 프레젠테이션에서 도형 유효 속성 가져오기
linktitle: 유효 속성
type: docs
weight: 50
url: /ko/cpp/shape-effective-properties/
keywords:
- 도형 속성
- 카메라 속성
- 조명 장치
- 베벨 도형
- 텍스트 프레임
- 텍스트 스타일
- 글꼴 높이
- 채우기 형식
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "PowerPoint 프레젠테이션에서 로컬, 상속 및 유효 도형 서식을 구분하기 위해 C++용 Aspose.Slides 사용 방법을 배우세요."
---
## **로컬, 상속 및 유효 속성 이해**

PowerPoint 서식은 여러 곳에서 올 수 있습니다. 객체에 직접 저장된 값은 **로컬 값**입니다. 해당 값이 설정되지 않은 경우 PowerPoint는 단락 기본값, 텍스트 스타일, 레이아웃 또는 마스터 슬라이드, 테마, 프레젠테이션 수준 기본값과 같은 상위 서식 소스를 확인합니다. 이러한 값은 **상속된 값**입니다. 전체 계층 구조가 해결된 후 남는 값이 **유효 값**이며, 객체를 렌더링하는 데 사용되는 값입니다.

예를 들어 텍스트 부분이 자체 글꼴 높이를 정의하지 않을 수 있습니다. 이 경우 로컬 [font height](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseportionformat/)은 `std::numeric_limits<float>::quiet_NaN()`이며, 이는 “여기서는 설정되지 않음”을 의미합니다. 이 부분은 단락, 프레젠테이션의 기본 텍스트 스타일 또는 다른 적용 가능한 소스에서 높이를 상속받을 수 있습니다. 부분 형식에서 [GetEffective](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportionformat/)을 호출하면 최종 해결된 높이가 반환됩니다.

다음 두 종류의 서식 데이터를 다른 목적에 사용하십시오:

- 값이 정의된 위치를 제어해야 할 때 [IPortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportionformat/)과 같은 로컬 서식 객체를 읽거나 변경합니다.
- 최종 렌더링 결과가 필요할 때 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportionformateffectivedata/)와 같은 유효 데이터 객체를 읽습니다. 유효 데이터는 읽기 전용입니다.

## **로컬, 상속 및 유효 값 비교**

다음 완전한 예제는 도형을 만들고 프레젠테이션, 단락 및 부분 수준에서 글꼴 높이를 적용합니다. 각 단계는 해당 수준에서 정의된 값과 동일한 텍스트 부분에 대한 결과 유효 값을 출력합니다. 또한 서식 변경 후 유효 데이터를 다시 읽어야 하는 이유를 보여줍니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// 두 가지 다른 수준에서 상속된 값을 정의합니다.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // 이전 변경 후 유효 데이터를 읽습니다.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// 부분에 대한 로컬 값이 두 상속 값을 모두 무시합니다.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// 상속 값을 변경해도 기존 로컬 값을 대체하지 않습니다.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// 로컬 값을 지웁니다. 이제 부분이 다시 단락에서 상속됩니다.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// 단락 값을 지웁니다. 이제 프레젠테이션 기본값이 결과를 제공합니다.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

이 예제에서 우선 순위는 부분 로컬 서식, 다음은 단락 서식, 그 다음은 프레젠테이션 기본값입니다. 다른 객체는 다른 상속 체인을 가질 수 있지만 원칙은 동일합니다: 보다 구체적인 명시적 값이 우선이며, [GetEffective](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportionformat/)은 최종 결과를 반환합니다.

## **유효 텍스트 속성 가져오기**

텍스트 서식은 여러 객체에 걸쳐 분산됩니다:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/)은 여백, 정렬, 자동 맞춤 및 수직 텍스트 방향과 같은 텍스트 프레임 속성을 해결합니다.
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextstyle/)은 각 텍스트 스타일 레벨에 대한 단락 서식을 해결합니다.
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/)은 정렬, 들여쓰기 및 글머리표와 같은 단락 속성을 해결합니다.
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportionformat/)은 글꼴 높이, 글꼴, 색상, 굵게 및 기울임과 같은 문자 속성을 해결합니다.

다음 예제를 실행하려면 `text-formatting.pptx`에 최소 하나의 슬라이드와 비어 있지 않은 텍스트 프레임을 가진 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)가 포함되어 있어야 합니다. IAutoShape는 도형 컬렉션의 어느 위치에 있어도 되며, 코드는 적합한 객체를 찾아 사용하기 전에 검증합니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **유효 3D 속성 가져오기**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/)은 모든 해결된 3D 설정을 묶는 하나의 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformateffectivedata/) 객체를 반환합니다. 해당 객체의 [camera](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icameraeffectivedata/), [light rig](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilightrigeffectivedata/), [top bevel](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapebeveleffectivedata/) 및 [bottom bevel](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapebeveleffectivedata/) 데이터는 각각의 유효 설정을 노출합니다. 이러한 관련 설정을 함께 읽으면 도형의 최종 3D 외관을 이해하기가 쉬워집니다.

이 예제를 실행하려면 `shape-3d.pptx`에 첫 번째 슬라이드에 최소 하나의 도형이 포함되어 있어야 합니다. 기본값이 아닌 값을 얻고 싶다면 해당 도형에 3D 카메라, 조명 또는 베벨 설정을 적용하십시오.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **유효 테이블 서식 가져오기**

테이블 서식은 테이블 스타일과 전체 테이블, 열, 행 또는 개별 셀에 적용된 서식에서 올 수 있습니다. 명시적으로 정의된 채우기 사이에 충돌이 발생하면 우선 순위는 셀 → 행 → 열 → 전체 테이블 순입니다. 셀의 유효 서식은 해당 셀을 그리는 데 사용되는 최종 서식입니다.

이 예제를 실행하려면 `table-formatting.pptx`에 첫 번째 슬라이드에 최소 하나의 테이블이 포함되어 있어야 합니다. 테이블에는 최소 하나의 행과 하나의 열이 있어야 합니다. 코드는 첫 번째 도형이 테이블이라고 가정하는 대신 [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/)을 검색합니다.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

색상만 필요하고 채우기 유형만 필요한 경우 먼저 유효 [FillType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifillformateffectivedata/)을 확인한 다음 해당 유형에 적용되는 속성을 읽습니다—예를 들어, 단색 채우기의 경우 [SolidFillColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifillformateffectivedata/)을 사용합니다.

## **변경 후 유효 데이터 다시 읽기**

유효 데이터는 해결 시점의 서식 계층 구조를 설명합니다. 계층 구조에 참여할 수 있는 어떤 항목이라도 변경한 후에는 `GetEffective`을 다시 호출하십시오. 포함 항목:

- 객체의 로컬 서식;
- 단락 또는 텍스트 프레임 기본값;
- 테이블 스타일, 테이블, 열, 행 또는 셀 서식;
- 레이아웃 또는 마스터 슬라이드 서식;
- 테마 데이터 또는 프레젠테이션 수준 기본값;
- 슬라이드에 할당된 레이아웃 또는 마스터.

유효 데이터 객체를 영구 스냅샷으로 보관하지 마세요. Aspose.Slides는 일부 유효 데이터를 내부적으로 캐시할 수 있으며, 이후 `GetEffective` 호출은 해당 데이터를 새로 고칠 수 있습니다. 변경 전후 값을 비교해야 하는 경우, 변경하기 전에 글꼴 높이, 색상, 정렬 또는 베벨 너비와 같은 필요한 스칼라 값을 자신의 변수에 복사해 두십시오.

값을 변경하려면 해당 로컬 서식 객체를 업데이트하고 `GetEffective`을 호출하여 결과를 확인합니다. 유효 데이터 객체 자체는 읽기 전용입니다.

## **FAQ**

**How can I tell which level supplied an effective value?**  
유효 데이터에는 최종 값만 포함되고 원본은 포함되지 않습니다. 가장 구체적인 수준부터 바깥쪽으로 적용 가능한 로컬 객체들을 검사하십시오. 텍스트의 경우 부분 → 단락 → 텍스트 프레임 → 레이아웃 → 마스터 → 테마 → 프레젠테이션 기본값 순으로 확인할 수 있습니다. `std::numeric_limits<float>::quiet_NaN()` 또는 `nullptr`와 같은 정의되지 않은 값은 검색이 더 높은 수준으로 계속 진행됨을 나타냅니다.

**What happens when no level defines a property?**  
Aspose.Slides는 해당 PowerPoint 또는 라이브러리 기본값을 해결합니다. 로컬 객체가 명시적으로 정의하지 않아도 해결된 값은 유효 데이터에 나타납니다.

**Why does an effective value sometimes equal the local value?**  
로컬 값이 상속 계산에서 승리했기 때문입니다. 이는 해당 객체에 속성이 명시적으로 설정되어 있고 더 구체적인 규칙이 이를 덮어쓰지 않을 때 기대되는 동작입니다.

**When should I use local data instead of effective data?**  
특정 서식 수준을 검사하거나 편집하려면 로컬 데이터를 사용하십시오. 상속, 테마 규칙 및 적용 가능한 스타일이 모두 해결된 후 최종 외관이 필요하면 유효 데이터를 사용하십시오. [전체 비교 예제](#compare-local-inherited-and-effective-values)에서 두 데이터를 동일 워크플로우에서 모두 활용하는 방법을 확인할 수 있습니다.