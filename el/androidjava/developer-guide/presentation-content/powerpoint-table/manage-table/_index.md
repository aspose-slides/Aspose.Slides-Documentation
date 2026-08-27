---
title: Διαχείριση Πινάκων Παρουσίασης σε Android
linktitle: Διαχείριση Πίνακα
type: docs
weight: 10
url: /el/androidjava/manage-table/
keywords:
- προσθήκη πίνακα
- δημιουργία πίνακα
- πρόσβαση πίνακα
- αναλογία διαστάσεων
- στοίχιση κειμένου
- μορφοποίηση κειμένου
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε & επεξεργαστείτε πίνακες σε διαφάνειες PowerPoint με το Aspose.Slides για Android. Ανακαλύψτε απλά παραδείγματα κώδικα Java για να βελτιώσετε τη ροή εργασίας με τους πίνακες σας."
---
## **Εισαγωγή**

Ένας πίνακας στο PowerPoint είναι ένας αποδοτικός τρόπος παρουσίασης και απεικόνισης πληροφοριών. Οι πληροφορίες σε ένα πλέγμα κυψελών (διατεταγμένες σε σειρές και στήλες) είναι απλές και εύκολα κατανοητές.

Η Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Table), το interface [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITable), την κλάση [Cell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/cell/), το interface [ICell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icell/) και άλλους τύπους ώστε να μπορείτε να δημιουργείτε, ενημερώνετε και διαχειρίζεστε πίνακες σε κάθε είδους παρουσιάσεις.

## **Δημιουργία Πίνακα από την Αρχή**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Ορίστε έναν πίνακα του `columnWidth`.
4. Ορίστε έναν πίνακα του `rowHeight`.
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITable) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Επαναλάβετε για κάθε [ICell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icell/) ώστε να εφαρμόσετε μορφοποίηση στα άνω, κάτω, δεξιά και αριστερά όρια.
7. Συγχωνεύστε τις δύο πρώτες κυψέλες της πρώτης σειράς του πίνακα. 
8. Αποκτήστε το [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframe/) ενός [ICell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icell/).
9. Προσθέστε κείμενο στο [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframe/).
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε έναν πίνακα σε μια παρουσίαση:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Προσπελαύνει την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ορίζει τη μορφή περιθωρίου για κάθε κελί
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

    // Αποθηκεύει την παρουσίαση στον δίσκο
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αρίθμηση σε Κανονικό Πίνακα**

Σε έναν κανονικό πίνακα, η αρίθμηση των κυψελών είναι απλή και μηδενικής βάσης. Η πρώτη κυψέλη σε έναν πίνακα έχει δείκτη 0,0 (στήλη 0, σειρά 0). 

Για παράδειγμα, οι κυψέλες σε έναν πίνακα με 4 στήλες και 4 σειρές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτός ο κώδικας Java δείχνει πώς να καθορίσετε την αρίθμηση των κυψελών σε έναν πίνακα:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation();
try {
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Προσθέτει ένα σχήμα πίνακα στη διαφάνεια
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ορίζει τη μορφή περιθωρίου για κάθε κελί
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

    // Αποθηκεύει την παρουσίαση στον δίσκο
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Πρόσβαση σε Υπάρχον Πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).

2. Αποκτήστε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα μέσω του δείκτη της. 

3. Δημιουργήστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITable) και ορίστε το σε null.

4. Περιηγηθείτε σε όλα τα αντικείμενα [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) μέχρι να βρεθεί ο πίνακας.  
   Εάν υποψιάζεστε ότι η διαφάνεια που επεξεργάζεστε περιέχει έναν μόνο πίνακα, μπορείτε απλώς να ελέγξετε όλα τα σχήματα που περιέχει. Όταν ένα σχήμα ταυτοποιηθεί ως πίνακας, μπορείτε να το μετατρέψετε σε αντικείμενο [Table](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Table). Ωστόσο, εάν η διαφάνεια περιέχει πολλούς πίνακες, είναι καλύτερο να αναζητήσετε τον απαιτούμενο πίνακα μέσω του [setAlternativeText(String value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Χρησιμοποιήστε το αντικείμενο [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITable) για να εργαστείτε με τον πίνακα. Στο παρακάτω παράδειγμα, ορίζουμε το κείμενο μιας κυψέλης στον πίνακα.

6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να αποκτήσετε πρόσβαση και να εργαστείτε με έναν υπάρχοντα πίνακα:

```java
import com.aspose.slides.*;

// Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Αρχικοποιεί το TableEx ως null
    ITable tbl = null;

    // Διατρέχει τα σχήματα και θέτει αναφορά στον εντοπισθέντα πίνακα
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Ορίζει το κείμενο για την πρώτη στήλη της δεύτερης σειράς
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Αποθηκεύει την τροποποιημένη παρουσίαση στον δίσκο
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εύρεση της Κυψέλης που Κατέχει ένα Πλαίσιο Κειμένου**

Όταν ο γενικός κώδικας επεξεργασίας κειμένου λαμβάνει ένα [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) από έναν πίνακα, χρησιμοποιήστε τη μέθοδο [ITextFrame.getParentCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#getParentCell--) για να ανακτήσετε την κυψέλη‑ιδιοκτήτη [ICell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icell/). Για ένα πλαίσιο κειμένου κελιού πίνακα, η [ITextFrame.getParentCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#getParentCell--) επιστρέφει τον ιδιοκτήτη και η [ITextFrame.getParentShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#getParentShape--) επιστρέφει `null`, παρόλο που ο ίδιος ο πίνακας είναι σχήμα.

Οι συντεταγμένες της κυψέλης είναι διαθέσιμες μέσω των μόνο‑ανάγνωσης μεθόδων [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) και [ICell.getFirstRowIndex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icell/#getFirstRowIndex--). Η [ITextFrame.getParentCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#getParentCell--) παρέχει επίσης μόνο‑ανάγνωσης πλοήγηση: επιστρέφει τον ιδιοκτήτη αλλά δεν αλλάζει την ιδιοκτησία. Πάντα ελέγχετε την επιστρεφόμενη κυψέλη για `null` πριν τη χρησιμοποιήσετε.

Για ένα πλήρες παράδειγμα που εντοπίζει ιδιοκτήτες κυψελών‑πίνακα και σχήματα, συμπεριλαμβανομένων σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε [Search and Replace Text](/slides/el/androidjava/search-and-replace-text/).

## **Στοίχιση Κειμένου σε Πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITable) στη διαφάνεια.
4. Αποκτήστε ένα αντικείμενο [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) από τον πίνακα.
5. Αποκτήστε το [IParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/) του [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/).
6. Στοίχισε το κείμενο κάθετα.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να στοίχετε το κείμενο σε έναν πίνακα:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Δημιουργεί μια παρουσία της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Παίρνει την πρώτη διαφάνεια
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
    
    // Στοιχίζει το κείμενο κάθετα
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Αποθηκεύει την παρουσίαση στον δίσκο
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Αποκτήστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ITable) από τη διαφάνεια.
4. Ορίστε το [setFontHeight(float value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) για το κείμενο.
5. Ορίστε το [setAlignment(int value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) και το [setMarginRight(float value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Ορίστε το [setTextVerticalType(byte value)](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση. 

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε τις προτιμητέες επιλογές μορφοποίησης στο κείμενο ενός πίνακα:

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
    
    // Ορίζει τη στοίχιση κειμένου και το δεξιό περιθώριο των κελιών του πίνακα σε μια κλήση
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

## **Ανάκτηση Ιδιοτήτων Στυλ Πίνακα**

Η Aspose.Slides σας επιτρέπει να ανακτήσετε τις ιδιότητες στυλ ενός πίνακα ώστε να μπορείτε να χρησιμοποιήσετε αυτές τις λεπτομέρειες για άλλο πίνακα ή σε άλλο μέρος. Αυτός ο κώδικας Java δείχνει πώς να λάβετε τις ιδιότητες στυλ από ένα προκαθορισμένο στυλ πίνακα:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // αλλάζει το προεπιλεγμένο στυλ preset

    // Λαμβάνει το στυλ preset του πίνακα
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // Εφαρμόζει το ανακτημένο στυλ preset σε έναν άλλο πίνακα
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Κλείδωμα Αναλογίας Διαστάσεων Πίνακα**

Η αναλογία διαστάσεων ενός γεωμετρικού σχήματος είναι ο λόγος των μεγεθών του σε διαφορετικές διαστάσεις. Η Aspose.Slides παρείχε την ιδιότητα [**setAspectRatioLocked**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) ώστε να μπορείτε να κλειδώσετε τη ρύθμιση αναλογίας διαστάσεων για πίνακες και άλλα σχήματα.

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

## **Συχνές Ερωτήσεις**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς τα αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας διαθέτει τη μέθοδο [setRightToLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-), και οι παράγραφοι έχουν το [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Η χρήση και των δύο εξασφαλίζει τη σωστή σειρά RTL και την απόδοση μέσα στα κελιά.

**Πώς μπορώ να αποτρέψω τους χρήστες από το να μετακινούν ή να αλλάζουν το μέγεθος ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε κλειδώσεις σχήματος για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κ.λπ. Αυτές οι κλειδώσεις ισχύουν και για πίνακες.

**Υποστηρίζεται η εισαγωγή μιας εικόνας μέσα σε μια κυψέλη ως φόντο;**

Ναι. Μπορείτε να ορίσετε ένα [picture fill](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/picturefillformat/) για μια κυψέλη· η εικόνα θα καλύπτει την περιοχή της κυψέλης σύμφωνα με την επιλεγμένη λειτουργία (stretch ή tile).