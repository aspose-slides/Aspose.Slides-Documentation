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
- επαλήθευση υπογραφής
- PowerPoint
- PPTX
- ασφάλεια παρουσίασης
- Java
- Aspose.Slides
description: "Μάθετε πώς να υπογράφετε υπάρχουσες παρουσιάσεις PPTX με πιστοποιητικά PFX και να χρησιμοποιείτε το Aspose.Slides για Java για την επαλήθευση ή αφαίρεση ψηφιακών υπογραφών."
---
## **Επισκόπηση**

Μια ψηφιακή υπογραφή βοηθά τον παραλήπτη να προσδιορίσει ποιος υπέγραψε μια παρουσίαση και αν το υπογεγραμμένο περιεχόμενο έχει αλλάξει. Τρία συναφή έννοιες ασφαλείας είναι σημαντικές εδώ:

- Ένα **ψηφιακό πιστοποιητικό** είναι ένα ηλεκτρονικό διαπιστευτήριο που συσχετίζει μια ταυτότητα με ένα δημόσιο κλειδί. Μια αξιόπιστη αρχή πιστοποίησης (CA) μπορεί να εκδώσει ένα πιστοποιητικό, ή ένας οργανισμός μπορεί να χρησιμοποιήσει ένα αυτό‑υπογεγραμμένο πιστοποιητικό για εσωτερικές ροές εργασίας.
- Μια **ψηφιακή υπογραφή** δημιουργείται από το περιεχόμενο της παρουσίασης και το ιδιωτικό κλειδί του κατόχου του πιστοποιητικού. Το δημόσιο κλειδί του πιστοποιητικού μπορεί στη συνέχεια να χρησιμοποιηθεί για την επαλήθευση της υπογραφής. Μια υπογραφή παρέχει αποδείξεις προέλευσης και ακεραιότητας· δεν κρυπτογραφεί την παρουσίαση.
- Η **προστασία με κωδικό** ελέγχει αν ένας χρήστης μπορεί να ανοίξει ή να τροποποιήσει μια παρουσίαση. Είναι ανεξάρτητη από την ψηφιακή υπογραφή και περιγράφεται στις [Παρουσιάσεις με Προστασία Κωδικού](/slides/el/java/password-protected-presentation/).

Το PowerPoint παρέχει την εντολή **Add a Digital Signature** στο **File > Info > Protect Presentation**.

![Μενού Protect Presentation του PowerPoint με επισημασμένη την Add a Digital Signature](add-digital-signature-in-powerpoint.png)

Μετά το άνοιγμα μιας υπογεγραμμένης παρουσίασης, το PowerPoint μπορεί να εμφανίσει μια ειδοποίηση κατάστασης υπογραφής.

![Ειδοποίηση του PowerPoint που αναφέρει ότι η παρουσίαση περιέχει έγκυρες υπογραφές](digital-signature-status-in-powerpoint.png)

Το Aspose.Slides εκθέτει τις υπογραφές μέσω [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), το οποίο επιστρέφει ένα [IDigitalSignatureCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/idigitalsignaturecollection/) των οποίων τα στοιχεία υλοποιούν το [IDigitalSignature](https://reference.aspose.com/slides/el/java/com.aspose.slides/idigitalsignature/). Μια παρουσίαση μπορεί να περιέχει περισσότερες από μία υπογραφές.

## **Κατανόηση Πιστοποιητικών PFX και Κωδικών**

Ένα αρχείο PFX, γνωστό επίσης ως αρχείο PKCS#12 και συνήθως έχει επέκταση `.pfx` ή `.p12`, μπορεί να περιέχει ένα πιστοποιητικό X.509, το ιδιωτικό του κλειδί και την αλυσίδα πιστοποιητικών. Το ιδιωτικό κλειδί είναι αυτό που επιτρέπει στον κάτοχο να δημιουργήσει μια υπογραφή. Ένα πιστοποιητικό χωρίς προσβάσιμο ιδιωτικό κλειδί δεν μπορεί να χρησιμοποιηθεί για να υπογράψει μια παρουσίαση.

Ο κωδικός PFX προστατεύει το πακέτο του πιστοποιητικού και το ιδιωτικό κλειδί. Δεν είναι **κωδικός** για το άνοιγμα ή την επεξεργασία της παρουσίασης. Μην προσθέτετε αρχεία PFX ή τους κωδικούς τους σε σύστημα ελέγχου εκδόσεων. Σε παραγωγικό περιβάλλον, περιορίστε την πρόσβαση στο αρχείο πιστοποιητικού και λάβετε τον κωδικό του από αποθήκη μυστικού ή άλλη προστατευμένη πηγή ρυθμίσεων. Τα παρακάτω παραδείγματα χρησιμοποιούν μια μεταβλητή περιβάλλοντος μόνο για να αποφύγουν την ενσωμάτωση του κωδικού στον κώδικα.

## **Προσθήκη Ψηφιακής Υπογραφής σε Παρουσίαση**

Για να υπογράψετε μια πραγματική ροή εργασίας παρουσίασης, φορτώστε ένα υπάρχον αρχείο PPTX, δημιουργήστε ένα [DigitalSignature](https://reference.aspose.com/slides/el/java/com.aspose.slides/digitalsignature/) από ένα πιστοποιητικό PFX και τον κωδικό του, προσθέστε την υπογραφή στη συλλογή της παρουσίασης και αποθηκεύστε σε αρχείο PPTX.

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

Η αποθήκευση του αποτελέσματος με νέο όνομα διατηρεί το αρχικό αρχείο χωρίς υπογραφή. Η τιμή που ορίζεται από το [IDigitalSignature.setComments](https://reference.aspose.com/slides/el/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) περιγράφει τον σκοπό της υπογραφής· δεν αποτελεί ασφάλεια.

## **Επικύρωση Ψηφιακών Υπογραφών**

Όταν φορτώνετε ένα υπογεγραμμένο αρχείο PPTX, εξετάστε κάθε στοιχείο που επιστρέφεται από το [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). Η μέθοδος [IDigitalSignature.isValid](https://reference.aspose.com/slides/el/java/com.aspose.slides/idigitalsignature/#isValid--) υποδεικνύει αν η ενσωματωμένη υπογραφή είναι έγκυρη για το τρέχον περιεχόμενο της παρουσίασης.

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

Ένα μη έγκυρο αποτέλεσμα συνήθως σημαίνει ότι το περιεχόμενο της υπογεγραμμένης παρουσίασης ή τα δεδομένα της υπογραφής άλλαξαν μετά την υπογραφή, ή ότι το αρχείο είναι κατεστραμμένο. Η αφαίρεση κάθε υπογραφής παράγει μια παρουσίαση χωρίς υπογραφή, έτσι ο έλεγχος μόνο της εγκυρότητας των στοιχείων δεν αρκεί: μια ροή εργασίας με ευαίσθητη ασφάλεια πρέπει επίσης να επαληθεύει ότι ο αναμενόμενος αριθμός υπογραφών και οι αναμενόμενες ταυτότητες των υπογράφοντων είναι παρούσες.

Αυτό το αποτέλεσμα εγκυρότητας δεν πρέπει να θεωρείται πλήρης απόφαση εμπιστοσύνης του πιστοποιητικού. Ανάλογα με την πολιτική ασφαλείας σας, η εφαρμογή σας μπορεί επίσης να χρειαστεί να δημιουργήσει και να επικυρώσει την αλυσίδα πιστοποιητικών X.509, να ελέγξει τις ημερομηνίες ισχύος του πιστοποιητικού και την κατάσταση ανάκλησης, να επιβεβαιώσει το αναμενόμενο θέμα ή αποτύπωμα, να επαληθεύσει τη χρήση του κλειδιού και να αξιολογήσει ένα αξιόπιστο χρονικό στίγμα. Η τιμή [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/el/java/com.aspose.slides/idigitalsignature/#getSignTime--) από μόνη της δεν αποτελεί απόδειξη από αξιόπιστη αρχή χρονικών στίγματων.

## **Αφαίρεση Ψηφιακών Υπογραφών**

Η αφαίρεση υπογραφών αλλάζει την κατάσταση ασφαλείας της παρουσίασης. Το παρακάτω παράδειγμα φορτώνει ένα υπογεγραμμένο αρχείο PPTX, αφαιρεί όλες τις υπογραφές με το [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/el/java/com.aspose.slides/idigitalsignaturecollection/#clear--) και αποθηκεύει ένα αντίγραφο χωρίς υπογραφή.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να αφαιρέσετε μόνο μία υπογραφή, καλέστε το [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/el/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) με τον μηδενικό δείκτη της. Αποθηκεύστε σε νέο αρχείο εκτός αν η αντικατάσταση του υπογεγραμμένου αρχικού είναι ρητό μέρος της ροής εργασίας σας.

## **Προβλήματα Επεξεργασίας και Μορφής**

- Μια υπογραφή δεν κάνει την παρουσίαση μόνο για ανάγνωση. Οι χρήστες και οι εφαρμογές μπορούν ακόμη να επεξεργαστούν το αρχείο, αλλά οι αλλαγές στο υπογεγραμμένο περιεχόμενο συνήθως ακυρώνουν την υπάρχουσα υπογραφή.
- Ολοκληρώστε όλες τις προγραμματισμένες επεξεργασίες πριν υπογράψετε. Εάν πρέπει να αλλάξει μια παρουσίαση, αποθηκεύστε την αναθεωρημένη παρουσίαση και υπογράψτε εκ νέου αυτή τη revision.
- Διατηρήστε την τελική έξοδο σε μορφή PPTX. Η μετατροπή μιας υπογεγραμμένης παρουσίασης σε άλλη μορφή δεν μεταφέρει την αρχική υπογραφή PPTX ως έγκυρη υπογραφή για το μετατρεπόμενο αρχείο.
- Θεωρήστε το ιδιωτικό κλειδί του πιστοποιητικού ως ευαίσθητο. Οποιοσδήποτε αποκτήσει το ιδιωτικό κλειδί και τον κωδικό του ενδέχεται να μπορεί να δημιουργήσει υπογραφές που φαίνονται ότι προέρχονται από τον κάτοχο του πιστοποιητικού.
- Διατηρήστε το μη υπογεγραμμένο αρχικό ή ένα άλλο ελεγχόμενο αντίγραφο όταν η πολιτική διατήρησης εγγράφων το απαιτεί.

## **Συχνές Ερωτήσεις**

**Κρυπτογραφεί η ψηφιακή υπογραφή την παρουσίαση;**

Όχι. Μια ψηφιακή υπογραφή παρέχει αποδείξεις για την προέλευση και την ακεραιότητα, αλλά το περιεχόμενο της παρουσίασης παραμένει αναγνώσιμο εκτός εάν εφαρμοστεί ξεχωριστή κρυπτογράφηση. Χρησιμοποιήστε την [προστασία με κωδικό](/slides/el/java/password-protected-presentation/) όταν πρέπει να περιοριστεί η πρόσβαση στο περιεχόμενο.

**Είναι ο κωδικός PFX ίδιος με τον κωδικό της παρουσίασης;**

Όχι. Ο κωδικός PFX ξεκλειδώνει το ιδιωτικό κλειδί που αποθηκεύεται στο πακέτο του πιστοποιητικού. Δεν ελέγχει ποιος μπορεί να ανοίξει ή να επεξεργαστεί το αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω ένα αυτό‑υπογεγραμμένο πιστοποιητικό;**

Τεχνικά, ένα αυτό‑υπογεγραμμένο πιστοποιητικό μπορεί να χρησιμοποιηθεί εφόσον περιλαμβάνει προσβάσιμο ιδιωτικό κλειδί. Οι παραλήπτες δεν θα το εμπιστεύονται αυτόματα, εκτός εάν το πιστοποιητικό έχει προαιρετικά προστεθεί στο αξιόπιστο περιβάλλον τους. Οι δημόσιες ή δια‑οργανωτικές ροές εργασίας συνήθως χρησιμοποιούν πιστοποιητικό που εκδόθηκε από αξιόπιστη CA.

**Τι καθιστά μια υπογραφή μη έγκυρη;**

Η αλλαγή του υπογεγραμμένου περιεχομένου της παρουσίασης ή των δεδομένων της υπογραφής μετά την υπογραφή μπορεί να ακυρώσει την υπογραφή. Η φθορία του αρχείου μπορεί επίσης να προκαλέσει αποτυχία επαλήθευσης. Εάν αφαιρεθούν όλες οι υπογραφές, η παρουσίαση γίνεται χωρίς υπογραφή και όχι ως αρχείο που περιέχει μη έγκυρη υπογραφή.

**Μια έγκυρη υπογραφή σημαίνει ότι πρέπει να εμπιστευτώ τον υπογραφέα;**

Όχι από μόνη της. Η ακεραιότητα της υπογραφής και η εμπιστοσύνη στον υπογραφέα είναι ξεχωριστές αποφάσεις. Μια πολιτική επαλήθευσης στην παραγωγή θα πρέπει επίσης να ελέγχει την αλυσίδα πιστοποιητικών, την περίοδο ισχύος, την κατάσταση ανάκλησης, την αναμενόμενη ταυτότητα, τη χρήση του κλειδιού και τυχόν απαιτήσεις αξιόπιστου χρονικού στίγματος.

**Τι συμβαίνει όταν λήγει το πιστοποιητικό;**

Η λήξη του πιστοποιητικού δεν τροποποιεί τα bytes της παρουσίασης, αλλά επηρεάζει την αξιολόγηση εμπιστοσύνης του πιστοποιητικού. Το αν η υπογραφή παραμένει αποδεκτή εξαρτάται από την πολιτική σας και από το εάν ένα έγκυρο αξιόπιστο χρονικό στίγμα αποδεικνύει ότι η υπογραφή έγινε ενώ το πιστοποιητικό ήταν έγκυρο. Μην βασίζεστε μόνο στην εμφανιζόμενη ώρα υπογραφής ως αξιόπιστο χρονικό στίγμα.

**Μπορεί μια υπογεγραμμένη παρουσίαση να επεξεργαστεί ακόμη;**

Ναι. Η υπογραφή δεν κλειδώνει το αρχείο. Η επεξεργασία του υπογεγραμμένου περιεχομένου συνήθως ακυρώνει την υπάρχουσα υπογραφή, επομένως ολοκληρώστε πρώτα την παρουσίαση και υπογράψτε τη τελική αναθεώρηση.

**Μπορεί μια παρουσίαση να περιέχει περισσότερες από μία υπογραφές;**

Ναι. Προσθέστε κάθε υπογραφή στη συλλογή που επιστρέφεται από το [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) πριν την αποθήκευση. Κατά την επαλήθευση, εξετάστε κάθε υπογραφή και επιβεβαιώστε ότι όλοι οι απαιτούμενοι υπογράφοντες είναι παρόντες.

**Ποιες μορφές παρουσίασης υποστηρίζουν αυτές τις λειτουργίες;**

Το Aspose.Slides υποστηρίζει τις λειτουργίες ψηφιακής υπογραφής που περιγράφονται εδώ μόνο για PPTX. Οι μορφές παρουσίασης PPT και OpenDocument δεν υποστηρίζονται από αυτήν τη ροή εργασίας API.

**Μπορώ να αφαιρέσω μια υπογραφή χωρίς να επηρεάσω τις διαφάνειες;**

Ναι. Μπορείτε να αφαιρέσετε μία υπογραφή ή να αδειάσετε ολόκληρη τη συλλογή και στη συνέχεια να αποθηκεύσετε την παρουσίαση. Το περιεχόμενο των διαφανειών παραμένει διαθέσιμο, αλλά το αποθηκευμένο αρχείο δεν φέρει πλέον τα αποδεικτικά στοιχεία της αφαιρεμένης υπογραφής.