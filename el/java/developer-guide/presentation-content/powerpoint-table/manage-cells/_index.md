---
title: Διαχείριση Κελιών Πίνακα σε Παρουσιάσεις με Java
linktitle: Διαχείριση Κελιών
type: docs
weight: 30
url: /el/java/manage-cells/
keywords:
- κελί πίνακα
- συγχώνευση κελιών
- αφαίρεση περιγράμματος
- διαχωρισμός κελιού
- εικόνα σε κελί
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα κελιά πινάκων PowerPoint με Java: εντοπίστε συγχωνευμένα κελιά, αφαιρέστε περιγράμματα, διαχωρίστε κελιά και ορίστε χρώματα φόντου και εικόνες με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να προσπελάσετε και να τροποποιήσετε κελιά πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίσετε συγχωνευμένα κελιά πινάκων, να αφαιρέσετε τα πλαίσια των κελιών, να εργαστείτε με την αρίθμηση των κελιών μετά τη συγχώνευση ή το διαχωρισμό των κελιών, να αλλάξετε το χρώμα φόντου ενός κελιού και να προσθέσετε μια εικόνα μέσα σε ένα κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να λάβετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση των κελιών μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες με μηδενική βάση για την πρόσβαση στα κελιά των πινάκων με τη σειρά `(column, row)`.

## **Εντοπισμός Συγχωνευμένου Κελιού Πίνακα**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και προσπελάζει το πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια, επαναλαμβάνει όλες τις σειρές και στήλες και χρησιμοποιεί [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) για να εντοπίσει κελιά σε ενωμένες περιοχές. Για κάθε αντιστοιχία, εκτυπώνει τις συντεταγμένες του κελιού με τη σειρά `row;column`, [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--), και τις αρχικές συντεταγμένες της περιοχής, [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) και [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--).

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

## **Αφαίρεση Περιγραμμάτων Κελιών Πίνακα**

Δημιουργήστε μια [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη του διαφάνεια με το [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Τα πλάτη των στηλών, τα ύψη των σειρών και η θέση του πίνακα καθορίζονται σε μονάδες point. Το παράδειγμα ορίζει όλα τα τέσσερα περιγράμματα του κελιού σε [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/), καθιστώντας τα αόρατα.

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

## **Προσθήκη Διαγώνιων Περιγραμμάτων Κελιού**

Χρησιμοποιήστε το [getBorderDiagonalDown](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalDown--) για να σχεδιάσετε μια γραμμή από την πάνω αριστερή γωνία προς την κάτω δεξιά, και το [getBorderDiagonalUp](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalUp--) για να σχεδιάσετε μια γραμμή από την κάτω αριστερή γωνία προς την πάνω δεξιά. Μια διαγώνιος μπορεί να σηματοδοτήσει μια κεφαλίδα γωνίας· και οι δύο διαγώνιοι μπορούν να σχηματίσουν ένα X για να δηλώσουν ότι το κελί δεν ισχύει.

Κάθε διαγώνιος είναι ένα [ILineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/). Στο [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--), χρησιμοποιήστε το [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) για να επιλέξετε [FillType.Solid](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) και να διαλέξετε χρώμα μέσω του [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--). Ορίστε το πλάτος της γραμμής σε μονάδες point με το [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-).

Το παράδειγμα δημιουργεί τρία κελιά σε μια σειρά: μια κόκκινη διαγώνιο προς τα κάτω, μια μπλε διαγώνιο προς τα πάνω και και τις δύο διαγώνιους. Αφήνει τα πάνω, κάτω, αριστερά και δεξιά περιγράμματα του κελιού αμετάβλητα.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Μια διαγώνιος είναι ιδιότητα μορφοποίησης, όχι διαχωρισμός κελιού. Κάθε κελί διατηρεί ένα μοναδικό πλαίσιο κειμένου, προσπελάσιμο μέσω του [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--); οι περιοχές στα δύο πλάγια μιας διαγώνιου δεν μπορούν να επεξεργαστούν ανεξάρτητα.

Ο αποθηκευμένος πίνακας, αποτυπωμένος στο Microsoft PowerPoint:

![Τρία κελιά πίνακα που δείχνουν μια κόκκινη διαγώνιο από πάνω αριστερά προς κάτω δεξιά, μια μπλε διαγώνιο από κάτω αριστερά προς πάνω δεξιά, και και τις δύο διαγώνιους σχηματίζοντας ένα X.](diagonal-cell-borders.png)

*Αριστερά προς δεξιά: διαγώνιος προς τα κάτω (κόκκινο, 3 pt), διαγώνιος προς τα πάνω (μπλε, 5 pt), και και οι δύο διαγώνιοι.*

## **Συγχώνευση Κελιών Πίνακα**

Χρησιμοποιήστε το [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) για να συνδυάσετε μια ορθογώνια περιοχή κελιών πίνακα σε ένα κελί. Καθορίστε τα κελιά στην πάνω αριστερή και κάτω δεξιά γωνία της περιοχής. Το τελικό όρισμα ελέγχει αν η συγχώνευση μπορεί να περιλαμβάνει κελιά εκτός της καθορισμένης περιοχής· η τιμή `false` διατηρεί τη συγχώνευση εντός αυτής της περιοχής.

Το παράδειγμα δημιουργεί έναν πίνακα 4 × 4 με στήλες και σειρές 70 point, έπειτα συγχωνεύει τα τέσσερα κεντρικά κελιά από `(1, 1)` έως `(2, 2)`. Το προκύπτον κελί καλύπτει δύο στήλες και δύο σειρές, ενώ το υποκείμενο πλέγμα του πίνακα παραμένει με τέσσερις στήλες και τέσσερις σειρές. Για πρόσβαση στο περιεχόμενο ή τη μορφοποίηση του συγχωνευμένου κελιού, χρησιμοποιήστε τη θέση του στην πάνω αριστερή γωνία: `table.get_Item(1, 1)` σε αυτό το παράδειγμα. Οι άλλες θέσεις στην περιοχή της συγχώνευσης παραμένουν μέρος του πλέγματος του πίνακα, έτσι οι δείκτες των κελιών εκτός της περιοχής δεν αλλάζουν.

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

## **Διαχωρισμός Κελιών Πίνακα**

Η συγχώνευση κελιών στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Ο διαχωρισμός ενός κελιού μπορεί να εισάγει μια νέα στήλη πλέγματος και να αλλάξει τους δείκτες στήλης των κελιών στα δεξιά του. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος των πινάκων του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4 × 4 με στήλες και σειρές 70 point και καλεί το [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) στο κελί `(1, 1)`. Το μισό του πλάτους των 70 point περνιέται για να δημιουργηθούν δύο κελιά ίσου πλάτους.

Μετά από αυτόν τον διαχωρισμό, τα δύο μισά προσπελάζονται ως `table.get_Item(1, 1)` και `table.get_Item(2, 1)`. Το πλέγμα του πίνακα έχει τώρα πέντε στήλες: τα κελιά που αρχικά ήταν στις στήλες 2 και 3 μετακινούνται στις στήλες 3 και 4, αντίστοιχα. Οι δείκτες σειρών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στήλης όταν προσπελάζετε κελιά μετά τον διαχωρισμό.

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
[![Ένα μη συγχωνευμένο κελί 70-point χωρίζεται σε δύο κελιά 35-point, προσθέτοντας μια πέμπτη στήλη πλέγματος και μετατοπίζοντας τους δείκτες προς τα δεξιά.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Η διαίρεση του πλάτους επηρεάζει το κελί (1, 1), χρησιμοποιώντας δείκτες με μηδενική βάση (στήλη, σειρά). Οι άλλες σειρές διατηρούν ένα κελί που απλώνεται και στις δύο νέες θέσεις στήλης.*
<!-- visual-explanation:manage-cells:end -->

### **Διαχωρισμός Συγχωνευμένων Κελιών κατά Εύρος Σειράς ή Στήλης**

Για να προετοιμάσετε συγχωνευμένα κελιά προτύπου για την προσθήκη δεδομένων, χρησιμοποιήσετε το [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) για διαχωρισμό κατά υπάρχον όριο σειράς, ή το [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) για διαχωρισμό κατά όριο στήλης.

Το όρισμα `index` μετρά σειρές στο ανώτερο τμήμα ή στήλες στο αριστερό τμήμα του διαχωρισμού· είναι σχετικό με την ενωμένη περιοχή:

- Row split: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- Column split: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

Το παράδειγμα υποθέτει ότι μια παρουσίαση περιέχει έναν πίνακα ως πρώτο σχήμα στην πρώτη διαφάνεια, με τα `(1, 2)` και `(1, 3)` συγχωνευμένα κάθετα. Ξεκινώντας από τη χαμηλότερη θέση, χρησιμοποιεί τα [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) και [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) για να εντοπίσει την αρχή και ελέγχει και τις δύο ανοχές. Το `splitByRowSpan(1)` χωρίζει τότε τις σειρές 2 και 3 για τα ονόματα προϊόντων. Για μια οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε αντί αυτού το `splitByColSpan(1)`.

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

        // Ανακτήστε τα προκύψαντα κελιά από τον πίνακα μετά το διαχωρισμό.
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

Το πλέγμα του πίνακα και οι δείκτες των γύρω κελιών παραμένουν αμετάβλητα. Ανακτήστε τα προκύπτουσες κελιά με τις συντεταγμένες τους· εδώ, και τα δύο έχουν ανοχή 1 και το [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) εμφανίζει `false`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν εν μέρει συγχωνευμένες μετά έναν διαχωρισμό.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στο άνω (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη μορφοποίηση του κελιού, όπως γέμισμα, περιγράμματα και περιθώρια. Συμπληρώστε τα κελιά μετά το διαχωρισμό και ορίστε ρητά τυχόν απαιτούμενη μορφοποίηση κειμένου.

Η αποθηκευμένη παρουσίαση περιλαμβάνει ξεχωριστά κελιά "Product A" και "Product B" με τη μορφοποίηση του κελιού του προτύπου διατηρημένη. Δείτε την [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) για λεπτομέρειες.

### **Διαχωρισμός Κελιού με Συγκεκριμένο Ύψος**

Το [splitByHeight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByHeight-double-) λαμβάνει το ύψος του ανώτερου τμήματος σε point. Το [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) λαμβάνει τον αριθμό των υπαρχουσών σειρών πλέγματος στο ανώτερο τμήμα. Για να κεντράρετε ένα κελί 40 point στη δεξιά στήλη, αφαιρέστε 40 από το πραγματικό ύψος του κελιού και διαιρέστε το υπόλοιπο ισόποσα πάνω και κάτω.

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

Ο πρώτος διαχωρισμός προσθέτει μια σειρά πλέγματος και αφήνει τα κάτω 90 point στο κελί `(1, 1)`. Ο δεύτερος διαχωρισμός διαιρεί αυτό το κελί σε ένα μεσαίο κελί 40 point και ένα κάτω κελί 50 point. Η δεξιά στήλη έχει τώρα τρία κελιά με ύψη 50, 40 και 50 point από πάνω προς τα κάτω. Το αριστερό κελί καλύπτει όλες τις τρεις σειρές και διατηρεί το αρχικό ύψος του 140 point.

![Το αριστερό κελί καλύπτει το πλήρες ύψος του πίνακα δίπλα σε τρία κελιά με το Middle στη μέση.](split-by-height.png)

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Αυτό το παράδειγμα δημιουργεί έναν πίνακα με στήλες 150 point και σειρές 50 point. Χρησιμοποιεί το [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) για να επιλέξει γεώση συμπαγούς χρώματος και ορίζει το χρώμα που επιστρέφεται από το [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) σε κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και τέταρτη σειρά.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Τοποθετήστε την εικόνα εισόδου στον κατάλογο εργασίας πριν εκτελέσετε αυτό το παράδειγμα. Φορτώνει την εικόνα με το [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με το [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Στη συνέχεια αναθέτει την εικόνα στο γέμισμα εικόνας του κελιού `(0, 0)`, το πρώτο κελί του πίνακα.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) τεντώνει την εικόνα ώστε να γεμίζει το κελί, κάτι που μπορεί να αλλάξει την αναλογία του. Τα πλάτη των στηλών και τα ύψη των σειρών είναι σε point. Η φορτωμένη εικόνα αποδεσμεύεται σε μπλοκ `finally` αφού προστεθεί στην παρουσίαση.

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

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ορίσω διαφορετικά πάχη και στυλ γραμμής για τις διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) έχουν ξεχωριστές ιδιότητες, ώστε το πάχος και το στυλ κάθε πλευράς να μπορούν να διαφέρουν.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος της στήλης/σείρας μετά τον ορισμό μιας εικόνας ως φόντο του κελιού;**

Η συμπεριφορά εξαρτάται από το [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tile). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με το κενάκι, τα τεμάχια ξαναϋπολογίζονται.

**Μπορώ να αναθέσω έναν υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

[Hyperlinks](/slides/el/java/manage-hyperlinks/) ορίζονται επιπέδου κειμένου (portion) μέσα στο πλαίσιο κειμένου του κελιού ή στο επίπεδο ολόκληρου του πίνακα/σχήματος. Στην πράξη, αναθέτετε τον σύνδεσμο σε μια portion ή στο όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (runs) με ανεξάρτητη μορφοποίηση—οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.