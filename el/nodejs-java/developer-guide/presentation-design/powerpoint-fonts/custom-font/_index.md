---
title: Προσαρμογή γραμματοσειρών PowerPoint σε JavaScript
linktitle: Προσαρμοσμένη γραμματοσειρά
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
description: "Προσαρμόστε τις γραμματοσειρές στις διαφάνειες PowerPoint με JavaScript και Aspose.Slides για Node.js μέσω Java για να διατηρήσετε τις παρουσιάσεις σας καθαρές και συνεπείς σε οποιαδήποτε συσκευή."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να χρησιμοποιείτε προσαρμοσμένες γραμματοσειρές σε παρουσιάσεις χωρίς να τις εγκαταστήσετε στο λειτουργικό σύστημα. Μπορείτε να φορτώνετε γραμματοσειρές από προσαρμοσμένους φακέλους, να παρέχετε γραμματοσειρές για μια συγκεκριμένη παρουσίαση μέσω πηγών γραμματοσειρών επιπέδου εγγράφου, ή να φορτώνετε εξωτερικές γραμματοσειρές απευθείας από δυαδικά δεδομένα.

Οι φορτωμένες γραμματοσειρές χρησιμοποιούνται όταν μια παρουσίαση αποδίδεται ή εξάγεται, για παράδειγμα σε PDF, εικόνες και άλλες υποστηριζόμενες μορφές. Αυτό βοηθά να διατηρείται το αποτέλεσμα της παρουσίασης συνεπές σε διάφορα περιβάλλοντα. Το άρθρο εξηγεί επίσης πώς να ελέγξετε τους φακέλους γραμματοσειρών που χρησιμοποιεί το Aspose.Slides και πώς να καθαρίσετε την κρυφή μνήμη γραμματοσειρών μετά τη χρήση εξωτερικών γραμματοσειρών.

Η καταχώριση προσαρμοσμένων γραμματοσειρών για απόδοση είναι ξεχωριστή από την ενσωμάτωση γραμματοσειρών σε αρχείο PPTX. Εάν μια γραμματοσειρά πρέπει να αποθηκευτεί μέσα στην παρουσίαση, χρησιμοποιήστε ρητά τις λειτουργίες ενσωμάτωσης γραμματοσειρών.

Ένα θέμα παρουσίασης μπορεί να παραπέμπει σε διαφορετικές οικογένειες γραμματοσειρών για μεμονωμένα συστήματα γραφής. Αυτοί οι χάρτες αποθηκεύουν τα ονόματα των γραμματοσειρών αλλά δεν εγκαθιστούν ή φορτώνουν τα αρχεία γραμματοσειρών. Δείτε το [Script-Specific Theme Fonts](/slides/el/nodejs-java/script-specific-font-mappings/) για τη διαχείριση των χαρτών και χρησιμοποιήστε τις παρακάτω επιλογές φόρτωσης ώστε οι παραπέμποντες γραμματοσειρές να είναι διαθέσιμες για συνεπή απόδοση.

{{% alert color="info" title="Σημείωση" %}}
Το Aspose Slides σας επιτρέπει να φορτώσετε αυτές τις γραμματοσειρές χρησιμοποιώντας τη μέθοδο [loadExternalFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Γραμματοσειρές TrueType (.ttf) και TrueType Collection (.ttc). Δείτε το [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Γραμματοσειρές OpenType (.otf). Δείτε το [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Φόρτωση προσαρμοσμένων γραμματοσειρών**

Το Aspose.Slides σάς επιτρέπει να φορτώνετε τις γραμματοσειρές που χρησιμοποιούνται σε μια παρουσίαση χωρίς να τις εγκαταστήσετε στο σύστημα. Αυτό επηρεάζει το αποτέλεσμα της εξαγωγής — όπως PDF, εικόνες και άλλες υποστηριζόμενες μορφές — ώστε τα παραγόμενα έγγραφα να φαίνονται συνεπή σε διαφορετικά περιβάλλοντα. Οι γραμματοσειρές φορτώνονται από προσαρμοσμένους καταλόγους.

1. Καθορίστε έναν ή περισσότερους φακέλους που περιέχουν τα αρχεία γραμματοσειρών.
2. Καλέστε τη στατική μέθοδο [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) για να φορτώσετε γραμματοσειρές από αυτούς τους φακέλους.
3. Φορτώστε και αποδώστε/εξάγετε την παρουσίαση.
4. Καλέστε το [FontsLoader.clearCache](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/clearcache/) για να εκκαθαρίσετε την κρυφή μνήμη γραμματοσειρών.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Ορίστε φακέλους που περιέχουν προσαρμοσμένα αρχεία γραμματοσειρών.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Φορτώστε προσαρμοσμένες γραμματοσειρές από τους καθορισμένους φακέλους.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Αποδώστε/εξάγετε την παρουσίαση (π.χ., σε PDF, εικόνες ή άλλες μορφές) χρησιμοποιώντας τις φορτωμένες γραμματοσειρές.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Καθαρίστε την κρυφή μνήμη γραμματοσειρών μετά το τέλος της εργασίας.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Σημείωση" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) προσθέτει επιπλέον φακέλους στις διαδρομές αναζήτησης γραμματοσειρών, αλλά δεν αλλάζει τη σειρά αρχικοποίησης των γραμματοσειρών.
Οι γραμματοσειρές αρχικοποιούνται με την εξής σειρά:

1. Η προεπιλεγμένη διαδρομή γραμματοσειρών του λειτουργικού συστήματος.
1. Οι διαδρομές που φορτώθηκαν μέσω του [FontsLoader](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Ανάκτηση φακέλου προσαρμοσμένων γραμματοσειρών**
Το Aspose.Slides παρέχει τη μέθοδο [getFontFolders](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) ώστε να μπορείτε να βρείτε φακέλους γραμματοσειρών. Αυτή η μέθοδος επιστρέφει φακέλους που προστέθηκαν μέσω της μεθόδου `LoadExternalFonts` και τους φακέλους γραμματοσειρών του συστήματος.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Αυτή η γραμμή εμφανίζει τους φακέλους όπου αναζητούνται τα αρχεία γραμματοσειρών.
// Αυτοί είναι οι φάκελοι που προστέθηκαν μέσω της μεθόδου LoadExternalFonts και οι φάκελοι γραμματοσειρών του συστήματος.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Καθορισμός προσαρμοσμένων γραμματοσειρών που χρησιμοποιούνται με την παρουσίαση**
Το Aspose.Slides παρέχει την ιδιότητα [setDocumentLevelFontSources](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) ώστε να μπορείτε να καθορίσετε εξωτερικές γραμματοσειρές που θα χρησιμοποιηθούν με την παρουσίαση.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **Διαχείριση γραμματοσειρών εξωτερικά**
Το Aspose.Slides παρέχει τη μέθοδο [loadExternalFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) ώστε να μπορείτε να φορτώσετε εξωτερικές γραμματοσειρές από δυαδικά δεδομένα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // εξωτερική γραμματοσειρά φορτωμένη κατά τη διάρκεια της παρουσίασης
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **Συχνές ερωτήσεις**

### Επηρεάζουν οι προσαρμοσμένες γραμματοσειρές την εξαγωγή σε όλες τις μορφές (PDF, PNG, SVG, HTML);
Ναι. Οι συνδεδεμένες γραμματοσειρές χρησιμοποιούνται από τον renderer σε όλες τις μορφές εξαγωγής.

### Ενσωματώνονται αυτόματα οι προσαρμοσμένες γραμματοσειρές στο παραγόμενο PPTX;
Όχι. Η καταχώριση μιας γραμματοσειράς για απόδοση δεν είναι το ίδιο με την ενσωμάτωση της σε ένα PPTX. Εάν χρειάζεστε τη γραμματοσειρά να βρίσκεται μέσα στο αρχείο παρουσίασης, πρέπει να χρησιμοποιήσετε τις ρητές [embedding features](/slides/el/nodejs-java/embedded-font/).

### Μπορώ να ελέγξω τη συμπεριφορά εναλλακτικής επιλογής όταν μια προσαρμοσμένη γραμματοσειρά λείπουν ορισμένα γλυφίδια;
Ναί. Διαμορφώστε [font substitution](/slides/el/nodejs-java/font-substitution/), [replacement rules](/slides/el/nodejs-java/font-replacement/) και [fallback sets](/slides/el/nodejs-java/fallback-font/) για να ορίσετε ακριβώς ποια γραμματοσειρά θα χρησιμοποιηθεί όταν το ζητούμενο γλυφίδιο λείπει.

### Μπορώ να χρησιμοποιήσω γραμματοσειρές σε δοχεία Linux/Docker χωρίς να τις εγκαταστήσω σε ολόκληρο το σύστημα;
Ναι. Κατευθύνετε προς τους δικούς σας φακέλους γραμματοσειρών ή φορτώστε γραμματοσειρές από byte arrays. Αυτό αφαιρεί οποιαδήποτε εξάρτηση από τους καταλόγους συστήματος γραμματοσειρών στην εικόνα του container.

### Τι γίνεται με την άδεια—μπορώ να ενσωματώσω οποιαδήποτε προσαρμοσμένη γραμματοσειρά χωρίς περιορισμούς;
Είστε υπεύθυνοι για τη συμμόρφωση με την άδεια χρήσης της γραμματοσειράς. Οι όροι διαφέρουν· ορισμένες άδειες απαγορεύουν την ενσωμάτωση ή εμπορική χρήση. Πάντα να ελέγχετε την ΕΣΑ της γραμματοσειράς πριν διανείμετε τα παραγόμενα αρχεία.