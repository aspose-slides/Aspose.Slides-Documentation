---
title: Ottieni l'intero sfondo della diapositiva da una presentazione come immagine
linktitle: Intero sfondo della diapositiva
type: docs
weight: 95
url: /it/php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- sfondo diapositiva
- sfondo finale
- estrarre sfondo
- sfondo intero
- sfondo in immagine
- sfondo PPT
- sfondo PPTX
- sfondo ODP
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Estrai gli sfondi completi delle diapositive come immagini da presentazioni PowerPoint e OpenDocument usando Aspose.Slides per PHP via Java, semplificando i flussi di lavoro visivi."
---
## **Panoramica**

Nelle presentazioni PowerPoint, lo sfondo di una diapositiva può essere costituito da più elementi, inclusi l'immagine di sfondo della diapositiva, il tema della presentazione, lo schema di colori e gli oggetti posizionati sulla diapositiva master o sulla diapositiva layout.

Questo articolo mostra come estrarre l'intero sfondo della diapositiva come immagine usando Aspose.Slides. Poiché non esiste un singolo metodo per questa operazione, l'approccio prevede la clonazione della diapositiva selezionata in una presentazione temporanea, la rimozione delle forme della diapositiva e poi la conversione dello sfondo risultante in un'immagine.

## **Ottenere l'intero sfondo della diapositiva**

Aspose.Slides per PHP via Java non fornisce un metodo semplice per estrarre l'intero sfondo della diapositiva della presentazione come immagine, ma è possibile seguire i passaggi seguenti per farlo:
1. Carica la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottieni le dimensioni della diapositiva dalla presentazione.
1. Seleziona una diapositiva.
1. Crea una presentazione temporanea.
1. Imposta le stesse dimensioni della diapositiva nella presentazione temporanea.
1. Clona la diapositiva selezionata nella presentazione temporanea.
1. Elimina le forme dalla diapositiva clonata.
1. Converti la diapositiva clonata in un'immagine.

Il seguente esempio di codice estrae l'intero sfondo della diapositiva della presentazione come immagine.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```

## **FAQ**

**I gradienti complessi, le texture o i riempimenti con immagine da una diapositiva master verranno preservati nell'immagine di sfondo risultante?**

Sì. Aspose.Slides rende i riempimenti a gradiente, immagine e texture definiti sulla diapositiva, sul layout o sul master. Se è necessario isolare l'aspetto dai master ereditati, [imposta uno sfondo proprio](/slides/it/php-java/presentation-background/) sulla diapositiva corrente prima di esportare.

**Posso aggiungere una filigrana all'immagine di sfondo risultante prima di salvarla?**

Sì. Puoi [aggiungi una filigrana](/slides/it/php-java/watermark/) forma o immagine su una [copia della diapositiva](/slides/it/php-java/clone-slides/) di lavoro (posizionata dietro altro contenuto) e poi esportare. Questo ti consente di generare un'immagine di sfondo con la filigrana incorporata.

**Posso ottenere lo sfondo per un layout o master specifico senza collegarlo a una diapositiva esistente?**

Sì. Accedi al master o layout desiderato, applicalo a una [diapositiva temporanea](/slides/it/php-java/clone-slides/) con le dimensioni richieste e esporta quella diapositiva per ottenere lo sfondo derivato da quel layout o master.

**Esistono limitazioni di licenza che influenzano l'esportazione delle immagini?**

Le funzionalità di rendering sono pienamente disponibili con una [licenza valida](/slides/it/php-java/licensing/). In modalità di valutazione, l'output può includere limitazioni come una filigrana. Attiva la licenza una volta per processo prima di eseguire esportazioni batch.