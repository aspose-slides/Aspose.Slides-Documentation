---
title: Python에서 프레젠테이션의 텍스트 부분 경계 가져오기
linktitle: 부분 경계
type: docs
weight: 47
url: /ko/python-net/portion-bounds/
keywords:
- 텍스트 부분 경계
- 텍스트 부분
- 텍스트 조각
- 텍스트 좌표
- 텍스트 위치
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트 부분 경계를 검색하는 방법을 배우세요."
---
## **개요**

텍스트 부분은 단락 내부의 특정 텍스트 조각을 나타내며, 해당 조각을 주변 콘텐츠와 독립적으로 작업할 수 있게 합니다. Aspose.Slides에서는 텍스트 조각의 경계를 가져오거나, 단락의 일부에만 서식을 적용하거나, 텍스트 동작을 보다 상세하게 제어해야 할 때 부분을 사용할 수 있습니다.

이 문서에서는 [Portion.get_rect](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/get_rect/)을 사용하여 부분의 경계 사각형을 가져오는 방법을 보여줍니다. 또한 [Portion.get_coordinates](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/get_coordinates/)을 사용하여 부분 시작 지점의 좌표를 가져오는 방법을 보여줍니다. 추가로, 단일 텍스트 조각에 하이퍼링크를 적용하거나, 서식이 부분, 단락, 텍스트 프레임 및 테마 상속을 통해 어떻게 해결되는지 이해하고, 지정된 폰트가 없을 경우를 처리하는 등 일반적인 부분 관련 시나리오를 강조합니다.

## **텍스트 부분의 경계 가져오기**

[Portion.get_rect](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/get_rect/)을 사용하여 텍스트 부분의 경계 사각형을 가져옵니다:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **텍스트 부분의 좌표 가져오기**

[Portion.get_coordinates](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/get_coordinates/)을 사용하여 텍스트 부분 시작 지점의 좌표를 가져옵니다:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **FAQ**

**단일 단락 내 텍스트의 일부에만 하이퍼링크를 적용할 수 있나요?**

예, 개별 부분에 [하이퍼링크를 할당](/slides/ko/python-net/manage-hyperlinks/)할 수 있습니다. 해당 조각만 클릭 가능하고 전체 단락은 클릭할 수 없습니다.

**스타일 상속은 어떻게 작동하나요: 부분이 무엇을 재정의하고, 단락이나 텍스트 프레임에서 무엇을 가져오나요?**

부분 수준 속성이 가장 높은 우선 순위를 가집니다. 해당 속성이 [Portion](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/)에 설정되지 않은 경우, Aspose.Slides는 [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/)에서 가져옵니다. 그곳에도 설정되지 않으면, Aspose.Slides는 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 또는 [theme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/theme/) 스타일을 사용합니다.

**부분에 지정된 폰트가 대상 컴퓨터나 서버에 없을 경우 어떻게 되나요?**

[폰트 대체 규칙](/slides/ko/python-net/font-selection-sequence/)이 적용됩니다. 텍스트가 재배치될 수 있으며, 메트릭, 하이픈 삽입 및 너비가 변동될 수 있어 정확한 배치에 영향을 미칩니다.

**부분별 텍스트 채우기 투명도나 그라디언트를 단락의 나머지와 별도로 설정할 수 있나요?**

예, [Portion](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/) 수준에서 텍스트 색상, 채우기 및 투명도를 인접 조각과 다르게 지정할 수 있습니다.