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
  - εσώματη εσοχή
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

Aspose.Slides for PHP μέσω Java αναπαριστά το κείμενο ως ιεραρχία πλαισίων κειμένου, παραγράφων και τμημάτων:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) αντιπροσωπεύει το δοχείο κειμένου σε ένα σχήμα και παρέχει πρόσβαση στη συλλογή παραγράφων του.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) αντιπροσωπεύει μία παράγραφο σε ένα πλαίσιο κειμένου και παρέχει πρόσβαση στα τμήματα και στη διαμόρφωση επιπέδου παραγράφου.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) αντιπροσωπεύει μια εκτέλεση κειμένου μέσα σε μια παράγραφο. Κάθε τμήμα μπορεί να έχει το δικό του κείμενο και διαμόρφωση σε επίπεδο χαρακτήρων.

Μία παράγραφος μπορεί λοιπόν να περιέχει κείμενο με διαφορετικές γραμματοσειρές, χρώματα, μεγέθη και άλλη μορφοποίηση χρησιμοποιώντας πολλαπλά τμήματα.

## **Δημιουργία και Μορφοποίηση Παραγράφων**

Δημιουργήστε παραγράφους στο πλαίσιο κειμένου ενός σχήματος και χρησιμοποιήστε τμήματα για να μορφοποιήσετε μεμονωμένες εκτελέσεις κειμένου. Η ενότητα αυτή δείχνει πώς να συνδυάσετε πολλαπλά τμήματα σε κάθε παράγραφο και να εφαρμόσετε διαφορετικά χρώματα, μεγέθη γραμματοσειράς και στυλ.

### **Δημιουργία Παραγράφων με Πολλαπλά Τμήματα**

Το παρακάτω παράδειγμα PHP δημιουργεί τρεις παραγράφους, η κάθε μία περιέχει τρεις εκτελέσεις κειμένου στη συλλογή που επιστρέφεται από το [Paragraph::getPortions](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getPortions). Επαναχρησιμοποιεί την προεπιλεγμένη παράγραφο και το κενό της τμήμα, στη συνέχεια προσθέτει τις υπόλοιπες παραγράφους και τμήματα. Η μορφοποίηση εφαρμόζεται μέσω του [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat): το πρώτο τμήμα σε κάθε παράγραφο είναι κόκκινο, έντονο και 15 σημείων· το δεύτερο είναι μπλε, πλάγιο και 18 σημείων. Το τρίτο τμήμα διατηρεί τη προεπιλεγμένη μορφοποίησή του:

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

## **Δημιουργία Λιστών με Κουκίδες και Αρίθμηση**

Οργανώστε το κείμενο των παραγράφων σε λίστες με σύμβολα, αριθμούς ή προσαρμοσμένες εικόνες. Τα παραδείγματα σε αυτήν την ενότητα καλύπτουν τη μορφοποίηση κουκίδων, τις πολυεπίπεδες λίστες και την προσαρμοσμένη έναρξη αριθμών.

### **Δημιουργία Λίστας με Κουκίδες ή Αρίθμηση**

Οι κουκίδες και η αρίθμηση καθιστούν τα σχετικά στοιχεία πιο εύκολα στην ανάγνωση. Στο Aspose.Slides, οι ρυθμίσεις λίστας ορίζονται μέσω του [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/).

Το παράδειγμα PHP προσθέτει μια συμβολική κουκίδα και ένα αριθμημένο στοιχείο στο ίδιο πλαίσιο κειμένου. Το [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) επιλέγει τον τύπο της κουκίδας, ενώ το [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) παρέχει το σύμβολο και το [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) επιλέγει το στυλ αρίθμησης. Και τα δύο στοιχεία χρησιμοποιούν μαύρες κουκίδες με ύψος 100 τοις εκατό και εσοχή παραγράφου 25 σημεία:

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

### **Χρήση Εικόνας ως Κουκίδα**

Οι εικόνες κουκίδες σάς επιτρέπουν να χρησιμοποιήσετε μια προσαρμοσμένη εικόνα αντί για σύμβολο ή αριθμό.

Το παράδειγμα PHP προσθέτει μια εικόνα στη συλλογή εικόνων της παρουσίασης ως [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/). Καλεί το [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) για να χρησιμοποιήσει εικόνα‑κουκίδα και αναθέτει την εικόνα μέσω του [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture). Το [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) ορίζεται στο 100 τοις εκατό για να ορίσει το μέγεθος της κουκίδας σε σχέση με το κείμενο της παραγράφου:

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

Ορίστε το [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) για να τοποθετήσετε παραγράφους σε διαφορετικά επίπεδα μιας λίστας. Το ανώτερο επίπεδο έχει βάθος `0`.

Το παράδειγμα PHP αποδίδει τιμές στο [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) από 0 έως 3 σε τέσσερις παραγράφους, δημιουργώντας μια ιεραρχία μέσα σε ένα πλαίσιο κειμένου. Κάθε παράγραφος χρησιμοποιεί μια σύμβολο‑κουκίδα, ενώ το [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) εναλλάσσεται μεταξύ μιας στρογγυλής κουκίδας και ενός παύλα για να διακρίνει τα γειτονικά επίπεδα:

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

Χρησιμοποιήστε το [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) για να ορίσετε τον αρχικό αριθμό που εμφανίζεται για μια αριθμημένη παράγραφο.

Το παράδειγμα PHP ορίζει το [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) για να χρησιμοποιήσει αρίθμηση για τρεις παραγράφους και αποδίδει τιμές στο [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) 2, 3 και 7. Η αρχική τιμή διαμορφώνεται ξεχωριστά για κάθε παράγραφο, επιτρέποντας την παράλειψη αριθμών:

```php
use aspose\slides\BulletType;
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

## **Έλεγχος Διάταξης Παραγράφων και Ιδιότητες Λήξης**

Ρυθμίστε τα περιθώρια και τις εσοχές των παραγράφων για να ελέγξετε τη θέση της πρώτης γραμμής και των γραμμών αναδίπλωσης. Μπορείτε επίσης να μορφοποιήσετε το σημάδι λήξης της παραγράφου ξεχωριστά από τα ορατά τμήματα κειμένου.

### **Ορισμός Εσοχής Πρώτης Γραμμής**

Χρησιμοποιήστε τη μέθοδο [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η ρύθμιση μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετατοπίζει την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) όταν χρειάζεται να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δίνει τρεις παραγράφους το ίδιο [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) 20 σημείων και τιμές [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) 0, 20 και 40 σημείων. Οι πρώτες γραμμές ξεκινούν με όλο και μεγαλύτερα ορίσματα, ενώ οι γραμμές αναδίπλωσης διατηρούν το ίδιο αριστερό περιθώριο:

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

### **Ορισμός Εσώματης Εσοχής**

Η εσώματη εσοχή είναι μια διάταξη παραγράφου στην οποία η πρώτη γραμμή αρχίζει αριστερά των υπολοίπων γραμμών. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με την ιδιότητα [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent). Ορίστε το `Indent` σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) ορίζει τη θέση αριστερά του σώματος της παραγράφου, και το [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε εσώματη εσοχή, ορίστε μια θετική τιμή `MarginLeft` και μια αρνητική τιμή `Indent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, καταχωρήσεις γλωσσολογίου και άλλες παραγράφους όπου οι γραμμές αναδίπλωσης πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου αντί κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

Το ακόλουθο παράδειγμα PHP συνδυάζει τιμές του [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) 40 και 60 σημείων με τιμές του [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) -20 και -30 σημείων. Σε κάθε παράγραφο, η πρώτη γραμμή αρχίζει αριστερά των γραμμών αναδίπλωσης· η δεύτερη παράγραφος έχει βαθύτερη εσώματη εσοχή:

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

![Η εσώματη εσοχή των παραγράφων](hanging_indent.png)

### **Ορισμός Ιδιοτήτων Τέλους Εκτέλεσης Παραγράφου**

Η μέθοδος [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) ελέγχει τη μορφοποίηση του σημείου λήξης της παραγράφου. Το παρακάτω παράδειγμα δημιουργεί ένα [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) με το [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) ορισμένο στα 48 σημεία και το [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont) ορισμένο σε Times New Roman. Αντιστοιχίζει αυτή τη μορφή στη σημάδι λήξης της δεύτερης παραγράφου, αφήνοντας τα ορατά τμήματα κειμένου αμετάβλητα:

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

## **Καταμέτρηση Απεικονισμένων Γραμμών**

Για κανόνες παραγράφων που επηρεάζουν την αυτόματη αναδίπλωση και την στίξη στο τέλος των γραμμών, δείτε [Έλεγχος Διακοπής Γραμμής](/slides/el/php-java/text-formatting/#control-line-breaking) και [Έλεγχος Αναρτημένης Στίξης](/slides/el/php-java/text-formatting/#control-hanging-punctuation).

Χρησιμοποιήστε το [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) για να μετρήσετε τις γραμμές που καταλαμβάνει μια παράγραφος μετά τη διάταξη του κειμένου, συμπεριλαμβανομένης της αυτόματης αναδίπλωσης. Αυτό είναι χρήσιμο όταν ελέγχετε το μήκος κειμένου και τη διάταξη σε πρότυπα παρουσιάσεων.

Μία παράγραφος είναι ένα στοιχείο στο [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) και μπορεί να καταλάβει πολλές απεικονισμένες γραμμές. Ένα ρητό τέλος γραμμής μέσα σε μια παράγραφο αναγκάζει νέα γραμμή χωρίς να δημιουργήσει άλλη παράγραφο. Η αυτόματη αναδίπλωση δημιουργεί γραμμές βάσει του διαθέσιμου πλάτους χωρίς να εισάγει ρητά χαρακτήρες λήξης γραμμής στο κείμενο. Επομένως η καταμέτρηση παραγράφων ή χαρακτήρων λήξης γραμμής δεν δίνει τον αριθμό των απεικονισμένων γραμμών.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα κειμένου, μετρά τις γραμμές του, στενεύει το σχήμα, και στη συνέχεια αντικαθιστά το κείμενο με μια πιο σύντομη συμβολοσειρά. Το παράδειγμα ενεργοποιεί την αναδίπλωση με το [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) και απενεργοποιεί το autofit με το [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) ώστε το πλάτος του σχήματος να ελέγχει την αναδίπλωση χωρίς αυτόματη σμίκρυνση του κειμένου ή αλλαγή μεγέθους του σχήματος. Κάθε μέτρηση χρησιμοποιεί το [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount). Οι διαστάσεις του σχήματος είναι σε σημεία. Τέλος, το παράδειγμα προσθέτει μια ακόμη παράγραφο και αθροίζει τους αριθμούς γραμμών σε όλο το πλαίσιο κειμένου.

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

Με αυτό το κείμενο και αυτές τις διαστάσεις, η στένωση του σχήματος αυξάνει τον αριθμό γραμμών, ενώ η αντικατάσταση του κειμένου με τη σύντομη συμβολοσειρά το μειώνει. Οι ακριβείς αριθμοί μπορεί να διαφέρουν ανάλογα με τη διαθεσιμότητα και αντικατάσταση γραμματοσειρών, το μέγεθος γραμματοσειράς, τα περιθώρια, την εσοχή, την αναδίπλωση και τις ρυθμίσεις autofit. Χρησιμοποιήστε τις γραμματοσειρές και τις ρυθμίσεις διάταξης που προορίζονται για το προορισμένο περιβάλλον κατά τον έλεγχο ενός προτύπου.

Ο αριθμός των γραμμών μόνο του δεν προσδιορίζει αν το κείμενο υπερβαίνει το περιέκτη του. Το διαθέσιμο ύψος, το ύψος των γραμμών, η απόσταση μεταξύ παραγράφων και γραμμών, και η συμπεριφορά του autofit επίσης παίζουν ρόλο· ακόμη και μία γραμμή μπορεί να ξεπεράσει το διαθέσιμο πλάτος όταν η αναδίπλωση είναι απενεργοποιημένη.

## **Εισαγωγή και Εξαγωγή Περιεχομένου Παραγράφου**

Χρησιμοποιήστε HTML για να εισαγάγετε κείμενο σε μια παρουσίαση ή να εξάγετε υπάρχουσες παραγράφους για χρήση εκτός αυτής. Αυτή η ενότητα δείχνει επίσης πώς να αποδώσετε μεμονωμένες παραγράφους ως εικόνες, συμπεριλαμβανομένων των παραγράφων σε κελιά πινάκων.

### **Εισαγωγή Κειμένου HTML σε Παραγράφους**

Χρησιμοποιήστε το [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) για να μετατρέψετε το σήμανση HTML σε παραγράφους και τμήματα σε ένα πλαίσιο κειμένου.

Το παράδειγμα PHP διαβάζει HTML από ένα αρχείο και περνά τη σήμανση στο [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml). Καθαρίζει την προεπιλεγμένη παράγραφο του πλαισίου κειμένου ώστε το πλαίσιο να περιέχει μόνο το εισαγόμενο περιεχόμενο. Το ορθογώνιο σχήμα αφήνει περιθώριο 10 σημείων σε κάθε πλευρά της διαφάνειας:

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

Χρησιμοποιήστε το [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml) για να εξάγετε ένα επιλεγμένο εύρος παραγράφων ως HTML. Όταν επαναχρησιμοποιείτε κείμενο παρουσίασης σε έναν ιστότοπο, μπορεί να θέλετε να διατηρήσετε την τοπική έμφαση χωρίς να μεταφέρετε τη γραμματοσειρά, το μέγεθος ή τα στυλ κουτιών κειμένου της παρουσίασης. Ορίστε το [TextToHtmlConversionOptions::setTextInheritanceLimit](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) για να ελέγξετε πόσο βαθιά ακολουθεί ο εξαγωγέας την κληρονομιά μορφοποίησης.

Κατεβάστε [το δείγμα παρουσίασης](text-inheritance.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Η πρώτη διαφάνειά του περιέχει ένα σχήμα κειμένου με το κείμενο "Inherited text; explicit red 18pt". Η είσοδος χρησιμοποιεί σκόπιμα πολλά επίπεδα μορφοποίησης:

- Το προεπιλεγμένο στυλ κειμένου της παρουσίασης παρέχει Calibri και μέγεθος 28 pt.
- Το στυλ κειμένου πρώτου επιπέδου του πλαισίου κειμένου παρέχει μπλε κείμενο και πλάγια.
- Η παράγραφος ορίζει ρητά έντονο κείμενο.
- Το δεύτερο τμήμα, "explicit red 18pt", ορίζει ρητά κόκκινο κείμενο και μέγεθος 18 pt.

Το παρακάτω πλήρες παράδειγμα εξάγει τις ίδιες παραγράφους τρεις φορές. Περνά το [TextToHtmlConversionOptions](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/) στη μέθοδο εξαγωγής και γράφει κάθε αποτέλεσμα ως ξεχωριστό αρχείο HTML UTF-8:

```php
use aspose\slides\Presentation;
use aspose\slides\TextInheritanceLimit;
use aspose\slides\TextToHtmlConversionOptions;

$presentation = new Presentation("text-inheritance.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();

            $modes = array(TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly);
            $fileNames = array("All.html", "TextBox.html", "ParagraphOnly.html");

            for ($i = 0; $i < count($modes); $i++) {
                $options = new TextToHtmlConversionOptions();
                $options->setTextInheritanceLimit($modes[$i]);

                $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), $options);
                if (file_put_contents($fileNames[$i], java_values($html)) === false) {
                    echo "The HTML file could not be written." . PHP_EOL;
                }
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

Το παραγόμενο HTML περιέχει το παρακάτω CSS για το πρώτο τμήμα, "Inherited text; ". Ο πίνακας παραθέτει τις σχετικές δηλώσεις· άλλες παραγόμενες ιδιότητες παραλείπονται για σαφήνεια.

| Αποτελέσμα | Σχετικό CSS για το πρώτο τμήμα | Εμφάνιση |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Μπλε, έντονο, πλάγιο κείμενο 28 pt σε Calibri, εφόσον η γραμματοσειρά είναι διαθέσιμη. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Μπλε, έντονο, πλάγιο κείμενο· η περιβάλλουσα σελίδα ή ο φυλλομετρητής παρέχει τη γραμματοσειρά και το μέγεθος. |
| `ParagraphOnly.html` | `font-weight:bold` | Έντονο κείμενο· η περιβάλλουσα σελίδα ή ο φυλλομετρητής παρέχει τη γραμματοσειρά, το μέγεθος, το χρώμα και το πλάγιο στυλ. |

Το δεύτερο τμήμα διατηρεί `color:#ff0000`, `font-size:18pt` και `font-weight:bold` σε όλα τα τρία αποτελέσματα. Διατηρεί επίσης το πλάγιο στυλ στα `All` και `TextBox`, αλλά όχι στο `ParagraphOnly`. Ο περιορισμός της κληρονομιάς συνεπώς δεν αφαιρεί τη μορφοποίηση που έχει οριστεί ρητά σε μια παράγραφο ή τμήμα.

Ανοίξτε τα αρχεία στον ίδιο φυλλομετρητή για να τα συγκρίνετε. Σε τις δύο περιορισμένες λειτουργίες, οι παραλειπόμενες ιδιότητες CSS επιλύονται από τα στυλ της σελίδας-προορισμού ή τα προεπιλεγμένα του φυλλομετρητή, έτσι η τελική εμφάνιση εξαρτάται από το πού χρησιμοποιείται το HTML.

### **Απόδοση Παραγράφου ως Εικόνα**

Το [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) αποδίδει απευθείας μια μεμονωμένη παράγραφο και επιστρέφει ένα [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/). Αποθηκεύστε το αποτέλεσμα σε αρχείο ή ρεύμα με το [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Δεν χρειάζεται να αποδώσετε το περιέχον σχήμα ή να περικόψετε ένα bitmap χειροκίνητα.

Το [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) μπορεί να επιστρέψει `null` εάν δεν βρεθεί η παράγραφος στη γονική της συλλογή, δεν έχει έγκυρα όρια απόδοσης ή δεν μπορεί να αποδοθεί. Ελέγξτε το αποτέλεσμα πριν το αποθηκεύσετε και απελευθερώστε την εικόνα που επιστράφηκε μετά τη χρήση.

#### **Απόδοση Παραγράφου στην Προεπιλεγμένη Κλίμακα**

Το παράδειγμα χρησιμοποιεί μια παρουσίαση με μία διαφάνεια της οποίας το πρώτο σχήμα είναι ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους.

![Το πλαίσιο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

Το παρακάτω παράδειγμα επιλέγει τη δεύτερη παράγραφο με δείκτη 1 και καλεί το [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) χωρίς παραμέτρους κλίμακας. Ελέγχει ότι το σχήμα περιέχει την απαιτούμενη παράγραφο και ότι η απόδοση επιστρέφει εικόνα πριν καλέσει το [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) για αποθήκευση σε μορφή PNG. Το μπλοκ `finally` απελευθερώνει την εικόνα μετά τη χρήση.

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

Χρησιμοποιήστε την υπερφόρτωση του [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) που δέχεται τις παραμέτρους `$scaleX` και `$scaleY` για να ορίσετε τους οριζόντιους και κάθετους παράγοντες κλίμακας. Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα, αποδίδει την παράγραφο στο πρώτο του κελί με διπλάσιο προεπιλεγμένο πλάτος και ύψος, και αποθηκεύει το αποτέλεσμα ως εικόνα PNG.

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

Ένας παράγοντας κλίμακας `1` διατηρεί αυτόν τον άξονα στο προεπιλεγμένο μέγεθος pixel. Για παράδειγμα, `2` και για τους δύο παράγοντες παράγει μια εικόνα του οποίου το πλάτος και το ύψος είναι περίπου διπλάσιο του προεπιλεγμένου, με αποτέλεσμα τέσσερις φορές περισσότερα pixel. Μεγαλύτεροι παράγοντες γενικά παράγουν πιο καθαρό κείμενο για μεγέθυνση ή εξαγωγή υψηλής ανάλυσης, αλλά επίσης αυξάνουν τη χρήση μνήμης και το μέγεθος του αρχείου. Παράγοντες κάτω από `1` παράγουν μικρότερες εικόνες με λιγότερες λεπτομέρειες. Χρησιμοποιήστε ίσους παράγοντες για να διατηρήσετε την αναλογία διαστάσεων της παραγράφου· διαφορετικοί οριζόντιοι και κάθετιοι παράγοντες τεντώνουν το αποτέλεσμα ανεξάρτητα.

Η απόδοση ενός ολόκληρου σχήματος με το [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) παραμένει χρήσιμη όταν το αποτέλεσμα πρέπει να περιλαμβάνει τη γέμιση, το πλαίσιο ή άλλο οπτικό περιεχόμενο του σχήματος. Για εικόνα μόνο με την παράγραφο, χρησιμοποιήστε το [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage).

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς την αναδίπλωση γραμμών μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Ορίστε το [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) ώστε να απενεργοποιηθεί η αναδίπλωση, έτσι οι γραμμές δεν θα σπάζουν στα άκρα του πλαισίου κειμένου.

**Πώς μπορώ να λάβω τα ακριβή όρια μιας συγκεκριμένης παραγράφου στην διαφάνεια;**

Χρησιμοποιήστε το [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) για να λάβετε το ορθογώνιο περιθώριο της παραγράφου. Το [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) παρέχει τα όρια ενός μεμονωμένου τμήματος.

**Πού ελέγχεται η στοίχιση παραγράφου (αριστερά, δεξιά, κέντρο ή πλήρης στοίχιση);**

Το [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) είναι μια ρύθμιση επιπέδου παραγράφου και εφαρμόζεται σε ολόκληρη την παράγραφο ανεξαρτήτως της μορφοποίησης των επιμέρους τμημάτων.

[Στοίχιση Γραμματοσειρών Κατά Μία Γραμμή](/slides/el/php-java/text-formatting/#align-fonts-within-a-line)

**Μπορώ να ορίσω τη γλώσσα ελέγχου για μέρος μιας παραγράφου;**

Ναι. Ορίστε το [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) για μεμονωμένα τμήματα, ώστε μια παράγραφος να μπορεί να περιέχει κείμενο σε πολλές γλώσσες.