---
title: Διαχείριση Παραγράφων Κειμένου PowerPoint σε Java
linktitle: Διαχείριση Παραγράφου
type: docs
weight: 40
url: /el/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- προσθήκη κειμένου
- προσθήκη παραγράφου
- διαχείριση κειμένου
- διαχείριση παραγράφου
- διαχείριση κουκκίδας
- εσοχή παραγράφου
- εσώματη εσοχή
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
- Java
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε παραγράφους, τμήματα, κουκκίδες, αριθμημένες λίστες, εσοχές, περιεχόμενο HTML και εικόνες παραγράφων με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Aspose.Slides for Java αντιπροσωπεύει το κείμενο ως ιεραρχία πλαισίων κειμένου, παραγράφων και τμημάτων:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) αντιπροσωπεύει το δοχείο κειμένου σε ένα σχήμα και παρέχει πρόσβαση στη συλλογή παραγράφων του.
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) αντιπροσωπεύει μία παράγραφο σε ένα πλαίσιο κειμένου και παρέχει πρόσβαση στα τμήματα και τη μορφοποίηση επιπέδου παραγράφου.
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) αντιπροσωπεύει ένα τμήμα κειμένου μέσα σε μια παράγραφο. Κάθε τμήμα μπορεί να έχει τη δική του μορφοποίηση κειμένου και χαρακτήρων.

Μια παράγραφος μπορεί επομένως να περιέχει κείμενο με διαφορετικές γραμματοσειρές, χρώματα, μεγέθη και άλλες μορφοποιήσεις χρησιμοποιώντας πολλαπλά τμήματα.

## **Δημιουργία και Μορφοποίηση Παραγράφων**

Δημιουργήστε παραγράφους στο πλαίσιο κειμένου ενός σχήματος και χρησιμοποιήστε τμήματα για τη μορφοποίηση μεμονωμένων τρεξίσεων κειμένου. Αυτή η ενότητα δείχνει πώς να συνδυάσετε πολλαπλά τμήματα σε κάθε παράγραφο και να εφαρμόσετε διαφορετικά χρώματα, μεγέθη γραμματοσειράς και στυλ.

### **Δημιουργία Παραγράφων με Πολλαπλά Τμήματα**

Το παρακάτω παράδειγμα Java δημιουργεί τρεις παραγράφους, η καθεμία από τις οποίες περιέχει τρεις τρεξίδες κειμένου στη συλλογή που επιστρέφεται από [IParagraph.getPortions](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getPortions--) . Επαναχρησιμοποιεί την προεπιλεγμένη παράγραφο και το κενό τμήμα της, στη συνέχεια προσθέτει τις υπόλοιπες παραγράφους και τμήματα. Η μορφοποίηση εφαρμόζεται μέσω του [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--) : το πρώτο τμήμα σε κάθε παράγραφο είναι κόκκινο, έντονο και 15 σημεία· το δεύτερο είναι μπλε, πλάγιο και 18 σημεία. Το τρίτο τμήμα διατηρεί την προεπιλεγμένη μορφοποίησή του:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Δημιουργία Λιστών με Κουκκίδες και Αρίθμηση**

Οργανώστε το κείμενο των παραγράφων σε λίστες με σύμβολα, αριθμούς ή προσαρμοσμένες εικόνες. Τα παραδείγματα σε αυτήν την ενότητα καλύπτουν τη μορφοποίηση κουκκίδων, τις πολυεπίπεδες λίστες και την προσαρμοσμένη έναρξη αριθμών.

### **Δημιουργία Λίστας με Κουκκίδες ή Αρίθμηση**

Οι κουκκίδες και η αρίθμηση κάνουν τα σχετικά στοιχεία πιο εύκολα στην ανάγνωση. Στο Aspose.Slides, οι ρυθμίσεις λίστας ορίζονται μέσω του [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) .

Αυτό το παράδειγμα Java προσθέτει μια κουκκίδα συμβόλου και ένα αριθμημένο στοιχείο στο ίδιο πλαίσιο κειμένου. Το [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) επιλέγει τον τύπο της κουκκίδας, ενώ το [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) παρέχει το σύμβολο και το [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) επιλέγει το στυλ αρίθμησης. Και τα δύο στοιχεία χρησιμοποιούν μαύρες κουκκίδες με ύψος 100 % και εσοχή παραγράφου 25 σημεία:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Οι κουκκίδες εικόνας σας επιτρέπουν να χρησιμοποιήσετε μια προσαρμοσμένη εικόνα αντί για σύμβολο ή αριθμό.

Αυτό το παράδειγμα Java προσθέτει μια εικόνα στη συλλογή εικόνων της παρουσίασης ως [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) και τη χρησιμοποιεί ως κουκκίδα παραγράφου. Καλεί το [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) για να χρησιμοποιήσει κουκκίδα εικόνας και ορίζει την εικόνα μέσω του [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) . Το [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) ορίζεται στο 100 % για να μεγέθυνει την κουκκίδα σχετικά με το κείμενο της παραγράφου:

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

### **Δημιουργία Πολυεπίπεδης Λίστας**

Ορίστε το [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) για να τοποθετήσετε τις παραγράφους σε διαφορετικά επίπεδα λίστας. Το κορυφαίο επίπεδο έχει βάθος `0`.

Αυτό το παράδειγμα Java αντιστοιχεί τιμές [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) από 0 έως 3 σε τέσσερις παραγράφους, δημιουργώντας ιεραρχία μέσα σε ένα πλαίσιο κειμένου. Κάθε παράγραφος χρησιμοποιεί μια κουκκίδα συμβόλου, με το [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) να εναλλάσσεται μεταξύ στρογγυλής κουκκίδας και παύλας για να διακρίνει τα γειτονικά επίπεδα:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Χρησιμοποιήστε το [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) για να ορίσετε τον αρχικό αριθμό που εμφανίζεται για μια αριθμημένη παράγραφο.

Αυτό το παράδειγμα Java ορίζει το [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) για να χρησιμοποιήσει αρίθμηση για τρεις παραγράφους και καθορίζει τιμές [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 2, 3 και 7. Η αρχική τιμή ρυθμίζεται ξεχωριστά για κάθε παράγραφο, επιτρέποντας την παράλειψη αριθμών:

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

## **Έλεγχος Διάταξης Παραγράφων και Ιδιοτήτων Λήξης**

Ρυθμίστε τα περιθώρια και τις εσοχές της παραγράφου για να ελέγξετε τη θέση της πρώτης γραμμής και των αναδιπλωμένων γραμμών. Μπορείτε επίσης να μορφοποιήσετε το σημείο λήξης της παραγράφου ξεχωριστά από τις ορατές τμηματικές μορφές.

### **Ορισμός Εσοχής Πρώτης Γραμμής**

Χρησιμοποιήστε τη μέθοδο [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η ρύθμιση μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετατοπίζει την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) όταν χρειάζεται να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δίνει σε τρεις παραγράφους το ίδιο [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 20 σημείων και τιμές [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 0, 20 και 40 σημείων. Οι πρώτες γραμμές ξεκινούν σταδιακά με μεγαλύτερες μετατοπίσεις, ενώ οι αναδιπλωμένες γραμμές διατηρούν το ίδιο αριστερό περιθώριο:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **Ορισμός Εσώματης Εσοχής**

Η εσώματη εσοχή είναι μια διάταξη παραγράφου στην οποία η πρώτη γραμμή ξεκινά αριστερά των υπολοίπων γραμμών. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με την ιδιότητα [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) . Ορίστε το `Indent` σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) ορίζει τη θέση του αριστερού περιθωρίου του σώματος της παραγράφου, και το [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε εσώματη εσοχή, ορίστε μια θετική τιμή `MarginLeft` και μια αρνητική τιμή `Indent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, εγγραφές γλωσσολογίου και άλλες παραγράφους όπου οι αναδιπλωμένες γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου αντί κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

Το παρακάτω παράδειγμα Java συνδυάζει τιμές [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 40 και 60 σημείων με τιμές [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) -20 και -30 σημείων. Σε κάθε παράγραφο, η πρώτη γραμμή ξεκινά αριστερά των αναδιπλωμένων γραμμών· η δεύτερη παράγραφος έχει πιο βαθιά εσώματη εσοχή:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **Ορισμός Ιδιοτήτων Τερματικού Τμηματος Παραγράφου**

Η μέθοδος [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) ελέγχει τη μορφοποίηση του σημείου λήξης της παραγράφου. Το παρακάτω παράδειγμα δημιουργεί ένα [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) με [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) 48 σημείων και [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) σε Times New Roman. Αναθέτει αυτή τη μορφοποίηση στο τερματικό σημείο της δεύτερης παραγράφου, αφήνοντας αμετάβλητα τα ορατά τμήματα κειμένου:

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

Για κανόνες παραγράφων που επηρεάζουν την αυτόματη αναδίπλωση και την στίξη στα τέλη γραμμής, δείτε [Control Line Breaking](/slides/el/java/text-formatting/#control-line-breaking) και [Control Hanging Punctuation](/slides/el/java/text-formatting/#control-hanging-punctuation).

Χρησιμοποιήστε το [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) για να μετρήσετε τις γραμμές που καταλαμβάνει μια παράγραφος μετά τη διάταξη του κειμένου, συμπεριλαμβανομένης της αυτόματης αναδίπλωσης. Αυτό είναι χρήσιμο κατά τον έλεγχο του μήκους κειμένου και της διάταξης σε πρότυπα παρουσίασης.

Μια παράγραφος είναι ένα αντικείμενο στο [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--) και μπορεί να καταλάβει αρκετές σχεδιασμένες γραμμές. Ένα ρητό διακοπή γραμμής μέσα σε μια παράγραφο αναγκάζει νέα γραμμή χωρίς να δημιουργεί άλλη παράγραφο. Η αυτόματη αναδίπλωση δημιουργεί γραμμές βάσει του διαθέσιμου πλάτους χωρίς να εισάγει ρητές διακοπές γραμμής στο κείμενο. Συνεπώς η καταμέτρηση παραγράφων ή χαρακτήρων νέας γραμμής δεν δίνει τον αριθμό των σχεδιασμένων γραμμών.

Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα κειμένου, μετρά τις γραμμές του, μειώνει το πλάτος του σχήματος και στη συνέχεια αντικαθιστά το κείμενο με μια πιο σύντομη συμβολοσειρά. Το παράδειγμα ενεργοποιεί την αναδίπλωση με το [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) και απενεργοποιεί την αυτόματη προσαρμογή με το [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) ώστε το πλάτος του σχήματος να ελέγχει την αναδίπλωση χωρίς αυτόματη σμίκρυνση του κειμένου ή αλλαγή μεγέθους του σχήματος. Κάθε μέτρηση χρησιμοποιεί το [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) . Οι διαστάσεις του σχήματος δίνονται σε σημεία. Τέλος, το παράδειγμα προσθέτει άλλη μια παράγραφο και αθροίζει τις μετρήσεις γραμμών σε όλο το πλαίσιο κειμένου.

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

Με αυτό το κείμενο και αυτές τις διαστάσεις, η σμίκρυνση του σχήματος αυξάνει τον αριθμό των γραμμών, ενώ η αντικατάσταση του κειμένου με τη σύντομη συμβολοσειρά τον μειώνει. Οι ακριβείς μετρήσεις μπορεί να διαφέρουν ανάλογα με τη διαθεσιμότητα και την υποκατάσταση γραμματοσειρών, το μέγεθος γραμματοσειράς, τα περιθώρια, την εσοχή, την αναδίπλωση και τις ρυθμίσεις αυτόματης προσαρμογής. Χρησιμοποιήστε τις γραμματοσειρές και τις ρυθμίσεις διάταξης που προορίζονται για το περιβάλλον στόχο όταν ελέγχετε ένα πρότυπο.

Ο μόνος ο αριθμός γραμμών δεν καθορίζει αν το κείμενο υπερβαίνει το δοχείο του. Το διαθέσιμο ύψος, το ύψος των γραμμών, η απόσταση παραγράφων και γραμμών και η συμπεριφορά αυτόματης προσαρμογής επίσης παίζουν ρόλο· ακόμη και μια μόνο γραμμή μπορεί να ξεπερνά το διαθέσιμο πλάτος όταν η αναδίπλωση είναι απενεργοποιημένη.

## **Εισαγωγή και Εξαγωγή Περιεχομένου Παραγράφων**

Χρησιμοποιήστε HTML για να εισάγετε κείμενο σε μια παρουσίαση ή να εξάγετε υπάρχουσες παραγράφους για χρήση εκτός αυτής. Αυτή η ενότητα δείχνει επίσης πώς να αποδίδετε μεμονωμένες παραγράφους ως εικόνες, συμπεριλαμβανομένων των παραγράφων σε κελιά πινάκων.

### **Εισαγωγή HTML Κειμένου σε Παραγράφους**

Χρησιμοποιήστε το [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) για να μετατρέψετε την σήμανση HTML σε παραγράφους και τμήματα σε ένα πλαίσιο κειμένου.

Αυτό το παράδειγμα Java διαβάζει HTML από αρχείο και περνά τη σήμανση στο [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) . Εκκαθαρίζει την προεπιλεγμένη παράγραφο του πλαισίου κειμένου ώστε το πλαίσιο να περιέχει μόνο το εισαγόμενο περιεχόμενο. Το ορθογώνιο σχήμα αφήνει περιθώριο 10 σημείων σε κάθε πλευρά της διαφάνειας:

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

Χρησιμοποιήστε το [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) για να εξάγετε ένα επιλεγμένο εύρος παραγράφων ως HTML. Όταν επαναχρησιμοποιείτε το κείμενο παρουσίασης σε ιστότοπο, μπορεί να θέλετε να διατηρήσετε τη τοπική έμφαση χωρίς να μεταφέρετε τη γραμματοσειρά, το μέγεθος ή τα στυλ του πλαισίου κειμένου. Ορίστε το [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) για να ελέγξετε πόσο μακριά ακολουθεί ο εξαγώγων η κληρονομιά μορφοποίησης.

Κατεβάστε την [sample presentation](text-inheritance.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Η πρώτη της διαφάνεια περιέχει ένα σχήμα κειμένου με το κείμενο "Inherited text; explicit red 18pt". Η είσοδος χρησιμοποιεί σκόπιμα πολλά επίπεδα μορφοποίησης:

- Το προεπιλεγμένο στυλ κειμένου της παρουσίασης παρέχει Calibri και μέγεθος 28 pt.
- Το στυλ κειμένου πρώτου επιπέδου του πλαισίου κειμένου παρέχει μπλε κείμενο και πλάγια γραφή.
- Η παράγραφος ορίζει ρητά έντονο κείμενο.
- Το δεύτερο τμήμα, "explicit red 18pt", ορίζει ρητά κόκκινο κείμενο και μέγεθος 18 pt.

Το παρακάτω πλήρες παράδειγμα εξάγει τις ίδιες παραγράφους τρεις φορές. Περνά το [TextToHtmlConversionOptions](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/) στη μέθοδο εξαγωγής και γράφει κάθε αποτέλεσμα σε ξεχωριστό αρχείο HTML UTF‑8:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
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

Το παραγόμενο HTML περιέχει το ακόλουθο CSS για το πρώτο τμήμα, "Inherited text; ". Ο πίνακας παραθέτει τις σχετικές δηλώσεις· άλλες παραγόμενες ιδιότητες παραλείπονται για σαφήνεια.

| Output | Relevant CSS for the first portion | Appearance |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Μπλε, έντονο, πλάγιο κείμενο 28 pt σε Calibri, αν η γραμματοσειρά είναι διαθέσιμη. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Μπλε, έντονο, πλάγιο κείμενο· η σελίδα ή ο φυλλομετρητής παρέχει τη γραμματοσειρά και το μέγεθος. |
| `ParagraphOnly.html` | `font-weight:bold` | Έντονο κείμενο· η σελίδα ή ο φυλλομετρητής παρέχει γραμματοσειρά, μέγεθος, χρώμα και πλάγια γραφή. |

Το δεύτερο τμήμα διατηρεί `color:#ff0000`, `font-size:18pt` και `font-weight:bold` σε όλες τις τρεις εξόδους. Διατηρεί επίσης πλάγια γραφή στα `All` και `TextBox`, αλλά όχι στο `ParagraphOnly`. Ο περιορισμός κληρονομιάς επομένως δεν αφαιρεί τη μορφοποίηση που έχει οριστεί ρητά σε παράγραφο ή τμήμα.

Ανοίξτε τα αρχεία στον ίδιο φυλλομετρητή για να τα συγκρίνετε. Στις δύο περιορισμένες λειτουργίες, οι παραλειπόμενες ιδιότητες CSS επιλύονται από τα στυλ της σελίδας προορισμού ή τις προεπιλογές του φυλλομετρητή, οπότε η τελική εμφάνιση εξαρτάται από το πού χρησιμοποιείται το HTML.

### **Απόδοση Παραγράφου ως Εικόνας**

Το [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) αποδίδει άμεσα μια μεμονωμένη παράγραφο και επιστρέφει ένα [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/). Αποθηκεύστε το αποτέλεσμα σε αρχείο ή ροή με το [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) . Δεν χρειάζεται να αποδώσετε το σχήμα-παιδί ή να περικόψετε bitmap χειροκίνητα.

Το [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) μπορεί να επιστρέψει `null` εάν η παράγραφος δεν βρεθεί στη γονική της συλλογή, δεν έχει έγκυρα όρια απόδοσης ή δεν μπορεί να αποδοθεί. Ελέγξτε το αποτέλεσμα πριν το αποθηκεύσετε και απελευθερώστε την εικόνα μετά τη χρήση.

#### **Απόδοση Παραγράφου στην Προεπιλεγμένη Κλίμακα**

Το παράδειγμα χρησιμοποιεί μια παρουσίαση με μία διαφάνεια της οποίας το πρώτο σχήμα είναι ένα πλαίσιο κειμένου με τρεις παραγράφους.

![The text box with three paragraphs](paragraph_to_image_input.png)

Το παρακάτω παράδειγμα επιλέγει τη δεύτερη παράγραφο με δείκτη 1 και καλεί το [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) χωρίς παραμέτρους κλίμακας. Ελέγχει ότι το σχήμα περιέχει την απαιτούμενη παράγραφο και ότι η απόδοση επιστρέφει εικόνα πριν καλέσει το [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) για να την αποθηκεύσει σε μορφή PNG. Το μπλοκ `finally` απελευθερώνει την εικόνα μετά τη χρήση.

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

#### **Απόδοση Παραγράφου σε Κελί Πίνακα με Κλίμακα**

Χρησιμοποιήστε την υπερφόρτωση του [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) που δέχεται τις παραμέτρους `float scaleX` και `float scaleY` για να ορίσετε τους οριζόντιους και κατακόρυφους συντελεστές κλίμακας. Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα, αποδίδει την παράγραφο στο πρώτο κελί του με διπλάσιο πλάτος και ύψος από την προεπιλεγμένη, και αποθηκεύει το αποτέλεσμα ως εικόνα PNG.

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

Ένας συντελεστής κλίμακας `1` διατηρεί αυτόν τον άξονα στο προεπιλεγμένο μέγεθος εικονοστοιχείου. Για παράδειγμα, `2` και για τους δύο παράγοντες παράγει μια εικόνα του οποίου το πλάτος και το ύψος είναι περίπου διπλάσιο του προεπιλεγμένου, με αποτέλεσμα τέσσερις φορές περισσότερα εικονοστοιχεία. Μεγαλύτεροι παράγοντες γενικά προσφέρουν πιο οξεία γραφή για ζουμά ή εξαγωγή υψηλής ανάλυσης, αλλά αυξάνουν επίσης τη μνήμη και το μέγεθος του αρχείου. Παράγοντες κάτω του `1` παράγουν μικρότερες εικόνες με λιγότερη λεπτομέρεια. Χρησιμοποιήστε ίσους παράγοντες για να διατηρήσετε την αναλογία διαστάσεων της παραγράφου· διαφορετικοί οριζόντιοι και κατακόρυφοι παράγοντες τεντώνονται ανεξάρτητα.

Η απόδοση ολόκληρου σχήματος με το [IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) παραμένει χρήσιμη όταν το αποτέλεσμα πρέπει να περιλαμβάνει το γέμισμα, το περίγραμμα ή άλλο οπτικό περιεχόμενο του σχήματος. Για εικόνα μόνο παραγράφου, χρησιμοποιήστε το [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) .

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς την αναδίπλωση γραμμών μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Ορίστε το [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) για να απενεργοποιήσετε την αναδίπλωση ώστε οι γραμμές να μην σπάνε στις άκρες του πλαισίου κειμένου.

**Πώς μπορώ να λάβω τα ακριβή όρια στοσλάιν μιας συγκεκριμένης παραγράφου;**

Χρησιμοποιήστε το [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) για να ανακτήσετε το ορθογώνιο περιθώριο της παραγράφου. Το [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) παρέχει τα όρια ενός μεμονωμένου τμήματος.

**Πού ελέγχεται η στοίχιση παραγράφου (αριστερά, δεξιά, κέντρο ή πλήρης στοίχιση);**

Το [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) είναι ρύθμιση επιπέδου παραγράφου και εφαρμόζεται σε όλη την παράγραφο ανεξάρτητα από τη μορφοποίηση των επιμέρους τμημάτων.

Για κάθετη στοίχιση τμημάτων με διαφορετικά μεγέθη γραμματοσειρών μέσα σε κάθε γραμμή, δείτε [Align Fonts Within a Line](/slides/el/java/text-formatting/#align-fonts-within-a-line).

**Μπορώ να ορίσω τη γλώσσα απόδοσης για μέρος μιας παραγράφου;**

Ναι. Ορίστε το [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) για μεμονωμένα τμήματα, ώστε μια παράγραφος να μπορεί να περιέχει κείμενο σε πολλαπλές γλώσσες.