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
description: "Διαχειριστείτε τις κεφαλίδες και τα υποσέλιδα των διαφανειών με το Aspose.Slides για Python μέσω Java: προσθέστε ημερομηνίες, αριθμούς διαφανειών και προσαρμοσμένο κείμενο σε παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε υποσέλιδα και να ενημερώσετε τα placeholders ημερομηνίας και ώρας χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην ενότητα [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει η JVM, και στη συνέχεια εισάγει το API αφού η JVM είναι σε λειτουργία.

## **Προσθήκη Υποσέλιδου**

Προσθέστε κείμενο στην περιοχή του υποσέλιδου μιας διαφάνειας και κάντε το ορατό.

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

Τροποποιήστε το placeholder ημερομηνίας και ώρας σε μια διαφάνεια.

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