---
title: Αποθήκευση Παρουσιάσεων σε Python μέσω Java
linktitle: Αποθήκευση Παρουσίασης
type: docs
weight: 80
url: /el/python-java/save-presentation/
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
- Αυστηρή Μορφή Office Open XML
- Λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- Python
- Java
- Aspose.Slides
description: "Αποθήκευση παρουσιάσεων PowerPoint και OpenDocument σε αρχεία ή ροές σε Python μέσω Java με Aspose.Slides, και διαμόρφωση εξόδου PPTX και αναφορά προόδου."
---
## **Επισκόπηση**

Αφού δημιουργήσετε μια παρουσίαση ή [ανοίξετε μια υπάρχουσα](/slides/el/python-java/open-presentation/), χρησιμοποιήστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) για να γράψετε το αποτέλεσμα. Το Aspose.Slides για Python μέσω Java μπορεί να αποθηκεύσει μια παρουσίαση σε αρχείο ή ροή σε μορφές PowerPoint, OpenDocument, PDF και άλλες μορφές. Οι παρακάτω ενότητες καλύπτουν τις τυπικές λειτουργίες αποθήκευσης και τις διαθέσιμες επιλογές για έξοδο PPTX.

## **Αποθήκευση Παρουσιάσεων σε Αρχεία**

Για να αποθηκεύσετε μια παρουσίαση σε αρχείο, περάστε τη διαδρομή εξόδου και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/) στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save). Η τιμή μορφής καθορίζει τον τύπο του αρχείου που δημιουργεί το Aspose.Slides.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει ως αρχείο PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Προσθέστε ή τροποποιήστε το περιεχόμενο της παρουσίασης εδώ.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αποθήκευση Παρουσιάσεων στην Αρχική τους Μορφή**

Για παραδείγματα ανίχνευσης αρχείου και ροής, τη συμπεριφορά των νεοδημιουργημένων παρουσιάσεων και τη διάκριση μεταξύ πηγής και μορφής εξόδου, δείτε [Determine the Original Presentation Format](/slides/el/python-java/detect-presentation-source-format/).

Σε εφαρμογή επεξεργασίας παρτίδας, η μορφή εισόδου μπορεί να μην είναι γνωστή εκ των προτέρων. Μετά τη φόρτωση ενός αρχείου, διαβάστε την αρχική του μορφή από τη μέθοδο [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSourceFormat). Περάστε την προκύπτουσα τιμή [SourceFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/sourceformat/) στη μέθοδο [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideutil/#toSaveFormat) για να λάβετε την αντίστοιχη τιμή [SaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/), και έπειτα χρησιμοποιήστε τη [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) για να γράψετε την τροποποιημένη παρουσίαση.

Το παρακάτω πλήρες παράδειγμα επεξεργάζεται κάθε αρχείο σε έναν φάκελο εισόδου, ενημερώνει τον τίτλο του και το αποθηκεύει σε φάκελο εξόδου στη μορφή από την οποία φορτώθηκε:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideutil/#toSaveFormat) αντιστοιχίζει PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP και PowerPoint XML στις αντίστοιχες μορφές αποθήκευσης παρουσίασης. Αντιστοιχίζει μόνο μορφές πηγής παρουσίασης· δεν προορίζεται για επιλογή μορφών εξαγωγής όπως PDF, HTML, TIFF ή εικόνες. Η μεταβίβαση μιας μη υποστηριζόμενης ή μη έγκυρης τιμής [SourceFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/sourceformat/) έχει ως αποτέλεσμα το [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Τα παλαιά αρχεία PPT, PPS και POT χρησιμοποιούν το ίδιο δυαδικό δοχείο. Όταν τέτοια παρουσίαση φορτωθεί από ροή χωρίς επέκταση αρχείου, ένα αρχείο PPS ή POT ενδέχεται να ταυτοποιηθεί ως PPT. Εάν απαιτείται διατήρηση αυτών των παλαιών υποτύπων, κρατήστε το αρχικό όνομα αρχείου ή τα μεταβλητά δεδομένα μορφής ξεχωριστά και χρησιμοποιήστε τα κατά την επιλογή του ονόματος και της μορφής εξόδου.

## **Αποθήκευση Παρουσιάσεων σε Ροές**

Για να γράψετε μια παρουσίαση χωρίς να εξαρτηθείτε από τελική διαδρομή αρχείου, περάστε μια ροή εγγραφής και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/) στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save). Αυτή η προσέγγιση είναι χρήσιμη όταν η έξοδος πρέπει να επιστραφεί από μια υπηρεσία web, να αποθηκευτεί σε βάση δεδομένων ή να επεξεργαστεί στη μνήμη.

Το παρακάτω παράδειγμα αποθηκεύει μια νέα παρουσίαση σε ροή αρχείου:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **Αποθήκευση Παρουσιάσεων με Προκαθορισμένο Τύπο Προβολής**

Μπορείτε να καθορίσετε την προβολή με την οποία το PowerPoint ανοίγει αρχικά μια αποθηκευμένη παρουσίαση. Χρησιμοποιήστε τη μέθοδο [ViewProperties.setLastView](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewproperties/#setLastView) με μια τιμή [ViewType](https://reference.aspose.com/slides/el/python-java/aspose.slides/viewtype/) πριν από την αποθήκευση.

Το παρακάτω παράδειγμα ρυθμίζει την προβολή Slide Master ως αρχική προβολή:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Αποθήκευση Παρουσιάσεων σε Απολύτως Συμβατή Μορφή Office Open XML**

Για να δημιουργήσετε ένα αρχείο PPTX που συμμορφώνεται με το αυστηρό προφίλ του Office Open XML, δημιουργήστε ένα αντικείμενο [PptxOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxoptions/) και χρησιμοποιήστε τη μέθοδο [setConformance](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxoptions/#setConformance) με την τιμή [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/el/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Στη συνέχεια περάστε τις επιλογές στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Αποθήκευση Παρουσιάσεων σε Μορφή Office Open XML σε Λειτουργία Zip64**

Ένα τυπικό αρχείο ZIP περιορίζει το συμπιεσμένο και μη συμπιεσμένο μέγεθος κάθε καταχώρησης, το συνολικό μέγεθος του αρχείου και τον αριθμό των καταχωρήσεων. Επειδή ένα αρχείο PPTX είναι αρχείο ZIP, μια πολύ μεγάλη παρουσίαση μπορεί να υπερβεί αυτά τα όρια. Οι επεκτάσεις ZIP64 αυξάνουν τα όρια μεγέθους και αριθμού καταχωρήσεων.

Χρησιμοποιήστε τη μέθοδο [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxoptions/#setZip64Mode) για να ελέγξετε αν το Aspose.Slides γράφει επεκτάσεις ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/el/python-java/aspose.slides/zip64mode/#IfNecessary) χρησιμοποιεί ZIP64 μόνο όταν η παρουσίαση υπερβαίνει τα τυπικά όρια ZIP. Αυτή είναι η προεπιλεγμένη λειτουργία.
- [Never](https://reference.aspose.com/slides/el/python-java/aspose.slides/zip64mode/#Never) απενεργοποιεί τις επεκτάσεις ZIP64.
- [Always](https://reference.aspose.com/slides/el/python-java/aspose.slides/zip64mode/#Always) γράφει πάντα επεκτάσεις ZIP64.

Το παρακάτω παράδειγμα ενεργοποιεί πάντα τις επεκτάσεις ZIP64 για την έξοδο της παρουσίασης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Αν χρησιμοποιηθεί το [Zip64Mode.Never](https://reference.aspose.com/slides/el/python-java/aspose.slides/zip64mode/#Never) και η παρουσίαση δεν μπορεί να χωρέσει στα τυπικά όρια ZIP, η λειτουργία αποθήκευσης θα πετάξει μια [PptxException](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Αποθήκευση Παρουσιάσεων σε Μορφή Office Open XML με Επίπεδα Συμπίεσης**

Για έξοδο PPTX, μπορείτε να ισορροπήσετε την ταχύτητα αποθήκευσης με το μέγεθος του αρχείου χρησιμοποιώντας τη μέθοδο [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxoptions/#setCompressionLevel). Η κλάση [CompressionLevel](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/) παρέχει τις ακόλουθες τιμές:

- [None](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#None) αποθηκεύει δεδομένα χωρίς συμπίεση.
- [Level1](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#Level1) προσφέρει την πιο γρήγορη συμπίεση και το μεγαλύτερο συμπιεσμένο αποτέλεσμα.
- [Level2](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#Level2) μέσω [Level5](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#Level5) προτιμούν σταδιακά μικρότερο μέγεθος εξόδου έναντι ταχύτητας αποθήκευσης.
- [Level6](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#Level6) ισορροπεί την ταχύτητα αποθήκευσης και το μέγεθος του αρχείου. Αυτή είναι η προεπιλεγμένη τιμή.
- [Level7](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#Level7) και [Level8](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#Level8) προτιμούν ακόμη περισσότερο μικρότερη έξοδο έναντι ταχύτητας αποθήκευσης.
- [Level9](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#Level9) παρέχει τη μέγιστη συμπίεση και απαιτεί το μεγαλύτερο χρόνο επεξεργασίας.

Το παρακάτω παράδειγμα αποθηκεύει μια παρουσίαση χωρίς συμπίεση:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

Το παρακάτω παράδειγμα χρησιμοποιεί το μέγιστο επίπεδο συμπίεσης:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Αποθήκευση Παρουσιάσεων χωρίς Ανανέωση της Μικρογραφίας**

Όταν μια παρουσίαση αποθηκεύεται ως PPTX, η μέθοδος [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ελέγχει τη μικρογραφία του εγγράφου:

- `True` επαναδημιουργεί τη μικρογραφία κατά τη λειτουργία αποθήκευσης. Αυτή είναι η προεπιλεγμένη τιμή.
- `False` διατηρεί τη υπάρχουσα μικρογραφία. Εάν η παρουσίαση δεν έχει μικρογραφία, το Aspose.Slides δεν θα δημιουργήσει καμία.

Το παρακάτω παράδειγμα αποθηκεύει μια παρουσίαση χωρίς να ανανεώσει τη μικρογραφία της:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Η απενεργοποίηση της ανανέωσης της μικρογραφίας μπορεί να μειώσει τον χρόνο που απαιτείται για την αποθήκευση ενός αρχείου PPTX.
{{% /alert %}}

## **Αναφορά Προόδου Αποθήκευσης ως Ποσοστού**

Για να παρακολουθείτε μια λειτουργία αποθήκευσης, καταχωρίστε έναν χειριστή προόδου Python μέσω `jpype.JProxy` και περάστε τον στη μέθοδο [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveoptions/#setProgressCallback). Το Aspose.Slides τότε καλεί τη μέθοδο `reporting` του χειριστή με τιμές προόδου κατά την εξαγωγή.

Το παρακάτω παράδειγμα αναφέρει την πρόοδο εξαγωγής PDF στην κονσόλα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Το Aspose παρέχει ένα δωρεάν [PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) που δημιουργήθηκε με το API του Aspose.Slides. Αποθηκεύει επιλεγμένες διαφάνειες από μια παρουσίαση ως ξεχωριστά αρχεία PPT ή PPTX.
{{% /alert %}}

## **FAQ**

**Υποστηρίζει το Aspose.Slides αποθήκευση σταδιακά ή «γρήγορη αποθήκευση»;**

Όχι. Κάθε λειτουργία αποθήκευσης γράφει ένα πλήρες αρχείο εξόδου αντί να ενημερώνει μόνο τα τροποποιημένα τμήματα.

**Μπορούν πολλά νήματα να αποθηκεύσουν το ίδιο αντικείμενο Presentation;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) **δεν είναι thread‑safe** (/slides/el/python-java/multithreading/). Πρόσβαση και αποθήκευση κάθε αντικειμένου πρέπει να γίνεται από ένα μόνο νήμα τη φορά.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία όταν αποθηκεύω μια παρουσίαση;**

[Hyperlinks](/slides/el/python-java/manage-hyperlinks/) παραμένουν στην παρουσίαση. Το Aspose.Slides δεν αντιγράφει εξωτερικά συνδεδεμένα αρχεία, έτσι η αποθηκευμένη παρουσίαση πρέπει ακόμη να μπορεί να προσπελάσει τις τοποθεσίες τους.

**Μπορώ να αποθηκεύσω μεταδεδομένα εγγράφου όπως συγγραφέα, τίτλο, εταιρεία και ημερομηνία δημιουργίας;**

Ναι. Ορίστε τις κατάλληλες [document properties](/slides/el/python-java/presentation-properties/) πριν από την αποθήκευση και το Aspose.Slides θα τις γράψει στο αρχείο εξόδου.