---
title: Αποθήκευση παρουσιάσεων σε Python
linktitle: Αποθήκευση παρουσιάσεων
type: docs
weight: 80
url: /el/python-net/save-presentation/
keywords:
- αποθήκευση PowerPoint
- αποθήκευση OpenDocument
- αποθήκευση παρουσίασης
- αποθήκευση διαφάνειας
- αποθήκευση PPT
- αποθήκευση PPTX
- αποθήκευση ODP
- παρουσίαση σε αρχείο
- παρουσίαση σε ροή
- προκαθορισμένος τύπος προβολής
- Αυστηρή μορφή Office Open XML
- Λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- Python
- Aspose.Slides
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις σε Python με χρήση Aspose.Slides—εξαγωγή σε PowerPoint ή OpenDocument διατηρώντας διατάξεις, γραμματοσειρές και εφέ."
---
## **Επισκόπηση**

Το [Άνοιγμα παρουσίασης σε Python](/slides/el/python-net/open-presentation/) περιγράφει πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για να ανοίξετε μια παρουσίαση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) περιέχει το περιεχόμενο μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από την αρχή είτε τροποποιείτε μια υπάρχουσα, θα θέλετε να την αποθηκεύσετε όταν τελειώσετε. Με το Aspose.Slides for Python, μπορείτε να αποθηκεύσετε σε **αρχείο** ή **ροή**. Αυτό το άρθρο εξηγεί τους διαφορετικούς τρόπους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση παρουσιάσεων σε αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο καλώντας τη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/). Περνάτε το όνομα αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με Aspose.Slides for Python.

```py
import aspose.slides as slides

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:
    
    # Κάντε κάποια εργασία εδώ...

    # Αποθηκεύστε την παρουσίαση σε αρχείο.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Αποθήκευση παρουσιάσεων σε ροές**

Μπορείτε να αποθηκεύσετε μια παρουσίαση σε ροή περνώντας μια ρεύμα εξόδου στη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/). Μια παρουσίαση μπορεί να γραφτεί σε πολλούς τύπους ροών. Στο παρακάτω παράδειγμα, δημιουργούμε μια νέα παρουσίαση και τη αποθηκεύουμε σε ροή αρχείου.

```py
import aspose.slides as slides

# Δημιουργήστε το αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Αποθηκεύστε την παρουσίαση στη ροή.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Αποθήκευση παρουσιάσεων με προεπιλεγμένο τύπο προβολής**

Το Aspose.Slides for Python σάς επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η δημιουργημένη παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/). Ορίστε την ιδιότητα `last_view` σε μία τιμή από την απαρίθμηση [ViewType](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Αποθήκευση παρουσιάσεων σε αυστηρή μορφή Office Open XML**

Το Aspose.Slides σάς επιτρέπει να αποθηκεύσετε μια παρουσίαση σε αυστηρή μορφή Office Open XML. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pptxoptions/) και ορίστε την ιδιότητα `conformance` κατά την αποθήκευση. Αν ορίσετε `Conformance.ISO_29500_2008_STRICT`, το αρχείο εξόδου αποθηκεύεται σε αυστηρή μορφή Office Open XML.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει σε αυστηρή μορφή Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:
    # Αποθηκεύστε την παρουσίαση σε αυστηρή μορφή Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Αποθήκευση παρουσιάσεων σε μορφή Office Open XML σε λειτουργία Zip64**

Ένα αρχείο Office Open XML είναι μια συμπιεσμένη αρχειοθήκη ZIP που επιβάλλει περιορισμούς 4 GB (2^32 bytes) στο μη συμπιεσμένο μέγεθος οποιουδήποτε αρχείου, στο συμπιεσμένο μέγεθος οποιουδήποτε αρχείου και στο συνολικό μέγεθος της αρχειοθήκης, καθώς και περιορίζει την αρχειοθήκη σε 65 535 (2^16‑1) αρχεία. Οι επεκτάσεις μορφής ZIP64 αυξάνουν αυτούς τους περιορισμούς σε 2^64.

Η ιδιότητα [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) σας επιτρέπει να επιλέξετε πότε να χρησιμοποιήσετε τις επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός αρχείου Office Open XML.

Αυτή η ιδιότητα παρέχει τις παρακάτω λειτουργίες:

- `IF_NECESSARY` χρησιμοποιεί τις επεκτάσεις μορφής ZIP64 μόνο εάν η παρουσίαση υπερβαίνει τους παραπάνω περιορισμούς. Αυτή είναι η προεπιλεγμένη λειτουργία.
- `NEVER` δεν χρησιμοποιεί ποτέ τις επεκτάσεις μορφής ZIP64.
- `ALWAYS` χρησιμοποιεί πάντα τις επεκτάσεις μορφής ZIP64.

Ο παρακάτω κώδικας δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX με ενεργοποιημένες τις επεκτάσεις μορφής ZIP64:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
Όταν αποθηκεύετε με `Zip64Mode.NEVER`, ρίχνεται ένα [PptxException](https://reference.aspose.com/slides/el/python-net/aspose.slides/pptxexception/) εάν η παρουσίαση δεν μπορεί να αποθηκευτεί σε μορφή ZIP32.
{{% /alert %}}

## **Αποθήκευση παρουσιάσεων σε μορφή Office Open XML με επίπεδα συμπίεσης**

Κατά τη δουλειά με μεγάλες παρουσιάσεις, μπορείτε να ρυθμίσετε το επίπεδο συμπίεσης για να εξισορροπήσετε το μέγεθος του αρχείου και τον χρόνο επεξεργασίας. Ανάλογα με τις απαιτήσεις σας, μπορεί να προτιμάτε ταχύτερη επεξεργασία ή μικρότερα αρχεία εξόδου.

Το Aspose.Slides παρέχει την ιδιότητα [PptxOptions.compression_level](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pptxoptions/compression_level/), η οποία σας επιτρέπει να καθορίσετε το επίπεδο συμπίεσης που χρησιμοποιείται κατά την αποθήκευση μιας παρουσίασης σε μορφή Office Open XML.

Τα διαθέσιμα επίπεδα συμπίεσης είναι:

- [**NONE**](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/compressionlevel/): Δεν εφαρμόζεται συμπίεση. Τα αρχεία αποθηκεύονται όπως είναι.
- [**LEVEL1**](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/compressionlevel/): Η πιο γρήγορη συμπίεση με την χαμηλότερη αναλογία συμπίεσης.
- [**LEVEL2**](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/compressionlevel/): Ταχύτερη συμπίεση με ελαφρώς καλύτερη αναλογία από το **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/compressionlevel/): Παρέχει καλύτερη συμπίεση από το **LEVEL2** με μέτρια επίπτωση στην ταχύτητα επεξεργασίας.
- [**LEVEL4**](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/compressionlevel/): Παρέχει καλύτερη συμπίεση από το **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/compressionlevel/): Παρέχει βελτιωμένη συμπίεση σε σχέση με το **LEVEL4** με επιπλέον χρόνο επεξεργασίας.
- [**LEVEL6**](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/compressionlevel/): Κανονική συμπίεση που προσφέρει καλή ισορροπία μεταξύ ταχύτητας επεξεργασίας και μεγέθους αρχείου. Αυτό είναι το *προεπιλεγμένο επίπεδο συμπίεσης*.
- [**LEVEL7**](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/compressionlevel/): Παρέχει καλύτερη συμπίεση από το **LEVEL6** με πιο αργή επεξεργασία.
- [**LEVEL8**](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/compressionlevel/): Παρέχει καλύτερη συμπίεση από το **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/compressionlevel/): Μέγιστη συμπίεση. Παράγει το μικρότερο μέγεθος αρχείου με κόστος του μεγαλύτερου χρόνου επεξεργασίας.

Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX *χωρίς συμπίεση*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Αυτό το παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο PPTX με *μέγιστη συμπίεση*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Αποθήκευση παρουσιάσεων χωρίς ανανέωση της μικρογραφίας**

Η ιδιότητα [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) ελέγχει τη δημιουργία μικρογραφίας όταν αποθηκεύεται μια παρουσίαση σε PPTX:

- Εάν οριστεί σε `True`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Αυτό είναι το προεπιλεγμένο.
- Εάν οριστεί σε `False`, η τρέχουσα μικρογραφία διατηρείται. Εάν η παρουσίαση δεν έχει μικρογραφία, δεν δημιουργείται καμία.

Στον κώδικα παρακάτω, η παρουσίαση αποθηκεύεται σε PPTX χωρίς την ανανέωση της μικρογραφίας της.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Αυτή η επιλογή βοηθά στη μείωση του χρόνου που απαιτείται για την αποθήκευση μιας παρουσίασης σε μορφή PPTX.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Η Aspose έχει αναπτύξει μια [δωρεάν εφαρμογή PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) χρησιμοποιώντας το δικό της API. Η εφαρμογή σάς επιτρέπει να χωρίσετε μια παρουσίαση σε πολλά αρχεία αποθηκεύοντας επιλεγμένες διαφάνειες ως νέα αρχεία PPTX ή PPT.
{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Υποστηρίζεται η «γρήγορη αποθήκευση» (αυξητική αποθήκευση) ώστε να γράφονται μόνο οι αλλαγές;**

Όχι. Κάθε αποθήκευση δημιουργεί το πλήρες αρχείο προορισμού· η αυξητική «γρήγορη αποθήκευση» δεν υποστηρίζεται.

**Είναι ασφαλές από πολλαπλά νήματα να αποθηκεύεται το ίδιο αντικείμενο Presentation από πολλαπλά νήματα;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) [δεν είναι ασφαλές από πολλαπλά νήματα](/slides/el/python-net/multithreading/); αποθηκεύστε το από ένα μόνο νήμα.

**Τι γίνεται με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

[Οι υπερσύνδεσμοι](/slides/el/python-net/manage-hyperlinks/) διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ. βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα· βεβαιωθείτε ότι οι διαδρομές που αναφέρονται παραμένουν προσβάσιμες.

**Μπορώ να ορίσω/αποθηκεύσω μεταδεδομένα εγγράφου (Συγγραφέας, Τítulo, Εταιρεία, Ημερομηνία);**

Ναι. Οι τυπικές [ιδιότητες εγγράφου](/slides/el/python-net/presentation-properties/) υποστηρίζονται και θα γραφτούν στο αρχείο κατά την αποθήκευση.