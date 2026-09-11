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
- 가로세로 비율
- 텍스트 정렬
- 텍스트 서식
- 표 스타일
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Java를 통해 Python용 Aspose.Slides로 PowerPoint 슬라이드의 표를 만들고 편집합니다. 표 작업 흐름을 간소화할 간단한 코드 예제를 찾아보세요."
---
## **소개**

PowerPoint에서 표는 정보를 효율적으로 표시하는 방법입니다. 행과 열로 구성된 셀 그리드에 있는 정보는 직관적이고 이해하기 쉽습니다.

Aspose.Slides는 [Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/) 클래스, [Cell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/cell/) 클래스 및 기타 타입을 제공하여 프레젠테이션의 표를 생성, 수정 및 관리할 수 있도록 합니다.

## **표를 처음부터 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.  
3. 열 너비 목록을 정의합니다.  
4. 행 높이 목록을 정의합니다.  
5. [addTable](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addTable) 메서드를 통해 슬라이드에 [Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/) 개체를 추가합니다.  
6. 각 [Cell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/cell/)을 순회하면서 상/하/좌/우 테두리 서식을 적용합니다.  
7. 표 첫 번째 행의 처음 두 셀을 병합합니다.  
8. [Cell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/cell/)의 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)에 접근합니다.  
9. [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)에 텍스트를 추가합니다.  
10. 수정된 프레젠테이션을 저장합니다.

다음 Python 코드는 프레젠테이션에 표를 만드는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
presentation = Presentation()
try:

    # 첫 번째 슬라이드에 접근합니다
    slide = presentation.getSlides().get_Item(0)

    # 열 너비와 행 높이를 정의합니다
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 슬라이드에 표 모양을 추가합니다
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 각 셀에 대한 테두리 서식을 설정합니다
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

    # 1행의 셀 1과 2를 병합합니다
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # 병합된 셀에 텍스트를 추가합니다
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # 프레젠테이션을 디스크에 저장합니다
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **표의 표준 번호 매기기**

표의 셀 번호는 직관적이며 0부터 시작합니다. 표의 첫 번째 셀은 (0,0) (열 0, 행 0)으로 인덱싱됩니다.

예를 들어, 4열 4행 표의 셀 번호는 다음과 같습니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

다음 Python 코드는 표준 셀 번호 매기기를 사용해 표를 만드는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
presentation = Presentation()
try:

    # 첫 번째 슬라이드에 접근합니다
    slide = presentation.getSlides().get_Item(0)

    # 열 너비와 행 높이를 정의합니다
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 슬라이드에 표 모양을 추가합니다
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 각 셀에 대한 테두리 서식을 설정합니다
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

    # 프레젠테이션을 디스크에 저장합니다
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **기존 표 접근하기**

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 표가 포함된 슬라이드에 대한 참조를 가져옵니다.  
3. [Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/) 개체에 대한 변수를 초기화하고 `None`으로 설정합니다.  
4. 표가 발견될 때까지 모든 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/) 개체를 순회합니다.  

   슬라이드에 단일 표만 포함되어 있다고 판단되면 포함된 모든 도형을 확인하면 됩니다. 도형이 표로 식별되면 이를 [Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/) 개체로 사용할 수 있습니다. 슬라이드에 여러 표가 있는 경우에는 [getAlternativeText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getAlternativeText) 속성을 통해 필요한 표를 찾는 것이 좋습니다.  

5. [Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/) 개체를 사용하여 표를 조작합니다. 아래 예시에서는 두 번째 행 첫 번째 열의 텍스트를 업데이트합니다.  
6. 수정된 프레젠테이션을 저장합니다.

다음 Python 코드는 기존 표에 접근하고 작업하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # 첫 번째 슬라이드에 접근합니다
    slide = presentation.getSlides().get_Item(0)

    # 표 참조를 초기화합니다.
    table = None

    # 도형들을 순회하면서 찾은 표에 대한 참조를 설정합니다
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # 두 번째 행 첫 번째 열의 텍스트를 설정합니다
            table.get_Item(0, 1).getTextFrame().setText("New")

    # 수정된 프레젠테이션을 디스크에 저장합니다
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **텍스트 프레임을 소유한 셀 찾기**

표에서 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)을 받는 일반 텍스트 처리 코드는 [TextFrame.getParentCell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/#getParentCell) 메서드를 사용해 해당 [Cell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/cell/)을 가져와야 합니다. 표 셀 텍스트 프레임에 대해 [TextFrame.getParentCell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/#getParentCell) 은 소유자를 반환하고, [TextFrame.getParentShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/#getParentShape) 은 `None`을 반환합니다(표 자체도 도형이지만).

셀 좌표는 읽기 전용 [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/ko/python-java/aspose.slides/cell/#getFirstColumnIndex) 및 [Cell.getFirstRowIndex](https://reference.aspose.com/slides/ko/python-java/aspose.slides/cell/#getFirstRowIndex) 메서드를 통해 확인할 수 있습니다. [TextFrame.getParentCell](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/#getParentCell) 역시 읽기 전용 탐색을 제공하며, 반환된 셀에 대해 `None`인지 확인한 후 사용해야 합니다.

표 셀과 도형 소유자를 식별하고 SmartArt 노드와 연결된 도형까지 포함한 전체 예시는 [Search and Replace Text](/slides/ko/python-java/search-and-replace-text/) 를 참고하십시오.

## **표 안의 텍스트 정렬**

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.  
3. 슬라이드에 [Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/) 개체를 추가합니다.  
4. 표에서 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/) 개체에 접근합니다.  
5. [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/) 개체의 [Paragraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraph/)에 접근합니다.  
6. 텍스트를 수직으로 정렬합니다.  
7. 수정된 프레젠테이션을 저장합니다.

다음 Python 코드는 표 안의 텍스트를 정렬하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Presentation 클래스의 인스턴스를 생성합니다
presentation = Presentation()
try:

    # 첫 번째 슬라이드를 가져옵니다
    slide = presentation.getSlides().get_Item(0)

    # 열 너비와 행 높이를 정의합니다
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # 슬라이드에 표 모양을 추가합니다
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # 텍스트 프레임에 접근합니다
    text_frame = table.get_Item(0, 0).getTextFrame()

    # 텍스트 프레임의 첫 번째 단락에 접근합니다.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # 단락의 첫 번째 부분에 접근합니다.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # 텍스트를 수직으로 정렬합니다
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # 프레젠테이션을 디스크에 저장합니다
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **표 수준에서 텍스트 서식 지정하기**

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.  
3. 슬라이드에서 [Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/) 개체에 접근합니다.  
4. [setFontHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setFontHeight) 로 텍스트의 폰트 높이를 설정합니다.  
5. [setAlignment](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraphformat/#setAlignment) 과 [setMarginRight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraphformat/#setMarginRight) 로 정렬 및 오른쪽 여백을 설정합니다.  
6. [setTextVerticalType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setTextVerticalType) 으로 수직 텍스트 유형을 설정합니다.  
7. 수정된 프레젠테이션을 저장합니다.

다음 Python 코드는 표 안의 텍스트에 선호하는 서식 옵션을 적용하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Presentation 클래스의 인스턴스를 생성합니다
presentation = Presentation("simpletable.pptx")
try:

    # 첫 번째 슬라이드의 첫 번째 도형이 표라고 가정합니다
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # 표 셀의 글꼴 높이를 설정합니다
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # 표 셀의 텍스트 정렬과 오른쪽 여백을 한 번에 설정합니다
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # 표 셀의 텍스트 수직 방향을 설정합니다
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **표 스타일 속성 가져오기**

Aspose.Slides를 사용하면 표의 스타일 속성을 가져와 다른 표나 다른 위치에 재사용할 수 있습니다. 다음 Python 코드는 사전 정의된 표 스타일에서 스타일 속성을 가져오는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # 기본 스타일 프리셋 테마를 변경합니다

    # 표의 스타일 프리셋을 가져옵니다
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # 가져온 스타일 프리셋을 다른 표에 적용합니다
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **표의 가로·세로 비율 잠금**

기하학적 도형의 가로·세로 비율은 각 차원의 크기 비율을 의미합니다. Aspose.Slides는 [setAspectRatioLocked](https://reference.aspose.com/slides/ko/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) 메서드를 제공하여 표 및 기타 도형의 비율 잠금 설정을 할 수 있게 합니다.

다음 Python 코드는 표의 가로·세로 비율을 잠그는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # 반전
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**전체 표와 셀 내 텍스트에 대해 오른쪽에서 왼쪽(RTL) 읽기 방향을 활성화할 수 있나요?**

예. 표는 [setRightToLeft](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/#setRightToLeft) 메서드를 제공하고, 단락은 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraphformat/#setRightToLeft) 를 가지고 있습니다. 두 메서드를 함께 사용하면 셀 내부의 올바른 RTL 순서와 렌더링을 보장합니다.

**최종 파일에서 사용자가 표를 이동하거나 크기를 조정하지 못하도록 방지할 수 있나요?**

[shape locks](/slides/ko/python-java/applying-protection-to-presentation/) 를 사용하여 이동, 크기 조정, 선택 등을 비활성화하십시오. 이러한 잠금은 표에도 적용됩니다.

**셀 안에 이미지를 배경으로 삽입하는 것이 지원되나요?**

예. 셀에 [picture fill](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillformat/) 을 설정하면 이미지가 선택한 모드(스트레치 또는 타일)에 따라 셀 영역을 채웁니다.