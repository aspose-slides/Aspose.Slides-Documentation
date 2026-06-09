---
title: "Προσαρμογή γραμματοσειρών PowerPoint σε Java"
linktitle: "Προσαρμοσμένη γραμματοσειρά"
type: docs
weight: 20
url: /el/java/custom-font/
keywords:
  - "γραμματοσειρά"
  - "προσαρμοσμένη γραμματοσειρά"
  - "εξωτερική γραμματοσειρά"
  - "φόρτωση γραμματοσειράς"
  - "διαχείριση γραμματοσειρών"
  - "φάκελο γραμματοσειρών"
  - "PowerPoint"
  - "OpenDocument"
  - "παρουσίαση"
  - "Java"
  - "Aspose.Slides"
description: "Προσαρμόστε τις γραμματοσειρές στις διαφάνειες PowerPoint με το Aspose.Slides για Java ώστε οι παρουσιάσεις σας να παραμένουν καθαρές και συνεπείς σε οποιαδήποτε συσκευή."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να χρησιμοποιήσετε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαταστήσετε στο λειτουργικό σύστημα. Μπορείτε να φορτώσετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για μια συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών επιπέδου εγγράφου, ή να φορτώσετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά στη διατήρηση της συνέπειας του αποτελέσματος της παρουσίασης σε διαφορετικά περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να ελέγξετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να εκκαθαρίσετε τη λανθάνουσα μνήμη των γραμματοσειρών μετά τη χρήση εξωτερικών γραμματοσειρών.

Η καταχώριση προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ενσωμάτωση γραμματοσειρών σε αρχείο PPTX. Εάν μια γραμματοσειρά πρέπει να αποθηκευτεί μέσα στην παρουσίαση, χρησιμοποιήστε ρητά τις δυνατότητες ενσωμάτωσης γραμματοσειρών.

{{% alert color="primary" %}} 
Το Aspose Slides σας επιτρέπει να φορτώσετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [loadExternalFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Γραμματοσειρές TrueType (.ttf) και TrueType Collection (.ttc). Δείτε το [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Γραμματοσειρές OpenType (.otf). Δείτε το [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides σας επιτρέπει να φορτώσετε γραμματοσειρές που χρησιμοποιούνται σε παρουσίαση χωρίς να τις εγκαταστήσετε στο σύστημα. Αυτό επηρεάζει το αποτέλεσμα της εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — ώστε τα τελικά έγγραφα να φαίνονται συνεπή σε διαφορετικά περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.
2. Καλέστε τη static μέθοδο [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) για να φορτώσετε γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Καλέστε τη μέθοδο [FontsLoader.clearCache](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsLoader#clearCache--) για να εκκαθαρίσετε τη λανθάνουσα μνήμη των γραμματοσειρών.

Το παρακάτω παράδειγμα κώδικα δείχνει τη διαδικασία φόρτωσης γραμματοσειρών:

```java
// Ορίστε φακέλους που περιέχουν προσαρμοσμένα αρχεία γραμματοσειρών.
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

    // Καθαρίστε τη λανθάνουσα μνήμη των γραμματοσειρών αφού ολοκληρωθεί η εργασία.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά εκκίνησης των γραμματοσειρών.
Οι γραμματοσειρές αρχικοποιούνται με αυτή τη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
1. Οι διαδρομές που φορτώθηκαν μέσω του [FontsLoader](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Λήψη Προσαρμοσμένων Φακέλων Γραμματοσειρών**

Το Aspose.Slides παρέχει τη μέθοδο [getFontFolders](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#getFontFolders--) ώστε να μπορείτε να εντοπίσετε φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` και τους φακέλους γραμματοσειρών του συστήματος.

Αυτός ο κώδικας Java σας δείχνει πώς να χρησιμοποιήσετε το [getFontFolders](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Αυτή η γραμμή εμφανίζει φακέλους όπου αναζητούνται αρχεία γραμματοσειρών.
// Αυτοί είναι οι φάκελοι που προστέθηκαν μέσω της μεθόδου LoadExternalFonts και οι φάκελοι γραμματοσειρών του συστήματος.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών που Χρησιμοποιούνται με Παρουσίαση**

Το Aspose.Slides παρέχει την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) ώστε να μπορείτε να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση. 

Αυτός ο κώδικας Java σας δείχνει πώς να χρησιμοποιήσετε την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Εργαστείτε με την παρουσίαση
    // Το CustomFont1, το CustomFont2 και οι γραμματοσειρές από τους φακέλους assets\fonts & global\fonts και τους υποφακέλους τους είναι διαθέσιμες στην παρουσίαση
} finally {
    if (pres != null) pres.dispose();
}
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**

Το Aspose.Slides παρέχει τη μέθοδο [loadExternalFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) ώστε να μπορείτε να φορτώσετε εξωτερικές γραμματοσειρές από δυαδικά δεδομένα.

Αυτός ο κώδικας Java δείχνει τη διαδικασία φόρτωσης γραμματοσειράς από πίνακα bytes:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // εξωτερική γραμματοσειρά φορτώθηκε κατά τη διάρκεια της παρουσίασης
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

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον μηχανισμό απόδοσης σε όλες τις μορφές εξαγωγής.

**Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο τελικό PPTX;**

Όχι. Η καταχώριση μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωσή της σε αρχείο PPTX. Εάν χρειάζεται η γραμματοσειρά να μεταφερθεί μέσα στο αρχείο παρουσίασης, πρέπει να χρησιμοποιήσετε τις ρητές [δυνατότητες ενσωμάτωσης](/slides/el/java/embedded-font/).

**Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικής γραμματοσειράς όταν μια προσαρμοσμένη γραμματοσειρά λείπει ορισμένα γλύφους;**

Ναι. Διαμορφώστε την [αντικατάσταση γραμματοσειρών](/slides/el/java/font-substitution/), τους [κανόνες αντικατάστασης](/slides/el/java/font-replacement/) και τα [σύνολα εναλλακτικών](/slides/el/java/fallback-font/) για να ορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν λείπει το ζητούμενο γλύφο.

**Μπορώ να χρησιμοποιήσω γραμματοσειρές σε κοντέινερ Linux/Docker χωρίς να τις εγκαταστήσω σε επίπεδο συστήματος;**

Ναι. Δείξτε τους δικούς σας φακέλους γραμματοσειρών ή φορτώστε γραμματοσειρές από πίνακες bytes. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από τους φακέλους γραμματοσειρών του συστήματος στην εικόνα του κοντέινερ.

**Τι γίνεται με τις άδειες—μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;**

Είστε υπεύθυνοι για τη συμμόρφωση με τις άδειες των γραμματοσειρών. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή την εμπορική χρήση. Πάντα ελέγχετε την άδεια χρήσης (EULA) της γραμματοσειράς πριν διανείμετε τα αποτελέσματα.