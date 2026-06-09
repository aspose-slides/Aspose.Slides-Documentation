---
title: "Διαχείριση Κειμένου Παραγράφων PowerPoint σε PHP"
linktitle: "Διαχείριση Παραγράφου"
type: docs
weight: 40
url: /el/php-java/manage-paragraph/
keywords:
- "προσθήκη κειμένου"
- "προσθήκη παραγράφου"
- "διαχείριση κειμένου"
- "διαχείριση παραγράφου"
- "διαχείριση κουκίδας"
- "εσοχή παραγράφου"
- "αναρτημένη εσοχή"
- "κουκίδα παραγράφου"
- "αριθμημένη λίστα"
- "λίστα με κουκίδες"
- "ιδιότητες παραγράφου"
- "εισαγωγή HTML"
- "κείμενο σε HTML"
- "παράγραφος σε HTML"
- "παράγραφος σε εικόνα"
- "κείμενο σε εικόνα"
- "εξαγωγή παραγράφου"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "PHP"
- "Aspose.Slides"
description: "Μάθετε να διαμορφώνετε παραγράφες με το Aspose.Slides για PHP μέσω Java — βελτιστοποιήστε την στοίχηση, το κενό και το στυλ σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Το Aspose.Slides παρέχει όλες τις κλάσεις που χρειάζεστε για να εργαστείτε με κείμενα PowerPoint, παραγράφους και τμήματα.

* Το Aspose.Slides παρέχει την κλάση [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) που σας επιτρέπει να προσθέσετε αντικείμενα που αντιπροσωπεύουν μια παράγραφο. Ένα αντικείμενο `TextFame` μπορεί να περιέχει μία ή πολλαπλές παραγράφους (κάθε παράγραφος δημιουργείται μέσω μιας αλλαγής γραμμής).
* Το Aspose.Slides παρέχει την κλάση [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) που σας επιτρέπει να προσθέσετε αντικείμενα που αντιπροσωπεύουν τμήματα. Ένα αντικείμενο `Paragraph` μπορεί να περιέχει ένα ή πολλαπλά τμήματα (συλλογή αντικειμένων τμημάτων).
* Το Aspose.Slides παρέχει την κλάση [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) που σας επιτρέπει να προσθέσετε αντικείμενα που αντιπροσωπεύουν κείμενα και τις ιδιότητες μορφοποίησής τους.

Ένα αντικείμενο `Paragraph` είναι σε θέση να διαχειρίζεται κείμενα με διαφορετικές ιδιότητες μορφοποίησης μέσω των υποκείμενων αντικειμένων `Portion`.

## **Προσθήκη Πολλαπλών Παραγράφων που Περιέχουν Πολλαπλά Τμήματα**

These steps show you how to add a text frame containing 3 paragraphs and each paragraph containing 3 portions:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πρόσβαση στην αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Αποκτήστε το ITextFrame που σχετίζεται με το [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/).
5. Δημιουργήστε δύο αντικείμενα [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) και προσθέστε τα στη συλλογή παραγράφων του [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/).
6. Δημιουργήστε τρία αντικείμενα [Portion](https://reference.aspose.com/slides/el/php-java/aspose.slides/portion/) για κάθε νέο `Paragraph` (δύο αντικείμενα Portion για την προεπιλεγμένη Paragraph) και προσθέστε κάθε αντικείμενο `Portion` στη συλλογή τμημάτων του αντίστοιχου `Paragraph`.
7. Ορίστε κάποιο κείμενο για κάθε τμήμα.
8. Εφαρμόστε τις προτιμώμενες μορφοποιητικές ιδιότητες σε κάθε τμήμα χρησιμοποιώντας τις ιδιότητες μορφοποίησης που εκτίθενται από το αντικείμενο `Portion`.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```php
# Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο PPTX
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
    # Αποθήκευση PPTX στο δίσκο
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Διαχείριση Κουκίδων Παραγράφων**

Bullet lists help you to organize and present information quickly and efficiently. Bulleted paragraphs are always easier to read and understand.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πρόσβαση στην αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στην επιλεγμένη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του AutoShape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/).
7. Ορίστε τον `Type` της κουκίδας για την παράγραφο σε `Symbol` και ορίστε το χαρακτήρα της κουκίδας.
8. Ορίστε το `Text` της παραγράφου.
9. Ορίστε το `Indent` της παραγράφου για την κουκίδα.
10. Ορίστε χρώμα για την κουκίδα.
11. Ορίστε ύψος για την κουκίδα.
12. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του `TextFrame`.
13. Προσθέστε τη δεύτερη παράγραφο και επαναλάβετε τη διαδικασία των βημάτων 7 έως 12.
14. Αποθηκεύστε την παρουσίαση.

```php
# Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει αρχείο PPTX
$pres = new Presentation();
try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθέτει και προσπελάζει το AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Πρόσβαση στο πλαίσιο κειμένου του AutoShape
    $txtFrm = $aShp->getTextFrame();
    # Αφαίρεση της προεπιλεγμένης παραγράφου
    $txtFrm->getParagraphs()->removeAt(0);
    # Δημιουργία παραγράφου
    $para = new Paragraph();
    # Ορίζει το στυλ και το σύμβολο της κουκίδας παραγράφου
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Ορίζει κείμενο παραγράφου
    $para->setText("Welcome to Aspose.Slides");
    # Ορίζει την εσοχή της κουκίδας
    $para->getParagraphFormat()->setIndent(25);
    # Ορίζει το χρώμα της κουκίδας
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// ορίζει IsBulletHardColor σε true για χρήση προσαρμοσμένου χρώματος κουκίδας

    # Ορίζει το ύψος της κουκίδας
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Προσθήκη παραγράφου στο πλαίσιο κειμένου
    $txtFrm->getParagraphs()->add($para);
    # Δημιουργία δεύτερης παραγράφου
    $para2 = new Paragraph();
    # Ορίζει τύπο και στυλ κουκίδας παραγράφου
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Προσθέτει κείμενο παραγράφου
    $para2->setText("This is numbered bullet");
    # Ορίζει την εσοχή της κουκίδας
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// ορίζει IsBulletHardColor σε true για χρήση προσαρμοσμένου χρώματος κουκίδας

    # Ορίζει το ύψος της κουκίδας
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Προσθήκη παραγράφου στο πλαίσιο κειμένου
    $txtFrm->getParagraphs()->add($para2);
    # Αποθηκεύει την τροποποιημένη παρουσίαση
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Διαχείριση Κουκίδων Εικόνας**

Bullet lists help you to organize and present information quickly and efficiently. Picture paragraphs are easy to read and understand.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πρόσβαση στην αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του AutoShape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/).
7. Φορτώστε την εικόνα στο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/).
8. Ορίστε τον τύπο της κουκίδας σε [Picture](https://reference.aspose.com/slides/el/php-java/aspose.slides/bullettype/#Picture) και ορίστε την εικόνα.
9. Ορίστε το `Text` της Paragraph.
10. Ορίστε το `Indent` της Paragraph για την κουκίδα.
11. Ορίστε χρώμα για την κουκίδα.
12. Ορίστε ύψος για την κουκίδα.
13. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του `TextFrame`.
14. Προσθέστε τη δεύτερη παράγραφο και επαναλάβετε τη διαδικασία βάσει των προηγούμενων βημάτων.
15. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```php
# Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει αρχείο PPTX
$presentation = new Presentation();
try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $slide = $presentation->getSlides()->get_Item(0);
    # Δημιουργεί την εικόνα για τις κουκίδες
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Προσθέτει και προσπελάζει το AutoShape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Πρόσβαση στο πλαίσιο κειμένου του AutoShape
    $textFrame = $autoShape->getTextFrame();
    # Αφαίρεση της προεπιλεγμένης παραγράφου
    $textFrame->getParagraphs()->removeAt(0);
    # Δημιουργία νέας παραγράφου
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Ορίζει το στυλ κουκίδας παραγράφου και την εικόνα
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Ορίζει το ύψος της κουκίδας
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Προσθήκη παραγράφου στο πλαίσιο κειμένου
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

## **Διαχείριση Πολυεπίπεδων Κουκίδων**

Bullet lists help you to organize and present information quickly and efficiently. Multilevel bullets are easy to read and understand.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πρόσβαση στην αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στην νέα διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του AutoShape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) και ορίστε το βάθος σε 0.
7. Δημιουργήστε το δεύτερο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 1.
8. Δημιουργήστε το τρίτο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 2.
9. Δημιουργήστε το τέταρτο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 3.
10. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του `TextFrame`.
11. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```php
# Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει αρχείο PPTX
$pres = new Presentation();
try {
    # Πρόσβαση στην πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθέτει και προσπελάζει το AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Πρόσβαση στο πλαίσιο κειμένου του δημιουργημένου AutoShape
    $text = $aShp->addTextFrame("");
    # Αφαιρεί την προεπιλεγμένη παράγραφο
    $text->getParagraphs()->clear();
    # Προσθήκη της πρώτης παραγράφου
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ορίζει το επίπεδο της κουκίδας
    $para1->getParagraphFormat()->setDepth(0);
    # Προσθήκη της δεύτερης παραγράφου
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ορίζει το επίπεδο της κουκίδας
    $para2->getParagraphFormat()->setDepth(1);
    # Προσθήκη της τρίτης παραγράφου
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ορίζει το επίπεδο της κουκίδας
    $para3->getParagraphFormat()->setDepth(2);
    # Προσθήκη της τέταρτης παραγράφου
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ορίζει το επίπεδο της κουκίδας
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

The [BulletFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/) class provides the [setNumberedBulletStartWith](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) method and others that allow you to manage paragraphs with custom numbering or formatting.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πρόσβαση στη διαφάνεια που περιέχει την παράγραφο.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του AutoShape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) και ορίστε το [NumberedBulletStartWith](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) σε 2.
7. Δημιουργήστε το δεύτερο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το `NumberedBulletStartWith` σε 3.
8. Δημιουργήστε το τρίτο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το `NumberedBulletStartWith` σε 7.
9. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του `TextFrame`.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

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

Use the [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setindent/) method to control the first-line indent of a paragraph. This method moves only the first line relative to the paragraph's left margin. A positive value shifts the first line to the right, while the remaining lines stay aligned to the paragraph body.

Use [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setmarginleft/) when you need to move the whole paragraph. Use [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setindent/) when you need to move only the first line.

The example below creates several paragraphs and applies different indent values to demonstrate how the first-line indent affects paragraph layout.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πρόσβαση στη στοχευμένη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε πολλές παραγράφους και ορίστε διαφορετικές τιμές [Indent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setindent/) για αυτές.
6. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

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

## **Ορισμός Αναρτημένης Εσοχής για Παράγραφο**

A hanging indent is a paragraph layout in which the first line starts to the left of the remaining lines. In Aspose.Slides, you create this effect with the [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setindent/) method. Set the indent to a negative value to move the first line to the left relative to the paragraph body.

In practice, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setmarginleft/) defines the left position of the paragraph body, and [ParagraphFormat::setIndent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setindent/) defines the position of the first line relative to that margin. To create a hanging indent, set a positive `MarginLeft` value and a negative `Indent` value.

This formatting is useful for bibliographies, references, glossary entries, and other paragraphs where wrapped lines must align under the paragraph body rather than under the first character of the first line.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πρόσβαση στη στοχευμένη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε παραγράφους και ορίστε μια θετική τιμή [MarginLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setmarginleft/) για κάθε παράγραφο.
6. Ορίστε μια αρνητική τιμή [Indent](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setindent/) για να δημιουργήσετε το εφέ της αναρτημένης εσοχής.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

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

![Η αναρτημένη εσοχή των παραγράφων](hanging_indent.png)

## **Διαχείριση Ιδιοτήτων Τερματισμού Παραγράφου**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Λάβετε την αναφορά για τη διαφάνεια που περιέχει την παράγραφο μέσω της θέσης της.
1. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Προσθέστε ένα [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) με δύο παραγράφους στο Rectangle.
1. Ορίστε το ύψος της γραμματοσειράς και τον τύπο γραμματοσειράς για τις παραγράφους.
1. Ορίστε τις ιδιότητες End για τις παραγράφους.
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

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

## **Εισαγωγή Κειμένου HTML σε Παραγράφους**

Aspose.Slides provides enhanced support for importing HTML text into paragraphs.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Πρόσβαση στην αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε και αποκτήστε πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του AutoShape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Διαβάστε το αρχείο HTML πηγής σε έναν TextReader.
7. Δημιουργήστε το πρώτο αντικείμενο παραγράφου μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/).
8. Προσθέστε το περιεχόμενο του αρχείου HTML από το TextReader στην [ParagraphCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphcollection/) του TextFrame.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```php
# Δημιουργία κενής παρουσίασης
$pres = new Presentation();
try {
    # Πρόσβαση στην προεπιλεγμένη πρώτη διαφάνεια της παρουσίασης
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθήκη AutoShape για τη φιλοξενία του HTML περιεχομένου
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Προσθήκη πλαισίου κειμένου στο σχήμα
    $ashape->addTextFrame("");
    # Καθαρισμός όλων των παραγράφων στο προστεθέν πλαίσιο κειμένου
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Φόρτωση του αρχείου HTML χρησιμοποιώντας StreamReader
    $tr = new StreamReader("file.html");
    # Προσθήκη κειμένου από το StreamReader HTML στο πλαίσιο κειμένου
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Αποθήκευση παρουσίασης
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Εξαγωγή Κειμένου Παραγράφου σε HTML**

Aspose.Slides provides enhanced support for exporting texts (contained in paragraphs) to HTML.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) και φορτώστε την επιθυμούν παρουσίαση.
2. Πρόσβαση στην αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Πρόσβαση στο σχήμα που περιέχει το κείμενο που θα εξαχθεί σε HTML.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) του σχήματος.
5. Δημιουργήστε μια εμφάνιση `StreamWriter` και προσθέστε το νέο αρχείο HTML.
6. Παρέχετε έναν αρχικό δείκτη στο StreamWriter και εξαχθείτε τις προτιμώμενες παραγράφους.

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
    # Εγγραφή δεδομένων παραγράφων σε HTML με παροχή δείκτη έναρξης παραγράφου και συνολικού αριθμού παραγράφων προς αντιγραφή
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

In this section, we will explore two examples that demonstrate how to save a text paragraph, represented by the [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) class, as an image. Both examples include obtaining the image of a shape containing the paragraph using the `getImage` methods from the [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) class, calculating the bounds of the paragraph within the shape, and exporting it as a bitmap image. These approaches allow you to extract specific parts of the text from PowerPoint presentations and save them as separate images, which can be useful for further use in various scenarios.

Let's assume we have a presentation file called sample.pptx with one slide, where the first shape is a text box containing three paragraphs.

![Το πλαίσιο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

**Example 1**

In this example, we obtain the second paragraph as an image. To do this, we extract the image of the shape from the first slide of the presentation and then calculate the bounds of the second paragraph in the shape's text frame. The paragraph is then redrawn onto a new bitmap image, which is saved in PNG format. This method is especially useful when you need to save a specific paragraph as a separate image while preserving the exact dimensions and formatting of the text.

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

    // Υπολογισμός των συντεταγμένων και του μεγέθους για την εικόνα εξόδου (ελάχιστο μέγεθος - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Περικοπή του bitmap σχήματος ώστε να ληφθεί μόνο το bitmap της παραγράφου.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

The result:

![Το εικόνα της παραγράφου](paragraph_to_image_output.png)

**Example 2**

In this example, we extend the previous approach by adding scaling factors to the paragraph image. The shape is extracted from the presentation and saved as an image with a scaling factor of `2`. This allows for a higher resolution output when exporting the paragraph. The paragraph bounds are then calculated considering the scale. Scaling can be particularly useful when a more detailed image is needed, for example, for use in high-quality printed materials.

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

    // Περικοπή του bitmap σχήματος ώστε να ληφθεί μόνο το bitmap της παραγράφου.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω πλήρως την αναδίπλωση γραμμών μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Χρησιμοποιήστε τη ρύθμιση αναδίπλωσης του πλαισίου κειμένου ([setWrapText](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/setwraptext/)) για να απενεργοποιήσετε την αναδίπλωση ώστε οι γραμμές να μην σπάνε στα άκρα του πλαισίου.

**Πώς μπορώ να λάβω τις ακριβείς διαστάσεις στην διαφάνεια ενός συγκεκριμένου παραγράφου;**

Μπορείτε να ανακτήσετε το ορθογώνιο περιγράμματα του παραγράφου (και ακόμη και ενός μεμονωμένου τμήματος) για να γνωρίζετε τη συγκεκριμένη θέση και το μέγεθός του στην διαφάνεια.

**Πού ελέγχεται η στοίχηση της παραγράφου (αριστερά/δεξιά/κέντρο/στοίχωση);**

[Alignment](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/setalignment/) είναι ρύθμιση επιπέδου παραγράφου στο [ParagraphFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/); εφαρμόζεται σε ολόκληρη την παράγραφο ανεξαρτήτως μορφοποίησης επιμέρους τμημάτων.

**Μπορώ να ορίσω γλώσσα ελέγχου ορθογραφίας μόνο για ένα τμήμα της παραγράφου (π.χ. μια λέξη);**

Ναι. Η γλώσσα ορίζεται σε επίπεδο τμήματος ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseportionformat/#setLanguageId)), έτσι ώστε να μπορούν να συνυπάρχουν πολλαπλές γλώσσες σε μια ενιαία παράγραφο.