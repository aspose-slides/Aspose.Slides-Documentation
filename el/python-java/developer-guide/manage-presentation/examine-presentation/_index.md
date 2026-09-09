---
title: Ανάκτηση και Ενημέρωση Πληροφοριών Παρουσίασης σε Python μέσω Java
linktitle: Πληροφορίες Παρουσίασης
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
description: "Εξερευνήστε τις διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Python μέσω Java για πιο γρήγορη ανάλυση και πιο έξυπνους ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να αναγνωρίσει τη μορφή μιας παρουσίασης και να διαβάσει τα μεταδεδομένα του εγγράφου χωρίς να δημιουργήσει ένα πλήρες μοντέλο αντικειμένου παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να ταξινομήσετε αρχεία, να δημιουργήσετε ένα απόθεμα ή να εξετάσετε ιδιότητες πριν αποφασίσετε αν θα φορτώσετε και θα επεξεργαστείτε το περιεχόμενο της παρουσίασης.

Τα παραδείγματα απαιτούν το Aspose.Slides for Python via Java και ένα συμβατό Java runtime. Κάθε παράδειγμα ξεκινά το JVM εάν δεν εκτελείται ήδη. Παρέχετε υπάρχοντα αρχεία παρουσίασης στις διαδρομές που χρησιμοποιούνται στα παραδείγματα.

Αυτό το άρθρο δείχνει ελαφριά επιθεώρηση μέσω του [PresentationFactory](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/) και του [PresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/), καθώς και στοχευμένες ενημερώσεις μέσω του [DocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/).

## **Έλεγχος μορφής παρουσίασης**

Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/#getPresentationInfo) για να ελέγξετε ένα αρχείο χωρίς να δημιουργήσετε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) . Η μέθοδος [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#getLoadFormat) αναφέρει τη ανιχνευμένη μορφή, όπως PPTX, PPT ή ODP.

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

## **Δημιουργία ελαφρού αποθέματος παρουσίασης**

Όταν επεξεργάζεστε πολλά αρχεία παρουσίασης, μπορεί να χρειαστείτε ένα συμπαγές απόθεμα για επικύρωση, ευρετηρίαση ή σύστημα διαχείρισης εγγράφων. Σε αυτήν την περίπτωση, χρησιμοποιήτε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/#getPresentationInfo) για να αποκτήσετε ένα αντικείμενο [PresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/) , και στη συνέχεια καλέστε το [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties) για να διαβάσετε τα μεταδεδομένα του εγγράφου. Αυτή η προσέγγιση δεν δημιουργεί ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) ή δεν απαιτεί να διασχίσετε το πλήρες μοντέλο αντικειμένου παρουσίασης.

Οι επεκτεινόμενες ιδιότητες που εκτίθενται από το [DocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/) παρέχουν τις ακόλουθες τιμές αποθέματος:

| Μέθοδος | Τιμή αποθέματος |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getSlides) | Συνολικός αριθμός διαφανειών. |
| [getHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Αριθμός κρυφών διαφανειών. |
| [getNotes](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getNotes) | Αριθμός διαφανειών που περιέχουν σημειώσεις. |
| [getParagraphs](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getParagraphs) | Συνολικός αριθμός παραγράφων, όταν είναι διαθέσιμος. |
| [getWords](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getWords) | Συνολικός αριθμός λέξεων. |
| [getMultimediaClips](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Συνολικός αριθμός κλιπ ήχου και βίντεο. |

Το παρακάτω παράδειγμα διαβάζει αυτές τις τιμές χωρίς να δημιουργεί ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και εκτυπώνει ένα συμπαγές απόθεμα. Συνδυάζει επίσης τα [getHeadingPairs](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getHeadingPairs) με τα [getTitlesOfParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getTitlesOfParts) για να εμφανίσει ομάδες περιεχομένου όπως γραμματοσειρές, θέματα και τίτλους διαφανειών.

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

Κάθε [HeadingPair](https://reference.aspose.com/slides/el/python-java/aspose.slides/headingpair/) παρέχει ένα όνομα ομάδας και τον αριθμό των στοιχείων σε αυτήν την ομάδα. Η μέθοδος [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getTitlesOfParts) επιστρέφει έναν επίπεδο, ταξινομημένο πίνακα, ώστε να καταναλώσετε τον αριθμό των διαδοχικών τίτλων που καθορίζονται από κάθε ζεύγος επικεφαλίδας.

### **Αποθηκευμένα μεταδεδομένα και περιορισμοί μορφής**

Οι ιδιότητες αποθέματος που επιστρέφει το [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties) αντανακλούν τα μεταδεδομένα διαθέσιμα στο αρχικό έγγραφο. Το Aspose.Slides δεν φορτώνει και διασχίζει το μοντέλο αντικειμένου παρουσίασης για να επανυπολογίσει αυτές τις τιμές για αυτήν την κλήση. Οι ελλείπουσες ιδιότητες αναπαριστώνται από προεπιλεγμένες τιμές, και οι αποθηκευμένες τιμές μπορεί να είναι παρωχημένες εάν η εφαρμογή που αποθήκευσε το αρχείο τελευταία δεν ενημέρωσε τις ιδιότητες του εγγράφου.

- **PPTX:** Η μορφή παρέχει επεκτεινόμενες ιδιότητες εγγράφου για αριθμούς διαφανειών, σημειώσεων, κρυπτών διαφανειών, παραγράφων, λέξεων και πολυμέσων, καθώς και ζεύγη επικεφαλίδων και τίτλους τμημάτων. Η διαθεσιμότητα εξαρτάται από τις ιδιότητες που έγραψε ο δημιουργός του εγγράφου.
- **PPT:** Η δυαδική μορφή μπορεί να αποθηκεύσει αντίστοιχες ιδιότητες περίληψης εγγράφου. Εάν μια ιδιότητα λείπει ή δεν ανανεώθηκε από τον δημιουργό του εγγράφου, το Aspose.Slides επιστρέφει την αποθηκευμένη ή προεπιλεγμένη τιμή αντί να την υπολογίσει από τις διαφάνειες.
- **ODP:** Τα μεταδεδομένα OpenDocument παρέχουν γενικά στατιστικά εγγράφου, όπως αριθμούς σελίδων, παραγράφων και λέξεων, αλλά αυτές οι τιμές δεν αντιστοιχούν σε κάθε ειδική για PowerPoint επεκτεινόμενη ιδιότητα. Τα μεταδεδομένα για κρυφές διαφάνειες, διαφάνειες με σημειώσεις, πολυμέσα, ζεύγη επικεφαλίδων και τίτλους τμημάτων ενδέχεται να μην είναι διαθέσιμα, και οι ιδιότητες αποθέματος μπορεί να επιστρέψουν προεπιλεγμένες τιμές. Μην θεωρείτε μια μηδενική τιμή ή ένα κενό πίνακα ως αποδεικτικό ότι το αντίστοιχο περιεχόμενο λείπει.

Χρησιμοποιήστε την ελαφριά προσέγγιση μεταδεδομένων για αποθέματα και προκαταρκτικούς ελέγχους. Φορτώστε την παρουσίαση και εξετάστε το ζωντανό μοντέλο αντικειμένου όταν το αποτέλεσμα πρέπει να αντικατοπτρίζει αλλαγές στη μνήμη ή όταν χρειάζεται να επαληθεύσετε το πραγματικό περιεχόμενο της παρουσίασης.

## **Ενημέρωση ιδιοτήτων παρουσίασης**

Οι ιδιότητες που επιστρέφει το [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties) μπορούν επίσης να αλλάξουν χωρίς τη δημιουργία ενός αντικειμένου [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) . Εφαρμόστε τις αλλαγές με το [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), και στη συνέχεια γράψτε την δεσμευμένη παρουσίαση με το [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Η ακόλουθη εικόνα δείχνει τις αρχικές ιδιότητες του εγγράφου.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Το παρακάτω παράδειγμα αλλάζει τον τίτλο και την ημερομηνία τελευταίας αποθήκευσης και γράφει το αποτέλεσμα σε ένα νέο αρχείο:

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

Η ακόλουθη εικόνα δείχνει τις αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint.

![Αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι σύνδεσμοι**

Για σχετικούς ελέγχους ασφαλείας και ρυθμίσεις προστασίας, δείτε τα παρακάτω άρθρα:

- [Προστασία παρουσιάσεων με κωδικό](/slides/el/python-java/password-protected-presentation/)
- [Προστασία παρουσιάσεων από εγγραφή](/slides/el/python-java/write-protected-presentation/)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να ελέγξω εάν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Φορτώστε την παρουσίαση και χρησιμοποιήστε το [Presentation.getFontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getFontsManager). Καλέστε το [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) για να λάβετε τις ενσωματωμένες γραμματοσειρές και το [FontsManager.getFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getFonts) για να λάβετε τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση. Συγκρίνετε τα δύο αποτελέσματα για να βρείτε τις γραμματοσειρές που απαιτούνται για την απόδοση αλλά δεν είναι ενσωματωμένες.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Όταν τα αποθηκευμένα μεταδεδομένα του εγγράφου είναι επαρκή, διαβάστε το [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getHiddenSlides) μέσω του [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/#getPresentationInfo) και του [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties). Αυτό είναι κατάλληλο για ελαφρύ απόθεμα. Εάν η παρουσίαση έχει τροποποιηθεί στη μνήμη, τα αποθηκευμένα μεταδεδομένα μπορεί να λείπουν ή να είναι παρωχημένα, ή εάν χρειάζεται να επαληθεύσετε τις τρέχουσες τιμές, επαναλάβετε τη διαδρομή μέσω του [Presentation.getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlides) και ελέγξτε τη μέθοδο [Slide.getHidden](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getHidden) κάθε διαφάνειας.

**Μπορώ να ανιχνεύσω εάν χρησιμοποιείται προσαρμοσμένο μέγεθος και προσανατολισμός διαφάνειας, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Φορτώστε την παρουσίαση και καλέστε το [Presentation.getSlideSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlideSize). Χρησιμοποιήστε τις μεθόδους [SlideSize.getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesize/#getSize), και [SlideSize.getOrientation](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesize/#getOrientation) για να συγκρίνετε τις τρέχουσες ρυθμίσεις με το αναμενόμενο πρότυπο και τις διαστάσεις.

**Υπάρχει γρήγορος τρόπος να διαπιστώ αν τα διαγράμματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Εντοπίστε κάθε [Chart](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/) και καλέστε τη μέθοδο [ChartData.getDataSourceType](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getDataSourceType). Για εξωτερικό βιβλίο εργασίας, καλέστε το [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Ο τύπος πηγής δεδομένων και η διαδρομή προσδιορίζουν μια εξωτερική αναφορά, αλλά η επαλήθευση της διαθεσιμότητας του στόχου απαιτεί ξεχωριστό έλεγχο πόρων.

**Πώς μπορώ να αξιολογήσω τις 'βαριές' διαφάνειες που μπορεί να καθυστερούν την απόδοση ή την εξαγωγή PDF;**

Δεν υπάρχει μια ενιαία ιδιότητα πολυπλοκότητας. Διασχίστε το [Presentation.getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlides) και τη συλλογή [BaseSlide.getShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getShapes) κάθε διαφάνειας. Χρησιμοποιήστε τον αριθμό των σχημάτων και την παρουσία μεγάλων εικόνων, εφέ, κινούμενων εφέ ή πολυμέσων ως δείκτες, και μετρήστε μια αντιπροσωπευτική απόδοση ή εξαγωγή πριν θεωρήσετε μια διαφάνεια ως επιβεβαιωμένο σημείο συμφόρησης.