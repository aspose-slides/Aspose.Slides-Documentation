---
title: Διαχείριση Λιστών με Κουκκίδες και Αριθμούς σε Παρουσιάσεις σε Java
linktitle: Διαχείριση Λιστών
type: docs
weight: 60
url: /el/java/manage-lists/
keywords:
- κουκκίδα
- λίστα με κουκκίδες
- αριθμημένη λίστα
- σύμβολο κουκκίδας
- κουκκίδα εικόνας
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
description: Μάθετε πώς να δημιουργείτε και να μορφοποιείτε λίστες με κουκκίδες, εικόνα, πολυεπίπεδες και αριθμημένες σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides for Java.
---
## **Επισκόπηση**

Το Aspose.Slides for Java σάς επιτρέπει να δημιουργείτε και να διαμορφώνετε λίστες με κουκκίδες και αριθμημένες λίστες σε παρουσιάσεις PowerPoint και OpenDocument. Ένα στοιχείο λίστας είναι μια παράγραφος της οποίας οι ρυθμίσεις της κουκκίδας ελέγχονται μέσω της μορφοποίησης της παραγράφου.

Χρησιμοποιήστε τη μέθοδο [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraph/#getParagraphFormat--) για να έχετε πρόσβαση στις ρυθμίσεις λίστας σε επίπεδο παραγράφου. Το κύριο σημείο εισόδου είναι το [IParagraphFormat.getBullet](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#getBullet--), το οποίο επιστρέφει ένα αντικείμενο [IBulletFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/). Με αυτό το αντικείμενο, μπορείτε να ορίσετε τον τύπο της κουκκίδας, το σύμβολο, την εικόνα, το χρώμα, το μέγεθος, το στυλ αρίθμησης και τον αρχικό αριθμό.

Αυτό το άρθρο δείχνει πώς να:

- Δημιουργήσετε λίστα με κουκκίδες χρησιμοποιώντας προσαρμοσμένο σύμβολο
- Δημιουργήσετε εικόνα‑κουκκίδα
- Δημιουργήσετε πολυεπίπεδο κατάλογο ορίζοντας το βάθος της παραγράφου
- Δημιουργήσετε αριθμημένη λίστα
- Ελέγξετε και αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση

## **Δημιουργία λίστας με κουκκίδες**

Για να δημιουργήσετε λίστα με κουκκίδες, προσθέστε αντικείμενα [IParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraph/) σε ένα [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/) και ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#setType-byte-) σε [BulletType.Symbol](https://reference.aspose.com/slides/el/java/com.aspose.slides/bullettype/#Symbol). Στη συνέχεια, μπορείτε να ορίσετε το [IBulletFormat.setChar](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#setChar-char-), το [IBulletFormat.getColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#getColor--) και το [IBulletFormat.setHeight](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#setHeight-float-) για να ελέγξετε την εμφάνιση της κουκκίδας.

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε μια λίστα με κουκκίδες σε μια διαφάνεια:

```java
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

![The symbol bullets](symbol_bullets.png)

## **Δημιουργία αριθμημένης λίστας**

Χρησιμοποιήστε αριθμημένες λίστες όταν η σειρά των στοιχείων έχει σημασία. Ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#setType-byte-) σε [BulletType.Numbered](https://reference.aspose.com/slides/el/java/com.aspose.slides/bullettype/#Numbered). Μπορείτε επίσης να επιλέξετε μορφή αρίθμησης με το [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) ή να ορίσετε το [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) όταν η λίστα πρέπει να ξεκινά από τιμή διαφορετική από το 1.

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε μια αριθμημένη λίστα σε μια διαφάνεια:

```java
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

![The numbered bullets](numbered_bullets.png)

## **Δημιουργία εικόνας‑κουκκίδας**

Το Aspose.Slides σας επιτρέπει να αντικαταστήσετε ένα κανονικό σύμβολο κουκκίδας με μια εικόνα. Οι εικόνες‑κουκκίδες λειτουργούν καλύτερα με απλές εικόνες που παραμένουν αναγνώσιμες σε μικρό μέγεθος, όπως εικονίδια ή μικρά διαυρά PNG αρχεία.

{{% alert color="primary" %}}
Ιδανικά, αν σκοπεύετε να αντικαταστήσετε το κανονικό σύμβολο κουκκίδας με μια εικόνα, είναι καλύτερο να επιλέξετε ένα απλό γραφικό με διαυρή φόντο. Τέτοιες εικόνες λειτουργούν καλά ως προσαρμοσμένα σύμβολα κουκκίδας.

Να θυμάστε ότι η εικόνα θα κλιμακωθεί σε πολύ μικρό μέγεθος. Για αυτόν τον λόγο, συνιστούμε έντονα να επιλέξετε μια εικόνα που παραμένει καθαρή και οπτικά αποτελεσματική όταν χρησιμοποιείται ως κουκκίδα σε λίστα.
{{% /alert %}}

Για να δημιουργήσετε εικόνα‑κουκκίδα, προσθέστε μια εικόνα στο [Presentation.getImages](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getImages--) και αναθέστε το επιστραφέν αντικείμενο εικόνας στο [IBulletFormat.getPicture](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#getPicture--). Ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibulletformat/#setType-byte-) σε [BulletType.Picture](https://reference.aspose.com/slides/el/java/com.aspose.slides/bullettype/#Picture) πριν την ανάθεση της εικόνας.

Ας υποθέσουμε ότι έχουμε ένα "image.png":

![A picture for the bullets](picture_for_bullets.png)

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε εικόνες‑κουκκίδες σε μια διαφάνεια:

```java
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

![The picture bullets](picture_bullets.png)

## **Δημιουργία πολυεπίπεδου καταλόγου**

Χρησιμοποιήστε το [IParagraphFormat.setDepth](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setDepth-short-) για να τοποθετήσετε στοιχεία λίστας σε διαφορετικά επίπεδα. Το επίπεδο 0 είναι το ανώτατο επίπεδο, το επίπεδο 1 είναι εσωτερικό του και ούτω καθεξής.

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε μια πολυεπίπεδη λίστα με κουκκίδες:

```java
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

![The multilevel list](multilevel_list.png)

## **Αλλαγή υπάρχουσας λίστας**

Για να αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο και ενημερώστε τις ρυθμίσεις του [IParagraphFormat.getBullet](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#getBullet--) . Οι ίδιες ιδιότητες που χρησιμοποιήθηκαν για τη δημιουργία λιστών μπορούν να χρησιμοποιηθούν για την επιθεώρηση ή την τροποποίηση λιστών που έχουν φορτωθεί από αρχείο PPT, PPTX ή ODP.

Ο παρακάτω κώδικας Java αλλάζει την πρώτη παράγραφο σε πλαίσιο κειμένου ώστε να χρησιμοποιεί στυλ αριθμημένης λίστας:

```java
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

**Μπορούν οι λίστες με κουκκίδες και οι αριθμημένες λίστες να εξαχθούν σε PDF ή εικόνες;**

Ναι. Το Aspose.Slides διατηρεί τη μορφοποίηση της λίστας όταν η μορφή προορισμού υποστηρίζει την αντίστοιχη διάταξη κειμένου και τις δυνατότητες κουκκίδας.

**Μπορώ να επεξεργαστώ λίστες σε υπάρχουσες παρουσιάσεις;**

Ναι. Φορτώστε την παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο, επιθεωρήστε ή ενημερώστε τις ρυθμίσεις του [IParagraphFormat.getBullet](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#getBullet--), και αποθηκεύστε την παρουσίαση.

**Μπορούν οι λίστες να περιέχουν μη λατινικό κείμενο;**

Ναι. Το κείμενο των στοιχείων λίστας μπορεί να περιέχει χαρακτήρες Unicode, έτσι ώστε να μπορείτε να δημιουργείτε λίστες σε πολυγλωσσικές παρουσιάσεις. Βεβαιωθείτε ότι οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση υποστηρίζουν τους χαρακτήρες που χρειάζεστε.