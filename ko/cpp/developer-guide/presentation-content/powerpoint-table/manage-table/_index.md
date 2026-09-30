---
title: C++에서 프레젠테이션 표 관리
linktitle: 표 관리
type: docs
weight: 10
url: /ko/cpp/manage-table/
keywords:
- 표 추가
- 표 만들기
- 표 접근
- 가로세로 비율
- 텍스트 정렬
- 텍스트 서식
- 표 스타일
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 슬라이드에서 표를 만들고 편집하십시오. 표 작업 흐름을 간소화하는 간단한 코드 예제를 확인하세요."
---
## **소개**

PowerPoint의 표는 정보를 행과 열로 정리하여 값을 읽고 비교하기 쉽게 합니다.

Aspose.Slides는 [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) 클래스, [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 인터페이스, [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) 클래스, [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) 인터페이스 및 기타 유형을 제공하여 프레젠테이션에서 표를 만들고, 업데이트하고, 관리할 수 있게 합니다.

## **스크래치에서 표 만들기**

위치, 열 너비 및 행 높이를 지정하여 표를 생성합니다. 슬라이드에 추가한 후에는 셀 테두리를 서식 지정하고, 셀을 병합하고, 텍스트를 삽입할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 포인트 단위의 열 너비 배열을 정의합니다.
4. 포인트 단위의 행 높이 배열을 정의합니다.
5. [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 메서드를 통해 슬라이드에 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 객체를 추가합니다.
6. 각 [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/)을 반복하여 상단, 하단, 오른쪽 및 왼쪽 테두리에 서식을 적용합니다.
7. 표 첫 번째 행의 처음 두 셀을 병합합니다.
8. 병합된 셀을 [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) 메서드를 통해 접근합니다.
9. 병합된 셀에 텍스트를 설정합니다.
10. 수정된 프레젠테이션을 저장합니다.

아래 예제는 (100, 50) 포인트 위치에 열 3개와 행 5개인 표를 생성합니다. 테두리 두께 5포인트의 빨간색 테두리를 적용하고, 첫 번째 행의 처음 두 셀을 병합한 후 결과를 `table.pptx`로 저장합니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **표준 표에서 번호 매기기**

표준 표에서 셀 인덱스는 0부터 시작하며 (열, 행) 순서를 사용합니다. 첫 번째 셀은 (0, 0)으로 인덱싱됩니다.

예를 들어, 4열 4행 표의 셀은 다음과 같이 번호가 매겨집니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

이 예제는 위에 표시된 4 × 4 표를 생성하며, 열 너비와 행 높이는 70포인트이고 빨간색 셀 테두리 두께는 5포인트입니다. 좌표는 셀 인덱스를 나타냅니다; 예제는 셀을 비워 두고 표를 `StandardTables_out.pptx`로 저장합니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **기존 표에 액세스하기**

표는 슬라이드의 도형 컬렉션에 저장됩니다. 도형들을 반복하여 표를 찾은 다음, [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 인터페이스를 사용해 셀을 읽거나 업데이트합니다.

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스를 사용하여 프레젠테이션을 로드합니다.
2. 인덱스로 테이블이 포함된 슬라이드에 대한 참조를 가져옵니다.
3. [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 객체들을 반복하고 표를 찾으면 중지합니다. 슬라이드에 여러 표가 있는 경우, [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/)을 사용하여 필요한 표를 식별합니다.
4. 대상 셀의 텍스트를 업데이트합니다.
5. 수정된 프레젠테이션을 저장합니다.

아래 예제는 `UpdateExistingTable.pptx`를 열고 첫 번째 슬라이드에서 첫 번째 표를 찾습니다. 열 0, 행 1 위치의 셀을 `New`로 설정하고 결과를 `table1_out.pptx`로 저장합니다. 입력 파일에는 최소 하나의 슬라이드가 있어야 하며, 해당 슬라이드의 첫 번째 표는 최소 하나의 열과 두 개의 행을 가져야 합니다.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

기존 표의 행 크기를 조정하고, 실제 높이가 요청된 최소값을 초과할 수 있는 이유를 이해하려면 [행 높이 제어](/slides/ko/cpp/manage-rows-and-columns/#control-row-height)를 참조하십시오.

## **텍스트 프레임을 소유하는 셀 찾기**

일반 텍스트 처리 코드가 표에서 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)을 받으면, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/)을 사용하여 소유자 [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/)을 가져옵니다. 표 셀의 텍스트 프레임의 경우, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/)은 소유자를 반환하고 [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/)은 `nullptr`을 반환합니다(표 자체도 도형이지만).

셀 좌표는 읽기 전용 [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) 및 [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) 메서드를 통해 확인할 수 있습니다. [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/)은 또한 읽기 전용 탐색을 제공하며, 소유자를 반환하지만 소유권을 변경하지 않습니다. 사용하기 전에 항상 반환된 셀이 `nullptr`인지 확인하십시오.

테이블 셀 및 도형 소유자를 식별하는 전체 예제(스마트아트 노드와 연결된 도형 포함)는 [텍스트 검색 및 교체](/slides/ko/cpp/search-and-replace-text/)를 참조하십시오.

## **표에서 텍스트 정렬**

개별 표 셀의 수직 고정 및 텍스트 방향을 제어할 수 있습니다. 이 섹션의 예제는 첫 번째 셀의 텍스트를 가운데 정렬하고 270도 회전합니다.

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 객체를 추가합니다.
4. 표에서 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 객체에 액세스합니다.
5. 첫 번째 [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/)에 액세스하고 텍스트와 색상을 설정합니다.
6. [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) 및 [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/)을 사용하여 셀의 수직 고정 및 텍스트 방향을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

이 예제는 열 너비 120포인트, 행 높이 100포인트인 4 × 4 표를 생성합니다. 셀 (0, 0)의 텍스트를 서식 지정하고, 첫 번째 행의 나머지 셀에 값을 추가한 후 결과를 `Vertical_Align_Text_out.pptx`로 저장합니다.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **표 수준에서 텍스트 서식 설정**

[SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/)을 사용하여 표의 모든 셀에 텍스트 서식을 적용합니다. 이 메서드의 오버로드는 구간, 단락 및 텍스트 프레임 서식을 허용하므로 개별 셀을 반복하지 않고도 이러한 속성을 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스를 사용하여 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에서 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 객체에 액세스합니다.
4. 텍스트에 대해 [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/)을 사용하여 글꼴 크기를 설정합니다.
5. [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) 및 [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/)을 사용하여 단락 정렬 및 오른쪽 여백을 설정합니다.
6. [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/)을 사용하여 텍스트 방향을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

아래 예제는 `table.pptx`를 열며, 이 파일은 최소 하나의 슬라이드에 첫 번째 도형으로 표가 포함되어 있어야 합니다. 글꼴 크기를 25포인트로 설정하고, 단락을 오른쪽 정렬하며 오른쪽 여백을 20포인트로 지정하고, 텍스트를 수직으로 만듭니다. 서식이 적용된 프레젠테이션은 `result.pptx`로 저장됩니다.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **표 스타일 속성 가져오기**

[get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/)을 사용하여 표의 사전 정의된 스타일을 읽고, [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/)으로 지정합니다. 이 예제는 한 표에 [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/)을 적용하고, 프리셋 이름을 출력한 다음, 동일한 프리셋을 두 번째 표에 할당합니다. 두 표 모두 `table-style.pptx`에 저장됩니다.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **표의 가로세로 비율 잠금**

표의 가로세로 비율은 너비와 높이의 비율입니다. [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/)을 사용하여 표의 비율을 잠글 수 있습니다.

아래 예제는 `pres.pptx`를 열며, 이 파일은 최소 하나의 슬라이드에 첫 번째 도형으로 표가 포함되어 있어야 합니다. 현재 잠금 상태를 출력하고, 가로세로 비율 잠금을 활성화한 뒤, 업데이트된 상태(`True`)를 출력하고 결과를 `pres-out.pptx`로 저장합니다.

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**전체 표와 셀 내부 텍스트에 대해 오른쪽에서 왼쪽(RTL) 읽기 방향을 활성화할 수 있나요?**

예. 표는 [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) 메서드를 제공하고, 단락에는 [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/)이 있습니다. 두 메서드를 모두 사용하면 셀 내부에서 올바른 RTL 순서와 렌더링이 보장됩니다.

**최종 파일에서 사용자가 표를 이동하거나 크기를 조정하지 못하도록 하려면 어떻게 해야 하나요?**

[shape locks](/slides/ko/cpp/applying-protection-to-presentation/)을 사용하여 이동, 크기 조정, 선택 등을 비활성화합니다. 이러한 잠금은 표에도 적용됩니다.

**셀 내부에 이미지를 배경으로 삽입하는 것이 지원되나요?**

예. 셀에 대해 [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/)을 설정할 수 있으며, 선택한 모드(늘리기 또는 타일)에 따라 이미지가 셀 영역을 채웁니다.