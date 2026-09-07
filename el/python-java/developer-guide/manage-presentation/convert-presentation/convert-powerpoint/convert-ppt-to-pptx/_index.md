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
description: "Μετατροπή παλαιών αρχείων PPT σε PPTX σε Python με Aspose.Slides. Περιλαμβάνει παραδείγματα Python για μετατροπή ενός αρχείου ή ομάδας αρχείων, διαχείριση σφαλμάτων και σημειώσεις ακρίβειας."
---
## **Επισκόπηση**

Το PPT είναι η παλαιότερη δυαδική μορφή του PowerPoint, ενώ το PPTX είναι η νεότερη μορφή Open XML. Το Aspose.Slides for Python via Java μπορεί να φορτώσει ένα αρχείο PPT και να το αποθηκεύσει ως PPTX χωρίς το Microsoft PowerPoint. Αυτό το άρθρο δείχνει πώς να μετατρέψετε ένα αρχείο ή έναν φάκελο αρχείων και εξηγεί τι πρέπει να ελέγξετε μετά τη μετατροπή.

Κάθε παράδειγμα εκκινεί τη Java Virtual Machine εάν χρειάζεται και απελευθερώνει την παρουσίαση μετά τη χρήση. Αντικαταστήστε τις διαδρομές παραδείγματος με τις δικές σας διαδρομές αρχείου ή φακέλου.

## **Μετατροπή αρχείου PPT σε PPTX**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/), στη συνέχεια καλέστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Pptx). Το μπλοκ `finally` απελευθερώνει την παρουσίαση και τις πόρους της.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Φορτώστε την παλαιότερη παρουσίαση PPT.
presentation = Presentation("presentation.ppt")
try:
    # Αποθηκεύστε την παρουσίαση σε μορφή PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η επέκταση αρχείου δεν καθορίζει από μόνη της τη μορφή εξόδου· το επιχείρημα [SaveFormat.Pptx](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Pptx) το κάνει. Διατηρήστε διαφορετικές διαδρομές εισόδου και εξόδου εάν χρειάζεται να διατηρήσετε το αρχικό αρχείο PPT.

## **Μετατροπή πολλαπλών αρχείων PPT**

Το παρακάτω παράδειγμα μετατρέπει κάθε αρχείο `.ppt` σε έναν φάκελο. Κάθε αρχείο επεξεργάζεται ανεξάρτητα, έτσι μια αποτυχία μετατροπής δεν σταματά την υπόλοιπη δόση.

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

Για παραγωγικά φορτία εργασίας, καταγράψτε την πλήρη εξαίρεση, αποφασίστε αν ένα υπάρχον αρχείο εξόδου μπορεί να αντικατασταθεί και γράψτε τα ονόματα των αποτυχημένων αρχείων σε μια ουρά επανάληψης ή ελέγχου. Κατεστραμμένα αρχεία, αρχεία προστατευμένα με κωδικό πρόσβασης που ανοίγονται χωρίς τον απαιτούμενο κωδικό, μη προσβάσιμες διαδρομές και μη υποστηριζόμενο περιεχόμενο μπορούν όλα να προκαλέσουν αποτυχία μετατροπής. Δείτε το [Παραστάσεις με προστασία κωδικού](/slides/el/python-java/password-protected-presentation/) για τη φόρτωση κρυπτογραφημένων αρχείων.

## **Ακρίβεια και Παλαιές Λειτουργίες**

Η μετατροπή συνήθως διατηρεί τις διαφάνειες, τα master, τις διατάξεις, το κείμενο, τα σχήματα, τις εικόνες, τους πίνακες και τα διαγράμματα. Ωστόσο, τα PPT και PPTX δεν αντιπροσωπεύουν κάθε λειτουργία με ακριβώς τον ίδιο τρόπο. Μια κληρονομική λειτουργία που δεν έχει ισοδύναμο στο PPTX ή δεν υποστηρίζεται από τη βιβλιοθήκη μπορεί να κανονικοποιηθεί, να παραλειφθεί ή να εμφανιστεί διαφορετικά.

Ελέγξτε το μετατρεπόμενο αρχείο όταν περιέχει κινήσεις, μεταβάσεις, ενσωματωμένα ή συνδεδεμένα αντικείμενα OLE, ελέγχους ActiveX, ενσωματωμένα μέσα, σπάνιες γραμματοσειρές ή μακροεντολές VBA. Ένα απλό αρχείο PPTX δεν είναι μορφή με υποστήριξη μακροεντολών, επομένως χρησιμοποιήστε κατάλληλη ροή εργασίας με ενεργοποιημένες μακροεντολές όταν το VBA πρέπει να παραμείνει διαθέσιμο. Επίσης, βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές και οι εξωτερικοί πόροι υπάρχουν στο περιβάλλον όπου η μετατρεπόμενη παρουσίαση θα ανοιχτεί ή θα αποδοθεί.

Για σημαντικά έγγραφα, ανοίξτε ξανά το παραγόμενο PPTX προγραμματιστικά και ελέγξτε τον αριθμό των διαφανειών και το περιεχόμενο, έπειτα συγκρίνετε την εμφάνιση και τη συμπεριφορά της παρουσίασης στην προοριζόμενη εφαρμογή προβολής. Μην θεωρείτε μια επιτυχημένη κλήση του [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) ως απόδειξη ότι κάθε παλιά λειτουργία έχει ακριβή αναπαράσταση σε PPTX.

## **Πότε να χρησιμοποιηθεί το PPTX**

Χρησιμοποιήστε PPTX όταν η παρουσίαση θα επεξεργαστεί σε τρέχουσες εκδόσεις του PowerPoint, θα ανταλλαχθεί με συστήματα που δουλεύουν με πακέτα Open XML ή θα αποθηκευτεί σε μορφή που είναι πιο εύκολη στην επιθεώρηση και ανάκτηση από το παλαιότερο δυαδικό PPT. Διατηρήστε το αρχικό PPT ως αρχείο αρχειοθέτησης ή αντίγραφο επαναφοράς μέχρι η μετατρεπόμενη παρουσίαση να περάσει τους ελέγχους ακρίβειας.

Αν χρειάζεστε PDF, HTML, εικόνες, XPS ή άλλο τύπο εξόδου, χρησιμοποιήστε την καθοδήγηση ανά μορφή στο [Convert Presentations to Multiple Formats](/slides/el/python-java/convert-presentation/) αντί να υποθέτετε ότι όλοι οι προορισμοί διατηρούν τις επεξεργάσιμες λειτουργίες του PowerPoint.

## **Online Μετατροπέας**

Για ένα περιστασιακό αρχείο ή μια γρήγορη σύγκριση, μπορείτε να χρησιμοποιήσετε τον [online μετατροπέας PPT σε PPTX](https://products.aspose.app/slides/el/conversion/ppt-to-pptx). Για επαναλαμβανόμενες μετατροπές, επεξεργασία δέσμης ή διαχείριση σφαλμάτων σε επίπεδο εφαρμογής, χρησιμοποιήστε το API Python via Java.

## **Σχετικά Άρθρα**

- [PPT vs PPTX](/slides/el/python-java/ppt-vs-pptx/)
- [Αποθήκευση παρουσιάσεων σε Python](/slides/el/python-java/save-presentation/)
- [Υποστηριζόμενες μορφές αρχείων](/slides/el/python-java/supported-file-formats/)
- [Άνοιγμα παρουσιάσεων σε Python](/slides/el/python-java/open-presentation/)

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω PPT σε PPTX χωρίς εγκατεστημένο το Microsoft PowerPoint;**

Ναι. Το Aspose.Slides for Python via Java φορτώνει και αποθηκεύει αρχεία παρουσίασης χωρίς να απαιτεί το Microsoft PowerPoint.

**Θα διατηρήσει η μετατροπή PPT‑σε‑PPTX όλο το περιεχόμενο ακριβώς;**

Διατηρεί το κοινό περιεχόμενο της παρουσίασης, αλλά η ακριβής ακρίβεια δεν είναι εγγυημένη για κάθε κληρονομική ή μη υποστηριζόμενη λειτουργία. Ελέγξτε το παραγόμενο αρχείο όταν περιέχει μακροεντολές, αντικείμενα OLE ή ActiveX, μέσα, εξειδικευμένες κινήσεις ή σπάνιες γραμματοσειρές.

**Μπορώ να μετατρέψω ένα αρχείο PPT προστατευμένο με κωδικό;**

Ναι, εφόσον παρέχετε τον σωστό κωδικό πρόσβασης κατά τη φόρτωση του αρχείου. Η έλλειψη ή το λάθος κωδικού προκαλεί αποτυχία της λειτουργίας φόρτωσης.

**Πρέπει να διαγράψω το αρχείο PPT μετά τη μετατροπή;**

Διατηρήστε το αρχικό αρχείο μέχρι να επαληθεύσετε το PPTX στους προβολείς και τις ροές εργασίας που σας ενδιαφέρουν. Αυτό παρέχει αντίγραφο επαναφοράς εάν μια κληρονομική λειτουργία μετατραπεί διαφορετικά.