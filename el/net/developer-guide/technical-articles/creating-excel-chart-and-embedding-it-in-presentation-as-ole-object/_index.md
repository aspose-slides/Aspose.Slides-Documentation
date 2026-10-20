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
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε ένα διάγραμμα Excel με το Aspose.Cells για .NET και ενσωματώστε το βιβλίο εργασίας σε μια παρουσίαση PowerPoint με το Aspose.Slides, συμπεριλαμβανομένης μιας προεπισκόπησης διαγράμματος."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε ένα γράφημα στήλης του Excel με το Aspose.Cells for .NET και να ενσωματώσετε το βιβλίο εργασίας του σε μια παρουσίαση PowerPoint με το Aspose.Slides for .NET. Το ενσωματωμένο βιβλίο εργασίας περιέχει τόσο τα δεδομένα προέλευσης όσο και το γράφημα. Μια ξεχωριστή προεπισκόπηση PNG εμφανίζει το γράφημα στη διαφάνεια πριν ενεργοποιηθεί το αντικείμενο OLE.

Το αποτέλεσμα είναι ένα ενσωματωμένο αντικείμενο Excel, όχι ένα εγγενές γράφημα PowerPoint. Η επεξεργασία του βιβλίου εργασίας μέσω OLE απαιτεί μια εφαρμογή υπολογιστή που υποστηρίζει την ενεργοποίηση OLE και μια συμβατή εγκατάσταση του Excel.

## **Προαπαιτούμενα**

Προσθέστε αναφορές στο Aspose.Cells for .NET και στο Aspose.Slides for .NET στο έργο C# σας. Το παράδειγμα χρησιμοποιεί δηλώσεις κορυφαίου επιπέδου και απαιτεί C# 9 ή νεότερο. Το Microsoft Office δεν απαιτείται για τη δημιουργία της παρουσίασης με αυτές τις βιβλιοθήκες.

Δεν απαιτούνται αρχεία εισόδου: το παράδειγμα δημιουργεί τα δεδομένα και το γράφημα στη μνήμη, και στη συνέχεια γράφει `OutputChart.pptx` στον τρέχοντα φάκελο εργασίας. Εφαρμόστε άδειες για και τα δύο προϊόντα όταν εκτελείται εκτός λειτουργίας αξιολόγησης.

## **Πώς Λειτουργεί η Ενσωμάτωση**

1. Δημιουργήστε ένα βιβλίο εργασίας με ένα φύλλο δεδομένων και ένα φύλλο γραφήματος.
1. Κάντε το φύλλο γραφήματος ενεργό ώστε το βιβλίο εργασίας να ανοίγει στο γράφημα.
1. Ορίστε την περιοχή εμφάνισης OLE του βιβλίου εργασίας και αποδώστε το γράφημα σε PNG.
1. Αποθηκεύστε το βιβλίο εργασίας ως XLSX στη μνήμη και ενσωματώστε αυτά τα bytes σε μια διαφάνεια.
1. Αναθέστε το PNG ως προεπισκόπηση του αντικειμένου OLE και αποθηκεύστε την παρουσίαση ως PPTX.

Η περιοχή εμφάνισης του βιβλίου εργασίας και το πλαίσιο στη διαφάνεια έχουν διαφορετικούς ρόλους. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) λαμβάνει δείκτες γραμμής/στήλης αρχής/τέλους με βάση το μηδέν. Αντίθετα, το [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) λαμβάνει τη γραμμή επάνω, τη στήλη αριστερά, τη γραμμή κάτω και τη στήλη δεξιά. Το παράδειγμα χρησιμοποιεί δείκτη γραμμής 55 και δείκτη στήλης 25 ως τα κάτω δεξιά όρια· αυτές οι τιμές είναι επιλογές διάταξης, όχι ο αριθμός των γραμμών ή των στηλών δεδομένων.

Το πλαίσιο της διαφάνειας χρησιμοποιεί μονάδες σημείου. Το παράδειγμα το προσαρμόζει εντός της διαφάνειας και το κεντράρει διατηρώντας την αναλογία διαστάσεων του PNG, αντί να τεντωθεί η προεπισκόπηση για να γεμίσει τη διαφάνεια.

## **Δημιουργία και Ενσωμάτωση του Γραφήματος**

Το παρακάτω πλήρες παράδειγμα γεμίζει το `DataSheet` με τέσσερις σειρές και πέντε στήλες τιμών. Κάθε σειρά γίνεται μία σειρά γραφήματος. Το `ChartSheet` επιλέγεται ως το ενεργό φύλλο πριν αποθηκευτεί το βιβλίο εργασίας.

Το βιβλίο εργασίας αποθηκεύεται ρητά ως XLSX, ταιριάζοντας με την επέκταση `xlsx` που περνιέται στο [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/). Το PNG φορτώνεται άμεσα από το ροή του χωρίς ενδιάμεση μετατροπή bitmap. Η ανάθεσή του μέσω του [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) αντικαθιστά το προεπιλεγμένο placeholder OLE.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// Αποδίδεται η προεπισκόπηση του διαγράμματος και σειριοποιείται χωριστά το επεξεργάσιμο βιβλίο εργασίας.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Αναμενόμενο Αποτέλεσμα**

`OutputChart.pptx` περιέχει μία διαφάνεια με ενσωματωμένο βιβλίο εργασίας Excel και προεπισκόπηση γραφήματος. Το βιβλίο εργασίας περιέχει τα αρχικά δεδομένα και ένα γράφημα στήλης με τέσσερις σειρές. Η προεπισκόπηση είναι κεντρασμένη στη διαφάνεια και διατηρεί τις αναλογίες της.

![Γράφημα στήλης Excel που εμφανίζεται ως προεπισκόπηση ενσωματωμένου βιβλίου εργασίας](excel-chart-ole-preview.png)

Σε ένα συμβατό περιβάλλον PowerPoint σε υπολογιστή με διαθέσιμο Excel, κάντε διπλό κλικ στο αντικείμενο για να ενεργοποιήσετε και να επεξεργαστείτε το ενσωματωμένο βιβλίο εργασίας. Η ενεργοποίηση και η επεξεργασία εξαρτώνται από την υποστήριξη OLE της εφαρμογής-ξενιστή και τις ρυθμίσεις ασφαλείας.

## **Συχνές Ερωτήσεις**

**Γιατί χρειάζεται μια εικόνα προεπισκόπησης;**

Το ενσωματωμένο βιβλίο εργασίας και η προεπισκόπηση της διαφάνειας είναι ξεχωριστό περιεχόμενο. Παρέχετε μια εικόνα γραφήματος ώστε η διαφάνεια να εμφανίζει το γράφημα αντί του προεπιλεγμένου placeholder "EMBEDDED OLE OBJECT". Δείτε το [Πρόβλημα Προεπισκόπησης Αντικειμένου κατά την Προσθήκη OleObjectFrame](/slides/el/net/object-preview-issue-when-adding-oleobjectframe/).

**Ενημερώνεται αυτόματα η προεπισκόπηση όταν αλλάζω το βιβλίο εργασίας στον κώδικα;**

Αντιμετωπίστε την προεπισκόπηση ως στιγμιότυπο. Όταν ενημερώνετε τα δεδομένα του βιβλίου εργασίας προγραμματιστικά, δημιουργήστε ξανά την εικόνα του γραφήματος και αντικαταστήστε την προεπισκόπηση καθώς και τα ενσωματωμένα δεδομένα του βιβλίου εργασίας.

**Μπορώ να χρησιμοποιήσω XLS αντί για XLSX;**

Ναι. Αποθηκεύστε το βιβλίο εργασίας σε μορφή XLS και χρησιμοποιήστε `xls` ως επέκταση των ενσωματωμένων δεδομένων. Η επέκταση πρέπει να ταιριάζει με την πραγματική μορφή του βιβλίου εργασίας· η αλλαγή μόνο της επέκτασης δεν μετατρέπει τα δεδομένα.

**Γιατί το αντικείμενο μπορεί να αλλάξει μέγεθος μετά την ενεργοποίηση;**

Η εφαρμογή-ξενιστής μπορεί να ενημερώσει την παρουσίαση του αντικειμένου OLE όταν ενεργοποιήσει το βιβλίο εργασίας. Η περιοχή εμφάνισης OLE του βιβλίου εργασίας και οι διαστάσεις του πλαισίου της διαφάνειας είναι και οι δύο σημαντικές. Δείτε τη [Λύση Εργασίας για Αλλαγή Μεγέθους Γραφήματος σε PPTX](/slides/el/net/working-solution-for-chart-resizing-in-pptx/).

## **Σχετικές Ενότητες**

- [Λύση Εργασίας για Αλλαγή Μεγέθους Γραφήματος σε PPTX](/slides/el/net/working-solution-for-chart-resizing-in-pptx/)
- [Πρόβλημα Προεπισκόπησης Αντικειμένου κατά την Προσθήκη OleObjectFrame](/slides/el/net/object-preview-issue-when-adding-oleobjectframe/)
- [Αυτόματη Ενημέρωση Αντικειμένων OLE με Χρήση Πρόσθετου PowerPoint](/slides/el/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)