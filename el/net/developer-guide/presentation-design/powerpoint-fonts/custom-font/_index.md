---
title: "Προσαρμογή Γραμματοσειρών PowerPoint σε .NET"
linktitle: "Προσαρμοσμένη Γραμματοσειρά"
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

Το Aspose.Slides σας επιτρέπει να χρησιμοποιείτε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαθιστάτε στο λειτουργικό σύστημα. Μπορείτε να φορτώνετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για μια συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών επιπέδου εγγράφου, ή να φορτώνετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά να διατηρείται η έξοδος της παρουσίασης συνεπής σε διαφορετικά περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να ελέγξετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να καθαρίσετε τη λανθάνουσα μνήμη (cache) γραμματοσειρών μετά τη χρήση εξωτερικών γραμματοσειρών.

Η καταχώριση προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ενσωμάτωση γραμματοσειρών σε αρχείο PPTX. Εάν μια γραμματοσειρά πρέπει να αποθηκευτεί εντός της παρουσίασης, χρησιμοποιήστε ρητά τις δυνατότητες ενσωμάτωσης γραμματοσειρών.

{{% alert color="primary" %}} 

Aspose Slides σας επιτρέπει να φορτώνετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfonts/) :

* Γραμματοσειρές TrueType (.ttf) και TrueType Collection (.ttc). Δείτε το [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Γραμματοσειρές OpenType (.otf). Δείτε το [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides σας επιτρέπει να φορτώνετε τις γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαθιστάτε στο σύστημα. Αυτό επηρεάζει την έξοδο εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — ώστε τα παραγόμενα έγγραφα να φαίνονται συνεπή σε διάφορα περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.  
2. Κληθείτε τη στατική μέθοδο [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfonts/) για να φορτώσετε τις γραμματοσειρές από αυτούς τους φακέλους.  
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.  
4. Κληθείτε τη [FontsLoader.ClearCache](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/clearcache/) για να καθαρίσετε τη λανθάνουσα μνήμη γραμματοσειρών.

Το παρακάτω παράδειγμα κώδικα δείχνει τη διαδικασία φόρτωσης γραμματοσειρών:

```cs
// Ορίστε φακέλους που περιέχουν προσαρμοσμένα αρχεία γραμματοσειρών.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// Φορτώστε προσαρμοσμένες γραμματοσειρές από τους καθορισμένους φακέλους.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Αποδώστε/εξάγετε την παρουσίαση (π.χ., σε PDF, εικόνες ή άλλες μορφές) χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Καθαρίστε τη λανθάνουσα μνήμη γραμματοσειρών μετά την ολοκλήρωση της εργασίας.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfonts/) προσθέτει πρόσθετους φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά εκκίνησης των γραμματοσειρών.
Οι γραμματοσειρές αρχικοποιούνται με αυτή τη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.  
1. Οι διαδρομές που φορτώθηκαν μέσω του [FontsLoader](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Λήψη Προσαρμοσμένων Φακέλων Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [GetFontFolders](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/getfontfolders/) ώστε να μπορείτε να εντοπίζετε φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` και φακέλους γραμματοσειρών του συστήματος.

Αυτός ο κώδικας C# δείχνει πώς να χρησιμοποιήσετε το [GetFontFolders](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/getfontfolders/) :

```c#
// Αυτή η γραμμή εμφανίζει τους φακέλους που ελέγχονται για αρχεία γραμματοσειρών.
// Αυτοί είναι οι φάκελοι που προστέθηκαν μέσω της μεθόδου LoadExternalFonts και οι φάκελοι γραμματοσειρών του συστήματος.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών που Χρησιμοποιούνται με την Παρουσίαση**

Το Aspose.Slides παρέχει την ιδιότητα [DocumentLevelFontSources](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/documentlevelfontsources/) ώστε να μπορείτε να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση.

Αυτός ο κώδικας C# δείχνει πώς να χρησιμοποιήσετε την ιδιότητα [DocumentLevelFontSources](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/documentlevelfontsources/) :

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Εργαστείτε με την παρουσίαση
    // Οι CustomFont1, CustomFont2 και οι γραμματοσειρές από τους φακέλους assets\fonts & global\fonts και τους υποφακέλους τους είναι διαθέσιμες στην παρουσίαση
}
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**

Το Aspose.Slides παρέχει τη μέθοδο [LoadExternalFont](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) ώστε να μπορείτε να φορτώνετε εξωτερικές γραμματοσειρές από δυαδικά δεδομένα.

Αυτός ο κώδικας C# δείχνει τη διαδικασία φόρτωσης γραμματοσειράς από πίνακα byte:

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // εξωτερική γραμματοσειρά φορτώνεται κατά τη διάρκεια της παρουσίασης
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **Συχνές Ερωτήσεις**

**Επηρεάζουν οι προσαρμοσμένες γραμματοσειρές την εξαγωγή σε όλες τις μορφές (PDF, PNG, SVG, HTML);**

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον renderer σε όλες τις μορφές εξαγωγής.

**Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο παραγόμενο PPTX;**

Όχι. Η καταχώριση μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωσή της σε αρχείο PPTX. Εάν χρειάζεστε τη γραμματοσειρά μέσα στο αρχείο παρουσίασης, πρέπει να χρησιμοποιήσετε ρητά τις [δυνατότητες ενσωμάτωσης](/slides/el/net/embedded-font/).

**Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικών γραμματοσειρών όταν μια προσαρμοσμένη γραμματοσειρά δεν περιέχει ορισμένα γλυφά;**

Ναι. Ρυθμίστε την [αντικατάσταση γραμματοσειρών](/slides/el/net/font-substitution/), τους [κανόνες αντικατάστασης](/slides/el/net/font-replacement/), και τα [σύνολα εναλλακτικών](/slides/el/net/fallback-font/) για να ορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν το ζητούμενο γλυφά λείπει.

**Μπορώ να χρησιμοποιήσω γραμματοσειρές σε περιβάλλοντα Linux/Docker χωρίς να τις εγκαταστήσω σε ολόκληρο το σύστημα;**

Ναι. Δείξτε στους δικούς σας φακέλους γραμματοσειρών ή φορτώστε τις γραμματοσειρές από πίνακες byte. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από φακέλους γραμματοσειρών του συστήματος στην εικόνα του κοντέινερ.

**Πώς είναι τα θέματα αδειοδότησης—μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;**

Είστε υπεύθυνοι για τη συμμόρφωση με τις άδειες χρήσης των γραμματοσειρών. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή την εμπορική χρήση. Πάντα εξετάζετε την ΕΣΧ (EULA) της γραμματοσειράς πριν διανείμετε τα αποτελέσματα.