---
title: Μετατροπή PPT και PPTX σε PDF σε C++ [Συμπεριλαμβάνονται Προχωρημένα Χαρακτηριστικά]
linktitle: PowerPoint σε PDF
type: docs
weight: 40
url: /el/cpp/convert-powerpoint-to-pdf/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- PowerPoint σε PDF
- παρουσίαση σε PDF
- PPT σε PDF
- μετατροπή PPT σε PDF
- PPTX σε PDF
- μετατροπή PPTX σε PDF
- αποθήκευση PowerPoint ως PDF
- αποθήκευση PPT ως PDF
- αποθήκευση PPTX ως PDF
- εξαγωγή PPT σε PDF
- εξαγωγή PPTX σε PDF
- συνημμένο
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε PDF υψηλής ποιότητας, αναζητήσιμα, σε C++ χρησιμοποιώντας το Aspose.Slides, με γρήγορα παραδείγματα κώδικα και προχωρημένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή των παρουσιάσεων PowerPoint (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF σε C++ προσφέρει αρκετά πλεονεκτήματα, συμπεριλαμβανομένης της συμβατότητας μεταξύ διαφορετικών συσκευών και της διατήρησης της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για έλεγχο της ποιότητας των εικόνων, να συμπεριλάβετε κρυφές διαφάνειες, να προστατεύσετε με κωδικό πρόσβασης τα αρχεία PDF, να εντοπίσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις στις ακόλουθες μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) κλάση και έπειτα αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) μέθοδο. Η [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) κλάση εκθέτει τη [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) μέθοδο που συνήθως χρησιμοποιείται για τη μετατροπή μιας παρουσίασης σε PDF.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides for C++ εισάγει τις πληροφορίες API του και τον αριθμό έκδοσης στα έγγραφα εξόδου. Για παράδειγμα, όταν μετατρέπεται μια παρουσίαση σε PDF, το Aspose.Slides γεμίζει το πεδίο Application με "*Aspose.Slides*" και το πεδίο PDF Producer με μια τιμή σε μορφή "*Aspose.Slides v XX.XX*". **Σημείωση** ότι δεν μπορείτε να υποδείξετε στο Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα έγγραφα εξόδου.
{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:
* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα παραγόμενα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και οι ιδιότητες αποτυπώνονται με ακρίβεια κατά τη μετατροπή, συμπεριλαμβανομένων:
* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφων
* Υπερσυνδέσεις
* Κεφαλίδες και υποσέλιδα
* Κουκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint σε PDF χρησιμοποιεί προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στα μέγιστα επίπεδα ποιότητας.

Το ακόλουθο παράδειγμα φορτώνει μια παρουσίαση και αποθηκεύει όλες τις ορατές διαφάνειες σε PDF χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις εξαγωγής.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Το Aspose προσφέρει έναν δωρεάν online [**Μετατροπέας PowerPoint σε PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) που παρουσιάζει τη διαδικασία μετατροπής παρουσίασης σε PDF. Μπορείτε να εκτελέσετε μια δοκιμή με αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές — ιδιότητες στην κλάση [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) — που σας επιτρέπουν να προσαρμόσετε το παραγόμενο PDF, να κλειδώσετε το PDF με κωδικό πρόσβασης ή να καθορίσετε πώς θα προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για ραστερ εικόνες, να καθορίσετε πώς θα χειρίζονται τα metafiles, να ορίσετε επίπεδο συμπίεσης για κείμενο, να διαμορφώσετε DPI για εικόνες, κ.ά.

Το ακόλουθο παράδειγμα εξάγει μια παρουσίαση σε PDF 1.5 με ποιότητα JPEG ορισμένη στο 90, ανάλυση εικόνας ορισμένη στα 300 DPI, metafiles αποθηκευμένα ως PNG, και συμπίεση κειμένου Flate.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Αυτόματη Επιλογή Συμπίεσης Εικόνας**

Όταν μια παρουσίαση περιέχει πολλές φωτογραφίες ή στιγμιότυπα οθόνης, η μείωση του μεγέθους του εξαγόμενου PDF μπορεί να το κάνει πιο εύκολο για αποστολή ή λήψη. Καλέστε [PdfOptions::set_BestImagesCompressionRatio](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/) με `true` για να επιλέξετε αυτόματα τον πιο κατάλληλο αλγόριθμο συμπίεσης για κάθε εικόνα κατά την εξαγωγή PDF.

Το ακόλουθο παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση, ενεργοποιεί την αυτόματη επιλογή συμπίεσης εικόνας και την αποθηκεύει ως έγγραφο PDF. Όλες οι άλλες ρυθμίσεις εξαγωγής PDF διατηρούν τις προεπιλεγμένες τιμές τους.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_BestImagesCompressionRatio(true);

auto presentation = MakeObject<Presentation>(u"image-heavy.pptx");
presentation->Save(u"image-heavy.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Αυτή η επιλογή επιλέγει αλγόριθμο συμπίεσης για κάθε εικόνα. Η μείωση της ποιότητας JPEG με [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) μειώνει την ποιότητα της εικόνας JPEG, ενώ η μείωση της ανάλυσης με [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) επιτρέπει στις εικόνες να υποδειγματοληφθούν σε μικρότερη ανάλυση, πράγμα που μπορεί να μειώσει τις λεπτομέρειες. Η ενεργοποίηση της αυτόματης επιλογής συμπίεσης δεν μειώνει από μόνη της καμία από αυτές τις ρυθμίσεις.

Η επιλογή αλγορίθμων συμπίεσης εικόνας απαιτεί πρόσθετο χρόνο επεξεργασίας και μνήμη. Η μείωση του μεγέθους εξαρτάται από τις εικόνες και τις ρυθμίσεις εξαγωγής της παρουσίασης· δεν υπάρχει εγγυημένη σταθερή μείωση για κάθε παρουσίαση.

### **Διατήρηση Ενσωματωμένων Αρχείων OLE ως Συνημμένα PDF**

Εάν μια παρουσίαση περιέχει ενσωματωμένο βιβλίο εργασίας Excel, ίσως θελήσετε οι παραλήπτες του PDF να έχουν πρόσβαση στα δεδομένα του βιβλίου εργασίας καθώς και να βλέπουν τις διαφάνειες. Καλέστε [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) με `true` για να διατηρήσετε τα ενσωματωμένα αρχεία OLE ως συνημμένα στο παραγόμενο PDF.

Η προεπιλεγμένη τιμή είναι `false`: η προεπισκόπηση ή το εικονίδιο του αντικειμένου OLE εμφανίζεται στη σελίδα PDF, αλλά το ενσωματωμένο αρχείο δεν συμπεριλαμβάνεται ως συνημμένο. Ορίζοντας την επιλογή σε `true` περιλαμβάνει επίσης τα δεδομένα του αρχείου. Η προεπισκόπηση παραμένει οπτική αναπαράσταση· το συνημμένο επιτρέπει στους παραλήπτες να ανοίξουν ή να αποθηκεύσουν το ενσωματωμένο αρχείο ξεχωριστά. Το αντικείμενο OLE δεν μετατρέπεται σε διαδραστικό φύλλο εργασίας Excel στη σελίδα PDF.

Το ακόλουθο παράδειγμα φορτώνει μια παρουσίαση που ήδη περιέχει ενσωματωμένο βιβλίο εργασίας Excel και το εξάγει σε PDF με το βιβλίο εργασίας συνημμένο.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Για να ελέγξετε το αποτέλεσμα:
1. Ανοίξτε το εξαγόμενο PDF σε προβολή που υποστηρίζει συνημμένα αρχεία, όπως το Adobe Acrobat Reader.
2. Ανοίξτε το **Συνημμένα** πάνελ του προγράμματος και εντοπίστε το ενσωματωμένο βιβλίο εργασίας.
3. Αποθηκεύστε το συνημμένο και ανοίξτε το στο Excel για να ελέγξετε τα δεδομένα του, ή ανοίξτε το απευθείας αν το πρόγραμμα το επιτρέπει. Η προεπισκόπηση στη σελίδα PDF είναι ξεχωριστή από το συνημμένο.

{{% alert color="info" title="Note" %}}
Τα πρότυπα PDF/A επιβάλλουν περιορισμούς στα συνημμένα: το PDF/A-1 απαγορεύει ενσωματωμένα αρχεία, το PDF/A-2 επιτρέπει μόνο συνημμένα PDF/A, και το PDF/A-3 επιτρέπει άλλους τύπους αρχείων, συμπεριλαμβανομένων των βιβλίων εργασίας Excel. Αυτές είναι απαιτήσεις των προτύπων, όχι περιορισμοί ειδικά του Aspose.Slides. Αυτό το παράδειγμα χρησιμοποιεί την προεπιλεγμένη ρύθμιση συμμόρφωσης PDF και δεν παρουσιάζει εξαγωγή PDF/A.
{{% /alert %}}

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε τη μέθοδο [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) από την κλάση [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Το ακόλουθο παράδειγμα εξάγει μια παρουσίαση σε PDF, συμπεριλαμβάνοντας τυχόν κρυφές διαφάνειες.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού Πρόσβασης**

Το ακόλουθο παράδειγμα εξάγει μια παρουσίαση σε PDF που απαιτεί τον κωδικό `password` για άνοιγμα. Τα δικαιώματα πρόσβασης επιτρέπουν εκτύπωση, συμπεριλαμβανομένης της εκτύπωσης υψηλής ποιότητας.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Εντοπισμός Αντικαταστάσεων Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) που σας επιτρέπει να εντοπίσετε αντικαταστάσεις γραμματοσειρών κατά τη διαδικασία μετατροπής παρουσίασης σε PDF.

Το ακόλουθο παράδειγμα εξάγει μια παρουσίαση σε PDF και εκτυπώνει προειδοποιήσεις αντικατάστασης γραμματοσειρών στην κονσόλα. Μια προειδοποίηση εκτυπώνεται μόνο όταν μια μη διαθέσιμη γραμματοσειρά αντικαθίσταται κατά την εξαγωγή.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Για περισσότερες πληροφορίες σχετικά με την αντικατάσταση γραμματοσειρών, δείτε το άρθρο [Αντικατάσταση Γραμματοσειρών](/slides/el/cpp/font-substitution/).
{{% /alert %}}

### **Διαχείριση Γραμματοσειρών χωρίς Αποκλειστικό Παχύ Στυλ**

Μια παρουσίαση μπορεί να εφαρμόσει παχύ στυλ σε κείμενο ακόμη και όταν η γραμματοσειρά της δεν διαθέτει αποκλειστικό παχύ στυλ. Το κείμενο μπορεί να εμφανίζεται παχύ μέσω συνθετικού παχουσμού, που πάχυναει τεχνητά τα κανονικά γλύφοι. Όταν αυτό το κείμενο φαίνεται πολύ βαρύ ή διαφέρει από την προτιμώμενη εμφάνιση στο PDF, δοκιμάστε να καλέσετε [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) με `true`. Αυτή η επιλογή αποδίδει το επηρεασμένο κείμενο ως bitmap κατά την εξαγωγή PDF και μπορεί να βελτιώσει την εμφάνισή του για ορισμένες γραμματοσειρές. Η προεπιλεγμένη τιμή είναι `false`.

Η δείγμα παρουσίαση περιέχει δύο πλαίσια κειμένου: ένα με κανονικό κείμενο και ένα με παχύ στυλ στην ίδια γραμματοσειρά, η οποία δεν έχει αποκλειστικό παχύ στυλ. Το ακόλουθο παράδειγμα φορτώνει την παρουσίαση, ενεργοποιεί τη ραστεροποίηση μη υποστηριζόμενων στυλ γραμματοσειράς και την εξάγει σε PDF:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Οι παρακάτω προεπισκοπήσεις δείχνουν την έξοδο με την επιλογή απενεργοποιημένη και ενεργοποιημένη. Σε αυτό το παράδειγμα, το παχύ κείμενο έχει βαρύτερα στίγματα όταν η επιλογή είναι απενεργοποιημένη. Με την επιλογή ενεργοποιημένη, τα στίγματα είναι πιο ελαφριά· το κανονικό κείμενο παραμένει αμετάβλητο. Συγκρίνετε τα αποτελέσματα πριν επιλέξετε τη ρύθμιση για την παρουσίασή σας.

| Επιλογή απενεργοποιημένη (`false`, η προεπιλογή) | Επιλογή ενεργοποιημένη (`true`) |
|---|---|
| ![PDF με απενεργοποιημένη ραστεροποίηση μη υποστηριζόμενου στυλ γραμματοσειράς](unsupported-bold-disabled.png) | ![PDF με ενεργοποιημένη ραστεροποίηση μη υποστηριζόμενου στυλ γραμματοσειράς](unsupported-bold-enabled.png) |

Σε αυτό το παράδειγμα, η ενεργοποίηση της επιλογής μετατρέπει μόνο το παχύ κείμενο σε bitmap: δεν μπορεί να επιλεγεί, αντιγραφεί ή αναζητηθεί ως κείμενο χωρίς OCR, και οι άκρες του φαίνονται πιο μαλακές σε ζουμ 800%. Το κανονικό κείμενο παραμένει αναζητήσιμο. Με την επιλογή απενεργοποιημένη, και οι δύο συμβολοσειρές παραμένουν κείμενο.

Αυτή η επιλογή ραστεροποιεί κείμενο μορφοποιημένο ως παχύ όταν η γραμματοσειρά του δεν έχει αποκλειστικό παχύ στυλ. [Αντικατάσταση Γραμματοσειρών](/slides/el/cpp/font-substitution/) επιλέγει εναλλακτική γραμματοσειρά όταν η αρχική δεν είναι διαθέσιμη.

## **Μετατροπή Επιλεγμένων Διαφανειών από PowerPoint σε PDF**

Το ακόλουστο παράδειγμα εξάγει τις διαφάνειες 1 και 3 από μια παρουσίαση σε PDF. Οι αριθμοί διαφανειών σε αυτόν τον πίνακα είναι βάση ενός (one‑based), και η εισερχόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον τρεις διαφάνειες.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Το ακόλουθο παράδειγμα αντιγράφει την πρώτη διαφάνεια από μια παρουσίαση σε νέα παρουσίαση με μέγεθος διαφάνειας 612 × 792 points (8.5 × 11 ίντσες). Κλιμακώνει το περιεχόμενο της διαφάνειας ώστε να ταιριάζει και την εξάγει ως μοναδική διαφάνεια σε PDF.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Μετατροπή PowerPoint σε PDF σε Προβολή Σημειώσεων Διαφάνειας**

Το ακόλουστο παράδειγμα εξάγει μια παρουσίαση σε PDF, τοποθετώντας τις σημειώσεις του ομιλητή κάτω από κάθε διαφάνεια. Χρησιμοποιήστε μια παρουσίαση που περιέχει σημειώσεις ομιλητή για να δείτε το αποτέλεσμα.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **Πρότυπα Προσβασιμότητας και Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Οδηγίες Προσβασιμότητας Περιεχομένου Ιστού (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b** και **PDF/UA**.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Το Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντάς σας να μετατρέψετε αρχεία PDF σε δημοφιλείς μορφές αρχείων. Μπορείτε να εκτελέσετε μετατροπές [PDF σε HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF σε εικόνα](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές — [PDF σε SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — υποστηρίζονται επίσης.
{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει πολύπλογα γραφικά όπως SmartArt, διαγράμματα και τύπους ως μία ενιαία μορφή. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως εικονίδια· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρη τη μορφή.

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλά αρχεία PowerPoint σε PDF μαζικά;**

Ναι, το Aspose.Slides υποστηρίζει παρτίδα μετατροπής πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να διατρέξετε τα αρχεία σας και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματιστικά.

**Μπορώ να προστατεύσω με κωδικό πρόσβασης το μετατρεπόμενο PDF;**

Ναι. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) για να ορίσετε κωδικό πρόσβασης και να καθορίσετε δικαιώματα πρόσβασης κατά τη διαδικασία μετατροπής.

**Πώς να συμπεριλάβω κρυφές διαφάνειες στο PDF;**

Χρησιμοποιήστε τη μέθοδο [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) για να συμπεριλάβετε κρυφές διαφάνειες στο παραγόμενο PDF.

**Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα εικόνας χρησιμοποιώντας μεθόδους όπως [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) και [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) για να εξασφαλίσετε εικόνες υψηλής ποιότητας στο PDF σας.

**Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;**

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε PDFs που συμμορφώνονται με διάφορα πρότυπα, συμπεριλαμβανομένων των PDF/A1a, PDF/A1b και PDF/UA, διασφαλίζοντας ότι τα έγγραφά σας πληρούν τις απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Aspose.Slides for C++ Documentation](/slides/el/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)