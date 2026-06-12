---
title: Animare i grafici PowerPoint su Android
linktitle: Grafici animati
type: docs
weight: 80
url: /it/androidjava/animated-charts/
keywords:
- grafico
- grafico animato
- animazione del grafico
- serie del grafico
- categoria del grafico
- elemento di serie
- elemento di categoria
- aggiungi effetto
- tipo di effetto
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Crea grafici animati sorprendenti in Java con Aspose.Slides per Android. Potenzia le presentazioni con visual dinamici in file PPT e PPTX—inizia subito."
---
## **Introduzione**

Aspose.Slides per Android via Java supporta l'animazione degli elementi del grafico. **Series**, **Categories**, **Series Elements**, **Categories Elements** possono essere animati con il metodo [ISequence.addEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) e due enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/EffectChartMajorGroupingType) e [EffectChartMinorGroupingType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/EffectChartMinorGroupingType).

## **Animazione della serie del grafico**
Se vuoi animare una serie di grafico, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento dell'oggetto grafico.
1. Anima la serie.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato la serie del grafico.

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Ottenere il riferimento dell'oggetto grafico
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animare la serie
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

    // Scrivere la presentazione modificata su disco
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animazione della categoria del grafico**
Se vuoi animare una categoria di grafico, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento dell'oggetto grafico.
1. Anima la categoria.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato la categoria del grafico.

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione
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

## **Animazione di un elemento di serie**
Se vuoi animare gli elementi della serie, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento dell'oggetto grafico.
1. Anima gli elementi della serie.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato gli elementi della serie.

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Ottenere il riferimento dell'oggetto grafico
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animare gli elementi della serie
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

    // Scrivere il file della presentazione su disco 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animazione di un elemento di categoria**
Se vuoi animare gli elementi delle categorie, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento dell'oggetto grafico.
1. Anima gli elementi delle categorie.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato gli elementi delle categorie.

```java
// Istanziare la classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Ottenere il riferimento dell'oggetto grafico
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animare gli elementi delle categorie
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

    // Scrivere il file della presentazione su disco
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Sono supportati diversi tipi di effetti (ad es., ingresso, enfasi, uscita) per i grafici come per le forme regolari?**

Sì. Un grafico è trattato come una forma, quindi supporta i tipi standard di effetti di animazione, inclusi ingresso, enfasi e uscita, con pieno controllo tramite la timeline della diapositiva e le sequenze di animazione.

**Posso combinare l'animazione del grafico con le transizioni della diapositiva?**

Sì. [Transitions](/slides/it/androidjava/slide-transition/) si applicano alla diapositiva, mentre gli effetti di animazione si applicano agli oggetti sulla diapositiva. Puoi usare entrambi insieme nella stessa presentazione e controllarli indipendentemente.

**Le animazioni dei grafici vengono conservate quando si salva in PPTX?**

Sì. Quando [salvi in PPTX](/slides/it/androidjava/save-presentation/), tutti gli effetti di animazione e il loro ordine vengono conservati perché fanno parte del modello di animazione nativo della presentazione.

**Posso leggere le animazioni dei grafici esistenti da una presentazione e modificarle?**

Sì. L'API fornisce l'accesso alla timeline della diapositiva, alle sequenze e agli effetti, consentendo di esaminare le animazioni dei grafici esistenti e di modificarle senza ricreare tutto da zero.

**Posso creare un video che includa le animazioni dei grafici usando Aspose.Slides?**

Sì. Puoi [esportare una presentazione in video](/slides/it/androidjava/convert-powerpoint-to-video/) mantenendo le animazioni, configurando i tempi e le altre impostazioni di esportazione in modo che il clip risultante rifletta la riproduzione animata.