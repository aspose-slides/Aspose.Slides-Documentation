---
title: Διαχείριση λιστών με κουκκίδες και αριθμημένων λιστών σε παρουσιάσεις με Python
linktitle: Διαχείριση Λιστών
type: docs
weight: 70
url: /el/python-net/manage-lists/
keywords:
- κουκκίδα
- λίστα με κουκκίδες
- αριθμημένη λίστα
- συμβολική κουκκίδα
- κουκκίδα εικόνας
- προσαρμοσμένη κουκκίδα
- πολυεπίπεδη λίστα
- δημιουργία κουκκίδας
- προσθήκη κουκκίδας
- προσθήκη λίστας
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε λίστες με κουκκίδες, εικόνας, πολυεπίπεδες και αριθμημένες σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Το Aspose.Slides για Python μέσω .NET σας επιτρέπει να δημιουργείτε και να μορφοποιείτε λίστες με κουκκίδες και αριθμημένους λίστες σε παρουσιάσεις PowerPoint και OpenDocument. Ένα στοιχείο λίστας είναι μια παράγραφος της οποίας οι ρυθμίσεις της κουκίδας ελέγχονται μέσω της μορφοποίησης της παραγράφου.

Χρησιμοποιήστε την ιδιότητα [Paragraph.paragraph_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/paragraph_format/) για πρόσβαση στις ρυθμίσεις λίστας επιπέδου παραγράφου. Το κύριο σημείο εισόδου είναι το [ParagraphFormat.bullet](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/bullet/), το οποίο επιστρέφει ένα αντικείμενο [BulletFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/). Με αυτό το αντικείμενο, μπορείτε να ορίσετε τον τύπο της κουκίδας, το σύμβολο, την εικόνα, το χρώμα, το μέγεθος, το στυλ αρίθμησης και τον αρχικό αριθμό.

Αυτό το άρθρο δείχνει πώς να:

- δημιουργήσετε μια λίστα με κουκκίδες με προσαρμοσμένο σύμβολο
- δημιουργήσετε μια κουκκίδα εικόνας
- δημιουργήσετε μία πολυεπίπεδη λίστα ορίζοντας το βάθος της παραγράφου
- δημιουργήσετε μια αριθμημένη λίστα
- εξετάσετε και αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση

## **Δημιουργία λίστας με κουκκίδες**

Για να δημιουργήσετε μια λίστα με κουκκίδες, προσθέστε αντικείμενα [Paragraph](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraph/) σε ένα [TextFrame](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/) και ορίστε το [BulletFormat.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/type/) σε [BulletType.SYMBOL](https://reference.aspose.com/slides/el/python-net/aspose.slides/bullettype/). Στη συνέχεια μπορείτε να ορίσετε το [BulletFormat.char](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/char/), το [BulletFormat.color](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/color/) και το [BulletFormat.height](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/height/) για να ελέγξετε την εμφάνιση της κουκίδας.

Ο παρακάτω κώδικας Python δείχνει πώς να δημιουργήσετε μια λίστα με κουκκίδες σε μια διαφάνεια:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι συμβολικές κουκκίδες](symbol_bullets.png)

## **Δημιουργία αριθμημένης λίστας**

Χρησιμοποιήστε αριθμημένες λίστες όταν η σειρά των στοιχείων έχει σημασία. Ορίστε το [BulletFormat.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/type/) σε [BulletType.NUMBERED](https://reference.aspose.com/slides/el/python-net/aspose.slides/bullettype/). Μπορείτε επίσης να επιλέξετε μορφή αρίθμησης με το [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/numbered_bullet_style/) ή να ορίσετε το [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) όταν η λίστα πρέπει να ξεκινήσει από τιμή διαφορετική από το 1.

Ο παρακάτω κώδικας Python δείχνει πώς να δημιουργήσετε μια αριθμημένη λίστα σε μια διαφάνεια:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι αριθμημένες κουκκίδες](numbered_bullets.png)

## **Δημιουργία κουκκίδας εικόνας**

Το Aspose.Slides σας επιτρέπει να αντικαταστήσετε ένα κανονικό σύμβολο κουκίδας με εικόνα. Οι κουκκίδες εικόνας λειτουργούν καλύτερα με απλές εικόνες που παραμένουν αναγνώσιμες σε μικρό μέγεθος, όπως εικονίδια ή μικρά διαφανή αρχεία PNG.

{{% alert color="primary" %}}
Ιδανικά, εάν σκοπεύετε να αντικαταστήσετε το κανονικό σύμβολο κουκίδας με εικόνα, είναι καλύτερο να επιλέξετε ένα απλό γραφικό με διαφανές φόντο. Τέτοιες εικόνες λειτουργούν καλά ως προσαρμοσμένα σύμβολα κουκίδας.

Λάβετε υπόψη ότι η εικόνα θα κλιμακωθεί σε πολύ μικρό μέγεθος. Για αυτόν τον λόγο, συνιστούμε έντονα να επιλέξετε μια εικόνα που παραμένει καθαρή και οπτικά αποτελεσματική όταν χρησιμοποιείται ως κουκίδα σε λίστα.
{{% /alert %}}

Για να δημιουργήσετε μια κουκκίδα εικόνας, προσθέστε μια εικόνα στο [Presentation.images](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/images/) και αντιστοιχίστε το επιστρεφόμενο αντικείμενο εικόνας στο [BulletFormat.picture](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/picture/). Ορίστε το [BulletFormat.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/bulletformat/type/) σε [BulletType.PICTURE](https://reference.aspose.com/slides/el/python-net/aspose.slides/bullettype/) πριν αντιστοιχίσετε την εικόνα.

Ας υποθέσουμε ότι έχουμε ένα "image.png":

![Μια εικόνα για τις κουκκίδες](picture_for_bullets.png)

Ο παρακάτω κώδικας Python δείχνει πώς να δημιουργήσετε κουκκίδες εικόνας σε μια διαφάνεια:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Οι εικόνες-κουκκίδες](picture_bullets.png)

## **Δημιουργία πολυεπίπεδης λίστας**

Χρησιμοποιήστε το [ParagraphFormat.depth](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/depth/) για να τοποθετήσετε στοιχεία λίστας σε διαφορετικά επίπεδα. Το επίπεδο 0 είναι το κορυφαίο επίπεδο, το επίπεδο 1 είναι ενσωματωμένο κάτω από αυτό, κ.ο.κ.

Ο παρακάτω κώδικας Python δείχνει πώς να δημιουργήσετε μια πολυεπίπεδη λιστα με κουκκίδες:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Το αποτέλεσμα:

![Η πολυεπίπεδη λίστα](multilevel_list.png)

## **Αλλαγή υπάρχουσας λίστας**

Για να αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση, προσπελάστε τη στοχευόμενη παράγραφο και ενημερώστε τις ρυθμίσεις της [ParagraphFormat.bullet](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/bullet/). Οι ίδιες ιδιότητες που χρησιμοποιούνται για τη δημιουργία λιστών μπορούν να χρησιμοποιηθούν για την εξέταση ή τροποποίηση λιστών που έχουν φορτωθεί από αρχείο PPT, PPTX ή ODP.

Ο παρακάτω κώδικας Python αλλάζει την πρώτη παράγραφο σε ένα πλαίσιο κειμένου ώστε να χρησιμοποιεί στυλ αριθμημένης λίστας:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές ερωτήσεις**

**Μπορούν οι λίστες με κουκκίδες και οι αριθμημένες λίστες να εξαχθούν σε PDF ή εικόνες;**

Ναι. Το Aspose.Slides διατηρεί τη μορφοποίηση των λιστών όταν η μορφή προορισμού υποστηρίζει την αντίστοιχη διάταξη κειμένου και τις δυνατότητες κουκκίδας.

**Μπορώ να επεξεργαστώ τις λίστες σε υπάρχουσες παρουσιάσεις;**

Ναι. Φορτώστε την παρουσίαση, προσπελάστε τη στοχευόμενη παράγραφο, ελέγξτε ή ενημερώστε τις ρυθμίσεις της [ParagraphFormat.bullet](https://reference.aspose.com/slides/el/python-net/aspose.slides/paragraphformat/bullet/) και αποθηκεύστε την παρουσίαση.

**Μπορούν οι λίστες να περιέχουν μη-λατινικό κείμενο;**

Ναι. Το κείμενο των στοιχείων λίστας μπορεί να περιέχει χαρακτήρες Unicode, έτσι μπορείτε να δημιουργήσετε λίστες σε πολύγλωσσες παρουσιάσεις. Βεβαιωθείτε ότι οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση υποστηρίζουν τους χαρακτήρες που χρειάζεστε.