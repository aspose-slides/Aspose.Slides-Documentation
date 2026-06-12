---
title: Animeer PowerPoint-diagrammen in JavaScript
linktitle: Geanimeerde diagrammen
type: docs
weight: 80
url: /nl/nodejs-java/animated-charts/
keywords:
- diagram
- geanimeerd diagram
- diagramanimatie
- diagramreeks
- diagramcategorie
- reeks-element
- categorie-element
- effect toevoegen
- effecttype
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak verbluffende geanimeerde diagrammen in JavaScript met Aspose.Slides voor Node.js. Versterk presentaties met dynamische visuals in PPT- en PPTX-bestanden — begin nu."
---
## **Introductie**

Aspose.Slides for Node.js via Java ondersteunt het animeren van chart‑elementen. **Series**, **Categorieën**, **Series‑elementen**, **Categorie‑elementen** kunnen geanimeerd worden met de methode [Sequence.addEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#addEffect) en de twee enumeraties [EffectChartMajorGroupingType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effectchartmajorgroupingtype/) en [EffectChartMinorGroupingType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effectchartminorgroupingtype/).

## **Chart‑series animatie**
Als u een chart‑serie wilt animeren, schrijft u de code volgens de onderstaande stappen:

1. Laad een presentatie.  
1. Verkrijg een referentie naar het chart‑object.  
1. Animeer de serie.  
1. Schrijf het presentatie‑bestand naar schijf.

In het onderstaande voorbeeld hebben we chart‑series geanimeerd.

```javascript
// Instantieer de Presentation‑klasse die een presentatie‑bestand voorstelt
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Verkrijg een referentie naar het chart‑object
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animeer de serie
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Schrijf de aangepaste presentatie naar schijf
    pres.save("AnimatingSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Chart‑categorie animatie**
Als u een chart‑categorie wilt animeren, schrijft u de code volgens de onderstaande stappen:

1. Laad een presentatie.  
1. Verkrijg een referentie naar het chart‑object.  
1. Animeer de categorie.  
1. Schrijf het presentatie‑bestand naar schijf.

In het onderstaande voorbeeld hebben we chart‑categorieën geanimeerd.

```javascript
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt
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

## **Animatie in serie‑element**
Als u serie‑elementen wilt animeren, schrijft u de code volgens de onderstaande stappen:

1. Laad een presentatie.  
1. Verkrijg een referentie naar het chart‑object.  
1. Animeer serie‑elementen.  
1. Schrijf het presentatie‑bestand naar schijf.

In het onderstaande voorbeeld hebben we serie‑elementen geanimeerd.

```javascript
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Verkrijg een referentie naar het chart-object
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animeer serie-elementen
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
    // Schrijf het presentatiebestand naar schijf
    pres.save("AnimatingSeriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animatie in categorie‑element**
Als u categorie‑elementen wilt animeren, schrijft u de code volgens de onderstaande stappen:

1. Laad een presentatie.  
1. Verkrijg een referentie naar het chart‑object.  
1. Animeer categorie‑elementen.  
1. Schrijf het presentatie‑bestand naar schijf.

In het onderstaande voorbeeld hebben we categorie‑elementen geanimeerd.

```javascript
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Verkrijg een referentie naar het chart-object
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animeer categorie-elementen
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
    // Schrijf het presentatiebestand naar schijf
    pres.save("AnimatingCategoriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Worden verschillende effecttypen (bijv. binnenkomst, nadruk, uitgang) ondersteund voor charts zoals voor gewone vormen?**

Ja. Een chart wordt behandeld als een vorm, dus hij ondersteunt de standaardanimatie‑effecttypen, inclusief binnenkomst, nadruk en uitgang, met volledige controle via de tijdlijn en animatiesequenties van de dia.

**Kan ik chart‑animatie combineren met dia‑overgangen?**

Ja. [Transitions](/slides/nl/nodejs-java/slide-transition/) worden toegepast op de dia, terwijl animatie‑effecten worden toegepast op objecten op de dia. U kunt beide samen in dezelfde presentatie gebruiken en onafhankelijk beheren.

**Worden chart‑animaties behouden bij het opslaan naar PPTX?**

Ja. Wanneer u [save to PPTX](/slides/nl/nodejs-java/save-presentation/) gebruikt, blijven alle animatie‑effecten en hun volgorde behouden omdat ze deel uitmaken van het native animatiemodel van de presentatie.

**Kan ik bestaande chart‑animaties uit een presentatie lezen en aanpassen?**

Ja. De API geeft toegang tot de tijdlijn van de dia, sequenties en effecten, zodat u bestaande chart‑animaties kunt inspecteren en aanpassen zonder alles opnieuw te moeten maken.

**Kan ik een video produceren die chart‑animaties bevat met Aspose.Slides?**

Ja. U kunt een presentatie [export to video](/slides/nl/nodejs-java/convert-powerpoint-to-video/) terwijl u de animaties behoudt, de timing en andere exportinstellingen configureert, zodat het resulterende fragment de geanimeerde weergave weerspiegelt.