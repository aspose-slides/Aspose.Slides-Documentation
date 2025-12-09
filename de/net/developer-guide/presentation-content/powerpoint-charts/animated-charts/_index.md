---
title: PowerPoint-Diagramme in .NET animieren
linktitle: Animierte Diagramme
type: docs
weight: 80
url: /de/net/animated-charts/
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
- .NET
- C#
- Aspose.Slides
description: "Erstellen Sie beeindruckende animierte Diagramme in .NET mit Aspose.Slides. Verbessern Sie Präsentationen mit dynamischen Visualisierungen in PPT- und PPTX-Dateien – starten Sie jetzt."
---

Aspose.Slides für .NET unterstützt die Animation von Diagrammelementen. **Serien**, **Kategorien**, **Serienelemente**, **Kategorienelemente** können mit der Methode [**ISequence**.**AddEffect**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/methods/addeffect) und zwei Enums [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartmajorgroupingtype) und [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartminorgroupingtype) animiert werden.

## **Diagramm-Serienanimation**
Wenn Sie eine Diagrammserie animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.  
2. Holen Sie die Referenz des Diagrammobjekts.  
3. Animieren Sie die Serien.  
4. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir Diagrammserien animiert.  
```c#
// Instanziiert die Presentation-Klasse, die eine Präsentationsdatei darstellt 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Ruft die Referenz des Diagrammobjekts ab
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animiert die Serie
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

    // Schreibt die geänderte Präsentation auf die Festplatte 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```


## **Diagramm-Kategorienanimation**
Wenn Sie eine Diagrammkategorie animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.  
2. Holen Sie die Referenz des Diagrammobjekts.  
3. Animieren Sie die Kategorie.  
4. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir Diagrammkategorien animiert.  
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Holt die Referenz des Diagrammobjekts
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animiert die Elemente der Kategorien
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

    // Schreibt die Präsentationsdatei auf die Festplatte
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **Animation in Serienelementen**
Wenn Sie Serienelemente animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.  
2. Holen Sie die Referenz des Diagrammobjekts.  
3. Animieren Sie Serienelemente.  
4. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir Serienelemente animiert.  
```c#
// Lade eine Präsentation
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Hole die Referenz des Diagrammobjekts
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animieren von Serienelementen
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

    // Schreibe die Präsentationsdatei auf die Festplatte 
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
}
```



## **Animation in Kategorienelementen**
Wenn Sie Kategorienelemente animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.  
2. Holen Sie die Referenz des Diagrammobjekts.  
3. Animieren Sie Kategorienelemente.  
4. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir Kategorienelemente animiert.  
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Holt die Referenz des Diagrammobjekts
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animiert die Elemente der Kategorien
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

    // Schreibt die Präsentationsdatei auf die Festplatte
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Werden verschiedene Effektarten (z. B. Eintritt, Hervorhebung, Austritt) für Diagramme wie für reguläre Formen unterstützt?**  
Ja. Ein Diagramm wird als Form behandelt, sodass es die Standard‑Animationseffekteinkategorien – Eintritt, Hervorhebung und Austritt – unterstützt und volle Kontrolle über die Zeitleiste der Folie und die Animationssequenzen bietet.

**Kann ich Diagrammanimationen mit Folienübergängen kombinieren?**  
Ja. [Übergänge](/slides/de/net/slide-transition/) gelten für die Folie, während Animationseffekte für Objekte auf der Folie gelten. Sie können beide in derselben Präsentation verwenden und sie unabhängig voneinander steuern.

**Bleiben Diagrammanimationen beim Speichern als PPTX erhalten?**  
Ja. Beim [speichern als PPTX](/slides/de/net/save-presentation/) werden alle Animations‑Effekte und ihre Reihenfolge beibehalten, da sie Teil des nativen Animationsmodells der Präsentation sind.

**Kann ich vorhandene Diagrammanimationen aus einer Präsentation auslesen und ändern?**  
Ja. Die [API](https://reference.aspose.com/slides/net/aspose.slides.animation/) bietet Zugriff auf die Folien‑Zeitleiste, Sequenzen und Effekte, sodass Sie bestehende Diagrammanimationen inspizieren und anpassen können, ohne alles neu zu erstellen.

**Kann ich mit Aspose.Slides ein Video erzeugen, das Diagrammanimationen enthält?**  
Ja. Sie können eine Präsentation [in ein Video exportieren](/slides/de/net/convert-powerpoint-to-video/), wobei die Animationen erhalten bleiben und Sie Timing‑ und Exporteinstellungen konfigurieren können, sodass das resultierende Video die animierte Wiedergabe widerspiegelt.