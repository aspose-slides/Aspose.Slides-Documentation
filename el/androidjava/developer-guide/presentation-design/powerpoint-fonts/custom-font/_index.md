---
title: "Προσαρμογή Γραμματοσειρών PowerPoint σε Android"
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
description: "Προσαρμόστε τις γραμματοσειρές στις διαφάνειες PowerPoint με το Aspose.Slides για Android μέσω Java, ώστε οι παρουσιάσεις σας να παραμένουν καθαρές και συνεπείς σε οποιαδήποτε συσκευή."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιείτε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαθιστάτε στο λειτουργικό σύστημα. Μπορείτε να φορτώνετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για μια συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών επιπέδου εγγράφου ή να φορτώνετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν η παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά να διατηρείται η συνοχή της εξόδου της παρουσίασης σε διαφορετικά περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να ελέγξετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να αδειάσετε την κρυφή μνήμη γραμματοσειρών μετά από χρήση εξωτερικών γραμματοσειρών.

Η καταχώρηση προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ένθεση γραμματοσειρών σε αρχείο PPTX. Εάν χρειάζεται να αποθηκευτεί μια γραμματοσειρά μέσα στην ίδια την παρουσίαση, χρησιμοποιήστε τις λειτουργίες ένθεσης γραμματοσειρών ρητά.

{{% alert color="info" %}} 
Το Aspose Slides σας επιτρέπει να φορτώσετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [loadExternalFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) και TrueType Collection (.ttc) γραμματοσειρές. Δείτε το [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) γραμματοσειρές. Δείτε το [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides σας επιτρέπει να φορτώσετε γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαταστήσετε στο σύστημα. Αυτό επηρεάζει το αποτέλεσμα της εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — ώστε τα παραγόμενα έγγραφα να εμφανίζονται συνεπή σε όλα τα περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Ορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.
2. Καλέστε τη στατική μέθοδο [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) για να φορτώσετε τις γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Καλέστε τη μέθοδο [FontsLoader.clearCache](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/FontsLoader#clearCache--) για να αδειάσετε την κρυφή μνήμη γραμματοσειρών.

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

    // Αποδώστε/εξάγετε την παρουσίαση (π.χ. σε PDF, εικόνες ή άλλες μορφές) χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Αδειάστε την κρυφή μνήμη γραμματοσειρών μετά το τέλος της εργασίας.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά αρχικοποίησης των γραμματοσειρών.
Οι γραμματοσειρές αρχικοποιούνται με την ακόλουθη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
1. Οι διαδρομές που φορτώθηκαν μέσω του [FontsLoader](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Λήψη Προσαρμοσμένων Φακέλων Γραμματοσειρών**
Το Aspose.Slides παρέχει τη μέθοδο [getFontFolders](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) που σας επιτρέπει να βρείτε τους φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει τους φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` καθώς και τους φακέλους γραμματοσειρών του συστήματος.

Αυτός ο κώδικας Java δείχνει πώς να χρησιμοποιήσετε τη [getFontFolders](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Αυτή η γραμμή εμφανίζει τους φακέλους όπου αναζητούνται αρχεία γραμματοσειρών.
// Αυτοί είναι οι φάκελοι που προστίθενται μέσω της μεθόδου LoadExternalFonts και οι φάκελοι γραμματοσειρών του συστήματος.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών για Παρουσίαση**
Το Aspose.Slides παρέχει την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) που σας επιτρέπει να ορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση.

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
    // Εργασία με την παρουσίαση
    // Οι CustomFont1, CustomFont2 και οι γραμματοσειρές από τους φακέλους assets\fonts & global\fonts και τους υποφακέλους τους είναι διαθέσιμες στην παρουσίαση
} finally {
    if (pres != null) pres.dispose();
}
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**

Το Aspose.Slides παρέχει τη μέθοδο [loadExternalFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) που σας επιτρέπει να φορτώσετε εξωτερικές γραμματοσειρές από δυαδικά δεδομένα.

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

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον αποτυπωτή σε όλες τις μορφές εξαγωγής.

### Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο τελικό PPTX;

Όχι. Η καταχώρηση μιας γραμματοσειράς για απόδοση δεν ισοδυναμεί με την ενσωμάτωσή της σε ένα PPTX. Εάν χρειάζεται η γραμματοσειρά να είναι εντός του αρχείου παρουσίασης, πρέπει να χρησιμοποιήσετε ρητά τις [λειτουργίες ένθεσης](/slides/el/androidjava/embedded-font/).

### Μπορώ να ελέγξω τη συμπεριφορά υποκατάστασης όταν μια προσαρμοσμένη γραμματοσειρά λείπουν συγκεκριμένα γλυφία;

Ναι. Διαμορφώστε την [αντικατάσταση γραμματοσειρών](/slides/el/androidjava/font-substitution/), τους [κανόνες αντικατάστασης](/slides/el/androidjava/font-replacement/) και τα [σύνολα εφεδρείας](/slides/el/androidjava/fallback-font/) ώστε να καθορίζετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν λείπουν τα απαιτούμενα γλυφία.

### Μπορώ να χρησιμοποιήσω γραμματοσειρές σε περιβάλλοντα Linux/Docker χωρίς εγκατάσταση στο σύστημα;

Ναι. Καθορίστε τους δικούς σας φακέλους γραμματοσειρών ή φορτώστε τις γραμματοσειρές από πίνακες byte. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από τους καταλόγους γραμματοσειρών του συστήματος στην εικόνα του container.

### Τι γίνεται με την άδεια χρήσης — μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;

Είστε υπεύθυνοι για τη συμμόρφωση με τις άδειες χρήσης των γραμματοσειρών. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή την εμπορική χρήση. Πάντα ελέγχετε την ΕΣΔΑ (EULA) της γραμματοσειράς πριν διανείμετε τα παραγόμενα αρχεία.