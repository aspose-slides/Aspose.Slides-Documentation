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
description: "Εξαγωγή διαφανειών PowerPoint ως εικόνες SVG σε .NET και έλεγχος γραμματοσειρών, κειμένου, εικόνων, αναγνωριστικών και συμβάντων με Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι μια κλιμακώσιμη μορφή εικόνας βασισμένη σε XML που λειτουργεί καλά για δημοσίευση στο web, προβολείς διαφανειών, ροές εργασίας προσβασιμότητας και αυτοματοποιημένη μεταεπεξεργασία. Το Aspose.Slides εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σάς επιτρέπει να ελέγχετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) όταν το εξαγόμενο SVG πρέπει να είναι συμπαγές, προβλέψιμο σε διαφορετικά προγράμματα περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή διαφάνειας ως SVG**

Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ροή. Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια σε μια παρουσίαση ως ξεχωριστό αρχείο SVG.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Το όνομα αρχείου χρησιμοποιεί το [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) αντί για τον δείκτη του βρόχου. Μπορείτε επίσης να εξαγάγετε ένα μεμονωμένο σχήμα με το [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζεται μόνο αυτό το σχήμα.

## **Διαμόρφωση εξόδου SVG**

Το [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) ελέγχει τη σχεδίαση SVG. Για πλαίσια κειμένου, το [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) συμπεριλαμβάνει το πλαίσιο κειμένου στην περιοχή σχεδίασης, και το [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) καθορίζει αν θα εφαρμοστεί η περιστροφή του πλαισίου. Ορίστε το [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) σε `true` όταν το κείμενο πρέπει να αποδοθεί χωρίς λήμματα.

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

## **Έλεγχος περικοπής άκρων γραμμής σε κεφαλές βελών**

Το SVG 1.1 δεν διαθέτει ρύθμιση εσωτερικού δείκτη για να ορίσει πού πρέπει να σταματήσει μια γραμμή κάτω από μια κεφαλή βέλους. Από προεπιλογή, το Aspose.Slides συντομεύει τη γραμμή που εξάγεται ώστε η γραμμή του στυλ να μην προεξέχει μέσω του δείκτη. Ορίστε το [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) σε `true` για να σχεδιάσετε τη γραμμή μέχρι το αρχικό σημείο λήξης της. Αυτή η ρύθμιση επηρεάζει μόνο την έξοδο SVG. Η γραμμή διατηρεί τη θέση και το μήκος της στη διαφάνεια.

Το παράδειγμα σχεδιάζει κεφαλές βελών τριγώνου και ρόμβου σε γραμμές πάχους 2 και 10 σημεία. Εξάγει την ίδια διαφάνεια δύο φορές, αλλάζοντας μόνο την επιλογή περικοπής.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

Η σύγκριση δείχνει την τριγωνική κεφαλή βέλους στη γραμμή των 10 σημείων. Με ενεργοποιημένη την περικοπή, η άκρη είναι κοφιά. Με απενεργοποιημένη την περικοπή, η γραμμή προεξέχει μέσω των κλίσεων του δείκτη και αφήνει μια επίπεδη άκρη.

![Μεγεθυμένο τρίγωνο 10 σημείων με κοφιά άκρη όταν η περικοπή είναι ενεργοποιημένη και επίπεδη άκρη όταν η περικοπή είναι απενεργοποιημένη](line-end-cropping.png)

Στις άλλες γραμμές του παραδείγματος, η προεξέχουσα γραμμή είναι λιγότερο ορατή στο τρίγωνο των 2 σημείων. Ο γεμισμένος ρόμβος καλύπτει το τέλος της γραμμής και στα δύο πλάτη.

## **Έλεγχος κειμένου και γραμματοσειρών**

Κατά την εξαγωγή διαφανειών σε SVG, μπορείτε να ελέγξετε αν το κείμενο παραμένει ως κείμενο ή μετατρέπεται σε διανυσματικά γραφικά, καθώς και πώς οι εξωτερικές γραμματοσειρές περιλαμβάνονται ή αναφέρονται. Οι παρακάτω επιλογές σας βοηθούν να ισορροπήσετε τη οπτική συνέπεια, την επιλογή κειμένου και τις εξαρτήσεις γραμματοσειρών στο εξαγόμενο SVG.

### **Διανυσματισμός όλου του κειμένου**

Ορίστε το [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) σε `true` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό εξαλείφει τις εξαρτήσεις γραμματοσειρών και κάνει το οπτικό αποτέλεσμα πιο συνεπές μεταξύ των προγραμμάτων περιήγησης, αλλά το κείμενο δεν είναι πλέον επιλέξιμο ή αναζητήσιμο ως κείμενο SVG.

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

### **Επιλέξτε πώς χειρίζονται οι εξωτερικές γραμματοσειρές**

Το [SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) χρησιμοποιεί μια τιμή [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) για γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `AddLinksToFontFiles` για να αναφέρετε ξεχωριστά αρχεία γραμματοσειρών, `Embed` για να συμπεριλάβετε τα δεδομένα γραμματοσειράς στο SVG, ή `Vectorize` για να αποδείξετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Επαληθεύστε τη χορήγηση άδειας χρήσης των γραμματοσειρών πριν τις ενσωματώσετε.

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

Χρησιμοποιήστε το [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) για να παραλείψετε τις περικομμένες περιοχές πηγής, και το [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) για να ελέγξετε την ποιότητα κωδικοποίησης JPEG. αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου με κόστος τη πιστότητα της εικόνας ή τα διατηρημένα δεδομένα εικόνας.

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

## **Έλεγχος ανάλυσης rasterization μετααρχεία**

Το [SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) ορίζει το κατώτατο όριο ανάλυσης για rasterization μετααρχεία κατά την εξαγωγή SVG. Χρησιμοποιήστε το για να ισορροπήσετε λεπτομέρειες και μέγεθος αρχείου όταν μια εικόνα EMF ή WMF rasterizes. Δεν ορίζει ένα παγκόσμιο DPI για το SVG ούτε αναγκάζει κάθε αντικείμενο στη διαφάνεια να γίνει raster εικόνα.

Κατεβάστε το [metafile-rasterization.pptx](metafile-rasterization.pptx), που περιέχει μια εικόνα EMF με πολύ κοντινές διαγώνιες γραμμές. Το παρακάτω παράδειγμα εξάγει την πρώτη διαφάνειά του σε τρεις αναλύσεις rasterization μέσω του [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Όλες οι άλλες ρυθμίσεις εξαγωγής παραμένουν ίδιες ώστε να μπορούν να συγκριθούν τα αποτελέσματα.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

Στην έξοδο, το EMF μετατράπηκε σε ένα ενσωματωμένο PNG σε κάθε SVG. Οι παρακάτω μετρήσεις αφορούν την παρεχόμενη παρουσίαση· δεν αποτελούν γενικό τύπο μετατροπής DPI σε διαστάσεις pixel.

| DPI rasterization μετααρχείου | Διαστάσεις ενσωματωμένου PNG | Μέγεθος αρχείου SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Η σύγκριση παρακάτω δείχνει την ίδια περιοχή του ενσωματωμένου raster στην ίδια μεγεθυμένη απεικόνιση. Οι διαγώνιες γραμμές εμφανίζουν ορατή εικονοστοιχία στα 72 DPI και πιο ομαλές ακμές σε υψηλότερες αναλύσεις, ενώ το αρχείο SVG αυξάνεται. Η αύξηση της τιμής δεν βελτιώνει απαραίτητα κάθε λεπτομέρεια ή αλλάζει κάθε εξαγόμενη εικόνα.

![Μεγεθυμένη λεπτομέρεια διαγώνιων γραμμών στα 72, 150 και 300 DPI](metafile-rasterization-comparison.png)

Το [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) ελέγχει τη μείωση ανάλυσης εικόνας και μπορεί να καλύψει την επίδραση της αλλαγής της ανάλυσης rasterization του μετααρχειου. Το [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) ελέγχει την ποιότητα κωδικοποίησης JPEG, όχι την ανάλυση rasterization του μετααρχειου.

## **Ανάθεση σταθερών αναγνωριστικών σε σχήματα και κείμενο**

Χρησιμοποιήστε το [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) για να ορίσετε το [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) για κάθε σχήμα SVG. Για να ορίσετε τιμές [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) στα στοιχεία κειμένου `tspan`, υλοποιήστε το [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Αναθέστε οποιονδήποτε ελεγκτή με το [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Ο παρακάτω ελεγκτής χρησιμοποιεί το [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), το οποίο είναι σταθερό για τη διάρκεια ζωής του σχήματος, και έναν επαναλήψιμο μετρητή για τα κείμενα του. Αυτό καθιστά τα παραγόμενα αναγνωριστικά κατάλληλα για μεταεπεξεργασία μιας αμετάβλητης παρουσίασης.

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

## **Προσθήκη χειριστών γεγονότων SVG**

Σε ένα [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/), καλέστε το [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) με μια τιμή [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) για να προσθέσετε έναν χειριστή συμβάντος JavaScript σε ένα εξαγόμενο σχήμα. Αναθέστε τον ελεγκτή με το [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) και ορίστε τη λειτουργία JavaScript στη σελίδα ή το έγγραφο SVG που φιλοξενεί το αποτέλεσμα.

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

Η σελίδα-υποδοχέας μπορεί να ορίσει τη λειτουργία JavaScript στην οποία αναφέρεται ο χειριστής. Η ανάθεση αναγνωριστικών και χειριστών συμβάντων ενεργοποιεί προβολείς διαφανειών, βελτιώσεις προσβασιμότητας και άλλες διαδραστικές ροές εργασίας SVG.

## **Συχνές ερωτήσεις**

**Πότε θα πρέπει να χρησιμοποιήσω το [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) αντί για το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/);**

Χρησιμοποιήστε το [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από γραμματοσειρές. Χρησιμοποιήστε το [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος να κάνω ένα SVG μικρότερο;**

Ξεκινήστε συμπιέζοντας τις ενσωματωμένες εικόνες, διαγράφοντας τις περικομμένες περιοχές εικόνας, και επιλέγοντας συνδεδεμένα αρχεία γραμματοσειρών όταν το περιβάλλον στόχου μπορεί να τα εξυπηρετήσει. Δοκιμάστε το αποτέλεσμα, επειδή η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και ο διανυσματισμός κειμένου έχουν διαφορετικές ανταλλαγές ποιότητας‑μεγέθους.

**Μπορώ να τροποποιήσω τα εξαγόμενα στοιχεία SVG μετά την εξαγωγή;**

Ναι. Αναθέστε αναγνωριστικά μέσω ενός ελεγκτή μορφοποίησης, στη συνέχεια επιλέξτε τα αντίστοιχα στοιχεία SVG στο εργαλείο μεταεπεξεργασίας ή στο σενάριο του προγράμματος περιήγησης.