---
title: Μετατροπή PPTX σε PPT στο Android
linktitle: PPTX σε PPT
type: docs
weight: 21
url: /el/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "Μετατρέψτε εύκολα το PPTX σε PPT με το Aspose.Slides για Android μέσω Java—εξασφαλίζοντας απρόσκοπτη συμβατότητα με τις μορφές PowerPoint ενώ διατηρείτε τη διάταξη και την ποιότητα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε μια PowerPoint Presentation σε μορφή PPTX σε μορφή PPT χρησιμοποιώντας τη Java. Καλύπτεται το παρακάτω θέμα.

- Μετατροπή PPTX σε PPT με Java

## **Μετατροπή PPTX σε PPT στο Android**

Για δείγμα κώδικα Java για τη μετατροπή PPTX σε PPT, δείτε την ενότητα παρακάτω, δηλαδή [Convert PPTX to PPT](#convert-pptx-to-ppt). Απλώς φορτώνει το αρχείο PPTX και το αποθηκεύει σε μορφή PPT. Καθορίζοντας διαφορετικές μορφές αποθήκευσης, μπορείτε επίσης να αποθηκεύσετε το αρχείο PPTX σε πολλές άλλες μορφές όπως PDF, XPS, ODP, HTML κ.λπ., όπως συζητούνται σε αυτά τα άρθρα.

- [Μετατροπή PPTX σε PDF στο Android](/slides/el/androidjava/convert-powerpoint-to-pdf/)
- [Μετατροπή PPTX σε XPS στο Android](/slides/el/androidjava/convert-powerpoint-to-xps/)
- [Μετατροπή PPTX σε HTML στο Android](/slides/el/androidjava/convert-powerpoint-to-html/)
- [Μετατροπή PPTX σε ODP στο Android](/slides/el/androidjava/save-presentation/)
- [Μετατροπή PPTX σε PNG στο Android](/slides/el/androidjava/convert-powerpoint-to-png/)

## **Μετατροπή PPTX σε PPT**
Για να μετατρέψετε ένα PPTX σε PPT, απλώς περάστε το όνομα αρχείου και τη μορφή αποθήκευσης στη μέθοδο **Save** της κλάσης [**Presentation**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation). Το παρακάτω δείγμα κώδικα Java μετατρέπει μια Presentation από PPTX σε PPT χρησιμοποιώντας τις προεπιλεγμένες ρυθμίσεις.

```java
// δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation presentation = new Presentation("template.pptx");

// αποθηκεύστε την παρουσίαση ως PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **Συχνές Ερωτήσεις**

**Επιβιώνουν όλα τα εφέ και χαρακτηριστικά του PPTX όταν αποθηκεύονται στη κληρονομική μορφή PPT (97–2003);**

Όχι πάντα. Η μορφή PPT δεν διαθέτει ορισμένες νεότερες δυνατότητες (π.χ. ορισμένα εφέ, αντικείμενα και συμπεριφορές), έτσι τα χαρακτηριστικά μπορεί να απλοποιηθούν ή να ραστεροποιηθούν κατά τη μετατροπή.

**Μπορώ να μετατρέψω μόνο τις επιλεγμένες διαφάνειες σε PPT αντί για ολόκληρη την παρουσίαση;**

Η άμεση αποθήκευση στοχεύει ολόκληρη την παρουσίαση. Για να μετατρέψετε συγκεκριμένες διαφάνειες, δημιουργήστε μια νέα παρουσίαση μόνο με αυτές τις διαφάνειες και αποθηκεύστε την ως PPT· εναλλακτικά, χρησιμοποιήστε μια υπηρεσία/API που υποστηρίζει παραμέτρους μετατροπής ανά διαφάνεια.

**Υποστηρίζονται παρουσιάσεις με προστασία κωδικού πρόσβασης;**

Ναι. Μπορείτε να ανιχνεύσετε εάν ένα αρχείο είναι προστατευμένο, να το ανοίξετε με κωδικό πρόσβασης και επίσης να [ρυθμίσετε τις ρυθμίσεις προστασίας/κρυπτογράφησης](/slides/el/androidjava/password-protected-presentation/) για το αποθηκευμένο PPT.