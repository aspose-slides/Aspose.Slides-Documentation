---
title: Διαχείριση Παρουσιάσεων Διαφανειών σε Python μέσω Java
linktitle: Παρουσίαση Διαφανειών
type: docs
weight: 90
url: /el/python-java/manage-slide-show/
keywords:
- τύπος παρουσίασης
- παρουσιάζεται από ομιλητή
- προβολή από άτομο
- προβολή σε περίπτερο
- επιλογές παρουσίασης
- συνεχής επανάληψη
- παρουσίαση χωρίς αφηγήση
- παρουσίαση χωρίς κίνηση
- χρώμα στυλό
- προβολή διαφανειών
- προσαρμοσμένη παρουσίαση
- προώθηση διαφανειών
- χειροκίνητα
- χρήση χρονισμών
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τις παρουσιάσεις διαφανειών στο Aspose.Slides για Python μέσω Java. Ελέγξτε τις μεταβάσεις διαφανειών, τους χρονισμούς και άλλα, σε μορφές PPT, PPTX και ODP, με ευκολία."
---
## **Εισαγωγή**

Οι επιλογές **Set Up Show** του Microsoft PowerPoint σάς επιτρέπουν να επιλέξετε τον τύπο της παρουσίασης, να ενεργοποιήσετε την επανάληψη, να επιλέξετε διαφάνειες και να ελέγξετε τον τρόπο προόδους των διαφανειών. Με το Aspose.Slides for Python via Java, μπορείτε να ρυθμίσετε αυτές τις επιλογές προγραμματιστικά και να τις αποθηκεύσετε σε αρχείο παρουσίασης.

Η μέθοδος [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlideShowSettings) επιστρέφει ένα αντικείμενο [SlideShowSettings](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/) που ελέγχει αυτές τις επιλογές. Τα παραδείγματα παρακάτω απαιτούν το Aspose.Slides for Python via Java και ένα συμβατό Java runtime. Κάθε παράδειγμα εκκινεί το JVM εάν χρειάζεται και απελευθερώνει την παρουσίαση όταν ολοκληρωθεί.

## **Επιλογή Τύπου Παρουσίασης**

Η μέθοδος [SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/#setSlideShowType) ορίζει τον τύπο της παρουσίασης, ο οποίος μπορεί να είναι μια παρουσίαση των ακόλουθων κλάσεων: [PresentedBySpeaker](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/el/python-java/aspose.slides/browsedbyindividual/), ή [BrowsedAtKiosk](https://reference.aspose.com/slides/el/python-java/aspose.slides/browsedatkiosk/). Η χρήση αυτής της μεθόδου σας επιτρέπει να προσαρμόσετε την παρουσίαση για διαφορετικά σενάρια χρήσης, όπως αυτοματοποιημένα παζλ ή χειροκίνητες παρουσιάσεις.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ορίζει τον τύπο παρουσίασης σε «Browsed by an individual» χωρίς εμφάνιση της γραμμής κύλισης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ενεργοποίηση Επιλογών Παρουσίασης**

Η μέθοδος [SlideShowSettings.setLoop](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/#setLoop) καθορίζει εάν η παρουσίαση θα επαναλαμβάνονται σε βρόχο μέχρι να σταματήσει χειροκίνητα. Αυτό είναι χρήσιμο για αυτοματοποιημένες παρουσιάσεις που πρέπει να λειτουργούν συνεχώς. Η μέθοδος [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/#setShowNarration) καθορίζει εάν θα αναπαράγονται ηχητικές αφηγήσεις κατά τη διάρκεια της παρουσίασης. Αυτό είναι χρήσιμο για αυτοματοποιημένες παρουσιάσεις που περιέχουν φωνητική καθοδήγηση για το κοινό. Η μέθοδος [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/#setShowAnimation) καθορίζει εάν θα αναπαράγονται οι κινήσεις που έχουν προστεθεί σε αντικείμενα διαφάνειας. Αυτό είναι χρήσιμο για την πλήρη οπτική απόδοση της παρουσίασης.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και επαναλαμβάνει τη παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Επιλογή Διαφανειών για Εμφάνιση**

Η μέθοδος [SlideShowSettings.setSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/#setSlides) σας επιτρέπει να επιλέξετε μια σειρά διαφανειών που θα εμφανιστούν κατά τη διάρκεια της παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να εμφανίσετε μόνο ένα τμήμα της παρουσίασης αντί για όλες τις διαφάνειες. Το παρακάτω παράδειγμα κώδικα δημιουργεί μια παρουσίαση με εννέα διαφάνειες και επιλέγει τις διαφάνειες 2 έως 9. Η σειρά χρησιμοποιεί αριθμούς διαφάνειας που αρχίζουν από το 1.

```python
import jpide
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Δημιουργήστε εννέα διαφάνειες ώστε το επιλεγμένο εύρος να υπάρχει.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Έλεγχος Προόδου Διαφάνειας**

Η μέθοδος [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/#setUseTimings) σας επιτρέπει να ενεργοποιήσετε ή να απενεργοποιήσετε τη χρήση προρυθμισμένων χρονισμών για κάθε διαφάνεια. Αυτό είναι χρήσιμο για αυτόματη εμφάνιση διαφανειών με προκαθορισμένες διάρκειες προβολής. Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και απενεργοποιεί τη χρήση χρονισμών.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Εμφάνιση Ελέγχων Πολυμέσων**

Η μέθοδος [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) καθορίζει εάν οι έλεγχοι πολυμέσων (όπως αναπαραγωγή, παύση και διακοπή) θα εμφανίζονται κατά τη διάρκεια της παρουσίασης όταν γίνεται αναπαραγωγή πολυμέσων (π.χ. βίντεο ή ήχος). Αυτό είναι χρήσιμο όταν θέλετε να δώσετε στον παρουσιαστή έλεγχο της αναπαραγωγής πολυμέσων κατά τη διάρκεια της παρουσίασης.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ενεργοποιεί την εμφάνιση ελέγχων πολυμέσων.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές ερωτήσεις**

**Μπορώ να αποθηκεύσω μια παρουσίαση ώστε να ανοίγει απευθείας σε λειτουργία παρουσίασης;**

Ναι. Αποθηκεύστε το αρχείο ως PPSX ή PPSM· αυτές οι μορφές ξεκινούν απευθείας σε λειτουργία παρουσίασης όταν ανοίγονται στο PowerPoint. Στο Aspose.Slides, επιλέξτε την αντίστοιχη μορφή αποθήκευσης [during export](/slides/el/python-java/save-presentation/).

**Μπορώ να εξαιρέσω μεμονωμένες διαφάνειες από την παρουσίαση χωρίς να τις διαγράψω από το αρχείο;**

Ναι. Σημειώστε μια διαφάνεια ως [hidden](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#setHidden). Οι κρυμμένες διαφάνειες παραμένουν στην παρουσίαση αλλά δεν εμφανίζονται κατά τη διάρκεια της παρουσίασης.

**Μπορεί το Aspose.Slides να αναπαράγει μια παρουσίαση ή να ελέγξει μία ζωντανή παρουσίαση στην οθόνη;**

Όχι. Το Aspose.Slides επεξεργάζεται, αναλύει και μετατρέπει αρχεία παρουσίασης· η πραγματική αναπαραγωγή γίνεται από μια εφαρμογή προβολής, όπως το PowerPoint.