---
title: Λήψη αποτελεσματικών ιδιοτήτων σχήματος από παρουσιάσεις στο Android
linktitle: Αποτελεσματικές ιδιότητες
type: docs
weight: 50
url: /el/androidjava/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- εξοπλισμός φωτισμού
- κλίση σχήματος
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφότυπο γεμίσματος
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
1. Πρωτότυπα στυλ κειμένου σχήματος σε διάταξη ή κύρια διαφάνεια, όταν το σχήμα πλαισίου κειμένου του τμήματος έχει ένα.
1. Καθολικές ρυθμίσεις κειμένου σε μια παρουσίαση.

Οι τοπικές τιμές μπορούν να οριστούν ή να παραλειφθούν σε οποιοδήποτε επίπεδο. Όταν το Aspose.Slides χρειάζεται τη τελική μορφοποίηση «όπως αποδίδεται», επιλύει την αλυσίδα κληρονομιάς και επιστρέφει **αποτελεσματικές** τιμές. Μπορείτε να τις λάβετε καλώντας τη μέθοδο `getEffective()` στο αντικείμενο τοπικής μορφής.

Το παρακάτω παράδειγμα δείχνει πώς να λάβετε αποτελεσματικές τιμές. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) με πλαίσιο κειμένου και τουλάχιστον ένα τμήμα.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
Τα δεδομένα αποτελεσματικής μορφοποίησης αντιπροσωπεύουν τη τρέχουσα υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομιάς. Στην τρέχουσα υλοποίηση, ορισμένα αντικείμενα αποτελεσματικών δεδομένων, όπως το [IPortionFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportionformateffectivedata/), μπορεί να αποθηκεύονται στην μνήμη. Η κλήση του `getEffective()` ξανά μετά την αλλαγή της γονικής ή κληρονομισμένης μορφοποίησης μπορεί να ανανεώσει τα αποθηκευμένα δεδομένα, και ένα αντικείμενο που έχει ληφθεί προηγουμένως μπορεί να μην αντιπροσωπεύει πλέον την προηγούμενη κατάσταση. Εάν χρειάζεται να διατηρήσετε τις αποτελεσματικές τιμές για μελλοντική χρήση, αντιγράψτε τις απαιτούμενες ιδιότητες, όπως το ύψος γραμματοσειράς, το χρώμα γεμίσματος, το στυλ γραμματοσειράς ή την στοίχηση, στο δικό σας αντικείμενο δεδομένων.
{{% /alert %}}

## **Λήψη αποτελεσματικών ιδιοτήτων κάμερας**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες μιας κάμερας. Η διεπαφή [ICameraEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icameraeffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει τις αποτελεσματικές ιδιότητες της κάμερας. Μια παρουσία του [ICameraEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icameraeffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/).

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για την κάμερα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3Δ μορφοποίηση.

```java
import com.aspose.slides.*;

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

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες ενός εξοπλισμού φωτισμού. Η διεπαφή [ILightRigEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilightrigeffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει τις αποτελεσματικές ιδιότητες του εξοπλισμού φωτισμού. Μια παρουσία του [ILightRigEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ilightrigeffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/).

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για τον εξοπλισμό φωτισμού. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3Δ μορφοποίηση.

```java
import com.aspose.slides.*;

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

## **Λήψη αποτελεσματικών ιδιοτήτων κλίσης σχήματος**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες μιας κλίσης σχήματος. Η διεπαφή [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapebeveleffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει τις αποτελεσματικές ιδιότητες ανάγλυφου για ένα σχήμα. Μια παρουσία του [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapebeveleffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/).

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για την άνω κλίση ενός σχήματος. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3Δ μορφοποίηση.

```java
import com.aspose.slides.*;

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

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε τις αποτελεσματικές ιδιότητες ενός πλαισίου κειμένου. Η διεπαφή [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformateffectivedata/) περιέχει τις ιδιότητες αποτελεσματικής μορφοποίησης πλαισίου κειμένου.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να λάβετε τις ιδιότητες αποτελεσματικής μορφοποίησης πλαισίου κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) με πλαίσιο κειμένου.

```java
import com.aspose.slides.*;

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

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε τις αποτελεσματικές ιδιότητες ενός στυλ κειμένου. Η διεπαφή [ITextStyleEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextstyleeffectivedata/) περιέχει τις ιδιότητες αποτελεσματικού στυλ κειμένου.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να λάβετε τις ιδιότητες αποτελεσματικού στυλ κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) με πλαίσιο κειμένου.

```java
import com.aspose.slides.*;

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

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε το αποτελεσματικό ύψος γραμματοσειράς. Ο παρακάτω κώδικας δείχνει πώς το αποτελεσματικό ύψος γραμματοσειράς ενός τμήματος αλλάζει μετά τον ορισμό τοπικών τιμών ύψους γραμματοσειράς σε διαφορετικά επίπεδα δομής παρουσίασης.

```java
import com.aspose.slides.*;

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

## **Λήψη αποτελεσματικού φορμάτ γεμίσματος για πίνακα**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε αποτελεσματική μορφοποίηση γεμίσματος για διαφορετικά μέρη πίνακα. Η διεπαφή [IFillFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifillformateffectivedata/) περιέχει τις ιδιότητες αποτελεσματικής μορφοποίησης γεμίσματος. Η μορφοποίηση κελιού έχει υψηλότερη προτεραιότητα από τη μορφοποίηση γραμμής, η μορφοποίηση γραμμής έχει υψηλότερη προτεραιότητα από τη μορφοποίηση στήλης, και η μορφοποίηση στήλης έχει υψηλότερη προτεραιότητα από τη μορφοποίηση ολόκληρου του πίνακα.

Ως αποτέλεσμα, χρησιμοποιούνται οι ιδιότητες του [ICellFormatEffectiveData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icellformateffectivedata/) για τη σχεδίαση του κελιού του πίνακα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να λάβετε αποτελεσματική μορφοποίηση γεμίσματος για διαφορετικά μέρη πίνακα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [ITable](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itable/).

```java
import com.aspose.slides.*;

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

## **Συχνές ερωτήσεις**

### Επιστρέφει η `getEffective()` ένα στιγμιότυπο;

Όχι πάντα. Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τη μορφοποίηση που υπολογίζεται μετά την εφαρμογή της κληρονομιάς, αλλά ορισμένα αντικείμενα αποτελεσματικών δεδομένων ενδέχεται να αποθηκεύονται προσωρινά εσωτερικά. Μια επακόλουθη κλήση της `getEffective()` μπορεί να επαναϋπολογίσει τη μορφοποίηση και να ανανεώσει τα αποθηκευμένα δεδομένα, οπότε ένα αντικείμενο που έχει ληφθεί προηγουμένως δεν πρέπει να θεωρηθεί ως μόνιμο στιγμιότυπο.

### Πότε πρέπει να διαβάσω ξανά τις αποτελεσματικές ιδιότητες;

Καλείτε τη `getEffective()` ξανά μετά την αλλαγή της τοπικής μορφοποίησης, των γονικών στυλ, της μορφοποίησης της διάταξης, της μορφοποίησης του κύριου ή των προεπιλογών σε επίπεδο παρουσίασης. Η επόμενη κλήση επανεξετάζει τη ιεραρχία μορφοποίησης και επιστρέφει το τρέχον αποτελεσματικό αποτέλεσμα.

### Επηρεάζει η αλλαγή ή η αφαίρεση μιας διάταξης/κύριας διαφάνειας τις αποτελεσματικές ιδιότητες που έχουν ήδη ληφθεί;

Ναι, αλλά η αλλαγή αντικατοπτρίζεται στην επόμενη κλήση της `getEffective()`. Εάν η γονική πηγή μορφοποίησης αλλάξει ή αφαιρεθεί, τα αποτελεσματικά δεδομένα που έχουν ληφθεί νωρίτερα μπορεί να είναι παλιά. Μόλις κληθεί ξανά η `getEffective()`, το Aspose.Slides επανεξετάζει το δέντρο μορφοποίησης και οι προκύπτουσες γραμματοσειρές, χρώματα, μεγέθη ή άλλες τιμές μπορεί να αλλάξουν.

### Μπορώ να τροποποιήσω τιμές μέσω αντικειμένων αποτελεσματικών δεδομένων;

Όχι. Τα αντικείμενα αποτελεσματικών δεδομένων εκθέτουν τις υπολογισμένες τιμές. Κάντε τις αλλαγές στα τοπικά αντικείμενα μορφοποίησης και, στη συνέχεια, λάβετε ξανά τις αποτελεσματικές τιμές.

### Τι συμβαίνει αν μια ιδιότητα δεν ορίζεται στο επίπεδο του σχήματος, ούτε στη διάταξη/κύρια, ούτε στις καθολικές ρυθμίσεις;

Η αποτελεσματική τιμή προσδιορίζεται από τον προεπιλεγμένο μηχανισμό, που περιλαμβάνει τις προεπιλογές του PowerPoint και του Aspose.Slides. Η λυθείσα τιμή γίνεται μέρος των τρεχόντων αποτελεσματικών δεδομένων.

### Από μια αποτελεσματική τιμή γραμματοσειράς, μπορώ να προσδιορίσω ποιο επίπεδο παρείχε το μέγεθος ή το τύπο γραμματοσειράς;

Όχι άμεσα. Τα αποτελεσματικά δεδομένα επιστρέφουν την τελική τιμή. Για να βρείτε την πηγή, ελέγξτε τις τοπικές τιμές στο τμήμα, στην παράγραφο, στο πλαίσιο κειμένου και στα στυλ κειμένου στην διάταξη, στο κύριο και σε επίπεδο παρουσίασης για να δείτε πού εμφανίζεται ο πρώτος ρητός ορισμός.

### Γιατί οι αποτελεσματικές τιμές μερικές φορές μοιάζουν με τις τοπικές;

Επειδή η τοπική τιμή αποδείχθηκε τελική (δεν απαιτήθηκε κληρονομιά από υψηλότερο επίπεδο). Σε τέτοιες περιπτώσεις, η αποτελεσματική τιμή ταιριάζει με την τοπική.

### Πότε πρέπει να χρησιμοποιώ αποτελεσματικές ιδιότητες και πότε να δουλεύω μόνο με τοπικές;

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα όταν χρειάζεστε το αποτέλεσμα «όπως αποδίδεται» αφού εφαρμοστεί όλη η κληρονομιά, π.χ. για την ευθυγράμμιση χρωμάτων, εσοχών ή μεγεθών. Εάν χρειάζεται να διατηρήσετε αυτές τις τιμές ανεξάρτητα από μελλοντικές αλλαγές μορφοποίησης, αντιγράψτε τις απαιτούμενες ιδιότητες σε δικό σας αντικείμενο. Εάν πρέπει να αλλάξετε τη μορφοποίηση σε συγκεκριμένο επίπεδο, τροποποιήστε τις τοπικές ιδιότητες και, εφόσον χρειαστεί, διαβάστε ξανά τα αποτελεσματικά δεδομένα για να επαληθεύσετε το αποτέλεσμα.