---
title: Creare grafici Excel e incorporarli in presentazioni come oggetti OLE
type: docs
weight: 50
url: /it/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- grafico Excel
- incorporare grafico
- oggetto OLE
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Creare grafici Excel e incorporarli come oggetti OLE in presentazioni PowerPoint e OpenDocument con C#/.NET. Guida passo passo con esempi di codice."
---
## **Contesto**

In PowerPoint, l'uso di grafici modificabili per visualizzare i dati in modo grafico è una pratica comune. Aspose supporta la creazione di grafici Excel con Aspose.Cells per .NET, e questi grafici possono poi essere incorporati come oggetti OLE nelle diapositive PowerPoint tramite Aspose.Slides per .NET. Questo articolo descrive i passaggi necessari e fornisce esempi di codice C# per creare un grafico Excel e incorporarlo come oggetto OLE in una presentazione PowerPoint usando Aspose.Cells e Aspose.Slides.

## **Passaggi necessari**

La seguente sequenza di passaggi è necessaria per creare e incorporare un grafico Excel come oggetto OLE in una diapositiva PowerPoint:

1. Creare un grafico Excel utilizzando Aspose.Cells.
1. Impostare le dimensioni OLE del grafico Excel utilizzando Aspose.Cells.
1. Ottenere un'immagine del grafico Excel con Aspose.Cells.
1. Incorporare il grafico Excel come oggetto OLE in una presentazione PPTX utilizzando Aspose.Slides.
1. Sostituire l'immagine "EMBEDDED OLE OBJECT" con l'immagine ottenuta al passo 3 per risolvere il [problema di anteprima dell'oggetto](/slides/it/net/object-preview-issue-when-adding-oleobjectframe/).
1. Salvare la presentazione su disco in formato PPTX.

## **Implementazione dei passaggi necessari**

L'implementazione C# dei passaggi precedenti è la seguente:

```cs
// Passo - 1: Creare un grafico Excel utilizzando Aspose.Cells.
// ---------------------------------------------------
// Creare una cartella di lavoro.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Aggiungere un grafico Excel.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Passo - 2: Impostare le dimensioni OLE del grafico utilizzando Aspose.Cells.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// Passo - 3: Ottenere l'immagine del grafico con Aspose.Cells.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// Save the workbook to a stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Passo - 4 E 5
// ==============
// Passo - 4: Incorporare il grafico come oggetto OLE all'interno di una presentazione .ppt utilizzando Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Passo - 5: Sostituire l'immagine "EMBEDDED OLE OBJECT" con l'immagine ottenuta al passo 3 per risolvere il problema di anteprima dell'oggetto.
// --------------------------------------------------------------------------------------------------------------------
// Create a presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // Aggiungere la cartella di lavoro alla diapositiva.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // Passo - 6: Salvare la presentazione di output su disco.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // Un array di nomi di celle.
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Un array di dati delle celle.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Aggiungere un nuovo foglio di lavoro per popolare le celle con i dati.
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // Popolare il foglio dati con i dati.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // Aggiungere un foglio del grafico.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // Aggiungere un grafico al foglio del grafico con le serie dati dal foglio dati.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // Impostare il foglio del grafico come foglio attivo.
    workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
    return chartSheetIndex;
}
```

```cs
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] oleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(oleData, 0, oleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	    imageStream.Position = 0;
        IPPImage ppImage = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

La presentazione creata con il metodo sopra conterrà il grafico Excel come oggetto OLE, che può essere attivato facendo doppio clic sul frame dell'oggetto OLE.

## **Conclusione**

Utilizzando Aspose.Cells per .NET insieme ad Aspose.Slides per .NET, è possibile creare qualsiasi grafico Excel supportato da Aspose.Cells e incorporare il grafico come oggetto OLE in una diapositiva PowerPoint. Le dimensioni OLE del grafico Excel possono anche essere definite. Gli utenti finali possono quindi modificare il grafico Excel come qualsiasi altro oggetto OLE.

## **Sezioni correlate**

- [Soluzione funzionante per il ridimensionamento dei grafici in PPTX](/slides/it/net/working-solution-for-chart-resizing-in-pptx/)
- [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/net/object-preview-issue-when-adding-oleobjectframe/)
- [Aggiornamento automatico degli oggetti OLE utilizzando un componente aggiuntivo PowerPoint](/slides/it/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)