---
title: Προσθήκη Ψηφιακών Υπογραφών σε Παρουσιάσεις στο .NET
linktitle: Ψηφιακή Υπογραφή
type: docs
weight: 10
url: /el/net/digital-signature-in-powerpoint/
keywords:
- ψηφιακή υπογραφή
- ψηφιακό πιστοποιητικό
- αρχή πιστοποίησης
- πιστοποιητικό PFX
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να υπογράφετε ψηφιακά αρχεία PowerPoint & OpenDocument με το Aspose.Slides για .NET. Ασφαλίστε τις διαφάνειές σας σε δευτερόλεπτα με σαφή παραδείγματα κώδικα."
---
## **Εισαγωγή**

**Ψηφιακό πιστοποιητικό** χρησιμοποιείται για τη δημιουργία μιας παρουσίασης PowerPoint προστατευμένης με κωδικό, που σημειώνεται ως δημιουργηθείσα από έναν συγκεκριμένο οργανισμό ή άτομο. Το ψηφιακό πιστοποιητικό μπορεί να ληφθεί επικοινωνώντας με έναν εξουσιοδοτημένο οργανισμό – μια αρχή πιστοποιητικών. Αφού εγκατασταθεί το ψηφιακό πιστοποιητικό στο σύστημα, μπορεί να χρησιμοποιηθεί για την προσθήκη ψηφιακής υπογραφής στην παρουσίαση μέσω Αρχείο -> Πληροφορίες -> Προστασία Παρουσίασης:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Η παρουσίαση μπορεί να περιέχει περισσότερες από μία ψηφιακές υπογραφές. Αφού προστεθεί η ψηφιακή υπογραφή στην παρουσίαση, θα εμφανιστεί ένα ειδικό μήνυμα στο PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Για να υπογράψετε την παρουσίαση ή να ελέγξετε την αυθεντικότητα των υπογραφών της, το **Aspose.Slides API** παρέχει τη διεπαφή [**IDigitalSignature**](https://reference.aspose.com/slides/el/net/aspose.slides/idigitalsignature), τη διεπαφή [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/el/net/aspose.slides/IDigitalSignatureCollection) και την ιδιότητα [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/properties/digitalsignatures). Προς το παρόν, οι ψηφιακές υπογραφές υποστηρίζονται μόνο για τη μορφή PPTX.

## **Προσθήκη ψηφιακής υπογραφής από πιστοποιητικό PFX**

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να προσθέσετε ψηφιακή υπογραφή από πιστοποιητικό PFX:

1. Ανοίξτε το αρχείο PFX και περάστε τον κωδικό PFX στο αντικείμενο [**DigitalSignature**](https://reference.aspose.com/slides/el/net/aspose.slides/digitalsignature) .
1. Προσθέστε τη δημιουργημένη υπογραφή στο αντικείμενο παρουσίασης.

```c#
using (Presentation pres = new Presentation())
{
    // Δημιουργήστε αντικείμενο DigitalSignature με αρχείο PFX και κωδικό PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Σχόλιο νέας ψηφιακής υπογραφής
    signature.Comments = "Aspose.Slides digital signing test.";

    // Προσθήκη ψηφιακής υπογραφής στην παρουσίαση
    pres.DigitalSignatures.Add(signature);

    // Αποθήκευση παρουσίασης
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```



Τώρα είναι δυνατόν να ελέγξετε εάν η παρουσίαση έχει ψηφιακά υπογραφεί και δεν έχει τροποποιηθεί:

```c#
// Άνοιγμα παρουσίασης
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // Έλεγχος εάν όλες οι ψηφιακές υπογραφές είναι έγκυρες
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```

## **FAQ**

**Μπορώ να αφαιρέσω υπάρχουσες υπογραφές από ένα αρχείο;**

Ναι. Η συλλογή ψηφιακών υπογραφών υποστηρίζει την αφαίρεση μεμονωμένων στοιχείων και τον καθαρισμό της εντελώς· μετά την αποθήκευση του αρχείου, η παρουσίαση δεν θα έχει υπογραφές.

**Γίνεται το αρχείο "μόνο για ανάγνωση" μετά την υπογραφή;**

Όχι. Μια υπογραφή διατηρεί την ακεραιότητα και τη συγγραφή, αλλά δεν εμποδίζει τις επεμβάσεις. Για να περιορίσετε την επεξεργασία, συνδυάστε τη με ["Μόνο για ανάγνωση" ή κωδικός](/slides/el/net/password-protected-presentation/).

**Θα εμφανίζεται σωστά η υπογραφή σε διαφορετικές εκδόσεις του PowerPoint;**

Η υπογραφή δημιουργείται για το δοχείο OOXML (PPTX). Οι σύγχρονες εκδόσεις του PowerPoint που υποστηρίζουν υπογραφές OOXML εμφανίζουν σωστά την κατάσταση αυτών των υπογραφών.