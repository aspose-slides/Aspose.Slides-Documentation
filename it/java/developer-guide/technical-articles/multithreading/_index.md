---
title: Multithreading in Aspose.Slides per Java
linktitle: Multithreading
type: docs
weight: 310
url: /it/java/multithreading/
keywords:
- multithreading
- thread multipli
- lavoro parallelo
- convertire diapositive
- diapositive in immagini
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Il multithreading di Aspose.Slides per Java accelera l'elaborazione di PowerPoint e OpenDocument. Scopri le migliori pratiche per flussi di lavoro di presentazioni efficienti."
---
## **Introduzione**

Mentre il lavoro parallelo con le presentazioni è possibile (oltre alla analisi/caricamento/clonazione) e tutto procede bene (nella maggior parte dei casi), c’è una piccola possibilità di ottenere risultati errati quando si utilizza la libreria in più thread.

Raccomandiamo vivamente di **non** utilizzare una singola istanza di [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) in un ambiente multithread perché potrebbe causare errori o guasti imprevedibili difficili da rilevare.

Non è **sicuro** caricare, salvare e/o clonare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) in più thread. Tali operazioni **non** sono supportate.  Se è necessario eseguire queste operazioni, è necessario parallelizzarle usando diversi processi monothread—e ciascuno di questi processi dovrebbe utilizzare la propria istanza di presentazione. 

## **Convertire le diapositive di una presentazione in immagini in parallelo**

Supponiamo di voler convertire tutte le diapositive di una presentazione PowerPoint in immagini PNG in parallelo. Poiché non è sicuro utilizzare una singola istanza di `Presentation` in più thread, dividiamo le diapositive della presentazione in presentazioni separate e convertiamo le diapositive in immagini in parallelo, usando ogni presentazione in un thread separato. L’esempio di codice seguente mostra come fare questo.

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Estrai la diapositiva i in una presentazione separata.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // Converti la diapositiva in un'immagine in un'attività separata.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// Attendi il completamento di tutte le attività.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **FAQ**

**Devo chiamare la configurazione della licenza in ogni thread?**

No. È sufficiente farlo una sola volta per processo/area di app prima dell’avvio dei thread. Se la [license setup](/slides/it/java/licensing/) può essere invocata contemporaneamente (ad esempio durante l’inizializzazione lazy), sincronizzate quella chiamata poiché il metodo di configurazione della licenza stesso non è thread‑safe.

**Posso passare oggetti `Presentation` o `Slide` tra i thread?**

Passare oggetti di presentazione "live" tra i thread non è consigliato: utilizzare istanze indipendenti per thread o pre‑creare presentazioni/contenitori di diapositive separati per ogni thread. Questo approccio segue la raccomandazione generale di non condividere una singola istanza di presentazione tra thread.

**È sicuro parallelizzare l’esportazione in formati diversi (PDF, HTML, immagini) a condizione che ogni thread abbia la propria istanza di `Presentation`?**

Sì. Con istanze indipendenti e percorsi di output separati, tali attività si parallelizzano correttamente nella maggior parte dei casi; evitare oggetti di presentazione condivisi e flussi I/O condivisi.

**Cosa devo fare con le impostazioni globali dei font (cartelle, sostituzioni) nel multithreading?**

Inizializzare tutte le [font settings](/slides/it/java/powerpoint-fonts/) globali prima di avviare i thread e non modificarle durante il lavoro parallelo. Questo elimina le condizioni di gara quando si accede a risorse di font condivise.