---
title: Προσθήκη Ψηφιακών Υπογραφών σε Παρουσιάσεις με Python
linktitle: Ψηφιακή Υπογραφή
type: docs
weight: 10
url: /el/python-java/digital-signature-in-powerpoint/
keywords:
- ψηφιακή υπογραφή
- ψηφιακό πιστοποιητικό
- αρχή πιστοποιητικών
- πιστοποιητικό PFX
- PKCS#12
- επικύρωση υπογραφής
- PowerPoint
- PPTX
- ασφάλεια παρουσίασης
- Python
- Aspose.Slides
description: "Μάθετε πώς να υπογράφετε υπάρχουσες παρουσιάσεις PPTX με πιστοποιητικά PFX και να χρησιμοποιείτε το Aspose.Slides για Python μέσω Java για την επικύρωση ή την αφαίρεση ψηφιακών υπογραφών."
---
## **Επισκόπηση**

Μια ψηφιακή υπογραφή βοηθά τον παραλήπτη να καθορίσει ποιος υπέγραψε μια παρουσίαση και αν το υπογεγραμμένο περιεχόμενο έχει αλλάξει. Τρία σχετιζόμενα έννοιες ασφαλείας είναι σημαντικά εδώ:

- Ένα **ψηφιακό πιστοποιητικό** είναι ένα ηλεκτρονικό διακριτικό που συσχετίζει μια ταυτότητα με ένα δημόσιο κλειδί. Μια αξιόπιστη αρχή πιστοποιητικών (CA) μπορεί να εκδώσει ένα πιστοποιητικό, ή ένας οργανισμός μπορεί να χρησιμοποιήσει ένα αυτο‑υπογεγραμμένο πιστοποιητικό για εσωτερικές διαδικασίες.
- Μια **ψηφιακή υπογραφή** δημιουργείται από το περιεχόμενο της παρουσίασης και το ιδιωτικό κλειδί του κατόχου του πιστοποιητικού. Το δημόσιο κλειδί του πιστοποιητικού μπορεί στη συνέχεια να χρησιμοποιηθεί για την επαλήθευση της υπογραφής. Μια υπογραφή παρέχει αποδείξεις προέλευσης και ακεραιότητας· δεν κρυπτογραφεί την παρουσίαση.
- **Προστασία με κωδικό** ελέγχει αν ένας χρήστης μπορεί να ανοίξει ή να τροποποιήσει μια παρουσίαση. Είναι ξεχωριστό από την ψηφιακή υπογραφή και περιγράφεται στις [Παρουσιάσεις με Προστασία Κωδικού](/slides/el/python-java/password-protected-presentation/).

Το PowerPoint παρέχει την εντολή **Add a Digital Signature** στο **File > Info > Protect Presentation**.

![Μενού Protect Presentation του PowerPoint με την επιλογή Add a Digital Signature επισημασμένη](add-digital-signature-in-powerpoint.png)

Αφού ανοίξει μια υπογεγραμμένη παρουσίαση, το PowerPoint μπορεί να εμφανίσει μια ειδοποίηση κατάστασης υπογραφής.

![Ειδοποίηση του PowerPoint που δηλώνει ότι η παρουσίαση περιέχει έγκυρες υπογραφές](digital-signature-status-in-powerpoint.png)

Το Aspose.Slides αποκαλύπτει τις υπογραφές μέσω του [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getDigitalSignatures), το οποίο επιστρέφει ένα [DigitalSignatureCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/digitalsignaturecollection/) του οποίου τα στοιχεία είναι στιγμές του [DigitalSignature](https://reference.aspose.com/slides/el/python-java/aspose.slides/digitalsignature/). Μια παρουσίαση μπορεί να περιέχει πολλαπλές υπογραφές.

## **Κατανόηση Πιστοποιητικών PFX και Κωδικών Πρόσβασης**

Ένα αρχείο PFX, επίσης γνωστό ως αρχείο PKCS#12 και συνήθως με επέκταση `.pfx` ή `.p12`, μπορεί να περιέχει ένα πιστοποιητικό X.509, το ιδιωτικό του κλειδί και την αλυσίδα πιστοποιητικών. Το ιδιωτικό κλειδί είναι αυτό που επιτρέπει στον κάτοχο να δημιουργήσει μια υπογραφή. Ένα πιστοποιητικό χωρίς προσβάσιμο ιδιωτικό κλειδί δεν μπορεί να χρησιμοποιηθεί για να υπογράψει μια παρουσίαση.

Ο κωδικός πρόσβασης του PFX προστατεύει το πακέτο του πιστοποιητικού και το ιδιωτικό κλειδί. Δεν είναι **κωδικός πρόσβασης** για το άνοιγμα ή την επεξεργασία της παρουσίασης. Μην καταχωρίζετε αρχεία PFX ή τους κωδικούς τους στον έλεγχο πηγής. Σε παραγωγικό περιβάλλον, περιορίστε την πρόσβαση στο αρχείο πιστοποιητικού και πάρτε τον κωδικό του από ένα ασφαές κατάστημα μυστικών ή άλλη προστατευμένη πηγή ρυθμίσεων. Τα παραδείγματα παρακάτω χρησιμοποιούν μια μεταβλητή περιβάλλοντος μόνο για να αποφύγουν την ενσωμάτωση του κωδικού στον κώδικα.

## **Προσθήκη Ψηφιακής Υπογραφής σε Παρουσίαση**

Για να υπογράψετε μια πραγματική ροή εργασίας παρουσίασης, φορτώστε ένα υπάρχον αρχείο PPTX, δημιουργήστε ένα [DigitalSignature](https://reference.aspose.com/slides/el/python-java/aspose.slides/digitalsignature/) από ένα πιστοποιητικό PFX και τον κωδικό του, προσθέστε την υπογραφή στη συλλογή της παρουσίασης και αποθηκεύστε το σε αρχείο PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Η αποθήκευση του αποτελέσματος με νέο όνομα διατηρεί το αρχείο πηγής χωρίς υπογραφή. Η τιμή που ορίζεται από το [DigitalSignature.setComments](https://reference.aspose.com/slides/el/python-java/aspose.slides/digitalsignature/#setComments) περιγράφει τον σκοπό της υπογραφής· δεν αποτελεί έλεγχο ασφαλείας.

## **Επικύρωση Ψηφιακών Υπογραφών**

Όταν φορτώνετε ένα υπογεγραμμένο αρχείο PPTX, ελέγξτε κάθε στοιχείο που επιστρέφεται από το [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getDigitalSignatures). Η μέθοδος [DigitalSignature.isValid](https://reference.aspose.com/slides/el/python-java/aspose.slides/digitalsignature/#isValid) δείχνει αν η ενσωματωμένη υπογραφή είναι έγκυρη για το τρέχον περιεχόμενο της παρουσίασης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

Ένα άκυρο αποτέλεσμα συνήθως σημαίνει ότι το υπογεγραμμένο περιεχόμενο της παρουσίασης ή τα δεδομένα της υπογραφής άλλαξαν μετά την υπογραφή, ή ότι το αρχείο είναι κατεστραμμένο. Η αφαίρεση όλων των υπογραφών παράγει μια παρουσίαση χωρίς υπογραφή, οπότε ο έλεγχος μόνο της εγκυρότητας των στοιχείων δεν είναι επαρκής: μια ροή εργασίας ευαίσθητη στην ασφάλεια πρέπει επίσης να επαληθεύει ότι υπάρχει ο αναμενόμενος αριθμός υπογραφών και οι αναμενόμενες ταυτότητες των υπογραφόντων.

Αυτό το αποτέλεσμα εγκυρότητας δεν πρέπει να αντιμετωπίζεται ως πλήρης απόφαση εμπιστοσύνης του πιστοποιητικού. Ανάλογα με την πολιτική ασφαλείας σας, η εφαρμογή σας ενδέχεται επίσης να χρειάζεται να δημιουργήσει και να επαληθεύσει την αλυσίδα πιστοποιητικών X.509, να ελέγξει τις ημερομηνίες ισχύος του πιστοποιητικού και την κατάσταση ανάκλησής του, να επιβεβαιώσει το αναμενόμενο θέμα ή αποτύπωμα, να επαληθεύσει τη χρήση κλειδιού και να αξιολογήσει ένα αξιόπιστο χρονικό σήμα. Η τιμή [DigitalSignature.getSignTime](https://reference.aspose.com/slides/el/python-java/aspose.slides/digitalsignature/#getSignTime) από μόνη της δεν αποτελεί απόδειξη από αξιόπιστη αρχή χρονικού σήματος.

## **Αφαίρεση Ψηφιακών Υπογραφών**

Η αφαίρεση υπογραφών αλλάζει την κατάσταση ασφαλείας της παρουσίασης. Το παρακάτω παράδειγμα φορτώνει ένα υπογεγραμμένο αρχείο PPTX, αφαιρεί όλες τις υπογραφές με το [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/el/python-java/aspose.slides/digitalsignaturecollection/#clear), και αποθηκεύει ένα αντίγραφο χωρίς υπογραφή.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Για να αφαιρέσετε μόνο μία υπογραφή, καλέστε το [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/el/python-java/aspose.slides/digitalsignaturecollection/#removeAt) με το μηδενικό του δείκτη. Αποθηκεύστε σε νέο αρχείο εκτός αν η αντικατάσταση του υπογεγραμμένου αρχικού είναι ρητό μέρος της ροής εργασίας σας.

## **Προβληματισμοί Επεξεργασίας και Μορφοποίησης**

- Μια υπογραφή δεν κάνει την παρουσίαση μόνο για ανάγνωση. Οι χρήστες και οι εφαρμογές μπορούν ακόμη να επεξεργαστούν το αρχείο, αλλά οι αλλαγές στο υπογεγραμμένο περιεχόμενο συνήθως ακυρώνουν την υπάρχουσα υπογραφή.
- Ολοκληρώστε όλες τις προγραμματισμένες επεξεργασίες πριν από την υπογραφή. Εάν πρέπει να αλλάξει μια παρουσίαση, αποθηκεύστε την αναθεωρημένη έκδοση και υπογράψτε ξανά αυτήν την εκδοχή.
- Διατηρήστε το τελικό αποτέλεσμα σε μορφή PPTX. Η μετατροπή μιας υπογεγραμμένης παρουσίασης σε άλλη μορφή δεν μεταφέρει την αρχική υπογραφή PPTX ως έγκυρη υπογραφή για το μετατρεπόμενο αρχείο.
- Αντιμετωπίστε το ιδιωτικό κλειδί του πιστοποιητικού ως ευαίσθητο. Οποιοσδήποτε αποκτήσει το ιδιωτικό κλειδί και τον κωδικό πρόσβασής του μπορεί να δημιουργήσει υπογραφές που φαίνονται ότι προέρχονται από αυτόν τον κάτοχο του πιστοποιητικού.
- Διατηρήστε την πηγή χωρίς υπογραφή ή άλλο ελεγχόμενο αντίγραφο όταν η πολιτική διατήρησης εγγράφων το απαιτεί.

## **Συχνές Ερωτήσεις**

**Κρυπτογραφεί η ψηφιακή υπογραφή την παρουσίαση;**

Όχι. Μια ψηφιακή υπογραφή παρέχει αποδείξεις σχετικά με την προέλευση και την ακεραιότητα, αλλά το περιεχόμενο της παρουσίασης παραμένει αναγνώσιμο εκτός αν εφαρμοστεί ξεχωριστή κρυπτογράφηση. Χρησιμοποιήστε την [προστασία με κωδικό](/slides/el/python-java/password-protected-presentation/) όταν πρέπει να περιοριστεί η πρόσβαση στο περιεχόμενο.

**Είναι ο κωδικός PFX ίδιος με τον κωδικό της παρουσίασης;**

Όχι. Ο κωδικός PFX ξεκλειδώνει το ιδιωτικό κλειδί που αποθηκεύεται στο πακέτο του πιστοποιητικού. Δεν ελέγχει ποιος μπορεί να ανοίξει ή να επεξεργαστεί το αρχείο PPTX.

**Μπορώ να χρησιμοποιήσω αυτο‑υπογεγραμμένο πιστοποιητικό;**

Τεχνικά, ένα αυτο‑υπογεγραμμένο πιστοποιητικό μπορεί να χρησιμοποιηθεί εφόσον περιλαμβάνει προσβάσιμο ιδιωτικό κλειδί. Οι παραλήπτες δεν θα το εμπιστευθούν αυτόματα, εκτός αν το πιστοποιητικό έχει προσαρτηθεί ρητά στο αξιόπιστο περιβάλλον τους. Οι δημόσιες ή διαπολιτισμικές ροές εργασίας συνήθως χρησιμοποιούν πιστοποιητικό που εκδίδεται από αξιόπιστη Αρχή Πιστοποιητικών (CA).

**Τι καθιστά μια υπογραφή άκυρη;**

Η αλλαγή του υπογεγραμμένου περιεχομένου της παρουσίασης ή των δεδομένων της υπογραφής μετά την υπογραφή μπορεί να ακυρώσει την υπογραφή. Η κακή κατάσταση του αρχείου μπορεί επίσης να προκαλέσει αποτυχία επικύρωσης. Εάν αφαιρεθούν όλες οι υπογραφές, η παρουσίαση είναι χωρίς υπογραφή και όχι ένα αρχείο που περιέχει άκυρη υπογραφή.

**Σημαίνει μια έγκυρη υπογραφή ότι πρέπει να εμπιστευθώ τον υπογράφοντα;**

Όχι από μόνο του. Η ακεραιότητα της υπογραφής και η εμπιστοσύνη στον υπογράφοντα είναι ξεχωριστές αποφάσεις. Μια πολιτική επικύρωσης σε παραγωγικό περιβάλλον πρέπει επίσης να ελέγχει την αλυσίδα του πιστοποιητικού, την περίοδο ισχύος, την κατάσταση ανάκλησης, την αναμενόμενη ταυτότητα, τη χρήση κλειδιού και τυχόν απαιτήσεις αξιόπιστου χρονικού σήματος.

**Τι συμβαίνει όταν λήξει το πιστοποιητικό;**

Η λήξη του πιστοποιητικού δεν αλλάζει τα bytes της παρουσίασης, αλλά επηρεάζει την αξιολόγηση εμπιστοσύνης του πιστοποιητικού. Το αν μια υπογραφή παραμένει αποδεκτή εξαρτάται από την πολιτική σας και από το αν ένα έγκυρο αξιόπιστο χρονικό σήμα αποδεικνύει ότι η υπογραφή έγινε ενώ το πιστοποιητικό ήταν έγκυρο. Μην βασίζεστε μόνο στον εμφανιζόμενο χρόνο υπογραφής ως αξιόπιστο χρονικό σήμα.

**Μπορεί μια υπογεγραμμένη παρουσίαση να επεξεργαστεί ακόμη;**

Ναι. Η υπογραφή δεν κλειδώνει το αρχείο. Η επεξεργασία του υπογεγραμμένου περιεχομένου συνήθως ακυρώνει την υπάρχουσα υπογραφή, επομένως ολοκληρώστε πρώτα την παρουσίαση και υπογράψτε την τελική έκδοση.

**Μπορεί μια παρουσίαση να περιέχει περισσότερες από μία υπογραφές;**

Ναι. Προσθέστε κάθε υπογραφή στη συλλογή που επιστρέφεται από το [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#getDigitalSignatures) πριν αποθηκεύσετε. Κατά την επικύρωση, ελέγξτε κάθε υπογραφή και επιβεβαιώστε ότι όλοι οι απαιτούμενοι υπογράφοντες είναι παρόντες.

**Ποιες μορφές παρουσίασης υποστηρίζουν αυτές τις λειτουργίες;**

Το Aspose.Slides υποστηρίζει τις λειτουργίες ψηφιακής υπογραφής που περιγράφονται εδώ μόνο για PPTX. Οι μορφές παρουσίασης PPT και OpenDocument δεν υποστηρίζονται από αυτήν τη ροή εργασίας API.

**Μπορώ να αφαιρέσω μια υπογραφή χωρίς να επηρεάσω τις διαφάνειες;**

Ναι. Μπορείτε να αφαιρέσετε μία υπογραφή ή να αδειάσετε ολόκληρη τη συλλογή και μετά να αποθηκεύσετε την παρουσίαση. Το περιεχόμενο των διαφανειών παραμένει διαθέσιμο, αλλά το αποθηκευμένο αρχείο δεν φέρει πλέον την απόδειξη της αφαιρεθείσας υπογραφής.