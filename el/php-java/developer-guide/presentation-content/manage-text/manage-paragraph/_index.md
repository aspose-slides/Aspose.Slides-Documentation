---
title: Διαχείριση Παραγράφων Κειμένου PowerPoint σε PHP
linktitle: Διαχείριση Παραγράφου
type: docs
weight: 40
url: /el/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- προσθήκη κειμένου
- προσθήκη παραγράφου
- διαχείριση κειμένου
- διαχείριση παραγράφου
- διαχείριση κουκκίδας
- εσοχή παραγράφου
- κρεματή εσοχή
- κουκκίδα παραγράφου
- αριθμημένη λίστα
- λίστα με κουκκίδες
- ιδιότητες παραγράφου
- εισαγωγή HTML
- κείμενο σε HTML
- παράγραφος σε HTML
- παράγραφος σε εικόνα
- κείμενο σε εικόνα
- εξαγωγή παραγράφου
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε παραγράφους, τμήματα, κουκκίδες, αριθμημένες λίστες, εσοχές, περιεχόμενο HTML και εικόνες παραγράφων με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides for PHP via Java αντιπροσωπεύει το κείμενο ως μια ιεραρχία πλαισίων κειμένου, παραγράφων και τμημάτων:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) αντιπροσωπεύει το κοντέινερ κειμένου σε ένα σχήμα και παρέχει πρόσβαση στη συλλογή παραγράφων του.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) αντιπροσωπεύει μία παράγραφο σε ένα πλαίσιο κειμένου και παρέχει πρόσβαση στα τμήματα και στη μορφοποίηση επιπέδου παραγράφου.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) αντιπροσωπεύει ένα τμήμα κειμένου μέσα σε μια παράγραφο. Κάθε τμήμα μπορεί να έχει τη δική του μορφοποίηση χαρακτήρων.

Μια παράγραφος μπορεί επομένως να περιέχει κείμενο με διαφορετικές γραμματοσειρές, χρώματα, μεγέθη και άλλη μορφοποίηση χρησιμοποιώντας πολλαπλά τμήματα.

## **Δημιουργία και Μορφοποίηση Παραγράφων**

### **Δημιουργία Παραγράφων με Πολλαπλά Τμήματα**

Τα παρακάτω βήματα δημιουργούν ένα πλαίσιο κειμένου με τρεις παραγράφους, η καθεμία από τις οποίες περιέχει τρία τμήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε μια ορθογώνια [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) του σχήματος.
5. Χρησιμοποιήστε την προεπιλεγμένη παράγραφο και προσθέστε δύο ακόμη αντικείμενα [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) στο πλαίσιο κειμένου.
6. Προσθέστε αρκετά αντικείμενα [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) ώστε κάθε παράγραφος να περιέχει τρία τμήματα. Η προεπιλεγμένη παράγραφος περιέχει ήδη ένα κενό τμήμα.
7. Ορίστε το κείμενο κάθε τμήματος.
8. Εφαρμόστε μορφοποίηση επιπέδου χαρακτήρων μέσω [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat--).
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα PHP υλοποιεί τα βήματα:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Δημιουργία Λιστών με Κουκκίδες και Αρίθμηση**

### **Δημιουργία Λίστας με Κουκκίδες ή Αρίθμηση**

Οι κουκκίδες και η αρίθμηση καθιστούν τα σχετικά στοιχεία πιο ευανάγνωστα. Στο Aspose.Slides, οι ρυθμίσεις λίστας ορίζονται μέσω του [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/).

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) του σχήματος.
5. Καταργήστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου.
6. Δημιουργήστε ένα [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) για μια συμβολοσειρά κουκκίδας.
7. Ορίστε [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) σε [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/) και καθορίστε τον χαρακτήρα της κουκκίδας.
8. Ορίστε το κείμενο της παραγράφου, την εσοχή, το χρώμα της κουκκίδας και το ύψος της κουκκίδας.
9. Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
10. Δημιουργήστε δεύτερη παράγραφο και ορίστε [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) σε [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/).
11. Διαμορφώστε το στυλ αριθμημένης κουκκίδας και προσθέστε την παράγραφο στο πλαίσιο κειμένου.
12. Αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα PHP δημιουργεί μια συμβολοσειρά κουκκίδας και μια αριθμημένη κουκκίδα:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Χρήση Εικόνας Κουκκίδας**

Οι εικόνες κουκκίδας σάς επιτρέπουν να χρησιμοποιήσετε μια προσαρμοσμένη εικόνα αντί για σύμβολο ή αριθμό.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) και αποκτήστε πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
4. Καταργήστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου.
5. Φορτώστε την εικόνα της κουκκίδας και προσθέστε τη στη συλλογή εικόνων της παρουσίασης ως [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).
6. Δημιουργήστε ένα [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) και ορίστε το κείμενό του.
7. Ορίστε [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) σε [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/).
8. Αντιστοιχίστε την εικόνα μέσω [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture--) και ορίστε το ύψος της κουκκίδας.
9. Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα PHP δημιουργεί μια εικόνα κουκκίδας:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **Δημιουργία Πολυεπίπεδης Λίστας**

Ορίστε [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth-short-) για να τοποθετήσετε τις παραγράφους σε διαφορετικά επίπεδα λίστας. Το ανώτερο επίπεδο έχει βάθος `0`.

1. Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) και αποκτήστε πρόσβαση σε μια διαφάνεια.
2. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) και αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου του.
3. Δημιουργήστε τέσσερις παραγράφους και διαμορφώστε τα σύμβολα κουκκίδας τους.
4. Ορίστε τις τιμές [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth-short-) σε `0`, `1`, `2` και `3`.
5. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου και αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα PHP δημιουργεί μια τετραεπίπεδη λίστα με κουκκίδες:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Έναρξη Αριθμημένων Στοιχείων Λίστας με Προσαρμοσμένες Τιμές**

Χρησιμοποιήστε [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) για να ορίσετε τον αρχικό αριθμό που εμφανίζεται για μια αριθμημένη παράγραφο.

1. Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) και προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) σε μια διαφάνεια.
2. Καθαρίστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου του σχήματος.
3. Δημιουργήστε τρεις αριθμημένες παραγράφους.
4. Ορίστε [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) σε `2`, `3` και `7` για τις αντίστοιχες παραγράφους.
5. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου και αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα PHP αντιστοιχεί σε προσαρμοσμένους αρχικούς αριθμούς για κάθε παράγραφο:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Έλεγχος Διάταξης Παραγράφου και Ιδιοτήτων Τέλους**

### **Ορισμός Εσοχής Πρώτης Γραμμής**

Χρησιμοποιήστε [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η μέθοδος μετακινεί μόνο την πρώτη γραμμή σχετικά με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετατοπίζει την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) όταν χρειάζεται να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δημιουργεί αρκετές παραγράφους και εφαρμόζει διαφορετικές τιμές [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) για να δείξει πώς η εσοχή πρώτης γραμμής επηρεάζει τη διάταξη της παραγράφου.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Πρόσβαση στη στοχευόμενη διαφάνεια.
3. Προσθέστε μια ορθογώνια [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) του σχήματος και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε πολλές παραγράφους και ορίστε διαφορετικές τιμές [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) για αυτές.
6. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε εσοχή παραγράφου:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η εσοχή πρώτης γραμμής των παραγράφων](first_line_indent.png)

### **Ορισμός Κρεματής Εσοχής**

Μια κρεματή εσοχή είναι μια διάταξη παραγράφου στην οποία η πρώτη γραμμή αρχίζει αριστερά των υπολοίπων γραμμών. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-). Δώστε μια αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) ορίζει τη θέση αριστερά του σώματος της παραγράφου, και το [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε μια κρεματή εσοχή, δώστε μια θετική τιμή στο `setMarginLeft` και μια αρνητική τιμή στο `setIndent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, εγγραφές γλωσσολογικού λόγου και άλλες παραγράφους όπου οι περιτυλιγμένες γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου αντί κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Πρόσβαση στη στοχευόμενη διαφάνεια.
3. Προσθέστε μια ορθογώνια [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) του σχήματος και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε παραγράφους και δώστε μια θετική τιμή στο [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) για καθεμία.
6. Δώστε μια αρνητική τιμή στο [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) για να δημιουργήσετε το εφέ κρεματής εσοχής.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε κρεματή εσοχή για μια παράγραφο:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η κρεματή εσοχή των παραγράφων](hanging_indent.png)

### **Ορισμός Ιδιοτήτων Τέλους Παραγράφου**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) ελέγχει τη μορφοποίηση του σημείου τερματισμού της παραγράφου. Το παρακάτω παράδειγμα PHP αντιστοιχεί μέγεθος γραμματοσειράς και λατινική γραμματοσειρά στο σημείο τερματισμού της δεύτερης παραγράφου:

1. Φορτώστε μια [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) και πρόσβαση σε μια διαφάνεια.
2. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) και καθαρίστε την προεπιλεγμένη παράγραφο.
3. Δημιουργήστε δύο παραγράφους και προσθέστε τμήματα κειμένου σε αυτές.
4. Δημιουργήστε ένα [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) για το σημείο τερματισμού της δεύτερης παραγράφου.
5. Ορίστε [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) και [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Αντιστοιχίστε τη μορφοποίηση με [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) και αποθηκεύστε την παρουσίαση.

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Καταμέτρηση Σχεδιασμένων Γραμμών**

Για κανόνες παραγράφου που επηρεάζουν την αυτόματη αναδίπλωση και την στίξη στο τέλος γραμμής, δείτε [Control Line Breaking](/slides/el/php-java/text-formatting/#control-line-breaking) και [Control Hanging Punctuation](/slides/el/php-java/text-formatting/#control-hanging-punctuation).

Χρησιμοποιήστε [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount--) για να μετρήσετε τις γραμμές που καταλαμβάνει μια παράγραφος μετά τη διάταξη του κειμένου, συμπεριλαμβανομένης της αυτόματης αναδίπλωσης. Αυτό είναι χρήσιμο όταν ελέγχετε το μήκος του κειμένου και τη διάταξη σε πρότυπα παρουσίασης.

Μια παράγραφος είναι ένα στοιχείο στο [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs--), και μπορεί να καταλάβει αρκετές σχεδιασμένες γραμμές. Μια ρητή αλλαγή γραμμής μέσα σε μια παράγραφο δημιουργεί νέα γραμμή χωρίς να δημιουργεί νέα παράγραφο. Η αυτόματη αναδίπλωση δημιουργεί γραμμές βάσει του διαθέσιμου πλάτους χωρίς να εισάγει ρητές αλλαγές γραμμής στο κείμενο. Συνεπώς, η καταμέτρηση παραγράφων ή χαρακτήρων αλλαγής γραμμής δεν δίνει τον αριθμό των σχεδιασμένων γραμμών.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα κειμένου, μετρά τις γραμμές του, στενεύει το σχήμα και στη συνέχεια αντικαθιστά το κείμενο με μια συντομότερη συμβολοσειρά. Η αναδίπλωση είναι ενεργοποιημένη και η αυτόματη προσαρμογή είναι απενεργοποιημένη ώστε το πλάτος του σχήματος να ελέγχει την αναδίπλωση χωρίς αυτόματη σμίκρυνση του κειμένου ή αλλαγή μεγέθους του σχήματος. Οι διαστάσεις του σχήματος εκφράζονται σε πόντους. Τέλος, το παράδειγμα προσθέτει άλλη μια παράγραφο και αθροίζει τους αριθμούς γραμμών σε όλο το πλαίσιο κειμένου.

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Με αυτό το κείμενο και αυτές τις διαστάσεις, η στένωση του σχήματος αυξάνει τον αριθμό γραμμών, ενώ η αντικατάσταση του κειμένου με τη σύντομη συμβολοσειρά τον μειώνει. Οι ακριβείς μετρήσεις μπορεί να διαφέρουν ανάλογα με τη διαθεσιμότητα γραμματοσειρών και τις αντικαταστάσεις, το μέγεθος γραμματοσειράς, τα περιθώρια, την εσοχή, την αναδίπλωση και τις ρυθμίσεις αυτόματης προσαρμογής. Χρησιμοποιήστε τις γραμματοσειρές και τις ρυθμίσεις διάταξης που προορίζονται για το περιβάλλον στόχο όταν ελέγχετε ένα πρότυπο.

Ο μόνος αριθμός γραμμών δεν καθορίζει αν το κείμενο υπερβαίνει το περιέκτη του. Το διαθέσιμο ύψος, τα ύψη γραμμής, η απόσταση παραγράφου και γραμμής, καθώς και η συμπεριφορά αυτόματης προσαρμογής επίσης παίζουν ρόλο· ακόμη και μία γραμμή μπορεί να υπερβεί το διαθέσιμο πλάτος όταν η αναδίπλωση είναι απενεργοποιημένη.

## **Εισαγωγή και Εξαγωγή Περιεχομένου Παραγράφου**

### **Εισαγωγή Κειμένου HTML σε Παραγράφους**

Χρησιμοποιήστε [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) για να μετατρέψετε HTML markup σε παραγράφους και τμήματα σε ένα πλαίσιο κειμένου.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Πρόσβαση σε μια διαφάνεια και προσθήκη ενός [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
3. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) του σχήματος και αφαίρεση της προεπιλεγμένης παραγράφου.
4. Διαβάστε το πηγαίο αρχείο HTML.
5. Π pass the HTML string to [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα PHP εισάγει HTML σε ένα πλαίσιο κειμένου:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **Εξαγωγή Κειμένου Παραγράφου σε HTML**

Χρησιμοποιήστε [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) για να εξάγετε ένα επιλεγμένο εύρος παραγράφων ως HTML.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) και φορτώστε την επιθυμητή παρουσίαση.
2. Πρόσβαση στη διαφάνεια και εντοπισμός του [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) που περιέχει το κείμενο.
3. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) του σχήματος.
4. Κλήση του [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) με τον δείκτη της αρχικής παραγράφου και τον αριθμό των παραγράφων προς εξαγωγή.
5. Γράψτε τη ληφθείσα συμβολοσειρά HTML σε αρχείο.

Αυτό το παράδειγμα PHP εξάγει όλες τις παραγράφους από το πρώτο σχήμα κειμένου:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **Απόδοση Παραγράφου ως Εικόνα**

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--) αποδίδει απευθείας μια μεμονωμένη παράγραφο και επιστρέφει ένα [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/). Αποθηκεύστε το αποτέλεσμα σε αρχείο ή ροή με [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Δεν χρειάζεται να αποδώσετε το περιβάλλον σχήμα ή να περικόψετε bitmap χειροκίνητα.

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--) μπορεί να επιστρέψει `null` εάν η παράγραφος δεν βρεθεί στη γονική της συλλογή, δεν έχει έγκυρα όρια απόδοσης ή δεν μπορεί να αποδοθεί. Ελέγξτε το αποτέλεσμα πριν το αποθηκεύσετε και απελευθερώστε την επιστρεφόμενη εικόνα μετά τη χρήση.

#### **Απόδοση Παραγράφου στην Προεπιλεγμένη Κλίμακα**

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης που ονομάζεται sample.pptx με μία διαφάνεια, όπου το πρώτο σχήμα είναι ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους.

![Το πλαίσιο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

Το παρακάτω παράδειγμα PHP αποδίδει τη δεύτερη παράγραφο σε ένα κανονικό πλαίσιο κειμένου στην προεπιλεγμένη κλίμακα και αποθηκεύει την επιστρεφόμενη εικόνα σε μορφή PNG. Το τμήμα `finally` διασφαλίζει ότι η εικόνα απελευθερώνεται σωστά.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η εικόνα της παραγράφου](paragraph_to_image_output.png)

#### **Απόδοση Παραγράφου σε Κελί Πίνακα με Κλιμάκωση**

Χρησιμοποιήστε το υπερφορτωμένο [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage-float-float-) που δέχεται τις παραμέτρους `$scaleX` και `$scaleY` για να ορίσετε τους οριζόντιους και κάθετους συντελεστές κλίμακας. Το παρακάτω παράδειγμα PHP δημιουργεί έναν πίνακα, αποδίδει την παράγραφο στο πρώτο κελί του διπλάσιο του προεπιλεγμένου πλάτους και ύψους και αποθηκεύει το αποτέλεσμα ως PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

Ένας συντελεστής κλίμακας `1` διατηρεί αυτόν τον άξονα στο προεπιλεγμένο μέγεθος εικονοστοιχείου. Για παράδειγμα, `2` για και τις δύο παράμετρους δημιουργεί εικόνα του οποίου το πλάτος και το ύψος είναι περίπου διπλάσιο του προεπιλεγμένου, με αποτέλεσμα τέσσερις φορές περισσότερα εικονοστοιχεία. Μεγαλύτεροι συντελεστές συνήθως παράγουν ευκρύτερο κείμενο για μεγέθυνση ή έξοδο υψηλής ανάλυσης, αλλά αυξάνουν και τη μνήμη και το μέγεθος αρχείου. Συντελεστές μικρότεροι από `1` παράγουν μικρότερες εικόνες με λιγότερες λεπτομέρειες. Χρησιμοποιήστε ίδιους συντελεστές για να διατηρήσετε την αναλογία διαστάσεων της παραγράφου· διαφορετικοί οριζόντιοι και κάθετοι συντελεστές τεντώνουν το αποτέλεσμα ανεξαρτήτως.

Η απόδοση ολόκληρου σχήματος με [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage--) παραμένει χρήσιμη όταν η έξοδος πρέπει να περιλαμβάνει το γέμισμα, το περίγραμμα ή άλλα οπτικά στοιχεία του σχήματος. Για εικόνα μόνο-παραγράφου, χρησιμοποιήστε το [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--).

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς τη διάσπαση γραμμής μέσα σε πλαίσιο κειμένου;**

Ναι. Ορίστε το [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText-byte-) ώστε να απενεργοποιήσετε την αναδίπλωση, έτσι οι γραμμές δεν θα σπάνε στα άκρα του πλαισίου κειμένου.

**Πώς μπορώ να λάβω τα ακριβή όρια πάνω‑διαφάνειας μιας συγκεκριμένης παραγράφου;**

Χρησιμοποιήστε το [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect--) για να ανακτήσετε το ορθογώνιο περιορισμού της παραγράφου. Το [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect--) παρέχει τα όρια ενός μεμονωμένου τμήματος.

**Πού ελέγχεται η στοίχιση παραγράφου (αριστερά, δεξιά, κέντρο ή διάσπαρτη);**

Το [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment-int-) είναι μια ρύθμιση επιπέδου παραγράφου και εφαρμόζεται σε όλη την παράγραφο ανεξάρτητα από τη μορφοποίηση των επιμέρους τμημάτων.

Για να στοιχίσετε κατακόρυφα τμήματα διαφορετικών μεγεθών γραμματοσειράς εντός κάθε γραμμής, δείτε [Align Fonts Within a Line](/slides/el/php-java/text-formatting/#align-fonts-within-a-line).

**Μπορώ να ορίσω τη γλώσσα απόδειξης για μέρος μιας παραγράφου;**

Ναι. Ορίστε το [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) για μεμονωμένα τμήματα, ώστε μια παράγραφος να μπορεί να περιέχει κείμενο σε πολλές γλώσσες.