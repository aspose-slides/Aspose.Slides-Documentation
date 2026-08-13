---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις σε .NET
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
- υπόβαθρο
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
description: "Απλοποιήστε τη διαχείριση εικόνων σε PowerPoint και OpenDocument με το Aspose.Slides για .NET, βελτιώνοντας την απόδοση και αυτοματοποιώντας τη ροή εργασίας σας."
---
## **Εισαγωγή**

Οι εικόνες καθιστούν τις παρουσιάσεις πιο ελκυστικές και οπτικά ελκυστικές. Στο Microsoft PowerPoint, μπορείτε να εισάγετε εικόνες στις διαφάνειες από αρχεία, το διαδίκτυο ή άλλες πηγές. Με παρόμοιο τρόπο, το Aspose.Slides σας επιτρέπει να προσθέτετε εικόνες στις διαφάνειες παρουσίασης με διάφορους τρόπους.

{{% alert  title="Tip" color="info" %}} 
Το Aspose παρέχει δωρεάν μετατροπείς—[JPEG to PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG to PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που σας επιτρέπουν να δημιουργήσετε γρήγορα παρουσιάσεις από εικόνες. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Αν θέλετε να προσθέσετε μια εικόνα ως πλαίσιο εικόνας—ιδιαίτερα εάν σκοπεύετε να τη αλλάξετε μέγεθος, να εφαρμόσετε εφέ ή να χρησιμοποιήσετε άλλες τυπικές επιλογές μορφοποίησης—δείτε το [Picture Frame](/slides/el/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Μπορείτε να μετατρέψετε εικόνες από μια μορφή σε άλλη. Δείτε τις παρακάτω σελίδες: μετατρέψτε [image to JPG](https://products.aspose.com/slides/el/net/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/el/net/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/el/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/el/net/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/el/net/conversion/png-to-svg/), και [SVG to PNG](https://products.aspose.com/slides/el/net/conversion/svg-to-png/).
{{% /alert %}}

Το Aspose.Slides υποστηρίζει εικόνες σε δημοφιλείς μορφές όπως JPEG, PNG, BMP, GIF και άλλες. 

## **Προσθήκη Εικόνων Αποθηκευμένων Τοπικά στις Διαφάνειες**

Μπορείτε να προσθέσετε μία ή περισσότερες εικόνες που είναι αποθηκευμένες στον υπολογιστή σας σε μια διαφάνεια παρουσίασης. Ο παρακάτω κώδικας δείγμα C# δείχνει πώς να προσθέσετε μια εικόνα σε μια διαφάνεια:

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

## **Προσθήκη Εικόνων από το Διαδίκτυο σε Διαφάνειες**

Εάν η εικόνα που θέλετε να προσθέσετε σε μια διαφάνεια δεν είναι αποθηκευμένη στον υπολογιστή σας, μπορείτε να την προσθέσετε απευθείας από το διαδίκτυο. 

Ο παρακάτω κώδικας δείγμα C# δείχνει πώς να προσθέσετε μια εικόνα από το διαδίκτυο σε μια διαφάνεια:

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

## **Προσθήκη Εικόνων σε Master Διαφάνειας**

Ένας master διαφάνειας αποθηκεύει και ελέγχει πληροφορίες όπως το θέμα και η διάταξη για τις διαφάνειες που τον χρησιμοποιούν. Όταν προσθέτετε μια εικόνα σε έναν master διαφάνειας, η εικόνα εμφανίζεται σε κάθε διαφάνεια που βασίζεται σε αυτόν τον master. 

Ο παρακάτω κώδικας δείγμα C# δείχνει πώς να προσθέσετε μια εικόνα σε έναν master διαφάνειας:

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

## **Προσθήκη Εικόνων ως Υπόβαθρα Διαφάνειας**

Μπορείτε να χρησιμοποιήσετε μια εικόνα ως υπόβαθρο για μία ή περισσότερες διαφάνειες. Για λεπτομέρειες, δείτε *[Setting Images as Backgrounds for Slides](/slides/el/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Προσθήκη SVG σε Παρουσιάσεις**

Το περιεχόμενο SVG μπορεί να προστεθεί σε μια παρουσίαση χρησιμοποιώντας την κλάση [SvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/svgimage/). Το αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/) που προκύπτει μπορεί στη συνέχεια να προστεθεί στη συλλογή εικόνων της παρουσίασης και να χρησιμοποιηθεί για τη δημιουργία πλαισίου εικόνας.

Ο παρακάτω κώδικας C# παράδειγμα εισάγει μια ενσωματωμένη συμβολοσειρά SVG. Όλες οι εικόνες, τα στυλ και οι άλλοι πόροι που χρησιμοποιεί αυτό το SVG είναι ενσωματωμένοι απευθείας στο περιεχόμενο SVG.

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

Αρχεία SVG που εξάγονται από εργαλεία σχεδίασης, επεξεργαστές διαγραμμάτων, συστήματα εικονιδίων και διαδικτυακές αλυσίδες ενδέχεται να αναφέρονται σε πόρους που αποθηκεύονται εκτός του εγγράφου SVG. Για παράδειγμα, ένα SVG μπορεί να περιέχει σύνδεσμο εικόνας όπως `images/photo.png`, μια τιμή CSS `url(...)` ή μια διεύθυνση γραμματοσειράς.

Για να εισάγετε τέτοιο περιεχόμενο SVG, δημιουργήστε μια υλοποίηση του [IExternalResourceResolver](https://reference.aspose.com/slides/el/net/aspose.slides.import/iexternalresourceresolver/) και περάστε το, μαζί με μια βασική URI, σε έναν κατάλληλο κατασκευαστή `SvgImage`. Η βασική URI προσδιορίζει τη θέση του εγγράφου SVG και χρησιμοποιείται για την επίλυση σχετικών συνδέσμων.

Η διεπαφή [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/) παρέχει πρόσβαση σε πληροφορίες σχετικά με το εισαγόμενο SVG:

- `SvgContent` επιστρέφει το σήμανση SVG ως συμβολοσειρά.
- `SvgData` επιστρέφει το περιεχόμενο SVG ως πίνακα byte.
- `BaseUri` επιστρέφει τη βασική URI που χρησιμοποιείται για σχετικούς συνδέσμους.
- `ExternalResourceResolver` επιστρέφει τον επιλυτή που έχει οριστεί για την εικόνα SVG.

### **Υλοποίηση Εξωτερικού Επιδιόρθου Πόρων**

Ο επιλυτής διαθέτει δύο μεθόδους:

- [ResolveUri](https://reference.aspose.com/slides/el/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) συνδυάζει τη βασική URI και έναν σχετικό σύνδεσμο πόρου και επιστρέφει μια απόλυτη URI. Επιστρέψτε `null` όταν ο σύνδεσμος δεν μπορεί να επιλυθεί ή δεν επιτρέπεται.
- [GetEntity](https://reference.aspose.com/slides/el/net/aspose.slides.import/iexternalresourceresolver/getentity/) επιστρέφει ένα ρεύμα ανάγνωσης για μια απόλυτη URI πόρου. Επιστρέψτε `null` όταν ο πόρος λείπεται, είναι αποκλεισμένος ή μη διαθέσιμος. Ένα εναλλακτικό ρεύμα μπορεί επίσης να επιστραφεί όταν είναι κατάλληλο.

Ο παρακάτω επιλυτής φορτώνει συνδεδεμένους πόρους μόνο από έναν επιτρεπόμενο τοπικό φάκελο. Οι πόροι δικτύου και διαδρομές εκτός του επιτρεπόμενου φακέλου αποκλείονται. Επιστρέφεται μια προαιρετική εναλλακτική εικόνα για μη επιλυμένους συνδέσμους εικόνας.

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

        // Αυτός ο επιλυτής επιτρέπει σκόπιμα μόνο τοπικά αρχεία.
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

        // Χρησιμοποιήστε εναλλακτικό μόνο για πόρους εικόνας. Επιστρέφοντας ένα ρεύμα εικόνας
        // για μια ελλείπουσα γραμματοσειρά ή φύλλο στυλ δεν θα ήταν έγκυρο.
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

### **Επίλυση Συνδεδεμένων Πόρων Κατά τη Διαδικασία Εισαγωγής SVG**

Υποθέτουμε ότι το `assets/diagram.svg` περιέχει μια σχετική αναφορά όπως:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Ο παρακάτω κώδικας δείγμα C# περνά τη URI του αρχείου SVG ως τη βασική URI και παρέχει έναν προσαρμοσμένο επιλυτή. Ο επιλυτής μετατρέπει τον σχετικό σύνδεσμο εικόνας σε απόλυτη URI και επιστρέφει ένα ρεύμα που περιέχει τον συνδεδεμένο πόρο ενώ το Aspose.Slides επεξεργάζεται το SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// Το βασικό URI εκπροσωπεί τη θέση του εγγράφου SVG.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// Το ISvgImage εκθέτει το περιεχόμενο πηγής, τα δυαδικά δεδομένα, το βασικό URI και τον επιλυτή.
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

Η κλάση `SvgImage` παρέχει επίσης υπερφορτώσεις που δέχονται δεδομένα SVG ως πίνακα byte ή ως ρεύμα, μαζί με έναν εξωτερικό επιλυτή πόρων και μια βασική URI.

{{% alert title="Important" color="warning" %}}
Ο επιλυτής πόρων καθιστά τα εξωτερικά αρχεία διαθέσιμα ενώ το Aspose.Slides επεξεργάζεται και αποδίδει το SVG. Δεν τροποποιεί το αρχικό σήμανση SVG ούτε ενσωματώνει αυτόματα τους επιλυμένους πόρους σε αυτό. 

Όταν προστίθεται ένα `ISvgImage` στη συλλογή εικόνων της παρουσίασης, το αρχείο PPTX μπορεί να περιέχει τόσο την αρχική αναπαράσταση SVG όσο και μια εναλλακτική ραστερική εικόνα. Ένας συνδεδεμένος πόρος μπορεί να εμφανιστεί στην παραγόμενη εναλλακτική εικόνα, ενώ ένας σχετικός σύνδεσμος όπως `images/photo.png` παραμένει αμετάβλητος στο αποθηκευμένο SVG. Μια εφαρμογή που αποδίδει την εγγενή αναπαράσταση SVG μπορεί επομένως να παραλείπει το συνδεδεμένο περιεχόμενο όταν ο αρχικός εξωτερικός πόρος δεν είναι διαθέσιμος.
{{% /alert %}}

### **Δημιουργία Φορητής Εικόνας SVG**

Για να δημιουργήσετε μια εικόνα SVG που δεν εξαρτάται από εξωτερικά αρχεία, κάντε το SVG αυτόνομο πριν δημιουργήσετε το `SvgImage`. Για παράδειγμα, αντικαταστήστε τα συνδεδεμένα URL εικόνων με URI τύπου `data:` που περιέχουν τα δεδομένα της εικόνας:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Αφού όλα τα απαιτούμενα αρχεία ενσωματωθούν στο περιεχόμενο SVG, δημιουργήστε το `SvgImage`, προσθέστε το στη συλλογή εικόνων της παρουσίασης και τοποθετήστε το σε πλαίσιο εικόνας όπως φαίνεται στο προηγούμενο παράδειγμα.

### **Διαχείριση Ελλειπόντων ή Αποκλεισμένων Πόρων**

Επιστρέψτε `null` από το `ResolveUri` όταν μια URI πόρου είναι άκυρη, απαγορευμένη ή δεν μπορεί να επιλυθεί. Επιστρέψτε `null` από το `GetEntity` όταν ο πόρος δεν μπορεί να διαβαστεί. Το Aspose.Slides συνεχίζει την επεξεργασία του SVG χωρίς αυτόν τον πόρο όταν είναι δυνατόν.

Ένα εναλλακτικό ρεύμα μπορεί να επιστραφεί για έναν ελλιπές πόρο, αλλά το περιεχόμενό του πρέπει να είναι συμβατό με τον ζητούμενο τύπο πόρου. Για παράδειγμα, επιστρέψτε ρεύμα εικόνας μόνο για μια ελλιπή εικόνα, όχι για γραμματοσειρά ή φύλλο στυλ.

{{% alert title="Security" color="warning" %}}
Μην επιλύετε αυθαίρετες διαδρομές αρχείων ή απεριόριστες διευθύνσεις URL δικτύου από μη έμπιστα αρχεία SVG. Περιορίστε τα επιτρεπόμενα σχήματα, καταλόγους και κεντρικούς υπολογιστές. Για πόρους δικτύου, εφαρμόστε επίσης χρονικά όρια σύνδεσης, όρια μεγέθους απάντησης και επικύρωση περιεχομένου.
{{% /alert %}}

## **Μετατροπή SVG σε Σύνολο Σχημάτων**
Το Aspose.Slides μπορεί να μετατρέψει ένα SVG σε σύνολο σχημάτων, παρόμοια με την αντίστοιχη λειτουργία στο PowerPoint:

![Μενού Αναδυόμενο PowerPoint](img_01_01.png)

Αυτή η λειτουργία παρέχεται από μια υπερφόρτωση της μεθόδου [AddGroupShape](https://reference.aspose.com/slides/el/net/aspose.slides.ishapecollection/addgroupshape/methods/1) του διεπαφής [IShapeCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection) που δέχεται ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage) ως πρώτο όρισμα.

Ο παρακάτω κώδικας δείγμα C# δείχνει πώς να χρησιμοποιήσετε αυτή τη μέθοδο για να μετατρέψετε ένα αρχείο SVG σε σύνολο σχημάτων:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Όνομα αρχείου πηγής SVG
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
Το Aspose.Slides για .NET σας επιτρέπει να δημιουργήσετε εικόνες EMF από φύλλα εργασίας Excel με το Aspose.Cells και να τις προσθέσετε σε διαφάνειες παρουσίασης.

Ο παρακάτω κώδικας δείγμα C# δείχνει πώς να το κάνετε αυτό:

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

Το Aspose.Slides σας επιτρέπει να αντικαταστήσετε εικόνες αποθηκευμένες στη συλλογή εικόνων μιας παρουσίασης, συμπεριλαμβανομένων των εικόνων που χρησιμοποιούνται από σχήματα διαφάνειας. Αυτό το τμήμα περιγράφει διάφορους τρόπους ενημέρωσης των εικόνων στη συλλογή. Μπορείτε να αντικαταστήσετε μια εικόνα χρησιμοποιώντας ακατέργαστα δεδομένα byte, μια παρουσία της κλάσης [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/), ή μια άλλη εικόνα που υπάρχει ήδη στη συλλογή.

Ακολουθήστε τα παρακάτω βήματα:

1. Φορτώστε το αρχείο παρουσίασης που περιέχει εικόνες χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Φορτώστε μια νέα εικόνα από αρχείο σε έναν πίνακα byte.
1. Αντικαταστήστε την εικόνα-στόχο με τη νέα εικόνα χρησιμοποιώντας τον πίνακα byte.
1. Στη δεύτερη προσέγγιση, φορτώστε την εικόνα σε ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) και αντικαταστήστε την εικόνα-στόχο με αυτό το αντικείμενο.
1. Στην τρίτη προσέγγιση, αντικαταστήστε την εικόνα-στόχο με μια εικόνα που υπάρχει ήδη στη συλλογή εικόνων της παρουσίασης.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία ενός αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

{{% alert title="Info" color="info" %}}
Με τον δωρεάν μετατροπέα [Text to GIF](https://products.aspose.app/slides/el/text-to-gif) του Aspose, μπορείτε εύκολα να δημιουργήσετε κινούμενα κείμενα και GIF από κείμενο. 
{{% /alert %}}

## **FAQ**

**Παραμένει η αρχική ανάλυση της εικόνας ανέπαφη μετά την εισαγωγή;**

Ναι. Τα αρχικά pixel διατηρούνται, αλλά η τελική εμφάνιση εξαρτάται από το πώς κλιμακώνεται το [picture](/slides/el/net/picture-frame/) στη διαφάνεια και τυχόν συμπίεση που εφαρμόζεται κατά την αποθήκευση.

**Ποιος είναι ο καλύτερος τρόπος να αντικαταστήσω το ίδιο λογότυπο σε δεκάδες διαφάνειες ταυτόχρονα;**

Τοποθετήστε το λογότυπο στη master διαφάνειας ή σε ένα layout και αντικαταστήστε το στη συλλογή εικόνων της παρουσίασης—οι ενημερώσεις θα εξαπλωθούν σε όλα τα στοιχεία που χρησιμοποιούν αυτόν τον πόρο.

**Μπορεί το εισαχθέν SVG να μετατραπεί σε επεξεργάσιμα σχήματα;**

Ναι. Μπορείτε να μετατρέψετε ένα SVG σε ομάδα σχημάτων, μετά από την οποία τα μεμονωμένα μέρη γίνονται επεξεργάσιμα με τις τυπικές ιδιότητες σχήματος.

**Πώς μπορώ να ορίσω μια εικόνα ως υπόβαθρο για πολλαπλές διαφάνειες ταυτόχρονα;**

[Αναθέστε την εικόνα ως υπόβαθρο](/slides/el/net/presentation-background/) στη master διαφάνειας ή στο σχετικό layout—οποιεσδήποτε διαφάνειες χρησιμοποιούν αυτόν τον master/layout θα κληρονομήσουν το υπόβαθρο.

**Πώς αποτρέπω μια παρουσίαση από το να γίνει πολύ μεγάλη λόγω πολλών εικόνων;**

Επαναχρησιμοποιήστε έναν ενιαίο πόρο εικόνας αντί για διπλότυπα, επιλέξτε λογικές αναλύσεις, εφαρμόστε συμπίεση κατά την αποθήκευση και κρατήστε τα επαναλαμβανόμενα γραφικά στη master όπου είναι κατάλληλο.