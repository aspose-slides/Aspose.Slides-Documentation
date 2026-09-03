---
title: Gestire gli avvisi delle presentazioni in Java
type: docs
weight: 90
url: /it/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Java
- Aspose.Slides
description: "Scopri come raccogliere, classificare e gestire gli avvisi durante il caricamento, il rendering, la conversione e il salvataggio delle presentazioni con Aspose.Slides per Java."
---
## **Panoramica**

Aspose.Slides può segnalare problemi recuperabili durante il caricamento, il rendering, la conversione o il salvataggio di una presentazione. Esempi includono record di origine danneggiati, contenuti che non possono essere preservati, la sostituzione dei caratteri e le limitazioni di un formato di destinazione. Un callback di avviso consente a un'applicazione di registrare queste condizioni e decidere se l'operazione corrente può continuare.

Implementare l'interfaccia [IWarningCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarningcallback/) e verificare i valori [getWarningType](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getWarningType--) e [getDescription](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getDescription--) forniti tramite [IWarningInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/). Restituire [ReturnAction.Continue](https://reference.aspose.com/slides/it/java/com.aspose.slides/returnaction/#Continue) per accettare l'avviso o [ReturnAction.Abort](https://reference.aspose.com/slides/it/java/com.aspose.slides/returnaction/#Abort) per interrompere l'operazione.

Usare [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) per gli avvisi generati durante l'apertura di una presentazione. Le classi di opzioni di rendering ed esportazione ereditano [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), che ricevono avvisi dal rendering delle diapositive, dalla conversione e dal salvataggio. Poiché l'avviso stesso non identifica l'operazione dell'applicazione, associare ogni istanza del callback a una fase operativa quando si costruisce un report combinato.

## **Avvisi ed eccezioni**

Un avviso descrive una condizione da cui Aspose.Slides può riprendersi se il callback restituisce `ReturnAction.Continue`. Un'eccezione indica che l'operazione richiesta non può completarsi normalmente; le eccezioni non vengono convertite in avvisi e non possono essere gestite da una politica di avviso.

Restituire `ReturnAction.Abort` chiede al dispatcher degli avvisi di terminare l'operazione corrente sollevando un'eccezione. L'eccezione pubblica dipende dall'operazione e dal formato della presentazione. Ad esempio, il caricamento può generare una [PptxReadException](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptxreadexception/) o una [PptReadException](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptreadexception/), mentre il salvataggio o l'esportazione possono generare una [PptxException](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptxexception/). Gestire l'eccezione al confine dell'operazione e usare il report degli avvisi per determinare se la politica dell'applicazione ha causato la terminazione anziché fare affidamento su un sottotipo di eccezione o su un messaggio. Il callback registra l'avviso prima di restituire `ReturnAction.Abort`, garantendo che il motivo rimanga disponibile per l'applicazione.

## **Categorie di avviso**

La classe [WarningType](https://reference.aspose.com/slides/it/java/com.aspose.slides/warningtype/) fornisce costanti intere per le seguenti categorie:

| Tipo di avviso | Significato | Politica tipica |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/it/java/com.aspose.slides/warningtype/#SourceFileCorruption) | La presentazione di origine contiene corruzione che può rendere inutilizzabile un documento salvato nel suo formato originale. | Interrompi. |
| [DataLoss](https://reference.aspose.com/slides/it/java/com.aspose.slides/warningtype/#DataLoss) | Testo, grafici, immagini o altri dati potrebbero mancare dopo il caricamento o il salvataggio. | Interrompi. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/it/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | La presentazione potrebbe perdere una formattazione importante. | Interrompi in modalità di validazione rigida; altrimenti registra e continua. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/it/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | Potrebbe verificarsi una limitata differenza di formattazione. | Registra per diagnosticare e continua. |
| [CompatibilityIssue](https://reference.aspose.com/slides/it/java/com.aspose.slides/warningtype/#CompatibilityIssue) | Il risultato potrebbe non aprirsi o comportarsi correttamente in alcune applicazioni o versioni più vecchie. | Registra e continua a meno che la compatibilità non sia obbligatoria. |
| [UnexpectedContent](https://reference.aspose.com/slides/it/java/com.aspose.slides/warningtype/#UnexpectedContent) | L'origine contiene contenuti non supportati o non riconosciuti il cui effetto potrebbe non essere ancora noto. | Registra e continua, oppure trattalo come errore in una policy rigorosa. |

La categoria dovrebbe guidare la decisione di politica. Memorizzare il valore restituito da [getDescription](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getDescription--) per scopi diagnostici, ma non fare affidamento sulla sua formulazione per la logica dell'applicazione perché il testo del messaggio può variare tra scenari di avviso e versioni del prodotto.

## **Raccogliere e classificare gli avvisi**

Il seguente esempio utilizza un report a livello di applicazione per l'intera pipeline di elaborazione. Un'istanza di callback separata etichetta gli avvisi provenienti da caricamento, rendering, conversione PDF e salvataggio PPTX. La politica interrompe in caso di corruzione della sorgente o perdita di dati, opzionalmente interrompe in caso di perdita di formattazione importante e continua per gli altri avvisi.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

Passare `false` per `abortOnMajorFormattingLoss` durante la costruzione di `WarningPolicy` se le differenze di formattazione importanti sono accettabili. I problemi di compatibilità, la perdita di formattazione minore e i contenuti inaspettati rimangono comunque nel report anche quando l'operazione continua. Estendere `WarningPolicy.getAction` se l'applicazione deve rifiutare una di quelle categorie.

## **Scenari comuni di avviso**

- **Firme digitali:** Una presentazione firmata può generare un avviso durante il caricamento indicando che la firma verrà persa durante l'elaborazione. Aspose.Slides segnala questa condizione `DataLoss` tramite [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationsignedwarninginfo/). Un callback nella fase di caricamento consente all'applicazione di rifiutare il file o accettare esplicitamente la perdita segnalata.
- **Sostituzione dei caratteri:** Un carattere non disponibile può essere sostituito mentre una diapositiva viene renderizzata o esportata. Gli avvisi di sostituzione dei caratteri sono segnalati come `DataLoss`, quindi la politica rigorosa sopra interrompe anche se l'applicazione considererebbe accettabile una determinata sostituzione dal punto di vista visivo. Per osservare questo comportamento, utilizzare una presentazione di input contenente testo in un carattere non disponibile al runtime. La descrizione dell'avviso identifica la sostituzione; configurare i caratteri richiesti o le [font substitution rules](/slides/it/java/font-substitution/) prima di riprovare.
- **Contenuto non supportato o inaspettato:** Un caricatore può incontrare record o funzionalità della presentazione che non riconosce. Tali avvisi possono utilizzare `UnexpectedContent`, o una categoria più severa quando si sa che dati o formattazione sono interessati.
- **Compatibilità del formato:** Il salvataggio in un altro formato di presentazione può omettere funzionalità o produrre un risultato che si comporta diversamente in alcune applicazioni. Ad esempio, salvare una presentazione con più di otto guide di disegno orizzontali o verticali in un PPT legacy genera un `CompatibilityIssue`. Il callback nella fase di salvataggio può registrare la perdita e continuare, oppure rifiutarla se è necessario preservare tutte le guide.
- **Comportamento di caricamento:** Opzioni di caricamento e comportamenti legacy possono anch'essi generare avvisi. Ad esempio, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifica l'uso di un comportamento di blocco della presentazione obsoleto come `CompatibilityIssue`.

Gli avvisi dipendono dal documento di origine, dal formato di destinazione, dall'operazione e dalla versione di Aspose.Slides. Non presumere che ogni file generi un avviso o che uno scenario mappi sempre a una sola categoria.

## **Gestire in modo sicuro le operazioni interrotte**

Quando un callback restituisce `ReturnAction.Abort`, non utilizzare un oggetto che non è stato caricato correttamente e non presumere che un output di rendering o salvataggio sia completo. L'operazione può terminare dopo la creazione di un file di output ma prima del completamento.

Salvare i risultati convalidati in un percorso separato, ad esempio `validated-output.pptx`. Sostituire una presentazione esistente solo dopo che l'operazione è terminata con successo, il report degli avvisi soddisfa la politica dell'applicazione e l'output può essere aperto e verificato. Questo evita di sovrascrivere un file di origine valido con un risultato parziale o rifiutato.

Un report di avvisi vuoto non garantisce che ogni caratteristica di origine sia stata preservata. Applicare ulteriori controlli di contenuto e visuali richiesti dall'applicazione. Vedere anche [Open Presentations](/slides/it/java/open-presentation/) e [Save Presentations](/slides/it/java/save-presentation/).

## **FAQ**

**Il callback di avviso può gestire tutti gli errori di Aspose.Slides?**

No. Gestisce condizioni recuperabili segnalate come avvisi. Le eccezioni che si verificano indipendentemente dal callback devono essere gestite dall'applicazione intorno alla chiamata di caricamento, rendering, conversione o salvataggio.

**Restituire `ReturnAction.Continue` garantisce un output identico?**

No. Consente solo di proseguire l'elaborazione. La condizione segnalata può comunque causare differenze di dati, formattazione o compatibilità, quindi è necessario esaminare i tipi di avviso e le descrizioni raccolte.

**Come può un'applicazione identificare l'operazione che ha prodotto un avviso?**

Creare un'istanza di callback per ciascuna operazione e memorizzare una fase definita dall'applicazione insieme ai valori restituiti da [getWarningType](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getWarningType--) e [getDescription](https://reference.aspose.com/slides/it/java/com.aspose.slides/iwarninginfo/#getDescription--), come mostrato nell'esempio.