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
{{% alert color="primary" %}} 

È stato osservato che i fogli di lavoro Excel incorporati come oggetti OLE in una presentazione PowerPoint tramite componenti Aspose vengono ridimensionati a una scala non identificata dopo la prima attivazione. Questo comportamento crea una differenza visiva evidente nella presentazione tra gli stati pre‑ e post‑attivazione dell'oggetto OLE. Abbiamo esaminato questo problema in dettaglio e fornito una soluzione, descritta in questo articolo.

{{% /alert %}} 

## **Contesto**

Nell'articolo [Manage OLE](/slides/it/net/manage-ole/), abbiamo spiegato come aggiungere un frame OLE a una presentazione PowerPoint utilizzando Aspose.Slides per .NET. Per risolvere il [object preview issue](/slides/it/net/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato un'immagine dell'area del foglio di lavoro selezionata al frame dell'oggetto OLE. Nella presentazione di output, quando si fa doppio clic sul frame OLE che visualizza l'immagine del foglio di lavoro, il cartellino Excel viene attivato. Gli utenti finali possono apportare le modifiche desiderate al vero foglio di lavoro Excel e poi tornare alla diapositiva facendo clic al di fuori del cartellino Excel attivato. La dimensione del frame OLE cambierà quando l'utente tornerà alla diapositiva. Il fattore di ridimensionamento varierà a seconda delle dimensioni del frame OLE e del foglio di lavoro Excel incorporato.

## **Causa del ridimensionamento**

Poiché il cartellino Excel ha una propria dimensione della finestra, tenta di mantenere la dimensione originale al primo avvio. D'altra parte, il frame OLE ha una sua dimensione. Secondo Microsoft, quando il cartellino Excel è attivato, Excel e PowerPoint negoziano la dimensione per garantire che mantenga le proporzioni corrette come parte del processo di incorporamento. Il ridimensionamento avviene in base alle differenze tra la dimensione della finestra di Excel e la dimensione e posizione del frame OLE.

## **Soluzione operativa**

Esistono due soluzioni possibili per evitare l'effetto di ridimensionamento.

- Scala la dimensione del frame OLE nella presentazione PowerPoint per corrispondere all'altezza e alla larghezza del numero desiderato di righe e colonne nel frame OLE.
- Mantieni la dimensione del frame OLE costante e scala la dimensione delle righe e colonne partecipanti per adattarla alla dimensione del frame OLE selezionato.

### **Scalare la dimensione del frame OLE**

In questo approccio, impareremo come impostare la dimensione del frame OLE del foglio di lavoro Excel incorporato per corrispondere alla dimensione cumulativa delle righe e colonne partecipanti nel foglio di calcolo Excel.

Supponiamo di avere un foglio Excel modello e di volerlo aggiungere a una presentazione come frame OLE. In questo scenario, la dimensione del frame OLE verrà prima calcolata in base alle altezze cumulative delle righe e alle larghezze cumulative delle colonne delle righe e colonne partecipanti nel cartellino. Successivamente, imposteremo la dimensione del frame OLE su questo valore calcolato. Per evitare il messaggio rosso "EMBEDDED OLE OBJECT" per il frame OLE in PowerPoint, cattureremo anche un'immagine delle porzioni desiderate delle righe e colonne nel cartellino e la imposteremo come immagine del frame OLE.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// We need to use the modified workbook.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Add the OLE image to the presentation resources.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
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

### **Scalare la dimensione dell'intervallo di celle**

In questo approccio, impareremo come scalare le altezze delle righe partecipanti e la larghezza delle colonne partecipanti per corrispondere a una dimensione personalizzata del frame OLE.

Supponiamo di avere un foglio Excel modello e di volerlo aggiungere a una presentazione come frame OLE. In questo scenario, imposteremo la dimensione del frame OLE e scaleremo la dimensione delle righe e colonne che partecipano all'area del frame OLE. Salveremo poi il cartellino in uno stream per applicare le modifiche e lo convertirà in un array di byte per aggiungerlo al frame OLE. Per evitare il messaggio rosso "EMBEDDED OLE OBJECT" per il frame OLE in PowerPoint, cattureremo anche un'immagine delle porzioni desiderate delle righe e colonne nel cartellino e la imposteremo come immagine del frame OLE.

```cs
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

// Scala l'intervallo di celle per adattarlo alla dimensione del frame.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// È necessario usare la cartella di lavoro modificata.
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

## **Conclusione**

{{% alert color="primary" %}}

Ci sono due approcci per risolvere il problema di ridimensionamento del foglio di lavoro. La scelta dell'approccio appropriato dipende dai requisiti specifici e dal caso d'uso. Entrambi gli approcci funzionano allo stesso modo, sia che le presentazioni siano create da un modello sia da zero. Inoltre, non vi è alcun limite alla dimensione del frame OLE in questa soluzione.

{{% /alert %}}

## **FAQ**

**Perché un foglio di lavoro Excel incorporato cambia dimensione alla prima attivazione in PowerPoint?**  
Questo accade perché Excel tenta di mantenere la dimensione originale della finestra quando è attivato, mentre il frame OLE in PowerPoint ha le proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere le proporzioni, il che può causare il ridimensionamento.

**È possibile prevenire completamente questo problema di ridimensionamento?**  
Sì. Scalando il frame OLE per adattarlo alla dimensione dell'intervallo di celle Excel o scalando l'intervallo di celle per adattarlo alla dimensione desiderata del frame OLE, è possibile evitare il ridimensionamento indesiderato.

**Quale metodo di scaling dovrei usare, lo scaling del frame OLE o lo scaling dell'intervallo di celle?**  
Seleziona **OLE frame scaling** se desideri mantenere le dimensioni originali delle righe e colonne di Excel. Seleziona **cell range scaling** se desideri una dimensione fissa per il frame OLE nella tua presentazione.

**Queste soluzioni funzioneranno se la mia presentazione è basata su un modello?**  
Sì. Entrambe le soluzioni funzionano per presentazioni create da modelli e da zero.

**C'è un limite alla dimensione del frame OLE quando si usano questi metodi?**  
No. Puoi impostare il frame OLE a qualsiasi dimensione, purché la scala sia impostata correttamente.

**Esiste un modo per evitare il testo segnaposto "EMBEDDED OLE OBJECT" in PowerPoint?**  
Sì. Catturando un'istantanea dell'intervallo di celle Excel target e impostandola come immagine segnaposto del frame OLE, è possibile visualizzare un'immagine di anteprima personalizzata al posto del segnaposto predefinito.

## **Articoli correlati**

[Creare un grafico Excel e incorporarlo in una presentazione come oggetto OLE](/slides/it/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Aggiornare gli oggetti OLE automaticamente usando un componente aggiuntivo MS PowerPoint](/slides/it/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)