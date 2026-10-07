---
title: Python을 사용하여 프레젠테이션에서 테이블 셀 관리
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
- 배경 색상
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python용 Aspose.Slides for Java를 사용하여 PowerPoint 테이블 셀을 관리합니다: 병합된 셀 식별, 테두리 제거, 셀 분할, 배경 색상 및 이미지 설정."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 테이블 셀에 액세스하고 수정할 수 있습니다. 이 문서에서는 병합된 테이블 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 후 셀 번호를 처리하는 방법, 셀 배경색을 변경하는 방법 및 테이블 셀 내부에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 생성하거나 열고, 슬라이드에서 테이블을 가져오며, 셀 속성을 통해 셀 서식을 업데이트하고, 수정된 프레젠테이션을 PPTX 파일로 저장하는 방법을 보여줍니다.

Aspose.Slides는 테이블 셀에 접근할 때 `(column, row)` 순서의 0부터 시작하는 인덱스를 사용합니다.

## **병합된 테이블 셀 식별**

예제는 기존 프레젠테이션을 열고 첫 번째 슬라이드의 첫 번째 도형을 테이블로 액세스합니다. 슬라이드와 도형이 존재하며 해당 도형이 테이블이라고 가정합니다. 그런 다음 모든 행과 열을 반복하면서 [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell)으로 병합된 영역의 셀을 식별합니다. 일치하는 각 셀에 대해 `row;column` 순서로 셀 좌표와 [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan), 그리고 영역 시작 좌표인 [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex)와 [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex)를 출력합니다.

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

[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)을 생성하고 [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable)으로 첫 번째 슬라이드에 테이블을 추가합니다. 열 너비, 행 높이 및 테이블 위치는 포인트 단위로 지정됩니다. 예제에서는 모든 네 개의 셀 테두리를 [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/)으로 설정하여 보이지 않게 합니다.

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

## **테이블 셀 병합**

[mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells)를 사용하여 직사각형 범위의 테이블 셀을 하나의 셀로 결합합니다. 범위의 좌측 상단과 우측 하단 셀을 지정합니다. 마지막 인자는 지정된 범위 밖의 셀을 포함할지 여부를 제어하며, `False`이면 병합이 해당 범위 내에 제한됩니다.

예제에서는 70포인트 열과 행을 가진 4×4 테이블을 만든 뒤, `(1, 1)`부터 `(2, 2)`까지 네 개의 중앙 셀을 병합합니다. 결과 셀은 두 열과 두 행을 차지하지만 테이블의 기본 그리드는 여전히 네 열과 네 행을 유지합니다. 병합된 셀의 내용이나 서식에 접근하려면 이 예제에서는 `table.get_Item(1, 1)`와 같이 좌측 상단 위치를 사용합니다. 병합 범위에 포함되지 않은 다른 셀들의 인덱스는 변하지 않습니다.

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

이전 예제에서 셀을 병합해도 테이블 그리드는 유지됩니다. 셀을 분할하면 새 열이 추가될 수 있으며 오른쪽에 있는 셀들의 열 인덱스가 변경됩니다. Aspose.Slides는 PowerPoint의 테이블 그리드 모델을 따릅니다.

예제에서는 70포인트 열과 행을 가진 4×4 테이블을 만든 뒤, 셀 `(1, 1)`에 대해 [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth)를 호출합니다. 셀의 70포인트 너비 절반을 전달하여 두 개의 동일 너비 셀을 생성합니다.

분할 후 두 절반은 `table.get_Item(1, 1)`와 `table.get_Item(2, 1)`으로 접근합니다. 테이블 그리드는 이제 다섯 열을 갖게 되며, 원래 2열과 3열에 있던 셀은 각각 3열과 4열로 이동합니다. 행 인덱스는 변하지 않으며, 분할 후 셀에 접근할 때는 업데이트된 열 인덱스를 사용해야 합니다.

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

### **병합된 셀을 행 또는 열 범위로 분할**

데이터 채우기를 위해 병합된 템플릿 셀을 준비하려면 [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan)으로 기존 행 경계 따라 분할하거나, [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan)으로 열 경계 따라 분할합니다.

`index` 인자는 분할된 상단 부분의 행 또는 좌측 부분의 열 수를 나타내며, 병합 영역을 기준으로 합니다.

- 행 분할: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- 열 분할: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

예제에서는 프레젠테이션의 첫 번째 슬라이드 첫 번째 도형이 테이블이며, `(1, 2)`와 `(1, 3)`이 수직으로 병합되어 있다고 가정합니다. 아래쪽 위치에서 시작하여 [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex)와 [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex)를 사용해 원점을 찾고 두 스팬을 확인합니다. `splitByRowSpan(1)`은 제품 이름을 위한 2행과 3행을 분리합니다. 가로 두 열 병합의 경우 대신 `splitByColSpan(1)`을 사용합니다.

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

테이블 그리드와 주변 셀 인덱스는 그대로 유지됩니다. 여기서는 두 셀 모두 스팬이 1이며 [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) 결과가 `False`인 것을 좌표로 검색합니다. 큰 영역은 하나의 분할 후에도 부분적으로 병합된 상태를 유지할 수 있습니다.

원본 텍스트와 서식은 상위(또는 좌측) 셀에 남고, 새 셀은 비어 있지만 채우기, 테두리, 여백 등 셀 서식을 상속합니다. 분할 후 셀에 내용을 채우고 필요한 텍스트 서식을 명시적으로 설정합니다.

저장된 프레젠테이션에는 템플릿의 셀 서식이 유지된 채 “Product A”와 “Product B” 셀이 별도로 존재합니다. 자세한 내용은 [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/)를 참조하십시오.

## **테이블 셀 배경색 변경**

예제에서는 150포인트 열과 50포인트 행을 가진 테이블을 만들고, [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType)으로 단색 채우기를 선택한 뒤, [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor)에서 반환된 색을 빨간색으로 설정하여 셀 `(2, 3)`(세 번째 열, 네 번째 행)의 배경색을 변경합니다.

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

## **테이블 셀 내부에 이미지 추가**

예제를 실행하기 전에 입력 이미지를 작업 디렉터리에 배치하십시오. 이미지 파일을 [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile)으로 로드하고, [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage)으로 프레젠테이션의 이미지 컬렉션에 추가합니다. 그런 다음 이미지를 셀 `(0, 0)`(테이블의 첫 번째 셀)의 그림 채우기로 할당합니다.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/)은 이미지를 셀 전체에 늘려 채우며, 이 경우 종횡비가 변경될 수 있습니다. 열 너비와 행 높이는 포인트 단위입니다. 로드된 이미지는 프레젠테이션에 추가된 후 `finally` 블록에서 해제됩니다.

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

**Can I set different line thicknesses and styles for different sides of a single cell?**

Yes. The [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) borders have separate properties, so the thickness and style of each side can differ.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

The behavior depends on the [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). With stretching, the image adjusts to the new cell; with tiling, the tiles are recalculated.

**Can I assign a hyperlink to all the content of a cell?**

[Hyperlinks](/slides/ko/python-java/manage-hyperlinks/) are set at the text (portion) level inside the cell’s text frame or at the level of the entire table/shape. In practice, you assign the link to a portion or to all the text in the cell.

**Can I set different fonts within a single cell?**

Yes. A cell’s text frame supports [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (runs) with independent formatting—font family, style, size, and color.