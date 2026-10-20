---
title: Soluzione operativa per il ridimensionamento del foglio di lavoro
type: docs
weight: 40
url: /it/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- immagine di anteprima
- ridimensionamento immagine
- Excel
- foglio di lavoro
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Correggi il ridimensionamento OLE dei fogli di lavoro Excel nelle presentazioni: due modi per mantenere i frame degli oggetti coerenti—scala il frame o il foglio—nei formati PPT e PPTX."
---
{{% alert color="info" title="Note" %}}

I fogli di lavoro Excel incorporati come oggetti OLE in una presentazione PowerPoint utilizzando i componenti Aspose possono ridimensionarsi in modo inatteso dopo la prima attivazione. Questo comportamento crea una differenza visiva evidente tra l'oggetto OLE prima e dopo l'attivazione. Questo articolo spiega il problema e descrive due modalità per risolverlo.

{{% /alert %}} 

## **Contesto**

Nell'articolo [Gestisci OLE](/slides/it/net/manage-ole/), abbiamo spiegato come aggiungere un frame OLE a una presentazione PowerPoint utilizzando Aspose.Slides per .NET. Per risolvere il [problema di anteprima dell'oggetto](/slides/it/net/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato un'immagine dell'area del foglio di lavoro selezionata al frame dell'oggetto OLE. Nella presentazione risultante, quando si fa doppio clic sul frame OLE che mostra l'immagine del foglio di lavoro, il workbook di Excel viene attivato. Gli utenti finali possono apportare le modifiche desiderate al vero workbook di Excel e poi tornare alla diapositiva facendo clic al di fuori del workbook Excel attivato. Le dimensioni del frame OLE cambieranno quando l'utente tornerà alla diapositiva. Il fattore di ridimensionamento varrà a seconda delle dimensioni del frame OLE e del workbook Excel incorporato.

## **Causa del ridimensionamento**

Poiché il workbook di Excel ha una propria dimensione della finestra, tenta di mantenere la dimensione originale al momento della prima attivazione. D'altra parte, il frame dell'oggetto OLE ha una propria dimensione. Secondo Microsoft, quando il workbook di Excel è attivato, Excel e PowerPoint negoziano la dimensione per garantire che mantenga le proporzioni corrette come parte del processo di incorporamento. Il ridimensionamento si verifica in base alle differenze tra la dimensione della finestra di Excel e le dimensioni e la posizione del frame OLE.

## **Soluzione operativa**

Esistono due soluzioni possibili per evitare l'effetto di ridimensionamento.

- Ridimensionare il frame OLE nella presentazione PowerPoint per corrispondere all'altezza e larghezza totali delle righe e colonne selezionate.  
- Mantenere costante la dimensione del frame OLE e scalare le righe e colonne selezionate per adattarle all'interno.

### **Ridimensiona la dimensione del frame OLE**

Questo approccio imposta la dimensione del frame OLE in modo da corrispondere all'altezza e larghezza totali delle righe e colonne selezionate nel foglio di lavoro Excel incorporato.

L'esempio carica un workbook Excel esistente e seleziona le prime 10 righe e le prime 13 colonne del suo primo foglio di lavoro utilizzando indici basati su zero. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) definisce l'intervallo visualizzato. L'anteprima è renderizzata a 96 DPI e le sue dimensioni in pixel vengono convertite in punti usando 72 punti per pollice. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) incorpora il workbook modificato in un frame con quelle dimensioni. L'anteprima è assegnata tramite [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) per sostituire il segnaposto "EMBEDDED OLE OBJECT" nella presentazione salvata.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Imposta la dimensione visualizzata quando il file workbook è usato come oggetto OLE in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Ottieni la larghezza e l'altezza dell'immagine OLE in punti.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// È necessario utilizzare il workbook modificato.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Aggiungi l'immagine OLE alle risorse della presentazione.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Crea il frame dell'oggetto OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

L'helper di anteprima imposta [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) sull'intervallo selezionato e rimuove i margini, le intestazioni e i piè di pagina. Con [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) abilitata, [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) rende l'intervallo come immagine PNG. L'helper riavvolge lo stream dell'immagine prima di restituirlo per l'uso nella presentazione.

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **Ridimensiona la dimensione dell'intervallo di celle**

Questo approccio scala le altezze delle righe selezionate e le larghezze delle colonne selezionate per corrispondere a una dimensione personalizzata del frame OLE.

L'esempio carica un workbook Excel esistente e seleziona le prime 10 righe e le prime 13 colonne del suo primo foglio di lavoro utilizzando indici basati su zero. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) definisce l'intervallo visualizzato e l'helper sottostante scala tale intervallo per adattarlo a un frame largo 400 punti e alto 100 punti. Dopo aver salvato il workbook modificato in uno stream, [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) lo incorpora nella dimensione specificata. Un'anteprima renderizzata a 96 DPI è assegnata tramite [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/), così la presentazione salvata visualizza le celle selezionate invece del segnaposto predefinito.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Imposta la dimensione visualizzata quando il file workbook è usato come oggetto OLE in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Scala l'intervallo di celle per adattarlo alla dimensione del frame.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// È necessario utilizzare il workbook modificato.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Aggiungi l'immagine OLE alle risorse della presentazione.
var oleImage = presentation.Images.AddImage(imageStream);

// Crea il frame dell'oggetto OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

L'helper di scalatura calcola rapporti di larghezza e altezza separati per l'intervallo selezionato, preservando le larghezze relative delle colonne e le altezze relative delle righe. Converte le dimensioni calcolate da punti a pollici prima di applicarle con [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) e [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/). L'intervallo selezionato deve avere larghezza e altezza diverse da zero.

```cs
/// <param name="width">La larghezza prevista dell'intervallo di celle in punti.</param>
/// <param name="height">L'altezza prevista dell'intervallo di celle in punti.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

L'helper di anteprima rende l'intervallo ridimensionato utilizzando [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). Limita [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) a quell'intervallo, rimuove i margini, le intestazioni e i piè di pagina, e restituisce uno stream PNG posizionato all'inizio.

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **Conclusione**

{{% alert color="info" title="Note" %}}

Esistono due approcci per risolvere il problema di ridimensionamento del foglio di lavoro. Scegli l'approccio che meglio si adatta alle tue esigenze e al caso d'uso. Entrambi gli approcci funzionano allo stesso modo, sia che le presentazioni siano create da un modello sia da zero. Inoltre, non vi è alcun limite alla dimensione del frame dell'oggetto OLE in questa soluzione.

{{% /alert %}}

## **FAQ**

**Perché un foglio di lavoro Excel incorporato cambia dimensione quando viene attivato per la prima volta in PowerPoint?**

Questo accade perché Excel cerca di mantenere la dimensione originale della finestra quando viene attivato, mentre il frame dell'oggetto OLE in PowerPoint ha le proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere le proporzioni, il che può causare il ridimensionamento.

**È possibile evitare completamente questo problema di ridimensionamento?**

Sì. Ridimensionando il frame OLE per adattarlo alla dimensione dell'intervallo di celle Excel o scalando l'intervallo di celle per adattarlo alla dimensione desiderata del frame OLE, è possibile evitare il ridimensionamento indesiderato.

**Quale metodo di scalatura devo usare, la scalatura del frame OLE o la scalatura dell'intervallo di celle?**

Seleziona **scalatura del frame OLE** se desideri mantenere le dimensioni originali delle righe e delle colonne di Excel. Seleziona **scalatura dell'intervallo di celle** se vuoi una dimensione fissa per il frame OLE nella tua presentazione.

**Queste soluzioni funzioneranno se la mia presentazione è basata su un modello?**

Sì. Entrambe le soluzioni funzionano per le presentazioni create da modelli e da zero.

**Esiste un limite alla dimensione del frame OLE quando si usano questi metodi?**

No. È possibile impostare il frame dell'oggetto OLE a qualsiasi dimensione, purché la scala sia impostata correttamente.

**È possibile evitare il testo segnaposto "EMBEDDED OLE OBJECT" in PowerPoint?**

Sì. Catturando un'immagine dell'intervallo di celle Excel di destinazione e impostandola come immagine segnaposto del frame OLE, è possibile visualizzare un'immagine di anteprima personalizzata al posto del segnaposto predefinito.

## **Articoli correlati**

[Creare un grafico Excel e incorporarlo in una presentazione come oggetto OLE](/slides/it/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Aggiornare gli oggetti OLE automaticamente utilizzando un componente aggiuntivo MS PowerPoint](/slides/it/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)