---
title: Animare il testo PowerPoint in PHP
linktitle: Testo animato
type: docs
weight: 60
url: /it/php-java/animated-text/
keywords:
- testo animato
- animazione del testo
- paragrafo animato
- animazione del paragrafo
- effetto di animazione
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Crea testo animato dinamico in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per PHP via Java, con esempi di codice facili da seguire e ottimizzati."
---
## **Panoramica**

Questo articolo spiega come lavorare con il testo animato in Aspose.Slides applicando effetti di animazione a singoli paragrafi e recuperando gli effetti già assegnati ai paragrafi in un riquadro di testo. Si concentra sui metodi API usati per aggiungere animazioni a livello di paragrafo e per ispezionare gli effetti di animazione dei paragrafi esistenti in una presentazione.

## **Aggiungere effetti di animazione ai paragrafi**

Abbiamo aggiunto il metodo [**addEffect()**](https://reference.aspose.com/slides/it/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) alla classe [**Sequence**](https://reference.aspose.com/slides/it/php-java/aspose.slides/Sequence). Questo metodo consente di aggiungere effetti di animazione a un singolo paragrafo. Il seguente esempio di codice mostra come aggiungere un effetto di animazione a un singolo paragrafo:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # seleziona il paragrafo a cui aggiungere l'effetto
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # aggiungi effetto di animazione Fly al paragrafo selezionato
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ottenere gli effetti di animazione dei paragrafi**

Potresti decidere di scoprire gli effetti di animazione aggiunti a un paragrafo — ad esempio, in uno scenario vuoi ottenere gli effetti di animazione in un paragrafo perché intendi applicarli a un altro paragrafo o a una forma.

Aspose.Slides per PHP via Java consente di ottenere tutti gli effetti di animazione applicati ai paragrafi contenuti in un riquadro di testo (forma). Il seguente esempio di codice mostra come ottenere gli effetti di animazione in un paragrafo:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **FAQ**

**In che modo le animazioni del testo differiscono dalle transizioni della diapositiva e possono essere combinate?**

Le animazioni del testo controllano il comportamento dell'oggetto nel tempo su una diapositiva, mentre le [transizioni](/slides/it/php-java/slide-transition/) controllano come le diapositive cambiano. Sono indipendenti e possono essere usate insieme; l'ordine di riproduzione è governato dalla timeline dell'animazione e dalle impostazioni di transizione.

**Le animazioni del testo vengono conservate durante l'esportazione in PDF o immagini?**

No. PDF e immagini raster sono statici, quindi vedrai un singolo stato della diapositiva senza movimento. Per mantenere il movimento, usa l'esportazione in [video](/slides/it/php-java/convert-powerpoint-to-video/) o in [HTML](/slides/it/php-java/export-to-html5/).

**Le animazioni del testo funzionano nei layout e nel master della diapositiva?**

Gli effetti applicati a oggetti di layout/master vengono ereditati dalle diapositive, ma la loro temporizzazione e interazione con le animazioni a livello di diapositiva dipendono dalla sequenza finale sulla diapositiva.