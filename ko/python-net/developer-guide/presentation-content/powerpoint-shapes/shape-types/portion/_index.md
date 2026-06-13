---
title: Python을 사용한 프레젠테이션의 텍스트 구분 영역 관리
linktitle: 텍스트 구분 영역
type: docs
weight: 70
url: /ko/python-net/portion/
keywords:
- 텍스트 구분 영역
- 텍스트 부분
- 텍스트 좌표
- 텍스트 위치
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트 구분 영역을 관리하는 방법을 배우고, 성능과 사용자 정의를 향상시킵니다."
---
## **소개**

텍스트 구분 영역은 단락 내의 특정 텍스트 조각을 나타내며, 주변 내용과 독립적으로 해당 조각을 작업할 수 있게 합니다. Aspose.Slides에서는 텍스트 조각의 위치를 가져오거나, 단락의 일부에만 서식을 적용하거나, 텍스트 동작을 보다 자세히 제어해야 할 때 구분 영역을 사용할 수 있습니다.

## **텍스트 구분 영역 좌표 가져오기**

[get_coordinates](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/get_coordinates/) 메서드가 [Portion](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/) 클래스에 추가되어 텍스트 구분 영역의 좌표를 가져올 수 있습니다:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **자주 묻는 질문**

**단일 단락 내 텍스트의 일부분에만 하이퍼링크를 적용할 수 있나요?**

예, 개별 구분 영역에 [하이퍼링크 할당](/slides/ko/python-net/manage-hyperlinks/)을 지정할 수 있습니다; 해당 조각만 클릭 가능하고 전체 단락은 클릭되지 않습니다.

**스타일 상속은 어떻게 작동합니까: Portion가 어떤 속성을 재정의하고, Paragraph/TextFrame에서 어떤 속성을 가져오는지?**

Portion 수준 속성이 가장 높은 우선순위를 가집니다. 해당 속성이 [Portion](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/)에 설정되지 않은 경우 엔진은 [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/)에서 가져오며, 그곳에도 설정되지 않으면 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 또는 [theme](https://reference.aspose.com/slides/ko/python-net/aspose.slides.theme/theme/) 스타일에서 가져옵니다.

**Portion에 지정된 폰트가 대상 머신/서버에 없으면 어떻게 됩니까?**

[Font substitution rules](/slides/ko/python-net/font-selection-sequence/)가 적용됩니다. 텍스트가 재배치될 수 있으며, 메트릭, 하이픈 삽입 및 너비가 변경될 수 있어 정확한 위치 지정에 영향을 줍니다.

**Paragraph의 나머지 부분과 독립적으로 Portion 전용 텍스트 채우기 투명도나 그라데이션을 설정할 수 있나요?**

예, [Portion](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/) 수준에서 텍스트 색상, 채우기 및 투명도를 주변 조각과 다르게 설정할 수 있습니다.