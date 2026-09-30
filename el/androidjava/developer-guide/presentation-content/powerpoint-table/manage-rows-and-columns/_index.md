---
title: Διαχείριση Σειρών και Στηλών σε Πίνακες PowerPoint στο Android
linktitle: Σειρές και Στήλες
type: docs
weight: 20
url: /el/androidjava/manage-rows-and-columns/
keywords:
- σειρά πίνακα
- στήλη πίνακα
- πρώτη σειρά
- κεφαλίδα πίνακα
- κλωνοποίηση σειράς
- κλωνοποίηση στήλης
- αντιγραφή σειράς
- αντιγραφή στήλης
- αφαίρεση σειράς
- αφαίρεση στήλης
- μορφοποίηση κειμένου σειράς
- μορφοποίηση κειμένου στήλης
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις σειρές και τις στήλες πίνακα στο PowerPoint με το Aspose.Slides για Android μέσω Java και επιταχύνετε την επεξεργασία παρουσιάσεων και τις ενημερώσεις δεδομένων."
---
## **Εισαγωγή**

Aspose.Slides for Android μέσω Java σας επιτρέπει να διαχειρίζεστε τη δομή και τη μορφοποίηση των πινάκων σε παρουσιάσεις PowerPoint μέσω της κλάσης [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) και της διεπαφής [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Μπορείτε να ορίσετε μια σειρά κεφαλίδας, να αντιγράψετε ή να αφαιρέσετε σειρές και στήλες και να εφαρμόσετε μορφοποίηση κειμένου σε ολόκληρη τη σειρά ή στήλη.

Αυτό το άρθρο εξηγεί αυτές τις λειτουργίες με παραδείγματα Java. Επίσης δείχνει πώς να ανακτήσετε το προεπιλεγμένο στυλ πίνακα ώστε να το επαναχρησιμοποιήσετε. Οι δείκτες σειρών και στηλών του πίνακα ξεκινούν από το μηδέν.

## **Έλεγχος Υψους Σειράς**

Χρησιμοποιήστε [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) για να ορίσετε το ελάχιστο ύψος μιας σειράς σε σημεία. Είναι ένα κατώτερο όριο, όχι ένα σταθερό ύψος. [IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--) επιστρέφει το πραγματικό ύψος. Πρόσβαση στη σειρά γίνεται μέσω του [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--).

Το παράδειγμα φορτώνει το [row-height-input.pptx](row-height-input.pptx), το οποίο έχει έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη σειρά του ξεκινά στα 70 σημεία. Τα κελιά χρησιμοποιούν κείμενο Arial 18 σημείων, με αναδίπλωση και περιθώρια 6 σημείων από πάνω και από κάτω· το πιο μακρύ κείμενο στη δεύτερη στήλη αναδιπλώνεται σε πολλές γραμμές. Το παράδειγμα αυξάνει το ελάχιστο σε 100 σημεία, στη συνέχεια το μειώνει σε 20 σημεία, εκτυπώνει το πραγματικό ύψος μετά από κάθε αλλαγή και αποθηκεύει και τα δύο αποτελέσματα.

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

Με την παρεχόμενη παρουσίαση, η αύξηση του ελάχιστου προσθέτει χώρο στη σειρά. Η μείωσή του αφαιρεί αυτόν τον επιπλέον χώρο, αλλά το πραγματικό ύψος παραμένει μεγαλύτερο από 20 σημεία επειδή το κείμενο και τα περιθώρια των κελιών χρειάζονται περισσότερο χώρο. Η μείωση του ελάχιστου μόνιμα δεν μπορεί να εξαναγκάσει τη σειρά κάτω από το χώρο που απαιτεί το περιεχόμενό της.

Αρκετοί παράγοντες επηρεάζουν το πραγματικό ύψος:

- **Κείμενο και μέγεθος γραμματοσειράς:** πιο μακρύ κείμενο, ρητές αλλαγές γραμμής ή μεγαλύτερη γραμματοσειρά μπορεί να απαιτούν περισσότερο κάθετο χώρο.
- **Αναδίπλωση και πλάτος στήλης:** με ενεργή την αναδίπλωση, η μείωση του πλάτους της στήλης με το [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) μπορεί να δημιουργήσει περισσότερες γραμμές. Μία ευρύτερη στήλη μπορεί να μειώσει τον απαιτούμενο κάθετο χώρο.
- **Περιθώρια κελιού:** τα [ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-) και [ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-) προσθέτουν κάθετο χώρο. Τα [ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-) και [ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-) μειώνουν το πλάτος που διατίθεται για κείμενο και μπορούν να προκαλέσουν επιπλέον αναδίπλωση.

Για αυτόν τον πίνακα χωρίς συγχωνευμένα κελιά, το κελί που χρειάζεται περισσότερο κάθετο χώρο καθορίζει το περιοριστικό όριο του περιεχομένου για ολόκληρη τη σειρά. Για να κάνετε τη σειρά πιο σύντομη, ίσως χρειαστεί να μειώσετε το κείμενο, το μέγεθος γραμματοσειράς ή τα περιθώρια, ή να ευρύνει μια στήλη.

Οι εικόνες παρακάτω δείχνουν τον ίδιο πίνακα στην ίδια κλίμακα. Στα παρασταθέντα αποτελέσματα, τα πραγματικά ύψη ήταν 70, 100 και 55.2 σημεία: η τελική σειρά παρέμεινε ψηλότερη από το ελάχιστο των 20 σημείων. Οι ακριβείς μετρήσεις κειμένου μπορεί να διαφέρουν με τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον σας. Κατεβάστε τα αποθηκευμένα αποτελέσματα: [increased minimum](row-height-increased.pptx) και [decreased minimum](row-height-decreased.pptx).

| Αρχικό: ελάχιστο 70 pt, πραγματικό 70 pt | Αυξημένο: ελάχιστο 100 pt, πραγματικό 100 pt | Μειωμένο: ελάχιστο 20 pt, πραγματικό 55.2 pt |
| --- | --- | --- |
| ![Αρχικός πίνακας με πρώτη σειρά 70 σημείων.](row-height-before.png) | ![Πίνακας μετά την αύξηση του ελάχιστου της πρώτης σειράς σε 100 σημεία.](row-height-increased.png) | ![Πίνακας μετά τη μείωση του ελάχιστου της πρώτης σειράς σε 20 σημεία· το αναδιπλωμένο κείμενο διατηρεί τη σειρά ψηλότερη από το ελάχιστο.](row-height-decreased.png) |

## **Ορισμός Πρώτης Σειράς ως Κεφαλίδας**

Χρησιμοποιήστε τη μέθοδο [setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-) για να σηματοδοτήσετε την πρώτη σειρά για μορφοποίηση κεφαλίδας. Η εμφάνισή της εξαρτάται από το στυλ πίνακα που έχει εφαρμοστεί στον πίνακα.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Πρόσβαση στον πίνακα που είναι αποθηκευμένος ως το πρώτο σχήμα στη διαφάνεια.
4. Ενεργοποιήστε τη μορφοποίηση κεφαλίδας για την πρώτη σειρά.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Ενεργοποιεί τη μορφοποίηση κεφαλίδας για την πρώτη σειρά και αποθηκεύει το `First_row_header.pptx`.

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

## **Αντιγραφή Σειράς ή Στήλης Πίνακα**

Αντιγράψτε σειρές ή στήλες για να επαναχρησιμοποιήσετε το περιεχόμενό τους και τη μορφοποίησή τους. Μπορείτε να προσθέσετε ένα αντίγραφο στο τέλος του πίνακα ή να το τοποθετήσετε σε συγκεκριμένη θέση.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Ορίστε τα πλάτη των στηλών και τα ύψη των σειρών.
4. Προσθέστε έναν πίνακα με τη μέθοδο [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Αντιγράψτε τις απαιτούμενες σειρές.
6. Αντιγράψτε τις απαιτούμενες στήλες.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `Test.pptx` με τουλάχιστον μία διαφάνεια. Δημιουργεί έναν πίνακα με τρεις στήλες και πέντε σειρές, με διαστάσεις καθορισμένες σε σημεία. Προσθέτει αντίγραφα της πρώτης σειράς και στήλης, έπειτα εισάγει αντίγραφα της δεύτερης σειράς και στήλης στη θέση 3 (την τέταρτη θέση). Ο τελικός πίνακας έχει επτά σειρές και πέντε στήλες. Το όρισμα `false` απενεργοποιεί την αντιγραφή σε παρακείμενες συγχωνευμένες σειρές ή στήλες· αυτός ο πίνακας δεν έχει συγχωνευμένα κελιά.

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

## **Αφαίρεση Σειράς ή Στήλης από Πίνακα**

Αφαιρέστε σειρές ή στήλες που δεν χρειάζονται πια σε έναν πίνακα. Η αφαίρεση ενός στοιχείου μετατοπίζει τους δείκτες των σειρών ή στηλών που ακολουθούν.

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Ορίστε τα πλάτη των στηλών και τα ύψη των σειρών.
4. Προσθέστε έναν πίνακα με τη μέθοδο [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Αφαιρέστε τη δεύτερη σειρά και τη δεύτερη στήλη.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα τριών επί τριών και αφαιρεί τη σειρά και τη στήλη στη θέση 1, αφήνοντας έναν πίνακα δύο επί δύο στο `TestTable_out.pptx`. Οι διαστάσεις είναι σε σημεία. Το όρισμα `false` απενεργοποιεί την αφαίρεση παρακείμενων συγχωνευμένων σειρών ή στηλών· αυτός ο πίνακας δεν έχει συγχωνευμένα κελιά.

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

## **Μορφοποίηση Κειμένου σε Επίπεδο Σειράς Πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη τη σειρά ώστε τα κελιά της να είναι συνεπή. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και κατεύθυνση κειμένου χωρίς να μορφοποιήσετε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.
3. Χρησιμοποιήστε το [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) για την πρώτη σειρά.
4. Χρησιμοποιήστε το [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) και το [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) για την πρώτη σειρά.
5. Χρησιμοποιήστε το [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) για τη δεύτερη σειρά.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο σειρές. Εφαρμόζει κείμενο 25 σημείων, ευθυγράμμιση δεξιά και περιθώριο παραγράφου δεξιά 20 σημείων στην πρώτη σειρά, έπειτα ορίζει κάθετο κείμενο στη δεύτερη σειρά.

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

## **Μορφοποίηση Κειμένου σε Επίπεδο Στήλης Πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη τη στήλη ώστε τα κελιά της να είναι συνεπή. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και κατεύθυνση κειμένου χωρίς να μορφοποιήσετε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.
3. Χρησιμοποιήστε το [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) για την πρώτη στήλη.
4. Χρησιμοποιήστε το [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) και το [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) για την πρώτη στήλη.
5. Χρησιμοποιήστε το [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) για τη δεύτερη στήλη.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο στήλες. Εφαρμόζει κείμενο 25 σημείων, ευθυγράμμιση δεξιά και περιθώριο παραγράφου δεξιά 20 σημείων στην πρώτη στήλη, έπειτα ορίζει κάθετο κείμενο στη δεύτερη στήλη.

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

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Χρησιμοποιήστε τη μέθοδο [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) για να ανακτήσετε το προεπιλεγμένο στυλ που έχει εφαρμοστεί σε έναν πίνακα και να το επαναχρησιμοποιήσετε σε άλλο πίνακα. Αυτό αναγνωρίζει το προεπιλεγμένο στυλ αντί για ξεχωριστές παρακάμψεις μορφοποίησης κελιών.

Το παράδειγμα δημιουργεί έναν πίνακα, εφαρμόζει το [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1) και διαβάζει το προεπιλεγμένο στυλ. Εκτυπώνει την ακέραιη τιμή που αντιστοιχεί στο `DarkStyle1` και αποθηκεύει τον πίνακα στο `table.pptx`.

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

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω θέματα/στυλ PowerPoint σε έναν πίνακα που έχει ήδη δημιουργηθεί;**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/κύριου αρχείου και μπορείτε ακόμη να αντικαταστήσετε γεμίσματα, περιθώρια και χρώματα κειμένου πάνω από αυτό το θέμα.

**Μπορώ να ταξινομήσω τις σειρές του πίνακα όπως στο Excel;**

Όχι, οι πίνακες του Aspose.Slides δεν διαθέτουν ενσωματωμένη λειτουργία ταξινόμησης ή φιλτραρίσματος. Ταξινομήστε τα δεδομένα στη μνήμη πρώτα, έπειτα γεμίστε ξανά τις σειρές του πίνακα με τη σωστή σειρά.

**Μπορώ να έχω διαβαθμισμένες (striped) στήλες ενώ διατηρώ προσαρμοσμένα χρώματα σε συγκεκριμένα κελιά;**

Ναι. Ενεργοποιήστε τις διαβαθμισμένες στήλες, έπειτα αντικαταστήστε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση σε επίπεδο κελιού έχει προτεραιότητα πάνω από το στυλ πίνακα.