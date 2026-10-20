---
title: Δημιουργία διαγραμμάτων Excel και ενσωμάτωση τους σε παρουσιάσεις ως αντικείμενα OLE
type: docs
weight: 40
url: /el/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Διάγραμμα Excel
- Ενσωμάτωση διαγράμματος
- Αντικείμενο OLE
- PowerPoint
- Παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε ένα διάγραμμα Excel με το Aspose.Cells για C++ και ενσωματώστε το βιβλίο εργασίας σε μια παρουσίαση PowerPoint με το Aspose.Slides, περιλαμβάνοντας μια προεπισκόπηση διαγράμματος."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε ένα διάγραμμα στηλών Excel με Aspose.Cells for C++ και να ενσωματώσετε το βιβλίο εργασίας του σε μια παρουσίαση PowerPoint με Aspose.Slides for C++. Το ενσωματωμένο βιβλίο εργασίας περιέχει τόσο τα δεδομένα προέλευσης όσο και το διάγραμμα. Μια ξεχωριστή προεπισκόπηση PNG εμφανίζει το διάγραμμα στη διαφάνεια πριν ενεργοποιηθεί το αντικείμενο OLE.

Το αποτέλεσμα είναι ένα ενσωματωμένο αντικείμενο Excel, όχι ένα εγγενές διάγραμμα PowerPoint. Η επεξεργασία του βιβλίου εργασίας μέσω OLE απαιτεί μια εφαρμογή επιφάνειας εργασίας που υποστηρίζει ενεργοποίηση OLE και μια συμβατή εγκατάσταση του Excel.

## **Προαπαιτούμενα**

Διαμορφώστε το έργο C++ σας με τις κεφαλίδες και τις βιβλιοθήκες για Aspose.Cells for C++ και Aspose.Slides for C++. Τοποθετήστε τον κώδικα παραδείγματος στο σημείο εισόδου της εφαρμογής σας, με τις δηλώσεις include σε επίπεδο αρχείου. Δεν απαιτείται Microsoft Office για τη δημιουργία της παρουσίασης με αυτές τις βιβλιοθήκες.

Δεν απαιτούνται αρχεία εισόδου: το παράδειγμα δημιουργεί τα δεδομένα και το διάγραμμα στη μνήμη, στη συνέχεια γράφει `OutputChart.pptx` στον τρέχοντα φάκελο εργασίας. Εφαρμόστε άδειες για και τα δύο προϊόντα όταν εκτελείται εκτός λειτουργίας αξιολόγησης.

## **Πώς Λειτουργεί η Ενσωμάτωση**

1. Δημιουργήστε ένα βιβλίο εργασίας με ένα φύλλο δεδομένων και ένα φύλλο διαγράμματος.  
1. Κάντε το φύλλο διαγράμματος ενεργό ώστε το βιβλίο εργασίας να ανοίγει στο διάγραμμα.  
1. Ορίστε το εύρος εμφάνισης OLE του βιβλίου εργασίας και αποδώστε το διάγραμμα σε PNG.  
1. Αποθηκεύστε το βιβλίο εργασίας ως XLSX στη μνήμη και ενσωματώστε αυτά τα bytes σε μια διαφάνεια.  
1. Ορίστε το PNG ως προεπισκόπηση του αντικειμένου OLE και αποθηκεύστε την παρουσίαση ως PPTX.

Το εύρος εμφάνισης του βιβλίου εργασίας και το πλαίσιο στη διαφάνεια έχουν διαφορετικούς ρόλους. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) δέχεται δείκτες γραμμής/στήλης με μηδενική βάση. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) αντίθετα δέχεται την άνω γραμμή, αριστερή στήλη, κάτω γραμμή και δεξιά στήλη. Το παράδειγμα χρησιμοποιεί τη γραμμή 55 και τη στήλη 25 ως τα κάτω‑δεξιά όρια· αυτές οι τιμές είναι επιλογές διάταξης, όχι ο αριθμός των γραμμών ή στηλών δεδομένων.

Το πλαίσιο της διαφάνειας χρησιμοποιεί μονάδες points. Το παράδειγμα το τοποθετεί στο κέντρο της διαφάνειας διατηρώντας την αναλογία διαστάσεων του PNG, αντί να τεντώσει την προεπισκόπηση για να γεμίσει τη διαφάνεια.

## **Δημιουργία και Ενσωμάτωση του Διαγράμματος**

Το παρακάτω πλήρες παράδειγμα γεμίζει το `DataSheet` με τέσσερις γραμμές και πέντε στήλες τιμών. Κάθε γραμμή γίνεται μια σειρά διαγράμματος. Το `ChartSheet` επιλέγεται ως ενεργό φύλλο πριν αποθηκευτεί το βιβλίο εργασίας.

Το βιβλίο εργασίας αποθηκεύεται ρητά ως XLSX, ταιριάζοντας με την επέκταση `xlsx` που περνάται στο [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/). Το PNG φορτώνεται από μια ροή μνήμης χωρίς ενδιάμεση μετατροπή bitmap. Το Aspose.Cells επιστρέφει διανύσματα byte, τα οποία το παράδειγμα αντιγράφει στο τύπο πίνακα που αποδέχεται το Aspose.Slides. Αρχικοποιήστε το Aspose.Cells πριν χρησιμοποιήσετε τα αντικείμενά του, και ελευθερώστε τους πόρους του αφού αυτά τα αντικείμενα έχουν καταστραφεί. Η ανάθεση μέσω του [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) αντικαθιστά το προεπιλεγμένο placeholder OLE.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Initialize Cells before creating any of its objects.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // Αποδώστε την προεπισκόπηση του διαγράμματος και αποθηκεύστε ξεχωριστά το επεξεργάσιμο βιβλίο εργασίας.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Αντιγράψτε τα buffers του Cells στον τύπο πίνακα που χρησιμοποιείται από το Slides.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // Προσαρμόστε την προεπισκόπηση μέσα στη διαφάνεια χωρίς να αλλάξετε την αναλογία διαστάσεων.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// Απελευθερώστε τους πόρους του Cells μετά την καταστροφή όλων των αντικειμένων Cells.
Aspose::Cells::Cleanup();
```

## **Αναμενόμενο Αποτέλεσμα**

`OutputChart.pptx` περιέχει μία διαφάνεια με ένα ενσωματωμένο βιβλίο εργασίας Excel και μια προεπισκόπηση διαγράμματος. Το βιβλίο εργασίας περιέχει τα αρχικά δεδομένα και ένα διάγραμμα στηλών με τέσσερις σειρές. Η προεπισκόπηση είναι κεντραρισμένη στη διαφάνεια και διατηρεί τις αναλογίες της.

![Διάγραμμα στηλών Excel ως προεπισκόπηση ενσωματωμένου βιβλίου εργασίας](excel-chart-ole-preview.png)

Σε περιβάλλον PowerPoint επιφάνειας εργασίας με εγκατεστημένο το Excel, κάντε διπλό‑κλικ στο αντικείμενο για να το ενεργοποιήσετε και να επεξεργαστείτε το ενσωματωμένο βιβλίο εργασίας. Η ενεργοποίηση και η επεξεργασία εξαρτώνται από την υποστήριξη OLE και τις ρυθμίσεις ασφαλείας της εφαρμογής‑κεντρικού.

## **Συχνές Ερωτήσεις**

**Γιατί χρειάζεται εικόνα προεπισκόπησης;**

Το ενσωματωμένο βιβλίο εργασίας και η προεπισκόπηση στη διαφάνεια είναι ξεχωριστό περιεχόμενο. Παρέχετε μια εικόνα διαγράμματος ώστε η διαφάνεια να δείχνει το διάγραμμα αντί του προεπιλεγμένου placeholder «EMBEDDED OLE OBJECT». Δείτε το [Πρόβλημα Προεπισκόπησης Αντικειμένου κατά την Προσθήκη OleObjectFrame](/slides/el/cpp/object-preview-issue-when-adding-oleobjectframe/).

**Ενημερώνεται αυτόματα η προεπισκόπηση όταν αλλάζω το βιβλίο εργασίας στον κώδικα;**

Η προεπισκόπηση θεωρείται στιγμιότυπο. Όταν ενημερώνετε τα δεδομένα του βιβλίου εργασίας προγραμματικά, δημιουργήστε ξανά την εικόνα του διαγράμματος και αντικαταστήστε τη προεπισκόπηση καθώς και τα ενσωματωμένα δεδομένα του βιβλίου εργασίας.

**Μπορώ να χρησιμοποιήσω XLS αντί για XLSX;**

Ναι. Αποθηκεύστε το βιβλίο εργασίας σε μορφή XLS και χρησιμοποιήστε `xls` ως επέκταση των ενσωματωμένων δεδομένων. Η επέκταση πρέπει να ταιριάζει με την πραγματική μορφή του βιβλίου εργασίας· η αλλαγή μόνο της επέκτασης δεν μετατρέπει τα δεδομένα.

**Γιατί το αντικείμενο μπορεί να αλλάξει μέγεθος μετά την ενεργοποίηση;**

Η εφαρμογή‑κεντρική μπορεί να ενημερώσει την παρουσίαση του αντικειμένου OLE όταν ενεργοποιήσει το βιβλίο εργασίας. Το εύρος εμφάνισης OLE του βιβλίου εργασίας και οι διαστάσεις του πλαισίου της διαφάνειας είναι και τα δύο σημαντικά. Δείτε την [Λύση Εργασίας για Αλλαγή Μεγέθους Διαγράμματος σε PPTX](/slides/el/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Σχετικές Ενότητες**

- [Λύση Εργασίας για Αλλαγή Μεγέθους Διαγράμματος σε PPTX](/slides/el/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Πρόβλημα Προεπισκόπησης Αντικειμένου κατά την Προσθήκη OleObjectFrame](/slides/el/cpp/object-preview-issue-when-adding-oleobjectframe/)