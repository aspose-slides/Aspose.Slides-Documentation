---
title: Soluzione funzionante per il ridimensionamento del foglio di lavoro
type: docs
weight: 20
url: /it/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- immagine di anteprima
- ridimensionamento immagine
- Excel
- foglio di lavoro
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Correggi il ridimensionamento OLE del foglio di lavoro Excel nelle presentazioni: due modalità per mantenere i frame degli oggetti coerenti—scala il frame o il foglio—nei formati PPT e PPTX."
---
{{% alert color="info" title="Note" %}}

I fogli di lavoro Excel incorporati come oggetti OLE in una presentazione PowerPoint tramite componenti Aspose possono ridimensionarsi in modo imprevisto dopo la prima attivazione. Questo comportamento crea una differenza visiva evidente tra l'oggetto OLE prima e dopo l'attivazione. Questo articolo spiega il problema e descrive due modalità per risolverlo.

{{% /alert %}}

## **Contesto**

Nell'articolo [Gestisci OLE](/slides/it/php-java/manage-ole/), abbiamo spiegato come aggiungere un frame OLE a una presentazione PowerPoint usando Aspose.Slides per PHP via Java. Per affrontare il problema di [anteprima dell'oggetto](/slides/it/php-java/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato un'immagine dell'area del foglio di lavoro selezionata al frame dell'oggetto OLE. Nella presentazione risultante, quando si fa doppio clic sul frame OLE che mostra l'immagine del foglio, il workbook Excel viene attivato. Gli utenti finali possono apportare le modifiche desiderate al workbook Excel reale e poi tornare alla diapositiva facendo clic fuori dal workbook attivato. Le dimensioni del frame OLE cambieranno quando l'utente torna alla diapositiva. Il fattore di ridimensionamento varia in base alle dimensioni del frame OLE e del workbook Excel incorporato.

## **Causa del ridimensionamento**

Poiché il workbook Excel ha una propria dimensione della finestra, tenta di mantenere la sua dimensione originale alla prima attivazione. D'altra parte, il frame OLE ha una sua dimensione. Secondo Microsoft, quando il workbook Excel è attivato, Excel e PowerPoint negoziano la dimensione per garantire che venga mantenuta la corretta proporzione nel processo di incorporamento. Il ridimensionamento avviene in base alle differenze tra la dimensione della finestra Excel e le dimensioni e posizione del frame OLE.

## **Soluzione funzionante**

Esistono due possibili soluzioni per evitare l'effetto di ridimensionamento.

- Ridimensionare il frame OLE nella presentazione PowerPoint in modo da corrispondere all'altezza e larghezza totali delle righe e colonne selezionate.
- Mantenere costante la dimensione del frame OLE e ridimensionare le righe e colonne selezionate per adattarle al suo interno.

### **Ridimensionare le dimensioni del frame OLE**

Questo approccio imposta le dimensioni del frame OLE affinché corrispondano all'altezza e larghezza totali delle righe e colonne selezionate nel foglio Excel incorporato.

L'esempio carica un workbook Excel esistente e seleziona le prime 10 righe e 13 colonne del primo foglio usando indici a zero. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) definisce l'intervallo visualizzato. L'anteprima è renderizzata a 96 DPI e le sue dimensioni in pixel sono convertite in punti usando 72 punti per pollice. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) incorpora il workbook modificato in un frame con quelle dimensioni. L'anteprima è assegnata tramite [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) per sostituire il segnaposto "EMBEDDED OLE OBJECT" nella presentazione salvata.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Incorpora il workbook modificato e mantieni i dati binari in array di byte Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

L'aiuto all'anteprima imposta [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) sull'intervallo selezionato e rimuove margini, intestazioni e piè di pagina. Con [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) abilitato, [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) renderizza l'intervallo come immagine PNG. L'aiuto restituisce un nuovo stream di input contenente l'immagine PNG, posizionato all'inizio per l'uso nella presentazione.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **Ridimensionare l'intervallo di celle**

Questo approccio ridimensiona le altezze delle righe selezionate e le larghezze delle colonne selezionate per corrispondere a una dimensione personalizzata del frame OLE.

L'esempio carica un workbook Excel esistente e seleziona le prime 10 righe e 13 colonne del primo foglio usando indici a zero. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) definisce l'intervallo visualizzato, e l'aiuto qui sotto ridimensiona quell'intervallo per adattarlo a un frame largo 400 punti e alto 100 punti. Dopo aver salvato il workbook modificato in uno stream, [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) lo incorpora nella dimensione specificata. Un'anteprima renderizzata a 96 DPI è assegnata tramite [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), così la presentazione salvata visualizza le celle selezionate invece del segnaposto predefinito.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Incorpora il workbook modificato e mantieni i dati binari in array di byte Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

L'aiuto di scaling calcola rapporti di larghezza e altezza separati per l'intervallo selezionato, preservando le larghezze relative delle colonne e le altezze relative delle righe. Converte le dimensioni calcolate da punti a pollici prima di applicarle con [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) e [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch). L'intervallo selezionato deve avere larghezza e altezza diverse da zero.

```php
use aspose\cells\CellsUnitType;

// Larghezza e altezza sono le dimensioni previste dell'intervallo di celle in punti.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

Questo aiuto all'anteprima renderizza l'intervallo ridimensionato usando [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage). Limita [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) a quell'intervallo, rimuove margini, intestazioni e piè di pagina, e restituisce uno stream PNG posizionato all'inizio.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **Conclusione**

{{% alert color="info" title="Note" %}}

Esistono due approcci per risolvere il problema di ridimensionamento del foglio di lavoro. Scegli l'approccio che meglio si adatta ai tuoi requisiti e caso d'uso. Entrambi gli approcci funzionano allo stesso modo, sia che le presentazioni siano create da un modello sia da zero. Inoltre, non c'è alcun limite alla dimensione del frame OLE in questa soluzione.

{{% /alert %}}

## **FAQ**

**Perché un foglio Excel incorporato cambia dimensione al primo attivarsi in PowerPoint?**

Questo accade perché Excel tenta di mantenere la dimensione originale della finestra quando viene attivato, mentre il frame OLE in PowerPoint ha dimensioni proprie. PowerPoint ed Excel negoziano la dimensione per mantenere le proporzioni, il che può causare il ridimensionamento.

**È possibile evitare completamente questo problema di ridimensionamento?**

Sì. Ridimensionando il frame OLE per adattarlo alla dimensione dell'intervallo di celle Excel o ridimensionando l'intervallo di celle per adattarlo al frame OLE desiderato, è possibile evitare il ridimensionamento indesiderato.

**Quale metodo di scaling dovrei usare, scaling del frame OLE o scaling dell'intervallo di celle?**

Seleziona **scaling del frame OLE** se vuoi mantenere le dimensioni originali delle righe e colonne Excel. Seleziona **scaling dell'intervallo di celle** se desideri una dimensione fissa per il frame OLE nella presentazione.

**Queste soluzioni funzionano se la mia presentazione è basata su un modello?**

Sì. Entrambe le soluzioni funzionano per presentazioni create da modelli e da zero.

**Esiste un limite alla dimensione del frame OLE quando si usano questi metodi?**

No. È possibile impostare il frame OLE a qualsiasi dimensione, purché la scala venga impostata correttamente.

**C'è un modo per evitare il testo segnaposto "EMBEDDED OLE OBJECT" in PowerPoint?**

Sì. Acquisendo un'istantanea dell'intervallo di celle Excel di destinazione e impostandola come immagine segnaposto del frame OLE, è possibile visualizzare un'immagine di anteprima personalizzata al posto del segnaposto predefinito.

## **Articoli correlati**

[Creare un grafico Excel e incorporarlo in una presentazione come oggetto OLE](/slides/it/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Aggiornare gli oggetti OLE automaticamente usando un add-in MS PowerPoint](/slides/it/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)