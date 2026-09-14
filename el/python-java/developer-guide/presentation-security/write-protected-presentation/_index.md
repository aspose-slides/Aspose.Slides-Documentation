---
title: Προστασία Εγγραφής Παρουσιάσεων σε Python
linktitle: Προστασία Εγγραφής
type: docs
weight: 25
url: /el/python-java/write-protected-presentation/
keywords:
- προστασία εγγραφής
- προστασία εγγραφής PowerPoint
- κωδικός για τροποποίηση
- περιορισμός επεξεργασίας παρουσίασης
- αφαίρεση προστασίας εγγραφής
- επιβεβαίωση κωδικού τροποποίησης
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Ορίστε, εντοπίστε, επαληθεύστε και αφαιρέστε κωδικούς προστασίας εγγραφής σε παρουσιάσεις PowerPoint PPT και PPTX χρησιμοποιώντας το Aspose.Slides για Python μέσω Java."
---
## **Εισαγωγή**

Ο κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση μιας παρουσίασης, αλλά δεν κρυπτογραφεί το περιεχόμενό της. Οι χρήστες μπορούν να φορτώσουν και να προβάλλουν μια παρουσίαση με προστασία εγγραφής χωρίς τον κωδικό. Ανάλογα με την εφαρμογή, μπορεί επίσης να είναι δυνατόν να επεξεργαστούν το περιεχόμενο και να το αποθηκεύσουν με διαφορετικό όνομα, επομένως η προστασία εγγραφής δεν πρέπει να θεωρείται μηχανισμός εμπιστευτικότητας.

Ο κωδικός ανοίγματος εξυπηρετεί διαφορετικό σκοπό: κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Για την κρυπτογράφηση μιας παρουσίασης ή την επικύρωση κωδικού ανοίγματος, δείτε [Password-Protect Presentations](/slides/el/python-java/password-protected-presentation/).

Οι ροές εργασίας σε αυτό το άρθρο ισχύουν τόσο για παρουσιάσεις PPT όσο και PPTX. Τα παραδείγματα χρησιμοποιούν αρχεία PPTX· κατά την αποθήκευση σε PPT, χρησιμοποιήστε την επέκταση `.ppt` και την αντίστοιχη μορφή αποθήκευσης PPT.

## **Ορισμός Προστασίας Εγγραφής σε Παρουσίαση**

Χρησιμοποιήστε [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/el/python-java/aspose.slides/protectionmanager/#setWriteProtection) για να ορίσετε κωδικό για την τροποποίηση μιας παρουσίασης. Η αποθήκευση της παρουσίασης διατηρεί τη ρύθμιση προστασίας.

Το παρακάτω παράδειγμα ορίζει προστασία εγγραφής σε παρουσίαση PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Φόρτωση Προστατευμένης με Προστασία Εγγραφής Παρουσίασης**

Επειδή η προστασία εγγραφής δεν κρυπτογραφεί το περιεχόμενο της παρουσίασης, δεν απαιτείται κωδικός για τη φόρτωση της. Ο κωδικός είναι σχετικός μόνο όταν επικυρώνεται η εξουσιοδότηση τροποποίησης της προστατευμένης παρουσίασης.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

Μην περάσετε κωδικό προστασίας εγγραφής στη μέθοδο [LoadOptions.setPassword](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setPassword). Αυτή η μέθοδος δέχεται κωδικό ανοίγματος για κρυπτογραφημένο περιεχόμενο. Αν μια παρουσίαση έχει και τους δύο τύπους προστασίας, δώστε τον κωδικό ανοίγματος για να τη φορτώσετε και διαχειριστείτε ξεχωριστά τον κωδικό προστασίας εγγραφής.

## **Αφαίρεση Προστασίας Εγγραφής από Παρουσίαση**

Χρησιμοποιήστε [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/el/python-java/aspose.slides/protectionmanager/#removeWriteProtection) για να αφαιρέσετε τον περιορισμό τροποποίησης, στη συνέχεια αποθηκεύστε την παρουσίαση.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Έλεγχος εάν μια Παρουσίαση είναι Προστατευμένη με Προστασία Εγγραφής**

Για να εξετάσετε ένα αρχείο χωρίς να δημιουργήσετε ένα πλήρες αντικείμενο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/), καλέστε [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/#getPresentationInfo) και ελέγξτε [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#isWriteProtected). Η μέθοδος χρησιμοποιεί το [NullableBool](https://reference.aspose.com/slides/el/python-java/aspose.slides/nullablebool/) και επιστρέφει `NullableBool.True_` όταν ανιχνευθεί προστασία εγγραφής.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

Η υπερφόρτωση ροής της μεθόδου [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationfactory/#getPresentationInfo) παρέχει τις ίδιες πληροφορίες για μια παρουσίαση που παρασχέθηκε ως ροή.

## **Επικύρωση Κωδικού Προστασίας Εγγραφής**

Χρησιμοποιήστε [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#checkWriteProtection) για να επικυρώσετε έναν κωδικό τροποποίησης χωρίς να φορτώσετε ολόκληρη την παρουσίαση. Ελέγξτε πρώτα το [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#isWriteProtected) ώστε η εφαρμογή να ζητά ή να επικυρώνει κωδικό μόνο όταν υπάρχει προστασία εγγραφής.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#checkWriteProtection) επικυρώνει μόνο τον κωδικό προστασίας εγγραφής. Δεν επικυρώνει κωδικό ανοίγματος ούτε καθορίζει αν μπορεί να φορτωθεί κρυπτογραφημένο περιεχόμενο. Αντιθέτως, το [PresentationInfo.checkPassword](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentationinfo/#checkPassword) επικυρώνει μόνο έναν κωδικό ανοίγματος. Αν μια πλήρης παρουσίαση έχει ήδη φορτωθεί, το [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/el/python-java/aspose.slides/protectionmanager/#checkWriteProtection) παρέχει τον ισοδύναμο έλεγχο προστασίας εγγραφής μέσω του διαχειριστή προστασίας.

Σε παραγωγικές εφαρμογές, μην καταγράφετε κωδικούς ή τους συμπεριλαμβάνετε σε διαγνωστικά μηνύματα. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης και διατηρείτε τους κωδικούς στη μνήμη μόνο όσο χρειάζεται.

{{% alert color="info" title="Δείτε επίσης" %}}
- [Παρουσιάσεις με Προστασία Κωδικού](/slides/el/python-java/password-protected-presentation/)
- [Παρουσιάσεις μόνο για Ανάγνωση](/slides/el/python-java/read-only-presentation/)
- [Ψηφιακή Υπογραφή στο PowerPoint](/slides/el/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Κρυπτογραφεί η προστασία εγγραφής μια παρουσίαση;**

Όχι. Περιορίζει τη τροποποίηση αλλά αφήνει το περιεχόμενο της παρουσίασης διαθέσιμο για φόρτωση και προβολή.

**Απαιτείται ο κωδικός προστασίας εγγραφής για το άνοιγμα μιας παρουσίασης;**

Όχι. Μόνο ένας κωδικός ανοίγματος απαιτείται για τη φόρτωση κρυπτογραφημένου περιεχομένου παρουσίασης.

**Μπορεί μια παρουσίαση να έχει και κωδικό ανοίγματος και κωδικό προστασίας εγγραφής;**

Ναι. Δώστε τον κωδικό ανοίγματος μέσω των επιλογών φόρτωσης για να ανοίξετε την κρυπτογραφημένη παρουσίαση και επικυρώστε ξεχωριστά τον κωδικό προστασίας εγγραφής όταν απαιτείται εξουσιοδότηση τροποποίησης.