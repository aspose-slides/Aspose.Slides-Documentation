---
title: Βελτιώστε την Επεξεργασία Εικόνας με το Σύγχρονο API
linktitle: Σύγχρονο API
type: docs
weight: 237
url: /el/net/modern-api/
keywords:
- System.Drawing
- σύγχρονο API
- σχεδίαση
- μικρογραφία διαφάνειας
- διαφάνεια σε εικόνα
- μικρογραφία σχήματος
- σχήμα σε εικόνα
- μικρογραφία παρουσίασης
- παρουσίαση σε εικόνες
- προσθήκη εικόνας
- προσθήκη εικόνας
- .NET
- C#
- Aspose.Slides
description: Αναβαθμίστε την επεξεργασία εικόνας διαφανειών αντικαθιστώντας τις παρωχημένες API απεικόνισης με το .NET Σύγχρονο API για άψογη αυτοματοποίηση PowerPoint και OpenDocument.
---
## **Εισαγωγή**

Ιστορικά, το Aspose Slides εξαρτάται από το System.Drawing και στο δημόσιο API περιλαμβάνει τις ακόλουθες κλάσεις από αυτό:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Από την έκδοση 24.4, αυτό το δημόσιο API έχει χαρακτηριστεί ως παρωχημένο.

Καθώς η υποστήριξη του System.Drawing στις εκδόσεις .NET6 και άνω αφαιρέθηκε για μη‑Windows εκδόσεις ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), το Slides υλοποίησε μια προσέγγιση δύο πακέτων:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - υποστήριξη για .NET6+ για Windows, .NETStandard για Windows/Linux/MacOS, .NETFramework 2+ (Windows).
  - έχει εξάρτηση από [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - Έκδοση για Windows/Linux/MacOS χωρίς εξαρτήσεις.

Το πρόβλημα του [Aspose.Slides.NET6.CrossPlatform] είναι ότι υλοποιεί τη δική του έκδοση του System.Drawing στην ίδια χώρο ονομάτων (για να υποστηρίξει τη συμβατότητα με το δημόσιο API). Έτσι, όταν το Aspose.Slides.NET6.CrossPlatform και το System.Drawing από το .NET Framework ή το πακέτο System.Drawing.Common χρησιμοποιούνται ταυτόχρονα, προκύπτει σύγκρουση ονομάτων εκτός εάν χρησιμοποιηθεί ψευδώνυμο.

Για να απαλλαγούμε από τις εξαρτήσεις στο System.Drawing στο κύριο πακέτο Aspose.Slides.NET, προσθέσαμε το λεγόμενο «Modern API» – δηλαδή το API που θα πρέπει να χρησιμοποιείται αντί του παρωχημένου, των οποίων οι υπογραφές περιέχουν εξαρτήσεις στους παρακάτω τύπους από το System.Drawing: [Image] και [Bitmap]. Οι [PrinterSettings] και [Graphics] έχουν χαρακτηριστεί ως παρωχημένα και η υποστήριξή τους αφαιρέθηκε από το δημόσιο API του Slides.

Στις τρέχουσες εκδόσεις, αντιμετωπίζετε το δημόσιο API που εξαρτάται από το System.Drawing ως παλαιότερο/παρωχημένο. Χρησιμοποιήστε το Modern API για νέο κώδικα και κατά τη μετάβαση των υφιστάμενων ροών εργασίας επεξεργασίας εικόνας.

## **Σύγχρονο API**

Προστέθηκαν οι παρακάτω κλάσεις και enum στο δημόσιο API:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) - αντιπροσωπεύει την ραστική ή διανυσματική εικόνα.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/el/net/aspose.slides/imageformat/) - αντιπροσωπεύει τη μορφή αρχείου της εικόνας.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/el/net/aspose.slides/images/) - μέθοδοι για δημιουργία και εργασία με τη διεπαφή [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/).

Παρακαλούμε σημειώστε ότι το [IImage] είναι διαχειρίσιμο (υλοποιεί τη διεπαφή [IDisposable] και η χρήση του πρέπει να περιβάλλεται σε `using` ή να διακοπτεί με άλλο βολικό τρόπο).

Χρησιμοποιήστε `GetImage` για απόδοση μιας ενιαίας διαφάνειας ή σχήματος. Χρησιμοποιήτε `GetImages` για απόδοση πολλαπλών διαφανειών παρουσίασης. Χρησιμοποιήτε τις μεθόδους του [Images] για φόρτωση εικόνων, `AddImage` με [IImage] για προσθήκη τους σε παρουσίαση, και `ReplaceImage` με [IImage] για ενημέρωση υπάρχουσας εικόνας παρουσίασης.

Ένα τυπικό σενάριο χρήσης του νέου API μπορεί να φαίνεται ως εξής:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // δημιουργήστε μια διαχειρίσιμη εμφάνιση του IImage από το αρχείο στο δίσκο.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // δημιουργήστε μια εικόνα PowerPoint προσθέτοντας μια εμφάνιση IImage στις εικόνες της παρουσίασης.
        ppImage = pres.Images.AddImage(image);
    }

    // προσθέστε ένα σχήμα εικόνας στη διαφάνεια #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // λάβετε μια εμφάνιση του IImage που αντιπροσωπεύει τη διαφάνεια #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // αποθηκεύστε την εικόνα στο δίσκο.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Αντικατάσταση παλαιού κώδικα με το Σύγχρονο API**

Για ευκολία μετάβασης, η διεπαφή του νέου [IImage] επαναλαμβάνει τις ξεχωριστές υπογραφές των κλάσεων [Image] και [Bitmap]. Γενικά, θα χρειαστεί απλώς να αντικαταστήσετε την κλήση στην παλιά μέθοδο που χρησιμοποιεί το System.Drawing με τη νέα.

### **Λήψη μικρογραφίας διαφάνειας**

Παλιό/παρωχημένο API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Σύγχρονο API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Λήψη μικρογραφίας σχήματος**

Παλιό/παρωχημένο API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Σύγχρονο API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Λήψη μικρογραφίας παρουσίασης**

Παλιό/παρωχημένο API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var bitmaps = pres.GetThumbnails(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < bitmaps.Length; index++)
        {
            Bitmap thumbnail = bitmaps[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (Bitmap bitmap in bitmaps)
        {
            bitmap.Dispose();
        }
    }
}
```

Σύγχρονο API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var images = pres.GetImages(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < images.Length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (IImage image in images)
        {
            image.Dispose();
        }
    }
}
```

### **Προσθήκη εικόνας σε παρουσίαση**

Παλιό/παρωχημένο API:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (Image image = Image.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

Σύγχρονο API:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (IImage image = Aspose.Slides.Images.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

## **Μέθοδοι/Ιδιότητες που έχουν αποσυρθεί και η αντικατάστασή τους στο Σύγχρονο API**

### **Presentation**
| Υπογραφή Μεθόδου                               | Αντικατάσταση Υπογραφής Μεθόδου                             |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/getimages#getimages)                   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/getimages#getimages_1)   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print()                           | No Modern API replacement                               |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement                            |
| public void Print(string printerName)         | No Modern API replacement                               |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement                          |

### **Shape**
| Υπογραφή Μεθόδου                                                      | Αντικατάσταση Υπογραφής Μεθόδου                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail()                                          | [GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/shape/getimage#getimage)                                                           |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/el/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Υπογραφή Μεθόδου                                                      | Αντικατάσταση Υπογραφής Μεθόδου                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY)                | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/el/net/aspose.slides/slide/getimage#getimage_5)                                 |
| public Bitmap GetThumbnail()                                         | [GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/slide/getimage#getimage)                                                              |
| public Bitmap GetThumbnail(IRenderingOptions options)                | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/el/net/aspose.slides/slide/getimage#getimage_1)                                  |
| public Bitmap GetThumbnail(Size imageSize)                           | [GetImage(Size imageSize)](https://reference.aspose.com/slides/el/net/aspose.slides/slide/getimage#getimage_6)                                             |
| public Bitmap GetThumbnail(ITiffOptions options)                    | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/el/net/aspose.slides/slide/getimage#getimage_4)                                      |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/el/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/el/net/aspose.slides/slide/getimage#getimage_3)               |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement                                       |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement                             |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement                                    |

### **Output**
| Υπογραφή Μεθόδου                                                | Αντικατάσταση Υπογραφής Μεθόδου                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image)               | [Add(string path, IImage image)](https://reference.aspose.com/slides/el/net/aspose.slides.export.web/output/add#add_1)                               |

### **ImageCollection**
| Υπογραφή Μεθόδου                          | Αντικατάσταση Υπογραφής Μεθόδου               |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image)           | [AddImage(IImage image)](https://reference.aspose.com/slides/el/net/aspose.slides/imagecollection/addimage#addimage)                      |

### **ImageWrapperFactory**
| Υπογραφή Μεθόδου                                         | Αντικατάσταση Υπογραφής Μεθόδου                            |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image)           | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/el/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper)                        |

### **PPImage**
| Υπογραφή/Ιδιότητα                     | Αντικατάσταση Υπογραφής   |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage)   | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/el/net/aspose.slides/ppimage/replaceimage#replaceimage)            |
| Image SystemImage { get; }          | [IImage Image { get; }](https://reference.aspose.com/slides/el/net/aspose.slides/ppimage/image)                    |

### **PatternFormat**
| Υπογραφή Μεθόδου                                          | Αντικατάσταση Υπογραφής                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/el/net/aspose.slides/patternformat/gettile#gettile_1)         |
| Bitmap GetTileImage(Color styleColor)                     | [GetTile(Color styleColor)](https://reference.aspose.com/slides/el/net/aspose.slides/patternformat/gettile#gettile)                           |

### **IPatternFormatEffectiveData**
| Υπογραφή Μεθόδου                                          | Αντικατάσταση Υπογραφής                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/el/net/aspose.slides/ipatternformateffectivedata/gettileiimage)                    |

## **Υποστήριξη API για Graphics και PrinterSettings**

Η κλάση [Graphics] δεν υποστηρίζεται για εκδόσεις .NET6 και άνω που είναι πλατφόρμα‑αμετάβατες. Στο Aspose Slides, χρησιμοποιήστε τις μεθόδους απόδοσης εικόνας του Σύγχρονου API αντί του API που αποδίδει σε [Graphics]:
[ISlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/el/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/el/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/el/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Επιπλέον, το API που σχετίζεται με την εκτύπωση μέσω [PrinterSettings] δεν έχει άμεση αντικατάσταση στο Σύγχρονο API:
[IPresentation](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/print/#print_2)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Γιατί αφαιρέθηκε το [Graphics];**

Η υποστήριξη για το [Graphics] έχει χαρακτηριστεί ως παρωχημένη στο δημόσιο API για να ενοποιηθεί η εργασία με απόδοση και εικόνες, να αφαιρεθούν οι συνδέσεις με εξαρτήσεις ειδικές για πλατφόρμα, και να μεταβεί σε μια πλατφόρμα‑αμετάβατη προσέγγιση με το [IImage]. Χρησιμοποιήστε `GetImage` ή `GetImages` αντί για απόδοση σε [Graphics].

**Ποιο είναι το πρακτικό όφελος του [IImage] σε σύγκριση με το [Image]/[Bitmap];**

[IImage] ενοποιεί τη δουλειά με τόσο ραστικές όσο και διανυσματικές εικόνες, απλοποιεί την αποθήκευση σε διάφορες μορφές μέσω του [ImageFormat], μειώνει την εξάρτηση από το `System.Drawing`, και καθιστά τον κώδικα πιο φορητό μεταξύ περιβάλλοντων.

**Θα επηρεάσει το Σύγχρονο API την απόδοση της δημιουργίας μικρογραφιών;**

Η μετάβαση από το `GetThumbnail` στο `GetImage` δεν επηρεάζει αρνητικά τις συνθήκες: οι νέες μέθοδοι παρέχουν τις ίδιες δυνατότητες για παραγωγή εικόνων με επιλογές και μεγέθη, ενώ διατηρούν την υποστήριξη για επιλογές απόδοσης. Το συγκεκριμένο κέρδος ή η απώλεια εξαρτάται από το σενάριο, αλλά λειτουργικά οι αντικαταστάσεις είναι ισοδύναμες.