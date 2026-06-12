---
title: Rendere le diapositive di presentazione come immagini SVG in PHP
linktitle: Diapositiva in SVG
type: docs
weight: 50
url: /it/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint in SVG
- presentazione in SVG
- diapositiva in SVG
- PPT in SVG
- PPTX in SVG
- salva PPT come SVG
- salva PPTX come SVG
- esporta PPT in SVG
- esporta PPTX in SVG
- renderizza diapositiva
- converti diapositiva
- esporta diapositiva
- immagine vettoriale
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come rendere le diapositive PowerPoint come immagini SVG usando Aspose.Slides per PHP tramite Java. Visuali di alta qualità con semplici esempi di codice."
---
## **Panoramica**

Questo articolo spiega come rendere le diapositive di una presentazione come immagini SVG usando Aspose.Slides. Descrive il formato SVG e i suoi vantaggi, tra cui scalabilità, accessibilità e idoneità per lo sviluppo web.

Imparerai come caricare un file di presentazione, iterare le sue diapositive e salvare ogni diapositiva come file SVG separato. L'articolo copre i formati di presentazione PowerPoint e OpenDocument, inclusi PPT, PPTX, ODP e PPS, e mostra come eseguire la conversione in modo programmatico con la classe `Presentation` e il metodo `writeAsSvg`.

## **Formato SVG**

SVG—acronimo di Scalable Vector Graphics—è un tipo o formato grafico standard usato per rendere immagini bidimensionali. SVG memorizza le immagini come vettori in XML con dettagli che ne definiscono il comportamento o l'aspetto.

SVG è uno dei pochi formati di immagine che soddisfa standard molto elevati in termini di: scalabilità, interattività, prestazioni, accessibilità, programmabilità e altro. Per questi motivi è comunemente usato nello sviluppo web.

Potresti voler usare file SVG quando devi

- **stampare la tua presentazione in un *formato molto grande*.** Le immagini SVG possono scalare a qualsiasi risoluzione o livello. Puoi ridimensionare le immagini SVG quante volte è necessario senza sacrificare la qualità.
- **usare grafici e diagrammi dalle tue diapositive in *diversi supporti o piattaforme*.** La maggior parte dei lettori può interpretare i file SVG.
- **usare le *dimensioni più piccole possibili per le immagini***. I file SVG sono generalmente più piccoli dei loro equivalenti ad alta risoluzione in altri formati, soprattutto quelli basati su bitmap (JPEG o PNG).

## **Renderizzare una diapositiva come immagine SVG**

Aspose.Slides for PHP via Java ti consente di esportare le diapositive delle tue presentazioni come immagini SVG. Segui questi passaggi per generare immagini SVG:

1. Crea un'istanza della classe Presentation.
2. Itera tutte le diapositive della presentazione.
3. Scrivi ogni diapositiva nel proprio file SVG tramite FileOutputStream.

{{% alert color="primary" %}} 
Potresti voler provare la nostra [applicazione web gratuita](https://products.aspose.app/slides/it/conversion/ppt-to-svg) nella quale abbiamo implementato la funzione di conversione da PPT a SVG di Aspose.Slides per PHP via Java.
{{% /alert %}} 

Questo esempio di codice mostra come convertire PPT in SVG usando Aspose.Slides:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $fileStream = new Java("java.io.FileOutputStream", "slide-" . $index . ".svg");
      try {
        $slide->writeAsSvg($fileStream);
      } finally {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Perché il risultato SVG può apparire diverso tra i vari browser?**

Il supporto per specifiche funzionalità SVG è implementato diversamente dai motori dei browser. I parametri [SVGOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/) aiutano a mitigare le incompatibilità.

**È possibile esportare non solo le diapositive ma anche forme individuali in SVG?**

Sì. Qualsiasi [forma può essere salvata come SVG separato](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/writeassvg/), il che è comodo per icone, pittogrammi e riutilizzo di grafiche.

**È possibile combinare più diapositive in un unico SVG (striscia/documento)?**

Lo scenario standard è una diapositiva → un SVG. Unire più diapositive in un unico canvas SVG è un'operazione di post‑processing eseguita a livello di applicazione.