---
title: Διαχείριση λιστών με κουκκίδες και αριθμημένων λιστών σε παρουσιάσεις με Java
linktitle: Διαχείριση λιστών
type: docs
weight: 60
url: /el/java/manage-lists/
keywords:
- κουκκίδα
- λίστα με κουκκίδες
- αριθμημένη λίστα
- συμβολική κουκκίδα
- εικόνα-κουκκίδα
- προσαρμοσμένη κουκκίδα
- πολυεπίπεδη λίστα
- δημιουργία κουκκίδας
- προσθήκη κουκκίδας
- προσθήκη λίστας
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε λιστες με κουκκίδες, εικόνα, πολυεπίπεδες και αριθμημένες λιστες σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Java σάς επιτρέπει να δημιουργείτε και να μορφοποιείτε λιστες με κουκκίδες και αριθμημένες λιστες σε παρουσιάσεις PowerPoint και OpenDocument. Ένα στοιχείο λίστας είναι μια παράγραφος της οποίας οι ρυθμίσεις της κουκκίδας ελέγχονται μέσω της μορφοποίησης παραγράφου.

Χρησιμοποιήστε τη μέθοδο [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraph/#getParagraphFormat--) για να αποκτήσετε πρόσβαση στις ρυθμίσεις λίστας επιπέδου παραγράφου. Το κύριο σημείο εισόδου είναι το [IParagraphFormat.getBullet](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#getBullet--), το οποίο επιστρέφει ένα αντικείμενο [IBulletFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/). Με αυτό το αντικείμενο, μπορείτε να ορίσετε τον τύπο της κουκκίδας, το σύμβολο, την εικόνα, το χρώμα, το μέγεθος, το στυλ αρίθμησης και τον αρχικό αριθμό.

Αυτό το άρθρο δείχνει πώς να:

- δημιουργήσετε μια λιστα με κουκκίδες με προσαρμοσμένο σύμβολο
- δημιουργήσετε μια εικόνα-κουκκίδα
- δημιουργήσετε πολυεπίπεδη λιστα ορίζοντας το βάθος της παραγράφου
- δημιουργήσετε αριθμημένη λιστα
- ελέγξετε και αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση

## **Δημιουργία λίστας με κουκκίδες**

Για να δημιουργήσετε μια λιστα με κουκκίδες, προσθέστε αντικείμενα [IParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraph/) σε ένα [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/) και ορίστε [IBulletFormat.setType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#setType-byte-) σε [BulletType.Symbol](https://reference.aspose.com/slides/el/java/com.aspose.slides/bullettype/#Symbol). Στη συνέχεια μπορείτε να ορίσετε [IBulletFormat.setChar](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#getColor--) και [IBulletFormat.setHeight](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#setHeight-float-) για να ελέγξετε την εμφάνιση της κουκκίδας.

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε μια λιστα με κουκκίδες σε μία διαφάνεια:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Τα σύμβολα των κουκκίδων](symbol_bullets.png)

## **Δημιουργία αριθμημένης λίστας**

Χρησιμοποιήστε αριθμημένες λιστες όταν η σειρά των στοιχείων έχει σημασία. Ορίστε [IBulletFormat.setType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#setType-byte-) σε [BulletType.Numbered](https://reference.aspose.com/slides/el/java/com.aspose.slides/bullettype/#Numbered). Μπορείτε επίσης να επιλέξετε μορφή αρίθμησης με [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) ή να ορίσετε [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) όταν η λιστα πρέπει να ξεκινήσει από τιμή διαφορετική από 1.

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε μια αριθμημένη λιστα σε μία διαφάνεια:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι αριθμημένες κουκκίδες](numbered_bullets.png)

## **Δημιουργία εικόνας-κουκκίδας**

Το Aspose.Slides επιτρέπει την αντικατάσταση ενός κανονικού συμβόλου κουκκίδας με εικόνα. Οι εικόνες-κουκκίδες λειτουργούν καλύτερα με απλές εικόνες που παραμένουν αναγνώσιμες σε μικρό μέγεθος, όπως εικονίδια ή μικρά διαφανή αρχεία PNG.

{{% alert color="info" %}}
Ιδανικά, εάν σκοπεύετε να αντικαταστήσετε το κανονικό σύμβολο της κουκκίδας με εικόνα, είναι καλύτερο να επιλέξετε ένα απλό γραφικό με διαφανές φόντο. Τέτοιες εικόνες λειτουργούν καλά ως προσαρμοσμένα σύμβολα κουκκίδας.

Λάβετε υπόψη ότι η εικόνα θα κλιμακωθεί σε πολύ μικρό μέγεθος. Για το λόγο αυτό, συνιστούμε ανεπιφύλακτα την επιλογή μιας εικόνας που παραμένει καθαρή και οπτικά αποτελεσματική όταν χρησιμοποιείται ως κουκκίδα σε λιστα.
{{% /alert %}}

Για να δημιουργήσετε μια εικόνα-κουκκίδα, προσθέστε μια εικόνα στο [Presentation.getImages](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getImages--) και αντιστοιχίστε το αντικείμενο εικόνας που επιστρέφεται στο [IBulletFormat.getPicture](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#getPicture--). Ορίστε [IBulletFormat.setType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#setType-byte-) σε [BulletType.Picture](https://reference.aspose.com/slides/el/java/com.aspose.slides/bullettype/#Picture) πριν αναθέσετε την εικόνα.

Ας πούμε ότι έχουμε ένα «image.png»:

![Μια εικόνα για τις κουκκίδες](picture_for_bullets.png)

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε εικόνες-κουκκίδες σε μία διαφάνεια:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι εικόνες-κουκκίδες](picture_bullets.png)

## **Δημιουργία πολυεπίπεδης λίστας**

Χρησιμοποιήστε [IParagraphFormat.setDepth](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setDepth-short-) για να τοποθετήσετε στοιχεία λίστας σε διαφορετικά επίπεδα. Το επίπεδο 0 είναι το άνω επίπεδο, το επίπεδο 1 είναι ένθετο κάτω από αυτό, κ.ο.κ.

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε μια πολυεπίπεδη λιστα με κουκκίδες:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η πολυεπίπεδη λίστα](multilevel_list.png)

## **Αλλαγή υπάρχουσας λίστας**

Για να αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο και ενημερώστε τις ρυθμίσεις [IParagraphFormat.getBullet](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#getBullet--) της. Οι ίδιες ιδιότητες που χρησιμοποιούνται για τη δημιουργία λιστών μπορούν να χρησιμοποιηθούν για την εξέταση ή την τροποποίηση λιστών που έχουν φορτωθεί από αρχείο PPT, PPTX ή ODP.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

### Μπορούν οι λιστες με κουκκίδες και οι αριθμημένες λιστες να εξαχθούν σε PDF ή εικόνες;

Ναι. Το Aspose.Slides διατηρεί τη μορφοποίηση της λίστας όταν η μορφή προορισμού υποστηρίζει την αντίστοιχη διάταξη κειμένου και τις δυνατότητες κουκκίδας.

### Μπορώ να επεξεργαστώ λιστες σε υπάρχουσες παρουσιάσεις;

Ναι. Φορτώστε την παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο, ελέγξτε ή ενημερώστε τις ρυθμίσεις [IParagraphFormat.getBullet](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#getBullet--) και αποθηκεύστε την παρουσίαση.

### Μπορούν οι λιστες να περιέχουν μη λατινικό κείμενο;

Ναί. Το κείμενο των στοιχείων λίστας μπορεί να περιέχει χαρακτήρες Unicode, ώστε να μπορείτε να δημιουργείτε λιστες σε πολυγλωσσικές παρουσιάσεις. Βεβαιωθείτε ότι οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση υποστηρίζουν τους χαρακτήρες που χρειάζεστε.