---
title: Μετατροπή PPT σε PPTX σε Python
linktitle: PPT σε PPTX
type: docs
weight: 20
url: /el/python-java/convert-ppt-to-pptx/
keywords:
  - μετατροπή PowerPoint
  - μετατροπή παρουσίασης
  - μετατροπή διαφάνειας
  - μετατροπή PPT
  - PPT σε PPTX
  - αποθήκευση PPT ως PPTX
  - εξαγωγή PPT σε PPTX
  - PowerPoint
  - παρουσίαση
  - Python
  - Java
  - Aspose.Slides
description: "Μετατροπή κληρονομικών αρχείων PPT σε PPTX σε Python με το Aspose.Slides. Περιλαμβάνει παραδείγματα Python για μετατροπή ενός αρχείου και δέσμης, διαχείριση σφαλμάτων και σημειώσεις για την ακρίβεια."
---
## **Επισκόπηση**

Το PPT είναι η κληρονομική δυαδική μορφή του PowerPoint, ενώ το PPTX είναι η νεότερη μορφή Open XML. Το Aspose.Slides για Python μέσω Java μπορεί να φορτώσει ένα αρχείο PPT και να το αποθηκεύσει ως PPTX χωρίς το Microsoft PowerPoint. Αυτό το άρθρο δείχνει πώς να μετατρέψετε ένα αρχείο ή έναν φάκελο αρχείων και εξηγεί τι πρέπει να ελέγξετε μετά τη μετατροπή.

Κάθε παράδειγμα εκκινεί τη εικονική μηχανή Java εάν απαιτείται και απελευθερώνει την παρουσίαση μετά τη χρήση. Αντικαταστήστε τις διαδρομές του παραδείγματος με τις δικές σας διαδρομές αρχείων ή φακέλου.

## **Μετατροπή αρχείου PPT σε PPTX**

Φορτώστε το αρχικό αρχείο με την κλάση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/), στη συνέχεια καλέστε [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Pptx). Το μπλοκ `finally` απελευθερώνει την παρουσίαση και τις πηγές της.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpance.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Φορτώστε την κληρονομική παρουσίαση PPT.
presentation = Presentation("presentation.ppt")
try:
    #Αποθηκεύστε την παρουσίαση σε μορφή PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η επέκταση του αρχείου δεν επιλέγει από μόνη της τη μορφή εξόδου· το όρισμα [SaveFormat.Pptx](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Pptx) το κάνει. Διατηρήστε διαφορετικές τις διαδρομές εισόδου και εξόδου εάν χρειάζεται να διατηρήσετε το αρχικό αρχείο PPT.

## **Μετατροπή πολλαπλών αρχείων PPT**

Το παρακάτω παράδειγμα μετατρέπει κάθε αρχείο `.ppt` σε έναν φάκελο. Κάθε αρχείο επεξεργάζεται ανεξάρτητα, έτσι μια αποτυχία μετατροπής δεν σταματά το υπόλοιπο σύνολο.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

Για παραγωγικές εργασίες, καταγράψτε την πλήρη εξαίρεση, αποφασίστε αν ένα υπάρχον αρχείο εξόδου μπορεί να αντικατασταθεί και γράψτε τα ονόματα των αποτυχημένων αρχείων σε ουρά επανάληψης ή ελέγχου. Κατεστραμμένα αρχεία, αρχεία με προστασία κωδικού που ανοίγονται χωρίς τον απαιτούμενο κωδικό, μη προσβάσιμες διαδρομές και μη υποστηριζόμενο περιεχόμενο μπορούν όλα να προκαλέσουν αποτυχία μετατροπής. Δείτε το [Password‑Protected Presentations](/slides/el/python-java/password-protected-presentation/) για φόρτωση κρυπτογραφημένων αρχείων.

## **Ακρίβεια και Παλιές Λειτουργίες**

Η μετατροπή συνήθως διατηρεί τις διαφάνειες, τα master, τις διατάξεις, το κείμενο, τα σχήματα, τις εικόνες, τους πίνακες και τα γραφήματα. Ωστόσο, το PPT και το PPTX δεν αντιπροσωπεύουν κάθε λειτουργία με ακριβώς τον ίδιο τρόπο. Μια παλιά λειτουργία που δεν έχει ισοδύναμο στο PPTX, ή δεν υποστηρίζεται από τη βιβλιοθήκη, μπορεί να κανονικοποιηθεί, να παραλειφθεί ή να εμφανιστεί διαφορετικά.

Ελέγξτε το μετατρεπόμενο αρχείο όταν περιέχει κινούμενα σχέδια, μεταβάσεις, ενσωματωμένα ή συνδεδεμένα αντικείμενα OLE, ελεγκτές ActiveX, ενσωματωμένα μέσα, μη συνηθισμένες γραμματοσειρές ή μακροεντολές VBA. Ένα απλό αρχείο PPTX δεν είναι μορφή με υποστήριξη μακροεντολών, οπότε χρησιμοποιήστε μια κατάλληλη ροή εργασίας με υποστήριξη μακροεντολών όταν η VBA πρέπει να παραμείνει διαθέσιμη. Επίσης, επαληθεύστε ότι οι απαιτούμενες γραμματοσειρές και οι εξωτερικοί πόροι είναι παρόντες στο περιβάλλον όπου η μετατρεπόμενη παρουσίαση θα ανοίξει ή θα αποδοθεί.

Για σημαντικά έγγραφα, ανοίξτε εκ νέου το παραγόμενο PPTX προγραμματικά και ελέγξτε τους βασικούς αριθμούς διαφανειών και το περιεχόμενο, έπειτα συγκρίνετε την εμφάνιση και τη συμπεριφορά της παρουσίασης στον προοριζόμενο προβολέα. Μην θεωρείτε ότι μια επιτυχής κλήση στο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) είναι απόδειξη ότι κάθε κληρονομική λειτουργία έχει ακριβή αναπαράσταση στο PPTX.

## **Πότε να Χρησιμοποιήσετε το PPTX**

Χρησιμοποιήστε το PPTX όταν η παρουσίαση θα επεξεργαστεί σε τρέχουσες εκδόσεις του PowerPoint, θα ανταλλαγεί με συστήματα που δουλεύουν με πακέτα Open XML, ή θα αποθηκευτεί σε μορφή πιο εύκολη στην επιθεώρηση και ανάκτηση από το κληρονομικό δυαδικό PPT. Διατηρήστε το αρχικό PPT ως αρχείο αρχειοθέτησης ή αντιγραφο ασφαλείας μέχρι η μετατρεπόμενη παρουσίαση να περάσει τους ελέγχους ακρίβειας.

Αν χρειάζεστε αντ' αυτού PDF, HTML, εικόνες, XPS ή κάποιον άλλο τύπο εξόδου, χρησιμοποιήστε τις οδηγίες ανά μορφή στο [Convert Presentations to Multiple Formats](/slides/el/python-java/convert-presentation/) αντί να υποθέτετε ότι όλοι οι προορισμοί διατηρούν τις επεξεργάσιμες λειτουργίες του PowerPoint.

## **Online Μετατροπέας**

Για ένα περιστασιακό αρχείο ή μια γρήγορη σύγκριση, μπορείτε να χρησιμοποιήσετε τον [online PPT to PPTX converter](https://products.aspose.app/slides/el/conversion/ppt-to-pptx). Για επαναλαμβανόμενες μετατροπές, επεξεργασία δέσμης ή διαχείριση σφαλμάτων σε επίπεδο εφαρμογής, χρησιμοποιήστε το API Python μέσω Java.

## **Σχετικά Άρθρα**

- [PPT vs PPTX](/slides/el/python-java/ppt-vs-pptx/)
- [Αποθήκευση Παρουσιών σε Python](/slides/el/python-java/save-presentation/)
- [Υποστηριζόμενες Μορφές Αρχείων](/slides/el/python-java/supported-file-formats/)
- [Άνοιγμα Παρουσιών σε Python](/slides/el/python-java/open-presentation/)

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω PPT σε PPTX χωρίς την εγκατάσταση του Microsoft PowerPoint;**

Ναι. Το Aspose.Slides για Python μέσω Java φορτώνει και αποθηκεύει αρχεία παρουσίασης χωρίς να απαιτεί το Microsoft PowerPoint.

**Θα διατηρήσει η μετατροπή PPT σε PPTX όλο το περιεχόμενο ακριβώς;**

Διατηρεί το κοινό περιεχόμενο της παρουσίασης, αλλά η ακριβής ακρίβεια δεν εγγυάται για κάθε κληρονομική ή μη υποστηριζόμενη λειτουργία. Εξετάστε το παραγόμενο αρχείο όταν περιέχει μακροεντολές, αντικείμενα OLE ή ActiveX, μέσα, εξειδικευμένα κινούμενα σχέδια ή μη συνηθισμένες γραμματοσειρές.

**Μπορώ να μετατρέψω ένα αρχείο PPT με προστασία κωδικού;**

Ναι, εφόσον παρέχετε τον σωστό κωδικό κατά τη φόρτωση του αρχείου. Ένας ελλιπής ή λανθασμένος κωδικός κάνει τη λειτουργία φόρτωσης να αποτύχει.

**Πρέπει να διαγράψω το αρχείο PPT μετά τη μετατροπή;**

Διατηρήστε το αρχικό μέχρι να ελέγξετε το PPTX στους προβολείς και τις ροές εργασίας που σας ενδιαφέρουν. Αυτό παρέχει ένα αντίγραφο επαναφοράς αν μια κληρονομική λειτουργία μετατραπεί διαφορετικά.