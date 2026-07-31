---
title: Διαχείριση Παραγράφων Κειμένου PowerPoint σε PHP
linktitle: Διαχείριση Παραγράφου
type: docs
weight: 40
url: /el/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
keywords:
- προσθήκη κειμένου
- προσθήκη παραγράφου
- διαχείριση κειμένου
- διαχείριση παραγράφου
- διαχείριση σφαραγγίδας
- εσοχή παραγράφου
- εσοχή κρέμασματος
- σφαραγγίδα παραγράφου
- αριθμημένη λίστα
- λίστα με σφαραγγίδες
- ιδιότητες παραγράφου
- εισαγωγή HTML
- κείμενο σε HTML
- παράγραφος σε HTML
- παράγραφος σε εικόνα
- κείμενο σε εικόνα
- εξαγωγή παραγράφου
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Αποκτήστε έλεγχο της μορφοποίησης παραγράφων με το Aspose.Slides για PHP μέσω Java — βελτιστοποιήστε την στοίχιση, το διάστημα & το στυλ σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Η Aspose.Slides παρέχει όλες τις κλάσεις που χρειάζεστε για να εργάζεστε με κείμενα, παραγράφους και τμήματα PowerPoint.

* Η Aspose.Slides παρέχει την κλάση [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) ώστε να μπορείτε να προσθέτετε αντικείμενα που αντιπροσωπεύουν μια παράγραφο. Ένα αντικείμενο `TextFame` μπορεί να περιέχει μία ή πολλές παραγράφους (κάθε παράγραφος δημιουργείται μέσω επιστροφής του δρομέα).
* Η Aspose.Slides παρέχει την κλάση [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) ώστε να μπορείτε να προσθέτετε αντικείμενα που αντιπροσωπεύουν τμήματα. Ένα αντικείμενο `Paragraph` μπορεί να περιέχει ένα ή πολλά τμήματα (συλλογή αντικειμένων τμήματος).
* Η Aspose.Slides παρέχει την κλάση [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) ώστε να μπορείτε να προσθέτετε αντικείμενα που αντιπροσωπεύουν κείμενα και τις ιδιότητες μορφοποίησής τους.

Ένα αντικείμενο `Paragraph` είναι ικανό να διαχειρίζεται κείμενα με διαφορετικές ιδιότητες μορφοποίησης μέσω των βασικών του αντικειμένων `Portion`.

## **Προσθήκη Πολλαπλών Παραγράφων που Περιέχουν Πολλαπλά Τμήματα**

Αυτά τα βήματα σας δείχνουν πώς να προσθέσετε ένα πλαίσιο κειμένου που περιέχει 3 παραγράφους και κάθε παράγραφο να περιέχει 3 τμήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε την αναφορά της αντίστοιχης διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Λάβετε το ITextFrame που συνδέεται με το [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).
5. Δημιουργήστε δύο αντικείμενα [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) και προσθέστε τα στη συλλογή παραγράφων του [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/).
6. Δημιουργήστε τρία αντικείμενα [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) για κάθε νέο `Paragraph` (δύο αντικείμενα Portion για την προεπιλεγμένη Paragraph) και προσθέστε κάθε αντικείμενο `Portion` στη συλλογή τμημάτων του αντίστοιχου `Paragraph`.
7. Ορίστε κάποιο κείμενο για κάθε τμήμα.
8. Εφαρμόστε τις προτιμώμενες ιδιότητες μορφοποίησης σε κάθε τμήμα χρησιμοποιώντας τις ιδιότητες μορφοποίησης που εκτίθενται από το αντικείμενο `Portion`.
9. Αποθηκεύστε την τροποποιημένη παρουσία.

```php
# Δημιουργία της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
$pres = new Presentation();
try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθήκη AutoShape τύπου Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Πρόσβαση στο TextFrame του AutoShape
    $tf = $ashp->getTextFrame();
    # Δημιουργία Παραγράφων και Τμημάτων με διαφορετικές μορφές κειμένου
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # Αποθήκευση του PPTX στο δίσκο
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Διαχείριση Κουκίδων Παραγράφων**

Οι λίστας με κουκίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποδοτικά. Οι παράγραφοι με κουκίδες είναι πάντα πιο εύκολες στην ανάγνωση και κατανόηση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε την αναφορά της αντίστοιχης διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στην επιλεγμένη διαφάνεια.
4. Αποκτήστε το [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του auto shape.
5. Καταργήστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε την πρώτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/).
7. Ορίστε τον `Type` της σφαραγγίδας για την παράγραφο σε `Symbol` και ορίστε τον χαρακτήρα της σφαραγγίδας.
8. Ορίστε το `Text` της παραγράφου.
9. Ορίστε το `Indent` της παραγράφου για τη σφαραγγίδα.
10. Ορίστε ένα χρώμα για τη σφαραγγίδα.
11. Ορίστε το ύψος της σφαραγγίδας.
12. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του `TextFrame`.
13. Προσθέστε τη δεύτερη παράγραφο και επαναλάβετε τη διαδικασία όπως περιγράφεται στα βήματα 7 έως 13.
14. Αποθηκεύστε την παρουσία.

```php
# Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
$pres = new Presentation();
try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθήκη και πρόσβαση στο Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Πρόσβαση στο πλαίσιο κειμένου του autoshape
    $txtFrm = $aShp->getTextFrame();
    # Αφαίρεση της προεπιλεγμένης παραγράφου
    $txtFrm->getParagraphs()->removeAt(0);
    # Δημιουργία παραγράφου
    $para = new Paragraph();
    # Ορισμός στυλ σφαραγγίδας παραγράφου και συμβόλου
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Ορισμός κειμένου για την παράγραφο
    $para->setText("Welcome to Aspose.Slides");
    # Ορισμός εσοχής σφαραγγίδας
    $para->getParagraphFormat()->setIndent(25);
    # Ορισμός χρώματος σφαραγγίδας
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// ορίζει το IsBulletHardColor σε true για χρήση δικού χρώματος σφαραγγίδας

    # Ορισμός ύψους σφαραγγίδας
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Προσθήκη παραγράφου στο πλαίσιο κειμένου
    $txtFrm->getParagraphs()->add($para);
    # Δημιουργία δεύτερης παραγράφου
    $para2 = new Paragraph();
    # Ορισμός τύπου σφαραγγίδας παραγράφου και στυλ
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Προσθήκη κειμένου παραγράφου
    $para2->setText("This is numbered bullet");
    # Ορισμός εσοχής σφαραγγίδας
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// ορίζει το IsBulletHardColor σε true για χρήση δικού χρώματος σφαραγγίδας

    # Ορισμός ύψους σφαραγγίδας
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Προσθήκη παραγράφου στο πλαίσιο κειμένου
    $txtFrm->getParagraphs()->add($para2);
    # Αποθήκευση της τροποποιημένης παρουσίασης
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Διαχείριση Σφαραγγιών Εικόνας**

Οι λίστες με σφαραγγίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποδοτικά. Οι παράγραφοι με εικόνα είναι εύκολο να διαβαστούν και να κατανοηθούν.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε την αναφορά της αντίστοιχης διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Αποκτήστε το [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του auto shape.
5. Καταργήστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήсте την πρώτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/).
7. Φορτώστε την εικόνα στο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/).
8. Ορίστε τον τύπο σφαραγγίδας σε [Picture](https://reference.aspose.com/slides/el/php-java/aspose.slides/bullettype/#Picture) και ορίστε την εικόνα.
9. Ορίστε το `Text` της Παραγράφου.
10. Ορίστε το `Indent` της Παραγράφου για τη σφαραγγίδα.
11. Ορίστε ένα χρώμα για τη σφαραγγίδα.
12. Ορίστε ένα ύψος για τη σφαραγγίδα.
13. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του `TextFrame`.
14. Προσθέστε τη δεύτερη παράγραφο και επαναλάβετε τη διαδικασία βάσει των προηγούμενων βημάτων.
15. Αποθηκεύστε την τροποποιημένη παρουσία.

```php
# Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
$presentation = new Presentation();
try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $slide = $presentation->getSlides()->get_Item(0);
    # Δημιουργεί την εικόνα για τις σφαραγγίδες
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Προσθέτει και αποκτά πρόσβαση στο Autoshape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Πρόσβαση στο πλαίσιο κειμένου του autoshape
    $textFrame = $autoShape->getTextFrame();
    # Αφαίρεση της προεπιλεγμένης παραγράφου
    $textFrame->getParagraphs()->removeAt(0);
    # Δημιουργία νέας παραγράφου
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Ορίζει το στυλ σφαραγγίδας παραγράφου και την εικόνα
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Ορίζει το ύψος της σφαραγγίδας
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Προσθέτει την παράγραφο στο πλαίσιο κειμένου
    $textFrame->getParagraphs()->add($paragraph);
    # Αποθηκεύει την παρουσίαση ως αρχείο PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Αποθηκεύει την παρουσίαση ως αρχείο PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Διαχείριση Πολυεπίπεδων Σφαραγγιών**

Οι λίστες με σφαραγγίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποδοτικά. Οι πολυεπίπεδες σφαραγγίδες είναι εύκολο να διαβαστούν και να κατανοηθούν.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε την αναφορά της αντίστοιχης διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη νέα διαφάνεια.
4. Αποκτήστε το [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του auto shape.
5. Καταργήστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε την πρώτη παράγραφο μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) και ορίστε το βάθος στην τιμή 0.
7. Δημιουργήστε τη δεύτερη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το βάθος στην τιμή 1.
8. Δημιουργήστε την τρίτη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το βάθος στην τιμή 2.
9. Δημιουργήστε την τέταρτη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το βάθος στην τιμή 3.
10. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του `TextFrame`.
11. Αποθηκεύστε την τροποποιημένη παρουσία.

```php
# Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
$pres = new Presentation();
try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθέτει και αποκτά πρόσβαση στο Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Πρόσβαση στο πλαίσιο κειμένου του δημιουργημένου autoshape
    $text = $aShp->addTextFrame("");
    # Καθαρίζει την προεπιλεγμένη παράγραφο
    $text->getParagraphs()->clear();
    # Προσθέτει τη πρώτη παράγραφο
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ορίζει το επίπεδο σφαραγγίδας
    $para1->getParagraphFormat()->setDepth(0);
    # Προσθέτει τη δεύτερη παράγραφο
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ορίζει το επίπεδο σφαραγγίδας
    $para2->getParagraphFormat()->setDepth(1);
    # Προσθέτει την τρίτη παράγραφο
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ορίζει το επίπεδο σφαραγγίδας
    $para3->getParagraphFormat()->setDepth(2);
    # Προσθέτει την τέταρτη παράγραφο
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ορίζει το επίπεδο σφαραγγίδας
    $para4->getParagraphFormat()->setDepth(3);
    # Προσθέτει τις παραγράφους στη συλλογή
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Αποθηκεύει την παρουσίαση ως αρχείο PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Διαχείριση Παραγράφου με Προσαρμοσμένη Αριθμημένη Λίστα**

Η κλάση [BulletFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/) παρέχει τη μέθοδο [setNumberedBulletStartWith](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) και άλλες που σας επιτρέπουν να διαχειρίζεστε παραγράφους με προσαρμοσμένη αρίθμηση ή μορφοποίηση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε τη διαφάνεια που περιέχει την παράγραφο.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Αποκτήστε το [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του auto shape.
5. Καταργήστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε την πρώτη παράγραφο μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) και ορίστε το [NumberedBulletStartWith](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) σε 2.
7. Δημιουργήστε τη δεύτερη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το `NumberedBulletStartWith` σε 3.
8. Δημιουργήστε την τρίτη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το `NumberedBulletStartWith` σε 7.
9. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του `TextFrame`.
10. Αποθηκεύστε την τροποποιημένη παρουσία.

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Πρόσβαση στο πλαίσιο κειμένου του δημιουργημένου autoshape
    $textFrame = $shape->getTextFrame();
    # Αφαιρεί την προεπιλεγμένη υπάρχουσα παράγραφο
    $textFrame->getParagraphs()->removeAt(0);
    # Πρώτη λίστα
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Ορισμός Εσοχής Πρώτης Γραμμής για Παράγραφο**

Χρησιμοποιήστε τη μέθοδο [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setindent/) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η μέθοδος μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετακινεί την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setmarginleft/) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setindent/) όταν χρειάζεται να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δημιουργεί πολλαπλές παραγράφους και εφαρμόζει διαφορετικές τιμές εσοχής για να δείξει πώς η εσοχή της πρώτης γραμμής επηρεάζει τη διάταξη της παραγράφου.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε τη διαφάνεια-στόχο.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε αρκετές παραγράφους και ορίστε διαφορετικές τιμές [Indent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setindent/) γι' αυτές.
6. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσία.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
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

## **Ορισμός Εσοχής Κρέμασματος για Παράγραφο**

Μια εσοχή κρέμασματος είναι μια διάταξη παραγράφου στην οποία η πρώτη γραμμή ξεκινά αριστερά των υπολοίπων γραμμών. Στο Aspose.Slides, δημιουργείτε αυτό το αποτέλεσμα με τη μέθοδο [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setindent/). Ορίστε την εσοχή σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setmarginleft/) ορίζει τη θέση αριστερά του σώματος της παραγράφου, ενώ το [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setindent/) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε εσοχή κρέμασματος, ορίστε μια θετική τιμή `MarginLeft` και μια αρνητική τιμή `Indent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, αναφορές, εγγραφές γλωσσάριου και άλλες παραγράφους όπου οι αναδιπλωμένες γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου αντί κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε τη διαφάνεια-στόχο.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε παραγράφους και ορίστε μια θετική τιμή [MarginLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setmarginleft/) για κάθε παράγραφο.
6. Ορίστε μια αρνητική τιμή [Indent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setindent/) για να δημιουργήσετε το εφέ εσοχής κρέμασματος.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσία.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
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

![Η εσοχή κρέμασματος των παραγράφων](hanging_indent.png)

## **Διαχείριση Ιδιοτήτων Τερματισμού Παραγράφου**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Λάβετε την αναφορά της διαφάνειας που περιέχει την παράγραφο μέσω της θέσης της.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) με δύο παραγράφους στο ορθογώνιο.
5. Ορίστε το ύψος γραμματοσειράς και το τύπο γραμματοσειράς για τις παραγράφους.
6. Ορίστε τις ιδιότητες End για τις παραγράφους.
7. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Εισαγωγή HTML Κειμένου σε Παραγράφους**

Η Aspose.Slides παρέχει βελτιωμένη υποστήριξη για εισαγωγή HTML κειμένου σε παραγράφους.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Αποκτήστε την αναφορά της αντίστοιχης διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε και αποκτήστε πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του `AutoShape`.
5. Καταργήστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Διαβάστε το αρχείο HTML προέλευσης με έναν TextReader.
7. Δημιουργήστε την πρώτη παράγραφο μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/).
8. Προσθέστε το περιεχόμενο του HTML αρχείου από τον αναγόμενο TextReader στη [ParagraphCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphcollection/) του TextFrame.
9. Αποθηκεύστε την τροποποιημένη παρουσία.

```php
# Δημιουργεί κενή παρουσίαση
$pres = new Presentation();
try {
    # Πρόσβαση στην προεπιλεγμένη πρώτη διαφάνεια της παρουσίασης
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθήκη AutoShape για τοποθέτηση του περιεχομένου HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Προσθήκη πλαισίου κειμένου στο σχήμα
    $ashape->addTextFrame("");
    # Καθαρισμός όλων των παραγράφων στο προστεθέν πλαίσιο κειμένου
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Φόρτωση του αρχείου HTML χρησιμοποιώντας stream reader
    $tr = new StreamReader("file.html");
    # Προσθήκη κειμένου από το stream reader HTML στο πλαίσιο κειμένου
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Αποθήκευση της παρουσίασης
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Εξαγωγή Κειμένου Παραγράφου σε HTML**

Η Aspose.Slides παρέχει βελτιωμένη υποστήριξη για εξαγωγή κειμένων (που περιέχονται σε παραγράφους) σε HTML.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και φορτώστε την επιθυμητή παρουσία.
2. Αποκτήστε την αναφορά της αντίστοιχης διαφάνειας μέσω του δείκτη της.
3. Αποκτήστε το σχήμα που περιέχει το κείμενο που θα εξαχθεί σε HTML.
4. Αποκτήστε το [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του σχήματος.
5. Δημιουργήστε μια παρουσία του `StreamWriter` και προσθέστε το νέο αρχείο HTML.
6. Καθορίστε έναν αρχικό δείκτη στο StreamWriter και εξάγετε τις επιθυμητές παραγράφους.

```php
# Φόρτωση του αρχείου παρουσίασης
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Πρόσβαση στην προεπιλεγμένη πρώτη διαφάνεια της παρουσίασης
    $slide = $pres->getSlides()->get_Item(0);
    # Επιθυμητός δείκτης
    $index = 0;
    # Πρόσβαση στο προστεθέν σχήμα
    $ashape = $slide->getShapes()->get_Item($index);
    # Δημιουργία αρχείου εξόδου HTML
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Εξαγωγή της πρώτης παραγράφου ως HTML
    # Εγγραφή δεδομένων παραγράφων σε HTML παρέχοντας τον αρχικό δείκτη παραγράφου, τον συνολικό αριθμό παραγράφων προς αντιγραφή
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Αποθήκευση Παραγράφου ως Εικόνα**

Σε αυτήν την ενότητα, θα εξερευνήσουμε δύο παραδείγματα που δείχνουν πώς να αποθηκεύσετε μια παράγραφο κειμένου, που αναπαρίσταται από την κλάση [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/), ως εικόνα. Και τα δύο παραδείγματα περιλαμβάνουν την απόκτηση της εικόνας ενός σχήματος που περιέχει την παράγραφο χρησιμοποιώντας τις μεθόδους `getImage` από την κλάση [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/), τον υπολογισμό των συνόρων της παραγράφου μέσα στο σχήμα και την εξαγωγή της ως bitmap εικόνα. Αυτές οι προσεγγίσεις σας επιτρέπουν να εξάγετε συγκεκριμένα τμήματα του κειμένου από παρουσιάσεις PowerPoint και να τα αποθηκεύσετε ως ξεχωριστές εικόνες, οι οποίες μπορούν να είναι χρήσιμες για περαιτέρω χρήση σε διάφορα σενάρια.

![Το πλαίσιο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

**Παράδειγμα 1**

Σε αυτό το παράδειγμα, λαμβάνουμε τη δεύτερη παράγραφο ως εικόνα. Για να το κάνουμε αυτό, εξάγουμε την εικόνα του σχήματος από την πρώτη διαφάνεια της παρουσίασης και μετά υπολογίζουμε τα όρια της δεύτερης παραγράφου στο πλαίσιο κειμένου του σχήματος. Στη συνέχεια, η παράγραφος επανασχεδιάζεται σε μια νέα bitmap εικόνα, η οποία αποθηκεύεται σε μορφή PNG. Αυτή η μέθοδος είναι ιδιαίτερα χρήσιμη όταν χρειάζεται να αποθηκεύσετε μια συγκεκριμένη παράγραφο ως ξεχωριστή εικόνα διατηρώντας τις ακριβείς διαστάσεις και τη μορφοποίηση του κειμένου.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Αποθήκευση του σχήματος στη μνήμη ως bitmap.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Δημιουργία bitmap σχήματος από τη μνήμη.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Υπολογισμός των ορίων της δεύτερης παραγράφου.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Υπολογισμός των συντεταγμένων και του μεγέθους για την εικόνα εξόδου (μεγαλύτερο ελάχιστο μέγεθος - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Κόψιμο του bitmap του σχήματος ώστε να ληφθεί μόνο το bitmap της παραγράφου.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Το αποτέλεσμα:

![Η εικόνα της παραγράφου](paragraph_to_image_output.png)

**Παράδειγμα 2**

Σε αυτό το παράδειγμα, επεκτείνουμε την προηγούμενη προσέγγιση προσθέτοντας παράγοντες κλιμάκωσης στην εικόνα της παραγράφου. Το σχήμα εξάγεται από την παρουσίαση και αποθηκεύεται ως εικόνα με παράγοντα κλιμάκωσης `2`. Αυτό επιτρέπει μεγαλύτερη ανάλυση κατά την εξαγωγή της παραγράφου. Τα όρια της παραγράφου υπολογίζονται λαμβάνοντας υπόψη την κλίμακα. Η κλιμάκωση μπορεί να είναι ιδιαίτερα χρήσιμη όταν απαιτείται πιο λεπτομερής εικόνα, για παράδειγμα για χρήση σε έντυπα υψηλής ποιότητας.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Αποθήκευση του σχήματος στη μνήμη ως bitmap με κλιμάκωση.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Δημιουργία bitmap σχήματος από τη μνήμη.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Υπολογισμός των ορίων της δεύτερης παραγράφου.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Υπολογισμός των συντεταγμένων και του μεγέθους για την εικόνα εξόδου (ελάχιστο μέγεθος - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Κοπή του bitmap του σχήματος ώστε να ληφθεί μόνο το bitmap της παραγράφου.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς τη αναδίπλωση γραμμών μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Χρησιμοποιήστε τη ρύθμιση αναδίπλωσης του πλαισίου κειμένου ([setWrapText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/setwraptext/)) για να απενεργοποιήσετε την αναδίπλωση ώστε οι γραμμές να μην σπάζουν στα όρια του πλαισίου.

**Πώς μπορώ να λάβω τα ακριβή όρια μιας συγκεκριμένης παραγράφου στην διαφάνεια;**

Μπορείτε να ανακτήσετε το ορθογώνιο περιθώριο της παραγράφου (και ακόμη ενός μεμονωμένου τμήματος) ώστε να γνωρίζετε τη ακριβή θέση και μέγεθός του στη διαφάνεια.

**Πού ελέγχεται η στοίχιση της παραγράφου (αριστερά/δεξιά/κέντρο/πλήρης);**

Η [Alignment](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setalignment/) είναι μια ρύθμιση επιπέδου παραγράφου στο [ParagraphFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/); εφαρμόζεται σε όλη την παράγραφο ανεξαρτήτως της μορφοποίησης των μεμονωμένων τμημάτων.

**Μπορώ να ορίσω γλώσσα ελέγχου ορθογραφίας μόνο για μέρος μιας παραγράφου (π.χ. μια λέξη);**

Ναι. Η γλώσσα ορίζεται στο επίπεδο του τμήματος ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLanguageId)), έτσι μπορεί να υπάρχουν πολλαπλές γλώσσες μέσα σε μία παράγραφο.