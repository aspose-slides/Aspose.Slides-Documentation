---
title: "Διαχείριση Ετικετών Ευαισθησίας σε Παρουσιάσεις PowerPoint σε Java"
linktitle: "Ετικέτες Ευαισθησίας"
type: docs
weight: 50
url: /el/java/sensitivity-labels/
keywords:
- "ετικέτα ευαισθησίας"
- "Microsoft Purview"
- "Προστασία Πληροφοριών Microsoft"
- "μεταδεδομένα MIP"
- "σήμανση περιεχομένου"
- "προστασία πληροφοριών"
- "διακυβέρνηση εγγράφων"
- "PowerPoint"
- "PPTX"
- "ασφάλεια παρουσίασης"
- "Java"
- "Aspose.Slides"
description: "Διαβάστε, προσθέστε, ενημερώστε, αφαιρέστε και μετακινήστε τις ετικέτες ευαισθησίας του Microsoft Purview σε παρουσιάσεις PowerPoint PPTX με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Οι ετικέτες ευαισθησίας του Microsoft Purview βοηθούν τις οργανώσεις να ταξινομούν και να διαχειρίζονται έγγραφα. Κατά τη διάρκεια της αυτοματοποιημένης επεξεργασίας παρουσιάσεων, μια εφαρμογή ενδέχεται να χρειάζεται να διατηρήσει μια υπάρχουσα ετικέτα, να εφαρμόσει μια ετικέτα που επιλέγεται από πολιτική, να ενημερώσει την κατάσταση της ή να μεταφέρει τα μεταδεδομένα ετικέτας που εγράφησαν από μια παλαιότερη ροή εργασίας Microsoft Information Protection (MIP).

Aspose.Slides αποκαλύπτει τα σύγχρονα μεταδεδομένα ετικέτας ευαισθησίας μέσω του [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Αυτή η μέθοδος επιστρέφει μια [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/) που μπορεί να εξεταστεί και να τροποποιηθεί πριν την παρουσίαση αποθηκευτεί ως PPTX.

{{% alert color="primary" title="Σημείωση" %}}

Οι ταυτοποιητές ετικετών ευαισθησίας και οι πληροφορίες πολιτικής ορίζονται από τη ρύθμιση του Microsoft Purview. Επαληθεύστε τη διαθεσιμότητα των ετικετών και τις απαιτήσεις πολιτικής στο περιβάλλον σας πριν προσθέσετε ή μετακινήσετε μεταδεδομένα. Οι τιμές του [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) περιγράφουν τις σήμανσεις περιεχομένου που συνδέονται με μια ετικέτα· δεν προσθέτουν από μόνες τους ορατό κείμενο ή σχήματα στις διαφάνειες.

{{% /alert %}}

## **Κατανόηση Ιδιοτήτων Ετικέτας Ευαισθησίας**

Κάθε [ISensitivityLabel](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/) περιέχει τα ακόλουθα μεταδεδομένα:

| Μέθοδοι | Σκοπός |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getId--) και [ISensitivityLabel.setId](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Ανάκτηση ή ορισμός του αναγνωριστικού ετικέτας ευαισθησίας στην πολιτική Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getSiteId--) και [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Ανάκτηση ή ορισμός του site που σχετίζεται με την πολιτική ετικέτας. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#isEnabled--) και [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Ανάκτηση ή ορισμός του αν η ετικέτα είναι ενεργοποιημένη. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#isRemoved--) και [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Ανάκτηση ή ορισμός του αν η ετικέτα έχει αφαιρεθεί. Ορίστε την τιμή σε `true` όταν η κατάσταση αφαίρεσης πρέπει να διατηρείται στα μεταδεδομένα. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) και [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Ανάκτηση ή ορισμός του αν η ετικέτα εφαρμόστηκε αυτόματα ή μέσω απόφασης χρήστη. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Ανάκτηση των τύπων σήμανσης περιεχομένου που συσχετίζονται με την ετικέτα. |

Η κλάση [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelassignmenttype/) ορίζει πώς μια ετικέτα εκχωρήθηκε:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια προεπιλεγμένη ή αυτόματα εφαρμοσμένη ετικέτα.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια ετικέτα που εφαρμόζεται μέσω απόφασης χρήστη, συμπεριλαμβανομένων των χειροκίνητα εφαρμόσιμων, προτεινόμενων και υποχρεωτικών ετικετών.

Η κλάση [SensitivityLabelContentType](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelcontenttype/) ορίζει τη σήμανση που σχετίζεται με μια ετικέτα:

| Τιμή | Νόημα |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelcontenttype/) | Η ετικέτα εφαρμόστηκε προεπιλεγμένα ή αυτόματα. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση περιεχομένου κεφαλίδας συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση περιεχομένου υποσέλιδου συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση περιεχομένου υδατοποίτησης συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelcontenttype/) | Η προστασία κρυπτογράφησης συνδέεται με την ετικέτα. |

Πολλοί τύποι σήμανσης μπορούν να συσχετιστούν με μία ετικέτα.

## **Λίστα Υπαρχουσών Ετικετών Ευαισθησίας**

Διαβάστε τη σύγχρονη συλλογή ετικετών από το [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) και επαναλάβετε την. Το ακόλουθο παράδειγμα εμφανίζει κάθε ιδιότητα και σήμανση περιεχομένου που αποθηκεύεται για κάθε ετικέτα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Ετικέτας Ευαισθησίας με Σήμανση Περιεχομένου**

Χρησιμοποιήστε το [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) με το αναγνωριστικό της ετικέτας, το αναγνωριστικό του site, την κατάσταση ενεργοποίησης και τη μέθοδο εκχώρησης. Αφού η μέθοδος επιστρέψει τη νέα [ISensitivityLabel](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/), προσθέστε τις απαιτούμενες τιμές σήμανσης μέσω της λίστας που επιστρέφει το [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Το παρακάτω παράδειγμα προσθέτει μια χειροκίνητα επιλεγμένη ετικέτα που σχετίζεται με σήμανση υποσέλιδου και υδατοποίτησης, και στη συνέχεια αποθηκεύει το αποτέλεσμα ως PPTX:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ενημέρωση Ετικέτας Ευαισθησίας**

Οι τιμές του [ISensitivityLabel](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/) είναι αναγνώσιμες/εγγράψιμες, εκτός από τη λίστα που επιστρέφει το [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) η οποία τροποποιείται μέσω των λειτουργιών λίστας της. Αφού εντοπίσετε την απαιτούμενη ετικέτα, μπορείτε να ενημερώσετε το αναγνωριστικό της, το αναγνωριστικό του site, την κατάσταση ενεργοποίησης, τη μέθοδο εκχώρησης, την κατάσταση αφαίρεσης και τους τύπους σήμανσης περιεχομένου. Αποθηκεύστε την παρουσίαση για να διατηρήσετε τις αλλαγές.

Το παρακάτω παράδειγμα ενημερώνει την κατάσταση ενεργοποίησης και τη μέθοδο εκχώρησης της πρώτης ετικέτας:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Σήμανση Ετικέτας Ευαισθησίας ως Αφαιρεμένη**

Για να διατηρήσετε το γεγονός ότι μια ετικέτα αφαιρέθηκε, βρείτε την ετικέτα και καλέστε το [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) με `true`. Αυτό διατηρεί την καταχώρηση της ετικέτας ενώ καταγράφει την κατάσταση αφαίρεσής της. Εάν αντίθετα χρειάζεται να διαγράψετε μια καταχώρηση από τη σύγχρονη συλλογή, χρησιμοποιήστε το [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); χρησιμοποιήστε το [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/#clear--) για να διαγράψετε όλες τις καταχωρήσεις.

Το παρακάτω παράδειγμα σηματοδοτεί μια συγκεκριμένη ετικέτα ως αφαιρεμένη και αποθηκεύει την ενημερωμένη παρουσίαση:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ανάγνωση και Μετακίνηση Κληρονομικών Ετικετών Ευαισθησίας MIP**

Οι παλαιότερες ροές εργασίας βασισμένες στο MIP μπορούν να αποθηκεύουν τα μεταδεδομένα ετικέτας ευαισθησίας σε προσαρμοσμένες ιδιότητες εγγράφου αντί για τη σύγχρονη συλλογή ετικετών. Διαβάστε αυτά τα μεταδεδομένα με το [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Η μέθοδος αναλύει τις κληρονομικές προσαρμοσμένες ιδιότητες και επιστρέφει έναν πίνακα αντικειμένων [ISensitivityLabel](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/).

Για να μετακινήσετε τα μεταδεδομένα, προσθέστε κάθε επιστρεφόμενη ετικέτα στη σύγχρονη [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/) μέσω του [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Επειδή η προσθήκη ενός διπλότυπου αναγνωριστικού ετικέτας προκαλεί εξαίρεση, το παράδειγμα ελέγχει τη συλλογή προορισμού πριν αντιγράψει κάθε ετικέτα. Μπορείτε να προσθέσετε περαιτέρω επαλήθευση για να επιβεβαιώσετε ότι κάθε κληρονομική ετικέτα εξακολουθεί να υπάρχει στην τρέχουσα πολιτική Purview.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η μετακίνηση αντιγράφει τα αναλυμένα αντικείμενα ετικετών στη σύγχρονη συλλογή. Δεν απαιτείται εκκαθάριση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου, έτσι τα μη σχετιζόμενα μεταδεδομένα παραμένουν αμιγγράφητα. Χρησιμοποιήτε το [IPresentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/) για να γράψετε τα σύγχρονα μεταδεδομένα ετικέτας σε αρχείο PPTX.

## **FAQ**

**Δημιουργεί η προσθήκη τύπου σήμανσης περιεχομένου μια ορατή κεφαλίδα, υποσέλιδο ή υδατοποίηση στις διαφάνειες;**

Όχι. Οι τιμές που προστίθενται μέσω της λίστας που επιστρέφει το [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) περιγράφουν τις σήμανσεις που σχετίζονται με την ετικέτα ευαισθησίας. Δεν δημιουργούν ορατό κείμενο ή σχήματα στην παρουσίαση. Προσθέστε το αντίστοιχο περιεχόμενο διαφάνειας ξεχωριστά εάν η ροή εργασίας σας πρέπει να αποτυπώσει αυτές τις σήμανσεις.

**Ποια είναι η διαφορά μεταξύ σήμανσης μιας ετικέτας ως αφαιρεμένη και διαγραφής της από τη συλλογή;**

Η κλήση του [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) με `true` διατηρεί την καταχώρηση της ετικέτας και καταγράφει την κατάσταση αφαίρεσής της. Η κλήση του [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) διαγράφει την καταχώρηση από τη σύγχρονη συλλογή. Επιλέξτε τη λειτουργία που ταιριάζει με τις απαιτήσεις διατήρησης μεταδεδομένων του οργανισμού σας.

**Μπορεί μια παρουσίαση να περιέχει τόσο κληρονομικά μεταδεδομένα MIP όσο και σύγχρονες ετικέτες ευαισθησίας;**

Ναι. Οι κληρονομικές ετικέτες μπορούν να παραμείνουν σε προσαρμοσμένες ιδιότητες εγγράφου, ενώ οι σύγχρονες ετικέτες είναι διαθέσιμες μέσω του [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Χρησιμοποιήστε το [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) για να διαβάσετε τα κληρονομικά μεταδεδομένα και να μετακινήσετε μόνο τις έγκυρες ετικέτες που δεν υπάρχουν ήδη στη σύγχρονη συλλογή.

**Τι συμβαίνει όταν μια ετικέτα με το ίδιο αναγνωριστικό προστίθεται περισσότερες από μία φορές;**

Το [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) προκαλεί εξαίρεση όταν η συλλογή περιέχει ήδη μια ετικέτα με το ίδιο αναγνωριστικό. Ελέγξτε τις υπάρχουσες τιμές που επιστρέφει το [ISensitivityLabel.getId](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getId--) πριν προσθέσετε ή μετακινήσετε ετικέτες.

**Ποια μορφή εξόδου πρέπει να χρησιμοποιηθεί για τη διατήρηση των ενημερωμένων ετικετών ευαισθησίας;**

Αποθηκεύστε την παρουσίαση ως PPTX καλώντας το [IPresentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/), όπως φαίνεται στα παραπάνω παραδείγματα.