---
title: Κλωνοποίηση Διαφανειών Παρουσίασης σε Python
linktitle: Κλωνοποίηση Διαφανειών
type: docs
weight: 35
url: /el/python-java/clone-slides/
keywords:
- κλωνοποίηση διαφάνειας
- αντιγραφή διαφάνειας
- αποθήκευση διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Δημιουργήστε γρήγορα αντίγραφα διαφανειών PowerPoint με το Aspose.Slides for Python via Java. Ακολουθήστε τα σαφή παραδείγματα κώδικα μας για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα και να εξαλείψετε τη χειροκίνητη εργασία."
---
## **Εισαγωγή**

Η κλωνοποίηση είναι η διαδικασία δημιουργίας ακριβούς αντιγράφου ή αντιδείγματος κάτι. Το Aspose.Slides for Python via Java καθιστά επίσης δυνατόν το αντίγραφο ή την κλωνοποίηση οποιασδήποτε διαφάνειας και στη συνέχεια η εισαγωγή της κλωνοποιημένης διαφάνειας στην τρέχουσα παρουσίαση ή σε οποιαδήποτε άλλη ανοιχτή παρουσίαση. Η διαδικασία κλωνοποίησης διαφάνειας δημιουργεί μια νέα διαφάνεια που μπορεί να τροποποιηθεί από προγραμματιστές χωρίς να αλλάξει η αρχική διαφάνεια. Υπάρχουν διάφοροι τρόποι κλωνοποίησης διαφάνειας:

- Κλωνοποίηση στο τέλος μέσα σε μια παρουσίαση.
- Κλωνοποίηση σε άλλη θέση μέσα σε μια παρουσίαση.
- Κλωνοποίηση στο τέλος σε άλλη παρουσίαση.
- Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση.
- Κλωνοποίηση μαζί με τη κύρια διαφάνεια σε άλλη παρουσίαση.

Στο Aspose.Slides for Python via Java, η συλλογή διαφανειών (μια συλλογή αντικειμένων [Slide](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/) ) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) παρέχει τις μεθόδους [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addClone) και [insertClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#insertClone) για την εκτέλεση των παραπάνω τύπων κλωνοποίησης διαφανείων.

## **Κλωνοποίηση Διαφάνειας στο Τέλος μιας Παρουσίασης**

Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης στο τέλος των υφιστάμενων διαφανειών, χρησιμοποιήστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addClone) σύμφωνα με τα παρακάτω βήματα:

1. Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Λάβετε το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/) αναφέροντας τη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/) και περάστε τη διαφάνεια που θα κλωνοποιηθεί ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addClone).
1. Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Στο παρακάτω παράδειγμα, έχουμε κλωνοποιήσει μια διαφάνεια (που βρίσκεται στην πρώτη θέση – δείκτης μηδέν – της παρουσίασης) στο τέλος της παρουσίασης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Δημιουργία κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # Κλωνοποίηση της απαιτούμενης διαφάνειας στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Αποθήκευση της τροποποιημένης παρουσίασης στο δίσκο
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Κλωνοποίηση Διαφάνειας σε Άλλη Θέση μέσα σε Παρουσίαση**

Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης αλλά σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#insertClone):

1. Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Αποκτήστε αναφορά στη συλλογή διαφανειών που επιστρέφεται από τη μέθοδο [getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlides) στο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
1. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#insertClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/) και περάστε τη διαφάνεια που θα κλωνοποιηθεί μαζί με το δείκτη για τη νέα θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#insertClone).
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, έχουμε κλωνοποιήσει μια διαφάνεια (που βρίσκεται στον δείκτη 1 – θέση 2 – της παρουσίασης) στον δείκτη 2 – θέση 3 – της παρουσίασης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Δημιουργία κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Λήψη της συλλογής διαφανειών στην παρουσίαση
    slides = presentation.getSlides()

    # Κλωνοποίηση της απαιτούμενης διαφάνειας στον καθορισμένο δείκτη στην ίδια παρουσίαση
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Αποθήκευση της τροποποιημένης παρουσίασης στο δίσκο
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Κλωνοποίηση Διαφάνειας στο Τέλος Άλλης Παρουσίασης**

Αν χρειάζεστε να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, στο τέλος των υφιστάμενων διαφανειών:

1. Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που περιέχει την παρουσίαση από την οποία θα κλωνοποιηθεί η διαφάνεια.
1. Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που περιέχει την προοριστική παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Λάβετε το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/) αναφέροντας τη συλλογή διαφανειών που επιστρέφεται από τη μέθοδο [getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlides) στο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/) και περάστε τη διαφάνεια από την πηγαία παρουσίαση ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addClone).
1. Γράψτε το τροποποιημένο αρχείο προορισμού.

Στο παρακάτω παράδειγμα, έχουμε κλωνοποιήσει μια διαφάνεια (από το δείκτη 0 της πηγαίας παρουσίασης) στο τέλος της προοριστικής παρουσίασης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Δημιουργία κλάσης Presentation για τη φόρτωση του αρχείου πηγαίας παρουσίασης
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Δημιουργία κλάσης Presentation για την προοριστική PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    destination_presentation = Presentation()
    try:
        # Κλωνοποίηση της απαιτούμενης διαφάνειας από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην προοριστική παρουσίαση
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # Αποθήκευση της προοριστικής παρουσίασης στο δίσκο
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Κλωνοποίηση Διαφάνειας σε Άλλη Θέση σε Άλλη Παρουσίαση**

Αν χρειάζεστε να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, σε συγκεκριμένη θέση:

1. Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που περιέχει την πηγαία παρουσίαση.
1. Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που περιέχει την παρουσίαση στην οποία θα προστεθεί η διαφάνεια.
1. Λάβετε το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/) αναφέροντας τη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [insertClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#insertClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/) και περάστε τη διαφάνεια από την πηγαία παρουσίαση μαζί με τη ζητούμενη θέση ως παράμετρο στη μέθοδο [insertClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#insertClone).
1. Γράψτε το τροποποιημένο αρχείο προορισμού.

Στο παρακάτω παράδειγμα, έχουμε κλωνοποιήσει μια διαφάνεια (από το μηδενικό δείκτη της πηγαίας παρουσίασης) στον δείκτη 1 (θέση 2) της προοριστικής παρουσίασης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Δημιουργία κλάσης Presentation για τη φόρτωση του αρχείου πηγαίας παρουσίασης
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Δημιουργία κλάσης Presentation για την προοριστική PPTX (όπου θα κλωνοποιηθεί η διαφάνεια)
    destination_presentation = Presentation()
    try:
        # Κλωνοποίηση της απαιτούμενης διαφάνειας από την πηγαία παρουσίαση στον καθορισμένο δείκτη στην προοριστική παρουσίαση
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Αποθήκευση της προοριστικής παρουσίασης στο δίσκο
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Κλωνοποίηση Διαφάνειας με την Κύρια Διαφάνειά της σε Άλλη Παρουσίαση**

Αν χρειάζεστε να κλωνοποιήσετε μια διαφάνεια μαζί με την κύρια διαφάνειά της από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη παρουσίαση, πρέπει πρώτα να κλωνοποιήσετε την επιθυμητή κύρια διαφάνεια από την πηγαία παρουσίαση στην προοριστική παρουσίαση. Στη συνέχεια, χρησιμοποιήστε την κλωνοποιημένη κύρια διαφάνεια κατά την κλωνοποίηση της διαφάνειας. Η μέθοδος [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addClone) απαιτεί μια κύρια διαφάνεια από την προοριστική παρουσίαση και όχι από την πηγαία. Για να κλωνοποιήσετε τη διαφάνεια με κύρια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που περιέχει την πηγαία παρουσίαση.
1. Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) που περιέχει την προοριστική παρουσίαση.
1. Πρόσβαση στη διαφάνεια που θα κλωνοποιηθεί μαζί με την κύρια διαφάνεια.
1. Λάβετε το αντικείμενο [MasterSlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslidecollection/) αναφέροντας τη συλλογή Masters που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslidecollection/#addClone) που εκτίθεται από το αντικείμενο [MasterSlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslidecollection/) και περάστε την κύρια διαφάνεια από το πηγαίο PPTX ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/masterslidecollection/#addClone).
1. Λάβετε το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/) αναφέροντας τη συλλογή Slides που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) της προοριστικής παρουσίασης.
1. Καλέστε τη μέθοδο [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addClone) που εκτίθεται από το αντικείμενο [SlideCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/) και περάστε τη διαφάνεια από την πηγαία παρουσίαση που θα κλωνοποιηθεί και την κύρια διαφάνεια ως παράμετρο στη μέθοδο [addClone](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addClone).
1. Γράψτε το τροποποιημένο αρχείο προορισμού.

Στο παρακάτω παράδειγμα, έχουμε κλωνοποιήσει μια διαφάνεια με κύρια (που βρίσκεται στον μηδενικό δείκτη της πηγαίας παρουσίασης) στο τέλος της προοριστικής παρουσίασης χρησιμοποιώντας την κύρια διαφάνεια της πηγαίας διαφάνειας.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Δημιουργία κλάσης Presentation για τη φόρτωση του αρχείου πηγαίας παρουσίασης
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Δημιουργία κλάσης Presentation για την προοριστική παρουσίαση (όπου θα κλωνοποιηθεί η διαφάνεια)
    destination_presentation = Presentation()
    try:
        # Δημιουργία Slide από τη συλλογή διαφανειών στην πηγαία παρουσίαση μαζί με
        # την κύρια διαφάνεια
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Κλωνοποίηση της επιθυμητής κύριας διαφάνειας από την πηγαία παρουσίαση στη συλλογή κυρίων στη
        # την προοριστική παρουσίαση
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Κλωνοποίηση της επιθυμητής διαφάνειας από την πηγαία παρουσίαση με την επιθυμητή κύρια διαφάνεια στο τέλος της
        # συλλογής διαφανειών στην προοριστική παρουσίαση
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Αποθήκευση της προοριστικής παρουσίασης στο δίσκο
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Κλωνοποίηση Διαφάνειας στο Τέλος Καθορισμένου Τμήματος**

Αν θέλετε να κλωνοποιήσετε μια διαφάνεια και να τη χρησιμοποιήσετε στο ίδιο αρχείο παρουσίασης αλλά σε διαφορετικό τμήμα, τότε χρησιμοποιήστε τη μέθοδο [**addClone**](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/#addClone) που εκτίθεται από την κλάση [**SlideCollection**](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidecollection/). Το Aspose.Slides for Python via Java καθιστά δυνατό το να κλωνοποιήσετε μια διαφάνεια από το πρώτο τμήμα και να την εισάγετε στο δεύτερο τμήμα της ίδιας παρουσίασης.

Το ακόλουθο απόσπασμα κώδικα δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να την εισάγετε σε ένα καθορισμένο τμήμα.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Αποθήκευση της προοριστικής παρουσίασης στο δίσκο
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Βεβαιώστε Ομοιότητα Μεγέθους Διαφάνειας**

Κατά την κλωνοποίηση διαφανειών σε άλλη παρουσίαση, βεβαιωθείτε ότι η προοριστική παρουσίαση έχει το ίδιο μέγεθος διαφάνειας με την πηγαία. Εάν τα μεγέθη διαφάνειας διαφέρουν, το Aspose.Slides δεν κλιμακώνει αυτόματα τα κλωνοποιημένα σχήματα — οι αρχικές συντεταγμένες και διαστάσεις διατηρούνται, κάτι που μπορεί να προκαλέσει μη ευθυγραμμισμένο περιεχόμενο ή εξήχωση εκτός των ορίων της διαφάνειας.

Μπορείτε να ορίσετε το μέγεθος διαφάνειας της προοριστικής παρουσίασης ώστε να ταιριάζει με την πηγαία πριν από την κλωνοποίηση του master και της διαφάνειας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Κάντε αυτό πριν από την κλωνοποίηση του master και της διαφάνειας.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Κλωνοποιούνται οι σημειώσεις ομιλητή και τα σχόλια ελεγκτών;**

Ναι. Η σελίδα σημειώσεων και τα σχόλια ελέγχου περιλαμβάνονται στην κλωνοποίηση. Εάν δεν τα θέλετε, [αφαιρέστε τα](/slides/el/python-java/presentation-notes/) μετά την εισαγωγή.

**Πώς διαχειρίζονται τα διαγράμματα και οι πηγές δεδομένων τους;**

Το αντικείμενο διαγράμματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Εάν το διάγραμμα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ. ένα ενσωματωμένο βιβλίο εργασίας OLE), αυτή η σύνδεση διατηρείται ως [αντικείμενο OLE](/slides/el/python-java/manage-ole/). Μετά τη μετακίνηση μεταξύ αρχείων, ελέγξτε τη διαθεσιμότητα των δεδομένων και τη συμπεριφορά ανανέωσης.

**Μπορώ να ελέγξω τη θέση εισαγωγής και τα τμήματα για την κλωνοποίηση;**

Ναι. Μπορείτε να εισάγετε το κλώνο σε συγκεκριμένο δείκτη διαφάνειας και να το τοποθετήσετε σε επιλεγμένο [τμήμα](/slides/el/python-java/slide-section/). Εάν το τμήμα προορισμού δεν υπάρχει, δημιουργήστε το πρώτα και στη συνέχεια μετακινήστε τη διαφάνεια σε αυτό.