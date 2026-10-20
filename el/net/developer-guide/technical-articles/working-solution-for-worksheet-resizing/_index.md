---
title: Λύση για την αλλαγή μεγέθους του φύλλου εργασίας
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
description: "Διορθώστε την αλλαγή μεγέθους OLE φύλλου εργασίας Excel σε παρουσιάσεις: δύο τρόποι για να διατηρήσετε σταθερά τα πλαίσια αντικειμένων—κλιμακώστε το πλαίσιο ή το φύλλο—σε μορφές PPT και PPTX."
---
{{% alert color="info" title="Note" %}}

Τα φύλλα εργασίας του Excel ενσωματωμένα ως αντικείμενα OLE σε μια παρουσίαση PowerPoint χρησιμοποιώντας συστατικά Aspose ενδέχεται να αλλάξουν μέγεθος απροσδόκητα μετά την πρώτη τους ενεργοποίηση. Αυτή η συμπεριφορά δημιουργεί μια εμφανή οπτική διαφορά μεταξύ του αντικειμένου OLE πριν και μετά την ενεργοποίηση. Αυτό το άρθρο εξηγεί το ζήτημα και περιγράφει δύο τρόπους αντιμετώπισής του.

{{% /alert %}} 

## **Ιστορικό**

Στο άρθρο [Διαχείριση OLE](/slides/el/net/manage-ole/), εξηγήσαμε πώς να προσθέσουμε ένα πλαίσιο OLE σε μια παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides for .NET. Για την αντιμετώπιση του [πρόβλημα προεπισκόπησης αντικειμένου](/slides/el/net/object-preview-issue-when-adding-oleobjectframe/), αντιστοιχίσαμε μια εικόνα της επιλεγμένης περιοχής του φύλλου εργασίας στο πλαίσιο αντικειμένου OLE. Στην τελική παρουσίαση, όταν κάνετε διπλό κλικ στο πλαίσιο αντικειμένου OLE που εμφανίζει την εικόνα του φύλλου, το βιβλίο εργασίας του Excel ενεργοποιείται. Οι τελικοί χρήστες μπορούν να κάνουν τις επιθυμητές αλλαγές στο πραγματικό βιβλίο εργασίας του Excel και στη συνέχεια να επιστρέψουν στη διαφάνεια κάνοντας κλικ έξω από το ενεργοποιημένο βιβλίο εργασίας. Το μέγεθος του πλαισίου αντικειμένου OLE θα αλλάξει όταν ο χρήστης επιστρέψει στη διαφάνεια. Ο παράγοντας αλλαγής μεγέθους θα διαφέρει ανάλογα με το μέγεθος του πλαισίου αντικειμένου OLE και του ενσωματωμένου βιβλίου εργασίας του Excel. 

## **Αιτία αλλαγής μεγέθους**

Επειδή το βιβλίο εργασίας του Excel έχει το δικό του μέγεθος παραθύρου, προσπαθεί να διατηρήσει το αρχικό του μέγεθος κατά την πρώτη ενεργοποίηση. Από την άλλη πλευρά, το πλαίσιο αντικειμένου OLE έχει το δικό του μέγεθος. Σύμφωνα με τη Microsoft, όταν το βιβλίο εργασίας του Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος ώστε να εξασφαλιστεί ότι διατηρεί τις σωστές αναλογίες ως μέρος της διαδικασίας ενσωμάτωσης. Η αλλαγή μεγέθους συμβαίνει βάσει των διαφορών μεταξύ του μεγέθους του παραθύρου του Excel και του μεγέθους και της θέσης του πλαισίου αντικειμένου OLE. 

## **Λειτουργική Λύση**

Υπάρχουν δύο πιθανές λύσεις για να αποφευχθεί το φαινόμενο αλλαγής μεγέθους.

- Κλιμακώστε το πλαίσιο OLE στην παρουσίαση PowerPoint ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων σειρών και στηλών.
- Διατηρήστε το μέγεθος του πλαισίου OLE σταθερό και κλιμακώστε τις επιλεγμένες σειρές και στήλες ώστε να ταιριάζουν μέσα του.

### **Κλιμακώστε το Μέγεθος του Πλαισίου OLE**

Αυτή η προσέγγιση ορίζει το μέγεθος του πλαισίου OLE ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων σειρών και στηλών στο ενσωματωμένο φύλλο εργασίας του Excel.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας Excel και επιλέγει τις πρώτες 10 σειρές και 13 στήλες του πρώτου φύλλου του χρησιμοποιώντας δείκτες μηδενικής βάσης. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) ορίζει την προβεβλημένη περιοχή. Η προεπισκόπηση αποδίδεται στα 96 DPI και οι διαστάσεις των εικονοστοιχείων μετατρέπονται σε πόντους χρησιμοποιώντας 72 πόντους ανά ίντσα. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) ενσωματώνει το τροποποιημένο βιβλίο εργασίας σε ένα πλαίσιο με αυτές τις διαστάσεις. Η προεπισκόπηση αντιστοιχίζεται μέσω του [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) για να αντικαταστήσει το χώρο κράτησης «EMBEDDED OLE OBJECT» στην αποθηκευμένη παρουσίαση.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

// Δημιουργήστε το πλαίσιο αντικειμένου OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Ο βοηθός προεπισκόπησης ορίζει το [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) στη επιλεγμένη περιοχή και αφαιρεί περιθώρια, κεφαλίδες και υποσέλιδα. Με ενεργοποιημένο το [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/), το [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) αποδίδει την περιοχή ως εικόνα PNG. Ο βοηθός επαναφέρνει τη ροή εικόνας πριν την επιστρέψει για χρήση στην παρουσίαση.

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

### **Κλιμακώστε το Μέγεθος του Περιοχής Κελιών**

Αυτή η προσέγγιση κλιμακώνει τα ύψη των επιλεγμένων σειρών και τα πλάτη των επιλεγμένων στηλών ώστε να ταιριάζουν με ένα προσαρμοσμένο μέγεθος πλαισίου OLE.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας Excel και επιλέγει τις πρώτες 10 σειρές και 13 στήλες του πρώτου φύλλου του χρησιμοποιώντας δείκτες μηδενικής βάσης. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) ορίζει την προβεβλημένη περιοχή, και ο παρακάτω βοηθός κλιμακώνει αυτήν την περιοχή ώστε να ταιριάζει σε ένα πλαίσιο 400 πόντων πλάτους και 100 πόντων ύψους. Αφού αποθηκευτεί το τροποποιημένο βιβλίο εργασίας σε ροή, το [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) το ενσωματώνει στο καθορισμένο μέγεθος. Μια προεπισκόπηση που αποδίδεται στα 96 DPI αντιστοιχίζεται μέσω του [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/), ώστε η αποθηκευμένη παρουσίαση να εμφανίζει τα επιλεγμένα κελιά αντί του προεπιλεγμένου χώρου κράτησης.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

// Κλιμακώστε την περιοχή κελιών ώστε να ταιριάζει με το μέγεθος του πλαισίου.
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

Ο βοηθός κλιμάκωσης υπολογίζει ξεχωριστούς συντελεστές πλάτους και ύψους για την επιλεγμένη περιοχή, διατηρώντας τις σχετικές αναλογίες των στηλών και των σειρών της. Μετατρέπει τις υπολογισμένες διαστάσεις από πόντους σε ίντσες πριν τις εφαρμόσει με τις μεθόδους [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) και [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/). Η επιλεγμένη περιοχή πρέπει να έχει μη μηδενικό πλάτος και ύψος.

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

Αυτός ο βοηθός προεπισκόπησης αποδίδει την κλιμακωμένη περιοχή χρησιμοποιώντας το [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). Περιορίζει το [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) σε εκείνη την περιοχή, αφαιρεί περιθώρια, κεφαλίδες και υποσέλιδα, και επιστρέφει μια ροή PNG τοποθετημένη στην αρχή της.

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

{{% alert color="info" title="Note" %}}

Υπάρχουν δύο προσεγγίσεις για την επίλυση του προβλήματος αλλαγής μεγέθους του φύλλου εργασίας. Επιλέξτε την προσέγγιση που ταιριάζει καλύτερα στις απαιτήσεις και τη χρήση σας. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο, είτε οι παρουσιάσεις δημιουργούνται από πρότυπο είτε από την αρχή. Επιπλέον, δεν υπάρχει όριο στο μέγεθος του πλαισίου αντικειμένου OLE σε αυτή τη λύση.

{{% /alert %}}

## **ΣΥΧΝΑ ΕΡΩΤΗΣΕΙΣ**

**Γιατί ένα ενσωματωμένο φύλλο Excel αλλάζει μέγεθος όταν ενεργοποιείται για πρώτη φορά στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να διατηρήσει το αρχικό μέγεθος του παραθύρου κατά την ενεργοποίηση, ενώ το πλαίσιο αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρήσουν την αναλογία διαστάσεων, γεγονός που μπορεί να προκαλέσει την αλλαγή μεγέθους.

**Μπορεί να αποτραπεί πλήρως αυτό το πρόβλημα αλλαγής μεγέθους;**

Ναι. Κλιμακώνοντας το πλαίσιο OLE ώστε να ταιριάζει με το μέγεθος της περιοχής κελιών του Excel ή κλιμακώνοντας την περιοχή κελιών ώστε να ταιριάζει με το επιθυμητό μέγεθος πλαισίου OLE, μπορείτε να αποτρέψετε ανεπιθύμητες αλλαγές μεγέθους.

**Ποια μέθοδο κλιμακώματος πρέπει να χρησιμοποιήσω, κλιμάκωση πλαισίου OLE ή κλιμάκωση περιοχής κελιών;**

Επιλέξτε **κλιμάκωση πλαισίου OLE** εάν θέλετε να διατηρήσετε τα αρχικά μεγέθη σειρών και στηλών του Excel. Επιλέξτε **κλιμάκωση περιοχής κελιών** εάν θέλετε ένα σταθερό μέγεθος για το πλαίσιο OLE στην παρουσίασή σας.

**Θα λειτουργούν αυτές οι λύσεις αν η παρουσίαση μου βασίζεται σε πρότυπο;**

Ναι. Και οι δύο λύσεις λειτουργούν για παρουσιάσεις που δημιουργούνται από πρότυπα και από την αρχή.

**Υπάρχει όριο στο μέγεθος του πλαισίου OLE όταν χρησιμοποιούνται αυτές οι μέθοδοι;**

Όχι. Μπορείτε να ορίσετε το πλαίσιο αντικειμένου OLE σε οποιοδήποτε μέγεθος, αρκεί να ρυθμίσετε σωστά την κλιμάκωση.

**Υπάρχει τρόπος να αποφύγετε το κείμενο θέσης κράτησης «EMBEDDED OLE OBJECT» στο PowerPoint;**

Ναι. Με τη λήψη στιγμιότυπου της επιλεγμένης περιοχής κελιών του Excel και ορίζοντας το ως εικόνα θέσης κράτησης του πλαισίου OLE, μπορείτε να εμφανίσετε μια προσαρμοσμένη εικόνα προεπισκόπησης στη θέση του προεπιλεγμένου χώρου κράτησης.

## **Σχετικά Άρθρα**

[Δημιουργία γραφήματος Excel και ενσωμάτωσή του σε παρουσίαση ως αντικείμενο OLE](/slides/el/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Αυτόματη ενημέρωση αντικειμένων OLE χρησιμοποιώντας πρόσθετο MS PowerPoint](/slides/el/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)