---
title: Μετατροπή παρουσιάσεων PowerPoint σε XPS με Python
linktitle: PowerPoint σε XPS
type: docs
weight: 70
url: /el/python-java/convert-powerpoint-to-xps/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε XPS
- παρουσίαση σε XPS
- PPT σε XPS
- PPTX σε XPS
- αποθήκευση PPT ως XPS
- αποθήκευση PPTX ως XPS
- εξαγωγή PPT σε XPS
- εξαγωγή PPTX σε XPS
- Python
- Java
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint PPT και PPTX σε XPS με Python χρησιμοποιώντας το Aspose.Slides για Python μέσω Java, με προεπιλεγμένες ή προσαρμοσμένες ρυθμίσεις εξαγωγής."
---
## **Επισκόπηση**

Το Aspose.Slides for Python via Java σάς επιτρέπει να μετατρέπετε παρουσιάσεις PowerPoint σε XPS αποθηκεύοντας ένα αρχείο PPT ή PPTX στη μορφή XPS. Αυτό το άρθρο εξηγεί πότε το XPS μπορεί να είναι χρήσιμο και δείχνει πώς να εξάγετε μια παρουσίαση χρησιμοποιώντας είτε τις προεπιλεγμένες ρυθμίσεις είτε προσαρμοσμένες ρυθμίσεις [XpsOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/xpsoptions/) .

## **Σχετικά με το XPS**

Το XPS (XML Paper Specification) είναι μια μορφή εγγράφου βάσει XML που αναπτύχθηκε από τη Microsoft. Περιγράφει σταθερές σελίδες, διατηρώντας τη διάταξη του κειμένου και των γραφικών για προβολή και εκτύπωση με συμβατά λογισμικά.

## **Πότε να Χρησιμοποιήσετε τη Μορφή Microsoft XPS**

Χρησιμοποιήστε το XPS όταν μια ροή εργασίας εγγράφων απαιτεί αρχεία σταθερής διάταξης για κοινή χρήση ή εκτύπωση μέσω εργαλείων που υποστηρίζουν XPS. Οι παραλήπτες χρειάζονται λογισμικό που υποστηρίζει XPS. Εάν η ροή εργασίας σας απαιτεί PDF αντί αυτού, δείτε [Convert PowerPoint to PDF](/slides/el/python-java/convert-powerpoint-to-pdf/) .

{{% alert color="info" title="Σημείωση" %}}
Για να δοκιμάσετε τη μετατροπή μιας παρουσίασης PPT ή PPTX σε XPS, χρησιμοποιήστε τον [δωρεάν διαδικτυακό μετατροπέα](https://products.aspose.app/slides/el/conversion) .
{{% /alert %}}

| Παρουσίαση PowerPoint εισόδου | Έγγραφο XPS εξόδου |
| --- | --- |
| ![Αρχική παρουσίαση PowerPoint](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Παρουσίαση που μετατράπηκε σε XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **Μετατροπή XPS με το Aspose.Slides**

Χρησιμοποιήστε τη μέθοδο [save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) με το [SaveFormat.Xps](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Xps) για να εξάγετε μια παρουσίαση. Μπορείτε να χρησιμοποιήσετε τις προεπιλεγμένες ρυθμίσεις εξαγωγής ή να παρέχειτε [XpsOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/xpsoptions/) για να προσαρμόσετε την έξοδο.

Κάθε παράδειγμα παρακάτω ξεκινά τη μηχανή εικονικής Java εάν χρειάζεται και απελευθερώνει την παρουσίαση μετά τη χρήση. Αντικαταστήστε το όνομα αρχείου εισόδου με τη διαδρομή προς το αρχείο PPT ή PPTX σας.

### **Μετατροπή Παρουσιάσεων σε XPS με Χρήση Προεπιλεγμένων Ρυθμίσεων**

Ο παρακάτω κώδικας Python μετατρέπει μια παρουσίαση σε XPS χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Αποθήκευση της παρουσίασης ως έγγραφο XPS.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Μετατροπή Παρουσιάσεων σε XPS με Προσαρμοσμένες Ρυθμίσεις**

Το παρακάτω παράδειγμα χρησιμοποιεί τη μέθοδο [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/el/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) για να αποθηκεύσει τα μετααρχεία ως εικόνες PNG στο τελικό έγγραφο XPS:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # Αποθήκευση της παρουσίασης με τις προσαρμοσμένες ρυθμίσεις XPS.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Μπορώ να αποθηκεύσω το XPS σε ροή αντί για αρχείο;**

Ναι. Η μέθοδος [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) διαθέτει υπερφορτώσεις που δέχονται ροή εξόδου Java. Με Python via Java, χρησιμοποιήστε μια συμβατή ροή Java μέσω JPype, όπως μια ροή εξόδου byte-array Java, για να διατηρήσετε τα εξαγόμενα δεδομένα στη μνήμη.

**Συμπεριλαμβάνονται οι κρυφές διαφάνειες στην έξοδο XPS;**

Οι κρυφές διαφάνειες εξαιρούνται εξ ορισμού. Για να τις συμπεριλάβετε, ορίστε το [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) σε `True` πριν την αποθήκευση.

**Διατηρούνται οι κινήσεις και οι μεταβάσεις διαφανειών στο XPS;**

Όχι. Το XPS περιέχει σταθερές σελίδες, επομένως οι εξαγόμενες διαφάνειες δεν αναπαράγουν κινήσεις ή εφέ μετάβασης.