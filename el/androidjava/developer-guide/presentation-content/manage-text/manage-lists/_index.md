---
title: "Διαχείριση λιστών με κουκίδες και αριθμημένων λιστών σε παρουσιάσεις στο Android"
linktitle: "Διαχείριση λιστών"
type: docs
weight: 60
url: /el/androidjava/manage-lists/
keywords:
- "κουκίδα"
- "λίστα με κουκίδες"
- "αριθμημένη λίστα"
- "συμβολική κουκίδα"
- "κουκίδα εικόνας"
- "προσαρμοσμένη κουκίδα"
- "λίστα πολλαπλών επιπέδων"
- "δημιουργία κουκίδας"
- "προσθήκη κουκίδας"
- "προσθήκη λίστας"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε λίστες με κουκίδες, εικόνες, πολλαπλά επίπεδα και αριθμημένες λίστες σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Android μέσω Java σάς επιτρέπει να δημιουργείτε και να μορφοποιείτε λίστες με κουκίδες και αριθμημένες λίστες σε παρουσιάσεις PowerPoint και OpenDocument. Ένα στοιχείο λίστας είναι μια παράγραφος της οποίας οι ρυθμίσεις της κουκίδας ελέγχονται μέσω της διαμόρφωσης της παραγράφου.

Χρησιμοποιήστε τη μέθοδο [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) για να αποκτήσετε πρόσβαση στις ρυθμίσεις λίστας επιπέδου παραγράφου. Το κύριο σημείο εισόδου είναι το [IParagraphFormat.getBullet](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), το οποίο επιστρέφει ένα αντικείμενο [IBulletFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/). Με αυτό το αντικείμενο, μπορείτε να ορίσετε τον τύπο της κουκίδας, το σύμβολο, την εικόνα, το χρώμα, το μέγεθος, το στυλ αρίθμησης και τον αρχικό αριθμό.

Το άρθρο αυτό δείχνει πώς να:

- δημιουργία λίστας με κουκίδες με προσαρμοσμένο σύμβολο
- δημιουργία εικόνας-κουκίδας
- δημιουργία πολλαπλών επιπέδων λίστας ορίζοντας το βάθος της παραγράφου
- δημιουργία αριθμημένης λίστας
- έλεγχος και αλλαγή μορφοποίησης λίστας σε υπάρχουσα παρουσίαση

## **Δημιουργία λίστας με κουκίδες**

Για να δημιουργήσετε λίστα με κουκίδες, προσθέστε παραγράφους σε ένα [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) και ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) σε [BulletType.Symbol](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/bullettype/). Στη συνέχεια, μπορείτε να ορίσετε το [IBulletFormat.setChar](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), το [IBulletFormat.getColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#getColor--), και το [IBulletFormat.setHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) για να ελέγξετε την εμφάνιση της κουκίδας.

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε λίστα με κουκίδες σε μια διαφάνεια:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι συμβολικές κουκίδες](symbol_bullets.png)

## **Δημιουργία αριθμημένης λίστας**

Χρησιμοποιήστε αριθμημένες λίστες όταν η σειρά των στοιχείων έχει σημασία. Ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) σε [BulletType.Numbered](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/bullettype/). Μπορείτε επίσης να επιλέξετε μορφή αρίθμησης με το [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) ή να ορίσετε το [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) όταν η λίστα πρέπει να ξεκινά από μια τιμή διαφορετική από το 1.

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε αριθμημένη λίστα σε μια διαφάνεια:

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

![Οι αριθμημένες κουκίδες](numbered_bullets.png)

## **Δημιουργία εικόνας-κουκίδας**

Το Aspose.Slides σας επιτρέπει να αντικαταστήσετε ένα κανονικό σύμβολο κουκίδας με μια εικόνα. Οι εικόνες-κουκίδες λειτουργούν καλύτερα με απλές εικόνες που παραμένουν ευανάγνωστες σε μικρό μέγεθος, όπως εικονίδια ή μικρά διαφανή αρχεία PNG.

{{% alert color="primary" %}}
Ιδανικά, εάν σκοπεύετε να αντικαταστήσετε το κανονικό σύμβολο κουκίδας με μια εικόνα, είναι καλύτερο να επιλέξετε ένα απλό γραφικό με διαφανές φόντο. Τέτοιες εικόνες λειτουργούν καλά ως προσαρμοσμένα σύμβολα κουκίδας.
{{% /alert %}}

Λάβετε υπόψη ότι η εικόνα θα κλιμακωθεί σε πολύ μικρό μέγεθος. Για αυτόν τον λόγο, συνιστούμε ανεπιφύλακτα να επιλέξετε μια εικόνα που παραμένει σαφής και οπτικά αποτελεσματική όταν χρησιμοποιείται ως κουκίδα σε λίστα.

Για να δημιουργήσετε εικόνα-κουκίδα, προσθέστε μια εικόνα στο [Presentation.getImages](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getImages--) και εκχωρήστε το επιστρεφόμενο αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/) στην [IBulletFormat.getPicture](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#getPicture--). Ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) σε [BulletType.Picture](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/bullettype/) πριν εκχωρήσετε την εικόνα.

Ας πούμε ότι έχουμε ένα "image.png":

![Μια εικόνα για τις κουκίδες](picture_for_bullets.png)

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε εικόνες-κουκίδες σε μια διαφάνεια:

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

![Οι εικόνες-κουκίδες](picture_bullets.png)

## **Δημιουργία λίστας πολλαπλών επιπέδων**

Χρησιμοποιήστε το [IParagraphFormat.setDepth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) για να τοποθετήσετε στοιχεία λίστας σε διαφορετικά επίπεδα. Το επίπεδο 0 είναι το ανώτερο επίπεδο, το επίπεδο 1 βρίσκεται εντός αυτού, κλπ.

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε λίστα με πολλαπλά επίπεδα κουκίδων:

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

![Η λίστα πολλαπλών επιπέδων](multilevel_list.png)

## **Αλλαγή υπάρχουσας λίστας**

Για να αλλάξετε τη μορφοποίηση λίστας σε μια υπάρχουσα παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο και ενημερώστε τις ρυθμίσεις της [IParagraphFormat.getBullet](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#getBullet--). Οι ίδιες μέθοδοι που χρησιμοποιούνται για τη δημιουργία λιστών μπορούν να χρησιμοποιηθούν για την επισκόπηση ή την τροποποίηση λιστών που έχουν φορτωθεί από αρχείο PPT, PPTX ή ODP.

Ο παρακάτω κώδικας Java αλλάζει την πρώτη παράγραφο σε ένα πλαίσιο κειμένου ώστε να χρησιμοποιήσει στυλ αριθμημένης λίστας:

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

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορούν οι λίστες με κουκίδες και οι αριθμημένες λίστες να εξαχθούν σε PDF ή εικόνες;**

Ναι. Το Aspose.Slides διατηρεί τη μορφοποίηση λίστας όταν η μορφή προορισμού υποστηρίζει τη σχετική διάταξη κειμένου και τις δυνατότητες των κουκίδων.

**Μπορώ να επεξεργαστώ λίστες σε υπάρχουσες παρουσιάσεις;**

Ναι. Φορτώστε την παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο, εξέταση ή ενημέρωση των ρυθμίσεων της [IParagraphFormat.getBullet](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) και αποθηκεύστε την παρουσίαση.

**Μπορούν οι λίστες να περιέχουν μη-λατινικό κείμενο;**

Ναι. Το κείμενο των στοιχείων λίστας μπορεί να περιέχει χαρακτήρες Unicode, ώστε να μπορείτε να δημιουργήσετε λίστες σε πολυγλωσσικές παρουσιάσεις. Βεβαιωθείτε ότι οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση υποστηρίζουν τους χαρακτήρες που χρειάζεστε.