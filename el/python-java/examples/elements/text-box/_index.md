---
title: Πλαίσιο Κειμένου
type: docs
weight: 40
url: /el/python-java/examples/elements/text-box/
keywords:
- παράδειγμα κώδικα
- πλαίσιο κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Εργαστείτε με πλαίσια κειμένου στο Aspose.Slides για Python μέσω Java: προσθέστε, μορφοποιήστε, βρείτε και αφαιρέστε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument."
---
Στο **Aspose.Slides for Python via Java**, ένα πλαίσιο κειμένου είναι ένα αυτόματο σχήμα που περιέχει κείμενο. Σχεδόν οποιοδήποτε σχήμα μπορεί να περιέχει κείμενο, αλλά ένα τυπικό πλαίσιο κειμένου δεν έχει γέμισμα ή περιθώριο και εμφανίζει μόνο κείμενο.

Αυτός ο οδηγός εξηγεί πώς να προσθέσετε, να αποκτήσετε πρόσβαση και να αφαιρέσετε πλαίσια κειμένου προγραμματιστικά.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Εγκατάσταση](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει η JVM, και στη συνέχεια εισάγει το API αφού η JVM είναι ενεργή.

## **Προσθήκη Πλαισίου Κειμένου**

Δημιουργήστε ένα ορθογώνιο, αφαιρέστε το γέμισμα και το περιθώριο του, και αναθέστε μορφοποιημένο κείμενο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Δημιουργία σχήματος ορθογωνίου.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # Αφαίρεση γεμίσματος και περιγράμματος για προβολή μόνο του κειμένου.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # Ορισμός προεπιλεγμένης μορφοποίησης κειμένου.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **Πρόσβαση σε Πλαίσια Κειμένου κατά Περιεχόμενο**

Προσθέστε ένα παράδειγμα πλαισίου κειμένου, στη συνέχεια βρείτε σχήματα των οποίων το κείμενο περιέχει τη λέξη-κλειδί "Slide".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # Χρήση του αντίστοιχου πλαισίου κειμένου.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **Αφαίρεση Πλαισίων Κειμένου κατά Περιεχόμενο**

Βρείτε και διαγράψτε τα πλαίσια κειμένου στην πρώτη διαφάνεια που περιέχουν συγκεκριμένη λέξη-κλειδί.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Συμβουλή" %}}
Συλλέξτε τα ταιριαστά σχήματα σε ξεχωριστή λίστα πριν τα διαγράψετε, ώστε να αποφύγετε την τροποποίηση της συλλογής σχημάτων κατά την επανάληψη.
{{% /alert %}}