---
title: Python을 사용하여 PowerPoint 테이블의 행 및 열 관리
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
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint에서 테이블의 행과 열을 관리하고 프레젠테이션 편집 및 데이터 업데이트를 빠르게 수행합니다."
---
## **소개**

Aspose.Slides for Python via .NET를 사용하면 PowerPoint 프레젠테이션에서 테이블 구조와 서식을 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) 클래스를 통해 관리할 수 있습니다. 헤더 행을 지정하고, 행 및 열을 복제하거나 제거하며, 전체 행 또는 열에 텍스트 서식을 적용할 수 있습니다.

이 문서에서는 Python 예제를 통해 이러한 작업을 설명합니다. 또한 테이블의 스타일 프리셋을 가져와 재사용하는 방법을 보여줍니다. 테이블 행 및 열 인덱스는 0부터 시작합니다.

## **행 높이 제어**

점 단위로 행의 최소 높이를 설정하려면 [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/)을 사용합니다. 이는 하한값이며 고정 높이가 아닙니다. 실제 높이를 반환하고 읽기 전용인 [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/)를 사용할 수 있습니다. [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/)를 통해 행에 접근합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형으로 테이블이 있는 [row-height-input.pptx](row-height-input.pptx)를 로드합니다. 첫 번째 행은 70점에서 시작합니다. 셀은 18점 Arial 텍스트와 자동 줄 바꿈, 상하 6점 여백을 사용하며, 두 번째 열의 긴 텍스트는 여러 줄로 래핑됩니다. 예제는 최소값을 100점으로 증가시킨 다음 20점으로 감소시키고, 각 변경 후 실제 높이를 출력하며 두 결과를 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

제공된 프레젠테이션에서 최소값을 증가시키면 행에 공간이 추가됩니다. 감소시키면 해당 여분의 공간이 제거되지만, 텍스트와 셀 여백 때문에 실제 높이는 20점보다 크게 유지됩니다. 최소값만 줄여서는 내용이 필요로 하는 공간 이하로 행을 강제로 낮출 수 없습니다.

실제 높이에 영향을 미치는 여러 요인:

- **텍스트 및 폰트 크기:** 긴 텍스트, 명시적인 줄 바꿈 또는 큰 폰트는 더 많은 수직 공간을 필요로 할 수 있습니다.
- **자동 줄 바꿈 및 열 너비:** 자동 줄 바꿈이 활성화된 경우, 더 좁은 [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/)은 더 많은 줄을 생성할 수 있습니다. 넓은 열은 수직으로 필요한 공간을 줄일 수 있습니다.
- **셀 여백:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) 및 [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/)는 수직 공간을 추가합니다. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) 및 [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/)는 텍스트에 사용할 수 있는 너비를 줄이며 추가 줄 바꿈을 일으킬 수 있습니다.

병합된 셀이 없는 이 테이블에서는 가장 많은 수직 공간이 필요한 셀이 전체 행의 콘텐츠 기반 하한을 결정합니다. 행을 짧게 만들려면 텍스트를 줄이거나, 폰트 크기 또는 여백을 감소시키거나, 열을 넓혀야 할 수도 있습니다.

아래 이미지들은 동일한 비율로 같은 테이블을 보여줍니다. 이번 실행에서 실제 높이는 각각 70점, 100점, 55.2점이었습니다: 최종 행은 20점 최소값보다 높게 유지되었습니다. 정확한 텍스트 측정은 사용 환경의 폰트에 따라 달라질 수 있습니다. 저장된 결과를 다운로드하십시오: [increased minimum](row-height-increased.pptx) 및 [decreased minimum](row-height-decreased.pptx).

| 원본: 최소 70pt, 실제 70pt | 증가: 최소 100pt, 실제 100pt | 감소: 최소 20pt, 실제 55.2pt |
| --- | --- | --- |
| ![첫 번째 행이 70점인 원본 테이블.](row-height-before.png) | ![첫 번째 행 최소값을 100점으로 증가시킨 후의 테이블.](row-height-increased.png) | ![첫 번째 행 최소값을 20점으로 감소시킨 후의 테이블; 자동 줄 바꿈 텍스트 때문에 행이 최소값보다 높게 유지됩니다.](row-height-decreased.png) |

## **첫 번째 행을 헤더로 설정**

[first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) 속성을 사용하여 첫 번째 행을 헤더 서식으로 표시합니다. 외관은 적용된 테이블 스타일에 따라 달라집니다.

1. 프레젠테이션을 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 클래스로 로드합니다.
2. 첫 번째 슬라이드에 접근합니다.
3. 슬라이드의 첫 번째 도형으로 저장된 테이블에 접근합니다.
4. 첫 번째 행에 헤더 서식을 활성화합니다.
5. 수정된 프레젠테이션을 저장합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형으로 테이블이 있는 `table.pptx`가 필요합니다. 첫 번째 행에 헤더 서식을 적용하고 `First_row_header.pptx`로 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **테이블 행 또는 열 복제**

행 또는 열을 복제하여 내용과 서식을 재사용합니다. 복사본을 테이블 끝에 추가하거나 특정 위치에 삽입할 수 있습니다.

1. 프레젠테이션을 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 클래스로 로드합니다.
2. 첫 번째 슬라이드에 접근합니다.
3. 열 너비와 행 높이를 정의합니다.
4. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 메서드로 테이블을 추가합니다.
5. 필요한 행을 복제합니다.
6. 필요한 열을 복제합니다.
7. 수정된 프레젠테이션을 저장합니다.

예제는 최소 하나의 슬라이드가 있는 `Test.pptx`가 필요합니다. 점 단위로 지정된 크기로 3열 5행 테이블을 생성합니다. 첫 번째 행과 열의 복사본을 추가한 다음, 두 번째 행과 열의 복사본을 인덱스 3(네 번째 위치)에 삽입합니다. 결과 테이블은 7행 5열이 됩니다. `False` 인자는 인접한 병합된 행이나 열로 복제되는 것을 비활성화합니다; 이 테이블에는 병합된 셀이 없습니다.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **테이블에서 행 또는 열 제거**

테이블에서 더 이상 필요하지 않은 행이나 열을 제거합니다. 항목을 제거하면 그 뒤에 있는 행이나 열의 인덱스가 이동합니다.

1. 프레젠테이션을 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 클래스로 생성합니다.
2. 첫 번째 슬라이드에 접근합니다.
3. 열 너비와 행 높이를 정의합니다.
4. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) 메서드로 테이블을 추가합니다.
5. 두 번째 행과 두 번째 열을 제거합니다.
6. 수정된 프레젠테이션을 저장합니다.

이 예제는 3x3 테이블을 만든 후 인덱스 1에 있는 행과 열을 제거하여 `TestTable_out.pptx`에 2x2 테이블을 남깁니다. 크기는 점 단위입니다. `False` 인자는 인접한 병합된 행이나 열을 제거하지 않도록 합니다; 이 테이블에는 병합된 셀이 없습니다.

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

## **테이블 행 수준에서 텍스트 서식 설정**

전체 행에 텍스트 서식을 적용하여 셀들을 일관되게 유지합니다. 각 셀을 개별적으로 서식 지정하지 않고도 폰트 속성, 단락 서식 및 텍스트 방향을 설정할 수 있습니다.

1. 프레젠테이션을 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 클래스로 로드합니다.
2. 첫 번째 슬라이드의 테이블에 접근합니다.
3. [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/)을 첫 번째 행에 설정합니다.
4. 첫 번째 행에 [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 및 [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/)를 설정합니다.
5. 두 번째 행에 [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/)를 설정합니다.
6. 수정된 프레젠테이션을 저장합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형으로 테이블이 있는 `table.pptx`와 최소 두 행이 필요합니다. 첫 번째 행에 25점 텍스트, 오른쪽 정렬, 20점 오른쪽 단락 여백을 적용하고, 두 번째 행에 수직 텍스트를 설정합니다.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **테이블 열 수준에서 텍스트 서식 설정**

전체 열에 텍스트 서식을 적용하여 셀들을 일관되게 유지합니다. 각 셀을 개별적으로 서식 지정하지 않고도 폰트 속성, 단락 서식 및 텍스트 방향을 설정할 수 있습니다.

1. 프레젠테이션을 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 클래스로 로드합니다.
2. 첫 번째 슬라이드의 테이블에 접근합니다.
3. [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/)을 첫 번째 열에 설정합니다.
4. 첫 번째 열에 [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 및 [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/)를 설정합니다.
5. 두 번째 열에 [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/)를 설정합니다.
6. 수정된 프레젠테이션을 저장합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형으로 테이블이 있는 `table.pptx`와 최소 두 열이 필요합니다. 첫 번째 열에 25점 텍스트, 오른쪽 정렬, 20점 오른쪽 단락 여백을 적용하고, 두 번째 열에 수직 텍스트를 설정합니다.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **테이블 스타일 속성 가져오기**

[style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) 속성을 사용하여 테이블에 적용된 프리셋을 가져오고 다른 테이블에 재사용합니다. 이는 개별 셀 서식 재정의가 아닌 프리셋을 식별합니다.

예제는 테이블을 생성하고 [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/)을 적용한 뒤 프리셋을 다시 읽어옵니다. 가져온 프리셋이 적용된 프리셋과 일치하면 `True`를 출력하고 테이블을 `table.pptx`에 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**이미 만든 테이블에 PowerPoint 테마/스타일을 적용할 수 있나요?**

네. 테이블은 슬라이드/레이아웃/마스터 테마를 상속받으며, 해당 테마 위에 채우기, 테두리 및 텍스트 색상을 여전히 재정의할 수 있습니다.

**Excel처럼 테이블 행을 정렬할 수 있나요?**

아니요, Aspose.Slides 테이블에는 내장된 정렬이나 필터 기능이 없습니다. 먼저 메모리에서 데이터를 정렬한 다음 해당 순서대로 테이블 행을 다시 채워넣으세요.

**특정 셀에 사용자 정의 색상을 유지하면서 밴드(줄무늬) 열을 가질 수 있나요?**

네. 밴드 열을 활성화한 다음, 특정 셀에 로컬 서식을 적용하면 됩니다. 셀 수준 서식이 테이블 스타일보다 우선합니다.