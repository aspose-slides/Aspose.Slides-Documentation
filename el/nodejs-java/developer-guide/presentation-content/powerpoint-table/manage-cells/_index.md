---
title: Διαχείριση κελιών πίνακα σε παρουσιάσεις με JavaScript
linktitle: Διαχείριση κελιών
type: docs
weight: 30
url: /el/nodejs-java/manage-cells/
keywords:
- κελί πίνακα
- συγχώνευση κελιών
- αφαίρεση περιγράμματος
- διαίρεση κελιού
- εικόνα σε κελί
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχείριση κελιών πίνακα PowerPoint σε JavaScript: εντοπισμός συγχωνευμένων κελιών, αφαίρεση περιγραμμάτων, διαίρεση κελιών, και ορισμός χρωμάτων φόντου και εικόνων με Aspose.Slides για Node.js μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να έχετε πρόσβαση και να τροποποιείτε τα κελιά πίνακα σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένα κελιά πίνακα, να αφαιρείτε τα περιθώρια των κελιών, να εργάζεστε με την αρίθμηση των κελιών μετά τη συγχώνευση ή το σπάσιμο των κελιών, να αλλάζετε το χρώμα φόντου ενός κελιού και να προσθέτετε μια εικόνα μέσα σε κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να λάβετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση των κελιών μέσω των ιδιοτήτων κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες που ξεκινούν από το μηδέν για την πρόσβαση στα κελιά πίνακα με τη σειρά `(στήλη, γραμμή)`.

## **Identify a Merged Table Cell**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και προσπελάζει το πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια διατρέχει όλες τις γραμμές και στήλες και χρησιμοποιεί [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) για να εντοπίσει κελιά σε συγχωνευμένες περιοχές. Για κάθε αντιστοιχία, εκτυπώνει τις συντεταγμένες του κελιού με τη μορφή `row;column`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), και τις αρχικές συντεταγμένες της περιοχής, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) και [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

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

## **Remove Table Cell Borders**

Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη του διαφάνεια με το [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). Τα πλάτη των στηλών, τα ύψη των γραμμών και η θέση του πίνακα ορίζονται σε μονάδες point. Το παράδειγμα ορίζει όλα τα τέσσερα περιθώρια κελιών σε [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), καθιστώντας τα αόρατα.

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

## **Add Diagonal Cell Borders**

Χρησιμοποιήστε [getBorderDiagonalDown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonaldown/) για να σχεδιάσετε μια γραμμή από την πάνω‑αριστερή γωνία προς την κάτω‑δεξιά, και [getBorderDiagonalUp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonalup/) για να σχεδιάσετε μια γραμμή από την κάτω‑αριστερή γωνία προς την πάνω‑δεξιά. Μια διαγώνιος μπορεί να δηλώνει επικεφαλίδα γωνίας· και οι δύο διαγώνιοι μπορούν να σχηματίσουν ένα X για να σημειώσουν ότι το κελί δεν είναι εφαρμόσιμο.

Κάθε διαγώνιος είναι ένα [LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/). Στο [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) του, χρησιμοποιήστε [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) για να επιλέξετε [FillType.Solid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) και διαλέξτε χρώμα μέσω του [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/). Ορίστε το πλάτος της γραμμής σε points με το [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/).

Το παράδειγμα δημιουργεί τρία κελιά σε μία γραμμή: μια κόκκινη διαγώνιος που κατεβάζει, μια μπλε διαγώνιος που ανεβαίνει, και και τις δύο διαγώνιους. Αφήνει αμετάβλητα τα επάνω, κάτω, αριστερά και δεξιά περιθώρια του κελιού.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [210, 210, 210]);
    const rowHeights = java.newArray("double", [160]);
    const table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    const downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    downwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    downwardBorder.setWidth(3);

    const upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    upwardBorder.setWidth(5);

    const crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    crossDownwardBorder.setWidth(3);

    const crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Μια διαγώνιος είναι ιδιότητα μορφοποίησης, όχι διαίρεση κελιού. Κάθε κελί διατηρεί ένα μοναδικό πλαίσιο κειμένου, προσβάσιμο μέσω του [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/gettextframe/); οι περιοχές στα δύο πλευρά της διαγωνίου δεν μπορούν να επεξεργαστούν ανεξάρτητα.

The saved table, rendered in Microsoft PowerPoint:

![Τρία κελιά πίνακα που δείχνουν μια κόκκινη διαγώνιο από πάνω-αριστερά προς κάτω-δεξιά, μια μπλε διαγώνιο από κάτω-αριστερά προς πάνω-δεξιά, και και τις δύο διαγωνίους σχηματίζουν ένα Χ.](diagonal-cell-borders.png)

*Αριστερά προς δεξιά: κατιούσα διαγώνιος (κόκκινη, 3 pt), ανερχόμενη διαγώνιος (μπλε, 5 pt), και και οι δύο διαγώνιοι.*

## **Merge Table Cells**

Χρησιμοποιήστε [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) για να συνδυάσετε μια ορθογώνια περιοχή κελιών πίνακα σε ένα κελί. Καθορίστε τα κελιά στην πάνω‑αριστερή και κάτω‑δεξιά γωνία της περιοχής. Το τελευταίο όρισμα ελέγχει αν η σύζευξη μπορεί να περιλάβει κελιά εκτός της συγκεκριμένης περιοχής· `false` κρατά τη σύζευξη εντός της περιοχής.

Το παράδειγμα δημιουργεί έναν πίνακα 4‑by‑4 με στήλες και γραμμές 70 point, στη συνέχεια συγχωνεύει τα τέσσερα κεντρικά κελιά από το `(1, 1)` μέχρι το `(2, 2)`. Το προκύπτον κελί καλύπτει δύο στήλες και δύο γραμμές, ενώ το υποκείμενο πλέγμα του πίνακα διατηρεί τέσσερις στήλες και τέσσερις γραμμές. Για πρόσβαση στο περιεχόμενο ή τη μορφοποίηση του συγχωνευμένου κελιού, χρησιμοποιήστε τη θέση του πάνω‑αριστερά: `table.get_Item(1, 1)` σε αυτό το παράδειγμα. Οι άλλες θέσεις στην συγχωνευμένη περιοχή παραμένουν μέρος του πλέγματος του πίνακα, έτσι οι δείκτες των κελιών εκτός της περιοχής δεν αλλάζουν.

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

## **Split Table Cells**

Η συγχώνευση κελιών στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Η διαίρεση ενός κελιού μπορεί να εισαγάγει μια νέα στήλη πλέγματος και να αλλάξει τους δείκτες στήλης των κελιών δεξιά του. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος πίνακα του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4‑by‑4 με στήλες και γραμμές 70 point και καλεί το [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) στο κελί `(1, 1)`. Το ήμισυ του πλάτους των 70 point του κελιού περνιέται για να δημιουργηθούν δύο κελιά ίσου πλάτους.

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

<!-- visual-explanation:manage-cells:start -->
[![Ένα μη συγχωνευμένο κελί 70 σημείων διαχωρίζεται σε δύο κελιά 35 σημείων, προσθέτοντας μια πέμπτη στήλη πλέγματος και μετατοπίζοντας τους δείκτες δεξιά του.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Η διαίρεση του πλάτους επηρεάζει το κελί (1, 1), χρησιμοποιώντας δείκτες μηδενικής βάσης (στήλη, γραμμή). Οι άλλες γραμμές διατηρούν ένα κελί που καλύπτει και τις δύο νέες θέσεις στήλης.*
<!-- visual-explanation:manage-cells:end -->

### **Split Merged Cells by Row or Column Span**

Για να προετοιμάσετε συγχωνευμένα κελιά προτύπου για πληρωμή δεδομένων, χρησιμοποιήστε το [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) για να χωρίσετε κατά έναν υπάρχοντα ορίζοντα γραμμής, ή το [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) για να χωρίσετε κατά έναν ορίζοντα στήλης.

Το όρισμα `index` μετράει γραμμές στο άνω μέρος ή στήλες στο αριστερό μέρος της διαίρεσης· είναι σχετικό με τη συγχωνευμένη περιοχή:

- Row split: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Column split: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

Το παράδειγμα υποθέτει ότι μια παρουσίαση έχει έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια, με τα `(1, 2)` και `(1, 3)` συγχωνευμένα κάθετα. Ξεκινώντας από τη χαμηλότερη θέση, χρησιμοποιεί τα [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) και [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) για να εντοπίσει το αρχικό σημείο και ελέγχει και τις δύο εκτάσεις. Το `splitByRowSpan(1)` στη συνέχεια διαχωρίζει τις γραμμές 2 και 3 για τα ονόματα προϊόντων. Για οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε αντί αυτού το `splitByColSpan(1)`.

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

Το πλέγμα του πίνακα και οι γύρω δείκτες κελιών παραμένουν αμετάβλητοι. Ανακτήστε τα προκύπτοντα κελιά με βάση τις συντεταγμένες τους· εδώ, και τα δύο έχουν εκτάσεις 1 και το [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) εμφανίζει `false`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν εν μέρει συγχωνευμένες μετά μια διαίρεση.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στο άνω (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη μορφοποίηση του κελιού, όπως γέμισμα, περιθώρια και περιθώρια. Συμπληρώστε τα κελιά μετά τη διαίρεση και ορίστε τυχόν απαιτούμενη μορφοποίηση κειμένου ρητά.

Η αποθηκευμένη παρουσίαση περιέχει ξεχωριστά κελιά “Product A” και “Product B” με τη μορφοποίηση του προτύπου διατηρημένη. Δείτε την [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) για λεπτομέρειες.

### **Split a Cell at a Specific Height**

Το [splitByHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyheight/) λαμβάνει το ύψος του άνω μέρους σε points. Το [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) λαμβάνει τον αριθμό των υπαρχουσών σειρών πλέγματος στο άνω μέρος. Για να κεντράρετε ένα κελί 40 point στη δεξιά στήλη, αφαιρέστε 40 από το πραγματικό ύψος του κελιού και διαιρέστε τον υπόλοιπο χώρο ισομερώς πάνω και κάτω από αυτό.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [160, 160]);
    const rowHeights = java.newArray("double", [140]);

    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    const height = table.get_Item(1, 0).getHeight();
    const margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η πρώτη διαίρεση προσθέτει μια σειρά πλέγματος και αφήνει τα κάτω 90 point στο κελί `(1, 1)`. Η δεύτερη διαίρεση χωρίζει αυτό το κελί σε ένα μεσαίο κελί 40 point και ένα κάτω κελί 50 point. Η δεξιά στήλη έχει τώρα τρία κελιά με ύψη 50, 40 και 50 point από πάνω προς τα κάτω. Το αριστερό κελί καλύπτει όλες τις τρεις γραμμές και διατηρεί το αρχικό του ύψος των 140 point.

![Το αριστερό κελί καλύπτει όλο το ύψος του πίνακα δίπλα σε τρία κελιά με το Μεσαίο στη μέση.](split-by-height.png)

## **Change the Table Cell Background Color**

Αυτό το παράδειγμα δημιουργεί έναν πίνακα με στήλες 150 point και γραμμές 50 point. Χρησιμοποιεί το [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) για να επιλέξει στερεό γέμισμα και ορίζει το χρώμα που επιστρέφεται από το [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) ως κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και την τέταρτη γραμμή.

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

## **Add an Image Inside a Table Cell**

Τοποθετήστε την είσοδο εικόνας στον κατάλογο εργασίας πριν τρέξετε αυτό το παράδειγμα. Φορτώνει την εικόνα με το [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με το [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). Στη συνέχεια αναθέτει την εικόνα στη γεμιστική εικόνα (picture fill) του κελιού `(0, 0)`, του πρώτου κελιού του πίνακα.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) τεντώνει την εικόνα ώστε να γεμίσει το κελί, κάτι που μπορεί να αλλάξει την αναλογία του. Τα πλάτη των στηλών και τα ύψη των γραμμών είναι σε points. Η φορτωμένη εικόνα διαγράφεται σε ένα `finally` block μετά την προσθήκη της στην παρουσίαση.

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

## **FAQ**

**Can I set different line thicknesses and styles for different sides of a single cell?**

Ναι. Τα περιθώρια [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) έχουν ξεχωριστές ιδιότητες, έτσι το πάχος και το στυλ κάθε πλευράς μπορούν να διαφέρουν.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

Η συμπεριφορά εξαρτάται από το [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με επικάλυψη, τα πλακίδια υπολογίζονται ξανά.

**Can I assign a hyperlink to all the content of a cell?**

[Hyperlinks](/slides/el/nodejs-java/manage-hyperlinks/) ορίζονται σε επίπεδο κειμένου (portion) μέσα στο πλαίσιο κειμένου του κελιού ή σε επίπεδο ολόκληρου πίνακα/σχήματος. Στην πράξη, αναθέτετε το σύνδεσμο σε ένα τμήμα ή σε όλο το κείμενο του κελιού.

**Can I set different fonts within a single cell?**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (runs) με ανεξάρτητη μορφοποίηση — οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.