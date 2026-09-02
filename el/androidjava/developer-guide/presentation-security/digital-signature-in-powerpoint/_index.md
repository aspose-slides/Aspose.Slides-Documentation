---
title: Προσθήκη Ψηφιακών Υπογραφών σε Παρουσιάσεις σε Android
linktitle: Ψηφιακή Υπογραφή
type: docs
weight: 10
url: /el/androidjava/digital-signature-in-powerpoint/
keywords:
- ψηφιακή υπογραφή
- ψηφιακό πιστοποιητικό
- αρχή πιστοποιήσεων
- PFX πιστοποιητικό
- PKCS#12
- επικύρωση υπογραφής
- PowerPoint
- PPTX
- ασφάλεια παρουσίασης
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να υπογράφετε υπάρχουσες παρουσιάσεις PPTX με πιστοποιητικά PFX και να χρησιμοποιείτε το Aspose.Slides για Android μέσω Java για την επικύρωση ή την αφαίρεση ψηφιακών υπογραφών."
---
## **Επισκόπηση**

Μια ψηφιακή υπογραφή βοηθά τον παραλήπτη να καθορίσει ποιος υπέγραψε μια παρουσίαση και εάν το υπογεγραμμένο περιεχόμενο έχει αλλάξει. Τρία συναφή θέματα ασφαλείας είναι σημαντικά εδώ:

- Ένα **digital certificate** είναι ένα ηλεκτρονικό διαπιστευτήριο που συνδέει μια ταυτότητα με ένα δημόσιο κλειδί. Μια αξιόπιστη αρχή πιστοποιήσεων (CA) μπορεί να εκδώσει πιστοποιητικό, ή ένας οργανισμός μπορεί να χρησιμοποιήσει ένα αυτο-υπογεγραμμένο πιστοποιητικό για εσωτερικές διαδικασίες.
- Μια **digital signature** δημιουργείται από το περιεχόμενο της παρουσίασης και το ιδιωτικό κλειδί του κατόχου του πιστοποιητικού. Το δημόσιο κλειδί του πιστοποιητικού μπορεί στη συνέχεια να χρησιμοποιηθεί για την επαλήθευση της υπογραφής. Μια υπογραφή παρέχει απόδειξη προέλευσης και ακεραιότητας· δεν κρυπτογραφεί την παρουσίαση.
- **Password protection** ελέγχει αν ένας χρήστης μπορεί να ανοίξει ή να τροποποιήσει μια παρουσίαση. Είναι ξεχωριστή από την ψηφιακή υπογραφή και περιγράφεται στις [Password-Protected Presentations](/androidjava/password-protected-presentation/).

Το PowerPoint παρέχει την εντολή **Add a Digital Signature** στο **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Μετά το άνοιγμα μιας υπογεγραμμένης παρουσίασης, το PowerPoint μπορεί να εμφανίσει μια ειδοποίηση κατάστασης υπογραφής.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Το Aspose.Slides εκθέτει τις υπογραφές μέσω [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--), που επιστρέφει μια [IDigitalSignatureCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idigitalsignaturecollection/) των οποίων τα στοιχεία υλοποιούν την [IDigitalSignature](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idigitalsignature/). Μια παρουσίαση μπορεί να περιέχει πολλαπλές υπογραφές.

## **Κατανόηση Πιστοποιητικών PFX και Κωδικών Πρόσβασης**

Ένα αρχείο PFX, επίσης γνωστό ως αρχείο PKCS#12 και συνήθως με επέκταση `.pfx` ή `.p12`, μπορεί να περιέχει ένα πιστοποιητικό X.509, το ιδιωτικό του κλειδί και την αλυσίδα πιστοποιητικών. Το ιδιωτικό κλειδί είναι αυτό που επιτρέπει στον κάτοχο να δημιουργήσει μια υπογραφή. Ένα πιστοποιητικό χωρίς προσβάσιμο ιδιωτικό κλειδί δεν μπορεί να χρησιμοποιηθεί για την υπογραφή μιας παρουσίασης.

Ο κωδικός PFX προστατεύει το πακέτο του πιστοποιητικού και το ιδιωτικό κλειδί. **Δεν** είναι κωδικός για το άνοιγμα ή την επεξεργασία της παρουσίασης. Μην καταχωρείτε αρχεία PFX ή τους κωδικούς τους σε σύστημα ελέγχου πηγής. Σε παραγωγικό περιβάλλον, περιορίστε την πρόσβαση στο αρχείο πιστοποιητικού και αποκτήστε τον κωδικό του από αποθήκη μυστικών ή άλλη προστατευμένη πηγή ρυθμίσεων. Τα παραδείγματα παρακάτω χρησιμοποιούν μια μεταβλητή περιβάλλοντος μόνο για να αποφύγουν την ενσωμάτωση του κωδικού στον κώδικα.

## **Προσθήκη Ψηφιακής Υπογραφής σε Παρουσίαση**

Για να υπογράψετε μια πραγματική παρουσίαση, φορτώστε ένα υπάρχον αρχείο PPTX, δημιουργήστε μια [DigitalSignature](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/digitalsignature/) από ένα πιστοποιητικό PFX και τον κωδικό του, προσθέστε την υπογραφή στη συλλογή της παρουσίασης και αποθηκεύστε σε αρχείο PPTX.

```java
import com.aspose.slides.*;

String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αποθήκευση του αποτελέσματος με νέο όνομα διατηρεί το μη υπογεγραμμένο αρχικό αρχείο. Η τιμή που ορίζεται με τη μέθοδο [IDigitalSignature.setComments](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) περιγράφει τον σκοπό της υπογραφής· δεν αποτελεί έλεγχο ασφαλείας.

## **Επικύρωση Ψηφιακών Υπογραφών**

Όταν φορτώνετε ένα υπογεγραμμένο αρχείο PPTX, εξετάστε κάθε στοιχείο που επιστρέφεται από το [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--). Η μέθοδος [IDigitalSignature.isValid](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idigitalsignature/#isValid--) υποδεικνύει αν η ενσωματωμένη υπογραφή είναι έγκυρη για το τρέχον περιεχόμενο της παρουσίασης.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Ένα μη έγκυρο αποτέλεσμα συνήθως σημαίνει ότι το υπογεγραμμένο περιεχόμενο ή τα δεδομένα της υπογραφής άλλαξαν μετά την υπογραφή, ή ότι το αρχείο είναι κατεστραμμένο. Η αφαίρεση όλων των υπογραφών παράγει μια μη υπογεγραμμένη παρουσίαση, επομένως ο έλεγχος μόνο της εγκυρότητας των στοιχείων δεν επαρκεί: μια ροή εργασίας ευαίσθητη στην ασφάλεια πρέπει επίσης να επαληθεύει ότι υπάρχει ο αναμενόμενος αριθμός υπογραφών και οι αναμενόμενες ταυτότητες υπογραφούντων.

Αυτό το αποτέλεσμα εγκυρότητας δεν πρέπει να θεωρείται απόλυτη απόφαση εμπιστοσύνης στο πιστοποιητικό. Ανάλογα με την πολιτική ασφαλείας σας, η εφαρμογή σας μπορεί επίσης να χρειαστεί να κατασκευάσει και να επικυρώσει την αλυσίδα πιστοποιητικών X.509, να ελέγξει τις ημερομηνίες ισχύος και την κατάσταση ανάκλησης του πιστοποιητικού, να επιβεβαιώσει το αναμενόμενο θέμα ή αποτύπωμα, να ελέγξει τη χρήση του κλειδιού και να αξιολογήσει ένα αξιόπιστο χρονικό σήμα. Η τιμή που επιστρέφει η μέθοδος [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) από μόνη της δεν αποτελεί απόδειξη από αξιόπιστη αρχή χρονικού σήματος.

## **Αφαίρεση Ψηφιακών Υπογραφών**

Η αφαίρεση υπογραφών αλλάζει την κατάσταση ασφαλείας της παρουσίασης. Το παρακάτω παράδειγμα φορτώνει ένα υπογεγραμμένο αρχείο PPTX, αφαιρεί όλες τις υπογραφές με τη μέθοδο [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--), και αποθηκεύει ένα μη υπογεγραμμένο αντίγραφό του.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να αφαιρέσετε μόνο μία υπογραφή, καλέστε τη μέθοδο [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) με τον μηδενικό δείκτη της. Αποθηκεύστε σε νέο αρχείο εκτός αν η αντικατάσταση του υπογεγραμμένου αρχικού είναι ρητό μέρος της ροής εργασίας σας.

## **Επεξεργασία και Σκέψεις για Μορφές**

- Μια υπογραφή δεν κάνει την παρουσίαση μόνο για ανάγνωση. Οι χρήστες και οι εφαρμογές μπορούν ακόμη να επεξεργαστούν το αρχείο, αλλά οι αλλαγές στο υπογεγραμμένο περιεχόμενο συνήθως ακυρώνουν την υπάρχουσα υπογραφή.
- Ολοκληρώστε όλες τις προγραμματισμένες επεξεργασίες πριν την υπογραφή. Αν πρέπει να αλλάξετε την παρουσίαση, αποθηκεύστε την αναθεωρημένη έκδοση και υπογράψτε ξανά.
- Διατηρήστε την τελική έξοδο σε μορφή PPTX. Η μετατροπή μιας υπογεγραμμένης παρουσίασης σε άλλη μορφή δεν μεταφέρει την αρχική υπογραφή PPTX ως έγκυρη υπογραφή για το μετατρεπόμενο αρχείο.
- Θεωρήστε το ιδιωτικό κλειδί του πιστοποιητικού ως ευαίσθητο. Όποιος αποκτήσει το ιδιωτικό κλειδί και τον κωδικό του μπορεί να δημιουργήσει υπογραφές που φαίνονται να προέρχονται από αυτόν τον κάτοχο του πιστοποιητικού.
- Διατηρήστε το μη υπογεγραμμένο αρχικό ή κάποιο άλλο ελεγχόμενο αντίγραφο όταν η πολιτική διατήρησης εγγράφων το απαιτεί.

## **Συχνές Ερωτήσεις**

**Η ψηφιακή υπογραφή κρυπτογραφεί την παρουσίαση;**

Όχι. Μια ψηφιακή υπογραφή παρέχει απόδειξη προέλευσης και ακεραιότητας, αλλά το περιεχόμενο της παρουσίασης παραμένει αναγνώσιμο εκτός αν εφαρμοστεί ξεχωριστή κρυπτογράφηση. Χρησιμοποιήστε την [password protection](/androidjava/password-protected-presentation/) όταν η πρόσβαση στο περιεχόμενο πρέπει να περιοριστεί.

**Ο κωδικός PFX είναι ίδιος με τον κωδικό παρουσίασης;**

Όχι. Ο κωδικός PFX ξεκλειδώνει το ιδιωτικό κλειδί που αποθηκεύεται στο πακέτο του πιστοποιητικού. Δεν ελέγχει ποιος μπορεί να ανοίξει ή να επεξεργαστεί το αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω αυτο-υπογεγραμμένο πιστοποιητικό;**

Τεχνικά, ένα αυτο-υπογεγραμμένο πιστοποιητικό μπορεί να χρησιμοποιηθεί όταν περιλαμβάνει προσβάσιμο ιδιωτικό κλειδί. Οι παραλήπτες δεν θα το εμπιστευτούν αυτόματα, εκτός αν το πιστοποιητικό προστεθεί ρητά στο αξιόπιστο περιβάλλον τους. Οι δημόσιες ή δια-οργανωτικές ροές εργασίας συνήθως χρησιμοποιούν πιστοποιητικό που εκδόθηκε από αξιόπιστη CA.

**Τι κάνει μια υπογραφή μη έγκυρη;**

Η αλλαγή του υπογεγραμμένου περιεχομένου της παρουσίασης ή των δεδομένων της υπογραφής μετά την υπογραφή μπορεί να την ακυρώσει. Η κατεστραμμένη κατάσταση του αρχείου μπορεί επίσης να προκαλέσει αποτυχία επικύρωσης. Αν αφαιρεθούν όλες οι υπογραφές, η παρουσίαση είναι μη υπογεγραμμένη αντί για αρχείο με μη έγκυρη υπογραφή.

**Μια έγκυρη υπογραφή σημαίνει ότι πρέπει να εμπιστευθώ τον υπογράφοντα;**

Όχι από μόνη της. Η ακεραιότητα της υπογραφής και η εμπιστοσύνη στον υπογράφοντα είναι ξεχωριστές αποφάσεις. Μια πολιτική παραγωγικής επικύρωσης θα πρέπει επίσης να ελέγχει την αλυσίδα πιστοποιητικών, την περίοδο ισχύος, την κατάσταση ανάκλησης, την αναμενόμενη ταυτότητα, τη χρήση του κλειδιού και τυχόν απαιτήσεις αξιόπιστου χρονικού σήματος.

**Τι συμβαίνει όταν λήξει το πιστοποιητικό;**

Η λήξη του πιστοποιητικού δεν αλλάζει τα byte της παρουσίασης, αλλά επηρεάζει την αξιολόγηση εμπιστοσύνης του πιστοποιητικού. Αν μια υπογραφή παραμένει αποδεκτή εξαρτάται από την πολιτική σας και από το εάν ένα έγκυρο αξιόπιστο χρονικό σήμα αποδεικνύει ότι η υπογραφή έγινε ενώ το πιστοποιητικό ήταν έγκυρο. Μην βασίζεστε μόνο στην εμφανιζόμενη ώρα υπογραφής ως αξιόπιστο χρονικό σήμα.

**Μπορεί μια υπογεγραμμένη παρουσίαση να επεξεργαστεί ακόμη;**

Ναι. Η υπογραφή δεν κλειδώνει το αρχείο. Η επεξεργασία του υπογεγραμμένου περιεχομένου συνήθως ακυρώνει την υπάρχουσα υπογραφή, οπότε ολοκληρώστε την παρουσίαση πρώτα και υπογράψτε την τελική έκδοση.

**Μπορεί μια παρουσίαση να περιέχει περισσότερες από μία υπογραφές;**

Ναι. Προσθέστε κάθε υπογραφή στη συλλογή που επιστρέφεται από το [IPresentation.getDigitalSignatures] πριν την αποθήκευση. Κατά την επικύρωση, ελέγξτε κάθε υπογραφή και βεβαιωθείτε ότι όλοι οι απαιτούμενοι υπογράφοντες είναι παρόντες.

**Ποιες μορφές παρουσίασης υποστηρίζουν αυτές τις λειτουργίες;**

Το Aspose.Slides υποστηρίζει τις λειτουργίες ψηφιακής υπογραφής που περιγράφονται εδώ μόνο για PPTX. Οι μορφές PPT και OpenDocument παρουσιάσεων δεν υποστηρίζονται από αυτό το API.

**Μπορώ να αφαιρέσω μια υπογραφή χωρίς να επηρεαστούν οι διαφάνειες;**

Ναί. Μπορείτε να αφαιρέσετε μία υπογραφή ή να καθαρίσετε ολόκληρη τη συλλογή και μετά να αποθηκεύσετε την παρουσίαση. Το περιεχόμενο των διαφανειών παραμένει διαθέσιμο, αλλά το αποθηκευμένο αρχείο δεν φέρει πλέον την αποδεικτική υπογραφή.