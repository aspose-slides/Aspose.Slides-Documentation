---
title: Αλλαγή Μεγέθους Σχημάτων σε Διαφάνειες Παρουσίασης σε PHP
type: docs
weight: 130
url: /el/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/re-sizing-shapes-on-slide/
keywords:
- αλλαγή μεγέθους σχήματος
- τροποποίηση μεγέθους σχήματος
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Απλή αλλαγή μεγέθους σχημάτων σε διαφάνειες PowerPoint και OpenDocument με το Aspose.Slides για PHP μέσω Java—αυτοματοποιήστε τις ρυθμίσεις διάταξης διαφάνειας και αυξήστε την παραγωγικότητα."
---
## **Επισκόπηση**

Όταν αλλάζετε το μέγεθος διαφάνειας μιας παρουσίασης, μπορεί επίσης να χρειαστεί να αλλάξετε το μέγεθος και τη θέση των σχημάτων της ώστε να ταιριάζουν με τις νέες διαστάσεις. Αυτό το άρθρο δείχνει πώς να κλιμακώσετε τα σχήματα χειροκίνητα και πώς να διαχειριστείτε πίνακες σε διαφάνειες, κύριες διαφάνειες και διατάξεις.

## **Αλλαγή Μεγέθους Σχημάτων**

Για να διατηρήσετε τη σχετική θέση και το μέγεθος κάθε σχήματος, πολλαπλασιάστε τις οριζόντιες συντεταγμένες και το πλάτος του με τον λόγο του νέου πλάτους της διαφάνειας προς το αρχικό πλάτος. Εφαρμόστε τον αντίστοιχο λόγο ύψους στις κάθετες συντεταγμένες και το ύψος του.

Το πρώτο παράδειγμα φορτώνει μια παρουσίαση της οποίας οι διαφάνειες δεν περιέχουν πίνακες, αλλάζει το μέγεθος της διαφάνειας σε A4 και αποθηκεύει το αποτέλεσμα. Χρησιμοποιεί [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) με [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) ώστε ο επακόλουθος βρόχος να ελέγχει την κλιμάκωση. Οι λόγοι είναι χωρίς μονάδα· οι θέσεις και οι διαστάσεις των σχημάτων μετρώνται σε σημεία. Διαφορετικοί λόγοι πλάτους και ύψους μπορούν να παραμορφώσουν τα σχήματα, και η αλλαγή των διαστάσεων ενός σχήματος δεν κλιμακώνει τα μεγέθη γραμματοσειράς του.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Υπολογίστε ανεξάρτητους οριζόντιους και κάθετους συντελεστές κλίμακας.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Οι πίνακες απαιτούν ξεχωριστό χειρισμό: κλιμακώστε το πλάτος των στηλών και το ύψος των γραμμών αντί να ορίσετε το συνολικό πλάτος και ύψος του πίνακα. Τα ύψη των γραμμών μπορεί να παραμείνουν μεγαλύτερα από το ζητούμενο εάν το περιεχόμενο του κελιού απαιτεί περισσότερη θέση.
{{% /alert %}}

Το δεύτερο παράδειγμα υποστηρίζει πίνακες και επεξεργάζεται σχήματα σε κύριες διαφάνειες και διατάξεις καθώς και σε μεμονωμένες διαφάνειες πριν αποθηκεύσει την αλλαγμένη παρουσίαση. Ο βοηθός του χειρίζεται κάθε [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) κλιμακώντας τα πλάτη των στηλών με [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) και τα ελάχιστα ύψη των γραμμών με [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). Στη συνέχεια κλιμακώνει τη θέση του πίνακα χωρίς να κλιμακώνει ξεχωριστά τις συνολικές του διαστάσεις.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // Οι διαστάσεις του πίνακα ελέγχονται από τα πλάτη των στηλών και τα ύψη των γραμμών.
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    // Υπολογίστε ανεξάρτητους οριζόντιους και κάθετους συντελεστές κλίμακας.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Αλλάξτε το μέγεθος των σχημάτων που ορίζονται σε κύριες διαφάνειες και διατάξεις, καθώς και σε μεμονωμένες διαφάνειες.
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Γιατί τα σχήματα παραμορφώνονται ή κόβονται μετά την αλλαγή μεγέθους μιας διαφάνειας;**

Αν αλλάξετε το μέγεθος της διαφάνειας χωρίς να κλιμακώσετε τα σχήματα, αυτά διατηρούν τις αρχικές τους θέσεις και διαστάσεις και μπορεί να υπερβαίνουν τα όρια της διαφάνειας. Η κλιμάκωση του πλάτους και του ύψους με διαφορετικούς λόγους μπορεί επίσης να παραμορφώσει τα σχήματα.

**Λειτουργεί ο παρεχόμενος κώδικας για όλους τους τύπους σχημάτων;**

Το πρώτο παράδειγμα αλλάζει άμεσα τα όρια των σχημάτων και προορίζεται για διαφάνειες χωρίς πίνακες. Το δεύτερο παράδειγμα διαχειρίζεται τους πίνακες ξεχωριστά. Ελέγξτε τη διαρραφή του αποτελέσματος, ειδικά το κείμενο και τους πίνακες, επειδή αυτά τα παραδείγματα δεν κλιμακώνουν τα μεγέθη γραμματοσειράς και το περιεχόμενο των πινάκων μπορεί να περιορίσει το ύψος των γραμμών.

**Πώς μπορώ να αλλάξω το μέγεθος των πινάκων όταν αλλάζω το μέγεθος μιας διαφάνειας;**

Κλιμακώστε το πλάτος των στηλών με βάση το λόγο πλάτους και τα ελάχιστα ύψη των γραμμών με βάση το λόγο ύψους, έπειτα κλιμακώστε τη θέση του πίνακα, όπως φαίνεται στο δεύτερο παράδειγμα.

**Θα λειτουργήσει αυτή η αλλαγή μεγέθους και για κύριες διαφάνειες και διατάξεις;**

Ναι. Το δεύτερο παράδειγμα επαναλαμβάνει μέσω του [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) και των [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) κάθε κύριας διαφάνειας και εφαρμόζει την ίδια λογική αλλαγής μεγέθους στα σχήματά τους.

**Μπορώ να αλλάξω την προσανατολισμό μιας διαφάνειας (κάθετη/οριζόντια) μαζί με την αλλαγή μεγέθους;**

Ναι. Καλέστε το [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) μετά την αλλαγή του μεγέθους της διαφάνειας και πριν διαβάσετε τις στοχευμένες διαστάσεις, ώστε οι συντελεστές κλίμακας να αντανακλούν τον τελικό προσανατολισμό.

**Υπάρχει περιορισμός στο μέγεθος της διαφάνειας που μπορώ να ορίσω;**

Μπορείτε να ορίσετε προσαρμοσμένες διαστάσεις διαφάνειας με το [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). Οι υποστηριζόμενες διαστάσεις εξαρτώνται επίσης από τη μορφή της παρουσίασης και την εφαρμογή που χρησιμοποιείται για το άνοιγμα του αρχείου.

**Πώς μπορώ να αποτρέψω τα σχήματα με σταθερή αναλογία διαστάσεων να παραμορφωθούν;**

Χρησιμοποιήστε τον ίδιο συντελεστή κλιμάκωσης για το πλάτος και το ύψος. Για να προσαρμόσετε την αρχική διάταξη στις νέες διαστάσεις της διαφάνειας, χρησιμοποιήστε τον μικρότερο από τους λόγους πλάτους και ύψους και για τις δύο διαστάσεις και τις θέσεις. Αυτό διατηρεί τις αναλογίες, αλλά μπορεί να αφήσει αχρησιμοποίηση χώρου κατά μήκος μιας άκρης.