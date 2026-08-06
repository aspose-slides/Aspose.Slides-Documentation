---
title: Προσαρμογή γραμματοσειρών PowerPoint στο .NET
linktitle: Προσαρμοσμένη Γραμματοσειρά
type: docs
weight: 20
url: /el/net/custom-font/
keywords:
- γραμματοσειρά
- προσαρμοσμένη γραμματοσειρά
- εξωτερική γραμματοσειρά
- φόρτωση γραμματοσειράς
- διαχείριση γραμματοσειρών
- φάκελος γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Προσαρμόστε τις γραμματοσειρές στις διαφάνειες PowerPoint με το Aspose.Slides για .NET ώστε οι παρουσιάσεις σας να παραμένουν καθαρές και συνεπείς σε οποιαδήποτε συσκευή."
---
## **Επισκόπηση**

Aspose.Slides σάς επιτρέπει να χρησιμοποιείτε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαθιστάτε στο λειτουργικό σύστημα. Μπορείτε να φορτώνετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών σε επίπεδο εγγράφου, ή να φορτώνετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν η παρουσίαση αποδίδεται ή εξάγεται, π.χ. σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά να διατηρείται η έξοδος της παρουσίασης συνεπής σε διαφορετικά περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να ελέγξετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να εκκαθαρίσετε τη λανθάνουσα μνήμη (cache) γραμματοσειρών μετά τη χρήση εξωτερικών γραμματοσειρών.

Η καταχώριση προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ενσωμάτωση γραμματοσειρών σε αρχείο PPTX. Εάν πρέπει μια γραμματοσειρά να αποθηκευτεί μέσα στην παρουσίαση, χρησιμοποιήστε τα χαρακτηριστικά ενσωμάτωσης γραμματοσειρών ρητά.

{{% alert color="primary" %}} 
Το Aspose Slides σας επιτρέπει να φορτώνετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) και TrueType Collection (.ttc) γραμματοσειρές. Δείτε [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) γραμματοσειρές. Δείτε [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Aspose.Slides σάς επιτρέπει να φορτώνετε γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαθιστάτε στο σύστημα. Αυτό επηρεάζει την έξοδο εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — ώστε τα παραγόμενα έγγραφα να φαίνονται συνεπή μεταξύ διαφορετικών περιβαλλόντων. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Ορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.
2. Καλείστε τη στατική μέθοδο [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfonts/) για να φορτώσετε τις γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Καλείστε το [FontsLoader.ClearCache](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/clearcache/) για να εκκαθαρίσετε τη λανθάνουσα μνήμη γραμματοσειρών.

Το ακόλουθο παράδειγμα κώδικα δείχνει τη διαδικασία φόρτωσης γραμματοσειρών:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Ορίστε φακέλους που περιέχουν προσαρμοσμένα αρχεία γραμματοσειρών.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Φορτώστε προσαρμοσμένες γραμματοσειρές από τους καθορισμένους φακέλους.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Αποδώστε/εξάγετε την παρουσίαση (π.χ., σε PDF, εικόνες ή άλλες μορφές) χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Εκκαθαρίστε τη λανθάνουσα μνήμη γραμματοσειρών μετά την ολοκλήρωση της εργασίας.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfonts/) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά αρχικοποίησης των γραμματοσειρών.
Οι γραμματοσειρές αρχικοποιούνται με την ακόλουθη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
1. Οι διαδρομές που φορτώθηκαν μέσω του [FontsLoader](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Λήψη Φακέλων Προσαρμοσμένων Γραμματοσειρών**

Aspose.Slides παρέχει τη μέθοδο [GetFontFolders](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/getfontfolders/) για να βρείτε φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` καθώς και φακέλους συστήματος.

Αυτός ο κώδικας C# δείχνει πώς να χρησιμοποιήσετε το [GetFontFolders](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Αυτή η γραμμή εξάγει τους φακέλους που ελέγχονται για αρχεία γραμματοσειρών.
// Αυτοί είναι φάκελοι που προστέθηκαν μέσω της μεθόδου LoadExternalFonts και φάκελοι γραμματοσειρών του συστήματος.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών που Χρησιμοποιούνται με Παρουσίαση**

Aspose.Slides παρέχει την ιδιότητα [DocumentLevelFontSources](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/documentlevelfontsources/) για να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση.

Αυτός ο κώδικας C# δείχνει πώς να χρησιμοποιήσετε την ιδιότητα [DocumentLevelFontSources](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Εργαστείτε με την παρουσίαση
    // CustomFont1, CustomFont2 και οι γραμματοσειρές από τους φακέλους assets\fonts & global\fonts και τους υποφακέλους τους είναι διαθέσιμες στην παρουσίαση
}
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**

Aspose.Slides παρέχει τη μέθοδο [LoadExternalFont](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) για να φορτώνετε εξωτερικές γραμματοσειρές από δυαδικά δεδομένα.

Αυτός ο κώδικας C# παρουσιάζει τη διαδικασία φόρτωσης γραμματοσειρών από πίνακα byte:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // εξωτερική γραμματοσειρά φορτωμένη κατά τη διάρκεια της παρουσίασης
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**Επηρεάζουν οι προσαρμοσμένες γραμματοσειρές την εξαγωγή σε όλες τις μορφές (PDF, PNG, SVG, HTML);**

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από το μοντέλο απόδοσης σε όλες τις μορφές εξαγωγής.

**Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο παραγόμενο PPTX;**

Όχι. Η καταγραφή μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωσή της σε PPTX. Εάν χρειάζεται η γραμματοσειρά να είναι ενσωματωμένη μέσα στο αρχείο παρουσίασης, πρέπει να χρησιμοποιήσετε τις ρητές [embedding features](/slides/el/net/embedded-font/).

**Μπορώ να ελέγξω τη συμπεριφορά fallback όταν μια προσαρμοσμένη γραμματοσειρά δεν περιέχει ορισμένα γλύφες;**

Ναι. Διαμορφώστε την [font substitution](/slides/el/net/font-substitution/), τους [replacement rules](/slides/el/net/font-replacement/) και τα [fallback sets](/slides/el/net/fallback-font/) για να ορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν το ζητούμενο γλύφος λείπει.

**Μπορώ να χρησιμοποιήσω γραμματοσειρές σε κοντέινερ Linux/Docker χωρίς να τις εγκαταστήσω σε όλο το σύστημα;**

Ναι. Κατευθύνετε σε δικούς σας φακέλους γραμματοσειρών ή φορτώστε γραμματοσειρές από πίνακες byte. Αυτό αφαιρεί κάθε εξάρτηση από φακέλους γραμματοσειρών του συστήματος στην εικόνα του κοντέινερ.

> **Note for Linux/Docker**: When calling `FontsLoader.LoadExternalFonts`, ensure that every entry in the `directories` array contains a non-empty path to an existing directory. If an environment variable used to construct a font path is undefined or empty, Aspose.Slides may attempt to resolve the empty value as a full path, resulting in `System.ArgumentException`.

**Τι γίνεται με την άδεια—μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;**

Είστε υπεύθυνοι για τη συμμόρφωση με τις άδειες των γραμματοσειρών. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή εμπορική χρήση. Πάντα ελέγχετε το EULA της γραμματοσειράς πριν διανείμετε τα παραγόμενα αρχεία.