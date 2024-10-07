---
title: Erstellen und Einfügen eines Excel-Diagramms als OLE-Objekt in eine Microsoft PowerPoint-Folie
type: docs
weight: 70
url: /net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 Diagramme sind visuelle Darstellungen Ihrer Daten und werden häufig in Präsentationsfolien verwendet. Dieser Artikel zeigt Ihnen den Code zum Erstellen und Einfügen eines Excel-Diagramms als OLE-Objekt in die PowerPoint-Folie programmgesteuert mit [VSTO](/slides/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) und [Aspose.Slides für .NET](/slides/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Erstellen und Einfügen eines Excel-Diagramms**
Die beiden folgenden Codebeispiele sind lang und detailliert, da die Aufgabe, die sie beschreiben, komplex ist. Sie erstellen eine Microsoft Excel-Arbeitsmappe, erstellen ein Diagramm und erstellen dann die Microsoft PowerPoint-Präsentation, in die Sie das Diagramm einfügen. OLE-Objekte enthalten Links zum ursprünglichen Dokument, sodass ein Benutzer, der auf die eingebettete Datei doppelklickt, die Datei und deren Anwendung öffnet.
## **VSTO-Beispiel**
Mit VSTO werden folgende Schritte ausgeführt:

1. Erstellen Sie eine Instanz des Microsoft Excel ApplicationClass-Objekts.
1. Erstellen Sie eine neue Arbeitsmappe mit einem Arbeitsblatt.
1. Fügen Sie das Diagramm in das Arbeitsblatt ein.
1. Speichern Sie die Arbeitsmappe.
1. Öffnen Sie die Excel-Arbeitsmappe mit den Diagrammdaten.
1. Holen Sie sich die ChartObjects-Sammlung für das Arbeitsblatt.
1. Holen Sie sich das zu kopierende Diagramm.
1. Erstellen Sie eine Microsoft PowerPoint-Präsentation.
1. Fügen Sie der Präsentation eine leere Folie hinzu.
1. Kopieren Sie das Diagramm aus dem Excel-Arbeitsblatt in die Zwischenablage.
1. Fügen Sie das Diagramm in die PowerPoint-Präsentation ein.
1. Positionieren Sie das Diagramm auf der Folie.
1. Speichern Sie die Präsentation.

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
    // Deklarieren Sie eine Variable für die Instanz der Excel ApplicationClass.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Deklarieren Sie Variablen für die Parameter der Workbooks.Open-Methode.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Deklarieren Sie Variablen für die Chart.ChartWizard-Methode.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Verkäufe nach Quartal";
    object paramCategoryTitle = "Geschäftsquartal";
    object paramValueTitle = "Milliarden";

    try
    {
        // Erstellen Sie eine Instanz des Excel ApplicationClass-Objekts.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Erstellen Sie eine neue Arbeitsmappe mit 1 Arbeitsblatt.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Ändern Sie den Namen des Arbeitsblatts.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quartalsverkäufe";

        // Fügen Sie einige Daten für das Diagramm in das Arbeitsblatt ein.
        //              A       B       C       D       E
        //     1                Q1      Q2      Q3      Q4
        //     2    N. Amerika  1.5     2       1.5     2.5
        //     3    S. Amerika  2       1.75    2       2
        //     4    Europa      2.25    2       2.5     2
        //     5    Asien       2.5     2.5     2       2.75

        SetCellValue(targetSheet, "A2", "N. Amerika");
        SetCellValue(targetSheet, "A3", "S. Amerika");
        SetCellValue(targetSheet, "A4", "Europa");
        SetCellValue(targetSheet, "A5", "Asien");

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

        // Holen Sie sich den Bereich, der die Diagrammdaten enthält.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Holen Sie sich die ChartObjects-Sammlung für das Arbeitsblatt.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Fügen Sie ein Diagramm zur Sammlung hinzu.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Verkaufsdiagramm";

        // Erstellen Sie ein neues Diagramm mit den Daten.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Speichern Sie die Arbeitsmappe.
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
            // Schließen Sie Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Deklarieren Sie Variablen, um Referenzen auf PowerPoint-Objekte zu halten.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Deklarieren Sie Variablen, um Referenzen auf Excel-Objekte zu halten.
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
        // Erstellen Sie eine Instanz von PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Erstellen Sie eine Instanz von Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Öffnen Sie die Excel-Arbeitsmappe mit den Diagrammdaten.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Holen Sie sich das Arbeitsblatt, das das Diagramm enthält.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quartalsverkäufe"]);

        // Holen Sie sich die ChartObjects-Sammlung für das Arbeitsblatt.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Holen Sie sich das zu kopierende Diagramm.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Verkaufsdiagramm"));

        // Erstellen Sie eine PowerPoint-Präsentation.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Fügen Sie der Präsentation eine leere Folie hinzu.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Kopieren Sie das Diagramm aus dem Excel-Arbeitsblatt in die Zwischenablage.
        existingChartObject.Copy();

        // Fügen Sie das Diagramm in die PowerPoint-Präsentation ein.
        shapeRange = pptSlide.Shapes.Paste();

        // Positionieren Sie das Diagramm auf der Folie.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Speichern Sie die Präsentation.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Geben Sie das PowerPoint-Folienobjekt frei.
        shapeRange = null;
        pptSlide = null;

        // Schließen und geben Sie das Präsentationsobjekt frei.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Beenden Sie PowerPoint und geben Sie das ApplicationClass-Objekt frei.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Geben Sie die Excel-Objekte frei.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Schließen und geben Sie das Excel-Arbeitsmappenobjekt frei.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Beenden Sie Excel und geben Sie das ApplicationClass-Objekt frei.
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




## **Aspose.Slides für .NET Beispiel**
Mit Aspose.Slides für .NET werden folgende Schritte ausgeführt:

1. Erstellen Sie eine Arbeitsmappe mit Aspose.Cells für .NET.
1. Erstellen Sie ein Microsoft Excel-Diagramm.
1. Setzen Sie die OLE-Größe des Excel-Diagramms.
1. Holen Sie sich ein Bild des Diagramms.
1. Fügen Sie das Excel-Diagramm als OLE-Objekt in die PPTX-Präsentation ein, indem Sie Aspose.Slides für .NET verwenden.
1. Ersetzen Sie das Bild des geänderten Objekts durch das in Schritt 3 erhaltene Bild, um das Problem des geänderten Objekts zu beheben.
1. Schreiben Sie die Ausgabepräsentation im PPTX-Format auf die Festplatte.



```c#
//Schritt - 1: Erstellen Sie ein Excel-Diagramm mit Aspose.Cells
//--------------------------------------------------
//Erstellen Sie eine Arbeitsmappe
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Fügen Sie ein Excel-Diagramm hinzu
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Schritt - 2: Setzen Sie die OLE-Größe des Diagramms. mit Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Schritt - 3: Holen Sie sich das Bild des Diagramms mit Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Speichern Sie die Arbeitsmappe im Stream
MemoryStream wbStream = wb.SaveToStream();
//Schritt - 4  UND 5
//-----------------------------------------------------------
//Schritt - 4: Fügen Sie das Diagramm als OLE-Objekt in die .ppt-Präsentation mit Aspose.Slides ein
//-----------------------------------------------------------
//Schritt - 5: Ersetzen Sie das Bild des geänderten Objekts durch das in Schritt 3 erhaltene Bild, um das Problem des geänderten Objekts zu beheben
//-----------------------------------------------------------
//Erstellen Sie eine Präsentation
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Fügen Sie die Arbeitsmappe auf der Folie hinzu
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Schritt - 6: Schreiben Sie die Ausgabepräsentation auf die Festplatte
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
    //Array von Zellnamen
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Array von Zellwerten
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Fügen Sie ein neues Arbeitsblatt hinzu, um die Zellen mit Daten zu füllen
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "Datenblatt";
    dataSheet.Name = sheetName;
    //Populieren Sie das Datenblatt mit Daten
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Fügen Sie ein Diagrammblatt hinzu
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "Diagrammblatt";
    //Fügen Sie ein Diagramm im Diagrammblatt mit Datenserien aus dem Datenblatt hinzu
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Setzen Sie das Diagrammblatt als aktives Blatt
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```