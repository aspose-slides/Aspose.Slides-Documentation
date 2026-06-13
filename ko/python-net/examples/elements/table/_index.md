---
title: 테이블
type: docs
weight: 120
url: /ko/python-net/examples/elements/table/
keywords:
- 테이블
- 테이블 추가
- 테이블 액세스
- 테이블 제거
- 셀 병합
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 테이블을 생성하고 서식 지정합니다: 데이터를 삽입하고, 셀을 병합하고, 테두리를 스타일링하고, 내용을 정렬하며, PPT, PPTX 및 ODP를 위한 가져오기/내보내기를 수행합니다."
---
**Aspose.Slides for Python via .NET**를 사용하여 테이블을 추가하고, 액세스하고, 제거하고, 셀을 병합하는 예제입니다.

## **테이블 추가**

두 개의 행과 두 개의 열을 가진 간단한 테이블을 만들습니다.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 열 너비와 행 높이를 정의합니다.
        widths = [80, 80]
        heights = [30, 30]

        # 슬라이드에 테이블 도형을 추가합니다.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **테이블 액세스**

슬라이드에서 첫 번째 테이블 모양을 가져옵니다.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # 슬라이드의 첫 번째 테이블에 접근합니다.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **테이블 제거**

슬라이드에서 테이블을 삭제합니다.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 도형이 테이블이라고 가정합니다.
        table = slide.shapes[0]

        # 슬라이드에서 테이블을 제거합니다.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **테이블 셀 병합**

인접한 테이블 셀을 하나의 셀로 병합합니다.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 도형이 테이블이라고 가정합니다.
        table = slide.shapes[0]

        # 셀을 병합합니다.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```