---
title: "Αποθήκευση Παρουσιάσεων σε Python"
linktitle: "Αποθήκευση Παρουσίασης"
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
- λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- Python
- Aspose.Slides
description: "Αποθήκευση παρουσιάσεων PowerPoint και OpenDocument σε αρχεία ή ροές σε Python με Aspose.Slides και διαμόρφωση επιλογών εξόδου PPTX."
---
## **Επισκόπηση**

Αφού δημιουργήσετε μια παρουσίαση ή [ανοίξε ένα υπάρχον](/slides/el/python-net/open-presentation/), χρησιμοποιήστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/ipresentation/save/) για να εγγράψετε το αποτέλεσμα. Το Aspose.Slides for Python via .NET μπορεί να αποθηκεύσει μια παρουσίαση σε αρχείο ή ροή σε μορφές PowerPoint, OpenDocument, PDF και άλλες. Τα παρακάτω τμήματα καλύπτουν τις τυπικές λειτουργίες αποθήκευσης και τις διαθέσιμες επιλογές για έξοδο PPTX.

## **Αποθήκευση Παρουσιάσεων σε Αρχεία**

Για να αποθηκεύσετε μια παρουσίαση σε αρχείο, περάστε τη διαδρομή εξόδου και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/saveformat/) στην μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/ipresentation/save/). Η τιμή μορφής καθορίζει τον τύπο αρχείου που δημιουργεί το Aspose.Slides.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει ως αρχείο PPTX:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Προσθέστε ή τροποποιήστε το περιεχόμενο της παρουσίασης εδώ.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Αποθήκευση Παρουσιάσεων στην Αρχική τους Μορφή**

Για παραδείγματα ανίχνευσης αρχείου και ροής, τη συμπεριφορά των νεοδημιουργημένων παρουσιάσεων και τη διάκριση μεταξύ μορφής προέλευσης και εξόδου, δείτε [Καθορίστε τη Μορφή της Αρχικής Παρουσίασης](/slides/el/python-net/detect-presentation-source-format/).

Σε μια εφαρμογή επεξεργασίας παρτίδας, η μορφή εισόδου μπορεί να μην είναι γνωστή εκ των προτέρων. Μετά τη φόρτωση ενός αρχείου, διαβάστε τη αρχική μορφή του από την ιδιότητα [Presentation.source_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/source_format/) . Περάστε την προκύπτουσα τιμή [SourceFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/sourceformat/) στη μέθοδο [SlideUtil.to_save_format](https://reference.aspose.com/slides/el/python-net/aspose.slides.util/slideutil/to_save_format/) για να λάβετε την αντίστοιχη τιμή [SaveFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/saveformat/) και, στη συνέχεια, χρησιμοποιήστε το [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/ipresentation/save/) για να γράψετε την τροποποιημένη παρουσίαση.

Το παρακάτω πλήρες παράδειγμα επεξεργάζεται κάθε αρχείο σε έναν φάκελο εισόδου, ενημερώνει τον τίτλο του και το αποθηκεύει σε έναν φάκελο εξόδου στη μορφή από την οποία φορτώθηκε:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/el/python-net/aspose.slides.util/slideutil/to_save_format/) αντιστοιχίζει PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP και PowerPoint XML στις αντίστοιχες μορφές αποθήκευσης παρουσίασης. Απεικονίζει μόνο μορφές προέλευσης παρουσίασης· δεν προορίζεται για επιλογή μορφών εξαγωγής όπως PDF, HTML, TIFF ή εικόνες. Η παροχή μιας μη υποστηριζόμενης ή μη έγκυρης τιμής [SourceFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides/sourceformat/) προκαλεί εξαίρεση.

Τα παλαιά αρχεία PPT, PPS και POT χρησιμοποιούν το ίδιο δυαδικό container. Όταν μια τέτοια παρουσίαση φορτώνεται από ροή χωρίς επέκταση αρχείου, ένα αρχείο PPS ή POT μπορεί επομένως να αναγνωριστεί ως PPT. Εάν απαιτείται διατήρηση αυτών των παλαιών υποτύπων, κρατήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα μορφής ξεχωριστά και χρησιμοποιήστε τα κατά την επιλογή του ονόματος αρχείου και της μορφής εξόδου.

## **Αποθήκευση Παρουσιάσεων σε Ροές**

Για να γράψετε μια παρουσίαση χωρίς να βασίζεστε σε τελική διαδρομή αρχείου, περάστε μια γραψιμό [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) ροή και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/saveformat/) στην μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/ipresentation/save/). Αυτή η προσέγγιση είναι χρήσιμη όταν η έξοδος πρέπει να επιστραφεί από μια υπηρεσία ιστού, να αποθηκευτεί σε βάση δεδομένων ή να υποβληθεί σε επεξεργασία στη μνήμη.

Το παρακάτω παράδειγμα αποθηκεύει μια νέα παρουσίαση σε ροή αρχείου:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Αποθήκευση Παρουσιάσεων με Προκαθορισμένο Τύπο Προβολής**

Μπορείτε να καθορίσετε την προβολή με την οποία το PowerPoint ανοίγει αρχικά μια αποθηκευμένη παρουσίαση. Ορίστε την ιδιότητα [ViewProperties.last_view](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewproperties/last_view/) σε μια τιμή [ViewType](https://reference.aspose.com/slides/el/python-net/aspose.slides/viewtype/) πριν από την αποθήκευση.

Το παρακάτω παράδειγμα διαμορφώνει την προβολή Slide Master ως αρχική προβολή:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Αποθήκευση Παρουσιάσεων σε Αυστηρή Μορφή Office Open XML**

Για να δημιουργήσετε ένα αρχείο PPTX που συμμορφώνεται με το αυστηρό προφίλ του Office Open XML, δημιουργήστε ένα αντικείμενο [PptxOptions](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pptxoptions/) και ορίστε την ιδιότητα [conformance](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pptxoptions/conformance/) σε `Conformance.ISO_29500_2008_STRICT`. Στη συνέχεια περάστε τις επιλογές στην μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/ipresentation/save/).

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Αποθήκευση Παρουσιάσεων σε Office Open XML Μορφή σε Λειτουργία Zip64**

Ένα τυπικό αρχείο ZIP περιορίζει το συμπιεσμένο και ασυμπίεστο μέγεθος κάθε καταχώρησης, το συνολικό μέγεθος του αρχείου και τον αριθμό των καταχωρήσεων. Επειδή ένα αρχείο PPTX είναι αρχείο ZIP, μια πολύ μεγάλη παρουσίαση μπορεί να υπερβεί αυτά τα όρια. Οι επεκτάσεις ZIP64 αυξάνουν τα όρια μεγέθους και αριθμού καταχωρήσεων.

Χρησιμοποιήστε την ιδιότητα [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) για να ελέγξετε αν το Aspose.Slides θα γράψει επεκτάσεις ZIP64:

- `IF_NECESSARY` χρησιμοποιεί ZIP64 μόνο όταν η παρουσίαση υπερβαίνει τα τυπικά όρια ZIP. Αυτή είναι η προεπιλεγμένη λειτουργία.
- `NEVER` απενεργοποιεί τις επεκτάσεις ZIP64.
- `ALWAYS` γράφει πάντα επεκτάσεις ZIP64.

Το παρακάτω παράδειγμα ενεργοποιεί πάντα τις επεκτάσεις ZIP64 για την έξοδο παρουσίασης:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
Αν χρησιμοποιηθεί `Zip64Mode.NEVER` και η παρουσίαση δεν μπορεί να χωρέσει εντός των τυπικών ορίων ZIP, η λειτουργία αποθήκευσης προκαλεί την εξαίρεση [PptxException](https://reference.aspose.com/slides/el/python-net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Αποθήκευση Παρουσιάσεων σε Office Open XML Μορφή με Επίπεδα Συμπίεσης**

Για έξοδο PPTX, μπορείτε να εξισορροπήσετε την ταχύτητα αποθήκευσης έναντι του μεγέθους αρχείου ορίζοντας την ιδιότητα [PptxOptions.compression_level](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pptxoptions/compression_level/). Η απαρίθμηση [CompressionLevel](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/compressionlevel/) παρέχει τις ακόλουθες τιμές:

- `NONE` αποθηκεύει τα δεδομένα χωρίς συμπίεση.
- `LEVEL1` παρέχει τη γρηγορότερη συμπίεση και το μεγαλύτερο συμπιεσμένο αποτέλεσμα.
- `LEVEL2` έως `LEVEL5` ευνοούν προοδευτικά μικρότερο αποτέλεσμα έναντι ταχύτητας αποθήκευσης.
- `LEVEL6` ισορροπεί την ταχύτητα αποθήκευσης και το μέγεθος του αρχείου. Αυτή είναι η προεπιλεγμένη τιμή.
- `LEVEL7` και `LEVEL8` ευνοούν περαιτέρω μικρότερο αποτέλεσμα έναντι ταχύτητας αποθήκευσης.
- `LEVEL9` παρέχει τη δυνατήστερη συμπίεση και απαιτεί τον περισσότερο χρόνο επεξεργασίας.

Το παρακάτω παράδειγμα αποθηκεύει μια παρουσίαση χωρίς συμπίεση:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

Το παρακάτω παράδειγμα χρησιμοποιεί το μέγιστο επίπεδο συμπίεσης:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Αποθήκευση Παρουσιάσεων χωρίς Ανανέωση Μικρογραφίας**

Όταν μια παρουσίαση αποθηκεύεται ως PPTX, η ιδιότητα [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) ελέγχει τη μικρογραφία του εγγράφου:

- `True` επαναδημιουργεί τη μικρογραφία κατά τη διαδικασία αποθήκευσης. Αυτή είναι η προεπιλεγμένη τιμή.
- `False` διατηρεί την υπάρχουσα μικρογραφία. Αν η παρουσίαση δεν έχει μικρογραφία, το Aspose.Slides δεν δημιουργεί νέα.

Το παρακάτω παράδειγμα αποθηκεύει μια παρουσίαση χωρίς να ανανεώσει τη μικρογραφία της:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
Η απενεργοποίηση της ανανέωσης της μικρογραφίας μπορεί να μειώσει τον χρόνο που απαιτείται για την αποθήκευση ενός αρχείου PPTX.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Η Aspose παρέχει ένα δωρεάν [PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) που έχει δημιουργηθεί με το API Aspose.Slides. Αποθηκεύει επιλεγμένες διαφάνειες από μια παρουσίαση ως ξεχωριστά αρχεία PPT ή PPTX.
{{% /alert %}}

## **FAQ**

**Υποστηρίζει το Aspose.Slides την αυξητική ή «γρήγορη αποθήκευση»;**

Όχι. Κάθε λειτουργία αποθήκευσης γράφει ένα πλήρες αρχείο εξόδου αντί να ενημερώνει μόνο τα τροποποιημένα τμήματα.

**Μπορούν πολλαπλά νήματα να αποθηκεύσουν το ίδιο αντικείμενο Presentation;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) **δεν είναι thread‑safe** (/slides/el/python-net/multithreading/). Πρόσβαση και αποθήκευση κάθε αντικειμένου πρέπει να γίνεται από ένα μόνο νήμα τη φορά.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία όταν αποθηκεύω μια παρουσίαση;**

Τα [Hyperlinks](/slides/el/python-net/manage-hyperlinks/) παραμένουν στην παρουσίαση. Το Aspose.Slides δεν αντιγράφει εξωτερικά συνδεδεμένα αρχεία, επομένως η αποθηκευμένη παρουσίαση πρέπει ακόμη να μπορεί να προσπελάσει τις τοποθεσίες τους.

**Μπορώ να αποθηκεύσω μεταδεδομένα εγγράφου όπως συγγραφέα, τίτλο, εταιρεία και ημερομηνία δημιουργίας;**

Ναι. Ορίστε τις κατάλληλες [document properties](/slides/el/python-net/presentation-properties/) πριν από την αποθήκευση και το Aspose.Slides θα τις γράψει στο αρχείο εξόδου.