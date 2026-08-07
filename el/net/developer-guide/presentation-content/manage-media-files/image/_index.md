---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις στο .NET
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/net/image/
keywords:
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- προσθήκη bitmap
- αντικατάσταση εικόνας
- αντικατάσταση φωτογραφίας
- από το web
- φόντο
- προσθήκη PNG
- προσθήκη JPG
- προσθήκη SVG
- εξωτερικοί πόροι SVG
- επιλυτής SVG
- συνδεδεμένες εικόνες SVG
- γραμματοσειρές SVG
- προσθήκη EMF
- προσθήκη WMF
- προσθήκη TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Απλοποιήστε τη διαχείριση εικόνων στο PowerPoint και το OpenDocument με το Aspose.Slides για .NET, βελτιώνοντας την απόδοση και αυτοματοποιώντας τη ροή εργασίας σας."
---
## **Εισαγωγή**

Οι εικόνες κάνουν τις παρουσιάσεις πιο ελκυστικές και οπτικά εντυπωσιακές. Στο Microsoft PowerPoint, μπορείτε να εισάγετε εικόνες στις διαφάνειες από αρχεία, το διαδίκτυο ή άλλες πηγές. Ανάλογα, το Aspose.Slides σας επιτρέπει να προσθέτετε εικόνες στις διαφάνειες παρουσίασης με διάφορους τρόπους.

{{% alert  title="Συμβουλή" color="primary" %}} 
Η Aspose παρέχει δωρεάν μετατροπείς—[JPEG σε PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG σε PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που σας επιτρέπουν να δημιουργείτε γρήγορα παρουσιάσεις από εικόνες. 
{{% /alert %}} 

{{% alert title="Πληροφορίες" color="info" %}}
Αν θέλετε να προσθέσετε μια εικόνα ως πλαίσιο εικόνας—ιδιαίτερα αν σκοπεύετε να την αλλάξετε μέγεθος, να εφαρμόσετε εφέ ή να χρησιμοποιήσετε άλλες τυπικές επιλογές μορφοποίησης—δείτε [Picture Frame](/slides/el/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Σημείωση" color="warning" %}}
Μπορείτε να μετατρέψετε εικόνες από τη μία μορφή στην άλλη. Δείτε τις παρακάτω σελίδες: μετατροπή [εικόνα σε JPG](https://products.aspose.com/slides/el/net/conversion/image-to-jpg/), [JPG σε εικόνα](https://products.aspose.com/slides/el/net/conversion/jpg-to-image/), [JPG σε PNG](https://products.aspose.com/slides/el/net/conversion/jpg-to-png/), [PNG σε JPG](https://products.aspose.com/slides/el/net/conversion/png-to-jpg/), [PNG σε SVG](https://products.aspose.com/slides/el/net/conversion/png-to-svg/), και [SVG σε PNG](https://products.aspose.com/slides/el/net/conversion/svg-to-png/).
{{% /alert %}}

Η Aspose.Slides υποστηρίζει εικόνες σε δημοφιλείς μορφές όπως JPEG, PNG, BMP, GIF και άλλες. 

## **Προσθήκη Εικόνων που Αποθηκεύονται Τοπικά σε Διαφάνειες**

Μπορείτε να προσθέσετε μία ή περισσότερες εικόνες που αποθηκεύονται στον υπολογιστή σας σε μια διαφάνεια παρουσίασης. Ο παρακάτω κώδικας C# δείχνει πώς να προσθέσετε μια εικόνα σε μια διαφάνεια:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Προσθήκη Εικόνων από τον Ιστό σε Διαφάνειες**

Αν η εικόνα που θέλετε να προσθέσετε σε μια διαφάνεια δεν είναι αποθηκευμένη στον υπολογιστή σας, μπορείτε να την προσθέσετε απευθείας από το διαδίκτυο. 

Ο παρακάτω κώδικας C# δείχνει πώς να προσθέσετε μια εικόνα από το διαδίκτυο σε μια διαφάνεια:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Προσθήκη Εικόνων σε Κυρίως Διαφάνειες**

Ένας κύριος διαφάνειας (slide master) αποθηκεύει και ελέγχει πληροφορίες όπως το θέμα και η διάταξη για τις διαφάνειες που τον χρησιμοποιούν. Όταν προσθέτετε μια εικόνα σε κύριο διαφάνειας, η εικόνα εμφανίζεται σε κάθε διαφάνεια που βασίζεται σε αυτόν τον κύριο. 

Ο παρακάτω κώδικας C# δείχνει πώς να προσθέσετε μια εικόνα σε κύριο διαφάνειας:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Προσθήκη Εικόνων ως Φόντο Διαφάνειας**

Μπορείτε να χρησιμοποιήσετε μια εικόνα ως φόντο για μία ή περισσότερες διαφάνειες. Για λεπτομέρειες, δείτε *[Ορισμός Εικόνων ως Φόντο για Διαφάνειες](/slides/el/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Προσθήκη SVG σε Παρουσιάσεις**

Το περιεχόμενο SVG μπορεί να προστεθεί σε μια παρουσίαση χρησιμοποιώντας την κλάση [SvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/svgimage/). Το παραγόμενο αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/) μπορεί στη συνέχεια να προστεθεί στη συλλογή εικόνων της παρουσίασης και να χρησιμοποιηθεί για τη δημιουργία ενός πλαισίου εικόνας.

Ο παρακάτω κώδικας C# εισάγει μια αυτόνομη συμβολοσειρά SVG. Όλες οι εικόνες, τα στυλ και οι άλλοι πόροι που χρησιμοποιεί αυτό το SVG είναι ενσωματωμένοι απευθείας στο περιεχόμενο του SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **Εισαγωγή Περιεχομένου SVG με Εξωτερικούς Πόρους**

Αρχεία SVG που εξάγονται από εργαλεία σχεδίασης, επεξεργαστές διαγραμμάτων, συστήματα εικονιδίων και διαδικτυακές αγωγές μπορεί να αναφέρονται σε πόρους που αποθηκεύονται εκτός του εγγράφου SVG. Για παράδειγμα, ένα SVG μπορεί να περιέχει σύνδεσμο σε εικόνα όπως `images/photo.png`, μια τιμή CSS `url(...)`, ή μια διεύθυνση URL γραμματοσειράς.

Για να εισάγετε τέτοιο περιεχόμενο SVG, δημιουργήστε μια υλοποίηση του [IExternalResourceResolver](https://reference.aspose.com/slides/el/net/aspose.slides.import/iexternalresourceresolver/) και περάστε την, μαζί με μια βασική URI, σε έναν κατάλληλο κατασκευαστή `SvgImage`. Η βασική URI ταυτοποιεί τη θέση του εγγράφου SVG και χρησιμοποιείται για την επίλυση σχετικών συνδέσμων.

Η διεπαφή [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/) παρέχει πρόσβαση σε πληροφορίες σχετικά με το εισαχθέν SVG:

- `SvgContent` επιστρέφει το SVG markup ως συμβολοσειρά.
- `SvgData` επιστρέφει το περιεχόμενο SVG ως πίνακα byte.
- `BaseUri` επιστρέφει τη βασική URI που χρησιμοποιείται για σχετικούς συνδέσμους.
- `ExternalResourceResolver` επιστρέφει τον επιλυτή που έχει ανατεθεί στην εικόνα SVG.

### **Υλοποίηση Εξωτερικού Επίλυσης Πόρων**

Ο επιλυτής διαθέτει δύο μεθόδους:

- [ResolveUri](https://reference.aspose.com/slides/el/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) συνδυάζει τη βασική URI και έναν σχετικό σύνδεσμο πόρου και επιστρέφει μια απόλυτη URI. Επιστρέψτε `null` όταν ο σύνδεσμος δεν μπορεί να επιλυθεί ή δεν επιτρέπεται.
- [GetEntity](https://reference.aspose.com/slides/el/net/aspose.slides.import/iexternalresourceresolver/getentity/) επιστρέφει ένα ρεύμα ανάγνωσης για μια απόλυτη URI πόρου. Επιστρέψτε `null` όταν ο πόρος λείπει, είναι αποκλεισμένος ή μη διαθέσιμος. Ένα εναλλακτικό ρεύμα μπορεί επίσης να επιστραφεί όταν είναι κατάλληλο.

Ο παρακάτω επιλυτής φορτώνει συνδεδεμένους πόρους μόνο από έναν επιτρεπόμενο τοπικό φάκελο. Οι δικτυακοί πόροι και οι διαδρομές εκτός του επιτρεπόμενου φακέλου μπλοκάρονται. Μια προαιρετική εναλλακτική εικόνα επιστρέφεται για μη επιλυμένους συνδέσμους εικόνων.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // Αυτός ο επιλυτής επιτρέπει εκ προθέσεως μόνο τοπικά αρχεία.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // Χρησιμοποιήστε εναλλακτικό μόνο για πόρους εικόνας. Η επιστροφή ρεύματος εικόνας
        // για ελλείπουσα γραμματοσειρά ή φύλλο στυλ δεν είναι έγκυρη.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **Επίλυση Συνδεδεμένων Πόρων Κατά τη Διάρκεια Εισαγωγής SVG**

Υποθέστε ότι το `assets/diagram.svg` περιέχει ένα σχετικό αναφορά όπως:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Ο παρακάτω κώδικας C# περνά τη URI του αρχείου SVG ως τη βασική URI και παρέχει έναν προσαρμοσμένο επιλυτή. Ο επιλυτής μετατρέπει το σχετικό σύνδεσμο εικόνας σε απόλυτη URI και επιστρέφει ένα ρεύμα που περιέχει τον συνδεδεμένο πόρο ενώ το Aspose.Slides επεξεργάζεται το SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// Η βασική URI αντιπροσωπεύει τη θέση του εγγράφου SVG.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

Η κλάση `SvgImage` παρέχει επίσης υπερφορτώσεις που δέχονται δεδομένα SVG ως πίνακα byte ή ρεύμα, μαζί με έναν εξωτερικό επιλυτή πόρων και μια βασική URI.

{{% alert title="Σημαντικό" color="warning" %}}
Ο επιλυτής πόρων κάνει τους εξωτερικούς πόρους διαθέσιμους ενώ το Aspose.Slides επεξεργάζεται και αποδίδει το SVG. Δεν τροποποιεί το αρχικό SVG markup ούτε ενσωματώνει αυτόματα τους επιλυμένους πόρους σε αυτό.
Όταν ένα `ISvgImage` προστίθεται στη συλλογή εικόνων της παρουσίασης, το αρχείο PPTX μπορεί να περιέχει τόσο την αρχική SVG αναπαράσταση όσο και μια εναλλακτική ραστερ εικόνα. Ένας συνδεδεμένος πόρος μπορεί να εμφανίζεται στην παραγόμενη εναλλακτική εικόνα ενώ ένας σχετικός σύνδεσμος όπως `images/photo.png` παραμένει αμετάβλητος στο αποθηκευμένο SVG. Μια εφαρμογή που αποδίδει τη φυσική SVG αναπαράσταση μπορεί επομένως να παραλείψει το συνδεδεμένο περιεχόμενο όταν ο αρχικός εξωτερικός πόρος δεν είναι διαθέσιμος.
{{% /alert %}}

### **Δημιουργία Φορητής SVG Εικόνας**

Για να δημιουργήσετε μια SVG εικόνα που δεν εξαρτάται από εξωτερικά αρχεία, κάντε το SVG αυτόνομο πριν δημιουργήσετε το `SvgImage`. Για παράδειγμα, αντικαταστήστε τα συνδεδεμένα URL εικόνων με URIs `data:` που περιέχουν τα δεδομένα της εικόνας:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Μετά την ενσωμάτωση όλων των απαιτούμενων πόρων στο περιεχόμενο SVG, δημιουργήστε το `SvgImage`, προσθέστε το στη συλλογή εικόνων της παρουσίασης και τοποθετήστε το σε πλαίσιο εικόνας όπως φαίνεται στο προηγούμενο παράδειγμα.

### **Διαχείριση Ελλιπών ή Φραγμένων Πόρων**

Επιστρέψτε `null` από το `ResolveUri` όταν μια URI πόρου είναι άκυρη, απαγορευμένη ή δεν μπορεί να επιλυθεί. Επιστρέψτε `null` από το `GetEntity` όταν ο πόρος δεν μπορεί να διαβαστεί. Το Aspose.Slides συνεχίζει την επεξεργασία του SVG χωρίς αυτόν τον πόρο όταν είναι δυνατό.

Ένα εναλλακτικό ρεύμα μπορεί να επιστραφεί για έναν ελλιπές πόρο, αλλά το περιεχόμενό του πρέπει να είναι συμβατό με τον απαιτούμενο τύπο πόρου. Για παράδειγμα, επιστρέψτε ρεύμα εικόνας μόνο για ελλιπή εικόνα, όχι για γραμματοσειρά ή φύλλο στυλ.

{{% alert title="Ασφάλεια" color="warning" %}}
Μην επιλύετε αυθαίρετες διαδρομές αρχείων ή απεριόριστες διευθύνσεις URL δικτύου από μη αξιόπιστα αρχεία SVG. Περιορίστε τα επιτρεπόμενα σχήματα, φακέλους και κέντρους. Για δικτυακούς πόρους, εφαρμόστε επίσης χρονικά όρια σύνδεσης, όρια μεγέθους απάντησης και επικύρωση περιεχομένου.
{{% /alert %}}

## **Μετατροπή SVG σε Σύνολο Σχημάτων**
Aspose.Slides μπορεί να μετατρέψει ένα SVG σε σύνολο σχημάτων, παρόμοιο με τη σχετική λειτουργία στο PowerPoint:

![Μενού Αναδυόμενων PowerPoint](img_01_01.png)

Αυτή η λειτουργία παρέχεται από μια υπερφόρτωση της μεθόδου [AddGroupShape](https://reference.aspose.com/slides/el/net/aspose.slides.ishapecollection/addgroupshape/methods/1) του interface [IShapeCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection) που δέχεται ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage) ως πρώτο όρισμα.

Ο παρακάτω κώδικας C# δείχνει πώς να χρησιμοποιήσετε αυτή τη μέθοδο για να μετατρέψετε ένα αρχείο SVG σε σύνολο σχημάτων:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Όνομα αρχείου SVG
string svgFileName = "sample.svg";

// Όνομα αρχείου εξόδου παρουσίασης
string outPptxPath = "presentation.pptx";

// Δημιουργία νέας παρουσίασης
using (IPresentation presentation = new Presentation())
{
    // Ανάγνωση περιεχομένου αρχείου SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Δημιουργία αντικειμένου SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Λήψη μεγέθους διαφάνειας
    SizeF slideSize = presentation.SlideSize.Size;

    // Μετατροπή της εικόνας SVG σε ομάδα σχημάτων και κλιμάκωση στο μέγεθος της διαφάνειας
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Αποθήκευση παρουσίασης σε μορφή PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Προσθήκη Εικόνων ως EMF σε Διαφάνειες**
Το Aspose.Slides για .NET σας επιτρέπει να δημιουργείτε εικόνες EMF από φύλλα εργασίας Excel με το Aspose.Cells και να τις προσθέτετε σε διαφάνειες παρουσίασης.

Ο παρακάτω κώδικας C# δείχνει πώς να το κάνετε:

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // Αποθήκευση του βιβλίου εργασίας σε ροή
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Αντικατάσταση Εικόνων στη Συλλογή Εικόνων**

Το Aspose.Slides σάς επιτρέπει να αντικαθιστάτε εικόνες που αποθηκεύονται στη συλλογή εικόνων μιας παρουσίασης, συμπεριλαμβανομένων των εικόνων που χρησιμοποιούνται από σχήματα διαφάνειας. Αυτή η ενότητα περιγράφει αρκετούς τρόπους ενημέρωσης των εικόνων στη συλλογή. Μπορείτε να αντικαταστήσετε μια εικόνα χρησιμοποιώντας ακατέργαστα δεδομένα byte, μια παρουσία [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) ή μια άλλη εικόνα που υπάρχει ήδη στη συλλογή.

Ακολουθήστε τα παρακάτω βήματα:

1. Φορτώστε το αρχείο παρουσίασης που περιέχει εικόνες χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Φορτώστε μια νέα εικόνα από αρχείο σε έναν πίνακα byte.
3. Αντικαταστήστε την επιλεγμένη εικόνα με τη νέα εικόνα χρησιμοποιώντας τον πίνακα byte.
4. Στη δεύτερη προσέγγιση, φορτώστε την εικόνα σε αντικείμενο [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) και αντικαταστήστε την επιλεγμένη εικόνα με αυτό το αντικείμενο.
5. Στην τρίτη προσέγγιση, αντικαταστήστε την επιλεγμένη εικόνα με μια εικόνα που υπάρχει ήδη στη συλλογή εικόνων της παρουσίασης.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using Presentation presentation = new Presentation("sample.pptx");

// Ο πρώτος τρόπος.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Ο δεύτερος τρόπος.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Ο τρίτος τρόπος.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Αποθήκευση της παρουσίασης σε αρχείο.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Πληροφορίες" color="info" %}}
Με τον δωρεάν μετατροπέα Aspose [Text to GIF](https://products.aspose.app/slides/el/text-to-gif) μπορείτε εύκολα να ανιματίσετε κείμενο και να δημιουργήσετε GIF από κείμενο. 
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Μένει η αρχική ανάλυση της εικόνας αμετάβλητη μετά την εισαγωγή;**

Ναι. Τα αρχικά pixel διατηρούνται, αλλά η τελική εμφάνιση εξαρτάται από το πώς η [picture](/slides/el/net/picture-frame/) κλιμακώνεται στη διαφάνεια και τυχόν συμπίεση που εφαρμόζεται κατά την αποθήκευση.

**Ποιος είναι ο καλύτερος τρόπος να αντικαταστήσω το ίδιο λογότυπο σε δεκάδες διαφάνειες ταυτόχρονα;**

Τοποθετήστε το λογότυπο στον κύριο διαφάνειας ή σε μια διάταξη και αντικαταστήστε το στη συλλογή εικόνων της παρουσίασης—οι αλλαγές θα επεκταθούν σε όλα τα στοιχεία που χρησιμοποιούν αυτόν τον πόρο.

**Μπορεί ένα εισακτέο SVG να μετατραπεί σε επεξεργάσιμα σχήματα;**

Ναι. Μπορείτε να μετατρέψετε ένα SVG σε ομάδα σχημάτων, μετά το οποίο τα μεμονωμένα μέρη γίνονται επεξεργάσιμα με τις τυπικές ιδιότητες σχήματος.

**Πώς μπορώ να ορίσω μια εικόνα ως φόντο για πολλαπλές διαφάνειες ταυτόχρονα;**

[Αναθέστε την εικόνα ως φόντο](/slides/el/net/presentation-background/) στον κύριο διαφάνειας ή στη σχετική διάταξη—όλες οι διαφάνειες που χρησιμοποιούν αυτόν τον κύριο/διάταξη θα κληρονομήσουν το φόντο.

**Πώς μπορώ να αποτρέψω μια παρουσίαση να γίνει πολύ μεγάλη εξαιτίας πολλών εικόνων;**

Ξαναχρησιμοποιήστε έναν ενιαίο πόρο εικόνας αντί για διπλότυπα, επιλέξτε λογικές αναλύσεις, εφαρμόστε συμπίεση κατά την αποθήκευση και κρατήστε τα επαναλαμβανόμενα γραφικά στον κύριο όπου είναι δυνατόν.