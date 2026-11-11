---
title: Μετατροπή PPT και PPTX σε PDF σε .NET [Συμπερίληψη Προηγμένων Χαρακτηριστικών]
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
description: "Μετατρέψτε PowerPoint PPT/PPTX σε υψηλής ποιότητας, αναζητήσιμα PDF σε .NET χρησιμοποιώντας Aspose.Slides, με γρήγορα παραδείγματα κώδικα C# και προηγμένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF σε C# προσφέρει πολλά πλεονεκτήματα, συμπεριλαμβανομένης της συμβατότητας με διαφορετικές συσκευές και της διατήρησης της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για τον έλεγχο της ποιότητας εικόνας, να συμπεριλάβετε κρυφές διαφάνειες, να προστατέψετε με κωδικό πρόσβασης τα αρχεία PDF, να εντοπίσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Χρησιμοποιώντας Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις στις ακόλουθες μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στη κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) και στη συνέχεια αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Η κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) εκθέτει τη μέθοδο [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) που συνήθως χρησιμοποιείται για τη μετατροπή μιας παρουσίασης σε PDF.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides για .NET εισάγει τις πληροφορίες του API του και τον αριθμό έκδοσης στα έγγραφα εξόδου. Για παράδειγμα, όταν μετατρέπεται μια παρουσίαση σε PDF, το Aspose.Slides γεμίζει το πεδίο Application με "*Aspose.Slides*" και το πεδίο PDF Producer με μια τιμή στη μορφή "*Aspose.Slides v XX.XX*". **Σημείωση** ότι δεν μπορείτε να ζητήσετε από το Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα έγγραφα εξόδου.
{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα προκύπτοντα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και τα χαρακτηριστικά αποδίδονται με ακρίβεια κατά τη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφου
* Υπερσυνδέσμους
* Κεφαλίδες και υποσέλιδα
* Κουκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint‑σε‑PDF χρησιμοποιεί τις προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στα μέγιστα επίπεδα ποιότητας.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση και σώζει όλες τις ορατές διαφάνειες σε PDF χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις εξαγωγής.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Η Aspose προσφέρει έναν δωρεάν διαδικτυακό [**μετατροπέα PowerPoint σε PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) που δείχνει τη διαδικασία μετατροπής παρουσίασης σε PDF. Μπορείτε να εκτελέσετε μια δοκιμή με αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές — ιδιότητες στην κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) — που σας επιτρέπουν να προσαρμόσετε το παραγόμενο PDF, να κλειδώσετε το PDF με κωδικό πρόσβασης ή να καθορίσετε πώς πρέπει να προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για εικόνες raster, να καθορίσετε πώς πρέπει να διαχειρίζονται τα metafiles, να ορίσετε επίπεδο συμπίεσης για κείμενο, να ρυθμίσετε DPI για εικόνες και άλλα.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF 1.5 με ποιότητα JPEG ορισμένη στο 90, ανάλυση εικόνας 300 DPI, metafiles αποθηκευμένα ως PNG, και συμπίεση κειμένου Flate.

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

> **Σημείωση:** Μπορείτε να βελτιώσετε την ποιότητα απόδοσης των σκιών κειμένου και των εφέ ανάκλασης κατά τη μετατροπή σε PDF θέτοντας το `PdfOptions.SufficientResolution` σε υψηλότερη τιμή (π.χ., `300`). Αυτό παράγει PDF που ταιριάζει πιο κοντά με την εμφάνιση στο Microsoft PowerPoint.

### **Αυτόματη Επιλογή Συμπίεσης Εικόνας**

Όταν μια παρουσίαση περιέχει πολλές φωτογραφίες ή στιγμιότυπα οθόνης, η μείωση του μεγέθους του εξαγόμενου PDF μπορεί να διευκολύνει την αποστολή μέσω ηλεκτρονικού ταχυδρομείου ή τη λήψη. Ορίστε το [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) σε `true` ώστε να επιλέγεται αυτόματα ο πιο κατάλληλος αλγόριθμος συμπίεσης για κάθε εικόνα κατά την εξαγωγή PDF.

Το παρακάτω παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση, ενεργοποιεί την αυτόματη επιλογή συμπίεσης εικόνων και την αποθηκεύει ως έγγραφο PDF. Όλες οι υπόλοιπες ρυθμίσεις εξαγωγής PDF διατηρούν τις προεπιλεγμένες τιμές.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

Αυτή η επιλογή επιλέγει έναν αλγόριθμο συμπίεσης για κάθε εικόνα. Η μείωση του [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) μειώνει την ποιότητα εικόνας JPEG, ενώ η μείωση του [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) επιτρέπει τη μείωση της ανάλυσης των εικόνων, κάτι που μπορεί να μειώσει τις λεπτομέρειες. Η ενεργοποίηση της αυτόματης επιλογής συμπίεσης δεν μειώνει από μόνη της καμία από αυτές τις ρυθμίσεις.

Η επιλογή αλγορίθμων συμπίεσης εικόνας απαιτεί πρόσθετο χρόνο επεξεργασίας και μνήμη. Η μείωση του μεγέθους εξαρτάται από τις εικόνες της παρουσίασης και τις ρυθμίσεις εξαγωγής· δεν υπάρχει εγγυημένη σταθερή μείωση για κάθε παρουσίαση.

### **Διατήρηση Ενσωματωμένων Αρχείων OLE ως Συνημμένα PDF**

Εάν μια παρουσίαση περιέχει ενσωματωμένο βιβλίο εργασίας Excel, μπορεί να θέλετε οι παραλήπτες του PDF να έχουν πρόσβαση στα δεδομένα του βιβλίου εργασίας καθώς και να βλέπουν τις διαφάνειες. Ορίστε το [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) σε `true` για να διατηρηθούν τα ενσωματωμένα αρχεία OLE ως συνημμένα στο προκύπτω PDF.

Η προεπιλεγμένη τιμή είναι `false`: η εικόνα προεπισκόπησης ή το εικονίδιο του αντικειμένου OLE αποδίδονται στη σελίδα PDF, αλλά το ενσωματωμένο αρχείο δεν συμπεριλαμβάνεται ως συνημμένο. Ορίζοντας την επιλογή σε `true` προστίθενται επίσης τα δεδομένα του αρχείου. Η προεπισκόπηση παραμένει μια οπτική αναπαράσταση· το συνημμένο επιτρέπει στους παραλήπτες να ανοίξουν ή να αποθηκεύσουν το ενσωματωμένο αρχείο ξεχωριστά. Το αντικείμενο OLE δεν μετατρέπεται σε διαδραστικό φύλλο Excel στη σελίδα PDF.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση που ήδη περιέχει ενσωματωμένο βιβλίο εργασίας Excel και το εξάγει σε PDF με το βιβλίο εργασίας συνημμένο.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Για να ελέγξετε το αποτέλεσμα:

1. Ανοίξτε το εξαγόμενο PDF σε έναν προβολέα που υποστηρίζει συνημμένα αρχείων, όπως το Adobe Acrobat Reader.
2. Ανοίξτε το πάνελ **Attachments** του προβολέα και εντοπίστε το ενσωματωμένο βιβλίο εργασίας.
3. Αποθηκεύστε το συνημμένο και ανοίξτε το στο Excel για να ελέγξετε τα δεδομένα του, ή ανοίξτε το άμεσα εφόσον ο προβολέας το επιτρέπει. Η προεπισκόπηση στη σελίδα PDF είναι ξεχωριστή από το συνημμένο.

{{% alert color="info" title="Note" %}}
Τα πρότυπα PDF/A επιβάλλουν περιορισμούς στα συνημμένα: το PDF/A‑1 απαγορεύει ενσωματωμένα αρχεία, το PDF/A‑2 επιτρέπει μόνο συνημμένα PDF/A, και το PDF/A‑3 επιτρέπει άλλους τύπους αρχείων, συμπεριλαμβανομένων βιβλιοθηκών Excel. Αυτές είναι απαιτήσεις των προτύπων, όχι περιορισμοί ειδικά για το Aspose.Slides. Αυτό το παράδειγμα χρησιμοποιεί την προεπιλεγμένη ρύθμιση συμμόρφωσης PDF και δεν παρουσιάζει εξαγωγή PDF/A.
{{% /alert %}}

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε την ιδιότητα [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) από την κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο προκύπτω PDF.

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

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF που απαιτεί τον κωδικό `password` για άνοιγμα. Τα δικαιώματα πρόσβασης επιτρέπουν εκτύπωση, συμπεριλαμβανομένης εκτύπωσης υψηλής ποιότητας.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Εντοπισμός Αντικαταστάσεων Γραμματοσειράς**

Το Aspose.Slides παρέχει την ιδιότητα [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), επιτρέποντάς σας να εντοπίζετε αντικαταστάσεις γραμματοσειράς κατά τη διαδικασία μετατροπής παρουσίασης σε PDF.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF και εκτυπώνει προειδοποιήσεις αντικατάστασης γραμματοσειρών στην κονσόλα. Μία προειδοποίηση εμφανίζεται μόνο όταν αντικαθίσταται μια μη διαθέσιμη γραμματοσειρά κατά την εξαγωγή.

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

### **Διαχείριση Γραμματοσειρών χωρίς Αφιερωμένο Βαθυγράμματο**

Μια παρουσίαση μπορεί να εφαρμόσει έντονη μορφοποίηση σε κείμενο ακόμα και αν η γραμματοσειρά της δεν διαθέτει αφιερωμένο βαθυγράμματο. Το κείμενο μπορεί να εμφανίζεται έντονο μέσω συνθετικού έντονου, που παχύνει τεχνητά τα κανονικά γλυφικά. Όταν αυτό το κείμενο φαίνεται πολύ βαρύ ή διαφορετικό από την επιδιωκόμενη εμφάνιση στο PDF, δοκιμάστε να ορίσετε το [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) σε `true`. Αυτή η επιλογή αποδίδει το επηρεασμένο κείμενο ως bitmap κατά την εξαγωγή PDF και μπορεί να βελτιώσει την εμφάνισή του για ορισμένες γραμματοσειρές. Η προεπιλεγμένη τιμή είναι `false`.

Η παράδειγμα παρουσίαση περιέχει δύο πλαίσια κειμένου: ένα με κανονικό κείμενο και ένα με έντονη μορφοποίηση στην ίδια γραμματοσειρά, η οποία δεν διαθέτει αφιερωμένο βαθυγράμματο. Το παρακάτω παράδειγμα φορτώνει την παρουσίαση, ενεργοποιεί τη rasterization των μη υποστηριζόμενων στυλ γραμματοσειράς και την εξάγει σε PDF:

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

Οι παρακάτω προεπισκοπήσεις δείχνουν την έξοδο με την επιλογή απενεργοποιημένη και ενεργοποιημένη. Σε αυτό το παράδειγμα, το έντονο κείμενο έχει πιο παχυρές γραμμές όταν η επιλογή είναι απενεργοποιημένη. Με την επιλογή ενεργοποιημένη, οι γραμμές του είναι πιο λεπτές· το κανονικό κείμενο παραμένει αμετάβλητο. Συγκρίνετε τα αποτελέσματα πριν επιλέξετε τη ρύθμιση για την παρουσίασή σας.

| Επιλογή απενεργοποιημένη (`false`, η προεπιλογή) | Επιλογή ενεργοποιημένη (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Σε αυτό το παράδειγμα, η ενεργοποίηση της επιλογής μετατρέπει μόνο το έντονο κείμενο σε bitmap: δεν μπορεί να επιλεχθεί, αντιγραφεί ή αναζητηθεί ως κείμενο χωρίς OCR, και οι άκρες του φαίνονται πιο απαλοί σε μεγέθυνση 800%. Το κανονικό κείμενο παραμένει αναζητήσιμο. Με την επιλογή απενεργοποιημένη, και οι δύο συμβολοσειρές παραμένουν κείμενο.

Αυτή η επιλογή rasterizes κείμενο μορφοποιημένο ως έντονο όταν η γραμματοσειρά του δεν διαθέτει αφιερωμένο βαθυγράμματο. Η [Font substitution](/slides/el/net/font-substitution/) αντίθετα επιλέγει άλλη γραμματοσειρά όταν η αρχική δεν είναι διαθέσιμη.

## **Μετατροπή Επιλεγμένων Διαφανειών από PowerPoint σε PDF**

Το παρακάτω παράδειγμα εξάγει τις διαφάνειες 1 και 3 από μια παρουσίαση σε PDF. Οι αριθμοί διαφανών σε αυτόν τον πίνακα είναι με βάση το 1, και η εισαγόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον τρεις διαφάνειες.

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

## **Μετατροπή PowerPoint σε PDF σε Προβολή Διαφάνειας Σημειώσεων**

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

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Κατευθυντήριες Οδηγίες Προσβασιμότητας Ιστού (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b**, και **PDF/UA**.

Αυτός ο κώδικας C# δείχνει μια διαδικασία μετατροπής PowerPoint‑σε‑PDF που παράγει πολλαπλά PDF με βάση διαφορετικά πρότυπα συμμόρφωσης:

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
Το Aspose.Slides υποστηρίζει λειτουργίες μετατροπής PDF, επιτρέποντάς σας να μετατρέψετε αρχεία PDF σε δημοφιλείς μορφές αρχείων. Μπορείτε να πραγματοποιήσετε μετατροπές [PDF σε HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF σε εικόνα](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές — [PDF σε SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — υποστηρίζονται επίσης.
{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει πολύπλοκα γραφικά όπως SmartArt, διαγράμματα και τύπους ως μία ενιαία μορφή. Τα μεμονωμένα στοιχεία μονοπατιού δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως τέλη· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρη τη μορφή.

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλά αρχεία PowerPoint σε PDF ταυτόχρονα;**

Ναι, το Aspose.Slides υποστηρίζει μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επαναλάβετε τα αρχεία σας και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματιστικά.

**Μπορεί να προστατευθεί με κωδικό πρόσβασης το μετατρεπόμενο PDF;**

Ναι. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) για να ορίσετε κωδικό πρόσβασης και να ορίσετε δικαιώματα πρόσβασης κατά τη διαδικασία μετατροπής.

**Πώς μπορώ να συμπεριλάβω κρυφές διαφάνειες στο PDF;**

Ορίστε την ιδιότητα [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) σε `true` για να συμπεριλάβετε τις κρυφές διαφάνειες στο προκύπτω PDF.

**Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα εικόνας ορίζοντας ιδιότητες όπως τα [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) και [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) ώστε να διασφαλίσετε εικόνες υψηλής ποιότητας στο PDF.

**Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;**

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε PDF που συμμορφώνονται με διάφορα πρότυπα, συμπεριλαμβανομένων PDF/A1a, PDF/A1b και PDF/UA, διασφαλίζοντας ότι τα έγγραφά σας πληρούν τις απαιτήσεις προσβασιμότητας και αρχειοθέτησης.

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides για .NET](/slides/el/net/)
- [Αναφορά API Aspose.Slides για .NET](https://reference.aspose.com/slides/net/)
- [Δωρεάν διαδικτυακοί μετατροπείς Aspose](https://products.aspose.app/slides/conversion)

Σχετική δυνατότητα: [Εξαγωγή παρουσιάσεων σε PDF](/slides/el/features/pdf-export/).