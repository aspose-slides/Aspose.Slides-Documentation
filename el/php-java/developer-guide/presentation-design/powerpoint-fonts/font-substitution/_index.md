---
title: Διαμόρφωση αντικατάστασης γραμματοσειρών σε παρουσιάσεις χρησιμοποιώντας PHP
linktitle: Αντικατάσταση γραμματοσειρών
type: docs
weight: 70
url: /el/php-java/font-substitution/
keywords:
- γραμματοσειρά
- εναλλακτική γραμματοσειρά
- αντικατάσταση γραμματοσειράς
- αλλαγή γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- κανόνας αντικατάστασης
- κανόνας αντικατάστασης
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαμορφώστε κανόνες αντικατάστασης γραμματοσειρών και ελέγξτε τις αντικατεστημένες γραμματοσειρές στο Aspose.Slides για PHP μέσω Java κατά την απόδοση ή μετατροπή παρουσιάσεων PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειρών επιτρέπει στο Aspose.Slides να χρησιμοποιεί μια διαθέσιμη γραμματοσειρά αντί μιας γραμματοσειράς που δεν είναι προσπελάσιμη όταν μια παρουσίαση αποδίδεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει το παραγόμενο αποτέλεσμα· δεν αλλάζει τη γραμματοσειρά που έχει εκχωρηθεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιείται όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη και να εξετάσετε τις αντικαταστάσεις που θα κάνει το Aspose.Slides κατά την απόδοση. Αυτό βοηθά στη διατήρηση συνεπούς εξόδου ανάμεσα σε περιβάλλοντα με διαφορετικές εγκατεστημένες γραμματοσειρές.

Αν μια γραμματοσειρά είναι διαθέσιμη αλλά δεν διαθέτει αποκλειστική έντονη εμφάνιση, δείτε [Διαχείριση γραμματοσειρών χωρίς αποκλειστική έντονη εμφάνιση](/slides/el/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Αυτή η ενότητα εξηγεί πώς να ραστεροποιήσετε το επηρεασμένο κείμενο κατά την εξαγωγή σε PDF και τις συνέπειες για επιλογή κειμένου, αναζήτηση και κλιμάκωση.

## **Λήψη αντικατάστασης γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) για να προσδιορίσετε ποιες γραμματοσειρές θα αντικατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) που ταυτοποιούν τα αρχικά και τα αντικαταστημένα ονόματα γραμματοσειρών.

Το παρακάτω παράδειγμα PHP εμφανίζει όλες τις αντικαταστάσεις γραμματοσειρών για μια παρουσίαση:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Λήψη αντικατάστασης γραμματοσειρών για επιλεγμένες διαφάνειες**

Χρησιμοποιήστε την υπερφόρτωση της μεθόδου [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) με όρισμα `int[] slides` για να εξετάσετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε σταδιακά μια μεγάλη παρουσίαση, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, ετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για διακομιστή ή κοντέινερ, ή διαγνώσκετε διαφορές απόδοσης χωρίς να επεξεργάζεστε μη σχετικές διαφάνειες.

Ο πίνακας `slides` περιέχει δείκτες διαφανειών με βάση το 1: το `1` προσδιορίζει την πρώτη διαφάνεια. Αντίθετα, ο προσπελάστριας συλλογής [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) χρησιμοποιεί μηδενική αρίθμηση, οπότε η ίδια διαφάνεια προσπελάζεται ως `$presentation->getSlides()->get_Item(0)`. Κρατήστε αυτή τη διαφορά στο μυαλό σας όταν δημιουργείτε τον πίνακα ώστε να αποφύγετε σφάλματα «από ένα».

Καλέστε την υπερφόρτωση μέσω της μεθόδου [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/). Επιστρέφει μόνο τις αντικαταστάσεις που προσδιορίστηκαν κατά την απόδοση των επιλεγμένων διαφανειών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα αντικαταστημένα ονόματα γραμματοσειρών. Το αποτέλεσμα αντανακλά το τρέχον περιβάλλον γραμματοσειρών, τους ρυθμισμένους κανόνες εναλλακτικών, τους κανόνες αντικατάστασης αποθηκευμένους σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) και τις [externally loaded fonts](/slides/el/php-java/custom-font/).

Η ίδια αντικατάσταση μπορεί να απαιτείται από περισσότερες από μία επιλεγμένες διαφάνειες. Απομακρύνετε τα διπλότυπα όταν δημιουργείτε ένα απογραφή γραμματοσειρών ή αναφορά προελέγχου. Το παρακάτω παράδειγμα καταγράφει κάθε επιστρεφόμενη αντικατάσταση και, στη συνέχεια, δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχίσεων γραμματοσειρών:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Η κλάση [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) παρέχει και τις δύο υπερφορτώσεις. Επιλέξτε μία σύμφωνα με το εύρος της λειτουργίας απόδοσης:

| Υπερφόρτωση | Χρησιμοποιήστε το όταν |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) με χωρίς ορίσματα | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) με `int[] slides` | Χρειάζεστε αντικαταστάσεις για επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός κανόνων αντικατάστασης γραμματοσειράς**

Για να καθορίσετε τη γραμματοσειρά που πρέπει να χρησιμοποιεί το Aspose.Slides όταν μια πηγαία γραμματοσειρά δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.
2. Δημιουργήστε ορισμούς γραμματοσειρών για τη πηγή και τις εναλλακτικές γραμματοσειρές.
3. Δημιουργήστε ένα [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) με την συνθήκη [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/).
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/).
5. Εκχωρήστε τη συλλογή χρησιμοποιώντας τη μέθοδο [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα PHP αντικαθιστά το `Arial` με το `SomeRareFont` όταν το `SomeRareFont` δεν είναι διαθέσιμο και, στη συνέχεια, αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η εναλλακτική γραμματοσειρά πρέπει να είναι διαθέσιμη στο Aspose.Slides.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Για μια άνευ όρων αλλαγή των γραμματοσειρών που χρησιμοποιούνται σε όλη την παρουσίαση, δείτε [Αντικατάσταση γραμματοσειρών](/slides/el/php-java/font-replacement/).
{{% /alert %}}

## **Περιορισμοί για γραμματοσειρές μαθηματικών εξισώσεων**

Οι κανόνες αντικατάστασης γραμματοσειρών αποτελούν μέρος της τυπικής διαδικασίας επιλογής γραμματοσειράς που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσπελάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που ορίζεται από έναν κανόνα.

Οι εξισώσεις Office Math έχουν πρόσθετη απαισία. Αν μια εξίσωση χρησιμοποιεί **Cambria Math**, το Aspose.Slides μπορεί να χρειάζεται ακριβώς αυτή τη γραμματοσειρά για να υπολογίσει και να αποδώσει τη διάταξη της εξίσωσης. Ένας κανόνας που αντικαθιστά άλλη μαθηματική γραμματοσειρά, όπως **STIX Two Math**, δεν μπορεί να αντικαταστήσει το **Cambria Math** για αυτόν τον σκοπό, και η απόδοση ενδέχεται ακόμα να αναφέρει ότι απαιτείται **Cambria Math**.

Για την απόδοση ή τη μετατροπή μιας τέτοιας παρουσίασης, κάντε το **Cambria Math** διαθέσιμο στο Aspose.Slides. Εγκαταστήστε το στο λειτουργικό σύστημα ή φορτώστε το ως [external font](/slides/el/php-java/custom-font/).

Αυτός ο περιορισμός ισχύει για τη διάταξη των εξισώσεων. Οι κανόνες αντικατάστασης που περιγράφηκαν παραπάνω εξακολουθούν να ισχύουν για το κανονικό κείμενο της παρουσίασης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειράς και αντικατάστασης γραμματοσειρών;**

[Font replacement](/slides/el/php-java/font-replacement/) αλλάζει σκόπιμα μια γραμματοσειρά με άλλη σε όλη την παρουσίαση. Η αντικατάσταση γραμματοσειρών επιλέγει μια γραμματοσειρά για το παραγόμενο αποτέλεσμα όταν πληρούται η ρυθμισμένη συνθήκη, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες αντικατάστασης;**

Οι κανόνες συμμετέχουν στην [font selection sequence](/slides/el/php-java/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με την `WhenInaccessible`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει τη πηγαία γραμματοσειρά.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν έχει ρυθμιστεί κανένας κανόνας αντικατάστασης;**

Το Aspose.Slides επιλέγει τη πιο κοντινή διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειράς. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την αντικατάσταση;**

Ναι. Μπορείτε να [load external fonts](/slides/el/php-java/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιεί κατά την απόδοση και τη μετατροπή.

**Διανέμει το Aspose γραμματοσειρές με τη βιβλιοθήκη;**

Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειές τους.

**Μπορούν τα αποτελέσματα αντικατάστασης να διαφέρουν μεταξύ Windows, Linux και macOS;**

Ναι. Οι εγκατεστημένες γραμματοσειρές και οι θέσεις αναζήτησης γραμματοσειρών διαφέρουν ανά λειτουργικό σύστημα, επομένως μια γραμματοσειρά που είναι διαθέσιμη σε ένα μηχάνημα μπορεί να απαιτεί αντικατάσταση σε άλλο.

**Πώς μπορώ να κάνω τη επιλογή γραμματοσειράς συνεπή σε μαζικές μετατροπές;**

Χρησιμοποιήστε τα ίδια αρχεία γραμματοσειρών και τις ίδιες εκδόσεις σε κάθε μηχάνημα ή κοντέινερ, [load required external fonts](/slides/el/php-java/custom-font/), και [embed fonts](/slides/el/php-java/embedded-font/) όταν οι άδειες το επιτρέπουν. Μπορείτε επίσης να καλέσετε το [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) πριν την εξαγωγή για να εντοπίσετε απρόσμενες αντικαταστάσεις.