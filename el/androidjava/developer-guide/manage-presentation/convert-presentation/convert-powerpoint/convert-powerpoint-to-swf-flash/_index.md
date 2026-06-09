---
title: Μετατροπή παρουσιάσεων PowerPoint σε SWF Flash σε Android
linktitle: PowerPoint σε SWF
type: docs
weight: 80
url: /el/androidjava/convert-powerpoint-to-swf-flash/
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
- Android
- Java
- Aspose.Slides
description: "Μετατρέψτε PowerPoint (PPT/PPTX) σε SWF Flash σε Java με Aspose.Slides για Android. Παραδείγματα κώδικα βήμα‑βήμα, γρήγορη εξαγωγή υψηλής ποιότητας, χωρίς αυτοματοποίηση PowerPoint."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε SWF χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως αρχείο SWF με τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) και πώς να διαμορφώσετε την εξαγωγή με το [SwfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/swfoptions/), συμπεριλαμβανομένων των ρυθμίσεων προβολέα και της διάταξης σημειώσεων ή σχολίων.

## **Μετατροπή PPT(X) σε SWF**
Η μέθοδος [Save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) μπορεί να χρησιμοποιηθεί για να μετατρέψει ολόκληρη την παρουσίαση σε έγγραφο **SWF**. Το παρακάτω παράδειγμα δείχνει πώς να μετατρέψετε μια παρουσίαση σε έγγραφο **SWF** χρησιμοποιώντας τις επιλογές που παρέχονται από την κλάση [**SWFOptions**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SwfOptions). Μπορείτε επίσης να συμπεριλάβετε σχόλια στο παραγόμενο SWF χρησιμοποιώντας την κλάση [**ISWFOptions**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISwfOptions) και το interface [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).

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

## **Συχνές ερωτήσεις**

**Can I include hidden slides in the SWF?**

Ναι. Ενεργοποιήστε τις κρυφές διαφάνειες χρησιμοποιώντας τη μέθοδο [setShowHiddenSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) στο [SwfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/swfoptions/). Από προεπιλογή, οι κρυφές διαφάνειες δεν εξάγονται.

**How can I control compression and the final SWF size?**

Χρησιμοποιήστε τη μέθοδο [setCompressed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) και [adjust JPEG quality](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) για να ισορροπήσετε το μέγεθος του αρχείου και την πιστότητα της εικόνας.

**What is 'setViewerIncluded' for, and when should I disable it?**

[setViewerIncluded](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) προσθέτει μια ενσωματωμένη διεπαφή player (χειριστήρια πλοήγησης, πάνελ, αναζήτηση). Απενεργοποιήστε το εάν σκοπεύετε να χρησιμοποιήσετε το δικό σας player ή χρειάζεστε ένα άδειο πλαίσιο SWF χωρίς διεπαφή.

**What happens if a source font is missing on the export machine?**

Το Aspose.Slides θα αντικαταστήσει τη γραμματοσειρά που καθορίζετε μέσω του [setDefaultRegularFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) στο [SwfOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/swfoptions/) ώστε να αποφευχθεί μια ανεπιθύμητη εναλλακτική.