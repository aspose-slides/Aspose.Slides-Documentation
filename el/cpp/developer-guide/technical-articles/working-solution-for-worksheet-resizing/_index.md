---
title: Λύση λειτουργίας για την αλλαγή μεγέθους του φύλλου εργασίας
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
- Aspose.Slides για C++
description: "Λύση λειτουργίας για την αλλαγή μεγέθους του φύλλου εργασίας σε παρουσιάσεις PowerPoint χρησιμοποιώντας C++"
---
{{% alert color="info" title="Σημείωση" %}}
Τα φύλλα εργασίας του Excel που είναι ενσωματωμένα ως αντικείμενα OLE σε παρουσίαση PowerPoint χρησιμοποιώντας τα στοιχεία Aspose ενδέχεται να αλλάξουν μέγεθος απρόσμενα μετά την πρώτη ενεργοποίησή τους. Αυτή η συμπεριφορά δημιουργεί μια εμφανή οπτική διαφορά μεταξύ του αντικειμένου OLE πριν και μετά την ενεργοποίηση. Το άρθρο αυτό εξηγεί το πρόβλημα και περιγράφει δύο τρόπους αντιμετώπισής του.
{{% /alert %}}

## **Υπόβαθρο**

Στο άρθρο [Διαχείριση OLE](/slides/el/cpp/manage-ole/), εξηγήσαμε πώς να προσθέσετε ένα πλαίσιο OLE σε παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides για C++. Για να αντιμετωπίσουμε το [πρόβλημα προεπισκόπησης αντικειμένου](/slides/el/cpp/object-preview-issue-when-adding-oleobjectframe/), αντιστοιχίσαμε μια εικόνα της επιλεγμένης περιοχής φύλλου εργασίας στο πλαίσιο αντικειμένου OLE. Στην τελική παρουσίαση, όταν κάνετε διπλό κλικ στο πλαίσιο αντικειμένου OLE που εμφανίζει την εικόνα του φύλλου, το βιβλίο εργασίας του Excel ενεργοποιείται. Οι τελικοί χρήστες μπορούν να κάνουν τις επιθυμητές αλλαγές στο πραγματικό βιβλίο εργασίας του Excel και στη συνέχεια να επιστρέψουν στη διαφάνεια κάνοντας κλικ εκτός του ενεργοποιημένου βιβλίου εργασίας του Excel. Το μέγεθος του πλαισίου αντικειμένου OLE θα αλλάξει όταν ο χρήστης επιστρέψει στη διαφάνεια. Ο παράγοντας αλλαγής μεγέθους θα διαφέρει ανάλογα με το μέγεθος του πλαισίου αντικειμένου OLE και του ενσωματωμένου βιβλίου εργασίας του Excel.

## **Αιτία αλλαγής μεγέθους**

Δεδομένου ότι το βιβλίο εργασίας του Excel έχει το δικό του μέγεθος παραθύρου, προσπαθεί να διατηρήσει το αρχικό του μέγεθος κατά την πρώτη ενεργοποίηση. Από την άλλη πλευρά, το πλαίσιο αντικειμένου OLE έχει το δικό του μέγεθος. Σύμφωνα με τη Microsoft, όταν το βιβλίο εργασίας του Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος ώστε να διατηρούν τις σωστές αναλογίες ως μέρος της διαδικασίας ενσωμάτωσης. Η αλλαγή μεγέθους συμβαίνει βάσει των διαφορών μεταξύ του μεγέθους του παραθύρου του Excel και του μεγέθους και της θέσης του πλαισίου αντικειμένου OLE.

## **Λύση**

Υπάρχουν δύο πιθανές λύσεις για την αποφυγή του φαινομένου αλλαγής μεγέθους.

- Κλιμακώστε το πλαίσιο OLE στην παρουσίαση PowerPoint ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων γραμμών και στηλών.
- Διατηρήστε το μέγεθος του πλαισίου OLE σταθερό και κλιμακώστε τις επιλεγμένες γραμμές και στήλες ώστε να ταιριάζουν μέσα σε αυτό.

### **Κλιμάκωση του μεγέθους του πλαισίου OLE**

Αυτή η προσέγγιση ορίζει το μέγεθος του πλαισίου OLE ώστε να ταιριάζει με το συνολικό ύψος και πλάτος των επιλεγμένων γραμμών και στηλών στο ενσωματωμένο φύλλο εργασίας του Excel.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας Excel και επιλέγει τις πρώτες 10 γραμμές και 13 στήλες του πρώτου φύλλου του χρησιμοποιώντας δείκτες μηδενικής βάσης. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) ορίζει το εμφανιζόμενο εύρος. Η προεπισκόπηση αποδίδεται στα 96 DPI, και οι διαστάσεις των εικονοστοιχείων της μετατρέπονται σε πόντους χρησιμοποιώντας 72 πόντους ανά ίντσα. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) ενσωματώνει το τροποποιημένο βιβλίο εργασίας σε ένα πλαίσιο με αυτές τις διαστάσεις. Η προεπισκόπηση αντιστοιχίζεται μέσω [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) για την αντικατάσταση του κράτηματος θέσης "EMBEDDED OLE OBJECT" στην αποθηκευμένη παρουσίαση.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We need to use the modified workbook.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add the OLE image to the presentation resources.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

Ο βοηθός προεπισκόπησης χρησιμοποιεί το [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) για την επιλογή του εύρους και αφαιρεί τα περιθώρια, τις κεφαλίδες και τα υποσέλιδα. Με ενεργοποιημένο το [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/), το [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) αποδίδει το εύρος ως εικόνα PNG. Ο βοηθός αντιγράφει τα δεδομένα της αποδοθείσας εικόνας σε μια νέα ροή μνήμης τοποθετημένη στην αρχή της για χρήση στην παρουσίαση.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

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

### **Κλιμάκωση του μεγέθους του εύρους κελιών**

Αυτή η προσέγγιση κλιμακώνει τα ύψη των επιλεγμένων γραμμών και τα πλάτη των επιλεγμένων στηλών ώστε να ταιριάζουν με ένα προσαρμοσμένο μέγεθος πλαισίου OLE.

Το παράδειγμα φορτώνει ένα υπάρχον βιβλίο εργασίας Excel και επιλέγει τις πρώτες 10 γραμμές και 13 στήλες του πρώτου φύλλου του χρησιμοποιώντας δείκτες μηδενικής βάσης. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) ορίζει το εμφανιζόμενο εύρος, και ο παρακάτω βοηθός κλιμακώνει αυτό το εύρος ώστε να χωρέσει σε ένα πλαίσιο 400 πόντων πλάτος και 100 πόντων ύψος. Μετά την αποθήκευση του τροποποιημένου βιβλίου εργασίας σε έναν πίνακα byte, το [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) το ενσωματώνει στο καθορισμένο μέγεθος. Μια προεπισκόπηση αποδίδεται στα 96 DPI και αντιστοιχίζεται μέσω [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/), έτσι ώστε η αποθηκευμένη παρουσίαση να εμφανίζει τα επιλεγμένα κελιά αντί του προεπιλεγμένου κράτηματος θέσης.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

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

// Κλιμακώστε το εύρος κελιών ώστε να ταιριάζει στο μέγεθος του πλαισίου.
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

Ο βοηθός κλιμάκωσης υπολογίζει ξεχωριστά λόγους πλάτους και ύψους για το επιλεγμένο εύρος, διατηρώντας τις σχετικές αναλογίες πλάτους των στηλών του και ύψους των γραμμών του. Μετατρέπει τις υπολογιζόμενες διαστάσεις από πόντους σε ίντσες πριν τις εφαρμόσει με [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) και [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/). Το επιλεγμένο εύρος πρέπει να έχει μη μηδενικό πλάτος και ύψος.

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">Το αναμενόμενο πλάτος του εύρους κελιών σε πόντους.</param>
/// <param name="height">Το αναμενόμενο ύψος του εύρους κελιών σε πόντους.</param>
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

Αυτός ο βοηθός προεπισκόπησης αποδίδει το επαναμεγεθυμένο εύρος χρησιμοποιώντας το [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/). Χρησιμοποιεί το [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) για τον περιορισμό της εκτύπωσης σε εκείνο το εύρος, αφαιρεί τα περιθώρια, τις κεφαλίδες και τα υποσέλιδα, και επιστρέφει μια ροή PNG τοποθετημένη στην αρχή της.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

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

{{% alert color="info" title="Σημείωση" %}}
Υπάρχουν δύο προσεγγίσεις για τη διόρθωση του προβλήματος αλλαγής μεγέθους των φύλλων εργασίας. Επιλέξτε την προσέγγιση που ταιριάζει καλύτερα στις απαιτήσεις και τη χρήση σας. Και οι δύο προσεγγίσεις λειτουργούν με τον ίδιο τρόπο, είτε οι παρουσιάσεις δημιουργούνται από πρότυπο είτε από το μηδέν. Επιπλέον, δεν υπάρχει όριο στο μέγεθος του πλαισίου αντικειμένου OLE σε αυτήν τη λύση.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Γιατί το ενσωματωμένο φύλλο εργασίας Excel αλλάζει μέγεθος όταν ενεργοποιείται για πρώτη φορά στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να διατηρήσει το αρχικό μέγεθος παραθύρου όταν ενεργοποιείται, ενώ το πλαίσιο αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος για να διατηρήσουν την αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει αλλαγή μεγέθους.

**Μπορεί να αποτραπεί εντελώς αυτό το πρόβλημα αλλαγής μεγέθους;**

Ναι. Με την κλιμάκωση του πλαισίου OLE ώστε να ταιριάζει στο μέγεθος του εύρους κελιών του Excel ή με την κλιμάκωση του εύρους κελιών ώστε να ταιριάζει στο επιθυμητό μέγεθος πλαισίου OLE, μπορείτε να αποτρέψετε ανεπιθύμητες αλλαγές μεγέθους.

**Ποια μέθοδο κλιμάκωσης πρέπει να χρησιμοποιήσω, κλιμάκωση πλαισίου OLE ή κλιμάκωση εύρους κελιών;**

Επιλέξτε **OLE frame scaling** εάν θέλετε να διατηρήσετε τα αρχικά μεγέθη γραμμών και στηλών του Excel. Επιλέξτε **cell range scaling** εάν θέλετε ένα σταθερό μέγεθος για το πλαίσιο OLE στην παρουσίασή σας.

**Θα λειτουργούν αυτές οι λύσεις αν η παρουσίασή μου βασίζεται σε πρότυπο;**

Ναι. Και οι δύο λύσεις λειτουργούν για παρουσιάσεις που δημιουργούνται από πρότυπα και από το μηδέν.

**Υπάρχει κάποιο όριο στο μέγεθος του πλαισίου OLE όταν χρησιμοποιούνται αυτές οι μέθοδοι;**

Όχι. Μπορείτε να ορίσετε το πλαίσιο αντικειμένου OLE σε οποιοδήποτε μέγεθος όσο το κλιμακώνετε κατάλληλα.

**Υπάρχει τρόπος να αποτραπεί το κείμενο κράτησης θέσης "EMBEDDED OLE OBJECT" στο PowerPoint;**

Ναι. Με τη λήψη στιγμιότυπου του επιθυμητού εύρους κελιών του Excel και ορισμό του ως εικόνα κράτησης θέσης του πλαισίου OLE, μπορείτε να εμφανίσετε μια προσαρμοσμένη εικόνα προεπισκόπησης αντί του προεπιλεγμένου κράτηματος θέσης.

## **Σχετικά άρθρα**

[Δημιουργία γραφήματος Excel και ενσωμάτωσή του σε παρουσίαση ως αντικείμενο OLE](/slides/el/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)