---
title: "Προσαρμογή γραμματοσειρών PowerPoint σε .NET"
linktitle: "Προσαρμοσμένη γραμματοσειρά"
type: docs
weight: 20
url: /el/net/custom-font/
keywords:
- "γραμματοσειρά"
- "προσαρμοσμένη γραμματοσειρά"
- "εξωτερική γραμματοσειρά"
- "φόρτωση γραμματοσειράς"
- "διαχείριση γραμματοσειρών"
- "φάκελος γραμματοσειρών"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Προσαρμόστε τις γραμματοσειρές σε διαφάνειες PowerPoint με το Aspose.Slides για .NET ώστε οι παρουσιάσεις σας να παραμένουν καθαρές και συνεπείς σε οποιαδήποτε συσκευή."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να χρησιμοποιείτε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαταστήσετε στο λειτουργικό σύστημα. Μπορείτε να φορτώνετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για μια συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών επιπέδου εγγράφου, ή να φορτώνετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά στη διατήρηση της συνέπειας του αποτελέσματος της παρουσίασης σε διαφορετικά περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να ελέγξετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να εκκαθαρίσετε την κρυφή μνήμη γραμματοσειρών μετά τη χρήση εξωτερικών γραμματοσειρών.

Η καταχώριση προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ενσωμάτωση γραμματοσειρών σε αρχείο PPTX. Εάν μια γραμματοσειρά πρέπει να αποθηκευτεί μέσα στην παρουσίαση, χρησιμοποιήστε ρητά τις λειτουργίες ενσωμάτωσης γραμματοσειρών.

Ένα θέμα παρουσίασης μπορεί να αναφέρει διαφορετικές οικογένειες γραμματοσειρών για μεμονωμένα συστήματα γραφής. Αυτές οι αντιστοιχίσεις αποθηκεύουν ονόματα γραμματοσειρών αλλά δεν εγκαθιστούν ή φορτώνουν τα αρχεία γραμματοσειρών. Δείτε το [Script-Specific Theme Fonts](/slides/el/net/script-specific-font-mappings/) για να διαχειριστείτε τις αντιστοιχίσεις και χρησιμοποιήστε τις παρακάτω επιλογές φόρτωσης ώστε οι αναφερόμενες γραμματοσειρές να είναι διαθέσιμες για συνεπή απόδοση.

{{% alert color="info" title="Note" %}}

Το Aspose Slides σας επιτρέπει να φορτώνετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) και TrueType Collection (.ttc) γραμματοσειρές. Δείτε το [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) γραμματοσειρές. Δείτε το [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides σάς επιτρέπει να φορτώνετε γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαταστήσετε στο σύστημα. Αυτό επηρεάζει το αποτέλεσμα της εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — ώστε τα παραγόμενα έγγραφα να φαίνονται συνεπή σε διαφορετικά περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.
2. Καλέστε τη στατική μέθοδο [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfonts/) για να φορτώσετε τις γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Καλέστε το [FontsLoader.ClearCache](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/clearcache/) για να εκκαθαρίσετε την κρυφή μνήμη γραμματοσειρών.

Το παρακάτω παράδειγμα κώδικα δείχνει τη διαδικασία φόρτωσης γραμματοσειρών:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Ορίστε φακέλους που περιέχουν προσαρμοσμένα αρχεία γραμματοσειρών.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Φορτώστε προσαρμοσμένες γραμματοσειρές από τους καθορισμένους φακέλους.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Αποδώστε/εξάγετε την παρουσίαση (π.χ. σε PDF, εικόνες ή άλλες μορφές) χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Καθαρίστε την κρυφή μνήμη γραμματοσειρών μετά το τέλος της εργασίας.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

Το [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfonts/) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά αρχικοποίησης των γραμματοσειρών.  
Οι γραμματοσειρές αρχικοποιούνται με αυτή τη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
2. Οι διαδρομές που φορτώνονται μέσω του [FontsLoader](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Λήψη Προσαρμοσμένων Φακέλων Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [GetFontFolders](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/getfontfolders/) για να σας επιτρέψει να εντοπίσετε φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` καθώς και τους φακέλους γραμματοσειρών του συστήματος.

Αυτός ο κώδικας C# δείχνει πώς να χρησιμοποιήσετε το [GetFontFolders](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Αυτή η γραμμή εμφανίζει τους φακέλους που ελέγχονται για αρχεία γραμματοσειρών.
// Αυτοί είναι οι φάκελοι που προστέθηκαν μέσω της μεθόδου LoadExternalFonts και οι φάκελοι γραμματοσειρών του συστήματος.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Καθορίστε Προσαρμοσμένες Γραμματοσειρές που Χρησιμοποιούνται με μια Παρουσίαση**

Το Aspose.Slides παρέχει την ιδιότητα [DocumentLevelFontSources](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/documentlevelfontsources/) ώστε να μπορείτε να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση.

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
    // Οι CustomFont1, CustomFont2 και οι γραμματοσειρές από τους φακέλους assets\fonts & global\fonts και τους υποφακέλους τους είναι διαθέσιμες στην παρουσίαση
}
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**

Το Aspose.Slides παρέχει τη μέθοδο [LoadExternalFont](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) ώστε να μπορείτε να φορτώσετε εξωτερικές γραμματοσειρές από δυαδικά δεδομένα.

Αυτός ο κώδικας C# δείχνει τη διαδικασία φόρτωσης γραμματοσειράς από πίνακα byte: 

```c#
using Aspose.Slides;

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

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Επηρεάζουν οι προσαρμοσμένες γραμματοσειρές την εξαγωγή σε όλες τις μορφές (PDF, PNG, SVG, HTML);**

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον renderer σε όλες τις μορφές εξαγωγής.

**Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο τελικό PPTX;**

Όχι. Η καταχώριση μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωσή της σε PPTX. Εάν χρειάζεται η γραμματοσειρά να μεταφέρεται μέσα στο αρχείο παρουσίασης, πρέπει να χρησιμοποιήσετε ρητά τις [λειτουργίες ενσωμάτωσης](/slides/el/net/embedded-font/).

**Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικής γραμματοσειράς όταν μια προσαρμοσμένη γραμματοσειρά λείπουν ορισμένα γλυφά;**

Ναι. Διαμορφώστε την [αντικατάσταση γραμματοσειρών](/slides/el/net/font-substitution/), τους [κανόνες αντικατάστασης](/slides/el/net/font-replacement/) και τα [σύνολα εναλλακτικών](/slides/el/net/fallback-font/) ώστε να ορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιείται όταν το απαιτούμενο γλυφά λείπει.

**Μπορώ να χρησιμοποιήσω γραμματοσειρές σε περιβάλλοντα Linux/Docker χωρίς να τις εγκαταστήσω σε επίπεδο συστήματος;**

Ναι. Δείξτε στους δικούς σας φακέλους γραμματοσειρών ή φορτώστε τις γραμματοσειρές από πίνακες byte. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από τους φακέλους γραμματοσειρών του συστήματος στην εικόνα του container.

> **Σημείωση για Linux/Docker**: Κατά την κλήση του `FontsLoader.LoadExternalFonts`, βεβαιωθείτε ότι κάθε καταχώρηση στον πίνακα `directories` περιέχει μια μη κενή διαδρομή σε υπάρχον φάκελο. Εάν μια μεταβλητή περιβάλλοντος που χρησιμοποιείται για τη δημιουργία διαδρομής γραμματοσειράς δεν είναι ορισμένη ή είναι κενή, το Aspose.Slides μπορεί να προσπαθήσει να ερμηνεύσει την κενή τιμή ως πλήρη διαδρομή, με αποτέλεσμα το `System.ArgumentException`.

**Πώς είναι η άδεια—μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;**

Είστε υπεύθυνοι για τη συμμόρφωση με την άδεια χρήσης των γραμματοσειρών. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή τη εμπορική χρήση. Πάντα ελέγχετε τη συμφωνία χρήσης (EULA) της γραμματοσειράς πριν διανείμετε τα αποτελέσματα.