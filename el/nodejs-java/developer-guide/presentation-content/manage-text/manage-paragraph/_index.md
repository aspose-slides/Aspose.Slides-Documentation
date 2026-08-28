---
title: Διαχείριση Παραγράφων Κειμένου PowerPoint σε JavaScript
linktitle: Διαχείριση Παραγράφου
type: docs
weight: 40
url: /el/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να δημιουργήσετε και να διαμορφώσετε παραγράφους, τμήματα, κουκίδες, αριθμημένες λίστες, εσοχές, περιεχόμενο HTML και εικόνες παραγράφων με το Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides για Node.js μέσω Java αντιπροσωπεύει το κείμενο ως ιεραρχία πλαισίων κειμένου, παραγράφων και τμημάτων:

* [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) αναπαριστά το κοντέινερ κειμένου σε ένα σχήμα και παρέχει πρόσβαση στη συλλογή των παραγράφων του.
* [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/) αντιπροσωπεύει μία παράγραφο σε ένα πλαίσιο κειμένου και παρέχει πρόσβαση στα τμήματα και στη μορφοποίηση επιπέδου παραγράφου.
* [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/) αντιπροσωπεύει μια εκτέλεση κειμένου μέσα σε μια παράγραφο. Κάθε τμήμα μπορεί να έχει το δικό του κείμενο και μορφοποίηση επιπέδου χαρακτήρα.

Μια παράγραφος μπορεί επομένως να περιέχει κείμενο με διαφορετικές γραμματοσειρές, χρώματα, μεγέθη και άλλες μορφοποιήσεις χρησιμοποιώντας πολλαπλά τμήματα.

## **Δημιουργία και Μορφοποίηση Παραγράφων**

### **Δημιουργία Παραγράφων με Πολλαπλά Τμήματα**

Τα παρακάτω βήματα δημιουργούν ένα πλαίσιο κειμένου με τρεις παραγράφους, καθεμία με τρία τμήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) του σχήματος.
5. Χρησιμοποιήστε την προεπιλεγμένη παράγραφο και προσθέστε δύο ακόμη αντικείμενα [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/) στο πλαίσιο κειμένου.
6. Προσθέστε αρκετά αντικείμενα [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/) ώστε κάθε παράγραφος να περιέχει τρία τμήματα. Η προεπιλεγμένη παράγραφος περιέχει ήδη ένα κενό τμήμα.
7. Ορίστε το κείμενο κάθε τμήματος.
8. Εφαρμόστε μορφοποίηση επιπέδου χαρακτήρα μέσω του [Portion.getPortionFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/getportionformat/).
9. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτό το παράδειγμα JavaScript υλοποιεί τα βήματα:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Δημιουργία Λιστών με Κουκίδες και Αρίθμηση**

### **Δημιουργία Λίστας με Κουκίδες ή Αριθμούς**

Οι κουκίδες και η αρίθμηση κάνουν τα σχετιζόμενα στοιχεία πιο εύκολα στην ανάγνωση. Στο Aspose.Slides, οι ρυθμίσεις λίστας ορίζονται μέσω του [BulletFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bulletformat/).

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στην επιλεγμένη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) του σχήματος.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου.
6. Δημιουργήστε ένα [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/) για μια κουκίδα συμβόλου.
7. Ορίστε το [BulletFormat.setType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bulletformat/settype/) σε [BulletType.Symbol](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bullettype/) και καθορίστε τον χαρακτήρα της κουκίδας.
8. Ορίστε το κείμενο της παραγράφου, την εσοχή, το χρώμα της κουκίδας και το ύψος της κουκίδας.
9. Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
10. Δημιουργήστε μια δεύτερη παράγραφο και ορίστε το [BulletFormat.setType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bulletformat/settype/) σε [BulletType.Numbered](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bullettype/).
11. Διαμορφώστε το στυλ αριθμημένης κουκίδας και προσθέστε την παράγραφο στο πλαίσιο κειμένου.
12. Αποθηκεύστε την παρουσία.

Αυτό το παράδειγμα JavaScript δημιουργεί μια κουκίδα συμβόλου και μια αριθμημένη κουκίδα:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Χρήση Εικόνας ως Κουκίδα**

Οι εικόνες-κουκίδες σάς επιτρέπουν να χρησιμοποιήσετε μια προσαρμοσμένη εικόνα αντί για σύμβολο ή αριθμό.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στη σχετική διαφάνεια μέσω του δείκτη της.
3. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) και πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/).
4. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου.
5. Φορτώστε την εικόνα της κουκίδας και προσθέστε την στη συλλογή εικόνων της παρουσίασης ως [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/).
6. Δημιουργήστε ένα [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/) και ορίστε το κείμενό του.
7. Ορίστε το [BulletFormat.setType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bulletformat/settype/) σε [BulletType.Picture](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bullettype/).
8. Αντιστοιχίστε την εικόνα μέσω του [BulletFormat.getPicture](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bulletformat/getpicture/) και ορίστε το ύψος της κουκίδας.
9. Προσθέστε την παράγραφο στο πλαίσιο κειμένου.
10. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτό το παράδειγμα JavaScript δημιουργεί μια εικόνα-κουκίδα:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Δημιουργία Πολυεπίπεδης Λίστας**

Ορίστε το [ParagraphFormat.setDepth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setdepth/) για να τοποθετήσετε παραγράφους σε διαφορετικά επίπεδα λίστας. Το υψηλότερο επίπεδο έχει βάθος `0`.

1. Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και πρόσβαση σε μια διαφάνεια.
2. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) και αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου του.
3. Δημιουργήστε τέσσερις παραγράφους και διαμορφώστε τα σύμβολα των κουκίδων τους.
4. Ορίστε τις τιμές του [ParagraphFormat.setDepth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setdepth/) σε `0`, `1`, `2` και `3`.
5. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου και αποθηκεύστε την παρουσία.

Αυτό το παράδειγμα JavaScript δημιουργεί μια λίστα με τέσσερα επίπεδα κουκίδων:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Έναρξη Αριθμημένων Στοιχείων Λίστας σε Προσαρμοσμένες Τιμές**

Χρησιμοποιήστε το [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) για να ορίσετε τον αρχικό αριθμό που εμφανίζεται για μια αριθμημένη παράγραφο.

1. Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) σε μια διαφάνεια.
2. Αφαιρέστε την προεπιλεγμένη παράγραφο από το πλαίσιο κειμένου του σχήματος.
3. Δημιουργήστε τρεις αριθμημένες παραγράφους.
4. Ορίστε το [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) σε `2`, `3` και `7` για τις αντίστοιχες παραγράφους.
5. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου και αποθηκεύστε την παρουσία.

Αυτό το παράδειγμα JavaScript αναθέτει προσαρμοσμένο αρχικό αριθμό σε κάθε παράγραφο:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Διάταξης Παραγράφου και Ιδιότητες Λήξης**

### **Ορισμός Εσοχής Πρώτης Γραμμής**

Χρησιμοποιήστε το [ParagraphFormat.setIndent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setindent/) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η μέθοδος μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετατοπίζει την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [ParagraphFormat.setIndent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setindent/) όταν θέλετε να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δημιουργεί πολλές παραγράφους και εφαρμόζει διαφορετικές τιμές στο [ParagraphFormat.setIndent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setindent/) για να δείξει πώς η εσοχή πρώτης γραμμής επηρεάζει τη διάταξη.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στη στοχευμένη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) του σχήματος και αφαίρεση της προεπιλεγμένης παραγράφου.
5. Δημιουργήστε πολλές παραγράφους και ορίστε διαφορετικές τιμές στο [ParagraphFormat.setIndent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setindent/) για αυτές.
6. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτός ο κώδικας δείχνει πώς να ορίσετε εσοχή παραγράφου:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η εσοχή πρώτης γραμμής των παραγράφων](first_line_indent.png)

### **Ορισμός Κρεμαστής Εσοχής**

Η κρεμαστή εσοχή είναι διάταξη παραγράφου στην οποία η πρώτη γραμμή αρχίζει αριστερότερα από τις υπόλοιπες γραμμές. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με το [ParagraphFormat.setIndent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setindent/). Δώστε μια αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) ορίζει τη θέση του αριστερού περιθωρίου του σώματος της παραγράφου, και το [ParagraphFormat.setIndent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setindent/) ορίζει τη θέση της πρώτης γραμμής ως προς εκείνο το περιθώριο. Για κρεμαστή εσοχή, δώστε μια θετική τιμή στο `setMarginLeft` και μια αρνητική τιμή στο `setIndent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, εγγραφές γλωσσολογικού λεξικού και άλλες παραγράφους όπου οι αναδιπλωμένες γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου και όχι κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στη στοχευμένη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) στη διαφάνεια.
4. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) του σχήματος και αφαίρεση της προεπιλεγμένης παραγράφου.
5. Δημιουργήστε παραγράφους και δώστε μια θετική τιμή στο [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) για κάθε παράγραφο.
6. Δώστε μια αρνητική τιμή στο [ParagraphFormat.setIndent](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setindent/) για να δημιουργήσετε το εφέ κρεμαστής εσοχής.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτός ο κώδικας δείχνει πώς να ορίσετε κρεμαστή εσοχή για μια παράγραφο:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η κρεμαστή εσοχή των παραγράφων](hanging_indent.png)

### **Ορισμός Ιδιοτήτων Τέλους Παραγράφου**

Η [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) ελέγχει τη μορφοποίηση του σημείου λήξης παραγράφου. Το παρακάτω παράδειγμα αναθέτει μέγεθος γραμματοσειράς και λατινική γραμματοσειρά στο σημείο λήξης της δεύτερης παραγράφου:

1. Δημιουργήστε ή φορτώστε μια [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και πρόσβαση σε μια διαφάνεια.
2. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) και αφαιρέστε την προεπιλεγμένη παράγραφο.
3. Δημιουργήστε δύο παραγράφους και προσθέστε τμήματα κειμένου σε αυτές.
4. Δημιουργήστε ένα [PortionFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portionformat/) για το σημείο λήξης της δεύτερης παραγράφου.
5. Ορίστε το [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) και το [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. Αναθέστε τη μορφοποίηση με τη [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) και αποθηκεύστε την παρουσία.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εισαγωγή και Εξαγωγή Περιεχομένου Παραγράφου**

### **Εισαγωγή HTML Κειμένου σε Παραγράφους**

Χρησιμοποιήστε το [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) για να μετατρέψετε ετικέτες HTML σε παραγράφους και τμήματα σε ένα πλαίσιο κειμένου.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση σε μια διαφάνεια και προσθήκη ενός [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/).
3. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) του σχήματος και αφαίρεση της προεπιλεγμένης παραγράφου.
4. Ορίστε ή διαβάστε το πηγαίο κείμενο HTML.
5. Περνάτε το κείμενο HTML στο [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτό το παράδειγμα JavaScript εισάγει HTML σε ένα πλαίσιο κειμένου:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Εξαγωγή Κειμένου Παραγράφου σε HTML**

Χρησιμοποιήστε το [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) για να εξαγάγετε ένα επιλεγμένο εύρος παραγράφων ως HTML.

1. Δημιουργήστε ή φορτώστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στη διαφάνεια και εντοπισμός του [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) που περιέχει το κείμενο.
3. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) του σχήματος.
4. Καλέστε το [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) με το δείκτη της αρχικής παραγράφου και τον αριθμό των παραγράφων προς εξαγωγή.
5. Γράψτε την επιστρεφόμενη συμβολοσειρά HTML σε ένα αρχείο.

Αυτό το αυτόνομο παράδειγμα JavaScript δημιουργεί ένα σχήμα κειμένου και εξάγει όλες τις παραγράφους του:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Απόδοση Παραγράφου ως Εικόνας**

Η [Paragraph.getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/#getImage) αποδίδει άμεσα μία μεμονωμένη παράγραφο και επιστρέφει ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/). Αποθηκεύστε το αποτέλεσμα σε αρχείο με τη μέθοδο [IImage.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/iimage/#save). Δεν χρειάζεται να αποδώσετε ολόκληρο το σχήμα ή να περικόψετε το bitmap χειροκίνητα.

Η [Paragraph.getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/#getImage) μπορεί να επιστρέψει `null` αν η παράγραφος δεν βρεθεί στη συλλογή γονέα, δεν έχει έγκυρα όρια απόδοσης ή δεν μπορεί να αποδοθεί. Ελέγξτε το αποτέλεσμα πριν το αποθηκεύσετε και απελευθερώστε την επιστρεφόμενη εικόνα μετά τη χρήση.

#### **Απόδοση Παραγράφου σε Προεπιλεγμένη Κλίμακα**

Το παρακάτω πλαίσιο κειμένου περιέχει τρεις παραγράφους:

![Το πλαίσιο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

Το παρακάτω παράδειγμα αποδίδει τη δεύτερη παράγραφο σε ένα κανονικό σχήμα κειμένου στην προεπιλεγμένη κλίμακα και αποθηκεύει την επιστρεφόμενη εικόνα σε μορφή PNG. Το τμήμα `finally` εξασφαλίζει ότι η εικόνα απελευθερώνεται σωστά.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![Η εικόνα της παραγράφου](paragraph_to_image_output.png)

#### **Απόδοση Παραγράφου σε Κελί Πίνακα με Κλιμάκωση**

Χρησιμοποιήστε τη φορμάτ της [Paragraph.getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/#getImage) που δέχεται παραμέτρους `scaleX` και `scaleY` για να ορίσετε τους οριζόντιους και κατακορυφήσιους παράγοντες κλίμακας. Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα, αποδίδει την παράγραφο στο πρώτο του κελί με διπλάσιο πλάτος και ύψος από την προεπιλεγμένη τιμή, και αποθηκεύει το αποτέλεσμα ως εικόνα PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Ένας παράγοντας κλίμακας `1` διατηρεί τον άξονα στο προεπιλεγμένο μέγεθος εικονοστοιχείου. Για παράδειγμα, `2` και για τους δύο παράγοντες παράγει εικόνα του οποίου το πλάτος και το ύψος είναι περίπου διπλάσιοι των προεπιλεγμένων διαστάσεων, με αποτέλεσμα τέσσερις φορές περισσότερα εικονοστοιχεία. Μεγαλύτεροι παράγοντες γενικά παράγουν πιο ευκρινές κείμενο για μεγέθυνση ή έξοδο υψηλής ανάλυσης, αλλά αυξάνουν και τη χρήση μνήμης και το μέγεθος του αρχείου. Παράγοντες κάτω από `1` παράγουν μικρότερες εικόνες με λιγότερες λεπτομέρειες. Χρησιμοποιήστε ίδιους παράγοντες για να διατηρήσετε την αναλογία διαστάσεων της παραγράφου· διαφορετικοί οριζόντιοι και κατακόρυφοι παράγοντες τεντώνουν το αποτέλεσμα ανεξάρτητα.

Η απόδοση ενός ολόκληρου σχήματος με τη [Shape.getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getImage) παραμένει χρήσιμη όταν η έξοδος πρέπει να περιλαμβάνει το γέμισμα, το περίγραμμα ή άλλο οπτικό πλαίσιο του σχήματος. Για εικόνα που αφορά μόνο την παράγραφο, χρησιμοποιήστε τη [Paragraph.getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/#getImage).

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς την Αναδίπλωση γραμμών μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Ορίστε το [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/setwraptext/) για να απενεργοποιήσετε την αναδίπλωση, ώστε οι γραμμές να μη σπάζουν στις άκρες του πλαισίου κειμένου.

**Πώς μπορώ να λάβω τα ακριβή όρια στο σλάιδα μιας συγκεκριμένης παραγράφου;**

Χρησιμοποιήστε το [Paragraph.getRect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/getrect/) για να ανακτήσετε το ορθογώνιο περιοριστικό της παραγράφου. Το [Portion.getRect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/#getRect) παρέχει τα όρια ενός μεμονωμένου τμήματος.

**Πού ελέγχεται η Στοίχηση της Παραγράφου (αριστερά, δεξιά, κέντρο ή πλήρης στοίχιση);**

Η [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setalignment/) είναι ρύθμιση επιπέδου παραγράφου και εφαρμόζεται σε ολόκληρη την παράγραφο ανεξάρτητα από τη μορφοποίηση μεμονωμένων τμημάτων.

**Μπορώ να ορίσω τη γλώσσα απόδοσης για μέρος μιας παραγράφου;**

Ναι. Ορίστε το [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) για μεμονωμένα τμήματα, ώστε μια παράγραφος να μπορεί να περιέχει κείμενο σε πολλαπλές γλώσσες.