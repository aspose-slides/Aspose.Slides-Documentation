---
title: Διαχείριση Παραγράφων Κειμένου PowerPoint σε Android
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
- διαχείριση κουκίδας
- εσοχή παραγράφου
- κρεμαστή εσοχή
- κουκίδα παραγράφου
- αριθμημένη λίστα
- λίστα με κουκίδες
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
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε παραγράφους, τμήματα, κουκίδες, αριθμημένες λίστες, εσοχές, περιεχόμενο HTML και εικόνες παραγράφων με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides for Android via Java αντιπροσωπεύει το κείμενο ως ιεραρχία πλαισίων κειμένου, παραγράφων και τμημάτων:

* [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) παριστά το δοχείο κειμένου σε ένα σχήμα και παρέχει πρόσβαση στη συλλογή των παραγράφων του.
* [IParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/) παριστά μία παράγραφο σε ένα πλαίσιο κειμένου και παρέχει πρόσβαση στα τμήματα και τη μορφοποίηση επιπέδου παραγράφου.
* [IPortion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/) παριστά μία ροή κειμένου μέσα σε μία παράγραφο. Κάθε τμήμα μπορεί να έχει το δικό του κείμενο και μορφοποίηση επιπέδου χαρακτήρα.

Μια παράγραφος μπορεί επομένως να περιέχει κείμενο με διαφορετικές γραμματοσειρές, χρώματα, μεγέθη και άλλες μορφοποιήσεις χρησιμοποιώντας πολλαπλά τμήματα.

## **Δημιουργία και Μορφοποίηση Παραγράφων**

### **Δημιουργία Παραγράφων με Πολλαπλά Τμήματα**

Τα παρακάτω βήματα δημιουργούν ένα πλαίσιο κειμένου με τρεις παραγράφους, η καθεμία από τις οποίες περιέχει τρία τμήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
4. Πρόσβαση στο [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του σχήματος.
5. Χρησιμοποιήστε την προεπιλεγμένη παράγραφο και προσθέστε δύο ακόμη αντικείμενα [IParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/) στο πλαίσιο κειμένου.
6. Προσθέστε αρκετά αντικείμενα [IPortion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/) ώστε κάθε παράγραφος να περιέχει τρία τμήματα. Η προεπιλεγμένη παράγραφος περιέχει ήδη ένα κενό τμήμα.
7. Ορίστε το κείμενο κάθε τμήματος.
8. Εφαρμόστε μορφοποίηση επιπέδου χαρακτήρα μέσω του [IPortion.getPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα Android via Java υλοποιεί τα βήματα:

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

## **Δημιουργία Κουκίδων και Αριθμημένων Λιστών**

### **Δημιουργία Λίστας με Κουκίδες ή Αριθμούς**

Οι κουκίδες και η αρίθμηση κάνουν τα συναφή στοιχεία πιο εύκολα στην ανάγνωση. Στο Aspose.Slides, οι ρυθμίσεις λίστας ορίζονται μέσω του [IBulletFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/).

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη επιλεγμένη διαφάνεια.
4. Πρόσβαση στο [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του σχήματος.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου.
6. Δημιουργήστε ένα [Paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraph/) για μια κουκίδα συμβόλου.
7. Ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setType-int-) σε [BulletType.Symbol](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/bullettype/) και καθορίστε τον χαρακτήρα της κουκίδας.
8. Ορίστε το κείμενο της παραγράφου, την εσοχή, το χρώμα της κουκίδας και το ύψος της κουκίδας.
9. Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
10. Δημιουργήστε μια δεύτερη παράγραφο και ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setType-int-) σε [BulletType.Numbered](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/bullettype/).
11. Διαμορφώστε το στυλ της αριθμημένης κουκίδας και προσθέστε την παράγραφο στο πλαίσιο κειμένου.
12. Αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα Android via Java δημιουργεί μια κουκίδα συμβόλου και μια αριθμημένη κουκίδα:

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

### **Χρήση Κουκίδων Εικόνας**

Οι κουκίδες εικόνας σάς επιτρέπουν να χρησιμοποιήσετε μια προσαρμοσμένη εικόνα αντί για σύμβολο ή αριθμό.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) και πρόσβαση στο [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του.
4. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου.
5. Φορτώστε την εικόνα της κουκίδας και προσθέστε την στη συλλογή εικόνων της παρουσίασης ως [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/).
6. Δημιουργήστε ένα [Paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraph/) και ορίστε το κείμενό του.
7. Ορίστε το [IBulletFormat.setType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setType-int-) σε [BulletType.Picture](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/bullettype/).
8. Εκχωρήστε την εικόνα μέσω του [IBulletFormat.getPicture](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#getPicture--) και ορίστε το ύψος της κουκίδας.
9. Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα Android via Java δημιουργεί μια κουκίδα εικόνας:

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

### **Δημιουργία Πολυστρωματικής Λίστας**

Ορίστε το [IParagraphFormat.setDepth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) για να τοποθετήσετε τις παραγράφους σε διαφορετικά επίπεδα λίστας. Το επάνω επίπεδο έχει βάθος `0`.

1. Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και πρόσβαση σε μια διαφάνεια.
2. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) και καθαρίστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου του.
3. Δημιουργήστε τέσσερις παραγράφους και διαμορφώστε τα σύμβολα των κουκίδων τους.
4. Ορίστε τις τιμές του [IParagraphFormat.setDepth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) σε `0`, `1`, `2` και `3`.
5. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου και αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα Android via Java δημιουργεί μια λίστα με τέσσερα επίπεδα κουκίδων:

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

### **Έναρξη Αριθμημένων Στοιχείων Λίστας με Προσαρμοσμένες Τιμές**

Χρησιμοποιήστε το [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) για να ορίσετε τον αρχικό αριθμό που εμφανίζεται για μια αριθμημένη παράγραφο.

1. Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) σε μια διαφάνεια.
2. Καθαρίστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου του σχήματος.
3. Δημιουργήστε τρεις αριθμημένες παραγράφους.
4. Ορίστε το [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) σε `2`, `3` και `7` για τις αντίστοιχες παραγράφους.
5. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου και αποθηκεύστε την παρουσίαση.

Αυτό το παράδειγμα Android via Java καθορίζει έναν προσαρμοσμένο αρχικό αριθμό για κάθε παράγραφο:

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

Χρησιμοποιήστε το [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η μέθοδος μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετατοπίζει την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) όταν θέλετε να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δημιουργεί διάφορες παραγράφους και εφαρμόζει διαφορετικές τιμές του [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) για να δείξει πώς η εσοχή της πρώτης γραμμής επηρεάζει τη διάταξη της παραγράφου.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Πρόσβαση στη στοχευόμενη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
4. Πρόσβαση στο [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του σχήματος και αφαίρεση της προεπιλεγμένης παραγράφου.
5. Δημιουργήστε πολλές παραγράφους και ορίστε διαφορετικές τιμές του [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) για αυτές.
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

![Η εσοχή πρώτης γραμμής των παραγράφων](first_line_indent.png)

### **Ορισμός Κρεμαστής Εσοχής**

Η κρεμαστή εσοχή είναι μια διάταξη παραγράφου στην οποία η πρώτη γραμμή ξεκινά αριστερότερα από τις υπόλοιπες γραμμές. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με το [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Δώστε μια αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή προς τα αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) ορίζει την αριστερή θέση του σώματος της παραγράφου, ενώ το [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ορίζει τη θέση της πρώτης γραμμής ως προς αυτό το περιθώριο. Για να δημιουργήσετε κρεμαστή εσοχή, δώστε μια θετική τιμή στο `setMarginLeft` και μια αρνητική τιμή στο `setIndent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, εγγραφές γλωσσογονικού και άλλες παραγράφους όπου οι γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου παρά κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Πρόσβαση στη στοχευόμενη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
4. Πρόσβαση στο [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του σχήματος και αφαίρεση της προεπιλεγμένης παραγράφου.
5. Δημιουργήστε παραγράφους και δώστε μια θετική τιμή στο [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) για κάθε παράγραφο.
6. Δώστε μια αρνητική τιμή στο [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) για να δημιουργήσετε το εφέ κρεμαστής εσοχής.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας δείχνει πώς να ορίσετε κρεμαστή εσοχή για μια παράγραφο:

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

![Η κρεμαστή εσοχή των παραγράφων](hanging_indent.png)

### **Ορισμός Ιδιοτήτων Τέλους Παραγράφου**

Το [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) ελέγχει τη μορφοποίηση του σημείου τέλους της παραγράφου. Το παρακάτω παράδειγμα εκχωρεί μέγεθος γραμματοσειράς και λατινική γραμματοσειρά στο σημείο τέλους της δεύτερης παραγράφου:

1. Φορτώστε μια [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και πρόσβαση σε μια διαφάνεια.
2. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) και καθαρίστε την προεπιλεγμένη του παράγραφο.
3. Δημιουργήστε δύο παραγράφους και προσθέστε τμήματα κειμένου σε αυτές.
4. Δημιουργήστε ένα [PortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portionformat/) για το σημείο τέλους της δεύτερης παραγράφου.
5. Ορίστε το [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) και το [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Εκχωρήστε τη μορφή με το [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) και αποθηκεύστε την παρουσίαση.

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

## **Καταμέτρηση Σχεδιασμένων Γραμμών**

Χρησιμοποιήστε το [IParagraph.getLinesCount](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) για να υπολογίσετε τις γραμμές που καταλαμβάνει μια παράγραφος μετά τη διάταξη του κειμένου, συμπεριλαμβανομένης της αυτόματης αναδίπλωσης. Αυτό είναι χρήσιμο όταν ελέγχετε το μήκος και τη διάταξη του κειμένου σε πρότυπα παρουσιάσεων.

Μια παράγραφος είναι ένα στοιχείο στο [ITextFrame.getParagraphs](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#getParagraphs--), και μπορεί να καταλάβει πολλές σχεδιασμένες γραμμές. Μια ρητή αλλαγή γραμμής μέσα σε μια παράγραφο προκαλεί νέα γραμμή χωρίς τη δημιουργία νέας παραγράφου. Η αυτόματη αναδίπλωση δημιουργεί γραμμές βασιζόμενη στο διαθέσιμο πλάτος χωρίς να εισάγει ρητές αλλαγές γραμμής στο κείμενο. Συνεπώς, η καταμέτρηση παραγράφων ή χαρακτήρων αλλαγής γραμμής δεν δίνει το αριθμό των σχεδιασμένων γραμμών.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα κειμένου, μετρά τις γραμμές του, στενεύει το σχήμα και στη συνέχεια αντικαθιστά το κείμενο με ένα πιο σύντομο. Η αναδίπλωση είναι ενεργοποιημένη και η αυτόματη προσαρμογή είναι απενεργοποιημένη ώστε το πλάτος του σχήματος να ελέγχει την αναδίπλωση χωρίς αυτόματη σύμπτυξη του κειμένου ή αλλαγή μεγέθους του σχήματος. Οι διαστάσεις του σχήματος δίνονται σε σημεία. Τέλος, το παράδειγμα προσθέτει μια ακόμη παράγραφο και αθροίζει τα πλήθη γραμμών σε όλο το πλαίσιο κειμένου.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Με αυτό το κείμενο και αυτές τις διαστάσεις, η στενότερη διάσταση του σχήματος αυξάνει τον αριθμό γραμμών, ενώ η αντικατάσταση του κειμένου με το σύντομο κείμενο τον μειώνει. Οι ακριβείς μετρήσεις μπορεί να διαφέρουν ανάλογα με τη διαθεσιμότητα και την αντικατάσταση γραμματοσειρών, το μέγεθος της γραμματοσειράς, τα περιθώρια, την εσοχή, την αναδίπλωση και τις ρυθμίσεις αυτόματης προσαρμογής. Χρησιμοποιήστε τις γραμματοσειρές και τις ρυθμίσεις διάταξης που προορίζονται για το περιβάλλον προορισμού όταν ελέγχετε ένα πρότυπο.

Ο μόνος αριθμός γραμμών δεν καθορίζει αν το κείμενο υπερβαίνει το δοχείο του. Το διαθέσιμο ύψος, οι ύψους γραμμών, η απόσταση μεταξύ παραγράφων και γραμμών, καθώς και η συμπεριφορά της αυτόματης προσαρμογής επίσης παίζουν ρόλο· ακόμη και μια μονή γραμμή μπορεί να ξεπεράσει το διαθέσιμο πλάτος όταν η αναδίπλωση είναι απενεργοποιημένη.

## **Εισαγωγή και Εξαγωγή Περιεχομένου Παραγράφων**

### **Εισαγωγή Κειμένου HTML σε Παραγράφους**

Χρησιμοποιήστε το [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) για να μετατρέψετε σήμανση HTML σε παραγράφους και τμήματα σε ένα πλαίσιο κειμένου.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Πρόσβαση σε μια διαφάνεια και προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/).
3. Πρόσβαση στο [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του σχήματος και καθαρίστε την προεπιλεγμένη παράγραφο.
4. Διαβάστε το αρχείο HTML προέλευσης.
5. Μεταβιβάστε τη συμβολοσειρά HTML στο [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα Android via Java εισάγει HTML σε ένα πλαίσιο κειμένου:

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

Χρησιμοποιήστε το [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) για να εξάγετε ένα επιλεγμένο εύρος παραγράφων ως HTML.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και φορτώστε την επιθυμητή παρουσίαση.
2. Πρόσβαση στη διαφάνεια και βρείτε το [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) που περιέχει το κείμενο.
3. Πρόσβαση στο [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/).
4. Κλήση του [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) με το δείκτη της αρχικής παραγράφου και τον αριθμό των παραγράφων προς εξαγωγή.
5. Γράψτε τη ληφθείσα συμβολοσειρά HTML σε αρχείο.

Αυτό το παράδειγμα Android via Java εξάγει όλες τις παραγράφους από το πρώτο σχήμα κειμένου:

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

Το [IParagraph.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#getImage--) αποδίδει απευθείας μια μεμονωμένη παράγραφο και επιστρέφει ένα [IImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/). Αποθηκεύστε το αποτέλεσμα σε αρχείο ή ρεύμα με το [IImage.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Δεν χρειάζεται να αποδώσετε το περιβάλλον σχήματος ή να περικόψετε bitmap χειροκίνητα.

Το [IParagraph.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#getImage--) μπορεί να επιστρέψει `null` αν η παράγραφος δεν βρεθεί στη συλλογή γονέα, δεν έχει έγκυρα όρια απόδοσης ή δεν μπορεί να αποδοθεί. Ελέγξτε το αποτέλεσμα πριν το αποθηκεύσετε και απελευθερώστε την εικόνα μετά τη χρήση.

#### **Απόδοση Παραγράφου στην Προεπιλεγμένη Κλίμακα**

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης με όνομα sample.pptx που περιέχει μία διαφάνεια, όπου το πρώτο σχήμα είναι ένα πλαίσιο κειμένου με τρεις παραγράφους.

![The text box with three paragraphs](paragraph_to_image_input.png)

Το παρακάτω παράδειγμα αποδίδει τη δεύτερη παράγραφο σε ένα κανονικό πλαίσιο κειμένου στην προεπιλεγμένη κλίμακα και αποθηκεύει τη ληφθείσα εικόνα σε μορφή PNG. Το μπλοκ `finally` διασφαλίζει ότι η εικόνα απελευθερώνεται σωστά.

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

![The paragraph image](paragraph_to_image_output.png)

#### **Απόδοση Παραγράφου σε Κελί Πίνακα με Κλιμάκωση**

Χρησιμοποιήστε την υπερφόρτωση του [IParagraph.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) που δέχεται τις παραμέτρους `float scaleX` και `float scaleY` για να ορίσετε τους οριζόντιους και κάθετους συντελεστές κλίμακας. Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα, αποδίδει την παράγραφο στο πρώτο του κελί με διπλάσιο πλάτος και ύψος από το προεπιλεγμένο και αποθηκεύει το αποτέλεσμα σε μορφή PNG.

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

Ένας συντελεστής κλίμακας `1` διατηρεί τον άξονα στην προεπιλεγμένη του τιμή σε εικονοστοιχεία. Για παράδειγμα, `2` για και τους δύο παράγοντες παράγει εικόνα του οποίου το πλάτος και το ύψος είναι περίπου διπλάσιοι από τις προεπιλεγμένες διαστάσεις, με αποτέλεσμα τέσσερις φορές περισσότερα εικονοστοιχεία. Μεγαλύτεροι συντελεστές συνήθως παράγουν πιο καθαρό κείμενο για μεγέθυνση ή υψηλής ανάλυσης εξαγωγή, αλλά αυξάνουν και τη χρήσ

η μνήμης και το μέγεθος του αρχείου. Συντελεστές κάτω από `1` παράγουν μικρότερες εικόνες με λιγότερη λεπτομέρεια. Χρησιμοποιήστε ίδιους συντελεστές για να διατηρήσετε την αναλογία διαστάσεων της παραγράφου· διαφορετικοί οριζόντιοι και κάθετοι παράγοντες τεντώσουν το αποτέλεσμα αυτόνομα.

Η απόδοση ολόκληρου σχήματος με το [IShape.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getImage--) παραμένει χρήσιμη όταν η έξοδος πρέπει να περιλαμβάνει το γέμισμα, το περίγραμμα ή άλλο οπτικό περιεχόμενο του σχήματος. Για εικόνα μόνο της παραγράφου, χρησιμοποιήστε το [IParagraph.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς την αλλαγή γραμμής μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Ορίστε το [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) για να απενεργοποιήσετε την αναδίπλωση ώστε οι γραμμές να μην σπάζουν στις άκρες του πλαισίου κειμένου.

**Πώς μπορώ να λάβω τις ακριβείς συντεταγμένες στο slide ενός συγκεκριμένου παραγράφου;**

Χρησιμοποιήστε το [IParagraph.getRect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/#getRect--) για να ανακτήσετε το ορθογώνιο που περιβάλλει την παράγραφο. Το [IPortion.getRect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/#getRect--) παρέχει τα όρια ενός μεμονωμένου τμήματος.

**Πού ελέγχεται η στοίχιση παραγράφου (αριστερά, δεξιά, κέντρο ή πλήρης ευθυγράμμιση);**

Το [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) είναι ρύθμιση επιπέδου παραγράφου και εφαρμόζεται σε ολόκληρη την παράγραφο ανεξάρτητα από τη μορφοποίηση των επιμέρους τμημάτων.

**Μπορώ να ορίσω τη γλώσσα διόρθωσης για μέρος μιας παραγράφου;**

Ναι. Ορίστε το [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) για μεμονωμένα τμήματα, ώστε μια παράγραφος να περιέχει κείμενο σε πολλαπλές γλώσσες.