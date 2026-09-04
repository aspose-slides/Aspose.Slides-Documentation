---
title: Αντικείμενο OLE
type: docs
weight: 210
url: /el/python-java/examples/elements/ole-object/
keywords:
- παράδειγμα κώδικα
- αντικείμενο OLE
- προσθήκη αντικειμένου OLE
- πρόσβαση σε αντικείμενο OLE
- κατάργηση αντικειμένου OLE
- ενημέρωση αντικειμένου OLE
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides για Python μέσω Java για να προσθέσετε, να έχετε πρόσβαση, να αφαιρέσετε και να ενημερώσετε αντικείμενα OLE σε παρουσιάσεις PowerPoint και OpenDocument."
---
Αυτό το άρθρο δείχνει πώς να ενσωματώσετε ένα αρχείο ως αντικείμενο OLE και να ενημερώσετε τα δεδομένα του χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Εγκατάσταση](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει η JVM, και μετά εισάγει το API όταν η JVM εκτελείται.

## **Προσθήκη αντικειμένου OLE**

Ενσωματώστε ένα αρχείο PDF στην παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε αντικείμενο OLE**

Ανακτήστε το πρώτο πλαίσιο αντικειμένου OLE σε μια διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    first_ole_frame = None
    for shape in slide.getShapes():
        if isinstance(shape, OleObjectFrame):
            first_ole_frame = shape
            break

    if first_ole_frame is None:
        print("The slide contains no OLE object frames.")
finally:
    presentation.dispose()
```

## **Κατάργηση αντικειμένου OLE**

Διαγράψτε ένα ενσωματωμένο αντικείμενο OLE από τη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    slide.getShapes().remove(ole_frame)
finally:
    presentation.dispose()
```

## **Ενημέρωση δεδομένων αντικειμένου OLE**

Αντικαταστήστε τα δεδομένα που είναι ενσωματωμένα σε ένα υπάρχον αντικείμενο OLE.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    new_data = Files.readAllBytes(Paths.get("Picture.png"))
    new_data_info = OleEmbeddedDataInfo(new_data, "png")
    ole_frame.setEmbeddedData(new_data_info)
finally:
    presentation.dispose()
```