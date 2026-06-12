---
title: Soluzione funzionante per il ridimensionamento del foglio di lavoro
type: docs
weight: 20
url: /it/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- immagine di anteprima
- ridimensionamento immagine
- Excel
- foglio di lavoro
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Correggi il ridimensionamento OLE dei fogli di lavoro Excel nelle presentazioni: due modi per mantenere i frame degli oggetti coerenti—scala il frame o il foglio—nei formati PPT e PPTX."
---
{{% alert color="primary" %}}
È stato osservato che i fogli di lavoro Excel incorporati come oggetti OLE in una presentazione PowerPoint tramite componenti Aspose vengono ridimensionati a una scala non identificata dopo la prima attivazione. Questo comportamento crea una differenza visiva evidente nella presentazione tra gli stati pre‑ e post‑attivazione dell’oggetto OLE. Abbiamo investigato il problema in dettaglio e fornito una soluzione, descritta in questo articolo.
{{% /alert %}}

## **Contesto**

Nell'articolo [Manage OLE](/slides/it/androidjava/manage-ole/), abbiamo spiegato come aggiungere un frame OLE a una presentazione PowerPoint usando Aspose.Slides per Android via Java. Per affrontare il [object preview issue](/slides/it/androidjava/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato un'immagine dell'area del foglio di lavoro selezionata al frame OLE. Nella presentazione di output, quando si fa doppio clic sul frame OLE che mostra l'immagine del foglio, il workbook Excel viene attivato. Gli utenti finali possono apportare le modifiche desiderate al workbook Excel reale e poi tornare alla diapositiva facendo clic al di fuori del workbook attivato. La dimensione del frame OLE cambierà quando l'utente ritorna alla diapositiva. Il fattore di ridimensionamento varierà a seconda delle dimensioni del frame OLE e del workbook Excel incorporato.

## **Causa del ridimensionamento**

Poiché il workbook Excel ha la propria dimensione della finestra, tenta di mantenere la dimensione originale al primo avvio. D'altra parte, il frame OLE ha la sua dimensione. Secondo Microsoft, quando il workbook Excel è attivato, Excel e PowerPoint negoziano la dimensione per assicurare che mantenga le proporzioni corrette come parte del processo di incorporamento. Il ridimensionamento avviene sulla base delle differenze tra la dimensione della finestra di Excel e la dimensione e posizione del frame OLE.

## **Soluzione**

Esistono due possibili soluzioni per evitare l'effetto di ridimensionamento.

- Ridimensionare la dimensione del frame OLE nella presentazione PowerPoint per corrispondere all’altezza e alla larghezza del numero desiderato di righe e colonne nel frame OLE.  
- Mantenere costante la dimensione del frame OLE e ridimensionare le righe e le colonne partecipanti per adattarsi alla dimensione del frame OLE selezionato.

### **Ridimensiona la dimensione del frame OLE**

In questo approccio, impareremo come impostare la dimensione del frame OLE del workbook Excel incorporato in modo che corrisponda alla dimensione cumulativa delle righe e colonne partecipanti nel foglio Excel.

Supponiamo di avere un foglio Excel modello e di volerlo aggiungere a una presentazione come frame OLE. In questo scenario, la dimensione del frame OLE verrà prima calcolata in base alle altezze cumulative delle righe e alle larghezze cumulative delle colonne partecipanti nel workbook. Poi, imposteremo la dimensione del frame OLE a questo valore calcolato. Per evitare il messaggio rosso "EMBEDDED OLE OBJECT" per il frame OLE in PowerPoint, cattureremo anche un'immagine delle parti desiderate delle righe e colonne nel workbook e la imposteremo come immagine del frame OLE.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Imposta la dimensione visualizzata quando il file di workbook viene usato come oggetto OLE in PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// We need to use the modified workbook.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **Ridimensiona la dimensione dell’intervallo di celle**

In questo approccio, impareremo come ridimensionare le altezze delle righe partecipanti e la larghezza delle colonne partecipanti per corrispondere a una dimensione personalizzata del frame OLE.

Supponiamo di avere un foglio Excel modello e di volerlo aggiungere a una presentazione come frame OLE. In questo scenario, imposteremo la dimensione del frame OLE e ridimensioneremo le righe e le colonne che partecipano all'area del frame OLE. Salveremo poi il workbook in uno stream per applicare le modifiche e lo convertiremo in un array di byte per aggiungerlo al frame OLE. Per evitare il messaggio rosso "EMBEDDED OLE OBJECT" per il frame OLE in PowerPoint, cattureremo anche un'immagine delle parti desiderate delle righe e colonne nel workbook e la imposteremo come immagine del frame OLE.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Imposta la dimensione visualizzata quando il file di workbook viene usato come oggetto OLE in PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Scala l'intervallo di celle per adattarlo alla dimensione del frame.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// We need to use the modified workbook.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Aggiungi l'immagine OLE alle risorse della presentazione.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Crea il frame dell'oggetto OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     La larghezza prevista dell'intervallo di celle in punti.
 * @param height    L'altezza prevista dell'intervallo di celle in punti.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **Conclusione**

{{% alert color="primary" %}} 
Esistono due approcci per risolvere il problema di ridimensionamento del foglio di lavoro. La scelta dell'approccio appropriato dipende dai requisiti specifici e dal caso d'uso. Entrambi gli approcci funzionano allo stesso modo, sia che le presentazioni vengano create da un modello sia da zero. Inoltre, non c'è alcun limite alla dimensione del frame OLE in questa soluzione.
{{% /alert %}}

## **FAQ**

**Perché un foglio di lavoro Excel incorporato cambia dimensione al primo avvio in PowerPoint?**  
Questo accade perché Excel tenta di mantenere la dimensione originale della finestra quando viene attivato, mentre il frame OLE in PowerPoint ha le proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere le proporzioni, il che può causare il ridimensionamento.

**È possibile evitare completamente questo problema di ridimensionamento?**  
Sì. Ridimensionando il frame OLE per adattarlo alla dimensione dell’intervallo di celle Excel o ridimensionando l’intervallo di celle per adattarlo alla dimensione desiderata del frame OLE, è possibile prevenire il ridimensionamento indesiderato.

**Quale metodo di ridimensionamento dovrei usare, il ridimensionamento del frame OLE o quello dell’intervallo di celle?**  
Seleziona **ridimensionamento del frame OLE** se vuoi mantenere le dimensioni originali delle righe e colonne di Excel. Se desideri una dimensione fissa per il frame OLE nella tua presentazione, scegli **ridimensionamento dell’intervallo di celle**.

**Queste soluzioni funzioneranno se la presentazione è basata su un modello?**  
Sì. Entrambe le soluzioni funzionano per presentazioni create da modelli e da zero.

**C'è un limite alla dimensione del frame OLE quando si usano questi metodi?**  
No. Puoi impostare il frame OLE a qualsiasi dimensione, purché il fattore di scala sia impostato correttamente.

**È possibile evitare il testo segnaposto "EMBEDDED OLE OBJECT" in PowerPoint?**  
Sì. Scattando un'istantanea dell’intervallo di celle Excel di destinazione e impostandola come immagine segnaposto del frame OLE, è possibile visualizzare un'anteprima personalizzata al posto del segnaposto predefinito.