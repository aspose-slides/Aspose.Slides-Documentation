---
title: Unire in modo efficiente le presentazioni in PHP
linktitle: Unisci Presentazioni
type: docs
weight: 40
url: /it/php-java/merge-presentation/
keywords:
- unire PowerPoint
- unire presentazioni
- unire diapositive
- unire PPT
- unire PPTX
- unire ODP
- combinare PowerPoint
- combinare presentazioni
- combinare diapositive
- combinare PPT
- combinare PPTX
- combinare ODP
- PHP
- Aspose.Slides
description: "Unisci facilmente le presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP) con Aspose.Slides per PHP via Java, semplificando il tuo flusso di lavoro."
---
## **Panoramica**

Aspose.Slides consente di unire presentazioni clonando le diapositive da una presentazione all'altra. Questo articolo spiega come unire presentazioni intere o diapositive selezionate, utilizzare un master diapositiva o un layout specifico durante l'unione, gestire presentazioni con dimensioni delle diapositive diverse e aggiungere diapositive unite a una sezione della presentazione. Copre anche note pratiche relative al contenuto unito, incluse le note del relatore, i commenti, i file di origine protetti da password e l'uso dei thread.

## **Unione di Presentazioni**

Quando unisci una presentazione a un'altra, stai effettivamente combinando le loro diapositive in un'unica presentazione per ottenere un unico file. 

{{% alert title="Info" color="info" %}}
La maggior parte dei programmi di presentazione (PowerPoint o OpenOffice) non dispone di funzioni che consentono agli utenti di combinare le presentazioni in questo modo. 
{{% /alert %}}

[**Aspose.Slides per PHP via Java**](https://products.aspose.com/slides/it/php-java/), tuttavia, consente di unire presentazioni in diversi modi. È possibile unire presentazioni con tutte le loro forme, stili, testi, formattazioni, commenti, animazioni, ecc., senza doversi preoccupare della perdita di qualità o dati.

**Vedi anche**

[Clona Diapositive](/slides/it/php-java/clone-slides/).

### **Cosa Può Essere Unito**

Con Aspose.Slides, puoi unire 

* presentazioni intere. Tutte le diapositive delle presentazioni finiscono in un'unica presentazione
* diapositive specifiche. Le diapositive selezionate finiscono in un'unica presentazione
* presentazioni in un unico formato (PPT a PPT, PPTX a PPTX, ecc.) e in formati diversi (PPT a PPTX, PPTX a ODP, ecc.) tra loro. 

{{% alert title="Note" color="warning" %}} 
Oltre alle presentazioni, Aspose.Slides consente di unire altri file:

* [Immagini](https://products.aspose.com/slides/it/php-java/merger/image-to-image/), come [JPG a JPG](https://products.aspose.com/slides/it/php-java/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/it/php-java/merger/png-to-png/)
* Documenti, come [PDF a PDF](https://products.aspose.com/slides/it/php-java/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/it/php-java/merger/html-to-html/)
* E due file diversi, come [immagine a PDF](https://products.aspose.com/slides/it/php-java/merger/image-to-pdf/), [JPG a PDF](https://products.aspose.com/slides/it/php-java/merger/jpg-to-pdf/) o [TIFF a PDF](https://products.aspose.com/slides/it/php-java/merger/tiff-to-pdf/).
{{% /alert %}}

### **Opzioni di Unione**

Puoi applicare opzioni che determinano se

* ogni diapositiva nella presentazione di output mantiene uno stile unico
* uno stile specifico è utilizzato per tutte le diapositive nella presentazione di output. 

Per unire presentazioni, Aspose.Slides fornisce metodi [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) (dalla classe [SlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/)). Esistono diverse implementazioni dei metodi `addClone` che definiscono i parametri del processo di unione delle presentazioni. Ogni oggetto Presentation ha una collezione di [slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getslides/), quindi è possibile chiamare un metodo `addClone` dalla presentazione in cui si desidera unire le diapositive.

Il metodo `addClone` restituisce un oggetto `Slide`, che è una copia della diapositiva di origine. Le diapositive in una presentazione di output sono semplicemente una copia delle diapositive di origine. Pertanto, è possibile modificare le diapositive risultanti (ad esempio, applicare stili, opzioni di formattazione o layout) senza preoccuparsi che le presentazioni di origine vengano influenzate. 

## **Unisci Presentazioni** 

Aspose.Slides fornisce il metodo [addClone(Slide)](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) che consente di combinare diapositive mantenendo i loro layout e stili (parametri predefiniti).

Questo codice PHP mostra come unire presentazioni:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Unisci Presentazioni con un Master Diapositiva**

Aspose.Slides fornisce il metodo [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) che consente di combinare diapositive applicando un modello di master diapositiva. In questo modo, se necessario, è possibile modificare lo stile delle diapositive nella presentazione di output.

Questo codice dimostra l'operazione descritta:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Il layout della diapositiva per il master è determinato automaticamente. Quando non è possibile determinare un layout appropriato, se il parametro booleano `allowCloneMissingLayout` del metodo `addClone` è impostato su true, viene utilizzato il layout della diapositiva di origine. In caso contrario, verrà generata un'eccezione [PptxEditException](https://reference.aspose.com/slides/it/php-java/aspose.slides/PptxEditException). 
{{% /alert %}}

Se desideri che le diapositive nella presentazione di output abbiano un layout diverso, usa invece il metodo [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) durante l'unione.

## **Unisci Diapositive Specifiche da Presentazioni**

Unire diapositive specifiche da più presentazioni è utile per creare deck personalizzati. Aspose.Slides per PHP via Java consente di selezionare e importare solo le diapositive necessarie. L'API preserva formattazione, layout e design delle diapositive originali.

Il seguente codice PHP crea una nuova presentazione, aggiunge diapositive titolo da due altre presentazioni e salva il risultato in un file:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **Unisci Presentazioni con un Layout Diapositiva**

Questo codice PHP mostra come combinare diapositive da presentazioni applicando il layout di diapositiva preferito per ottenere una presentazione di output unica:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Unisci Presentazioni con Dimensioni Diapositiva Diverse**

{{% alert title="Note" color="warning" %}} 
Non è possibile unire presentazioni con dimensioni diapositive diverse. 
{{% /alert %}}

Per unire 2 presentazioni con dimensioni diapositive diverse, è necessario ridimensionare una delle presentazioni in modo che le sue dimensioni corrispondano a quelle dell'altra.

Questo codice di esempio dimostra l'operazione descritta:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Unisci Diapositive in una Sezione di Presentazione**

Questo codice PHP mostra come unire una diapositiva specifica a una sezione in una presentazione:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

La diapositiva viene aggiunta alla fine della sezione. 

## **Vedi anche**

Aspose offre un [FREE Online Collage Maker](https://products.aspose.app/slides/it/collage). Utilizzando questo servizio online, è possibile unire immagini [JPG a JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG a PNG, creare [griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid) e altro ancora.

Scopri il [Aspose FREE Online Merger](https://products.aspose.app/slides/it/merger). Consente di unire presentazioni PowerPoint nello stesso formato (ad es. PPT a PPT, PPTX a PPTX) o tra formati diversi (ad es. PPT a PPTX, PPTX a ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/it/merger)

## **FAQ**

**Ci sono limitazioni sul numero di diapositive quando si uniscono presentazioni?**

Nessuna limitazione rigida. Aspose.Slides può gestire file di grandi dimensioni, ma le prestazioni dipendono dalla dimensione e dalle risorse di sistema. Per presentazioni molto grandi, è consigliato utilizzare una JVM a 64 bit e allocare sufficiente memoria heap.

**Posso unire presentazioni con video o audio incorporati?**

Sì, Aspose.Slides conserva i contenuti multimediali incorporati nelle diapositive, ma la presentazione finale potrebbe diventare significativamente più grande.

**I font verranno conservati quando si uniscono le presentazioni?**

Sì. I font utilizzati nelle presentazioni di origine sono preservati nel file di output, a condizione che siano installati sul sistema o [incorporati](/slides/it/php-java/embedded-font/).