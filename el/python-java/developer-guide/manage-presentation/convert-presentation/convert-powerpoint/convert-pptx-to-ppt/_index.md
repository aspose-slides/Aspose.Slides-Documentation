---
title: Μετατροπή PPTX σε PPT σε Python
linktitle: PPTX σε PPT
type: docs
weight: 21
url: /el/python-java/convert-pptx-to-ppt/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPTX
- PPTX σε PPT
- αποθήκευση PPTX ως PPT
- εξαγωγή PPTX σε PPT
- PowerPoint
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μετατροπή PPTX σε παλαιότερη μορφή PPT σε Python με Aspose.Slides for Python via Java. Περιλαμβάνει παράδειγμα κώδικα και σημειώσεις σχετικά με τη συμβατότητα και τα προστατευμένα αρχεία."
---
## **Επισκόπηση**

Το Aspose.Slides for Python via Java σάς επιτρέπει να μετατρέψετε μια παρουσίαση PPTX στη παλαιότερη μορφή PPT που χρησιμοποιείται από το PowerPoint 97–2003 χωρίς να είναι εγκατεστημένο το Microsoft PowerPoint. Φορτώστε το αρχείο PPTX και αποθηκεύστε το με τη μορφή εξόδου PPT, όπως φαίνεται παρακάτω.

## **Μετατροπή PPTX σε PPT**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και, στη συνέχεια, καλέστε [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) με τη διαδρομή εξόδου και [SaveFormat.Ppt](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Ppt).

Το παρακάτω παράδειγμα ξεκινά τη μηχανή εικονικής Java εάν απαιτείται και μετατρέπει το `template.pptx` σε `output.ppt` χρησιμοποιώντας τις προεπιλεγμένες επιλογές. Αντικαταστήστε τις διαδρομές με τα δικά σας ονόματα αρχείων. Το μπλοκ `finally` απελευθερώνει τους πόρους της παρουσίασης ακόμη και αν η αποθήκευση αποτύχει.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Φόρτωσε την παρουσίαση PPTX.
presentation = Presentation("template.pptx")
try:
    # Αποθήκευσε την παρουσίαση σε μορφή PPT.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

Το όρισμα [SaveFormat.Ppt](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#Ppt) επιλέγει τη μορφή εξόδου· η αλλαγή μόνο της κατάληξης του αρχείου δεν μετατρέπει την παρουσίαση. Διατηρήστε το αρχικό αρχείο PPTX ώστε να μπορείτε να επιστρέψετε σε αυτό εάν μια νεότερη λειτουργία δεν έχει ισοδύναμο στην PPT.

## **Μετατροπή PPTX σε Άλλα Μορφότυπα**

Το Aspose.Slides υποστηρίζει επίσης και άλλους μορφότυπους εξόδου. Δείτε τα αντίστοιχα άρθρα για επιλογές και παραδείγματα ειδικά για κάθε μορφότυπο:

- [Μετατροπή PowerPoint σε PDF σε Python](/slides/el/python-java/convert-powerpoint-to-pdf/)
- [Μετατροπή PowerPoint σε XPS σε Python](/slides/el/python-java/convert-powerpoint-to-xps/)
- [Μετατροπή PowerPoint σε HTML σε Python](/slides/el/python-java/convert-powerpoint-to-html/)
- [Αποθήκευση Παρουσιάσεων ως ODP σε Python](/slides/el/python-java/save-presentation/)
- [Μετατροπή PowerPoint σε PNG σε Python](/slides/el/python-java/convert-powerpoint-to-png/)

## **Συχνές Ερωτήσεις**

**Διατηρούνται όλα τα εφέ και χαρακτηριστικά του PPTX μετά τη μετατροπή σε PPT;**

Δεν πάντα. Η παλαιότερη μορφή PPT δεν υποστηρίζει κάθε δυνατότητα που υπάρχει στο PPTX. Ορισμένα εφέ, αντικείμενα ή συμπεριφορές μπορεί να απλοποιηθούν ή να εμφανιστούν διαφορετικά. Ελέγξτε την μετατρεπόμενη παρουσίαση στον προοριζόμενο προβολέα, ειδικά όταν περιέχει νεότερα χαρακτηριστικά του PowerPoint.

**Μπορώ να μετατρέψω μόνο επιλεγμένες διαφάνειες σε PPT;**

Η αποθήκευση σε PPT γράφει ολόκληρη την παρουσίαση. Για να μετατρέψετε μόνο επιλεγμένες διαφάνειες, δημιουργήστε μια νέα παρουσίαση, αφαιρέστε την αρχική κενή διαφάνεια, κλωνοποιήστε τις απαιτούμενες διαφάνειες σε αυτήν και αποθηκεύστε την ως PPT. Δείτε [Clone Slides in Python](/slides/el/python-java/clone-slides/).

**Μπορώ να μετατρέψω ένα αρχείο PPTX που προστατεύεται με κωδικό;**

Ναι, εάν παρέχετε τον σωστό κωδικό πρόσβασης κατά τη φόρτωση της πηγής παρουσίασης. Μπορείτε επίσης να ρυθμίσετε προστασία για το αρχείο εξόδου. Δείτε [Password-Protected Presentations](/slides/el/python-java/password-protected-presentation/).