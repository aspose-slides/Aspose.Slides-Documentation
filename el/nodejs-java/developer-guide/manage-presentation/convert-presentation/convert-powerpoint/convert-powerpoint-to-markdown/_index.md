---
title: Μετατροπή Παρουσιάσεων PowerPoint σε Markdown με JavaScript
linktitle: PowerPoint σε Markdown
type: docs
weight: 140
url: /el/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε MD
- παρουσίαση σε MD
- διαφάνεια σε MD
- PPT σε MD
- PPTX σε MD
- αποθήκευση PowerPoint ως Markdown
- αποθήκευση παρουσίασης ως Markdown
- αποθήκευση διαφάνειας ως Markdown
- αποθήκευση PPT ως MD
- αποθήκευση PPTX ως MD
- εξαγωγή PPT σε MD
- εξαγωγή PPTX σε MD
- PowerPoint
- παρουσίαση
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατροπή διαφανειών PowerPoint σε JavaScript—PPT, PPTX—σε καθαρό Markdown με Aspose.Slides για Node.js μέσω Java, αυτοματοποιήστε την τεκμηρίωση και διατηρήστε τη μορφοποίηση."
---
## **Εισαγωγή**

Το Aspose.Slides σας επιτρέπει να μετατρέπετε παρουσιάσεις PowerPoint σε Markdown, κάτι που μπορεί να είναι χρήσιμο για ροές εργασίας τεκμηρίωσης, δημιουργία στατικών ιστοτόπων, μετεγκατάσταση περιεχομένου και έκδοση κειμένου υπό έλεγχο έκδοσης. Το API υποστηρίζει άμεση εξαγωγή από παρουσιάσεις PPT και PPTX σε αρχεία MD και παρέχει πρόσθετες επιλογές για τον έλεγχο του τρόπου που το περιεχόμενο των διαφανειών παρουσιάζεται στο τελικό έγγραφο Markdown.

Μπορείτε να εξάγετε παρουσιάσεις ως απλό Markdown, να επιλέξετε ανάμεσα σε πολλαπλές γεύσεις Markdown όπως CommonMark και GitHub Flavored Markdown, και να διαμορφώσετε τον τρόπο διαχείρισης των εικόνων κατά την εξαγωγή. Για παρουσιάσεις που περιέχουν οπτικό περιεχόμενο, το Aspose.Slides σας επιτρέπει επίσης να αποθηκεύετε τις εικόνες σε ξεχωριστό φάκελο και να τις αναφέρετε από το παραγόμενο αρχείο Markdown.

{{% alert color="warning" %}} 
Η εξαγωγή PowerPoint σε markdown είναι **χωρίς εικόνες** από προεπιλογή. Εάν θέλετε να εξάγετε ένα έγγραφο PowerPoint που περιέχει εικόνες, πρέπει να καλέσετε `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` και επίσης να ορίσετε το `BasePath` όπου θα αποθηκευτούν οι εικόνες που αναφέρονται στο έγγραφο markdown.
{{% /alert %}} 

## **Μετατροπή PowerPoint σε Markdown**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) για να αντιπροσωπεύσετε ένα αντικείμενο παρουσίασης.
2. Χρησιμοποιήστε τη μέθοδο [save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) για να αποθηκεύσετε το αντικείμενο ως αρχείο markdown.

Αυτό το JavaScript δείχνει πώς να μετατρέψετε PowerPoint σε markdown:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Μετατροπή PowerPoint σε Γεύση Markdown**

Το Aspose.Slides σας επιτρέπει να μετατρέπετε PowerPoint σε markdown (με βασική σύνταξη), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab και 17 άλλες γεύσεις markdown.

Αυτό το JavaScript δείχνει πώς να μετατρέψετε PowerPoint σε CommonMark:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Οι 23 υποστηριζόμενες γεύσεις markdown είναι [listed under the Flavor enumeration](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/flavor/) από την κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/).

## **Μετατροπή Παρουσίασης που Περιέχει Εικόνες σε Markdown**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownsaveoptions/) παρέχει ιδιότητες και απαριθμήσεις που σας επιτρέπουν να χρησιμοποιήσετε συγκεκριμένες επιλογές ή ρυθμίσεις για το παραγόμενο αρχείο markdown. Η απαρίθμηση [MarkdownExportType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/markdownexporttype/), για παράδειγμα, μπορεί να οριστεί σε τιμές που καθορίζουν πώς θα αποδοθούν ή θα διαχειριστούν οι εικόνες: `Sequential`, `TextOnly`, `Visual`.

### **Μετατροπή Εικόνων Κατ' Ακολουθία**

Εάν θέλετε οι εικόνες να εμφανίζονται με τη σειρά, μια μετά την άλλη, στο τελικό markdown, πρέπει να επιλέξετε την επιλογή sequential. Αυτό το JavaScript δείχνει πώς να μετατρέψετε μια παρουσίαση που περιέχει εικόνες σε markdown:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Μετατροπή Εικόνων Οπτικά**

Εάν θέλετε οι εικόνες να εμφανίζονται μαζί στο τελικό markdown, πρέπει να επιλέξετε την επιλογή visual. Σε αυτήν την περίπτωση, οι εικόνες θα αποθηκευτούν στον τρέχοντα φάκελο της εφαρμογής (και θα δημιουργηθεί σχετική διαδρομή για αυτές στο έγγραφο markdown), ή μπορείτε να καθορίσετε προτιμώμενη διαδρομή και όνομα φακέλου.

Αυτό το JavaScript δείχνει τη λειτουργία:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι υπερσυνδέσεις κατά την εξαγωγή σε Markdown;**

Ναι. Τα κείμενα [hyperlinks](/slides/el/nodejs-java/manage-hyperlinks/) διατηρούνται ως τυπικοί σύνδεσμοι Markdown. Οι [transitions](/slides/el/nodejs-java/slide-transition/) και οι [animations](/slides/el/nodejs-java/powerpoint-animation/) δεν μετατρέπονται.

**Μπορώ να επιταχύνω τη μετατροπή τρέχοντάς την σε πολλαπλά νήματα;**

Μπορείτε να παραλληλοποιήσετε ανά αρχείο, αλλά [don’t share](/slides/el/nodejs-java/multithreading/) την ίδια παρουσία [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) μεταξύ νημάτων. Χρησιμοποιήστε ξεχωριστές παρουσίες/διεργασίες ανά αρχείο για να αποφύγετε συγκρούσεις.

**Τι συμβαίνει με τις εικόνες — πού αποθηκεύονται και οι διαδρομές είναι σχετικές;**

Οι [Images](/slides/el/nodejs-java/image/) εξάγονται σε ξεχωριστό φάκελο, και το αρχείο Markdown τις αναφέρει με σχετικές διαδρομές από προεπιλογή. Μπορείτε να διαμορφώσετε τη βασική διαδρομή εξόδου και το όνομα του φακέλου πόρων για να διατηρήσετε μια προβλέψιμη δομή αποθετηρίου.