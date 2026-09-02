---
title: Διαχείριση πλαισίων εικόνας σε παρουσιάσεις σε .NET
linktitle: Πλαίσιο εικόνας
type: docs
weight: 10
url: /el/net/picture-frame/
keywords:
- πλαίσιο εικόνας
- προσθήκη πλαισίου εικόνας
- δημιουργία πλαισίου εικόνας
- ενσωματωμένη εικόνα
- συνδεδεμένη εικόνα
- εξαγωγή εικόνας
- raster εικόνα
- SVG εικόνα
- περικοπή εικόνας
- διαγραφή περικομμένων περιοχών
- συμπίεση εικόνας
- StretchOffset
- μορφοποίηση πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- λόγος διαστάσεων
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε, μορφοποιήστε, συνδέστε, περικόψτε, εξάγετε και συμπιέστε πλαίσια εικόνας σε παρουσιάσεις με Aspose.Slides για .NET."
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: ένα [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) διαχειρίζεται ενσωματωμένους πόρους εικόνας μέσω της συλλογής [Images](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/images/), ενώ ένα [IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/) ελέγχει τη θέση, το μέγεθος, τη μορφοποίηση γραμμής, την περιστροφή, την περικοπή, τα εφέ εικόνας και άλλες ρυθμίσεις επιπέδου πλαισίου.

Αυτός ο διαχωρισμός είναι χρήσιμος όταν η ίδια εικόνα εμφανίζεται περισσότερες από μία φορές. Προσθέστε την εικόνα στην παρουσίαση μία φορά, κρατήστε το επιστρεφόμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας κατά τη δημιουργία πλαισίων εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν raster εικόνες όπως PNG ή JPEG και διανυσματικές SVG εικόνες. Μπορούν επίσης να αναφέρονται σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα byte της εικόνας στην παρουσίαση. Η επιλογή επηρεάζει τη φορητότητα, το μέγεθος του αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, οπότε είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευτεί η εικόνα πριν εφαρμόσετε μορφοποίηση ή βελτιστοποίηση.

## **Προσθήκη και μορφοποίηση ενσωματωμένης εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addpictureframe/). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, ώστε η παρουσίαση να παραμένει αυτόνομη όταν μεταφερθεί σε έναν άλλο υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια JPEG εικόνα, δημιουργεί ένα πλαίσιο στις αρχικές διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις εικονοστοιχείων που αποθηκεύονται στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν περικόπτετε ή συμπιέζετε μια εικόνα αργότερα.

## **Χρήση σχετικής κλίμακας**

[IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/) εκθέτει σχετική κλίμακα πλάτους και ύψους για το πλαίσιο. Μια τιμή `1.0` αντιστοιχεί στο 100 % του αρχικού μεγέθους της εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας χρειάζεται να διατηρήσει τη σχέση με το μέγεθος της πηγαίας εικόνας αντί να υπολογίζει τις τελικές διαστάσεις χειροκίνητα.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

Η σχετική κλίμακα αλλάζει τις ρυθμίσεις κλίμακας του πλαισίου· δεν επαναδειγματοληπτεί ή συμπιέζει την ενσωματωμένη εικόνα.

## **Ενσωματωμένες και συνδεδεμένες εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας μέσα στην παρουσίαση και αποτελεί επομένως την πιο ασφαλή επιλογή για φορητότητα και προβλεπόμενη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική διαδρομή μέσω του συνδέσμου [ISlidesPicture](https://reference.aspose.com/slides/el/net/aspose.slides/islidespicture/) αντί να ενσωματώνει τα δεδομένα εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν το ποσό των δεδομένων εικόνας που αποθηκεύονται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν η διαδρομή αλλάξει, μετακινηθεί το αρχείο ή ο πόρος δεν είναι διαθέσιμος, η συνδεδεμένη εικόνα μπορεί να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να αποσταλούν μέσω email, να αρχειοθετηθούν ή να αποδοθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη συνδεδεμένης εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το συνδέει με ένα τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και δεν αναμειγνύεται σκόπιμα σε αυτό το παράδειγμα.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Χρησιμοποιήστε συνδέσμους όταν η εξωτερική διαχείριση αρχείων είναι εσκεμμένη. Μην τους χρησιμοποιείτε μόνο ως αντικατάστατο της συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη αυτόνομη παρουσίαση.

## **Εξαγωγή εικόνων από πλαίσια εικόνας**

Πριν εξαγάγετε μια εικόνα από μια υπάρχουσα παρουσίαση, ελέγξτε ότι ένα σχήμα είναι πράγματι ένα [IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/) και ότι περιέχει μια ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας μπορεί να μην περιέχουν τα byte της εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή raster εικόνας**

Το σύγχρονο API εικόνας χρησιμοποιεί άμεσα το [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) και δεν απαιτεί τον παλαιότερο wrapper συστήματος εικόνας. Το παρακάτω παράδειγμα βρίσκει την πρώτη ενσωματωμένη raster εικόνα σε μια διαφάνεια και την αποθηκεύει ως PNG:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

Η αποθήκευση μέσω [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) μετατρέπει την εξαγόμενη εικόνα στη ζητούμενη μορφή εξόδου. Εάν χρειάζεστε τα κωδικοποιημένα byte που είναι αποθηκευμένα στην παρουσίαση αντί για ένα μετατρεπόμενο raster αρχείο, χρησιμοποιήστε τα δυαδικά δεδομένα του πόρου εικόνας.

### **Εξαγωγή SVG εικόνας**

Για μια SVG εικόνα, το [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) εκθέτει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα δεδομένα SVG άμεσα αντί να rasterize την εικόνα πρώτα.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

Η διατήρηση του περιεχομένου SVG ως SVG διατηρεί την διανυσματική πηγή μέσα στην παρουσίαση. Οι raster εξαγωγές όπως PNG ή JPEG αναγκαστικά αποδίδουν αυτό το διανυσματικό περιεχόμενο σε pixel. Η εξαγωγή διαφάνειας σε PDF ή SVG είναι επίσης μια λειτουργία απόδοσης, έτσι τα εξαχθέντα γραφικά δεν πρέπει να θεωρούνται ακριβές αντίγραφα byte‑για‑byte του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε τα δεδομένα του ενσωματωμένου [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/) όταν απαιτείται ο ίδιος ο διανυσματικός πόσος.

## **Κοπή εικόνας**

Η περικοπή αλλάζει ποιο τμήμα μιας εικόνας είναι ορατό εντός του πλαισίου. Οι τιμές περικοπής στο [IPictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/) είναι ποσοστά των διαστάσεων της πηγαίας εικόνας. Η περικοπή δεν διαγράφει αρχικά τα κρυφά pixel από την ενσωματωμένη εικόνα· αλλάζει μόνο την ορατή περιοχή.

Το παρακάτω παράδειγμα βρίσκει ένα πλαίσιο εικόνας με ασφάλεια και εφαρμόζει τιμές περικοπής:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Καθώς τα κρυμμένα δεδομένα εικόνας παραμένουν, η περικοπή μπορεί να τροποποιηθεί αργότερα χωρίς να χαθούν τα αρχικά pixel. Εάν το μέγεθος του αρχείου έχει μεγαλύτερη σημασία από την αναστροφή, οι περικομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Αφαίρεση δεδομένων κομμένων εικόνων**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) αφαιρεί τα δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου περικοπής και επιστρέφει τον προκύπτον πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος του αρχείου, αλλά αποτελεί καταστροφική βελτιστοποίηση: μετά την αποθήκευση της παρουσίασης, τα αφαιρεθέντα pixel δεν είναι πλέον διαθέσιμα για μετέπειτα λειτουργία απο‑πέρικοπης.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

Η μέθοδος μπορεί να προσθέσει έναν νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, αυτά τα πλαίσια εξακολουθούν να χρειάζονται τον υπάρχοντα πόρο, οπότε η διαγραφή των κομμένων περιοχών δεν μειώνει απαραίτητα τον συνολικό αριθμό εικόνων. Η περικοπή περιεχομένου WMF ή EMF με αυτή τη μέθοδο rasterize το αποτέλεσμα σε PNG.

## **Συμπίεση raster εικόνων**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/compressimage/) μειώνει την ανάλυση της raster εικόνας σε σχέση με το μέγεθος με το οποίο η εικόνα εμφανίζεται. Μπορεί επίσης να αφαιρέσει τις περικομμένες περιοχές στην ίδια λειτουργία. Η μέθοδος επιστρέφει `true` όταν η εικόνα έχει αλλάξει μέγεθος ή περικοπεί και `false` όταν δεν ήταν απαραίτητη καμία αλλαγή.

Χρησιμοποιήστε μια προκαθορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/net/aspose.slides.export/picturescompression/) όταν αρκεί μια τυπική ανάλυση στόχου:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

Μια προσαρμοσμένη θετική τιμή DPI μπορεί να περαστεί αντί μιας τιμής enum όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για raster εικόνες. Το περιεχόμενο SVG και των μεταγραφικών αρχείων δεν μειώνεται με αυτήν τη διαδικασία raster συμπίεσης. Επίσης, θυμηθείτε ότι η χαμηλότερη ανάλυση και οι διαγραμμένες περιοχές περικοπής δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε ανάλυση στόχου με βάση το μεγαλύτερο μέγεθος στο οποίο η εικόνα θα προβληθεί ή θα εξαχθεί πραγματικά, αντί να εφαρμόζετε παγκόσμια το χαμηλότερο DPI.

## **Επιθεώρηση εφέ εικόνας**

Τα εφέ εικόνας αποθηκεύονται στην εικόνα που χρησιμοποιείται από το πλαίσιο. Η συλλογή μετασχηματισμών εικόνας μπορεί να περιέχει εφέ όπως σταθερή διαμόρφωση άλφα για διαφάνεια και φωτεινότητα/αντίθεση για φωταύγεια. Το παρακάτω παράδειγμα διαβάζει με ασφάλεια και τα δύο είδη εφέ από το πρώτο πλαίσιο εικόνας σε μια διαφάνεια:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

Αυτά τα εφέ αλλάζουν τον τρόπο απόδοσης της εικόνας στο πλαίσιο· δεν επανεγγράφουν τα αρχικά byte της ενσωματωμένης εικόνας.

## **Κλείδωμα γεωμετρίας πλαισίου εικόνας**

Οι ρυθμίσεις [IPictureFrameLock](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας είναι απενεργοποιημένες για ένα πλαίσιο εικόνας. Για παράδειγμα, το κλείδωμα λόγου διαστάσεων διατηρεί τις αναλογίες του σχήματος κατά την αλλαγή μεγέθους.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν αναγκάζει την πηγαία εικόνα να επαναδειγματοληπτεί ή να αλλάξει μόνιμα σε ίδιο λόγο διαστάσεων.

## **Ρύθμιση τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι «stretch», οι τιμές stretch‑offset στο [IPictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/) ορίζουν το ορθογώνιο γεμίσματος ως προς το περίγραμμα του πλαισίου εικόνας. Τα θετικά ποσοστά δημιουργούν εσωτερικό περιθώριο από την άκρη, ενώ τα αρνητικά ποσοστά δημιουργούν εξωτερικό περιθώριο.

Αυτό είναι διαφορετικό από την περικοπή. Οι τιμές περικοπής επιλέγουν ποιο τμήμα της πηγαίας εικόνας είναι ορατό· οι stretch‑offset αλλάζουν το ορθογώνιο στο οποίο τεντώνεται το ορατό γέμισμα εικόνας.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Χρησιμοποιήστε stretch‑offset για τοποθέτηση γεμίσματος. Χρησιμοποιήστε τις ιδιότητες περικοπής όταν ο στόχος είναι να κρύψετε τις άκρες της πηγαίας εικόνας.

## **Αποθήκευση, μέγεθος αρχείου και παράγοντες εξαγωγής**

Οι κύριες ανταλλαγές είναι πιο εύκολα διαχειρίσιμες όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου εικόνας αντιμετωπίζονται ξεχωριστά:

- **Embedded images** κάνουν την παρουσίαση αυτόνομη και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση από διακομιστή, αλλά οι μεγάλες raster εικόνες αυξάνουν το μέγεθος του PPTX και τη χρήση μνήμης.
- **Linked images** μπορούν να διατηρήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από τα εξωτερικά αρχεία που πρέπει να παραμείνουν διαθέσιμα στις αποθηκευμένες διαδρομές ή τοποθεσίες.
- **Cropping** είναι αρχικά μη καταστροφική. Τα κρυμμένα pixel παραμένουν ενσωματωμένα μέχρι να διαγραφούν ρητά οι περιοχές ή να αφαιρεθούν κατά τη συμπίεση.
- **Compression** μπορεί να μειώσει σημαντικά το μέγεθος του αρχείου για υπερμεγέθη raster εικόνες, αλλά ανταλλάσσει την πηγαία ανάλυση. Θα πρέπει να εφαρμοστεί αφού γνωστοποιηθεί το επιθυμητό μέγεθος στην διαφάνεια.
- **SVG images** πρέπει να παραμένουν ως SVG όταν η διατήρηση του διανύσματος είναι σημαντική. Εξάγετε το ενσωματωμένο SVG απευθείας όταν χρειάζεστε τον ίδιο τον διανυσματικό πόρο. Οι raster εξαγωγές διαφάνειας πάντα μετατρέπουν τη διαφάνεια σε pixel.
- **Repeated images** πρέπει να επαναχρησιμοποιούν έναν υπάρχοντα πόρο [IPPImage] όταν είναι δυνατόν, αντί να φορτώνουν ξανά το ίδιο αρχείο στη ροή εργασίας της παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποτελεσματική όταν εκτελείται επιλεκτικά: διατηρήστε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέστε φωτογραφίες σύμφωνα με το πραγματικό μέγεθος προβολής, αφαιρέστε τα pixel της περικοπής μόνο όταν η μετέπειτα επεξεργασία δεν απαιτείται και αποφύγετε εξωτερικούς συνδέσμους εκτός εάν η διαχείριση εξαρτήσεων αποτελεί μέρος του σχεδιασμού ανάπτυξης.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου εικόνας και ενός πόρου εικόνας;**

Ένα [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) αντιπροσωπεύει έναν πόρο εικόνας που συνδέεται με την παρουσίαση. Ένα [IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/) είναι ένα σχήμα σε μια διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει γεωμετρία και μορφοποίηση επιπέδου πλαισίου όπως μέγεθος, περιστροφή, τιμές περικοπής, εφέ και κλειδώματα.

**Να ενσωματώ ή να συνδέσω εικόνες;**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή να αποδίδεται χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η αποθήκευση των αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές θέσεις μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η περικοπή το μέγεθος του αρχείου PPTX;**

Όχι από μόνη της. Οι κανονικές ρυθμίσεις περικοπής κρύβουν μέρη της πηγαίας εικόνας αλλά διατηρούν τα υποκείμενα pixel. Χρησιμοποιήστε το [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ή τη συμπίεση εικόνας με αφαίρεση των περικομμένων περιοχών όταν αυτά τα pixel μπορούν να διαγραφούν οριστικά.

**Μπορώ να αποκαταστήσω την ποιότητα της εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη raster ανάλυση, και η αφαίρεση των περικομμένων περιοχών διαγράφει δεδομένα εικόνας. Διατηρήστε την αρχική πηγή εικόνας εκτός της παρουσίασης εάν απαιτείται μετέπειτα επεξεργασία υψηλής ανάλυσης.

**Πώς πρέπει να διαχειρίζεστε τις SVG εικόνες;**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η διατήρηση του διανύσματος είναι σημαντική. Ο ενσωματωμένος [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/) μπορεί να εξαχθεί απευθείας. Η απόδοση μιας διαφάνειας σε raster μορφή όπως PNG ή JPEG rasterizes το SVG ως μέρος της εικόνας της διαφάνειας.

**Πώς μπορώ να αποφύγω μη ασφαλείς μετατροπές (casts) όταν διαβάζω υπάρχουσες διαφάνειες;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Η αντιστοίχιση τύπων με [IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/) ή το φιλτράρισμα της συλλογής σ shapes ανά αυτό το interface αποτρέπει μη έγκυρες μετατροπές και επιτρέπει στον κώδικα να διαχειριστεί διαφάνειες που δεν περιέχουν πλαίσια εικόνας.