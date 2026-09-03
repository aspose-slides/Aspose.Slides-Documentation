---
title: Gestire gli avvisi della presentazione in Node.js
type: docs
weight: 90
url: /it/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- JavaScript
- Node.js
- Aspose.Slides
description: "Impara a raccogliere, classificare e gestire gli avvisi durante il caricamento, il rendering, la conversione e il salvataggio delle presentazioni con Aspose.Slides per Node.js via Java."
---
## **Panoramica**

Aspose.Slides può segnalare problemi recuperabili durante il caricamento, il rendering, la conversione o il salvataggio di una presentazione. Gli esempi includono record di origine danneggiati, contenuti che non possono essere preservati, sostituzione dei caratteri e limitazioni di un formato di destinazione. Un callback di avviso consente a un'applicazione di registrare queste condizioni e decidere se l'operazione corrente può continuare.

Usa `java.newProxy` per implementare l'interfaccia Java [IWarningCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarningcallback/) in JavaScript ed esaminare i valori [getWarningType](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getWarningType--) e [getDescription](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getDescription--) forniti tramite [IWarningInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/). Restituisci [ReturnAction.Continue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/returnaction/#Continue) per accettare l'avviso o [ReturnAction.Abort](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/returnaction/#Abort) per interrompere l'operazione.

Usa [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) per gli avvisi generati durante l'apertura di una presentazione. Le classi di opzioni di rendering ed esportazione ereditano [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveoptions/#setWarningCallback), che riceve avvisi dal rendering delle diapositive, dalla conversione e dal salvataggio. Poiché l'avviso stesso non identifica l'operazione dell'applicazione, associa ogni istanza del callback a una fase dell'operazione quando crei un report combinato.

## **Avvisi ed Eccezioni**

Un avviso descrive una condizione da cui Aspose.Slides può recuperare se il callback restituisce `ReturnAction.Continue`. Un'eccezione indica che l'operazione richiesta non può completarsi normalmente; le eccezioni non vengono convertite in avvisi e non possono essere gestite da una politica di avviso.

Restituire `ReturnAction.Abort` chiede al dispatcher degli avvisi di terminare l'operazione corrente sollevando un'eccezione. L'eccezione pubblica dipende dall'operazione e dal formato della presentazione. Ad esempio, il caricamento può generare una [PptxReadException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxreadexception/) o una [PptReadException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptreadexception/), mentre il salvataggio o l'esportazione possono generare una [PptxException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxexception/). Cattura l'errore dal bridge Java al confine dell'operazione e utilizza il report degli avvisi per determinare se la politica dell'applicazione ha causato la terminazione invece di fare affidamento su un sottotipo o messaggio di eccezione. Il callback registra l'avviso prima di restituire `ReturnAction.Abort`, garantendo che il motivo rimanga disponibile per l'applicazione.

## **Categorie di Avviso**

La classe [WarningType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/warningtype/) fornisce costanti intere per le seguenti categorie:

| Tipo di avviso | Significato | Politica tipica |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | La presentazione di origine contiene corruzione che può rendere inutilizzabile un documento salvato nel suo formato originale. | Interrompi. |
| [DataLoss](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/warningtype/#DataLoss) | Testo, grafici, immagini o altri dati potrebbero mancare dopo il caricamento o il salvataggio. | Interrompi. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | La presentazione potrebbe perdere formattazioni importanti. | Interrompi in modalità di validazione stretta; altrimenti registra e continua. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | Potrebbe verificarsi una piccola differenza di formattazione. | Registra per la diagnostica e continua. |
| [CompatibilityIssue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | Il risultato potrebbe non aprirsi o comportarsi correttamente in alcune applicazioni o versioni più vecchie. | Registra nel log e continua a meno che la compatibilità non sia obbligatoria. |
| [UnexpectedContent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | La sorgente contiene contenuti non supportati o non riconosciuti il cui effetto potrebbe non essere ancora noto. | Registra e continua, o tratta come errore in una politica rigida. |

La categoria dovrebbe guidare la decisione della politica. Conserva il valore restituito da [getDescription](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getDescription--) per la diagnostica, ma non fare affidamento sulla sua formulazione per la logica dell'applicazione poiché il testo del messaggio può variare tra scenari di avviso e versioni del prodotto.

## **Raccogliere e Classificare gli Avvisi**

Il seguente esempio JavaScript utilizza un unico report a livello di applicazione per l'intera pipeline di elaborazione. Un'istanza di callback separata etichetta gli avvisi provenienti dal caricamento, dal rendering, dalla conversione PDF e dal salvataggio PPTX. La politica interrompe in caso di corruzione della sorgente o perdita di dati, opzionalmente interrompe in caso di perdita di formattazione importante e continua per gli altri avvisi.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

Passa `false` per `abortOnMajorFormattingLoss` durante la costruzione di `WarningPolicy` se le differenze di formattazione importanti sono accettabili. I problemi di compatibilità, la perdita di formattazione minore e i contenuti inaspettati vengono comunque mantenuti nel report anche quando l'operazione continua. Estendi `WarningPolicy.getAction` se l'applicazione deve rifiutare una di queste categorie.

## **Scenari di Avviso Comuni**

Gli avvisi possono apparire in diverse fasi di un flusso di lavoro:

- **Digital signatures:** Una presentazione firmata può generare un avviso durante il caricamento indicando che la firma verrà persa durante l'elaborazione. Aspose.Slides segnala questa condizione `DataLoss` tramite [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationsignedwarninginfo/). Un callback nella fase di caricamento consente all'applicazione di rifiutare il file o di accettare esplicitamente la perdita segnalata.
- **Font substitution:** Un carattere non disponibile può essere sostituito durante il rendering o l'esportazione di una diapositiva. Gli avvisi di sostituzione dei caratteri sono segnalati come `DataLoss`, quindi la politica rigida sopra interrompe anche se l'applicazione considererebbe una specifica sostituzione accettabile visivamente. Per osservare questo comportamento, utilizza una presentazione di input contenente testo in un carattere non disponibile al runtime. La descrizione dell'avviso identifica la sostituzione; configura i caratteri richiesti o le [regole di sostituzione dei caratteri](/slides/it/nodejs-java/font-substitution/) prima di riprovare.
- **Unsupported or unexpected content:** Un loader può incontrare record o funzionalità della presentazione che non riconosce. Tali avvisi possono utilizzare `UnexpectedContent`, o una categoria più severa quando si sa che dati o formattazione sono interessati.
- **Format compatibility:** Il salvataggio in un altro formato di presentazione può omettere funzionalità o produrre un risultato che si comporta diversamente in alcune applicazioni. Per esempio, salvare una presentazione con più di otto guide di disegno orizzontali o otto verticali in un PPT legacy genera un `CompatibilityIssue`. Il callback nella fase di salvataggio può registrare la perdita e continuare, o rifiutarla se è necessario preservare tutte le guide.
- **Loading behavior:** Le opzioni di caricamento e i comportamenti legacy possono anche generare avvisi. Per esempio, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifica l'uso di un comportamento di blocco della presentazione obsoleto come un `CompatibilityIssue`.

Gli avvisi dipendono dal documento di origine, dal formato di destinazione, dall'operazione e dalla versione di Aspose.Slides. Non presumere che ogni file generi un avviso o che uno scenario corrisponda sempre a una sola categoria.

## **Gestire in Sicurezza le Operazioni Interrotte**

Quando un callback restituisce `ReturnAction.Abort`, non utilizzare un oggetto che non è stato caricato e non presumere che un output di rendering o salvataggio sia completo. L'operazione può terminare dopo aver creato un file di output ma prima di averlo completato.

Salva i risultati convalidati in un percorso separato, ad esempio `validated-output.pptx`. Sostituisci una presentazione esistente solo dopo che l'operazione è terminata con successo, il report degli avvisi soddisfa la politica dell'applicazione e l'output può essere aperto e verificato. Questo evita di sovrascrivere un file di origine valido con un risultato parziale o rifiutato.

Un report di avviso vuoto non garantisce che ogni funzionalità di origine sia stata preservata. Applica eventuali controlli aggiuntivi di contenuto e visivi richiesti dall'applicazione. Vedi anche [Open Presentations](/slides/it/nodejs-java/open-presentation/) e [Save Presentations](/slides/it/nodejs-java/save-presentation/).

## **FAQ**

**Il callback di avviso può gestire tutti gli errori di Aspose.Slides?**

No. Gestisce condizioni recuperabili segnalate come avvisi. Le eccezioni che si verificano indipendentemente dal callback devono essere gestite dall'applicazione attorno alla chiamata di caricamento, rendering, conversione o salvataggio.

**Restituire `ReturnAction.Continue` garantisce un output identico?**

No. Consente solo di continuare l'elaborazione. La condizione segnalata può comunque causare differenze di dati, formattazione o compatibilità, quindi esamina i tipi di avviso e le descrizioni raccolti.

**Come può un'applicazione identificare l'operazione che ha prodotto un avviso?**

Crea un'istanza di callback per ogni operazione e memorizza una fase definita dall'applicazione insieme ai valori restituiti da [getWarningType](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getWarningType--) e [getDescription](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getDescription--), come mostrato nell'esempio.