---
title: Μετατροπή παρουσιάσεων PowerPoint σε XML με Python μέσω Java
linktitle: PowerPoint σε XML
type: docs
weight: 145
url: /el/python-java/convert-powerpoint-to-xml/
keywords:
- μετατροπή PowerPoint σε XML
- μετατροπή παρουσίασης σε XML
- PPT σε XML
- PPTX σε XML
- ODP σε XML
- Παρουσίαση PowerPoint XML
- SaveFormat.Xml
- αποθήκευση παρουσίασης ως XML
- εξαγωγή παρουσίασης σε XML
- ροή XML
- Python
- Java
- Aspose.Slides
description: "Μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε αρχεία ή ροές PowerPoint XML με Python μέσω Java χρησιμοποιώντας το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides for Python via Java μπορεί να μετατρέπει παρουσιάσεις PowerPoint στη μορφή PowerPoint XML Presentation. Η έξοδος XML είναι χρήσιμη όταν χρειάζεστε μια κειμενική αναπαράσταση για τον έλεγχο της δομής της παρουσίασης, την αντιμετώπιση προβλημάτων των παραγόμενων εγγράφων, τη σύγκριση αποτελεσμάτων σε αυτοματοποιημένες δοκιμές ή την ενσωμάτωση με μια ροή εργασίας που καταναλώνει XML αντί για πακέτο παρουσίασης.

Χρησιμοποιήστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) με την τιμή [Xml](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Xml) από την κλάση [SaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/). Μπορείτε να γράψετε το αποτέλεσμα απευθείας σε αρχείο ή σε ροή.

{{% alert color="info" title="Σημείωση" %}}

[SaveFormat.Xml](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Xml) δημιουργεί μια PowerPoint XML Presentation. Δεν εξάγει τα μεμονωμένα μέρη Office Open XML που αποθηκεύονται μέσα σε ένα πακέτο PPTX. Εάν χρειάζεστε τα ακριβή μέρη του πακέτου PPTX, όπως `ppt/presentation.xml` ή μεμονωμένα αρχεία XML διαφάνειας, εξετάστε το ίδιο το πακέτο PPTX.

{{% /alert %}}

## **Μετατροπή παρουσίασης σε αρχείο XML**

Φορτώστε μια πηγαία παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και, στη συνέχεια, περάστε τη διαδρομή εξόδου και το [SaveFormat.Xml](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Xml) στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save). Η πηγή μπορεί να είναι οποιαδήποτε μορφή παρουσίασης που υποστηρίζεται για φόρτωση, όπως PPT, PPTX ή ODP.

Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση PPTX σε αρχείο XML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **Εγγραφή εξόδου XML σε ροή**

Χρησιμοποιήστε την υπερφόρτωση ροής της μεθόδου [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) όταν το XML πρέπει να παραμείνει στη μνήμη ή να περάσει σε άλλο στοιχείο, όπως μια υπηρεσία web, πάροχο αποθήκευσης ή pipeline επεξεργασίας XML. Το παρακάτω παράδειγμα γράφει το αποτέλεσμα σε ένα [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) και λαμβάνει το παραγόμενο XML ως αντικείμενο bytes της Python:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # Περάστε το xml_data στο επόμενο στοιχείο της ροής εργασίας.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **Σύγκριση XML με μορφές Παρουσίασης και Εξαγωγής**

Επιλέξτε τη μορφή εξόδου ανάλογα με το πώς θα χρησιμοποιηθεί το αποτέλεσμα:

| Μορφή | Έξοδος | Τυπική χρήση |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Μια PowerPoint XML Presentation | Έλεγχος δομής, αντιμετώπιση προβλημάτων, σύγκριση παραγόμενων αποτελεσμάτων και ενσωμάτωση βάσει XML |
| PPT (`.ppt`) | Αρχείο παρουσίασης παλαιού δυαδικού τύπου | Συμβατότητα με παλαιές ροές εργασίας PowerPoint |
| PPTX (`.pptx`) | Πακέτο Office Open XML με πολλαπλά μέρη | Κανονική επεξεργασία PowerPoint και ανταλλαγή παρουσιάσεων |
| PDF ή TIFF | Σελίδες σταθερής διάταξης ή εικόνα πολλαπλών σελίδων | Προβολή, εκτύπωση και αρχειοθέτηση |
| PNG, JPEG ή SVG | Αποτυπωμένη αναπαράσταση μεμονωμένης διαφάνειας | Μικρογραφίες, προεπισκοπήσεις και εικόνες πόρων |
| HTML ή HTML5 | Έξοδος παρουσίασης προσανατολισμένης στο web | Προβολή σε πρόγραμμα περιήγησης και δημοσίευση στο web |

Σε αντίθεση με τα PPT και PPTX, η έξοδος XML προορίζεται κυρίως για έλεγχο και ροές εργασίας προσανατολισμένες στα δεδομένα. Σε αντίθεση με τα PDF, TIFF, HTML και μορφές εικόνας διαφάνειας, το XML αντιπροσωπεύει τα δεδομένα της παρουσίασης αντί για απόδοση των διαφανειών ως σελίδες ή οπτικά περιουσιακά στοιχεία. Ο πίνακας [supported file formats](/slides/el/python-java/supported-file-formats/) καταγράφει το PowerPoint XML Presentation ως μορφή μόνο αποθήκευσης, οπότε μην το χρησιμοποιείτε όταν μια ροή εργασίας πρέπει να φορτώσει ξανά το εξαγόμενο αρχείο στο Aspose.Slides για συνεχή επεξεργασία.

## **Συχνές Ερωτήσεις**

**Είναι η εξαγωγή XML ίδια με την αποθήκευση αρχείου PPTX;**

Όχι. Το PPTX είναι ένα πακέτο που περιέχει πολλαπλά μέρη Office Open XML, ενώ το [SaveFormat.Xml](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Xml) δημιουργεί ένα αρχείο PowerPoint XML Presentation.

**Μπορώ να αποθηκεύσω την έξοδο XML χωρίς να δημιουργήσω αρχείο στο δίσκο;**

Ναι. Περάστε μια εγγράψιμη ροή εξόδου Java στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save). Για παράδειγμα, χρησιμοποιήστε ένα [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) για επεξεργασία στη μνήμη.

**Μπορεί το Aspose.Slides να φορτώσει ξανά το εξαγόμενο αρχείο XML;**

Όχι. Η PowerPoint XML Presentation υποστηρίζεται αυτή τη στιγμή μόνο για αποθήκευση, όχι για φόρτωση. Χρησιμοποιήστε PPTX ή άλλη υποστηριζόμενη μορφή παρουσίασης όταν απαιτείται επαναληπτική επεξεργασία.

**Η μετατροπή XML αποδίδει κάθε διαφάνεια ως σελίδα ή εικόνα;**

Όχι. Η μετατροπή XML γράφει δομημένα δεδομένα παρουσίασης. Χρησιμοποιήστε PDF ή TIFF για έξοδο προσανατολισμένο σε σελίδες ή PNG, JPEG και SVG για εικόνες μεμονωμένων διαφανειών.