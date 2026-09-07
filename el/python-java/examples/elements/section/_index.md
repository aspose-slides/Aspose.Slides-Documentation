---
title: Ενότητα
type: docs
weight: 90
url: /el/python-java/examples/elements/section/
keywords:
- παράδειγμα κώδικα
- ενότητα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις ενότητες παρουσίασης στο Aspose.Slides για Python μέσω Java: προσθέστε, αποκτήστε πρόσβαση, αφαιρέστε και μετονομάστε ενότητες με παραδείγματα κώδικα Python."
---
Παραδείγματα διαχείρισης ενοτήτων παρουσίασης—προσθήκη, πρόσβαση, διαγραφή και μετονομασία τους προγραμματιστικά χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει το JVM και, στη συνέχεια, εισάγει το API μετά την εκκίνηση του JVM.

## **Προσθήκη ενότητας**

Δημιουργήστε μια ενότητα που αρχίζει από μια συγκεκριμένη διαφάνεια.

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Καθορίστε τη διαφάνεια που σηματοδοτεί την αρχή της ενότητας.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε ενότητα**

Διαβάστε τις πληροφορίες της ενότητας από μια παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # Πρόσβαση σε ενότητα με δείκτη.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Κατάργηση ενότητας**

Διαγράψτε μια προηγούμενα προστιθέμενη ενότητα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # Αφαιρέστε την πρώτη ενότητα.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Μετονομασία ενότητας**

Αλλάξτε το όνομα μιας υπάρχουσας ενότητας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```