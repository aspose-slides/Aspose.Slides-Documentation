---
title: Java를 통해 Python에서 프레젠테이션의 텍스트 조각 경계 가져오기
linktitle: 조각 경계
type: docs
weight: 47
url: /ko/python-java/portion-bounds/
keywords:
- 텍스트 조각 경계
- 텍스트 조각
- 텍스트 부분
- 텍스트 좌표
- 텍스트 위치
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션에서 텍스트 조각 경계를 검색하는 방법을 배웁니다."
---
## **개요**

텍스트 조각은 단락 내의 특정 텍스트 조각을 나타내며, 주변 콘텐츠와 독립적으로 해당 조각을 작업할 수 있게 합니다. Aspose.Slides에서는 텍스트 조각의 경계를 가져오거나, 단락의 일부분에만 서식을 적용하거나, 텍스트 동작을 보다 상세하게 제어해야 할 때 조각을 사용할 수 있습니다.

이 문서에서는 [Portion.getRect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/#getRect)을 사용하여 조각의 경계 사각형을 가져오는 방법을 보여줍니다. 또한 [Portion.getCoordinates](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/#getCoordinates)를 사용하여 조각 시작 좌표를 가져오는 방법을 설명합니다. 추가로, 단일 텍스트 조각에 하이퍼링크를 적용하거나, 서식이 조각, 단락, 텍스트 프레임 및 테마 상속을 통해 어떻게 결정되는지 이해하고, 지정된 폰트가 없을 경우를 처리하는 등 일반적인 조각 관련 시나리오를 강조합니다.

## **텍스트 조각의 경계 가져오기**

텍스트 조각의 경계 사각형을 가져오려면 [Portion.getRect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/#getRect)를 사용합니다:

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

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **텍스트 조각의 좌표 가져오기**

텍스트 조각 시작 좌표를 가져오려면 [Portion.getCoordinates](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/#getCoordinates)를 사용합니다:

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

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **FAQ**

**단일 단락 내 텍스트의 일부에만 하이퍼링크를 적용할 수 있나요?**

예, 개별 조각에 [하이퍼링크를 할당](/slides/ko/python-java/manage-hyperlinks/)할 수 있습니다. 해당 조각만 클릭 가능하며 전체 단락은 클릭할 수 없습니다.

**스타일 상속은 어떻게 작동하나요: 조각이 무엇을 재정의하고, 단락이나 텍스트 프레임에서 무엇을 가져오나요?**

조각 수준 속성이 가장 높은 우선순위를 가집니다. 속성이 [Portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/)에 설정되지 않은 경우, Aspose.Slides는 [Paragraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraph/)에서 해당 속성을 가져옵니다. 그곳에도 설정되지 않으면, Aspose.Slides는 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/) 또는 [theme](https://reference.aspose.com/slides/ko/python-java/aspose.slides/theme/) 스타일을 사용합니다.

**조각에 지정된 폰트가 대상 머신이나 서버에 없으면 어떻게 되나요?**

[글꼴 대체 규칙](/slides/ko/python-java/font-selection-sequence/)이 적용됩니다. 텍스트가 재배치될 수 있으며, 메트릭, 하이픈 처리 및 너비가 변경될 수 있어 정확한 위치 지정에 영향을 미칩니다.

**조각 별 텍스트 채우기 투명도나 그라디언트를 단락의 다른 부분과 독립적으로 설정할 수 있나요?**

예, [Portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/) 수준에서 텍스트 색상, 채우기 및 투명도는 인접한 조각과 다르게 설정할 수 있습니다.