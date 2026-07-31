---
title: Μετατροπή PPT και PPTX σε PDF σε C++ [Συμπεριλαμβάνονται Προχωρημένες Λειτουργίες]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε υψηλής ποιότητας, αναζητήσιμα PDF σε C++ χρησιμοποιώντας το Aspose.Slides, με γρήγορα παραδείγματα κώδικα και προχωρημένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP, κ.λπ.) σε μορφή PDF σε C++ προσφέρει πολλά πλεονεκτήματα, όπως συμβατότητα μεταξύ διαφορετικών συσκευών και διατήρηση της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για έλεγχο της ποιότητας εικόνας, να συμπεριλάβετε κρυφές διαφάνειες, να προστατέψετε με κωδικό πρόσβασης τα αρχεία PDF, να εντοπίσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα τελικά έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Με τη χρήση του Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις στις ακόλουθες μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) και στη συνέχεια αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο `Save`. Η κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) εκτίθενται τη μέθοδο `Save` που χρησιμοποιείται συνήθως για τη μετατροπή μιας παρουσίασης σε PDF.

{{%  alert title="ΣΗΜΕΙΩΣΗ"  color="warning"   %}} 

Το Aspose.Slides for C++ εισάγει τις πληροφορίες του API του και τον αριθμό έκδοσης στα παραγόμενα έγγραφα. Για παράδειγμα, κατά τη μετατροπή μιας παρουσίασης σε PDF, το Aspose.Slides γεμίζει το πεδίο Application με "*Aspose.Slides*" και το πεδίο PDF Producer με τιμή στη μορφή "*Aspose.Slides v XX.XX*". **Σημείωση** ότι δεν μπορείτε να απαιτήσετε από το Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα παραγόμενα έγγραφα.

{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα προκύπτοντα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Στοιχεία και ιδιότητες αποδίδονται με ακρίβεια στη μετατροπή, συμπεριλαμβανομένων:

* Εικόνων
* Πλαισίων κειμένου και σχημάτων
* Μορφοποίησης κειμένου
* Μορφοποίησης παραγράφων
* Υπερσυνδέσεων
* Κεφαλίδων και υποσέλιδων
* Κουκίδων
* Πινάκων

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint‑σε‑PDF χρησιμοποιεί προεπιλεγμένες επιλογές. Σε αυτή την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στα μέγιστα επίπεδα ποιότητας.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση (PPT, PPTX, ODP, κ.λπ.) σε PDF:

```c++
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Αποθηκεύστε την παρουσίαση ως PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Το Aspose προσφέρει έναν δωρεάν διαδικτυακό [**μετατροπέα PowerPoint σε PDF**](https://products.aspose.app/slides/el/conversion/ppt-to-pdf) που δείχνει τη διαδικασία μετατροπής παρουσίασης‑σε‑PDF. Μπορείτε να εκτελέσετε μια δοκιμή με αυτόν τον μετατροπέα για ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.

{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές—ιδιότητες της κλάσης [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/)—που σας επιτρέπουν να προσαρμόσετε το παραγόμενο PDF, να το κλειδώσετε με κωδικό πρόσβασης ή να καθορίσετε πώς θα προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Με τις προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για ραστερ εικόνες, να καθορίσετε πώς θα διαχειριστούν τα metafiles, να θέσετε επίπεδο συμπίεσης για κείμενο, να ρυθμίσετε DPI για εικόνες κ.λπ.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με πολλαπλές προσαρμοσμένες επιλογές.

```c++
// Δημιουργία της κλάσης PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Ορισμός ποιότητας για εικόνες JPG.
pdfOptions->set_JpegQuality(90);

// Ορισμός DPI για εικόνες.
pdfOptions->set_SufficientResolution(300);

// Ορισμός συμπεριφοράς για μετααρχεία.
pdfOptions->set_SaveMetafilesAsPng(true);

// Ορισμός επιπέδου συμπίεσης κειμένου για το κειμενικό περιεχόμενο.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Ορισμός λειτουργίας συμμόρφωσης PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Αποθήκευση της παρουσίασης ως έγγραφο PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Αν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε τη μέθοδο [set_ShowHiddenSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) της κλάσης [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο προκύπτον PDF.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με τις κρυφές διαφάνειες να περιλαμβάνονται:

```c++
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Δημιουργία της κλάσης PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Προσθήκη κρυφών διαφανειών.
pdfOptions->set_ShowHiddenSlides(true);

// Αποθήκευση της παρουσίασης ως PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού**

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με προστασία κωδικού πρόσβασης χρησιμοποιώντας τις παραμέτρους προστασίας της κλάσης [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/):

```c++
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Δημιουργία της κλάσης PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Ορισμός κωδικού πρόσβασης PDF και δικαιωμάτων πρόσβασης.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Αποθήκευση της παρουσίασης ως PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Ανίχνευση Αντικαταστάσεων Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [set_WarningCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveoptions/set_warningcallback/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/), επιτρέποντάς σας να εντοπίσετε αντικαταστάσεις γραμματοσειρών κατά τη διαδικασία μετατροπής παρουσίασης‑σε‑PDF.

Αυτός ο κώδικας C++ δείχνει πώς να εντοπίσετε αντικαταστάσεις γραμματοσειρών:

```c++
// Υλοποίηση της κλήσης προειδοποίησης.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss && 
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Ορισμός της κλήσης προειδοποίησης στις επιλογές PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Αποθήκευση της παρουσίασης ως PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

Για περισσότερες πληροφορίες σχετικά με λήψη callbacks για αντικαταστάσεις γραμματοσειρών κατά τη διαδικασία απόδοσης, δείτε το [Getting Warning Callbacks for Fonts Substitution](/slides/el/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Για περισσότερες πληροφορίες σχετικά με την αντικατάσταση γραμματοσειρών, δείτε το άρθρο [Font Substitution](/slides/el/cpp/font-substitution/).

{{% /alert %}} 

## **Μετατροπή Επιλεγμένων Διαφανειών από PowerPoint σε PDF**

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μόνο συγκεκριμένες διαφάνειες από μια παρουσίαση PowerPoint σε PDF:

```C++
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Ορισμός πίνακα αριθμών διαφανειών.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Αποθήκευση της παρουσίασης ως PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με καθορισμένο μέγεθος διαφάνειας:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Δημιουργία νέας παρουσίασης με προσαρμοσμένο μέγεθος διαφάνειας.
auto resizedPresentation = MakeObject<Presentation>();

// Ορισμός προσαρμοσμένου μεγέθους διαφάνειας.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Κλωνοποίηση της πρώτης διαφάνειας από την αρχική παρουσίαση.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Αποθήκευση της μεγέθυνσης παρουσίασης ως PDF με σημειώσεις.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Μετατροπή PowerPoint σε PDF με Προβολή Σημειώσεων Διαφάνειας**

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF που περιλαμβάνει σημειώσεις:

```C++
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Διαμόρφωση των επιλογών PDF με διάταξη Σημειώσεων.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Αποθήκευση της παρουσίασης σε PDF με σημειώσεις.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Πρότυπα Προσβασιμότητας και Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Οδηγίες Προσβασιμότητας Περιεχομένου Ιστού (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από τα εξής πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b** και **PDF/UA**.

Αυτός ο κώδικας C++ δείχνει μια διαδικασία μετατροπής PowerPoint‑σε‑PDF που παράγει πολλαπλά PDF με διαφορετικά πρότυπα συμμόρφωσης:

```C++
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

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Το Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντάς σας να μετατρέψετε αρχεία PDF σε δημοφιλείς μορφές αρχείων. Μπορείτε να πραγματοποιήσετε μετατροπές [PDF σε HTML](https://products.aspose.com/slides/el/cpp/conversion/pdf-to-html/), [PDF σε εικόνα](https://products.aspose.com/slides/el/cpp/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/el/cpp/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/el/cpp/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές—[PDF σε SVG](https://products.aspose.com/slides/el/cpp/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/el/cpp/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/el/cpp/conversion/pdf-to-xml/)—υποστηρίζονται επίσης.

{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει σύνθετα γραφικά όπως SmartArt, διαγράμματα και τύπους ως μία ενιαία μορφή. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως τεχνητά αντικείμενα· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρη τη μορφή.

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλά αρχεία PowerPoint σε PDF μαζικά;**

Ναι, το Aspose.Slides υποστηρίζει μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επαναλάβετε τα αρχεία σας και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματικά.

**Μπορώ να προστατέψω με κωδικό πρόσβασης το PDF που δημιουργείται;**

Απόλυτα. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/) για να ορίσετε κωδικό πρόσβασης και να ορίσετε δικαιώματα πρόσβασης κατά τη διαδικασία μετατροπής.

**Πώς μπορώ να συμπεριλάβω κρυφές διαφάνειες στο PDF;**

Χρησιμοποιήστε τη μέθοδο `set_ShowHiddenSlides` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες στο παραγόμενο PDF.

**Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα εικόνας χρησιμοποιώντας μεθόδους όπως `set_JpegQuality` και `set_SufficientResolution` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/) για να εξασφαλίσετε υψηλής ποιότητας εικόνες στο PDF σας.

**Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;**

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε PDF που συμμορφώνονται με διάφορα πρότυπα, συμπεριλαμβανομένων των PDF/A1a, PDF/A1b και PDF/UA, διασφαλίζοντας ότι τα έγγραφά σας πληρούν τις απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides for C++](/slides/el/cpp/)
- [Αναφορά API Aspose.Slides for C++](https://reference.aspose.com/slides/el/cpp/)
- [Δωρεάν Διαδικτυακοί Μετατροπείς Aspose](https://products.aspose.app/slides/el/conversion)