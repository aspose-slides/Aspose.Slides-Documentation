---
title: Crea e incorpora grafici Excel come oggetti OLE usando VSTO e Aspose.Slides per .NET
linktitle: Crea e incorpora grafici Excel come oggetti OLE
type: docs
weight: 70
url: /it/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- crea grafico
- incorpora grafico Excel
- oggetto OLE
- migrazione
- VSTO
- automazione Office
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Migra dall'automazione Microsoft Office ad Aspose.Slides per .NET e incorpora grafici Excel come oggetti OLE nelle diapositive PowerPoint (PPT, PPTX) in C#."
---
{{% alert color="primary" %}} 

I grafici sono rappresentazioni visive dei tuoi dati e sono ampiamente usati nelle diapositive di presentazione. Questo articolo ti mostrerà il codice per creare e incorporare un grafico Excel come oggetto OLE in una diapositiva PowerPoint in modo programmatico, utilizzando [VSTO](/slides/it/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) e [Aspose.Slides for .NET](/slides/it/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Creare e incorporare un grafico Excel**
I due esempi di codice qui sotto sono lunghi e dettagliati perché il compito che descrivono è complesso. Crei una cartella di lavoro Microsoft Excel, crei un grafico e poi crei la presentazione Microsoft PowerPoint nella quale incorporerai il grafico. Gli oggetti OLE contengono collegamenti al documento originale, quindi un utente che fa doppio clic sul file incorporato avvierà il file e la sua applicazione.
## **Esempio VSTO**
Utilizzando VSTO, vengono eseguiti i seguenti passaggi:

1. Creare un'istanza dell'oggetto Microsoft Excel ApplicationClass.
1. Creare una nuova cartella di lavoro con un foglio.
1. Aggiungere un grafico al foglio.
1. Salvare la cartella di lavoro.
1. Aprire la cartella di lavoro Excel contenente il foglio di lavoro con i dati del grafico.
1. Ottenere la raccolta ChartObjects per il foglio.
1. Ottenere il grafico da copiare.
1. Creare una presentazione Microsoft PowerPoint.
1. Aggiungere una diapositiva vuota alla presentazione.
1. Copiare il grafico dal foglio di lavoro Excel negli appunti.
1. Incollare il grafico nella presentazione PowerPoint.
1. Posizionare il grafico sulla diapositiva.
1. Salvare la presentazione.

```c#
CreateNewChartInExcel();
UseCopyPaste();
```

```c#
static void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)
{
    targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);
}
```

```c#
static void CreateNewChartInExcel()
{
        // Dichiarare una variabile per l'istanza di Excel ApplicationClass.
        Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

        // Dichiarare variabili per i parametri del metodo Workbooks.Open.
        string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
        object paramMissing = Type.Missing;

        // Dichiarare variabili per il metodo Chart.ChartWizard.
        object paramChartFormat = 1;
        object paramCategoryLabels = 0;
        object paramSeriesLabels = 0;
        bool paramHasLegend = true;
        object paramTitle = "Sales by Quarter";
        object paramCategoryTitle = "Fiscal Quarter";
        object paramValueTitle = "Billions";

        try
        {
                // Creare un'istanza dell'oggetto Excel ApplicationClass.
                excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

                // Creare una nuova cartella di lavoro con 1 foglio.
                xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

                // Modificare il nome del foglio.
                xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
                targetSheet.Name = "Quarterly Sales";

                // Inserire alcuni dati per il grafico nel foglio.
                //              A       B       C       D       E
                //     1                Q1      Q2      Q3      Q4
                //     2    N. America  1.5     2       1.5     2.5
                //     3    S. America  2       1.75    2       2
                //     4    Europe      2.25    2       2.5     2
                //     5    Asia        2.5     2.5     2       2.75

                SetCellValue(targetSheet, "A2", "N. America");
                SetCellValue(targetSheet, "A3", "S. America");
                SetCellValue(targetSheet, "A4", "Europe");
                SetCellValue(targetSheet, "A5", "Asia");

                SetCellValue(targetSheet, "B1", "Q1");
                SetCellValue(targetSheet, "B2", 1.5);
                SetCellValue(targetSheet, "B3", 2);
                SetCellValue(targetSheet, "B4", 2.25);
                SetCellValue(targetSheet, "B5", 2.5);

                SetCellValue(targetSheet, "C1", "Q2");
                SetCellValue(targetSheet, "C2", 2);
                SetCellValue(targetSheet, "C3", 1.75);
                SetCellValue(targetSheet, "C4", 2);
                SetCellValue(targetSheet, "C5", 2.5);

                SetCellValue(targetSheet, "D1", "Q3");
                SetCellValue(targetSheet, "D2", 1.5);
                SetCellValue(targetSheet, "D3", 2);
                SetCellValue(targetSheet, "D4", 2.5);
                SetCellValue(targetSheet, "D5", 2);

                SetCellValue(targetSheet, "E1", "Q4");
                SetCellValue(targetSheet, "E2", 2.5);
                SetCellValue(targetSheet, "E3", 2);
                SetCellValue(targetSheet, "E4", 2);
                SetCellValue(targetSheet, "E5", 2.75);

                // Ottenere l'intervallo che contiene i dati del grafico.
                xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

                // Ottenere la raccolta ChartObjects per il foglio.
                xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

                // Aggiungere un grafico alla raccolta.
                xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
                newChartObject.Name = "Sales Chart";

                // Creare un nuovo grafico dai dati.
                newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
                    paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

                // Salvare la cartella di lavoro.
                newWorkbook.SaveAs(paramWorkbookPath, paramMissing, paramMissing, paramMissing, paramMissing,
                    paramMissing, xlNS.XlSaveAsAccessMode.xlNoChange, paramMissing, paramMissing, paramMissing, paramMissing, paramMissing);
        }
        catch (Exception ex)
        {
                Console.WriteLine(ex.Message);
        }
        finally
        {
                if (excelApplication != null)
                {
                        // Chiudere Excel.
                        excelApplication.Quit();
                }
        }
}
```

```c#
static void UseCopyPaste()
{
    // Dichiarare variabili per contenere riferimenti agli oggetti PowerPoint.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Dichiarare variabili per contenere riferimenti agli oggetti Excel.
    xlNS.ApplicationClass excelApplication = null;
    xlNS.Workbook excelWorkBook = null;
    xlNS.Worksheet targetSheet = null;
    xlNS.ChartObjects chartObjects = null;
    xlNS.ChartObject existingChartObject = null;

    string paramPresentationPath = Application.StartupPath + @"\ChartTest.pptx";
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    try
    {
        // Creare un'istanza di PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Creare un'istanza di Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Aprire la cartella di lavoro Excel contenente il foglio di lavoro con i dati del grafico.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Ottenere il foglio di lavoro che contiene il grafico.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Ottenere la collezione ChartObjects per il foglio.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Ottenere il grafico da copiare.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // Creare una presentazione PowerPoint.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Aggiungere una diapositiva vuota alla presentazione.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Copiare il grafico dal foglio di lavoro Excel negli appunti.
        existingChartObject.Copy();

        // Incollare il grafico nella presentazione PowerPoint.
        shapeRange = pptSlide.Shapes.Paste();

        // Posizionare il grafico sulla diapositiva.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Salvare la presentazione.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Rilasciare l'oggetto diapositiva PowerPoint.
        shapeRange = null;
        pptSlide = null;

        // Chiudere e rilasciare l'oggetto Presentation.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Chiudere PowerPoint e rilasciare l'oggetto ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Rilasciare gli oggetti Excel.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Chiudere e rilasciare l'oggetto Workbook di Excel.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Chiudere Excel e rilasciare l'oggetto ApplicationClass.
        if (excelApplication != null)
        {
            excelApplication.Quit();
            excelApplication = null;
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
```




## **Esempio Aspose.Slides per .NET**
Utilizzando Aspose.Slides per .NET, vengono eseguiti i seguenti passaggi:

1. Creare una cartella di lavoro usando Aspose.Cells per .NET.
1. Creare un grafico Microsoft Excel.
1. Impostare la dimensione OLE del grafico Excel.
1. Ottenere un'immagine del grafico.
1. Incorporare il grafico Excel come oggetto OLE all'interno di una presentazione PPTX usando Aspose.Slides per .NET.
1. Sostituire l'immagine dell'oggetto modificato con l'immagine ottenuta al punto 3 per gestire il problema dell'oggetto modificato.
1. Scrivere la presentazione di output su disco in formato PPTX.



```c#
//Passo - 1: Crea un grafico Excel usando Aspose.Cells
//--------------------------------------------------
//Crea una cartella di lavoro
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Aggiungi un grafico Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Passo - 2: Imposta la dimensione OLE del grafico usando Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Passo - 3: Ottieni l'immagine del grafico con Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Salva la cartella di lavoro nello stream
MemoryStream wbStream = wb.SaveToStream();
//Passo - 4 e 5
//-----------------------------------------------------------
//Passo - 4: Incorpora il grafico come oggetto OLE nella presentazione .ppt usando Aspose.Slides
//-----------------------------------------------------------
//Passo - 5: Sostituisci l'immagine dell'oggetto modificato con l'immagine ottenuta al passo 3 per gestire il problema dell'oggetto modificato
//-----------------------------------------------------------
//Crea una presentazione
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Aggiungi la cartella di lavoro alla diapositiva
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Passo - 6: Scrivi la presentazione di output su disco
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] chartOleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(chartOleData, 0, chartOleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	imageStream.Position = 0;
        IPPImage image = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = image;
    }
}
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
{
    //Array di nomi di celle
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Array di dati delle celle
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Aggiungi un nuovo foglio di lavoro per popolare le celle con i dati
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Popola DataSheet con i dati
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Aggiungi un foglio di grafico
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Aggiungi un grafico in ChartSheet con le serie di dati da DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Imposta ChartSheet come foglio attivo
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```