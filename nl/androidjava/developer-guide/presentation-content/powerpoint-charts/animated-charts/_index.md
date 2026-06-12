---
title: "Animeer PowerPoint-diagrammen op Android"
linktitle: "Geanimeerde diagrammen"
type: docs
weight: 80
url: /nl/androidjava/animated-charts/
keywords:
- diagram
- geanimeerd diagram
- diagramanimatie
- diagramreeks
- diagramcategorie
- reeks element
- categorie element
- effect toevoegen
- effecttype
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak verbluffende geanimeerde diagrammen in Java met Aspose.Slides for Android. Verhoog presentaties met dynamische visuals in PPT- en PPTX-bestanden—begin nu."
---
## **Introductie**

Aspose.Slides for Android via Java ondersteunt het animeren van de diagramonderdelen. **Series**, **Categories**, **Series Elements**, **Categories Elements** kunnen worden geanimeerd met de methode [ISequence.addEffect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) en twee enumeraties [EffectChartMajorGroupingType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/EffectChartMajorGroupingType) en [EffectChartMinorGroupingType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/EffectChartMinorGroupingType).

## **Grafiekreeksanimatie**
Als je een grafiekreeks wilt animeren, schrijf de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Haal een referentie op naar het diagramobject.
1. Animeer de reeks.
1. Schrijf het presentatiebestand naar schijf.

In het onderstaande voorbeeld hebben we de grafiekreeks geanimeerd.

```java
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Haal referentie van het diagramobject op
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animeer de reeks
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

    // Schrijf de gewijzigde presentatie naar schijf
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Grafiekcategorieanimatie**
Als je een grafiekcategorie wilt animeren, schrijf de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Haal een referentie op naar het diagramobject.
1. Animeer de categorie.
1. Schrijf het presentatiebestand naar schijf.

In het onderstaande voorbeeld hebben we de grafiekcategorie geanimeerd.

```java
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
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

## **Animatie in een serieselement**
Als je series‑elementen wilt animeren, schrijf de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Haal een referentie op naar het diagramobject.
1. Animeer series‑elementen.
1. Schrijf het presentatiebestand naar schijf.

In het onderstaande voorbeeld hebben we series‑elementen geanimeerd.

```java
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Haal referentie van het diagramobject op
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animeer series‑elementen
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

    // Schrijf het presentatiebestand naar schijf 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animatie in een categorie‑element**
Als je categorie‑elementen wilt animeren, schrijf de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Haal een referentie op naar het diagramobject.
1. Animeer categorie‑elementen.
1. Schrijf het presentatiebestand naar schijf.

In het onderstaande voorbeeld hebben we categorie‑elementen geanimeerd.

```java
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Haal referentie van het diagramobject op
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animeer elementen van categorieën
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

    // Schrijf het presentatiebestand naar schijf
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Worden verschillende effecttypen (bijv. intrede, nadruk, uitgang) ondersteund voor diagrammen zoals voor reguliere vormen?**

Ja. Een diagram wordt behandeld als een vorm, dus het ondersteunt de standaard animatie‑effecttypen, inclusief intrede, nadruk en uitgang, met volledige controle via de tijdlijn van de dia en animatiesequenties.

**Kan ik diagramanimatie combineren met dia‑overgangen?**

Ja. [Transitions](/slides/nl/androidjava/slide-transition/) zijn van toepassing op de dia, terwijl animatie‑effecten van toepassing zijn op objecten op de dia. Je kunt beide samen gebruiken in dezelfde presentatie en ze onafhankelijk van elkaar beheersen.

**Worden diagramanimaties behouden bij het opslaan als PPTX?**

Ja. Wanneer je [save to PPTX](/slides/nl/androidjava/save-presentation/) gebruikt, worden alle animatie‑effecten en hun volgorde behouden omdat ze deel uitmaken van het native animatiemodel van de presentatie.

**Kan ik bestaande diagramanimaties uit een presentatie lezen en aanpassen?**

Ja. De API biedt toegang tot de tijdlijn van de dia, sequenties en effecten, zodat je bestaande diagramanimaties kunt inspecteren en aanpassen zonder alles van nul af aan opnieuw te maken.

**Kan ik met Aspose.Slides een video maken die diagramanimaties bevat?**

Ja. Je kunt een presentatie [export a presentation to video](/slides/nl/androidjava/convert-powerpoint-to-video/) exporteren naar video terwijl je de animaties behoudt, de timing en andere exportinstellingen configureert zodat het resulterende fragment de geanimeerde weergave weerspiegelt.