---
title: Διαχείριση λιστών με κουκκίδες και αριθμημένων λιστών σε παρουσιάσεις χρησιμοποιώντας PHP
linktitle: Διαχείριση λιστών
type: docs
weight: 60
url: /el/php-java/manage-lists/
keywords:
- κουκκίδα
- λίστα με κουκκίδες
- αριθμημένη λίστα
- κουκκίδα συμβόλου
- κουκκίδα εικόνας
- προσαρμοσμένη κουκκίδα
- πολυεπίπεδη λίστα
- δημιουργία κουκκίδας
- προσθήκη κουκκίδας
- προσθήκη λίστας
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε λίστες με κουκκίδες, εικόνες, πολυεπίπεδες και αριθμημένες λίστες σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides for PHP via Java σάς επιτρέπει να δημιουργείτε και να μορφοποιείτε λίστες με κουκκίδες και αριθμημένες λίστες σε PowerPoint και OpenDocument παρουσιάσεις. Ένα στοιχείο λίστας είναι μια παράγραφος της οποίας οι ρυθμίσεις της κουκκίδας ελέγχονται μέσω της μορφής παραγράφου.

Χρησιμοποιήστε τη μέθοδο [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/#getParagraphFormat--) για να έχετε πρόσβαση στις ρυθμίσεις λίστας σε επίπεδο παραγράφου. Το κύριο σημείο εισόδου είναι το [ParagraphFormat.getBullet](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#getBullet--) το οποίο επιστρέφει ένα αντικείμενο [BulletFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/). Με αυτό το αντικείμενο, μπορείτε να ορίσετε τον τύπο της κουκκίδας, το σύμβολο, την εικόνα, το χρώμα, το μέγεθος, το στυλ αρίθμησης και τον αρχικό αριθμό.

Αυτό το άρθρο δείχνει πώς να:

- δημιουργήσετε μια λίστα με κουκκίδες με προσαρμοσμένο σύμβολο
- δημιουργήσετε μια εικόνα-κουκκίδα
- δημιουργήσετε μια πολυεπίπεδη λίστα ορίζοντας το βάθος της παραγράφου
- δημιουργήσετε μια αριθμημένη λίστα
- εξετάσετε και αλλάξετε τη μορφοποίηση λίστας σε μια υπάρχουσα παρουσίαση

## **Δημιουργία λίστας με κουκκίδες**

Για να δημιουργήσετε μια λίστα με κουκκίδες, προσθέστε αντικείμενα [Paragraph](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraph/) σε ένα [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/) και ορίστε το [BulletFormat.setType](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#setType-int-) σε [BulletType.Symbol](https://reference.aspose.com/slides/el/php-java/aspose.slides/bullettype/#Symbol). Στη συνέχεια, μπορείτε να ορίσετε το [BulletFormat.setChar](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#setChar-char-), το [BulletFormat.getColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#getColor--) και το [BulletFormat.setHeight](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#setHeight-float-) για να ελέγξετε την εμφάνιση της κουκκίδας.

Ο παρακάτω κώδικας PHP δείχνει πώς να δημιουργήσετε μια λίστα με κουκκίδες σε μια διαφάνεια:

```php
function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Το αποτέλεσμα:

![Τα σύμβολα κουκκίδας](symbol_bullets.png)

## **Δημιουργία αριθμημένης λίστας**

Χρησιμοποιήστε αριθμημένες λίστες όταν η σειρά των στοιχείων έχει σημασία. Ορίστε το [BulletFormat.setType](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#setType-int-) σε [BulletType.Numbered](https://reference.aspose.com/slides/el/php-java/aspose.slides/bullettype/#Numbered). Μπορείτε επίσης να επιλέξετε μορφή αρίθμησης με το [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) ή να ορίσετε το [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) όταν η λίστα πρέπει να ξεκινά από τιμή διαφορετική από 1.

Ο παρακάτω κώδικας PHP δείχνει πώς να δημιουργήσετε μια αριθμημένη λίστα σε μια διαφάνεια:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Το αποτέλεσμα:

![Οι αριθμημένες κουκκίδες](numbered_bullets.png)

## **Δημιουργία εικόνας-κουκκίδας**

Το Aspose.Slides σας επιτρέπει να αντικαταστήσετε ένα κανονικό σύμβολο κουκκίδας με μια εικόνα. Οι εικόνες-κουκκίδες λειτουργούν καλύτερα με απλές εικόνες που παραμένουν αναγνώσιμες σε μικρό μέγεθος, όπως εικονίδια ή μικρά διαφανή αρχεία PNG.

{{% alert color="primary" %}}
Ιδανικά, εάν σχεδιάζετε να αντικαταστήσετε το κανονικό σύμβολο κουκκίδας με μια εικόνα, είναι καλύτερο να επιλέξετε ένα απλό γραφικό με διαφανές φόντο. Τέτοιες εικόνες λειτουργούν καλά ως προσαρμοσμένα σύμβολα κουκκίδας.
{{% /alert %}}

Για να δημιουργήσετε μια εικόνα-κουκκίδα, προσθέστε μια εικόνα στο [Presentation.getImages](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/#getImages--) και αντιστοιχίστε το επιστρεφόμενο αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) στο [BulletFormat.getPicture](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#getPicture--). Ορίστε το [BulletFormat.setType](https://reference.aspose.com/slides/el/php-java/aspose.slides/bulletformat/#setType-int-) σε [BulletType.Picture](https://reference.aspose.com/slides/el/php-java/aspose.slides/bullettype/#Picture) πριν αναθέσετε την εικόνα.

Ας υποθέσουμε ότι έχουμε ένα "image.png":

![Μία εικόνα για τις κουκκίδες](picture_for_bullets.png)

Ο παρακάτω κώδικας PHP δείχνει πώς να δημιουργήσετε εικόνες-κουκκίδες σε μια διαφάνεια:

```php
function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Το αποτέλεσμα:

![Οι εικόνες-κουκκίδες](picture_bullets.png)

## **Δημιουργία πολυεπίπεδου λίστας**

Χρησιμοποιήστε το [ParagraphFormat.setDepth](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#setDepth-short-) για να τοποθετήσετε στοιχεία λίστας σε διαφορετικά επίπεδα. Το επίπεδο 0 είναι το κορυφαίο επίπεδο, το επίπεδο 1 είναι ενσωματωμένο κάτω από αυτό, κλπ.

Ο παρακάτω κώδικας PHP δείχνει πώς να δημιουργήσετε μια πολυεπίπεδη λίστα με κουκκίδες:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Το αποτέλεσμα:

![Η πολυεπίπεδη λίστα](multilevel_list.png)

## **Τροποποίηση υπάρχουσας λίστας**

Για να αλλάξετε τη μορφοποίηση λίστας σε μια υπάρχουσα παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο και ενημερώστε τις ρυθμίσεις της [ParagraphFormat.getBullet](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#getBullet--). Οι ίδιες ιδιότητες που χρησιμοποιούνται για τη δημιουργία λιστών μπορούν να χρησιμοποιηθούν για την εξέταση ή τροποποίηση λιστών που έχουν φορτωθεί από αρχείο PPT, PPTX ή ODP.

Ο παρακάτω κώδικας PHP αλλάζει την πρώτη παράγραφο σε ένα πλαίσιο κειμένου ώστε να χρησιμοποιεί στυλ αριθμημένης λίστας:

```php
$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορούν οι λίστες με κουκκίδες και αριθμημένες λίστες να εξαχθούν σε PDF ή εικόνες;**

Ναι. Το Aspose.Slides διατηρεί τη μορφοποίηση λίστας όταν η μορφή προορισμού υποστηρίζει τη σχετική διάταξη κειμένου και τα χαρακτηριστικά της κουκκίδας.

**Μπορώ να επεξεργαστώ λίστες σε υπάρχουσες παρουσιάσεις;**

Ναι. Φορτώστε την παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο, εξετάστε ή ενημερώστε τις ρυθμίσεις της [ParagraphFormat.getBullet](https://reference.aspose.com/slides/el/php-java/aspose.slides/paragraphformat/#getBullet--), και αποθηκεύστε την παρουσίαση.

**Μπορούν οι λίστες να περιέχουν μη-λατινικό κείμενο;**

Ναι. Το κείμενο των στοιχείων λίστας μπορεί να περιέχει χαρακτήρες Unicode, ώστε να μπορείτε να δημιουργείτε λίστες σε πολυγλωσσικές παρουσιάσεις. Βεβαιωθείτε ότι οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση υποστηρίζουν τους χαρακτήρες που χρειάζεστε.