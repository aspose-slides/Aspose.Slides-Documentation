---
title: Σύνδεσμος
type: docs
weight: 190
url: /el/python-java/examples/elements/connector/
keywords:
- παράδειγμα κώδικα
- σύνδεσμος
- προσθήκη συνδέσμου
- πρόσβαση σε σύνδεσμο
- αφαίρεση συνδέσμου
- επανασύνδεση σχημάτων
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να έχετε πρόσβαση, να αφαιρείτε και να επανασυνδέετε σχήματα με συνδέσμους χρησιμοποιώντας το Aspose.Slides για Python μέσω Java σε παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να συνδέσετε σχήματα με σύνδεσμους και να αλλάξετε τους προορισμούς τους χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει η JVM, και, στη συνέχεια, εισάγει το API όταν η JVM εκτελείται.

## **Προσθήκη Συνδέσμου**

Εισάγετε ένα σχήμα σύνδεσμου μεταξύ δύο σημείων στη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε Σύνδεσμο**

Ανακτήστε το πρώτο σχήμα σύνδεσμου που προστέθηκε σε μια διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Connector, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    # Πρόσβαση στον πρώτο σύνδεσμο στη διαφάνεια.
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **Αφαίρεση Συνδέσμου**

Διαγράψτε έναν σύνδεσμο από τη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    slide.getShapes().remove(connector)
finally:
    presentation.dispose()
```

## **Επανασύνδεση Σχημάτων**

Συνδέστε έναν σύνδεσμο σε δύο σχήματα ορίζοντας ως στόχους την αρχή και το τέλος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    connector.setStartShapeConnectedTo(shape1)
    connector.setEndShapeConnectedTo(shape2)
finally:
    presentation.dispose()
```