---
title: Διαχείριση γραμματοσειρών θέματος ειδικές για σενάρια σε JavaScript
linktitle: Γραμματοσειρές Θέματος Ειδικές για Σενάρια
type: docs
weight: 15
url: /el/nodejs-java/script-specific-font-mappings/
keywords:
- γραμματοσειρά ειδική για σενάριο
- αντιστοίχηση γραμματοσειράς θέματος
- πολυγλωσσική παρουσίαση
- σύστημα γραφής
- γραμματοσειρά κυριλλική
- γραμματοσειρά αραβική
- γραμματοσειρά ιαπωνική
- γραμματοσειρά γεωργιανή
- γραμματοσειρά θάανα
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Επιθεώρηση, προσθήκη, αντικατάσταση και αφαίρεση αντιστοιχίσεων γραμματοσειρών ειδικών για σενάριο σε θέματα PowerPoint με το Aspose.Slides για Node.js."
---
## **Επισκόπηση**

Ένα θέμα παρουσίασης μπορεί να επιλέγει διαφορετικές οικογένειες γραμματοσειρών για διαφορετικά συστήματα γραφής. Αυτό επιτρέπει κειμενικά πολυγλωσσικά κείμενα που εξακολουθούν να χρησιμοποιούν τις γραμματοσειρές του θέματος να ακολουθούν ένα συντονισμένο σχήμα γραμματοσειρών, ενώ χρησιμοποιούν κατάλληλες γραμματοσειρές για Κυριλλική, Αραβική, Ιαπωνική, Γεωργιανή, Θάανα και άλλες γραφές.

Το [FontScheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontscheme/) του θέματος περιέχει μια κύρια συλλογή γραμματοσειρών, συνήθως χρησιμοποιούμενη για επικεφαλίδες, και μια δευτερεύουσα συλλογή γραμματοσειρών, συνήθως χρησιμοποιούμενη για το σώμα του κειμένου. Εκτός από τις ρυθμίσεις γραμματοσειρών για Λατινικό και Ανατολική Ασία, και οι δύο συλλογές εκθέτουν αντιστοιχίσεις από ετικέτες συστήματος γραφής σε ονόματα οικογενειών γραμματοσειρών μέσω της κλάσης [Fonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fonts/).

Αυτό το άρθρο δείχνει πώς να επιθεωρήσετε και να τροποποιήσετε αυτές τις αντιστοιχίσεις στο κύριο θέμα της παρουσίασης και να επαληθεύσετε ότι οι αλλαγές παραμένουν μετά από έναν κύκλο αποθήκευσης και επανεκκίνησης.

## **Κατανόηση Ετικετών Σεναρίου**

Οι μέθοδοι γραμματοσειράς σεναρίου χρησιμοποιούν υποετικέτες σεναρίου τεσσάρων χαρακτήρων σύμφωνα με το BCP 47 για την αναγνώριση των συστημάτων γραφής. Συνήθεις τιμές περιλαμβάνουν:

| Ετικέτα σεναρίου | Σύστημα γραφής |
|---|---|
| `Cyrl` | Κυριλλική |
| `Arab` | Αραβική |
| `Hans` | Απλοποιημένα Κινέζικα |
| `Jpan` | Ιαπωνική |
| `Geor` | Γεωργιανή |
| `Thaa` | Θάανα |

## **Πρόσβαση και Επιθεώρηση Αντιστοιχίσεων Γραμματοσειρών Σεναρίου**

Χρησιμοποιήστε το [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getmastertheme/) για να αποκτήσετε πρόσβαση στο θέμα επιπέδου παρουσίασης. Οι μέθοδοι [FontScheme.getMajor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontscheme/) και [FontScheme.getMinor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontscheme/) επιστρέφουν τις δύο συλλογές [Fonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fonts/).

Καλέστε [Fonts.getScriptFontMap](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fonts/) για να ανακτήσετε όλες τις αντιστοιχίσεις από μια συλλογή. Για να αναζητήσετε ένα σύστημα γραφής, καλέστε το [Fonts.getScriptFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fonts/) με την ετικέτα του σεναρίου. Το `getScriptFont` επιστρέφει `null` όταν η συλλογή δεν ορίζει την ζητούμενη αντιστοιχία.

## **Τροποποίηση Αντιστοιχίσεων και Επαλήθευση Διατήρησης**

Χρησιμοποιήστε το [Fonts.setScriptFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fonts/) για να δημιουργήσετε μια αντιστοιχία ή να αντικαταστήσετε την τρέχουσα οικογένεια γραμματοσειρών. Χρησιμοποιήστε το [Fonts.removeScriptFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fonts/) για να αφαιρέσετε μια αντιστοιχία.

Το παρακάτω παράδειγμα end-to-end διαβάζει όλες τις υπάρχουσες κύριες και δευτερεύουσες αντιστοιχίσεις, εντοπίζει τη κύρια γραμματοσειρά για Ιαπωνικά, αλλάζει τη κύρια γραμματοσειρά για Κυριλλική, αφαιρεί τη δευτερεύουσα αντιστοιχία Θάανα, αποθηκεύει την παρουσίαση και την ανοίγει ξανά για να επαληθεύσει και τις δύο αλλαγές. Για να κάνει το βήμα αφαίρεσης ανεξάρτητο από το αρχικό θέμα, το παράδειγμα πρώτα δημιουργεί μια αντιστοιχία Θάανα μόνο εάν δεν υπάρχει ήδη ορισμένη.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Η επαλήθευση χρησιμοποιεί την ίδια συμπεριφορά `null` όπως μια συνηθισμένη αναζήτηση: μετά την αποθήκευση της αφαίρεσης, το `getScriptFont("Thaa")` επιστρέφει `null` για τη δευτερεύουσα συλλογή.

## **Διαχωρισμός Αντιστοιχίσεων Θέματος από Άλλες Ρυθμίσεις Γραμματοσειρών**

Οι αντιστοιχίες θέματος ειδικές για σενάρια συμμετέχουν στην επιλογή γραμματοσειράς, αλλά λύνουν διαφορετικό πρόβλημα από την άμεση μορφοποίηση κειμένου, την αντικατάσταση και την εναλλακτική παροχή:

| Μηχανισμός | Σκοπός | Αποτέλεσμα αλλαγής αντιστοιχίας θέματος |
|---|---|---|
| Αντιστοίχιση γραμματοσειράς θέματος ειδική για σενάριο | Επιλέγει μια κύρια ή δευτερεύουσα γραμματοσειρά θέματος για ένα σύστημα γραφής. | Το κείμενο που εξακολουθεί να χρησιμοποιεί τη σχετική γραμματοσειρά θέματος μπορεί να αντιστοιχιστεί στη νέα οικογένεια. |
| Γραμματοσειρά που έχει εκχωρηθεί ρητά σε τμήμα κειμένου | Καθορίζει την ζητούμενη οικογένεια γραμματοσειράς στο τμήμα αυτό αντί να εξαρτάται από το θέμα. | Το τμήμα μπορεί να παραμείνει αμετάβλητο επειδή η άμεση μορφοποίηση του υπερισχύει της επιλογής θέματος. |
| Αντικατάσταση γραμματοσειράς | Αντικαθιστά μια ζητούμενη γραμματοσειρά όταν αυτή δεν είναι διαθέσιμη ή όταν εφαρμόζεται κανόνας αντικατάστασης. | Λειτουργεί μετά την αίτηση μιας γραμματοσειράς· δεν επαναπροσδιορίζει την αντιστοίχιση σεναρίου του θέματος. |
| Εναλλακτική παροχή γραμματοσειράς | Παρέχει γλύφα που η επιλεγμένη γραμματοσειρά δεν περιλαμβάνει, συχνά για συγκεκριμένες περιοχές Unicode. | Συμπληρώνει την έλλειψη γλύφων· δεν αλλάζει την αποθηκευμένη αντιστοίχιση θέματος. |

Για περισσότερες πληροφορίες σχετικά με τους τελευταίους δύο μηχανισμούς, δείτε [Font Substitution](/slides/el/nodejs-java/font-substitution/) και [Fallback Fonts](/slides/el/nodejs-java/fallback-font/).

Η αλλαγή μιας αντιστοίχισης στο [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getmastertheme/) επηρεάζει μόνο το περιεχόμενο του οποίου η αποτελεσματική μορφοποίηση εξακολουθεί να εξαρτάται από αυτό το θέμα. Το κείμενο μπορεί αντίθετα να κληρονομήσει μια παράκαμψη θέματος από ένα κύριο, διάταξη ή διαφάνεια, ή να χρησιμοποιήσει μια ρητά εκχωρημένη γραμματοσειρά. Επιθεωρήστε αυτά τα επίπεδα όταν το ορατό αποτέλεσμα δεν ακολουθεί την αντιστοίχιση σε επίπεδο παρουσίασης.

## **Καταστήστε τις Αντιστοιχομένες Γραμματοσειρές Διαθέσιμες και Επικυρώστε το Αποτέλεσμα**

Μια αντιστοίχιση σεναρίου αποθηκεύει ένα όνομα οικογένειας γραμματοσειράς· δεν εγκαθιστά ή φορτώνει το αντίστοιχο αρχείο γραμματοσειράς. Για συνεπή απόδοση και εξαγωγή, κάθε αντιστοιχομένη γραμματοσειρά πρέπει να είναι εγκατεστημένη στο περιβάλλον ή να παρέχεται στο Aspose.Slides μέσω μιας προσαρμοσμένης πηγής όπως το [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) ή το [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/). Δείτε το [Custom Fonts](/slides/el/nodejs-java/custom-font/) για τις διαθέσιμες επιλογές φόρτωσης.

Η επαλήθευση της αποθηκευμένης αντιστοίχισης επιβεβαιώνει μόνο ότι ο ορισμός του θέματος διατηρήθηκε. Δεν αποδεικνύει ότι η γραμματοσειρά είναι διαθέσιμη, περιέχει όλα τα απαιτούμενα γλύφα ή παράγει την επιθυμητή διάταξη. Αποδώστε αντιπροσωπευτικό κείμενο για κάθε απαιτούμενο σύστημα γραφής σε εικόνα ή PDF και επιθεωρήστε το αποτέλεσμα. Αυτό εντοπίζει ελλιπείς γραμματοσειρές, ελλιπή κάλυψη γλύφων, συμπεριφορά εναλλακτικής παροχής και αλλαγές διάταξης πριν τη διανομή της παρουσίασης. Δείτε το [Convert PowerPoint Presentations](/slides/el/nodejs-java/convert-powerpoint/) για παραδείγματα απόδοσης και εξαγωγής.

## **Συχνές Ερωτήσεις**

**Τι επιστρέφει το `getScriptFont` όταν ένα σενάριο δεν είναι αντιστοιχισμένο;**

Το [Fonts.getScriptFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fonts/) επιστρέφει `null` όταν η ζητούμενη αντιστοίχιση σεναρίου δεν έχει οριστεί σε εκείνη τη κύρια ή δευτερεύουσα συλλογή γραμματοσειρών.

**Προσθέτει το `setScriptFont` μια δεύτερη αντιστοίχιση όταν το σενάριο υπάρχει ήδη;**

Όχι. Το [Fonts.setScriptFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fonts/) δημιουργεί την αντιστοίχιση όταν λείπει και αντικαθιστά την αντιστοιχομένη οικογένεια γραμματοσειρών όταν η ίδια ετικέτα σεναρίου είναι ήδη παρούσα.

**Γιατί η αλλαγή μιας αντιστοίχισης θέματος δεν άλλαξε ορισμένο κείμενο;**

Το κείμενο μπορεί να έχει μια ρητά εκχωρημένη γραμματοσειρά, να κληρονομήσει διαφορετικό θέμα μέσω παράκαμψης ή να επηρεάζεται από αντικατάσταση ή εναλλακτική παροχή κατά την απόδοση. Μια αντιστοίχιση σεναρίου σε επίπεδο παρουσίασης ελέγχει μόνο το κείμενο του οποίου η αποτελεσματική μορφοποίηση εξακολουθεί να αναφέρεται στην εν λόγω συλλογή γραμματοσειρών θέματος.

**Είναι η αποθήκευση και επανέναρξη αρκετές για την επικύρωση πολυγλωσσικής εξόδου;**

Όχι. Η επανέναρξη επαληθεύει τη διατήρηση των δεδομένων θέματος. Επίσης, αποδώστε αντιπροσωπευτικό κείμενο από κάθε απαιτούμενο σύστημα γραφής για να επιβεβαιώσετε ότι οι αντιστοιχομένες γραμματοσειρές είναι διαθέσιμες και περιέχουν τα απαραίτητα γλύφα.