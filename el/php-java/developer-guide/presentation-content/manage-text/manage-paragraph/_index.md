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
- διαχείριση κουκίδας
- εσοχή παραγράφου
- εσώματιση
- κουκίδα παραγράφου
- αριθμημένη λίστα
- λίστα με κουκίδες
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
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε παραγράφους, τμήματα, κουκίδες, αριθμημένες λίστες, εσοχές, περιεχόμενο HTML και εικόνες παραγράφων με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides for PHP μέσω Java αντιπροσωπεύει το κείμενο ως ιεραρχία πλαισίων κειμένου, παραγράφων και τμημάτων:

* [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) αναπαριστά το δοχείο κειμένου σε ένα σχήμα και παρέχει πρόσβαση στη συλλογή παραγράφων του.
* [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) αναπαριστά μία παράγραφο σε ένα πλαίσιο κειμένου και παρέχει πρόσβαση στα τμήματα του καθώς και στη διαμόρφωση σε επίπεδο παραγράφου.
* [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) αντιπροσωπεύει μια διαδοχή κειμένου μέσα σε μια παράγραφο. Κάθε τμήμα μπορεί να έχει το δικό του κείμενο και διαμόρφωση σε επίπεδο χαρακτήρων.

Μια παράγραφος μπορεί λοιπόν να περιέχει κείμενο με διαφορετικές γραμματοσειρές, χρώματα, μεγέθη και άλλες διαμορφώσεις, χρησιμοποιώντας πολλαπλά τμήματα.

## **Δημιουργία και Διαμόρφωση Παραγράφων**

### **Δημιουργία Παραγράφων με Πολλαπλά Τμήματα**

Τα παρακάτω βήματα δημιουργούν ένα πλαίσιο κειμένου με τρεις παραγράφους, καθεμία από τις οποίες περιέχει τρία τμήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του σχήματος.
5. Χρησιμοποιήστε την προεπιλεγμένη παράγραφο και προσθέστε δύο ακόμη αντικείμενα [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) στο πλαίσιο κειμένου.
6. Προσθέστε αρκετά αντικείμενα [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) ώστε κάθε παράγραφος να περιέχει τρία τμήματα. Η προεπιλεγμένη παράγραφος περιέχει ήδη ένα κενό τμήμα.
7. Ορίστε το κείμενο κάθε τμήματος.
8. Εφαρμόστε διαμόρφωση επιπέδου χαρακτήρων μέσω του [Portion::getPortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/#getPortionFormat--).
9. Αποθηκεύστε την τροποποιημένη παρουσία.

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

## **Δημιουργία Λιστών με Κουκίδες και Αρίθμιση**

### **Δημιουργία Λίστας με Κουκίδες ή Αρίθμηση**

Οι κουκίδες και η αρίθμηση διευκολύνουν την ανάγνωση σχετικών στοιχείων. Στο Aspose.Slides, οι ρυθμίσεις λίστας ορίζονται μέσω του [BulletFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/).

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του σχήματος.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου.
6. Δημιουργήστε ένα [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) για μια κουκίδα σύμβολου.
7. Ορίστε το [BulletFormat::setType](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#setType-int-) σε [BulletType::Symbol](https://reference.aspose.com/slides/el/php-java/aspose.slides/bullettype/) και καθορίστε τον χαρακτήρα της κουκίδας.
8. Ορίστε το κείμενο της παραγράφου, την εσοχή, το χρώμα και το ύψος της κουκίδας.
9. Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
10. Δημιουργήστε δεύτερη παράγραφο και ορίστε το [BulletFormat::setType](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#setType-int-) σε [BulletType::Numbered](https://reference.aspose.com/slides/el/php-java/aspose.slides/bullettype/).
11. Διαμορφώστε το στυλ της αριθμημένης κουκίδας και προσθέστε την παράγραφο στο πλαίσιο κειμένου.
12. Αποθηκεύστε την παρουσία.

Αυτό το παράδειγμα PHP δημιουργεί μια κουκίδα σύμβολου και μια αριθμημένη κουκίδα:

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

### **Χρήση Κουκίδων Εικόνας**

Οι κουκίδες εικόνας σας επιτρέπουν να χρησιμοποιήσετε μια προσαρμοσμένη εικόνα αντί για σύμβολο ή αριθμό.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) και πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/).
4. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου.
5. Φορτώστε την εικόνα της κουκίδας και προσθέστε τη στη συλλογή εικόνων της παρουσίασης ως [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/).
6. Δημιουργήστε ένα [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) και ορίστε το κείμενό του.
7. Ορίστε το [BulletFormat::setType](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#setType-int-) σε [BulletType::Picture](https://reference.aspose.com/slides/el/php-java/aspose.slides/bullettype/).
8. Αντιστοιχίστε την εικόνα μέσω του [BulletFormat::getPicture](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#getPicture--) και ορίστε το ύψος της κουκίδας.
9. Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
10. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτό το παράδειγμα PHP δημιουργεί μια κουκίδα εικόνας:

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

Ορίστε το [ParagraphFormat::setDepth](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setDepth-short-) για να τοποθετήσετε παραγράφους σε διαφορετικά επίπεδα λίστας. Το ανώτερο επίπεδο έχει βάθος `0`.

1. Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και προσπελάστε μια διαφάνεια.
2. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) και αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου του.
3. Δημιουργήστε τέσσερις παραγράφους και διαμορφώστε τα σύμβολα των κουκίδων τους.
4. Ορίστε τις τιμές του [ParagraphFormat::setDepth](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setDepth-short-) σε `0`, `1`, `2` και `3`.
5. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου και αποθηκεύστε την παρουσία.

Αυτό το παράδειγμα PHP δημιουργεί μια λίστα με τέσσερα επίπεδα κουκίδων:

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

Χρησιμοποιήστε το [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) για να ορίσετε τον αρχικό αριθμό που εμφανίζεται σε αριθμημένη παράγραφο.

1. Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) σε μια διαφάνεια.
2. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου του σχήματος.
3. Δημιουργήστε τρεις αριθμημένες παραγράφους.
4. Ορίστε το [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) σε `2`, `3` και `7` για τις αντίστοιχες παραγράφους.
5. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου και αποθηκεύστε την παρουσία.

Αυτό το παράδειγμα PHP αντιστοιχεί έναν προσαρμοσμένο αρχικό αριθμό σε κάθε παράγραφο:

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

Χρησιμοποιήστε το [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setIndent-float-) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η μέθοδος μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετακινεί την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setIndent-float-) όταν θέλετε να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δημιουργεί αρκετές παραγράφους και εφαρμόζει διαφορετικές τιμές του [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setIndent-float-) για να δείξει πώς η εσοχή πρώτης γραμμής επηρεάζει τη διάταξη.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πρόσβαση στη στοχευμένη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του σχήματος και αφαίρεση της προεπιλεγμένης παραγράφου.
5. Δημιουργήστε πολλές παραγράφους και ορίστε διαφορετικές τιμές του [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setIndent-float-) για καθεμία.
6. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσία.

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

### **Ορισμός Εσώματισης (Hanging Indent)**

Η εσώματιση είναι μια διάταξη παραγράφου όπου η πρώτη γραμμή ξεκινά αριστερότερα από τις υπόλοιπες γραμμές. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με το [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setIndent-float-). Δώστε μια αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή αριστερά σχετικά με το σώμα της παραγράφου.

Στην πράξη, το [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) ορίζει τη θέση αριστερά του σώματος της παραγράφου, ενώ το [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setIndent-float-) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για εσώματιση, δώστε μια θετική τιμή στο `setMarginLeft` και μια αρνητική τιμή στο `setIndent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, καταχωρήσεις γλωσσολογικού λεξικού και άλλες παραγράφους όπου οι αναδιπλωμένες γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου και όχι κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πρόσβαση στη στοχευμένη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του σχήματος και αφαίρεση της προεπιλεγμένης παραγράφου.
5. Δημιουργήστε παραγράφους και δώστε μια θετική τιμή στο [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) για κάθε παράγραφο.
6. Δώστε μια αρνητική τιμή στο [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setIndent-float-) για να δημιουργήσετε το εφέ της εσώματισης.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτός ο κώδικας PHP δείχνει πώς να ορίσετε εσώματιση για μια παράγραφο:

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

![Η εσώματιση των παραγράφων](hanging_indent.png)

### **Ορισμός Ιδιοτήτων Τέλους Παραγράφου**

Η μέθοδος [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) ελέγχει τη διαμόρφωση του σημείου τέλους της παραγράφου. Το παρακάτω παράδειγμα PHP αναθέτει μέγεθος γραμματοσειράς και λατινική γραμματοσειρά στο τέλος της δεύτερης παραγράφου:

1. Φορτώστε μια [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και προσπελάστε μια διαφάνεια.
2. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) και αφαιρέστε την προεπιλεγμένη του παράγραφο.
3. Δημιουργήστε δύο παραγράφους και προσθέστε τμήματα κειμένου σε αυτές.
4. Δημιουργήστε ένα [PortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/portionformat/) για το σημείο τέλους της δεύτερης παραγράφου.
5. Ορίστε το [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) και το [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Αναθέστε τη μορφή με το [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) και αποθηκεύστε την παρουσία.

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

## **Εισαγωγή και Εξαγωγή Περιεχομένου Παραγράφου**

### **Εισαγωγή HTML Κειμένου σε Παραγράφους**

Χρησιμοποιήστε το [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) για να μετατρέψετε σήμανση HTML σε παραγράφους και τμήματα σε ένα πλαίσιο κειμένου.

1. Δημιουργήστε μια παρουσία της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πρόσβαση σε μια διαφάνεια και προσθήκη ενός [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).
3. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του σχήματος και αφαίρεση της προεπιλεγμένης παραγράφου.
4. Διαβάστε το αρχείο HTML πηγής.
5. Μετάβαλε το κείμενο HTML στο [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Αποθηκεύστε την τροποποιημένη παρουσία.

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

Χρησιμοποιήστε το [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) για να εξάγετε ένα επιλεγμένο εύρος παραγράφων ως HTML.

1. Δημιουργήστε μια παρουσία της [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και φορτώστε την επιθυμητή παρουσία.
2. Πρόσβαση στη διαφάνεια και εντοπισμός του [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) που περιέχει το κείμενο.
3. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του σχήματος.
4. Καλέστε το [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) με το αρχικό δείκτη παραγράφου και τον αριθμό παραγράφων προς εξαγωγή.
5. Γράψτε το επιστρεφόμενο κείμενο HTML σε αρχείο.

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

### **Απόδοση Παραγράφου ως Εικόνας**

Η μέθοδος [Paragraph::getImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/#getImage--) αποδίδει άμεσα μια μεμονωμένη παράγραφο και επιστρέφει ένα [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/). Αποθηκεύστε το αποτέλεσμα σε αρχείο ή ρεύμα με το [IImage::save](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Δεν χρειάζεται να αποδώσετε ολόκληρο το σχήμα ή να περικόψετε το bitmap χειροκίνητα.

Το [Paragraph::getImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/#getImage--) μπορεί να επιστρέψει `null` αν η παράγραφος δεν βρεθεί στη γονική της συλλογή, δεν έχει έγκυρα όρια απόδοσης ή δεν μπορεί να αποδοθεί. Ελέγξτε το αποτέλεσμα πριν το αποθηκεύσετε και διαγράψτε την εικόνα μετά τη χρήση.

#### **Απόδοση Παραγράφου στην Προεπιλεγμένη Κλίμακα**

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης με όνομα sample.pptx με μία διαφάνεια, όπου το πρώτο σχήμα είναι ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους.

![Το πλαίσιο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

Το παρακάτω παράδειγμα PHP αποδίδει τη δεύτερη παράγραφο σε ένα κανονικό σχήμα κειμένου στην προεπιλεγμένη κλίμακα και αποθηκεύει την εικόνα σε μορφή PNG. Το μπλοκ `finally` εξασφαλίζει τη σωστή απελευθέρωση της εικόνας.

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

Χρησιμοποιήστε την υπερφόρτωση του [Paragraph::getImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/#getImage-float-float-) που δέχεται τις παραμέτρους `$scaleX` και `$scaleY` για να ορίσετε τους οριζόντιους και κατακόρυφους παράγοντες κλίμακας. Το παρακάτω παράδειγμα PHP δημιουργεί έναν πίνακα, αποδίδει την παράγραφο στο πρώτο του κελί με διπλάσιο πλάτος και ύψος από την προεπιλεγμένη και αποθηκεύει το αποτέλεσμα ως εικόνα PNG.

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

Ένας παράγοντας κλίμακας `1` διατηρεί τον άξονα στο προεπιλεγμένο μέγεθος εικονοστοιχείου. Για παράδειγμα, `2` και για τους δύο παράγοντες παράγει εικόνα του οποίας το πλάτος και το ύψος είναι περίπου διπλάσιο από τις προεπιλεγμένες διαστάσεις, με αποτέλεσμα τέσσερις φορές περισσότερα εικονοστοιχεία. Μεγαλύτεροι παράγοντες γενικά παράγουν πιο οξυρήμένο κείμενο για ζουμ ή υψηλής ανάλυσης έξοδο, αλλά αυξάνουν τη μνήμη και το μέγεθος του αρχείου. Παράγοντες κάτω από `1` παράγουν μικρότερες εικόνες με λιγότερες λεπτομέρειες. Χρησιμοποιήστε ίσους παράγοντες για να διατηρήσετε την αναλογία διαστάσεων της παραγράφου· διαφορετικοί οριζόντιοι και κατακόρυφοι παράγοντες τεντώσουν το αποτέλεσμα ανεξάρτητα.

Η απόδοση ολόκληρου σχήματος με το [Shape::getImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getImage--) παραμένει χρήσιμη όταν η έξοδος πρέπει να περιλαμβάνει το γέμισμα, το περίγραμμα ή άλλο οπτικό περιεχόμενο του σχήματος. Για εικόνα μόνο της παραγράφου, χρησιμοποιήστε το [Paragraph::getImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/#getImage--).

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς την αναδίπλωση γραμμών μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Ορίστε το [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setWrapText-byte-) για να απενεργοποιήσετε την αναδίπλωση ώστε οι γραμμές να μην σπάνε στα άκρα του πλαισίου κειμένου.

**Πώς μπορώ να λάβω τα ακριβή όρια στην διαφάνεια ενός συγκεκριμένου παραγράφου;**

Χρησιμοποιήστε το [Paragraph::getRect](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/#getRect--) για να ανακτήσετε το ορθογώνιο περιοριστικό της παραγράφου. Το [Portion::getRect](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/#getRect--) παρέχει τα όρια ενός μεμονωμένου τμήματος.

**Πού ελέγχεται η στοίχιση παραγράφου (αριστερά, δεξιά, κέντρο ή πλήρης στοίχιση);**

Το [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setAlignment-int-) είναι ρύθμιση σε επίπεδο παραγράφου και εφαρμόζεται σε ολόκληρη την παράγραφο ανεξάρτητα από τη διαμόρφωση μεμονωμένων τμημάτων.

**Μπορώ να ορίσω τη γλώσσα απόδειξης για μέρος μιας παραγράφου;**

Ναι. Ορίστε το [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) για μεμονωμένα τμήματα, ώστε μια παράγραφος να μπορεί να περιέχει κείμενο σε πολλές γλώσσες.