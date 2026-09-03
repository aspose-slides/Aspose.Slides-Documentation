---
title: Ενσωμάτωση γραμματοσειρών σε παρουσιάσεις σε .NET
linktitle: Ενσωματωμένες Γραμματοσειρές
type: docs
weight: 40
url: /el/net/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειρών
- λήψη ενσωματωμένης γραμματοσειράς
- προσθήκη ενσωματωμένης γραμματοσειράς
- αφαίρεση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε τις ενσωματωμένες γραμματοσειρές στο PowerPoint με το Aspose.Slides for .NET. Χρησιμοποιήστε C# για να προσθέτετε, να ανακτάτε, να αφαιρείτε και να συμπιέζετε γραμματοσειρές, ώστε να διατηρείται η εμφάνιση του κειμένου και να μειώνεται το μέγεθος του αρχείου."
---
## **Εισαγωγή**

Η ενσωμάτωση γραμματοσειρών αποθηκεύει τα δεδομένα της γραμματοσειράς μέσα σε μια παρουσίαση PowerPoint. Όταν ένας προβολέας υποστηρίζει ενσωματωμένες γραμματοσειρές, μπορεί να εμφανίσει κείμενο χρησιμοποιώντας αυτές τις γραμματοσειρές ακόμη και αν δεν είναι εγκατεστημένες στο σύστημα‑στόχο. Αυτό βοηθά στη διατήρηση των αλλαγών γραμμής, του διαστήματος του κειμένου και της διάταξης των διαφανειών.

Το Aspose.Slides for .NET σάς επιτρέπει να ανακτάτε, να προσθέτετε και να καταργείτε ενσωματωμένες γραμματοσειρές μέσω της ιδιότητας [FontsManager](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/fontsmanager/) ενός [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Μπορείτε επίσης να μειώσετε το μέγεθος των δεδομένων ενσωματωμένης γραμματοσειράς αφαιρώντας χαρακτήρες που δεν χρησιμοποιεί η παρουσίαση.

Τα παραδείγματα παρακάτω λειτουργούν με αρχεία PPTX. Πριν ενσωματώσετε μια γραμματοσειρά, βεβαιωθείτε ότι τα δεδομένα της γραμματοσειράς είναι διαθέσιμα στο Aspose.Slides και ότι η άδειά της επιτρέπει την ενσωμάτωση.

## **Λήψη και Κατάργηση Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιήστε το [GetEmbeddedFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/getembeddedfonts/) για να απαριθμήσετε τις γραμματοσειρές που είναι αποθηκευμένες σε μια παρουσίαση. Για να αφαιρέσετε μία, περάστε μια γραμματοσειρά από αυτή τη λίστα στο [RemoveEmbeddedFont](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/removeembeddedfont/), και στη συνέχεια αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα απαριθμεί τις ενσωματωμένες γραμματοσειρές στο αρχείο `EmbeddedFonts.pptx` και αφαιρεί τη Calibri εάν είναι παρούσα:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

Η κατάργηση μιας ενσωματωμένης γραμματοσειράς αφαιρεί τα αποθηκευμένα δεδομένα της γραμματοσειράς· δεν αλλάζει τη γραμματοσειρά που έχει αντιστοιχιστεί στο κείμενο. Εάν η γραμματοσειρά είναι εγκατεστημένη στο σύστημα‑στόχο, το κείμενο μπορεί ακόμη να τη χρησιμοποιήσει. Διαφορετικά, η απόδοση ενδέχεται να απαιτήσει [font substitution](/slides/el/net/font-substitution/), κάτι που μπορεί να επηρεάσει τη διάταξη.

## **Επιθεώρηση Δεδομένων Γραμματοσειράς και Δικαιωμάτων Ενσωμάτωσης**

Χρησιμοποιήστε τη διεπαφή [IFontsManager](https://reference.aspose.com/slides/el/net/aspose.slides/ifontsmanager/) για να επιθεωρήσετε τις γραμματοσειρές πριν τις ενσωματώσετε. Καλέστε το [IFontsManager.GetFonts](https://reference.aspose.com/slides/el/net/aspose.slides/ifontsmanager/getfonts/) για να ανακτήσετε τις γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση. Για κάθε γραμματοσειρά, περάστε ένα αντικείμενο [IFontData](https://reference.aspose.com/slides/el/net/aspose.slides/ifontdata/) και την απαιτούμενη τιμή [FontStyleType](https://reference.aspose.com/slides/el/net/aspose.slides/fontstyletype/), στο [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/el/net/aspose.slides/ifontsmanager/getfontbytes/). Η μέθοδος επιστρέφει τα δυαδικά δεδομένα για εκείνο το στυλ γραμματοσειράς, ή `null` όταν η ζητούμενη γραμματοσειρά ή στυλ δεν είναι διαθέσιμα. Μην περάσετε ένα αποτέλεσμα `null` στο [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/el/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), επειδή αυτή η μέθοδος απαιτεί έναν πίνακα byte.

[EmbeddingLevel](https://reference.aspose.com/slides/el/net/aspose.slides/embeddinglevel/) είναι μια απαγωγή flags που αναφέρει τους περιορισμούς ενσωμάτωσης που αποθηκεύονται στη γραμματοσειρά:

- `Installable` επιτρέπει την ενσωμάτωση και μόνιμη εγκατάσταση σε άλλο σύστημα, υπό την άδεια της γραμματοσειράς.
- `Restricted` απαγορεύει την ενσωμάτωση εκτός εάν ληφθεί άδεια από τον νόμιμο κάτοχο της γραμματοσειράς όταν είναι η μοναδική σημαία άδειας χρήσης.
- `PreviewPrint` επιτρέπει προσωρινή χρήση για προβολή και εκτύπωση· ένα έγγραφο που περιέχει τη γραμματοσειρά πρέπει να είναι μόνο για ανάγνωση.
- `Editable` επιτρέπει προσωρινή χρήση και επιτρέπει το έγγραφο να επεξεργαστεί και να αποθηκευτεί.
- `NoSubsetting` είναι ένας επιπλέον περιορισμός που απαγορεύει την ενσωμάτωση μόνο ενός υποσυνόλου των γλύφων. Ενσωματώνει όλους τους χαρακτήρες όταν αυτή η σημαία είναι παρούσα.
- `BitmapOnly` είναι ένας επιπλέον περιορισμός που επιτρέπει την ενσωμάτωση μόνο bitmap strikes, όχι δεδομένων περιγράμματος. Εάν η γραμματοσειρά δεν έχει bitmap strikes, δεν μπορεί να ενσωματωθεί.

Οι πρώτες τέσσερις τιμές περιγράφουν την άδεια χρήσης, ενώ τα `NoSubsetting` και `BitmapOnly` μπορούν να συνδυαστούν μαζί τους. Ελέγξτε τους τροποποιητές με λειτουργίες bitwise. Επειδή το `Installable` είναι μηδέν, μην χρησιμοποιήσετε `HasFlag` για να το εντοπίσετε· μάσκαρε τα bits άδειας χρήσης και σύγκρινε το αποτέλεσμα με το `Installable`. Οι τρέχουσες γραμματοσειρές πρέπει να θέτουν το πολύ ένα bit άδειας χρήσης. Για συμβατότητα με παλαιότερες γραμματοσειρές που θέτουν περισσότερα από ένα, ο βοηθός παρακάτω επιλέγει την λιγότερο περιοριστική άδεια: `Editable`, μετά `PreviewPrint`, μετά `Restricted`.

Το παρακάτω παράδειγμα ελέγχει τα κανονικά, έντονα, πλάγια και έντονα‑πλάγια δεδομένα που διατίθενται για κάθε γραμματοσειρά που επιστρέφεται από το `GetFonts`. Παράβλεψη μη διαθέσιμων στυλ, περιορισμένων γραμματοσειρών, bitmap‑only γραμματοσειρών, γραμματοσειρών περιορισμένων σε προεπισκόπηση και εκτύπωση επειδή το αποτέλεσμα παραμένει επεξεργάσιμο, και γραμματοσειρών που είναι ήδη ενσωματωμένες. Εάν κάποιο διαθέσιμο στυλ έχει `NoSubsetting`, ενσωματώνει όλους τους χαρακτήρες για εκείνη την οικογένεια γραμματοσειρών.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

Αυτή η επιθεώρηση αναφέρει τους περιορισμούς που κωδικοποιούνται σε κάθε αρχείο γραμματοσειράς. Δεν παρέχει άδεια, δεν αποδεικνύει ότι αποκτήσατε τη γραμματοσειρά νόμιμα, ούτε αντικαθιστά τον έλεγχο της συμφωνίας άδειας της γραμματοσειράς πριν διανείμετε ένα ενσωματωμένο αντίτυπο.

## **Προσθήκη Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιήστε το [AddEmbeddedFont](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/addembeddedfont/) για να ενσωματώσετε μια γραμματοσειρά. Οι υπερφορτώσεις του δέχονται είτε ένα αντικείμενο [IFontData](https://reference.aspose.com/slides/el/net/aspose.slides/ifontdata/) είτε έναν πίνακα byte που περιέχει τα δεδομένα της γραμματοσειράς. Η απαγωγή [EmbedFontCharacters](https://reference.aspose.com/slides/el/net/aspose.slides.export/embedfontcharacters/) ελέγχει ποιους χαρακτήρες θα συμπεριληφθούν:

- [All](https://reference.aspose.com/slides/el/net/aspose.slides.export/embedfontcharacters/) ενσωματώνει όλους τους χαρακτήρες στη γραμματοσειρά. Χρησιμοποιήστε αυτήν την επιλογή όταν οι παραλήπτες χρειάζονται να επεξεργαστούν την παρουσίαση και να εισάγουν νέο κείμενο.
- [OnlyUsed](https://reference.aspose.com/slides/el/net/aspose.slides.export/embedfontcharacters/) ενσωματώνει μόνο τους χαρακτήρες που χρησιμοποιούνται στην παρουσίαση για να μειωθεί το μέγεθος του αρχείου. Επιλέξτε αυτήν την επιλογή για μια τελική παρουσίαση που προορίζεται κυρίως για προβολή.

Το παρακάτω παράδειγμα χρησιμοποιεί το [GetFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/getfonts/) για να ανακτήσει τις γραμματοσειρές που χρησιμοποιούνται στο `Fonts.pptx` και ενσωματώνει εκείνες που δεν είναι ήδη ενσωματωμένες. Οι γραμματοσειρές που θα προστεθούν πρέπει να είναι διαθέσιμες στο μηχάνημα που εκτελεί τον κώδικα. Οι υπάρχουσες ενσωματωμένες γραμματοσειρές διατηρούν τα τρέχοντα σύνολα χαρακτήρων τους.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **Συμπίεση Ενσωματωμένων Γραμματοσειρών**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/compressembeddedfonts/) μειώνει τα ενσωματωμένα δεδομένα γραμματοσειράς αφαιρώντας αχρησιμοποίητους χαρακτήρες. Λειτουργεί σε γραμματοσειρές που είναι ήδη ενσωματωμένες, έτσι η μείωση του μεγέθους εξαρτάται από το πόσα αχρησιμοποίητα δεδομένα γραμματοσειράς περιέχει η παρουσίαση.

Το παρακάτω παράδειγμα συμπιέζει τις γραμματοσειρές στο `EmbeddedFonts.pptx` και αποθηκεύει το αποτέλεσμα ως ξεχωριστό αρχείο:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Διατηρήστε το αρχικό αρχείο εάν οι παραλήπτες ενδέχεται να χρειαστούν να προσθέσουν κείμενο αργότερα. Οι χαρακτήρες που αφαιρέθηκαν κατά τη συμπίεση δεν είναι πλέον διαθέσιμοι από την ενσωματωμένη γραμματοσειρά, ακόμη και αν αρχικά ενσωματώσατε όλους τους χαρακτήρες.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω εάν μια ενσωματωμένη γραμματοσειρά θα συνεχίσει να υποκαθίσταται κατά την απόδοση;**

Καλέστε το [GetSubstitutions](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/getsubstitutions/) στο περιβάλλον όπου αποδίδετε την παρουσίαση για να δείτε ποιες γραμματοσειρές θα αντικαταστήσει το Aspose.Slides. Ελέγξτε επίσης τις ρυθμίσεις [font substitution](/slides/el/net/font-substitution/) και τους κανόνες [font fallback](/slides/el/net/fallback-font/). Η εναλλακτική αντιμετωπίζει τους χαμένους χαρακτήρες, επομένως η ενσωμάτωση μιας γραμματοσειράς δεν λύνει χαρακτήρες που η ίδια η γραμματοσειρά δεν περιέχει.

**Θα πρέπει να ενσωματώνω κοινές γραμματοσειρές όπως Arial και Calibri;**

Βασίστε την απόφαση στο περιβάλλον‑στόχο. Εάν οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες σε κάθε μηχάνημα που ανοίγει ή αποδίδει την παρουσίαση, η ενσωμάτωσή τους μπορεί να προσθέσει μη απαραίτητο μέγεθος αρχείου. Εάν οι παραλήπτες ή οι διακομιστές ενδέχεται να μην διαθέτουν αυτές τις γραμματοσειρές, η ενσωμάτωσή τους μπορεί να βοηθήσει στη διατήρηση της προοριζόμενης εμφάνισης, εφόσον οι άδειές τους το επιτρέπουν.