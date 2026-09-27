---
title: Δημιουργία Παρουσίασεων σε Python μέσω Java
linktitle: Δημιουργία Παρουσίασης
type: docs
weight: 10
url: /el/python-java/create-presentation/
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
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Δημιουργήστε παρουσιάσεις σε Python μέσω Java με Aspose.Slides - δημιουργήστε αρχεία PPT, PPTX και ODP, επωφεληθείτε από την υποστήριξη OpenDocument και αποθηκεύστε τα προγραμματιστικά για αξιόπιστα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια παρουσίαση με Aspose.Slides για Python μέσω Java, να προσθέσετε ένα σχήμα με κείμενο στην πρώτη διαφάνεια και να αποθηκεύσετε το αποτέλεσμα ως αρχείο PPTX. Η Συχνή Ερωτήσεις καλύπτει μορφές εξόδου, πρότυπα, μέγεθος διαφάνειας, χρήση μνήμης, πολυνηματισμό, αδειοδότηση, ψηφιακές υπογραφές και υποστήριξη VBA.

Πριν ξεκινήσετε, εγκαταστήστε την Python, ένα JDK, το JPype και το Aspose.Slides για Python μέσω Java. Δείτε την [Εγκατάσταση](/slides/el/python-java/installation/) για τα βήματα στα Windows, Linux και macOS.

## **Δημιουργία Παρουσίασης**

Η δημιουργία αρχείου PowerPoint από την αρχή στο Aspose.Slides για Python μέσω Java είναι τόσο απλή όσο η δημιουργία ενός αντικειμένου της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) . Ο κατασκευαστής παρέχει αυτόματα ένα κενό σετ με μία διαφάνεια, προσφέροντάς σας αμέσως έναν καμβά για σχήματα, κείμενο, γραφήματα ή οποιοδήποτε άλλο περιεχόμενο χρειάζεται η εφαρμογή σας. Μόλις τροποποιήσετε αυτή τη διαφάνεια — ή προσθέσετε νέες — μπορείτε να αποθηκεύσετε το αποτέλεσμα σε PPTX, κληροδοτημένο PPT ή ακόμη και σε μορφές OpenDocument. Το σύντομο παράδειγμα κώδικα παρακάτω δείχνει αυτή τη ροή εργασίας προσθέτοντας ένα απλό σχήμα στην πρώτη διαφάνεια.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Αποκτήστε την πρώτη διαφάνεια με το ευρετήριο της, 0.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) τύπου [ShapeType.Cloud](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Cloud) χρησιμοποιώντας το [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Ορίστε το κείμενο του σχήματος χρησιμοποιώντας το [TextFrame.setText](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#setText).
1. Αποθηκεύστε την παρουσίαση χρησιμοποιώντας το [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx).

Το παρακάτω παράδειγμα ξεκινά τη Java Virtual Machine (JVM) αν δεν εκτελείται ήδη, προσθέτει ένα σχήμα σύννεφων με κείμενο στην πρώτη διαφάνεια και αποθηκεύει την παρουσίαση. Αποθηκεύστε το ως *create_presentation.py*:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Δημιουργία παρουσίασης με μία κενή διαφάνεια.
presentation = Presentation()
try:
    # Λήψη της πρώτης διαφάνειας.
    slide = presentation.getSlides().get_Item(0)

    # Προσθήκη σχήματος σύννεφου και ορισμός του κειμένου.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Εκτελέστε το σενάριο στο περιβάλλον όπου εγκαταστήσατε τα πακέτα:

```sh
python create_presentation.py
```

Η πάνω‑αριστερή γωνία του σύννεφου βρίσκεται 20 σημεία από την αριστερή και την πάνω άκρη της διαφάνειας, και το σύννεφο έχει πλάτος 200 σημείων και ύψος 80 σημείων. Το σενάριο αποθηκεύει το *new_presentation.pptx* στον τρέχοντα φάκελο εργασίας, με μία διαφάνεια που περιέχει το σύννεφο και το κείμενό του. Η JVM συνεχίζει να εκτελείται μέχρι να τερματιστεί η διαδικασία Python· δείτε τις [Περιορισμοί και Διαφορές API](/slides/el/python-java/limitations-and-api-differences/#import-the-library). Χωρίς άδεια, το Aspose.Slides προσθέτει επίσης ένα πλαίσιο κειμένου υδατογράφησης αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει· δείτε την [Αδειοδότηση](/slides/el/python-java/licensing/).

Το αποτέλεσμα:

![Η νέα παρουσίαση](new_presentation.png)

## **Συχνές Ερωτήσεις**

**Σε ποιες μορφές μπορώ να αποθηκεύσω μια νέα παρουσίαση;**

Μπορείτε να αποθηκεύσετε σε [PPTX, PPT και ODP](/slides/el/python-java/save-presentation/), και να εξάγετε σε [PDF](/slides/el/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/el/python-java/convert-powerpoint-to-xps/), [HTML](/slides/el/python-java/convert-powerpoint-to-html/), [SVG](/slides/el/python-java/render-a-slide-as-an-svg-image/) και [εικόνες](/slides/el/python-java/convert-powerpoint-to-png/), μεταξύ άλλων.

**Μπορώ να ξεκινήσω από ένα πρότυπο (POTX/POTM) και να το αποθηκεύσω ως κανονικό PPTX;**

Ναι. Φορτώστε το πρότυπο και αποθηκεύστε στο επιθυμητό format· οι μορφές POTX/POTM/PPTM και παρόμοιες [υποστηρίζονται](/slides/el/python-java/supported-file-formats/).

**Πώς ελέγχω το μέγεθος/αναλογία διαφάνειας κατά τη δημιουργία μιας παρουσίασης;**

Ορίστε το [μέγεθος διαφάνειας](/slides/el/python-java/slide-size/) (συμπεριλαμβανομένων προεπιλογών όπως 4:3 και 16:9 ή προσαρμοσμένων διαστάσεων) και επιλέξτε πώς θα κλιμακωθεί το περιεχόμενο.

**Σε ποιες μονάδες μετρώνται τα μεγέθη και οι συντεταγμένες;**

Σε points: 1 ίντσα ισούται με 72 μονάδες.

**Πώς να διαχειριστώ πολύ μεγάλες παρουσιάσεις (με πολλά αρχεία πολυμέσων) για να μειώσω τη χρήση μνήμης;**

Χρησιμοποιήστε [στρατηγικές διαχείρισης BLOB](/slides/el/python-java/manage-blob/), περιορίστε την αποθήκευση στη μνήμη εκμεταλλευόμενοι προσωρινά αρχεία, και προτιμήστε ροές εργασίας βάσει αρχείων αντί για εντελώς ενθυλακωμένες ροές στη μνήμη.

**Μπορώ να δημιουργήσω/αποθηκεύσω παρουσιάσεις παράλληλα;**

Δεν μπορείτε να λειτουργήσετε στην ίδια παρουσίαση [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) από [πολλαπλά νήματα](/slides/el/python-java/multithreading/). Εκτελέστε ξεχωριστές, απομονωμένες παρουσίες ανά νήμα ή διεργασία.

**Πώς αφαιρώ το υδατογράφημα δοκιμής και τους περιορισμούς;**

[Εφαρμόστε άδεια](/slides/el/python-java/licensing/) μία φορά ανά διεργασία. Το XML της άδειας πρέπει να παραμείνει αμετάβλητο και η ρύθμιση της άδειας να συγχρονίζεται εάν εμπλέκονται πολλαπλά νήματα.

**Μπορώ να ψηφιακά υπογράψω το PPTX που δημιουργώ;**

Ναι. Οι [Ψηφιακές υπογραφές](/slides/el/python-java/digital-signature-in-powerpoint/) (προσθήκη και επαλήθευση) υποστηρίζονται για παρουσιάσεις.

**Υποστηρίζονται μακροεντολές (VBA) στις δημιουργημένες παρουσιάσεις;**

Ναι. Μπορείτε να [δημιουργήσετε/επεξεργαστείτε έργα VBA](/slides/el/python-java/presentation-via-vba/) και να αποθηκεύσετε αρχεία με ενεργοποιημένες μακροεντολές όπως PPTM/PPSM.