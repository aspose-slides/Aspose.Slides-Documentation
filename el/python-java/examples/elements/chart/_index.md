---
title: Διάγραμμα
type: docs
weight: 60
url: /el/python-java/examples/elements/chart/
keywords:
- διάγραμμα
- προσθήκη διαγράμματος
- πρόσβαση σε διάγραμμα
- αφαίρεση διαγράμματος
- ενημέρωση διαγράμματος
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε, αποκτήστε πρόσβαση, αφαιρέστε και ενημερώστε διαγράμματα σε παρουσιάσεις PowerPoint και OpenDocument με Aspose.Slides για Python μέσω Java."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε, να αποκτήσετε πρόσβαση, να αφαιρέσετε και να ενημερώσετε διαγράμματα σε μια παρουσίαση χρησιμοποιώντας **Aspose.Slides for Python via Java**.

Εγκαταστήστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/python-java/installation/). Κάθε παράδειγμα εισάγει το `asposeslides` πριν ξεκινήσει το JVM, στη συνέχεια εισάγει το API αφού το JVM είναι σε λειτουργία. Εκτελέστε πρώτα το παράδειγμα προσθήκης για να δημιουργήσετε το `chart.pptx` για τα υπόλοιπα παραδείγματα.

## **Προσθήκη διαγράμματος**

Προσθέστε ένα διάγραμμα περιοχής στην πρώτη διαφάνεια και αποθηκεύστε την παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη διαγράμματος περιοχής στην πρώτη διαφάνεια.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Πρόσβαση σε διάγραμμα**

Βρείτε το πρώτο διάγραμμα στη συλλογή σχήματος στην πρώτη διαφάνεια.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Πρόσβαση στο πρώτο διάγραμμα στη διαφάνεια.
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **Αφαίρεση διαγράμματος**

Αφαιρέστε το πρώτο διάγραμμα από τη διαφάνεια και αποθηκεύστε την τροποποιημένη παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Βρείτε και αφαιρέστε το πρώτο διάγραμμα στη διαφάνεια.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ενημέρωση δεδομένων διαγράμματος**

Προβάλετε τον τίτλο του διαγράμματος, αλλάξτε το κείμενό του και αποθηκεύστε την ενημερωμένη παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Βρείτε το πρώτο διάγραμμα στη διαφάνεια.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # Εμφανίστε τον τίτλο του διαγράμματος και αλλάξτε το κείμενό του.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```