---
title: Πρ��σθήκη Ψηφιακών Υπογραφών σε Παρουσιάσεις με Python
linktitle: Ψηφιακή Υπογραφή
type: docs
weight: 10
url: /el/python-net/digital-signature-in-powerpoint/
keywords:
- ψηφιακή υπογραφή
- ψηφιακό πιστοποιητικό
- αρχή πιστοποιήσεων
- πιστοποιητικό PFX
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς να υπογράφετε ψηφιακά αρχεία PowerPoint & OpenDocument με το Aspose.Slides για Python μέσω .NET. Ασφαλίστε τις διαφάνειές σας σε δευτερόλεπτα με σαφή παραδείγματα κώδικα."
---
## **Εισαγωγή**

**Ψηφιακό πιστοποιητικό** χρησιμοποιείται για τη δημιουργία μίας παρουσίασης PowerPoint προστατευμένης με κωδικό, η οποία σημειώνεται ως δημιουργημένη από συγκεκριμένη οργάνωση ή άτομο. Το ψηφιακό πιστοποιητικό μπορεί να ληφθεί επικοινωνώντας με μια εξουσιοδοτημένη οργάνωση – μια αρχή πιστοποιήσεων. Μετά την εγκατάσταση του ψηφιακού πιστοποιητικού στο σύστημα, μπορεί να χρησιμοποιηθεί για την προσθήκη ψηφιακής υπογραφής στην παρουσίαση μέσω File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Η παρουσίαση μπορεί να περιέχει περισσότερες από μία ψηφιακές υπογραφές. Αφού προστεθεί η ψηφιακή υπογραφή στην παρουσίαση, ένα ειδικό μήνυμα θα εμφανιστεί στο PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Για να υπογράψετε την παρουσίαση ή να ελέγξετε την αυθεντικότητα των υπογραφών της παρουσίασης, **Aspose.Slides API** παρέχει [**DigitalSignature**](https://reference.aspose.com/slides/el/python-net/aspose.slides/digitalsignature/) κλάση, [**DigitalSignatureCollection**](https://reference.aspose.com/slides/el/python-net/aspose.slides/DigitalSignatureCollection/) κλάση και [**Presentation.digital_signatures**](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/digital_signatures/) ιδιότητα. Προς το παρόν, οι ψηφιακές υπογραφές υποστηρίζονται μόνο για τη μορφή PPTX.

## **Προσθήκη Ψηφιακής Υπογραφής από Πιστοποιητικό PFX**

Το παρακάτω δείγμα κώδικα δείχνει πώς να προσθέσετε ψηφιακή υπογραφή από ένα πιστοποιητικό PFX:

1. Ανοίξτε το αρχείο PFX και περάστε τον κωδικό πρόσβασης PFX στο αντικείμενο [**DigitalSignature**](https://reference.aspose.com/slides/el/python-net/aspose.slides/digitalsignature/).
1. Προσθέστε τη δημιουργημένη υπογραφή στο αντικείμενο παρουσίασης.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Δημιουργία αντικειμένου DigitalSignature με αρχείο PFX και κωδικό PFX
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Σχόλιο νέας ψηφιακής υπογραφής
    signature.comments = "Aspose.Slides digital signing test."

    # Προσθήκη ψηφιακής υπογραφής στην παρουσίαση
    pres.digital_signatures.add(signature)

    # Αποθήκευση παρουσίασης
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Τώρα είναι δυνατόν να ελέγξετε εάν η παρουσίαση είχε ψηφιακή υπογραφή και δεν έχει τροποποιηθεί:

```py
# Άνοιγμα παρουσίασης
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Έλεγχος εάν όλες οι ψηφιακές υπογραφές είναι έγκυρες
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **Συχνές Ερωτήσεις**

**Μπορώ να αφαιρέσω υπάρχουσες υπογραφές από ένα αρχείο;**

Ναι. Η συλλογή ψηφιακών υπογραφών υποστηρίζει το [removing individual items](https://reference.aspose.com/slides/el/python-net/aspose.slides/digitalsignaturecollection/remove_at/) και το [clearing it entirely](https://reference.aspose.com/slides/el/python-net/aspose.slides/digitalsignaturecollection/clear/); μετά την αποθήκευση του αρχείου, η παρουσίαση δεν θα έχει υπογραφές.

**Γίνεται το αρχείο "μόνο για ανάγνωση" μετά την υπογραφή;**

Όχι. Μια υπογραφή διατηρεί την ακεραιότητα και τη συγγραφή αλλά δεν εμποδίζει τις επεξεργασίες. Για περιορισμό επεξεργασίας, συνδυάστε το με το ["Read-only" or a password](/slides/el/python-net/password-protected-presentation/).

**Θα εμφανίζεται σωστά η υπογραφή σε διαφορετικές εκδόσεις του PowerPoint;**

Η υπογραφή δημιουργείται για το κοντέινερ OOXML (PPTX). Σύγχρονες εκδόσεις του PowerPoint που υποστηρίζουν υπογραφές OOXML εμφανίζουν σωστά την κατάσταση αυτών των υπογραφών.