---
title: "Python via Java에서 PowerPoint 차트 애니메이션"
linktitle: "애니메이션 차트"
type: docs
weight: 80
url: /ko/python-java/animated-charts/
keywords:
- 차트
- 애니메이션 차트
- 차트 애니메이션
- 차트 시리즈
- 차트 카테고리
- 시리즈 요소
- 카테고리 요소
- 효과 추가
- 효과 유형
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides와 함께 Python via Java에서 놀라운 애니메이션 차트를 만들세요. PPT 및 PPTX 파일에 동적인 비주얼을 추가해 프레젠테이션을 강화합니다—지금 바로 시작하세요."
---
## **소개**

Aspose.Slides for Python via Java는 차트 요소에 대한 애니메이션을 지원합니다. **Series**, **Categories**, **Series Elements**, **Category Elements**는 [Sequence.addEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sequence/#addEffect) 메서드와 두 개의 열거형인 [EffectChartMajorGroupingType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effectchartmajorgroupingtype/) 및 [EffectChartMinorGroupingType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effectchartminorgroupingtype/)을 사용하여 애니메이션화할 수 있습니다.

## **차트 시리즈 애니메이션**

차트 시리즈를 애니메이션화하려면 아래 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체에 대한 참조를 가져옵니다.
1. 시리즈에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

다음 예제는 차트 시리즈에 애니메이션을 적용합니다. 예제 파일의 차트에는 세 개의 시리즈가 있으므로 0부터 2까지 각 인덱스마다 하나의 효과가 추가됩니다. Aspose.Slides는 인덱스를 차트 데이터와 확인하지 않으며, 존재하지 않는 시리즈에 추가된 효과는 파일에 기록되지만 아무 것도 애니메이션하지 않습니다—귀하의 차트에서 인덱스를 시리즈 수보다 낮게 유지하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# 프레젠테이션을 로드합니다.
presentation = Presentation("ExistingChart.pptx")
try:
    # 차트 객체에 대한 참조를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # 차트 요소에 애니메이션을 적용합니다.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 수정된 프레젠테이션을 디스크에 저장합니다.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **차트 카테고리 애니메이션**

차트 카테고리를 애니메이션화하려면 아래 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체에 대한 참조를 가져옵니다.
1. 카테고리에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

다음 예제는 차트 카테고리에 애니메이션을 적용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# 프레젠테이션을 로드합니다.
presentation = Presentation("ExistingChart.pptx")
try:
    # 차트 객체에 대한 참조를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # 차트 요소에 애니메이션을 적용합니다.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 수정된 프레젠테이션을 디스크에 저장합니다.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **시리즈 요소의 애니메이션**

시리즈 요소를 애니메이션화하려면 아래 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체에 대한 참조를 가져옵니다.
1. 시리즈 요소에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

다음 예제는 시리즈 요소에 애니메이션을 적용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# 프레젠테이션을 로드합니다.
presentation = Presentation("ExistingChart.pptx")
try:
    # 차트 객체에 대한 참조를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # 차트 요소에 애니메이션을 적용합니다.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 수정된 프레젠테이션을 디스크에 저장합니다.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **카테고리 요소의 애니메이션**

카테고리 요소를 애니메이션화하려면 아래 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체에 대한 참조를 가져옵니다.
1. 카테고리 요소에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

다음 예제는 카테고리 요소에 애니메이션을 적용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpave.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# 프레젠테이션을 로드합니다.
presentation = Presentation("ExistingChart.pptx")
try:
    # 차트 객체에 대한 참조를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # 차트 요소에 애니메이션을 적용합니다.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 수정된 프레젠테이션을 디스크에 저장합니다.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**일반 도형과 마찬가지로 차트에서도 다양한 효과 유형(예: 들어오기, 강조, 나가기)이 지원되나요?**

네. 차트는 도형으로 취급되므로 들어오기, 강조, 나가기를 포함한 표준 애니메이션 효과 유형을 지원하며, 슬라이드 타임라인과 애니메이션 시퀀스를 통해 전체 제어가 가능합니다.

**차트 애니메이션을 슬라이드 전환과 함께 사용할 수 있나요?**

네. [전환](/slides/ko/python-java/slide-transition/)는 슬라이드에 적용되고, 애니메이션 효과는 슬라이드의 객체에 적용됩니다. 두 가지를 동일한 프레젠테이션에서 함께 사용할 수 있으며 각각 독립적으로 제어할 수 있습니다.

**PPTX로 저장할 때 차트 애니메이션이 유지되나요?**

네. [PPTX로 저장](/slides/ko/python-java/save-presentation/)를 수행하면 모든 애니메이션 효과와 순서가 프레젠테이션 고유의 애니메이션 모델에 포함되어 있기 때문에 유지됩니다.

**프레젠테이션에서 기존 차트 애니메이션을 읽어 수정할 수 있나요?**

네. API는 슬라이드 타임라인, 시퀀스 및 효과에 대한 액세스를 제공하므로 기존 차트 애니메이션을 검사하고 처음부터 모두 다시 만들 필요 없이 조정할 수 있습니다.

**Aspose.Slides를 사용해 차트 애니메이션이 포함된 비디오를 만들 수 있나요?**

네. [프레젠테이션을 비디오로 내보내기](/slides/ko/python-java/convert-powerpoint-to-video/)를 사용하면 애니메이션을 유지하면서 타이밍 및 기타 내보내기 설정을 구성하여 결과 비디오가 애니메이션 재생을 반영하도록 할 수 있습니다.