---
title: Unisci presentazioni in modo efficiente in Python tramite Java
linktitle: Unisci presentazioni
type: docs
weight: 40
url: /it/python-java/merge-presentation/
keywords:
- unisci PowerPoint
- unisci presentazioni
- unisci diapositive
- unisci PPT
- unisci PPTX
- unisci ODP
- combina PowerPoint
- combina presentazioni
- combina diapositive
- combina PPT
- combina PPTX
- combina ODP
- Python
- Java
- Aspose.Slides
description: "Scopri come unire presentazioni PowerPoint e OpenDocument in Python tramite Java clonando le diapositive, controllando master e layout, ridimensionando il contenuto delle diapositive, preservando le sezioni e gestendo file protetti o di grandi dimensioni."
---
## **Panoramica**

Aspose.Slides per Python via Java unisce presentazioni clonando diapositive da una [Presentazione](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) a un'altra. L'operazione principale è [SlideCollection.addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone), che può preservare la formattazione della diapositiva di origine o collegare la diapositiva clonata a un master o a un layout nella presentazione di destinazione.

Questo articolo copre i flussi di lavoro di unione più comuni:

- unire tutte le diapositive preservando la formattazione di origine;
- unire le diapositive selezionate;
- applicare un master dalla presentazione di destinazione;
- applicare un layout specifico dalla presentazione di destinazione;
- normalizzare diverse dimensioni delle diapositive prima dell'unione;
- aggiungere diapositive clonate a una sezione;
- unire più presentazioni in un unico flusso di lavoro end‑to‑end;
- gestire master, risorse, note, commenti, media, caratteri, password, file di grandi dimensioni e problematiche di multithreading.

## **Come la clonazione delle diapositive influisce su Master e Layout**

Una diapositiva eredita gran parte del suo aspetto dal layout e dal master. Per questo motivo, la sovraccarico di clonazione che scegli determina come la diapositiva unita viene integrata nella presentazione di destinazione.

Usa [SlideCollection.addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone) in uno di questi modi:

- `addClone(source_slide)` — preserva il layout e la formattazione della diapositiva di origine. Se necessario, il master di origine può essere clonato automaticamente nella presentazione di destinazione. Aspose.Slides tiene traccia dei master clonati automaticamente in modo che le diapositive ripetute che usano lo stesso master di origine non causino la clonazione ripetuta di quel master.
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — collega la diapositiva clonata a un [MasterSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/) di destinazione specifico. Aspose.Slides cerca un layout corrispondente sotto quel master per tipo o nome di layout.
- `addClone(source_slide, destination_layout)` — collega direttamente la diapositiva clonata a un [LayoutSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/) di destinazione specifico.

Il master o layout fornito a una sovraccarico di `addClone` deve appartenere alla presentazione **di destinazione**, non a quella di origine.

## **Unire intere presentazioni preservando la formattazione di origine**

L'unione più semplice copia ogni diapositiva dalla presentazione di origine a quella di destinazione. Questa è la scelta appropriata quando le diapositive importate devono mantenere il tema, il master e le relazioni di layout originali.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

La presentazione risultante può contenere più master quando la sorgente e la destinazione usano design differenti. Questo è previsto quando la formattazione di origine è intenzionalmente preservata.

## **Unire diapositive selezionate**

Non è necessario clonare ogni diapositiva. L'esempio seguente importa solo gli indici di diapositiva selezionati dalla presentazione di origine.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        slide_indexes = [0, 2, 4]
        for index in slide_indexes:
            if 0 <= index < source.getSlides().size():
                destination.getSlides().addClone(source.getSlides().get_Item(index))
            else:
                print(f"Skipping invalid slide index: {index}")
    finally:
        source.dispose()

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Convalida gli indici delle diapositive prima della clonazione quando provengono da input dell'utente o da configurazioni esterne.

## **Unire diapositive usando un master di destinazione**

Usa la sovraccarico di [SlideCollection.addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone) quando le diapositive importate devono seguire un master che appartiene già alla presentazione di destinazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_master = destination.getMasters().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_master, True)
    finally:
        source.dispose()

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Aspose.Slides seleziona un layout appropriato sotto il master specificato confrontando il tipo o il nome del layout di origine. Se non esiste un layout adeguato e `allow_clone_missing_layout` è `True`, il layout di origine viene clonato così la diapositiva può essere aggiunta. Se è `False`, viene generata una `PptxEditException`.

Usa `False` quando desideri che l'unione fallisca invece di introdurre un layout aggiuntivo nel master di destinazione.

## **Unire diapositive usando un layout di destinazione specifico**

Usa la sovraccarico di [SlideCollection.addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone) quando sai esattamente quale layout di destinazione le diapositive importate devono usare.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_layout = destination.getLayoutSlides().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_layout)
    finally:
        source.dispose()

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Applicare un layout di destinazione modifica la relazione di layout ereditata; non ridisegna il contenuto della diapositiva di origine. Se i layout di origine e destinazione hanno strutture di segnaposto differenti, ispeziona il risultato per confermare che la formattazione ereditata e il comportamento dei segnaposto siano appropriati.

## **Unire presentazioni con dimensioni di diapositiva differenti**

Le presentazioni con dimensioni di diapositiva differenti possono essere unite, ma clonare una diapositiva in una presentazione con un'altra dimensione non ridisegna automaticamente il suo contenuto per la nuova area. Le forme possono quindi apparire spostate, ridimensionate in modo inatteso o fuori dall'area visibile della diapositiva.

Un approccio pratico è ridimensionare la presentazione di origine prima della clonazione. Il metodo [SlideSize.setSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesize/#setSize) può scalare il contenuto esistente cambiando le dimensioni della diapositiva. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesizescaletype/) scala il contenuto per adattarlo alla dimensione richiesta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        source_size = source.getSlideSize().getSize()
        destination_size = destination.getSlideSize().getSize()
        width = jpype.JFloat(destination_size.getWidth())
        height = jpype.JFloat(destination_size.getHeight())
        if source_size.getWidth() != width or source_size.getHeight() != height:
            source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Il ridimensionamento modifica l'oggetto della presentazione di origine in memoria. Se hai bisogno che la presentazione di origine rimanga invariata per altre operazioni, apri un'istanza separata per l'unione.

## **Unire diapositive in una sezione della presentazione**

Il ciclo base di clonazione delle diapositive non ricrea la gerarchia delle sezioni della presentazione di origine. Se le sezioni sono importanti nell'output, crea o seleziona le sezioni nella presentazione di destinazione e clona le diapositive in esse esplicitamente con [SlideCollection.addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addClone).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        imported_section = destination.getSections().appendEmptySection("Imported slides")
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, imported_section)
    finally:
        source.dispose()

    destination.save("merged-with-section.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Le diapositive clonate vengono aggiunte alla sezione di destinazione specificata. Per preservare più sezioni di origine, elenca [Presentation.getSections](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSections), recupera le diapositive attuali di ciascuna sezione di origine con [Section.getSlidesListOfSection](https://reference.aspose.com/slides/it/python-java/aspose.slides/section/#getSlidesListOfSection), ricrea le sezioni nella destinazione e clona ogni diapositiva restituita nella sua corrispondente sezione di destinazione. Vedi [Gestione delle sezioni delle diapositive](/slides/it/python-java/slide-section/) per un esempio completo di enumerazione delle sezioni, incluse sezioni vuote e modifiche strutturali.

## **Unire più presentazioni in modo sicuro**

Il seguente esempio end‑to‑end usa la prima presentazione come destinazione, normalizza la dimensione della diapositiva di ciascuna fonte aggiuntiva, mantiene ogni fonte aperta solo mentre viene copiata e salva il file finale una sola volta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

merged = Presentation(input_files[0])
try:
    merged_size = merged.getSlideSize().getSize()
    width = jpype.JFloat(merged_size.getWidth())
    height = jpype.JFloat(merged_size.getHeight())

    for input_file in input_files[1:]:
        source = Presentation(input_file)
        try:
            source_size = source.getSlideSize().getSize()
            if source_size.getWidth() != width or source_size.getHeight() != height:
                source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

            for slide in source.getSlides():
                merged.getSlides().addClone(slide)
        finally:
            source.dispose()

    merged.save("merged.pptx", SaveFormat.Pptx)
finally:
    merged.dispose()
```

Questo è un utile punto di partenza per preservare la formattazione di origine delle diapositive importate. Se il tuo output deve usare un unico tema di destinazione, sostituisci la semplice chiamata `addClone(slide)` con la sovraccarico di destination‑master o destination‑layout mostrata in precedenza.

## **Considerazioni pratiche**

### **Master, Layout e fedeltà della formattazione**

La clonazione predefinita delle diapositive può portare automaticamente un master di origine necessario nella presentazione di destinazione. Aspose.Slides mantiene un registro interno per i master clonati automaticamente per evitare di clonare più volte lo stesso master. I master clonati manualmente non sono tracciati da quel registro, quindi evita di pre‑clonare i master a meno che tu non abbia bisogno di un controllo esplicito della struttura del master.

Non presumere che due master o layout con lo stesso nome siano visualmente equivalenti. Se un modello aziendale deve controllare l'aspetto finale, scegli esplicitamente un master o layout di destinazione e verifica il risultato dopo l'unione.

### **Note e commenti**

Le note del relatore e i commenti alle diapositive sono associati al contenuto della diapositiva e vengono copiati quando una diapositiva è clonata. Aspose.Slides espone anche API dedicate per [note di presentazione](/slides/it/python-java/presentation-notes/) e [commenti di presentazione](/slides/it/python-java/presentation-comments/).

Se la formattazione della pagina delle note è importante, verifica la presentazione unita perché i master delle note sono oggetti a livello di presentazione e possono differire tra i file di origine. Nei flussi di lavoro di revisione, verifica anche gli autori dei commenti e i commenti in thread dopo aver combinato file da autori o modelli diversi.

### **Immagini, Audio, Video, oggetti OLE e collegamenti esterni**

Le diapositive possono fare riferimento a risorse a livello di presentazione come immagini, audio incorporato, video incorporato e dati OLE. Clona la diapositiva stessa invece di copiare solo le forme visibili affinché Aspose.Slides mantenga le relazioni della diapositiva con le sue risorse.

Le risorse incorporate e collegate devono essere trattate diversamente. Un audio, video, oggetto OLE o iperlink collegato rimane dipendente dal suo target esterno; clonare una diapositiva non trasforma un collegamento esterno in contenuto incorporato. Testa i percorsi e gli URL delle risorse collegate nell'ambiente in cui la presentazione unita sarà aperta.

Aspose.Slides tiene esplicitamente traccia dei master clonati automaticamente, ma ciò non deve essere considerato una garanzia generale che le risorse binarie identiche provenienti da presentazioni di origine non correlate saranno sempre deduplicate. Se la dimensione del file di output è importante, ispeziona il pacchetto unito e misura il risultato invece di fare affidamento sulla deduplicazione implicita.

### **Caratteri incorporati e disponibilità dei caratteri**

I caratteri sono gestiti a livello di presentazione. Se la tipografia deve rimanere coerente tra macchine, non presumere che la sola clonazione delle diapositive garantisca che ogni carattere richiesto sia disponibile nell'ambiente di destinazione. Puoi ispezionare i caratteri incorporati con [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) e gestire l'incorporamento esplicitamente come descritto in [Incorporare i caratteri nelle presentazioni](/slides/it/python-java/embedded-font/).

Verifica inoltre di avere il permesso di incorporare i caratteri usati nei file di origine. Le licenze dei caratteri possono limitare l'incorporamento.

### **Presentazioni protette da password**

Una sorgente protetta da password deve essere aperta correttamente prima che le sue diapositive possano essere clonate. Fornisci la password tramite [LoadOptions.setPassword](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setPassword).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setPassword("YOUR_PASSWORD")

source = Presentation("protected.pptx", load_options)
try:
    # Lavora con la presentazione decrittata.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

Aprire una sorgente crittografata non applica automaticamente la stessa protezione alla presentazione di destinazione. Configura la protezione dell'output separatamente quando necessario.

### **Presentazioni di grandi dimensioni e utilizzo della memoria**

Le presentazioni di grandi dimensioni contenenti immagini ad alta risoluzione, audio, video o altri oggetti binari di grandi dimensioni possono consumare molta memoria. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) fornisce controlli per la gestione dei BLOB e l'uso di file temporanei. Vedi [Gestire i BLOB di presentazione](/slides/it/python-java/manage-blob/) per le strategie su file di grandi dimensioni.

Per file di grandi dimensioni, preferisci il caricamento da percorsi file quando possibile, elimina ogni presentazione di origine non appena è stata unita e evita di salvare ripetutamente risultati intermedi a meno che il flusso di lavoro richieda checkpoint.

### **Sicurezza dei thread**

Non caricare, modificare, salvare o clonare la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) contemporaneamente da più thread. Mantieni ogni istanza di presentazione confinata a una singola operazione di unione. Se parallelizzi lavori indipendenti, usa istanze di presentazione indipendenti e segui le [linee guida di multithreading di Aspose.Slides](/slides/it/python-java/multithreading/).

## **FAQ**

**Come posso mantenere il design originale di ogni presentazione di origine?**

Usa `addClone` senza fornire un master o un layout di destinazione. Aspose.Slides può clonare automaticamente il master di origine quando è necessario per la diapositiva importata.

**Come posso far sì che le diapositive importate usino il tema di destinazione?**

Usa la sovraccarico che accetta un master di destinazione. Passa un master dalla presentazione di destinazione, non da quella di origine. Aspose.Slides cercherà di mappare ogni diapositiva di origine a un layout appropriato sotto quel master.

**Quando dovrei usare un layout di destinazione specifico invece di un master di destinazione?**

Usa un layout specifico quando ogni diapositiva importata deve usare un layout noto. Usa un master quando vuoi che Aspose.Slides selezioni tra i layout di quel master in base al tipo o al nome del layout di origine.

**È possibile unire presentazioni con dimensioni di diapositiva diverse?**

Sì, ma il contenuto delle diapositive non viene ridisegnato automaticamente per le dimensioni di destinazione. Ridimensiona prima la presentazione di origine quando hai bisogno di un posizionamento prevedibile, ad esempio con `SlideSize.setSize` e `SlideSizeScaleType.EnsureFit`.

**Posso unire presentazioni PPT, PPTX e ODP in un unico file?**

Sì. Carica ogni presentazione di origine, clona le diapositive necessarie in una destinazione e salva la destinazione in un formato di output supportato. Poiché i formati di presentazione non supportano esattamente lo stesso set di funzionalità, verifica i contenuti complessi dopo le unioni cross‑format. Vedi [Formati di file supportati](/slides/it/python-java/supported-file-formats/) per i dettagli.

**Le sezioni di origine vengono preservate automaticamente?**

No, non con un semplice ciclo che clona solo le diapositive. Ricrea le sezioni necessarie nella destinazione e usa la sovraccarico di sezione di `addClone` quando la struttura delle sezioni deve essere preservata.

**Le note del relatore e i commenti vengono preservati?**

Vengono copiate con la diapositiva clonata. Per i flussi di lavoro che dipendono dallo stile del master delle note, dagli autori dei commenti o dai dati di revisione in thread, verifica il risultato unito perché questi scenari coinvolgono strutture a livello di presentazione così come contenuti a livello di diapositiva.

**Cosa succede ad audio, video, oggetti OLE e collegamenti ipertestuali?**

Il contenuto incorporato viene trasportato come parte delle relazioni di risorse della diapositiva clonata. I collegamenti esterni rimangono esterni, quindi i loro file di destinazione o URL devono essere ancora disponibili dopo l'unione.

**I caratteri incorporati da ogni sorgente sono garantiti disponibili nella presentazione unita?**

Non fare affidamento solo sulla clonazione delle diapositive per la distribuzione dei caratteri. Ispeziona i caratteri incorporati nella destinazione e gestisci esplicitamente l'incorporamento dei caratteri o la disponibilità di caratteri esterni quando la tipografia è importante.

**Come unisco un file protetto da password?**

Aprilo con il corretto `LoadOptions.setPassword`, poi clona le sue diapositive normalmente. La protezione dell'output è configurata separatamente.

**Come dovrei gestire presentazioni molto grandi?**

Usa la gestione dei BLOB quando gli oggetti binari di grandi dimensioni dominano l'uso della memoria, preferisci il caricamento da percorsi file per file molto grandi, elimina prontamente le presentazioni di origine e salva il risultato finale solo quando necessario.

**Posso unire diapositive da più thread?**

Non usare la stessa istanza di `Presentation` contemporaneamente da più thread. Mantieni ogni operazione di unione isolata nelle proprie istanze di presentazione.