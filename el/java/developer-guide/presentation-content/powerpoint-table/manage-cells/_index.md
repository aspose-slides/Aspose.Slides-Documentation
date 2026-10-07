---
title: Διαχείριση κελιών πίνακα σε παρουσιάσεις χρησιμοποιώντας Java
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
description: "Διαχειριστείτε τα κελιά πίνακα PowerPoint σε Java: εντοπίστε συγχωνευμένα κελιά, αφαιρέστε περιγράμματα, διαχωρίστε κελιά και ορίστε χρώματα φόντου και εικόνες με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να έχετε πρόσβαση και να τροποποιείτε κελιά πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένα κελιά πινάκων, να αφαιρείτε τα περιθώρια των κελιών, να εργάζεστε με την αρίθμηση των κελιών μετά τη συγχώνευση ή το διαχωρισμό τους, να αλλάζετε το χρώμα φόντου ενός κελιού και να προσθέτετε μια εικόνα μέσα σε ένα κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να πάρετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση του κελιού μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Το Aspose.Slides χρησιμοποιεί δείκτες που ξεκινούν από το μηδέν για πρόσβαση στα κελιά πινάκων με τη σειρά `(column, row)`.

## **Εντοπισμός Συγχωνευμένου Κελιού Πίνακα**

Το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και προσπελαύνει το πρώτο σχήμα στην πρώτη διαφάνεια ως πίνακα. Υποθέτει ότι η διαφάνεια και το σχήμα υπάρχουν και ότι το σχήμα είναι πίνακας. Στη συνέχεια επαναλαμβάνει όλες τις γραμμές και στήλες και χρησιμοποιεί [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) για να εντοπίσει κελιά σε συγχωνευμένες περιοχές. Για κάθε αντιστοιχία, εκτυπώνει τις συντεταγμένες του κελιού με τη σειρά `row;column`, [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--), και τις αρχικές συντεταγμένες της περιοχής, [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--), και [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--).

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

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) και προσθέστε έναν πίνακα στην πρώτη του διαφάνεια με τη μέθοδο [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Τα πλάτη των στηλών, τα ύψη των γραμμών και η θέση του πίνακα καθορίζονται σε μονάδες σημείου. Το παράδειγμα ορίζει όλα τα τέσσερα περιγράμματα του κελιού σε [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/), καθιστώντας τα αόρατα.

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

Χρησιμοποιήστε τη μέθοδο [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) για να συνδυάσετε μια ορθογώνια περιοχή κελιών πίνακα σε ένα κελί. Καθορίστε τα κελιά στην επάνω αριστερή και κάτω δεξιά γωνία της περιοχής. Το τελευταίο όρισμα ελέγχει αν η συγχώνευση μπορεί να περιλαμβάνει κελιά εκτός της καθορισμένης περιοχής· `false` διατηρεί τη συγχώνευση εντός αυτής της περιοχής.

Το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και γραμμές 70 σημείων, έπειτα συγχωνεύει τα τέσσερα κεντρικά κελιά από το `(1, 1)` έως το `(2, 2)`. Το προκύπτον κελί εκτείνεται σε δύο στήλες και δύο γραμμές, ενώ το υποκείμενο πλέγμα του πίνακα διατηρεί τέσσερις στήλες και τέσσερις γραμμές. Για να προσπελάσετε το περιεχόμενο ή τη μορφοποίηση του συγχωνευμένου κελιού, χρησιμοποιήστε τη θέση του επάνω αριστερά: `table.get_Item(1, 1)` σε αυτό το παράδειγμα. Οι άλλες θέσεις στην συγχωνευμένη περιοχή παραμένουν μέρος του πλέγματος του πίνακα, έτσι οι δείκτες των κελιών εκτός της περιοχής δεν αλλάζουν.

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

Η συγχώνευση κελιών στο προηγούμενο παράδειγμα διατηρεί το πλέγμα του πίνακα. Ο διαχωρισμός ενός κελιού μπορεί να εισαγάγει μια νέα στήλη στο πλέγμα και να αλλάξει τους δείκτες στήλης των κελιών στα δεξιά του. Το Aspose.Slides ακολουθεί το μοντέλο πλέγματος πίνακα του PowerPoint.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 4x4 με στήλες και γραμμές 70 σημείων και καλεί τη μέθοδο [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) στο κελί `(1, 1)`. Το ήμισυ του πλάτους των 70 σημείων του κελιού περνιέται για τη δημιουργία δύο κελιών ίσου πλάτους.

Μετά από αυτόν τον διαχωρισμό, τα δύο μισά προσπελαύνονται ως `table.get_Item(1, 1)` και `table.get_Item(2, 1)`. Το πλέγμα του πίνακα έχει πλέον πέντε στήλες: τα κελιά που αρχικά ήταν στις στήλες 2 και 3 μετακινήθηκαν στις στήλες 3 και 4, αντίστοιχα. Οι δείκτες γραμμών παραμένουν αμετάβλητοι. Χρησιμοποιήστε αυτούς τους ενημερωμένους δείκτες στήλης όταν προσπελάζετε κελιά μετά τον διαχωρισμό.

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

### **Διαχωρισμός Συγχωνευμένων Κελιών κατά Εύρος Γραμμής ή Στήλης**

Για να προετοιμάσετε τα συγχωνευμένα κελιά προτύπου για την εισαγωγή δεδομένων, χρησιμοποιήστε τη μέθοδο [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) για διαχωρισμό κατά μια υπάρχουσα γραμμή, ή τη μέθοδο [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) για διαχωρισμό κατά μια στήλη.

Το όρισμα `index` μετρά τις γραμμές στο άνω τμήμα ή τις στήλες στο αριστερό τμήμα του διαχωρισμού· είναι σχετικό με τη συγχωνευμένη περιοχή:

- Διχάρισμα γραμμής: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- Διχάρισμα στήλης: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

Το παράδειγμα αναμένει μια παρουσίαση να έχει έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια, με τα `(1, 2)` και `(1, 3)` συγχωνευμένα κατακόρυφα. Ξεκινώντας από τη χαμηλότερη θέση, χρησιμοποιεί [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) και [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) για να εντοπίσει το αρχικό σημείο και ελέγχει και τις δύο εκτάσεις. Η κλήση `splitByRowSpan(1)` στη συνέχεια χωρίζει τις γραμμές 2 και 3 για τα ονόματα προϊόντων. Για μια οριζόντια συγχώνευση δύο στηλών, χρησιμοποιήστε `splitByColSpan(1)` αντίγια.

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

Το πλέγμα του πίνακα και οι γύρω δείκτες κελιών παραμένουν αμετάβλητοι. Ανακτήστε τα προκύπτοντα κελιά με βάση τις συντεταγμένες τους· εδώ και τα δύο έχουν εκτάσεις 1 και το [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) εμφανίζει `false`. Μεγαλύτερες περιοχές μπορούν να παραμείνουν κατά μέρος συγχωνευμένες μετά έναν διαχωρισμό.

Το αρχικό κείμενο και η μορφοποίησή του παραμένουν στο άνω (ή αριστερό) κελί· το νέο κελί είναι κενό αλλά κληρονομεί τη μορφοποίηση του κελιού όπως γέμισμα, περιγράμματα και περιθώρια. Συμπληρώστε τα κελιά μετά το διαχωρισμό και ορίστε ρητά τυχόν απαιτούμενη μορφοποίηση κειμένου.

Η αποθηκευμένη παρουσίαση περιέχει ξεχωριστά κελιά «Product A» και «Product B» με τη διατήρηση της μορφοποίησης κελιού του προτύπου. Δείτε την [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) για λεπτομέρειες.

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 150‑σημείων στήλης και 50‑σημείων γραμμής. Χρησιμοποιεί το [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) για επιλογή ενιαίου γεμίσματος και ορίζει το χρώμα που επιστρέφεται από το [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) σε κόκκινο για το κελί `(2, 3)`, στην τρίτη στήλη και τέταρτη γραμμή.

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

## **Προσθήκη Εικόνας μέσα σε Κελί Πίνακα**

Τοποθετήστε την εισαγόμενη εικόνα στον κατάλογο εργασίας πριν εκτελέσετε αυτό το παράδειγμα. Φορτώνει την εικόνα με το [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) και την προσθέτει στη συλλογή εικόνων της παρουσίασης με το [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Στη συνέχεια αναθέτει την εικόνα στο γέμισμα εικόνας του κελιού `(0, 0)`, του πρώτου κελιού στον πίνακα.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) τεντώνει την εικόνα ώστε να γεμίσει το κελί, κάτι που μπορεί να αλλάξει την αναλογία διαστάσεων. Τα πλάτη των στηλών και τα ύψη των γραμμών είναι σε σημεία. Η φορτωμένη εικόνα απελευθερώνεται σε ένα μπλοκ `finally` μετά την προσθήκη της στην παρουσίαση.

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

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω διαφορετικά πάχη γραμμών και στυλ για τις διάφορες πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [επάνω](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[κάτω](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[αριστερά](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[δεξιά](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) έχουν ξεχωριστές ιδιότητες, ώστε το πάχος και το στυλ κάθε πλευράς μπορούν να διαφέρουν.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος της στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντο του κελιού;**

Η συμπεριφορά εξαρτάται από τη [λειτουργία γεμίσματος](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tile). Με τέντωμα, η εικόνα προσαρμόζεται στο νέο κελί· με την επικάλυψη, τα τμήματα επαναϋπολογίζονται.

**Μπορώ να εκχωρήσω υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

Οι [Υπερσύνδεσμοι](/slides/el/java/manage-hyperlinks/) ορίζονται στο επίπεδο κειμένου (τμήματος) μέσα στο πλαίσιο κειμένου του κελιού ή στο επίπεδο ολόκληρου πίνακα/σχήματος. Στην πράξη, εκχωρείτε τον σύνδεσμο σε ένα τμήμα ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [τμήματα](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (runs) με ανεξάρτητη μορφοποίηση — οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.