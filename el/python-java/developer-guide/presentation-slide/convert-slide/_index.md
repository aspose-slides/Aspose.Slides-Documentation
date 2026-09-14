---
title: Μετατροπή διαφανειών παρουσίασης σε εικόνες με Python
linktitle: Διαφάνεια σε Εικόνα
type: docs
weight: 35
url: /el/python-java/convert-slide/
keywords:
- μετατροπή διαφάνειας
- εξαγωγή διαφάνειας
- διαφάνεια σε εικόνα
- αποθήκευση διαφάνειας ως εικόνα
- διαφάνεια σε EMF
- διαφάνεια σε PNG
- διαφάνεια σε JPEG
- διαφάνεια σε bitmap
- διαφάνεια σε TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: Μετατροπή διαφανειών από παρουσιάσεις PPT, PPTX και ODP σε PNG, JPEG, GIF, TIFF, EMF και άλλες μορφές εικόνας στην Python με Aspose.Slides.
---
## **Εισαγωγή**

Το Aspose.Slides for Python via Java μπορεί να αποδώσει μεμονωμένες διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument ως PNG, JPEG, GIF, TIFF και άλλες μορφές εικόνας.

Για να μετατρέψετε μια διαφάνεια σε εικόνα, ακολουθήστε τα παρακάτω βήματα:

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
2. Επιλέξτε τη διαφάνεια που θέλετε να αποδώσετε.
3. Αν χρειάζεται, διαμορφώστε την απόδοση με την κλάση [RenderingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/renderingoptions/) ή [TiffOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/tiffoptions/).
4. Καλείτε τη μέθοδο [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage). Επιστρέφει ένα αντικείμενο εικόνας.
5. Αποθηκεύστε την εικόνα και καθορίστε τη μορφή εξόδου με μια τιμή [ImageFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/imageformat/).

## **Μετατροπή μιας διαφάνειας σε εικόνα PNG**

Η πιο απλή μετατροπή χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις απόδοσης. Το αντικείμενο εικόνας που προκύπτει μπορεί να επεξεργαστεί στη μνήμη ή να αποθηκευτεί σε αρχείο.

Το παρακάτω παράδειγμα Python αποδίδει τη πρώτη διαφάνεια και την αποθηκεύει ως εικόνα PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Μετατροπή διαφανειών σε εικόνες με προσαρμοσμένα μεγέθη**

Χρησιμοποιήστε την υπερφόρτωση [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) που δέχεται μια τιμή [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) για να αποδώσετε μια διαφάνεια με ακριβείς διαστάσεις σε εικονοστοιχεία.

Το παρακάτω παράδειγμα δημιουργεί μια εικόνα JPEG 1820 × 1040:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Μετατροπή διαφανειών με σημειώσεις και σχόλια σε εικόνες**

Από προεπιλογή, οι εικόνες διαφανειών δεν περιλαμβάνουν σημειώσεις ή σχόλια. Προσδώστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/) στη μέθοδο [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) για να ελέγξετε πού εμφανίζονται οι σημειώσεις και τα σχόλια.

Το παρακάτω παράδειγμα τοποθετεί περικομμένες σημειώσεις κάτω από τη διαφάνεια και σχόλια στα δεξιά της:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Προειδοποίηση" color="warning" %}}
Για τη μετατροπή διαφάνειας-σε-εικόνα, μην περάσετε [BottomFull](https://reference.aspose.com/slides/el/python-java/aspose.slides/notespositions/#BottomFull) στη μέθοδο [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/el/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Οι σημειώσεις μπορούν να περιέχουν περισσότερο κείμενο από ό,τι μπορεί να χωρέσει το σταθερό μέγεθος της εικόνας. Χρησιμοποιήστε [BottomTruncated](https://reference.aspose.com/slides/el/python-java/aspose.slides/notespositions/#BottomTruncated) αντί αυτού.
{{% /alert %}}

## **Μετατροπή διαφανειών σε εικόνες χρησιμοποιώντας επιλογές TIFF**

Η κλάση [TiffOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/tiffoptions/) σας επιτρέπει να ελέγχετε το μέγεθος, την ανάλυση και άλλες ιδιότητες της παραγόμενης εικόνας TIFF.

Το παρακάτω παράδειγμα αποδίδει τη πρώτη διαφάνεια ως εικόνα TIFF 2160 × 2880 σε 300 DPI:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Προειδοποίηση" color="warning" %}}
Η υποστήριξη TIFF δεν εγγυάται σε εκδόσεις Java παλαιότερες από το JDK 9.
{{% /alert %}}

## **Μετατροπή όλων των διαφανειών σε εικόνες**

Επανάληψη στη συλλογή διαφανειών για να μετατρέψετε ολόκληρη την παρουσίαση σε σειρά εικόνων. Οι κρυμμένες διαφάνειες περιλαμβάνονται εκτός αν τις παραλείψετε ρητά.

Το παρακάτω παράδειγμα αποδίδει κάθε διαφάνεια ως εικόνα JPEG με οριζόντιους και κάθετους συντελεστές κλιμάκωσης ίσους με 2:

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Δημιουργία εξόδου Enhanced Metafile**

Το Enhanced Metafile (EMF) είναι χρήσιμο όταν χρειάζεται να ανταλλαγούν γραφικά βάσει διανυσμάτων με το Microsoft Office ή άλλες εφαρμογές Windows που υποστηρίζουν Windows metafiles. Σε αντίθεση με μια εικόνα βάσει εικονοστοιχείων, ένα EMF μπορεί να διατηρεί τις διανυσματικές λειτουργίες σχεδίασης που κλιμακώνονται χωρίς απώλεια ευκρίνειας. Ωστόσο, το EMF είναι κυρίως μορφή συμβατότητας για εφαρμογές με υποστήριξη Windows metafile, όχι μία καθολική μορφή ανταλλαγής. Επιπλέον, σύνθετο περιεχόμενο διαφάνειας, όπως εικόνες bitmap και ορισμένα εφέ, μπορεί να αποθηκεύεται ως ραστερισμένα στοιχεία μέσα στο διανυσματικό φάκελο metafile.

### **Εξαγωγή διαφάνειας σε EMF**

Η μέθοδος [Slide.writeAsEmf](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/) γράφει μια διαφάνεια σε ένα ρεύμα στόχο σε μορφή EMF. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, επιλέγει την πρώτη διαφάνεια και την γράφει σε ρεύμα αρχείου EMF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

Ο καλών έχει την ιδιοκτησία του ρεύματος που περνιέται στη μέθοδο [Slide.writeAsEmf](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/) και είναι υπεύθυνος για το κλείσιμο του, όπως φαίνεται παραπάνω.

### **Μετατροπή εικόνας SVG σε EMF και προσθήκη της σε παρουσίαση**

Χρησιμοποιήστε το [SvgImage.writeAsEmf](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgimage/) για να μετατρέψετε το περιεχόμενο SVG σε EMF. Τα προκύπτοντα bytes μπορούν να προστεθούν στην παρουσίαση μέσω [ImageCollection.addImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/imagecollection/#addImage) και να τοποθετηθούν σε μια διαφάνεια με [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addPictureFrame).

Το παρακάτω παράδειγμα δημιουργεί ένα [SvgImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgimage/) από σήμανση SVG, το μετατρέπει σε EMF στη μνήμη, εισάγει το metafile στην πρώτη διαφάνεια και αποθηκεύει την παρουσίαση:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το [SvgImage.writeAsEmf](https://reference.aspose.com/slides/el/python-java/aspose.slides/svgimage/) δεν αποκτά την ιδιοκτησία του ρεύματος προορισμού. Ένα [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) αποθηκεύει όλα τα παραγόμενα δεδομένα στη μνήμη, έτσι δεν απαιτείται επαναφορά της θέσης πριν κληθεί το [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--). Ο επιστρεφόμενος πίνακας byte παραμένει έγκυρος μετά το κλείσιμο του ρεύματος.

Η δημιουργία EMF είναι διαθέσιμη στα λειτουργικά συστήματα που υποστηρίζονται από την επιλεγμένη διαμόρφωση Aspose.Slides for Python via Java και JDK, αλλά η απόδοση μπορεί να διαφέρει μεταξύ πλατφορμών όταν λείπουν γραμματοσειρές ή εξαρτήσεις γραφικών. Εγκαταστήστε τις γραμματοσειρές που χρησιμοποιούνται στο αρχικό περιεχόμενο ή διαμορφώστε κατάλληλες αντικαταστάσεις, ακολουθήστε τις απαιτήσεις πλατφόρμας για το Aspose.Slides for Python via Java και επικυρώστε το αποτέλεσμα στην εφαρμογή‑παραλήπτη EMF. Οι εφαρμογές Linux και macOS συχνά έχουν περιορισμένη ή ασυνεπή υποστήριξη για την προβολή και επεξεργασία Windows metafiles.

## **Απόδοση χρωματιστών Emoji**

{{% alert title="Σημείωση" color="info" %}}
Για τη σωστή απόδοση χρωματιστών emoji κατά τη μετατροπή των διαφανειών παρουσίασης σε εικόνες, οι γραμματοσειρές emoji που χρησιμοποιούνται στην παρουσίαση πρέπει να είναι εγκατεστημένες και διαθέσιμες στο σύστημα που εκτελεί τη μετατροπή. Για παράδειγμα, εάν η παρουσίαση χρησιμοποιεί **Segoe UI Emoji** και αυτή η γραμματοσειρά λείπει, τα emoji μπορεί να εμφανιστούν μονόχρωμα στις εικόνες εξόδου.
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Υποστηρίζει το Aspose.Slides τη δημιουργία εικόνων διαφανειών με κινούμενα σχέδια;**

Όχι. Η μέθοδος [Slide.getImage](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getImage) αποδίδει μια στατική εικόνα της διαφάνειας και δεν εξάγει τις κινούμενες εικόνες.

**Μπορούν οι κρυμμένες διαφάνειες να εξαχθούν ως εικόνες;**

Ναι. Οι κρυμμένες διαφάνειες μπορούν να αποδοθούν όπως οι κανονικές διαφάνειες. Συμπεριλάβετε τες στον βρόχο επεξεργασίας, όπως φαίνεται στο παραπάνω παράδειγμα.

**Διατηρούνται οι σκιές και άλλα εφέ στις εικόνες των διαφανειών;**

Ναι. Το Aspose.Slides αποδίδει σκιές, διαφάνεια και άλλα υποστηριζόμενα γραφικά εφέ στις εικόνες των διαφάνειων.