---
title: Μετατροπή παρουσιάσεων PowerPoint σε HTML με C++
linktitle: PowerPoint σε HTML
type: docs
weight: 30
url: /el/cpp/convert-powerpoint-to-html/
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
- C++
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint σε HTML με C++. Χρησιμοποιήστε το Aspose.Slides για εξαγωγή αρχείων PPT και PPTX, επιλεγμένων διαφανειών, σημειώσεων, γραμματοσειρών, εικόνων, SVG και πολυμέσων."
---
## **Επισκόπηση**

Το Aspose.Slides για C++ μπορεί να αποθηκεύσει παρουσιάσεις PowerPoint ως HTML χωρίς το Microsoft PowerPoint. Η βασική μετατροπή αποτελείται από ένα ενιαίο φόρτωμα του [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) και μια κλήση `Save` με το [SaveFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveformat/). Χρησιμοποιήστε το [HtmlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/htmloptions/) όταν χρειάζεται να ελέγξετε τη διάταξη, τις γραμματοσειρές, τις εικόνες, τις σημειώσεις, τα σχόλια, την έξοδο SVG ή τους συνδεδεμένους πόρους.

Αυτός ο οδηγός επικεντρώνεται σε πρακτικά σενάρια εξαγωγής HTML:

- Εξαγωγή ολόκληρης της παρουσίασης ή επιλεγμένων διαφανειών.
- Δημιουργία HTML σταθερής διάταξης, προσαρμοστικού ή βασισμένου σε SVG.
- Συμπερίληψη σημειώσεων ομιλητή και σχολίων.
- Έλεγχος ποιότητας εικόνας και περικομμένων δεδομένων εικόνας.
- Ενσωμάτωση γραμματοσειρών ή αποθήκευση αρχείων γραμματοσειρών ξεχωριστά.
- Επιλογή τρόπου εγγραφής και αναφοράς εξωτερικών πόρων και αρχείων πολυμέσων.

Από προεπιλογή, η εξαγωγή HTML παράγει ένα αυτόνομο έγγραφο HTML όπου οι περισσότεροι πόροι ενσωματώνονται. Αυτό είναι βολικό για κοινή χρήση ενός αρχείου, αλλά μπορεί να αυξήσει το μέγεθος εξόδου. Για δημοσίευση στο web, εξετάστε την χρήση εξωτερικών πόρων, χαμηλότερο DPI εικόνας και ενσωμάτωση μόνο των γραμματοσειρών που δεν είναι αξιόπιστα διαθέσιμες στο περιβάλλον προορισμού.

## **Μετατροπή Παρουσίασης σε HTML**

Για εξαγωγή μιας παρουσίασης σε HTML, φορτώστε τη με το [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) και αποθηκεύστε τη με `SaveFormat::Html`.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

Αυτό το παράδειγμα γράφει ένα αρχείο HTML. Η κλήση στο `Dispose` απελευθερώνει τα δεσμευμένα αρχεία και τους πόρους απόδοσης μετά την εξαγωγή.

## **Χρήση HtmlOptions**

Το [HtmlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/htmloptions/) είναι η κύρια κλάση διαμόρφωσης για την εξαγωγή HTML. Κοινές ρυθμίσεις περιλαμβάνουν:

- `SlidesLayoutOptions`: προσθέτει σημειώσεις, σχόλια, φυλλάδια ή άλλες πληροφορίες διάταξης.
- `HtmlFormatter`: αλλάζει τη δομή του εγγράφου HTML ή αναθέτει τη μορφοποίηση σε ένας ελεγκτή.
- `SlideImageFormat`: αλλάζει τον τρόπο παράστασης των διαφανειών, για παράδειγμα ως SVG.
- `PicturesCompression`: ελέγχει το DPI της εικόνας και το μέγεθος εξόδου.
- `DeletePicturesCroppedAreas`: διατηρεί ή αφαιρεί τα περικομμένα δεδομένα εικόνας.
- `SvgResponsiveLayout`: κάνει το εξαγόμενο περιεχόμενο SVG να προσαρμόζεται στο χώρο του.
- `ShowHiddenSlides`: περιλαμβάνει κρυφές διαφάνειες όταν απαιτείται.

Οι παρακάτω ενότητες δείχνουν τις πιο κοινές επιλογές χωριστά ώστε να μπορείτε να συνδυάσετε μόνο αυτές που χρειάζεται η ροή εργασίας σας.

## **Μετατροπή Επιλεγμένων Διαφανειών σε HTML**

Η υπερφόρτωση `Presentation::Save` που δέχεται αριθμούς διαφανειών χρησιμοποιεί θέσεις 1‑βάσης. Ο βρόχος παρακάτω αποθηκεύει κάθε διαφάνεια σε ξεχωριστό αρχείο HTML.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

Χρησιμοποιήστε αυτό το μοτίβο όταν ένας ιστότοπος ή μια εφαρμογή χρειάζεται μία σελίδα HTML ανά διαφάνεια. Αν κάθε διαφάνεια πρέπει να έχει την ίδια διάταξη, δημιουργήστε μία παρουσίαση του [HtmlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/htmloptions/) και περάστε την σε κάθε κλήση `Save`.

## **Δημιουργία Responsive HTML**

Το [ResponsiveHtmlController](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/responsivehtmlcontroller/) παρέχει responsive έξοδο HTML μέσω του [HtmlFormatter](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/htmlformatter/). Χρησιμοποιήστε το όταν η εξαγόμενη σελίδα πρέπει να προσαρμόζεται καλύτερα στο πλάτος του προγράμματος περιήγησης.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Για προσαρμοστική διάταξη βασισμένη σε SVG, ορίστε `SvgResponsiveLayout` στο [HtmlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/htmloptions/). Αυτό είναι χρήσιμο όταν το περιεχόμενο της διαφάνειας εξάγεται ως επεκτάσιμη σήμανση SVG.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Συμπερίληψη Σημειώσεων Ομιλητή και Σχολίων**

Χρησιμοποιήστε το [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/notescommentslayoutingoptions/) μέσω του `HtmlOptions.SlidesLayoutOptions` για να συμπεριλάβετε σημειώσεις ομιλητή ή σχόλια. Οι σημειώσεις και τα σχόλια είναι κρυμμένα από προεπιλογή, εκτός εάν ορίσετε τις θέσεις τους.

Ας υποθέσουμε ότι η πηγαία παρουσίαση περιέχει σημειώσεις ομιλητή:

![Διαφάνεια με σημειώσεις ομιλητή στο PowerPoint](slide_with_notes.png)

Ο παρακάτω κώδικας εξάγει το περιεχόμενο της διαφάνειας με τις σημειώσεις ομιλητή κάτω από τη διαφάνεια.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Η εξαγόμενη HTML περιλαμβάνει την περιοχή σημειώσεων:

![Έξοδος HTML με τη διαφάνεια και τις σημειώσεις ομιλητή](HTML_with_notes.png)

Για εξαγωγή σχολίων, ορίστε `CommentsPosition`, π.χ. σε `CommentsPositions::Right` ή `CommentsPositions::Bottom`. Εάν χρειάζεστε μόνο σχόλια, παραλείψτε το `NotesPosition`. Εάν χρειάζεστε και τα δύο, ορίστε και τις δύο ιδιότητες.

## **Έλεγχος Ποιότητας Εικόνας και Περικομμένων Περιοχών**

Η εξαγωγή HTML μπορεί να συμπιέσει τις εικόνες διαφανειών για μείωση του μεγέθους εξόδου. Ορίστε `PicturesCompression` σε μια τιμή από το [PicturesCompression](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/picturescompression/) όταν χρειάζεστε υψηλότερη ποιότητα εικόνας.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Από προεπιλογή, οι περικομμένες περιοχές των εικόνων μπορεί να αφαιρεθούν από την εξαγόμενη έξοδο. Διατηρήστε τα περικομμένα δεδομένα μόνο όταν οι χρήστες πρέπει να μπορούν να τα αποκαλύψουν ή να τα εξετάσουν. Η διατήρηση αυτών μπορεί να αυξήσει το μέγεθος του HTML.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Προσθήκη CSS**

Για απλή μορφοποίηση, περάστε ένα CSS string στο `HtmlFormatter::CreateDocumentFormatter`. Αυτό αλλάζει το περιβάλλον του εγγράφου HTML ενώ το Aspose.Slides συνεχίζει να αποδίδει το περιεχόμενο της διαφάνειας.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Για προσαρμοσμένη κεφαλίδα εγγράφου, συνδεμένο αρχείο CSS ή προσαρμοσμένη σήμανση γύρω από διαφάνειες και σχήματα, υλοποιήστε το [IHtmlFormattingController](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ihtmlformattingcontroller/) και περάστε το στο [HtmlFormatter](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/htmlformatter/) με το `CreateCustomFormatter`.

## **Ενσωμάτωση Γραμματοσειρών**

Εάν το περιβάλλον προορισμού ενδέχεται να μην έχει εγκατεστημένες τις γραμματοσειρές της παρουσίασης, ενσωματώστε τις γραμματοσειρές στο HTML με το [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/embedallfontshtmlcontroller/). Η ενσωμάτωση βελτιώνει την οπτική πιστότητα αλλά αυξάνει το μέγεθος εξόδου.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Αποκλείστε τις γραμματοσειρές μόνο όταν είστε σίγουροι ότι οι προοριστικοί browsers ή συστήματα τις παρέχουν ήδη. Για εταιρικές ή λιγότερο κοινές γραμματοσειρές, η ενσωμάτωση είναι συνήθως πιο ασφαλής.

## **Σύνδεση Αρχείων Γραμματοσειρών αντί για Ενσωμάτωση**

Για μείωση του μεγέθους του αρχείου HTML, μπορείτε να γράψετε τα δεδομένα της γραμματοσειράς σε ξεχωριστά αρχεία WOFF και να προσθέσετε κανόνες `@font-face` στο HTML. Ο βοηθός παρακάτω επεκτείνει το [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/embedallfontshtmlcontroller/) και υπερκαλύπτει το `WriteFont`.

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Σε αυτό το παράδειγμα, τα αρχεία γραμματοσειρών αποθηκεύονται στο `html-output/fonts`, και το HTML τα αναφέρει με URLs όπως `fonts/BrandFont-normal-400.woff`. Εάν το αρχείο HTML και οι γραμματοσειρές αναπτύσσονται σε άλλη τοποθεσία, επιλέξτε το `fontUrlPrefix` ώστε να ταιριάζει με τη διαδρομή URL που θα χρησιμοποιηθεί.

## **Αποθήκευση Πόρων Εξωτερικά**

Το αυτόνομο HTML είναι εύκολο στη μετακίνηση, αλλά οι ενσωματωμένοι πόροι Base64 μπορούν να το κάνουν μεγάλο. Εάν η εφαρμογή σας χρειάζεται εξωτερικά αρχεία εικόνας, υλοποιήστε το [ILinkEmbedController](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ilinkembedcontroller/) και περάστε το στον κατασκευαστή του [HtmlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/htmloptions/).

Όταν εξωτερικοποιείτε πόρους, επιλέξτε δύο διαδρομές σκόπιμα:

- Τη διαδρομή εξόδου του συστήματος αρχείων, όπου η εφαρμογή σας γράφει τις παραγόμενες εικόνες, γραμματοσειρές, ήχους ή βίντεο.
- Τη διαδρομή URL, που είναι αυτή που ο browser χρησιμοποιεί από το έγγραφο HTML για να φορτώσει αυτά τα αρχεία.

## **Εξαγωγή Αρχείων Πολυμέσων**

Το [VideoPlayerHtmlController](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/videoplayerhtmlcontroller/) εξάγει βίντεο και αρχεία ήχου και γράφει HTML που μπορεί να τα αναπαράγει σε browser. Ο κατασκευαστής του δέχεται:

- `path`: ο φάκελος όπου θα γραφτούν τα παραγόμενα αρχεία πολυμέσων.
- `fileName`: το όνομα του αρχείου HTML που δημιουργείται.
- `baseUri`: το απόλυτο πρόθεμα URI που χρησιμοποιείται στους συνδέσμους HTML προς τα αρχεία πολυμέσων.

Εάν το αρχείο HTML είναι `html-output/presentation.html` και τα αρχεία πολυμέσων αποθηκεύονται στο `html-output/media`, το `path` πρέπει να δείχνει το φάκελο πολυμέσων στο δίσκο, ενώ το `baseUri` πρέπει να δείχνει στον ίδιο φάκελο από την άποψη του browser. Για τοπική προεπισκόπηση, μπορείτε να δημιουργήσετε ένα URI `file:///` από το φάκελο πολυμέσων. Για μια εφαρμογή σε παραγωγή, χρησιμοποιήστε το απόλυτο URL του δημοσιευμένου φακέλου πολυμέσων.

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

Χρησιμοποιήστε φακέλους εξόδου μοναδικούς ανά εργασία εξαγωγής, ειδικά σε server εφαρμογές. Κοινές διαδρομές εξόδου μπορεί να προκαλέσουν αντικατάσταση αρχείων από διαφορετικές μετατροπές.

## **Απόδοση και Διαχείριση Πόρων**

Η μετατροπή σε HTML είναι λειτουργία απόδοσης, επομένως ο χρόνος επεξεργασίας και η χρήση μνήμης εξαρτώνται από τον αριθμό διαφανειών, την ανάλυση εικόνας, τις γραμματοσειρές, τα εφέ, τα διαγράμματα και τα ενσωματωμένα πολυμεσικά. Υψηλότερες τιμές DPI στο `PicturesCompression`, ενσωματωμένες γραμματοσειρές, έξοδο SVG και διατηρημένες περικομμένες περιοχές εικόνας μπορούν να βελτιώσουν την πιστότητα αλλά συνήθως αυξάνουν το μέγεθος εξόδου.

Για μαζική μετατροπή:

- Κάντε `Dispose` κάθε παρουσίαση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) αμέσως.
- Χρησιμοποιήστε ξεχωριστούς φακέλους εξόδου για διαφορετικές εργασίες.
- Αποφύγετε την ενσωμάτωση κοινών γραμματοσειρών εκτός εάν η πιστότητα το απαιτεί.
- Χαμηλότερο DPI εικόνας όταν το HTML προορίζεται για προεπισκόπηση ή μικρογραφίες.
- Διατηρήστε την πηγή παρουσίασης, το παραγόμενο HTML και τους εξωτερικούς πόρους μαζί μέχρι να οριστούν οι τελικές διαδρομές ανάπτυξης.

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι υπερσυνδέσεις στην έξοδο HTML;**

Ναι. Οι υπερσυνδέσεις της παρουσίασης εξάγονται σε HTML και παραμένουν κλικαμπλές όταν το URL προορισμού είναι έγκυρο.

**Μπορώ να μετατρέπω παρουσιάσεις σε HTML παράλληλα;**

Ναι, αλλά μην μοιράζεστε μία παρουσίαση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) μεταξύ νήματων. Επεξεργαστείτε διαφορετικά αρχεία με ξεχωριστές παρουσίες, ξεχωριστά streams και ξεχωριστούς φακέλους εξόδου. Δείτε τις οδηγίες [multithreading guidance](/slides/el/cpp/multithreading/) για λεπτομέρειες.

**Είναι ασφαλές το αντικείμενο Presentation για χρήση από πολλαπλά νήματα;**

Όχι. Μία παρουσίαση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) πρέπει να φορτώνεται, να τροποποιείται, να αποθηκεύεται και να διαστέλλεται σε ένα μόνο νήμα. Για παράλληλη εργασία, δημιουργήστε ανεξάρτητη παρουσίαση ανά νήμα ή διεργασία.

**Γιατί το παραγόμενο αρχείο HTML είναι μεγάλο;**

Η προεπιλεγμένη εξαγωγή μπορεί να ενσωματώνει πόρους απευθείας στο HTML. Ενσωματωμένες γραμματοσειρές, εικόνες υψηλού DPI, πολυμέσα, περιεχόμενο SVG και διατηρημένες περικομμένες περιοχές εικόνας αυξάνουν επίσης το μέγεθος. Χρησιμοποιήστε εξωτερικούς πόρους, αποκλείστε τις κοινές γραμματοσειρές από ενσωμάτωση και χαμηλότερο `PicturesCompression` όταν το μικρότερο μέγεθος είναι πιο σημαντικό από τη μέγιστη πιστότητα.

**Γιατί ένα μέγεθος γραμματοσειράς PowerPoint όπως 24 pt εμφανίζεται ως 17.999819 pt στο HTML;**

Αυτό μπορεί να συμβεί επειδή το PowerPoint και το HTML χρησιμοποιούν διαφορετικά μοντέλα DPI. Το PowerPoint αποθηκεύει τα μεγέθη κειμένου σε τυπικά σημεία βασισμένα σε 72 DPI, ενώ η διάταξη HTML βασίζεται σε pixel CSS σε μοντέλο 96 DPI. Όταν το Aspose.Slides εξάγει μια παρουσίαση σε HTML, το μέγεθος γραμματοσειράς μετατρέπεται μεταξύ αυτών των συστημάτων, και η μετατροπή μπορεί να εισάγει μικρές στρογγυλοποιήσεις.

Αυτές οι τιμές δεν υποδεικνύουν πραγματική οπτική αλλαγή μεγέθους γραμματοσειράς. Είναι μόνο ένα μαθηματικό παράπλευρο αποτέλεσμα της μετατροπής μετρικών κειμένου μεταξύ PowerPoint και HTML.

**Πώς πρέπει να επιλέξω το baseUri για εξαγωγή πολυμέσων;**

Επιλέξτε το `baseUri` από την άποψη του browser και περάστε το ως απόλυτο URI. Για τοπική προεπισκόπηση, μπορείτε να το παραγώγετε από τον φάκελο εξόδου με `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()`. Για ανάπτυξη, χρησιμοποιήστε το απόλυτο URL του δημοσιευμένου φακέλου πολυμέσων. Η διαδρομή αρχείου `path` και το `baseUri` του browser δεν χρειάζεται να είναι το ίδιο string, αλλά πρέπει να περιγράφουν την ίδια τοποθεσία πόρου.

**Μπορώ να συμπεριλάβω κρυφές διαφάνειες;**

Ναι. Ορίστε `ShowHiddenSlides` σε `true` στο [HtmlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/htmloptions/) όταν πρέπει να εξαχθούν οι κρυφές διαφάνειες.