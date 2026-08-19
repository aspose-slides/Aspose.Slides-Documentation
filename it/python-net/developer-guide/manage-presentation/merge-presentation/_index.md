---
title: Unire presentazioni in modo efficiente con Python
linktitle: Unisci presentazioni
type: docs
weight: 40
url: /it/python-net/merge-presentation/
keywords:
- unire PowerPoint
- unire presentazioni
- unire diapositive
- unire PPT
- unire PPTX
- unire ODP
- combinare PowerPoint
- combinare presentazioni
- combinare diapositive
- combinare PPT
- combinare PPTX
- combinare ODP
- Python
- Aspose.Slides
description: "Scopri come unire presentazioni PowerPoint e OpenDocument in Python clonando le diapositive, controllando master e layout, ridimensionando il contenuto delle diapositive, preservando le sezioni e gestendo file protetti o di grandi dimensioni."
---
## **Panoramica**

Aspose.Slides per Python tramite .NET unisce presentazioni clonando le diapositive da una [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) a un'altra. L'operazione principale è [SlideCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/), che può preservare la formattazione della diapositiva di origine o collegare la diapositiva clonata a un master o a un layout nella presentazione di destinazione.

Questo articolo copre i flussi di lavoro di unione più comuni:

- unire tutte le diapositive preservando la formattazione di origine;
- unire le diapositive selezionate;
- applicare un master dalla presentazione di destinazione;
- applicare un layout specifico dalla presentazione di destinazione;
- normalizzare le diverse dimensioni delle diapositive prima dell'unione;
- aggiungere diapositive clonate a una sezione;
- unire più presentazioni in un unico flusso end‑to‑end;
- gestire master, risorse, note, commenti, media, caratteri, password, file di grandi dimensioni e problemi di multithreading.

## **Come la clonazione delle diapositive influisce su master e layout**

Una diapositiva eredita gran parte del suo aspetto dal suo layout e dal master. Per questo motivo, la sovraccarico di clonazione che scegli determina come la diapositiva unita viene integrata nella presentazione di destinazione.

Usa [SlideCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/) in uno di questi modi:

- `add_clone(source_slide)` — preserva il layout e la formattazione della diapositiva di origine. Quando necessario, il master di origine può essere clonato nella presentazione di destinazione automaticamente. Aspose.Slides tiene traccia dei master clonati automaticamente così le diapositive ripetute che usano lo stesso master di origine non causano la clonazione ripetuta di quel master.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — collega la diapositiva clonata a uno specifico [IMasterSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasterslide/). Aspose.Slides cerca un layout corrispondente sotto quel master per tipo di layout o nome.
- `add_clone(source_slide, destination_layout)` — collega direttamente la diapositiva clonata a un specifico [ILayoutSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/ilayoutslide/).

Il master o il layout passato a una sovraccarico `add_clone` deve appartenere alla presentazione **di destinazione**, non a quella di origine.

## **Unisci intere presentazioni e preserva la formattazione di origine**

L'unione più semplice copia ogni diapositiva dalla presentazione di origine alla presentazione di destinazione. Questa è la scelta appropriata quando le diapositive importate devono mantenere il tema originale, il master e le relazioni di layout.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

La presentazione risultante può contenere più master quando l'origine e la destinazione utilizzano design diversi. Questo è previsto quando la formattazione di origine viene preservata intenzionalmente.

## **Unisci diapositive selezionate**

Non è necessario clonare ogni diapositiva. L'esempio seguente importa solo gli indici delle diapositive selezionate dalla presentazione di origine.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

Convalida gli indici delle diapositive prima della clonazione quando provengono da input dell'utente o da configurazioni esterne.

## **Unisci diapositive usando un master di destinazione**

Utilizza la sovraccarico [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/) quando le diapositive importate devono seguire un master che appartiene già alla presentazione di destinazione.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides seleziona un layout appropriato sotto il master specificato corrispondendo al tipo o al nome del layout di origine. Se nessun layout adatto esiste e `allow_clone_missing_layout` è `True`, il layout di origine viene clonato così la diapositiva può essere aggiunta. Se è `False`, viene sollevata una [PptxEditException](https://reference.aspose.com/slides/it/python-net/aspose.slides/pptxeditexception/).

Usa `False` quando desideri che l'unione fallisca invece di introdurre un layout aggiuntivo nel master di destinazione.

## **Unisci diapositive usando un layout specifico di destinazione**

Utilizza la sovraccarico [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/) quando sai esattamente quale layout di destinazione le diapositive importate devono usare.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

L'applicazione di un layout di destinazione modifica la relazione di layout ereditata; non riprogetta il contenuto della diapositiva di origine. Se i layout di origine e destinazione hanno strutture di segnaposto diverse, ispeziona il risultato per confermare che la formattazione ereditata e il comportamento dei segnaposti siano appropriati.

## **Unisci presentazioni con dimensioni delle diapositive diverse**

Le presentazioni con dimensioni delle diapositive diverse possono essere unite, ma clonare una diapositiva in una presentazione con un'altra dimensione non riprogetta automaticamente il suo contenuto per il nuovo canvas. Le forme possono quindi apparire spostate, scalate in modo inaspettato o fuori dall'area visibile della diapositiva.

Un approccio pratico è ridimensionare la presentazione di origine prima della clonazione. Il metodo [SlideSize.set_size](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidesize/set_size/) può scalare il contenuto esistente cambiando le dimensioni della diapositiva. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidesizescaletype/) scala il contenuto per adattarlo alla dimensione richiesta.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

Il ridimensionamento modifica l'oggetto della presentazione di origine in memoria. Se hai bisogno della presentazione di origine originale invariata per altre operazioni, apri un'istanza separata per l'unione.

## **Unisci diapositive in una sezione della presentazione**

Il ciclo base di clonazione delle diapositive non ricrea la gerarchia delle sezioni della presentazione di origine. Se le sezioni sono importanti nell'output, crea o seleziona sezioni nella presentazione di destinazione e clona le diapositive in esse esplicitamente con [SlideCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/).

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

Le diapositive clonate vengono aggiunte alla sezione di destinazione specificata. Per preservare più sezioni di origine, ricrea quelle sezioni nella destinazione con [SectionCollection.append_empty_section](https://reference.aspose.com/slides/it/python-net/aspose.slides/sectioncollection/append_empty_section/) e associa ogni diapositiva di origine alla corrispondente sezione di destinazione.

## **Unisci più presentazioni in modo sicuro**

L'esempio end‑to‑end seguente utilizza la prima presentazione come destinazione, normalizza la dimensione delle diapositive di ogni ulteriore origine, mantiene ogni origine aperta solo durante la copia e salva il file finale una sola volta.

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Questo è un utile punto di partenza per preservare la formattazione di origine delle diapositive importate. Se il tuo output deve utilizzare un unico tema di destinazione, sostituisci la semplice chiamata `add_clone(slide)` con la sovraccarico di master o layout di destinazione appropriata mostrata in precedenza.

## **Considerazioni pratiche**

### **Master, layout e fedeltà della formattazione**

La clonazione predefinita delle diapositive può inserire automaticamente un master di origine necessario nella presentazione di destinazione. Aspose.Slides mantiene un registro interno per i master clonati automaticamente per evitare di clonare lo stesso master più volte. I master clonati manualmente non sono tracciati da quel registro, quindi evita di pre‑clonare i master a meno che non sia necessario un controllo esplicito sulla struttura del master.

Non presumere che due master o layout con lo stesso nome siano visualmente equivalenti. Se un modello aziendale deve controllare l'aspetto finale, scegli esplicitamente un master o layout di destinazione e verifica il risultato dopo l'unione.

### **Note e commenti**

Le note del relatore e i commenti delle diapositive sono associati al contenuto della diapositiva e vengono copiati quando una diapositiva viene clonata. Aspose.Slides espone inoltre API dedicate per [note della presentazione](https://docs.aspose.com/slides/it/python-net/presentation-notes/) e [commenti della presentazione](https://docs.aspose.com/slides/it/python-net/presentation-comments/).

Se la formattazione della pagina delle note è importante, verifica la presentazione unita perché i master delle note sono oggetti a livello di presentazione e possono differire tra i file di origine. Per i flussi di revisione, verifica anche gli autori dei commenti e i commenti in thread dopo aver combinato file da diversi autori o modelli.

### **Immagini, audio, video, oggetti OLE e collegamenti esterni**

Le diapositive possono fare riferimento a risorse a livello di presentazione come immagini, audio incorporato, video incorporato e dati OLE. Clona la diapositiva stessa invece di copiare solo le forme visibili così Aspose.Slides può mantenere le relazioni della diapositiva con le sue risorse.

Le risorse incorporate e collegate dovrebbero essere trattate diversamente. Un audio, video, oggetto OLE o hyperlink collegato rimane dipendente dal suo bersaglio esterno; clonare una diapositiva non trasforma un link esterno in contenuto incorporato. Testa i percorsi e gli URL delle risorse collegate nell'ambiente in cui la presentazione unita sarà aperta.

Aspose.Slides traccia esplicitamente i master clonati automaticamente, ma questo non deve essere considerato una garanzia generale che risorse binarie identiche da presentazioni di origine non correlate vengano sempre deduplicate. Se la dimensione del file di output è importante, ispeziona il pacchetto unito e misura il risultato invece di fare affidamento sulla deduplicazione implicita.

### **Caratteri incorporati e disponibilità dei caratteri**

I caratteri sono gestiti a livello di presentazione. Se la tipografia deve rimanere coerente tra macchine, non presumere che la sola clonazione delle diapositive garantisca che tutti i caratteri richiesti siano disponibili nell'ambiente di destinazione. Puoi ispezionare i caratteri incorporati con [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) e gestire l'incorporamento esplicitamente come descritto in [Incorpora i caratteri nelle presentazioni](https://docs.aspose.com/slides/it/python-net/embedded-font/).

Verifica anche di essere autorizzato a incorporare i caratteri usati nei file di origine. Le licenze dei caratteri possono limitare l'incorporamento.

### **Presentazioni protette da password**

Una sorgente protetta da password deve essere aperta con successo prima che le sue diapositive possano essere clonate. Fornisci la password tramite [LoadOptions.password](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/password/).

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

L'apertura di una sorgente crittata non applica automaticamente la stessa protezione alla presentazione di destinazione. Configura la protezione dell'output separatamente quando necessario.

### **Presentazioni di grandi dimensioni e utilizzo della memoria**

Le presentazioni di grandi dimensioni contenenti immagini ad alta risoluzione, audio, video o altri oggetti binari di grandi dimensioni possono consumare molta memoria. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/blob_management_options/) fornisce controlli per la gestione dei BLOB e l'uso di file temporanei. Vedi [Gestisci i BLOB delle presentazioni](https://docs.aspose.com/slides/it/python-net/manage-blob/) per strategie su file di grandi dimensioni.

Per i file di grandi dimensioni, preferisci il caricamento da percorsi di file quando possibile, chiudi ogni presentazione di origine appena è stata unita e evita di salvare ripetutamente risultati intermedi a meno che il flusso di lavoro richieda checkpoint. Usare `with slides.Presentation(...)` garantisce che le risorse della presentazione vengano rilasciate quando il contesto termina.

### **Sicurezza dei thread**

Non caricare, salvare o clonare un'istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) contemporaneamente da più thread. Mantieni ogni operazione di unione a thread singolo. Se parallelizzi lavori di unione indipendenti, usa processi separati a thread singolo e istanze di presentazione indipendenti come descritto nella [guida al multithreading di Aspose.Slides](https://docs.aspose.com/slides/it/python-net/multithreading/).

## **FAQ**

**Come mantengo il design originale di ciascuna presentazione di origine?**

Usa [`add_clone(source_slide)`](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/) senza fornire un master o layout di destinazione. Aspose.Slides può clonare automaticamente il master di origine quando è necessario per la diapositiva importata.

**Come faccio a far usare alle diapositive importate il tema di destinazione?**

Usa la sovraccarico che accetta un master di destinazione. Passa un master dalla presentazione di destinazione, non da quella di origine. Aspose.Slides cercherà di mappare ogni diapositiva di origine a un layout appropriato sotto quel master.

**Quando dovrei usare un layout di destinazione specifico invece di un master di destinazione?**

Usa un layout specifico quando ogni diapositiva importata deve usare un layout noto. Usa un master quando vuoi che Aspose.Slides selezioni tra i layout di quel master in base al tipo o al nome del layout di origine.

**Possono essere unite presentazioni con dimensioni delle diapositive diverse?**

Sì, ma il contenuto della diapositiva non viene riprogettato automaticamente per le dimensioni di destinazione. Ridimensiona prima la presentazione di origine quando hai bisogno di un posizionamento prevedibile, ad esempio con [SlideSize.set_size](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidesize/set_size/) e [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidesizescaletype/).

**Posso unire presentazioni PPT, PPTX e ODP in un unico file?**

Sì. Carica ogni presentazione di origine, clona le diapositive necessarie in una destinazione e salva la destinazione in un formato di output supportato. Poiché i formati delle presentazioni non supportano esattamente lo stesso insieme di funzionalità, verifica il contenuto complesso dopo unioni cross‑format. Vedi [Supported File Formats](https://docs.aspose.com/slides/it/python-net/supported-file-formats/).

**Le sezioni di origine vengono preservate automaticamente?**

No, non con un ciclo base che clona solo le diapositive. Ricrea le sezioni necessarie nella destinazione e usa la sovraccarico di sezione di [add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/) quando la struttura delle sezioni deve essere preservata.

**Le note del relatore e i commenti vengono preservati?**

Vengono copiati con la diapositiva clonata. Per flussi di lavoro che dipendono dallo stile del master delle note, dagli autori dei commenti o dai dati di revisione in thread, verifica il risultato unito perché questi scenari coinvolgono strutture a livello di presentazione oltre al contenuto a livello di diapositiva.

**Cosa succede ad audio, video, oggetti OLE e hyperlink?**

Il contenuto incorporato è trasportato come parte delle relazioni delle risorse della diapositiva clonata. I link esterni rimangono esterni, quindi i loro file di destinazione o URL devono essere ancora disponibili dopo l'unione.

**I caratteri incorporati da ogni origine sono garantiti disponibili nella presentazione unita?**

Non fare affidamento solo sulla clonazione delle diapositive per la distribuzione dei caratteri. Ispeziona i caratteri incorporati nella destinazione e gestisci esplicitamente l'incorporamento dei caratteri o la disponibilità di caratteri esterni quando la tipografia è importante.

**Come unisco un file protetto da password?**

Aprilo con la corretta [LoadOptions.password](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/password/), quindi clona le sue diapositive normalmente. La protezione dell'output viene configurata separatamente.

**Come gestire presentazioni molto grandi?**

Usa la gestione dei BLOB quando gli oggetti binari di grandi dimensioni dominano l'uso della memoria, preferisci il caricamento da percorso file per file molto grandi, chiudi rapidamente le presentazioni di origine e salva il risultato finale solo quando necessario.

**Posso unire diapositive da più thread?**

Non caricare, salvare o clonare istanze di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) in più thread. Mantieni ogni operazione di unione a thread singolo; usa processi indipendenti a thread singolo se devi parallelizzare lavori di unione separati.