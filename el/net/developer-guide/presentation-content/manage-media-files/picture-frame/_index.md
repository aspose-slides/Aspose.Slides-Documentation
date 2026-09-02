---
title: Διαχείριση πλαισίων εικόνας σε παρουσιάσεις στο .NET
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
- ραστερ εικόνα
- SVG εικόνα
- αποκοπή εικόνας
- διαγραφή αποκομμένων περιοχών
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
description: "Δημιουργία, μορφοποίηση, σύνδεση, αποκοπή, εξαγωγή και συμπίεση πλαισίων εικόνας σε παρουσιάσεις με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Ένα πλαίσιο εικόνας είναι ένα σχήμα διαφάνειας που εμφανίζει μια εικόνα. Στο Aspose.Slides, ο πόρος εικόνας και το σχήμα που την εμφανίζει είναι ξεχωριστά αντικείμενα: ένα [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) κατέχει ενσωματωμένους πόρους εικόνας μέσω της συλλογής [Images](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/images/) ενώ ένα [IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/) ελέγχει τη θέση, το μέγεθος, τη μορφοποίηση γραμμής, την περιστροφή, την αποκοπή, τα εφέ εικόνας και άλλες ρυθμίσεις επιπέδου πλαισίου.

Αυτή η διάσπαση είναι χρήσιμη όταν η ίδια εικόνα εμφανίζεται περισσότερο από μία φορά. Προσθέστε την εικόνα στην παρουσίαση μία φορά, κρατήστε το επιστραφέν [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/), και χρησιμοποιήστε αυτόν τον πόρο εικόνας όταν δημιουργείτε πλαίσια εικόνας.

Τα πλαίσια εικόνας μπορούν να περιέχουν ραστερ εικόνες όπως PNG ή JPEG και διανυσματικές SVG εικόνες. Μπορούν επίσης να αναφέρονται σε συνδεδεμένες εικόνες αντί να αποθηκεύουν τα δεδομένα της εικόνας στην παρουσίαση. Η επιλογή αυτή επηρεάζει την φορητότητα, το μέγεθος αρχείου, την εξαγωγή και τη συμπεριφορά εξαγωγής, επομένως είναι χρήσιμο να αποφασίσετε πώς θα αποθηκευτεί η εικόνα πριν εφαρμόσετε μορφοποίηση ή βελτιστοποίηση.

## **Προσθήκη και μορφοποίηση ενσωματωμένης εικόνας**

Για μια ενσωματωμένη εικόνα, προσθέστε τα δεδομένα εικόνας στην παρουσίαση και δημιουργήστε ένα πλαίσιο εικόνας με [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addpictureframe/). Η εικόνα γίνεται μέρος του πακέτου παρουσίασης, έτσι η παρουσίαση παραμένει αυτό-συνεκτική όταν μεταφερθεί σε υπολογιστή.

Το παρακάτω παράδειγμα προσθέτει μια JPEG εικόνα, δημιουργεί ένα πλαίσιο με τις φυσικές διαστάσεις της εικόνας και εφαρμόζει μορφοποίηση γραμμής και περιστροφή:

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

Το πλαίσιο εικόνας ελέγχει τη γεωμετρία που εμφανίζεται· η αλλαγή του μεγέθους του πλαισίου δεν αλλάζει τις αρχικές διαστάσεις εικονοστοιχείων που αποθηκεύονται στον ενσωματωμένο πόρο εικόνας. Αυτή η διάκριση γίνεται σημαντική όταν αποκόπτεται ή συμπιέζεται μια εικόνα αργότερα.

## **Χρήση σχετικού κλίμακας**

[IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/) εκθέτει σχετική κλίμακα πλάτους και ύψους για το πλαίσιο. Μια τιμή `1.0` αντιστοιχεί σε 100 % του αρχικού μεγέθους της εικόνας. Η σχετική κλίμακα είναι χρήσιμη όταν μια ροή εργασίας χρειάζεται να διατηρήσει τη σχέση με το μέγεθος της πηγαίας εικόνας αντί να υπολογίζει τις τελικές διαστάσεις χειροκίνητα.

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

Η σχετική κλίμακα αλλάζει τις ρυθμίσεις κλίμακας του πλαισίου· δεν επαναδείγματο ή συμπιέζει την ενσωματωμένη εικόνα.

## **Ενσωματωμένες και συνδεδεμένες εικόνες**

Μια ενσωματωμένη εικόνα αποθηκεύει τα δεδομένα εικόνας μέσα στην παρουσίαση και επομένως αποτελεί την ασφαλέστερη επιλογή για φορητότητα και προβλέψιμη απόδοση. Μια συνδεδεμένη εικόνα αποθηκεύει μια εξωτερική θέση μέσω του μονοπατιού συνδέσμου [ISlidesPicture](https://reference.aspose.com/slides/el/net/aspose.slides/islidespicture/) αντί να ενσωματώνει τα δεδομένα εικόνας με τον ίδιο τρόπο.

Οι συνδεδεμένες εικόνες μπορούν να μειώσουν το πλήθος των δεδομένων εικόνας που αποθηκεύονται στο PPTX, αλλά εισάγουν εξωτερική εξάρτηση. Το συνδεδεμένο αρχείο πρέπει να παραμένει προσβάσιμο στην εφαρμογή που ανοίγει ή αποδίδει την παρουσίαση. Εάν το μονοπάτι αλλάξει, το αρχείο μετακινηθεί ή ο πόρος είναι μη διαθέσιμος, η συνδεδεμένη εικόνα ενδέχεται να μην εμφανιστεί όπως αναμένεται. Για παρουσιάσεις που πρέπει να αποσταλούν μέσω email, να αρχειοθετηθούν ή να αποδοθούν σε απομονωμένα περιβάλλοντα, οι ενσωματωμένες εικόνες είναι συνήθως πιο αξιόπιστες.

### **Προσθήκη συνδεδεμένης εικόνας**

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο εικόνας και το συνδέει με ένα τοπικό αρχείο εικόνας. Ασχολείται μόνο με τη σύνδεση εικόνας· η σύνδεση βίντεο είναι ξεχωριστή ροή πολυμέσων και σκόπιμα δεν αναμιγνύεται σε αυτό το παράδειγμα.

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

Χρησιμοποιήστε συνδέσμους όταν η εξωτερική διαχείριση αρχείων είναι σκόπιμη. Μην τους χρησιμοποιείτε απλώς ως υποκατάστατο συμπίεσης: ένα μικρό PPTX με σπασμένες εξαρτήσεις εικόνας είναι συνήθως λιγότερο χρήσιμο από μια μεγαλύτερη αυτό-συνεκτική παρουσίαση.

## **Εξαγωγή εικόνων από πλαίσια εικόνας**

Πριν εξάγετε μια εικόνα από μια υπάρχουσα παρουσίαση, ελέγξτε ότι ένα σχήμα είναι πραγματικά ένα [IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/) και ότι περιέχει ενσωματωμένη εικόνα. Τα συνδεδεμένα πλαίσια εικόνας ενδέχεται να μην περιέχουν τα δεδομένα εικόνας που μπορούν να εξαχθούν με τον ίδιο τρόπο.

### **Εξαγωγή ραστερ εικόνας**

Το σύγχρονο API εικόνας χρησιμοποιεί απευθείας το [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) και δεν απαιτεί τον παλαιότερο περιτυλίγτη συστήματος‑εικόνας. Το παρακάτω παράδειγμα εντοπίζει την πρώτη ενσωματωμένη ραστερ εικόνα σε μια διαφάνεια και την αποθηκεύει ως PNG:

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

Η αποθήκευση μέσω [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) μετατρέπει την εξαγόμενη εικόνα στη ζητούμενη μορφή εξόδου. Εάν χρειάζεστε τα κωδικοποιημένα bytes που αποθηκεύονται στην παρουσίαση αντί για ένα μετατρεπόμενο ραστερ αρχείο, χρησιμοποιήστε τα δυαδικά δεδομένα του πόρου εικόνας.

### **Εξαγωγή SVG εικόνας**

Για μια SVG εικόνα, το [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) εκθέτει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/). Αυτό σας επιτρέπει να ανακτήσετε τα SVG δεδομένα απευθείας αντί να ραστεροποιήσετε πρώτα την εικόνα.

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

Διατηρώντας το περιεχόμενο SVG ως SVG διατηρείται η διανυσματική πηγή μέσα στην παρουσίαση. Οι ραστερ εξαγωγές όπως PNG ή JPEG αποδίδουν αναγκαστικά αυτό το διανυσματικό περιεχόμενο σε εικονοστοιχεία. Η εξαγωγή διαφάνειας σε PDF ή SVG αποτελεί επίσης λειτουργία απόδοσης, επομένως τα εξαγόμενα γραφικά δεν θα πρέπει να θεωρηθούν ακριβές αντίγραφα byte‑για‑byte του αρχικού ενσωματωμένου SVG· χρησιμοποιήστε τα δεδομένα του ενσωματωμένου [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/) όταν απαιτείται ο ίδιος ο αρχικός διανυσματικός πόρος.

## **Αποκοπή εικόνας**

Η αποκοπή αλλάζει ποιο μέρος της εικόνας είναι ορατό εντός του πλαισίου. Οι τιμές αποκοπής στο [IPictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/) είναι ποσοστά των διαστάσεων της πηγαίας εικόνας. Η αποκοπή δεν διαγράφει αρχικά τα κρυφά εικονοστοιχεία από την ενσωματωμένη εικόνα· αλλάζει μόνο την ορατή περιοχή.

Το παρακάτω παράδειγμα εντοπίζει με ασφάλεια ένα πλαίσιο εικόνας και εφαρμόζει τιμές αποκοπής:

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

Επειδή τα κρυφά δεδομένα εικόνας παραμένουν, η αποκοπή μπορεί να αλλάξει αργότερα χωρίς απώλεια των αρχικών εικονοστοιχείων. Εάν το μέγεθος αρχείου είναι πιο σημαντικό από την δυνατότητα επαναφοράς, οι αποκομμένες περιοχές μπορούν να αφαιρεθούν φυσικά όπως περιγράφεται στην επόμενη ενότητα.

## **Αφαίρεση δεδομένων αποκομμένης εικόνας**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) αφαιρεί τα δεδομένα εικόνας εκτός του τρέχοντος ορθογωνίου αποκοπής και επιστρέφει τον προκύπτοντα πόρο εικόνας. Αυτό μπορεί να μειώσει το μέγεθος αρχείου, αλλά αποτελεί καταστροφική βελτιστοποίηση: μετά την αποθήκευση της παρουσίασης, τα αφαιρεθέντα εικονοστοιχεία δεν είναι πλέον διαθέσιμα για επαναφορά.

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

Η μέθοδος μπορεί να προσθέσει νέο πόρο εικόνας στην παρουσίαση. Εάν η αρχική εικόνα χρησιμοποιείται επίσης από άλλα πλαίσια εικόνας, αυτά τα πλαίσια χρειάζονται ακόμη τον υπάρχοντα πόρο, οπότε η διαγραφή των αποκομμένων περιοχών δεν μειώνει υποχρεωτικά τον συνολικό αριθμό εικόνων. Η αποκοπή WMF ή EMF περιεχομένου με αυτή τη μέθοδο ραστεροποιεί το αποτέλεσμα σε PNG.

## **Συμπίεση ραστερ εικόνων**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/compressimage/) μειώνει την ανάλυση ραστερ εικόνας σχετικά με το μέγεθος με το οποίο η εικόνα εμφανίζεται. Μπορεί επίσης να αφαιρέσει περιοχές αποκοπής στην ίδια λειτουργία. Η μέθοδος επιστρέφει `true` όταν η εικόνα έχει αλλάξει μέγεθος ή αποκοπεί και `false` όταν δεν απαιτήθηκε αλλαγή.

Χρησιμοποιήστε μια προ‑καθορισμένη τιμή [PicturesCompression](https://reference.aspose.com/slides/el/net/aspose.slides.export/picturescompression/) όταν μια τυπική στόχευση ανάλυσης είναι επαρκής:

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

Μπορείτε επίσης να περάσετε μια προσαρμοσμένη θετική τιμή DPI αντί για τιμή enum όταν απαιτείται συγκεκριμένος στόχος.

Η συμπίεση προορίζεται για ραστερ εικόνες. Το SVG και το περιεχόμενο μετααρχειάς δεν μειώνονται από αυτή τη ροή συμπίεσης ραστερ. Επίσης, θυμηθείτε ότι η χαμηλότερη ανάλυση και οι διαγραμμένες αποκομμένες περιοχές δεν μπορούν να ανακτηθούν από την βελτιστοποιημένη παρουσίαση. Επιλέξτε στόχο ανάλυσης βάσει του μέγιστου μεγέθους στο οποίο η εικόνα θα προβληθεί ή θα εξαχθεί, αντί να εφαρμόζετε το χαμηλότερο DPI παγκοσμίως.

## **Διαχείριση εφέ μετασχηματισμού εικόνας**

Για πλήρη ροή εργασίας που καλύπτει φωτεινότητα, αντίθεση, χρωματικούς μετασχηματισμούς, θόλωση, εφέ άλφα, αλυσίδες εντολών, επιθεώρηση, αφαίρεση και επαλήθευση round‑trip, δείτε [Image Transform Effects](/slides/el/net/image-transform-effects/).

## **Κλείδωμα γεωμετρίας πλαισίου εικόνας**

Οι ρυθμίσεις [IPictureFrameLock](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframelock/) ελέγχουν ποιες λειτουργίες επεξεργασίας είναι απενεργοποιημένες για ένα πλαίσιο εικόνας. Για παράδειγμα, το κλείδωμα λόγου διαστάσεων διατηρεί τις αναλογίες του σχήματος ενώ μεταβάλλεται το μέγεθός του.

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

Το κλείδωμα εφαρμόζεται στο σχήμα του πλαισίου εικόνας. Δεν αναγκάζει την πηγαία εικόνα να επαναδειγματοληφθεί ή να αλλάξει μόνιμα στο ίδιο λόγο διαστάσεων.

## **Προσαρμογή τιμών StretchOffset**

Όταν η λειτουργία γεμίσματος εικόνας είναι stretch, οι τιμές stretch‑offset στο [IPictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/) ορίζουν το ορθογώνιο γέμισμα σχετικό με το περιοριστικό πλαίσιο του πλαισίου εικόνας. Θετικά ποσοστά δημιουργούν εσοχή από την άκρη, ενώ αρνητικά ποσοστά δημιουργούν έξοδο.

Αυτό διαφέρει από την αποκοπή. Οι τιμές αποκοπής επιλέγουν ποιο μέρος της πηγαίας εικόνας είναι ορατό· τα stretch offset αλλάζουν το ορθογώνιο μέσα στο οποίο τεντώνεται το ορατό γεμίσμα εικόνας.

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

Χρησιμοποιήστε stretch offset για τοποθέτηση γεμίσματος. Χρησιμοποιήστε ιδιότητες αποκοπής όταν ο στόχος είναι η απόκρυψη άκρων της πηγαίας εικόνας.

## **Αποθήκευση, μέγεθος αρχείου και παραμέτρους εξαγωγής**

Τα κύρια εμπορικά σημεία γίνονται πιο εύκολα στη διαχείριση όταν η αποθήκευση εικόνας και η μορφοποίηση πλαισίου αντιμετωπίζονται χωριστά:

- **Ενσωματωμένες εικόνες** κάνουν την παρουσίαση αυτό‑συνεκτική και είναι οι πιο αξιόπιστες για κοινή χρήση και απόδοση διακομιστή, αλλά μεγάλες ραστερ εικόνες αυξάνουν το μέγεθος PPTX και τη χρήση μνήμης.
- **Συνδεδεμένες εικόνες** μπορούν να κρατήσουν το πακέτο μικρότερο, αλλά η παρουσίαση εξαρτάται από εξωτερικά αρχεία που παραμένουν διαθέσιμα στις αποθηκευμένες διαδρομές ή θέσεις.
- **Αποκοπή** είναι αρχικά μη καταστροφική. Τα κρυφά εικονοστοιχεία παραμένουν ενσωματωμένα μέχρι να διαγραφούν ρητά οι αποκομμένες περιοχές ή να αφαιρεθούν κατά τη συμπίεση.
- **Συμπίεση** μπορεί να μειώσει σημαντικά το μέγεθος αρχείου για υπερμεγέθη ραστερ εικόνες, αλλά θυσιάζει την πηγαία ανάλυση. Θα πρέπει να εφαρμοστεί αφού γνωριστεί το προοριζόμενο μέγεθος στην διαφάνεια.
- **SVG εικόνες** πρέπει να παραμείνουν ως SVG όταν η διατήρηση διανυσματικής μορφής είναι σημαντική. Εξάγετε το ενσωματωμένο SVG απευθείας όταν χρειάζεστε τον ίδιο τον διανυσματικό πόρο. Οι ραστερ εξαγωγές διαφάνειας μετατρέπουν πάντα τη διαφάνεια σε εικονοστοιχεία.
- **Επανάληψη εικόνων** πρέπει να επαναχρησιμοποιεί έναν υπάρχοντα πόρο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) όταν είναι δυνατόν αντί να φορτώνεται ξανά το ίδιο αρχείο στην ροή εργασίας της παρουσίασης.

Για μεγάλες παρουσιάσεις, η βελτιστοποίηση εικόνας είναι συνήθως πιο αποτελεσματική όταν πραγματοποιείται επιλεκτικά: διατηρείτε λογότυπα και διαγράμματα ως διανυσματικό περιεχόμενο, συμπιέζετε φωτογραφίες ανάλογα με το πραγματικό μέγεθος προβολής, αφαιρείτε αποκομμένα pixels μόνο όταν δεν απαιτείται επεγγιή αργότερα, και αποφεύγετε εξωτερικούς συνδέσμους εκτός εάν η διαχείριση εξαρτήσεων αποτελεί μέρος του σχεδίου ανάπτυξης.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ πλαισίου εικόνας και πόρου εικόνας;**

Ένα [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) αντιπροσωπεύει έναν πόρο εικόνας που συνδέεται με την παρουσίαση. Ένα [IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/) είναι ένα σχήμα σε μια διαφάνεια που εμφανίζει μια εικόνα και αποθηκεύει τη γεωμετρία και τη μορφοποίηση σε επίπεδο πλαισίου όπως μέγεθος, περιστροφή, τιμές αποκοπής, εφέ και κλειδώματα.

**Πρέπει να ενσωματώνω ή να συνδέω τις εικόνες;**

Ενσωματώστε εικόνες όταν η παρουσίαση πρέπει να είναι φορητή, αρχειοθετημένη ή αποδοθεί χωρίς πρόσβαση σε εξωτερικούς πόρους. Συνδέστε εικόνες μόνο όταν η αποθήκευση των αρχείων εικόνας εκτός του PPTX είναι σκόπιμη και οι εξωτερικές θέσεις μπορούν να διατηρηθούν αξιόπιστα.

**Μειώνει η αποκοπή το μέγεθος αρχείου PPTX;**

Όχι από μόνη της. Οι κανονικές ρυθμίσεις αποκοπής κρύβουν τμήματα της πηγαίας εικόνας αλλά διατηρούν τα υποκείμενα εικονοστοιχεία. Χρησιμοποιήστε [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ή συμπίεση εικόνας με αφαίρεση αποκομμένων περιοχών όταν αυτά τα εικονοστοιχεία μπορούν να διαγραφούν μόνιμα.

**Μπορώ να αποκαταστήσω την ποιότητα εικόνας μετά τη συμπίεση;**

Όχι. Η συμπίεση μπορεί να μειώσει την αποθηκευμένη ραστερ ανάλυση, και η αφαίρεση αποκομμένων περιοχών διαγράφει δεδομένα εικόνας. Κρατήστε την αρχική πηγαία εικόνα εκτός της παρουσίασης εάν απαιτείται μεταγενέστερη επεξεργασία υψηλής ανάλυσης.

**Πώς πρέπει να διαχειρίζομαι τις SVG εικόνες;**

Διατηρήστε το περιεχόμενο SVG ως SVG όταν η διανυσματική ακεραιότητα είναι σημαντική. Το ενσωματωμένο [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/) μπορεί να εξαχθεί απευθείας. Η απόδοση μιας διαφάνειας σε ραστερ μορφή όπως PNG ή JPEG ραστεροποιεί το SVG ως μέρος της εικόνας της διαφάνειας.

**Πώς μπορώ να αποφύγω μη ασφαλείς μετατροπές τύπων κατά την ανάγνωση υπαρχουσών διαφανειών;**

Ελέγξτε τον τύπο του σχήματος πριν χρησιμοποιήσετε μέλη ειδικά για πλαίσια εικόνας. Η αντιστοίχιση τύπου με [IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/) ή το φιλτράρισμα της συλλογής σ shapes με αυτό το interface αποφεύγει άκυρες μετατροπές και επιτρέπει στον κώδικα να διαχειρίζεται διαφάνειες που δεν περιέχουν πλαίσια εικόνας.