---
title: Converti diapositive PowerPoint in PNG con Python
linktitle: PowerPoint in PNG
type: docs
weight: 30
url: /it/python-java/convert-powerpoint-to-png/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- PowerPoint in PNG
- presentazione in PNG
- diapositiva in PNG
- PPT in PNG
- PPTX in PNG
- salvare PPT come PNG
- salvare PPTX come PNG
- esportare PPT in PNG
- esportare PPTX in PNG
- Python
- Java
- Aspose.Slides
description: "Converti diapositive PowerPoint in immagini PNG con Python via Java. Esporta presentazioni PPT, PPTX e ODP con scale personalizzate o dimensioni immagine precise."
---
## **Panoramica**

Questo articolo spiega come convertire presentazioni PowerPoint in immagini PNG utilizzando Aspose.Slides per Python via Java. È possibile caricare file PPT, PPTX e ODP, renderizzare ogni diapositiva e salvarla come immagine PNG separata.

Gli esempi mostrano anche come controllare le dimensioni dell'output tramite fattori di scala o una larghezza e altezza precise. Ogni esempio avvia la macchina virtuale Java se necessario e rilascia le risorse della presentazione e dell'immagine dopo l'uso.

## **Converti PowerPoint in PNG**

1. Carica il file di input con la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Recupera le diapositive usando [Presentation.getSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlides).
3. Renderizza ogni diapositiva usando [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage).
4. Salva ogni immagine renderizzata con [ImageFormat.Png](https://reference.aspose.com/slides/it/python-java/aspose.slides/imageformat/#Png), quindi rilascia le relative risorse.

Il seguente esempio Python esporta tutte le diapositive con le loro dimensioni predefinite:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Converti PowerPoint in PNG con una scala personalizzata**

Passa i fattori di scala orizzontali e verticali a [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) per aumentare o diminuire le dimensioni dell'output. Ad esempio, una diapositiva di 720 × 540 punti renderizzata con un fattore di scala di 2 su entrambi gli assi produce un'immagine di 1440 × 1080 pixel.

Usa fattori di scala uguali per preservare il rapporto d'aspetto della diapositiva. Fattori diversi allungano la diapositiva orizzontalmente o verticalmente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Converti PowerPoint in PNG con una dimensione personalizzata**

Per specificare dimensioni pixel precise, passa un oggetto Java `Dimension` con la larghezza e l'altezza desiderate a [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage). Scegli dimensioni con lo stesso rapporto d'aspetto della diapositiva di origine per evitare distorsioni.

Il seguente esempio salva ogni diapositiva come immagine PNG di 960 × 720 pixel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Posso esportare una forma individuale, come un grafico o un'immagine, invece dell'intera diapositiva?**

Sì. Aspose.Slides supporta la generazione di miniature per forme individuali, che è possibile salvare come immagini PNG. [/slides/it/python-java/create-shape-thumbnails/]

**Posso convertire presentazioni in parallelo su un server?**

Utilizza un'istanza di presentazione separata per ogni thread o processo e usa percorsi di output unici per evitare che i file vengano sovrascritti. Non condividere un'istanza di presentazione tra thread. Vedi [/slides/it/python-java/multithreading/].

**Quali sono le limitazioni della versione di prova durante l'esportazione in PNG?**

La modalità di valutazione aggiunge una filigrana alle immagini di output e applica altre restrizioni. Applica una licenza per rimuovere queste limitazioni. [/slides/it/python-java/licensing/]