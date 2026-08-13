---
title: Μετατροπή PPT και PPTX σε PDF στο .NET [Συμπεριλαμβάνονται Προηγμένα Χαρακτηριστικά]
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
description: "Μετατρέψτε PowerPoint PPT/PPTX σε PDF υψηλής ποιότητας, αναζητήσιμα, στο .NET χρησιμοποιώντας το Aspose.Slides, με γρήγορα παραδείγματα κώδικα C# και προηγμένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF σε C# προσφέρει διάφορα πλεονεκτήματα, όπως συμβατότητα σε διαφορετικές συσκευές και διατήρηση της διάταξης και μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέπετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιείτε διάφορες επιλογές για έλεγχο της ποιότητας εικόνων, να συμπεριλάβετε κρυφές διαφάνειες, να προστατεύετε με κωδικό πρόσβασης τα αρχεία PDF, να εντοπίζετε αντικαταστάσεις γραμματοσειρών, να επιλέγετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόζετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Με τη χρήση του Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις στα ακόλουθα μορφότυπα σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και, στη συνέχεια, αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/). Η κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) εκθέτει τη μέθοδο [Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) που χρησιμοποιείται συνήθως για τη μετατροπή μιας παρουσίασης σε PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Το Aspose.Slides for .NET προσθέτει πληροφορίες API και αριθμό έκδοσης στα έγγραφα εξόδου. Για παράδειγμα, κατά τη μετατροπή μιας παρουσίασης σε PDF, το Aspose.Slides συμπληρώνει το πεδίο Application με "*Aspose.Slides*" και το πεδίο PDF Producer με μια τιμή σε μορφή "*Aspose.Slides v XX.XX*". **Σημείωση** ότι δεν μπορείτε να ζητήσετε από το Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα έγγραφα εξόδου.

{{% /alert %}}

Το Aspose.Slides επιτρέπει τη μετατροπή:

* Ολόκληρων παρουσιάσεων σε PDF
* Συγκεκριμένων διαφανειών από μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα παραγόμενα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Στοιχεία και ιδιότητες αποδίδονται με ακρίβεια στη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφων
* Υπερσυνδέσμους
* Κεφαλίδες και υποσέλιδες
* Κουκκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint‑σε‑PDF χρησιμοποιεί τις προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στα μέγιστα επίπεδα ποιότητας.

Αυτό το παράδειγμα κώδικα C# δείχνει πώς να μετατρέψετε μια παρουσίαση (PPT, PPTX, ODP κ.λπ.) σε PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Αποθήκευση της παρουσίασης ως PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Το Aspose προσφέρει έναν δωρεάν διαδικτυακό [**μετατροπέα PowerPoint σε PDF**](https://products.aspose.app/slides/el/conversion/ppt-to-pdf) που επιδεικνύει τη διαδικασία μετατροπής παρουσίασης‑σε‑PDF. Μπορείτε να εκτελέσετε μια δοκιμή με αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφηκε εδώ.

{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές—ιδιότητες της κλάσης [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/)—που σας επιτρέπουν να προσαρμόσετε το παραγόμενο PDF, να κλειδώσετε το PDF με κωδικό πρόσβασης ή να καθορίσετε πώς θα προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Με τις προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε το προτιμώμενο επίπεδο ποιότητας για raster εικόνες, να καθορίσετε πώς θα χειριστούν τα metafile, να ορίσετε επίπεδο συμπίεσης για κείμενο, να ρυθμίσετε DPI για εικόνες και πολλά άλλα.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με αρκετές προσαρμοσμένες επιλογές.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία αντικειμένου της κλάσης PdfOptions.
var pdfOptions = new PdfOptions
{
    // Ορισμός ποιότητας για εικόνες JPG.
    JpegQuality = 90,

    // Ορισμός DPI για εικόνες.
    SufficientResolution = 300,

    // Ορισμός συμπεριφοράς για metafiles.
    SaveMetafilesAsPng = true,

    // Ορισμός επιπέδου συμπίεσης κειμένου για το κειμενικό περιεχόμενο.
    TextCompression = PdfTextCompression.Flate,

    // Καθορισμός λειτουργίας συμμόρφωσης PDF.
    Compliance = PdfCompliance.Pdf15
};

// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// Αποθήκευση της παρουσίασης ως PDF έγγραφο.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε την ιδιότητα [ShowHiddenSlides](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/showhiddenslides/) από την κλάση [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με τις κρυφές διαφάνειες να περιλαμβάνονται:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Δημιουργία αντικειμένου της κλάσης PdfOptions.
var pdfOptions = new PdfOptions();

// Προσθήκη κρυφών διαφανειών.
pdfOptions.ShowHiddenSlides = true;

// Αποθήκευση της παρουσίασης ως PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού**

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με προστασία κωδικού πρόσβασης χρησιμοποιώντας τις παραμέτρους προστασίας από την κλάση [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/):

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Δημιουργία αντικειμένου της κλάσης PdfOptions.
var pdfOptions = new PdfOptions();

// Ορισμός κωδικού πρόσβασης PDF και δικαιωμάτων πρόσβασης.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Αποθήκευση της παρουσίασης ως PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Ανίχνευση Αντικατάστασης Γραμματοσειρών**

Το Aspose.Slides παρέχει την ιδιότητα [WarningCallback](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveoptions/warningcallback/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/), επιτρέποντάς σας να ανιχνεύσετε αντικαταστάσεις γραμματοσειρών κατά τη διαδικασία μετατροπής παρουσίασης‑σε‑PDF.

Αυτός ο κώδικας C# δείχνει πώς να ανιχνεύσετε αντικαταστάσεις γραμματοσειρών:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file. 
    using var presentation = new Presentation("sample.pptx");

    // Ορισμός της λειτουργίας επανάκλησης προειδοποίησης στις επιλογές PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Αποθήκευση της παρουσίασης ως PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Υλοποίηση της λειτουργίας επανάκλησης προειδοποίησης.
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

{{%  alert color="info"  %}} 

Για περισσότερες πληροφορίες σχετικά με την λήψη callbacks για αντικατάσταση γραμματοσειρών κατά τη διαδικασία απόδοσης, δείτε το άρθρο [Getting Warning Callbacks for Fonts Substitution](/slides/el/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Για περισσότερες πληροφορίες σχετικά με την αντικατάσταση γραμματοσειρών, δείτε το άρθρο [Font Substitution](/slides/el/net/font-substitution/).

{{% /alert %}} 

## **Μετατροπή Επιλεγμένων Διαφανειών από PowerPoint σε PDF**

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μόνο συγκεκριμένες διαφάνειες από μια παρουσίαση PowerPoint σε PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// Ορισμός πίνακα αριθμών διαφανειών.
int[] slides = { 1, 3 };

// Αποθήκευση της παρουσίασης ως PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με καθορισμένο μέγεθος διαφάνειας:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);

// Save the resized presentation as a PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Μετατροπή PowerPoint σε PDF στην Προβολή Σημειώσεων Διαφάνειας**

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF που περιλαμβάνει σημειώσεις:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Φόρτωση παρουσίασης PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Ρύθμιση των επιλογών PDF με διάταξη σημειώσεων.
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

Αυτός ο κώδικας C# δείχνει μια διαδικασία μετατροπής PowerPoint‑σε‑PDF που παράγει πολλαπλά PDF βάσει διαφορετικών προτύπων συμμόρφωσης:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Το Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντάς σας να μετατρέψετε αρχεία PDF σε δημοφιλείς μορφές αρχείων. Μπορείτε να εκτελέσετε μετατροπές [PDF σε HTML](https://products.aspose.com/slides/el/net/conversion/pdf-to-html/), [PDF σε εικόνα](https://products.aspose.com/slides/el/net/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/el/net/conversion/pdf-to-jpg/) και [PDF σε PNG](https://products.aspose.com/slides/el/net/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές—[PDF σε SVG](https://products.aspose.com/slides/el/net/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/el/net/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/el/net/conversion/pdf-to-xml/)—υποστηρίζονται επίσης.

{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει πολύπλογα γραφικά όπως SmartArt, διαγράμματα και τύπους ως μια ενιαία φιγούρα. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως τεχνητά αντικείμενα· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρη τη φιγούρα.

## **Συχνές Ερωτήσεις**

### Μπορώ να μετατρέψω πολλαπλά αρχεία PowerPoint σε PDF μαζικά;

Ναι, το Aspose.Slides υποστηρίζει μαζική μετατροπή πολλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επαναλάβετε τα αρχεία σας και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματιστικά.

### Είναι δυνατόν να προστατεύσω με κωδικό πρόσβασης το PDF που δημιουργήθηκε;

Απολύτως. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/) για να ορίσετε έναν κωδικό πρόσβασης και να καθορίσετε δικαιώματα πρόσβασης κατά τη διαδικασία μετατροπής.

### Πώς συμπεριλαμβάνω κρυφές διαφάνειες στο PDF;

Ορίστε την ιδιότητα `ShowHiddenSlides` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/) σε `true` για να συμπεριλάβετε τις κρυφές διαφάνειες στο παραγόμενο PDF.

### Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;

Ναι, μπορείτε να ελέγχετε την ποιότητα εικόνας ορίζοντας ιδιότητες όπως `JpegQuality` και `SufficientResolution` στην κλάση [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/) ώστε να εξασφαλίζετε εικόνες υψηλής ποιότητας στο PDF σας.

### Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε PDF που συμμορφώνονται με διάφορα πρότυπα, όπως PDF/A1a, PDF/A1b και PDF/UA, εξασφαλίζοντας ότι τα έγγραφά σας πληρούν τις απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides for .NET](/slides/el/net/)
- [Αναφορά API Aspose.Slides for .NET](https://reference.aspose.com/slides/el/net/)
- [Δωρεάν Online Μετατροπείς Aspose](https://products.aspose.app/slides/el/conversion)