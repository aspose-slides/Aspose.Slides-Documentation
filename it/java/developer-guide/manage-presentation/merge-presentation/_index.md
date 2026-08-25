---
title: Unire le presentazioni in Java in modo efficiente
linktitle: Unire le presentazioni
type: docs
weight: 40
url: /it/java/merge-presentation/
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
- Java
- Aspose.Slides
description: "Scopri come unire presentazioni PowerPoint e OpenDocument in Java clonando le diapositive, controllando master e layout, ridimensionando il contenuto delle diapositive, preservando le sezioni e gestendo file protetti o di grandi dimensioni."
---
## **Panoramica**

Aspose.Slides per Java unisce presentazioni clonando diapositive da una [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) a un'altra. L'operazione principale è [ISlideCollection.addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), che può preservare la formattazione della diapositiva di origine o collegare la diapositiva clonata a un master o a un layout nella presentazione di destinazione.

Questo articolo copre i flussi di lavoro di fusione più comuni:

- unire tutte le diapositive mantenendo la loro formattazione originale;
- unire diapositive selezionate;
- applicare un master dalla presentazione di destinazione;
- applicare un layout specifico dalla presentazione di destinazione;
- normalizzare diverse dimensioni delle diapositive prima della fusione;
- aggiungere diapositive clonate a una sezione;
- unire più presentazioni in un flusso di lavoro end‑to‑end;
- gestire master, risorse, note, commenti, media, caratteri, password, file di grandi dimensioni e problemi di multithreading.

## **Come la clonazione delle diapositive influisce su master e layout**

Una diapositiva eredita gran parte del proprio aspetto dal layout e dal master. Per questa ragione, la sovraccarico di clonazione che scegli determina come la diapositiva unita viene integrata nella presentazione di destinazione.

Usa [ISlideCollection.addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidecollection/) in uno dei seguenti modi:

- `addClone(sourceSlide)` — preserva il layout e la formattazione della diapositiva di origine. Se necessario, il master di origine può essere clonato automaticamente nella presentazione di destinazione. Aspose.Slides traccia i master clonati automaticamente in modo che diapositive ripetute che usano lo stesso master di origine non provocino la clonazione ripetuta di quel master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — collega la diapositiva clonata a uno specifico [IMasterSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslide/) di destinazione. Aspose.Slides cerca un layout corrispondente sotto quel master per tipo o nome del layout.
- `addClone(sourceSlide, destinationLayout)` — collega direttamente la diapositiva clonata a uno specifico [ILayoutSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/).

Il master o il layout passato a una sovraccarico `addClone` deve appartenere alla **presentazione di destinazione**, non a quella di origine.

## **Unire intere presentazioni preservando la formattazione di origine**

La fusione più semplice copia ogni diapositiva dalla presentazione di origine alla presentazione di destinazione. Questa è la scelta appropriata quando le diapositive importate devono mantenere il tema, il master e le relazioni di layout originali.

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

La presentazione risultante può contenere più master quando l'origine e la destinazione usano design diversi. Ciò è previsto quando la formattazione di origine viene intenzionalmente preservata.

## **Unire diapositive selezionate**

Non è necessario clonare ogni diapositiva. L'esempio seguente importa solo gli indici di diapositiva selezionati dalla presentazione di origine.

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

Convalida gli indici di diapositiva prima della clonazione quando provengono da input dell'utente o da configurazioni esterne.

## **Unire diapositive usando un master di destinazione**

Usa la sovraccarico [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) quando le diapositive importate devono seguire un master che appartiene già alla presentazione di destinazione.

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

Aspose.Slides seleziona un layout appropriato sotto il master specificato abbinando il tipo o il nome del layout di origine. Se non esiste un layout adatto e `allowCloneMissingLayout` è `true`, il layout di origine viene clonato così la diapositiva può essere aggiunta. Se è `false`, viene sollevata una [PptxEditException](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptxeditexception/).

Usa `false` quando desideri che la fusione fallisca invece di introdurre un layout aggiuntivo nel master di destinazione.

## **Unire diapositive usando un layout di destinazione specifico**

Usa la sovraccarico [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) quando conosci esattamente quale layout di destinazione devono utilizzare le diapositive importate.

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

L'applicazione di un layout di destinazione modifica la relazione di layout ereditata; non ridisegna il contenuto della diapositiva di origine. Se i layout di origine e destinazione hanno strutture di segnaposto differenti, ispeziona il risultato per confermare che la formattazione ereditata e il comportamento dei segnaposto siano appropriati.

## **Unire presentazioni con dimensioni di diapositiva diverse**

Le presentazioni con dimensioni di diapositiva diverse possono essere unite, ma clonare una diapositiva in una presentazione con un'altra dimensione non ridisegna automaticamente il suo contenuto per la nuova area. Le forme possono quindi apparire spostate, scalate in modo imprevisto o fuori dall'area visibile della diapositiva.

Un approccio pratico è ridimensionare la presentazione di origine prima della clonazione. Il metodo [SlideSize.setSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidesize/#setSize-float-float-int-) può scalare il contenuto esistente cambiando le dimensioni della diapositiva. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidesizescaletype/) scala il contenuto per adattarlo alla dimensione richiesta.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
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

Il ridimensionamento modifica l'oggetto della presentazione di origine in memoria. Se hai bisogno che la presentazione di origine rimanga invariata per altre operazioni, apri un'istanza separata per la fusione.

## **Unire diapositive in una sezione della presentazione**

Il ciclo di base per la clonazione delle diapositive non ricrea la gerarchia delle sezioni della presentazione di origine. Se le sezioni sono importanti nell'output, crea o seleziona sezioni nella presentazione di destinazione e clona le diapositive in esse esplicitamente con [addClone(ISlide, ISection)](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Le diapositive clonate vengono aggiunte alla sezione di destinazione specificata. Per preservare più sezioni di origine, enumera [Presentation.getSections](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getSections--), recupera le diapositive correnti di ogni sezione di origine con [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/it/java/com.aspose.slides/isection/#getSlidesListOfSection--), ricrea le sezioni nella destinazione e clona ciascuna diapositiva restituita nella sua corrispondente sezione di destinazione. Vedi [Gestire le sezioni delle diapositive](/slides/it/java/slide-section/) per un esempio completo di enumerazione delle sezioni, incluse sezioni vuote e modifiche strutturali.

## **Unire più presentazioni in modo sicuro**

L'esempio end‑to‑end seguente utilizza la prima presentazione come destinazione, normalizza la dimensione delle diapositive di ogni fonte aggiuntiva, mantiene ogni fonte aperta solo mentre viene copiata e salva il file finale una sola volta.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
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

Questo è un utile punto di partenza per preservare la formattazione di origine delle diapositive importate. Se il tuo output deve usare un unico tema di destinazione, sostituisci la semplice chiamata `addClone(slide)` con la sovraccarico master‑di‑destinazione o layout‑di‑destinazione mostrata in precedenza.

## **Considerazioni pratiche**

### **Master, layout e fedeltà della formattazione**

La clonazione predefinita delle diapositive può introdurre automaticamente un master di origine necessario nella presentazione di destinazione. Aspose.Slides mantiene un registro interno per i master clonati automaticamente al fine di evitare la clonazione ripetuta dello stesso master. I master clonati manualmente non sono tracciati da quel registro, quindi evita di pre‑clonare i master a meno che non ti serva un controllo esplicito sulla struttura del master.

Non presumere che due master o layout con lo stesso nome siano visualmente equivalenti. Se un modello aziendale deve controllare l'aspetto finale, scegli esplicitamente un master o un layout di destinazione e verifica il risultato dopo la fusione.

### **Note e commenti**

Le note del relatore e i commenti alle diapositive sono associati al contenuto della diapositiva e vengono copiati quando una diapositiva è clonata. Aspose.Slides espone anche API dedicate per [note della presentazione](/slides/it/java/presentation-notes/) e [commenti della presentazione](/slides/it/java/presentation-comments/).

Se la formattazione della pagina delle note è importante, verifica la presentazione unita perché i master delle note sono oggetti a livello di presentazione e possono differire tra i file di origine. Per flussi di revisione, verifica anche gli autori dei commenti e i commenti nidificati dopo aver combinato file da autori o modelli diversi.

### **Immagini, audio, video, oggetti OLE e collegamenti esterni**

Le diapositive possono fare riferimento a risorse a livello di presentazione come immagini, audio incorporato, video incorporato e dati OLE. Clona la diapositiva stessa invece di copiare solo le forme visibili così Aspose.Slides può mantenere le relazioni della diapositiva con le sue risorse.

Le risorse incorporate e quelle collegate devono essere trattate diversamente. Un audio, video, oggetto OLE o collegamento ipertestuale collegato rimane dipendente dal suo target esterno; clonare una diapositiva non trasforma un collegamento esterno in contenuto incorporato. Verifica i percorsi e gli URL delle risorse collegate nell'ambiente in cui verrà aperta la presentazione unita.

Aspose.Slides traccia esplicitamente i master clonati automaticamente, ma questo non deve essere interpretato come una garanzia generale che le risorse binarie identiche provenienti da presentazioni di origine non correlate siano sempre deduplicate. Se la dimensione del file di output è importante, ispeziona il pacchetto unito e misura il risultato invece di fare affidamento sulla deduplicazione implicita.

### **Caratteri incorporati e disponibilità dei caratteri**

I caratteri sono gestiti a livello di presentazione. Se la tipografia deve rimanere coerente su più macchine, non presumere che la sola clonazione delle diapositive garantisca che ogni carattere necessario sia disponibile nell'ambiente di destinazione. Puoi ispezionare i caratteri incorporati con [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) e gestire l'incorporamento esplicitamente come descritto in [Incorporare i caratteri nelle presentazioni](/slides/it/java/embedded-font/).

Verifica anche di avere l'autorizzazione a incorporare i caratteri usati nei file di origine. Le licenze dei caratteri possono limitare l'incorporamento.

### **Presentazioni protette da password**

Una fonte protetta da password deve essere aperta con successo prima che le sue diapositive possano essere clonate. Fornisci la password tramite [LoadOptions.setPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

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

L'apertura di una fonte crittografata non applica automaticamente la stessa protezione alla presentazione di destinazione. Configura la protezione dell'output separatamente quando necessario.

### **Presentazioni di grandi dimensioni e uso della memoria**

Le presentazioni di grandi dimensioni contenenti immagini ad alta risoluzione, audio, video o altri oggetti binari voluminosi possono consumare molta memoria. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) fornisce controlli per la gestione dei BLOB e l'uso di file temporanei. Vedi [Gestire i BLOB delle presentazioni](/slides/it/java/manage-blob/) per strategie su file di grandi dimensioni.

Per file di grandi dimensioni, preferisci il caricamento da percorsi file quando possibile, rilascia ogni presentazione di origine non appena è stata unita e evita di salvare ripetutamente risultati intermedi a meno che il flusso di lavoro non richieda checkpoint.

### **Sicurezza multithread**

Non caricare, modificare, salvare o clonare la stessa [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) contemporaneamente da più thread. Mantieni ogni istanza di presentazione confinata a una singola operazione di fusione. Se parallelizzi lavori indipendenti, utilizza istanze di presentazione indipendenti e segui le indicazioni sul [multithreading di Aspose.Slides](/slides/it/java/multithreading/).

## **FAQ**

**Come mantengo il design originale di ogni presentazione di origine?**

Usa [addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) senza fornire un master o un layout di destinazione. Aspose.Slides può clonare automaticamente il master di origine quando è necessario per la diapositiva importata.

**Come faccio a far usare alle diapositive importate il tema di destinazione?**

Usa la sovraccarico che accetta un master di destinazione. Passa un master dalla presentazione di destinazione, non da quella di origine. Aspose.Slides cercherà di mappare ogni diapositiva di origine a un layout appropriato sotto quel master.

**Quando devo usare un layout di destinazione specifico invece di un master di destinazione?**

Usa un layout specifico quando ogni diapositiva importata deve utilizzare un unico layout noto. Usa un master quando vuoi che Aspose.Slides selezioni tra i layout di quel master in base al tipo o al nome del layout di origine.

**È possibile unire presentazioni con dimensioni di diapositiva diverse?**

Sì, ma il contenuto della diapositiva non viene ridisegnato automaticamente per le dimensioni di destinazione. Ridimensiona prima la presentazione di origine quando ti serve un posizionamento prevedibile, ad esempio con [SlideSize.setSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidesize/#setSize-float-float-int-) e [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidesizescaletype/).

**Posso unire presentazioni PPT, PPTX e ODP in un unico file?**

Sì. Carica ogni presentazione di origine, clona le diapositive necessarie in una destinazione e salva la destinazione in un formato di output supportato. Poiché i formati di presentazione non supportano esattamente lo stesso set di funzionalità, verifica il contenuto complesso dopo le fusioni tra formati diversi. Vedi [Formati di file supportati](/slides/it/java/supported-file-formats/).

**Le sezioni di origine vengono preservate automaticamente?**

No, non con un ciclo base che clona solo le diapositive. Ricrea le sezioni necessarie nella destinazione e usa la sovraccarico di sezione di [addClone](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) quando la struttura delle sezioni deve essere preservata.

**Le note del relatore e i commenti vengono preservati?**

Vengono copiati con la diapositiva clonata. Per i flussi di lavoro che dipendono dallo stile del master delle note, dagli autori dei commenti o dai dati di revisione nidificati, verifica il risultato unito perché tali scenari coinvolgono strutture a livello di presentazione oltre al contenuto delle diapositive.

**Cosa accade a audio, video, oggetti OLE e collegamenti ipertestuali?**

Il contenuto incorporato viene trasportato come parte delle relazioni di risorsa della diapositiva clonata. I collegamenti esterni rimangono esterni, quindi i loro file o URL di destinazione devono ancora essere disponibili dopo la fusione.

**I caratteri incorporati da ogni origine sono garantiti disponibili nella presentazione unita?**

Non fare affidamento solo sulla clonazione delle diapositive per la distribuzione dei caratteri. Ispeziona i caratteri incorporati nella destinazione e gestisci esplicitamente l'incorporamento dei caratteri o la disponibilità di caratteri esterni quando la tipografia è importante.

**Come unisco un file protetto da password?**

Aprilo con la corretta [LoadOptions.setPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), quindi clona le sue diapositive normalmente. La protezione dell'output viene configurata separatamente.

**Come devo gestire presentazioni molto grandi?**

Usa la gestione dei BLOB quando gli oggetti binari di grandi dimensioni dominano l'uso della memoria, preferisci il caricamento da percorsi file per file molto grandi, rilascia prontamente le presentazioni di origine e salva il risultato finale solo quando necessario.

**Posso unire diapositive da più thread?**

Non utilizzare la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) contemporaneamente da più thread. Mantieni ogni operazione di fusione isolata nelle proprie istanze di presentazione.