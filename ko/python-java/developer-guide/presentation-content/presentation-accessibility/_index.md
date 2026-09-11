---
title: Python을 통해 Java에서 프레젠테이션 접근성 관리
linktitle: 프레젠테이션 접근성
type: docs
weight: 30
url: /ko/python-java/presentation-accessibility/
keywords:
- 프레젠테이션 접근성
- 장식으로 표시
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python을 통한 Java용 Aspose.Slides가 PPT, PPTX 및 ODP 파일에서 프레젠테이션 접근성 검사를 자동화하는 방법을 알아보고, 스크린 리더 경험을 향상시키고 규정 준수를 강화하세요."
---
## **Introduction**

프레젠테이션 접근성은 스크린 리더, 점자 디스플레이, 키보드 전용 탐색과 같은 보조 기술을 사용하는 사람들이 시각이 있거나 마우스를 사용하는 관객만큼 슬라이드를 이해하고 탐색할 수 있도록 보장합니다. 좋은 실천은 명확한 읽기 순서, 유의미한 대체 텍스트, 충분한 색 대비, 가독성 좋은 타이포그래피, 설명적인 링크 텍스트, 색상이나 위치만으로 의미를 전달하지 않는 것을 중점으로 합니다. 접근성을 처음부터 계획하면 구조가 더 깔끔해지고 시각적 일관성이 증가하며, 모든 사용자가 별도의 우회 없이 내용을 볼 수 있습니다.

## **Mark as Decorative**

Mark as decorative 플래그는 순수하게 장식용인 시각 요소에 적용되어 스크린 리더가 이를 건너뛰게 하여 잡음을 줄이고 의미 있는 콘텐츠에 집중하도록 합니다. 배경, 장식, 간격 요소 등에 적용하고 차트, 아이콘, 정보를 전달하는 이미지에는 절대 적용하지 마십시오. Aspose.Slides는 이 플래그를 감지하고 검증할 수 있도록 제공하여 자동 접근성 검사 및 정리를 가능하게 합니다.

![장식으로 표시](mark_as_decorative.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```