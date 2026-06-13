---
title: .NET에서 PowerPoint 차트 애니메이션
linktitle: 애니메이션 차트
type: docs
weight: 80
url: /ko/net/animated-charts/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides를 사용하여 .NET에서 놀라운 애니메이션 차트를 만들고, PPT 및 PPTX 파일에 동적인 비주얼을 추가해 프레젠테이션을 강화하세요—지금 시작하세요."
---
## **소개**

Aspose.Slides for .NET은 차트 요소의 애니메이션을 지원합니다. **Series**, **Categories**, **Series Elements**, **Categories Elements**는 [ISequence.AddEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/isequence/methods/addeffect) 메서드와 두 개의 열거형 [EffectChartMajorGroupingType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effectchartmajorgroupingtype) 및 [EffectChartMinorGroupingType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effectchartminorgroupingtype)을 사용하여 애니메이션할 수 있습니다.

## **차트 시리즈 애니메이션**
차트 시리즈를 애니메이션하려면, 아래 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 개체에 대한 참조를 가져옵니다.
1. 시리즈를 애니메이션합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예제에서는 차트 시리즈를 애니메이션했습니다.

```c#
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // 차트 객체에 대한 참조를 가져옵니다
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // 시리즈를 애니메이션합니다
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
    EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 0,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 1,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 2,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 3,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 수정된 프레젠테이션을 디스크에 저장합니다 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```

## **차트 카테고리 애니메이션**
차트 카테고리를 애니메이션하려면, 아래 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 개체에 대한 참조를 가져옵니다.
1. 카테고리를 애니메이션합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예제에서는 차트 카테고리를 애니메이션했습니다.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // 차트 객체에 대한 참조를 가져옵니다
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // 카테고리 요소를 애니메이션합니다
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 프레젠테이션 파일을 디스크에 저장합니다
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **시리즈 요소의 애니메이션**
시리즈 요소를 애니메이션하려면, 아래 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 개체에 대한 참조를 가져옵니다.
1. 시리즈 요소를 애니메이션합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예제에서는 시리즈 요소를 애니메이션했습니다.

```c#
// 프레젠테이션을 로드합니다
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // 차트 객체에 대한 참조를 가져옵니다
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // 시리즈 요소를 애니메이션합니다
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 프레젠테이션 파일을 디스크에 저장합니다 
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
```

## **카테고리 요소의 애니메이션**
카테고리 요소를 애니메이션하려면, 아래 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 개체에 대한 참조를 가져옵니다.
1. 카테고리 요소를 애니메이션합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예제에서는 카테고리 요소를 애니메이션했습니다.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // 차트 객체에 대한 참조를 가져옵니다
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // 카테고리 요소를 애니메이션합니다
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 프레젠테이션 파일을 디스크에 저장합니다
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**차트도 일반 도형과 마찬가지로 다양한 효과 유형(예: 시작, 강조, 종료)이 지원되나요?**  
예. 차트는 도형으로 취급되므로, 시작, 강조, 종료를 포함한 표준 애니메이션 효과 유형을 지원하며 슬라이드의 타임라인 및 애니메이션 시퀀스를 통해 전체적으로 제어할 수 있습니다.

**차트 애니메이션을 슬라이드 전환과 결합할 수 있나요?**  
예. [Transitions](/slides/ko/net/slide-transition/)은 슬라이드에 적용되고, 애니메이션 효과는 슬라이드상의 객체에 적용됩니다. 동일한 프레젠테이션에서 두 기능을 함께 사용할 수 있으며 각각을 독립적으로 제어할 수 있습니다.

**PPTX로 저장할 때 차트 애니메이션이 유지되나요?**  
예. [save to PPTX](/slides/ko/net/save-presentation/)를 수행하면 모든 애니메이션 효과와 순서가 프레젠테이션 고유의 애니메이션 모델에 포함되어 있으므로 유지됩니다.

**기존 프레젠테이션에서 차트 애니메이션을 읽고 수정할 수 있나요?**  
예. [API](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/)는 슬라이드 타임라인, 시퀀스 및 효과에 접근할 수 있게 해 주어 기존 차트 애니메이션을 검사하고 처음부터 모두 다시 만들 필요 없이 조정할 수 있습니다.

**Aspose.Slides를 사용해 차트 애니메이션이 포함된 비디오를 만들 수 있나요?**  
예. [export a presentation to video](/slides/ko/net/convert-powerpoint-to-video/)를 사용하면 애니메이션을 유지하면서 타이밍 및 기타 내보내기 설정을 구성하여 결과 영상이 애니메이션 재생을 반영하도록 할 수 있습니다.