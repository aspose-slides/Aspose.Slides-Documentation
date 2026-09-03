---
title: Gestire gli avvisi delle presentazioni in PHP
type: docs
weight: 90
url: /it/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback di avviso
- politica di avviso
- perdita di dati
- corruzione della sorgente
- problema di compatibilità
- sostituzione dei caratteri
- firma digitale
- caricamento della presentazione
- rendering della presentazione
- conversione della presentazione
- salvataggio della presentazione
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Scopri come raccogliere, classificare e gestire gli avvisi durante il caricamento, il rendering, la conversione e il salvataggio delle presentazioni con Aspose.Slides per PHP tramite Java."
---
## **Panoramica**

Aspose.Slides può segnalare problemi recuperabili durante il caricamento, il rendering, la conversione o il salvataggio di una presentazione. Esempi includono record di origine danneggiati, contenuti che non possono essere preservati, sostituzione dei caratteri e limitazioni del formato di destinazione. Un callback di avviso consente a un'applicazione di registrare queste condizioni e decidere se l'operazione corrente può continuare.

Crea una classe PHP con un metodo pubblico `warning` ed esponila tramite PHP Java Bridge come l'interfaccia Java [IWarningCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarningcallback/) usando `java_closure`. Esamina i valori restituiti da [getWarningType](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getWarningType--) e [getDescription](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getDescription--) attraverso [IWarningInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/). Restituisci [ReturnAction::Continue](https://reference.aspose.com/slides/it/php-java/aspose.slides/returnaction/#Continue) per accettare l'avviso o [ReturnAction::Abort](https://reference.aspose.com/slides/it/php-java/aspose.slides/returnaction/#Abort) per interrompere l'operazione.

Usa [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setWarningCallback) per gli avvisi generati durante l'apertura di una presentazione. Le classi di opzioni di rendering ed esportazione ereditano [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveoptions/#setWarningCallback), che riceve avvisi dal rendering delle diapositive, dalla conversione e dal salvataggio. Poiché l'avviso stesso non identifica l'operazione dell'applicazione, associa ogni istanza del callback a una fase operativa quando costruisci un report combinato.

## **Avvisi ed Eccezioni**

Le eccezioni Java sono esposte a PHP tramite PHP Java Bridge; catturale al confine dell'operazione, come mostrato nell'esempio sotto. I collegamenti all'interfaccia Java in questo articolo descrivono il contratto del callback usato dal bridge.

Un avviso descrive una condizione da cui Aspose.Slides può riprendersi se il callback restituisce `ReturnAction::Continue`. Un'eccezione indica che l'operazione richiesta non può completarsi normalmente; le eccezioni non vengono convertite in avvisi e non possono essere gestite da una politica di avviso.

Restituire `ReturnAction::Abort` chiede al dispatcher degli avvisi di terminare l'operazione corrente sollevando un'eccezione. L'eccezione pubblica dipende dall'operazione e dal formato della presentazione. Ad esempio, il caricamento può generare una [PptxReadException](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxreadexception/) o una [PptReadException](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptreadexception/), mentre il salvataggio o l'esportazione può generare una [PptxException](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxexception/). Gestisci l'eccezione al confine dell'operazione e utilizza il report degli avvisi per determinare se la politica dell'applicazione ha causato la terminazione, anziché fare affidamento su un sottotipo di eccezione o su un messaggio. Il callback registra l'avviso prima di restituire `ReturnAction::Abort`, garantendo che il motivo rimanga disponibile per l'applicazione.

## **Categorie di Avviso**

La classe [WarningType](https://reference.aspose.com/slides/it/php-java/aspose.slides/warningtype/) fornisce costanti intere per le seguenti categorie:

| Tipo di avviso | Significato | Politica tipica |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/it/php-java/aspose.slides/warningtype/#SourceFileCorruption) | Il file di origine contiene corruzioni che possono rendere inutilizzabile un documento salvato nel suo formato originale. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/it/php-java/aspose.slides/warningtype/#DataLoss) | Testi, grafici, immagini o altri dati potrebbero mancare dopo il caricamento o il salvataggio. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/it/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | La presentazione potrebbe perdere formattazioni importanti. | Abort in modalità di validazione rigorosa; altrimenti registra e prosegui. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/it/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | Potrebbe verificarsi una differenza di formattazione limitata. | Registra per diagnostica e prosegui. |
| [CompatibilityIssue](https://reference.aspose.com/slides/it/php-java/aspose.slides/warningtype/#CompatibilityIssue) | Il risultato potrebbe non aprirsi o comportarsi correttamente in alcune applicazioni o versioni più vecchie. | Registralo e prosegui a meno che la compatibilità non sia obbligatoria. |
| [UnexpectedContent](https://reference.aspose.com/slides/it/php-java/aspose.slides/warningtype/#UnexpectedContent) | L'origine contiene contenuti non supportati o non riconosciuti il cui effetto potrebbe non essere ancora noto. | Registra e prosegui, o trattalo come errore in una politica rigorosa. |

La categoria dovrebbe guidare la decisione di politica. Conserva il valore restituito da [getDescription](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getDescription--) per la diagnostica, ma non fare affidamento sulla sua formulazione per la logica dell'applicazione, poiché il testo del messaggio può variare tra scenari di avviso e versioni del prodotto.

## **Raccogliere e Classificare gli Avvisi**

L'esempio seguente utilizza un unico report a livello di applicazione per l'intera pipeline di elaborazione. Un'istanza di callback separata etichetta gli avvisi provenienti da caricamento, rendering, conversione PDF e salvataggio PPTX. La politica abortisce in caso di corruzione della sorgente o perdita di dati, opzionalmente abortisce in caso di perdita di formattazione maggiore e continua per gli altri avvisi. Il callback converte i valori di avviso in valori PHP native con `java_values` prima di registrarli e confrontarli.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

Passa `false` per `abortOnMajorFormattingLoss` quando costruisci `WarningPolicy` se le differenze di formattazione maggiori sono accettabili. I problemi di compatibilità, la perdita di formattazione minore e il contenuto inatteso rimangono comunque nel report anche quando l'operazione continua. Estendi `WarningPolicy::getAction` se l'applicazione deve rifiutare una di queste categorie.

## **Scenari Comuni di Avviso**

Gli avvisi possono comparire in diverse fasi di un flusso di lavoro:

- **Firme digitali:** Una presentazione firmata può generare un avviso durante il caricamento indicando che la firma verrà persa durante l'elaborazione. Aspose.Slides segnala questa condizione `DataLoss` tramite [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationsignedwarninginfo/). Un callback nella fase di caricamento consente all'applicazione di rifiutare il file o di accettare esplicitamente la perdita segnalata.
- **Sostituzione dei caratteri:** Un carattere non disponibile può essere sostituito durante il rendering o l'esportazione di una diapositiva. Gli avvisi di sostituzione dei caratteri sono segnalati come `DataLoss`, quindi la politica rigorosa sopra abortisce anche se l'applicazione considererebbe una determinata sostituzione accettabile dal punto di vista visivo. Per osservare questo comportamento, utilizza una presentazione di input contenente testo in un carattere non disponibile al runtime. La descrizione dell'avviso identifica la sostituzione; configura i caratteri necessari o le [regole di sostituzione dei caratteri](/slides/it/php-java/font-substitution/) prima di riprovare.
- **Contenuto non supportato o inatteso:** Un loader può incontrare record di presentazione o funzionalità che non riconosce. Tali avvisi possono usare `UnexpectedContent`, o una categoria più severa quando dati o formattazione si sa siano interessati.
- **Compatibilità del formato:** Il salvataggio in un altro formato di presentazione può omettere funzionalità o produrre un risultato che si comporta diversamente in alcune applicazioni. Ad esempio, salvare una presentazione con più di otto guide di disegno orizzontali o verticali in un PPT legacy genera un `CompatibilityIssue`. Il callback nella fase di salvataggio può registrare la perdita e continuare, o rifiutarla se è necessario preservare tutte le guide.
- **Comportamento di caricamento:** Opzioni di caricamento e comportamenti legacy possono anch'essi generare avvisi. Ad esempio, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifica l'uso di un comportamento di blocco della presentazione obsoleto come `CompatibilityIssue`.

Gli avvisi dipendono dal documento di origine, dal formato di destinazione, dall'operazione e dalla versione di Aspose.Slides. Non presumere che ogni file generi un avviso o che uno scenario mappi sempre a una sola categoria.

## **Gestire in Sicurezza le Operazioni Interrotte**

Quando un callback restituisce `ReturnAction::Abort`, non utilizzare un oggetto che non è stato caricato e non presumere che un output di rendering o di salvataggio sia completo. L'operazione può terminare dopo aver creato un file di output ma prima di completarlo.

Salva i risultati convalidati in un percorso separato, ad esempio `validated-output.pptx`. Sostituisci una presentazione esistente solo dopo che l'operazione è terminata con successo, il report degli avvisi soddisfa la politica dell'applicazione e l'output può essere aperto e verificato. In questo modo si evita di sovrascrivere un file sorgente valido con un risultato parziale o rifiutato.

Un report di avvisi vuoto non garantisce che tutte le funzionalità di origine siano state preservate. Applica ulteriori controlli di contenuto e visuali richiesti dall'applicazione. Vedi anche [Open Presentations](/slides/it/php-java/open-presentation/) e [Save Presentations](/slides/it/php-java/save-presentation/).

## **FAQ**

**Un callback di avviso può gestire tutti gli errori di Aspose.Slides?**

No. Gestisce solo le condizioni recuperabili segnalate come avvisi. Le eccezioni che si verificano indipendentemente dal callback devono essere gestite dall'applicazione attorno alla chiamata di caricamento, rendering, conversione o salvataggio.

**Restituire `ReturnAction::Continue` garantisce un output identico?**

No. Consente solo di proseguire l'elaborazione. La condizione segnalata può comunque causare differenze di dati, formattazione o compatibilità, quindi revisiona i tipi e le descrizioni degli avvisi raccolti.

**Come può un'applicazione identificare l'operazione che ha prodotto un avviso?**

Crea un'istanza di callback per ogni operazione e memorizza una fase definita dall'applicazione insieme ai valori restituiti da [getWarningType](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getWarningType--) e [getDescription](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getDescription--), come mostrato nell'esempio.