---
title: Ottieni l'intero sfondo della diapositiva da una presentazione come immagine
linktitle: Sfondo completo della diapositiva
type: docs
weight: 95
url: /it/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- sfondo diapositiva
- sfondo finale
- estrarre sfondo
- sfondo completo
- sfondo in immagine
- sfondo PPT
- sfondo PPTX
- sfondo ODP
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Estrai gli sfondi completi delle diapositive come immagini da presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Java, semplificando i flussi di lavoro visivi."
---
## **Panoramica**

Nelle presentazioni PowerPoint, lo sfondo di una diapositiva può essere costituito da più elementi, inclusi l'immagine di sfondo della diapositiva, il tema della presentazione, lo schema di colore e gli oggetti posizionati sulla diapositiva master o sulla diapositiva layout.

Questo articolo mostra come estrarre l'intero sfondo della diapositiva come immagine usando Aspose.Slides per .NET. Poiché non esiste un metodo unico per questa operazione, l'approccio prevede di clonare la diapositiva selezionata in una presentazione temporanea, rimuovere le forme della diapositiva e quindi convertire lo sfondo risultante in un'immagine.

## **Ottenere l'intero sfondo della diapositiva**

Aspose.Slides per Java non fornisce un metodo semplice per estrarre l'intero sfondo della diapositiva della presentazione come immagine, ma è possibile seguire i passaggi seguenti per farlo:
1. Carica la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni le dimensioni della diapositiva dalla presentazione.
1. Seleziona una diapositiva.
1. Crea una presentazione temporanea.
1. Imposta le stesse dimensioni della diapositiva nella presentazione temporanea.
1. Clona la diapositiva selezionata nella presentazione temporanea.
1. Elimina le forme dalla diapositiva clonata.
1. Converti la diapositiva clonata in un'immagine.

Il seguente esempio di codice estrae l'intero sfondo della diapositiva della presentazione come immagine.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **FAQ**

**I gradienti complessi, le trame o i riempimenti con immagine da una diapositiva master verranno conservati nell'immagine di sfondo risultante?**

Sì. Aspose.Slides rende i riempimenti gradienti, immagine e texture definiti nella diapositiva, nel layout o nel master. Se è necessario isolare l'aspetto dai master ereditati, [imposta uno sfondo proprio](/slides/it/java/presentation-background/) sulla diapositiva corrente prima dell'esportazione.

**Posso aggiungere una filigrana all'immagine di sfondo risultante prima di salvarla?**

Sì. È possibile [aggiungere una filigrana](/slides/it/java/watermark/) sotto forma di forma o immagine su una [copia della diapositiva](/slides/it/java/clone-slides/) di lavoro (posizionata dietro gli altri contenuti) e poi esportare. In questo modo si genera un'immagine di sfondo con la filigrana incorporata.

**Posso ottenere lo sfondo per un layout o master specifico senza associarlo a una diapositiva esistente?**

Sì. Accedi al master o layout desiderato, applicalo a una [diapositiva temporanea](/slides/it/java/clone-slides/) con le dimensioni richieste e quindi esporta quella diapositiva per ottenere lo sfondo derivato da quel layout o master.

**Ci sono limitazioni di licenza che influenzano l'esportazione delle immagini?**

Le funzionalità di rendering sono pienamente disponibili con una [licenza valida](/slides/it/java/licensing/). In modalità di valutazione, l'output può includere limitazioni come una filigrana. Attiva la licenza una volta per processo prima di eseguire esportazioni batch.