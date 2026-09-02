---
title: Διαμόρφωση αντικατάστασης γραμματοσειρών στις παρουσιάσεις με χρήση PHP
linktitle: Αντικατάσταση γραμματοσειράς
type: docs
weight: 70
url: /el/php-java/font-substitution/
keywords:
- γραμματοσειρά
- αντικαταστατική γραμματοσειρά
- αντικατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- αντικατάσταση γραμματοσειράς
- κανόνας αντικατάστασης
- κανόνας αντικατάστασης
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαμορφώστε τους κανόνες αντικατάστασης γραμματοσειρών και ελέγξτε τις αντικατεστημένες γραμματοσειρές στο Aspose.Slides για PHP μέσω Java κατά την απόδοση ή τη μετατροπή παρουσιάσεων PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Η αντικατάσταση γραμματοσειράς επιτρέπει στο Aspose.Slides να χρησιμοποιεί μια διαθέσιμη γραμματοσειρά αντί μιας γραμματοσειράς που δεν είναι προσβάσιμη όταν η παρουσίαση αποδίδεται ή μετατρέπεται. Η αντικατάσταση επηρεάζει το αποδιδόμενο αποτέλεσμα· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο περιεχόμενο της παρουσίασης.

Μπορείτε να ορίσετε τη γραμματοσειρά που θα χρησιμοποιείται όταν μια συγκεκριμένη γραμματοσειρά δεν είναι διαθέσιμη, και μπορείτε να ελέγξετε τις αντικαταστάσεις που το Aspose.Slides θα κάνει κατά την απόδοση. Αυτό βοηθά το αποτέλεσμα να παραμένει συνεπές μεταξύ περιβαλλόντων με διαφορετικές εγκατεστημένες γραμματοσειρές.

## **Λήψη αντικαταστάσεων γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [FontsManager::getSubstitutions](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/getsubstitutions/) για να καθορίσετε ποιες γραμματοσειρές θα αντικατασταθούν όταν η παρουσίαση αποδίδεται. Η μέθοδος επιστρέφει αντικείμενα [FontSubstitutionInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsubstitutioninfo/) που ταυτοποιούν τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών.

Το παρακάτω παράδειγμα PHP παραθέτει όλες τις αντικαταστάσεις γραμματοσειρών για μια παρουσίαση:

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

## **Λήψη αντικαταστάσεων γραμματοσειρών για επιλεγμένες διαφάνειες**

Χρησιμοποιήστε τη συνάρτηση [FontsManager::getSubstitutions](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/getsubstitutions/) με το όρισμα `int[] slides` για να ελέγξετε μόνο τις αντικαταστάσεις που απαιτούνται για την απόδοση συγκεκριμένων διαφανειών. Αυτό είναι χρήσιμο όταν αποδίδετε ή εξάγετε μέρος μιας παρουσίασης, ελέγχετε σταδιακά μια μεγάλη παρουσίαση, εντοπίζετε διαφάνειες που εξαρτώνται από μη διαθέσιμες γραμματοσειρές, προετοιμάζετε ένα ελάχιστο πακέτο γραμματοσειρών για διακομιστή ή контейнер, ή διαγωνίζεστε διαφορές απόδοσης χωρίς να επεξεργαστείτε άσχετες διαφάνειες.

Ο πίνακας `slides` περιέχει δείκτες διαφανειών αρχιζόμενους από το 1: το `1` αναφέρεται στην πρώτη διαφάνεια. Αντίθετα, ο συλλέχτης [Presentation::getSlides](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getSlides) χρησιμοποιεί μηδενική αρίθμηση, ώστε η ίδια διαφάνεια να προσπελαστεί ως `$presentation->getSlides()->get_Item(0)`. Κρατήστε αυτή τη διαφορά στο μυαλό σας όταν δημιουργείτε τον πίνακα για να αποφύγετε σφάλματα κατά ένα.

Κληθείτε την υπερφόρτωση μέσω της μεθόδου [Presentation::getFontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getFontsManager). Αυτή επιστρέφει μόνο τις αντικαταστάσεις που προσδιορίστηκαν κατά την απόδοση των επιλεγμένων διαφανειών. Κάθε αποτέλεσμα είναι ένα αντικείμενο [FontSubstitutionInfo](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsubstitutioninfo/) που περιέχει τα αρχικά και τα αντικατεστημένα ονόματα γραμματοσειρών. Το αποτέλεσμα αντανακλά το τρέχον περιβάλλον γραμματοσειρών, τους κανόνες εφεδρείας, τους κανόνες αντικατάστασης αποθηκευμένους σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsubstrulecollection/), καθώς και τις [εξωτερικά φορτωμένες γραμματοσειρές](/slides/el/php-java/custom-font/).

Η ίδια αντικατάσταση μπορεί να απαιτηθεί από περισσότερες από μία επιλεγμένες διαφάνειες. Απομακρύνετε τα διπλότυπα όταν δημιουργείτε απογραφή γραμματοσειρών ή αναφορά προελέγχου. Το παρακάτω παράδειγμα αναφέρει κάθε επιστρεφόμενη αντικατάσταση και στη συνέχεια δημιουργεί μια ταξινομημένη λίστα μοναδικών αντιστοιχίσεων γραμματοσειρών:

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

Η κλάση [FontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/) παρέχει και τις δύο υπερφορτώσεις. Επιλέξτε αυτή που ταιριάζει στο εύρος της λειτουργίας απόδοσης:

| Υπερφόρτωση | Χρησιμοποιήστε το όταν |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/getsubstitutions/) χωρίς ορίσματα | Χρειάζεστε αντικαταστάσεις για ολόκληρη την παρουσίαση. |
| [getSubstitutions](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/getsubstitutions/) με `int[] slides` | Χρειάζεστε αντικαταστάσεις για επιλεγμένο εύρος, σταδιακό έλεγχο ή μερική εξαγωγή. |

## **Ορισμός κανόνων αντικατάστασης γραμματοσειρών**

Για να ορίσετε τη γραμματοσειρά που πρέπει να χρησιμοποιεί το Aspose.Slides όταν μια πηγή γραμματοσειράς δεν είναι διαθέσιμη:

1. Φορτώστε την παρουσίαση.
2. Δημιουργήστε ορισμούς γραμματοσειρών για τη πηγή και τη γραμματοσειρά αντικατάστασης.
3. Δημιουργήστε ένα [FontSubstRule](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsubstrule/) με την προϋπόθεση [WhenInaccessible](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsubstcondition/).
4. Προσθέστε τον κανόνα σε μια [FontSubstRuleCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsubstrulecollection/).
5. Αναθέστε τη συλλογή χρησιμοποιώντας τη μέθοδο [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Αποδώστε ή μετατρέψτε την παρουσίαση.

Το παρακάτω παράδειγμα PHP αντικαθιστά το `Arial` με το `SomeRareFont` όταν το `SomeRareFont` δεν είναι διαθέσιμο και στη συνέχεια αποδίδει την πρώτη διαφάνεια για να επαληθεύσει το αποτέλεσμα. Η γραμματοσειρά αντικατάστασης πρέπει να είναι διαθέσιμη στο Aspose.Slides.

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

{{% alert color="info" title="Σημείωση" %}}
Για μια ανεξάρτητη αλλαγή των γραμματοσειρών που χρησιμοποιούνται σε ολόκληρη την παρουσίαση, δείτε την ενότητα [Font Replacement](/slides/el/php-java/font-replacement/).
{{% /alert %}}

## **Περιορισμοί για γραμματοσειρές μαθηματικών εξισώσεων**

Οι κανόνες αντικατάστασης γραμματοσειρών αποτελούν μέρος της τυπικής διαδικασίας επιλογής γραμματοσειράς που χρησιμοποιείται κατά την απόδοση και τη μετατροπή. Λειτουργούν για κανονικό κείμενο όταν το Aspose.Slides μπορεί να αντικαταστήσει μια μη προσβάσιμη γραμματοσειρά με τη διαθέσιμη γραμματοσειρά που καθορίζεται από έναν κανόνα.

Οι εξισώσεις Office Math έχουν πρόσθετη απαίτηση. Εάν μια εξίσωση χρησιμοποιεί τη **Cambria Math**, το Aspose.Slides μπορεί να χρειαστεί ακριβώς αυτή τη γραμματοσειρά για να υπολογίσει και να αποδώσει τη διάταξη της εξίσωσης. Ένας κανόνας που αντικαθιστά άλλη μαθηματική γραμματοσειρά, όπως η **STIX Two Math**, δεν μπορεί να αντικαταστήσει τη **Cambria Math** για αυτόν τον σκοπό, και η απόδοση μπορεί ακόμη να αναφέρει ότι απαιτείται η **Cambria Math**.

Για να αποδώσετε ή να μετατρέψετε μια τέτοια παρουσίαση, κάντε τη **Cambria Math** διαθέσιμη στο Aspose.Slides. Εγκαταστήστε τη στο λειτουργικό σύστημα ή φορτώστε τη ως [εξωτερική γραμματοσειρά](/slides/el/php-java/custom-font/).

Αυτός ο περιορισμός ισχύει για τη διάταξη εξίσωσης. Οι κανόνες αντικατάστασης που περιγράφηκαν παραπάνω εξακολουθούν να ισχύουν για το κανονικό κείμενο της παρουσίασης.

## **Συχνές ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ αντικατάστασης γραμματοσειράς και αντικατάστασης γραμματοσειράς;**  
Η [αλλαγή γραμματοσειράς](/slides/el/php-java/font-replacement/) αλλάζει σκόπιμα μια γραμματοσειρά σε άλλη σε όλη την παρουσίαση. Η αντικατάσταση γραμματοσειράς επιλέγει μια γραμματοσειρά για το αποδοθέν αποτέλεσμα όταν πληρούται η διαμορφωμένη προϋπόθεση, όπως όταν η αρχική γραμματοσειρά δεν είναι διαθέσιμη.

**Πότε εφαρμόζονται οι κανόνες αντικατάστασης;**  
Οι κανόνες συμμετέχουν στην [ακολουθία επιλογής γραμματοσειράς](/slides/el/php-java/font-selection-sequence/) κατά την απόδοση και τη μετατροπή. Με το `WhenInaccessible`, ένας κανόνας χρησιμοποιείται μόνο όταν το Aspose.Slides δεν μπορεί να προσπελάσει τη γραμματοσειρά πηγής.

**Τι συμβαίνει όταν λείπει μια γραμματοσειρά και δεν έχει οριστεί κανένας κανόνας αντικατάστασης;**  
Το Aspose.Slides επιλέγει τη πιο κοντινά διαθέσιμη γραμματοσειρά σύμφωνα με τη διαδικασία επιλογής γραμματοσειράς του. Το αποτέλεσμα εξαρτάται από τις γραμματοσειρές που είναι διαθέσιμες στο χρόνο εκτέλεσης.

**Μπορώ να φορτώσω εξωτερικές γραμματοσειρές για να αποφύγω την αντικατάσταση;**  
Ναι. Μπορείτε να [φορτώσετε εξωτερικές γραμματοσειρές](/slides/el/php-java/custom-font/) ώστε το Aspose.Slides να τις χρησιμοποιήσει κατά την απόδοση και τη μετατροπή.

**Διανέμει το Aspose τις γραμματοσειρές με τη βιβλιοθήκη;**  
Όχι. Είστε υπεύθυνοι για την παροχή των γραμματοσειρών και τη συμμόρφωση με τις άδειές τους.

**Μπορούν τα αποτελέσματα της αντικατάστασης να διαφέρουν μεταξύ Windows, Linux και macOS;**  
Ναι. Οι εγκατεστημένες γραμματοσειρές και οι τοποθεσίες αναζήτησης γραμματοσειρών διαφέρουν ανά λειτουργικό σύστημα, οπότε μια γραμματοσειρά που είναι διαθέσιμη σε ένα μηχάνημα μπορεί να απαιτεί αντικατάσταση σε ένα άλλο.

**Πώς μπορώ να διασφαλίσω συνεπή επιλογή γραμματοσειρών σε μαζικές μετατροπές;**  
Χρησιμοποιήστε τα ίδια αρχεία γραμματοσειρών και τις ίδιες εκδόσεις σε κάθε μηχάνημα ή κοντέινερ, [φορτώστε τις απαιτούμενες εξωτερικές γραμματοσειρές](/slides/el/php-java/custom-font/), και [ενσωματώστε τις γραμματοσειρές](/slides/el/php-java/embedded-font/) όταν επιτρέπουν οι άδειες. Μπορείτε επίσης να καλέσετε το [FontsManager::getSubstitutions](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/getsubstitutions/) πριν από την εξαγωγή για να εντοπίσετε μη αναμενόμενες αντικαταστάσεις.