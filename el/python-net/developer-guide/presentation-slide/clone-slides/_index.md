---
title: Κλωνοποίηση διαφανειών PowerPoint σε Python
linktitle: Κλωνοποίηση διαφανειών
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
description: "Κλωνοποιήστε ή αντιγράψτε γρήγορα διαφάνειες PowerPoint με το Aspose.Slides for Python via .NET. Ακολουθήστε τα σαφή παραδείγματα κώδικα και τις συμβουλές μας για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα, να αυξήσετε την παραγωγικότητα και να απαλλάξετε από την χειροκίνητη εργασία."
---
## **Εισαγωγή**

Η κλωνοποίηση είναι η διαδικασία δημιουργίας ακριβούς αντιγράφου ή αντίγραφου κάτι. Το Aspose.Slides επίσης σας επιτρέπει να αντιγράψετε (κλωνοποιήσετε) οποιαδήποτε διαφάνεια και στη συνέχεια να εισάγετε τη κλωνοποιημένη διαφάνεια στην τρέχουσα παρουσίαση ή σε οποιαδήποτε άλλη ανοιχτή παρουσίαση. Η κλωνοποίηση διαφάνειας δημιουργεί μια νέα διαφάνεια που οι προγραμματιστές μπορούν να τροποποιήσουν χωρίς να επηρεάσουν την αρχική διαφάνεια. Υπάρχουν διάφοροι τρόποι κλωνοποίησης μιας διαφάνειας:

- Κλωνοποίηση στο τέλος μιας παρουσίασης.
- Κλωνοποίηση σε άλλη θέση μέσα σε μια παρουσίαση.
- Κλωνοποίηση στο τέλος άλλης παρουσίασης.
- Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση.
- Κλωνοποίηση σε συγκεκριμένη θέση σε άλλη παρουσίαση.

Στο Aspose.Slides for Python via .NET, η [συλλογή διαφανειών](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) παρέχει τις μεθόδους `add_clone` και `insert_clone` για την εκτέλεση αυτών των τύπων κλωνοποίησης διαφάνειας.

## **Εγκατάσταση**

```bash
pip install aspose.slides
```

## **Εγκατάσταση**

Αν θέλετε να κλωνοποιήσετε μια διαφάνεια στην ίδια παρουσίαση και να την προσθέσετε στο τέλος των υπαρχουσών διαφανειών, χρησιμοποιήστε τη μέθοδο `add_clone`. Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε τη συλλογή διαφανειών από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Καλέστε τη μέθοδο `add_clone` στη [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/), περνώντας τη διαφάνεια προς κλωνοποίηση.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Στο παρακάτω παράδειγμα, η πρώτη διαφάνεια (δείκτης 0) κλωνοποιείται και προστίθεται στο τέλος της παρουσίασης.

```py
import aspose.slides as slides

# Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation για να αντιπροσωπεύει το αρχείο παρουσίασης.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Κλωνοποιήστε τη ζητούμενη διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση.
    presentation.slides.add_clone(presentation.slides[0])
    # Αποθηκεύστε την τροποποιημένη παρουσίαση στο δίσκο.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση σε Συγκεκριμένη Θέση εντός της Ίδιας Παρουσίασης**

Αν θέλετε να κλωνοποιήσετε μια διαφάνεια στην ίδια παρουσίαση και να την τοποθετήσετε σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο `insert_clone`:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Λάβετε τη συλλογή διαφανειών από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Καλέστε τη μέθοδο `insert_clone` στη [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/), περνώντας τη διαφάνεια προς κλωνοποίηση και τον στόχο δείκτη για τη νέα θέση της.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Στο παρακάτω παράδειγμα, η διαφάνεια με δείκτη 1 (θέση 2) κλωνοποιείται στον δείκτη 2 (θέση 3) μέσα στην ίδια παρουσίαση.

```py
import aspose.slides as slides

# Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation για να αντιπροσωπεύει το αρχείο παρουσίασης.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Κλωνοποιήστε τη ζητούμενη διαφάνεια στη συγκεκριμένη θέση (δείκτη) μέσα στην ίδια παρουσίαση.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Αποθηκεύστε την τροποιημένη παρουσίαση στο δίσκο.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση στο Τέλος Άλλης Παρουσίασης**

Αν χρειάζεστε να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να την προσθέσετε στο τέλος μιας άλλης παρουσίασης:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την πηγαία παρουσίαση (αυτή που περιέχει τη διαφάνεια προς κλωνοποίηση).
1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την προορισμού παρουσίαση (όπου θα προστεθεί η διαφάνεια).
1. Λάβετε τη συλλογή διαφανειών από την προορισμού παρουσίαση.
1. Καλέστε `add_clone` στη [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/) της προορισμού, περνώντας τη διαφάνεια από την πηγαία παρουσίαση.
1. Αποθηκεύστε την τροποποιημένη προορισμού παρουσίαση.

Στο παρακάτω παράδειγμα, η διαφάνεια με δείκτη 0 στην πηγαία παρουσίαση κλωνοποιείται στο τέλος της προορισμού παρουσίασης.

```py
import aspose.slides as slides

# Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation για να αντιπροσωπεύει το αρχείο πηγαίας παρουσίασης.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation για το προορισμό PPTX (όπου θα κλωνοποιηθεί η διαφάνεια).
    with slides.Presentation() as target_presentation:
        # Κλωνοποιήστε τη ζητούμενη διαφάνεια από την πηγαία παρουσίαση στο τέλος της συλλογής διαφανειών στην παρουσίαση προορισμού.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Αποθηκεύστε την παρουσίαση προορισμού στο δίσκο.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση σε Συγκεκριμένη Θέση Άλλης Παρουσίασης**

Αν χρειάζεστε να κλωνοποιήσετε μια διαφάνεια από μια παρουσίαση και να την εισάγετε σε άλλη παρουσίαση σε συγκεκριμένη θέση:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την πηγαία παρουσίαση (η οποία περιέχει τη διαφάνεια προς κλωνοποίηση).
1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την προορισμού παρουσίαση (όπου θα προστεθεί η διαφάνεια).
1. Λάβετε τη συλλογή διαφανειών από την προορισμού παρουσίαση.
1. Καλέστε τη μέθοδο `insert_clone` στη [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/) της προορισμού, περνώντας τη διαφάνεια από την πηγαία παρουσίαση και τον επιθυμητό δείκτη στόχου.
1. Αποθηκεύστε την τροποποιημένη προορισμού παρουσίαση.

Στο παρακάτω παράδειγμα, η διαφάνεια με δείκτη 0 στην πηγαία παρουσίαση κλωνοποιείται στον δείκτη 2 (θέση 3) στην προορισμού παρουσίαση.

```py
import aspose.slides as slides

# Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation για να αντιπροσωπεύει το αρχείο πηγαίας παρουσίασης.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation για το αρχείο PPTX προορισμού (όπου θα κλωνοποιηθεί η διαφάνεια).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Τοποθετήστε ένα κλώνο της πρώτης διαφάνειας από την πηγή στον δείκτη 2 στην παρουσίαση προορισμού.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Αποθηκεύστε την παρουσίαση προορισμού στο δίσκο.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση Διαφάνειας μαζί με την Κύρια Διαφάνειά της σε Άλλη Παρουσίαση**

Αν χρειάζεστε να κλωνοποιήσετε μια διαφάνεια **μαζί με την κύρια της** από μια παρουσίαση και να τη χρησιμοποιήσετε σε άλλη, πρώτα κλωνοποιήστε την απαιτούμενη κύρια διαφάνεια από την πηγαία παρουσίαση στην προορισμού παρουσίαση. Στη συνέχεια, χρησιμοποιήστε αυτή την προορισμού κύρια διαφάνεια όταν κλωνοποιείτε τη διαφάνεια. Η μέθοδος `add_clone(Slide, MasterSlide)` αναμένει μια **κύρια διαφάνεια από την προορισμού παρουσίαση**, όχι από την πηγαία.

Για να κλωνοποιήσετε μια διαφάνεια μαζί με την κύρια της, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την πηγαία παρουσίαση.
1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την προορισμού παρουσίαση.
1. Πρόσβαση στη πηγαία διαφάνεια που θα κλωνοποιηθεί και στην κύρια της.
1. Λάβετε το [MasterSlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/) από τη συλλογή κύρων της προορισμού παρουσίασης.
1. Καλέστε `add_clone` στη [MasterSlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/) της προορισμού, περνώντας την πηγαία κύρια διαφάνεια για να την κλωνοποιήσετε στην προορισμού.
1. Λάβετε το [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/) από τη συλλογή διαφανειών της προορισμού παρουσίασης.
1. Καλέστε `add_clone` στη [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/) της προορισμού, περνώντας τη πηγαία διαφάνεια και την κλωνοποιημένη προορισμού κύρια.
1. Αποθηκεύστε την τροποποιημένη προορισμού παρουσίαση.

Στο παρακάτω παράδειγμα, η διαφάνεια με δείκτη 0 στην πηγαία παρουσίαση κλωνοποιείται στο τέλος της προορισμού παρουσίασης χρησιμοποιώντας την κύρια που κλωνοποιήθηκε από την πηγαία.

```py
import aspose.slides as slides

# Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation για να αντιπροσωπεύει το αρχείο πηγαίας παρουσίασης.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation για την παρουσίαση προορισμού όπου θα κλωνοποιηθεί η διαφάνεια.
    with slides.Presentation() as target_presentation:
        # Λάβετε την πρώτη διαφάνεια από την πηγαία παρουσίαση.
        source_slide = source_presentation.slides[0]
        # Λάβετε τη κύρια διαφάνεια που χρησιμοποιείται από την πρώτη διαφάνεια.
        source_master = source_slide.layout_slide.master_slide
        # Κλωνοποιήστε τη κύρια διαφάνεια στη συλλογή κυρίων διαφανειών της προορισμένης παρουσίασης.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Κλωνοποιήστε τη διαφάνεια από την πηγαία παρουσίαση στο τέλος της παρουσίασης προορισμού χρησιμοποιώντας τη κλωνοποιημένη κύρια.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Αποθηκεύστε την παρουσίαση προορισμού στο δίσκο.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση στο Τέλος σε Καθορισμένο Τμήμα**

Με το Aspose.Slides for Python via .NET, μπορείτε να κλωνοποιήσετε μια διαφάνεια από ένα τμήμα μιας παρουσίασης και να την εισάγετε σε άλλο τμήμα μέσα στην ίδια παρουσίαση. Για να το κάνετε αυτό, χρησιμοποιήστε τη μέθοδο `add_clone(Slide, Section)` της κλάσης [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/).

Το παρακάτω παράδειγμα Python δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να εισάγετε το αντίγραφο σε καθορισμένο τμήμα:

```py
import aspose.slides as slides

# Δημιουργήστε μια νέα κενή παρουσίαση.
with slides.Presentation() as presentation:
    # Προσθέστε μια κενή διαφάνεια βασισμένη στη διάταξη της πρώτης διαφάνειας.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Προσθέστε ένα σχήμα έλλειψης στη νέα διαφάνεια· αυτή η διαφάνεια θα κλωνοποιηθεί αργότερα.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Προσθέστε μια άλλη κενή διαφάνεια βασισμένη στη διάταξη της πρώτης διαφάνειας.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Δημιουργήστε ένα τμήμα με όνομα "Section2" που ξεκινά στη διαφάνεια2.
    section = presentation.sections.add_section("Section2", slide2)
    # Κλωνοποιήστε τη διαφάνεια που δημιουργήθηκε προηγουμένως στο τμήμα "Section2".
    presentation.slides.add_clone(slide, section)
    # Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Διασφάλιση Συμφωνίας Μεγέθους Διαφάνειας**

Κατά την κλωνοποίηση διαφανειών σε άλλη παρουσίαση, βεβαιωθείτε ότι η προορισμού παρουσίαση έχει το ίδιο μέγεθος διαφάνειας με την πηγαία. Αν τα μεγέθη διαφανειών διαφέρουν, το Aspose.Slides δεν επανεκτελεί αυτόματα την κλιμάκωση των κλωνοποιημένων σχημάτων· οι αρχικές συντεταγμένες και διαστάσεις διατηρούνται, κάτι που μπορεί να οδηγήσει σε ακατάλληλη τοποθέτηση ή υπέρβαση των ορίων της διαφάνειας.

Μπορείτε να ρυθμίσετε το μέγεθος διαφάνειας της προορισμού παρουσίασης ώστε να ταιριάζει με το μέγεθος της πηγαίας πριν κλωνοποιήσετε την κύρια και τη διαφάνεια:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Κάντε αυτό πριν κλωνοποιήσετε την κύρια και τη διαφάνεια.

## **Συχνές Ερωτήσεις**

**Κλωνοποιούνται οι σημειώσεις ομιλητή και τα σχόλια αξιολογητών;**

Ναι. Η σελίδα σημειώσεων και τα σχόλια αξιολογητών περιλαμβάνονται στην κλωνοποίηση. Αν δεν τα θέλετε, [αφαιρέστε τα](/slides/el/python-net/presentation-notes/) μετά την εισαγωγή.

**Πώς διαχειρίζονται τα διαγράμματα και οι πηγές δεδομένων τους;**

Το αντικείμενο διαγράμματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Αν το διάγραμμα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ. ένα OLE‑ενσωματωμένο βιβλίο εργασίας), αυτή η σύνδεση διατηρείται ως [αντικείμενο OLE](/slides/el/python-net/manage-ole/). Μετά τη μεταφορά μεταξύ αρχείων, ελέγξτε τη διαθεσιμότητα των δεδομένων και τη συμπεριφορά ανανέωσης.

**Μπορώ να ελέγξω τη θέση εισαγωγής και τα τμήματα για την κλωνοποίηση;**

Ναι. Μπορείτε να εισάγετε το αντίγραφο σε συγκεκριμένο δείκτη διαφάνειας και να το τοποθετήσετε σε επιλεγμένο [τμήμα](/slides/el/python-net/slide-section/). Αν το τμήμα προορισμού δεν υπάρχει, δημιουργήστε το πρώτα και μετά μετακινήστε τη διαφάνεια σε αυτό.
