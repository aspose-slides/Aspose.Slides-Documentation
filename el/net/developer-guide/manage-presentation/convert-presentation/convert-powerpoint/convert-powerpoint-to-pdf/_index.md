---
title: Μετατροπή PPT και PPTX σε PDF σε .NET [Περιλαμβάνονται Προηγμένα Χαρακτηριστικά]
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
description: "Μετατρέψτε PowerPoint PPT/PPTX σε PDFs υψηλής ποιότητας, με δυνατότητα αναζήτησης, σε .NET χρησιμοποιώντας Aspose.Slides, με γρήγορα παραδείγματα κώδικα C# και προηγμένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF σε C# προσφέρει πολλά πλεονεκτήματα, συμπεριλαμβανομένης της συμβατότητας μεταξύ διαφόρων συσκευών και της διατήρησης της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για τον έλεγχο της ποιότητας των εικόνων, να συμπεριλάβετε κρυφές διαφάνειες, να προστατέψετε το PDF με κωδικό, να εντοπίσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις στις παρακάτω μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) και στη συνέχεια αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Η κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) εκθέτει τη μέθοδο [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), η οποία συνήθως χρησιμοποιείται για τη μετατροπή μιας παρουσίασης σε PDF.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides για .NET εισάγει τις πληροφορίες του API του και τον αριθμό έκδοσης στα έγγραφα εξόδου. Για παράδειγμα, όταν μετατρέπεται μια παρουσίαση σε PDF, το Aspose.Slides γεμίζει το πεδίο Application με "*Aspose.Slides*" και το πεδίο PDF Producer με μια τιμή στη μορφή "*Aspose.Slides v XX.XX*". **Σημείωση** ότι δεν μπορείτε να υποδείξετε στο Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα έγγραφα εξόδου.
{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, εξασφαλίζοντας ότι τα παραγόμενα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και τα χαρακτηριστικά αποδίδονται ακριβώς στη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφων
* Υπερσυνδέσμους
* Κεφαλίδες και υποσέλιδα
* Κουκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint σε PDF χρησιμοποιεί τις προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει τη δοθείσα παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στο μέγιστο επίπεδο ποιότητας.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση και αποθηκεύει όλες τις ορατές διαφάνειες σε PDF χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις εξαγωγής.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Το Aspose προσφέρει έναν δωρεάν διαδικτυακό [**Μετατροπέας PowerPoint σε PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) που παρουσιάζει τη διαδικασία μετατροπής παρουσίασης σε PDF. Μπορείτε να εκτελέσετε μια δοκιμή με αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές—ιδιότητες στην κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—που σας επιτρέπουν να προσαρμόσετε το παραγόμενο PDF, να το κλειδώσετε με κωδικό ή να καθορίσετε πώς θα προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για εικόνες raster, να καθορίσετε πώς θα διαχειρίζονται τα metafiles, να ορίσετε επίπεδο συμπίεσης για το κείμενο, να ρυθμίσετε DPI για τις εικόνες και άλλα.

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

### **Αυτόματη Επιλογή Συμπίεσης Εικόνας**

Όταν μια παρουσίαση περιέχει πολλές φωτογραφίες ή στιγμιότυπα οθόνης, η μείωση του μεγέθους του εξαγόμενου PDF μπορεί να το κάνει πιο εύκολο για αποστολή μέσω email ή λήψη. Ορίστε το [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) σε `true` για να επιλέγεται αυτόματα ο πιο κατάλληλος αλγόριθμος συμπίεσης για κάθε εικόνα κατά την εξαγωγή PDF.

Το παρακάτω παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση, ενεργοποιεί την αυτόματη επιλογή συμπίεσης εικόνας και την αποθηκεύει ως έγγραφο PDF. Όλες οι άλλες ρυθμίσεις εξαγωγής PDF διατηρούν τις προεπιλεγμένες τιμές τους.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

Αυτή η επιλογή επιλέγει αλγόριθμο συμπίεσης για κάθε εικόνα. Η μείωση του [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) μειώνει την ποιότητα των JPEG εικόνων, ενώ η μείωση του [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) επιτρέπει την υποδειγματοληψία των εικόνων σε χαμηλότερη ανάλυση, κάτι που μπορεί να μειώσει τις λεπτομέρειες. Η ενεργοποίηση της αυτόματης επιλογής συμπίεσης δεν μειώνει από μόνη της καμία από αυτές τις ρυθμίσεις.

Η επιλογή αλγορίθμων συμπίεσης εικόνας απαιτεί επιπλέον χρόνο επεξεργασίας και μνήμη. Η μείωση του μεγέθους εξαρτάται από τις εικόνες της παρουσίασης και τις ρυθμίσεις εξαγωγής· δεν εγγυάται σταθερή μείωση για κάθε παρουσίαση.

### **Διατήρηση Ενσωματωμένων Αρχείων OLE ως Συνημμένα PDF**

Εάν μια παρουσίαση περιέχει ενσωματωμένο βιβλίο εργασίας Excel, μπορεί να θέλετε οι παραλήπτες του PDF να έχουν πρόσβαση στα δεδομένα του βιβλίου εργασίας καθώς και να βλέπουν τις διαφάνειες. Ορίστε το [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) σε `true` για να διατηρηθούν τα ενσωματωμένα αρχεία OLE ως συνημμένα στο παραγόμενο PDF.

Η προεπιλεγμένη τιμή είναι `false`: η εικόνα προεπισκόπησης ή το εικονίδιο του αντικειμένου OLE αποδίδονται στη σελίδα PDF, αλλά το ενσωματωμένο αρχείο δεν συμπεριλαμβάνεται ως συνημμένο. Ορισμός της επιλογής σε `true` προσθέτει επιπλέον τα δεδομένα του αρχείου. Η προεπισκόπηση παραμένει οπτική αναπαράσταση· το συνημμένο επιτρέπει στους παραλήπτες να ανοίξουν ή να αποθηκεύσουν το ενσωματωμένο αρχείο ξεχωριστά. Το αντικείμενο OLE δεν γίνεται διαδραστικό φύλλο εργασίας Excel στη σελίδα PDF.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση που ήδη περιέχει ενσωματωμένο βιβλίο εργασίας Excel και το εξάγει σε PDF με το βιβλίο εργασίας ως συνημμένο.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Για να ελέγξετε το αποτέλεσμα:

1. Ανοίξτε το εξαγόμενο PDF σε προβολή που υποστηρίζει συνημμένα αρχεία, όπως το Adobe Acrobat Reader.
2. Ανοίξτε το πάνελ **Attachments** του προβολέα και εντοπίστε το ενσωματωμένο βιβλίο εργασίας.
3. Αποθηκεύστε το συνημμένο και ανοίξτε το στο Excel για να ελέγξετε τα δεδομένα του, ή ανοίξτε το απευθείας εάν το πρόγραμμα προβολής το επιτρέπει. Η προεπισκόπηση στη σελίδα PDF είναι ξεχωριστή από το συνημμένο.

{{% alert color="info" title="Note" %}}
Τα πρότυπα PDF/A επιβάλλουν περιορισμούς στα συνημμένα: το PDF/A-1 απαγορεύει ενσωματωμένα αρχεία, το PDF/A-2 επιτρέπει μόνο συνημμένα PDF/A, και το PDF/A-3 επιτρέπει άλλους τύπους αρχείων, συμπεριλαμβανομένων των βιβλίων εργασίας Excel. Αυτές είναι απαιτήσεις των προτύπων, όχι περιορισμοί ειδικά για το Aspose.Slides. Αυτό το παράδειγμα χρησιμοποιεί την προεπιλεγμένη ρύθμιση συμμόρφωσης PDF και δεν δείχνει εξαγωγή PDF/A.
{{% /alert %}}

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε την ιδιότητα [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) από την κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF, συμπεριλαμβάνοντας τυχόν κρυφές διαφάνειες.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF που απαιτεί τον κωδικό `password` για άνοιγμα. Τα δικαιώματα πρόσβασης επιτρέπουν εκτύπωση, συμπεριλαμβανομένης της εκτύπωσης υψηλής ποιότητας.

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

Το Aspose.Slides παρέχει την ιδιότητα [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), επιτρέποντάς σας να ανιχνεύετε αντικαταστάσεις γραμματοσειρών κατά τη διαδικασία μετατροπής παρουσίασης σε PDF.

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
Για περισσότερες πληροφορίες σχετικά με την αντικατάσταση γραμματοσειρών, δείτε το άρθρο [Αντικατάσταση Γραμματοσειρών](/slides/el/net/font-substitution/).
{{% /alert %}} 

### **Διαχείριση Γραμματοσειρών Χωρίς Αποκλειστικό Γραμματοσειρά Bold**

Μια παρουσίαση μπορεί να εφαρμόσει τη μορφοποίηση bold σε κείμενο ακόμη και όταν η γραμματοσειρά της δεν διαθέτει αποκλειστική γραμματοσειρά bold. Το κείμενο μπορεί να εμφανίζεται still bold μέσω συνθετικού bold, το οποίο παχύνει τε χνητά τα κανονικά glyphs. Όταν αυτό το κείμενο φαίνεται πολύ βαρύ ή διαφορετικό από την επιθυμητή εμφάνιση στο PDF, δοκιμάστε να ορίσετε το [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) σε `true`. Αυτή η επιλογή αποδίδει το επηρεασμένο κείμενο ως bitmap κατά την εξαγωγή PDF και μπορεί να βελτιώσει την εμφάνισή του για ορισμένες γραμματοσειρές. Η προεπιλεγμένη τιμή είναι `false`.

Η δείγμα παρουσίαση περιέχει δύο πλαίσια κειμένου: ένα με κανονικό κείμενο και ένα με μορφοποίηση bold που εφαρμόζεται στην ίδια γραμματοσειρά, η οποία δεν έχει αποκλειστική γραμματοσειρά bold. Το παρακάτω παράδειγμα φορτώνει την παρουσίαση, ενεργοποιεί την rasterization των μη υποστηριζόμενων στυλ γραμματοσειρών, και την εξάγει σε PDF:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

Οι παρακάτω προεπισκοπήσεις δείχνουν την έξοδο με τη δυνατότητα απενεργοποιημένη και ενεργοποιημένη. Σε αυτό το παράδειγμα, το κείμενο bold έχει πιο έντονα στίγματα με την επιλογή απενεργοποιημένη. Με την επιλογή ενεργοποιημένη, τα στίγματα γίνονται πιο ελαφριά· το κανονικό κείμενο παραμένει αμετάβλητο. Συγκρίνετε τα αποτελέσματα πριν επιλέξετε τη ρύθμιση για την παρουσίασή σας.

| Επιλογή απενεργοποιημένη (`false`, η προεπιλογή) | Επιλογή ενεργοποιημένη (`true`) |
|---|---|
| ![PDF με rasterization μη υποστηριζόμενου στυλ γραμματοσειράς απενεργοποιημένο](unsupported-bold-disabled.png) | ![PDF με rasterization μη υποστηριζόμενου στυλ γραμματοσειράς ενεργοποιημένο](unsupported-bold-enabled.png) |

Σε αυτό το παράδειγμα, η ενεργοποίηση της επιλογής μετατρέπει μόνο το κείμενο bold σε bitmap: δεν μπορεί να επιλεγεί, αντιγραφεί ή αναζητηθεί ως κείμενο χωρίς OCR, και οι άκρες του φαίνονται πιο απαλοί σε ζουμ 800%. Το κανονικό κείμενο παραμένει αναζητήσιμο. Με την επιλογή απενεργοποιημένη, και οι δύο συμβολοσειρές παραμένουν κείμενο.

Αυτή η επιλογή rasterizes κείμενο μορφοποιημένο ως bold όταν η γραμματοσειρά του δεν έχει αποκλειστική γραμματοσειρά bold. [Αντικατάσταση Γραμματοσειρών](/slides/el/net/font-substitution/) αντίθετα επιλέγει άλλη γραμματοσειρά όταν η αρχική δεν είναι διαθέσιμη.

## **Μετατροπή Επιλεγμένων Διαφανειών από PowerPoint σε PDF**

Το παρακάτω παράδειγμα εξάγει τις διαφάνειες 1 και 3 από μια παρουσίαση σε PDF. Οι αριθμοί διαφανειών σε αυτόν τον πίνακα ξεκινούν από το 1, και η είσοδος παρουσίασης πρέπει να περιέχει τουλάχιστον τρεις διαφάνειες.

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

## **Πρόσβαση και Πρότυπα Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b**, και **PDF/UA**.

Αυτός ο κώδικας C# επιδεικνύει μια διαδικασία μετατροπής PowerPoint σε PDF που δημιουργεί πολλαπλά PDF βάσει διαφορετικών προτύπων συμμόρφωσης:

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
Το Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντας να μετατρέπετε αρχεία PDF σε δημοφιλείς μορφές αρχείων. Μπορείτε να εκτελέσετε [PDF σε HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF σε εικόνα](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) μετατροπές. Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές—[PDF σε SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—επίσης υποστηρίζονται.
{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει σύνθετα γραφικά όπως SmartArt, διαγράμματα και τύπους ως μία ενιαία εικόνα. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως artefacts· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρη την εικόνα.

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλαπλά αρχεία PowerPoint σε PDF μαζικά;**

Ναι, το Aspose.Slides υποστηρίζει μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επαναλάβετε τα αρχεία σας και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματιστικά.

**Μπορεί να προστατευτεί με κωδικό το PDF μετά τη μετατροπή;**

Ναι. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) για να ορίσετε κωδικό και να καθορίσετε δικαιώματα πρόσβασης κατά τη διαδικασία μετατροπής.

**Πώς να συμπεριλάβω κρυφές διαφάνειες στο PDF;**

Ορίστε την ιδιότητα [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) σε `true` για να συμπεριλάβετε τις κρυφές διαφάνειες στο παραγόμενο PDF.

**Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα εικόνας ορίζοντας ιδιότητες όπως [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) και [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) για να εξασφαλίσετε εικόνες υψηλής ποιότητας στο PDF σας.

**Υποστηρίζει το Aspose.Slides τα πρότυπα συμμόρφωσης PDF/A;**

Ναί, το Aspose.Slides σας επιτρέπει να εξάγετε PDF που συμμορφώνονται με διάφορα πρότυπα, συμπεριλαμβανομένων των PDF/A1a, PDF/A1b και PDF/UA, διασφαλίζοντας ότι τα έγγραφά σας πληρούν τις απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides για .NET](/slides/el/net/)
- [API Αναφορά Aspose.Slides για .NET](https://reference.aspose.com/slides/net/)
- [Δωρεάν Online Μετατροπείς Aspose](https://products.aspose.app/slides/conversion)