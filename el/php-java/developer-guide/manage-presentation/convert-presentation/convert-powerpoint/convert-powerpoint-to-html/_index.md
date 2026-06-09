---
title: Μετατροπή παρουσιάσεων PowerPoint σε HTML με PHP
linktitle: PowerPoint σε HTML
type: docs
weight: 30
url: /el/php-java/convert-powerpoint-to-html/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε HTML
- παρουσίαση σε HTML
- διαφάνεια σε HTML
- PPT σε HTML
- PPTX σε HTML
- αποθήκευση PowerPoint ως HTML
- αποθήκευση παρουσίασης ως HTML
- αποθήκευση διαφάνειας ως HTML
- αποθήκευση PPT ως HTML
- αποθήκευση PPTX ως HTML
- εξαγωγή PPT σε HTML
- εξαγωγή PPTX σε HTML
- PHP
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint σε HTML με PHP. Χρησιμοποιήστε το Aspose.Slides για εξαγωγή αρχείων PPT και PPTX, επιλεγμένων διαφανειών, σημειώσεων, γραμματοσειρών, εικόνων, SVG και πολυμέσων."
---
## **Επισκόπηση**

Το Aspose.Slides for PHP via Java μπορεί να αποθηκεύει παρουσιάσεις PowerPoint ως HTML χωρίς το Microsoft PowerPoint. Η βασική μετατροπή αποτελείται από ένα μόνο φόρτωμα [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και μια κλήση `save` με [SaveFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/). Χρησιμοποιήστε [HtmlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/) όταν χρειάζεται να ελέγξετε τη διάταξη εξαγωγής, τις γραμματοσειρές, τις εικόνες, τις σημειώσεις, τα σχόλια, την έξοδο SVG ή τους συνδεδεμένους πόρους.

Αυτός ο οδηγός εστιάζει σε πρακτικά σενάρια εξαγωγής HTML:

- Εξαγωγή ολόκληρης παρουσίασης ή επιλεγμένων διαφανειών.
- Δημιουργία HTML με σταθερή διάταξη, ανταποκρινόμενο ή βασισμένο σε SVG.
- Συμπερίληψη σημειώσεων ομιλητή και σχολίων.
- Έλεγχος ποιότητας εικόνας και δεδομένων περικομμένων εικόνων.
- Ενσωμάτωση γραμματοσειρών ή αποθήκευση αρχείων γραμματοσειρών ξεχωριστά.
- Επιλογή του πώς γράφονται και αναφέρονται οι εξωτερικοί πόροι και αρχεία πολυμέσων.

Από προεπιλογή, η εξαγωγή HTML παράγει ένα αυτόνομο αρχείο HTML όπου οι περισσότεροι πόροι είναι ενσωματωμένοι. Αυτό είναι βολικό για κοινή χρήση ενός αρχείου, αλλά μπορεί να αυξήσει το μέγεθος εξόδου. Για δημοσίευση στον ιστό, λάβετε υπόψη εξωτερικούς πόρους, χαμηλότερο DPI εικόνας και ενσωμάτωση μόνο των γραμματοσειρών που δεν είναι αξιόπιστα διαθέσιμες στο περιβάλλον‑στόχο.

## **Μετατροπή Παρουσίασης σε HTML**

Για να εξάγετε μια παρουσίαση σε HTML, φορτώστε την με [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και αποθηκεύστε την με [SaveFormat.Html](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Αυτό το παράδειγμα γράφει ένα αρχείο HTML. Το αντικείμενο παρουσίασης διαγράφεται στο μπλοκ `finally`, το οποίο απελευθερώνει τους χειριστές αρχείων και τους πόρους απόδοσης μετά την εξαγωγή.

## **Χρήση HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/) είναι η κύρια κλάδα διαμόρφωσης για την εξαγωγή HTML. Συνηθισμένες ρυθμίσεις περιλαμβάνουν:

- `SlidesLayoutOptions`: προσθέτει σημειώσεις, σχόλια, φυλλάδια ή άλλες πληροφορίες διάταξης.
- `HtmlFormatter`: αλλάζει τη δομή του εγγράφου HTML ή παραχωρεί τη μορφοποίηση σε έναν ελεγκτή.
- `SlideImageFormat`: αλλάζει τον τρόπο παρουσίασης των διαφανειών, για παράδειγμα ως SVG.
- `PicturesCompression`: ελέγχει το DPI της εικόνας και το μέγεθος εξόδου.
- `DeletePicturesCroppedAreas`: διατηρεί ή αφαιρεί δεδομένα περικομμένων εικόνων.
- `SvgResponsiveLayout`: κάνει το εξαγόμενο περιεχόμενο SVG να προσαρμόζεται στο περιέκτη του.
- `ShowHiddenSlides`: συμπεριλαμβάνει κρυφές διαφάνειες όταν απαιτείται.

Οι παρακάτω ενότητες δείχνουν τις πιο συνηθισμένες επιλογές ξεχωριστά ώστε να μπορείτε να συνδυάσετε μόνο αυτές που χρειάζονται στη ροή εργασίας σας.

## **Μετατροπή Επιλεγμένων Διαφανειών σε HTML**

Η υπερφόρτωση `save` που δέχεται αριθμούς διαφανειών χρησιμοποιεί θέσεις διαφανειών 1‑βάση. Ο παρακάτω βρόχος αποθηκεύει κάθε διαφάνεια σε ξεχωριστό αρχείο HTML.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

Χρησιμοποιήστε αυτό το πρότυπο όταν μια ιστοσελίδα ή εφαρμογή χρειάζεται μία σελίδα HTML ανά διαφάνεια. Αν κάθε διαφάνεια πρέπει να έχει την ίδια διάταξη, δημιουργήστε μία διεπαφή [HtmlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/) και περάστε την σε κάθε κλήση `save`.

## **Δημιουργία Απάντεχου HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/el/php-java/aspose.slides/responsivehtmlcontroller/) παρέχει απάντεχη έξοδο HTML μέσω του [HtmlFormatter](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmlformatter/). Χρησιμοποιήστε το όταν η εξαγόμενη σελίδα πρέπει να προσαρμόζεται καλύτερα στο πλάτος του προγράμματος περιήγησης.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Για απάντεχη διάταξη βασισμένη σε SVG, ορίστε το `SvgResponsiveLayout` στο [HtmlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/). Αυτό είναι χρήσιμο όταν το περιεχόμενο της διαφάνειας εξάγεται ως επεκτάσιμη markup SVG.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Συμπερίληψη Σημειώσεων Ομιλητή και Σχολίων**

Χρησιμοποιήστε το [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/notescommentslayoutingoptions/) μέσω του `HtmlOptions.SlidesLayoutOptions` για να συμπεριλάβετε σημειώσεις ομιλητή ή σχόλια. Οι σημειώσεις και τα σχόλια κρύβονται από προεπιλογή εκτός αν επιλέξετε τις θέσεις τους.

Ας υποθέσουμε ότι η πηγαία παρουσίαση περιέχει σημειώσεις ομιλητή:

![Διαφάνεια με σημειώσεις ομιλητή στο PowerPoint](slide_with_notes.png)

Ο παρακάτω κώδικας εξάγει το περιεχόμενο της διαφάνειας με τις σημειώσεις ομιλητή κάτω από τη διαφάνεια.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

![Έξοδος HTML με τη διαφάνεια και τις σημειώσεις ομιλητή](HTML_with_notes.png)

Για να εξάγετε σχόλια, ορίστε `CommentsPosition`, π.χ. σε `CommentsPositions.Right` ή `CommentsPositions.Bottom`. Εάν χρειάζεστε μόνο σχόλια, παραλείψτε το `NotesPosition`. Εάν χρειάζεστε και τις δύο, σημειώσεις και σχόλια, ορίστε και τις δύο ιδιότητες.

## **Έλεγχος Ποιότητας Εικόνας και Περικομμένων Περιοχών**

Η εξαγωγή HTML μπορεί να συμπιέσει τις εικόνες των διαφανειών για να μειώσει το μέγεθος εξόδου. Ορίστε το `PicturesCompression` σε μια τιμή από το [PicturesCompression](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturescompression/) όταν χρειάζεστε υψηλότερη ποιότητα εικόνας.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Από προεπιλογή, οι περικομμένες περιοχές των εικόνων μπορεί να αφαιρεθούν από την εξαγόμενη έξοδο. Διατηρήστε τα περικομμένα δεδομένα μόνο όταν οι χρήστες πρέπει να μπορούν να επαναφέρουν ή να επιθεωρήσουν αυτά τα κρυφά μέρη της εικόνας. Η διατήρηση μπορεί να αυξήσει το μέγεθος του HTML.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Προσθήκη CSS**

Για απλή μορφοποίηση, περάστε μια συμβολοσειρά CSS στο [HtmlFormatter](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmlformatter/) μέσω του `createDocumentFormatter`. Αυτό αλλάζει το περιβάλλοντος έγγραφο HTML ενώ το Aspose.Slides συνεχίζει να αποδίδει το περιεχόμενο της διαφάνειας.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Για προσαρμοσμένη κεφαλίδα εγγράφου, ένα συνδεδεμένο αρχείο CSS ή προσαρμοσμένο markup γύρω από διαφάνειες και σχήματα, χρησιμοποιήστε έναν προσαρμοσμένο ελεγκτή μορφοποίησης και περάστε το στο [HtmlFormatter](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmlformatter/) με το `createCustomFormatter`.

## **Ενσωμάτωση Γραμματοσειρών**

Εάν το περιβάλλον‑στόχος δεν έχει εγκατεστημένες τις γραμματοσειρές της παρουσίασης, ενσωματώστε τις γραμματοσειρές στο HTML με το [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/el/php-java/aspose.slides/embedallfontshtmlcontroller/). Η ενσωμάτωση βελτιώνει την οπτική πιστότητα αλλά αυξάνει το μέγεθος εξόδου.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Αποκλείστε τις γραμματοσειρές μόνο όταν είστε βέβαιοι ότι οι προοριζόμενοι περιηγητές ή συστήματα τις παρέχουν ήδη. Για γραμματοσειρές εταιρικής ταυτότητας ή λιγότερο κοινές γραμματοσειρές, η ενσωμάτωση είναι συνήθως πιο ασφαλής.

## **Σύνδεση Αρχείων Γραμματοσειρών Αντί Ενσωμάτωσής τους**

Για να μειώσετε το μέγεθος του αρχείου HTML, μπορείτε να γράψετε τα δεδομένα της γραμματοσειράς σε ξεχωριστά αρχεία WOFF και να προσθέσετε κανόνες `@font-face` στο HTML. Στο PHP μέσω Java, αυτό το σενάριο υλοποιείται συνήθως με μια μικρή βοηθητική κλάση Java που κληρονομεί το [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/el/php-java/aspose.slides/embedallfontshtmlcontroller/), γράφει τα byte της γραμματοσειράς σε έναν φάκελο εξόδου και ενσωματώνει κανόνες `@font-face` στο παραγόμενο HTML. Συγκομποιήστε αυτήν τη βοηθητική κλάση, προσθέστε τη στη διαδρομή κλάσεων του PHP Java Bridge και, στη συνέχεια, δημιουργήστε ένα αντικείμενο από PHP με `new Java(...)`.

Όταν δημιουργείτε τέτοιο βοηθητικό πρόγραμμα, επιλέξτε σκόπιμα δύο διαδρομές:

- Η διαδρομή εξόδου στο σύστημα αρχείων, όπου γράφονται τα παραγόμενα αρχεία γραμματοσειρών.
- Η διαδρομή URL, που είναι αυτή που χρησιμοποιεί το πρόγραμμα περιήγησης από το έγγραφο HTML για τη φόρτωση αυτών των αρχείων γραμματοσειρών.

## **Αποθήκευση Πόρων Εξωτερικά**

Το αυτόνομο HTML είναι εύκολο να μετακινείται, αλλά οι ενσωματωμένοι πόροι Base64 μπορούν να κάνουν το αρχείο μεγάλο. Εάν η εφαρμογή σας χρειάζεται εξωτερικά αρχεία εικόνας, παρέχετε έναν προσαρμοσμένο ελεγκτή σύνδεσης/ενσωμάτωσης στον κατασκευαστή του [HtmlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/).

Όταν εξωτερικοποιείτε πόρους, επιλέξτε σκόπιμα δύο διαδρομές:

- Η διαδρομή εξόδου στο σύστημα αρχείων, όπου η εφαρμογή σας γράφει τις παραγόμενες εικόνες, γραμματοσειρές, ήχο ή βίντεο.
- Η διαδρομή URL, που είναι αυτή που χρησιμοποιεί το πρόγραμμα περιήγησης από το έγγραφο HTML για τη φόρτωση εκείνων των αρχείων.

Διατηρήστε αυτές τις διαδρομές συνεπείς με τη διάταξη ανάπτυξης ώστε το παραγόμενο HTML να μπορεί να φορτώνει τους εξωτερικούς πόρους του μετά τη μεταφορά του σε διακομιστή ιστού ή σε άλλο φάκελο.

## **Εξαγωγή Αρχείων Πολυμέσων**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoplayerhtmlcontroller/) εξάγει αρχεία βίντεο και ήχου και γράφει HTML που μπορεί να τα αναπαράγει σε πρόγραμμα περιήγησης. Ο κατασκευαστής του δέχεται:

- `path`: ο φάκελος εξόδου που χρησιμοποιείται από το παραγόμενο HTML και τα αρχεία πολυμέσων.
- `fileName`: το όνομα του αρχείου HTML που δημιουργείται.
- `baseUri`: το απόλυτο πρόθεμα URI που χρησιμοποιείται στους συνδέσμους HTML προς τα αρχεία πολυμέσων.

Αν το αρχείο HTML είναι `html-output/presentation.html`, το `path` πρέπει να δείχνει στο `html-output`, και το `baseUri` πρέπει να δείχνει στον ίδιο φάκελο από την άποψη του προγράμματος περιήγησης. Για τοπική προεπισκόπηση, μπορείτε να δημιουργήσετε ένα URI `file:///` από τον φάκελο εξόδου. Για μια αναπτυγμένη εφαρμογή, χρησιμοποιήστε το απόλυτο URL του δημοσιευμένου φακέλου εξόδου.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

Χρησιμοποιήστε φακέλους εξόδου που είναι μοναδικοί για κάθε εργασία εξαγωγής, ειδικά σε εφαρμογές διακομιστή. Κοινές διαδρομές εξόδου μπορούν να προκαλέσουν αντικατάσταση αρχείων από διαφορετικές μετατροπές.

## **Απόδοση και Διαχείριση Πόρων**

Η μετατροπή HTML είναι μια λειτουργία απόδοσης, επομένως ο χρόνος επεξεργασίας και η χρήση μνήμης εξαρτώνται από τον αριθμό διαφανειών, την ανάλυση εικόνας, τις γραμματοσειρές, τα εφέ, τα διαγράμματα και τα ενσωματωμένα πολυμέσα. Οι υψηλότερες τιμές DPI του `PicturesCompression`, οι ενσωματωμένες γραμματοσειρές, η έξοδος SVG και η διατήρηση των περικομμένων περιοχών εικόνας μπορούν να βελτιώσουν την πιστότητα αλλά συνήθως αυξάνουν το μέγεθος εξόδου.

Για μαζική μετατροπή:

- Διαγράψτε άμεσα κάθε παρουσίαση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
- Χρησιμοποιήστε ξεχωριστούς φακέλους εξόδου για ξεχωριστές εργασίες.
- Αποφύγετε την ενσωμάτωση κοινών γραμματοσειρών εκτός εάν η πιστότητα το απαιτεί.
- Μειώστε το DPI της εικόνας όταν το HTML προορίζεται για προεπισκόπηση ή μικρογραφίες.
- Διατηρήστε την πηγαία παρουσίαση, το παραγόμενο HTML και τους εξωτερικούς πόρους μαζί μέχρι οι διαδρομές ανάπτυξης να είναι τελικές.

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι υπερσυνδέσμοι στην έξοδο HTML;**

Ναι. Οι υπερσύνδεσμοι της παρουσίασης εξάγονται σε HTML και παραμένουν κλικαρίθμιτοι όταν η URL προορισμού είναι έγκυρη.

**Μπορώ να μετατρέπω παρουσιάσεις σε HTML παράλληλα;**

Ναι, αλλά μην μοιράζεστε μία παρουσίαση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) μεταξύ νημάτων. Επεξεργαστείτε διαφορετικά αρχεία με ξεχωριστές παρουσίες παρουσίασης, ξεχωριστά ροές και ξεχωριστούς φακέλους εξόδου.

**Είναι το αντικείμενο Presentation ασφαλές για πολλαπλά νήματα;**

Όχι. Μία μόνο παρουσίαση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) θα πρέπει να φορτώνεται, τροποποιείται, αποθηκεύεται και διαγράφεται σε ένα νήμα. Για παράλληλη εργασία, δημιουργήστε ανεξάρτητη παρουσίαση ανά νήμα ή διαδικασία.

**Γιατί το παραγόμενο αρχείο HTML είναι μεγάλο;**

Η προεπιλεγμένη εξαγωγή μπορεί να ενσωματώνει πόρους απευθείας στο HTML. Ενσωματωμένες γραμματοσειρές, εικόνες υψηλού DPI, πολυμέσα, περιεχόμενο SVG και διατηρημένες περικομμένες περιοχές εικόνας επίσης αυξάνουν το μέγεθος. Χρησιμοποιήστε εξωτερικούς πόρους, αποκλείστε τις κοινές γραμματοσειρές από την ενσωμάτωση και μειώστε το `PicturesCompression` όταν το μικρότερο μέγεθος είναι πιο σημαντικό από τη μέγιστη πιστότητα.

**Γιατί ένα μέγεθος γραμματοσειράς PowerPoint όπως 24 pt εμφανίζεται ως 17.999819 pt στο HTML;**

Αυτό μπορεί να συμβαίνει επειδή το PowerPoint και το HTML χρησιμοποιούν διαφορετικά μοντέλα DPI. Το PowerPoint αποθηκεύει τα μεγέθη κειμένου σε τυπογραφικά σημεία βασισμένα σε 72 DPI, ενώ η διάταξη HTML βασίζεται σε pixel CSS σε μοντέλο 96 DPI. Όταν το Aspose.Slides εξάγει μια παρουσίαση σε HTML, το μέγεθος γραμματοσειράς μεταφράζεται μεταξύ αυτών των συστημάτων, και η μετατροπή μπορεί να εισαγάγει μικρές στρογγυλοποιητικές διαφορές.

Αυτές οι τιμές δεν υποδεικνύουν πραγματική οπτική αλλαγή του μεγέθους της γραμματοσειράς. Είναι μόνο ένα μαθηματικό παράπλευρο αποτέλεσμα της μετατροπής των μετρικών κειμένου μεταξύ PowerPoint και HTML.

**Πώς πρέπει να επιλέξω το baseUri για την εξαγωγή πολυμέσων;**

Επιλέξτε το `baseUri` από την άποψη του προγράμματος περιήγησης και περάστε το ως απόλυτο URI. Για τοπική προεπισκόπηση, μπορείτε να το προεξάγετε από το φάκελο εξόδου με ένα URI αρχείου Java. Για ανάπτυξη, χρησιμοποιήστε το απόλυτο URL του δημοσιευμένου φακέλου πολυμέσων. Το `path` του συστήματος αρχείων και το `baseUri` του προγράμματος περιήγησης δεν χρειάζεται να είναι η ίδια συμβολοσειρά, αλλά πρέπει να περιγράφουν την ίδια θέση πόρου.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες;**

Ναι. Ορίστε το `ShowHiddenSlides` σε `true` στο [HtmlOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/htmloptions/) όταν πρέπει να εξαχθούν κρυφές διαφάνειες.