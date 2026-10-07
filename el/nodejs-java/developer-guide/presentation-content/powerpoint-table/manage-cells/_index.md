---
title: Διαχείριση Κυττών Πίνακα σε Παρουσιάσεις με JavaScript
linktitle: Διαχείριση Κυττάρων
type: docs
weight: 30
url: /el/nodejs-java/manage-cells/
keywords:
- κελί πίνακα
- συγχώνευση κελιών
- αφαίρεση περιγράμματος
- διάσπαση κελιού
- εικόνα σε κελί
- χρώμα υποβάθρου
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχείριση κελιών πίνακα PowerPoint με JavaScript: αναγνώριση συγχωνευμένων κελιών, αφαίρεση περιγραμμάτων, διάσπαση κελιών και ορισμός χρωμάτων υποβάθρου και εικόνων με Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να προσπελάζετε και να τροποποιείτε τα κελιά πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένα κελιά πινάκων, να αφαιρείτε τα πλαίσια των κελιών, να εργάζεστε με την αρίθμηση των κελιών μετά τη συγχώνευση ή το διαχωρισμό τους, να αλλάζετε το χρώμα υποβάθρου ενός κελιού και να προσθέτετε εικόνα μέσα σε ένα κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να λάβετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση του κελιού μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες που ξεκινούν από το μηδέν για την πρόσβαση στα κελιά πινάκων με τη σειρά `(column, row)`.

## **Ανίχνευση Συγχωνευμένου Κελιού Πίνακα**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και προσπελαύνει το πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνειά και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια διατρέχει όλες τις γραμμές και στήλες και χρησιμοποιεί [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) για να εντοπίσει κελιά σε συγχωνευμένες περιοχές. Για κάθε αντιστοίχιση, εκτυπώνει τις συντεταγμένες του κελιού με σειρά `row;column`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), και τις αρχικές συντεταγμένες της περιοχής, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) και [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Αφαίρεση Περιγραμμάτων Κελιών Πίνακα**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη του διαφάνεια με το [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). Τα πλάτη των στηλών, τα ύψη των γραμμών και η θέση του πίνακα καθορίζονται σε μονάδες (points). Το παράδειγμα ορίζει όλα τα τέσσερα περιγράμματα του κελιού σε [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), καθιστώντας τα αόρατα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συγχώνευση Κελιών Πίνακα**

Χρησιμοποιήστε το [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) για να συνδυάσετε ένα ορθογώνιο εύρος κελιών πίνακα σε ένα κελί. Καθορίστε τα κελιά στην επάνω-αριστερή και κάτω-δεξιά γωνία του εύρους. Το τελευταίο όρισμα ελέγχει αν η συγχώνευση μπορεί να περιλαμβάνει κελιά εκτός του καθορισμένου εύρους· η τιμή `false` διατηρεί τη συγχώνευση εντός του εύρους.

Το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και γραμμές 70 points, στη συνέχεια συγχωνεύει τα τέσσερα κεντρικά κελιά από το `(1, 1)` έως το `(2, 2)`. Το προκύπτον κελί καλύπτει δύο στήλες και δύο γραμμές, ενώ το υποκείμενο πλέγμα του πίνακα παραμένει με τέσσερις στήλες και τέσσερις γραμμές. Για να προσπελάσετε το περιεχόμενο ή τη μορφοποίηση του συγχωνευμένου κελιού, χρησιμοποιήστε τη θέση του επάνω‑αριστερά: `table.get_Item(1, 1)` σε αυτό το παράδειγμα. Οι άλλες θέσεις στο συγχωνευμένο εύρος παραμένουν μέρος του πλέγματος του πίνακα, έτσι οι δείκτες των κελιών εκτός του εύρους δεν αλλάζουν.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Διαίρεση Κελιών Πίνακα**

Η συγχώνευση κελιών στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Η διάσπαση ενός κελιού μπορεί να εισαγάγει μια νέα στήλη στο πλέγμα και να αλλάξει τους δείκτες στήλης των κελιών στα δεξιά του. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος πινάκων του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και γραμμές 70 points και καλεί το [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) στο κελί `(1, 1)`. Το μισό του πλάτους των 70 points του κελιού χρησιμοποιείται για τη δημιουργία δύο κελιών ίσου πλάτους.

Μετά από αυτή τη διάσπαση, τα δύο μισά προσπελαύνονται ως `table.get_Item(1, 1)` και `table.get_Item(2, 1)`. Το πλέγμα του πίνακα έχει τώρα πέντε στήλες: τα κελιά αρχικά στις στήλες 2 και 3 μετακινούνται στις στήλες 3 και 4, αντίστοιχα. Οι δείκτες γραμμών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στήλης όταν προσπελάζετε κελιά μετά τη διάσπαση.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Διαίρεση Συγχωνευμένων Κελιών κατά Γραμμή ή Στήλη**

Για να προετοιμάσετε τα συγχωνευμένα κελιά προτύπου για την εισαγωγή δεδομένων, χρησιμοποιήστε το [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) για να διαιρέσετε κατά μια υπάρχουσα γραμμή, ή το [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) για να διαιρέσετε κατά μια στήλη.

Το όρισμα `index` μετρά τις γραμμές στο άνω μέρος ή τις στήλες στο αριστερό μέρος της διάσπασης· είναι σχετικό με τη συγχωνευμένη περιοχή:

- Διάσπαση γραμμής: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Διάσπαση στήλης: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

Το παράδειγμα υποθέτει ότι μια παρουσίαση έχει πίνακα ως πρώτο σχήμα στην πρώτη διαφάνεια, με τα `(1, 2)` και `(1, 3)` να είναι συγχωνευμένα κατακόρυφα. Ξεκινώντας από τη χαμηλότερη θέση, χρησιμοποιεί τα [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) και [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) για να εντοπίσει το σημείο εκκίνησης και ελέγχει και τις δύο διασπάσεις. Το `splitByRowSpan(1)` χωρίζει στη συνέχεια τις γραμμές 2 και 3 για τα ονόματα προϊόντων. Για οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε το `splitByColSpan(1)`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // Ανακτήστε τα προκύπτοντα κελιά από τον πίνακα μετά το διαχωρισμό.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Το πλέγμα του πίνακα και οι δείκτες των γύρω κελιών παραμένουν αμετάβλητοι. Ανακτήστε τα προκύψαντα κελιά με τις συντεταγμένες τους· εδώ, και τα δύο έχουν εύρος 1 και το [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) εμφανίζει `false`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν μερικώς συγχωνευμένες μετά από μία διάσπαση.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στο άνω (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη μορφοποίηση του κελιού όπως γέμισμα, περιγράμματα και περιθώρια. Συμπληρώστε τα κελιά μετά τη διάσπαση και ορίστε ρητά οποιαδήποτε απαιτούμενη μορφοποίηση κειμένου.

Η αποθηκευμένη παρουσίαση περιέχει ξεχωριστά κελιά «Product A» και «Product B» με τη μορφοποίηση του κελιού του προτύπου διατηρημένη. Δείτε το [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) για λεπτομέρειες.

## **Αλλαγή Χρώματος Υποβάθρου Κελιού Πίνακα**

Αυτό το παράδειγμα δημιουργεί έναν πίνακα με στήλες 150 points και γραμμές 50 points. Χρησιμοποιεί το [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) για να επιλέξει γεμίσμα στερεό και ορίζει το χρώμα που επιστρέφεται από το [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) σε κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και τέταρτη γραμμή.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Εικόνας Μέσα σε Κελί Πίνακα**

Τοποθετήστε την εικόνα εισόδου στον κατάλογο εργασίας πριν εκτελέσετε αυτό το παράδειγμα. Φορτώνει την εικόνα με το [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με το [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). Στη συνέχεια αναθέτει την εικόνα στο γέμισμα εικόνας του κελιού `(0, 0)`, το πρώτο κελί του πίνακα.

Το [PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) τεντώνει την εικόνα ώστε να γεμίσει το κελί, κάτι που μπορεί να αλλάξει την αναλογία διαστάσεων. Τα πλάτη των στηλών και τα ύψη των γραμμών είναι σε μονάδες (points). Η φορτωμένη εικόνα απελευθερώνεται σε ένα μπλοκ `finally` μετά την προσθήκη της στην παρουσίαση.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ορίσω διαφορετικά πάχη γραμμών και στυλ για τις διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) έχουν ξεχωριστές ιδιότητες, έτσι το πάχος και το στυλ κάθε πλευράς μπορούν να διαφέρουν.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος της στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντο του κελιού;**

Η συμπεριφορά εξαρτάται από το [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Με το τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με το πλακίδιο, τα πλακίδια επαναϋπολογίζονται.

**Μπορώ να αναθέσω ένα hyperlink σε όλο το περιεχόμενο ενός κελιού;**

Τα [Hyperlinks](/slides/el/nodejs-java/manage-hyperlinks/) ορίζονται στο επίπεδο του κειμένου (portion) μέσα στο πλαίσιο κειμένου του κελιού ή στο επίπεδο όλου του πίνακα/σχήματος. Στην πράξη, αναθέτετε τον σύνδεσμο σε ένα μέρος ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (τμήματα) με ανεξάρτητη μορφοποίηση—οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.