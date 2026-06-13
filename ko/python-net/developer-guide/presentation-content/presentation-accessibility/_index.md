---
title: Python에서 프레젠테이션 접근성 관리
linktitle: 프레젠테이션 접근성
type: docs
weight: 30
url: /ko/python-net/presentation-accessibility/
keywords:
- 프레젠테이션 접근성
- 장식용으로 표시
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python이 PPT, PPTX 및 ODP 파일에서 프레젠테이션 접근성 검사를 자동화하도록 도와줍니다—스크린 리더 경험을 향상하고 규정 준수를 강화합니다."
---
## **소개**

프레젠테이션 접근성은 화면 판독기, 점자 디스플레이, 또는 키보드 전용 탐색 등 보조 기술을 사용하는 사람들이 시각이 있고 마우스를 사용하는 청중만큼 슬라이드를 이해하고 탐색할 수 있도록 보장합니다. 우수한 실천은 명확한 읽기 순서, 유용한 시각 자료에 대한 의미 있는 대체 텍스트, 충분한 색 대비, 가독성 높은 타이포그래피, 설명적인 링크 텍스트, 그리고 색상이나 위치만으로 의미를 전달하지 않는 것을 중점으로 합니다. 접근성을 처음부터 계획하면 구조가 더 깔끔해지고 시각 자료가 일관되며, 별도의 우회 조치 없이 모든 사용자에게 도달하는 콘텐츠가 만들어집니다.

## **장식용으로 표시**

장식용으로 표시는 순수 장식용 시각 요소에 플래그를 지정하여 화면 판독기가 이를 건너뛰게 함으로써 잡음을 줄이고 의미 있는 콘텐츠에 초점을 맞추게 합니다. 배경, 장식 요소 및 간격용 요소에 적용하고 차트, 아이콘 또는 정보를 전달하는 이미지에는 절대 적용하지 마세요. Aspose.Slides는 이 플래그를 감지 및 검증하도록 제공하여 자동 접근성 검사와 정리를 가능하게 합니다.

![장식용으로 표시](mark_as_decorative.png)

다음 코드 샘플은 도형이 장식용으로 표시되었는지 확인하는 방법을 보여줍니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    print(f"Is shape decorative: {shape.is_decorative}")
```