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
description: "Εξερευνήστε τις διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Python για ταχύτερη κατανόηση και πιο έξυπνες αξιολογήσεις περιεχομένου."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να επιθεωρήσετε τις πληροφορίες παρουσίασης στο Aspose.Slides. Εξηγεί πώς να προσδιορίσετε τη τρέχουσα μορφή μιας παρουσίασης χωρίς να φορτώσετε το πλήρες αρχείο, να διαβάσετε τις ιδιότητες εγγράφου της και να ενημερώσετε αυτές τις ιδιότητες όταν χρειάζεται.

Τα παραδείγματα βασίζονται στα API [PresentationInfo](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/) και [DocumentProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/) και δείχνουν τυπικές λειτουργίες για την εργασία με τα μεταδεδομένα παρουσίασης.

## **Έλεγχος Μορφής Παρουσίασης**

Πριν εργαστείτε σε μια παρουσίαση, ίσως θέλετε να μάθετε σε ποια μορφή (PPT, PPTX, ODP και άλλες) βρίσκεται η παρουσίαση αυτή τη στιγμή.

Μπορείτε να ελέγξετε τη μορφή μιας παρουσίασης χωρίς να την φορτώσετε. Δείτε αυτόν τον κώδικα Python:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Λήψη Ιδιοτήτων Παρουσίασης**

Αυτός ο κώδικας Python σας δείχνει πώς να λάβετε τις ιδιότητες της παρουσίασης (πληροφορίες σχετικά με την παρουσίαση):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Μπορείτε να δείτε τις [ιδιότητες στην κλάση DocumentProperties](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/#properties).

## **Ενημέρωση Ιδιοτήτων Παρουσίασης**

Το Aspose.Slides παρέχει τη μέθοδο [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) που σας επιτρέπει να κάνετε αλλαγές στις ιδιότητες της παρουσίασης.

Ας πούμε ότι έχουμε μια παρουσίαση PowerPoint με τις ιδιότητες εγγράφου που φαίνονται παρακάτω.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να επεξεργαστείτε ορισμένες ιδιότητες παρουσίασης:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Τα αποτελέσματα της αλλαγής των ιδιοτήτων εγγράφου εμφανίζονται παρακάτω.

![Αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι Σύνδεσμοι**

Για περισσότερες πληροφορίες σχετικά με μια παρουσίαση και τα χαρακτηριστικά ασφαλείας της, μπορεί να βρείτε χρήσιμο αυτούς τους συνδέσμους:

- [Έλεγχος αν μια παρουσίαση είναι κρυπτογραφημένη](https://docs.aspose.com/slides/el/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Έλεγχος αν μια παρουσίαση προστατεύεται από εγγραφή (μόνο για ανάγνωση)](https://docs.aspose.com/slides/el/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Έλεγχος αν μια παρουσίαση είναι προστατευμένη με κωδικό πριν τη φόρτωση](https://docs.aspose.com/slides/el/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Επιβεβαίωση του κωδικού που χρησιμοποιήθηκε για την προστασία μιας παρουσίασης](https://docs.aspose.com/slides/el/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Αναζητήστε τις [πληροφορίες ενσωματωμένων γραμματοσειρών](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) στο επίπεδο της παρουσίασης, έπειτα συγκρίνετε αυτές τις καταχωρήσεις με το σύνολο των [γραμματοσειρών που χρησιμοποιούνται πραγματικά σε όλο το περιεχόμενο](https://reference.aspose.com/slides/el/python-net/aspose.slides/fontsmanager/get_fonts/) για να εντοπίσετε ποιες γραμματοσειρές είναι κρίσιμες για την απόδοση.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Διέλθετε τη [συλλογή διαφανειών](https://reference.aspose.com/slides/el/python-net/aspose.slides/slidecollection/) και ελέγξτε τη [σημαία ορατότητας](https://reference.aspose.com/slides/el/python-net/aspose.slides/slide/hidden/) κάθε διαφάνειας.

**Μπορώ να εντοπίσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος και προσανατολισμός διαφάνειας, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Συγκρίνετε το τρέχον [μέγεθος διαφάνειας](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/slide_size/) και προσανατολισμό με τις τυπικές προεπιλογές· αυτό βοηθά στην πρόβλεψη της συμπεριφοράς για εκτύπωση και εξαγωγή.

**Υπάρχει γρήγορος τρόπος να διαπιστώ αν τα γραφήματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Περιηγηθείτε σε όλα τα [γράφημα](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chart/), ελέγξτε την [πηγή δεδομένων](https://reference.aspose.com/slides/el/python-net/aspose.slides.charts/chartdata/data_source_type/), και σημειώστε αν τα δεδομένα είναι εσωτερικά ή βασισμένα σε σύνδεσμο, συμπεριλαμβανομένων τυχόν σπασμένων συνδέσμων.

**Πώς μπορώ να αξιολογήσω τις «βαριές» διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή PDF;**

Για κάθε διαφάνεια, μετρήστε τον αριθμό των αντικειμένων και ψάξτε για μεγάλες εικόνες, διαφάνειες, σκιές, κινούμενα σχέδια και πολυμέσα· δώστε μια κατά προσέγγιση βαθμολογία πολυπλοκότητας ώστε να επισημάνετε πιθανά σημεία επιβάρυνσης απόδοσης.