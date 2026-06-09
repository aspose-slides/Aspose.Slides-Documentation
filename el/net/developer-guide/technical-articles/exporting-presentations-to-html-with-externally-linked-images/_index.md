---
title: Εξαγωγή παρουσιάσεων σε HTML με εξωτερικά συνδεδεμένες εικόνες
type: docs
weight: 100
url: /el/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- εξαγωγή PowerPoint
- εξαγωγή OpenDocument
- εξαγωγή παρουσίασης
- εξαγωγή διαφάνειας
- εξαγωγή PPT
- εξαγωγή PPTX
- εξαγωγή ODP
- PowerPoint σε HTML
- OpenDocument σε HTML
- παρουσίαση σε HTML
- διαφάνεια σε HTML
- PPT σε HTML
- PPTX σε HTML
- ODP σε HTML
- συνδεδεμένη εικόνα
- εξωτερικά συνδεδεμένη εικόνα
- συνδεδεμένος πόρος
- εξωτερικός πόρος
- .NET
- C#
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint και OpenDocument σε HTML στο .NET χρησιμοποιώντας το Aspose.Slides, με εικόνες και άλλους πόρους αποθηκευμένους ως εξωτερικά συνδεδεμένα αρχεία."
---
## **Επισκόπηση**

Από προεπιλογή, το Aspose.Slides εξάγει μια παρουσίαση σε ένα αυτόνομο αρχείο HTML. Οι εικόνες και άλλοι πόροι γράφονται απευθείας στο HTML, συνήθως ως δεδομένα Base64. Αυτό είναι βολικό όταν χρειάζεστε ένα μόνο φορητό αρχείο, αλλά δεν είναι πάντα η καλύτερη μορφή για έναν ιστότοπο, ένα CMS ή μια διακομιστική γραμμή μετατροπής.

Χρησιμοποιήστε εξωτερικά συνδεδεμένους πόρους όταν θέλετε να:
- μειώσετε το μέγεθος του εγγράφου HTML·
- αποθηκεύσετε στην κρυφή μνήμη (cache) εικόνες, γραμματοσειρές, ήχο ή βίντεο ξεχωριστά σε έναν περιηγητή ή CDN·
- εξετάσετε, αντικαταστήσετε, συμπιέσετε ή κάνετε επεξεργασία μετά την εξαγωγή των παραγόμενων πόρων·
- διατηρήσετε τη δομή εξόδου πιο κοντά σε αυτή που αναμένει μια διαδικτυακή εφαρμογή.

Για τη γενική ροή εργασίας μετατροπής HTML, δείτε [Μετατροπή παρουσιάσεων PowerPoint σε HTML](/slides/el/net/convert-powerpoint-to-html/). Αυτό το άρθρο εστιάζει στο μέρος της εξαγωγής που αφορά τη σύνδεση πόρων.

## **Πώς λειτουργεί η εξαγωγή συνδεδεμένων πόρων**

[ILinkEmbedController](https://reference.aspose.com/slides/el/net/aspose.slides.export/ilinkembedcontroller/) επιτρέπει στην εφαρμογή σας να αποφασίζει, πόρος προς πόρο, εάν ο εξαγωγέας ενσωματώνει τα δεδομένα στο HTML ή τα αποθηκεύει εξωτερικά και γράφει έναν σύνδεσμο.

Η διεπαφή έχει τρεις μεθόδους:
- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/el/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) αποφασίζει εάν ένας πόρος πρέπει να συνδεθεί ή να ενσωματωθεί.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/el/net/aspose.slides.export/ilinkembedcontroller/geturl/) επιστρέφει το URL που θα γραφτεί στο παραγόμενο HTML ή σε έναν άλλο συνδεδεμένο πόρο.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/el/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) γράφει τα δεδομένα του συνδεδεμένου πόρου στο δίσκο ή σε άλλο στόχο αποθήκευσης.

Η διαδρομή του συστήματος αρχείων και το URL του περιηγητή είναι ξεχωριστά ζητήματα. Για παράδειγμα, το παρακάτω δείγμα γράφει τα αρχεία πόρων στο `html-output/assets` στο δίσκο, ενώ το HTML περιέχει σχετικές URL όπως `assets/resource-1.svg`. Ένας περιηγητής επιλύει αυτές τις URL σχετικά με το αρχείο που περιέχει τον σύνδεσμο. Συνεπώς, ένας σύνδεσμος από το `presentation.html` προς ένα αρχείο SVG χρησιμοποιεί `assets/resource-1.svg`, ενώ ένας σύνδεσμος από εκείνο το αρχείο SVG προς μια εικόνα αποθηκευμένη στον ίδιο φάκελο `assets` χρησιμοποιεί `resource-4.jpg`.

## **Εξαγωγή HTML με συνδεδεμένους πόρους**

Το παρακάτω παράδειγμα C# δημιουργεί έναν φάκελο εξόδου, αποθηκεύει το αρχείο HTML εκεί και αποθηκεύει τους συνδεδεμένους πόρους σε έναν υποφάκελο `assets`. Ο ελεγκτής συνδέει κοινά εικόνες, γραμματοσειρές, ήχο, βίντεο και πόρους CSS όταν το Aspose.Slides παρέχει ή μπορεί να συμπεράνει ασφαλή κατάληξη αρχείου. Οι πόροι που δεν αναγνωρίζονται παραμένουν ενσωματωμένοι.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.IO;

var inputFilePath = "presentation.pptx";
var outputDirectory = "html-output";
var assetDirectoryName = "assets";
var assetDirectory = Path.Combine(outputDirectory, assetDirectoryName);

Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(assetDirectory);

var assetUrlPrefix = assetDirectoryName + "/";
var controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(string.Empty, false),
    SlideImageFormat = slideImageFormat
};

using var presentation = new Presentation(inputFilePath);

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

public sealed class ExternalResourceController : ILinkEmbedController
{
    private static readonly Dictionary<string, string> ExtensionsByContentType = new(StringComparer.OrdinalIgnoreCase)
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/gif"] = ".gif",
        ["image/bmp"] = ".bmp",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/x-emf"] = ".emf",
        ["image/x-wmf"] = ".wmf",
        ["font/woff"] = ".woff",
        ["font/woff2"] = ".woff2",
        ["font/ttf"] = ".ttf",
        ["application/font-woff"] = ".woff",
        ["application/vnd.ms-fontobject"] = ".eot",
        ["application/x-font-ttf"] = ".ttf",
        ["text/css"] = ".css",
        ["audio/mpeg"] = ".mp3",
        ["audio/mp4"] = ".m4a",
        ["audio/wav"] = ".wav",
        ["video/mp4"] = ".mp4",
        ["video/webm"] = ".webm"
    };

    private readonly string assetDirectory;
    private readonly string assetUrlPrefix;
    private readonly Dictionary<int, string> fileNamesByResourceId = new();

    public ExternalResourceController(string assetDirectory, string assetUrlPrefix)
    {
        if (string.IsNullOrWhiteSpace(assetDirectory))
        {
            throw new ArgumentException("The asset output directory must not be empty.", nameof(assetDirectory));
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
    }

    public LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        byte[] entityData,
        string semanticName,
        string contentType,
        string recommendedExtension)
    {
        var extension = ResolveExtension(contentType, recommendedExtension);
        if (extension == null)
        {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId[resourceId] = $"resource-{resourceId}{extension}";
        return LinkEmbedDecision.Link;
    }

    public string GetUrl(int resourceId, int referrer)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            return null;
        }

        if (fileNamesByResourceId.ContainsKey(referrer))
        {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    public void SaveExternal(int resourceId, byte[] entityData)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} was not registered for external storage.");
        }

        if (entityData == null || entityData.Length == 0)
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} contains no data and cannot be saved.");
        }

        Directory.CreateDirectory(assetDirectory);

        var filePath = Path.Combine(assetDirectory, fileName);
        File.WriteAllBytes(filePath, entityData);
    }

    private static string ResolveExtension(string contentType, string recommendedExtension)
    {
        if (!string.IsNullOrWhiteSpace(contentType) &&
            ExtensionsByContentType.TryGetValue(contentType, out var mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(contentType))
        {
            return null;
        }

        return NormalizeExtension(recommendedExtension);
    }

    private static bool IsSupportedContentType(string contentType)
    {
        return contentType != null &&
            (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("font/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
    }

    private static string NormalizeExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return null;
        }

        var extensionCharacters = extension.Trim().TrimStart('.');
        foreach (var character in extensionCharacters)
        {
            if (!char.IsLetterOrDigit(character))
            {
                return null;
            }
        }

        return "." + extensionCharacters.ToLowerInvariant();
    }

    private static string NormalizeUrlPrefix(string urlPrefix)
    {
        if (string.IsNullOrEmpty(urlPrefix))
        {
            return string.Empty;
        }

        var normalizedUrlPrefix = urlPrefix.Replace('\\', '/');
        return normalizedUrlPrefix.EndsWith("/")
            ? normalizedUrlPrefix
            : normalizedUrlPrefix + "/";
    }
}
```

Μετά την εξαγωγή, ο φάκελος εξόδου έχει την εξής δομή:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Τα ακριβή αρχεία εξαρτώνται από το περιεχόμενο της παρουσίασης και τις επιλογές εξαγωγής. Για παράδειγμα, οι ραστερ εικόνες συνήθως εξάγονται ως JPEG ή PNG. Το Aspose.Slides μπορεί να επιλέξει διαφορετικό κωδικοποιητή εικόνας από αυτόν που χρησιμοποιείται στην πηγή όταν αυτό παράγει μικρότερο ή πιο κατάλληλο αρχείο. Οι εικόνες με διαφάνεια εξάγονται ως PNG.

## **Επιλογή URL για ανάπτυξη**

Το δείγμα χρησιμοποιεί ένα σχετικό πρόθεμα URL: `assets/`. Εάν το `presentation.html` ανοίξει από το `html-output/presentation.html`, ο περιηγητής φορτώνει το `html-output/assets/resource-1.svg`.

Όταν ένας συνδεδεμένος πόρος παραπέμπει σε έναν άλλο συνδεδεμένο πόρο, το δείγμα χρησιμοποιεί την παράμετρο `referrer` στην [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/el/net/aspose.slides.export/ilinkembedcontroller/geturl/) και επιστρέφει μόνο το όνομα του αρχείου. Για παράδειγμα, εάν τα `resource-1.svg` και `resource-4.jpg` βρίσκονται και τα δύο στον φάκελο `assets`, το αρχείο SVG πρέπει να παραπέμπει στο `resource-4.jpg`, όχι στο `assets/resource-4.jpg`.

Χρησιμοποιήστε διαφορετικό πρόθεμα URL όταν τα αρχεία αναπτύσσονται αλλού:
- Χρησιμοποιήστε `assets/` όταν ο φάκελος περιουσιακών στοιχείων είναι δίπλα στο αρχείο HTML.
- Χρησιμοποιήστε `../assets/` όταν ο φάκελος περιουσιακών στοιχείων είναι ένα επίπεδο πάνω από το αρχείο HTML.
- Χρησιμοποιήστε `https://cdn.example.com/presentations/job-123/assets/` όταν τα αρχεία ανεβαίνουν σε CDN ή σε στατικό διακομιστή αρχείων.

Το URL που επιστρέφεται από την [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/el/net/aspose.slides.export/ilinkembedcontroller/geturl/) πρέπει να ταιριάζει με την τελική θέση του αρχείου που γράφεται από την [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/el/net/aspose.slides.export/ilinkembedcontroller/saveexternal/). Σε εφαρμογές διακομιστή, χρησιμοποιήστε μοναδικό φάκελο εξόδου ή πρόθεμα αποθήκευσης αντικειμένου για κάθε εργασία μετατροπής ώστε να αποφεύγεται η αντικατάσταση αρχείων από άλλη εξαγωγή.

## **Πότε να ενσωματώσετε αντί αυτού**

Το ενσωματωμένο Base64 HTML παραμένει χρήσιμο όταν η έξοδος πρέπει να είναι ένα ενιαίο αρχείο, όπως συνημμένο email, προβολή εκτός σύνδεσης ή έγγραφο που θα μεταφερθεί χωρίς φάκελο περιουσιακών στοιχείων. Οι συνδεδεμένοι πόροι είναι πιο κατάλληλοι όταν το HTML θα σερβιριστεί από διαδικτυακή εφαρμογή, θα αποθηκευτεί σε CMS, θα βελτιστοποιηθεί από γραμμή κατασκευής ή θα κρυφά αποθηκευτεί ανεξάρτητα από το HTML από τους περιηγητές.

## **FAQ**

**Μπορώ να εξωτερικοποιήσω μόνο τις εικόνες και να διατηρήσω τους άλλους πόρους ενσωματωμένους;**

Ναι. Στην [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/el/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/), επιστρέψτε `LinkEmbedDecision.Link` μόνο για τους τύπους περιεχομένου που θέλετε να αποθηκεύσετε ως ξεχωριστά αρχεία και επιστρέψτε `LinkEmbedDecision.Embed` για τα υπόλοιπα.

**Γιατί η εξαγόμενη κατάληξη εικόνας διαφέρει από αυτή της πηγής παρουσίασης;**

Το Aspose.Slides μπορεί να ξανακωδικοποιήσει τις ραστερ εικόνες κατά την εξαγωγή σε HTML για βελτίωση του μεγέθους ή της συμβατότητας με τον περιηγητή. Για παράδειγμα, μια εικόνα από το αρχείο πηγής μπορεί να γραφτεί ως JPEG ή PNG ανάλογα με το αποτέλεσμα απόδοσης.

**Λειτουργούν οι σχετικές URL μετά τη μετακίνηση του αρχείου HTML;**

Οι σχετικές URL λειτουργούν μόνο όταν διατηρείται η ίδια σχετική δομή φακέλων. Εάν το HTML παραπέμπει στο `assets/resource-1.png`, ο φάκελος `assets` πρέπει να παραμείνει δίπλα στο αρχείο HTML, εκτός εάν δημιουργήσετε διαφορετικό πρόθεμα URL.

**Πρέπει οι εφαρμογές διακομιστή να επαναχρησιμοποιούν τον ίδιο φάκελο εξόδου;**

Όχι. Χρησιμοποιήστε μοναδικό φάκελο εξόδου ή πρόθεμα αποθήκευσης για κάθε εργασία μετατροπής. Αυτό αποτρέπει συγκρούσεις ονομάτων αρχείων και εμποδίζει μια εξαγωγή να αντικαταστήσει πόρους που δημιουργήθηκαν από άλλη εξαγωγή.