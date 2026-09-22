---
title: Determina il formato originale della presentazione in PHP
linktitle: Formato sorgente
type: docs
weight: 35
url: /it/php-java/detect-presentation-source-format/
keywords:
- formato sorgente
- rileva formato presentazione
- PowerPoint
- OpenDocument
- presentazione
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Leggi il formato originale di una presentazione caricata in PHP con Aspose.Slides per PHP via Java, confronta le API di rilevamento e gestisci file, stream e formati legacy."
---
## **Panoramica**

Dopo aver caricato una presentazione, chiama il metodo [Presentation::getSourceFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSourceFormat) per determinare il suo formato originale. Usalo quando l'elaborazione successiva dipende dal formato da cui è stata caricata l'istanza corrente.

Il formato sorgente è distinto dal [SaveFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/) selezionato per un file di output. Salvare in un altro formato non modifica il formato sorgente dell'istanza esistente.

## **Leggi il Formato Sorgente di un File**

Questo esempio richiede un file `sample.pptx` esistente. Carica il file e seleziona una politica di elaborazione dell'applicazione usando [Presentation::getSourceFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSourceFormat), invece del nome file. Cambia il percorso di input per provare altri formati. L'esempio stampa la politica selezionata; sostituisci i messaggi con la logica della tua applicazione.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **Riconosci i Valori Supportati**

La classe [SourceFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/sourceformat/) definisce costanti intere che distinguono i seguenti formati di presentazione. Le estensioni riportate di seguito sono estensioni convenzionali, non una ricostruzione del nome file originale.

| Valore SourceFormat | Estensione | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 presentation |
| `Pptx` | `.pptx` | Office Open XML presentation |
| `Pptm` | `.pptm` | Macro-enabled Office Open XML presentation |
| `Pps` | `.pps` | PowerPoint 97–2003 slide show |
| `Ppsx` | `.ppsx` | Office Open XML slide show |
| `Ppsm` | `.ppsm` | Macro-enabled Office Open XML slide show |
| `Pot` | `.pot` | PowerPoint 97–2003 template |
| `Potx` | `.potx` | Office Open XML template |
| `Potm` | `.potm` | Macro-enabled Office Open XML template |
| `Odp` | `.odp` | OpenDocument presentation |
| `Otp` | `.otp` | OpenDocument presentation template |
| `Fodp` | `.fodp` | Flat XML ODF presentation |
| `Xml` | `.xml` | PowerPoint XML presentation |

## **Leggi il Formato Sorgente di uno Stream**

Questo esempio richiede un file `sample.pps` esistente. Leggere i suoi byte in uno stream di memoria simula un input ricevuto senza un nome file, ad esempio un valore di database o un array di byte caricato. Il costruttore [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) riceve solo lo stream.

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT, PPS e POT utilizzano lo stesso formato binario sottostante. Quando si carica tramite percorso file, l'estensione può aiutare a distinguere una presentazione o un modello. Senza un nome file, il contenuto legacy PPS e POT può essere segnalato come `SourceFormat::Ppt`; l'esempio PPS sopra stampa il valore intero di `SourceFormat::Ppt`.

Se la tua applicazione deve conservare la distinzione, mantieni separatamente il nome file originale o i metadati del sottotipo. Un'estensione è un indizio utile per questi sottotipi legacy, ma non dovrebbe essere l'unica base per identificare contenuti di presentazione arbitrari.

## **Confronta il Rilevamento Prima e Dopo il Caricamento**

Usa [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/#getPresentationInfo) e [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#getLoadFormat) quando devi ispezionare un file prima di caricare il suo modello di oggetti di presentazione completo. Usa [Presentation::getSourceFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSourceFormat) quando l'istanza esiste già.

Questo esempio richiede `sample.pptx` e stampa i valori interi di `LoadFormat::Pptx` e `SourceFormat::Pptx`, rispettivamente. In produzione, scegli l'API appropriata al tuo stadio di elaborazione; una presentazione già caricata non necessita di una seconda ispezione solo per ottenere il suo formato sorgente.

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

I risultati utilizzano costanti provenienti da classi diverse: [LoadFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadformat/) e [SourceFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/sourceformat/). Non confrontare i loro valori numerici né presumere che ogni formato abbia risultati di rilevamento identici. PowerPoint XML può essere segnalato come `LoadFormat::Unknown` prima del caricamento e `SourceFormat::Xml` dopo il caricamento.

## **Mantieni Separati Formati Sorgente e di Output**

Questo esempio richiede `sample.pptx` e scrive `converted.odp`. Stampa il valore intero di `SourceFormat::Pptx` sia prima sia dopo il salvataggio dell'istanza originale. Solo la nuova istanza caricata dall'output ODP segnala `Odp`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Una presentazione creata da zero con `new Presentation()` segnala `SourceFormat::Pptx`. Non ha alcun file di input: questo è il valore predefinito per un'istanza appena creata, non una prova che sia stato caricato un file PPTX. Tieni traccia separatamente se la tua applicazione ha creato o caricato l'istanza, se tale distinzione è importante.

## **Mappa un Formato Sorgente a un'Estensione**

Il seguente esempio richiede `sample.pptx`. Mappa ogni valore attualmente supportato di [SourceFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/sourceformat/) a un'estensione convenzionale, senza analizzare il nome file di input. Il fallback evita di assegnare silenziosamente un'estensione a un valore non riconosciuto.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Questa mappatura non converte un file né recupera un sottotipo legacy PPS/POT perso durante il caricamento da stream. Per il salvataggio effettivo, seleziona esplicitamente un [SaveFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/) oppure utilizza la conversione mostrata in [Save Presentations in Their Original Format](/slides/it/php-java/save-presentation/#save-presentations-in-their-original-format).

## **Verifica i Formati Salvando e Riaprendo**

Questo esempio autonomo crea una presentazione e scrive tre file nella directory di lavoro, sovrascrivendo i file con gli stessi nomi. Riapre ciascun output sia tramite percorso che tramite uno stream di memoria. Per PPTX e ODP, entrambi i percorsi segnalano il formato salvato. Per PPS, il caricamento per percorso segnala `Pps`, mentre il caricamento degli stessi byte senza nome file segnala `Ppt`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

La tabella seguente riepiloga l'identificazione del formato sorgente per presentazioni con estensioni corrispondenti. I nomi indicano costanti; gli esempi PHP stampano i loro valori interi:

| Formato salvato | SourceFormat da un percorso file | SourceFormat da uno stream senza nome |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT content è identificato come `Ppt` per stream senza nome. La tabella descrive l'identificazione del formato, non la conservazione di tutte le caratteristiche della presentazione durante la conversione.

## **FAQ**

**Il salvataggio in ODP modifica il formato sorgente di una presentazione caricata da PPTX?**

No. L'istanza esistente segnala ancora `Pptx`. Un'istanza caricata dal file ODP salvato segnala `Odp`.

**Uno stream può sempre distinguere una presentazione legacy, una presentazione slide show e un modello?**

No. PPT, PPS e POT condividono lo stesso formato binario. Conserva separatamente il nome file o i metadati del sottotipo quando è necessaria tale distinzione.

**Quale API devo usare se la presentazione è già caricata?**

Leggi [Presentation::getSourceFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSourceFormat). Usa [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/#getPresentationInfo) per l'ispezione prima del caricamento.