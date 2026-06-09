---
title: Δημιουργία Διαγραμμάτων Excel και Ενσωμάτωση τους σε Παρουσιάσεις ως Αντικείμενα OLE
type: docs
weight: 30
url: /el/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Διάγραμμα Excel
- Ενσωμάτωση διαγράμματος
- Αντικείμενο OLE
- PowerPoint
- OpenDocument
- Παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε διαγράμματα Excel και ενσωματώστε τα ως αντικείμενα OLE σε παρουσιάσεις PowerPoint και OpenDocument με τη Java. Οδηγός βήμα προς βήμα με παραδείγματα κώδικα."
---
## **Ιστορικό**

Στο PowerPoint, η χρήση επεξεργάσιμων διαγραμμάτων για την γραφική παρουσίαση δεδομένων είναι κοινή πρακτική. Η Aspose υποστηρίζει τη δημιουργία διαγραμμάτων Excel με το Aspose.Cells for Java, και αυτά τα διαγράμματα μπορούν στη συνέχεια να ενσωματωθούν ως αντικείμενα OLE σε διαφάνειες PowerPoint μέσω του Aspose.Slides for Java. Αυτό το άρθρο καλύπτει τα απαραίτητα βήματα και παρέχει δείγματα κώδικα Java για τη δημιουργία διαγράμματος Excel και την ενσωμάτωσή του ως αντικείμενο OLE σε παρουσίαση PowerPoint χρησιμοποιώντας Aspose.Cells και Aspose.Slides.

## **Απαιτούμενα βήματα**

Η ακόλουθη ακολουθία βημάτων απαιτείται για τη δημιουργία και ενσωμάτωση ενός διαγράμματος Excel ως αντικείμενο OLE σε διαφάνεια PowerPoint:

1. Δημιουργήστε ένα διάγραμμα Excel χρησιμοποιώντας το Aspose.Cells.
1. Ορίσετε το μέγεθος OLE του διαγράμματος Excel χρησιμοποιώντας το Aspose.Cells.
1. Αποκτήστε μια εικόνα του διαγράμματος Excel με το Aspose.Cells.
1. Ενσωματώστε το διάγραμμα Excel ως αντικείμενο OLE σε παρουσίαση PPTX χρησιμοποιώντας το Aspose.Slides.
1. Αντικαταστήστε την εικόνα "EMBEDDED OLE OBJECT" με την εικόνα που λήφθηκε στο βήμα 3 για την αντιμετώπιση του [object preview issue](/slides/el/java/object-preview-issue-when-adding-oleobjectframe/).
1. Αποθηκεύστε την παρουσίαση στο δίσκο σε μορφή PPTX.

## **Υλοποίηση των Απαιτούμενων Βημάτων**

Η υλοποίηση Java των παραπάνω βημάτων είναι ως εξής:

```java
// Δημιουργία βιβλίου εργασίας.
Workbook workbook = new Workbook();

// Προσθήκη διαγράμματος Excel.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Ορισμός του μεγέθους OLE του διαγράμματος.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// Λήψη της εικόνας του διαγράμματος και αποθήκευση σε ροή.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// Αποθήκευση του βιβλίου εργασίας σε ροή.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// Δημιουργία παρουσίασης.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Προσθήκη του βιβλίου εργασίας σε διαφάνεια.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// Αποθήκευση της παρουσίασης στο δίσκο.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // Δημιουργία αντικειμένου LoadOptions τύπου EXCEL_97_TO_2003.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // Μία διάταξη ονομάτων κελιών.
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Μία διάταξη δεδομένων κελιών.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Προσθήκη νέου φύλλου εργασίας για τη συμπλήρωση των κελιών με δεδομένα.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // Γέμισμα του φύλλου δεδομένων με δεδομένα.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // Προσθήκη φύλλου διαγράμματος.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // Προσθήκη διαγράμματος στο φύλλο διαγράμματος με σειρές δεδομένων από το φύλλο δεδομένων.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // Ορισμός του φύλλου διαγράμματος ως ενεργό φύλλο.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

Η παρουσίαση που δημιουργείται με τη παραπάνω μέθοδο θα περιέχει το διάγραμμα Excel ως αντικείμενο OLE που μπορεί να ενεργοποιηθεί με διπλό κλικ στο πλαίσιο αντικειμένου OLE.

## **Συμπέρασμα**

Χρησιμοποιώντας το Aspose.Cells for Java μαζί με το Aspose.Slides for Java, μπορούμε να δημιουργήσουμε οποιοδήποτε διάγραμμα Excel που υποστηρίζεται από το Aspose.Cells και να το ενσωματώσουμε ως αντικείμενο OLE σε μια διαφάνεια PowerPoint. Το μέγεθος OLE του διαγράμματος Excel μπορεί επίσης να οριστεί. Οι τελικοί χρήστες μπορούν στη συνέχεια να επεξεργαστούν το διάγραμμα Excel όπως οποιοδήποτε άλλο αντικείμενο OLE.

## **Σχετικές Ενότητες**

- [Λύση Λειτουργίας για Αλλαγή Μεγέθους Διαγράμματος σε PPTX](/slides/el/java/working-solution-for-chart-resizing-in-pptx/)
- [Πρόβλημα Προεπισκόπησης Αντικειμένου όταν Προστίθεται OleObjectFrame](/slides/el/java/object-preview-issue-when-adding-oleobjectframe/)
- [Αυτόματη Ενημέρωση Αντικειμένων OLE με χρήση Πρόσθετου PowerPoint](/slides/el/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)