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
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - Python
  - Aspose.Slides for Python
description: "Οδηγός βήμα‑βήμα για τη μετατροπή των PPT, PPTX και ODP σε PDF υψηλής ποιότητας, συμβατά με WCAG, με Python και Aspose.Slides—περιλαμβάνει προστασία με κωδικό, επιλογή διαφανειών και έλεγχο ποιότητας εικόνας."
showReadingTime: true
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP) σε μορφή PDF με Python προσφέρει πολλά πλεονεκτήματα, όπως η εξασφάλιση συμβατότητας σε διαφορετικές συσκευές και η διατήρηση της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για τον έλεγχο της ποιότητας των εικόνων, να συμπεριλάβετε κρυφές διαφάνειες, να προστατεύσετε με κωδικό τα έγγραφα PDF, να ανιχνεύσετε αντικαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **Εγκατάσταση**

```bash
pip install aspose.slides
```

Το πακέτο περιλαμβάνει το runtime που χρειάζεται, ώστε το Microsoft PowerPoint δεν χρειάζεται να είναι εγκατεστημένο στο μηχάνημα που εκτελεί τη μετατροπή.

## **Μετατροπές PowerPoint σε PDF**

Χρησιμοποιώντας Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις σε αυτές τις μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF με Python, αρκεί να περάσετε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/) και στη συνέχεια να αποθηκεύσετε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [Save](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/#methods). Η κλάση [Presentation](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/) εκθέτει τη μέθοδο [Save](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides/presentation/#methods) που χρησιμοποιείται τυπικά για τη μετατροπή μιας παρουσίασης σε PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Το Aspose.Slides for Python γράφει απευθείας πληροφορίες API και αριθμό έκδοσης στα παραγόμενα έγγραφα. Για παράδειγμα, όταν μετατρέπει μια παρουσίαση σε PDF, το Aspose.Slides for Python συμπληρώνει το πεδίο Application με την τιμή '*Aspose.Slides*' και το πεδίο PDF Producer με μια τιμή στη μορφή '*Aspose.Slides v XX.XX*'. **Σημείωση** ότι δεν μπορείτε να υποδείξετε στο Aspose.Slides for Python να αλλάξει ή να αφαιρέσει αυτή την πληροφορία από τα παραγόμενα έγγραφα.

{{% /alert %}}

Το Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες σε μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, εξασφαλίζοντας ότι τα περιεχόμενα των παραγόμενων PDF ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και οι ιδιότητες αποδίδονται με ακρίβεια κατά τη μετατροπή, συμπεριλαμβανομένων:

* Εικόνων
* Πλαισίων κειμένου και σχημάτων
* Μορφοποίησης κειμένου
* Μορφοποίησης παραγράφων
* Υπερσυνδέσμων
* Κεφαλίδων και υποσέλιδων
* Κουκκίδων
* Πινάκων

## **Μετατροπή PowerPoint σε PDF**

Η τυπική λειτουργία μετατροπής PowerPoint σε PDF εκτελείται χρησιμοποιώντας τις προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις με μέγιστη ποιότητα. Αυτός ο κώδικας Python δείχνει πώς να μετατρέψετε ένα PowerPoint σε PDF:

_Βήματα: Μετατροπές PowerPoint σε PDF με Python_

Ο παρακάτω παραδειγματικός κώδικας εξηγεί αυτές τις μετατροπές χρησιμοποιώντας Python μέσω .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Βήματα: Μετατροπή PowerPoint σε PDF χρησιμοποιώντας Python μέσω .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Βήματα: Μετατροπή PPT σε PDF χρησιμοποιώντας Python μέσω .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Βήματα: Μετατροπή PPTX σε PDF χρησιμοποιώντας Python μέσω .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Βήματα: Μετατροπή ODP σε PDF χρησιμοποιώντας Python μέσω .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Βήματα: Μετατροπή PPS σε PDF χρησιμοποιώντας Python μέσω .NET</a></strong>

_Code Steps:_

- Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και δώστε του το αρχείο PowerPoint.
  * _.ppt_ επέκταση για φόρτωση αρχείου **PPT** στην κλάση _Presentation_.
  * _.pptx_ επέκταση για φόρτωση αρχείου **PPTX** στην κλάση _Presentation_.
  * _.odp_ επέκταση για φόρτωση αρχείου **ODP** στην κλάση _Presentation_.
  * _.pps_ επέκταση για φόρτωση αρχείου **PPS** στην κλάση _Presentation_.
- Αποθηκεύστε την _Presentation_ σε μορφή **PDF** καλώντας τη μέθοδο **Save** και χρησιμοποιώντας την απαρίθμηση **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Αποθηκεύει την παρουσίαση ως PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Το Aspose προσφέρει ένα δωρεάν διαδικτυακό [**PowerPoint to PDF converter**](https://products.aspose.app/slides/el/conversion/ppt-to-pdf) που επιδεικνύει τη διαδικασία μετατροπής παρουσίασης σε PDF. Για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ, μπορείτε να κάνετε δοκιμή με τον μετατροπέα.

{{% /alert %}}

## **Μετατροπή PowerPoint σε PDF με Επιλογές**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές—ιδιότητες στην κλάση [PdfOptions](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides.export/pdfoptions/)—που σας επιτρέπουν να προσαρμόσετε το PDF (που προκύπτει από τη διαδικασία μετατροπής), να κλειδώσετε το PDF με κωδικό ή ακόμη και να ορίσετε πώς πρέπει να εκτελείται η διαδικασία μετατροπής.

### **Μετατροπή PowerPoint σε PDF με Προσαρμοσμένες Επιλογές**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για raster εικόνες, να καθορίσετε πώς πρέπει να διαχειριστούν τα metafiles, να θέσετε επίπεδο συμπίεσης για κείμενα, DPI για εικόνες κ.λπ.

Ο παρακάτω κώδικας δείχνει μια λειτουργία στην οποία μια παρουσίαση PowerPoint μετατρέπεται σε PDF με πολλές προσαρμοσμένες επιλογές:

```python
import aspose.slides as slides

# Δημιουργεί ένα αντικείμενο της κλάσης PdfOptions
pdf_options = slides.export.PdfOptions()

# Ορίζει την ποιότητα για εικόνες JPG
pdf_options.jpeg_quality = 90

# Ορίζει DPI για εικόνες
pdf_options.sufficient_resolution = 300

# Ορίζει τη συμπεριφορά για metafiles
pdf_options.save_metafiles_as_png = True

# Ορίζει το επίπεδο συμπίεσης κειμένου για το κειμενικό περιεχόμενο
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Καθορίζει τη λειτουργία συμμόρφωσης PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Δημιουργεί ένα αντικείμενο κλάσης Presentation που αντιπροσωπεύει ένα έγγραφο PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Αποθηκεύει την παρουσίαση ως έγγραφο PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Μετατροπή PowerPoint σε PDF με Κρυφές Διαφάνειες**

Εάν μια παρουσίαση περιέχει κρυφές διαφάνειες, μπορείτε να χρησιμοποιήσετε την προσαρμοσμένη επιλογή—την ιδιότητα `show_hidden_slides` από την κλάση [PdfOptions](https://docs.aspose.com/slides/el/python-net/api-reference/aspose.slides.export/pdfoptions/)—για να υποδείξετε στο Aspose.Slides να συμπεριλάβει τις κρυφές διαφάνειες ως σελίδες στο παραγόμενο PDF.

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

Αυτός ο κώδικας Python δείχνει πώς να μετατρέψετε ένα PowerPoint όταν το μέγεθος της διαφάνειας του έχει οριστεί σε PDF:

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

        # Κλωνοποιεί την πρώτη διαφάνεια από την αρχική παρουσίαση και αφαιρεί την προεπιλεγμένη κενή διαφάνεια.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # Αποθηκεύει την επαναρρυθμισμένη παρουσίαση σε PDF.
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Μετατροπή PowerPoint σε PDF στην Προβολή Στόχων Διαφάνειας**

Αυτός ο κώδικας Python δείχνει πώς να μετατρέψετε ένα PowerPoint σε PDF με σημειώσεις διαφάνειας:

```python
import aspose.slides as slides

# Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

# Ρυθμίζει τις επιλογές PDF με τη διάταξη σημειώσεων
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Αποθηκεύει την παρουσίαση σε PDF με σημειώσεις
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Πρόσβαση και Πρότυπα Συμμόρφωσης για PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Οδηγίες Προσβασιμότητας Περιεχομένου Ιστού (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από τα παρακάτω πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b**, και **PDF/UA**.

Αυτός ο κώδικας Python παρουσιάζει μια λειτουργία μετατροπής PowerPoint σε PDF στην οποία παραλαμβάνονται πολλαπλά PDF με διαφορετικά πρότυπα συμμόρφωσης:

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

Η υποστήριξη του Aspose.Slides για λειτουργίες μετατροπής PDF επεκτείνεται ώστε να σας επιτρέπει να μετατρέψετε PDF στα πιο δημοφιλή μορφότυπα αρχείων. Μπορείτε να κάνετε μετατροπές [PDF σε HTML](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-html/), [PDF σε εικόνα](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-png/). Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές—[PDF σε SVG](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/el/python-net/conversion/pdf-to-xml/)—επίσης υποστηρίζονται.

{{% /alert %}}

> **Σημείωση:** Κατά την εξαγωγή σε PDF/UA, το Aspose.Slides αντιμετωπίζει σύνθετα γραφικά όπως SmartArt, διαγράμματα και τύπους ως μία ενιαία μορφή. Τα επιμέρους στοιχεία διαδρομής δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως τεχνούργημα· το εναλλακτικό κείμενο παρέχεται μόνο για ολόκληρη τη μορφή.

## **FAQ**

### Μπορεί το Aspose.Slides for Python να αφαιρέσει τις πληροφορίες εφαρμογής από το PDF;

Όχι, το Aspose.Slides for Python προσθέτει αυτόματα πληροφορίες API και αριθμό έκδοσης στο παραγόμενο PDF. Αυτές οι πληροφορίες δεν μπορούν να τροποποιηθούν ή να αφαιρεθούν.

### Πώς μπορώ να συμπεριλάβω μόνο συγκεκριμένες διαφάνειες στη μετατροπή PDF;

Μπορείτε να καθορίσετε τα ευρετήρια διαφανειών που θέλετε να μετατρέψετε περνώντας έναν πίνακα θέσεων διαφάνειας στη μέθοδο `save`.

### Είναι δυνατόν να προστατεύσω με κωδικό το PDF κατά τη μετατροπή;

Ναι, μπορείτε να ορίσετε κωδικό πρόσβασης και να ορίσετε δικαιώματα πρόσβασης χρησιμοποιώντας την κλάση `PdfOptions` πριν αποθηκεύσετε την παρουσίαση ως PDF.

### Υποστηρίζει το Aspose.Slides τη μετατροπή PDF σε άλλα μορφότυπα;

Ναι, το Aspose.Slides υποστηρίζει τη μετατροπή PDF σε μορφότυπα όπως HTML, εικόνες (JPG, PNG), SVG, TIFF και XML.

### Πώς μπορώ να διασφαλίσω ότι το PDF μου συμμορφώνεται με πρότυπα προσβασιμότητας;

Ορίστε την ιδιότητα `compliance` στην `PdfOptions` σε πρότυπα όπως `PDF_A1A`, `PDF_A1B` ή `PDF_UA` για να εξασφαλίσετε συμμόρφωση με τις οδηγίες προσβασιμότητας.

### Μπορώ να συμπεριλάβω κρυφές διαφάνειες στο παραγόμενο PDF;

Ναι, ορίζοντας την ιδιότητα `show_hidden_slides` στην `PdfOptions` σε `True`, οι κρυφές διαφάνειες θα συμπεριληφθούν στο PDF.

### Πώς ρυθμίζω την ποιότητα και την ανάλυση εικόνας κατά τη μετατροπή;

Χρησιμοποιήστε τις ιδιότητες `jpeg_quality` και `sufficient_resolution` στην `PdfOptions` για να ελέγξετε την ποιότητα και την ανάλυση των εικόνων στο παραγόμενο PDF.

### Το Aspose.Slides διαχειρίζεται αυτόματα τις αντικαταστάσεις γραμματοσειρών;

Το Aspose.Slides εντοπίζει τις αντικαταστάσεις γραμματοσειρών κατά τη μετατροπή και μπορείτε να τις διαχειριστείτε μέσω της ιδιότητας `warning_callback` στην `SaveOptions` (προς το παρόν περιορισμένη).

## **Πρόσθετοι Πόροι**

- [Aspose.Slides for .NET Documentation](https://docs.aspose.com/slides/el/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/el/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/el/conversion)