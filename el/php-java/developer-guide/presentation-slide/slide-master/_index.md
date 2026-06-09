---
title: Διαχείριση slide masters παρουσίασης σε PHP
linktitle: Κύρια διαφάνεια
type: docs
weight: 70
url: /el/php-java/slide-master/
keywords:
- κύριο slide
- κύρια διαφάνεια
- PPT κύρια διαφάνεια
- πολλαπλές κύριες διαφάνειες
- σύγκριση κυρίων διαφάνειων
- φόντο
- σύμβολο κράτησης
- κλωνοποίηση κύριας διαφάνειας
- αντιγραφή κύριας διαφάνειας
- διπλασιασμός κύριας διαφάνειας
- αχρησιμοποίητη κύρια διαφάνεια
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχείριση των slide masters στο Aspose.Slides για PHP μέσω Java: πρόσβαση, επεξεργασία, κλωνοποίηση, σύγκριση και αφαίρεση κυρίων διαφάνειων σε παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Ένα **slide master** ορίζει κοινές ρυθμίσεις σχεδίασης για μια ομάδα διαφανειών. Μπορεί να περιέχει κοινά σχήματα, λογότυπα, φόντα, στυλ κειμένου, ρυθμίσεις θέματος και ρυθμίσεις υποσέλιδου. Στο PowerPoint, η επεξεργασία ενός slide master είναι ο συνηθισμένος τρόπος να διατηρείται μια παρουσίαση συνεπής χωρίς να επαναλαμβάνεται η ίδια μορφοποίηση σε κάθε διαφάνεια.

Το Aspose.Slides for PHP via Java υποστηρίζει το ίδιο μοντέλο. Μια παρουσίαση μπορεί να περιέχει μία ή περισσότερες master slides, και κάθε master slide μπορεί να περιέχει αρκετές layout slides. Οι normal slides συνήθως δεν αναφέρονται άμεσα σε ένα master slide. Αντ' αυτού, μια normal slide χρησιμοποιεί μια layout slide, η οποία ανήκει σε ένα master slide.

Η ιεραρχία είναι:

1. **Slide master** - ορίζει το κοινό σχέδιο και το θέμα.
1. **Layout slide** - ορίζει μια συγκεκριμένη διάταξη placeholders και μορφοποίησης επιπέδου layout.
1. **Normal slide** - περιέχει το πραγματικό περιεχόμενο της παρουσίασης και χρησιμοποιεί μία layout slide.

![Η ιεραρχία των master slides, layout slides και normal slides](slide-master_2.jpg)

Στο Aspose.Slides, ένα slide master αντιπροσωπεύεται από την κλάση [MasterSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/). Όλες οι master slides σε μια παρουσίαση είναι διαθέσιμες μέσω της μεθόδου [Presentation.getMasters](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getMasters), η οποία επιστρέφει ένα αντικείμενο [MasterSlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Όταν η ίδια ιδιότητα ορίζεται σε περισσότερο από ένα επίπεδο, το πιο συγκεκριμένο επίπεδο κερδίζει. Για παράδειγμα, εάν ένα master slide και ένα layout slide και τα δύο ορίσουν φόντο, οι διαφάνειες που βασίζονται σε αυτό το layout χρησιμοποιούν το φόντο του layout. Για περισσότερες πληροφορίες σχετικά με τα layout slides, δείτε [Apply or Change Slide Layouts](/slides/el/php-java/slide-layout/).
{{% /alert %}}

## **Πρόσβαση σε Slide Masters**

Στο PowerPoint, μπορείτε να ανοίξετε την προβολή **Προβολή** > **Slide Master**.

![Η εντολή Slide Master στην καρτέλα View του PowerPoint](slide-master_3.jpg)

Στο Aspose.Slides, χρησιμοποιήστε τη μέθοδο `getMasters` για πρόσβαση σε master slides:

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

Μπορείτε επίσης να λάβετε το master slide που χρησιμοποιείται από μια normal slide μέσω του layout της:

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

## **Τι Περιέχει ένα Slide Master**

Ένα master slide είναι ένα αντικείμενο τύπου διαφάνειας. Επεκτείνει την κλάση [BaseSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/), επομένως εκθέτει πολλές από τις ίδιες ιδιότητες διαφάνειας που χρησιμοποιούνται από normal και layout slides. Τα μέλη που αφορούν ειδικά το master slide αναφέρονται στη σελίδα API [MasterSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslide/).

Κοινώς χρησιμοποιούμενα μέλη του master slide περιλαμβάνουν:

| Μέλος | Σκοπός |
| --- | --- |
| `getBackground` | Ορίζει το φόντο σε επίπεδο master. |
| `getShapes` | Αποθηκεύει σχήματα τοποθετημένα στο master, όπως λογότυπα, πλαίσια εικόνων και κοινό κείμενο. |
| `getLayoutSlides` | Αποθηκεύει τις layout slides που ανήκουν στο master. |
| `getThemeManager` | Παρέχει πρόσβαση στα API θέματος του master. |
| `getHeaderFooterManager` | Ελέγχει κεφαλίδες, υποσέλιδα, ημερομηνίες και αριθμούς διαφανειών για το master και τις θυγατρικές του layout. |
| `getDependingSlides` | Επιστρέφει τις normal slides που εξαρτώνται από το master μέσω των layout τους. |

## **Προσθήκη Εικόνας σε Slide Master**

Όταν προσθέτετε μια εικόνα σε ένα master slide, εμφανίζεται στις διαφάνειες που χρησιμοποιούν layout από το συγκεκριμένο master. Αυτό είναι χρήσιμο για λογότυπα, υδατογραφήματα, διακοσμητικές λωρίδες και άλλα επαναλαμβανόμενα οπτικά στοιχεία.

Το παρακάτω παράδειγμα προσθέτει λογότυπο στο πρώτο master slide:

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

## **Δουλειά με Placeholders**

Τα placeholders ορίζονται κανονικά στις layout slides. Το master slide παρέχει το κοινό στυλ και θέμα που κληρονομούν αυτές οι layout, ενώ κάθε layout αποφασίζει ποια placeholders είναι διαθέσιμα και πού τοποθετούνται.

Στο PowerPoint, οι εντολές placeholder είναι διαθέσιμες στην προβολή Slide Master.

![Η εντολή Insert Placeholder στην προβολή Slide Master του PowerPoint](slide-master_5.png)

Για να προσθέσετε νέα placeholders με το Aspose.Slides, εργαστείτε με τη layout slide που ανήκει στο master:

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

Μπορείτε επίσης να μορφοποιήσετε σχήματα placeholder που ήδη υπάρχουν σε ένα master slide. Το παρακάτω παράδειγμα βρίσκει το placeholder τίτλου και εφαρμόζει γραμμική διαβάθμιση:

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

![Τίτλος placeholder μορφοποιημένος που κληρονομείται από normal slides](slide-master_8.png)

Για περισσότερες επιλογές μορφοποίησης placeholder και κειμένου, δείτε [Set Prompt Text in Placeholder](/slides/el/php-java/manage-placeholder/) και [Text Formatting](/slides/el/php-java/text-formatting/).

## **Αλλαγή Φόντου Slide Master**

Ένα φόντο master κληρονομείται από τις layout και τις διαφάνειες που δεν το παρακάμπτουν. Το παρακάτω παράδειγμα ορίζει ένα στερεό χρώμα φόντου για το πρώτο master slide:

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

Για συναφή θέματα, δείτε [Presentation Background](/slides/el/php-java/presentation-background/) και [Presentation Theme](/slides/el/php-java/presentation-theme/).

## **Κλωνοποίηση Slide Master σε Άλλη Παρουσίαση**

Χρησιμοποιήστε το `addClone` από το [MasterSlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslidecollection/) για να αντιγράψετε ένα master slide σε άλλη παρουσίαση. Το αντίγραφο master μπορεί στη συνέχεια να χρησιμοποιηθεί από layout και διαφάνειες στην προοριστική παρουσίαση.

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

Εάν χρειάζεστε κλωνοποίηση normal slides μαζί με το master τους, δείτε [Clone Slides](/slides/el/php-java/clone-slides/).

## **Προσθήκη Πολλαπλών Slide Masters**

Μια παρουσίαση μπορεί να περιέχει πολλαπλά master slides. Αυτό είναι χρήσιμο όταν διαφορετικά τμήματα απαιτούν διαφορετική επωνυμία, δομή σελίδας ή ρυθμίσεις θέματος.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Το παρακάτω παράδειγμα κλωνοποιεί το προεπιλεγμένο master, δίνει στο αντίγραφο διαφορετικό φόντο, δημιουργεί μια layout κάτω από το κλωνοποιημένο master και προσθέτει μια νέα διαφάνεια βασισμένη σε αυτή τη layout:

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

## **Σύγκριση Slide Masters**

Τα master slides μπορούν να συγκριθούν με τη μέθοδο `equals` που κληρονομείται από το [BaseSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/). Η σύγκριση ελέγχει τη δομή και το στατικό περιεχόμενο, όπως σχήματα, κείμενο, μορφοποίηση, animations και άλλες ρυθμίσεις διαφάνειας. Δεν συγκρίνει μοναδικά αναγνωριστικά, όπως IDs διαφανειών, ή δυναμικές τιμές placeholder, όπως η τρέχουσα ημερομηνία.

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

## **Ορισμός Προβολής Slide Master ως Προεπιλεγμένη Προβολή**

Χρησιμοποιήστε τη μέθοδο `setLastView` στην κλάση [ViewProperties](https://reference.aspose.com/slides/el/php-java/aspose.slides/viewproperties/) για να ελέγξετε την προβολή που ανοίγει πρώτο το PowerPoint. Το παρακάτω παράδειγμα ανοίγει την παρουσίαση στην προβολή Slide Master:

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

## **Αφαίρεση Μη Χρησιμοποιούμενων Master Slides**

Οι παρουσιάσεις μερικές φορές περιέχουν master slides που δεν χρησιμοποιούνται πλέον από καμία normal slide. Η αφαίρεση μη χρησιμοποιούμενων masters μπορεί να μειώσει το μέγεθος του αρχείου και να απλοποιήσει τη διαχείριση προτύπων.

Χρησιμοποιήστε το `removeUnused` από το [MasterSlideCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/masterslidecollection/) για να αφαιρέσετε μη χρησιμοποιούμενα masters από τη συλλογή `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Μπορείτε επίσης να χρησιμοποιήσετε τη μέθοδο χαμηλού κώδικα `removeUnusedMasterSlides` από την κλάση [Compress](https://reference.aspose.com/slides/el/php-java/aspose.slides/compress/):

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

**Ποια είναι η διαφορά μεταξύ ενός slide master και μιας layout slide;**

Ένα slide master ορίζει κοινές ρυθμίσεις σχεδίασης όπως θέμα, φόντο, κοινά σχήματα και στυλ κειμένου. Μια layout slide ανήκει σε ένα slide master και ορίζει μια συγκεκριμένη διάταξη placeholders. Μια normal slide χρησιμοποιεί μια layout slide, έτσι κληρονομεί τόσο από τη layout όσο και από το master.

**Μπορεί μια παρουσίαση να περιέχει πολλά slide masters;**

Ναι. Μια παρουσίαση μπορεί να περιέχει πολλούς slide masters. Χρησιμοποιήστε πολλαπλά masters όταν διαφορετικά τμήματα χρειάζονται διαφορετικά οπτικά συστήματα ή επωνυμία.

**Πρέπει να προσθέσω placeholders σε master slide ή σε layout slide;**

Στις περισσότερες περιπτώσεις, προσθέστε placeholders σε layout slides. Τοποθετήστε τα κοινά οπτικά στοιχεία και τη κοινή μορφοποίηση στο master slide, και τα placeholders περιεχομένου στις layout που θα χρησιμοποιήσουν οι normal slides.

**Μπορώ να διαγράψω ένα master slide που χρησιμοποιείται ακόμη;**

Όχι. Ένα master slide που έχει εξαρτημένες διαφάνειες δεν μπορεί να διαγραφεί με ασφάλεια. Πρώτα μετακινήστε αυτές τις διαφάνειες σε layout κάτω από άλλο master, ή χρησιμοποιήστε μια μέθοδο καθαρισμού μη χρησιμοποιούμενων masters που αφαιρεί μόνο masters που δεν είναι σε χρήση.