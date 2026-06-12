---
title: Animare i grafici PowerPoint in Python
linktitle: Grafici animati
type: docs
weight: 80
url: /it/python-net/animated-charts/
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
- Python
- Aspose.Slides
description: "Crea grafici animati sorprendenti in Python con Aspose.Slides. Potenzia le presentazioni con visual dinamici in file PPT, PPTX e ODP — inizia subito."
---
## **Introduzione**

Aspose.Slides per Python tramite .NET supporta l'animazione degli elementi del grafico. **Serie**, **Categorie**, **Elementi della Serie**, **Elementi delle Categorie** possono essere animati con il metodo [ISequence.add_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/isequence/) e due enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effectchartmajorgroupingtype/) e [EffectChartMinorGroupingType](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effectchartminorgroupingtype/).
## **Animazione della Serie del Grafico**
Se vuoi animare una serie di grafico, scrivi il codice seguendo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni un riferimento all'oggetto grafico.
1. Anima la serie.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato le serie del grafico.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Istanzia la classe Presentation che rappresenta un file di presentazione 
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Ottieni il riferimento dell'oggetto grafico
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Anima la serie
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

    # Scrivi la presentazione modificata su disco 
    presentation.save("AnimatingSeries_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Animazione della Categoria del Grafico**
Se vuoi animare una categoria di grafico, scrivi il codice seguendo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni un riferimento all'oggetto grafico.
1. Anima la categoria.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato la categoria del grafico.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Ottieni il riferimento dell'oggetto grafico
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Anima gli elementi delle categorie
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

    # Scrivi il file della presentazione su disco
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Animazione negli Elementi della Serie**
Se vuoi animare gli elementi della serie, scrivi il codice seguendo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni un riferimento all'oggetto grafico.
1. Anima gli elementi della serie.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato gli elementi della serie.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Carica una presentazione
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Ottieni il riferimento dell'oggetto grafico
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Anima gli elementi della serie
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Scrivi il file della presentazione su disco 
    presentation.save("AnimatingSeriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Animazione negli Elementi della Categoria**
Se vuoi animare gli elementi delle categorie, scrivi il codice seguendo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni un riferimento all'oggetto grafico.
1. Anima gli elementi delle categorie.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato gli elementi delle categorie.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Ottieni il riferimento dell'oggetto grafico
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Anima gli elementi delle categorie
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

    # Scrivi il file della presentazione su disco
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Sono supportati diversi tipi di effetto (es. ingresso, enfasi, uscita) per i grafici come per le forme standard?**

Sì. Un grafico è considerato una forma, quindi supporta i tipi di effetto di animazione standard, inclusi ingresso, enfasi e uscita, con pieno controllo tramite la timeline della diapositiva e le sequenze di animazione.

**Posso combinare l'animazione del grafico con le transizioni della diapositiva?**

Sì. [Transitions](/slides/it/python-net/slide-transition/) si applicano alla diapositiva, mentre gli effetti di animazione si applicano agli oggetti sulla diapositiva. Puoi utilizzare entrambi nella stessa presentazione e controllarli indipendentemente.

**Le animazioni dei grafici vengono preservate quando si salva in PPTX?**

Sì. Quando [salvi in PPTX](/slides/it/python-net/save-presentation/), tutti gli effetti di animazione e il loro ordine vengono preservati perché fanno parte del modello di animazione nativo della presentazione.

**Posso leggere le animazioni dei grafici esistenti da una presentazione e modificarle?**

Sì. L'[API](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/) fornisce l'accesso alla timeline della diapositiva, alle sequenze e agli effetti, consentendo di ispezionare le animazioni dei grafici esistenti e di modificarle senza ricreare tutto da zero.

**Posso creare un video che includa le animazioni dei grafici usando Aspose.Slides per Python tramite .NET?**

Sì. Puoi [esportare una presentazione in video](/slides/it/python-net/convert-powerpoint-to-video/) mantenendo le animazioni, configurando i tempi e altre impostazioni di esportazione in modo che il clip risultante rifletta la riproduzione animata.