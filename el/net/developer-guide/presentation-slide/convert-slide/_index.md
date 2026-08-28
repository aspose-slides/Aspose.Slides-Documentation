---
title: Μετατροπή διαφανειών παρουσίασης σε εικόνες στο .NET
linktitle: Διαφάνεια σε εικόνα
type: docs
weight: 41
url: /el/net/convert-slide/
keywords:
- μετατροπή διαφάνειας
- εξαγωγή διαφάνειας
- διαφάνεια σε εικόνα
- αποθήκευση διαφάνειας ως εικόνα
- διαφάνεια σε EMF
- διαφάνεια σε PNG
- διαφάνεια σε JPEG
- διαφάνεια σε bitmap
- διαφάνεια σε TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες από παρουσιάσεις PPT, PPTX και ODP σε PNG, JPEG, GIF, TIFF, EMF και άλλες μορφές εικόνας σε C# με Aspose.Slides for .NET."
---
## **Εισαγωγή**

Το Aspose.Slides for .NET μπορεί να αποδώσει μεμονωμένες διαφάνειες από παρουσιάσεις PowerPoint και OpenDocument ως PNG, JPEG, GIF, TIFF και άλλες μορφές εικόνας.

Για να μετατρέψετε μια διαφάνεια σε εικόνα, ακολουθήστε τα παρακάτω βήματα:

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Επιλέξτε τη διαφάνεια που θέλετε να αποδώσετε.
3. Εάν είναι απαραίτητο, διαμορφώστε την απόδοση με την κλάση [RenderingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/renderingoptions/) ή [TiffOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/).
4. Καλέστε τη μέθοδο [GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/islide/getimage/). Επιστρέφει ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/).
5. Καλέστε τη μέθοδο [IImage.Save](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/save/) και ορίστε τη μορφή εξόδου με μια τιμή [ImageFormat](https://reference.aspose.com/slides/el/net/aspose.slides/imageformat/).

## **Μετατροπή μιας διαφάνειας σε εικόνα PNG**

Η πιο απλή μετατροπή χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις απόδοσης. Το παραγόμενο αντικείμενο [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) μπορεί να επεξεργαστεί στη μνήμη ή να αποθηκευτεί σε αρχείο.

Το παρακάτω παράδειγμα C# αποδίδει την πρώτη διαφάνεια και την αποθηκεύει ως εικόνα PNG:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Μετατροπή διαφανειών σε εικόνες με προσαρμοσμένα μεγέθη**

Χρησιμοποιήστε την υπερφόρτωση της [GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/islide/getimage/) που δέχεται μια τιμή [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) για να αποδώσετε μια διαφάνεια με ακριβείς διαστάσεις εικονοστοιχείων.

Το παρακάτω παράδειγμα δημιουργεί μια εικόνα JPEG 1820 × 1040:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Μετατροπή διαφανειών με σημειώσεις και σχόλια σε εικόνες**

Από προεπιλογή, οι εικόνες διαφανειών δεν περιλαμβάνουν σημειώσεις ή σχόλια. Αναθέστε ένα αντικείμενο [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/notescommentslayoutingoptions/) στην ιδιότητα [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) για να ελέγξετε πού εμφανίζονται οι σημειώσεις και τα σχόλια.

Το παρακάτω παράδειγμα τοποθετεί περικομμένες σημειώσεις κάτω από τη διαφάνεια και σχόλια στα δεξιά της:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
Για τη μετατροπή διαφανειών σε εικόνες, μην ορίζετε την ιδιότητα [NotesPosition](https://reference.aspose.com/slides/el/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) σε [BottomFull](https://reference.aspose.com/slides/el/net/aspose.slides.export/notespositions/). Οι σημειώσεις μπορεί να περιέχουν περισσότερο κείμενο από ό,τι μπορεί να χωρέσει το σταθερό μέγεθος της εικόνας. Χρησιμοποιήστε αντί αυτού το [BottomTruncated](https://reference.aspose.com/slides/el/net/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Μετατροπή διαφανειών σε εικόνες χρησιμοποιώντας τις επιλογές TIFF**

Η κλάση [TiffOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/) σάς επιτρέπει να ελέγχετε το μέγεθος, την ανάλυση και άλλες ιδιότητες της αποδοθείσας εικόνας TIFF.

Το παρακάτω παράδειγμα αποδίδει την πρώτη διαφάνεια ως εικόνα TIFF 2160 × 2880 με 300 DPI:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **Μετατροπή όλων των διαφανειών σε εικόνες**

Διέλθετε τη συλλογή διαφανειών για να μετατρέψετε ολόκληρη την παρουσίαση σε σειρά εικόνων. Οι κρυμμένες διαφάνειες περιλαμβάνονται εκτός αν τις παραλείψετε σκόπιμα.

Το παρακάτω παράδειγμα αποδίδει κάθε διαφάνεια ως εικόνα JPEG με οριζόντιους και κατακόρυφους παράγοντες κλίμακας ίσους με 2:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **Δημιουργία εξόδου Enhanced Metafile**

Το Enhanced Metafile (EMF) είναι χρήσιμο όταν χρειάζεται ανταλλαγή γραφικών βασισμένων σε διανύσματα με το Microsoft Office ή άλλες εφαρμογές Windows που υποστηρίζουν Windows metafiles. Σε αντίθεση με μια εικόνα βασισμένη σε εικονοστοιχεία, ένα EMF μπορεί να διατηρήσει τις διανυσματικές εντολές σχεδίασης που κλιμακώνονται χωρίς την ίδια απώλεια ευκρίνειας. Ωστόσο, το EMF είναι κυρίως μορφή συμβατότητας για εφαρμογές με υποστήριξη Windows metafile, όχι μια παγκόσμια μορφή ανταλλαγής. Επιπλέον, το σύνθετο περιεχόμενο διαφάνειας, όπως εικόνες bitmap και ορισμένα εφέ, μπορεί να αποθηκευτεί ως ραστερισμένα στοιχεία μέσα στο διανυσματικό δοχείο metafile.

### **Εξαγωγή διαφάνειας σε EMF**

Η μέθοδος [ISlide.WriteAsEmf](https://reference.aspose.com/slides/el/net/aspose.slides/islide/writeasemf/) γράφει ένα [ISlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide/) σε ρεύμα-στόχο σε μορφή EMF. Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, επιλέγει την πρώτη διαφάνεια και τη γράφει σε ρεύμα αρχείου EMF:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

Ο καλώντζος κατέχει το ρεύμα που περνάλθηκε στο [ISlide.WriteAsEmf](https://reference.aspose.com/slides/el/net/aspose.slides/islide/writeasemf/) και πρέπει να το κλείσει ή να το απορρίψει. Το Aspose.Slides γράφει στη τρέχουσα θέση του ρεύματος και το αφήνει ανοιχτό.

### **Μετατροπή εικόνας SVG σε EMF και προσθήκη της σε παρουσίαση**

Χρησιμοποιήστε το [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/writeasemf/) για να μετατρέψετε περιεχόμενο SVG σε EMF. Τα παραγόμενα byte μπορούν να προστεθούν στην παρουσίαση μέσω του [IImageCollection.AddImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimagecollection/addimage/) και να τοποθετηθούν σε διαφάνεια με το [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addpictureframe/).

Το παρακάτω παράδειγμα δημιουργεί ένα [SvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/svgimage/) από σήμανση SVG, το μετατρέπει σε EMF στη μνήμη, εισάγει το metafile στην πρώτη διαφάνεια και αποθηκεύει την παρουσίαση:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/writeasemf/) δεν αναλαμβάνει την ιδιοκτησία του ρεύματος προορισμού. Μετά τη γραφή, η θέση του ρεύματος βρίσκεται στο τέλος των παραγόμενων δεδομένων. Επαναφέρετε το `Position` στην αρχή πριν περάσετε το ίδιο ρεύμα αναζήτησης σε έναν αναγνώστη, όπως φαίνεται παραπάνω. Κρατήστε το ρεύμα ανοιχτό μέχρι ο καταναλωτής να ολοκληρώσει την ανάγγεται του, και στη συνέχεια απορρίψτε το. Εναλλακτικά, καλέστε το `ToArray` και περάστε το επιστρεφόμενο byte array στο [IImageCollection.AddImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimagecollection/addimage/); το `ToArray` επιστρέφει ολόκληρο το buffer ανεξάρτητα από την τρέχουσα θέση του ρεύματος.

Η δημιουργία EMF είναι διαθέσιμη στα λειτουργικά συστήματα που υποστηρίζονται από το επιλεγμένο build του Aspose.Slides for .NET, αλλά η απόδοση μπορεί να διαφέρει ανά πλατφόρμα όταν δεν υπάρχουν διαθέσιμες γραμματοσειρές ή εγγενείς εξαρτήσεις γραφικών. Εγκαταστήστε τις γραμματοσειρές που χρησιμοποιούνται από το πηγαίο περιεχόμενο ή ρυθμίστε κατάλληλες υποκατάστατες, ακολουθήστε τις [platform requirements](/slides/el/net/system-requirements/) για το πακέτο Aspose.Slides και επικυρώστε το αποτέλεσμα στην εφαρμογή-προορισμό που καταναλώνει EMF. Οι εφαρμογές Linux και macOS συχνά έχουν περιορισμένη ή ασυνεπή υποστήριξη για την εμφάνιση και επεξεργασία Windows metafiles.

## **Απόδοση χρωματικών Emoji**

{{% alert title="Note" color="info" %}}
Για να αποδίδονται σωστά τα χρωματικά emoji κατά τη μετατροπή των διαφανειών παρουσίασης σε εικόνες, οι γραμματοσειρές emoji που χρησιμοποιούνται στην παρουσίαση πρέπει να είναι εγκατεστημένες και διαθέσιμες στο σύστημα που εκτελεί τη μετατροπή. Για παράδειγμα, εάν η παρουσίαση χρησιμοποιεί **Segoe UI Emoji** και αυτή η γραμματοσειρά λείπει, τα emoji μπορεί να εμφανιστούν σε μονόχρωμη μορφή στις εξαγώμενες εικόνες.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Το Aspose.Slides υποστηρίζει την απόδοση διαφανειών με κινούμενα σχέδια;**

Όχι. Η μέθοδος [GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/islide/getimage/) αποδίδει μια στατική εικόνα της διαφάνειας και δεν εξάγει τα κινούμενα σχέδια.

**Μπορούν οι κρυμμένες διαφάνειες να εξαχθούν ως εικόνες;**

Ναι. Οι κρυμμένες διαφάνειες μπορούν να αποδοθούν όπως οι κανονικές διαφάνειες. Συμπεριλάβετε τες στον βρόχο επεξεργασίας, όπως φαίνεται στο παραπάνω παράδειγμα.

**Διατηρούνται οι σκιές και άλλα εφέ στις εικόνες διαφάνειας;**

Ναι. Το Aspose.Slides αποδίδει σκιές, διαφάνεια και άλλα υποστηριζόμενα γραφικά εφέ στις εικόνες διαφάνειας.