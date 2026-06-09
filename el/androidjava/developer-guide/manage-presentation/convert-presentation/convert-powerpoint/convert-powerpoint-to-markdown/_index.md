---
title: Μετατροπή παρουσιάσεων PowerPoint σε Markdown σε Android
linktitle: PowerPoint σε Markdown
type: docs
weight: 140
url: /el/androidjava/convert-powerpoint-to-markdown/
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
  - Android
  - Java
  - Aspose.Slides
description: "Μετατρέψτε τις διαφάνειες PowerPoint—PPT, PPTX—σε καθαρό Markdown με Aspose.Slides για Android μέσω Java, αυτοματοποιήστε την τεκμηρίωση και διατηρήστε τη μορφοποίηση."
---
## **Εισαγωγή**

Το Aspose.Slides σας επιτρέπει να μετατρέψετε παρουσιάσεις PowerPoint σε Markdown, το οποίο μπορεί να είναι χρήσιμο για διαδικασίες τεκμηρίωσης, δημιουργία στατικών ιστοσελίδων, μεταφορά περιεχομένου και έκδοση κειμένου υπό έλεγχο έκδοσης. Το API υποστηρίζει άμεση εξαγωγή από παρουσιάσεις PPT και PPTX σε αρχεία MD και παρέχει πρόσθετες επιλογές για να ελέγχετε πώς θα αναπαρίστανται τα περιεχόμενα των διαφάνειων στο παραγόμενο έγγραφο Markdown.

Μπορείτε να εξάγετε τις παρουσιάσεις ως απλό Markdown, να επιλέξετε από πολλαπλές εκδοχές του Markdown όπως CommonMark και GitHub Flavored Markdown, και να ρυθμίσετε πώς διαχειρίζονται οι εικόνες κατά την εξαγωγή. Για παρουσιάσεις που περιέχουν οπτικό περιεχόμενο, το Aspose.Slides σας επιτρέπει επίσης να αποθηκεύετε τις εικόνες σε ξεχωριστό φάκελο και να τις αναφέρετε από το παραγόμενο αρχείο Markdown.

Το Aspose.Slides υποστηρίζει τη μετατροπή παρουσίασης σε markdown.

{{% alert color="warning" %}} 
Η εξαγωγή PowerPoint σε markdown είναι **χωρίς εικόνες** από προεπιλογή. Εάν θέλετε να εξάγετε ένα έγγραφο PowerPoint που περιέχει εικόνες, πρέπει να ορίσετε `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` και επίσης να ορίσετε το `BasePath` όπου θα αποθηκευτούν οι εικόνες που αναφέρονται στο έγγραφο markdown.
{{% /alert %}} 

## **Μετατροπή PowerPoint σε Markdown**

1. Δημιουργήστε μια εμφάνιση της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) για να αντιπροσωπεύει ένα αντικείμενο παρουσίασης.
2. Χρησιμοποιήστε τη μέθοδο [Αποθήκευση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) για να αποθηκεύσετε το αντικείμενο ως αρχείο markdown.

Αυτό το κώδικα Java σας δείχνει πώς να μετατρέψετε το PowerPoint σε markdown:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Μετατροπή PowerPoint σε Έκδοση Markdown**

Το Aspose.Slides σας επιτρέπει να μετατρέψετε το PowerPoint σε markdown (με βασική σύνταξη), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab και σε 17 άλλες εκδοχές markdown.

Αυτό το κώδικα Java σας δείχνει πώς να μετατρέψετε το PowerPoint σε CommonMark:
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

Οι 23 υποστηριζόμενες εκδοχές markdown παρατίθενται [στην απαρίθμηση Flavor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/flavor/) από την κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/).

## **Μετατροπή Παρουσίασης που Περιέχει Εικόνες σε Markdown**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownsaveoptions/) παρέχει ιδιότητες και απαριθμήσεις που σας επιτρέπουν να χρησιμοποιήσετε ορισμένες επιλογές ή ρυθμίσεις για το παραγόμενο αρχείο markdown. Η απαρίθμηση [MarkdownExportType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/markdownexporttype/), για παράδειγμα, μπορεί να οριστεί σε τιμές που καθορίζουν πώς θα αποδοθούν ή θα διαχειριστούν οι εικόνες: `Sequential`, `TextOnly`, `Visual`.

### **Μετατροπή Εικόνων Κατά Σειρά**

Εάν θέλετε οι εικόνες να εμφανίζονται μεμονωμένα μία μετά την άλλη στο παραγόμενο markdown, πρέπει να επιλέξετε την επιλογή sequential. Αυτός ο κώδικας Java σας δείχνει πώς να μετατρέψετε μια παρουσίαση που περιέχει εικόνες σε markdown:
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

Εάν θέλετε οι εικόνες να εμφανίζονται μαζί στο παραγόμενο markdown, πρέπει να επιλέξετε την επιλογή visual. Σε αυτή τη περίπτωση, οι εικόνες θα αποθηκευτούν στον τρέχοντα κατάλογο της εφαρμογής (και θα δημιουργηθεί σχετική διαδρομή για αυτές στο έγγραφο markdown), ή μπορείτε να καθορίσετε την προτιμώμενη διαδρομή και το όνομα καταλόγου.
Αυτός ο κώδικας Java επιδεικνύει τη λειτουργία:
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

**Παραμένουν οι υπερσυνδέσεις μετά την εξαγωγή σε Markdown;**

Ναι. Τα κείμενα [υπερσύνδεσμοι](/slides/el/androidjava/manage-hyperlinks/) διατηρούνται ως τυπικοί σύνδεσμοι Markdown. Οι [μεταβάσεις](/slides/el/androidjava/slide-transition/) και οι [κινήσεις](/slides/el/androidjava/powerpoint-animation/) των διαφανειών δεν μετατρέπονται.

**Μπορώ να επιταχύνω τη μετατροπή τρέχοντάς την σε πολλαπλά νήματα;**

Μπορείτε να παράλληλοποιήσετε ανά αρχείο, όμως [μην μοιράζεστε](/slides/el/androidjava/multithreading/) την ίδια [Παρουσίαση](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) μεταξύ νημάτων. Χρησιμοποιήστε ξεχωριστές εμφανίσεις/διεργασίες ανά αρχείο για να αποφύγετε τον ανταγωνισμό.

**Τι συμβαίνει με τις εικόνες — πού αποθηκεύονται και είναι οι διαδρομές σχετικές;**

Οι [εικόνες](/slides/el/androidjava/image/) εξάγονται σε έναν αφιερωμένο φάκελο, και το αρχείο Markdown τις αναφέρει με σχετικές διαδρομές από προεπιλογή. Μπορείτε να ρυθμίσετε τη βασική διαδρομή εξόδου και το όνομα του φακέλου πόρων για να διατηρήσετε μια προβλέψιμη δομή αποθετηρίου.