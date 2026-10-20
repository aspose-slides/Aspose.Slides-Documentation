---
title: Crea grafici Excel e incorporali nelle presentazioni come oggetti OLE
type: docs
weight: 30
url: /it/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Grafico Excel
- incorpora grafico
- oggetto OLE
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Crea un grafico Excel con Aspose.Cells per PHP via Java e incorpora la cartella di lavoro in una presentazione PowerPoint con Aspose.Slides per PHP via Java, includendo un'anteprima del grafico."
---
## **Panoramica**

Questo articolo mostra come creare un grafico a colonne di Excel con Aspose.Cells for PHP via Java e incorporare la sua cartella di lavoro in una presentazione PowerPoint con Aspose.Slides for PHP via Java. La cartella di lavoro incorporata contiene sia i dati di origine sia il grafico. Un'anteprima PNG separata visualizza il grafico nella diapositiva prima che l'oggetto OLE venga attivato.

Il risultato è un oggetto Excel incorporato, non un grafico PowerPoint nativo. Modificare la cartella di lavoro tramite OLE richiede un'applicazione desktop che supporti l'attivazione OLE e un'installazione di Excel compatibile.

## **Prerequisiti**

Configura Aspose.Cells for PHP via Java e Aspose.Slides for PHP via Java con la stessa istanza di PHP/Java Bridge. Carica entrambi i wrapper PHP e rendi disponibili le librerie Java di entrambi i prodotti al bridge. Microsoft Office non è necessario per generare la presentazione con queste librerie.

Non sono richiesti file di input: l'esempio crea i dati e il grafico in memoria, quindi scrive `OutputChart.pptx` nella directory di lavoro corrente. Applica le licenze per entrambi i prodotti quando si esegue al di fuori della modalità di valutazione.

## **Come funziona l'incorporamento**

1. Crea una cartella di lavoro con un foglio dati e un foglio grafico.  
2. Rendi il foglio grafico attivo in modo che la cartella di lavoro si apra sul grafico.  
3. Imposta l'intervallo di visualizzazione OLE della cartella di lavoro e rendi il grafico in PNG.  
4. Salva la cartella di lavoro come XLSX in memoria e incorpora quei byte in una diapositiva.  
5. Assegna il PNG come anteprima dell'oggetto OLE e salva la presentazione come PPTX.  

L'intervallo di visualizzazione della cartella di lavoro e il riquadro sulla diapositiva hanno ruoli diversi. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) accetta indici di riga e colonna di inizio/fine basati su zero. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) invece accetta la riga superiore, la colonna sinistra, la riga inferiore e la colonna destra. L'esempio utilizza l'indice di riga 55 e l'indice di colonna 25 come confini in basso a destra; questi valori sono scelte di layout, non il numero di righe o colonne di dati.

Il riquadro della diapositiva utilizza punti. L'esempio lo adatta all'interno della diapositiva e lo centra preservando il rapporto d'aspetto del PNG, anziché allungare l'anteprima per riempire la diapositiva.

## **Crea e incorpora il grafico**

Il seguente esempio completo popola `DataSheet` con quattro righe e cinque colonne di valori. Ogni riga diventa una serie del grafico. `ChartSheet` è selezionato come foglio attivo prima di salvare la cartella di lavoro.

La cartella di lavoro è salvata esplicitamente come XLSX, corrispondente all'estensione `xlsx` passata a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). I risultati numerici Java vengono convertiti con `java_values` prima che PHP esegua operazioni aritmetiche, mentre i dati binari rimangono in array di byte Java. Il PNG è caricato direttamente dai suoi byte senza una conversione bitmap intermedia. Assegnandolo tramite [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) si sostituisce il segnaposto OLE predefinito.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Mantieni il PNG e l'XLSX come array di byte Java quando li passi a Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Adatta e centra l'anteprima preservando il rapporto d'aspetto.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Risultato previsto**

`OutputChart.pptx` contiene una diapositiva con una cartella di lavoro Excel incorporata e un'anteprima del grafico. La cartella di lavoro contiene i dati originali e un grafico a colonne con quattro serie. L'anteprima è centrata sulla diapositiva e ne conserva le proporzioni.

![Grafico a colonne di Excel visualizzato come anteprima di una cartella di lavoro incorporata](excel-chart-ole-preview.png)

In un ambiente desktop PowerPoint compatibile con Excel disponibile, fare doppio clic sull'oggetto per attivare e modificare la cartella di lavoro incorporata. L'attivazione e la modifica dipendono dal supporto OLE dell'applicazione host e dalle impostazioni di sicurezza.

## **FAQ**

**Perché è necessaria un'immagine di anteprima?**

La cartella di lavoro incorporata e la sua anteprima nella diapositiva sono contenuti separati. Fornire un'immagine del grafico così la diapositiva mostra il grafico invece del segnaposto predefinito "EMBEDDED OLE OBJECT". Vedi [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/php-java/object-preview-issue-when-adding-oleobjectframe/).

**L'anteprima si aggiorna automaticamente quando modifico la cartella di lavoro nel codice?**

Considera l'anteprima come un'istantanea. Quando si aggiornano i dati della cartella di lavoro programmaticamente, rigenera l'immagine del grafico e sostituisci l'anteprima così come i dati della cartella di lavoro incorporata.

**Posso usare XLS invece di XLSX?**

Sì. Salva la cartella di lavoro in formato XLS e usa `xls` come estensione dei dati incorporati. L'estensione deve corrispondere al formato effettivo della cartella di lavoro; cambiare solo l'estensione non converte i dati.

**Perché l'oggetto potrebbe cambiare dimensione dopo l'attivazione?**

L'applicazione host può aggiornare la presentazione dell'oggetto OLE quando attiva la cartella di lavoro. Sia l'intervallo di visualizzazione OLE della cartella di lavoro sia le dimensioni del riquadro della diapositiva sono importanti. Vedi [Soluzione funzionante per il ridimensionamento del grafico in PPTX](/slides/it/java/working-solution-for-chart-resizing-in-pptx/).

## **Sezioni correlate**

- [Soluzione funzionante per il ridimensionamento del grafico in PPTX](/slides/it/java/working-solution-for-chart-resizing-in-pptx/)
- [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [Gestire gli oggetti OLE](/slides/it/php-java/manage-ole/)