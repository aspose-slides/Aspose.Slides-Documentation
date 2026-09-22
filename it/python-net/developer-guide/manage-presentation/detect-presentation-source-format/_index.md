---
title: Determinare il formato originale della presentazione in Python
linktitle: Formato di origine
type: docs
weight: 35
url: /it/python-net/detect-presentation-source-format/
keywords:
- formato di origine
- rilevare formato presentazione
- PowerPoint
- OpenDocument
- presentazione
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Leggi il formato originale di una presentazione caricata in Python con Aspose.Slides per Python via .NET, confronta le API di rilevamento e gestisci file, stream e formati legacy."
---
## **Panoramica**

Dopo aver caricato una presentazione, leggi la proprietà di sola lettura [Presentation.source_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/source_format/) per determinare il suo formato originale. Usala quando l'elaborazione successiva dipende dal formato da cui è stata caricata l'istanza corrente.

Il formato di origine è distinto dal [SaveFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/) selezionato per un file di output. Salvare in un altro formato non modifica il formato di origine dell'istanza esistente.

## **Leggi il formato di origine di un file**

Questo esempio richiede un file `sample.pptx` esistente. Carica il file e seleziona una politica di elaborazione dell'applicazione utilizzando [Presentation.source_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/source_format/), piuttosto che il nome file. Modifica il percorso di input per provare altri formati. L'esempio stampa la politica selezionata; sostituisci i messaggi con la logica della tua applicazione.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Riconosci i valori supportati**

L'enumerazione [SourceFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/sourceformat/) distingue i seguenti formati di presentazione. Le estensioni qui sotto sono estensioni convenzionali, non una ricostruzione del nome file originale.

| Valore SourceFormat | Estensione | Formato |
| --- | --- | --- |
| `PPT` | `.ppt` | Presentazione PowerPoint 97–2003 |
| `PPTX` | `.pptx` | Presentazione Office Open XML |
| `PPTM` | `.pptm` | Presentazione Office Open XML con macro |
| `PPS` | `.pps` | Presentazione diapositive PowerPoint 97–2003 |
| `PPSX` | `.ppsx` | Presentazione diapositive Office Open XML |
| `PPSM` | `.ppsm` | Presentazione diapositive Office Open XML con macro |
| `POT` | `.pot` | Modello PowerPoint 97–2003 |
| `POTX` | `.potx` | Modello Office Open XML |
| `POTM` | `.potm` | Modello Office Open XML con macro |
| `ODP` | `.odp` | Presentazione OpenDocument |
| `OTP` | `.otp` | Modello di presentazione OpenDocument |
| `FODP` | `.fodp` | Presentazione ODF Flat XML |
| `XML` | `.xml` | Presentazione PowerPoint XML |

## **Leggi il formato di origine di uno stream**

Questo esempio richiede un file `sample.pps` esistente. Leggere i suoi byte in un flusso di memoria simula un ingresso ricevuto senza nome file, ad esempio un valore di database o un array di byte caricato. Il costruttore [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) accetta solo il flusso.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS e POT utilizzano lo stesso formato binario sottostante. Quando si carica tramite percorso file, l'estensione può aiutare a distinguere una presentazione diapositive o un modello. Senza un nome file, il contenuto legacy di PPS e POT può essere segnalato come `SourceFormat.PPT`; l'esempio PPS sopra segnala `PPT`.

Se la tua applicazione deve preservare la distinzione, conserva separatamente il nome file originale o i metadati del sottotipo. Un'estensione è un'indicazione utile per questi sottotipi legacy, ma non dovrebbe essere l'unico criterio per identificare contenuti di presentazione arbitrari.

## **Confronta il rilevamento prima e dopo il caricamento**

Usa [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/get_presentation_info/) e [PresentationInfo.load_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/load_format/) quando è necessario ispezionare un file prima di caricare il suo modello completo di oggetti della presentazione. Usa [Presentation.source_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/source_format/) quando l'istanza esiste già.

Questo esempio richiede `sample.pptx` e stampa `PPTX` per entrambi i controlli. In produzione, scegli l'API appropriata per la tua fase di elaborazione; una presentazione già caricata non necessita di una seconda ispezione solo per ottenere il suo formato di origine.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

I risultati hanno tipi di enumerazione diversi: [LoadFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadformat/) e [SourceFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/sourceformat/). Non confrontarli convertendo i loro valori numerici né presumere che ogni formato abbia risultati di rilevamento identici. Nel controllo di salvataggio e riapertura descritto di seguito, PowerPoint XML è stato segnalato come `LoadFormat.UNKNOWN` prima del caricamento e `SourceFormat.XML` dopo il caricamento.

## **Mantieni separati i formati di origine e di output**

Questo esempio richiede `sample.pptx` e scrive `converted.odp`. Stampa `PPTX` sia prima che dopo aver salvato l'istanza originale. Solo la nuova istanza caricata dall'output ODP segnala `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

Una presentazione creata da zero con `slides.Presentation()` segnala `SourceFormat.PPTX`. Non ha un file di input: questo è il valore predefinito per un'istanza appena creata, non una prova che sia stato caricato un file PPTX. Tieni traccia separatamente se la tua applicazione ha creato o caricato l'istanza, se tale distinzione è importante.

## **Mappa un formato di origine a un'estensione**

Il seguente esempio richiede `sample.pptx`. Mappa ogni valore attualmente supportato di [SourceFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/sourceformat/) a un'estensione convenzionale, senza analizzare il nome file di ingresso. Il fallback evita di assegnare silenziosamente un'estensione a un valore non riconosciuto.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

Questa mappatura non converte un file né ripristina un sottotipo legacy PPS/POT perso durante il caricamento dello stream. Per il salvataggio reale, seleziona esplicitamente un [SaveFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/), o usa la conversione mostrata in [Save Presentations in Their Original Format](/slides/it/python-net/save-presentation/#save-presentations-in-their-original-format).

## **Verifica i formati salvando e riaprendo**

Questo esempio autonomo crea una presentazione e scrive tre file nella directory di lavoro, sovrascrivendo i file con gli stessi nomi. Riapre ogni output sia tramite percorso sia tramite un flusso di memoria. Per PPTX e ODP, entrambi i percorsi segnalano il formato salvato. Per PPS, il caricamento via percorso segnala `PPS`, mentre il caricamento degli stessi byte senza nome file segnala `PPT`.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

Lo stesso controllo con tutti i formati elencati sopra ha prodotto questi risultati per presentazioni generate con estensioni corrispondenti:

| Formato salvato | SourceFormat da un percorso file | SourceFormat da un flusso senza nome |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` rispettivamente | Stesso del percorso file |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` rispettivamente | Stesso del percorso file |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` rispettivamente | Stesso del percorso file |
| ODP, OTP | `ODP`, `OTP` rispettivamente | Stesso del percorso file |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

In questi controlli, l'unica normalizzazione del formato di origine è stata PPS/POT a `PPT` per i flussi senza nome. La tabella descrive l'identificazione del formato, non la conservazione di tutte le funzionalità della presentazione durante la conversione.

## **FAQ**

**Il salvataggio in ODP modifica il formato di origine di una presentazione caricata da PPTX?**

No. L'istanza esistente segnala ancora `PPTX`. Un'istanza caricata dal file ODP salvato segnala `ODP`.

**Uno stream può sempre distinguere una presentazione legacy, una presentazione diapositive e un modello?**

No. PPT, PPS e POT condividono il formato binario. Conserva separatamente il nome file o i metadati del sottotipo quando è necessaria quella distinzione.

**Quale API devo usare se la presentazione è già caricata?**

Leggi [Presentation.source_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/source_format/). Usa [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/get_presentation_info/) per l'ispezione prima del caricamento.