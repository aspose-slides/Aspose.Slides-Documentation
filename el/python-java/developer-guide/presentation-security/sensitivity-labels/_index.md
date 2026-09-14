---
title: Διαχείριση Ετικετών Ευαισθησίας σε Παρουσιάσεις PowerPoint με Python
linktitle: Ετικέτες Ευαισθησίας
type: docs
weight: 50
url: /el/python-java/sensitivity-labels/
keywords:
- ετικέτα ευαισθησίας
- Microsoft Purview
- Microsoft Information Protection
- μεταδεδομένα MIP
- επισήμανση περιεχομένου
- προστασία πληροφοριών
- διακυβέρνηση εγγράφων
- PowerPoint
- PPTX
- ασφάλεια παρουσίασης
- Python
- Aspose.Slides
description: "Διαβάστε, προσθέστε, ενημερώστε, αφαιρέστε και μεταφέρετε τις ετικέτες ευαισθησίας Microsoft Purview σε παρουσιάσεις PowerPoint PPTX με το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Οι ετικέτες ευαισθησίας του Microsoft Purview βοηθούν τις οργανώσεις να κατατάσσουν και να διαχειρίζονται έγγραφα. Κατά την αυτοματοποιημένη επεξεργασία παρουσίασης, μια εφαρμογή μπορεί να χρειάζεται να διατηρήσει μια υπάρχουσα ετικέτα, να εφαρμόσει μια ετικέτα που έχει επιλεγεί από πολιτική, να ενημερώσει την κατάσταση της ή να μεταφέρει μεταδεδομένα ετικέτας που έχουν γραφτεί από μια παλαιότερη ροή εργασίας του Microsoft Information Protection (MIP).

Το Aspose.Slides εκθέτει τα σύγχρονα μεταδεδομένα ετικέτας ευαισθησίας μέσω του [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSensitivityLabels). Αυτή η μέθοδος επιστρέφει μια [SensitivityLabelCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelcollection/) η οποία μπορεί να εξεταστεί και να τροποποιηθεί πριν η παρουσίαση αποθηκευτεί ως PPTX.

{{% alert color="info" title="Note" %}}
Τα αναγνωριστικά ετικετών ευαισθησίας και οι πληροφορίες πολιτικής ορίζονται από τη ρύθμιση του Microsoft Purview. Επικυρώστε τη διαθεσιμότητα ετικέτας και τις απαιτήσεις πολιτικής στο περιβάλλον σας πριν προσθέσετε ή μεταφέρετε μεταδεδομένα. Οι τιμές του [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) περιγράφουν τις επισήμανσεις περιεχομένου που συνδέονται με μια ετικέτα· από μόνες τους δεν προσθέτουν ορατό κείμενο ή σχήματα στις διαφάνειες.
{{% /alert %}}

## **Κατανοήστε τις Ιδιότητες Ετικέτας Ευαισθησίας**

Κάθε [SensitivityLabel](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/) περιέχει τα ακόλουθα μεταδεδομένα:

| Μέθοδοι | Σκοπός |
| --- | --- |
| [getId](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#getId) και [setId](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#setId) | Ανάκτηση ή ορισμός του αναγνωριστικού ετικέτας ευαισθησίας στην πολιτική Purview. |
| [getSiteId](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#getSiteId) και [setSiteId](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Ανάκτηση ή ορισμός του ιστότοπου που συνδέεται με την πολιτική ετικέτας. |
| [isEnabled](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#isEnabled) και [setEnabled](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Ανάκτηση ή ορισμός εάν η ετικέτα είναι ενεργοποιημένη. |
| [isRemoved](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#isRemoved) και [setRemoved](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Ανάκτηση ή ορισμός εάν η ετικέτα έχει αφαιρεθεί. Ορίστε την τιμή σε `True` όταν πρέπει να διατηρηθεί η κατάσταση αφαίρεσης στα μεταδεδομένα. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) και [setAssignmentMethodType](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Ανάκτηση ή ορισμός εάν η ετικέτα εφαρμόστηκε αυτόματα ή μέσω απόφασης χρήστη. |
| [getContentMarkTypes](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Ανάκτηση των τύπων επισήμανσης περιεχομένου που συνδέονται με την ετικέτα. |

Η κλάση [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelassignmenttype/) ορίζει πώς μια ετικέτα έχει ανατεθεί:

- [Standard](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια προεπιλεγμένη ή αυτόματα εφαρμοσμένη ετικέτα.
- [Privileged](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια ετικέτα που εφαρμόζεται μέσω απόφασης χρήστη, συμπεριλαμβανομένων των χειροκίνητα εφαρμοσμένων, προτεινόμενων και υποχρεωτικών ετικετών.

Η κλάση [SensitivityLabelContentType](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelcontenttype/) ορίζει την επισήμανση που συνδέεται με μια ετικέτα:

| Τιμή | Νόημα |
| --- | --- |
| [None](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelcontenttype/) | Η ετικέτα εφαρμόστηκε προεπιλογή ή αυτόματα. |
| [Header](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelcontenttype/) | Η επισήμανση περιεχομένου κεφαλίδας συνδέεται με την ετικέτα. |
| [Footer](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelcontenttype/) | Η επισύμανση περιεχομένου υποσέλιδου συνδέεται με την ετικέτα. |
| [Watermark](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelcontenttype/) | Η επισήμανση περιεχομένου υδατογράφημα συνδέεται με την ετικέτα. |
| [Encryption](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelcontenttype/) | Η προστασία κρυπτογράφησης συνδέεται με την ετικέτα. |

Πολλαπλοί τύποι επισήμανσης μπορούν να συνδέονται με μία ετικέτα.

## **Λίστα Υπαρχουσών Ετικετών Ευαισθησίας**

Διαβάστε τη σύγχρονη συλλογή ετικετών από το [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSensitivityLabels) και κάντε την επανάληψή της. Το παρακάτω παράδειγμα εμφανίζει κάθε ιδιότητα και επισήμανση περιεχομένου που αποθηκεύονται για κάθε ετικέτα:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **Προσθήκη Ετικέτας Ευαισθησίας με Επισήμανση Περιεχομένου**

Χρησιμοποιήστε το [SensitivityLabelCollection.add](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelcollection/#add) με το αναγνωριστικό ετικέτας, το αναγνωριστικό ιστότοπου, την κατάσταση ενεργοποίησης και τη μέθοδο ανάθεσης. Αφού η μέθοδος επιστρέψει τη νέα [SensitivityLabel](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/), προσθέστε τις απαιτούμενες τιμές επισήμανσης μέσω της λίστας που επιστρέφει το [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Το παρακάτω παράδειγμα προσθέτει μια χειροκίνητα επιλεγμένη ετικέτα που συνδέεται με επισήμανση υποσέλιδου και υδατογραφήματος και στη συνέχεια αποθηκεύει το αποτέλεσμα ως PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ενημέρωση Ετικέτας Ευαισθησίας**

Οι τιμές του [SensitivityLabel](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/) είναι αναγνώσιμες/εγγραφές, εκτός από τη λίστα που επιστρέφει το [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) η οποία τροποποιείται μέσω των λειτουργιών της λίστας. Αφού εντοπίσετε την απαιτούμενη ετικέτα, μπορείτε να ενημερώσετε το αναγνωριστικό της, το αναγνωριστικό ιστότοπου, την κατάσταση ενεργοποίησης, τη μέθοδο ανάθεσης, την κατάσταση αφαίρεσης και τους τύπους επισήμανσης περιεχομένου. Αποθηκεύστε την παρουσίαση για να διατηρηθούν οι αλλαγές.

Το παρακάτω παράδειγμα ενημερώνει την κατάσταση ενεργοποίησης και τη μέθοδο ανάθεσης της πρώτης ετικέτας:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Σήμανση Ετικέτας Ευαισθησίας ως Αφαιρεμένη**

Για να διατηρήσετε το γεγονός ότι μια ετικέτα αφαιρέθηκε, βρείτε την ετικέτα και καλέστε το [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#setRemoved) με `True`. Αυτό διατηρεί την καταχώρηση της ετικέτας ενώ καταγράφει την κατάσταση αφαίρεσης. Εάν αντίθετα χρειάζεται να διαγράψετε μια καταχώρηση από τη σύγχρονη συλλογή, χρησιμοποιήστε το [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelcollection/#removeAt); χρησιμοποιήστε το [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelcollection/#clear) για να διαγράψετε όλες τις καταχωρίσεις.

Το παρακάτω παράδειγμα σημαδεύει μια συγκεκριμένη ετικέτα ως αφαιρεμένη και αποθηκεύει την ενημερωμένη παρουσίαση:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ανάγνωση και Μεταφορά Κληρονομικών Ετικετών Ευαισθησίας MIP**

Οι παλαιότερες ροές εργασίας βασισμένες στο MIP μπορούν να αποθηκεύουν μεταδεδομένα ετικετών ευαισθησίας σε προσαρμοσμένες ιδιότητες εγγράφου αντί για τη σύγχρονη συλλογή ετικετών. Διαβάστε αυτά τα μεταδεδομένα με το [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getSensitivityLabels). Η μέθοδος αναλύει τις κληρονομικές προσαρμοσμένες ιδιότητες και επιστρέφει έναν πίνακα αντικειμένων [SensitivityLabel](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/).

Για να μεταφέρετε τα μεταδεδομένα, προσθέστε κάθε επιστρεφόμενη ετικέτα στη σύγχρονη [SensitivityLabelCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelcollection/) μέσω του [SensitivityLabelCollection.add](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelcollection/#add). Επειδή η προσθήκη διπλότυπου αναγνωριστικού ετικέτας προκαλεί εξαίρεση, το παράδειγμα ελέγχει τη συλλογή προορισμού πριν αντιγράψει κάθε ετικέτα. Μπορείτε να προσθέσετε περαιτέρω επικυρώσεις για να επιβεβαιώσετε ότι κάθε κληρονομική ετικέτα υπάρχει ακόμη στην τρέχουσα πολιτική Purview.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η μεταφορά αντιγράφει τα αναλυθέντα αντικείμενα ετικέτας στη σύγχρονη συλλογή. Δεν απαιτεί εκκαθάριση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου, έτσι τα ανεξάρτητα μεταδεδομένα του εγγράφου παραμένουν αμετάβλητα. Χρησιμοποιήστε το [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/) για να γράψετε τα σύγχρονα μεταδεδομένα ετικετών σε αρχείο PPTX.

## **Συχνές Ερωτήσεις**

**Δημιουργεί η προσθήκη τύπου επισήμανσης περιεχομένου ορατή κεφαλίδα, υποσέλιδο ή υδατογράφημα στις διαφάνειες;**

Όχι. Οι τιμές που προστίθενται μέσω της λίστας που επιστρέφει το [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) περιγράφουν τις επισήμανσης που συνδέονται με την ετικέτα ευαισθησίας. Δεν δημιουργούν ορατό κείμενο ή σχήματα στην παρουσίαση. Προσθέστε το αντίστοιχο περιεχόμενο διαφάνειας ξεχωριστά εάν η ροή εργασίας σας απαιτεί την απόδοση αυτών των επισήμανσης.

**Ποια είναι η διαφορά μεταξύ του να σημαδέψετε μια ετικέτα ως αφαιρεμένη και του να τη διαγράψετε από τη συλλογή;**

Η κλήση του [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#setRemoved) με `True` διατηρεί την καταχώρηση της ετικέτας και καταγράφει την κατάσταση αφαίρεσης. Η κλήση του [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) διαγράφει την καταχώρηση από τη σύγχρονη συλλογή. Επιλέξτε τη λειτουργία που ταιριάζει στις απαιτήσεις διατήρησης μεταδεδομένων του οργανισμού σας.

**Μπορεί μια παρουσίαση να περιέχει τόσο κληρονομικά μεταδεδομένα MIP όσο και σύγχρονες ετικέτες ευαισθησίας;**

Ναι. Οι κληρονομικές ετικέτες μπορούν να παραμείνουν σε προσαρμοσμένες ιδιότητες εγγράφου, ενώ οι σύγχρονες ετικέτες είναι διαθέσιμες μέσω του [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getSensitivityLabels). Χρησιμοποιήστε το [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/el/python-java/aspose.slides/documentproperties/#getSensitivityLabels) για να διαβάσετε τα κληρονομικά μεταδεδομένα και να μεταφέρετε μόνο τις έγκυρες ετικέτες που δεν υπάρχουν ήδη στη σύγχρονη συλλογή.

**Τι συμβαίνει όταν μια ετικέτα με το ίδιο αναγνωριστικό προστίθεται περισσότερες από μία φορές;**

Το [SensitivityLabelCollection.add](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabelcollection/#add) προκαλεί εξαίρεση όταν η συλλογή περιέχει ήδη ετικέτα με το ίδιο αναγνωριστικό. Ελέγξτε τις υπάρχουσες τιμές που επιστρέφει το [SensitivityLabel.getId](https://reference.aspose.com/slides/el/python-java/aspose.slides/sensitivitylabel/#getId) πριν προσθέσετε ή μεταφέρετε ετικέτες.

**Ποια μορφή εξόδου πρέπει να χρησιμοποιηθεί για τη διατήρηση των ενημερωμένων ετικετών ευαισθησίας;**

Αποθηκεύστε την παρουσίαση ως PPTX καλώντας το [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/), όπως φαίνεται στα παραδείγματα παραπάνω.