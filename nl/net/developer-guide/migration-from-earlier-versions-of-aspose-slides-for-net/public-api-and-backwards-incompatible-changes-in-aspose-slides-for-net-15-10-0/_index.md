---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 15.10.0
linktitle: Aspose.Slides voor .NET 15.10.0
type: docs
weight: 200
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/
keywords:
- migratie
- legacy code
- moderne code
- legacy aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de openbare API-updates en breaking changes in Aspose.Slides voor .NET om uw PowerPoint PPT, PPTX en ODP presentaties soepel te migreren."
---
{{% alert color="info" %}} 

Deze pagina geeft een overzicht van alle [added](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) of [removed](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for .NET 15.10.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **A New VideoPlayerHtmlController Added to Support Export Media Files to HTML**
De nieuwe publieke klasse VideoPlayerHtmlController is toegevoegd aan de namespace Aspose.Slides.Export. Met een instantie van deze klasse kan de gebruiker video- en audiobestanden exporteren naar HTML.  
VideoPlayerHtmlController constructeurs accepteren de volgende parameters:

path: Het pad waar de video- en audiobestanden worden gegenereerd  
fileName: De naam van het HTML‑bestand  

baseUri: De basis‑URI die gebruikt wordt om links te genereren  
Voorbeeld van gebruik:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


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
De twee nieuwe methoden zijn toegevoegd aan de interface Aspose.Slides.Animation.ISequence.

``` csharp
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;


 IEffect AddEffect(IChart chart, EffectChartMajorGroupingType type, int index, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

IEffect AddEffect(IChart chart, EffectChartMinorGroupingType type, int seriesIndex, int categoriesIndex, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

``` 

Deze methoden zijn bedoeld om de animaties van chart‑elementen te ondersteunen:
by series
by categories
by series elements
by categories elements

De twee nieuwe enumeraties EffectChartMajorGroupingType en EffectChartMinorGroupingType, gerelateerd aan de animatie van chart‑elementen, zijn geïntroduceerd.

Om een serie‑animatie aan de chart toe te voegen kan de volgende code worden gebruikt:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

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

Animatie van categorieën:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

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

Animatie van serie‑elementen:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

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

Animatie van categorie‑elementen:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

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