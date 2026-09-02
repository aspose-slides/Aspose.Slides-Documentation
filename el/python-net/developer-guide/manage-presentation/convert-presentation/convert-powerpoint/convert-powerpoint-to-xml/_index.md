---
title: Μετατροπή παρουσιάσεων PowerPoint σε XML με Python
linktitle: PowerPoint σε XML
type: docs
weight: 145
url: /el/python-net/convert-powerpoint-to-xml/
keywords:
- μετατροπή PowerPoint σε XML
- μετατροπή παρουσίασης σε XML
- PPT σε XML
- PPTX σε XML
- ODP σε XML
- Παρουσίαση PowerPoint XML
- SaveFormat.XML
- αποθήκευση παρουσίασης ως XML
- εξαγωγή παρουσίασης σε XML
- Ροή XML
- Python
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint και OpenDocument σε αρχεία ή ροές PowerPoint XML με Python και Aspose.Slides."
---
## **Επισκόπηση**

Το Aspose.Slides for Python via .NET μπορεί να μετατρέπει παρουσιάσεις PowerPoint σε μορφή PowerPoint XML Presentation. Η έξοδος XML είναι χρήσιμη όταν χρειάζεστε μια αναπαράσταση κειμενική για την επιθεώρηση της δομής της παρουσίασης, την αντιμετώπιση προβλημάτων των παραγόμενων εγγράφων, τη σύγκριση των αποτελεσμάτων σε αυτόματες δοκιμές ή την ενσωμάτωση με μια ροή εργασίας που καταναλώνει XML αντί για πακέτο παρουσίασης.

Χρησιμοποιήστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/) με την τιμή `XML` από την απαρίθμηση [SaveFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/saveformat/). Μπορείτε να γράψετε το αποτέλεσμα απευθείας σε αρχείο ή σε ρεύμα.

{{% alert color="info" title="Note" %}}
`SaveFormat.XML` δημιουργεί μια PowerPoint XML Presentation. Δεν εξάγει τα μεμονωμένα τμήματα Office Open XML που αποθηκεύονται μέσα σε ένα πακέτο PPTX. Εάν χρειάζεστε τα ακριβή τμήματα του πακέτου PPTX, όπως `ppt/presentation.xml` ή τα μεμονωμένα αρχεία XML των διαφανειών, εξετάστε το ίδιο το πακέτο PPTX.
{{% /alert %}}

## **Μετατροπή παρουσίασης σε αρχείο XML**

Φορτώστε μια πηγή παρουσίασης με την κλάση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/), και στη συνέχεια περάστε τη διαδρομή εξόδου και το `SaveFormat.XML` στη [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/). Η πηγή μπορεί να είναι οποιαδήποτε μορφή παρουσίασης που υποστηρίζεται για φόρτωση, όπως PPT, PPTX ή ODP.

Το παρακάτω παράδειγμα μετατρέπει μια παρουσίαση PPTX σε αρχείο XML:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **Γράψτε την έξοδο XML σε ρεύμα**

Χρησιμοποιήστε την υπερφόρτωση ρεύματος της [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/) όταν το XML πρέπει να παραμείνει στη μνήμη ή να περάσει σε άλλο στοιχείο, όπως μια υπηρεσία ιστού, πάροχο αποθήκευσης ή δίαυλο επεξεργασίας XML. Το παρακάτω παράδειγμα γράφει το αποτέλεσμα σε ροή [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) και την επαναφέρει στην αρχή για μετέπειτα ανάγνωση:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # Περάστε το xml_stream στο επόμενο στοιχείο της ροής εργασίας.
```

## **Σύγκριση XML με μορφές παρουσίασης και εξαγωγής**

Επιλέξτε τη μορφή εξόδου ανάλογα με το πώς θα χρησιμοποιηθεί το αποτέλεσμα:

| Μορφή | Έξοδος | Τυπική χρήση |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Μια PowerPoint XML Presentation | Επιθεώρηση δομής, αντιμετώπιση προβλημάτων, σύγκριση παραγόμενης εξόδου και ενσωμάτωση βάσει XML |
| PPT (`.ppt`) | Ένα παλαιότερο δυαδικό αρχείο παρουσίασης | Συμβατότητα με παλαιότερες ροές εργασίας PowerPoint |
| PPTX (`.pptx`) | Ένα πακέτο Office Open XML που περιέχει πολλαπλά τμήματα | Κανονική επεξεργασία PowerPoint και ανταλλαγή παρουσιάσεων |
| PDF or TIFF | Σελίδες σταθερής διάταξης ή πολυσελίδα εικόνα | Προβολή, εκτύπωση και αρχειοθέτηση |
| PNG, JPEG, or SVG | Μια αποδομένη αναπαράσταση μιας μεμονωμένης διαφάνειας | Μικρογραφίες, προεπισκοπήσεις και εικόνες περιουσιακών στοιχείων |
| HTML or HTML5 | Έξοδος παρουσίασης προσαρμοσμένης για web | Προβολή σε προγράμματα περιήγησης και δημοσίευση στο διαδίκτυο |

Σε αντίθεση με τα PPT και PPTX, η έξοδος XML προορίζεται κυρίως για επιθεώρηση και ροές εργασίας προσανατολισμένες στα δεδομένα. Σε αντίθεση με τα PDF, TIFF, HTML και μορφές εικόνας διαφανειών, αντιπροσωπεύει τα δεδομένα της παρουσίασης αντί για την απόδοση των διαφανειών ως σελίδες ή οπτικά στοιχεία. Ο πίνακας [supported file formats](/slides/el/python-net/supported-file-formats/) αναγράφει την PowerPoint XML Presentation ως μορφή μόνο αποθήκευσης, επομένως μην το χρησιμοποιείτε όταν μια ροή εργασίας πρέπει να φορτώσει το εξαγόμενο αρχείο ξανά στο Aspose.Slides για συνεχή επεξεργασία.

## **FAQ**

**Είναι το `SaveFormat.XML` το ίδιο με την αποθήκευση ενός αρχείου PPTX;**

Όχι. Το PPTX είναι ένα πακέτο που περιέχει πολλαπλά τμήματα Office Open XML, ενώ το `SaveFormat.XML` δημιουργεί ένα αρχείο PowerPoint XML Presentation.

**Μπορώ να αποθηκεύσω την έξοδο XML χωρίς να δημιουργήσω αρχείο στο δίσκο;**

Ναί. Περάστε μια εγγράψιμη ροή στη [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/). Για παράδειγμα, χρησιμοποιήστε μια ροή [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) για επεξεργασία στη μνήμη.

**Μπορεί το Aspose.Slides να φορτώσει ξανά το εξαγόμενο αρχείο XML;**

Όχι. Η PowerPoint XML Presentation υποστηρίζεται επί του παρόντος μόνο για αποθήκευση και όχι για φόρτωση. Χρησιμοποιήστε PPTX ή άλλη υποστηριζόμενη μορφή παρουσίασης όταν απαιτείται επεναστροφή επεξεργασίας.

**Η μετατροπή XML αποδίδει κάθε διαφάνεια ως σελίδα ή εικόνα;**

Όχι. Η μετατροπή XML γράφει δομημένα δεδομένα παρουσίασης. Χρησιμοποιήστε PDF ή TIFF για έξοδο προσανατολισμένο σε σελίδες, ή PNG, JPEG και SVG για εικόνες μεμονωμένων διαφανειών.