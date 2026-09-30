---
title: C++를 사용하여 PowerPoint 표의 행과 열 관리
linktitle: 행과 열
type: docs
weight: 20
url: /ko/cpp/manage-rows-and-columns/
keywords:
- 테이블 행
- 테이블 열
- 첫 번째 행
- 테이블 헤더
- 행 복제
- 열 복제
- 행 복사
- 열 복사
- 행 삭제
- 열 삭제
- 행 텍스트 서식
- 열 텍스트 서식
- 테이블 스타일
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint에서 표의 행과 열을 관리하고 프레젠테이션 편집 및 데이터 업데이트를 빠르게 수행합니다."
---
## **소개**

Aspose.Slides for C++는 PowerPoint 프레젠테이션에서 [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) 클래스와 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 인터페이스를 통해 표 구조와 서식을 관리할 수 있도록 합니다. 헤더 행을 지정하고, 행 및 열을 복제하거나 제거하며, 전체 행이나 열에 텍스트 서식을 적용할 수 있습니다.

이 문서는 이러한 작업을 C++ 예제와 함께 설명합니다. 또한 표의 스타일 프리셋을 검색하여 재사용하는 방법을 보여줍니다. 표 행 및 열 인덱스는 0부터 시작합니다.

## **행 높이 제어**

[IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/)을 사용하여 행의 최소 높이를 포인트 단위로 설정합니다. 이는 고정 높이가 아니라 하한선입니다. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/)은 실제 높이를 반환하며, 이 값은 직접 설정할 수 없습니다. 행은 [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/)를 통해 접근합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형으로 표가 포함된 [row-height-input.pptx](row-height-input.pptx)를 로드합니다. 첫 번째 행은 70포인트에서 시작합니다. 셀은 18포인트 Arial 텍스트, 자동 줄 바꿈, 위·아래 여백 6포인트를 사용합니다; 두 번째 열의 긴 텍스트는 여러 줄로 자동 줄 바꿈됩니다. 예제는 최소값을 100포인트로 증가시켰다가 20포인트로 감소시키고, 각 변경 후 실제 높이를 출력한 뒤 두 결과를 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

제공된 프레젠테이션에서 최소값을 증가하면 행에 공간이 추가됩니다. 최소값을 감소하면 그 여분의 공간이 제거되지만, 텍스트와 셀 여백 때문에 실제 높이는 20포인트보다 큽니다. 최소값만 줄인다고 해서 내용이 요구하는 공간보다 낮게 행을 강제로 만들 수는 없습니다.

실제 높이에 영향을 주는 여러 요소:

- **텍스트 및 글꼴 크기:** 긴 텍스트, 명시적인 줄 바꿈, 또는 큰 글꼴은 더 많은 수직 공간을 필요로 할 수 있습니다.
- **줄 바꿈 및 열 너비:** 줄 바꿈이 활성화된 상태에서 [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/)로 열 너비를 줄이면 더 많은 줄이 생성될 수 있습니다. 넓은 열은 수직 공간 요구량을 줄일 수 있습니다.
- **셀 여백:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) 및 [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/)는 수직 여백을 추가합니다. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/)와 [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/)는 텍스트에 사용 가능한 너비를 줄여 추가 줄 바꿈을 유발할 수 있습니다.

병합된 셀이 없는 이 표에서는 가장 많은 수직 공간을 필요로 하는 셀이 전체 행에 대한 내용 기반 하한을 결정합니다. 행을 짧게 만들려면 텍스트를 짧게 하거나, 글꼴 크기·여백을 줄이거나, 열을 넓혀야 할 수도 있습니다.

아래 이미지는 동일한 표를 동일한 배율로 보여줍니다. 여기서 .NET 실행 결과 실제 높이는 각각 70, 100, 55.2포인트였으며, 최종 행은 20포인트 최소값보다 높게 유지되었습니다. 정확한 텍스트 측정값은 환경에 따라 사용 가능한 글꼴에 따라 달라질 수 있습니다. 저장된 결과를 다운로드하십시오: [증가된 최소값](row-height-increased.pptx) 및 [감소된 최소값](row-height-decreased.pptx).

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![70포인트 첫 번째 행이 있는 원본 표.](row-height-before.png) | ![첫 번째 행 최소값을 100포인트로 증가시킨 표.](row-height-increased.png) | ![첫 번째 행 최소값을 20포인트로 감소시킨 표; 줄 바꿈된 텍스트 때문에 행이 최소값보다 높게 유지됩니다.](row-height-decreased.png) |

## **첫 번째 행을 헤더로 설정**

[set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) 메서드를 사용하여 첫 번째 행을 헤더 서식으로 표시합니다. 헤더의 모양은 표에 적용된 표 스타일에 따라 달라집니다.

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드합니다.
2. 첫 번째 슬라이드에 접근합니다.
3. 슬라이드의 첫 번째 도형으로 저장된 표에 접근합니다.
4. 첫 번째 행에 헤더 서식을 활성화합니다.
5. 수정된 프레젠테이션을 저장합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형으로 표가 포함된 `table.pptx`를 필요로 합니다. 첫 번째 행에 헤더 서식을 적용하고 `First_row_header.pptx`로 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **표 행 또는 열 복제**

행이나 열을 복제하여 내용과 서식을 재사용할 수 있습니다. 복제본을 표 끝에 추가하거나 특정 위치에 삽입할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드합니다.
2. 첫 번째 슬라이드에 접근합니다.
3. 열 너비와 행 높이를 정의합니다.
4. [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 메서드로 표를 추가합니다.
5. 필요한 행을 복제합니다.
6. 필요한 열을 복제합니다.
7. 수정된 프레젠테이션을 저장합니다.

예제는 최소 하나의 슬라이드가 있는 `Test.pptx`를 필요로 합니다. 세 개의 열과 다섯 개의 행을 가진 표를 생성하고, 각 차원을 포인트 단위로 지정합니다. 첫 번째 행과 열을 복제하여 끝에 추가하고, 두 번째 행과 열을 인덱스 3(네 번째 위치)에 삽입합니다. 결과 표는 일곱 개의 행과 다섯 개의 열을 갖게 됩니다. `false` 인자는 인접한 병합 행이나 열에 대한 복제를 비활성화합니다; 이 표에는 병합된 셀이 없습니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **표에서 행 또는 열 제거**

표에서 더 이상 필요하지 않은 행이나 열을 제거합니다. 항목을 제거하면 그 뒤에 있는 행이나 열의 인덱스가 이동합니다.

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스로 프레젠테이션을 생성합니다.
2. 첫 번째 슬라이드에 접근합니다.
3. 열 너비와 행 높이를 정의합니다.
4. [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 메서드로 표를 추가합니다.
5. 두 번째 행과 두 번째 열을 제거합니다.
6. 수정된 프레젠테이션을 저장합니다.

이 예제는 3×3 표를 만든 뒤 인덱스 1에 있는 행과 열을 제거하여 `TestTable_out.pptx`에 2×2 표를 남깁니다. 차원은 포인트 단위입니다. `false` 인자는 인접한 병합 행·열 제거를 비활성화합니다; 이 표에는 병합된 셀이 없습니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **표 행 수준의 텍스트 서식 설정**

전체 행에 텍스트 서식을 적용하여 셀 간 일관성을 유지합니다. 각 셀을 개별적으로 서식 지정하지 않고도 글꼴 속성, 단락 서식, 텍스트 방향을 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드합니다.
2. 첫 번째 슬라이드의 표에 접근합니다.
3. 첫 번째 행에 대해 [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) 로 글꼴 높이를 설정합니다.
4. 첫 번째 행에 대해 [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) 과 [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) 로 정렬 및 오른쪽 단락 여백을 설정합니다.
5. 두 번째 행에 대해 [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) 로 텍스트 방향을 설정합니다.
6. 수정된 프레젠테이션을 저장합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형에 표가 포함된 `table.pptx`와 최소 두 개의 행을 필요로 합니다. 첫 번째 행에 25포인트 텍스트, 오른쪽 정렬, 20포인트 오른쪽 단락 여백을 적용하고, 두 번째 행에 수직 텍스트를 설정합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **표 열 수준의 텍스트 서식 설정**

전체 열에 텍스트 서식을 적용하여 셀 간 일관성을 유지합니다. 각 셀을 개별적으로 서식 지정하지 않고도 글꼴 속성, 단락 서식, 텍스트 방향을 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스로 프레젠테이션을 로드합니다.
2. 첫 번째 슬라이드의 표에 접근합니다.
3. 첫 번째 열에 대해 [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) 로 글꼴 높이를 설정합니다.
4. 첫 번째 열에 대해 [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) 와 [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) 로 정렬 및 오른쪽 단락 여백을 설정합니다.
5. 두 번째 열에 대해 [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) 로 텍스트 방향을 설정합니다.
6. 수정된 프레젠테이션을 저장합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형에 표가 포함된 `table.pptx`와 최소 두 개의 열을 필요로 합니다. 첫 번째 열에 25포인트 텍스트, 오른쪽 정렬, 20포인트 오른쪽 단락 여백을 적용하고, 두 번째 열에 수직 텍스트를 설정합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **표 스타일 속성 가져오기**

[get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) 메서드를 사용하여 표에 적용된 프리셋을 검색하고 다른 표에 재사용할 수 있습니다. 이는 개별 셀 서식 재정의가 아니라 프리셋 자체를 식별합니다.

예제는 표를 만든 뒤 [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) 를 적용하고 프리셋을 다시 읽습니다. `DarkStyle1`을 출력하고 표를 `table.pptx`에 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**이미 만든 테이블에 PowerPoint 테마/스타일을 적용할 수 있나요?**

네. 표는 슬라이드/레이아웃/마스터 테마를 상속받으며, 그 위에 채우기, 테두리 및 텍스트 색을 재정의할 수 있습니다.

**Excel처럼 표 행을 정렬할 수 있나요?**

아니요, Aspose.Slides 표에는 내장된 정렬이나 필터 기능이 없습니다. 데이터를 먼저 메모리에서 정렬한 뒤 해당 순서대로 표 행을 다시 채워야 합니다.

**특정 셀에 사용자 지정 색상을 유지하면서 스트라이프(밴드) 열을 적용할 수 있나요?**

네. 밴드 열을 활성화한 뒤 특정 셀에 로컬 서식을 적용하면 됩니다. 셀 수준 서식이 표 스타일보다 우선합니다.