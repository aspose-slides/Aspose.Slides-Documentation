---
title: Λειτουργίες Παρουσίασης Χαμηλού Κώδικα σε Python
linktitle: API Χαμηλού Κώδικα
type: docs
weight: 50
url: /el/python-net/low-code-presentation-operations/
keywords:
- API παρουσίασης χαμηλού κώδικα
- μετατροπή παρουσίασης
- συγχώνευση παρουσιάσεων
- συλλογή σχημάτων
- συμπίεση παρουσίασης
- αφαίρεση αχρησιμοποίητων master διαφανειών
- αφαίρεση αχρησιμοποίητων διαφανειών διάταξης
- συμπίεση ενσωματωμένων γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Χρησιμοποιήστε το API χαμηλού κώδικα του Aspose.Slides σε Python για να μετατρέψετε και να συγχωνεύσετε παρουσιάσεις, να συλλέξετε σχήματα και να μειώσετε το μέγεθος της παρουσίασης."
---
## **Επισκόπηση**

Το [aspose.slides.lowcode](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/) μοντέλο παρέχει βοηθητικές κλάσεις για κοινές λειτουργίες παρουσίασης. Αυτοί οι βοηθοί ενθυλάσσουν συχνά χρησιμοποιούμενες ροές εργασίας του μοντέλου αντικειμένων σε εστιασμένες μεθόδους, ώστε να μπορείτε να μετατρέπετε ή να συγχωνεύετε αρχεία, να συλλέγετε σχήματα και να αφαιρείτε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθητικές λειτουργίες low‑code είναι πιο χρήσιμες όταν η λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή εργασίας ταιριάζει με τις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες [Aspose.Slides object model](https://reference.aspose.com/slides/el/python-net/aspose.slides/) όταν χρειάζεστε λεπτομερή έλεγχο σε μεμονωμένες διαφάνειες, master, διάταξη, σχήματα, ρυθμίσεις εξαγωγής ή σχέσεις μεταξύ των στοιχείων της παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τους διαθέσιμους βοηθούς:

| Βοηθός | Για ποιο σκοπό |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/convert/) | Μετατροπή μιας παρουσίασης σε άλλη μορφή με άμεση κλήση αρχείου‑σε‑αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/merger/) | Συγχώνωση πλήρων αρχείων παρουσίασης του ίδιου τύπου. |
| [Collect](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/) | Αφαίρεση αχρησιμοποίητων master και διατάξεων και μείωση των ενσωματωμένων δεδομένων γραμματοσειράς. |

## **Μετατροπή Παρουσίασης**

Χρησιμοποιήστε το [Convert.auto_by_extension](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/convert/auto_by_extension/) όταν η επέκταση του αρχείου εξόδου είναι επαρκής για την επιλογή της μορφής εξαγωγής. Η μέθοδος ανοίγει την πηγή παρουσίασης, καθορίζει τη απαιτούμενη μορφή από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/convert/) παρέχει επίσης ειδικές μεθόδους για έξοδο PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιθεωρήσετε ή να τροποποιήσετε την παρουσίαση πριν από την εξαγωγή ή να ρυθμίσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον επιλεγμένο βοηθό. Δείτε το [Convert Presentation](/slides/el/python-net/convert-presentation/) για ροές εργασίας και επιλογές ανά μορφή.

## **Συγχώνευση Παρουσιάσεων**

Χρησιμοποιήστε το [Merger.process](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/merger/process/) για συνένωση πλήρων αρχείων παρουσίασης με μία κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν την ίδια μορφή αρχείου.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προσαρτηθούν σε ένα αποτέλεσμα χωρίς να τις επιλέγετε ή να τις ανασχεδιάζετε ξεχωριστά. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε προορισμό master ή διάταξης, να διατηρήσετε ενότητες ρητά ή να εναρμονίσετε διαφορετικά μεγέθη διαφάνειας. Δείτε το [Merge Presentations](/slides/el/python-net/merge-presentation/) για αυτές τις περιπτώσεις.

## **Συλλογή Σχημάτων**

Χρησιμοποιήστε το [Collect.shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/collect/shapes/) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτράρεται, μετράται ή επεξεργάζεται περισσότερες φορές.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Χρησιμοποιήστε άμεσες βρόχους συλλογής όταν η σειρά διερεύσης, η πρώιμη έξοδος, το φιλτράρισμα πριν την επεξεργασία ή ο λεπτομερής έλεγχος γονέα‑παιδιού είναι σημαντικά.

## **Συμπίεση Περιεχομένου Παρουσίασης**

Η κλάση [Compress](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει τα ενσωματωμένα δεδομένα γραμματοσειράς:

- Το [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) αφαιρεί διαφάνειες διάταξης που δεν αναφέρονται από καμία κανονική διαφάνεια.
- Το [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) αφαιρεί master διαφάνειες που δεν χρησιμοποιούνται πλέον.
- Το [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) αφαιρεί αχρησιμοποίητους χαρακτήρες από ενσωματωμένες γραμματοσειρές.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Αφαιρέστε πρώτα τις αχρησιμοποίητες διατάξεις πριν από τα αχρησιμοποίητα master, ώστε ένα master που γίνεται αδεσπότο μετά τον καθαρισμό των διατάξεων να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο εάν μπορεί να χρειαστείτε τα αρχικά master, διατάξεις ή πλήρη ενσωματωμένα δεδομένα γραμματοσειράς αργότερα. Για περισσότερες λεπτομέρειες, δείτε το [Slide Master](/slides/el/python-net/slide-master/) και το [Embedded Font](/slides/el/python-net/embedded-font/).

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το low‑code API αντί για το πλήρες μοντέλο αντικειμένων;**

Χρησιμοποιήστε τους βοηθούς low‑code όταν μια τυπική λειτουργία εφαρμόζεται σε πλήρες αρχείο ή παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο των μεμονωμένων στοιχείων. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε σχέσεις master‑διάταξη, να ελέγξετε ενδιάμεση κατάσταση ή να ρυθμίσετε λειτουργίες που ο βοηθός δεν εκθέτει.

**Μπορεί ο Merger να συνδυάσει παρουσιάσεις διαφορετικών μορφών αρχείου;**

Όχι. Το [Merger.process](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/merger/process/) απαιτεί οι εισερχόμενες παρουσιάσεις να είναι στην ίδια μορφή. Μετατρέψτε πρώτα τα αρχεία εισόδου σε κοινή μορφή, για παράδειγμα με το [Convert.auto_by_extension](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/convert/auto_by_extension/), και μετά συγχωνεύστε τα μετατρεπόμενα αρχεία.

**Τι περιλαμβάνει το Collect.shapes;**

Το [Collect.shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/collect/shapes/) ανακτά σχήματα από την παρουσίαση ώστε να μπορούν να διατηρηθούν, φιλτραριστούν, μετρηθούν ή να περάσουν πολλαπλές φορές. Χρησιμοποιήστε άμεσους βρόχους συλλογής όταν χρειάζεστε ακριβή έλεγχο του τύπου διαφάνειας ή των ένθετων αντικειμένων που επισκέπτετε.

**Η Compress κάνει πάντα τη παρουσίαση μικρότερη;**

Όχι απαραίτητα. Το αποτέλεσμα εξαρτάται από το αν η παρουσίαση περιέχει αχρησιμοποίητες διατάξεις, αχρησιμοποίητα master ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Αν δεν υπάρχουν, οι αντίστοιχες λειτουργίες [Compress](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/) ενδέχεται να μην μειώσουν το μέγεθος του αρχείου.

**Αποθηκεύονται αυτόματα οι αλλαγές που κάνει η Compress;**

Όχι. Αυτοί οι βοηθοί λειτουργούν στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) στη μνήμη. Μετά την εκτέλεση του [Compress](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/), καλέστε το [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Convert Presentation](/slides/el/python-net/convert-presentation/)
- [Merge Presentations](/slides/el/python-net/merge-presentation/)
- [Slide Master](/slides/el/python-net/slide-master/)
- [Manage Text Box](/slides/el/python-net/manage-textbox/)
- [Embedded Font](/slides/el/python-net/embedded-font/)