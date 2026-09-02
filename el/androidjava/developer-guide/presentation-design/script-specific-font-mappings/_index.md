---
title: Διαχείριση γραμματοσειρών θέματος ειδικών σεναρίων σε Android
linktitle: Γραμματοσειρές θέματος ειδικές για σενάριο
type: docs
weight: 15
url: /el/androidjava/script-specific-font-mappings/
keywords:
- γραμματοσειρά ειδική για σενάριο
- αντιστοίχηση γραμματοσειράς θέματος
- πολυγλωσσική παρουσίαση
- σύστημα γραφής
- γραμματοσειρά κυριλλικών
- γραμματοσειρά αραβικών
- γραμματοσειρά ιαπωνικών
- γραμματοσειρά γεωργιανών
- γραμματοσειρά θάνα
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Επιθεωρήστε, προσθέστε, αντικαταστήστε και αφαιρέστε αντιστοιχίσεις γραμματοσειρών ειδικών για σενάριο σε θέματα PowerPoint με την Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Ένα θέμα παρουσίασης μπορεί να επιλέξει διαφορετικές οικογένειες γραμματοσειρών για διαφορετικά συστήματα γραφής. Αυτό επιτρέπει κείμενο πολλαπλών γλωσσών που εξακολουθεί να χρησιμοποιεί τις γραμματοσειρές του θέματος να ακολουθεί ένα ενιαίο σχήμα γραμματοσειρών, χρησιμοποιώντας κατάλληλες γραμματοσειρές για κυριλλικά, αραβικά, ιαπωνικά, γεωργιανά, θάνα και άλλα γραπτά.

Το θέμα περιέχει το [IFontScheme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontscheme/) μια κύρια συλλογή γραμματοσειρών, που συνήθως χρησιμοποιείται για κεφαλίδες, και μια δευτερεύουσα συλλογή γραμματοσειρών, που συνήθως χρησιμοποιείται για το κυρίως κείμενο. Εκτός από τις ρυθμίσεις γραμματοσειρών για Λατινικά και Ανατολικές Ασίας, και οι δύο συλλογές εκθέτουν αντιστοιχίσεις από ετικέτες συστημάτων γραφής σε ονόματα οικογενειών γραμματοσειρών μέσω της διεπαφής [IFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifonts/).

Αυτό το άρθρο δείχνει πώς να επιθεωρήσετε και να τροποποιήσετε αυτές τις αντιστοιχίσεις στο κύριο θέμα της παρουσίασης και να επαληθεύσετε ότι οι αλλαγές παραμένουν μετά από μια συνεδρία αποθήκευσης και επαναφόρτωσης.

## **Κατανόηση ετικετών σεναρίου**

Οι μέθοδοι γραμματοσειράς σεναρίου χρησιμοποιούν υπο-ετικέτες σεναρίου BCP 47 τεσσάρων γραμμάτων για τον προσδιορισμό των συστημάτων γραφής. Συνηθισμένες τιμές περιλαμβάνουν:

| Ετικέτα σεναρίου | Σύστημα γραφής |
|---|---|
| `Cyrl` | Κυριλλικά |
| `Arab` | Αραβικά |
| `Hans` | Απλοποιημένα Κινέζικα |
| `Jpan` | Ιαπωνικά |
| `Geor` | Γεωργιανά |
| `Thaa` | Θάνα |

Αυτές οι αντιστοιχίσεις ανήκουν στο σχήμα γραμματοσειρών του θέματος, όχι σε μεμονωμένα τμήματα κειμένου. Μια παρουσίαση μπορεί να ορίσει διαφορετικές αντιστοιχίσεις για τις κύριες και δευτερεύουσες συλλογές, και μπορεί να παραλείψει αντιστοιχίσεις για ορισμένα σενάρια.

## **Πρόσβαση και επιθεώρηση αντιστοιχίσεων γραμματοσειρών σεναρίου**

Χρησιμοποιήστε το [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getMasterTheme--) για να αποκτήσετε πρόσβαση στο θέμα σε επίπεδο παρουσίασης. Οι μέθοδοι [IFontScheme.getMajor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontscheme/#getMajor--) και [IFontScheme.getMinor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontscheme/#getMinor--) επιστρέφουν τις δύο συλλογές [IFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifonts/).

Καλέστε το [IFonts.getScriptFontMap](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) για να λάβετε όλες τις αντιστοιχίσεις από μια συλλογή. Για να αναζητήσετε ένα σύστημα γραφής, καλέστε το [IFonts.getScriptFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) με την ετικέτα σεναρίου του. Η μέθοδος `getScriptFont` επιστρέφει `null` όταν η συλλογή δεν ορίζει την απαιτούμενη αντιστοιχία.

## **Τροποποίηση αντιστοιχίσεων και επαλήθευση διατήρησης**

Χρησιμοποιήστε το [IFonts.setScriptFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) για να δημιουργήσετε μια αντιστοιχία ή να αντικαταστήσετε την τρέχουσα οικογένεια γραμματοσειράς. Χρησιμοποιήστε το [IFonts.removeScriptFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) για να αφαιρέσετε μια αντιστοιχία.

Το παρακάτω παράδειγμα από αρχή έως τέλος διαβάζει όλες τις υπάρχουσες κύριες και δευτερεύουσες αντιστοιχίσεις, αναζητά τη μεγαλύτερη γραμματοσειρά για Ιαπωνικά, αλλάζει τη μεγαλύτερη γραμματοσειρά για Κυριλλικά, αφαιρεί τη δευτερεύουσα αντιστοιχία για Θάνα, αποθηκεύει την παρουσίαση και την ανοίγει ξανά για να επαληθεύσει και τις δύο αλλαγές. Για να είναι το βήμα αφαίρεσης ανεξάρτητο από το αρχικό θέμα, το παράδειγμα πρώτα δημιουργεί μια αντιστοιχία Θάνα μόνο εάν δεν υπάρχει ήδη ορισμένη.

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

Η επαλήθευση χρησιμοποιεί την ίδια συμπεριφορά `null` όπως μια συνηθισμένη αναζήτηση: μετά την αποθήκευση της αφαίρεσης, η `getScriptFont("Thaa")` επιστρέφει `null` για τη δευτερεύουσα συλλογή.

## **Διάκριση αντιστοιχίσεων θέματος από άλλες ρυθμίσεις γραμματοσειράς**

Οι αντιστοιχίσεις θέματος ειδικές για σενάριο συμμετέχουν στην επιλογή γραμματοσειράς, αλλά λύνουν διαφορετικό πρόβλημα από την άμεση μορφοποίηση κειμένου, την αντικατάσταση και την εναλλακτική λύση:

| Μηχανισμός | Σκοπός | Αποτέλεσμα αλλαγής αντιστοιχίας θέματος |
|---|---|---|
| Αντιστοιχία γραμματοσειράς θέματος ειδική για σενάριο | Επιλέγει μια κύρια ή δευτερεύουσα γραμματοσειρά θέματος για ένα σύστημα γραφής. | Το κείμενο που εξακολουθεί να χρησιμοποιεί την αντίστοιχη γραμματοσειρά θέματος μπορεί να επιλυθεί στη νέα αντιστοιχισμένη οικογένεια. |
| Γραμματοσειρά που έχει εκχωρηθεί ρητά σε τμήμα κειμένου | Διορθώνει την ζητούμενη οικογένεια γραμματοσειράς στο τμήμα αυτό αντί να βασίζεται στο θέμα. | Το τμήμα μπορεί να παραμείνει αμετάβλητο επειδή η άμεση μορφοποίηση του υπερισχύει της επιλογής θέματος. |
| Αντικατάσταση γραμματοσειράς | Αντικαθιστά μια ζητούμενη γραμματοσειρά όταν αυτή δεν είναι διαθέσιμη ή όταν εφαρμόζεται κανόνας αντικατάστασης. | Λειτουργεί μετά την αίτηση γραμματοσειράς· δεν επαναπροσδιορίζει την αντιστοίχηση σεναρίου του θέματος. |
| Αντικατάσταση (fallback) γραμματοσειράς | Παρέχει γράμματα που δεν περιέχει η επιλεγμένη γραμματοσειρά, συχνά για συγκεκριμένα εύρη Unicode. | Συμπληρώνει έλλειψη γραμμάτων· δεν αλλάζει την αποθηκευμένη αντιστοίχηση θέματος. |

Για περισσότερες πληροφορίες σχετικά με τους δύο τελευταίους μηχανισμούς, δείτε [Αντικατάσταση γραμματοσειράς](/slides/el/androidjava/font-substitution/) και [Γραμματοσειρές εναλλακτικής λύσης](/slides/el/androidjava/fallback-font/).

Η αλλαγή μιας αντιστοιχίας στο [Presentation.getMasterTheme](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getMasterTheme--) επηρεάζει μόνο το περιεχόμενο του οποίου η αποτελεσματική μορφοποίηση εξακολουθεί να εξαρτάται από αυτό το θέμα. Το κείμενο μπορεί αντ' αυτού να κληρονομήσει μια παράκαμψη θέματος από έναν κύριο, διάταξη ή διαφάνεια, ή να χρησιμοποιήσει μια ρητά εκχωρημένη γραμματοσειρά. Εξετάστε αυτά τα επίπεδα όταν το ορατό αποτέλεσμα δεν ακολουθεί την αντιστοιχία σε επίπεδο παρουσίασης.

## **Καταστήστε τις αντιστοιχισμένες γραμματοσειρές διαθέσιμες και επαληθεύστε το αποτέλεσμα**

Μια αντιστοίχηση σεναρίου αποθηκεύει μόνο το όνομα της οικογένειας γραμματοσειράς· δεν εγκαθιστά ή φορτώνει το αντίστοιχο αρχείο γραμματοσειράς. Για συνεπή απόδοση και εξαγωγή, κάθε αντιστοιχισμένη γραμματοσειρά πρέπει να είναι εγκατεστημένη στο περιβάλλον ή να παρέχεται στο Aspose.Slides μέσω μιας προσαρμοσμένης πηγής, όπως το [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ή το [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Δείτε το [Custom Fonts](/slides/el/androidjava/custom-font/) για τις διαθέσιμες επιλογές φόρτωσης.

Η επαλήθευση της αποθηκευμένης αντιστοίχισης επιβεβαιώνει μόνο ότι ο ορισμός του θέματος διατηρήθηκε. Δεν αποδεικνύει ότι η γραμματοσειρά είναι διαθέσιμη, περιέχει όλα τα απαιτούμενα γλύφα ή παράγει την επιθυμητή διάταξη. Αποδώστε αντιπροσωπευτικό κείμενο για κάθε απαιτούμενο σύστημα γραφής σε εικόνα ή PDF και εξετάστε το αποτέλεσμα. Αυτό εντοπίζει ελλείπουσες γραμματοσειρές, ελλιπή κάλυψη γλύφων, συμπεριφορά εναλλακτικής λύσης και αλλαγές διάταξης πριν τη διανομή της παρουσίασης. Δείτε το [Convert PowerPoint Presentations](/slides/el/androidjava/convert-powerpoint/) για παραδείγματα απόδοσης και εξαγωγής.

## **Συχνές ερωτήσεις**

**Τι επιστρέφει το `getScriptFont` όταν ένα σενάριο δεν είναι αντιστοιχισμένο;**

[IFonts.getScriptFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) επιστρέφει `null` όταν η ζητούμενη αντιστοίχηση σεναρίου δεν είναι ορισμένη σε αυτήν τη κύρια ή δευτερεύουσα συλλογή γραμματοσειρών.

**Προσθέτει το `setScriptFont` μια δεύτερη αντιστοίχηση όταν το σενάριο υπάρχει ήδη;**

Όχι. Το [IFonts.setScriptFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) δημιουργεί την αντιστοίχηση όταν λείπει και αντικαθιστά την αντιστοιχισμένη οικογένεια γραμματοσειράς όταν η ίδια ετικέτα σεναρίου υπάρχει ήδη.

**Γιατί η αλλαγή μιας αντιστοίχισης θέματος δεν άλλαξε κάποιο κείμενο;**

Το κείμενο μπορεί να έχει μια ρητά εκχωρημένη γραμματοσειρά, να κληρονομήσει διαφορετικό θέμα μέσω παράκαμψης, ή να επηρεαστεί από αντικατάσταση ή εναλλακτική λύση κατά την απόδοση. Μια αντιστοίχηση σεναρίου σε επίπεδο παρουσίασης ελέγχει μόνο το κείμενο του οποίου η αποτελεσματική μορφοποίηση εξακολουθεί να αναφέρεται σε αυτή τη συλλογή γραμματοσειρών του θέματος.

**Είναι η αποθήκευση και επαναφόρτωση επαρκής για την επικύρωση του πολυγλωσίου αποτελέσματος;**

Όχι. Η επαναφόρτωση επαληθεύει τη διατήρηση των δεδομένων του θέματος. Επίσης, αποδώστε αντιπροσωπευτικό κείμενο από κάθε απαιτούμενο σύστημα γραφής για να επιβεβαιώσετε ότι οι αντιστοιχισμένες γραμματοσειρές είναι διαθέσιμες και περιέχουν τα απαραίτητα γλύφα.