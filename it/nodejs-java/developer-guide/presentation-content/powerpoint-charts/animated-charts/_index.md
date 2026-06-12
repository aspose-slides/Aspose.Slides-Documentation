---
title: "Animare i grafici PowerPoint in JavaScript"
linktitle: "Grafici animati"
type: docs
weight: 80
url: /it/nodejs-java/animated-charts/
keywords:
- "grafico"
- "grafico animato"
- "animazione del grafico"
- "serie del grafico"
- "categoria del grafico"
- "elemento della serie"
- "elemento della categoria"
- "aggiungi effetto"
- "tipo di effetto"
- "PowerPoint"
- "presentazione"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Crea grafici animati sorprendenti in JavaScript con Aspose.Slides per Node.js. Potenzia le presentazioni con visual dinamici nei file PPT e PPTX—inizia subito."
---
## **Introduzione**

Aspose.Slides per Node.js via Java supporta l'animazione degli elementi del grafico. **Series**, **Categories**, **Series Elements**, **Categories Elements** possono essere animati con il metodo [Sequence.addEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#addEffect) e due enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effectchartmajorgroupingtype/) e [EffectChartMinorGroupingType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effectchartminorgroupingtype/).

## **Animazione della Serie del Grafico**
Se vuoi animare una serie di un grafico, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento dell'oggetto grafico.
1. Anima la serie.
1. Scrivi il file della presentazione su disco.

Nell'esempio riportato di seguito, abbiamo animato la serie del grafico.

```javascript
// Istanziare la classe Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Ottenere il riferimento dell'oggetto grafico
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animare la serie
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Scrivere la presentazione modificata su disco
    pres.save("AnimatingSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animazione della Categoria del Grafico**
Se vuoi animare una categoria di un grafico, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento dell'oggetto grafico.
1. Anima la categoria.
1. Scrivi il file della presentazione su disco.

Nell'esempio riportato di seguito, abbiamo animato la categoria del grafico.

```javascript
// Istanziare la classe Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    pres.save("Sample_Animation_C.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animazione nell'Elemento di Serie**
Se vuoi animare gli elementi di serie, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento dell'oggetto grafico.
1. Anima gli elementi di serie.
1. Scrivi il file della presentazione su disco.

Nell'esempio riportato di seguito, abbiamo animato gli elementi delle serie.

```javascript
// Istanziare la classe Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Ottenere il riferimento dell'oggetto grafico
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animare gli elementi della serie
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Scrivere il file della presentazione su disco
    pres.save("AnimatingSeriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animazione nell'Elemento di Categoria**
Se vuoi animare gli elementi delle categorie, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento dell'oggetto grafico.
1. Anima gli elementi delle categorie.
1. Scrivi il file della presentazione su disco.

Nell'esempio riportato di seguito, abbiamo animato gli elementi delle categorie.

```javascript
// Istanziare la classe Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Ottenere il riferimento dell'oggetto grafico
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Animare gli elementi delle categorie
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Scrivere il file della presentazione su disco
    pres.save("AnimatingCategoriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Sono supportati diversi tipi di effetto (ad es., ingresso, enfasi, uscita) per i grafici come per le forme regolari?**

Sì. Un grafico è trattato come una forma, quindi supporta i tipici tipi di effetto di animazione, inclusi ingresso, enfasi e uscita, con pieno controllo tramite la timeline della diapositiva e le sequenze di animazione.

**Posso combinare l'animazione del grafico con le transizioni della diapositiva?**

Sì. Le [Transitions](/slides/it/nodejs-java/slide-transition/) si applicano alla diapositiva, mentre gli effetti di animazione si applicano agli oggetti sulla diapositiva. Puoi usarli entrambi nella stessa presentazione e controllarli indipendentemente.

**Le animazioni del grafico vengono conservate quando si salva in PPTX?**

Sì. Quando si [save to PPTX](/slides/it/nodejs-java/save-presentation/), tutte le animazioni e il loro ordine sono preservati perché fanno parte del modello di animazione nativo della presentazione.

**Posso leggere le animazioni di grafico esistenti da una presentazione e modificarle?**

Sì. L'API fornisce l'accesso alla timeline della diapositiva, alle sequenze e agli effetti, consentendo di ispezionare le animazioni esistenti del grafico e di modificarle senza ricreare tutto da zero.

**Posso creare un video che includa le animazioni del grafico usando Aspose.Slides?**

Sì. Puoi [export a presentation to video](/slides/it/nodejs-java/convert-powerpoint-to-video/) mantenendo le animazioni, configurando i tempi e altre impostazioni di esportazione in modo che il clip risultante rifletta la riproduzione animata.