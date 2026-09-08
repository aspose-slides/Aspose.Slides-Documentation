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
- αφαίρεση αντικειμένου OLE
- ενημέρωση αντικειμένου OLE
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides for Python via Java για να προσθέσετε, να αποκτήσετε πρόσβαση, να αφαιρέσετε και να ενημερώσετε αντικείμενα OLE σε παρουσιάσεις PowerPoint και OpenDocument."
---
Αυτό το άρθρο επιδεικνύει πώς να ενσωματώσετε ένα αρχείο ως αντικείμενο OLE και να ενημερώσετε τα δεδομένα του χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Εγκατάσταση](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει η JVM, και στη συνέχεια εισάγει το API αφού η JVM είναι σε λειτουργία.

## **Προσθήκη ενός αντικειμένου OLE**

Ενσωματώστε ένα αρχείο PDF στην παρουσίαση.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε αντικείμενο OLE**

Ανακτήστε το πρώτο πλαίσιο αντικειμένου OLE σε μια διαφάνεια.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
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

## **Αφαίρεση αντικειμένου OLE**

Διαγράψτε ένα ενσωματωμένο αντικείμενο OLE από τη διαφάνεια.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    slide.getShapes().remove(ole_frame)
finally:
    presentation.dispose()
```

## **Ενημέρωση δεδομένων αντικειμένου OLE**

Αντικαταστήστε τα δεδομένα που είναι ενσωματωμένα σε ένα υπάρχον αντικείμενο OLE.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    new_data = Path("Picture.png").read_bytes()
    java_new_data = jpype.JArray(jpype.JByte)(new_data)
    new_data_info = OleEmbeddedDataInfo(java_new_data, "png")
    ole_frame.setEmbeddedData(new_data_info)
finally:
    presentation.dispose()
```