---
title: Animera PowerPoint-diagram i Python via Java
linktitle: Animerade diagram
type: docs
weight: 80
url: /sv/python-java/animated-charts/
keywords:
- diagram
- animerat diagram
- diagramanimation
- diagramserie
- diagramkategori
- serieelement
- kategorielement
- lägg till effekt
- effekttyp
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Skapa imponerande animerade diagram i Python via Java med Aspose.Slides. Förbättra presentationer med dynamiska visuella element i PPT- och PPTX-filer—kom igång nu."
---
## **Introduktion**

Aspose.Slides för Python via Java stöder animering av diagramelement. **Serier**, **Kategorier**, **Serieelement** och **Kategorielement** kan animeras med hjälp av metoden [Sequence.addEffect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sequence/#addEffect) och två uppräkningar: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effectchartmajorgroupingtype/) och [EffectChartMinorGroupingType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Animation av diagramserier**

Om du vill animera en diagramserie, skriv koden enligt stegen som listas nedan:

1. Läs in en presentation.
1. Hämta en referens till diagramobjektet.
1. Animera serien.
1. Spara presentationsfilen till disk.

Följande exempel animera diagramserier. Diagrammet i exempelfilen har tre serier, så en effekt läggs till för varje index från 0 till 2. Aspose.Slides kontrollerar inte indexet mot diagramdata, och en effekt som läggs till för en serie som inte finns skrivs till filen men animerar inget – håll indexet under antalet serier i ditt eget diagram.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Ladda presentationen.
presentation = Presentation("ExistingChart.pptx")
try:
    # Hämta en referens till diagramobjektet.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animera diagrammets element.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Skriv den modifierade presentationen till disk.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animation av diagramkategorier**

Om du vill animera en diagramkategori, skriv koden enligt stegen som listas nedan:

1. Läs in en presentation.
1. Hämta en referens till diagramobjektet.
1. Animera kategorin.
1. Spara presentationsfilen till disk.

Följande exempel animera diagramkategorier.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Ladda presentationen.
presentation = Presentation("ExistingChart.pptx")
try:
    # Hämta en referens till diagramobjektet.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animera diagrammets element.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Skriv den modifierade presentationen till disk.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animation i ett serieelement**

Om du vill animera serieelement, skriv koden enligt stegen som listas nedan:

1. Läs in en presentation.
1. Hämta en referens till diagramobjektet.
1. Animera serieelement.
1. Spara presentationsfilen till disk.

Följande exempel animera serieelement.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Ladda presentationen.
presentation = Presentation("ExistingChart.pptx")
try:
    # Hämta en referens till diagramobjektet.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animera diagrammets element.
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

    # Skriv den modifierade presentationen till disk.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animation i ett kategorielement**

Om du vill animera kategorielement, skriv koden enligt stegen som listas nedan:

1. Läs in en presentation.
1. Hämta en referens till diagramobjektet.
1. Animera kategorielement.
1. Spara presentationsfilen till disk.

Följande exempel animera kategorielement.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Ladda presentationen.
presentation = Presentation("ExistingChart.pptx")
try:
    # Hämta en referens till diagramobjektet.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animera diagrammets element.
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

    # Skriv den modifierade presentationen till disk.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Stöds olika effekttyper (t.ex. inträde, betoning, avslut) för diagram på samma sätt som för vanliga former?**

Ja. Ett diagram behandlas som en form, så det stöder de vanliga animationseffekttyperna, inklusive inträde, betoning och avslut, med full kontroll via bildens tidslinje och animationssekvenser.

**Kan jag kombinera diagramanimation med bildövergångar?**

Ja. [Transitions](/slides/sv/python-java/slide-transition/) gäller för bilden, medan animationseffekter gäller för objekt på bilden. Du kan använda båda tillsammans i samma presentation och kontrollera dem oberoende.

**Bevaras diagramanimationer när man sparar som PPTX?**

Ja. När du [spara som PPTX](/slides/sv/python-java/save-presentation/), bevaras alla animationseffekter och deras ordning eftersom de är en del av presentationens inbyggda animationsmodell.

**Kan jag läsa befintliga diagramanimationer från en presentation och ändra dem?**

Ja. API:et ger åtkomst till bildens tidslinje, sekvenser och effekter, vilket gör att du kan granska befintliga diagramanimationer och justera dem utan att skapa om allt från början.

**Kan jag skapa en video som inkluderar diagramanimationer med Aspose.Slides?**

Ja. Du kan [exportera en presentation till video](/slides/sv/python-java/convert-powerpoint-to-video/) samtidigt som du bevarar animationerna, konfigurerar tidsinställningar och andra exportalternativ så att den resulterande videon återger den animerade uppspelningen.