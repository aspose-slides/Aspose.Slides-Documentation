---
title: Διαχείριση παραγράφων κειμένου PowerPoint στο Android
linktitle: Διαχείριση παραγράφου
type: docs
weight: 40
url: /el/androidjava/manage-paragraph/
keywords:
- προσθήκη κειμένου
- προσθήκη παραγράφου
- διαχείριση κειμένου
- διαχείριση παραγράφου
- διαχείριση κουκίδας
- εσοχή παραγράφου
- αναρρέουσα εσοχή
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
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Αποκτήστε τον απόλυτο έλεγχο μορφοποίησης παραγράφων με Aspose.Slides για Android—βελτιστοποιήστε την στοίχιση, το διάστημα & το στυλ σε παρουσιάσεις PPT, PPTX και ODP σε Java."
---
## **Εισαγωγή**

Το Aspose.Slides παρέχει όλες τις διεπαφές και κλάσεις που χρειάζεστε για εργασία με κείμενα PowerPoint, παραγράφους και τμήματα στη Java.

* Το Aspose.Slides παρέχει τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) για να μπορείτε να προσθέσετε αντικείμενα που αντιπροσωπεύουν μια παράγραφο. Ένα αντικείμενο `ITextFame` μπορεί να έχει μία ή πολλές παραγράφους (κάθε παράγραφος δημιουργείται μέσω αλλαγής γραμμής).
* Το Aspose.Slides παρέχει τη διεπαφή [IParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/) για να μπορείτε να προσθέσετε αντικείμενα που αντιπροσωπεύουν τμήματα. Ένα αντικείμενο `IParagraph` μπορεί να έχει ένα ή πολλά τμήματα (συλλογή αντικειμένων iPortions).
* Το Aspose.Slides παρέχει τη διεπαφή [IPortion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/) για να μπορείτε να προσθέσετε αντικείμενα που αντιπροσωπεύουν κείμενα και τις ιδιότητές τους μορφοποίησης.

Ένα αντικείμενο `IParagraph` είναι ικανό να χειρίζεται κείμενα με διαφορετικές ιδιότητες μορφοποίησης μέσω των υποκείμενων αντικειμένων `IPortion`.

## **Προσθήκη Πολλαπλών Παραγράφων που Περιέχουν Πολλαπλά Τμήματα Κειμένου**

Αυτά τα βήματα σας δείχνουν πώς να προσθέσετε ένα πλαίσιο κειμένου που περιέχει 3 παραγράφους και κάθε παράγραφος που περιέχει 3 τμήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Προσπελάστε τη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
4. Λάβετε το `ITextFrame` που συνδέεται με το [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/).
5. Δημιουργήστε δύο αντικείμενα [IParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/) και προσθέστε τα στη συλλογή `IParagraphs` του [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/).
6. Δημιουργήστε τρία αντικείμενα [IPortion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/) για κάθε νέο `IParagraph` (δύο αντικείμενα Portion για την προεπιλεγμένη Παράγραφο) και προσθέστε κάθε αντικείμενο `IPortion` στη συλλογή IPortion της αντίστοιχης `IParagraph`.
7. Ορίστε κάποιο κείμενο για κάθε τμήμα.
8. Εφαρμόστε τις προτιμητέες ιδιότητες μορφοποίησης σε κάθε τμήμα χρησιμοποιώντας τις ιδιότητες μορφοποίησης που εκτίθενται από το αντικείμενο `IPortion`.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Java είναι μια υλοποίηση των βημάτων για την προσθήκη παραγράφων που περιέχουν τμήματα:

```java
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθήκη AutoShape τύπου Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Πρόσβαση στο TextFrame του AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Δημιουργία παραγράφων και τμημάτων με διαφορετικές μορφοποιήσεις κειμένου
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    //Αποθήκευση PPTX στο δίσκο
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Διαχείριση Κουκίδων Παραγράφου**

Οι λίστες με κουκίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποδοτικά. Οι παραγράφοι με κουκίδες είναι πάντα πιο εύκολα αναγνώσιμα και κατανοητά.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Προσπελάστε τη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στην επιλεγμένη διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του autoshape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε την πρώτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraph/).
7. Ορίστε τον `Type` της κουκίδας σε `Symbol` και ορίστε το χαρακτήρα της κουκίδας.
8. Ορίστε το `Text` της παραγράφου.
9. Ορίστε το `Indent` της παραγράφου για την κουκίδα.
10. Ορίστε χρώμα για την κουκίδα.
11. Ορίστε ύψος για την κουκίδα.
12. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του `TextFrame`.
13. Προσθέστε τη δεύτερη παράγραφο και επαναλάβετε τη διαδικασία στα βήματα 7‑13.
14. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε μια κουκίδα παραγράφου:

```java
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Προσθέτει και προσπελάζει το Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Πρόσβαση στο πλαίσιο κειμένου του Autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Αφαιρεί την προεπιλεγμένη παράγραφο
    txtFrm.getParagraphs().removeAt(0);

    // Δημιουργία παραγράφου
    Paragraph para = new Paragraph();

    // Ορίζει το στυλ και το σύμβολο της κουκίδας της παραγράφου
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Ορίζει το κείμενο της παραγράφου
    para.setText("Welcome to Aspose.Slides");

    // Ορίζει την εσοχή της κουκίδας
    para.getParagraphFormat().setIndent(25);

    // Ορίζει το χρώμα της κουκίδας
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // ορίζει το IsBulletHardColor σε true για χρήση του δικού χρώματος κουκίδας

    // Ορίζει το ύψος της κουκίδας
    para.getParagraphFormat().getBullet().setHeight(100);

    // Προσθέτει την παράγραφο στο πλαίσιο κειμένου
    txtFrm.getParagraphs().add(para);

    // Δημιουργεί δεύτερη παράγραφο
    Paragraph para2 = new Paragraph();

    // Ορίζει τον τύπο και το στυλ της κουκίδας της παραγράφου
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Προσθέτει το κείμενο της παραγράφου
    para2.setText("This is numbered bullet");

    // Ορίζει την εσοχή της κουκίδας
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // ορίζει το IsBulletHardColor σε true για χρήση του δικού χρώματος κουκίδας

    // Ορίζει το ύψος της κουκίδας
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Προσθέτει την παράγραφο στο πλαίσιο κειμένου
    txtFrm.getParagraphs().add(para2);
    
    // Αποθηκεύει την τροποποιημένη παρουσίαση
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Διαχείριση Κουκίδων Εικόνας**

Οι λίστες με κουκίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποδοτικά. Οι παράγραφοι με εικόνες είναι εύκολα αναγνώσιμες και κατανοητές.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Προσπελάστε τη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του autoshape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε την πρώτη παράγραφο χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraph/).
7. Φορτώστε την εικόνα στο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/).
8. Ορίστε τον τύπο της κουκίδας σε [Picture](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ippimage/) και ορίστε την εικόνα.
9. Ορίστε το `Text` της παραγράφου.
10. Ορίστε το `Indent` της παραγράφου για την κουκίδα.
11. Ορίστε χρώμα για την κουκίδα.
12. Ορίστε ύψος για την κουκίδα.
13. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του `TextFrame`.
14. Προσθέστε τη δεύτερη παράγραφο και επαναλάβετε τη διαδικασία βάσει των προηγούμενων βημάτων.
15. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε και να διαχειριστείτε κουκίδες εικόνας:

```java
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation presentation = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = presentation.getSlides().get_Item(0);

    // Δημιουργεί την εικόνα για τις κουκίδες
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Προσθέτει και προσπελάζει το Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Πρόσβαση στο πλαίσιο κειμένου του autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Αφαιρεί την προεπιλεγμένη παράγραφο
    textFrame.getParagraphs().removeAt(0);

    // Δημιουργεί νέα παράγραφο
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Ορίζει το στυλ και την εικόνα της κουκίδας της παραγράφου
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Ορίζει το ύψος της κουκίδας
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Προσθέτει την παράγραφο στο πλαίσιο κειμένου
    textFrame.getParagraphs().add(paragraph);

    // Αποθηκεύει την παρουσίαση ως αρχείο PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Αποθηκεύει την παρουσίαση ως αρχείο PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Διαχείριση Πολυεπίπεδων Κουκίδων**

Οι λίστες με κουκίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποδοτικά. Οι πολυεπίπεδες κουκίδες είναι εύκολα αναγνώσιμες και κατανοητές.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Προσπελάστε τη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη νέα διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του autoshape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε την πρώτη παράγραφο μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraph/) και ορίστε το βάθος σε 0.
7. Δημιουργήστε τη δεύτερη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 1.
8. Δημιουργήστε την τρίτη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 2.
9. Δημιουργήστε την τέταρτη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 3.
10. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του `TextFrame`.
11. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε και να διαχειριστείτε πολυεπίπεδες κουκίδες:

```java
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθέτει και προσπελάζει το Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Πρόσβαση στο πλαίσιο κειμένου του δημιουργημένου autoshape
    ITextFrame text = aShp.addTextFrame("");

    // Καθαρίζει την προεπιλεγμένη παράγραφο
    text.getParagraphs().clear();

    // Προσθέτει την πρώτη παράγραφο
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ορίζει το επίπεδο της κουκίδας
    para1.getParagraphFormat().setDepth((short)0);

    // Προσθέτει τη δεύτερη παράγραφο
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ορίζει το επίπεδο της κουκίδας
    para2.getParagraphFormat().setDepth((short)1);

    // Προσθέτει την τρίτη παράγραφο
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ορίζει το επίπεδο της κουκίδας
    para3.getParagraphFormat().setDepth((short)2);

    // Προσθέτει την τέταρτη παράγραφο
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Ορίζει το επίπεδο της κουκίδας
    para4.getParagraphFormat().setDepth((short)3);

    // Προσθέτει τις παραγράφους στη συλλογή
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Αποθηκεύει την παρουσίαση ως αρχείο PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Διαχείριση Παραγράφου με Προσαρμοσμένη Αριθμημένη Λίστα**

Η διεπαφή [IBulletFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/) παρέχει την ιδιότητα [NumberedBulletStartWith](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) και άλλες που σας επιτρέπουν να διαχειρίζεστε παραγράφους με προσαρμοσμένη αρίθμηση ή μορφοποίηση.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Προσπελάστε τη διαφάνεια που περιέχει την παράγραφο.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) του autoshape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε την πρώτη παράγραφο μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraph/) και ορίστε το [NumberedBulletStartWith](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) σε 2.
7. Δημιουργήστε τη δεύτερη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το `NumberedBulletStartWith` σε 3.
8. Δημιουργήστε την τρίτη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το `NumberedBulletStartWith` σε 7.
9. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του `TextFrame`.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε και να διαχειριστείτε παραγράφους με προσαρμοσμένη αρίθμηση ή μορφοποίηση:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Πρόσβαση στο πλαίσιο κειμένου του δημιουργημένου autoshape
    ITextFrame textFrame = shape.getTextFrame();

    // Αφαίρεση της προεπιλεγμένης υπάρχουσας παραγράφου
    textFrame.getParagraphs().removeAt(0);

    // Πρώτη λίστα
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ορισμός Εσοχής Πρώτης Γραμμής για Παράγραφο**

Χρησιμοποιήστε τη μέθοδο [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η μέθοδος μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετακινεί την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) όταν πρέπει να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) όταν θέλετε να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δημιουργεί πολλές παραγράφους και εφαρμόζει διαφορετικές τιμές εσοχής για να δείξει πώς η εσοχή της πρώτης γραμμής επηρεάζει τη διάταξη της παραγράφου.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Προσπελάστε τη στοχευμένη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε πολλές παραγράφους και ορίστε διαφορετικές τιμές [Indent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) για αυτές.
6. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας δείχνει πώς να ορίσετε εσοχή παραγράφου:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η εσοχή πρώτης γραμμής των παραγράφων](first_line_indent.png)

## **Ορισμός Αναρρέουσας Εσοχής για Παράγραφο**

Η αναρρέουσα εσοχή είναι μια διάταξη παραγράφου στην οποία η πρώτη γραμμή αρχίζει αριστερά των υπολοίπων γραμμών. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με τη μέθοδο [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Ορίστε την εσοχή σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) ορίζει τη θέση του αριστερού περιθωρίου του σώματος της παραγράφου, ενώ το [IParagraphFormat.setIndent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε μια αναρρέουσα εσοχή, ορίστε μια θετική τιμή για το `MarginLeft` και μια αρνητική τιμή για το `Indent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, αναφορές, εισαγωγές γλωσσολογικών όρων και άλλες παραγράφους όπου οι περιτυλιγμένες γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου αντί κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Προσπελάστε τη στοχευμένη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε παραγράφους και ορίστε μια θετική τιμή [MarginLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) για κάθε παράγραφο.
6. Ορίστε μια αρνητική τιμή [Indent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) για να δημιουργήσετε το εφέ της αναρρέουσας εσοχής.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας δείχνει πώς να ορίσετε αναρρέουσα εσοχή για μια παράγραφο:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η αναρρέουσα εσοχή των παραγράφων](hanging_indent.png)

## **Διαχείριση Ιδιοτήτων Τέλους Παραγράφου**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
1. Λάβετε την αναφορά στη διαφάνεια που περιέχει την παράγραφο μέσω της θέσης της.
1. Προσθέστε ένα ορθογώνιο [autoshape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
1. Προσθέστε ένα [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) με δύο παραγράφους στο Rectangle.
1. Ορίστε το `FontHeight` και τον τύπο γραμματοσειράς για τις παραγράφους.
1. Ορίστε τις ιδιότητες End για τις παραγράφους.
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε τις ιδιότητες End για παραγράφους στο PowerPoint:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εισαγωγή HTML Κειμένου σε Παραγράφους**

Το Aspose.Slides παρέχει βελτιωμένη υποστήριξη για την εισαγωγή HTML κειμένου σε παραγράφους.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/).
2. Προσπελάστε τη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσθέστε και προσπελάστε το `autoshape` [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/).
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `ITextFrame`.
6. Διαβάστε το πηγαίο αρχείο HTML σε έναν TextReader.
7. Δημιουργήστε την πρώτη παράγραφο μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraph/).
8. Προσθέστε το περιεχόμενο του αρχείου HTML, διαβασμένο από το TextReader, στη [ParagraphCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraphcollection/) του TextFrame.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Java είναι μια υλοποίηση των βημάτων για την εισαγωγή HTML κειμένων σε παραγράφους:

```java
// Δημιουργία κενής παρουσίασης
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην προεπιλεγμένη πρώτη διαφάνεια της παρουσίασης
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθήκη του AutoShape για τη φιλοξενία του περιεχομένου HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Προσθήκη πλαισίου κειμένου στο σχήμα
    ashape.addTextFrame("");

    // Διαγραφή όλων των παραγράφων στο προστεθέν πλαίσιο κειμένου
    ashape.getTextFrame().getParagraphs().clear();

    // Φόρτωση του αρχείου HTML χρησιμοποιώντας StreamReader
    TextReader tr = new StreamReader("file.html");

    // Προσθήκη κειμένου από τον HTML StreamReader στο πλαίσιο κειμένου
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Αποθήκευση παρουσίασης
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εξαγωγή Κειμένου Παραγράφου σε HTML**

Το Aspose.Slides παρέχει βελτιωμένη υποστήριξη για την εξαγωγή κειμένων (που περιέχονται σε παραγράφους) σε HTML.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και φορτώστε την επιθυμητή παρουσίαση.
2. Προσπελάστε τη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσπελάστε το σχήμα που περιέχει το κείμενο που θα εξαχθεί σε HTML.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframe/) του σχήματος.
5. Δημιουργήστε ένα αντικείμενο `StreamWriter` και προσθέστε το νέο αρχείο HTML.
6. Ορίστε έναν αρχικό δείκτη στο StreamWriter και εξάγετε τις προτιμώμενες παραγράφους.

Αυτός ο κώδικας Java δείχνει πώς να εξάγετε τα κείμενα παραγράφων PowerPoint σε HTML:

```java
// Φόρτωση του αρχείου παρουσίασης
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Πρόσβαση στην προεπιλεγμένη πρώτη διαφάνεια της παρουσίασης
    ISlide slide = pres.getSlides().get_Item(0);

    // Απαιτούμενος δείκτης
    int index = 0;

    // Πρόσβαση στο προστεθέν σχήμα
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Δημιουργία αρχείου εξόδου HTML
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Εξαγωγή πρώτης παραγράφου ως HTML
    // Εγγραφή δεδομένων παραγράφων σε HTML παρέχοντας τον αρχικό δείκτη παραγράφου, το σύνολο των παραγράφων που θα αντιγραφούν
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αποθήκευση Παραγράφου ως Εικόνα**

Σε αυτήν την ενότητα, θα εξετάσουμε δύο παραδείγματα που δείχνουν πώς να αποθηκεύσετε μια παράγραφο κειμένου, που αντιπροσωπεύεται από τη διεπαφή [IParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/), ως εικόνα. Και τα δύο παραδείγματα περιλαμβάνουν την απόκτηση της εικόνας ενός σχήματος που περιέχει την παράγραφο χρησιμοποιώντας τις μεθόδους `getImage` της διεπαφής [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/), τον υπολογισμό των ορίων της παραγράφου εντός του σχήματος και την εξαγωγή της ως bitmap εικόνα. Αυτές οι προσεγγίσεις σας επιτρέπουν να εξάγετε συγκεκριμένα τμήματα κειμένου από παρουσιάσεις PowerPoint και να τα αποθηκεύσετε ως ξεχωριστές εικόνες, κάτι που μπορεί να είναι χρήσιμο σε διάφορα σενάρια.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης με όνομα sample.pptx με μία διαφάνεια, όπου το πρώτο σχήμα είναι ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους.

![Το πλαίσιο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

**Παράδειγμα 1**

Σε αυτό το παράδειγμα, εξάγουμε τη δεύτερη παράγραφο ως εικόνα. Για να το κάνουμε αυτό, εξάγουμε την εικόνα του σχήματος από την πρώτη διαφάνεια της παρουσίασης και στη συνέχεια υπολογίζουμε τα όρια της δεύτερης παραγράφου στο πλαίσιο κειμένου του σχήματος. Η παράγραφος στη συνέχεια επανασχεδιάζεται σε μια νέα bitmap εικόνα, η οποία αποθηκεύεται σε μορφή PNG. Αυτή η μέθοδος είναι ιδιαίτερα χρήσιμη όταν χρειάζεται να αποθηκεύσετε μια συγκεκριμένη παράγραφο ως ξεχωριστή εικόνα, διατηρώντας τις ακριβείς διαστάσεις και τη μορφοποίηση του κειμένου.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Αποθηκεύει το σχήμα στη μνήμη ως bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Δημιουργεί ένα bitmap σχήματος από τη μνήμη.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Υπολογίζει τα όρια της δεύτερης παραγράφου.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // Υπολογίζει τις συντεταγμένες και το μέγεθος της εικόνας εξόδου (ελάχιστο μέγεθος - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Κόβει το bitmap του σχήματος για να πάρει μόνο το bitmap της παραγράφου.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Το αποτέλεσμα:

![Η εικόνα της παραγράφου](paragraph_to_image_output.png)

**Παράδειγμα 2**

Σε αυτό το παράδειγμα, επεκτείνουμε την προγενέστερη προσέγγιση προσθέτοντας παράγοντες κλίμακας στην εικόνα παραγράφου. Το σχήμα εξάγεται από την παρουσίαση και αποθηκεύεται ως εικόνα με παράγοντα κλιμάκωσης `2`. Αυτό επιτρέπει ένα υψηλότερης ανάλυσης αποτέλεσμα κατά την εξαγωγή της παραγράφου. Τα όρια της παραγράφου υπολογίζονται μετά τον υπολογισμό της κλίμακας. Η κλιμάκωση μπορεί να είναι ιδιαίτερα χρήσιμη όταν απαιτείται πιο λεπτομερής εικόνα, για παράδειγμα για χρήση σε υψηλής ποιότητας έντυπο υλικό.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Αποθηκεύει το σχήμα στη μνήμη ως bitmap με κλιμάκωση.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Δημιουργεί ένα bitmap σχήματος από τη μνήμη.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Υπολογίζει τα όρια της δεύτερης παραγράφου.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // Υπολογίζει τις συντεταγμένες και το μέγεθος της εικόνας εξόδου (ελάχιστο μέγεθος - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Κόβει το bitmap του σχήματος για να πάρει μόνο το bitmap της παραγράφου.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς τη συρραφή γραμμών μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Χρησιμοποιήστε τη ρύθμιση συρραφής του πλαισίου κειμένου ([setWrapText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) για να απενεργοποιήσετε τη συρραφή ώστε οι γραμμές να μην σπάζουν στις άκρες του πλαισίου.

**Πώς μπορώ να λάβω τα ακριβή όρια στο slide ενός συγκεκριμένου τμήματος παραγράφου;**

Μπορείτε να ανακτήσετε το ορθογώνιο περιορισμών της παραγράφου (και ακόμη και ενός μεμονωμένου τμήματος) για να γνωρίζετε τη θέση και το μέγεθός του στην διαφάνεια.

**Πού ελέγχεται η στοίχιση παραγράφου (αριστερά/δεξιά/κέντρο/πλήρης δικαιολογία);**

Η [Alignment](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) είναι ρύθμιση επιπέδου παραγράφου στο [ParagraphFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraphformat/); εφαρμόζεται σε ολόκληρη την παράγραφο ανεξάρτητα από τη μορφοποίηση των επιμέρους τμημάτων.

**Μπορώ να ορίσω γλώσσα ελέγχου ορθογραφίας μόνο για μέρος μιας παραγράφου (π.χ. μια λέξη);**

Ναι. Η γλώσσα ορίζεται σε επίπεδο τμήματος ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), ώστε να μπορούν να συνυπάρχουν πολλαπλές γλώσσες μέσα σε μια ενιαία παράγραφο.