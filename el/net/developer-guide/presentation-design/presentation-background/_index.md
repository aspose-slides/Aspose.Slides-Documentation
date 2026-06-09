---
title: Διαχείριση Φόντων Παρουσίασης σε .NET
linktitle: Φόντο Διαφάνειας
type: docs
weight: 20
url: /el/net/presentation-background/
keywords:
- φόντο παρουσίασης
- φόντο διαφάνειας
- συμπαγές χρώμα
- χρώμα διαβάθμισης
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

Τα συμπαγή χρώματα, οι διαβαθμίσεις και οι εικόνες χρησιμοποιούνται συνήθως ως φόντο διαφανειών. Μπορείτε να ορίσετε το φόντο για μια **κανονική διαφάνεια** (μια μόνο διαφάνεια) ή μια **κύρια διαφάνεια** (εφαρμόζεται σε πολλές διαφάνειες ταυτόχρονα).

![PowerPoint background](powerpoint-background.png)

## **Ορισμός Σταθερού Χρώματος Φόντου για Κανονική Διαφάνεια**

Το Aspose.Slides σας επιτρέπει να ορίσετε ένα συμπαγές χρώμα ως φόντο για μια συγκεκριμένη διαφάνεια σε μια παρουσίαση—ακόμη και αν η παρουσίαση χρησιμοποιεί κύρια διαφάνεια. Η αλλαγή εφαρμόζεται μόνο στη συγκεκριμένη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/net/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Solid`.
4. Χρησιμοποιήστε την ιδιότητα [SolidFillColor](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/solidfillcolor/) στο [FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/) για να καθορίσετε το συμπαγές χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα C# δείχνει πώς να ορίσετε ένα μπλε συμπαγές χρώμα ως φόντο για μια κανονική διαφάνεια:

```cs
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

## **Ορισμός Σταθερού Χρώματος Φόντου για Κύρια Διαφάνεια**

Το Aspose.Slides σας επιτρέπει να ορίσετε ένα συμπαγές χρώμα ως φόντο για την κύρια διαφάνεια σε μια παρουσίαση. Η κύρια διαφάνεια λειτουργεί ως πρότυπο που ελέγχει τη μορφοποίηση όλων των διαφανειών, έτσι όταν επιλέγετε ένα συμπαγές χρώμα για το φόντο της κύριας διαφάνειας, εφαρμόζεται σε κάθε διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/net/aspose.slides/backgroundtype/) της κύριας διαφάνειας (μέσω `masters`) σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του φόντου της κύριας διαφάνειας σε `Solid`.
4. Χρησιμοποιήστε το [SolidFillColor](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/solidfillcolor/) για να καθορίσετε το συμπαγές χρώμα φόντου.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα C# δείχνει πώς να ορίσετε ένα συμπαγές χρώμα (πράσινο δάσους) ως φόντο για μια κύρια διαφάνεια:

```cs
// Δημιουργήστε μια παρουσία της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Ορίστε το χρώμα φόντου της κύριας διαφάνειας σε Πράσινο Δάσους.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Διαβαθμισμένου Φόντου για Διαφάνεια**

Μια διαβάθμιση είναι ένα γραφικό εφέ που δημιουργείται από μια σταδιακή αλλαγή χρώματος. Όταν χρησιμοποιείται ως φόντο διαφάνειας, οι διαβαθμίσεις μπορούν να κάνουν τις παρουσιάσεις πιο καλλιτεχνικές και επαγγελματικές. Το Aspose.Slides σας επιτρέπει να ορίσετε ένα χρώμα διαβάθμισης ως φόντο για διαφάνειες.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/net/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Gradient`.
4. Χρησιμοποιήστε την ιδιότητα [GradientFormat](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/gradientformat/) στο [FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/) για να διαμορφώσετε τις προτιμώμενες ρυθμίσεις διαβάθμισης.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα C# δείχνει πώς να ορίσετε ένα χρώμα διαβάθμισης ως φόντο για μια διαφάνεια:

```cs
// Δημιουργήστε μια παρουσία της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Εφαρμόστε ένα εφέ διαβάθμισης στο φόντο.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Αποθηκεύστε την παρουσίαση στο δίσκο.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Εικόνας ως Φόντο Διαφάνειας**

Εκτός από συμπαγείς και διαβαθμισμένες γεμίσεις, το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε εικόνες ως φόντο διαφάνειας.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Ορίστε το [BackgroundType](https://reference.aspose.com/slides/el/net/aspose.slides/backgroundtype/) της διαφάνειας σε `OwnBackground`.
3. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του φόντου της διαφάνειας σε `Picture`.
4. Φορτώστε την εικόνα που θέλετε να χρησιμοποιήσετε ως φόντο διαφάνειας.
5. Προσθέστε την εικόνα στη συλλογή εικόνων της παρουσίασης.
6. Χρησιμοποιήστε την ιδιότητα [PictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/picturefillformat/) στο [FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/) για να αναθέσετε την εικόνα ως φόντο.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα C# δείχνει πώς να ορίσετε μια εικόνα ως φόντο για μια διαφάνεια:

```c#
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

Το παρακάτω δείγμα κώδικα δείχνει πώς να ορίσετε τον τύπο γεμίσματος φόντου σε μια εικονοστοιχειωμένη εικόνα και να τροποποιήσετε τις ιδιότητες επικάλυψης:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Ορίστε την εικόνα που χρησιμοποιείται για το γέμισμα φόντου.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Ορίστε τη λειτουργία γεμίσματος εικόνας σε Πλακίδιο και προσαρμόστε τις ιδιότητες του πλακιδίου.
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

{{% alert color="primary" %}}
Διαβάστε περισσότερα: [**Tile Picture As Texture**](/slides/el/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Αλλαγή Διαφάνειας Εικόνας Φόντου**

Μπορεί να θέλετε να προσαρμόσετε τη διαφάνεια της εικόνας φόντου μιας διαφάνειας ώστε το περιεχόμενο της διαφάνειας να ξεχωρίζει. Το παρακάτω κώδικα C# σας δείχνει πώς να αλλάξετε τη διαφάνεια για μια εικόνα φόντου διαφάνειας:

```cs
var transparencyValue = 30; // Για παράδειγμα.

// Αποκτήστε τη συλλογή των λειτουργιών μετασχηματισμού εικόνας.
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
```

## **Λήψη Τιμής Φόντου Διαφάνειας**

Το Aspose.Slides παρέχει τη διεπαφή [IBackgroundEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ibackgroundeffectivedata/) για την ανάκτηση των αποτελεσματικών τιμών φόντου μιας διαφάνειας. Αυτή η διεπαφή εκθέτει το αποτελεσματικό [FillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ibackgroundeffectivedata/fillformat/) και το [EffectFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

Χρησιμοποιώντας την ιδιότητα `background` της κλάσης [BaseSlide](https://reference.aspose.com/slides/el/net/aspose.slides/baseslide/), μπορείτε να αποκτήσετε το αποτελεσματικό φόντο μιας διαφάνειας.

Το παρακάτω παράδειγμα C# δείχνει πώς να λάβετε την αποτελεσματική τιμή φόντου μιας διαφάνειας:

```cs
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

**Μπορώ να επαναφέρω ένα προσαρμοσμένο φόντο και να επαναφέρω το φόντο θέματος/διάταξης;**

Ναι. Αφαιρέστε την προσαρμοσμένη γεμιστική της διαφάνειας, και το φόντο θα κληρονομηθεί ξανά από την αντίστοιχη διαφάνεια [διάταξη](/slides/el/net/slide-layout/)/[κύρια](/slides/el/net/slide-master/) (δηλαδή το [φόντο θέματος](/slides/el/net/presentation-theme/)).

**Τι συμβαίνει με το φόντο αν αλλάξω το θέμα της παρουσίασης αργότερα;**

Αν μια διαφάνεια έχει τη δική της γεμιστική, αυτή θα παραμείνει αμετάβλητη. Αν το φόντο κληρονομείται από τη [διάταξη](/slides/el/net/slide-layout/)/[κύρια](/slides/el/net/slide-master/), θα ενημερωθεί ώστε να ταιριάζει με το [νέο θέμα](/slides/el/net/presentation-theme/).