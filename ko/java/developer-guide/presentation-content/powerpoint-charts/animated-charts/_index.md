---
title: Java에서 PowerPoint 차트 애니메이션 만들기
linktitle: 애니메이션 차트
type: docs
weight: 80
url: /ko/java/animated-charts/
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
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 멋진 애니메이션 차트를 만들 수 있습니다. PPT 및 PPTX 파일의 동적 비주얼로 프레젠테이션을 강화하고 지금 바로 시작하세요."
---
## **Introduction**

Aspose.Slides for Java는 차트 요소에 대한 애니메이션을 지원합니다. **Series**, **Categories**, **Series Elements**, **Categories Elements**는 [ISequence.addEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) 메서드와 두 개의 열거형 [EffectChartMajorGroupingType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/EffectChartMajorGroupingType) 및 [EffectChartMinorGroupingType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/EffectChartMinorGroupingType)를 사용하여 애니메이션을 적용할 수 있습니다.

## **Chart Series Animation**
차트 시리즈를 애니메이트하려면 아래에 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체에 대한 참조를 가져옵니다.
1. 시리즈에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예시에서는 차트 시리즈에 애니메이션을 적용했습니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // 차트 객체에 대한 참조를 가져옵니다
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animate the series
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Chart Category Animation**
차트 카테고리를 애니메이트하려면 아래에 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체에 대한 참조를 가져옵니다.
1. 카테고리에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예시에서는 차트 카테고리에 애니메이션을 적용했습니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animation in a Series Element**
시리즈 요소에 애니메이션을 적용하려면 아래에 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체에 대한 참조를 가져옵니다.
1. 시리즈 요소에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예시에서는 시리즈의 요소에 애니메이션을 적용했습니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // 차트 객체에 대한 참조를 가져옵니다
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // 시리즈 요소에 애니메이션을 적용합니다
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 프레젠테이션 파일을 디스크에 저장합니다 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animation in a Category Element**
카테고리 요소에 애니메이션을 적용하려면 아래에 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체에 대한 참조를 가져옵니다.
1. 카테고리 요소에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예시에서는 카테고리 요소에 애니메이션을 적용했습니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // 차트 객체에 대한 참조를 가져옵니다
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // 카테고리 요소에 애니메이션을 적용합니다
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 프레젠테이션 파일을 디스크에 저장합니다
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**차트에 대해 일반 도형과 같이 다양한 효과 유형(예: entrance, emphasis, exit)이 지원되나요?**  
예. 차트는 도형으로 취급되므로 entrance, emphasis, exit를 포함한 표준 애니메이션 효과 유형을 지원하며, 슬라이드 타임라인 및 애니메이션 시퀀스를 통해 완전하게 제어할 수 있습니다.

**차트 애니메이션을 슬라이드 전환과 결합할 수 있나요?**  
예. [Transitions](/slides/ko/java/slide-transition/)는 슬라이드에 적용되고, 애니메이션 효과는 슬라이드상의 객체에 적용됩니다. 동일한 프레젠테이션에서 두 기능을 함께 사용할 수 있으며 각각 독립적으로 제어할 수 있습니다.

**PPTX로 저장할 때 차트 애니메이션이 유지되나요?**  
예. [save to PPTX](/slides/ko/java/save-presentation/)를 수행하면 모든 애니메이션 효과와 순서가 프레젠테이션의 기본 애니메이션 모델에 포함되어 있기 때문에 유지됩니다.

**프레젠테이션에서 기존 차트 애니메이션을 읽고 수정할 수 있나요?**  
예. API는 슬라이드 타임라인, 시퀀스 및 효과에 대한 접근을 제공하므로 기존 차트 애니메이션을 검사하고 처음부터 모두 다시 만들 필요 없이 조정할 수 있습니다.

**Aspose.Slides를 사용해 차트 애니메이션을 포함한 비디오를 만들 수 있나요?**  
예. [export a presentation to video](/slides/ko/java/convert-powerpoint-to-video/)를 사용하면 애니메이션을 유지하면서 타이밍 및 기타 내보내기 설정을 구성해 결과 비디오가 애니메이션 재생을 반영하도록 할 수 있습니다.