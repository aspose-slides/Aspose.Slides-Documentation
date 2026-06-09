---
title: Μετατροπή Παρουσιάσεων PowerPoint σε SWF Flash σε Java
linktitle: PowerPoint σε SWF
type: docs
weight: 80
url: /el/java/convert-powerpoint-to-swf-flash/
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
- Java
- Aspose.Slides
description: "Μετατροπή PowerPoint (PPT/PPTX) σε SWF Flash σε Java με Aspose.Slides. Παραδείγματα κώδικα βήμα-βήμα, γρήγορη έξοδος υψηλής ποιότητας, χωρίς αυτοματοποίηση PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε SWF χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο SWF με τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) και πώς να διαμορφώσετε την εξαγωγή με το [SwfOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/swfoptions/), συμπεριλαμβανομένων των ρυθμίσεων προβολέα και της διάταξης σημειώσεων ή σχολίων.

## **Μετατροπή Παρουσιάσεων σε Flash**

Η μέθοδος [save](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) μπορεί να χρησιμοποιηθεί για να μετατρέψει ολόκληρη την παρουσίαση σε έγγραφο **SWF**. Το παρακάτω παράδειγμα δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο **SWF** χρησιμοποιώντας τις επιλογές που παρέχονται από την κλάση [**SWFOptions**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SwfOptions). Μπορείτε επίσης να συμπεριλάβετε σχόλια στο παραγόμενο SWF χρησιμοποιώντας την κλάση [**ISWFOptions**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISwfOptions) και το interface [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/el/java/com.aspose.slides/INotesCommentsLayoutingOptions).

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Αποθήκευση παρουσίασης
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες στο SWF;**

Ναι. Ενεργοποιήστε τις κρυφές διαφάνειες χρησιμοποιώντας τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) στην κλάση [SwfOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/swfoptions/). Από προεπιλογή, οι κρυφές διαφάνειες δεν εξάγονται.

**Πώς μπορώ να ελέγξω τη συμπίεση και το τελικό μέγεθος του SWF;**

Χρησιμοποιήστε τη μέθοδο [setCompressed](https://reference.aspose.com/slides/el/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) και την [adjust JPEG quality](https://reference.aspose.com/slides/el/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) για να εξισορροπήσετε το μέγεθος του αρχείου και την ποιότητα της εικόνας.

**Για ποιο σκοπό υπάρχει το 'setViewerIncluded' και πότε πρέπει να το απενεργοποιήσω;**

[setViewerIncluded](https://reference.aspose.com/slides/el/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) προσθέτει ενσωματωμένο UI αναπαραγωγέα (σχέδια πλοήγησης, πίνακες, αναζήτηση). Απενεργοποιήστε το εάν σκοπεύετε να χρησιμοποιήσετε τον δικό σας αναπαραγωγέα ή χρειάζεστε ένα γυμνό πλαίσιο SWF χωρίς UI.

**Τι συμβαίνει εάν λείπει μια γραμματοσειρά στην μηχανή εξαγωγής;**

Το Aspose.Slides θα αντικαταστήσει τη γραμματοσειρά που καθορίζετε μέσω της [setDefaultRegularFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) στη [SwfOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/swfoptions/) για να αποφύγει μια ανεπιθύμητη εναλλακτική.