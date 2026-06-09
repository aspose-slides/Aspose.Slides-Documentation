---
title: Δημιουργία διαγραμμάτων Excel και ενσωμάτωσή τους σε παρουσιάσεις ως αντικείμενα OLE
type: docs
weight: 50
url: /el/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Διάγραμμα Excel
- ενσωμάτωση διαγράμματος
- αντικείμενο OLE
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε διαγράμματα Excel και ενσωματώστε τα ως αντικείμενα OLE σε παρουσιάσεις PowerPoint και OpenDocument με C#/.NET. Οδηγός βήμα προς βήμα με δείγματα κώδικα."
---
## **Ιστορικό**

Στο PowerPoint, η χρήση επεξεργάσιμων διαγραμμάτων για την γραφική παρουσίαση δεδομένων είναι συνηθισμένη πρακτική. Το Aspose υποστηρίζει τη δημιουργία διαγραμμάτων Excel με το Aspose.Cells για .NET, και αυτά τα διαγράμματα μπορούν στη συνέχεια να ενσωματωθούν ως αντικείμενα OLE σε διαφάνειες PowerPoint μέσω του Aspose.Slides για .NET. Αυτό το άρθρο καλύπτει τα απαραίτητα βήματα και παρέχει δείγματα κώδικα C# για τη δημιουργία διαγράμματος Excel και την ενσωματωσή του ως αντικείμενο OLE σε παρουσίαση PowerPoint χρησιμοποιώντας τα Aspose.Cells και Aspose.Slides.

## **Απαιτούμενα Βήματα**

Η παρακάτω ακολουθία βημάτων απαιτείται για τη δημιουργία και ενσωμάτωση ενός διαγράμματος Excel ως αντικείμενο OLE σε διαφάνεια PowerPoint:

1. Δημιουργήστε ένα διάγραμμα Excel χρησιμοποιώντας το Aspose.Cells.
1. Ορίστε το μέγεθος OLE του διαγράμματος Excel χρησιμοποιώντας το Aspose.Cells.
1. Αποκτήστε μια εικόνα του διαγράμματος Excel με το Aspose.Cells.
1. Ενσωματώστε το διάγραμμα Excel ως αντικείμενο OLE σε παρουσίαση PPTX χρησιμοποιώντας το Aspose.Slides.
1. Αντικαταστήστε την εικόνα "EMBEDDED OLE OBJECT" με την εικόνα που λήφθηκε στο βήμα 3 για την αντιμετώπιση του [πρόβλημα προεπισκόπησης αντικειμένου](/slides/el/net/object-preview-issue-when-adding-oleobjectframe/).
1. Αποθηκεύστε την παρουσίαση στον δίσκο σε μορφή PPTX.

## **Υλοποίηση των Απαιτούμενων Βημάτων**

Η υλοποίηση C# των παραπάνω βημάτων είναι ως εξής:

```cs
// Βήμα - 1: Δημιουργία διαγράμματος Excel χρησιμοποιώντας το Aspose.Cells.
// ---------------------------------------------------
// Δημιουργία βιβλίου εργασίας.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Προσθήκη διαγράμματος Excel.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Βήμα - 2: Ορισμός του μεγέθους OLE του διαγράμματος χρησιμοποιώντας το Aspose.Cells.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// Βήμα - 3: Λήψη της εικόνας του διαγράμματος με το Aspose.Cells.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// Αποθήκευση του βιβλίου εργασίας σε ροή.
MemoryStream workbookStream = workbook.SaveToStream();

// Βήμα - 4 ΚΑΙ 5
// =============
// Βήμα - 4: Ενσωμάτωση του διαγράμματος ως αντικειμένου OLE σε παρουσίαση .ppt χρησιμοποιώντας το Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Βήμα - 5: Αντικατάσταση της εικόνας "EMBEDDED OLE OBJECT" με την εικόνα που λήφθηκε στο βήμα 3 για την αντιμετώπιση του προβλήματος προεπισκόπησης αντικειμένου.
// --------------------------------------------------------------------------------------------------------------------
 // Δημιουργία παρουσίασης.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // Προσθήκη του βιβλίου εργασίας στη διαφάνεια.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // Βήμα - 6: Αποθήκευση της τελικής παρουσίασης στον δίσκο.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // Ένας πίνακας ονομάτων κελιών.
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Ένας πίνακας δεδομένων κελιών.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Προσθήκη νέου φύλλου εργασίας για τη συμπλήρωση κελιών με δεδομένα.
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // Συμπλήρωση του φύλλου δεδομένων με δεδομένα.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // Προσθήκη φύλλου διαγράμματος.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // Προσθήκη διαγράμματος στο φύλλο διαγράμματος με σειρές δεδομένων από το φύλλο δεδομένων.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // Ορισμός του φύλλου διαγράμματος ως ενεργό φύλλο.
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

Η παρουσίαση που δημιουργείται με τη παραπάνω μέθοδο θα περιέχει το διάγραμμα Excel ως αντικείμενο OLE που μπορεί να ενεργοποιηθεί κάνοντας διπλό κλικ στο πλαίσιο του αντικειμένου OLE.

## **Συμπέρασμα**

Με τη χρήση του Aspose.Cells για .NET σε συνδυασμό με το Aspose.Slides για .NET, μπορούμε να δημιουργήσουμε οποιοδήποτε διάγραμμα Excel που υποστηρίζεται από το Aspose.Cells και να ενσωματώσουμε το διάγραμμα ως αντικείμενο OLE σε διαφάνεια PowerPoint. Το μέγεθος OLE του διαγράμματος Excel μπορεί επίσης να οριστεί. Οι τελικοί χρήστες μπορούν στη συνέχεια να επεξεργαστούν το διάγραμμα Excel όπως οποιοδήποτε άλλο αντικείμενο OLE.

## **Σχετικές Ενότητες**

- [Λύση λειτουργίας για αλλαγή μεγέθους διαγράμματος σε PPTX](/slides/el/net/working-solution-for-chart-resizing-in-pptx/)
- [Πρόβλημα προεπισκόπησης αντικειμένου όταν προστίθεται OleObjectFrame](/slides/el/net/object-preview-issue-when-adding-oleobjectframe/)
- [Ανανέωση αντικειμένων OLE αυτόματα χρησιμοποιώντας πρόσθετο PowerPoint](/slides/el/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)