---
title: Μετατροπή PPT και PPTX σε PDF με .NET [Συμπεριλαμβανομένα Προηγμένα Χαρακτηριστικά]
linktitle: PowerPoint σε PDF
type: docs
weight: 40
url: /el/net/convert-powerpoint-to-pdf/
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
- .NET
- C#
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε υψηλής ποιότητας, αναζητήσιμα PDF σε .NET χρησιμοποιώντας Aspose.Slides, με γρήγορα παραδείγματα κώδικα C# και προηγμένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF με C# προσφέρει πολλά πλεονεκτήματα, όπως συμβατότητα με διαφορετικές συσκευές και διατήρηση της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για τον έλεγχο της ποιότητας των εικόνων, να συμπεριλάβετε κρυφές διαφάνειες, να προστατεύσετε με κωδικό πρόσβασης τα αρχεία PDF, να εντοπίσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Με χρήση του Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις στις ακόλουθες μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και στη συνέχεια αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/). Η κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) εκθέτει τη μέθοδο [Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) η οποία συνήθως χρησιμοποιείται για τη μετατροπή μιας παρουσίασης σε PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Το Aspose.Slides for .NET εισάγει τις πληροφορίες του API και τον αριθμό έκδοσης στα έγγραφα εξόδου. Για παράδειγμα, κατά τη μετατροπή μιας παρουσίασης σε PDF, το Aspose.Slides συμπληρώνει το πεδίο Application με "*Aspose.Slides*" και το πεδίο PDF Producer με τιμή σε μορφή "*Aspose.Slides v XX.XX*". **Σημείωση** ότι δεν μπορείτε να υποδείξετε στο Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα έγγραφα εξόδου.

{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, εξασφαλίζοντας ότι τα παραγόμενα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και οι ιδιότητες αποδίδονται ακριβώς κατά τη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Κείμενα και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφων
* Υπερσυνδέσμους
* Κεφαλίδες και υποσέλιδα
* Κουκκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint‑σε‑PDF χρησιμοποιεί προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στα μέγιστα επίπεδα ποιότητας.

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση (PPT, PPTX, ODP κ.λπ.) σε PDF:

```c#
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Αποθηκεύστε την παρουσίαση ως PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Το Aspose προσφέρει έναν δωρεάν διαδικτυακό [**μετατροπέα PowerPoint σε PDF**](https://products.aspose.app/slides/el/conversion/ppt-to-pdf) που επιδεικνύει τη διαδικασία μετατροπής παρουσίασης‑σε‑PDF. Μπορείτε να εκτελέσετε μια δοκιμή με αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.

{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές—ιδιότητες της κλάσης [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/)—που σας επιτρέπουν να προσαρμόσετε το παραγόμενο PDF, να το κλειδώσετε με κωδικό πρόσβασης ή να ορίσετε πώς θα προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Με χρήση προσαρμοσμένων επιλογών μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για ριζικές εικόνες, να καθορίσετε πώς θα διαχειριστούν τα metafiles, να ορίσετε επίπεδο συμπίεσης για κείμενο, να ρυθμίσετε DPI για εικόνες κ.λπ.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με πολλές προσαρμοσμένες επιλογές.

```c#
// Δημιουργία της κλάσης PdfOptions.
var pdfOptions = new PdfOptions
{
    // Ορισμός της ποιότητας για εικόνες JPG.
    JpegQuality = 90,

    // Ορισμός DPI για εικόνες.
    SufficientResolution = 300,

    // Ορισμός της συμπεριφοράς για μετααρχεία.
    SaveMetafilesAsPng = true,

    // Ορισμός του επιπέδου συμπίεσης κειμένου για το κειμενικό περιεχόμενο.
    TextCompression = PdfTextCompression.Flate,

    // Καθορισμός της λειτουργίας συμμόρφωσης PDF.
    Compliance = PdfCompliance.Pdf15
};

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Αποθήκευση της παρουσίασης ως έγγραφο PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε την ιδιότητα [ShowHiddenSlides](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/showhiddenslides/) της κλάσης [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με κρυφές διαφάνειες:

```c#
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Δημιουργία της κλάσης PdfOptions.
var pdfOptions = new PdfOptions();

// Προσθήκη κρυφών διαφανειών.
pdfOptions.ShowHiddenSlides = true;

// Αποθήκευση της παρουσίασης ως PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού Πρόσβασης**

Αυτός ο κώδικας C# επιδεικνύει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF προστατευμένο με κωδικό πρόσβασης χρησιμοποιώντας τις παραμέτρους προστασίας της κλάσης [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/):

```c#
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Δημιουργία της κλάσης PdfOptions.
var pdfOptions = new PdfOptions();

// Ορισμός κωδικού πρόσβασης PDF και δικαιωμάτων πρόσβασης.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Αποθήκευση της παρουσίασης ως PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Εντοπισμός Αντικαταστάσεων Γραμματοσειράς**

Το Aspose.Slides παρέχει την ιδιότητα [WarningCallback](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveoptions/warningcallback/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/), επιτρέποντάς σας να εντοπίσετε αντικαταστάσεις γραμματοσειρών κατά τη διαδικασία μετατροπής παρουσίασης‑σε‑PDF.

Αυτός ο κώδικας C# δείχνει πώς να εντοπίσετε αντικαταστάσεις γραμματοσειράς:

```c#
public static void Main()
{
    // Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file. 
    using var presentation = new Presentation("sample.pptx");

    // Ορισμός της λειτουργίας επιστροφής προειδοποίησης στις επιλογές PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Αποθήκευση της παρουσίασης ως PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Υλοποίηση της λειτουργίας επιστροφής προειδοποίησης.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Για περισσότερες πληροφορίες σχετικά με την λήψη callbacks για αντικατάσταση γραμματοσειρών κατά τη διαδικασία απόδοσης, δείτε [Getting Warning Callbacks for Fonts Substitution](/slides/el/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Για περισσότερες πληροφορίες σχετικά με την αντικατάσταση γραμματοσειράς, δείτε το άρθρο [Font Substitution](/slides/el/net/font-substitution/).

{{% /alert %}} 

## **Μετατροπή Επιλεγμένων Διαφανειών από PowerPoint σε PDF**

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μόνο συγκεκριμένες διαφάνειες από μια παρουσίαση PowerPoint σε PDF:

```c#
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// Ορισμός πίνακα αριθμών διαφανειών.
int[] slides = { 1, 3 };

// Αποθήκευση της παρουσίασης ως PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με καθορισμένο μέγεθος διαφάνειας:

```c#
var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **Μετατροπή PowerPoint σε PDF σε Προβολή Σημειώσεων Διάφάνειας**

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF που περιλαμβάνει σημειώσεις:

```c#
// Φόρτωση παρουσίασης PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Διαμόρφωση των επιλογών PDF με διάταξη σημειώσεων.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Αποθήκευση της παρουσίασης σε PDF με σημειώσεις.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Πρόσβαση και Πρότυπα Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Οδηγίες Προσβασιμότητας Περιεχομένου Ιστού (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από τα ακόλουθα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b** και **PDF/UA**.

Αυτός ο κώδικας C# επιδεικνύει μια διαδικασία μετατροπής PowerPoint‑σε‑PDF που παράγει πολλαπλά PDFs βάσει διαφορετικών προτύπων συμμόρφωσης:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert title="Note" color="warning" %}} 

Το Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντας τη μετατροπή αρχείων PDF σε δημοφιλείς μορφές αρχείων. Μπορείτε να εκτελέσετε μετατροπές [PDF to HTML](https://products.aspose.com/slides/el/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/el/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/el/net/conversion/pdf-to-jpg/), και [PDF to PNG](https://products.aspose.com/slides/el/net/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές—[PDF to SVG](https://products.aspose.com/slides/el/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/el/net/conversion/pdf-to-tiff/), και [PDF to XML](https://products.aspose.com/slides/el/net/conversion/pdf-to-xml/)—επίσης υποστηρίζονται.

{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει περίπλογα γραφικά όπως SmartArt, διαγράμματα και τύπους ως μία ενιαία μορφή. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως τεχνουργήματα· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρη τη μορφή.

## **FAQ**

**Μπορώ να μετατρέψω πολλά αρχεία PowerPoint σε PDF μαζικά;**

Ναι, το Aspose.Slides υποστηρίζει μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επαναλάβετε τα αρχεία σας και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματιστικά.

**Μπορώ να προστατεύσω με κωδικό πρόσβασης το PDF που δημιουργείται;**

Απόλυτα. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/) για να ορίσετε κωδικό πρόσβασης και να καθορίσετε δικαιώματα πρόσβασης κατά τη διαδικασία μετατροπής.

**Πώς μπορώ να συμπεριλάβω κρυφές διαφάνειες στο PDF;**

Ορίστε την ιδιότητα `ShowHiddenSlides` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/) σε `true` για να συμπεριλάβετε τις κρυφές διαφάνειες στο παραγόμενο PDF.

**Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα εικόνας ορίζοντας ιδιότητες όπως `JpegQuality` και `SufficientResolution` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/) ώστε να διασφαλίσετε υψηλής ποιότητας εικόνες στο PDF σας.

**Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;**

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε PDFs που συμμορφώνονται με διάφορα πρότυπα, συμπεριλαμβανομένων των PDF/A1a, PDF/A1b και PDF/UA, εξασφαλίζοντας ότι τα έγγραφά σας πληρούν τις απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides για .NET](/slides/el/net/)
- [Αναφορά API Aspose.Slides για .NET](https://reference.aspose.com/slides/el/net/)
- [Δωρεάν Online Μετατροπείς Aspose](https://products.aspose.app/slides/el/conversion)