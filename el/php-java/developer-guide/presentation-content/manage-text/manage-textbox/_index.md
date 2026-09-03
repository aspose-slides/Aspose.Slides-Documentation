---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις με PHP
linktitle: Διαχείριση πλαισίου κειμένου
type: docs
weight: 20
url: /el/php-java/manage-textbox/
keywords:
- πλαίσιο κειμένου
- πλαίσιο κειμένου
- προσθήκη κειμένου
- ενημέρωση κειμένου
- δημιουργία πλαισίου κειμένου
- έλεγχος πλαισίου κειμένου
- προσθήκη στήλης κειμένου
- προσθήκη υπερσύνδεσμου
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργία, αναγνώριση, μορφοποίηση και ενημέρωση πλαισίων κειμένου σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Aspose.Slides για PHP μέσω Java."
---
## **Εισαγωγή**

Στο Aspose.Slides για PHP μέσω Java, το κείμενο της διαφάνειας αποθηκεύεται σε πλαίσια κειμένου που ανήκουν σε σχήματα. Η κλάση [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) αντιπροσωπεύει το πιο κοινό σχήμα που περιέχει κείμενο και εκθέτει το κείμενό του μέσω της μεθόδου [AutoShape::getTextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}

Κάθε αυτόματο σχήμα προέρχεται από το [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/), αλλά δεν είναι κάθε σχήμα αυτόματο σχήμα ή υποστηρίζει πλαίσιο κειμένου. Όταν επεξεργάζεστε μια υπάρχουσα παρουσία, χρησιμοποιήστε `java_instanceof` για να ελέγξετε ότι ένα σχήμα είναι ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) πριν αποκτήσετε πρόσβαση στο κείμενό του.

{{% /alert %}}

## **Δημιουργία πλαισίου κειμένου σε διαφάνεια**

Για να δημιουργήσετε ένα πλαίσιο κειμένου, προσθέστε ένα αυτόματο σχήμα σε μια διαφάνεια, προσθέστε κείμενο στο πλαίσιο κειμένου του και αποθηκεύστε την παρουσία. Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο πλαίσιο κειμένου:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Οι συντεταγμένες και διαστάσεις που περνάνε στο [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/#addAutoShape) μετρώνται σε σημεία. Η [AutoShape::addTextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/#addTextFrame) αρχικοποιεί το πλαίσιο κειμένου με το παρεχόμενο κείμενο.

## **Έλεγχος για σχήμα πλαισίου κειμένου**

Χρησιμοποιήστε τη μέθοδο [AutoShape::isTextBox](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/#isTextBox) για να προσδιορίσετε εάν ένα αυτόματο σχήμα αντιμετωπίζεται ως πλαίσιο κειμένου. Αυτό είναι χρήσιμο όταν μια παρουσία περιλαμβάνει τόσο σχήματα με κείμενο όσο και καθαρά γραφικά αυτόματα σχήματα.

![Ένα πλαίσιο κειμένου και ένα σχήμα](istextbox.png)

Το παρακάτω παράδειγμα εξετάζει κάθε αυτόματο σχήμα σε μια παρουσία:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Ένα πρόσφατα προστεθειμένο αυτόματο σχήμα δεν θεωρείται πλαίσιο κειμένου μέχρι να περιέχει μη κενό κείμενο. Μπορείτε να παρέχετε αυτό το κείμενο μέσω της [AutoShape::addTextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/#addTextFrame) ή του [TextFrame::setText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#setText). Η προσθήκη ή ανάθεση μιας κενής συμβολοσειράς αφήνει τη [AutoShape::isTextBox](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/#isTextBox) να επιστρέφει `false`:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Οι δύο πρώτες κλήσεις εκτυπώνουν `true`; οι δύο τελευταίες εκτυπώνουν `false`.

## **Εύρεση του σχήματος που κατέχει πλαίσιο κειμένου**

Γενικός κώδικας επεξεργασίας κειμένου μπορεί να λάβει ένα [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) χωρίς να γνωρίζει ποιο αντικείμενο παρουσία το περιέχει. Χρησιμοποιήστε τη μέθοδο μόνο για ανάγνωση [TextFrame::getParentShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#getParentShape) για να πλοηγηθείτε πίσω στο ιδιοκτησιακό του [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/).

Για ένα πλαίσιο κειμένου που ανήκει σε ένα αυτόματο σχήμα ή σε κάποιο άλλο σ_shape_ με κείμενο, η [TextFrame::getParentShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#getParentShape) επιστρέφει τον κάτοχο και η [TextFrame::getParentCell](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#getParentCell) επιστρέφει `null`. Ελέγξτε την επιστρεφόμενη τιμή με `java_is_null` πριν την προσπελάσετε. Για να προσδιορίσετε τόσο τους κάτοχους σχήματος όσο και των κελιών πινάκων, συμπεριλαμβανομένων των σχημάτων που συνδέονται με κόμβους SmartArt, δείτε [Search and Replace Text](/slides/el/php-java/search-and-replace-text/).

## **Προσθήκη στηλών σε πλαίσιο κειμένου**

Η μέθοδος [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setColumnCount) διαιρεί το πλαίσιο κειμένου σε στήλες, ενώ η [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setColumnSpacing) ορίζει το κενό μεταξύ των στηλών σε σημεία. Και οι δύο ρυθμίσεις ανήκουν στο [TextFrameFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/) και μπορούν να αλλάξουν μέσω του πλαισίου κειμένου ενός υπάρχοντος πλαισίου κειμένου. Το κείμενο ρέει ξανά μεταξύ των στηλών μέσα στο ίδιο σχήμα· δεν συνεχίζεται σε άλλο σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα πλαίσιο κειμένου τριών στηλών με 10 σημεία διάστημα μεταξύ των στηλών, αποθηκεύει την παρουσία και διαβάζει τις αποθηκευμένες ρυθμίσεις από το αρχείο εξόδου:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Εξαγωγή κειμένου από μεμονωμένες στήλες**

Χρησιμοποιήστε το [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#splitTextByColumns) για να ανακτήσετε το κείμενο που έχει ανατεθεί σε κάθε οπτική στήλη ενός υπάρχοντος πλαισίου κειμένου. Η μέθοδος επιστρέφει μία συμβολοσειρά για κάθε στήλη, με τη σειρά ανάγνωσης βάσει στηλών. Ένα πλαίσιο κειμένου μίας στήλης παράγει έναν πίνακα με ένα στοιχείο, και μια κενή στήλη αναπαρίσταται από μια κενή συμβολοσειρά. Οι συμβολοσειρές περιέχουν μόνο ακατέργαστο κείμενο· η μορφοποίηση σε επίπεδο τμήματος δεν διατηρείται.

Αυτό είναι χρήσιμο όταν χρειάζεται να:

- Εξαγάγετε κείμενο διατηρώντας τη σειρά ανάγνωσης κατά στήλες.
- Ευρετηριάσετε ή συγκρίνετε το περιεχόμενο διαφανειών πολλαπλών στηλών.
- Εξάγετε κάθε στήλη σε ξεχωριστό αρχείο, πεδίο βάσης δεδομένων ή άλλο προορισμό.
- Εξετάσετε πώς το κείμενο αναδιανέμεται μετά την αλλαγή του αριθμού στηλών με το [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setColumnCount), του διαστήματος με το [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setColumnSpacing), της γραμματοσειράς ή του μεγέθους του πλαισίου κειμένου.

Η μέθοδος αναφέρει το κείμενο που κατανέμεται εντός του τρέχοντος [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/); δεν μεταφέρει αυτόματα το κείμενο μεταξύ ξεχωριστών σχημάτων ή πλαισίων κειμένου. Η κατανομή ανά στήλη εξαρτάται από τις διαθέσιμες γραμματοσειρές και άλλες ρυθμίσεις διάταξης κειμένου, οπότε βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες όταν τα αποτελέσματα πρέπει να είναι συνεπή.

Το παρακάτω παράδειγμα φορτώνει μια παρουσία, βρίσκει το πρώτο αυτόματο σχήμα πολλαπλών στηλών με πλαίσιο κειμένου, διαβάζει τον διαμορφωμένο αριθμό στηλών και γράφει το κείμενο από κάθε στήλη σε ξεχωριστό αρχείο. Τα σχήματα που δεν παρέχουν πλαίσιο κειμένου παραλείπονται.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Ενημέρωση κειμένου**

Για να ενημερώσετε το κείμενο σε όλη την παρουσία, επαναλάβετε τις διαφάνειες και τα σχήματα, επιλέξτε τα αυτόματα σχήματα και, στη συνέχεια, επεξεργαστείτε τα τμήματά τους. Η εργασία σε επίπεδο τμήματος σας επιτρέπει να αλλάξετε τόσο το κείμενο όσο και τη μορφοποίηση των χαρακτήρων.

Το παρακάτω παράδειγμα αντικαθιστά κάθε εμφάνιση του `years` με το `months` σε κείμενο αυτόματων σχημάτων και κάνει κάθε επηρεασμένο τμήμα έντονο:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Αυτή η διαπέραση ενημερώνει το κείμενο μόνο σε αυτόματα σχήματα. Το κείμενο που αποθηκεύεται σε πίνακες, διαγράμματα, SmartArt ή ομαδοποιημένα σχήματα απαιτεί διαπέραση των συλλογών των αντίστοιχων αντικειμένων.

## **Προσθήκη πλαισίου κειμένου με υπερσύνδεσμο**

Ένας υπερσύνδεσμος μπορεί να εκχωρηθεί σε συγκεκριμένο τμήμα κειμένου, ώστε μόνο αυτό το κείμενο να λειτουργεί ως κλικαρίσσιμος σύνδεσμος. Χρησιμοποιήστε το [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) για να συσχετίσετε το τμήμα με μια εξωτερική διεύθυνση URL.

Το παρακάτω παράδειγμα δημιουργεί συνδεδεμένο κείμενο και το αποθηκεύει σε μια παρουσία:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ ενός πλαισίου κειμένου και ενός σύμμεινου κειμένου σε μια κύρια ή διάταξη διαφάνειας;**

Ένα [placeholder](/slides/el/php-java/manage-placeholder/) μπορεί να κληρονομήσει τη θέση και τη μορφοποίησή του από μια [master slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/) ή [layout slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/). Ένα κανονικό πλαίσιο κειμένου είναι ένα ανεξάρτητο σχήμα στη διαφάνεια όπου δημιουργήθηκε και δεν αποκτά τη συμπεριφορά του σύμμεινου όταν η διάταξη αλλάζει.

**Πώς μπορώ να αντικαταστήσω κείμενο χωρίς να αλλάξω το κείμενο σε διαγράμματα, πίνακες ή SmartArt;**

Περιορίστε τη διαπέραση σε αντικείμενα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) όπως φαίνεται στο παράδειγμα Ενημέρωσης Κειμένου. Τα διαγράμματα, οι πίνακες και το SmartArt αποθηκεύουν κείμενο στα δικά τους μοντέλα αντικειμένων, οπότε δεν τροποποιούνται από αυτήν τη βρόχο.