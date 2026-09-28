---
title: "Διαχείριση Μαστέρι Διαφάνειας Παρουσίασης σε PHP"
linktitle: "Μαστέρι Διαφάνειας"
type: docs
weight: 70
url: /el/php-java/slide-master/
keywords:
- "μαστέρι διαφάνειας"
- "διαφάνεια μαστέρι"
- "διαφάνεια μαστέρι PPT"
- "πολλαπλά μαστέρι διαφανειών"
- "σύγκριση μαστέρι διαφανειών"
- "φόντο"
- "θέση κράτησης"
- "κλωνοποίηση διαφάνειας μαστέρι"
- "αντιγραφή διαφάνειας μαστέρι"
- "διπλασιασμός διαφάνειας μαστέρι"
- "αχρησιμοποίητη διαφάνεια μαστέρι"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "PHP"
- "Aspose.Slides"
description: "Διαχείριση μαστέρι διαφανειών στο Aspose.Slides για PHP μέσω Java: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και αφαίρεση μαστέρι διαφανειών σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένας **μαστέρι διαφάνειας** ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιέχει κοινά σχήματα, λογότυπα, φόντα, στυλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός μαστέρι διαφάνειας είναι ο συνηθισμένος τρόπος να διατηρείται μια παρουσίαση συνεπής χωρίς να επαναλαμβάνεται η ίδια μορφοποίηση σε κάθε διαφάνεια.

Το Aspose.Slides for PHP via Java υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει ένα ή περισσότερα μαστέρια διαφανειών, και κάθε μαστέρι μπορεί να περιέχει πολλαπλές διαφάνειες διάταξης. Οι κανονικές διαφάνειες συνήθως δεν αναφέρονται άμεσα σε μαστέρι. Αντίθετα, μια κανονική διαφάνεια χρησιμοποιεί μια διαφάνεια διάταξης, η οποία ανήκει σε ένα μαστέρι.

Η ιεραρχία είναι:

1. **Μαστέρι διαφάνειας** – ορίζει το κοινό σχέδιο και το θέμα.
1. **Διαφάνεια διάταξης** – ορίζει μια συγκεκριμένη διάταξη θέσεων κράτησης και μορφοποίησης επιπέδου διάταξης.
1. **Κανονική διαφάνεια** – περιέχει το πραγματικό περιεχόμενο της παρουσίασης και χρησιμοποιεί μία διαφάνεια διάταξης.

![Η ιεραρχία των μαστέρι διαφανειών, διαφανειών διάταξης και κανονικών διαφανειών](slide-master_2.jpg)

Στο Aspose.Slides, ένα μαστέρι διαφάνειας αντιπροσωπεύεται από την κλάση [MasterSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/). Όλα τα μαστέρια σε μια παρουσίαση είναι διαθέσιμα μέσω της μεθόδου [Presentation.getMasters](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getMasters), η οποία επιστρέφει ένα αντικείμενο [MasterSlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Κληρονόμηση" %}}

Όταν η ίδια ιδιότητα ορίζεται σε περισσότερα από ένα επίπεδα, το πιο συγκεκριμένο επίπεδο υπερισχύει. Για παράδειγμα, εάν ένα μαστέρι και μια διαφάνεια διάταξης ορίζουν και τα δύο ένα φόντο, οι διαφάνειες που βασίζονται σε αυτήν τη διάταξη χρησιμοποιούν το φόντο της διάταξης. Για περισσότερες πληροφορίες σχετικά με τις διαφάνειες διάταξης, δείτε [Εφαρμογή ή Αλλαγή Διαφανειών Διάταξης](/slides/el/php-java/slide-layout/).

{{% /alert %}}

## **Πρόσβαση σε Μαστέρια Διαφανειών**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή Μαστέρι Διαφάνειας από **View** > **Slide Master**.

![Η εντολή Slide Master στην καρτέλα View του PowerPoint](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη μέθοδο `getMasters` για πρόσβαση σε μαστέρια:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Μπορείτε επίσης να λάβετε τη μαστέρι διαφάνειας που χρησιμοποιείται από μια κανονική διαφάνεια μέσω της διάταξής της:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Τι Περιέχει ένα Μαστέρι Διαφάνειας**

Ένα μαστέρι διαφάνειας είναι ένα αντικείμενο παρόμοιο με διαφάνεια. Επεκτείνει το [BaseSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/), έτσι εκθέτει πολλές από τις ίδιες ιδιότητες διαφάνειας που χρησιμοποιούνται από κανονικές και διαφάνειες διάταξης. Τα μέλη που είναι ειδικά για μαστέρι αναφέρονται στη σελίδα API του [MasterSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/).

Τα πιο κοινά μέλη μαστέρι διαφάνειας περιλαμβάνουν:

| Μέλος | Σκοπός |
| --- | --- |
| `getBackground` | Ορίζει το φόντο της διαφάνειας σε επίπεδο μαστέρι. |
| `getShapes` | Αποθηκεύει τα σχήματα που τοποθετούνται στο μαστέρι, όπως λογότυπα, πλαίσια εικόνας και κοινό κείμενο. |
| `getLayoutSlides` | Αποθηκεύει τις διαφάνειες διάταξης που ανήκουν στο μαστέρι. |
| `getThemeManager` | Παρέχει πρόσβαση στα API θέματος του μαστέρι. |
| `getHeaderFooterManager` | Ελέγχει κεφαλίδες, υποσέλιδα, ημερομηνίες και αριθμούς διαφανειών για το μαστέρι και τις παιδικές του διαφάνειες διάταξης. |
| `getDependingSlides` | Επιστρέφει κανονικές διαφάνειες που εξαρτώνται από το μαστέρι μέσω των διαφανειών διάταξης τους. |

## **Προσθήκη Εικόνας σε Μαστέρι Διαφάνειας**

Όταν προσθέτετε μια εικόνα σε μαστέρι διαφάνειας, εμφανίζεται σε διαφάνειες που χρησιμοποιούν διαφάνειες διάταξης από αυτό το μαστέρι. Αυτό είναι χρήσιμο για λογότυπα, υδατογραφήματα, διακοσμητικές λωρίδες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το ακόλουθο παράδειγμα προσθέτει ένα λογότυπο στην πρώτη μαστέρι διαφάνειας:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Για περισσότερες πληροφορίες σχετικά με τα πλαίσια εικόνας, δείτε [Picture Frame](/slides/el/php-java/picture-frame/).

## **Έλεγχος Ορατότητας Γραφικών Μαστέρι**

Χρησιμοποιήστε το [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/#setShowMasterShapes) για να κρύψετε κληρονομικές γραφικές του μαστέρι, όπως λογότυπα ή διακοσμητικά σχήματα, χωρίς να τα διαγράψετε από το μαστέρι. Περνάτε `false` στη μέθοδο [Slide::setShowMasterShapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#setShowMasterShapes) στη διαφάνεια που πρέπει να παραλείψει αυτά τα γραφικά και το αφήνετε `true` στις διαφάνειες που πρέπει να τα εμφανίσει.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί μια μπλε διακοσμητική λωρίδα σε μαστέρι και σε δύο διαφάνειες που χρησιμοποιούν την ίδια κενή διάταξη. Η λωρίδα είναι ορατή στην πρώτη διαφάνεια και κρυμμένη στη δεύτερη. Δεν απαιτείται εισαγωγική παρουσίαση ή εικόνα.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το παράδειγμα χρησιμοποιεί τη διάταξη **Blank** που παρέχεται με μια νέα παρουσίαση και αφαιρεί τις αρχικές θέσεις κράτησης της πρώτης διαφάνειας.

### **Επιλογή Πεδίου Εφαρμογής της Ρύθμισης**

Μια κανονική διαφάνεια χρησιμοποιεί το μαστέρι της μέσω των [Slide::getLayoutSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#getLayoutSlide) και [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#getMasterSlide). Η ρύθμιση της ιδιότητας σε μια μεμονωμένη διαφάνεια επηρεάζει μόνο εκείνη τη διαφάνεια. Η μεταφορά `false` στη μέθοδο [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/#setShowMasterShapes) κρύβει τα γραφικά μαστέρι για τις διαφάνειες που χρησιμοποιούν αυτήν τη κοινή διάταξη, ακόμη και αν η δική τους ρύθμιση είναι `true`. Για να κρύψετε γραφικά σε μία μόνο διαφάνεια, αλλάξτε την ιδιότητα της διαφάνειας και αφήστε την κοινή διάταξη αμετάβλητη.

Η ρύθμιση δεν υποστηρίζεται ως έλεγχος ορατότητας στο ίδιο το μαστέρι διαφάνειας. Σε μαστέρι, το [getShowMasterShapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/#getShowMasterShapes) πάντα επιστρέφει `false`, και η μεταφορά `true` στο [setShowMasterShapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/#setShowMasterShapes) προκαλεί εξαίρεση. Εφαρμόστε τη σε κανονική διαφάνεια ή σε διάταξη.

### **Διαχωρισμός Γραφικών από το Φόντο**

| Επιχείρηση | Αποτέλεσμα |
| --- | --- |
| Απόκρυψη γραφικών μαστέρι | Ελέγχει την ορατότητα των κληρονομικών σχημάτων μαστέρι χωρίς να τα διαγράψει ή να αλλάξει τα δικά σχήματα της διαφάνειας. |
| Αλλαγή γεμίσματος φόντου διαφάνειας | Αλλάζει το χρώμα, τη διαβάθμιση ή την εικόνα φόντου. Τα γραφικά μαστέρι είναι ξεχωριστά σχήματα και μπορούν να παραμένουν ορατά πάνω από το φόντο. Δείτε [Presentation Background](/slides/el/php-java/presentation-background/). |
| Διαγραφή σχήματος από το μαστέρι | Αφαιρεί το κοινό σχήμα πηγής, ώστε να μην είναι πια διαθέσιμο σε καμία διαφάνεια που χρησιμοποιεί αυτό το μαστέρι. |

## **Εργασία με Θέσεις Κράτησης**

Οι θέσεις κράτησης ορίζονται συνήθως σε διαφάνειες διάταξης. Το μαστέρι παρέχει το κοινό στυλ και το θέμα που κληρονομούν αυτές οι διαφάνειες, ενώ κάθε διάταξη αποφασίζει ποιες θέσεις κράτησης είναι διαθέσιμες και πού τοποθετούνται.

Στο PowerPoint, οι εντολές θέσεων κράτησης είναι διαθέσιμες στην προβολή Μαστέρι Διαφάνειας.

![Η εντολή Insert Placeholder στην προβολή Slide Master του PowerPoint](slide-master_5.png)

Για να προσθέσετε νέες θέσεις κράτησης με το Aspose.Slides, εργαστείτε με τη διαφάνεια διάταξης που ανήκει στο μαστέρι:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Μπορείτε επίσης να μορφοποιήσετε σχήματα θέσεων κράτησης που ήδη υπάρχουν σε μαστέρι διαφάνειας. Το παρακάτω παράδειγμα εντοπίζει τη θέση κράτησης του τίτλου και εφαρμόζει γραμμική διαβάθμιση:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Τίτλος διαμορφωμένος ως θέση κράτησης που κληρονομείται από κανονικές διαφάνειες](slide-master_8.png)

Για περισσότερες επιλογές μορφοποίησης θέσεων κράτησης και κειμένου, δείτε [Set Prompt Text in Placeholder](/slides/el/php-java/manage-placeholder/) και [Text Formatting](/slides/el/php-java/text-formatting/).

## **Αλλαγή Φόντου Μαστέρι Διαφάνειας**

Ένα φόντο μαστέρι κληρονομείται από τις διαφάνειες διάταξης και τις διαφάνειες που δεν το παρακάμπτουν. Το παρακάτω παράδειγμα ορίζει ένα συμπαγές χρώμα φόντου για την πρώτη μαστέρι διαφάνειας:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Για σχετικούς θεματικούς κόμβους, δείτε [Presentation Background](/slides/el/php-java/presentation-background/) και [Presentation Theme](/slides/el/php-java/presentation-theme/).

## **Κλωνοποίηση Μαστέρι Διαφάνειας σε Άλλη Παρουσίαση**

Χρησιμοποιήστε τη μέθοδο `addClone` από το [MasterSlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslidecollection/) για να αντιγράψετε ένα μαστέρι διαφάνειας σε άλλη παρουσίαση. Το αντιγραμμένο μαστέρι μπορεί στη συνέχεια να χρησιμοποιηθεί από διαφάνειες διάταξης και κανονικές διαφάνειες στην προορισμένη παρουσίαση.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

Αν χρειάζεται να κλωνοποιήσετε κανονικές διαφάνειες μαζί με το μαστέρι τους, δείτε [Clone Slides](/slides/el/php-java/clone-slides/).

## **Προσθήκη Πολλαπλών Μαστέρι Διαφανειών**

Μια παρουσίαση μπορεί να περιέχει πολλαπλά μαστέρια διαφανειών. Αυτό είναι χρήσιμο όταν διαφορετικές ενότητες απαιτούν διαφορετική επωνυμία, δομή σελίδας ή ρυθμίσεις θέματος.

![Εντολές PowerPoint για εισαγωγή και διαχείριση μαστέρι διαφανειών](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί το προεπιλεγμένο μαστέρι, δίνει στο κλώνο διαφορετικό φόντο, δημιουργεί μια διάταξη υπό αυτό το κλώνο και προσθέτει μία νέα διαφάνεια βασισμένη σε αυτήν τη διάταξη:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Σύγκριση Μαστέρι Διαφανειών**

Τα μαστέρια διαφανειών μπορούν να συγκριθούν με τη μέθοδο `equals` που κληρονομείται από το [BaseSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σχήματα, κείμενο, μορφοποίηση, κινούμενα σχέδια και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως το ID διαφάνειας, ή δυναμικές τιμές θέσεων κράτησης, όπως η τρέχουσα ημερομηνία.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

Για περισσότερες πληροφορίες, δείτε [Compare Presentation Slides](/slides/el/php-java/compare-slides/).

## **Ορισμός Προβολής Μαστέρι Διαφάνειας ως Προεπιλεγμένης Προβολής**

Χρησιμοποιήστε τη μέθοδο `setLastView` στην κλάση [ViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/) για να ελέγξετε την προβολή που ανοίγει το PowerPoint πρώτο. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση στην προβολή Μαστέρι Διαφάνειας:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Για περισσότερες ρυθμίσεις προβολής, δείτε [Save Presentation](/slides/el/php-java/save-presentation/).

## **Αφαίρεση Αχρησιμοποιημένων Μαστέρι Διαφανειών**

Οι παρουσιάσεις μερικές φορές περιέχουν μαστέρια διαφανειών που δεν χρησιμοποιούνται πλέον από καμία κανονική διαφάνεια. Η αφαίρεση αχρησιμοποιημένων μαστέρι μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη συντήρηση του προτύπου.

Χρησιμοποιήστε τη μέθοδο `removeUnused` από το [MasterSlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslidecollection/) για να αφαιρέσετε αχρησιμοποίητα μαστέρια από τη συλλογή `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Μπορείτε επίσης να χρησιμοποιήσετε τη μέθοδο low-code `removeUnusedMasterSlides` από την κλάση [Compress](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Ποια είναι η διαφορά μεταξύ μαστέρι διαφάνειας και διαφάνειας διάταξης;**

Ένα μαστέρι διαφάνειας ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, φόντο, κοινά σχήματα και στυλ κειμένου. Μια διαφάνεια διάταξης ανήκει σε μαστέρι διαφάνειας και ορίζει μια συγκεκριμένη διάταξη θέσεων κράτησης. Μια κανονική διαφάνεια χρησιμοποιεί μια διαφάνεια διάταξης, έτσι κληρονομεί τόσο από τη διάταξη όσο και από το μαστέρι.

**Μπορεί μια παρουσίαση να περιέχει πολλά μαστέρια διαφανειών;**

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλά μαστέρια. Χρησιμοποιήστε πολλαπλά μαστέρια όταν διαφορετικές ενότητες χρειάζονται διαφορετικά οπτικά συστήματα ή επωνυμία.

**Πρέπει να προσθέσω θέσεις κράτησης σε μαστέρι διαφάνειας ή σε διαφάνεια διάταξης;**

Στις περισσότερες περιπτώσεις, προσθέτετε θέσεις κράτησης σε διαφάνειες διάταξης. Βάλτε κοινά οπτικά στοιχεία και κοινή μορφοποίηση στο μαστέρι, και τις θέσεις κράτησης περιεχομένου στις διαφάνειες διάταξης που θα χρησιμοποιούν οι κανονικές διαφάνειες.

**Μπορώ να διαγράψω ένα μαστέρι διαφάνειας που χρησιμοποιείται ακόμα;**

Όχι. Ένα μαστέρι διαφάνειας που έχει εξαρτημένες διαφάνειες δεν μπορεί να αφαιρεθεί με ασφάλεια. Μετακινήστε πρώτα αυτές τις διαφάνειες σε διαφάνειες διάταξης κάτω από άλλο μαστέρι ή χρησιμοποιήστε μια μέθοδο καθαρισμού αχρησιμοποίητων μαστέρι που αφαιρεί μόνο τα μαστέρια που δεν χρησιμοποιούνται.