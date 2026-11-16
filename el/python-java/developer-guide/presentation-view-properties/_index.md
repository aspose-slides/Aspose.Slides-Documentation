---
title: "Ανάκτηση και Ενημέρωση Ιδιοτήτων Προβολής Παρουσίασης σε Python μέσω Java"
linktitle: "Ιδιότητες Προβολής"
type: docs
weight: 80
url: /el/python-java/presentation-view-properties/
keywords:
- ιδιότητες προβολής
- κανονική προβολή
- περιεχόμενο περιγράμματος
- εικονίδια περιγράμματος
- συγκράτηση κατακόρυφου διαχωριστή
- μονή προβολή
- κατάσταση γραμμής
- μέγεθος διάστασης
- αυτόματη προσαρμογή
- προεπιλεγμένη εστίαση
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides για Python μέσω Java για να διαμορφώσετε τη διάταξη της κανονικής προβολής, την εστίαση των διαφανειών και των σημειώσεων, το διάστιχο του πλέγματος και την ορατότητα των σχολίων στις παρουσιάσεις PowerPoint."
---
## **Εισαγωγή**

Στη φυσιολογική προβολή του PowerPoint, η διαφάνεια εμφανίζεται μεταξύ ενός πλευρικού παραθύρου για μικρογραφίες ή ένα περίγραμμα και ενός παραθύρου σημειώσεων από κάτω. Το Aspose.Slides for Python μέσω Java εκθέτει τις αποθηκευμένες προτιμήσεις επεξεργασίας της παρουσίασης μέσω [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties). Αυτές περιλαμβάνουν τη διάταξη των παραθύρων, τα επίπεδα εστίασης, το διάστιχο του πλέγματος και την ορατότητα σχολίων.

## **Σχετικά με το NormalViewProperties**

Χρησιμοποιήστε το [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) για να αποκτήσετε πρόσβαση στην κλάση [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/). Το [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) ελέγχει εάν εμφανίζονται εικονίδια δίπλα στους τίτλους των διαφανειών στο περίγραμμα. Το [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) επιτρέπει στο πλευρικό παράθυρο να «κολλήσει» στην ελαχιστοποιημένη του κατάσταση όταν ο χρήστης το σμικρύνει. Το [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) δείχνει προτίμηση για εμφάνιση ενός παραθύρου σε πλήρη παράθυρο.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) ελέγχει το διαχωριστικό μεταξύ του πλευρικού παραθύρου και της διαφάνειας. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) ελέγχει το διαχωριστικό πάνω από το παράθυρο σημειώσεων. Και τα δύο δέχονται μια τιμή [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) του `Minimized`, `Maximized` ή `Restored`.

## **Σχετικά με την Επαναφορά NormalViewProperties**

Όταν ένα διαχωριστικό επανέρχεται, το [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) παρέχει το αποθηκευμένο μέγεθος του πλευρικού παραθύρου και το [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) παρέχει το αποθηκευμένο μέγεθος της άνω περιοχής της διαφάνειας. Και τα δύο επιστρέφουν μια παρουσία του [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/). Η μέθοδος [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) δέχεται ένα ποσοστό από 0 έως 100, και το [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) ελέγχει εάν ο επεξεργαστής προσαρμόζει το μέγεθος όταν αλλάζει το μέγεθος του παραθύρου.

Αυτό το παράδειγμα ενημερώνει μια υπάρχουσα παρουσίαση. Επαναφέρει το οριζόντιο διαχωριστικό, ορίζει το μέγεθος που επιστρέφει το [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) στο 80 % με ενεργοποιημένη την αυτόματη προσαρμογή, και μεγιστοποιεί το κάθετο διαχωριστικό. Καλεί επίσης το [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) για να εμφανίσει εικονίδια στην προβολή περιγράμματος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός της Προεπιλεγμένης Τιμής Εστίασης**

Τα [getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) και [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) αποθηκεύουν ανεξάρτητες ρυθμίσεις εστίασης για τον επεξεργαστή. Αυτές οι ρυθμίσεις δεν επηρεάζουν τις διαστάσεις της διαφάνειας, την αναπαραγωγή της παρουσίασης ή την ανάλυση εξαγωγής εικόνας.

Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και καλεί το [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) για να προσαρμόσει τη διαφάνεια στο παράθυρο επεξεργασίας. Για τη σελίδα σημειώσεων, απενεργοποιεί την αυτόματη κλιμάκωση και καλεί το [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) για να ορίσει σταθερή εστίαση στο 80 %.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ορισμός του Διαστημάτων Πλέγματος**

Το [setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) ορίζει την απόσταση μεταξύ των γραμμών πλέγματος επεξεργασίας σε ολόκληρη την παρουσίαση. Δέχεται θετική τιμή σε πόντους, με 72 πόντους ανά ίντσα. Αυτό το παράδειγμα εκτυπώνει το τρέχον διάστημα σε μια υπάρχουσα παρουσίαση και αποθηκεύει ένα πλέγμα τέταρτου ίντσας ορίζοντας το διάστημα στα 18 πόντους.

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

Το πλέγμα επαναλαμβάνεται σε σταθερό διάστημα. Οι [Drawing guides](/slides/el/python-java/drawing-guides/) σημαδέψουν μεμονωμένες οριζόντιες ή κάθετες θέσεις. Και τα δύο είναι βοηθήματα επεξεργασίας και εμφανίζονται μόνο σε επεξεργαστές που τα εμφανίζουν. Οι παρουσιάσεις και οι εξαγωγές σε PDF, εικόνες ή SVG τα παραλείπουν.

## **Εμφάνιση ή Απόκρυψη Σχολίων Κατά το Άνοιγμα Παρουσίασης**

Το [setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) αποθηκεύει μια προτίμηση που οι συμβατοί επεξεργαστές χρησιμοποιούν κατά το άνοιγμα της παρουσίασης. Για μια υπάρχουσα παρουσίαση με σχόλια, αυτό το παράδειγμα εκτυπώνει την τρέχουσα ρύθμιση και αποθηκεύει ένα αντίγραφο με κρυμμένα σχόλια. Καλεί επίσης το [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) με το [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) ώστε το αντίγραφο να ανοίξει σε προβολή διαφάνειας.

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

Η απόκρυψη των σχολίων διατηρεί το κείμενό τους, τους συγγραφείς, τις θέσεις, τις απαντήσεις και τις καταστάσεις. Για να αλλάξετε τα ίδια τα σχόλια, δείτε τα [Presentation Comments](/slides/el/python-java/presentation-comments/). Οι ρυθμίσεις εξαγωγής ελέγχουν εάν τα σχόλια εμφανίζονται σε PDF, HTML, εικόνες, σημειώσεις ή φυλλάδια.

## **Συχνές Ερωτήσεις**

**Γιατί το πλέγμα είναι κρυφό όταν ανοίγω ξανά την παρουσίαση;**

Η παρουσίαση αποθηκεύει το διάστημα του πλέγματος. Για να δείτε το πλέγμα, ενεργοποιήστε την ορατότητα του πλέγματος στον επεξεργαστή.

**Αλλάζει η εκκαθάριση των οδηγών σχεδίασης το διάστημα του πλέγματος;**

Όχι. Η προσθήκη, η μετακίνηση ή η εκκαθάριση ενός οδηγού αφήνει το διάστημα του πλέγματος αμετάβλητο.

**Μπορούν διαφορετικά τμήματα μιας παρουσίασης να έχουν διαφορετικές ρυθμίσεις προβολής;**

Όχι. Το [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) εφαρμόζεται σε ολόκληρη την παρουσίαση.

**Μπορώ να αποθηκεύσω διαφορετικές ρυθμίσεις προβολής για διαφορετικούς χρήστες;**

Το αρχείο αποθηκεύει ένα σύνολο ιδιοτήτων προβολής για όλους. Ένας επεξεργαστής μπορεί επίσης να εφαρμόσει τις τοπικές προτιμήσεις του χρήστη.

**Μπορώ να αποθηκεύσω τις ρυθμίσεις προβολής σε ένα πρότυπο;**

Ναι. Οι παρουσιάσεις που δημιουργούνται από το πρότυπο κληρονομούν τις αποθηκευμένες ρυθμίσεις προβολής του.