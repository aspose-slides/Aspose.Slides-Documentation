---
title: Unire Efficientemente le Presentazioni in PHP
linktitle: Unire Presentazioni
type: docs
weight: 40
url: /it/php-java/merge-presentation/
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
- PHP
- Aspose.Slides
description: "Scopri come unire presentazioni PowerPoint e OpenDocument in PHP clonando le diapositive, controllando master e layout, ridimensionando il contenuto delle diapositive, preservando le sezioni e gestendo file protetti o di grandi dimensioni."
---
## **Panoramica**

Aspose.Slides for PHP via Java unisce presentazioni clonando le diapositive da una [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) a un'altra. L'operazione principale è [SlideCollection::addClone()](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/), che può preservare la formattazione della diapositiva di origine o collegare la diapositiva clonata a un master o layout nella presentazione di destinazione.

Questo articolo copre i flussi di lavoro di unione più comuni:

- unire tutte le diapositive preservando la loro formattazione di origine;
- unire diapositive selezionate;
- applicare un master dalla presentazione di destinazione;
- applicare un layout specifico dalla presentazione di destinazione;
- normalizzare diverse dimensioni delle diapositive prima dell'unione;
- aggiungere diapositive clonate a una sezione;
- unire diverse presentazioni in un unico flusso end-to-end;
- gestire master, risorse, note, commenti, media, font, password, file di grandi dimensioni e problematiche di multithreading.

## **Come la clonazione delle diapositive influisce su master e layout**

Una diapositiva eredita gran parte del suo aspetto dal layout e dal master. Per questo motivo, il sovraccarico di clonazione scelto determina come la diapositiva unita viene integrata nella presentazione di destinazione.

Usa [SlideCollection::addClone()](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) in uno di questi modi:

- `addClone(sourceSlide)` — preserva il layout e la formattazione della diapositiva di origine. Quando necessario, il master di origine può essere clonato automaticamente nella presentazione di destinazione. Aspose.Slides tiene traccia dei master clonati automaticamente in modo che le diapositive ripetute che usano lo stesso master di origine non provochino una clonazione ripetuta di quel master.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — collega la diapositiva clonata a un [MasterSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/) di destinazione specifico. Aspose.Slides cerca un layout corrispondente sotto quel master per tipo o nome di layout.
- `addClone(sourceSlide, destinationLayout)` — collega direttamente la diapositiva clonata a un [LayoutSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/) di destinazione specifico.

Il master o il layout passato a una sovraccarico `addClone` deve appartenere alla presentazione **di destinazione**, non a quella di origine.

## **Unire presentazioni intere preservando la formattazione di origine**

L'unione più semplice copia ogni diapositiva dalla presentazione di origine a quella di destinazione. Questa è la scelta appropriata quando le diapositive importate devono mantenere il tema, il master e le relazioni di layout originali.

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

La presentazione risultante può contenere più master quando l'origine e la destinazione utilizzano design diversi. Questo è previsto quando la formattazione di origine viene intenzionalmente preservata.

## **Unire diapositive selezionate**

Non è necessario clonare ogni diapositiva. L'esempio seguente importa solo gli indici di diapositiva selezionati dalla presentazione di origine.

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

Convalida gli indici di diapositiva prima di clonare quando provengono da input dell'utente o da configurazioni esterne.

## **Unire diapositive usando un master di destinazione**

Usa il sovraccarico [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) quando le diapositive importate devono seguire un master che già appartiene alla presentazione di destinazione.

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

Aspose.Slides seleziona un layout appropriato sotto il master specificato facendo corrispondere il tipo o il nome del layout di origine. Se non esiste un layout adatto e `allowCloneMissingLayout` è `true`, il layout di origine viene clonato così la diapositiva può essere aggiunta. Se è `false`, viene sollevata una [PptxEditException](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxeditexception/).

Usa `false` quando desideri che l'unione fallisca invece di introdurre un layout aggiuntivo nel master di destinazione.

## **Unire diapositive usando un layout di destinazione specifico**

Usa il sovraccarico [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) quando sai esattamente quale layout di destinazione devono utilizzare le diapositive importate.

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

Applicare un layout di destinazione modifica la relazione di layout ereditata; non ridisegna il contenuto della diapositiva di origine. Se i layout di origine e di destinazione hanno strutture di segnaposto diverse, ispeziona il risultato per confermare che la formattazione ereditata e il comportamento dei segnaposto siano appropriati.

## **Unire presentazioni con diverse dimensioni delle diapositive**

Le presentazioni con dimensioni di diapositiva differenti possono essere unite, ma clonare una diapositiva in una presentazione con una dimensione diversa non ridisegna automaticamente il suo contenuto per la nuova area di lavoro. Le forme possono quindi apparire spostate, scalate in modo inatteso o fuori dall'area visibile della diapositiva.

Un approccio pratico è ridimensionare la presentazione di origine prima di clonare. Il metodo [SlideSize::setSize()](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesize/setsize/) può scalare il contenuto esistente modificando le dimensioni della diapositiva. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesizescaletype/) scala il contenuto per adattarlo alla dimensione richiesta.

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

Il ridimensionamento modifica l'oggetto della presentazione di origine in memoria. Se hai bisogno che la presentazione di origine rimanga invariata per altre operazioni, apri un'istanza separata per l'unione.

## **Unire diapositive in una sezione della presentazione**

Il ciclo base di clonazione delle diapositive non ricrea la gerarchia delle sezioni della presentazione di origine. Se le sezioni sono importanti nell'output, crea o seleziona le sezioni nella presentazione di destinazione e clona le diapositive al loro interno esplicitamente con [addClone(Slide, Section)](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/).

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

Le diapositive clonate vengono aggiunte alla sezione di destinazione specificata. Per preservare diverse sezioni di origine, elenca [Presentation::getSections](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getSections), recupera le diapositive correnti di ogni sezione di origine con [Section::getSlidesListOfSection](https://reference.aspose.com/slides/it/php-java/aspose.slides/Section/#getSlidesListOfSection), ricrea le sezioni nella destinazione e clona ciascuna diapositiva restituita nella sua sezione di destinazione corrispondente. Consulta [Manage Slide Sections](/slides/it/php-java/slide-section/) per un esempio completo di enumerazione delle sezioni, incluse sezioni vuote e modifiche strutturali.

## **Unire più presentazioni in modo sicuro**

Il seguente esempio end-to-end utilizza la prima presentazione come destinazione, normalizza la dimensione delle diapositive di ogni origine aggiuntiva, mantiene aperta ogni origine solo mentre viene copiata e salva il file finale una sola volta.

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

Questo è un punto di partenza utile per preservare la formattazione di origine delle diapositive importate. Se il tuo output deve utilizzare un unico tema di destinazione, sostituisci la semplice chiamata `addClone($slide)` con il sovraccarico di master o layout di destinazione appropriato mostrato in precedenza.

## **Considerazioni pratiche**

### **Master, layout e fedeltà della formattazione**

Il clonaggio predefinito delle diapositive può portare automaticamente un master di origine necessario nella presentazione di destinazione. Aspose.Slides mantiene un registro interno per i master clonati automaticamente, evitando di clonare lo stesso master più volte. I master clonati manualmente non sono tracciati da tale registro, quindi evita di pre-clonare i master a meno che tu non abbia bisogno di un controllo esplicito sulla struttura del master.

Non dare per scontato che due master o layout con lo stesso nome siano visivamente equivalenti. Se un modello aziendale deve controllare l'aspetto finale, scegli esplicitamente un master o layout di destinazione e verifica il risultato dopo l'unione.

### **Note e commenti**

Le note del relatore e i commenti delle diapositive sono associati al contenuto della diapositiva e vengono copiati quando una diapositiva è clonata. Aspose.Slides espone inoltre API dedicate per [presentation notes](/slides/it/php-java/presentation-notes/) e [presentation comments](/slides/it/php-java/presentation-comments/).

Se la formattazione della pagina delle note è importante, verifica la presentazione unita perché i master delle note sono oggetti a livello di presentazione e possono differire tra i file di origine. Per i flussi di revisione, verifica anche gli autori dei commenti e i commenti annidati dopo aver combinato file di autori o modelli diversi.

### **Immagini, audio, video, oggetti OLE e collegamenti esterni**

Le diapositive possono fare riferimento a risorse a livello di presentazione come immagini, audio incorporato, video incorporato e dati OLE. Clona l'intera diapositiva anziché copiare solo le forme visibili affinché Aspose.Slides mantenga le relazioni della diapositiva con le sue risorse.

Le risorse incorporate e collegate devono essere trattate diversamente. Un audio, video, oggetto OLE o hyperlink collegato rimane dipendente dal suo obiettivo esterno; clonare una diapositiva non trasforma un collegamento esterno in contenuto incorporato. Testa i percorsi e gli URL delle risorse collegate nell'ambiente in cui la presentazione unita verrà aperta.

Aspose.Slides traccia esplicitamente i master clonati automaticamente, ma ciò non costituisce una garanzia generale che risorse binarie identiche provenienti da presentazioni di origine non correlate vengano sempre deduplicate. Se la dimensione del file di output è importante, ispeziona il pacchetto unito e misura il risultato invece di fare affidamento sulla deduplicazione implicita.

### **Font incorporati e disponibilità dei font**

I font sono gestiti a livello di presentazione. Se la tipografia deve rimanere coerente tra macchine, non dare per scontato che la clonazione delle diapositive garantisca la disponibilità di tutti i font richiesti nell'ambiente di destinazione. Puoi ispezionare i font incorporati con [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/getembeddedfonts/) e gestire l'incorporamento esplicitamente come descritto in [Embed Fonts in Presentations](/slides/it/php-java/embedded-font/).

Verifica inoltre di avere l'autorizzazione per incorporare i font utilizzati nei file di origine. Le licenze dei font possono limitare l'incorporamento.

### **Presentazioni protette da password**

Una sorgente protetta da password deve essere aperta correttamente prima che le sue diapositive possano essere clonate. Fornisci la password tramite [LoadOptions::setPassword()](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Lavorare con la presentazione decrittata.
} finally {
    $source->dispose();
}
```

Aprire una sorgente crittografata non applica automaticamente la stessa protezione alla presentazione di destinazione. Configura la protezione dell'output separatamente quando necessario.

### **Presentazioni di grandi dimensioni e uso della memoria**

Le presentazioni di grandi dimensioni contenenti immagini ad alta risoluzione, audio, video o altri oggetti binari di grandi dimensioni possono consumare molta memoria. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) fornisce controlli per la gestione dei BLOB e l'uso di file temporanei. Consulta [Open Presentations](/slides/it/php-java/open-presentation/#open-large-presentations) per un esempio PHP via Java di file di grandi dimensioni.

Per file di grandi dimensioni, preferisci il caricamento da percorsi di file quando possibile, rilascia ogni presentazione di origine appena è stata unita e evita di salvare ripetutamente risultati intermedi salvo che il flusso di lavoro richieda punti di controllo.

### **Sicurezza dei thread**

Non caricare, modificare, salvare o clonare istanze di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) in più thread. Queste operazioni non sono supportate per l'uso multithread in PHP via Java. Se hai bisogno di lavori di unione paralleli, eseguili in processi separati a thread singolo, ciascuno con le proprie istanze di presentazione, e segui le [linee guida sul multithreading di Aspose.Slides](/slides/it/php-java/multithreading/).

## **FAQ**

**Come posso mantenere il design originale di ogni presentazione di origine?**

Usa [SlideCollection::addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) senza fornire un master o un layout di destinazione. Aspose.Slides può clonare automaticamente il master di origine quando è necessario per la diapositiva importata.

**Come faccio a far utilizzare alle diapositive importate il tema di destinazione?**

Usa il sovraccarico che accetta un master di destinazione. Passa un master dalla presentazione di destinazione, non da quella di origine. Aspose.Slides cercherà di mappare ogni diapositiva di origine a un layout appropriato sotto quel master.

**Quando dovrei usare un layout di destinazione specifico invece di un master di destinazione?**

Usa un layout specifico quando ogni diapositiva importata deve utilizzare un layout noto. Usa un master quando vuoi che Aspose.Slides selezioni tra i layout di quel master in base al tipo o al nome del layout di origine.

**Posso unire presentazioni con diverse dimensioni delle diapositive?**

Sì, ma il contenuto delle diapositive non viene ridisegnato automaticamente per le dimensioni di destinazione. Ridimensiona prima la presentazione di origine quando hai bisogno di un posizionamento prevedibile, ad esempio con [SlideSize::setSize()](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesize/setsize/) e [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesizescaletype/).

**Posso unire presentazioni PPT, PPTX e ODP in un unico file?**

Sì. Carica ogni presentazione di origine, clona le diapositive necessarie in una destinazione e salva la destinazione in un formato di output supportato. Poiché i formati di presentazione non supportano esattamente lo stesso insieme di funzionalità, verifica il contenuto complesso dopo unioni tra formati diversi. Consulta [Supported File Formats](/slides/it/php-java/supported-file-formats/).

**Le sezioni di origine vengono preservate automaticamente?**

No, non con un ciclo base che clona solo le diapositive. Ricrea le sezioni necessarie nella destinazione e usa il sovraccarico di sezione di [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/addclone/) quando la struttura delle sezioni deve essere mantenuta.

**Le note del relatore e i commenti vengono preservati?**

Vengono copiati con la diapositiva clonata. Per i flussi di lavoro che dipendono dallo stile del master delle note, dagli autori dei commenti o dai dati di revisione annidata, verifica il risultato unito perché questi scenari coinvolgono anche strutture a livello di presentazione oltre al contenuto delle diapositive.

**Cosa succede a audio, video, oggetti OLE e hyperlink?**

Il contenuto incorporato viene trasportato come parte delle relazioni di risorsa della diapositiva clonata. I collegamenti esterni rimangono esterni, quindi i file o gli URL di destinazione devono ancora essere disponibili dopo l'unione.

**I font incorporati da ogni origine sono garantiti disponibili nella presentazione unita?**

Non fare affidamento solo sul clonaggio delle diapositive per la distribuzione dei font. Ispeziona i font incorporati nella destinazione e gestisci esplicitamente l'incorporamento dei font o la disponibilità dei font esterni quando la tipografia è importante.

**Come unisco un file protetto da password?**

Aprilo con il corretto [LoadOptions::setPassword()](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/setpassword/), quindi clona le sue diapositive normalmente. La protezione dell'output viene configurata separatamente.

**Come devo gestire presentazioni molto grandi?**

Usa la gestione dei BLOB quando gli oggetti binari di grandi dimensioni dominano l'uso della memoria, preferisci il caricamento da percorso file per file molto grandi, rilascia prontamente le presentazioni di origine e salva il risultato finale solo quando necessario.

**Posso unire diapositive da più thread?**

Il caricamento, il salvataggio o la clonazione di presentazioni in più thread non è supportato in PHP via Java. Per lavori paralleli, utilizza processi separati a thread singolo e mantieni le istanze di presentazione isolate all'interno di ciascun processo.