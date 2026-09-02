---
title: Λήψη Αποτελεσματικών Ιδιοτήτων Σχήματος από Παρουσιάσεις σε JavaScript
linktitle: Αποτελεσματικές Ιδιότητες
type: docs
weight: 50
url: /el/nodejs-java/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- σύστημα φωτισμού
- σχήμα κλίσης
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να χρησιμοποιείτε το Aspose.Slides for Node.js μέσω Java για να διακρίνετε την τοπική, κληρονομισμένη και αποτελεσματική μορφοποίηση σχήματος σε παρουσιάσεις PowerPoint."
---
## **Κατανόηση Τοπικών, Κληρονομισμένων και Αποτελεσματικών Ιδιοτήτων**

Η μορφοποίηση του PowerPoint μπορεί να προέρχεται από διάφορες πηγές. Η τιμή που αποθηκεύεται άμεσα σε ένα αντικείμενο είναι η **τοπική τιμή** του. Εάν αυτή η τιμή δεν έχει οριστεί, το PowerPoint εξετάζει τις πηγές μορφοποίησης γονέα, όπως το προεπιλεγμένο παράγραφο, ένα στυλ κειμένου, μια διάταξη ή μια κύρια διαφάνεια, ένα θέμα ή τις προεπιλογές επιπέδου παρουσίασης. Αυτές οι τιμές είναι **κληρονομισμένες τιμές**. Η τιμή που παραμένει μετά την επίλυση ολόκληρης της ιεραρχίας είναι η **αποτελεσματική τιμή** — η τιμή που χρησιμοποιείται για την απόδοση του αντικειμένου.

Για παράδειγμα, ένα τμήμα κειμένου μπορεί να μην ορίζει το δικό του ύψος γραμματοσειράς. Η τοπική του τιμή [getFontHeight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portionformat/#getFontHeight) είναι τότε `NaN`, που σημαίνει «δεν ορίσθηκε εδώ». Το τμήμα μπορεί να κληρονομήσει το ύψος από την παράγραφο, το προεπιλεγμένο στυλ κειμένου της παρουσίασης ή άλλη εφαρμόσιμη πηγή. Η κλήση του [getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portionformat/#getEffective) στη μορφή του τμήματος επιστρέφει το τελικό επιλυμένο ύψος.

Χρησιμοποιήστε τα δύο είδη δεδομένων μορφοποίησης για διαφορετικούς σκοπούς:

- Διαβάστε ή τροποποιήστε ένα τοπικό αντικείμενο μορφοποίησης, όπως το [PortionFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portionformat/), όταν χρειάζεται να ελέγξετε πού ορίζεται μια τιμή.
- Διαβάστε τα [effective data returned by PortionFormat.getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portionformat/#getEffective) όταν χρειάζεστε το τελικό, αποδιδόμενο αποτέλεσμα. Τα αποτελεσματικά δεδομένα είναι μόνο για ανάγνωση.

Προτού εκτελέσετε τα παραδείγματα, [install Aspose.Slides for Node.js via Java](/slides/el/nodejs-java/installation/).

## **Σύγκριση Τοπικών, Κληρονομισμένων και Αποτελεσματικών Τιμών**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα σχήμα και εφαρμόζει ύψη γραμματοσειράς σε επίπεδα παρουσίασης, παραγράφου και τμήματος. Κάθε βήμα εκτυπώνει τις τιμές που ορίζονται σε αυτά τα επίπεδα και την προκύπτουσα αποτελεσματική τιμή για το ίδιο τμήμα κειμένου. Επίσης δείχνει γιατί τα αποτελεσματικά δεδομένα πρέπει να αναγιγνώσκονται ξανά μετά από αλλαγές μορφοποίησης.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // Διαβάστε τα αποτελεσματικά δεδομένα μετά τις προηγούμενες αλλαγές.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // Ορίστε κληρονομισμένες τιμές σε δύο διαφορετικά επίπεδα.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // Μια τοπική τιμή στο τμήμα υπερισχύει και των κληρονομισμένων τιμών.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Η αλλαγή μιας κληρονομισμένης τιμής δεν παρακάμπτει μια υπάρχουσα τοπική τιμή.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Καθαρίστε την τοπική τιμή. Το τμήμα κληρονομεί πάλι από την παράγραφο.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Καθαρίστε την τιμή της παραγράφου. Η προεπιλογή παρουσίασης παρέχει şimdi το αποτέλεσμα.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η προτεραιότητα σε αυτό το παράδειγμα είναι η τοπική μορφοποίηση του τμήματος, έπειτα η μορφοποίηση της παραγράφου, και τέλος η προεπιλογή της παρουσίασης. Άλλα αντικείμενα μπορούν να έχουν διαφορετικούς αλυσίδες κληρονομικότητας, αλλά η αρχή παραμένει η ίδια: μια πιο συγκεκριμένη ρητή τιμή κερδίζει, και το [getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portionformat/#getEffective) επιστρέφει το τελικό αποτέλεσμα.

## **Λήψη Αποτελεσματικών Ιδιοτήτων Κειμένου**

Η μορφοποίηση κειμένου διαχωρίζεται σε πολλά αντικείμενα:

- Το [TextFrameFormat.getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#getEffective) επιλύει τις ιδιότητες πλαισίου κειμένου όπως περιθώρια, αγκύρωση, αυτόματο προσαρμοστικό μέγεθος και κάθετη κατεύθυνση κειμένου.
- Το [TextStyle.getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textstyle/#getEffective) επιλύει τη μορφοποίηση παραγράφου για κάθε επίπεδο στυλ κειμένου.
- Το [ParagraphFormat.getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraphformat/#getEffective) επιλύει ιδιότητες παραγράφου όπως στοίχιση, εσοχές και κουκίδες.
- Το [PortionFormat.getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portionformat/#getEffective) επιλύει ιδιότητες χαρακτήρων όπως ύψος γραμματοσειράς, τύπο γραμματοσειράς, χρώμα, έντονη και πλάγια γραφή.

Για το επόμενο παράδειγμα, το `text-formatting.pptx` πρέπει να περιέχει τουλάχιστον μία διαφάνεια και ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) με μη κενό πλαίσιο κειμένου. Το AutoShape μπορεί να εμφανίζεται σε οποιαδήποτε θέση στη συλλογή σχημάτων· ο κώδικας αναζητά ένα κατάλληλο αντικείμενο και το επικυρώνει πριν το χρησιμοποιήσει.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **Λήψη Αποτελεσματικών 3Δ Ιδιοτήτων**

Το [ThreeDFormat.getEffective](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getEffective) επιστρέφει ένα αντικείμενο αποτελεσματικών δεδομένων που ομαδοποιεί όλες τις επιλυμένες ρυθμίσεις 3Δ. Οι μέθοδοι του [getCamera](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getBevelTop) και [getBevelBottom](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getBevelBottom) αποκαλύπτουν τα αντίστοιχα αποτελεσματικά δεδομένα. Η ανάγνωση αυτών των σχετικών ρυθμίσεων μαζί καθιστά πιο εύκολο να κατανοήσετε την τελική εμφάνιση 3Δ ενός σχήματος.

Για αυτό το παράδειγμα, το `shape-3d.pptx` πρέπει να περιέχει τουλάχιστον ένα σχήμα στην πρώτη του διαφάνεια. Εφαρμόστε 3Δ κάμερα, φωτισμό ή ρυθμίσεις ασκήματος σε αυτό το σχήμα εάν θέλετε το αποτέλεσμα να περιέχει τιμές διαφορετικές από τις προεπιλογές.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **Λήψη Αποτελεσματικής Μορφοποίησης Πίνακα**

Η μορφοποίηση πίνακα μπορεί να προέλθει από το στυλ του πίνακα και από μορφώσεις που εφαρμόζονται σε ολόκληρο τον πίνακα, μια στήλη, μια γραμμή ή ένα μεμονωμένο κελί. Σε συγκρούσεις μεταξύ ρητά ορισμένων γεμισμάτων, η προτεραιότητα είναι κελί, γραμμή, στήλη και στη συνέχεια ολόκληρος ο πίνακας. Η αποτελεσματική μορφή ενός κελιού είναι η τελική μορφή που χρησιμοποιείται για τη σχεδίαση εκείνου του κελιού.

Για αυτό το παράδειγμα, το `table-formatting.pptx` πρέπει να περιέχει τουλάχιστον έναν πίνακα στην πρώτη του διαφάνεια. Ο πίνακας πρέπει να έχει τουλάχιστον μία γραμμή και μία στήλη. Ο κώδικας αναζητά ένα [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/table/) αντί να υποθέτει ότι το `getShapes().get_Item(0)` είναι πίνακας.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

Εάν χρειάζεστε το χρώμα αντί μόνο του τύπου γεμίσματος, πρώτα ελέγξτε το αποτελεσματικό [getFillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fillformat/#getFillType) και, στη συνέχεια, διαβάστε τη μέθοδο που εφαρμόζεται σε αυτόν τον τύπο — για παράδειγμα, το [getSolidFillColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) για γεμιστό στερεό.

## **Ανανέωση Αποτελεσματικών Δεδομένων Μετά Από Αλλαγές**

Τα αποτελεσματικά δεδομένα περιγράφουν την ιεραρχία μορφοποίησης τη στιγμή που επιλύονται. Καλέστε ξανά το `getEffective` μετά από οποιαδήποτε αλλαγή μπορεί να συμμετέχει σε αυτήν την ιεραρχία, συμπεριλαμβανομένων:

- της τοπικής μορφοποίησης του αντικειμένου·
- των προεπιλογών παραγράφου ή πλαισίου κειμένου·
- ενός στυλ πίνακα, πίνακα, στήλης, γραμμής ή μορφοποίησης κελιού·
- της μορφοποίησης διάταξης ή κύριας διαφάνειας·
- των δεδομένων θέματος ή προεπιλογών επιπέδου παρουσίασης·
- της διάταξης ή κύριας που έχει εκχωρηθεί σε μια διαφάνεια.

Μην κρατάτε ένα αντικείμενο αποτελεσματικών δεδομένων ως μόνιμο στιγμιότυπο. Το Aspose.Slides μπορεί να κάνει εσωτερική προσωρινή αποθήκευση (caching) ορισμένων αποτελεσματικών δεδομένων, και μια μεταγενέστερη κλήση `getEffective` μπορεί να ανανεώσει αυτά τα δεδομένα. Εάν χρειάζεται να συγκρίνετε τιμές πριν και μετά από μια αλλαγή, αντιγράψτε τις βαθμικές τιμές που χρειάζεστε — όπως ύψος γραμματοσειράς, χρώμα, στοίχιση ή πλάτος ασκήματος — σε δικές σας μεταβλητές πριν κάνετε την αλλαγή.

Για να αλλάξετε μια τιμή, ενημερώστε το κατάλληλο τοπικό αντικείμενο μορφοποίησης και, στη συνέχεια, καλέστε το `getEffective` για να επαληθεύσετε το αποτέλεσμα. Τα αντικείμενα αποτελεσματικών δεδομένων είναι μόνο για ανάγνωση.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διακρίνω ποιο επίπεδο παρείχε μια αποτελεσματική τιμή;**

Τα αποτελεσματικά δεδομένα περιέχουν τη τελική τιμή, όχι την πηγή της. Εξετάστε τα εφαρμόσιμα τοπικά αντικείμενα ξεκινώντας από το πιο συγκεκριμένο επίπεδο προς τα έξω. Για κείμενο, αυτό μπορεί να περιλαμβάνει το τμήμα, την παράγραφο, το πλαίσιο κειμένου, τη διάταξη, την κύρια διαφάνεια, το θέμα και τις προεπιλογές της παρουσίασης. Απροσδιόριστες τιμές όπως `NaN` ή `null` υποδηλώνουν ότι η αναζήτηση συνεχίζεται σε άλλο επίπεδο.

**Τι συμβαίνει όταν κανένα επίπεδο δεν ορίζει μια ιδιότητα;**

Το Aspose.Slides επιλύει την κατάλληλη προεπιλογή του PowerPoint ή της βιβλιοθήκης. Η επιλυμένη τιμή εμφανίζεται στα αποτελεσματικά δεδομένα παρόλο που κανένα τοπικό αντικείμενο δεν την ορίζει ρητά.

**Γιατί μια αποτελεσματική τιμή μερικές φορές είναι ίση με την τοπική τιμή;**

Η τοπική τιμή κέρδισε τον υπολογισμό κληρονομικότητας. Αυτό είναι αναμενόμενο όταν η ιδιότητα έχει οριστεί ρητά στο αντικείμενο και κανένας πιο συγκεκριμένος κανόνας δεν την υπερισχύει.

**Πότε πρέπει να χρησιμοποιήσω τοπικά δεδομένα αντί για αποτελεσματικά δεδομένα;**

Χρησιμοποιήστε τοπικά δεδομένα για να ελέγξετε ή να επεξεργαστείτε ένα συγκεκριμένο επίπεδο μορφοποίησης. Χρησιμοποιήστε αποτελεσματικά δεδομένα όταν χρειάζεστε την τελική εμφάνιση μετά την κληρονομικότητα, τους κανόνες θέματος και τα εφαρμόσιμα στυλ. Το [complete comparison example](#compare-local-inherited-and-effective-values) παρουσιάζει και τα δύο στην ίδια ροή εργασίας.