---
title: Προσθήκη Ψηφιακών Υπογραφών σε Παρουσιάσεις σε PHP
linktitle: Ψηφιακή Υπογραφή
type: docs
weight: 10
url: /el/php-java/digital-signature-in-powerpoint/
keywords:
- ψηφιακή υπογραφή
- ψηφιακό πιστοποιητικό
- αρχή πιστοποίησης
- πιστοποιητικό PFX
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να υπογράφετε ψηφιακά αρχεία PowerPoint & OpenDocument με το Aspose.Slides για PHP μέσω Java. Ασφαλίστε τις διαφάνειές σας σε δευτερόλεπτα με σαφή παραδείγματα κώδικα."
---
## **Εισαγωγή**

**Digital certificate** χρησιμοποιείται για τη δημιουργία μιας παρουσίασης PowerPoint προστατευμένης με κωδικό, η οποία σημειώνεται ως δημιουργήθηκε από συγκεκριμένο οργανισμό ή άτομο. Το ψηφιακό πιστοποιητικό μπορεί να ληφθεί επικοινωνώντας με έναν εξουσιοδοτημένο οργανισμό – μια αρχή πιστοποίησης. Αφού εγκατασταθεί το ψηφιακό πιστοποιητικό στο σύστημα, μπορεί να χρησιμοποιηθεί για την προσθήκη ψηφιακής υπογραφής στην παρουσίαση μέσω Αρχείο -> Πληροφορίες -> Προστασία Παρουσίασης:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Η παρουσίαση μπορεί να περιέχει περισσότερες από μία ψηφιακές υπογραφές. Αφού προστεθεί η ψηφιακή υπογραφή στην παρουσίαση, θα εμφανιστεί ένα ειδικό μήνυμα στο PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Για να υπογράψετε την παρουσίαση ή να ελέγξετε την αυθεντικότητα των υπογραφών της παρουσίασης, το **Aspose.Slides API** παρέχει την κλάση [**DigitalSignature**](https://reference.aspose.com/slides/el/php-java/aspose.slides/DigitalSignature), την κλάση [**DigitalSignatureCollection**](https://reference.aspose.com/slides/el/php-java/aspose.slides/DigitalSignatureCollection) και τη μέθοδο [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/el/php-java/aspose.slides/Presentation/#getDigitalSignatures). Προς το παρόν, οι ψηφιακές υπογραφές υποστηρίζονται μόνο για τη μορφή PPTX.

## **Προσθήκη Ψηφιακής Υπογραφής από Πιστοποιητικό PFX**

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να προσθέσετε μια ψηφιακή υπογραφή από ένα πιστοποιητικό PFX:

1. Ανοίξτε το αρχείο PFX και περάστε τον κωδικό PFX στο αντικείμενο [**DigitalSignature**](https://reference.aspose.com/slides/el/php-java/aspose.slides/DigitalSignature).
1. Προσθέστε τη δημιουργημένη υπογραφή στο αντικείμενο παρουσίασης.

```php
  # Άνοιγμα του αρχείου παρουσίασης
  $pres = new Presentation();
  try {
    # Δημιουργία αντικειμένου DigitalSignature με αρχείο PFX και κωδικό PFX
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # Σχόλιο νέας ψηφιακής υπογραφής
    $signature->setComments("Aspose.Slides digital signing test.");
    # Προσθήκη ψηφιακής υπογραφής στην παρουσίαση
    $pres->getDigitalSignatures()->add($signature);
    # Αποθήκευση παρουσίασης
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Τώρα είναι δυνατόν να ελέγξετε αν η παρουσίαση έχει ψηφιακή υπογραφή και δεν έχει τροποποιηθεί:

```php
  # Άνοιγμα παρουσίασης
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # Έλεγχος αν όλες οι ψηφιακές υπογραφές είναι έγκυρες
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Μπορώ να αφαιρέσω υπάρχουσες υπογραφές από ένα αρχείο;**

Ναι. Η συλλογή ψηφιακών υπογραφών υποστηρίζει [αφαίρεση μεμονωμένων στοιχείων](https://reference.aspose.com/slides/el/php-java/aspose.slides/digitalsignaturecollection/removeat/) και [καθαρισμό της εντελώς](https://reference.aspose.com/slides/el/php-java/aspose.slides/digitalsignaturecollection/clear/); αφού αποθηκεύσετε το αρχείο, η παρουσίαση δεν θα έχει υπογραφές.

**Γίνεται το αρχείο "μόνο-ανάγνωση" μετά την υπογραφή;**

Όχι. Μια υπογραφή διατηρεί την ακεραιότητα και τη συντακτική ιδιότητα, αλλά δεν εμποδίζει τις επεξεργασίες. Για να περιορίσετε την επεξεργασία, συνδυάστε τη με ["Μόνο-ανάγνωση" ή έναν κωδικό](/slides/el/php-java/password-protected-presentation/).

**Θα εμφανίζεται η υπογραφή σωστά σε διαφορετικές εκδόσεις του PowerPoint;**

Η υπογραφή δημιουργείται για το κοντέινερ OOXML (PPTX). Οι σύγχρονες εκδόσεις του PowerPoint που υποστηρίζουν υπογραφές OOXML εμφανίζουν την κατάσταση τέτοιων υπογραφών σωστά.