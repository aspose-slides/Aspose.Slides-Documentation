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
description: "Αναζητήστε, επισημάνετε και αντικαταστήστε κείμενο σε παρουσιάσεις PowerPoint ενώ συλλέγετε κάθε αντιστοίχηση με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides για PHP μέσω Java μπορεί να αναζητήσει, να επισημάνει και να αντικαταστήσει κείμενο σε ένα μεμονωμένο πλαίσιο κειμένου ή σε ολόκληρη την παρουσίαση. Κάθε λειτουργία μπορεί επίσης να ειδοποιεί μια εφαρμογή για κάθε αντιστοίχηση μέσω μιας κλήσης επιστροφής αποτελέσματος. Αυτό καθιστά δυνατή την ενημέρωση μιας παρουσίασης και ταυτόχρονα τη δημιουργία ενός αρχείου ελέγχου που περιέχει το αντιστοιχισμένο κείμενο, το πλαίσιο του, τη θέση, το πλαίσιο κειμένου και τον αριθμό της διαφάνειας.

Αυτές οι δυνατότητες είναι χρήσιμες για ανασκόπηση, διαγραφή, έλεγχο ορολογίας, καθαρισμό προτύπων και αυτοματοποιημένες ροές εργασίας αναφοράς.

Στα πρώτα παραδείγματα παρακάτω, χρησιμοποιούμε ένα αρχείο με το όνομα "sample.pptx", το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το ακόλουθο κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επιλέξτε το Πεδίο Αναζήτησης**

Χρησιμοποιήστε μεθόδους στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) για να περιορίσετε μια λειτουργία σε ένα πλαίσιο κειμένου. Χρησιμοποιήτε μεθόδους στο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) για να επεξεργαστείτε όλο το κείμενο που ισχύει στην παρουσίαση.

| Λειτουργία | Ένα πλαίσιο κειμένου | Ολόκληρη η παρουσίαση |
|---|---|---|
| Επισήμανση κυριολεκτικού κειμένου | [TextFrame::highlightText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#highlightText) |
| Επισήμανση αντιστοιχίσεων κανονικής έκφρασης | [TextFrame::highlightRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#highlightRegex) |
| Αντικατάσταση κυριολεκτικού κειμένου | [TextFrame::replaceText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#replaceText) |
| Αντικατάσταση αντιστοιχίσεων κανονικής έκφρασης | [TextFrame::replaceRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#replaceRegex) |

## **Διαμορφώστε την Αντιστοίχηση Κειμένου**

Για λειτουργίες κυριολεκτικού κειμένου, χρησιμοποιήστε το [TextSearchOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/) για να ελέγξετε την αντιστοίχηση:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) περιορίζει τις αντιστοιχίες σε ολόκληρες λέξεις.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) ελέγχει αν πρέπει να ταιριάζει η διάκριση κεφαλαίων/μικρών.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) περιλαμβάνει τις σημειώσεις διαφάνειας σε λειτουργίες αναζήτησης, αντικατάστασης και επισήμανσης σε επίπεδο παρουσίασης.

Οι λειτουργίες κανονικής έκφρασης χρησιμοποιούν ένα Java `Pattern`, ώστε οι κανόνες αντιστοίχισης όπως η διάκριση κεφαλαίων/μικρών και τα όρια λέξεων να ορίζονται από την έκφραση και τις σημαίες της.

## **Καθορίστε τον Ιδιοκτήτη ενός Πλαισίου Κειμένου**

Γενικές ροές επεξεργασίας κειμένου συχνά λαμβάνουν ένα [TextFrame] κατά την αναζήτηση, αντικατάσταση, επικύρωση ή εξαγωγή κειμένου. Χρησιμοποιήστε τα [TextFrame::getParentShape] και [TextFrame::getParentCell] για να προσδιορίσετε ποιο αντικείμενο παρουσίασης κατέχει το πλαίσιο κειμένου.

Οι αναμενόμενες τιμές εξαρτώνται από τον ιδιοκτήτη:

| Ιδιοκτήτης πλαισίου κειμένου | `getParentShape` | `getParentCell` |
|---|---|---|
| Ένα AutoShape ή άλλο σχήμα που περιέχει κείμενο | Το κυρίως [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) | `null` |
| Ένα κελί πίνακα | `null` | Το κυρίως [Cell](https://reference.aspose.com/slides/el/php-java/aspose.slides/cell/) |

Και οι δύο μέθοδοι παρέχουν πλοήγηση μόνο για ανάγνωση. Η κλήση τους δεν μετακινεί το πλαίσιο κειμένου ούτε αλλάζει τον ιδιοκτήτη του. Ο γενικός κώδικας πρέπει να ελέγχει και τις δύο τιμές με `java_is_null` και να διαχειρίζεται την πιθανότητα να μην είναι διαθέσιμος κανένας ιδιοκτήτης.

Το παρακάτω παράδειγμα χρησιμοποιεί το [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/el/php-java/aspose.slides/slideutil/#getAllTextFrames) για να επαναλάβει όλα τα πλαίσια κειμένου σε μια παρουσίαση. Για σχήματα, αναφέρει το όνομα του σχήματος, τον τύπο χρόνου εκτέλεσης Java και τη διαφάνεια που το περιέχει. Για κελιά πίνακα, αναφέρει τις συντεταγμένες στήλης και σειράς (από το μηδέν) και τη διαφάνεια που τα περιέχει.

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

Για περιεχόμενο SmartArt, επαναλάβετε τα σχήματα στο [SmartArtNode::getShapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartnode/#getShapes) και αποκτήστε πρόσβαση σε κάθε [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartartshape/#getTextFrame). Το πλαίσιο κειμένου μπορεί να εντοπιστεί στο σχετικό σχήμα μέσω του [TextFrame::getParentShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#getParentShape), ενώ το [TextFrame::getParentCell](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#getParentCell) επιστρέφει `null`. Συνεπώς, το κλαδί σχήματος στο παράδειγμα χειρίζεται επίσης κείμενο από κόμβους SmartArt.

## **Συλλογή Πληροφοριών Αντιστοίχησης με Κλήση Επιστροφής**

Προωθήστε μια κλήση επιστροφής proxy Java σε μια μέθοδο επισήμανσης ή αντικατάστασης για να λάβετε ειδοποίηση για κάθε αντιστοίχηση. Η μέθοδος της κλήσης επιστροφής λαμβάνει το σχετικό πλαίσιο κειμένου, το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο και τη θέση της αντιστοίχισης.

Η κλήση επιστροφής δεν λαμβάνει άμεσα τον αριθμό της διαφάνειας. Η παρακάτω υλοποίηση τον εξάγει από τη γονική διαφάνεια και επίσης διαχειρίζεται κείμενο που βρίσκεται στις σημειώσεις διαφάνειας. Ο πίνακας αποτελεσμάτων χρησιμοποιεί `null` όταν το κείμενο σχετίζεται με άλλο τύπο διαφάνειας.

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
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

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

Δημιουργήστε ένα proxy για αυτό το αντικείμενο PHP πριν το περάσετε σε μια λειτουργία:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Για λειτουργίες αντικατάστασης, το `foundText` περιέχει το αρχικό αντιστοιχισμένο κείμενο, ώστε η κλήση επιστροφής μπορεί να καταγράψει ακριβώς ποιές λέξεις αντικαταστάθηκαν.

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [TextFrame::highlightText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#highlightText) για να επισημάνετε αντιστοιχίσεις κυριολεκτικού κειμένου σε ένα πλαίσιο κειμένου. Προωθήστε το [TextSearchOptions](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/) για να ελέγξετε την αναζήτηση.

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισημαίνει μόνο τη λέξη **"to"** πλήρως.

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

    // Επισήμανση μόνο της πλήρης λέξης "to".
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

## **Επισήμανση Κειμένου με Κανονικές Εκφράσεις**

Η μέθοδος [TextFrame::highlightRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#highlightRegex) επισημαίνει τις αντιστοιχίες κειμένου που βρίσκονται μέσω κανονικής έκφρασης σε ένα πλαίσιο κειμένου.

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

![Το επισημασμένο κείμενο με την κανονική έκφραση](highlighted_text_using_regex.png)

## **Επισήμανση Κειμένου σε Όλη την Παρουσίαση**

Χρησιμοποιήστε τα [Presentation::highlightText](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#highlightText) και [Presentation::highlightRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#highlightRegex) για να αναζητήσετε όλα τα συναφή πλαίσια κειμένου σε μια παρουσίαση. Το παρακάτω παράδειγμα επισημαίνει έναν κυριολεκτικό όρο και όλες τις διευθύνσεις email:

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

Χρησιμοποιήστε το [TextFrame::replaceText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceText) για κυριολεκτικό κείμενο και το [TextFrame::replaceRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceRegex) για αντικατάσταση βάσει προτύπου. Αυτές οι μέθοδοι ενημερώνουν το αντιστοιχισμένο κείμενο εντός του υπάρχοντος πλαισίου κειμένου, διατηρώντας τη μορφοποίηση των περιβάλλων τμημάτων αντί να ξαναδημιουργήσουν το πλαίσιο κειμένου από απλό κείμενο.

Το παρακάτω παράδειγμα σταθεροποιεί μια παραλλαγή ορθογραφίας και στη συνέχεια αντικαθιστά ετικέτες έκδοσης:

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

Αν μια αντιστοίχηση καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να επιβεβαιώσετε ποια μορφοποίηση πρέπει να εφαρμοστεί στο κείμενο αντικατάστασης.

## **Αντικατάσταση Κειμένου σε Όλη την Παρουσίαση**

Χρησιμοποιήστε τα [Presentation::replaceText](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#replaceText) και [Presentation::replaceRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#replaceRegex) για να εφαρμόσετε τις ίδιες λειτουργίες σε όλη την παρουσίαση. Αυτό είναι χρήσιμο για τον καθαρισμό προτύπων, τις ενημερώσεις ορολογίας και τη διαγραφή.

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

## **Ομαδοποίηση Αντιστοιχίσεων για Αναφορές**

Καθώς κάθε αποτέλεσμα αποθηκεύει τον αριθμό της διαφάνειας και το πλαίσιο κειμένου, οι εφαρμογές μπορούν να ομαδοποιούν τις αντιστοιχίσεις για ελεγκτικούς, αναφορικούς ή ελεγκτικούς κύκλους εργασίας. Το παρακάτω παράδειγμα ομαδοποιεί τα συλλεγμένα αποτελέσματα πρώτα ανά διαφάνεια και στη συνέχεια ανά πλαίσιο κειμένου:

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

Αποκτήστε το πλαίσιο κειμένου του σχήματος και καλέστε το [TextFrame::highlightText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#highlightText), το [TextFrame::highlightRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#highlightRegex), το [TextFrame::replaceText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceText) ή το [TextFrame::replaceRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceRegex) σε αυτό το πλαίσιο κειμένου. Οι μέθοδοι σε επίπεδο παρουσίασης επεξεργάζονται όλα τα συναφή πλαίσια κειμένου.

**Πώς μπορώ να αντιστοιχίσω πλήρεις λέξεις με τη σωστή κεφαλαία/μικρά;**

Ορίστε τα [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) και [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) σε `true` και προωθήστε τις επιλογές σε μια μέθοδο επισήμανσης ή αντικατάστασης κυριολεκτικού κειμένου. Για κανονικές εκφράσεις, καθορίστε τα όρια λέξεων και τη διάκριση κεφαλαίων/μικρών μέσα στο Java `Pattern` ίδιο του.

**Μπορεί η αναζήτηση και η αντικατάσταση να περιλαμβάνει κείμενο στις σημειώσεις διαφάνειας;**

Ναι. Ορίστε το [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/el/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) σε `true` όταν χρησιμοποιείτε μια λειτουργία κυριολεκτικού κειμένου σε επίπεδο παρουσίασης.

**Πώς μπορώ να δημιουργήσω μια αναφορά χωρίς να σαρώσω τη παρουσίαση δεύτερη φορά;**

Προωθήστε μια κλήση επιστροφής proxy Java στην λειτουργία επισήμανσης ή αντικατάστασης. Λαμβάνει κάθε αντιστοίχηση κατά τη διάρκεια της λειτουργίας, ώστε η εφαρμογή να μπορεί να αποθηκεύσει το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο, τη θέση, το πλαίσιο κειμένου και τον προκύπτοντα αριθμό διαφάνειας για μετέπειτα ομαδοποίηση ή εξαγωγή.

**Διατηρεί η αντικατάσταση κειμένου τη μορφοποίησή του;**

Οι μέθοδοι [TextFrame::replaceText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceText) και [TextFrame::replaceRegex](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#replaceRegex) τροποποιούν το αντιστοιχισμένο κείμενο εντός του υπάρχοντος πλαισίου κειμένου και διατηρούν τη μορφοποίηση των περιβάλλοντων τμημάτων. Εάν μια αντιστοίχηση καλύπτει τμήματα με διαφορετική μορφοποίηση, εξετάστε το αποτέλεσμα ώστε η αντικατάσταση να χρησιμοποιεί το επιθυμητό στυλ.