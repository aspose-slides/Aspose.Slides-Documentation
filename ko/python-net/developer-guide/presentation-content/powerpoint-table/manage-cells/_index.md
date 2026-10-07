---
title: Python을 사용하여 프레젠테이션의 표 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/python-net/manage-cells/
keywords:
- 표 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 안의 이미지
- 배경 색상
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python용 Aspose.Slides for .NET를 사용하여 PowerPoint 표 셀을 관리합니다: 병합 셀 식별, 테두리 제거, 셀 분할, 배경 색상 및 이미지 설정."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 표 셀에 접근하고 수정할 수 있습니다. 이 기사에서는 병합된 표 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀 병합 또는 분할 후 셀 번호 매기기를 다루는 방법, 셀 배경색을 변경하는 방법, 그리고 표 셀 안에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 만들거나 열고, 슬라이드에서 표를 가져오고, 셀 속성을 통해 셀 형식을 업데이트하며, 수정된 프레젠테이션을 PPTX 파일로 저장하는 방법을 보여줍니다.

Aspose.Slides는 0부터 시작하는 인덱스를 사용합니다. 이 기사에 있는 좌표는 `(column, row)` 형식으로 표시됩니다.

## **병합된 표 셀 식별**

예제는 기존 프레젠테이션을 열고 첫 번째 슬라이드의 첫 번째 모양을 표로 접근합니다. 슬라이드와 모양이 존재하고 모양이 표라고 가정합니다. 그런 다음 모든 행과 열을 반복하면서 [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/)을 사용하여 병합된 영역의 셀을 식별합니다. 일치하는 각 셀에 대해 `row;column` 순서로 셀 좌표와 [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), 그리고 영역의 시작 좌표인 [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/)와 [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/)를 출력합니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **표 셀 테두리 제거**

첫 번째 슬라이드에 표를 추가하려면 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)을 만들고 [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/)을 사용합니다. 열 너비, 행 높이 및 표 위치는 포인트 단위로 지정됩니다. 예제에서는 모든 네 개의 셀 테두리를 [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)으로 설정하여 보이지 않게 합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **표 셀 병합**

[merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/)을 사용하여 직사각형 범위의 표 셀을 하나의 셀로 결합합니다. 범위의 왼쪽 위와 오른쪽 아래 모서리에 있는 셀을 지정합니다. 마지막 인자는 병합이 지정된 범위 밖의 셀을 포함할 수 있는지 제어하며, `False`는 병합을 해당 범위 내에만 유지합니다.

예제에서는 70포인트 열과 행을 가진 4×4 표를 만든 다음, `(1, 1)`부터 `(2, 2)`까지 네 개의 중앙 셀을 병합합니다. 결과 셀은 두 열과 두 행을 차지하지만, 표의 기본 그리드는 여전히 네 열과 네 행을 유지합니다. 병합된 셀의 내용이나 형식에 접근하려면 해당 셀의 왼쪽 위 위치인 `table.rows[1][1]`을 사용합니다. 병합 범위 내의 다른 위치는 표 그리드의 일부로 남아 있으므로, 범위 외 셀의 인덱스는 변경되지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **표 셀 분할**

이전 예제에서 셀을 병합하면 표 그리드가 유지됩니다. 셀을 분할하면 새로운 그리드 열이 생기고 오른쪽 셀들의 열 인덱스가 변경될 수 있습니다. Aspose.Slides는 PowerPoint의 표 그리드 모델을 따릅니다.

이 예제는 70포인트 열과 행을 가진 4×4 표를 만든 다음 셀 `(1, 1)`에 대해 [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/)을 호출합니다. 셀의 70포인트 너비 절반을 전달하여 두 개의 동일한 너비 셀을 생성합니다.

분할 후 두 절반은 `table.rows[1][1]`와 `table.rows[1][2]`로 접근할 수 있습니다. 표 그리드는 이제 다섯 열을 갖게 되며, 원래 열 2와 3에 있던 셀은 각각 열 3과 4로 이동합니다. 행 인덱스는 변하지 않습니다. 분할 후 셀에 접근할 때는 이러한 업데이트된 열 인덱스를 사용하십시오.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **행 또는 열 범위로 병합된 셀 분할**

병합된 템플릿 셀을 데이터 채우기에 준비하려면 기존 행 경계에 따라 분할하려면 [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/)을 사용하고, 열 경계에 따라 분할하려면 [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/)을 사용합니다.

`index` 인자는 분할의 상단 부분에 있는 행 또는 왼쪽 부분에 있는 열을 셉니다; 이는 병합된 영역을 기준으로 합니다:

- 행 분할: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- 열 분할: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

예제에서는 프레젠테이션에 첫 번째 슬라이드의 첫 번째 모양이 표이며, `(1, 2)`와 `(1, 3)`이 수직으로 병합되어 있다고 가정합니다. 아래쪽 위치에서 시작하여 [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/)와 [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/)을 사용해 원점을 찾고 두 스팬을 확인합니다. 인덱스 1의 `split_by_row_span`은 제품 이름을 위해 행 2와 3을 분리합니다. 가로 두 열 병합의 경우 대신 인덱스 1의 `split_by_col_span`을 사용합니다.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # 분할 후 테이블에서 결과 셀을 가져옵니다.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

표 그리드와 주변 셀 인덱스는 변경되지 않습니다. 결과 셀을 좌표로 찾아보면, 여기서는 두 셀 모두 스팬이 1이며 [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/)은 `False`를 반환합니다. 더 큰 영역은 하나의 분할 후에도 일부가 병합된 상태로 남을 수 있습니다.

원본 텍스트와 서식은 상위(또는 왼쪽) 셀에 그대로 남고, 새 셀은 비어 있지만 채우기, 테두리, 여백 등 셀 서식을 상속받습니다. 분할 후 셀에 데이터를 채우고 필요한 텍스트 서식을 명시적으로 설정하십시오.

저장된 프레젠테이션에는 템플릿의 셀 서식이 유지된 채 "Product A"와 "Product B" 셀이 별도로 존재합니다. 자세한 내용은 [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)를 참조하십시오.

## **표 셀 배경색 변경**

이 예제는 150포인트 열과 50포인트 행을 가진 표를 생성합니다. 셀 `(2, 3)`(세 번째 열, 네 번째 행)의 [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/)을 solid로, [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/)을 빨간색으로 설정합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **표 셀 안에 이미지 추가**

이 예제를 실행하기 전에 입력 이미지를 작업 디렉터리에 배치하십시오. 이미지 파일은 [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/)을 사용해 로드하고, [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/)으로 프레젠테이션의 이미지 컬렉션에 추가합니다. 그런 다음 이미지를 표의 첫 번째 셀인 `(0, 0)`의 그림 채우기(picture fill)로 할당합니다.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)은 이미지를 셀에 맞게 늘려 채우며, 이때 종횡비가 변경될 수 있습니다. 열 너비와 행 높이는 포인트 단위입니다. 로드된 이미지는 `with` 블록이 끝나면 자동으로 해제됩니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **자주 묻는 질문**

**단일 셀의 각 면에 대해 서로 다른 선 두께와 스타일을 설정할 수 있나요?**

예. [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) 테두리는 별개의 속성을 가지고 있어 각 면의 두께와 스타일을 다르게 설정할 수 있습니다.

**셀 배경에 그림을 설정한 후 열/행 크기를 변경하면 이미지에 어떤 일이 발생하나요?**

동작은 [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/​tile)에 따라 달라집니다. Stretch를 사용하면 이미지가 새로운 셀 크기에 맞게 조정되고, tile을 사용하면 타일이 다시 계산됩니다.

**셀의 모든 콘텐츠에 하이퍼링크를 지정할 수 있나요?**

[Hyperlinks](/slides/ko/python-net/manage-hyperlinks/)는 셀 텍스트 프레임 내부의 텍스트(구간) 수준이나 전체 표/모양 수준에서 설정됩니다. 실제로는 구간에 하이퍼링크를 지정하거나 셀 전체 텍스트에 적용합니다.

**단일 셀 내에서 서로 다른 글꼴을 설정할 수 있나요?**

예. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (런) 별로 독립적인 서식—글꼴 종류, 스타일, 크기, 색상을 지원합니다.