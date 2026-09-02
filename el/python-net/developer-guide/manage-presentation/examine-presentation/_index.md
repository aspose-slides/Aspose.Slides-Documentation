---
title: "Ανάκτηση και Ενημέρωση Πληροφοριών Παρουσίασης σε Python"
linktitle: "Πληροφορίες Παρουσίασης"
type: docs
weight: 30
url: /el/python-net/examine-presentation/
keywords:
- "μορφή παρουσίασης"
- "ιδιότητες παρουσίασης"
- "ιδιότητες εγγράφου"
- "λήψη ιδιοτήτων"
- "ανάγνωση ιδιοτήτων"
- "αλλαγή ιδιοτήτων"
- "τροποποίηση ιδιοτήτων"
- "ενημέρωση ιδιοτήτων"
- "εξέταση PPTX"
- "εξέταση PPT"
- "εξέταση ODP"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "Python"
- "Aspose.Slides"
description: "Εξερευνήστε τις διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Python για πιο γρήγορες γνώσεις και πιο έξυπνους ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να εντοπίσει τη μορφή μιας παρουσίασης και να διαβάσει τα μεταδεδομένα του εγγράφου χωρίς να δημιουργήσει ένα πλήρες αντικειμενοστραφές μοντέλο παρουσίασης. Αυτό είναι χρήσιμο όταν πρέπει να ταξινομήσετε αρχεία, να δημιουργήσετε μια απογραφή ή να ελέγξετε ιδιότητες πριν αποφασίσετε αν θα φορτώσετε και θα επεξεργαστείτε το περιεχόμενο της παρουσίασης.

Αυτό το άρθρο δείχνει ελαφριά επιθεώρηση μέσω [PresentationFactory](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/) και [PresentationInfo](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/), καθώς και στοχευμένες ενημερώσεις μέσω [DocumentProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/).

## **Έλεγχος Μορφής Παρουσίασης**

Χρησιμοποιήστε [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) για να επιθεωρήσετε ένα αρχείο χωρίς να δημιουργήσετε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/). Η ιδιότητα [PresentationInfo.load_format](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/load_format/) αναφέρει τη ανιχνευθείσα μορφή, όπως PPTX, PPT ή ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Δημιουργία Ελαφράς Απογραφής Παρουσίασης**

Όταν επεξεργάζεστε πολλά αρχεία παρουσίασης, μπορεί να χρειαστείτε μια συμπαγή απογραφή για επικύρωση, ευρετηρίαση ή σύστημα διαχείρισης εγγράφων. Σε αυτό το σενάριο, χρησιμοποιήστε [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) για να λάβετε ένα αντικείμενο [PresentationInfo](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/), και κατόπιν καλέστε [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/read_document_properties/) για να διαβάσετε τα μεταδεδομένα του εγγράφου. Αυτή η προσέγγιση δεν δημιουργεί ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) ούτε απαιτεί να διασχίσετε το πλήρες αντικειμενοστραφές μοντέλο της παρουσίασης.

Οι επεκτατές ιδιότητες που αποκαλύπτονται από το [DocumentProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/) παρέχουν τις ακόλουθες τιμές απογραφής:

| Ιδιότητα | Τιμή απογραφής |
| --- | --- |
| [slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/slides/el/) | Συνολικός αριθμός διαφανειών. |
| [hidden_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/hidden_slides/) | Αριθμός κρυφών διαφανειών. |
| [notes](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/notes/) | Αριθμός διαφανειών που περιέχουν σημειώσεις. |
| [paragraphs](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/paragraphs/) | Συνολικός αριθμός παραγράφων, εφόσον είναι διαθέσιμος. |
| [words](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/words/) | Συνολικός αριθμός λέξεων. |
| [multimedia_clips](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/multimedia_clips/) | Συνολικός αριθμός ηχητικών και βίντεο κλιπ. |

Το παρακάτω παράδειγμα διαβάζει αυτές τις τιμές χωρίς να δημιουργεί ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) και εκτυπώνει μια συμπαγή απογραφή. Συνδυάζει επίσης το [heading_pairs](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/heading_pairs/) με τα [titles_of_parts](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/titles_of_parts/) για να εμφανίσει ομάδες περιεχομένου όπως γραμματοσειρές, θέματα και τίτλους διαφανειών.

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

Κάθε [HeadingPair](https://reference.aspose.com/slides/el/python-net/aspose.slides/headingpair/) παρέχει ένα όνομα ομάδας και τον αριθμό των στοιχείων σε αυτήν την ομάδα. Το [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/titles_of_parts/) είναι μια επίπεδη, διατεταγμένη συλλογή, έτσι καταναλώνετε τον αριθμό των διαδοχικών τίτλων που ορίζονται από κάθε heading pair.

### **Αποθηκευμένα Μεταδεδομένα και Περιορισμοί Μορφής**

Οι ιδιότητες απογραφής που επιστρέφει το [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/read_document_properties/) αντικατοπτρίζουν τα μεταδεδομένα που είναι διαθέσιμα στο πηγαίο έγγραφο. Το Aspose.Slides δεν φορτώνει και δεν διασχίζει το μοντέλο αντικειμένων παρουσίασης για να επαναϋπολογίσει αυτές τις τιμές για αυτήν την κλήση. Οι ελλιπείς ιδιότητες παρουσιάζονται με προεπιλεγμένες τιμές, και οι αποθηκευμένες τιμές μπορεί να είναι παλιές εάν η εφαρμογή που αποθήκευσε τελευταία το αρχείο δεν ενημέρωσε τις ιδιότητες εγγράφου.

- **PPTX:** Η μορφή παρέχει επεκτατικές ιδιότητες εγγράφου για μετρήσεις διαφάνειας, σημειώσεων, κρυφών διαφανειών, παραγράφων, λέξεων και πολυμέσων, καθώς και heading pairs και titles of parts. Η διαθεσιμότητα εξαρτάται από το ποιες ιδιότητες έγραψε ο δημιουργός του εγγράφου.
- **PPT:** Η δυαδική μορφή μπορεί να αποθηκεύσει αντίστοιχες ιδιότητες σύνοψης εγγράφου. Εάν μια ιδιότητα λείπει ή δεν ανανεώθηκε από τον δημιουργό, το Aspose.Slides επιστρέφει την αποθηκευμένη ή προεπιλεγμένη τιμή αντί να την υπολογίσει από τις διαφάνειες.
- **ODP:** Τα μεταδεδομένα OpenDocument παρέχουν γενικά στατιστικά εγγράφου, όπως αριθμό σελίδων, παραγράφων και λέξεων, αλλά αυτές οι τιμές δεν αντιστοιχούν σε κάθε PowerPoint‑συγκεκριμένη επεκτατική ιδιότητα. Τα μεταδεδομένα κρυφών διαφανειών, σημειώσεων, πολυμεσικών, heading‑pair και part‑title μπορεί να μην είναι διαθέσιμα, και οι ιδιότητες απογραφής μπορεί να επιστρέψουν προεπιλεγμένες τιμές. Μην θεωρείτε μηδενική τιμή ή κενή συλλογή ως αποδεικτικό ότι το αντίστοιχο περιεχόμενο λείπει.

Χρησιμοποιήστε την ελαφριά προσέγγιση μεταδεδομένων για απογραφές και προκαταρκτικούς ελέγχους. Φορτώστε την παρουσίαση και ελέγξτε το ζωντανό μοντέλο αντικειμένων όταν το αποτέλεσμα πρέπει να αντανακλά αλλαγές στη μνήμη ή όταν χρειάζεται επαλήθευση του πραγματικού περιεχομένου της παρουσίασης.

## **Ενημέρωση Ιδιοτήτων Παρουσίασης**

Οι ιδιότητες που επιστρέφει το [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/read_document_properties/) μπορούν επίσης να τροποποιηθούν χωρίς τη δημιουργία ενός αντικειμένου [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/). Εφαρμόστε τις αλλαγές με το [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/update_document_properties/), και κατόπιν γράψτε την δεσμευμένη παρουσίαση με το [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

Η ακόλουθη εικόνα δείχνει τις αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Το παρακάτω παράδειγμα τροποποιεί τον τίτλο και την ώρα τελευταίας αποθήκευσης και γράφει το αποτέλεσμα σε νέο αρχείο:

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

Η ακόλουθη εικόνα δείχνει τις αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint.

![Αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι Σύνδεσμοι**

Για σχετικούς ελέγχους ασφαλείας και ρυθμίσεις προστασίας, δείτε τα παρακάτω άρθρα:

- [Password-Protect Presentations](/slides/el/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/el/python-net/write-protected-presentation/)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Φορτώστε την παρουσίαση και χρησιμοποιήστε το [Presentation.fonts_manager](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/fonts_manager/). Καλέστε το [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) για να αποκτήσετε τις ενσωματωμένες γραμματοσειρές και το [FontsManager.get_fonts](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_fonts/) για να λάβετε τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση. Συγκρίνετε τα δύο αποτελέσματα για να βρείτε γραμματοσειρές που απαιτούνται για την απόδοση αλλά δεν είναι ενσωματωμένες.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Όταν τα αποθηκευμένα μεταδεδομένα εγγράφου είναι επαρκή, διαβάστε το [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/hidden_slides/) μέσω του [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) και του [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/read_document_properties/). Αυτό είναι κατάλληλο για ελαφριά απογραφή. Εάν η παρουσίαση έχει τροποποιηθεί στη μνήμη, τα αποθηκευμένα μεταδεδομένα μπορεί να λείπουν ή να είναι παλιά, ή αν χρειάζεται επαλήθευση ζωνών τιμών, περάστε από τις [Presentation.slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/slides/el/) και ελέγξτε την ιδιότητα [Slide.hidden](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/hidden/) κάθε διαφάνειας.

**Μπορώ να εντοπίσω αν χρησιμοποιούνται προσαρμοσμένο μέγεθος διαφάνειας και προσανατολισμός, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Φορτώστε την παρουσίαση και διαβάστε το [Presentation.slide_size](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/slide_size/). Ελέγξτε το [SlideSize.type](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidesize/type/), το [SlideSize.size](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidesize/size/) και το [SlideSize.orientation](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidesize/orientation/) για να συγκρίνετε τις τρέχουσες ρυθμίσεις με τις αναμενόμενες προεπιλογές και διαστάσεις.

**Υπάρχει γρήγορος τρόπος να δω αν τα διαγράμματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Εντοπίστε κάθε [Chart](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/) και ελέγξτε το [ChartData.data_source_type](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/data_source_type/). Για εξωτερικό βιβλίο εργασίας, διαβάστε το [ChartData.external_workbook_path](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Ο τύπος πηγής δεδομένων και η διαδρομή προσδιορίζουν μια εξωτερική αναφορά, αλλά η επαλήθευση της διαθεσιμότητας του στόχου απαιτεί ξεχωριστό έλεγχο πόρων.

**Πώς μπορώ να αξιολογήσω τις «βαριές» διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή σε PDF;**

Δεν υπάρχει μια ενιαία ιδιότητα πολυπλοκότητας. Διασχίστε τις [Presentation.slides](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/slides/el/) και τη συλλογή [BaseSlide.shapes](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslide/shapes/) κάθε διαφάνειας. Χρησιμοποιήστε μετρήσεις σχήματος και την παρουσία μεγάλων εικόνων, εφέ, κινούμενων γραφικών ή πολυμέσων ως σήματα φιλτραρίσματος, και εκτελέστε μια αντιπροσωπευτική απόδοση ή εξαγωγή πριν θεωρήσετε μια διαφάνεια ως επιβεβαιωμένο σημάδι επιβράδυνσης απόδοσης.