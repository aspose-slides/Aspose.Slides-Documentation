---
title: Διαχείριση Υπερσυνδέσμων Παρουσίασης σε PHP
linktitle: Διαχείριση Υπερσυνδέσμου
type: docs
weight: 20
url: /el/php-java/manage-hyperlinks/
keywords:
- προσθήκη URL
- προσθήκη υπερσυνδέσμου
- δημιουργία υπερσυνδέσμου
- μορφοποίηση υπερσυνδέσμου
- αφαίρεση υπερσυνδέσμου
- ενημέρωση υπερσυνδέσμου
- υπερσύνδεσμος κειμένου
- υπερσύνδεσμος διαφάνειας
- υπερσύνδεσμος σχήματος
- υπερσύνδεσμος εικόνας
- υπερσύνδεσμος βίντεο
- μεταβλητός υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε εύκολα τους υπερσυνδέσμους σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για PHP μέσω Java — βελτιώστε την αλληλεπίδραση και τη ροή εργασιών σε λίγα λεπτά."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος είναι μια αναφορά σε ένα αντικείμενο ή δεδομένα ή σε ένα μέρος σε κάτι. Αυτοί είναι οι συνηθισμένοι υπερσύνδεσμοι σε παρουσιάσεις PowerPoint:

* Σύνδεσμοι σε ιστότοπους μέσα σε κείμενα, σχήματα ή πολυμέσα
* Σύνδεσμοι σε διαφάνειες

Aspose.Slides για PHP μέσω Java επιτρέπει την εκτέλεση πολλών εργασιών που αφορούν υπερσυνδέσμους σε παρουσιάσεις.

{{% alert color="primary" %}} 
Ίσως θελήσετε να δοκιμάσετε το απλό, [δωρεάν online επεξεργαστή PowerPoint.](https://products.aspose.app/slides/el/editor)
{{% /alert %}} 

## **Προσθήκη URL Υπερσυνδέσμων**

### **Προσθήκη URL Υπερσυνδέσμων σε Κείμενο**

Αυτός ο κώδικας PHP δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστότοπου σε κείμενο:

```php
  $presentation = new Presentation();
  try {
    $shape1 = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Προσθήκη URL Υπερσυνδέσμων σε Σχήματα ή Πλαισίους**

Αυτό το παράδειγμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστότοπου σε ένα σχήμα:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);
    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Προσθήκη URL Υπερσυνδέσμων σε Πολυμέσα**

Το Aspose.Slides επιτρέπει την προσθήκη υπερσυνδέσμων σε εικόνες, ήχο και αρχεία βίντεο. 

Αυτό το παράδειγμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε μια **εικόνα**:

```php
  $pres = new Presentation();
  try {
    # Προσθέτει εικόνα στην παρουσίαση
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Δημιουργεί πλαίσιο εικόνας στη διαφάνεια 1 βάσει της προηγούμενης εικόνας
    $pictureFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pictureFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pictureFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Αυτό το παράδειγμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε ένα **αρχείο ήχου**:

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "audio.mp3"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $audio = $pres->getAudios()->addAudio($bytes);

    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->addAudioFrameEmbedded(10, 10, 100, 100, $audio);
    $audioFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $audioFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Αυτό το παράδειγμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε ένα **βίντεο**:

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "video.avi"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $video = $pres->getVideos()->addVideo($bytes);

    $videoFrame = $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 100, 100, $video);
    $videoFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $videoFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  title="Tip"  color="primary"  %}} 
Ίσως θέλετε να δείτε *[Διαχείριση OLE](/slides/el/php-java/manage-ole/)*.
{{% /alert %}}

## **Χρήση Υπερσυνδέσμων για Δημιουργία Πίνακα Περιεχομένων**

Δεδομένου ότι οι υπερσύνδεσμοι σας επιτρέπουν να προσθέτετε αναφορές σε αντικείμενα ή θέσεις, μπορείτε να τους χρησιμοποιήσετε για τη δημιουργία πίνακα περιεχομένων. 

Αυτό το παράδειγμα κώδικα δείχνει πώς να δημιουργήσετε έναν πίνακα περιεχομένων με υπερσυνδέσμους:

```php
  $pres = new Presentation();
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    $secondSlide = $pres->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());
    $contentTable = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $contentTable->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getTextFrame()->getParagraphs()->clear();
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");
    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);
    $paragraph->getPortions()->add($linkPortion);
    $contentTable->getTextFrame()->getParagraphs()->add($paragraph);
    $pres->save("link_to_slide.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Μορφοποίηση Υπερσυνδέσμων**

### **Χρώμα**

Με τη μέθοδο [setColorSource](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/setcolorsource/) στην κλάση [Hyperlink](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/), μπορείτε να ορίσετε το χρώμα για τους υπερσυνδέσμους και επίσης να λάβετε τις πληροφορίες χρώματος από τους υπερσυνδέσμους. Η λειτουργία παρουσιάστηκε για πρώτη φορά στο PowerPoint 2019, οπότε οι αλλαγές που αφορούν αυτήν την ιδιότητα δεν ισχύουν για παλαιότερες εκδόσεις του PowerPoint.

Αυτό το παράδειγμα κώδικα δείχνει μια λειτουργία όπου προστέθηκαν υπερσύνδεσμοι με διαφορετικά χρώματα στην ίδια διαφάνεια:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $shape1->addTextFrame("This is a sample of colored hyperlink.");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setColorSource(HyperlinkColorSource->PortionFormat);
    $portionFormat::getFillFormat()->setFillType(FillType::Solid);
    $portionFormat::getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $shape2 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $shape2->addTextFrame("This is a sample of usual hyperlink.");
    $shape2->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pres->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

### **Αφαίρεση Υπερσυνδέσμων από Κείμενο**

Αυτός ο κώδικας PHP δείχνει πώς να αφαιρέσετε τον υπερσύνδεσμο από κείμενο σε διαφάνεια παρουσίασης:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $autoShape = $shape;
      if (!java_is_null($autoShape)) {
        foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
          foreach($paragraph->getPortions() as $portion) {
            $portion->getPortionFormat()->getHyperlinkManager()->removeHyperlinkClick();
          }
        }
      }
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Αφαίρεση Υπερσυνδέσμων από Σχήματα ή Πλαισίων**

Αυτός ο κώδικας PHP δείχνει πώς να αφαιρέσετε τον υπερσύνδεσμο από ένα σχήμα σε διαφάνεια παρουσίασης:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $shape->getHyperlinkManager()->removeHyperlinkClick();
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Μεταβλητός Υπερσύνδεσμος**

Η κλάση [Hyperlink](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/) είναι μεταβλητή. Με αυτήν την κλάση, μπορείτε να αλλάξετε τις τιμές για αυτές τις ιδιότητες:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

Το απόσπασμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε μια διαφάνεια και να επεξεργαστείτε το tooltip του αργότερα:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $pres->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Υποστηριζόμενες Ιδιότητες στο IHyperlinkQueries**

Μπορείτε να έχετε πρόσβαση στις [HyperlinkQueries](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkqueries/) από μια παρουσίαση, διαφάνεια ή κείμενο για το οποίο ορίζεται ο υπερσύνδεσμος.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/el/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/gethyperlinkqueries/)

Η κλάση [HyperlinkQueries](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkqueries/) υποστηρίζει αυτές τις μεθόδους και ιδιότητες:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/el/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να δημιουργήσω εσωτερική πλοήγηση όχι μόνο σε μια διαφάνεια, αλλά σε μια «ενότητα» ή στην πρώτη διαφάνεια μιας ενότητας;**

Οι ενότητες στο PowerPoint είναι ομάδες διαφανειών· η πλοήγηση τεχνικά στοχεύει σε μια συγκεκριμένη διαφάνεια. Για να «πλοηγηθείτε σε μια ενότητα», συνήθως συνδέεστε με την πρώτη διαφάνειά της.

**Μπορώ να συζεύσω έναν υπερσύνδεσμο με στοιχεία της κύριας διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία της κύριας διαφάνειας και του διάταξης υποστηρίζουν υπερσυνδέσμους. Τέτοιοι σύνδεσμοι εμφανίζονται στις θυγατρικές διαφάνειες και είναι κλικαρίθμιση κατά τη διάρκεια της παρουσίασης.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Στα [PDF](/slides/el/php-java/convert-powerpoint-to-pdf/) και [HTML](/slides/el/php-java/convert-powerpoint-to-html/), ναι — οι σύνδεσμοι διατηρούνται γενικά. Κατά την εξαγωγή σε [εικόνες](/slides/el/php-java/convert-powerpoint-to-png/) και [βίντεο](/slides/el/php-java/convert-powerpoint-to-video/), η δυνατότητα κλικ δεν μεταφέρεται λόγω της φύσης αυτών των μορφών (πλαστικές καρέ/βίντεο δεν υποστηρίζουν υπερσυνδέσμους).