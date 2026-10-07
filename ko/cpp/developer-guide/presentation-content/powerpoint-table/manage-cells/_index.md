---
title: C++를 사용하여 프레젠테이션의 테이블 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/cpp/manage-cells/
keywords:
- 테이블 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 안의 이미지
- 배경 색상
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 테이블 셀을 관리합니다: 병합 셀 식별, 테두리 제거, 셀 분할 및 배경 색상과 이미지를 설정합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 테이블 셀에 액세스하고 수정할 수 있습니다. 이 문서에서는 병합된 테이블 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 후 셀 번호를 처리하는 방법, 셀의 배경색을 변경하는 방법 및 테이블 셀 안에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 만들거나 열고, 슬라이드에서 테이블을 가져오며, 셀 속성을 통해 셀 서식을 업데이트하고, 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 보여줍니다.

Aspose.Slides는 `(column, row)` 순서로 테이블 셀에 접근하기 위해 0부터 시작하는 인덱스를 사용합니다.

## **병합된 테이블 셀 식별**

예제는 기존 프레젠테이션을 열고 첫 번째 슬라이드의 첫 번째 모양을 테이블로 접근합니다. 슬라이드와 모양이 존재하며 해당 모양이 테이블이라고 가정합니다. 그런 다음 모든 행과 열을 순회하면서 [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/)을 사용하여 병합 영역에 있는 셀을 식별합니다. 일치하는 셀마다 `row;column` 순서로 셀 좌표와 [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), 그리고 영역의 시작 좌표인 [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) 및 [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/)을 출력합니다.

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

## **테이블 셀 테두리 제거**

[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)을 생성하고 [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/)을 사용하여 첫 번째 슬라이드에 테이블을 추가합니다. 열 너비, 행 높이 및 테이블 위치는 포인트 단위로 지정됩니다. 예제에서는 모든 네 개의 셀 테두리를 [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)으로 설정하여 보이지 않게 합니다.

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

## **테이블 셀 병합**

[MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/)을 사용하여 사각형 범위의 테이블 셀을 하나의 셀로 결합합니다. 범위의 왼쪽 위와 오른쪽 아래 모서리에 있는 셀을 지정합니다. 마지막 인자는 병합이 지정된 범위 밖의 셀을 포함할 수 있는지를 제어하며, `false`는 병합을 해당 범위 내에만 유지합니다.

예제에서는 70포인트 열과 행을 가진 4×4 테이블을 만든 다음 `(1, 1)`부터 `(2, 2)`까지 네 개의 중앙 셀을 병합합니다. 결과 셀은 두 열과 두 행을 차지하지만, 테이블의 기본 그리드는 네 열과 네 행을 유지합니다. 병합된 셀의 내용이나 서식에 접근하려면 이 예제에서는 `table->idx_get(1, 1)`을 사용하여 왼쪽 위 위치를 지정합니다. 병합 범위에 포함되지 않은 다른 위치는 테이블 그리드의 일부로 남아 있어 범위 외 셀의 인덱스는 변경되지 않습니다.

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

## **테이블 셀 분할**

이전 예제에서 셀을 병합하면 테이블 그리드가 유지됩니다. 셀을 분할하면 새로운 그리드 열이 추가되고 오른쪽에 있는 셀의 열 인덱스가 변경될 수 있습니다. Aspose.Slides는 PowerPoint의 테이블 그리드 모델을 따릅니다.

예제에서는 70포인트 열과 행을 가진 4×4 테이블을 만든 후 셀 `(1, 1)`에 대해 [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/)을 호출합니다. 셀의 70포인트 폭 중 절반을 전달하여 두 개의 동일한 너비 셀을 생성합니다.

이 분할 후 두 반쪽은 `table->idx_get(1, 1)`과 `table->idx_get(2, 1)`으로 접근됩니다. 테이블 그리드는 이제 다섯 개의 열을 가지고: 원래 열 2와 3에 있던 셀은 각각 열 3과 4로 이동합니다. 행 인덱스는 변하지 않습니다. 분할 후 셀에 접근할 때는 업데이트된 열 인덱스를 사용하십시오.

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

### **행 또는 열 스팬에 따라 병합된 셀 분할**

데이터 채우기를 위해 병합된 템플릿 셀을 준비하려면 기존 행 경계에 따라 분할하는 [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) 또는 열 경계에 따라 분할하는 [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/)을 사용하십시오.

`index` 인자는 분할의 상위 부분에 있는 행 또는 왼쪽 부분에 있는 열을 계산하며, 병합된 영역을 기준으로 합니다:

- 행 분할: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- 열 분할: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

예제는 프레젠테이션에 첫 번째 슬라이드의 첫 번째 모양으로 테이블이 존재하고, `(1, 2)`와 `(1, 3)`이 수직으로 병합되어 있다고 가정합니다. 아래 위치에서 시작하여 [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/)와 [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/)을 사용해 원점을 찾고 두 스팬을 확인합니다. `SplitByRowSpan(1)`은 제품 이름을 위해 행 2와 3을 분리합니다. 수평 두 열 병합의 경우 대신 `SplitByColSpan(1)`을 사용하십시오.

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

    // 분할 후 테이블에서 결과 셀을 가져옵니다.
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

테이블 그리드와 주변 셀 인덱스는 그대로 유지됩니다. 결과 셀을 좌표로 검색하면 두 셀 모두 스팬이 1이며 [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/)은 `False`를 반환합니다. 하나의 분할 후에도 더 큰 영역은 일부가 병합된 상태로 남을 수 있습니다.

원본 텍스트와 서식은 상위(또는 좌측) 셀에 남고, 새 셀은 비어 있지만 채우기, 테두리 및 여백과 같은 셀 서식을 상속합니다. 분할 후 셀에 내용을 채우고 필요한 텍스트 서식을 명시적으로 설정하십시오.

저장된 프레젠테이션에는 템플릿의 셀 서식이 유지된 채 "Product A"와 "Product B" 셀이 별도로 포함됩니다. 자세한 내용은 [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/)를 참조하십시오.

## **테이블 셀 배경색 변경**

예제에서는 150포인트 열과 50포인트 행을 가진 테이블을 만들고, [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/)을 사용해 단색 채우기를 선택한 뒤, [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/)으로 채우기 색상을 가져와 셀 `(2, 3)`(세 번째 열, 네 번째 행)의 배경색을 빨간색으로 설정합니다.

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

## **테이블 셀 안에 이미지 삽입**

예제를 실행하기 전에 입력 이미지를 작업 디렉터리에 배치하십시오. 이미지는 [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/)으로 로드되고, [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/)을 사용해 프레젠테이션의 이미지 컬렉션에 추가됩니다. 그런 다음 이미지를 테이블의 첫 번째 셀인 `(0, 0)`의 그림 채우기에 할당합니다.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/)은 이미지를 셀에 맞게 늘려 비율이 바뀔 수 있습니다. 열 너비와 행 높이는 포인트 단위입니다. 로드된 이미지는 프레젠테이션에 추가된 후 폐기됩니다.

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

**단일 셀의 서로 다른 면에 대해 다른 선 두께와 스타일을 설정할 수 있나요?**

예. [상단](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[하단](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[왼쪽](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[오른쪽](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) 테두리는 개별 속성을 가지므로 각 면의 두께와 스타일을 다르게 지정할 수 있습니다.

**셀 배경에 그림을 설정한 후 열/행 크기를 변경하면 이미지가 어떻게 되나요?**

동작은 [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/)(stretch/tile)에 따라 다릅니다. stretch인 경우 이미지는 새로운 셀 크기에 맞게 조정되고, tile인 경우 타일이 다시 계산됩니다.

**셀의 전체 내용에 하이퍼링크를 지정할 수 있나요?**

[하이퍼링크](/slides/ko/cpp/manage-hyperlinks/)는 셀 텍스트 프레임 내부의 텍스트(부분) 수준이나 전체 테이블/모양 수준에 설정됩니다. 실제로는 셀 안의 일부 텍스트에 링크를 지정하거나 셀 전체 텍스트에 링크를 지정합니다.

**단일 셀 내에서 서로 다른 글꼴을 설정할 수 있나요?**

예. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (런) 단위로 독립적인 서식—글꼴 종류, 스타일, 크기 및 색상—을 지원합니다.