---
title: Python으로 프레젠테이션의 테이블 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/python-net/manage-cells/
keywords:
- 테이블 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 안의 이미지
- 배경 색상
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: ".NET을 통해 Python용 Aspose.Slides로 PowerPoint 및 OpenDocument의 테이블 셀을 손쉽게 관리하십시오. 셀에 대한 접근, 수정 및 스타일링을 빠르게 마스터하여 원활한 슬라이드 자동화를 구현합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 테이블 셀에 접근하고 수정할 수 있습니다. 이 문서에서는 병합된 테이블 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 뒤 셀 번호 매기기를 처리하는 방법, 셀의 배경 색상을 변경하는 방법, 그리고 테이블 셀에 이미지를 삽입하는 방법을 설명합니다. 예제에서는 프레젠테이션을 생성하거나 열고, 슬라이드에서 테이블을 가져와 셀 속성을 통해 서식을 업데이트한 후 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 보여줍니다.

## **병합된 테이블 셀 식별**

테이블에는 헤더용 또는 관련 데이터를 그룹화하기 위해 종종 병합된 셀이 포함됩니다. 이 섹션에서는 특정 셀이 병합된 영역에 속하는지 확인하고 마스터(왼쪽 상단) 셀을 참조하여 전체 블록을 일관되게 읽거나 서식 지정하는 방법을 살펴봅니다.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) class.
1. Get the table from the first slide.
1. Iterate through the table’s rows and columns to find merged cells.
1. Print a message when merged cells are found.

다음 Python 코드는 프레젠테이션에서 병합된 테이블 셀을 식별합니다:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # 첫 번째 슬라이드의 첫 번째 도형이 테이블이라고 가정합니다.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **테이블 셀 테두리 제거**

때때로 테이블 테두리가 내용에서 산만하게 작용하거나 시각적 혼란을 일으킬 수 있습니다. 이 섹션에서는 선택한 셀 전체 또는 셀의 특정 면에 대해 테두리를 제거하여 더 깔끔한 레이아웃을 구현하고 슬라이드 디자인에 맞추는 방법을 보여줍니다.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) class.
1. Get the slide by its index.
1. Define an array of column widths.
1. Define an array of row heights.
1. Add a table to the slide using the [add_table](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_table/) method.
1. Iterate through each cell to clear the top, bottom, left, and right borders.
1. Save the modified presentation as a PPTX file.

다음 Python 코드는 테이블 셀의 테두리를 제거하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 열의 너비와 행의 높이를 정의합니다.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # 슬라이드에 테이블 도형을 추가합니다.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 각 셀에 대한 테두리 채우기를 제거합니다.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # PPTX 파일을 디스크에 저장합니다.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **병합된 셀의 번호 매기기**

두 쌍의 셀을 병합한다고 가정해 보겠습니다—예를 들어 (1, 1) × (2, 1) 및 (1, 2) × (2, 2)—그 결과 테이블은 병합되지 않은 테이블과 동일한 셀 번호 체계를 유지합니다. 다음 Python 코드는 이 동작을 시연합니다:

```python
import aspose.slides as slides

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 열의 너비와 행의 높이를 정의합니다.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 슬라이드에 테이블 도형을 추가합니다.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 셀 (1,1)과 (2,1)을 병합합니다.
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # 셀 (1, 2)과 (2, 2)을 병합합니다.
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # 셀 인덱스를 출력합니다.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # PPTX 파일을 디스크에 저장합니다.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

출력:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **분할된 셀의 번호 매기기**

이전 예제에서는 셀을 병합했을 때 다른 셀의 번호가 변하지 않았습니다. 이번에는 병합된 셀이 전혀 없는 일반 테이블을 만든 후 셀 (1, 1)을 분할하여 특수한 테이블을 생성합니다. 이 테이블의 번호 매기기에 주목하십시오—다소 특이하게 보일 수 있습니다. 그러나 이것이 Microsoft PowerPoint가 테이블 셀에 번호를 매기는 방식이며, Aspose.Slides도 동일한 동작을 따릅니다.

다음 Python 코드는 이 동작을 보여줍니다:

```python
import aspose.slides as slides

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 열 너비와 행 높이를 정의합니다.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # 슬라이드에 테이블 도형을 추가합니다.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 셀 (1, 1)을 분할합니다.
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # 셀 인덱스를 출력합니다.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # PPTX 파일을 디스크에 저장합니다.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

출력:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **테이블 셀 배경 색상 변경**

다음 Python 예제는 테이블 셀의 배경 색상을 변경하는 방법을 시연합니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # 새 테이블을 생성합니다.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 셀의 배경 색상을 설정합니다.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **테이블 셀에 이미지 삽입**

이 섹션에서는 Aspose.Slides에서 테이블 셀에 이미지를 삽입하는 방법을 설명합니다. 대상 셀에 그림 채우기를 적용하고 스트레치 또는 타일과 같은 표시 옵션을 구성하는 과정을 다룹니다.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) class.
1. Get a slide reference by its index.
1. Define an array of column widths.
1. Define an array of row heights.
1. Add a table to the slide with the [add_table](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_table/) method.
1. Load the image from a file.
1. Add the image to the presentation’s images to obtain a [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/).
1. Set the table cell’s [FillType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/filltype/) to `PICTURE`.
1. Apply the image to the table cell and choose a fill mode (e.g., `STRETCH`).
1. Save the presentation as a PPTX file.

다음 Python 코드는 테이블을 생성하면서 이미지를 셀 내부에 배치하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# Presentation 객체를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 열 너비와 행 높이를 정의합니다.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # 슬라이드에 테이블 도형을 추가합니다.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 이미지를 로드하고 프레젠테이션에 추가하여 PPImage를 얻습니다.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # 이미지를 첫 번째 테이블 셀에 적용합니다.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**단일 셀의 각 면에 대해 서로 다른 선 두께와 스타일을 설정할 수 있나요?**

예. [top](https://reference.aspose.com/slides/ko/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/ko/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/ko/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/ko/python-net/aspose.slides/cellformat/border_right/) 테두리는 각각 별도의 속성을 가지고 있어 각 면의 두께와 스타일을 다르게 지정할 수 있습니다. 이는 본문에 설명된 셀의 면별 테두리 제어와 논리적으로 일치합니다.

**셀의 배경으로 그림을 설정한 뒤 열/행 크기를 변경하면 이미지가 어떻게 되나요?**

동작은 [fill mode](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillmode/) (stretch/​tile)에 따라 달라집니다. 스트레치 모드에서는 이미지가 새로운 셀 크기에 맞게 조정되고, 타일 모드에서는 타일이 재계산됩니다. 본문에서는 셀 내 이미지 표시 모드에 대해 언급하고 있습니다.

**셀의 모든 콘텐츠에 하이퍼링크를 할당할 수 있나요?**

[Hyperlinks](/slides/ko/python-net/manage-hyperlinks/)는 셀의 텍스트 프레임 내부의 텍스트(포션) 수준 또는 전체 테이블/쉐이프 수준에서 설정됩니다. 실제로는 텍스트의 일부에 링크를 지정하거나 셀 전체 텍스트에 링크를 걸 수 있습니다.

**단일 셀 내에서 서로 다른 글꼴을 사용할 수 있나요?**

예. 셀의 텍스트 프레임은 독립적인 서식을 지원하는 [portions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/) (런)들을 지원하므로 글꼴 종류, 스타일, 크기, 색상을 각각 다르게 지정할 수 있습니다.