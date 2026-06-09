---
title: Διαχείριση κελιών πίνακα σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Διαχείριση κελιών
type: docs
weight: 30
url: /el/nodejs-java/manage-cells/
keywords:
- κελί πίνακα
- συγχώνευση κελιών
- αφαίρεση περιγράμματος
- διαχωρισμός κελιού
- εικόνα σε κελί
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε τα κελιά πίνακα στο PowerPoint με το Aspose.Slides για Node.js. Κατακτήστε την πρόσβαση, την τροποποίηση και τη μορφοποίηση των κελιών γρήγορα για αδιάσπαστη αυτοματοποίηση των διαφανειών."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει την πρόσβαση και την τροποποίηση των κελιών πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένα κελιά πίνακα, να αφαιρείτε τα περιγράμματα των κελιών, να εργάζεστε με την αρίθμηση των κελιών μετά τη συγχώνευση ή το διαχωρισμό, να αλλάζετε το χρώμα φόντου ενός κελιού και να προσθέτετε εικόνα μέσα σε κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να λάβετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση του κελιού μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

## **Προσδιορισμός Συγχωνευμένων Κελιών Πίνακα**
1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Λάβετε τον πίνακα από την πρώτη διαφάνεια. 
3. Περάστε από τις σειρές και τις στήλες του πίνακα για να βρείτε συγχωνευμένα κελιά.
4. Εκτυπώστε μήνυμα όταν βρεθούν συγχωνευμένα κελιά.

Αυτός ο κώδικας JavaScript σας δείχνει πώς να εντοπίζετε συγχωνευμένα κελιά πίνακα σε μια παρουσίαση:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// υποθέτοντας ότι το Slide#0.Shape#0 είναι πίνακας
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αφαίρεση Περιγράμματος Κελιών Πίνακα**
1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Λάβετε μια αναφορά στη διαφάνεια μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα στηλών με πλάτος.
4. Ορίστε έναν πίνακα γραμμών με ύψος.
5. Προσθέστε έναν πίνακα στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Διασχίστε κάθε κελί για να αφαιρέσετε τα επάνω, κάτω, δεξιά και αριστερά περιγράμματα.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να αφαιρέσετε τα περιγράμματα από τα κελιά πίνακα:

```javascript
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Ορίζει στήλες με πλάτος και γραμμές με ύψος
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Προσθέτει σχήμα πίνακα στην διαφάνεια
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Ορίζει τη μορφή περιγράμματος για κάθε κελί
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // Αποθηκεύει το PPTX στο δίσκο
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αρίθμηση σε Συγχωνευμένα Κελιά**
Αν συγχωνεύσουμε 2 ζεύγη κελιών (1, 1) × (2, 1) και (1, 2) × (2, 2), ο προκύπτων πίνακας θα αριθμηθεί. Αυτός ο κώδικας JavaScript επιδεικνύει τη διαδικασία:

```javascript
// Δημιουργεί αντικείμενο της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Ορίζει στήλες με πλάτος και γραμμές με ύψος
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Προσθέτει σχήμα πίνακα στη διαφάνεια
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
    // Συγχωνεύει τα κελιά (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Συγχωνεύει τα κελιά (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Στη συνέχεια συγχωνεύουμε περαιτέρω τα κελιά συγχωνεύοντας το (1, 1) με το (1, 2). Το αποτέλεσμα είναι ένας πίνακας που περιέχει ένα μεγάλο συγχωνευμένο κελί στο κέντρο του:

```javascript
// Δημιουργεί αντικείμενο της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Ορίζει στήλες με πλάτος και γραμμές με ύψος
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Προσθέτει σχήμα πίνακα στη διαφάνεια
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
    // Συγχωνεύει τα κελιά (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Συγχωνεύει τα κελιά (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Συγχωνεύει τα κελιά (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αρίθμηση σε Διαχωρισμένο Κελί**
Στα προηγούμενα παραδείγματα, όταν τα κελιά πίνακα συγχωνεύονταν, το σύστημα αρίθμησης σε άλλα κελιά δεν άλλαζε.

Αυτή τη φορά, παίρνουμε έναν κανονικό πίνακα (χωρίς συγχωνευμένα κελιά) και προσπαθούμε να διαχωρίσουμε το κελί (1,1) για να δημιουργήσουμε έναν ιδιαίτερο πίνακα. Ίσως θέλετε να προσέξετε την αρίθμηση αυτού του πίνακα, η οποία ενδέχεται να φαίνεται περίεργη. Ωστόσο, έτσι ακριβώς αριθμεί τα κελιά πίνακα το Microsoft PowerPoint και το Aspose.Slides κάνει το ίδιο.

Αυτός ο κώδικας JavaScript επιδεικνύει τη διαδικασία που περιγράψαμε:

```javascript
// Δημιουργεί το αντικείμενο της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var sld = pres.getSlides().get_Item(0);
    // Ορίζει στήλες με πλάτος και γραμμές με ύψος
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Προσθέτει σχήμα πίνακα στη διαφάνεια
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
    // Συγχωνεύει τα κελιά (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Συγχωνεύει τα κελιά (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Διαχωρίζει το κελί (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // Γράφει το αρχείο PPTX στο δίσκο
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Αυτός ο κώδικας JavaScript σας δείχνει πώς να αλλάξετε το χρώμα φόντου ενός κελιού πίνακα:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // δημιουργία νέου πίνακα
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // ορισμός χρώματος φόντου για ένα κελί
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Προσθήκη Εικόνας Μέσα σε Κελί Πίνακα**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2. Λάβετε μια αναφορά στη διαφάνεια μέσω του δείκτη της.
3. Ορίστε έναν πίνακα στηλών με πλάτος.
4. Ορίστε έναν πίνακα γραμμών με ύψος.
5. Προσθέστε έναν πίνακα στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Δημιουργήστε ένα αντικείμενο `Images` για να κρατήσετε το αρχείο εικόνας.
7. Προσθέστε την εικόνα `IImage` στο αντικείμενο `PPImage`.
8. Ορίστε το `FillFormat` για το Κελί Πίνακα σε `Picture`.
9. Προσθέστε την εικόνα στο πρώτο κελί του πίνακα.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX

Αυτός ο κώδικας JavaScript σας δείχνει πώς να τοποθετήσετε μια εικόνα μέσα σε κελί πίνακα κατά τη δημιουργία του πίνακα:

```javascript
// Δημιουργεί το αντικείμενο της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
var pres = new aspose.slides.Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    var islide = pres.getSlides().get_Item(0);
    // Ορίζει στήλες με πλάτος και γραμμές με ύψος
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // Προσθέτει σχήμα πίνακα στη διαφάνεια
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // Δημιουργεί ένα αντικείμενο PPImage χρησιμοποιώντας το αρχείο εικόνας
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Προσθέτει την εικόνα στο πρώτο κελί του πίνακα
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω διαφορετικά πάχη και στυλ γραμμής για διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [top](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellformat/getbordertop/), [bottom](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellformat/getborderbottom/), [left](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellformat/getborderleft/), και [right](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cellformat/getborderright/) έχουν ξεχωριστές ιδιότητες, ώστε το πάχος και το στυλ κάθε πλευράς να μπορεί να διαφέρει. Αυτό ακολουθεί λογικά τον έλεγχο περιγράμματος ανά πλευρά για ένα κελί, όπως παρουσιάζεται στο άρθρο.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος της στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντο του κελιού;**

Η συμπεριφορά εξαρτάται από τη [fill mode](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Με το stretch, η εικόνα προσαρμόζεται στο νέο κελί· με το tile, τα κομμάτια επαναϋπολογίζονται. Το άρθρο αναφέρεται στους τρόπους εμφάνισης εικόνας σε κελί.

**Μπορώ να αντιστοιχίσω υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

Τα [Hyperlinks](/slides/el/nodejs-java/manage-hyperlinks/) ορίζονται σε επίπεδο κειμένου (portion) μέσα στο πλαίσιο κειμένου του κελιού ή σε επίπεδο ολόκληρου πίνακα/σχήματος. Στην πράξη, αντιστοιχίζετε τον σύνδεσμο σε μια μέρος ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/) (τμήματα) με ανεξάρτητη μορφοποίηση — οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.