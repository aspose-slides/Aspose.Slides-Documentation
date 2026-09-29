---
title: Προσαρμογή γραμματοσειρών PowerPoint σε Java
linktitle: Προσαρμοσμένη γραμματοσειρά
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
description: "Προσαρμόστε τις γραμματοσειρές στις διαφάνειες PowerPoint με το Aspose.Slides για Java ώστε οι παρουσιάσεις σας να παραμένουν καθαρές και συνεπείς σε οποιαδήποτε συσκευή."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιείτε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαθιστάτε στο λειτουργικό σύστημα. Μπορείτε να φορτώνετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για μια συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών επιπέδου εγγράφου ή να φορτώνετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά να διατηρείται η έξοδος της παρουσίασης συνεπής σε διαφορετικά περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να επιθεωρήσετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να καθαρίσετε την κρυφή μνήμη γραμματοσειρών μετά τη χρήση εξωτερικών γραμματοσειρών.

Η καταχώριση προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ενσωμάτωση γραμματοσειρών σε αρχείο PPTX. Εάν μια γραμματοσειρά πρέπει να αποθηκευτεί εντός της παρουσίασης, χρησιμοποιήστε ρητά τις δυνατότητες ενσωμάτωσης γραμματοσειρών.

Ένα θέμα παρουσίασης μπορεί να αναφέρει διαφορετικές οικογένειες γραμματοσειρών για μεμονωμένα συστήματα γραφής. Αυτοί οι χάρτες αποθηκεύουν τα ονόματα των γραμματοσειρών αλλά δεν εγκαθιστούν ή φορτώνουν τα αρχεία γραμματοσειρών. Δείτε [Γραμματοσειρές Θέματος Κατά Σενάριο](/slides/el/java/script-specific-font-mappings/) για τη διαχείριση των χαρτών και χρησιμοποιήστε τις παρακάτω επιλογές φόρτωσης ώστε οι αναφερόμενες γραμματοσειρές να είναι διαθέσιμες για συνεπή απόδοση.

{{% alert color="info" title="Σημείωση" %}}
Το Aspose Slides σας επιτρέπει να φορτώνετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [loadExternalFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) και TrueType Collection (.ttc) γραμματοσειρές. Δείτε [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) γραμματοσειρές. Δείτε [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides σας επιτρέπει να φορτώνετε τις γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαθιστάτε στο σύστημα. Αυτό επηρεάζει την εξαγωγή—όπως σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές—ώστε τα παραγόμενα έγγραφα να φαίνονται συνεπή σε όλα τα περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.
2. Καλέστε τη στατική μέθοδο [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) για να φορτώσετε γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Καλέστε το [FontsLoader.clearCache](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#clearCache--) για να καθαρίσετε την κρυφή μνήμη γραμματοσειρών.

Το παρακάτω παράδειγμα κώδικα δείχνει τη διαδικασία φόρτωσης γραμματοσειρών:

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

    // Καθαρίστε την κρυφή μνήμη γραμματοσειρών μετά την ολοκλήρωση της εργασίας.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Σημείωση" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά εκκίνησης των γραμματοσειρών.
Οι γραμματοσειρές αρχικοποιούνται με αυτή τη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
1. Οι διαδρομές που φορτώνονται μέσω του [FontsLoader](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Λήψη Προσαρμοσμένων Φακέλων Γραμματοσειρών**
Το Aspose.Slides παρέχει τη μέθοδο [getFontFolders](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#getFontFolders--) ώστε να μπορείτε να εντοπίζετε φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` και φακέλους γραμματοσειρών του συστήματος.

Αυτός ο κώδικας Java δείχνει πώς να χρησιμοποιήσετε το [getFontFolders](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Αυτή η γραμμή εμφανίζει τους φακέλους όπου αναζητούνται αρχεία γραμματοσειρών.
// Αυτοί είναι οι φάκελοι που προστέθηκαν μέσω της μεθόδου LoadExternalFonts και οι φάκελοι γραμματοσειρών του συστήματος.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών που Χρησιμοποιούνται σε Παρουσίαση**
Το Aspose.Slides παρέχει την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) ώστε να μπορείτε να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να χρησιμοποιήσετε την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // Οι CustomFont1, CustomFont2 και οι γραμματοσειρές από τους φακέλους assets\fonts & global\fonts και τους υποφακέλους τους είναι διαθέσιμες στην παρουσίαση
} finally {
    if (pres != null) pres.dispose();
}
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**

Το Aspose.Slides παρέχει τη μέθοδο [loadExternalFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) ώστε να μπορείτε να φορτώνετε εξωτερικές γραμματοσειρές από δυαδικά δεδομένα.

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
        // η εξωτερική γραμματοσειρά φορτώνεται κατά τη διάρκεια της παρουσίασης
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
Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον αποδοτικό σε όλες τις μορφές εξαγωγής.

### Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο τελικό PPTX;
Όχι. Η καταχώριση μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωσή της σε PPTX. Εάν χρειάζεστε τη γραμματοσειρά να περιλαμβάνεται μέσα στο αρχείο παρουσίασης, πρέπει να χρησιμοποιήσετε τις ρητές [δυνατότητες ενσωμάτωσης](/slides/el/java/embedded-font/).

### Μπορώ να ελέγξω τη συμπεριφορά εφεδρείας όταν μια προσαρμοσμένη γραμματοσειρά λείπουν ορισμένα γλύφοι;
Ναι. Διαμορφώστε την [αντικατάσταση γραμματοσειρών](/slides/el/java/font-substitution/), τους [κανόνες αντικατάστασης](/slides/el/java/font-replacement/), και τα [σύνολα εφεδρείας](/slides/el/java/fallback-font/) για να ορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν λείπει το ζητούμενο γλύφη.

### Μπορώ να χρησιμοποιήσω γραμματοσειρές σε κοντέινερ Linux/Docker χωρίς να τις εγκαταστήσω στο σύστημα;
Μερικώς. Το Aspose.Slides μπορεί να χρησιμοποιεί γραμματοσειρές από δικούς σας φακέλους ή από πίνακες byte χωρίς εγκατάσταση, αλλά η υποστήριξη γραμματοσειρών της Java απαιτεί τουλάχιστον μία εγκατεστημένη γραμματοσειρά στην εικόνα. Χωρίς αυτή, η φόρτωση αποτυγχάνει με το σφάλμα «Fontconfig head is null, check your fonts or fonts configuration». Δείτε [Ανάπτυξη Γραμματοσειρών](/slides/el/java/deploy-fonts/).

### Τι γίνεται με την άδεια χρήσης—μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;
Είστε υπεύθυνοι για τη συμμόρφωση με τις άδειες των γραμματοσειρών. Οι όροι διαφέρουν· κάποιες άδειες απαγορεύουν την ενσωμάτωση ή τη εμπορική χρήση. Πάντα ελέγχετε την άδεια χρήσης (EULA) της γραμματοσειράς πριν διανείμετε τα αποτελέσματα.