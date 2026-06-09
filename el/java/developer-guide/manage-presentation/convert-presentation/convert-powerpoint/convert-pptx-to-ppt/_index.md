---
title: Μετατροπή PPTX σε PPT στη Java
linktitle: PPTX σε PPT
type: docs
weight: 21
url: /el/java/convert-pptx-to-ppt/
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
- Java
- Aspose.Slides
description: "Μετατρέψτε εύκολα PPTX σε PPT με το Aspose.Slides για Java—εξασφαλίστε αδιάλειπτη συμβατότητα με τις μορφές PowerPoint ενώ διατηρείτε τη διάταξη και την ποιότητα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε μια Παρουσίαση PowerPoint σε μορφή PPTX σε μορφή PPT χρησιμοποιώντας τη Java. Το παρακάτω θέμα καλύπτεται.

- Μετατροπή PPTX σε PPT στη Java

## **Μετατροπή PPTX σε PPT στη Java**

Για δείγμα κώδικα Java που μετατρέπει PPTX σε PPT, δείτε την ενότητα παρακάτω, δηλαδή [Convert PPTX to PPT](#convert-pptx-to-ppt). Απλώς φορτώνει το αρχείο PPTX και το αποθηκεύει σε μορφή PPT. Καθορίζοντας διαφορετικές μορφές αποθήκευσης, μπορείτε επίσης να αποθηκεύσετε το αρχείο PPTX σε πολλές άλλες μορφές όπως PDF, XPS, ODP, HTML κ.λπ., όπως συζητείται σε αυτά τα άρθρα.

- [Convert PPTX to PDF in Java](/slides/el/java/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS in Java](/slides/el/java/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML in Java](/slides/el/java/convert-powerpoint-to-html/)
- [Convert PPTX to ODP in Java](/slides/el/java/save-presentation/)
- [Convert PPTX to PNG in Java](/slides/el/java/convert-powerpoint-to-png/)

## **Μετατροπή PPTX σε PPT**
Για να μετατρέψετε ένα PPTX σε PPT, απλώς περάστε το όνομα αρχείου και τη μορφή αποθήκευσης στη μέθοδο **Save** της κλάσης [**Presentation**](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation). Το παρακάτω δείγμα κώδικα Java μετατρέπει μια Παρουσίαση από PPTX σε PPT χρησιμοποιώντας τις προεπιλεγμένες επιλογές.

```java
// δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation presentation = new Presentation("template.pptx");

// αποθηκεύστε την παρουσίαση ως PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **FAQ**

**Μας όλα τα εφέ και χαρακτηριστικά του PPTX διατηρούνται κατά την αποθήκευση στη παλιά μορφή PPT (97–2003);**

Δεν πάντα. Η μορφή PPT δεν υποστηρίζει ορισμένες νεότερες δυνατότητες (π.χ. συγκεκριμένα εφέ, αντικείμενα και συμπεριφορές), έτσι τα χαρακτηριστικά μπορεί να απλουστευτούν ή να rasterize κατά τη μετατροπή.

**Μπορώ να μετατρέψω μόνο επιλεγμένες διαφάνειες σε PPT αντί για ολόκληρη την παρουσίαση;**

Η απευθείας αποθήκευση στοχεύει ολόκληρη την παρουσίαση. Για να μετατρέψετε συγκεκριμένες διαφάνειες, δημιουργήστε μια νέα παρουσίαση μόνο με αυτές τις διαφάνειες και αποθηκεύστε την ως PPT· εναλλακτικά, χρησιμοποιήστε μια υπηρεσία/API που υποστηρίζει παραμέτρους μετατροπής ανά διαφάνεια.

**Υποστηρίζονται παρουσιάσεις με προστασία κωδικού;**

Ναι. Μπορείτε να εντοπίσετε εάν ένα αρχείο είναι προστατευμένο, να το ανοίξετε με κωδικό πρόσβασης και επίσης [configure protection/encryption settings](/slides/el/java/password-protected-presentation/) για το αποθηκευμένο PPT.