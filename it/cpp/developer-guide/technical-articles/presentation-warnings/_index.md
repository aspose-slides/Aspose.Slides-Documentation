---
title: Gestire gli avvisi di presentazione in C++
type: docs
weight: 70
url: /it/cpp/presentation-warnings/
aliases:
- /cpp/ottenere-callback-di-avviso-per-sostituzione-dei-font-in-aspose-slides/
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
- C++
- Aspose.Slides
description: "Scopri come raccogliere, classificare e gestire gli avvisi durante il caricamento, il rendering, la conversione e il salvataggio delle presentazioni con Aspose.Slides per C++."
---
## **Panoramica**

Aspose.Slides può segnalare problemi recuperabili durante il caricamento, il rendering, la conversione o il salvataggio di una presentazione. Esempi includono record sorgente danneggiati, contenuti che non possono essere preservati, sostituzione dei caratteri e limitazioni di un formato di destinazione. Un callback di avviso consente a un'applicazione di registrare queste condizioni e decidere se l'operazione corrente può continuare.

Implementare l'[IWarningCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides.warnings/iwarningcallback/) interfaccia e esaminare i metodi [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/it/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) e [IWarningInfo::get_Description](https://reference.aspose.com/slides/it/cpp/aspose.slides.warnings/iwarninginfo/get_description/) forniti tramite [IWarningInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides.warnings/iwarninginfo/). Restituire [ReturnAction::Continue](https://reference.aspose.com/slides/it/cpp/aspose.slides.warnings/returnaction/) per accettare l'avviso o `ReturnAction::Abort` per interrompere l'operazione.

Usare [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_warningcallback/) per gli avvisi generati durante l'apertura di una presentazione. Le classi di opzioni di rendering ed esportazione ereditano [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveoptions/set_warningcallback/), che riceve avvisi dal rendering delle diapositive, dalla conversione e dal salvataggio. Poiché l'avviso stesso non identifica l'operazione dell'applicazione, associare ogni istanza di callback a una fase dell'operazione quando si costruisce un report combinato.

## **Avvisi ed Eccezioni**

Un avviso descrive una condizione da cui Aspose.Slides può recuperare se il callback restituisce `ReturnAction::Continue`. Un'eccezione significa che l'operazione richiesta non può completarsi normalmente; le eccezioni non vengono convertite in avvisi e non possono essere gestite da una politica di avviso.

Restituire `ReturnAction::Abort` chiede al dispatcher degli avvisi di terminare l'operazione corrente sollevando un'eccezione. L'eccezione pubblica dipende dall'operazione e dal formato della presentazione. Per esempio, il caricamento può generare una [PptxReadException](https://reference.aspose.com/slides/it/cpp/aspose.slides/pptxreadexception/) o una [PptReadException](https://reference.aspose.com/slides/it/cpp/aspose.slides/pptreadexception/), mentre il salvataggio o l'esportazione può generare una [PptxException](https://reference.aspose.com/slides/it/cpp/aspose.slides/pptxexception/). Gestire l'eccezione al confine dell'operazione e usare il report degli avvisi per determinare se la politica dell'applicazione ha causato la terminazione invece di fare affidamento su un sottotipo di eccezione o su un messaggio. Il callback registra l'avviso prima di restituire `ReturnAction::Abort`, garantendo che il motivo rimanga disponibile per l'applicazione.

## **Categorie di Avviso**

L'enumerazione [WarningType](https://reference.aspose.com/slides/it/cpp/aspose.slides.warnings/warningtype/) fornisce le seguenti categorie:

| Tipo di avviso | Significato | Politica tipica |
| --- | --- | --- |
| `SourceFileCorruption` | La presentazione di origine contiene corruzione che può rendere inutilizzabile un documento salvato nel suo formato originale. | Interrompi. |
| `DataLoss` | Testo, grafici, immagini o altri dati potrebbero mancare dopo il caricamento o il salvataggio. | Interrompi. |
| `MajorFormattingLoss` | La presentazione potrebbe perdere formattazioni importanti. | Interrompi in modalità di convalida rigorosa; altrimenti registra e continua. |
| `MinorFormattingLoss` | Potrebbe verificarsi una differenza di formattazione limitata. | Registra per la diagnostica e continua. |
| `CompatibilityIssue` | Il risultato potrebbe non aprirsi o comportarsi correttamente in alcune applicazioni o versioni più vecchie. | Registra e continua a meno che la compatibilità non sia obbligatoria. |
| `UnexpectedContent` | L'origine contiene contenuti non supportati o non riconosciuti il cui effetto potrebbe non essere ancora noto. | Registra e continua, o tratta come errore in una politica rigorosa. |

La categoria dovrebbe guidare la decisione della politica. Conservare la descrizione dell'avviso per la diagnostica, ma non fare affidamento sulla formulazione per la logica dell'applicazione poiché il testo del messaggio può variare tra scenari di avviso e versioni del prodotto.

## **Raccogliere e Classificare gli Avvisi**

L'esempio seguente utilizza un report a livello di applicazione per l'intera pipeline di elaborazione. Un'istanza di callback separata etichetta gli avvisi provenienti da caricamento, rendering, conversione PDF e salvataggio PPTX. La politica interrompe in caso di corruzione della sorgente o perdita di dati, opzionalmente interrompe in caso di perdita di formattazione maggiore e continua per gli altri avvisi.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

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
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

Impostare `abortOnMajorFormattingLoss` su `false` quando le differenze di formattazione maggiori sono accettabili. I problemi di compatibilità, la perdita di formattazione minore e i contenuti inaspettati rimangono comunque nel report anche quando l'operazione continua. Estendere `WarningPolicy::GetAction` se l'applicazione deve rifiutare una di queste categorie.

## **Scenari comuni di avviso**

Gli avvisi possono apparire in diverse fasi di un flusso di lavoro:

- **Firme digitali:** Una presentazione firmata può generare un avviso durante il caricamento indicando che la firma verrà persa durante l'elaborazione. Aspose.Slides segnala questa condizione `DataLoss` tramite [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). Un callback nella fase di caricamento consente all'applicazione di rifiutare il file o accettare esplicitamente la perdita segnalata.
- **Sostituzione dei caratteri:** Un carattere non disponibile può essere sostituito mentre una diapositiva viene renderizzata o esportata. Gli avvisi di sostituzione dei caratteri sono segnalati come `DataLoss`, quindi la politica rigorosa sopra interrompe anche se l'applicazione considererebbe una determinata sostituzione accettabile visivamente. Per osservare questo comportamento, utilizzare una presentazione di input contenente testo in un carattere non disponibile al runtime. La descrizione dell'avviso identifica la sostituzione; configurare i caratteri richiesti o le [regole di sostituzione dei caratteri](/slides/it/cpp/font-substitution/) prima di riprovare.
- **Contenuto non supportato o inatteso:** Un loader può incontrare record o funzionalità della presentazione che non riconosce. Tali avvisi possono usare `UnexpectedContent`, o una categoria più severa quando si sa che dati o formattazione sono interessati.
- **Compatibilità del formato:** Il salvataggio in un altro formato di presentazione può omettere funzionalità o produrre un risultato che si comporta diversamente in alcune applicazioni. Per esempio, salvare una presentazione con più di otto guide di disegno orizzontali o verticali in un PPT legacy segnala un `CompatibilityIssue`. Il callback nella fase di salvataggio può registrare la perdita e continuare, o rifiutarla se è necessario preservare tutte le guide.
- **Comportamento di caricamento:** Opzioni di caricamento e comportamenti legacy possono generare avvisi. Per esempio, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identifica l'uso di un comportamento di blocco della presentazione obsoleto come `CompatibilityIssue`.

Gli avvisi dipendono dal documento sorgente, dal formato di destinazione, dall'operazione e dalla versione di Aspose.Slides. Non presumere che ogni file generi un avviso o che uno scenario si mappi sempre a una sola categoria.

## **Gestire in modo sicuro le operazioni interrotte**

Quando un callback restituisce `ReturnAction::Abort`, non utilizzare un oggetto che non è stato caricato correttamente e non presumere che un output di rendering o salvataggio sia completo. L'operazione può terminare dopo aver creato un file di output ma prima di completarlo.

Salvare i risultati convalidati in un percorso separato, ad esempio `validated-output.pptx`. Sostituire una presentazione esistente solo dopo che l'operazione è terminata con successo, il report degli avvisi soddisfa la politica dell'applicazione e l'output può essere aperto e verificato. Questo evita di sovrascrivere un file sorgente valido con un risultato parziale o rifiutato.

Un report di avvisi vuoto non garantisce che ogni caratteristica della sorgente sia stata preservata. Applicare tutti i controlli di contenuto e visivi aggiuntivi richiesti dall'applicazione. Vedere anche [Apri presentazioni](/slides/it/cpp/open-presentation/) e [Salva presentazioni](/slides/it/cpp/save-presentation/).

## **FAQ**

**Un callback di avviso può gestire ogni errore di Aspose.Slides?**

No. Gestisce solo le condizioni recuperabili segnalate come avvisi. Le eccezioni che si verificano indipendentemente dal callback devono essere gestite dall'applicazione attorno alla chiamata di caricamento, rendering, conversione o salvataggio.

**Restituire `ReturnAction::Continue` garantisce un output identico?**

No. Consente solo di proseguire l'elaborazione. La condizione segnalata può comunque causare differenze di dati, formattazione o compatibilità, quindi è necessario esaminare i tipi e le descrizioni degli avvisi raccolti.

**Come può un'applicazione identificare l'operazione che ha prodotto un avviso?**

Creare un'istanza di callback per ciascuna operazione e memorizzare una fase definita dall'applicazione insieme al tipo di avviso e alla descrizione, come mostrato nell'esempio.