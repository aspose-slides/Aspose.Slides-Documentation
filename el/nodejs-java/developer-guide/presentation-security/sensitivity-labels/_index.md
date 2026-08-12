---
title: Διαχείριση Ετικετών Ευαισθησίας σε Παρουσιάσεις PowerPoint με JavaScript
linktitle: Ετικέτες Ευαισθησίας
type: docs
weight: 50
url: /el/nodejs-java/sensitivity-labels/
keywords:
- ετικέτα ευαισθησίας
- Microsoft Purview
- Microsoft Information Protection
- μεταδεδομένα MIP
- σήμανση περιεχομένου
- προστασία πληροφοριών
- διακυβέρνηση εγγράφων
- PowerPoint
- PPTX
- ασφάλεια παρουσίασης
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαβάστε, προσθέστε, ενημερώστε, αφαιρέστε και μεταφέρετε τις ετικέτες ευαισθησίας του Microsoft Purview σε παρουσιάσεις PowerPoint PPTX με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Οι ετικέτες ευαισθησίας του Microsoft Purview βοηθούν τις οργανώσεις να ταξινομούν και να διαχειρίζονται έγγραφα. Κατά την αυτόματη επεξεργασία παρουσιάσεων, μια εφαρμογή ενδέχεται να χρειάζεται να διατηρήσει μια υπάρχουσα ετικέτα, να εφαρμόσει μια ετικέτα που επιλέγεται από πολιτική, να ενημερώσει την κατάσταση της ή να μεταναστεύσει τα μεταδεδομένα ετικετών που γράφτηκαν από μια παλαιότερη ροή εργασίας του Microsoft Information Protection (MIP).

Το Aspose.Slides for Node.js μέσω Java εκθέτει σύγχρονα μεταδεδομένα ετικετών ευαισθησίας μέσω [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Αυτή η μέθοδος επιστρέφει μια [SensitivityLabelCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelcollection/) η οποία μπορεί να εξεταστεί και να τροποποιηθεί πριν η παρουσίαση αποθηκευτεί ως PPTX.

{{% alert color="primary" title="Note" %}}
Οι ταυτοποιητές ετικετών ευαισθησίας και οι πληροφορίες πολιτικής ορίζονται από τη ρύθμιση του Microsoft Purview. Επικυρώστε τη διαθεσιμότητα των ετικετών και τις απαιτήσεις πολιτικής στο περιβάλλον σας πριν προσθέσετε ή μεταναστεύσετε μεταδεδομένα. Οι τιμές του [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) περιγράφουν τις σήμανσεις περιεχομένου που σχετίζονται με μια ετικέτα· δεν προσθέτουν από μόνες τους ορατό κείμενο ή σχήματα στις διαφάνειες.
{{% /alert %}}

## **Κατανόηση Ιδιοτήτων Ετικέτας Ευαισθησίας**

Κάθε [SensitivityLabel](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/) περιέχει τα παρακάτω μεταδεδομένα:

| Μέθοδοι | Σκοπός |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#getId) and [SensitivityLabel.setId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Ανακτά ή ορίζει το αναγνωριστικό της ετικέτας ευαισθησίας στην πολιτική Purview. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) and [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | Ανακτά ή ορίζει τον ιστότοπο που σχετίζεται με την πολιτική ετικέτας. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) and [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Ανακτά ή ορίζει εάν η ετικέτα είναι ενεργοποιημένη. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) and [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Ανακτά ή ορίζει εάν η ετικέτα έχει αφαιρεθεί. Ορίστε την τιμή σε `true` όταν η κατάσταση αφαίρεσης πρέπει να διατηρηθεί στα μεταδεδομένα. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) and [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Ανακτά ή ορίζει εάν η ετικέτα εφαρμόστηκε αυτόματα ή μέσω απόφασης χρήστη. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Ανακτά τους τύπους σήμανσης περιεχομένου που σχετίζονται με την ετικέτα. |

Η κλάση [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) ορίζει πώς ανατέθηκε μια ετικέτα:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια προεπιλεγμένη ή αυτόματα εφαρμοσμένη ετικέτα.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια ετικέτα που εφαρμόστηκε μέσω απόφασης χρήστη, περιλαμβάνοντας χειροκίνητα εφαρμοσμένες, προτεινόμενες και υποχρεωτικές ετικέτες.

Η κλάση [SensitivityLabelContentType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) ορίζει τη σήμανση που σχετίζεται με μια ετικέτα:

| Τιμή | Σημασία |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Η ετικέτα εφαρμόστηκε προεπιλεγμένα ή αυτόματα. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση περιεχομένου κεφαλίδας σχετίζεται με την ετικέτα. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση περιεχομένου υποσέλιδου σχετίζεται με την ετικέτα. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση περιεχομένου υδατογράμματος σχετίζεται με την ετικέτα. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Η προστασία κρυπτογράφησης σχετίζεται με την ετικέτα. |

Πολλοί τύποι σήμανσης μπορούν να συνδεθούν με μία ετικέτα.

## **Καταγραφή Υπάρχουσων Ετικετών Ευαισθησίας**

Αναγνώστε τη σύγχρονη συλλογή ετικετών από [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) και κάντε την απαρίθμησή της. Το παρακάτω παράδειγμα καταγράφει κάθε ιδιότητα και σήμανση περιεχομένου που αποθηκεύονται για κάθε ετικέτα:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Ετικέτας Ευαισθησίας με Σήμανση Περιεχομένου**

Χρησιμοποιήστε [SensitivityLabelCollection.add](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) με το αναγνωριστικό της ετικέτας, το αναγνωριστικό του ιστότοπου, την κατάσταση ενεργοποίησης και τη μέθοδο ανάθεσης. Αφού η μέθοδος επιστρέψει τη νέα [SensitivityLabel](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/), προσθέστε τις απαιτούμενες τιμές σήμανσης μέσω της λίστας που επιστρέφει το [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Το παρακάτω παράδειγμα προσθέτει μια χειροκίνητα επιλεγμένη ετικέτα που σχετίζεται με σήμανση υποσέλιδου και υδατογραφήματος και, στη συνέχεια, αποθηκεύει το αποτέλεσμα ως PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ενημέρωση Ετικέτας Ευαισθησίας**

Οι τιμές του [SensitivityLabel](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/) είναι αναγνώσιμες/εγγράφιμες, εκτός από το ότι η λίστα που επιστρέφει το [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) τροποποιείται μέσω των λειτουργιών λίστας της. Αφού εντοπίσετε την απαιτούμενη ετικέτα, μπορείτε να ενημερώσετε το αναγνωριστικό της, το αναγνωριστικό ιστότοπου, την κατάσταση ενεργοποίησης, τη μέθοδο ανάθεσης, την κατάσταση αφαίρεσης και τους τύπους σήμανσης περιεχομένου. Αποθηκεύστε την παρουσίαση για να διατηρηθούν οι αλλαγές.

Το παρακάτω παράδειγμα ενημερώνει την κατάσταση ενεργοποίησης και τη μέθοδο ανάθεσης της πρώτης ετικέτας:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Σήμανση Ετικέτας Ευαισθησίας ως Αφαιρεμένη**

Για να διατηρήσετε το γεγονός ότι μια ετικέτα αφαιρέθηκε, βρείτε την ετικέτα και καλέστε [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) με `true`. Αυτό διατηρεί την εγγραφή της ετικέτας ενώ καταγράφει την κατάσταση αφαίρεσής της. Εάν αντίθετα πρέπει να διαγράψετε μια εγγραφή από τη σύγχρονη συλλογή, χρησιμοποιήστε [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt); χρησιμοποιήστε [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) για να διαγράψετε όλες τις εγγραφές.

Το παρακάτω παράδειγμα σηματοδοτεί μια συγκεκριμένη ετικέτα ως αφαιρεμένη και αποθηκεύει την ενημερωμένη παρουσίαση:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ανάγνωση και Μεταφορά Παλαιών Ετικετών Ευαισθησίας MIP**

Οι παλαιότερες ροές εργασίας βάσει MIP μπορούν να αποθηκεύουν μεταδεδομένα ετικετών ευαισθησίας σε προσαρμοσμένες ιδιότητες εγγράφου αντί στη σύγχρονη συλλογή ετικετών. Διαβάστε αυτά τα μεταδεδομένα με το [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels). Η μέθοδος αναλύει τις κληρονομημένες προσαρμοσμένες ιδιότητες και επιστρέφει έναν πίνακα αντικειμένων [SensitivityLabel](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/).

Για να μεταφέρετε τα μεταδεδομένα, προσθέστε κάθε επιστρεφόμενη ετικέτα στη σύγχρονη [SensitivityLabelCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelcollection/) μέσω του [SensitivityLabelCollection.add](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelcollection/#add). Επειδή η προσθήκη διπλότυπου αναγνωριστικού ετικέτας προκαλεί εξαίρεση, το παράδειγμα ελέγχει τη συλλογή προορισμού πριν αντιγράψει κάθε ετικέτα. Μπορείτε να προσθέσετε περαιτέρω επικυρώσεις για να επιβεβαιώσετε ότι κάθε κληρονομημένη ετικέτα υπάρχει ακόμη στην τρέχουσα πολιτική Purview.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η μεταφορά αντιγράφει τα αναλυθέντα αντικείμενα ετικετών στη σύγχρονη συλλογή. Δεν απαιτεί τον καθαρισμό όλων των προσαρμοσμένων ιδιοτήτων εγγράφου, έτσι τα ανεξήγητα μεταδεδομένα παραμένουν άθικτα. Χρησιμοποιήστε το [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/) για να γράψετε τα σύγχρονα μεταδεδομένα ετικετών σε αρχείο PPTX.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Δημιουργεί η προσθήκη ενός τύπου σήμανσης περιεχομένου ορατή κεφαλίδα, υποσέλιδο ή υδατογράφημα στις διαφάνειες;**

Όχι. Οι τιμές που προστίθενται μέσω της λίστας που επιστρέφει το [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) περιγράφουν τις σήμανσεις που σχετίζονται με την ετικέτα ευαισθησίας. Δεν δημιουργούν ορατό κείμενο ή σχήματα στην παρουσίαση. Προσθέστε το αντίστοιχο περιεχόμενο διαφάνειας ξεχωριστά εάν η ροή εργασίας σας πρέπει να τα αποδείξει.

**Ποια είναι η διαφορά μεταξύ του να σημαδέψετε μια ετικέτα ως αφαιρεμένη και του να τη διαγράψετε από τη συλλογή;**

Καλώντας το [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) με `true` διατηρείται η εγγραφή της ετικέτας και καταγράφεται η κατάσταση αφαίρεσής της. Καλώντας το [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) διαγράφεται η εγγραφή από τη σύγχρονη συλλογή. Επιλέξτε τη λειτουργία που ταιριάζει με τις απαιτήσεις διατήρησης μεταδεδομένων του οργανισμού σας.

**Μπορεί μια παρουσίαση να περιέχει τόσο κληρονομημένα μεταδεδομένα MIP όσο και σύγχρονες ετικέτες ευαισθησίας;**

Ναι. Οι κληρονομημένες ετικέτες μπορούν να παραμείνουν σε προσαρμοσμένες ιδιότητες εγγράφου ενώ οι σύγχρονες ετικέτες είναι διαθέσιμες μέσω του [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Χρησιμοποιήστε το [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) για να διαβάσετε τα κληρονομημένα μεταδεδομένα και να μεταφέρετε μόνο τις έγκυρες ετικέτες που δεν υπάρχουν ήδη στη σύγχρονη συλλογή.

**Τι συμβαίνει όταν μια ετικέτα με το ίδιο αναγνωριστικό προστίθεται περισσότερες από μία φορές;**

Το [SensitivityLabelCollection.add](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) εγείρει εξαίρεση όταν η συλλογή περιέχει ήδη ετικέτα με το ίδιο αναγνωριστικό. Ελέγξτε τις υπάρχουσες τιμές που επιστρέφει το [SensitivityLabel.getId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sensitivitylabel/#getId) πριν προσθέσετε ή μεταφέρετε ετικέτες.

**Ποια μορφή εξόδου πρέπει να χρησιμοποιηθεί για τη διατήρηση των ενημερωμένων ετικετών ευαισθησίας;**

Αποθηκεύστε την παρουσίαση ως PPTX καλώντας το [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/), όπως φαίνεται στα παραπάνω παραδείγματα.