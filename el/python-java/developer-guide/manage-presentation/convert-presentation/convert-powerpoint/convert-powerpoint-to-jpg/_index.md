---
title: Μετατροπή PPT και PPTX σε JPG με Python
linktitle: PowerPoint σε JPG
type: docs
weight: 60
url: /el/python-java/convert-powerpoint-to-jpg/
keywords:
- Μετατροπή PowerPoint
- Μετατροπή παρουσίασης
- Μετατροπή διαφάνειας
- PowerPoint σε JPG
- PPT σε JPG
- PPTX σε JPG
- αποθήκευση διαφάνειας ως JPG
- εξαγωγή PPT σε JPG
- εξαγωγή PPTX σε JPG
- Python
- Java
- Aspose.Slides
description: "Μετατρέψτε τις διαφάνειες PowerPoint (PPT, PPTX) σε εικόνες JPG με Python μέσω Java. Ορίστε προσαρμοσμένες διαστάσεις εικόνας και αποδώστε σημειώσεις και σχόλια με Aspose.Slides."
---
## **Εισαγωγή**

Το Aspose.Slides for Python via Java σας επιτρέπει να μετατρέψετε παρουσιάσεις PowerPoint και OpenDocument (PPT, PPTX και ODP) σε εικόνες JPEG. Μπορείτε να εξάγετε κάθε διαφάνεια ή μια επιλεγμένη διαφάνεια για να δημιουργήσετε μικρογραφίες, να δημιουργήσετε έναν προβολέα παρουσιάσεων ή να ενσωματώσετε προεπισκοπήσεις διαφανειών σε έναν ιστότοπο ή εφαρμογή.

## **Μετατροπή PowerPoint PPT/PPTX σε JPG**

1. Φορτώστε την παρουσίαση με το [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
2. Ανακτήστε τις διαφάνειες χρησιμοποιώντας το [getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlides).
3. Καλέστε το [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) με οριζόντιους και κάθετους συντελεστές κλίμακας για να απεικονίσετε κάθε διαφάνεια.
4. Αποθηκεύστε κάθε αποδομένη εικόνα ως JPEG χρησιμοποιώντας το [ImageFormat.Jpeg](https://reference.aspose.com/slides/el/python-java/aspose.slides/imageformat/#Jpeg), στη συνέχεια απελευθερώστε τους πόρους της εικόνας.

{{% alert color="info" title="Σημείωση" %}}
Η εξαγωγή σε JPG δημιουργεί ξεχωριστή εικόνα για κάθε διαφάνεια. Αποθηκεύστε την αποδομένη εικόνα αντί να αποθηκεύετε την παρουσίαση απευθείας σε μορφή εικόνας.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```
## **Μετατροπή PowerPoint PPT/PPTX σε JPG με Προσαρμοσμένες Διαστάσεις**

Υπολογίστε τους οριζόντιους και κάθετους συντελεστές κλίμακας από τις επιθυμητές διαστάσεις σε pixel και το αρχικό μέγεθος της διαφάνειας, στη συνέχεια περάστε τα στο [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage). Το παρακάτω παράδειγμα στοχεύει σε εικόνα 1200 × 800 για κάθε διαφάνεια.

Η χρήση διαφορετικών συντελεστών κλίμακας μπορεί να τεντώσει τη διαφάνεια. Για να διατηρήσετε την αναλογία διαστάσεων, χρησιμοποιήστε τον ίδιο συντελεστή κλίμακας και για τους δύο άξονες· το αποτέλεσμα θα ακολουθεί τις αρχικές αναλογίες της διαφάνειας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```
## **Απόδοση Σχολίων Κατά την Αποθήκευση Διαφανειών ως Εικόνες**

Χρησιμοποιήστε το [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/) για να ρυθμίσετε τις σημειώσεις και τα σχόλια, και εφαρμόστε τη διάταξη μέσω του [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions). Αυτό το παράδειγμα τοποθετεί τις σημειώσεις στο κάτω μέρος, περικόβοντας τις σημειώσεις που δεν χωρούν, και εμφανίζει τα σχόλια δεξιά σε περιοχή 200 pixel πλάτους. Αποθηκεύει κάθε αποδομένη διαφάνεια ως εικόνα JPG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```
## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω πολλές διαφάνειες ή παρουσιάσεις σε JPG;**

Ναι. Τα παραδείγματα διατρέχουν όλες τις διαφάνειες και αποθηκεύουν ένα JPG ανά διαφάνεια. Για να επεξεργαστείτε πολλαπλές παρουσιάσεις, επαναλάβετε τη μετατροπή για κάθε αρχείο εισόδου και χρησιμοποιήστε ξεχωριστούς φακέλους εξόδου ή μοναδικά ονόματα αρχείων ώστε να αποφύγετε την αντικατάσταση των εικόνων.

**Συμπεριλαμβάνονται τα διαγράμματα, SmartArt, πίνακες και σχήματα στις εικόνες;**

Αυτά τα αντικείμενα αποδίδονται ως μέρος της διαφάνειας. Βεβαιωθείτε ότι οι γραμματοσειρές που χρησιμοποιεί η παρουσίαση είναι διαθέσιμες στο περιβάλλον μετατροπής για να μειωθούν οι διαφορές που προκαλούνται από την αντικατάσταση γραμματοσειρών.

**Πώς μπορώ να μειώσω τη χρήση μνήμης κατά την εξαγωγή μεγάλων παρουσιάσεων;**

Επεξεργαστείτε τις εικόνες μία τη φορά, απελευθερώνοντας κάθε εικόνα μετά την αποθήκευση, και αποφύγετε υπερβολικά μεγάλες διαστάσεις εξόδου. Οι απαιτήσεις μνήμης εξαρτώνται από το περιεχόμενο της διαφάνειας και το μέγεθος της εικόνας.

## **Δείτε επίσης**

- [Μετατροπή PowerPoint σε PNG](/slides/el/python-java/convert-powerpoint-to-png/).
- [Απόδοση διαφάνειας ως εικόνα SVG](/slides/el/python-java/render-a-slide-as-an-svg-image/).