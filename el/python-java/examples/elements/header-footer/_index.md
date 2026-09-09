---
title: Κεφαλίδα και Υποσέλιδο
type: docs
weight: 220
url: /el/python-java/examples/elements/header-footer/
keywords:
- παράδειγμα κώδικα
- κεφαλίδα
- υποσέλιδο
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Χειρισμός κεφαλίδων και υποσέλιδων διαφάνειας με Aspose.Slides για Python μέσω Java: προσθήκη ημερομηνιών, αριθμών διαφανειών και προσαρμοσμένου κειμένου σε παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε υποσέλιδες και να ενημερώσετε τα δεσμευόμενα θέσεις ημερομηνίας και ώρας χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει η JVM, και έπειτα εισάγει το API αφού η JVM τρέχει.

## **Προσθήκη Υποσέλιδου**

Προσθέστε κείμενο στην περιοχή υποσέλιδου μιας διαφάνειας ώστε να είναι εμφανές.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **Ενημέρωση Ημερομηνίας και Ώρας**

Τροποποιήστε το δεσμευόμενο στοιχείο ημερομηνίας και ώρας σε μια διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```