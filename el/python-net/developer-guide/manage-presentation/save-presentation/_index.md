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
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις σε Python χρησιμοποιώντας το Aspose.Slides—εξαγωγή σε PowerPoint ή OpenDocument διατηρώντας τις διατάξεις, τις γραμματοσειρές και τα εφέ."
---
## **Επισκόπηση**

[Άνοιγμα παρουσίασης σε Python](/slides/el/python-net/open-presentation/) περιγράφει πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) για το άνοιγμα μιας παρουσίασης. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) περιέχει τα περιεχόμενα μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από την αρχή είτε τροποποιείτε μια υπάρχουσα, θέλετε να την αποθηκεύσετε όταν τελειώσετε. Με το Aspose.Slides για Python, μπορείτε να αποθηκεύσετε σε **αρχείο** ή **ροή**. Αυτό το άρθρο εξηγεί τους διαφορετικούς τρόπους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση παρουσιάσεων σε αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο καλώντας τη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/). Παραχωρήστε το όνομα του αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με Aspose.Slides για Python.

```py
import aspose.slides as slides

# Δημιουργήστε το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:
    
    # Κάντε κάποια εργασία εδώ...

    # Αποθηκεύστε την παρουσίαση σε αρχείο.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Αποθήκευση παρουσιάσεων σε ροές**

Μπορείτε να αποθηκεύσετε μια παρουσίαση σε ροή περνώντας μια έξοδο ροής στη μέθοδο `save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/). Μια παρουσίαση μπορεί να γραφτεί σε πολλούς τύπους ροών. Στο παρακάτω παράδειγμα, δημιουργούμε μια νέα παρουσίαση, προσθέτουμε κείμενο σε σχήμα και την αποθηκεύουμε σε ροή.

```py
import aspose.slides as slides

# Δημιουργήστε το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Αποθηκεύστε την παρουσίαση στη ροή.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Αποθήκευση παρουσιάσεων με προεπιλεγμένο τύπο προβολής**

Το Aspose.Slides για Python σάς επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η δημιουργημένη παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/). Ορίστε την ιδιότητα `last_view` σε μια τιμή από την απαρίθμηση [ViewType](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Αποθήκευση παρουσιάσεων σε αυστηρή μορφή Office Open XML**

Το Aspose.Slides σας επιτρέπει να αποθηκεύσετε μια παρουσίαση σε αυστηρή μορφή Office Open XML. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pptxoptions/) και ορίστε την ιδιότητα conformance κατά την αποθήκευση. Εάν ορίσετε `Conformance.ISO_29500_2008_STRICT`, το αρχείο εξόδου αποθηκεύεται σε αυστηρή μορφή Office Open XML.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει σε αυστηρή μορφή Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Δημιουργήστε το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
with slides.Presentation() as presentation:
    # Αποθηκεύστε την παρουσίαση σε αυστηρή μορφή Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Αποθήκευση παρουσιάσεων σε μορφή Office Open XML σε λειτουργία Zip64**

Ένα αρχείο Office Open XML είναι ένα αρχείο ZIP που επιβάλλει περιορισμούς 4 GB (2^32 bytes) στο μη συμπιεσμένο μέγεθος οποιουδήποτε αρχείου, στο συμπιεσμένο μέγεθος οποιουδήποτε αρχείου και στο συνολικό μέγεθος του αρχείου, και επίσης περιορίζει τον αριθμό αρχείων σε 65 535 (2^16‑1). Οι επεκτάσεις μορφής ZIP64 ανεβάζουν αυτούς τους περιορισμούς σε 2^64.

Η ιδιότητα [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) σας επιτρέπει να επιλέξετε πότε να χρησιμοποιείτε τις επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός αρχείου Office Open XML.

Αυτή η ιδιότητα παρέχει τις ακόλουθες λειτουργίες:

- `IF_NECESSARY` χρησιμοποιεί τις επεκτάσεις μορφής ZIP64 μόνο εάν η παρουσίαση υπερβαίνει τους παραπάνω περιορισμούς. Αυτή είναι η προεπιλεγμένη λειτουργία.
- `NEVER` δεν χρησιμοποιεί ποτέ τις επεκτάσεις μορφής ZIP64.
- `ALWAYS` χρησιμοποιεί πάντα τις επεκτάσεις μορφής ZIP64.

Ο παρακάτω κώδικας παρουσιάζει πώς να αποθηκεύσετε μια παρουσίαση ως PPTX με ενεργοποιημένες τις επεκτάσεις μορφής ZIP64:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
Όταν αποθηκεύετε με `Zip64Mode.NEVER`, εξαίρεση [PptxException](https://reference.aspose.com/slides/el/python-net/aspose.slides/pptxexception/) παράγεται εάν η παρουσίαση δεν μπορεί να αποθηκευτεί σε μορφή ZIP32.
{{% /alert %}}

## **Αποθήκευση παρουσιάσεων χωρίς ανανέωση της μικρογραφίας**

Η ιδιότητα [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) ελέγχει τη δημιουργία μικρογραφίας όταν αποθηκεύεται μια παρουσίαση σε PPTX:

- Εάν οριστεί σε `True`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Αυτό είναι το προεπιλεγμένο.
- Εάν οριστεί σε `False`, διατηρείται η τρέχουσα μικρογραφία. Αν η παρουσίαση δεν έχει μικρογραφία, δεν δημιουργείται καμία.

Στον παρακάτω κώδικα, η παρουσίαση αποθηκεύεται σε PPTX χωρίς να ανανεώνεται η μικρογραφία της.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Αυτή η επιλογή βοηθά να μειωθεί ο χρόνος που απαιτείται για την αποθήκευση μιας παρουσίασης σε μορφή PPTX.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Η Aspose έχει αναπτύξει μια [δωρεάν εφαρμογή PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) χρησιμοποιώντας το δικό της API. Η εφαρμογή σας επιτρέπει να χωρίσετε μια παρουσίαση σε πολλά αρχεία αποθηκεύοντας τις επιλεγμένες διαφάνειες ως νέα αρχεία PPTX ή PPT.
{{% /alert %}}

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Υποστηρίζεται η «γρήγορη αποθήκευση» (εισαγωγική αποθήκευση) ώστε να γράφονται μόνο οι αλλαγές;**

Όχι. Η αποθήκευση δημιουργεί το πλήρες αρχείο προορισμού κάθε φορά· η εισαγωγική «γρήγορη αποθήκευση» δεν υποστηρίζεται.

**Είναι ασφαλές ως προς νήματα (thread‑safe) να αποθηκεύσετε το ίδιο αντικείμενο Presentation από πολλαπλά νήματα;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) δεν είναι thread‑safe[/slides/el/python-net/multithreading/]; αποθηκεύστε το από ένα μόνο νήμα.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

Οι [υπερσυνδέσεις](/slides/el/python-net/manage-hyperlinks/) διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ., βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα—βεβαιωθείτε ότι οι αναφερόμενοι δρόμοι παραμένουν προσβάσιμοι.

**Μπορώ να ορίσω/αποθηκεύσω μεταδεδομένα εγγράφου (Συγγραφέας, Τίτλος, Εταιρεία, Ημερομηνία);**

Ναι. Οι τυπικές [ιδιότητες εγγράφου](/slides/el/python-net/presentation-properties/) υποστηρίζονται και θα γραφούν στο αρχείο κατά την αποθήκευση.