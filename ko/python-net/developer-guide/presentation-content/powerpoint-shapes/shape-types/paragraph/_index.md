---
title: Python 프레젠테이션에서 단락 경계 가져오기
linktitle: 단락
type: docs
weight: 60
url: /ko/python-net/paragraph/
keywords:
- 단락 경계
- 텍스트 구간 경계
- 단락 좌표
- 구간 좌표
- 단락 크기
- 텍스트 구간 크기
- 텍스트 프레임
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET에서 단락 및 텍스트 구간 경계를 가져오는 방법을 배우고, PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트 위치를 최적화하세요."
---
## **개요**

이 문서는 Aspose.Slides에서 단락 및 텍스트 구간의 경계, 크기 및 좌표를 가져오는 방법을 설명합니다. `get_rect()`를 사용하여 `TextFrame` 내 단락의 사각형을 검색하는 방법, 테이블 셀 텍스트 프레임 내부의 단락 및 구간 좌표를 얻는 방법을 보여주며, 측정 단위, 텍스트 래핑이 경계에 미치는 영향, 픽셀 변환 및 유효 단락 서식 값과 같은 중요한 세부 사항을 강조합니다.

## **TextFrame에서 단락 및 구간 좌표 가져오기**

Aspose.Slides for Python via .NET를 사용하면 개발자는 이제 TextFrame의 단락 컬렉션 내부에 있는 Paragraph의 사각형 좌표를 얻을 수 있습니다. 또한 단락의 구간 컬렉션 내부에 있는 구간의 좌표를 얻을 수 있습니다. 이 항목에서는 예제를 통해 단락의 사각형 좌표와 단락 내부 구간의 위치를 ​​가져오는 방법을 시연합니다.

## **단락의 사각형 좌표 가져오기**

새 메서드 **GetRect()**가 추가되었습니다. 이 메서드를 사용하면 단락 경계 사각형을 얻을 수 있습니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **테이블 셀 텍스트 프레임 내부에서 단락 및 구간 크기 가져오기** ##

테이블 셀 텍스트 프레임에서 [Portion](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/) 또는 [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/)의 크기와 좌표를 가져오려면 [IPortion.GetRect](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iportion/) 및 [IParagraph.GetRect](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iparagraph/) 메서드를 사용할 수 있습니다.

이 샘플 코드는 설명된 작업을 보여줍니다:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **자주 묻는 질문**

**단락 및 텍스트 구간의 좌표는 어떤 단위로 반환되나요?**

포인트 단위이며, 1인치 = 72포인트입니다. 이는 슬라이드의 모든 좌표와 치수에 적용됩니다.

**단어 래핑이 단락의 경계에 영향을 미칩니까?**

예. [wrapping](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/wrap_text/)이 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)에서 활성화되면 텍스트가 영역 너비에 맞게 줄바꿈되어 단락의 실제 경계가 변경됩니다.

**단락 좌표를 내보낸 이미지의 픽셀에 신뢰성 있게 매핑할 수 있나요?**

예. 픽셀 = 포인트 × (DPI / 72) 로 포인트를 픽셀로 변환합니다. 결과는 렌더링/내보내기에 선택한 DPI에 따라 달라집니다.

**스타일 상속을 고려한 "유효한" 단락 서식 매개변수는 어떻게 가져오나요?**

[effective paragraph formatting data structure](/slides/ko/python-net/shape-effective-properties/)를 사용하세요; 들여쓰기, 간격, 래핑, RTL 등에 대한 최종 통합 값을 반환합니다.