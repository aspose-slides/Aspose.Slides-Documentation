---
title: Recuperare e aggiornare le informazioni della presentazione in PHP
linktitle: Informazioni sulla presentazione
type: docs
weight: 30
url: /it/php-java/examine-presentation/
keywords:
- formato della presentazione
- proprietà della presentazione
- proprietà del documento
- ottenere proprietà
- leggere proprietà
- cambiare proprietà
- modificare proprietà
- aggiornare proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per PHP per ottenere approfondimenti più rapidi e audit dei contenuti più intelligenti."
---
## **Panoramica**

Aspose.Slides può identificare il formato di una presentazione e leggere i metadata del documento senza creare un modello di oggetto presentazione completo. Questo è utile quando è necessario classificare i file, creare un inventario o esaminare le proprietà prima di decidere se caricare e elaborare il contenuto della presentazione.

Questo articolo dimostra l'ispezione leggera tramite [PresentationFactory](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/) e [PresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/), nonché gli aggiornamenti mirati tramite [DocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/).

## **Verificare il formato di una presentazione**

Utilizzare [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/) per ispezionare un file senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/). Il metodo [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#getLoadFormat) restituisce il formato rilevato, ad esempio PPTX, PPT o ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Creare un inventario di presentazioni leggero**

Quando si elaborano molti file di presentazione, può essere necessario un inventario compatto per la convalida, l'indicizzazione o un sistema di gestione documentale. In questo scenario, utilizzare [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/) per ottenere un oggetto [PresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/), quindi chiamare [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#readDocumentProperties) per leggere i metadata del documento. Questo approccio non crea un'istanza di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) né richiede di attraversare l'intero modello di oggetto presentazione.

Le proprietà estese esposte da [DocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/) forniscono i seguenti valori d'inventario:

| Metodo | Valore dell'inventario |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#getSlides) | Numero totale di diapositive. |
| [getHiddenSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Numero di diapositive nascoste. |
| [getNotes](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#getNotes) | Numero di diapositive che contengono note. |
| [getParagraphs](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#getParagraphs) | Numero totale di paragrafi, se disponibili. |
| [getWords](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#getWords) | Numero totale di parole. |
| [getMultimediaClips](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Numero totale di clip audio e video. |

L'esempio seguente legge questi valori senza creare un oggetto [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e stampa un inventario compatto. Combina inoltre [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#getHeadingPairs) con [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#getTitlesOfParts) per visualizzare gruppi di contenuto come caratteri, temi e titoli delle diapositive.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Ogni [HeadingPair](https://reference.aspose.com/slides/it/php-java/aspose.slides/headingpair/) fornisce un nome di gruppo e il numero di elementi in quel gruppo. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#getTitlesOfParts) restituisce un array piatto e ordinato, quindi è necessario consumare il numero di titoli consecutivi specificato da ciascuna coppia di intestazione.

### **Metadati memorizzati e limitazioni di formato**

Le proprietà di inventario restituite da [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#readDocumentProperties) riflettono i metadata disponibili nel documento sorgente. Aspose.Slides non carica e attraversa il modello di oggetto presentazione per ricalcolare questi valori per questa chiamata. Le proprietà mancanti sono rappresentate da valori predefiniti e i valori memorizzati possono essere obsoleti se l'applicazione che ha salvato per ultima il file non ha aggiornato le proprietà del documento.

- **PPTX:** Il formato fornisce proprietà di documento estese per il conteggio di diapositive, note, diapositive nascoste, paragrafi, parole e multimedia, nonché per le coppie di intestazioni e i titoli delle parti. La disponibilità dipende da quali proprietà sono state scritte dal produttore del documento.
- **PPT:** Il formato binario può memorizzare le corrispondenti proprietà di riepilogo del documento. Se una proprietà è assente o non è stata aggiornata dal produttore del documento, Aspose.Slides restituisce il valore memorizzato o predefinito anziché calcolarlo dalle diapositive.
- **ODP:** I metadata OpenDocument forniscono statistiche generali del documento, come conteggi di pagine, paragrafi e parole, ma questi valori non corrispondono a tutte le proprietà estese specifiche di PowerPoint. I metadata di diapositive nascoste, note, multimedia, coppie di intestazioni e titoli delle parti potrebbero non essere disponibili e le proprietà di inventario potrebbero restituire valori predefiniti. Non trattare un valore zero o un array vuoto come prova autorevole dell'assenza del contenuto corrispondente.

Utilizzare l'approccio di metadata leggeri per inventari e controlli preliminari. Caricare la presentazione e ispezionare il suo modello di oggetto in memoria quando il risultato deve riflettere modifiche in memoria o quando è necessario verificare il contenuto effettivo della presentazione.

## **Aggiornare le proprietà della presentazione**

Le proprietà restituite da [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#readDocumentProperties) possono anche essere modificate senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/). Applicare le modifiche con [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#updateDocumentProperties), quindi scrivere la presentazione associata con [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

L'immagine seguente mostra le proprietà originali del documento.

![Original document properties of the PowerPoint presentation](input_properties.png)

L'esempio seguente modifica il titolo e l'ora dell'ultimo salvataggio e scrive il risultato in un nuovo file:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

L'immagine seguente mostra le proprietà del documento aggiornate.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Link utili**

Per controlli di sicurezza correlati e impostazioni di protezione, consultare i seguenti articoli:

- [Password-Protect Presentations](/slides/it/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/it/php-java/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i caratteri sono incorporati e quali sono?**

Caricare la presentazione e utilizzare [Presentation::getFontsManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getFontsManager). Chiamare [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) per ottenere i caratteri incorporati e [FontsManager::getFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/#getFonts) per ottenere i caratteri usati dalla presentazione. Confrontare i due risultati per individuare i caratteri necessari per il rendering ma non incorporati.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Quando i metadata del documento memorizzati sono sufficienti, leggere [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#getHiddenSlides) tramite [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/) e [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#readDocumentProperties). Questo è adatto per un inventario leggero. Se la presentazione è stata modificata in memoria, i metadata memorizzati potrebbero mancare o essere obsoleti; in tal caso, iterare su [Presentation::getSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSlides) e ispezionare il metodo [Slide::getHidden](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getHidden) di ciascuna diapositiva.

**Posso rilevare se vengono utilizzate dimensioni e orientamento personalizzati della diapositiva e se differiscono dalle impostazioni predefinite?**

Sì. Caricare la presentazione e chiamare [Presentation::getSlideSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSlideSize). Utilizzare [SlideSize::getType](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesize/#getSize) e [SlideSize::getOrientation](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidesize/#getOrientation) per confrontare le impostazioni correnti con i valori predefiniti e le dimensioni previste.

**Esiste un modo rapido per vedere se i grafici fanno riferimento a origini dati esterne?**

Sì. Individuare ciascun [Chart](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/) e chiamare [ChartData::getDataSourceType](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/#getDataSourceType). Per una cartella di lavoro esterna, chiamare [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). Il tipo di origine dati e il percorso identificano un riferimento esterno, ma verificare la disponibilità della destinazione richiede un controllo delle risorse separato.

**Come posso valutare le diapositive "pesanti" che potrebbero rallentare il rendering o l'esportazione in PDF?**

Non esiste una singola proprietà di complessità. Attraversare [Presentation::getSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSlides) e la collezione di forme di ciascuna diapositiva tramite [BaseSlide::getShapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/#getShapes). Utilizzare il conteggio delle forme e la presenza di immagini di grandi dimensioni, effetti, animazioni o multimedia come segnali di screening, e misurare un rendering o un'esportazione rappresentativa prima di considerare una diapositiva come colli di bottiglia confermati.