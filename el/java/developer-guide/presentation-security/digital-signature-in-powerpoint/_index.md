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
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να υπογράφετε ψηφιακά αρχεία PowerPoint & OpenDocument με το Aspose.Slides για Java. Ασφαλίστε τις διαφάνειες σας σε δευτερόλεπτα με σαφή παραδείγματα κώδικα."
---
## **Introduction**

**Ψηφιακό πιστοποιητικό** χρησιμοποιείται για τη δημιουργία μιας παρουσίασης PowerPoint προστατευμένης με κωδικό, σημειωμένης ως δημιουργημένη από συγκεκριμένη οργάνωση ή άτομο. Το ψηφιακό πιστοποιητικό μπορεί να αποκτηθεί επικοινωνώντας με εξουσιοδοτημένη οργάνωση - ένα κέντρο πιστοποίησης. Μετά την εγκατάσταση του ψηφιακού πιστοποιητικού στο σύστημα, μπορεί να χρησιμοποιηθεί για την προσθήκη ψηφιακής υπογραφής στην παρουσίαση μέσω Αρχείο → Πληροφορίες → Προστασία Παρουσίασης:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Η παρουσίαση μπορεί να περιέχει περισσότερες από μία ψηφιακές υπογραφές. Αφού προστεθεί η ψηφιακή υπογραφή στην παρουσίαση, ένα ειδικό μήνυμα θα εμφανιστεί στο PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Για την υπογραφή παρουσίασης ή τον έλεγχο της αυθεντικότητας των υπογραφών παρουσίασης, το **Aspose.Slides API** παρέχει το [**IDigitalSignature**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IDigitalSignature) interface, το [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IDigitalSignatureCollection) interface και τη μέθοδο [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentation#getDigitalSignatures--) . Επί του παρόντος, οι ψηφιακές υπογραφές υποστηρίζονται μόνο για τη μορφή PPTX.
## **Add a Digital Signature from a PFX Certificate**
Το παρακάτω δείγμα κώδικα δείχνει πώς να προσθέσετε ψηφιακή υπογραφή από πιστοποιητικό PFX:

1. Ανοίξτε το αρχείο PFX και περάστε τον κωδικό PFX στο αντικείμενο [**DigitalSignature**](https://reference.aspose.com/slides/el/java/com.aspose.slides/DigitalSignature).
1. Προσθέστε τη δημιουργημένη υπογραφή στο αντικείμενο παρουσίασης.

```java
// Άνοιγμα του αρχείου παρουσίασης
Presentation pres = new Presentation();
try {
    // Δημιουργία αντικειμένου DigitalSignature με αρχείο PFX και κωδικό PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Σχόλιο νέας ψηφιακής υπογραφής
    signature.setComments("Aspose.Slides digital signing test.");

    // Προσθήκη ψηφιακής υπογραφής στην παρουσίαση
    pres.getDigitalSignatures().add(signature);

    // Αποθήκευση παρουσίασης
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Τώρα είναι δυνατόν να ελέγξετε εάν η παρουσίαση έχει ψηφιακά υπογραφεί και δεν έχει τροποποιηθεί:

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

## **FAQ**

**Μπορώ να αφαιρέσω τις υπάρχουσες υπογραφές από ένα αρχείο;**

Ναι. Η συλλογή ψηφιακών υπογραφών υποστηρίζει [αφαίρεση μεμονωμένων στοιχείων](https://reference.aspose.com/slides/el/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) και [εκκαθάριση του σύνολο­υ](https://reference.aspose.com/slides/el/java/com.aspose.slides/digitalsignaturecollection/#clear--); μετά την αποθήκευση του αρχείου, η παρουσίαση δεν θα έχει υπογραφές.

**Γίνεται το αρχείο «μόνο για ανάγνωση» μετά την υπογραφή;**

Όχι. Μια υπογραφή διατηρεί την ακεραιότητα και το δικαίωμα δημιουργού, αλλά δεν εμποδίζει τις επεξεργασίες. Για περιορισμό επεξεργασίας, συνδυάστε τη με το ["Μόνο για ανάγνωση" ή κωδικός πρόσβασης](/slides/el/java/password-protected-presentation/).

**Θα εμφανίζεται η υπογραφή σωστά σε διαφορετικές εκδόσεις του PowerPoint;**

Η υπογραφή δημιουργείται για το κοντέινερ OOXML (PPTX). Οι σύγχρονες εκδόσεις του PowerPoint που υποστηρίζουν υπογραφές OOXML εμφανίζουν σωστά την κατάσταση αυτών των υπογραφών.