---
title: Animare i grafici PowerPoint in .NET
linktitle: Grafici animati
type: docs
weight: 80
url: /it/net/animated-charts/
keywords:
- grafico
- grafico animato
- animazione del grafico
- serie del grafico
- categoria del grafico
- elemento della serie
- elemento della categoria
- aggiungi effetto
- tipo di effetto
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea grafici animati sorprendenti in .NET con Aspose.Slides. Potenzia le presentazioni con elementi visuali dinamici nei file PPT e PPTX—inizia subito."
---
## **Introduzione**

Aspose.Slides per .NET supporta l'animazione degli elementi del grafico. **Series**, **Categories**, **Series Elements**, **Categories Elements** possono essere animati con il metodo [ISequence.AddEffect](https://reference.aspose.com/slides/it/net/aspose.slides.animation/isequence/methods/addeffect) e due enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effectchartmajorgroupingtype) e [EffectChartMinorGroupingType](https://reference.aspose.com/slides/it/net/aspose.slides.animation/effectchartminorgroupingtype).

## **Animazione delle serie del grafico**
Se desideri animare una serie di grafico, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento all'oggetto grafico.
1. Anima la serie.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato le serie del grafico.

```c#
// Istanzia la classe Presentation che rappresenta un file di presentazione 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Ottieni il riferimento all'oggetto grafico
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Anima la serie
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

    // Scrivi la presentazione modificata su disco 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```

## **Animazione della categoria del grafico**
Se desideri animare una serie di grafico, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento all'oggetto grafico.
1. Anima la categoria.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato la categoria del grafico.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Ottieni il riferimento all'oggetto grafico
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Anima gli elementi delle categorie
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

    // Scrivi il file della presentazione su disco
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Animazione in un elemento della serie**
Se desideri animare gli elementi della serie, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento all'oggetto grafico.
1. Anima gli elementi della serie.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato gli elementi della serie.

```c#
// Carica una presentazione
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Ottieni il riferimento all'oggetto grafico
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Anima gli elementi della serie
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

    // Scrivi il file della presentazione su disco 
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Animazione in un elemento della categoria**
Se desideri animare gli elementi delle categorie, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento all'oggetto grafico.
1. Anima gli elementi delle categorie.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato gli elementi delle categorie.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Ottieni il riferimento all'oggetto grafico
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Anima gli elementi delle categorie
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

    // Scrivi il file della presentazione su disco
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Sono supportati diversi tipi di effetto (ad es., ingresso, enfasi, uscita) per i grafici come per le forme normali?**

Sì. Un grafico è considerato una forma, quindi supporta i tipi di effetto di animazione standard, inclusi ingresso, enfasi e uscita, con pieno controllo tramite la timeline della diapositiva e le sequenze di animazione.

**Posso combinare l'animazione del grafico con le transizioni della diapositiva?**

Sì. [Transitions](/slides/it/net/slide-transition/) si applicano alla diapositiva, mentre gli effetti di animazione si applicano agli oggetti sulla diapositiva. Puoi utilizzare entrambi nello stesso file di presentazione e controllarli in modo indipendente.

**Le animazioni dei grafici vengono preservate quando si salva in PPTX?**

Sì. Quando [salvi in PPTX](/slides/it/net/save-presentation/), tutti gli effetti di animazione e il loro ordine vengono preservati perché fanno parte del modello di animazione nativo della presentazione.

**Posso leggere le animazioni dei grafici esistenti da una presentazione e modificarle?**

Sì. L'[API](https://reference.aspose.com/slides/it/net/aspose.slides.animation/) offre l'accesso alla timeline della diapositiva, alle sequenze e agli effetti, consentendo di esaminare le animazioni dei grafici esistenti e di modificarle senza dover ricreare tutto da capo.

**Posso creare un video che includa le animazioni dei grafici usando Aspose.Slides?**

Sì. Puoi [esportare una presentazione in video](/slides/it/net/convert-powerpoint-to-video/) mantenendo le animazioni, configurando i tempi e altre impostazioni di esportazione in modo che il video risultante rifletta la riproduzione animata.