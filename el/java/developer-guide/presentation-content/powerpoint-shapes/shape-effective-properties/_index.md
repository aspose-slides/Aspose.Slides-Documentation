---
title: Λήψη Αποτελεσματικών Ιδιοτήτων Σχήματος από Παρουσιάσεις σε Java
linktitle: Αποτελεσματικές Ιδιότητες
type: docs
weight: 50
url: /el/java/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- σύστημα φωτισμού
- σχήμα χωνίας
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς το Aspose.Slides για Java υπολογίζει και εφαρμόζει αποτελεσματικές ιδιότητες σχήματος για ακριβή απόδοση PowerPoint."
---
## **Επισκόπηση**

Αυτό το θέμα εξηγεί τη διαφορά μεταξύ **τοπικών** και **αποτελεσματικών** ιδιοτήτων. Οι τοπικές τιμές είναι τιμές που ορίζονται άμεσα σε συγκεκριμένο επίπεδο μορφοποίησης, όπως:

1. Ιδιότητες τμήματος σε μία διαφάνεια.
1. Στυλ κειμένου πρωτότυπου σχήματος σε διάταξη ή κύρια διαφάνεια, όταν το σχήμα του πλαισίου κειμένου του τμήματος διαθέτει ένα.
1. Γενικές ρυθμίσεις κειμένου σε μια παρουσίαση.

Οι τοπικές τιμές μπορούν να οριστούν ή να παραλειφθούν σε οποιοδήποτε επίπεδο. Όταν το Aspose.Slides χρειάζεται την τελική μορφοποίηση "όπως αποδίδεται", επιλύει την αλυσίδα κληρονομικότητας και επιστρέφει **αποτελεσματικές** τιμές. Μπορείτε να τις λάβετε καλώντας τη μέθοδο `getEffective` στο αντικείμενο τοπικής μορφής.

Το παρακάτω παράδειγμα δείχνει πώς να λάβετε αποτελεσματικές τιμές. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape) με πλαίσιο κειμένου και τουλάχιστον ένα τμήμα.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Τα δεδομένα αποτελεσματικής μορφοποίησης αντιπροσωπεύουν την τρέχουσα υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας. Στην τρέχουσα υλοποίηση, ορισμένα αντικείμενα αποτελεσματικών δεδομένων, όπως το [IPortionFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPortionFormatEffectiveData), μπορεί να αποθηκεύονται στην μνήμη. Η επανεκτέλεση του `getEffective` μετά από αλλαγή της γονικής ή κληρονομημένης μορφοποίησης μπορεί να ανανεώσει τα cached δεδομένα, και ένα αντικείμενο που ελήφθη προηγουμένως μπορεί να μην αντιπροσωπεύει πια την προηγούμενη κατάσταση. Εάν χρειάζεται να διατηρήσετε τις αποτελεσματικές τιμές για μετέπειτα χρήση, αντιγράψτε τις απαιτούμενες ιδιότητες, όπως το ύψος γραμματοσειράς, το χρώμα γεμίσματος, το στυλ γραμματοσειράς ή την στοίχιση, σε δικό σας αντικείμενο δεδομένων.
{{% /alert %}}

## **Λήψη Αποτελεσματικών Ιδιοτήτων Κάμερας**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες μιας κάμερας. Η διεπαφή [ICameraEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICameraEffectiveData) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει τις αποτελεσματικές ιδιότητες της κάμερας. Ένα στιγμιότυπο [ICameraEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICameraEffectiveData) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IThreeDFormatEffectiveData), το οποίο παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/IThreeDFormat).

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για την κάμερα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια διαθέτει 3Δ μορφοποίηση.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Λήψη Αποτελεσματικών Ιδιοτήτων Συστήματος Φώτου**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες ενός συστήματος φωτός. Η διεπαφή [ILightRigEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ILightRigEffectiveData) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες του συστήματος φωτός. Ένα στιγμιότυπο [ILightRigEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ILightRigEffectiveData) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IThreeDFormatEffectiveData), που παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/IThreeDFormat).

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για το σύστημα φωτός. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια διαθέτει 3Δ μορφοποίηση.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Λήψη Αποτελεσματικών Ιδιοτήτων Σχήματος Χωνίας**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες μιας χωνίας σχήματος. Η διεπαφή [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeBevelEffectiveData) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες ανάπλασης για ένα σχήμα. Ένα στιγμιότυπο [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeBevelEffectiveData) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IThreeDFormatEffectiveData), το οποίο παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/IThreeDFormat).

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για την επάνω χωνία ενός σχήματος. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια διαθέτει 3Δ μορφοποίηση.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Λήψη Αποτελεσματικών Ιδιοτήτων Πλαισίου Κειμένου**

Με το Aspose.Slides, μπορείτε να λάβετε τις αποτελεσματικές ιδιότητες ενός πλαισίου κειμένου. Η διεπαφή [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITextFrameFormatEffectiveData) περιέχει ιδιότητες αποτελεσματικής μορφοποίησης πλαισίου κειμένου.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να λάβετε τις ιδιότητες αποτελεσματικής μορφοποίησης πλαισίου κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape) με πλαίσιο κειμένου.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Λήψη Αποτελεσματικών Ιδιοτήτων Στυλ Κειμένου**

Με το Aspose.Slides, μπορείτε να λάβετε τις αποτελεσματικές ιδιότητες ενός στυλ κειμένου. Η διεπαφή [ITextStyleEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITextStyleEffectiveData) περιέχει ιδιότητες αποτελεσματικού στυλ κειμένου.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να λάβετε τις ιδιότητες αποτελεσματικού στυλ κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape) με πλαίσιο κειμένου.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Λήψη Αποτελεσματικής Τιμής Ύψους Γραμματοσειράς**

Με το Aspose.Slides, μπορείτε να λάβετε το αποτελεσματικό ύψος γραμματοσειράς. Ο παρακάτω κώδικας δείχνει πώς το αποτελεσματικό ύψος γραμματοσειράς ενός τμήματος αλλάζει μετά τον ορισμό τοπικών τιμών ύψους γραμματοσειράς σε διαφορετικά επίπεδα δομής της παρουσίασης.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Λήψη Αποτελεσματικής Μορφής Γέμισης για Πίνακα**

Με το Aspose.Slides, μπορείτε να λάβετε την αποτελεσματική μορφή γέμισης για διάφορα τμήματα πίνακα. Η διεπαφή [IFillFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IFillFormatEffectiveData) περιέχει ιδιότητες αποτελεσματικής μορφής γέμισης. Η μορφοποίηση κελιού έχει μεγαλύτερη προτεραιότητα από τη μορφοποίηση γραμμής, η μορφοποίηση γραμμής έχει μεγαλύτερη προτεραιότητα από τη μορφοποίηση στήλης, και η μορφοποίηση στήλης έχει μεγαλύτερη προτεραιότητα από τη μορφοποίηση ολόκληρου πίνακα.

Ως αποτέλεσμα, χρησιμοποιούνται οι ιδιότητες [ICellFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICellFormatEffectiveData) για την απόδοση του κελιού του πίνακα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να λάβετε την αποτελεσματική μορφή γέμισης για διαφορετικά τμήματα πίνακα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [ITable](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITable).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Επιστρέφει η `getEffective` στιγμιότυπο;**

Όχι πάντα. Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τη μορφοποίηση που υπολογίζεται μετά την εφαρμογή της κληρονομικότητας, αλλά ορισμένα αντικείμενα αποτελεσματικών δεδομένων ενδέχεται να αποθηκεύονται στην μνήμη. Μια επόμενη κλήση της `getEffective` μπορεί να επανυπολογίσει τη μορφοποίηση και να ανανεώσει τα αποθηκευμένα δεδομένα, έτσι ώστε ένα αντικείμενο που ελήφθη προηγουμένως να μην θεωρείται μόνιμο στιγμιότυπο.

**Πότε πρέπει να διαβάζω ξανά τις αποτελεσματικές ιδιότητες;**

Καλέστε ξανά τη `getEffective` μετά από αλλαγή της τοπικής μορφοποίησης, των στυλ γονέα, της μορφοποίησης διάταξης, της μορφοποίησης κύριας διαφάνειας ή των προεπιλογών επιπέδου παρουσίασης. Η επόμενη κλήση επαναξιολογεί την ιεραρχία μορφοποίησης και επιστρέφει το τρέχον αποτελεσματικό αποτέλεσμα.

**Επηρεάζει η αλλαγή ή η κατάργηση μιας διαφάνειας διάταξης/κύριας τις αποτελεσματικές ιδιότητες που έχουν ήδη ανακτηθεί;**

Ναι, αλλά η αλλαγή αντικατοπτρίζεται στην επόμενη κλήση της `getEffective`. Εάν αλλάξει ή αφαιρεθεί μια πηγή γονικής μορφοποίησης, τα προηγουμένως αποκτημένα αποτελεσματικά δεδομένα μπορεί να είναι εκτός ισχύος. Μόλις κληθεί ξανά η `getEffective`, το Aspose.Slides επαναξιολογεί το δέντρο μορφοποίησης και οι προκύπτοντες γραμματοσειρές, χρώματα, μεγέθη ή άλλες τιμές ενδέχεται να αλλάξουν.

**Μπορώ να τροποποιήσω τιμές μέσω των αντικειμένων αποτελεσματικών δεδομένων;**

Όχι. Τα αντικείμενα αποτελεσματικών δεδομένων εκθέτουν τις υπολογισμένες τιμές. Κάντε αλλαγές στα τοπικά αντικείμενα μορφοποίησης και, στη συνέχεια, λάβετε ξανά τις αποτελεσματικές τιμές.

**Τι συμβαίνει αν μια ιδιότητα δεν οριστεί στο επίπεδο του σχήματος, ούτε στη διάταξη/κύρια, ούτε στις παγκόσμιες ρυθμίσεις;**

Η αποτελεσματική τιμή καθορίζεται από τον μηχανισμό προεπιλογής, ο οποίος περιλαμβάνει τις προεπιλογές του PowerPoint και του Aspose.Slides. Η τιμή που προκύπτει γίνεται μέρος των τρεχουσών αποτελεσματικών δεδομένων.

**Από μια αποτελεσματική τιμή γραμματοσειράς, μπορώ να προσδιορίσω από ποιο επίπεδο προήλθε το μέγεθος ή το στυλ;**

Όχι άμεσα. Τα αποτελεσματικά δεδομένα επιστρέφουν την τελική τιμή. Για να βρείτε την πηγή, ελέγξτε τις τοπικές τιμές στο τμήμα, την παράγραφο, το πλαίσιο κειμένου και τα στυλ κειμένου στην διάταξη, την κύρια διαφάνεια και το επίπεδο παρουσίασης, ώστε να εντοπίσετε πού εμφανίζεται ο πρώτος ρητός ορισμός.

**Γιατί μερικές φορές οι αποτελεσματικές τιμές μοιάζουν με τις τοπικές;**

Διότι η τοπική τιμή αποδείχτηκε τελική (δεν απαιτήθηκε κληρονομικότητα από υψηλότερο επίπεδο). Σε αυτές τις περιπτώσεις, η αποτελεσματική τιμή συμπίπτει με την τοπική.

**Πότε πρέπει να χρησιμοποιώ αποτελεσματικές ιδιότητες και πότε να εργάζομαι μόνο με τις τοπικές;**

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα όταν χρειάζεστε το αποτέλεσμα "όπως αποδίδεται" μετά την εφαρμογή όλης της κληρονομικότητας, π.χ. για το συντονισμό χρωμάτων, εσοχών ή μεγεθών. Εάν πρέπει να διατηρήσετε αυτές τις τιμές ανεξάρτητα από μελλοντικές αλλαγές μορφοποίησης, αντιγράψτε τις απαιτούμενες ιδιότητες σε δικό σας αντικείμενο. Εάν πρέπει να αλλάξετε τη μορφοποίηση σε συγκεκριμένο επίπεδο, τροποποιήστε τις τοπικές ιδιότητες και, εάν χρειάζεται, διαβάστε ξανά τα αποτελεσματικά δεδομένα για να επαληθεύσετε το αποτέλεσμα.