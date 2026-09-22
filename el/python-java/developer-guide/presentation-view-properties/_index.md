---
title: Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε Python μέσω Java
linktitle: Ιδιότητες Προβολής
type: docs
weight: 80
url: /el/python-java/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο προσυνοχής
- εικονίδια προσυνοχής
- κλείδωμα κάθετης διαχωριστικής γραμμής
- μονή προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένο μεγέθυνση
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides για Python μέσω Java για προσαρμογή διαφανειών PPT, PPTX και ODP—ρυθμίστε διατάξεις, επίπεδα μεγέθυνσης και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια ίδια, μια πλευρική περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Οι ιδιότητες της κανονικής προβολής περιγράφουν τη θέση αυτών των περιοχών περιεχομένου. Αυτή η πληροφορία επιτρέπει στην εφαρμογή να αποθηκεύει την κατάσταση προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να είναι στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η μέθοδος [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#getNormalViewProperties) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής μιας παρουσίασης.

Οι κλάσεις [NormalViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/) και [NormalViewRestoredProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewrestoredproperties/) και η απαρίθμηση [SplitterBarStateType](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/) προστέθηκαν.

## **Σχετικά με το NormalViewProperties**

Αναπαριστά τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) καθορίζουν αν η εφαρμογή θα εμφανίζει εικονίδια όταν προβάλλει περιεχόμενο προσυνοχής σε οποιαδήποτε από τις περιοχές περιεχομένου της κανονικής λειτουργίας προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) καθορίζουν αν η κάθετη διαχωριστική γραμμή θα κλειδώνεται σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Οι μέθοδοι [getPreferSingleView](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) και [setPreferSingleView](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) καθορίζουν αν ο χρήστης προτιμά να βλέπει μια πλήρη περιοχή περιεχομένου σε όλο το παράθυρο αντί της τυπικής κανονικής προβολής με τρεις περιοχές περιεχομένου. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε όλο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) και [getHorizontalBarState](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) καθορίζουν την κατάσταση στην οποία θα εμφανίζεται η οριζόντια ή κάθετη γραμμή διαχωριστή. Μια οριζόντια γραμμή διαχωριστή χωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια· μια κάθετη γραμμή διαχωριστή χωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Οι πιθανές τιμές είναι: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/#Maximized) και [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) και [getRestoredTop](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredTop) καθορίζουν το μέγεθος της άνω ή πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/#Restored) εφαρμόζεται στο [getVerticalBarState](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) και στο [getHorizontalBarState](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), αντίστοιχα.

## **Σχετικά με την Επαναφορά NormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του [getRestoredTop](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredTop), ύψος όταν είναι παιδί του [getRestoredLeft](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ούτε ελαχιστοποιημένο ούτε μεγιστοποιημένο).

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι παιδί του [getRestoredTop](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredTop), ύψος όταν είναι παιδί του [getRestoredLeft](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) καθορίζει αν το μέγεθος της πλευρικής περιοχής περιεχομένου θα προσαρμοστεί στο νέο μέγεθος όταν αλλάζει το μέγεθος του παραθύρου που περιέχει την προβολή μέσα στην εφαρμογή.

Το παρακάτω παράδειγμα δείχνει πώς να αποκτήσετε πρόσβαση στη [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#getNormalViewProperties) για μια παρουσίαση.

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

    # Επαναφορά των ιδιοτήτων προβολής της παρουσίασης.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός της Προεπιλεγμένης Τιμής Μεγέθυνσης**

{{% alert color="info" title="Note" %}}

Το Aspose.Slides for Python via Java υποστηρίζει τον ορισμό της προεπιλεγμένης τιμής μεγέθυνσης ώστε να εφαρμόζεται αυτόματα όταν η παρουσίαση ανοίγει. Αυτό μπορεί να γίνει ορίζοντας τις [ViewProperties] μιας παρουσίασης. Οι μέθοδοι [getSlideViewProperties] και [getNotesViewProperties] μπορούν να ρυθμιστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσετε τις [View Properties] του [Presentation] στο Aspose.Slides.

{{% /alert %}}

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Ορίστε τις [View Properties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/) του [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Ορισμός των ιδιοτήτων προβολής της παρουσίασης.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Ποσοστό μεγέθυνσης για προβολή διαφάνειας.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Ποσοστό μεγέθυνσης για προβολή σημειώσεων.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός της Απόστασης Πλέγματος**

Χρησιμοποιήστε το [Presentation.getViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getViewProperties) για πρόσβαση στις ρυθμίσεις προβολής σε ολόκληρη την παρουσίαση. Οι μέθοδοι [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#getGridSpacing) και [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#setGridSpacing) διαβάζουν ή αλλάζουν το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση εφαρμόζεται σε όλη την παρουσίαση, όχι σε μεμονωμένη διαφάνεια. Η απόσταση πλέγματος ορίζεται σε σημεία, όπου 72 σημεία ισοδυναμούν με ένα ίντσα. Χρησιμοποιήστε θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον `demo.pptx`, εκτυπώνει την τρέχουσα απόσταση πλέγματος, ορίζει ένα διάστημα τέταρτου ίντσας και αποθηκεύει το αποτέλεσμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Το πλέγμα διαφέρει από τις [drawing guides](/slides/el/python-java/drawing-guides/). Η απόσταση πλέγματος ελέγχει ένα τακτικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι ατομικά τοποθετημένες οριζόντιες ή κάθετες ευθυγραμμίσεις. Η προσθήκη, η μετακίνηση ή η εκκαθάριση οδηγών σχεδίασης δεν αλλάζει την απόσταση πλέγματος.

Τanto το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση της απόστασης πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα· η ορατότητά του εξαρτάται επίσης από τις προτιμήσεις του προγράμματος προβολής ή επεξεργαστή.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Γιατί το πλέγμα δεν είναι ορατό μετά το άνοιγμα ξανά της παρουσίασης;**

Το αρχείο αποθηκεύει την απόσταση πλέγματος, αλλά ο επεξεργαστής ελέγχει αν το πλέγμα θα εμφανιστεί. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλάζει η εκκαθάριση οδηγών σχεδίασης το πλέγμα;**

Όχι. Οι οδηγίες σχεδίασης και η απόσταση πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η εκκαθάριση των οδηγών αφήνει το αποθηκευμένο διάστημα πλέγματος αμετάβλητο.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [view settings] ορίζονται σε επίπεδο παρουσίασης ([Normal View]/[Slide View]), όχι ανά ενότητα, οπότε ένα σύνολο παραμέτρων εφαρμόζεται σε όλο το έγγραφο κατά το άνοιγμα.

**Μπορώ να προκαθορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και είναι κοινές. Οι εφαρμογές προβολής μπορεί να σεβαστούν τις προτιμήσεις του χρήστη, αλλά το αρχείο περιέχει ένα σύνολο ιδιοτήτων προβολής.

**Μπορώ να προετοιμάσω ένα πρότυπο με προορισμένες Ιδιότητες Προβολής ώστε νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [view properties] αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική ρύθμιση προβολής.