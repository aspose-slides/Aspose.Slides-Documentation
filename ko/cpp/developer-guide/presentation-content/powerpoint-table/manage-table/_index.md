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
- 가로 세로 비율
- 텍스트 정렬
- 텍스트 서식
- 표 스타일
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 슬라이드에서 표를 만들고 편집하세요. 표 작업 흐름을 간소화하는 간단한 코드 예제를 확인해 보세요."
---
## **소개**

PowerPoint의 표는 정보를 표시하고 전달하는 효율적인 방법입니다. 행과 열로 구성된 셀 그리드에 있는 정보는 단순하고 이해하기 쉽습니다.

Aspose.Slides는 [Table](https://reference.aspose.com/slides/ko/cpp/aspose.slides/table/) 클래스, [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 인터페이스, [Cell](https://reference.aspose.com/slides/ko/cpp/aspose.slides/cell/) 클래스, [ICell](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icell/) 인터페이스 및 기타 유형을 제공하여 모든 종류의 프레젠테이션에서 표를 만들고, 업데이트하고, 관리할 수 있도록 합니다.

## **처음부터 표 만들기**

1. 프레젠테이션 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.
3. `columnWidth` 배열을 정의합니다.
4. `rowHeight` 배열을 정의합니다.
5. [AddTable()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addtable/) 메서드를 사용하여 슬라이드에 [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체를 추가합니다.
6. 각 [ICell](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icell/)을 반복하여 위, 아래, 오른쪽, 왼쪽 테두리에 서식을 적용합니다.
7. 표 첫 번째 행의 처음 두 셀을 병합합니다.
8. [ICell](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textframe/)에 접근합니다.
9. [TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textframe/)에 텍스트를 추가합니다.
10. 수정된 프레젠테이션을 저장합니다.

This C++ code shows you how to create a table in a presentation:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
auto pres = System::MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
auto sld = pres->get_Slides()->idx_get(0);

// 열 너비와 행 높이를 정의합니다
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// 슬라이드에 표 도형을 추가합니다
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 각 셀에 대한 테두리 형식을 설정합니다
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
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
// 첫 번째 행의 셀 1과 2를 병합합니다
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// 병합된 셀에 텍스트를 추가합니다
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// 프레젠테이션을 디스크에 저장합니다
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **표준 표의 번호 매기기**

표준 표에서는 셀 번호 매김이 단순하고 0부터 시작합니다. 표의 첫 번째 셀은 0,0(열 0, 행 0)으로 인덱스됩니다.

예를 들어, 4열 4행 표의 셀은 다음과 같이 번호가 매겨집니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This C++ code shows you how to specify the numbering for cells in a table:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
auto pres = System::MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
auto sld = pres->get_Slides()->idx_get(0);

// 열 너비와 행 높이를 정의합니다
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// 슬라이드에 표 도형을 추가합니다
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 각 셀에 대한 테두리 형식을 설정합니다
for (const auto& row : tbl->get_Rows())
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

// 프레젠테이션을 디스크에 저장합니다
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **기존 표에 접근하기**

1. 프레젠테이션 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 표가 포함된 슬라이드에 대한 참조를 가져옵니다.
3. [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체를 생성하고 null로 설정합니다.
4. 모든 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/) 객체를 반복하여 표가 발견될 때까지 탐색합니다.

   슬라이드에 단일 표만 포함된 것으로 예상될 경우, 포함된 모든 도형을 확인하면 됩니다. 도형이 표로 식별되면 [Table](https://reference.aspose.com/slides/ko/cpp/aspose.slides/table/) 객체로 형 변환할 수 있습니다. 그러나 슬라이드에 여러 표가 포함된 경우, [set_AlternativeText()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/set_alternativetext/)를 통해 필요한 표를 검색하는 것이 좋습니다.
5. [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체를 사용하여 표를 작업합니다. 아래 예제에서는 표에 새 행을 추가했습니다.
6. 수정된 프레젠테이션을 저장합니다.

This C++ code shows you how to access and work with an existing table:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// 첫 번째 슬라이드에 접근합니다
auto sld = pres->get_Slides()->idx_get(0);

// Table을 null로 초기화합니다
System::SharedPtr<ITable> tbl;

// 도형들을 순회하며 찾은 표에 대한 참조를 설정합니다
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// 두 번째 행의 첫 번째 열에 텍스트를 설정합니다
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// 수정된 프레젠테이션을 디스크에 저장합니다
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **텍스트 프레임을 소유하는 셀 찾기**

표에서 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)을 수신하는 일반 텍스트 처리 코드에서는 [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/get_parentcell/)를 사용하여 해당 [ICell](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icell/)을 조회합니다. 표 셀의 텍스트 프레임에 대해 [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/get_parentcell/)은 소유자를 반환하고 [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/get_parentshape/)는 `nullptr`를 반환합니다(표 자체도 도형이지만).

셀 좌표는 읽기 전용 [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icell/get_firstcolumnindex/) 및 [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icell/get_firstrowindex/) 메서드를 통해 확인할 수 있습니다. [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/get_parentcell/)도 읽기 전용 탐색을 제공하며, 소유자를 반환하지만 소유권을 변경하지는 않습니다. 사용하기 전에 반환된 셀이 `nullptr`인지 항상 확인하십시오.

표 셀 및 도형 소유자를 식별하는 전체 예제(스마트아트 노드와 연결된 도형 포함)는 [Search and Replace Text](/slides/ko/cpp/search-and-replace-text/)를 참조하십시오.

## **표 안의 텍스트 정렬**

1. 프레젠테이션 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체를 추가합니다.
4. 표에서 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/) 객체에 접근합니다.
5. [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)의 [IParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/)에 접근합니다.
6. 텍스트를 수직으로 정렬합니다.
7. 수정된 프레젠테이션을 저장합니다.

This C++ code shows you how to align the text in a table:

```c++
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
#include <DOM/ISlideCollection.h>
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

// Presentation 클래스의 인스턴스를 생성합니다
auto presentation = System::MakeObject<Presentation>();

// 첫 번째 슬라이드를 가져옵니다
auto slide = presentation->get_Slides()->idx_get(0);

// 열 너비와 행 높이를 정의합니다
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// 슬라이드에 표 도형을 추가합니다
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// 텍스트 프레임에 접근합니다
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// 텍스트 프레임용 Paragraph 객체를 생성합니다
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Paragraph용 Portion 객체를 생성합니다
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// 텍스트를 수직으로 정렬합니다
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// 프레젠테이션을 디스크에 저장합니다
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **표 수준에서 텍스트 서식 설정**

1. 프레젠테이션 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에서 [ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/) 객체에 접근합니다.
4. 텍스트의 [set_FontHeight()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_fontheight/)를 설정합니다.
5. [set_Alignment()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_alignment/) 및 [set_MarginRight()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraphformat/set_marginright/)를 설정합니다.
6. [set_TextVerticalType()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/textframeformat/set_textverticaltype/)를 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

This C++ code shows you how to apply your preferred formatting options to the text in a table:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Presentation 클래스의 인스턴스를 생성합니다
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// 첫 번째 슬라이드의 첫 번째 도형이 표라고 가정합니다
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// 표 셀의 글꼴 높이를 설정합니다
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// 표 셀의 텍스트 정렬과 오른쪽 여백을 한 번에 설정합니다
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// 표 셀의 텍스트 수직 유형을 설정합니다
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **표 스타일 속성 가져오기**

Aspose.Slides는 표의 스타일 속성을 검색할 수 있게 하여 해당 세부 정보를 다른 표나 다른 위치에 사용할 수 있도록 합니다. 이 C++ 코드는 표 사전 설정 스타일에서 스타일 속성을 가져오는 방법을 보여줍니다:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **표의 가로 세로 비율 잠금**

기하학적 도형의 가로 세로 비율은 서로 다른 차원에서의 크기 비율을 의미합니다. Aspose.Slides는 `AspectRatioLocked()` 속성을 제공하여 표 및 기타 도형에 대한 가로 세로 비율 잠금을 가능하게 합니다.

This C++ code shows you how to lock the aspect ratio for a table:

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**

예. 표는 [set_RightToLeft](https://reference.aspose.com/slides/ko/cpp/aspose.slides/table/set_righttoleft/) 메서드를 제공하고, 단락은 [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/ko/cpp/aspose.slides/paragraphformat/set_righttoleft/)을 지원합니다. 두 가지를 모두 사용하면 셀 내부의 올바른 RTL 순서와 렌더링이 보장됩니다.

**How can I prevent users from moving or resizing a table in the final file?**

[shape locks](/slides/ko/cpp/applying-protection-to-presentation/)를 사용하여 이동, 크기 조절, 선택 등을 비활성화합니다. 이러한 잠금은 표에도 적용됩니다.

**Is inserting an image inside a cell as a background supported?**

예. 셀에 [picture fill](https://reference.aspose.com/slides/ko/cpp/aspose.slides/picturefillformat/)을 설정하면 이미지가 선택한 모드(늘리기 또는 타일링)에 따라 셀 영역을 채웁니다.