---
title: Animeer PowerPoint-grafieken in Python via Java
linktitle: Geanimeerde Grafieken
type: docs
weight: 80
url: /nl/python-java/animated-charts/
keywords:
- grafiek
- geanimeerde grafiek
- grafiekanimatie
- grafiekserie
- grafiekkategorie
- serie-element
- categorie-element
- effect toevoegen
- effecttype
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak verbluffende geanimeerde grafieken in Python via Java met Aspose.Slides. Verhoog presentaties met dynamische visuals in PPT- en PPTX-bestanden - begin nu."
---
## **Introductie**

Aspose.Slides voor Python via Java ondersteunt het animeren van grafiekelementen. **Series**, **Categorieën**, **Series‑elementen** en **Categorie‑elementen** kunnen geanimeerd worden met de [Sequence.addEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sequence/#addEffect)‑methode en twee enumeraties: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effectchartmajorgroupingtype/) en [EffectChartMinorGroupingType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Animatie van grafiekseries**

Als u een grafiekserie wilt animeren, schrijft u de code volgens de onderstaande stappen:

1. Laad een presentatie.  
1. Haal een verwijzing op naar het grafiekobject.  
1. Animeer de serie.  
1. Schrijf het presentatie‑bestand naar schijf.

Het volgende voorbeeld animeert grafiekseries. De grafiek in het voorbeeldbestand heeft drie series, dus wordt voor elke index van 0 tot 2 één effect toegevoegd. Aspose.Slides controleert de index niet tegen de grafiekgegevens; een effect dat wordt toegevoegd voor een serie die niet bestaat, wordt wel in het bestand geschreven maar animeert niets — zorg ervoor dat de index lager is dan het aantal series in uw eigen grafiek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Laad de presentatie.
presentation = Presentation("ExistingChart.pptx")
try:
    # Haal een referentie op naar het grafiekobject.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animeer de grafiekelementen.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Schrijf de gewijzigde presentatie naar schijf.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animatie van grafiekkategorieën**

Als u een grafiekkategorie wilt animeren, schrijft u de code volgens de onderstaande stappen:

1. Laad een presentatie.  
1. Haal een verwijzing op naar het grafiekobject.  
1. Animeer de categorie.  
1. Schrijf het presentatie‑bestand naar schijf.

Het volgende voorbeeld animeert grafiekkategorieën.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Laad de presentatie.
presentation = Presentation("ExistingChart.pptx")
try:
    # Haal een referentie op naar het grafiekobject.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animeer de grafiekelementen.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Schrijf de gewijzigde presentatie naar schijf.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animatie in een serie‑element**

Als u serie‑elementen wilt animeren, schrijft u de code volgens de onderstaande stappen:

1. Laad een presentatie.  
1. Haal een verwijzing op naar het grafiekobject.  
1. Animeer serie‑elementen.  
1. Schrijf het presentatie‑bestand naar schijf.

Het volgende voorbeeld animeert serie‑elementen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Laad de presentatie.
presentation = Presentation("ExistingChart.pptx")
try:
    # Haal een referentie op naar het grafiekobject.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animeer de grafiekelementen.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Schrijf de gewijzigde presentatie naar schijf.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animatie in een categorie‑element**

Als u categorie‑elementen wilt animeren, schrijft u de code volgens de onderstaande stappen:

1. Laad een presentatie.  
1. Haal een verwijzing op naar het grafiekobject.  
1. Animeer categorie‑elementen.  
1. Schrijf het presentatie‑bestand naar schijf.

Het volgende voorbeeld animeert categorie‑elementen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Laad de presentatie.
presentation = Presentation("ExistingChart.pptx")
try:
    # Haal een referentie op naar het grafiekobject.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animeer de grafiekelementen.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Schrijf de gewijzigde presentatie naar schijf.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **FAQ**

**Worden verschillende effecttypen (bijv. entree, nadruk, exit) ondersteund voor grafieken zoals voor gewone vormen?**

Ja. Een grafiek wordt behandeld als een vorm, dus ondersteunt hij de standaard effecttypen, inclusief entree, nadruk en exit, met volledige controle via de tijdlijn van de dia en animaties.

**Kan ik grafiekanimatie combineren met dia‑overgangen?**

Ja. [Overgangen](/slides/nl/python-java/slide-transition/) worden toegepast op de dia, terwijl animatie‑effecten worden toegepast op objecten op de dia. U kunt beide samen in dezelfde presentatie gebruiken en apart besturen.

**Blijven grafiekanimaties behouden bij het opslaan als PPTX?**

Ja. Wanneer u [opslaan als PPTX](/slides/nl/python-java/save-presentation/) kiest, blijven alle animatie‑effecten en hun volgorde behouden omdat ze deel uitmaken van het native animatiemodel van de presentatie.

**Kan ik bestaande grafiekanimaties uit een presentatie lezen en aanpassen?**

Ja. De API biedt toegang tot de tijdlijn van de dia, de reeksen en de effecten, zodat u bestaande grafiekanimaties kunt inspecteren en aanpassen zonder alles opnieuw te moeten maken.

**Kan ik een video maken die grafiekanimaties bevat met Aspose.Slides?**

Ja. U kunt een presentatie [exporteren naar video](/slides/nl/python-java/convert-powerpoint-to-video/) waarbij animaties behouden blijven, met timing‑ en exportinstellingen zodat het resulterende fragment de geanimeerde weergave reflecteert.