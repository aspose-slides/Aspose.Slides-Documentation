---
title: Multithreading in Aspose.Slides per C++
linktitle: Multithreading
type: docs
weight: 200
url: /it/cpp/multithreading/
keywords:
- multithreading
- thread multipli
- lavoro parallelo
- convertire diapositive
- diapositive in immagini
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Il multithreading di Aspose.Slides per C++ potenzia l'elaborazione di PowerPoint e OpenDocument. Scopri le migliori pratiche per flussi di lavoro di presentazione efficienti."
---
## **Introduzione**

Mentre il lavoro parallelo con le presentazioni è possibile (oltre a parsing/caricamento/clonazione) e tutto procede bene (la maggior parte delle volte), c'è una piccola possibilità che si ottengano risultati errati quando si usa la libreria in più thread.

Raccomandiamo vivamente di **non** utilizzare un singolo [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) in un ambiente multithread perché potrebbe causare errori o guasti imprevedibili che non sono facilmente rilevabili.

Non è **sicuro** caricare, salvare e/o clonare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) in più thread. Tali operazioni **non** sono supportate. Se è necessario eseguire queste attività, è necessario parallelizzare le operazioni utilizzando diversi processi monothread — e ciascun processo deve utilizzare la propria istanza di presentazione.

## **Converti le diapositive della presentazione in immagini in parallelo**

Supponiamo di voler convertire tutte le diapositive di una presentazione PowerPoint in immagini PNG in parallelo. Poiché non è sicuro utilizzare una singola istanza `Presentation` in più thread, dividiamo le diapositive della presentazione in presentazioni separate e convertiamo le diapositive in immagini in parallelo, utilizzando ciascuna presentazione in un thread distinto. Il seguente esempio di codice mostra come farlo.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Estrai la diapositiva i in una presentazione separata.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Converti la diapositiva in un'immagine in un'attività separata.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// Attendi che tutte le attività siano completate.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **FAQ**

**Devo chiamare la configurazione della licenza in ogni thread?**

No. È sufficiente farlo una volta per processo/domain dell'app prima dell'avvio dei thread. Se la [license setup](/slides/it/cpp/licensing/) potrebbe essere invocata contemporaneamente (ad esempio durante l'inizializzazione pigra), sincronizzare quella chiamata perché il metodo di configurazione della licenza stesso non è thread‑safe.

**Posso passare oggetti `Presentation` o `Slide` tra thread?**

Passare oggetti di presentazione "live" tra thread non è consigliato: utilizzare istanze indipendenti per thread o pre‑creare presentazioni/container diapositive separati per ciascun thread. Questo approccio segue la raccomandazione generale di non condividere una singola istanza di presentazione tra thread.

**È sicuro parallelizzare l'esportazione in formati diversi (PDF, HTML, immagini) a condizione che ogni thread abbia la propria istanza `Presentation`?**

Sì. Con istanze indipendenti e percorsi di output separati, tali attività si parallelizzano correttamente nella maggior parte dei casi; evitare qualsiasi oggetto di presentazione condiviso e flussi I/O condivisi.

**Cosa devo fare con le impostazioni globali dei font (cartelle, sostituzioni) nel multithreading?**

Inizializzare tutte le impostazioni globali dei font prima di avviare i thread e non modificarle durante il lavoro parallelo. Questo elimina le condizioni di gara quando si accede a risorse di font condivise.