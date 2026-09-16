---
title: Διαχείριση Υπερσυνδέσμων Παρουσίασης σε PHP
linktitle: Διαχείριση Υπερσυνδέσμων
type: docs
weight: 20
url: /el/php-java/manage-hyperlinks/
keywords:
- Προσθήκη URL
- Προσθήκη Υπερσυνδέσμου
- Δημιουργία Υπερσυνδέσμου
- Μορφοποίηση Υπερσυνδέσμου
- Αφαίρεση Υπερσυνδέσμου
- Ενημέρωση Υπερσυνδέσμου
- Υπερσύνδεσμος Κειμένου
- Υπερσύνδεσμος Διαφάνειας
- Υπερσύνδεσμος Σχήματος
- Υπερσύνδεσμος Εικόνας
- Υπερσύνδεσμος Βίντεο
- Μεταβλητός Υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Προσθήκη, μορφοποίηση, ενημέρωση και αφαίρεση υπερσυνδέσμων σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για PHP μέσω Java, χρησιμοποιώντας παραδείγματα PHP."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος συνδέει το περιεχόμενο της παρουσίασης με έναν ιστότοπο ή μια θέση μέσα στην παρουσίαση. Στο PowerPoint, οι υπερσύνδεσμοι συχνά εξυπηρετούν δύο σκοπούς:

* Άνοιγμα ιστοσελίδας από κείμενο, σχήμα ή πλαίσιο πολυμέσων.
* Περιήγηση σε άλλη διαφάνεια, π.χ. από πίνακα περιεχομένων.

Aspose.Slides for PHP via Java σας επιτρέπει να προσθέσετε αυτούς τους συνδέσμους, να ελέγξετε την εμφάνιση και τον ήχο τους, να ενημερώσετε τις ιδιότητές τους και να τους αφαιρέσετε. Τα παραδείγματα παρακάτω δείχνουν πώς να εργαστείτε με υπερσυνδέσμους σε μεμονωμένα στοιχεία και πώς να έχετε πρόσβαση σε υπερσυνδέσμους σε επίπεδο παρουσίασης, διαφάνειας ή πλαισίου κειμένου. Υποθέτουν ότι το PHP/Java Bridge και το wrapper Aspose.Slides PHP είναι αρχικοποιημένα. Τα μέλη API χωρίς σελίδα αναφοράς PHP συνδέονται με το υποκείμενο Java API.

{{% alert color="info" title="Note" %}}
Μπορείτε επίσης να επεξεργαστείτε παρουσιάσεις με τον [free online Aspose PowerPoint editor](https://products.aspose.app/slides/el/editor).
{{% /alert %}} 

## **Προσθήκη Υπερσυνδέσμων URL**

Μπορείτε να αντιστοιχίσετε μια διεύθυνση URL ιστοσελίδας σε κείμενο, σχήμα ή πλαίσιο πολυμέσων. Το στοιχείο στο οποίο αναθέτετε τον υπερσύνδεσμο καθορίζει την περιοχή που μπορεί να γίνει κλικ: ένα τμήμα κειμένου συνδέει το επιλεγμένο κείμενο, ενώ ένα σχήμα ή πλαίσιο συνδέει το αντικείμενο της διαφάνειας.

### **Προσθήκη Υπερσυνδέσμων URL σε Κείμενο**

Για να συνδέσετε κείμενο με έναν ιστότοπο, περάστε ένα [Hyperlink](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/) στη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/portionformat/sethyperlinkclick/) του τμήματος κειμένου, όπως φαίνεται παρακάτω. Μόνο αυτό το τμήμα κειμένου γίνεται κλικ.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Προσθήκη Υπερσυνδέσμων URL σε Σχήματα και Πλαίσια Πολυμέσων**

Για να κάνετε ένα σχήμα ή πλαίσιο κλικατο, καλέστε τη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/sethyperlinkclick/) του. Ο υπερσύνδεσμος ανήκει στο ίδιο το αντικείμενο και όχι σε κάποιο τμήμα κειμένου εντός αυτού.

Η ίδια προσέγγιση ισχύει για εικόνες, ήχη και βίντεο: αντιστοιχίστε τον υπερσύνδεσμο στο πλαίσιο και, αν χρειαστεί, καλέστε τη [setTooltip](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/settooltip/).

Το παρακάτω παράδειγμα κάνει ένα παραλληλόγραμμο κλικατό:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Χρήση Υπερσυνδέσεων για Δημιουργία Πίνακα Περιεχομένων**

Οι εσωτερικοί υπερσύνδεσμοι επιτρέπουν στους αναγνώστες να μεταβούν από έναν πίνακα περιεχομένων σε συγκεκριμένη διαφάνεια. Το παρακάτω παράδειγμα χρησιμοποιεί τη [setInternalHyperlinkClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) για να συνδέσει το κείμενο “Page 2” στην πρώτη διαφάνεια με τη δεύτερη διαφάνεια.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Μορφοποίηση Υπερσυνδέσεων**

### **Χρώμα**

Η μέθοδος [setColorSource](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/setcolorsource/) του [Hyperlink](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/) καθορίζει αν ένας υπερσύνδεσμος χρησιμοποιεί το χρώμα υπερσυνδέσμου της παρουσίασης ή τη διαμόρφωση του τμήματος κειμένου. Για να εφαρμόσετε προσαρμοσμένο χρώμα κειμένου, επιλέξτε [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkcolorsource/) και ορίστε το χρώμα γεμίσματος του τμήματος. Η δυνατότητα αυτή εισήχθη στο PowerPoint 2019· οι παλαιότερες εκδόσεις δεν εφαρμόζουν αυτή τη ρύθμιση.

Το επόμενο παράδειγμα προσθέτει δύο υπερσυνδέσμους κειμένου στην ίδια διαφάνεια. Ο πρώτος χρησιμοποιεί κόκκινο γέμισμα κειμένου, ενώ ο δεύτερος διατηρεί το προεπιλεγμένο χρώμα υπερσυνδέσμου.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **Ήχος**

Ένας υπερσύνδεσμος μπορεί να αναπαράγει ήχο όταν ενεργοποιείται ή να σταματήσει ήχο που ήδη παίζει. Χρησιμοποιήστε τις παρακάτω μεθόδους για να ρυθμίσετε αυτές τις συμπεριφορές:

- [Hyperlink::setSound](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/setsound/) καθορίζει το ήχο που σχετίζεται με τον υπερσύνδεσμο.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/setstopsoundonclick/) ελέγχει αν η ενεργοποίηση του υπερσυνδέσμου σταματά τον προηγούμενο ήχο.

#### **Προσθήκη Ήχου Υπερσύνδεσης**

Το επόμενο παράδειγμα φορτώνει το `sampleaudio.wav` και το συσχετίζει με ένα κουμπί στην πρώτη διαφάνεια. Κάνοντας κλικ στο κουμπί παίζει ο ήχος και μεταβαίνει στην επόμενη διαφάνεια. Ένα δεύτερο σχήμα σε αυτή τη διαφάνεια σταματά τον προηγούμενο ήχο όταν κάνει κλικ, χωρίς να εκτελεί ενέργεια πλοήγησης.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **Εξαγωγή Ήχου Υπερσύνδεσης**

Το επόμενο παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε παραπάνω και διαβάζει τον ήχο υπερσύνδεσμου του πρώτου σχήματος στη μνήμη μέσω των [getSound](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/getsound/) και [getBinaryData](https://reference.aspose.com/slides/el/php-java/aspose.slides/audio/getbinarydata/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Ρυθμίσεις Tooltip και Αλληλεπίδρασης**

Μπορείτε να καλέσετε τις παρακάτω μεθόδους του [Hyperlink](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/) μετά την ανάθεση υπερσύνδεσμου σε κείμενο ή σχήμα:

- [setTooltip](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/settooltip/) ορίζει το κείμενο που μπορεί να εμφανίσει ο θεατής ως υπόδειξη για τον σύνδεσμο.
- [setTargetFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/settargetframe/) καθορίζει το πλαίσιο προορισμού μέσα σε ένα γονικό HTML frameset, όταν ισχύει.
- [setHistory](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/sethistory/) ελέγχει αν η ενεργοποίηση του συνδέσμου προσθέτει τον προορισμό του στη λίστα των προβαλλόμενων υπερσυνδέσμων.
- [setHighlightClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/sethighlightclick/) ελέγχει αν ο υπερσύνδεσμος επισημαίνεται όταν γίνεται κλικ.

## **Αφαίρεση Υπερσυνδέσεων από Παρουσιάσεις**

Χρησιμοποιήστε το [getAnyHyperlinks](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) για να συλλέξετε τα containers υπερσυνδέσμων, συμπεριλαμβανομένων των συνδέσμων τμημάτων κειμένου, πριν τα αλλάξετε. Το παρακάτω παράδειγμα αφαιρεί και τους δύο τύπους ενεργοποίησης από την πρώτη διαφάνεια. Για να αφαιρέσετε μόνο έναν τύπο, καλέστε μόνο το [removeHyperlinkClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) ή το [removeHyperlinkMouseOver](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); η αφαίρεση μιας ενέργειας κλικ δεν αφαιρεί το αντίστοιχο mouse‑over.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Για αφαίρεση χωρίς προϋποθέσεις, το [removeAllHyperlinks](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) αφαιρεί και τους δύο τύπους ενεργοποίησης στο επιλεγμένο πεδίο με μία κλήση. Για επιλεκικό καθαρισμό και κάλυψη των master, layout και σημειώσεων, δείτε το [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Δημιουργία Πλήρους Καταλόγου Υπερσυνδέσεων**

Πριν διανείμετε μια παρουσίαση, καταγράψτε τις διαδραστικές της ενέργειες καθώς και τους σύνδεσμούς ιστού. Το [getAnyHyperlinks](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) επιστρέφει αντικείμενα [IHyperlinkContainer](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkcontainer/), όχι μια επίπεδη λίστα συμβολοσειρών URL. Εξετάστε τόσο το [getHyperlinkClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) όσο και το [getHyperlinkMouseOver](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) σε κάθε container. Είναι ανεξάρτητα: το ίδιο container μπορεί να εκθέτει και τις δύο ενέργειες, έτσι ένας πλήρης αναφοράς χρειάζεται έως δύο γραμμές ανά container.

Η σάρωση μόνο σε επίπεδο σχήματος μπορεί να παραβλέψει συνδέσμους που είναι ενσωματωμένοι σε τμήματα κειμένου. Κάντε ερώτημα στο κατάλληλο πεδίο και διατηρήστε τα containers που επιστρέφονται ώστε να μπορείτε αργότερα να ενημερώσετε ή να αφαιρέσετε τις ενέργειές τους.

### **Ερώτημα Πεδίου Παρουσίασης, Διαφάνειας και Πλαισίου Κειμένου**

Η κλάση [HyperlinkQueries](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkqueries/) είναι διαθέσιμη μέσω των [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), και [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/gethyperlinkqueries/). Κάθε πεδίο υποστηρίζει τις ίδιες ερωτήσεις:

- [getHyperlinkClicks](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) επιστρέφει containers με ενέργεια κλικ.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) επιστρέφει containers με ενέργεια mouse‑over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) επιστρέφει containers με μία ή και τις δύο ενέργειες.

Το παρακάτω παράδειγμα δημιουργεί το `hyperlink-audit-input.pptx` με εξωτερικό κλικ‑σύνδεσμο, σύνδεσμο αρχείου mouse‑over, εσωτερική πλοήγηση διαφάνειας, σύνδεσμο κειμένου mouse‑over και ενέργεια μακροεντολής. Δεν εκτελεί καμία από αυτές τις ενέργειες. Οι τρεις ερωτήσεις λειτουργούν σε κάθε πεδίο· οι μετρήσεις περιγράφουν containers, όχι το σύνολο των ενεργειών. Το πεδίο text‑frame εξαιρεί τους δικούς του συνδέσμους του περιβάλλοντος σχήματος.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Για αυτό το παράδειγμα, οι ερωτήσεις παρουσίασης και διαφάνειας αναφέρουν τρία containers κλικ, δύο containers mouse‑over και τρία containers με κάποια ενέργεια. Η ερώτηση text‑frame αναφέρει ένα container σε κάθε κατηγορία.

### **Κατηγοριοποίηση Ενεργειών και Προορισμών**

Χρησιμοποιήστε το [Hyperlink::getActionType](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/getactiontype/) για να ερμηνεύσετε μια ενέργεια πριν ερμηνεύσετε τον προορισμό της. Οι τιμές του [HyperlinkActionType](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkactiontype/) καλύπτουν περισσότερα από πλοήγηση στο web:

| Τιμές | Νόημα για έλεγχο |
| --- | --- |
| `Hyperlink` | Εξωτερικός υπερσύνδεσμος· επιθεώρηση του URL και του σχήματός του. |
| `JumpSpecificSlide` | Εσωτερική πλοήγηση σε συγκεκριμένη διαφάνεια. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ενσωματωμένη πλοήγηση παρουσίασης, επιλύεται στο πλαίσιο παρουσίασης. |
| `JumpEndShow`, `StartCustomSlideShow` | Τερματισμός της τρέχουσας παρουσίασης ή έναρξη προσαρμοσμένης παρουσίασης. |
| `StartMacro` | Εκτέλεση μακροεντολής. |
| `StartProgram` | Έναρξη προγράμματος. |
| `OpenFile`, `OpenPresentation` | Άνοιγμα αρχείου ή άλλης παρουσίασης· ελέγξτε ξεχωριστά από τις διευθύνσεις ιστού. |
| `StartStopMedia` | Έναρξη ή διακοπή αναπαραγωγής πολυμέσων. |
| `NoAction`, `Unknown` | Καμία ενέργεια πλοήγησης ή μη αναγνωρισμένη ενέργεια που απαιτεί επανεξέταση. |

Διαβάστε εξωτερικούς προορισμούς από το [getExternalUrl](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/getexternalurl/) και συγκεκριμένους εσωτερικούς προορισμούς από το [getTargetSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/gettargetslide/). Οι εσωτερικές ενέργειες και οι ενσωματωμένες εντολές μπορεί να μην έχουν εξωτερικό URL· ένα κενό URL δεν σημαίνει ότι το container δεν έχει ενέργεια. Διατηρήστε την τιμή που επιστρέφει το [getExternalUrlOriginal](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) όταν διαφέρει από το κανονικοποιημένο URL, και συμπεριλάβετε το tooltip που επιστρέφει το [getTooltip](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/gettooltip/) όταν είναι διαθέσιμο.

### **Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσεων**

Το παρακάτω παράδειγμα PHP διαβάζει μια υπάρχουσα παρουσίαση (χρησιμοποιήστε το αρχείο που δημιουργήθηκε παραπάνω), γράφει το `hyperlink-audit.json`, εφαρμόζει μια πολιτική, αποθηκεύει το `hyperlink-sanitized.pptx` και το ανοίγει ξανά για να ελέγξει και πάλι και τις δύο ενεργοποιήσεις. Συλλέγει containers πριν τα αλλάξει και χρησιμοποιεί ισοδυναμία αναφοράς για να αποφύγει την επεξεργασία του ίδιου container δύο φορές. Οι ερωτήσεις παρουσίασης καλύπτουν τις κοινές διαφάνειες· για έναν κατάλογο ολόκληρης της συσκευής, ερωτά επίσης ρητά master, layout, σημειώσεις και τους master σημειώσεων και φυλλαδίου όταν υπάρχουν.

Η αναφορά καταγράφει έναν δείκτη διαφάνειας με βάση το ένα και το [getSlideId](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseslide/#getSlideId--) όταν είναι διαθέσιμο. Το [ISlideComponent::getSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecomponent/#getSlide--) παρέχει τη διαφάνεια ιδιοκτήτη για υποστηριζόμενα containers. Τα master, layout και σημειώσεις δεν έχουν κανονικό δείκτη διαφάνειας και προσδιορίζονται από το πεδίο τους. Τα containers σχήματος και τα containers διαμόρφωσης τμημάτων κειμένου επισημαίνονται ξεχωριστά· άλλοι τύποι containers διατηρούν το όνομα τύπου χρόνου εκτέλεσης. Κάθε container λαμβάνει ένα τοπικό ID αναφοράς ώστε οι δύο του δράσεις να συσχετιστούν. Η αναφορά αποθηκεύει τους τύπους δράσης ως ακέραιους σταθερούς που ορίζονται από την παρτίδα PHP.

Αυτή η σκόπιμα περιοριστική πολιτική εφαρμογής επιτρέπει μόνο απόλυτα HTTPS URLs και έγκυρους εσωτερικούς προορισμούς διαφάνειας. Απορρίπτει μακροεντολές, προγράμματα, ενέργειες αρχείων, άλλες ενέργειες παρουσίασης, άγνωστες ενέργειες και άλλες σχήματα URL. Αυτές οι απορρίψεις είναι αποφάσεις πολιτικής, όχι απόφαση ασφαλείας του Aspose.Slides. Το HTTPS μόνο δεν εγγυάται εμπιστοσύνη: προσθέστε λιστες επιτρεπόμενων υποδοχέων και άλλους ελέγχους για την εφαρμογή σας. Και τα αρχικά και τα κανονικοποιημένα εξωτερικά URLs ελέγχονται. Το παράδειγμα ελέγχει μεταδεδομένα χωρίς να ακολουθεί συνδέσμους ή να εκτελεί ενέργειες.

Για αποκατάσταση, το [getHyperlinkManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) του container υποστηρίζει τις [setExternalHyperlinkClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) και [removeHyperlinkMouseOver](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Εδώ, οι απαγορευμένοι εξωτερικοί κλικ‑σύνδεσμοι αντικαθίστανται με μια σταθερή HTTPS σελίδα προορισμού· άλλοι απαγορευμένοι κλικ και απαγορευμένες ενέργειες mouse‑over αφαιρούνται ανεξάρτητα. Ορίστε το `$replaceExternalClicks` σε `false` για να αφαιρέσετε όλες τις παραβιάσεις πολιτικής. Επιλέξτε μια σελίδα αντικατάστασης που ανήκει στην εφαρμογή πριν από την ανάπτυξη.

Η σημαία εξαγωγής της αναφοράς χρησιμοποιεί μια συντηρητική πολιτική ανασκόπησης PDF: επισημαίνει ενέργειες mouse‑over και οτιδήποτε εκτός από εξωτερικό σύνδεσμο ή συγκεκριμένο άλμα διαφάνειας ως πιθανώς μη υποστηριζόμενο. Είναι μια υπόδειξη ανασκόπησης, όχι δοκιμή ικανότητας ή εγγύηση ότι οι μη επισημασμένοι σύνδεσμοι θα παραμείνουν στην εξαγωγή. Οι υποστηριζόμενες εξαγωγές [PDF](/slides/el/php-java/convert-powerpoint-to-pdf/) και [HTML](/slides/el/php-java/convert-powerpoint-to-html/) μπορεί να διατηρήσουν υπερσυνδέσμους, ανάλογα με την ενέργεια, τις επιλογές εξαγωγής και το πρόγραμμα προβολής. Τα raster [images](/slides/el/php-java/convert-powerpoint-to-png/) και [video](/slides/el/php-java/convert-powerpoint-to-video/) δεν μπορούν να διατηρήσουν διαδραστικούς υπερσυνδέσμους· σημειώστε κάθε ενέργεια όταν ελέγχετε για αυτές τις εξόδους.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Με το παραπάνω εισαγόμενο αρχείο, η αναφορά περιέχει πέντε γραμμές δράσεων. Ο σύνδεσμος αρχείου mouse‑over και η μακροεντολή κλικ αφαιρούνται, ενώ οι HTTPS σύνδεσμοι και η εσωτερική πλοήγηση διαφάνειας παραμένουν. Η επαλήθευση εκτυπώνει μηδενικές απαγορευμένες ενέργειες. Μια είσοδος που περιέχει απαγορευμένο εξωτερικό URL κλικ επίσης ενεργοποιεί το κλάδο αντικατάστασης. Ένα container με επιτρεπόμενο κλικ και απαγορευμένο mouse‑over διατηρεί την ενέργεια κλικ του.

Αυτός ο επιλεκτικός καθαρισμός διαφέρει από το [removeAllHyperlinks](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), το οποίο αφαιρεί και τις δύο ενεργοποιήσεις σε όλο το επιλεγμένο πεδίο ανεξάρτητα από την πολιτική. Η επαλήθευση εδώ ελέγχει μόνο τις ενέργειες υπερσυνδέσμων· δεν αφαιρεί ενσωματωμένα VBA projects, OLE objects ή άλλο ενεργό περιεχόμενο, και δεν επικυρώνει ένα εξαχθέν PDF ή HTML αρχείο.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να συνδέσω με μια ενότητα ή την πρώτη της διαφάνεια;**

Οι ενότητες στο PowerPoint ομαδοποιούν διαφάνειες, αλλά ένας εσωτερικός υπερσύνδεσμος στοχεύει σε μια συγκεκριμένη διαφάνεια. Για να δημιουργήσετε πλοήγηση σε ενότητα, συνδέστε στην πρώτη διαφάνεια της ενότητας.

**Μπορώ να προσθέσω υπερσύνδεσμο σε στοιχεία κύριας διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία της κύριας διαφάνειας και των διατάξεων υποστηρίζουν υπερσυνδέσμους. Οι σύνδεσμοι σε αυτά τα στοιχεία είναι διαθέσιμοι κατά τη διάρκεια της παρουσίασης στις διαφάνειες που χρησιμοποιούν την αντίστοιχη κύρια ή διάταξη.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Οι υποστηριζόμενες εξαγωγές PDF και HTML μπορεί να διατηρήσουν τους υπερσυνδέσμους· οι ραϊχισμένες εικόνες και τα βίντεο δεν μπορούν. Δείτε τις σκέψεις εξαγωγής στο [Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσεων](#report-sanitize-and-verify-hyperlinks).