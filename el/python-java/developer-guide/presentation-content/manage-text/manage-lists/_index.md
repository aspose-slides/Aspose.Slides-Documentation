---
title: Διαχείριση λιστών με κουκκίδες και αριθμημένων λιστών σε παρουσιάσεις χρησιμοποιώντας Python μέσω Java
linktitle: Διαχείριση λιστών
type: docs
weight: 60
url: /el/python-java/manage-lists/
keywords:
- κουκκίδα
- λίστα με κουκκίδες
- αριθμημένη λίστα
- σύμβολο κουκκίδας
- εικόνα‑κουκκίδα
- προσαρμοσμένη κουκκίδα
- πολυεπίπεδη λίστα
- δημιουργία κουκκίδας
- προσθήκη κουκκίδας
- προσθήκη λίστας
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε λιστες με κουκκίδες, εικόνα‑κουκκίδες, πολυεπίπεδες λιστες και αριθμημένες λιστες σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides for Python via Java σάς επιτρέπει να δημιουργείτε και να μορφοποιείτε λιστες με κουκκίδες και αριθμημένες λιστες σε παρουσιάσεις PowerPoint και OpenDocument. Ένα στοιχείο λίστας είναι μια παράγραφος των οποίων οι ρυθμίσεις κουκκίδας ελέγχονται μέσω της μορφοποίησης της παραγράφου.

Χρησιμοποιήστε τη μέθοδο [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/#getParagraphFormat) για να αποκτήσετε πρόσβαση στις ρυθμίσεις λίστας σε επίπεδο παραγράφου. Το κύριο σημείο εισόδου είναι το [ParagraphFormat.getBullet](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#getBullet), το οποίο επιστρέφει ένα αντικείμενο [BulletFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/bulletformat/). Με αυτό το αντικείμενο μπορείτε να ορίσετε τον τύπο της κουκκίδας, το σύμβολο, την εικόνα, το χρώμα, το μέγεθος, το στυλ αρίθμησης και τον αρχικό αριθμό.

Αυτό το άρθρο δείχνει πώς να:

- δημιουργήσετε μια λίστα με κουκκίδες χρησιμοποιώντας προσαρμοσμένο σύμβολο
- δημιουργήσετε μια εικόνα-κουκκίδα
- δημιουργήσετε πολυεπίπεδη λίστα ορίζοντας το βάθος της παραγράφου
- δημιουργήσετε μια αριθμημένη λίστα
- ελέγξετε και τροποποιήσετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση

## **Δημιουργία Λίστας με Κουκκίδες**

Για να δημιουργήσετε μια λίστα με κουκκίδες, προσθέστε αντικείμενα [Paragraph](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/) σε ένα [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) και ορίστε το [BulletFormat.setType](https://reference.aspose.com/slides/el/python-java/aspose.slides/bulletformat/#setType) σε [BulletType.Symbol](https://reference.aspose.com/slides/el/python-java/aspose.slides/bullettype/#Symbol). Μπορείτε στη συνέχεια να χρησιμοποιήσετε το [BulletFormat.setChar](https://reference.aspose.com/slides/el/python-java/aspose.slides/bulletformat/#setChar), το [BulletFormat.getColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/bulletformat/#getColor) και το [BulletFormat.setHeight](https://reference.aspose.com/slides/el/python-java/aspose.slides/bulletformat/#setHeight) για να ελέγξετε την εμφάνιση της κουκκίδας.

Ο ακόλουθος κώδικας Python δείχνει πώς να δημιουργήσετε μια λίστα με κουκκίδες σε μια διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Οι σύμβολα κουκκίδας](symbol_bullets.png)

## **Δημιουργία Αριθμημένης Λίστας**

Χρησιμοποιήστε αριθμημένες λιστες όταν η σειρά των στοιχείων έχει σημασία. Ορίστε το [BulletFormat.setType](https://reference.aspose.com/slides/el/python-java/aspose.slides/bulletformat/#setType) σε [BulletType.Numbered](https://reference.aspose.com/slides/el/python-java/aspose.slides/bullettype/#Numbered). Μπορείτε επίσης να επιλέξετε μορφή αρίθμησης με το [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/el/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) ή να χρησιμοποιήσετε το [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/el/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) όταν η λίστα πρέπει να ξεκινήσει από τιμή διαφορετική από το 1.

Ο ακόλουθος κώδικας Python δείχνει πώς να δημιουργήσετε μια αριθμημένη λίστα σε μια διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Οι αριθμημένες κουκκίδες](numbered_bullets.png)

## **Δημιουργία Εικόνας‑Κουκκίδας**

Aspose.Slides σας επιτρέπει να αντικαταστήσετε ένα κανονικό σύμβολο κουκκίδας με μια εικόνα. Οι εικόνες‑κουκκίδες λειτουργούν καλύτερα με απλές εικόνες που παραμένουν ευανάγνωστες σε μικρό μέγεθος, όπως εικονίδια ή μικρά διαφανή αρχεία PNG.

{{% alert color="info" title="Σημείωση" %}}
Αν σκοπεύετε να αντικαταστήσετε ένα κανονικό σύμβολο κουκκίδας με μια εικόνα, επιλέξτε ένα απλό γραφικό με διαφανές φόντο. Τέτοιες εικόνες λειτουργούν καλά ως προσαρμοσμένα σύμβολα κουκκίδας.

Να έχετε κατά νου ότι η εικόνα θα μειωθεί σε πολύ μικρό μέγεθος. Για αυτόν τον λόγο, συνιστούμε έντονα να επιλέξετε μια εικόνα που παραμένει καθαρή και οπτικά αποτελεσματική όταν χρησιμοποιείται ως κουκκίδα σε λίστα.
{{% /alert %}}

Για να δημιουργήσετε μια εικόνα‑κουκκίδα, προσθέστε μια εικόνα στο [Presentation.getImages](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getImages) και εκχωρήστε το επιστρεφόμενο αντικείμενο εικόνας στο [BulletFormat.getPicture](https://reference.aspose.com/slides/el/python-java/aspose.slides/bulletformat/#getPicture). Ορίστε το [BulletFormat.setType](https://reference.aspose.com/slides/el/python-java/aspose.slides/bulletformat/#setType) σε [BulletType.Picture](https://reference.aspose.com/slides/el/python-java/aspose.slides/bullettype/#Picture) πριν εκχωρήσετε την εικόνα.

Έστω ότι έχουμε μια εικόνα με όνομα "image.png":

![Μια εικόνα για τις κουκκίδες](picture_for_bullets.png)

Ο ακόλουθος κώδικας Python δείχνει πώς να δημιουργήσετε εικόνες‑κουκκίδας σε μια διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Οι εικόνες‑κουκκίδες](picture_bullets.png)

## **Δημιουργία Πολυεπίπεδης Λίστας**

Χρησιμοποιήστε το [ParagraphFormat.setDepth](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#setDepth) για να τοποθετήσετε στοιχεία λίστας σε διαφορετικά επίπεδα. Το επίπεδο 0 είναι το κορυφαίο επίπεδο, το επίπεδο 1 είναι ενσωματωμένο κάτω από αυτό, κλπ.

Ο ακόλουθος κώδικας Python δείχνει πώς να δημιουργήσετε μια πολυεπίπεδη λιστα με κουκκίδες:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το αποτέλεσμα:

![Η πολυεπίπεδη λίστα](multilevel_list.png)

## **Τροποποίηση Υπάρχουσας Λίστας**

Για να αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο και ενημερώστε τις ρυθμίσεις της μέσω του [ParagraphFormat.getBullet](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#getBullet). Οι ίδιες ιδιότητες που χρησιμοποιούνται για τη δημιουργία λιστών μπορούν να χρησιμοποιηθούν για τον έλεγχο ή την τροποποίηση λιστών που φορτώθηκαν από αρχείο PPT, PPTX ή ODP.

Ο ακόλουθος κώδικας Python αλλάζει την πρώτη παράγραφο σε ένα πλαίσιο κειμένου ώστε να χρησιμοποιεί στυλ αριθμημένης λίστας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ΣΥΝΗΘΩΜΕΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορούν οι λιστες με κουκκίδες και αριθμημένες λιστες να εξαχθούν σε PDF ή εικόνες;**

Ναι. Το Aspose.Slides διατηρεί τη μορφοποίηση της λίστας όταν η μορφή προορισμού υποστηρίζει την αντίστοιχη διάταξη κειμένου και τις δυνατότητες κουκκίδας.

**Μπορώ να επεξεργαστώ λιστες σε υπάρχουσες παρουσιάσεις;**

Ναι. Φορτώστε την παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο, ελέγξτε ή ενημερώστε τις ρυθμίσεις του [ParagraphFormat.getBullet](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraphformat/#getBullet) και αποθηκεύστε την παρουσίαση.

**Μπορούν οι λιστες να περιέχουν μη‑λατινικό κείμενο;**

Ναι. Το κείμενο των στοιχείων λίστας μπορεί να περιέχει χαρακτήρες Unicode, έτσι ώστε να μπορείτε να δημιουργήσετε λιστες σε πολύγλωσσες παρουσιάσεις. Βεβαιωθείτε ότι οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση υποστηρίζουν τους χαρακτήρες που χρειάζεστε.