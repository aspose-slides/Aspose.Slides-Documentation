---
title: Μετατροπή PPTX σε PPT με JavaScript
linktitle: PPTX σε PPT
type: docs
weight: 21
url: /el/nodejs-java/convert-pptx-to-ppt/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατρέψτε εύκολα το PPTX σε PPT με Aspose.Slides—εξασφαλίστε απρόσκοπτη συμβατότητα με τις μορφές PowerPoint διατηρώντας τη διάταξη και την ποιότητα της παρουσίασής σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε μια παρουσίαση PowerPoint σε μορφή PPTX σε μορφή PPT χρησιμοποιώντας JavaScript. Το παρακάτω θέμα καλύπτεται.

- Μετατροπή PPTX σε PPT με JavaScript

## **Java Μετατροπή PPTX σε PPT**

Για δείγμα κώδικα JavaScript για τη μετατροπή PPTX σε PPT, παρακαλούμε δείτε την παρακάτω ενότητα, δηλαδή [Μετατροπή PPTX σε PPT](#convert-pptx-to-ppt). Απλώς φορτώνει το αρχείο PPTX και το αποθηκεύει σε μορφή PPT. Καθορίζοντας διάφορες μορφές αποθήκευσης, μπορείτε επίσης να αποθηκεύσετε το αρχείο PPTX σε πολλές άλλες μορφές όπως PDF, XPS, ODP, HTML κ.λπ., όπως συζητείται σε αυτά τα άρθρα.

- [Μετατροπή PPTX σε PDF με JavaScript](/slides/el/nodejs-java/convert-powerpoint-to-pdf/)
- [Μετατροπή PPTX σε XPS με JavaScript](/slides/el/nodejs-java/convert-powerpoint-to-xps/)
- [Μετατροπή PPTX σε HTML με JavaScript](/slides/el/nodejs-java/convert-powerpoint-to-html/)
- [Μετατροπή PPTX σε ODP με JavaScript](/slides/el/nodejs-java/save-presentation/)
- [Μετατροπή PPTX σε PNG με JavaScript](/slides/el/nodejs-java/convert-powerpoint-to-png/)

## **Μετατροπή PPTX σε PPT**

Για να μετατρέψετε ένα PPTX σε PPT, απλώς περάστε το όνομα αρχείου και τη μορφή αποθήκευσης στη μέθοδο **Save** της κλάσης [**Presentation**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation). Το παρακάτω δείγμα κώδικα JavaScript μετατρέπει μια Presentation από PPTX σε PPT χρησιμοποιώντας προεπιλεγμένες επιλογές.

```javascript
// δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// save the presentation as PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **Συχνές Ερωτήσεις**

**Διατηρούνται όλα τα εφέ και χαρακτηριστικά του PPTX κατά την αποθήκευση στη κλασική μορφή PPT (97–2003);**

Όχι πάντα. Η μορφή PPT δεν περιέχει ορισμένες νεότερες δυνατότητες (π.χ. συγκεκριμένα εφέ, αντικείμενα και συμπεριφορές), οπότε τα χαρακτηριστικά μπορεί να απλοποιηθούν ή να ραστεροποιηθούν κατά τη μετατροπή.

**Μπορώ να μετατρέψω μόνο επιλεγμένες διαφάνειες σε PPT αντί ολόκληρης της παρουσίασης;**

Η απευθείας αποθήκευση στοχεύει σε ολόκληρη την παρουσίαση. Για να μετατρέψετε συγκεκριμένες διαφάνειες, δημιουργήστε μια νέα παρουσίαση μόνο με αυτές τις διαφάνειες και αποθηκεύστε την ως PPT· εναλλακτικά, χρησιμοποιήστε μια υπηρεσία/API που υποστηρίζει παραμέτρους μετατροπής ανά διαφάνεια.

**Υποστηρίζονται παρουσιάσεις με προστασία κωδικού;**

Ναι. Μπορείτε να εντοπίσετε αν ένα αρχείο είναι προστατευμένο, να το ανοίξετε με κωδικό πρόσβασης, και επίσης να [ρυθμίσετε τις ρυθμίσεις προστασίας/κρυπτογράφησης](/slides/el/nodejs-java/password-protected-presentation/) για το αποθηκευμένο PPT.