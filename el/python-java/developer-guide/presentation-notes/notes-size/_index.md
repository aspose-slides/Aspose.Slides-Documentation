---
title: Αλλαγή του Μεγέθους και του Προσανατολισμού της Σελίδας Σημειώσεων σε Python μέσω Java
linktitle: Μέγεθος Σελίδας Σημειώσεων
type: docs
weight: 10
url: /el/python-java/notes-size/
keywords:
- μέγεθος σελίδας σημειώσεων
- προσανατολισμός σημειώσεων
- οριζόντιες σημειώσεις
- κάθετες σημειώσεις
- μέγεθος διανομής
- PowerPoint
- παρουσίαση
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Διαβάστε και αλλάξτε τις διαστάσεις της σελίδας σημειώσεων στο Aspose.Slides για Python μέσω Java, αλλάξτε τον προσανατολισμό, επαληθεύστε τα αποθηκευμένα μεγέθη και εξάγετε σημειώσεις ή διανομές σε PDF και εικόνες."
---
## **Επισκόπηση**

Χρησιμοποιήστε [Presentation.getNotesSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getNotesSize) για πρόσβαση στις ρυθμίσεις της σελίδας σημειώσεων της παρουσίασης. Επιστρέφει ένα αντικείμενο [NotesSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/notessize/) του οποίου η μέθοδος [setSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/notessize/#setSize) ορίζει τις διαστάσεις της σελίδας. Αν και το αντικείμενο ρυθμίσεων δεν μπορεί να αντικατασταθεί, μπορείτε να ορίσετε νέες διαστάσεις μέσω αυτής της μεθόδου.

Το πλάτος και το ύψος καθορίζονται σε **points**, με 72 points ανά ίντσα. Για παράδειγμα, 900 × 600 points ισοδυναμούν με 12,5 × 8⅓ ίντσες. Αυτές οι ρυθμίσεις ισχύουν για την παρουσίαση, όχι για τις σημειώσεις ενός μεμονωμένου slide.

| Ρύθμιση | Σκοπός |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getNotesSize) | Ελέγχει τις διαστάσεις της σελίδας σημειώσεων και τις διαστάσεις της σελίδας που χρησιμοποιούνται για εξαγωγή διανομής. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlideSize) | Ελέγχει τις κανονικές διαστάσεις των διαφανειών της παρουσίασης μέσω του [SlideSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesize/). |

Η αλλαγή μιας από τις ρυθμίσεις δεν αλλάζει αυτόματα την άλλη. Η αλλαγή του προσανατολισμού της σελίδας σημειώσεων επίσης δεν περιστρέφει τις κανονικές διαφάνειες. Δείτε το [Slide Size](/slides/el/python-java/slide-size/) για αλλαγή διαστάσεων των κανονικών διαφανειών.

Τα παραδείγματα παρακάτω χρησιμοποιούν ένα υπάρχον `sample.pptx`. Για τα παραδείγματα εξαγωγής, χρησιμοποιήστε μια παρουσίαση με τουλάχιστον μία διαφάνεια που περιέχει σημειώσεις παρουσιαστή. Κάθε παράδειγμα μπορεί να εκτελεστεί ανεξάρτητα.

## **Διαβάστε τις διαστάσεις και τον προσανατολισμό της σελίδας σημειώσεων**

Διαβάστε το πλάτος και το ύψος και συγκρίνετέ τα για να προσδιορίσετε τον προσανατολισμό: μια ευρύτερη σελίδα είναι οριζόντια, μια πιο ψηλή σελίδα είναι κάθετη, και ίσες διαστάσεις περιγράφουν τετράγωνη σελίδα. Αυτό το παράδειγμα εκτυπώνει τις πραγματικές διαστάσεις σε points, χωρίς να υποθέτει κάποιο πρότυπο μέγεθος χαρτιού.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **Αλλαγή σε οριζόντια διάταξη χωρίς αλλαγή του μεγέθους του χαρτιού**

Για να αλλάξετε μόνο τον προσανατολισμό, ανταλλάξτε το υπάρχον πλάτος και ύψος. Αυτό διατηρεί τα μήκη και των δύο πλευρών, συμπεριλαμβανομένων των διαστάσεων ενός προσαρμοσμένου μεγέθους χαρτιού. Η παρακάτω συνθήκη αποτρέπει το να μετατραπεί μια ήδη οριζόντια σελίδα ξανά σε κάθετη και αφήνει μια τετράγωνη σελίδα αμετάβλητη.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για κάθετη διάταξη, χρησιμοποιήστε την ίδια εκχώρηση όταν `size.getWidth() > size.getHeight()`. Μην αντικαταστήσετε τις διαστάσεις A4 ή Letter εκτός αν θέλετε επίσης να αλλάξετε το μέγεθος του χαρτιού.

## **Ορίστε και επαληθεύστε προσαρμοσμένο μέγεθος σελίδας σημειώσεων**

Ορίστε και τις δύο διαστάσεις μαζί, στη συνέχεια χρησιμοποιήστε την [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) για να γράψετε την παρουσίαση. Αυτό το παράδειγμα ορίζει μια οριζόντια σελίδα 900 × 600 points, την αποθηκεύει ως PPTX και ανοίγει ξανά το αποθηκευμένο αρχείο για να ελέγξει τις διατηρημένες τιμές. Η σύγκριση επιτρέπει ανοχή 0,01 point για τιμές κινητής υποδιαστολής· δεν αποτελεί εγγύηση ακρίβειας για κάθε μορφή αρχείου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Το αναμενόμενο αποτέλεσμα είναι `900.0 x 600.0 points` και `Size preserved: True`. Ο έλεγχος μιας νεοανοιγμένης παρουσίασης επαληθεύει το αποθηκευμένο αρχείο, όχι μόνο τις ρυθμίσεις στη μνήμη.

## **Εξαγωγή σημειώσεων και διανομών**

Οι διαστάσεις της σελίδας ορίζουν τον διαθέσιμο χώρο για τις διατάξεις σημειώσεων ή διανομών. Δεν ενεργοποιούν τις διατάξεις αυτές από μόνες τους: πρέπει επίσης να ρυθμίσετε τις επιλογές εξαγωγής. Η εξαγωγή κανονικών διαφανειών συνεχίζει να χρησιμοποιεί τις διαστάσεις της διαφάνειας.

### **Εξαγωγή σημειώσεων σε PDF και PNG**

Ορίστε το [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/) στην [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) για να συμπεριλάβετε τις σημειώσεις στο PDF. Αυτό το παράδειγμα επίσης αποδίδει την πρώτη διαφάνεια με σημειώσεις σε PNG χρησιμοποιώντας το [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) και το [RenderingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/renderingoptions/).

Η λειτουργία [BottomTruncated](https://reference.aspose.com/slides/el/python-java/aspose.slides/notespositions/) διατηρεί τις σημειώσεις σε μία σελίδα· οι σημειώσεις που δεν χωρούν μπορούν να περικοπούν. Το PDF χρησιμοποιεί σελίδες 900 × 600 points. Στην κλίμακα εικόνας 1 × 1 που χρησιμοποιείται παρακάτω, το PNG είναι 900 × 600 pixels. Τα points περιγράφουν τη γεωμετρία της σελίδας· τα pixels περιγράφουν την εικονογραφική έξοδο, των οποίων οι διαστάσεις εξαρτώνται επίσης από την κλίμακα απόδοσης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Για εξαγωγή PDF με μακριές σημειώσεις, το [BottomFull](https://reference.aspose.com/slides/el/python-java/aspose.slides/notespositions/) επιτρέπει πρόσθετες σελίδες ανάλογα με τις ανάγκες. Μην χρησιμοποιήσετε αυτή τη λειτουργία με την κλήση εικόνας μίας διαφάνειας παραπάνω, η οποία δεν την υποστηρίζει. Μετά την αλλαγή μεγέθους, ελέγξτε την έξοδο για περικομμένες σημειώσεις και την τοποθέτηση των υπαρχόντων αντικειμένων notes‑master· η αλλαγή μόνο των διαστάσεων της σελίδας δεν πρέπει να θεωρηθεί εγγύηση ότι όλο το περιεχόμενο θα χωράει. Δείτε το [Convert PowerPoint to PDF with Notes](/slides/el/python-java/convert-powerpoint-to-pdf-with-notes/) για περισσότερες πληροφορίες σχετικά με την εξαγωγή σημειώσεων.

### **Εξαγωγή διανομών σε PDF**

Χρησιμοποιήστε το [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/handoutlayoutingoptions/) για πολλαπλά μικρογραφίες διαφανειών σε μία σελίδα. Το παρακάτω παράδειγμα ορίζει μια σελίδα 900 × 600 points και χρησιμοποιεί το [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/el/python-java/aspose.slides/handouttype/) για τη διάταξη έως και τεσσάρων διαφανειών ανά σελίδα. Η οριζόντια προεπιλογή ελέγχει τη σειρά των διαφανειών· ο προσανατολισμός της σελίδας προέρχεται από το πλάτος και το ύψος της.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Η αλλαγή του μεγέθους της σελίδας αλλάζει την περιοχή διαθέσιμη για το πλέγμα της διανομής χωρίς να αλλάζει τις διαστάσεις των αρχικών διαφανειών. Για εικόνες διανομών, χρησιμοποιήστε το [Presentation.getImages](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getImages) με τη διάταξη διανομής, αντί για τη μέθοδο εικόνας μεμονωμένης διαφάνειας. Στο Aspose.Slides, η απόδοση διανομής σε επίπεδο παρουσίασης χρησιμοποιεί τις διαστάσεις της σελίδας σημειώσεων, ενώ η κλήση εικόνας μεμονωμένης διαφάνειας δεν παράγει τη σελίδα διανομής. Δείτε το [Handout Mode](/slides/el/python-java/convert-powerpoint-in-handout-mode/) για επιλογές διάταξης.

## **Μέγεθος σελίδας σε προβολείς, εξαγωγή και εκτύπωση**

Διατηρήστε ξεχωριστά το αποθηκευμένο μέγεθος της παρουσίασης, το εξαγόμενο μέγεθος της σελίδας και το εκτυπωμένο μέγεθος χαρτιού:

- **Presentation viewers:** Ένας προβολέας μπορεί να εμφανίσει ή να εκτυπώσει τις σημειώσεις χρησιμοποιώντας τους δικούς του κανόνες διάταξης. Εάν άλλη εφαρμογή αποθηκεύσει το αρχείο, ανοίξτε το ξανά και ελέγξτε τις διαστάσεις· η μετατροπή μορφής εκείνης της εφαρμογής μπορεί να τις ομαλοποιήσει.
- **Export formats:** Τα παραδείγματα PDF σημειώσεων και διανομών πιο πάνω χρησιμοποιούν τις ρυθμισμένες διαστάσεις της σελίδας. Οι ρομπότ εικόνων χρησιμοποιούν ακέραιες διαστάσεις pixel και κλίμακα απόδοσης, έτσι οι κλασματικές τιμές point μπορεί να στρογγυλοποιηθούν στην έξοδο εικόνας. Η εξαγωγή κανονικών διαφανειών δεν εφαρμόζει το μέγεθος της σελίδας σημειώσεων.
- **Printer drivers:** Η επιλογή χαρτιού, η αυτόματη περιστροφή και οι ρυθμίσεις προσαρμογής στη σελίδα μπορούν να αλλάξουν το φυσικό αποτέλεσμα χωρίς να αλλάξουν τις διαστάσεις που είναι αποθηκευμένες στην παρουσίαση ή στο PDF. Για ένα συγκεκριμένο μέγεθος χαρτιού, ταιριάξτε τις ρυθμίσεις του εκτυπωτή και ελέγξτε την προεπισκόπηση εκτύπωσης.

## **Συχνές ερωτήσεις**

**Μπορώ να ορίσω το μέγεθος των σημειώσεων για μόνο μία διαφάνεια;**

Το μέγεθος της σελίδας σημειώσεων είναι ρύθμιση σε επίπεδο παρουσίασης. Οι μεμονωμένες διαφάνειες μπορούν να έχουν διαφορετικό περιεχόμενο σημειώσεων, αλλά αυτή η ιδιότητα δεν παρέχει ξεχωριστό μέγεθος σελίδας για κάθε διαφάνεια.

**Γιατί η αλλαγή του προσανατολισμού των σημειώσεων δεν άλλαξε τις διαφάνειές μου;**

Οι σελίδες σημειώσεων και οι κανονικές διαφάνειες έχουν ανεξάρτητες διαστάσεις. Χρησιμοποιήστε τις ρυθμίσεις μεγέθους των κανονικών διαφανειών όταν θέλετε να αλλάξετε το μέγεθος των διαφανειών.

**Γιατί το αποθηκευμένο ή εκτυπωμένο αποτέλεσμα έχει διαφορετικό μέγεθος;**

Πρώτα ανοίξτε ξανά την αποθηκευμένη παρουσίαση και συγκρίνετε τις διαστάσεις των σημειώσεων. Αν αυτές έχουν αλλάξει, ελέγξτε αν η αποθήκευση ή η μετατροπή του αρχείου σε άλλη εφαρμογή άλλαξε τις ρυθμίσεις της σελίδας. Εάν δεν συνέβη, ελέγξτε τη διάταξη εξαγωγής, την κλίμακα εικόνας, τις ρυθμίσεις προβολέα και την επιλογή χαρτιού του εκτυπωτή.