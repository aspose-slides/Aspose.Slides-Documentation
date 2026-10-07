---
title: Διαχείριση κελιών πίνακα σε παρουσιάσεις Android
linktitle: Διαχείριση Κελιών
type: docs
weight: 30
url: /el/androidjava/manage-cells/
keywords:
- κελί πίνακα
- συγχώνευση κελιών
- αφαίρεση περιγράμματος
- διαχωρισμός κελιού
- εικόνα σε κελί
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα κελιά πίνακα PowerPoint στο Android: εντοπίστε συγχωνευμένα κελιά, αφαιρέστε περιγράμματα, διαχωρίστε κελιά και ορίστε χρώματα φόντου και εικόνες με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να έχετε πρόσβαση και να τροποποιήσετε τα κελιά πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίσετε συγχωνευμένα κελιά πινάκων, να αφαιρέσετε τα περιγράμματα των κελιών, να εργαστείτε με την αρίθμηση κελιών μετά τη συγχώνευση ή τον διαχωρισμό, να αλλάξετε το χρώμα φόντου ενός κελιού και να προσθέσετε εικόνα μέσα σε κελί πινάκου. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να αποκτήσετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση των κελιών μέσω των ιδιοτήτων των κελιών και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες που ξεκινούν από το μηδέν για να έχει πρόσβαση στα κελιά του πίνακα με τη σειρά `(στήλη, γραμμή)`.

## **Εντοπισμός Συγχωνευμένου Κελιού Πίνακα**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και αποκτά το πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια επαναλαμβάνει όλες τις γραμμές και τις στήλες και χρησιμοποιεί [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) για να εντοπίσει κελιά σε συγχωνευμένες περιοχές. Για κάθε ταιριάζον αποτέλεσμα, εκτυπώνει τις συντεταγμένες του κελιού με τη σειρά `γραμμή;στήλη`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), και τις αρχικές συντεταγμένες της περιοχής, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) και [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

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

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη του διαφάνεια με την [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Τα πλάτη των στηλών, τα ύψη των γραμμών και η θέση του πίνακα ορίζονται σε σημεία. Το παράδειγμα ορίζει και τα τέσσερα περιγράμματα κελιών στο [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), καθιστώντας τα αόρατα.

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

## **Συγχώνευση Κελιών Πίνακα**

Χρησιμοποιήστε την [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) για να συνδυάσετε ένα ορθογώνιο εύρος κελιών σε ένα κελί. Καθορίστε τα κελιά στην πάνω‑αριστερή και στην κάτω‑δεξιά γωνία του εύρους. Η τελική παράμετρος ελέγχει αν η συγχώνευση μπορεί να περιλάβει κελιά εκτός του καθορισμένου εύρους· το `false` περιορίζει τη συγχώνευση στο εύρος αυτό.

Το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και γραμμές 70 σημείων, στη συνέχεια συγχωνεύει τα τέσσερα κεντρικά κελιά από το `(1, 1)` έως το `(2, 2)`. Το αποτέλεσμα είναι ένα κελί που εκτείνεται σε δύο στήλες και δύο γραμμές, ενώ το υποκείμενο πλέγμα του πίνακα διατηρεί τέσσερις στήλες και τέσσερις γραμμές. Για να έχετε πρόσβαση στο περιεχόμενο ή τη μορφοποίηση του συγχωνευμένου κελιού, χρησιμοποιήστε τη θέση του πάνω‑αριστερού άκρου: `table.get_Item(1, 1)` σε αυτό το παράδειγμα. Οι άλλες θέσεις στο συγχωνευμένο εύρος παραμένουν μέρος του πλέγματος του πίνακα, οπότε οι δείκτες των κελιών εκτός του εύρους δεν αλλάζουν.

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

Η συγχώνευση κελιών στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Η διαίρεση ενός κελιού μπορεί να εισάγει μια νέα στήλη πλέγματος και να αλλάξει τους δείκτες των στηλών των κελιών δεξιά του. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος πινάκων του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και γραμμές 70 σημείων και καλεί την [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) στο κελί `(1, 1)`. Η μισή από το πλάτος των 70 σημείων του κελιού περνιέται για να δημιουργηθούν δύο κελιά ίσου πλάτους.

Μετά από αυτή τη διαίρεση, οι δύο μισές προσεγγίζονται ως `table.get_Item(1, 1)` και `table.get_Item(2, 1)`. Το πλέγμα του πίνακα έχει τώρα πέντε στήλες: τα κελιά που αρχικά ήταν στις στήλες 2 και 3 μετακινούνται στις στήλες 3 και 4, αντίστοιχα. Οι δείκτες γραμμών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στηλών όταν έχετε πρόσβαση σε κελιά μετά τη διαίρεση.

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

### **Διαίρεση Συγχωνευμένων Κελιών κατά Γραμμή ή Στήλη**

Για να προετοιμάσετε συγχωνευμένα κελιά προτύπου για την πληρότητα δεδομένων, χρησιμοποιήστε την [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) ώστε να διαχωρίσετε κατά υπάρχον όριο γραμμής, ή την [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) ώστε να διαχωρίσετε κατά όριο στήλης.

Η παράμετρος `index` μετράει τις γραμμές στο άνω μέρος ή τις στήλες στο αριστερό μέρος του διαχωρισμού· είναι σχετική με τη συγχωνευμένη περιοχή:

- Διαχωρισμός γραμμής: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Διαχωρισμός στήλης: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

Το παράδειγμα προϋποθέτει ότι η παρουσίαση διαθέτει πίνακα ως πρώτο σχήμα στην πρώτη διαφάνεια, με τα `(1, 2)` και `(1, 3)` συγχωνευμένα κάθετα. Ξεκινώντας από τη χαμηλότερη θέση, χρησιμοποιεί το [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) και το [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) για να εντοπίσει την προέλευση και ελέγχει και τις δύο εκτάσεις. Το `splitByRowSpan(1)` στη συνέχεια διαχωρίζει τις γραμμές 2 και 3 για τα ονόματα προϊόντων. Για μια οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε το `splitByColSpan(1)`.

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

        // Ανακτήστε τα προκύπτοντα κελιά από τον πίνακα μετά το διαχωρισμό.
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

Το πλέγμα του πίνακα και οι γύρω δείκτες κελιών παραμένουν αμετάβλητοι. Ανακτήστε τα προκύπτοντα κελιά με τις συντεταγμένες τους· εδώ, και τα δύο έχουν εκτάσεις 1 και το [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) εμφανίζει `false`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν εν μέρει συγχωνευμένες μετά από ένα διαχωρισμό.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στο άνω (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη μορφοποίηση του κελιού όπως γέμισμα, περιγράμματα και περιθώρια. Συμπληρώστε τα κελιά μετά το διαχωρισμό και ορίστε ρητά τυχόν απαιτούμενη μορφοποίηση κειμένου.

Η αποθηκευμένη παρουσίαση περιέχει ξεχωριστά κελιά "Product A" και "Product B" με τη μορφοποίηση του προτύπου διατηρημένη. Δείτε την [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) για λεπτομέρειες.

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Αυτό το παράδειγμα δημιουργεί έναν πίνακα με στήλες 150 σημείων και γραμμές 50 σημείων. Χρησιμοποιεί το [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) για να επιλέξει γεμισμό συμπαγούς χρώματος και ορίζει το χρώμα που επιστρέφεται από το [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) σε κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και τέταρτη γραμμή.

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

Τοποθετήστε την είσοδο εικόνας στον φάκελο εργασίας πριν τρέξετε αυτό το παράδειγμα. Φορτώνει την εικόνα με το [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με το [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Στη συνέχεια αναθέτει την εικόνα στο γέμισμα εικόνας του κελιού `(0, 0)`, του πρώτου κελιού του πίνακα.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) τεντώνει την εικόνα ώστε να γεμίσει το κελί, γεγονός που μπορεί να αλλάξει την αναλογία του. Τα πλάτη των στηλών και τα ύψη των γραμμών είναι σε σημεία. Η φορτωμένη εικόνα διαγράφεται σε μπλοκ `finally` μετά την προσθήκη της στην παρουσίαση.

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

## **FAQ**

**Μπορώ να ορίσω διαφορετικά πάχη και στυλ γραμμής για διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) έχουν ξεχωριστές ιδιότητες, έτσι ώστε το πάχος και το στυλ κάθε πλευράς να μπορεί να διαφέρει.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντο κελιού;**

Η συμπεριφορά εξαρτάται από τη [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με επικάλυψη, τα τεμάχια επαναϋπολογίζονται.

**Μπορώ να αναθέσω υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

[Hyperlinks](/slides/el/androidjava/manage-hyperlinks/) ορίζονται στο επίπεδο κειμένου (τμήματος) μέσα στο πλαίσιο κειμένου του κελιού ή στο επίπεδο ολόκληρου του πίνακα/σχήματος. Στην πράξη, αναθέτετε τον σύνδεσμο σε ένα τμήμα ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (τεμάχια) με ανεξάρτητη μορφοποίηση—οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.