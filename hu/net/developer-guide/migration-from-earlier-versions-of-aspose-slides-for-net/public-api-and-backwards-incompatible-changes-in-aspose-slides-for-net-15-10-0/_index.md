---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 15.10.0-ban
linktitle: Aspose.Slides for .NET 15.10.0
type: docs
weight: 200
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for .NET nyilvános API frissítéseit és törő változásait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) osztályt, metódust, tulajdonságot stb., valamint az Aspose.Slides for .NET 15.10.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Publikus API változások**
#### **Új VideoPlayerHtmlController hozzáadva a médiafájlok HTML-be exportálásának támogatásához**
Az új publikus VideoPlayerHtmlController osztály hozzá lett adva az Aspose.Slides.Export névtérhez. Az osztály példányának használatával a felhasználó videó- és hangfájlokat exportálhat HTML-be.
A VideoPlayerHtmlController konstruktora a következő paramétereket fogadja:

path: Az útvonal, ahová a videó- és hangfájlok létrejönnek
fileName: A HTML fájl neve

baseUri: Az alap URI, amely a hivatkozások generálásához lesz használva
Használati példa:

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
#### **Diagram sorozat animáció API hozzáadva**
Az új 2 metódus lett hozzáadva az Aspose.Slides.Animation.ISequence interfészhez.

``` csharp

 IEffect AddEffect(IChart chart, EffectChartMajorGroupingType type, int index, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);
IEffect AddEffect(IChart chart, EffectChartMinorGroupingType type, int seriesIndex, int categoriesIndex, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);
``` 

Ezek a metódusok a diagram elemeinek animációját támogatják:
sorozatonként
kategóriánként
sorozat elemek szerint
kategória elemek szerint

A diagramelemek animációjához kapcsolódó két új enum, az EffectChartMajorGroupingType és az EffectChartMinorGroupingType került bevezetésre.

A sorozat animáció hozzáadásához a diagramhoz a következő kód használható:

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

Kategória animáció:

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

Sorozat elemek animációja:

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

Kategória elemek animációja:

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