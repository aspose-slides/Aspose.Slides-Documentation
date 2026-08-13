---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 15.10.0
linktitle: Aspose.Slides pro .NET 15.10.0
type: docs
weight: 200
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte aktualizace veřejného API a přerušené změny v Aspose.Slides pro .NET, abyste hladce migrovali své řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidány](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) nebo [odebrány](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) třídy, metody, vlastnosti a podobně, a další změny zavedené v API Aspose.Slides pro .NET 15.10.0.

{{% /alert %}} 
## **Změny veřejného API**
#### **Nový VideoPlayerHtmlController přidán pro podporu exportu mediálních souborů do HTML**
Nová veřejná třída VideoPlayerHtmlController byla přidána do jmenného prostoru Aspose.Slides.Export. Pomocí instance této třídy může uživatel exportovat video a audio soubory do HTML.
Konstruktory VideoPlayerHtmlController přijímají následující parametry:

path: Cesta, kde budou generovány video a audio soubory  
fileName: Název souboru HTML  

baseUri: Základní URI, které bude použito pro generování odkazů  
Příklad použití:

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
#### **API animace řad grafu bylo přidáno**
Do rozhraní Aspose.Slides.Animation.ISequence byly přidány nové 2 metody.

``` csharp
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;


 IEffect AddEffect(IChart chart, EffectChartMajorGroupingType type, int index, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

IEffect AddEffect(IChart chart, EffectChartMinorGroupingType type, int seriesIndex, int categoriesIndex, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

``` 

Tyto metody jsou určeny k podpoře animací prvků grafu:
podle řad
podle kategorií
prvky řad
prvky kategorií

Byly zavedeny dva nové výčty EffectChartMajorGroupingType a EffectChartMinorGroupingType související s animací prvků grafu.

Pro přidání animace řady do grafu může být použit následující kód:

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

Animace kategorií:

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

Animace prvků řad:

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

Animace prvků kategorií:

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