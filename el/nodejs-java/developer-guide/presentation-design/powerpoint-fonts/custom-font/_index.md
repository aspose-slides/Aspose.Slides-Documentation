---
title: Προσαρμογή γραμματοσειρών PowerPoint σε JavaScript
linktitle: Προσαρμοσμένη Γραμματοσειρά
type: docs
weight: 20
url: /el/nodejs-java/custom-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Προσαρμόστε τις γραμματοσειρές στις διαφάνειες PowerPoint με JavaScript και Aspose.Slides για Node.js μέσω Java, ώστε οι παρουσιάσεις σας να παραμείνουν ευκρινείς και συνεπείς σε κάθε συσκευή."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να χρησιμοποιείτε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαταστήσετε στο λειτουργικό σύστημα. Μπορείτε να φορτώσετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για μια συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών επιπέδου εγγράφου, ή να φορτώσετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά στη διατήρηση της συνέπειας του αποτελέσματος της παρουσίασης σε διαφορετικά περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να εξετάσετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να καθαρίσετε την κρυφή μνήμη γραμματοσειρών μετά τη χρήση εξωτερικών γραμματοσειρών.

Η καταγραφή προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ενσωμάτωση γραμματοσειρών σε αρχείο PPTX. Εάν μια γραμματοσειρά πρέπει να αποθηκευτεί μέσα στην ίδια την παρουσίαση, χρησιμοποιήστε ρητά τις λειτουργίες ενσωμάτωσης γραμματοσειρών.

{{% alert color="primary" %}} 

Το Aspose Slides σάς επιτρέπει να φορτώσετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [loadExternalFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Γραμματοσειρές TrueType (.ttf) και TrueType Collection (.ttc). Δείτε το [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Γραμματοσειρές OpenType (.otf). Δείτε το [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Φόρτωση Προσαρμοσμένων Γραμματοσειρών**

Το Aspose.Slides σάς επιτρέπει να φορτώνετε γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαταστήσετε στο σύστημα. Αυτό επηρεάζει το εξαγόμενο αποτέλεσμα—όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές—ώστε τα τελικά έγγραφα να φαίνονται συνεπή σε διάφορα περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.  
2. Καλέστε τη στατική μέθοδο [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) για να φορτώσετε γραμματοσειρές από αυτούς τους φακέλους.  
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.  
4. Καλέστε το [FontsLoader.clearCache](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/clearcache/) για να εκκαθαρίσετε την κρυφή μνήμη γραμματοσειρών.

Το παρακάτω παράδειγμα κώδικα δείχνει τη διαδικασία φόρτωσης γραμματοσειράς:

```js
// Ορίστε τους φακέλους που περιέχουν προσαρμοσμένα αρχεία γραμματοσειρών.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Φορτώστε προσαρμοσμένες γραμματοσειρές από τους καθορισμένους φακέλους.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Αποδώστε/εξάγετε την παρουσίαση (π.χ. σε PDF, εικόνες ή άλλες μορφές) χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Καθαρίστε την κρυφή μνήμη γραμματοσειρών μετά την ολοκλήρωση της εργασίας.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

Η [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά εκκίνησης των γραμματοσειρών.  
Οι γραμματοσειρές αρχικοποιούνται με την ακόλουθη σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.  
1. Οι διαδρομές που φορτώνονται μέσω του [FontsLoader](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Λήψη Φακέλου Προσαρμοσμένων Γραμματοσειρών**
Το Aspose.Slides παρέχει τη μέθοδο [getFontFolders](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) ώστε να μπορείτε να βρείτε φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` και φακέλους γραμματοσειρών του συστήματος.

Αυτός ο κώδικας JavaScript δείχνει πώς να χρησιμοποιήσετε τη [getFontFolders](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
// Αυτή η γραμμή εμφανίζει τους φακέλους όπου αναζητούνται αρχεία γραμματοσειρών.
// Αυτοί είναι οι φάκελοι που προστέθηκαν μέσω της μεθόδου LoadExternalFonts και οι φάκελοι γραμματοσειρών του συστήματος.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Καθορισμός Προσαρμοσμένων Γραμματοσειρών που Χρησιμοποιούνται με την Παρουσίαση**
Το Aspose.Slides παρέχει την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) ώστε να μπορείτε να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση.

Αυτός ο κώδικας JavaScript δείχνει πώς να χρησιμοποιήσετε την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Εργαστείτε με την παρουσίαση
    // Οι CustomFont1, CustomFont2 και οι γραμματοσειρές από τους φακέλους assets\fonts & global\fonts και τους υποφακέλους τους είναι διαθέσιμες στην παρουσίαση
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Διαχείριση Γραμματοσειρών Εξωτερικά**

Το Aspose.Slides παρέχει τη μέθοδο [loadExternalFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) ώστε να μπορείτε να φορτώσετε εξωτερικές γραμματοσειρές από δυαδικά δεδομένα.

Αυτός ο κώδικας JavaScript επιδεικνύει τη διαδικασία φόρτωσης γραμματοσειράς από πίνακα byte:

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // εξωτερική γραμματοσειρά φορτώνεται κατά τη διάρκεια της παρουσίασης
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **Συχνές Ερωτήσεις**

**Επηρεάζουν οι προσαρμοσμένες γραμματοσειρές την εξαγωγή σε όλες τις μορφές (PDF, PNG, SVG, HTML);**

Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον καταχωρητή σε όλες τις μορφές εξαγωγής.

**Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο τελικό PPTX;**

Όχι. Η καταγραφή μιας γραμματοσειράς για απόδοση δεν είναι ίδια με την ενσωμάτωσή της σε ένα PPTX. Εάν χρειάζεστε τη γραμματοσειρά εντός του αρχείου παρουσίασης, πρέπει να χρησιμοποιήσετε τις ρητές [λειτουργίες ενσωμάτωσης](/slides/el/nodejs-java/embedded-font/).

**Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικής γραμματοσειράς όταν μια προσαρμοσμένη γραμματοσειρά λείπουν κάποια σύμβολα;**

Ναι. Διαμορφώστε την [αντικατάσταση γραμματοσειρών](/slides/el/nodejs-java/font-substitution/), τους [κανόνες αντικατάστασης](/slides/el/nodejs-java/font-replacement/) και τα [σύνολα εναλλακτικών](/slides/el/nodejs-java/fallback-font/) για να ορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν λείπει το ζητούμενο σύμβολο.

**Μπορώ να χρησιμοποιήσω γραμματοσειρές σε κοντέινερ Linux/Docker χωρίς να τις εγκαταστήσω σε ολόκληρο το σύστημα;**

Ναι. Δείξτε στους δικούς σας φακέλους γραμματοσειρών ή φορτώστε γραμματοσειρές από πίνακες byte. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από τους φακέλους γραμματοσειρών του συστήματος στην εικόνα του κοντέινερ.

**Τι γίνεται με την αδειοδότηση — μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;**

Είστε υπεύθυνοι για τη συμμόρφωση με την αδειοδότηση των γραμματοσειρών. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή τη εμπορική χρήση. Πάντα ελέγχετε τη συμφωνία χρήσης (EULA) της γραμματοσειράς πριν διανείμετε τα αποτελέσματα.