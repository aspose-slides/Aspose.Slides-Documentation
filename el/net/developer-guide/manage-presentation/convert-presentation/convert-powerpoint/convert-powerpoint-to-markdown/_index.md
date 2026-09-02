---
title: "Μετατροπή Παρουσιάσεων PowerPoint σε Markdown στο .NET"
linktitle: "PowerPoint σε Markdown"
type: docs
weight: 140
url: /el/net/convert-powerpoint-to-markdown/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε MD
- παρουσίαση σε MD
- διαφάνεια σε MD
- PPT σε MD
- PPTX σε MD
- αποθήκευση PowerPoint ως Markdown
- αποθήκευση παρουσίασης ως Markdown
- αποθήκευση διαφάνειας ως Markdown
- αποθήκευση PPT ως MD
- αποθήκευση PPTX ως MD
- εξαγωγή PPT σε MD
- εξαγωγή PPTX σε MD
- εξαγωγή εικόνων Markdown
- σύνδεσμοι εικόνων CDN
- PowerPoint
- παρουσίαση
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PPT και PPTX σε Markdown στο .NET και ελέγξτε πού αποθηκεύονται και αναφέρονται οι εξαγόμενες εικόνες bitmap, metafile και SVG."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET μπορεί να μετατρέπει παρουσιάσεις PPT και PPTX σε Markdown για τεκμηρίωση, στατικές ιστοσελίδες, μεταφορά περιεχομένου και ροές εργασίας ελέγχου έκδοσης. Μπορείτε να επιλέξετε μια γεύση Markdown, να ελέγξετε πώς αποδίδεται το περιεχόμενο των διαφάνειων και να αποφασίσετε πού θα αποθηκευτούν οι εξαγόμενες εικόνες και πώς θα τις αναφέρει το δημιουργημένο Markdown.

Από προεπιλογή, η εξαγωγή σε Markdown χρησιμοποιεί έξοδο μόνο κειμένου. Για να εξάγετε οπτικό περιεχόμενο, ορίστε την ιδιότητα [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions/exporttype/) στην τιμή `Sequential` ή `Visual` από την απαρίθμηση [MarkdownExportType](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownexporttype/). Το `Sequential` αποδίδει τα στοιχεία της διαφάνειας ξεχωριστά και με σειρά, ενώ το `Visual` διατηρεί τις ομαδοποιημένες αντικείμενα μαζί για να διατηρήσει τη οπτική τους σχέση. Η τιμή `TextOnly` δεν δημιουργεί πόρους εικόνας, επομένως τα γεγονότα αποθήκευσης εικόνας δεν καλούνται σε αυτήν τη λειτουργία.

## **Μετατροπή Παρουσίασης σε Markdown**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και, στη συνέχεια, καλέστε τη μέθοδο [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) με την τιμή `Md` από την απαρίθμηση [SaveFormat](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Επιλογή Γεύσης Markdown**

Η ιδιότητα [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions/flavor/) ελέγχει την προδιαγραφή Markdown που χρησιμοποιείται για την έξοδο. Η απαρίθμηση [Flavor](https://reference.aspose.com/slides/el/net/aspose.slides.export/flavor/) περιλαμβάνει CommonMark, GitHub Flavored Markdown και άλλες υποστηριζόμενες παραλλαγές.

Το παρακάτω παράδειγμα εξάγει μια παρουσίαση ως CommonMark:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Εξαγωγή Εικόνων Χρησιμοποιώντας την Προεπιλεγμένη Συμπεριφορά Τοπικής Αποθήκευσης**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions/) παρέχει δύο ιδιότητες για τοπικά αποθηκευμένες εικόνες:

- [BasePath](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions/basepath/) καθορίζει το βασικό κατάλογο για το έγγραφο Markdown και τους πόρους του.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) καθορίζει τον υποκατάλογο εικόνων. Η προεπιλεγμένη τιμή του είναι `Images`.

Το παρακάτω παράδειγμα αποδίδει οπτικό περιεχόμενο, γράφει εικόνες στο `output/assets` και δημιουργεί σχετικές αναφορές εικόνας στο έγγραφο Markdown:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Η συμπεριφορά αυτή εξυπηρετεί επίσης ως εφεδρική όταν ένας προσαρμοσμένος χειριστής αποθήκευσης εικόνας επιστρέφει `false`.

## **Προσαρμογή Αποθήκευσης Εικόνας και Συνδέσμων Markdown**

Χρησιμοποιήστε το γεγονός [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions/imagesaving/) για πόρους bitmap και μετααρχείων που δεν είναι SVG που εκπονούνται κατά την εξαγωγή σε Markdown. Ο εκχωρητής [MarkdownImageSavingHandler](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) λαμβάνει το αντικείμενο [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/), το [ImageFormat](https://reference.aspose.com/slides/el/net/aspose.slides/imageformat/) και τον παραγόμενο σύνδεσμο Markdown ως παράμετρο `ref string`. Αποθηκεύστε ή ανεβάστε την εικόνα με τη μορφή που δίνεται και αντικαταστήστε το `link` με την αναφορά που πρέπει να εμφανιστεί στην έξοδο Markdown.

Οι πόροι που εκπονούνται σε μορφή SVG διαχειρίζονται χωριστά. Εγγραφείτε στο γεγονός [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/), του οποίου ο εκχωρητής [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) λαμβάνει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/) και την παράμετρο `ref string link`. Ένα SVG δεν έχει όρισμα `ImageFormat`; γράψτε ή ανεβάστε τα XML δεδομένα του από την ιδιότητα [ISvgImage.SvgData](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/svgdata/) αντ' αυτού. Ανάλογα με τη λειτουργία εξαγωγής και την οπτική ομαδοποίηση, ένα SVG στην πηγή μπορεί να ραστεροποιηθεί ή να συνδυαστεί με άλλο περιεχόμενο· ο μη‑SVG πόρος που προκύπτει τότε διαβιβάζεται στο `ImageSaving`. Εγγραφείτε και στα δύο γεγονότα όταν κάθε εξαγόμενος οπτικός πόρος απαιτεί προσαρμοσμένη επεξεργασία.

Η τιμή επιστροφής του χειριστή καθορίζει ποιος επεξεργάζεται την εικόνα:

- Επιστρέψτε `true` αφού ο χειριστής έχει αποθηκεύσει, ανεβάσει, μετασχηματίσει ή με οποιονδήποτε τρόπο επεξεργαστεί την εικόνα και έχει ορίσει μια έγκυρη τιμή στο `link`. Το Aspose.Slides γράφει αυτήν την τιμή στο έγγραφο Markdown και δεν εκτελεί την προεπιλεγμένη τοπική αποθήκευση.
- Επιστρέψτε `false` για να επιτρέψετε στο Aspose.Slides να αποθηκεύσει την εικόνα τοπικά και να δημιουργήσει τον σύνδεσμο σύμφωνα με τις ιδιότητες [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions/basepath/) και [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Ένας χειριστής που επιστρέφει `true` αναλαμβάνει την ευθύνη για την εικόνα. Εάν επιστρέψει `true` χωρίς να αντιστοιχίσει έναν έγκυρο, μη κενό σύνδεσμο, η εξαγωγή αποτυγχάνει με `InvalidOperationException`.
{{% /alert %}}

### **Αποθήκευση Εικόνων σε Κατάλογο Προέλευσης CDN και Χρήση Εξωτερικών URLs**

Το παρακάτω παράδειγμα αντιλαμβάνεται το `cdn-origin/presentations/quarterly-report` ως προσαρτημένο ή συγχρονισμένο κατάλογο προέλευσης CDN. Κάθε χειριστής εξάγει το όνομα του παραγόμενου αρχείου, αποθηκεύει την εικόνα σε αυτόν τον προσαρμοσμένο κατάλογο και αντικαθιστά την τοπική αναφορά με ένα δημόσιο URL CDN. Το ίδιο το δείγμα δεν εκτελεί καμία δικτυακή φόρτωση: το URL γίνεται έγκυρο μόνο αφού ο κατάλογος προσαρτηθεί ως προέλευση CDN ή τα αρχεία του δημοσιευτούν στο CDN. Για αποθήκευση αντικειμένων, αντικαταστήστε την εγγραφή στο σύστημα αρχείων με τη λειτουργία ανεβάσματος του SDK αποθήκευσης και ορίστε το `link` μόνο μετά την επιτυχή μεταφόρτωση.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Ο χειριστής bitmap επιστρέφει σκόπιμα `false` για εικόνες μικρότερες από 128 × 128 pixel, ώστε το Aspose.Slides να αποθηκεύσει αυτές τις εικόνες στο `output/fallback-images` χρησιμοποιώντας τη προεπιλεγμένη συμπεριφορά. Μεγαλύτεροι πόροι bitmap και μετααρχείων, καθώς και πόροι SVG, διαχειρίζονται από τον προσαρμοσμένο κώδικα. Για παράδειγμα, μια τοπική αναφορά όπως `fallback-images/image1.png` γίνεται `https://cdn.example.com/presentations/quarterly-report/image1.png`. Οι χειριστές χρησιμοποιούν μόνο διαδρομές λειτουργικού συστήματος κατά την εγγραφή αρχείων· οι σύνδεσμοι που γράφονται στο Markdown χρησιμοποιούν κάθετους (/) και URL‑κωδικοποιημένα ονόματα αρχείων. Εφαρμόστε τον ίδιο κανόνα όταν δημιουργείτε σχετικούς συνδέσμους: χρησιμοποιήστε `/`, όχι το διαχωριστικό καταλόγου της πλατφόρμας.

## **Συχνές Ερωτήσεις**

**Μπορεί ένας χειριστής να επεξεργαστεί τόσο ραστερ εικόνες όσο και SVG εικόνες;**

Όχι. Χρησιμοποιήστε το [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions/imagesaving/) για bitmap και μετααρχείο πόρους και το [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) για πόρους που εκπονούνται ως SVG. Το πρώτο παρέχει ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) και ένα [ImageFormat](https://reference.aspose.com/slides/el/net/aspose.slides/imageformat/); το δεύτερο παρέχει ένα αντικείμενο [ISvgImage](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/) του οποίου τα δεδομένα SVG διαβάζονται από το [ISvgImage.SvgData](https://reference.aspose.com/slides/el/net/aspose.slides/isvgimage/svgdata/). Ένα SVG στην πηγή που ραστεροποιείται κατά την εξαγωγή επεξεργάζεται από το `ImageSaving`.

**Τι συμβαίνει όταν ένας χειριστής αποθήκευσης εικόνας επιστρέφει `false`;**

Το Aspose.Slides χρησιμοποιεί τη προεπιλεγμένη συμπεριφορά τοπικής αποθήκευσης. Η θέση της εικόνας και η δημιουργημένη αναφορά ελέγχονται από τις ιδιότητες [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions/basepath/) και [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/el/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

**Μπορεί ένας χειριστής να παρέχει URL χωρίς να αποθηκεύει την εικόνα τοπικά;**

Ναι. Ο χειριστής μπορεί να ανεβάσει την εικόνα σε αποθήκευση αντικειμένων ή να τη μεταβιβάσει σε άλλη υπηρεσία, να ορίσει το προκύπτων URL στο `link` και να επιστρέψει `true`. Ο χειριστής πρέπει να ολοκληρώσει την επεξεργασία μόνος του· η επιστροφή `true` αποτρέπει την προεπιλεγμένη τοπική αποθήκευση.

**Γιατί η εξαγωγή Markdown ρίχνει `InvalidOperationException` από έναν χειριστή;**

Αυτή η εξαίρεση εμφανίζεται όταν ο χειριστής επιστρέφει `true` αλλά δεν παρέχει έγκυρο σύνδεσμο. Ορίστε τη σχετική διαδρομή ή το εξωτερικό URL που πρέπει να γραφτεί στο Markdown πριν επιστρέψετε `true`.

**Ποιον διαχωριστικό διαδρομής πρέπει να χρησιμοποιούν οι σύνδεσμοι εικόνας;**

Χρησιμοποιήστε κάθετους (/) σε συνδέσμους Markdown και URLs. Χρησιμοποιήστε το `Path.Combine` μόνο για διαδρομές συστήματος αρχείων· στη συνέχεια δημιουργήστε ή ομαλοποιήστε την αναφορά Markdown ξεχωριστά.

**Διατηρούνται οι υπερσυνδέσεις κατά την εξαγωγή σε Markdown;**

Ναι. Τα κείμενα [hyperlinks](/slides/el/net/manage-hyperlinks/) διατηρούνται ως κανονικοί σύνδεσμοι Markdown. Οι [transitions](/slides/el/net/slide-transition/) και [animations](/slides/el/net/powerpoint-animation/) των διαφάνειων δεν μετατρέπονται.

**Μπορούν οι παρουσιάσεις να μετατραπούν σε Markdown παράλληλα;**

Μπορείτε να επεξεργαστείτε διαφορετικά αρχεία παρουσίασης παράλληλα, αλλά μην μοιράζετε το ίδιο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) μεταξύ νημάτων. Ακολουθήστε τις [multithreading guidelines](/slides/el/net/multithreading/) και χρησιμοποιήστε ξεχωριστό στιγμιότυπο για κάθε αρχείο.