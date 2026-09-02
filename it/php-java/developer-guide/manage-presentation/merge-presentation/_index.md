---
title: "Unire le presentazioni in modo efficiente in PHP"
linktitle: "Unire presentazioni"
type: docs
weight: 40
url: /it/php-java/merge-presentation/
keywords:
- "unire PowerPoint"
- "unire presentazioni"
- "unire diapositive"
- "unire PPT"
- "unire PPTX"
- "unire ODP"
- "combinare PowerPoint"
- "combinare presentazioni"
- "combinare diapositive"
- "combinare PPT"
- "combinare PPTX"
- "combinare ODP"
- "PHP"
- "Aspose.Slides"
description: "Scopri come unire presentazioni PowerPoint e OpenDocument in PHP clonando le diapositive, controllando master e layout, ridimensionando il contenuto delle diapositive, preservando le sezioni e gestendo file protetti o di grandi dimensioni."
---
## **Panoramica**

Aspose.Slides per PHP via Java unisce presentazioni clonando le diapositive da una [Presentazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) a un'altra. L'operazione principale è [SlideCollection::addClone()](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/), che può preservare la formattazione della diapositiva di origine o collegare la diapositiva clonata a un master o a un layout nella presentazione di destinazione.

Questo articolo copre i flussi di lavoro di fusione più comuni:

- unire tutte le diapositive preservando la loro formattazione di origine;
- unire diapositive selezionate;
- applicare un master dalla presentazione di destinazione;
- applicare un layout specifico dalla presentazione di destinazione;
- normalizzare diverse dimensioni delle diapositive prima della fusione;
- aggiungere diapositive clonate a una sezione;
- unire più presentazioni in un flusso di lavoro end‑to‑end;
- gestire master, risorse, note, commenti, media, caratteri, password, file di grandi dimensioni e considerazioni sul multithreading.

## **Come la clonazione delle diapositive influisce su Master e Layout**

Una diapositiva eredita gran parte del suo aspetto dal layout e dal master. Per questo motivo, il sovraccarico di clonazione scelto determina come la diapositiva unita viene integrata nella presentazione di destinazione.

Usa [SlideCollection::addClone()](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) in uno di questi modi:

- `addClone(sourceSlide)` — preserva il layout e la formattazione della diapositiva di origine. Quando necessario, il master di origine può essere clonato automaticamente nella presentazione di destinazione. Aspose.Slides traccia automaticamente i master clonati in modo che diapositive ripetute che usano lo stesso master di origine non causino una clonazione ripetuta di quel master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — collega la diapositiva clonata a uno specifico [MasterSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/) di destinazione. Aspose.Slides cerca un layout corrispondente sotto quel master in base al tipo o al nome del layout.
- `addClone(sourceSlide, destinationLayout)` — collega direttamente la diapositiva clonata a uno specifico [LayoutSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/).

Il master o il layout passato a un sovraccarico `addClone` deve appartenere alla **presentazione di destinazione**, non a quella di origine.

## **Unire intere presentazioni e preservare la formattazione di origine**

La fusione più semplice copia ogni diapositiva dalla presentazione di origine alla presentazione di destinazione. Questa è la scelta appropriata quando le diapositive importate devono mantenere il loro tema, master e layout originali.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

La presentazione risultante può contenere più master quando l'origine e la destinazione usano design diversi. Ciò è previsto quando la formattazione di origine viene preservata intenzionalmente.

## **Unire diapositive selezionate**

Non è necessario clonare ogni diapositiva. Nell’esempio seguente vengono importati solo gli indici delle diapositive selezionate dalla presentazione di origine.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Convalida gli indici delle diapositive prima di clonare quando provengono da input utente o da configurazioni esterne.

## **Unire diapositive usando un Master di destinazione**

Usa il sovraccarico [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) quando le diapositive importate devono seguire un master già presente nella presentazione di destinazione.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides seleziona un layout appropriato sotto il master specificato confrontando il tipo o il nome del layout di origine. Se non esiste un layout adeguato e `allowCloneMissingLayout` è `true`, il layout di origine viene clonato in modo che la diapositiva possa essere aggiunta. Se è `false`, viene generata un’[PptxEditException](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxeditexception/).

Usa `false` quando vuoi che la fusione fallisca invece di introdurre un layout aggiuntivo nel master di destinazione.

## **Unire diapositive usando un Layout di destinazione specifico**

Usa il sovraccarico [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) quando sai esattamente quale layout di destinazione devono usare le diapositive importate.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

L’applicazione di un layout di destinazione modifica la relazione di ereditarietà del layout; non ridisegna il contenuto della diapositiva di origine. Se i layout di origine e di destinazione hanno strutture di segnaposto diverse, ispeziona il risultato per confermare che la formattazione ereditata e il comportamento dei segnaposto siano appropriati.

## **Unire presentazioni con dimensioni di diapositiva diverse**

Le presentazioni con dimensioni di diapositiva diverse possono essere unite, ma clonare una diapositiva in una presentazione con una dimensione diversa non ridisegna automaticamente il contenuto per il nuovo canvas. Le forme possono quindi apparire spostate, scalate in modo inatteso o fuori dall’area visibile della diapositiva.

Un approccio pratico è ridimensionare la presentazione di origine prima della clonazione. Il metodo [SlideSize::setSize()](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesize/setsize/) può ridimensionare il contenuto esistente mentre cambia le dimensioni della diapositiva. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesizescaletype/) scala il contenuto per adattarlo alla dimensione richiesta.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Il ridimensionamento modifica l’oggetto della presentazione di origine in memoria. Se hai bisogno che la presentazione di origine rimanga invariata per altre operazioni, apri un’istanza separata per la fusione.

## **Unire diapositive in una sezione della presentazione**

Il ciclo base di clonazione delle diapositive non ricrea la gerarchia delle sezioni della presentazione di origine. Se le sezioni sono importanti nell’output, crea o seleziona le sezioni nella presentazione di destinazione e clona le diapositive in esse esplicitamente con [addClone(Slide, Section)](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Le diapositive clonate vengono aggiunte alla sezione di destinazione specificata. Per preservare più sezioni di origine, ricrea quelle sezioni nella destinazione e mappa ciascuna diapositiva di origine alla sezione di destinazione corrispondente.

## **Unire più presentazioni in modo sicuro**

L’esempio end‑to‑end seguente usa la prima presentazione come destinazione, normalizza la dimensione delle diapositive di ogni altra origine, mantiene aperta ogni origine solo durante la copia e salva il file finale una sola volta.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

Questo è un buon punto di partenza per preservare la formattazione di origine delle diapositive importate. Se il tuo output deve usare un unico tema di destinazione, sostituisci la semplice chiamata `addClone($slide)` con il sovraccarico di master o layout di destinazione mostrato in precedenza.

## **Considerazioni pratiche**

### **Master, Layout e fedeltà della formattazione**

La clonazione predefinita delle diapositive può introdurre automaticamente un master di origine necessario nella presentazione di destinazione. Aspose.Slides mantiene un registro interno per i master clonati automaticamente, evitando di clonare lo stesso master più volte. I master clonati manualmente non sono tracciati da quel registro, quindi evita di pre‑clonare i master a meno che tu non abbia bisogno di un controllo esplicito sulla struttura del master.

Non dare per scontato che due master o layout con lo stesso nome siano visivamente equivalenti. Se un modello aziendale deve controllare l’aspetto finale, scegli esplicitamente un master o un layout di destinazione e verifica il risultato dopo la fusione.

### **Note e commenti**

Le note del relatore e i commenti alle diapositive sono associati al contenuto della diapositiva e vengono copiati quando una diapositiva viene clonata. Aspose.Slides espone anche API dedicate per le [note della presentazione](https://docs.aspose.com/slides/it/php-java/presentation-notes/) e i [commenti della presentazione](https://docs.aspose.com/slides/it/php-java/presentation-comments/).

Se la formattazione della pagina delle note è importante, verifica la presentazione unita perché i master delle note sono oggetti a livello di presentazione e possono differire tra i file di origine. Per i flussi di revisione, verifica anche gli autori dei commenti e le conversazioni annidate dopo aver combinato file da diversi autori o modelli.

### **Immagini, audio, video, oggetti OLE e collegamenti esterni**

Le diapositive possono fare riferimento a risorse a livello di presentazione come immagini, audio incorporato, video incorporato e dati OLE. Clona la diapositiva stessa anziché copiare solo le forme visibili, così Aspose.Slides può mantenere le relazioni della diapositiva con le sue risorse.

Le risorse incorporate e collegate devono essere trattate diversamente. Un audio, video, oggetto OLE o collegamento ipertestuale collegato rimane dipendente dal suo obiettivo esterno; clonare una diapositiva non trasforma un collegamento esterno in contenuto incorporato. Testa i percorsi e gli URL delle risorse collegate nell’ambiente in cui verrà aperta la presentazione unita.

Aspose.Slides traccia esplicitamente i master clonati automaticamente, ma questo non deve essere inteso come una garanzia generale che le risorse binarie identiche provenienti da presentazioni di origine non correlate vengano sempre deduplicate. Se la dimensione del file di output è importante, ispeziona il pacchetto unito e misura il risultato invece di fare affidamento sulla deduplicazione implicita.

### **Caratteri incorporati e disponibilità dei caratteri**

I caratteri sono gestiti a livello di presentazione. Se la tipografia deve rimanere coerente su più macchine, non dare per scontato che la sola clonazione delle diapositive garantisca la presenza di tutti i caratteri richiesti nell’ambiente di destinazione. Puoi ispezionare i caratteri incorporati con [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/getembeddedfonts/) e gestire l’incorporamento esplicitamente come descritto in [Incorporare i caratteri nelle presentazioni](https://docs.aspose.com/slides/it/php-java/embedded-font/).

Verifica anche di avere il permesso di incorporare i caratteri usati nei file di origine. Le licenze dei caratteri possono limitare l’incorporamento.

### **Presentazioni protette da password**

Un file di origine protetto da password deve essere aperto correttamente prima che le sue diapositive possano essere clonate. Fornisci la password tramite [LoadOptions::setPassword()](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Lavora con la presentazione decrittografata.
} finally {
    $source->dispose();
}
```

L’apertura di una fonte cifrata non applica automaticamente la stessa protezione alla presentazione di destinazione. Configura la protezione di output separatamente quando necessario.

### **Presentazioni di grandi dimensioni e utilizzo della memoria**

Le presentazioni di grandi dimensioni contenenti immagini ad alta risoluzione, audio, video o altri oggetti binari di grandi dimensioni possono consumare molta memoria. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) offre controlli per la gestione dei BLOB e l’utilizzo di file temporanei. Consulta [Aprire presentazioni](https://docs.aspose.com/slides/it/php-java/open-presentation/#open-large-presentations) per un esempio PHP via Java di file di grandi dimensioni.

Per file di grandi dimensioni, preferisci il caricamento da percorsi di file quando possibile, elimina ogni presentazione di origine appena è stata unita e evita di salvare ripetutamente risultati intermedi a meno che il flusso di lavoro non richieda checkpoint.

### **Sicurezza dei thread**

Non caricare, modificare, salvare o clonare istanze di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) in più thread. queste operazioni non sono supportate per l’uso multithread in PHP via Java. Se hai bisogno di lavori di fusione paralleli, eseguili in processi separati a thread singolo, ciascuno con le proprie istanze di presentazione, e segui le [linee guida multithreading di Aspose.Slides](https://docs.aspose.com/slides/it/php-java/multithreading/).

## **FAQ**

**Come faccio a mantenere il design originale di ogni presentazione di origine?**

Usa [`addClone(sourceSlide)`](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) senza fornire un master o un layout di destinazione. Aspose.Slides può clonare automaticamente il master di origine quando è necessario per la diapositiva importata.

**Come faccio a far usare alle diapositive importate il tema di destinazione?**

Usa il sovraccarico che accetta un master di destinazione. Passa un master dalla presentazione di destinazione, non da quella di origine. Aspose.Slides cercherà di mappare ogni diapositiva di origine a un layout appropriato sotto quel master.

**Quando devo usare un layout di destinazione specifico invece di un master di destinazione?**

Usa un layout specifico quando ogni diapositiva importata deve usare un layout noto. Usa un master quando vuoi che Aspose.Slides scelga tra i layout di quel master in base al tipo o al nome del layout di origine.

**È possibile unire presentazioni con dimensioni di diapositiva diverse?**

Sì, ma il contenuto della diapositiva non viene ridisegnato automaticamente per le dimensioni di destinazione. Ridimensiona prima la presentazione di origine quando hai bisogno di un posizionamento prevedibile, ad esempio con [SlideSize::setSize()](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesize/setsize/) e [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesizescaletype/).

**Posso unire presentazioni PPT, PPTX e ODP in un unico file?**

Sì. Carica ogni presentazione di origine, clona le diapositive necessarie in una destinazione e salva la destinazione in un formato di output supportato. Poiché i formati di presentazione non supportano esattamente lo stesso set di funzionalità, verifica i contenuti complessi dopo le fusioni tra formati diversi. Consulta [Formati di file supportati](https://docs.aspose.com/slides/it/php-java/supported-file-formats/).

**Le sezioni di origine vengono preservate automaticamente?**

No, non con un ciclo base che clona solo le diapositive. Ricrea le sezioni necessarie nella destinazione e usa il sovraccarico di sezione di [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) quando la struttura delle sezioni deve essere preservata.

**Le note del relatore e i commenti vengono preservati?**

Vengono copiati con la diapositiva clonata. Per i flussi di lavoro che dipendono dallo stile del master delle note, dagli autori dei commenti o dai dati di revisione annidata, verifica il risultato unito perché questi scenari coinvolgono strutture a livello di presentazione oltre al contenuto delle diapositive.

**Cosa succede a audio, video, oggetti OLE e collegamenti ipertestuali?**

Il contenuto incorporato viene trasportato come parte delle relazioni delle risorse della diapositiva clonata. I collegamenti esterni rimangono esterni, quindi i loro file o URL di destinazione devono essere ancora disponibili dopo la fusione.

**I caratteri incorporati da ogni origine sono garantiti disponibili nella presentazione unita?**

Non fare affidamento solo sulla clonazione delle diapositive per il deployment dei caratteri. Ispeziona i caratteri incorporati nella destinazione e gestisci esplicitamente l’incorporamento dei caratteri o la disponibilità di caratteri esterni quando la tipografia è importante.

**Come unisco un file protetto da password?**

Aprilo con il corretto [LoadOptions::setPassword()](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/setpassword/), poi clona le sue diapositive normalmente. La protezione di output viene configurata separatamente.

**Come devo gestire presentazioni molto grandi?**

Usa la gestione dei BLOB quando gli oggetti binari di grandi dimensioni dominano l’uso della memoria, preferisci il caricamento da percorsi di file per file molto grandi, elimina le presentazioni di origine prontamente e salva il risultato finale solo quando necessario.

**Posso unire diapositive da più thread?**

Il caricamento, il salvataggio o la clonazione di presentazioni in più thread non è supportato in PHP via Java. Per lavori paralleli, utilizza processi separati a thread singolo e mantieni le istanze di presentazione isolate all’interno di ciascun processo.