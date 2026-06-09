---
title: Διαχείριση Γραμματοσειρών σε Παρουσιάσεις Χρησιμοποιώντας JavaScript
linktitle: Διαχείριση Γραμματοσειρών
type: docs
weight: 10
url: /el/nodejs-java/manage-fonts/
keywords:
- διαχείριση γραμματοσειρών
- ιδιότητες γραμματοσειράς
- παράγραφος
- μορφοποίηση κειμένου
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Έλεγχος γραμματοσειρών με Aspose.Slides for Node.js via Java: ενσωμάτωση, υποκατάσταση και φόρτωση προσαρμοσμένων γραμματοσειρών για να διατηρείτε τις παρουσιάσεις PPT, PPTX και ODP καθαρές και συνεπείς."
---
## **Εισαγωγή**

Οι παρουσιάσεις συνήθως περιέχουν τόσο κείμενο όσο και εικόνες. Το κείμενο μπορεί να μορφοποιηθεί με διάφορους τρόπους, είτε για να τονιστούν συγκεκριμένα τμήματα και λέξεις είτε για να συμμορφωθεί με εταιρικά στυλ. Η μορφοποίηση του κειμένου βοηθά τους χρήστες να διαφοροποιούν την εμφάνιση του περιεχομένου της παρουσίασης. Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε το Aspose.Slides for Node.js via Java για να διαμορφώσετε τις ιδιότητες γραμματοσειράς παραγράφων κειμένου στις διαφάνειες.

## **Διαχείριση Ιδιοτήτων Σχετικών με τη Γραμματοσειρά**

Για να διαχειριστείτε τις ιδιότητες γραμματοσειράς μιας παραγράφου χρησιμοποιώντας το Aspose.Slides for Node.js via Java:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
1. Πρόσβαση στα σχήματα [Placeholder](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/placeholder/) στη διαφάνεια και μετατροπή τους σε [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/).
1. Λάβετε το [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/) από το [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) που εκτίθεται από το [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/).
1. Στοίχιση της παραγράφου.
1. Πρόσβαση στο κείμενο [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/) μιας [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/).
1. Ορίστε τη γραμματοσειρά χρησιμοποιώντας το [FontData](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontdata/) και ρυθμίστε το **Font** του κειμένου [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/) αντίστοιχα.
   1. Ορίστε τη γραμματοσειρά σε έντονη.
   1. Ορίστε τη γραμματοσειρά σε πλάγια.
1. Ορίστε το χρώμα της γραμματοσειράς χρησιμοποιώντας το [FillFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fillformat/) που εκτίθεται από το αντικείμενο [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων δίνεται παρακάτω. Παίρνει μια ακατέργαστη παρουσίαση και μορφοποιεί τις γραμματοσειρές σε μία από τις διαφάνειες. Τα στιγμιότυπα οθόνης που ακολουθούν δείχνουν το αρχείο εισόδου και πώς τα αποσπάσματα κώδικα το τροποποιούν. Ο κώδικας αλλάζει τη γραμματοσειρά, το χρώμα και το στυλ της γραμματοσειράς.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Σχήμα: Το κείμενο στο αρχείο εισόδου**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Σχήμα: Το ίδιο κείμενο με ενημερωμένη μορφοποίηση**|

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Πρόσβαση σε διαφάνεια χρησιμοποιώντας τη θέση της
    var slide = pres.getSlides().get_Item(0);
    // Πρόσβαση στα πρώτα και δεύτερα placeholders στη διαφάνεια και μετατροπή τους σε AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Πρόσβαση στην πρώτη παράγραφο
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Στοίχιση της παραγράφου
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // Πρόσβαση στο πρώτο τμήμα
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Ορισμός νέων γραμματοσειρών
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Ανάθεση νέων γραμματοσειρών στο τμήμα
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Ορισμός γραμματοσειράς σε έντονη
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Ορισμός γραμματοσειράς σε πλάγια
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ορισμός χρώματος γραμματοσειράς
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Αποθήκευση του PPTX στο δίσκο
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Ιδιοτήτων Γραμματοσειράς Κειμένου**
{{% alert color="primary" %}} 

Όπως αναφέρεται στο **Διαχείριση Ιδιοτήτων Σχετικών με τη Γραμματοσειρά**, ένα [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/) χρησιμοποιείται για την αποθήκευση κειμένου με παρόμοιο στυλ μορφοποίησης σε μια παράγραφο. Αυτό το άρθρο δείχνει πώς να χρησιμοποιήσετε το Aspose.Slides for Node.js via Java για να δημιουργήσετε ένα πλαίσιο κειμένου με κάποιο κείμενο και στη συνέχεια να ορίσετε μια συγκεκριμένη γραμματοσειρά, καθώς και διάφορες άλλες ιδιότητες της κατηγορίας οικογένειας γραμματοσειράς.

{{% /alert %}} 

Για να δημιουργήσετε ένα πλαίσιο κειμένου και να ορίσετε τις ιδιότητες γραμματοσειράς του κειμένου σε αυτό:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) του τύπου **Rectangle** στη διαφάνεια.
1. Αφαιρέστε το στυλ γεμίσματος που σχετίζεται με το [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/).
1. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) του [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/).
1. Προσθέστε κάποιο κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/).
1. Πρόσβαση στο αντικείμενο [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/) που συνδέεται με το [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/).
1. Ορίστε τη γραμματοσειρά που θα χρησιμοποιηθεί για το [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/).
1. Ορίστε άλλες ιδιότητες γραμματοσειράς όπως έντονη, πλάγια, υπογραμμισμένη, χρώμα και ύψος χρησιμοποιώντας τις σχετικές ιδιότητες που εκτίθενται από το αντικείμενο [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Η υλοποίηση των παραπάνω βημάτων δίνεται παρακάτω.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Σχήμα: Κείμενο με ορισμένες ιδιότητες γραμματοσειράς που ορίστηκαν από το Aspose.Slides for Node.js via Java**|

```javascript
// Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Λήψη της πρώτης διαφάνειας
    var sld = pres.getSlides().get_Item(0);
    // Προσθήκη AutoShape τύπου Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Αφαίρεση τυχόν στυλ γεμίσματος που σχετίζεται με το AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Πρόσβαση στο TextFrame που συσχετίζεται με το AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Πρόσβαση στο Portion που συσχετίζεται με το TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Ορισμός γραμματοσειράς για το Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Ορισμός ιδιότητας έντονης γραμματοσειράς
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Ορισμός ιδιότητας πλάγιας γραμματοσειράς
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ορισμός ιδιότητας υπογράμμισης της γραμματοσειράς
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Ορισμός ύψους της γραμματοσειράς
    port.getPortionFormat().setFontHeight(25);
    // Ορισμός χρώματος της γραμματοσειράς
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Αποθήκευση της παρουσίασης στο δίσκο
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```