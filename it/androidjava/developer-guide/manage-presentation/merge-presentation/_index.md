---
title: Unire Presentazioni in modo efficiente su Android
linktitle: Unire presentazioni
type: docs
weight: 40
url: /it/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Scopri come unire presentazioni PowerPoint e OpenDocument su Android clonando le diapositive, controllando master e layout, ridimensionando il contenuto delle diapositive, preservando le sezioni e gestendo file protetti o di grandi dimensioni."
---
## **Panoramica**

Aspose.Slides per Android tramite Java unisce presentazioni clonando diapositive da una [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) a un’altra. L’operazione principale è [ISlideCollection.addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), che può conservare la formattazione della diapositiva di origine o allegare la diapositiva clonata a un master o a un layout nella presentazione di destinazione.

Questo articolo copre i flussi di lavoro di unione più comuni:

- unire tutte le diapositive preservando la formattazione originale;
- unire diapositive selezionate;
- applicare un master dalla presentazione di destinazione;
- applicare un layout specifico dalla presentazione di destinazione;
- normalizzare diverse dimensioni di diapositiva prima dell’unione;
- aggiungere diapositive clonate a una sezione;
- unire più presentazioni in un unico flusso end‑to‑end;
- gestire master, risorse, note, commenti, media, font, password, file di grandi dimensioni e problematiche di multithreading.

## **Come la clonazione delle diapositive influenza i master e i layout**

Una diapositiva eredita gran parte del suo aspetto dal layout e dal master. Per questo motivo, il sovraccarico di clonazione che scegli determina come la diapositiva unita viene integrata nella presentazione di destinazione.

Usa [ISlideCollection.addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidecollection/) in uno dei seguenti modi:

- `addClone(sourceSlide)` — conserva il layout e la formattazione della diapositiva di origine. Se necessario, il master di origine può essere clonato automaticamente nella presentazione di destinazione. Aspose.Slides traccia i master clonati automaticamente in modo che diapositive ripetute che usano lo stesso master di origine non provocino la clonazione ripetuta di quel master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — allega la diapositiva clonata a un [IMasterSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterslide/) di destinazione specifico. Aspose.Slides cerca un layout corrispondente sotto quel master per tipo o nome di layout.
- `addClone(sourceSlide, destinationLayout)` — allega direttamente la diapositiva clonata a un [ILayoutSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilayoutslide/) di destinazione specifico.

Il master o il layout passato a un sovraccarico `addClone` deve appartenere alla **presentazione di destinazione**, non a quella di origine.

## **Unire intere presentazioni e conservare la formattazione originale**

L’unione più semplice copia ogni diapositiva dalla presentazione di origine alla presentazione di destinazione. Questa è la scelta appropriata quando le diapositive importate devono mantenere il tema, il master e le relazioni di layout originali.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

La presentazione risultante può contenere più master quando la presentazione di origine e quella di destinazione usano design diversi. Questo è previsto quando la formattazione di origine viene preservata intenzionalmente.

## **Unire diapositive selezionate**

Non è necessario clonare tutte le diapositive. L’esempio seguente importa solo gli indici di diapositiva selezionati dalla presentazione di origine.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Convalida gli indici di diapositiva prima della clonazione quando provengono da input dell’utente o da configurazioni esterne.

## **Unire diapositive usando un master di destinazione**

Usa il sovraccarico [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) quando le diapositive importate devono seguire un master che appartiene già alla presentazione di destinazione.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides seleziona un layout appropriato sotto il master specificato, corrispondendo al tipo o al nome del layout di origine. Se non esiste un layout adatto e `allowCloneMissingLayout` è `true`, il layout di origine viene clonato così la diapositiva può essere aggiunta. Se è `false`, viene sollevata una [PptxEditException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pptxeditexception/).

Usa `false` quando vuoi che l’unione fallisca invece di introdurre un layout aggiuntivo nel master di destinazione.

## **Unire diapositive usando un layout di destinazione specifico**

Usa il sovraccarico [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) quando sai esattamente quale layout di destinazione devono utilizzare le diapositive importate.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

L’applicazione di un layout di destinazione modifica la relazione di layout ereditata; non ridisegna il contenuto della diapositiva di origine. Se i layout di origine e di destinazione hanno strutture di segnaposto diverse, ispeziona il risultato per confermare che la formattazione ereditata e il comportamento dei segnaposto siano appropriati.

## **Unire presentazioni con dimensioni di diapositiva differenti**

Le presentazioni con dimensioni di diapositiva diverse possono essere unite, ma clonare una diapositiva in una presentazione con un’altra dimensione non ridisegna automaticamente il contenuto per la nuova area. Le forme possono quindi apparire spostate, scalate in modo inatteso o fuori dall’area visibile della diapositiva.

Un approccio pratico è ridimensionare la presentazione di origine prima della clonazione. Il metodo [SlideSize.setSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) può scalare il contenuto esistente modificando le dimensioni della diapositiva. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidesizescaletype/) scala il contenuto per adattarlo alla dimensione richiesta.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Il ridimensionamento modifica l’oggetto presentazione di origine in memoria. Se hai bisogno della presentazione di origine originale invariata per altre operazioni, apri un’istanza separata per l’unione.

## **Unire diapositive in una sezione della presentazione**

Il ciclo base di clonazione delle diapositive non ricrea la gerarchia delle sezioni della presentazione di origine. Se le sezioni sono importanti nell’output, crea o seleziona le sezioni nella presentazione di destinazione e clona le diapositive in esse esplicitamente con [addClone(ISlide, ISection)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-).

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Le diapositive clonate vengono aggiunte alla sezione di destinazione specificata. Per conservare più sezioni di origine, elenca [Presentation.getSections](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSections--), recupera le diapositive correnti di ciascuna sezione di origine con [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--), ricrea le sezioni nella destinazione e clona ogni diapositiva restituita nella sua sezione di destinazione corrispondente. Vedi [Manage Slide Sections](/slides/it/androidjava/slide-section/) per un esempio completo di enumerazione delle sezioni, incluse sezioni vuote e modifiche strutturali.

## **Unire più presentazioni in modo sicuro**

L’esempio end‑to‑end seguente utilizza la prima presentazione come destinazione, normalizza la dimensione della diapositiva di ciascuna fonte aggiuntiva, mantiene ogni fonte aperta solo mentre viene copiata e salva il file finale una sola volta.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Questo è un buon punto di partenza per conservare la formattazione di origine delle diapositive importate. Se il tuo output deve utilizzare un unico tema di destinazione, sostituisci la semplice chiamata `addClone(slide)` con il sovraccarico master‑di‑destinazione o layout‑di‑destinazione mostrato in precedenza.

## **Considerazioni pratiche**

### **Master, layout e fedeltà della formattazione**

La clonazione predefinita delle diapositive può introdurre automaticamente un master di origine necessario nella presentazione di destinazione. Aspose.Slides conserva un registro interno dei master clonati automaticamente per evitare di clonare lo stesso master più volte. I master clonati manualmente non sono tracciati da tale registro, quindi evita di pre‑clonare i master a meno che tu non abbia bisogno di un controllo esplicito sulla struttura dei master.

Non dare per scontato che due master o layout con lo stesso nome siano visualmente equivalenti. Se un modello aziendale deve controllare l’aspetto finale, scegli esplicitamente un master o un layout di destinazione e verifica il risultato dopo l’unione.

### **Note e commenti**

Le note del relatore e i commenti delle diapositive sono associati al contenuto della diapositiva e vengono copiati quando una diapositiva viene clonata. Aspose.Slides espone inoltre API dedicate per [note di presentazione](/slides/it/androidjava/presentation-notes/) e [commenti di presentazione](/slides/it/androidjava/presentation-comments/).

Se la formattazione della pagina delle note è importante, verifica la presentazione unita perché i master delle note sono oggetti a livello di presentazione e possono differire tra i file di origine. Per i flussi di revisione, verifica anche gli autori dei commenti e i commenti annidati dopo aver combinato file di diversi autori o modelli.

### **Immagini, audio, video, oggetti OLE e collegamenti esterni**

Le diapositive possono fare riferimento a risorse a livello di presentazione come immagini, audio incorporato, video incorporato e dati OLE. Clona l’intera diapositiva anziché copiare solo le forme visibili affinché Aspose.Slides possa mantenere le relazioni della diapositiva con le sue risorse.

Le risorse incorporate e collegate devono essere gestite in modo diverso. Un audio, video, oggetto OLE o collegamento ipertestuale collegato rimane dipendente dal suo target esterno; clonare una diapositiva non trasforma un collegamento esterno in contenuto incorporato. Testa i percorsi e gli URL delle risorse collegate nell’ambiente in cui la presentazione unita verrà aperta.

Aspose.Slides traccia esplicitamente i master clonati automaticamente, ma questo non deve essere considerato una garanzia generale che risorse binarie identiche provenienti da presentazioni di origine non correlate siano sempre deduplicate. Se la dimensione del file di output è importante, ispeziona il pacchetto unito e misura il risultato invece di fare affidamento su una deduplicazione implicita.

### **Font incorporati e disponibilità dei font**

I font sono gestiti a livello di presentazione. Se la tipografia deve rimanere coerente su più macchine, non dare per scontato che la sola clonazione delle diapositive garantisca che ogni font necessario sia disponibile nell’ambiente di destinazione. Puoi ispezionare i font incorporati con [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) e gestire l’incorporamento esplicitamente come descritto in [Embed Fonts in Presentations](/slides/it/androidjava/embedded-font/).

Verifica inoltre di avere il permesso di incorporare i font utilizzati nei file di origine. Le licenze dei font possono limitare l’incorporamento.

### **Presentazioni protette da password**

Una presentazione di origine protetta da password deve essere aperta correttamente prima che le sue diapositive possano essere clonate. Fornisci la password tramite [LoadOptions.setPassword](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Lavora con la presentazione decrittata.
} finally {
    source.dispose();
}
```

L’apertura di una fonte crittografata non applica automaticamente la stessa protezione alla presentazione di destinazione. Configura la protezione dell’output separatamente quando necessario.

### **Presentazioni di grandi dimensioni e utilizzo della memoria**

Le presentazioni di grandi dimensioni contenenti immagini ad alta risoluzione, audio, video o altri oggetti binari di grandi dimensioni possono consumare molta memoria. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) offre controlli per la gestione dei BLOB e l’uso di file temporanei. Vedi [Manage Presentation BLOBs](/slides/it/androidjava/manage-blob/) per le strategie sui file di grandi dimensioni.

Per file voluminosi, preferisci il caricamento da percorsi file quando possibile, elimina ogni presentazione di origine appena è stata unita e evita di salvare ripetutamente risultati intermedi a meno che il flusso di lavoro non richieda punti di controllo.

### **Sicurezza dei thread**

Non caricare, modificare, salvare o clonare la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) contemporaneamente da più thread. Mantieni ogni istanza di presentazione confinata a un’unica operazione di unione. Se parallelizzi lavori indipendenti, utilizza istanze di presentazione indipendenti e segui le linee guida sul [multithreading di Aspose.Slides](/slides/it/androidjava/multithreading/).

## **Domande frequenti**

**Come mantengo il design originale di ciascuna presentazione di origine?**

Usa [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) senza fornire un master o un layout di destinazione. Aspose.Slides può clonare automaticamente il master di origine quando è necessario per la diapositiva importata.

**Come faccio a far utilizzare alle diapositive importate il tema di destinazione?**

Usa il sovraccarico che accetta un master di destinazione. Fornisci un master dalla presentazione di destinazione, non da quella di origine. Aspose.Slides cercherà di mappare ogni diapositiva di origine a un layout appropriato sotto quel master.

**Quando devo usare un layout di destinazione specifico anziché un master di destinazione?**

Usa un layout specifico quando ogni diapositiva importata deve utilizzare un layout noto. Usa un master quando vuoi che Aspose.Slides selezioni tra i layout di quel master in base al tipo o al nome del layout di origine.

**È possibile unire presentazioni con dimensioni di diapositiva diverse?**

Sì, ma il contenuto della diapositiva non viene ridisegnato automaticamente per le nuove dimensioni. Ridimensiona prima la presentazione di origine, ad esempio con [SlideSize.setSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) e [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidesizescaletype/).

**Posso unire file PPT, PPTX e ODP in un unico documento?**

Sì. Carica ciascuna presentazione di origine, clona le diapositive necessarie in una destinazione e salva la destinazione in un formato di output supportato. Poiché i formati di presentazione non supportano esattamente lo stesso set di funzionalità, verifica il contenuto complesso dopo le unioni cross‑format. Vedi [Supported File Formats](/slides/it/androidjava/supported-file-formats/).

**Le sezioni di origine vengono preservate automaticamente?**

No, non con un ciclo base che clona solo le diapositive. Ricrea le sezioni necessarie nella destinazione e usa il sovraccarico di sezione di [addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) quando la struttura delle sezioni deve essere mantenuta.

**Le note del relatore e i commenti vengono preservati?**

Sì, vengono copiate con la diapositiva clonata. Per i flussi di lavoro che dipendono dallo stile del master delle note, dagli autori dei commenti o dai dati di revisione annidata, verifica il risultato unito perché tali scenari coinvolgono strutture a livello di presentazione oltre al contenuto della diapositiva.

**Cosa succede a audio, video, oggetti OLE e collegamenti ipertestuali?**

I contenuti incorporati vengono trasportati come parte delle relazioni di risorsa della diapositiva clonata. I collegamenti esterni rimangono esterni, quindi i loro file o URL di destinazione devono essere ancora disponibili dopo l’unione.

**I font incorporati da tutte le origini sono garantiti nella presentazione unita?**

Non fare affidamento solo sulla clonazione delle diapositive per la distribuzione dei font. Ispeziona i font incorporati nella destinazione e gestisci esplicitamente l’incorporamento o la disponibilità di font esterni quando la tipografia è importante.

**Come unisco un file protetto da password?**

Aprilo con la corretta [LoadOptions.setPassword](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), poi clona le sue diapositive normalmente. La protezione dell’output viene configurata separatamente.

**Come devo gestire presentazioni molto grandi?**

Usa la gestione dei BLOB quando gli oggetti binari di grandi dimensioni dominano l’uso di memoria, preferisci il caricamento da percorsi file per file molto grandi, elimina prontamente le presentazioni di origine e salva il risultato finale solo quando necessario.

**Posso unire diapositive da più thread?**

Non utilizzare la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) contemporaneamente da più thread. Mantieni ogni operazione di unione isolata su proprie istanze di presentazione.