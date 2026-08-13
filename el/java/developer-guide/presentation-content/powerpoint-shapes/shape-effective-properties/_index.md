---
title: Απόκτηση αποτελεσματικών ιδιοτήτων σχήματος από παρουσιάσεις σε Java
linktitle: Αποτελεσματικές Ιδιότητες
type: docs
weight: 50
url: /el/java/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- σύστημα φωτισμού
- σχήμα λοξής άκρης
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς το Aspose.Slides για Java υπολογίζει και εφαρμόζει τις αποτελεσματικές ιδιότητες σχήματος για ακριβή απόδοση σε PowerPoint."
---
## **Επισκόπηση**

Αυτό το θέμα εξηγεί τη διαφορά μεταξύ **τοπικών** και **αποτελεσματικών** ιδιοτήτων. Οι τοπικές τιμές είναι τιμές που ορίζονται απευθείας σε ένα συγκεκριμένο επίπεδο μορφοποίησης, όπως:

1. Ιδιότητες τμήματος σε μια διαφάνεια.
1. Στυλ κειμένου προτύπου σχήματος σε μια διάταξη ή κύρια διαφάνεια, όταν το σχήμα πλαισίου κειμένου του τμήματος έχει ένα.
1. Καθολικές ρυθμίσεις κειμένου σε μια παρουσίαση.

Οι τοπικές τιμές μπορούν να οριστούν ή να παραλειφθούν σε οποιοδήποτε επίπεδο. Όταν το Aspose.Slides χρειάζεται την τελική μορφοποίηση «όπως παρουσιάζεται», επιλύει την αλυσίδα κληρονομικότητας και επιστρέφει **αποτελεσματικές** τιμές. Μπορείτε να τις λάβετε καλώντας τη μέθοδο `getEffective` στο τοπικό αντικείμενο μορφοποίησης.

Το παρακάτω παράδειγμα δείχνει πώς να λάβετε τις αποτελεσματικές τιμές. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/IAutoShape) με πλαίσιο κειμένου και τουλάχιστον ένα τμήμα.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}Τα δεδομένα αποτελεσματικής μορφοποίησης αντιπροσωπεύουν την τρέχουσα υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας. Στην τρέχουσα υλοποίηση, ορισμένα αντικείμενα αποτελεσματικών δεδομένων, όπως το [IPortionFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPortionFormatEffectiveData), ενδέχεται να αποθηκεύονται στην εσωτερική μνήμη. Η κλήση του `getEffective` ξανά μετά την αλλαγή του γονικού ή κληρονομημένου μορφοποίησης μπορεί να ανανεώσει τα αποθηκευμένα δεδομένα, και ένα προηγουμένως ληφθέν αντικείμενο ενδέχεται να μην αντιπροσωπεύει πλέον την προηγούμενη κατάσταση. Εάν χρειάζεται να διατηρήσετε τις αποτελεσματικές τιμές για μελλοντική χρήση, αντιγράψτε τις απαιτούμενες ιδιότητες, όπως το ύψος γραμματοσειράς, το χρώμα γεμίσματος, το στυλ γραμματοσειράς ή την στοίχιση, σε δικό σας αντικείμενο δεδομένων.{{% /alert %}}

## **Λήψη αποτελεσματικών ιδιοτήτων κάμερας**

Το Aspose.Slides σάς επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες μιας κάμερας. Η διεπαφή [ICameraEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICameraEffectiveData) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες κάμερας. Ένα στιγμιότυπο [ICameraEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICameraEffectiveData) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IThreeDFormatEffectiveData), το οποίο παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/IThreeDFormat).

```java
import com.aspose.slides.*;

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

## **Λήψη αποτελεσματικών ιδιοτήτων φωτιστικού συστήματος**

Το Aspose.Slides σάς επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες ενός φωτιστικού συστήματος. Η διεπαφή [ILightRigEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ILightRigEffectiveData) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες φωτιστικού συστήματος. Ένα στιγμιότυπο [ILightRigEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ILightRigEffectiveData) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IThreeDFormatEffectiveData), το οποίο παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/IThreeDFormat).

```java
import com.aspose.slides.*;

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

## **Λήψη αποτελεσματικών ιδιοτήτων λοξής άκρης σχήματος**

Το Aspose.Slides σάς επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες λοξής άκρης ενός σχήματος. Η διεπαφή [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeBevelEffectiveData) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει αποτελεσματικές ιδιότητες ανάπλασης προσώπου για ένα σχήμα. Ένα στιγμιότυπο [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeBevelEffectiveData) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IThreeDFormatEffectiveData), το οποίο παρέχει αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/IThreeDFormat).

```java
import com.aspose.slides.*;

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

## **Λήψη αποτελεσματικών ιδιοτήτων πλαισίου κειμένου**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε τις αποτελεσματικές ιδιότητες ενός πλαισίου κειμένου. Η διεπαφή [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITextFrameFormatEffectiveData) περιέχει αποτελεσματικές ιδιότητες μορφοποίησης πλαισίου κειμένου.

```java
import com.aspose.slides.*;

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

## **Λήψη αποτελεσματικών ιδιοτήτων στυλ κειμένου**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε τις αποτελεσματικές ιδιότητες ενός στυλ κειμένου. Η διεπαφή [ITextStyleEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITextStyleEffectiveData) περιέχει αποτελεσματικές ιδιότητες στυλ κειμένου.

```java
import com.aspose.slides.*;

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

## **Λήψη της αποτελεσματικής μορφής γεμίσματος για έναν Πίνακα**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε αποτελεσματική μορφή γεμίσματος για διαφορετικά μέρη του πίνακα. Η διεπαφή [IFillFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/IFillFormatEffectiveData) περιέχει αποτελεσματικές ιδιότητες μορφής γεμίσματος. Η μορφοποίηση κελιού έχει προτεραιότητα πάνω από τη μορφοποίηση γραμμής, η μορφοποίηση γραμμής έχει προτεραιότητα πάνω από τη μορφοποίηση στήλης, και η μορφοποίηση στήλης έχει προτεραιότητα πάνω από τη μορφοποίηση ολόκληρου του πίνακα.

Ως αποτέλεσμα, οι ιδιότητες του [ICellFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ICellFormatEffectiveData) χρησιμοποιούνται για την σχεδίαση του κελιού του πίνακα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να λάβετε αποτελεσματική μορφή γεμίσματος για διαφορετικά μέρη του πίνακα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [ITable](https://reference.aspose.com/slides/el/java/com.aspose.slides/ITable).

```java
import com.aspose.slides.*;

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

## **Συχνές ερωτήσεις**

### Επιστρέφει η `getEffective` ένα στιγμιότυπο;

Δεν πάντα. Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας, αλλά ορισμένα αντικείμενα αποτελεσματικών δεδομένων ενδέχεται να αποθηκεύονται στην εσωτερική μνήμη. Μια επακόλουθη κλήση `getEffective` μπορεί να επαναϋπολογίσει τη μορφοποίηση και να ανανεώσει τα αποθηκευμένα δεδομένα, οπότε ένα προηγουμένως ληφθέν αντικείμενο δεν πρέπει να θεωρείται μόνιμο στιγμιότυπο.

### Πότε πρέπει να διαβάζω ξανά τις αποτελεσματικές ιδιότητες;

Καλέστε ξανά τη `getEffective` μετά την αλλαγή τοπικής μορφοποίησης, γονικών στυλ, μορφοποίησης διάταξης, μορφοποίησης κύριου σχήματος ή προεπιλογών επιπέδου παρουσίασης. Η επόμενη κλήση επανεξετάζει την ιεραρχία μορφοποίησης και επιστρέφει το τρέχον αποτελεσματικό αποτέλεσμα.

### Η αλλαγή ή η αφαίρεση μιας διάταξης/κύριου σχήματος επηρεάζει τις αποτελεσματικές ιδιότητες που έχουν ήδη ληφθεί;

Ναι, αλλά η αλλαγή αντικατοπτρίζεται στην επόμενη κλήση `getEffective`. Εάν μια πηγή γονικής μορφοποίησης αλλάξει ή αφαιρεθεί, τα προηγουμένως ληφθέντα αποτελεσματικά δεδομένα μπορεί να γίνουν παλιά. Μόλις κληθεί ξανά η `getEffective`, το Aspose.Slides επανεξετάζει το δέντρο μορφοποίησης και οι τιμές γραμματοσειρών, χρωμάτων, μεγεθών ή άλλων ιδιοτήτων μπορεί να αλλάξουν.

### Μπορώ να τροποποιήσω τιμές μέσω των αντικειμένων αποτελεσματικών δεδομένων;

Όχι. Τα αντικείμενα αποτελεσματικών δεδομένων εκθέτουν υπολογισμένες τιμές. Κάντε αλλαγές στα τοπικά αντικείμενα μορφοποίησης και, στη συνέχεια, λάβετε ξανά τις αποτελεσματικές τιμές.

### Τι συμβαίνει αν μια ιδιότητα δεν έχει οριστεί στο επίπεδο σχήματος, ούτε στη διάταξη/κύριο, ούτε στις καθολικές ρυθμίσεις;

Η αποτελεσματική τιμή καθορίζεται με τον προεπιλεγμένο μηχανισμό, που περιλαμβάνει τις προεπιλογές του PowerPoint και του Aspose.Slides. Η επεξεργασμένη τιμή γίνεται μέρος των τρεχουσών αποτελεσματικών δεδομένων.

### Από μια αποτελεσματική τιμή γραμματοσειράς, μπορώ να καταλάβω ποιο επίπεδο παρείχε το μέγεθος ή την οικογένεια γραμματοσειράς;

Όχι άμεσα. Τα αποτελεσματικά δεδομένα επιστρέφουν τη τελική τιμή. Για να βρείτε την πηγή, ελέγξτε τις τοπικές τιμές στο τμήμα, την παράγραφο, το πλαίσιο κειμένου και τα στυλ κειμένου στη διάταξη, στο κύριο και στο επίπεδο παρουσίασης για να εντοπίσετε πού εμφανίζεται η πρώτη ρητή δήλωση.

### Γιατί οι αποτελεσματικές τιμές μερικές φορές φαίνονται πανομοιότυπες με τις τοπικές;

Επειδή η τοπική τιμή κατέληξε να είναι η τελική (δεν απαιτήθηκε κληρονομικότητα ανώτερου επιπέδου). Σε τέτοιες περιπτώσεις, η αποτελεσματική τιμή ταιριάζει με την τοπική.

### Πότε πρέπει να χρησιμοποιώ αποτελεσματικές ιδιότητες και πότε μόνο τις τοπικές;

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα όταν χρειάζεστε το αποτέλεσμα «όπως παρουσιάζεται» μετά την ολοκλήρωση της κληρονομικότητας, π.χ. για στοίχιση χρωμάτων, εσοχών ή μεγεθών. Εάν χρειάζεται να διατηρήσετε αυτές τις τιμές ανεξάρτητα από μελλοντικές αλλαγές μορφοποίησης, αντιγράψτε τις απαιτούμενες ιδιότητες σε δικό σας αντικείμενο. Αν θέλετε να αλλάξετε τη μορφοποίηση σε συγκεκριμένο επίπεδο, τροποποιήστε τις τοπικές ιδιότητες και, εφόσον είναι απαραίτητο, διαβάστε ξανά τα αποτελεσματικά δεδομένα για επαλήθευση του αποτελέσματος.