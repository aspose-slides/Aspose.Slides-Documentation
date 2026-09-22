---
title: Άνοιγμα Παρουσιάσεων σε C++
linktitle: Άνοιγμα Παρουσίασης
type: docs
weight: 20
url: /el/cpp/open-presentation/
keywords:
- άνοιγμα PowerPoint
- άνοιγμα OpenDocument
- άνοιγμα παρουσίασης
- άνοιγμα PPTX
- άνοιγμα PPT
- άνοιγμα ODP
- φόρτωση παρουσίασης
- φόρτωση PPTX
- φόρτωση PPT
- φόρτωση ODP
- προστατευμένη παρουσίαση
- μεγάλη παρουσίαση
- εξωτερικός πόρος
- δυαδικό αντικείμενο
- C++
- Aspose.Slides
description: "Μάθετε πώς να ανοίγετε παρουσιάσεις PowerPoint και OpenDocument σε C++, να παρέχετε κωδικούς πρόσβασης ανοίγματος, να ελέγχετε τη φόρτωση πόρων και να μειώνετε τη χρήση μνήμης με το Aspose.Slides για C++."
---
## **Εισαγωγή**

[Aspose.Slides for C++](https://products.aspose.com/slides/el/cpp/) μπορεί να φορτώνει παρουσιάσεις PowerPoint και OpenDocument από αρχεία και ροές. Μετά τη φόρτωση μιας παρουσίασης, μπορείτε να εξετάσετε τη δομή της, να επεξεργαστείτε τις διαφάνειες, να διαχειριστείτε τους πόρους και να την αποθηκεύσετε στην αρχική ή σε άλλη υποστηριζόμενη μορφή.

Η συμπεριφορά φόρτωσης μπορεί να προσαρμοστεί μέσω της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/). Για παράδειγμα, μπορείτε να παρέχετε κωδικό πρόσβασης για άνοιγμα, να κρατάτε μεγάλα δυαδικά αντικείμενα εκτός μνήμης, να ελέγχετε εξωτερικούς πόρους ή να παραλείπετε ενσωματωμένα δυαδικά δεδομένα.

## **Άνοιγμα παρουσιάσεων**

Μετά τη φόρτωση ενός αρχείου ή ροής, μπορείτε να [καθορίσετε την αρχική μορφή της παρουσίασης](/slides/el/cpp/detect-presentation-source-format/) για να επιλέξετε πώς θα την επεξεργαστεί η εφαρμογή σας.

Για να ανοίξετε μια υπάρχουσα παρουσίαση, περάστε τη διαδρομή του αρχείου στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/). Απομακρύνετε (dispose) την παρουσίαση μετά τη χρήση ώστε να απελευθερωθούν άμεσα τα handles αρχείων, τα προσωρινά δεδομένα και άλλοι πόροι.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Άνοιγμα κωδικοπροστατευμένων παρουσιάσεων**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί το περιεχόμενο της παρουσίασης. Για να φορτώσετε ολόκληρη την παρουσίαση, περάστε τον σωστό κωδικό στο [LoadOptions::set_Password](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_password/) και περάστε τις επιλογές στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/). Η φόρτωση αποτυγχάνει όταν λείπει ή είναι λανθασμένος ο κωδικός.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

Για εντοπισμό, επικύρωση και ροές εργασίας κρυπτογράφησης κωδικού, δείτε [Παρουσιάσεις με προστασία κωδικού](/slides/el/cpp/password-protected-presentation/). Αν μια κρυπτογραφημένη παρουσίαση αποθηκευτεί σκόπιμα με δημόσια ιδιότητα εγγράφου, αυτές οι ιδιότητες μπορούν να διαβαστούν χωρίς κωδικό· δείτε [Διαχείριση ιδιοτήτων παρουσίασης](/slides/el/cpp/presentation-properties/).

## **Άνοιγμα μεγάλων παρουσιάσεων**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) ελέγχει πώς το Aspose.Slides χειρίζεται μεγάλα δυαδικά αντικείμενα, όπως εικόνες, ήχο και βίντεο. Μπορείτε να κρατήσετε το αρχείο προέλευσης κλειδωμένο, να επιτρέψετε προσωρινά αρχεία και να περιορίσετε την ποσότητα των δεδομένων BLOB που διατηρούνται στη μνήμη.

Ο παρακάτω κώδικας C++ δείχνει πώς να φορτώσετε μια μεγάλη παρουσίαση (π.χ., 2 GB):

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Με `PresentationLockingBehavior::KeepLocked`, το αρχείο προέλευσης παραμένει κλειδωμένο έως ότου το αντικείμενο `Presentation` απομακρυνθεί. Μην μετακινείτε, αντικαθιστάτε ή διαγράφετε το αρχείο προέλευσης ενώ αυτό το αντικείμενο είναι ενεργό.

Το Aspose.Slides μπορεί να αντιγράψει τα περιεχόμενα μιας εισερχόμενης ροής κατά τη φόρτωση. Για μεγάλες παρουσιάσεις, η διαδρομή αρχείου είναι γενικά πιο αποδοτική από τη ροή. Δείτε [Διαχείριση BLOB](/slides/el/cpp/manage-blob/) για πρόσθετες επιλογές αποθήκευσης και διαχείρισης μνήμης.

{{% /alert %}}

## **Έλεγχος εξωτερικών πόρων**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) δέχεται μια υλοποίηση του [IResourceLoadingCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides/iresourceloadingcallback/). Η κλήση-πίσω μπορεί να παρέχει δεδομένα αντικατάστασης, να ανακατευθύνει έναν πόρο, να χρησιμοποιήσει τον προεπιλεγμένο φορτωτή ή να παραλείψει τον πόρο. Αυτό είναι χρήσιμο όταν οι παρουσιάσεις περιέχουν εξωτερικές εικόνες που πρέπει να επιλυθούν σύμφωνα με κανόνες ασφαλείας ή αποθήκευσης της εφαρμογής.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Φόρτωση παρουσιάσεων χωρίς ενσωματωμένα δυαδικά αντικείμενα**

Μια παρουσίαση μπορεί να περιέχει ενσωματωμένα δυαδικά δεδομένα που η εφαρμογή δεν χρειάζεται ή δεν επιθυμεί να διατηρήσει. Παραδείγματα περιλαμβάνουν:

- Έργα VBA, διαθέσιμα μέσω [IPresentation::get_VbaProject](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/get_vbaproject/);
- ενσωματωμένα δεδομένα OLE, διαθέσιμα μέσω [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- δεδομένα ελέγχου ActiveX, διαθέσιμα μέσω [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/el/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Περάστε `true` στο [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) για να αφαιρέσετε αυτά τα δυαδικά δεδομένα κατά τη φόρτωση. Αποθηκεύστε την φορτωμένη παρουσίαση για να διατηρήσετε το καθαρισμένο αποτέλεσμα.

Αυτή η επιλογή μειώνει την έκθεση σε ανεπιθύμητα ενσωματωμένα φορτία, αλλά δεν αποτελεί πλήρες σύστημα εντοπισμού κακόβουλου λογισμικού ή καθαρισμού περιεχομένου.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Συχνές ερωτήσεις**

**Πώς μπορώ να καταλάβω ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχτεί;**

Το Aspose.Slides ρίχνει εξαίρεση ανάλυσης ή μορφής κατά τη φόρτωση. Χειριστείτε αυτήν την αποτυχία ξεχωριστά από σφάλμα λανθασμένου κωδικού πρόσβασης ώστε η εφαρμογή να μπορεί να αναφέρει ακριβώς την αιτία.

**Τι συμβαίνει αν λείπουν οι απαιτούμενες γραμματοσειρές;**

Η παρουσίαση μπορεί ακόμη να φορτωθεί, αλλά η απόδοση και η εξαγωγή μπορεί να αντικαταστήσουν τις γραμματοσειρές. Μπορείτε να [ρυθμίσετε την αντικατάσταση γραμματοσειρών](/slides/el/cpp/font-substitution/) ή να [παρέχετε προσαρμοσμένες γραμματοσειρές](/slides/el/cpp/custom-font/) ώστε το αποτέλεσμα να είναι πιο προβλέψιμο.

**Φορτώνει η φόρτωση μιας παρουσίασης και τα ενσωματωμένα πολυμέσα της;**

Τα ενσωματωμένα ηχητικά και βίντεο γίνονται διαθέσιμα μέσω του μοντέλου αντικειμένων της παρουσίασης. Οι εξωτερικοί πόροι επιλύονται σύμφωνα με τη ρυθμισμένη συμπεριφορά φόρτωσης πόρων και μπορεί να μην είναι προσβάσιμοι αν οι θέσεις τους δεν είναι προσβάσιμες.