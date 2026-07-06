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
- προσθήκη εικόνας
- δημιουργία εικόνας
- εξαγωγή εικόνας
- ράστερ εικόνα
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
description: "Προσθέστε πλαίσια εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για .NET. Απλοποιήστε τη ροή εργασίας σας και βελτιώστε το σχεδιασμό των διαφανειών."
---
## **Εισαγωγή**

Ένα πλαίσιο εικόνας είναι ένα σχήμα που περιέχει μια εικόνα—είναι σαν μια εικόνα σε πλαίσιο.  

Μπορείτε να προσθέσετε μια εικόνα σε μια διαφάνεια μέσω ενός πλαισίου εικόνας. Με αυτόν τον τρόπο, διαμορφώνετε την εικόνα μορφοποιώντας το πλαίσιο εικόνας.

{{% alert  title="Συμβουλή" color="primary" %}} 

Η Aspose παρέχει δωρεάν μετατροπείς—[JPEG σε PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG σε PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν στους χρήστες να δημιουργούν παρουσιάσεις γρήγορα από εικόνες. 

{{% /alert %}} 

## **Δημιουργία Πλαισίου Εικόνας**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation). 
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage) προσθέτοντας μια εικόνα στη συλλογή [IImagescollection](https://reference.aspose.com/slides/el/net/aspose.slides/iimagecollection) που είναι συσχετισμένη με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για τη γέμιση του σχήματος.
4. Καθορίστε το πλάτος και το ύψος της εικόνας.
5. Δημιουργήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe) με βάση το πλάτος και το ύψος της εικόνας μέσω της μεθόδου `AddPictureFrame` που εκτίθεται από το αντικείμενο σχήματος που σχετίζεται με τη διαφάνεια αναφοράς.
6. Προσθέστε ένα πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```c#
// Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation pres = new Presentation())
{
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide slide = pres.Slides[0];

    // Φορτώνει μια εικόνα και τη προσθέτει στη συλλογή εικόνων της παρουσίασης
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

Τα πλαίσια εικόνας σας επιτρέπουν να δημιουργήσετε γρήγορα διαφάνειες παρουσίασης βασισμένες σε εικόνες. Όταν συνδυάσετε το πλαίσιο εικόνας με τις επιλογές αποθήκευσης του Aspose.Slides, μπορείτε να διαχειριστείτε λειτουργίες εισόδου/εξόδου για να μετατρέψετε εικόνες από μια μορφή σε άλλη. Μπορείτε να δείτε αυτές τις σελίδες: μετατροπή [image to JPG](https://products.aspose.com/slides/el/net/conversion/image-to-jpg/)· μετατροπή [JPG to image](https://products.aspose.com/slides/el/net/conversion/jpg-to-image/)· μετατροπή [JPG to PNG](https://products.aspose.com/slides/el/net/conversion/jpg-to-png/), μετατροπή [PNG to JPG](https://products.aspose.com/slides/el/net/conversion/png-to-jpg/), μετατροπή [PNG to SVG](https://products.aspose.com/slides/el/net/conversion/png-to-svg/), μετατροπή [SVG to PNG](https://products.aspose.com/slides/el/net/conversion/svg-to-png/).

{{% /alert %}}

## **Δημιουργία Πλαισίου Εικόνας με Σχετική Κλίμακα**

Με την τροποποίηση της σχετικής κλιμάκωσης μιας εικόνας, μπορείτε να δημιουργήσετε ένα πιο περίπλοκο πλαίσιο εικόνας. 

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation). 
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε μια εικόνα στη συλλογή εικόνων της παρουσίασης.
4. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage) προσθέτοντας μια εικόνα στη συλλογή [IImagescollection](https://reference.aspose.com/slides/el/net/aspose.slides/iimagecollection) που είναι συσχετισμένη με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για τη γέμιση του σχήματος.
5. Καθορίστε το σχετικό πλάτος και ύψος της εικόνας στο πλαίσιο εικόνας.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```c#
// Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation presentation = new Presentation())
{
    // Φορτώνει μια εικόνα και τη προσθέτει στη συλλογή εικόνων της παρουσίασης
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

Μπορείτε να εξάγετε ράστερ εικόνες από αντικείμενα [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe) και να τις αποθηκεύσετε σε μορφές PNG, JPG και άλλες. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε μια εικόνα από το έγγραφο "sample.pptx" και να την αποθηκεύσετε σε μορφή PNG.

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Εξαγωγή SVG Εικόνων από Πλαίσια Εικόνας**

Όταν μια παρουσίαση περιέχει γραφικά SVG τοποθετημένα μέσα σε σχήματα [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/) , το Aspose.Slides για .NET σας επιτρέπει να ανακτήσετε τις αρχικές διανυσματικές εικόνες με πλήρη πιστότητα. Διασχίζοντας τη συλλογή σχημάτων της διαφάνειας, μπορείτε να εντοπίσετε κάθε [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/), να ελέγξετε αν το υποκείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) περιέχει περιεχόμενο SVG, και έπειτα να αποθηκεύσετε αυτήν την εικόνα σε δίσκο ή ροή στη φυσική της μορφή SVG.

Ο ακόλουθος κώδικας δείχνει πώς να εξάγετε μια SVG εικόνα από ένα πλαίσιο εικόνας:

```cs
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

## **Λήψη Διαφάνειας Εικόνας**

Η Aspose.Slides σας επιτρέπει να λάβετε το αποτέλεσμα διαφάνειας που εφαρμόζεται σε μια εικόνα. Αυτός ο κώδικας C# επιδεικνύει τη λειτουργία:

```c#
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

## **Λήψη Φωτεινότητας και Αντίθεσης Εικόνας**

Η Aspose.Slides σας επιτρέπει να λάβετε το αποτέλεσμα φωτεινότητας και αντίθεσης που εφαρμόζεται σε μια εικόνα. Η διεπαφή [ILuminance](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iluminance/) αντιπροσωπεύει αυτήν την μετατροπή εικόνας.

Αυτός ο κώδικας C# δείχνει πώς να λάβετε τις ρυθμίσεις φωτεινότητας και αντίθεσης από ένα πλαίσιο εικόνας:

```csharp
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

{{% alert color="primary" %}} 
Όλες οι επιδράσεις που εφαρμόζονται στις εικόνες μπορούν να βρεθούν στο [Aspose.Slides.Effects](https://reference.aspose.com/slides/el/net/aspose.slides.effects/).
{{% /alert %}}

## **Μορφοποίηση Πλαισίου Εικόνας**

Το Aspose.Slides παρέχει πολλές επιλογές μορφοποίησης που μπορούν να εφαρμοστούν σε ένα πλαίσιο εικόνας. Χρησιμοποιώντας αυτές τις επιλογές, μπορείτε να τροποποιήσετε ένα πλαίσιο εικόνας ώστε να ανταποκρίνεται σε συγκεκριμένες απαιτήσεις.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](http://www.aspose.com/api/net/slides/el/aspose.slides/). 
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage) προσθέτοντας μια εικόνα στη συλλογή [IImagescollection](https://reference.aspose.com/slides/el/net/aspose.slides/iimagecollection) που είναι συσχετισμένη με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για τη γέμιση του σχήματος.
4. Καθορίστε το πλάτος και το ύψος της εικόνας.
5. Δημιουργήστε ένα `PictureFrame` με βάση το πλάτος και το ύψος της εικόνας μέσω της μεθόδου [AddPictureFrame](http://www.aspose.com/api/net/slides/el/aspose.slides/ishapecollection/methods/addpictureframe) που εκτίθεται από το αντικείμενο [IShapes](http://www.aspose.com/api/net/slides/el/aspose.slides/ishapecollection) που σχετίζεται με τη διαφάνεια αναφοράς.
6. Προσθέστε το πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.
7. Ορίστε το χρώμα γραμμής του πλαισίου εικόνας.
8. Ορίστε το πάχος γραμμής του πλαισίου εικόνας.
9. Περιστρέψτε το πλαίσιο εικόνας δίνοντάς του μια θετική ή αρνητική τιμή.
   * Μια θετική τιμή περιστρέφει την εικόνα δεξιόστροφα. 
   * Μια αρνητική τιμή περιστρέφει την εικόνα αριστερόστροφα.
10. Προσθέστε το πλαίσιο εικόνας (που περιέχει την εικόνα) στη διαφάνεια.
11. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```c#
// Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation presentation = new Presentation())
{
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide slide = presentation.Slides[0];

    // Φορτώνει μια εικόνα και τη προσθέτει στη συλλογή εικόνων της παρουσίασης
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

{{% alert color="primary" %}}

Η Aspose ανέπτυξε πρόσφατα ένα [free Collage Maker](https://products.aspose.app/slides/el/collage). Εάν χρειαστεί ποτέ να [συγχωνεύσετε JPG/JPEG](https://products.aspose.app/slides/el/collage/jpg) ή PNG εικόνες, ή να [δημιουργήσετε πλέγματα από φωτογραφίες](https://products.aspose.app/slides/el/collage/photo-grid), μπορείτε να χρησιμοποιήσετε αυτήν την υπηρεσία. 

{{% /alert %}}

## **Προσθήκη Εικόνας ως Σύνδεσμο**

Για να αποφύγετε μεγάλα μεγέθη παρουσίασης, μπορείτε να προσθέσετε εικόνες (ή βίντεο) μέσω συνδέσμων αντί να ενσωματώνετε τα αρχεία απευθείας στις παρουσιάσεις. Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε μια εικόνα και βίντεο σε έναν placeholder:

```c#
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
using (Presentation presentation = new Presentation())
{
    // Δημιουργεί ένα νέο αντικείμενο εικόνας
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Προσθέτει ένα PictureFrame σε μια διαφάνεια
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Κόβει την εικόνα (τιμές ποσοστών)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Αποθηκεύει το αποτέλεσμα
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Διαγραφή Περιοχών Περικοπής σε Πλαίσιο**

Εάν θέλετε να διαγράψετε τις περιοχές περικοπής μιας εικόνας που περιέχεται σε ένα πλαίσιο, μπορείτε να χρησιμοποιήσετε τη μέθοδο [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Αυτή η μέθοδος επιστρέφει την περικομμένη εικόνα ή την αρχική εικόνα εάν η περικοπή δεν είναι απαραίτητη.

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Λαμβάνει το PictureFrame από την πρώτη διαφάνεια
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Διαγράφει τις περιοχές περικοπής της εικόνας του PictureFrame και επιστρέφει την περικομμένη εικόνα
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Αποθηκεύει το αποτέλεσμα
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Η μέθοδος [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) προσθέτει την περικομμένη εικόνα στη συλλογή εικόνων της παρουσίασης. Εάν η εικόνα χρησιμοποιείται μόνο στο επεξεργασμένο [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/), αυτή η ρύθμιση μπορεί να μειώσει το μέγεθος της παρουσίασης. Διαφορετικά, ο αριθμός των εικόνων στην τελική παρουσίαση θα αυξηθεί.

Η μέθοδος μετατρέπει τα μετααρχικά αρχεία WMF/EMF σε ράστερ εικόνα PNG κατά τη διαδικασία περικοπής. 

{{% /alert %}}

## **Συμπίεση Εικόνων**

Μπορείτε να συμπιέσετε μια εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/compressimage/). Αυτή η μέθοδος συμπιέζει μια εικόνα μειώνοντας το μέγεθός της με βάση το μέγεθος του σχήματος και την καθορισμένη ανάλυση, με τη δυνατότητα διαγραφής περιοχών περικοπής. 

Προσαρμόζει το μέγεθος και την ανάλυση της εικόνας παρόμοια με τη λειτουργία **Picture Format → Compress Pictures → Resolution** του PowerPoint.

Τα παρακάτω παραδείγματα C# δείχνουν πώς να συμπιέσετε μια εικόνα σε μια παρουσίαση καθορίζοντας μια στοχευμένη ανάλυση και προαιρετικά αφαιρώντας περιοχές περικοπής:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Συμπιέστε την εικόνα με στοχευμένη ανάλυση 150 DPI (ανάλυση Web) και αφαιρέστε τις περιοχές περικοπής.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Ελέγξτε το αποτέλεσμα της συμπίεσης.
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

Ή χρησιμοποιώντας απευθείας μια προσαρμοσμένη τιμή DPI:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Συμπιέστε την εικόνα στα 150 DPI (ανάλυση Web), αφαιρώντας τις περιοχές περικοπής.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Η μέθοδος μετατρέπει την εικόνα σε χαμηλότερη ανάλυση με βάση το μέγεθος του σχήματος και το παρεχόμενο DPI. Οι περιοχές περικοπής μπορούν επίσης να διαγραφούν για βελτιστοποίηση του μεγέθους του αρχείου.  
Εάν η εικόνα είναι μετααρχείο (WMF/EMF) ή SVG, η συμπίεση δεν θα εφαρμοστεί. Επίσης, η ποιότητα JPEG διατηρείται ή μειώνεται ελαφρώς ανάλογα με την ανάλυση, όπως γίνεται στο PowerPoint για υψηλής ανάλυσης JPEGs.

{{% /alert %}}

## **Κλείδωμα Αναλογίας Διαστάσεων**

Εάν θέλετε ένα σχήμα που περιέχει μια εικόνα να διατηρεί την αναλογία διαστάσεών του ακόμη και μετά την αλλαγή των διαστάσεων της εικόνας, μπορείτε να χρησιμοποιήσετε την ιδιότητα [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframelock/aspectratiolocked/) για να ορίσετε τη ρύθμιση *Lock Aspect Ratio*. 

Αυτός ο κώδικας C# δείχνει πώς να κλειδάρετε την αναλογία διαστάσεων ενός σχήματος:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Ορίζει το σχήμα να διατηρεί την αναλογία διαστάσεων όταν αλλάζει το μέγεθος
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Αυτή η ρύθμιση *Lock Aspect Ratio* διατηρεί μόνο την αναλογία διαστάσεων του σχήματος και όχι της εικόνας που περιέχει.

{{% /alert %}}

## **Χρήση της Ιδιότητας StretchOff**

Χρησιμοποιώντας τις ιδιότητες [StretchOffsetLeft](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat/properties/stretchoffsetright) και [StretchOffsetBottom](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) από τη διεπαφή [IPictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat) και την κλάση [PictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat), μπορείτε να καθορίσετε ένα ορθογώνιο γεμίσματος. 

Όταν ορίζεται stretching για μια εικόνα, ένα αρχικό ορθογώνιο κλιμακώνεται ώστε να ταιριάζει στο καθορισμένο ορθογώνιο γεμίσματος. Κάθε πλευρά του ορθογωνίου ορίζεται από ένα ποσοστό μετατόπισης από την αντίστοιχη πλευρά του περιθωρίου του σχήματος. Ένα θετικό ποσοστό υποδεικνύει εσοχή, ενώ ένα αρνητικό ποσοστό υποδεικνύει εξόρθηση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](http://www.aspose.com/api/net/slides/el/aspose.slides/). 
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο `AutoShape`. 
4. Δημιουργήστε μια εικόνα.
5. Ορίστε τον τύπο γεμίσματος του σχήματος.
6. Ορίστε τη λειτουργία γεμίσματος εικόνας του σχήματος.
7. Προσθέστε μια εικόνα για γέμισμα του σχήματος.
8. Καθορίστε τις μετατοπίσεις εικόνας από την αντίστοιχη πλευρά του περιθωρίου του σχήματος.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Ορίζει την εικόνα να τεντωθεί από κάθε πλευρά στο σώμα του σχήματος
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Πώς μπορώ να μάθω ποιες μορφές εικόνας υποστηρίζονται για το PictureFrame;**

Το Aspose.Slides υποστηρίζει τόσο ραστέρ εικόνες (PNG, JPEG, BMP, GIF κλπ.) όσο και διανυσματικές εικόνες (π.χ., SVG) μέσω του αντικειμένου εικόνας που ανατίθεται σε ένα [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/). Η λίστα των υποστηριζόμενων μορφών γενικά συμπίπτει με τις δυνατότητες της μηχανής διαφάνειας και μετατροπής εικόνας.

**Πώς θα επηρεάσει η προσθήκη δεκάδων μεγάλων εικόνων το μέγεθος και την απόδοση του PPTX;**

Η ενσωμάτωση μεγάλων εικόνων αυξάνει το μέγεθος του αρχείου και τη χρήση μνήμης· η σύνδεση εικόνων βοηθά στη διατήρηση του μικρότερου μεγέθους της παρουσίασης, αλλά απαιτεί τα εξωτερικά αρχεία να είναι προσβάσιμα. Το Aspose.Slides παρέχει τη δυνατότητα προσθήκης εικόνων μέσω συνδέσμου για μείωση του μεγέθους του αρχείου.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο εικόνας από τυχαία μετακίνηση/αλλαγή μεγέθους;**

Χρησιμοποιήστε τα [shape locks](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/pictureframelock/) για ένα [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/) (π.χ., απενεργοποίηση μετακίνησης ή αλλαγής μεγέθους). Ο μηχανισμός κλειδώματος περιγράφεται για σχήματα σε ξεχωριστό [protection article](/slides/el/net/applying-protection-to-presentation/) και υποστηρίζεται για διάφορους τύπους σχημάτων, συμπεριλαμβανομένου του [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/).

**Διατηρείται η πιστότητα του διανύσματος SVG κατά την εξαγωγή μιας παρουσίασης σε PDF/εικόνες;**

Το Aspose.Slides επιτρέπει την εξαγωγή ενός SVG από ένα [PictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/pictureframe/) ως το αρχικό διάνυσμα. Κατά την [εξαγωγή σε PDF](/slides/el/net/convert-powerpoint-to-pdf/) ή σε [ραστέρ μορφές](/slides/el/net/convert-powerpoint-to-png/), το αποτέλεσμα μπορεί να ραστεροποιηθεί ανάλογα με τις ρυθμίσεις εξαγωγής· το γεγονός ότι το αρχικό SVG αποθηκεύεται ως διάνυσμα επιβεβαιώνεται από τη συμπεριφορά εξαγωγής.