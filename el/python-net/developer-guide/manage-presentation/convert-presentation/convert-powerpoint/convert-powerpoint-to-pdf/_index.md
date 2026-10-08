---
title: "Μετατροπή PPT & PPTX σε PDF με Python | Προηγμένες επιλογές"
linktitle: "PowerPoint σε PDF"
type: docs
weight: 40
url: /el/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- "μετατροπή PowerPoint"
- "παρουσίαση"
- "PowerPoint σε PDF"
- "PPT σε PDF"
- "PPTX σε PDF"
- "αποθήκευση PowerPoint ως PDF"
- "συνημμένο"
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- "Aspose.Slides for Python"
description: "Οδηγός βήμα‑βήμα για τη μετατροπή PPT, PPTX και ODP σε PDFs υψηλής ποιότητας, συμβατών με WCAG, με Python και Aspose.Slides—περιλαμβάνει προστασία με κωδικό, επιλογή διαφανειών και έλεγχο ποιότητας εικόνας."
showReadingTime: true
---
## **Επισκόπηση**

Η μετατροπή παρουσιάσεων PowerPoint (PPT, PPTX, ODP) σε μορφή PDF με Python προσφέρει αρκετά πλεονεκτήματα, συμπεριλαμβανομένης της εξασφάλισης συμβατότητας μεταξύ διαφορετικών συσκευών και της διατήρησης της διάταξης και της μορφοποίησης της παρουσίασής σας. Αυτός ο οδηγός δείχνει πώς να μετατρέψετε παρουσιάσεις σε έγγραφα PDF, να χρησιμοποιήσετε διάφορες επιλογές για έλεγχο της ποιότητας εικόνας, να συμπεριλάβετε κρυμμένες διαφάνειες, να προστατέψετε με κωδικό πρόσβασης τα έγγραφα PDF, να εντοπίσετε υποκαταστάσεις γραμματοσειρών, να επιλέξετε συγκεκριμένες διαφάνειες για μετατροπή και να εφαρμόσετε πρότυπα συμμόρφωσης στα παραγόμενα έγγραφα.

## **PowerPoint to PDF Conversions**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να μετατρέψετε παρουσιάσεις σε αυτές τις μορφές σε PDF:

* **PPT**
* **PPTX**
* **ODP**

Για να μετατρέψετε μια παρουσίαση σε PDF με Python, αρκεί να περάσετε το όνομα του αρχείου ως όρισμα στην κλάση [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) και στη συνέχεια να αποθηκεύσετε την παρουσίαση ως PDF χρησιμοποιώντας τη μέθοδο [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Η κλάση [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) εκθέτει τη μέθοδο [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) η οποία χρησιμοποιείται συνήθως για τη μετατροπή μιας παρουσίασης σε PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides για Python εισάγει τις πληροφορίες API του και τον αριθμό έκδοσης στα παραγόμενα έγγραφα. Για παράδειγμα, όταν μετατρέπει μια παρουσίαση σε PDF, το Aspose.Slides για Python γεμίζει το πεδίο Application με την τιμή '*Aspose.Slides*' και το πεδίο PDF Producer με τιμή σε μορφή '*Aspose.Slides v XX.XX*'. **Note** ότι δεν μπορείτε να υποδείξετε στο Aspose.Slides για Python να αλλάξει ή να αφαιρέσει αυτές τις πληροφορίες από τα παραγόμενα έγγραφα.
{{% /alert %}}

Aspose.Slides σας επιτρέπει να μετατρέψετε:

* Ολόκληρες παρουσιάσεις σε PDF
* Συγκεκριμένες διαφάνειες σε μια παρουσίαση σε PDF

Το Aspose.Slides εξάγει παρουσιάσεις σε PDF, διασφαλίζοντας ότι τα περιεχόμενα των προκύπτοντων PDFs ταιριάζουν στενά με τις αρχικές παρουσιάσεις. Τα στοιχεία και οι ιδιότητες αποδίδονται ακρίβεια κατά τη μετατροπή, συμπεριλαμβανομένων:

* Εικόνες
* Πλαίσια κειμένου και σχήματα
* Μορφοποίηση κειμένου
* Μορφοποίηση παραγράφου
* Υπερσυνδέσμους
* Κεφαλίδες και υποσέλιδα
* Κουκκίδες
* Πίνακες

## **Convert PowerPoint to PDF**

Η τυπική διαδικασία μετατροπής PowerPoint‑to‑PDF χρησιμοποιεί τις προεπιλεγμένες επιλογές. Σε αυτήν την περίπτωση, το Aspose.Slides προσπαθεί να μετατρέψει την παρεχόμενη παρουσίαση σε PDF χρησιμοποιώντας βέλτιστες ρυθμίσεις στα μέγιστα επίπεδα ποιότητας.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση και αποθηκεύει όλες τις ορατές διαφάνειες σε PDF χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις εξαγωγής.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose παρέχει έναν δωρεάν διαδικτυακό [**Μετατροπέας PowerPoint σε PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) που δείχνει τη διαδικασία μετατροπής παρουσίασης σε PDF. Για μια ζωντανή υλοποίηση της διαδικασίας που περιγράφεται εδώ, μπορείτε να κάνετε ένα τεστ με το μετατροπέα.
{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Το Aspose.Slides παρέχει προσαρμοσμένες επιλογές—ιδιότητες κάτω από την κλάση [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—που σας επιτρέπουν να προσαρμόσετε το PDF (που προκύπτει από τη διαδικασία μετατροπής), να κλειδώσετε το PDF με κωδικό πρόσβασης ή ακόμη και να καθορίσετε πώς πρέπει να εκτελείται η διαδικασία μετατροπής.

### **Convert PowerPoint to PDF with Custom Options**

Χρησιμοποιώντας προσαρμοσμένες επιλογές μετατροπής, μπορείτε να ορίσετε την προτιμώμενη ρύθμιση ποιότητας για raster εικόνες, να καθορίσετε πώς θα αντιμετωπίζονται τα metafiles, να ορίσετε επίπεδο συμπίεσης για το κείμενο, να ορίσετε DPI για τις εικόνες κ.λπ.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF 1.5 με ποιότητα JPEG 90, ανάλυση εικόνας 300 DPI, metafiles αποθηκευμένα ως PNG και συμπίεση κειμένου Flate.

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

### **Preserve Embedded OLE Files as PDF Attachments**

Εάν μια παρουσίαση περιέχει ενσωματωμένο βιβλίο εργασίας Excel, μπορεί να θέλετε οι παραλήπτες του PDF να έχουν πρόσβαση στα δεδομένα του βιβλίου εργασίας καθώς και να βλέπουν τις διαφάνειες. Ορίστε το [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) σε `True` για να διατηρήσετε τα ενσωματωμένα αρχεία OLE ως συνημμένα στο παραγόμενο PDF.

Η προεπιλεγμένη τιμή είναι `False`: η εικόνα προεπισκόπησης ή το εικονίδιο του αντικειμένου OLE αποδίδεται στη σελίδα PDF, αλλά το ενσωματωμένο αρχείο δεν περιλαμβάνεται ως συνημμένο. Ορίζοντας την επιλογή σε `True` περιλαμβάνει επιπλέον τα δεδομένα του αρχείου. Η προεπισκόπηση παραμένει οπτική αναπαράσταση· το συνημμένο επιτρέπει στους παραλήπτες να ανοίξουν ή να αποθηκεύσουν το ενσωματωμένο αρχείο ξεχωριστά. Το αντικείμενο OLE δεν μετατρέπεται σε διαδραστικό φύλλο Excel στη σελίδα PDF.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση που ήδη περιέχει ενσωματωμένο βιβλίο εργασίας Excel και την εξάγει σε PDF με το βιβλίο εργασίας προσαρτημένο.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Για να ελέγξετε το αποτέλεσμα:

1. Ανοίξτε το εξαγόμενο PDF σε προβολή που υποστηρίζει συνημμένα αρχεία, όπως το Adobe Acrobat Reader.
2. Ανοίξτε το πάνελ **Attachments** του προγράμματος προβολής και εντοπίστε το ενσωματωμένο βιβλίο εργασίας.
3. Αποθηκεύστε το συνημμένο και ανοίξτε το στο Excel για να ελέγξετε τα δεδομένα του, ή ανοίξτε το απευθείας αν το πρόγραμμα προβολής το επιτρέπει. Η προεπισκόπηση στη σελίδα PDF είναι ξεχωριστή από το συνημμένο.

{{% alert color="info" title="Note" %}}
Τα πρότυπα PDF/A επιβάλλουν περιορισμούς στα συνημμένα: το PDF/A‑1 απαγορεύει ενσωματωμένα αρχεία, το PDF/A‑2 επιτρέπει μόνο συνημμένα PDF/A, και το PDF/A‑3 επιτρέπει άλλους τύπους αρχείων, συμπεριλαμβανομένων βιβλίων εργασίας Excel. Αυτές είναι απαιτήσεις των προτύπων, όχι περιορισμοί ειδικοί του Aspose.Slides. Αυτό το παράδειγμα χρησιμοποιεί την προεπιλεγμένη ρύθμιση συμμόρφωσης PDF και δεν δείχνει εξαγώγιση PDF/A.
{{% /alert %}}

### **Convert PowerPoint to PDF with Hidden Slides**

Εάν μια παρουσίαση περιέχει κρυμμένες διαφάνειες, μπορείτε να χρησιμοποιήσετε μια προσαρμοσμένη επιλογή—την ιδιότητα [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) από την κλάση [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—για να υποδείξετε στο Aspose.Slides να συμπεριλάβει τις κρυμμένες διαφάνειες ως σελίδες στο παραγόμενο PDF.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF, συμπεριλαμβανομένων τυχόν κρυμμένων διαφανειών.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Convert PowerPoint to a Password-Protected PDF**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF που απαιτεί τον κωδικό `password` για να ανοίξει. Οι άδειες πρόσβασης επιτρέπουν εκτύπωση, συμπεριλαμβανομένης της εκτύπωσης υψηλής ποιότητας.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Handle Fonts Without a Dedicated Bold Typeface**

Μια παρουσίαση μπορεί να εφαρμόσει έντονη μορφοποίηση σε κείμενο ακόμα και όταν η γραμματοσειρά της δεν διαθέτει αφιερωμένη έντονη γραμματοσειρά. Το κείμενο μπορεί να εμφανίζεται έντονο μέσω συνθετικής έντονης γραφής, η οποία παχύνει τεχνητά τα κανονικά γλύφους. Όταν αυτό το κείμενο φαίνεται πολύ βαρύ ή διαφορετικό από το επιθυμητό στην PDF, δοκιμάστε να ορίσετε το [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) σε `True`. Αυτή η επιλογή αποδίδει το επηρεασμένο κείμενο ως bitmap κατά την εξαγωγή PDF και μπορεί να βελτιώσει την εμφάνισή του για ορισμένες γραμματοσειρές. Η προεπιλεγμένη τιμή είναι `False`.

Η δείγμα παρουσίαση περιέχει δύο πλαίσια κειμένου: ένα με κανονικό κείμενο και ένα με έντονη μορφοποίηση στην ίδια γραμματοσειρά, η οποία δεν διαθέτει αφιερωμένη έντονη γραμματοσειρά. Το παρακάτω παράδειγμα φορτώνει την παρουσίαση, ενεργοποιεί τη rasterization των μη υποστηριζόμενων στυλ γραμματοσειράς και την εξάγει σε PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Οι παρακάτω προεπισκοπήσεις δείχνουν την έξοδο με την επιλογή απενεργοποιημένη και ενεργοποιημένη. Σε αυτό το παράδειγμα, το έντονο κείμενο έχει πιο παχιές γραμμές με την επιλογή απενεργοποιημένη. Με την επιλογή ενεργοποιημένη, οι γραμμές του είναι πιο ελαφριές· το κανονικό κείμενο παραμένει αμετάβλητο. Συγκρίνετε τα αποτελέσματα πριν επιλέξετε τη ρύθμιση για την παρουσίασή σας.

| Option disabled (`False`, the default) | Option enabled (`True`) |
|---|---|
| ![PDF με απενεργοποιημένη rasterization μη υποστηριζόμενου στυλ γραμματοσειράς](unsupported-bold-disabled.png) | ![PDF με ενεργοποιημένη rasterization μη υποστηριζόμενου στυλ γραμματοσειράς](unsupported-bold-enabled.png) |

Σε αυτό το παράδειγμα, η ενεργοποίηση της επιλογής μετατρέπει μόνο το έντονο κείμενο σε bitmap: δεν μπορεί να επιλεγεί, αντιγραφεί ή αναζητηθεί ως κείμενο χωρίς OCR, και οι άκρες του φαίνονται πιο απαλές σε ζουμ 800 %. Το κανονικό κείμενο παραμένει αναζητήσιμο. Με την επιλογή απενεργοποιημένη, και τα δύο κείμενα παραμένουν κείμενο.

Αυτή η επιλογή rasterizes κείμενο μορφοποιημένο ως έντονο όταν η γραμματοσειρά του δεν έχει αφιερωμένη έντονη γραμματοσειρά. Η [Αντικατάσταση γραμματοσειράς](/slides/el/python-net/font-substitution/) επιλέγει εναλλακτική γραμματοσειρά όταν η αρχική δεν είναι διαθέσιμη.

## **Convert Selected Slides in PowerPoint to PDF**

Το παρακάτω παράδειγμα εξάγει τις διαφάνειες 1 και 3 από μια παρουσίαση σε PDF. Οι αριθμοί διαφανειών σε αυτόν τον πίνακα είναι 1‑βασισμένοι και η είσοδος παρουσίασης πρέπει να περιέχει τουλάχιστον τρεις διαφάνειες.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Convert PowerPoint to PDF with Custom Slide Size**

Το παρακάτω παράδειγμα αντιγράφει την πρώτη διαφάνεια από μια παρουσίαση σε μια νέα παρουσίαση με μέγεθος διαφάνειας 612 × 792 points (8,5 × 11 ίντσες). Κλιμακώνει το περιεχόμενο της διαφάνειας ώστε να ταιριάζει και εξάγει τη μοναδική διαφάνεια σε PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Καταργήστε τη κενή διαφάνεια που δημιουργήθηκε με τη νέα παρουσίαση.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Convert PowerPoint to PDF in Notes Slide View**

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση σε PDF, τοποθετώντας τις σημειώσεις του ομιλητή κάτω από κάθε διαφάνεια. Χρησιμοποιήστε μια παρουσίαση που περιέχει σημειώσεις ομιλητή για να δείτε το αποτέλεσμα.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Accessibility and Compliance Standards for PDF**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε μια διαδικασία μετατροπής που συμμορφώνεται με τις [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Μπορείτε να εξάγετε ένα έγγραφο PowerPoint σε PDF χρησιμοποιώντας οποιοδήποτε από αυτά τα πρότυπα συμμόρφωσης: **PDF/A1a**, **PDF/A1b**, και **PDF/UA**.

Αυτός ο κώδικας Python δείχνει μια λειτουργία μετατροπής PowerPoint σε PDF στην οποία λαμβάνονται πολλαπλά PDFs με διαφορετικά πρότυπα συμμόρφωσης:

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
Η υποστήριξη του Aspose.Slides για λειτουργίες μετατροπής PDF σας επιτρέπει να μετατρέψετε PDF σε τις πιο δημοφιλείς μορφές αρχείων. Μπορείτε να κάνετε [PDF σε HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF σε εικόνα](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF σε JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), και [PDF σε PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) μετατροπές. Άλλες λειτουργίες μετατροπής PDF σε εξειδικευμένες μορφές—[PDF σε SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF σε TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), και [PDF σε XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—επίσης υποστηρίζονται.
{{% /alert %}}

> **Note:** Όταν εξάγετε σε PDF/UA, το Aspose.Slides αντιμετωπίζει πολύπλογα γραφικά όπως SmartArt, διαγράμματα και τύπους ως ένα ενιαίο σχήμα. Τα μεμονωμένα στοιχεία μονοπατιού δεν διατηρούνται ως ξεχωριστό περιεχόμενο και μπορεί να χαρακτηριστούν ως τεχνουργήματα· το εναλλακτικό κείμενο παρέχεται μόνο για το σύνολο του σχήματος.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides για Python να αφαιρέσει τις πληροφορίες εφαρμογής από το PDF;**

Όχι, το Aspose.Slides για Python αυτόματα συμπεριλαμβάνει πληροφορίες API και τον αριθμό έκδοσης στο παραγόμενο PDF. Αυτές οι πληροφορίες δεν μπορούν να τροποποιηθούν ή να αφαιρεθούν.

**Πώς μπορώ να συμπεριλάβω μόνο συγκεκριμένες διαφάνειες στη μετατροπή PDF;**

Μπορείτε να καθορίσετε τις θέσεις διαφανειών που θέλετε να μετατρέψετε περνώντας έναν πίνακα θέσεων διαφανειών στη μέθοδο [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**Είναι δυνατόν να προστατεύσετε με κωδικό πρόσβασης το PDF κατά τη μετατροπή;**

Ναι, μπορείτε να ορίσετε κωδικό πρόσβασης και να ορίσετε άδειες πρόσβασης χρησιμοποιώντας την κλάση [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) πριν αποθηκεύσετε την παρουσίαση ως PDF.

**Το Aspose.Slides υποστηρίζει τη μετατροπή PDF σε άλλες μορφές;**

Ναι, το Aspose.Slides υποστηρίζει τη μετατροπή PDF σε μορφές όπως HTML, μορφές εικόνας (JPG, PNG), SVG, TIFF και XML.

**Πώς μπορώ να εξασφαλίσω ότι το PDF μου συμμορφώνεται με πρότυπα προσβασιμότητας;**

Ορίστε την ιδιότητα [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) σε πρότυπα όπως `PDF_A1A`, `PDF_A1B` ή `PDF_UA` για να εξασφαλίσετε τη συμμόρφωση με τις οδηγίες προσβασιμότητας.

**Μπορώ να συμπεριλάβω κρυμμένες διαφάνειες στην έξοδο PDF;**

Ναι, ορίζοντας την ιδιότητα [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) σε `True`, οι κρυμμένες διαφάνειες θα συμπεριληφθούν στο PDF.

**Πώς ρυθμίζω την ποιότητα και την ανάλυση εικόνας κατά τη μετατροπή;**

Χρησιμοποιήστε τις ιδιότητες [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) και [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) στην κλάση [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) για να ελέγξετε την ποιότητα και την ανάλυση εικόνας στο παραγόμενο PDF.

**Το Aspose.Slides διαχειρίζεται αυτόματα τις υποκαταστάσεις γραμματοσειρών;**

Το Aspose.Slides εντοπίζει τις υποκαταστάσεις γραμματοσειράς κατά τη μετατροπή και μπορείτε να τις διαχειριστείτε χρησιμοποιώντας την ιδιότητα `warning_callback` στην `SaveOptions` (προς το παρόν περιορισμένη).

## **Additional Resources**

- [Τεκμηρίωση Aspose.Slides για Python μέσω .NET](/slides/el/python-net/)
- [Αναφορά API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Δωρεάν διαδικτυακοί μετατροπείς Aspose](https://products.aspose.app/slides/conversion)