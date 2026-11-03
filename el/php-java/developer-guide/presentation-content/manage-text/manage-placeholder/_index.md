---
title: Διαχείριση Placeholder Παρουσιάσεων στο PHP
linktitle: Διαχείριση Placeholder
type: docs
weight: 10
url: /el/php-java/manage-placeholder/
keywords:
- σύμβολο κράτησης
- σύμβολο κράτησης κειμένου
- σύμβολο κράτησης εικόνας
- σύμβολο κράτησης διαγράμματος
- σύμβολο κράτησης περιεχομένου
- κείμενο προτροπής
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να ελέγχετε και να επεξεργάζεστε σύμβολα κράτησης κειμένου, εικόνας, διαγράμματος και περιεχομένου και να κατανοήσετε την κληρονόμηση σύμβολων κράτησης με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Ένα placeholder είναι ένα σχήμα που κρατά μια θέση για ένα συγκεκριμένο είδος περιεχομένου σε ένα πρότυπο παρουσίασης. Κοινά παραδείγματα είναι τα placeholders τίτλου, σώματος, εικόνας, διαγράμματος και γενικού σκοπού περιεχομένου. Σε αντίθεση με ένα συνηθισμένο σχήμα, ένα placeholder μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη μορφοποίηση και άλλες ρυθμίσεις από μια διαφάνεια διάταξης ή από τη μητρική διαφάνεια.

Aspose.Slides εκθέτει πληροφορίες placeholder μέσω της μεθόδου [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) . Η μέθοδος επιστρέφει ένα αντικείμενο [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) ή `null` για ένα κανονικό σχήμα. Χρησιμοποιήστε το [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) για να προσδιορίσετε τι προορίζεται να περιέχει το placeholder.

Η κλάση σχήματος εξακολουθεί να έχει σημασία μετά τη γνώση του τύπου του placeholder:

- Ένα κενό placeholder κειμένου, εικόνας, διαγράμματος ή περιεχομένου συνήθως αναπαρίσταται από ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
- Ένα γεμάτο placeholder εικόνας μπορεί να αναπαρίσταται από ένα [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).
- Ένα γεμάτο placeholder διαγράμματος μπορεί να αναπαρίσταται από ένα [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/).
- Ένα placeholder περιεχομένου μπορεί να περιέχει διάφορα είδη περιεχομένου. Ελέγξτε τόσο το [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) όσο και την κλάση σχήματος κατά το χρόνο εκτέλεσης αντί να υποθέτετε ότι κάθε placeholder είναι ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) περιγράφει το ρόλο ενός placeholder· δεν εγγυάται την κλάση σχήματος κατά το χρόνο εκτέλεσης. Πάντα χρησιμοποιείτε έλεγχο τύπου πριν αποκτήσετε πρόσβαση σε κείμενο, εικόνα, διάγραμμα, πίνακα ή ειδικά μέλη πολυμέσων.
{{% /alert %}}

## **Κατανόηση Κληρονόμησης Placeholder**

Τα placeholders σχηματίζουν ιεραρχία:

1. Μια μητρική διαφάνεια ορίζει επαναχρησιμοποιούμενα στυλ και, σε ορισμένες περιπτώσεις, placeholders σε επίπεδο μητρικής.
2. Μια διαφάνεια διάταξης ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από τη μητρική.
3. Μια κανονική διαφάνεια περιέχει τα placeholders για αυτή τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξή της.

Καλέστε το [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) για να μετακινηθείτε ένα επίπεδο επάνω στην ιεραρχία αυτή. Ένα placeholder διαφάνειας συνήθως επιστρέφει το placeholder της διάταξής του· ένα placeholder διάταξης μπορεί να επιστρέψει το placeholder της μητρικής. Η μέθοδος επιστρέφει `null` όταν το σχήμα δεν έχει βασικό placeholder.

Το παρακάτω παράδειγμα εμφανίζει τα placeholders στην πρώτη διαφάνεια και αναφέρει τα βασικά τους placeholders:

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

Η επεξεργασία ενός placeholder σε μια κανονική διαφάνεια δημιουργεί ή αλλάζει μια τοπική υπερβολή για εκείνη τη διαφάνεια. Η επεξεργασία της σχετικής διάταξης ή της μητρικής μπορεί να επηρεάσει όλες τις διαφάνειες που εξακολουθούν να κληρονομούν αυτή τη ρύθμιση. Ένα τοπικό συνηθισμένο σχήμα δεν έχει βασικό placeholder και δεν αρχίζει να κληρονομεί απλώς επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Αφαίρεση Κατάστασης Placeholder**

Κατά την προσαρμογή ενός προτύπου, χρησιμοποιήστε το [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) για να διατηρήσετε ένα υπάρχον αντικείμενο ως συνηθισμένο σχήμα. Η μέθοδος [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) του επιστρέφει `null`, αλλά το σχήμα παραμένει στη συλλογή της διαφάνειας. Σε αντίθεση, το [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) διαγράφει το σχήμα από εκείνη τη συλλογή.

Το παρακάτω παράδειγμα απαιτεί το `template.pptx` με τουλάχιστον μία διαφάνεια και ένα μη κενό placeholder κειμένου στην πρώτη διαφάνεια. Χρησιμοποιήστε ένα placeholder με μορφοποίηση κληρονομημένη από τη διάταξη ή τη μητρική για να δείτε το αποτέλεσμα της αφαίρεσης της σχέσης. Το παράδειγμα ελέγχει ότι το ίδιο σχήμα παραμένει, καλεί ξανά τη μέθοδο στο πλέον κανονικό σχήμα και αποθηκεύει το αποτέλεσμα.

{{% alert color="warning" title="Warning" %}}
Η αφαίρεση της κατάστασης placeholder δεν διατηρεί αυτόματα τις κληρονομημένες ρυθμίσεις εμφάνισης. Το παρακάτω παράδειγμα αφήνει σκόπιμα αυτές τις ρυθμίσεις αμετάβλητες, επομένως η έξοδος μπορεί να φαίνεται διαφορετική. Ένα σχήμα του οποίου η θέση και το μέγεθος είναι πλήρως κληρονομημένα μπορεί να έχει μηδενικές συντεταγμένες και διαστάσεις μετά την κλήση και να γίνει αόρατο, παρόλο που παραμένει στη συλλογή.
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // Η κλήση της μεθόδου σε ένα συνηθισμένο σχήμα δεν έχει αποτέλεσμα.
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Για ένα αντιστοιχισμένο placeholder, και τα τρία ελέγχων εκτυπώνουν `true`. Το κείμενο παραμένει, αλλά η κληρονομημένη θέση, μέγεθος, περιστροφή, γραμματοσειρά, στοίχιση παραγράφου, περιθώρια πλαισίου κειμένου, κάθετη αγκύρωση, γεμίσματα και ρυθμίσεις γραμμής μπορεί να αλλάξουν όταν η σχέση placeholder αφαιρεθεί. Για παράδειγμα, η κληρονομημένη μορφοποίηση τίτλου μπορεί να επιστρέψει στην τυπική μορφοποίηση κειμένου. Δείτε το [Slide Layout](/slides/el/php-java/slide-layout/) για περισσότερα σχετικά με τις διατάξεις.

Για να διατηρήσετε την επιδιωκόμενη εμφάνιση, καταγράψτε τη διαλυμένη θέση, μέγεθος και περιστροφή πριν από την κλήση και αντιγράψτε τις απαιτούμενες τιμές αποτελεσματικής μορφοποίησης σε ξεχωριστές μεταβλητές. Ανακτήστε αυτές τις τιμές μέσω των [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/), [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/), [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/), και [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/). Μην βασίζεστε μόνο στα αντικείμενα αποτελεσματικής μορφοποίησης, επειδή οι τιμές μορφοποίησης κειμένου τους μπορούν να αλλάξουν μετά την αφαίρεση της σχέσης. Εφαρμόστε ρητά τις καταγραφόμενες τιμές στο συνηθισμένο σχήμα αργότερα, συμπεριλαμβανομένων της οικογένειας γραμματοσειράς, μεγέθους, στιλ, χρώματος, ρυθμίσεων παραγράφου, ρυθμίσεων πλαισίου κειμένου, γεμίσματος και γραμμής που χρησιμοποιεί το πρότυπό σας.

Η κληρονομημένη γεωμετρία σχήματος μπορεί επίσης να χρειαστεί να οριστεί ρητά μέσω του [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType). Για ένα ορθογώνιο placeholder κειμένου, αυτό σημαίνει την ανάθεση του [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/); η αποκατάσταση μόνο του γεμίσματος και της γραμμής ενδέχεται να μην επαναφέρει το ορατό ορθογώνιο. Τα πρότυπα με πρόσθετα εφέ ή πιο σύνθετη μορφοποίηση απαιτούν επίσης τη διαχείριση αυτών των ρυθμίσεων.

## **Αλλαγή Κειμένου σε Placeholder**

Οι placeholders τίτλου, κεντραρισμένου τίτλου, υπότιτλου, σώματος και κειμένου υποστηρίζουν συνήθως κείμενο. Ελέγξτε για [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) πριν χρησιμοποιήσετε τη μέθοδο [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) της.

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

Αυτό το πρότυπο αποφεύγει την αντιμετώπιση των placeholders εικόνας, διαγράμματος, πίνακα ή πολυμέσων ως αντικειμένων [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/). Επίσης, προσδιορίζει το placeholder με βάση τον σκοπό του αντί να βασίζεται σε ευαίσθητο δείκτη σχήματος.

## **Ορισμός Κειμένου Προτροπής σε Διάταξη**

Το κείμενο προτροπής είναι η οδηγία στο χρόνο σχεδίασης που εμφανίζεται σε ένα κενό placeholder, όπως *Click to add title*. Ορίστε προσαρμοσμένο κείμενο προτροπής στο placeholder της διάταξης αντί να προσπαθήσετε να το προσεγγίσετε μέσω της συλλογής σ Shape της κανονικής διαφάνειας. Πρόσβαση στη διάταξη μέσω του [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) και επαναλάβετε τη συλλογή που επιστρέφει το [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes).

Το παρακάτω παράδειγμα αλλάζει τις προτροπές τίτλου και υποτίτλου στη διάταξη που χρησιμοποιείται από την πρώτη διαφάνεια:

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

Το κείμενο προτροπής δεν είναι κανονικό περιεχόμενο διαφάνειας. Απευθύνεται σε κενά placeholders σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή πρόγραμμα παρέχει πραγματικό περιεχόμενο, η προτροπή δεν εμφανίζεται πλέον. Η αλλαγή μιας προτροπής δεν αντικαθιστά επίσης το υπάρχον κείμενο στις διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Placeholder Εικόνας**

Υπάρχουν δύο περιπτώσεις που πρέπει να αντιμετωπιστούν:

- Εάν το placeholder εικόνας είναι ήδη γεμάτο και αναπαρίσταται από ένα [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), αντικαταστήστε την εικόνα μέσω του [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) και του [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage).
- Εάν είναι ακόμη κενό placeholder, προσθέστε ένα πλαίσιο εικόνας στις συντεταγμένες του placeholder με το [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) και αφαιρέστε το κενό placeholder.

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

Η αντικατάσταση που δημιουργείται για ένα κενό placeholder είναι ένα τοπικό πλαίσιο εικόνας, όχι ένα νέο placeholder, επειδή το [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) δεν παρέχει setter. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πλέον τη συμπεριφορά που σχετίζεται με το placeholder. Εάν η διατήρηση της σχέσης placeholder είναι ουσιώδης, ετοιμάστε και γεμίστε το placeholder στο PowerPoint πρώτα, κατόπιν ενημερώστε το προκύπτον [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) με το Aspose.Slides.

Για διαφάνεια εικόνας, περικοπή και άλλα εφέ ειδικά για εικόνες, δείτε το [Manage Picture Frames](/slides/el/php-java/picture-frame/). Αυτές οι λειτουργίες ανήκουν στο πλαίσιο εικόνας ή στο γεμίσμα εικόνας, όχι στα μεταδεδομένα του placeholder.

## **Δουλειά με Placeholder Διαγραμμάτων και Περιεχομένου**

Ένα γεμάτο placeholder διαγράμματος μπορεί να αναπαρίσταται από ένα [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/). Αυτό το παράδειγμα βρίσκει ένα τέτοιο διάγραμμα τόσο με βάση τον τύπο του placeholder όσο και με βάση την κλάση σχήματος κατά το χρόνο εκτέλεσης, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

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

Ένα γενικό placeholder περιεχομένου συνήθως έχει [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/). Στο PowerPoint λειτουργεί ως εκκινητής για πολλαπλούς τύπους περιεχομένου, όπως διαγράμματα, πίνακες, διαγράμματα ροής, εικόνες και πολυμέσα. Αφού γεμίσει, εξετάστε την πραγματική κλάση σχήματος για να μάθετε τι περιέχει. Εξειδικευμένες διατάξεις μπορούν επίσης να εκθέτουν [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), ή [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/).

Το Aspose.Slides δεν μετατρέπει ένα κενό placeholder [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) σε ένα [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) απλώς αλλάζοντας το [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/); ο τύπος δεν μπορεί να αλλάξει μέσω της κλάσης. Για να γεμίσετε ένα κενό διάγραμμα ή περιοχή περιεχομένου προγραμματιστικά, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του placeholder και, στη συνέχεια, αφαιρέστε το κενό placeholder. Το παρακάτω παράδειγμα το κάνει για ένα διάγραμμα:

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

Το προστιθέμενο διάγραμμα είναι ένα συνηθισμένο τοπικό διάγραμμα. Καταλαμβάνει την περιοχή του placeholder αλλά δεν κληρονομεί από το placeholder της διάταξης. Χρησιμοποιήστε τα ειδικά άρθρα διαχείρισης διαγραμμάτων [chart management articles](/slides/el/php-java/powerpoint-charts/) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα του βιβλίου εργασίας.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Περιεχομένου Εικόνας**

Το παρακάτω παράδειγμα πλήρους ροής ανοίγει ένα πρότυπο, ψάχνει την πρώτη διαφάνεια για είτε placeholder τίτλου είτε placeholder εικόνας, ελέγχει τους τύπους placeholder και σχήματος, ενημερώνει το κατάλληλο περιεχόμενο και αποθηκεύει το αρχείο εξόδου. Το παράδειγμα αποφεύγει σκόπιμα την υπόθεση δείκτη σχήματος ή την αντιμετώπιση κάθε placeholder ως ίδιας κλάσης.

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

Ένα base placeholder είναι το αντίστοιχο σχήμα στη διάταξη ή στη μητρική από το οποίο κληρονομεί ένα άλλο placeholder. Χρησιμοποιήστε το [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) για να το ανακτήσετε. Ένα συνηθισμένο τοπικό σχήμα επιστρέφει `null` επειδή δεν αποτελεί μέρος της ιεραρχίας placeholder.

**Μπορώ να αλλάξω όλους τους τίτλους των διαφανειών επεξεργαζόμενος ένα placeholder διάταξης;**

Μπορείτε να αλλάξετε τη κληρονομημένη μορφοποίηση ή το κείμενο προτροπής μέσω μιας διάταξης, αλλά το υπάρχον περιεχόμενο τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε τον πραγματικό τίτλο σε όλη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε κάθε placeholder τίτλου.

**Πώς διαχειρίζομαι placeholders ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδου στο αντίστοιχο επίπεδο διαφάνειας, διάταξης, μητρικής, σημειώσεων ή χεριών. Δείτε τη σελίδα [Manage Presentation Header and Footer](/slides/el/php-java/presentation-header-and-footer/) για πλήρη παραδείγματα.