---
title: Soluzione funzionante per il ridimensionamento del foglio di lavoro
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
description: "Correggi il ridimensionamento OLE del foglio di lavoro Excel nelle presentazioni: due modi per mantenere i frame degli oggetti coerenti — scala il frame o il foglio — nei formati PPT e PPTX."
---
{{% alert color="info" %}} 

È stato osservato che i fogli di lavoro Excel incorporati come oggetti OLE in una presentazione PowerPoint tramite i componenti Aspose vengono ridimensionati a una scala non identificata dopo la prima attivazione. Questo comportamento crea una differenza visiva evidente nella presentazione tra gli stati pre‑ e post‑attivazione dell’oggetto OLE. Abbiamo analizzato il problema in dettaglio e fornito una soluzione, descritta in questo articolo.

{{% /alert %}} 

## **Background**

Nell'articolo [Manage OLE](/slides/it/net/manage-ole/), abbiamo spiegato come aggiungere un frame OLE a una presentazione PowerPoint utilizzando Aspose.Slides per .NET. Per risolvere il [problema dell'anteprima dell'oggetto](/slides/it/net/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato un'immagine dell'area del foglio di lavoro selezionata al frame dell'oggetto OLE. Nella presentazione di output, quando si fa doppio clic sul frame OLE che mostra l'immagine del foglio di lavoro, la cartella di lavoro Excel viene attivata. Gli utenti finali possono apportare tutte le modifiche desiderate alla reale cartella di lavoro Excel e poi tornare alla diapositiva facendo clic al di fuori della cartella di lavoro Excel attivata. La dimensione del frame OLE cambierà quando l'utente tornerà alla diapositiva. Il fattore di ridimensionamento varierà in base alle dimensioni del frame OLE e della cartella di lavoro Excel incorporata. 

## **Cause of Resizing**

Poiché la cartella di lavoro Excel ha una sua dimensione della finestra, tenta di mantenere la sua dimensione originale al primo avvio. D'altra parte, il frame dell'oggetto OLE ha una sua dimensione. Secondo Microsoft, quando la cartella di lavoro Excel viene attivata, Excel e PowerPoint negoziano la dimensione per garantire che mantenga le proporzioni corrette come parte del processo di incorporamento. Il ridimensionamento avviene in base alle differenze tra la dimensione della finestra di Excel e la dimensione e posizione del frame OLE. 

## **Working Solution**

Esistono due soluzioni possibili per evitare l'effetto di ridimensionamento.

- Ridimensionare la dimensione del frame OLE nella presentazione PowerPoint per corrispondere all'altezza e alla larghezza del numero desiderato di righe e colonne nel frame OLE.  
- Mantenere la dimensione del frame OLE costante e ridimensionare la dimensione delle righe e colonne partecipanti per adattarle alla dimensione del frame OLE selezionato.  

### **Scale the OLE Frame Size**

In questo approccio, impareremo come impostare la dimensione del frame OLE della cartella di lavoro Excel incorporata per corrispondere alla dimensione cumulativa delle righe e colonne partecipanti nel foglio di lavoro Excel.

Supponiamo di avere un foglio Excel modello e di volerlo aggiungere a una presentazione come frame OLE. In questo scenario, la dimensione del frame oggetto OLE verrà prima calcolata in base all'altezza cumulativa delle righe e alla larghezza cumulativa delle colonne delle righe e colonne partecipanti nella cartella di lavoro. Poi, imposteremo la dimensione del frame OLE su questo valore calcolato. Per evitare il messaggio rosso "EMBEDDED OLE OBJECT" per il frame OLE in PowerPoint, cattureremo anche un'immagine delle porzioni desiderate delle righe e colonne nella cartella di lavoro e la imposteremo come immagine del frame OLE.

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

// Imposta la dimensione visualizzata quando il file della cartella di lavoro è usato come oggetto OLE in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Ottieni la larghezza e l'altezza dell'immagine OLE in punti.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// È necessario utilizzare la cartella di lavoro modificata.
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

### **Scale the Cell Range Size**

In questo approccio, impareremo come ridimensionare le altezze delle righe partecipanti e la larghezza delle colonne partecipanti per corrispondere a una dimensione personalizzata del frame OLE.

Supponiamo di avere un foglio Excel modello e di volerlo aggiungere a una presentazione come frame OLE. In questo scenario, imposteremo la dimensione del frame OLE e ridimensioneremo la dimensione delle righe e colonne che partecipano all'area del frame OLE. Salveremo quindi la cartella di lavoro in uno stream per applicare le modifiche e la convertirà in un array di byte per aggiungerla al frame OLE. Per evitare il messaggio rosso "EMBEDDED OLE OBJECT" per il frame OLE in PowerPoint, cattureremo anche un'immagine delle porzioni desiderate delle righe e colonne nella cartella di lavoro e la useremo come immagine del frame OLE.

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

// Imposta la dimensione visualizzata quando il file della cartella di lavoro è usato come oggetto OLE in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Scala l'intervallo di celle per adattarlo alle dimensioni del frame.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// È necessario utilizzare la cartella di lavoro modificata.
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

## **Conclusion**

{{% alert color="info" %}}

Esistono due approcci per risolvere il problema di ridimensionamento del foglio di lavoro. La scelta dell'approccio appropriato dipende dai requisiti specifici e dal caso d'uso. Entrambi gli approcci funzionano allo stesso modo, sia che le presentazioni siano create da un modello sia da zero. Inoltre, non vi è alcun limite alla dimensione del frame dell'oggetto OLE in questa soluzione.

{{% /alert %}}

## **FAQ**

### Why does an embedded Excel worksheet change size when first activated in PowerPoint?
Questo accade perché Excel cerca di mantenere la dimensione originale della finestra quando viene attivato, mentre il frame dell'oggetto OLE in PowerPoint ha proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere le proporzioni, il che può causare il ridimensionamento.

### Is it possible to prevent this resizing issue entirely?
Sì. Ridimensionando il frame OLE per adattarlo alla dimensione dell'intervallo di celle Excel o ridimensionando l'intervallo di celle per adattarlo alla dimensione desiderata del frame OLE, è possibile evitare il ridimensionamento indesiderato.

### Which scaling method should I use, OLE frame scaling or cell range scaling?
Seleziona **OLE frame scaling** se desideri mantenere le dimensioni originali delle righe e colonne di Excel. Seleziona **cell range scaling** se vuoi una dimensione fissa per il frame OLE nella tua presentazione.

### Will these solutions work if my presentation is based on a template?
Sì. Entrambe le soluzioni funzionano per presentazioni create da modelli e da zero.

### Is there a limit to the size of the OLE frame when using these methods?
No. È possibile impostare il frame dell'oggetto OLE a qualsiasi dimensione, purché la scala sia impostata correttamente.

### Is there a way to avoid the "EMBEDDED OLE OBJECT" placeholder text in PowerPoint?
Sì. Catturando un'istantanea dell'intervallo di celle Excel di destinazione e impostandola come immagine segnaposto del frame OLE, è possibile visualizzare un'immagine di anteprima personalizzata al posto del segnaposto predefinito.

## **Related Articles**

[Creare un grafico Excel e incorporarlo in una presentazione come oggetto OLE](/slides/it/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Aggiornare gli oggetti OLE automaticamente usando un componente aggiuntivo MS PowerPoint](/slides/it/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)