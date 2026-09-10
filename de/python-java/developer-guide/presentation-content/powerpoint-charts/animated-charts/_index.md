---
title: "PowerPoint-Diagramme in Python via Java animieren"
linktitle: "Animierte Diagramme"
type: docs
weight: 80
url: /de/python-java/animated-charts/
keywords:
- Diagramm
- animiertes Diagramm
- Diagramm-Animation
- Diagrammserie
- Diagrammkategorie
- Serienelement
- Kategorienelement
- Effekt hinzufügen
- Effekttyp
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erstellen Sie atemberaubende animierte Diagramme in Python via Java mit Aspose.Slides. Steigern Sie Präsentationen mit dynamischen Visualisierungen in PPT- und PPTX-Dateien - starten Sie jetzt."
---
## **Einleitung**

Aspose.Slides für Python via Java unterstützt die Animation von Diagrammelementen. **Series**, **Categories**, **Series Elements** und **Category Elements** können mit der Methode [Sequence.addEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/sequence/#addEffect) und den beiden Aufzählungen [EffectChartMajorGroupingType](https://reference.aspose.com/slides/de/python-java/aspose.slides/effectchartmajorgroupingtype/) und [EffectChartMinorGroupingType](https://reference.aspose.com/slides/de/python-java/aspose.slides/effectchartminorgroupingtype/) animiert werden.

## **Diagrammserien-Animation**

Wenn Sie eine Diagrammserie animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie eine Referenz auf das Diagrammobjekt.
1. Animieren Sie die Serie.
1. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Das folgende Beispiel animiert Diagrammserien. Das Diagramm in der Beispieldatei enthält drei Serien, sodass für jeden Index von 0 bis 2 ein Effekt hinzugefügt wird. Aspose.Slides prüft den Index nicht gegen die Diagrammdaten, und ein für eine nicht vorhandene Serie hinzugefügter Effekt wird in die Datei geschrieben, animiert jedoch nichts — halten Sie den Index unter der Serienanzahl Ihres eigenen Diagramms.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Laden Sie die Präsentation.
presentation = Presentation("ExistingChart.pptx")
try:
    # Eine Referenz auf das Diagrammobjekt erhalten.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Die Diagrammelemente animieren.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Die modifizierte Präsentation auf die Festplatte schreiben.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Diagrammkategorie-Animation**

Wenn Sie eine Diagrammkategorie animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie eine Referenz auf das Diagrammobjekt.
1. Animieren Sie die Kategorie.
1. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Das folgende Beispiel animiert Diagrammkategorien.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpact.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Laden Sie die Präsentation.
presentation = Presentation("ExistingChart.pptx")
try:
    # Eine Referenz auf das Diagrammobjekt erhalten.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Die Diagrammelemente animieren.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Die modifizierte Präsentation auf die Festplatte schreiben.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animation in einem Serien-Element**

Wenn Sie Serien‑Elemente animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie eine Referenz auf das Diagrammobjekt.
1. Animieren Sie Serien‑Elemente.
1. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Das folgende Beispiel animiert Serien‑Elemente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Laden Sie die Präsentation.
presentation = Presentation("ExistingChart.pptx")
try:
    # Eine Referenz auf das Diagrammobjekt erhalten.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Die Diagrammelemente animieren.
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

    # Die modifizierte Präsentation auf die Festplatte schreiben.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animation in einem Kategorie‑Element**

Wenn Sie Kategorie‑Elemente animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie eine Referenz auf das Diagrammobjekt.
1. Animieren Sie Kategorie‑Elemente.
1. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Das folgende Beispiel animiert Kategorie‑Elemente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Präsentation laden.
presentation = Presentation("ExistingChart.pptx")
try:
    # Eine Referenz auf das Diagrammobjekt erhalten.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Die Diagrammelemente animieren.
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

    # Die modifizierte Präsentation auf die Festplatte schreiben.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Werden verschiedene Effektarten (z. B. Eintritt, Betonung, Ausgang) für Diagramme wie für reguläre Formen unterstützt?**

Ja. Ein Diagramm wird als Form behandelt, sodass es die Standard‑Animationseffektarten unterstützt, einschließlich Eintritt, Betonung und Ausgang, mit voller Kontrolle über die Zeitleiste und Animationssequenzen der Folie.

**Kann ich Diagramm‑Animationen mit Folienübergängen kombinieren?**

Ja. [Transitions](/slides/de/python-java/slide-transition/) gelten für die Folie, während Animations­effekte für Objekte auf der Folie gelten. Sie können beides in derselben Präsentation verwenden und unabhängig steuern.

**Werden Diagramm‑Animationen beim Speichern im PPTX‑Format beibehalten?**

Ja. Beim [save to PPTX](/slides/de/python-java/save-presentation/) werden alle Animations­effekte und deren Reihenfolge beibehalten, da sie Teil des nativen Animationsmodells der Präsentation sind.

**Kann ich vorhandene Diagramm‑Animationen aus einer Präsentation auslesen und ändern?**

Ja. Die API bietet Zugriff auf die Folien‑Zeitleiste, Sequenzen und Effekte, sodass Sie bestehende Diagramm‑Animationen inspizieren und anpassen können, ohne alles neu zu erstellen.

**Kann ich ein Video erzeugen, das Diagramm‑Animationen mit Aspose.Slides enthält?**

Ja. Sie können eine Präsentation [to video exportieren](/slides/de/python-java/convert-powerpoint-to-video/), wobei die Animationen erhalten bleiben. Durch Konfiguration von Zeit­abfolgen und anderen Exporteinstellungen wird das Ergebnis die animierte Wiedergabe widerspiegeln.