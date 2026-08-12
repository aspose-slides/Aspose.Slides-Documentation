---
title: Αναζήτηση και Αντικατάσταση Κειμένου σε Παρουσιάσεις PowerPoint σε PHP
linktitle: Αναζήτηση και Αντικατάσταση Κειμένου
type: docs
weight: 55
url: /el/php-java/search-and-replace-text/
keywords:
- αναζήτηση κειμένου
- επισήμανση κειμένου
- αντικατάσταση κειμένου
- κανονική έκφραση
- κλήση επιστροφής αποτελέσματος
- πλαίσιο κειμένου
- αναφορά ελέγχου
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Αναζήτηση, επισήμανση και αντικατάσταση κειμένου σε παρουσιάσεις PowerPoint, ενώ συλλέγονται όλες οι αντιστοιχίσεις με το Aspose.Slides for PHP μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides for PHP μέσω Java μπορεί να αναζητά, να επισημαίνει και να αντικαθιστά κείμενο σε ένα μεμονωμένο πλαίσιο κειμένου ή σε ολόκληρη την παρουσίαση. Κάθε λειτουργία μπορεί επίσης να ειδοποιεί μια εφαρμογή για κάθε αντιστοίχιση μέσω μιας κλήσης επιστροφής αποτελέσματος. Αυτό καθιστά δυνατό το ενημέρωση μιας παρουσίασης και ταυτόχρονα τη δημιουργία ενός αρχείου ελέγχου που περιέχει το αντιστοιχισμένο κείμενο, το περιεχόμενό του, τη θέση, το πλαίσιο κειμένου και τον αριθμό της διαφάνειας.

Αυτές οι δυνατότητες είναι χρήσιμες για έλεγχο, διαγραφή, έλεγχο ορολογίας, καθαρισμό προτύπων και αυτοματοποιημένες ροές εργασίας αναφοράς.

Στα πρώτα παραδείγματα παρακάτω, χρησιμοποιούμε ένα αρχείο με όνομα "sample.pptx", το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το ακόλουθο κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επιλογή Πεδίου Αναζήτησης**

Χρησιμοποιήστε μεθόδους στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) για να περιορίσετε μια λειτουργία σε ένα πλαίσιο κειμένου. Χρησιμοποιήστε μεθόδους στο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) για να επεξεργαστείτε όλο το εφαρμόσιμο κείμενο στην παρουσίαση.

| Λειτουργία | Ένα πλαίσιο κειμένου | Ολόκληρη η παρουσίαση |
|---|---|---|
| Επισήμανση κυριολεκτικού κειμένου | [TextFrame::highlightText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#highlightText) |
| Επισήμανση αντιστοιχιών κανονικής έκφρασης | [TextFrame::highlightRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#highlightRegex) |
| Αντικατάσταση κυριολεκτικού κειμένου | [TextFrame::replaceText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#replaceText) |
| Αντικατάσταση αντιστοιχιών κανονικής έκφρασης | [TextFrame::replaceRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#replaceRegex) |

## **Διαμόρφωση Ταύτισης Κειμένου**

Για λειτουργίες κυριολεκτικού κειμένου, χρησιμοποιήστε το [TextSearchOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/) για να ελέγξετε την ταύτιση:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) περιορίζει τις αντιστοιχίες σε πλήρεις λέξεις.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) ελέγχει αν πρέπει να ταιριάζει ο χαρακτήρας κεφαλαίων/μικρών.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) περιλαμβάνει τις σημειώσεις διαφάνειας στις λειτουργίες αναζήτησης, αντικατάστασης και επισήμανσης σε επίπεδο παρουσίασης.

Οι λειτουργίες κανονικής έκφρασης χρησιμοποιούν ένα Java `Pattern`, έτσι οι κανόνες ταύτισης όπως η ευαισθησία σε πεζά/κεφαλαία και τα όρια λέξεων ορίζονται από την έκφραση και τις σημαίες της.

## **Συλλογή Πληροφοριών Αντιστοιχίας με Κλήση Επιστροφής**

Περάστε μια κλήση επιστροφής διαμεσολαβητή Java σε μια μέθοδο επισήμανσης ή αντικατάστασης για να λάβετε ειδοποίηση για κάθε αντιστοίχιση. Η μέθοδος κλήσης επιστροφής λαμβάνει το σχετικό πλαίσιο κειμένου, το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο και τη θέση της αντιστοίχισης.

Η κλήση επιστροφής δεν λαμβάνει άμεσα τον αριθμό διαφάνειας. Η παρακάτω υλοποίηση τον εξάγει από τη γονική διαφάνεια και επίσης διαχειρίζεται κείμενο που βρίσκεται σε σημειώσεις διαφάνειας. Ο πίνακας αποτελεσμάτων χρησιμοποιεί `null` όταν το κείμενο σχετίζεται με άλλο τύπο διαφάνειας.

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentSlide = $textFrame->getSlide();
        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

Δημιουργήστε έναν διαμεσολαβητή για αυτό το αντικείμενο PHP πριν το περάσετε σε μια λειτουργία:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Για λειτουργίες αντικατάστασης, το `foundText` περιέχει το αρχικό αντιστοιχισμένο κείμενο, έτσι η κλήση επιστροφής μπορεί να καταγράψει ακριβώς ποιες όροι αντικαταστάθηκαν.

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [TextFrame::highlightText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#highlightText) για να επισημάνετε τις κυριολεκτικές αντιστοιχίες κειμένου σε ένα πλαίσιο κειμένου. Περάστε το [TextSearchOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/) για να ελέγξετε την αναζήτηση.

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισημαίνει μόνο την πλήρη λέξη **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // Επισήμανση κάθε εμφάνισης του "try" στο πλαίσιο κειμένου.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // Επισήμανση μόνο της πλήρους λέξης "to".
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο](highlighted_text.png)

## **Επισήμανση Κειμένου Χρησιμοποιώντας Κανονικές Εκφράσεις**

Η μέθοδος [TextFrame::highlightRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#highlightRegex) επισημαίνει τις αντιστοιχίες κειμένου που βρίσκονται με μια κανονική έκφραση σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας επισημαίνει όλες τις λέξεις που περιέχουν επτά ή περισσότερους χαρακτήρες:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το επισημασμένο κείμενο χρησιμοποιώντας την κανονική έκφραση](highlighted_text_using_regex.png)

## **Επισήμανση Κειμένου σε Ολόκληρη την Παρουσίαση**

Χρησιμοποιήστε τις [Presentation::highlightText](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#highlightText) και [Presentation::highlightRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#highlightRegex) για να αναζητήσετε όλα τα εφαρμοστέα πλαίσια κειμένου σε μια παρουσίαση. Το παρακάτω παράδειγμα επισημαίνει έναν κυριολεκτικό όρο και όλες τις διευθύνσεις email:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Αντικατάσταση Κειμένου σε Πλαίσιο Κειμένου**

Χρησιμοποιήστε το [TextFrame::replaceText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceText) για κυριολεκτικό κείμενο και το [TextFrame::replaceRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceRegex) για αντικατάσταση βάσει προτύπου. Αυτές οι μέθοδοι ενημερώνουν το αντιστοιχισμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου, το οποίο διατηρεί τη μορφοποίηση των περιμετρικών τμημάτων αντί να ξαναδημιουργήσει το πλαίσιο κειμένου από μια απλή συμβολοσειρά.

Το παρακάτω παράδειγμα σταθεροποιεί μια παραλλαγή ορθογραφίας και στη συνέχεια αντικαθιστά ετικέτες εκδόσεων:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Εάν μια αντιστοίχιση καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε την έξοδο για να επιβεβαιώσετε ποια μορφοποίηση πρέπει να εφαρμοστεί στο κείμενο αντικατάστασης.

## **Αντικατάσταση Κειμένου σε Ολόκληρη την Παρουσίαση**

Χρησιμοποιήστε τις [Presentation::replaceText](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#replaceText) και [Presentation::replaceRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#replaceRegex) για να εφαρμόσετε τις ίδιες λειτουργίες σε όλη την παρουσίαση. Αυτό είναι χρήσιμο για καθαρισμό προτύπων, ενημερώσεις ορολογίας και διαγραφή.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Ομαδοποίηση Αντιστοιχιών για Αναφορά**

Επειδή κάθε αποτέλεσμα αποθηκεύει τον αριθμό της διαφάνειας και το πλαίσιο κειμένου, οι εφαρμογές μπορούν να ομαδοποιήσουν τις αντιστοιχίες για έλεγχο, αναφορά ή ροές εργασίας ανασκόπησης. Το παρακάτω παράδειγμα ομαδοποιεί τα συλλεχθέντα αποτελέσματα πρώτα κατά διαφάνεια και στη συνέχεια κατά πλαίσιο κειμένου:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αναζητήσω μόνο ένα πλαίσιο κειμένου αντί για ολόκληρη την παρουσίαση;**

Αποκτήστε το πλαίσιο κειμένου του σχήματος και καλέστε το [TextFrame::highlightText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceText) ή το [TextFrame::replaceRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceRegex) σε αυτό το πλαίσιο κειμένου. Οι μέθοδοι σε επίπεδο παρουσίασης επεξεργάζονται όλα τα εφαρμοστέα πλαίσια κειμένου αντί για αυτό.

**Πώς μπορώ να ταιριάξω πλήρεις λέξεις με τη σωστή κεφαλαιοποίηση;**

Ορίστε το [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) και το [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) σε `true` και περάστε τις επιλογές σε μια μέθοδο επισήμανσης ή αντικατάστασης κυριολεκτικού κειμένου. Για κανονικές εκφράσεις, ορίστε τα όρια λέξεων και την ευαισθησία σε πεζά/κεφαλαία στο ίδιο το Java `Pattern`.

**Μπορεί η αναζήτηση και η αντικατάσταση να περιλαμβάνει κείμενο σε σημειώσεις διαφάνειας;**

Ναι. Ορίστε το [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) σε `true` όταν χρησιμοποιείτε μια λειτουργία κυριολεκτικού κειμένου σε επίπεδο παρουσίασης.

**Πώς μπορώ να δημιουργήσω μια αναφορά χωρίς να σαρώσω ξανά την παρουσίαση;**

Περάστε μια κλήση επιστροφής διαμεσολαβητή Java στη λειτουργία επισήμανσης ή αντικατάστασης. Λαμβάνει κάθε αντιστοίχιση κατά τη διάρκεια της λειτουργίας, ώστε η εφαρμογή να μπορεί να αποθηκεύσει το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο, τη θέση, το πλαίσιο κειμένου και τον προεξαχθέντα αριθμό διαφάνειας για μετέπειτα ομαδοποίηση ή εξαγωγή.

**Διατηρεί η αντικατάσταση κειμένου τη μορφοποίησή του;**

[TextFrame::replaceText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceText) και [TextFrame::replaceRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceRegex) τροποποιούν το αντιστοιχισμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου και διατηρούν τη μορφοποίηση των περιμετρικών τμημάτων. Εάν μια αντιστοίχιση καλύπτει τμήματα με διαφορετική μορφοποίηση, εξετάστε το αποτέλεσμα για να διασφαλίσετε ότι η αντικατάσταση χρησιμοποιεί το επιθυμητό στυλ.