---
title: Soluzione funzionante per il ridimensionamento del foglio di lavoro
type: docs
weight: 20
url: /it/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- immagine di anteprima
- ridimensionamento immagine
- Excel
- foglio di lavoro
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Correggi il ridimensionamento OLE del foglio di lavoro Excel nelle presentazioni: due modi per mantenere i frame degli oggetti coerenti—scala il frame o il foglio—nei formati PPT e PPTX."
---
{{% alert color="info" title="Nota" %}}

I fogli di lavoro Excel incorporati come oggetti OLE in una presentazione PowerPoint utilizzando i componenti Aspose possono ridimensionarsi in modo inatteso dopo la prima attivazione. Questo comportamento crea una differenza visiva evidente tra l'oggetto OLE prima e dopo l'attivazione. Questo articolo spiega il problema e descrive due modi per risolverlo.

{{% /alert %}}

## **Contesto**

Nell'articolo [Gestire OLE](/slides/it/java/manage-ole/), abbiamo spiegato come aggiungere un frame OLE a una presentazione PowerPoint usando Aspose.Slides per Java. Per affrontare il [problema di anteprima dell'oggetto](/slides/it/java/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato un'immagine dell'area del foglio di lavoro selezionata al frame dell'oggetto OLE. Nella presentazione di output, quando si fa doppio clic sul frame OLE che mostra l'immagine del foglio di lavoro, il file Excel viene attivato. Gli utenti finali possono apportare qualsiasi modifica desiderata al vero file Excel e quindi tornare alla diapositiva facendo clic al di fuori del file Excel attivato. Le dimensioni del frame OLE cambieranno quando l'utente ritorna alla diapositiva. Il fattore di ridimensionamento varierà in base alle dimensioni del frame OLE e del file Excel incorporato.

## **Causa del ridimensionamento**

Poiché il file Excel ha le proprie dimensioni della finestra, tenta di mantenere le dimensioni originali al momento della prima attivazione. D'altra parte, il frame OLE ha le proprie dimensioni. Secondo Microsoft, quando il file Excel è attivato, Excel e PowerPoint negoziano le dimensioni per garantire che mantengano le proporzioni corrette come parte del processo di incorporamento. Il ridimensionamento avviene in base alle differenze tra le dimensioni della finestra di Excel e le dimensioni e la posizione del frame OLE.

## **Soluzione funzionante**

Esistono due soluzioni possibili per evitare l'effetto di ridimensionamento.

- Ridimensionare il frame OLE nella presentazione PowerPoint per corrispondere all'altezza e larghezza totali delle righe e colonne selezionate.  
- Mantenere costante la dimensione del frame OLE e ridimensionare le righe e colonne selezionate per adattarle al suo interno.

### **Scala le dimensioni del frame OLE**

Questo approccio imposta le dimensioni del frame OLE per corrispondere all'altezza e larghezza totali delle righe e colonne selezionate nel foglio Excel incorporato.

L'esempio carica un file Excel esistente e seleziona le prime 10 righe e 13 colonne del primo foglio usando indici basati su zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definisce l'intervallo visualizzato. L'anteprima è renderizzata a 96 DPI e le sue dimensioni in pixel sono convertite in punti usando 72 punti per pollice. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) incorpora il workbook modificato in un frame con quelle dimensioni. L'anteprima è assegnata tramite [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) per sostituire il segnaposto "EMBEDDED OLE OBJECT" nella presentazione salvata.

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Imposta la dimensione visualizzata quando il file di cartella di lavoro viene usato come oggetto OLE in PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Ottieni la larghezza e l'altezza dell'immagine OLE in punti.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Abbiamo bisogno di usare la cartella di lavoro modificata.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Aggiungi l'immagine OLE alle risorse della presentazione.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Crea il frame dell'oggetto OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

L'helper di anteprima imposta [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) sull'intervallo selezionato e rimuove margini, intestazioni e piè di pagina. Con [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) abilitato, [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) renderizza l'intervallo come immagine PNG. L'helper restituisce un nuovo stream di input contenente l'immagine PNG, posizionato all'inizio per l'uso nella presentazione.

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

### **Scala le dimensioni dell'intervallo di celle**

Questo approccio scala le altezze delle righe selezionate e le larghezze delle colonne selezionate per corrispondere a una dimensione personalizzata del frame OLE.

L'esempio carica un file Excel esistente e seleziona le prime 10 righe e 13 colonne del primo foglio usando indici basati su zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definisce l'intervallo visualizzato, e l'helper sottostante scala quell'intervallo per adattarlo a un frame largo 400 punti e alto 100 punti. Dopo aver salvato il workbook modificato in uno stream, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) lo incorpora nelle dimensioni specificate. Un'anteprima renderizzata a 96 DPI è assegnata tramite [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--), così la presentazione salvata mostra le celle selezionate invece del segnaposto predefinito.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Imposta la dimensione visualizzata quando il file di cartella di lavoro viene usato come oggetto OLE in PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Scala l'intervallo di celle per adattarlo alle dimensioni del frame.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Abbiamo bisogno di usare la cartella di lavoro modificata.
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

L'helper di scaling calcola rapporti di larghezza e altezza separati per l'intervallo selezionato, preservando le larghezze relative delle colonne e le altezze relative delle righe. Converte le dimensioni calcolate da punti a pollici prima di applicarle con [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) e [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). L'intervallo selezionato deve avere larghezza e altezza diverse da zero.

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

Questo helper di anteprima renderizza l'intervallo ridimensionato usando [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Limita [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) a quel intervallo, rimuove margini, intestazioni e piè di pagina, e restituisce uno stream PNG posizionato all'inizio.

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

{{% alert color="info" title="Nota" %}}

Esistono due approcci per risolvere il problema di ridimensionamento del foglio di lavoro. Scegli l'approccio che meglio si adatta ai tuoi requisiti e al caso d'uso. Entrambi gli approcci funzionano allo stesso modo, sia che le presentazioni siano create da un modello sia da zero. Inoltre, non vi è alcun limite alla dimensione del frame OLE in questa soluzione.

{{% /alert %}}

## **FAQ**

**Perché un foglio di lavoro Excel incorporato cambia dimensione quando viene attivato per la prima volta in PowerPoint?**

Questo accade perché Excel tenta di mantenere le dimensioni originali della finestra quando è attivato, mentre il frame OLE in PowerPoint ha le proprie dimensioni. PowerPoint ed Excel negoziano le dimensioni per mantenere le proporzioni, il che può causare il ridimensionamento.

**È possibile evitare completamente questo problema di ridimensionamento?**

Sì. Ridimensionando il frame OLE per adattarlo alle dimensioni dell'intervallo di celle Excel o scalando l'intervallo di celle per adattarlo alla dimensione desiderata del frame OLE, è possibile prevenire il ridimensionamento indesiderato.

**Quale metodo di scaling devo usare, il scaling del frame OLE o quello dell'intervallo di celle?**

Seleziona **scala del frame OLE** se desideri mantenere le dimensioni originali delle righe e colonne di Excel. Seleziona **scala dell'intervallo di celle** se desideri una dimensione fissa per il frame OLE nella tua presentazione.

**Queste soluzioni funzionano se la presentazione è basata su un modello?**

Sì. Entrambe le soluzioni funzionano per presentazioni create da modelli e da zero.

**Esiste un limite alla dimensione del frame OLE quando si usano questi metodi?**

No. Puoi impostare il frame OLE a qualsiasi dimensione purché il fattore di scala sia adeguato.

**C'è un modo per evitare il testo segnaposto "EMBEDDED OLE OBJECT" in PowerPoint?**

Sì. Acquisendo uno snapshot dell'intervallo di celle Excel di destinazione e impostandolo come immagine segnaposto del frame OLE, puoi visualizzare un'immagine di anteprima personalizzata al posto del segnaposto predefinito.

## **Articoli correlati**

[Creare un grafico Excel e incorporarlo in una presentazione come oggetto OLE](/slides/it/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Aggiornare gli oggetti OLE automaticamente usando un componente aggiuntivo MS PowerPoint](/slides/it/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)