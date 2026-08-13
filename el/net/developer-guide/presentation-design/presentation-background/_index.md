---
title: Διοίκηση Φόντου Παρουσίασης σε .NET
linktitle: Φόντο Διαφάνειας
type: docs
weight: 20
url: /el/net/presentation-background/
keywords:
- φόντο παρουσίασης
- φόντο διαφάνειας
- στερεό χρώμα
- διαβαθμισμένο χρώμα
- φόντο εικόνας
- διαφάνεια φόντου
- ιδιότητες φόντου
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να ορίζετε δυναμικά φόντα σε αρχεία PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET, με συμβουλές κώδικα για να ενισχύσετε τις παρουσιάσεις σας."
---
## **Εισαγωγή**

Τα στερεά χρώματα, τα διαβαθμισμένα χρώματα και οι εικόνες χρησιμοποιούνται συνήθως ως φόντο διαφανειών. Μπορείτε να ορίσετε το φόντο για μια **κανονική διαφάνεια** (μια μόνο διαφάνεια) ή για μια **κύρια διαφάνεια** (εφαρμόζεται σε πολλές διαφάνειες ταυτόχρονα).

![Φόντο PowerPoint](powerpoint-background.png)

## **Ορισμός Στερεού Χρώματος Φόντου για Κανονική Διαφάνεια**

Το Aspose.Slides σας επιτρέπει να ορίσετε ένα στερεό χρώμα ως φόντο για μια συγκεκριμένη διαφάνεια σε μια παρουσίαση — ακόμη και αν η παρουσίαση χρησιμοποιεί κύρια διαφάνεια. Η αλλαγή εφαρμόζεται μόνο στην επιλεγμένη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Ορίστε την ιδιότητα [BackgroundType](https://reference.aspose.com/slides/el/net/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε την ιδιότητα [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Solid`.
4. Χρησιμοποιήστε την ιδιότητα [SolidFillColor](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/solidfillcolor/) στο [FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/) για να καθορίσετε το στερεό χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το ακόλουθο παράδειγμα C# δείχνει πώς να ορίσετε το μπλε στερεό χρώμα ως φόντο για μια κανονική διαφάνεια:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργήστε μια παρουσία της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ορίστε το χρώμα φόντου της διαφάνειας σε μπλε.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Στερεού Χρώματος Φόντου για Κύρια Διαφάνεια**

Το Aspose.Slides σας επιτρέπει να ορίσετε ένα στερεό χρώμα ως φόντο για την κύρια διαφάνεια σε μια παρουσίαση. Η κύρια διαφάνεια λειτουργεί ως πρότυπο που ελέγχει τη μορφοποίηση για όλες τις διαφάνειες, έτσι όταν επιλέγετε ένα στερεό χρώμα για το φόντο της κύριας διαφάνειας, αυτό εφαρμόζεται σε κάθε διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Ορίστε την ιδιότητα [BackgroundType](https://reference.aspose.com/slides/el/net/aspose.slides/backgroundtype/) της κύριας διαφάνειας (μέσω `masters`) σε `OwnBackground`.
3. Ορίστε την ιδιότητα [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του φόντου της κύριας διαφάνειας σε `Solid`.
4. Χρησιμοποιήστε το [SolidFillColor](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/solidfillcolor/) για να καθορίσετε το στερεό χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το ακόλουθο παράδειγμα C# δείχνει πώς να ορίσετε ένα στερεό χρώμα (πράσινο δάση) ως φόντο για την κύρια διαφάνεια:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργήστε μια παρουσία της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Ορίστε το χρώμα φόντου για τη κύρια διαφάνεια σε Πράσινο Δάσους.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Διαβαθμισμένου Φόντου για Διαφάνεια**

Η διαβάθμιση είναι ένα γραφικό εφέ που δημιουργείται από μια σταδιακή αλλαγή του χρώματος. Όταν χρησιμοποιείται ως φόντο διαφάνειας, οι διαβαθμίσεις μπορούν να κάνουν τις παρουσιάσεις να φαίνονται πιο καλλιτεχνικές και επαγγελματικές. Το Aspose.Slides σας επιτρέπει να ορίσετε ένα διαβαθμισμένο χρώμα ως φόντο για διαφάνειες.

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Ορίστε την ιδιότητα [BackgroundType](https://reference.aspose.com/slides/el/net/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε την ιδιότητα [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Gradient`.
4. Χρησιμοποιήστε την ιδιότητα [GradientFormat](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/gradientformat/) στο [FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/) για να διαμορφώσετε τις προτιμώμενες ρυθμίσεις διαβάθμισης.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το ακόλουθο παράδειγμα C# δείχνει πώς να ορίσετε ένα διαβαθμισμένο χρώμα ως φόντο για διαφάνεια:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργήστε μια παρουσία της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Εφαρμόστε ένα διαβαθμιστικό εφέ στο φόντο.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Εικόνας ως Φόντο Διαφάνειας**

Εκτός από στερεές και διαβαθμισμένες γεμίσεις, το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε εικόνες ως φόντο διαφάνειας.

1. Δημιουργήστε μια παρουσία της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Ορίστε την ιδιότητα [BackgroundType](https://reference.aspose.com/slides/el/net/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε την ιδιότητα [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Picture`.
4. Φορτώστε την εικόνα που θέλετε να χρησιμοποιήσετε ως φόντο διαφάνειας.
5. Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
6. Χρησιμοποιήστε την ιδιότητα [PictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/picturefillformat/) στο [FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/) για να ορίσετε την εικόνα ως φόντο.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το ακόλουθο παράδειγμα C# δείχνει πώς να ορίσετε μια εικόνα ως φόντο για διαφάνεια:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργήστε μια παρουσία της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ορίστε τις ιδιότητες εικόνας φόντου.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Φορτώστε την εικόνα.
    IImage image = Images.FromFile("Tulips.jpg");
    // Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

Το ακόλουθο δείγμα κώδικα δείχνει πώς να ορίσετε τον τύπο γεμίσματος φόντου σε εναλλασσόμενο (tiled) σχήμα εικόνας και να τροποποιήσετε τις ιδιότητες επικάλυψης:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Ορίστε την εικόνα που χρησιμοποιείται για τη γέμιση φόντου.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Ορίστε τη λειτουργία γέμισης εικόνας σε Tile και προσαρμόστε τις ιδιότητες του πλακιδίου.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}

Διαβάστε περισσότερα: [**Τίσωση Εικόνας ως Υφή**](/slides/el/net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Αλλαγή Διαφάνειας της Εικόνας Φόντου**

Μπορεί να θέλετε να προσαρμόσετε τη διαφάνεια της εικόνας φόντου μιας διαφάνειας ώστε το περιεχόμενο της διαφάνειας να ξεχωρίζει. Ο παρακάτω κώδικας C# δείχνει πώς να αλλάξετε τη διαφάνεια για μια εικόνα φόντου διαφάνειας:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // Για παράδειγμα.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Λάβετε τη συλλογή των λειτουργιών μετασχηματισμού εικόνας.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // Βρείτε ένα υπάρχον εφέ διαφάνειας σταθερού ποσοστού.
    var transparencyOperation = null as IAlphaModulateFixed;
    foreach (var operation in imageTransform)
    {
        if (operation is IAlphaModulateFixed alphaModulateFixed)
        {
            transparencyOperation = alphaModulateFixed;
            break;
        }
    }

    // Ορίστε τη νέα τιμή διαφάνειας.
    if (transparencyOperation == null)
    {
        imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else
    {
        transparencyOperation.Amount = (100 - transparencyValue);
    }

    presentation.Save("ImageBackgroundTransparency.pptx", SaveFormat.Pptx);
}
```

## **Λήψη Τιμής Φόντου Διαφάνειας**

Το Aspose.Slides παρέχει τη διεπαφή [IBackgroundEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ibackgroundeffectivedata/) για την ανάκτηση των αποτελεσματικών τιμών φόντου μιας διαφάνειας. Αυτή η διεπαφή εκθέτει το αποτελεσματικό [FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ibackgroundeffectivedata/fillformat/) και το [EffectFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

Χρησιμοποιώντας την ιδιότητα `background` της κλάσης [BaseSlide](https://reference.aspose.com/slides/el/net/aspose.slides/baseslide/), μπορείτε να λάβετε το αποτελεσματικό φόντο για μια διαφάνεια.

Το ακόλουθο παράδειγμα C# δείχνει πώς να λάβετε την αποτελεσματική τιμή φόντου μιας διαφάνειας:

```cs
using Aspose.Slides;

// Δημιουργήστε μια παρουσία της κλάσης Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Ανακτήστε το αποτελεσματικό φόντο, λαμβάνοντας υπόψη το master, το layout και το theme.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **Συχνές Ερωτήσεις**

### Μπορώ να επαναφέρω ένα προσαρμοσμένο φόντο και να αποκαταστήσω το φόντο θέματος/διάταξης;

Ναι. Αφαιρέστε τη προσαρμοσμένη γεμιστική της διαφάνειας και το φόντο θα κληρονομηθεί ξανά από τη σχετική διαφάνεια [διάταξης](/slides/el/net/slide-layout/)/[κύρια](/slides/el/net/slide-master/) (δηλαδή το [φόντο θέματος](/slides/el/net/presentation-theme/)).

### Τι συμβαίνει με το φόντο αν αλλάξω αργότερα το θέμα της παρουσίασης;

Αν μια διαφάνεια έχει τη δική της γεμιστική, αυτή θα παραμείνει αμετάβλητη. Αν το φόντο κληρονομείται από τη [διάταξη](/slides/el/net/slide-layout/)/[κύρια](/slides/el/net/slide-master/), θα ενημερωθεί ώστε να ταιριάζει με το [νέο θέμα](/slides/el/net/presentation-theme/).