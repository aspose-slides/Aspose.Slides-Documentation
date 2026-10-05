---
title: Μετατροπή PPT και PPTX σε PDF στο .NET [Συμπεριλαμβανομένων Προηγμένων Χαρακτηριστικών]
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
- συνημμένο
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε PDF υψηλής ποιότητας, αναζητήσιμα στο .NET χρησιμοποιώντας το Aspose.Slides, με γρήγορα παραδείγματα κώδικα C# και προχωρημένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή των παρουσιάσεων PowerPoint (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF με C# προσφέρει πολλά πλεονεκτήματα, συμπεριλαμβανομένης της συμβατότητας σε διαφορετικές συσκευές και της διατήρησης της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για τον έλεγχο της ποιότητας των εικόνων, να συμπεριλάβετε κρυφές διαφάνειες, να προστατεύσετε με κωδικό πρόσβασης τα αρχεία PDF, να ανιχνεύσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα τελικά έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις στις παρακάτω μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) και στη συνέχεια αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Η κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) εκθέτει τη μέθοδο [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) που χρησιμοποιείται συνήθως για τη μετατροπή μιας παρουσίασης σε PDF.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides for .NET εισάγει τις πληροφορίες API του και τον αριθμό έκδοσης σε έγγραφα εξόδου. Για παράδειγμα, κατά τη μετατροπή μιας παρουσίασης σε PDF, το Aspose.Slides γεμίζει το πεδίο Application με "*Aspose.Slides*" και το πεδίο PDF Producer με τιμή στη μορφή "*Aspose.Slides v XX.XX*". **Σημείωση** ότι δεν μπορείτε να υποδείξετε στο Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα έγγραφα εξόδου.
{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα προκύπτοντα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και τα χαρακτηριστικά αποδίδονται ακριβώς στη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Πλαίσιο κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφου
* Υπερσυνδέσμους
* Κεφαλίδες και υποσέλιδα
* Κουκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint σε PDF χρησιμοποιεί προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στα μέγιστα επίπεδα ποιότητας.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση και αποθηκεύει όλες τις ορατές διαφάνειες σε PDF χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις εξαγωγής.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Η Aspose προσφέρει έναν δωρεάν διαδικτυακό [**Μετατροπέας PowerPoint σε PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) που επιδεικνύει τη διαδικασία μετατροπής παρουσίασης σε PDF. Μπορείτε να εκτελέσετε ένα δοκιμαστικό με αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές—ιδιότητες της κλάσης [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—που σας επιτρέπουν να προσαρμόσετε το παραγόμενο PDF, να κλειδώσετε το PDF με κωδικό πρόσβασης ή να καθορίσετε πώς θα προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Με τη χρήση προσαρμοσμένων επιλογών μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για ράστερ εικόνων, να καθορίσετε πώς θα διαχειρίζονται τα μετααρχεία, να ορίσετε επίπεδο συμπίεσης για κείμενο, να ρυθμίσετε DPI για εικόνες και πολλά άλλα.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF 1.5 με ποιότητα JPEG 90, ανάλυση εικόνας 300 DPI, μετααρχεία αποθηκευμένα ως PNG και συμπίεση κειμένου Flate.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Διατήρηση Ενσωματωμένων Αρχείων OLE ως Συνημμένα PDF**

Εάν μια παρουσίαση περιέχει ενσωματωμένο βιβλίο εργασίας Excel, ίσως θέλετε οι παραλήπτες του PDF να έχουν πρόσβαση στα δεδομένα του βιβλίου καθώς και να δουν τις διαφάνειες. Ορίστε την ιδιότητα [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) σε `true` για να διατηρήσετε τα ενσωματωμένα αρχεία OLE ως συνημμένα στο παραγόμενο PDF.

Η προεπιλεγμένη τιμή είναι `false`: η εικόνα προεπισκόπησης ή το εικονίδιο του αντικειμένου OLE αποδίδεται στη σελίδα PDF, αλλά το ενσωματωμένο αρχείο δεν συμπεριλαμβάνεται ως συνημμένο. Ορίζοντας την επιλογή σε `true` προσθέτει επιπλέον τα δεδομένα του αρχείου. Η προεπισκόπηση παραμένει οπτική αναπαράσταση· το συνημμένο επιτρέπει στους παραλήπτες να ανοίξουν ή να αποθηκεύσουν το ενσωματωμένο αρχείο ξεχωριστά. Το αντικείμενο OLE δεν μετατρέπεται σε διαδραστικό φύλλο Excel στη σελίδα PDF.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση που ήδη περιέχει ενσωματωμένο βιβλίο εργασίας Excel και το εξάγει σε PDF με το βιβλίο εργασίας ως συνημμένο.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Για να ελέγξετε το αποτέλεσμα:

1. Ανοίξτε το εξαγόμενο PDF σε πρόγραμμα προβολής που υποστηρίζει συνημμένα, όπως το Adobe Acrobat Reader.
2. Ανοίξτε το τμήμα **Attachments** του προβολέα και εντοπίστε το ενσωματωμένο βιβλίο εργασίας.
3. Αποθηκεύστε το συνημμένο και ανοίξτε το στο Excel για να ελέγξετε τα δεδομένα του, ή ανοίξτε το απευθείας εάν το πρόγραμμα προβολής το επιτρέπει. Η προεπισκόπηση στη σελίδα PDF είναι ξεχωριστή από το συνημμένο.

{{% alert color="info" title="Note" %}}
Τα πρότυπα PDF/A επιβάλλουν περιορισμούς στα συνημμένα: το PDF/A-1 απαγορεύει ενσωματωμένα αρχεία, το PDF/A-2 επιτρέπει μόνο συνημμένα PDF/A, και το PDF/A-3 επιτρέπει άλλους τύπους αρχείων, συμπεριλαμβανομένων βιβλίων εργασίας Excel. Αυτές είναι απαιτήσεις των προτύπων, όχι περιορισμοί συγκεκριμένοι για το Aspose.Slides. Αυτό το παράδειγμα χρησιμοποιεί την προεπιλεγμένη ρύθμιση συμμόρφωσης PDF και δεν παρουσιάζει εξαγωγή PDF/A.
{{% /alert %}}

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε την ιδιότητα [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) από την κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF, συμπεριλαμβανομένων τυχόν κρυφών διαφανειών.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF που απαιτεί τον κωδικό `password` για άνοιγμα. Οι άδειες πρόσβασης επιτρέπουν εκτύπωση, συμπεριλαμβανομένης εκτύπωσης υψηλής ποιότητας.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Ανίχνευση Αντικαταστάσεων Γραμματοσειρών**

Το Aspose.Slides παρέχει την ιδιότητα [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), επιτρέποντάς σας να ανιχνεύσετε αντικαταστάσεις γραμματοσειρών κατά τη διαδικασία μετατροπής παρουσίασης σε PDF.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF και εκτυπώνει προειδοποιήσεις αντικατάστασης γραμματοσειρών στην κονσόλα. Μια προειδοποίηση εκτυπώνεται μόνο όταν μια μη διαθέσιμη γραμματοσειρά αντικαθίσταται κατά την εξαγωγή.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
Για περισσότερες πληροφορίες σχετικά με την αντικατάσταση γραμματοσειρών, δείτε το άρθρο [Font Substitution](/slides/el/net/font-substitution/).
{{% /alert %}} 

## **Μετατροπή Επιλεγμένων Διαφανειών από PowerPoint σε PDF**

Το παρακάτω παράδειγμα εξάγει τις διαφάνειες 1 και 3 από μια παρουσίαση σε PDF. Οι αριθμοί διαφανειών σε αυτή τη συλλογή ξεκινούν από το 1, και η εισαγόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον τρεις διαφάνειες.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Το παρακάτω παράδειγμα αντιγράφει την πρώτη διαφάνεια από μια παρουσίαση σε μια νέα παρουσίαση με μέγεθος διαφάνειας 612 × 792 points (8,5 × 11 ίντσες). Κλιμακώνει το περιεχόμενο της διαφάνειας ώστε να ταιριάζει και εξάγει τη μοναδική διαφάνεια σε PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Μετατροπή PowerPoint σε PDF σε Προβολή Σημειώσεων Διαφάνειας**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF, τοποθετώντας τις σημειώσεις ομιλητή κάθε διαφάνειας κάτω από τη διαφάνεια. Χρησιμοποιήστε μια παρουσίαση που περιέχει σημειώσεις ομιλητή για να δείτε το αποτέλεσμα.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Πρότυπα Προσβασιμότητας και Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b**, και **PDF/UA**.

Αυτός ο κώδικας C# επιδεικνύει μια διαδικασία μετατροπής PowerPoint σε PDF που δημιουργεί πολλά PDF με βάση διαφορετικά πρότυπα συμμόρφωσης:

```csharp
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

{{% alert color="info" title="Note" %}}
Το Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντάς σας να μετατρέψετε αρχεία PDF σε δημοφιλείς μορφές αρχείων. Μπορείτε να εκτελέσετε μετατροπές [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), και [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές—[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), και [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—επίσης υποστηρίζονται.
{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει πολύπλογα γραφικά όπως SmartArt, διαγράμματα και φόρμουλες ως μία ενιαία εικόνα. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να επισημανθούν ως τεχνούργημα· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρη τη εικόνα.

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλαπλά αρχεία PowerPoint σε PDF μαζικά;**

Ναι, το Aspose.Slides υποστηρίζει μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επαναλάβετε τα αρχεία σας και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματισμένα.

**Είναι δυνατόν να προστατεύσουμε με κωδικό πρόσβασης το μετατρεπόμενο PDF;**

Ναι. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) για να ορίσετε κωδικό πρόσβασης και να καθορίσετε άδειες πρόσβασης κατά τη διαδικασία μετατροπής.

**Πώς μπορώ να συμπεριλάβω κρυφές διαφάνειες στο PDF;**

Ορίστε την ιδιότητα [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) σε `true` για να συμπεριληφθούν οι κρυφές διαφάνειες στο παραγόμενο PDF.

**Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα των εικόνων ορίζοντας ιδιότητες όπως [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) και [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) ώστε να εξασφαλίσετε υψηλής ποιότητας εικόνες στο PDF σας.

**Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;**

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε PDF που συμμορφώνονται με διάφορα πρότυπα, συμπεριλαμβανομένων PDF/A1a, PDF/A1b και PDF/UA, διασφαλίζοντας ότι τα έγγραφά σας πληρούν απαιτήσεις προσβασιμότητας και αρχειοθεσίας.

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides για .NET](/slides/el/net/)
- [Αναφορά API Aspose.Slides για .NET](https://reference.aspose.com/slides/net/)
- [Δωρεάν διαδικτυακοί μετατροπείς Aspose](https://products.aspose.app/slides/conversion)