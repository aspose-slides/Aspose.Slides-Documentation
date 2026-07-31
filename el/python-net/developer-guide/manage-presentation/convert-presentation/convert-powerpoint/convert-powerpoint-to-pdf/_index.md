---
title: Μετατροπή PPT & PPTX σε PDF με Python | Προηγμένες Επιλογές
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
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - Python
  - Aspose.Slides for Python
description: "Οδηγός βήμα‑βήμα για τη μετατροπή PPT, PPTX και ODP σε PDF υψηλής ποιότητας, συμβατά με WCAG, σε Python με Aspose.Slides — περιλαμβάνει προστασία με κωδικό, επιλογή διαφανειών και έλεγχο ποιότητας εικόνας."
showReadingTime: true
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP) σε μορφή PDF με τη χρήση Python προσφέρει πολλά πλεονεκτήματα, συμπεριλαμβανομένης της διασφάλισης συμβατότητας μεταξύ διαφορετικών συσκευών και της διατήρησης της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για τον έλεγχο της ποιότητας εικόνας, να συμπεριλάβετε κρυφές διαφάνειες, να προστατεύσετε με κωδικό πρόσβασης τα έγγραφα PDF, να εντοπίσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα έγγραφα εξόδου.

## **Μετατροπές PowerPoint σε PDF**

Χρησιμοποιώντας Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις σε αυτές τις μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF με Python, απλώς πρέπει να περάσετε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/) και, στη συνέχεια, να αποθηκεύσετε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [Save](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/#methods). Η κλάση [Presentation] εκθέτει τη μέθοδο [Save] η οποία χρησιμοποιείται τυπικά για τη μετατροπή μιας παρουσίασης σε PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Το Aspose.Slides για Python γράφει απευθείας πληροφορίες API και αριθμό έκδοσης στα έγγραφα εξόδου. Για παράδειγμα, όταν μετατρέπει μια παρουσίαση σε PDF, το Aspose.Slides για Python συμπληρώνει το πεδίο Application με την τιμή '*Aspose.Slides*' και το πεδίο PDF Producer με μια τιμή της μορφής '*Aspose.Slides v XX.XX*'. **Σημείωση** ότι δεν μπορείτε να υποδείξετε στο Aspose.Slides για Python να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα έγγραφα εξόδου.

{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες σε μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, εξασφαλίζοντας ότι το περιεχόμενο των παραγόμενων PDF ταιριάζει στενά με τις αρχικές παρουσιάσεις. Στοιχεία και ιδιότητες αποδίδονται με ακρίβεια κατά τη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφων
* Υπερσύνδεσμοι
* Κεφαλίδες και υποσέλιδα
* Κουκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική λειτουργία μετατροπής PowerPoint σε PDF εκτελείται χρησιμοποιώντας τις προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στα μέγιστα επίπεδα ποιότητας. Αυτός ο κώδικας Python δείχνει πώς να μετατρέψετε ένα PowerPoint σε PDF:

_Βήματα: Μετατροπές PowerPoint σε PDF με Python_

Ο παρακάτω κώδικας δείχνει αυτές τις μετατροπές χρησιμοποιώντας Python μέσω .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Βήματα: Μετατροπή PowerPoint σε PDF χρησιμοποιώντας Python μέσω .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Βήματα: Μετατροπή PPT σε PDF χρησιμοποιώντας Python μέσω .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Βήματα: Μετατροπή PPTX σε PDF χρησιμοποιώντας Python μέσω .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Βήματα: Μετατροπή ODP σε PDF χρησιμοποιώντας Python μέσω .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Βήματα: Μετατροπή PPS σε PDF χρησιμοποιούμε Python μέσω .NET</strong></a>

_Βήματα κώδικα:_

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και δώστε της το αρχείο PowerPoint.
  * *.ppt* επέκταση για φόρτωση **PPT** αρχείου μέσα στην κλάση _Presentation_.
  * *.pptx* επέκταση για φόρτωση **PPTX** αρχείου μέσα στην κλάση _Presentation_.
  * *.odp* επέκταση για φόρτωση **ODP** αρχείου μέσα στην κλάση _Presentation_.
  * *.pps* επέκταση για φόρτωση **PPS** αρχείου μέσα στην κλάση _Presentation_.
- Αποθηκεύστε το _Presentation_ σε μορφή **PDF** καλώντας τη μέθοδο **Save** και χρησιμοποιώντας την απαρίθμηση **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Αποθηκεύει την παρουσίαση ως PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Το Aspose παρέχει ένα δωρεάν διαδικτυακό [**Μετατροπέας PowerPoint σε PDF**](https://products.aspose.app/slides/el/conversion/ppt-to-pdf) που επιδεικνύει τη διαδικασία μετατροπής παρουσίασης σε PDF. Για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ, μπορείτε να κάνετε δοκιμή με τον μετατροπέα.

{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές — ιδιότητες της κλάσης [PdfOptions](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides.export/pdfoptions/) — που σας επιτρέπουν να προσαρμόσετε το PDF (που προκύπτει από τη διαδικασία μετατροπής), να κλειδώσετε το PDF με κωδικό πρόσβασης ή ακόμη και να καθορίσετε πώς θα εκτελείται η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Με προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για raster εικόνες, να καθορίσετε πώς θα διαχειρίζεστε metafiles, να θέσετε επίπεδο συμπίεσης για κείμενα, DPI για εικόνες κλπ.

Το παρακάτω παράδειγμα κώδικα δείχνει μια λειτουργία στην οποία μια παρουσίαση PowerPoint μετατρέπεται σε PDF με πολλές προσαρμοσμένες επιλογές:

```python
import aspose.slides as slides

# Δημιουργεί μια παρουσία της κλάσης PdfOptions
pdf_options = slides.export.PdfOptions()

# Ορίζει την ποιότητα για εικόνες JPG
pdf_options.jpeg_quality = 90

# Ορίζει το DPI για εικόνες
pdf_options.sufficient_resolution = 300

# Ορίζει τη συμπεριφορά για μετααρχεία
pdf_options.save_metafiles_as_png = True

# Ορίζει το επίπεδο συμπίεσης κειμένου για το κειμενικό περιεχόμενο
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Ορίζει τη λειτουργία συμμόρφωσης PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα έγγραφο PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Αποθηκεύει την παρουσίαση ως έγγραφο PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Αν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε μια προσαρμοσμένη επιλογή — την ιδιότητα `show_hidden_slides` από την κλάση [PdfOptions](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides.export/pdfoptions/) — για να υποδείξετε στο Aspose.Slides να συμπεριλάβει τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Αυτός ο κώδικας Python δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με τις κρυφές διαφάνειες να περιλαμβάνονται:

```python
import aspose.slides as slides

# Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Δημιουργεί την κλάση PdfOptions
pdfOptions = slides.export.PdfOptions()

# Προσθέτει κρυφές διαφάνειες
pdfOptions.show_hidden_slides = True

# Αποθηκεύει την παρουσίαση ως PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού**

Αυτός ο κώδικας Python δείχνει πώς να μετατρέψετε ένα PowerPoint σε PDF προστατευμένο με κωδικό (χρησιμοποιώντας παραμέτρους προστασίας από την κλάση [PdfOptions](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Δημιουργεί την κλάση PdfOptions
pdfOptions = slides.export.PdfOptions()

# Ορίζει κωδικό πρόσβασης PDF και δικαιώματα πρόσβασης
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Αποθηκεύει την παρουσίαση ως PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Μετατροπή Επιλεγμένων Διαφανειών σε PowerPoint σε PDF**

Αυτός ο κώδικας Python δείχνει πώς να μετατρέψετε συγκεκριμένες διαφάνειες μιας παρουσίασης PowerPoint σε PDF:

```python
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Ορίζει έναν πίνακα θέσεων διαφανειών
slides_array = [ 1, 3 ]

# Αποθηκεύει την παρουσίαση ως PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Αυτός ο κώδικας Python δείχνει πώς να μετατρέψετε ένα PowerPoint όταν το μέγεθος της διαφάνειας έχει καθοριστεί σε PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Δημιουργεί την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Δημιουργεί μια νέα παρουσίαση με προσαρμοσμένο μέγεθος διαφάνειας.
    with slides.Presentation() as resized_presentation:

        # Ορίζει το προσαρμοσμένο μέγεθος διαφάνειας.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Κλωνοποιεί την πρώτη διαφάνεια από την αρχική παρουσίαση.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Αποθηκεύει την προσαρμοσμένη παρουσίαση σε PDF με σημειώσεις.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Μετατροπή PowerPoint σε PDF σε Προβολή Σημειώσεων Διαφάνειας**

Αυτός ο κώδικας Python δείχνει πώς να μετατρέψετε ένα PowerPoint σε PDF σημειώσεων:

```python
import aspose.slides as slides

# Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Αποθηκεύει την παρουσίαση σε PDF σημειώσεις
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Πρόσβαση και Πρότυπα Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Οδηγίες Προσβασιμότητας Περιεχομένου Ιστού (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από τα παρακάτω πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b**, και **PDF/UA**.

Αυτός ο κώδικας Python επιδεικνύει μια λειτουργία μετατροπής PowerPoint σε PDF στην οποία λαμβάνονται πολλά PDF βάσει διαφορετικών προτύπων συμμόρφωσης:

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

{{% alert title="Note" color="warning" %}} 

Η υποστήριξη του Aspose.Slides για λειτουργίες μετατροπής PDF επεκτείνεται ώστε να σας επιτρέπει να μετατρέψετε PDF στις πιο δημοφιλείς μορφές αρχείων. Μπορείτε να κάνετε μετατροπές [PDF σε HTML](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-html/), [PDF σε εικόνα](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές — [PDF σε SVG](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-xml/) — επίσης υποστηρίζονται.

{{% /alert %}}

> **Σημείωση:** Όταν εξάγετε σε PDF/UA, το Aspose.Slides αντιμετωπίζει πολύπλογα γραφικά όπως SmartArt, διαγράμματα και τύπους ως μία ενιαία εικόνα. Τα επιμέρους στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως τέχνη· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρη τη φιγούρα.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides για Python να αφαιρέσει τις πληροφορίες εφαρμογής από το PDF;**

Όχι, το Aspose.Slides για Python προσθέτει αυτόματα πληροφορίες API και τον αριθμό έκδοσης στο παραγόμενο PDF. Αυτές οι πληροφορίες δεν μπορούν να τροποποιηθούν ή να αφαιρεθούν.

**Πώς μπορώ να συμπεριλάβω μόνο συγκεκριμένες διαφάνειες στη μετατροπή PDF;**

Μπορείτε να καθορίσετε τις θέσεις διαφανειών που θέλετε να μετατρέψετε περνώντας έναν πίνακα δεικτών διαφανειών στη μέθοδο `save`.

**Μπορεί η PDF να προστατευθεί με κωδικό κατά τη μετατροπή;**

Ναι, μπορείτε να ορίσετε κωδικό πρόσβασης και να ορίσετε δικαιώματα πρόσβασης χρησιμοποιώντας την κλάση `PdfOptions` πριν αποθηκεύσετε την παρουσίαση ως PDF.

**Υποστηρίζει το Aspose.Slides τη μετατροπή PDF σε άλλες μορφές;**

Ναι, το Aspose.Slides υποστηρίζει τη μετατροπή PDF σε μορφές όπως HTML, μορφές εικόνας (JPG, PNG), SVG, TIFF και XML.

**Πώς μπορώ να εξασφαλίσω ότι το PDF μου συμμορφώνεται με πρότυπα προσβασιμότητας;**

Ορίστε την ιδιότητα `compliance` στην `PdfOptions` σε πρότυπα όπως `PDF_A1A`, `PDF_A1B` ή `PDF_UA` για να εξασφαλίσετε τη συμμόρφωση με τις οδηγίες προσβασιμότητας.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στο παραγόμενο PDF;**

Ναι, ορίζοντας την ιδιότητα `show_hidden_slides` στην `PdfOptions` σε `True`, οι κρυφές διαφάνειες θα περιλαμβάνονται στο PDF.

**Πώς ρυθμίζω την ποιότητα και την ανάλυση εικόνας κατά τη μετατροπή;**

Χρησιμοποιήστε τις ιδιότητες `jpeg_quality` και `sufficient_resolution` στην `PdfOptions` για να ελέγξετε την ποιότητα και την ανάλυση των εικόνων στο παραγόμενο PDF.

**Το Aspose.Slides διαχειρίζεται αυτόματα τις αντικαταστάσεις γραμματοσειρών;**

Το Aspose.Slides ανιχνεύει αντικαταστάσεις γραμματοσειρών κατά τη μετατροπή, και μπορείτε να τις διαχειριστείτε χρησιμοποιώντας την ιδιότητα `warning_callback` στην `SaveOptions` (προς το παρόν περιορισμένη).

## **Πρόσθετοι Πόροι**

- [Aspose.Slides for .NET Documentation](https://docs.aspose.com/slides/el/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/el/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/el/conversion)