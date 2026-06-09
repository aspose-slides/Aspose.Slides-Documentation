---
title: Μετατροπή παρουσιάσεων PowerPoint σε HTML με .NET
linktitle: PowerPoint σε HTML
type: docs
weight: 30
url: /el/net/convert-powerpoint-to-html/
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
- .NET
- C#
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint σε HTML με .NET. Χρησιμοποιήστε το Aspose.Slides για να εξάγετε αρχεία PPT και PPTX, επιλεγμένες διαφάνειες, σημειώσεις, γραμματοσειρές, εικόνες, SVG και πολυμέσα."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET μπορεί να αποθηκεύσει παρουσιάσεις PowerPoint ως HTML χωρίς το Microsoft PowerPoint. Η βασική μετατροπή είναι μια ενιαία φόρτωση ενός [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και μια κλήση [Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) με [SaveFormat](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/). Χρησιμοποιήστε [HtmlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/htmloptions/) όταν χρειάζεται να ελέγξετε τη διάταξη εξαγόμενου περιεχομένου, τις γραμματοσειρές, τις εικόνες, τις σημειώσεις, τα σχόλια, την έξοδο SVG ή τους συνδεδεμένους πόρους.

Αυτός ο οδηγός εστιάζει σε πρακτικά σενάρια εξαγωγής HTML:

- Εξαγωγή ολόκληρης παρουσίασης ή επιλεγμένων διαφανειών.
- Δημιουργία HTML σταθερής διάταξης, προσαρμοστικού ή βασισμένου σε SVG.
- Συμπερίληψη σημειώσεων ομιλητή και σχολίων.
- Έλεγχος ποιότητας εικόνας και δεδομένων περικομμένων εικόνων.
- Ενσωμάτωση γραμματοσειρών ή αποθήκευση αρχείων γραμματοσειρών ξεχωριστά.
- Επιλογή τρόπου εγγραφής και αναφοράς εξωτερικών πόρων και αρχείων πολυμέσων.

Από προεπιλογή, η εξαγωγή HTML παράγει ένα αυτόνομα έγγραφο HTML όπου οι περισσότεροι πόροι είναι ενσωματωμένοι. Αυτό είναι βολικό για κοινή χρήση ενός αρχείου, αλλά μπορεί να αυξήσει το μέγεθος του αποτελέσματος. Για δημοσίευση στο διαδίκτυο, εξετάστε τη χρήση εξωτερικών πόρων, χαμηλότερο DPI εικόνας και ενσωμάτωση μόνο εκείνων των γραμματοσειρών που δεν είναι αξιόπιστα διαθέσιμες στο περιβάλλον στόχο.

## **Μετατροπή παρουσίασης σε HTML**

Για να εξάγετε μια παρουσίαση σε HTML, φορτώστε τη με [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και αποθηκεύστε τη με [SaveFormat.Html](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

Αυτό το παράδειγμα γράφει ένα αρχείο HTML. Το αντικείμενο παρουσίασης διαγράφεται από τη δήλωση `using`, η οποία απελευθερώνει τα χειριστήρια αρχείων και τους πόρους απόδοσης μετά την εξαγωγή.

## **Χρήση HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/htmloptions/) είναι η κύρια κλάση διαμόρφωσης για την εξαγωγή HTML. Οι πιο κοινές ρυθμίσεις περιλαμβάνουν:

- `SlidesLayoutOptions`: προσθέτει σημειώσεις, σχόλια, φυλλάδια ή άλλες πληροφορίες διάταξης.
- `HtmlFormatter`: αλλάζει τη δομή του εγγράφου HTML ή παραχωρεί τη μορφοποίηση σε έναν ελεγκτή.
- `SlideImageFormat`: αλλάζει τον τρόπο παρουσίασης των διαφανειών, για παράδειγμα ως SVG.
- `PicturesCompression`: ελέγχει το DPI της εικόνας και το μέγεθος εξόδου.
- `DeletePicturesCroppedAreas`: διατηρεί ή αφαιρεί τα δεδομένα περικομμένων εικόνων.
- `SvgResponsiveLayout`: κάνει το εξαγόμενο περιεχόμενο SVG να προσαρμόζεται στο περιέκτη του.
- `ShowHiddenSlides`: περιλαμβάνει κρυφές διαφάνειες όταν απαιτείται.

Οι παρακάτω ενότητες παρουσιάζουν τις πιο συνηθισμένες επιλογές ξεχωριστά ώστε να μπορείτε να συνδυάσετε μόνο αυτές που χρειάζεται η ροή εργασίας σας.

## **Μετατροπή επιλεγμένων διαφανειών σε HTML**

Η υπερφόρτωση [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) που δέχεται αριθμούς διαφανειών χρησιμοποιεί θέσεις διαφανειών με βάση το 1. Ο βρόχος παρακάτω αποθηκεύει κάθε διαφάνεια σε ξεχωριστό αρχείο HTML.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Χρησιμοποιήστε αυτό το μοτίβο όταν μια ιστοσελίδα ή εφαρμογή χρειάζεται μία σελίδα HTML ανά διαφάνεια. Εάν κάθε διαφάνεια πρέπει να έχει την ίδια διάταξη, δημιουργήστε μία παρουσία [HtmlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/htmloptions/) και περάστε την σε κάθε κλήση `Save`.

## **Δημιουργία προσαρμοστικού HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/el/net/aspose.slides.export/responsivehtmlcontroller/) παρέχει προσαρμοστική έξοδο HTML μέσω του [HtmlFormatter](https://reference.aspose.com/slides/el/net/aspose.slides.export/htmlformatter/). Χρησιμοποιήστε το όταν η εξαγόμενη σελίδα πρέπει να προσαρμόζεται καλύτερα στο πλάτος του προγράμματος περιήγησης.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

Για προσαρμοστική διάταξη βασισμένη σε SVG, ορίστε `SvgResponsiveLayout` στο [HtmlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/htmloptions/). Αυτό είναι χρήσιμο όταν το περιεχόμενο της διαφάνειας εξάγεται ως κλιμακούμενο SVG markup.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Συμπερίληψη σημειώσεων ομιλητή και σχολίων**

Χρησιμοποιήστε [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/notescommentslayoutingoptions/) μέσω `HtmlOptions.SlidesLayoutOptions` για να συμπεριλάβετε σημειώσεις ομιλητή ή σχόλια. Οι σημειώσεις και τα σχόλια είναι κρυφά από προεπιλογή, εκτός εάν επιλέξετε τις θέσεις τους.

Υποθέστε ότι η πηγή παρουσίασης περιέχει σημειώσεις ομιλητή:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Ο παρακάτω κώδικας εξάγει το περιεχόμενο της διαφάνειας με τις σημειώσεις ομιλητή κάτω από τη διαφάνεια.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

Το εξαγόμενο HTML περιλαμβάνει την περιοχή σημειώσεων:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Για εξαγωγή σχολίων, ορίστε `CommentsPosition`, π.χ. σε `CommentsPositions.Right` ή `CommentsPositions.Bottom`. Εάν χρειάζεστε μόνο σχόλια, παραλείψτε το `NotesPosition`. Εάν χρειάζεστε και τις δύο, ορίστε και τις δύο ιδιότητες.

## **Έλεγχος ποιότητας εικόνας και περικομμένων περιοχών**

Η εξαγωγή HTML μπορεί να συμπιέσει τις εικόνες των διαφανειών για να μειώσει το μέγεθος εξόδου. Ορίστε `PicturesCompression` σε μια τιμή από το [PicturesCompression](https://reference.aspose.com/slides/el/net/aspose.slides.export/picturescompression/) όταν χρειάζεστε υψηλότερη ποιότητα εικόνας.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

Από προεπιλογή, οι περικομμένες περιοχές των εικόνων μπορεί να αφαιρεθούν από το εξαγόμενο αποτέλεσμα. Διατηρήστε τα περικομμένα δεδομένα μόνο όταν οι χρήστες πρέπει να μπορούν να επαναφέρουν ή να εξετάσουν αυτά τα κρυμμένα μέρη της εικόνας. Η διατήρηση αυτών μπορεί να αυξήσει το μέγεθος του HTML.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **Προσθήκη CSS**

Για απλή μορφοποίηση, περάστε μια συμβολοσειρά CSS στο [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/el/net/aspose.slides.export/htmlformatter/createdocumentformatter/). Αυτό αλλάζει το περιβάλλον HTML ενώ το Aspose.Slides συνεχίζει να αποδίδει το περιεχόμενο της διαφάνειας.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

Για προσαρμοσμένη κεφαλίδα εγγράφου, συνδεδεμένο αρχείο CSS ή προσαρμοσμένο markup γύρω από τις διαφάνειες και τα σχήματα, υλοποιήστε [IHtmlFormattingController](https://reference.aspose.com/slides/el/net/aspose.slides.export/ihtmlformattingcontroller/) και περάστε το στο [HtmlFormatter](https://reference.aspose.com/slides/el/net/aspose.slides.export/htmlformatter/) με `CreateCustomFormatter`.

## **Ενσωμάτωση γραμματοσειρών**

Εάν το περιβάλλον στόχος ενδέχεται να μην έχει εγκατεστημένες τις γραμματοσειρές της παρουσίασης, ενσωματώστε τις γραμματοσειρές στο HTML με [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/el/net/aspose.slides.export/embedallfontshtmlcontroller/). Η ενσωμάτωση βελτιώνει την οπτική πιστότητα αλλά αυξάνει το μέγεθος εξόδου.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

Αποκλείστε τις γραμματοσειρές μόνο όταν είστε σίγουροι ότι τα προγράμματα περιήγησης ή τα συστήματα στόχου τις παρέχουν ήδη. Για εταιρικές γραμματοσειρές ή λιγότερο κοινές, η ενσωμάτωση είναι συνήθως πιο ασφαλή.

## **Σύνδεση αρχείων γραμματοσειρών αντί για ενσωμάτωση**

Για να μειώσετε το μέγεθος του αρχείου HTML, μπορείτε να γράψετε τα δεδομένα της γραμματοσειράς σε ξεχωριστά αρχεία WOFF και να προσθέσετε κανόνες `@font-face` στο HTML. Ο βοηθός παρακάτω επεκτείνει το [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/el/net/aspose.slides.export/embedallfontshtmlcontroller/) και αντικαθιστά το `WriteFont`.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

Σε αυτό το παράδειγμα, τα αρχεία γραμματοσειρών αποθηκεύονται στο `html-output/fonts`, και το HTML τα αναφέρεται με URL όπως `fonts/BrandFont-normal-400.woff`. Εάν το αρχείο HTML και οι γραμματοσειρές αναπτυχθούν σε άλλη θέση, επιλέξτε `fontUrlPrefix` ώστε να ταιριάζει με το αναπτυγμένο μονοπάτι URL.

## **Αποθήκευση πόρων εξωτερικά**

Το αυτόνομο HTML είναι εύκολο στη μετακίνηση, αλλά οι ενσωματωμένοι πόροι Base64 μπορούν να κάνουν το αρχείο μεγάλο. Εάν η εφαρμογή σας χρειάζεται εξωτερικά αρχεία εικόνας, υλοποιήστε το [ILinkEmbedController](https://reference.aspose.com/slides/el/net/aspose.slides.export/ilinkembedcontroller/) και περάστε το στον κατασκευαστή του [HtmlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/htmloptions/htmloptions/).

Όταν εξωτερικοποιείτε πόρους, επιλέξτε δύο διαδρομές σκόπιμα:

- Το μονοπάτι εξόδου στο σύστημα αρχείων, όπου η εφαρμογή σας γράφει τις παραγόμενες εικόνες, γραμματοσειρές, ήχος ή βίντεο.
- Το μονοπάτι URL, που είναι αυτό που χρησιμοποιεί ο περιηγητής από το έγγραφο HTML για τη φόρτωση αυτών των αρχείων.

Για πλήρη υλοποίηση σύνδεσης εικόνων, δείτε το [Export Presentations to HTML with Externally Linked Images](/slides/el/net/exporting-presentations-to-html-with-externally-linked-images/).

## **Εξαγωγή αρχείων πολυμέσων**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/el/net/aspose.slides.export/videoplayerhtmlcontroller/) εξάγει αρχεία βίντεο και ήχου και γράφει HTML που μπορεί να τα αναπαράγει σε πρόγραμμα περιήγησης. Ο κατασκευαστής του δέχεται:

- `path`: ο φάκελος όπου θα γραφούν τα παραγόμενα αρχεία πολυμέσων.
- `fileName`: το όνομα του αρχείου HTML που δημιουργείται.
- `baseUri`: το απόλυτο πρόθεμα URI που χρησιμοποιείται στους συνδέσμους HTML προς τα αρχεία πολυμέσων.

Εάν το αρχείο HTML είναι `html-output/presentation.html` και τα αρχεία πολυμέσων αποθηκεύονται στο `html-output/media`, το `path` πρέπει να δείχνει στον φάκελο πολυμέσων στο δίσκο, ενώ το `baseUri` πρέπει να δείχνει στον ίδιο φάκελο από την άποψη του περιηγητή. Για τοπική προεπισκόπηση, μπορείτε να δημιουργήσετε ένα `file:///` URI από το φάκελο πολυμέσων. Για μια αναπτυγμένη εφαρμογή, χρησιμοποιήστε το απόλυτο URL του δημοσιευμένου φακέλου πολυμέσων.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

Χρησιμοποιήστε καταλόγους εξόδου που είναι μοναδικοί ανά εργασία εξαγωγής, ειδικά σε εφαρμογές διακομιστή. Κοινά μονοπάτια εξόδου μπορούν να οδηγήσουν σε αντικατάσταση αρχείων από διαφορετικές μετατροπές.

## **Απόδοση και διαχείριση πόρων**

Η μετατροπή HTML είναι λειτουργία απόδοσης, έτσι ο χρόνος επεξεργασίας και η χρήση μνήμης εξαρτώνται από τον αριθμό διαφανειών, την ανάλυση εικόνας, τις γραμματοσειρές, τα εφέ, τα γραφήματα και τα ενσωματωμένα πολυμέσα. Υψηλότερες τιμές DPI στο `PicturesCompression`, ενσωματωμένες γραμματοσειρές, έξοδος SVG και διατήρηση περικομμένων περιοχών εικόνας μπορούν να βελτιώσουν την πιστότητα αλλά συνήθως αυξάνουν το μέγεθος του αποτελέσματος.

Για μαζική μετατροπή:

- Διαγράψτε άμεσα κάθε αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
- Χρησιμοποιήστε ξεχωριστούς καταλόγους εξόδου για διαφορετικές εργασίες.
- Αποφύγετε την ενσωμάτωση κοινών γραμματοσειρών εκτός εάν η πιστότητα το απαιτεί.
- Μειώστε το DPI των εικόνων όταν το HTML προορίζεται για προεπισκόπηση ή μικρογραφίες.
- Διατηρήστε την πηγαία παρουσίαση, το παραγόμενο HTML και τους εξωτερικούς πόρους μαζί μέχρι να οριστικοποιηθούν οι διαδρομές ανάπτυξης.

## **Συχνές ερωτήσεις**

**Διατηρούνται οι υπερσυνδέσεις στην έξοδο HTML;**

Ναι. Οι υπερσυνδέσεις της παρουσίασης εξάγονται σε HTML και παραμένουν κλικ ανοιγόμενες όταν η διεύθυνση URL προορισμού είναι έγκυρη.

**Μπορώ να μετατρέψω παρουσιάσεις σε HTML παράλληλα;**

Ναι, αλλά μην μοιράζεστε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) μεταξύ νημάτων. Επεξεργαστείτε διαφορετικά αρχεία με ξεχωριστά αντικείμενα παρουσίασης, ξεχωριστά ρεύματα και ξεχωριστούς καταλόγους εξόδου. Δείτε τις οδηγίες [multithreading](/slides/el/net/multithreading/) για λεπτομέρειες.

**Είναι το αντικείμενο Presentation ασφαλές για χρήση από πολλαπλά νήματα;**

Όχι. Ένα μόνο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) πρέπει να φορτώνεται, να τροποποιείται, να αποθηκεύεται και να διαγράφεται σε ένα νήμα. Για παράλληλη εργασία, δημιουργήστε ανεξάρτητο αντικείμενο ανά νήμα ή διεργασία.

**Γιατί το παραγόμενο αρχείο HTML είναι μεγάλο;**

Η προεπιλεγμένη εξαγωγή μπορεί να ενσωματώνει πόρους απευθείας στο HTML. Ενσωματωμένες γραμματοσειρές, εικόνες υψηλού DPI, πολυμέσα, περιεχόμενο SVG και διατηρημένες περικομμένες περιοχές εικόνας αυξάνουν επίσης το μέγεθος. Χρησιμοποιήστε εξωτερικούς πόρους, εξαιρέστε κοινές γραμματοσειρές από ενσωμάτωση και μειώστε το `PicturesCompression` όταν το μικρότερο μέγεθος είναι πιο σημαντικό από την μέγιστη πιστότητα.

**Γιατί ένα μέγεθος γραμματοσειράς PowerPoint όπως 24 pt εμφανίζεται ως 17.999819 pt στο HTML;**

Αυτό μπορεί να συμβεί επειδή το PowerPoint και το HTML χρησιμοποιούν διαφορετικά μοντέλα DPI. Το PowerPoint αποθηκεύει τα μεγέθη κειμένου σε τυπογραφικά σημεία βάσει 72 DPI, ενώ η διάταξη HTML βασίζεται σε pixel CSS σε μοντέλο 96 DPI. Όταν το Aspose.Slides εξάγει μια παρουσίαση σε HTML, το μέγεθος γραμματοσειράς μεταφράζεται μεταξύ των δύο συστημάτων, και η μετατροπή μπορεί να εισάγει μικρές στρογγυλοποιήσεις.

Αυτές οι τιμές δεν υποδεικνύουν πραγματική οπτική αλλαγή μεγέθους γραμματοσειράς. Αποτελούν μόνο ένα μαθηματικό υποπροϊόν της μετατροπής μετρικών κειμένου μεταξύ PowerPoint και HTML.

**Πώς πρέπει να επιλέξω το baseUri για εξαγωγή πολυμέσων;**

Επιλέξτε το `baseUri` από την άποψη του περιηγητή και περάστε το ως απόλυτο URI. Για τοπική προεπισκόπηση, μπορείτε να το δημιουργήσετε από τον κατάλογο εξόδου με `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri`. Για ανάπτυξη, χρησιμοποιήστε το απόλυτο URL του δημοσιευμένου φακέλου πολυμέσων. Το σύστημα αρχείων `path` και το `baseUri` του περιηγητή δεν χρειάζεται να είναι η ίδια συμβολοσειρά, αλλά πρέπει να περιγράφουν την ίδια τοποθεσία πόρου.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες;**

Ναι. Ορίστε `ShowHiddenSlides = true` στο [HtmlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/htmloptions/) όταν πρέπει να εξαχθούν κρυφές διαφάνειες.