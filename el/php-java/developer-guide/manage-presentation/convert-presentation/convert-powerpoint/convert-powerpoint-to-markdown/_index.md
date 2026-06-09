---
title: Μετατροπή Παρουσιάσεων PowerPoint σε Markdown σε PHP
linktitle: PowerPoint σε Markdown
type: docs
weight: 140
url: /el/php-java/convert-powerpoint-to-markdown/
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
- PHP
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες PowerPoint — PPT, PPTX — σε καθαρό Markdown με Aspose.Slides για PHP μέσω Java, αυτοματοποιήστε την τεκμηρίωση και διατηρήστε τη μορφοποίηση."
---
## **Εισαγωγή**

Aspose.Slides σάς επιτρέπει να μετατρέπετε παρουσιάσεις PowerPoint σε Markdown, κάτι που μπορεί να είναι χρήσιμο για ροές εργασίας τεκμηρίωσης, δημιουργία στατικών ιστοτόπων, μεταφορά περιεχομένου και έκδοση κειμένων με έλεγχο εκδόσεων. Το API υποστηρίζει άμεση εξαγωγή από παρουσιάσεις PPT και PPTX σε αρχεία MD και προσφέρει πρόσθετες επιλογές για τον έλεγχο του τρόπου με τον οποίο το περιεχόμενο των διαφανειών αναπαρίσταται στο τελικό έγγραφο Markdown.

Μπορείτε να εξάγετε παρουσιάσεις ως απλό Markdown, να επιλέξετε από πολλές γεύσεις Markdown όπως CommonMark και GitHub Flavored Markdown, και να ρυθμίσετε πώς διαχειρίζονται οι εικόνες κατά την εξαγωγή. Για παρουσιάσεις που περιέχουν οπτικό περιεχόμενο, το Aspose.Slides σας επιτρέπει επίσης να αποθηκεύετε τις εικόνες σε ξεχωριστό φάκελο και να τις αναφέρετε από το παραγόμενο αρχείο Markdown.

{{% alert color="warning" %}}

Η εξαγωγή PowerPoint‑to‑Markdown είναι **χωρίς εικόνες** εξ ορισμού. Εάν θέλετε να εξάγετε ένα έγγραφο PowerPoint που περιέχει εικόνες, πρέπει να ορίσετε `ExportType = MarkdownExportType::Visual` και να καθορίσετε το `BasePath`, όπου οι εικόνες που θα αναφέρονται στο έγγραφο Markdown θα αποθηκευτούν.

{{% /alert %}}

## **Μετατροπή Παρουσίασης σε Markdown**

Αυτή η ενότητα εξηγεί πώς το Aspose.Slides μετατρέπει παρουσιάσεις PowerPoint και OpenDocument (PPT, PPTX, ODP) σε καθαρό Markdown, διατηρώντας την αρχική ιεραρχία διαφανειών, το κείμενο και τη βασική μορφοποίηση ώστε να μπορείτε να επαναχρησιμοποιήσετε το περιεχόμενο σε τεκμηρίωση ή ροές εργασίας με έλεγχο εκδόσεων χωρίς πρόσθετη χειροκίνητη παρέμβαση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) για να αντιπροσωπεύει την παρουσίαση.
1. Χρησιμοποιήστε τη μέθοδο [save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save) για να την εξάγετε ως αρχείο Markdown.

Αυτός ο κώδικας PHP δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Μετατροπή Παρουσίασης σε Γεύση Markdown**

Το Aspose.Slides σας επιτρέπει να μετατρέψετε παρουσιάσεις PowerPoint σε Markdown με βασική σύνταξη, καθώς και σε CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab και δεκαεπτά άλλες γεύσεις Markdown.

Ο παρακάτω κώδικας PHP παρουσιάζει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε CommonMark:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

Οι 23 υποστηριζόμενες γεύσεις Markdown παρατίθενται στην [Flavor enumeration](https://reference.aspose.com/slides/el/php-java/aspose.slides/flavor/).

## **Μετατροπή Παρουσίασης που Περιέχει Εικόνες σε Markdown**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownsaveoptions/) εκθέτει ιδιότητες και απαρίθμηση που σας επιτρέπουν να διαμορφώσετε το τελικό αρχείο Markdown. Για παράδειγμα, η απαρίθμηση [MarkdownExportType](https://reference.aspose.com/slides/el/php-java/aspose.slides/markdownexporttype/) καθορίζει πώς διαχειρίζονται οι εικόνες: `Sequential`, `TextOnly` ή `Visual`.

{{% alert color="warning" %}}

Από προεπιλογή, η εξαγωγή PowerPoint‑to‑Markdown **δεν περιλαμβάνει εικόνες**. Για να ενσωματώσετε εικόνες, καλέστε `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` και ορίστε το `BasePath` που υποδεικνύει πού θα αποθηκευτούν οι εικόνες που αναφέρονται στο αρχείο Markdown.

{{% /alert %}}

### **Μετατροπή Εικόνων Διαδοχικά**

Εάν θέλετε οι εικόνες να εμφανίζονται ξεχωριστά, η μία μετά την άλλη, στο παραγόμενο Markdown, πρέπει να επιλέξετε την επιλογή `Sequential`. Ο παρακάτω κώδικας PHP δείχνει πώς να μετατρέψετε μια παρουσίαση που περιέχει εικόνες σε Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **Μετατροπή Εικόνων Οπτικά**

Εάν θέλετε οι εικόνες να εμφανίζονται μαζί στο παραγόμενο Markdown, πρέπει να επιλέξετε την επιλογή `Visual`. Σε αυτή την περίπτωση, οι εικόνες αποθηκεύονται στον τρέχοντα κατάλογο της εφαρμογής (και δημιουργείται σχετική διαδρομή για αυτές στο έγγραφο Markdown), ή μπορείτε να καθορίσετε τον προτιμώμενο κατάλογο και όνομα φακέλου.

Ο παρακάτω κώδικας PHP παρουσιάζει τη λειτουργία:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι υπερσυνδέσεις κατά την εξαγωγή σε Markdown;**

Ναι. Τα κείμενα [hyperlinks](/slides/el/php-java/manage-hyperlinks/) διατηρούνται ως τυπικοί σύνδεσμοι Markdown. Οι [transitions](/slides/el/php-java/slide-transition/) και [animations](/slides/el/php-java/powerpoint-animation/) των διαφανειών δεν μετατρέπονται.

**Μπορώ να επιταχύνω τη μετατροπή τρέχοντάς την σε πολλαπλά νήματα;**

Μπορείτε να παράλληλα επεξεργαστείτε διαφορετικά αρχεία, αλλά [don’t share](/slides/el/php-java/multithreading/) την ίδια παρουσίαση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) μεταξύ νημάτων. Χρησιμοποιήστε ξεχωριστές παρουσίες/διεργασίες ανά αρχείο ώστε να αποφύγετε τον ανταγωνισμό.

**Τι γίνεται με τις εικόνες — πού αποθηκεύονται και είναι οι διαδρομές σχετικές;**

Οι [Images](/slides/el/php-java/image/) εξάγονται σε έναν αφιερωμένο φάκελο, και το αρχείο Markdown τις αναφέρει με σχετικές διαδρομές εξ ορισμού. Μπορείτε να ρυθμίσετε τη βασική διαδρομή εξόδου και το όνομα του φακέλου περιουσιακών στοιχείων για να διατηρείται μια προβλέψιμη δομή αποθετηρίου.