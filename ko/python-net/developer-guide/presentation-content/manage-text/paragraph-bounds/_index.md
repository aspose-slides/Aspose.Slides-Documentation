---
title: Python에서 프레젠테이션의 단락 경계 가져오기
linktitle: 단락 경계
type: docs
weight: 43
url: /ko/python-net/paragraph-bounds/
keywords:
- 단락 경계
- 단락 좌표
- 단락 크기
- 텍스트 프레임
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET에서 단락 경계를 가져오는 방법을 학습하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트 위치를 최적화하세요."
---
## **Overview**

이 문서는 Aspose.Slides에서 단락의 경계, 크기 및 좌표를 가져오는 방법을 설명합니다. [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)에서 [Paragraph.get_rect](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/get_rect/)을 사용하여 단락 사각형을 검색하는 방법, 표 셀 텍스트 프레임 내부의 단락 좌표를 가져오는 방법, 측정 단위, 텍스트 래핑이 경계에 미치는 영향, 픽셀 변환 및 실제 단락 서식 값과 같은 중요한 세부 사항을 강조합니다.

## **Get Rectangular Coordinates of a Paragraph**

[Paragraph.get_rect](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/get_rect/)을 사용하여 단락의 경계 사각형을 가져옵니다.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Get the Size of a Paragraph Inside a Table Cell TextFrame**

표 셀 텍스트 프레임에서 [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/)의 크기와 좌표를 가져오려면 [Paragraph.get_rect](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/get_rect/)을 사용합니다. 반환된 사각형은 표 셀 텍스트 프레임을 기준으로 하므로 슬라이드 수준의 좌표가 필요할 때는 표 위치와 셀 오프셋을 더해야 합니다.

다음 예제는 표 셀 내부의 단락 경계를 가져와 슬라이드에 사각형을 그려 해당 경계를 시각화합니다:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**In what units are paragraph coordinates measured?**

좌표는 포인트 단위로 측정되며, 1인치는 72포인트에 해당합니다. 이는 슬라이드의 모든 좌표와 크기에 적용됩니다.

**Does word wrapping affect a paragraph's bounds?**

예. [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/wrap_text/)이 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)에 대해 활성화된 경우 텍스트가 영역 너비에 맞게 줄 바꿈되어 단락의 실제 경계가 변경됩니다.

**Can paragraph coordinates be reliably mapped to pixels in the exported image?**

예. 포인트를 픽셀로 변환하려면 다음 공식을 사용합니다: pixels = points × (DPI / 72). 결과는 렌더링 또는 내보내기에 선택한 DPI에 따라 달라집니다.

**How do I get the "effective" paragraph formatting parameters, taking style inheritance into account?**

[effective paragraph formatting data structure](/slides/ko/python-net/shape-effective-properties/)를 사용합니다; 이는 들여쓰기, 간격, 래핑, RTL 및 기타 서식에 대한 최종 통합 값을 반환합니다.