---
title: Διαχείριση πεδίων κειμένου σε παρουσιάσεις PowerPoint σε PHP
linktitle: Πεδία κειμένου
type: docs
weight: 52
url: /el/php-java/text-fields/
keywords:
- πεδίο κειμένου
- αυτόματο κείμενο
- αριθμός διαφάνειας
- ημερομηνία και ώρα
- κεφαλίδα
- υποσέλιδο
- τμήμα κειμένου
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Δημιουργήστε, ελέγξτε, τροποποιήστε και αφαιρέστε πεδία κειμένου σε παρουσιάσεις PowerPoint με το Aspose.Slides για PHP μέσω Java. Διατηρήστε τη μορφοποίηση και επαληθεύστε τα αποθηκευμένα αρχεία PPTX και PPT."
---
## **Επισκόπηση**

Μια παράγραφος κειμένου αποτελείται από τμήματα. Ένα συνηθισμένο [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) περιέχει κυριολεκτικό κείμενο· ένα τμήμα πεδίου επίσης έχει ένα [Field](https://reference.aspose.com/slides/el/php-java/aspose.slides/field/) του οποίου ο τύπος προσδιορίζει μια αυτόματα ενημερωμένη τιμή, όπως αριθμός διαφάνειας ή ημερομηνία. Δύο τμήματα μπορούν να εμφανίζουν τους ίδιους χαρακτήρες ενώ μόνο ένα περιέχει πεδίο.

Χρησιμοποιήστε το [Portion::getField](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/#getField) για να τα διακρίνετε: είναι `null` για συνηθισμένο κείμενο. Το [Portion::addField](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/#addField) μετατρέπει ένα υπάρχον τμήμα σε πεδίο. Κρατήστε μια ετικέτα και τη δυναμική της τιμή σε ξεχωριστά τμήματα ώστε η μετατροπή της τιμής να μην αντικαθιστά επίσης την ετικέτα.

Αυτός ο οδηγός καλύπτει τα πεδία μέσα στο κείμενο, τη μορφοποίησή τους και την αποθήκευση τους σε PPTX και PPT. Για πλαίσια κειμένου και παραγράφους, δείτε το [Manage Text](/slides/el/php-java/manage-text/).

## **Δημιουργία Πεδίου Αριθμού Διαφάνειας**

Το παρακάτω πλήρες παράδειγμα δημιουργεί μια πλαίσιο κειμένου που περιέχει μια κυριολεκτική ετικέτα `Slide ` ακολουθούμενη από έναν αυτόματα ενημερωμένο αριθμό. Ορίζει το μέγεθος, το βάρος και το χρώμα του αριθμού πριν προσθέσει το πεδίο, έπειτα ανοίγει ξανά την αποθηκευμένη παρουσίαση και ελέγχει τον τύπο του πεδίου, το κείμενο και τη μορφοποίηση. Δεν απαιτείται αρχείο εισόδου.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Η νέα παρουσίαση ξεκινά με αριθμό διαφάνειας 1, έτσι το κείμενο είναι `Slide 1`, και και οι δύο έλεγχοι εμφανίζουν `true`. Ο αριθμός παραμένει πεδίο μετά το άνοιγμα· δεν είναι η κυριολεκτική τιμή `1`. Τα ευρετήρια στην επαλήθευση αναφέρονται στο σχήμα και στα τμήματα που δημιουργήθηκαν από αυτό το παράδειγμα.

## **Επιλογή Τύπου Πεδίου**

Το [FieldType](https://reference.aspose.com/slides/el/php-java/aspose.slides/fieldtype/) παρέχει τις ακόλουθες μεθόδους για λήψη προορισμένων τιμών. Πληκτρολογήστε την κατάλληλη τιμή στο [addField](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/#addField).

| Μέθοδος | Σκοπός |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/el/php-java/aspose.slides/fieldtype/#getSlideNumber) | Ο τρέχων αριθμός διαφάνειας. |
| [getDateTime](https://reference.aspose.com/slides/el/php-java/aspose.slides/fieldtype/#getDateTime) | Η ημερομηνία/ώρα στη προεπιλεγμένη μορφή της εφαρμογής απόδοσης. |
| [getDateTime1](https://reference.aspose.com/slides/el/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/el/php-java/aspose.slides/fieldtype/#getDateTime9) | Προκαθορισμένες μορφές ημερομηνίας ή συνδυασμένων ημερομηνίας/ώρας. |
| [getDateTime10](https://reference.aspose.com/slides/el/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/el/php-java/aspose.slides/fieldtype/#getDateTime13) | Προκαθορισμένες μορφές ώρας, με επιλογές για δευτερόλεπτα και 12‑ωρο ρολόι. |
| [getHeader](https://reference.aspose.com/slides/el/php-java/aspose.slides/fieldtype/#getHeader) | Πεδίο κεφαλίδας· δείτε τους περιορισμούς placeholder και μορφής παρακάτω. |
| [getFooter](https://reference.aspose.com/slides/el/php-java/aspose.slides/fieldtype/#getFooter) | Πεδίο υποσέλιδου. |

Για παράδειγμα, το [getDateTime3](https://reference.aspose.com/slides/el/php-java/aspose.slides/fieldtype/#getDateTime3) αντιπροσωπεύει ημέρα, πλήρες όνομα μήνα και έτος στα Αγγλικά. Αυτές είναι προεπιλεγμένες μορφές πεδίου, όχι αυθαίρετες συμβολοσειρές μορφοποίησης ημερομηνίας PHP. Η γλώσσα που ορίζεται με το [setLanguageId](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLanguageId) και η εφαρμογή που επεξεργάζεται την παρουσίαση μπορούν να επηρεάσουν το εμφανιζόμενο αποτέλεσμα.

## **Δημιουργία Πεδίου από Εσωτερική Συμβολοσειρά**

Η υπερφόρτωση συμβολοσειράς του [addField](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/#addField) δέχεται έναν εσωτερικό ταυτοποιητή πεδίου. Χρησιμοποιήστε το όταν διατηρείτε έναν ταυτοποιητή που παρέχεται από άλλη εφαρμογή και δεν έχει προεπιλεγμένη τιμή. Μπορείτε επίσης να δημιουργήσετε ένα [FieldType](https://reference.aspose.com/slides/el/php-java/aspose.slides/fieldtype/#FieldType) από τον ταυτοποιητή. Το [FieldType::getInternalString](https://reference.aspose.com/slides/el/php-java/aspose.slides/fieldtype/#getInternalString) εμφανίζει αυτόν τον ταυτοποιητή για επιθεώρηση.

Αυτό το παράδειγμα αποθηκεύει ένα πεδίο `custom-report-id` ειδικό για την εφαρμογή με το εναλλακτικό κείμενο `Report-042`. Ο ταυτοποιητής δεν καταγράφει καμία ανάλογη καταγραφή: το Aspose.Slides δεν δημιουργεί αναγνωριστικά αναφορών για άγνωστο τύπο. Η εφαρμογή που καταλαβαίνει αυτόν τον ταυτοποιητή πρέπει να παρέχει το νόημά του και να ενημερώνει την τιμή του.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Μετά από αυτό το στρογγυλό ταξίδι PPTX, ο τύπος είναι `custom-report-id` και το κείμενο είναι `Report-042`. Η προσφορά μιας συμβολοσειράς όπως `Y-m-d` θα ονόμαζε έναν τύπο πεδίου· δεν θα διαμόρφωνε προσαρμοσμένη μορφή ημερομηνίας. Για σταθερή ημερομηνία σε αυθαίρετη μορφή, χρησιμοποιήστε συνηθισμένο κείμενο.

## **Επιθεώρηση, Τροποποίηση και Αφαίρεση Πεδίων Ημερομηνίας/Ώρας**

Αλλάξτε ένα υπάρχον πεδίο μέσω του [Field::setType](https://reference.aspose.com/slides/el/php-java/aspose.slides/field/#setType). Ελέγξτε ότι το πεδίο υπάρχει πριν αποκτήσετε πρόσβαση στον τύπο του. Για να σταματήσετε τις αυτόματες ενημερώσεις, καλέστε το [Portion::removeField](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/#removeField). Αυτό διατηρεί το τμήμα και το τρέχον κείμενό του ενώ αφαιρεί τη συσχέτιση του πεδίου. Εάν χρειάζεστε μια συγκεκριμένη σταθερή τιμή, αντιστοιχίστε αυτό το κείμενο μετά την αφαίρεση του πεδίου.

Για τη ρύθμιση API που σχετίζεται με την επεξεργασία πεδίων ημερομηνίας/ώρας, δείτε το [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#setCurrentDateTime). Το παρακάτω παράδειγμα χρησιμοποιεί μια σαφή ημερομηνία έγκρισης κατά τη μετατροπή ενός πεδίου σε συνηθισμένο κείμενο.

Κατεβάστε το [sample.pptx](sample.pptx) και τοποθετήστε το στον κατάλογο εργασίας JavaBridge, ή περάστε το απόλυτο μονοπάτι του στον κατασκευαστή παρουσίασης. Περιέχει δύο μορφοποιημένα σχήματα κειμένου, `UpdatedAt` και `ApprovedDate`, το καθένα με ένα πεδίο ημερομηνίας/ώρας, καθώς και συνηθισμένες ετικέτες κειμένου. Το παρακάτω παράδειγμα περιηγείται στα κειμενικά σχήματα πρώτου επιπέδου σε κανονικές διαφάνειες. Αλλάζει τα πεδία ημερομηνίας/ώρας σε μορφή μακράς ημερομηνίας και τα κάνει πλάγια, διατηρώντας τις άλλες μορφοποιήσεις τους. Μόνο τα πεδία στο `ApprovedDate` γίνονται σταθερό κείμενο.

Το δείγμα αναγνωρίζει τους ενσωματωμένους εσωτερικούς ταυτοποιητές `datetime` και `datetime1` έως `datetime13`. Οι ομάδες, πίνακες, σημειώσεις, διατάξεις και κύριοι απαιτούν διέλευση των δικών τους κοντέινερ κειμένου και δεν περιλαμβάνονται σε αυτό το παράδειγμα.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Μετά το άνοιγμα ξανά, το `UpdatedAt` έχει τύπο `datetime3` και παραμένει δυναμικό. Το `ApprovedDate` δεν έχει πεδίο και περιέχει `05 April 2030`. Και τα δύο τμήματα ημερομηνίας είναι πλάγια, και το αρχικό μέγεθος γραμματοσειράς, η έντονη ρύθμιση και το χρώμα τους παραμένουν αμετάβλητα. Οι συνηθισμένες ετικέτες κειμένου παραμένουν αμετάβλητες. Η επαλήθευση διαβάζει το πρώτο τμήμα των δύο γνωστών σχημάτων στο παρεχόμενο δείγμα.

## **Διατήρηση Μορφοποίησης Κειμένου**

Εργαστείτε με το υπάρχον τμήμα όταν προσθέτετε ένα πεδίο, αλλάζετε τον τύπο του ή το αφαιρείτε. Αυτές οι λειτουργίες διατηρούν τη μορφοποίηση του τμήματος. Χρησιμοποιήστε το [Portion::getPortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/#getPortionFormat) για να αλλάξετε μόνο τις απαραίτητες ιδιότητες, όπως δείχνουν τα παραδείγματα για χρώμα ή πλάγια.

Αποφύγετε την ανασυγκρότηση ολόκληρου πλαισίου κειμένου μόνο για να ενημερώσετε ένα πεδίο: κάτι τέτοιο μπορεί να χαθεί τα αρχικά όρια του τμήματος και τη μεμονωμένη μορφοποίηση του. Επίσης διαχωρίστε τη ρητά ορισμένη μορφοποίηση από τη μορφοποίηση που κληρονομείται από την παράγραφο, τη διάταξη ή το θέμα. Δείτε το [Text Formatting](/slides/el/php-java/text-formatting/) για πιο ευρείες επιλογές μορφοποίησης.

## **Πεδία και Συμπληρώματα Κεφαλίδας/Υποσέλιδου**

Ένα πεδίο αποτελεί μέρος ενός τμήματος κειμένου. Ένα placeholder είναι ένα σχήμα με ρόλο στην παρουσίαση, όπως υποσέλιδο ή αριθμός διαφάνειας. Η προσθήκη πεδίου σε ένα συνηθισμένο πλαίσιο κειμένου δεν μετατρέπει αυτό το σχήμα σε placeholder.

Οι διαχειριστές κεφαλίδας/υποσέλιδου ελέγχουν το κείμενο placeholder και την ορατότητα στις διαφάνειες, διατάξεις και κύριους, συμπεριλαμβανομένης της διάδοσης σε εξαρτημένες διαφάνειες. Ένα πεδίο αριθμού σε προσαρμοσμένο πλαίσιο κειμένου μπορεί επομένως να είναι χρήσιμο ακόμη και όταν δεν χρησιμοποιείτε το placeholder του αριθμού διαφάνειας. Αντιθέτως, η αλλαγή της ορατότητας του placeholder δεν αφαιρεί το πεδίο από ένα ανεξάρτητο πλαίσιο κειμένου.

Οι προορισμένοι τύποι κεφαλίδας και υποσέλιδου δεν δημιουργούν τα αντίστοιχα placeholders ή παρέχουν το περιεχόμενό τους. Συγκεκριμένα, μια κανονική διαφάνεια PowerPoint δεν έχει placeholder κεφαλίδας· οι κεφαλίδες ανήκουν στις σελίδες σημειώσεων και τα φυλλάδια. Μην υποθέτετε ότι ένα πεδίο κεφαλίδας ή υποσέλιδου σε τυχαίο σχήμα θα λάβει αυτόματα το κείμενο που έχει διαμορφωθεί μέσω του διαχειριστή placeholder. Για αυτή τη ροή εργασίας, δείτε το [Presentation Headers and Footers](/slides/el/php-java/presentation-header-and-footer/).

## **Περιορισμοί PPTX και PPT**

Ελέγξτε τόσο τον τύπο του πεδίου όσο και το κείμενο που προκύπτει μετά την αποθήκευση και το άνοιγμα ξανά. Η διατήρηση ενός ταυτοποιητή δεν αποδεικνύει ότι μια εφαρμογή μπορεί να υπολογίσει ή να εμφανίσει την τιμή του.

| Μορφή | Συμπεριφορά πεδίου και περιορισμοί |
|---|---|
| PPTX | Αποθηκεύει εσωτερικούς ταυτοποιητές πεδίου μαζί με το κείμενο του πεδίου. Σε ελέγχους round‑trip, οι προεπιλεγμένοι τύποι και ο προσαρμοσμένος ταυτοποιητής που χρησιμοποιήθηκε παραπάνω επιβίωσαν στην αποθήκευση και το ξανά άνοιγμα. Ο άγνωστος προσαρμοσμένος τύπος διατήρησε το εναλλακτικό κείμενό του· δεν απέκτησε αυτόματο λογισμικό υπολογισμού. Μια άλλη εφαρμογή μπορεί να αντιμετωπίσει διαφορετικά τους μη υποστηριζόμενους ταυτοποιητές. |
| PPT | Χρησιμοποιεί παλαιές αναπαραστάσεις πεδίων και έχει πιο περιορισμένη συμβατότητα. Σε ελέγχους round‑trip, τα πεδία αριθμού διαφάνειας και οι προεπιλεγμένα πεδία ημερομηνίας/ώρας επιβίωσαν στην αποθήκευση και το ξανά άνοιγμα. Ένα προσαρμοσμένο πεδίο σε ένα συνηθισμένο πλαίσιο κειμένου διαφάνειας άνοιξε ξανά με τον ταυτοποιητή του αλλά με `*` ως κείμενο· ένα πεδίο κεφαλίδας στο ίδιο πλαίσιο παρήγαγε επίσης `*`. Μην βασίζεστε σε προσαρμοσμένα πεδία ή μη υποστηριζόμενα πλαίσια πεδίου που διατηρούν το ορατό κείμενό τους. |

Για φορητό, σταθερό αποτέλεσμα, μετατρέψτε τα μη υποστηριζόμενα πεδία σε συνηθισμένο κείμενο και αντιστοιχίστε ρητά την τιμή που θέλετε πριν την αποθηκεύσετε. Αυτό διατηρεί το επιλεγμένο κείμενο αλλά σταματά σκόπιμα τις αυτόματες ενημερώσεις. Δοκιμάστε επίσης την εφαρμογή-στόχο όταν η δική της επανυπολογισμού πεδίων αποτελεί μέρος της ροής εργασίας σας.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω αν ένας εμφανιζόμενος αριθμός ή ημερομηνία είναι πεδίο;**

Ελέγξτε το [Portion::getField](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/#getField). Μια μη‑null τιμή προσδιορίζει πεδίο· το εμφανιζόμενο κείμενο μόνο δεν μπορεί να το δείξει.

**Αφαιρεί η αφαίρεση ενός πεδίου το κείμενο ή τη μορφοποίησή του;**

Όχι. Το [removeField](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/#removeField) μετατρέπει το υπάρχον τμήμα σε συνηθισμένο κείμενο. Αν χρειάζεστε μια συγκεκριμένη παγωμένη ημερομηνία ή εναλλακτική τιμή, αντιστοιχίστε την ρητά μετά.

**Μπορεί μια εσωτερική συμβολοσειρά να ορίσει νέα μορφή ημερομηνίας ή τύπο;**

Όχι. Αναγνωρίζει έναν τύπο πεδίου. Ένας άγνωστος ταυτοποιητής δεν παρέχει αξιολογητή ή μοτίβο μορφοποίησης ημερομηνίας PHP. Χρησιμοποιήστε έναν υποστηριζόμενο προεπιλεγμένο τύπο ή μορφοποιήστε την τιμή εσείς ως συνηθισμένο κείμενο.

**Γιατί ελέγχετε ξανά την παρουσίαση μετά την αποθήκευσή της;**

Οι ταυτοποιητές πεδίου, το υπολογισμένο κείμενο και η μορφοποίηση είναι ξεχωριστά στοιχεία προς επαλήθευση. Η μετατροπή μορφής μπορεί να αλλάξει το ορατό αποτέλεσμα ακόμη και όταν παραμένει ο ταυτοποιητής πεδίου.