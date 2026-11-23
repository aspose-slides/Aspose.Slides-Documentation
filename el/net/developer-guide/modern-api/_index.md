---
title: Βελτιώστε την Επεξεργασία Εικόνας με το Μοντέρνο API
linktitle: Μοντέρνο API
type: docs
weight: 234
url: /el/net/modern-api/
keywords:
- System.Drawing
- μοντέρνο API
- σχεδίαση
- μικρογραφία διαφάνειας
- διαφάνεια σε εικόνα
- μικρογραφία σχήματος
- σχήμα σε εικόνα
- μικρογραφία παρουσίασης
- παρουσίαση σε εικόνες
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- .NET
- C#
- Aspose.Slides
description: "Εξοπλίστε την επεξεργασία εικόνων διαφανειών με την αντικατάσταση των παρωχημένων API εικόνας από το .NET Μοντέρνο API για απρόσκοπτη αυτοματοποίηση PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Ιστορικά, το Aspose Slides εξαρτάται από το System.Drawing και στο δημόσιο API περιλαμβάνει τις ακόλουθες κλάσεις από αυτό:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Από την έκδοση 24.4, αυτό το δημόσιο API έχει χαρακτηριστεί ως παρωχημένο.

Καθώς η υποστήριξη του System.Drawing στις εκδόσεις .NET6 και άνω έχει αφαιρεθεί για μη‑Windows εκδόσεις ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), το Slides υλοποίησε μια προσέγγιση δύο πακέτων:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – υποστήριξη για .NET6+ σε Windows, .NETStandard για Windows/Linux/MacOS, .NETFramework 2+ (Windows).  
  - εξαρτάται από το [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – έκδοση για Windows/Linux/MacOS χωρίς εξαρτήσεις.

Το πρόβλημα του [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) είναι ότι υλοποιεί τη δική του έκδοση του System.Drawing στην ίδια ονομαστική περιοχή (για υποστήριξη της συμβατότητας με το δημόσιο API). Έτσι, όταν χρησιμοποιούνται ταυτόχρονα Aspose.Slides.NET6.CrossPlatform και System.Drawing από .NET Framework ή το πακέτο System.Drawing.Common, προκύπτει σύγκρουση ονομάτων εκτός εάν χρησιμοποιηθεί ψευδώνυμο.

Για να απαλλαγούμε από τις εξαρτήσεις στο System.Drawing στο κύριο πακέτο Aspose.Slides.NET, προσθέσαμε το λεγόμενο «Μοντέρνο API» – δηλαδή το API που πρέπει να χρησιμοποιείται αντί του παρωχημένου, του οποίου οι υπογραφές περιέχουν εξαρτήσεις από τους τύπους του System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) και [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). Οι [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) και [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) χαρακτηρίζονται ως παρωχημένες και η υποστήριξή τους έχει αφαιρεθεί από το δημόσιο Slides API.

Στις τρέχουσες εκδόσεις, θεωρείτε το δημόσιο API που εξαρτάται από το System.Drawing ως κληρονομικό/παρωχημένο. Χρησιμοποιήστε το Μοντέρνο API για νέο κώδικα και κατά τη μεταφορά των υπάρχουσων ροών επεξεργασίας εικόνων.

## **Μοντέρνο API**

Προστέθηκαν οι παρακάτω κλάσεις και enum στο δημόσιο API:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) – αντιπροσωπεύει την ραστών ή διανυσματική εικόνα.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) – αντιπροσωπεύει τη μορφή αρχείου της εικόνας.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) – μεθόδους για δημιουργία και εργασία με τη διεπαφή [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).

Σημειώστε ότι το [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) είναι disposable (υλοποιεί τη διεπαφή [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) και η χρήση του θα πρέπει να τυλίγεται σε using ή να διαρρέεται με άλλο βολικό τρόπο).

Χρησιμοποιήστε `GetImage` για απόδοση μιας μίας διαφάνειας ή σχήματος. Χρησιμοποιήστε `GetImages` για απόδοση πολλών διαφανειών παρουσίασης. Χρησιμοποιήστε τις μεθόδους του [Images](https://reference.aspose.com/slides/net/aspose.slides/images/) για φόρτωση εικόνων, `AddImage` με [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) για προσθήκη τους σε παρουσίαση, και `ReplaceImage` με [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) για ενημέρωση υπάρχουσας εικόνας παρουσίασης.

Ένα τυπικό σενάριο χρήσης του νέου API μπορεί να έχει ως εξής:

``` csharp
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // Δημιουργήστε μια απορριπτέα παρουσία του IImage από το αρχείο στον δίσκο.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // Δημιουργήστε μια εικόνα PowerPoint προσθέτοντας μια παρουσία του IImage στις εικόνες της παρουσίασης.
        ppImage = pres.Images.AddImage(image);
    }

    // Προσθέστε ένα σχήμα εικόνας στη διαφάνεια #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // Αποκτήστε μια παρουσία του IImage που αντιπροσωπεύει τη διαφάνεια #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // Αποθηκεύστε την εικόνα στον δίσκο.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Αντικατάσταση παλαιού κώδικα με το Μοντέρνο API**

Για ευκολία μετάβασης, η διεπαφή του νέου [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) επαναλαμβάνει τις ξεχωριστές υπογραφές των κλάσεων [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) και [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). Γενικά, αρκεί να αντικαταστήσετε την κλήση στην παλιά μέθοδο που χρησιμοποιεί System.Drawing με τη νέα.

### **Λήψη μικρογραφίας διαφάνειας**

Παλιό/παρωχημένο API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Μοντέρνο API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Λήψη μικρογραφίας σχήματος**

Παλιό/παρωχημένο API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Μοντέρνο API:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Λήψη μικρογραφίας παρουσίασης**

Παλιό/παρωχημένο API:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Μοντέρνο API:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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
using System.Drawing;
using Aspose.Slides;

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

Μοντέρνο API:

``` csharp
using Aspose.Slides;

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
## **Παρωχημένες Μέθοδοι/Ιδιότητες και η Αντικατάστασή τους στο Μοντέρνο API**

### **Presentation**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|-------------------|----------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Shape**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|-------------------|----------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|-------------------|----------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|-------------------|----------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|-------------------|----------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|-------------------|----------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Υπογραφή/Ιδιότητα | Υπογραφή Μεθόδου Αντικατάστασης |
|-------------------|-----------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|-------------------|----------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Υπογραφή Μεθόδου | Υπογραφή Μεθόδου Αντικατάστασης |
|-------------------|----------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Υποστήριξη API για Graphics και PrinterSettings**

Η κλάση [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) δεν υποστηρίζεται για τις πλατφόρμες‑διασταυρούμενες εκδόσεις του .NET6 και άνω. Στο Aspose Slides, χρησιμοποιήστε τις μεθόδους απόδοσης εικόνας του Μοντέρνου API αντί του API που αποδίδει σε [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Επίσης, το API που σχετίζεται με εκτύπωση μέσω [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) δεν έχει άμεση αντικατάσταση στο Μοντέρνο API:

[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **Συχνές Ερωτήσεις**

### Γιατί απομακρύνθηκε το [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics);

Η υποστήριξη για το [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) θεωρείται παρωχημένη στο δημόσιο API για να ενοποιηθεί η εργασία με απόδοση και εικόνες, να εξαλειφθούν οι δεσμοί σε εξαρτήσεις ειδικές για πλατφόρμα και να μεταβούμε σε μια διασυνοριακή προσέγγιση με το [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Χρησιμοποιήστε `GetImage` ή `GetImages` αντί της απόδοσης σε [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

### Ποιο είναι το πρακτικό όφελος του [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) σε σχέση με το [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap);

Το [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) ενοποιεί την εργασία με ραστών και διανυσματικές εικόνες, απλοποιεί την αποθήκευση σε διάφορες μορφές μέσω του [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), μειώνει την εξάρτηση από το `System.Drawing` και κάνει τον κώδικα πιο φορητό μεταξύ περιβαλλόντων.

### Θα επηρεάσει το Μοντέρνο API την απόδοση της δημιουργίας μικρογραφιών;

Η μετάβαση από `GetThumbnail` σε `GetImage` δεν επιδεινώνει τα σενάρια: οι νέες μέθοδοι παρέχουν τις ίδιες δυνατότητες παραγωγής εικόνων με επιλογές και μεγέθη, διατηρώντας την υποστήριξη των επιλογών απόδοσης. Το συγκεκριμένο κέρδος ή η πτώση εξαρτώνται από το σενάριο, αλλά λειτουργικά οι αντικαταστάσεις είναι ισοδύναμες.