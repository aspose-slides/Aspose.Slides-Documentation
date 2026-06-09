---
title: Μετατροπή Παρουσιάσεων PowerPoint σε Markdown σε Java
linktitle: PowerPoint σε Markdown
type: docs
weight: 140
url: /el/java/convert-powerpoint-to-markdown/
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
- exportPPTX σε MD
- PowerPoint
- παρουσίαση
- Markdown
- Java
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες PowerPoint—PPT, PPTX—σε καθαρό Markdown με Aspose.Slides για Java, αυτοματοποιήστε την τεκμηρίωση και διατηρήστε τη μορφοποίηση."
---
## **Εισαγωγή**

Το Aspose.Slides σάς επιτρέπει να μετατρέπειτε παρουσιάσεις PowerPoint σε Markdown, κάτι που μπορεί να είναι χρήσιμο για ροές τεκμηρίωσης, δημιουργία στατικών ιστότοπων, μεταφορά περιεχομένου και έκδοση ελεγχόμενης κειμενικής δημοσίευσης. Το API υποστηρίζει άμεση εξαγωγή από παρουσιάσεις PPT και PPTX σε αρχεία MD και παρέχει πρόσθετες επιλογές για τον έλεγχο του τρόπου που το περιεχόμενο των διαφανειών παρουσιάζεται στο τελικό έγγραφο Markdown.

Μπορείτε να εξάγετε παρουσιάσεις ως απλό Markdown, να επιλέξετε από πολλαπλές γεύσεις Markdown όπως CommonMark και GitHub Flavored Markdown, και να διαμορφώσετε τον τρόπο διαχείρισης των εικόνων κατά την εξαγωγή. Για παρουσιάσεις που περιέχουν οπτικό περιεχόμενο, το Aspose.Slides επίσης επιτρέπει την αποθήκευση των εικόνων σε ξεχωριστό φάκελο και την αναφορά σε αυτές από το παραγόμενο αρχείο Markdown.

{{% alert color="warning" %}}
Η εξαγωγή PowerPoint σε markdown είναι **χωρίς εικόνες** εξ' ορισμού. Εάν θέλετε να εξάγετε ένα έγγραφο PowerPoint που περιέχει εικόνες, πρέπει να χρησιμοποιήσετε `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` και επίσης το `setBasePath` όπου οι εικόνες που αναφέρονται στο έγγραφο markdown θα αποθηκευτούν.
{{% /alert %}}

## **Μετατροπή PowerPoint σε Markdown**

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) για να αντιπροσωπεύσει ένα αντικείμενο παρουσίασης.
2. Χρησιμοποιήστε τη μέθοδο [Αποθήκευση](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) για να αποθηκεύσετε το αντικείμενο ως αρχείο markdown.

Αυτός ο κώδικας Java δείχνει πώς να μετατρέψετε το PowerPoint σε markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Μετατροπή PowerPoint σε Γεύση Markdown**

Το Aspose.Slides σάς επιτρέπει να μετατρέψετε το PowerPoint σε markdown (με βασική σύνταξη), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab και 17 άλλες γεύσεις markdown.

Αυτός ο κώδικας Java δείχνει πώς να μετατρέψετε το PowerPoint σε CommonMark:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

Οι 23 υποστηριζόμενες γεύσεις markdown είναι [αναφερθείσες στην απαρίθμηση Flavor](https://reference.aspose.com/slides/el/java/com.aspose.slides/flavor/) από την κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/).

## **Μετατροπή Παρουσίασης με Εικόνες σε Markdown**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownsaveoptions/) παρέχει ιδιότητες και απαριθμήσεις που σας επιτρέπουν να χρησιμοποιήσετε συγκεκριμένες επιλογές ή ρυθμίσεις για το τελικό αρχείο markdown. Η απαρίθμηση [MarkdownExportType](https://reference.aspose.com/slides/el/java/com.aspose.slides/markdownexporttype/) μπορεί, για παράδειγμα, να οριστεί σε τιμές που καθορίζουν τον τρόπο απόδοσης ή διαχείρισης των εικόνων: `Sequential`, `TextOnly`, `Visual`.

### **Μετατροπή Εικόνων Διαδοχικά**

Εάν θέλετε οι εικόνες να εμφανίζονται ξεχωριστά η μία μετά την άλλη στο τελικό markdown, πρέπει να επιλέξετε την επιλογή διαδοχική. Αυτός ο κώδικας Java δείχνει πώς να μετατρέψετε μια παρουσίαση με εικόνες σε markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Μετατροπή Εικόνων Οπτικά**

Εάν θέλετε οι εικόνες να εμφανίζονται μαζί στο τελικό markdown, πρέπει να επιλέξετε την οπτική επιλογή. Σε αυτήν την περίπτωση, οι εικόνες θα αποθηκευτούν στο τρέχον φάκελο της εφαρμογής (και θα δημιουργηθεί σχετική διαδρομή για αυτές στο έγγραφο markdown), ή μπορείτε να καθορίσετε τη δική σας προτιμώμενη διαδρομή και όνομα φακέλου.

Αυτός ο κώδικας Java δείχνει τη λειτουργία:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Επιβιώνουν οι υπερσύνδεσμοι στην εξαγωγή σε Markdown;**

Ναι. Τα κείμενα [υπερσυνδέσμοι](/slides/el/java/manage-hyperlinks/) παραμένουν ως τυπικοί σύνδεσμοι Markdown. Οι [μεταβάσεις](/slides/el/java/slide-transition/) και οι [κινούμενα εφέ](/slides/el/java/powerpoint-animation/) των διαφανειών δεν μετατρέπονται.

**Μπορώ να επιταχύνω τη μετατροπή τρέχοντάς την σε πολλαπλά νήματα;**

Μπορείτε να παράλληλοποιήσετε ανά αρχείο, αλλά [μην μοιράζεστε](/slides/el/java/multithreading/) την ίδια [Παρουσίαση](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) μεταξύ νήματος. Χρησιμοποιήστε ξεχωριστές παρουσίες/διαδικασίες ανά αρχείο για να αποφύγετε τον ανταγωνισμό.

**Τι συμβαίνει με τις εικόνες — πού αποθηκεύονται και είναι οι διαδρομές σχετικές;**

Οι [εικόνες](/slides/el/java/image/) εξάγονται σε αφιερωμένο φάκελο, και το αρχείο Markdown τις αναφέρει με σχετικές διαδρομές εξ' ορισμού. Μπορείτε να ρυθμίσετε τη βασική διαδρομή εξόδου και το όνομα του φακέλου περιουσιακών στοιχείων ώστε να διατηρείται μια προβλέψιμη δομή αποθετηρίου.