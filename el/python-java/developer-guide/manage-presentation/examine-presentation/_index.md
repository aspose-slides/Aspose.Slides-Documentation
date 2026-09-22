---
title: Ανάκτηση και ενημέρωση πληροφοριών παρουσίασης σε Python μέσω Java
linktitle: Πληροφορίες παρουσίασης
type: docs
weight: 30
url: /el/python-java/examine-presentation/
keywords:
- μορφή παρουσίασης
- ιδιότητες παρουσίασης
- ιδιότητες εγγράφου
- λήψη ιδιοτήτων
- ανάγνωση ιδιοτήτων
- αλλαγή ιδιοτήτων
- τροποποίηση ιδιοτήτων
- ενημέρωση ιδιοτήτων
- εξέταση PPTX
- εξέταση PPT
- εξέταση ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Εξερευνήστε διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Python μέσω Java για ταχύτερη κατανόηση και πιο έξυπνες ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να εντοπίσει τη μορφή μιας παρουσίασης και να διαβάσει τα μεταδεδομένα του εγγράφου χωρίς να δημιουργήσει ένα πλήρες μοντέλο αντικειμένου παρουσίασης. Αυτό είναι χρήσιμο όταν πρέπει να ταξινομήσετε αρχεία, να δημιουργήσετε μια απογραφή ή να ελέγξετε ιδιότητες πριν αποφασίσετε αν θα φορτώσετε και θα επεξεργαστείτε το περιεχόμενο της παρουσίασης.

Τα παραδείγματα απαιτούν το Aspose.Slides for Python via Java και ένα συμβατό περιβάλλον εκτέλεσης Java. Κάθε παράδειγμα ξεκινά το JVM αν δεν εκτελείται ήδη. Παρέχετε υπάρχοντα αρχεία παρουσίασης στις διαδρομές που χρησιμοποιούνται στα παραδείγματα.

Αυτό το άρθρο δείχνει ελαφριά επιθεώρηση μέσω του [PresentationFactory](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/) και του [PresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/), καθώς και στοχευμένες ενημερώσεις μέσω του [DocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/).

## **Έλεγχος μορφής παρουσίασης**

Αν έχετε ήδη φορτωμένη παρουσίαση, δείτε το [Determine the Original Presentation Format](/slides/el/python-java/detect-presentation-source-format/) για εντοπισμό μετά τη φόρτωση και τους περιορισμούς των παλαιών ροών PPT, PPS και POT.

Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/#getPresentationInfo) για να επιθεωρήσετε ένα αρχείο χωρίς να δημιουργήσετε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) . Η μέθοδος [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#getLoadFormat) αναφέρει τη εντοπισμένη μορφή, όπως PPTX, PPT ή ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Δημιουργία ελαφριάς απογραφής παρουσίασης**

Όταν επεξεργάζεστε πολλά αρχεία παρουσίασης, μπορεί να χρειαστείτε μια συμπαγή απογραφή για επικύρωση, ευρετήριο ή σύστημα διαχείρισης εγγράφων. Σε αυτή την περίπτωση, χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/#getPresentationInfo) για να αποκτήσετε ένα αντικείμενο [PresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/) και, στη συνέχεια, καλέστε το [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties) για να διαβάσετε τα μεταδεδομένα του εγγράφου. Αυτή η προσέγγιση δεν δημιουργεί ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και δεν απαιτεί την πλήρη διάσχιση του μοντέλου αντικειμένου παρουσίασης.

Οι εκτεταμένες ιδιότητες που εκτίθενται από το [DocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/) παρέχουν τις ακόλουθες τιμές απογραφής:

| Μέθοδος | Τιμή απογραφής |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getSlides) | Συνολικός αριθμός διαφανειών. |
| [getHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Αριθμός κρυφών διαφανειών. |
| [getNotes](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getNotes) | Αριθμός διαφανειών που περιέχουν σημειώσεις. |
| [getParagraphs](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getParagraphs) | Συνολικός αριθμός παραγράφων, όταν είναι διαθέσιμες. |
| [getWords](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getWords) | Συνολικός αριθμός λέξεων. |
| [getMultimediaClips](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Συνολικός αριθμός ηχητικών και βιντεοκλιπ. |

Το παρακάτω παράδειγμα διαβάζει αυτές τις τιμές χωρίς να δημιουργήσει ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και εκτυπώνει μια συμπαγή απογραφή. Συμπεριλαμβάνει επίσης τον συνδυασμό του [getHeadingPairs](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getHeadingPairs) με το [getTitlesOfParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getTitlesOfParts) για την προβολή ομάδων περιεχομένου όπως γραμματοσειρές, θέματα και τίτλοι διαφανειών.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Κάθε [HeadingPair](https://reference.aspose.com/slides/el/python-java/aspose.slides/headingpair/) παρέχει ένα όνομα ομάδας και τον αριθμό των στοιχείων σε αυτήν την ομάδα. Η μέθοδος [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getTitlesOfParts) επιστρέφει έναν επίπεδο, διατεταγμένο πίνακα, ώστε να καταναλώσετε τον αριθμό διαδοχικών τίτλων που καθορίζονται από κάθε heading pair.

### **Αποθηκευμένα μεταδεδομένα και περιορισμοί μορφής**

Οι ιδιότητες απογραφής που επιστρέφει το [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties) αντικατοπτρίζουν τα μεταδεδομένα διαθέσιμα στο πηγαίο έγγραφο. Το Aspose.Slides δεν φορτώνει και δεν διασχίζει το μοντέλο αντικειμένου παρουσίασης για να επανυπολογίσει αυτές τις τιμές για αυτήν την κλήση. Οι ελλιπείς ιδιότητες αντιπροσωπεύονται από προεπιλεγμένες τιμές και οι αποθηκευμένες τιμές μπορεί να είναι ξεπερασμένες εάν η εφαρμογή που αποθήκευσε τελευταία το αρχείο δεν ενημέρωσε τις ιδιότητες του εγγράφου.

- **PPTX:** Η μορφή παρέχει εκτεταμένες ιδιότητες εγγράφου για μετρήσεις διαφανειών, σημειώσεων, κρυφών διαφανειών, παραγράφων, λέξεων και πολυμέσων, καθώς και ζευγάρια επικεφαλίδων και τίτλους τμημάτων. Η διαθεσιμότητα εξαρτάται από το ποιες ιδιότητες γράφτηκαν από τον δημιουργό του εγγράφου.
- **PPT:** Η δυαδική μορφή μπορεί να αποθηκεύσει αντίστοιχες ιδιότητες σύνοψης εγγράφου. Εάν μια ιδιότητα λείπει ή δεν ενημερώθηκε από τον δημιουργό, το Aspose.Slides επιστρέφει την αποθηκευμένη ή προεπιλεγμένη τιμή αντί να την υπολογίζει από τις διαφάνειες.
- **ODP:** Τα μεταδεδομένα OpenDocument παρέχουν γενικά στατιστικά εγγράφου, όπως μετρήσεις σελίδων, παραγράφων και λέξεων, αλλά αυτές οι τιμές δεν αντιστοιχούν σε κάθε εκτεταμένη ιδιότητα PowerPoint. Τα μεταδεδομένα κρυφών διαφανειών, σημειώσεων, πολυμέσων, ζευγάρια επικεφαλίδων και τίτλοι τμημάτων μπορεί να μην είναι διαθέσιμα, και οι ιδιότητες απογραφής μπορεί να επιστρέψουν προεπιλεγμένες τιμές. Μην θεωρείτε μηδενική τιμή ή κενό πίνακα ως αυθεντική απόδειξη ότι το αντίστοιχο περιεχόμενο λείπει.

Χρησιμοποιήστε την ελαφριά προσέγγιση μεταδεδομένων για απογραφές και προκαταρκτικούς ελέγχους. Φορτώστε την παρουσίαση και επιθεωρήστε το ζωντανό μοντέλο αντικειμένου όταν το αποτέλεσμα πρέπει να αντικατοπτρίζει τις αλλαγές στη μνήμη ή όταν χρειάζεται να επαληθεύσετε το πραγματικό περιεχόμενο της παρουσίασης.

## **Ενημέρωση ιδιοτήτων παρουσίασης**

Οι ιδιότητες που επιστρέφει το [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties) μπορούν επίσης να αλλάξουν χωρίς τη δημιουργία ενός αντικειμένου [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) . Εφαρμόστε τις αλλαγές με το [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) και, στη συνέχεια, γράψτε την δεσμευμένη παρουσίαση με το [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Η ακόλουθη εικόνα δείχνει τις αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Το παρακάτω παράδειγμα αλλάζει τον τίτλο και την ώρα τελευταίας αποθήκευσης και γράφει το αποτέλεσμα σε νέο αρχείο:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

Η ακόλουθη εικόνα δείχνει τις ενημερωμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint.

![Ενημερωμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι σύνδεσμοι**

Για συναφείς ελέγχους ασφαλείας και ρυθμίσεις προστασίας, δείτε τα παρακάτω άρθρα:

- [Password-Protect Presentations](/slides/el/python-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/el/python-java/write-protected-presentation/)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Φορτώστε την παρουσίαση και χρησιμοποιήστε το [Presentation.getFontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getFontsManager). Καλέστε το [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) για να αποκτήσετε τις ενσωματωμένες γραμματοσειρές και το [FontsManager.getFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getFonts) για να λάβετε τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση. Συγκρίνετε τα δύο αποτελέσματα για να βρείτε τις γραμματοσειρές που απαιτούνται για απόδοση αλλά δεν είναι ενσωματωμένες.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Όταν τα αποθηκευμένα μεταδεδομένα εγγράφου είναι επαρκή, διαβάστε το [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getHiddenSlides) μέσω του [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/#getPresentationInfo) και του [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties). Αυτό είναι κατάλληλο για ελαφριά απογραφή. Εάν η παρουσίαση έχει τροποποιηθεί στη μνήμη, τα αποθηκευμένα μεταδεδομένα μπορεί να λείπουν ή να είναι ξεπερασμένα· ή αν χρειάζεται να επαληθεύσετε ζωντανές τιμές, επαναλάβετε μέσω του [Presentation.getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlides) και ελέγξτε τη μέθοδο [Slide.getHidden](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getHidden) για κάθε διαφάνεια.

**Μπορώ να εντοπίσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος ή προσανατολισμός διαφάνειας και αν διαφέρουν από τις προεπιλογές;**

Ναι. Φορτώστε την παρουσίαση και καλέστε το [Presentation.getSlideSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlideSize). Χρησιμοποιήστε τις μεθόδους [SlideSize.getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesize/#getSize) και [SlideSize.getOrientation](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesize/#getOrientation) για να συγκρίνετε τις τρέχουσες ρυθμίσεις με τις προκαθορισμένες τιμές και διαστάσεις.

**Υπάρχει γρήγορος τρόπος για να δω αν οι γραφήματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Εντοπίστε κάθε [Chart](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/) και καλέστε το [ChartData.getDataSourceType](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getDataSourceType). Για εξωτερικό φύλλο εργασίας, καλέστε το [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Ο τύπος πηγής δεδομένων και η διαδρομή υποδεικνύουν εξωτερική αναφορά, αλλά η επαλήθευση της διαθεσιμότητας του στόχου απαιτεί ξεχωριστό έλεγχο πόρων.

**Πώς μπορώ να αξιολογήσω «βαριές» διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή σε PDF;**

Δεν υπάρχει μια μοναδική ιδιότητα πολυπλοκότητας. Διασχίστε το [Presentation.getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlides) και τη συλλογή [BaseSlide.getShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getShapes) κάθε διαφάνειας. Χρησιμοποιήστε τους αριθμούς των σχημάτων και την παρουσία μεγάλων εικόνων, εφέ, κινούμενων ή πολυμέσων ως σήματα φιλτραρίσματος και μετρήστε μια αντιπροσωπευτική απόδοση ή εξαγωγή πριν θεωρήσετε μια διαφάνεια ως επιβεβαιωμένο σημείο συμφόρησης στην απόδοση.