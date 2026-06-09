---
title: Λήψη αποτελεσματικών ιδιοτήτων σχήματος από παρουσιάσεις σε JavaScript
linktitle: Αποτελεσματικές Ιδιότητες
type: docs
weight: 50
url: /el/nodejs-java/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- σύστημα φωτισμού
- σχήμα bevel
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ανακαλύψτε πώς το Aspose.Slides για Node.js μέσω Java υπολογίζει και εφαρμόζει τις αποτελεσματικές ιδιότητες σχήματος για ακριβή απόδοση PowerPoint."
---
## **Επισκόπηση**

Αυτό το θέμα εξηγεί τη διαφορά μεταξύ **τοπικές** και **αποτελεσματικές** ιδιότητες. Οι τοπικές τιμές είναι τιμές που ορίζονται απευθείας σε ένα συγκεκριμένο επίπεδο μορφοποίησης, όπως:

1. Ιδιότητες τμήματος σε μια διαφάνεια.
1. Στυλ κειμένου πρωτότυπου σχήματος σε διάταξη ή κύρια διαφάνεια, όταν το σχήμα πλαισίου κειμένου του τμήματος έχει ένα.
1. Καθολικές ρυθμίσεις κειμένου σε μια παρουσίαση.

Οι τοπικές τιμές μπορούν να οριστούν ή να παραλειφθούν σε οποιοδήποτε επίπεδο. Όταν το Aspose.Slides χρειάζεται την τελική μορφοποίηση «όπως εμφανίζεται», λύνει την αλυσίδα κληρονομικότητας και επιστρέφει τις **αποτελεσματικές** τιμές. Μπορείτε να τις λάβετε καλώντας τη μέθοδο `getEffective` στο τοπικό αντικείμενο μορφής.

Το παρακάτω παράδειγμα δείχνει πώς να λάβετε τις αποτελεσματικές τιμές. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) με πλαίσιο κειμένου και τουλάχιστον ένα τμήμα.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Τα δεδομένα αποτελεσματικής μορφοποίησης αντιπροσωπεύουν τη τρέχουσα υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας. Στην τρέχουσα υλοποίηση, ορισμένα αντικείμενα αποτελεσματικών δεδομένων μπορεί να αποθηκεύονται προσωρινά εσωτερικά. Η επανάκληση του `getEffective` μετά την αλλαγή της γονικής ή κληρονομικής μορφοποίησης μπορεί να ανανεώσει τα προσωρινά δεδομένα, και ένα αντικείμενο που είχε ληφθεί προηγουμένως ενδέχεται να μην αντιπροσωπεύει πλέον την προηγούμενη κατάσταση. Εάν χρειάζεται να διατηρήσετε τις αποτελεσματικές τιμές για μελλοντική χρήση, αντιγράψτε τις απαιτούμενες ιδιότητες, όπως το ύψος γραμματοσειράς, το χρώμα γεμίσματος, το στυλ γραμματοσειράς ή την ευθυγράμμιση, στο δικό σας αντικείμενο δεδομένων.
{{% /alert %}}

## **Λήψη αποτελεσματικών ιδιοτήτων κάμερας**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες μιας κάμερας. Το αντικείμενο δεδομένων αποτελεσματικής κάμερας περιέχει αμετάβλητες ιδιότητες κάμερας και εκτίθεται μέσω των αποτελεσματικών τιμών που επιστρέφονται για το [ThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για την κάμερα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει μορφοποίηση 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Λήψη αποτελεσματικών ιδιοτήτων συστήματος φωτισμού**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες ενός συστήματος φωτισμού. Το αντικείμενο δεδομένων αποτελεσματικού φωτισμού περιέχει αμετάβλητες ιδιότητες του φωτιστικού συστήματος και εκτίθεται μέσω των αποτελεσματικών τιμών που επιστρέφονται για το [ThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για το σύστημα φωτισμού. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει μορφοποίηση 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Λήψη αποτελεσματικών ιδιοτήτων σχήματος Bevel**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες ενός σχήματος Bevel. Το αντικείμενο δεδομένων αποτελεσματικού σχήματος Bevel περιέχει αμετάβλητες ιδιότητες ανάπλασης του σχήματος και εκτίθεται μέσω των αποτελεσματικών τιμών που επιστρέφονται για το [ThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για το άνω bevel ενός σχήματος. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει μορφοποίηση 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Λήψη αποτελεσματικών ιδιοτήτων πλαισίου κειμένου**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε τις αποτελεσματικές ιδιότητες ενός πλαισίου κειμένου. Το επιστρεφόμενο αντικείμενο αποτελεσματικών δεδομένων περιέχει ιδιότητες μορφοποίησης πλαισίου κειμένου.

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις ιδιότητες μορφοποίησης αποτελεσματικού πλαισίου κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) με πλαίσιο κειμένου.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Λήψη αποτελεσματικών ιδιοτήτων στυλ κειμένου**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε τις αποτελεσματικές ιδιότητες ενός στυλ κειμένου. Το επιστρεφόμενο αντικείμενο αποτελεσματικών δεδομένων περιέχει ιδιότητες στυλ κειμένου.

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις ιδιότητες αποτελεσματικού στυλ κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) με πλαίσιο κειμένου.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Λήψη της αποτελεσματικής τιμής ύψους γραμματοσειράς**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε το αποτελεσματικό ύψος γραμματοσειράς. Ο παρακάτω κώδικας δείχνει πώς το αποτελεσματικό ύψος γραμματοσειράς ενός τμήματος αλλάζει μετά το τοπικό ορισμό του ύψους γραμματοσειράς σε διαφορετικά επίπεδα δομής παρουσίασης.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **Λήψη της αποτελεσματικής μορφής γεμίσματος για Πίνακα**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε αποτελεσματικό γεμίζον μορφότυπο για διαφορετικά μέρη πίνακα. Το επιστρεφόμενο αντικείμενο αποτελεσματικών δεδομένων περιέχει ιδιότητες μορφοποίησης γεμίσματος. Η μορφοποίηση κελιού έχει προτεραιότητα έναντι της μορφοποίησης σειράς, η μορφοποίηση σειράς έχει προτεραιότητα έναντι της μορφοποίησης στήλης, και η μορφοποίηση στήλης έχει προτεραιότητα έναντι της μορφοποίησης ολόκληρου του πίνακα.

Ως αποτέλεσμα, οι αποτελεσματικές ιδιότητες μορφοποίησης κελιού χρησιμοποιούνται για τη σχεδίαση του κελιού του πίνακα. Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε αποτελεσματική μορφοποίηση γεμίσματος για διαφορετικά μέρη του πίνακα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/table/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Επιστρέφει η `getEffective` ένα στιγμιότυπο;**

Όχι πάντα. Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τη μορφοποίηση που υπολογίζεται μετά την εφαρμογή της κληρονομικότητας, αλλά ορισμένα αντικείμενα αποτελεσματικών δεδομένων μπορεί να αποθηκεύονται προσωρινά εσωτερικά. Μια επόμενη κλήση του `getEffective` μπορεί να επαναϋπολογίσει τη μορφοποίηση και να ανανεώσει τα προσωρινά δεδομένα, έτσι ένα αντικείμενο που είχε ληφθεί προηγουμένως δεν πρέπει να θεωρείται μόνιμο στιγμιότυπο.

**Πότε πρέπει να διαβάσω ξανά τις αποτελεσματικές ιδιότητες;**

Κλήστε το `getEffective` ξανά μετά από αλλαγή της τοπικής μορφοποίησης, των στυλ γονέα, της μορφοποίησης διάταξης, της μορφοποίησης κύριου αρχείου ή των προεπιλογών σε επίπεδο παρουσίασης. Η επόμενη κλήση επανεξετάζει την ιεραρχία μορφοποίησης και επιστρέφει το τρέχον αποτελεσματικό αποτέλεσμα.

**Επηρεάζει η αλλαγή ή η αφαίρεση μιας διαφάνειας διάταξης/κύριας τις ήδη ανακτημένες αποτελεσματικές ιδιότητες;**

Ναι, αλλά η αλλαγή αντανακλάται στην επόμενη κλήση του `getEffective`. Εάν αλλάξει ή αφαιρεθεί η πηγή μορφοποίησης γονέα, τα προηγουμένως αποκτηθέντα αποτελεσματικά δεδομένα μπορεί να είναι παλιά. Μόλις κληθεί ξανά το `getEffective`, το Aspose.Slides επανεξετάζει το δένδρο μορφοποίησης και οι προκύπτοντες γραμματοσειρές, χρώματα, μεγέθη ή άλλες τιμές μπορεί να αλλάξουν.

**Μπορώ να τροποποιήσω τιμές μέσω των αντικειμένων αποτελεσματικών δεδομένων;**

Όχι. Τα αντικείμενα αποτελεσματικών δεδομένων εκθέτουν τις υπολογισμένες τιμές. Κάντε τις αλλαγές στα τοπικά αντικείμενα μορφοποίησης και, στη συνέχεια, λάβετε ξανά τις αποτελεσματικές τιμές.

**Τι συμβαίνει αν μια ιδιότητα δεν έχει οριστεί στο επίπεδο του σχήματος, ούτε στη διάταξη/κύρια, ούτε στις καθολικές ρυθμίσεις;**

Η αποτελεσματική τιμή καθορίζεται από τον προεπιλεγμένο μηχανισμό, ο οποίος περιλαμβάνει τις προεπιλογές του PowerPoint και του Aspose.Slides. Η επιλυμένη τιμή γίνεται μέρος των τρεχουσών αποτελεσματικών δεδομένων.

**Από μια αποτελεσματική τιμή γραμματοσειράς, μπορώ να προσδιορίσω ποιο επίπεδο παρείχε το μέγεθος ή το τυπογραφικό;**

Όχι άμεσα. Τα αποτελεσματικά δεδομένα επιστρέφουν την τελική τιμή. Για να βρείτε την πηγή, ελέγξτε τις τοπικές τιμές στο τμήμα, την παράγραφο, το πλαίσιο κειμένου και τα στυλ κειμένου στη διάταξη, το κύριο και το επίπεδο παρουσίασης για να δείτε πού εμφανίζεται ο πρώτος ρητός ορισμός.

**Γιατί οι αποτελεσματικές τιμές μερικές φορές μοιάζουν με τις τοπικές;**

Επειδή η τοπική τιμή καταλήγει να είναι η τελική (δεν απαιτήθηκε κληρονόμηση από ανώτερο επίπεδο). Σε τέτοιες περιπτώσεις, η αποτελεσματική τιμή ταιριάζει με την τοπική.

**Πότε πρέπει να χρησιμοποιώ αποτελεσματικές ιδιότητες και πότε να εργάζομαι μόνο με τις τοπικές;**

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα όταν χρειάζεστε το αποτέλεσμα «όπως εμφανίζεται» μετά την πλήρη κληρονομικότητα, όπως για την ευθυγράμμιση χρωμάτων, εσοχών ή μεγεθών. Εάν χρειάζεται να διατηρήσετε αυτές τις τιμές ανεξάρτητα από μελλοντικές αλλαγές μορφοποίησης, αντιγράψτε τις απαιτούμενες ιδιότητες στο δικό σας αντικείμενο. Εάν χρειάζεται να αλλάξετε τη μορφοποίηση σε συγκεκριμένο επίπεδο, τροποποιήστε τις τοπικές ιδιότητες και, αν χρειάζεται, διαβάστε ξανά τα αποτελεσματικά δεδομένα για να επαληθεύσετε το αποτέλεσμα.