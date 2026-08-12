---
title: Αποθήκευση Παρουσιάσεων σε C++
linktitle: Αποθήκευση Παρουσίασης
type: docs
weight: 80
url: /el/cpp/save-presentation/
keywords:
- αποθήκευση PowerPoint
- αποθήκευση OpenDocument
- αποθήκευση παρουσίασης
- αποθήκευση διαφάνειας
- αποθήκευση PPT
- αποθήκευση PPTX
- αποθήκευση ODP
- παρουσίαση σε αρχείο
- παρουσίαση σε ροή
- προκαθορισμένος τύπος προβολής
- Αυστηρή μορφή Office Open XML
- λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- C++
- Aspose.Slides
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις σε C++ χρησιμοποιώντας το Aspose.Slides—εξαγωγή σε PowerPoint ή OpenDocument διατηρώντας τις διατάξεις, τις γραμματοσειρές και τα εφέ."
---
## **Επισκόπηση**

[Open Presentations in C++](/slides/el/cpp/open-presentation/) περιγράφει πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) για το άνοιγμα μιας παρουσίασης. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) περιέχει τα περιεχόμενα μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από το μηδέν είτε τροποποιείτε μια υπάρχουσα, θα θέλετε να την αποθηκεύσετε όταν τελειώσετε. Με το Aspose.Slides για C++, μπορείτε να αποθηκεύσετε σε **αρχείο** ή **ροή**. Αυτό το άρθρο εξηγεί τις διαφορετικές μεθόδους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση Παρουσιάσεων σε Αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο καλώντας τη μέθοδο `Save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/). Π περάστε το όνομα αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με το Aspose.Slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Δημιουργείστε το αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Κάντε κάποια εργασία εδώ...

// Αποθηκεύστε την παρουσίαση σε αρχείο.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Αποθήκευση Παρουσιάσεων σε Ροές**

Μπορείτε να αποθηκεύσετε μια παρουσίαση σε ροή περνώντας μια έξοδο ροής στη μέθοδο `Save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/). Μια παρουσίαση μπορεί να γραφεί σε πολλούς τύπους ροών. Στο παρακάτω παράδειγμα, δημιουργούμε μια νέα παρουσίαση και την αποθηκεύουμε σε ροή αρχείου.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Δημιουργεί το αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Save the presentation to the stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Αποθήκευση Παρουσιάσεων με Προκαθορισμένου Τύπου Προβολή**

Το Aspose.Slides σάς επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η δημιουργούμενη παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/). Χρησιμοποιήστε τη μέθοδο [set_LastView](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/set_lastview/) με μια τιμή από την απαρίθμηση [ViewType](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewtype/).

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Αποθήκευση Παρουσιάσεων σε Αυστηρή Μορφή Office Open XML**

Το Aspose.Slides σάς επιτρέπει να αποθηκεύσετε μια παρουσίαση σε Αυστηρή μορφή Office Open XML. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pptxoptions/) και ορίστε την ιδιότητα conformance κατά την αποθήκευση. Αν ορίσετε `Conformance.Iso29500_2008_Strict`, το αρχείο εξόδου αποθηκεύεται στην Αυστηρή μορφή Office Open XML.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει στην Αυστηρή μορφή Office Open XML.

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Δημιουργεί το αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποθηκεύει την παρουσίαση σε αυστηρή μορφή Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Αποθήκευση Παρουσιάσεων σε Μορφή Office Open XML σε Κατάσταση Zip64**

Ένα αρχείο Office Open XML είναι ένα αρχείο ZIP που επιβάλλει περιορισμούς 4 GB (2^32 bytes) στο αμεσυσκευασμένο μέγεθος οποιουδήποτε αρχείου, στο συμπιεσμένο μέγεθος οποιουδήποτε αρχείου και στο συνολικό μέγεθος του αρχείου, καθώς και περιορισμό 65 535 (2^16‑1) αρχείων. Οι επεκτάσεις μορφής ZIP64 αυξάνουν αυτά τα όρια σε 2^64.

Η μέθοδος [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) σας επιτρέπει να επιλέξετε πότε να χρησιμοποιείτε τις επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός αρχείου Office Open XML.

Αυτή η μέθοδος μπορεί να χρησιμοποιηθεί με τις παρακάτω καταστάσεις:

- `IfNecessary` χρησιμοποιεί επεκτάσεις μορφής ZIP64 μόνο εάν η παρουσίαση ξεπερνά τους παραπάνω περιορισμούς. Είναι η προεπιλεγμένη κατάσταση.
- `Never` δεν χρησιμοποιεί ποτέ επεκτάσεις μορφής ZIP64.
- `Always` χρησιμοποιεί πάντα επεκτάσεις μορφής ZIP64.

Ο παρακάτω κώδικας δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX με ενεργοποιημένες επεκτάσεις μορφής ZIP64:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Όταν αποθηκεύετε με `Zip64Mode.Never`, μια [PptxException](https://reference.aspose.com/slides/el/cpp/aspose.slides/pptxexception/) ρίχνεται εάν η παρουσίαση δεν μπορεί να αποθηκευτεί σε μορφή ZIP32.
{{% /alert %}}

## **Αποθήκευση Παρουσιάσεων σε Μορφή Office Open XML με Επίπεδα Συμπίεσης**

Όταν εργάζεστε με μεγάλες παρουσιάσεις, μπορείτε να προσαρμόσετε το επίπεδο συμπίεσης ώστε να ισορροπείτε το μέγεθος του αρχείου και το χρόνο επεξεργασίας. Ανάλογα με τις απαιτήσεις σας, μπορεί να προτιμάτε ταχύτερη επεξεργασία ή μικρότερα αρχεία εξόδου.

Το Aspose.Slides παρέχει τη μέθοδο [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) που σας επιτρέπει να καθορίσετε το επίπεδο συμπίεσης που χρησιμοποιείται όταν αποθηκεύετε μια παρουσίαση σε μορφή Office Open XML.

Τα διαθέσιμα επίπεδα συμπίεσης είναι:

- **None**: Δεν εφαρμόζεται συμπίεση. Τα αρχεία αποθηκεύονται όπως είναι.
- **Level1:** Η πιο γρήγορη συμπίεση με το χαμηλότερο λόγο συμπίεσης.
- **Level2:** Πιο γρήγορη συμπίεση με ελαφρώς καλύτερο λόγο συμπίεσης από το **Level1**.
- **Level3:** Παρέχει καλύτερη συμπίεση από το **Level2** με μέτρια επίδραση στο χρόνο επεξεργασίας.
- **Level4:** Παρέχει καλύτερη συμπίεση από το **Level3**.
- **Level5:** Παρέχει βελτιωμένη συμπίεση σε σχέση με το **Level4** με επιπλέον χρόνο επεξεργασίας.
- **Level6:** Τυπική συμπίεση που προσφέρει καλή ισορροπία μεταξύ ταχύτητας επεξεργασίας και μεγέθους αρχείου. Αυτό είναι το *προεπιλεγμένο επίπεδο συμπίεσης*.
- **Level7:** Παρέχει καλύτερη συμπίεση από το **Level6** με πιο αργή επεξεργασία.
- **Level8:** Παρέχει καλύτερη συμπίεση από το **Level7**.
- **Level9:** Μέγιστη συμπίεση. Παράγει το μικρότερο μέγεθος αρχείου με κόστος του μεγαλύτερου χρόνου επεξεργασίας.

Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX *χωρίς συμπίεση*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

Αυτό το παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX *με μέγιστη συμπίεση*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **Αποθήκευση Παρουσιάσεων χωρίς Ανανέωση της Μικρογραφίας**

Η μέθοδος [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) ελέγχει τη δημιουργία μικρογραφίας όταν αποθηκεύεται μια παρουσίαση σε PPTX:

- Αν οριστεί σε `true`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Είναι η προεπιλογή.
- Αν οριστεί σε `false`, η τρέχουσα μικρογραφία διατηρείται. Εάν η παρουσίαση δεν έχει μικρογραφία, δεν δημιουργείται καμία.

Στον παρακάτω κώδικα, η παρουσίαση αποθηκεύεται σε PPTX χωρίς ανανέωση της μικρογραφίας της.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Αυτή η επιλογή βοηθά στη μείωση του χρόνου που απαιτείται για την αποθήκευση μιας παρουσίασης σε μορφή PPTX.
{{% /alert %}}

## **Αποθήκευση Ενημερώσεων Προόδου σε Ποσοστό**

Η διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprogresscallback/) χρησιμοποιείται μέσω της μεθόδου `set_ProgressCallback` που εκτίθενται από τη διεπαφή [ISaveOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/isaveoptions/) και την αφηρημένη κλάση [SaveOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveoptions/). Αναθέστε μια υλοποίηση [IProgressCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprogresscallback/) με το `set_ProgressCallback` για να λαμβάνετε ενημερώσεις προόδου αποθήκευσης ως ποσοστό.

Τα παρακάτω αποσπάσματα κώδικα δείχνουν πώς να χρησιμοποιήσετε το `IProgressCallback`.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // Χρησιμοποιήστε εδώ την τιμή ποσοστού προόδου.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Η κλάση callback προόδου που ορίστηκε παραπάνω.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Η Aspose έχει αναπτύξει μια [δωρεάν εφαρμογή PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) χρησιμοποιώντας το δικό της API. Η εφαρμογή σας επιτρέπει να διαιρέσετε μια παρουσίαση σε πολλαπλά αρχεία αποθηκεύοντας επιλεγμένες διαφάνειες ως νέα αρχεία PPTX ή PPT.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Υποστηρίζεται η «γρήγορη αποθήκευση» (αυτόματη αποθήκευση) ώστε να γράφονται μόνο οι αλλαγές;**

Όχι. Η αποθήκευση δημιουργεί το πλήρες αρχείο προορισμού κάθε φορά· η «γρήγορη αποθήκευση» δεν υποστηρίζεται.

**Είναι ασφαλές νήμα (thread‑safe) το να αποθηκεύεται το ίδιο αντικείμενο Presentation από πολλαπλά νήματα;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) δεν είναι ασφαλές νήμα‑από (thread‑safe)· αποθηκεύστε το από ένα μόνο νήμα.

**Τι γίνεται με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

Τα [Hyperlinks](/slides/el/cpp/manage-hyperlinks/) διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ. βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα· βεβαιωθείτε ότι οι αναφερόμενες διαδρομές παραμένουν προσβάσιμες.

**Μπορώ να ορίσω/αποθηκεύσω μεταδεδομένα εγγράφου (Συγγραφέας, Τίτλος, Εταιρεία, Ημερομηνία);**

Ναι. Οι τυπικές [ιδιότητες εγγράφου](/slides/el/cpp/presentation-properties/) υποστηρίζονται και θα γραφτούν στο αρχείο κατά την αποθήκευση.