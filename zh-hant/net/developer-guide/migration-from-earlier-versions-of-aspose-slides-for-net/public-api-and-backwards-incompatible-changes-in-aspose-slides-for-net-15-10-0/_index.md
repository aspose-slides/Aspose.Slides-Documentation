---
title: Aspose.Slides for .NET 15.10.0 的公用 API 與向後不相容變更
linktitle: Aspose.Slides for .NET 15.10.0
type: docs
weight: 200
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢視 Aspose.Slides for .NET 的公用 API 更新與破壞性變更，以順利將您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案遷移。"
---
{{% alert color="primary" %}} 
此頁面列出所有已新增或已移除的類別、方法、屬性等，及 Aspose.Slides for .NET 15.10.0 API 所引入的其他變更。
{{% /alert %}} 
## **Public API Changes**
#### **A New VideoPlayerHtmlController Added to Support Export Media Files to HTML**
已在 Aspose.Slides.Export 命名空間中新增公用類別 VideoPlayerHtmlController。使用此類別的實例，使用者可將視訊與音訊檔案匯出為 HTML。  
VideoPlayerHtmlController 建構函式接受以下參數：

path: 產生視訊與音訊檔案的路徑  
fileName: HTML 檔案的名稱  

baseUri: 用於產生連結的基礎 URI  
使用範例：

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
#### **Chart Series Animation API Has Been Added**
已在 Aspose.Slides.Animation.ISequence 介面中新增了兩個方法。

``` csharp

 IEffect AddEffect(IChart chart, EffectChartMajorGroupingType type, int index, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

IEffect AddEffect(IChart chart, EffectChartMinorGroupingType type, int seriesIndex, int categoriesIndex, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

``` 

這些方法旨在支援圖表元素的動畫效果：
by series  
by categories  
by series elements  
by categories elements  

已引入兩個新列舉 EffectChartMajorGroupingType 與 EffectChartMinorGroupingType，與圖表元素動畫相關。

若要為圖表新增系列動畫，可使用以下程式碼：

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