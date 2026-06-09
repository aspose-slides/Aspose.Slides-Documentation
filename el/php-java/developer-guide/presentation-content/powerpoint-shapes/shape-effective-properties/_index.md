---
title: Λήψη αποτελεσματικών ιδιοτήτων σχήματος από παρουσιάσεις σε PHP
linktitle: Αποτελεσματικές Ιδιότητες
type: docs
weight: 50
url: /el/php-java/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- σύστημα φωτισμού
- σχήμα λοξής τομής
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Ανακαλύψτε πώς το Aspose.Slides για PHP μέσω Java υπολογίζει και εφαρμόζει τις αποτελεσματικές ιδιότητες σχήματος για ακριβή απόδοση PowerPoint."
---
## **Επισκόπηση**

Αυτό το θέμα εξηγεί τη διαφορά μεταξύ ιδιοτήτων **local** και **effective**. Οι τοπικές τιμές είναι τιμές που ορίζονται άμεσα σε ένα συγκεκριμένο επίπεδο μορφοποίησης, όπως:

1. Ιδιότητες τμήματος (portion) σε μια διαφάνεια.  
1. Πρότυπο στυλ κειμένου σχήματος σε μια διάταξη ή κύρια διαφάνεια, όταν το σχήμα του πλαισίου κειμένου του τμήματος το διαθέτει.  
1. Καθολικές ρυθμίσεις κειμένου σε μια παρουσίαση.

Οι τοπικές τιμές μπορούν να οριστούν ή να παραλειφθούν σε οποιοδήποτε επίπεδο. Όταν το Aspose.Slides χρειάζεται την τελική μορφοποίηση «όπως αποδίδεται», λύνει την αλυσίδα κληρονομικότητας και επιστρέφει τις τιμές **effective**. Μπορείτε να τις λάβετε καλώντας τη μέθοδο `getEffective` στο τοπικό αντικείμενο μορφοποίησης.

Το παρακάτω παράδειγμα δείχνει πώς να λάβετε τις αποτελεσματικές τιμές. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) με πλαίσιο κειμένου και τουλάχιστον ένα τμήμα.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Τα δεδομένα αποτελεσματικής μορφοποίησης αντιπροσωπεύουν τη τρέχουσα υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας. Στην τρέχουσα υλοποίηση, ορισμένα αντικείμενα αποτελεσματικών δεδομένων που επιστρέφονται από μεθόδους όπως [PortionFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/portionformat/geteffective/) μπορεί να αποθηκεύονται προσωρινά εσωτερικά. Η επανάκληση του `getEffective` μετά την αλλαγή της γονικής ή κληρονομημένης μορφοποίησης μπορεί να ανανεώσει τα αποθηκευμένα δεδομένα, και ένα αντικείμενο που είχε ληφθεί προηγουμένως μπορεί να μην αντιπροσωπεύει πλέον την προηγούμενη κατάσταση. Εάν χρειάζεται να διατηρήσετε αποτελεσματικές τιμές για μελλοντική επαναχρήση, αντιγράψτε τις απαιτούμενες ιδιότητες, όπως το ύψος γραμματοσειράς, το χρώμα γεμίσματος, το στυλ γραμματοσειράς ή την στοίχιση, στο δικό σας αντικείμενο δεδομένων.
{{% /alert %}}

## **Λήψη αποτελεσματικών ιδιοτήτων κάμερας**

Το Aspose.Slides επιτρέπει τη λήψη αποτελεσματικών ιδιοτήτων μιας κάμερας. Τα αποτελεσματικά δεδομένα που επιστρέφει η [ThreeDFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/geteffective/) περιέχουν τις τελικές ιδιότητες της κάμερας για ένα [ThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για την κάμερα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια διαθέτει 3D μορφοποίηση.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Λήψη αποτελεσματικών ιδιοτήτων Light Rig**

Το Aspose.Slides επιτρέπει τη λήψη αποτελεσματικών ιδιοτήτων ενός Light Rig. Τα αποτελεσματικά δεδομένα που επιστρέφει η [ThreeDFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/geteffective/) περιέχουν τις τελικές ιδιότητες του Light Rig για ένα [ThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για το Light Rig. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια διαθέτει 3D μορφοποίηση.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Λήψη αποτελεσματικών ιδιοτήτων Bevel Shape**

Το Aspose.Slides επιτρέπει τη λήψη αποτελεσματικών ιδιοτήτων ενός Bevel Shape. Τα αποτελεσματικά δεδομένα που επιστρέφει η [ThreeDFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/geteffective/) περιέχουν τις τελικές ιδιότητες ανάγλυφου για ένα [ThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για το άνω Bevel ενός σχήματος. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια διαθέτει 3D μορφοποίηση.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Λήψη αποτελεσματικών ιδιοτήτων πλαισίου κειμένου**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε αποτελεσματικές ιδιότητες ενός πλαισίου κειμένου. Τα αποτελεσματικά δεδομένα που επιστρέφει η [TextFrameFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/geteffective/) περιέχουν τις ιδιότητες μορφοποίησης του πλαισίου κειμένου.

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες μορφοποίησης πλαισίου κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) με πλαίσιο κειμένου.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Λήψη αποτελεσματικών ιδιοτήτων στυλ κειμένου**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε αποτελεσματικές ιδιότητες ενός στυλ κειμένου. Τα αποτελεσματικά δεδομένα που επιστρέφει η [TextStyle.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/textstyle/geteffective/) περιέχουν τις ιδιότητες του στυλ κειμένου.

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες στυλ κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) με πλαίσιο κειμένου.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Λήψη της αποτελεσματικής τιμής ύψους γραμματοσειράς**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε το αποτελεσματικό ύψος γραμματοσειράς. Ο παρακάτω κώδικας δείχνει πώς το αποτελεσματικό ύψος γραμματοσειράς ενός τμήματος αλλάζει μετά την ορισμό τοπικών τιμών ύψους σε διαφορετικά επίπεδα δομής της παρουσίασης.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Λήψη αποτελεσματικού Fill Format για πίνακα**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να λάβετε αποτελεσματική μορφή γεμίσματος για διαφορετικά τμήματα πίνακα. Τα αποτελεσματικά δεδομένα που επιστρέφονται από τα αντικείμενα μορφοποίησης περιέχουν ιδιότητες του [FillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/fillformat/). Η μορφοποίηση κελιού έχει προτεραιότητα έναντι της μορφοποίησης γραμμής, η μορφοποίηση γραμμής έναντι της μορφοποίησης στήλης, και η μορφοποίηση στήλης έναντι της μορφοποίησης ολόκληρου του πίνακα.

Ως αποτέλεσμα, οι αποτελεσματικές ιδιότητες του [CellFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/cellformat/) χρησιμοποιούνται για τη σχεδίαση του κελιού του πίνακα. Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε αποτελεσματική μορφή γεμίσματος για διαφορετικά τμήματα του πίνακα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/table/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Επιστρέφει η `getEffective` ένα στιγμιότυπο;**

Όχι πάντα. Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τη υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας, αλλά ορισμένα αντικείμενα αποτελεσματικών δεδομένων μπορεί να αποθηκεύονται προσωρινά εσωτερικά. Μια επόμενη κλήση του `getEffective` μπορεί να επαναϋπολογίσει τη μορφοποίηση και να ανανεώσει τα αποθηκευμένα δεδομένα, επομένως ένα αντικείμενο που είχε ληφθεί προηγουμένως δεν πρέπει να θεωρείται ως διαρκές στιγμιότυπο.

**Πότε πρέπει να διαβάζω ξανά τις αποτελεσματικές ιδιότητες;**

Καλέστε ξανά το `getEffective` μετά την αλλαγή της τοπικής μορφοποίησης, των γονικών στυλ, της μορφοποίησης της διάταξης, της μορφοποίησης του κύριου σχήματος ή των προεπιλογών σε επίπεδο παρουσίασης. Η επόμενη κλήση επανεκτιμά την ιεραρχία μορφοποίησης και επιστρέφει το τρέχον αποτελεσματικό αποτέλεσμα.

**Επηρεάζει η αλλαγή ή η αφαίρεση μιας διάταξης/κύριας διαφάνειας τις αποτελεσματικές ιδιότητες που έχουν ήδη ανακτηθεί;**

Ναι, αλλά η αλλαγή θα φαίνεται στην επόμενη κλήση του `getEffective`. Εάν αλλάξει ή αφαιρεθεί μια πηγή γονικής μορφοποίησης, τα προηγούμενα αποτελεσματικά δεδομένα μπορεί να είναι ξεπερασμένα. Όταν κληθεί ξανά το `getEffective`, το Aspose.Slides επανεκτιμά το δέντρο μορφοποίησης και οι προκύπτουσες γραμματοσειρές, χρώματα, μεγέθη ή άλλες τιμές μπορεί να αλλάξουν.

**Μπορώ να τροποποιήσω τιμές μέσω των αντικειμένων αποτελεσματικών δεδομένων;**

Όχι. Τα αντικείμενα αποτελεσματικών δεδομένων εκθέτουν μόνο τις υπολογισμένες τιμές. Κάντε αλλαγές στα τοπικά αντικείμενα μορφοποίησης και, στη συνέχεια, λάβετε πάλι τις αποτελεσματικές τιμές.

**Τι συμβαίνει εάν μια ιδιότητα δεν έχει οριστεί στο επίπεδο σχήματος, ούτε στη διάταξη/κύριο, ούτε στις καθολικές ρυθμίσεις;**

Η αποτελεσματική τιμή καθορίζεται από τον μηχανισμό προεπιλογής, που περιλαμβάνει τις προεπιλογές του PowerPoint και του Aspose.Slides. Η τιμή που προκύπτει γίνεται μέρος των τρεχόντων αποτελεσματικών δεδομένων.

**Από μια αποτελεσματική τιμή γραμματοσειράς, μπορώ να καταλάβω ποιο επίπεδο παρείχε το μέγεθος ή το όνομα γραμματοσειράς;**

Όχι άμεσα. Τα αποτελεσματικά δεδομένα επιστρέφουν τη τελική τιμή. Για να βρείτε την πηγή, ελέγξτε τις τοπικές τιμές στο τμήμα, την παράγραφο, το πλαίσιο κειμένου και τα στυλ κειμένου στη διάταξη, το κύριο και το επίπεδο παρουσίασης, ώστε να εντοπίσετε πού εμφανίζεται η πρώτη ρητή οριστική τιμή.

**Γιατί μερικές φορές οι αποτελεσματικές τιμές φαίνονται ίδιες με τις τοπικές;**

Επειδή η τοπική τιμή έγινε τελική (δεν απαιτήθηκε κληρονομική τιμή από ανώτερο επίπεδο). Σε τέτοιες περιπτώσεις, η αποτελεσματική τιμή ταιριάζει με την τοπική.

**Πότε πρέπει να χρησιμοποιώ αποτελεσματικές ιδιότητες και πότε να δουλεύω μόνο με τις τοπικές;**

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα όταν χρειάζεστε το αποτέλεσμα «όπως αποδίδεται» μετά την εφαρμογή όλων των κληρονομιάς, π.χ. για να ευθυγραμμίσετε χρώματα, εσοχές ή μεγέθη. Εάν θέλετε να διατηρήσετε αυτές τις τιμές ανεξάρτητα από μελλοντικές αλλαγές μορφοποίησης, αντιγράψτε τις απαιτούμενες ιδιότητες σε δικό σας αντικείμενο. Εάν χρειάζεται να αλλάξετε τη μορφοποίηση σε συγκεκριμένο επίπεδο, τροποποιήστε τις τοπικές ιδιότητες και, αν χρειάζεται, διαβάστε ξανά τα αποτελεσματικά δεδομένα για να επαληθεύσετε το αποτέλεσμα.