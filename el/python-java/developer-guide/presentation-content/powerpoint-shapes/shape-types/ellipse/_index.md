---
title: Προσθήκη Ελλειψών σε Παρουσιάσεις σε Python μέσω Java
linktitle: Έλλειψη
type: docs
weight: 30
url: /el/python-java/ellipse/
keywords:
- έλλειψη
- σχήμα
- προσθήκη έλλειψης
- δημιουργία έλλειψης
- σχεδίαση έλλειψης
- μορφοποιημένη έλλειψη
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε, μορφοποιείτε και να χειρίζεστε σχήματα έλλειψης στο Aspose.Slides για Python μέσω Java σε παρουσιάσεις PPT και PPTX — περιλαμβάνονται παραδείγματα κώδικα Python."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να προσθέσετε σχήματα ελλείψεων σε διαφάνειες PowerPoint χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη δημιουργία ενός απλού ελλειψοειδούς, τη δημιουργία ενός μορφοποιημένου ελλειψοειδούς και την αποθήκευση της ενημερωμένης παρουσίασης ως αρχείο PPTX. Επίσης, αγγίζει σχετικές ερωτήσεις όπως η εργασία με τη θέση και το μέγεθος του ελλειψοειδούς, ο έλεγχος της σειράς στοίβασης και η εφαρμογή εφέ κίνησης.

## **Δημιουργία Ελλειψοειδούς**

Για να προσθέσετε ένα απλό ελλειψοειδές σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
- Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
- Προσθέστε ένα ελλειψοειδές χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addAutoShape) του αντικειμένου [ShapeCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/).
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το παρακάτω παράδειγμα προσθέτει ένα ελλειψοειδές στην πρώτη διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Δημιουργία στιγμιότυπου της κλάσης Presentation που αντιπροσωπεύει το αρχείο PPTX.
presentation = Presentation()
try:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη σχήματος έλλειψης.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Εγγραφή του αρχείου PPTX στο δίσκο.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Δημιουργία Μορφοποιημένου Ελλειψοειδούς**

Για να προσθέσετε ένα μορφοποιημένο ελλειψοειδές σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
- Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
- Προσθέστε ένα ελλειψοειδές χρησιμοποιώντας τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/#addAutoShape) του αντικειμένου [ShapeCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/).
- Ορίστε τον τύπο γεμίσματος του ελλειψοειδούς σε συμπαγές.
- Ορίστε το χρώμα γεμίσματος του ελλειψοειδούς μέσω της μεθόδου [getSolidFillColor](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/#getSolidFillColor) στο αντικείμενο [FillFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/fillformat/) που συνδέεται με το αντικείμενο [Shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/shape/).
- Ορίστε το χρώμα του περιγράμματος του ελλειψοειδούς.
- Ορίστε το πλάτος του περιγράμματος του ελλειψοειδούς.
- Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το παρακάτω παράδειγμα προσθέτει ένα μορφοποιημένο ελλειψοειδές στην πρώτη διαφάνεια της παρουσίασης:

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Δημιουργία στιγμιότυπου της κλάσης Presentation που αντιπροσωπεύει το αρχείο PPTX.
presentation = Presentation()
try:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη σχήματος έλλειψης.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Μορφοποίηση γεμίσματος του ελλειψοειδούς.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Μορφοποίηση περιγράμματος του ελλειψοειδούς.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # Εγγραφή του αρχείου PPTX στο δίσκο.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ορίσω τη ακριβή θέση και το μέγεθος ενός ελλειψοειδούς σε σχέση με τις μονάδες της διαφάνειας;**

Οι συντεταγμένες και τα μεγέθη συνήθως καθορίζονται **σε σημεία**. Για προβλέψιμα αποτελέσματα, βασίστε τους υπολογισμούς σας στο μέγεθος της διαφάνειας και μετατρέψτε τα απαιτούμενα χιλιοστά ή ίντσες σε σημεία πριν αναθέσετε τις τιμές.

**Πώς μπορώ να τοποθετήσω ένα ελλειψοειδές πάνω ή κάτω από άλλα αντικείμενα (έλεγχος σειράς στοίβασης);**

Ρυθμίστε τη σειρά σχεδίασης του αντικειμένου φέροντας το μπροστά ή στέλνοντάς το πίσω. Αυτό επιτρέπει στο ελλειψοειδές να επικαλύπτει άλλα αντικείμενα ή να αποκαλύπτει αυτά που βρίσκονται κάτω του.

**Πώς μπορώ να κινήσω την εμφάνιση ή την έμφαση ενός ελλειψοειδούς;**

[Apply](/slides/el/python-java/shape-animation/) εφέ εισόδου, έμφασης ή εξόδου στο σχήμα, και διαμορφώστε εναύσματα και χρονισμούς για να οργανώσετε πότε και πώς θα εκτελείται η κίνηση.