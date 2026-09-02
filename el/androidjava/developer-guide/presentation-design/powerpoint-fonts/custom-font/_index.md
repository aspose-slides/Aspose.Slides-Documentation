---
title: Προσαρμογή γραμματοσειρών PowerPoint σε Android
linktitle: Προσαρμοσμένη γραμματοσειρά
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
description: "Προσαρμόστε τις γραμματοσειρές στις διαφάνειες PowerPoint με το Aspose.Slides για Android μέσω Java ώστε οι παρουσιάσεις σας να παραμένουν σαφείς και συνεπείς σε οποιαδήποτε συσκευή."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιείτε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαταστήσετε στο λειτουργικό σύστημα. Μπορείτε να φορτώσετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για μια συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών σε επίπεδο εγγράφου, ή να φορτώσετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά να διατηρηθεί η έξοδος της παρουσίασης συνεπής σε διαφορετικά περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να ελέγξετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να καθαρίσετε τη λανθάνουσα μνήμη (cache) των γραμματοσειρών μετά τη χρήση εξωτερικών γραμματοσειρών.

Η καταχώριση προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ενσωμάτωση γραμματοσειρών σε αρχείο PPTX. Εάν χρειάζεται μια γραμματοσειρά να αποθηκευτεί μέσα στην ίδια την παρουσίαση, χρησιμοποιήστε ρητά τις δυνατότητες ενσωμάτωσης γραμματοσειρών.

Ένα θέμα παρουσίασης μπορεί να αναφέρει διαφορετικές οικογένειες γραμματοσειρών για μεμονωμένα συστήματα γραφής. Αυτές οι αντιστοιχίσεις αποθηκεύουν ονόματα γραμματοσειρών αλλά δεν εγκαθιστούν ή φορτώνουν τα αρχεία γραμματοσειρών. Δείτε [Script-Specific Theme Fonts](/slides/el/androidjava/script-specific-font-mappings/) για να διαχειριστείτε τις αντιστοιχίσεις και χρησιμοποιήστε τις παρακάτω επιλογές φόρτωσης ώστε οι αναφερόμενες γραμματοσειρές να είναι διαθέσιμες για συνεπή απόδοση.

{{% alert color="info" title="Σημείωση" %}}

Το Aspose Slides σας επιτρέπει να φορτώσετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [loadExternalFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) και TrueType Collection (.ttc) γραμματοσειρές. Δείτε το [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) γραμματοσειρές. Δείτε το [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides σας επιτρέπει να φορτώνετε τις γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαταστήσετε στο σύστημα. Αυτό επηρεάζει την έξοδο της εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — ώστε τα προκύπτοντα έγγραφα να φαίνονται συνεπή σε όλα τα περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.
2. Καλέστε τη στατική μέθοδο [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) για να φορτώσετε τις γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Καλέστε [FontsLoader.clearCache](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontsLoader#clearCache--) για να καθαρίσετε τη λανθάνουσα μνήμη των γραμματοσειρών.

Το παρακάτω παράδειγμα κώδικα δείχνει τη διαδικασία φόρτωσης γραμματοσειρών:

```java
import com.aspose.slides.*;

// Ορίστε φακέλους που περιέχουν προσαρμοσμένα αρχεία γραμματοσειρών.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Φορτώστε προσαρμοσμένες γραμματοσειρές από τους καθορισμένους φακέλους.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Αποδώστε/εξάγετε την παρουσίαση (π.χ., σε PDF, εικόνες ή άλλες μορφές) χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Καθαρίστε τη λανθάνουσα μνήμη των γραμματοσειρών μετά το πέρας της εργασίας.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Σημείωση" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά εκκίνησης των γραμματοσειρών. Οι γραμματοσειρές εκκινούνται με αυτή τη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
1. Οι διαδρομές που φορτώθηκαν μέσω του [FontsLoader](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Λήψη Προσαρμοσμένων Φακέλων Γραμματοσειρών**
Το Aspose.Slides παρέχει τη μέθοδο [getFontFolders](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) ώστε να μπορείτε να εντοπίζετε φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` καθώς και τους φακέλους γραμματοσειρών του συστήματος.

Αυτός ο κώδικας Java δείχνει πώς να χρησιμοποιήσετε το [getFontFolders](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Αυτή η γραμμή εμφανίζει φακέλους όπου αναζητούνται αρχεία γραμματοσειρών.
// Αυτοί είναι οι φάκελοι που προστέθηκαν μέσω της μεθόδου LoadExternalFonts και οι φάκελοι γραμματοσειρών του συστήματος.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών για Μια Παρουσίαση**
Το Aspose.Slides παρέχει την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) ώστε να μπορείτε να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να χρησιμοποιήσετε την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Εργαστείτε με την παρουσίαση
    // CustomFont1, CustomFont2 και οι γραμματοσειρές από τους φακέλους assets\fonts & global\fonts και τους υποφακέλους τους είναι διαθέσιμες στην παρουσίαση
} finally {
    if (pres != null) pres.dispose();
}
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**

Το Aspose.Slides παρέχει τη μέθοδο [loadExternalFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) ώστε να μπορείτε να φορτώσετε εξωτερικές γραμματοσειρές από δυαδικά δεδομένα.

Αυτός ο κώδικας Java δείχνει τη διαδικασία φόρτωσης γραμματοσειράς από πίνακα byte:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // εξωτερική γραμματοσειρά φορτωμένη κατά τη διάρκεια της ζωής της παρουσίασης
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **Συχνές Ερωτήσεις**

### Επηρεάζουν οι προσαρμοσμένες γραμματοσειρές την εξαγωγή σε όλες τις μορφές (PDF, PNG, SVG, HTML);

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον αποδοτικό (renderer) για όλες τις μορφές εξαγωγής.

### Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο τελικό PPTX;

Όχι. Η καταχώριση μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωσή της σε PPTX. Εάν χρειάζεται η γραμματοσειρά να μεταφερθεί μέσα στο αρχείο παρουσίασης, πρέπει να χρησιμοποιήσετε ρητά τις [δυνατότητες ενσωμάτωσης](/slides/el/androidjava/embedded-font/).

### Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικών (fallback) όταν μια προσαρμοσμένη γραμματοσειρά λείπουν ορισμένα γλυφά;

Ναι. Διαμορφώστε την [αντικατάσταση γραμματοσειρών](/slides/el/androidjava/font-substitution/), τους [κανόνες αντικατάστασης](/slides/el/androidjava/font-replacement/) και τα [σύνολα εναλλακτικών](/slides/el/androidjava/fallback-font/) ώστε να ορίζετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιείται όταν λείπει το ζητούμενο γλυφά.

### Μπορώ να χρησιμοποιήσω γραμματοσειρές σε περιβάλλοντα Linux/Docker χωρίς να τις εγκαταστήσω σε όλο το σύστημα;

Ναι. Κατευθύνετε σε δικούς σας φακέλους γραμματοσειρών ή φορτώστε γραμματοσειρές από πίνακες byte. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από τους καταλόγους γραμματοσειρών του συστήματος στην εικόνα του container.

### Τι γίνεται με την άδεια χρήσης—μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;

Είστε υπεύθυνοι για τη συμμόρφωση με τις άδειες χρήσης των γραμματοσειρών. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή εμπορική χρήση. Πάντα ελέγχετε την ΕΣΑ (EULA) της γραμματοσειράς πριν διανείμετε τα αποτελέσματα.