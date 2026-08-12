---
title: Διαχείριση Ετικετών Ευαισθησίας σε Παρουσιάσεις PowerPoint στο Android
linktitle: Ετικέτες Ευαισθησίας
type: docs
weight: 50
url: /el/androidjava/sensitivity-labels/
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
- Android
- Java
- Aspose.Slides
description: "Διαβάστε, προσθέστε, ενημερώστε, αφαιρέστε και μεταφέρετε τις ετικέτες ευαισθησίας Microsoft Purview σε παρουσιάσεις PowerPoint PPTX χρησιμοποιώντας το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Οι ετικέτες ευαισθησίας Microsoft Purview βοηθούν τις οργανώσεις να ταξινομούν και να διαχειρίζονται έγγραφα. Κατά την αυτοματοποιημένη επεξεργασία παρουσίασης, μια εφαρμογή ενδέχεται να χρειαστεί να διατηρήσει μια υπάρχουσα ετικέτα, να εφαρμόσει μια ετικέτα που επιλέχθηκε από πολιτική, να ενημερώσει την κατάσταση της ή να μεταναστεύσει μεταδεδομένα ετικέτας που γράφτηκαν από παλαιότερη ροή εργασίας Microsoft Information Protection (MIP).

Το Aspose.Slides for Android via Java εκθέτει τα σύγχρονα μεταδεδομένα ετικετών ευαισθησίας μέσω του [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Αυτή η μέθοδος επιστρέφει ένα [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/) που μπορεί να εξεταστεί και να τροποποιηθεί πριν αποθηκευτεί η παρουσίαση ως PPTX.

{{% alert color="primary" title="Σημείωση" %}}

Τα αναγνωριστικά ετικετών ευαισθησίας και οι πληροφορίες πολιτικής ορίζονται από τη διαμόρφωση του Microsoft Purview. Επαληθεύστε τη διαθεσιμότητα ετικετών και τις απαιτήσεις πολιτικής στο περιβάλλον σας πριν προσθέσετε ή μεταναστεύσετε μεταδεδομένα. Οι τιμές του [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) περιγράφουν τις σήμανσης περιεχομένου που σχετίζονται με μια ετικέτα· δεν προσθέτουν αυτόνομα ορατό κείμενο ή σχήματα στις διαφάνειες.

{{% /alert %}}

## **Κατανόηση Ιδιοτήτων Ετικέτας Ευαισθησίας**

Κάθε [ISensitivityLabel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/) περιέχει τα ακόλουθα μεταδεδομένα:

| Μέθοδοι | Σκοπός |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getId--) και [ISensitivityLabel.setId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Λήψη ή ορισμός του αναγνωριστικού ετικέτας ευαισθησίας στην πολιτική Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) και [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Λήψη ή ορισμός του ιστότοπου που σχετίζεται με την πολιτική ετικέτας. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) και [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Λήψη ή ορισμός του εάν η ετικέτα είναι ενεργοποιημένη. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) και [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Λήψη ή ορισμός του εάν η ετικέτα έχει αφαιρεθεί. Ορίστε την τιμή σε `true` όταν η κατάσταση αφαίρεσης πρέπει να διατηρηθεί στα μεταδεδομένα. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) και [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Λήψη ή ορισμός του εάν η ετικέτα εφαρμόστηκε αυτόματα ή μέσω απόφασης χρήστη. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Λήψη των τύπων σήμανσης περιεχομένου που σχετίζονται με την ετικέτα. |

Η κλάση [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) ορίζει πώς εκχωρήθηκε μια ετικέτα:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια προεπιλεγμένη ή αυτόματα εφαρμοσμένη ετικέτα.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια ετικέτα που εφαρμόστηκε μέσω απόφασης χρήστη, συμπεριλαμβανομένων των χειροκίνητα εφαρμοσμένων, των προτεινόμενων και των υποχρεωτικών ετικετών.

Η κλάση [SensitivityLabelContentType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) ορίζει τη σήμανση που συνδέεται με μια ετικέτα:

| Τιμή | Νόημα |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Η ετικέτα εφαρμόστηκε προεπιλογή ή αυτόματα. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση περιεχομένου κεφαλίδας συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση περιεχομένου υποσέλιδου συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση περιεχομένου υδατογράφησης συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Η προστασία κρυπτογράφησης συνδέεται με την ετικέτα. |

Πολλοί τύποι σήμανσης μπορούν να συνδεθούν με μία ετικέτα.

## **Λίστα Υπάρχουσων Ετικετών Ευαισθησίας**

Διαβάστε τη σύγχρονη συλλογή ετικετών από το [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) και επαναλάβετε την. Το παρακάτω παράδειγμα εμφανίζει κάθε ιδιότητα και σήμανση περιεχομένου που αποθηκεύονται για κάθε ετικέτα:

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

Χρησιμοποιήστε το [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) με το αναγνωριστικό ετικέτας, το αναγνωριστικό ιστότοπου, την κατάσταση ενεργοποίησης και τη μέθοδο εκχώρησης. Αφού η μέθοδος επιστρέψει τη νέα [ISensitivityLabel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/), προσθέστε τις απαιτούμενες τιμές σήμανσης μέσω της λίστας που επιστρέφεται από το [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Το ακόλουθο παράδειγμα προσθέτει μια χειροκίνητα επιλεγμένη ετικέτα που συνδέεται με σήμανση υποσέλιδου και υδατογράφησης, και στη συνέχεια αποθηκεύει το αποτέλεσμα ως PPTX:

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

Οι τιμές του [ISensitivityLabel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/) είναι αναγνώσιμες/εγγράψιμες, εκτός από τη λίστα που επιστρέφεται από το [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) η οποία τροποποιείται μέσω των λειτουργιών λίστας της. Αφού εντοπίσετε την απαιτούμενη ετικέτα, μπορείτε να ενημερώσετε το αναγνωριστικό της, το αναγνωριστικό ιστότοπου, την κατάσταση ενεργοποίησης, τη μέθοδο εκχώρησης, την κατάσταση αφαίρεσης και τους τύπους σήμανσης περιεχομένου. Αποθηκεύστε την παρουσίαση για να διατηρήσετε τις αλλαγές.

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

## **Σήμανση Ετικέτας Ευαισθησίας ως Αφαιρεμένης**

Για να διατηρήσετε το γεγονός ότι μια ετικέτα αφαιρέθηκε, βρείτε την ετικέτα και καλέστε το [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) με `true`. Αυτό διατηρεί την εγγραφή της ετικέτας ενώ καταγράφει την κατάσταση αφαίρεσής της. Αν χρειάζεται να διαγράψετε μια εγγραφή από τη σύγχρονη συλλογή, χρησιμοποιήστε το [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); χρησιμοποιήστε το [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) για να διαγράψετε όλες τις εγγραφές.

Το παρακάτω παράδειγμα σημειώνει μια συγκεκριμένη ετικέτα ως αφαιρεμένη και αποθηκεύει την ενημερωμένη παρουσίαση:

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

## **Ανάγνωση και Μεταφορά Παλαιών Ετικετών Ευαισθησίας MIP**

Οι παλαιότερες ροές εργασίας βασισμένες σε MIP μπορούν να αποθηκεύουν μεταδεδομένα ετικέτας ευαισθησίας σε προσαρμοσμένες ιδιότητες εγγράφου αντί για τη σύγχρονη συλλογή ετικετών. Διαβάστε αυτά τα μεταδεδομένα με το [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Η μέθοδος αναλύει τις κληρονομημένες προσαρμοσμένες ιδιότητες και επιστρέφει έναν πίνακα αντικειμένων [ISensitivityLabel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/).

Για να μεταφέρετε τα μεταδεδομένα, προσθέστε κάθε ετικέτα που επιστράφηκε στη σύγχρονη [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/) μέσω του [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Επειδή η προσθήκη διπλότυπου αναγνωριστικού ετικέτας προκαλεί εξαίρεση, το παράδειγμα ελέγχει τη συλλογή προορισμού πριν αντιγράψει κάθε ετικέτα. Μπορείτε να προσθέσετε περαιτέρω έλεγχο για να επιβεβαιώσετε ότι κάθε κληρονομημένη ετικέτα υπάρχει ακόμη στην τρέχουσα πολιτική Purview.

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

Η μεταφορά αντιγράφει τα αναλυμένα αντικείμενα ετικετών στη σύγχρονη συλλογή. Δεν απαιτεί εκκαθάριση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου, έτσι τα μη σχετιζόμενα μεταδεδομένα παραμένουν άθικτα. Χρησιμοποιήστε το [IPresentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/) για να γράψετε τα σύγχρονα μεταδεδομένα ετικετών σε αρχείο PPTX.

## **Συχνές Ερωτήσεις**

**Δημιουργεί η προσθήκη τύπου σήμανσης περιεχομένου μια ορατή κεφαλίδα, υποσέλιδο ή υδατογράφημα στις διαφάνειες;**

Όχι. Οι τιμές που προστίθενται μέσω της λίστας που επιστρέφεται από το [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) περιγράφουν τις σήμανσεις που σχετίζονται με την ετικέτα ευαισθησίας. Δεν δημιουργούν ορατό κείμενο ή σχήματα στην παρουσίαση. Προσθέστε το αντίστοιχο περιεχόμενο διαφάνειας ξεχωριστά εάν η ροή εργασίας σας πρέπει να εμφανίσει αυτές τις σήμανσεις.

** Ποια είναι η διαφορά μεταξύ του να σημειωθεί μια ετικέτα ως αφαιρεμένη και του να διαγραφεί από τη συλλογή;**

Καλώντας το [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) με `true` διατηρείται η εγγραφή της ετικέτας και καταγράφεται η κατάσταση αφαίρεσής της. Καλώντας το [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) η εγγραφή διαγράφεται από τη σύγχρονη συλλογή. Επιλέξτε τη λειτουργία που ταιριάζει στις απαιτήσεις διατήρησης μεταδεδομένων του οργανισμού σας.

**Μπορεί μια παρουσίαση να περιέχει τόσο μεταδεδομένα MIP κληρονομημένα όσο και σύγχρονες ετικέτες ευαισθησίας;**

Ναι. Οι κληρονομημένες ετικέτες μπορούν να παραμείνουν σε προσαρμοσμένες ιδιότητες εγγράφου, ενώ οι σύγχρονες ετικέτες είναι διαθέσιμες μέσω του [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Χρησιμοποιήστε το [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) για να διαβάσετε τα κληρονομημένα μεταδεδομένα και να μεταφέρετε μόνο τις έγκυρες ετικέτες που δεν υπάρχουν ήδη στη σύγχρονη συλλογή.

**Τι συμβαίνει όταν προστίθεται μια ετικέτα με το ίδιο αναγνωριστικό περισσότερες από μία φορές;**

Το [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) προκαλεί εξαίρεση όταν η συλλογή περιέχει ήδη μια ετικέτα με το ίδιο αναγνωριστικό. Ελέγξτε τις υπάρχουσες τιμές που επιστρέφονται από το [ISensitivityLabel.getId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getId--) πριν προσθέσετε ή μεταφέρετε ετικέτες.

**Ποια μορφή εξόδου πρέπει να χρησιμοποιηθεί για τη διατήρηση των ενημερωμένων ετικετών ευαισθησίας;**

Αποθηκεύστε την παρουσίαση ως PPTX καλώντας το [IPresentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/), όπως φαίνεται στα παραδείγματα παραπάνω.