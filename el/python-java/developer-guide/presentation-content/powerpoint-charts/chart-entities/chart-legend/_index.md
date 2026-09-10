---
title: Προσαρμογή των λεζαντών διαγραμμάτων σε παρουσιάσεις χρησιμοποιώντας Python
linktitle: Λεζάντα Διαγράμματος
type: docs
url: /el/python-java/chart-legend/
keywords:
- λεζάντα διαγράμματος
- θέση λεζάντας
- μέγεθος γραμματοσειράς
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Προσαρμόστε τις λεζάντες διαγραμμάτων με το Aspose.Slides για Python μέσω Java για να βελτιστοποιήσετε τις παρουσιάσεις PowerPoint με προσαρμοσμένη μορφοποίηση λεζάντας."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει επιλογές για την προσαρμογή των λεζάντων διαγραμμάτων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο δείχνει πώς να τοποθετήσετε και να ρυθμίσετε το μέγεθος μιας λεζάντας, να ορίσετε το μέγεθος γραμματοσειράς για ολόκληρη τη λεζάντα και να εφαρμόσετε μορφοποίηση σε μεμονωμένη καταχώριση λεζάντας.

Καλύπτει επίσης διάφορες σχετικές συμπεριφορές στις Συχνές Ερωτήσεις, όπως η χρήση μη‑επικάλυπτης λειτουργίας ώστε η περιοχή σχεδίου να αφήνει χώρο για τη λεζάντα, η δυνατότητα περιτύλιξης ή χρήσης αλλαγών γραμμής για μακρές ετικέτες λεζάντας, και η κληρονομιά μορφοποίησης της λεζάντας από το θέμα της παρουσίασης όταν δεν έχουν οριστεί ρητά κείμενο και ρυθμίσεις γεμίσματος.

## **Τοποθέτηση Λεζάντας**

Για να ορίσετε τις ιδιότητες της λεζάντας, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Πάρτε μια αναφορά στη διαφάνεια.
1. Προσθέστε ένα γράφημα στη διαφάνεια.
1. Ορίστε τις ιδιότητες της λεζάντας.
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Το παρακάτω παράδειγμα ορίζει τη θέση και το μέγεθος μιας λεζάντας γραφήματος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Δημιουργήστε μια κενή παρουσίαση.
presentation = Presentation()
try:
    # Λάβετε μια αναφορά στη διαφάνεια.
    slide = presentation.getSlides().get_Item(0)

    # Προσθέστε ένα διαγράφημα ομαδοποιημένων στηλών στη διαφάνεια.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Ορίστε τις ιδιότητες της λεζάντας.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Μεγέθους Γραμματοσειράς Λεζάντας**

Το Aspose.Slides for Python via Java σας επιτρέπει να ορίσετε το μέγεθος γραμματοσειράς μιας λεζάντας. Ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Δημιουργήστε το προεπιλεγμένο γράφημα.
1. Ορίστε το μέγεθος γραμματοσειράς.
1. Ορίστε την ελάχιστη τιμή άξονα.
1. Ορίστε τη μέγιστη τιμή άξονα.
1. Αποθηκεύστε την παρουσίαση στο δίσκο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Δημιουργήστε μια κενή παρουσίαση.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Μεγέθους Γραμματοσειράς Μεμονωμένης Καταχώρισης Λεζάντας**

Το Aspose.Slides for Python via Java σας επιτρέπει να ορίσετε το μέγεθος γραμματοσειράς για μεμονωμένες καταχωρίσεις λεζάντας. Ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Δημιουργήστε το προεπιλεγμένο γράφημα.
1. Πρόσβαση σε μια καταχώριση λεζάντας.
1. Ορίστε το μέγεθος γραμματοσειράς.
1. Αποθηκεύστε την παρουσίαση στο δίσκο.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Δημιουργήστε μια κενή παρουσίαση.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω τη λεζάντα ώστε το γράφημα να κατανέμει αυτόματα χώρο για αυτήν αντί να την επικαλύπτει;**

Ναι. Χρησιμοποιήστε το [setOverlay](https://reference.aspose.com/slides/el/python-java/aspose.slides/legend/#setOverlay) με `False` για να ενεργοποιήσετε τη μη‑επικάλυπτη λειτουργία· σε αυτήν την περίπτωση η περιοχή σχεδίου θα μικρύνει για να φιλοξενήσει τη λεζάντα.

**Μπορώ να δημιουργήσω ετικέτες λεζάντας πολλών γραμμών;**

Ναι. Οι μακρές ετικέτες περιτυλίγονται αυτόματα όταν ο χώρος είναι περιορισμένος· οι αναγκαστικές αλλαγές γραμμής υποστηρίζονται μέσω χαρακτήρων νέας γραμμής στο όνομα της σειράς.

**Πώς μπορώ η λεζάντα να ακολουθεί το χρωματικό σχήμα του θέματος της παρουσίασης;**

Μην ορίσετε ρητά χρώματα, γεμίσματα ή γραμματοσειρές για τη λεζάντα ή το κείμενό της. Θα κληρονομήσουν τότε από το θέμα και θα ενημερώνονται σωστά όταν το σχέδιο αλλάζει.