---
title: Μετατροπή PPT & PPTX σε PDF με Python | Προχωρημένες Επιλογές
linktitle: PowerPoint σε PDF
type: docs
weight: 40
url: /el/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- μετατροπή PowerPoint
- παρουσίαση
- PowerPoint σε PDF
- PPT σε PDF
- PPTX σε PDF
- αποθήκευση PowerPoint ως PDF
- συνημμένο
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Οδηγός βήμα‑βήμα για τη μετατροπή PPT, PPTX και ODP σε PDF υψηλής ποιότητας, συμβατά με WCAG, με την Python και το Aspose.Slides—συμπεριλαμβάνει προστασία με κωδικό πρόσβασης, επιλογή διαφανειών και έλεγχο ποιότητας εικόνας."
showReadingTime: true
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP) σε μορφή PDF με την Python προσφέρει πολλά πλεονεκτήματα, συμπεριλαμβανομένης της διασφάλισης συμβατότητας σε διαφορετικές συσκευές και της διατήρησης της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για το έλεγχο της ποιότητας εικόνας, να συμπεριλάβετε κρυφές διαφάνειες, να προστατέψετε με κωδικό πρόσβασης τα έγγραφα PDF, να ανιχνεύσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις σε αυτές τις μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF με την Python, αρκεί να περάσετε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) και στη συνέχεια να αποθηκεύσετε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Η κλάση [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) εκθέτει τη μέθοδο [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) που συνήθως χρησιμοποιείται για τη μετατροπή μιας παρουσίασης σε PDF.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides για Python προσθέτει τις πληροφορίες του API και τον αριθμό έκδοσης στα παραγόμενα έγγραφα. Για παράδειγμα, όταν μετατρέπει μια παρουσίαση σε PDF, το Aspose.Slides για Python συμπληρώνει το πεδίο Application με την τιμή '*Aspose.Slides*' και το πεδίο PDF Producer με μια τιμή στη μορφή '*Aspose.Slides v XX.XX*'. **Σημειώστε** ότι δεν μπορείτε να ζητήσετε από το Aspose.Slides για Python να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα παραγόμενα έγγραφα.
{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες σε μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι το περιεχόμενο των παραγόμενων PDF ταιριάζει στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και τα χαρακτηριστικά αποδίδονται με ακρίβεια κατά τη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Κουτιά κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφων
* Υπερσυνδέσεις
* Κεφαλίδες και υποσέλιδα
* Κουκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική διαδικασία μετατροπής PowerPoint σε PDF χρησιμοποιεί προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στα μέγιστα επίπεδα ποιότητας.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση και αποθηκεύει όλες τις ορατές διαφάνειες σε PDF χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις εξαγωγής.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Το Aspose παρέχει έναν δωρεάν διαδικτυακό [**μετατροπέα PowerPoint σε PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) που επιδεικνύει τη διαδικασία μετατροπής παρουσίασης σε PDF. Για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ, μπορείτε να κάνετε μια δοκιμή με τον μετατροπέα.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές—ιδιότητες στην κλάση [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—που σας επιτρέπουν να προσαρμόσετε το PDF (που προκύπτει από τη διαδικασία μετατροπής), να κλειδώσετε το PDF με κωδικό πρόσβασης ή ακόμη και να καθορίσετε πώς θα γίνει η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για ραστερ εικόνες, να καθορίσετε πώς θα χειρίζονται τα μετααρχεία, να ορίσετε επίπεδο συμπίεσης για κείμενο, DPI για εικόνες κ.λπ.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF 1.5 με ποιότητα JPEG 90, ανάλυση εικόνας 300 DPI, μετααρχεία αποθηκευμένα ως PNG και συμπίεση κειμένου Flate.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Διατήρηση Ενσωματωμένων Αρχείων OLE ως Συνημμένα PDF**

Εάν μια παρουσίαση περιέχει ενσωματωμένο βιβλίο εργασίας Excel, μπορεί να θέλετε οι αποδέκτες του PDF να έχουν πρόσβαση στα δεδομένα του βιβλίου εργασίας καθώς και να βλέπουν τις διαφάνειες. Ορίστε το [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) σε `True` για να διατηρήσετε τα ενσωματωμένα αρχεία OLE ως συνημμένα στο παραγόμενο PDF.

Η προεπιλεγμένη τιμή είναι `False`: η προεπισκόπηση εικόνας ή το εικονίδιο του αντικειμένου OLE αποτυπώνεται στη σελίδα PDF, αλλά το ενσωματωμένο αρχείο δεν συμπεριλαμβάνεται ως συνημμένο. Ορίζοντας την επιλογή σε `True` συμπεριλαμβάνει επιπλέον τα δεδομένα του αρχείου. Η προεπισκόπηση παραμένει οπτική αναπαράσταση· το συνημμένο επιτρέπει στους αποδέκτες να ανοίξουν ή να αποθηκεύσουν το ενσωματωμένο αρχείο χωριστά. Το αντικείμενο OLE δεν γίνεται διαδραστικό φύλλο Excel στη σελίδα PDF.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση που ήδη περιέχει ενσωματωμένο βιβλίο εργασίας Excel και την εξάγει σε PDF με το βιβλίο εργασίας συνημμένο.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Για να ελέγξετε το αποτέλεσμα:

1. Ανοίξτε το εξαγόμενο PDF σε έναν προβολέα που υποστηρίζει συνημμένα αρχεία, όπως το Adobe Acrobat Reader.
2. Ανοίξτε το πάνελ **Attachments** του προβολέα και εντοπίστε το ενσωματωμένο βιβλίο εργασίας.
3. Αποθηκεύστε το συνημμένο και ανοίξτε το στο Excel για να ελέγξετε τα δεδομένα του, ή ανοίξτε το απευθείας εάν ο προβολέας το επιτρέπει. Η προεπισκόπηση στη σελίδα PDF είναι ξεχωριστή από το συνημμένο.

{{% alert color="info" title="Note" %}}
Τα πρότυπα PDF/A επιβάλλουν περιορισμούς στα συνημμένα: το PDF/A-1 απαγορεύει ενσωματωμένα αρχεία, το PDF/A-2 επιτρέπει μόνο συνημμένα PDF/A, και το PDF/A-3 επιτρέπει άλλους τύπους αρχείων, συμπεριλαμβανομένων βιβλίων εργασίας Excel. Πρόκειται για απαιτήσεις των προτύπων, όχι περιορισμούς ειδικά για το Aspose.Slides. Αυτό το παράδειγμα χρησιμοποιεί την προεπιλεγμένη ρύθμιση συμμόρφωσης PDF και δεν δείχνει εξαγωγή PDF/A.
{{% /alert %}}

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε μια προσαρμοσμένη επιλογή—την ιδιότητα [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) από την κλάση [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—για να ζητήσετε από το Aspose.Slides να συμπεριλάβει τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF, συμπεριλαμβανομένων τυχόν κρυφών διαφανειών.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Μετατροπή PowerPoint σε PDF με Κωδικό Πρόσβασης**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF που απαιτεί τον κωδικό `password` για άνοιγμα. Τα δικαιώματα πρόσβασης επιτρέπουν εκτύπωση, συμπεριλαμβανομένης εκτύπωσης υψηλής ποιότητας.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Μετατροπή Επιλεγμένων Διαφανειών σε PowerPoint σε PDF**

Το παρακάτω παράδειγμα εξάγει τις διαφάνειες 1 και 3 από μια παρουσίαση σε PDF. Οι αριθμοί διαφανειών σε αυτόν τον πίνακα ξεκινούν από το 1, και η είσοδος παρουσίασης πρέπει να περιέχει τουλάχιστον τρεις διαφάνειες.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Το παρακάτω παράδειγμα αντιγράφει την πρώτη διαφάνεια από μια παρουσίαση σε μια νέα παρουσίαση με μέγεθος διαφάνειας 612 × 792 σημεία (8,5 × 11 ίντσες). Κάνει κλιμάκωση του περιεχομένου της διαφάνειας ώστε να χωράει και εξάγει τη μοναδική διαφάνεια σε PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Αφαιρέστε τη κενή διαφάνεια που δημιουργήθηκε με τη νέα παρουσίαση.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Μετατροπή PowerPoint σε PDF σε Προβολή Σημειώσεων Διαφάνειας**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF, τοποθετώντας τις σημειώσεις ομιλητή κάθε διαφάνειας κάτω από τη διαφάνεια. Χρησιμοποιήστε μια παρουσίαση που περιέχει σημειώσεις ομιλητή για να δείτε το αποτέλεσμα.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Πρότυπα Προσβασιμότητας και Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Οδηγίες Προσβασιμότητας Περιεχομένου Ιστού (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b**, και **PDF/UA**.

Αυτός ο κώδικας Python δείχνει μια λειτουργία μετατροπής PowerPoint σε PDF στην οποία λαμβάνονται πολλαπλά PDF βάσει διαφορετικών προτύπων συμμόρφωσης:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert color="info" title="Note" %}}
Η υποστήριξη του Aspose.Slides για λειτουργίες μετατροπής PDF σάς επιτρέπει να μετατρέψετε PDF στις πιο δημοφιλείς μορφές αρχείων. Μπορείτε να κάνετε μετατροπές [PDF σε HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF σε εικόνα](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές—[PDF σε SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—υποστηρίζονται επίσης.
{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει σύνθετα γραφικά όπως SmartArt, διαγράμματα και τύπους ως ένα ενιαίο στοιχείο. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως αντικείμενα τέχνης· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρο το στοιχείο.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Μπορεί το Aspose.Slides για Python να αφαιρέσει τις πληροφορίες εφαρμογής από το PDF;**

Όχι, το Aspose.Slides για Python συμπεριλαμβάνει αυτόματα τις πληροφορίες του API και τον αριθμό έκδοσης στο εξαγόμενο PDF. Αυτές οι πληροφορίες δεν μπορούν να τροποποιηθούν ή να αφαιρεθούν.

**Πώς μπορώ να συμπεριλάβω μόνο συγκεκριμένες διαφάνειες στη μετατροπή PDF;**

Μπορείτε να καθορίσετε τα ευρετήρια των διαφανειών που θέλετε να μετατρέψετε περνώντας έναν πίνακα θέσεων διαφανειών στη μέθοδο [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**Μπορεί να προστατευτεί με κωδικό πρόσβασης το PDF κατά τη μετατροπή;**

Ναι, μπορείτε να ορίσετε κωδικό πρόσβασης και να καθορίσετε δικαιώματα πρόσβασης χρησιμοποιώντας την κλάση [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) πριν αποθηκεύσετε την παρουσίαση ως PDF.

**Υποστηρίζει το Aspose.Slides τη μετατροπή PDF σε άλλες μορφές;**

Ναι, το Aspose.Slides υποστηρίζει τη μετατροπή PDF σε μορφές όπως HTML, μορφές εικόνας (JPG, PNG), SVG, TIFF και XML.

**Πώς μπορώ να διασφαλίσω ότι το PDF μου συμμορφώνεται με τα πρότυπα προσβασιμότητας;**

Ορίστε την ιδιότητα [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) σε πρότυπα όπως `PDF_A1A`, `PDF_A1B` ή `PDF_UA` για να διασφαλίσετε τη συμμόρφωση με τις οδηγίες προσβασιμότητας.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στην έξοδο PDF;**

Ναι, ορίζοντας την ιδιότητα [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) σε `True`, οι κρυφές διαφάνειες θα συμπεριληφθούν στο PDF.

**Πώς μπορώ να ρυθμίσω την ποιότητα και την ανάλυση εικόνας κατά τη μετατροπή;**

Χρησιμοποιήστε τις ιδιότητες [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) και [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) για να ελέγξετε την ποιότητα και την ανάλυση εικόνας στο παραγόμενο PDF.

**Ανιχνεύει το Aspose.Slides αυτόματα αντικαταστάσεις γραμματοσειρών;**

Το Aspose.Slides ανιχνεύει αντικαταστάσεις γραμματοσειρών κατά τη μετατροπή, και μπορείτε να τις διαχειριστείτε χρησιμοποιώντας την ιδιότητα `warning_callback` στην `SaveOptions` (προς το παρόν περιορισμένη).

## **Επιπλέον Πόροι**

- [Aspose.Slides για Python μέσω .NET Τεκμηρίωση](/slides/el/python-net/)
- [Αναφορά API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Δωρεάν Online Μετατροπείς Aspose](https://products.aspose.app/slides/conversion)