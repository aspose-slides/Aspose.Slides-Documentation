---
title: Anima i grafici PowerPoint in PHP
linktitle: Grafici animati
type: docs
weight: 80
url: /it/php-java/animated-charts/
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
  - PHP
  - Aspose.Slides
description: "Crea grafici animati sorprendenti con Aspose.Slides per PHP via Java. Potenzia le presentazioni con elementi visivi dinamici nei file PPT e PPTX — inizia subito."
---
## **Introduzione**

Aspose.Slides per PHP via Java supporta l'animazione degli elementi del grafico. **Series**, **Categories**, **Series Elements**, **Categories Elements** possono essere animati con il metodo [Sequence::addEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/sequence/#addEffect) e due enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/it/php-java/aspose.slides/EffectChartMajorGroupingType) e [EffectChartMinorGroupingType](https://reference.aspose.com/slides/it/php-java/aspose.slides/EffectChartMinorGroupingType).

## **Animazione della Serie del Grafico**
Se desideri animare una serie di grafico, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento dell'oggetto grafico.
1. Anima la serie.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato le serie del grafico.

```php
  # Istanziare la classe Presentation che rappresenta un file di presentazione
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Ottieni il riferimento dell'oggetto grafico
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Anima la serie
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Scrivi la presentazione modificata su disco
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animazione della Categoria del Grafico**
Se desideri animare una categoria di grafico, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento dell'oggetto grafico.
1. Anima la categoria.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato la categoria del grafico.

```php
  # Istanziare la classe Presentation che rappresenta un file di presentazione
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animazione di un Elemento di Serie**
Se desideri animare gli elementi della serie, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento dell'oggetto grafico.
1. Anima gli elementi della serie.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato gli elementi delle serie.

```php
  # Istanziare la classe Presentation che rappresenta un file di presentazione
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Ottenere il riferimento dell'oggetto grafico
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animare gli elementi della serie
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Scrivere il file di presentazione su disco
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animazione di un Elemento di Categoria**
Se desideri animare gli elementi delle categorie, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.
1. Ottieni il riferimento dell'oggetto grafico.
1. Anima gli elementi delle categorie.
1. Scrivi il file della presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo animato gli elementi delle categorie.

```php
  # Istanziare la classe Presentation che rappresenta un file di presentazione
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Ottenere il riferimento dell'oggetto grafico
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animare gli elementi delle categorie
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Scrivere il file di presentazione su disco
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Sono supportati diversi tipi di effetti (ad es., ingresso, enfasi, uscita) per i grafici come per le forme normali?**

Sì. Un grafico è considerato una forma, quindi supporta i tipi di effetto di animazione standard, inclusi ingresso, enfasi e uscita, con pieno controllo tramite la timeline della diapositiva e le sequenze di animazione.

**Posso combinare l'animazione del grafico con le transizioni delle diapositive?**

Sì. [Transizioni](/slides/it/php-java/slide-transition/) si applicano alla diapositiva, mentre gli effetti di animazione si applicano agli oggetti sulla diapositiva. Puoi utilizzare entrambi nella stessa presentazione e controllarli indipendentemente.

**Le animazioni dei grafici vengono conserve quando si salva in PPTX?**

Sì. Quando [salva in PPTX](/slides/it/php-java/save-presentation/), tutti gli effetti di animazione e il loro ordine vengono conservati perché fanno parte del modello di animazione nativo della presentazione.

**Posso leggere le animazioni dei grafici esistenti da una presentazione e modificarle?**

Sì. L'API fornisce l'accesso alla timeline della diapositiva, alle sequenze e agli effetti, consentendo di esaminare le animazioni dei grafici esistenti e di regolarle senza ricreare tutto da zero.

**Posso creare un video che includa le animazioni dei grafici usando Aspose.Slides?**

Sì. È possibile [esporta una presentazione in video](/slides/it/php-java/convert-powerpoint-to-video/) mantenendo le animazioni, configurando i tempi e le altre impostazioni di esportazione in modo che il video risultante rifletta la riproduzione animata.