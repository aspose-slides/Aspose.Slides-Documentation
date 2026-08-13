---
title: Προσαρμογή γραμματοσειρών PowerPoint στο .NET
linktitle: Προσαρμοσμένη γραμματοσειρά
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
description: "Προσαρμόστε τις γραμματοσειρές στις διαφάνειες του PowerPoint με το Aspose.Slides για .NET ώστε οι παρουσιάσεις σας να παραμένουν καθαρές και συνεπείς σε οποιαδήποτε συσκευή."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιείτε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαθιστάτε στο λειτουργικό σύστημα. Μπορείτε να φορτώσετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για μια συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών επιπέδου εγγράφου ή να φορτώσετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά στη διατήρηση της συνέπειας των εξόδων της παρουσίασης σε διαφορετικά περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να ελέγξετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να καθαρίσετε την προσωρινή μνήμη γραμματοσειρών μετά από εργασία με εξωτερικές γραμματοσειρές.

Η καταγραφή προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ενσωμάτωση γραμματοσειρών σε αρχείο PPTX. Εάν μια γραμματοσειρά πρέπει να αποθηκευτεί μέσα στην ίδια την παρουσίαση, χρησιμοποιήστε ρητά τις δυνατότητες ενσωμάτωσης γραμματοσειρών.

{{% alert color="info" %}} 
Το Aspose Slides σας επιτρέπει να φορτώσετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfonts/):

* γραμματοσειρές TrueType (.ttf) και TrueType Collection (.ttc). Δείτε [TrueType](https://en.wikipedia.org/wiki/TrueType).
* γραμματοσειρές OpenType (.otf). Δείτε [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides σας επιτρέπει να φορτώνετε τις γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαθιστάτε στο σύστημα. Αυτό επηρεάζει την έξοδο εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — έτσι ώστε τα παραγόμενα έγγραφα να έχουν συνεπή εμφάνιση σε διάφορα περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.
2. Κληθείτε τη στατική μέθοδο [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfonts/) για να φορτώσετε γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Κλήστε τη [FontsLoader.ClearCache](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/clearcache/) για να καθαρίσετε την προσωρινή μνήμη γραμματοσειρών.

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

// Καθαρίστε την προσωρινή μνήμη γραμματοσειρών μετά την ολοκλήρωση της εργασίας.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
Η [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfonts/) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά αρχικοποίησης των γραμματοσειρών. Οι γραμματοσειρές αρχικοποιούνται με αυτή τη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
1. Οι διαδρομές που φορτώνονται μέσω του [FontsLoader](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Λήψη Προσαρμοσμένων Φακέλων Γραμματοσειρών**
Το Aspose.Slides παρέχει τη μέθοδο [GetFontFolders](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/getfontfolders/) ώστε να βρείτε φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` και τους φακέλους γραμματοσειρών του συστήματος.

```c#
using Aspose.Slides;

// Αυτή η γραμμή εμφανίζει τους φακέλους που ελέγχονται για αρχεία γραμματοσειρών.
// Αυτοί είναι οι φάκελοι που προστέθηκαν μέσω της μεθόδου LoadExternalFonts και οι φάκελοι γραμματοσειρών του συστήματος.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών που Χρησιμοποιούνται με μια Παρουσίαση**
Το Aspose.Slides παρέχει την ιδιότητα [DocumentLevelFontSources](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/documentlevelfontsources/) ώστε να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση.

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Εργασία με την παρουσίαση
    // Οι CustomFont1, CustomFont2 και οι γραμματοσειρές από τους φακέλους assets\fonts & global\fonts και τους υποφακέλους τους είναι διαθέσιμες στην παρουσίαση
}
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**
Το Aspose.Slides παρέχει τη μέθοδο [LoadExternalFont](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) ώστε να φορτώσετε εξωτερικές γραμματοσειρές από δυαδικά δεδομένα.

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

## **Συχνές Ερωτήσεις**

**Επηρεάζουν οι προσαρμοσμένες γραμματοσειρές την εξαγωγή σε όλες τις μορφές (PDF, PNG, SVG, HTML);**

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον αποτυπωματιστή σε όλες τις μορφές εξαγωγής.

**Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο παραγόμενο PPTX;**

Όχι. Η καταγραφή μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωση της σε αρχείο PPTX. Εάν χρειάζεστε τη γραμματοσειρά ενσωματωμένη μέσα στο αρχείο παρουσίασης, πρέπει να χρησιμοποιήσετε τις ρητές [δυνατότητες ενσωμάτωσης](/slides/el/net/embedded-font/).

**Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικής γραμματοσειράς όταν μια προσαρμοσμένη γραμματοσειρά λείπουν ορισμένα γλυφικά;**

Ναι. Διαμορφώστε την [αντικατάσταση γραμματοσειρών](/slides/el/net/font-substitution/), τους [κανόνες αντικατάστασης](/slides/el/net/font-replacement/) και τα [σύνολα εφεδρικών γραμματοσειρών](/slides/el/net/fallback-font/) για να καθορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν λείπει το ζητούμενο γλυφικό.

**Μπορώ να χρησιμοποιήσω γραμματοσειρές σε κοντέινερ Linux/Docker χωρίς να τις εγκαταστήσω σε ολόκληρο το σύστημα;**

Ναι. Δείξτε στους δικούς σας φακέλους γραμματοσειρών ή φορτώστε γραμματοσειρές από πίνακες byte. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από τους καταλόγους γραμματοσειρών του συστήματος στην εικόνα του κοντέινερ.

> **Σημείωση για Linux/Docker**: Κατά την κλήση της `FontsLoader.LoadExternalFonts`, βεβαιωθείτε ότι κάθε στοιχείο στον πίνακα `directories` περιέχει μια μη κενή διαδρομή προς έναν υπάρχοντα φάκελο. Εάν μια μεταβλητή περιβάλλοντος που χρησιμοποιείται για τη δημιουργία διαδρομής γραμματοσειράς είναι ακαθόριστη ή κενή, το Aspose.Slides μπορεί να προσπαθήσει να επιλύσει την κενή τιμή ως πλήρη διαδρομή, με αποτέλεσμα να προκύψει το `System.ArgumentException`.

**Τι γίνεται με την άδεια—μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;**

Είστε υπεύθυνοι για τη συμμόρφωση με τις άδειες των γραμματοσειρών. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή την εμπορική χρήση. Πάντα ελέγχετε την άδεια χρήσης (EULA) της γραμματοσειράς πριν διανείμετε τα παραγόμενα αρχεία.