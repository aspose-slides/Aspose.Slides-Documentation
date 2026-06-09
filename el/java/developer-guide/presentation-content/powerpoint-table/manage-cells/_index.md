---
title: Διαχείριση Κελιών Πίνακα σε Παρουσιάσεις Χρησιμοποιώντας Java
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
description: "Διαχειριστείτε με ευκολία τα κελιά πινάκων στο PowerPoint με το Aspose.Slides για Java. Κατακτήστε την πρόσβαση, τροποποίηση και στυλιζάρισμα των κελιών γρήγορα για απρόσκοπτη αυτοματοποίηση διαφανειών."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να έχετε πρόσβαση και να τροποποιείτε τα κελιά πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένα κελιά πινάκων, να αφαιρείτε τα περιγράμματα των κελιών, να εργάζεστε με την αρίθμηση των κελιών μετά τη συγχώνευση ή το διαχωρισμό τους, να αλλάζετε το χρώμα φόντου ενός κελιού και να προσθέτετε μια εικόνα μέσα σε ένα κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να πάρετε έναν πίνακα από ένα σλάιντ, να ενημερώσετε τη μορφοποίηση του κελιού μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε τη τροποποιημένη παρουσίαση ως αρχείο PPTX.

## **Εντοπισμός Συγχωνευμένου Κελιού Πίνακα**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε τον πίνακα από το πρώτο σλάιντ.
3. Περιηγηθείτε στις γραμμές και στήλες του πίνακα για να βρείτε συγχωνευμένα κελιά.
4. Εκτυπώστε μήνυμα όταν βρεθούν συγχωνευμένα κελιά.

Αυτός ο κώδικας Java δείχνει πώς να εντοπίσετε συγχωνευμένα κελιά πίνακα σε μια παρουσίαση:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // υποθέτοντας ότι το Slide#0.Shape#0 είναι ένας πίνακας
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

## **Αφαίρεση Περιγραμμάτων Κυψελών Πίνακα**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά ενός σλαίντ μέσω του δείκτη του.
3. Ορίστε έναν πίνακα στηλών με πλάτος.
4. Ορίστε έναν πίνακα γραμμών με ύψος.
5. Προσθέστε έναν πίνακα στο σλάιντ μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Περιηγηθείτε σε κάθε κελί για να αφαιρέσετε τα πάνω, κάτω, δεξιό και αριστερό περίγραμμα.
7. Αποθηκεύστε τη τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να αφαιρέσετε τα περιγράμματα από τα κελιά πίνακα:

```java
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Προσπελαύνει την πρώτη διαφάνεια
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και γραμμές με ύψη
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Προσθέτει σχήμα πίνακα στη διαφάνεια
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ορίζει το φορμά περιγράμματος για κάθε κελί
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

    // Γράφει το αρχείο PPTX στον δίσκο
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αρίθμηση σε Συγχωνευμένα Κελιά**
Αν συγχωνεύσουμε 2 ζεύγη κελιών (1, 1) x (2, 1) και (1, 2) x (2, 2), ο προκύπτων πίνακας θα είναι αριθμημένος. Αυτός ο κώδικας Java επιδεικνύει τη διαδικασία:

```java
// Δημιουργεί αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Προσεγγίζει την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και γραμμές με ύψη
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

Στη συνέχεια, συγχωνεύουμε περαιτέρω τα κελιά συγχωνεύοντας τα (1, 1) και (1, 2). Το αποτέλεσμα είναι ένας πίνακας που περιέχει ένα μεγάλο συγχωνευμένο κελί στο κέντρο του:

```java
// Δημιουργεί αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Προσπελάζει την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και γραμμές με ύψη
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
    
    //Γράφει το αρχείο PPTX στον δίσκο
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αρίθμηση σε Διαχωρισμένο Κελιά**
Στα προηγούμενα παραδείγματα, όταν τα κελιά πίνακα συγχωνεύονταν, η αρίθμηση ή το σύστημα αριθμών στα άλλα κελιά δεν άλλαζε.

Αυτή τη φορά, παίρνουμε έναν κανονικό πίνακα (έναν πίνακα χωρίς συγχωνευμένα κελιά) και προσπαθούμε να διαχωρίσουμε το κελί (1,1) για να δημιουργήσουμε έναν ειδικό πίνακα. Ενδέχεται να θέλετε να προσέξετε την αρίθμηση αυτού του πίνακα, η οποία μπορεί να φαίνεται παράξενη. Ωστόσο, αυτός είναι ο τρόπος με τον οποίο το Microsoft PowerPoint αριθμεί τα κελιά πίνακα και το Aspose.Slides κάνει το ίδιο.

Αυτός ο κώδικας Java επιδεικνύει τη διαδικασία που περιγράψαμε:

```java
// Δημιουργεί αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Προσπελάζει την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και γραμμές με ύψη
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

    //Γράφει το αρχείο PPTX στον δίσκο
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

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά ενός σλαίντ μέσω του δείκτη του.
3. Ορίστε έναν πίνακα στηλών με πλάτος.
4. Ορίστε έναν πίνακα γραμμών με ύψος.
5. Προσθέστε έναν πίνακα στο σλάιντ μέσω της μεθόδου [AddTable](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Δημιουργήστε ένα αντικείμενο `Images` για να κρατήσει το αρχείο εικόνας.
7. Προσθέστε την εικόνα `IImage` στο αντικείμενο `IPPImage`.
8. Ορίστε το `FillFormat` για το Κελί Πίνακα σε `Picture`.
9. Προσθέστε την εικόνα στο πρώτο κελί του πίνακα.
10. Αποθηκεύστε τη τροποποιημένη παρουσίαση ως αρχείο PPTX

Αυτός ο κώδικας Java δείχνει πώς να τοποθετήσετε μια εικόνα μέσα σε ένα κελί πίνακα κατά τη δημιουργία πίνακα:

```java
// Δημιουργεί το αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Προσπελάζει την πρώτη διαφάνεια
    ISlide islide = pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και γραμμές με ύψη
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

**Μπορώ να ορίσω διαφορετικά πάχη γραμμής και στυλ για διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιγράμματα [επάνω](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellformat/#getBorderTop--)/[κάτω](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellformat/#getBorderBottom--)/[αριστερά](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellformat/#getBorderLeft--)/[δεξιά](https://reference.aspose.com/slides/el/java/com.aspose.slides/cellformat/#getBorderRight--) έχουν ξεχωριστές ιδιότητες, ώστε το πάχος και το στυλ κάθε πλευράς να μπορεί να διαφέρει. Αυτό προκύπτει λογικά από τον έλεγχο περιγράμματος ανά πλευρά για ένα κελί που παρουσιάζεται στο άρθρο.

**Τι συμβαίνει με την εικόνα εάν αλλάξω το μέγεθος της στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντο του κελιού;**

Η συμπεριφορά εξαρτάται από το [mode πλήρωσης](https://reference.aspose.com/slides/el/java/com.aspose.slides/picturefillmode/) (stretch/tile). Με το stretch, η εικόνα προσαρμόζεται στο νέο κελί· με το tile, τα πλακίδια επανυπολογίζονται. Το άρθρο αναφέρει τις λειτουργίες εμφάνισης εικόνας σε ένα κελί.

**Μπορώ να αντιστοιχίσω υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

[Hyperlinks](/slides/el/java/manage-hyperlinks/) ρυθμίζονται στο επίπεδο του κειμένου (portion) μέσα στο πλαίσιο κειμένου του κελιού ή στο επίπεδο ολόκληρου του πίνακα/σχήματος. Στην πράξη, αντιστοιχίζετε τον σύνδεσμο σε μια περιοχή ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει [portions](https://reference.aspose.com/slides/el/java/com.aspose.slides/portion/) (run) με ανεξάρτητη μορφοποίηση — οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.