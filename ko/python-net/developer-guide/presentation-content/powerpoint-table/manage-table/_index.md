---
title: Python으로 프레젠테이션 표 관리
linktitle: 표 관리
type: docs
weight: 10
url: /ko/python-net/manage-table/
keywords:
- 표 추가
- 표 만들기
- 표 접근
- 종횡비
- 텍스트 정렬
- 텍스트 서식 지정
- 표 스타일
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 슬라이드의 표를 만들고 편집합니다. 표 작업 흐름을 간소화하는 간단한 코드 예제를 확인하십시오."
---
## **소개**

PowerPoint의 표는 정보를 효율적으로 제시하는 방법입니다. 셀(행과 열) 그리드에 배열된 정보는 직관적이며 이해하기 쉽습니다.

Aspose.Slides는 [Table](https://reference.aspose.com/slides/ko/python-net/aspose.slides/table/) 클래스, [Cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides/cell/) 클래스 및 기타 관련 유형을 제공하여 프레젠테이션에서 표를 만들고, 업데이트하고, 관리할 수 있도록 도와줍니다.

## **표를 처음부터 만들기**

이 섹션에서는 슬라이드에 표 셰이프를 추가하고 행과 열을 정의한 뒤 정확한 크기를 지정하여 Aspose.Slides에서 표를 처음부터 만드는 방법을 보여줍니다. 또한 셀에 텍스트를 채우고, 정렬 및 테두리를 조정하며, 표 모양을 사용자 정의하는 방법도 확인할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
3. 열 너비 배열을 정의합니다.
4. 행 높이 배열을 정의합니다.
5. 슬라이드에 [Table](https://reference.aspose.com/slides/ko/python-net/aspose.slides/table/)을 추가합니다.
6. 각 [Cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides/cell/)을 반복하면서 상, 하, 좌, 우 테두리를 지정합니다.
7. 첫 번째와 두 번째 행, 첫 번째와 두 번째 열의 셀을 하나의 셀로 병합합니다.
8. [Cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides/cell/)의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)에 접근합니다.
9. [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)에 텍스트를 추가합니다.
10. 수정된 프레젠테이션을 저장합니다.

다음 Python 예제는 프레젠테이션에 표를 만드는 방법을 보여 줍니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 열 너비와 행 높이를 정의합니다.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 슬라이드에 테이블 셰이프를 추가합니다.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # 각 셀의 테두리 형식을 설정합니다.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # (행 0, 열 0)부터 (행 1, 열 1)까지 셀을 병합합니다.
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # 병합된 셀에 텍스트를 추가합니다.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **표준 표의 번호 매기기**

표준 표에서 셀 번호 매기기는 간단하며 0부터 시작합니다. 표의 첫 번째 셀은 (0, 0) (열 0, 행 0)으로 인덱스됩니다.

예를 들어, 4열 4행 표에서 셀 번호는 다음과 같습니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

다음 Python 예제는 이 0 기반 번호 매기기를 사용하여 셀을 참조하는 방법을 보여 줍니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 4열 4행 표를 추가합니다.
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **기존 표에 접근하기**

이 섹션에서는 Aspose.Slides를 사용하여 프레젠테이션에 있는 기존 표를 찾고 작업하는 방법을 설명합니다. 슬라이드에서 표를 찾고, 행·열·셀에 접근하며, 내용이나 서식을 업데이트하는 방법을 배웁니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 표가 포함된 슬라이드에 대한 참조를 가져옵니다.
3. [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/) 객체를 모두 반복하여 표를 찾습니다.
4. [Table](https://reference.aspose.com/slides/ko/python-net/aspose.slides/table/) 객체를 사용하여 표를 작업합니다.
5. 수정된 프레젠테이션을 저장합니다.

{{% alert color="info" title="Note" %}}
슬라이드에 여러 개의 표가 포함된 경우 `alternative_text` 속성을 사용하여 필요한 표를 검색하는 것이 좋습니다.
{{% /alert %}}

다음 Python 예제는 기존 표에 접근하고 작업하는 방법을 보여 줍니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# PPTX 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("sample.pptx") as presentation:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    table = None

    # 셰이프를 반복하면서 처음 찾은 표를 참조합니다.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # 첫 번째 행 첫 번째 셀의 텍스트를 설정합니다.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # 수정된 프레젠테이션을 디스크에 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **텍스트 프레임을 소유하는 셀 찾기**

일반 텍스트 처리 코드가 표에서 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)을 받으면, 해당 프레임을 소유한 [Cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides/cell/)을 가져오기 위해 [TextFrame.parent_cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/parent_cell/) 속성을 사용합니다. 테이블 셀의 텍스트 프레임에서는 [TextFrame.parent_cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/parent_cell/)이 설정되고 [TextFrame.parent_shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/parent_shape/)은 `None`이며, 테이블 자체는 셰이프이지만 그렇습니다.

셀 좌표는 읽기 전용 [Cell.first_column_index](https://reference.aspose.com/slides/ko/python-net/aspose.slides/cell/first_column_index/) 및 [Cell.first_row_index](https://reference.aspose.com/slides/ko/python-net/aspose.slides/cell/first_row_index/) 속성을 통해 확인할 수 있습니다. [TextFrame.parent_cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/parent_cell/)도 읽기 전용이며, 소유자에 대한 탐색을 제공하지만 소유권을 변경하지 않습니다. 사용하기 전에 반환된 셀이 `None`인지 항상 확인하십시오.

테이블 셀 및 셰이프 소유자를 식별하는 완전한 예제(스마트아트 노드와 연결된 셰이프 포함)는 [Search and Replace Text](/slides/ko/python-net/search-and-replace-text/)를 참조하십시오.

## **표에서 텍스트 정렬**

이 섹션에서는 Aspose.Slides를 사용하여 표 셀 내부의 텍스트 배치를 제어하는 방법을 보여줍니다. 셀 안에서 텍스트를 수직으로 고정하고 텍스트의 진행 방향을 변경하는 방법을 배웁니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 [Table](https://reference.aspose.com/slides/ko/python-net/aspose.slides/table/) 객체를 추가합니다.
4. 표에서 [Cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides/cell/) 객체에 접근합니다.
5. 셀 내 텍스트를 수직 중앙에 맞추고 텍스트 방향을 설정합니다.
6. 수정된 프레젠테이션을 저장합니다.

다음 Python 예제는 표에서 텍스트를 정렬하는 방법을 보여 줍니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation 클래스의 인스턴스를 생성합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 열 너비와 행 높이를 정의합니다.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # 슬라이드에 표 셰이프를 추가합니다.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # 텍스트를 중앙에 맞추고 수직 방향을 설정합니다.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **표 수준에서 텍스트 서식 지정**

이 섹션에서는 Aspose.Slides에서 표 수준의 텍스트 서식을 적용하여 모든 셀이 일관된 스타일을 상속받도록 하는 방법을 보여줍니다. 글꼴 크기, 정렬 및 여백을 전역적으로 설정하는 방법을 배웁니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 [Table](https://reference.aspose.com/slides/ko/python-net/aspose.slides/table/)을 추가합니다.
4. 텍스트의 글꼴 크기(높이)를 설정합니다.
5. 단락 정렬과 여백을 설정합니다.
6. 수직 텍스트 방향을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

다음 Python 예제는 표의 텍스트에 선호하는 서식 옵션을 적용하는 방법을 보여 줍니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation 클래스의 인스턴스를 생성합니다
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # 모든 표 셀에 대한 글꼴 크기를 설정합니다.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # 모든 표 셀에 대해 오른쪽 정렬 텍스트와 오른쪽 여백을 설정합니다.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # 모든 표 셀에 대한 수직 텍스트 방향을 설정합니다.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **내장 표 스타일 적용**

Aspose.Slides를 사용하면 코드에서 직접 미리 정의된 스타일을 사용해 표를 서식 지정할 수 있습니다. 이 예제는 표를 만들고, 내장 스타일을 적용한 뒤 결과를 저장하는 과정을 보여 주며, 일관되고 전문적인 서식을 보장하는 효율적인 방법입니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **표의 종횡비 고정**

셰이프의 종횡비는 그 치수 비율을 의미합니다. Aspose.Slides는 `aspect_ratio_locked` 속성을 제공하여 표 및 기타 셰이프의 종횡비를 고정할 수 있게 합니다.

다음 Python 예제는 표의 종횡비를 고정하는 방법을 보여 줍니다:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**전체 표와 셀 내 텍스트에 오른쪽에서 왼쪽(RTL) 읽기 방향을 적용할 수 있나요?**

예. 표는 [right_to_left](https://reference.aspose.com/slides/ko/python-net/aspose.slides/table/right_to_left/) 속성을 제공하고, 단락에는 [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/right_to_left/) 속성이 있습니다. 두 속성을 모두 사용하면 셀 내부에서 올바른 RTL 순서와 렌더링이 보장됩니다.

**사용자가 최종 파일에서 표를 이동하거나 크기를 조정하지 못하도록 하려면 어떻게 해야 하나요?**

표에 대해서도 적용되는 [shape locks](/slides/ko/python-net/applying-protection-to-presentation/)를 사용하여 이동, 크기 조정, 선택 등을 비활성화합니다.

**셀 안에 이미지를 배경으로 삽입하는 것이 지원되나요?**

예. 셀에 대해 [picture fill](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/) 속성을 설정하면 이미지가 선택된 모드(스트레치 또는 타일)에 따라 셀 영역을 덮습니다.