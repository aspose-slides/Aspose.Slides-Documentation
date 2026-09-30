---
title: Διαχείριση Γραμμών και Στηλών σε Πίνακες PowerPoint με Χρήση Java
linktitle: Γραμμές και Στήλες
type: docs
weight: 20
url: /el/java/manage-rows-and-columns/
keywords:
- γραμμή πίνακα
- στήλη πίνακα
- πρώτη γραμμή
- κεφαλίδα πίνακα
- κλωνοποίηση γραμμής
- κλωνοποίηση στήλης
- αντιγραφή γραμμής
- αντιγραφή στήλης
- αφαίρεση γραμμής
- αφαίρεση στήλης
- μορφοποίηση κειμένου γραμμής
- μορφοποίηση κειμένου στήλης
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις γραμμές και τις στήλες πίνακα σε PowerPoint με το Aspose.Slides for Java και επιταχύνετε την επεξεργασία παρουσιάσεων και τις ενημερώσεις δεδομένων."
---
## **Εισαγωγή**

Το Aspose.Slides for Java σάς επιτρέπει να διαχειρίζεστε τη δομή και τη μορφοποίηση πινάκων σε παρουσιάσεις PowerPoint μέσω της κλάσης [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) και της διεπαφής [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Μπορείτε να ορίσετε μια γραμμή κεφαλίδας, να κλωνοποιήσετε ή να αφαιρέσετε γραμμές και στήλες και να εφαρμόζετε μορφοποίηση κειμένου σε ολόκληρη τη γραμμή ή τη στήλη.

Αυτό το άρθρο εξηγεί αυτές τις λειτουργίες με παραδείγματα Java. Επίσης δείχνει πώς να ανακτήσετε το προεπιλεγμένο στυλ ενός πίνακα ώστε να το χρησιμοποιήσετε ξανά. Οι δείκτες γραμμών και στηλών του πίνακα είναι μηδενικής βάσης.

## **Έλεγχος ύψους γραμμής**

Χρησιμοποιήστε [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) για να ορίσετε το ελάχιστο ύψος μιας γραμμής σε σημεία. Είναι ένα κατώτερο όριο, όχι σταθερό ύψος. [IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) επιστρέφει το πραγματικό ύψος. Πρόσβαση στη γραμμή μέσω [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--).

Το παράδειγμα φορτώνει το [row-height-input.pptx](row-height-input.pptx), το οποίο έχει έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη του γραμμή ξεκινά στα 70 σημεία. Τα κελιά χρησιμοποιούν κείμενο Arial 18 σημείων, αναδίπλωση και περιθώρια 6 σημείων πάνω και κάτω· το πιο μακρύ κείμενο στη δεύτερη στήλη αναδιπλώνεται σε πολλές γραμμές. Το παράδειγμα αυξάνει το ελάχιστο σε 100 σημεία, στη συνέχεια το μειώνει σε 20 σημεία, εκτυπώνει το πραγματικό ύψος μετά από κάθε αλλαγή και αποθηκεύει και τα δύο αποτελέσματα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Με την παρεχόμενη παρουσίαση, η αύξηση του ελάχιστου προσθέτει χώρο στη γραμμή. Η μείωση του αφαιρεί αυτόν τον επιπλέον χώρο, αλλά το πραγματικό ύψος παραμένει μεγαλύτερο από 20 σημεία επειδή το κείμενο και τα περιθώρια των κελιών απαιτούν περισσότερο χώρο. Η μείωση του ελάχιστου από μόνη της δεν μπορεί να αναγκάσει τη γραμμή να πέσει κάτω από το χώρο που απαιτεί το περιεχόμενό της.

Διάφοροι παράγοντες επηρεάζουν το πραγματικό ύψος:

- **Κείμενο και μέγεθος γραμματοσειράς:** μεγαλύτερο κείμενο, ρητές αλλαγές γραμμής ή μεγαλύτερη γραμματοσειρά μπορεί να απαιτούν περισσότερο κατακόρυφο χώρο.
- **Αναδίπλωση και πλάτος στήλης:** με ενεργή την αναδίπλωση, η μείωση του πλάτους της στήλης με το [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) μπορεί να δημιουργήσει περισσότερες γραμμές. Μία ευρύτερη στήλη μπορεί να μειώσει τον απαιτούμενο κατακόρυφο χώρο.
- **Περιθώρια κελιών:** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) και [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) προσθέτουν κατακόρυφο χώρο. [ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) και [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) μειώνουν το διαθέσιμο πλάτος για το κείμενο και μπορούν να προκαλέσουν επιπλέον αναδίπλωση.

Για αυτόν τον πίνακα χωρίς συγχωνευμένα κελιά, το κελί που χρειάζεται τον περισσότερο κατακόρυφο χώρο καθορίζει το όριο που θέτει το περιεχόμενο για ολόκληρη τη γραμμή. Για να κάνετε τη γραμμή πιο σύντομη, ίσως χρειαστεί επίσης να συντομεύσετε το κείμενο, να μειώσετε το μέγεθος γραμματοσειράς ή τα περιθώρια, ή να διευρύνετε μια στήλη.

Οι εικόνες παρακάτω δείχνουν τον ίδιο πίνακα στην ίδια κλίμακα. Στα απεικονισμένα αποτελέσματα, τα πραγματικά ύψη ήταν 70, 100 και 55,2 σημεία: η τελευταία γραμμή παρέμεινε ψηλότερη από το ελάχιστο των 20 σημείων. Οι ακριβείς μετρήσεις κειμένου μπορούν να διαφέρουν ανάλογα με τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον σας. Κατεβάστε τα αποθηκευμένα αποτελέσματα: [increased minimum](row-height-increased.pptx) και [decreased minimum](row-height-decreased.pptx).

| Αρχικό: ελάχιστο 70 pt, πραγματικό 70 pt | Αυξημένο: ελάχιστο 100 pt, πραγματικό 100 pt | Μειωμένο: ελάχιστο 20 pt, πραγματικό 55.2 pt |
| --- | --- | --- |
| ![Αρχικός πίνακας με πρώτη γραμμή 70 σημείων.](row-height-before.png) | ![Πίνακας μετά την αύξηση του ελάχιστου πρώτης γραμμής σε 100 σημεία.](row-height-increased.png) | ![Πίνακας μετά τη μείωση του ελάχιστου πρώτης γραμμής σε 20 σημεία· το αναδιπλωμένο κείμενο διατηρεί τη γραμμή υψηλότερη από το ελάχιστο.](row-height-decreased.png) |

## **Ορισμός πρώτης γραμμής ως κεφαλίδας**

Χρησιμοποιήστε τη μέθοδο [setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-) για να σημαδέψετε την πρώτη γραμμή για μορφοποίηση κεφαλίδας. Η εμφάνισή της εξαρτάται από το στυλ πίνακα που έχει εφαρμοστεί στον πίνακα.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Πρόσβαση στον πίνακα αποθηκευμένο ως το πρώτο σχήμα στη διαφάνεια.
4. Ενεργοποιήστε τη μορφοποίηση κεφαλίδας για την πρώτη του γραμμή.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Ενεργοποιεί τη μορφοποίηση κεφαλίδας για την πρώτη γραμμή και αποθηκεύει το `First_row_header.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Κλωνοποίηση γραμμής ή στήλης πίνακα**

Κλωνοποιήστε γραμμές ή στήλες ώστε να επαναχρησιμοποιήσετε το περιεχόμενό τους και τη μορφοποίησή τους. Μπορείτε να προσθέσετε ένα αντίγραφο στο τέλος του πίνακα ή να το εισάγετε σε συγκεκριμένη θέση.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Ορίστε τα πλάτη των στηλών και τα ύψη των γραμμών.
4. Προσθέστε έναν πίνακα με τη μέθοδο [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Κλωνοποιήστε τις απαιτούμενες γραμμές.
6. Κλωνοποιήστε τις απαιτούμενες στήλες.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `Test.pptx` με τουλάχιστον μία διαφάνεια. Δημιουργεί έναν πίνακα με τρεις στήλες και πέντε γραμμές, με διαστάσεις καθορισμένες σε σημεία. Προσθέτει αντίγραφα της πρώτης γραμμής και στήλης, στη συνέχεια εισάγει αντίγραφα της δεύτερης γραμμής και στήλης στη θέση δείκτη 3 (την τέταρτη θέση). Ο τελικός πίνακας έχει επτά γραμμές και πέντε στήλες. Το όρισμα `false` απενεργοποιεί την κλωνοποίηση σε γειτονικά συγχωνευμένα κελιά· αυτός ο πίνακας δεν έχει συγχωνευμένα κελιά.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αφαίρεση γραμμής ή στήλης από πίνακα**

Αφαιρέστε γραμμές ή στήλες που δεν χρειάζεστε πλέον σε έναν πίνακα. Η αφαίρεση ενός στοιχείου μετατοπίζει τους δείκτες των γραμμών ή στηλών που το ακολουθούν.

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Ορίστε τα πλάτη των στηλών και τα ύψη των γραμμών.
4. Προσθέστε έναν πίνακα με τη μέθοδο [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Αφαιρέστε τη δεύτερη γραμμή και τη δεύτερη στήλη.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα 3x3 και αφαιρεί τη γραμμή και τη στήλη στο δείκτη 1, αφήνοντας έναν πίνακα 2x2 στο `TestTable_out.pptx`. Οι διαστάσεις είναι σε σημεία. Το όρισμα `false` απενεργοποιεί την αφαίρεση γειτονικών συγχωνευμένων γραμμών ή στηλών· αυτός ο πίνακας δεν έχει συγχωνευμένα κελιά.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Μορφοποίηση κειμένου στο επίπεδο γραμμής πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη τη γραμμή ώστε τα κελιά της να είναι συνεπή. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και κατεύθυνση κειμένου χωρίς να μορφοποιείτε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.
3. Χρησιμοποιήστε το [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) για την πρώτη γραμμή.
4. Χρησιμοποιήστε τα [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) και [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) για την πρώτη γραμμή.
5. Χρησιμοποιήστε το [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) για τη δεύτερη γραμμή.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο γραμμές. Εφαρμόζει κείμενο 25 σημείων, στοίχιση προς τα δεξιά και περιθώριο παραγράφου δεξιά 20 σημείων στην πρώτη γραμμή, έπειτα θέτει κάθετο κείμενο στη δεύτερη γραμμή.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Μορφοποίηση κειμένου στο επίπεδο στήλης πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη τη στήλη ώστε τα κελιά της να είναι συνεπή. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και κατεύθυνση κειμένου χωρίς να μορφοποιείτε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.
3. Χρησιμοποιήστε το [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) για την πρώτη στήλη.
4. Χρησιμοποιήστε τα [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) και [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) για την πρώτη στήλη.
5. Χρησιμοποιήστε το [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) για τη δεύτερη στήλη.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο στήλες. Εφαρμόζει κείμενο 25 σημείων, στοίχιση προς τα δεξιά και περιθώριο παραγράφου δεξιά 20 σημείων στην πρώτη στήλη, έπειτα θέτει κάθετο κείμενο στη δεύτερη στήλη.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Λήψη ιδιοτήτων στυλ πίνακα**

Χρησιμοποιήστε τη μέθοδο [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) για να ανακτήσετε το προεπιλεγμένο στυλ που έχει εφαρμοστεί σε έναν πίνακα και να το χρησιμοποιήσετε ξανά σε άλλο πίνακα. Αυτό προσδιορίζει το προεπιλεγμένο στυλ αντί για τις ατομικές παρακάμψεις μορφοποίησης κελιών.

Το παράδειγμα δημιουργεί έναν πίνακα, εφαρμόζει το [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1) και διαβάζει ξανά το προεπιλεγμένο στυλ. Εκτυπώνει την ακέραια τιμή που αντιστοιχεί στο `DarkStyle1` και αποθηκεύει τον πίνακα στο `table.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να εφαρμόσω θέματα/στυλ PowerPoint σε έναν πίνακα που έχει ήδη δημιουργηθεί;**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/μαστέρου, και μπορείτε ακόμη να παρακάμψετε τα γέμισματα, τα περιγράμματα και τα χρώματα κειμένου πάνω από αυτό το θέμα.

**Μπορώ να ταξινομήσω τις γραμμές του πίνακα όπως στο Excel;**

Όχι, οι πίνακες Aspose.Slides δεν διαθέτουν ενσωματωμένη ταξινόμηση ή φίλτρα. Ταξινομήστε τα δεδομένα στη μνήμη πρώτα, στη συνέχεια επανασυμπληρώστε τις γραμμές του πίνακα με τη νέα σειρά.

**Μπορώ να έχω λωμή (striped) στήλες ενώ διατηρώ προσαρμοσμένα χρώματα σε συγκεκριμένα κελιά;**

Ναι. Ενεργοποιήστε τις λωμή στήλες, στη συνέχεια παρακάμψτε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση σε επίπεδο κελιού έχει προτεραιότητα πάνω στο στυλ πίνακα.