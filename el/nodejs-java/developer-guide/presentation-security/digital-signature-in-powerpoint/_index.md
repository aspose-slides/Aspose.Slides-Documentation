---
title: Προσθήκη ψηφιακών υπογραφών σε παρουσιάσεις με JavaScript
linktitle: Ψηφιακή Υπογραφή
type: docs
weight: 10
url: /el/nodejs-java/digital-signature-in-powerpoint/
keywords:
- ψηφιακή υπογραφή
- ψηφιακό πιστοποιητικό
- αρχή πιστοποιητικών
- πιστοποιητικό PFX
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να υπογράφετε ψηφιακά αρχεία PowerPoint & OpenDocument με το Aspose.Slides για Node.js μέσω Java. Ασφαλίστε τις διαφάνειες σας σε δευτερόλεπτα με σαφή παραδείγματα κώδικα."
---
## **Εισαγωγή**

**Digital certificate** χρησιμοποιείται για τη δημιουργία μιας παρουσίασης PowerPoint προστατευμένης με κωδικό, που σημειώνεται ως δημιουργημένη από συγκεκριμένο οργανισμό ή άτομο. Digital certificate μπορεί να ληφθεί επικοινωνώντας με έναν εξουσιοδοτημένο οργανισμό - μια αρχή πιστοποιητικών. Μετά την εγκατάσταση του Digital certificate στο σύστημα, μπορεί να χρησιμοποιηθεί για να προσθέσετε ψηφιακή υπογραφή στην παρουσίαση μέσω Αρχείο -> Πληροφορίες -> Προστασία Παρουσίασης:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Η παρουσίαση μπορεί να περιέχει περισσότερες από μία ψηφιακές υπογραφές. Αφού προστεθεί η ψηφιακή υπογραφή στην παρουσίαση, θα εμφανιστεί ένα ειδικό μήνυμα στο PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Για την υπογραφή της παρουσίασης ή τον έλεγχο της αυθεντικότητας των υπογραφών της παρουσίασης, **Aspose.Slides API** παρέχει την κλάση [**DigitalSignature**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/DigitalSignature), την κλάση [**DigitalSignatureCollection**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/DigitalSignatureCollection) και τη μέθοδο [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) . Προς το παρόν, οι ψηφιακές υπογραφές υποστηρίζονται μόνο για τη μορφή PPTX.

## **Προσθήκη ψηφιακής υπογραφής από πιστοποιητικό PFX**

Το παρακάτω δείγμα κώδικα δείχνει πώς να προσθέσετε ψηφιακή υπογραφή από ένα πιστοποιητικό PFX:

1. Ανοίξτε το αρχείο PFX και περάστε τον κωδικό PFX στο αντικείμενο [**DigitalSignature**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/DigitalSignature).

1. Προσθέστε τη δημιουργημένη υπογραφή στο αντικείμενο παρουσίασης.

```javascript
// Άνοιγμα του αρχείου παρουσίασης
var pres = new aspose.slides.Presentation();
try {
    // Δημιουργία αντικειμένου DigitalSignature με αρχείο PFX και κωδικό PFX
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Σχόλιο νέας ψηφιακής υπογραφής
    signature.setComments("Aspose.Slides digital signing test.");
    // Προσθήκη ψηφιακής υπογραφής στην παρουσίαση
    pres.getDigitalSignatures().add(signature);
    // Αποθήκευση παρουσίασης
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Τώρα είναι δυνατόν να ελέγξετε εάν η παρουσίαση είχε ψηφιακά υπογραφεί και δεν έχει τροποποιηθεί:

```javascript
// Άνοιγμα παρουσίασης
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Έλεγχος αν όλες οι ψηφιακές υπογραφές είναι έγκυρες
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να αφαιρέσω υπάρχουσες υπογραφές από ένα αρχείο;**

Ναι. Η συλλογή ψηφιακών υπογραφών υποστηρίζει [αφαίρεση μεμονωμένων στοιχείων](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) και [εκκαθάριση της πλήρως](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/digitalsignaturecollection/clear/)· μετά την αποθήκευση του αρχείου, η παρουσίαση δεν θα περιέχει καμία υπογραφή.

**Γίνεται το αρχείο «μόνο για ανάγνωση» μετά την υπογραφή;**

Όχι. Μια υπογραφή διατηρεί την ακεραιότητα και τη συγγραφή, αλλά δεν εμποδίζει τις επεξεργασίες. Για να περιορίσετε την επεξεργασία, συνδυάστε την με την επιλογή [«Μόνο για ανάγνωση» ή κωδικό πρόσβασης](/slides/el/nodejs-java/password-protected-presentation/).

**Θα εμφανίζεται σωστά η υπογραφή σε διαφορετικές εκδόσεις του PowerPoint;**

Η υπογραφή δημιουργείται για το δοχείο OOXML (PPTX). Οι σύγχρονες εκδόσεις του PowerPoint που υποστηρίζουν υπογραφές OOXML εμφανίζουν σωστά την κατάσταση τέτοιων υπογραφών.