---
title: Διαχείριση Γραμμών και Στηλών σε Πίνακες PowerPoint χρησιμοποιώντας JavaScript
linktitle: Γραμμές και Στήλες
type: docs
weight: 20
url: /el/nodejs-java/manage-rows-and-columns/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε τις γραμμές και τις στήλες των πινάκων σε PowerPoint με JavaScript και Aspose.Slides για Node.js μέσω Java και επιταχύνετε την επεξεργασία παρουσιάσεων και τις ενημερώσεις δεδομένων."
---
## **Εισαγωγή**

Το Aspose.Slides for Node.js μέσω Java σάς επιτρέπει να διαχειρίζεστε τη δομή και τη μορφοποίηση των πινάκων σε παρουσιάσεις PowerPoint μέσω της κλάσης [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Μπορείτε να ορίσετε μια γραμμή κεφαλίδας, να κλωνοποιήσετε ή να αφαιρέσετε γραμμές και στήλες και να εφαρμόσετε μορφοποίηση κειμένου σε ολόκληρη μια γραμμή ή στήλη.

Αυτό το άρθρο εξηγεί αυτές τις λειτουργίες με παραδείγματα JavaScript. Επίσης δείχνει πώς να ανακτήσετε την προεπιλεγμένη μορφή ενός πίνακα ώστε να την επαναχρησιμοποιήσετε. Οι δείκτες γραμμών και στηλών του πίνακα είναι μηδενικής βάσης.

## **Έλεγχος Ύψους Γραμμής**

Χρησιμοποιήστε [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) για να ορίσετε το ελάχιστο ύψος μιας γραμμής σε σημεία. Είναι ένα κατώτερο όριο, όχι σταθερό ύψος. [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) επιστρέφει το πραγματικό ύψος. Πρόσβαση στη γραμμή γίνεται μέσω [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--).

Το παράδειγμα φορτώνει το αρχείο [row-height-input.pptx](row-height-input.pptx), το οποίο έχει έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Η πρώτη του γραμμή αρχίζει στα 70 σημεία. Τα κελιά χρησιμοποιούν κείμενο Arial 18 σημείων, με αναδίπλωση και περιθώρια 6 σημείων επάνω και κάτω· το μεγαλύτερο κείμενο στη δεύτερη στήλη αναδιπλώνεται σε πολλές γραμμές. Το παράδειγμα αυξάνει το ελάχιστο σε 100 σημεία, στη συνέχεια το μειώνει σε 20 σημεία, εκτυπώνει το πραγματικό ύψος μετά από κάθε αλλαγή και αποθηκεύει και τα δύο αποτελέσματα.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Με την παρεχόμενη παρουσίαση, η αύξηση του ελάχιστου προσθέτει χώρο στη γραμμή. Η μείωση του αφαιρεί αυτόν τον επιπλέον χώρο, αλλά το πραγματικό ύψος παραμένει μεγαλύτερο από 20 σημεία επειδή το κείμενο και τα περιθώρια των κελιών χρειάζονται περισσότερο χώρο. Η μείωση του ελάχιστου από μόνη της δεν μπορεί να εξαναγκάσει τη γραμμή να είναι μικρότερη από το χώρο που απαιτεί το περιεχόμενό της.

Πολλοί παράγοντες επηρεάζουν το πραγματικό ύψος:

- **Κείμενο και μέγεθος γραμματοσειράς:** το μεγαλύτερο κείμενο, σαφείς αλλαγές γραμμής ή μια μεγαλύτερη γραμματοσειρά μπορούν να απαιτήσουν περισσότερο κάθετο χώρο.
- **Αναδίπλωση και πλάτος στήλης:** με ενεργοποιημένη την αναδίπλωση, η μείωση του πλάτους της στήλης με [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) μπορεί να δημιουργήσει περισσότερες γραμμές. Μια ευρύτερη στήλη μπορεί να μειώσει τον κάθετο χώρο που απαιτείται.
- **Περιθώρια κελιού:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) και [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) προσθέτουν κάθετο χώρο. [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) και [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) μειώνουν το πλάτος διαθέσιμο για κείμενο και μπορούν να προκαλέσουν πρόσθετη αναδίπλωση.

Για αυτόν τον πίνακα χωρίς συγχωνευμένα κελιά, το κελί που χρειάζεται τον περισσότερο κάθετο χώρο καθορίζει το όριο κατώτερης τιμής της γραμμής. Για να κάνετε τη γραμμή συντομότερη, μπορεί επίσης να χρειαστεί να μειώσετε το κείμενο, το μέγεθος της γραμματοσειράς ή τα περιθώρια, ή να διευρύνετε μια στήλη.

Οι παρακάτω εικόνες δείχνουν τον ίδιο πίνακα στην ίδια κλίμακα. Στα παραδειγματικά αποτελέσματα, τα πραγματικά ύψη ήταν 70, 100 και 55,2 σημεία: η τελική γραμμή παρέμεινε ψηλότερη από το ελάχιστο των 20 σημείων. Οι ακριβείς μετρήσεις κειμένου μπορούν να διαφέρουν ανάλογα με τις γραμματοσειρές που είναι διαθέσιμες στο περιβάλλον σας. Κατεβάστε τα αποθηκευμένα αποτελέσματα: [αυξημένο ελάχιστο](row-height-increased.pptx) και [μειωμένο ελάχιστο](row-height-decreased.pptx).

| Αρχικό: ελάχιστο 70 pt, πραγματικό 70 pt | Αυξημένο: ελάχιστο 100 pt, πραγματικό 100 pt | Μειωμένο: ελάχιστο 20 pt, πραγματικό 55.2 pt |
| --- | --- | --- |
| ![Αρχικός πίνακας με πρώτη γραμμή 70 σημείων.](row-height-before.png) | ![Πίνακας μετά την αύξηση του ελάχιστου της πρώτης γραμμής σε 100 σημεία.](row-height-increased.png) | ![Πίνακας μετά τη μείωση του ελάχιστου της πρώτης γραμμής σε 20 σημεία· το αναδιπλωμένο κείμενο διατηρεί τη γραμμή ψηλότερη από το ελάχιστο.](row-height-decreased.png) |

## **Ορισμός της Πρώτης Γραμμής ως Κεφαλίδα**

Χρησιμοποιήστε τη μέθοδο [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) για να μαρκάρετε την πρώτη γραμμή για μορφοποίηση κεφαλίδας. Η εμφάνισή της εξαρτάται από το στυλ πίνακα που έχει εφαρμοστεί.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Πρόσβαση στον πίνακα που αποθηκεύεται ως το πρώτο σχήμα στη διαφάνεια.
4. Ενεργοποιήστε τη μορφοποίηση κεφαλίδας για την πρώτη του γραμμή.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το αρχείο `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια. Ενεργοποιεί τη μορφοποίηση κεφαλίδας για την πρώτη γραμμή και αποθηκεύει το `First_row_header.pptx`.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Κλωνοποίηση Γραμμής ή Στήλης Πίνακα**

Κλωνοποιήστε γραμμές ή στήλες για να επαναχρησιμοποιήσετε το περιεχόμενο και τη μορφοποίησή τους. Μπορείτε να προσθέσετε ένα αντίγραφο στο τέλος του πίνακα ή να το εισάγετε σε συγκεκριμένη θέση.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Ορίστε τα πλάτη των στηλών και τα ύψη των γραμμών.
4. Προσθήκη πίνακα με τη μέθοδο [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Κλωνοποιήστε τις απαιτούμενες γραμμές.
6. Κλωνοποιήστε τις απαιτούμενες στήλες.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το αρχείο `Test.pptx` με τουλάχιστον μια διαφάνεια. Δημιουργεί έναν πίνακα με τρεις στήλες και πέντε γραμμές, με διαστάσεις καθορισμένες σε σημεία. Προσθέτει αντίγραφα της πρώτης γραμμής και στήλης, στη συνέχεια εισάγει αντίγραφα της δεύτερης γραμμής και στήλης στη θέση 3 (τη δεκάτη θέση). Ο τελικός πίνακας έχει επτά γραμμές και πέντε στήλες. Η παράμετρος `false` απενεργοποιεί την κλωνοποίηση σε γειτονικά συγχωνευμένα κελιά· αυτός ο πίνακας δεν περιέχει συγχωνευμένα κελιά.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Κατάργηση Γραμμής ή Στήλης από Πίνακα**

Αφαιρέστε γραμμές ή στήλες που δεν χρειάζονται πια σε έναν πίνακα. Η αφαίρεση ενός στοιχείου μετατοπίζει τους δείκτες των γραμμών ή στηλών που ακολουθούν.

1. Δημιουργήστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στην πρώτη διαφάνεια.
3. Ορίστε τα πλάτη των στηλών και τα ύψη των γραμμών.
4. Προσθήκη πίνακα με τη μέθοδο [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Αφαιρέστε τη δεύτερη γραμμή και τη δεύτερη στήλη.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα δημιουργεί έναν πίνακα τριών επί τριών και αφαιρεί τη γραμμή και τη στήλη στη θέση 1, αφήνοντας έναν πίνακα δέκα επί δέκα στο `TestTable_out.pptx`. Οι διαστάσεις είναι σε σημεία. Η παράμετρος `false` απενεργοποιεί την αφαίρεση σε γειτονικά συγχωνευμένα κελιά· αυτός ο πίνακας δεν περιέχει συγχωνευμένα κελιά.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Γραμμής Πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη μια γραμμή για να διατηρήσετε τη συνοχή των κελιών της. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και κατεύθυνση κειμένου χωρίς να μορφοποιήσετε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.
3. Χρησιμοποιήστε [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) για την πρώτη γραμμή.
4. Χρησιμοποιήστε [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) και [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) για την πρώτη γραμμή.
5. Χρησιμοποιήστε [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) για τη δεύτερη γραμμή.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο γραμμές. Εφαρμόζει κείμενο 25 σημείων, στοίχιση δεξιά και περιθώριο παραγράφου δεξιά 20 σημείων στην πρώτη γραμμή, έπειτα ορίζει κάθετο κείμενο στη δεύτερη γραμμή.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Μορφοποίησης Κειμένου σε Επίπεδο Στήλης Πίνακα**

Εφαρμόστε μορφοποίηση κειμένου σε ολόκληρη μια στήλη για να διατηρήσετε τη συνοχή των κελιών της. Μπορείτε να ορίσετε ιδιότητες γραμματοσειράς, μορφοποίηση παραγράφου και κατεύθυνση κειμένου χωρίς να μορφοποιήσετε κάθε κελί ξεχωριστά.

1. Φορτώστε την παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Πρόσβαση στον πίνακα στην πρώτη διαφάνεια.
3. Χρησιμοποιήστε [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) για την πρώτη στήλη.
4. Χρησιμοποιήστε [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) και [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) για την πρώτη στήλη.
5. Χρησιμοποιήστε [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) για τη δεύτερη στήλη.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παράδειγμα απαιτεί το `table.pptx` με έναν πίνακα ως το πρώτο σχήμα στην πρώτη διαφάνεια και τουλάχιστον δύο στήλες. Εφαρμόζει κείμενο 25 σημείων, στοίχιση δεξιά και περιθώριο παραγράφου δεξιά 20 σημείων στην πρώτη στήλη, έπειτα ορίζει κάθετο κείμενο στη δεύτερη στήλη.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Λήψη Ιδιοτήτων Στυλ Πίνακα**

Χρησιμοποιήστε τη μέθοδο [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) για να ανακτήσετε το προεπιλεγμένο στυλ που έχει εφαρμοστεί σε έναν πίνακα και να το επαναχρησιμοποιήσετε σε άλλον πίνακα. Αυτό προσδιορίζει το προεπίλεπτο αντί για τις μεμονωμένες παρακάμψεις μορφοποίησης κελιών.

Το παράδειγμα δημιουργεί έναν πίνακα, εφαρμόζει το [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) και διαβάζει το προεπιλεγμένο στυλ πίσω. Εκτυπώνει την ακέραια τιμή που αντιστοιχεί στο `DarkStyle1` και αποθηκεύει τον πίνακα στο `table.pptx`.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόζω θέματα/στυλ PowerPoint σε έναν ήδη δημιουργημένο πίνακα;**

Ναι. Ο πίνακας κληρονομεί το θέμα της διαφάνειας/διάταξης/προτύπου και μπορείτε ακόμη να αντικαταστήσετε γεμίσματα, περιθώρια και χρώματα κειμένου πάνω από αυτό το θέμα.

**Μπορώ να ταξινομώ τις γραμμές του πίνακα όπως στο Excel;**

Όχι, οι πίνακες του Aspose.Slides δεν διαθέτουν ενσωματωμένη ταξινόμηση ή φίλτρα. Ταξινομήστε τα δεδομένα στη μνήμη πρώτα, έπειτα επανασυμπληρώστε τις γραμμές του πίνακα με τη συγκεκριμένη σειρά.

**Μπορώ να έχω ταινιασμένες (γραμμωτές) στήλες διατηρώντας προσαρμοσμένα χρώματα σε συγκεκριμένα κελιά;**

Ναί. Ενεργοποιήστε τις ταινιασμένες στήλες, στη συνέχεια αντικαταστήστε συγκεκριμένα κελιά με τοπική μορφοποίηση· η μορφοποίηση επιπέδου κελιού έχει προτεραιότητα έναντι του στυλ πίνακα.