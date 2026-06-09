---
title: Κλωνοποίηση διαφανειών PowerPoint σε Python
linktitle: Κλωνοποίηση Διαφανειών
type: docs
weight: 40
url: /el/python-net/clone-slides/
keywords:
- κλωνοποίηση διαφάνειας
- αντιγραφή διαφάνειας
- αποθήκευση διαφάνειας
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Γρήγορη κλωνοποίηση ή αντιγραφή διαφανειών PowerPoint με Aspose.Slides για Python μέσω .NET. Ακολουθήστε τα σαφή παραδείγματα κώδικα και τις συμβουλές μας για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα, να αυξήσετε την παραγωγικότητα και να εξαλείψετε την χειροκίνητη εργασία."
---
## **Εισαγωγή**

Η κλωνοποίηση είναι η διαδικασία δημιουργίας ακριβούς αντιγράφου ή αντιτύπου κάτι. Το Aspose.Slides επίσης επιτρέπει την αντιγραφή (κλωνοποίηση) οποιασδήποτε διαφάνειας και στη συνέχεια την εισαγωγή της κλωνοποιημένης διαφάνειας στην τρέχουσα παρουσίαση ή σε οποιαδήποτε άλλη ανοιχτή παρουσίαση. Η κλωνοποίηση διαφάνειας δημιουργεί μια νέα διαφάνεια που οι προγραμματιστές μπορούν να τροποποιήσουν χωρίς να επηρεάσουν την αρχική διαφάνεια. Υπάρχουν διάφοροι τρόποι για να κλωνοποιήσετε μια διαφάνεια:

- Κλωνοποίηση στο τέλος μιας παρουσίασης.
- Κλωνοποίηση σε άλλη θέση μέσα σε μια παρουσίαση.
- Κλωνοποίηση στο τέλος άλλης παρουσίασης.
- Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση.
- Κλωνοποίηση σε συγκεκριμένη θέση σε άλλη παρουσίαση.

Στο Aspose.Slides for Python via .NET, η [συλλογή διαφανειών](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/) που παρέχεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) προσφέρει τις μεθόδους `add_clone` και `insert_clone` για την εκτέλεση αυτών των τύπων κλωνοποίησης διαφανειών.

## **Κλωνοποίηση στο Τέλος στην Ίδια Παρουσίαση**

Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια στην ίδια παρουσίαση και να την προσθέσετε στο τέλος των υφιστάμενων διαφανειών, χρησιμοποιήστε τη μέθοδο `add_clone`. Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Αποκτήστε τη συλλογή διαφανειών από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Καλέστε τη μέθοδο `add_clone` στην [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/), περνώντας τη διαφάνεια που θα κλωνοποιηθεί.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Στο παρακάτω παράδειγμα, η πρώτη διαφάνεια (δείκτης 0) κλωνοποιείται και προστίθεται στο τέλος της παρουσίασης.

```py
import aspose.slides as slides

# Δημιουργήστε την κλάση Presentation για να αντιπροσωπεύσετε το αρχείο παρουσίασης.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Κλωνοποιήστε την επιθυμητή διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση.
    presentation.slides.add_clone(presentation.slides[0])
    # Αποθηκεύστε την τροποποιημένη παρουσίαση στον δίσκο.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση σε Συγκεκριμένη Θέση στην Ίδια Παρουσίαση**

Εάν θέλετε να κλωνοποιήσετε μια διαφάνεια στην ίδια παρουσίαση και να την τοποθετήσετε σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο `insert_clone`:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Αποκτήστε τη συλλογή διαφανειών από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Καλέστε τη μέθοδο `insert_clone` στην [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/), περνώντας τη διαφάνεια που θα κλωνοποιηθεί και τον δείκτη‑στόχο για τη νέα θέση της.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Στο παρακάτω παράδειγμα, η διαφάνεια με δείκτη 0 (θέση 1) κλωνοποιείται στον δείκτη 1 (θέση 2) στην ίδια παρουσίαση.

```py
import aspose.slides as slides

# Δημιουργήστε την κλάση Presentation για να αντιπροσωπεύσετε το αρχείο παρουσίασης.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Κλωνοποιήστε την επιθυμητή διαφάνεια στην καθορισμένη θέση (δείκτη) μέσα στην ίδια παρουσίαση.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Αποθηκεύστε την τροποποιημένη παρουσίαση στον δίσκο.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση στο Τέλος Άλλης Παρουσίασης**

Εάν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να την προσθέσετε στο τέλος μιας άλλης παρουσίασης:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την παρουσίαση προέλευσης (την οποία περιέχει τη διαφάνεια προς κλωνοποίηση).
1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την παρουσίαση προορισμού (όπου θα προστεθεί η διαφάνεια).
1. Αποκτήστε τη συλλογή διαφανειών από την παρουσίαση προορισμού.
1. Καλέστε τη μέθοδο `add_clone` στη [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/) της προορισμού, περνώντας τη διαφάνεια από την παρουσίαση προέλευσης.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση προορισμού.

Στο παρακάτω παράδειγμα, η διαφάνεια με δείκτη 0 στην παρουσίαση προέλευσης κλωνοποιείται στο τέλος της παρουσίασης προορισμού.

```py
import aspose.slides as slides

# Δημιουργήστε την κλάση Presentation για να αντιπροσωπεύσετε το αρχείο παρουσίασης προέλευσης.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Δημιουργήστε την κλάση Presentation για το προορισμό PPTX (όπου θα κλωνοποιηθεί η διαφάνεια).
    with slides.Presentation() as target_presentation:
        # Κλωνοποιήστε την επιθυμητή διαφάνεια από την παρουσίαση προέλευσης στο τέλος της συλλογής διαφανειών στην παρουσίαση προορισμού.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Αποθηκεύστε την παρουσίαση προορισμού στον δίσκο.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση σε Συγκεκριμένη Θέση σε Άλλη Παρουσίαση**

Εάν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να την εισάγετε σε άλλη παρουσίαση σε συγκεκριμένη θέση:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την παρουσίαση προέλευσης (την οποία περιέχει τη διαφάνεια προς κλωνοποίηση).
1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την παρουσίαση προορισμού (όπου θα προστεθεί η διαφάνεια).
1. Αποκτήστε τη συλλογή διαφανειών από την παρουσίαση προορισμού.
1. Καλέστε τη μέθοδο `insert_clone` στη [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/) της προορισμού, περνώντας τη διαφάνεια από την παρουσίαση προέλευσης και τον επιθυμητό δείκτη‑στόχο.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση προορισμού.

Στο παρακάτω παράδειγμα, η διαφάνεια με δείκτη 0 στην παρουσίαση προέλευσης κλωνοποιείται στον δείκτη 1 (θέση 2) στην παρουσίαση προορισμού.

```py
import aspose.slides as slides

# Δημιουργήστε την κλάση Presentation για να αντιπροσωπεύσετε το αρχείο παρουσίασης προέλευσης.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Δημιουργήστε την κλάση Presentation για το αρχείο PPTX προορισμού (όπου θα κλωνοποιηθεί η διαφάνεια).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Εισάγετε ένα κλώνο της πρώτης διαφάνειας από την προέλευση στο δείκτη 2 στην παρουσίαση προορισμού.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Αποθηκεύστε την παρουσίαση προορισμού στον δίσκο.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση Διαφάνειας με το Κύριο Σχέδιο της σε Άλλη Παρουσίαση**

Εάν χρειάζεται να κλώνοποιήσετε μια διαφάνεια **με το κύριο σχέδιο** από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη, πρώτα κλωνοποιήστε το απαιτούμενο κύριο σχέδιο από την παρουσίαση προέλευσης στην παρουσίαση προορισμού. Στη συνέχεια, χρησιμοποιήστε αυτό το κύριο σχέδιο της προορισμού κατά την κλωνοποίηση της διαφάνειας. Η μέθοδος `add_clone(Slide, MasterSlide)` αναμένει ένα **κύριο σχέδιο από την παρουσίαση προορισμού**, όχι από την προέλευση.

Για να κλωνοποιήσετε μια διαφάνεια με το κύριο σχέδιο της, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την παρουσίαση προέλευσης (την οποία περιέχει τη διαφάνεια προς κλωνοποίηση).
1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την παρουσίαση προορισμού.
1. Προσπελάστε τη διαφάνεια προέλευσης που θα κλωνοποιηθεί και το κύριο σχέδιο της.
1. Αποκτήστε τη [MasterSlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/) από τη συλλογή κυρίων σχεδίων της παρουσίασης προορισμού.
1. Καλέστε τη μέθοδο `add_clone` στη [MasterSlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/), περνώντας το κύριο σχέδιο προέλευσης για να το κλωνοποιήσετε στην προορισμό.
1. Αποκτήστε τη [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/) από τη συλλογή διαφανειών της παρουσίασης προορισμού.
1. Καλέστε τη μέθοδο `add_clone` στη [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/), περνώντας τη διαφάνεια προέλευσης και το κλωνοποιημένο κύριο σχέδιο της προορισμού.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση προορισμού.

Στο παρακάτω παράδειγμα, η διαφάνεια με δείκτη 0 στην παρουσίαση προέλευσης κλωνοποιείται στο τέλος της παρουσίασης προορισμού χρησιμοποιώντας το κύριο σχέδιο που κλωνοποιήθηκε από την προέλευση.

```py
import aspose.slides as slides

# Δημιουργήστε την κλάση Presentation για να αντιπροσωπεύσετε το αρχείο παρουσίασης προέλευσης.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Δημιουργήστε την κλάση Presentation για την παρουσίαση προορισμού όπου θα κλωνοποιηθεί η διαφάνεια.
    with slides.Presentation() as target_presentation:
        # Αποκτήστε την πρώτη διαφάνεια από την παρουσίαση προέλευσης.
        source_slide = source_presentation.slides[0]
        # Αποκτήστε τη κύρια διαφάνεια που χρησιμοποιείται από την πρώτη διαφάνεια.
        source_master = source_slide.layout_slide.master_slide
        # Κλωνοποιήστε τη κύρια διαφάνεια στη συλλογή κυρίων διαφανειών της παρουσίασης προορισμού.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Κλωνοποιήστε τη διαφάνεια από την παρουσίαση προέλευσης στο τέλος της παρουσίασης προορισμού χρησιμοποιώντας τη κλωνοποιημένη κύρια διαφάνεια.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Αποθηκεύστε την παρουσίαση προορισμού στον δίσκο.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση στο Τέλος σε Καθορισμένη Ενότητα**

Με το Aspose.Slides for Python via .NET, μπορείτε να κλωνοποιήσετε μια διαφάνεια από μια ενότητα μιας παρουσίασης και να την εισάγετε σε άλλη ενότητα μέσα στην ίδια παρουσίαση. Για να το κάνετε αυτό, χρησιμοποιήστε τη μέθοδο `add_clone(Slide, Section)` της κλάσης [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/).

Το παρακάτω παράδειγμα Python δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να εισάγετε το κλώνο σε καθορισμένη ενότητα:

```py
import aspose.slides as slides

# Δημιουργήστε μια νέα κενή παρουσίαση.
with slides.Presentation() as presentation:
    # Προσθέστε μια κενή διαφάνεια βασισμένη στη διάταξη της πρώτης διαφάνειας.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Προσθέστε ένα σχήμα έλλειψης στη νέα διαφάνεια· αυτή η διαφάνεια θα κλωνοποιηθεί αργότερα.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Προσθέστε άλλη μια κενή διαφάνεια βασισμένη στη διάταξη της πρώτης διαφάνειας.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Δημιουργήστε μια ενότητα με όνομα "Section2" που ξεκινά στη διαφάνεια slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Κλωνοποιήστε την προηγουμένως δημιουργημένη διαφάνεια στην ενότητα "Section2".
    presentation.slides.add_clone(slide, section)
    # Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές Ερωτήσεις**

**Τα σημειώματα ομιλητή και τα σχόλια των αξιολογητών κλωνοποιούνται;**

Ναι. Η σελίδα σημειώματος και τα σχόλια αξιολόγησης περιλαμβάνονται στο κλώνο. Εάν δεν τα θέλετε, [αφαιρέστε τα](/slides/el/python-net/presentation-notes/) μετά την εισαγωγή.

**Πώς διαχειρίζονται τα γραφήματα και οι πηγές δεδομένων τους;**

Το αντικείμενο γραφήματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Εάν το γράφημα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ., ένα OLE‑ενσωματωμένο βιβλίο εργασίας), αυτή η σύνδεση διατηρείται ως ένα [αντικείμενο OLE](/slides/el/python-net/manage-ole/). Μετά τη μεταφορά μεταξύ αρχείων, ελέγξτε τη διαθεσιμότητα των δεδομένων και τη συμπεριφορά ενημέρωσης.

**Μπορώ να ελέγξω τη θέση εισαγωγής και τις ενότητες για το κλώνο;**

Ναι. Μπορείτε να εισάγετε το κλώνο σε συγκεκριμένο δείκτη διαφάνειας και να το τοποθετήσετε σε μια επιλεγμένη [ενότητα](/slides/el/python-net/slide-section/). Εάν η στοχευόμενη ενότητα δεν υπάρχει, δημιουργήστε την πρώτα και μετά μετακινήστε τη διαφάνεια σε αυτήν.