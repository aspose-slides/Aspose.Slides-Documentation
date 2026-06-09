---
title: Μετατροπή παρουσιάσεων PowerPoint σε SWF Flash σε PHP
linktitle: PowerPoint σε SWF
type: docs
weight: 80
url: /el/php-java/convert-powerpoint-to-swf-flash/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε SWF
- παρουσίαση σε SWF
- διαφάνεια σε SWF
- PPT σε SWF
- PPTX σε SWF
- PowerPoint σε Flash
- παρουσίαση σε Flash
- διαφάνεια σε Flash
- PPT σε Flash
- PPTX σε Flash
- αποθήκευση PPT ως SWF
- αποθήκευση PPTX ως SWF
- εξαγωγή PPT σε SWF
- εξαγωγή PPTX σε SWF
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μετατροπή PowerPoint (PPT/PPTX) σε SWF Flash σε PHP με Aspose.Slides. Παραδείγματα κώδικα βήμα-βήμα, γρήγορη παραγωγή υψηλής ποιότητας, χωρίς αυτοματοποίηση PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε SWF χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο SWF με τη μέθοδο [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/save/) και πώς να ρυθμίσετε την εξαγωγή με το [SwfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/swfoptions/), συμπεριλαμβανομένων των ρυθμίσεων προβολέα και της διάταξης σημειώσεων ή σχολίων.

## **Μετατροπή Παρουσιάσεων σε Flash**

Η μέθοδος [save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/save/) που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) μπορεί να χρησιμοποιηθεί για να μετατρέψει ολόκληρη την παρουσίαση σε ένα έγγραφο **SWF**. Το παρακάτω παράδειγμα δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο **SWF** χρησιμοποιώντας τις επιλογές που παρέχονται από την κλάση [SWFOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/swfoptions/). Μπορείτε επίσης να συμπεριλάβετε σχόλια στο παραγόμενο SWF χρησιμοποιώντας την κλάση [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/notescommentslayoutingoptions/).

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Αποθήκευση παρουσίασης
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Μπορώ να συμπεριλάβω κρυμμένες διαφάνειες στο SWF;**

Ναι. Ενεργοποιήστε τις κρυμμένες διαφάνειες χρησιμοποιώντας τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/swfoptions/setshowhiddenslides/) στο [SwfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/swfoptions/). Από προεπιλογή, οι κρυμμένες διαφάνειες δεν εξάγονται.

**Πώς μπορώ να ελέγξω τη συμπίεση και το τελικό μέγεθος του SWF;**

Χρησιμοποιήστε τη μέθοδο [setCompressed](https://reference.aspose.com/slides/el/php-java/aspose.slides/swfoptions/setcompressed/) και [adjust JPEG quality](https://reference.aspose.com/slides/el/php-java/aspose.slides/swfoptions/setjpegquality/) για να εξισορροπήσετε το μέγεθος του αρχείου και την πιστότητα της εικόνας.

**Για τι χρησιμοποιείται το 'setViewerIncluded' και πότε πρέπει να το απενεργοποιήσω;**

[setViewerIncluded](https://reference.aspose.com/slides/el/php-java/aspose.slides/swfoptions/setviewerincluded/) προσθέτει ενσωματωμένο UI αναπαραγωγέα (πλήκτρα πλοήγησης, πίνακες, αναζήτηση). Απενεργοποιήστε το εάν σκοπεύετε να χρησιμοποιήσετε το δικό σας player ή χρειάζεστε ένα απλό πλαίσιο SWF χωρίς UI.

**Τι συμβαίνει αν λείπει μια γραμματοσειρά πηγής στο μηχάνημα εξαγωγής;**

Το Aspose.Slides θα αντικαταστήσει τη γραμματοσειρά που ορίζετε μέσω του [setDefaultRegularFont](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) στο [SwfOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/swfoptions/) για να αποφευχθεί μια ανεπιθύμητη εναλλακτική.