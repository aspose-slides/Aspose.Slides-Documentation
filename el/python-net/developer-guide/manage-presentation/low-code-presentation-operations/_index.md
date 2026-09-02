---
title: Λειτουργίες Παρουσίασης Low-Code σε Python
linktitle: API χαμηλού κώδικα
type: docs
weight: 50
url: /el/python-net/low-code-presentation-operations/
keywords:
- API παρουσίασης χαμηλού κώδικα
- μετατροπή παρουσίασης
- συγχώνευση παρουσιάσεων
- συλλογή σχημάτων
- συμπίεση παρουσίασης
- αφαίρεση αχρησιμοποίητων κύριων διαφανειών
- αφαίρεση αχρησιμοποίητων διαφανειών διάταξης
- συμπίεση ενσωματωμένων γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Χρησιμοποιήστε το API χαμηλού κώδικα Aspose.Slides σε Python για τη μετατροπή και τη συγχώνευση παρουσιάσεων, τη συλλογή σχημάτων και τη μείωση του μεγέθους της παρουσίασης."
---
## **Επισκόπηση**

Το [aspose.slides.lowcode](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/) μοντέλο παρέχει βοηθητικές κλάσεις για κοινές λειτουργίες παρουσίασης. Αυτοί οι βοηθοί περιβάλλουν συχνά χρησιμοποιούμενες ροές εργασίας του μοντέλου αντικειμένων σε εστιασμένες μεθόδους, ώστε να μπορείτε να μετατρέψετε ή να ενώσετε αρχεία, να συλλέξετε σχήματα και να αφαιρέσετε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθοί low-code είναι πιο χρήσιμοι όταν η λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή ταιριάζει στις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες [Aspose.Slides object model](https://reference.aspose.com/slides/el/python-net/aspose.slides/) όταν χρειάζεστε λεπτομερή έλεγχο πάνω σε μεμονωμένες διαφάνειες, μάστερ, διατάξεις, σχήματα, ρυθμίσεις εξαγωγής ή σχέσεις μεταξύ των στοιχείων της παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τους διαθέσιμους βοηθούς:

| Βοηθός | Γιατί να το χρησιμοποιήσετε |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/convert/) | Μετατροπή μιας παρουσίασης σε άλλη μορφή με άμεση κλήση αρχείου‑σε‑αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/merger/) | Συνδυασμός πλήρων αρχείων παρουσίασης του ίδιου τύπου. |
| [Collect](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/) | Αφαίρεση αχρησιμοποίητων μάστερ και διατάξεων και μείωση ενσωματωμένων δεδομένων γραμματοσειρών. |

## **Μετατροπή Παρουσίασης**

Χρησιμοποιήστε το [Convert.auto_by_extension](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/convert/auto_by_extension/) όταν η επέκταση του αρχείου εξόδου είναι αρκετή για την επιλογή της μορφής εξαγωγής. Η μέθοδος ανοίγει την πηγή παρουσίασης, καθορίζει τη ζητούμενη μορφή από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/convert/) παρέχει επίσης ειδικές μεθόδους για έξοδο σε PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να ελέγξετε ή να τροποποιήσετε την παρουσίαση πριν από την εξαγωγή ή να διαμορφώσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον επιλεγμένο βοηθό. Δείτε το [Convert Presentation](/python-net/convert-presentation/) για ροές εργασίας και επιλογές ανά μορφή.

## **Συγχώνευση Παρουσιασών**

Χρησιμοποιήστε το [Merger.process](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/merger/process/) για να συνδυάσετε πλήρη αρχεία παρουσίασης με μία κλήση. Οι εισαγόμενες παρουσιάσεις πρέπει να έχουν την ίδια μορφή αρχείου.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προσαρτηθούν σε ένα αποτέλεσμα χωρίς να επιλέγονται ή να αντιστοιχίζονται ξεχωριστά. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε έναν προορισμό μάστερ ή διάταξης, να διατηρήσετε ενότητες ρητά ή να εξισορροπήσετε διαφορετικά μεγέθη διαφάνειας. Δείτε το [Merge Presentations](/python-net/merge-presentation/) για αυτά τα σενάρια.

## **Συλλογή Σχημάτων**

Χρησιμοποιήστε το [Collect.shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/collect/shapes/) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτραριστεί, μετρηθεί ή επεξεργαστεί περισσότερες από μία φορές.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Χρησιμοποιήστε άμεσους βρόχους συλλογής όταν η σειρά διάσχισης, η πρώιμη έξοδος, το φιλτράρισμα πριν την επεξεργασία ή ο λεπτομερής έλεγχος γονέα‑παιδίου είναι σημαντικά.

## **Συμπίεση Περιεχομένου Παρουσίασης**

Η κλάση [Compress](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει τα ενσωματωμένα δεδομένα γραμματοσειρών:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) αφαιρεί τις διαφάνειες διάταξης που δεν παραπέμπει καμία κανονική διαφάνεια.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) αφαιρεί τα μάστερ που δεν χρησιμοποιούνται πλέον.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) αφαιρεί τους αχρησιμοποίητους χαρακτήρες από τις ενσωματωμένες γραμματοσειρές.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Αφαιρέστε πρώτα τις αχρησιμοποίητες διατάξεις πριν τα αχρησιμοποίητα μάστερ, έτσι ώστε ένα μάστερ που γίνεται αδιάφορο μετά τον καθαρισμό διατάξεων να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο εάν χρειαστείτε αργότερα τα αρχικά μάστερ, τις διατάξεις ή τα πλήρη ενσωματωμένα δεδομένα γραμματοσειρών. Για περισσότερες λεπτομέρειες, δείτε το [Slide Master](/python-net/slide-master/) και το [Embedded Font](/python-net/embedded-font/).

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Πότε θα πρέπει να χρησιμοποιήσω το API low-code αντί του πλήρους μοντέλου αντικειμένων;**

Χρησιμοποιήστε τα βοηθητικά low-code όταν μια τυπική λειτουργία εφαρμόζεται σε ένα ολοκληρωμένο αρχείο ή παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο των μεμονωμένων στοιχείων. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε τις σχέσεις μεταξύ μάστερ και διατάξεων, να εξετάσετε ενδιάμεση κατάσταση ή να διαμορφώσετε συμπεριφορά που δεν εκτίθεται από τον βοηθό.

**Μπορεί το Merger να συνδυάσει παρουσιάσεις σε διαφορετικές μορφές αρχείου;**

Όχι. Το [Merger.process](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/merger/process/) απαιτεί τις εισαγόμενες παρουσιάσεις να είναι στην ίδια μορφή. Μετατρέψτε πρώτα τα αρχεία εισόδου σε κοινή μορφή, π.χ. με το [Convert.auto_by_extension](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/convert/auto_by_extension/), και έπειτα συγχωνεύστε τα μετατρεπόμενα αρχεία.

**Τι περιλαμβάνει το Collect.shapes;**

Το [Collect.shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/collect/shapes/) ανακτά σχήματα από την παρουσίαση ώστε να μπορούν να διατηρηθούν, φιλτραριστούν, μετρηθούν ή να διασχιστούν πολλές φορές. Χρησιμοποιήστε άμεσους βρόχους συλλογής όταν χρειάζεστε ακριβή έλεγχο του ποιου τύπου διαφάνειας ή ένθετων αντικειμένων θα επισκεφθείτε.

**Κάνει πάντα η Compress το αρχείο παρουσίασης μικρότερο;**

Όχι απαραίτητα. Το αποτέλεσμα εξαρτάται από το εάν η παρουσίαση περιέχει αχρησιμοποίητες διατάξεις, αχρησιμοποίητα μάστερ ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Εάν δεν υπάρχουν τέτοια στοιχεία, οι αντίστοιχες λειτουργίες [Compress](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/) μπορεί να μην μειώσουν το μέγεθος του αρχείου.

**Αποθηκεύονται αυτόματα οι αλλαγές που κάνει η Compress;**

Όχι. Αυτοί οι βοηθοί λειτουργούν πάνω στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) στη μνήμη. Μετά την εκτέλεση του [Compress](https://reference.aspose.com/slides/el/python-net/aspose.slides.lowcode/compress/), καλέστε το [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Μετατροπή Παρουσίασης](/python-net/convert-presentation/)
- [Συγχώνευση Παρουσιάσεων](/python-net/merge-presentation/)
- [Μάστερ Διαφάνειας](/python-net/slide-master/)
- [Διαχείριση Πλαισίου Κειμένου](/python-net/manage-textbox/)
- [Ενσωματωμένη Γραμματοσειρά](/python-net/embedded-font/)