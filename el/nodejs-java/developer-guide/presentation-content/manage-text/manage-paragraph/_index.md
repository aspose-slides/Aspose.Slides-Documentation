---
title: Διαχείριση Παραγράφων Κειμένου PowerPoint σε JavaScript
linktitle: Διαχείριση Παραγράφου
type: docs
weight: 40
url: /el/nodejs-java/manage-paragraph/
keywords:
- προσθήκη κειμένου
- προσθήκη παραγράφου
- διαχείριση κειμένου
- διαχείριση παραγράφου
- διαχείριση κουκίδας
- εσοχή παραγράφου
- εξαρτημένη εσοχή
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Αποκτήστε πλήρη έλεγχο της μορφοποίησης παραγράφων με Aspose.Slides για Node.js μέσω Java - βελτιώστε την ευθυγράμμιση, το διάστιχο & το στυλ σε παρουσιάσεις PPT, PPTX και ODP σε JavaScript."
---
## **Εισαγωγή**

Η Aspose.Slides παρέχει όλες τις κλάσεις που χρειάζεστε για την εργασία με κείμενα PowerPoint, παραγράφους και τμήματα σε Java.

* Η Aspose.Slides παρέχει την κλάση [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) ώστε να μπορείτε να προσθέτετε αντικείμενα που αντιπροσωπεύουν μια παράγραφο. Ένα αντικείμενο `TextFame` μπορεί να περιέχει μία ή πολλές παραγράφους (κάθε παράγραφος δημιουργείται μέσω μιας αλλαγής γραμμής).
* Η Aspose.Slides παρέχει την κλάση [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/) ώστε να μπορείτε να προσθέτετε αντικείμενα που αντιπροσωπεύουν τμήματα. Ένα αντικείμενο `Paragraph` μπορεί να περιέχει ένα ή πολλά τμήματα (συλλογή αντικειμένων τμήματος κειμένου).
* Η Aspose.Slides παρέχει την κλάση [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/) ώστε να μπορείτε να προσθέτετε αντικείμενα που αντιπροσωπεύουν κείμενα και τις ιδιότητες μορφοποίησής τους.

Ένα αντικείμενο `Paragraph` είναι ικανό να διαχειρίζεται κείμενα με διαφορετικές ιδιότητες μορφοποίησης μέσω των υποκείμενων αντικειμένων `Portion`.

## **Προσθήκη Πολλαπλών Παραγράφων που Περιέχουν Πολλαπλά Τμήματα**

Αυτά τα βήματα δείχνουν πώς να προσθέσετε ένα πλαίσιο κειμένου που περιέχει 3 παραγράφους και κάθε παράγραφος που περιέχει 3 τμήματα:

1. Δημιουργήστε μια实例 της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στην αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) Rectangle στη διαφάνεια.
4. Λάβετε το `ITextFrame` που σχετίζεται με το [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/).
5. Δημιουργήστε δύο αντικείμενα [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/) και προσθέστε τα στη συλλογή `IParagraphs` του [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/).
6. Δημιουργήστε τρία αντικείμενα [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/) για κάθε νέο `Paragraph` (δύο αντικείμενα Portion για την προεπιλεγμένη Paragraph) και προσθέστε κάθε αντικείμενο `Portion` στη συλλογή `IPortion` της κάθε `Paragraph`.
7. Ορίστε κάποιο κείμενο για κάθε τμήμα.
8. Εφαρμόστε τις προτιμώμενες ιδιότητες μορφοποίησης σε κάθε τμήμα χρησιμοποιώντας τις ιδιότητες μορφοποίησης που εκτίθενται από το αντικείμενο `Portion`.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας JavaScript είναι μια υλοποίηση των βημάτων για την προσθήκη παραγράφων που περιέχουν τμήματα:

```javascript
// Δημιουργία κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var slide = pres.getSlides().get_Item(0);
    // Προσθήκη AutoShape τύπου Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Πρόσβαση στο TextFrame του AutoShape
    var tf = ashp.getTextFrame();
    // Δημιουργία παραγράφων και τμημάτων με διαφορετικές μορφές κειμένου
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // Αποθήκευση του PPTX στον δίσκο
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Διαχείριση Κουκίδων Παραγράφων**

Οι λίστες με κουκίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποτελεσματικά. Οι παράγραφοι με κουκίδες είναι πάντα πιο εύκολο να διαβαστούν και να κατανοηθούν.

1. Δημιουργήστε μια实例 της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στην αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) του auto‑shape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/).
7. Ορίστε το `Type` της σφαίρας για την παράγραφο σε `Symbol` και ορίστε το χαρακτήρα σφαίρας.
8. Ορίστε το `Text` της παραγράφου.
9. Ορίστε το `Indent` της παραγράφου για τη σφαίρα.
10. Ορίστε χρώμα για τη σφαίρα.
11. Ορίστε ύψος της σφαίρας.
12. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του `TextFrame`.
13. Προσθέστε τη δεύτερη παράγραφο και επαναλάβετε τη διαδικασία των βημάτων 7‑13.
14. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε μια σφαίρα παραγράφου:

```javascript
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var slide = pres.getSlides().get_Item(0);
    // Προσθήκη και πρόσβαση στο AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Πρόσβαση στο πλαίσιο κειμένου του AutoShape
    var txtFrm = aShp.getTextFrame();
    // Αφαίρεση της προεπιλεγμένης παραγράφου
    txtFrm.getParagraphs().removeAt(0);
    // Δημιουργία παραγράφου
    var para = new aspose.slides.Paragraph();
    // Ορίζει το στυλ σφαίρας παραγράφου και το σύμβολο
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Ορίζει το κείμενο της παραγράφου
    para.setText("Welcome to Aspose.Slides");
    // Ορίζει την εσοχή της σφαίρας
    para.getParagraphFormat().setIndent(25);
    // Ορίζει το χρώμα της σφαίρας
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // ορίζει IsBulletHardColor σε true για χρήση δικού χρώματος σφαίρας
    // Ορίζει το ύψος της σφαίρας
    para.getParagraphFormat().getBullet().setHeight(100);
    // Προσθέτει την παράγραφο στο πλαίσιο κειμένου
    txtFrm.getParagraphs().add(para);
    // Δημιουργεί δεύτερη παράγραφο
    var para2 = new aspose.slides.Paragraph();
    // Ορίζει τον τύπο σφαίρας παραγράφου και το στυλ
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Ορίζει το κείμενο της παραγράφου
    para2.setText("This is numbered bullet");
    // Ορίζει την εσοχή της σφαίρας
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // ορίζει IsBulletHardColor σε true για χρήση δικού χρώματος σφαίρας
    // Ορίζει το ύψος της σφαίρας
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Προσθέτει την παράγραφο στο πλαίσιο κειμένου
    txtFrm.getParagraphs().add(para2);
    // Αποθηκεύει την τροποποιημένη παρουσίαση
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Διαχείριση Σφαίρων Εικόνας**

Οι λίστες με σφαίρες εικόνας σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποτελεσματικά. Οι παράγραφοι με σφαίρες εικόνας είναι εύκολο να διαβαστούν και να κατανοηθούν.

1. Δημιουργήστε μια实例 της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στην αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) του auto‑shape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/).
7. Φορτώστε την εικόνα σε [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/).
8. Ορίστε τον τύπο σφαίρας σε [Picture](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) και ορίστε την εικόνα.
9. Ορίστε το `Text` της παραγράφου.
10. Ορίστε το `Indent` της παραγράφου για τη σφαίρα.
11. Ορίστε χρώμα για τη σφαίρα.
12. Ορίστε ύψος για τη σφαίρα.
13. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του `TextFrame`.
14. Προσθέστε τη δεύτερη παράγραφο και επαναλάβετε τη διαδικασία με τα προηγούμενα βήματα.
15. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε και να διαχειριστείτε σφαίρες εικόνας:

```javascript
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
var presentation = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var slide = presentation.getSlides().get_Item(0);
    // Δημιουργεί την εικόνα για τις σφαίρες
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Προσθήκη και πρόσβαση στο AutoShape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Πρόσβαση στο πλαίσιο κειμένου του AutoShape
    var textFrame = autoShape.getTextFrame();
    // Αφαίρεση της προεπιλεγμένης παραγράφου
    textFrame.getParagraphs().removeAt(0);
    // Δημιουργία νέας παραγράφου
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Ορίζει το στυλ σφαίρας της παραγράφου και την εικόνα
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Ορίζει το ύψος της σφαίρας
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Προσθήκη παραγράφου στο πλαίσιο κειμένου
    textFrame.getParagraphs().add(paragraph);
    // Αποθηκεύει την παρουσίαση ως αρχείο PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Αποθηκεύει την παρουσίαση ως αρχείο PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Διαχείριση Πολυεπίπεδων Σφαίρων**

Οι λίστες με σφαίρες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποτελεσματικά. Οι πολυεπίπεδες σφαίρες είναι εύκολο να διαβαστούν και να κατανοηθούν.

1. Δημιουργήστε μια实例 της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στην αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη νέα διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) του auto‑shape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/) και ορίστε το βάθος σε 0.
7. Δημιουργήστε το δεύτερο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 1.
8. Δημιουργήστε το τρίτο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 2.
9. Δημιουργήστε το τέταρτο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 3.
10. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του `TextFrame`.
11. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε και να διαχειριστείτε πολυεπίπεδες σφαίρες:

```javascript
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var slide = pres.getSlides().get_Item(0);
    // Προσθήκη και πρόσβαση στο AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Πρόσβαση στο πλαίσιο κειμένου του δημιουργημένου AutoShape
    var text = aShp.addTextFrame("");
    // Καθαρισμός της προεπιλεγμένης παραγράφου
    text.getParagraphs().clear();
    // Προσθήκη της πρώτης παραγράφου
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Ορίζει το επίπεδο σφαίρας
    para1.getParagraphFormat().setDepth(0);
    // Προσθήκη της δεύτερης παραγράφου
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Ορίζει το επίπεδο σφαίρας
    para2.getParagraphFormat().setDepth(1);
    // Προσθήκη της τρίτης παραγράφου
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Ορίζει το επίπεδο σφαίρας
    para3.getParagraphFormat().setDepth(2);
    // Προσθήκη της τέτατης παραγράφου
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Ορίζει το επίπεδο σφαίρας
    para4.getParagraphFormat().setDepth(3);
    // Προσθήκη παραγράφων στη συλλογή
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // Αποθηκεύει την παρουσίαση ως αρχείο PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Διαχείριση Παραγράφου με Προσαρμοσμένη Αριθμημένη Λίστα**

Η κλάση [BulletFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bulletformat/) παρέχει την ιδιότητα [NumberedBulletStartWith](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) και άλλες που σας επιτρέπουν να διαχειρίζεστε παραγράφους με προσαρμοσμένη αρίθμηση ή μορφοποίηση.

1. Δημιουργήστε μια实例 της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στη διαφάνεια που περιέχει την παράγραφο.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) του auto‑shape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/) και ορίστε το [NumberedBulletStartWith](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) σε 2.
7. Δημιουργήστε το δεύτερο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το `NumberedBulletStartWith` σε 3.
8. Δημιουργήστε το τρίτο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το `NumberedBulletStartWith` σε 7.
9. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του `TextFrame`.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε και να διαχειριστείτε παραγράφους με προσαρμοσμένη αρίθμηση ή μορφοποίηση:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Πρόσβαση στο πλαίσιο κειμένου του δημιουργημένου autoshape
    var textFrame = shape.getTextFrame();
    // Αφαιρεί την προεπιλεγμένη υπάρχουσα παράγραφο
    textFrame.getParagraphs().removeAt(0);
    // Πρώτη λίστα
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ορισμός Εσοχής Πρώτης Γραμμής για Παράγραφο**

Χρησιμοποιήστε τη μέθοδο [ParagraphFormat.setIndent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setindent/) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η μέθοδος μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετακινεί την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [ParagraphFormat.setIndent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setindent/) όταν χρειάζεται να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δημιουργεί πολλαπλές παραγράφους και εφαρμόζει διαφορετικές τιμές εσοχής για να δείξει πώς η εσοχή της πρώτης γραμμής επηρεάζει τη διάταξη της παραγράφου.

1. Δημιουργήστε μια实例 της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στην επιλεγμένη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε πολλαπλές παραγράφους και ορίστε διαφορετικές τιμές [Indent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setindent/) για αυτές.
6. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας δείχνει πώς να ορίσετε εσοχή παραγράφου:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η εσοχή της πρώτης γραμμής των παραγράφων](first_line_indent.png)

## **Ορισμός Εξαρτημένης Εσοχής για Παράγραφο**

Η εξαρτημένη εσοχή (hanging indent) είναι μια διάταξη παραγράφου στην οποία η πρώτη γραμμή ξεκινά αριστερά των υπολοίπων γραμμών. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με τη μέθοδο [ParagraphFormat.setIndent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setindent/). Ορίστε την εσοχή σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) ορίζει τη θέση αριστερά του σώματος της παραγράφου, ενώ το [ParagraphFormat.setIndent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setindent/) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε εξαρτημένη εσοχή, ορίστε μια θετική τιμή `MarginLeft` και μια αρνητική τιμή `Indent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, εγγραφές γλωσσολογικών όρων και άλλες παραγράφους όπου οι περιτυλιγμένες γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου αντί κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε μια实例 της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στη στοχευμένη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε παραγράφους και ορίστε μια θετική τιμή [MarginLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) για κάθε παράγραφο.
6. Ορίστε μια αρνητική τιμή [Indent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setindent/) για να δημιουργήσετε το εφέ της εξαρτημένης εσοχής.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας δείχνει πώς να ορίσετε εξαρτημένη εσοχή για μια παράγραφο:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η εξαρτημένη εσοχή των παραγράφων](hanging_indent.png)

## **Διαχείριση Ιδιοτήτων Run Τέλους Παραγράφου για Παράγραφο**

1. Δημιουργήστε μια实例 της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
1. Λάβετε την αναφορά για τη διαφάνεια που περιέχει την παράγραφο μέσω της θέσης της.
1. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Προσθέστε ένα [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) με δύο παραγράφους στο Rectangle.
1. Ορίστε το `FontHeight` και τον τύπο γραμματοσειράς για τις παραγράφους.
1. Ορίστε τις ιδιότητες End για τις παραγράφους.
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε τις ιδιότητες End για παραγράφους στο PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Εισαγωγή HTML Κειμένου σε Παραγράφους**

Η Aspose.Slides παρέχει ενισχυμένη υποστήριξη για την εισαγωγή HTML κειμένου σε παραγράφους.

1. Δημιουργήστε μια实例 της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στην αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε και αποκτήστε πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) του `AutoShape`.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Διαβάστε το πηγαίο αρχείο HTML σε έναν `TextReader`.
7. Δημιουργήστε το πρώτο αντικείμενο παραγράφου μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/).
8. Προσθέστε το περιεχόμενο του αρχείου HTML από τον αναγνώστη `TextReader` στη [ParagraphCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphcollection/) του `TextFrame`.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας JavaScript είναι μια υλοποίηση των βημάτων για την εισαγωγή HTML κειμένων σε παραγράφους:

```javascript
// Δημιουργία κενής παρουσίασης
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην προεπιλεγμένη πρώτη διαφάνεια της παρουσίασης
    var slide = pres.getSlides().get_Item(0);
    // Προσθήκη του AutoShape για τοποθέτηση του περιεχομένου HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Προσθήκη πλαισίου κειμένου στο σχήμα
    ashape.addTextFrame("");
    // Καθαρισμός όλων των παραγράφων στο προστεθέν πλαίσιο κειμένου
    ashape.getTextFrame().getParagraphs().clear();
    // Φόρτωση του αρχείου HTML με χρήση stream reader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Προσθήκη κειμένου από το stream reader HTML στο πλαίσιο κειμένου
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Αποθήκευση της παρουσίασης
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Εξαγωγή Κειμένου Παραγράφων σε HTML**

Η Aspose.Slides παρέχει ενισχυμένη υποστήριξη για την εξαγωγή κειμένων (που περιέχονται σε παραγράφους) σε HTML.

1. Δημιουργήστε μια实例 της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και φορτώστε την επιθυμητή παρουσίαση.
2. Πρόσβαση στην αναφορά της σχετικής διαφάνειας μέσω του δείκτη της.
3. Πρόσβαση στο σχήμα που περιέχει το κείμενο που θα εξαχθεί σε HTML.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) του σχήματος.
5. Δημιουργήστε μια实例 του `StreamWriter` και προσθέστε το νέο αρχείο HTML.
6. Ορίστε έναν αρχικό δείκτη στο `StreamWriter` και εξάγετε τις προτιμώμενες παραγράφους.

Αυτός ο κώδικας JavaScript δείχνει πώς να εξάγετε τα κείμενα παραγράφων PowerPoint σε HTML:

```javascript
// Φόρτωση του αρχείου παρουσίασης
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Πρόσβαση στην προεπιλεγμένη πρώτη διαφάνεια της παρουσίασης
    var slide = pres.getSlides().get_Item(0);
    // Επιθυμητός δείκτης
    var index = 0;
    // Πρόσβαση στο προστεθέν σχήμα
    var ashape = slide.getShapes().get_Item(index);
    // Δημιουργία αρχείου εξόδου HTML
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Εξαγωγή της πρώτης παραγράφου ως HTML
    // Γράψιμο δεδομένων παραγράφων σε HTML παρέχοντας τον δείκτη έναρξης παραγράφου και τον συνολικό αριθμό παραγράφων που θα αντιγραφούν
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αποθήκευση Παράγραφου ως Εικόνα**

Σε αυτήν την ενότητα, θα εξετάσουμε δύο παραδείγματα που δείχνουν πώς να αποθηκεύσετε μια παράγραφο κειμένου, που αντιπροσωπεύεται από την κλάση [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/), ως εικόνα. Και τα δύο παραδείγματα περιλαμβάνουν την απόσπαση της εικόνας ενός σχήματος που περιέχει την παράγραφο χρησιμοποιώντας τις μεθόδους `getImage` από την κλάση [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/), τον υπολογισμό των ορίων της παραγράφου εντός του σχήματος και την εξαγωγή της ως bitmap εικόνα. Αυτές οι προσεγγίσεις επιτρέπουν την εξαγωγή συγκεκριμένων τμημάτων του κειμένου από παρουσιάσεις PowerPoint και την αποθήκευσή τους ως ξεχωριστές εικόνες, κάτι που μπορεί να είναι χρήσιμο για περαιτέρω χρήση σε διάφορα σενάρια.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης με όνομα **sample.pptx** που περιέχει μία διαφάνεια, όπου το πρώτο σχήμα είναι ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους.

![Το πλαίσιο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

**Παράδειγμα 1**

Σε αυτό το παράδειγμα, εξάγουμε τη δεύτερη παράγραφο ως εικόνα. Για να το κάνουμε αυτό, εξάγουμε την εικόνα του σχήματος από την πρώτη διαφάνεια της παρουσίασης και στη συνέχεια υπολογίζουμε τα όρια της δεύτερης παραγράφου στο πλαίσιο κειμένου του σχήματος. Η παράγραφος έπειτα επανασχεδιάζεται σε μια νέα bitmap εικόνα, η οποία αποθηκεύεται σε μορφή PNG. Αυτή η μέθοδος είναι ιδιαίτερα χρήσιμη όταν χρειάζεται να αποθηκεύσετε μια συγκεκριμένη παράγραφο ως ξεχωριστή εικόνα, διατηρώντας τις ακριβείς διαστάσεις και τη μορφοποίηση του κειμένου.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Αποθήκευση του σχήματος στη μνήμη ως bitmap.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Δημιουργία bitmap σχήματος από τη μνήμη.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Υπολογισμός των ορίων της δεύτερης παραγράφου.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Υπολογισμός των συντεταγμένων και του μεγέθους για την εικόνα εξόδου (ελάχιστο μέγεθος - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Περικοπή του bitmap σχήματος για να ληφθεί μόνο το bitmap της παραγράφου.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Το αποτέλεσμα:

![Η εικόνα της παραγράφου](paragraph_to_image_output.png)

**Παράδειγμα 2**

Σε αυτό το παράδειγμα, επεκτείνουμε την προηγούμενη προσέγγιση προσθέτοντας παράγοντες κλιμάκωσης στην εικόνα της παραγράφου. Το σχήμα εξάγεται από την παρουσίαση και αποθηκεύεται ως εικόνα με παράγοντα κλιμάκωσης `2`. Αυτό επιτρέπει εξαγωγή υψηλότερης ανάλυσης όταν εξάγουμε την παράγραφο. Τα όρια της παραγράφου υπολογίζονται έπειτα λαμβάνοντας υπόψη την κλίμακα. Η κλιμάκωση μπορεί να είναι ιδιαίτερα χρήσιμη όταν απαιτείται πιο λεπτομερής εικόνα, για παράδειγμα για χρήση σε υλικά υψηλής ποιότητας εκτύπωσης.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Αποθήκευση του σχήματος στη μνήμη ως bitmap με κλιμάκωση.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Δημιουργία bitmap σχήματος από τη μνήμη.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Υπολογισμός των ορίων της δεύτερης παραγράφου.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Υπολογισμός των συντεταγμένων και του μεγέθους για την εικόνα εξόδου (ελάχιστο μέγεθος - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Περικοπή του bitmap σχήματος για να ληφθεί μόνο το bitmap της παραγράφου.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς την αναδίπλωση κειμένου μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Χρησιμοποιήστε τη ρύθμιση αναδίπλωσης του πλαίσιο κειμένου ([setWrapText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/setwraptext/)) για να κλείσετε την αναδίπλωση ώστε οι γραμμές να μην σπάνε στις άκρες του πλαισίου.

**Πώς μπορώ να λάβω τα ακριβή όρια στο slide για μια συγκεκριμένη παράγραφο;**

Μπορείτε να ανακτήσετε το ορθογώνιο περιγράμματος της παραγράφου (και ακόμη ενός μοναδικού τμήματος) για να γνωρίζετε τη ακριβή θέση και το μέγεθός του στο slide.

**Πού ελέγχεται η στοίχιση της παραγράφου (αριστερά/δεξιά/κέντρο/δικαιολογημένο);**

Το [setAlignment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setalignment/) είναι μια μέθοδος ρύθμισης επιπέδου παραγράφου στο [ParagraphFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/); εφαρμόζεται σε ολόκληρη την παράγραφο ανεξάρτητα από την μορφοποίηση των μεμονωμένων τμημάτων.

**Μπορώ να ορίσω γλώσσα ελέγχου ορθογραφίας μόνο για ένα τμήμα μιας παραγράφου (π.χ. μια λέξη);**

Ναι. Η γλώσσα ορίζεται σε επίπεδο τμήματος ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), ώστε να μπορούν να συνυπάρχουν πολλαπλές γλώσσες μέσα σε μια ενιαία παράγραφο.