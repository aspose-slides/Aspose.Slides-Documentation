---
title: Python에서 PowerPoint 차트 애니메이션
linktitle: 애니메이션 차트
type: docs
weight: 80
url: /ko/python-net/animated-charts/
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
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 멋진 애니메이션 차트를 만들고, PPT, PPTX 및 ODP 파일에 동적 비주얼을 적용해 프레젠테이션을 강화하십시오—지금 시작하세요."
---
## **소개**

Aspose.Slides for Python via .NET은 차트 요소의 애니메이션을 지원합니다. **시리즈**, **카테고리**, **시리즈 요소**, **카테고리 요소**는 [ISequence.add_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/isequence/) 메서드와 두 개의 열거형 [EffectChartMajorGroupingType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effectchartmajorgroupingtype/) 및 [EffectChartMinorGroupingType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effectchartminorgroupingtype/)을 사용하여 애니메이션할 수 있습니다.

## **차트 시리즈 애니메이션**
차트 시리즈를 애니메이션하려면 아래 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체의 참조를 가져옵니다.
1. 시리즈에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예제에서는 차트 시리즈에 애니메이션을 적용했습니다.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다 
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # 차트 객체의 참조를 가져옵니다
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # 시리즈에 애니메이션을 적용합니다
    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectType.FADE, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectChartMajorGroupingType.BY_SERIES, 0, 
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 1,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 2,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 3,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # 수정된 프레젠테이션을 디스크에 저장합니다 
    presentation.save("AnimatingSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **차트 카테고리 애니메이션**
차트 카테고리를 애니메이션하려면 아래 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체의 참조를 가져옵니다.
1. 카테고리에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예제에서는 차트 카테고리에 애니메이션을 적용했습니다.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # 차트 객체의 참조를 가져옵니다
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # 카테고리 요소에 애니메이션을 적용합니다
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # 프레젠테이션 파일을 디스크에 저장합니다
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **시리즈 요소 애니메이션**
시리즈 요소를 애니메이션하려면 아래 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체의 참조를 가져옵니다.
1. 시리즈 요소에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예제에서는 시리즈 요소에 애니메이션을 적용했습니다.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# 프레젠테이션을 로드합니다
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # 차트 객체의 참조를 가져옵니다
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # 시리즈 요소에 애니메이션을 적용합니다
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # 프레젠테이션 파일을 디스크에 저장합니다 
    presentation.save("AnimatingSeriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **카테고리 요소 애니메이션**
카테고리 요소를 애니메이션하려면 아래 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체의 참조를 가져옵니다.
1. 카테고리 요소에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예제에서는 카테고리 요소에 애니메이션을 적용했습니다.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # 차트 객체의 참조를 가져옵니다
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # 카테고리 요소에 애니메이션을 적용합니다
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # 프레젠테이션 파일을 디스크에 저장합니다
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**차트가 일반 도형과 마찬가지로 다양한 효과 유형(예: 입장, 강조, 종료)을 지원합니까?**  
예. 차트는 도형으로 취급되므로 입장, 강조, 종료를 포함한 표준 애니메이션 효과 유형을 지원하며, 슬라이드의 타임라인 및 애니메이션 시퀀스를 통해 전체 제어가 가능합니다.

**차트 애니메이션을 슬라이드 전환과 결합할 수 있습니까?**  
예. [전환](/slides/ko/python-net/slide-transition/)은 슬라이드에 적용되고, 애니메이션 효과는 슬라이드의 객체에 적용됩니다. 두 가지를 동일한 프레젠테이션에서 함께 사용할 수 있으며 각각 독립적으로 제어할 수 있습니다.

**PPTX로 저장할 때 차트 애니메이션이 유지됩니까?**  
예. [PPTX 저장](/slides/ko/python-net/save-presentation/)를 수행하면 모든 애니메이션 효과와 순서가 프레젠테이션의 고유 애니메이션 모델에 포함되어 있기 때문에 유지됩니다.

**프레젠테이션에서 기존 차트 애니메이션을 읽고 수정할 수 있습니까?**  
예. [API](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/)는 슬라이드 타임라인, 시퀀스 및 효과에 대한 접근을 제공하므로 기존 차트 애니메이션을 확인하고 처음부터 모두 다시 만들 필요 없이 조정할 수 있습니다.

**Aspose.Slides for Python via .NET을 사용하여 차트 애니메이션이 포함된 비디오를 만들 수 있습니까?**  
예. [프레젠테이션을 비디오로 내보내기](/slides/ko/python-net/convert-powerpoint-to-video/)를 사용하면 애니메이션을 유지하면서 타이밍 및 기타 내보내기 설정을 구성하여 결과 클립이 애니메이션 재생을 반영하도록 할 수 있습니다.