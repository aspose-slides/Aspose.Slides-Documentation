---
title: 파이썬에서 프레젠테이션 슬라이드 비교
linktitle: 슬라이드 비교
type: docs
weight: 50
url: /ko/python-java/compare-slides/
keywords:
- 슬라이드 비교
- 슬라이드 비교
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Java를 통해 Python용 Aspose.Slides로 PowerPoint 및 OpenDocument 프레젠테이션을 프로그래밍 방식으로 비교합니다. 코드를 사용해 슬라이드 차이를 빠르게 식별합니다."
---
## **Overview**

Aspose.Slides는 [equals](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslide/#equals) 메서드를 사용하여 슬라이드, 레이아웃 슬라이드 및 마스터 슬라이드를 비교할 수 있습니다. 이 메서드는 비교된 슬라이드가 구조와 정적 콘텐츠가 동일할 때 `True`를 반환합니다.

## **Compare Two Slides**

[equals](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslide/#equals) 메서드는 구조와 정적 콘텐츠가 동일한 슬라이드, 레이아웃 슬라이드 및 마스터 슬라이드에 대해 `True`를 반환합니다.

두 슬라이드가 동일하다고 판단되는 기준은 모든 도형, 스타일, 텍스트, 애니메이션 및 기타 설정이 동일한 경우입니다. 비교 시 슬라이드 ID와 같은 고유 식별자 값이나 날짜 자리 표시자와 같은 동적 콘텐츠는 고려되지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **FAQ**

**Does the fact that a slide is hidden affect the comparison of the slides themselves?**

[Hidden status](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getHidden) 은 프레젠테이션/재생 수준의 속성으로, 시각적 콘텐츠가 아닙니다. 두 슬라이드의 동일성은 구조와 정적 콘텐츠에 의해 결정되며, 슬라이드가 숨겨져 있다는 사실만으로 슬라이드가 달라지는 것은 아닙니다.

**Are hyperlinks and their parameters taken into account?**

예. 하이퍼링크는 슬라이드의 정적 콘텐츠의 일부입니다. URL이나 하이퍼링크 동작이 다르면 일반적으로 정적 콘텐츠 차이로 간주됩니다.

**If a chart refers to an external Excel file, will the contents of that file be taken into account?**

아니요. 비교는 슬라이드 자체를 기준으로 수행됩니다. 외부 데이터 소스는 비교 시 일반적으로 읽히지 않으며, 슬라이드의 구조와 정적 상태에 포함된 내용만 고려됩니다.