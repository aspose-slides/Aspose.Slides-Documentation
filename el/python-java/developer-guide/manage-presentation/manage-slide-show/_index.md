---
title: Διαχείριση Παρουσιάσεων Διαφανειών σε Python μέσω Java
linktitle: Παρουσίαση Διαφανειών
type: docs
weight: 90
url: /el/python-java/manage-slide-show/
keywords:
- τύπος παρουσίασης
- παρουσιάζεται από τον ομιλητή
- προβάλλεται από άτομο
- προβάλλεται σε περίπτερο
- επιλογές παρουσίασης
- απείρων βρόχος
- παρουσίαση χωρίς αφήγηση
- παρουσίαση χωρίς κίνηση
- χρώμα στυλό
- εμφάνιση διαφανειών
- προσαρμοσμένη παρουσίαση
- προώθηση διαφανειών
- χειροκίνητα
- χρησιμοποιώντας χρόνους
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να διαχειριστείτε τις παρουσιάσεις διαφανειών στο Aspose.Slides για Python μέσω Java. Ελέγξτε τις μεταβάσεις διαφανειών, τους χρόνους και πολλά άλλα σε μορφές PPT, PPTX και ODP με ευκολία."
---
## **Εισαγωγή**

Οι **Set Up Show** του Microsoft PowerPoint σάς επιτρέπουν να επιλέξετε τον τύπο παρουσίασης, να ενεργοποιήσετε την επανάληψη, να επιλέξετε διαφάνειες και να ελέγξετε τον τρόπο προόδου των διαφανειών. Με το Aspose.Slides for Python via Java, μπορείτε να ρυθμίσετε αυτές τις επιλογές προγραμματιστικά και να τις αποθηκεύσετε σε αρχείο παρουσίασης.

Η μέθοδος [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlideShowSettings) επιστρέφει ένα αντικείμενο [SlideShowSettings](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/) που ελέγχει αυτές τις επιλογές. Τα παραδείγματα παρακάτω απαιτούν το Aspose.Slides for Python via Java και ένα συμβατό περιβάλλον εκτέλεσης Java. Κάθε παράδειγμα εκκινεί την JVM αν χρειάζεται και απελευθερώνει την παρουσίαση όταν ολοκληρωθεί.

## **Επιλογή τύπου παρουσίασης**

Η μέθοδος [SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/#setSlideShowType) καθορίζει τον τύπο της παρουσίασης, ο οποίος μπορεί να είναι μια παρουσίαση των ακόλουθων κλάσεων: [PresentedBySpeaker](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/el/python-java/aspose.slides/browsedbyindividual/), ή [BrowsedAtKiosk](https://reference.aspose.com/slides/el/python-java/aspose.slides/browsedatkiosk/). Η χρήση αυτής της μεθόδου σάς επιτρέπει να προσαρμόσετε την παρουσίαση για διαφορετικά σενάρια χρήσης, όπως αυτοματοποιημένα περίπτερα ή χειροκίνητες παρουσιάσεις.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και ορίζει τον τύπο παρουσίασης σε «Browsed by an individual» χωρίς την εμφάνιση της γραμμής κύλισης.

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

## **Ενεργοποίηση επιλογών παρουσίασης**

Η μέθοδος [SlideShowSettings.setLoop](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/#setLoop) καθορίζει αν η παρουσίαση θα επαναλαμβάνεται σε βρόχο μέχρι να σταματήσει χειροκίνητα. Αυτό είναι χρήσιμο για αυτοματοποιημένες παρουσιάσεις που πρέπει να εκτελούνται συνεχώς. Η μέθοδος [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/#setShowNarration) καθορίζει αν θα παιχθούν φωνητικές αφηγήσεις κατά τη διάρκεια της παρουσίασης. Είναι χρήσιμο για αυτοματοποιημένες παρουσιάσεις που περιέχουν φωνητικές οδηγίες για το κοινό. Η μέθοδος [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/#setShowAnimation) καθορίζει αν θα παιχθούν οι κινούμενες εικόνες που έχουν προστεθεί στα αντικείμενα των διαφανειών. Αυτό είναι χρήσιμο για την πλήρη οπτική απεικόνιση της παρουσίασης.

Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και βάζει την παρουσίαση σε λούπα.

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

## **Επιλογή διαφανειών προς προβολή**

Η μέθοδος [SlideShowSettings.setSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/#setSlides) σας επιτρέπει να επιλέξετε μια σειρά διαφανειών που θα προβληθούν κατά τη διάρκεια της παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να εμφανίσετε μόνο μέρος της παρουσίασης αντί για όλες τις διαφάνειες. Το παρακάτω παράδειγμα κώδικα δημιουργεί μια παρουσίαση με εννιά διαφάνειες και επιλέγει τις διαφάνειες 2 έως 9. Η περιοχή χρησιμοποιεί αριθμούς διαφανειών που ξεκινούν από το 1.

```python
import jpife
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Δημιουργήστε εννιά διαφάνειες ώστε το επιλεγμένο εύρος να υπάρχει.
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

## **Διαχείριση προόδου διαφανειών**

Η μέθοδος [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/#setUseTimings) σας επιτρέπει να ενεργοποιήσετε ή να απενεργοποιήσετε τη χρήση προρυθμισμένων χρόνων για κάθε διαφάνεια. Αυτό είναι χρήσιμο για αυτόματη προβολή διαφανειών με προκαθορισμένη διάρκεια εμφάνισης. Το παρακάτω παράδειγμα κώδικα δημιουργεί μια νέα παρουσίαση και απενεργοποιεί τη χρήση χρόνων.

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

## **Εμφάνιση ελέγχων πολυμέσων**

Η μέθοδος [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) καθορίζει αν θα εμφανιστούν οι έλεγχοι πολυμέσων (όπως αναπαραγωγή, παύση και διακοπή) κατά τη διάρκεια της παρουσίασης όταν αναπαράγεται πολυμεσικό περιεχόμενο (π.χ. βίντεο ή ήχος). Αυτό είναι χρήσιμο όταν θέλετε να δώσετε στον παρουσιαστή έλεγχο της αναπαραγωγής πολυμέσων κατά την παρουσίαση.

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

Ναι. Αποθηκεύστε το αρχείο ως PPSX ή PPSM· αυτές οι μορφές ανοίγουν απευθείας σε λειτουργία παρουσίασης όταν ανοιχτούν στο PowerPoint. Στο Aspose.Slides, επιλέξτε το αντίστοιχο μορφότυπο αποθήκευσης [during export](/slides/el/python-java/save-presentation/).

**Μπορώ να αποκλείσω μεμονωμένες διαφάνειες από την παρουσίαση χωρίς να τις διαγράψω από το αρχείο;**

Ναι. Σημειώστε μια διαφάνεια ως [hidden](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#setHidden). Οι κρυμμένες διαφάνειες παραμένουν στην παρουσίαση αλλά δεν εμφανίζονται κατά τη λειτουργία παρουσίασης.

**Μπορεί το Aspose.Slides να παίξει μια παρουσίαση ή να ελέγξει μια ζωντανή παρουσίαση στην οθόνη;**

Όχι. Το Aspose.Slides επεξεργάζεται, αναλύει και μετατρέπει αρχεία παρουσίασης· η πραγματική αναπαραγωγή γίνεται από μια εφαρμογή προβολής όπως το PowerPoint.