---
title: Converti PPT in PPTX in PHP
linktitle: PPT in PPTX
type: docs
weight: 20
url: /it/php-java/convert-ppt-to-pptx/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- PPT in PPTX
- salva PPT come PPTX
- esporta PPT in PPTX
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Converti file PPT legacy in PPTX in PHP con Aspose.Slides. Include esempi PHP per la conversione di un singolo file e batch, gestione degli errori e note sulla fedeltà."
---
## **Panoramica**

Il PPT è il formato binario legacy di PowerPoint, mentre il PPTX è il formato più recente Open XML. Aspose.Slides per PHP via Java può caricare un file PPT e salvarlo come PPTX senza Microsoft PowerPoint. Questo articolo mostra come convertire un file o una directory di file e spiega cosa verificare dopo la conversione.

## **Convertire un file PPT in PPTX**

Carica il file sorgente con la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/), poi chiama [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) con [SaveFormat::Pptx](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/#Pptx). Il blocco `finally` rilascia la presentazione e libera le sue risorse.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Carica la presentazione PPT legacy.
$presentation = new Presentation("presentation.ppt");
try {
    // Salva la presentazione in formato PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

L'estensione del file non seleziona il formato di output da sola; è l'argomento [SaveFormat::Pptx](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/#Pptx) a farlo. Mantieni percorsi di input e output diversi se devi conservare il file PPT originale.

## **Convertire più file PPT**

L'esempio seguente converte ogni file `.ppt` in una directory. Ogni file viene elaborato in modo indipendente, quindi una conversione fallita non interrompe il resto del batch.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

Per carichi di lavoro di produzione, registra l'eccezione completa, decidi se un file di output esistente può essere sovrascritto e scrivi i nomi dei file falliti in una coda di ripetizione o revisione. File corrotti, file protetti da password aperti senza la password richiesta, percorsi non accessibili e contenuti non supportati possono tutti provocare un fallimento della conversione. Vedi [Password-Protected Presentations](/php-java/password-protected-presentation/) per caricare file crittati.

## **Fedeltà e funzionalità legacy**

La conversione normalmente mantiene diapositive, master, layout, testo, forme, immagini, tabelle e grafici. Tuttavia, PPT e PPTX non rappresentano ogni funzionalità esattamente allo stesso modo. Una funzionalità legacy priva di equivalente PPTX, o non supportata dalla libreria, può essere normalizzata, omessa o visualizzata in modo diverso.

Controlla il file convertito quando contiene animazioni, transizioni, oggetti OLE incorporati o collegati, controlli ActiveX, media incorporati, font non comuni o macro VBA. Un file PPTX semplice non è un formato abilitato alle macro, quindi utilizza un flusso di lavoro adeguato per le macro quando VBA deve rimanere disponibile. Verifica inoltre che i font richiesti e le risorse esterne siano presenti nell'ambiente in cui la presentazione convertita sarà aperta o renderizzata.

Per documenti importanti, riapri programmaticamente il PPTX generato e ispeziona il conteggio e il contenuto delle diapositive chiave, quindi confronta il suo aspetto e il comportamento della presentazione nello spettatore previsto. Non considerare una chiamata riuscita a [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) come prova che ogni funzionalità legacy abbia una rappresentazione PPTX esatta.

## **Quando usare PPTX**

Usa PPTX quando la presentazione verrà modificata nelle versioni attuali di PowerPoint, scambiata con sistemi che lavorano con pacchetti Open XML, o archiviata in un formato più facile da ispezionare e recuperare rispetto al legacy binario PPT. Conserva il PPT originale come copia di archivio o di rollback finché la presentazione convertita non supera i tuoi controlli di fedeltà.

Se invece ti serve PDF, HTML, immagini, XPS o un altro tipo di output, utilizza le indicazioni specifiche per formato in [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) invece di presumere che tutte le destinazioni conservino le funzionalità modificabili di PowerPoint.

## **Convertitore online**

Per un file occasionale o un confronto rapido, puoi utilizzare il [online PPT to PPTX converter](https://products.aspose.app/slides/it/conversion/ppt-to-pptx). Per conversioni ripetibili, elaborazione batch o gestione degli errori a livello di applicazione, usa l'API PHP.

## **Articoli correlati**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [Salvare le presentazioni in PHP](/php-java/save-presentation/)
- [Formati di file supportati](/php-java/supported-file-formats/)
- [Aprire le presentazioni in PHP](/php-java/open-presentation/)

## **FAQ**

**Posso convertire PPT in PPTX senza Microsoft PowerPoint installato?**

Sì. Aspose.Slides per PHP via Java carica e salva i file di presentazione senza richiedere Microsoft PowerPoint.

**La conversione da PPT a PPTX preserverà tutto il contenuto esattamente?**

Preserva i contenuti comuni della presentazione, ma la fedeltà esatta non è garantita per ogni funzionalità legacy o non supportata. Revisiona il file generato quando contiene macro, oggetti OLE o ActiveX, media, animazioni specializzate o font non comuni.

**Posso convertire un file PPT protetto da password?**

Sì, se fornisci la password corretta durante il caricamento del file. Una password mancante o errata fa fallire l'operazione di caricamento.

**Devo eliminare il file PPT dopo la conversione?**

Conserva l'originale finché non hai verificato il PPTX negli spettatori e nei flussi di lavoro che ti interessano. Questo fornisce una copia di rollback se una funzionalità legacy viene convertita in modo diverso.