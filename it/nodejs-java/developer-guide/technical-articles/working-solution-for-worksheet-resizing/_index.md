---
title: Soluzione funzionante per il ridimensionamento dei fogli di lavoro
type: docs
weight: 20
url: /it/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- immagine di anteprima
- ridimensionamento immagine
- Excel
- foglio di lavoro
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Correggi il ridimensionamento OLE dei fogli di lavoro Excel nelle presentazioni: due modi per mantenere i frame degli oggetti coerenti—scala il frame o il foglio—nei formati PPT e PPTX."
---
{{% alert color="info" title="Nota" %}}
I fogli di lavoro Excel incorporati come oggetti OLE in una presentazione PowerPoint usando componenti Aspose possono ridimensionarsi in modo inatteso dopo la prima attivazione. Questo comportamento crea una differenza visiva evidente tra l'oggetto OLE prima e dopo l'attivazione. Questo articolo spiega il problema e descrive due modi per affrontarlo.
{{% /alert %}}

## **Contesto**
Nell'articolo [Gestisci OLE](/slides/it/nodejs-java/manage-ole/), abbiamo spiegato come aggiungere un frame OLE a una presentazione PowerPoint usando Aspose.Slides per Node.js tramite Java. Per affrontare il [problema di anteprima dell'oggetto](/slides/it/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato un'immagine dell'area del foglio di lavoro selezionata al frame dell'oggetto OLE. Nella presentazione di output, quando si fa doppio clic sul frame OLE che visualizza l'immagine del foglio, il cartellino Excel viene attivato. Gli utenti finali possono apportare le modifiche desiderate al vero cartellino Excel e poi tornare alla diapositiva facendo clic al di fuori del cartellino Excel attivato. La dimensione del frame OLE cambierà quando l'utente ritorna alla diapositiva. Il fattore di ridimensionamento varierà in base alle dimensioni del frame OLE e del cartellino Excel incorporato.

## **Causa del ridimensionamento**
Poiché il cartellino Excel ha una propria dimensione della finestra, tenta di mantenere la sua dimensione originale alla prima attivazione. D'altro canto, il frame OLE ha le proprie dimensioni. Secondo Microsoft, quando il cartellino Excel è attivato, Excel e PowerPoint negoziano la dimensione per garantire che mantenga le proporzioni corrette come parte del processo di incorporamento. Il ridimensionamento avviene in base alle differenze tra la dimensione della finestra di Excel e le dimensioni e la posizione del frame OLE.

## **Soluzione funzionante**
Esistono due soluzioni possibili per evitare l'effetto di ridimensionamento.

- Ridimensionare il frame OLE nella presentazione PowerPoint per corrispondere all'altezza e alla larghezza totali delle righe e delle colonne selezionate.  
- Mantenere costante la dimensione del frame OLE e ridimensionare le righe e le colonne selezionate per adattarle al suo interno.

### **Ridimensiona la dimensione del frame OLE**
Questo approccio imposta la dimensione del frame OLE per corrispondere all'altezza e alla larghezza totali delle righe e delle colonne selezionate nel foglio Excel incorporato.

L'esempio carica un cartellino Excel esistente e seleziona le prime 10 righe e 13 colonne del suo primo foglio usando indici a base zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) definisce l'intervallo visualizzato. L'anteprima è resa a 96 DPI e le sue dimensioni in pixel sono convertite in punti usando 72 punti per pollice. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) incorpora il cartellino modificato in un frame con quelle dimensioni. L'anteprima è assegnata tramite [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) per sostituire il segnaposto "EMBEDDED OLE OBJECT" nella presentazione salvata.

Installa i pacchetti `aspose.cells`, `aspose.slides.via.java` e `java` e posiziona `sample.xlsx` nella directory di lavoro. Per ogni approccio, esegui prima lo script di preparazione, poi lo script di incorporamento in un processo Node.js separato nella stessa directory. I due pacchetti Aspose inizializzano il bridge Java separatamente.

Salva questo script di preparazione come `prepare-frame-scaled.js` ed eseguilo con `node prepare-frame-scaled.js`. Genera `frame-scaled.xlsx` e `frame-scaled.png`.

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// Tutto il lavoro sincrono è completato; arresta il processo del ponte Java.
process.exit(0);
```

Salva questo script di incorporamento come `embed-frame-scaled.js` ed eseguilo con `node embed-frame-scaled.js`. Legge quei file e genera `frame-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// Tutto il lavoro sincrono è completato; arresta il processo del ponte Java.
process.exit(0);
```

L'aiutante di anteprima imposta [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) sull'intervallo selezionato e rimuove margini, intestazioni e piè di pagina. Con [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) abilitato, [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) rende l'intervallo come immagine PNG. L'aiutante salva l'immagine PNG in un file per l'uso nella presentazione.

### **Ridimensiona la dimensione dell'intervallo di celle**
Questo approccio scala le altezze delle righe selezionate e le larghezze delle colonne selezionate per corrispondere a una dimensione personalizzata del frame OLE.

L'esempio carica un cartellino Excel esistente e seleziona le prime 10 righe e 13 colonne del suo primo foglio usando indici a base zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) definisce l'intervallo visualizzato, e l'aiutante scala quell'intervallo per adattarlo a un frame largo 400 punti e alto 100 punti. Dopo aver salvato il cartellino modificato in un file, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) lo incorpora nella dimensione specificata. Un'anteprima resa a 96 DPI è assegnata tramite [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), così la presentazione salvata visualizza le celle selezionate invece del segnaposto predefinito.

Salva questo script di preparazione come `prepare-cells-scaled.js` ed eseguilo con `node prepare-cells-scaled.js`. Genera `cells-scaled.xlsx` e `cells-scaled.png`.

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// Tutto il lavoro sincrono è completato; arresta il processo del ponte Java.
process.exit(cellsPrepared ? 0 : 1);
```

Salva questo script di incorporamento come `embed-cells-scaled.js` ed eseguilo con `node embed-cells-scaled.js`. Legge quei file e genera `cells-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// Tutto il lavoro sincrono è completato; arresta il processo del ponte Java.
process.exit(0);
```

L'aiutante di scaling calcola rapporti di larghezza e altezza separati per l'intervallo selezionato, preservando le larghezze relative delle colonne e le altezze relative delle righe. Converte le dimensioni calcolate da punti a pollici prima di applicarle con [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) e [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch). L'intervallo selezionato deve avere larghezza e altezza diverse da zero.

Questo aiutante di anteprima rende l'intervallo ridimensionato usando [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). Limita [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) a quell'intervallo, rimuove margini, intestazioni e piè di pagina, e salva l'immagine PNG in un file.

## **Conclusione**
{{% alert color="info" title="Nota" %}}
Esistono due approcci per risolvere il problema di ridimensionamento del foglio di lavoro. Scegli l'approccio che meglio si adatta ai tuoi requisiti e al caso d'uso. Entrambi gli approcci funzionano allo stesso modo, sia che le presentazioni siano create da un modello sia da zero. Inoltre, non vi è alcun limite alla dimensione del frame OLE in questa soluzione.
{{% /alert %}}

## **FAQ**
**Perché un foglio di lavoro Excel incorporato cambia dimensione alla prima attivazione in PowerPoint?**  
Questo accade perché Excel tenta di mantenere la dimensione originale della finestra quando viene attivato, mentre il frame OLE in PowerPoint ha le proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere il rapporto d'aspetto, il che può causare il ridimensionamento.

**È possibile evitare completamente questo problema di ridimensionamento?**  
Sì. Ridimensionando il frame OLE per adattarlo alla dimensione dell'intervallo di celle Excel o ridimensionando l'intervallo di celle per adattarlo alla dimensione desiderata del frame OLE, è possibile evitare il ridimensionamento indesiderato.

**Quale metodo di scaling dovrei usare, scaling del frame OLE o scaling dell'intervallo di celle?**  
Seleziona **scaling del frame OLE** se vuoi mantenere le dimensioni originali delle righe e colonne di Excel. Seleziona **scaling dell'intervallo di celle** se desideri una dimensione fissa per il frame OLE nella tua presentazione.

**Queste soluzioni funzioneranno se la presentazione è basata su un modello?**  
Sì. Entrambe le soluzioni funzionano per presentazioni create da modelli e da zero.

**Esiste un limite alla dimensione del frame OLE quando si usano questi metodi?**  
No. Puoi impostare il frame OLE a qualsiasi dimensione purché tu regoli correttamente lo scaling.

**C'è un modo per evitare il testo segnaposto "EMBEDDED OLE OBJECT" in PowerPoint?**  
Sì. Scattando un'istantanea dell'intervallo di celle Excel di destinazione e impostandola come immagine segnaposto del frame OLE, è possibile visualizzare un'immagine di anteprima personalizzata al posto del segnaposto predefinito.

## **Articoli correlati**
[Creare un grafico Excel e incorporarlo in una presentazione come oggetto OLE](/slides/it/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Aggiornare automaticamente gli oggetti OLE usando un componente aggiuntivo MS PowerPoint](/slides/it/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)