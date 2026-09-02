---
title: Unire Presentazioni in Modo Efficiente con Python
linktitle: Unisci Presentazioni
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

Aspose.Slides per Python via .NET unisce presentazioni clonando le diapositive da una [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) a un'altra. L'operazione principale è [SlideCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/), che può preservare la formattazione della diapositiva originale o collegare la diapositiva clonata a un master o a un layout nella presentazione di destinazione.

Questo articolo copre i flussi di lavoro di unione più comuni:

- unire tutte le diapositive preservando la formattazione originale;
- unire diapositive selezionate;
- applicare un master dalla presentazione di destinazione;
- applicare un layout specifico dalla presentazione di destinazione;
- normalizzare diverse dimensioni delle diapositive prima dell'unione;
- aggiungere diapositive clonate a una sezione;
- unire più presentazioni in un unico flusso di lavoro end-to-end;
- gestire master, risorse, note, commenti, media, font, password, file di grandi dimensioni e problematiche di multithreading.

## **Come il Clonare le Diapositive Influisce su Master e Layout**

Una diapositiva eredita gran parte del suo aspetto dal suo layout e dal master. Per questo motivo, la variante di overload di clonazione che scegli determina come la diapositiva unita viene integrata nella presentazione di destinazione.

Usa [SlideCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/) in uno di questi modi:

- `add_clone(source_slide)` — preserva il layout e la formattazione della diapositiva di origine. Quando necessario, il master di origine può essere clonato automaticamente nella presentazione di destinazione. Aspose.Slides tiene traccia dei master clonati automaticamente in modo che le diapositive ripetute che usano lo stesso master di origine non causino un clonaggio ripetuto di quel master.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — collega la diapositiva clonata a un [IMasterSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasterslide/) di destinazione specifico. Aspose.Slides ricerca un layout corrispondente sotto quel master in base al tipo o al nome del layout.
- `add_clone(source_slide, destination_layout)` — collega direttamente la diapositiva clonata a un [ILayoutSlide](https://reference.aspose.com/slides/it/python-net/aspose.slides/ilayoutslide/) di destinazione specifico.

Il master o il layout passato a una overload `add_clone` deve appartenere alla presentazione **di destinazione**, non a quella di origine.

## **Unire Presentazioni Intere e Conservare la Formattazione di Origine**

L'unione più semplice copia ogni diapositiva dalla presentazione di origine a quella di destinazione. Questa è la scelta appropriata quando le diapositive importate devono mantenere il tema, il master e le relazioni di layout originali.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

La presentazione risultante può contenere più master quando l'origine e la destinazione usano design diversi. Questo è previsto quando la formattazione di origine viene preservata intenzionalmente.

## **Unire Diapositive Selezionate**

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

Convalida gli indici delle diapositive prima di clonare quando provengono da input utente o da configurazioni esterne.

## **Unire Diapositive Usando un Master di Destinazione**

Utilizza la overload [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/) quando le diapositive importate devono seguire un master che appartiene già alla presentazione di destinazione.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides seleziona un layout appropriato sotto il master specificato confrontando il tipo o il nome del layout di origine. Se non esiste un layout adatto e `allow_clone_missing_layout` è `True`, il layout di origine viene clonato così che la diapositiva possa essere aggiunta. Se è `False`, viene generata una [PptxEditException](https://reference.aspose.com/slides/it/python-net/aspose.slides/pptxeditexception/).

Usa `False` quando vuoi che l'unione fallisca invece di introdurre un layout aggiuntivo nel master di destinazione.

## **Unire Diapositive Usando un Layout di Destinazione Specifico**

Utilizza la overload [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/) quando sai esattamente quale layout di destinazione devono utilizzare le diapositive importate.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

Applicare un layout di destinazione modifica la relazione di layout ereditata; non ridisegna il contenuto della diapositiva di origine. Se i layout di origine e destinazione hanno strutture di segnaposto diverse, ispeziona il risultato per confermare che la formattazione ereditata e il comportamento dei segnaposto siano appropriati.

## **Unire Presentazioni con Dimensioni di Diapositiva Diverse**

Le presentazioni con dimensioni di diapositiva diverse possono essere unite, ma clonare una diapositiva in una presentazione con un'altra dimensione non ridisegna automaticamente il suo contenuto per la nuova area. Le forme possono quindi apparire spostate, scalate in modo inatteso o fuori dall'area visibile della diapositiva.

Un approccio pratico è ridimensionare la presentazione di origine prima di clonare. Il metodo [SlideSize.set_size](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidesize/set_size/) può ridimensionare il contenuto esistente modificando le dimensioni della diapositiva. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidesizescaletype/) scala il contenuto affinché rientri nella dimensione richiesta.

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

## **Unire Diapositive in una Sezione della Presentazione**

Il ciclo di clonazione diapositive di base non ricrea la gerarchia delle sezioni della presentazione di origine. Se le sezioni sono importanti nell'output, crea o seleziona sezioni nella presentazione di destinazione e clona le diapositive in esse esplicitamente con [SlideCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/).

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

Le diapositive clonate vengono aggiunte alla sezione di destinazione specificata. Per preservare più sezioni di origine, elenca [Presentation.sections](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/sections/), recupera le diapositive correnti di ciascuna sezione di origine con [Section.get_slides_list_of_section](https://reference.aspose.com/slides/it/python-net/aspose.slides/section/get_slides_list_of_section/), ricrea le sezioni nella destinazione e clona ciascuna diapositiva restituita nella sua corrispondente sezione di destinazione. Vedi [Gestire le Sezioni delle Diapositive](/slides/it/python-net/slide-section/) per un esempio completo di enumerazione delle sezioni, incluse sezioni vuote e modifiche strutturali.

## **Unire più Presentazioni in modo Sicuro**

Il seguente esempio end-to-end utilizza la prima presentazione come destinazione, normalizza le dimensioni delle diapositive di ogni fonte aggiuntiva, mantiene ogni fonte aperta solo mentre viene copiata e salva il file finale una sola volta.

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

Questo è un utile punto di partenza per preservare la formattazione di origine delle diapositive importate. Se il tuo output deve utilizzare un unico tema di destinazione, sostituisci la semplice chiamata `add_clone(slide)` con la overload master di destinazione o layout di destinazione appropriata mostrata in precedenza.

## **Considerazioni Pratiche**

### **Master, Layout e Fedeltà della Formattazione**

Il clonaggio diapositive predefinito può portare automaticamente un master di origine necessario nella presentazione di destinazione. Aspose.Slides mantiene un registro interno per i master clonati automaticamente, così da evitare di clonare più volte lo stesso master. I master clonati manualmente non sono tracciati da quel registro, quindi evita di pre-clonare i master a meno che non ti serva un controllo esplicito sulla struttura dei master.

Non presumere che due master o layout con lo stesso nome siano visivamente equivalenti. Se un modello aziendale deve controllare l'aspetto finale, scegli esplicitamente un master o un layout di destinazione e verifica il risultato dopo l'unione.

### **Note e Commenti**

Le note del relatore e i commenti delle diapositive sono associati al contenuto della diapositiva e vengono copiate quando una diapositiva è clonata. Aspose.Slides espone anche API dedicate per [note della presentazione](/slides/it/python-net/presentation-notes/) e [commenti della presentazione](/slides/it/python-net/presentation-comments/).

Se la formattazione della pagina delle note è importante, verifica la presentazione unita perché i master delle note sono oggetti a livello di presentazione e possono differire tra i file di origine. Per flussi di revisione, verifica anche gli autori dei commenti e i commenti in thread dopo aver combinato file provenienti da autori o modelli diversi.

### **Immagini, Audio, Video, Oggetti OLE e Collegamenti Esterni**

Le diapositive possono fare riferimento a risorse a livello di presentazione, come immagini, audio incorporato, video incorporato e dati OLE. Clona l'intera diapositiva anziché copiare solo le forme visibili affinché Aspose.Slides possa mantenere le relazioni della diapositiva con le sue risorse.

Le risorse incorporate e quelle collegate devono essere gestite diversamente. Un audio, video, oggetto OLE o collegamento ipertestuale collegato rimane dipendente dal suo obiettivo esterno; clonare una diapositiva non trasforma un collegamento esterno in contenuto incorporato. Testa i percorsi e gli URL delle risorse collegate nell'ambiente in cui la presentazione unita verrà aperta.

Aspose.Slides tiene esplicitamente traccia dei master clonati automaticamente, ma ciò non deve essere considerato una garanzia generale che risorse binarie identiche provenienti da presentazioni di origine non correlate vengano sempre deduplicate. Se la dimensione del file di output è importante, ispeziona il pacchetto unito e misura il risultato invece di fare affidamento sulla deduplicazione implicita.

### **Font Incorporati e Disponibilità dei Font**

I font sono gestiti a livello di presentazione. Se la tipografia deve rimanere coerente su più macchine, non presumere che il semplice clonare le diapositive garantisca che tutti i font richiesti siano disponibili nell'ambiente di destinazione. Puoi ispezionare i font incorporati con [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) e gestire l'incorporamento esplicitamente come descritto in [Incorporare Font nelle Presentazioni](/slides/it/python-net/embedded-font/).

Verifica anche di avere il permesso di incorporare i font usati nei file di origine. Le licenze dei font possono limitare l'incorporamento.

### **Presentazioni Protette da Password**

Una fonte protetta da password deve essere aperta con successo prima che le sue diapositive possano essere clonate. Fornisci la password tramite [LoadOptions.password](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/password/).

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

Aprire una fonte crittografata non applica automaticamente la stessa protezione alla presentazione di destinazione. Configura la protezione di output separatamente quando necessario.

### **Presentazioni di grandi dimensioni e uso della memoria**

Le presentazioni di grandi dimensioni contenenti immagini ad alta risoluzione, audio, video o altri oggetti binari di grandi dimensioni possono consumare molta memoria. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/blob_management_options/) fornisce controlli per la gestione dei BLOB e l'uso di file temporanei. Vedi [Gestire i BLOB della Presentazione](/slides/it/python-net/manage-blob/) per strategie su file di grandi dimensioni.

Per file di grandi dimensioni, preferisci il caricamento da percorsi di file quando possibile, chiudi ogni presentazione di origine appena è stata unita e evita di salvare ripetutamente risultati intermedi a meno che il flusso di lavoro non richieda checkpoint. L'uso di `with slides.Presentation(...)` garantisce che le risorse della presentazione vengano rilasciate all'uscita del contesto.

### **Sicurezza dei Thread**

Non caricare, salvare o clonare un'istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) contemporaneamente da più thread. Mantieni ogni operazione di unione a thread singolo. Se parallelizzi lavori di unione indipendenti, utilizza processi separati a thread singolo e istanze di presentazione indipendenti come descritto nella [guida al multithreading di Aspose.Slides](/slides/it/python-net/multithreading/).

## **FAQ**

**Come posso mantenere il design originale di ogni presentazione di origine?**

Usa [add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/) senza fornire un master o un layout di destinazione. Aspose.Slides può clonare automaticamente il master di origine quando è necessario per la diapositiva importata.

**Come faccio a far utilizzare alle diapositive importate il tema di destinazione?**

Usa la overload che accetta un master di destinazione. Passa un master dalla presentazione di destinazione, non da quella di origine. Aspose.Slides cercherà di mappare ogni diapositiva di origine a un layout appropriato sotto quel master.

**Quando dovrei usare un layout di destinazione specifico invece di un master di destinazione?**

Usa un layout specifico quando ogni diapositiva importata deve utilizzare un layout noto. Usa un master quando vuoi che Aspose.Slides selezioni tra i layout di quel master in base al tipo o al nome del layout di origine.

**È possibile unire presentazioni con dimensioni di diapositiva diverse?**

Sì, ma il contenuto delle diapositive non viene ridisegnato automaticamente per le dimensioni di destinazione. Ridimensiona prima la presentazione di origine quando hai bisogno di un posizionamento prevedibile, ad esempio con [SlideSize.set_size](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidesize/set_size/) e [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidesizescaletype/).

**Posso unire presentazioni PPT, PPTX e ODP in un unico file?**

Sì. Carica ogni presentazione di origine, clona le diapositive necessarie in una destinazione e salva la destinazione in un formato di output supportato. Poiché i formati delle presentazioni non supportano esattamente lo stesso set di funzionalità, verifica i contenuti complessi dopo unioni cross-format. Vedi [Formati di File Supportati](/slides/it/python-net/supported-file-formats/).

**Le sezioni di origine vengono preservate automaticamente?**

No, non con un ciclo base che clona solo le diapositive. Ricrea le sezioni necessarie nella destinazione e usa la overload di sezione di [add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_clone/) quando la struttura delle sezioni deve essere preservata.

**Le note del relatore e i commenti vengono preservati?**

Vengono copiate insieme alla diapositiva clonata. Per i flussi di lavoro che dipendono dallo stile del master delle note, dagli autori dei commenti o dai dati di revisione a thread, verifica il risultato unito perché tali scenari coinvolgono strutture a livello di presentazione oltre al contenuto a livello di diapositiva.

**Cosa succede ad audio, video, oggetti OLE e collegamenti ipertestuali?**

I contenuti incorporati vengono trasportati come parte delle relazioni delle risorse della diapositiva clonata. I collegamenti esterni rimangono esterni, quindi i file o gli URL di destinazione devono comunque essere disponibili dopo l'unione.

**I font incorporati da ogni origine sono garantiti disponibili nella presentazione unita?**

Non fare affidamento solo sul clonare le diapositive per la distribuzione dei font. Ispeziona i font incorporati nella destinazione e gestisci esplicitamente l'incorporamento dei font o la disponibilità di font esterni quando la tipografia è importante.

**Come unisco un file protetto da password?**

Aprilo con la corretta [LoadOptions.password](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/password/), poi clona le sue diapositive normalmente. La protezione di output viene configurata separatamente.

**Come dovrei gestire presentazioni molto grandi?**

Usa la gestione dei BLOB quando gli oggetti binari di grandi dimensioni dominano l'uso della memoria, preferisci il caricamento da percorsi di file per file molto grandi, chiudi rapidamente le presentazioni di origine e salva il risultato finale solo quando necessario.

**Posso unire diapositive da più thread?**

Non caricare, salvare o clonare istanze di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) in più thread. Mantieni ogni operazione di unione a thread singolo; usa processi separati a thread singolo se devi parallelizzare lavori di unione indipendenti.