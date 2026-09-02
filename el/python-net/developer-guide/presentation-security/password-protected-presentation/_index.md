---
title: Προστασία Παρουσιάσεων με Κωδικό σε Python
linktitle: Προστασία Κωδικού
type: docs
weight: 20
url: /el/python-net/password-protected-presentation/
keywords:
- παρουσίαση με προστασία κωδικού
- κωδικός άνοιγμα
- κρυπτογράφηση PowerPoint
- αποκρυπτογράφηση PowerPoint
- επικύρωση κωδικού παρουσίασης
- έλεγχος κωδικού παρουσίασης
- άνοιγμα κρυπτογραφημένης παρουσίασης
- αφαίρεση κρυπτογράφησης
- PowerPoint
- PPT
- PPTX
- παρουσίαση
- Python
- Aspose.Slides
description: "Κρυπτογραφήστε, ανιχνεύστε, επικυρώστε, ανοίξτε και αποκρυπτογραφήστε παρουσιάσεις PowerPoint PPT και PPTX προστατευμένες με κωδικό σε Python με το Aspose.Slides."
---
## **Επισκόπηση**

Ένας κωδικός πρόσβασης άνοιγμα κρυπτογραφεί μια παρουσίαση. Ο σωστός κωδικός πρόσβασης απαιτείται για τη φόρτωση και την προβολή του περιεχομένου της παρουσίασης, οπότε αυτή η προστασία παρέχει εμπιστευτικότητα.

Ο κωδικός πρόσβασης άνοιγμα διαφέρει από τον κωδικό προστασίας εγγραφής. Η προστασία εγγραφής περιορίζει την τροποποίηση αλλά δεν κρυπτογραφεί το περιεχόμενο ούτε εμποδίζει τη φόρτωση της παρουσίασης. Για τη διαχείριση κωδικών πρόσβασης για τροποποίηση παρουσιάσεων, δείτε [Προστασία Παρουσιάσεων από Εγγραφή](/slides/el/python-net/write-protected-presentation/).

Οι παρακάτω ροές εργασίας εφαρμόζονται τόσο σε παρουσιάσεις PPT όσο και PPTX. Τα παραδείγματα χρησιμοποιούν και τις δύο μορφές όταν η συμπεριφορά τους βάσει αρχείου ή ροής είναι σημαντική.

## **Κρυπτογράφηση Παρουσίασης με Κωδικό Άνοιγμα**

Χρησιμοποιήστε [ProtectionManager.encrypt](https://reference.aspose.com/slides/el/python-net/aspose.slides/protectionmanager/encrypt/) για να ορίσετε έναν κωδικό άνοιγμα. Στη συνέχεια, χρησιμοποιήστε [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/) για να αποθηκεύσετε την κρυπτογραφημένη παρουσίαση.

Το παρακάτω παράδειγμα κρυπτογραφεί μια παρουσίαση PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Φόρτωση Κρυπτογραφημένης Παρουσίασης**

Ορίστε [LoadOptions.password](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/password/) στον κωδικό άνοιγμα και περάστε τις επιλογές στο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κατά τη φόρτωση του αρχείου. Η φόρτωση αποτυγχάνει όταν απαιτείται κωδικός άνοιγμα αλλά ο δοθέν κωδικός λείπει ή είναι λανθασμένος.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Εργαστείτε με την αποκρυπτογραφημένη παρουσίαση.
    pass
```

## **Αφαίρεση Κρυπτογράφησης από Παρουσίαση**

Φορτώστε την παρουσίαση με τον κωδικό άνοιγμα, καλέστε [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/el/python-net/aspose.slides/protectionmanager/remove_encryption/), και αποθηκεύστε το αποτέλεσμα. Η αποθηκευμένη παρουσίαση μπορεί στη συνέχεια να φορτωθεί χωρίς κωδικό.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Επικύρωση Κωδικού Άνοιγμα Πριν τη Φόρτωση**

Χρησιμοποιήστε [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) για να αποκτήσετε το [PresentationInfo](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/) χωρίς να δημιουργήσετε μια πλήρη παρουσίαση. Ελέγξτε το [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/is_password_protected/) πριν ζητήσετε ή επικυρώσετε έναν κωδικό. Όταν υπάρχει προστασία, επικυρώστε την παρεχόμενη τιμή με το [PresentationInfo.check_password](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/check_password/).

### **Ροή Εργασίας με Διάδρομο Αρχείου**

Το παρακάτω παράδειγμα επικυρώνει έναν κωδικό άνοιγμα για ένα αρχείο PPTX, περνά την επικυρωμένη τιμή στο [LoadOptions.password](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/password/), και κατόπιν φορτώνει την πλήρη παρουσίαση:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **Ροή Εργασίας με Ροή**

Η υπερφόρτωση ροής του [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) παρέχει την ίδια ροή εργασίας. Επαναφέρετε τη θέση μιας αναζητήσιμης ροής πριν τη φόρτωση της πλήρους παρουσίασης από αυτή τη ροή.

Το παρακάτω παράδειγμα χρησιμοποιεί ένα αρχείο PPT:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **Τιμές Επιστροφής CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/check_password/) επιστρέφει `True` μόνο όταν η παρουσίαση διαθέτει κωδικό άνοιγμα και ο παρεχόμενος κωδικός είναι σωστός. Επιστρέφει `False` σε κάθε μία από τις παρακάτω περιπτώσεις:

- Ο κωδικός είναι λανθασμένος.
- Η παρουσίαση δεν διαθέτει κωδικό άνοιγμα.
- Ο παρεχόμενος κωδικός είναι `None` ή κενός.

Η συμπεριφορά είναι η ίδια για παρουσιάσεις PPT και PPTX.

## **Έλεγχος Αν Η Φορτωμένη Παρουσίαση Είναι Κρυπτογραφημένη**

Μετά τη φόρτωση μιας παρουσίασης με τον σωστό κωδικό, ελέγξτε το [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/el/python-net/aspose.slides/protectionmanager/is_encrypted/) για να επιβεβαιώσετε ότι η αρχική παρουσίαση ήταν κρυπτογραφημένη. Για την ανίχνευση προστασίας με κωδικό άνοιγμα πριν τη φόρτωση, χρησιμοποιήστε `PresentationInfo.is_password_protected` όπως φαίνεται παραπάνω.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Συστάσεις Ασφάλειας**

{{% alert color="warning" title="Security" %}}
Να μην καταγράφετε τους κωδικούς άνοιγμα ή να τους συμπεριλαμβάνετε σε διαγνωστικά μηνύματα. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης, κρατήστε τους κωδικούς στη μνήμη μόνο όσο χρειάζεται, και επαναχρησιμοποιήστε ένα επιτυχές αποτέλεσμα επικύρωσης όταν φορτώνετε άμεσα την παρουσίαση.
{{% /alert %}}

## **Προστασία Παρουσίασης με Κωδικό Online**

1. Ανοίξτε την εφαρμογή [Aspose.Slides Lock](https://products.aspose.app/slides/el/lock).
2. Επιλέξτε ή ανεβάστε την παρουσίαση.
3. Εισάγετε έναν κωδικό για προστασία προβολής.
4. Προαιρετικά, εισάγετε έναν ξεχωριστό κωδικό για προστασία επεξεργασίας.
5. Εφαρμόστε την προστασία και κατεβάστε το προκύπτων αρχείο.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/el/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/el/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποια είναι η διαφορά μεταξύ κωδικού άνοιγμα και κωδικού προστασίας εγγραφής;**

Ένας κωδικός άνοιγμα κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Ένας κωδικός προστασίας εγγραφής περιορίζει τη τροποποίηση χωρίς να κρυπτογραφεί το περιεχόμενο.

**Μπορώ να επικυρώσω έναν κωδικό άνοιγμα χωρίς να φορτώσω όλες τις διαφάνειες;**

Ναι. Αποκτήστε πληροφορίες παρουσίασης, ελέγξτε εάν υπάρχει προστασία κωδικού άνοιγμα και επικυρώστε τον κωδικό πριν δημιουργήσετε μια πλήρη παρουσίαση.

**Υποστηρίζουν οι ροές ελέγχου κωδικού και τα δύο PPT και PPTX;**

Ναι. Ο εντοπισμός και η επικύρωση κωδικού βάσει διαδρομής αρχείου ή ροής λειτουργούν με τον ίδιο τρόπο για παρουσιάσεις PPT και PPTX.