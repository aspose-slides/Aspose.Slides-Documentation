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
description: "Προσαρμόστε τις γραμματοσειρές στις διαφάνειες PowerPoint με το Aspose.Slides για Java, ώστε οι παρουσιάσεις σας να παραμένουν καθαρές και συνεπείς σε οποιαδήποτε συσκευή."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιείτε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαταστήσετε στο λειτουργικό σύστημα. Μπορείτε να φορτώνετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για μια συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών σε επίπεδο εγγράφου, ή να φορτώνετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά να παραμένει η έξοδος της παρουσίασης συνεπής σε διαφορετικά περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να ελέγχετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να καθαρίζετε τη λανθάνουσα μνήμη (cache) των γραμματοσειρών μετά τη χρήση εξωτερικών γραμματοσειρών.

Η καταγραφή προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ενσωμάτωση γραμματοσειρών σε αρχείο PPTX. Εάν πρέπει μια γραμματοσειρά να αποθηκευτεί μέσα στην παρουσίαση, χρησιμοποιήστε ρητά τις λειτουργίες ενσωμάτωσης γραμματοσειρών.

{{% alert color="info" %}} 
Το Aspose Slides σας επιτρέπει να φορτώνετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [loadExternalFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Γραμματοσειρές TrueType (.ttf) και TrueType Collection (.ttc). Δείτε το [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Γραμματοσειρές OpenType (.otf). Δείτε το [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides σας επιτρέπει να φορτώνετε γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαταστήσετε στο σύστημα. Αυτό επηρεάζει το αποτέλεσμα εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — ώστε τα παραγόμενα έγγραφα να φαίνονται συνεπή σε διαφορετικά περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.
2. Καλέστε τη στατική μέθοδο [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) για να φορτώσετε γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Καλέστε τη [FontsLoader.clearCache](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsLoader#clearCache--) για να καθαρίζετε τη λανθάνουσα μνήμη των γραμματοσειρών.

Το παρακάτω παράδειγμα κώδικα δείχνει τη διαδικασία φόρτωσης των γραμματοσειρών:

```java
import com.aspose.slides.*;

// Ορίστε φακέλους που περιέχουν προσαρμοσμένα αρχεία γραμματοσειρών.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Φορτώστε προσαρμοσμένες γραμματοσειρές από τους καθορισμένους φακέλους.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Αποδόστε/εξαγάγετε την παρουσίαση (π.χ. σε PDF, εικόνες ή άλλες μορφές) χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Καθαρίστε τη λανθάνουσα μνήμη γραμματοσειρών μετά το τέλος της εργασίας.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά αρχικοποίησης των γραμματοσειρών.
Οι γραμματοσειρές αρχικοποιούνται με τη σειρά:
1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
1. Οι διαδρομές που φορτώθηκαν μέσω του [FontsLoader](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Λήψη Προσαρμοσμένων Φακέλων Γραμματοσειρών**
Το Aspose.Slides παρέχει τη μέθοδο [getFontFolders](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#getFontFolders--) για να μπορείτε να βρείτε φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` και τους φακέλους γραμματοσειρών του συστήματος.

Αυτός ο κώδικας Java σας δείχνει πώς να χρησιμοποιήσετε το [getFontFolders](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Αυτή η γραμμή εμφανίζει τους φακέλους όπου αναζητούνται τα αρχεία γραμματοσειρών.
// Αυτοί είναι οι φάκελοι που προστέθηκαν μέσω της μεθόδου LoadExternalFonts και οι φάκελοι γραμματοσειρών του συστήματος.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών που Χρησιμοποιούνται με Μια Παρουσίαση**
Το Aspose.Slides παρέχει την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) ώστε να μπορείτε να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση. 

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
    // CustomFont1, CustomFont2 και οι γραμματοσειρές από τους φακέλους assets\fonts & global\fonts και τους υποφακέλους τους είναι διαθέσιμες στην παρουσίαση
} finally {
    if (pres != null) pres.dispose();
}
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**

Το Aspose.Slides παρέχει τη μέθοδο [loadExternalFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) για να μπορείτε να φορτώνετε εξωτερικές γραμματοσειρές από δυαδικά δεδομένα.

Αυτός ο κώδικας Java δείχνει τη διαδικασία φόρτωσης γραμματοσειράς από πίνακα bytes:

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
        // εξωτερική γραμματοσειρά φορτωμένη κατά τη διάρκεια της παρουσίασης
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

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον αποδότη σε όλες τις μορφές εξαγωγής.

### Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο παραγόμενο PPTX;

Όχι. Η καταγραφή μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωσή της σε PPTX. Εάν χρειάζεστε τη γραμματοσειρά ενσωματωμένη μέσα στο αρχείο παρουσίασης, πρέπει να χρησιμοποιήσετε ρητά τις [λειτουργίες ενσωμάτωσης](/slides/el/java/embedded-font/).

### Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικού (fallback) όταν μια προσαρμοσμένη γραμματοσειρά δεν περιέχει ορισμένα γλύφη;

Ναι. Διαμορφώστε την [αντικατάσταση γραμματοσειρών](/slides/el/java/font-substitution/), τις [κανόνες αντικατάστασης](/slides/el/java/font-replacement/), και τα [σύνολα εναλλακτικών](/slides/el/java/fallback-font/) για να ορίζετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν λείπει το ζητούμενο γλύφη.

### Μπορώ να χρησιμοποιήσω γραμματοσειρές σε κοντέινερ Linux/Docker χωρίς να τις εγκαταστήσω σε ολόκληρο το σύστημα;

Ναι. Κατευθύνετε σε δικούς σας φακέλους γραμματοσειρών ή φορτώστε γραμματοσειρές από πίνακες bytes. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από τους φακούς γραμματοσειρών του συστήματος στην εικόνα του κοντέινερ.

### Πώς είναι η άδεια—μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;

Είστε υπεύθυνοι για τη συμμόρφωση με την άδεια χρήσης των γραμματοσειρών. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή την εμπορική χρήση. Πάντα ελέγχετε τη συμφωνία χρήσης (EULA) της γραμματοσειράς πριν διανείμετε τα αποτελέσματα.