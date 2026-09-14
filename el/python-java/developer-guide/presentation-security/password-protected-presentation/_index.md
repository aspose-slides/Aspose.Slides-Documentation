---
title: "Προστασία Παρουσιάσεων με Κωδικό Πρόσβασης σε Python"
linktitle: "Προστασία Κωδικού Πρόσβασης"
type: docs
weight: 20
url: /el/python-java/password-protected-presentation/
keywords:
- "παρουσίαση με κωδικό πρόσβασης"
- "κωδικός πρόσβασης ανοίγματος"
- "κρυπτογράφηση PowerPoint"
- "αποκρυπτογράφηση PowerPoint"
- "επικύρωση κωδικού παρουσίασης"
- "έλεγχος κωδικού παρουσίασης"
- "άνοιγμα κρυπτογραφημένης παρουσίασης"
- "αφαίρεση κρυπτογράφησης"
- "PowerPoint"
- "PPT"
- "PPTX"
- "παρουσίαση"
- "Python"
- "Aspose.Slides"
description: "Κρυπτογραφήστε, εντοπίστε, επικυρώστε, ανοίξτε και αποκρυπτογραφήστε παρουσιάσεις PowerPoint PPT και PPTX με κωδικό πρόσβασης χρησιμοποιώντας το Aspose.Slides για Python μέσω Java."
---
## **Επισκόπηση**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί μια παρουσίαση. Ο σωστός κωδικός απαιτείται για τη φόρτωση και προβολή του περιεχομένου της παρουσίασης, επομένως αυτή η προστασία παρέχει εμπιστευτικότητα.

Ένας κωδικός πρόσβασης ανοίγματος είναι διαφορετικός από έναν κωδικό προστασίας εγγραφής. Η προστασία εγγραφής περιορίζει την τροποποίηση αλλά δεν κρυπτογραφεί το περιεχόμενο ή εμποδίζει τη φόρτωση της παρουσίασης. Για να διαχειριστείτε κωδικούς για την τροποποίηση παρουσιάσεων, δείτε [Προστασία Εγγραφής Παρουσιάσεων](/slides/el/python-java/write-protected-presentation/).

Οι παρακάτω ροές εργασίας ισχύουν και για τις παρουσιάσεις PPT και PPTX. Τα παραδείγματα χρησιμοποιούν και τις δύο μορφές όπου η συμπεριφορά με βάση το αρχείο και τη ροή είναι σημαντική.

## **Κρυπτογράφηση Παρουσίασης με Κωδικό Πρόσβασης Ανοίγματος**

Χρησιμοποιήστε [ProtectionManager.encrypt] για να ορίσετε έναν κωδικό πρόσβασης ανοίγματος. Στη συνέχεια, χρησιμοποιήστε [Presentation.save] για να αποθηκεύσετε την κρυπτογραφημένη παρουσίαση.

Το παρακάτω παράδειγμα κρυπτογραφεί μια παρουσίαση PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Διατήρηση Δημοσίων Ιδιοτήτων Εγγράφου**

Από προεπιλογή, το Aspose.Slides περιλαμβάνει τις ιδιότητες του εγγράφου στην κρυπτογράφηση της παρουσίασης. Η μέθοδος [ProtectionManager.setEncryptDocumentProperties] ελέγχει αυτή τη συμπεριφορά ανεξάρτητα από την κρυπτογράφηση του περιεχομένου των διαφανειών. Περάστε το `False` πριν καλέσετε τη [ProtectionManager.encrypt] όταν ένα σύστημα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων πρέπει να διαβάσει μεταδεδομένα χωρίς τον κωδικό πρόσβασης ανοίγματος.

Το παρακάτω παράδειγμα δημιουργεί μια κρυπτογραφημένη παρουσίαση PPTX ενώ αφήνει τις ενσωματωμένες ιδιότητες εγγράφου δημόσιες:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Η μεταβίβαση του `False` στη [ProtectionManager.setEncryptDocumentProperties] δεν κάνει τις διαφάνειες, τους κύριους, τις διατάξεις, τα σχήματα, τα μέσα ή άλλο περιεχόμενο της παρουσίασης δημόσια. Επηρεάζει μόνο τις ιδιότητες του εγγράφου. Για να διαβάσετε αυτές τις ιδιότητες χωρίς να φορτώσετε το κρυπτογραφημένο περιεχόμενο, δείτε [Manage Presentation Properties](/slides/el/python-java/presentation-properties/).

## **Φόρτωση Κρυπτογραφημένης Παρουσίασης**

Ορίστε το [LoadOptions.setPassword] στον κωδικό πρόσβασης ανοίγματος και περάστε τις επιλογές στη [Presentation] όταν φορτώνετε το αρχείο. Η φόρτωση αποτυγχάνει όταν απαιτείται κωδικός πρόσβασης ανοίγματος αλλά ο παρεχόμενος κωδικός λείπει ή είναι λανθασμένος.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # Εργαστείτε με την αποκρυπτογραφημένη παρουσίαση.
    pass
finally:
    presentation.dispose()
```

## **Αφαίρεση Κρυπτογράφησης από Παρουσίαση**

Φορτώστε την παρουσίαση με τον κωδικό πρόσβασης ανοίγματος, καλέστε τη [ProtectionManager.removeEncryption] και αποθηκεύστε το αποτέλεσμα. Η αποθηκευμένη παρουσίαση μπορεί στη συνέχεια να φορτωθεί χωρίς κωδικό.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Επικύρωση Κωδικού Πρόσβασης Ανοίγματος Πριν τη Φόρτωση**

Χρησιμοποιήστε τη [PresentationFactory.getPresentationInfo] για να αποκτήσετε το [PresentationInfo] χωρίς να δημιουργήσετε ένα πλήρες αντικείμενο παρουσίασης. Ελέγξτε το [PresentationInfo.isPasswordProtected] πριν ζητήσετε ή επικυρώσετε έναν κωδικό. Όταν υπάρχει προστασία, επικυρώστε την παρεχόμενη τιμή με τη [PresentationInfo.checkPassword].

### **Ροή Εργασίας με Διαδρομή Αρχείου**

Το παρακάτω παράδειγμα επικυρώνει έναν κωδικό πρόσβασης ανοίγματος για αρχείο PPTX, περνά την επικυρωμένη τιμή στο [LoadOptions.setPassword] και στη συνέχεια φορτώνει την πλήρη παρουσίαση:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **Ροή Εργασίας με Ροή**

Η υπερφόρτωση ροής της [PresentationFactory.getPresentationInfo] παρέχει την ίδια ροή εργασίας. Επαναφέρετε τη θέση μιας ρεύσιμης ροής πριν φορτώσετε την πλήρη παρουσίαση από αυτήν.

Το παρακάτω παράδειγμα χρησιμοποιεί αρχείο PPT:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **Τιμές Επιστροφής της checkPassword**

Η [PresentationInfo.checkPassword] επιστρέφει `True` μόνο όταν η παρουσίαση έχει κωδικό πρόσβασης ανοίγματος και ο παρεχόμενος κωδικός είναι σωστός. Επιστρέφει `False` σε κάθε μία από τις παρακάτω περιπτώσεις:
- Ο κωδικός είναι λανθασμένος.
- Η παρουσίαση δεν έχει κωδικό πρόσβασης ανοίγματος.
- Ο παρεχόμενος κωδικός είναι `None` ή κενός.

Η συμπεριφορά είναι η ίδια για παρουσιάσεις PPT και PPTX.

## **Έλεγχος Εάν Η Φορτωμένη Παρουσίαση Είναι Κρυπτογραφημένη**

Μετά τη φόρτωση μιας παρουσίασης με το σωστό κωδικό, ελέγξτε το [ProtectionManager.isEncrypted] για να επιβεβαιώσετε ότι η αρχική παρουσίαση ήταν κρυπτογραφημένη. Για να εντοπίσετε την προστασία με κωδικό ανοίγματος πριν τη φόρτωση, χρησιμοποιήστε το [PresentationInfo.isPasswordProtected] όπως φαίνεται παραπάνω.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **Συστάσεις Ασφάλειας**

{{% alert color="warning" title="Security" %}}
Μην καταγράφετε τους κωδικούς πρόσβασης ανοίγματος ή τους συμπεριλαμβάνετε σε διαγνωστικά μηνύματα. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης, κρατήστε τους κωδικούς στη μνήμη μόνο όσο είναι απαραίτητο, και επαναχρησιμοποιήστε ένα επιτυχές αποτέλεσμα επικύρωσης όταν φορτώνετε αμέσως την παρουσίαση.

Οι δημόσιες ιδιότητες εγγράφου μπορούν να αποκαλύψουν ονόματα συντακτών, τίτλους, θέματα, λέξεις-κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές, ακόμη και αν το περιεχόμενο της παρουσίασης είναι κρυπτογραφημένο. Κρυπτογραφήστε τα ευαίσθητα μεταδεδομένα μαζί με την παρουσίαση. Η διατήρηση των ιδιοτήτων ως δημόσιες πρέπει να είναι σαφής απόφαση, ληφθείσα μόνο όταν τα συστήματα πρέπει να ευρετηριάσουν, ταξινομήσουν, αναζητήσουν ή διαχειριστούν το αρχείο χωρίς κωδικό πρόσβασης ανοίγματος.
{{% /alert %}}

## **Προστασία Παρουσίασης με Κωδικό Πρόσβασης Online**

1. Ανοίξτε την εφαρμογή [Aspose.Slides Lock](https://products.aspose.app/slides/el/lock).
2. Επιλέξτε ή ανεβάστε την παρουσίαση.
3. Εισάγετε έναν κωδικό για προστασία προβολής.
4. Προαιρετικά εισάγετε έναν ξεχωριστό κωδικό για προστασία επεξεργασίας.
5. Εφαρμόστε την προστασία και κατεβάστε το αρχείο.

{{% alert color="info" title="See also" %}}
- [Προστασία Εγγραφής Παρουσιάσεων](/slides/el/python-java/write-protected-presentation/)
- [Ψηφιακή Υπογραφή στο PowerPoint](/slides/el/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποια είναι η διαφορά μεταξύ κωδικού πρόσβασης ανοίγματος και κωδικού προστασίας εγγραφής;**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Ένας κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση χωρίς να κρυπτογραφεί το περιεχόμενο.

**Μπορώ να επικυρώσω έναν κωδικό πρόσβασης ανοίγματος χωρίς να φορτώσω όλες τις διαφάνειες;**

Ναι. Αποκτήστε τις πληροφορίες της παρουσίασης, ελέγξτε αν υπάρχει προστασία με κωδικό ανοίγματος και επικυρώστε τον κωδικό πριν δημιουργήσετε ένα πλήρες αντικείμενο παρουσίασης.

**Μπορεί μια εφαρμογή να διαβάσει μεταδεδομένα χωρίς τον κωδικό πρόσβασης ανοίγματος;**

Ναι, αλλά μόνο όταν η παρουσίαση κρυπτογραφήθηκε με την κρυπτογράφηση των ιδιοτήτων εγγράφου απενεργοποιημένη. Η εφαρμογή πρέπει τότε να χρησιμοποιήσει τη λειτουργία φόρτωσης μόνο με ιδιότητες εγγράφου όπως περιγράφεται στα [Manage Presentation Properties](/slides/el/python-java/presentation-properties/).

**Υποστηρίζουν οι ροές ελέγχου κωδικού πρόσβασης και τα δύο PPT και PPTX;**

Ναι. Η ανίχνευση και επικύρωση κωδικού με βάση τη διαδρομή αρχείου ή τη ροή συμπεριφέρονται το ίδιο για παρουσιάσεις PPT και PPTX.