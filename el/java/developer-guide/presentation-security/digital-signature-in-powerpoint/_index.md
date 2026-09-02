---
title: Προσθήκη Ψηφιακών Υπογραφών σε Παρουσιάσεις σε Java
linktitle: Ψηφιακή Υπογραφή
type: docs
weight: 10
url: /el/java/digital-signature-in-powerpoint/
keywords:
- ψηφιακή υπογραφή
- ψηφιακό πιστοποιητικό
- αρχή πιστοποίησης
- πιστοποιητικό PFX
- PKCS#12
- επικύρωση υπογραφής
- PowerPoint
- PPTX
- ασφάλεια παρουσίασης
- Java
- Aspose.Slides
description: "Μάθετε πώς να υπογράφετε υπάρχουσες παρουσιάσεις PPTX με πιστοποιητικά PFX και να χρησιμοποιείτε το Aspose.Slides για Java για την επικύρωση ή την αφαίρεση ψηφιακών υπογραφών."
---
## **Επισκόπηση**

Μια ψηφιακή υπογραφή βοηθά τον παραλήπτη να καθορίσει ποιος υπέγραψε μια παρουσίαση και εάν το υπογεγραμμένο περιεχόμενο έχει αλλάξει. Τρία συναφή ζητήματα ασφαλείας είναι σημαντικά εδώ:

- Ένα **ψηφιακό πιστοποιητικό** είναι ένα ηλεκτρονικό διαπιστευτήριο που συνδέει μια ταυτότητα με ένα δημόσιο κλειδί. Ένας αξιόπιστος οργανισμός έκδοσης πιστοποιητικών (CA) μπορεί να εκδώσει ένα πιστοποιητικό, ή ένας οργανισμός μπορεί να χρησιμοποιήσει ένα αυτοπ υπογεγραμμένο πιστοποιητικό για εσωτερικές ροές εργασίας.
- Μια **ψηφιακή υπογραφή** δημιουργείται από το περιεχόμενο της παρουσίασης και το ιδιωτικό κλειδί του κατόχου του πιστοποιητικού. Το δημόσιο κλειδί του πιστοποιητικού μπορεί στη συνέχεια να χρησιμοποιηθεί για την επαλήθευση της υπογραφής. Μια υπογραφή παρέχει αποδείξεις προέλευσης και ακεραιότητας· δεν κρυπτογραφεί την παρουσίαση.
- **Προστασία με κωδικό** ελέγχει αν ένας χρήστης μπορεί να ανοίξει ή να τροποποιήσει μια παρουσίαση. Είναι ξεχωριστή από την ψηφιακή υπογραφή και περιγράφεται στα [Password-Protected Presentations](/java/password-protected-presentation/).

Το PowerPoint παρέχει την εντολή **Add a Digital Signature** στο **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Αφού ανοίξει μια υπογεγραμμένη παρουσίαση, το PowerPoint μπορεί να εμφανίσει μια ειδοποίηση κατάστασης υπογραφής.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Η Aspose.Slides εκθέτει υπογραφές μέσω του [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), το οποίο επιστρέφει ένα [IDigitalSignatureCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/idigitalsignaturecollection/) των οποίων τα στοιχεία υλοποιούν το [IDigitalSignature](https://reference.aspose.com/slides/el/java/com.aspose.slides/idigitalsignature/). Μια παρουσίαση μπορεί να περιέχει πολλαπλές υπογραφές.

## **Κατανόηση Πιστοποιητικών PFX και Κωδικών Πρόσβασης**

Ένα αρχείο PFX, γνωστό επίσης ως αρχείο PKCS#12 και συνήθως με κατάληξη `.pfx` ή `.p12`, μπορεί να περιέχει ένα πιστοποιητικό X.509, το ιδιωτικό του κλειδί και την αλυσίδα πιστοποιητικών. Το ιδιωτικό κλειδί είναι αυτό που επιτρέπει στον κάτοχο να δημιουργήσει μια υπογραφή. Ένα πιστοποιητικό χωρίς προσβάσιμο ιδιωτικό κλειδί δεν μπορεί να χρησιμοποιηθεί για την υπογραφή μιας παρουσίασης.

Ο κωδικός πρόσβασης PFX προστατεύει το πακέτο του πιστοποιητικού και το ιδιωτικό κλειδί. **Δεν** είναι κωδικός πρόσβασης για το άνοιγμα ή την επεξεργασία της παρουσίασης. Μην καταχωρείτε αρχεία PFX ή τους κωδικούς τους σε σύστημα ελέγχου κώδικα. Σε παραγωγή, περιορίστε την πρόσβαση στο αρχείο πιστοποιητικού και λάβετε τον κωδικό πρόσβασης από ένα ασφαλές αποθετήριο ή άλλη προστατευμένη πηγή διαμόρφωσης. Τα παραδείγματα παρακάτω χρησιμοποιούν μεταβλητή περιβάλλοντος μόνο για να αποφύγουν την ενσωμάτωση του κωδικού στο κώδικα.

## **Προσθήκη Ψηφιακής Υπογραφής σε Παρουσίαση**

Για να υπογράψετε μια πραγματική ροή εργασίας παρουσίασης, φορτώστε ένα υπάρχον αρχείο PPTX, δημιουργήστε ένα [DigitalSignature](https://reference.aspose.com/slides/el/java/com.aspose.slides/digitalsignature/) από ένα πιστοποιητικό PFX και τον κωδικό του, προσθέστε την υπογραφή στη συλλογή της παρουσίασης και αποθηκεύστε το σε αρχείο PPTX.

```java
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

Η αποθήκευση του αποτελέσματος με νέο όνομα διατηρεί το αρχείο πηγής χωρίς υπογραφή. Η τιμή που ορίζεται από το [IDigitalSignature.setComments](https://reference.aspose.com/slides/el/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) περιγράφει το σκοπό της υπογραφής· δεν αποτελεί μέτρο ασφαλείας.

## **Επικύρωση Ψηφιακών Υπογραφών**

Όταν φορτώνετε ένα υπογεγραμμένο αρχείο PPTX, ελέγξτε κάθε στοιχείο που επιστρέφεται από το [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). Η μέθοδος [IDigitalSignature.isValid](https://reference.aspose.com/slides/el/java/com.aspose.slides/idigitalsignature/#isValid--) υποδεικνύει αν η ενσωματωμένη υπογραφή είναι έγκυρη για το τρέχον περιεχόμενο της παρουσίασης.

```java
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

Ένα μη έγκυρο αποτέλεσμα συνήθως σημαίνει ότι το υπογεγραμμένο περιεχόμενο ή τα δεδομένα της υπογραφής άλλαξαν μετά την υπογραφή, ή ότι το αρχείο είναι κατεστραμμένο. Η αφαίρεση όλων των υπογραφών παράγει μια παρουσίαση χωρίς υπογραφή, επομένως ο έλεγχος μόνο της εγκυρότητας των στοιχείων δεν είναι επαρκής: μια ροή εργασίας με ευαισθησία ασφαλείας πρέπει επίσης να επαληθεύει ότι υπάρχει ο αναμενόμενος αριθμός υπογραφών και οι αναμενόμενες ταυτότητες υπογράφοντων.

Αυτό το αποτέλεσμα εγκυρότητας δεν πρέπει να θεωρείται πλήρης απόφαση εμπιστοσύνης πιστοποιητικού. Ανάλογα με την πολιτική ασφαλείας σας, η εφαρμογή σας ίσως χρειάζεται επίσης να δημιουργήσει και να επικυρώσει την αλυσίδα πιστοποιητικών X.509, να ελέγξει τις ημερομηνίες ισχύος και την κατάσταση ανάκλησης του πιστοποιητικού, να επιβεβαιώσει το αναμενόμενο θέμα ή αποτύπωμα, να επαληθεύσει τη χρήση κλειδιού και να αξιολογήσει ένα αξιόπιστο χρονικό σήμα. Η τιμή του [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/el/java/com.aspose.slides/idigitalsignature/#getSignTime--) από μόνη της δεν αποτελεί απόδειξη από αξιόπιστη αρχή χρονικού σήματος.

## **Αφαίρεση Ψηφιακών Υπογραφών**

Η αφαίρεση υπογραφών αλλάζει την κατάσταση ασφαλείας της παρουσίασης. Το παρακάτω παράδειγμα φορτώνει ένα υπογεγραμμένο αρχείο PPTX, αφαιρεί όλες τις υπογραφές με το [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/idigitalsignaturecollection/#clear--), και αποθηκεύει ένα αντίγραφο χωρίς υπογραφή.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να αφαιρέσετε μόνο μια υπογραφή, καλέστε το [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/el/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) με το μηδενικό του δείκτη. Αποθηκεύστε σε νέο αρχείο εκτός εάν η αντικατάσταση του υπογεγραμμένου αρχικού αποτελεί σαφή μέρος της ροής εργασίας σας.

## **Επεξεργασία και Σκέψεις για τη Μορφή**

- Μια υπογραφή δεν καθιστά την παρουσίαση μόνο για ανάγνωση. Οι χρήστες και οι εφαρμογές μπορούν ακόμη να επεξεργαστούν το αρχείο, αλλά αλλαγές στο υπογεγραμμένο περιεχόμενο συνήθως ακυρώνουν την υπάρχουσα υπογραφή.
- Ολοκληρώστε όλες τις προτιθέμενες επεξεργασίες πριν υπογράψετε. Εάν πρέπει να αλλάξει μια παρουσίαση, αποθηκεύστε την αναθεωρημένη έκδοση και υπογράψτε ξανά αυτήν την αναθεώρηση.
- Διατηρήστε το τελικό αποτέλεσμα σε μορφή PPTX. Η μετατροπή μιας υπογεγραμμένης παρουσίασης σε άλλη μορφή δεν μεταφέρει την αρχική υπογραφή PPTX ως έγκυρη υπογραφή για το μετατραπέν αρχείο.
- Θεωρήστε το ιδιωτικό κλειδί του πιστοποιητικού ως ευαίσθητο. Όποιος αποκτήσει το ιδιωτικό κλειδί και τον κωδικό του μπορεί να δημιουργήσει υπογραφές που φαίνονται να προέρχονται από τον κάτοχο του πιστοποιητικού.
- Διατηρήστε την πηγή χωρίς υπογραφή ή άλλο ελεγχόμενο αντίγραφο όταν η πολιτική διατήρησης εγγράφων το απαιτεί.

## **Συχνές Ερωτήσεις**

**Κρυπτογραφεί μια ψηφιακή υπογραφή την παρουσίαση;**

Όχι. Μια ψηφιακή υπογραφή παρέχει αποδείξεις για την προέλευση και την ακεραιότητα, αλλά το περιεχόμενο της παρουσίασης παραμένει αναγνώσιμο εκτός εάν εφαρμοστεί ξεχωριστή κρυπτογράφηση. Χρησιμοποιήστε [password protection](/java/password-protected-presentation/) όταν η πρόσβαση στο περιεχόμενο πρέπει να περιοριστεί.

**Είναι ο κωδικός PFX ο ίδιος με τον κωδικό παρουσίασης;**

Όχι. Ο κωδικός PFX ξεκλειδώνει το ιδιωτικό κλειδί που αποθηκεύεται στο πακέτο πιστοποιητικού. Δεν ελέγχει ποιος μπορεί να ανοίξει ή να επεξεργαστεί το αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω αυτοπ υπογεγραμμένο πιστοποιητικό;**

Τεχνικά, ένα αυτοπ υπογεγραμμένο πιστοποιητικό μπορεί να χρησιμοποιηθεί εφόσον περιλαμβάνει προσβάσιμο ιδιωτικό κλειδί. Οι παραλήπτες δεν θα το εμπιστευτούν αυτόματα, εκτός αν το πιστοποιητικό έχει προσθεθεί ρητά στο αξιόπιστο περιβάλλον τους. Οι δημόσιες ή δια-οργανωτικές ροές εργασίας συνήθως χρησιμοποιούν πιστοποιητικό που εκδόθηκε από αξιόπιστο CA.

**Τι κάνει μια υπογραφή μη έγκυρη;**

Η αλλαγή του υπογεγραμμένου περιεχομένου ή των δεδομένων της υπογραφής μετά την υπογραφή μπορεί να ακυρώσει την υπογραφή. Η αλλοίωση του αρχείου μπορεί επίσης να προκαλέσει αποτυχία επικύρωσης. Εάν αφαιρεθούν όλες οι υπογραφές, η παρουσίαση είναι χωρίς υπογραφή αντί για αρχείο με μη έγκυρη υπογραφή.

**Μια έγκυρη υπογραφή σημαίνει ότι πρέπει να εμπιστευτώ τον υπογράφοντα;**

Όχι από μόνη της. Η ακεραιότητα της υπογραφής και η εμπιστοσύνη στον υπογράφοντα είναι ξεχωριστές αποφάσεις. Μια πολιτική παραγωγικής επικύρωσης πρέπει επίσης να ελέγχει την αλυσίδα πιστοποιητικών, την περίοδο ισχύος, την κατάσταση ανάκλησης, την αναμενόμενη ταυτότητα, τη χρήση κλειδιού και τυχόν απαιτήσεις αξιόπιστου χρονικού σήματος.

**Τι συμβαίνει όταν λήξει το πιστοποιητικό;**

Η λήξη του πιστοποιητικού δεν αλλάζει τα byte της παρουσίασης, αλλά επηρεάζει την αξιολόγηση εμπιστοσύνης του πιστοποιητικού. Το αν η υπογραφή παραμένει αποδεκτή εξαρτάται από την πολιτική σας και από το αν υπάρχει έγκυρο αξιόπιστο χρονικό σήμα που αποδεικνύει ότι η υπογραφή έγινε ενώ το πιστοποιητικό ήταν έγκυρο. Μην βασίζεστε μόνο στην εμφανιζόμενη ώρα υπογραφής ως αξιόπιστο χρονικό σήμα.

**Μια υπογεγραμμένη παρουσίαση μπορεί ακόμα να επεξεργαστεί;**

Ναι. Η υπογραφή δεν κλειδώνει το αρχείο. Η επεξεργασία του υπογεγραμμένου περιεχομένου συνήθως κάνει την υπάρχουσα υπογραφή μη έγκυρη, επομένως ολοκληρώστε την παρουσίαση πρώτα και υπογράψτε την τελική αναθεώρηση.

**Μπορεί μια παρουσίαση να περιέχει περισσότερες από μία υπογραφές;**

Ναι. Προσθέστε κάθε υπογραφή στη συλλογή που επιστρέφεται από το [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) πριν αποθηκεύσετε. Κατά την επικύρωση, ελέγξτε κάθε υπογραφή και επιβεβαιώστε ότι όλοι οι απαιτούμενοι υπογράφοντες είναι παρόντες.

**Ποιες μορφές παρουσίασης υποστηρίζουν αυτές τις λειτουργίες;**

Η Aspose.Slides υποστηρίζει τις λειτουργίες ψηφιακής υπογραφής που περιγράφονται εδώ μόνο για PPTX. Οι μορφές PPT και OpenDocument presentation δεν υποστηρίζονται από αυτό το API workflow.

**Μπορώ να αφαιρέσω μια υπογραφή χωρίς να επηρεάσω τις διαφάνειες;**

Ναι. Μπορείτε να αφαιρέσετε μία υπογραφή ή να εκκαθαρίσετε ολόκληρη τη συλλογή και, στη συνέχεια, να αποθηκεύσετε την παρουσίαση. Το περιεχόμενο των διαφανειών παραμένει διαθέσιμο, αλλά το αποθηκευμένο αρχείο δεν φέρει πλέον τα αποδεικτικά της αφαιρεμένης υπογραφής.