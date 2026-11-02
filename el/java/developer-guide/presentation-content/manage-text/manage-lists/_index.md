---
title: Διαχείριση λιστών με κουκίδες και αριθμημένων λιστών σε παρουσιάσεις με Java
linktitle: Διαχείριση λιστών
type: docs
weight: 60
url: /el/java/manage-lists/
keywords:
- κουκίδα
- λίστα με κουκίδες
- αριθμημένη λίστα
- σύμβολο κουκίδας
- εικόνα-κουκίδα
- προσαρμοσμένη κουκίδα
- πολυεπίπεδη λίστα
- δημιουργία κουκίδας
- προσθήκη κουκίδας
- προσθήκη λίστας
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε λίστες με κουκίδες, εικόνες, πολυεπίπεδες και αριθμημένες σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Java σας επιτρέπει να δημιουργείτε και να μορφοποιείτε μαστιγές και αριθμημένες λίστες σε παρουσιάσεις PowerPoint και OpenDocument. Ένα στοιχείο λίστας είναι μια παράγραφος της οποίας οι ρυθμίσεις κουκίδας ελέγχονται μέσω της μορφής της παραγράφου.

Χρησιμοποιήστε τη μέθοδο [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) για πρόσβαση στις ρυθμίσεις λίστας σε επίπεδο παραγράφου. Το κύριο σημείο εισόδου είναι [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--), το οποίο επιστρέφει ένα αντικείμενο [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/). Με αυτό το αντικείμενο, μπορείτε να ορίσετε τον τύπο της κουκίδας, το σύμβολο, την εικόνα, το χρώμα, το μέγεθος, το στυλ αρίθμησης και τον αρχικό αριθμό.

Αυτό το άρθρο δείχνει πώς να:

- δημιουργήσετε μια λίστα με κουκίδες με προσαρμοσμένο σύμβολο
- δημιουργήσετε μια εικόνα‑κουκίδα
- δημιουργήσετε μια πολυεπίπεδη λίστα ορίζοντας το βάθος της παραγράφου
- δημιουργήσετε μια αριθμημένη λίστα
- εξετάσετε και αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση
- διαβάσετε τις πραγματικές ενδείξεις λίστας και τους αριθμούς δίπλα στο κείμενο της παραγράφου

## **Δημιουργία λίστας με κουκίδες**

Για να δημιουργήσετε μια λίστα με κουκίδες, προσθέστε αντικείμενα [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) σε ένα [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) και ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) σε [BulletType.Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Symbol). Στη συνέχεια μπορείτε να ορίσετε το [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-), το [IBulletFormat.getColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getColor--) και το [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) για να ελέγξετε την εμφάνιση της κουκίδας.

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε μια λίστα με κουκίδες σε μια διαφάνεια:

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

![Τα σύμβολα κουκίδων](symbol_bullets.png)

## **Δημιουργία αριθμημένης λίστας**

Χρησιμοποιήστε αριθμημένες λίστες όταν η σειρά των στοιχείων έχει σημασία. Ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) σε [BulletType.Numbered](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Numbered). Μπορείτε επίσης να επιλέξετε μορφή αρίθμησης με το [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) ή να ορίσετε το [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) όταν η λίστα πρέπει να ξεκινά από τιμή διαφορετική από 1.

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε μια αριθμημένη λίστα σε μια διαφάνεια:

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

![Οι αριθμημένες κουκίδες](numbered_bullets.png)

## **Δημιουργία εικόνας‑κουκίδας**

Το Aspose.Slides σας επιτρέπει να αντικαταστήσετε ένα κανονικό σύμβολο κουκίδας με εικόνα. Οι εικόνες‑κουκίδες λειτουργούν καλύτερα με απλές εικόνες που παραμένουν αναγνώσιμες σε μικρό μέγεθος, όπως εικονίδια ή μικρά διαφανή αρχεία PNG.

{{% alert color="info" title="Note" %}}
Ιδανικά, εάν σκοπεύετε να αντικαταστήσετε το κανονικό σύμβολο κουκίδας με εικόνα, είναι καλύτερο να επιλέξετε ένα απλό γραφικό με διαφανές φόντο. Τέτοιες εικόνες λειτουργούν καλά ως προσαρμοσμένα σύμβολα κουκίδας.

Λάβετε υπόψη ότι η εικόνα θα κλιμακωθεί σε πολύ μικρό μέγεθος. Για αυτόν τον λόγο, συνιστούμε έντονα να επιλέξετε μια εικόνα που παραμένει καθαρή και οπτικά αποτελεσματική όταν χρησιμοποιείται ως κουκίδα σε λίστα.
{{% /alert %}}

Για να δημιουργήσετε μια εικόνα‑κουκίδα, προσθέστε μια εικόνα στο [Presentation.getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) και αντιστοιχίστε το επιστρεφόμενο αντικείμενο εικόνας στο [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--). Ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) σε [BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Picture) πριν αντιστοιχίσετε την εικόνα.

Ας υποθέσουμε ότι έχουμε ένα «image.png»:

![Μια εικόνα για τις κουκίδες](picture_for_bullets.png)

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε εικόνες‑κουκίδες σε μια διαφάνεια:

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

![Οι εικόνες‑κουκίδες](picture_bullets.png)

## **Δημιουργία πολυεπίπεδης λίστας**

Χρησιμοποιήστε το [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) για να τοποθετήσετε στοιχεία λίστας σε διαφορετικά επίπεδα. Το επίπεδο 0 είναι το υψηλότερο επίπεδο, το επίπεδο 1 είναι ενσωματωμένο κάτω από αυτό, κ.λπ.

Ο παρακάτω κώδικας Java δείχνει πώς να δημιουργήσετε μια πολυεπίπεδη λιστε με κουκίδες:

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

Για να αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση, προσπελάστε την στοχευμένη παράγραφο και ενημερώστε τις ρυθμίσεις της [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--). Οι ίδιες ιδιότητες που χρησιμοποιούνται για τη δημιουργία λιστών μπορούν να χρησιμοποιηθούν για την επιθεώρηση ή τροποποίηση λιστών που φορτώθηκαν από αρχείο PPT, PPTX ή ODP.

Ο παρακάτω κώδικας Java αλλάζει την πρώτη παράγραφο σε πλαίσιο κειμένου ώστε να χρησιμοποιεί στυλ αριθμημένης λίστας:

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

## **Ανάγνωση πραγματικών τιμών κουκίδας**

Κατά την εξαγωγή περιεχομένου παρουσίασης, διατηρήστε τις ενδείξεις λίστας παράλληλα με το κείμενο της παραγράφου. Καλέστε το [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--) και προσπελάστε το [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) για να αποκτήσετε τη θετική μορφή της κουκίδας. Ελέγξτε το [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) πριν διαβάσετε το [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--).

Για αριθμημένες λίστες, διακρίνετε τις τρεις ακόλουθες τιμές:

- Το [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) καθορίζει τη μορφή, όπως αραβικοί αριθμοί ακολουθούμενοι από τελεία ή πεζά γράμματα ακολουθούμενα από τελεία.
- Το [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) ορίζει τον αρχικό αριθμό για μια ομάδα αριθμημένων παραγράφων.
- Το [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) επιστρέφει την μορφοποιημένη ένδειξη για μια συγκεκριμένη παράγραφο. Για παράδειγμα, το δεύτερο στοιχείο σε λίστα που ξεκινά από 5 επιστρέφει `6.`.

Διατηρήστε το [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDepth--) με κάθε παράγραφο για να κρατήσετε το επίπεδο εμφώλευσής της. Η πραγματική ένδειξη δεν κωδικοποιεί ολόκληρη τη ιεραρχία: ένα ενσωματωμένο στοιχείο μπορεί να επιστρέψει `c.` αντί για συνδυασμένη ετικέτα όπως `6.c.`.

Ο παρακάτω αυτόνομος παράδειγμα δημιουργεί λίστες, τις αποθηκεύει σε παρουσίαση και ξαναφορτώνει την παρουσίαση για να αναφέρει το κείμενο, το βάθος, τον τύπο κουκίδας και την πραγματική τιμή κάθε παραγράφου. Η μικρή μπλε ένδειξη εικόνας δημιουργείται από ενσωματωμένο SVG.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Δημιουργία δείκτη εικόνας χωρίς εξωτερικό αρχείο εικόνας.
    SvgImage svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    IPPImage bulletImage = presentation.getImages().addImage(svg);

    class ListBuilder {
        void addParagraph(String text, short depth, byte type, short start, byte style) {
            Paragraph paragraph = new Paragraph();
            paragraph.setText(text);

            IParagraphFormat format = paragraph.getParagraphFormat();
            format.setDepth(depth);
            format.setMarginLeft(30 + depth * 40);
            format.setIndent(-28);
            format.setSpaceAfter(8);
            format.getDefaultPortionFormat().setFontHeight(22);
            format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
            format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
            format.getBullet().setType(type);
            format.getBullet().setBulletHardColor(NullableBool.True);
            format.getBullet().getColor().setColor(Color.BLACK);
            if (type == BulletType.Numbered) {
                format.getBullet().setNumberedBulletStyle(style);
                format.getBullet().setNumberedBulletStartWith(start);
            } else if (type == BulletType.Symbol) {
                format.getBullet().setChar('\u2022');
            } else if (type == BulletType.Picture) {
                format.getBullet().getPicture().setImage(bulletImage);
            }

            textFrame.getParagraphs().add(paragraph);
        }
    }

    ListBuilder list = new ListBuilder();
    list.addParagraph("First item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Second item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Next nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Deep item", (short) 2, BulletType.Numbered, (short) 4, NumberedBulletStyle.BulletRomanLCPeriod);
    list.addParagraph("Back to top level", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Symbol marker", (short) 0, BulletType.Symbol, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("No bullet", (short) 0, BulletType.None, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Picture marker", (short) 0, BulletType.Picture, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    IAutoShape loadedShape = (IAutoShape) loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Text | Depth | Type | Actual value");
    for (IParagraph paragraph : loadedShape.getTextFrame().getParagraphs()) {
        IBulletFormatEffectiveData bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        String marker;
        switch (bullet.getType()) {
            case BulletType.Numbered:
            case BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        String typeName = BulletType.getName(BulletType.class, bullet.getType());
        System.out.println(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

Οι πηγές λιστών εμφανίζονται παρακάτω.

![Λίστες που ξεκινούν από 5, ένθετα στοιχεία με γράμματα και ρωμαϊκούς αριθμούς, ένδειξη συμβόλου, παράγραφος χωρίς κουκίδα και μπλε ένδειξη εικόνας](actual_bullet_values.png)

Η αναφορά ταιριάζει με τις ενδείξεις που εμφανίζονται στο PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Για [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/), το [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) επιστρέφει `null`, όχι κενή συμβολοσειρά. Χειριστείτε αυτούς τους τύπους χωριστά: ο πρώτος δεν έχει ένδειξη, ενώ ο δεύτερος απαιτεί την εξαγωγή της εικόνας κουκίδας ξεχωριστά. Μια εικόνα‑κουκίδα δεν μπορεί να αναπαραχθεί μόνο με την εξαγωγή της ένδειξης κειμένου.

## **Συχνές ερωτήσεις**

**Μπορούν οι λίστες με κουκίδες και αριθμούς να εξαχθούν σε PDF ή εικόνες;**

Ναι. Το Aspose.Slides διατηρεί τη μορφοποίηση της λίστας όταν η μορφή προορισμού υποστηρίζει την αντίστοιχη διάταξη κειμένου και τις λειτουργίες κουκίδας.

**Μπορώ να επεξεργαστώ λίστες σε υπάρχουσες παρουσιάσεις;**

Ναι. Φορτώστε την παρουσίαση, προσπελάστε την στοχευμένη παράγραφο, ελέγξτε ή ενημερώστε τις ρυθμίσεις της [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) και αποθηκεύστε την παρουσίαση.

**Μπορούν οι λίστες να περιέχουν μη‑λατινικό κείμενο;**

Ναί. Το κείμενο των στοιχείων λίστας μπορεί να περιέχει χαρακτήρες Unicode, έτσι ώστε να μπορείτε να δημιουργείτε λίστες σε πολυγλωσσικές παρουσιάσεις. Βεβαιωθείτε ότι οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση υποστηρίζουν τους χαρακτήρες που χρειάζεστε.