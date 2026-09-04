---
title: Προστασία Παρουσιών με Κωδικό Πρόσβασης σε Python
linktitle: Προστασία Κωδικού Πρόσβασης
type: docs
weight: 20
url: /el/python-net/password-protected-presentation/
keywords:
- παρουσίαση με προστασία κωδικού
- κωδικός πρόσβασης ανοίγματος
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
description: "Κρυπτογραφήστε, εντοπίστε, επικυρώστε, ανοίξτε και αποκρυπτογραφήστε παρουσιάσεις PowerPoint PPT και PPTX με προστασία κωδικού πρόσβασης σε Python με Aspose.Slides."
---
## **Επισκόπηση**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί μια παρουσίαση. Ο σωστός κωδικός πρόσβασης απαιτείται για τη φόρτωση και την προβολή του περιεχομένου της παρουσίασης, έτσι η προστασία αυτή παρέχει διαφύλαξη.

Ένας κωδικός πρόσβασης ανοίγματος διαφέρει από έναν κωδικό προστασίας εγγραφής. Η προστασία εγγραφής περιορίζει την τροποποίηση αλλά δεν κρυπτογραφεί το περιεχόμενο ή εμποδίζει τη φόρτωση της παρουσίασης. Για τη διαχείριση κωδικών πρόσβασης για τροποποίηση παρουσιάσεων, δείτε [Write-Protect Presentations](/slides/el/python-net/write-protected-presentation/).

Οι παρακάτω ροές εργασίας ισχύουν για παρουσιάσεις PPT και PPTX. Τα παραδείγματα χρησιμοποιούν και τις δύο μορφές όπου η συμπεριφορά με βάση το αρχείο και το ρεύμα είναι σημαντική.

## **Κρυπτογράφηση Παρουσίασης με Κωδικό Πρόσβασης Ανοίγματος**

Χρησιμοποιήστε το [ProtectionManager.encrypt](https://reference.aspose.com/slides/el/python-net/aspose.slides/protectionmanager/encrypt/) για να ορίσετε έναν κωδικό πρόσβασης ανοίγματος. Στη συνέχεια, χρησιμοποιήστε το [Presentation.save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/) για να αποθηκεύσετε την κρυπτογραφημένη παρουσίαση.

Το παρακάτω παράδειγμα κρυπτογραφεί μια παρουσίαση PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Διατήρηση Δημοσίων Ιδιοτήτων Εγγράφου**

Από προεπιλογή, το Aspose.Slides περιλαμβάνει τις ιδιότητες του εγγράφου στην κρυπτογράφηση της παρουσίασης. Η ιδιότητα [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/el/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) ελέγχει αυτή τη συμπεριφορά ανεξάρτητα από την κρυπτογράφηση του περιεχομένου των διαφανειών. Ορίστε την σε `False` πριν καλέσετε το [ProtectionManager.encrypt](https://reference.aspose.com/slides/el/python-net/aspose.slides/protectionmanager/encrypt/) όταν ένα σύστημα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων πρέπει να διαβάσει μεταδεδομένα χωρίς τον κωδικό πρόσβασης ανοίγματος.

Το παρακάτω παράδειγμα δημιουργεί μια κρυπτογραφημένη παρουσίαση PPTX αφήνοντας τις ενσωματωμένες ιδιότητες εγγράφου δημόσιες:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

Ο ορισμός του `encrypt_document_properties` σε `False` δεν καθιστά δημόσιες τις διαφάνειες, τους κύριους, τις διατάξεις, τα σχήματα, τα μέσα ή άλλο περιεχόμενο της παρουσίασης. Επηρεάζει μόνο τις ιδιότητες του εγγράφου. Για να διαβάσετε αυτές τις ιδιότητες χωρίς να φορτώσετε το κρυπτογραφημένο περιεχόμενο, δείτε [Manage Presentation Properties](/slides/el/python-net/presentation-properties/).

## **Φόρτωση Κρυπτογραφημένης Παρουσίασης**

Ορίστε το [LoadOptions.password](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/password/) στον κωδικό πρόσβασης ανοίγματος και περάστε τις επιλογές στο [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/) κατά τη φόρτωση του αρχείου. Η φόρτωση αποτυγχάνει όταν απαιτείται κωδικός πρόσβασης ανοίγματος αλλά ο παρεχόμενος κωδικός λείπει ή είναι λανθασμένος.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Εργασία με την αποκρυπτογραφημένη παρουσίαση.
    pass
```

## **Αφαίρεση Κρυπτογράφησης από Παρουσίαση**

Φορτώστε την παρουσίαση με τον κωδικό πρόσβασης ανοίγματος, καλέστε το [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/el/python-net/aspose.slides/protectionmanager/remove_encryption/), και αποθηκεύστε το αποτέλεσμα. Η αποθηκευμένη παρουσίαση μπορεί στη συνέχεια να φορτωθεί χωρίς κωδικό.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Επικύρωση Κωδικού Πρόσβασης Ανοίγματος Πριν τη Φόρτωση**

Χρησιμοποιήστε το [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) για να λάβετε το [PresentationInfo](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/) χωρίς να δημιουργήσετε μια πλήρη παρουσίαση. Ελέγξτε το [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/is_password_protected/) πριν ζητήσετε ή επικυρώσετε έναν κωδικό πρόσβασης. Όταν υπάρχει προστασία, επικυρώστε την παρεχόμενη τιμή με το [PresentationInfo.check_password](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/check_password/).

### **Ροή Εργασίας με Διαδρομή Αρχείου**

Το παρακάτω παράδειγμα επικυρώνει έναν κωδικό πρόσβασης ανοίγματος για ένα αρχείο PPTX, περνά την επικυρωμένη τιμή στο [LoadOptions.password](https://reference.aspose.com/slides/el/python-net/aspose.slides/loadoptions/password/), και στη συνέχεια φορτώνει την πλήρη παρουσίαση:

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

### **Ροή Εργασίας με Ρεύμα**

Η υπερφόρτωση ρεύματος του [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationfactory/get_presentation_info/) παρέχει την ίδια ροή εργασίας. Επαναφέρετε τη θέση ενός αναζητήσιμου ρεύματος πριν φορτώσετε την πλήρη παρουσίαση από αυτό το ρεύμα.

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

[PresentationInfo.check_password](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentationinfo/check_password/) επιστρέφει `True` μόνο όταν η παρουσίαση έχει κωδικό πρόσβασης ανοίγματος και ο παρεχόμενος κωδικός είναι σωστός. Επιστρέφει `False` σε κάθε μία από τις ακόλουθες περιπτώσεις:

- Ο κωδικός πρόσβασης είναι λανθασμένος.
- Η παρουσίαση δεν έχει κωδικό πρόσβασης ανοίγματος.
- Ο παρεχόμενος κωδικός είναι `None` ή κενός.

Η συμπεριφορά είναι η ίδια για παρουσιάσεις PPT και PPTX.

## **Έλεγχος Εάν Η Φορτωμένη Παρουσίαση Είναι Κρυπτογραφημένη**

Μετά τη φόρτωση μιας παρουσίασης με τον σωστό κωδικό, ελέγξτε το [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/el/python-net/aspose.slides/protectionmanager/is_encrypted/) για να επιβεβαιώσετε ότι η πηγή παρουσίασης ήταν κρυπτογραφημένη. Για να εντοπίσετε προστασία κωδικού πρόσβασης ανοίγματος πριν τη φόρτωση, χρησιμοποιήστε το `PresentationInfo.is_password_protected` όπως φαίνεται παραπάνω.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Συστάσεις Ασφαλείας**

{{% alert color="warning" title="Ασφάλεια" %}}
Μην καταγράφετε τους κωδικούς πρόσβασης ανοίγματος ή τους συμπεριλαμβάνετε σε μηνύματα διάγνωσης. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης, κρατήστε τους κωδικούς στη μνήμη μόνο όσο είναι απαραίτητο, και επαναχρησιμοποιήστε ένα επιτυχημένο αποτέλεσμα επικύρωσης όταν φορτώνετε αμέσως την παρουσίαση.

Οι δημόσιες ιδιότητες του εγγράφου μπορεί να αποκαλύψουν ονόματα συγγραφέων, τίτλους, θέματα, λέξεις-κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές, ακόμη και όταν το περιεχόμενο της παρουσίασης είναι κρυπτογραφημένο. Κρυπτογραφήστε τα ευαίσθητα μεταδεδομένα μαζί με την παρουσίαση. Η διατήρηση των ιδιοτήτων δημόσιες θα πρέπει να είναι μια σαφής απόφαση που λαμβάνεται μόνο όταν τα συστήματα πρέπει να ευρετηριάσουν, ταξινομήσουν, αναζητήσουν ή διαχειριστούν το αρχείο χωρίς κωδικό πρόσβασης ανοίγματος.
{{% /alert %}}

## **Προστασία Παρουσίασης με Κωδικό Πρόσβασης Online**

1. Ανοίξτε την εφαρμογή [Aspose.Slides Lock](https://products.aspose.app/slides/el/lock).
2. Επιλέξτε ή ανεβάστε την παρουσίαση.
3. Καταχωρίστε έναν κωδικό πρόσβασης για προστασία προβολής.
4. Προαιρετικά, καταχωρίστε έναν ξεχωριστό κωδικό πρόσβασης για προστασία επεξεργασίας.
5. Εφαρμόστε την προστασία και κατεβάστε το προκύπτον αρχείο.

{{% alert color="info" title="Δείτε επίσης" %}}
- [Προστασία Εγγραφής Παρουσιών](/slides/el/python-net/write-protected-presentation/)
- [Ψηφιακή Υπογραφή στο PowerPoint](/slides/el/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ κωδικού πρόσβασης ανοίγματος και κωδικού προστασίας εγγραφής;**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Ένας κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση χωρίς να κρυπτογραφεί το περιεχόμενο.

**Μπορώ να επικυρώσω έναν κωδικό πρόσβασης ανοίγματος χωρίς να φορτώσω όλες τις διαφάνειες;**

Ναι. Λάβετε πληροφορίες παρουσίασης, ελέγξτε αν υπάρχει προστασία με κωδικό πρόσβασης ανοίγματος και επικυρώστε τον κωδικό πριν δημιουργήσετε μια πλήρη παρουσίαση.

**Μπορεί μια εφαρμογή να διαβάσει μεταδεδομένα χωρίς τον κωδικό πρόσβασης ανοίγματος;**

Ναι, αλλά μόνο όταν η παρουσίαση κρυπτογραφήθηκε με το `encrypt_document_properties` ορισμένο σε `False`. Η εφαρμογή πρέπει τότε να χρησιμοποιήσει τη λειτουργία φόρτωσης μόνο-ιδιοτήτων-εγγράφου που περιγράφεται στο [Manage Presentation Properties](/slides/el/python-net/presentation-properties/).

**Υποστηρίζουν οι ροές ελέγχου κωδικού πρόσβασης τόσο PPT όσο και PPTX;**

Ναι. Η ανίχνευση και η επικύρωση κωδικού πρόσβασης με βάση τη διαδρομή αρχείου ή το ρεύμα συμπεριφέρονται με τον ίδιο τρόπο για παρουσιάσεις PPT και PPTX.