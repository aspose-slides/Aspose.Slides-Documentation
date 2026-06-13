---
title: Python을 사용한 PowerPoint 테이블의 행 및 열 관리
linktitle: 행 및 열
type: docs
weight: 20
url: /ko/python-net/manage-rows-and-columns/
keywords:
- 테이블 행
- 테이블 열
- 첫 번째 행
- 테이블 헤더
- 행 복제
- 열 복제
- 행 복사
- 열 복사
- 행 제거
- 열 제거
- 행 텍스트 서식
- 열 텍스트 서식
- 테이블 스타일
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python(.NET)을 사용하여 PowerPoint 및 OpenDocument에서 테이블 행과 열을 관리하고 프레젠테이션 편집 및 데이터 업데이트를 빠르게 수행합니다."
---
## **개요**

이 문서는 Aspose.Slides for Python을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 테이블 행과 열을 관리하는 방법을 보여 줍니다. 행이나 열을 추가, 삽입, 복제, 삭제하고 첫 번째 행을 헤더로 지정하며 크기와 레이아웃을 조정하고 행 또는 열 수준에서 텍스트와 스타일 서식을 적용하는 방법을 배웁니다. 각 작업은 [Table](https://reference.aspose.com/slides/ko/python-net/aspose.slides/table/) API를 기반으로 한 간결하고 독립적인 코드 조각으로 시연되므로 슬라이드에서 테이블을 빠르게 찾고 디자인에 맞게 구조를 재구성할 수 있습니다.

## **첫 번째 행을 헤더로 설정**

테이블의 첫 번째 행을 헤더로 지정하여 열 제목과 데이터를 명확히 구분합니다. Aspose.Slides for Python에서는 테이블의 *First Row* 옵션을 활성화하기만 하면 선택된 테이블 스타일에 정의된 헤더 서식이 적용됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 접근합니다.
3. 모든 [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/) 객체를 반복하여 관련 테이블을 찾습니다.
4. 테이블의 첫 번째 행을 헤더로 설정합니다.

```python
import aspose.slides as slides

# Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("table.pptx") as presentation:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 도형들을 반복하여 테이블에 대한 참조를 가져옵니다.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # 테이블의 첫 번째 행을 헤더로 설정합니다.
    table.first_row = True
    
    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **테이블 행 또는 열 복제**

테이블의 행이나 열을 복제하고 복사본을 원하는 위치에 삽입합니다. 복제본은 셀 내용, 서식 및 크기를 보존하므로 레이아웃을 빠르고 일관되게 확장할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 접근합니다.
3. 열 너비 배열을 정의합니다.
4. 행 높이 배열을 정의합니다.
5. `add_table(x, y, column_widths, row_heights)`를 사용하여 슬라이드에 [Table](https://reference.aspose.com/slides/ko/python-net/aspose.slides/table/)을 추가합니다.
6. 테이블 행을 복제합니다.
7. 테이블 열을 복제합니다.
8. 수정된 프레젠테이션을 저장합니다.

```python
 import aspose.slides as slides

# Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 열 너비와 행 높이를 정의합니다.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 슬라이드에 테이블을 추가합니다.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # 행 1, 열 1에 텍스트를 추가합니다.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # 행 2, 열 1에 텍스트를 추가합니다.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # 테이블 끝에 행 1을 복제합니다.
    table.rows.add_clone(table.rows[0], False)

    # 행 1, 열 2에 텍스트를 추가합니다.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # 행 2, 열 2에 텍스트를 추가합니다.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # 행 2를 테이블의 4번째 행으로 복제합니다.
    table.rows.insert_clone(3,table.rows[1], False)

    # 첫 번째 열을 끝에 복제합니다.
    table.columns.add_clone(table.columns[0], False)

    # 두 번째 열을 인덱스 3(네 번째 위치)에 복제합니다.
    table.columns.insert_clone(3,table.columns[1], False)
    
    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **테이블에서 행 또는 열 제거**

Aspose.Slides for Python을 사용하여 인덱스로 행이나 열을 제거하면 레이아웃이 자동으로 재조정되고 남은 셀의 서식은 유지됩니다. 데이터 그리드를 단순화하거나 자리 표시자를 삭제할 때 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 접근합니다.
3. 열 너비 배열을 정의합니다.
4. 행 높이 배열을 정의합니다.
5. `add_table(x, y, column_widths, row_heights)`를 사용하여 슬라이드에 ITable을 추가합니다.
6. 테이블 행을 제거합니다.
7. 테이블 열을 제거합니다.
8. 수정된 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]

    table = slide.shapes.add_table(100, 100, column_widths, row_heights)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **테이블 행 수준에서 텍스트 서식 지정**

한 번에 전체 테이블 행에 일관된 텍스트 스타일을 적용합니다. Aspose.Slides for Python을 사용하면 행에 포함된 모든 셀에 대해 글꼴 종류, 크기, 굵기, 색상 및 정렬을 한 번에 설정하여 머리글이나 데이터 밴드를 균일하게 유지할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 접근합니다.
3. 슬라이드에서 관련 [Table](https://reference.aspose.com/slides/ko/python-net/aspose.slides/table/) 객체에 접근합니다.
4. 첫 번째 행 셀의 글꼴 높이를 설정합니다.
5. 첫 번째 행 셀의 정렬과 오른쪽 여백을 설정합니다.
6. 두 번째 행 셀의 텍스트 수직 유형을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides

# Presentation 클래스의 인스턴스를 생성합니다.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # 첫 번째 행 셀의 글꼴 높이를 설정합니다.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # 첫 번째 행 셀의 텍스트 정렬 및 오른쪽 여백을 설정합니다.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # 두 번째 행 셀의 텍스트 수직 유형을 설정합니다.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **테이블 열 수준에서 텍스트 서식 지정**

전체 테이블 열에 일관된 텍스트 스타일을 한 번에 적용합니다. Aspose.Slides for Python을 사용하면 열에 포함된 모든 셀에 대해 글꼴 종류, 크기, 굵기, 색상 및 정렬을 설정하여 머리글이나 데이터에 균일한 수직 밴드를 만들 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 접근합니다.
3. 슬라이드에서 관련 [Table](https://reference.aspose.com/slides/ko/python-net/aspose.slides/table/) 객체에 접근합니다.
4. 첫 번째 열 셀의 글꼴 높이를 설정합니다.
5. 첫 번째 열 셀의 정렬과 오른쪽 여백을 설정합니다.
6. 두 번째 열 셀의 텍스트 수직 유형을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides

# Presentation 클래스의 인스턴스를 생성합니다.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # 첫 번째 열 셀의 글꼴 높이를 설정합니다.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # 첫 번째 열 셀의 텍스트 정렬 및 오른쪽 여백을 설정합니다.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # 두 번째 열 셀의 텍스트 수직 유형을 설정합니다.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **테이블 스타일 속성 가져오기**

Aspose.Slides를 사용하면 테이블의 스타일 속성을 가져와 다른 테이블이나 다른 위치에서 재사용할 수 있습니다. 다음 Python 코드는 미리 정의된 테이블 스타일에서 스타일 속성을 가져오는 방법을 보여 줍니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**이미 생성된 테이블에 PowerPoint 테마/스타일을 적용할 수 있나요?**

예. 테이블은 슬라이드/레이아웃/마스터 테마를 상속받으며, 해당 테마 위에 채우기, 테두리 및 텍스트 색상을 별도로 재정의할 수 있습니다.

**Excel처럼 테이블 행을 정렬할 수 있나요?**

아니오, Aspose.Slides 테이블에는 내장 정렬이나 필터 기능이 없습니다. 데이터를 메모리에서 먼저 정렬한 다음 그 순서대로 테이블 행을 다시 채워야 합니다.

**특정 셀에 사용자 지정 색상을 유지하면서 줄무늬(밴드) 열을 사용할 수 있나요?**

예. 밴드 열을 활성화한 후 특정 셀에 로컬 서식을 적용하면 해당 셀 서식이 테이블 스타일보다 우선합니다.