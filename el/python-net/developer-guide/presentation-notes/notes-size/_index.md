---
title: Αλλαγή Μεγέθους και Προσανατολισμού Σελίδας Σημειώσεων σε Python
linktitle: Μέγεθος Σελίδας Σημειώσεων
type: docs
weight: 10
url: /el/python-net/notes-size/
keywords:
- μέγεθος σελίδας σημειώσεων
- προσανατολισμός σημειώσεων
- οριζόντιες σημειώσεις
- κατακόρυφες σημειώσεις
- μέγεθος φυλλαδίου
- PowerPoint
- παρουσίαση
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Διαβάστε και αλλάξτε τις διαστάσεις της σελίδας σημειώσεων στο Aspose.Slides για Python μέσω .NET, αλλάξτε τον προσανατολισμό, επαληθεύστε τα αποθηκευμένα μεγέθη και εξάγετε σημειώσεις ή φυλλαδία σε PDF και εικόνες."
---
## **Επισκόπηση**

Χρησιμοποιήστε [Presentation.notes_size](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/notes_size/) για πρόσβαση στις ρυθμίσεις σελίδας σημειώσεων της παρουσίασης. Επιστρέφει ένα αντικείμενο [NotesSize](https://reference.aspose.com/slides/el/python-net/aspose.slides/notessize/) του οποίου η ιδιότητα [size](https://reference.aspose.com/slides/el/python-net/aspose.slides/notessize/size/) είναι εγγράψιμη. Παρόλο που το ίδιο το αντικείμενο ρυθμίσεων είναι μόνο για ανάγνωση, μπορείτε να αναθέσετε νέες διαστάσεις στην ιδιότητα size.

Το πλάτος και το ύψος καθορίζονται σε **σημεία**, με 72 σημεία ανά ίντσα. Για παράδειγμα, 900 × 600 σημεία ισοδυναμούν με 12,5 × 8⅓ ίντσες. Αυτές οι ρυθμίσεις εφαρμόζονται στην παρουσίαση, όχι σε σημειώσεις ενός μεμονωμένου διαφάνειας.

| Ρύθμιση | Σκοπός |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/notes_size/) | Ελέγχει τις διαστάσεις της σελίδας σημειώσεων και τις διαστάσεις σελίδας που χρησιμοποιούνται για εξαγωγή φυλλαδίων. |
| [Presentation.slide_size](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/slide_size/) | Ελέγχει τις κανονικές διαστάσεις των διαφανειών της παρουσίασης μέσω του [SlideSize](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidesize/). |

Η αλλαγή οποιασδήποτε από τις ρυθμίσεις δεν αλλάζει αυτόματα την άλλη. Η αλλαγή του προσανατολισμού της σελίδας σημειώσεων δεν περιστρέφει επίσης τις κανονικές διαφάνειες. Δείτε το [Slide Size](/slides/el/python-net/slide-size/) για να αλλάξετε το μέγεθος των κανονικών διαφανειών.

Τα παρακάτω παραδείγματα χρησιμοποιούν ένα υπάρχον αρχείο `sample.pptx`. Για τα παραδείγματα εξαγωγής, χρησιμοποιήστε μια παρουσίαση που περιέχει τουλάχιστον μία διαφάνεια με σημειώσεις ομιλητή. Κάθε παράδειγμα μπορεί να εκτελεστεί ανεξάρτητα.

## **Ανάγνωση του Μεγέθους και του Προσανατολισμού της Σελίδας Σημειώσεων**

Διαβάστε το πλάτος και το ύψος και συγκρίνετέ τα για να προσδιορίσετε τον προσανατολισμό: μια πιο πλατιά σελίδα είναι οριζόντια, μια πιο ψηλή σελίδα είναι κάθετη, και ίσες διαστάσεις περιγράφουν τετράγωνη σελίδα. Αυτό το παράδειγμα εκτυπώνει τις πραγματικές διαστάσεις σε σημεία, χωρίς να υποθέτει τυπικό μέγεθος χαρτιού.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Αλλαγή σε Οριζόντια Προσανατολισμό Χωρίς Αλλαγή του Μεγέθους Χαρτιού**

Για να αλλάξετε μόνο τον προσανατολισμό, ανταλλάξτε το τρέχον πλάτος και ύψος. Αυτό διατηρεί τα μήκη και των δύο πλευρών, συμπεριλαμβανομένων των διαστάσεων ενός προσαρμοσμένου μεγέθους χαρτιού. Η παρακάτω συνθήκη αποτρέπει μια ήδη οριζόντια σελίδα να μετατραπεί ξανά σε κάθετη και αφήνει μια τετράγωνη σελίδα αμετάβλητη.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

Για κάθετο προσανατολισμό, χρησιμοποιήστε την ίδια ανάθεση όταν `size.width > size.height`. Μην αντικαταστήσετε τις διαστάσεις A4 ή Letter εκτός αν θέλετε επίσης να αλλάξετε το μέγεθος του χαρτιού.

## **Ορισμός και Επαλήθευση Προσαρμοσμένου Μεγέθους Σελίδας Σημειώσεων**

Αναθέστε και τις δύο διαστάσεις μαζί, στη συνέχεια χρησιμοποιήστε το [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/) για να αποθηκεύσετε την παρουσίαση. Αυτό το παράδειγμα ορίζει μια οριζόντια σελίδα 900 × 600 σημείων, την αποθηκεύει ως PPTX και ανοίγει ξανά το αποθηκευμένο αρχείο για να ελέγξει τις αποθηκευμένες τιμές. Η σύγκριση επιτρέπει ανοχή 0,01 σημείου για δεκαδικές τιμές· δεν αποτελεί εγγύηση ακρίβειας για κάθε μορφή αρχείου.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

Το αναμενόμενο αποτέλεσμα είναι `900 x 600 points` και `Size preserved: True`. Ο έλεγχος μιας πρόσφατα ανοιγμένης παρουσίασης επαληθεύει το αποθηκευμένο αρχείο, όχι μόνο τις ρυθμίσεις στη μνήμη.

## **Εξαγωγή Σημειώσεων και Φυλλαδίων**

Οι διαστάσεις της σελίδας ορίζουν την διαθέσιμη περιοχή για διατάξεις σημειώσεων ή φυλλαδίων. Δεν ενεργοποιούν αυτές τις διατάξεις από μόνες τους· πρέπει επίσης να ρυθμίσετε τις επιλογές εξαγωγής. Η εξαγωγή κανονικών διαφανειών συνεχίζει να χρησιμοποιεί τις διαστάσεις των διαφανειών.

### **Εξαγωγή Σημειώσεων σε PDF και PNG**

Αναθέστε το [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/notescommentslayoutingoptions/) στο [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) για να συμπεριλάβετε τις σημειώσεις στο PDF. Αυτό το παράδειγμα επίσης αποδίδει την πρώτη διαφάνεια με σημειώσεις σε PNG χρησιμοποιώντας το [Slide.get_image](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/get_image/) και το [RenderingOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/renderingoptions/).

Η λειτουργία [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/notespositions/) διατηρεί τις σημειώσεις σε μία σελίδα· οι σημειώσεις που δεν χωράνε μπορούν να περικοπούν. Το PDF χρησιμοποιεί σελίδες 900 × 600 σημείων. Στην κλίμακα εικόνας 1 × 1 που χρησιμοποιείται παρακάτω, το PNG είναι 900 × 600 εικονοστοιχεία. Τα σημεία περιγράφουν τη γεωμετρία της σελίδας· τα εικονοστοιχεία περιγράφουν την έξοδο raster, των οποίων οι διαστάσεις εξαρτώνται επίσης από την κλίμακα απόδοσης.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

Για εξαγωγή PDF με μεγάλες σημειώσεις, το [BOTTOM_FULL](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/notespositions/) επιτρέπει πρόσθετες σελίδες όπως απαιτείται. Μην χρησιμοποιείτε αυτή τη λειτουργία με την κλήση εικόνας μιας μόνο διαφάνειας παραπάνω, η οποία δεν την υποστηρίζει. Μετά την αλλαγή μεγέθους, εξετάστε το αποτέλεσμα για αποκομμένες σημειώσεις και τη θέση των υπαρχόντων αντικειμένων notes‑master· η αλλαγή των διαστάσεων της σελίδας από μόνη της δεν πρέπει να θεωρείται εγγύηση ότι όλο το περιεχόμενο θα χωράει. Δείτε το [Convert PowerPoint to PDF with Notes](/slides/el/python-net/convert-powerpoint-to-pdf-with-notes/) για περισσότερα σχετικά με την εξαγωγή σημειώσεων.

### **Εξαγωγή Φυλλαδίων σε PDF**

Χρησιμοποιήστε το [HandoutLayoutingOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/handoutlayoutingoptions/) για πολλές μικρογραφίες διαφανειών σε μία σελίδα. Το παρακάτω παράδειγμα ορίζει μια σελίδα 900 × 600 σημείων και χρησιμοποιεί το [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/handouttype/) για να διατάξει έως τέσσερις διαφάνειες ανά σελίδα. Η οριζόντια προεπιλογή ελέγχει τη σειρά των διαφανειών· ο προσανατολισμός της σελίδας προέρχεται από το πλάτος και το ύψος της.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Η αλλαγή του μεγέθους της σελίδας αλλάζει την διαθέσιμη περιοχή για το πλέγμα των φυλλαδίων χωρίς να αλλάζει τις διαστάσεις των πηγαίων διαφανειών. Για εικόνες φυλλαδίου, χρησιμοποιήστε το [Presentation.get_images](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/get_images/) με τη διάταξη του φυλλαδίου, αντί για τη μέθοδο εικόνας μιας μεμονωμένης διαφάνειας. Στο Aspose.Slides, η απόδοση φυλλαδίου σε επίπεδο παρουσίασης χρησιμοποιεί τις διαστάσεις της σελίδας σημειώσεων, ενώ η κλήση εικόνας μεμονωμένης διαφάνειας δεν δημιουργεί τη σελίδα του φυλλαδίου. Δείτε το [Handout Mode](/slides/el/python-net/convert-powerpoint-in-handout-mode/) για επιλογές διάταξης.

## **Μέγεθος Σελίδας σε Προβολείς, Εξαγωγές και Εκτυπώσεις**

Διατηρήστε ξεχωριστά το αποθηκευμένο μέγεθος της παρουσίασης, το εξαγόμενο μέγεθος σελίδας και το εκτυπωμένο μέγεθος χαρτιού:

- **Presentation viewers:** Ένας προβολέας μπορεί να εμφανίσει ή να εκτυπώσει τις σημειώσεις χρησιμοποιώντας τους δικούς του κανόνες διάταξης. Εάν μια άλλη εφαρμογή αποθηκεύσει το αρχείο, ανοίξτε το ξανά και ελέγξτε τις διαστάσεις· η μετατροπή μορφής της εφαρμογής ενδέχεται να τις ομαλοποιήσει.
- **Export formats:** Τα παραδείγματα PDF σημειώσεων και φυλλαδίων παραπάνω χρησιμοποιούν τις ρυθμισμένες διαστάσεις σελίδας. Οι raster εικόνες χρησιμοποιούν ακέραιες διαστάσεις εικονοστοιχείων και κλίμακα απόδοσης, έτσι οι κλασματικές τιμές σε σημείο μπορούν να στρογγυλοποιηθούν στην έξοδο εικόνας. Η εξαγωγή των κανονικών διαφανειών δεν εφαρμόζει το μέγεθος της σελίδας σημειώσεων.
- **Printer drivers:** Η επιλογή χαρτιού, η αυτόματη περιστροφή και οι ρυθμίσεις προσαρμογής στο μέγεθος σελίδας μπορούν να αλλάξουν το φυσικό αποτέλεσμα χωρίς να αλλάξουν τις διαστάσεις που αποθηκεύονται στην παρουσίαση ή στο PDF. Για ένα συγκεκριμένο μέγεθος χαρτιού, ταιριάξτε τις ρυθμίσεις του εκτυπωτή και ελέγξτε την προεπισκόπηση εκτύπωσης.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ορίσω το μέγεθος των σημειώσεων για μόνο μία διαφάνεια;**

Το μέγεθος της σελίδας σημειώσεων είναι ρύθμιση σε επίπεδο παρουσίασης. Οι μεμονωμένες διαφάνειες μπορούν να έχουν διαφορετικό περιεχόμενο σημειώσεων, αλλά αυτή η ιδιότητα δεν παρέχει ξεχωριστό μέγεθος σελίδας για κάθε διαφάνεια.

**Γιατί η αλλαγή του προσανατολισμού των σημειώσεων δεν άλλαξε τις διαφάνειές μου;**

Οι σελίδες σημειώσεων και οι κανονικές διαφάνειες έχουν ανεξάρτητες διαστάσεις. Χρησιμοποιήστε τις ρυθμίσεις μεγέθους κανονικών διαφανειών όταν θέλετε να αλλάξετε τις διαφάνειες.

**Γιατί το αποθηκευμένο ή εκτυπωμένο αποτέλεσμα έχει διαφορετικό μέγεθος;**

Πρώτα ανοίξτε ξανά την αποθηκευμένη παρουσίαση και συγκρίνετε τις διαστάσεις των σημειώσεων. Εάν αυτές έχουν αλλάξει, ελέγξτε αν η αποθήκευση ή η μετατροπή του αρχείου σε άλλη εφαρμογή άλλαξε τις ρυθμίσεις σελίδας. Αν δεν άλλαξαν, ελέγξτε τη διάταξη εξαγωγής, την κλίμακα εικόνας, τις ρυθμίσεις προβολέα και την επιλογή χαρτιού του εκτυπωτή.