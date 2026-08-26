---
title: Προστασία Εγγραφής Παρουσιάσεων σε Python
linktitle: Προστασία Εγγραφής
type: docs
weight: 25
url: /el/python-net/write-protected-presentation/
keywords:
- προστασία εγγραφής
- προστασία εγγραφής PowerPoint
- κωδικός για τροποποίηση
- περιορισμός επεξεργασίας παρουσίασης
- αφαίρεση προστασίας εγγραφής
- επικύρωση κωδικού τροποποίησης
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ορίστε, εντοπίστε, επικυρώστε και αφαιρέστε κωδικούς προστασίας εγγραφής σε παρουσιάσεις PowerPoint PPT και PPTX χρησιμοποιώντας το Aspose.Slides για Python."
---
## **Εισαγωγή**

Ένας κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση μιας παρουσίασης, αλλά δεν κρυπτογραφεί το περιεχόμενό της. Οι χρήστες μπορούν να φορτώσουν και να προβάλλουν μια παρουσίαση με προστασία εγγραφής χωρίς τον κωδικό. Ανάλογα με την εφαρμογή, μπορεί επίσης να είναι σε θέση να επεξεργαστούν το περιεχόμενο και να το αποθηκεύσουν υπό διαφορετικό όνομα, έτσι η προστασία εγγραφής δεν πρέπει να θεωρείται μηχανισμός εμπιστευτικότητας.

Ένας κωδικός ανοίγματος εξυπηρετεί διαφορετικό σκοπό: κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Για να κρυπτογραφήσετε μια παρουσίαση ή να επικυρώσετε έναν κωδικό ανοίγματος, δείτε [Password‑Protect Presentations](/slides/el/python‑net/password‑protected‑presentation/).

Οι ροές εργασίας σε αυτό το άρθρο ισχύουν και για παρουσιάσεις PPT και PPTX. Τα παραδείγματα χρησιμοποιούν αρχεία PPTX· όταν αποθηκεύετε σε PPT, χρησιμοποιήστε την επέκταση `.ppt` και την αντίστοιχη μορφή αποθήκευσης PPT.

## **Ορισμός προστασίας εγγραφής σε παρουσίαση**

Χρησιμοποιήστε το [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/el/python-net/aspose.slides/protectionmanager/set_write_protection/) για να ορίσετε έναν κωδικό για την τροποποίηση μιας παρουσίασης. Η αποθήκευση της παρουσίασης διατηρεί τη ρύθμιση προστασίας.

Το παρακάτω παράδειγμα ορίζει προστασία εγγραφής σε μια παρουσίαση PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Φόρτωση παρουσίασης με προστασία εγγραφής**

Επειδή η προστασία εγγραφής δεν κρυπτογραφεί το περιεχόμενο της παρουσίασης, δεν απαιτείται κωδικός για τη φόρτωση της παρουσίασης. Ο κωδικός είναι σχετικός μόνο κατά την επαλήθευση της εξουσιοδότησης για την τροποποίηση της προστατευμένης παρουσίασης.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Μην περάσετε έναν κωδικό προστασίας εγγραφής στο [LoadOptions.password](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/password/). Η ιδιότητα αυτή δέχεται έναν κωδικό ανοίγματος για κρυπτογραφημένο περιεχόμενο. Εάν μια παρουσίαση διαθέτει και τους δύο τύπους προστασίας, δώστε τον κωδικό ανοίγματος για να την φορτώσετε και διαχειριστείτε τον κωδικό προστασίας εγγραφής ξεχωριστά.

## **Αφαίρεση προστασίας εγγραφής από παρουσίαση**

Χρησιμοποιήστε το [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/el/python-net/aspose.slides/protectionmanager/remove_write_protection/) για να αφαιρέσετε τον περιορισμό τροποποίησης, και στη συνέχεια αποθηκεύστε την παρουσίαση.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Έλεγχος εάν μια παρουσίαση είναι προστατευμένη από εγγραφή**

Για να επιθεωρήσετε ένα αρχείο χωρίς να δημιουργήσετε μια πλήρη παρουσίαση [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/), καλέστε το [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) και ελέγξτε το [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/is_write_protected/). Η ιδιότητα χρησιμοποιεί το [NullableBool](https://reference.aspose.com/slides/el/python-net/aspose.slides/nullablebool/) και επιστρέφει `NullableBool.TRUE` όταν ανιχνεύεται προστασία εγγραφής.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

Η έκδοση με ροή του [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) παρέχει τις ίδιες πληροφορίες για μια παρουσίαση που παρέχεται ως ροή.

## **Επικύρωση κωδικού προστασίας εγγραφής**

Χρησιμοποιήστε το [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/check_write_protection/) για να επικυρώσετε έναν κωδικό τροποποίησης χωρίς να φορτώσετε την πλήρη παρουσίαση. Ελέγξτε πρώτα το [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/is_write_protected/) ώστε η εφαρμογή να ζητήσει ή να επικυρώσει έναν κωδικό μόνο όταν υπάρχει προστασία εγγραφής.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/check_write_protection/) επικυρώνει μόνο τον κωδικό προστασίας εγγραφής. Δεν επικυρώνει έναν κωδικό ανοίγματος ούτε προσδιορίζει αν μπορεί να φορτωθεί κρυπτογραφημένο περιεχόμενο. Αντίστροφα, το [PresentationInfo.check_password](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/check_password/) επικυρώνει μόνο έναν κωδικό ανοίγματος. Εάν μια πλήρης παρουσίαση έχει ήδη φορτωθεί, το [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/el/python-net/aspose.slides/protectionmanager/check_write_protection/) παρέχει τον ισοδύναμο έλεγχο προστασίας εγγραφής μέσω του διαχειριστή προστασίας του.

Σε παραγωγικές εφαρμογές, μην καταγράφετε κωδικούς ή τους ενσωματώνετε σε διαγνωστικά μηνύματα. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης και κρατήστε τους κωδικούς στη μνήμη μόνο όσο είναι απαραίτητο.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/el/python-net/password-protected-presentation/)
- [Read-Only Presentations](/slides/el/python-net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/el/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Κρυπτογραφεί η προστασία εγγραφής μια παρουσίαση;**

Όχι. Περιορίζει την τροποποίηση, αλλά αφήνει το περιεχόμενο της παρουσίασης διαθέσιμο για φόρτωση και προβολή.

**Απαιτείται ο κωδικός προστασίας εγγραφής για το άνοιγμα μιας παρουσίασης;**

Όχι. Μόνο ένας κωδικός ανοίγματος απαιτείται για τη φόρτωση του κρυπτογραφημένου περιεχομένου της παρουσίασης.

**Μπορεί μια παρουσίαση να έχει και κωδικό ανοίγματος και κωδικό προστασίας εγγραφής;**

Ναι. Παρέχετε τον κωδικό ανοίγματος μέσω των επιλογών φόρτωσης για να ανοίξετε την κρυπτογραφημένη παρουσίαση και επικυρώστε τον κωδικό προστασίας εγγραφής ξεχωριστά όταν απαιτείται εξουσιοδότηση τροποποίησης.