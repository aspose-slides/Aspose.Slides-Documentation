---
title: Απόδοση διαφανειών παρουσίασης ως εικόνες SVG σε .NET
linktitle: Διαφάνεια σε SVG
type: docs
weight: 50
url: /el/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint σε SVG
- παρουσίαση σε SVG
- διαφάνεια σε SVG
- PPT σε SVG
- PPTX σε SVG
- επιλογές εξαγωγής SVG
- διαδραστικό SVG
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εξάγετε διαφάνειες PowerPoint ως εικόνες SVG σε .NET και ελέγξτε τις γραμματοσειρές, το κείμενο, τις εικόνες, τα αναγνωριστικά και τα συμβάντα με το Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι μια κλιμακώσιμη μορφή εικόνας βασισμένη σε XML που λειτουργεί άψογα για δημοσίευση στο web, προβολείς διαφανειών, ροές εργασίας προσβασιμότητας και αυτοματοποιημένη μετα‑επεξεργασία. Το Aspose.Slides εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σας επιτρέπει να ελέγχετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε το [SVGOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/) όταν το εξαχθέν SVG πρέπει να είναι συμπαγές, προβλέψιμο σε διαφορετικούς περιηγητές ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή μιας διαφάνειας ως SVG**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ροή. Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια μιας παρουσίασης ως ξεχωριστό αρχείο SVG.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Το όνομα αρχείου χρησιμοποιεί το [ISlide.SlideNumber](https://reference.aspose.com/slides/el/net/aspose.slides/islide/slidenumber/) αντί του δείκτη βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με το [IShape.WriteAsSvg](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/writeassvg/) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζεται μόνο εκείνο το σχήμα.

## **Διαμόρφωση εξόδου SVG**

Το [SVGOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/) ελέγχει την απόδοση του SVG. Για πλαισίωση κειμένου, το [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/useframesize/) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή απόδοσης, και το [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/useframerotation/) καθορίζει αν θα εφαρμοστεί η περιστροφή του πλαισίου. Ορίστε το [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/disablefontligatures/) σε `true` όταν το κείμενο πρέπει να αποδοθεί χωρίς συνδετικά.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Έλεγχος κειμένου και γραμματοσειρών**

### **Διάνυσμα όλου του κειμένου**

Ορίστε το [SVGOptions.VectorizeText](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/vectorizetext/) σε `true` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό εξαλείφει τις εξαρτήσεις από γραμματοσειρές και κάνει το οπτικό αποτέλεσμα πιο συνεπές σε διαφορετικούς περιηγητές, αλλά το κείμενο δεν μπορεί πλέον να επιλεχθεί ή να αναζητηθεί ως κείμενο SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **Επιλογή τρόπου διαχείρισης εξωτερικών γραμματοσειρών**

Το [SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/externalfontshandling/) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgexternalfontshandling/) για γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `AddLinksToFontFiles` για να παραπέμπετε σε ξεχωριστά αρχεία γραμματοσειρών, `Embed` για να ενσωματώσετε τα δεδομένα γραμματοσειράς στο SVG, ή `Vectorize` για να αποδείξετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Επαληθεύστε τις άδειες χρήσης των γραμματοσειρών πριν τις ενσωματώσετε.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **Μείωση μεγέθους ενσωματωμένων εικόνων**

Χρησιμοποιήστε το [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/picturescompression/) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) για να παραλείψετε περιοχές που έχουν περικοπεί, και το [SVGOptions.JpegQuality](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/jpegquality/) για να ελέγχετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου με κόστος στην πιστότητα της εικόνας ή τα διατηρημένα δεδομένα εικόνας.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Ανάθεση σταθερών αναγνωριστικών σε σχήματα και κείμενο**

Χρησιμοποιήστε το [ISvgShapeFormattingController](https://reference.aspose.com/slides/el/net/aspose.slides.export/isvgshapeformattingcontroller/) για να ορίσετε το [ISvgShape.Id](https://reference.aspose.com/slides/el/net/aspose.slides.export/isvgshape/id/) για κάθε σχήμα SVG. Για να ορίσετε τιμές [ISvgTSpan.Id](https://reference.aspose.com/slides/el/net/aspose.slides.export/isvgtspan/id/) και στα στοιχεία κειμένου `tspan`, υλοποιήστε το [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/el/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Αναθέστε οποιονδήποτε από τους ελεγκτές με το [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Ο παρακάτω ελεγκτής χρησιμοποιεί το [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/officeinteropshapeid/), το οποίο είναι σταθερό για τη διάρκεια ζωής του σχήματος, και έναν επαναλαμβανόμενο μετρητή για τα κείμενα `tspan`. Αυτό καθιστά τα παραγόμενα αναγνωριστικά κατάλληλα για μετα‑επεξεργασία μιας αμετάβλητης παρουσίασης.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **Προσθήκη χειριστών συμβάντων SVG**

Σε έναν [ISvgShapeFormattingController](https://reference.aspose.com/slides/el/net/aspose.slides.export/isvgshapeformattingcontroller/), καλέστε το [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/el/net/aspose.slides.export/isvgshape/seteventhandler/) με μια τιμή [SvgEvent](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgevent/) για να προσθέσετε έναν χειριστή συμβάντων JavaScript σε ένα εξαγόμενο σχήμα. Αναθέστε τον ελεγκτή με το [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) και ορίστε τη λειτουργία JavaScript στη σελίδα ή στο έγγραφο SVG που φιλοξενεί το αποτέλεσμα.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

Η σελίδα-ξένο μπορεί να ορίσει τη λειτουργία JavaScript που παραπέμπει ο χειριστής. Η ανάθεση αναγνωριστικών και χειριστών συμβάντων ενεργοποιεί προβολείς διαφανειών, βελτιώσεις προσβασιμότητας και άλλες διαδραστικές ροές εργασίας SVG.

## **Συχνές Ερωτήσεις**

**Πότε θα πρέπει να χρησιμοποιήσω το [SVGOptions.VectorizeText](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/vectorizetext/) αντί του [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgexternalfontshandling/);**

Χρησιμοποιήστε το [SVGOptions.VectorizeText](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/vectorizetext/) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από τις γραμματοσειρές. Χρησιμοποιήστε το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgexternalfontshandling/) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος για να μειώσω το μέγεθος ενός SVG;**

Ξεκινήστε συμπιέζοντας τις ενσωματωμένες εικόνες, διαγράφοντας τις περιοχές των εικόνων που έχουν περικοπεί και επιλέγοντας συνδεδεμένα αρχεία γραμματοσειρών όταν το περιβάλλον‑στόχος μπορεί να τα εξυπηρετήσει. Δοκιμάστε το αποτέλεσμα, επειδή η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και το διανυσματικό κείμενο έχουν διαφορετικές ανταλλαγές ποιότητας‑μεγέθους.

**Μπορώ να τροποποιήσω τα εξαγόμενα στοιχεία SVG μετά την εξαγωγή;**

Ναι. Αναθέστε αναγνωριστικά μέσω ενός ελεγκτή μορφοποίησης και, στη συνέχεια, επιλέξτε τα αντίστοιχα στοιχεία SVG στο εργαλείο μετα‑επεξεργασίας ή στο script του προγράμματος περιήγησης.