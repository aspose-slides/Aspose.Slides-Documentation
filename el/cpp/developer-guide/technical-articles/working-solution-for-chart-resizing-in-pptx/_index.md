---
title: Λύση για τη Μεγέθυνση του Διαγράμματος σε PPTX
type: docs
weight: 60
url: /el/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- αλλαγή μεγέθους διαγράμματος
- διάγραμμα Excel
- αντικείμενο OLE
- ενσωμάτωση διαγράμματος
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Διορθώστε την απρόσμενη αλλαγή μεγέθους του διαγράμματος στο PPTX κατά τη χρήση ενσωματωμένων αντικειμένων Excel OLE με το Aspose.Slides για C++. Ορίστε σταθερές διαστάσεις διαγράμματος ώστε να διατηρείται η συνοχή των μεγέθων του διαγράμματος και του πλαισίου OLE."
---
## **Υπόβαθρο**

Τα διαγράμματα Excel που ενσωματώνονται ως αντικείμενα OLE σε παρουσιάσεις PowerPoint χρησιμοποιώντας συστατικά Aspose μπορούν να αλλάξουν μέγεθος μετά την πρώτη τους ενεργοποίηση. Αυτό μπορεί να προκαλέσει εμφανή διαφορά στην εμφάνιση του διαγράμματος πριν και μετά την ενεργοποίηση. Αυτό το άρθρο εξηγεί γιατί συμβαίνει η αλλαγή μεγέθους και δείχνει πώς να την αποτρέψετε ταιριάζοντας σταθερές διαστάσεις διαγράμματος με το πλαίσιο OLE.

Στο [Δημιουργία Διαγραμμάτων Excel και Ενσωμάτωσή τους ως Αντικείμενα OLE σε Παρουσιάσεις](/slides/el/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), εξηγήσαμε πώς να δημιουργήσουμε ένα διάγραμμα Excel με το Aspose.Cells για C++ και να το ενσωματώσουμε σε μια παρουσίαση PowerPoint χρησιμοποιώντας το Aspose.Slides για C++. Για να αντιμετωπίσουμε το [πρόβλημα προεπισκόπησης αντικειμένου](/slides/el/cpp/object-preview-issue-when-adding-oleobjectframe/), αντιστοιχίσαμε την εικόνα του διαγράμματος στο πλαίσιο OLE αντικειμένου του διαγράμματος. Στην παραγόμενη παρουσίαση, όταν κάνετε διπλό κλικ στο πλαίσιο OLE αντικειμένου που εμφανίζει την εικόνα του διαγράμματος, το διάγραμμα Excel ενεργοποιείται. Οι χρήστες μπορούν να επεξεργαστούν το ενσωματωμένο βιβλίο εργασίας Excel και, στη συνέχεια, να επιστρέψουν στη διαφάνεια κάνοντας κλικ εκτός του ενεργοποιημένου βιβλίου εργασίας. Το μέγεθος του πλαισίου OLE αντικειμένου αλλάζει όταν ο χρήστης επιστρέφει στη διαφάνεια, και ο συντελεστής αλλαγής μεγέθους διαφέρει ανάλογα με τα αρχικά μεγέθη τόσο του πλαισίου OLE αντικειμένου όσο και του ενσωματωμένου βιβλίου εργασίας Excel.

## **Αιτία της Αλλαγής Μεγέθους**

Το ενσωματωμένο βιβλίο εργασίας Excel διαθέτει τις δικές του διαστάσεις παραθύρου, τις οποίες το Excel προσπαθεί να διατηρήσει όταν το αντικείμενο ενεργοποιείται για πρώτη φορά. Το πλαίσιο OLE στη διαφάνεια έχει ανεξάρτητα ορισμένες διαστάσεις. Όταν το βιβλίο εργασίας Excel ενεργοποιείται, το Excel και το PowerPoint διαπραγματεύονται το μέγεθος του αντικειμένου ώστε να διατηρηθούν οι αναλογίες του ως μέρος της διαδικασίας ενσωμάτωσης. Οι διαφορές μεταξύ του παραθύρου του βιβλίου εργασίας και του πλαισίου OLE μπορούν επομένως να προκαλέσουν αλλαγή μεγέθους του αντικειμένου.

## **Λύση**

Ταιριάξτε το μέγεθος του διαγράμματος με το πλαίσιο OLE στη διαφάνεια και διατηρήστε τις διαστάσεις του διαγράμματος ανεξάρτητες από το παράθυρο του βιβλίου εργασίας. Αυτή η λύση λειτουργεί με μια νέα παρουσίαση ή με υπάρχον πρότυπο.

Το παράδειγμα απαιτεί το Aspose.Cells για C++ και το Aspose.Slides για C++. Δημιουργεί ένα απλό διάγραμμα στήλης σε ενεργό φύλλο διαγράμματος και ενσωματώνει το βιβλίο εργασίας σε μορφή XLS. Δεν ορίζεται εικόνα προεπισκόπησης διαγράμματος· το διάγραμμα γίνεται ορατό όταν το αντικείμενο OLE ενεργοποιείται στο PowerPoint.

Τοποθετήστε τον κώδικα του παραδείγματος στο σημείο εισόδου της εφαρμογής σας, με τις δηλώσεις #include στο επίπεδο αρχείου. Αρχικοποιήστε το Aspose.Cells πριν δημιουργήσετε τα αντικειμένα του και απελευθερώστε τους πόρους του μετά την καταστροφή αυτών των αντικειμένων. Το παράδειγμα αντιγράφει το διάνυσμα bytes του βιβλίου εργασίας που επιστρέφεται από το Aspose.Cells στην τύπου πίνακα που δέχεται το Aspose.Slides.

Το παράδειγμα δημιουργεί μια νέα παρουσίαση με πλαίσιο OLE 9,5 × 4 ίντσες, τοποθετημένο 0,5 ίντσες από την αριστερή πλευρά και 1 ίντσα από το πάνω μέρος. Οι συντεταγμένες και οι διαστάσεις της διαφάνειας είναι σε points (72 points ανά ίντσα). Για υπάρχουσα παρουσίαση, δείτε [Χρήση Προτύπου](#use-a-template).

## **Ορισμός Σταθερού Μεγέθους Διαγράμματος**

Ορίστε το [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) σε false ώστε οι διαστάσεις του διαγράμματος να είναι ανεξάρτητες από το παράθυρο του βιβλίου εργασίας. Ορίστε τις διαστάσεις του [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) μέσω των [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) και [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), μετατρέποντας τα points σε pixels χρησιμοποιώντας 96 pixels ανά ίντσα: ένα πλαίσιο 684 × 288 points αντιστοιχεί σε διάγραμμα 912 × 384 pixels. Ορίστε το [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) στην τιμή Custom του [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). Το παράδειγμα ενσωματώνει το βιβλίο εργασίας με το [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) και αποθηκεύει μια παρουσίαση με πλαίσιο OLE 9.5 × 4 ίντσες.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Οι συντεταγμένες και οι διαστάσεις της διαφάνειας είναι σε points (72 points ανά ίντσα).
    auto width = 684.f; // 9.5 ίντσες.
    auto height = 288.f; // 4 ίντσες.

    chart.SetSizeWithWindow(false);
    // Μετατροπή points σε pixel διαγράμματος χρησιμοποιώντας 96 pixel ανά ίντσα.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Αντιγράψτε το διάνυσμα byte του Cells στον τύπο πίνακα που δέχεται το Slides.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Χρήση Προτύπου**

Η λογική μεγέθυνσης είναι η ίδια για υπάρχουσα παρουσίαση. Για να προσαρμόσετε το παράδειγμα:

1. Φορτώστε την παρουσίαση προτύπου αντί να δημιουργήσετε μια κενή παρουσίαση.
2. Ελέγξτε ότι η πρώτη διαφάνεια περιέχει τουλάχιστον τρία σχήματα, έπειτα χρησιμοποιήστε το σχήμα με δείκτη 2 ως placeholder.
3. Πάρτε το πλάτος και το ύψος του πλαισίου από αυτό το σχήμα αντί να χρησιμοποιήσετε τις σταθερές τιμές 684 και 288. Διατηρήστε αμετάβλητους τους υπολογισμούς μεγέθους.
4. Προσθέστε το πλαίσιο OLE στη θέση του placeholder αντί των σταθερών συντεταγμένων 36 και 72.
5. Αφαιρέστε το placeholder πριν αποθηκεύσετε την παρουσίαση.

## **Συχνές Ερωτήσεις**

**Γιατί το ενσωματωμένο διάγραμμα Excel μου αλλάζει μέγεθος μετά την ενεργοποίηση του στο PowerPoint;**

Αυτό συμβαίνει επειδή το Excel προσπαθεί να επαναφέρει το αρχικό μέγεθος του παραθύρου κατά την πρώτη ενεργοποίηση, ενώ το πλαίσιο αντικειμένου OLE στο PowerPoint έχει τις δικές του διαστάσεις. Το PowerPoint και το Excel διαπραγματεύονται το μέγεθος ώστε να διατηρηθεί η αναλογία διαστάσεων, κάτι που μπορεί να προκαλέσει την αλλαγή μεγέθους.

**Πώς μπορώ να διατηρήσω σταθερά τα μεγέθη του διαγράμματος και του πλαισίου OLE;**

Ορίστε σταθερές διαστάσεις διαγράμματος που ταιριάζουν με το πλαίσιο OLE και χρησιμοποιήστε προσαρμοσμένο μέγεθος εκτυπώσιμου διαγράμματος πριν την ενσωμάτωση του βιβλίου εργασίας. Το παραπάνω παράδειγμα δείχνει τις απαιτούμενες ρυθμίσεις και τις μετατροπές μονάδων.

**Είναι επαρκής η αντιστοίχηση του μεγέθους του παραθύρου του βιβλίου εργασίας;**

Η αντιστοίχηση μόνο του μεγέθους του παραθύρου του βιβλίου εργασίας δεν αποτρέπει αξιόπιστα το πλαίσιο OLE από το να αλλάζει μέγεθος μετά την ενεργοποίηση. Χρησιμοποιήστε σταθερές διαστάσεις διαγράμματος όπως φαίνεται στο παράδειγμα.

**Λειτουργεί αυτή η λύση τόσο με παρουσιάσεις βασισμένες σε πρότυπο όσο και με νέες παρουσιάσεις;**

Ναι. Για πρότυπο, χρησιμοποιήστε τις διαστάσεις και τη θέση του placeholder. Για νέα παρουσίαση, καθορίστε απευθείας τις διαστάσεις και τη θέση του πλαισίου.

**Μπορώ να χρησιμοποιήσω αυτό το παράδειγμα με διαγράμματα που δημιουργήθηκαν σε άλλα προγράμματα λογιστικών φύλλων;**

Το παράδειγμα χρησιμοποιεί ένα βιβλίο εργασίας Excel που δημιουργήθηκε με το Aspose.Cells. Δεν δείχνει τη συμπεριφορά ενεργοποίησης για άλλα προγράμματα λογιστικών φύλλων.

## **Σχετικές Ενότητες**

- [Δημιουργία Διαγραμμάτων Excel και Ενσωμάτωσή τους ως Αντικείμενα OLE σε Παρουσιάσεις](/slides/el/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)