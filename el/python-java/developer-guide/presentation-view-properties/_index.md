---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε Python μέσω Java
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/python-java/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- πρεσγάρωση κάθετου διαχωριστή
- μονή προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο ζουμ
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Ανακαλύψτε τις ιδιότητες προβολής Aspose.Slides για Python μέσω Java για την προσαρμογή διαφανειών PPT, PPTX και ODP —ρυθμίστε τις διατάξεις, τα επίπεδα ζουμ και τις ρυθμίσεις εμφάνισης."
---
## **Introduction**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια αυτή καθ' αυτή, μια πλευρική περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Οι ιδιότητες της κανονικής προβολής περιγράφουν τη θέση αυτών των περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύσει την κατάσταση προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να είναι στην ίδια κατάσταση με την τελευταία αποθήκευση της παρουσίασης.

Η μέθοδος [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#getNormalViewProperties) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής μιας παρουσίασης.

Οι κλάσε​ς [NormalViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/) , [NormalViewRestoredProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewrestoredproperties/) και η απαρίθμηση [SplitterBarStateType](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/) προστέθηκαν.

## **About NormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) καθορίζουν εάν η εφαρμογή πρέπει να εμφανίζει εικονίδια όταν εμφανίζεται το περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της κανονικής προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) καθορίζουν εάν ο κατακόρυφος διαχωριστής θα «πιάσει» σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Οι μέθοδοι [getPreferSingleView](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) και [setPreferSingleView](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) καθορίζουν εάν ο χρήστης προτιμά να βλέπει μια περιοχή περιεχομένου πλήρους παραθύρου αντί για την τυπική κανονική προβολή με τρεις περιοχές. Εάν είναι ενεργοποιημένος, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) και [getHorizontalBarState](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) καθορίζουν την κατάσταση στην οποία θα εμφανίζεται η οριζόντια ή κάθετη γραμμή διαχωρισμού. Μια οριζόντια γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια· μια κάθετη γραμμή διαχωρισμού χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/#Maximized) και [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) και [getRestoredTop](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredTop) καθορίζουν το μέγεθος της επάνω ή της πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/#Restored) εφαρμόζεται στο [getVerticalBarState](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) και στο [getHorizontalBarState](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), αντίστοιχα.

## **About Restoring NormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι θυγατρικό του [getRestoredTop](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredTop), ύψος όταν είναι θυγατρικό του [getRestoredLeft](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ούτε ελαχιστοποιημένη ούτε μεγιστοποιημένη).

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι θυγατρικό του [getRestoredTop](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredTop), ύψος όταν είναι θυγατρικό του [getRestoredLeft](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) καθορίζει εάν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να αντισταθμίσει το νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που περιέχει την προβολή στην εφαρμογή.

Το παρακάτω παράδειγμα δείχνει πώς να αποκτήσετε πρόσβαση στο [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#getNormalViewProperties) για μια παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Αποκατάσταση των ιδιοτήτων προβολής της παρουσίασης.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set the Default Zoom Value**

{{% alert color="info" title="Note" %}}
Το Aspose.Slides για Python μέσω Java υποστηρίζει τον ορισμό της προεπιλεγμένης τιμής εστίασης ώστε να εφαρμόζεται ήδη όταν ανοίγει η παρουσίαση. Αυτό μπορεί να γίνει ορίζοντας το [ViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/) μιας παρουσίασης. Τα [getSlideViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#getSlideViewProperties) καθώς και τα [getNotesViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#getNotesViewProperties) μπορούν να διαμορφωθούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις [View Properties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/) του [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) στο [Aspose.Slides](/slides/el/).
{{% /alert %}}

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα εξής βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Ορίστε τις [View Properties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/) του [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Γράψτε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Στο παρακάτω παράδειγμα, ορίζουμε την τιμή εστίασης τόσο για την προβολή διαφάνειας όσο και για την προβολή σημειώσεων.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Ορίστε τις ιδιότητες προβολής της παρουσίασης.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Ποσοστό ζουμ για την προβολή διαφάνειας.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Ποσοστό ζουμ για την προβολή σημειώσεων.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικά τμήματα μιας παρουσίασης;**

Οι ρυθμίσεις προβολής ορίζονται σε επίπεδο παρουσίασης (Normal View/Slide View), όχι ανά τμήμα, έτσι ένα ενιαίο σύνολο παραμέτρων εφαρμόζεται σε ολόκληρο το έγγραφο όταν ανοίγει.

**Μπορώ να προορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και είναι κοινές. Οι εφαρμογές προβολής μπορεί να σέβονται τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα μόνο σύνολο ιδιοτήτων προβολής.

**Μπορώ να προετοιμάσω ένα πρότυπο με προορισμένες ιδιότητες προβολής ώστε οι νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι ιδιότητες προβολής αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργείτε νέα έγγραφα από αυτό με την ίδια αρχική ρύθμιση προβολής.