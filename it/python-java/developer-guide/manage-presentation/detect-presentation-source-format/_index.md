---
title: Determinare il formato originale della presentazione in Python via Java
linktitle: Formato sorgente
type: docs
weight: 35
url: /it/python-java/detect-presentation-source-format/
keywords:
- formato sorgente
- rilevare il formato della presentazione
- PowerPoint
- OpenDocument
- presentazione
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Leggi il formato originale di una presentazione caricata in Python tramite Java con Aspose.Slides per Python tramite Java, confronta le API di rilevamento e gestisci file, stream e formati legacy."
---
## **Panoramica**

Dopo aver caricato una presentazione, chiama il metodo [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSourceFormat) per determinare il suo formato originale. Usalo quando l'elaborazione successiva dipende dal formato con cui è stata caricata l'istanza corrente.

Il formato sorgente è distinto dal [SaveFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/) selezionato per un file di output. Salvarlo in un altro formato non modifica il formato sorgente dell'istanza esistente.

Gli esempi richiedono Aspose.Slides per Python via Java e un runtime Java compatibile. Ogni esempio avvia la JVM se non è già in esecuzione.

## **Leggi il Formato Sorgente di un File**

Questo esempio richiede un file `sample.pptx` esistente. Carica il file e seleziona una politica di elaborazione dell'applicazione usando [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSourceFormat), anziché il nome file. Modifica il percorso di input per provare altri formati. L'esempio stampa la politica selezionata; sostituisci i messaggi con la logica della tua applicazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Riconosci i Valori Supportati**

La classe [SourceFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/sourceformat/) definisce costanti intere che distinguono i seguenti formati di presentazione. Le estensioni riportate di seguito sono estensioni convenzionali, non una ricostruzione del nome file originale.

| Valore SourceFormat | Estensione | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | Presentazione PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Presentazione Office Open XML |
| `Pptm` | `.pptm` | Presentazione Office Open XML con macro |
| `Pps` | `.pps` | Presentazione PowerPoint 97–2003 a schermo intero |
| `Ppsx` | `.ppsx` | Presentazione Office Open XML a schermo intero |
| `Ppsm` | `.ppsm` | Presentazione Office Open XML a schermo intero con macro |
| `Pot` | `.pot` | Modello PowerPoint 97–2003 |
| `Potx` | `.potx` | Modello Office Open XML |
| `Potm` | `.potm` | Modello Office Open XML con macro |
| `Odp` | `.odp` | Presentazione OpenDocument |
| `Otp` | `.otp` | Modello di presentazione OpenDocument |
| `Fodp` | `.fodp` | Presentazione OpenDocument XML piatta |
| `Xml` | `.xml` | Presentazione PowerPoint XML |

## **Leggi il Formato Sorgente di uno Stream**

Questo esempio richiede un file `sample.pps` esistente. Leggere i suoi byte in uno stream di memoria modella un input ricevuto senza nome file, ad esempio un valore di database o un array di byte caricato. Il costruttore [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) riceve solo lo stream. Python legge i byte del file e JPype li converte in un array di byte Java per lo stream di memoria Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS e POT utilizzano lo stesso formato binario di base. Quando si carica tramite percorso file, l'estensione può aiutare a distinguere una presentazione a schermo intero o un modello. Senza nome file, il contenuto legacy PPS e POT può essere segnalato come `SourceFormat.Ppt`; l'esempio PPS sopra stampa il valore intero di `SourceFormat.Ppt`.

Se la tua applicazione deve preservare questa distinzione, conserva separatamente il nome file originale o i metadati di sottotipo. Un'estensione è un suggerimento utile per questi sottotipi legacy, ma non dovrebbe essere l'unico criterio per identificare contenuti di presentazione arbitrari.

## **Confronta il Rilevamento Prima e Dopo il Caricamento**

Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationfactory/#getPresentationInfo) e [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#getLoadFormat) quando devi ispezionare un file prima di caricare il suo modello oggetto di presentazione completo. Usa [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSourceFormat) quando l'istanza esiste già.

Questo esempio richiede `sample.pptx` e stampa i valori interi di `LoadFormat.Pptx` e `SourceFormat.Pptx`, rispettivamente. In produzione, scegli l'API appropriata per la fase di elaborazione; una presentazione già caricata non necessita di una seconda ispezione solo per ottenere il suo formato sorgente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

I risultati usano costanti di classi diverse: [LoadFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadformat/) e [SourceFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/sourceformat/). Non confrontare i loro valori numerici né presumere che ogni formato abbia risultati di rilevamento identici. PowerPoint XML può essere segnalato come `LoadFormat.Unknown` prima del caricamento e come `SourceFormat.Xml` dopo il caricamento.

## **Mantieni Separati Formati Sorgente e di Output**

Questo esempio richiede `sample.pptx` e scrive `converted.odp`. Stampa il valore intero di `SourceFormat.Pptx` sia prima che dopo il salvataggio dell'istanza originale. Solo la nuova istanza caricata dall'output ODP segnala `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Una presentazione creata da zero con `Presentation()` segnala `SourceFormat.Pptx`. Non ha un file di input: questo è il valore predefinito per un'istanza appena creata, non la prova che sia stato caricato un file PPTX. Tieni traccia separatamente se la tua applicazione ha creato o caricato l'istanza, se quella distinzione è importante.

## **Mappa un Formato Sorgente a un'Estensione**

Il seguente esempio richiede `sample.pptx`. Mappa ogni valore attualmente supportato di [SourceFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/sourceformat/) a un'estensione convenzionale, senza analizzare il nome file di ingresso. Il fallback evita di assegnare silenziosamente un'estensione a un valore non riconosciuto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

Questa mappatura non converte un file né recupera un sottotipo legacy PPS/POT perduto durante il caricamento da stream. Per il salvataggio reale, seleziona esplicitamente un [SaveFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/) oppure usa la conversione mostrata in [Save Presentations in Their Original Format](/slides/it/python-java/save-presentation/#save-presentations-in-their-original-format).

## **Verifica i Formati Salvando e Riaprendo**

Questo esempio autonomo crea una presentazione e scrive tre file nella directory di lavoro, sovrascrivendo i file con gli stessi nomi. Riapre ogni output sia tramite percorso sia tramite uno stream di memoria. Per PPTX e ODP, entrambe le rotte segnalano il formato salvato. Per PPS, il caricamento tramite percorso segnala `Pps`, mentre il caricamento degli stessi byte senza nome file segnala `Ppt`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

La tabella seguente riassume l'identificazione del formato sorgente per presentazioni con estensioni corrispondenti. I nomi indicano costanti; gli esempi Python stampano i loro valori interi:

| Formato salvato | SourceFormat da percorso file | SourceFormat da stream senza nome |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` rispettivamente | Stesso del percorso file |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` rispettivamente | Stesso del percorso file |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` rispettivamente | Stesso del percorso file |
| ODP, OTP | `Odp`, `Otp` rispettivamente | Stesso del percorso file |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Il contenuto PPS/POT è identificato come `Ppt` per stream senza nome. La tabella descrive l'identificazione del formato, non la conservazione di tutte le caratteristiche della presentazione durante la conversione.

## **FAQ**

**Il salvataggio in ODP modifica il formato sorgente di una presentazione caricata da PPTX?**

No. L'istanza esistente continua a segnalare `Pptx`. Un'istanza caricata dal file ODP salvato segnala `Odp`.

**Uno stream può sempre distinguere una presentazione legacy, una presentazione a schermo intero e un modello?**

No. PPT, PPS e POT condividono lo stesso formato binario. Conserva separatamente il nome file o i metadati di sottotipo quando è necessaria quella distinzione.

**Quale API devo usare se la presentazione è già caricata?**

Leggi [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSourceFormat). Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationfactory/#getPresentationInfo) per l'ispezione prima del caricamento.