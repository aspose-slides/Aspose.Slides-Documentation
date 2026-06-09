---
title: Προσθήκη Ψηφιακών Υπογραφών σε Παρουσιάσεις σε C++
linktitle: Ψηφιακή Υπογραφή
type: docs
weight: 10
url: /el/cpp/digital-signature-in-powerpoint/
keywords:
- ψηφιακή υπογραφή
- ψηφιακό πιστοποιητικό
- αρχή πιστοποίησης
- πιστοποιητικό PFX
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να υπογράφετε ψηφιακά αρχεία PowerPoint & OpenDocument με το Aspose.Slides για C++. Εξασφαλίστε τις διαφάνειές σας σε δευτερόλεπτα με σαφή παραδείγματα κώδικα."
---
## **Εισαγωγή**

**Ψηφιακό πιστοποιητικό** χρησιμοποιείται για τη δημιουργία μιας παρουσίασης PowerPoint προσεκτικά κωδικοποιημένης, σημειωμένης ως δημιουργημένη από συγκεκριμένο οργανισμό ή άτομο. Το ψηφιακό πιστοποιητικό μπορεί να ληφθεί επικοινωνώντας με έναν εξουσιοδοτημένο οργανισμό - μια αρχή πιστοποίησης. Αφού εγκατασταθεί το ψηφιακό πιστοποιητικό στο σύστημα, μπορεί να χρησιμοποιηθεί για την προσθήκη ψηφιακής υπογραφής στην παρουσίαση μέσω Αρχείο -> Πληροφορίες -> Προστασία Παρουσίασης:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Η παρουσίαση μπορεί να περιέχει περισσότερες από μία ψηφιακές υπογραφές. Αφού προστεθεί η ψηφιακή υπογραφή στην παρουσίαση, θα εμφανιστεί ένα ειδικό μήνυμα στο PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Για να υπογράψετε την παρουσίαση ή να ελέγξετε την αυθεντικότητα των υπογραφών της παρουσίασης, το **Aspose.Slides API** παρέχει το interface [**IDigitalSignature**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_digital_signature), το interface [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_digital_signature_collection) και τη μέθοδο [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1). Επί του παρόντος, οι ψηφιακές υπογραφές υποστηρίζονται μόνο για τη μορφή PPTX.

## **Προσθήκη ψηφιακής υπογραφής από πιστοποιητικό PFX**
Το παρακάτω δείγμα κώδικα δείχνει πώς να προσθέσετε ψηφιακή υπογραφή από ένα πιστοποιητικό PFX:

1. Ανοίξτε το αρχείο PFX και περάστε τον κωδικό PFX στο αντικείμενο [**DigitalSignature**](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.digital_signature).
1. Προσθέστε τη δημιουργημένη υπογραφή στο αντικείμενο παρουσίασης.

``` cpp
auto pres = System::MakeObject<Presentation>();

// Δημιουργία αντικειμένου DigitalSignature με αρχείο PFX και κωδικό PFX 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Σχόλιο νέας ψηφιακής υπογραφής
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Προσθήκη ψηφιακής υπογραφής στην παρουσίαση
pres->get_DigitalSignatures()->Add(signature);

// Αποθήκευση παρουσίασης
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Τώρα είναι δυνατόν να ελέγξετε εάν η παρουσίαση υπογράφηκε ψηφιακά και δεν έχει τροποποιηθεί:

``` cpp
// Άνοιγμα παρουσίασης
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Έλεγχος εάν όλες οι ψηφιακές υπογραφές είναι έγκυρες
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να αφαιρέσω υπάρχουσες υπογραφές από ένα αρχείο;**

Ναι. Η συλλογή ψηφιακών υπογραφών υποστηρίζει [αφαίρεση μεμονωμένων στοιχείων](https://reference.aspose.com/slides/el/cpp/aspose.slides/digitalsignaturecollection/removeat/) και [εκαθάριση ολόκληρης της συλλογής](https://reference.aspose.com/slides/el/cpp/aspose.slides/digitalsignaturecollection/clear/); μετά την αποθήκευση του αρχείου, η παρουσίαση δεν θα έχει υπογραφές.

**Γίνεται το αρχείο "μόνο για ανάγνωση" μετά την υπογραφή;**

Όχι. Μια υπογραφή διατηρεί την ακεραιότητα και τη συγγραφικότητα αλλά δεν εμποδίζει τις επεξεργασίες. Για να περιορίσετε την επεξεργασία, συνδυάστε τη με την επιλογή [\"Μόνο για ανάγνωση\" ή κωδικός πρόσβασης](/slides/el/cpp/password-protected-presentation/).

**Θα εμφανίζεται σωστά η υπογραφή σε διαφορετικές εκδόσεις του PowerPoint;**

Η υπογραφή δημιουργείται για το δοχείο OOXML (PPTX). Οι σύγχρονες εκδόσεις του PowerPoint που υποστηρίζουν υπογραφές OOXML εμφανίζουν σωστά την κατάσταση τέτοιων υπογραφών.