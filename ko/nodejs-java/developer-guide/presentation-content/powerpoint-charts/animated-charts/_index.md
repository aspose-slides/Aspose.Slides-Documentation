---
title: JavaScript에서 PowerPoint 차트 애니메이션
linktitle: 애니메이션 차트
type: docs
weight: 80
url: /ko/nodejs-java/animated-charts/
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
- Node.js
- 자바스크립트
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 JavaScript에서 멋진 애니메이션 차트를 만들세요. PPT 및 PPTX 파일에서 동적인 시각 효과로 프레젠테이션을 강화하고 지금 바로 시작하세요."
---
## **소개**

Aspose.Slides for Node.js via Java는 차트 요소에 대한 애니메이션을 지원합니다. **Series**, **Categories**, **Series Elements**, **Categories Elements**는 [Sequence.addEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sequence/#addEffect) 메서드와 두 개의 열거형 [EffectChartMajorGroupingType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effectchartmajorgroupingtype/) 및 [EffectChartMinorGroupingType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effectchartminorgroupingtype/)를 사용하여 애니메이션을 적용할 수 있습니다.

## **차트 시리즈 애니메이션**
차트 시리즈에 애니메이션을 적용하려면 아래 단계에 따라 코드를 작성하십시오.

1. 프레젠테이션을 로드합니다.
1. 차트 객체의 참조를 가져옵니다.
1. 시리즈에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예제에서는 차트 시리즈에 애니메이션을 적용했습니다.

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // 차트 객체의 참조를 가져옵니다
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // 시리즈에 애니메이션을 적용합니다
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.save("AnimatingSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **차트 카테고리 애니메이션**
차트 카테고리에 애니메이션을 적용하려면 아래 단계에 따라 코드를 작성하십시오.

1. 프레젠테이션을 로드합니다.
1. 차트 객체의 참조를 가져옵니다.
1. 카테고리에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예제에서는 차트 카테고리에 애니메이션을 적용했습니다.

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    pres.save("Sample_Animation_C.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **시리즈 요소 애니메이션**
시리즈 요소에 애니메이션을 적용하려면 아래 단계에 따라 코드를 작성하십시오.

1. 프레젠테이션을 로드합니다.
1. 차트 객체의 참조를 가져옵니다.
1. 시리즈 요소에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예제에서는 시리즈 요소에 애니메이션을 적용했습니다.

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // 차트 객체의 참조를 가져옵니다
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // 시리즈 요소에 애니메이션을 적용합니다
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // 프레젠테이션 파일을 디스크에 저장합니다
    pres.save("AnimatingSeriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **카테고리 요소 애니메이션**
카테고리 요소에 애니메이션을 적용하려면 아래 단계에 따라 코드를 작성하십시오.

1. 프레젠테이션을 로드합니다.
1. 차트 객체의 참조를 가져옵니다.
1. 카테고리 요소에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

아래 예제에서는 카테고리 요소에 애니메이션을 적용했습니다.

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // 차트 객체의 참조를 가져옵니다
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // 카테고리 요소에 애니메이션을 적용합니다
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // 프레젠테이션 파일을 디스크에 저장합니다
    pres.save("AnimatingCategoriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**차트에도 일반 도형과 마찬가지로 다양한 효과 유형(예: 입장, 강조, 퇴장)이 지원되나요?**

네. 차트는 도형으로 처리되므로 입장, 강조, 퇴장 등 표준 애니메이션 효과 유형을 모두 지원하며, 슬라이드 타임라인 및 애니메이션 시퀀스를 통해 완전한 제어가 가능합니다.

**차트 애니메이션을 슬라이드 전환과 함께 사용할 수 있나요?**

네. [전환](/slides/ko/nodejs-java/slide-transition/)은 슬라이드에 적용되고, 애니메이션 효과는 슬라이드 내 객체에 적용됩니다. 두 기능을 같은 프레젠테이션에서 동시에 사용할 수 있으며 각각 독립적으로 제어할 수 있습니다.

**PPTX로 저장할 때 차트 애니메이션이 유지되나요?**

네. [PPTX에 저장](/slides/ko/nodejs-java/save-presentation/)하면 모든 애니메이션 효과와 순서가 프레젠테이션의 기본 애니메이션 모델에 포함되어 그대로 보존됩니다.

**프레젠테이션에서 기존 차트 애니메이션을 읽고 수정할 수 있나요?**

네. API는 슬라이드 타임라인, 시퀀스 및 효과에 대한 접근을 제공하므로 기존 차트 애니메이션을 검사하고 처음부터 다시 만들 필요 없이 조정할 수 있습니다.

**Aspose.Slides를 사용해 차트 애니메이션이 포함된 비디오를 만들 수 있나요?**

네. [프레젠테이션을 비디오로 내보내기](/slides/ko/nodejs-java/convert-powerpoint-to-video/)를 사용하면 애니메이션을 보존하면서 타이밍 및 기타 내보내기 설정을 구성하여 애니메이션이 적용된 동영상을 생성할 수 있습니다.