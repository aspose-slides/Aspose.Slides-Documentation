---
title: "Απόκτηση αποτελεσματικών ιδιοτήτων σχήματος από παρουσιάσεις στο Android"
linktitle: "Αποτελεσματικές Ιδιότητες"
type: docs
weight: 50
url: /el/androidjava/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- εξοπλισμός φωτισμού
- σχήμα bevel
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς το Aspose.Slides για Android μέσω Java υπολογίζει και εφαρμόζει τις αποτελεσματικές ιδιότητες σχήματος για ακριβή απόδοση PowerPoint."
---
## **Επισκόπηση**

Αυτό το θέμα εξηγεί τη διαφορά μεταξύ **τοπικών** και **αποτελεσματικών** ιδιοτήτων. Οι τοπικές τιμές είναι τιμές που ορίζονται άμεσα σε ένα συγκεκριμένο επίπεδο μορφοποίησης, όπως:

1. Ιδιότητες τμήματος σε μια διαφάνεια.  
1. Προκαθορισμένα στυλ κειμένου σχήματος σε διάταξη ή κύρια διαφάνεια, όταν το σχήμα πλαισίου κειμένου του τμήματος έχει ένα.  
1. Καθολικές ρυθμίσεις κειμένου σε μια παρουσίαση.

Οι τοπικές τιμές μπορούν να οριστούν ή να παραλειφθούν σε οποιοδήποτε επίπεδο. Όταν το Aspose.Slides χρειάζεται την τελική μορφοποίηση «όπως αποδίδεται», επιλύει την αλυσίδα κληρονομικότητας και επιστρέφει **αποτελεσματικές** τιμές. Μπορείτε να τις λάβετε καλώντας τη μέθοδο `getEffective()` στο τοπικό αντικείμενο μορφοποίησης.

Το παρακάτω παράδειγμα δείχνει πώς να λάβετε αποτελεσματικές τιμές. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) με πλαίσιο κειμένου και τουλάχιστον ένα τμήμα.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Τα δεδομένα αποτελεσματικής μορφοποίησης αντιπροσωπεύουν την τρέχουσα υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας. Στην τρέχουσα υλοποίηση, κάποια αντικείμενα αποτελεσματικών δεδομένων, όπως το [IPortionFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportionformateffectivedata/), μπορεί να αποθηκεύονται προσωρινά εσωτερικά. Η επανάκληση του `getEffective()` μετά από αλλαγή της γονικής ή κληρονομημένης μορφοποίησης μπορεί να ανανεώσει τα προσωρινά δεδομένα, και ένα αντικείμενο που είχε ληφθεί προηγουμένως μπορεί να μην αντιπροσωπεύει πλέον την προηγούμενη κατάσταση. Εάν χρειάζεται να διατηρήσετε τις αποτελεσματικές τιμές για μελλοντική χρήση, αντιγράψτε τις απαιτούμενες ιδιότητες, όπως το ύψος γραμματοσειράς, το χρώμα γεμίσματος, το στυλ γραμματοσειράς ή την στοίχιση, σε δικό σας αντικείμενο δεδομένων.
{{% /alert %}}

## **Λήψη αποτελεσματικών ιδιοτήτων κάμερας**

Το Aspose.Slides σας επιτρέπει να λάβετε αποτελεσματικές ιδιότητες μιας κάμερας. Η διεπαφή [ICameraEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icameraeffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες κάμερας. Μια παρουσίαση της [ICameraEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icameraeffectivedata/) εκτίθεται μέσω της [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformateffectivedata/), η οποία παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε αποτελεσματικές ιδιότητες για την κάμερα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3D μορφοποίηση.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Λήψη αποτελεσματικών ιδιοτήτων εξοπλισμού φωτισμού**

Το Aspose.Slides σας επιτρέπει να λάβετε αποτελεσματικές ιδιότητες ενός εξοπλισμού φωτισμού. Η διεπαφή [ILightRigEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilightrigeffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες φωτισμού. Μια παρουσίαση της [ILightRigEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilightrigeffectivedata/) εκτίθεται μέσω της [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformateffectivedata/), η οποία παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε αποτελεσματικές ιδιότητες για τον εξοπλισμό φωτισμού. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3D μορφοποίηση.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Λήψη αποτελεσματικών ιδιοτήτων σχήματος bevel**

Το Aspose.Slides σας επιτρέπει να λάβετε αποτελεσματικές ιδιότητες ενός σχήματος bevel. Η διεπαφή [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapebeveleffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες ανάγλυφου για ένα σχήμα. Μια παρουσίαση της [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapebeveleffectivedata/) εκτίθεται μέσω της [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformateffectivedata/), η οποία παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε αποτελεσματικές ιδιότητες για το επάνω bevel ενός σχήματος. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3D μορφοποίηση.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Λήψη αποτελεσματικών ιδιοτήτων πλαισίου κειμένου**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε αποτελεσματικές ιδιότητες ενός πλαισίου κειμένου. Η διεπαφή [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformateffectivedata/) περιέχει αποτελεσματικές ιδιότητες μορφοποίησης πλαισίου κειμένου.

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε αποτελεσματικές ιδιότητες μορφοποίησης πλαισίου κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) με πλαίσιο κειμένου.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **Λήψη αποτελεσματικών ιδιοτήτων στυλ κειμένου**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε αποτελεσματικές ιδιότητες ενός στυλ κειμένου. Η διεπαφή [ITextStyleEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextstyleeffectivedata/) περιέχει αποτελεσματικές ιδιότητες στυλ κειμένου.

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε αποτελεσματικές ιδιότητες στυλ κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) με πλαίσιο κειμένου.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **Λήψη της αποτελεσματικής τιμής ύψους γραμματοσειράς**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε το αποτελεσματικό ύψος γραμματοσειράς. Το παρακάτω δείγμα κώδικα δείχνει πώς το αποτελεσματικό ύψος γραμματοσειράς ενός τμήματος αλλάζει μετά από ορισμό τοπικών τιμών ύψους γραμματοσειράς σε διαφορετικά επίπεδα δομής της παρουσίασης.

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

## **Λήψη του αποτελεσματικού μορφότυπου γεμίσματος για πίνακα**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε αποτελεσματική μορφοποίηση γεμίσματος για διαφορετικά τμήματα πίνακα. Η διεπαφή [IFillFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifillformateffectivedata/) περιέχει αποτελεσματικές ιδιότητες μορφοποίησης γεμίσματος. Η μορφοποίηση κελιού έχει υψηλότερη προτεραιότητα από τη μορφοποίηση γραμμής, η μορφοποίηση γραμμής έχει υψηλότερη προτεραιότητα από τη μορφοποίηση στήλης, και η μορφοποίηση στήλης έχει υψηλότερη προτεραιότητα από τη μορφοποίηση ολόκληρου του πίνακα.

Ως αποτέλεσμα, χρησιμοποιούνται οι ιδιότητες του [ICellFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icellformateffectivedata/) για την απόδοση του κελιού του πίνακα. Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε αποτελεσματική μορφοποίηση γεμίσματος για διαφορετικά τμήματα πίνακα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itable/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Επιστρέφει η `getEffective()` ένα στιγμιότυπο;**

Δεν πάντα. Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τη υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας, αλλά ορισμένα αντικείμενα αποτελεσματικών δεδομένων μπορεί να αποθηκεύονται προσωρινά εσωτερικά. Μια επακόλουθη κλήση του `getEffective()` μπορεί να επαναϋπολογίσει τη μορφοποίηση και να ανανεώσει τα προσωρινά δεδομένα, έτσι ένα αντικείμενο που είχε ληφθεί προηγουμένως δεν πρέπει να θεωρείται ανθεκτικό στιγμιότυπο.

**Πότε πρέπει να διαβάζω ξανά τις αποτελεσματικές ιδιότητες;**

Καλέστε ξανά το `getEffective()` μετά από αλλαγή τοπικής μορφοποίησης, γονικών στυλ, μορφοποίησης διάταξης, μορφοποίησης κύριου σχήματος ή προεπιλογών σε επίπεδο παρουσίασης. Η επόμενη κλήση επανεξετάζει τη ιεραρχία μορφοποίησης και επιστρέφει το τρέχον αποτελεσματικό αποτέλεσμα.

**Αλλάζει η αλλαγή ή η αφαίρεση μιας διαφάνειας διάταξης/κύριας τις αποτελεσματικές ιδιότητες που έχουν ήδη ληφθεί;**

Ναι, αλλά η αλλαγή αντικατοπτρίζεται στην επόμενη κλήση του `getEffective()`. Εάν αλλάξει ή αφαιρεθεί μια πηγή γονικής μορφοποίησης, τα προηγουμένως ληφθέντα αποτελεσματικά δεδομένα μπορεί να είναι παλιά. Μόλις κληθεί ξανά το `getEffective()`, το Aspose.Slides επανεξετάζει το δένδρο μορφοποίησης και οι προκύπτουσες γραμματοσειρές, χρώματα, μεγέθη ή άλλες τιμές μπορεί να αλλάξουν.

**Μπορώ να τροποποιήσω τιμές μέσω των αντικειμένων αποτελεσματικών δεδομένων;**

Όχι. Τα αντικείμενα αποτελεσματικών δεδομένων εκθέτουν υπολογισμένες τιμές. Κάντε αλλαγές στα τοπικά αντικείμενα μορφοποίησης και, στη συνέχεια, λάβετε ξανά τις αποτελεσματικές τιμές.

**Τι συμβαίνει αν μια ιδιότητα δεν οριστεί στο επίπεδο του σχήματος, ούτε στη διάταξη/κύρια, ούτε στις καθολικές ρυθμίσεις;**

Η αποτελεσματική τιμή καθορίζεται από τον μηχανισμό προεπιλογής, που περιλαμβάνει τις προεπιλογές του PowerPoint και του Aspose.Slides. Η τιμή που προκύπτει γίνεται μέρος των τρεχόντων αποτελεσματικών δεδομένων.

**Από μια αποτελεσματική τιμή γραμματοσειράς, μπορώ να προσδιορίσω ποιο επίπεδο παρείχε το μέγεθος ή το τύπο γραμματοσειράς;**

Όχι άμεσα. Τα αποτελεσματικά δεδομένα επιστρέφουν την τελική τιμή. Για να βρείτε την πηγή, ελέγξτε τις τοπικές τιμές στο τμήμα, την παράγραφο, το πλαίσιο κειμένου και τα στυλ κειμένου στη διάταξη, το κύριο σχήμα και το επίπεδο παρουσίασης ώστε να εντοπίσετε πού εμφανίζεται ο πρώτος ρητός ορισμός.

**Γιατί οι αποτελεσματικές τιμές μερικές φορές μοιάζουν με τις τοπικές;**

Επειδή η τοπική τιμή κατέληξε να είναι τελική (δεν απαιτήθηκε κληρονόμηση από υψηλότερο επίπεδο). Σε τέτοιες περιπτώσεις, η αποτελεσματική τιμή ταιριάζει με την τοπική.

**Πότε πρέπει να χρησιμοποιώ αποτελεσματικές ιδιότητες και πότε μόνο τις τοπικές;**

Χρησιμοποιείτε τα αποτελεσματικά δεδομένα όταν χρειάζεστε το αποτέλεσμα «όπως αποδίδεται» μετά από όλα τα επίπεδα κληρονομικότητας, π.χ. για ευθυγράμμιση χρωμάτων, εσοχών ή μεγεθών. Εάν πρέπει να διατηρήσετε αυτές τις τιμές ανεξάρτητα από μεταγενέστερες αλλαγές μορφοποίησης, αντιγράψτε τις απαιτούμενες ιδιότητες σε δικό σας αντικείμενο. Εάν πρέπει να αλλάξετε τη μορφοποίηση σε συγκεκριμένο επίπεδο, τροποποιήστε τις τοπικές ιδιότητες και, εφόσον χρειάζεται, διαβάστε ξανά τα αποτελεσματικά δεδομένα για επαλήθευση του αποτελέσματος.