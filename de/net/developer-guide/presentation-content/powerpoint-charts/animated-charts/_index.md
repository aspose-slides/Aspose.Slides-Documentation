---
title: Animierte Diagramme
type: docs
weight: 80
url: /de/net/animated-charts/
keywords: "Diagramme, Diagrammserien, Animation PowerPoint-Präsentation, PPTX, PPT, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint-Diagrammserien und -Animationen in C# oder .NET"
---

Aspose.Slides für .NET unterstützt die Animation von Diagrammelementen. **Series**, **Categories**, **Series Elements**, **Categories Elements** können mit der [**ISequence**.**AddEffect**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/methods/addeffect)Methode und zwei Aufzählungen [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartmajorgroupingtype) und [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartminorgroupingtype) animiert werden.

## **Diagramm-Serien-Animation**
Wenn Sie eine Diagramm‑Serie animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.  
2. Holen Sie die Referenz des Diagramm‑Objekts.  
3. Animieren Sie die Serie.  
4. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir die Diagramm‑Serie animiert.
```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Holen Sie die Referenz des Diagrammobjekts
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animieren Sie die Serie
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

    // Speichern Sie die modifizierte Präsentation auf dem Datenträger 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```


## **Diagramm-Kategorien-Animation**
Wenn Sie eine Diagramm‑Kategorie animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.  
2. Holen Sie die Referenz des Diagramm‑Objekts.  
3. Animieren Sie die Kategorie.  
4. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir die Diagramm‑Kategorie animiert.
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Holen Sie die Referenz des Diagrammobjekts
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animieren Sie die Elemente der Kategorien
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

    // Schreiben Sie die Präsentationsdatei auf die Festplatte
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **Animation im Serien-Element**
Wenn Sie Serien‑Elemente animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.  
2. Holen Sie die Referenz des Diagramm‑Objekts.  
3. Animieren Sie Serien‑Elemente.  
4. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir die Elemente der Serie animiert.
```c#
    // Laden Sie eine Präsentation
    using (Presentation presentation = new Presentation("ExistingChart.pptx"))
    {
        // Holen Sie die Referenz des Diagrammobjekts
        var slide = presentation.Slides[0] as Slide;
        var shapes = slide.Shapes as ShapeCollection;
        var chart = shapes[0] as IChart;

        // Animieren Sie die Elemente der Serie
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

        // Schreiben Sie die Präsentationsdatei auf die Festplatte 
        presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
    }
```


## **Animation im Kategorien-Element**
Wenn Sie Kategorien‑Elemente animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.  
2. Holen Sie die Referenz des Diagramm‑Objekts.  
3. Animieren Sie Kategorien‑Elemente.  
4. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir die Kategorien‑Elemente animiert.
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Holen Sie die Referenz des Diagrammobjekts
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animieren Sie die Elemente der Kategorien
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

    // Schreiben Sie die Präsentationsdatei auf die Festplatte
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Werden verschiedene Effektarten (z. B. Einstieg, Hervorhebung, Verlassen) für Diagramme wie für reguläre Formen unterstützt?**  
Ja. Ein Diagramm wird als Form behandelt, sodass es die standardmäßigen Animationseffektarten unterstützt, einschließlich Einstieg, Hervorhebung und Verlassen, mit voller Kontrolle über die Zeitleiste der Folie und die Animationssequenzen.

**Kann ich Diagramm-Animationen mit Folienübergängen kombinieren?**  
Ja. [Transitions](/slides/de/net/slide-transition/) gelten für die Folie, während Animationseffekte für Objekte auf der Folie gelten. Sie können beide zusammen in derselben Präsentation verwenden und sie unabhängig steuern.

**Werden Diagramm-Animationen beim Speichern als PPTX erhalten?**  
Ja. Wenn Sie [save to PPTX](/slides/de/net/save-presentation/) verwenden, werden alle Animationseffekte und deren Reihenfolge erhalten, da sie Teil des nativen Animationsmodells der Präsentation sind.

**Kann ich vorhandene Diagramm-Animationen aus einer Präsentation lesen und ändern?**  
Ja. Die [API](https://reference.aspose.com/slides/net/aspose.slides.animation/) bietet Zugriff auf die Zeitleiste der Folie, Sequenzen und Effekte, sodass Sie vorhandene Diagramm‑Animationen untersuchen und anpassen können, ohne alles von Grund auf neu zu erstellen.

**Kann ich mit Aspose.Slides ein Video erzeugen, das Diagramm-Animationen enthält?**  
Ja. Sie können eine Präsentation [export a presentation to video](/slides/de/net/convert-powerpoint-to-video/) exportieren, wobei die Animationen erhalten bleiben, Timings und weitere Exporteinstellungen konfiguriert werden, sodass das resultierende Video die animierte Wiedergabe widerspiegelt.