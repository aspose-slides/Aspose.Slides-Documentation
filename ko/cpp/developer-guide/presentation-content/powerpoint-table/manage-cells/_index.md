---
title: C++를 사용하여 프레젠테이션의 표 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/cpp/manage-cells/
keywords:
- 표 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 안의 이미지
- 배경 색상
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++로 PowerPoint 표 셀을 관리합니다: 병합된 셀 식별, 테두리 제거, 셀 분할, 그리고 배경 색상 및 이미지를 Aspose.Slides for C++를 사용해 설정합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 표 셀에 액세스하고 수정할 수 있습니다. 이 문서에서는 병합된 표 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀 병합 또는 분할 후 셀 번호 매기기 작업, 셀 배경색을 변경하는 방법, 그리고 표 셀 내부에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 만들거나 열고, 슬라이드에서 표를 가져오고, 셀 속성을 통해 셀 서식을 업데이트하며, 수정된 프레젠테이션을 PPTX 파일로 저장하는 방법을 보여줍니다.

Aspose.Slides는 표 셀에 액세스하기 위해 0 기반 인덱스를 사용하며 순서는 `(column, row)` 입니다.

## **병합된 표 셀 식별**

예제는 기존 프레젠테이션을 열고 첫 번째 슬라이드의 첫 번째 도형을 표로 가져옵니다. 슬라이드와 도형이 존재하고 해당 도형이 표라고 가정합니다. 그런 다음 모든 행과 열을 순회하면서 [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/)을 사용하여 병합된 영역의 셀을 식별합니다. 일치하는 각 셀에 대해 `row;column` 순서로 셀 좌표, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), 그리고 영역의 시작 좌표인 [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) 및 [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/)를 출력합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **표 셀 테두리 제거**

새 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)을 생성하고 [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/)을 사용하여 첫 번째 슬라이드에 표를 추가합니다. 열 너비, 행 높이 및 표 위치는 포인트 단위로 지정됩니다. 예제에서는 네 개의 셀 테두리 모두를 [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)으로 설정하여 보이지 않게 합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **대각선 셀 테두리 추가**

[get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/)을 사용하여 왼쪽 위 모서리에서 오른쪽 아래 모서리까지 선을 그리고, [get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/)을 사용하여 왼쪽 아래 모서리에서 오른쪽 위 모서리까지 선을 그립니다. 대각선은 코너 헤더를 표시할 수 있으며, 두 대각선을 모두 사용하면 셀을 적용 불가능하게 표시하는 X 모양을 만들 수 있습니다.

각 대각선은 [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/)입니다. [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/)을 사용하여 채우기에 접근하고, [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/)에 [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)을 지정한 뒤 [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/)으로 색상을 선택합니다. 라인 너비는 포인트 단위로 [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/)으로 설정합니다.

예제에서는 한 행에 세 개의 셀을 만들고, 빨간색 하향 대각선, 파란색 상향 대각선, 그리고 두 대각선을 모두 가진 셀을 생성합니다. 위, 아래, 왼쪽, 오른쪽 셀 테두리는 변경하지 않은 채 둡니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({210, 210, 210});
auto rowHeights = MakeArray<double>({160});
auto table = slide->get_Shapes()->AddTable(45, 130, columnWidths, rowHeights);

auto downwardBorder = table->idx_get(0, 0)->get_CellFormat()->get_BorderDiagonalDown();
downwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
downwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
downwardBorder->set_Width(3);

auto upwardBorder = table->idx_get(1, 0)->get_CellFormat()->get_BorderDiagonalUp();
upwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
upwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
upwardBorder->set_Width(5);

auto crossDownwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalDown();
crossDownwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossDownwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
crossDownwardBorder->set_Width(3);

auto crossUpwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalUp();
crossUpwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossUpwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
crossUpwardBorder->set_Width(5);

presentation->Save(u"diagonal_cell_borders.pptx", SaveFormat::Pptx);
```

대각선은 서식 속성일 뿐이며 셀을 분할하는 것이 아닙니다. 각 셀은 [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/)을 통해 접근하는 단일 텍스트 프레임을 유지합니다; 대각선 양쪽 영역을 독립적으로 편집할 수 없습니다.

The saved table, rendered in Microsoft PowerPoint:

![왼쪽 위에서 오른쪽 아래로 빨간 대각선, 왼쪽 아래에서 오른쪽 위로 파란 대각선, 그리고 두 대각선이 X 모양을 이루는 세 개의 표 셀](diagonal-cell-borders.png)

*왼쪽에서 오른쪽 순서: 하향 대각선(빨강, 3 pt), 상향 대각선(파랑, 5 pt), 그리고 두 대각선.*

## **표 셀 병합**

[MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/)을 사용하여 사각형 범위의 표 셀을 하나의 셀로 결합합니다. 범위의 왼쪽 위와 오른쪽 아래 셀을 지정합니다. 마지막 인자는 병합이 지정된 범위 밖의 셀을 포함할지 여부를 제어하며, `false`이면 병합이 해당 범위 내에만 유지됩니다.

예제에서는 열과 행이 70 포인트인 4×4 표를 만든 뒤, 중앙에 있는 네 개의 셀을 `(1, 1)`부터 `(2, 2)`까지 병합합니다. 결과 셀은 두 열과 두 행을 차지하지만, 표의 기본 그리드는 여전히 네 열과 네 행을 유지합니다. 병합된 셀의 내용이나 서식에 액세스하려면 해당 셀의 왼쪽 위 위치인 `table->idx_get(1, 1)`을 사용합니다. 병합된 범위의 다른 위치는 표 그리드의 일부로 남아 있어, 범위 밖 셀의 인덱스는 변경되지 않습니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **표 셀 분할**

이전 예제에서 셀을 병합하면 표 그리드가 유지됩니다. 셀을 분할하면 새 그리드 열이 추가되고 오른쪽 셀의 열 인덱스가 변경될 수 있습니다. Aspose.Slides는 PowerPoint의 표 그리드 모델을 따릅니다.

이 예제에서는 열과 행이 70 포인트인 4×4 표를 만든 뒤, 셀 `(1, 1)`에 대해 [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/)를 호출합니다. 셀의 70 포인트 너비의 절반을 전달하여 두 개의 동일한 너비 셀을 생성합니다.

분할 후 두 절반은 `table->idx_get(1, 1)` 및 `table->idx_get(2, 1)`로 접근합니다. 표 그리드는 이제 다섯 열을 가지며, 원래 2·3열에 있던 셀은 각각 3·4열로 이동합니다. 행 인덱스는 변하지 않습니다. 분할 후 셀에 접근할 때는 업데이트된 열 인덱스를 사용하세요.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

<!-- visual-explanation:manage-cells:start -->
[![병합되지 않은 70포인트 셀이 두 개의 35포인트 셀로 분할되어 다섯 번째 그리드 열이 추가되고 오른쪽 인덱스가 이동합니다.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*너비 분할은 셀 (1, 1)에 영향을 주며, 0 기반 (column, row) 인덱스를 사용합니다. 다른 행은 두 새로운 열 위치를 모두 차지하는 셀을 유지합니다.*
<!-- visual-explanation:manage-cells:end -->

### **행 또는 열 범위에 따라 병합된 셀 분할**

데이터 채우기를 위해 병합된 템플릿 셀을 준비하려면 기존 행 경계를 따라 [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/)을 사용하거나 열 경계를 따라 [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/)을 사용합니다.

`index` 인수는 분할된 상부 부분의 행 수 또는 좌측 부분의 열 수를 셉니다; 이는 병합된 영역에 대해 상대적인 값입니다:

- 행 분할: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- 열 분할: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

예제에서는 프레젠테이션의 첫 번째 슬라이드 첫 번째 도형이 표이며, `(1, 2)`와 `(1, 3)`이 수직으로 병합되어 있다고 가정합니다. 아래쪽 위치에서 시작하여 [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/)와 [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/)을 사용해 시작점을 찾고 두 스팬을 확인합니다. `SplitByRowSpan(1)`은 제품 이름을 위해 행 2와 3을 분리합니다. 가로 두 열 병합의 경우 대신 `SplitByColSpan(1)`을 사용합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // 분할 후 표에서 결과 셀을 가져옵니다.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

표 그리드와 주변 셀 인덱스는 변경되지 않습니다. 좌표로 결과 셀을 검색하면, 여기서는 두 셀이 모두 span이 1이며 [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/)은 `False`를 반환합니다. 더 큰 영역은 하나의 분할 후에도 일부가 병합된 상태로 남을 수 있습니다.

원본 텍스트와 서식은 상위(또는 좌측) 셀에 그대로 남고, 새 셀은 비어 있지만 채우기, 테두리, 여백 등 셀 서식을 상속합니다. 분할 후 셀에 데이터를 채우고 필요한 텍스트 서식을 명시적으로 설정하십시오.

저장된 프레젠테이션에는 템플릿의 셀 서식을 유지한 채 별개의 "Product A"와 "Product B" 셀이 포함됩니다. 자세한 내용은 [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/)를 참조하십시오.

### **특정 높이에서 셀 분할**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/)은 위쪽 부분의 높이를 포인트 단위로 전달받습니다. [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/)은 위쪽 부분의 기존 그리드 행 수를 전달받습니다. 오른쪽 열에서 40포인트 셀을 가운데에 배치하려면 셀의 실제 높이에서 40을 빼고 남은 공간을 위와 아래에 동일하게 나눕니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/ITextFrame.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({160, 160});
auto rowHeights = MakeArray<double>({140});

auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Left");

auto height = table->idx_get(1, 0)->get_Height();
auto margin = (height - 40) / 2;

table->idx_get(1, 0)->SplitByHeight(margin);
table->idx_get(1, 1)->SplitByHeight(40);
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Middle");

presentation->Save(u"split_by_height.pptx", SaveFormat::Pptx);
```

첫 번째 분할은 그리드 행을 추가하고, 아래쪽 90 포인트를 `(1, 1)`에 남깁니다. 두 번째 분할은 해당 셀을 대상으로 하여 아래에 또 다른 행을 추가합니다. 오른쪽 열은 이제 `(1, 0)`이 50 포인트(`margin`), `(1, 1)`이 40 포인트, `(1, 2)`가 50 포인트(`margin`)를 가집니다. 왼쪽 셀은 원래 높이인 140 포인트로 세 행 전체를 차지합니다.

![왼쪽 셀은 전체 표 높이를 차지하고, 가운데에 Middle이 있는 세 개의 셀과 함께합니다.](split-by-height.png)

## **표 셀 배경색 변경**

예제에서는 열이 150포인트, 행이 50포인트인 표를 생성합니다. [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/)을 사용하여 단색 채우기를 선택하고, [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/)으로 채우기 색상에 접근하여 셀 `(2, 3)`(세 번째 열, 네 번째 행)의 색상을 빨강으로 설정합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **표 셀 내부에 이미지 추가**

이 예제를 실행하기 전에 입력 이미지를 작업 디렉터리에 배치하십시오. [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/)을 사용해 이미지를 로드하고 [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/)으로 프레젠테이션의 이미지 컬렉션에 추가합니다. 그런 다음 이미지를 표의 첫 번째 셀인 `(0, 0)`의 그림 채우기에 할당합니다.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/)은 이미지를 셀에 맞게 늘려 채우며, 이 경우 종횡비가 변경될 수 있습니다. 열 너비와 행 높이는 포인트 단위입니다. 로드된 이미지는 프레젠테이션에 추가된 후 해제됩니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **FAQ**

**단일 셀의 각 면마다 다른 선 두께와 스타일을 설정할 수 있나요?**

예. [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) 테두리는 각각 별도의 속성을 가지고 있어 각 면의 두께와 스타일을 다르게 설정할 수 있습니다.

**셀 배경에 그림을 설정한 후 열/행 크기를 변경하면 이미지가 어떻게 되나요?**

동작은 [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/)에 따라 달라집니다. stretch인 경우 이미지가 새 셀에 맞게 조정되고, tile인 경우 타일이 다시 계산됩니다.

**셀의 모든 내용에 하이퍼링크를 할당할 수 있나요?**

[Hyperlinks](/slides/ko/cpp/manage-hyperlinks/)는 셀 텍스트 프레임 내부의 텍스트(부분) 수준이나 전체 표/도형 수준에서 설정됩니다. 실제로는 셀의 특정 부분이나 전체 텍스트에 링크를 할당합니다.

**단일 셀 안에서 서로 다른 글꼴을 설정할 수 있나요?**

예. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (런)별로 독립적인 서식을 지원하므로 글꼴 종류, 스타일, 크기, 색상을 각각 설정할 수 있습니다.