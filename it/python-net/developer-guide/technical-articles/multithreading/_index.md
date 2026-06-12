---
title: Multithreading in Aspose.Slides per Python
linktitle: Multithreading
type: docs
weight: 200
url: /it/python-net/multithreading/
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
- Aspose.Slides
description: "Aspose.Slides per Python tramite multithreading .NET aumenta l'elaborazione di PowerPoint e OpenDocument. Scopri le migliori pratiche per flussi di lavoro di presentazioni efficienti."
---
## **Introduzione**

Mentre è possibile eseguire lavori in parallelo con le presentazioni (oltre a parsing/caricamento/clonazione) e tutto funziona bene (nella maggior parte dei casi), c'è una piccola possibilità che si ottengano risultati errati quando si utilizza la libreria in più thread.

Raccomandiamo vivamente di **non** utilizzare una singola [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) istanza in un ambiente multithreading perché potrebbe causare errori o guasti imprevedibili che non sono facilmente rilevabili.

Non è **sicuro** caricare, salvare e/o clonare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) in più thread. Tali operazioni **non** sono supportate.  Se è necessario eseguire tali operazioni, è necessario parallelizzarle usando diversi processi monothread—e ciascuno di questi processi dovrebbe usare la propria istanza di presentazione.

## **Converti le diapositive della presentazione in immagini in parallelo**

Supponiamo di voler convertire tutte le diapositive di una presentazione PowerPoint in immagini PNG in parallelo. Poiché non è sicuro utilizzare una singola istanza `Presentation` in più thread, suddividiamo le diapositive della presentazione in presentazioni separate e convertiamo le diapositive in immagini in parallelo, usando ogni presentazione in un thread separato. Il seguente esempio di codice mostra come fare.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Estrai la diapositiva i in una presentazione separata.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Converti la diapositiva in un'immagine.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Attendi che tutte le attività siano completate.
for task in conversion_tasks:
    task.result()

del presentation
```

## **FAQ**

**Devo chiamare la configurazione della licenza in ogni thread?**

No. È sufficiente farlo una volta per processo/ dominio dell'applicazione prima che i thread vengano avviati. Se la [license setup](/slides/it/python-net/licensing/) può essere invocata contemporaneamente (ad esempio durante l'inizializzazione pigra), sincronizzare quella chiamata poiché il metodo di configurazione della licenza stesso non è thread‑safe.

**Posso passare oggetti `Presentation` o `Slide` tra i thread?**

Passare oggetti di presentazione "live" tra i thread non è consigliato: utilizzare istanze indipendenti per thread o precreare presentazioni/contenitori di diapositive separati per ogni thread. Questo approccio segue la raccomandazione generale di non condividere un'unica istanza di presentazione tra i thread.

**È sicuro parallelizzare l'esportazione in diversi formati (PDF, HTML, immagini) a condizione che ogni thread abbia la propria istanza `Presentation`?**

Sì. Con istanze indipendenti e percorsi di output separati, tali operazioni solitamente si parallelizzano correttamente; evitare oggetti di presentazione condivisi e stream I/O condivisi.

**Cosa devo fare con le impostazioni globali dei font (cartelle, sostituzioni) nel multithreading?**

Inizializzare tutte le impostazioni globali dei font prima di avviare i thread e non modificarle durante il lavoro parallelo. Questo elimina le condizioni di gara quando si accede a risorse di font condivise.