---
title: Unire presentazioni in modo efficiente con JavaScript
linktitle: Unisci presentazioni
type: docs
weight: 40
url: /it/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come unire presentazioni PowerPoint e OpenDocument in JavaScript clonando le diapositive, controllando master e layout, ridimensionando il contenuto delle diapositive, preservando le sezioni e gestendo file protetti o di grandi dimensioni."
---
## **Panoramica**

Aspose.Slides per Node.js tramite Java unisce presentazioni clonando diapositive da una [Presentazione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) a un'altra. L'operazione principale è [SlideCollection.addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), che può preservare la formattazione della diapositiva di origine o collegare la diapositiva clonata a un master o a un layout nella presentazione di destinazione.

Questo articolo copre i flussi di lavoro di unione più comuni:

- unire tutte le diapositive mantenendo la formattazione di origine;
- unire diapositive selezionate;
- applicare un master dalla presentazione di destinazione;
- applicare un layout specifico dalla presentazione di destinazione;
- normalizzare diverse dimensioni delle diapositive prima dell'unione;
- aggiungere diapositive clonate a una sezione;
- unire più presentazioni in un unico flusso di lavoro end‑to‑end;
- gestire master, risorse, note, commenti, media, caratteri, password, file di grandi dimensioni e problematiche di multithreading.

## **Come la clonazione delle diapositive influisce su Master e Layout**

Una diapositiva eredita gran parte del suo aspetto dal layout e dal master. Per questo motivo, il sovraccarico di clonazione scelto determina come la diapositiva unita viene integrata nella presentazione di destinazione.

Usa [SlideCollection.addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/) in uno dei seguenti modi:

- `addClone(sourceSlide)` — preserva il layout e la formattazione della diapositiva di origine. Se necessario, il master di origine può essere clonato automaticamente nella presentazione di destinazione. Aspose.Slides tiene traccia dei master clonati automaticamente in modo che diapositive ripetute che usano lo stesso master di origine non provocino il clono ripetuto di quel master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — collega la diapositiva clonata a un [MasterSlide] specifico di destinazione. Aspose.Slides cerca un layout corrispondente sotto quel master per tipo di layout o nome.
- `addClone(sourceSlide, destinationLayout)` — collega la diapositiva clonata direttamente a un [LayoutSlide] specifico di destinazione.

Il master o il layout passato a un sovraccarico `addClone` deve appartenere alla **presentazione di destinazione**, non a quella di origine.

## **Unire intere presentazioni mantenendo la formattazione di origine**

L'unione più semplice copia ogni diapositiva dalla presentazione di origine alla presentazione di destinazione. Questa è la scelta appropriata quando le diapositive importate devono conservare il tema, il master e le relazioni di layout originali.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

La presentazione risultante può contenere più master quando l'origine e la destinazione usano design diversi. Questo è previsto quando la formattazione di origine è intenzionalmente preservata.

## **Unire diapositive selezionate**

Non è necessario clonare ogni diapositiva. L'esempio seguente importa solo gli indici di diapositiva selezionati dalla presentazione di origine.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Convalida gli indici delle diapositive prima della clonazione quando provengono da input dell'utente o da configurazioni esterne.

## **Unire diapositive usando un Master di destinazione**

Usa il sovraccarico [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) quando le diapositive importate devono seguire un master che già appartiene alla presentazione di destinazione.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides seleziona un layout appropriato sotto il master specificato in base al tipo o al nome del layout di origine. Se non esiste un layout adatto e `allowCloneMissingLayout` è `true`, il layout di origine viene clonato così la diapositiva può essere aggiunta. Se è `false`, viene generata un'[PptxEditException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxeditexception/).

Usa `false` quando vuoi che l'unione fallisca invece di introdurre un layout aggiuntivo nel master di destinazione.

## **Unire diapositive usando un Layout di destinazione specifico**

Usa il sovraccarico [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) quando sai esattamente quale layout di destinazione devono utilizzare le diapositive importate.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

L'applicazione di un layout di destinazione modifica la relazione di layout ereditata; non ridisegna il contenuto della diapositiva di origine. Se i layout di origine e destinazione hanno strutture di segnaposto diverse, ispeziona il risultato per confermare che la formattazione e il comportamento dei segnaposto ereditati siano appropriati.

## **Unire presentazioni con dimensioni di diapositiva diverse**

Le presentazioni con dimensioni di diapositiva differenti possono essere unite, ma clonare una diapositiva in una presentazione con un'altra dimensione non ridisegna automaticamente il suo contenuto per il nuovo canvas. Le forme possono quindi apparire spostate, scalate in modo imprevisto o fuori dall'area visibile della diapositiva.

Un approccio pratico è ridimensionare la presentazione di origine prima della clonazione. Il metodo [SlideSize.setSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) può ridimensionare il contenuto esistente cambiando le dimensioni della diapositiva. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesizescaletype/) ridimensiona il contenuto per adattarlo alla dimensione richiesta.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Il ridimensionamento modifica l'oggetto della presentazione di origine in memoria. Se hai bisogno che la presentazione di origine rimanga invariata per altre operazioni, apri un'istanza separata per l'unione.

## **Unire diapositive in una sezione della presentazione**

Il ciclo base di clonazione delle diapositive non ricrea la gerarchia delle sezioni della presentazione di origine. Se le sezioni sono importanti nell'output, crea o seleziona le sezioni nella presentazione di destinazione e clona le diapositive in esse esplicitamente con [addClone(Slide, Section)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Le diapositive clonate vengono aggiunte alla sezione di destinazione specificata. Per preservare più sezioni di origine, enumera [Presentation.getSections](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSections), recupera le diapositive correnti di ciascuna sezione di origine con [Section.getSlidesListOfSection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/section/#getSlidesListOfSection), ricrea le sezioni nella destinazione e clona ogni diapositiva restituita nella sezione di destinazione corrispondente. Vedi [Gestire le sezioni delle diapositive](/slides/it/nodejs-java/slide-section/) per un esempio completo di enumerazione delle sezioni, incluse sezioni vuote e modifiche strutturali.

## **Unire più presentazioni in modo sicuro**

L'esempio end‑to‑end seguente usa la prima presentazione come destinazione, normalizza la dimensione delle diapositive di ciascuna fonte aggiuntiva, mantiene aperta ogni fonte solo durante la copia e salva il file finale una sola volta.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Questo è un utile punto di partenza per preservare la formattazione di origine delle diapositive importate. Se il tuo output deve usare un unico tema di destinazione, sostituisci la semplice chiamata `addClone(sourceSlide)` con il sovraccarico master‑di destinazione o layout‑di destinazione mostrato in precedenza.

## **Considerazioni pratiche**

### **Master, Layout e fedeltà della formattazione**

La clonazione predefinita delle diapositive può introdurre automaticamente un master di origine necessario nella presentazione di destinazione. Aspose.Slides mantiene un registro interno per i master clonati automaticamente, evitando di clonare lo stesso master più volte. I master clonati manualmente non sono tracciati da quel registro, quindi evita di pre‑clonare i master a meno che non ti serva un controllo esplicito sulla struttura del master.

Non dare per scontato che due master o layout con lo stesso nome siano visualmente equivalenti. Se un modello aziendale deve controllare l'aspetto finale, scegli esplicitamente un master o un layout di destinazione e verifica il risultato dopo l'unione.

### **Note e commenti**

Le note del relatore e i commenti alle diapositive sono associati al contenuto della diapositiva e vengono copiati quando una diapositiva è clonata. Aspose.Slides espone inoltre API dedicate per le [note della presentazione](/slides/it/nodejs-java/presentation-notes/) e i [commenti della presentazione](/slides/it/nodejs-java/presentation-comments/).

Se la formattazione della pagina delle note è importante, verifica la presentazione unita perché i master delle note sono oggetti a livello di presentazione e possono differire tra i file di origine. Per i flussi di revisione, verifica anche gli autori dei commenti e i commenti annidati dopo aver combinato file provenienti da autori o modelli diversi.

### **Immagini, audio, video, oggetti OLE e collegamenti esterni**

Le diapositive possono fare riferimento a risorse a livello di presentazione come immagini, audio incorporato, video incorporato e dati OLE. Clona la diapositiva stessa anziché copiare solo le forme visibili affinché Aspose.Slides mantenga le relazioni della diapositiva con le sue risorse.

Le risorse incorporate e quelle collegate devono essere trattate in modo diverso. Un audio, video, oggetto OLE o collegamento ipertestuale collegato rimane dipendente dal suo bersaglio esterno; clonare una diapositiva non trasforma un collegamento esterno in contenuto incorporato. Verifica i percorsi e gli URL delle risorse collegate nell'ambiente in cui la presentazione unita sarà aperta.

Aspose.Slides traccia esplicitamente i master clonati automaticamente, ma questo non deve essere considerato una garanzia generale che risorse binarie identiche provenienti da presentazioni sorgente non correlate saranno sempre deduplicate. Se la dimensione del file di output è importante, ispeziona il pacchetto unito e misura il risultato invece di affidarti a una deduplicazione implicita.

### **Font incorporati e disponibilità dei font**

I font sono gestiti a livello di presentazione. Se la tipografia deve rimanere coerente su più macchine, non dare per scontato che la sola clonazione delle diapositive garantisca la disponibilità di tutti i font necessari nell'ambiente di destinazione. Puoi ispezionare i font incorporati con [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) e gestire l'incorporazione esplicitamente come descritto in [Incorporare i font nelle presentazioni](/slides/it/nodejs-java/embedded-font/).

Verifica inoltre di avere i permessi per incorporare i font usati nei file di origine. Le licenze dei font possono limitare l'incorporazione.

### **Presentazioni protette da password**

Una fonte protetta da password deve essere aperta con successo prima che le sue diapositive possano essere clonate. Fornisci la password tramite [LoadOptions.setPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Lavorare con la presentazione decrittata.
} finally {
    source.dispose();
}
```

Aprire una fonte crittografata non applica automaticamente la stessa protezione alla presentazione di destinazione. Configura la protezione di output separatamente quando necessario.

### **Presentazioni di grandi dimensioni e utilizzo della memoria**

Le presentazioni di grandi dimensioni contenenti immagini ad alta risoluzione, audio, video o altri oggetti binari voluminosi possono consumare molta memoria. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) fornisce controlli per la gestione dei BLOB e l'uso di file temporanei. Vedi [Gestire i BLOB della presentazione](/slides/it/nodejs-java/manage-blob/) per strategie su file di grandi dimensioni.

Per file di grandi dimensioni, preferisci il caricamento da percorsi file quando possibile, elimina ogni presentazione di origine non appena è stata unita e evita di salvare ripetutamente risultati intermedi a meno che il flusso di lavoro non richieda punti di controllo.

### **Sicurezza dei thread**

Non caricare, salvare o clonare un'istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) in più thread. Queste operazioni non sono supportate per l'uso multithread. Se devi parallelizzare lavori di unione indipendenti, utilizza più processi monothread, ciascuno con le proprie istanze di presentazione, e segui le linee guida sul [multithreading di Aspose.Slides](/slides/it/nodejs-java/multithreading/).

## **FAQ**

**Come posso mantenere il design originale di ogni presentazione di origine?**

Usa [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) senza fornire un master o un layout di destinazione. Aspose.Slides può clonare automaticamente il master di origine quando è necessario per la diapositiva importata.

**Come faccio a far utilizzare alle diapositive importate il tema di destinazione?**

Usa il sovraccarico che accetta un master di destinazione. Fornisci un master dalla presentazione di destinazione, non da quella di origine. Aspose.Slides cercherà di mappare ogni diapositiva di origine a un layout appropriato sotto quel master.

**Quando devo usare un layout di destinazione specifico anziché un master di destinazione?**

Usa un layout specifico quando ogni diapositiva importata deve utilizzare un layout noto. Usa un master quando vuoi che Aspose.Slides selezioni tra i layout di quel master in base al tipo o al nome del layout di origine.

**È possibile unire presentazioni con dimensioni di diapositiva diverse?**

Sì, ma il contenuto della diapositiva non viene ridisegnato automaticamente per le dimensioni di destinazione. Ridimensiona prima la presentazione di origine quando hai bisogno di posizionamenti prevedibili, ad esempio con [SlideSize.setSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) e [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesizescaletype/).

**Posso unire presentazioni PPT, PPTX e ODP in un unico file?**

Sì. Carica ogni presentazione di origine, clona le diapositive necessarie in una destinazione e salva la destinazione in un formato di output supportato. Poiché i formati di presentazione non supportano esattamente lo stesso set di funzionalità, verifica il contenuto complesso dopo unioni cross‑format. Vedi [Formati di file supportati](/slides/it/nodejs-java/supported-file-formats/).

**Le sezioni di origine vengono preserve automaticamente?**

No, non con un semplice ciclo che clona solo le diapositive. Ricrea le sezioni necessarie nella destinazione e usa il sovraccarico di sezione di [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) quando la struttura delle sezioni deve essere preservata.

**Le note del relatore e i commenti vengono preservati?**

Sì, vengono copiati con la diapositiva clonata. Per i flussi di lavoro che dipendono dallo stile del master delle note, dagli autori dei commenti o dai dati di revisione annidata, verifica il risultato unito perché tali scenari coinvolgono strutture a livello di presentazione oltre al contenuto delle diapositive.

**Cosa succede ad audio, video, oggetti OLE e collegamenti ipertestuali?**

Il contenuto incorporato viene trasportato come parte delle relazioni delle risorse della diapositiva clonata. I collegamenti esterni rimangono esterni, quindi i file di destinazione o gli URL devono comunque essere disponibili dopo l'unione.

**I font incorporati da ogni fonte sono garantiti nel file unito?**

Non fare affidamento solo sulla clonazione delle diapositive per distribuire i font. Ispeziona i font incorporati nella destinazione e gestisci esplicitamente l'incorporazione dei font o la disponibilità di font esterni quando la tipografia è importante.

**Come unisco un file protetto da password?**

Aprilo con il corretto [LoadOptions.setPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), quindi clona le sue diapositive normalmente. La protezione di output viene configurata separatamente.

**Come devo gestire presentazioni molto grandi?**

Usa la gestione dei BLOB quando gli oggetti binari dominano l'uso della memoria, preferisci il caricamento da percorsi file per file molto grandi, elimina rapidamente le presentazioni di origine e salva il risultato finale solo quando necessario.

**Posso unire diapositive da più thread?**

Non caricare, salvare o clonare istanze di presentazione in più thread. Per lavori di unione paralleli, utilizza processi monothread separati e istanze di presentazione indipendenti.