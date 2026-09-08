---
title: Λειτουργίες Παρουσίασης Χαμηλού Κώδικα σε Python μέσω Java
linktitle: API Χαμηλού Κώδικα
type: docs
weight: 50
url: /el/python-java/low-code-presentation-operations/
keywords:
- API παρουσίασης χαμηλού κώδικα
- μετατροπή παρουσίασης
- συγχώνευση παρουσιάσεων
- επανάληψη διαφανειών
- επανάληψη σχημάτων
- επανάληψη κειμένου
- συλλογή σχημάτων
- συμπίεση παρουσίασης
- αφαίρεση αχρησιμοποίητων master διαφανειών
- αφαίρεση αχρησιμοποίητων layout διαφανειών
- συμπίεση ενσωματωμένων γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Χρησιμοποιήστε το API χαμηλού κώδικα Aspose.Slides σε Python μέσω Java για να μετατρέψετε και να συγχωνεύσετε παρουσιάσεις, να επαναλάβετε το περιεχόμενο, να συλλέξετε σχήματα και να μειώσετε το μέγεθος της παρουσίασης."
---
## **Επισκόπηση**

Το API [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/el/python-java/aspose.slides/) παρέχει στατικές βοηθητικές κλάσεις για κοινές λειτουργίες παρουσίασης. Αυτοί οι βοηθοί περιβάλλουν συχνά χρησιμοποιούμενες ροές εργασίας του μοντέλου αντικειμένων σε εστιασμένες μεθόδους, ώστε να μπορείτε να μετατρέπετε ή να συγχωνεύετε αρχεία, να επεξεργάζεστε στοιχεία παρουσίασης, να συλλέγετε σχήματα και να αφαιρείτε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθοί χαμηλού κώδικα είναι πιο χρήσιμοι όταν η λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή εργασίας ταιριάζει με τις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες [Aspose.Slides object model](https://reference.aspose.com/slides/el/python-java/aspose.slides/) όταν χρειάζεστε λεπτομερή έλεγχο των επιμέρους διαφανειών, master, layout, σχημάτων, ρυθμίσεων εξαγωγής ή σχέσεων μεταξύ των στοιχείων παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τους διαθέσιμους βοηθούς:

| Βοηθός | Χρήση |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/python-java/aspose.slides/convert/) | Μετατροπή παρουσίασης σε άλλη μορφή με άμεση κλήση αρχείου‑σε‑αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/python-java/aspose.slides/merger/) | Συνδυασμός πλήρων αρχείων παρουσίασης του ίδιου τύπου. |
| [ForEach](https://reference.aspose.com/slides/el/python-java/aspose.slides/foreach/) | Εκτέλεση ενέργειας για κάθε διαφάνεια, σχήμα, παράγραφο ή τμήμα κειμένου. |
| [Collect](https://reference.aspose.com/slides/el/python-java/aspose.slides/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/python-java/aspose.slides/compress/) | Αφαίρεση αχρησιμοποίητων master και layout και μείωση ενσωματωμένων δεδομένων γραμματοσειράς. |

## **Μετατροπή Παρουσίασης**

Χρησιμοποιήστε [Convert.autoByExtension](https://reference.aspose.com/slides/el/python-java/aspose.slides/convert/#autoByExtension) όταν η κατάληξη του αρχείου εξόδου είναι επαρκής για την επιλογή της μορφής εξαγωγής. Η μέθοδος ανοίγει την πηγή παρουσίασης, καθορίζει τη απαιτούμενη μορφή από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/python-java/aspose.slides/convert/) παρέχει επίσης αφιερωμένες μεθόδους για έξοδο σε PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να ελέγξετε ή να τροποποιήσετε την παρουσίαση πριν από την εξαγωγή ή να ρυθμίσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον επιλεγμένο βοηθό. Δείτε την ενότητα [Μετατροπή Παρουσίασης](/slides/el/python-java/convert-presentation/) για διαδικασίες και επιλογές ειδικές για κάθε μορφή.

## **Συγχώνευση Παρουσιάσεων**

Χρησιμοποιήστε [Merger.process](https://reference.aspose.com/slides/el/python-java/aspose.slides/merger/#process) για να συνδυάσετε πλήρη αρχεία παρουσίασης με μία κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν την ίδια μορφή αρχείου.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

Ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προσαρτηθούν σε ένα αποτέλεσμα χωρίς να τις επιλέξετε ή να τις αντιστοιχίσετε ξεχωριστά. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε έναν προορισμό master ή layout, να διατηρήσετε ρητά ενότητες ή να εναρμονίσετε διαφορετικά μεγέθη διαφάνειας. Δείτε την ενότητα [Συγχώνευση Παρουσιάσεων](/slides/el/python-java/merge-presentation/) για αυτά τα σενάρια.

## **Επανάληψη Στοιχείων Παρουσίασης**

Η κλάση [ForEach](https://reference.aspose.com/slides/el/python-java/aspose.slides/foreach/) καλεί μια συνάρτηση επιστροφής για κάθε ζητούμενο τύπο στοιχείου παρουσίασης. Αποφεύγει έντονες επαναλήψεις συλλογών και είναι βολική για παγκόσμια επιθεώρηση ή αλλαγές μορφοποίησης της παρουσίασης.

Το παρακάτω παράδειγμα χρησιμοποιεί [ForEach.slide](https://reference.aspose.com/slides/el/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/el/python-java/aspose.slides/foreach/#paragraph) και [ForEach.portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/foreach/#portion) για την επιθεώρηση των αντίστοιχων στοιχείων:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

Από προεπιλογή, η διαδρομή σχημάτων και κειμένου για ολόκληρη την παρουσίαση περιλαμβάνει κανονικές, master και layout διαφάνειες. Υπερφορτώσεις με παράμετρο `includeNotes` μπορούν επίσης να επεξεργαστούν διαφάνειες σημειώσεων. Χρησιμοποιήστε άμεσες επαναλήψεις συλλογών όταν η σειρά διαγραφής, η πρώιμη έξοδος, το φιλτράρισμα πριν την κλήση ή ο λεπτομερής έλεγχος γονέα‑παιδίου είναι σημαντικά.

## **Συλλογή Σχημάτων**

Χρησιμοποιήστε [Collect.shapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/collect/#shapes) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση αντί για μια κλήση ανά σχήμα. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτράρεται, θα μετράται ή θα επεξεργάζεται περισσότερες φορές.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Χρησιμοποιήστε [ForEach.shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/foreach/#shape) αντʼ αυτού όταν κάθε σχήμα μπορεί να επεξεργαστεί αμέσως και δεν χρειάζεται να διατηρηθεί το συλλεγμένο αποτέλεσμα.

## **Συμπίεση Περιεχομένου Παρουσίασης**

Η κλάση [Compress](https://reference.aspose.com/slides/el/python-java/aspose.slides/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει ενσωματωμένα δεδομένα γραμματοσειράς:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) αφαιρεί διαφάνειες layout που δεν αναφέρονται από καμία κανονική διαφάνεια.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/compress/#removeUnusedMasterSlides) αφαιρεί master διαφάνειες που δεν χρησιμοποιούνται πλέον.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/compress/#compressEmbeddedFonts) αφαιρεί αχρησιμοποίητους χαρακτήρες από ενσωματωμένες γραμματοσειρές.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Αφαιρέστε πρώτα τα αχρησιμοποίητα layout πριν τα αχρησιμοποίητα master, ώστε ένα master που γίνεται άδειο μετά τον καθαρισμό των layout να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο αν μπορεί να χρειαστείτε αργότερα τα αρχικά master, layout ή ολόκληρα δεδομένα ενσωματωμένων γραμματοσειρών. Για περισσότερες λεπτομέρειες, δείτε τις ενότητες [Slide Master](/slides/el/python-java/slide-master/) και [Embedded Font](/slides/el/python-java/embedded-font/).

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το API χαμηλού κώδικα αντί του πλήρους μοντέλου αντικειμένων;**

Χρησιμοποιήστε τους βοηθούς χαμηλού κώδικα όταν μια τυπική λειτουργία εφαρμόζεται σε πλήρες αρχείο ή παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο των επιμέρους στοιχείων. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε σχέσεις master‑layout, να επιθεωρήσετε μεσαίο στάδιο ή να ρυθμίσετε συμπεριφορά που ο βοηθός δεν εκθέτει.

**Μπορεί ο Merger να συνδυάσει παρουσιάσεις διαφορετικών μορφών αρχείου;**

Όχι. Το [Merger.process](https://reference.aspose.com/slides/el/python-java/aspose.slides/merger/#process) απαιτεί οι εισερχόμενες παρουσιάσεις να έχουν την ίδια μορφή. Μετατρέψτε πρώτα τα αρχεία εισόδου σε κοινή μορφή, π.χ. με το [Convert.autoByExtension](https://reference.aspose.com/slides/el/python-java/aspose.slides/convert/#autoByExtension), και έπειτα συγχωνεύστε τα μεταγλωττισμένα αρχεία.

**Επεξεργάζεται το ForEach master, layout και διαφάνειες σημειώσεων;**

Το [ForEach.slide](https://reference.aspose.com/slides/el/python-java/aspose.slides/foreach/#slide) διατρέχει μόνο τις κανονικές διαφάνειες παρουσίασης. Οι παγκόσμιες λειτουργίες [ForEach.shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/el/python-java/aspose.slides/foreach/#paragraph) και [ForEach.portion](https://reference.aspose.com/slides/el/python-java/aspose.slides/foreach/#portion) περιλαμβάνουν από προεπιλογή κανονικές, master και layout διαφάνειες. Χρησιμοποιήστε τις υπερφορτώσεις τους με `includeNotes` ορισμένο σε `True` για να περιλάβετε και τις διαφάνειες σημειώσεων.

**Ποια είναι η διαφορά μεταξύ ForEach.shape και Collect.shapes;**

Χρησιμοποιήστε [ForEach.shape](https://reference.aspose.com/slides/el/python-java/aspose.slides/foreach/#shape) για να επεξεργαστείτε κάθε σχήμα αμέσως μέσω μιας κλήσης επιστροφής. Χρησιμοποιήστε [Collect.shapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/collect/#shapes) όταν χρειάζεστε ένα επαναλήψιμο αποτέλεσμα που μπορεί να διατηρηθεί, να φιλτραριστεί, να μετρηθεί ή να διατρασπαριστεί πολλές φορές.

**Κάνει πάντα το Compress το αρχείο παρουσίασης μικρότερο;**

Δεν είναι απαραίτητο. Το αποτέλεσμα εξαρτάται από το αν η παρουσίαση περιέχει αχρησιμοποίητα layout, αχρησιμοποίητα master ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Εάν δεν υπάρχουν αυτά τα στοιχεία, οι αντίστοιχες λειτουργίες του [Compress](https://reference.aspose.com/slides/el/python-java/aspose.slides/compress/) μπορεί να μην μειώσουν το μέγεθος του αρχείου.

**Αποθηκεύονται αυτόματα οι αλλαγές που γίνονται από το ForEach ή το Compress;**

Όχι. Αυτοί οι βοηθοί λειτουργούν στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) στη μνήμη. Μετά την αλλαγή των στοιχείων σε μια κλήση επιστροφής του [ForEach](https://reference.aspose.com/slides/el/python-java/aspose.slides/foreach/) ή την εκτέλεση του [Compress](https://reference.aspose.com/slides/el/python-java/aspose.slides/compress/), καλέστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Μετατροπή Παρουσίασης](/slides/el/python-java/convert-presentation/)
- [Συγχώνευση Παρουσιάσεων](/slides/el/python-java/merge-presentation/)
- [Slide Master](/slides/el/python-java/slide-master/)
- [Manage Text Box](/slides/el/python-java/manage-textbox/)
- [Embedded Font](/slides/el/python-java/embedded-font/)