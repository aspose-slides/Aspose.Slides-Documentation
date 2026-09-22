---
title: Αποθήκευση Παρουσιών σε C++
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
- Στενή Μορφή Office Open XML
- Λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- C++
- Aspose.Slides
description: "Αποθήκευση παρουσιάσεων PowerPoint και OpenDocument σε αρχεία ή ροές σε C++ με Aspose.Slides, και διαμόρφωση της εξόδου PPTX και αναφοράς προόδου."
---
## **Επισκόπηση**

Αφού δημιουργήσετε μια παρουσίαση ή [ανοίξετε μια υπάρχουσα](/slides/el/cpp/open-presentation/), χρησιμοποιήστε τη μέθοδο [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) για να γράψετε το αποτέλεσμα. Το Aspose.Slides για C++ μπορεί να αποθηκεύσει μια παρουσίαση σε αρχείο ή ροή σε μορφές PowerPoint, OpenDocument, PDF και άλλες. Τα επόμενα τμήματα καλύπτουν τις τυπικές λειτουργίες αποθήκευσης και τις επιλογές διαθέσιμες για έξοδο PPTX.

## **Αποθήκευση Παρουσιάσεων σε Αρχεία**

Για να αποθηκεύσετε μια παρουσίαση σε αρχείο, περάστε τη διαδρομή εξόδου και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/) στη μέθοδο [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/). Η τιμή μορφής καθορίζει τον τύπο του αρχείου που δημιουργεί το Aspose.Slides.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει ως αρχείο PPTX:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Προσθέστε ή τροποποιήστε το περιεχόμενο της παρουσίασης εδώ.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Αποθήκευση Παρουσιάσεων στην Αρχική τους Μορφή**

Για παραδείγματα ανίχνευσης αρχείων και ροών, τη συμπεριφορά των νεοδημιουργημένων παρουσιάσεων και τη διάκριση μεταξύ πηγής και μορφής εξόδου, δείτε [Καθορίστε την Αρχική Μορφή Παρουσίασης](/slides/el/cpp/detect-presentation-source-format/).

Σε εφαρμογή επεξεργασίας δέσμης, η μορφή εισόδου ενδέχεται να μην είναι γνωστή εκ των προτέρων. Μετά τη φόρτωση ενός αρχείου, διαβάστε την αρχική του μορφή με [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/get_sourceformat/). Περάστε τη ληφθείσα τιμή [SourceFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/sourceformat/) στη μέθοδο [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/slideutil/tosaveformat/) για να λάβετε την αντίστοιχη τιμή [SaveFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/) και, στη συνέχεια, χρησιμοποιήστε το [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) για να γράψετε τη μετασχηματισμένη παρουσίαση.

Το παρακάτω πλήρες παράδειγμα επεξεργάζεται κάθε αρχείο σε έναν φάκελο εισόδου, ενημερώνει τον τίτλο του και το αποθηκεύει σε φάκελο εξόδου στη μορφή από την οποία φορτώθηκε:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/slideutil/tosaveformat/) αντιστοιχεί τα PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP και PowerPoint XML στις αντίστοιχες μορφές αποθήκευσης παρουσίασης. Αντιστοιχεί μόνο μορφές πηγής παρουσίασης· δεν προορίζεται για επιλογή μορφών εξαγωγής όπως PDF, HTML, TIFF ή εικόνες. Η παράδοση μιας μη υποστηριζόμενης ή μη έγκυρης τιμής [SourceFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/sourceformat/) οδηγεί σε [ArgumentException](https://reference.aspose.com/slides/el/cpp/system/argumentexception/).

Τα παλαιά αρχεία PPT, PPS και POT χρησιμοποιούν το ίδιο δυαδικό κοντέινερ. Όταν μια τέτοια παρουσίαση φορτώνεται από ροή χωρίς επέκταση αρχείου, ένα αρχείο PPS ή POT μπορεί να ταυτοποιηθεί ως PPT. Εάν απαιτείται διατήρηση αυτών των παλαιών υποτύπων, διατηρήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα μορφής χωριστά και χρησιμοποιήστε τα κατά την επιλογή του ονόματος και της μορφής εξόδου.

## **Αποθήκευση Παρουσιάσεων σε Ροές**

Για να γράψετε μια παρουσίαση χωρίς να βασίζεστε σε τελική διαδρομή αρχείου, περάστε ένα εγγράψιμο [Stream](https://reference.aspose.com/slides/el/cpp/system.io/stream/) και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/) στη μέθοδο [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/). Αυτή η προσέγγιση είναι χρήσιμη όταν η έξοδος πρέπει να επιστραφεί από μια υπηρεσία web, αποθηκευτεί σε βάση δεδομένων ή επεξεργαστεί στη μνήμη.

Το παρακάτω παράδειγμα αποθηκεύει μια νέα παρουσίαση σε ροή αρχείου:

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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Αποθήκευση Παρουσιάσεων με Προκαθορισμένο Τύπο Προβολής**

Μπορείτε να ορίσετε την προβολή με την οποία το PowerPoint ανοίγει αρχικά μια αποθηκευμένη παρουσίαση. Κλήστε το [ViewProperties::set_LastView](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/set_lastview/) με μια τιμή [ViewType](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewtype/) πριν την αποθήκευση.

Το παρακάτω παράδειγμα ρυθμίζει την προβολή Slide Master ως αρχική προβολή:

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

## **Αποθήκευση Παρουσιάσεων σε Σύνθετη Μορφή Office Open XML**

Για να δημιουργήσετε ένα αρχείο PPTX που συμμορφώνεται με το Strict προφίλ του Office Open XML, δημιουργήστε ένα αντικείμενο [PptxOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pptxoptions/) και καλέστε το [PptxOptions::set_Conformance](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pptxoptions/set_conformance/) με `Conformance::Iso29500_2008_Strict`. Στη συνέχεια, περάστε τις επιλογές στη μέθοδο [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/).

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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Αποθήκευση Παρουσιάσεων σε Μορφή Office Open XML σε Λειτουργία Zip64**

Ένα τυπικό αρχείο ZIP περιορίζει το συμπιεσμένο και μη συμπιεσμένο μέγεθος κάθε καταχώρησης, το συνολικό μέγεθος του αρχείου και τον αριθμό των καταχωρήσεων. Επειδή ένα αρχείο PPTX είναι αρχείο ZIP, μια πολύ μεγάλη παρουσίαση μπορεί να υπερβεί αυτά τα όρια. Οι επεκτάσεις ZIP64 αυξάνουν τα όρια μεγέθους και αριθμού καταχωρήσεων.

Χρησιμοποιήστε το [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) για να ελέγξετε εάν το Aspose.Slides γράφει επεκτάσεις ZIP64:

- `IfNecessary` χρησιμοποιεί ZIP64 μόνο όταν η παρουσίαση υπερβαίνει τα τυπικά όρια ZIP. Αυτή είναι η προεπιλεγμένη λειτουργία.
- `Never` απενεργοποιεί τις επεκτάσεις ZIP64.
- `Always` γράφει πάντα επεκτάσεις ZIP64.

Το παρακάτω παράδειγμα ενεργοποιεί πάντα τις επεκτάσεις ZIP64 για την έξοδο της παρουσίασης:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
Αν το `Zip64Mode` οριστεί σε `Never` και η παρουσίαση δεν χωράει στα τυπικά όρια ZIP, η ενέργεια αποθήκευσης ρίχνει ένα [PptxException](https://reference.aspose.com/slides/el/cpp/aspose.slides/pptxexception/).
{{% /alert %}}

## **Αποθήκευση Παρουσιάσεων σε Μορφή Office Open XML με Επίπεδα Συμπίεσης**

Για έξοδο PPTX, μπορείτε να ισορροπήσετε την ταχύτητα αποθήκευσης με το μέγεθος του αρχείου καλώντας το [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/). Η απαρίθμηση [CompressionLevel](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/compressionlevel/) παρέχει τις ακόλουθες τιμές:

- `None` αποθηκεύει τα δεδομένα χωρίς συμπίεση.
- `Level1` προσφέρει τη γρηγορότερη συμπίεση και το μεγαλύτερο συμπιεσμένο αρχείο.
- `Level2` έως `Level5` προτιμούν σταδιακά μικρότερο μέγεθος εξόδου εις βάθος της ταχύτητας αποθήκευσης.
- `Level6` εξισορροπεί την ταχύτητα αποθήκευσης και το μέγεθος αρχείου. Αυτή είναι η προεπιλεγμένη τιμή.
- `Level7` και `Level8` ευνοούν περαιτέρω μικρότερο μέγεθος εις βάθος της ταχύτητας αποθήκευσης.
- `Level9` παρέχει τη δυνατότερη συμπίεση και απαιτεί το περισσότερη χρόνο επεξεργασίας.

Το παρακάτω παράδειγμα αποθηκεύει μια παρουσίαση χωρίς συμπίεση:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

Το παρακάτω παράδειγμα χρησιμοποιεί το μέγιστο επίπεδο συμπίεσης:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Αποθήκευση Παρουσιάσεων χωρίς Ανανέωση Μικρογραφίας**

Κατά την αποθήκευση μιας παρουσίασης ως PPTX, το [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) ελέγχει τη μικρογραφία του εγγράφου:

- `true` αναδημιουργεί τη μικρογραφία κατά την αποθήκευση. Αυτή είναι η προεπιλεγμένη τιμή.
- `false` διατηρεί την υπάρχουσα μικρογραφία. Εάν η παρουσίαση δεν διαθέτει μικρογραφία, το Aspose.Slides δεν δημιουργεί νέα.

Το παρακάτω παράδειγμα αποθηκεύει μια παρουσίαση χωρίς ανανέωση της μικρογραφίας:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Η απενεργοποίηση της ανανέωσης μικρογραφίας μπορεί να μειώσει το χρόνο που απαιτείται για την αποθήκευση αρχείου PPTX.
{{% /alert %}}

## **Αποθήκευση Ενημερώσεων Προόδου σε Ποσοστό**

Για να παρακολουθείτε μια ενέργεια αποθήκευσης, υλοποιήστε τη διεπαφή [IProgressCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprogresscallback/) και περάστε την υλοποίηση στη μέθοδο [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). Το Aspose.Slides στη συνέχεια καλεί το [IProgressCallback::Reporting](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprogresscallback/reporting/) με τιμές προόδου κατά την εξαγωγή.

Το παρακάτω παράδειγμα αναφέρει την πρόοδο εξαγωγής PDF στην κονσόλα:

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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Η Aspose προσφέρει δωρεάν το [PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) που δημιουργήθηκε με το API του Aspose.Slides. Αποθηκεύει επιλεγμένες διαφάνειες από μια παρουσίαση ως ξεχωριστά αρχεία PPT ή PPTX.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Υποστηρίζει το Aspose.Slides αποθήκευση επαναληπτική ή «γρήγορη»;**

Όχι. Κάθε ενέργεια αποθήκευσης γράφει ένα πλήρες αρχείο εξόδου αντί να ενημερώνει μόνο τα μέρη που έχουν αλλάξει.

**Μπορούν πολλαπλά νήματα να αποθηκεύσουν το ίδιο αντικείμενο Presentation;**

Όχι. Το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) **δεν είναι thread‑safe** (/slides/el/cpp/multithreading/). Κάθε νήμα πρέπει να έχει πρόσβαση και αποθήκευση ενός αντικειμένου μόνο από ένα νήμα τη φορά.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά αρχεία που συνδέονται όταν αποθηκεύω μια παρουσίαση;**

Οι [υπερσύνδεσμοι](/slides/el/cpp/manage-hyperlinks/) παραμένουν στην παρουσίαση. Το Aspose.Slides δεν αντιγράφει εξωτερικά συνδεδεμένα αρχεία, επομένως η αποθηκευμένη παρουσίαση πρέπει ακόμη να μπορεί να προσπελάσει τις τοποθεσίες τους.

**Μπορώ να αποθηκεύσω μεταδεδομένα εγγράφου όπως ο δημιουργός, ο τίτλος, η εταιρεία και η ημερομηνία δημιουργίας;**

Ναι. Ορίστε τις κατάλληλες [ιδιότητες εγγράφου](/slides/el/cpp/presentation-properties/) πριν την αποθήκευση και το Aspose.Slides θα τις γράψει στο αρχείο εξόδου.