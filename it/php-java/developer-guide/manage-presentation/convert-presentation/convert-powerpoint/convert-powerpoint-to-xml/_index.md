---
title: Converti le presentazioni PowerPoint in XML in PHP
linktitle: PowerPoint in XML
type: docs
weight: 145
url: /it/php-java/convert-powerpoint-to-xml/
keywords:
- converti PowerPoint in XML
- converti presentazione in XML
- PPT in XML
- PPTX in XML
- ODP in XML
- Presentazione PowerPoint XML
- SaveFormat.Xml
- salva presentazione come XML
- esporta presentazione in XML
- stream XML
- PHP
- Aspose.Slides
description: "Converti le presentazioni PowerPoint e OpenDocument in file XML PowerPoint o stream in PHP con Aspose.Slides per PHP via Java."
---
## **Panoramica**

Aspose.Slides per PHP via Java può convertire le presentazioni PowerPoint nel formato PowerPoint XML Presentation. L'output XML è utile quando è necessaria una rappresentazione basata su testo per ispezionare la struttura della presentazione, risolvere problemi nei documenti generati, confrontare l'output in test automatici o integrare con un flusso di lavoro che utilizza XML invece di un pacchetto di presentazione.

Utilizza il metodo [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) con il valore `Xml` dell'enumerazione [SaveFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/). È possibile scrivere il risultato direttamente su un file o su uno stream.

{{% alert color="info" title="Nota" %}}
`SaveFormat::Xml` crea una PowerPoint XML Presentation. Non estrae le parti individuali di Office Open XML contenute all'interno di un pacchetto PPTX. Se hai bisogno delle parti esatte del pacchetto PPTX, come `ppt/presentation.xml` o i file XML delle singole diapositive, ispeziona direttamente il pacchetto PPTX.
{{% /alert %}}

## **Convertire una presentazione in un file XML**

Carica una presentazione sorgente con la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/), quindi passa il percorso di output e `SaveFormat::Xml` a [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/). La sorgente può essere qualsiasi formato di presentazione supportato per il caricamento, come PPT, PPTX o ODP.

Il seguente esempio converte una presentazione PPTX in un file XML:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **Scrivere l'output XML su uno stream**

Utilizza la sovraccarico per stream di [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) quando l'XML deve rimanere in memoria o essere passato a un altro componente, come un servizio web, un provider di storage o una pipeline di elaborazione XML. Il seguente esempio scrive il risultato in un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) e ottiene l'XML generato come array di byte:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // Passa $xmlBytes al componente successivo nel flusso di lavoro.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Un `ByteArrayOutputStream` memorizza tutti i dati generati in memoria, quindi non è necessario ripristinare la posizione prima di chiamare `toByteArray`.

## **Confrontare XML con i formati di presentazione ed esportazione**

Scegli il formato di output in base a come verrà utilizzato il risultato:

| Formato | Output | Uso tipico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una PowerPoint XML Presentation | Ispezione della struttura, risoluzione dei problemi, confronto dell'output generato e integrazione basata su XML |
| PPT (`.ppt`) | Un file di presentazione binario legacy | Compatibilità con flussi di lavoro PowerPoint più vecchi |
| PPTX (`.pptx`) | Un pacchetto Office Open XML contenente più parti | Modifica regolare di PowerPoint e scambio di presentazioni |
| PDF o TIFF | Pagine a layout fisso o un'immagine multipagina | Visualizzazione, stampa e archiviazione |
| PNG, JPEG o SVG | Una rappresentazione renderizzata di una singola diapositiva | Miniature, anteprime e risorse immagine |
| HTML o HTML5 | Output di presentazione orientato al web | Visualizzazione in browser e pubblicazione web |

A differenza di PPT e PPTX, l'output XML è principalmente destinato a flussi di lavoro di ispezione e orientati ai dati. A differenza di PDF, TIFF, HTML e dei formati immagine delle diapositive, rappresenta i dati della presentazione anziché renderizzare le diapositive come pagine o risorse visive. La tabella dei [formati di file supportati](/slides/it/php-java/supported-file-formats/) elenca PowerPoint XML Presentation come formato solo per il salvataggio, quindi non usarlo quando un flusso di lavoro deve caricare nuovamente il file esportato in Aspose.Slides per continuare l'editing.

## **FAQ**

**Il `SaveFormat::Xml` è lo stesso di salvare un file PPTX?**

No. PPTX è un pacchetto che contiene più parti Office Open XML, mentre `SaveFormat::Xml` crea un file PowerPoint XML Presentation.

**Posso salvare l'output XML senza creare un file su disco?**

Sì. Passa uno stream scrivibile a [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/). Ad esempio, utilizza un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) per l'elaborazione in memoria.

**Aspose.Slides può caricare nuovamente il file XML esportato?**

No. PowerPoint XML Presentation è attualmente supportato solo per il salvataggio, non per il caricamento. Utilizza PPTX o un altro formato di presentazione supportato quando è necessario un editing bidirezionale.

**La conversione XML rende ogni diapositiva come una pagina o un'immagine?**

No. La conversione XML scrive dati strutturati della presentazione. Usa PDF o TIFF per un output orientato alle pagine, oppure PNG, JPEG e SVG per immagini di singole diapositive.