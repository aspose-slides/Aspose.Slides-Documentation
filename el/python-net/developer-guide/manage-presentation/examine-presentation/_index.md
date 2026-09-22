---
title: Ανάκτηση και Ενημέρωση Πληροφοριών Παρουσίασης σε Python
linktitle: Πληροφορίες Παρουσίασης
type: docs
weight: 30
url: /el/python-net/examine-presentation/
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
- Aspose.Slides
description: "Εξερευνήστε διαφάνειες, δομή και μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Python για πιο γρήγορες διορατικότητες και πιο έξυπνες ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να εντοπίσει τη μορφή μιας παρουσίασης και να διαβάσει τα μεταδεδομένα του εγγράφου χωρίς να δημιουργήσει ένα πλήρες μοντέλο αντικειμένου παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να ταξινομήσετε αρχεία, να δημιουργήσετε ένα απογραφή ή να ελέγξετε ιδιότητες πριν αποφασίσετε αν θα φορτώσετε και θα επεξεργαστείτε το περιεχόμενο της παρουσίασης.

Αυτό το άρθρο επιδεικνύει ελαφριά επιθεώρηση μέσω [PresentationFactory](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/) και [PresentationInfo](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/), καθώς και στοχευμένες ενημερώσεις μέσω [DocumentProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/).

## **Έλεγχος Μορφής Παρουσίασης**

Αν έχετε ήδη φορτωμένη παρουσίαση, δείτε το [Determine the Original Presentation Format](/slides/el/python-net/detect-presentation-source-format/) για εντοπισμό μετά το φόρτωμα και τους περιορισμούς των παλαιών ροών PPT, PPS και POT.

Χρησιμοποιήστε το [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) για να εξετάσετε ένα αρχείο χωρίς να δημιουργήσετε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) . Η ιδιότητα [PresentationInfo.load_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/load_format/) αναφέρει τη ανιχνευθείσα μορφή, όπως PPTX, PPT ή ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Δημιουργία Ελαφριάς Απογραφής Παρουσίασης**

Όταν επεξεργάζεστε πολλά αρχεία παρουσίασης, ενδέχεται να χρειάζεστε μια συμπαγή απογραφή για επικύρωση, ευρετηρίαση ή σύστημα διαχείρισης εγγράφων. Σε αυτό το σενάριο, χρησιμοποιήστε το [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) για να αποκτήσετε ένα αντικείμενο [PresentationInfo](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/) , και στη συνέχεια καλέστε το [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/read_document_properties/) για να διαβάσετε τα μεταδεδομένα του εγγράφου. Αυτή η προσέγγιση δεν δημιουργεί μια παρουσία του [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και δεν απαιτεί να περιηγηθείτε στο πλήρες μοντέλο αντικειμένου παρουσίασης.

Οι επεκτατικές ιδιότητες που εκτίθενται από [DocumentProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/) παρέχουν τις ακόλουθες τιμές απογραφής:

| Ιδιότητα | Τιμή απογραφής |
| --- | --- |
| [slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/slides/el/) | Συνολικός αριθμός διαφανειών. |
| [hidden_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/hidden_slides/) | Αριθμός κρυφών διαφανειών. |
| [notes](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/notes/) | Αριθμός διαφανειών που περιέχουν σημειώσεις. |
| [paragraphs](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/paragraphs/) | Συνολικός αριθμός παραγράφων, όταν είναι διαθέσιμος. |
| [words](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/words/) | Συνολικός αριθμός λέξεων. |
| [multimedia_clips](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/multimedia_clips/) | Συνολικός αριθμός ηχητικών και βιντεοαποσπασμάτων. |

Το παρακάτω παράδειγμα διαβάζει αυτές τις τιμές χωρίς να δημιουργήσει ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και εκτυπώνει μια συμπαγή απογραφή. Συνδυάζει επίσης τα [heading_pairs](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/heading_pairs/) με τα [titles_of_parts](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/titles_of_parts/) για να εμφανίσει ομάδες περιεχομένου όπως γραμματοσειρές, θέματα και τίτλους διαφανειών.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

Κάθε [HeadingPair](https://reference.aspose.com/slides/el/python-net/aspose.slides/headingpair/) παρέχει ένα όνομα ομάδας και τον αριθμό των στοιχείων σε αυτήν την ομάδα. Η [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/titles_of_parts/) είναι μια επίπεδη, διατεταγμένη συλλογή, επομένως ποσοτικοποιήστε τον αριθμό διαδοχικών τίτλων που καθορίζονται από κάθε heading pair.

### **Αποθηκευμένα Μεταδεδομένα και Περιορισμοί Μορφής**

Οι ιδιότητες απογραφής που επιστρέφει το [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/read_document_properties/) αντανακλούν τα μεταδεδομένα που είναι διαθέσιμα στο αρχικό έγγραφο. Το Aspose.Slides δεν φορτώνει και δεν περιηγείται στο μοντέλο αντικειμένου παρουσίασης για να επανυπολογίσει αυτές τις τιμές για αυτήν την κλήση. Οι ελλιπείς ιδιότητες απεικονίζονται με προεπιλεγμένες τιμές και οι αποθηκευμένες τιμές μπορεί να είναι παλαιές εάν η εφαρμογή που αποθήκευσε τελευταία το αρχείο δεν ενημέρωσε τις ιδιότητες του εγγράφου.

- **PPTX:** Η μορφή προσφέρει επεκτατικές ιδιότητες εγγράφου για αριθμούς διαφανειών, σημειώσεων, κρυφών διαφανειών, παραγράφων, λέξεων και πολυμέσων, καθώς και ζεύγη επικεφαλίδων και τίτλους τμημάτων. Η διαθεσιμότητα εξαρτάται από το ποιες ιδιότητες έγραψε ο δημιουργός του εγγράφου.
- **PPT:** Η δυαδική μορφή μπορεί να αποθηκεύσει αντίστοιχες ιδιότητες περίληψης εγγράφου. Εάν μια ιδιότητα λείπει ή δεν έχει ενημερωθεί από τον δημιουργό, το Aspose.Slides επιστρέφει την αποθηκευμένη ή προεπιλεγμένη της τιμή αντί να την υπολογίσει από τις διαφάνειες.
- **ODP:** Τα μεταδεδομένα OpenDocument προσφέρουν γενικές στατιστικές εγγράφου, όπως αριθμούς σελίδων, παραγράφων και λέξεων, αλλά αυτές οι τιμές δεν αντιστοιχούν σε κάθε ειδική επεκτατική ιδιότητα του PowerPoint. Τα μεταδεδομένα κρυφών διαφανειών, σημειώσεων, πολυμέσων, ζεύγων επικεφαλίδων και τίτλων τμημάτων μπορεί να μην είναι διαθέσιμα, και οι ιδιότητες απογραφής μπορεί να επιστρέψουν προεπιλεγμένες τιμές. Μην θεωρείτε μηδενική τιμή ή κενή συλλογή ως αποδεικτικό ότι το αντίστοιχο περιεχόμενο λείπει.

Χρησιμοποιήστε την ελαφριά προσέγγιση μεταδεδομένων για απογραφές και προκαταρκτικούς ελέγχους. Φορτώστε την παρουσίαση και ελέγξτε το ενεργό μοντέλο αντικειμένου όταν το αποτέλεσμα πρέπει να αντανακλά αλλαγές στη μνήμη ή όταν χρειάζεται να επαληθεύσετε το πραγματικό περιεχόμενο της παρουσίασης.

## **Ενημέρωση Ιδιοτήτων Παρουσίασης**

Οι ιδιότητες που επιστρέφει το [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/read_document_properties/) μπορούν επίσης να τροποποιηθούν χωρίς τη δημιουργία μιας παρουσίασης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) . Εφαρμόστε τις αλλαγές με το [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/update_document_properties/) και, στη συνέχεια, γράψτε την δεσμευμένη παρουσίαση με το [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/write_binded_presentation/) .

Η παρακάτω εικόνα δείχνει τις αρχικές ιδιότητες του εγγράφου της παρουσίασης PowerPoint:

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Το παρακάτω παράδειγμα αλλάζει τον τίτλο και την ώρα τελευταίας αποθήκευσης και γράφει το αποτέλεσμα σε νέο αρχείο:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

Η παρακάτω εικόνα δείχνει τις αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint:

![Αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι Σύνδεσμοι**

Για σχετικούς ελέγχους ασφαλείας και ρυθμίσεις προστασίας, δείτε τα ακόλουθα άρθρα:

- [Password-Protect Presentations](/slides/el/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/el/python-net/write-protected-presentation/)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Φορτώστε την παρουσίαση και χρησιμοποιήστε το [Presentation.fonts_manager](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/fonts_manager/). Καλέστε το [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) για να λάβετε τις ενσωματωμένες γραμματοσειρές και το [FontsManager.get_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_fonts/) για να λάβετε τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση. Συγκρίνετε τα δύο αποτελέσματα για να βρείτε τις γραμματοσειρές που απαιτούνται για απόδοση αλλά δεν είναι ενσωματωμένες.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Όταν τα αποθηκευμένα μεταδεδομένα εγγράφου είναι επαρκή, διαβάστε το [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/hidden_slides/) μέσω του [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) και του [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/read_document_properties/). Αυτό είναι κατάλληλο για ελαφριά απογραφή. Αν η παρουσίαση έχει τροποποιηθεί στη μνήμη, τα αποθηκευμένα μεταδεδομένα μπορεί να λείπουν ή να είναι παλαιά· ή αν χρειάζεται να επαληθεύσετε τις ζωντανές τιμές, διατρέξτε το [Presentation.slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/slides/el/) και ελέγξτε την ιδιότητα [Slide.hidden](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/hidden/) κάθε διαφάνειας.

**Μπορώ να ανιχνεύσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος διαφάνειας και προσανατολισμός, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Φορτώστε την παρουσίαση και διαβάστε το [Presentation.slide_size](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/slide_size/). Ελέγξτε το [SlideSize.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidesize/type/), το [SlideSize.size](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidesize/size/) και το [SlideSize.orientation](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidesize/orientation/) για να συγκρίνετε τις τρέχουσες ρυθμίσεις με τις αναμενόμενες προεπιλογές και διαστάσεις.

**Υπάρχει γρήγορος τρόπος να δούμε αν τα διαγράμματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναί. Εντοπίστε κάθε [Chart](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/) και ελέγξτε το [ChartData.data_source_type](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/data_source_type/). Για εξωτερικό βιβλίο εργασίας, διαβάστε το [ChartData.external_workbook_path](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Ο τύπος πηγής δεδομένων και η διαδρομή αναγνωρίζουν μια εξωτερική αναφορά, αλλά η επαλήθευση της διαθεσιμότητας του στόχου απαιτεί ξεχωριστό έλεγχο πόρων.

**Πώς μπορώ να αξιολογήσω «βαριές» διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή PDF;**

Δεν υπάρχει μία μοναδική ιδιότητα πολυπλοκότητας. Διατρέξτε το [Presentation.slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/slides/el/) και τη συλλογή [BaseSlide.shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslide/shapes/) κάθε διαφάνειας. Χρησιμοποιήστε μετρήσεις αριθμού σχημάτων και την παρουσία μεγάλων εικόνων, εφέ, κινούμενων σχεδίων ή πολυμέσων ως σήματα ελέγχου, και πραγματοποιήστε μια αντιπροσωπευτική απόδοση ή εξαγωγή πριν θεωρήσετε μια διαφάνεια ως επιβεβαιωμένο σημείο συμφόρησης στην απόδοση.