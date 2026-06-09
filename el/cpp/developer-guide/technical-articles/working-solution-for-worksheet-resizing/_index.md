---
title: Λύση λειτουργίας για αλλαγή μεγέθους φύλλου εργασίας
type: docs
weight: 130
url: /el/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- εικόνα προεπισκόπησης
- αλλαγή μεγέθους εικόνας
- Excel
- φύλλο εργασίας
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides for C++
description: "Λύση λειτουργίας για αλλαγή μεγέθους φύλλου εργασίας σε παρουσιάσεις PowerPoint χρησιμοποιώντας C++"
---
{{% alert color="primary" %}}

Έχει παρατηρηθεί ότι τα φύλλα Excel που είναι ενσωματωμένα ως αντικείμενα OLE σε παρουσίαση PowerPoint μέσω των στοιχείων Aspose αλλάζουν μέγεθος σε άγνωστη κλίμακα μετά την πρώτη ενεργοποίηση. Αυτή η συμπεριφορά δημιουργεί ορατή διαφορά στην παρουσίαση μεταξύ των καταστάσεων πριν και μετά την ενεργοποίηση του αντικειμένου OLE. Έχουμε διερευνήσει το πρόβλημα αναλυτικά και παρέχουμε μια λύση, η οποία περιγράφεται σε αυτό το άρθρο.

{{% /alert %}}

## **Παρασκήνιο**

Στο άρθρο [Manage OLE](/slides/el/cpp/manage-ole/) εξηγήσαμε πώς να προσθέσετε ένα πλαίσιο OLE σε μια παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides for C++. Για να αντιμετωπίσουμε το [object preview issue](/slides/el/cpp/object-preview-issue-when-adding-oleobjectframe/), αναθέσαμε μια εικόνα της περιοχής του επιλεγμένου φύλλου στο πλαίσιο αντικειμένου OLE. Στην τελική παρουσίαση, όταν κάνετε διπλό κλικ στο πλαίσιο αντικειμένου OLE που εμφανίζει την εικόνα του φύλλου, το βιβλίο εργασίας του Excel ενεργοποιείται. Οι τελικοί χρήστες μπορούν να κάνουν τις επιθυμητές αλλαγές στο πραγματικό βιβλίο εργασίας του Excel και, στη συνέχεια, να επιστρέψουν στη διαφάνεια κάνοντας κλικ εκτός του ενεργοποιημένου βιβλίου εργασίας. Το μέγεθος του πλαισίου αντικειμένου OLE θα αλλάξει όταν ο χρήστης επιστρέψει στη διαφάνειά του. Ο παράγοντας αλλαγής μεγέθους θα διαφέρει ανάλογα με το μέγεθος του πλαισίου αντικειμένου OLE και του ενσωματωμένου βιβλίου εργασίας Excel. 

## **Αιτία αλλαγής μεγέθους**

Δεδομένου ότι το βιβλίο εργασίας του Excel διαθέτει το δικό του μέγεθος παραθύρου, προσπαθεί να διατηρήσει το αρχικό του μέγεθος κατά την πρώτη ενεργοποίηση. Από την άλλη πλευρά, το πλαίσιο αντικειμένου OLE έχει το δικό του μέγεθος. Σύμφωνα με τη Microsoft, όταν το βιβλίο εργασίας του Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος ώστε να διατηρηθούν οι σωστές αναλογίες ως μέρος της διαδικασίας ενσωμάτωσης. Η αλλαγή μεγέθους συμβαίνει με βάση τις διαφορές μεταξύ του μεγέθους του παραθύρου του Excel και του μεγέθους και της θέσης του πλαισίου αντικειμένου OLE.

## **Λύση λειτουργίας**

Υπάρχουν δύο πιθανές λύσεις για την αποφυγή του φαινομένου αλλαγής μεγέθους.

- Κλιμακώστε το μέγεθος του πλαισίου OLE στην παρουσίαση PowerPoint ώστε να ταιριάζει με το ύψος και το πλάτος του επιθυμητού αριθμού γραμμών και στηλών στο πλαίσιο OLE.
- Κρατήστε το μέγεθος του πλαισίου OLE σταθερό και κλιμακώστε το μέγεθος των συμμετέχουσων γραμμών και στηλών ώστε να χωράει στο επιλεγμένο μέγεθος πλαισίου OLE.

### **Κλιμάκωση του Μεγέθους Πλαισίου OLE**

Σε αυτήν την προσέγγιση, θα μάθουμε πώς να ορίζουμε το μέγεθος του πλαισίου OLE του ενσωματωμένου βιβλίου εργασίας Excel ώστε να ταιριάζει με το συνολικό μέγεθος των συμμετέχουσων γραμμών και στηλών στο φύλλο Excel.

Έστω ότι έχουμε ένα πρότυπο φύλλο Excel και θέλουμε να το προσθέσουμε σε μια παρουσίαση ως πλαίσιο OLE. Σε αυτό το σενάριο, το μέγεθος του πλαισίου αντικειμένου OLE θα υπολογιστεί πρώτα με βάση το συνολικό ύψος των γραμμών και το συνολικό πλάτος των στηλών που συμμετέχουν στο βιβλίο εργασίας. Στη συνέχεια, θα ορίσουμε το μέγεθος του πλαισίου OLE σε αυτήν την υπολογισμένη τιμή. Για να αποφύγουμε το κόκκινο μήνυμα «EMBEDDED OLE OBJECT» για το πλαίσιο OLE στο PowerPoint, θα καταγράψουμε επίσης μια εικόνα των επιθυμητών τμημάτων των γραμμών και στηλών στο βιβλίο εργασίας και θα την ορίσουμε ως εικόνα πλαισίου OLE.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Ορίστε το εμφανιζόμενο μέγεθος όταν το αρχείο βιβλίου εργασίας χρησιμοποιείται ως αντικείμενο OLE στο PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Λάβετε το πλάτος και το ύψος της εικόνας OLE σε μονάδες point.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Πρέπει να χρησιμοποιήσουμε το τροποποιημένο βιβλίο εργασίας.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Προσθέστε την εικόνα OLE στους πόρους της παρουσίασης.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Δημιουργήστε το πλαίσιο αντικειμένου OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **Κλιμάκωση του Μεγέθους Περιοχής Κελιών**

Σε αυτήν την προσέγγιση, θα μάθουμε πώς να κλιμακώσουμε το ύψος των συμμετέχουσων γραμμών και το πλάτος των συμμετέχουσων στηλών ώστε να ταιριάζει με ένα προσαρμοσμένο μέγεθος πλαισίου OLE.

Έστω ότι έχουμε ένα πρότυπο φύλλο Excel και θέλουμε να το προσθέσουμε σε μια παρουσίαση ως πλαίσιο OLE. Σε αυτό το σενάριο, θα ορίσουμε το μέγεθος του πλαισίου OLE και θα κλιμακώσουμε το μέγεθος των γραμμών και στηλών που συμμετέχουν στην περιοχή του πλαισίου OLE. Στη συνέχεια, θα αποθηκεύσουμε το βιβλίο εργασίας σε ροή για να εφαρμόσουμε τις αλλαγές και θα το μετατρέψουμε σε πίνακα byte ώστε να το προσθέσουμε στο πλαίσιο OLE. Για να αποφύγουμε το κόκκινο μήνυμα «EMBEDDED OLE OBJECT» για το πλαίσιο OLE στο PowerPoint, θα καταγράψουμε επίσης μια εικόνα των επιθυμητών τμημάτων των γραμμών και στηλών στο βιβλίο εργασίας και θα την ορίσουμε ως εικόνα πλαισίου OLE.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Ορίστε το εμφανιζόμενο μέγεθος όταν το αρχείο βιβλίου εργασίας χρησιμοποιείται ως αντικείμενο OLE στο PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Κλιμακώστε την περιοχή κελιών ώστε να ταιριάζει με το μέγεθος του πλαισίου.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Πρέπει να χρησιμοποιήσουμε το τροποποιημένο βιβλίο εργασίας.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Προσθέστε την εικόνα OLE στους πόρους της παρουσίασης.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Δημιουργήστε το πλαίσιο αντικειμένου OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
/// <param name="width">Το αναμενόμενο πλάτος της περιοχής κελιών σε μονάδες point.</param>
/// <param name="height">Το αναμενόμενο ύψος της περιοχής κελιών σε μονάδες point.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cpp
SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **Συμπέρασμα**

{{% alert color="primary" %}}

Υπάρχουν δύο προσεγγίσεις για την επίλυση του προβλήματος αλλαγής μεγέθους του φύλλου εργασίας. Η επιλογή της κατάλληλης προσέγγισης εξαρτάται από τις συγκεκριμένες απαιτήσεις και την περίπτωση χρήσης. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο, ανεξάρτητα από το αν οι παρουσιάσεις δημιουργούνται από πρότυπο ή από την αρχή. Επιπλέον, δεν υπάρχει όριο στο μέγεθος του πλαισίου αντικειμένου OLE σε αυτή τη λύση.

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Γιατί ένα ενσωματωμένο φύλλο Excel αλλάζει μέγεθος όταν ενεργοποιείται για πρώτη φορά στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να διατηρήσει το αρχικό μέγεθος του παραθύρου όταν ενεργοποιείται, ενώ το πλαίσιο αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος ώστε να διατηρηθεί η αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει αλλαγή μεγέθους.

**Μπορεί κανείς να αποτρέψει εντελώς αυτήν την αλλαγή μεγέθους;**

Ναι. Με την κλιμάκωση του πλαισίου OLE ώστε να ταιριάζει με το μέγεθος της περιοχής κελιών του Excel ή με την κλιμάκωση της περιοχής κελιών ώστε να ταιριάζει με το επιθυμητό μέγεθος πλαισίου OLE, μπορείτε να αποτρέψετε την ανεπιθύμητη αλλαγή μεγέθους.

**Ποια μέθοδο κλιμάκωσης πρέπει να χρησιμοποιήσω, κλιμάκωση πλαισίου OLE ή κλιμάκωση περιοχής κελιών;**

Επιλέξτε **OLE frame scaling** εάν θέλετε να διατηρήσετε τα αρχικά μεγέθη γραμμών και στηλών του Excel. Επιλέξτε **cell range scaling** εάν θέλετε ένα σταθερό μέγεθος για το πλαίσιο OLE στην παρουσίασή σας.

**Θα λειτουργούν αυτές οι λύσεις αν η παρουσίασή μου βασίζεται σε πρότυπο;**

Ναι. Και οι δύο λύσεις λειτουργούν για παρουσιάσεις που δημιουργούνται από πρότυπα καθώς και από την αρχή.

**Υπάρχει όριο στο μέγεθος του πλαισίου OLE όταν χρησιμοποιούνται αυτές οι μέθοδοι;**

Όχι. Μπορείτε να ορίσετε το πλαίσιο αντικειμένου OLE σε οποιοδήποτε μέγεθος, αρκεί να προσαρμόσετε τη κλίμακα αναλόγως.

**Υπάρχει τρόπος να αποφευχθεί το κείμενο αντικατάστασης «EMBEDDED OLE OBJECT» στο PowerPoint;**

Ναι. Λαμβάνοντας ένα στιγμιότυπο της επιθυμητής περιοχής κελιών του Excel και ορίζοντάς το ως εικόνα κράτησης θέσης του πλαισίου OLE, μπορείτε να εμφανίσετε μια προσαρμοσμένη εικόνα προεπισκόπησης αντί του προεπιλεγμένου κειμένου.

## **Σχετικά Άρθρα**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/el/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)