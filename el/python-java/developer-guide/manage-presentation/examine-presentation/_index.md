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
description: "Εξερευνήστε τις διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Python μέσω Java για ταχύτερη κατανόηση και πιο έξυπνους ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να αναγνωρίσει τη μορφή μιας παρουσίασης και να διαβάσει τα μεταδεδομένα του εγγράφου χωρίς να δημιουργήσει ένα πλήρες μοντέλο αντικειμένων παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να ταξινομήσετε αρχεία, να δημιουργήσετε ένα απογραφή ή να επιθεωρήσετε ιδιότητες πριν αποφασίσετε αν θα φορτώσετε και θα επεξεργαστείτε το περιεχόμενο της παρουσίασης.

Τα παραδείγματα απαιτούν το Aspose.Slides για Python μέσω Java και ένα συμβατό περιβάλλον εκτέλεσης Java. Κάθε παράδειγμα ξεκινά το JVM αν δεν εκτελείται ήδη. Παρέχετε υπάρχοντα αρχεία παρουσίασης στις διαδρομές που χρησιμοποιούνται στα παραδείγματα.

Αυτό το άρθρο επιδεικνύει ελαφριά επιθεώρηση μέσω του [PresentationFactory](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/) και του [PresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/), καθώς και στοχευμένες ενημερώσεις μέσω του [DocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/).

## **Έλεγχος Μορφής Παρουσίασης**

Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/#getPresentationInfo) για να επιθεωρήσετε ένα αρχείο χωρίς να δημιουργήσετε μια παρουσίαση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) . Η μέθοδος [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#getLoadFormat) αναφέρει τη ανιχνευμένη μορφή, όπως PPTX, PPT ή ODP.

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

## **Δημιουργία Ελαφριάς Απογραφής Παρουσίασης**

Όταν επεξεργάζεστε πολλά αρχεία παρουσίασης, ενδέχεται να χρειάζεστε μια συμπαγή απογραφή για επικύρωση, ευρετήριο ή σύστημα διαχείρισης εγγράφων. Σε αυτό το σενάριο, χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/#getPresentationInfo) για να αποκτήσετε ένα αντικείμενο [PresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/) , και στη συνέχεια καλέστε το [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties) για να διαβάσετε τα μεταδεδομένα του εγγράφου. Αυτή η προσέγγιση δεν δημιουργεί μια παρουσίαση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) ή απαιτεί να διασχίσετε ολόκληρο το μοντέλο αντικειμένων παρουσίασης.

Οι επεκτατικές ιδιότητες που εκτίθενται από το [DocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/) παρέχουν τις ακόλουθες τιμές απογραφής:

| Μέθοδος | Τιμή απογραφής |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getSlides) | Συνολικός αριθμός διαφανειών. |
| [getHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Αριθμός κρυφών διαφανειών. |
| [getNotes](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getNotes) | Αριθμός διαφανειών που περιέχουν σημειώσεις. |
| [getParagraphs](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getParagraphs) | Συνολικός αριθμός παραγράφων, όταν είναι διαθέσιμος. |
| [getWords](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getWords) | Συνολικός αριθμός λέξεων. |
| [getMultimediaClips](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Συνολικός αριθμός ηχητικών και βίντεο κλιπ. |

Το παρακάτω παράδειγμα διαβάζει αυτές τις τιμές χωρίς να δημιουργήσει ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και εκτυπώνει μια συμπαγή απογραφή. Συνδυάζει επίσης το [getHeadingPairs](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getHeadingPairs) με το [getTitlesOfParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getTitlesOfParts) για να εμφανίσει ομάδες περιεχομένου όπως γραμματοσειρές, θέματα και τίτλους διαφανειών.

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

Κάθε [HeadingPair](https://reference.aspose.com/slides/el/python-java/aspose.slides/headingpair/) παρέχει ένα όνομα ομάδας και τον αριθμό των στοιχείων σε αυτήν την ομάδα. Το [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getTitlesOfParts) επιστρέφει έναν πλατύ, διατεταγμένο πίνακα, ώστε να καταναλώσετε τον αριθμό των διαδοχικών τίτλων που καθορίζονται από κάθε ζεύγος επικεφαλίδας.

### **Αποθηκευμένα Μεταδεδομένα και Περιορισμοί Μορφής**

Οι ιδιότητες απογραφής που επιστρέφονται από το [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties) αντικατοπτρίζουν τα μεταδεδομένα που είναι διαθέσιμα στο πηγαίο έγγραφο. Το Aspose.Slides δεν φορτώνει και δεν διασχίζει το μοντέλο αντικειμένων παρουσίασης για να επαναϋπολογίσει αυτές τις τιμές για αυτήν την κλήση. Οι ελλιπείς ιδιότητες αναπαρίστανται από προεπιλεγμένες τιμές, και οι αποθηκευμένες τιμές μπορεί να είναι παλαιές εάν η εφαρμογή που αποθήκευσε τελευταίος το αρχείο δεν ενημέρωσε τις ιδιότητες του εγγράφου.

- **PPTX:** Η μορφή παρέχει επεκτατικές ιδιότητες εγγράφου για αριθμούς διαφανειών, σημειώσεων, κρυφών διαφανειών, παραγράφων, λέξεων και πολυμέσων, καθώς και ζεύγη επικεφαλίδων και τίτλους τμημάτων. Η διαθεσιμότητα εξαρτάται από τις ιδιότητες που έγραψε ο δημιουργός του εγγράφου.
- **PPT:** Η δυαδική μορφή μπορεί να αποθηκεύσει αντίστοιχες ιδιότητες σύνοψης εγγράφου. Εάν μια ιδιότητα λείπει ή δεν είχε ενημερωθεί από τον παραγωγό του εγγράφου, το Aspose.Slides επιστρέφει την αποθηκευμένη ή προεπιλεγμένη τιμή αντί να την υπολογίσει από τις διαφάνειες.
- **ODP:** Τα μεταδεδομένα OpenDocument παρέχουν γενικά στατιστικά εγγράφου, όπως αριθμό σελίδων, παραγράφων και λέξεων, αλλά αυτές οι τιμές δεν αντιστοιχούν σε κάθε επέκταση ιδιότητας ειδική για το PowerPoint. Τα μεταδεδομένα κρυφών διαφανειών, διαφανειών με σημειώσεις, πολυμέσων, ζεύγων επικεφαλίδας και τίτλων τμημάτων μπορεί να μην είναι διαθέσιμα, και οι ιδιότητες απογραφής μπορεί να επιστρέψουν προεπιλεγμένες τιμές. Μην θεωρείτε μια μηδενική τιμή ή έναν κενό πίνακα ως τεκμηριωμένη απόδειξη ότι το αντίστοιχο περιεχόμενο λείπει.

Χρησιμοποιήστε την ελαφριά προσέγγιση μεταδεδομένων για απογραφές και προκαταρκτικούς ελέγχους. Φορτώστε την παρουσίαση και επιθεωρήστε το ενεργό μοντέλο αντικειμένων όταν το αποτέλεσμα πρέπει να αντανακλά αλλαγές στη μνήμη ή όταν χρειάζεται να επαληθεύσετε το πραγματικό περιεχόμενο της παρουσίασης.

## **Ενημέρωση Ιδιοτήτων Παρουσίασης**

Οι ιδιότητες που επιστρέφονται από το [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties) μπορούν επίσης να αλλάξουν χωρίς τη δημιουργία μιας παρουσίασης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) . Εφαρμόστε τις αλλαγές με το [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) , και στη συνέχεια γράψτε την συνδεδεμένη παρουσίαση με το [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) .

Η παρακάτω εικόνα δείχνει τις αρχικές ιδιότητες εγγράφου.

![Πρωτότυπες ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

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

![Αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι Σύνδεσμοι**

Για συναφή ελέγχους ασφαλείας και ρυθμίσεις προστασίας, δείτε τα παρακάτω άρθρα:

- [Παρουσιάσεις με Προστασία Κωδικού](/slides/el/python-java/password-protected-presentation/)
- [Παρουσιάσεις με Προστασία Εγγραφής](/slides/el/python-java/write-protected-presentation/)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Φορτώστε την παρουσίαση και χρησιμοποιήστε το [Presentation.getFontsManager](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getFontsManager) . Καλέστε το [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) για να αποκτήσετε τις ενσωματωμένες γραμματοσειρές και το [FontsManager.getFonts](https://reference.aspose.com/slides/el/python-java/aspose.slides/fontsmanager/#getFonts) για να λάβετε τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση. Συγκρίνετε τα δύο αποτελέσματα για να βρείτε γραμματοσειρές που απαιτούνται για την απόδοση αλλά δεν είναι ενσωματωμένες.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Όταν τα αποθηκευμένα μεταδεδομένα εγγράφου είναι επαρκή, διαβάστε το [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getHiddenSlides) μέσω του [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/#getPresentationInfo) και του [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#readDocumentProperties) . Αυτό είναι κατάλληλο για ελαφριά απογραφή. Εάν η παρουσίαση έχει τροποποιηθεί στη μνήμη, τα αποθηκευμένα μεταδεδομένα μπορεί να λείπουν ή να είναι παλαιά, ή εάν χρειάζεται να επαληθεύσετε τις ζωντανές τιμές, κάντε επανάληψη μέσω του [Presentation.getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlides) και επιθεωρήστε τη μέθοδο [Slide.getHidden](https://reference.aspose.com/slides/el/python-java/aspose.slides/slide/#getHidden) της κάθε διαφάνειας.

**Μπορώ να ανιχνεύσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος και προσανατολισμός διαφάνειας, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Φορτώστε την παρουσίαση και καλέστε το [Presentation.getSlideSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlideSize) . Χρησιμοποιήστε το [SlideSize.getType](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesize/#getType) , το [SlideSize.getSize](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesize/#getSize) και το [SlideSize.getOrientation](https://reference.aspose.com/slides/el/python-java/aspose.slides/slidesize/#getOrientation) για να συγκρίνετε τις τρέχουσες ρυθμίσεις με το αναμενόμενο προρυθμισμένο μέγεθος και διαστάσεις.

**Υπάρχει γρήγορος τρόπος να διαπιστώ αν τα διαγράμματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναί. Εντοπίστε κάθε [Chart](https://reference.aspose.com/slides/el/python-java/aspose.slides/chart/) και καλέστε το [ChartData.getDataSourceType](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getDataSourceType) . Για ένα εξωτερικό βιβλίο εργασίας, καλέστε το [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/el/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) . Ο τύπος πηγής δεδομένων και η διαδρομή προσδιορίζουν μια εξωτερική αναφορά, αλλά η επαλήθευση της διαθεσιμότητας του στόχου απαιτεί έναν ξεχωριστό έλεγχο πόρων.

**Πώς μπορώ να αξιολογήσω τις 'βαριές' διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή PDF;**

Δεν υπάρχει μία μοναδική ιδιότητα περίπλοκότητας. Διασχίστε το [Presentation.getSlides](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSlides) και τη συλλογή [BaseSlide.getShapes](https://reference.aspose.com/slides/el/python-java/aspose.slides/baseslide/#getShapes) κάθε διαφάνειας. Χρησιμοποιήστε τον αριθμό σχημάτων και την παρουσία μεγάλων εικόνων, εφέ, κινούμενων σχεδίων ή πολυμέσων ως δείκτες φιλτραρίσματος, και μετρήστε μια αντιπροσωπευτική απόδοση ή εξαγωγή προτού θεωρήσετε μια διαφάνεια ως επιβεβαιωμένο bottleneck απόδοσης.