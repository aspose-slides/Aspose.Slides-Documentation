---
title: Λύση Εργασίας για Αλλαγή Μεγέθους Φύλλου Εργασίας
type: docs
weight: 40
url: /el/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- εικόνα προεπισκόπησης
- αλλαγή μεγέθους εικόνας
- Excel
- φύλλο εργασίας
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διορθώστε την αλλαγή μεγέθους OLE φύλλου εργασίας Excel σε παρουσιάσεις: δύο τρόποι να διατηρήσετε συνεπή τα πλαίσια αντικειμένων—κλιμακάρετε το πλαίσιο ή το φύλλο—στα φορμά PPT και PPTX."
---
{{% alert color="primary" %}} 

Έχει παρατηρηθεί ότι τα φύλλα εργασίας του Excel που ενσωματώνονται ως αντικείμενα OLE σε παρουσίαση PowerPoint μέσω των στοιχείων Aspose, αλλάζουν μέγεθος σε άγνωστη κλίμακα μετά την πρώτη ενεργοποίηση. Αυτή η συμπεριφορά δημιουργεί ορατή διαφορά στην παρουσίαση μεταξύ των καταστάσεων πριν και μετά την ενεργοποίηση του αντικειμένου OLE. Έχουμε διερευνήσει το ζήτημα λεπτομερώς και προσφέρουμε μια λύση, η οποία περιγράφεται σε αυτό το άρθρο.

{{% /alert %}} 

## **Υπόβαθρο**

Στο άρθρο [Διαχείριση OLE](/slides/el/net/manage-ole/), εξηγήσαμε πώς να προσθέσετε ένα πλαίσιο OLE σε παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides for .NET. Για την αντιμετώπιση του [προβλήματος προεπισκόπησης αντικειμένου](/slides/el/net/object-preview-issue-when-adding-oleobjectframe/), αντιστοιχίσαμε μια εικόνα της επιλεγμένης περιοχής του φύλλου εργασίας στο πλαίσιο αντικειμένου OLE. Στην τελική παρουσίαση, όταν κάνετε διπλό‑κλικ στο πλαίσιο OLE που εμφανίζει την εικόνα του φύλλου, ενεργοποιείται το βιβλίο εργασίας του Excel. Οι τελικοί χρήστες μπορούν να κάνουν όποιες αλλαγές θέλουν στο πραγματικό βιβλίο εργασίας του Excel και κατόπιν να επιστρέψουν στη διαφάνεια κάνοντας κλικ εκτός του ενεργοποιημένου βιβλίου εργασίας. Το μέγεθος του πλαισίου OLE θα αλλάξει όταν ο χρήστης επιστρέψει στη διαφάνεια. Ο παράγοντας αλλαγής μεγέθους θα διαφέρει ανάλογα με το μέγεθος του πλαισίου OLE και του ενσωματωμένου βιβλίου εργασίας του Excel. 

## **Αιτία της αλλαγής μεγέθους**

Δεδομένου ότι το βιβλίο εργασίας του Excel έχει το δικό του μέγεθος παραθύρου, προσπαθεί να διατηρήσει το αρχικό του μέγεθος κατά την πρώτη ενεργοποίηση. Από την άλλη πλευρά, το πλαίσιο αντικειμένου OLE έχει το δικό του μέγεθος. Σύμφωνα με τη Microsoft, όταν το βιβλίο εργασίας του Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος ώστε να διατηρηθούν οι σωστές αναλογίες ως μέρος της διαδικασίας ενσωμάτωσης. Η αλλαγή μεγέθους πραγματοποιείται με βάση τις διαφορές μεταξύ του μεγέθους του παραθύρου του Excel και του μεγέθους και της θέσης του πλαισίου OLE. 

## **Λύση**

Υπάρχουν δύο πιθανές λύσεις για την αποφυγή του φαινομένου αλλαγής μεγέθους.

- Κλιματώστε το μέγεθος του πλαισίου OLE στην παρουσίαση PowerPoint ώστε να ταιριάζει με το ύψος και το πλάτος του επιθυμητού αριθμού σειρών και στηλών στο πλαίσιο OLE.  
- Διατηρήστε το μέγεθος του πλαισίου OLE σταθερό και κλιματώστε το μέγεθος των συμμετέχουσων σειρών και στηλών ώστε να χωράει μέσα στο επιλεγμένο μέγεθος πλαισίου OLE.  

### **Κλιμάκωση του Μεγέθους του Πλαισίου OLE**

Σε αυτήν την προσέγγιση, θα μάθετε πώς να ορίσετε το μέγεθος του πλαισίου OLE του ενσωματωμένου βιβλίου εργασίας του Excel ώστε να ταιριάζει με το συνολικό μέγεθος των συμμετέχουσων σειρών και στηλών στο φύλλο εργασίας.

Ας υποθέσουμε ότι έχουμε ένα πρότυπο φύλλο Excel και θέλουμε να το προσθέσουμε σε μια παρουσίαση ως πλαίσιο OLE. Σε αυτό το σενάριο, το μέγεθος του πλαισίου αντικειμένου OLE θα υπολογιστεί αρχικά βάσει του συνόλου του ύψους των σειρών και του πλάτους των στηλών των συμμετέχουσων γραμμών και στηλών στο βιβλίο εργασίας. Στη συνέχεια, θα ορίσουμε το μέγεθος του πλαισίου OLE σε αυτήν την υπολογισμένη τιμή. Για να αποφύγουμε το κόκκινο μήνυμα "EMBEDDED OLE OBJECT" για το πλαίσιο OLE στο PowerPoint, θα καταγράψουμε επίσης μια εικόνα των επιθυμητών τμημάτων των σειρών και στηλών στο βιβλίο εργασίας και θα την ορίσουμε ως εικόνα πλαισίου OLE.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Ορίστε το εμφανιζόμενο μέγεθος όταν το αρχείο βιβλίου εργασίας χρησιμοποιείται ως αντικείμενο OLE στο PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Λάβετε το πλάτος και το ύψος της εικόνας OLE σε πόντους.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Πρέπει να χρησιμοποιήσουμε το τροποποιημένο βιβλίο εργασίας.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Προσθέστε την εικόνα OLE στους πόρους της παρουσίασης.
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

### **Κλιμάκωση του Μεγέθους της Περιοχής Κυψέλης**

Σε αυτήν την προσέγγιση, θα μάθετε πώς να κλιματώσετε τα ύψη των συμμετέχουσων σειρών και το πλάτος των συμμετέχουσων στηλών ώστε να ταιριάζουν με ένα προσαρμοσμένο μέγεθος πλαισίου OLE.

Ας υποθέσουμε ότι έχουμε ένα πρότυπο φύλλο Excel και θέλουμε να το προσθέσουμε σε μια παρουσίαση ως πλαίσιο OLE. Σε αυτό το σενάριο, θα ορίσουμε το μέγεθος του πλαισίου OLE και θα κλιματώσουμε το μέγεθος των σειρών και των στηλών που συμμετέχουν στην περιοχή του πλαισίου OLE. Στη συνέχεια, θα αποθηκεύσουμε το βιβλίο εργασίας σε ροή για να εφαρμόσουμε τις αλλαγές και θα το μετατρέψουμε σε πίνακα byte για να το προσθέσουμε στο πλαίσιο OLE. Για να αποφύγουμε το κόκκινο μήνυμα "EMBEDDED OLE OBJECT" για το πλαίσιο OLE στο PowerPoint, θα καταγράψουμε επίσης μια εικόνα των επιθυμητών τμημάτων των σειρών και στηλών στο βιβλίο εργασίας και θα την ορίσουμε ως εικόνα πλαισίου OLE.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Ορίστε το εμφανιζόμενο μέγεθος όταν το αρχείο βιβλίου εργασίας χρησιμοποιείται ως αντικείμενο OLE στο PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Κλιματώστε το εύρος κελιών ώστε να ταιριάζει με το μέγεθος του πλαισίου.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Πρέπει να χρησιμοποιήσουμε το τροποποιημένο βιβλίο εργασίας.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Προσθέστε την εικόνα OLE στους πόρους της παρουσίασης.
var oleImage = presentation.Images.AddImage(imageStream);

// Δημιουργήστε το πλαίσιο αντικειμένου OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">Το αναμενόμενο πλάτος της περιοχής κελιών σε πόντους.</param>
/// <param name="height">Το αναμενόμενο ύψος της περιοχής κελιών σε πόντους.</param>
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

## **Συμπέρασμα**

{{% alert color="primary" %}}

Υπάρχουν δύο προσεγγίσεις για την επίλυση του προβλήματος αλλαγής μεγέθους του φύλλου εργασίας. Η επιλογή της κατάλληλης προσέγγισης εξαρτάται από τις συγκεκριμένες απαιτήσεις και τη χρήση. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο, είτε οι παρουσιάσεις δημιουργούνται από πρότυπο είτε από το μηδέν. Επιπλέον, δεν υπάρχει καθορισμένο όριο στο μέγεθος του πλαισίου OLE σε αυτή τη λύση.

{{% /alert %}}

## **Συχνές ερωτήσεις**

**Γιατί ένα ενσωματωμένο φύλλο εργασίας Excel αλλάζει μέγεθος όταν ενεργοποιείται για πρώτη φορά στο PowerPoint;**  
Αυτό συμβαίνει επειδή το Excel προσπαθεί να διατηρήσει το αρχικό μέγεθος του παραθύρου κατά την ενεργοποίηση, ενώ το πλαίσιο OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρήσουν την αναλογία, κάτι που μπορεί να προκαλέσει την αλλαγή μεγέθους.

**Μπορεί κανείς να αποτρέψει εντελώς αυτή την αλλαγή μεγέθους;**  
Ναι. Κλιμακώνοντας το πλαίσιο OLE ώστε να ταιριάζει με το μέγεθος της περιοχής κελιών του Excel ή κλιμακώνοντας την περιοχή κελιών ώστε να ταιριάζει με το επιθυμητό μέγεθος πλαισίου OLE, μπορείτε να αποτρέψετε ανεπιθύμητες αλλαγές μεγέθους.

**Ποια μέθοδο κλιμάκωσης πρέπει να χρησιμοποιήσω, κλιμάκωση πλαισίου OLE ή κλιμάκωση περιοχής κελιών;**  
Επιλέξτε **κλιμάκωση πλαισίου OLE** εάν θέλετε να διατηρήσετε τα αρχικά μεγέθη των σειρών και στηλών του Excel. Επιλέξτε **κλιμάκωση περιοχής κελιών** εάν θέλετε ένα σταθερό μέγεθος για το πλαίσιο OLE στην παρουσίασή σας.

**Θα λειτουργήσουν αυτές οι λύσεις εάν η παρουσίασή μου βασίζεται σε πρότυπο;**  
Ναι. Και οι δύο λύσεις λειτουργούν για παρουσιάσεις που δημιουργούνται από πρότυπα και από το μηδέν.

**Υπάρχει όριο στο μέγεθος του πλαισίου OLE όταν χρησιμοποιούνται αυτές οι μέθοδοι;**  
Όχι. Μπορείτε να κάνετε το πλαίσιο αντικειμένου OLE οποιοδήποτε μέγεθος, αρκεί να ρυθμίσετε την κλίμακα αναλόγως.

**Υπάρχει τρόπος να αποφευχθεί το κείμενο κράτησης θέσης «EMBEDDED OLE OBJECT» στο PowerPoint;**  
Ναι. Λαμβάνοντας ένα στιγμιότυπο της επιλεγμένης περιοχής κελιών του Excel και ορίζοντάς το ως εικόνα κράτησης θέσης του πλαισίου OLE, μπορείτε να εμφανίσετε μια προσαρμοσμένη εικόνα προεπισκόπησης αντί του προεπιλεγμένου κειμένου.

## **Σχετικά άρθρα**

[Δημιουργία διαγράμματος Excel και ενσωμάτωσή του σε παρουσίαση ως αντικείμενο OLE](/slides/el/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Αυτόματη ενημέρωση αντικειμένων OLE χρησιμοποιώντας πρόσθετο MS PowerPoint](/slides/el/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)