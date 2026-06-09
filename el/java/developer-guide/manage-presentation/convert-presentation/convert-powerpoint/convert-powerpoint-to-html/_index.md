---
title: Μετατροπή παρουσιάσεων PowerPoint σε HTML με Java
linktitle: PowerPoint σε HTML
type: docs
weight: 30
url: /el/java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint σε HTML με Java. Χρησιμοποιήστε το Aspose.Slides για να εξάγετε αρχεία PPT και PPTX, επιλεγμένες διαφάνειες, σημειώσεις, γραμματοσειρές, εικόνες, SVG και πολυμέσα."
---
## **Επισκόπηση**

Το Aspose.Slides for Java μπορεί να αποθηκεύει παρουσιάσεις PowerPoint ως HTML χωρίς το Microsoft PowerPoint. Η βασική μετατροπή είναι ένα απλό φόρτωμα του [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) και μια κλήση `save` με το [SaveFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/). Χρησιμοποιήστε το [HtmlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/htmloptions/) όταν χρειάζεται να ελέγξετε τη διάταξη του εξαγόμενου αρχείου, τις γραμματοσειρές, τις εικόνες, τις σημειώσεις, τα σχόλια, την έξοδο SVG ή τους συνδεδεμένους πόρους.

Αυτός ο οδηγός εστιάζει σε πρακτικά σενάρια εξαγωγής HTML:

- Εξαγωγή ολόκληρης παρουσίασης ή επιλεγμένων διαφανειών.
- Δημιουργία HTML με σταθερή διάταξη, ευαίσθητη (responsive) ή βασισμένη σε SVG.
- Συμπερίληψη σημειώσεων ομιλητή και σχολίων.
- Έλεγχος ποιότητας εικόνας και δεδομένων περικομμένων εικόνων.
- Ενσωμάτωση γραμματοσειρών ή αποθήκευση αρχείων γραμματοσειρών ξεχωριστά.
- Επιλογή τρόπου γραφής και αναφοράς εξωτερικών πόρων και αρχείων πολυμέσων.

Από προεπιλογή, η εξαγωγή HTML παράγει ένα αυτόνομο έγγραφο HTML όπου οι περισσότερες πηγές είναι ενσωματωμένες. Αυτό είναι βολικό για κοινή χρήση ενός αρχείου, αλλά μπορεί να αυξήσει το μέγεθος εξόδου. Για δημοσίευση στο διαδίκτυο, σκεφτείτε τη χρήση εξωτερικών πόρων, χαμηλότερο DPI εικόνας και μόνο ενσωμάτωση γραμματοσειρών που δεν είναι αξιόπιστα διαθέσιμες στο περιβάλλον προορισμού.

## **Μετατροπή Παρουσίασης σε HTML**

Για να εξάγετε μια παρουσίαση σε HTML, φορτώστε την με το [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) και αποθηκεύστε την με το [SaveFormat.Html](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Αυτό το παράδειγμα γράφει ένα αρχείο HTML. Το αντικείμενο παρουσίασης διαγράφεται στο μπλοκ `finally`, το οποίο απελευθερώνει τις χειρολαβές αρχείων και τους πόρους απόδοσης μετά την εξαγωγή.

## **Χρήση HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/htmloptions/) είναι η κύρια κλάση διαμόρφωσης για εξαγωγή HTML. Συνηθισμένες ρυθμίσεις περιλαμβάνουν:

- `SlidesLayoutOptions`: προσθέτει σημειώσεις, σχόλια, φυλλάδια ή άλλες πληροφορίες διάταξης.
- `HtmlFormatter`: αλλάζει τη δομή του εγγράφου HTML ή παραχωρεί τη μορφοποίηση σε έναν ελεγκτή.
- `SlideImageFormat`: αλλάζει τον τρόπο που αντιπροσωπεύονται οι διαφάνειες, για παράδειγμα ως SVG.
- `PicturesCompression`: ελέγχει το DPI της εικόνας και το μέγεθος εξόδου.
- `DeletePicturesCroppedAreas`: διατηρεί ή αφαιρεί τα δεδομένα περικομμένων εικόνων.
- `SvgResponsiveLayout`: κάνει το εξαγόμενο περιεχόμενο SVG να προσαρμόζεται στο περιέκτη του.
- `ShowHiddenSlides`: περιλαμβάνει κρυφές διαφάνειες όταν απαιτείται.

Οι παρακάτω ενότητες δείχνουν τις πιο συνηθισμένες επιλογές ξεχωριστά ώστε να μπορείτε να συνδυάσετε μόνο εκείνες που χρειάζεται η ροή εργασίας σας.

## **Μετατροπή Επιλεγμένων Διαφανειών σε HTML**

Η υπερφόρτωση `Presentation.save` που δέχεται αριθμούς διαφανειών χρησιμοποιεί θέσεις διαφανειών με βάση το 1. Ο βρόχος παρακάτω αποθηκεύει κάθε διαφάνεια σε ξεχωριστό αρχείο HTML.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε αυτό το πρότυπο όταν ένας ιστότοπος ή εφαρμογή χρειάζεται μία σελίδα HTML ανά διαφάνεια. Εάν κάθε διαφάνεια πρέπει να έχει την ίδια διάταξη, δημιουργήστε μία παρουσίαση [HtmlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/htmloptions/) και περάστε την σε κάθε κλήση `save`.

## **Δημιουργία Ανταποκρινόμενου HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/el/java/com.aspose.slides/responsivehtmlcontroller/) παρέχει ανταποκρινόμενη έξοδο HTML μέσω του [HtmlFormatter](https://reference.aspose.com/slides/el/java/com.aspose.slides/htmlformatter/). Χρησιμοποιήστε το όταν η εξαγόμενη σελίδα πρέπει να προσαρμόζεται καλύτερα στο πλάτος του προσαρτητή.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Για ανταποκρινόμενη διάταξη βασισμένη σε SVG, ορίστε `SvgResponsiveLayout` στο [HtmlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/htmloptions/). Αυτό είναι χρήσιμο όταν το περιεχόμενο της διαφάνειας εξάγεται ως κλιμακωτό markup SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Συμπερίληψη Σημειώσεων Ομιλητή και Σχολίων**

Χρησιμοποιήστε το [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/notescommentslayoutingoptions/) μέσω του `HtmlOptions.setSlidesLayoutOptions` για να συμπεριλάβετε σημειώσεις ομιλητή ή σχόλια. Οι σημειώσεις και τα σχόλια είναι κρυμμένα από προεπιλογή εκτός εάν ορίσετε τις θέσεις τους.

Έστω ότι η πηγαία παρουσίαση περιέχει σημειώσεις ομιλητή:

![Διαφάνεια με σημειώσεις ομιλητή στο PowerPoint](slide_with_notes.png)

Ο παρακάτω κώδικας εξάγει το περιεχόμενο της διαφάνειας με τις σημειώσεις ομιλητή κάτω από τη διαφάνεια.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

![Έξοδος HTML με τη διαφάνεια και τις σημειώσεις ομιλητή](HTML_with_notes.png)

Για εξαγωγή σχολίων, ορίστε `CommentsPosition`, π.χ. σε `CommentsPositions.Right` ή `CommentsPositions.Bottom`. Εάν χρειάζεστε μόνο σχόλια, παραλείψτε το `NotesPosition`. Εάν χρειάζεστε τόσο σημειώσεις όσο και σχόλια, ορίστε και τις δύο ιδιότητες.

## **Έλεγχος Ποιότητας Εικόνας και Περικομμένων Περιοχών**

Η εξαγωγή HTML μπορεί να συμπιέσει τις εικόνες των διαφανειών για να μειώσει το μέγεθος εξόδου. Ορίστε `PicturesCompression` σε μια τιμή από το [PicturesCompression](https://reference.aspose.com/slides/el/java/com.aspose.slides/picturescompression/) όταν χρειάζεστε υψηλότερη ποιότητα εικόνας.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Από προεπιλογή, οι περικομμένες περιοχές των εικόνων μπορεί να αφαιρεθούν από την εξαγόμενη έξοδο. Διατηρήστε τα περικομμένα δεδομένα μόνο όταν οι χρήστες πρέπει να μπορούν να επαναφέρουν ή να εξετάσουν αυτά τα κρυφά τμήματα της εικόνας. Η διατήρησή τους μπορεί να αυξήσει το μέγεθος του HTML.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη CSS**

Για απλή διαμόρφωση, περάστε μια συμβολοσειρά CSS στο `HtmlFormatter.createDocumentFormatter`. Αυτό αλλάζει το περιβάλλον HTML έγγραφο ενώ το Aspose.Slides συνεχίζει να αποδίδει το περιεχόμενο της διαφάνειας.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Για προσαρμοσμένη κεφαλίδα εγγράφου, συνδεδεμένο αρχείο CSS ή προσαρμοσμένο markup γύρω από διαφάνειες και σχήματα, υλοποιήστε το [IHtmlFormattingController](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihtmlformattingcontroller/) και περάστε το στο [HtmlFormatter](https://reference.aspose.com/slides/el/java/com.aspose.slides/htmlformatter/) με τη μέθοδο `createCustomFormatter`.

## **Ενσωμάτωση Γραμματοσειρών**

Εάν το περιβάλλον προορισμού δεν διαθέτει τις γραμματοσειρές της παρουσίασης, ενσωματώστε τις γραμματοσειρές στο HTML με το [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/el/java/com.aspose.slides/embedallfontshtmlcontroller/). Η ενσωμάτωση βελτιώνει την οπτική πιστότητα αλλά αυξάνει το μέγεθος εξόδου.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Αποκλείστε τις γραμματοσειρές μόνο όταν είστε βέβαιοι ότι οι προοριστικοί περιηγητές ή συστήματα τις παρέχουν ήδη. Για γραμματοσειρές εταιρικού σήματος ή λιγότερο συνηθισμένες γραμματοσειρές, η ενσωμάτωση είναι συνήθως πιο ασφαλής.

## **Σύνδεση Αρχείων Γραμματοσειρών Αντί για Ενσωμάτωση**

Για να μειώσετε το μέγεθος του αρχείου HTML, μπορείτε να αποθηκεύσετε τα δεδομένα γραμματοσειρών σε ξεχωριστά αρχεία WOFF και να προσθέσετε κανόνες `@font-face` στο HTML. Ο βοηθός παρακάτω επεκτείνει το [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/el/java/com.aspose.slides/embedallfontshtmlcontroller/) και υπερκαλύπτει τη μέθοδο `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Σε αυτό το παράδειγμα, τα αρχεία γραμματοσειρών αποθηκεύονται στο `html-output/fonts`, και το HTML τα αναφέρει με URLs όπως `fonts/BrandFont-normal-400.woff`. Εάν το αρχείο HTML και οι γραμματοσειρές αναπτυχθούν σε άλλο χώρο, επιλέξτε `fontUrlPrefix` ώστε να ταιριάζει με τη διαδρομή URL που έχει αναπτυχθεί.

## **Αποθήκευση Πόρων Εξωτερικά**

Το αυτόνομο HTML είναι εύκολο στη μετακίνηση, αλλά οι ενσωματωμένοι πόροι Base64 μπορούν να κάνουν το αρχείο μεγάλο. Εάν η εφαρμογή σας χρειάζεται εξωτερικά αρχεία εικόνας, υλοποιήστε το [ILinkEmbedController](https://reference.aspose.com/slides/el/java/com.aspose.slides/ilinkembedcontroller/) και περάστε το στον κατασκευαστή του [HtmlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/htmloptions/).

Όταν εξωτερικοποιείτε πόρους, επιλέξτε δύο διαδρομές σκόπιμα:

- Η διαδρομή εξόδου του συστήματος αρχείων, όπου η εφαρμογή σας γράφει τις δημιουργημένες εικόνες, γραμματοσειρές, ήχο ή βίντεο.
- Η διαδρομή URL, η οποία είναι αυτή που χρησιμοποιεί ο περιηγητής από το έγγραφο HTML για να φορτώσει αυτά τα αρχεία.

## **Εξαγωγή Αρχείων Πολυμέσων**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/el/java/com.aspose.slides/videoplayerhtmlcontroller/) εξάγει αρχεία βίντεο και ήχου και γράφει HTML που μπορεί να τα αναπαράγει σε έναν περιηγητή. Ο κατασκευαστής του δέχεται:

- `path`: ο φάκελος όπου θα γραφτούν τα δημιουργημένα αρχεία πολυμέσων.
- `fileName`: το όνομα του HTML αρχείου που δημιουργείται.
- `baseUri`: το απόλυτο πρόθεμα URI που χρησιμοποιείται στους συνδέσμους HTML προς τα αρχεία πολυμέσων.

Εάν το αρχείο HTML είναι `html-output/presentation.html` και τα αρχεία πολυμέσων αποθηκεύονται στο `html-output/media`, το `path` πρέπει να δείχνει στον φάκελο πολυμέσων στον δίσκο, ενώ το `baseUri` πρέπει να δείχνει στον ίδιο φάκελο από την άποψη του περιηγητή. Για τοπική προεπισκόπηση, μπορείτε να δημιουργήσετε ένα URI `file:///` από τον φάκελο πολυμέσων. Για μια αναπτυγμένη εφαρμογή, χρησιμοποιήστε το απόλυτο URL του δημοσιευμένου φακέλου πολυμέσων.

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Χρησιμοποιείτε φακέλους εξόδου που είναι μοναδικοί για κάθε εργασία εξαγωγής, ειδικά σε εφαρμογές διακομιστή. Οι κοινόχρηστοι φάκελοι εξόδου μπορούν να προκαλέσουν την αντικατάσταση αρχείων από διαφορετικές μετατροπές.

## **Απόδοση και Διαχείριση Πόρων**

Η μετατροπή HTML είναι μια λειτουργία απόδοσης, επομένως ο χρόνος επεξεργασίας και η χρήση μνήμης εξαρτώνται από τον αριθμό διαφανειών, την ανάλυση εικόνας, τις γραμματοσειρές, τα εφέ, τα γραφήματα και τα ενσωματωμένα πολυμέσα. Μεγαλύτερες τιμές DPI του `PicturesCompression`, ενσωματωμένες γραμματοσειρές, έξοδο SVG και διατηρημένες περικομμένες περιοχές εικόνων μπορούν να βελτιώσουν την πιστότητα αλλά συνήθως αυξάνουν το μέγεθος εξόδου.

- Απορρίψτε κάθε αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) αμέσως.
- Χρησιμοποιήστε ξεχωριστούς φακέλους εξόδου για ξεχωριστές εργασίες.
- Αποφύγετε την ενσωμάτωση κοινών γραμματοσειρών εκτός αν η πιστότητα το απαιτεί.
- Μειώστε το DPI της εικόνας όταν το HTML προορίζεται για προεπισκόπηση ή μικρογραφίες.
- Διατηρήστε την πηγαία παρουσίαση, το παραγόμενο HTML και τους εξωτερικούς πόρους μαζί μέχρι να οριστούν οι τελικές διαδρομές ανάπτυξης.

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι υπερσύνδεσμοι στην έξοδο HTML;**

Ναι. Οι υπερσύνδεσμοι της παρουσίασης εξάγονται σε HTML και παραμένουν κλικαρίσιμα όταν το URL προορισμού είναι έγκυρο.

**Μπορώ να μετατρέψω παρουσιάσεις σε HTML παράλληλα;**

Ναι, αλλά μην μοιράζεστε μία παρουσίαση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) μεταξύ νημάτων. Επεξεργαστείτε διαφορετικά αρχεία με ξεχωριστές παρουσίες, ξεχωριστές ροές και ξεχωριστούς φακέλους εξόδου. Δείτε την [οδηγία πολυνηματικότητας](/slides/el/java/multithreading/) για λεπτομέρειες.

**Είναι ασφαλές το αντικείμενο Presentation για χρήση από πολλά νήματα;**

Όχι. Μία μοναδική παρουσίαση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) πρέπει να φορτώνεται, να τροποποιείται, να αποθηκεύεται και να διαγράφεται σε ένα μόνο νήμα. Για παράλληλη εργασία, δημιουργήστε ανεξάρτητη παρουσίαση ανά νήμα ή διεργασία.

**Γιατί το παραγόμενο αρχείο HTML είναι μεγάλο;**

Η προεπιλεγμένη εξαγωγή μπορεί να ενσωματώνει πόρους απευθείας στο HTML. Ενσωματωμένες γραμματοσειρές, εικόνες υψηλού DPI, πολυμέσα, περιεχόμενο SVG και διατηρημένες περικομμένες περιοχές εικόνων επίσης αυξάνουν το μέγεθος. Χρησιμοποιήστε εξωτερικούς πόρους, αποκλείστε τις κοινές γραμματοσειρές από την ενσωμάτωση και μειώστε το `PicturesCompression` όταν το μικρότερο αρχείο είναι πιο σημαντικό από τη μέγιστη πιστότητα.

**Γιατί ένα μέγεθος γραμματοσειράς PowerPoint όπως 24 pt εμφανίζεται ως 17,999819 pt σε HTML;**

Αυτό μπορεί να συμβεί επειδή το PowerPoint και το HTML χρησιμοποιούν διαφορετικά μοντέλα DPI. Το PowerPoint αποθηκεύει τα μεγέθη κειμένου σε τυπογραφικά σημεία βασισμένα σε 72 DPI, ενώ η διάταξη HTML βασίζεται σε pixel CSS σε μοντέλο 96 DPI. Όταν το Aspose.Slides εξάγει μια παρουσίαση σε HTML, το μέγεθος γραμματοσειράς μεταφράζεται μεταξύ αυτών των συστημάτων, και η μετατροπή μπορεί να εισάγει μικρές σφαλματώδεις στρογγυλοποιήσεις.

Αυτές οι τιμές δεν υποδεικνύουν πραγματική οπτική αλλαγή στο μέγεθος της γραμματοσειράς. Είναι μόνο ένα μαθηματικό παρεμβατικό αποτέλεσμα της μετατροπής των μετρικών κειμένου μεταξύ PowerPoint και HTML.

**Πώς να επιλέξω το baseUri για εξαγωγή πολυμέσων;**

Επιλέξτε το `baseUri` από την άποψη του περιηγητή και περάστε το ως απόλυτο URI. Για τοπική προεπισκόπηση, μπορείτε να το παράγετε από το φάκελο εξόδου με `mediaDirectory.toUri().toString()`. Για ανάπτυξη, χρησιμοποιήστε το απόλυτο URL του δημοσιευμένου φακέλου πολυμέσων. Το `path` του συστήματος αρχείων και το `baseUri` του περιηγητή δεν πρέπει απαραίτητα να είναι το ίδιο κείμενο, αλλά πρέπει να περιγράφουν την ίδια τοποθεσία πόρων.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες;**

Ναι. Ορίστε το `ShowHiddenSlides` σε `true` στο [HtmlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/htmloptions/) όταν πρέπει να εξαχθούν κρυφές διαφάνειες.