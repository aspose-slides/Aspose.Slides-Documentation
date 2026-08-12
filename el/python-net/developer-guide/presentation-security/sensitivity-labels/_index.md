---
title: Διαχείριση Ετικετών Ευαισθησίας σε Παρουσιάσεις PowerPoint με Python
linktitle: Ετικέτες Ευαισθησίας
type: docs
weight: 50
url: /el/python-net/sensitivity-labels/
keywords:
- ετικέτα ευαισθησίας
- Microsoft Purview
- Microsoft Information Protection
- MIP metadata
- σήμανση περιεχομένου
- προστασία πληροφοριών
- διακυβέρνηση εγγράφων
- PowerPoint
- PPTX
- ασφάλεια παρουσίασης
- Python
- Aspose.Slides
description: "Ανάγνωση, προσθήκη, ενημέρωση, κατάργηση και μεταφορά ετικετών ευαισθησίας Microsoft Purview σε παρουσιάσεις PowerPoint PPTX με Aspose.Slides για Python μέσω .NET."
---
## **Επισκόπηση**

Οι ετικέτες ευαισθησίας Microsoft Purview βοηθούν τις οργανώσεις να ταξινομούν και να διαχειρίζονται έγγραφα. Κατά την αυτοματοποιημένη επεξεργασία παρουσίασης, μια εφαρμογή ενδέχεται να χρειαστεί να διατηρήσει μια υπάρχουσα ετικέτα, να εφαρμόσει μια ετικέτα που επιλέγεται από πολιτική, να ενημερώσει την κατάσταση της ή να μεταφέρει μεταδεδομένα ετικέτας που γράφτηκαν από παλαιότερη ροή εργασίας Microsoft Information Protection (MIP).

Το Aspose.Slides for Python via .NET εκθέτει σύγχρονα μεταδεδομένα ετικέτας ευαισθησίας μέσω [Presentation.sensitivity_labels](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/sensitivity_labels/). Αυτή η ιδιότητα επιστρέφει ένα [SensitivityLabelCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelcollection/) που μπορεί να ελεγχθεί και να τροποποιηθεί πριν αποθηκευτεί η παρουσίαση ως PPTX.

{{% alert color="primary" title="Note" %}}
Οι ταυτοποιητές ετικετών ευαισθησίας και οι πληροφορίες πολιτικής ορίζονται από τη ρύθμιση του Microsoft Purview. Επικυρώστε τη διαθεσιμότητα ετικετών και τις απαιτήσεις πολιτικής στο περιβάλλον σας πριν προσθέσετε ή μεταφέρετε μεταδεδομένα. Οι τιμές [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/content_mark_types/) περιγράφουν τα περιεχόμενα σήμανσης που συνδέονται με μια ετικέτα· από μόνες τους δεν προσθέτουν ορατό κείμενο ή σχήματα στις διαφάνειες.
{{% /alert %}}

## **Κατανόηση Ιδιοτήτων Ετικέτας Ευαισθησίας**

Κάθε [SensitivityLabel](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/) περιέχει τα παρακάτω μεταδεδομένα:

| Ιδιότητα | Σκοπός |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/id/) | Ταυτοποιεί την ετικέτα ευαισθησίας στην πολιτική Purview. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/site_id/) | Ταυτοποιεί τον ιστότοπο που σχετίζεται με την πολιτική ετικέτας. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Δείχνει αν η ετικέτα είναι ενεργοποιημένη. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/is_removed/) | Δείχνει ότι η ετικέτα έχει αφαιρεθεί. Ορίστε αυτή την ιδιότητα σε `True` όταν η κατάσταση αφαίρεσης πρέπει να διατηρηθεί στα μεταδεδομένα. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Καθορίζει αν η ετικέτα εφαρμόστηκε αυτόματα ή μέσω απόφασης χρήστη. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Αναφέρει τους τύπους σήμανσης περιεχομένου που συνδέονται με την ετικέτα. |

Η απαρίθμηση [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelassignmenttype/) περιγράφει πώς εκχωρήθηκε μια ετικέτα:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια προεπιλεγμένη ή αυτόματα εφαρμοσμένη ετικέτα.  
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει ετικέτα που εφαρμοστέα μέσω απόφασης χρήστη, συμπεριλαμβανομένων των χειροκίνητων, προτεινόμενων και υποχρεωτικών ετικετών.

Η απαρίθμηση [SensitivityLabelContentType](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelcontenttype/) αναγνωρίζει τη σήμανση που σχετίζεται με μια ετικέτα:

| Τιμή | Σημασία |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelcontenttype/) | Η ετικέτα εφαρμόστηκε προεπιλογή ή αυτόματα. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση περιεχομένου κεφαλίδας συσχετίζεται με την ετικέτα. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση περιεχομένου υποσέλιδου συσχετίζεται με την ετικέτα. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση υδατογραφήματος περιεχομένου συσχετίζεται με την ετικέτα. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelcontenttype/) | Η προστασία κρυπτογράφησης συσχετίζεται με την ετικέτα. |

Πολλαπλοί τύποι σήμανσης μπορούν να συσχετιστούν με μία ετικέτα.

## **Λίστα Υφιστάμενων Ετικετών Ευαισθησίας**

Διαβάστε τη σύγχρονη συλλογή ετικετών από [Presentation.sensitivity_labels](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/sensitivity_labels/) και κάντε την απαρίθμηση. Το παρακάτω παράδειγμα εμφανίζει κάθε ιδιότητα και σήμανση περιεχομένου που αποθηκεύονται για κάθε ετικέτα:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **Προσθήκη Ετικέτας Ευαισθησίας με Σήμανση Περιεχομένου**

Χρησιμοποιήστε [SensitivityLabelCollection.add](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelcollection/add/) με τον ταυτοποιητή ετικέτας, τον ταυτοποιητή ιστότοπου, την κατάσταση ενεργοποίησης και τη μέθοδο εκχώρησης. Περνείμετε τον ταυτοποιητή ιστότοπου ως αντικείμενο Python `uuid.UUID`. Μετά την επιστροφή της νέας [SensitivityLabel](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/), προσαρτήστε τις απαιτούμενες τιμές σήμανσης στο [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/content_mark_types/).

Το παρακάτω παράδειγμα προσθέτει μια χειροκίνητα επιλεγμένη ετικέτα που συσχετίζεται με σήμανση υποσέλιδου και υδατογραφήματος και, στη συνέχεια, αποθηκεύει το αποτέλεσμα ως PPTX:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Ενημέρωση Ετικέτας Ευαισθησίας**

Οι ιδιότητες του [SensitivityLabel](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/) είναι ανάγνωση/εγγραφή, εκτός από τη λίστα που επιστρέφεται από [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/content_mark_types/) η οποία τροποποιείται μέσω των λειτουργιών λίστας της. Αφού εντοπίσετε την απαιτούμενη ετικέτα, μπορείτε να ενημερώσετε τον ταυτοποιητή της, τον ταυτοποιητή ιστότοπου, την κατάσταση ενεργοποίησης, τη μέθοδο εκχώρησης, την κατάσταση αφαίρεσης και τους τύπους σήμανσης περιεχομένου. Αποθηκεύστε την παρουσίαση για να διασφαλιστούν οι αλλαγές.

Το παρακάτω παράδειγμα ενημερώνει την κατάσταση ενεργοποίησης και τη μέθοδο εκχώρησης της πρώτης ετικέτας:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Σήμανση Ετικέτας Ευαισθησίας ως Αφαιρεθείσα**

Για να διατηρηθεί το γεγονός ότι μια ετικέτα αφαιρέθηκε, βρείτε την ετικέτα και ορίστε το [SensitivityLabel.is_removed](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/is_removed/) σε `True`. Αυτό διατηρεί την καταχώριση της ετικέτας ενώ καταγράφει την κατάσταση αφαίρεσής της. Εάν, αντιθέτως, χρειάζεται να διαγράψετε μια καταχώριση από τη σύγχρονη συλλογή, χρησιμοποιήστε [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); χρησιμοποιήστε [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelcollection/clear/) για να διαγράψετε όλες τις καταχωρίσεις.

Το παρακάτω παράδειγμα σημειώνει μια συγκεκριμένη ετικέτα ως αφαιρεθείσα και αποθηκεύει την ενημερωμένη παρουσίαση:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Ανάγνωση και Μεταφορά Κληρονομημένων Ετικετών MIP**

Οι παλαιότερες ροές εργασίας βασισμένες στο MIP μπορούν να αποθηκεύουν μεταδεδομένα ετικετών ευαισθησίας σε προσαρμοσμένες ιδιότητες εγγράφου αντί για τη σύγχρονη συλλογή ετικετών. Διαβάστε αυτά τα μεταδεδομένα με το [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). Η μέθοδος αναλύει τις κληρονομημένες προσαρμοσμένες ιδιότητες και επιστρέφει αντικείμενα [SensitivityLabel](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/).

Για να μεταφέρετε τα μεταδεδομένα, προσθέστε κάθε επιστρεφόμενη ετικέτα στη σύγχρονη [SensitivityLabelCollection](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelcollection/) μέσω του [SensitivityLabelCollection.add](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelcollection/add/). Επειδή η προσθήκη διπλού ταυτοποιητή ετικέτας προκαλεί εξαίρεση, το παράδειγμα ελέγχει τη συλλογή προορισμού πριν αντιγράψει κάθε ετικέτα. Μπορείτε να προσθέσετε περαιτέρω επικυρώσεις για να επιβεβαιώσετε ότι κάθε κληρονομημένη ετικέτα υπάρχει ακόμη στην τρέχουσα πολιτική Purview.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

Η μεταφορά αντιγράφει τα αναλυθέντα αντικείμενα ετικέτας στη σύγχρονη συλλογή. Δεν απαιτεί εκκαθάριση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου, επομένως τα άσχετα μεταδεδομένα του εγγράφου παραμένουν ακέραια. Χρησιμοποιήστε [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/) με [SaveFormat.PPTX](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/saveformat/) για να γράψετε τα σύγχρονα μεταδεδομένα ετικετών σε αρχείο PPTX.

## **Συνήθεις Ερωτήσεις**

**Δημιουργεί η προσθήκη τύπου σήμανσης περιεχομένου μια ορατή κεφαλίδα, υποσέλιδο ή υδατογράφημα στις διαφάνειες;**

Όχι. Οι τιμές που προστίθενται μέσω [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/content_mark_types/) περιγράφουν τις σήμανσεις που συνδέονται με την ετικέτα ευαισθησίας. Δεν δημιουργούν ορατό κείμενο ή σχήματα στην παρουσίαση. Προσθέστε το αντίστοιχο περιεχόμενο διαφάνειας ξεχωριστά εάν η ροή εργασίας σας πρέπει να τα αποτυπώσει.

** ποια είναι η διαφορά μεταξύ σήμανσης μιας ετικέτας ως αφαιρεθείσα και της διαγραφής της από τη συλλογή;**

Ο ορισμός του [SensitivityLabel.is_removed](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/is_removed/) σε `True` διατηρεί την καταχώριση της ετικέτας και καταγράφει την κατάσταση αφαίρεσής της. Η κλήση του [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) διαγράφει την καταχώριση από τη σύγχρονη συλλογή. Επιλέξτε τη λειτουργία που ταιριάζει στις απαιτήσεις διατήρησης μεταδεδομένων του οργανισμού σας.

**Μπορεί μια παρουσίαση να περιέχει τόσο κληρονομημένα μεταδεδομένα MIP όσο και σύγχρονες ετικέτες ευαισθησίας;**

Ναι. Οι κληρονομημένες ετικέτες μπορούν να παραμείνουν σε προσαρμοσμένες ιδιότητες εγγράφου, ενώ οι σύγχρονες ετικέτες είναι διαθέσιμες μέσω [Presentation.sensitivity_labels](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/sensitivity_labels/). Χρησιμοποιήστε το [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/el/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) για να διαβάσετε τα κληρονομημένα μεταδεδομένα και να μεταφέρετε μόνο τις έγκυρες ετικέτες που δεν υπάρχουν ήδη στη σύγχρονη συλλογή.

**Τι συμβαίνει όταν μια ετικέτα με τον ίδιο ταυτοποιητή προστίθεται περισσότερες από μία φορές;**

Το [SensitivityLabelCollection.add](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabelcollection/add/) προκαλεί εξαίρεση όταν η συλλογή περιέχει ήδη ετικέτα με τον ίδιο ταυτοποιητή. Ελέγξτε τις υπάρχουσες τιμές [SensitivityLabel.id](https://reference.aspose.com/slides/el/python-net/aspose.slides/sensitivitylabel/id/) πριν προσθέσετε ή μεταφέρετε ετικέτες.

**Ποια μορφή εξόδου πρέπει να χρησιμοποιηθεί για να διατηρηθούν οι ενημερωμένες ετικέτες ευαισθησίας;**

Αποθηκεύστε την παρουσίαση ως PPTX καλώντας το [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/) με το [SaveFormat.PPTX](https://reference.aspose.com/slides/el/python-net/aspose.slides.export/saveformat/), όπως φαίνεται στα παραπάνω παραδείγματα.