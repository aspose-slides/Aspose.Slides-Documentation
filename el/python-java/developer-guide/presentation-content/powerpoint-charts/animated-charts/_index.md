---
title: Κινούμενα διαγράμματα PowerPoint σε Python μέσω Java
linktitle: Κινούμενα Διαγράμματα
type: docs
weight: 80
url: /el/python-java/animated-charts/
keywords:
- διάγραμμα
- κινούμενο διάγραμμα
- κίνηση διαγράμματος
- σειρά διαγράμματος
- κατηγορία διαγράμματος
- στοιχείο σειράς
- στοιχείο κατηγορίας
- προσθήκη εφέ
- τύπος εφέ
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε εκπληκτικά κινούμενα διαγράμματα σε Python μέσω Java με το Aspose.Slides. Αναβαθμίστε τις παρουσιάσεις με δυναμικά οπτικά στοιχεία σε αρχεία PPT και PPTX — ξεκινήστε τώρα."
---
## **Εισαγωγή**

Το Aspose.Slides for Python via Java υποστηρίζει την κίνηση στοιχείων γραφήματος. Τα **Σειρές**, **Κατηγορίες**, **Στοιχεία Σειρών** και **Στοιχεία Κατηγορίας** μπορούν να κινούνται χρησιμοποιώντας τη μέθοδο [Sequence.addEffect](https://reference.aspose.com/slides/el/python-java/aspose.slides/sequence/#addEffect) και δύο απαριθμήσεις: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/el/python-java/aspose.slides/effectchartmajorgroupingtype/) και [EffectChartMinorGroupingType](https://reference.aspose.com/slides/el/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Κίνηση Σειρών Γραφήματος**

Αν θέλετε να δημιουργήσετε κίνηση για μια σειρά γραφήματος, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε αναφορά στο αντικείμενο γραφήματος.
1. Δημιουργήστε κίνηση στη σειρά.
1. Αποθηκεύστε το αρχείο παρουσίασης στο δίσκο.

Το παρακάτω παράδειγμα δημιουργεί κίνηση σε σειρές γραφήματος. Το γράφημα στο αρχείο παραδείγματος έχει τρεις σειρές, έτσι προστίθεται ένα εφέ για κάθε δείκτη από 0 έως 2. Το Aspose.Slides δεν ελέγχει τον δείκτη σε σχέση με τα δεδομένα του γραφήματος, και ένα εφέ που προστίθεται για σειρά που δεν υπάρχει γράφεται στο αρχείο αλλά δεν δημιουργεί κίνηση — διατηρήστε τον δείκτη κάτω από τον αριθμό των σειρών στο δικό σας γράφημα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Φορτώστε την παρουσίαση.
presentation = Presentation("ExistingChart.pptx")
try:
    # Αποκτήστε αναφορά στο αντικείμενο γραφήματος.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Δημιουργήστε κίνηση στα στοιχεία του γραφήματος.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Αποθηκεύστε την τροποποιημένη παρουσίαση στο δίσκο.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Κίνηση Κατηγοριών Γραφήματος**

Αν θέλετε να δημιουργήσετε κίνηση για μια κατηγορία γραφήματος, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε αναφορά στο αντικείμενο γραφήματος.
1. Δημιουργήστε κίνηση στην κατηγορία.
1. Αποθηκεύστε το αρχείο παρουσίασης στο δίσκο.

Το παρακάτω παράδειγμα δημιουργεί κίνηση σε κατηγορίες γραφήματος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Φορτώστε την παρουσίαση.
presentation = Presentation("ExistingChart.pptx")
try:
    # Αποκτήστε αναφορά στο αντικείμενο γραφήματος.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Δημιουργήστε κίνηση στα στοιχεία του γραφήματος.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Αποθηκεύστε την τροποποιημένη παρουσίαση στο δίσκο.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Κίνηση σε Στοιχείο Σειράς**

Αν θέλετε να δημιουργήσετε κίνηση σε στοιχεία σειράς, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε αναφορά στο αντικείμενο γραφήματος.
1. Δημιουργήστε κίνηση στα στοιχεία σειράς.
1. Αποθηκεύστε το αρχείο παρουσίασης στο δίσκο.

Το παρακάτω παράδειγμα δημιουργεί κίνηση σε στοιχεία σειράς.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Φορτώστε την παρουσίαση.
presentation = Presentation("ExistingChart.pptx")
try:
    # Αποκτήστε αναφορά στο αντικείμενο γραφήματος.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Δημιουργήστε κίνηση στα στοιχεία του γραφήματος.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Αποθηκεύστε την τροποποιημένη παρουσίαση στο δίσκο.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Κίνηση σε Στοιχείο Κατηγορίας**

Αν θέλετε να δημιουργήσετε κίνηση σε στοιχεία κατηγορίας, γράψτε τον κώδικα σύμφωνα με τα παρακάτω βήματα:

1. Φορτώστε μια παρουσίαση.
1. Αποκτήστε αναφορά στο αντικείμενο γραφήματος.
1. Δημιουργήστε κίνηση στα στοιχεία κατηγορίας.
1. Αποθηκεύστε το αρχείο παρουσίασης στο δίσκο.

Το παρακάτω παράδειγμα δημιουργεί κίνηση σε στοιχεία κατηγορίας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Φορτώστε την παρουσίαση.
presentation = Presentation("ExistingChart.pptx")
try:
    # Αποκτήστε αναφορά στο αντικείμενο γραφήματος.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Δημιουργήστε κίνηση στα στοιχεία του γραφήματος.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Αποθηκεύστε την τροποποιημένη παρουσίαση στο δίσκο.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές ερωτήσεις**

**Υποστηρίζονται διαφορετικοί τύποι εφέ (π.χ., είσοδο, έμφαση, έξοδο) για γραφήματα όπως και για κανονικά σχήματα;**

Ναι. Ένα γράφημα αντιμετωπίζεται ως σχήμα, έτσι υποστηρίζει τους τυπικούς τύπους εφέ κίνησης, συμπεριλαμβανομένων της εισόδου, της έμφασης και της εξόδου, με πλήρη έλεγχο μέσω της γραμμής χρόνου της διαφάνειας και των ακολουθιών κίνησης.

**Μπορώ να συνδυάσω την κίνηση γραφήματος με τις μεταβάσεις των διαφανειών;**

Ναι. Οι [Transitions](/slides/el/python-java/slide-transition/) εφαρμόζονται στη διαφάνεια, ενώ τα εφέ κίνησης εφαρμόζονται στα αντικείμενα της διαφάνειας. Μπορείτε να τα χρησιμοποιήσετε και τα δύο μαζί στην ίδια παρουσίαση και να τα ελέγχετε ανεξάρτητα.

**Διατηρούνται οι κινήσεις γραφήματος κατά την αποθήκευση σε PPTX;**

Ναι. Όταν [αποθηκεύετε σε PPTX](/slides/el/python-java/save-presentation/), όλα τα εφέ κίνησης και η σειρά τους διατηρούνται επειδή αποτελούν μέρος του εγγενή μοντέλου κίνησης της παρουσίασης.

**Μπορώ να διαβάσω υπάρχουσες κινήσεις γραφήματος από μια παρουσίαση και να τις τροποποιήσω;**

Ναι. Το API παρέχει πρόσβαση στη γραμμή χρόνου της διαφάνειας, στις ακολουθίες και στα εφέ, επιτρέποντάς σας να ελέγξετε τις υπάρχουσες κινήσεις γραφήματος και να τις προσαρμόσετε χωρίς να χρειάζεται να τα δημιουργήσετε ξανά από την αρχή.

**Μπορώ να δημιουργήσω βίντεο που περιλαμβάνει κινήσεις γραφήματος χρησιμοποιώντας το Aspose.Slides;**

Ναι. Μπορείτε να [εξάγετε μια παρουσίαση σε βίντεο](/slides/el/python-java/convert-powerpoint-to-video/) διατηρώντας τις κινήσεις, ρυθμίζοντας τα χρονικά διαστήματα και άλλες ρυθμίσεις εξαγωγής ώστε το αποτέλεσμα να αντανακλά την κίνηση της παρουσίασης.