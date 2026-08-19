---
title: Unisci Presentazioni in JavaScript in modo Efficiente
linktitle: Unisci Presentazioni
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

Aspose.Slides per Node.js tramite Java unisce presentazioni clonando le diapositive da una [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) a un'altra. L'operazione principale è [SlideCollection.addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), che può preservare la formattazione della diapositiva di origine o collegare la diapositiva clonata a un master o a un layout nella presentazione di destinazione.

Questo articolo copre i flussi di lavoro di unione più comuni:
- unire tutte le diapositive preservando la loro formattazione di origine;
- unire diapositive selezionate;
- applicare un master dalla presentazione di destinazione;
- applicare un layout specifico dalla presentazione di destinazione;
- normalizzare dimensioni delle diapositive diverse prima dell'unione;
- aggiungere diapositive clonate a una sezione;
- unire diverse presentazioni in un unico flusso end‑to‑end;
- gestire master, risorse, note, commenti, media, font, password, file di grandi dimensioni e problematiche di multithreading.

## **Come la clonazione delle diapositive influenza master e layout**

Una diapositiva eredita gran parte del suo aspetto dal suo layout e dal suo master. Per questo motivo, la variante di clonazione che scegli determina come la diapositiva unita viene integrata nella presentazione di destinazione.

Utilizza [SlideCollection.addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/) in uno dei seguenti modi:
- `addClone(sourceSlide)` — preserva il layout e la formattazione della diapositiva di origine. Quando necessario, il master di origine può essere clonato automaticamente nella presentazione di destinazione. Aspose.Slides traccia i master clonate automaticamente in modo che le diapositive ripetute che utilizzano lo stesso master di origine non causino il clono ripetuto del master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — collega la diapositiva clonata a un [MasterSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/) di destinazione specifico. Aspose.Slides cerca un layout corrispondente sotto quel master per tipo o nome di layout.
- `addClone(sourceSlide, destinationLayout)` — collega la diapositiva clonata direttamente a un [LayoutSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/) di destinazione specifico.

Il master o il layout passato a una variante `addClone` deve appartenere alla presentazione **di destinazione**, non a quella di origine.

## **Unire intere presentazioni e preservare la formattazione di origine**

L'unione più semplice copia ogni diapositiva dalla presentazione di origine a quella di destinazione. Questa è la scelta appropriata quando le diapositive importate devono mantenere il loro tema originale, master e relazioni di layout.

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

La presentazione risultante può contenere più master quando l'origine e la destinazione utilizzano design diversi. Questo è previsto quando la formattazione di origine viene preservata intenzionalmente.

## **Unire diapositive selezionate**

Non è necessario clonare tutte le diapositive. Il seguente esempio importa solo gli indici delle diapositive selezionate dalla presentazione di origine.

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

Convalida gli indici delle diapositive prima di clonare quando provengono da input dell'utente o da configurazioni esterne.

## **Unire diapositive usando un master di destinazione**

Utilizza la variante [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) quando le diapositive importate devono seguire un master che appartiene già alla presentazione di destinazione.

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

Aspose.Slides seleziona un layout appropriato sotto il master specificato abbinando il tipo o il nome del layout di origine. Se non esiste un layout adatto e `allowCloneMissingLayout` è `true`, il layout di origine viene clonato così la diapositiva può essere aggiunta. Se è `false`, viene generata un'eccezione [PptxEditException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxeditexception/).

Utilizza `false` quando desideri che l'unione fallisca invece di introdurre un layout aggiuntivo nel master di destinazione.

## **Unire diapositive usando un layout di destinazione specifico**

Utilizza la variante [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) quando sai esattamente quale layout di destinazione devono utilizzare le diapositive importate.

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

L'applicazione di un layout di destinazione modifica la relazione di layout ereditata; non riprogetta il contenuto della diapositiva di origine. Se i layout di origine e destinazione hanno strutture di segnaposto differenti, ispeziona il risultato per confermare che la formattazione ereditata e il comportamento dei segnaposto siano appropriati.

## **Unire presentazioni con dimensioni delle diapositive diverse**

Le presentazioni con dimensioni delle diapositive diverse possono essere unite, ma clonare una diapositiva in una presentazione con un'altra dimensione non riprogetta automaticamente il suo contenuto per il nuovo canvas. Le forme possono quindi apparire spostate, scalate in modo inatteso o fuori dall'area visibile della diapositiva.

Un approccio pratico è ridimensionare la presentazione di origine prima di clonare. Il metodo [SlideSize.setSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) può scalare il contenuto esistente cambiando le dimensioni della diapositiva. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesizescaletype/) scala il contenuto per adattarlo alla dimensione richiesta.

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

Il ridimensionamento modifica l'oggetto della presentazione di origine in memoria. Se hai bisogno della presentazione di origine originale invariata per altre operazioni, apri un'istanza separata per l'unione.

## **Unire diapositive in una sezione della presentazione**

Il ciclo base di clonazione delle diapositive non ricrea la gerarchia di sezioni della presentazione di origine. Se le sezioni sono importanti nell'output, crea o seleziona sezioni nella presentazione di destinazione e clona le diapositive al loro interno esplicitamente con [addClone(Slide, Section)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

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

Le diapositive clonate vengono aggiunte alla sezione di destinazione specificata. Per preservare più sezioni di origine, ricrea queste sezioni nella destinazione e mappa ogni diapositiva di origine alla corrispondente sezione di destinazione.

## **Unire più presentazioni in modo sicuro**

Il seguente esempio end‑to‑end utilizza la prima presentazione come destinazione, normalizza la dimensione delle diapositive di ogni origine aggiuntiva, mantiene ogni origine aperta solo durante la copia e salva il file finale una sola volta.

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

Questo è un utile punto di partenza per preservare la formattazione di origine delle diapositive importate. Se il tuo output deve utilizzare un unico tema di destinazione, sostituisci la semplice chiamata `addClone(sourceSlide)` con la variante di master di destinazione o di layout di destinazione appropriata mostrata in precedenza.

## **Considerazioni pratiche**

### **Master, layout e fedeltà della formattazione**

La clonazione predefinita delle diapositive può introdurre automaticamente un master di origine necessario nella presentazione di destinazione. Aspose.Slides mantiene un registro interno per i master clonate automaticamente per evitare di clonare lo stesso master più volte. I master clonati manualmente non vengono tracciati da tale registro, quindi evita di pre‑clonare i master a meno che non sia necessario un controllo esplicito della struttura del master.

Non presumere che due master o layout con lo stesso nome siano visualmente equivalenti. Se un modello aziendale deve controllare l'aspetto finale, scegli esplicitamente un master o layout di destinazione e verifica il risultato dopo l'unione.

### **Note e commenti**

Le note del relatore e i commenti delle diapositive sono associati al contenuto della diapositiva e vengono copiati quando una diapositiva è clonata. Aspose.Slides espone anche API dedicate per [presentation notes](https://docs.aspose.com/slides/it/nodejs-java/presentation-notes/) e [presentation comments](https://docs.aspose.com/slides/it/nodejs-java/presentation-comments/).

Se la formattazione della pagina delle note è importante, verifica la presentazione unita perché i master delle note sono oggetti a livello di presentazione e possono differire tra i file di origine. Per i flussi di lavoro di revisione, verifica anche gli autori dei commenti e i commenti a thread dopo aver combinato file di autori o modelli diversi.

### **Immagini, audio, video, oggetti OLE e collegamenti esterni**

Le diapositive possono fare riferimento a risorse a livello di presentazione come immagini, audio incorporato, video incorporato e dati OLE. Clona la diapositiva stessa anziché copiare solo le forme visibili affinché Aspose.Slides mantenga le relazioni della diapositiva con le sue risorse.

Le risorse incorporate e collegate devono essere trattate diversamente. Un audio, video, oggetto OLE o hyperlink collegato rimane dipendente dal suo target esterno; clonare una diapositiva non trasforma un collegamento esterno in contenuto incorporato. Verifica i percorsi e gli URL delle risorse collegate nell'ambiente in cui la presentazione unita verrà aperta.

Aspose.Slides traccia esplicitamente i master clonate automaticamente, ma ciò non deve essere considerato una garanzia generale che risorse binarie identiche provenienti da presentazioni di origine non correlate vengano sempre deduplicate. Se la dimensione del file di output è importante, ispeziona il pacchetto unito e misura il risultato invece di fare affidamento sulla deduplicazione implicita.

### **Font incorporati e disponibilità dei font**

I font sono gestiti a livello di presentazione. Se la tipografia deve rimanere coerente su più macchine, non presumere che la sola clonazione delle diapositive garantisca che tutti i font richiesti siano disponibili nell'ambiente di destinazione. Puoi ispezionare i font incorporati con [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) e gestire l'incorporamento esplicitamente come descritto in [Embed Fonts in Presentations](https://docs.aspose.com/slides/it/nodejs-java/embedded-font/).

Verifica anche di essere autorizzato a incorporare i font utilizzati nei file di origine. Le licenze dei font possono limitare l'incorporamento.

### **Presentazioni protette da password**

Una fonte protetta da password deve essere aperta correttamente prima che le sue diapositive possano essere clonate. Fornisci la password tramite [LoadOptions.setPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Lavora con la presentazione decrittata.
} finally {
    source.dispose();
}
```

Aprire una fonte crittografata non applica automaticamente la stessa protezione alla presentazione di destinazione. Configura la protezione dell'output separatamente quando necessario.

### **Presentazioni di grandi dimensioni e uso della memoria**

Le presentazioni di grandi dimensioni contenenti immagini ad alta risoluzione, audio, video o altri oggetti binari di grandi dimensioni possono consumare notevole memoria. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) fornisce controlli per la gestione dei BLOB e l'uso di file temporanei. Vedi [Manage Presentation BLOBs](https://docs.aspose.com/slides/it/nodejs-java/manage-blob/) per strategie su file di grandi dimensioni.

Per i file di grandi dimensioni, preferisci caricare da percorsi di file quando possibile, rilascia ogni presentazione di origine appena è stata unita ed evita di salvare ripetutamente risultati intermedi a meno che il flusso di lavoro non richieda checkpoint.

### **Sicurezza dei thread**

Non caricare, salvare o clonare un'istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) in più thread. Queste operazioni non sono supportate per l'uso multithread. Se devi parallelizzare lavori di unione indipendenti, utilizza diversi processi monothread, ciascuno con le proprie istanze di presentazione, e segui le [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/it/nodejs-java/multithreading/).

## **FAQ**

**Come mantengo il design originale di ogni presentazione di origine?**

Usa [`addClone(sourceSlide)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) senza fornire un master o layout di destinazione. Aspose.Slides può clonare automaticamente il master di origine quando è necessario per la diapositiva importata.

**Come faccio a far utilizzare alle diapositive importate il tema di destinazione?**

Utilizza la variante che accetta un master di destinazione. Passa un master dalla presentazione di destinazione, non da quella di origine. Aspose.Slides cercherà di mappare ogni diapositiva di origine a un layout appropriato sotto quel master.

**Quando dovrei usare un layout di destinazione specifico anziché un master di destinazione?**

Usa un layout specifico quando ogni diapositiva importata deve utilizzare un layout noto. Usa un master quando vuoi che Aspose.Slides selezioni tra i layout di quel master in base al tipo o al nome del layout di origine.

**Possono essere unite presentazioni con dimensioni delle diapositive diverse?**

Sì, ma il contenuto delle diapositive non viene riprogettato automaticamente per le dimensioni di destinazione. Ridimensiona prima la presentazione di origine quando hai bisogno di un posizionamento prevedibile, ad esempio con [SlideSize.setSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) e [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesizescaletype/).

**Posso unire presentazioni PPT, PPTX e ODP in un unico file?**

Sì. Carica ogni presentazione di origine, clona le diapositive necessarie in una destinazione e salva la destinazione in un formato di output supportato. Poiché i formati di presentazione non supportano esattamente lo stesso set di funzionalità, verifica i contenuti complessi dopo unioni tra formati diversi. Vedi [Supported File Formats](https://docs.aspose.com/slides/it/nodejs-java/supported-file-formats/).

**Le sezioni di origine vengono preservate automaticamente?**

No, non con un ciclo base che clona solo le diapositive. Ricrea le sezioni necessarie nella destinazione e utilizza la variante di sezione di [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) quando la struttura delle sezioni deve essere preservata.

**Le note del relatore e i commenti vengono preservati?**

Vengono copiati con la diapositiva clonata. Per i flussi di lavoro che dipendono dallo stile del master delle note, dagli autori dei commenti o dai dati di revisione a thread, verifica il risultato unito perché tali scenari coinvolgono strutture a livello di presentazione oltre al contenuto delle diapositive.

**Cosa accade ad audio, video, oggetti OLE e hyperlink?**

Il contenuto incorporato viene trasportato come parte delle relazioni di risorsa della diapositiva clonata. I collegamenti esterni rimangono esterni, quindi i loro file o URL di destinazione devono comunque essere disponibili dopo l'unione.

**I font incorporati da ogni fonte sono garantiti disponibili nella presentazione unita?**

Non fare affidamento solo sulla clonazione delle diapositive per il deployment dei font. Ispeziona i font incorporati nella destinazione e gestisci esplicitamente l'incorporamento o la disponibilità di font esterni quando la tipografia è importante.

**Come unire un file protetto da password?**

Aprila con il corretto [LoadOptions.setPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), quindi clona le sue diapositive normalmente. La protezione dell'output viene configurata separatamente.

**Come gestire presentazioni molto grandi?**

Utilizza la gestione dei BLOB quando gli oggetti binari di grandi dimensioni dominano l'uso della memoria, preferisci il caricamento da percorsi di file per file molto grandi, rilascia le presentazioni di origine tempestivamente e salva il risultato finale solo quando necessario.

**Posso unire diapositive da più thread?**

Non caricare, salvare o clonare istanze di presentazione in più thread. Per lavori di unione paralleli, utilizza processi monothread separati e istanze di presentazione indipendenti.