---
title: "PowerPoint-diagrammen animeren in .NET"
linktitle: "Geanimeerde diagrammen"
type: docs
weight: 80
url: /nl/net/animated-charts/
keywords:
- diagram
- geanimeerd diagram
- diagramanimatie
- diagramreeks
- diagramcategorie
- reeks element
- categorie-element
- effect toevoegen
- effecttype
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak verbluffende geanimeerde diagrammen in .NET met Aspose.Slides. Versterk presentaties met dynamische visuals in PPT- en PPTX-bestanden—begin nu."
---
## **Inleiding**

Aspose.Slides for .NET ondersteunt het animeren van de grafiekelementen. **Series**, **Categorieën**, **Serieselementen**, **Categorie‑elementen** kunnen geanimeerd worden met de [ISequence.AddEffect](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/isequence/methods/addeffect)‑methode en twee enumeraties [EffectChartMajorGroupingType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effectchartmajorgroupingtype) en [EffectChartMinorGroupingType](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/effectchartminorgroupingtype).

## **Animatie van grafiekseries**
Als je een grafiekserie wilt animeren, schrijf je de code volgens de onderstaande stappen:

1. Laad een presentatie.  
1. Verkrijg een referentie naar het grafiekobject.  
1. Animeer de series.  
1. Schrijf het presentatie‑bestand naar de schijf.

In het onderstaande voorbeeld hebben we een grafiekserie geanimeerd.

```c#
// Instantieer de Presentation‑klasse die een presentatiebestand representeert 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Haal referentie naar het grafiekobject op
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animeer de series
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

    // Schrijf de gewijzigde presentatie naar schijf 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```

## **Animatie van grafiekcategorie**
Als je een grafiekcategorie wilt animeren, schrijf je de code volgens de onderstaande stappen:

1. Laad een presentatie.  
1. Verkrijg een referentie naar het grafiekobject.  
1. Animeer de categorie.  
1. Schrijf het presentatie‑bestand naar de schijf.

In het onderstaande voorbeeld hebben we een grafiekcategorie geanimeerd.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Haal referentie naar het grafiekobject op
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animeer elementen van de categorieën
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

    // Schrijf het presentatie‑bestand naar schijf
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Animatie in een serieselement**
Als je serieselementen wilt animeren, schrijf je de code volgens de onderstaande stappen:

1. Laad een presentatie.  
1. Verkrijg een referentie naar het grafiekobject.  
1. Animeer serieselementen.  
1. Schrijf het presentatie‑bestand naar de schijf.

In het onderstaande voorbeeld hebben we serieselementen geanimeerd.

```c#
// Laad een presentatie
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Haal referentie naar het grafiekobject op
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animeer serieselementen
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

    // Schrijf het presentatie-bestand naar schijf 
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Animatie in een categorie‑element**
Als je categorie‑elementen wilt animeren, schrijf je de code volgens de onderstaande stappen:

1. Laad een presentatie.  
1. Verkrijg een referentie naar het grafiekobject.  
1. Animeer categorie‑elementen.  
1. Schrijf het presentatie‑bestand naar de schijf.

In het onderstaande voorbeeld hebben we categorie‑elementen geanimeerd.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Haal referentie naar het grafiekobject op
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animeer elementen van de categorieën
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

    // Schrijf het presentatie‑bestand naar schijf
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Veelgestelde vragen**

**Wordt voor grafieken, net als voor gewone vormen, ondersteuning geboden voor verschillende effecttypen (bijv. intrede, nadruk, vertrek)?**

Ja. Een grafiek wordt behandeld als een vorm, dus ondersteunt het de standaard animatie‑effecttypen, inclusief intrede, nadruk en vertrek, met volledige controle via de tijdlijn van de dia en de animatiesequenties.

**Kan ik grafiekanimatie combineren met dia‑overgangen?**

Ja. [Overgangen](/slides/nl/net/slide-transition/) worden toegepast op de dia, terwijl animatie‑effecten worden toegepast op objecten op de dia. Je kunt beide samen in dezelfde presentatie gebruiken en ze onafhankelijk van elkaar beheersen.

**Worden grafiekanimaties behouden bij het opslaan naar PPTX?**

Ja. Wanneer je [opslaan naar PPTX](/slides/nl/net/save-presentation/), worden alle animatie‑effecten en hun volgorde behouden omdat ze deel uitmaken van het native animatiemodel van de presentatie.

**Kan ik bestaande grafiekanimaties uit een presentatie lezen en aanpassen?**

Ja. De [API](https://reference.aspose.com/slides/nl/net/aspose.slides.animation/) biedt toegang tot de tijdlijn van de dia, sequenties en effecten, waardoor je bestaande grafiekanimaties kunt inspecteren en aanpassen zonder alles opnieuw te moeten creëren.

**Kan ik een video maken die grafiekanimaties bevat met Aspose.Slides?**

Ja. Je kunt een presentatie [exporteren naar video](/slides/nl/net/convert-powerpoint-to-video/) terwijl je animaties behoudt, timing en andere exportinstellingen configureren zodat de resulterende clip de geanimeerde weergave weerspiegelt.