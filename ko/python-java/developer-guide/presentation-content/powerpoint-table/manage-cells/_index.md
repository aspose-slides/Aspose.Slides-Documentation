---
title: Python을 사용한 프레젠테이션 테이블 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/python-java/manage-cells/
keywords:
- 테이블 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 내 이미지
- 배경 색
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python에서 Aspose.Slides for Java를 통해 PowerPoint 테이블 셀을 관리합니다: 병합 셀 식별, 테두리 제거, 셀 분할, 배경 색 및 이미지 설정."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 테이블 셀에 접근하고 수정할 수 있습니다. 이 문서에서는 병합된 테이블 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 후 셀 번호를 처리하는 방법, 셀 배경 색을 변경하는 방법 및 테이블 셀 안에 이미지를 삽입하는 방법을 설명합니다. 예제에서는 프레젠테이션을 만들거나 열고, 슬라이드에서 테이블을 가져오고, 셀 속성을 통해 셀 서식을 업데이트한 다음 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 보여줍니다.

Aspose.Slides는 `(column, row)` 순서의 0 기반 인덱스를 사용하여 테이블 셀에 접근합니다.

## **병합된 테이블 셀 식별**

예제는 기존 프레젠테이션을 열고 첫 번째 슬라이드의 첫 번째 도형을 테이블로 접근합니다. 슬라이드와 도형이 존재하며 도형이 테이블이라고 가정합니다. 그런 다음 모든 행과 열을 순회하면서 [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) 을 사용해 병합 영역의 셀을 식별합니다. 일치하는 셀마다 `row;column` 순서의 셀 좌표와 [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan), 그리고 영역 시작 좌표인 [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) 및 [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex)을 출력합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **테이블 셀 테두리 제거**

[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)을 생성하고 첫 번째 슬라이드에 [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) 로 테이블을 추가합니다. 열 너비, 행 높이 및 테이블 위치는 포인트 단위로 지정됩니다. 예제는 모든 네 면의 셀 테두리를 [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) 로 설정하여 보이지 않게 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **대각선 셀 테두리 추가**

[getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) 을 사용해 왼쪽 위 모서리에서 오른쪽 아래 모서리까지 선을 그리고, [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) 을 사용해 왼쪽 아래 모서리에서 오른쪽 위 모서리까지 선을 그립니다. 대각선은 코너 헤더를 표시할 수 있으며, 두 대각선을 교차시켜 X 표시로 셀을 적용 불가로 표시할 수 있습니다.

각 대각선은 [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/) 입니다. 해당 [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) 에서 [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) 로 [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) 을 선택하고, [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) 로 색상을 지정합니다. [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) 로 선의 두께를 포인트 단위로 설정합니다.

예제는 한 행에 세 개 셀을 만들고 각각 빨간색 하향 대각선, 파란색 상승 대각선, 그리고 두 대각선을 모두 그린 셀을 생성합니다. 상·하·좌·우 테두리는 그대로 유지됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

대각선은 서식 속성이며 셀 분할이 아닙니다. 각 셀은 [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) 으로 접근되는 단일 텍스트 프레임을 보유합니다. 대각선 양쪽 영역은 독립적으로 편집할 수 없습니다.

Microsoft PowerPoint에서 렌더링된 저장된 테이블:

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*왼쪽에서 오른쪽 순서: 하향 대각선(빨간색, 3 pt), 상승 대각선(파란색, 5 pt), 두 대각선이 교차한 X.*

## **테이블 셀 병합**

[mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) 을 사용해 직사각형 범위의 테이블 셀을 단일 셀로 결합합니다. 범위의 왼쪽 위와 오른쪽 아래 모서리 셀을 지정합니다. 마지막 인자는 지정된 범위 외의 셀을 포함할지 여부를 제어하며, `False` 로 설정하면 범위 내에서만 병합됩니다.

예제는 70포인트 열과 행을 가진 4×4 테이블을 만든 뒤 중앙 네 셀을 `(1, 1)`부터 `(2, 2)`까지 병합합니다. 결과 셀은 두 열과 두 행을 차지하지만, 테이블의 기본 그리드는 여전히 네 열과 네 행을 유지합니다. 병합된 셀의 내용이나 서식에 접근하려면 이 예제에서는 `table.get_Item(1, 1)` 을 사용합니다. 병합 범위 외의 셀 위치는 변하지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **테이블 셀 분할**

앞 예제의 셀 병합은 테이블 그리드를 유지합니다. 셀을 분할하면 새 그리드 열이 추가되고 오른쪽 셀의 열 인덱스가 변경될 수 있습니다. Aspose.Slides는 PowerPoint의 테이블 그리드 모델을 따릅니다.

이 예제는 70포인트 열과 행을 가진 4×4 테이블을 만든 뒤 셀 `(1, 1)` 에 대해 [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) 을 호출합니다. 셀의 70포인트 너비 절반을 전달해 두 개의 동일 너비 셀을 생성합니다.

분할 후 두 반은 `table.get_Item(1, 1)` 와 `table.get_Item(2, 1)` 로 접근됩니다. 이제 테이블 그리드는 5열이 되며, 원래 2열과 3열에 있던 셀은 각각 3열과 4열로 이동합니다. 행 인덱스는 변하지 않습니다. 분할 후 셀에 접근할 때는 업데이트된 열 인덱스를 사용하세요.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

<!-- visual-explanation:manage-cells:start -->
[![An unmerged 70-point cell splits into two 35-point cells, adding a fifth grid column and shifting the indices to its right.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*너비 분할은 셀 (1, 1)에 적용되며, 0 기반 (column, row) 인덱스를 사용합니다. 다른 행은 두 새로운 열 위치에 걸쳐 셀을 유지합니다.*
<!-- visual-explanation:manage-cells:end -->

### **행 또는 열 범위에 따라 병합 셀 분할**

병합된 템플릿 셀을 데이터로 채우기 위해서는 [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) 로 기존 행 경계에 따라 분할하거나, [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) 로 열 경계에 따라 분할합니다.

`index` 인자는 분할될 상단 부분의 행 또는 좌측 부분의 열을 의미하며, 병합 영역에 상대적입니다:

- 행 분할: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- 열 분할: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

예제는 첫 번째 슬라이드 첫 번째 도형이 테이블이며, `(1, 2)`와 `(1, 3)`이 수직으로 병합돼 있다고 가정합니다. 하단 위치에서 시작해 [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) 와 [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) 로 원점을 찾고 두 스팬을 확인합니다. `splitByRowSpan(1)` 은 제품 이름을 위한 행 2와 3을 분리합니다. 가로 두 열 병합인 경우 대신 `splitByColSpan(1)` 을 사용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # 분할 후 테이블에서 결과 셀을 가져옵니다.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

테이블 그리드와 주변 셀 인덱스는 변하지 않습니다. 결과 셀을 좌표로 조회하면 두 셀 모두 스팬이 1이며 [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) 은 `False` 를 반환합니다. 하나의 분할 후에도 큰 영역이 부분적으로 병합된 상태로 남을 수 있습니다.

원본 텍스트와 서식은 상위(또는 좌측) 셀에 그대로 남으며, 새 셀은 비어 있지만 채우기, 테두리, 여백 등 셀 서식을 상속합니다. 분할 후 셀에 내용을 채우고 필요한 텍스트 서식을 명시적으로 설정하세요.

저장된 프레젠테이션에는 템플릿 셀 서식이 유지된 채 “Product A”와 “Product B” 셀이 각각 별도로 존재합니다. 자세한 내용은 [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) 를 참조하세요.

### **특정 높이로 셀 분할**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) 은 상단 부분의 높이를 포인트 단위로 받습니다. [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) 은 상단 부분에 포함될 기존 그리드 행 수를 받습니다. 오른쪽 열에 40포인트 셀을 가운데 배치하려면 셀 실제 높이에서 40을 빼고 나머지를 위·아래에 동일하게 분배합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

첫 번째 분할은 그리드 행을 하나 추가하고 셀 `(1, 1)` 에 남은 90포인트를 유지합니다. 두 번째 분할은 해당 셀을 40포인트 중간 셀과 50포인트 하단 셀로 나눕니다. 이제 오른쪽 열에는 위에서 아래로 50, 40, 50 포인트 높이의 세 셀이 있습니다. 왼쪽 셀은 세 행을 모두 차지하며 원래 높이인 140포인트를 유지합니다.

![The left cell spans the full table height beside three cells with Middle in the center.](split-by-height.png)

## **테이블 셀 배경 색 변경**

이 예제는 150포인트 열과 50포인트 행을 가진 테이블을 생성합니다. [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) 으로 고체 채우기를 선택하고, [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) 로 반환되는 색상을 빨간색으로 설정해 셀 `(2, 3)` (세 번째 열, 네 번째 행)의 배경을 변경합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **테이블 셀 안에 이미지 추가**

예제를 실행하기 전에 입력 이미지를 작업 디렉터리에 배치하십시오. 이미지를 [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) 로 로드하고 [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) 로 프레젠테이션의 이미지 컬렉션에 추가합니다. 그런 다음 이미지를 셀 `(0, 0)` (테이블의 첫 번째 셀)의 그림 채우기로 할당합니다.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) 은 이미지를 셀 전체에 맞게 늘리며, 이 경우 비율이 변경될 수 있습니다. 열 너비와 행 높이는 포인트 단위입니다. 로드된 이미지는 프레젠테이션에 추가된 후 `finally` 블록에서 해제됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**하나의 셀에 대해 각 면마다 다른 선 두께와 스타일을 지정할 수 있나요?**

예. [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) 테두리는 각각 별도 속성을 가지고 있어 각 면의 두께와 스타일을 다르게 지정할 수 있습니다.

**셀 배경에 그림을 설정한 후 열/행 크기를 변경하면 이미지가 어떻게 되나요?**

동작은 [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile)에 따라 다릅니다. stretch인 경우 이미지가 새로운 셀 크기에 맞게 조정되고, tile인 경우 타일이 다시 계산됩니다.

**셀의 모든 콘텐츠에 하이퍼링크를 지정할 수 있나요?**

[Hyperlinks](/slides/ko/python-java/manage-hyperlinks/) 은 셀 텍스트 프레임 내부의 텍스트(구간) 수준이나 전체 테이블/도형 수준에서 설정됩니다. 실제로는 구간이나 셀 전체 텍스트에 링크를 지정합니다.

**하나의 셀 안에서 서로 다른 글꼴을 사용할 수 있나요?**

예. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (런) 별로 독립적인 서식을 지원하므로 글꼴 종류, 스타일, 크기 및 색상을 각각 지정할 수 있습니다.