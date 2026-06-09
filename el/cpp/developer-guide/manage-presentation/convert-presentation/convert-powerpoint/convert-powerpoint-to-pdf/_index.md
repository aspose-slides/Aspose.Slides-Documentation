---
title: Μετατροπή PPT και PPTX σε PDF σε C++ [Συμπεριλαμβανομένες Προηγμένες Λειτουργίες]
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
description: "Μετατροπή PowerPoint PPT/PPTX σε PDF υψηλής ποιότητας και αναζητήσιμα σε C++ χρησιμοποιώντας Aspose.Slides, με γρήγορα παραδείγματα κώδικα και προηγμένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF σε C++ προσφέρει αρκετά πλεονεκτήματα, συμπεριλαμβανομένης της συμβατότητας μεταξύ διαφόρων συσκευών και της διατήρησης της διάταξης και του μορφοποιήματος της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέπετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιείτε διάφορες επιλογές για τον έλεγχο της ποιότητας εικόνων, να περιλαμβάνετε κρυφές διαφάνειες, να προστατεύετε με κωδικό πρόσβασης τα αρχεία PDF, να ανιχνεύετε υποκαταστάσεις γραμματοσειρών, να επιλέγετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόζετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Χρησιμοποιώντας Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις στις ακόλουθες μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) και, στη συνέχεια, αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο `Save`. Η κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) εκθέτει τη μέθοδο `Save` η οποία χρησιμοποιείται συνήθως για τη μετατροπή μιας παρουσίασης σε PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Το Aspose.Slides για C++ εισάγει τις πληροφορίες του API του και τον αριθμό έκδοσης στα έγγραφα εξόδου. Για παράδειγμα, κατά τη μετατροπή μιας παρουσίασης σε PDF, το Aspose.Slides γεμίζει το πεδίο Application με "*Aspose.Slides*" και το πεδίο PDF Producer με μια τιμή σε μορφή "*Aspose.Slides v XX.XX*". **Σημείωση** ότι δεν μπορείτε να υποδείξετε στο Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα έγγραφα εξόδου.
{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, εξασφαλίζοντας ότι τα παραγόμενα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και τα χαρακτηριστικά αποδίδονται με ακρίβεια στη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφων
* Υπερσυνδέσμους
* Κεφαλίδες και υποσέλιδα
* Κουκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint σε PDF χρησιμοποιεί τις προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στο μέγιστο επίπεδο ποιότητας.

Αυτή η C++ κώδικας δείχνει πώς να μετατρέψετε μια παρουσίαση (PPT, PPTX, ODP κ.λπ.) σε PDF:

```c++
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 
Η Aspose προσφέρει έναν δωρεάν διαδικτυακό [**Μετατροπέας PowerPoint σε PDF**](https://products.aspose.app/slides/el/conversion/ppt-to-pdf) που επιδεικνύει τη διαδικασία μετατροπής παρουσίασης σε PDF. Μπορείτε να εκτελέσετε μια δοκιμή με αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμόσιμες επιλογές — ιδιότητες στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/) — που επιτρέπουν να προσαρμόσετε το παραγόμενο PDF, να κλειδώσετε το PDF με κωδικό πρόσβασης ή να καθορίσετε πώς θα προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για ραστές εικόνες, να καθορίσετε πώς θα διαχειρίζονται τα μετααρχεία, να ορίσετε επίπεδο συμπίεσης για κείμενο, να διαμορφώσετε DPI για εικόνες και άλλα.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με πολλές προσαρμοσμένες επιλογές.

```c++
// Δημιουργήστε την κλάση PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Ορίστε την ποιότητα για εικόνες JPG.
pdfOptions->set_JpegQuality(90);

// Ορίστε DPI για εικόνες.
pdfOptions->set_SufficientResolution(300);

// Ορίστε τη συμπεριφορά για μετααρχεία.
pdfOptions->set_SaveMetafilesAsPng(true);

// Ορίστε το επίπεδο συμπίεσης κειμένου για το κειμενικό περιεχόμενο.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Ορίστε τη λειτουργία συμμόρφωσης PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Αποθηκεύστε την παρουσίαση ως έγγραφο PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε τη μέθοδο [set_ShowHiddenSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) από την κλάση [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με τις κρυφές διαφάνειες να συμπεριλαμβάνονται:

```c++
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Δημιουργήστε την κλάση PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Προσθήκη κρυφών διαφανειών.
pdfOptions->set_ShowHiddenSlides(true);

// Αποθηκεύστε την παρουσίαση ως PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού Πρόσβασης**

Αυτός ο κώδικας C++ επιδεικνύει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με προστασία κωδικού πρόσβασης χρησιμοποιώντας τις παραμέτρους προστασίας από την κλάση [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/):

```c++
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Δημιουργήστε την κλάση PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Ορίστε κωδικό πρόσβασης PDF και δικαιώματα πρόσβασης.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Αποθηκεύστε την παρουσίαση ως PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Ανίχνευση Υποκατάστασης Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [set_WarningCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveoptions/set_warningcallback/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/), επιτρέποντάς σας να ανιχνεύετε υποκαταστάσεις γραμματοσειρών κατά τη διαδικασία μετατροπής παρουσίασης σε PDF.

Αυτός ο κώδικας C++ δείχνει πώς να ανιχνεύσετε υποκαταστάσεις γραμματοσειρών:

```c++
// Υλοποίηση της συνάρτησης προειδοποίησης.
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
    // Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Ορίστε τη συνάρτηση προειδοποίησης σε επιλογές PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Αποθηκεύστε την παρουσίαση ως PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 
Για περισσότερες πληροφορίες σχετικά με τη λήψη callbacks για υποκατάσταση γραμματοσειρών κατά τη διαδικασία απόδοσης, δείτε το [Getting Warning Callbacks for Fonts Substitution](/slides/el/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Για περισσότερες πληροφορίες σχετικά με την υποκατάσταση γραμματοσειρών, δείτε το άρθρο [Font Substitution](/slides/el/cpp/font-substitution/).
{{% /alert %}} 

## **Μετατροπή Επιλεγμένων Διαφανειών από PowerPoint σε PDF**

Αυτός ο κώδικας C++ επιδεικνύει πώς να μετατρέψετε μόνο συγκεκριμένες διαφάνειες από μια παρουσίαση PowerPoint σε PDF:

```C++
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Ορίστε τον πίνακα αριθμών διαφανειών.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Αποθηκεύστε την παρουσίαση ως PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Αυτός ο κώδικας C++ επιδεικνύει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με καθορισμένο μέγεθος διαφάνειας:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Μετατροπή PowerPoint σε PDF σε Προβολή Σημειώσεων Διαφάνειας**

Αυτός ο κώδικας C++ επιδεικνύει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF που περιλαμβάνει σημειώσεις:

```C++
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Διαμορφώστε τις επιλογές PDF με διάταξη σημειώσεων.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Αποθηκεύστε την παρουσίαση σε PDF με σημειώσεις.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Πρόσβαση και Πρότυπα Συμβατότητας για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Οδηγίες Πρόσβασης σε Ιστό Περιεχομένου (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b**, και **PDF/UA**.

Αυτός ο κώδικας C++ επιδεικνύει μια διαδικασία μετατροπής PowerPoint σε PDF που παράγει πολλαπλά PDF με βάση διαφορετικά πρότυπα συμμόρφωσης:

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

{{% alert title="Note" color="warning" %}} 
Το Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντάς σας να μετατρέψετε αρχεία PDF σε δημοφιλείς μορφές αρχείων. Μπορείτε να εκτελέσετε μετατροπές [PDF σε HTML](https://products.aspose.com/slides/el/cpp/conversion/pdf-to-html/), [PDF σε εικόνα](https://products.aspose.com/slides/el/cpp/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/el/cpp/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/el/cpp/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές — [PDF σε SVG](https://products.aspose.com/slides/el/cpp/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/el/cpp/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/el/cpp/conversion/pdf-to-xml/) — υποστηρίζονται επίσης.
{{% /alert %}}

> **Σημείωση:** Όταν εξάγετε σε PDF/UA, το Aspose.Slides αντιμετωπίζει πολύπλογα γραφικά όπως SmartArt, διαγράμματα και τύπους ως ένα ενιαίο σχήμα. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως τέχνηματα· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρο το σχήμα.

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλαπλά αρχεία PowerPoint σε PDF μαζικά;**

Ναι, το Aspose.Slides υποστηρίζει μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επαναλάβετε τα αρχεία σας και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματιστικά.

**Μπορεί να προστατευθεί με κωδικό πρόσβασης το μετατρεπόμενο PDF;**

Απόλυτα. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/) για να ορίσετε κωδικό πρόσβασης και να καθορίσετε δικαιώματα πρόσβασης κατά τη διαδικασία μετατροπής.

**Πώς να συμπεριλάβω κρυφές διαφάνειες στο PDF;**

Χρησιμοποιήστε τη μέθοδο `set_ShowHiddenSlides` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες στο παραγόμενο PDF.

**Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα εικόνας χρησιμοποιώντας μεθόδους όπως `set_JpegQuality` και `set_SufficientResolution` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/) για να εξασφαλίσετε εικόνες υψηλής ποιότητας στο PDF σας.

**Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;**

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε PDF που συμμορφώνονται με διάφορα πρότυπα, όπως PDF/A1a, PDF/A1b και PDF/UA, διασφαλίζοντας ότι τα έγγραφά σας πληρούν τις απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides για C++](/slides/el/cpp/)
- [Αναφορά API Aspose.Slides για C++](https://reference.aspose.com/slides/el/cpp/)
- [Δωρεάν Online Μετατροπείς Aspose](https://products.aspose.app/slides/el/conversion)