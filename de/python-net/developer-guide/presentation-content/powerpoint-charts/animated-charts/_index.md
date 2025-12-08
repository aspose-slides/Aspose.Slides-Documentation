---
title: PowerPoint-Diagramme in Python animieren
linktitle: Animierte Diagramme
type: docs
weight: 80
url: /de/python-net/animated-charts/
keywords:
- Diagramm
- animiertes Diagramm
- Diagrammanimation
- Diagrammserie
- Diagrammkategorie
- Serien-Element
- Kategorien-Element
- Effekt hinzufügen
- Effektart
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen Sie atemberaubende animierte Diagramme in Python mit Aspose.Slides. Verbessern Sie Präsentationen mit dynamischen Visualisierungen in PPT-, PPTX- und ODP-Dateien - starten Sie jetzt."
---

Aspose.Slides für Python via .NET unterstützt die Animation von Diagrammelementen. **Series**, **Categories**, **Series Elements**, **Categories Elements** können mit der Methode [**ISequence**.**AddEffect**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/isequence/) und zwei Enums [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effectchartmajorgroupingtype/) und [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effectchartminorgroupingtype/) animiert werden.
## **Diagrammserien-Animation**
Wenn Sie eine Diagrammserie animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie die Referenz des Diagrammobjekts.
1. Animieren Sie die Serie.
1. Speichern Sie die Präsentationsdatei auf der Festplatte.

Im nachstehenden Beispiel haben wir die Diagrammserie animiert.
```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Instanziiere die Presentation-Klasse, die eine Präsentationsdatei repräsentiert 
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Hole Referenz des Diagrammobjekts
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Serie animieren
    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectType.FADE, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectChartMajorGroupingType.BY_SERIES, 0, 
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 1,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 2,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 3,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Schreibe die modifizierte Präsentation auf die Festplatte 
    presentation.save("AnimatingSeries_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Diagrammkategorie-Animation**
Wenn Sie eine Diagrammkategorie animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie die Referenz des Diagrammobjekts.
1. Animieren Sie die Kategorie.
1. Speichern Sie die Präsentationsdatei auf der Festplatte.

Im nachstehenden Beispiel haben wir die Diagrammkategorie animiert.
```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Hole Referenz des Diagrammobjekts
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Elemente der Kategorien animieren
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Schreibe die Präsentationsdatei auf die Festplatte
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Animation im Serien-Element**
Wenn Sie Serien‑Elemente animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie die Referenz des Diagrammobjekts.
1. Animieren Sie Serien‑Elemente.
1. Speichern Sie die Präsentationsdatei auf der Festplatte.

Im nachstehenden Beispiel haben wir die Elemente der Serie animiert.
```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Lade eine Präsentation
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Hole Referenz des Diagrammobjekts
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Serienelemente animieren
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NO​NE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Schreibe die Präsentationsdatei auf die Festplatte 
    presentation.save("AnimatingSeriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Animation im Kategorien-Element**
Wenn Sie Kategorien‑Elemente animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie die Referenz des Diagrammobjekts.
1. Animieren Sie Kategorien‑Elemente.
1. Speichern Sie die Präsentationsdatei auf der Festplatte.

Im nachstehenden Beispiel haben wir die Kategorien‑Elemente animiert.
```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Hole Referenz des Diagrammobjekts
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Elemente der Kategorien animieren
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Schreibe die Präsentationsdatei auf die Festplatte
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Werden verschiedene Effektarten (z. B. Eintritt, Betonung, Ausgang) für Diagramme wie für reguläre Formen unterstützt?**

Ja. Ein Diagramm wird als Form behandelt, sodass es die Standard‑Animationseffektarten unterstützt, einschließlich Eintritt, Betonung und Ausgang, mit voller Kontrolle über die Zeitleiste der Folie und Animationssequenzen.

**Kann ich Diagramm‑Animationen mit Folienübergängen kombinieren?**

Ja. [Transitions](/slides/de/python-net/slide-transition/) gelten für die Folie, während Animationseffekte für Objekte auf der Folie gelten. Sie können beide zusammen in derselben Präsentation verwenden und sie unabhängig steuern.

**Werden Diagramm‑Animationen beim Speichern als PPTX beibehalten?**

Ja. Wenn Sie [Speichern als PPTX](/slides/de/python-net/save-presentation/) verwenden, werden alle Animationseffekte und deren Reihenfolge beibehalten, da sie Teil des nativen Animationsmodells der Präsentation sind.

**Kann ich vorhandene Diagramm‑Animationen aus einer Präsentation auslesen und ändern?**

Ja. Die [API](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) stellt Zugriff auf die Folien‑Zeitleiste, Sequenzen und Effekte bereit, sodass Sie vorhandene Diagramm‑Animationen untersuchen und anpassen können, ohne alles von Grund auf neu zu erstellen.

**Kann ich mit Aspose.Slides für Python via .NET ein Video erzeugen, das Diagramm‑Animationen enthält?**

Ja. Sie können die Präsentation [in ein Video exportieren](/slides/de/python-net/convert-powerpoint-to-video/), während die Animationen erhalten bleiben, Timings und andere Exporteinstellungen konfiguriert werden, sodass das resultierende Video die animierte Wiedergabe widerspiegelt.