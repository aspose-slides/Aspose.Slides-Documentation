---
title: Μετατροπή PPTX σε PPT με Python
linktitle: PPTX σε PPT
type: docs
weight: 21
url: /el/python-net/convert-pptx-to-ppt/
keywords:
- PPTX σε PPT
- μετατροπή PPTX σε PPT
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- Python
- Aspose.Slides
description: "Ευκολά μετατρέψτε PPTX σε PPT με το Aspose.Slides for Python μέσω .NET—διασφαλίστε αδιάλειπτη συμβατότητα με μορφές PowerPoint ενώ διατηρείτε τη διάταξη και την ποιότητα της παρουσίασής σας."
---
## **Επισκόπηση**

Το Aspose.Slides for Python σάς επιτρέπει να μετατρέψετε σύγχρονες παρουσιάσεις PPTX στη διακριτική μορφή PPT εξ ολοκλήρου με κώδικα. Ανοίξτε ένα PPTX και εξάγετέ το ως PPT διατηρώντας το περιεχόμενο και τη διάταξη της παρουσίασης, ώστε το αποτέλεσμα να είναι συμβατό με παλαιότερες εκδόσεις του PowerPoint. Η ίδια ροή εργασίας μπορεί να δημιουργήσει και άλλες εξόδους—όπως PDF, XPS, ODP, HTML ή εικόνες—έτσι ώστε να εντάσσεται ομαλά σε σενάρια, CI pipelines και επεξεργασία παρτίδας.

## **Μετατροπή PPTX σε PPT**

Για να μετατρέψετε ένα PPTX σε PPT, απλώς περάστε το όνομα του αρχείου και τη μορφή αποθήκευσης στη μέθοδο [save](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/save/) της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/). Το παρακάτω παράδειγμα Python μετατρέπει μια παρουσίαση από PPTX σε PPT χρησιμοποιώντας τις προεπιλεγμένες επιλογές.

```py
import aspose.slides as slides

# Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
presentation = slides.Presentation("presentation.pptx")

# Αποθηκεύστε την παρουσίαση ως αρχείο PPT.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **Συχνές Ερωτήσεις**

**Διατηρούνται όλα τα εφέ και χαρακτηριστικά του PPTX κατά την αποθήκευση σε μορφή κληρονομικής PPT (97–2003);**

Όχι πάντα. Η μορφή PPT δεν διαθέτει ορισμένες νεότερες δυνατότητες (π.χ., ορισμένα εφέ, αντικείμενα και συμπεριφορές), έτσι τα χαρακτηριστικά μπορεί να απλοποιηθούν ή να ραστεριστούν κατά τη μετατροπή.

**Μπορώ να μετατρέψω μόνο επιλεγμένες διαφάνειες σε PPT αντί για ολόκληρη την παρουσίαση;**

Η άμεση αποθήκευση στοχεύει σε όλη την παρουσίαση. Για να μετατρέψετε συγκεκριμένες διαφάνειες, δημιουργήστε μια νέα παρουσίαση μόνο με αυτές τις διαφάνειες και αποθηκεύστε τη ως PPT· εναλλακτικά, χρησιμοποιήστε μια υπηρεσία/API που υποστηρίζει παραμέτρους μετατροπής ανά διαφάνεια.

**Υποστηρίζονται παρουσιάσεις με προστασία κωδικού πρόσβασης;**

Ναι. Μπορείτε να εντοπίσετε αν ένα αρχείο είναι προστατευμένο, να το ανοίξετε με κωδικό πρόσβασης, και επίσης να διαμορφώσετε τις ρυθμίσεις προστασίας/κρυπτογράφησης για το αποθηκευμένο PPT.

**Δείτε επίσης:**
- [Μετατροπή PPT & PPTX σε PDF με Python | Προηγμένες Επιλογές](/slides/el/python-net/convert-powerpoint-to-pdf/)
- [Μετατροπή παρουσιάσεων PowerPoint σε XPS με Python](/slides/el/python-net/convert-powerpoint-to-xps/)
- [Μετατροπή παρουσιάσεων PowerPoint σε HTML με Python](/slides/el/python-net/convert-powerpoint-to-html/)
- [Μετατροπή διαφανειών PowerPoint σε PNG με Python](/slides/el/python-net/convert-powerpoint-to-png/)