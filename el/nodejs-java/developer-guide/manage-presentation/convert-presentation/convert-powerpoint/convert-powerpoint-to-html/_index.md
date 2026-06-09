---
title: Μετατροπή παρουσιάσεων PowerPoint σε HTML στο Node.js
linktitle: PowerPoint σε HTML
type: docs
weight: 30
url: /el/nodejs-java/convert-powerpoint-to-html/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατροπή παρουσιάσεων PowerPoint σε HTML στο Node.js. Χρησιμοποιήστε το Aspose.Slides για Node.js μέσω Java για εξαγωγή αρχείων PPT και PPTX, επιλεγμένων διαφανειών, σημειώσεων, γραμματοσειρών, εικόνων, SVG και πολυμέσων."
---
## **Επισκόπηση**

Το Aspose.Slides για Node.js μέσω Java μπορεί να αποθηκεύσει παρουσιάσεις PowerPoint ως HTML χωρίς το Microsoft PowerPoint. Η βασική μετατροπή αποτελείται από ένα μόνο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) φόρτωμα και μια κλήση `save` με [SaveFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/). Χρησιμοποιήστε [HtmlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/htmloptions/) όταν χρειάζεται να ελέγξετε τη διάταξη, τις γραμματοσειρές, τις εικόνες, τις σημειώσεις, τα σχόλια, την έξοδο SVG ή τους συνδεδεμένους πόρους.

Αυτή η οδηγία εστιάζει σε πρακτικά σενάρια εξαγωγής HTML:

- Εξαγωγή ολόκληρης παρουσίασης ή επιλεγμένων διαφάνειων.
- Δημιουργία HTML σταθερής διάταξης, προσαρμοζόμενης ή βασισμένης σε SVG.
- Συμπερίληψη σημειώσεων ομιλητή και σχολίων.
- Έλεγχος ποιότητας εικόνας και δεδομένων περικομμένων εικόνων.
- Ενσωμάτωση γραμματοσειρών ή αποθήκευση αρχείων γραμματοσειρών ξεχωριστά.
- Επιλογή τρόπου γραφής και αναφοράς εξωτερικών πόρων και αρχείων πολυμέσων.

Από προεπιλογή, η εξαγωγή HTML παράγει ένα αυτόνομο έγγραφο HTML όπου οι περισσότερες πηγές είναι ενσωματωμένες. Αυτό είναι βολικό για κοινή χρήση ενός αρχείου, αλλά μπορεί να αυξήσει το μέγεθος της εξόδου. Για δημοσίευση στο web, σκεφτείτε εξωτερικούς πόρους, χαμηλότερο DPI εικόνας και ενσωμάτωση μόνο των γραμματοσειρών που δεν είναι αξιόπιστα διαθέσιμες στο περιβάλλον προορισμού.

## **Μετατροπή μιας Presentation σε HTML**

Για να εξάγετε μια παρουσίαση σε HTML, φορτώστε τη με [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και αποθηκεύστε τη με [SaveFormat.Html](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Αυτό το παράδειγμα γράφει ένα αρχείο HTML. Το αντικείμενο παρουσίασης διαγραφεί στο μπλοκ `finally`, το οποίο απελευθερώνει τους χειριστές αρχείων και τους πόρους απόδοσης μετά την εξαγωγή.

## **Χρήση HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/htmloptions/) είναι η κύρια κλάση ρύθμισης για την εξαγωγή HTML. Συνηθισμένες ρυθμίσεις περιλαμβάνουν:

- `SlidesLayoutOptions`: προσθέτει σημειώσεις, σχόλια, φυλλάδια ή άλλες πληροφορίες διάταξης.
- `HtmlFormatter`: αλλάζει τη δομή του εγγράφου HTML ή παραχωρεί τη διαμόρφωση σε έναν ελεγκτή.
- `SlideImageFormat`: αλλάζει τον τρόπο αναπαράστασης των διαφάνειων, για παράδειγμα ως SVG.
- `PicturesCompression`: ελέγχει το DPI της εικόνας και το μέγεθος εξόδου.
- `DeletePicturesCroppedAreas`: διατηρεί ή αφαιρεί τα δεδομένα περικομμένων εικόνων.
- `SvgResponsiveLayout`: προσαρμόζει το εξαγόμενο περιεχόμενο SVG στο κοντέινερ του.
- `ShowHiddenSlides`: περιλαμβάνει κρυμμένες διαφάνειες όταν απαιτείται.

Οι παρακάτω ενότητες δείχνουν τις πιο συνήθεις επιλογές ξεχωριστά ώστε να μπορείτε να συνδυάσετε μόνο εκείνες που χρειάζεται η ροή εργασίας σας.

## **Μετατροπή Επιλεγμένων Διαφάνειων σε HTML**

Η υπερφόρτωση `Presentation.save` που δέχεται αριθμούς διαφάνειας χρησιμοποιεί θέσεις διαφάνειας με βάση το 1. Ο βρόχος παρακάτω αποθηκεύει κάθε διαφάνεια σε ξεχωριστό αρχείο HTML.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε αυτό το πρότυπο όταν ένας ιστότοπος ή μια εφαρμογή χρειάζεται μία σελίδα HTML ανά διαφάνεια. Αν κάθε διαφάνεια πρέπει να έχει την ίδια διάταξη, δημιουργήστε ένα στιγμιότυπο [HtmlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/htmloptions/) και περάστε το σε κάθε κλήση `save`.

## **Δημιουργία Responsive HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/responsivehtmlcontroller/) παρέχει responsive HTML έξοδο μέσω του [HtmlFormatter](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/htmlformatter/). Χρησιμοποιήστε το όταν η εξαγόμενη σελίδα πρέπει να προσαρμόζεται καλύτερα στο πλάτος του προγράμματος περιήγησης.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Για responsive διάταξη βασισμένη σε SVG, ορίστε `SvgResponsiveLayout` στο [HtmlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/htmloptions/). Αυτό είναι χρήσιμο όταν το περιεχόμενο της διαφάνειας εξάγεται ως κλιμακούμενο SVG markup.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Συμπερίληψη Σημειώσεων Ομιλητή και Σχολίων**

Χρησιμοποιήστε [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/notescommentslayoutingoptions/) μέσω `HtmlOptions.setSlidesLayoutOptions` για να συμπεριλάβετε σημειώσεις ομιλητή ή σχόλια. Οι σημειώσεις και τα σχόλια είναι κρυμμένα από προεπιλογή εκτός εάν επιλέξετε τις θέσεις τους.

Υποθέτουμε ότι η πηγαία παρουσίαση περιέχει σημειώσεις ομιλητή:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Ο παρακάτω κώδικας εξάγει το περιεχόμενο της διαφάνειας με τις σημειώσεις ομιλητή κάτω από τη διαφάνεια.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Το εξαγόμενο HTML περιλαμβάνει την περιοχή σημειώσεων:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Για εξαγωγή σχολίων, ορίστε `CommentsPosition`, π.χ. σε `CommentsPositions.Right` ή `CommentsPositions.Bottom`. Αν χρειάζεστε μόνο σχόλια, παραλείψτε το `NotesPosition`. Αν χρειάζεστε και τις δύο, ορίστε και τις δύο ιδιότητες.

## **Έλεγχος Ποιότητας Εικόνας και Περικομμένων Περιοχών**

Η εξαγωγή HTML μπορεί να συμπιέσει τις εικόνες των διαφάνειων για μείωση του μεγέθους εξόδου. Ορίστε `PicturesCompression` σε τιμή από το [PicturesCompression](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturescompression/) όταν χρειάζεται υψηλότερη ποιότητα εικόνας.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Από προεπιλογή, οι περιοχές περικομμένων εικόνων μπορεί να αφαιρεθούν από την εξαγόμενη έξοδο. Διατηρήστε τα περικομμένα δεδομένα μόνο όταν οι χρήστες πρέπει να μπορούν να τα ανακτήσουν ή να τα εξετάσουν. Η διατήρησή τους μπορεί να αυξήσει το μέγεθος του HTML.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη CSS**

Για απλό στυλ, περάστε μια συμβολοσειρά CSS στο `HtmlFormatter.createDocumentFormatter`. Αυτό αλλάζει το περιβάλλον του HTML εγγράφου ενώ το Aspose.Slides συνεχίζει να αποδίδει το περιεχόμενο της διαφάνειας.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Για προσαρμοσμένη κεφαλίδα εγγράφου, συνδεδεμένο αρχείο CSS ή προσαρμοσμένο markup γύρω από τις διαφάνειες και τα σχήματα, χρησιμοποιήστε το [HtmlFormatter](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/htmlformatter/) με έναν ελεγκτή διαμόρφωσης.

## **Ενσωμάτωση Γραμματοσειρών**

Αν το περιβάλλον προορισμού ενδέχεται να μην έχει εγκατεστημένες τις γραμματοσειρές της παρουσίασης, ενσωματώστε τις γραμματοσειρές στο HTML με το [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). Η ενσωμάτωση βελτιώνει την οπτική πιστότητα αλλά αυξάνει το μέγεθος εξόδου.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Αποκλείστε τις γραμματοσειρές μόνο όταν είστε σίγουροι ότι οι προοριστικοί περιηγητές ή συστήματα τις παρέχουν ήδη. Για εταιρικές ή λιγότερο κοινές γραμματοσειρές, η ενσωμάτωση είναι συνήθως πιο ασφαλής.

## **Σύνδεση Αρχείων Γραμματοσειρών αντί για Ενσωμάτωση**

Για μείωση του μεγέθους του αρχείου HTML, μπορείτε να γράψετε τα δεδομένα γραμματοσειράς σε ξεχωριστά αρχεία WOFF και να προσθέσετε κανόνες `@font-face` στο HTML. Στο Node.js μέσω Java, αυτό το σενάριο υλοποιείται συνήθως με μια μικρή βοηθητική κλάση Java που κληρονομεί το [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/embedallfontshtmlcontroller/), γράφει τα byte της γραμματοσειράς σε έναν φάκελο εξόδου και ενσωματώνει τους κανόνες `@font-face` στο παραγόμενο HTML. Συγκεντρώστε αυτή τη βοηθητική κλάση, προσθέστε την στο classpath του Node.js module και, στη συνέχεια, δημιουργήστε την από JavaScript με `java.newInstanceSync`.

Κατά τη δημιουργία μιας τέτοιας βοηθητικής κλάσης, επιλέξτε σκόπιμα δύο διαδρομές:

- Η διαδρομή εξόδου στο σύστημα αρχείων, όπου γράφονται τα παραγόμενα αρχεία γραμματοσειρών.
- Η διαδρομή URL, που είναι αυτή που ο προγράμματα περιήγησης χρησιμοποιεί από το HTML έγγραφο για τη φόρτωση των αρχείων γραμματοσειρών.

## **Αποθήκευση Πόρων Εξωτερικά**

Το αυτόνομο HTML είναι εύκολο στην μετακίνηση, αλλά οι ενσωματωμένοι πόροι Base64 μπορούν να κάνουν το αρχείο μεγάλο. Αν η εφαρμογή σας χρειάζεται εξωτερικά αρχεία εικόνας, γραμματοσειράς, ήχου ή βίντεο, χρησιμοποιήστε έναν ελεγκτή εξαγωγής που γράφει τους πόρους σε έναν επιλεγμένο φάκελο και εκδίδει URL που είναι ορατά από τον περιηγητή. Κρατήστε τη διαδρομή συστήματος αρχείων και τη διαδρομή URL συγχρονισμένες με τη διάταξη ανάπτυξης.

## **Εξαγωγή Αρχείων Πολυμέσων**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) εξάγει αρχεία βίντεο και ήχου και γράφει HTML που μπορεί να τα αναπαράγει σε πρόγραμμα περιήγησης. Ο κατασκευαστής του δέχεται:

- `path`: τον φάκελο όπου θα γραφτούν τα παραγόμενα αρχεία πολυμέσων.
- `fileName`: το όνομα του αρχείου HTML που παράγεται.
- `baseUri`: το απόλυτο πρόθεμα URI που χρησιμοποιείται στα συνδέσμους HTML προς τα αρχεία πολυμέσων.

Αν το αρχείο HTML είναι `html-output/presentation.html` και τα αρχεία πολυμέσων αποθηκεύονται σε `html-output/media`, το `path` πρέπει να δείχνει στο φάκελο πολυμέσων στο δίσκο, ενώ το `baseUri` πρέπει να δείχνει στον ίδιο φάκελο από την προοπτική του περιηγητή. Για τοπική προεπισκόπηση, μπορείτε να δημιουργήσετε ένα URI `file:///` από τον φάκελο πολυμέσων. Για μια αναπτυγμένη εφαρμογή, χρησιμοποιήστε το απόλυτο URL του δημοσιευμένου φακέλου πολυμέσων.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε φακέλους εξόδου που είναι μοναδικοί ανά εργασία εξαγωγής, ειδικά σε διακομιστικές εφαρμογές. Κοινόχρηστες διαδρομές εξόδου μπορεί να οδηγήσουν σε αντικατάσταση αρχείων από διαφορετικές μετατροπές.

## **Απόδοση και Διαχείριση Πόρων**

Η μετατροπή HTML είναι μια λειτουργία απόδοσης, έτσι ο χρόνος επεξεργασίας και η χρήση μνήμης εξαρτώνται από τον αριθμό διαφάνειων, την ανάλυση εικόνας, τις γραμματοσειρές, τα εφέ, τα διαγράμματα και τα ενσωματωμένα πολυμέσα. Υψηλές τιμές DPI στο `PicturesCompression`, ενσωματωμένες γραμματοσειρές, έξοδος SVG και διατηρημένα περικομμένα τμήματα εικόνας μπορούν να βελτιώσουν την πιστότητα αλλά συνήθως αυξάνουν το μέγεθος εξόδου.

Για batch μετατροπή:

- Διαγράψτε άμεσα κάθε αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
- Χρησιμοποιήστε ξεχωριστούς φακέλους εξόδου για ξεχωριστές εργασίες.
- Αποφύγετε την ενσωμάτωση κοινών γραμματοσειρών εκτός εάν η πιστότητα το απαιτεί.
- Μειώστε το DPI της εικόνας όταν το HTML προορίζεται για προεπισκόπηση ή μικρογραφίες.
- Κρατήστε την πηγαία παρουσίαση, το παραγόμενο HTML και τους εξωτερικούς πόρους μαζί μέχρι να οριστούν οι τελικές διαδρομές ανάπτυξης.

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι υπερσυνδέσεις στο HTML;**

Ναι. Οι υπερσυνδέσεις της παρουσίασης εξάγονται σε HTML και παραμένουν κλικάριστες όταν η διεύθυνση URL προορισμού είναι έγκυρη.

**Μπορώ να μετατρέπω παρουσιάσεις σε HTML παράλληλα;**

Ναι, αλλά μην μοιράζεστε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) μεταξύ εργατών. Επεξεργαστείτε διαφορετικά αρχεία με ξεχωριστές παρουσιαστικές περιπτώσεις, ξεχωριστά ρεύματα και ξεχωριστούς φακέλους εξόδου. Δείτε τις οδηγίες [multithreading guidance](/slides/el/nodejs-java/multithreading/) για λεπτομέρειες.

**Είναι το αντικείμενο Presentation thread‑safe;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) πρέπει να φορτώνεται, να τροποποιείται, να αποθηκεύεται και να διαγράφεται σε έναν εργαζόμενο. Για παράλληλη εργασία, δημιουργήστε ανεξάρτητη παρουσίαση ανά εργαζόμενο ή διεργασία.

**Γιατί το παραγόμενο αρχείο HTML είναι μεγάλο;**

Η προεπιλεγμένη εξαγωγή μπορεί να ενσωματώνει πόρους απευθείας στο HTML. Ενσωματωμένες γραμματοσειρές, εικόνες υψηλού DPI, πολυμέσα, περιεχόμενο SVG και διατηρημένα περικομμένα τμήματα εικόνας επίσης αυξάνουν το μέγεθος. Χρησιμοποιήστε εξωτερικούς πόρους, αποκλείστε κοινές γραμματοσειρές από την ενσωμάτωση και μειώστε το `PicturesCompression` όταν το μικρότερο μέγεθος είναι προτεραιότητα έναντι της μέγιστης πιστότητας.

**Γιατί μια γραμματοσειρά PowerPoint όπως 24 pt εμφανίζεται ως 17.999819 pt στο HTML;**

Αυτό μπορεί να συμβαίνει επειδή το PowerPoint και το HTML χρησιμοποιούν διαφορετικά μοντέλα DPI. Το PowerPoint αποθηκεύει τα μεγέθη κειμένου σε τυπογραφικά σημεία βάσει 72 DPI, ενώ η διάταξη HTML βασίζεται σε pixel CSS σε μοντέλο 96 DPI. Όταν το Aspose.Slides εξάγει μια παρουσίαση σε HTML, το μέγεθος γραμματοσειράς μεταφράζεται μεταξύ αυτών των συστημάτων, και η μετατροπή μπορεί να εισαγάγει μικρές στρογγυλοποιήσεις.

Αυτές οι τιμές δεν υποδεικνύουν πραγματική οπτική αλλαγή μεγέθους γραμματοσειράς. Είναι μόνο ένα μαθηματικό παράπλευρο αποτέλεσμα της μετατροπής μετρικών κειμένου μεταξύ PowerPoint και HTML.

**Πώς πρέπει να επιλέξω το baseUri για εξαγωγή πολυμέσων;**

Επιλέξτε το `baseUri` από την προοπτική του περιηγητή και περάστε το ως απόλυτο URI. Για τοπική προεπισκόπηση, μπορείτε να το προκύψετε από τον φάκελο εξόδου με ένα URI `file:///`. Για ανάπτυξη, χρησιμοποιήστε το απόλυτο URL του δημοσιευμένου φακέλου πολυμέσων. Η διαδρομή συστήματος αρχείων `path` και το `baseUri` του περιηγητή δεν χρειάζεται να είναι το ίδιο ακριβώς κείμενο, αλλά πρέπει να περιγράφουν την ίδια θέση πόρου.

**Μπορώ να συμπεριλάβω κρυμμένες διαφάνειες;**

Ναι. Ορίστε `ShowHiddenSlides` σε `true` στο [HtmlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/htmloptions/) όταν οι κρυμμένες διαφάνειες πρέπει να εξαχθούν.