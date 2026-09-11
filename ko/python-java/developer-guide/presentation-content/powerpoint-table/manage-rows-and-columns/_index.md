---
title: Python을 사용하여 PowerPoint 표의 행과 열 관리
linktitle: 행 및 열
type: docs
weight: 20
url: /ko/python-java/manage-rows-and-columns/
keywords:
- 표 행
- 표 열
- 첫 번째 행
- 표 헤더
- 행 복제
- 열 복제
- 행 복사
- 열 복사
- 행 제거
- 열 제거
- 행 텍스트 서식
- 열 텍스트 서식
- 표 스타일
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint에서 표의 행과 열을 관리하고 프레젠테이션 편집 및 데이터 업데이트를 빠르게 수행합니다."
---
## **소개**

PowerPoint 프레젠테이션에서 표의 행과 열을 관리할 수 있도록 Aspose.Slides는 [Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/) 클래스와 기타 다양한 유형을 제공합니다.

## **첫 번째 행을 헤더로 설정**

1. Presentation 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. [Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/) 참조를 생성하고 `None` 으로 설정합니다.
4. 관련 표를 찾기 위해 모든 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/) 객체를 반복합니다.
5. 표의 첫 번째 행을 헤더로 설정합니다.

이 Python 코드는 표의 첫 번째 행을 헤더로 설정하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **표 행 또는 열 복제**

1. Presentation 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 열 너비 목록을 정의합니다.
4. 행 높이 목록을 정의합니다.
5. [addTable](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addTable) 메서드를 통해 슬라이드에 [Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/) 객체를 추가합니다.
6. 표 행을 복제합니다.
7. 표 열을 복제합니다.
8. 수정된 프레젠테이션을 저장합니다.

이 Python 코드는 PowerPoint 표의 행 또는 열을 복제하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **표에서 행 또는 열 제거**

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 열 너비 목록을 정의합니다.
4. 행 높이 목록을 정의합니다.
5. [addTable](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addTable) 메서드를 통해 슬라이드에 [Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/) 객체를 추가합니다.
6. 표 행을 제거합니다.
7. 표 열을 제거합니다.
8. 수정된 프레젠테이션을 저장합니다.

이 Python 코드는 표에서 행 또는 열을 제거하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **표 행 수준에서 텍스트 서식 설정**

1. Presentation 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에서 관련 [Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/) 객체에 접근합니다.
4. [setFontHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setFontHeight)를 사용하여 첫 번째 행 셀의 글꼴 높이를 설정합니다.
5. [setAlignment](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraphformat/#setAlignment)와 [setMarginRight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraphformat/#setMarginRight)를 사용하여 첫 번째 행 셀의 텍스트 정렬과 오른쪽 여백을 설정합니다.
6. [setTextVerticalType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setTextVerticalType)를 사용하여 두 번째 행 셀의 수직 텍스트 유형을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

이 Python 코드는 해당 작업을 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **표 열 수준에서 텍스트 서식 설정**

1. Presentation 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에서 관련 [Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/table/) 객체에 접근합니다.
4. [setFontHeight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseportionformat/#setFontHeight)를 사용하여 첫 번째 열 셀의 글꼴 높이를 설정합니다.
5. [setAlignment](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraphformat/#setAlignment)와 [setMarginRight](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraphformat/#setMarginRight)를 사용하여 첫 번째 열 셀의 텍스트 정렬과 오른쪽 여백을 설정합니다.
6. [setTextVerticalType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setTextVerticalType)를 사용하여 두 번째 열 셀의 수직 텍스트 유형을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

이 Python 코드는 해당 작업을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **표 스타일 속성 가져오기**

Aspose.Slides를 사용하면 표에 대한 스타일 속성을 가져와서 다른 표나 다른 곳에 사용할 수 있습니다. 이 Python 코드는 표 사전 정의 스타일에서 스타일 속성을 가져오는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**이미 만든 표에 PowerPoint 테마/스타일을 적용할 수 있나요?**

예. 표는 슬라이드/레이아웃/마스터 테마를 상속받으며, 해당 테마 위에 채우기, 경계선 및 텍스트 색상을 여전히 재정의할 수 있습니다.

**Excel처럼 표 행을 정렬할 수 있나요?**

아니요, Aspose.Slides 표에는 내장된 정렬이나 필터 기능이 없습니다. 먼저 메모리에서 데이터를 정렬한 다음, 해당 순서대로 표 행을 다시 채워야 합니다.

**특정 셀에 사용자 정의 색상을 유지하면서 밴드(스트라이프) 열을 적용할 수 있나요?**

예. 밴드 열을 활성화한 뒤, 특정 셀에 로컬 서식을 적용하면 됩니다. 셀 수준 서식이 표 스타일보다 우선합니다.