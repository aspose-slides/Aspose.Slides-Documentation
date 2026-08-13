---
title: Διαχείριση Πλαισίων Εικόνας σε Παρουσιάσεις σε .NET
linktitle: Πλαίσιο Εικόνας
type: docs
weight: 10
url: /el/net/picture-frame/
keywords:
- πλαίσιο εικόνας
- προσθήκη πλαισίου εικόνας
- δημιουργία πλαισίου εικόνας
- προσθήκη εικόνας
- δημιουργία εικόνας
- εξαγωγή εικόνας
- ραστερ εικόνας
- διανυσματική εικόνα
- περικοπή εικόνας
- περιοχή περικοπής
- ιδιότητα StretchOff
- μορφοποίηση πλαισίου εικόνας
- ιδιότητες πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- αναλογία διαστάσεων
- διαφάνεια εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Προσθέστε πλαίσια εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με Aspose.Slides για .NET. Βελτιώστε τη ροή εργασίας σας και ενισχύστε το σχεδιασμό των διαφανειών."
---
## **Εισαγωγή**

Ένα πλαίσιο εικόνας είναι ένα σχήμα που περιέχει μια εικόνα—είναι σαν μια εικόνα σε πλαίσιο.  

Μπορείτε να προσθέσετε μια εικόνα σε μια διαφάνεια μέσω ενός πλαισίου εικόνας. Με αυτόν τον τρόπο, μορφοποιείτε την εικόνα μορφοποιώντας το πλαίσιο εικόνας.

{{% alert  title="Tip" color="info" %}} 

Η Aspose παρέχει δωρεάν μετατροπείς—[JPEG σε PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG σε PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν στους χρήστες να δημιουργούν παρουσιάσεις γρήγορα από εικόνες. 

{{% /alert %}} 

## **Δημιουργία Πλαισίου Εικόνας**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation). 
2. Αποκτήστε αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage) προσθέτοντας μια εικόνα στην [IImagescollection](https://reference.aspose.com/slides/el/net/aspose.slides/iimagecollection) που συσχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για τη γεμίσματος του σχήματος. 
4. Καθορίστε το πλάτος και το ύψος της εικόνας. 
5. Δημιουργήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe) με βάση το πλάτος και το ύψος της εικόνας μέσω της μεθόδου `AddPictureFrame` που εκτίθεται από το αντικείμενο σχήματος που συσχετίζεται με τη σχετική διαφάνεια. 
6. Προσθέστε ένα πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια. 
7. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX. 

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation pres = new Presentation())
{
    // Αποκτά την πρώτη διαφάνεια
    ISlide slide = pres.Slides[0];

    // Φορτώνει μια εικόνα και την προσθέτει στη συλλογή εικόνων της παρουσίασης
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Προσθέτει ένα πλαίσιο εικόνας με το ίδιο ύψος και πλάτος
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Εφαρμόζει κάποιες μορφοποιήσεις στο πλαίσιο εικόνας
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Αποθηκεύει την παρουσίαση σε αρχείο PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Τα πλαίσια εικόνας σας επιτρέπουν να δημιουργείτε γρήγορα διαφάνειες παρουσίασης βασισμένες σε εικόνες. Όταν συνδυάσετε το πλαίσιο εικόνας με τις επιλογές αποθήκευσης του Aspose.Slides, μπορείτε να χειρίζεστε τις λειτουργίες εισόδου/εξόδου για να μετατρέψετε εικόνες από τη μια μορφή στην άλλη. Μπορείτε να δείτε αυτές τις σελίδες: μετατρέψτε [εικόνα σε JPG](https://products.aspose.com/slides/el/net/conversion/image-to-jpg/); μετατρέψτε [JPG σε εικόνα](https://products.aspose.com/slides/el/net/conversion/jpg-to-image/); μετατρέψτε [JPG σε PNG](https://products.aspose.com/slides/el/net/conversion/jpg-to-png/), μετατρέψτε [PNG σε JPG](https://products.aspose.com/slides/el/net/conversion/png-to-jpg/); μετατρέψτε [PNG σε SVG](https://products.aspose.com/slides/el/net/conversion/png-to-svg/), μετατρέψτε [SVG σε PNG](https://products.aspose.com/slides/el/net/conversion/svg-to-png/). 

{{% /alert %}}

## **Δημιουργία Πλαισίου Εικόνας με Σχετική Κλίμακα**

Αλλαγώντας τη σχετική κλιμάκωση μιας εικόνας, μπορείτε να δημιουργήσετε ένα πιο πολύπλοκο πλαίσιο εικόνας. 

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation). 
2. Αποκτήστε αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Προσθέστε μια εικόνα στη συλλογή εικόνων της παρουσίασης. 
4. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage) προσθέτοντας μια εικόνα στην [IImagescollection](https://reference.aspose.com/slides/el/net/aspose.slides/iimagecollection) που συσχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για τη γεμίσματος του σχήματος. 
5. Καθορίστε το σχετικό πλάτος και ύψος της εικόνας στο πλαίσιο εικόνας. 
6. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX. 

Αυτός ο κώδικας C# δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας με σχετική κλίμακα:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation presentation = new Presentation())
{
    // Φορτώνει μια εικόνα και την προσθέτει στη συλλογή εικόνων της παρουσίασης
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Προσθέτει ένα πλαίσιο εικόνας στη διαφάνεια
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Ορίζει το σχετικό πλάτος και ύψος κλίμακας
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Αποθηκεύει την παρουσίαση
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Εξαγωγή Ράστερ Εικόνων από Πλαίσια Εικόνας**

Μπορείτε να εξάγετε ραστέρ εικόνες από αντικείμενα [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe) και να τις αποθηκεύσετε σε PNG, JPG και άλλες μορφές. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε μια εικόνα από το έγγραφο "sample.pptx" και να τη σώσετε σε μορφή PNG.

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Εξαγωγή SVG Εικόνων από Πλαίσια Εικόνας**

Όταν μια παρουσίαση περιέχει γραφικά SVG τοποθετημένα μέσα σε σχήματα [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/), το Aspose.Slides for .NET σας επιτρέπει να ανακτήσετε τις αρχικές διανυσματικές εικόνες με πλήρη πιστότητα. Διασχίζοντας τη συλλογή σχημάτων της διαφάνειας, μπορείτε να εντοπίσετε κάθε [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/), να ελέγξετε εάν το υποκείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) περιέχει περιεχόμενο SVG και, στη συνέχεια, να αποθηκεύσετε αυτήν την εικόνα σε δίσκο ή ροή στη φυσική της μορφή SVG.

Ο παρακάτω κώδικας δείχνει πώς να εξάγετε μια SVG εικόνα από ένα πλαίσιο εικόνας:

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **Λήψη Διαφανούς Εφέ μιας Εικόνας**

Το Aspose.Slides σάς επιτρέπει να λάβετε το εφέ διαφάνειας που εφαρμόστηκε σε μια εικόνα. Αυτός ο κώδικας C# δείχνει τη λειτουργία:

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **Λήψη Φωτεινότητας και Αντίθεσης μιας Εικόνας**

Το Aspose.Slides σάς επιτρέπει να λάβετε το εφέ φωτεινότητας και αντίθεσης που εφαρμόστηκε σε μια εικόνα. Η διεπαφή [ILuminance](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iluminance/) αντιπροσωπεύει αυτή τη μετασχηματιστική λειτουργία εικόνας.

Αυτός ο κώδικας C# δείχνει πώς να λάβετε τις ρυθμίσεις φωτεινότητας και αντίθεσης από ένα πλαίσιο εικόνας:

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="info" %}} 
Όλα τα εφέ που εφαρμόζονται σε εικόνες μπορούν να βρεθούν στο [Aspose.Slides.Effects](https://reference.aspose.com/slides/el/net/aspose.slides.effects/).
{{% /alert %}}

## **Μορφοποίηση Πλαισίου Εικόνας**

Το Aspose.Slides παρέχει πολλές επιλογές μορφοποίησης που μπορούν να εφαρμοστούν σε ένα πλαίσιο εικόνας. Χρησιμοποιώντας αυτές τις επιλογές, μπορείτε να τροποποιήσετε ένα πλαίσιο εικόνας ώστε να ταιριάζει σε συγκεκριμένες απαιτήσεις.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](http://www.aspose.com/api/net/slides/el/aspose.slides/) . 
2. Αποκτήστε αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage) προσθέτοντας μια εικόνα στην [IImagescollection](https://reference.aspose.com/slides/el/net/aspose.slides/iimagecollection) που συσχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για το γέμισμα του σχήματος. 
4. Καθορίστε το πλάτος και το ύψος της εικόνας. 
5. Δημιουργήστε ένα `PictureFrame` με βάση το πλάτος και το ύψος της εικόνας μέσω της μεθόδου [AddPictureFrame](http://www.aspose.com/api/net/slides/el/aspose.slides/ishapecollection/methods/addpictureframe) που εκτίθεται από το αντικείμενο [IShapes](http://www.aspose.com/api/net/slides/el/aspose.slides/ishapecollection) που συσχετίζεται με τη σχετική διαφάνεια. 
6. Προσθέστε το πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια. 
7. Ορίστε το χρώμα της γραμμής του πλαισίου εικόνας. 
8. Ορίστε το πλάτος της γραμμής του πλαισίου εικόνας. 
9. Περιστρέψτε το πλαίσιο εικόνας δίνοντας είτε θετική είτε αρνητική τιμή. 
   * Μια θετική τιμή περιστρέφει την εικόνα δεξιόστροφα. 
   * Μια αρνητική τιμή περιστρέφει την εικόνα αριστερόστροφα. 
10. Προσθέστε το πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια. 
11. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX. 

Αυτός ο κώδικας C# δείχνει τη διαδικασία μορφοποίησης του πλαισίου εικόνας:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation presentation = new Presentation())
{
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide slide = presentation.Slides[0];

    // Φορτώνει μια εικόνα και την προσθέτει στη συλλογή εικόνων της παρουσίασης
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Προσθέτει ένα πλαίσιο εικόνας με το ίδιο ύψος και πλάτος της εικόνας
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Εφαρμόζει κάποιες μορφοποιήσεις στο πλαίσιο εικόνας
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Αποθηκεύει την παρουσίαση σε αρχείο PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}

Η Aspose πρόσφατα ανέπτυξε έναν [δωρεάν Collage Maker](https://products.aspose.app/slides/el/collage). Αν χρειαστείτε ποτέ να [συνδυάσετε JPG/JPEG](https://products.aspose.app/slides/el/collage/jpg) ή PNG εικόνες, [δημιουργήσετε πλέγματα από φωτογραφίες](https://products.aspose.app/slides/el/collage/photo-grid), μπορείτε να χρησιμοποιήσετε αυτήν την υπηρεσία. 

{{% /alert %}}

## **Προσθήκη Εικόνας ως Σύνδεσμου**

Για να αποφύγετε μεγάλα μεγέθη παρουσίασης, μπορείτε να προσθέτετε εικόνες (ή βίντεο) μέσω συνδέσμου αντί να ενσωματώνετε τα αρχεία απευθείας στις παρουσιάσεις. Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε μια εικόνα και βίντεο σε ένα placeholder:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Περικοπή Εικόνων**

Αυτός ο κώδικας C# δείχνει πώς να περικόψετε μια υπάρχουσα εικόνα σε μια διαφάνεια:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // Δημιουργεί ένα νέο αντικείμενο εικόνας
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Προσθέτει ένα PictureFrame σε μια διαφάνεια
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Κόβει την εικόνα (ποσοστώντις τιμές)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Αποθηκεύει το αποτέλεσμα
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Διαγραφή Περιοχών Περικομμένων μιας Εικόνας**

Αν θέλετε να διαγράψετε τις περιοχές που έχουν περικοπεί από μια εικόνα που βρίσκεται σε πλαίσιο, μπορείτε να χρησιμοποιήσετε τη μέθοδο [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Αυτή η μέθοδος επιστρέφει την περικομμένη εικόνα ή την αρχική εικόνα εάν η περικοπή είναι περιττή.

Αυτός ο κώδικας C# δείχνει τη λειτουργία:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Λαμβάνει το PictureFrame από την πρώτη διαφάνεια
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Διαγράφει τις περιοχές που έχουν περικοπεί από την εικόνα του PictureFrame και επιστρέφει την περικομμένη εικόνα
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Αποθηκεύει το αποτέλεσμα
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Η μέθοδος [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) προσθέτει την περικομμένη εικόνα στη συλλογή εικόνων της παρουσίασης. Αν η εικόνα χρησιμοποιείται μόνο στο επεξεργασμένο [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/), αυτή η ρύθμιση μπορεί να μειώσει το μέγεθος της παρουσίασης. Διαφορετικά, ο αριθμός των εικόνων στην τελική παρουσίαση θα αυξηθεί.

Αυτή η μέθοδος μετατρέπει τα μετα-αρχεία WMF/EMF σε ράστερ PNG στην πράξη της περικοπής. 

{{% /alert %}}

## **Συμπίεση Εικόνων**

Μπορείτε να συμπιέσετε μια εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/compressimage/). Αυτή η μέθοδος συμπιέζει μια εικόνα μειώνοντας το μέγεθός της βάσει του μεγέθους του σχήματος και της καθορισμένης ανάλυσης, με επιλογή διαγραφής των περικομμένων περιοχών. 

Προσαρμόζει το μέγεθος και την ανάλυση της εικόνας παρόμοια με τη λειτουργία **Picture Format → Compress Pictures → Resolution** του PowerPoint. 

Τα ακόλουθα παραδείγματα C# δείχνουν πώς να συμπιέσετε μια εικόνα σε μια παρουσίαση καθορίζοντας μια στοχευμένη ανάλυση και προαιρετικά διαγράφοντας τις περικομμένες περιοχές:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Συμπιέζει την εικόνα με στοχευμένη ανάλυση 150 DPI (ανάλυση Ιστού) και αφαιρεί τις περικομμένες περιοχές.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Ελέγχει το αποτέλεσμα της συμπίεσης.
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

Ή χρησιμοποιώντας μια προσαρμοσμένη τιμή DPI απευθείας:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Συμπιέζει την εικόνα σε 150 DPI (ανάλυση web), αφαιρώντας τις περικομμένες περιοχές.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Η μέθοδος μετατρέπει την εικόνα σε χαμηλότερη ανάλυση βάσει του μεγέθους του σχήματος και του παρεχόμενου DPI. Οι περικομμένες περιοχές μπορούν επίσης να διαγραφούν για βελτιστοποίηση του μεγέθους του αρχείου.  
Αν η εικόνα είναι μετα-αρχείο (WMF/EMF) ή SVG, η συμπίεση δεν θα εφαρμοστεί. Επίσης, η ποιότητα JPEG διατηρείται ή μειώνεται ελαφρώς βάσει της ανάλυσης, όπως γίνεται από το PowerPoint με υψηλής ανάλυσης JPEG. 

{{% /alert %}}

## **Κλείδωμα Αναλογίας Πλευρών**

Αν θέλετε ένα σχήμα που περιέχει μια εικόνα να διατηρεί την αναλογία πλευρών του ακόμη και μετά την αλλαγή των διαστάσεων της εικόνας, μπορείτε να χρησιμοποιήσετε την ιδιότητα [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframelock/aspectratiolocked/) για να ορίσετε τη ρύθμιση *Lock Aspect Ratio*. 

Αυτός ο κώδικας C# δείχνει πώς να κλειδώσετε την αναλογία πλευρών ενός σχήματος:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Ορίζει το σχήμα να διατηρεί την αναλογία διαστάσεων κατά την αλλαγή μεγέθους
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Αυτή η ρύθμιση *Lock Aspect Ratio* διατηρεί μόνο την αναλογία πλευρών του σχήματος και όχι της εικόνας που περιέχει. 

{{% /alert %}}

## **Χρήση της Ιδιότητας StretchOff**

Χρησιμοποιώντας τις ιδιότητες [StretchOffsetLeft](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat/properties/stretchoffsetright) και [StretchOffsetBottom](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) από τη διεπαφή [IPictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat) και την κλάση [PictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat), μπορείτε να καθορίσετε ένα ορθογώνιο γεμίσματος. 

Όταν καθορίζεται τέντωμα για μια εικόνα, ένα ορθογώνιο προέλευσης κλιμακώνεται ώστε να ταιριάζει στο καθορισμένο ορθογώνιο γεμίσματος. Κάθε άκρο του ορθογωνίου γεμίσματος ορίζεται από ποσοστιαία απόσταση από το αντίστοιχο άκρο του πλαισίου του σχήματος. Ένα θετικό ποσοστό ορίζει εσωτερική απόσταση, ενώ ένα αρνητικό ποσοστό ορίζει εξωτερική απόσταση. 

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](http://www.aspose.com/api/net/slides/el/aspose.slides/) . 
2. Αποκτήστε αναφορά σε μια διαφάνεια μέσω του δείκτη της. 
3. Προσθέστε ένα ορθογώνιο `AutoShape`. 
4. Δημιουργήστε μια εικόνα. 
5. Ορίστε τον τύπο γεμίσματος του σχήματος. 
6. Ορίστε τη λειτουργία γεμίσματος εικόνας του σχήματος. 
7. Προσθέστε μια εικόνα για γέμισμα του σχήματος. 
8. Καθορίστε τις αποστάσεις της εικόνας από το αντίστοιχο άκρο του πλαισίου του σχήματος 
9. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX. 

Αυτός ο κώδικας C# δείχνει μια διαδικασία που χρησιμοποιεί την ιδιότητα StretchOff:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Ορίζει την εικόνα τεντωμένη από κάθε πλευρά στο σώμα του σχήματος
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

### Πώς μπορώ να μάθω ποιοι τύποι εικόνας υποστηρίζονται για το PictureFrame;

Το Aspose.Slides υποστηρίζει τόσο ραστέρ εικόνες (PNG, JPEG, BMP, GIF κ.λπ.) όσο και διανυσματικές εικόνες (π.χ., SVG) μέσω του αντικειμένου εικόνας που έχει ανατεθεί σε ένα [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/). Η λίστα των υποστηριζόμενων μορφών γενικά επικαλύπτεται με τις δυνατότητες της μηχανής μετατροπής διαφάνειας και εικόνας.

### Πώς θα επηρεάσει η προσθήκη δεκάδων μεγάλων εικόνων το μέγεθος και την απόδοση του PPTX;

Η ενσωμάτωση μεγάλων εικόνων αυξάνει το μέγεθος του αρχείου και τη χρήση μνήμης· η σύνδεση εικόνων βοηθά στη μείωση του μεγέθους της παρουσίασης, αλλά απαιτεί τα εξωτερικά αρχεία να παραμένουν προσβάσιμα. Το Aspose.Slides παρέχει τη δυνατότητα προσθήκης εικόνων μέσω συνδέσμου για μείωση του μεγέθους του αρχείου.

### Πώς μπορώ να κλειδώσω ένα αντικείμενο εικόνας από ακούσια μετακίνηση/αλλαγή μεγέθους;

Χρησιμοποιήστε τα κλειδώματα σχήματος ([shape locks](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/pictureframelock/)) για ένα [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/) (π.χ., απενεργοποιήστε τη μετακίνηση ή αλλαγή μεγέθους). Ο μηχανισμός κλειδώματος περιγράφεται για σχήματα σε ένα ξεχωριστό [article προστασίας](/slides/el/net/applying-protection-to-presentation/) και υποστηρίζεται για διάφορους τύπους σχημάτων, συμπεριλαμβανομένου του [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/).

### Διατηρείται η πιστότητα του διανύσματος SVG όταν εξάγεται μια παρουσίαση σε PDF/εικόνες;

Το Aspose.Slides επιτρέπει την εξαγωγή ενός SVG από ένα [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/) ως το αρχικό διάνυσμα. Όταν γίνεται εξαγωγή σε PDF (/slides/el/net/convert-powerpoint-to-pdf/) ή σε ράστερ μορφές (/slides/el/net/convert-powerpoint-to-png/), το αποτέλεσμα μπορεί να ραστεριστεί ανάλογα με τις ρυθμίσεις εξαγωγής· το γεγονός ότι το αρχικό SVG αποθηκεύεται ως διάνυσμα επιβεβαιώνεται από τη συμπεριφορά εξαγωγής.