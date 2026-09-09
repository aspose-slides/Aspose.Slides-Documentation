---
title: "Java를 통해 Python에서 프레젠테이션의 단락 경계 가져오기"
linktitle: "단락 경계"
type: docs
weight: 43
url: /ko/python-java/paragraph-bounds/
keywords:
- "단락 경계"
- "단락 좌표"
- "단락 크기"
- "텍스트 프레임"
- "PowerPoint"
- "프레젠테이션"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java에서 단락 경계를 가져와 PowerPoint 프레젠테이션의 텍스트 위치를 최적화하는 방법을 배우세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 단락의 경계, 크기 및 좌표를 얻는 방법을 설명합니다. [Paragraph.getRect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraph/#getRect) 를 사용하여 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/) 에서 단락 사각형을 가져오는 방법, 표 셀 텍스트 프레임 내부의 단락 좌표를 얻는 방법, 측정 단위, 텍스트 래핑이 경계에 미치는 영향, 픽셀 변환 및 유효 단락 서식 값과 같은 중요한 세부 사항을 강조합니다.

## **단락의 사각형 좌표 얻기**

[Paragraph.getRect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraph/#getRect) 를 사용하여 단락의 경계 사각형을 가져옵니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **표 셀 텍스트 프레임 내부 단락의 크기 얻기**

표 셀 텍스트 프레임에서 [Paragraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraph/) 의 크기와 좌표를 얻으려면 [Paragraph.getRect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraph/#getRect) 를 사용합니다. 반환된 사각형은 표 셀 텍스트 프레임을 기준으로 하므로 슬라이드 수준 좌표가 필요할 경우 표 위치와 셀 오프셋을 추가합니다.

다음 예제는 표 셀 내부 단락의 경계를 가져와 해당 경계를 시각화하기 위해 슬라이드에 사각형을 그립니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**단락 좌표는 어떤 단위로 측정되나요?**

좌표는 포인트 단위로 측정되며, 1인치는 72포인트에 해당합니다. 이는 슬라이드의 모든 좌표와 차원에 적용됩니다.

**단어 래핑이 단락의 경계에 영향을 미치나요?**

예. [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setWrapText) 가 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/) 에 대해 활성화된 경우 텍스트가 영역 너비에 맞게 줄바꿈되어 실제 단락 경계가 변경됩니다.

**내보낸 이미지에서 단락 좌표를 픽셀에 신뢰성 있게 매핑할 수 있나요?**

예. 포인트를 픽셀로 변환하려면 다음 공식을 사용합니다: 픽셀 = 포인트 × (DPI / 72). 결과는 렌더링 또는 내보내기에 선택된 DPI에 따라 달라집니다.

**스타일 상속을 고려한 “유효” 단락 서식 매개변수를 어떻게 얻나요?**

[유효 단락 서식 데이터 구조](/slides/ko/python-java/shape-effective-properties/) 를 사용하십시오; 이는 들여쓰기, 간격, 래핑, RTL 등 최종 통합 값을 반환합니다.