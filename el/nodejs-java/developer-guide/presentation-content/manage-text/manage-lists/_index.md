---
title: Διαχείριση λιστών με κουκίδες και αριθμημένων λιστών σε παρουσιάσεις με χρήση JavaScript
linktitle: Διαχείριση λιστών
type: docs
weight: 60
url: /el/nodejs-java/manage-lists/
keywords:
- κουκίδα
- λίστα με κουκίδες
- αριθμημένη λίστα
- κουκίδα συμβόλου
- εικόνα-κουκίδα
- προσαρμοσμένη κουκίδα
- πολυεπίπεδη λίστα
- δημιουργία κουκίδας
- προσθήκη κουκίδας
- προσθήκη λίστας
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε λίστες με κουκίδες, εικόνα, πολυεπίπεδες και αριθμημένες λίστες σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides για Node.js μέσω Java σάς επιτρέπει να δημιουργείτε και να μορφοποιείτε λίστες με κουκίδες και αριθμημένες λίστες σε παρουσιάσεις PowerPoint και OpenDocument. Ένα στοιχείο λίστας είναι μια παράγραφος της οποίας οι ρυθμίσεις κουκίδας ελέγχονται μέσω της μορφής παραγράφου της.

Χρησιμοποιήστε την κλάση [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/) για να έχετε πρόσβαση στις ρυθμίσεις λίστας σε επίπεδο παραγράφου. Το κύριο σημείο εισόδου είναι `Paragraph.getParagraphFormat().getBullet()`, το οποίο επιστρέφει ένα αντικείμενο [BulletFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bulletformat/). Με αυτό το αντικείμενο, μπορείτε να ορίσετε τον τύπο της κουκίδας, το σύμβολο, την εικόνα, το χρώμα, το μέγεθος, το στυλ αρίθμησης και τον αριθμό εκκίνησης.

Αυτό το άρθρο δείχνει πώς να:

- δημιουργήσετε μια λίστα με κουκίδες με προσαρμοσμένο σύμβολο
- δημιουργήσετε μια εικόνα-κουκίδα
- δημιουργήσετε μια πολυεπίπεδη λίστα ορίζοντας το βάθος της παραγράφου
- δημιουργήσετε μια αριθμημένη λίστα
- εξετάσετε και να αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση

## **Δημιουργία λίστας με κουκίδες**

Για να δημιουργήσετε μια λίστα με κουκίδες, προσθέστε αντικείμενα [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/) σε ένα [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) και ορίστε το `BulletFormat.setType` σε [BulletType.Symbol](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bullettype/). Στη συνέχεια, μπορείτε να ορίσετε το `BulletFormat.setChar`, `BulletFormat.getColor` και `BulletFormat.setHeight` για να ελέγξετε την εμφάνιση της κουκίδας.

Ο παρακάτω κώδικας JavaScript δείχνει πώς να δημιουργήσετε μια λίστα με κουκίδες σε μια διαφάνεια:

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι κουκίδες με σύμβολα](symbol_bullets.png)

## **Δημιουργία αριθμημένης λίστας**

Χρησιμοποιήστε αριθμημένες λίστες όταν η σειρά των στοιχείων είναι σημαντική. Ορίστε το `BulletFormat.setType` σε [BulletType.Numbered](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bullettype/). Μπορείτε επίσης να επιλέξετε μορφή αρίθμησης με `BulletFormat.setNumberedBulletStyle` ή να ορίσετε το `BulletFormat.setNumberedBulletStartWith` όταν η λίστα πρέπει να ξεκινά από τιμή διαφορετική από το 1.

Ο παρακάτω κώδικας JavaScript δείχνει πώς να δημιουργήσετε μια αριθμημένη λίστα σε μια διαφάνεια:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι αριθμημένες κουκίδες](numbered_bullets.png)

## **Δημιουργία εικόνας-κουκίδας**

Το Aspose.Slides σας επιτρέπει να αντικαταστήσετε ένα κανονικό σύμβολο κουκίδας με μια εικόνα. Οι εικόνες-κουκίδες λειτουργούν καλύτερα με απλές εικόνες που παραμένουν αναγνώσιμες σε μικρό μέγεθος, όπως εικονίδια ή μικρά διαφανή αρχεία PNG.

{{% alert color="primary" %}}
Ιδανικά, εάν σκοπεύετε να αντικαταστήσετε το κανονικό σύμβολο κουκίδας με μια εικόνα, είναι καλύτερο να επιλέξετε ένα απλό γραφικό με διαφανές φόντο. Τέτοιες εικόνες λειτουργούν καλά ως προσαρμοσμένα σύμβολα κουκίδας.

Λάβετε υπόψη ότι η εικόνα θα κλιμακωθεί σε πολύ μικρό μέγεθος. Για αυτόν τον λόγο, συνιστούμε ανεπιφύλακτα να επιλέξετε μια εικόνα που παραμένει σαφής και οπτικά αποτελεσματική όταν χρησιμοποιείται ως κουκίδα σε μια λίστα.
{{% /alert %}}

Για να δημιουργήσετε μια εικόνα-κουκίδα, προσθέστε μια εικόνα στο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) με τη μέθοδο `Presentation.getImages().addImage` και εκχωρήστε το επιστρεφόμενο αντικείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) στο `BulletFormat.getPicture().setImage`. Ορίστε το `BulletFormat.setType` σε [BulletType.Picture](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bullettype/) πριν αναθέσετε την εικόνα.

Ας πούμε ότι έχουμε ένα "image.png":

![Μια εικόνα για τις κουκίδες](picture_for_bullets.png)

Ο παρακάτω κώδικας JavaScript δείχνει πώς να δημιουργήσετε εικόνες-κουκίδες σε μια διαφάνεια:

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Οι εικόνες-κουκίδες](picture_bullets.png)

## **Δημιουργία πολυεπίπεδης λίστας**

Χρησιμοποιήστε το `ParagraphFormat.setDepth` για να τοποθετήσετε στοιχεία λίστας σε διαφορετικά επίπεδα. Το επίπεδο 0 είναι το ανώτατο επίπεδο, το επίπεδο 1 είναι ενσωματωμένο κάτω από αυτό, κ.ο.κ.

Ο παρακάτω κώδικας JavaScript δείχνει πώς να δημιουργήσετε μια πολυεπίπεδη λίστα με κουκίδες:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η πολυεπίπεδη λίστα](multilevel_list.png)

## **Τροποποίηση υπάρχουσας λίστας**

Για να αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο και ενημερώστε τις ρυθμίσεις `ParagraphFormat.getBullet`. Οι ίδιες ιδιότητες που χρησιμοποιούνται για τη δημιουργία λιστών μπορούν να χρησιμοποιηθούν για την εξέταση ή την τροποποίηση λιστών που φορτώνονται από αρχείο PPT, PPTX ή ODP.

Ο παρακάτω κώδικας JavaScript αλλάζει την πρώτη παράγραφο σε ένα πλαίσιο κειμένου ώστε να χρησιμοποιεί στυλ αριθμημένης λίστας:

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορούν οι λίστες με κουκίδες και οι αριθμημένες λίστες να εξαχθούν σε PDF ή εικόνες;**

Ναι. Το Aspose.Slides διατηρεί τη μορφοποίηση της λίστας όταν η μορφή προορισμού υποστηρίζει την αντίστοιχη διάταξη κειμένου και τις δυνατότητες κουκίδας.

**Μπορώ να επεξεργαστώ λίστες σε υπάρχουσες παρουσιάσεις;**

Ναι. Φορτώστε την παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο, εξετάστε ή ενημερώστε τις ρυθμίσεις `ParagraphFormat.getBullet` και αποθηκεύστε την παρουσίαση.

**Μπορούν οι λίστες να περιέχουν μη-λατινικό κείμενο;**

Ναι. Το κείμενο των στοιχείων λίστας μπορεί να περιέχει χαρακτήρες Unicode, επομένως μπορείτε να δημιουργήσετε λίστες σε πολυγλωσσικές παρουσιάσεις. Βεβαιωθείτε ότι οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση υποστηρίζουν τους χαρακτήρες που χρειάζεστε.