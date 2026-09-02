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
description: "Κλωνοποιήστε ή αντιγράψτε γρήγορα διαφάνειες PowerPoint με το Aspose.Slides για Python μέσω .NET. Ακολουθήστε τα σαφή παραδείγματα κώδικα και τις συμβουλές μας για να αυτοματοποιήσετε τη δημιουργία PPT σε δευτερόλεπτα, να αυξήσετε την παραγωγικότητα και να αφαιρέσετε την χειροκίνητη εργασία."
---
## **Εισαγωγή**

Η κλωνοποίηση είναι η διαδικασία δημιουργίας ενός ακριβούς αντιγράφου ή αντιότυπου κάτι. Το Aspose.Slides επίσης επιτρέπει την αντιγραφή (κλωνοποίηση) οποιασδήποτε διαφάνειας και στη συνέχεια την εισαγωγή της κλωνοποιημένης διαφάνειας στην τρέχουσα παρουσίαση ή σε οποιαδήποτε άλλη ανοιχτή παρουσίαση. Η κλωνοποίηση διαφάνειας δημιουργεί μια νέα διαφάνεια που μπορούν οι προγραμματιστές να τροποποιήσουν χωρίς να επηρεάσουν την αρχική διαφάνεια. Υπάρχουν διάφοροι τρόποι για να κλωνοποιήσετε μια διαφάνεια:

- Κλωνοποίηση στο τέλος μιας παρουσίασης.
- Κλωνοποίηση σε άλλη θέση μέσα σε μια παρουσίαση.
- Κλωνοποίηση στο τέλος άλλης παρουσίασης.
- Κλωνοποίηση σε άλλη θέση σε άλλη παρουσίαση.
- Κλωνοποίηση σε συγκεκριμένη θέση σε άλλη παρουσίαση.

Στο Aspose.Slides for Python via .NET, η [συλλογή διαφανειών](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/) που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) παρέχει τις μεθόδους `add_clone` και `insert_clone` για να εκτελέσετε αυτούς τους τύπους κλωνοποίησης διαφάνειας.

## **Εγκατάσταση**

```bash
pip install aspose.slides
```

## **Κλωνοποίηση στο Τέλος εντός της Ίδιας Παρουσίασης**

Αν θέλετε να κλωνοποιήσετε μια διαφάνεια εντός της ίδιας παρουσίασης και να την προσθέσετε στο τέλος των υπαρχόντων διαφανειών, χρησιμοποιήστε τη μέθοδο `add_clone`. Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Αποκτήστε τη συλλογή διαφανειών από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Καλέστε τη μέθοδο `add_clone` στην [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/), περνώντας τη διαφάνεια που θα κλωνοποιηθεί.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Στο παρακάτω παράδειγμα, η πρώτη διαφάνεια (δείκτης 0) κλωνοποιείται και προστίθεται στο τέλος της παρουσίασης.

```py
import aspose.slides as slides

# Δημιουργήστε αντικείμενο της κλάσης Presentation για να αντιπροσωπεύει το αρχείο παρουσίασης.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Κλωνοποιήστε τη ζητούμενη διαφάνεια στο τέλος της συλλογής διαφανειών στην ίδια παρουσίαση.
    presentation.slides.add_clone(presentation.slides[0])
    # Αποθηκεύστε την τροποποιημένη παρουσίαση στο δίσκο.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση σε Συγκεκριμένη Θέση εντός της Ίδιας Παρουσίασης**

Αν θέλετε να κλωνοποιήσετε μια διαφάνεια εντός της ίδιας παρουσίασης και να τη τοποθετήσετε σε διαφορετική θέση, χρησιμοποιήστε τη μέθοδο `insert_clone`:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Αποκτήστε τη συλλογή διαφανειών από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/).
1. Καλέστε τη μέθοδο `insert_clone` στην [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/), περνώντας τη διαφάνεια που θα κλωνοποιηθεί και το δείκτη-στόχο για τη νέα της θέση.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Στο παρακάτω παράδειγμα, η διαφάνεια με δείκτη 1 (θέση 2) κλωνοποιείται στον δείκτη 2 (θέση 3) εντός της ίδιας παρουσίασης.

```py
import aspose.slides as slides

# Δημιουργήστε αντικείμενο της κλάσης Presentation για να αντιπροσωπεύει το αρχείο παρουσίασης.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Κλωνοποιήστε τη ζητούμενη διαφάνεια στην καθορισμένη θέση (δείκτη) μέσα στην ίδια παρουσίαση.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Αποθηκεύστε την τροποποιημένη παρουσίαση στο δίσκο.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση στο Τέλος Άλλης Παρουσίασης**

Αν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μία παρουσίαση και να την προσθέσετε στο τέλος μιας άλλης παρουσίασης:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την πηγή παρουσίαση (αυτή που περιέχει τη διαφάνεια προς κλωνοποίηση).
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την προορισμένη παρουσίαση (όπου η διαφάνεια θα προστεθεί).
1. Αποκτήστε τη συλλογή διαφανειών από την προορισμένη παρουσίαση.
1. Καλέστε το `add_clone` στη προορισμένη [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/), περνώντας τη διαφάνεια από την πηγή παρουσίαση.
1. Αποθηκεύστε την τροποποιημένη προορισμένη παρουσίαση.

Στο παρακάτω παράδειγμα, η διαφάνεια με δείκτη 0 στην πηγή παρουσίαση κλωνοποιείται στο τέλος της προορισμένης παρουσίασης.

```py
import aspose.slides as slides

# Δημιουργήστε αντικείμενο της κλάσης Presentation για να αντιπροσωπεύει το αρχείο πηγής παρουσίασης.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Δημιουργήστε αντικείμενο της κλάσης Presentation για το προορισμένο PPTX (όπου θα κλωνοποιηθεί η διαφάνεια).
    with slides.Presentation() as target_presentation:
        # Κλωνοποιήστε τη ζητούμενη διαφάνεια από την παρουσίαση πηγής στο τέλος της συλλογής διαφανειών στην προορισμένη παρουσίαση.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Αποθηκεύστε την προορισμένη παρουσίαση στο δίσκο.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση σε Συγκεκριμένη Θέση σε Άλλη Παρουσίαση**

Αν χρειάζεται να κλωνοποιήσετε μια διαφάνεια από μία παρουσίαση και να την εισάγετε σε άλλη παρουσίαση σε συγκεκριμένη θέση:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την πηγή παρουσίαση (αυτή που περιέχει τη διαφάνεια προς κλωνοποίηση).
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την προορισμένη παρουσίαση (όπου η διαφάνεια θα προστεθεί).
1. Αποκτήστε τη συλλογή διαφανειών από την προορισμένη παρουσίαση.
1. Καλέστε τη μέθοδο `insert_clone` στη προορισμένη [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/), περνώντας τη διαφάνεια από την πηγή παρουσίαση και τον επιθυμητό δείκτη-στόχο.
1. Αποθηκεύστε την τροποποιημένη προορισμένη παρουσίαση.

Στο παρακάτω παράδειγμα, η διαφάνεια με δείκτη 0 στην πηγή παρουσίαση κλωνοποιείται στον δείκτη 2 (θέση 3) στην προορισμένη παρουσίαση.

```py
import aspose.slides as slides

# Δημιουργήστε αντικείμενο της κλάσης Presentation για να αντιπροσωπεύει το αρχείο πηγής παρουσίασης.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Δημιουργήστε αντικείμενο της κλάσης Presentation για το προορισμένο PPTX (όπου η διαφάνεια θα κλωνοποιηθεί).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Εισάγετε μια κλωνοποίηση της πρώτης διαφάνειας από την πηγή στον δείκτη 2 στην προορισμένη παρουσίαση.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Αποθηκεύστε την προορισμένη παρουσίαση στο δίσκο.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση Διαφάνειας με την Κύρια Διαφάνειά της σε Άλλη Παρουσίαση**

Αν χρειάζεται να κλωνοποιήσετε μια διαφάνεια **με την κύρια διαφάνειά της** από μία παρουσίαση και να τη χρησιμοποιήσετε σε άλλη, πρώτα κλωνοποιήστε τη ζητούμενη κύρια διαφάνεια από την πηγή παρουσίαση στην προορισμένη παρουσίαση. Στη συνέχεια χρησιμοποιήστε αυτήν την προορισμένη κύρια διαφάνεια κατά την κλωνοποίηση της διαφάνειας. Η μέθοδος `add_clone(Slide, MasterSlide)` αναμένει μια **κύρια διαφάνεια από την προορισμένη παρουσίαση**, όχι από την πηγή.

Για να κλωνοποιήσετε μια διαφάνεια με την κύρια της, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την πηγή παρουσίαση (αυτή που περιέχει τη διαφάνεια προς κλωνοποίηση).
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για την προορισμένη παρουσίαση.
1. Πρόσβαση στη διαφάνεια που θα κλωνοποιηθεί και στην κύρια διαφάνειά της.
1. Αποκτήστε τη [MasterSlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/) από τη συλλογή κυρίων διαφανειών της προορισμένης παρουσίασης.
1. Καλέστε `add_clone` στη προορισμένη [MasterSlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/masterslidecollection/), περνώντας τη πηγαία κύρια διαφάνεια για να την κλωνοποιήσετε στην προορισμένη.
1. Αποκτήστε τη [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/) από τη συλλογή διαφανειών της προορισμένης παρουσίασης.
1. Καλέστε `add_clone` στη προορισμένη [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/), περνώντας τη πηγαία διαφάνεια και την κλωνοποιημένη προορισμένη κύρια διαφάνεια.
1. Αποθηκεύστε την τροποποιημένη προορισμένη παρουσίαση.

Στο παρακάτω παράδειγμα, η διαφάνεια με δείκτη 0 στην πηγή παρουσίαση κλωνοποιείται στο τέλος της προορισμένης παρουσίασης χρησιμοποιώντας την κύρια διαφάνεια που κλωνοποιήθηκε από την πηγή.

```py
import aspose.slides as slides

# Δημιουργήστε αντικείμενο της κλάσης Presentation για να αντιπροσωπεύει το αρχείο πηγής παρουσίασης.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Δημιουργήστε αντικείμενο της κλάσης Presentation για την προορισμένη παρουσίαση όπου θα κλωνοποιηθεί η διαφάνεια.
    with slides.Presentation() as target_presentation:
        # Αποκτήστε την πρώτη διαφάνεια από την πηγή παρουσίαση.
        source_slide = source_presentation.slides[0]
        # Αποκτήστε τη κύρια διαφάνεια που χρησιμοποιείται από την πρώτη διαφάνεια.
        source_master = source_slide.layout_slide.master_slide
        # Κλωνοποιήστε τη κύρια διαφάνεια στη συλλογή κυρίων διαφανειών της προορισμένης παρουσίασης.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Κλωνοποιήστε τη διαφάνεια από την πηγή παρουσίαση στο τέλος της προορισμένης παρουσίασης χρησιμοποιώντας τη κλωνοποιημένη κύρια διαφάνεια.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Αποθηκεύστε την προορισμένη παρουσίαση στο δίσκο.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Κλωνοποίηση στο Τέλος σε Καθορισμένη Ενότητα**

Με το Aspose.Slides for Python via .NET, μπορείτε να κλωνοποιήσετε μια διαφάνεια από μία ενότητα μιας παρουσίασης και να τη εισάγετε σε άλλη ενότητα μέσα στην ίδια παρουσίαση. Για να το κάνετε αυτό, χρησιμοποιήστε τη μέθοδο `add_clone(Slide, Section)` της κλάσης [SlideCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/).

Το παρακάτω παράδειγμα Python δείχνει πώς να κλωνοποιήσετε μια διαφάνεια και να εισάγετε την κλωνοποίηση σε καθορισμένη ενότητα:

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
    # Δημιουργήστε μια ενότητα με όνομα "Section2" που ξεκινά στη διαφάνεια2.
    section = presentation.sections.add_section("Section2", slide2)
    # Κλωνοποιήστε τη διαφάνεια που δημιουργήθηκε προηγουμένως στη ενότητα "Section2".
    presentation.slides.add_clone(slide, section)
    # Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές ερωτήσεις**

### Αντιγράφονται οι σημειώσεις ομιλητή και τα σχόλια του ελεγκτή;

Ναι. Η σελίδα σημειώσεων και τα σχόλια ελέγχου περιλαμβάνονται στην κλωνοποίηση. Αν δεν τα θέλετε, [αφαιρέστε τα](/slides/el/python-net/presentation-notes/) μετά την εισαγωγή.

### Πώς διαχειρίζονται τα γραφήματα και οι πηγές δεδομένων τους;

Το αντικείμενο γραφήματος, η μορφοποίηση και τα ενσωματωμένα δεδομένα αντιγράφονται. Αν το γράφημα ήταν συνδεδεμένο με εξωτερική πηγή (π.χ., ένα ενσωματωμένο OLE workbook), η σύνδεση διατηρείται ως ένα [OLE object](/slides/el/python-net/manage-ole/). Μετά τη μετακίνηση μεταξύ αρχείων, ελέγξτε τη διαθεσιμότητα των δεδομένων και τη συμπεριφορά ανανέωσης.

### Μπορώ να ελέγξω τη θέση εισαγωγής και τις ενότητες για την κλωνοποίηση;

Ναι. Μπορείτε να εισάγετε την κλωνοποίηση σε συγκεκριμένο δείκτη διαφάνειας και να τη τοποθετήσετε σε μια επιλεγμένη [ενότητα](/slides/el/python-net/slide-section/). Αν η στοχευόμενη ενότητα δεν υπάρχει, δημιουργήστε την πρώτα και στη συνέχεια μετακινήστε τη διαφάνεια σε αυτήν.