---
title: Ottenere l'intero sfondo della diapositiva da una presentazione come immagine
linktitle: Sfondo intero della diapositiva
type: docs
weight: 95
url: /it/python-java/get-the-entire-presentation-slide-background-as-an-image/
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
- Python
- Java
- Aspose.Slides
description: "Estrai gli sfondi completi delle diapositive come immagini da presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Python via Java, semplificando i flussi di lavoro visuali."
---
## **Panoramica**

Nelle presentazioni PowerPoint, lo sfondo di una diapositiva può essere composto da più elementi, tra cui l'immagine di sfondo della diapositiva, il tema della presentazione, lo schema di colori e gli oggetti posizionati sulla diapositiva master o sulla diapositiva layout.

Questo articolo mostra come estrarre l'intero sfondo della diapositiva come immagine utilizzando Aspose.Slides per Python via Java. Poiché non esiste un metodo singolo per questa operazione, l'approccio prevede di clonare la diapositiva selezionata in una presentazione temporanea, rimuovere le forme della diapositiva e quindi convertire lo sfondo risultante in un'immagine.

## **Ottenere l'intero sfondo della diapositiva**

Aspose.Slides per Python via Java non fornisce un metodo semplice per estrarre l'intero sfondo della diapositiva di una presentazione come immagine, ma è possibile seguire i passaggi seguenti per farlo:

1. Caricare la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottenere le dimensioni della diapositiva dalla presentazione.
1. Selezionare una diapositiva.
1. Creare una presentazione temporanea.
1. Impostare le stesse dimensioni della diapositiva nella presentazione temporanea.
1. Clonare la diapositiva selezionata nella presentazione temporanea.
1. Eliminare le forme dalla diapositiva clonata.
1. Convertire la diapositiva clonata in un'immagine.

Il seguente esempio di codice estrae l'intero sfondo della diapositiva della presentazione come immagine.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**I gradienti complessi, le texture o i riempimenti immagine da una diapositiva master saranno conservati nell'immagine di sfondo risultante?**

Sì. Aspose.Slides rende i riempimenti a gradiente, immagine e texture definiti sulla diapositiva, layout o master. Se è necessario isolare l'aspetto dai master ereditati, [impostare uno sfondo personalizzato](/slides/it/python-java/presentation-background/) sulla diapositiva corrente prima dell'esportazione.

**Posso aggiungere una filigrana all'immagine di sfondo risultante prima di salvarla?**

Sì. È possibile [aggiungere una filigrana](/slides/it/python-java/watermark/) sotto forma di forma o immagine su una [copia della diapositiva](/slides/it/python-java/clone-slides/) (posizionata dietro gli altri contenuti) e poi esportare. Questo consente di generare un'immagine di sfondo con la filigrana incorporata.

**Posso ottenere lo sfondo per un layout o master specifico senza collegarlo a una diapositiva esistente?**

Sì. Accedere al master o layout desiderato, applicarlo a una [diapositiva temporanea](/slides/it/python-java/clone-slides/) con le dimensioni richieste ed esportare quella diapositiva per ottenere lo sfondo derivato da quel layout o master.

**Ci sono limitazioni di licenza che influiscono sull'esportazione delle immagini?**

Le funzionalità di rendering sono pienamente disponibili con una [licenza valida](/slides/it/python-java/licensing/). In modalità di valutazione, l'output può includere limitazioni come una filigrana. Attivare la licenza una volta per processo prima di eseguire esportazioni batch.