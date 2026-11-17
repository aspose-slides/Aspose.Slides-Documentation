---
title: Διαχείριση κελιών πίνακα σε παρουσιάσεις σε Android
linktitle: Διαχείριση κελιών
type: docs
weight: 30
url: /el/androidjava/manage-cells/
keywords:
- κελί πίνακα
- συγχώνευση κελιών
- αφαίρεση περιγράμματος
- διάσπαση κελιού
- εικόνα σε κελί
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχείριση κελιών πίνακα PowerPoint σε Android: εντοπισμός συγχωνευμένων κελιών, αφαίρεση περιγραμμάτων, διάσπαση κελιών και ορισμός χρωμάτων φόντου και εικόνων με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides σας επιτρέπει να έχετε πρόσβαση και να τροποποιείτε κελιά πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένα κελιά πινάκων, να αφαιρείτε τα περιγράμματα των κελιών, να εργάζεστε με την αρίθμηση των κελιών μετά τη συγχώνευση ή το διαχωρισμό τους, να αλλάζετε το χρώμα φόντου ενός κελιού και να προσθέτετε εικόνα μέσα σε κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να λάβετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση του κελιού μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες μηδενικής βάσης για την πρόσβαση στα κελιά πινάκων με τη σειρά `(column, row)`.

## **Εντοπισμός Συγχωνευμένου Κελιού Πίνακα**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και προσπελαύνει το πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια επαναλαμβάνει όλες τις γραμμές και στήλες και χρησιμοποιεί [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) για τον εντοπισμό κελιών σε συγχωνευμένες περιοχές. Για κάθε αντιστοιχία, εκτυπώνει τις συντεταγμένες του κελιού με σειρά `row;column`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), και τις αρχικές συντεταγμένες της περιοχής, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) και [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Αφαίρεση Περιγραμμάτων Κελιού Πίνακα**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη του διαφάνεια με τη μέθοδο [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Τα πλάτη των στηλών, τα ύψη των γραμμών και η θέση του πίνακα καθορίζονται σε μονάδες point. Το παράδειγμα θέτει όλα τα τέσσερα περιγράμματα του κελιού σε [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), ώστε να γίνουν αόρατα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Διαγωνίων Περιγραμμάτων Κελιού**

Χρησιμοποιήστε [getBorderDiagonalDown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalDown--) για να σχεδιάσετε μια γραμμή από την επάνω αριστερή γωνία προς την κάτω δεξιά, και [getBorderDiagonalUp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalUp--) για να σχεδιάσετε μια γραμμή από την κάτω αριστερή γωνία προς την επάνω δεξιά. Μια διαγώνια μπορεί να δημειάζει μια επικεφαλίδα γωνίας· και οι δύο διαγωνίτες μπορούν να σχηματίσουν ένα X για να επισημάνουν ότι το κελί δεν είναι εφαρμόσιμο.

Κάθε διαγώνιος είναι ένα [ILineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/). Στο [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) του, χρησιμοποιήστε τη μέθοδο [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) για να επιλέξετε το [FillType.Solid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) και διαλέξτε ένα χρώμα μέσω του [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--). Ορίστε το πλάτος της γραμμής σε μονάδες point με το [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-).

Το παράδειγμα δημιουργεί τρία κελιά σε μια γραμμή: μια κόκκινη διαγώνια προς τα κάτω, μια μπλε διαγώνια προς τα πάνω, και και τις δύο διαγωνίτες. Αφήνει τα περιγράμματα του κελιού στην κορυφή, στο κάτω μέρος, αριστερά και δεξιά αμετάβλητα.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Μια διαγώνια είναι ιδιότητα μορφοποίησης, όχι διαχωρισμός κελιού. Κάθε κελί διατηρεί ένα μόνο πλαίσιο κειμένου, το οποίο προσπελαύνεται μέσω του [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--); οι περιοχές στα δύο πλάγια μιας διαγώνιας δεν μπορούν να επεξεργαστούν ανεξάρτητα.

Το αποθηκευμένο πίνακα, αποδομένο στο Microsoft PowerPoint:

![Τρία κελιά πίνακα που δείχνουν μια κόκκινη διαγώνια από την άνω αριστερή γωνία προς την κάτω δεξιά, μια μπλε διαγώνια από την κάτω αριστερή γωνία προς την άνω δεξιά, και και τις δύο διαγώνιες σχηματίζοντας ένα X.](diagonal-cell-borders.png)

*Από αριστερά προς δεξιά: διαγώνια προς τα κάτω (κόκκινη, 3 pt), διαγώνια προς τα πάνω (μπλε, 5 pt), και και οι δύο διαγώνιες.*

## **Συγχώνευση Κελιών Πίνακα**

Χρησιμοποιήστε τη μέθοδο [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) για να συνδυάσετε μια ορθογώνια περιοχή κελιών πίνακα σε ένα κελί. Καθορίστε τα κελιά στην άνω αριστερή και στην κάτω δεξιά γωνία της περιοχής. Το τελευταίο όρισμα ελέγχει εάν η συγχώνευση μπορεί να περιλάβει κελιά εκτός της καθορισμένης περιοχής· η τιμή `false` διατηρεί τη συγχώνευση μέσα σε αυτήν την περιοχή.

Το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και γραμμές 70 σημείων, στη συνέχεια συγχωνεύει τα τέσσερα κεντρικά κελιά από το `(1, 1)` μέχρι το `(2, 2)`. Το προκύπτον κελί εκτείνεται σε δύο στήλες και δύο γραμμές, ενώ το υποκείμενο πλέγμα του πίνακα διατηρεί τέσσερις στήλες και τέσσερις γραμμές. Για να προσπελάσετε το περιεχόμενο ή τη μορφοποίηση του συγχωνευμένου κελιού, χρησιμοποιήστε τη θέση του στην άνω αριστερή γωνία: `table.get_Item(1, 1)` σε αυτό το παράδειγμα. Οι άλλες θέσεις στο συγχωνευμένο εύρος παραμένουν μέρος του πλέγματος του πίνακα, έτσι οι δείκτες των κελιών εκτός του εύρους δεν αλλάζουν.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Διαίρεση Κελιών Πίνακα**

Η συγχώνευση κελιών στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Η διαίρεση ενός κελιού μπορεί να εισάγει μια νέα στήλη στο πλέγμα και να αλλάξει τους δείκτες στήλης των κελιών στα δεξιά του. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος πινάκων του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και γραμμές 70 σημείων και καλεί τη μέθοδο [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) στο κελί `(1, 1)`. Το μισό του πλάτους των 70 σημείων του κελιού περνιέται για να δημιουργηθούν δύο κελιά ίσου πλάτους.

Μετά τη διαίρεση, τα δύο μισά προσπελάζονται ως `table.get_Item(1, 1)` και `table.get_Item(2, 1)`. Το πλέγμα του πίνακα έχει πλέον πέντε στήλες: τα κελιά που αρχικά ήταν στις στήλες 2 και 3 μετακινούνται στις στήλες 3 και 4, αντίστοιχα. Οι δείκτες γραμμών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στήλης όταν προσπελάζετε κελιά μετά τη διαίρεση.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![Ένα μη συγχωνευμένο κελί 70 σημείων χωρίζεται σε δύο κελιά 35 σημείων, προσθέτοντας μια πέμπτη στήλη στο πλέγμα και μετατοπίζοντας τους δείκτες στα δεξιά του.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Η διαίρεση του πλάτους επηρεάζει το κελί (1, 1), χρησιμοποιώντας δείκτες μηδενικής βάσης (column, row). Οι υπόλοιπες γραμμές διατηρούν ένα κελί που εκτείνεται και στις δύο νέες στήλες.*
<!-- visual-explanation:manage-cells:end -->

### **Διαίρεση Συγχωνευμένων Κελιών κατά Γραμμή ή Στήλη**

Για να προετοιμάσετε συγχωνευμένα κελιά προτύπου για την πληθυσμός δεδομένων, χρησιμοποιήστε το [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) για διαίρεση κατά υπάρχουσα γραμμή, ή το [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) για διαίρεση κατά στήλη.

Το όρισμα `index` μετρά γραμμές στο ανώτερο τμήμα ή στήλες στο αριστερό τμήμα της διαίρεσης· είναι σχετικό με την συγχωνευμένη περιοχή:

- Διαίρεση γραμμής: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Διαίρεση στήλης: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

Το παράδειγμα υποθέτει ότι μια παρουσίαση έχει έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια, με τα κελιά `(1, 2)` και `(1, 3)` να είναι συγχωνευμένα κατακόρυφα. Ξεκινώντας από τη χαμηλότερη θέση, χρησιμοποιεί τα [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) και [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) για να εντοπίσει την αρχή και ελέγχει και τις δύο εκτάσεις. Το `splitByRowSpan(1)` στη συνέχεια χωρίζει τις γραμμές 2 και 3 για τα ονόματα προϊόντων. Για οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε το `splitByColSpan(1)`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // Ανάκτηση των προκύπτοντων κελιών από τον πίνακα μετά τη διαίρεση.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Το πλέγμα του πίνακα και οι δείκτες των περιβάλλοντων κελιών παραμένουν αμετάβλητοι. Ανακτήστε τα προκύπτοντα κελιά με τις συντεταγμένες τους· εδώ, και τα δύο έχουν εκτάσεις 1 και το [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) εκτυπώνει `false`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν εν μέρει συγχωνευμένες μετά από μία διαίρεση.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στο άνω (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη μορφοποίηση του κελιού όπως γέμιση, περιγράμματα και περιθώρια. Γεμίστε τα κελιά μετά τη διαίρεση και ορίστε ρητά τυχόν απαιτούμενη μορφοποίηση κειμένου.

Δείτε την [Αναφορά API Κελιού](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) για λεπτομέρειες.

### **Διαίρεση Κελιού σε Συγκεκριμένο Ύψος**

Το [splitByHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByHeight-double-) λαμβάνει το ύψος του ανώτερου τμήματος σε μονάδες point. Το [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) λαμβάνει τον αριθμό των υπαρχουσών γραμμών του πλέγματος στο ανώτερο τμήμα. Για να κεντράρετε ένα κελί 40 σημείων στη δεξιά στήλη, αφαιρέστε 40 από το πραγματικό ύψος του κελιού και διαιρέστε το υπόλειπο χώρο εξίσου πάνω και κάτω.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };

    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η πρώτη διαίρεση προσθέτει μια γραμμή στο πλέγμα και αφήνει τα κάτω 90 σημεία στο κελί `(1, 1)`. Η δεύτερη διαίρεση χωρίζει το κελί αυτό σε ένα κεντρικό κελί 40 σημείων και ένα κάτω κελί 50 σημείων. Η δεξιά στήλη έχει τώρα τρία κελιά με ύψη 50, 40 και 50 σημείων από πάνω προς τα κάτω. Το αριστερό κελί εκτείνεται στις τρεις γραμμές και διατηρεί το αρχικό του ύψος των 140 σημείων.

![Το αριστερό κελί εκτείνεται σε όλο το ύψος του πίνακα δίπλα σε τρία κελιά με το Μεσαίο στο κέντρο.](split-by-height.png)

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Αυτό το παράδειγμα δημιουργεί έναν πίνακα με στήλες 150 σημείων και γραμμές 50 σημείων. Χρησιμοποιεί τη μέθοδο [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) για να επιλέξει συμπαγή γέμιση και ορίζει το χρώμα που επιστρέφει το [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) σε κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και την τέταρτη γραμμή.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσθήκη Εικόνας Μέσα σε Κελί Πίνακα**

Τοποθετήστε την εικόνα εισόδου στον κατάλογο εργασίας πριν εκτελέσετε αυτό το παράδειγμα. Φορτώνει την εικόνα με τη μέθοδο [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με το [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Στη συνέχεια ορίζει την εικόνα ως γέμισμα εικόνας του κελιού `(0, 0)`, του πρώτου κελιού στον πίνακα.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) τεντώνει την εικόνα ώστε να γεμίσει το κελί, κάτι που μπορεί να αλλάξει την αναλογία διαστάσεων της. Τα πλάτη των στηλών και τα ύψη των γραμμών είναι σε μονάδες point. Η φορτωμένη εικόνα απελευθερώνεται σε ένα μπλοκ `finally` μετά την προσθήκη της στην παρουσίαση.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ΣΥΧΝΑ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ορίσω διαφορετικά πάχη και στυλ γραμμής για τις διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) έχουν ξεχωριστές ιδιότητες, έτσι το πάχος και το στυλ κάθε πλευράς μπορούν να διαφέρουν.

**Τι συμβαίνει με την εικόνα εάν αλλάξω το μέγεθος της στήλης/γραμμής μετά τη ρύθμιση μιας εικόνας ως φόντο του κελιού;**

Η συμπεριφορά εξαρτάται από τη [λειτουργία γεμίσματος](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με επικάλυψη, τα τεμάχια επαναϋπολογίζονται.

**Μπορώ να αναθέσω έναν υπερσύνδεσμο σε ολόκληρο το περιεχόμενο ενός κελιού;**

Οι [Υπερσύνδεσμοι](/slides/el/androidjava/manage-hyperlinks/) ορίζονται στο επίπεδο του κειμένου (τμήματος) μέσα στο πλαίσιο κειμένου του κελιού ή στο επίπεδο ολόκληρου πίνακα/σχήματος. Στην πράξη, αναθέτετε τον σύνδεσμο σε ένα τμήμα ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές εντός ενός μόνο κελιού;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [τμήματα](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (runs) με ανεξάρτητη μορφοποίηση—οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.