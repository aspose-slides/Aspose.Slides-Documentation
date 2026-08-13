---
title: Διαχείριση Ετικετών Ευαισθησίας σε Παρουσιάσεις PowerPoint σε Java
linktitle: Ετικέτες Ευαισθησίας
type: docs
weight: 50
url: /el/java/sensitivity-labels/
keywords:
- ετικέτα ευαισθησίας
- Microsoft Purview
- Microsoft Information Protection
- μεταδεδομένα MIP
- ένδειξη περιεχομένου
- προστασία πληροφοριών
- διακυβέρνηση εγγράφων
- PowerPoint
- PPTX
- ασφάλεια παρουσίασης
- Java
- Aspose.Slides
description: "Διαβάστε, προσθέστε, ενημερώστε, αφαιρέστε και μεταφέρετε ετικέτες ευαισθησίας Microsoft Purview σε παρουσιάσεις PowerPoint PPTX με Aspose.Slides για Java."
---
## **Επισκόπηση**

Οι ετικέτες ευαισθησίας του Microsoft Purview βοηθούν τις οργανώσεις να ταξινομούν και να διαχειρίζονται τα έγγραφα. Κατά την αυτόματη επεξεργασία παρουσιάσεων, μια εφαρμογή μπορεί να χρειαστεί να διατηρήσει μια υπάρχουσα ετικέτα, να εφαρμόσει μια ετικέτα που έχει επιλεχθεί από πολιτική, να ενημερώσει την κατάσταση της ή να μεταφέρει μεταδεδομένα ετικέτας που έχουν γραφτεί από μια παλαιότερη ροή εργασίας Microsoft Information Protection (MIP).

Aspose.Slides εκθέτει σύγχρονα μεταδεδομένα ετικετών ευαισθησίας μέσω [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Αυτή η μέθοδος επιστρέφει ένα [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/) που μπορεί να ελεγχθεί και να τροποποιηθεί πριν την παρουσίαση αποθηκευτεί ως PPTX.

{{% alert color="info" title="Σημείωση" %}}
Οι αναγνωριστές ετικετών ευαισθησίας και οι πληροφορίες πολιτικής ορίζονται από τις ρυθμίσεις του Microsoft Purview. Επαληθεύστε τη διαθεσιμότητα των ετικετών και τις απαιτήσεις της πολιτικής στο περιβάλλον σας πριν προσθέσετε ή μεταφέρετε μεταδεδομένα. Οι τιμές του [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) περιγράφουν τις ενδείξεις περιεχομένου που συνδέονται με μια ετικέτα· δεν προσθέτουν από μόνες τους ορατό κείμενο ή σχήματα στις διαφάνειες.
{{% /alert %}}

## **Κατανόηση Ιδιοτήτων Ετικέτας Ευαισθησίας**

Κάθε [ISensitivityLabel](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/) περιλαμβάνει τα παρακάτω μεταδεδομένα:

| Μέθοδοι | Σκοπός |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getId--) and [ISensitivityLabel.setId](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Λήψη ή ορισμός του αναγνωριστικού ετικέτας ευαισθησίας στην πολιτική Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getSiteId--) and [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Λήψη ή ορισμός του site που συνδέεται με την πολιτική ετικέτας. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#isEnabled--) and [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Λήψη ή ορισμός του αν η ετικέτα είναι ενεργή. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#isRemoved--) and [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Λήψη ή ορισμός του αν η ετικέτα έχει αφαιρεθεί. Ορίστε την τιμή σε `true` όταν πρέπει να διατηρηθεί η κατάσταση αφαίρεσης στα μεταδεδομένα. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) and [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Λήψη ή ορισμός του αν η ετικέτα εφαρμόστηκε αυτόματα ή με απόφαση χρήστη. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Λήψη των τύπων ενδείξεων περιεχομένου που συνδέονται με την ετικέτα. |

Η κλάση [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelassignmenttype/) καθορίζει πώς ανατέθηκε μια ετικέτα:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια προεπιλεγμένη ή αυτόματα εφαρμοσμένη ετικέτα.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια ετικέτα που εφαρμόστηκε μέσω απόφασης χρήστη, συμπεριλαμβανομένων των χειροκίνητα εφαρμοσμένων, προτεινόμενων και υποχρεωτικών ετικετών.

Η κλάση [SensitivityLabelContentType](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelcontenttype/) καθορίζει την ένδειξη που συνδέεται με μια ετικέτα:

| Τιμή | Σημασία |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelcontenttype/) | Η ετικέτα εφαρμόστηκε προεπιλεγμένα ή αυτόματα. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelcontenttype/) | Η ένδειξη περιεχομένου κεφαλίδας συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelcontenttype/) | Η ένδειξη περιεχομένου υποσέλιδου συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelcontenttype/) | Η ένδειξη περιεχομένου υδατογραφήματος συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/el/java/com.aspose.slides/sensitivitylabelcontenttype/) | Η προστασία κρυπτογράφησης συνδέεται με την ετικέτα. |

Πολλοί τύποι ενδείξεων μπορούν να συνδεθούν με μία ετικέτα.

## **Λίστα Υπάρχουσες Ετικέτες Ευαισθησίας**

Διαβάστε τη σύγχρονη συλλογή ετικετών από [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) και κάντε επανάληψη. Το παρακάτω παράδειγμα εμφανίζει κάθε ιδιότητα και ένδειξη περιεχομένου που αποθηκεύεται για κάθε ετικέτα:

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

## **Προσθήκη Ετικέτας Ευαισθησίας με Ενδείξη Περιεχομένου**

Χρησιμοποιήστε [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) με το αναγνωριστικό της ετικέτας, το αναγνωριστικό site, την κατάσταση ενεργοποίησης και τη μέθοδο ανάθεσης. Αφού η μέθοδος επιστρέψει τη νέα [ISensitivityLabel](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/), προσθέστε τις απαιτούμενες τιμές ενδείξεων μέσω του καταλόγου που επιστρέφει το [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Το παρακάτω παράδειγμα προσθέτει μια χειροκίνητα επιλεγμένη ετικέτα που συνδέεται με ενδείξεις υποσέλιδου και υδατογραφήματος και στη συνέχεια αποθηκεύει το αποτέλεσμα ως PPTX:

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

Οι τιμές του [ISensitivityLabel](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/) είναι αναγνώσιμες/εγγράψιμες, εκτός από το κατάλογο που επιστρέφει το [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) ο οποίος τροποποιείται μέσω των λειτουργιών του καταλόγου. Αφού εντοπίσετε την απαιτούμενη ετικέτα, μπορείτε να ενημερώσετε το αναγνωριστικό, το αναγνωριστικό site, την κατάσταση ενεργοποίησης, τη μέθοδο ανάθεσης, την κατάσταση αφαίρεσης και τους τύπους ενδείξεων περιεχομένου. Αποθηκεύστε την παρουσίαση για να διατηρηθούν οι αλλαγές.

Το παρακάτω παράδειγμα ενημερώνει την κατάσταση ενεργοποίησης και τη μέθοδο ανάθεσης της πρώτης ετικέτας:

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

Για να διατηρήσετε το γεγονός ότι μια ετικέτα αφαιρέθηκε, βρείτε την ετικέτα και καλέστε το [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) με `true`. Αυτό διατηρεί την καταχώρηση της ετικέτας ενώ καταγράφει την κατάσταση αφαίρεσής της. Εάν αντίθετα θέλετε να διαγράψετε μια καταχώρηση από τη σύγχρονη συλλογή, χρησιμοποιήστε το [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); χρησιμοποιήστε το [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/#clear--) για να διαγράψετε κάθε εγγραφή.

Το παρακάτω παράδειγμα σημαδεύει μια συγκεκριμένη ετικέτα ως αφαιρεμένη και αποθηκεύει την ενημερωμένη παρουσίαση:

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

## **Ανάγνωση και Μεταφορά Κληρονομικών Ετικετών Ευαισθησίας MIP**

Οι παλαιότερες ροές εργασίας βασισμένες στο MIP μπορούν να αποθηκεύουν μεταδεδομένα ετικέτας ευαισθησίας σε προσαρμοσμένες ιδιότητες εγγράφου αντί για τη σύγχρονη συλλογή ετικετών. Διαβάστε αυτά τα μεταδεδομένα με το [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Η μέθοδος αναλύει τις κληρονομικές προσαρμοσμένες ιδιότητες και επιστρέφει έναν πίνακα αντικειμένων [ISensitivityLabel](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/).

Για να μεταφέρετε τα μεταδεδομένα, προσθέστε κάθε επιστρεφόμενη ετικέτα στη σύγχρονη [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/) μέσω του [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Επειδή η προσθήκη διπλού αναγνωριστικού ετικέτας προκαλεί εξαίρεση, το παράδειγμα ελέγχει τη συλλογή προορισμού πριν αντιγράψει κάθε ετικέτα. Μπορείτε να προσθέσετε περαιτέρω επικύρωση για να επιβεβαιώσετε ότι κάθε κληρονομική ετικέτα εξακολουθεί να υπάρχει στην τρέχουσα πολιτική Purview.

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

Η μεταφορά αντιγράφει τα αναλυμένα αντικείμενα ετικετών στη σύγχρονη συλλογή. Δεν απαιτεί εκκαθάριση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου, έτσι τα μη σχετιζόμενα μεταδεδομένα παραμένουν αμετάβλητα. Χρησιμοποιήστε το [IPresentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/) για να γράψετε τα σύγχρονα μεταδεδομένα ετικετών σε αρχείο PPTX.

## **Συχνές Ερωτήσεις**

**Δημιουργεί η προσθήκη τύπου ενδείξεων περιεχομένου ορατή κεφαλίδα, υποσέλιδο ή υδατογράφημα στις διαφάνειες;**

Όχι. Οι τιμές που προστίθενται μέσω του καταλόγου που επιστρέφει το [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) περιγράφουν τις ενδείξεις που συνδέονται με την ετικέτα ευαισθησίας. Δεν δημιουργούν ορατό κείμενο ή σχήματα στην παρουσίαση. Προσθέστε το αντίστοιχο περιεχόμενο διαφάνειας ξεχωριστά εάν η ροή εργασίας σας πρέπει να αποδώσει αυτές τις ενδείξεις.

**Ποια είναι η διαφορά μεταξύ του να σημαδέψετε μια ετικέτα ως αφαιρεμένη και του να τη διαγράψετε από τη συλλογή;**

Καλώντας το [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) με `true` διατηρείτε την καταχώρηση της ετικέτας και καταγράφετε την κατάσταση αφαίρεσής της. Καλώντας το [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) διαγράφεται η καταχώρηση από τη σύγχρονη συλλογή. Επιλέξτε τη λειτουργία που ταιριάζει στις απαιτήσεις διατήρησης μεταδεδομένων του οργανισμού σας.

**Μπορεί μια παρουσίαση να περιέχει τόσο κληρονομικά μεταδεδομένα MIP όσο και σύγχρονες ετικέτες ευαισθησίας;**

Ναι. Οι κληρονομικές ετικέτες μπορούν να παραμείνουν σε προσαρμοσμένες ιδιότητες εγγράφου, ενώ οι σύγχρονες ετικέτες είναι διαθέσιμες μέσω του [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Χρησιμοποιήστε το [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) για να διαβάσετε τα κληρονομικά μεταδεδομένα και να μεταφέρετε μόνο τις έγκυρες ετικέτες που δεν υπάρχουν ήδη στη σύγχρονη συλλογή.

**Τι συμβαίνει όταν μια ετικέτα με το ίδιο αναγνωριστικό προστίθεται περισσότερες από μία φορές;**

Το [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) προκαλεί εξαίρεση όταν η συλλογή περιέχει ήδη μια ετικέτα με το ίδιο αναγνωριστικό. Ελέγξτε τις υπάρχουσες τιμές που επιστρέφει το [ISensitivityLabel.getId](https://reference.aspose.com/slides/el/java/com.aspose.slides/isensitivitylabel/#getId--) πριν προσθέσετε ή μεταφέρετε ετικέτες.

**Ποια μορφή εξόδου πρέπει να χρησιμοποιηθεί για να διατηρηθούν οι ενημερωμένες ετικέτες ευαισθησίας;**

Αποθηκεύστε την παρουσίαση ως PPTX καλώντας το [IPresentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/), όπως φαίνεται στα παραδείγματα παραπάνω.