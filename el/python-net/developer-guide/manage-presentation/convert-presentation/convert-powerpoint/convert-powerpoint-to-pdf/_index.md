---
title: Μετατροπή PPT & PPTX σε PDF με Python | Προηγμένες Επιλογές
linktitle: PowerPoint σε PDF
type: docs
weight: 40
url: /el/python-net/convert-powerpoint-to-pdf/
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
description: "Οδηγός βήμα προς βήμα για τη μετατροπή PPT, PPTX και ODP σε υψηλής ποιότητας, PDF σύμφωνα με WCAG, με Python και Aspose.Slides - περιλαμβάνει προστασία με κωδικό, επιλογή διαφανειών και έλεγχο ποιότητας εικόνας."
showReadingTime: true
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP) σε μορφή PDF με την Python προσφέρει αρκετά πλεονεκτήματα, συμπεριλαμβανομένης της διασφάλισης συμβατότητας μεταξύ διαφορετικών συσκευών και της διατήρησης της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για τον έλεγχο της ποιότητας των εικόνων, να συμπεριλάβετε κρυφές διαφάνειες, να προστατεύσετε με κωδικό πρόσβασης τα PDF, να ανιχνεύσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **Μετατροπές PowerPoint σε PDF**

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF με την Python, αρκεί να περάσετε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/) και έπειτα να αποθηκεύσετε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [Save](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/#methods). Η κλάση [Presentation](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/) εκθέτει τη μέθοδο [Save](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/#methods) που χρησιμοποιείται τυπικά για τη μετατροπή μιας παρουσίασης σε PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Το Aspose.Slides για Python καταγράφει απευθείας πληροφορίες API και αριθμό έκδοσης στα έγγραφα εξόδου. Για παράδειγμα, όταν μετατρέπει μια παρουσίαση σε PDF, το Aspose.Slides για Python γεμίζει το πεδίο Εφαρμογή με την τιμή '*Aspose.Slides*' και το πεδίο PDF Producer με τιμή της μορφής '*Aspose.Slides v XX.XX*'. **Σημείωση** ότι δεν μπορείτε να ζητήσετε από το Aspose.Slides για Python να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα έγγραφα εξόδου.

{{% /alert %}}

Aspose.Slides επιτρέπει τη μετατροπή:

* Ολόκληρων παρουσιάσεων σε PDF
* Συγκεκριμένων διαφανειών σε παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα περιεχόμενα των παραγόμενων PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και οι ιδιότητες αποδίδονται με ακρίβεια στη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφων
* Υπερσυνδέσεις
* Κεφαλίδες και υποσέλιδα
* Κουκκίδες
* Πίνακες

## **Μετατροπή PowerPoint σε PDF**

Η τυπική λειτουργία μετατροπής PowerPoint σε PDF εκτελείται με προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις σε μέγιστα επίπεδα ποιότητας. Αυτός ο κώδικας Python σας δείχνει πώς να μετατρέψετε ένα PowerPoint σε PDF:

_Βήματα: Μετατροπές PowerPoint σε PDF με Python_

- <a name="python-net-powerpoint-to-pdf"><strong>Βήματα: Μετατροπή PowerPoint σε PDF χρησιμοποιώντας Python μέσω .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Βήματα: Μετατροπή PPT σε PDF χρησιμοποιώντας Python μέσω .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Βήματα: Μετατροπή PPTX σε PDF χρησιμοποιώντας Python μέσω .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Βήματα: Μετατροπή ODP σε PDF χρησιμοποιώντας Python μέσω .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Βήματα: Μετατροπή PPS σε PDF χρησιμοποιώντας Python μέσω .NET</a></strong>

_Βήματα κώδικα:_

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και δώστε της το αρχείο PowerPoint.
  * _.ppt_ επέκταση για φόρτωση αρχείου **PPT** μέσα στην κλάση _Presentation_.
  * _.pptx_ επέκταση για φόρτωση αρχείου **PPTX** μέσα στην κλάση _Presentation_.
  * _.odp_ επέκταση για φόρτωση αρχείου **ODP** μέσα στην κλάση _Presentation_.
  * _.pps_ επέκταση για φόρτωση αρχείου **PPS** μέσα στην κλάση _Presentation_.
- Αποθηκεύστε το _Presentation_ σε μορφή **PDF** καλώντας τη μέθοδο **Save** και χρησιμοποιώντας την απαρίθμηση **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Αποθηκεύει την παρουσίαση ως PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Η Aspose παρέχει έναν δωρεάν διαδικτυακό **μετατροπέα PowerPoint σε PDF** που δείχνει τη διαδικασία μετατροπής παρουσίασης σε PDF. Για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ, μπορείτε να κάνετε δοκιμή με τον μετατροπέα.

{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές — ιδιότητες στην κλάση [PdfOptions](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides.export/pdfoptions/) — που σας επιτρέπουν να προσαρμόσετε το PDF (που προκύπτει από τη διαδικασία μετατροπής), να κλειδώσετε το PDF με κωδικό πρόσβασης ή ακόμη και να ορίσετε πώς θα εκτελεστεί η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για raster εικόνες, να καθορίσετε πώς θα διαχειρίζονται τα metafile, να θέσετε επίπεδο συμπίεσης για κείμενα, να ορίσετε DPI για εικόνες κ.λπ.

Το παρακάτω παράδειγμα κώδικα δείχνει μια λειτουργία όπου μια παρουσίαση PowerPoint μετατρέπεται σε PDF με πολλές προσαρμοσμένες επιλογές:

```python
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο της κλάσης PdfOptions
pdf_options = slides.export.PdfOptions()

# Ορίζει την ποιότητα για εικόνες JPG
pdf_options.jpeg_quality = 90

# Ορίζει το DPI για εικόνες
pdf_options.sufficient_resolution = 300

# Ορίζει τη συμπεριφορά για metafiles
pdf_options.save_metafiles_as_png = True

# Ορίζει το επίπεδο συμπίεσης κειμένου για το κειμενικό περιεχόμενο
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Ορίζει τη λειτουργία συμμόρφωσης PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Δημιουργεί ένα αντικείμενο κλάσης Presentation που αντιπροσωπεύει ένα έγγραφο PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Αποθηκεύει την παρουσίαση ως έγγραφο PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε μια προσαρμοσμένη επιλογή — την ιδιότητα `show_hidden_slides` από την κλάση [PdfOptions](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides.export/pdfoptions/) — για να υποδείξετε στο Aspose.Slides να συμπεριλάβει τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

Αυτός ο κώδικας Python σας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PDF με τις κρυφές διαφάνειες να συμπεριλαμβάνονται:

```python
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Δημιουργεί ένα αντικείμενο κλάσης PdfOptions
pdfOptions = slides.export.PdfOptions()

# Προσθέτει κρυφές διαφάνειες
pdfOptions.show_hidden_slides = True

# Αποθηκεύει την παρουσίαση ως PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Μετατροπή PowerPoint σε PDF με Προστασία Κωδικού**

Αυτός ο κώδικας Python σας δείχνει πώς να μετατρέψετε ένα PowerPoint σε PDF με προστασία κωδικού (χρησιμοποιώντας παραμέτρους προστασίας από την κλάση [PdfOptions](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Δημιουργεί το αντικείμενο της κλάσης PdfOptions
pdfOptions = slides.export.PdfOptions()

# Ορίζει κωδικό πρόσβασης PDF και δικαιώματα πρόσβασης
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Αποθηκεύει την παρουσίαση ως PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Μετατροπή Επιλεγμένων Διαφανειών σε PowerPoint σε PDF**

Αυτός ο κώδικας Python σας δείχνει πώς να μετατρέψετε συγκεκριμένες διαφάνειες σε μια παρουσίαση PowerPoint σε PDF:

```python
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Ορίζει έναν πίνακα με θέσεις διαφανειών
slides_array = [ 1, 3 ]

# Αποθηκεύει την παρουσίαση ως PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένο Μέγεθος Διαφάνειας**

Αυτός ο κώδικας Python σας δείχνει πώς να μετατρέψετε ένα PowerPoint όταν το μέγεθος της διαφάνειας του έχει καθοριστεί σε PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Δημιουργεί το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint ή OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Δημιουργεί μια νέα παρουσίαση με προσαρμοσμένο μέγεθος διαφάνειας.
    with slides.Presentation() as resized_presentation:

        # Ορίζει το προσαρμοσμένο μέγεθος διαφάνειας.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Αντιγράφει την πρώτη διαφάνεια από την αρχική παρουσίαση.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Αποθηκεύει τη μετασχηματισμένη παρουσίαση σε PDF με σημειώσεις.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Μετατροπή PowerPoint σε PDF σε Προβολή Σημειώσεων Διαφάνειας**

Αυτός ο κώδικας Python σας δείχνει πώς να μετατρέψετε ένα PowerPoint σε PDF σημειώσεων:

```python
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Αποθηκεύει την παρουσίαση σε PDF με σημειώσεις
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Πρότυπα Προσβασιμότητας και Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Οδηγίες Πρόσβασης σε Περιεχόμενο ιστού (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιαδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b**, και **PDF/UA**.

Αυτός ο κώδικας Python δείχνει μια λειτουργία μετατροπής PowerPoint σε PDF στην οποία λαμβάνονται πολλαπλά PDF με βάση διαφορετικά πρότυπα συμμόρφωσης:

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

Η υποστήριξη του Aspose.Slides για λειτουργίες μετατροπής PDF επεκτείνεται ώστε να επιτρέπει τη μετατροπή του PDF στις πιο δημοφιλείς μορφές αρχείων. Μπορείτε να κάνετε μετατροπές [PDF σε HTML](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-html/), [PDF σε εικόνα](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-png/) μετατροπές. Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές — [PDF σε SVG](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-xml/) — υποστηρίζονται επίσης.

{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει σύνθετα γραφικά όπως SmartArt, διαγράμματα και τύπους ως μία ενιαία μορφή. Τα μεμονωμένα στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να σημειωθούν ως τεχνικά υπολείμματα· εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρη τη μορφή.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides για Python να αφαιρέσει τις πληροφορίες της εφαρμογής από το PDF;**

Όχι, το Aspose.Slides για Python συμπεριλαμβάνει αυτόματα τις πληροφορίες API και τον αριθμό έκδοσης στο παραγόμενο PDF. Αυτές οι πληροφορίες δεν μπορούν να τροποποιηθούν ή να αφαιρεθούν.

**Πώς μπορώ να συμπεριλάβω μόνο συγκεκριμένες διαφάνειες στη μετατροπή PDF;**

Μπορείτε να καθορίσετε τις θέσεις των διαφανειών που θέλετε να μετατρέψετε περνώντας έναν πίνακα με τις θέσεις των διαφανειών στη μέθοδο `save`.

**Μπορεί να προστατευτεί το PDF με κωδικό πρόσβασης κατά τη μετατροπή;**

Ναι, μπορείτε να ορίσετε κωδικό πρόσβασης και να καθορίσετε δικαιώματα πρόσβασης χρησιμοποιώντας την κλάση `PdfOptions` πριν αποθηκεύσετε την παρουσίαση ως PDF.

**Το Aspose.Slides υποστηρίζει τη μετατροπή PDF σε άλλες μορφές;**

Ναι, το Aspose.Slides υποστηρίζει τη μετατροπή PDF σε μορφές όπως HTML, μορφές εικόνας (JPG, PNG), SVG, TIFF και XML.

**Πώς μπορώ να διασφαλίσω ότι το PDF μου συμμορφώνεται με πρότυπα προσβασιμότητας;**

Ορίστε την ιδιότητα `compliance` στην `PdfOptions` σε πρότυπα όπως `PDF_A1A`, `PDF_A1B` ή `PDF_UA` για να εξασφαλίσετε τη συμμόρφωση με τις οδηγίες προσβασιμότητας.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στο τελικό PDF;**

Ναι, ορίζοντας την ιδιότητα `show_hidden_slides` στην `PdfOptions` σε `True`, οι κρυφές διαφάνειες θα συμπεριληφθούν στο PDF.

**Πώς μπορώ να ρυθμίσω την ποιότητα και την ανάλυση των εικόνων κατά τη μετατροπή;**

Χρησιμοποιήστε τις ιδιότητες `jpeg_quality` και `sufficient_resolution` στην `PdfOptions` για να ελέγξετε την ποιότητα και την ανάλυση των εικόνων στο παραγόμενο PDF.

**Το Aspose.Slides διαχειρίζεται αυτόματα τις αντικαταστάσεις γραμματοσειρών;**

Το Aspose.Slides εντοπίζει αντικαταστάσεις γραμματοσειρών κατά τη μετατροπή, και μπορείτε να τις χειριστείτε χρησιμοποιώντας την ιδιότητα `warning_callback` στην `SaveOptions` (επί του παρόντος περιορισμένη).

## **Πρόσθετοι Πόροι**

- [Τεκμηρίωση Aspose.Slides για .NET](https://docs.aspose.com/slides/el/python-net/)
- [Αναφορά API Aspose.Slides](https://reference.aspose.com/slides/el/python-net/)
- [Δωρεάν διαδικτυακοί μετατροπείς Aspose](https://products.aspose.app/slides/el/conversion)