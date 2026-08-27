---
title: Διαχείριση Πινάκων Παρουσίασης σε Java
linktitle: Διαχείριση Πίνακα
type: docs
weight: 10
url: /el/java/manage-table/
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
- Java
- Aspose.Slides
description: "Δημιουργήστε & επεξεργαστείτε πίνακες σε διαφάνειες PowerPoint με το Aspose.Slides για Java. Ανακαλύψτε απλά παραδείγματα κώδικα για να βελτιστοποιήσετε τις ροές εργασίας με τους πίνακες."
---
## **Εισαγωγή**

Ένας πίνακας στο PowerPoint είναι ένας αποδοτικός τρόπος εμφάνισης και απεικόνισης πληροφοριών. Οι πληροφορίες σε ένα πλέγμα κελιών (διατεταγμένα σε σειρές και στήλες) είναι απλές και εύκολα κατανοητές.

Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/java/com.aspose.slides/Table), το interface [ITable](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITable), την κλάση [Cell](https://reference.aspose.com/slides/el/java/com.aspose.slides/cell/), το interface [ICell](https://reference.aspose.com/slides/el/java/com.aspose.slides/icell/) και άλλους τύπους για να μπορείτε να δημιουργείτε, ενημερώνετε και διαχειρίζεστε πίνακες σε κάθε είδους παρουσιάσεις. 

## **Δημιουργία Πίνακα από το μηδέν**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα `columnWidth`.
4. Ορίστε έναν πίνακα `rowHeight`.
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITable) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Περιηγηθείτε σε κάθε [ICell](https://reference.aspose.com/slides/el/java/com.aspose.slides/icell/) για να εφαρμόσετε μορφοποίηση στα άνω, κάτω, δεξιά και αριστερά σύνορα.
7. Συγχωνεύστε τα πρώτα δύο κελιά της πρώτης σειράς του πίνακα. 
8. Πρόσβαση στο [TextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/textframe/) ενός [ICell](https://reference.aspose.com/slides/el/java/com.aspose.slides/icell/). 
9. Προσθέστε κάποιο κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/textframe/).
10. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε έναν πίνακα σε μια παρουσίαση:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ορίζει τη μορφοποίηση του περιγράμματος για κάθε κελί
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Συγχωνεύει τα κελιά 1 & 2 της σειράς 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // Προσθέτει κείμενο στο συγχωνευμένο κελί
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αρίθμηση σε έναν Κανονικό Πίνακα**

Σε έναν κανονικό πίνακα, η αρίθμηση των κελιών είναι απλή και αρχίζει από το μηδέν. Το πρώτο κελί σε έναν πίνακα έχει δείκτη 0,0 (στήλη 0, σειρά 0). 

Για παράδειγμα, τα κελιά σε έναν πίνακα με 4 στήλες και 4 σειρές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτός ο κώδικας Java δείχνει πώς να καθορίσετε την αρίθμηση των κελιών σε έναν πίνακα:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Προσβάλλει την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ορίζει τη μορφοποίηση του περιγράμματος για κάθε κελί
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

    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Πρόσβαση σε Υπάρχοντα Πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Λάβετε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITable) και ορίστε το σε null.
4. Περιηγηθείτε σε όλα τα αντικείμενα [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) μέχρι να βρεθεί ο πίνακας.

   Αν υποψιάζεστε ότι η διαφάνεια που διαχειρίζεστε περιέχει έναν μόνο πίνακα, μπορείτε απλώς να ελέγξετε όλα τα σχήματα που περιέχει. Όταν ένα shape προσδιορίζεται ως πίνακας, μπορείτε να το μετατρέψετε σε αντικείμενο [Table](https://reference.aspose.com/slides/el/java/com.aspose.slides/Table). Αν όμως η διαφάνεια περιέχει πολλούς πίνακες, είναι καλύτερο να αναζητήσετε τον πίνακα που χρειάζεστε μέσω της μεθόδου [setAlternativeText(String value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).
5. Χρησιμοποιήστε το αντικείμενο [ITable](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITable) για να εργαστείτε με τον πίνακα. Στο παρακάτω παράδειγμα προσθέσαμε μια νέα σειρά στον πίνακα.
6. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτός ο κώδικας Java δείχνει πώς να αποκτήσετε πρόσβαση και να εργαστείτε με έναν υπάρχοντα πίνακα:

```java
import com.aspose.slides.*;

// Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Αρχικοποιεί το TableEx σε null
    ITable tbl = null;

    // Διατρέχει τα σχήματα και ορίζει μια αναφορά στον πίνακα που βρέθηκε
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Ορίζει το κείμενο για την πρώτη στήλη της δεύτερης σειράς
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Αποθηκεύει την τροποποιημένη παρουσίαση στο δίσκο
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εύρεση του Κελιού που Κατέχει ένα Πλαίσιο Κειμένου**

Όταν γενικός κώδικας επεξεργασίας κειμένου λαμβάνει ένα [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/) από πίνακα, χρησιμοποιήστε τη μέθοδο [ITextFrame.getParentCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#getParentCell--) για να ανακτήσετε το ιδιοκτησιακό [ICell](https://reference.aspose.com/slides/el/java/com.aspose.slides/icell/). Για ένα πλαίσιο κειμένου κελιού πίνακα, η μέθοδος [ITextFrame.getParentCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#getParentCell--) επιστρέφει τον ιδιοκτήτη και η μέθοδος [ITextFrame.getParentShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#getParentShape--) επιστρέφει `null`, ακόμη και αν ο πίνακας είναι shape.

Οι συντεταγμένες του κελιού είναι διαθέσιμες μέσω των μόνο-ανάγνωσης μεθόδων [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/el/java/com.aspose.slides/icell/#getFirstColumnIndex--) και [ICell.getFirstRowIndex](https://reference.aspose.com/slides/el/java/com.aspose.slides/icell/#getFirstRowIndex--). Η μέθοδος [ITextFrame.getParentCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#getParentCell--) παρέχει επίσης μόνο-ανάγνωσης πλοήγηση: επιστρέφει τον ιδιοκτήτη αλλά δεν αλλάζει την ιδιοκτησία. Πάντα ελέγχετε το επιστρεφόμενο κελί για `null` πριν το χρησιμοποιήσετε.

Για ένα πλήρες παράδειγμα που εντοπίζει ιδιοκτήτες κελιού πίνακα και shape, συμπεριλαμβανομένων των shapes που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/java/search-and-replace-text/).

## **Στοίχιση Κειμένου σε Πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITable) στη διαφάνεια. 
4. Αποκτήστε ένα αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/) από τον πίνακα. 
5. Αποκτήστε το [IParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraph/) του [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/).
6. Στοίχξτε το κείμενο κατακόρυφα.
7. Αποθηκεύστε την τροποποιημένη παρουσία.

Αυτός ο κώδικας Java δείχνει πώς να ευθυγραμμίσετε το κείμενο σε έναν πίνακα:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργεί μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Λαμβάνει την πρώτη διαφάνεια
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Προσθέτει το σχήμα πίνακα στη διαφάνεια
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Πρόσβαση στο πλαίσιο κειμένου
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Δημιουργεί το αντικείμενο Paragraph για το πλαίσιο κειμένου
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Δημιουργεί το αντικείμενο Portion για την παράγραφο
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Στοίχζει το κείμενο καθέτως
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

1. Δημιουργήστε μια παρουσία της [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) κλάσης.
2. Λάβετε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Αποκτήστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITable) από τη Διαφάνεια.
4. Ορίστε το [setFontHeight(float value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) για το κείμενο. 
5. Ορίστε το [setAlignment(int value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) και το [setMarginRight(float value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Ορίστε το [setTextVerticalType(byte value)](https://reference.aspose.com/slides/el/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Αποθηκεύστε την τροποποιημένη παρουσία. 

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε τις προτιμώμενες επιλογές μορφοποίησης στο κείμενο ενός πίνακα:

```java
import com.aspose.slides.*;

// Δημιουργεί μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Ας υποθέσουμε ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι πίνακας
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Ορίζει το ύψος γραμματοσειράς των κελιών του πίνακα
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Ορίζει την στοίχιση κειμένου και το δεξί περιθώριο των κελιών του πίνακα με μία κλήση
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Ορίζει τον κάθετο τύπο κειμένου των κελιών του πίνακα
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Το Aspose.Slides σας επιτρέπει να ανακτήσετε τις ιδιότητες στυλ ενός πίνακα ώστε να μπορείτε να τις χρησιμοποιήσετε για άλλον πίνακα ή αλλού. Αυτός ο κώδικας Java δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προκαθορισμένο στυλ πίνακα:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // αλλάζει το προεπιλεγμένο στυλ προεπιλογής 

    // Λαμβάνει την προεπιλογή στυλ του πίνακα
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // Εφαρμόζει την ανακτημένη προεπιλογή στυλ σε άλλο πίνακα
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Κλείδωμα Αναλογίας Διαστάσεων Πίνακα**

Η αναλογία διαστάσεων ενός γεωμετρικού σχήματος είναι το πηλίκο των μεγεθών του σε διαφορετικές διαστάσεις. Το Aspose.Slides παρείχε την ιδιότητα **setAspectRatioLocked**(https://reference.aspose.com/slides/el/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) για να κλειδώνετε τη ρύθμιση αναλογίας διαστάσεων για πίνακες και άλλα σχήματα. 

Αυτός ο κώδικας Java δείχνει πώς να κλειδώσετε την αναλογία διαστάσεων για έναν πίνακα:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // αντιστροφή

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ΣΥΓΚΕΝΤΡΑΜΕΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας εκθέτει τη μέθοδο [setRightToLeft](https://reference.aspose.com/slides/el/java/com.aspose.slides/table/#setRightToLeft-boolean-), και οι παράγραφοι έχουν το [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/el/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Χρησιμοποιώντας και τα δύο διασφαλίζετε τη σωστή σειρά RTL και την απόδοση μέσα στα κελιά.

**Πώς μπορώ να αποτρέψω τους χρήστες από το να μετακινήσουν ή να αλλάξουν το μέγεθος ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε [shape locks](/slides/el/java/applying-protection-to-presentation/) για να απενεργοποιήσετε τη μετακίνηση, το αλλαγή μεγέθους, την επιλογή κ.λπ. Αυτά τα κλειδώματα εφαρμόζονται και στους πίνακες.

**Υποστηρίζεται η εισαγωγή εικόνας μέσα σε κελί ως φόντο;**

Ναι. Μπορείτε να ορίσετε μια [picture fill](https://reference.aspose.com/slides/el/java/com.aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύπτει την περιοχή του κελιού ανάλογα με την επιλεγμένη λειτουργία (stretch ή tile).