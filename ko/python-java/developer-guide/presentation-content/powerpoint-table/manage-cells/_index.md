---
title: Python을 사용하여 프레젠테이션의 테이블 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/python-java/manage-cells/
keywords:
- 테이블 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 안의 이미지
- 배경 색상
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint에서 테이블 셀을 손쉽게 관리합니다. 셀에 빠르게 접근하고 수정하며 스타일링하여 슬라이드 자동화를 원활하게 수행하세요."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 테이블 셀에 액세스하고 수정할 수 있습니다. 이 문서는 병합된 테이블 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 후 셀 번호 매기기를 다루는 방법, 셀의 배경 색을 변경하는 방법, 그리고 테이블 셀 안에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 생성하거나 열고, 슬라이드에서 테이블을 가져오고, 셀 속성을 통해 셀 서식을 업데이트한 다음 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 보여줍니다.

## **병합된 테이블 셀 식별**

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에서 테이블을 가져옵니다.
3. 테이블의 행과 열을 반복하여 병합된 셀을 찾습니다.
4. 병합된 셀을 찾으면 메시지를 출력합니다.

이 Python 코드는 프레젠테이션에서 병합된 테이블 셀을 식별하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # 첫 번째 슬라이드의 첫 번째 도형이 테이블이라고 가정합니다.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **테이블 셀 테두리 제거**

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 열 너비 목록을 정의합니다.
4. 행 높이 목록을 정의합니다.
5. [addTable](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addTable) 메서드를 사용하여 슬라이드에 테이블을 추가합니다.
6. 모든 셀을 반복하여 위, 아래, 오른쪽 및 왼쪽 테두리를 제거합니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

이 Python 코드는 테이블 셀의 테두리를 제거하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.getSlides().get_Item(0)

    # 열 너비와 행 높이를 정의합니다.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 슬라이드에 테이블을 추가합니다.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 각 셀에 대한 테두리 형식을 설정합니다.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **병합된 셀의 번호 매기기**

두 쌍의 셀, (1, 1)과 (2, 1), 그리고 (1, 2)와 (2, 2)를 병합하면 결과 테이블은 셀 번호를 유지합니다. 이 Python 코드는 해당 과정을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.getSlides().get_Item(0)

    # 열 너비와 행 높이를 정의합니다.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 슬라이드에 테이블을 추가합니다.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 각 셀에 대한 테두리 형식을 설정합니다.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # (1, 1)과 (2, 1) 셀을 병합합니다.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # (1, 2)과 (2, 2) 셀을 병합합니다.
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

그런 다음 (1, 1)과 (1, 2)를 병합하여 셀을 추가로 병합합니다. 결과는 중앙에 큰 병합 셀을 가진 테이블이 됩니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.getSlides().get_Item(0)

    # 열 너비와 행 높이를 정의합니다.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 슬라이드에 테이블을 추가합니다.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 각 셀에 대한 테두리 형식을 설정합니다.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # (1, 1)과 (2, 1) 셀을 병합합니다.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # (1, 2)와 (2, 2) 셀을 병합합니다.
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # (1, 1)과 (1, 2) 셀을 병합합니다.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **분할 셀의 번호 매기기**

이전 예제에서는 테이블 셀을 병합해도 다른 셀의 번호 매기기가 변경되지 않았습니다.

이번에는 병합된 셀이 없는 일반 테이블을 사용한 다음 셀 (1, 1)을 분할하여 특수한 테이블을 만들어 봅니다. 이 테이블의 번호 매기기가 이상하게 보일 수 있으니 주의하십시오. 그러나 이것이 Microsoft PowerPoint가 테이블 셀에 번호를 매기는 방식이며 Aspose.Slides도 동일하게 동작합니다.

이 Python 코드는 설명한 과정을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.getSlides().get_Item(0)

    # 열 너비와 행 높이를 정의합니다.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 슬라이드에 테이블을 추가합니다.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 각 셀에 대한 테두리 형식을 설정합니다.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # 셀 (1, 1)을 분할합니다.
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **테이블 셀 배경 색 변경**

이 Python 코드는 테이블 셀의 배경 색을 변경하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.getSlides().get_Item(0)

    # 열 너비와 행 높이를 정의합니다.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # 슬라이드에 테이블을 추가합니다.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # 셀의 배경 색을 설정합니다.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **테이블 셀 내부에 이미지 추가**

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 열 너비 목록을 정의합니다.
4. 행 높이 목록을 정의합니다.
5. [addTable](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addTable) 메서드를 사용하여 슬라이드에 테이블을 추가합니다.
6. [Images.fromFile](https://reference.aspose.com/slides/ko/python-java/aspose.slides/images/#fromFile)을 사용하여 이미지 파일을 로드합니다.
7. 이미지를 프레젠테이션에 추가하여 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/) 객체를 생성합니다.
8. 테이블 셀의 [FillFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fillformat/) 채우기 유형을 [FillType.Picture](https://reference.aspose.com/slides/ko/python-java/aspose.slides/filltype/#Picture)으로 설정합니다.
9. 이미지를 테이블의 첫 번째 셀에 추가합니다.
10. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

이 Python 코드는 테이블을 만들 때 테이블 셀 내부에 이미지를 배치하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.getSlides().get_Item(0)

    # 열 너비와 행 높이를 정의합니다.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # 슬라이드에 테이블을 추가합니다.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # 이미지 파일에서 프레젠테이션 이미지를 생성합니다.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # 이미지를 첫 번째 테이블 셀에 추가합니다.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**단일 셀의 서로 다른 면에 대해 다른 선 두께와 스타일을 지정할 수 있나요?**

예. [top](https://reference.aspose.com/slides/ko/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/ko/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/ko/python-java/aspose.slides/cellformat/#getBorderRight) 테두리는 각각 별도의 속성을 가지고 있어 각 면의 두께와 스타일을 다르게 지정할 수 있습니다. 이는 문서에서 설명한 셀에 대한 면별 테두리 제어와 논리적으로 일치합니다.

**셀 배경으로 그림을 설정한 후 열/행 크기를 변경하면 이미지가 어떻게 되나요?**

동작은 [fill mode](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillmode/) (stretch/​tile)에 따라 달라집니다. Stretch인 경우 이미지가 새로운 셀 크기에 맞게 조정되고, Tile인 경우 타일이 다시 계산됩니다. 문서에서는 셀 내 이미지 표시 모드에 대해 언급하고 있습니다.

**셀의 모든 내용에 하이퍼링크를 지정할 수 있나요?**

[Hyperlinks](/slides/ko/python-java/manage-hyperlinks/)는 셀의 텍스트 프레임(부분) 수준이나 전체 테이블/쉐이프 수준에서 설정됩니다. 실제로는 해당 부분이나 셀 전체 텍스트에 링크를 지정합니다.

**단일 셀 내에서 서로 다른 글꼴을 설정할 수 있나요?**

예. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/)(런)별로 독립적인 서식(글꼴 가족, 스타일, 크기, 색상)을 지원합니다.