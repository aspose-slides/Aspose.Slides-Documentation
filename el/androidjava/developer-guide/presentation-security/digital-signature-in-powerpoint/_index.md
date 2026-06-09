---
title: Προσθήκη ψηφιακών υπογραφών σε παρουσιάσεις στο Android
linktitle: Ψηφιακή Υπογραφή
type: docs
weight: 10
url: /el/androidjava/digital-signature-in-powerpoint/
keywords:
- ψηφιακή υπογραφή
- ψηφιακό πιστοποιητικό
- αρχή πιστοποίησης
- πιστοποιητικό PFX
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να υπογράφετε ψηφιακά αρχεία PowerPoint & OpenDocument με το Aspose.Slides για Android. Ασφαλίστε τις διαφάνειες σας σε δευτερόλεπτα με σαφή παραδείγματα κώδικα Java."
---
## **Εισαγωγή**

**Ψηφιακό πιστοποιητικό** χρησιμοποιείται για τη δημιουργία μιας παρουσίασης PowerPoint προστατευμένης με κωδικό πρόσβασης, η οποία χαρακτηρίζεται ως δημιουργημένη από συγκεκριμένο οργανισμό ή άτομο. Το ψηφιακό πιστοποιητικό μπορεί να ληφθεί επικοινωνώντας με εξουσιοδοτημένο οργανισμό – μια αρχή πιστοποιήσεων. Αφού εγκατασταθεί το ψηφιακό πιστοποιητικό στο σύστημα, μπορεί να χρησιμοποιηθεί για την προσθήκη ψηφιακής υπογραφής στην παρουσίαση μέσω Αρχείο -> Πληροφορίες -> Προστασία Παρουσίασης:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Η παρουσίαση μπορεί να περιέχει περισσότερες από μία ψηφιακές υπογραφές. Αφού η ψηφιακή υπογραφή προστεθεί στην παρουσίαση, θα εμφανιστεί ένα ειδικό μήνυμα στο PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Για να υπογράψετε την παρουσίαση ή να ελέγξετε την αυθεντικότητα των υπογραφών της παρουσίασης, το **Aspose.Slides API** παρέχει τη διεπαφή [**IDigitalSignature**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IDigitalSignature), τη διεπαφή [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IDigitalSignatureCollection) και τη μέθοδο [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--) . Προς το παρόν, οι ψηφιακές υπογραφές υποστηρίζονται μόνο για τη μορφή PPTX.

## **Προσθήκη ψηφιακής υπογραφής από πιστοποιητικό PFX**

Το παρακάτω δείγμα κώδικα δείχνει πώς να προσθέσετε ψηφιακή υπογραφή από ένα πιστοποιητικό PFX:

1. Ανοίξτε το αρχείο PFX και περάστε τον κωδικό πρόσβασης PFX στο αντικείμενο [**DigitalSignature**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/DigitalSignature).
2. Προσθέστε τη δημιουργημένη υπογραφή στο αντικείμενο παρουσίασης.

```java
// Άνοιγμα του αρχείου παρουσίασης
Presentation pres = new Presentation();
try {
    // Δημιουργία αντικειμένου DigitalSignature με αρχείο PFX και κωδικό πρόσβασης PFX
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Σχόλιο για τη νέα ψηφιακή υπογραφή
    signature.setComments("Aspose.Slides digital signing test.");

    // Προσθήκη ψηφιακής υπογραφής στην παρουσίαση
    pres.getDigitalSignatures().add(signature);

    // Αποθήκευση παρουσίασης
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Τώρα είναι δυνατόν να ελέγξετε εάν η παρουσίαση έχει ψηφιακή υπογραφή και δεν έχει τροποποιηθεί:

```java
// Άνοιγμα παρουσίασης
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Έλεγχος εάν όλες οι ψηφιακές υπογραφές είναι έγκυρες
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να αφαιρέσω υπάρχουσες υπογραφές από ένα αρχείο;**

Ναι. Η συλλογή ψηφιακών υπογραφών υποστηρίζει [αφαίρεση μεμονωμένων στοιχείων](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) και [εκκαθάριση ολοκληρωτικά](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/digitalsignaturecollection/#clear--) ; μετά την αποθήκευση του αρχείου, η παρουσίαση δεν θα έχει υπογραφές.

**Γίνεται το αρχείο "μόνο για ανάγνωση" μετά την υπογραφή;**

Όχι. Μια υπογραφή διατηρεί την ακεραιότητα και τη συγγραφή, αλλά δεν εμποδίζει επεξεργασίες. Για να περιορίσετε την επεξεργασία, συνδυάστε το με ["Μόνο για ανάγνωση" ή κωδικό πρόσβασης](/slides/el/androidjava/password-protected-presentation/).

**Θα εμφανίζεται σωστά η υπογραφή σε διαφορετικές εκδόσεις του PowerPoint;**

Η υπογραφή δημιουργείται για το δοχείο OOXML (PPTX). Οι σύγχρονες εκδόσεις του PowerPoint που υποστηρίζουν υπογραφές OOXML εμφανίζουν σωστά την κατάσταση αυτών των υπογραφών.