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
- αναλογία πτυχίου
- στοίχιση κειμένου
- μορφοποίηση κειμένου
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργία και επεξεργασία πινάκων σε διαφάνειες PowerPoint με το Aspose.Slides για Java. Ανακαλύψτε απλά παραδείγματα κώδικα για να βελτιώσετε τη ροή εργασίας των πινάκων σας."
---
## **Εισαγωγή**

Οι πίνακες στο PowerPoint οργανώνουν τις πληροφορίες σε σειρές και στήλες, κάνοντας πιο εύκολη την ανάγνωση και τη σύγκριση τιμών.

Aspose.Slides παρέχει τις κλάσεις [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/), [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/), [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/), [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) και άλλους τύπους ώστε να μπορείτε να δημιουργείτε, να ενημερώνετε και να διαχειρίζεστε πίνακες σε παρουσιάσεις.

## **Δημιουργία Πίνακα από την Αρχή**

Δημιουργήστε έναν πίνακα καθορίζοντας τη θέση, το πλάτος των στηλών και το ύψος των σειρών. Αφού τον προσθέσετε σε μια διαφάνεια, μπορείτε να μορφοποιήσετε τα σύνορα των κελιών, να συγχωνεύσετε κελιά και να εισάγετε κείμενο.

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Λάβετε μια αναφορά στη διαφάνεια με το δείκτη της.
3. Ορίστε έναν πίνακα με τα πλάτη των στηλών σε μονάδες σημείου.
4. Ορίστε έναν πίνακα με τα ύψη των σειρών σε μονάδες σημείου.
5. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Διατρέξτε κάθε [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) για να εφαρμόσετε μορφοποίηση στα άνω, κάτω, δεξιά και αριστερά σύνορα.
7. Συγχωνεύστε τα δύο πρώτα κελιά της πρώτης σειράς του πίνακα.
8. Αποκτήστε πρόσβαση στο συγχωνευμένο κελί μέσω της μεθόδου [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--).
9. Ορίστε το κείμενο στο συγχωνευμένο κελί.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα με τρεις στήλες και πέντε σειρές στο (100, 50) σημεία. Εφαρμόζει κόκκινα σύνορα με πάχος 5 σημείων, συγχωνεύει τα δύο πρώτα κελιά στην πρώτη σειρά και αποθηκεύει το αποτέλεσμα ως `table.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
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

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αρίθμηση σε Τυπικό Πίνακα**

Σε έναν τυπικό πίνακα, οι δείκτες των κελιών είναι μηδενικής βάσης και χρησιμοποιούν τη σειρά (στήλη, σειρά). Το πρώτο κελί έχει δείκτη (0, 0).

Για παράδειγμα, τα κελιά σε έναν πίνακα με 4 στήλες και 4 σειρές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτό το παράδειγμα δημιουργεί τον 4 × 4 πίνακα που απεικονίζεται παραπάνω, με πλάτη στηλών και ύψη σειρών 70 σημείων και κόκκινα σύνορα κελιών 5 σημείων. Οι συντεταγμένες απεικονίζουν τους δείκτες των κελιών· το παράδειγμα αφήνει τα κελιά κενά και αποθηκεύει τον πίνακα ως `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
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

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Πρόσβαση σε Υπάρχον Πίνακα**

Οι πίνακες αποθηκεύονται στη συλλογή σχημάτων μιας διαφάνειας. Διατρέξτε τα σχήματα για να εντοπίσετε έναν πίνακα, στη συνέχεια χρησιμοποιήστε τη διεπαφή [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) για να διαβάσετε ή να ενημερώσετε τα κελιά του.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Λάβετε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα με το δείκτη της.
3. Διατρέξτε τα αντικείμενα [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) και σταματήστε όταν βρεθεί ένας πίνακας. Εάν η διαφάνεια περιέχει πολλούς πίνακες, χρησιμοποιήστε το [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--) για να εντοπίσετε αυτόν που χρειάζεστε.
4. Ενημερώστε το κείμενο στο στοχευμένο κελί.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα ανοίγει το `UpdateExistingTable.pptx` και βρίσκει τον πρώτο πίνακα στην πρώτη διαφάνεια. Ορίζει το κελί στη στήλη 0, σειρά 1 σε `New` και αποθηκεύει το αποτέλεσμα ως `table1_out.pptx`. Η είσοδος πρέπει να περιέχει τουλάχιστον μία διαφάνεια και ο πρώτος πίνακας σε αυτήν πρέπει να έχει τουλάχιστον μία στήλη και δύο σειρές.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Για να αλλάξετε το μέγεθος μιας σειράς σε έναν υπάρχοντα πίνακα και να κατανοήσετε γιατί το πραγματικό του ύψος μπορεί να υπερβαίνει το ζητούμενο ελάχιστο, δείτε [Control Row Height](/slides/el/java/manage-rows-and-columns/#control-row-height).

## **Βρείτε το Κελί που Κατέχει Πλαίσιο Κειμένου**

Όταν ο γενικός κώδικας επεξεργασίας κειμένου λαμβάνει ένα [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) από έναν πίνακα, χρησιμοποιήστε τη μέθοδο [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) για να ανακτήσετε το ιδιοκτησιακό [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/). Για ένα πλαίσιο κειμένου κελιού πίνακα, το [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) επιστρέφει τον κάτοχο και το [ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--) επιστρέφει `null`, ακόμη και αν ο ίδιος ο πίνακας είναι σχήμα.

Οι συντεταγμένες του κελιού είναι διαθέσιμες μέσω των αναγνώσιμων μόνο μεθόδων [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) και [ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--). Το [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) παρέχει επίσης πλοήγηση μόνο για ανάγνωση: επιστρέφει τον κάτοχο αλλά δεν αλλάζει την ιδιοκτησία. Πάντα ελέγχετε το επιστρεφόμενο κελί για `null` πριν το χρησιμοποιήσετε.

Για ένα πλήρες παράδειγμα που εντοπίζει ιδιοκτήτες κελιών πίνακα και σχημάτων, συμπεριλαμβανομένων των σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε [Search and Replace Text](/slides/el/java/search-and-replace-text/).

## **Στοίχιση Κειμένου σε Πίνακα**

Μπορείτε να ελέγξετε την κάθετη αγκύρωση και την κατεύθυνση κειμένου των μεμονωμένων κελιών πίνακα. Το παράδειγμα σε αυτήν την ενότητα κεντράρει το κείμενο στο πρώτο κελί και το περιστρέφει κατά 270 μοίρες.

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Λάβετε μια αναφορά στη διαφάνεια με το δείκτη της.
3. Προσθέστε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) στη διαφάνεια.
4. Αποκτήστε πρόσβαση σε ένα αντικείμενο [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) από τον πίνακα.
5. Αποκτήστε πρόσβαση στο πρώτο [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) και ορίστε το κείμενο και το χρώμα του.
6. Ορίστε την κάθετη αγκύρωση του κελιού και την κατεύθυνση κειμένου χρησιμοποιώντας τις μεθόδους [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) και [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα αυτό δημιουργεί έναν 4 × 4 πίνακα με πλάτη στηλών 120 σημείων και ύψη σειρών 100 σημείων. Μορφοποιεί το κείμενο στο κελί (0, 0), προσθέτει τιμές στα υπόλοιπα κελιά της πρώτης σειράς και αποθηκεύει το αποτέλεσμα ως `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Πίνακα**

Χρησιμοποιήστε τη μέθοδο [setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) για να εφαρμόσετε μορφοποίηση κειμένου σε όλα τα κελιά ενός πίνακα. Οι υπερφορτώσεις της δέχονται μορφοποίηση τμήματος, παραγράφου και πλαισίου κειμένου, ώστε να μπορείτε να ορίσετε αυτές τις ιδιότητες χωρίς να διατρέχετε τα μεμονωμένα κελιά.

1. Φορτώστε την παρουσίαση χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Λάβετε μια αναφορά στη διαφάνεια με το δείκτη της.
3. Αποκτήστε πρόσβαση σε ένα αντικείμενο [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) από τη διαφάνεια.
4. Ορίστε το μέγεθος γραμματοσειράς χρησιμοποιώντας τη μέθοδο [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) για το κείμενο.
5. Ορίστε την στοίχιση παραγράφου και το δεξιό περιθώριο χρησιμοποιώντας τις μεθόδους [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) και [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Ορίστε την κατεύθυνση κειμένου χρησιμοποιώντας τη μέθοδο [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα παρακάτω ανοίγει το `table.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια με πίνακα ως πρώτο του σχήμα. Ορίζει το μέγεθος γραμματοσειράς στα 25 σημεία, ευθυγραμμίζει δεξιά τις παραγράφους με δεξιό περιθώριο 20 σημεία και καθιστά το κείμενο κάθετο. Η μορφοποιημένη παρουσίαση αποθηκεύεται ως `result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Χρησιμοποιήστε τη μέθοδο [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) για να διαβάσετε το προεπιλεγμένο στυλ ενός πίνακα και τη μέθοδο [setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-) για να το ορίσετε. Αυτό το παράδειγμα εφαρμόζει το [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/) σε έναν πίνακα, εκτυπώνει την τιμή του προεπιλεγμένου στυλ και την αναθέτει σε δεύτερο πίνακα. Και οι δύο πίνακες αποθηκεύονται στο `table-style.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Κλείδωμα Λόγου Πτυχίου Πίνακα**

Ο λόγος πτυχίου ενός πίνακα είναι η αναλογία του πλάτους προς το ύψος του. Χρησιμοποιήστε τη μέθοδο [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) για να κλειδώσετε αυτήν την αναλογία για έναν πίνακα.

Το παράδειγμα παρακάτω ανοίγει το `pres.pptx`, το οποίο πρέπει να περιέχει τουλάχιστον μία διαφάνεια με πίνακα ως πρώτο σχήμα. Εκτυπώνει την τρέχουσα κατάσταση κλειδώματος, ενεργοποιεί το κλείδωμα λόγου πτυχίου, εκτυπώνει την ενημερωμένη κατάσταση (`true`) και αποθηκεύει το αποτέλεσμα ως `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ΣΥΝΗΘΕΣΜΕΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ενεργοποιήσω την ανάγνωση από δεξιά προς αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας προσφέρει τη μέθοδο [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-), και οι παράγραφοι έχουν τη μέθοδο [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Η χρήση και των δύο εξασφαλίζει τη σωστή σειρά RTL και την απόδοση μέσα στα κελιά.

**Πώς μπορώ να αποτρέψω τους χρήστες από το να μετακινούν ή να αλλάζουν το μέγεθος ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε τις [shape locks](/slides/el/java/applying-protection-to-presentation/) για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κ.λπ. Αυτοί οι περιορισμοί εφαρμόζονται και στους πίνακες.

**Υποστηρίζεται η εισαγωγή μιας εικόνας μέσα σε ένα κελί ως φόντο;**

Ναι. Μπορείτε να ορίσετε μια [picture fill](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύψει την περιοχή του κελιού σύμφωνα με την επιλεγμένη λειτουργία (τεντωμένη ή πλακίδια).