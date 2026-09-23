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
- προσκόλληση κάθετου διαχωριστή
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
description: "Ανακαλύψτε τις ιδιότητες προβολής του Aspose.Slides για Python μέσω Java για την προσαρμογή διαφανειών PPT, PPTX και ODP — ρυθμίστε διατάξεις, επίπεδα ζουμ και ρυθμίσεις εμφάνισης."
---
## **Εισαγωγή**

Η κανονική προβολή αποτελείται από τρεις περιοχές περιεχομένου: τη διαφάνεια αυτή καθαυτή, μια πλευρική περιοχή περιεχομένου και μια κάτω περιοχή περιεχομένου. Οι ιδιότητες της κανονικής προβολής περιγράφουν τη θέση αυτών των περιοχών περιεχομένου. Αυτές οι πληροφορίες επιτρέπουν στην εφαρμογή να αποθηκεύσει την κατάσταση προβολής στο αρχείο, ώστε όταν ανοίξει ξανά η προβολή να είναι στην ίδια κατάσταση όπως όταν η παρουσίαση αποθηκεύτηκε τελευταία.

Η μέθοδος [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#getNormalViewProperties) προστέθηκε για να παρέχει πρόσβαση στις ιδιότητες της κανονικής προβολής μιας παρουσίασης.

Οι κλάσεις [NormalViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/) και [NormalViewRestoredProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewrestoredproperties/) και η απαρίθμηση [SplitterBarStateType](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/) προστέθηκαν.

## **Σχετικά με NormalViewProperties**

Αντιπροσωπεύει τις ιδιότητες της κανονικής προβολής.

Οι μέθοδοι [getShowOutlineIcons](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) και [setShowOutlineIcons](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) καθορίζουν αν η εφαρμογή θα πρέπει να εμφανίζει εικονίδια όταν εμφανίζει το περιεχόμενο περιγράμματος σε οποιαδήποτε από τις περιοχές περιεχομένου της λειτουργίας κανονικής προβολής.

Οι μέθοδοι [getSnapVerticalSplitter](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) και [setSnapVerticalSplitter](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) καθορίζουν αν ο κάθετος διαχωριστής θα «κολλάει» σε ελαχιστοποιημένη κατάσταση όταν η πλευρική περιοχή είναι αρκετά μικρή.

Οι μέθοδοι [getPreferSingleView](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) και [setPreferSingleView](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) καθορίζουν αν ο χρήστης προτιμά να βλέπει μία περιοχή περιεχομένου σε πλήρη παράθυρο αντί για την τυπική κανονική προβολή με τρεις περιοχές περιεχομένου. Εάν ενεργοποιηθεί, η εφαρμογή μπορεί να επιλέξει να εμφανίσει μία από τις περιοχές περιεχομένου σε ολόκληρο το παράθυρο.

Οι μέθοδοι [getVerticalBarState](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) και [getHorizontalBarState](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) καθορίζουν την κατάσταση στην οποία πρέπει να εμφανίζεται η οριζόντια ή κάθετη γραμμή διαχωρισμού. Μία οριζόντια γραμμή διαχωρισμού διαχωρίζει τη διαφάνεια από την περιοχή περιεχομένου κάτω από τη διαφάνεια· μια κάθετη γραμμή διαχωρισμού διαχωρίζει τη διαφάνεια από την πλευρική περιοχή περιεχομένου. Πιθανές τιμές είναι: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/#Maximized) και [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/#Restored).

Οι μέθοδοι [getRestoredLeft](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) και [getRestoredTop](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredTop) καθορίζουν το μέγεθος της πάνω ή της πλευρικής περιοχής διαφάνειας της κανονικής προβολής, όταν η τιμή [SplitterBarStateType.Restored](https://reference.aspose.com/slides/el/python-java/aspose.slides/splitterbarstatetype/#Restored) εφαρμόζεται στη [getVerticalBarState](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) και στη [getHorizontalBarState](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), αντίστοιχα.

## **Σχετικά με την Επαναφορά NormalViewProperties**

Καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι θυγατρική του [getRestoredTop](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredTop), ύψος όταν είναι θυγατρική του [getRestoredLeft](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) της κανονικής προβολής, όταν η περιοχή έχει μεταβλητό επαναφερθέν μέγεθος (ούτε ελαχιστοποιημένη ούτε μεγιστοποιημένη).

Η μέθοδος [getDimensionSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) καθορίζει το μέγεθος της περιοχής διαφάνειας (πλάτος όταν είναι θυγατρική του [getRestoredTop](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredTop), ύψος όταν είναι θυγατρική του [getRestoredLeft](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Η μέθοδος [getAutoAdjust](https://reference.aspose.com/slides/el/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) καθορίζει αν το μέγεθος της πλευρικής περιοχής περιεχομένου πρέπει να προσαρμοστεί στο νέο μέγεθος κατά την αλλαγή μεγέθους του παραθύρου που περιέχει την προβολή μέσα στην εφαρμογή.

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

    # Επαναφορά των ιδιοτήτων προβολής της παρουσίασης.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Προεπιλεγμένης Τιμής Ζουμ**

{{% alert color="info" title="Note" %}}
Το Aspose.Slides για Python μέσω Java υποστηρίζει τον ορισμό της προεπιλεγμένης τιμής ζουμ ώστε να εφαρμόζεται αυτόματα όταν ανοίγει η παρουσίαση. Αυτό μπορεί να γίνει ορίζοντας τις [ViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/) μιας παρουσίασης. Οι [getSlideViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#getSlideViewProperties) καθώς και [getNotesViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#getNotesViewProperties) μπορούν να ρυθμιστούν προγραμματιστικά. Σε αυτό το θέμα, θα δούμε με ένα παράδειγμα πώς να ορίσουμε τις [View Properties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/) του [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) στο Aspose.Slides.
{{% /alert %}}

Για να ορίσετε τις ιδιότητες προβολής, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
2. Ορίστε τις [View Properties](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/) του [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
3. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/).

Στο παρακάτω παράδειγμα, ορίζουμε την τιμή ζουμ και για την προβολή διαφάνειας και για την προβολή σημειώσεων.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Ορισμός των ιδιοτήτων προβολής της παρουσίασης.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Ποσοστό ζουμ για προβολή διαφάνειας.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Ποσοστό ζουμ για προβολή σημειώσεων.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός Απόστασης Πλέγματος**

Χρησιμοποιήστε το [Presentation.getViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getViewProperties) για πρόσβαση στις ρυθμίσεις προβολής σε όλο το επίπεδο παρουσίασης. Οι μέθοδοι [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#getGridSpacing) και [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#setGridSpacing) διαβάζουν ή αλλάζουν το διάστημα του υποκείμενου πλέγματος επεξεργασίας. Αυτή η ρύθμιση ισχύει για ολόκληρη την παρουσίαση, όχι για μεμονωμένη διαφάνεια. Η απόσταση πλέγματος καθορίζεται σε πόντους, όπου 72 πόντοι ισοδυναμούν με μία ίντσα. Χρησιμοποιήστε μια θετική τιμή, όπως απαιτεί η τεκμηρίωση του API.

Το παρακάτω παράδειγμα ανοίγει ένα υπάρχον αρχείο `demo.pptx`, εκτυπώνει την τρέχουσα απόσταση πλέγματος, ορίζει ένα διάστημα τε¼ς ίντσας και αποθηκεύει το αποτέλεσμα.

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

Το πλέγμα διαφέρει από τις [drawing guides](/slides/el/python-java/drawing-guides/). Η απόσταση πλέγματος ελέγχει ένα τακτικό διάστημα, ενώ οι οδηγίες σχεδίασης είναι ατομικά τοποθετημένες οριζόντιες ή κάθετες γραμμές ευθυγράμμισης. Η προσθήκη, κίνηση ή διαγραφή των οδηγών σχεδίασης δεν αλλάζει την απόσταση του πλέγματος.

Τanto το πλέγμα όσο και οι οδηγίες σχεδίασης είναι βοηθήματα επεξεργασίας. Δεν αποδίδονται ως περιεχόμενο διαφάνειας σε PDF, εικόνες, SVG ή παρουσίαση. Η αποθήκευση της απόστασης του πλέγματος δεν εγγυάται ότι ένας επεξεργαστής θα εμφανίσει το πλέγμα: η ορατότητά του εξαρτάται επίσης από τις προτιμήσεις του προγράμματος προβολής ή επεξεργαστή.

## **Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης**

Χρησιμοποιήστε το [Presentation.getViewProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getViewProperties) για πρόσβαση στις ρυθμίσεις προβολής σε όλο το επίπεδο παρουσίασης. Χρησιμοποιήστε τα [ViewProperties.getShowComments](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#getShowComments) και [ViewProperties.setShowComments](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#setShowComments) για να διαβάσετε ή να αλλάξετε την αποθηκευμένη προτίμηση για το αν τα σχόλια θα εμφανίζονται όταν η παρουσίαση ανοίγει στο PowerPoint ή σε κάποιο άλλο συμβατό πρόγραμμα.

Αυτή η ρύθμιση ελέγχει μόνο την αποθηκευμένη προτίμηση προβολής. Δεν προσθέτει, αφαιρεί, επεξεργάζεται ή επιλύει σχόλια. Η απόκρυψη των σχολίων διατηρεί το περιεχόμενό τους, τους συγγραφείς, τις θέσεις, τις απαντήσεις και τις καταστάσεις. Δείτε τα [Presentation Comments](/slides/el/python-java/presentation-comments/) για ενέργειες που αλλάζουν τα ίδια τα σχόλια.

Το παρακάτω παράδειγμα απαιτεί ένα υπάρχον αρχείο `comments.pptx` που περιέχει σχόλια. Εκτυπώνει την τρέχουσα ρύθμιση ορατότητας, ζητάει να κρυφτούν τα σχόλια και αποθηκεύει ένα νέο PPTX χωρίς να αφαιρέσει κανένα σχόλιο. Χρησιμοποιεί επίσης το [ViewProperties.setLastView](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#setLastView) με το [ViewType.SlideView](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewtype/#SlideView) για να διαμορφώσει την αρχική προβολή επεξεργασίας μαζί με την ορατότητα των σχολίων.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αυτή η ρύθμιση δεν καθορίζει αν τα σχόλια θα συμπεριληφθούν στις εξαγωγές PDF, HTML, εικόνας, σημειώσεων ή φυλλαδίων. Διαμορφώστε τις αντίστοιχες επιλογές εξαγωγής ξεχωριστά.

## **FAQ**

**Γιατί το πλέγμα δεν είναι ορατό αφού ξαναάνοιξα την παρουσίαση;**

Το αρχείο αποθηκεύει την απόσταση του πλέγματος, αλλά ο επεξεργαστής ελέγχει αν το πλέγμα εμφανίζεται. Ελέγξτε τις ρυθμίσεις ορατότητας πλέγματος του επεξεργαστή.

**Αλλάζει η διαγραφή των οδηγών σχεδίασης την απόσταση του πλέγματος;**

Όχι. Οι οδηγίες σχεδίασης και η απόσταση πλέγματος είναι ανεξάρτητες ρυθμίσεις. Η διαγραφή των οδηγών αφήνει το αποθηκευμένο διάστημα πλέγματος αμετάβλητο.

**Μπορώ να ορίσω διαφορετικές ρυθμίσεις προβολής για διαφορετικές ενότητες μιας παρουσίασης;**

Οι [ρυθμίσεις προβολής](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getViewProperties) ορίζονται σε επίπεδο παρουσίασης ([Normal View](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), όχι ανά ενότητα, έτσι ένα ενιαίο σύνολο παραμέτρων ισχύει για ολόκληρο το έγγραφο όταν ανοίγει.

**Μπορώ να προκαθορίσω διαφορετικές καταστάσεις προβολής για διαφορετικούς χρήστες;**

Όχι. Οι ρυθμίσεις αποθηκεύονται στο αρχείο και μοιράζονται. Οι εφαρμογές προβολής μπορεί να τηρήσουν τις προτιμήσεις χρήστη, αλλά το ίδιο το αρχείο περιέχει ένα σετ ιδιοτήτων προβολής.

**Μπορώ να ετοιμάσω ένα πρότυπο με προκαθορισμένες Ιδιότητες Προβολής ώστε νέες παρουσιάσεις να ανοίγουν με τον ίδιο τρόπο;**

Ναι. Επειδή οι [ιδιότητες προβολής](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getViewProperties) αποθηκεύονται σε επίπεδο παρουσίασης, μπορείτε να τις ενσωματώσετε σε ένα πρότυπο και να δημιουργήσετε νέα έγγραφα από αυτό με την ίδια αρχική ρύθμιση προβολής.