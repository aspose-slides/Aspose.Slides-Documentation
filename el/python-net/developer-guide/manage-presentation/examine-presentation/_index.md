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
description: "Εξερευνήστε τις διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Python για πιο γρήγορη κατανόηση και εξυπνότερους ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να ελέγξετε τις πληροφορίες παρουσίασης στο Aspose.Slides. Εξηγεί πώς να προσδιορίσετε το τρέχον φορμάτ μιας παρουσίασης χωρίς να φορτώσετε ολόκληρο το αρχείο, να διαβάσετε τις ιδιότητες εγγράφου της και να ενημερώσετε αυτές τις ιδιότητες όταν χρειάζεται.

Τα παραδείγματα βασίζονται στις διεπαφές [PresentationInfo](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/) και [DocumentProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/) και δείχνουν τυπικές ενέργειες για εργασία με μεταδεδομένα παρουσίασης.

## **Έλεγχος μορφής παρουσίασης**

Πριν εργαστείτε με μια παρουσίαση, ίσως θέλετε να μάθετε σε ποιο φορμάτ (PPT, PPTX, ODP και άλλα) βρίσκεται η παρουσίαση αυτή τη στιγμή.

Μπορείτε να ελέγξετε το φορμάτ μιας παρουσίασης χωρίς να την φορτώσετε. Δείτε αυτόν τον κώδικα Python:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Λήψη ιδιοτήτων παρουσίασης**

Αυτός ο κώδικας Python σας δείχνει πώς να λάβετε τις ιδιότητες της παρουσίασης (πληροφορίες σχετικά με την παρουσίαση):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Ίσως θελήσετε να δείτε τις [ιδιότητες στην κλάση DocumentProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/#properties).

## **Ενημέρωση ιδιοτήτων παρουσίασης**

Το Aspose.Slides παρέχει τη μέθοδο [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) που επιτρέπει την τροποποίηση των ιδιοτήτων της παρουσίασης.

Ας υποθέσουμε ότι έχουμε μια παρουσίαση PowerPoint με τις ιδιότητες εγγράφου που φαίνονται παρακάτω.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να επεξεργαστείτε ορισμένες ιδιότητες της παρουσίασης:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Τα αποτελέσματα της αλλαγής των ιδιοτήτων εγγράφου εμφανίζονται παρακάτω.

![Αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι σύνδεσμοι**

Για να λάβετε περισσότερες πληροφορίες σχετικά με μια παρουσίαση και τα χαρακτηριστικά ασφαλείας της, μπορεί να βρείτε αυτούς τους συνδέσμους χρήσιμους:

- [Προστασία παρουσίασης με κωδικό](/slides/el/python-net/password-protected-presentation/)
- [Προστασία παρουσίασης από εγγραφή](/slides/el/python-net/write-protected-presentation/)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Αναζητήστε τις [πληροφορίες ενσωματωμένων γραμματοσειρών](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) σε επίπεδο παρουσίασης, έπειτα συγκρίνετε αυτές τις εγγραφές με το σύνολο των [γραμματοσειρών που χρησιμοποιούνται πραγματικά στο περιεχόμενο](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_fonts/) για να εντοπίσετε ποιες γραμματοσειρές είναι κρίσιμες για την απόδοση.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Περιηγηθείτε στη [συλλογή διαφανειών](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/) και εξετάστε τη [σημαία ορατότητας](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/hidden/) κάθε διαφάνειας.

**Μπορώ να ανιχνεύσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος και προσανατολισμός διαφάνειας, και αν διαφέρουν από τα προεπιλεγμένα;**

Ναι. Συγκρίνετε το τρέχον [μέγεθος διαφάνειας](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/slide_size/) και προσανατολισμό με τα τυπικά προεπιλεγμένα, ώστε να προβλέψετε τη συμπεριφορά κατά την εκτύπωση και εξαγωγή.

**Υπάρχει γρήγορος τρόπος να δειτε αν τα γραφήματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Περιηγηθείτε σε όλα τα [γράφηματα](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/), ελέγξτε την [πηγή δεδομένων](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/data_source_type/) και παρατηρήστε αν τα δεδομένα είναι εσωτερικά ή βασισμένα σε σύνδεσμο, συμπεριλαμβανομένων τυχόν σπασμένων συνδέσμων.

**Πώς μπορώ να αξιολογήσω τις 'βαριές' διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή PDF;**

Για κάθε διαφάνεια, μετρήστε τα αντικείμενα και ψάξτε για μεγάλες εικόνες, διαφάνειες, σκιές, κινήσεις και πολυμέσα· δώστε μια κατά προσέγγιση βαθμολογία πολυπλοκότητας για να επισημάνετε πιθανά σημεία συμφόρησης απόδοσης.