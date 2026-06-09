---
title: Διαχείριση Γραμμών και Στηλών σε Πίνακες PowerPoint χρησιμοποιώντας JavaScript
linktitle: Γραμμές και Στήλες
type: docs
weight: 20
url: /el/nodejs-java/manage-rows-and-columns/
keywords:
- γραμμή πίνακα
- στήλη πίνακα
- πρώτη γραμμή
- κεφαλίδα πίνακα
- κλωνοποίηση γραμμής
- κλωνοποίηση στήλης
- αντιγραφή γραμμής
- αντιγραφή στήλης
- αφαίρεση γραμμής
- αφαίρεση στήλης
- μορφοποίηση κειμένου γραμμής
- μορφοποίηση κειμένου στήλης
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε τις γραμμές και στήλες πίνακα σε PowerPoint με JavaScript και Aspose.Slides για Node.js μέσω Java και επιταχύνετε την επεξεργασία της παρουσίασης και τις ενημερώσεις δεδομένων."
---
## **Εισαγωγή**

Για να σας επιτρέψει να διαχειρίζεστε τις γραμμές και τις στήλες ενός πίνακα σε παρουσίαση PowerPoint, το Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/table/) και άλλους τύπους.

## **Ορισμός Πρώτης Γραμμής ως Κεφαλίδα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση.  
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Δημιουργήστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Table) και θέστε το σε null.  
4. Επανάληψη σε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/) για να βρείτε τον σχετικό πίνακα.  
5. Ορίστε την πρώτη γραμμή του πίνακα ως την κεφαλίδα του.  

Αυτός ο κώδικας JavaScript δείχνει πώς να ορίσετε την πρώτη γραμμή ενός πίνακα ως την κεφαλίδα του:

```javascript
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Αρχικοποιεί το TableEx σε null
    var tbl = null;
    // Διατρέχει τα σχήματα και ορίζει μια αναφορά στον πίνακα
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Ορίζει την πρώτη γραμμή ενός πίνακα ως την κεφαλίδα του
            tbl.setFirstRow(true);
        }
    }
    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Κλωνοποίηση Γραμμής ή Στήλης Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση,  
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Ορίστε έναν πίνακα του `columnWidth`.  
4. Ορίστε έναν πίνακα του `rowHeight`.  
5. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Table) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Κλωνοποιήστε τη γραμμή του πίνακα.  
7. Κλωνοποιήστε τη στήλη του πίνακα.  
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.  

Αυτός ο κώδικας JavaScript δείχνει πώς να κλωνοποιήσετε τη γραμμή ή τη στήλη ενός πίνακα PowerPoint:

```javascript
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Ορίζει στήλες με πλάτη και γραμμές με ύψη
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Προσθέτει κείμενο στο κελί 1 της γραμμής 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Προσθέτει κείμενο στο κελί 2 της γραμμής 1
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Κλωνοποιεί τη γραμμή 1 στο τέλος του πίνακα
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Προσθέτει κείμενο στο κελί 1 της γραμμής 2
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Προσθέτει κείμενο στο κελί 2 της γραμμής 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Κλωνοποιεί τη γραμμή 2 ως 4η γραμμή του πίνακα
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // Κλωνοποιεί την πρώτη στήλη στο τέλος
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // Κλωνοποιεί τη δεύτερη στήλη στη θέση της 4ης στήλης
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αφαίρεση Γραμμής ή Στήλης από Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση,  
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Ορίστε έναν πίνακα του `columnWidth`.  
4. Ορίστε έναν πίνακα του `rowHeight`.  
5. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Table) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Αφαιρέστε τη γραμμή του πίνακα.  
7. Αφαιρέστε τη στήλη του πίνακα.  
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.  

Αυτός ο κώδικας JavaScript δείχνει πώς να αφαιρέσετε μια γραμμή ή μια στήλη από έναν πίνακα:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Γραμμής Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση,  
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Πρόσβαση στο σχετικό αντικείμενο [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Table) από τη διαφάνεια.  
4. Ορίστε τα κελιά της πρώτης γραμμής με τη μέθοδο [setFontHeight(float value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Ορίστε τα κελιά της πρώτης γραμμής με τις μεθόδους [setAlignment(int value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) και [setMarginRight(float value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Ορίστε τα κελιά της δεύτερης γραμμής με τη μέθοδο [setTextVerticalType(byte value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.  

Αυτός ο κώδικας JavaScript επιδεικνύει τη λειτουργία.

```javascript
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Υποθέτουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Ορίζει το ύψος γραμματοσειράς των κελιών της πρώτης γραμμής
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // Ορίζει την στοίχιση κειμένου και το δεξιό περιθώριο των κελιών της πρώτης γραμμής
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // Ορίζει τον κάθετο τύπο κειμένου των κελιών της δεύτερης γραμμής
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Στήλης Πίνακα**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση,  
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.  
3. Πρόσβαση στο σχετικό αντικείμενο [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Table) από τη διαφάνεια.  
4. Ορίστε τα κελιά της πρώτης στήλης με τη μέθοδο [setFontHeight(float value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Ορίστε τα κελιά της πρώτης στήλης με τις μεθόδους [setAlignment(int value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) και [setMarginRight(float value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Ορίστε τα κελιά της δεύτερης στήλης με τη μέθοδο [setTextVerticalType(byte value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.  

Αυτός ο κώδικας JavaScript επιδεικνύει τη λειτουργία:

```javascript
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Ορίζει το ύψος γραμματοσειράς των κελιών της πρώτης στήλης
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // Ορίζει την στοίχιση κειμένου και το δεξιό περιθώριο των κελιών της πρώτης στήλης σε μία κλήση
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // Ορίζει τον κάθετο τύπο κειμένου των κελιών της δεύτερης στήλης
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Το Aspose.Slides σας επιτρέπει να ανακτήσετε τις ιδιότητες στυλ για έναν πίνακα ώστε να μπορείτε να τις χρησιμοποιήσετε για άλλο πίνακα ή αλλού. Αυτός ο κώδικας JavaScript δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προκαθορισμένο στυλ πίνακα:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// αλλάζει το προεπιλεγμένο στυλ θέματος
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω θέματα/στυλ PowerPoint σε έναν ήδη δημιουργημένο πίνακα;**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/κύριου θέματος, και μπορείτε ακόμη να παρακάμψετε τα γέμιστρα, τα περιγράμματα και τα χρώματα κειμένου πάνω από αυτό το θέμα.

**Μπορώ να ταξινομήσω τις γραμμές του πίνακα όπως στο Excel;**

Όχι, οι πίνακες του Aspose.Slides δεν διαθέτουν ενσωματωμένη ταξινόμηση ή φίλτρα. Ταξινομήστε τα δεδομένα στη μνήμη πρώτα, έπειτα γεμίστε ξανά τις γραμμές του πίνακα με αυτή τη σειρά.

**Μπορώ να έχω εναλλασσόμενες στήλες ενώ διατηρώ προσαρμοσμένα χρώματα σε συγκεκριμένα κελιά;**

Ναι. Ενεργοποιήστε τις εναλλασσόμενες στήλες, έπειτα παρακάμψτε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση επιπέδου κελιού έχει προτεραιότητα έναντι του στυλ του πίνακα.