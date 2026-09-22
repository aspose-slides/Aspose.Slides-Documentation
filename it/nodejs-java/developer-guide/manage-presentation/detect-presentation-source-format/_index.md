---
title: Determinare il formato originale della presentazione in Node.js
linktitle: Formato sorgente
type: docs
weight: 35
url: /it/nodejs-java/detect-presentation-source-format/
keywords:
- formato sorgente
- rilevare formato presentazione
- PowerPoint
- OpenDocument
- presentazione
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Leggi il formato originale di una presentazione caricata in Node.js con Aspose.Slides per Node.js via Java, confronta le API di rilevamento e gestisci file, stream e formati legacy."
---
## **Panoramica**

Dopo aver caricato una presentazione, chiama il metodo [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSourceFormat) per determinare il suo formato originale. Usalo quando l’elaborazione successiva dipende dal formato da cui è stata caricata l’istanza corrente.

Il formato sorgente è distinto dal [SaveFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/) selezionato per un file di output. Salvare in un altro formato non modifica il formato sorgente dell’istanza esistente.

## **Leggere il formato sorgente di un file**

Questo esempio richiede un file `sample.pptx` esistente. Carica il file e seleziona una politica di elaborazione dell’applicazione usando [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSourceFormat), anziché il nome del file. Cambia il percorso di input per provare altri formati. L’esempio stampa la politica selezionata; sostituisci i messaggi con la logica della tua applicazione.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Riconoscere i valori supportati**

La classe [SourceFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sourceformat/) definisce costanti intere che distinguono i seguenti formati di presentazione. Le estensioni riportate sono estensioni convenzionali, non una ricostruzione del nome file originale.

| Valore SourceFormat | Estensione | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | Presentazione PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Presentazione Office Open XML |
| `Pptm` | `.pptm` | Presentazione Office Open XML con macro |
| `Pps` | `.pps` | Presentazione slide show PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Slide show Office Open XML |
| `Ppsm` | `.ppsm` | Slide show Office Open XML con macro |
| `Pot` | `.pot` | Modello PowerPoint 97–2003 |
| `Potx` | `.potx` | Modello Office Open XML |
| `Potm` | `.potm` | Modello Office Open XML con macro |
| `Odp` | `.odp` | Presentazione OpenDocument |
| `Otp` | `.otp` | Modello di presentazione OpenDocument |
| `Fodp` | `.fodp` | Presentazione OpenDocument XML piatta |
| `Xml` | `.xml` | Presentazione PowerPoint XML |

## **Leggere il formato sorgente da uno stream**

Questo esempio richiede un file `sample.pps` esistente. Leggere i suoi byte in uno stream di memoria simula un input ricevuto senza nome file, ad esempio un valore di database o un array di byte caricato. Il costruttore [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) riceve solo lo stream.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS e POT usano lo stesso formato binario di base. Quando si carica tramite percorso file, l’estensione può aiutare a distinguere uno slide show da un modello. Senza nome file, il contenuto legacy PPS e POT può essere segnalato come `SourceFormat.Ppt`; l’esempio PPS sopra stampa il valore intero di `SourceFormat.Ppt`.

Se la tua applicazione deve preservare la distinzione, conserva separatamente il nome file originale o i metadati di sottotipo. Un’estensione è un suggerimento utile per questi sottotipi legacy, ma non dovrebbe essere l’unico criterio per identificare contenuti di presentazione arbitrari.

## **Confrontare il rilevamento prima e dopo il caricamento**

Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) e [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) quando devi ispezionare un file prima di caricare il suo modello oggetto completo. Usa [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSourceFormat) quando l’istanza esiste già.

Questo esempio richiede `sample.pptx` e stampa i valori interi di `LoadFormat.Pptx` e `SourceFormat.Pptx`, rispettivamente. In produzione, scegli l’API appropriata al tuo stadio di elaborazione; una presentazione già caricata non richiede una seconda ispezione solo per ottenere il suo formato sorgente.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

I risultati utilizzano costanti di classi diverse: [LoadFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadformat/) e [SourceFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sourceformat/). Non confrontare i loro valori numerici né presumere che ogni formato abbia risultati di rilevamento identici. PowerPoint XML può essere segnalato come `LoadFormat.Unknown` prima del caricamento e come `SourceFormat.Xml` dopo il caricamento.

## **Mantenere separati formati sorgente e di output**

Questo esempio richiede `sample.pptx` e scrive `converted.odp`. Stampa il valore intero di `SourceFormat.Pptx` sia prima sia dopo il salvataggio dell’istanza originale. Solo la nuova istanza caricata dall’output ODP riporta `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Una presentazione creata da zero con `new Presentation()` riporta `SourceFormat.Pptx`. Non ha un file di input: questo è il valore predefinito per un’istanza appena creata, non una prova che sia stato caricato un file PPTX. Tieni traccia separatamente se la tua applicazione ha creato o caricato l’istanza, se tale distinzione è importante.

## **Mappare un formato sorgente a un’estensione**

L’esempio seguente richiede `sample.pptx`. Mappa ogni valore attualmente supportato di [SourceFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sourceformat/) a un’estensione convenzionale, senza analizzare il nome file di input. Il fallback evita di assegnare silenziosamente un’estensione a un valore non riconosciuto.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Questa mappatura non converte un file né recupera un sottotipo legacy PPS/POT perso durante il caricamento da stream. Per il salvataggio effettivo, seleziona esplicitamente un [SaveFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/) o usa la conversione mostrata in [Save Presentations in Their Original Format](/slides/it/nodejs-java/save-presentation/#save-presentations-in-their-original-format).

## **Verificare i formati salvando e riaprendo**

Questo esempio autonomo crea una presentazione e scrive tre file nella directory di lavoro, sovrascrivendo file con gli stessi nomi. Riapre ogni output sia per percorso sia tramite uno stream di memoria. Per PPTX e ODP, entrambi i percorsi segnalano il formato salvato. Per PPS, il caricamento per percorso segnala `Pps`, mentre il caricamento degli stessi byte senza nome file segnala `Ppt`.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

La tabella seguente riepiloga l’identificazione del formato sorgente per presentazioni con estensioni corrispondenti. I nomi indicano costanti; gli esempi JavaScript stampano i loro valori interi:

| Formato salvato | SourceFormat da un percorso file | SourceFormat da uno stream senza nome |
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

Il contenuto PPS/POT è identificato come `Ppt` per stream senza nome. La tabella descrive l’identificazione del formato, non la conservazione di tutte le funzionalità della presentazione durante la conversione.

## **FAQ**

**Il salvataggio in ODP modifica il formato sorgente di una presentazione caricata da PPTX?**

No. L’istanza esistente continua a segnalare `Pptx`. Un’istanza caricata dal file ODP salvato segnala `Odp`.

**Uno stream può sempre distinguere una presentazione legacy, uno slide show e un modello?**

No. PPT, PPS e POT condividono lo stesso formato binario. Conserva separatamente il nome file o i metadati di sottotipo quando è necessaria tale distinzione.

**Quale API devo usare se la presentazione è già caricata?**

Leggi [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSourceFormat). Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) per l’ispezione prima del caricamento.