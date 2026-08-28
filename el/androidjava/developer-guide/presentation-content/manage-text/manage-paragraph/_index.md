---
title: Διαχείριση Παραγράφων Κειμένου PowerPoint στο Android
linktitle: Διαχείριση Παραγράφου
type: docs
weight: 40
url: /el/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
  - προσθήκη κειμένου
  - προσθήκη παραγράφου
  - διαχείριση κειμένου
  - διαχείριση παραγράφου
  - διαχείριση κουκκίδας
  - εσοχή παραγράφου
  - εσοχή κρέμασης
  - κουκκίδα παραγράφου
  - αριθμημένη λίστα
  - λίστα με κουκκίδες
  - ιδιότητες παραγράφου
  - εισαγωγή HTML
  - κείμενο σε HTML
  - παράγραφος σε HTML
  - παράγραφος σε εικόνα
  - κείμενο σε εικόνα
  - εξαγωγή παραγράφου
  - PowerPoint
  - παρουσίαση
  - Android
  - Java
  - Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε παραγράφους, τμήματα, κουκκίδες, αριθμημένες λίστες, εσοχές, περιεχόμενο HTML και εικόνες παραγράφων με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides για Android μέσω Java αντιπροσωπεύει το κείμενο ως ιεραρχία πλαισίων κειμένου, παραγράφων και τμημάτων:

* [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) αντιπροσωπεύει το περιέκτη κειμένου σε ένα σχήμα και παρέχει πρόσβαση στη συλλογή παραγράφων.
* [IParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/) αντιπροσωπεύει μία παράγραφο σε ένα πλαίσιο κειμένου και παρέχει πρόσβαση στα τμήματα της και στη μορφοποίηση επιπέδου παραγράφου.
* [IPortion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/) αντιπροσωπεύει ένα τμήμα κειμένου μέσα σε μια παράγραφο. Κάθε τμήμα μπορεί να έχει το δικό του κείμενο και μορφοποίηση επιπέδου χαρακτήρων.

Μία παράγραφος μπορεί λοιπόν να περιέχει κείμενο με διαφορετικές γραμματοσειρές, χρώματα, μεγέθη και άλλη μορφοποίηση χρησιμοποιώντας πολλαπλά τμήματα.

## **Δημιουργία και Μορφοποίηση Παραγράφων**

### **Δημιουργία Παραγράφων με Πολλαπλά Τμήματα**

Τα παρακάτω βήματα δημιουργούν ένα πλαίσιο κειμένου με τρεις παραγράφους, η κάθε μία να περιέχει τρία τμήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Προσπελάστε τη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του σχήματος.
5. Χρησιμοποιήστε την προεπιλεγμένη παράγραφο και προσθέστε δύο ακόμη αντικείμενα [IParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/) στο πλαίσιο κειμένου.
6. Προσθέστε αρκετά αντικείμενα [IPortion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/) ώστε κάθε παράγραφος να περιέχει τρία τμήματα. Η προεπιλεγμένη παράγραφος περιέχει ήδη ένα κενό τμήμα.
7. Ορίστε το κείμενο κάθε τμήματος.
8. Εφαρμόστε μορφοποίηση επιπέδου χαρακτήρων μέσω του [IPortion.getPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα Android μέσω Java εφαρμόζει τα βήματα:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Δημιουργία Λιστών με Κουκκίδες και Αριθμούς**

### **Δημιουργία Λίστας με Κουκκίδες ή Αριθμούς**

Οι κουκκίδες και η αρίθμηση κάνουν τα σχετιζόμενα στοιχεία πιο εύκολα στην ανάγνωση. Στο Aspose.Slides, οι ρυθμίσεις λίστας ορίζονται μέσω του [IBulletFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/).

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Προσπελάστε τη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στην επιλεγμένη διαφάνεια.
4. Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του σχήματος.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου.
6. Δημιουργήστε ένα [Paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraph/) για μια συμβολική κουκκίδα.
7. Ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setType-int-) σε [BulletType.Symbol](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/bullettype/) και καθορίστε τον χαρακτήρα της κουκκίδας.
8. Ορίστε το κείμενο της παραγράφου, την εσοχή, το χρώμα της κουκκίδας και το ύψος της κουκκίδας.
9. Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
10. Δημιουργήστε δεύτερη παράγραφο και ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setType-int-) σε [BulletType.Numbered](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/bullettype/).
11. Διαμορφώστε το στυλ αριθμημένης κουκκίδας και προσθέστε την παράγραφο στο πλαίσιο κειμένου.
12. Αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα Android μέσω Java δημιουργεί μια συμβολική κουκκίδα και μια αριθμημένη κουκκίδα:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Χρήση Εικόνας ως Κουκκίδα**

Οι εικόνες ως κουκκίδες σας επιτρέπουν να χρησιμοποιήσετε μια προσαρμοσμένη εικόνα αντί για σύμβολο ή αριθμό.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Προσπελάστε τη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) και προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του.
4. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου.
5. Φορτώστε την εικόνα της κουκκίδας και προσθέστε την στη συλλογή εικόνων της παρουσίασης ως [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/).
6. Δημιουργήστε ένα [Paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraph/) και ορίστε το κείμενό του.
7. Ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setType-int-) σε [BulletType.Picture](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/bullettype/).
8. Αντιστοιχίστε την εικόνα μέσω του [IBulletFormat.getPicture](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#getPicture--) και ορίστε το ύψος της κουκκίδας.
9. Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα Android μέσω Java δημιουργεί μια εικόνα-κουκκίδα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Δημιουργία Πολλαπλών Επιπέδων Λίστας**

Ορίστε το [IParagraphFormat.setDepth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) για να τοποθετήσετε τις παραγράφους σε διαφορετικά επίπεδα μιας λίστας. Το ανώτερο επίπεδο έχει βάθος `0`.

1. Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και προσπελάστε μια διαφάνεια.
2. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) και αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου του.
3. Δημιουργήστε τέσσερις παραγράφους και διαμορφώστε τα σύμβολα των κουκκίδων τους.
4. Ορίστε τις τιμές [IParagraphFormat.setDepth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) τους σε `0`, `1`, `2` και `3`.
5. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου και αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα Android μέσω Java δημιουργεί μια λίστα με τέσσερα επίπεδα κουκκίδων:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Έναρξη Αριθμημένων Στοιχείων Λίστας από Προσαρμοσμένες Τιμές**

Χρησιμοποιήστε το [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) για να ορίσετε τον αρχικό αριθμό που εμφανίζεται για μια αριθμημένη παράγραφο.

1. Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) σε μια διαφάνεια.
2. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου του σχήματος.
3. Δημιουργήστε τρεις αριθμημένες παραγράφους.
4. Ορίστε το [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) σε `2`, `3` και `7` για τις αντίστοιχες παραγράφους.
5. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου και αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα Android μέσω Java αντιστοιχίζει έναν προσαρμοσμένο αριθμό έναρξης σε κάθε παράγραφο:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Διάταξης Παραγράφου και Ιδιοτήτων Τέλους**

### **Ορισμός Εσοχής Πρώτης Γραμμής**

Χρησιμοποιήστε το [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η μέθοδος μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετακινεί την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) όταν θέλετε να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δημιουργεί αρκετές παραγράφους και εφαρμόζει διαφορετικές τιμές [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) για να δείξει πώς η εσοχή της πρώτης γραμμής επηρεάζει τη διάταξη της παραγράφου.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Προσπελάστε τη στοχευόμενη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του σχήματος και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε πολλές παραγράφους και ορίστε διαφορετικές τιμές [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) για αυτές.
6. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας δείχνει πώς να ορίσετε εσοχή παραγράφου:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η εσοχή της πρώτης γραμμής των παραγράφων](first_line_indent.png)

### **Ορισμός Εσώματος Κρέμασης**

Η εσώματος κρέμασης είναι διάταξη παράγραφου όπου η πρώτη γραμμή αρχίζει πιο αριστερά από τις υπόλοιπες γραμμές. Στο Aspose.Slides, αυτή την επίδραση δημιουργείτε με το [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Δώστε μια αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή προς τα αριστερά σχετικά με το σώμα της παραγράφου.

Στην πράξη, το [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) ορίζει τη θέση του αριστερού περιθωρίου του σώματος της παραγράφου, ενώ το [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε εσώματος κρέμασης, δώστε μια θετική τιμή στο `setMarginLeft` και μια αρνητική τιμή στο `setIndent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, λεξιλογικές καταχωρήσεις και άλλες παραγράφους όπου οι γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου και όχι κάτω από το πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Προσπελάστε τη στοχευόμενη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του σχήματος και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε παραγράφους και δώστε μια θετική τιμή στο [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) για κάθε παράγραφο.
6. Δώστε μια αρνητική τιμή στο [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) για να δημιουργήσετε το εφέ εσώματος κρέμασης.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας δείχνει πώς να ορίσετε εσώματος κρέμασης για μια παράγραφο:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η εσώματος κρέμασης των παραγράφων](hanging_indent.png)

### **Ορισμός Ιδιοτήτων Τέλους Παραγράφου**

Το [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) ελέγχει τη μορφοποίηση του συμβόλου τέλους παραγράφου. Το παρακάτω παράδειγμα εκχωρεί μέγεθος γραμματοσειράς και λατινική γραμματοσειρά στο σύμβολο τέλους της δεύτερης παραγράφου:

1. Φορτώστε ένα [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και προσπελάστε μια διαφάνεια.
2. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) και καθαρίστε την προεπιλεγμένη παράγραφο.
3. Δημιουργήστε δύο παραγράφους και προσθέστε τμήματα κειμένου σε αυτές.
4. Δημιουργήστε ένα [PortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portionformat/) για το σύμβολο τέλους της δεύτερης παραγράφου.
5. Ορίστε το [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) και το [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Αναθέστε τη μορφοποίηση με το [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) και αποθηκεύστε την παρουσίαση.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εισαγωγή και Εξαγωγή Περιεχομένου Παραγράφων**

### **Εισαγωγή HTML Κειμένου σε Παραγράφους**

Χρησιμοποιήστε το [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) για να μετατρέψετε σήμανση HTML σε παραγράφους και τμήματα σε ένα πλαίσιο κειμένου.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Προσπελάστε μια διαφάνεια και προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/).
3. Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του σχήματος και αφαιρέστε την προεπιλεγμένη παράγραφο.
4. Διαβάστε το πηγαίο αρχείο HTML.
5. Περικήστε τη συμβολοσειρά HTML στο [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα Android μέσω Java εισάγει HTML σε ένα πλαίσιο κειμένου:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Εξαγωγή Κειμένου Παραγράφου σε HTML**

Χρησιμοποιήστε το [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) για να εξάγετε μια επιλεγμένη περιοχή παραγράφων ως HTML.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και φορτώστε την επιθυμητή παρουσίαση.
2. Προσπελάστε τη διαφάνεια και βρείτε το [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) που περιέχει το κείμενο.
3. Προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του σχήματος.
4. Καλέστε το [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) με τον δείκτη της αρχικής παραγράφου και τον αριθμό των παραγράφων προς εξαγωγή.
5. Γράψτε τη ληφθείσα συμβολοσειρά HTML σε αρχείο.

Αυτό το παράδειγμα Android μέσω Java εξάγει όλες τις παραγράφους από το πρώτο πλαίσιο κειμένου:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Απόδοση Παραγράφου ως Εικόνας**

Η μέθοδος [IParagraph.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#getImage--) αποδίδει άμεσα μια μεμονωμένη παράγραφο και επιστρέφει ένα [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/). Αποθηκεύστε το αποτέλεσμα σε αρχείο ή ροή με τη [IImage.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Δεν χρειάζεται να αποδώσετε το περιβάλλον σχήματος ή να κόψετε το bitmap χειροκίνητα.

Η μέθοδος [IParagraph.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#getImage--) μπορεί να επιστρέψει `null` εάν η παράγραφος δεν βρεθεί στη γονική συλλογή, δεν διαθέτει έγκυρα όρια απόδοσης ή δεν μπορεί να αποδοθεί. Ελέγξτε το αποτέλεσμα πριν το αποθηκεύσετε και απελευθερώστε την επιστρεφόμενη εικόνα μετά τη χρήση.

#### **Απόδοση Παραγράφου στην Προεπιλεγμένη Κλίμακα**

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης με όνομα sample.pptx με μία διαφάνεια, όπου το πρώτο σχήμα είναι ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους.

![Το πλαίσιο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

Το παρακάτω παράδειγμα αποδίδει τη δεύτερη παράγραφο σε ένα κανονικό σχήμα κειμένου στην προεπιλεγμένη κλίμακα και αποθηκεύει την εικόνα σε μορφή PNG. Το τμήμα `finally` εξασφαλίζει ότι η εικόνα αποδεσμεύεται σωστά.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η εικόνα της παραγράφου](paragraph_to_image_output.png)

#### **Απόδοση Παραγράφου σε Κελί Πίνακα με Κλίμακα**

Χρησιμοποιήστε την υπερφόρτωση του [IParagraph.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) που δέχεται παραμέτρους `float scaleX` και `float scaleY` για να ορίσετε τους οριζόντιους και κάθετους παράγοντες κλίμακας. Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα, αποδίδει την παράγραφο στο πρώτο του κελί με διπλάσιο πλάτος και ύψος από την προεπιλογή και αποθηκεύει το αποτέλεσμα ως εικόνα PNG.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Ένας παράγοντας κλίμακας `1` διατηρεί τον άξονα στην προεπιλεγμένη του διάσταση σε εικονοστοιχεία. Για παράδειγμα, `2` και για τους δύο παράγοντες παράγει μια εικόνα του πλάτους και του ύψους περίπου δύο φορές τις προεπιλεγμένες διαστάσεις, με αποτέλεσμα τέσσερις φορές περισσότερα εικονοστοιχεία. Μεγαλύτεροι παράγοντες γενικά παρέχουν πιο καθαρό κείμενο για ζουμ ή εξαγωγή υψηλής ανάλυσης, αλλά αυξάνουν επίσης τη χρήση μνήμης και το μέγεθος του αρχείου. Παράγοντες κάτω από `1` παράγουν μικρότερες εικόνες με λιγότερη λεπτομέρεια. Χρησιμοποιήστε ίσους παράγοντες για να διατηρήσετε την αναλογία διαστάσεων της παραγράφου· διαφορετικοί οριζόντιοι και κάθετοι παράγοντες τεντώνουν το αποτέλεσμα ανεξάρτητα.

Η απόδοση ολόκληρου σχήματος με τη [IShape.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getImage--) παραμένει χρήσιμη όταν η έξοδος πρέπει να περιλαμβάνει το γέμισμα, το περίγραμμα ή άλλο οπτικό περιεχόμενο του σχήματος. Για εικόνα μόνο της παραγράφου, χρησιμοποιήστε το [IParagraph.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς τη συσσώρευση κειμένου μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Ορίστε το [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) για να απενεργοποιήσετε τη συσσώρευση ώστε οι γραμμές να μην σπάνε στις άκρες του πλαισίου κειμένου.

**Πώς μπορώ να λάβω τα ακριβή όρια εντός της διαφάνειας για μια συγκεκριμένη παράγραφο;**

Χρησιμοποιήστε το [IParagraph.getRect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#getRect--) για να ανακτήσετε το ορθογώνιο περιορισμού της παραγράφου. Το [IPortion.getRect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/#getRect--) παρέχει τα όρια ενός μεμονωμένου τμήματος.

**Πού ελέγχεται η στοίχιση παραγράφου (αριστερά, δεξιά, κέντρο ή πλήρης στοίχιση);**

Το [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) είναι ρύθμιση επιπέδου παραγράφου και εφαρμόζεται σε ολόκληρη την παράγραφο ανεξάρτητα από τη μορφοποίηση των επιμέρους τμημάτων.

**Μπορώ να ορίσω τη γλώσσα ελέγχου για μέρος μιας παραγράφου;**

Ναι. Ορίστε το [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) για μεμονωμένα τμήματα, ώστε μια παράγραφος να μπορεί να περιέχει κείμενο σε πολλαπλές γλώσσες.