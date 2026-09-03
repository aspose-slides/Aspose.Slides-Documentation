---
title: Gestire gli avvisi delle presentazioni in .NET
type: docs
weight: 120
url: /it/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- .NET
- C#
- Aspose.Slides
description: "Scopri come raccogliere, classificare e gestire gli avvisi durante il caricamento, il rendering, la conversione e il salvataggio delle presentazioni con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides può segnalare problemi recuperabili durante il caricamento, il rendering, la conversione o il salvataggio di una presentazione. Gli esempi includono record di origine danneggiati, contenuti che non possono essere preservati, la sostituzione dei caratteri e le limitazioni di un formato di destinazione. Un callback di avviso consente a un'applicazione di registrare queste condizioni e decidere se l'operazione corrente può continuare.

Implementare l'[IWarningCallback](https://reference.aspose.com/slides/it/net/aspose.slides.warnings/iwarningcallback/) interfaccia e esaminare le proprietà [WarningType](https://reference.aspose.com/slides/it/net/aspose.slides.warnings/iwarninginfo/warningtype/) e [Description](https://reference.aspose.com/slides/it/net/aspose.slides.warnings/iwarninginfo/description/) fornite tramite [IWarningInfo](https://reference.aspose.com/slides/it/net/aspose.slides.warnings/iwarninginfo/). Restituire [ReturnAction.Continue](https://reference.aspose.com/slides/it/net/aspose.slides.warnings/returnaction/) per accettare l'avviso o `ReturnAction.Abort` per interrompere l'operazione.

Utilizzare [LoadOptions.WarningCallback](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/warningcallback/) per gli avvisi generati durante l'apertura di una presentazione. Le classi di opzioni di rendering ed esportazione ereditano [SaveOptions.WarningCallback](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveoptions/warningcallback/), che riceve avvisi dal rendering delle diapositive, dalla conversione e dal salvataggio. Poiché l'avviso stesso non identifica l'operazione dell'applicazione, associare ogni istanza di callback a una fase dell'operazione quando si crea un rapporto combinato.

## **Avvisi ed Eccezioni**

Un avviso descrive una condizione da cui Aspose.Slides può recuperare se il callback restituisce `ReturnAction.Continue`. Un'eccezione indica che l'operazione richiesta non può completarsi normalmente; le eccezioni non vengono convertite in avvisi e non possono essere gestite da una politica di avviso.

Restituire `ReturnAction.Abort` richiede al dispatcher di avviso di terminare l'operazione corrente sollevando un'eccezione. L'eccezione pubblica dipende dall'operazione e dal formato della presentazione. Ad esempio, il caricamento può generare una [PptxReadException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxreadexception/) o una [PptReadException](https://reference.aspose.com/slides/it/net/aspose.slides/pptreadexception/), mentre il salvataggio o l'esportazione possono generare una [PptxException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxexception/). Gestire l'eccezione al confine dell'operazione e utilizzare il rapporto di avviso per determinare se la politica dell'applicazione ha causato la terminazione invece di fare affidamento su un sottotipo di eccezione o su un messaggio. Il callback registra l'avviso prima di restituire `ReturnAction.Abort`, garantendo che il motivo rimanga disponibile per l'applicazione.

## **Categorie di Avviso**

L'enumerazione [WarningType](https://reference.aspose.com/slides/it/net/aspose.slides.warnings/warningtype/) fornisce le seguenti categorie:

| Tipo di avviso | Significato | Politica tipica |
| --- | --- | --- |
| `SourceFileCorruption` | La presentazione di origine contiene corruzione che può rendere inutilizzabile un documento salvato nel suo formato originale. | Abort. |
| `DataLoss` | Testo, grafici, immagini o altri dati potrebbero mancare dopo il caricamento o il salvataggio. | Abort. |
| `MajorFormattingLoss` | La presentazione può perdere una formattazione importante. | Abort in modalità di convalida rigorosa; altrimenti registrare e continuare. |
| `MinorFormattingLoss` | Potrebbe verificarsi una differenza di formattazione limitata. | Registrare per diagnostica e continuare. |
| `CompatibilityIssue` | Il risultato potrebbe non aprirsi o comportarsi correttamente in alcune applicazioni o versioni precedenti. | Registrare e continuare a meno che la compatibilità non sia obbligatoria. |
| `UnexpectedContent` | L'origine contiene contenuti non supportati o non riconosciuti il cui effetto potrebbe non essere ancora noto. | Registrare e continuare, o trattare come errore in una politica rigorosa. |

La categoria dovrebbe guidare la decisione della politica. Conservare `Description` per la diagnostica, ma non fare affidamento sulla sua formulazione per la logica dell'applicazione perché il testo del messaggio può variare tra scenari di avviso e versioni del prodotto.

## **Raccogliere e Classificare gli Avvisi**

L'esempio seguente utilizza un unico rapporto a livello di applicazione per l'intera pipeline di elaborazione. Un'istanza di callback separata etichetta gli avvisi provenienti da caricamento, rendering, conversione PDF e salvataggio PPTX. La politica interrompe in caso di corruzione della sorgente o perdita di dati, opzionalmente interrompe in caso di perdita di formattazione importante e continua per gli altri avvisi.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

Impostare `abortOnMajorFormattingLoss` su `false` quando le differenze di formattazione importanti sono accettabili. I problemi di compatibilità, la perdita di formattazione minore e i contenuti inaspettati sono comunque mantenuti nel rapporto anche quando l'operazione continua. Estendere `WarningPolicy.GetAction` se l'applicazione deve rifiutare una di queste categorie.

## **Scenari di Avviso Comuni**

Gli avvisi possono apparire in diverse fasi di un flusso di lavoro:

- **Signature digitali:** Una presentazione firmata può generare un avviso durante il caricamento che la sua firma verrà persa durante l'elaborazione. Aspose.Slides segnala questa condizione `DataLoss` tramite [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/it/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). Un callback nella fase di caricamento consente all'applicazione di rifiutare il file o accettare esplicitamente la perdita segnalata.
- **Sostituzione dei caratteri:** Un carattere non disponibile può essere sostituito durante il rendering o l'esportazione di una diapositiva. Gli avvisi di sostituzione dei caratteri sono segnalati come `DataLoss`, quindi la politica rigorosa sopra interrompe anche se l'applicazione considererebbe una determinata sostituzione visivamente accettabile. Per osservare questo comportamento, utilizzare una presentazione di input contenente testo in un carattere non disponibile per il runtime. La descrizione dell'avviso identifica la sostituzione; configurare i caratteri richiesti o le [regole di sostituzione dei caratteri](/slides/it/net/font-substitution/) prima di riprovare.
- **Contenuto non supportato o inatteso:** Un loader può incontrare record o funzionalità della presentazione non riconosciuti. Tali avvisi possono utilizzare `UnexpectedContent`, o una categoria più severa quando si sa che dati o formattazione sono interessati.
- **Compatibilità del formato:** Il salvataggio in un altro formato di presentazione può omettere funzionalità o produrre un risultato che si comporta diversamente in alcune applicazioni. Ad esempio, salvare una presentazione con più di otto guide di disegno orizzontali o otto verticali in PPT legacy genera un `CompatibilityIssue`. Il callback nella fase di salvataggio può registrare la perdita e continuare, o rifiutarla se è necessario preservare tutte le guide.
- **Comportamento di caricamento:** Le opzioni di caricamento e i comportamenti legacy possono anche generare avvisi. Ad esempio, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/it/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identifica l'uso di un comportamento di blocco della presentazione obsoleto come `CompatibilityIssue`.

Gli avvisi dipendono dal documento di origine, dal formato di destinazione, dall'operazione e dalla versione di Aspose.Slides. Non assumere che ogni file generi un avviso o che uno scenario corrisponda sempre a una sola categoria.

## **Gestire in Sicurezza le Operazioni Interrotte**

Quando un callback restituisce `ReturnAction.Abort`, non utilizzare un oggetto che non è stato caricato e non assumere che un'output di rendering o salvataggio sia completo. L'operazione può terminare dopo la creazione di un file di output ma prima di completarlo.

Salvare i risultati convalidati in un percorso separato, ad esempio `validated-output.pptx`. Sostituire una presentazione esistente solo dopo che l'operazione è terminata con successo, il rapporto di avviso soddisfa la politica dell'applicazione e l'output può essere aperto e verificato. Ciò evita di sovrascrivere un file sorgente valido con un risultato parziale o rifiutato.

Un rapporto di avviso vuoto non garantisce che ogni funzionalità di origine sia stata preservata. Applicare eventuali controlli aggiuntivi di contenuto e visivi richiesti dall'applicazione. Vedi anche [Apri Presentazioni](/slides/it/net/open-presentation/) e [Salva Presentazioni](/slides/it/net/save-presentation/).

## **FAQ**

**Un callback di avviso può gestire ogni errore di Aspose.Slides?**

No. Gestisce condizioni recuperabili segnalate come avvisi. Le eccezioni che si verificano indipendentemente dal callback devono essere gestite dall'applicazione attorno alla chiamata di caricamento, rendering, conversione o salvataggio.

**Restituire `ReturnAction.Continue` garantisce un output identico?**

No. Consente solo di continuare l'elaborazione. La condizione segnalata può comunque causare differenze di dati, formattazione o compatibilità, quindi rivedere i tipi di avviso e le descrizioni raccolti.

**Come può un'applicazione identificare l'operazione che ha prodotto un avviso?**

Creare un'istanza di callback per ogni operazione e memorizzare una fase definita dall'applicazione insieme a `WarningType` e `Description`, come mostrato nell'esempio.