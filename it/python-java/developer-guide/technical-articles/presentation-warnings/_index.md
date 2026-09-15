---
title: Gestire gli avvisi della presentazione in Python tramite Java
type: docs
weight: 90
url: /it/python-java/presentation-warnings/
aliases:
- /python-java/ottenere-callback-di-avviso-per-sostituzione-font-in-aspose-slides/
keywords:
- callback di avviso
- politica di avviso
- perdita di dati
- corruzione della sorgente
- problema di compatibilità
- sostituzione dei font
- firma digitale
- caricamento della presentazione
- rendering della presentazione
- conversione della presentazione
- salvataggio della presentazione
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Scopri come raccogliere, classificare e gestire gli avvisi durante il caricamento, il rendering, la conversione e il salvataggio delle presentazioni con Aspose.Slides per Python tramite Java."
---
## **Panoramica**

Aspose.Slides può segnalare problemi recuperabili durante il caricamento, il rendering, la conversione o il salvataggio di una presentazione. Esempi includono record di origine danneggiati, contenuti che non possono essere preservati, sostituzione dei font e limitazioni di un formato di destinazione. Un callback di avviso consente a un’applicazione di registrare queste condizioni e decidere se l’operazione corrente può continuare.

Implementa l’interfaccia `IWarningCallback` tramite `jpype.JProxy` ed esamina i valori `getWarningType` e `getDescription` forniti da `IWarningInfo`. Restituisci [ReturnAction.Continue](https://reference.aspose.com/slides/it/python-java/aspose.slides/returnaction/#Continue) per accettare l’avviso o [ReturnAction.Abort](https://reference.aspose.com/slides/it/python-java/aspose.slides/returnaction/#Abort) per interrompere l’operazione.

Usa [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setWarningCallback) per gli avvisi generati durante l’apertura di una presentazione. Le classi delle opzioni di rendering ed esportazione ereditano [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveoptions/#setWarningCallback), che riceve avvisi dal rendering delle diapositive, dalla conversione e dal salvataggio. Poiché l’avviso stesso non identifica l’operazione dell’applicazione, associa ogni istanza di callback a una fase operativa quando costruisci un rapporto combinato.

## **Avvisi ed Eccezioni**

Un avviso descrive una condizione da cui Aspose.Slides può recuperare se il callback restituisce `ReturnAction.Continue`. Un’eccezione indica che l’operazione richiesta non può completarsi normalmente; le eccezioni non vengono convertite in avvisi e non possono essere gestite da una politica di avviso.

Restituire `ReturnAction.Abort` chiede al dispatcher degli avvisi di terminare l’operazione corrente sollevando un’eccezione. L’eccezione pubblica dipende dall’operazione e dal formato della presentazione. Ad esempio, il caricamento può generare una [PptxReadException](https://reference.aspose.com/slides/it/python-java/aspose.slides/pptxreadexception/) o una [PptReadException](https://reference.aspose.com/slides/it/python-java/aspose.slides/pptreadexception/), mentre il salvataggio o l’esportazione può generare una [PptxException](https://reference.aspose.com/slides/it/python-java/aspose.slides/pptxexception/). Gestisci l’eccezione al confine dell’operazione e utilizza il rapporto degli avvisi per determinare se la politica dell’applicazione ha causato l’interruzione, invece di fare affidamento su un singolo sottotipo di eccezione o su un messaggio. Il callback registra l’avviso prima di restituire `ReturnAction.Abort`, garantendo che il motivo rimanga disponibile per l’applicazione.

## **Categorie di Avviso**

La classe [WarningType](https://reference.aspose.com/slides/it/python-java/aspose.slides/warningtype/) fornisce costanti intere per le seguenti categorie:

| Tipo di avviso | Significato | Politica tipica |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/it/python-java/aspose.slides/warningtype/#SourceFileCorruption) | La presentazione di origine contiene corruzioni che possono rendere inutilizzabile un documento salvato nel suo formato originale. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/it/python-java/aspose.slides/warningtype/#DataLoss) | Testi, grafici, immagini o altri dati potrebbero mancare dopo il caricamento o il salvataggio. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/it/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | La presentazione potrebbe perdere una formattazione importante. | Abort in modalità di convalida stretta; altrimenti registra e continua. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/it/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | Potrebbe verificarsi una limitata differenza di formattazione. | Registra per diagnostica e continua. |
| [CompatibilityIssue](https://reference.aspose.com/slides/it/python-java/aspose.slides/warningtype/#CompatibilityIssue) | Il risultato potrebbe non aprirsi o comportarsi correttamente in alcune applicazioni o versioni precedenti. | Registra e continua a meno che la compatibilità non sia obbligatoria. |
| [UnexpectedContent](https://reference.aspose.com/slides/it/python-java/aspose.slides/warningtype/#UnexpectedContent) | L’origine contiene contenuti non supportati o non riconosciuti il cui effetto potrebbe non essere ancora noto. | Registra e continua, o tratta come errore in una politica stretta. |

La categoria dovrebbe guidare la decisione di politica. Conserva il valore restituito da `getDescription` per scopi diagnostici, ma non fare affidamento sul suo contenuto testuale per la logica dell’applicazione, poiché il testo del messaggio può variare tra scenari di avviso e versioni del prodotto.

## **Raccolta e Classificazione degli Avvisi**

L’esempio seguente utilizza un unico rapporto a livello di applicazione per l’intero flusso di elaborazione. Un’istanza di callback separata etichetta gli avvisi provenienti da caricamento, rendering, conversione PDF e salvataggio PPTX. La politica interrompe l’esecuzione in caso di corruzione del file di origine o perdita di dati, opzionalmente interrompe in caso di perdita di formattazione importante e continua per gli altri avvisi.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

Passa `False` per `abort_on_major_formatting_loss` quando costruisci `WarningPolicy` se le differenze di formattazione importanti sono accettabili. I problemi di compatibilità, la perdita di formattazione minore e i contenuti inaspettati rimangono comunque nel rapporto anche quando l’operazione continua. Estendi `WarningPolicy.get_action` se l’applicazione deve rifiutare una qualsiasi di queste categorie.

## **Scenari Comuni di Avviso**

Gli avvisi possono apparire in diverse fasi di un flusso di lavoro:

- **Firme digitali:** Una presentazione firmata può generare un avviso durante il caricamento indicando che la firma verrà persa durante l’elaborazione. Aspose.Slides segnala questa condizione `DataLoss` tramite `IPresentationSignedWarningInfo`. Un callback nella fase di caricamento consente all’applicazione di rifiutare il file o di accettare esplicitamente la perdita segnalata.
- **Sostituzione del font:** Un font non disponibile può essere sostituito mentre una diapositiva viene renderizzata o esportata. Gli avvisi di sostituzione del font sono segnalati come `DataLoss`, quindi la politica stretta sovrastata sopra interrompe anche se l’applicazione considererebbe accettabile una determinata sostituzione visiva. Per osservare questo comportamento, utilizza una presentazione di input contenente testo con un font non disponibile al runtime. La descrizione dell’avviso identifica la sostituzione; configura i font richiesti o le [font substitution rules](/slides/it/python-java/font-substitution/) prima di riprovare.
- **Contenuto non supportato o inaspettato:** Un loader può incontrare record o funzionalità della presentazione che non riconosce. Tali avvisi possono utilizzare `UnexpectedContent`, o una categoria più severa quando dati o formattazione sono noti per essere interessati.
- **Compatibilità del formato:** Il salvataggio in un formato di presentazione diverso può omettere funzionalità o produrre un risultato che si comporta diversamente in alcune applicazioni. Ad esempio, salvare una presentazione con più di otto guide di disegno orizzontali o verticali in un PPT legacy genera un `CompatibilityIssue`. Il callback nella fase di salvataggio può registrare la perdita e continuare, o rifiutarla se è necessario preservare tutte le guide.
- **Comportamento di caricamento:** Opzioni di caricamento e comportamenti legacy possono anch’essi generare avvisi. Ad esempio, `IObsoletePresLockingBehaviorWarningInfo` identifica l’uso di un comportamento di blocco della presentazione obsoleto come `CompatibilityIssue`.

Gli avvisi dipendono dal documento di origine, dal formato di destinazione, dall’operazione e dalla versione di Aspose.Slides. Non dare per scontato che ogni file generi un avviso o che uno scenario mappi sempre a una sola categoria.

## **Gestione Sicura delle Operazioni Interrotte**

Quando un callback restituisce `ReturnAction.Abort`, non utilizzare un oggetto che non è stato caricato correttamente e non presumere che un output di rendering o salvataggio sia completo. L’operazione può terminare dopo la creazione di un file di output ma prima del suo completamento.

Salva i risultati convalidati in un percorso separato, ad esempio `validated-output.pptx`. Sostituisci una presentazione esistente solo dopo che l’operazione è terminata con successo, il rapporto degli avvisi soddisfa la politica dell’applicazione e l’output può essere aperto e verificato. Ciò evita di sovrascrivere un file di origine valido con un risultato parziale o rifiutato.

Un rapporto di avviso vuoto non garantisce che ogni funzionalità di origine sia stata preservata. Applica tutti i controlli di contenuto e visivi aggiuntivi richiesti dall’applicazione. Vedi anche [Open Presentations](/slides/it/python-java/open-presentation/) e [Save Presentations](/slides/it/python-java/save-presentation/).

## **FAQ**

**Un callback di avviso può gestire tutti gli errori di Aspose.Slides?**

No. Gestisce solo le condizioni recuperabili segnalate come avvisi. Le eccezioni che si verificano indipendentemente dal callback devono essere gestite dall’applicazione attorno alla chiamata di caricamento, rendering, conversione o salvataggio.

**Restituire `ReturnAction.Continue` garantisce un output identico?**

No. Consente solo di proseguire l’elaborazione. La condizione segnalata può comunque causare differenze di dati, formattazione o compatibilità, quindi esamina i tipi e le descrizioni degli avvisi raccolti.

**Come può un’applicazione identificare l’operazione che ha prodotto un avviso?**

Crea un’istanza di callback per ogni operazione e conserva uno stato definito dall’applicazione insieme ai valori restituiti da `getWarningType` e `getDescription`, come mostrato nell’esempio.