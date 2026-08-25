---
title: Διαχείριση γραμματοσειρών θέματος ειδικού σεναρίου σε Java
linktitle: Γραμματοσειρές θέματος ειδικού σεναρίου
type: docs
weight: 15
url: /el/java/script-specific-font-mappings/
keywords:
- γραμματοσειρά ειδικού σεναρίου
- αντιστοίχηση γραμματοσειράς θέματος
- πολυγλωσσική παρουσίαση
- σύστημα γραφής
- γραμματοσειρά κυριλλικών
- γραμματοσειρά αραβικών
- γραμματοσειρά ιαπωνική
- γραμματοσειρά γεωργιανών
- γραμματοσειρά θάνα
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Επιθεώρηση, προσθήκη, αντικατάσταση και αφαίρεση αντιστοιχίσεων γραμματοσειρών ειδικού σεναρίου σε θέματα PowerPoint με Aspose.Slides για Java."
---
## **Επισκόπηση**

Ένα θέμα παρουσίασης μπορεί να επιλέξει διαφορετικές οικογένειες γραμματοσειρών για διαφορετικά συστήματα γραφής. Αυτό επιτρέπει το πολυγλωσσικό κείμενο που εξακολουθεί να χρησιμοποιεί τις γραμματοσειρές του θέματος να ακολουθεί ένα συντονισμένο σχήμα γραμματοσειρών ενώ χρησιμοποιεί κατάλληλες γραμματοσειρές για κυριλλικά, αραβικά, ιαπωνικά, γεωργιανά, θάνα και άλλες γραφές.

Το [IFontScheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontscheme/) του θέματος περιλαμβάνει μια κύρια συλλογή γραμματοσειρών, συνήθως χρησιμοποιούμενη για επικεφαλίδες, και μια δευτερεύουσα συλλογή γραμματοσειρών, συνήθως για σώμα κειμένου. Εκτός από τις ρυθμίσεις γραμματοσειρών για λατινικά και Ανατολική Ασία, και οι δύο συλλογές εκθέτουν αντιστοιχίσεις από ετικέτες συστήματος γραφής σε ονόματα οικογενειών γραμματοσειρών μέσω της διεπαφής [IFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifonts/).

Αυτό το άρθρο δείχνει πώς να εξετάσετε και να τροποποιήσετε αυτές τις αντιστοιχίσεις στο κύριο θέμα της παρουσίασης και να επαληθεύσετε ότι οι αλλαγές παραμένουν μετά από έναν κύκλο αποθήκευσης‑επανάκτησης.

## **Κατανόηση ετικετών σεναρίου**

Οι μέθοδοι γραμματοσειρών σεναρίου χρησιμοποιούν τέσσερις χαρακτήρες BCP 47 υποετικέτες σεναρίου για την αναγνώριση συστημάτων γραφής. Συνήθεις τιμές περιλαμβάνουν:

| Ετικέτα σεναρίου | Σύστημα γραφής |
|---|---|
| `Cyrl` | Κυριλλικό |
| `Arab` | Αραβικό |
| `Hans` | Απλοποιημένα κινέζικα |
| `Jpan` | Ιαπωνικό |
| `Geor` | Γεωργιανό |
| `Thaa` | Θάνα |

Αυτές οι αντιστοιχίσεις ανήκουν στο σχήμα γραμματοσειρών του θέματος, όχι σε μεμονωμένες τμήματα κειμένου. Μια παρουσίαση μπορεί να ορίσει διαφορετικές αντιστοιχίσεις για τις κύριες και δευτερεύουσες συλλογές και μπορεί να παραλείψει αντιστοιχίσεις για ορισμένα σενάρια.

## **Πρόσβαση και εξέταση αντιστοιχίσεων γραμματοσειρών σεναρίου**

Χρησιμοποιήστε το [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getMasterTheme--) για πρόσβαση στο θέμα σε επίπεδο παρουσίασης. Οι μέθοδοι [IFontScheme.getMajor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontscheme/#getMajor--) και [IFontScheme.getMinor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontscheme/#getMinor--) επιστρέφουν τις δύο συλλογές [IFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifonts/).

Καλέστε το [IFonts.getScriptFontMap](https://reference.aspose.com/slides/el/java/com.aspose.slides/fonts/#getScriptFontMap--) για την ανάκτηση όλων των αντιστοιχίσεων από μια συλλογή. Για να εντοπίσετε ένα σύστημα γραφής, καλέστε το [IFonts.getScriptFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) με την ετικέτα του σεναρίου. Το `getScriptFont` επιστρέφει `null` όταν η συλλογή δεν ορίζει την ζητούμενη αντιστοιχία.

## **Τροποποίηση αντιστοιχίσεων και επαλήθευση διατήρησης**

Χρησιμοποιήστε το [IFonts.setScriptFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) για να δημιουργήσετε ή να αντικαταστήσετε την τρέχουσα οικογένεια γραμματοσειρών. Χρησιμοποιήστε το [IFonts.removeScriptFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) για να αφαιρέσετε μια αντιστοιχία.

Το παρακάτω παράδειγμα από‑αρχή‑μέχρι‑τέλος διαβάζει όλες τις υπάρχουσες κύριες και δευτερεύουσες αντιστοιχίες, εντοπίζει τη μεγάλη ιάπωνική γραμματοσειρά, αλλάζει τη μεγάλη κυριλλική γραμματοσειρά, αφαιρεί τη δευτερεύουσα αντιστοιχία Θάνα, αποθηκεύει την παρουσίαση και την ανοίγει ξανά για επαλήθευση και των δύο αλλαγών. Για να είναι το βήμα αφαίρεσης ανεξάρτητο από το αρχικό θέμα, το παράδειγμα δημιουργεί μια αντιστοιχία Θάνα μόνο όταν δεν υπάρχει ήδη.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Η επαλήθευση χρησιμοποιεί την ίδια συμπεριφορά `null` όπως μια συνηθισμένη αναζήτηση: μετά την αποθήκευση της αφαίρεσης, το `getScriptFont("Thaa")` επιστρέφει `null` για τη δευτερεύουσα συλλογή.

## **Διαχωρισμός αντιστοιχίσεων θέματος από άλλες ρυθμίσεις γραμματοσειράς**

Οι αντιστοιχίες γραμματοσειράς θέματος ειδικές για σενάριο συμμετέχουν στην επιλογή γραμματοσειράς, αλλά λύνουν διαφορετικό πρόβλημα από την άμεση μορφοποίηση κειμένου, την αντικατάσταση και την εναπόθεση:

| Μηχανισμός | Σκοπός | Επίπτωση αλλαγής αντιστοίχισης θέματος |
|---|---|---|
| Αντιστοίχιση γραμματοσειράς θέματος ειδική για σενάριο | Επιλέγει μια κύρια ή δευτερεύουσα γραμματοσειρά θέματος για ένα σύστημα γραφής. | Το κείμενο που εξακολουθεί να χρησιμοποιεί τη σχετική γραμματοσειρά θέματος μπορεί να επιλυθεί στη νέα οικογένεια που έχει αντιστοιχηθεί. |
| Γραμματοσειρά που έχει εκχωρηθεί ρητά σε τμήμα κειμένου | Κλειδώνει την επιλεγμένη οικογένεια γραμματοσειρών στο τμήμα αυτό αντί να βασίζεται στο θέμα. | Το τμήμα μπορεί να παραμείνει αμετάβλητο, επειδή η άμεση μορφοποίηση υπερισχύει της επιλογής θέματος. |
| Αντικατάσταση γραμματοσειράς | Αντικαθιστά μια ζητούμενη γραμματοσειρά όταν αυτή δεν είναι διαθέσιμη ή όταν εφαρμόζεται κανόνας αντικατάστασης. | Δρουν μετά την αίτηση γραμματοσειράς· δεν επανακαθορίζουν την αντιστοίχηση σεναρίου του θέματος. |
| Εναπόθεση γραμματοσειράς | Παρέχει γλύφους που δεν περιέχονται στη επιλεγμένη γραμματοσειρά, συνήθως για συγκεκριμένα εύρη Unicode. | Συμπληρώνει ελλείπουσες γλυφικές κάλυψεις· δεν αλλάζει την αποθηκευμένη αντιστοίχηση θέματος. |

Για περισσότερες πληροφορίες σχετικά με τους δύο τελευταίους μηχανισμούς, δείτε [Font Substitution](/slides/el/java/font-substitution/) και [Fallback Fonts](/slides/el/java/fallback-font/).

Η αλλαγή μιας αντιστοίχισης στο [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getMasterTheme--) επηρεάζει μόνο το περιεχόμενο του οποίου η αποτελεσματική μορφοποίηση εξαρτάται ακόμη από αυτό το θέμα. Το κείμενο μπορεί αντίθετα να κληρονομήσει μια υπερκαλύπτοντας θέμα από master, layout ή slide, ή να χρησιμοποιήσει ρητά εκχωρημένη γραμματοσειρά. Εξετάστε αυτά τα επίπεδα όταν το ορατό αποτέλεσμα δεν ακολουθεί την αντιστοίχηση σε επίπεδο παρουσίασης.

## **Διαθέσιμοτητα αντιστοιχισμένων γραμματοσειρών και επαλήθευση του αποτελέσματος**

Μια αντιστοίχηση σεναρίου αποθηκεύει ένα όνομα οικογένειας γραμματοσειράς· δεν εγκαθιστά ή φορτώνει το αντίστοιχο αρχείο γραμματοσειράς. Για συνεπή απόδοση και εξαγωγή, κάθε αντιστοιχισμένη γραμματοσειρά πρέπει να είναι εγκατεστημένη στο περιβάλλον ή να παρέχεται στο Aspose.Slides μέσω προσαρμοσμένης πηγής όπως το [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ή το [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Δείτε την ενότητα [Custom Fonts](/slides/el/java/custom-font/) για τις διαθέσιμες επιλογές φόρτωσης.

Η επαλήθευση της αποθηκευμένης αντιστοίχισης επιβεβαιώνει μόνο ότι ο ορισμός του θέματος διατηρήθηκε. Δεν αποδεικνύει ότι η γραμματοσειρά είναι διαθέσιμη, περιέχει όλους τους απαιτούμενους γλύφους ή παράγει την επιθυμητή διάταξη. Αποδώστε αντιπροσωπευτικό κείμενο για κάθε απαιτούμενο σύστημα γραφής σε εικόνα ή PDF και εξετάστε το αποτέλεσμα. Αυτό εντοπίζει ελλιπείς γραμματοσειρές, ελλιπή κάλυψη γλύφων, συμπεριφορά εναπόθεσης και αλλαγές διάταξης πριν τη διανομή της παρουσίασης. Δείτε το [Convert PowerPoint Presentations](/slides/el/java/convert-powerpoint/) για παραδείγματα απόδοσης και εξαγωγής.

## **Συχνές ερωτήσεις**

**Τι επιστρέφει το `getScriptFont` όταν ένα σενάριο δεν είναι αντιστοιχισμένο;**

[IFonts.getScriptFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) επιστρέφει `null` όταν η ζητούμενη αντιστοίχηση σεναρίου δεν είναι ορισμένη στη συγκεκριμένη κύρια ή δευτερεύουσα συλλογή γραμματοσειρών.

**Προσθέτει το `setScriptFont` μια δεύτερη αντιστοίχηση όταν το σενάριο υπάρχει ήδη;**

Όχι. Το [IFonts.setScriptFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) δημιουργεί την αντιστοίχηση όταν λείπει και αντικαθιστά την υπάρχουσα οικογένεια γραμματοσειρών όταν η ίδια ετικέτα σεναρίου είναι ήδη παρούσα.

**Γιατί η αλλαγή μιας αντιστοίχισης θέματος δεν άλλαξε κάποιο κείμενο;**

Το κείμενο μπορεί να έχει ρητά εκχωρημένη γραμματοσειρά, να κληρονομεί διαφορετικό θέμα μέσω υπέρβασης, ή να επηρεάζεται από αντικατάσταση ή εναπόθεση κατά την απόδοση. Μια αντιστοίχηση σεναρίου σε επίπεδο παρουσίασης ελέγχει μόνο το κείμενο του οποίου η αποτελεσματική μορφοποίηση εξακολουθεί να αναφέρεται σε αυτή τη συλλογή γραμματοσειρών θέματος.

**Είναι η αποθήκευση και επανέναρξη επαρκείς για την επικύρωση πολυγλωσσικής εξόδου;**

Όχι. Η επανέναρξη επαληθεύει τη διατήρηση των δεδομένων θέματος. Πρέπει επίσης να αποδοθεί αντιπροσωπευτικό κείμενο από κάθε απαιτούμενο σύστημα γραφής ώστε να επιβεβαιωθεί ότι οι αντιστοιχισμένες γραμματοσειρές είναι διαθέσιμες και περιέχουν τους απαραίτητους γλύφους.