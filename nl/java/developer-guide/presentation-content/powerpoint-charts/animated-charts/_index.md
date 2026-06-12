---
title: Animeer PowerPoint-grafieken in Java
linktitle: Geanimeerde grafieken
type: docs
weight: 80
url: /nl/java/animated-charts/
keywords:
- grafiek
- geanimeerde grafiek
- grafiekanimatie
- grafiekserie
- grafiekcategorie
- serie‑element
- categorie‑element
- effect toevoegen
- effecttype
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Maak verbluffende geanimeerde grafieken in Java met Aspose.Slides. Versterk presentaties met dynamische visuals in PPT‑ en PPTX‑bestanden—begin nu."
---
## **Inleiding**

Aspose.Slides for Java ondersteunt het animeren van de grafiekelementen. **Series**, **Categorieën**, **Series‑elementen**, **Categorie‑elementen** kunnen geanimeerd worden met de methode [ISequence.addEffect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) en twee enumeraties [EffectChartMajorGroupingType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/EffectChartMajorGroupingType) en [EffectChartMinorGroupingType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/EffectChartMinorGroupingType).

## **Animatie van grafiekseries**

Als u een grafiekserie wilt animeren, schrijft u de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Haal de referentie naar het grafiekobject op.
1. Animeer de serie.
1. Schrijf het presentatie‑bestand naar de schijf.

In het onderstaande voorbeeld hebben we een grafiekserie geanimeerd.

```java
// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Haal referentie naar het grafiekobject op
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animeer de serie
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

    // Schrijf de gewijzigde presentatie naar de schijf
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animatie van grafiekcategorieën**

Als u een grafiekcategorie wilt animeren, schrijft u de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Haal de referentie naar het grafiekobject op.
1. Animeer de categorie.
1. Schrijf het presentatie‑bestand naar de schijf.

In het onderstaande voorbeeld hebben we een grafiekcategorie geanimeerd.

```java
// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt
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

## **Animatie in een series‑element**

Als u series‑elementen wilt animeren, schrijft u de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Haal de referentie naar het grafiekobject op.
1. Animeer series‑elementen.
1. Schrijf het presentatie‑bestand naar de schijf.

In het onderstaande voorbeeld hebben we series‑elementen geanimeerd.

```java
// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Haal referentie naar het grafiekobject op
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

    // Schrijf het presentatie‑bestand naar de schijf 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animatie in een categorie‑element**

Als u categorie‑elementen wilt animeren, schrijft u de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Haal de referentie naar het grafiekobject op.
1. Animeer categorie‑elementen.
1. Schrijf het presentatie‑bestand naar de schijf.

In het onderstaande voorbeeld hebben we categorie‑elementen geanimeerd.

```java
// Instantieer de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Haal referentie naar het grafiekobject op
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animeer elementen van categorieën
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.No
ne, EffectTriggerType.AfterPrevious);
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

    // Schrijf het presentatie‑bestand naar de schijf
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Worden verschillende effecttypen (bijv. binnenkomst, nadruk, uitgang) ondersteund voor grafieken zoals voor gewone vormen?**

Ja. Een grafiek wordt behandeld als een vorm, dus ondersteunt het de standaard animatie‑effecttypen, inclusief binnenkomst, nadruk en uitgang, met volledige controle via de tijdlijn van de dia en animatiesequenties.

**Kan ik grafiekanimatie combineren met dia‑overgangen?**

Ja. [Transitions](/slides/nl/java/slide-transition/) gelden voor de dia, terwijl animatie‑effecten gelden voor objecten op de dia. U kunt beide samen in dezelfde presentatie gebruiken en ze onafhankelijk van elkaar regelen.

**Worden grafiekanimaties behouden bij opslaan naar PPTX?**

Ja. Wanneer u [opslaat naar PPTX](/slides/nl/java/save-presentation/), blijven alle animatie‑effecten en hun volgorde behouden, omdat ze deel uitmaken van het native animatiemodel van de presentatie.

**Kan ik bestaande grafiekanimaties uit een presentatie lezen en aanpassen?**

Ja. De API biedt toegang tot de dia‑tijdlijn, sequenties en effecten, zodat u bestaande grafiekanimaties kunt bekijken en aanpassen zonder alles vanaf nul opnieuw te maken.

**Kan ik een video maken die grafiekanimaties bevat met Aspose.Slides?**

Ja. U kunt een presentatie [exporteren naar video](/slides/nl/java/convert-powerpoint-to-video/) terwijl u de animaties behoudt, de timing en andere exportinstellingen configureert, zodat het resulterende fragment de geanimeerde weergave weerspiegelt.