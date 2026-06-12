---
title: Ottieni l'intero sfondo della diapositiva da una presentazione come immagine
linktitle: Sfondo intero della diapositiva
type: docs
weight: 95
url: /it/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- sfondo diapositiva
- sfondo finale
- estrazione sfondo
- sfondo completo
- sfondo in immagine
- sfondo PPT
- sfondo PPTX
- sfondo ODP
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Estrai gli sfondi completi delle diapositive come immagini da presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per .NET, semplificando i flussi di lavoro visuali."
---
## **Panoramica**

Nelle presentazioni PowerPoint, lo sfondo di una diapositiva può essere costituito da più elementi, inclusi l'immagine di sfondo della diapositiva, il tema della presentazione, lo schema colori e gli oggetti posizionati sulla diapositiva master o sulla diapositiva layout.

Questo articolo mostra come estrarre l’intero sfondo della diapositiva come immagine utilizzando Aspose.Slides per .NET. Poiché non esiste un metodo unico per questa operazione, l’approccio prevede di clonare la diapositiva selezionata in una presentazione temporanea, rimuovere le forme della diapositiva e quindi convertire lo sfondo risultante in un’immagine.

## **Ottenere l’intero sfondo della diapositiva**

Aspose.Slides per .NET non fornisce un metodo semplice per estrarre l’intero sfondo di una diapositiva della presentazione come immagine, ma è possibile seguire i passaggi seguenti:
1. Caricare la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottenere le dimensioni della diapositiva dalla presentazione.
1. Selezionare una diapositiva.
1. Creare una presentazione temporanea.
1. Impostare le stesse dimensioni della diapositiva nella presentazione temporanea.
1. Clonare la diapositiva selezionata nella presentazione temporanea.
1. Eliminare le forme dalla diapositiva clonata.
1. Convertire la diapositiva clonata in un’immagine.

Il seguente esempio di codice estrae l’intero sfondo della diapositiva della presentazione come immagine.
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```

## **FAQ**

**I gradienti complessi, le trame o i riempimenti immagine da una diapositiva master verranno preservati nell’immagine di sfondo risultante?**

Sì. Aspose.Slides rende i riempimenti di gradiente, immagine e trama definiti sulla diapositiva, layout o master. Se è necessario isolare l’aspetto dai master ereditati, [set an own background](/slides/it/net/presentation-background/) sulla diapositiva corrente prima dell’esportazione.

**Posso aggiungere una filigrana all’immagine di sfondo risultante prima di salvarla?**

Sì. È possibile [add a watermark](/slides/it/net/watermark/) forma o immagine su una [copy of the slide](/slides/it/net/clone-slides/) di lavoro (posizionata dietro gli altri contenuti) e poi esportare. Questo consente di generare un’immagine di sfondo con la filigrana incorporata.

**Posso ottenere lo sfondo per un layout o master specifico senza collegarlo a una diapositiva esistente?**

Sì. Accedere al master o layout desiderato, applicarlo a una [temporary slide](/slides/it/net/clone-slides/) con le dimensioni richieste e esportare quella diapositiva per ottenere lo sfondo derivato da quel layout o master.

**Ci sono limitazioni di licenza che influenzano l’esportazione delle immagini?**

Le funzionalità di rendering sono completamente disponibili con una [valid license](/slides/it/net/licensing/). In modalità di valutazione, l’output potrebbe includere limitazioni come una filigrana. Attivare la licenza una volta per processo prima di eseguire esportazioni batch.