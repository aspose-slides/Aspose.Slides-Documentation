---
title: Διαχείριση Πινάκων Παρουσιάσεων σε JavaScript
linktitle: Διαχείριση Πίνακα
type: docs
weight: 10
url: /el/nodejs-java/manage-table/
keywords:
- προσθήκη πίνακα
- δημιουργία πίνακα
- πρόσβαση σε πίνακα
- λόγος πλευρών
- στοίχιση κειμένου
- μορφοποίηση κειμένου
- στυλ πίνακα
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε και επεξεργαστείτε πίνακες σε διαφάνειες PowerPoint με JavaScript και Aspose.Slides για Node.js. Ανακαλύψτε απλά παραδείγματα κώδικα για να βελτιστοποιήσετε τις ροές εργασίας με πίνακες."
---
## **Εισαγωγή**

Οι πίνακες στο PowerPoint οργανώνουν πληροφορίες σε σειρές και στήλες, διευκολύνοντας την ανάγνωση και τη σύγκριση τιμών.

Η Aspose.Slides παρέχει την κλάση [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) , την κλάση [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) και άλλους τύπους για να δημιουργήσετε, ενημερώσετε και διαχειριστείτε πίνακες σε παρουσιάσεις.

## **Δημιουργία πίνακα από το μηδέν**

Δημιουργήστε έναν πίνακα καθορίζοντας τη θέση του, το πλάτος των στηλών και το ύψος των σειρών. Αφού τον προσθέσετε σε μια διαφάνεια, μπορείτε να μορφοποιήσετε τα σύνορα των κελιών, να συγχωνεύσετε κελιά και να εισάγετε κείμενο.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στη διαφάνεια βάσει του δείκτη της.
3. Ορίστε έναν πίνακα πλάτους στηλών σε μονάδες σημείου.
4. Ορίστε έναν πίνακα ύψους σειρών σε μονάδες σημείου.
5. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) στη διαφάνεια μέσω της μεθόδου [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-).
6. Περάστε από κάθε [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) για να εφαρμόσετε μορφοποίηση στα άνω, κάτω, δεξιά και αριστερά σύνορα.
7. Συγχωνεύστε τα πρώτα δύο κελιά της πρώτης σειράς του πίνακα.
8. Πρόσβαση στο συγχωνευμένο κελί μέσω της μεθόδου [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--).
9. Ορίστε το κείμενο στο συγχωνευμένο κελί.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα δημιουργεί έναν πίνακα με τρεις στήλες και πέντε σειρές στο σημείο (100, 50). Εφαρμόζει κόκκινα σύνορα πάχους 5 σημείων, συγχωνεύει τα πρώτα δύο κελιά της πρώτης σειράς και αποθηκεύει το αποτέλεσμα ως `table.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αρίθμηση σε έναν τυπικό πίνακα**

Σε έναν τυπικό πίνακα, οι δείκτες των κελιών είναι μηδενική βάση και ακολουθούν τη σειρά (στήλη, σειρά). Το πρώτο κελί έχει δείκτη (0, 0).

Για παράδειγμα, τα κελιά ενός πίνακα με 4 στήλες και 4 σειρές αριθμούνται ως εξής:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Αυτό το παράδειγμα δημιουργεί τον 4 × 4 πίνακα που φαίνεται παραπάνω, με πλάτος στηλών και ύψος σειρών 70 σημείων και κόκκινα σύνορα κελιών πάχους 5 σημείων. Οι συντεταγμένες απεικονίζουν τους δείκτες των κελιών· το παράδειγμα αφήνει τα κελιά κενά και αποθηκεύει τον πίνακα ως `StandardTables_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Πρόσβαση σε έναν υπάρχοντα πίνακα**

Οι πίνακες αποθηκεύονται στη συλλογή σχημάτων μιας διαφάνειας. Διασχίστε τα σχήματα για να βρείτε έναν πίνακα, έπειτα χρησιμοποιήστε την κλάση [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) για να διαβάσετε ή να ενημερώσετε τα κελιά του.

1. Φορτώστε την παρουσία χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στη διαφάνεια που περιέχει τον πίνακα βάσει του δείκτη της.
3. Διασχίστε τα αντικείμενα [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) και σταματήστε όταν βρεθεί ένας πίνακας. Αν η διαφάνεια περιέχει πολλούς πίνακες, χρησιμοποιήστε το [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) για να εντοπίσετε αυτόν που χρειάζεστε.
4. Ενημερώστε το κείμενο στο επιθυμητό κελί.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα ανοίγει το `UpdateExistingTable.pptx` και εντοπίζει τον πρώτο πίνακα στην πρώτη διαφάνεια. Ορίζει το κελί στη στήλη 0, σειρά 1 σε `New` και αποθηκεύει το αποτέλεσμα ως `table1_out.pptx`. Η είσοδος πρέπει να περιέχει τουλάχιστον μία διαφάνεια και ο πρώτος πίνακας σε αυτή τη διαφάνεια πρέπει να έχει τουλάχιστον μία στήλη και δύο σειρές.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Για αλλαγή του ύψους μιας σειράς σε υπάρχοντα πίνακα και κατανόηση του γιατί το πραγματικό του ύψος μπορεί να υπερβαίνει το ζητούμενο ελάχιστο, δείτε το [Control Row Height](/slides/el/nodejs-java/manage-rows-and-columns/#control-row-height).

## **Βρείτε το κελί που κατέχει ένα πλαίσιο κειμένου**

Όταν γενικός κώδικας επεξεργασίας κειμένου λαμβάνει ένα [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) από έναν πίνακα, χρησιμοποιήστε τη μέθοδο [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) για να ανακτήσετε το κάτοχο του [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/). Για ένα πλαίσιο κειμένου κελιού πίνακα, το [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) επιστρέφει τον κάτοχο και το [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) επιστρέφει `null`, παρόλο που ο ίδιος ο πίνακας είναι σχήμα.

Οι συντεταγμένες του κελιού είναι διαθέσιμες μέσω των μόνο-ανάγνωσης μεθόδων [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) και [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--). Το [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) παρέχει επίσης μόνο-ανάγνωσης πλοήγηση: επιστρέφει τον κάτοχο χωρίς να αλλάζει την ιδιοκτησία. Πάντα ελέγχετε αν το επιστρεφόμενο κελί είναι `null` πριν το χρησιμοποιήσετε.

Για ολοκληρωμένο παράδειγμα που εντοπίζει ιδιοκτήτες κελιών πίνακα και σχημάτων, συμπεριλαμβανομένων σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/nodejs-java/search-and-replace-text/).

## **Στοίχιση κειμένου σε πίνακα**

Μπορείτε να ελέγξετε την κάθετη αγκύρωση και την κατεύθυνση κειμένου των μεμονωμένων κελιών πίνακα. Το παράδειγμα σε αυτήν την ενότητα κεντράρει το κείμενο στο πρώτο κελί και το περιστρέφει κατά 270 μοίρες.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στη διαφάνεια βάσει του δείκτη της.
3. Προσθέστε ένα αντικείμενο [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) στη διαφάνεια.
4. Πρόσβαση σε ένα αντικείμενο [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) από τον πίνακα.
5. Πρόσβαση στην πρώτη [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) και ορίστε το κείμενο και το χρώμα της.
6. Ορίστε την κάθετη αγκύρωση του κελιού και την κατεύθυνση κειμένου χρησιμοποιώντας τις μεθόδους [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) και [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτό το παράδειγμα δημιουργεί έναν 4 × 4 πίνακα με πλάτος στηλών 120 σημείων και ύψος σειρών 100 σημείων. Μορφοποιεί το κείμενο στο κελί (0, 0), προσθέτει τιμές στα υπόλοιπα κελιά της πρώτης σειράς και αποθηκεύει το αποτέλεσμα ως `Vertical_Align_Text_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός μορφοποίησης κειμένου σε επίπεδο πίνακα**

Χρησιμοποιήστε τη μέθοδο [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) για να εφαρμόσετε μορφοποίηση κειμένου σε όλα τα κελιά ενός πίνακα. Οι υπερφορτώσεις της δέχονται μορφοποίηση τμήματος, παραγράφου και πλαισίου κειμένου, ώστε να μπορείτε να ορίσετε αυτές τις ιδιότητες χωρίς να διασχίζετε μεμονωμένα κελιά.

1. Φορτώστε την παρουσία χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Αποκτήστε μια αναφορά στη διαφάνεια βάσει του δείκτη της.
3. Πρόσβαση σε ένα αντικείμενο [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) από τη διαφάνεια.
4. Ορίστε το μέγεθος γραμματοσειράς χρησιμοποιώντας τη μέθοδο [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) για το κείμενο.
5. Ορίστε την ευθυγράμμιση παραγράφου και το δεξιό περιθώριο με τις μεθόδους [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) και [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Ορίστε την κατεύθυνση κειμένου με τη μέθοδο [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Το παρακάτω παράδειγμα ανοίγει το `table.pptx`, που πρέπει να περιέχει τουλάχιστον μία διαφάνεια με πίνακα ως πρώτο σχήμα. Ορίζει το μέγεθος γραμματοσειράς σε 25 σημεία, ευθυγραμμίζει δεξιά τις παραγράφους με δεξιό περιθώριο 20 σημείων και κάνει το κείμενο κάθετο. Η μορφοποιημένη παρουσίαση αποθηκεύεται ως `result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Λήψη ιδιοτήτων στυλ πίνακα**

Χρησιμοποιήστε τη μέθοδο [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) για να διαβάσετε το προεπιλεγμένο στυλ ενός πίνακα και τη μέθοδο [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) για να το ορίσετε. Αυτό το παράδειγμα εφαρμόζει το [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) σε έναν πίνακα, εκτυπώνει την τιμή του προεπιλογής και ορίζει το ίδιο προεπιλεγμένο στυλ σε δεύτερο πίνακα. Και οι δύο πίνακες αποθηκεύονται στο `table-style.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Κλείδωμα λόγου διαστάσεων πίνακα**

Ο λόγος διαστάσεων ενός πίνακα είναι το πηλίκο του πλάτους προς το ύψος του. Χρησιμοποιήστε τη μέθοδο [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) για να κλειδώσετε αυτό το λόγο για έναν πίνακα.

Το παρακάτω παράδειγμα ανοίγει το `pres.pptx`, που πρέπει να περιέχει τουλάχιστον μία διαφάνεια με πίνακα ως πρώτο σχήμα. Εκτυπώνει την τρέχουσα κατάσταση του κλειδώματος, ενεργοποιεί το κλείδωμα του λόγου διαστάσεων, εκτυπώνει την ενημερωμένη κατάσταση (`true`) και αποθηκεύει το αποτέλεσμα ως `pres-out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Μπορώ να ενεργοποιήσω την κατεύθυνση ανάγνωσης δεξιά‑ προς‑αριστερά (RTL) για ολόκληρο τον πίνακα και το κείμενο στα κελιά του;**

Ναι. Ο πίνακας εκθέτει τη μέθοδο [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-), και οι παράγραφοι έχουν τη μέθοδο [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-). Η χρήση και των δύο εξασφαλίζει τη σωστή σειρά RTL και την απόδοση μέσα στα κελιά.

**Πώς μπορώ να αποτρέψω τους χρήστες από το να μετακινούν ή να αλλάζουν το μέγεθος ενός πίνακα στο τελικό αρχείο;**

Χρησιμοποιήστε τα [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) για να απενεργοποιήσετε τη μετακίνηση, την αλλαγή μεγέθους, την επιλογή κ.λπ. Αυτά τα κλειδώματα εφαρμόζονται και στους πίνακες.

**Υποστηρίζεται η εισαγωγή μιας εικόνας μέσα σε κελί ως φόντο;**

Ναι. Μπορείτε να ορίσετε μια [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) για ένα κελί· η εικόνα θα καλύψει την περιοχή του κελιού σύμφωνα με τον επιλεγμένο τρόπο (τράνταγμα ή επικάλυψη).