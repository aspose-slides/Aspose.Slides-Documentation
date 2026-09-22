---
title: Determinare il formato originale della presentazione su Android
linktitle: Formato di origine
type: docs
weight: 35
url: /it/androidjava/detect-presentation-source-format/
keywords:
- formato di origine
- rileva formato della presentazione
- PowerPoint
- OpenDocument
- presentazione
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Leggi il formato originale di una presentazione caricata su Android con Aspose.Slides per Android via Java, confronta le API di rilevamento e gestisci file, stream e formati legacy."
---
## **Panoramica**

Dopo aver caricato una presentazione, chiama il metodo [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSourceFormat--) per determinare il suo formato originale. Il metodo è disponibile anche tramite [IPresentation.getSourceFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). Usalo quando l'elaborazione successiva dipende dal formato da cui è stata caricata l'istanza corrente.

Il formato di origine è distinto dal [SaveFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveformat/) selezionato per un file di output. Salvare in un altro formato non modifica il formato di origine dell'istanza esistente.

Gli esempi utilizzano Java e percorsi di file. Su Android, sostituisci i percorsi di esempio con percorsi nella memoria accessibile dall'app, come la directory dei file interni dell'app.

## **Leggi il Formato di Origine di un File**

Questo esempio richiede un file `sample.pptx` esistente. Carica il file e seleziona una politica di elaborazione dell'applicazione usando [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSourceFormat--), anziché il nome file. Modifica il percorso di input per provare altri formati. L'esempio stampa la politica selezionata; sostituisci i messaggi con la logica della tua applicazione.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Riconosci i Valori Supportati**

La classe [SourceFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/sourceformat/) definisce costanti intere che distinguono i seguenti formati di presentazione. Le estensioni riportate sono convenzionali, non una ricostruzione del nome file originale.

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
| `Fodp` | `.fodp` | Presentazione OpenDocument Flat XML |
| `Xml` | `.xml` | Presentazione PowerPoint XML |

## **Leggi il Formato di Origine da uno Stream**

Questo esempio richiede un file `sample.pps` esistente. Leggere i suoi byte in uno stream di memoria simula un input ricevuto senza nome file, ad esempio un valore di database o un array di byte caricato. Il costruttore [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) riceve solo lo stream.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS e POT usano lo stesso formato binario di base. Quando si carica tramite percorso, l'estensione può aiutare a distinguere una presentazione a schermo intero o un modello. Senza nome file, il contenuto legacy PPS e POT può essere segnalato come `SourceFormat.Ppt`; l'esempio PPS sopra stampa il valore intero di `SourceFormat.Ppt`.

Se la tua applicazione deve preservare la distinzione, conserva separatamente il nome file originale o i metadati di sottotipo. Un'estensione è un indizio utile per questi sottotipi legacy, ma non dovrebbe essere l'unica base per identificare contenuti di presentazione arbitrari.

## **Confronta il Rilevamento Prima e Dopo il Caricamento**

Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) e [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) quando è necessario ispezionare un file prima di caricare il suo modello di oggetto presentazione completo. Usa [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSourceFormat--) quando l'istanza esiste già.

Questo esempio richiede `sample.pptx` e stampa i valori interi di `LoadFormat.Pptx` e `SourceFormat.Pptx`, rispettivamente. In produzione, scegli l'API appropriata allo stadio di elaborazione; una presentazione già caricata non necessita di una seconda ispezione solo per ottenere il suo formato di origine.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

I risultati usano costanti di classi diverse: [LoadFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadformat/) e [SourceFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/sourceformat/). Non confrontare i loro valori numerici né presumere che ogni formato abbia risultati di rilevamento identici. PowerPoint XML può essere segnalato come `LoadFormat.Unknown` prima del caricamento e `SourceFormat.Xml` dopo il caricamento.

## **Mantieni Separati i Formati di Origine e di Output**

Questo esempio richiede `sample.pptx` e scrive `converted.odp`. Stampa il valore intero di `SourceFormat.Pptx` sia prima che dopo il salvataggio dell'istanza originale. Solo la nuova istanza caricata dall'output ODP segnala `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Una presentazione creata da zero con `new Presentation()` segnala `SourceFormat.Pptx`. Non ha un file di input: questo è il valore predefinito per un'istanza appena creata, non una prova che sia stato caricato un file PPTX. Tieni traccia separatamente se la tua applicazione ha creato o caricato l'istanza, se tale distinzione è importante.

## **Mappa un Formato di Origine a un'Estensione**

Il seguente esempio richiede `sample.pptx`. Mappa ogni valore attualmente supportato di [SourceFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/sourceformat/) a un'estensione convenzionale, senza analizzare il nome file di input. Il fallback evita di assegnare silenziosamente un'estensione a un valore non riconosciuto.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Questa mappatura non converte un file né recupera un sottotipo legacy PPS/POT perso durante il caricamento dallo stream. Per il salvataggio effettivo, seleziona esplicitamente un [SaveFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveformat/) o usa la conversione mostrata in [Save Presentations in Their Original Format](/slides/it/androidjava/save-presentation/#save-presentations-in-their-original-format).

## **Verifica i Formati Salvando e Riaprendo**

Questo esempio autonomo crea una presentazione e scrive tre file nella directory di lavoro, sovrascrivendo i file con gli stessi nomi. Riapre ogni output sia tramite percorso sia attraverso uno stream di memoria. Per PPTX e ODP, entrambi i percorsi segnalano il formato salvato. Per PPS, il caricamento via percorso segnala `Pps`, mentre il caricamento degli stessi byte senza nome file segnala `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

La tabella seguente riepiloga l'identificazione del formato di origine per presentazioni con estensioni corrispondenti. I nomi indicano costanti; gli esempi Java stampano i loro valori interi:

| Formato Salvato | SourceFormat da un percorso file | SourceFormat da uno stream senza nome |
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

Il contenuto PPS/POT è identificato come `Ppt` per stream senza nome. La tabella descrive l'identificazione del formato, non la preservazione di tutte le caratteristiche della presentazione durante la conversione.

## **FAQ**

**Salvare in ODP cambia il formato di origine di una presentazione caricata da PPTX?**

No. L'istanza esistente segnala ancora `Pptx`. Un'istanza caricata dal file ODP salvato segnala `Odp`.

**Uno stream può sempre distinguere una presentazione legacy, uno schermo intero e un modello?**

No. PPT, PPS e POT condividono il formato binario. Conserva separatamente il nome file o i metadati di sottotipo quando è necessaria tale distinzione.

**Quale API devo usare se la presentazione è già caricata?**

Leggi [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSourceFormat--). Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) per l'ispezione prima del caricamento.