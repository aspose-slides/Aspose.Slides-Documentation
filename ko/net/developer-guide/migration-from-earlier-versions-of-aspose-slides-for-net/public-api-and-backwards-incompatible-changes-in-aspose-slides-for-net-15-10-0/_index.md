---
title: Aspose.Slides for .NET 15.10.0의 공개 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 15.10.0
type: docs
weight: 200
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/
keywords:
- 마이그레이션
- 레거시 코드
- 모던 코드
- 레거시 접근 방식
- 모던 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 공개 API 업데이트와 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="primary" %}} 

이 페이지는 Aspose.Slides for .NET 15.10.0 API와 함께 도입된 모든 [added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) 또는 [removed](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) 클래스, 메서드, 속성 등을 나열합니다.

{{% /alert %}} 
## **공용 API 변경 사항**
#### **HTML로 미디어 파일 내보내기를 지원하기 위해 새로운 VideoPlayerHtmlController가 추가되었습니다**
새로운 공개 클래스 VideoPlayerHtmlController가 Aspose.Slides.Export 네임스페이스에 추가되었습니다. 이 클래스의 인스턴스를 사용하면 사용자는 비디오 및 오디오 파일을 HTML로 내보낼 수 있습니다.
VideoPlayerHtmlController 생성자는 다음 매개변수를 받습니다:

path: 비디오 및 오디오 파일이 생성될 경로
fileName: HTML 파일의 이름

baseUri: 링크를 생성하는 데 사용될 기본 URI
사용 예시:

``` csharp

 using (Presentation pres = new Presentation("example.pptx"))

{

    const string path = "path";

    const string fileName = "video.html";

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    pres.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);

}

``` 
#### **차트 시리즈 애니메이션 API가 추가되었습니다**
새로운 2개의 메서드가 Aspose.Slides.Animation.ISequence 인터페이스에 추가되었습니다.

``` csharp

 IEffect AddEffect(IChart chart, EffectChartMajorGroupingType type, int index, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

IEffect AddEffect(IChart chart, EffectChartMinorGroupingType type, int seriesIndex, int categoriesIndex, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

``` 

이 메서드들은 차트 요소 애니메이션을 지원하도록 설계되었습니다:
by series
by categories
by series elements
by categories elements

차트 요소 애니메이션과 관련된 두 개의 새로운 열거형 EffectChartMajorGroupingType와 EffectChartMinorGroupingType이 도입되었습니다.

차트에 시리즈 애니메이션을 추가하려면 다음 코드를 사용할 수 있습니다:

``` csharp

 using (Presentation pres = new Presentation(inFileName))

{

    var slide = pres.Slides[0] as Slide;

    var shapes = slide.Shapes as ShapeCollection;

    var chart = shapes[0] as IChart;

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

    pres.Save(outFileName, SaveFormat.Pptx);

}

``` 

Categories animation:

``` csharp

 using (Presentation pres = new Presentation(inFileName))

{

    var slide = pres.Slides[0] as Slide;

    var shapes = slide.Shapes as ShapeCollection;

    var chart = shapes[0] as IChart;

    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,

        EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMajorGroupingType.ByCategory, 0,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMajorGroupingType.ByCategory, 1,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMajorGroupingType.ByCategory, 2,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMajorGroupingType.ByCategory, 3,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.Save(outFileName, SaveFormat.Pptx);

}

``` 

Series elements animation:

``` csharp

 using (Presentation pres = new Presentation(inFileName))

{

    var slide = pres.Slides[0] as Slide;

    var shapes = slide.Shapes as ShapeCollection;

    var chart = shapes[0] as IChart;

    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,

        EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 0, 0,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 0, 1,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 0, 2,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 0, 3,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 1, 0,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 1, 1,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 1, 2,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 1, 3,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 2, 0,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 2, 1,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 2, 2,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 2, 3,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.Save(outFileName, SaveFormat.Pptx);

}

``` 

Categories elements animation:

``` csharp

 using (Presentation pres = new Presentation(inFileName))

{

    var slide = pres.Slides[0] as Slide;

    var shapes = slide.Shapes as ShapeCollection;

    var chart = shapes[0] as IChart;

    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,

        EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 0, 0,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 0, 1,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 0, 2,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 0, 3,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 1, 0,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 1, 1,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 1, 2,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 1, 3,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 2, 0,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 2, 1,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 2, 2,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 2, 3,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.Save(outFileName, SaveFormat.Pptx);

}

```