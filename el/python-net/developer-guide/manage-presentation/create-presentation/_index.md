---
title: Δημιουργία Παρουσιάσεων σε Python
linktitle: Δημιουργία Παρουσίασης
type: docs
weight: 10
url: /el/python-net/create-presentation/
keywords:
- δημιουργία παρουσίασης
- νέα παρουσίαση
- δημιουργία PPT
- νέο PPT
- δημιουργία PPTX
- νέο PPTX
- δημιουργία ODP
- νέο ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Δημιουργήστε παρουσιάσεις PowerPoint σε Python με το Aspose.Slides—δημιουργήστε αρχεία PPT, PPTX και ODP, επωφεληθείτε από την υποστήριξη OpenDocument και αποθηκεύστε τα προγραμματιστικά για αξιόπιστα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια παρουσίαση με Aspose.Slides για Python μέσω .NET, να προσθέσετε ένα σχήμα με κείμενο στη πρώτη της διαφάνεια και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX. Το ίδιο API αποθηκεύει επίσης παρουσιάσεις ως PPT και ODP, ώστε να μπορείτε να στοχεύετε τόσο σε μορφές PowerPoint όσο και OpenDocument από μια βάση κώδικα, χωρίς το Microsoft Office. Μια σύντομη FAQ στο τέλος καλύπτει συνήθεις ερωτήσεις σχετικά με μορφές, πρότυπα, μεγέθυνση διαφάνειας, μονάδες, χρήση μνήμης, ταυτόχρονη εκτέλεση, αδειοδότηση, ψηφιακές υπογραφές και υποστήριξη VBA.

Πριν ξεκινήσετε, εγκαταστήστε το πακέτο από το PyPI με `pip install aspose.slides`. Δείτε την [Installation](/slides/el/python-net/installation/) για τις βιβλιοθήκες που χρειάζονται επίσης τα Linux και macOS, καθώς και για το εικονικό περιβάλλον που απαιτεί το σύστημα Python των Debian και Ubuntu.

## **Δημιουργία Παρουσίασης**

Για να δημιουργήσετε μια παρουσίαση και να τοποθετήσετε ένα σχήμα με κείμενο στην πρώτη της διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Μια νέα παρουσίαση περιέχει ήδη μια κενή διαφάνεια.
1. Αποκτήστε αυτήν τη διαφάνεια από τη συλλογή [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) με βάση το δείκτη της, 0.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) σε σχήμα σύννεφου με τη μέθοδο [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) της συλλογής [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) της διαφάνειας και ορίστε το [text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text/).
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX με τη μέθοδο [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

```py
import aspose.slides as slides

# Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:
    # Πάρτε την πρώτη διαφάνεια.
    slide = presentation.slides[0]

    # Προσθέστε ένα αυτόματο σχήμα τύπου CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Η επάνω‑αριστερή γωνία του σύννεφου βρίσκεται 20 points από την αριστερή άκρη και 20 points από την επάνω άκρη της διαφάνειας, ενώ το σύννεφο έχει πλάτος 200 points και ύψος 80 points. Η δήλωση `with` απελευθερώνει τους πόρους της παρουσίασης όταν το μπλοκ λήγει. Το σενάριο αποθηκεύει το *new_presentation.pptx* στον τρέχοντα φάκελο, με μία διαφάνεια που περιέχει το σύννεφο και το κείμενό του. Χωρίς άδεια, το Aspose.Slides προσθέτει επίσης υδατογράφημα αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει· δείτε την [Αδειοδότηση](/slides/el/python-net/licensing/).

Το αποτέλεσμα:

![Η νέα παρουσίαση](new_presentation.png)

## **Συχνές Ερωτήσεις**

### Σε ποιες μορφές μπορώ να αποθηκεύσω μια νέα παρουσίαση;

Μπορείτε να αποθηκεύσετε σε [PPTX, PPT, and ODP](/slides/el/python-net/save-presentation/), και να εξάγετε σε [PDF](/slides/el/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/el/python-net/convert-powerpoint-to-xps/), [HTML](/slides/el/python-net/convert-powerpoint-to-html/), [SVG](/slides/el/python-net/render-a-slide-as-an-svg-image/), και [images](/slides/el/python-net/convert-powerpoint-to-png/), μεταξύ άλλων.

### Μπορώ να ξεκινήσω από ένα πρότυπο (POTX/POTM) και να αποθηκεύσω ως κανονικό PPTX;

Ναι. Φορτώστε το πρότυπο και αποθηκεύστε το στην επιθυμητή μορφή· τα μορφές POTX/POTM/PPTM και παρόμοιες [υποστηρίζονται](/slides/el/python-net/supported-file-formats/).

### Πώς ελέγχω το μέγεθος/αναλογία διαφάνειας κατά τη δημιουργία μιας παρουσίασης;

Ορίστε το [μέγεθος διαφάνειας](/slides/el/python-net/slide-size/) (συμπεριλαμβανομένων προεπιλογών όπως 4:3 και 16:9 ή προσαρμοσμένες διαστάσεις) και επιλέξτε πώς θα κλιμακωθεί το περιεχόμενο.

### Σε ποιες μονάδες μετρώνται τα μεγέθη και οι συντεταγμένες;

Σε points: 1 ίντσα ισούται με 72 μονάδες.

### Πώς διαχειρίζομαι πολύ μεγάλες παρουσιάσεις (με πολλαπλά αρχεία πολυμέσων) για να μειώσω τη χρήση μνήμης;

Χρησιμοποιήστε τις [BLOB management strategies](/slides/el/python-net/manage-blob/), περιορίστε την αποθήκευση στη μνήμη αξιοποιώντας προσωρινά αρχεία και προτιμήστε διαδικασίες βασισμένες σε αρχεία αντί για καθαρά ροές στη μνήμη.

### Μπορώ να δημιουργήσω/αποθηκεύσω παρουσιάσεις παράλληλα;

Δεν μπορείτε να λειτουργήσετε στην ίδια [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) παρουσία από [πολλαπλά νήματα](/slides/el/python-net/multithreading/). Εκτελέστε ξεχωριστές, απομονωμένες παρουσίες ανά νήμα ή διεργασία.

### Πώς αφαιρώ το υδατογράφημα δοκιμής και τους περιορισμούς;

[Εφαρμόστε άδεια](/slides/el/python-net/licensing/) μία φορά ανά διεργασία. Το αρχείο XML της άδειας πρέπει να παραμείνει αμετάβλητο, και η ρύθμιση της άδειας πρέπει να συγχρονίζεται εάν εμπλέκονται πολλαπλά νήματα.

### Μπορώ να υπογράψω ψηφιακά το PPTX που δημιουργώ;

Ναι. Οι [Ψηφιακές υπογραφές](/slides/el/python-net/digital-signature-in-powerpoint/) (προσθήκη και επαλήθευση) υποστηρίζονται για παρουσιάσεις.

### Υποστηρίζονται μακροεντολές (VBA) στις δημιουργημένες παρουσιάσεις;

Ναι. Μπορείτε να [δημιουργήσετε/τροποποιήσετε έργα VBA](/slides/el/python-net/presentation-via-vba/) και να αποθηκεύσετε αρχεία με ενεργές μακροεντολές όπως PPTM/PPSM.