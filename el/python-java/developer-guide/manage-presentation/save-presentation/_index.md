---
title: Αποθήκευση παρουσιάσεων σε Python μέσω Java
linktitle: Αποθήκευση Παρουσίασης
type: docs
weight: 80
url: /el/python-java/save-presentation/
keywords:
- Αποθήκευση PowerPoint
- Αποθήκευση OpenDocument
- Αποθήκευση παρουσίασης
- Αποθήκευση διαφάνειας
- Αποθήκευση PPT
- Αποθήκευση PPTX
- Αποθήκευση ODP
- Παρουσίαση σε αρχείο
- Παρουσίαση σε ρεύμα
- Προκαθορισμένος τύπος προβολής
- Αυστηρή μορφή Office Open XML
- Λειτουργία Zip64
- Ανανέωση μικρογραφίας
- Πρόοδος αποθήκευσης
- Python
- Java
- Aspose.Slides
description: "Αποθηκεύστε παρουσιάσεις PowerPoint και OpenDocument σε αρχεία ή ρεύματα σε Python μέσω Java με το Aspose.Slides και διαμορφώστε την έξοδο PPTX και την αναφορά προόδου."
---
## **Επισκόπηση**

Αφού δημιουργήσετε μια παρουσίαση ή [ανοίξετε μια υπάρχουσα](/slides/el/python-java/open-presentation/), χρησιμοποιήστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) για να γράψετε το αποτέλεσμα. Το Aspose.Slides for Python via Java μπορεί να αποθηκεύσει μια παρουσίαση σε αρχείο ή ρεύμα σε μορφές PowerPoint, OpenDocument, PDF και άλλες. Τα παρακάτω τμήματα καλύπτουν τις τυπικές λειτουργίες αποθήκευσης και τις επιλογές που διατίθενται για έξοδο PPTX.

## **Αποθήκευση Παρουσιάσεων σε Αρχεία**

Για να αποθηκεύσετε μια παρουσίαση σε αρχείο, περάστε τη διαδρομή εξόδου και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/) στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save). Η τιμή μορφής καθορίζει τον τύπο αρχείου που δημιουργεί το Aspose.Slides.

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

Σε μια εφαρμογή επεξεργασίας παρτίδων, η μορφή εισόδου μπορεί να μην είναι γνωστή εκ των προτέρων. Μετά τη φόρτωση ενός αρχείου, διαβάστε την αρχική του μορφή από τη μέθοδο [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSourceFormat). Περάστε την προκύπτουσα τιμή [SourceFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/sourceformat/) στη μέθοδο [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideutil/#toSaveFormat) για να λάβετε την αντίστοιχη τιμή [SaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/), και στη συνέχεια χρησιμοποιήστε τη [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) για να γράψετε την τροποποιημένη παρουσίαση.

Το παρακάτω πλήρες παράδειγμα επεξεργάζεται κάθε αρχείο σε έναν φάκελο εισόδου, ενημερώνει τον τίτλο του και το αποθηκεύει σε έναν φάκελο εξόδου στη μορφή από την οποία φορτώθηκε:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/slideutil/#toSaveFormat) αντιστοιχίζει PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP και PowerPoint XML στις αντίστοιχες μορφές αποθήκευσης παρουσίασης. Αντιστοιχίζει μόνο μορφές πηγής παρουσίασης· δεν προορίζεται για επιλογή μορφών εξαγωγής όπως PDF, HTML, TIFF ή εικόνες. Η παροχή μιας μη υποστηριζόμενης ή άκυρης τιμής [SourceFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/sourceformat/) προκαλεί την εμφάνιση μιας [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Τα παλαιά αρχεία PPT, PPS και POT χρησιμοποιούν το ίδιο δυαδικό κοντέινερ. Όταν μια τέτοια παρουσίαση φορτωθεί από ρεύμα χωρίς επέκταση αρχείου, ένα αρχείο PPS ή POT μπορεί επομένως να αναγνωριστεί ως PPT. Εάν απαιτείται η διατήρηση αυτών των παλαιών υποτύπων, διατηρήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα μορφής ξεχωριστά και χρησιμοποιήστε τα κατά την επιλογή του ονόματος και της μορφής εξόδου.

## **Αποθήκευση Παρουσιάσεων σε Ρεύματα**

Για να γράψετε μια παρουσίαση χωρίς εξάρτηση από τελική διαδρομή αρχείου, περάστε ένα ρέοντα εγγράψιμο και μια τιμή [SaveFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/) στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save). Αυτή η προσέγγιση είναι χρήσιμη όταν η έξοδος πρέπει να επιστραφεί από μια διαδικτυακή υπηρεσία, να αποθηκευτεί σε βάση δεδομένων ή να υποβληθεί σε επεξεργασία στη μνήμη.

Το παρακάτω παράδειγμα αποθηκεύει μια νέα παρουσίαση σε ρεύμα αρχείου:

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

## **Αποθήκευση Παρουσιάσεων σε Αυστηρή Μορφή Office Open XML**

Για να δημιουργήσετε ένα αρχείο PPTX που συμμορφώνεται με το αυστηρό προφίλ του Office Open XML, δημιουργήστε μια παρουσία [PptxOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxoptions/) και χρησιμοποιήστε τη μέθοδο [setConformance](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxoptions/#setConformance) με την τιμή [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/el/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Στη συνέχεια περάστε τις επιλογές στη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save).

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

Ένα τυπικό αρχείο ZIP περιορίζει το συμπιεσμένο και ασυμπίεστο μέγεθος κάθε καταχώρησης, το συνολικό μέγεθος του αρχείου και τον αριθμό των καταχωρήσεων. Επειδή ένα αρχείο PPTX είναι αρχείο ZIP, μια πολύ μεγάλη παρουσίαση μπορεί να υπερβεί αυτά τα όρια. Οι επεκτάσεις ZIP64 αυξάνουν τα όρια μεγέθους και αριθμού καταχωρήσεων.

Χρησιμοποιήστε τη μέθοδο [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxoptions/#setZip64Mode) για να ελέγξετε εάν το Aspose.Slides γράφει επεκτάσεις ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/el/python-java/aspose.slides/zip64mode/#IfNecessary) χρησιμοποιεί ZIP64 μόνο όταν η παρουσίαση υπερβαίνει τα τυπικά όρια ZIP. Αυτή είναι η προεπιλεγμένη λειτουργία.
- [Never](https://reference.aspose.com/slides/el/python-java/aspose.slides/zip64mode/#Never) απενεργοποιεί τις επεκτάσεις ZIP64.
- [Always](https://reference.aspose.com/slides/el/python-java/aspose.slides/zip64mode/#Always) γράφει πάντα επεκτάσεις ZIP64.

Το παρακάτω παράδειγμα ενεργοποιεί πάντα τις επεκτάσεις ZIP64 για την έξοδο παρουσίασης:

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
Αν χρησιμοποιηθεί το [Zip64Mode.Never](https://reference.aspose.com/slides/el/python-java/aspose.slides/zip64mode/#Never) και η παρουσίαση δεν μπορεί να χωρέσει στα τυπικά όρια ZIP, η λειτουργία αποθήκευσης ρίχνει μια [PptxException](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Αποθήκευση Παρουσιάσεων σε Μορφή Office Open XML με Επίπεδα Συμπίεσης**

Για έξοδο PPTX, μπορείτε να ισορροπήσετε την ταχύτητα αποθήκευσης έναντι του μεγέθους αρχείου χρησιμοποιώντας τη μέθοδο [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxoptions/#setCompressionLevel). Η κλάση [CompressionLevel](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/) παρέχει τις ακόλουθες τιμές:

- [None](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#None) αποθηκεύει δεδομένα χωρίς συμπίεση.
- [Level1](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#Level1) παρέχει τη γρηγορότερη συμπίεση και το μεγαλύτερο συμπιεσμένο αποτέλεσμα.
- [Level2](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#Level2) έως [Level5](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#Level5) δίνουν προτεραιότητα σε μικρότερο αρχείο έναντι της ταχύτητας αποθήκευσης.
- [Level6](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#Level6) εξισορροπεί την ταχύτητα αποθήκευσης και το μέγεθος αρχείου. Αυτή είναι η προεπιλεγμένη τιμή.
- [Level7](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#Level7) και [Level8](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#Level8) δίνουν περαιτέρω προτεραιότητα σε μικρότερο αρχείο.
- [Level9](https://reference.aspose.com/slides/el/python-java/aspose.slides/compressionlevel/#Level9) παρέχει τη μεγαλύτερη συμπίεση και απαιτεί τον περισσότερο χρόνο επεξεργασίας.

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

## **Αποθήκευση Παρουσιάσεων χωρίς Ανανέωση Μικρογραφίας**

Όταν μια παρουσίαση αποθηκεύεται ως PPTX, η μέθοδος [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/el/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ελέγχει τη μικρογραφία του εγγράφου:

- `True` δημιουργεί εκ νέου τη μικρογραφία κατά τη λειτουργία αποθήκευσης. Αυτή είναι η προεπιλεγμένη τιμή.
- `False` διατηρεί την υπάρχουσα μικρογραφία. Αν η παρουσίαση δεν έχει μικρογραφία, το Aspose.Slides δεν δημιουργεί καμία.

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
Η απενεργοποίηση της ανανέωσης της μικρογραφίας μπορεί να μειώσει το χρόνο που απαιτείται για την αποθήκευση ενός αρχείου PPTX.
{{% /alert %}}

## **Αναφορά Προόδου Αποθήκευσης ως Ποσοστό**

Για να παρακολουθείτε μια λειτουργία αποθήκευσης, καταχωρήστε έναν Python progress handler μέσω `jpype.JProxy` και περάστε τον στη μέθοδο [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveoptions/#setProgressCallback). Το Aspose.Slides θα καλέσει τη μέθοδο `reporting` του handler με τιμές προόδου κατά την εξαγωγή.

Το παρακάτω παράδειγμα εμφανίζει την πρόοδο εξαγωγής PDF στην κονσόλα:

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
Η Aspose παρέχει ένα δωρεάν [PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) χτισμένο με το API του Aspose.Slides. Αποθηκεύει επιλεγμένες διαφάνειες από μια παρουσίαση ως ξεχωριστά αρχεία PPT ή PPTX.
{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Υποστηρίζει το Aspose.Slides την αυξήθεν ή “γρήγορη αποθήκευση”?**

Όχι. Κάθε λειτουργία αποθήκευσης γράφει ένα πλήρες αρχείο εξόδου αντί να ενημερώνει μόνο τα τροποποιημένα τμήματα.

**Μπορούν πολλαπλά νήματα να αποθηκεύσουν το ίδιο αντικείμενο Presentation;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) **δεν είναι thread‑safe** (/slides/el/python-java/multithreading/). Πρόσβαση και αποθήκευση κάθε αντικειμένου πρέπει να γίνεται από ένα νήμα τη φορά.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά αρχεία όταν αποθηκεύω μια παρουσίαση;**

Οι [Hyperlinks](/slides/el/python-java/manage-hyperlinks/) παραμένουν στην παρουσίαση. Το Aspose.Slides δεν αντιγράφει αρχεία που είναι εξωτερικά συνδεδεμένα, επομένως η αποθηκευμένη παρουσίαση πρέπει να μπορεί ακόμη να έχει πρόσβαση στις τοποθεσίες τους.

**Μπορώ να αποθηκεύσω μεταδεδομένα εγγράφου όπως συγγραφέα, τίτλο, εταιρεία και ημερομηνία δημιουργίας;**

Ναι. Ορίστε τις κατάλληλες [document properties](/slides/el/python-java/presentation-properties/) πριν από την αποθήκευση και το Aspose.Slides θα τις γράψει στο αρχείο εξόδου.