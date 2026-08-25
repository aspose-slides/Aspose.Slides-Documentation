---
title: Διαχείριση Γραμματοσειρών Θέματος Καθορισμένων ανά Σενάριο σε PHP
linktitle: Γραμματοσειρές Θέματος Καθορισμένες ανά Σενάριο
type: docs
weight: 15
url: /el/php-java/script-specific-font-mappings/
keywords:
- γραμματοσειρά συγκεκριμένη για σενάριο
- χάρτης γραμματοσειράς θέματος
- πολύγλωσση παρουσίαση
- σύστημα γραφής
- γραμματοσειρά κυριλλική
- γραμματοσειρά αραβική
- γραμματοσειρά ιαπωνική
- γραμματοσειρά γεωργιανή
- γραμματοσειρά θαάνα
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εξετάστε, προσθέστε, αντικαταστήστε και αφαιρέστε χάρτες γραμματοσειρών συγκεκριμένων για σενάριο σε θέματα PowerPoint με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Ένα θέμα παρουσίασης μπορεί να επιλέξει διαφορετικές οικογένειες γραμματοσειρών για διαφορετικά συστήματα γραφής. Αυτό επιτρέπει πολύγλωσσο κείμενο που εξακολουθεί να χρησιμοποιεί τις γραμματοσειρές του θέματος να ακολουθεί ένα ενιαίο σχήμα γραμματοσειρών, ενώ χρησιμοποιεί κατάλληλες γραμματοσειρές για κυριλλικό, αραβικό, ιαπωνικό, γεωργιανό, θέανα και άλλα συστήματα.

Το [FontScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontscheme/) του θέματος περιέχει μια κύρια συλλογή γραμματοσειρών, συνήθως χρησιμοποιούμενη για επικεφαλίδες, και μια δευτερεύουσα συλλογή, συνήθως για το κυρίως κείμενο. Εκτός από τις ρυθμίσεις των λατινικών και των ανατολικών ασιατικών γραμματοσειρών, και οι δύο συλλογές [Fonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/fonts/) εκθέτουν αντιστοιχίες από ετικέτες συστήματος γραφής σε ονόματα οικογενειών γραμματοσειρών.

Αυτό το άρθρο δείχνει πώς να επιθεωρήσετε και να τροποποιήσετε αυτές τις αντιστοιχίες στο κύριο θέμα της παρουσίασης και να επαληθεύσετε ότι οι αλλαγές παραμένουν μετά από αποθήκευση‑επαναφόρτωση.

## **Κατανόηση Ετικετών Σεναρίου**

Οι μέθοδοι γραμματοσειρών σεναρίου χρησιμοποιούν τετραγράμματα BCP 47 για την ταυτοποίηση συστημάτων γραφής. Συνήθεις τιμές περιλαμβάνουν:

| Ετικέτα σεναρίου | Σύστημα γραφής |
|---|---|
| `Cyrl` | Κυριλλικό |
| `Arab` | Αραβικό |
| `Hans` | Απλοποιημένα Κινέζικα |
| `Jpan` | Ιαπωνικά |
| `Geor` | Γεωργιανό |
| `Thaa` | Θάανα |

Αυτές οι αντιστοιχίες ανήκουν στο σχήμα γραμματοσειρών του θέματος, όχι σε μεμονωμένα τμήματα κειμένου. Μια παρουσίαση μπορεί να ορίσει διαφορετικές αντιστοιχίες για τις κύριες και δευτερεύουσες συλλογές, και μπορεί να παραλείψει αντιστοιχίες για ορισμένα σενάρια.

## **Πρόσβαση και Έλεγχος Χαρτών Γραμματοσειρών Σεναρίου**

Χρησιμοποιήστε το [Presentation::getMasterTheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getMasterTheme) για πρόσβαση στο θέμα σε επίπεδο παρουσίασης. Οι μέθοδοι [MasterTheme::getFontScheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontscheme/#getMajor) και [FontScheme::getMinor](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontscheme/#getMinor) παρέχουν πρόσβαση στις δύο συλλογές [Fonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/fonts/).

Καλέστε το [Fonts::getScriptFontMap](https://reference.aspose.com/slides/el/php-java/aspose.slides/fonts/#getScriptFontMap) για να ανακτήσετε όλες τις αντιστοιχίες από μια συλλογή. Για να αναζητήσετε ένα σύστημα γραφής, καλέστε το [Fonts::getScriptFont](https://reference.aspose.com/slides/el/php-java/aspose.slides/fonts/#getScriptFont) με την ετικέτα του σεναρίου. Το `Fonts::getScriptFont` επιστρέφει `null` όταν η συλλογή δεν ορίζει την ζητούμενη αντιστοιχία.

## **Τροποποίηση Χαρτών και Επαλήθευση Διατήρησης**

Χρησιμοποιήστε το [Fonts::setScriptFont](https://reference.aspose.com/slides/el/php-java/aspose.slides/fonts/#setScriptFont) για να δημιουργήσετε ή να αντικαταστήσετε την τρέχουσα οικογένεια γραμματοσειράς. Χρησιμοποιήστε το [Fonts::removeScriptFont](https://reference.aspose.com/slides/el/php-java/aspose.slides/fonts/#removeScriptFont) για να αφαιρέσετε μια αντιστοιχία.

Το παρακάτω ολοκληρωμένο παράδειγμα διαβάζει όλες τις υπάρχουσες κύριες και δευτερεύουσες αντιστοιχίες, ανακτά τη βασική ιαπωνική γραμματοσειρά, αλλάζει τη βασική κυριλλική γραμματοσειρά, αφαιρεί τη δευτερεύουσα αντιστοιχία Θάανα, αποθηκεύει την παρουσίαση και την ανοίγει ξανά για να επαληθεύσει και τις δύο αλλαγές. Για να είναι το βήμα αφαίρεσης ανεξάρτητο από το αρχικό θέμα, το παράδειγμα δημιουργεί την αντιστοιχία Θάανα μόνο εάν δεν υπάρχει ήδη.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

Η επαλήθευση χρησιμοποιεί την ίδια συμπεριφορά `null` όπως μια κανονική αναζήτηση: μετά την αποθήκευση της αφαίρεσης, το `Fonts::getScriptFont("Thaa")` επιστρέφει `null` για τη δευτερεύουσα συλλογή.

## **Διαχωρισμός Χαρτών Θέματος από Άλλες Ρυθμίσεις Γραμματοσειράς**

Οι χάρτες θέματος ειδικών σεναρίων συμμετέχουν στην επιλογή γραμματοσειράς, αλλά λύνουν διαφορετικό πρόβλημα από άμεση μορφοποίηση κειμένου, αντικατάσταση και αναπλήρωση:

| Μηχανισμός | Σκοπός | Αποτέλεσμα αλλαγής χάρτη θέματος |
|---|---|---|
| Script-specific theme font mapping | Επιλέγει τη βασική ή δευτερεύουσα γραμματοσειρά θέματος για ένα σύστημα γραφής. | Το κείμενο που εξακολουθεί να χρησιμοποιεί τη σχετική γραμματοσειρά θέματος μπορεί να αντιστοιχίσει στη νέα οικογένεια. |
| Font assigned explicitly to a text portion | Καθορίζει την επιλεγμένη οικογένεια γραμματοσειράς σε εκείνο το τμήμα αντί να βασίζεται στο θέμα. | Το τμήμα μπορεί να παραμείνει αμετάβλητο επειδή η άμεση μορφοποίηση υπερτερεί της επιλογής του θέματος. |
| Font substitution | Αντικαθιστά μια ζητούμενη γραμματοσειρά όταν αυτή δεν είναι διαθέσιμη ή όταν ισχύει κανόνας αντικατάστασης. | Δρά μετά την αίτηση γραμματοσειράς· δεν επαναπροσδιορίζει το χάρτη σεναρίου του θέματος. |
| Font fallback | Παρέχει χαρακτήρες που δεν περιέχει η επιλεγμένη γραμματοσειρά, συχνά για συγκεκριμένα εύρη Unicode. | Συμπληρώνει την έλλειψη χαρακτήρων· δεν αλλάζει το αποθηκευμένο χάρτη θέματος. |

Για περισσότερες πληροφορίες σχετικά με τους δύο τελευταίους μηχανισμούς, δείτε [Font Substitution](/slides/el/php-java/font-substitution/) και [Fallback Fonts](/slides/el/php-java/fallback-font/).

Η αλλαγή ενός χάρτη στο [Presentation::getMasterTheme](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getMasterTheme) επηρεάζει μόνο το περιεχόμενο του οποίου η αποτελεσματική μορφοποίηση εξακολουθεί να εξαρτάται από αυτό το θέμα. Το κείμενο μπορεί αντίθετα να κληρονομήσει παράκαμψη θέματος από master, layout ή slide, ή να χρησιμοποιεί ρητά καθορισμένη γραμματοσειρά. Ελέγξτε αυτά τα επίπεδα όταν το οπτικό αποτέλεσμα δεν ακολουθεί το χάρτη σε επίπεδο παρουσίασης.

## **Καταστήστε τις Χαρτημένες Γραμματοσειρές Διαθέσιμες και Επικυρώστε το Αποτέλεσμα**

Ένας χάρτης σεναρίου αποθηκεύει το όνομα οικογένειας γραμματοσειράς· δεν εγκαθιστά ή φορτώνει το αντίστοιχο αρχείο γραμματοσειράς. Για συνεπή απόδοση και εξαγωγή, κάθε χαρτογραφημένη γραμματοσειρά πρέπει να είναι εγκατεστημένη στο περιβάλλον ή να παρέχεται στην Aspose.Slides μέσω προσαρμοσμένης πηγής, όπως το [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsloader/#loadExternalFonts) ή το [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Δείτε το [Custom Fonts](/slides/el/php-java/custom-font/) για τις διαθέσιμες επιλογές φόρτωσης.

Η επαλήθευση του αποθηκευμένου χάρτη επιβεβαιώνει μόνο ότι ο ορισμός θέματος διατηρήθηκε. Δεν αποδεικνύει ότι η γραμματοσειρά είναι διαθέσιμη, περιέχει όλα τα απαιτούμενα σύμβολα ή δημιουργεί την επιθυμητή διάταξη. Αποδώστε αντιπροσωπευτικό κείμενο για κάθε απαιτούμενο σύστημα γραφής σε εικόνα ή PDF και ελέγξτε το αποτέλεσμα. Αυτό εντοπίζει ελλείπουσες γραμματοσειρές, ελλιπείς κάλυψη σύμβολων, συμπεριφορά αναπλήρωσης και αλλαγές διάταξης πριν τη διανομή της παρουσίασης. Δείτε το [Convert PowerPoint Presentations](/slides/el/php-java/convert-powerpoint/) για παραδείγματα απόδοσης και εξαγωγής.

## **Συχνές Ερωτήσεις**

**Τι επιστρέφει το `Fonts::getScriptFont` όταν ένα σενάριο δεν έχει χαρτογραφηθεί;**

[Fonts::getScriptFont](https://reference.aspose.com/slides/el/php-java/aspose.slides/fonts/#getScriptFont) επιστρέφει `null` όταν η ζητούμενη αντιστοιχία σεναρίου δεν είναι ορισμένη σε εκείνη τη κύρια ή δευτερεύουσα συλλογή γραμματοσειρών.

**Προσθέτει το `Fonts::setScriptFont` δεύτερη αντιστοιχία όταν το σενάριο υπάρχει ήδη;**

Όχι. Το [Fonts::setScriptFont](https://reference.aspose.com/slides/el/php-java/aspose.slides/fonts/#setScriptFont) δημιουργεί την αντιστοιχία όταν λείπει και αντικαθιστά την υπάρχουσα οικογένεια γραμματοσειράς όταν η ετικέτα σεναρίου είναι ήδη παρούσα.

**Γιατί η αλλαγή χάρτη θέματος δεν άλλαξε κάποιο κείμενο;**

Το κείμενο μπορεί να έχει ρητά καθορισμένη γραμματοσειρά, να κληρονομεί διαφορετικό θέμα μέσω παράκαμψης ή να επηρεάζεται από αντικατάσταση ή αναπλήρωση κατά την απόδοση. Ένας χάρτης σεναρίου σε επίπεδο παρουσίασης ελέγχει μόνο το κείμενο του οποίου η αποτελεσματική μορφοποίηση εξακολουθεί να αναφέρεται στη συλλογή γραμματοσειρών του θέματος.

**Είναι η αποθήκευση και η επαναφόρτωση επαρκείς για την επικύρωση του πολυγλωσσικού αποτελέσματος;**

Όχι. Η επαναφόρτωση επαληθεύει μόνο τη διατήρηση των δεδομένων θέματος. Πρέπει επίσης να αποδοθεί αντιπροσωπευτικό κείμενο από κάθε απαιτούμενο σύστημα γραφής για να επιβεβαιωθεί ότι οι χαρτογραφημένες γραμματοσειρές είναι διαθέσιμες και περιέχουν τα απαιτούμενα σύμβολα.