---
title: Multithreading in Aspose.Slides per Python tramite Java
linktitle: Multithreading
type: docs
weight: 310
url: /it/python-java/multithreading/
keywords:
- multithreading
- thread multipli
- lavoro parallelo
- convertire diapositive
- diapositive in immagini
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Il multithreading di Aspose.Slides per Python tramite Java migliora l'elaborazione di PowerPoint e OpenDocument. Scopri le migliori pratiche per flussi di lavoro di presentazione efficienti."
---
## **Introduzione**

Sebbene il lavoro parallelo con le presentazioni sia possibile (ad eccezione dell'analisi, del caricamento e della clonazione) e di solito funzioni bene, esiste una piccola probabilità di risultati errati quando si utilizza la libreria in più thread.

Raccomandiamo vivamente di **non** utilizzare una singola [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) istanza in un ambiente multithread perché potrebbe produrre errori o guasti imprevedibili difficili da rilevare.

Non è **sicuro** caricare, salvare e/o clonare una [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) istanza in più thread. Tali operazioni non sono supportate. Se è necessario eseguire queste attività, è necessario parallelizzare le operazioni utilizzando diversi processi a thread singolo - e ciascuno di questi processi deve utilizzare la propria istanza di presentazione.

## **Converti le diapositive della presentazione in immagini in parallelo**

Supponiamo di voler convertire tutte le diapositive di una presentazione PowerPoint in immagini PNG in parallelo. Poiché non è sicuro utilizzare una singola [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) istanza in più thread, dividiamo le diapositive della presentazione in presentazioni separate e convertiamo le diapositive in immagini in parallelo, utilizzando ogni presentazione in un thread separato. Il seguente esempio di codice mostra come fare.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Estrai la diapositiva in una presentazione separata.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Converti la diapositiva in un'immagine in un'attività separata.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Attendi il completamento di tutte le attività.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **FAQ**

**Devo chiamare la configurazione della licenza in ogni thread?**

No. È sufficiente farlo una volta per processo prima dell'avvio dei thread. Se la [license setup](/slides/it/python-java/licensing/) può essere invocata contemporaneamente (ad esempio, durante l'inizializzazione pigra), sincronizza quella chiamata perché il metodo di configurazione della licenza non è thread-safe.

**Posso passare oggetti [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) o [Slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/) tra thread?**

Passare oggetti di presentazione "live" tra thread non è consigliato: utilizzare istanze indipendenti per thread o creare presentazioni separate o contenitori di diapositive per ciascun thread in anticipo. Questo approccio segue la raccomandazione generale di non condividere una singola istanza di presentazione tra thread.

**È sicuro parallelizzare l'esportazione in diversi formati (PDF, HTML, immagini) a condizione che ogni thread abbia la propria istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/)?**

Sì. Con istanze indipendenti e percorsi di output separati, tali attività di solito si parallelizzano correttamente; evitare qualsiasi oggetto di presentazione condiviso e flussi I/O condivisi.

**Cosa devo fare con le impostazioni globali dei font (cartelle, sostituzioni) nel multithreading?**

Inizializza tutte le [font settings](/slides/it/python-java/powerpoint-fonts/) globali prima di avviare i thread e non modificarle durante il lavoro parallelo. Questo elimina le condizioni di gara nell'accesso alle risorse dei font condivisi.