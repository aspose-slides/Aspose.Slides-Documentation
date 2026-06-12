---
title: Multithreading in Aspose.Slides per .NET
linktitle: Multithreading
type: docs
weight: 310
url: /it/net/multithreading/
keywords:
- multithreading
- thread multipli
- lavoro parallelo
- convertire diapositive
- diapositive in immagini
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Il multithreading di Aspose.Slides per .NET migliora l'elaborazione di PowerPoint e OpenDocument. Scopri le migliori pratiche per flussi di lavoro di presentazioni efficienti."
---
## **Introduzione**

Sebbene il lavoro parallelo con le presentazioni sia possibile (oltre alla analisi/caricamento/clonazione) e tutto proceda bene (nella maggior parte dei casi), c’è una piccola possibilità di ottenere risultati errati quando si utilizza la libreria in più thread.

Consigliamo vivamente di **non** utilizzare una singola istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) in un ambiente multithreading perché potrebbe causare errori o guasti imprevedibili difficili da rilevare. 

Non è **sicuro** caricare, salvare e/o clonare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) in più thread. Tali operazioni non sono **supportate**.  Se è necessario eseguire tali attività, è necessario parallelizzare le operazioni usando diversi processi single‑threaded—e ciascuno di questi processi deve utilizzare la propria istanza di presentazione. 

## **Converti le diapositive della presentazione in immagini in parallelo**

Supponiamo di voler convertire tutte le diapositive di una presentazione PowerPoint in immagini PNG in parallelo. Poiché non è sicuro utilizzare una singola istanza di `Presentation` in più thread, dividiamo le diapositive della presentazione in presentazioni separate e convertiamo le diapositive in immagini in parallelo, usando ogni presentazione in un thread separato. L’esempio di codice seguente mostra come farlo.

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // Estrai la diapositiva i in una presentazione separata.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Converti la diapositiva in un'immagine in un task separato.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```

## **FAQ**

**Devo chiamare l'impostazione della licenza in ogni thread?**

No. È sufficiente farlo una sola volta per processo/ dominio dell’app prima che i thread vengano avviati. Se [license setup](/slides/it/net/licensing/) potrebbe essere invocato simultaneamente (ad esempio durante l’inizializzazione lazy), sincronizza quella chiamata perché il metodo di impostazione della licenza non è thread‑safe.

**Posso passare oggetti `Presentation` o `Slide` tra thread?**

Passare oggetti di presentazione "live" tra thread non è consigliato: usa istanze indipendenti per thread o precrea presentazioni/container di diapositive separati per ciascun thread. Questo approccio segue la raccomandazione generale di non condividere una singola istanza di presentazione tra thread.

**È sicuro parallelizzare l'esportazione in diversi formati (PDF, HTML, immagini) a condizione che ogni thread abbia la propria istanza `Presentation`?**

Sì. Con istanze indipendenti e percorsi di output separati, tali attività di solito si parallelizzano correttamente; evita qualsiasi oggetto di presentazione condiviso e flussi I/O condivisi.

**Cosa devo fare con le impostazioni globali dei font (cartelle, sostituzioni) nel multithreading?**

Inizializza tutte le impostazioni globali dei font prima di avviare i thread e non modificarle durante il lavoro parallelo. Questo elimina le condizioni di gara quando si accede a risorse di font condivise.