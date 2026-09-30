---
title: Python에서 프레젠테이션 표 관리
linktitle: 표 관리
type: docs
weight: 10
url: /ko/python-java/manage-table/
keywords:
- 표 추가
- 표 만들기
- 표 접근
- 종횡비
- 텍스트 정렬
- 텍스트 서식
- 표 스타일
- PowerPoint
- Python
- Aspose.Slides
description: "Python용 Aspose.Slides를 사용하여 Java를 통해 PowerPoint 슬라이드에서 표를 만들고 편집하십시오. 표 작업 흐름을 간소화하는 간단한 코드 예제를 확인하세요."
---
## **소개**

PowerPoint의 표는 정보를 행과 열로 정리하여 값을 읽고 비교하기 쉽게 합니다.

Aspose.Slides는 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 및 [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) 클래스와 기타 유형을 제공하여 프레젠테이션에서 표를 만들고, 업데이트하고, 관리할 수 있도록 합니다.

## **새 표 만들기**

표의 위치, 열 너비, 행 높이를 지정하여 표를 생성합니다. 슬라이드에 추가한 후 셀 테두리를 서식 지정하고, 셀을 병합하며, 텍스트를 삽입할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 포인트 단위의 열 너비 리스트를 정의합니다.
4. 포인트 단위의 행 높이 리스트를 정의합니다.
5. 슬라이드에 [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) 메서드를 사용하여 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 객체를 추가합니다.
6. 각 [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/)을 반복하면서 위, 아래, 오른쪽, 왼쪽 테두리 서식을 적용합니다.
7. 표 첫 번째 행의 처음 두 셀을 병합합니다.
8. 병합된 셀을 [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) 메서드로 접근합니다.
9. 병합된 셀에 텍스트를 설정합니다.
10. 수정된 프레젠테이션을 저장합니다.

아래 예제는 (100, 50) 포인트 위치에 열 3개, 행 5개의 표를 만들고, 너비 5포인트의 빨간색 테두리를 적용하며, 첫 번째 행의 처음 두 셀을 병합하고, 결과를 `table.pptx` 로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **표 표준 번호 매기기**

표준 표에서는 셀 인덱스가 0부터 시작하며 순서는 (열, 행)입니다. 첫 번째 셀은 (0, 0)으로 인덱싱됩니다.

예를 들어, 열 4개와 행 4개로 구성된 표의 셀은 다음과 같이 번호가 매겨집니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

이 예제는 위에 표시된 4×4 표를 만들며, 열 너비와 행 높이를 70포인트로 설정하고, 너비 5포인트의 빨간색 셀 테두리를 적용합니다. 좌표는 셀 인덱스를 나타냅니다; 예제는 셀을 비워 두고 표를 `StandardTables_out.pptx` 로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **기존 표에 접근하기**

표는 슬라이드의 도형 컬렉션에 저장됩니다. 도형을 반복해서 표를 찾은 다음, [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 클래스를 사용하여 셀을 읽거나 업데이트합니다.

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 클래스를 사용하여 프레젠테이션을 로드합니다.
2. 인덱스로 표가 포함된 슬라이드에 대한 참조를 가져옵니다.
3. [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 객체를 반복하여 표가 발견될 때까지 진행합니다. 슬라이드에 여러 표가 있는 경우, [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText)를 사용해 필요한 표를 식별합니다.
4. 대상 셀의 텍스트를 업데이트합니다.
5. 수정된 프레젠테이션을 저장합니다.

아래 예제는 `UpdateExistingTable.pptx` 를 열어 첫 번째 슬라이드의 첫 번째 표를 찾습니다. 열 0, 행 1 위치의 셀을 `New` 로 설정하고 결과를 `table1_out.pptx` 로 저장합니다. 입력 파일에는 최소한 하나의 슬라이드가 있어야 하며, 해당 슬라이드의 첫 번째 표는 최소 하나의 열과 두 개의 행을 가져야 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

기존 표에서 행의 크기를 조정하고, 실제 높이가 요청된 최소값을 초과할 수 있는 이유를 확인하려면 [Control Row Height](/slides/ko/python-java/manage-rows-and-columns/#control-row-height)를 참조하세요.

## **텍스트 프레임을 소유한 셀 찾기**

표에서 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)을 받는 일반 텍스트 처리 코드에서는 [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) 메서드를 사용해 해당 [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/)을 가져옵니다. 표 셀의 텍스트 프레임에서는 [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell)이 소유자를 반환하고, [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape)은 `None`을 반환합니다(표 자체도 도형이지만).

셀 좌표는 읽기 전용 [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) 및 [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) 메서드를 통해 확인할 수 있습니다. [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell)도 읽기 전용 내비게이션을 제공하며, 소유자를 반환하지만 소유권을 변경하지 않습니다. 사용하기 전에 반환된 셀이 `None`인지 항상 확인하십시오.

표 셀 및 도형 소유자(스마트아트 노드와 연결된 도형 포함)를 식별하는 전체 예제는 [Search and Replace Text](/slides/ko/python-java/search-and-replace-text/)를 참조하세요.

## **표에서 텍스트 정렬**

개별 표 셀의 수직 고정 및 텍스트 방향을 제어할 수 있습니다. 이 섹션의 예제는 첫 번째 셀의 텍스트를 가운데 정렬하고 270도 회전시킵니다.

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 객체를 추가합니다.
4. 표에서 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) 객체에 접근합니다.
5. 첫 번째 [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/)에 접근하여 텍스트와 색상을 설정합니다.
6. [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) 및 [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType)을 사용하여 셀의 수직 고정 및 텍스트 방향을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

이 예제는 열 너비 120포인트, 행 높이 100포인트인 4×4 표를 만들고, 셀 (0, 0)의 텍스트를 서식 지정하며, 첫 번째 행의 나머지 셀에 값을 추가하고, 결과를 `Vertical_Align_Text_out.pptx` 로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **표 수준에서 텍스트 서식 지정**

[setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat)을 사용하면 표의 모든 셀에 텍스트 서식을 적용할 수 있습니다. 이 메서드의 오버로드는 구간, 단락, 텍스트 프레임 서식을 받아 개별 셀을 반복하지 않고도 해당 속성을 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 클래스를 사용하여 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에서 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) 객체에 접근합니다.
4. 텍스트에 대해 [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight)를 사용해 글꼴 크기를 설정합니다.
5. [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment)와 [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight)를 사용해 단락 정렬 및 오른쪽 여백을 설정합니다.
6. [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType)을 사용해 텍스트 방향을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

아래 예제는 최소 하나의 슬라이드에 첫 번째 도형으로 표가 포함된 `table.pptx` 를 엽니다. 글꼴 크기를 25포인트로 설정하고, 단락을 오른쪽 정렬하며 오른쪽 여백을 20포인트로 지정하고, 텍스트를 수직으로 설정합니다. 형식이 적용된 프레젠테이션은 `result.pptx` 로 저장됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **표 스타일 속성 가져오기**

[getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset)을 사용해 표의 사전 정의된 스타일을 읽고, [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset)으로 지정할 수 있습니다. 이 예제는 한 표에 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/)을 적용하고, 프리셋 값을 출력한 뒤 같은 프리셋을 두 번째 표에 할당합니다. 두 표는 `table-style.pptx` 로 저장됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **표의 종횡비 잠금**

표의 종횡비는 너비와 높이의 비율을 의미합니다. [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked)을 사용해 표의 종횡비를 잠글 수 있습니다.

아래 예제는 최소 하나의 슬라이드에 첫 번째 도형으로 표가 포함된 `pres.pptx` 를 엽니다. 현재 잠금 상태를 출력하고, 종횡비 잠금을 활성화한 뒤 업데이트된 상태(`True`)를 출력하고, 결과를 `pres-out.pptx` 로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**전체 표와 셀 안의 텍스트에 대해 오른쪽에서 왼쪽(RTL) 읽기 방향을 활성화할 수 있나요?**

예. 표는 [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft) 메서드를 제공하고, 단락에는 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft)가 있습니다. 두 가지를 모두 사용하면 셀 내부에서 올바른 RTL 순서와 렌더링을 보장합니다.

**최종 파일에서 사용자가 표를 이동하거나 크기를 조정하지 못하도록 하려면 어떻게 해야 하나요?**

[shape locks](/slides/ko/python-java/applying-protection-to-presentation/)를 사용해 이동, 크기 조정, 선택 등을 비활성화합니다. 이러한 잠금은 표에도 적용됩니다.

**셀 안에 이미지를 배경으로 삽입하는 것이 지원되나요?**

예. 셀에 [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/)을 설정할 수 있으며, 선택한 모드(늘리기 또는 타일)대로 이미지가 셀 영역을 덮습니다.