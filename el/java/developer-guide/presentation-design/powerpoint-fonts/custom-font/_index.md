---
title: Προσαρμογή Γραμματοσειρών PowerPoint σε Java
linktitle: Προσαρμοσμένη Γραμματοσειρά
type: docs
weight: 20
url: /el/java/custom-font/
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
- Java
- Aspose.Slides
description: "Προσαρμόστε τις γραμματοσειρές στις διαφάνειες PowerPoint με το Aspose.Slides για Java ώστε οι παρουσιάσεις σας να είναι καθαρές και συνεπείς σε οποιαδήποτε συσκευή."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να χρησιμοποιείτε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαθιστάτε στο λειτουργικό σύστημα. Μπορείτε να φορτώνετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για μια συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών επιπέδου εγγράφου, ή να φορτώνετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά να διατηρείται συνεπές το αποτέλεσμα της παρουσίασης σε διαφορετικά περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να ελέγξετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να καθαρίσετε τη λανθάνουσα μνήμη (cache) γραμματοσειρών μετά τη χρήση εξωτερικών γραμματοσειρών.

Η καταχώριση προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ενσωμάτωση γραμματοσειρών σε αρχείο PPTX. Εάν μια γραμματοσειρά πρέπει να αποθηκευτεί μέσα στην παρουσίαση, χρησιμοποιήστε ρητά τις δυνατότητες ενσωμάτωσης γραμματοσειρών.

Ένα θέμα παρουσίασης μπορεί να αναφέρει διαφορετικές οικογένειες γραμματοσειρών για μεμονωμένα συστήματα γραφής. Αυτές οι αντιστοιχίσεις αποθηκεύουν ονόματα γραμματοσειρών αλλά δεν εγκαθιστούν ή φορτώνουν τα αρχεία γραμματοσειρών. Δείτε [Script-Specific Theme Fonts](/slides/el/java/script-specific-font-mappings/) για να διαχειριστείτε τις αντιστοιχίσεις και χρησιμοποιήστε τις παρακάτω επιλογές φόρτωσης για να καταστήσετε τις αναφερθέντες γραμματοσειρές διαθέσιμες για συνεπή απόδοση.

{{% alert color="info" title="Σημείωση" %}}

Aspose Slides σας επιτρέπει να φορτώνετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [loadExternalFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Γραμματοσειρές TrueType (.ttf) και TrueType Collection (.ttc). Δείτε [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Γραμματοσειρές OpenType (.otf). Δείτε [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Aspose.Slides σας επιτρέπει να φορτώνετε γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαθιστάτε στο σύστημα. Αυτό επηρεάζει το αποτέλεσμα της εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — ώστε τα τελικά έγγραφα να φαίνονται συνεπή σε όλα τα περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.
2. Καλέστε τη στατική μέθοδο [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) για να φορτώσετε γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Καλέστε [FontsLoader.clearCache](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsLoader#clearCache--) για να καθαρίσετε τη λανθάνουσα μνήμη (cache) γραμματοσειρών.

```java
import com.aspose.slides.*;

// Ορίστε φακέλους που περιέχουν προσαρμοσμένα αρχεία γραμματοσειρών.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Φορτώστε προσαρμοσμένες γραμματοσειρές από τους καθορισμένους φακέλους.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Αποδώστε/εξάγετε την παρουσίαση (π.χ. σε PDF, εικόνες ή άλλες μορφές) χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Καθαρίστε τη λανθάνουσα μνήμη (cache) γραμματοσειρών μετά το τέλος της εργασίας.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Σημείωση" %}}

Η [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά εκκίνησης των γραμματοσειρών. Οι γραμματοσειρές αρχικοποιούνται με αυτή τη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
2. Οι διαδρομές που φορτώθηκαν μέσω του [FontsLoader](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Λήψη Προσαρμοσμένων Φακέλων Γραμματοσειρών**

Ο Aspose.Slides παρέχει τη μέθοδο [getFontFolders](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#getFontFolders--) ώστε να μπορείτε να εντοπίσετε φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` και φακέλους γραμματοσειρών του συστήματος.

Αυτός ο κώδικας Java σας δείχνει πώς να χρησιμοποιήσετε την [getFontFolders](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Αυτή η γραμμή εμφανίζει τους φακέλους όπου αναζητούνται τα αρχεία γραμματοσειρών.
// Αυτοί είναι οι φάκελοι που προστέθηκαν μέσω της μεθόδου LoadExternalFonts και οι φάκελοι γραμματοσειρών του συστήματος.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών που Χρησιμοποιούνται με μια Παρουσίαση**

Ο Aspose.Slides παρέχει την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) ώστε να μπορείτε να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση.

Αυτός ο κώδικας Java σας δείχνει πώς να χρησιμοποιήσετε την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // Εργασία με την παρουσίαση
    // Οι CustomFont1, CustomFont2 και οι γραμματοσειρές από τους φακέλους assets\fonts & global\fonts και τους υποφακέλους τους είναι διαθέσιμες στην παρουσίαση
} finally {
    if (pres != null) pres.dispose();
}
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**

Ο Aspose.Slides παρέχει τη μέθοδο [loadExternalFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) ώστε να μπορείτε να φορτώσετε εξωτερικές γραμματοσειρές από δυαδικά δεδομένα.

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
        // εξωτερική γραμματοσειρά φορτώνεται κατά τη διάρκεια της παρουσίασης
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

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον renderer σε όλες τις μορφές εξαγωγής.

### Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο παραγόμενο PPTX;

Όχι. Η καταχώριση μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωσή της σε αρχείο PPTX. Εάν χρειάζεστε τη γραμματοσειρά εντός του αρχείου παρουσίασης, πρέπει να χρησιμοποιήσετε τις ρητές [ενσωματωτικές δυνατότητες](/slides/el/java/embedded-font/).

### Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικής (fallback) όταν μια προσαρμοσμένη γραμματοσειρά λείπουν ορισμένα γλυφικά;

Ναι. Διαμορφώστε την [font substitution](/slides/el/java/font-substitution/), τους [replacement rules](/slides/el/java/font-replacement/) και τα [fallback sets](/slides/el/java/fallback-font/) για να καθορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν το ζητούμενο γλυφί δεν υπάρχει.

### Μπορώ να χρησιμοποιήσω γραμματοσειρές σε κοντέινερ Linux/Docker χωρίς να τις εγκαταστήσω σε όλο το σύστημα;

Ναι. Δείξτε στους δικούς σας φακέλους γραμματοσειρών ή φορτώστε γραμματοσειρές από πίνακες byte. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από τους καταλόγους γραμματοσειρών του συστήματος στην εικόνα του κοντέινερ.

### Πώς είναι με τις άδειες—μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;

Είστε υπεύθυνοι για τη συμμόρφωση με τις άδειες χρήσης των γραμματοσείρων. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή εμπορική χρήση. Πάντα ελέγχετε τη Συμφωνία Εγγύησης Άδειας Χρήσης (EULA) της γραμματοσειράς προτού διανείμετε τα αποτελέσματα.