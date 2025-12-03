---
title: PowerPoint-Diagramme in Java animieren
linktitle: Animierte Diagramme
type: docs
weight: 80
url: /de/java/animated-charts/
keywords:
- Diagramm
- animiertes Diagramm
- Diagrammanimation
- Diagrammserie
- Diagrammkategorie
- Serienelement
- Kategorienelement
- Effekt hinzufügen
- Effekttyp
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen Sie beeindruckende animierte Diagramme in Java mit Aspose.Slides. Verbessern Sie Präsentationen mit dynamischen Visualisierungen in PPT- und PPTX-Dateien – beginnen Sie jetzt."
---

{{% alert color="primary" %}} 

Aspose.Slides for Java unterstützt die Animation von Diagrammelementen. **Serien**, **Kategorien**, **Serienelemente**, **Kategorienelemente** können mit der Methode [**ISequence**.**addEffect**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) und zwei Aufzählungen [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectChartMajorGroupingType) und [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectChartMinorGroupingType) animiert werden.

{{% /alert %}} 

## **Diagramm-Serien-Animation**
Wenn Sie eine Diagrammserie animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Präsentation laden.
1. Referenz des Diagrammobjekts erhalten.
1. Serie animieren.
1. Präsentationsdatei auf die Festplatte schreiben.

Im nachfolgenden Beispiel haben wir Diagrammserien animiert.
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Referenz des Diagrammobjekts holen
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Die Serie animieren
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

    // Die geänderte Präsentation auf die Festplatte schreiben
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Diagramm-Kategorie-Animation**
Wenn Sie eine Diagrammkategorie animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Präsentation laden.
1. Referenz des Diagrammobjekts erhalten.
1. Kategorie animieren.
1. Präsentationsdatei auf die Festplatte schreiben.

Im nachfolgenden Beispiel haben wir Diagrammkategorien animiert.
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0");

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


## **Animation in Serienelement**
Wenn Sie Serienelemente animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Präsentation laden.
1. Referenz des Diagrammobjekts erhalten.
1. Serienelemente animieren.
1. Präsentationsdatei auf die Festplatte schreiben.

Im nachfolgenden Beispiel haben wir Serienelemente animiert.
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Referenz des Diagrammobjekts erhalten
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Serien-Elemente animieren
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

    // Die Präsentationsdatei auf die Festplatte schreiben 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Animation in Kategorienelement**
Wenn Sie Kategorienelemente animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Präsentation laden.
1. Referenz des Diagrammobjekts erhalten.
1. Kategorienelemente animieren.
1. Präsentationsdatei auf die Festplatte schreiben.

Im nachfolgenden Beispiel haben wir Kategorienelemente animiert.
```java
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Referenz des Diagrammobjekts erhalten
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Kategorien‑Elemente animieren
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

    // Die Präsentationsdatei auf die Festplatte schreiben
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Werden verschiedene Effektarten (z. B. Eintritt, Hervorhebung, Austritt) für Diagramme wie für reguläre Formen unterstützt?**

Ja. Ein Diagramm wird als Form behandelt, sodass es die Standardanimationseffektarten, einschließlich Eintritt, Hervorhebung und Austritt, unterstützt und die vollständige Kontrolle über die Zeitleiste der Folie und die Animationssequenzen bietet.

**Kann ich Diagrammanimationen mit Folienübergängen kombinieren?**

Ja. [Transitions](/slides/de/java/slide-transition/) gelten für die Folie, während Animationseffekte für Objekte auf der Folie gelten. Sie können beides in derselben Präsentation verwenden und unabhängig voneinander steuern.

**Bleiben Diagrammanimationen beim Speichern als PPTX erhalten?**

Ja. Wenn Sie [save to PPTX](/slides/de/java/save-presentation/) verwenden, bleiben alle Animationseffekte und deren Reihenfolge erhalten, da sie Teil des nativen Animationsmodells der Präsentation sind.

**Kann ich vorhandene Diagrammanimationen aus einer Präsentation lesen und ändern?**

Ja. Die API bietet Zugriff auf die Zeitleiste der Folie, Sequenzen und Effekte, sodass Sie vorhandene Diagrammanimationen inspizieren und anpassen können, ohne alles von Grund auf neu zu erstellen.

**Kann ich ein Video erzeugen, das Diagrammanimationen mit Aspose.Slides enthält?**

Ja. Sie können eine Präsentation [export to video](/slides/de/java/convert-powerpoint-to-video/) exportieren und dabei Animationen beibehalten, Timings und weitere Exporteinstellungen konfigurieren, sodass das resultierende Video die animierte Wiedergabe widerspiegelt.