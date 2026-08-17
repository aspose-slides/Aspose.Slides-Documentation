---
title: "Διαχείριση δεσμευτικών θέσεων παρουσίασης σε PHP"
linktitle: "Διαχείριση δεσμευτικών θέσεων"
type: docs
weight: 10
url: /el/php-java/manage-placeholder/
keywords:
- "δεσμευτική θέση"
- "δεσμευτική θέση κειμένου"
- "δεσμευτική θέση εικόνας"
- "δεσμευτική θέση διαγράμματος"
- "δεσμευτική θέση περιεχομένου"
- "προτροπικό κείμενο"
- "PowerPoint"
- "παρουσίαση"
- "PHP"
- "Aspose.Slides"
description: "Μάθετε πώς να ελέγχετε και να επεξεργάζεστε δεσμευτικές θέσεις κειμένου, εικόνας, διαγράμματος και περιεχομένου και να κατανοείτε την κληρονομικότητα των δεσμευτικών θέσεων με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Ένα placeholder είναι ένα σχήμα που κρατάει θέση για έναν συγκεκριμένο τύπο περιεχομένου σε ένα πρότυπο παρουσίασης. Κοινά παραδείγματα είναι τα placeholders τίτλου, σώματος, εικόνας, διαγράμματος και γενικού σκοπού. Σε αντίθεση με ένα κανονικό σχήμα, ένα placeholder μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη μορφοποίηση και άλλες ρυθμίσεις από μια διαφάνεια διάταξης ή κύρια διαφάνεια.

Aspose.Slides εκθέτει τις πληροφορίες του placeholder μέσω της [Shape::getPlaceholder](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getplaceholder/) μεθόδου. Η μέθοδος επιστρέφει ένα αντικείμενο [Placeholder](https://reference.aspose.com/slides/el/php-java/aspose.slides/placeholder/) ή `null` για ένα κανονικό σχήμα. Χρησιμοποιήστε το [Placeholder::getType](https://reference.aspose.com/slides/el/php-java/aspose.slides/placeholder/gettype/) για να καθορίσετε τι προορίζεται να περιέχει το placeholder.

Η κλάση του σχήματος εξακολουθεί να είναι σημαντική αφού γνωρίζετε τον τύπο του placeholder:

- Ένα κενό placeholder κειμένου, εικόνας, διαγράμματος ή περιεχομένου αντιπροσωπεύεται συνήθως από ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).
- Ένα γεμάτο placeholder εικόνας μπορεί να αντιπροσωπευτεί από ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/).
- Ένα γεμάτο placeholder διαγράμματος μπορεί να αντιπροσωπευτεί από ένα [Chart](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/).
- Ένα placeholder περιεχομένου μπορεί να περιέχει πολλούς τύπους περιεχομένου. Ελέγξτε τόσο το [Placeholder::getType](https://reference.aspose.com/slides/el/php-java/aspose.slides/placeholder/gettype/) όσο και την κλάση σχήματος χρόνο εκτέλεσης, αντί να υποθέτετε ότι κάθε placeholder είναι ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType] περιγράφει τον ρόλο ενός placeholder· δεν εγγυάται την κλάση σχήματος χρόνου εκτέλεσης. Πάντα να κάνετε έναν έλεγχο τύπου πριν αποκτήσετε πρόσβαση σε μέλη κειμένου, εικόνας, διαγράμματος, πίνακα ή πολυμέσων.
{{% /alert %}}

## **Κατανόηση της Κληρονομικότητας των Placeholders**

Τα placeholders σχηματίζουν μια ιεραρχία:

1. Μια κύρια διαφάνεια ορίζει επαναχρησιμοποιήσιμα στυλ και, σε ορισμένες περιπτώσεις, placeholders επιπέδου master.
2. Μια διαφάνεια διάταξης ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από το master.
3. Μια κανονική διαφάνεια περιέχει τα placeholders για εκείνη τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξή της.

Καλέστε το [Shape::getBasePlaceholder](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getbaseplaceholder/) για να μετακινηθείτε ένα επίπεδο πιο πάνω σε αυτήν την ιεραρχία. Ένα placeholder διαφάνειας επιστρέφει συνήθως το placeholder της διάταξής του· ένα placeholder διάταξης μπορεί να επιστρέψει το master placeholder του. Η μέθοδος επιστρέφει `null` όταν το σχήμα δεν έχει base placeholder.

Το παρακάτω παράδειγμα λίσταζει τα placeholders στην πρώτη διαφάνεια και αναφέρει τα base placeholders τους:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Η επεξεργασία ενός placeholder σε μια κανονική διαφάνεια δημιουργεί ή αλλάζει μια τοπική παράκαμψη για αυτή τη διαφάνεια. Η επεξεργασία της σχετικής διάταξης ή του master μπορεί να επηρεάσει όλες τις διαφάνειες που ακόμα κληρονομούν αυτή τη ρύθμιση. Ένα τοπικό κανονικό σχήμα δεν έχει base placeholder και δεν αρχίζει να κληρονομεί απλώς επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Αλλαγή Κειμένου σε Placeholder**

Τα placeholders τίτλου, κεντραρισμένου τίτλου, υποτίτλου, σώματος και κειμένου υποστηρίζουν συνήθως κείμενο. Ελέγξτε για [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) πριν χρησιμοποιήσετε τη μέθοδο [getTextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/gettextframe/).

Αυτό το παράδειγμα ενημερώνει το πρώτο placeholder τίτλου στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Αυτό το πρότυπο αποφεύγει την αντιμετώπιση των placeholders εικόνας, διαγράμματος, πίνακα ή πολυμέσων ως αντικείμενα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/). Επίσης αναγνωρίζει το placeholder με βάση τον σκοπό του αντί να βασίζεται σε ευαίσθητο δείκτη σχήματος.

## **Ορισμός Κειμένου Prompt σε Διάταξη**

Το κείμενο prompt είναι η οδηγία χρόνου σχεδίασης που εμφανίζεται σε ένα κενό placeholder, όπως *Κάντε κλικ για να προσθέσετε τίτλο*. Ορίστε προσαρμοσμένο κείμενο prompt στο placeholder της διάταξης αντί να προσπαθήσετε να το προσεγγίσετε μέσω της συλλογής σ shapes μιας κανονικής διαφάνειας. Πρόσβαση στη διάταξη μέσω του [Slide::getLayoutSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#getLayoutSlide) και επαναλάβετε τη συλλογή που επιστρέφει το [BaseSlide::getShapes](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/#getShapes).

Το παρακάτω παράδειγμα αλλάζει τα prompts τίτλου και υποτίτλου στη διάταξη που χρησιμοποιείται από την πρώτη διαφάνεια:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το κείμενο prompt δεν είναι κανονικό περιεχόμενο διαφάνειας. Προορίζεται για κενά placeholders σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή πρόγραμμα παρέχει πραγματικό περιεχόμενο, το prompt δεν εμφανίζεται πλέον. Η αλλαγή του prompt δεν αντικαθιστά το υπάρχον κείμενο στις διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Placeholder Εικόνας**

Υπάρχουν δύο περιπτώσεις προς διαχείριση:

- Αν το placeholder εικόνας είναι ήδη γεμάτο και αντιπροσωπεύεται από ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/), αντικαταστήστε την εικόνα μέσω του [PictureFillFormat::getPicture](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/getpicture/) και του [SlidesPicture::setImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/slidespicture/setimage/).
- Αν είναι ακόμα κενό placeholder, προσθέστε ένα picture frame στις συντεταγμένες του placeholder με το [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addpictureframe/) και αφαιρέστε το κενό placeholder.

Το επόμενο παράδειγμα υποστηρίζει και τις δύο περιπτώσεις και αποθηκεύει την παρουσίαση:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η αντικατάσταση που δημιουργείται για ένα κενό placeholder είναι ένα τοπικό picture frame, όχι νέο placeholder, επειδή το [Shape::getPlaceholder](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getplaceholder/) δεν παρέχει setter. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πλέον τη συμπεριφορά του placeholder. Εάν η διατήρηση της σχέσης placeholder είναι ουσιώδης, προετοιμάστε και γεμίστε το placeholder στο PowerPoint πρώτα, έπειτα ενημερώστε το προκύπτον [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) με το Aspose.Slides.

Για διαφάνεια εικόνας, περικοπή και άλλα ειδικά εφέ εικόνας, δείτε το άρθρο [Manage Picture Frames](/slides/el/php-java/picture-frame/). Αυτές οι λειτουργίες ανήκουν στο picture frame ή στο picture fill, όχι στα μεταδεδομένα του placeholder.

## **Δουλειά με Placeholders Διαγράμματος και Περιεχομένου**

Ένα γεμάτο placeholder διαγράμματος μπορεί να αντιπροσωπευτεί από ένα [Chart](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/). Αυτό το παράδειγμα βρίσκει ένα τέτοιο διάγραμμα βάσει τόσο του τύπου placeholder όσο και της κλάσης χρόνου εκτέλεσης, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ένα γενικό placeholder περιεχομένου συνήθως έχει [PlaceholderType::Object](https://reference.aspose.com/slides/el/php-java/aspose.slides/placeholdertype/). Στο PowerPoint λειτουργεί ως εκκινητής για πολλούς τύπους περιεχομένου, συμπεριλαμβανομένων διαγραμμάτων, πινάκων, διαγραμμάτων, εικόνων και πολυμέσων. Αφού γεμίσει, εξετάστε την πραγματική κλάση σχήματος για να μάθετε τι περιέχει. Εξειδικευμένες διατάξεις μπορούν επίσης να εκθέτουν [PlaceholderType::Chart](https://reference.aspose.com/slides/el/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/el/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/el/php-java/aspose.slides/placeholdertype/), ή [PlaceholderType::Diagram](https://reference.aspose.com/slides/el/php-java/aspose.slides/placeholdertype/).

Το Aspose.Slides δεν μετατρέπει ένα κενό placeholder [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) σε [Chart](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/) απλώς αλλάζοντας το [Placeholder::getType](https://reference.aspose.com/slides/el/php-java/aspose.slides/placeholder/gettype/); ο τύπος δεν μπορεί να αλλάξει μέσω της κλάσης. Για να γεμίσετε προγραμματιστικά ένα κενό διάγραμμα ή περιοχή περιεχομένου, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του placeholder και στη συνέχεια αφαιρέστε το κενό placeholder. Το παρακάτω παράδειγμα το κάνει για ένα διάγραμμα:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το προστιθέμενο διάγραμμα είναι ένα κοινό τοπικό διάγραμμα. Καταλαμβάνει την περιοχή του placeholder αλλά δεν κληρονομεί από το placeholder της διάταξης. Χρησιμοποιήστε τα ειδικά άρθρα διαχείρισης διαγραμμάτων [chart management articles](/slides/el/php-java/powerpoint-charts/) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα του βιβλίου εργασίας.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Περιεχομένου Εικόνας**

Το παρακάτω παράδειγμα από άκρη σε άκρη ανοίγει ένα πρότυπο, αναζητά στην πρώτη διαφάνεια είτε ένα placeholder τίτλου είτε εικόνας, ελέγχει τους τύπους placeholder και σχήματος, ενημερώνει το αντίστοιχο περιεχόμενο και αποθηκεύει το αποτέλεσμα. Το παράδειγμα αποφεύγει σκόπιμα την υπόθεση δείκτη σχήματος ή την αντιμετώπιση κάθε placeholder ως ίδιας κλάσης.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Τι είναι ένα base placeholder;**

Ένα base placeholder είναι το αντίστοιχο σχήμα στη διάταξη ή το master από το οποίο κληρονομεί ένα άλλο placeholder. Χρησιμοποιήστε το [Shape::getBasePlaceholder](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/getbaseplaceholder/) για να το ανακτήσετε. Ένα κανονικό τοπικό σχήμα επιστρέφει `null` επειδή δεν αποτελεί μέρος της ιεραρχίας των placeholders.

**Μπορώ να αλλάξω όλους τους τίτλους διαφάνειας επεξεργάζοντας ένα placeholder διάταξης;**

Μπορείτε να αλλάξετε τη κληρονομημένη μορφοποίηση ή το κείμενο prompt μέσω μιας διάταξης, αλλά το υπάρχον περιεχόμενο τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε τον πραγματικό τίτλο σε ολόκληρη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε κάθε placeholder τίτλου.

**Πώς διαχειρίζομαι placeholders ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδου στο αντίστοιχο επίπεδο διαφάνειας, διάταξης, master, σημειώσεων ή φυλλαδίου. Δείτε το άρθρο [Manage Presentation Header and Footer](/slides/el/php-java/presentation-header-and-footer/) για πλήθη παραδείγματα.