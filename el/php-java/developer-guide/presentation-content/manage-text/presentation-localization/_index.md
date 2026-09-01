---
title: Αυτοματοποίηση της τοπικής προσαρμογής παρουσιάσεων σε PHP
linktitle: Τοπική Προσαρμογή Παρουσίασης
type: docs
weight: 100
url: /el/php-java/presentation-localization/
keywords:
- αλλαγή γλώσσας
- ορθογραφικός έλεγχος
- καταστολή ορθογραφικού ελέγχου
- γλώσσα επαλήθευσης
- αναγνωριστικό γλώσσας
- πολύγλωσσο κείμενο
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Ορίστε γλώσσες επαλήθευσης για κείμενο παρουσίασης PowerPoint και OpenDocument σε PHP με το Aspose.Slides, συμπεριλαμβανομένων των προεπιλογών και των πολύγλωσσων παραγράφων."
---
## **Επισκόπηση**

Το Aspose.Slides για PHP μέσω Java σάς επιτρέπει να ρυθμίσετε τα μεταδεδομένα επαλήθευσης για μεμονωμένα τμήματα κειμένου. Χρησιμοποιήστε [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLanguageId) για να προσδιορίσετε τη γλώσσα επαλήθευσης, [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setSpellCheck) για να επιτρέψετε ή να καταστέλετε τον ορθογραφικό έλεγχο και [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setProofDisabled) για να ελέγξετε την ευρύτερη κατάσταση «μη επαλήθευση». Επειδή αυτές οι ρυθμίσεις εφαρμόζονται σε επίπεδο τμήματος, μία παράγραφος μπορεί να περιέχει πολλαπλές γλώσσες και διαφορετικούς κανόνες επαλήθευσης.

Αυτό το άρθρο εξηγεί πώς να αναθέσετε μια γλώσσα σε συγκεκριμένο κείμενο, να ορίσετε την προεπιλεγμένη γλώσσα για νέο κείμενο με [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), να δημιουργήσετε πολύγλωσσες παραγράφους, να επιλέξετε μεταξύ `SpellCheck` και `ProofDisabled` και να διατηρήσετε τις προτιμώμενες ρυθμίσεις όταν χρησιμοποιείτε [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Αυτές οι ιδιότητες αποθηκεύουν μεταδεδομένα για εφαρμογές παρουσίασης· δεν μεταφράζουν κείμενο, δεν εκτελούν λεξικολογικό ορθογραφικό έλεγχο και δεν επιστρέφουν λανθασμένες λέξεις.

## **Ορισμός γλώσσας επαλήθευσης για κείμενο**

Δημιουργήστε ή φορτώστε μια [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/), αποκτήστε πρόσβαση στο απαιτούμενο τμήμα κειμένου μέσω του [Portion::getPortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/#getPortionFormat) και αναθέστε το αναγνωριστικό της γλώσσας του. Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα, ορίζει την βρετανική Αγγλική ως γλώσσα επαλήθευσης και αποθηκεύει το αποτέλεσμα με [Presentation::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#save):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ορισμός προεπιλεγμένης γλώσσας για νέο κείμενο**

Χρησιμοποιήστε [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) για να καθορίσετε τη γλώσσα επαλήθευσης που η Aspose.Slides θα αναθέτει στο νέο κείμενο. Αυτή η ρύθμιση είναι χρήσιμη όταν η πλειοψηφία ή όλο το νέο κείμενο σε μια παρουσίαση χρησιμοποιεί την ίδια γλώσσα. Δεν αλλάζει τα μεταδεδομένα γλώσσας του κειμένου που έχει ήδη ρητά ορισμένη γλώσσα.

Το ακόλουθο παράδειγμα δημιουργεί μια παρουσίαση όπου το νέο κείμενο χρησιμοποιεί γερμανικούς κανόνες επαλήθευσης:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Χρήση πολλαπλών γλωσσών σε μία παράγραφο**

Ένα [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) περιέχει μια συλλογή τμημάτων κειμένου. Δημιουργήστε ξεχωριστό [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) για κάθε γλώσσα και ορίστε το `LanguageId` του ανεξάρτητα.

Αυτό το παράδειγμα δημιουργεί μία παράγραφο με αγγλικά και γαλλικά τμήματα:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ενεργοποίηση ή καταστολή ορθογραφικού ελέγχου για μεμονωμένα τμήματα**

Το [PortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/portionformat/) κληρονομεί τις κοινές ιδιότητες κειμένου που ορίζει το [BasePortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/). Αποκτήστε πρόσβαση στη μορφή ενός τμήματος μέσω του [Portion::getPortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/#getPortionFormat) και χρησιμοποιήστε το [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setSpellCheck) για να ελέγξετε αν μια εφαρμογή παρουσίασης μπορεί να ελέγξει την ορθογραφία για εκείνο το τμήμα. Η προεπιλεγμένη τιμή είναι `false`: το `true` επιτρέπει τον έλεγχο, ενώ το `false` τον καταστέλλει.

Η ρύθμιση ισχύει για μεμονωμένα τμήματα κειμένου. Έτσι, διαφορετικά τμήματα στην ίδια παράγραφο μπορούν να έχουν διαφορετικές τιμές. Τα [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLanguageId) και `setSpellCheck` εξυπηρετούν συμπληρωματικούς σκοπούς: το `setLanguageId` προσδιορίζει τη γλώσσα επαλήθευσης, ενώ το `setSpellCheck` καθορίζει αν επιτρέπεται ο ορθογραφικός έλεγχος για το τμήμα.

Το [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setProofDisabled) ελέγχει επίσης την επαλήθευση, αλλά αντιπροσωπεύει την ευρύτερη κατάσταση «μη επαλήθευση» ως ένα [NullableBool](https://reference.aspose.com/slides/el/php-java/aspose.slides/nullablebool/). Χρησιμοποιήστε το `setSpellCheck` όταν χρειάζεστε άμεσο διακόπτη Boolean ειδικά για ορθογραφικούς ελέγχους. Χρησιμοποιήστε το `setProofDisabled` όταν θέλετε να διατηρήσετε ή να ελέγξετε ρητά τα μεταδεδομένα «μη επαλήθευση» της παρουσίασης, συμπεριλαμβανομένης της κατάστασης `NotDefined`. Εάν ορίσετε και τις δύο ιδιότητες, διατηρήστε τις τιμές τους συνεπείς· μην συνδυάσετε `setSpellCheck(true)` με `setProofDisabled(NullableBool::True)`.

Αυτές οι ιδιότητες διαμορφώνουν μεταδεδομένα επαλήθευσης που χρησιμοποιούνται από το PowerPoint και άλλες εφαρμογές παρουσίασης. Το Aspose.Slides δεν τις χρησιμοποιεί για εκτέλεση λεξικολογικού ορθογραφικού ελέγχου ή για επιστροφή λίστας λανθασμένων λέξεων.

Το παρακάτω πλήρες παράδειγμα δημιουργεί μια παρουσίαση εισόδου, τη φορτώνει, αναθέτει διαφορετικές ρυθμίσεις ορθογραφικού ελέγχου και γλώσσες επαλήθευσης σε δύο τμήματα της ίδιας παραγράφου, αποθηκεύει το αποτέλεσμα, το ξανανοίγει και επαληθεύει τις αποθηκευμένες τιμές:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) συνδυάζει διαδοχικά τμήματα που έχουν την ίδια μορφοποίηση. Μια διαφορά μόνο στο `SpellCheck` δεν διατηρεί τα τμήματα ξεχωριστά· μετά τη συγχώνευση, το προκύπτον τμήμα διατηρεί την τιμή `SpellCheck` του πρώτου τμήματος. Εάν τα τμήματα χρειάζονται διαφορετικές ρυθμίσεις ορθογραφικού ελέγχου, καλέστε το `joinPortionsWithSameFormatting` πριν την ανάθεση αυτών των ρυθμίσεων, ή εξετάστε τα όρια του προκύπτοντος τμήματος και επαναεφαρμόστε τις ρυθμίσεις μετά. Τα τμήματα με διαφορετικές τιμές `LanguageId` παραμένουν ξεχωριστά επειδή η μορφοποίηση γλώσσας επαλήθευσης διαφέρει.

## **Συχνές ερωτήσεις**

**Μεταφράζει το αναγνωριστικό γλώσσας το κείμενο;**

Όχι. Το [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLanguageId) αποθηκεύει μεταδεδομένα επαλήθευσης για ορθογραφία και γραμματική· δεν αλλάζει το περιεχόμενο του κειμένου. Μεταφράστε το κείμενο ξεχωριστά και, στη συνέχεια, ορίστε το κατάλληλο αναγνωριστικό γλώσσας για κάθε μεταφρασμένο τμήμα.

**Ελέγχει η γλώσσα επαλήθευσης τις γραμματοσειρές, τη συλλαβιστική διάσπαση ή την αναδίπλωση γραμμής;**

Όχι. Το αναγνωριστικό γλώσσας προορίζεται για επαλήθευση. Η απόδοση κειμένου και η διάταξη εξαρτώνται κυρίως από τις διαθέσιμες [fonts](/slides/el/php-java/powerpoint-fonts/), το σύστημα γραφής και τις ρυθμίσεις του πλαισίου κειμένου. Για αξιόπιστη απόδοση, παρέχετε τις απαιτούμενες γραμματοσειρές, ρυθμίστε την [font substitution](/slides/el/php-java/font-substitution/) ή [embed fonts](/slides/el/php-java/embedded-font/) στην παρουσίαση.

**Μπορεί μία παράγραφος να χρησιμοποιεί πολλές γλώσσες επαλήθευσης;**

Ναι. Αναθέστε κάθε γλώσσα σε ξεχωριστό τμήμα, όπως φαίνεται στο παράδειγμα πολύγλωσσης παραγράφου.

**Θα πρέπει να χρησιμοποιήσω `setDefaultTextLanguage` ή `setLanguageId`;**

Χρησιμοποιήστε το [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/el/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) όταν θέλετε μια προεπιλογή για το νέο κείμενο. Χρησιμοποιήστε το [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLanguageId) όταν ένα συγκεκριμένο τμήμα απαιτεί ρητή γλώσσα επαλήθευσης ή όταν μια παράγραφος περιέχει πολλαπλές γλώσσες.