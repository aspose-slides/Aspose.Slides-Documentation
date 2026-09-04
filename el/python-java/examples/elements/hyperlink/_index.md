---
title: Υπερσύνδεσμος
type: docs
weight: 130
url: /el/python-java/examples/elements/hyperlink/
keywords:
- παράδειγμα κώδικα
- υπερσύνδεσμος
- προσθήκη υπερσυνδέσμου
- πρόσβαση σε υπερσύνδεσμο
- κατάργηση υπερσυνδέσμου
- ενημέρωση υπερσυνδέσμου
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Προσθέστε και διαχειριστείτε υπερσυνδέσμους στο Aspose.Slides για Python μέσω Java: δημιουργήστε, αποκτήστε πρόσβαση, αφαιρέστε και ενημερώστε συνδέσμους σε παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει την προσθήκη, την πρόσβαση, την κατάργηση και την ενημέρωση υπερσυνδέσμων σε σχήματα χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει η JVM, και στη συνέχεια εισάγει το API αφού η JVM είναι σε λειτουργία.

## **Προσθήκη Υπερσυνδέσμου**

Δημιουργήστε ένα σχήμα ορθογωνίου με έναν υπερσύνδεσμο που οδηγεί σε έναν εξωτερικό ιστότοπο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **Πρόσβαση σε Υπερσύνδεσμο**

Αναγνώστε πληροφορίες υπερσυνδέσμου από το κείμενο ενός σχήματος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **Κατάργηση Υπερσυνδέσμου**

Καθαρίστε τον υπερσύνδεσμο από το κείμενο ενός σχήματος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **Ενημέρωση Υπερσυνδέσμου**

Αλλάξτε τον προορισμό ενός υπάρχοντος υπερσυνδέσμου. Χρησιμοποιήστε το [HyperlinkManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/hyperlinkmanager/) για να τροποποιήσετε κείμενο που ήδη περιέχει υπερσύνδεσμο, προσομοιώνοντας τον τρόπο με τον οποίο το PowerPoint ενημερώνει ασφαλώς τους υπερσυνδέσμους.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # Η αλλαγή ενός υπερσυνδέσμου μέσα σε υπάρχον κείμενο πρέπει να γίνεται μέσω
    # HyperlinkManager αντί για την άμεση ρύθμιση της ιδιότητας.
    # Αυτό μιμείται τον τρόπο με τον οποίο το PowerPoint ενημερώνει με ασφάλεια τους υπερσυνδέσμους.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```