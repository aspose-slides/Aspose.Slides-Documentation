---
title: Python으로 프레젠테이션 테이블 관리
linktitle: 표 관리
type: docs
weight: 10
url: /ko/python-net/manage-table/
keywords:
- 표 추가
- 표 만들기
- 표 접근
- 가로 세로 비율
- 텍스트 정렬
- 텍스트 서식
- 표 스타일
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 표를 만들고 편집합니다. 표 작업 흐름을 간소화하는 간단한 코드 예제를 확인하세요."
---
## **소개**

PowerPoint의 표는 정보를 행과 열로 구성하여 값을 읽고 비교하기 쉽게 합니다.

Aspose.Slides는 프레젠테이션에서 표를 만들고, 업데이트하고, 관리할 수 있도록 [표](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 및 [셀](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 클래스와 기타 유형을 제공합니다.

## **스크래치에서 표 만들기**

위치를 지정하고 열 너비와 행 높이를 정하여 표를 생성합니다. 슬라이드에 추가한 후 셀 테두리를 서식 지정하고, 셀을 병합하고, 텍스트를 삽입할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 포인트 단위의 열 너비 목록을 정의합니다.
4. 포인트 단위의 행 높이 목록을 정의합니다.
5. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 메서드를 통해 슬라이드에 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 객체를 추가합니다.
6. 각 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)을 반복하면서 위, 아래, 오른쪽, 왼쪽 테두리 서식을 적용합니다.
7. 표 첫 번째 행의 처음 두 셀을 병합합니다.
8. 병합된 셀을 해당 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) 속성을 통해 접근합니다.
9. 병합된 셀에 텍스트를 설정합니다.
10. 수정된 프레젠테이션을 저장합니다.

아래 예시는 (100, 50) 포인트 위치에 열 3개, 행 5개인 표를 만들고, 빨간색 테두리(두께 5 포인트)를 적용하고, 첫 번째 행의 처음 두 셀을 병합한 뒤 결과를 `table.pptx`로 저장합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **표준 표에서 번호 매기기**

표준 표에서 셀 인덱스는 0부터 시작하며 순서는 (열, 행)입니다. 첫 번째 셀은 (0, 0)으로 인덱싱됩니다. Python에서는 `table.rows[row_index][column_index]` 형태로 셀에 접근하며, 이 표현식에서는 행 인덱스가 먼저 옵니다.

예를 들어, 열 4개와 행 4개로 구성된 표의 셀 번호는 다음과 같습니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

이 예시는 위 표와 동일한 4 × 4 표를 만들고, 열 너비와 행 높이를 각각 70 포인트로 설정하며, 빨간색 셀 테두리(두께 5 포인트)를 적용합니다. 좌표는 셀 인덱스를 나타내며, 셀은 비워 두고 표를 `StandardTables_out.pptx`로 저장합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **기존 표에 접근하기**

표는 슬라이드의 도형 컬렉션에 저장됩니다. 도형을 순회하여 표를 찾은 다음, [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 클래스를 사용해 셀을 읽거나 업데이트합니다.

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 클래스를 사용해 프레젠테이션을 로드합니다.
2. 인덱스로 표가 포함된 슬라이드에 대한 참조를 가져옵니다.
3. [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 객체들을 순회하면서 표가 발견되면 중지합니다. 슬라이드에 여러 표가 있는 경우, [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/)를 사용해 필요한 표를 식별합니다.
4. 대상 셀의 텍스트를 업데이트합니다.
5. 수정된 프레젠테이션을 저장합니다.

아래 예시는 `UpdateExistingTable.pptx`를 열어 첫 번째 슬라이드에서 첫 번째 표를 찾고, 열 0, 행 1에 해당하는 셀을 `New`로 설정한 뒤 결과를 `table1_out.pptx`로 저장합니다. 입력 파일에는 최소 하나의 슬라이드가 있어야 하며, 해당 슬라이드의 첫 번째 표는 최소 하나의 열과 두 개의 행을 포함해야 합니다.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

기존 표에서 행의 크기를 조정하고 실제 높이가 요청한 최소 높이를 초과할 수 있는 이유를 보려면 [행 높이 제어](/slides/ko/python-net/manage-rows-and-columns/#control-row-height) 를 참조하십시오.

## **텍스트 프레임을 소유하는 셀 찾기**

표에서 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)을 받는 일반 텍스트 처리 코드에서는 해당 프레임의 [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) 속성을 사용해 소유 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)을 가져옵니다. 표 셀 텍스트 프레임의 경우, [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/)은 설정되어 있고 [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/)는 `None`이며, 표 자체도 도형이기 때문입니다.

셀 좌표는 읽기 전용 [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) 및 [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) 속성을 통해 확인할 수 있습니다. [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) 또한 읽기 전용이며, 소유자를 탐색할 수는 있지만 소유권을 변경하지는 않습니다. 사용하기 전에 반환된 셀이 `None`인지 항상 확인하십시오.

표 셀 및 도형 소유자를 식별하는 완전한 예제(스마트아트 노드와 연결된 도형 포함)는 [텍스트 검색 및 바꾸기](/slides/ko/python-net/search-and-replace-text/)를 참고하십시오.

## **표에서 텍스트 정렬**

개별 셀의 수직 정렬 및 텍스트 방향을 제어할 수 있습니다. 이 섹션의 예제는 첫 번째 셀의 텍스트를 가운데 정렬하고 270도 회전시킵니다.

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 객체를 추가합니다.
4. 표에서 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 객체에 접근합니다.
5. 첫 번째 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)에 접근해 텍스트와 색상을 설정합니다.
6. 셀의 [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) 및 [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/)을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

이 예시는 열 너비 120 포인트, 행 높이 100 포인트인 4 × 4 표를 만들고, 셀 (0, 0)의 텍스트를 포맷한 뒤 첫 번째 행의 나머지 셀에 값을 추가하고 결과를 `Vertical_Align_Text_out.pptx`로 저장합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **표 수준에서 텍스트 서식 설정**

[set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/)을 사용하면 표의 모든 셀에 텍스트 서식을 적용할 수 있습니다. 이 메서드는 부분, 단락 및 텍스트 프레임 서식을 모두 받아들이므로 개별 셀을 순회하지 않아도 됩니다.

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 클래스를 사용해 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에서 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 객체에 접근합니다.
4. 텍스트의 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/)를 설정합니다.
5. [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 및 [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/)을 설정합니다.
6. [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/)을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

아래 예시는 `table.pptx`를 열어(표가 첫 번째 도형으로 포함된 최소 하나의 슬라이드가 있어야 함) 글꼴 크기를 25 포인트로 설정하고, 오른쪽 여백 20 포인트로 오른쪽 정렬된 단락을 만든 뒤 텍스트를 수직으로 배치합니다. 서식이 적용된 프레젠테이션은 `result.pptx`로 저장됩니다.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **표 스타일 속성 가져오기**

[style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/)을 사용해 표의 사전 설정 스타일을 읽거나 지정할 수 있습니다. 이 예제는 하나의 표에 [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/)을 적용하고, 사전 설정 이름을 출력한 뒤 동일한 사전 설정을 두 번째 표에 할당합니다. 두 표 모두 `table-style.pptx`에 저장됩니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **표의 가로 세로 비율 잠금**

표의 가로 세로 비율은 너비와 높이의 비율을 말합니다. [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/)을 사용해 이 비율을 잠글 수 있습니다.

아래 예시는 `pres.pptx`를 열어(표가 첫 번째 도형으로 포함된 최소 하나의 슬라이드가 있어야 함) 현재 잠금 상태를 출력하고, 가로 세로 비율 잠금을 활성화한 뒤 업데이트된 상태(`True`)를 출력하고 결과를 `pres-out.pptx`로 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**전체 표와 셀 안의 텍스트에 대해 오른쪽‑왼쪽(RTL) 읽기 방향을 활성화할 수 있나요?**

예. 표는 [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) 속성을 제공하고, 단락은 [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/) 속성을 제공합니다. 두 속성을 모두 사용하면 셀 내부에서 올바른 RTL 순서와 렌더링을 보장할 수 있습니다.

**최종 파일에서 사용자가 표를 이동하거나 크기를 조정하지 못하도록 하려면 어떻게 해야 하나요?**

[shape locks](/slides/ko/python-net/applying-protection-to-presentation/)를 사용해 이동, 크기 조정, 선택 등을 비활성화합니다. 이러한 잠금은 표에도 적용됩니다.

**셀 안에 이미지를 배경으로 삽입하는 것이 지원되나요?**

예. 셀에 [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/)을 설정하면 이미지가 선택한 모드(스트레치 또는 타일)에 따라 셀 영역을 가득 채웁니다.