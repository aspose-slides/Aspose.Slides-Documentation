---
title: Multithreading in Aspose.Slides per Node.js tramite Java
linktitle: Multithreading
type: docs
weight: 310
url: /it/nodejs-java/multithreading/
keywords:
- multithreading
- thread multipli
- lavoro parallelo
- convertire diapositive
- diapositive in immagini
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Il multithreading di Aspose.Slides per Node.js tramite Java potenzia l'elaborazione di PowerPoint e OpenDocument. Scopri le migliori pratiche per flussi di lavoro di presentazione efficienti."
---
## **Introduzione**

Sebbene il lavoro parallelo con le presentazioni sia possibile (oltre a parsing/caricamento/clonazione) e tutto vada bene (nella maggior parte dei casi), c’è una piccola possibilità di ottenere risultati errati quando si utilizza la libreria in più thread.

Raccomandiamo vivamente di **non** utilizzare un’unica istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) in un ambiente multi-threading perché potrebbe causare errori o guasti imprevedibili difficili da rilevare.

Non è **sicuro** caricare, salvare e/o clonare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) in più thread. Tali operazioni **non** sono supportate. Se è necessario eseguire queste attività, è necessario parallelizzare le operazioni utilizzando diversi processi mono-thread e ciascuno di questi processi dovrebbe usare la propria istanza di presentazione.

## **Converti le diapositive della presentazione in immagini in parallelo**

Supponiamo di voler convertire tutte le diapositive di una presentazione PowerPoint in immagini PNG in parallelo. Poiché non è sicuro utilizzare un’unica istanza `Presentation` in più thread, suddiiviamo le diapositive della presentazione in presentazioni separate e convertiamo le diapositive in immagini in parallelo, usando ciascuna presentazione in un thread distinto. L’esempio di codice seguente mostra come farlo.

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // Estrai la diapositiva i in una presentazione separata.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // Attendere il completamento di tutte le attività.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **Domande frequenti**

**Devo chiamare la configurazione della licenza in ogni thread?**

No. È sufficiente farlo una volta per processo/domain dell’applicazione prima dell’avvio dei thread. Se la [configurazione della licenza](/slides/it/nodejs-java/licensing/) può essere invocata contemporaneamente (ad esempio durante l’inizializzazione lazy), sincronizza quella chiamata perché il metodo di configurazione della licenza non è thread‑safe.

**Posso passare oggetti `Presentation` o `Slide` tra i thread?**

Passare oggetti di presentazione “live” tra thread non è consigliato: usa istanze indipendenti per thread o crea in anticipo presentazioni/container di diapositive separati per ciascun thread. Questo approccio segue la raccomandazione generale di non condividere un’unica istanza di presentazione tra thread.

**È sicuro parallelizzare l’esportazione in formati diversi (PDF, HTML, immagini) a patto che ogni thread abbia la propria istanza `Presentation`?**

Sì. Con istanze indipendenti e percorsi di output separati, tali attività di solito si parallelizzano correttamente; evita qualsiasi oggetto di presentazione condiviso e stream I/O condivisi.

**Cosa devo fare con le impostazioni globali dei font (cartelle, sostituzioni) nel multithreading?**

Inizializza tutte le impostazioni globali dei font prima di avviare i thread e non modificarle durante il lavoro in parallelo. Questo elimina le condizioni di gara quando si accede a risorse di font condivise.