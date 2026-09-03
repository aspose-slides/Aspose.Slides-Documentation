---
title: Gestire gli avvisi delle presentazioni su Android
type: docs
weight: 90
url: /it/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Android
- Java
- Aspose.Slides
description: "Scopri come raccogliere, classificare e gestire gli avvisi durante il caricamento, il rendering, la conversione e il salvataggio delle presentazioni con Aspose.Slides per Android tramite Java."
---
## **Panoramica**

Aspose.Slides può segnalare problemi recuperabili durante il caricamento, il rendering, la conversione o il salvataggio di una presentazione. Gli esempi includono record di origine danneggiati, contenuti che non possono essere preservati, la sostituzione dei caratteri e le limitazioni di un formato di destinazione. Una callback di avviso consente a un'applicazione di registrare queste condizioni e decidere se l'operazione corrente può continuare.

Implementa l'interfaccia [IWarningCallback](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iwarningcallback/) e esamina i valori [getWarningType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) e [getDescription](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) forniti tramite [IWarningInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iwarninginfo/). Restituisci [ReturnAction.Continue](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/returnaction/#Continue) per accettare l'avviso o [ReturnAction.Abort](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/returnaction/#Abort) per interrompere l'operazione.

Usa [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) per gli avvisi generati durante l'apertura di una presentazione. Le classi di opzioni di rendering ed esportazione ereditano [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), che riceve avvisi dal rendering delle diapositive, dalla conversione e dal salvataggio. Poiché l'avviso stesso non identifica l'operazione dell'applicazione, associa ogni istanza della callback a una fase dell'operazione quando costruisci un report combinato.

## **Avvisi ed Eccezioni**

Un avviso descrive una condizione da cui Aspose.Slides può recuperare se la callback restituisce `ReturnAction.Continue`. Un'eccezione indica che l'operazione richiesta non può completarsi normalmente; le eccezioni non vengono convertite in avvisi e non possono essere gestite da una politica di avviso.

Restituire `ReturnAction.Abort` chiede al dispatcher degli avvisi di terminare l'operazione corrente sollevando un'eccezione. L'eccezione pubblica dipende dall'operazione e dal formato della presentazione. Ad esempio, il caricamento può generare una [PptxReadException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pptxreadexception/) o una [PptReadException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pptreadexception/), mentre il salvataggio o l'esportazione possono generare una [PptxException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pptxexception/). Gestisci l'eccezione al confine dell'operazione e utilizza il report degli avvisi per determinare se la politica dell'applicazione ha causato la terminazione, anziché fare affidamento su un unico sottotipo di eccezione o messaggio. La callback registra l'avviso prima di restituire `ReturnAction.Abort`, garantendo che il motivo rimanga disponibile per l'applicazione.

## **Categorie di Avviso**

La classe [WarningType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/warningtype/) fornisce costanti intere per le seguenti categorie:

| Tipo di avviso | Significato | Politica tipica |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | La presentazione di origine contiene corruzione che può rendere inutilizzabile un documento salvato nel suo formato originale. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/warningtype/#DataLoss) | Testi, grafici, immagini o altri dati potrebbero mancare dopo il caricamento o il salvataggio. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | La presentazione può perdere formattazioni importanti. | Abort in modalità di validazione rigorosa; altrimenti registra e continua. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | Potrebbe verificarsi una limitata differenza di formattazione. | Registra per diagnosi e continua. |
| [CompatibilityIssue](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | Il risultato potrebbe non aprirsi o comportarsi correttamente in alcune applicazioni o versioni più vecchie. | Registra e continua a meno che la compatibilità non sia obbligatoria. |
| [UnexpectedContent](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | La sorgente contiene contenuti non supportati o non riconosciuti il cui effetto potrebbe non essere ancora noto. | Registra e continua, o tratta come errore in una politica rigorosa. |

La categoria dovrebbe guidare la decisione di politica. Conserva il valore restituito da [getDescription](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) per la diagnostica, ma non basarti sul suo testo per la logica applicativa poiché il messaggio può variare tra scenari di avviso e versioni del prodotto.

## **Raccogliere e Classificare gli Avvisi**

L'esempio seguente utilizza un unico report a livello di applicazione per l'intera pipeline di elaborazione. Un'istanza di callback separata etichetta gli avvisi provenienti dal caricamento, dal rendering, dalla conversione PDF e dal salvataggio PPTX. La politica interrompe in caso di corruzione della sorgente o perdita di dati, opzionalmente interrompe in caso di perdita di formattazione importante e continua per gli altri avvisi.

Posiziona `input.pptx` in una directory scrivibile dell'applicazione e passa quella directory a `PresentationWarningExample.run`. L'esempio salva i risultati nella stessa directory. Esegui l'elaborazione della presentazione in un thread di background per mantenere reattiva l'interfaccia utente Android.

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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

Passa `false` per `abortOnMajorFormattingLoss` quando crei `WarningPolicy` se le differenze di formattazione importanti sono accettabili. Problemi di compatibilità, perdita di formattazione minore e contenuto inaspettato rimangono comunque nel report anche quando l'operazione continua. Estendi `WarningPolicy.getAction` se l'applicazione deve rifiutare una di queste categorie.

## **Scenari Comuni di Avviso**

Gli avvisi possono comparire in diverse fasi di un flusso di lavoro:

- **Firme digitali:** Una presentazione firmata può generare un avviso durante il caricamento indicando che la firma sarà persa durante l'elaborazione. Aspose.Slides riporta questa condizione `DataLoss` tramite [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/). Una callback nella fase di caricamento consente all'applicazione di rifiutare il file o accettare esplicitamente la perdita segnalata.
- **Sostituzione dei caratteri:** Un carattere non disponibile può essere sostituito mentre una diapositiva viene renderizzata o esportata. Gli avvisi di sostituzione dei caratteri sono riportati come `DataLoss`, quindi la politica rigorosa sopra interrompe anche se l'applicazione considererebbe accettabile una sostituzione visivamente adeguata. Per osservare questo comportamento, usa una presentazione di input contenente testo in un carattere non disponibile a runtime. La descrizione dell'avviso identifica la sostituzione; configura i caratteri richiesti o le [regole di sostituzione dei caratteri](/slides/it/androidjava/font-substitution/) prima di riprovare.
- **Contenuto non supportato o inaspettato:** Un loader può incontrare record o funzionalità della presentazione non riconosciuti. Tali avvisi possono usare `UnexpectedContent` o una categoria più severa quando si sa che dati o formattazione sono interessati.
- **Compatibilità del formato:** Il salvataggio in un altro formato di presentazione può omettere funzionalità o produrre un risultato che si comporta diversamente in alcune applicazioni. Ad esempio, salvare una presentazione con più di otto guide di disegno orizzontali o verticali in un PPT legacy riporta un `CompatibilityIssue`. La callback nella fase di salvataggio può registrare la perdita e continuare, o rifiutarla se è necessario preservare tutte le guide.
- **Comportamento di caricamento:** Opzioni di caricamento e comportamenti legacy possono anche generare avvisi. Ad esempio, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifica l'uso di un comportamento di blocco della presentazione obsoleto come `CompatibilityIssue`.

Gli avvisi dipendono dal documento di origine, dal formato di destinazione, dall'operazione e dalla versione di Aspose.Slides. Non presumere che ogni file generi un avviso o che uno scenario mappi sempre a una sola categoria.

## **Gestire in Sicurezza le Operazioni Interrotte**

Quando una callback restituisce `ReturnAction.Abort`, non utilizzare un oggetto che non è stato caricato correttamente e non presumere che un output di rendering o salvataggio sia completo. L'operazione può terminare dopo aver creato un file di output ma prima di completarlo.

Salva i risultati convalidati in un percorso separato, ad esempio `validated-output.pptx`. Sostituisci una presentazione esistente solo dopo che l'operazione è terminata con successo, il report degli avvisi soddisfa la politica dell'applicazione e l'output può essere aperto e verificato. Questo evita di sovrascrivere un file di origine valido con un risultato parziale o rifiutato.

Un report di avvisi vuoto non garantisce che ogni caratteristica di origine sia stata preservata. Applica tutte le verifiche aggiuntive di contenuto e visive richieste dall'applicazione. Vedi anche [Open Presentations](/slides/it/androidjava/open-presentation/) e [Save Presentations](/slides/it/androidjava/save-presentation/).

## **FAQ**

**Una callback di avviso può gestire ogni errore di Aspose.Slides?**

No. Gestisce solo le condizioni recuperabili segnalate come avvisi. Le eccezioni che si verificano indipendentemente dalla callback devono essere gestite dall'applicazione intorno alla chiamata di caricamento, rendering, conversione o salvataggio.

**Restituire `ReturnAction.Continue` garantisce un output identico?**

No. Consente solo di proseguire l'elaborazione. La condizione segnalata può comunque provocare differenze di dati, formattazione o compatibilità, quindi rivedi i tipi di avviso e le descrizioni raccolti.

**Come può un'applicazione identificare l'operazione che ha prodotto un avviso?**

Crea un'istanza di callback per ogni operazione e conserva una fase definita dall'applicazione insieme ai valori restituiti da [getWarningType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) e [getDescription](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iwarninginfo/#getDescription--), come mostrato nell'esempio.