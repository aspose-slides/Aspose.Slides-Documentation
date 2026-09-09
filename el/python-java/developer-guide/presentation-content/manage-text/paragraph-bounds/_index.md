---
title: Λήψη Ορίων Παραγράφου από Παρουσιάσεις σε Python μέσω Java
linktitle: Όρια Παραγράφου
type: docs
weight: 43
url: /el/python-java/paragraph-bounds/
keywords:
- όρια παραγράφου
- συντεταγμένη παραγράφου
- μέγεθος παραγράφου
- πλαίσιο κειμένου
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να ανακτήσετε τα όρια παραγράφου στο Aspose.Slides για Python μέσω Java ώστε να βελτιστοποιήσετε τη θέση του κειμένου στις παρουσιάσεις PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να λάβετε τα όρια, το μέγεθος και τις συντεταγμένες των παραγράφων στο Aspose.Slides. Δείχνει πώς να ανακτήσετε ένα ορθογώνιο παραγράφου από ένα [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/) χρησιμοποιώντας την [Paragraph.getRect](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/#getRect), πώς να λάβετε τις συντεταγμένες παραγράφου μέσα σε πλαίσιο κειμένου κελιού πίνακα, και αναδεικνύει σημαντικές λεπτομέρειες όπως οι μονάδες μέτρησης, η επίπτωση της αναδίπλωσης κειμένου στα όρια, η μετατροπή σε pixel και οι αποτελεσματικές τιμές μορφοποίησης παραγράφου.

## **Λήψη Ορθογώνιων Συντεταγμένων μιας Παραγράφου**

Χρησιμοποιήστε την [Paragraph.getRect](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/#getRect) για να λάβετε το περιοριστικό ορθογώνιο μιας παραγράφου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **Λήψη του Μεγέθους μιας Παραγράφου μέσα σε Πλαίσιο Κειμένου Κελιού Πίνακα**

Για να λάβετε το μέγεθος και τις συντεταγμένες ενός [Paragraph](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/) σε πλαίσιο κειμένου κελιού πίνακα, χρησιμοποιήστε την [Paragraph.getRect](https://reference.aspose.com/slides/el/python-java/aspose.slides/paragraph/#getRect). Το επιστρεφόμενο ορθογώνιο είναι σχετικά με το πλαίσιο κειμένου του κελιού πίνακα, επομένως προσθέστε τη θέση του πίνακα και την απόσταση του κελιού όταν χρειάζεστε συντεταγμένες επιπέδου διαφάνειας.

Το παρακάτω παράδειγμα λαμβάνει τα όρια της παραγράφου μέσα σε κελί πίνακα και σχεδιάζει ορθογώνια στη διαφάνεια για να οπτικοποιήσει αυτά τα όρια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Σε ποιες μονάδες μετρώνται οι συντεταγμένες της παραγράφου;**

Μετρώνται σε πόντους, όπου 1 ίντσα ισούται με 72 πόντους. Αυτό ισχύει για όλες τις συντεταγμένες και διαστάσεις στη διαφάνεια.

**Επηρεάζει η αναδίπλωση κειμένου τα όρια μιας παραγράφου;**

Ναι. Εάν η μέθοδος [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframeformat/#setWrapText) είναι ενεργοποιημένη για το [TextFrame](https://reference.aspose.com/slides/el/python-java/aspose.slides/textframe/), το κείμενο σπάει ώστε να ταιριάζει στο πλάτος της περιοχής, κάτι που αλλάζει τα πραγματικά όρια της παραγράφου.

**Μπορούν οι συντεταγμένες μιας παραγράφου να αντιστοιχιστούν αξιόπιστα σε pixel στην εξαγόμενη εικόνα;**

Ναι. Μετατρέψτε τους πόντους σε pixel χρησιμοποιώντας αυτόν τον τύπο: pixels = points x (DPI / 72). Το αποτέλεσμα εξαρτάται από το DPI που επιλέγεται για την απόδοση ή εξαγωγή.

**Πώς μπορώ να λάβω τις «αποτελεσματικές» παραμέτρους μορφοποίησης μιας παραγράφου, λαμβάνοντας υπόψη την κληρονομικότητα στυλ;**

Χρησιμοποιήστε τη [δομή δεδομένων αποτελεσματικής μορφοποίησης παραγράφων](/slides/el/python-java/shape-effective-properties/); επιστρέφει τις τελικές ενοποιημένες τιμές για εσοχές, απόσταση, αναδίπλωση, RTL και άλλα.