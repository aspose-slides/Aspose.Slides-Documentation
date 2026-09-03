---
title: Ενσωμάτωση Γραμματοσειρών σε Παρουσιάσεις με PHP
linktitle: Ενσωματωμένες Γραμματοσειρές
type: docs
weight: 40
url: /el/php-java/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- λήψη ενσωματωμένης γραμματοσειράς
- προσθήκη ενσωματωμένης γραμματοσειράς
- αφαίρεση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε ενσωματωμένες γραμματοσειρές στο PowerPoint με το Aspose.Slides για PHP μέσω Java. Προσθέστε, ανακτήστε, αφαιρέστε και συμπιέστε γραμματοσειρές ώστε να διατηρείται η εμφάνιση του κειμένου και να μειώνεται το μέγεθος του αρχείου."
---
## **Εισαγωγή**

Η ενσωμάτωση γραμματοσειρών αποθηκεύει τα δεδομένα γραμματοσειράς μέσα σε μια παρουσίαση PowerPoint. Όταν ένας προβολέας υποστηρίζει ενσωματωμένες γραμματοσειρές, μπορεί να εμφανίσει το κείμενο χρησιμοποιώντας αυτές τις γραμματοσειρές ακόμη και αν δεν είναι εγκατεστημένες στο σύστημα‑στόχο. Αυτό βοηθά στη διατήρηση των αλλαγών γραμμής, του διαστήματος κειμένου και της διάταξης των διαφανειών.

Το Aspose.Slides για PHP μέσω Java σας επιτρέπει να ανακτήσετε, να προσθέσετε και να αφαιρέσετε ενσωματωμένες γραμματοσειρές μέσω της κλάσης [FontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/) που επιστρέφεται από το [Presentation::getFontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getFontsManager). Μπορείτε επίσης να μειώσετε το μέγεθος των ενσωματωμένων δεδομένων γραμματοσειράς αφαιρώντας χαρακτήρες που η παρουσίαση δεν χρησιμοποιεί.

Τα παραδείγματα παρακάτω λειτουργούν με αρχεία PPTX. Πριν ενσωματώσετε μια γραμματοσειρά, βεβαιωθείτε ότι τα δεδομένα της γραμματοσειράς είναι διαθέσιμα στο Aspose.Slides και ότι η άδειά της επιτρέπει την ενσωμάτωση.

## **Λήψη και Κατάργηση Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιήστε το [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) για να εμφανίσετε τις γραμματοσειρές που αποθηκεύονται σε μια παρουσίαση. Για να καταργήσετε μία, περάστε μια γραμματοσειρά από αυτή τη λίστα στο [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) και, στη συνέχεια, αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα εμφανίζει τις ενσωματωμένες γραμματοσειρές στο αρχείο `EmbeddedFonts.pptx` και καταργεί τη Calibri εάν υπάρχει:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Η κατάργηση μιας ενσωματωμένης γραμματοσειράς αφαιρεί τα αποθηκευμένα δεδομένα της γραμματοσειράς· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο κείμενο. Εάν η γραμματοσειρά είναι εγκατεστημένη στο σύστημα‑στόχο, το κείμενο μπορεί ακόμη να τη χρησιμοποιήσει. Διαφορετικά, η απόδοση ενδέχεται να απαιτήσει [font substitution](/slides/el/php-java/font-substitution/), κάτι που μπορεί να επηρεάσει τη διάταξη.

## **Έλεγχος Δεδομένων Γραμματοσειράς και Δικαιωμάτων Ενσωμάτωσης**

Χρησιμοποιήστε την κλάση [FontsManager](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/) για να ελέγξετε τις γραμματοσειρές πριν τις ενσωματώσετε. Καλέστε το [FontsManager::getFonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#getFonts) για να ανακτήσετε τις γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση. Για κάθε γραμματοσειρά, περάστε ένα αντικείμενο [FontData](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontdata/) και την απαιτούμενη τιμή [FontStyleType](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontstyletype/) στο [FontsManager::getFontBytes](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#getFontBytes). Η μέθοδος επιστρέφει τα δυαδικά δεδομένα για αυτό το στυλ γραμματοσειράς, ή `null` όταν η ζητούμενη γραμματοσειρά ή στυλ δεν είναι διαθέσιμα. Μην περάσετε το αποτέλεσμα `null` στο [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), επειδή αυτή η μέθοδος απαιτεί έναν πίνακα byte.

[EmbeddingLevel](https://reference.aspose.com/slides/el/php-java/aspose.slides/embeddinglevel/) είναι μια απαρίθμηση σημαίας που αναφέρει τους περιορισμούς ενσωμάτωσης που αποθηκεύονται στη γραμματοσειρά:

- `Installable` επιτρέπει την ενσωμάτωση και την μόνιμη εγκατάσταση σε άλλο σύστημα, υπόκειται στην άδεια της γραμματοσειράς.
- `Restricted` απαγορεύει την ενσωμάτωση εκτός εάν ληφθεί άδεια από τον νόμιμο κάτοχο της γραμματοσειράς όταν είναι η μοναδική σημαία άδειας χρήσης.
- `PreviewPrint` επιτρέπει προσωρινή χρήση για προβολή και εκτύπωση· ένα έγγραφο που περιέχει τη γραμματοσειρά πρέπει να είναι μόνο για ανάγνωση.
- `Editable` επιτρέπει προσωρινή χρήση και επιτρέπει το έγγραφο να επεξεργαστεί και να αποθηκευτεί.
- `NoSubsetting` είναι ένας πρόσθετος περιορισμός που απαγορεύει την ενσωμάτωση μόνο ενός υποσυνόλου των γλυφών. Ενσωματώστε όλους τους χαρακτήρες όταν αυτή η σημαία είναι παρούσα.
- `BitmapOnly` είναι ένας πρόσθετος περιορισμός που επιτρέπει μόνο ενσωμάτωση bitmap strikes, όχι δεδομένων περιγράμματος. Εάν η γραμματοσειρά δεν έχει bitmap strikes, δεν μπορεί να ενσωματωθεί.

Οι πρώτες τέσσερις τιμές περιγράφουν την άδεια χρήσης, ενώ τα `NoSubsetting` και `BitmapOnly` μπορούν να συνδυαστούν με αυτές. Ελέγξτε τους τροποποιητές με λογικές πράξεις bitwise. Επειδή το `Installable` είναι μηδέν, κάντε μάσκα στα bits άδειας χρήσης και συγκρίνετε το αποτέλεσμα με το `Installable` αντί να το ελέγξετε ως σημαία. Οι τρέχουσες γραμματοσειρές θα πρέπει να θέτουν το πολύ ένα bit άδειας χρήσης. Για συμβατότητα με παλαιότερες γραμματοσειρές που ορίζουν περισσότερα από ένα, η βοηθητική λειτουργία παρακάτω επιλέγει την λιγότερο περιοριστική άδεια: `Editable`, έπειτα `PreviewPrint`, έπειτα `Restricted`.

Το παρακάτω παράδειγμα ελέγχει τα δεδομένα κανονικού, έντονου, πλάγιου και έντονου πλαγίου που είναι διαθέσιμα για κάθε γραμματοσειρά που επιστρέφεται από το `FontsManager::getFonts`. Παραλείπει τα στυλ που δεν είναι διαθέσιμα, τις περιορισμένες γραμματοσειρές, τις γραμματοσειρές μόνο bitmap, τις γραμματοσειρές περιορισμένες σε προεπισκόπηση και εκτύπωση επειδή η έξοδος παραμένει επεξεργάσιμη, και τις γραμματοσειρές που είναι ήδη ενσωματωμένες. Εάν κάποιο διαθέσιμο στυλ διαθέτει `NoSubsetting`, ενσωματώνει όλους τους χαρακτήρες για αυτήν την οικογένεια γραμματοσειράς.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Αυτή η επιθεώρηση αναφέρει τους περιορισμούς που κωδικοποιούνται σε κάθε αρχείο γραμματοσειράς. Δεν παρέχει άδεια, δεν αποδεικνύει ότι αποκτήσατε τη γραμματοσειρά νόμιμα και δεν αντικαθιστά τον έλεγχο της άδειας χρήσης της γραμματοσειράς πριν τη διανομή ενός ενσωματωμένου αντιγράφου.

## **Προσθήκη Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιήστε το [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) για να ενσωματώσετε μια γραμματοσειρά. Οι υπερφορτώσεις του δέχονται είτε ένα αντικείμενο [FontData](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontdata/) είτε έναν πίνακα byte που περιέχει τα δεδομένα της γραμματοσειράς. Η απαρίθμηση [EmbedFontCharacters](https://reference.aspose.com/slides/el/php-java/aspose.slides/embedfontcharacters/) ελέγχει ποιοι χαρακτήρες περιλαμβάνονται:

- [All](https://reference.aspose.com/slides/el/php-java/aspose.slides/embedfontcharacters/) ενσωματώνει όλους τους χαρακτήρες στη γραμματοσειρά. Χρησιμοποιήστε αυτήν την επιλογή όταν οι παραλήπτες πρέπει να επεξεργαστούν την παρουσίαση και να εισάγουν νέο κείμενο.
- [OnlyUsed](https://reference.aspose.com/slides/el/php-java/aspose.slides/embedfontcharacters/) ενσωματώνει μόνο τους χαρακτήρες που χρησιμοποιούνται στην παρουσίαση για να μειώσει το μέγεθος του αρχείου. Επιλέξτε αυτήν την επιλογή για τελική παρουσίαση που προορίζεται κυρίως για προβολή.

Το παρακάτω παράδειγμα χρησιμοποιεί το [FontsManager::getFonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#getFonts) για να ανακτήσει τις γραμματοσειρές που χρησιμοποιούνται στο `Fonts.pptx` και ενσωματώνει εκείνες που δεν είναι ήδη ενσωματωμένες. Οι γραμματοσειρές που θα προστεθούν πρέπει να είναι διαθέσιμες στο μηχάνυμα που εκτελεί τον κώδικα. Οι υπάρχουσες ενσωματωμένες γραμματοσειρές διατηρούν τα τρέχοντα σύνολα χαρακτήρων τους.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συμπίεση Ενσωματωμένων Γραμματοσειρών**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/#compressEmbeddedFonts) μειώνει τα ενσωματωμένα δεδομένα γραμματοσειράς αφαιρώντας αχρησιμοποίητους χαρακτήρες. Λειτουργεί σε γραμματοσειρές που είναι ήδη ενσωματωμένες, επομένως η μείωση του μεγέθους εξαρτάται από το πόσα αχρησιμοποίητα δεδομένα γραμματοσειράς περιέχει η παρουσίαση.

Το παρακάτω παράδειγμα συμπιέζει τις γραμματοσειρές στο `EmbeddedFonts.pptx` και αποθηκεύει το αποτέλεσμα ως ξεχωριστό αρχείο:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Διατηρήστε το αρχικό αρχείο εάν οι παραλήπτες μπορεί να χρειαστεί να προσθέσουν κείμενο αργότερα. Οι χαρακτήρες που αφαιρέθηκαν κατά τη συμπίεση δεν είναι πλέον διαθέσιμοι από την ενσωματωμένη γραμματοσειρά, ακόμη και αν αρχικά ενσωματώσατε όλους τους χαρακτήρες.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω αν μια ενσωματωμένη γραμματοσειρά θα συνεχίσει να αντικαθίσταται κατά την απόδοση;**

Καλέστε το [FontsManager::getSubstitutions](https://reference.aspose.com/slides/el/php-java/aspose.slides/fontsmanager/#getSubstitutions) στο περιβάλλον όπου αποδίδετε την παρουσίαση για να δείτε ποιες γραμματοσειρές θα αντικαταστήσει το Aspose.Slides. Επίσης ελέγξτε τις ρυθμίσεις [font substitution](/slides/el/php-java/font-substitution/) και τους κανόνες [font fallback](/slides/el/php-java/fallback-font/). Το fallback διαχειρίζεται τους ελλείποντες χαρακτήρες, έτσι η ενσωμάτωση μιας γραμματοσειράς δεν λύνει τους χαρακτήρες που η ίδια η γραμματοσειρά δεν περιέχει.

**Πρέπει να ενσωματώσω κοινές γραμματοσειρές όπως Arial και Calibri;**

Βασίστε την απόφαση στο στοχευόμενο περιβάλλον. Εάν οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες σε κάθε μηχάνημα που ανοίγει ή αποδίδει την παρουσίαση, η ενσωμάτωση τους μπορεί να προσθέσει περιττό μέγεθος αρχείου. Εάν οι παραλήπτες ή οι διακομιστές ενδέχεται να μην διαθέτουν αυτές τις γραμματοσειρές, η ενσωμάτωσή τους μπορεί να βοηθήσει στη διατήρηση της επιδιωκόμενης εμφάνισης, εφόσον οι άδειές τους το επιτρέπουν.