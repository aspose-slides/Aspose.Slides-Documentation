---
title: Excel-Diagramme als OLE-Objekte mit VSTO und Aspose.Slides für .NET erstellen und einbetten
linktitle: Excel-Diagramme als OLE-Objekte erstellen und einbetten
type: docs
weight: 70
url: /de/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- Diagramm erstellen
- Excel-Diagramm einbetten
- OLE-Objekt
- Migration
- VSTO
- Office-Automatisierung
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Von der Microsoft Office-Automatisierung zu Aspose.Slides für .NET migrieren und Excel-Diagramme als OLE-Objekte in PowerPoint‑Folien (PPT, PPTX) in C# einbetten."
---

{{% alert color="primary" %}} 

Diagramme sind visuelle Darstellungen Ihrer Daten und werden häufig in Präsentationsfolien verwendet. In diesem Artikel wird Ihnen der Code gezeigt, um ein Excel-Diagramm programmgesteuert als OLE-Objekt in eine PowerPoint‑Folien einzufügen, indem Sie [VSTO](/slides/de/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) und [Aspose.Slides for .NET](/slides/de/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) verwenden.

{{% /alert %}} 
## **Erstellen und Einbetten eines Excel-Diagramms**
Die beiden Codebeispiele unten sind lang und detailliert, weil die beschriebene Aufgabe komplex ist. Sie erstellen eine Microsoft Excel-Arbeitsmappe, erstellen ein Diagramm und dann die Microsoft PowerPoint-Präsentation, in die Sie das Diagramm einbetten. OLE‑Objekte enthalten Verknüpfungen zum Originaldokument, sodass ein Benutzer, der die eingebettete Datei doppelklickt, die Datei und deren Anwendung startet.
## **VSTO‑Beispiel**
Mit VSTO werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Instanz des Microsoft Excel ApplicationClass‑Objekts.
1. Erstellen Sie eine neue Arbeitsmappe mit einem Arbeitsblatt.
1. Fügen Sie dem Arbeitsblatt ein Diagramm hinzu.
1. Speichern Sie die Arbeitsmappe.
1. Öffnen Sie die Excel‑Arbeitsmappe, die das Arbeitsblatt mit den Diagrammdaten enthält.
1. Rufen Sie die ChartObjects‑Sammlung für das Arbeitsblatt ab.
1. Holen Sie das zu kopierende Diagramm.
1. Erstellen Sie eine Microsoft PowerPoint‑Präsentation.
1. Fügen Sie der Präsentation eine leere Folie hinzu.
1. Kopieren Sie das Diagramm vom Excel‑Arbeitsblatt in die Zwischenablage.
1. Fügen Sie das Diagramm in die PowerPoint‑Präsentation ein.
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
    // Deklariere eine Variable für die Excel ApplicationClass-Instanz.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Deklariere Variablen für die Parameter der Workbooks.Open-Methode.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Deklariere Variablen für die Chart.ChartWizard-Methode.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Erstelle eine Instanz des Excel ApplicationClass-Objekts.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Erstelle eine neue Arbeitsmappe mit 1 Blatt.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Ändere den Namen des Blattes.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // Füge einige Daten für das Diagramm in das Blatt ein.
        //              A       B       C       D       E
        //     1                Q1      Q2      Q3      Q4
        //     2    Nordamerika  1.5     2       1.5     2.5
        //     3    Südamerika    2       1.75    2       2
        //     4    Europa        2.25    2       2.5     2
        //     5    Asien         2.5     2.5     2       2.75

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

        // Erhalte den Bereich, der die Diagrammdaten enthält.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Erhalte die ChartObjects-Sammlung für das Blatt.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Füge ein Diagramm zur Sammlung hinzu.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // Erstelle ein neues Diagramm aus den Daten.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Speichere die Arbeitsmappe.
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
            // Schließe Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Deklariere Variablen, um Referenzen auf PowerPoint-Objekte zu halten.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Deklariere Variablen, um Referenzen auf Excel-Objekte zu halten.
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
        // Erstelle eine Instanz von PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Erstelle eine Instanz von Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Öffne die Excel-Arbeitsmappe, die das Arbeitsblatt mit den Diagrammdaten enthält.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Hole das Arbeitsblatt, das das Diagramm enthält.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Hole die ChartObjects‑Sammlung für das Blatt.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Hole das Diagramm zum Kopieren.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // Erstelle eine PowerPoint‑Präsentation.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Füge eine leere Folie zur Präsentation hinzu.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Kopiere das Diagramm vom Excel‑Arbeitsblatt in die Zwischenablage.
        existingChartObject.Copy();

        // Füge das Diagramm in die PowerPoint‑Präsentation ein.
        shapeRange = pptSlide.Shapes.Paste();

        // Positioniere das Diagramm auf der Folie.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Speichere die Präsentation.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Freigeben des PowerPoint-Folienobjekts.
        shapeRange = null;
        pptSlide = null;

        // Schließe und gib das Präsentationsobjekt frei.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Beende PowerPoint und gib das ApplicationClass‑Objekt frei.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Freigeben der Excel-Objekte.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Schließe und gib das Excel‑Workbook‑Objekt frei.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Beende Excel und gib das ApplicationClass‑Objekt frei.
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





## **Aspose.Slides für .NET‑Beispiel**
Mit Aspose.Slides für .NET werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Arbeitsmappe mit Aspose.Cells für .NET.
1. Erstellen Sie ein Microsoft Excel‑Diagramm.
1. Legen Sie die OLE‑Größe des Excel‑Diagramms fest.
1. Erzeugen Sie ein Bild des Diagramms.
1. Betten Sie das Excel‑Diagramm als OLE‑Objekt in eine PPTX‑Präsentation ein, wobei Sie Aspose.Slides für .NET verwenden.
1. Ersetzen Sie das Bild des geänderten Objekts durch das in Schritt 3 erhaltene Bild, um das Problem des geänderten Objekts zu beheben.
1. Schreiben Sie die Ausgabepäsentation im PPTX‑Format auf die Festplatte.
```c#
//Schritt - 1: Erstelle ein Excel-Diagramm mit Aspose.Cells
//--------------------------------------------------
//Erstelle eine Arbeitsmappe
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Füge ein Excel-Diagramm hinzu
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Schritt - 2: Setze die OLE-Größe des Diagramms. mit Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Schritt - 3: Hole das Bild des Diagramms mit Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Speichere die Arbeitsmappe in einen Stream
MemoryStream wbStream = wb.SaveToStream();
//Schritt - 4  UND 5
//-----------------------------------------------------------
//Schritt - 4: Betten Sie das Diagramm als OLE-Objekt in eine .ppt-Präsentation ein mit Aspose.Slides
//-----------------------------------------------------------
//Schritt - 5: Ersetzen Sie das Bild des geänderten Objekts durch das in Schritt 3 erhaltene Bild, um das Problem „Object Changed“ zu beheben
//-----------------------------------------------------------
//Erstelle eine Präsentation
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Füge die Arbeitsmappe auf der Folie hinzu
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Schritt - 6: Schreibe die Ausgabepäsentation auf die Festplatte
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
    //Ein neues Arbeitsblatt hinzufügen, um Zellen mit Daten zu füllen
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Datenblatt mit Daten füllen
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Ein Diagrammblatt hinzufügen
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Ein Diagramm im Diagrammblatt hinzufügen, basierend auf Datenreihen aus dem Datenblatt
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Diagrammblatt als aktives Blatt festlegen
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```
