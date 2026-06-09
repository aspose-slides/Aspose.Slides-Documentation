---
title: Διαχείριση κελιών πίνακα σε παρουσιάσεις στο Android
linktitle: Διαχείριση κελιών
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
description: "Διαχειριστείτε άψογα τα κελιά πίνακα στο PowerPoint με το Aspose.Slides για Android μέσω Java. Κατακτήστε την πρόσβαση, την τροποποίηση και το στυλιζάρισμα των κελιών γρήγορα για αδιάλειπτη αυτοματοποίηση διαφανειών."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να αποκτήσετε πρόσβαση και να τροποποιήσετε τα κελιά πίνακα σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίσετε συγχωνευμένα κελιά πίνακα, να αφαιρέσετε τα περιθώρια των κελιών, να εργαστείτε με την αρίθμηση των κελιών μετά τη συγχώνευση ή το διαχωρισμό τους, να αλλάξετε το χρώμα φόντου ενός κελιού και να προσθέσετε μια εικόνα μέσα σε κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να πάρετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση του κελιού μέσω των ιδιοτήτων του και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

## **Αναγνώριση Συγχωνευμένου Κελιού Πίνακα**
1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε τον πίνακα από την πρώτη διαφάνεια. 
3. Επαναλάβετε τις γραμμές και στήλες του πίνακα για να βρείτε συγχωνευμένα κελιά.
4. Εκτυπώστε μήνυμα όταν βρεθούν συγχωνευμένα κελιά.

Αυτός ο κώδικας Java δείχνει πώς να εντοπίσετε συγχωνευμένα κελιά πίνακα σε μια παρουσίαση:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // υποθέτοντας ότι το Slide#0.Shape#0 είναι πίνακας
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αφαίρεση Περιγραμμάτων Κελιών Πίνακα**
1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά σε διαφάνεια με βάση το δείκτη της. 
3. Ορίστε έναν πίνακα στηλών με το πλάτος.
4. Ορίστε έναν πίνακα σειρών με το ύψος.
5. Προσθέστε έναν πίνακα στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Επαναλάβετε κάθε κελί για να καθαρίσετε τα πάνω, κάτω, δεξιά και αριστερά περιγράμματα.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να αφαιρέσετε τα περιγράμματα από κελιά πίνακα:

```java
// Δημιουργεί μια Presentation κλάση που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Προσθέτει σχήμα πίνακα στη διαφάνεια
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ορίζει τη μορφή περιγράμματος για κάθε κελί
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // Γράφει το PPTX στο δίσκο
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αρίθμηση σε Συγχωνευμένα Κελιά**
Αν συγχωνεύσουμε 2 ζεύγη κελιών (1, 1) x (2, 1) και (1, 2) x (2, 2), ο προκύπτων πίνακας θα αριθμηθεί. Αυτός ο κώδικας Java παρουσιάζει τη διαδικασία:

```java
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Προσθέτει σχήμα πίνακα στη διαφάνεια
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ορίζει τη μορφή περιγράμματος για κάθε κελί
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Συγχωνεύει τα κελιά (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Συγχωνεύει τα κελιά (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Στη συνέχεια συγχωνεύουμε περαιτέρω τα κελιά συγχωνεύοντας τα (1, 1) και (1, 2). Το αποτέλεσμα είναι ένας πίνακας που περιέχει ένα μεγάλο συγχωνευμένο κελί στο κέντρο του:

```java
// Δημιουργεί αντικείμενο Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Προσθέτει σχήμα πίνακα στη διαφάνεια
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ορίζει τη μορφή περιγράμματος για κάθε κελί
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Συγχωνεύει τα κελιά (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Συγχωνεύει τα κελιά (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Συγχωνεύει τα κελιά (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
	
	// Γράφει το αρχείο PPTX στο δίσκο
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αρίθμηση σε Διαχωρισμένο Κελί**
Στα προηγούμενα παραδείγματα, όταν τα κελιά πίνακα συγχωνεύτηκαν, το σύστημα αρίθμησης στα άλλα κελιά δεν άλλαξε.

Αυτή τη φορά, παίρνουμε έναν κανονικό πίνακα (χωρίς συγχωνευμένα κελιά) και στη συνέχεια προσπαθούμε να διαχωρίσουμε το κελί (1,1) ώστε να προκύψει ένας ιδιαίτερος πίνακας. Ίσως θέλετε να προσέξετε την αρίθμηση αυτού του πίνακα, η οποία μπορεί να φανεί περίεργη. Ωστόσο, έτσι αριθμεί τα κελιά πίνακα το Microsoft PowerPoint και το Aspose.Slides κάνει το ίδιο.

Αυτός ο κώδικας Java δείχνει τη διαδικασία που περιγράψαμε:

```java
// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Προσθέτει σχήμα πίνακα στη διαφάνεια
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ορίζει τη μορφή περιγράμματος για κάθε κελί
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
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
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αλλαγή Χρώματος Φόντου Κελιού Πίνακα**

Αυτός ο κώδικας Java δείχνει πώς να αλλάξετε το χρώμα φόντου ενός κελιού πίνακα:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // δημιουργεί νέο πίνακα
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // ορίζει το χρώμα φόντου για ένα κελί 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Προσθήκη Εικόνας Μέσα σε Κελί Πίνακα**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε μια αναφορά σε διαφάνεια με βάση το δείκτη της.
3. Ορίστε έναν πίνακα στηλών με το πλάτος.
4. Ορίστε έναν πίνακα σειρών με το ύψος.
5. Προσθέστε έναν πίνακα στη διαφάνεια μέσω της μεθόδου [AddTable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Δημιουργήστε ένα αντικείμενο `Images` για να κρατήσει το αρχείο εικόνας.
7. Προσθέστε την εικόνα `IImage` στο αντικείμενο `IPPImage`.
8. Ορίστε το `FillFormat` του κελιού πίνακα σε `Picture`.
9. Προσθέστε την εικόνα στο πρώτο κελί του πίνακα.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να τοποθετήσετε μια εικόνα μέσα σε κελί πίνακα κατά τη δημιουργία ενός πίνακα:

```java
// Δημιουργεί την κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide islide = pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Προσθέτει σχήμα πίνακα στη διαφάνεια
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Δημιουργεί αντικείμενο IPPImage χρησιμοποιώντας το αρχείο εικόνας
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Προσθέτει την εικόνα στο πρώτο κελί του πίνακα
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Αποθηκεύει το αρχείο PPTX στον δίσκο
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω διαφορετικά πάχη και στυλ γραμμής για διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [top](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cellformat/#getBorderRight--) έχουν ξεχωριστές ιδιότητες, ώστε το πάχος και το στυλ της κάθε πλευράς να μπορούν να διαφέρουν. Αυτό προκύπτει λογικά από τον έλεγχο περιθωρίων ανά πλευρά για ένα κελί που παρουσιάζεται στο άρθρο.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντου του κελιού;**

Η συμπεριφορά εξαρτάται από τη [fill mode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile). Με το stretching, η εικόνα προσαρμόζεται στο νέο κελί· με το tiling, τα πλακίδια επανυπολογίζονται. Το άρθρο αναφέρει τις λειτουργίες εμφάνισης εικόνας σε κελί.

** Μπορώ να προσθέσω υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

[Hyperlinks](/slides/el/androidjava/manage-hyperlinks/) ορίζονται στο επίπεδο κειμένου (portion) μέσα στο πλαίσιο κειμένου του κελιού ή στο επίπεδο ολόκληρου πίνακα/σχήματος. Στην πράξη, ορίζετε το σύνδεσμο σε μια portion ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portion/) (runs) με ανεξάρτητη μορφοποίηση—συγγένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.