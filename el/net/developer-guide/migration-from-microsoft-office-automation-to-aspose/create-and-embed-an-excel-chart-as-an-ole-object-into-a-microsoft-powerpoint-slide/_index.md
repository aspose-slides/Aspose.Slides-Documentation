---
title: Δημιουργία και Ενσωμάτωση Διαγραμμάτων Excel ως Αντικείμενα OLE χρησιμοποιώντας VSTO και Aspose.Slides για .NET
linktitle: Δημιουργία και Ενσωμάτωση Διαγραμμάτων Excel ως Αντικείμενα OLE
type: docs
weight: 70
url: /el/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- δημιουργία διαγράμματος
- ενσωμάτωση διαγράμματος Excel
- αντικείμενο OLE
- μετάβαση
- VSTO
- αυτοματοποίηση Office
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μετάβαση από την αυτοματοποίηση Microsoft Office στο Aspose.Slides για .NET και ενσωμάτωση διαγραμμάτων Excel ως αντικείμενα OLE σε διαφάνειες PowerPoint (PPT, PPTX) σε C#."
---
{{% alert color="info" %}} 
Τα διαγράμματα είναι οπτικές αναπαραστάσεις των δεδομένων σας και χρησιμοποιούνται ευρέως σε διαφάνειες παρουσιάσεων. Αυτό το άρθρο θα σας δείξει τον κώδικα για τη δημιουργία και ενσωμάτωση ενός διαγράμματος Excel ως αντικειμένου OLE σε διαφάνεια PowerPoint προγραμματιστικά, χρησιμοποιώντας [VSTO](/slides/el/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) και [Aspose.Slides for .NET](/slides/el/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).
{{% /alert %}} 
## **Creating and Embedding an Excel Chart**
Τα δύο παραδείγματα κώδικα παρακάτω είναι μεγάλα και λεπτομερή επειδή η εργασία που περιγράφουν είναι πολύπλοκη. Δημιουργείτε ένα βιβλίο εργασίας Microsoft Excel, δημιουργείτε ένα διάγραμμα και στη συνέχεια δημιουργείτε την παρουσίαση Microsoft PowerPoint στην οποία θα ενσωματώσετε το διάγραμμα. Τα αντικείμενα OLE περιέχουν συνδέσμους προς το αρχικό έγγραφο, ώστε ένας χρήστης που κάνει διπλό κλικ στο ενσωματωμένο αρχείο να εκκινήσει το αρχείο και την εφαρμογή του.
## **VSTO Example**
Χρησιμοποιώντας το VSTO, εκτελούνται τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο του αντικειμένου Microsoft Excel ApplicationClass.
1. Δημιουργήστε ένα νέο βιβλίο εργασίας με ένα φύλλο.
1. Προσθέστε διάγραμμα στο φύλλο.
1. Αποθηκεύστε το βιβλίο εργασίας.
1. Ανοίξτε το βιβλίο εργασίας Excel που περιέχει το φύλλο εργασίας με τα δεδομένα του διαγράμματος.
1. Αποκτήστε τη συλλογή ChartObjects για το φύλλο.
1. Αποκτήστε το διάγραμμα για αντιγραφή.
1. Δημιουργήστε μια παρουσίαση Microsoft PowerPoint.
1. Προσθέστε μια κενή διαφάνεια στην παρουσίαση.
1. Αντιγράψτε το διάγραμμα από το φύλλο εργασίας του Excel στο πρόχειρο.
1. Επικολλήστε το διάγραμμα στην παρουσίαση PowerPoint.
1. Τοποθετήστε το διάγραμμα στη διαφάνεια.
1. Αποθηκεύστε την παρουσίαση.

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
    // Δηλώστε μια μεταβλητή για το αντικείμενο Excel ApplicationClass.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Δηλώστε μεταβλητές για τις παραμέτρους της μεθόδου Workbooks.Open.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Δηλώστε μεταβλητές για τη μέθοδο Chart.ChartWizard.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Δημιουργήστε ένα στιγμιότυπο του αντικειμένου Excel ApplicationClass.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Δημιουργήστε ένα νέο βιβλίο εργασίας με 1 φύλλο.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Αλλάξτε το όνομα του φύλλου.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // Εισάγετε κάποια δεδομένα για το διάγραμμα στο φύλλο.
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

        // Λάβετε το εύρος που περιέχει τα δεδομένα του διαγράμματος.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Λάβετε τη συλλογή ChartObjects για το φύλλο.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Προσθέστε ένα Διάγραμμα στη συλλογή.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // Δημιουργήστε ένα νέο διάγραμμα από τα δεδομένα.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Αποθηκεύστε το βιβλίο εργασίας.
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
            // Κλείστε το Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Δηλώστε μεταβλητές για την αποθήκευση αναφορών σε αντικείμενα PowerPoint.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Δηλώστε μεταβλητές για την αποθήκευση αναφορών σε αντικείμενα Excel.
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
        // Δημιουργήστε ένα στιγμιότυπο του PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Δημιουργήστε ένα στιγμιότυπο του Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Ανοίξτε το βιβλίο εργασίας Excel που περιέχει το φύλλο εργασίας με τα δεδομένα του διαγράμματος.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Λάβετε το φύλλο εργασίας που περιέχει το διάγραμμα.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Λάβετε τη συλλογή ChartObjects για το φύλλο.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Λάβετε το διάγραμμα για αντιγραφή.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // Δημιουργήστε μια παρουσίαση PowerPoint.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Προσθέστε μια κενή διαφάνεια στην παρουσίαση.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Αντιγράψτε το διάγραμμα από το φύλλο εργασίας Excel στο πρόχειρο.
        existingChartObject.Copy();

        // Επικολλήστε το διάγραμμα στην παρουσίαση PowerPoint.
        shapeRange = pptSlide.Shapes.Paste();

        // Τοποθετήστε το διάγραμμα στη διαφάνεια.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Αποθηκεύστε την παρουσίαση.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Αποδεσμεύστε το αντικείμενο διαφάνειας PowerPoint.
        shapeRange = null;
        pptSlide = null;

        // Κλείστε και αποδεσμεύστε το αντικείμενο Presentation.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Κλείστε το PowerPoint και αποδεσμεύστε το αντικείμενο ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Αποδεσμεύστε τα αντικείμενα Excel.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Κλείστε και αποδεσμεύστε το αντικείμενο Workbook του Excel.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Κλείστε το Excel και αποδεσμεύστε το αντικείμενο ApplicationClass.
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




## **Aspose.Slides for .NET Example**
Χρησιμοποιώντας το Aspose.Slides for .NET, εκτελούνται τα παρακάτω βήματα:

1. Δημιουργήστε ένα βιβλίο εργασίας χρησιμοποιώντας το Aspose.Cells for .NET.
1. Δημιουργήστε ένα διάγραμμα Microsoft Excel.
1. Ορίστε το μέγεθος OLE του διαγράμματος Excel.
1. Αποκτήστε μια εικόνα του διαγράμματος.
1. Ενσωματώστε το διάγραμμα Excel ως αντικείμενο OLE μέσα σε παρουσίαση PPTX χρησιμοποιώντας το Aspose.Slides for .NET.
1. Αντικαταστήστε την εικόνα αντικειμένου που άλλαξε με την εικόνα που λήφθηκε στο βήμα 3 για να αντιμετωπίσετε το πρόβλημα της αλλαγής αντικειμένου.
1. Γράψτε την τελική παρουσίαση στο δίσκο σε μορφή PPTX.

```c#
using System.Drawing;
using Aspose.Slides;

//Βήμα - 1: Δημιουργήστε ένα διάγραμμα Excel χρησιμοποιώντας Aspose.Cells
//--------------------------------------------------
//Δημιουργήστε ένα βιβλίο εργασίας
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Προσθέστε ένα διάγραμμα Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Βήμα - 2: Ορίστε το μέγεθος OLE του διαγράμματος. χρησιμοποιώντας Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Βήμα - 3: Λάβετε την εικόνα του διαγράμματος με Aspose.Cells
//-----------------------------------------------------------
MemoryStream chartImageStream = new MemoryStream();
wb.Worksheets[chartSheetIndex].Charts[0].ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
Bitmap imgChart = new Bitmap(chartImageStream);
//Save the workbook to stream
MemoryStream wbStream = wb.SaveToStream();
//Βήμα - 4  ΚΑΙ 5
//-----------------------------------------------------------
//Βήμα - 4: Ενσωματώστε το διάγραμμα ως αντικείμενο OLE μέσα σε παρουσίαση .ppt χρησιμοποιώντας Aspose.Slides
//-----------------------------------------------------------
//Βήμα - 5: Αντικαταστήστε την εικόνα που άλλαξε το αντικείμενο με την εικόνα που ελήφθη στο βήμα 3 για να αντιμετωπιστεί το πρόβλημα αλλαγής αντικειμένου
//-----------------------------------------------------------
//Δημιουργήστε μια παρουσίαση
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Προσθέστε το βιβλίο εργασίας στη διαφάνεια
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Βήμα - 6: Γράψτε την τελική παρουσίαση στο δίσκο
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

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
    //Διάταξη ονομάτων κελιών
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Διάταξη δεδομένων κελιών
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Προσθήκη νέου φύλλου εργασίας για τη συμπλήρωση των κελιών με δεδομένα
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Συμπλήρωση του DataSheet με δεδομένα
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Προσθήκη φύλλου διαγράμματος
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Προσθήκη διαγράμματος στο ChartSheet με σειρές δεδομένων από το DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Ορισμός του ChartSheet ως ενεργό φύλλο
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```