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
description: "Converti i file PPT legacy in PPTX in PHP con Aspose.Slides. Include esempi PHP per la conversione di un singolo file e batch, gestione degli errori e note sulla fedeltà."
---
## **Panoramica**

PPT è il formato binario legacy di PowerPoint, mentre PPTX è il formato Open XML più recente. Aspose.Slides per PHP tramite Java può caricare un file PPT e salvarlo come PPTX senza Microsoft PowerPoint. Questo articolo mostra come convertire un file o una directory di file e spiega cosa verificare dopo la conversione.

## **Convertire un file PPT in PPTX**

Carica il file di origine con la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/), quindi chiama [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) con [SaveFormat::Pptx](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/#Pptx). Il blocco `finally` rilascia la presentazione e libera le sue risorse.

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

L'estensione del file non seleziona il formato di output da sola; lo fa l'argomento [SaveFormat::Pptx](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/#Pptx). Mantieni percorsi di input e output diversi se devi conservare il file PPT originale.

## **Convertire più file PPT**

L'esempio seguente converte ogni file `.ppt` in una directory. Ogni file viene elaborato in modo indipendente, quindi una conversione non riuscita non interrompe il resto del batch.

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

Per carichi di lavoro in produzione, registra l'eccezione completa, decidi se un file di output esistente possa essere sovrascritto e scrivi i nomi dei file non riusciti in una coda di ripetizione o revisione. File corrotti, file protetti da password aperti senza la password richiesta, percorsi inaccessibili e contenuti non supportati possono tutti provocare il fallimento di una conversione. Vedi [Password-Protected Presentations](/slides/it/php-java/password-protected-presentation/) per caricare file crittografati.

## **Fedeltà e funzionalità legacy**

La conversione normalmente preserva diapositive, master, layout, testo, forme, immagini, tabelle e grafici. Tuttavia, PPT e PPTX non rappresentano ogni funzionalità esattamente allo stesso modo. Una funzionalità legacy che non ha un equivalente PPTX, o non è supportata dalla libreria, può essere normalizzata, omessa o visualizzata diversamente.

Verifica il file convertito quando contiene animazioni, transizioni, oggetti OLE incorporati o collegati, controlli ActiveX, media incorporati, font non comuni o macro VBA. Un file PPTX semplice non è un formato abilitato alle macro, quindi utilizza un flusso di lavoro appropriato per le macro quando VBA deve rimanere disponibile. Verifica inoltre che i font richiesti e le risorse esterne siano presenti nell'ambiente in cui la presentazione convertita verrà aperta o renderizzata.

Per i documenti importanti, riapri il PPTX generato programmaticamente e controlla il numero di diapositive chiave e il contenuto, quindi confronta il suo aspetto e il comportamento della presentazione nella visualizzazione prevista. Non considerare una chiamata riuscita a [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) come prova che ogni funzionalità legacy abbia una rappresentazione PPTX esatta.

## **Quando utilizzare PPTX**

Usa PPTX quando la presentazione verrà modificata nelle versioni attuali di PowerPoint, scambiata con sistemi che lavorano con pacchetti Open XML, o archiviata in un formato più facile da ispezionare e recuperare rispetto al binario legacy PPT. Conserva il PPT originale come copia di archivio o di rollback finché la presentazione convertita non supera i tuoi controlli di fedeltà.

Se hai bisogno invece di PDF, HTML, immagini, XPS o di un altro tipo di output, utilizza le indicazioni specifiche per il formato in [Convert Presentations to Multiple Formats](/slides/it/php-java/convert-presentation/) anziché presumere che tutti i target mantengano le funzionalità modificabili di PowerPoint.

## **Convertitore online**

Per un file occasionale o un confronto rapido, puoi utilizzare il [online PPT to PPTX converter](https://products.aspose.app/slides/it/conversion/ppt-to-pptx). Per conversioni ripetibili, elaborazione batch o gestione degli errori a livello di applicazione, utilizza l'API PHP.

## **Articoli correlati**

- [PPT vs PPTX](/slides/it/php-java/ppt-vs-pptx/)
- [Salvare presentazioni in PHP](/slides/it/php-java/save-presentation/)
- [Formati file supportati](/slides/it/php-java/supported-file-formats/)
- [Aprire presentazioni in PHP](/slides/it/php-java/open-presentation/)

## **FAQ**

**Posso convertire PPT in PPTX senza Microsoft PowerPoint installato?**

Sì. Aspose.Slides per PHP tramite Java carica e salva i file di presentazione senza richiedere Microsoft PowerPoint.

**La conversione da PPT a PPTX preserva tutto il contenuto esattamente?**

Preserva il contenuto comune delle presentazioni, ma la fedeltà esatta non è garantita per ogni funzionalità legacy o non supportata. Rivedi il file generato quando contiene macro, oggetti OLE o ActiveX, media, animazioni specializzate o font non comuni.

**Posso convertire un file PPT protetto da password?**

Sì, se fornisci la password corretta durante il caricamento del file. Una password mancante o errata provoca il fallimento dell'operazione di caricamento.

**Devo eliminare il file PPT dopo la conversione?**

Conserva l'originale finché non avrai verificato il PPTX nei visualizzatori e nei flussi di lavoro che ti interessano. Questo fornisce una copia di rollback se una funzionalità legacy viene convertita in modo diverso.