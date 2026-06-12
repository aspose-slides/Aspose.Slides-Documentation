---
title: Ottieni l'intero sfondo della diapositiva da una presentazione come immagine
linktitle: Sfondo intero della diapositiva
type: docs
weight: 95
url: /it/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositiva
- sfondo
- sfondo della diapositiva
- sfondo finale
- sfondo in immagine
- PowerPoint
- OpenDocument
- presentazione
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Estrai i sfondi completi delle diapositive come immagini da presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python tramite .NET, semplificando i flussi di lavoro visivi."
---
## **Panoramica**

Nelle presentazioni PowerPoint, lo sfondo di una diapositiva può essere costituito da più elementi, inclusi l'immagine di sfondo della diapositiva, il tema della presentazione, lo schema di colori e gli oggetti posizionati sulla diapositiva master o sulla diapositiva di layout.

Questo articolo mostra come estrarre l'intero sfondo di una diapositiva come immagine utilizzando Aspose.Slides. Poiché non esiste un unico metodo per questa operazione, l'approccio prevede la clonazione della diapositiva selezionata in una presentazione temporanea, la rimozione delle forme della diapositiva e quindi la conversione dello sfondo risultante in un'immagine.

## **Ottieni l'intero sfondo della diapositiva**

Aspose.Slides per Python non fornisce un metodo semplice per estrarre l'intero sfondo della diapositiva della presentazione come immagine, ma è possibile seguire i passaggi seguenti per farlo:
1. Carica la presentazione utilizzando la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni le dimensioni della diapositiva dalla presentazione.
1. Seleziona una diapositiva.
1. Crea una presentazione temporanea.
1. Imposta le stesse dimensioni della diapositiva nella presentazione temporanea.
1. Clona la diapositiva selezionata nella presentazione temporanea.
1. Elimina le forme dalla diapositiva clonata.
1. Converti la diapositiva clonata in un'immagine.

Il seguente esempio di codice estrae l'intero sfondo della diapositiva della presentazione come immagine.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```

## **FAQ**

**I gradienti complessi, le texture o i riempimenti immagine da una diapositiva master saranno conservati nell’immagine di sfondo risultante?**

Sì. Aspose.Slides rende i riempimenti a gradiente, immagine e texture definiti sulla diapositiva, sul layout o sul master. Se è necessario isolare l’aspetto dai master ereditati, [imposta uno sfondo proprio](/slides/it/python-net/presentation-background/) sulla diapositiva corrente prima dell’esportazione.

**Posso aggiungere una filigrana all’immagine di sfondo risultante prima di salvarla?**

Sì. È possibile [aggiungere una filigrana](/slides/it/python-net/watermark/) come forma o immagine su una [copia di lavoro della diapositiva](/slides/it/python-net/clone-slides/) (collocata dietro gli altri contenuti) e quindi esportare. In questo modo si può generare un’immagine di sfondo con la filigrana incorporata.

**Posso ottenere lo sfondo per un layout o master specifico senza associarlo a una diapositiva esistente?**

Sì. Accedi al master o layout desiderato, applicalo a una [diapositiva temporanea](/slides/it/python-net/clone-slides/) con le dimensioni richieste ed esporta quella diapositiva per ottenere lo sfondo derivato da quel layout o master.

**Esistono limitazioni di licenza che influenzano l’esportazione delle immagini?**

Le funzionalità di rendering sono pienamente disponibili con una [licenza valida](/slides/it/python-net/licensing/). In modalità di valutazione, l'output può includere limitazioni come una filigrana. Attiva la licenza una volta per processo prima di eseguire esportazioni batch.