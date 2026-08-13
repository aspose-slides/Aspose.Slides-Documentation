---
title: Διαχείριση OLE σε Παρουσιάσεις με C++
linktitle: Διαχείριση OLE
type: docs
weight: 40
url: /el/cpp/manage-ole/
keywords:
- αντικείμενο OLE
- Σύνδεση & Ενσωμάτωση Αντικειμένων
- προσθήκη OLE
- ενσωμάτωση OLE
- προσθήκη αντικειμένου
- ενσωμάτωση αντικειμένου
- προσθήκη αρχείου
- ενσωμάτωση αρχείου
- συνδεδεμένο αντικείμενο
- συνδεδεμένο αρχείο
- αλλαγή OLE
- εικονίδιο OLE
- τίτλος OLE
- εξαγωγή OLE
- εξαγωγή αντικειμένου
- εξαγωγή αρχείου
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Βελτιστοποιήστε τη διαχείριση αντικειμένων OLE σε αρχεία PowerPoint και OpenDocument με το Aspose.Slides for C++. Ενσωματώστε, ενημερώστε και εξάγετε το περιεχόμενο OLE απρόσκοπτα."
---
## **Εισαγωγή**

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) είναι τεχνολογία της Microsoft που επιτρέπει στα δεδομένα και τα αντικείμενα που δημιουργούνται σε μια εφαρμογή να τοποθετούνται σε άλλη εφαρμογή μέσω σύνδεσης ή ενσωμάτωσης. 
{{% /alert %}} 

Σκεφτείτε ένα διάγραμμα που δημιουργήθηκε στο MS Excel. Το διάγραμμα τοποθετείται στη συνέχεια σε μια διαφάνεια του PowerPoint. Αυτό το διάγραμμα Excel θεωρείται αντικείμενο OLE. 

- Ένα αντικείμενο OLE μπορεί να εμφανίζεται ως εικονίδιο. Σε αυτή την περίπτωση, όταν κάνετε διπλό κλικ στο εικονίδιο, το διάγραμμα ανοίγει στην σχετική του εφαρμογή (Excel), ή σας ζητείται να επιλέξετε μια εφαρμογή για το άνοιγμα ή την επεξεργασία του αντικειμένου. 
- Ένα αντικείμενο OLE μπορεί να εμφανίζει τα πραγματικά του περιεχόμενα, όπως τα δεδομένα ενός διαγράμματος. Σε αυτή την περίπτωση, το διάγραμμα ενεργοποιείται στο PowerPoint, φορτώνει η διεπαφή του διαγράμματος και μπορείτε να τροποποιήσετε τα δεδομένα του διαγράμματος μέσα στο PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/el/cpp/) σας επιτρέπει να εισάγετε αντικείμενα OLE σε διαφάνειες ως πλαίσια αντικειμένων OLE ([OleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/oleobjectframe/)).

## **Προσθήκη πλαισίων αντικειμένων OLE σε διαφάνειες**

Υποθέτοντας ότι έχετε ήδη δημιουργήσει ένα διάγραμμα στο Microsoft Excel και θέλετε να το ενσωματώσετε σε μια διαφάνεια ως πλαίσιο αντικειμένου OLE χρησιμοποιώντας το Aspose.Slides for C++, μπορείτε να το κάνετε ως εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
2. Λάβετε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.
3. Διαβάστε το αρχείο Excel ως πίνακα byte.
4. Προσθέστε το [OleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/oleobjectframe/) στη διαφάνεια περιλαμβάνοντας τον πίνακα byte και άλλες πληροφορίες σχετικά με το αντικείμενο OLE.
5. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε ένα διάγραμμα από αρχείο Excel σε μια διαφάνεια ως [OleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/oleobjectframe/) χρησιμοποιώντας το Aspose.Slides for C++.  
**Σημείωση** ότι ο κατασκευαστής [OleEmbeddedDataInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) δέχεται μια επέκταση ενσωματωμένου αντικειμένου ως δεύτερη παράμετρο. Αυτή η επέκταση επιτρέπει στο PowerPoint να ερμηνεύει σωστά τον τύπο αρχείου και να επιλέγει τη σωστή εφαρμογή για το άνοιγμα αυτού του αντικειμένου OLE.

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Προσθήκη συνδεδεμένων πλαισίων αντικειμένου OLE**

Aspose.Slides for C++ σας επιτρέπει να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/oleobjectframe/) χωρίς ενσωμάτωση δεδομένων αλλά μόνο με σύνδεσμο προς το αρχείο.

Αυτός ο κώδικας C++ σας δείχνει πώς να προσθέσετε ένα [OleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/oleobjectframe/) με ένα συνδεδεμένο αρχείο Excel σε μια διαφάνεια:

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Προσθήκη πλαισίου αντικειμένου OLE με συνδεδεμένο αρχείο Excel.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Πρόσβαση σε πλαίσια αντικειμένων OLE**

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να το βρείτε ή να το προσπελάσετε με αυτόν τον τρόπο:

1. Φορτώστε μια παρουσία με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
2. Λάβετε την αναφορά της διαφάνειας χρησιμοποιώντας το δείκτη της.
3. Προσπελάστε το σχήμα [OleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/oleobjectframe/). Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγουμένως δημιουργημένο PPTX που έχει μόνο ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* το αντικείμενο ως [IOleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ioleobjectframe/). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις αποκτήσετε πρόσβαση στο πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία πάνω του.

Στο παρακάτω παράδειγμα, πρόσβαση γίνεται σε ένα πλαίσιο αντικειμένου OLE (αντικείμενο διαγράμματος Excel ενσωματωμένο σε μια διαφάνεια) και στα δεδομένα αρχείου του.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Λάβετε τα ενσωματωμένα δεδομένα αρχείου.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Λάβετε την επέκταση του ενσωματωμένου αρχείου.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Πρόσβαση σε ιδιότητες συνδεδεμένου πλαισίου αντικειμένου OLE**

Το Aspose.Slides σας επιτρέπει να πρόσβαση σε ιδιότητες συνδεδεμένου πλαισίου αντικειμένου OLE.

Αυτός ο κώδικας C++ σας δείχνει πώς να ελέγξετε εάν ένα αντικείμενο OLE είναι συνδεδεμένο και στη συνέχεια να λάβετε τη διαδρομή του συνδεδεμένου αρχείου:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Ελέγξτε αν το αντικείμενο OLE είναι συνδεδεμένο.
    if (oleFrame->get_IsObjectLink())
    {
        // Εκτυπώστε τη πλήρη διαδρομή του συνδεδεμένου αρχείου.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Εκτυπώστε τη σχετική διαδρομή του συνδεδεμένου αρχείου αν υπάρχει.
        // Μόνο οι παρουσιάσεις PPT μπορούν να περιέχουν τη σχετική διαδρομή.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Αλλαγή δεδομένων αντικειμένου OLE**

{{% alert color="info" %}} 
Σε αυτήν την ενότητα, το παρακάτω παράδειγμα κώδικα χρησιμοποιεί το [Aspose.Cells for C++](/cells/cpp/). 
{{% /alert %}}

Εάν ένα αντικείμενο OLE είναι ήδη ενσωματωμένο σε μια διαφάνεια, μπορείτε εύκολα να προσπελάσετε αυτό το αντικείμενο και να τροποποιήσετε τα δεδομένα του με αυτόν τον τρόπο:

1. Φορτώστε μια παρουσία με το ενσωματωμένο αντικείμενο OLE δημιουργώντας μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
2. Λάβετε την αναφορά της διαφάνειας μέσω του δείκτη της. 
3. Προσπελάστε το σχήμα [OLEObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/oleobjectframe/). Στο παράδειγμά μας, χρησιμοποιήσαμε το προηγούμενο δημιουργημένο PPTX που έχει ένα σχήμα στην πρώτη διαφάνεια. Στη συνέχεια *cast* το αντικείμενο ως [IOleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ioleobjectframe/). Αυτό ήταν το επιθυμητό πλαίσιο αντικειμένου OLE για πρόσβαση.
4. Μόλις αποκτήσετε πρόσβαση στο πλαίσιο αντικειμένου OLE, μπορείτε να εκτελέσετε οποιαδήποτε λειτουργία πάνω του.
5. Δημιουργήστε ένα αντικείμενο `Workbook` και προσπελάστε τα δεδομένα OLE.
6. Προσπελάστε το επιθυμητό `Worksheet` και τροποποιήστε τα δεδομένα.
7. Αποθηκεύστε το ενημερωμένο `Workbook` σε ροή.
8. Αλλάξτε τα δεδομένα του αντικειμένου OLE από τη ροή.

Στο παρακάτω παράδειγμα, ένα πλαίσιο αντικειμένου OLE (αντικείμενο διαγράμματος Excel ενσωματωμένο σε μια διαφάνεια) προσεγγίζεται, και τα δεδομένα αρχείου του τροποποιούνται για την ενημέρωση των δεδομένων του διαγράμματος.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Το Aspose.Cells για C++ πρέπει να εκκινηθεί πριν χρησιμοποιηθεί οποιοδήποτε από τα τύπους του.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Λάβετε το πρώτο σχήμα ως πλαίσιο αντικειμένου OLE.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Ανάγνωση των δεδομένων του αντικειμένου OLE ως αντικείμενο Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Τροποποίηση των δεδομένων του workbook.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // Αλλαγή των δεδομένων του αντικειμένου πλαισίου OLE.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Ενσωμάτωση άλλων τύπων αρχείων σε διαφάνειες**

Εκτός από διαγράμματα Excel, το Aspose.Slides for C++ σας επιτρέπει να ενσωματώνετε άλλους τύπους αρχείων σε διαφάνειες. Για παράδειγμα, μπορείτε να εισάγετε αρχεία HTML, PDF και ZIP ως αντικείμενα. Όταν ένας χρήστης κάνει διπλό κλικ στο εισαχθέν αντικείμενο, αυτό ανοίγει αυτόματα στο αντίστοιχο πρόγραμμα, ή του ζητείται να επιλέξει κατάλληλο πρόγραμμα για άνοιγμά του.

Αυτός ο κώδικας C++ σας δείχνει πώς να ενσωματώσετε HTML και ZIP σε μια διαφάνεια:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός τύπων αρχείων για ενσωματωμένα αντικείμενα**

Κατά την εργασία με παρουσιάσεις, ίσως χρειαστεί να αντικαταστήσετε παλιά αντικείμενα OLE με νέα ή να αντικαταστήσετε ένα μη υποστηριζόμενο αντικείμενο OLE με ένα υποστηριζόμενο. Το Aspose.Slides for C++ σας επιτρέπει να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο, επιτρέποντάς σας να ενημερώσετε τα δεδομένα πλαισίου OLE ή την επέκτασή του.

Αυτός ο κώδικας C++ σας δείχνει πώς να ορίσετε τον τύπο αρχείου για ένα ενσωματωμένο αντικείμενο OLE σε `zip`:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Change the file type to ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ορισμός εικόνων εικονιδίου και τίτλων για ενσωματωμένα αντικείμενα**

Μετά την ενσωμάτωση ενός αντικειμένου OLE, προστίθεται αυτόματα μια προεπισκόπηση που αποτελείται από μια εικόνα εικονιδίου. Αυτή η προεπισκόπηση είναι ό,τι βλέπουν οι χρήστες πριν προσπελάσουν ή ανοίξουν το αντικείμενο OLE. Εάν θέλετε να χρησιμοποιήσετε μια συγκεκριμένη εικόνα και κείμενο ως στοιχεία στην προεπισκόπηση, μπορείτε να ορίσετε την εικόνα εικονιδίου και τον τίτλο χρησιμοποιώντας το Aspose.Slides for C++.

Αυτός ο κώδικας C++ σας δείχνει πώς να ορίσετε την εικόνα εικονιδίου και τον τίτλο για ένα ενσωματωμένο αντικείμενο: 

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Προσθήκη εικόνας στους πόρους της παρουσίασης.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Αποτροπή αλλαγής μεγέθους και θέσης πλαισίου OLE αντικειμένου**

Μετά την προσθήκη ενός συνδεδεμένου αντικειμένου OLE σε μια διαφάνεια παρουσίασης, όταν ανοίγετε την παρουσίαση στο PowerPoint, μπορεί να εμφανιστεί ένα μήνυμα που ζητά την ενημέρωση των συνδέσεων. Το κλικ στο κουμπί «Update Links» μπορεί να αλλάξει το μέγεθος και τη θέση του πλαισίου αντικειμένου OLE επειδή το PowerPoint ενημερώνει τα δεδομένα από το συνδεδεμένο αντικείμενο OLE και ανανεώνει την προεπισκόπηση. Για να αποτρέψετε το PowerPoint από το να ζητά ενημέρωση των δεδομένων του αντικειμένου, ορίστε τη μέθοδο `set_UpdateAutomatic` της διεπαφής [IOleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ioleobjectframe/) σε `false`:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **Εξαγωγή ενσωματωμένων αρχείων**

Το Aspose.Slides for C++ σας επιτρέπει να εξάγετε τα αρχεία που είναι ενσωματωμένα σε διαφάνειες ως αντικείμενα OLE με τον εξής τρόπο:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) που περιέχει τα αντικείμενα OLE που θέλετε να εξάγετε.
2. Περιηγηθείτε σε όλα τα σχήματα στην παρουσία και προσπελάστε τα σχήματα [OLEObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/oleobjectframe/).
3. Προσπελάστε τα δεδομένα των ενσωματωμένων αρχείων από τα πλαίσια αντικειμένων OLE και γράψτε τα στο δίσκο.

Αυτός ο κώδικας C++ σας δείχνει πώς να εξάγετε αρχεία ενσωματωμένα σε μια διαφάνεια ως αντικείμενα OLE:

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **Συχνές ερωτήσεις**

### Θα αποδοθεί το περιεχόμενο OLE κατά την εξαγωγή διαφανειών σε PDF/εικόνες;

Αυτό που είναι ορατό στη διαφάνεια αποδίδεται—το εικονίδιο/εναλλακτική εικόνα (προεπισκόπηση). Το «ζωντανό» περιεχόμενο OLE δεν εκτελείται κατά την απόδοση. Αν χρειάζεται, ορίστε τη δική σας εικόνα προεπισκόπησης ώστε να εξασφαλίσετε την αναμενόμενη εμφάνιση στο εξαγόμενο PDF.

### Πώς μπορώ να κλειδώσω ένα αντικείμενο OLE σε μια διαφάνεια ώστε οι χρήστες να μην μπορούν να το μετακινήσουν/επεξεργαστούν στο PowerPoint;

Κλειδώστε το σχήμα: το Aspose.Slides παρέχει [κλειδώσεις επιπέδου σχήματος](/slides/el/cpp/applying-protection-to-presentation/). Αυτό δεν είναι κρυπτογράφηση, αλλά εμποδίζει αποτελεσματικά ακούσιες επεμβάσεις και μετακινήσεις.

### Γιατί ένα συνδεδεμένο αντικείμενο Excel «πηδά» ή αλλάζει μέγεθος όταν ανοίγω την παρουσίαση;

Το PowerPoint μπορεί να ανανεώσει την προεπισκόπηση του συνδεδεμένου OLE. Για σταθερή εμφάνιση, ακολουθήστε τις πρακτικές του [Working Solution for Worksheet Resizing](/slides/el/cpp/working-solution-for-worksheet-resizing/)—είτε προσαρμόσετε το πλαίσιο στην περιοχή, είτε κλιμακώσετε την περιοχή σε ένα σταθερό πλαίσιο και ορίστε μια κατάλληλη εναλλακτική εικόνα.

### Θα διατηρηθούν οι σχετικοί δρόμοι για συνδεδεμένα αντικείμενα OLE στη μορφή PPTX;

Στο PPTX, οι πληροφορίες «σχετικού δρόμου» δεν είναι διαθέσιμες—μόνο η πλήρης διαδρομή. Οι σχετικοί δρόμοι υπάρχουν μόνο στην παλαιότερη μορφή PPT. Για φορητότητα, προτιμήστε αξιόπιστες απόλυτες διαδρομές/πρόσβαση μέσω URIs ή ενσωμάτωση.