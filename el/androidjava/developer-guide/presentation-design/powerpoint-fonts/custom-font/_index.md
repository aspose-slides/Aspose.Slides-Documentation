---
title: "Προσαρμογή γραμματοσειρών PowerPoint σε Android"
linktitle: "Προσαρμοσμένη γραμματοσειρά"
type: docs
weight: 20
url: /el/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "Προσαρμόστε τις γραμματοσειρές στις διαφάνειες PowerPoint με το Aspose.Slides για Android μέσω Java ώστε οι παρουσιάσεις σας να παραμένουν ευκρινείς και συνεπείς σε οποιαδήποτε συσκευή."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαταστήσετε στο λειτουργικό σύστημα. Μπορείτε να φορτώσετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για μια συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών επιπέδου εγγράφου, ή να φορτώσετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά να διατηρείται η έξοδος της παρουσίασης συνεπής μεταξύ διαφορετικών περιβαλλοντών. Το άρθρο εξηγεί επίσης πώς να ελέγξετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να καθαρίσετε τη μνήμη cache των γραμματοσειρών μετά τη χρήση εξωτερικών γραμματοσειρών.

Η εγγραφή προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ενσωμάτωση γραμματοσειρών σε ένα αρχείο PPTX. Εάν μια γραμματοσειρά πρέπει να αποθηκευτεί μέσα στην ίδια την παρουσίαση, χρησιμοποιήστε ρητά τις δυνατότητες ενσωμάτωσης γραμματοσειρών.

{{% alert color="primary" %}} 
Aspose Slides σάς επιτρέπει να φορτώσετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [loadExternalFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) και TrueType Collection (.ttc) γραμματοσειρές. Δείτε [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) γραμματοσειρές. Δείτε [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides σάς επιτρέπει να φορτώνετε γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαταστήσετε στο σύστημα. Αυτό επηρεάζει την έξοδο εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — ώστε τα προκύπτοντα έγγραφα να φαίνονται συνεπή μεταξύ περιβαλλόντων. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.
2. Καλέστε τη στατική μέθοδο [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) για να φορτώσετε γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Καλέστε το [FontsLoader.clearCache](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontsLoader#clearCache--) για να καθαρίσετε την κρυφή μνήμη (cache) των γραμματοσειρών.

Το παρακάτω παράδειγμα κώδικα δείχνει τη διαδικασία φόρτωσης γραμματοσειρών:

```java
// Ορίστε φακέλους που περιέχουν προσαρμοσμένα αρχεία γραμματοσειρών.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Φορτώστε προσαρμοσμένες γραμματοσειρές από τους καθορισμένους φακέλους.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Αποδώστε/εξάγετε την παρουσίαση (π.χ. σε PDF, εικόνες ή άλλες μορφές) χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Καθαρίστε τη μνήμη cache των γραμματοσειρών μετά το τέλος της εργασίας.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Σημείωση" %}}
Η [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά αρχικοποίησης των γραμματοσειρών.
Οι γραμματοσειρές αρχικοποιούνται με αυτή τη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
1. Οι διαδρομές που φορτώνονται μέσω του [FontsLoader](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Λήψη Προσαρμοσμένων Φακέλων Γραμματοσειρών**
Το Aspose.Slides παρέχει τη μέθοδο [getFontFolders](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) που σας επιτρέπει να βρείτε φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` και φακέλους γραμματοσειρών του συστήματος.

Αυτός ο κώδικας Java σας δείχνει πώς να χρησιμοποιήσετε το [getFontFolders](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Αυτή η γραμμή εμφανίζει τους φακέλους όπου αναζητούνται τα αρχεία γραμματοσειρών.
// Αυτοί είναι φάκελοι που προστέθηκαν μέσω της μεθόδου LoadExternalFonts και φάκελοι γραμματοσειρών του συστήματος.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών για Παρουσίαση**
Το Aspose.Slides παρέχει την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) που σας επιτρέπει να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση.

Αυτός ο κώδικας Java σας δείχνει πώς να χρησιμοποιήσετε την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Εργαστείτε με την παρουσίαση
    // Οι CustomFont1, CustomFont2 και οι γραμματοσειρές από τους φακέλους assets\fonts & global\fonts και τους υποφακέλους τους είναι διαθέσιμες στην παρουσίαση
} finally {
    if (pres != null) pres.dispose();
}
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**

Το Aspose.Slides παρέχει τη μέθοδο [loadExternalFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) που σας επιτρέπει να φορτώσετε εξωτερικές γραμματοσειρές από δυαδικά δεδομένα.

Αυτός ο κώδικας Java δείχνει τη διαδικασία φόρτωσης γραμματοσειράς από πίνακα byte:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // εξωτερική γραμματοσειρά που φορτώνεται κατά τη διάρκεια ζωής της παρουσίασης
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **Συχνές Ερωτήσεις**

**Επηρεάζουν οι προσαρμοσμένες γραμματοσειρές την εξαγωγή σε όλες τις μορφές (PDF, PNG, SVG, HTML);**

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον renderer σε όλες τις μορφές εξαγωγής.

**Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο παραγόμενο PPTX;**

Όχι. Η καταγραφή μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωσή της σε ένα PPTX. Εάν χρειάζεστε τη γραμματοσειρά ενσωματωμένη στο αρχείο παρουσίασης, πρέπει να χρησιμοποιήσετε ρητά τις [δυνατότητες ενσωμάτωσης](/slides/el/androidjava/embedded-font/).

**Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικής επιλογής όταν μια προσαρμοσμένη γραμματοσειρά λείπουν ορισμένα γλύφους;**

Ναι. Διαμορφώστε την [font substitution](/slides/el/androidjava/font-substitution/), τους [replacement rules](/slides/el/androidjava/font-replacement/) και τα [fallback sets](/slides/el/androidjava/fallback-font/) για να ορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν λείπει το ζητούμενο γλύφο.

**Μπορώ να χρησιμοποιήσω γραμματοσειρές σε κοντέινερ Linux/Docker χωρίς να τις εγκαταστήσω παγκοσμίως στο σύστημα;**

Ναι. Κατευθύνετε σε δικούς σας φακέλους γραμματοσειρών ή φορτώστε γραμματοσειρές από πίνακες byte. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από τους καταλόγους συστήματος γραμματοσειρών στην εικόνα του κοντέινερ.

**Τι γίνεται με τις άδειες—μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;**

Είστε υπεύθυνοι για τη συμμόρφωση με τις άδειες των γραμματοσειρών. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή τη εμπορική χρήση. Πάντα ελέγξτε το EULA της γραμματοσειράς πριν διανείμετε τα αποτελέσματα.