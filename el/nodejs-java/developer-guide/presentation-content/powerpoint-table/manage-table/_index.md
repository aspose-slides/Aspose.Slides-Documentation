---
title: Διαχείριση Πινάκων Παρουσίασης σε JavaScript
linktitle: Διαχείριση Πίνακα
type: docs
weight: 10
url: /el/nodejs-java/manage-table/
keywords:
  - προσθήκη πίνακα
  - δημιουργία πίνακα
  - πρόσβαση σε πίνακα
  - αναλογία διαστάσεων
  - στοίχιση κειμένου
  - μορφοποίηση κειμένου
  - στυλ πίνακα
  - PowerPoint
  - παρουσίαση
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Δημιουργήστε & επεξεργαστείτε πίνακες σε διαφάνειες PowerPoint με JavaScript και Aspose.Slides για Node.js. Ανακαλύψτε απλά παραδείγματα κώδικα για βελτιστοποίηση των ροών εργασίας με πίνακες."
---
## **Εισαγωγή**

Ένας πίνακας στο PowerPoint είναι ένας αποδοτικός τρόπος παρουσίασης και απεικόνισης πληροφοριών. Οι πληροφορίες σε ένα πλέγμα κελιών (διαρρυθμισμένα σε σειρές και στήλες) είναι σαφείς και εύκολες στην κατανόηση.

Το Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Table), την κλάση [Cell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cell/) και άλλους τύπους ώστε να μπορείτε να δημιουργείτε, ενημερώνετε και διαχειρίζεστε πίνακες σε κάθε τύπο παρουσίασης.

## **Δημιουργία Πίνακα από το Μηδέν**

1. Δημιουργήστε ένα αντίγραφο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα `columnWidth`.
4. Ορίστε έναν πίνακα `rowHeight`.
5. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Table) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Επαναλάβετε για κάθε [Cell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cell/) ώστε να εφαρμόσετε μορφοποίηση στα επάνω, κάτω, δεξιά και αριστερά όρια.
7. Συγχωνεύστε τα πρώτα δύο κελιά της πρώτης γραμμής του πίνακα. 
8. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) ενός [Cell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cell/).
9. Προσθέστε κάποιο κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/).
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας JavaScript σας δείχνει πώς να δημιουργήσετε έναν πίνακα σε μια παρουσίαση:

```javascript
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Προσπελάζει την πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Ορίζει τη μορφή του περιγράμματος για κάθε κελί
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Συγχωνεύει τα κελιά 1 και 2 της πρώτης σειράς
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Προσθέτει κείμενο στο συγχωνευμένο κελί
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αρίθμηση σε Κανονικό Πίνακα**

Σε έναν κανονικό πίνακα, η αρίθμηση των κελιών είναι απλή και μηδενική. Το πρώτο κελί ενός πίνακα έχει δείκτη 0,0 (στήλη 0, σειρά 0). 

Για παράδειγμα, τα κελιά σε έναν πίνακα με 4 στήλες και 4 σειρές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτός ο κώδικας JavaScript σας δείχνει πώς να ορίσετε την αρίθμηση για τα κελιά ενός πίνακα:

```javascript
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Προσπελάζει την πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Ορίζει τη μορφή περιγράμματος για κάθε κελί
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Πρόσβαση σε Υπάρχον Πίνακα**

1. Δημιουργήστε ένα αντίγραφο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).

2. Αποκτήστε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα μέσω του δείκτη της. 

3. Δημιουργήστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Table) και ορίστε το σε null.

4. Επαναλάβετε σε όλα τα αντικείμενα [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/) μέχρι να βρεθεί ο πίνακας.  

   Αν υποψιάζεστε ότι η διαφάνεια που επεξεργάζεστε περιέχει έναν μόνο πίνακα, μπορείτε απλώς να ελέγξετε όλα τα σχήματα που περιέχει. Όταν ένα σχήμα αναγνωριστεί ως πίνακας, μπορείτε να το μετατρέψετε σε αντικείμενο [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Table). Αλλά αν η διαφάνεια περιέχει πολλούς πίνακες, είναι προτιμότερο να αναζητήσετε τον επιθυμητό πίνακα μέσω της μεθόδου [setAlternativeText(String value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Χρησιμοποιήστε το αντικείμενο [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Table) για να δουλέψετε με τον πίνακα. Στο παρακάτω παράδειγμα, προσθέσαμε μια νέα γραμμή στον πίνακα.

6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας JavaScript σας δείχνει πώς να προσπελάσετε και να εργαστείτε με έναν υπάρχοντα πίνακα:

```javascript
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Προσπελάζει την πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Αρχικοποιεί το TableEx ως null
    var tbl = null;
    // Διατρέχει τα σχήματα και θέτει μια αναφορά στον εντοπισμένο πίνακα
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Ορίζει το κείμενο για την πρώτη στήλη της δεύτερης σειράς
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Αποθηκεύει την τροποποιημένη παρουσίαση στο δίσκο
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Στοίχιση Κειμένου σε Πίνακα**

1. Δημιουργήστε ένα αντίγραφο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Table) στη διαφάνεια.
4. Προσπελάστε ένα αντικείμενο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) από τον πίνακα.
5. Προσπελάστε το [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/) του [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/).
6. Στοιχίστε το κείμενο κατακόρυφα.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας JavaScript σας δείχνει πώς να στοιχίσετε το κείμενο σε έναν πίνακα:

```javascript
// Δημιουργεί ένα αντίγραφο της κλάσης Presentation
var pres = new aspose.slides.Presentation();
try {
    // Παίρνει την πρώτη διαφάνεια
    var slide = pres.getSlides().get_Item(0);
    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Προσθέτει το σχήμα πίνακα στη διαφάνεια
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Προσπελάζει το πλαίσιο κειμένου
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Δημιουργεί το αντικείμενο Paragraph για το πλαίσιο κειμένου
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Δημιουργεί το αντικείμενο Portion για την παράγραφο
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Στοιχίζει το κείμενο κατακόρυφα
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

1. Δημιουργήστε ένα αντίγραφο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσπελάστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Table) από τη διαφάνεια.
4. Ορίστε το [setFontHeight(float value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) για το κείμενο.
5. Ορίστε το [setAlignment(int value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) και το [setMarginRight(float value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Ορίστε το [setTextVerticalType(byte value)](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας JavaScript σας δείχνει πώς να εφαρμόσετε τις προτιμώμενες επιλογές μορφοποίησης στο κείμενο ενός πίνακα:

```javascript
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένας πίνακας
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Ορίζει το ύψος γραμματοσειράς των κελιών του πίνακα
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Ορίζει τη στοίχιση του κειμένου και το δεξιό περιθώριο των κελιών του πίνακα με μία κλήση
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Ορίζει τον κατακόρυφο τύπο κειμένου των κελιών του πίνακα
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Το Aspose.Slides σας επιτρέπει να ανακτήσετε τις ιδιότητες στυλ ενός πίνακα ώστε να τις χρησιμοποιήσετε για άλλο πίνακα ή αλλού. Αυτός ο κώδικας JavaScript σας δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προκαθορισμένο στυλ πίνακα:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// αλλάζει το προεπιλεγμένο στυλ προεπιλογής
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Κλείδωμα Αναλογίας Διαστάσεων Πίνακα**

Η αναλογία διαστάσεων ενός γεωμετρικού σχήματος είναι το πηλίκο των μεγεθών του σε διαφορετικές διαστάσεις. Το Aspose.Slides παρείχε την ιδιότητα [**setAspectRatioLocked**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) για να μπορείτε να κλειδώσετε τη ρύθμιση αναλογίας διαστάσεων για πίνακες και άλλα σχήματα.

Αυτός ο κώδικας JavaScript σας δείχνει πώς να κλειδώσετε την αναλογία διαστάσεων για έναν πίνακα:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας εκθέτει τη μέθοδο [setRightToLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/table/setrighttoleft/), και οι παράγραφοι έχουν το [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Η χρήση και των δύο εξασφαλίζει τη σωστή σειρά RTL και την εμφάνιση μέσα στα κελιά.

**Πώς μπορώ να αποτρέψω τους χρήστες από το να μετακινούν ή να αλλάζουν μέγεθος έναν πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε κλειδώματα σχήματος για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κ.λπ. Αυτά τα κλειδώματα ισχύουν και για πίνακες.

**Υποστηρίζεται η εισαγωγή μιας εικόνας μέσα σε κελί ως φόντο;**

Ναι. Μπορείτε να ορίσετε ένα [picture fill](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύψει την περιοχή του κελιού σύμφωνα με την επιλεγμένη λειτουργία (τέντωμα ή επικάλυψη).