---
title: Μετατροπή PPT και PPTX σε PDF σε Python μέσω Java [Συμπεριλαμβάνονται Προηγμένες Λειτουργίες]
linktitle: PowerPoint σε PDF
type: docs
weight: 40
url: /el/python-java/convert-powerpoint-to-pdf/
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
- Python
- Java
- Aspose.Slides
description: "Μετατρέψτε PowerPoint PPT/PPTX σε υψηλής ποιότητας, αναζητήσιμα PDFs σε Python μέσω Java χρησιμοποιώντας το Aspose.Slides, με γρήγορα παραδείγματα κώδικα και προηγμένες επιλογές μετατροπής."
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP κ.λπ.) σε μορφή PDF σε Python μέσω Java προσφέρει πολλά πλεονεκτήματα, συμπεριλαμβανομένης της συμβατότητας σε διαφορετικές συσκευές και της διατήρησης της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός επιδεικνύει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για τον έλεγχο της ποιότητας εικόνας, να συμπεριλάβετε κρυφές διαφάνειες, να προστατεύσετε με κωδικό πρόσβασης τα αρχεία PDF, να εντοπίσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Με τη χρήση του Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις στις ακόλουθες μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF, περάστε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) και στη συνέχεια αποθηκεύστε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Η κλάση [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) εκθέτει τη μέθοδο [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) η οποία χρησιμοποιείται συνήθως για τη μετατροπή μιας παρουσίασης σε PDF.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides για Python μέσω Java εισάγει τις πληροφορίες του API του και τον αριθμό έκδοσης στα έξοδα έγγραφα. Για παράδειγμα, κατά τη μετατροπή μιας παρουσίασης σε PDF, το Aspose.Slides γεμίζει το πεδίο Application με "*Aspose.Slides*" και το πεδίο PDF Producer με μια τιμή στη μορφή "*Aspose.Slides v XX.XX*". **Σημείωση** ότι δεν μπορείτε να υποδείξετε στο Aspose.Slides να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα παραγόμενα έγγραφα.
{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες από μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα παραγόμενα PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και τα χαρακτηριστικά αποδίδονται ακριβώς στην μετατροπή, περιλαμβάνοντας:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφου
* Υπερσυνδέσεις
* Κεφαλίδες και υποσέλιδα
* Κουκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική μετατροπή χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις εξαγωγής PDF. Χρησιμοποιήστε προσαρμοσμένες επιλογές όταν χρειάζεται να ελέγξετε την ποιότητα εικόνας, το περιεχόμενο της σελίδας ή τη συμμόρφωση με το PDF.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση και αποθηκεύει όλες τις ορατές διαφάνειες σε PDF χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις εξαγωγής.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Το Aspose προσφέρει έναν δωρεάν διαδικτυακό [**Μετατροπέας PowerPoint σε PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) που επιδεικνύει τη διαδικασία μετατροπής παρουσίασης σε PDF. Μπορείτε να εκτελέσετε ένα τεστ με αυτόν τον μετατροπέα για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές—ιδιότητες στην κλάση [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)—που σας επιτρέπουν να προσαρμόσετε το παραγόμενο PDF, να κλειδώσετε το PDF με κωδικό πρόσβασης ή να ορίσετε πώς θα προχωρήσει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για εικόνες raster, να καθορίσετε πώς θα διαχειρίζονται τα μετααρχεία, να θέσετε επίπεδο συμπίεσης για το κείμενο, να διαμορφώσετε DPI για τις εικόνες και άλλα.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF 1.5 με ποιότητα JPEG ορισμένη στο 90, ανάλυση εικόνας ορισμένη στα 300 DPI, μετααρχεία αποθηκευμένα ως PNG και συμπίεση κειμένου Flate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Αυτόματη Επιλογή Συμπίεσης Εικόνας**

Όταν μια παρουσίαση περιέχει πολλές φωτογραφίες ή στιγμιότυπα οθόνης, η μείωση του μεγέθους του εξαγόμενου PDF μπορεί να το κάνει πιο εύκολο για αποστολή μέσω email ή λήψη. Καλέστε τη μέθοδο [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setBestImagesCompressionRatio) με `True` για να επιλέξετε αυτόματα τον πιο κατάλληλο αλγόριθμο συμπίεσης για κάθε εικόνα κατά την εξαγωγή PDF.

Το παρακάτω παράδειγμα φορτώνει μια υπάρχουσα παρουσίαση, ενεργοποιεί την αυτόματη επιλογή συμπίεσης εικόνας και την αποθηκεύει ως έγγραφο PDF. Όλες οι άλλες ρυθμίσεις εξαγωγής PDF διατηρούν τις προεπιλεγμένες τιμές τους.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setBestImagesCompressionRatio(True)

presentation = Presentation("image-heavy.pptx")
try:
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Αυτή η επιλογή επιλέγει έναν αλγόριθμο συμπίεσης για κάθε εικόνα. Η μείωση της τιμής που περνιέται στη μέθοδο [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) μειώνει την ποιότητα της εικόνας JPEG, ενώ η μείωση της τιμής που περνιέται στη μέθοδο [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) επιτρέπει την υποδειγματοληψία των εικόνων σε χαμηλότερη ανάλυση, γεγονός που μπορεί να μειώσει τις λεπτομέρειες. Η ενεργοποίηση της αυτόματης επιλογής συμπίεσης δεν μειώνει από μόνη της καμία από αυτές τις ρυθμίσεις.

Η επιλογή αλγορίθμων συμπίεσης εικόνας απαιτεί επιπλέον χρόνο επεξεργασίας και μνήμη. Η μείωση του μεγέθους εξαρτάται από τις εικόνες της παρουσίασης και τις ρυθμίσεις εξαγωγής· δεν εγγυάται σταθερή μείωση για κάθε παρουσίαση.

### **Διατήρηση Ενσωματωμένων Αρχείων OLE ως Συνημμένα PDF**

Εάν μια παρουσίαση περιέχει ενσωματωμένο βιβλίο εργασίας Excel, ίσως θέλετε οι παραλήπτες του PDF να έχουν πρόσβαση στα δεδομένα του βιβλίου εργασίας καθώς και να βλέπουν τις διαφάνειες. Καλέστε τη μέθοδο [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) με `True` για να διατηρήσετε τα ενσωματωμένα αρχεία OLE ως συνημμένα στο παραγόμενο PDF.

Η προεπιλεγμένη τιμή είναι `False`: η εικόνα προεπισκόπησης ή το εικονίδιο του αντικειμένου OLE αποδίδεται στη σελίδα PDF, αλλά το ενσωματωμένο αρχείο δεν συμπεριλαμβάνεται ως συνημμένο. Ορισμός της επιλογής σε `True` προσθέτει επίσης τα δεδομένα του αρχείου. Η προεπισκόπηση παραμένει μια οπτική αναπαράσταση· το συνημμένο επιτρέπει στους παραλήπτες να ανοίξουν ή να αποθηκεύσουν το ενσωματωμένο αρχείο ξεχωριστά. Το αντικείμενο OLE δεν μετατρέπεται σε διαδραστικό φύλλο εργασίας Excel στη σελίδα PDF.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση που ήδη περιέχει ενσωματωμένο βιβλίο εργασίας Excel και το εξάγει σε PDF με το βιβλίο εργασίας επισυναπτόμενο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Για να ελέγξετε το αποτέλεσμα:

1. Ανοίξτε το εξαγόμενο PDF σε έναν προβολέα που υποστηρίζει συνημμένα αρχείο, όπως το Adobe Acrobat Reader.
2. Ανοίξτε το τμήμα **Attachments** του προβολέα και εντοπίστε το ενσωματωμένο βιβλίο εργασίας.
3. Αποθηκεύστε το συνημμένο και ανοίξτε το στο Excel για να ελέγξετε τα δεδομένα του, ή ανοίξτε το απευθείας εάν το προβολέα το επιτρέπει. Η προεπισκόπηση στη σελίδα PDF είναι ξεχωριστή από το συνημμένο.

{{% alert color="info" title="Note" %}}
Τα πρότυπα PDF/A επιβάλλουν περιορισμούς στα συνημμένα: το PDF/A-1 απαγορεύει ενσωματωμένα αρχεία, το PDF/A-2 επιτρέπει μόνο συνημμένα PDF/A, και το PDF/A-3 επιτρέπει άλλους τύπους αρχείων, συμπεριλαμβανομένων βιβλίων εργασίας Excel. Αυτά είναι απαιτήσεις των προτύπων, όχι περιορισμοί που αφορούν ειδικά το Aspose.Slides. Αυτό το παράδειγμα χρησιμοποιεί την προεπιλεγμένη ρύθμιση συμμόρφωσης PDF και δεν επιδεικνύει εξαγωγή PDF/A.
{{% /alert %}}

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) από την κλάση [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) για να συμπεριλάβετε τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF, συμπεριλαμβανομένων τυχόν κρυφών διαφανειών.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF που απαιτεί τον κωδικό `password` για άνοιγμα. Τα δικαιώματα πρόσβασης επιτρέπουν εκτύπωση, συμπεριλαμβανομένης εκτύπωσης υψηλής ποιότητας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Ανίχνευση Αντικαταστάσεων Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) στην κλάση [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), επιτρέποντάς σας να ανιχνεύσετε αντικαταστάσεις γραμματοσειρών κατά τη διαδικασία μετατροπής παρουσίασης σε PDF.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF και εκτυπώνει προειδοποιήσεις αντικατάστασης γραμματοσειράς στην κονσόλα. Μία προειδοποίηση εμφανίζεται μόνο όταν μια μη διαθέσιμη γραμματοσειρά αντικαθίσταται κατά την εξαγωγή. Χρησιμοποιήστε έναν διαμεσολαβητή JPype για να λαμβάνετε κλήσεις προειδοποίησης από το Java API. Μετατρέψτε τη συμβολοσειρά περιγραφής Java σε συμβολοσειρά Python πριν ελέγξετε το πρόθεμά της:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Για περισσότερες πληροφορίες σχετικά με την αντικατάσταση γραμματοσειρών, δείτε το άρθρο [Αντικατάσταση Γραμματοσειρών](/slides/el/python-java/font-substitution/).
{{% /alert %}}

### **Διαχείριση Γραμματοσειρών Χωρίς Αποκλειστικό Στυλ Bold**

Μια παρουσίαση μπορεί να εφαρμόσει έντονη μορφοποίηση σε κείμενο ακόμη και όταν η γραμματοσειρά της δεν διαθέτει ειδική έντονη γραμματοσειρά. Το κείμενο μπορεί να εμφανίζεται έντονο μέσω συνθετικού έντονου, το οποίο τεχνητά παχύνει τα κανονικά σύμβολα. Όταν αυτό το κείμενο φαίνεται πολύ βαρύ ή διαφορετικό από την επιθυμητή εμφάνιση στο PDF, δοκιμάστε να καλέσετε τη μέθοδο [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) με `True`. Αυτή η επιλογή αποδίδει το επηρεασμένο κείμενο ως bitmap κατά την εξαγωγή PDF και μπορεί να βελτιώσει την εμφάνισή του για ορισμένες γραμματοσειρές. Η προεπιλεγμένη τιμή της είναι `False`.

Η δείγμα παρουσίαση περιέχει δύο πλαίσια κειμένου: ένα με κανονικό κείμενο και ένα με έντονη μορφοποίηση που εφαρμόζεται στην ίδια γραμματοσειρά, η οποία δεν διαθέτει ειδική έντονη γραμματοσειρά. Το παρακάτω παράδειγμα φορτώνει την παρουσίαση, ενεργοποιεί τη rasterization μη υποστηριζόμενων στυλ γραμματοσειράς και την εξάγει σε PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Οι παρακάτω προεπισκοπήσεις εμφανίζουν το αποτέλεσμα με την επιλογή απενεργοποιημένη και ενεργοποιημένη. Σε αυτό το παράδειγμα, το έντονο κείμενο έχει πιο βαρύ στίγμα με την επιλογή απενεργοποιημένη. Με την επιλογή ενεργοποιημένη, τα στίγματα είναι ελαφρύτερα· το κανονικό κείμενο παραμένει αμετάβλητο. Συγκρίνετε τα αποτελέσματα πριν επιλέξετε τη ρύθμιση για την παρουσίασή σας.

| Option disabled (`False`, the default) | Option enabled (`True`) |
|---|---|
| ![PDF με rasterization μη υποστηριζόμενου στυλ γραμματοσειράς απενεργοποιημένο](unsupported-bold-disabled.png) | ![PDF με rasterization μη υποστηριζόμενου στυλ γραμματοσειράς ενεργοποιημένο](unsupported-bold-enabled.png) |

Σε αυτό το παράδειγμα, η ενεργοποίηση της επιλογής μετατρέπει μόνο το έντονο κείμενο σε bitmap: δεν μπορεί να επιλεχθεί, αντιγραφεί ή αναζητηθεί ως κείμενο χωρίς OCR, και οι άκρες του εμφανίζονται πιο μαλακές σε μεγέθυνση 800%. Το κανονικό κείμενο παραμένει αναζητήσιμο. Με την επιλογή απενεργοποιημένη, και οι δύο συμβολοσειρές παραμένουν κείμενο.

Αυτή η επιλογή rasterizes κείμενο μορφοποιημένο ως bold όταν η γραμματοσειρά του δεν διαθέτει ειδική bold γραμματοσειρά. Η [Αντικατάσταση Γραμματοσειρών](/slides/el/python-java/font-substitution/) επιλέγει αντίστροφα άλλη γραμματοσειρά όταν η αρχική δεν είναι διαθέσιμη.

## **Μετατροπή Επιλεγμένων Διαφανειών από PowerPoint σε PDF**

Οι αριθμοί διαφανειών που περνιούνται στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) είναι με βάση το 1. Αυτό το παράδειγμα εξάγει τις διαφάνειες 1 και 3 όταν και οι δύο υπάρχουν:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Αυτό το παράδειγμα εξάγει την πρώτη διαφάνεια σε μια σελίδα διαστάσεων 612 x 792 σημεία (US Letter). Αντιγράφει τη διαφάνεια σε μια νέα παρουσίαση με το καθορισμένο μέγεθος και κλιμακώνει το περιεχόμενο της διαφάνειας ώστε να ταιριάζει.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Αφαιρέστε τη κενή διαφάνεια που δημιουργήθηκε με τη νέα παρουσίαση.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Μετατροπή PowerPoint σε PDF σε Προβολή Σημειώσεων Διαφάνειας**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF, τοποθετώντας τις σημειώσεις ομιλητή κάθε διαφάνειας κάτω από τη διαφάνεια. Χρησιμοποιήστε μια παρουσίαση που περιέχει σημειώσεις ομιλητή για να δείτε το αποτέλεσμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Πρότυπα Προσβασιμότητας και Συμμόρφωσης για PDF**

Κατά την προετοιμασία προσβάσιμων PDF, συμβουλευτείτε τις [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Χρησιμοποιήστε τη μέθοδο [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) για να επιλέξετε ένα πρότυπο εξόδου: **PDF/A1a**, **PDF/A1b**, και **PDF/UA**.

Αυτός ο κώδικας επιδεικνύει μια διαδικασία μετατροπής PowerPoint σε PDF που παράγει πολλαπλά PDF βάσει διαφορετικών προτύπων συμμόρφωσης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()

    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)

    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει πολύπλοκα γραφικά όπως SmartArt, διαγράμματα και τύπους ως ένα ενιαίο σχήμα. Τα μεμονωμένα στοιχεία μονοπατιού δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως τέλη· εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρο το σχήμα.

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλά αρχεία PowerPoint σε PDF μαζικά;**

Ναι, το Aspose.Slides υποστηρίζει μαζική μετατροπή πολλαπλών αρχείων PPT ή PPTX σε PDF. Μπορείτε να επαναλάβετε τα αρχεία σας και να εφαρμόσετε τη διαδικασία μετατροπής προγραμματιστικά.

**Μπορεί να προστατευτεί με κωδικό πρόσβασης το μετατραπείν PDF;**

Ναι. Χρησιμοποιήστε την κλάση [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) για να ορίσετε κωδικό πρόσβασης και να καθορίσετε δικαιώματα πρόσβασης κατά τη διαδικασία μετατροπής.

**Πώς να συμπεριλάβω κρυφές διαφάνειες στο PDF;**

Καλέστε τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) με `True` στην κλάση [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) για να συμπεριλάβετε κρυφές διαφάνειες στο παραγόμενο PDF.

**Μπορεί το Aspose.Slides να διατηρήσει υψηλή ποιότητα εικόνας στο PDF;**

Ναι, μπορείτε να ελέγξετε την ποιότητα εικόνας χρησιμοποιώντας μεθόδους όπως [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) και [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) στην κλάση [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) για να εξασφαλίσετε υψηλής ποιότητας εικόνες στο PDF σας.

**Υποστηρίζει το Aspose.Slides πρότυπα συμμόρφωσης PDF/A;**

Ναι, το Aspose.Slides επιτρέπει την εξαγωγή PDF που συμμορφώνονται με [διάφορα πρότυπα](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), συμπεριλαμβανομένων PDF/A1a, PDF/A1b και PDF/UA, για προσβασιμότητα ή αρχειοθέτηση. Επιλέξτε το κατάλληλο πρότυπο και ελέγξτε το αποτέλεσμα σε σχέση με τις απαιτήσεις σας.

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides για Python μέσω Java](/slides/el/python-java/)
- [Αναφορά API Aspose.Slides για Python μέσω Java](https://reference.aspose.com/slides/python-java/)
- [Δωρεάν Online Μετατροπείς Aspose](https://products.aspose.app/slides/conversion)