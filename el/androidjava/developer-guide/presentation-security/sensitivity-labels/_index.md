---
title: Διαχείριση ετικετών ευαισθησίας σε παρουσιάσεις PowerPoint σε Android
linktitle: Ετικέτες ευαισθησίας
type: docs
weight: 50
url: /el/androidjava/sensitivity-labels/
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
- Android
- Java
- Aspose.Slides
description: "Διαβάστε, προσθέστε, ενημερώστε, αφαιρέστε και μεταφέρετε τις ετικέτες ευαισθησίας του Microsoft Purview σε παρουσιάσεις PowerPoint PPTX με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Οι ετικέτες ευαισθησίας του Microsoft Purview βοηθούν τους οργανισμούς να ταξινομούν και να διαχειρίζονται έγγραφα. Κατά την αυτόματη επεξεργασία παρουσιάσεων, μια εφαρμογή μπορεί να χρειαστεί να διατηρήσει μια υπάρχουσα ετικέτα, να εφαρμόσει μια ετικέτα που επιλέχθηκε από πολιτική, να ενημερώσει την κατάσταση της ή να μεταφέρει μεταδεδομένα ετικέτας που γράφτηκαν από παλαιότερη ροή εργασίας Microsoft Information Protection (MIP).

Το Aspose.Slides for Android μέσω Java εκθέτει σύγχρονα μεταδεδομένα ετικετών ευαισθησίας μέσω της μεθόδου [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Αυτή η μέθοδος επιστρέφει ένα αντικείμενο [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/) που μπορεί να εξεταστεί και να τροποποιηθεί πριν η παρουσίαση αποθηκευτεί ως PPTX.

{{% alert color="info" title="Σημείωση" %}}
Τα αναγνωριστικά ετικετών ευαισθησίας και οι πληροφορίες πολιτικής ορίζονται από τη διαμόρφωση του Microsoft Purview. Επαληθεύστε τη διαθεσιμότητα των ετικετών και τις απαιτήσεις πολιτικής στο περιβάλλον σας πριν προσθέσετε ή μεταφέρετε μεταδεδομένα. Οι τιμές της μεθόδου [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) περιγράφουν τις σήμανσεις περιεχομένου που συνδέονται με μια ετικέτα· δεν προσθέτουν οπτικό κείμενο ή σχήματα στις διαφάνειες από μόνες τους.
{{% /alert %}}

## **Κατανόηση Ιδιοτήτων Ετικέτας Ευαισθησίας**

Κάθε [ISensitivityLabel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/) περιέχει τα ακόλουθα μεταδεδομένα:

| Μέθοδοι | Σκοπός |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getId--) and [ISensitivityLabel.setId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Ανάγνωση ή ορισμός του αναγνωριστικού ετικέτας ευαισθησίας στην πολιτική Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) and [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Ανάγνωση ή ορισμός του site που συνδέεται με την πολιτική ετικέτας. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) and [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Ανάγνωση ή ορισμός του εάν η ετικέτα είναι ενεργή. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) and [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Ανάγνωση ή ορισμός του εάν η ετικέτα έχει αφαιρεθεί. Ορίστε την τιμή σε `true` όταν η κατάσταση αφαίρεσης πρέπει να διατηρηθεί στα μεταδεδομένα. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) and [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Ανάγνωση ή ορισμός του εάν η ετικέτα εφαρμόστηκε αυτόματα ή μέσω απόφασης χρήστη. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Ανάγνωση των τύπων σήμανσης περιεχομένου που συνδέονται με την ετικέτα. |

Η κλάση [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) ορίζει πώς ανατέθηκε μια ετικέτα:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια προεπιλεγμένη ή αυτόματα εφαρμοσμένη ετικέτα.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια ετικέτα που εφαρμόστηκε μέσω απόφασης χρήστη, συμπεριλαμβανομένων των χειροκίνητα εφαρμοσμένων, προτεινόμενων και υποχρεωτικών ετικετών.

Η κλάση [SensitivityLabelContentType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) ορίζει τη σήμανση που συνδέεται με μια ετικέτα:

| Τιμή | Περιγραφή |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Η ετικέτα εφαρμόστηκε από προεπιλογή ή αυτόματα. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση περιεχομένου κεφαλίδας συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση περιεχομένου υποσέλιδου συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Η σήμανση υδατογραφήματος συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Η κρυπτογράφηση προστασίας συνδέεται με την ετικέτα. |

Πολλοί τύποι σήμανσης μπορούν να συνδέονται με μία ετικέτα.

## **Λίστα Υπάρχουσων Ετικετών Ευαισθησίας**

Αναγνώστε τη σύγχρονη συλλογή ετικετών από τη μέθοδο [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) και επαναλάβετε την. Το παρακάτω παράδειγμα απαριθμεί κάθε ιδιότητα και σήμανση περιεχομένου που αποθηκεύεται για κάθε ετικέτα:

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

Χρησιμοποιήστε τη μέθοδο [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) με το αναγνωριστικό ετικέτας, το αναγνωριστικό site, την κατάσταση ενεργοποίησης και τη μέθοδο ανάθεσης. Αφού η μέθοδος επιστρέψει τη νέα [ISensitivityLabel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/), προσθέστε τις απαιτούμενες τιμές σήμανσης μέσω της λίστας που επιστρέφει η [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Το παρακάτω παράδειγμα προσθέτει μια χειροκίνητα επιλεγμένη ετικέτα που συνδέεται με σήμανση υποσέλιδου και υδατογραφήματος και στη συνέχεια αποθηκεύει το αποτέλεσμα ως PPTX:

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

Οι τιμές του [ISensitivityLabel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/) είναι αναγνώσιμες/εγγράψιμες, εκτός από τη λίστα που επιστρέφεται από τη [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) η οποία τροποποιείται μέσω των λειτουργιών της λίστας. Αφού εντοπίσετε την απαιτούμενη ετικέτα, μπορείτε να ενημερώσετε το αναγνωριστικό, το αναγνωριστικό site, την κατάσταση ενεργοποίησης, τη μέθοδο ανάθεσης, την κατάσταση αφαίρεσης και τους τύπους σήμανσης περιεχομένου. Αποθηκεύστε την παρουσίαση για να διατηρηθούν οι αλλαγές.

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

Για να διατηρηθεί το γεγονός ότι μια ετικέτα αφαιρέθηκε, βρείτε την ετικέτα και καλέστε τη μέθοδο [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) με `true`. Αυτό διατηρεί την καταχώρηση της ετικέτας ενώ καταγράφει την κατάσταση αφαίρεσης. Εάν αντί αυτού χρειάζεται να διαγράψετε μια καταχώρηση από τη σύγχρονη συλλογή, χρησιμοποιήστε τη μέθοδο [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); χρησιμοποιήστε τη μέθοδο [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) για να διαγράψετε όλες τις καταχωρήσεις.

Το παρακάτω παράδειγμα σημαίνει μια συγκεκριμένη ετικέτα ως αφαιρεμένη και αποθηκεύει την ενημερωμένη παρουσίαση:

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

## **Ανάγνωση και Μεταφορά Κληρονομικών Ετικετών MIP**

Οι παλαιότερες ροές εργασίας βάσει MIP μπορούν να αποθηκεύουν μεταδεδομένα ετικετών ευαισθησίας σε προσαρμοσμένες ιδιότητες εγγράφου αντί για τη σύγχρονη συλλογή ετικετών. Διαβάστε αυτά τα μεταδεδομένα με τη μέθοδο [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Η μέθοδος αναλύει τις κληρονομικές προσαρμοσμένες ιδιότητες και επιστρέφει έναν πίνακα αντικειμένων [ISensitivityLabel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/).

Για τη μεταφορά των μεταδεδομένων, προσθέστε κάθε επιστρεφόμενη ετικέτα στη σύγχρονη [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/) μέσω της μεθόδου [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Επειδή η προσθήκη διπλότυπου αναγνωριστικού ετικέτας προκαλεί εξαίρεση, το παράδειγμα ελέγχει τη συλλογή προορισμού πριν αντιγράψει κάθε ετικέτα. Μπορείτε να προσθέσετε επιπλέον επικύρωση για να επιβεβαιώσετε ότι κάθε κληρονομική ετικέτα εξακολουθεί να υπάρχει στην τρέχουσα πολιτική Purview.

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

Η μεταφορά αντιγράφει τα αναλυμένα αντικείμενα ετικετών στη σύγχρονη συλλογή. Δεν απαιτεί εκκαθάριση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου, ώστε τα ανεξάρτητα μεταδεδομένα του εγγράφου να παραμείνουν άθικτα. Χρησιμοποιήστε τη μέθοδο [IPresentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/) για να γράψετε τα σύγχρονα μεταδεδομένα ετικετών σε αρχείο PPTX.

## **Συχνές Ερωτήσεις**

**Δημιουργεί η προσθήκη τύπου σήμανσης περιεχομένου ορατή κεφαλίδα, υποσέλιδο ή υδατογράφημα στις διαφάνειες;**

Όχι. Οι τιμές που προστίθενται μέσω της λίστας που επιστρέφει η [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) περιγράφουν τις σήμανσεις που συνδέονται με την ετικέτα ευαισθησίας. Δεν δημιουργούν ορατό κείμενο ή σχήματα στην παρουσίαση. Προσθέστε το αντίστοιχο περιεχόμενο διαφάνειας ξεχωριστά εάν η ροή εργασίας σας πρέπει να τα αποδώσει.

**Ποια είναι η διαφορά μεταξύ σήμανσης μιας ετικέτας ως αφαιρεμένης και διαγραφής της από τη συλλογή;**

Η κλήση της μεθόδου [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) με `true` διατηρεί την καταχώρηση της ετικέτας και καταγράφει την κατάσταση αφαίρεσης. Η κλήση της μεθόδου [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) διαγράφει την καταχώρηση από τη σύγχρονη συλλογή. Επιλέξτε τη λειτουργία που ταιριάζει στις απαιτήσεις διατήρησης μεταδεδομένων του οργανισμού σας.

**Μπορεί μια παρουσίαση να περιέχει τόσο κληρονομικά μεταδεδομένα MIP όσο και σύγχρονες ετικέτες ευαισθησίας;**

Ναι. Οι κληρονομικές ετικέτες μπορούν να παραμείνουν σε προσαρμοσμένες ιδιότητες εγγράφου, ενώ οι σύγχρονες ετικέτες είναι διαθέσιμες μέσω της μεθόδου [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Χρησιμοποιήστε τη μέθοδο [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) για να διαβάσετε τα κληρονομικά μεταδεδομένα και να μεταφέρετε μόνο τις έγκυρες ετικέτες που δεν υπάρχουν ήδη στη σύγχρονη συλλογή.

**Τι συμβαίνει όταν μια ετικέτα με το ίδιο αναγνωριστικό προστίθεται περισσότερες από μία φορές;**

Η μέθοδος [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) προκαλεί εξαίρεση όταν η συλλογή περιέχει ήδη μια ετικέτα με το ίδιο αναγνωριστικό. Ελέγξτε τις υπάρχουσες τιμές που επιστρέφονται από τη μέθοδο [ISensitivityLabel.getId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/isensitivitylabel/#getId--) πριν προσθέσετε ή μεταφέρετε ετικέτες.

**Ποια μορφή εξόδου πρέπει να χρησιμοποιηθεί για τη διασφάλιση των ενημερωμένων ετικετών ευαισθησίας;**

Αποθηκεύστε την παρουσίαση ως PPTX καλώντας τη μέθοδο [IPresentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/), όπως φαίνεται στα παραπάνω παραδείγματα.