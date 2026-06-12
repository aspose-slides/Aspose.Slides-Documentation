---
title: Ottieni l'intero sfondo della diapositiva da una presentazione come immagine
linktitle: Sfondo intera diapositiva
type: docs
weight: 95
url: /it/androidjava/get-the-entire-presentation-slide-background-as-an-image/
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
- Android
- Java
- Aspose.Slides
description: "Estrai sfondi completi delle diapositive come immagini da presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Android via Java, semplificando i flussi di lavoro visivi."
---
## **Panoramica**

Nelle presentazioni PowerPoint, lo sfondo di una diapositiva può essere costituito da più elementi, tra cui l'immagine di sfondo della diapositiva, il tema della presentazione, lo schema di colori e gli oggetti posizionati sulla diapositiva master o sulla diapositiva layout.

Questo articolo mostra come estrarre l'intero sfondo della diapositiva come immagine utilizzando Aspose.Slides per .NET. Poiché non esiste un unico metodo per questa operazione, l'approccio prevede di clonare la diapositiva selezionata in una presentazione temporanea, rimuovere le forme della diapositiva e quindi convertire lo sfondo risultante in un'immagine.

## **Ottenere l'intero sfondo della diapositiva**

Aspose.Slides per Android via Java non fornisce un metodo semplice per estrarre l'intero sfondo della diapositiva della presentazione come immagine, ma è possibile seguire i passaggi seguenti per farlo:
1. Caricare la presentazione usando la [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) classe.
1. Ottenere le dimensioni della diapositiva dalla presentazione.
1. Selezionare una diapositiva.
1. Creare una presentazione temporanea.
1. Impostare le stesse dimensioni della diapositiva nella presentazione temporanea.
1. Clonare la diapositiva selezionata nella presentazione temporanea.
1. Eliminare le forme dalla diapositiva clonata.
1. Convertire la diapositiva clonata in un'immagine.

Il seguente esempio di codice estrae l'intero sfondo della diapositiva della presentazione come immagine.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **Domande frequenti**

**I gradienti complessi, le trame o i riempimenti immagine da una diapositiva master verranno conservati nell'immagine di sfondo risultante?**

Sì. Aspose.Slides renderizza riempimenti a gradiente, immagine e trama definiti sulla diapositiva, sul layout o sul master. Se è necessario isolare l'aspetto dai master ereditati, [impostare uno sfondo proprio](/slides/it/androidjava/presentation-background/) sulla diapositiva corrente prima di esportare.

**Posso aggiungere una filigrana all'immagine di sfondo risultante prima di salvarla?**

Sì. È possibile [aggiungere una filigrana](/slides/it/androidjava/watermark/) forma o immagine su una [copia della diapositiva](/slides/it/androidjava/clone-slides/) di lavoro (posizionata dietro altri contenuti) e quindi esportare. Questo consente di generare un'immagine di sfondo con la filigrana incorporata.

**Posso ottenere lo sfondo per un layout o un master specifico senza associarlo a una diapositiva esistente?**

Sì. Accedere al master o layout desiderato, applicarlo a una [diapositiva temporanea](/slides/it/androidjava/clone-slides/) con le dimensioni necessarie e esportare quella diapositiva per ottenere lo sfondo derivato da quel layout o master.

**Ci sono limitazioni di licenza che influenzano l'esportazione delle immagini?**

Le funzionalità di rendering sono pienamente disponibili con una [licenza valida](/slides/it/androidjava/licensing/). In modalità valutazione, l'output può includere limitazioni come una filigrana. Attivare la licenza una volta per processo prima di eseguire esportazioni batch.