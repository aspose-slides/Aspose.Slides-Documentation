---
title: Ενσωμάτωση γραμματοσειρών σε παρουσιάσεις με JavaScript
linktitle: Ενσωματωμένες γραμματοσειρές
type: docs
weight: 40
url: /el/nodejs-java/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειρών
- λήψη ενσωματωμένης γραμματοσειράς
- πρόσθεση ενσωματωμένης γραμματοσειράς
- αφαίρεση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε τις ενσωματωμένες γραμματοσειρές στο PowerPoint με το Aspose.Slides για Node.js μέσω Java. Προσθέστε, ανακτήστε, αφαιρέστε και συμπιέστε γραμματοσειρές ώστε να διατηρείται η εμφάνιση του κειμένου και να μειώνεται το μέγεθος του αρχείου."
---
## **Εισαγωγή**

Η ενσωμάτωση γραμματοσειρών αποθηκεύει δεδομένα γραμματοσειράς μέσα σε μια παρουσίαση PowerPoint. Όταν ένας προβολέας υποστηρίζει ενσωματωμένες γραμματοσειρές, μπορεί να εμφανίζει το κείμενο χρησιμοποιώντας αυτές τις γραμματοσειρές ακόμη και αν δεν είναι εγκατεστημένες στο σύστημα προορισμού. Αυτό βοηθά στη διατήρηση των αλλαγών γραμμής, του διαστήματος του κειμένου και της διάταξης των διαφανειών.

Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να ανακτάτε, προσθέτετε και αφαιρείτε ενσωματωμένες γραμματοσειρές μέσω της κλάσης FontsManager που επιστρέφεται από την Presentation.getFontsManager. Μπορείτε επίσης να μειώσετε το μέγεθος των ενσωματωμένων δεδομένων γραμματοσειράς αφαιρώντας χαρακτήρες που δεν χρησιμοποιούνται στην παρουσίαση.

Τα παραδείγματα παρακάτω λειτουργούν με αρχεία PPTX. Πριν ενσωματώσετε μια γραμματοσειρά, βεβαιωθείτε ότι τα δεδομένα της γραμματοσειράς είναι διαθέσιμα στο Aspose.Slides και ότι η άδειά της επιτρέπει την ενσωμάτωση.

## **Ανάκτηση και Αφαίρεση Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιήσετε το FontsManager.getEmbeddedFonts για να παραθέσετε τις γραμματοσειρές που είναι αποθηκευμένες σε μια παρουσίαση. Για να αφαιρέσετε μία, περάστε μια γραμματοσειρά από αυτή τη λίστα στη μέθοδο FontsManager.removeEmbeddedFont, στη συνέχεια αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα παραθέτει τις ενσωματωμένες γραμματοσειρές στο `EmbeddedFonts.pptx` και αφαιρεί τη Calibri εάν υπάρχει:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Η αφαίρεση μιας ενσωματωμένης γραμματοσειράς αφαιρεί τα αποθηκευμένα δεδομένα της γραμματοσειράς· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο κείμενο. Εάν η γραμματοσειρά είναι εγκατεστημένη στο σύστημα προορισμού, το κείμενο μπορεί ακόμη να τη χρησιμοποιήσει. Διαφορετικά, η απόδοση ενδέχεται να απαιτεί αντικατάσταση γραμματοσειράς, κάτι που μπορεί να επηρεάσει τη διάταξη.

## **Έλεγχος Δεδομένων Γραμματοσειράς και Δικαιωμάτων Ενσωμάτωσης**

Χρησιμοποιήστε την κλάση FontsManager για να ελέγξετε τις γραμματοσειρές πριν τις ενσωματώσετε. Καλέστε το FontsManager.getFonts για να ανακτήσετε τις γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση. Για κάθε γραμματοσειρά, περάστε ένα αντικείμενο FontData και την απαιτούμενη τιμή FontStyleType στη μέθοδο FontsManager.getFontBytes. Η μέθοδος επιστρέφει τα δυαδικά δεδομένα για εκείνο το στυλ γραμματοσειράς, ή `null` όταν η ζητούμενη γραμματοσειρά ή στυλ δεν είναι διαθέσιμα. Μην περνάτε ένα αποτέλεσμα `null` στη μέθοδο FontsManager.getFontEmbeddingLevel, επειδή αυτή η μέθοδος απαιτεί έναν πίνακα bytes. Στο Node.js, μετατρέψτε τον επιστραφέντα πίνακα JavaScript σε πίνακα byte Java με τη `java.newArray` πριν τον περάσετε στο `getFontEmbeddingLevel`.

[EmbeddingLevel](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/embeddinglevel/) αναφέρει τις περιορισμούς ενσωμάτωσης που είναι αποθηκευμένοι στη γραμματοσειρά ως σύνολο σημαιών:

- `Installable` επιτρέπει την ενσωμάτωση και τη μόνιμη εγκατάσταση σε άλλο σύστημα, υπό την άδεια της γραμματοσειράς.
- `Restricted` απαγορεύει την ενσωμάτωση εκτός αν ληφθεί άδεια από τον νομικό κάτοχο της γραμματοσειράς όταν είναι η μοναδική σημαία χρήσης.
- `PreviewPrint` επιτρέπει προσωρινή χρήση για προβολή και εκτύπωση· ένα έγγραφο που περιέχει τη γραμματοσειρά πρέπει να είναι μόνο για ανάγνωση.
- `Editable` επιτρέπει προσωρινή χρήση και επιτρέπει το έγγραφο να επεξεργαστεί και να αποθηκευτεί.
- `NoSubsetting` είναι ένας πρόσθετος περιορισμός που απαγορεύει την ενσωμάτωση μόνο ενός υποσυνόλου των γλυφών. Ενσωματώστε όλους τους χαρακτήρες όταν αυτή η σημαία είναι παρούσα.
- `BitmapOnly` είναι ένας πρόσθετος περιορισμός που επιτρέπει την ενσωμάτωση μόνο bitmap παλμών, όχι δεδομένων περιγράμματος. Εάν η γραμματοσειρά δεν έχει bitmap παλμούς, δεν μπορεί να ενσωματωθεί.

Οι πρώτες τέσσερις τιμές περιγράφουν την άδεια χρήσης, ενώ οι `NoSubsetting` και `BitmapOnly` μπορούν να συνδυαστούν με αυτές. Ελέγξτε τους τροποποιητές με δυαδικές (bitwise) λειτουργίες. Δεδομένου ότι το `Installable` είναι μηδέν, αποκρύψτε τα bits άδειας χρήσης και συγκρίνετε το αποτέλεσμα με το `Installable` αντί να το ελέγχετε ως σημαία. Οι τρέχουσες γραμματοσειρές θα πρέπει να ορίζουν το πολύ ένα bit άδειας χρήσης. Για συμβατότητα με παλαιότερες γραμματοσειρές που ορίζουν περισσότερα από ένα, η βοηθητική συνάρτηση παρακάτω επιλέγει την λιγότερο περιοριστική άδεια: `Editable`, μετά `PreviewPrint`, μετά `Restricted`.

Το παρακάτω παράδειγμα ελέγχει τα δεδομένα κανονικού, έντονου, πλάγιου και έντονα πλάγιου για κάθε γραμματοσειρά που επιστρέφεται από το `getFonts`. Παραλείπει στυλ που δεν είναι διαθέσιμα, περιορισμένες γραμματοσειρές, γραμματοσειρές μόνο bitmap, γραμματοσειρές περιορισμένες σε προεπισκόπηση και εκτύπωση επειδή το αποτέλεσμα παραμένει επεξεργάσιμο, και γραμματοσειρές που είναι ήδη ενσωματωμένες. Εάν κάποιο διαθέσιμο στυλ έχει `NoSubsetting`, ενσωματώνει όλους τους χαρακτήρες για εκείνη την οικογένεια γραμματοσειρών.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αυτή η επιθεώρηση αναφέρει τους περιορισμούς που κωδικοποιούνται σε κάθε αρχείο γραμματοσειράς. Δεν παρέχει άδεια, δεν αποδεικνύει ότι αποκτήσατε τη γραμματοσειρά νόμιμα, ούτε αντικαθιστά τον έλεγχο της συμφωνίας άδειας της γραμματοσειράς πριν τη διανομή ενός ενσωματωμένου αντιγράφου.

## **Προσθήκη Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιήστε το FontsManager.addEmbeddedFont για να ενσωματώσετε μια γραμματοσειρά. Οι υπερφορτώσεις του δέχονται είτε ένα αντικείμενο FontData είτε έναν πίνακα byte που περιέχει τα δεδομένα της γραμματοσειράς. Η κλάση EmbedFontCharacters ελέγχει ποιοι χαρακτήρες περιλαμβάνονται:

- `All` ενσωματώνει όλους τους χαρακτήρες στη γραμματοσειρά. Χρησιμοποιήστε αυτήν την επιλογή όταν οι αποδέκτες χρειάζονται να επεξεργαστούν την παρουσίαση και να εισάγουν νέο κείμενο.
- `OnlyUsed` ενσωματώνει μόνο τους χαρακτήρες που χρησιμοποιούνται στην παρουσίαση για να μειώσει το μέγεθος του αρχείου. Επιλέξτε αυτήν την επιλογή για μια τελική παρουσίαση που προορίζεται κυρίως για προβολή.

Το παρακάτω παράδειγμα χρησιμοποιεί το FontsManager.getFonts για να ανακτήσει τις γραμματοσειρές που χρησιμοποιούνται στο `Fonts.pptx` και ενσωματώνει αυτές που δεν είναι ήδη ενσωματωμένες. Οι γραμματοσειρές που θα προστεθούν πρέπει να είναι διαθέσιμες στο μηχάνημα που εκτελεί τον κώδικα. Οι υπάρχουσες ενσωματωμένες γραμματοσειρές διατηρούν τα τρέχοντα σύνολα χαρακτήρων τους.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συμπίεση Ενσωματωμένων Γραμματοσειρών**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/compress/compressembeddedfonts/) μειώνει τα ενσωματωμένα δεδομένα γραμματοσειράς αφαιρώντας τους αχρησιμοποίητους χαρακτήρες. Λειτουργεί σε γραμματοσειρές που είναι ήδη ενσωματωμένες, έτσι η μείωση του μεγέθους εξαρτάται από το πόσα αχρησιμοποίητα δεδομένα γραμματοσειράς περιέχει η παρουσίαση.

Το παρακάτω παράδειγμα συμπιέζει τις γραμματοσειρές στο `EmbeddedFonts.pptx` και αποθηκεύει το αποτέλεσμα ως ξεχωριστό αρχείο:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Διατηρήστε το αρχικό αρχείο εάν οι αποδέκτες ενδέχεται να χρειαστούν να προσθέσουν κείμενο αργότερα. Οι χαρακτήρες που αφαιρέθηκαν κατά τη συμπίεση δεν είναι πλέον διαθέσιμοι από την ενσωματωμένη γραμματοσειρά, ακόμη και αν αρχικά ενσωματώσατε όλους τους χαρακτήρες.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω αν μια ενσωματωμένη γραμματοσειρά θα εξακολουθήσει να αντικαθίσταται κατά τη διαδικασία απόδοσης;**

Καλέστε το FontsManager.getSubstitutions στο περιβάλλον όπου αποδίδετε την παρουσίαση για να δείτε ποιες γραμματοσειρές θα αντικαταστήσει το Aspose.Slides. Επίσης ελέγξτε τις ρυθμίσεις [αντικατάστασης γραμματοσειρών](/slides/el/nodejs-java/font-substitution/) και τους κανόνες [εφεδρικής γραμματοσειράς](/slides/el/nodejs-java/fallback-font/). Η εφεδρική γραμματοσειρά διαχειρίζεται τους χαρακτήρες που λείπουν, έτσι η ενσωμάτωση μιας γραμματοσειράς δεν λύνει τους χαρακτήρες που η ίδια η γραμματοσειρά δεν περιέχει.

**Θα πρέπει να ενσωματώνω κοινές γραμματοσειρές όπως Arial και Calibri;**

Λάβετε την απόφαση βάσει του περιβάλλοντος προορισμού. Εάν οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες σε κάθε μηχάνημα που ανοίγει ή αποτυπώνει την παρουσίαση, η ενσωμάτωση τους μπορεί να προσθέσει περιττό μέγεθος αρχείου. Εάν οι αποδέκτες ή οι διακομιστές ενδέχεται να μην έχουν αυτές τις γραμματοσειρές, η ενσωμάτωσή τους μπορεί να βοηθήσει στη διατήρηση της προβλεπόμενης εμφάνισης, εφόσον οι άδειες τους το επιτρέπουν.