---
title: Δημιουργία και Εφαρμογή Εφέ WordArt σε PHP
linktitle: WordArt
type: docs
weight: 110
url: /el/php-java/wordart/
keywords:
- WordArt
- Δημιουργία WordArt
- Πρότυπο WordArt
- Εφέ WordArt
- Εφέ σκιάς
- Εφέ αντανάκλασης
- Εφέ λάμψης
- Μετασχηματισμός WordArt
- 3D εφέ
- Εφέ εξωτερικής σκιάς
- Εφέ εσωτερικής σκιάς
- PHP
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε εφέ WordArt στο Aspose.Slides for PHP via Java. Αυτός ο οδηγός βήμα προς βήμα βοηθά τους προγραμματιστές να βελτιώσουν τις παρουσιάσεις με επαγγελματικό κείμενο σε PHP."
---
## **Επισκόπηση**

Οι εφέ WordArt σάς επιτρέπουν να μορφοποιείτε κείμενο με γεμίσματα, περιγράμματα, σκιές, αντανακλάσεις, λάμψη, μετασχηματισμούς και 3D μορφοποίηση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να προσαρμόσετε αυτά τα εφέ σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides for PHP via Java, χωρίς εγκατεστημένο το Microsoft Office.

## **Δημιουργία ενός Απλού Προτύπου WordArt και Εφαρμογή του σε Κείμενο**

Τα παρακάτω παραδείγματα δημιουργούν ένα απλό στυλ WordArt ορίζοντας το κείμενο, τη γραμματοσειρά, το γεμάτο μοτίβο και το περίγραμμα.

Κάθε παράδειγμα δημιουργεί μια νέα παρουσίαση και προσθέτει ένα ορθογώνιο στην πρώτη της διαφάνεια· δεν απαιτείται αρχείο εισόδου. Το πρώτο παράδειγμα ορίζει το κείμενο σε "Aspose.Slides". Η θέση και οι διαστάσεις του σχήματος μετρώνται σε πόντους:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();

    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
} finally {
    $presentation->dispose();
}
```

Ορίστε τη γραμματοσειρά σε Arial Black στα 36 πόντους για να γίνει η μορφοποίηση πιο εμφανής:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);
} finally {
    $presentation->dispose();
}
```

Εφαρμόστε ένα μοτίβο [SmallGrid](https://reference.aspose.com/slides/el/php-java/aspose.slides/patternstyle/#SmallGrid) με σκούρο πορτοκαλί προσκήνιο και λευκό φόντο, στη συνέχεια προσθέστε μαύρο περίγραμμα κειμένου με πλάτος 1 πόντου:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($darkOrange);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::SmallGrid);

    $portion->getPortionFormat()->getLineFormat()->setWidth(1);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα κειμένου:

![Το απλό πρότυπο WordArt](WordArt_template.png)

## **Εφαρμογή Άλλων Εφέ WordArt**

Τα παρακάτω παραδείγματα δείχνουν πώς να εφαρμόσετε σκιές, αντανακλάσεις, λάμψη, μετασχηματισμούς και 3D εφέ σε κείμενο.

### **Εφαρμογή Εξωτερικών Σκιών**

Μία εξωτερική σκιά προσθέτει βάθος τοποθετώντας μια σκιά πίσω από το κείμενο. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση, την ακτίνα θολώματος, την κλίμακα και την κλίση της.

Αυτό το παράδειγμα καλεί τη μέθοδο [enableOuterShadowEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) και ορίζει μια μαύρη σκιά με ακτίνα θολώματος 4 πόντων, κατεύθυνση 230 μοιρών και απόσταση 30 πόντων. Τιμές κλίμακας 100 διατηρούν το μέγεθος της σκιάς, ενώ η οριζόντια κλίση την κλίνει κατά 20 μοιρά. Η μετατροπή άλφα ορίζει τη διαφάνειά της στο 32%:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(30);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(20);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.32);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα κειμένου:

![Το εφέ της εξωτερικής σκιάς](outer_shadow_effect.png)

{{% alert color="info" title="Σημείωση" %}}
- Όταν χρησιμοποιούνται μαζί εξωτερικές και προεπιλογές σκιές, εφαρμόζεται μόνο η εξωτερική σκιά.
- Εάν χρησιμοποιηθούν ταυτόχρονα εξωτερικές και εσωτερικές σκιές, το αποτέλεσμα εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013 το εφέ διπλασιάζεται, ενώ στο PowerPoint 2007 εφαρμόζεται μόνο η εξωτερική σκιά.
{{% /alert %}}

### **Εφαρμογή Εφέ Αντανάκλασης**

Μια αντανάκλαση δημιουργεί ένα κατοπτρικό αντίγραφο του κειμένου. Ρυθμίστε τη θέση, την κλίμακα, το θόλωση και τη διαφάνεια για να ελέγξετε την εμφάνισή της.

Αυτό το παράδειγμα καλεί τη μέθοδο [enableReflectionEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/effectformat/#enableReflectionEffect--) και αναστρέφει την αντανάκλαση κατακόρυφα με κλίμακα -100%. Χρησιμοποιεί ακτίνα θολώματος 0,5 πόντου και απόσταση 4,72 πόντων. Η διαφάνεια μειώνεται από 60% στο 0,9% μεταξύ θέσεων 0% και 60% κατά τη διάρκεια της αντανάκλασης:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::BottomLeft);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα κειμένου:

![Το εφέ Αντανάκλασης](reflection_effect.png)

### **Εφαρμογή Εφέ Λάμψης**

Μια λάμψη προσθέτει ένα απαλό χρωματιστό περίγραμμα γύρω από το κείμενο. Ρυθμίστε το χρώμα, τη διαφάνεια και την ακτίνα για να ελέγξετε το εφέ.

Αυτό το παράδειγμα καλεί τη μέθοδο [enableGlowEffect](https://reference.aspose.com/slides/el/php-java/aspose.slides/effectformat/#enableGlowEffect--) και εφαρμόζει κόκκινη λάμψη με διαφάνεια 54% και ακτίνα 7 πόντων:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->RED);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.54);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα κειμένου:

![Το εφέ Λάμψης](glow_effect.png)

### **Εφαρμογή Μετασχηματισμών WordArt**

Οι μετασχηματισμοί WordArt λυγίζουν, τεντώνουν ή στύβουν ένα μπλοκ κειμένου.

Ορίστε το [setTransform](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setTransform-int-) σε [ArchUpPour](https://reference.aspose.com/slides/el/php-java/aspose.slides/textshapetype/#ArchUpPour) για να καμπυλώσετε το πλήρες πλαίσιο κειμένου προς τα πάνω:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα κειμένου:

![Ο μετασχηματισμός WordArt](transform_effect.png)

{{% alert color="info" title="Σημείωση" %}}
Το Aspose.Slides for PHP via Java παρέχει ένα σύνολο προεπιλεγμένων [τύπων μετασχηματισμού](https://reference.aspose.com/slides/el/php-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Εφαρμογή 3D Εφέ σε Σχήματα και Κείμενο**

Μπορείτε να εφαρμόσετε 3D εφέ σε ένα σχήμα ή στο κείμενό του. Τα καμπύλωμα, η εξώθηση, ο φωτισμός και οι ρυθμίσεις κάμερας ελέγχουν την τελική εμφάνιση.

Το παρακάτω παράδειγμα χρησιμοποιεί το [ThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/) για να προσθέσει κυκλικά καμπύλωμα, πορτοκαλί εξώθηση και σκούρο κόκκινο περίγραμμα στο ορθογώνιο. Οι διαστάσεις του καμπύλωματος, το ύψος εξώθησης, το πλάτος περιγράμματος και το βάθος μετρώνται σε πόντους. Ένα πλαστικό υλικό, ισορροπημένος φωτισμός περιστρεφόμενος 40 μοίρες γύρω από τον άξονα Z, και μια προοπτική κάμερα ορίζουν την εμφάνιση του:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $autoShape->getTextFrame()->setText("Aspose.Slides");

    $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
    $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);

    $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
    $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $autoShape->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $autoShape->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $autoShape->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $autoShape->getThreeDFormat()->setContourWidth(1.5);

    $autoShape->getThreeDFormat()->setDepth(3);

    $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα σχήματος:

![Το 3D εφέ του σχήματος](shape_3D_effect.png)

Αυτό το παράδειγμα εφαρμόζει παρόμοια 3D μορφοποίηση στο κείμενο μέσω του [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Μικρότερα καμπύλωμα διαμορφώνουν τις άκρες των γραμμάτων, ενώ η εξώθηση και ο φωτισμός προσδίδουν βάθος στο κείμενο:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα κειμένου:

![Το 3D εφέ του κειμένου](text_3D_effect.png)

{{% alert color="info" title="Σημείωση" %}}
Η εφαρμογή 3D εφέ σε κείμενο ή στα σχήματα τους —και η αλληλεπίδραση μεταξύ αυτών των εφέ—ρυθμίζεται από συγκεκριμένους κανόνες. Σκεφτείτε μια σκηνή που περιλαμβάνει τόσο το κείμενο όσο και το σχήμα που το περιέχει. Ένα 3D εφέ περιλαμβάνει την 3D αναπαράσταση του αντικειμένου και τη σκηνή στην οποία τοποθετείται.

- Αν έχει οριστεί σκηνή τόσο για το σχήμα όσο και για το κείμενο, η σκηνή του σχήματος έχει προτεραιότητα και η σκηνή του κειμένου αγνοείται.
- Αν το σχήμα δεν διαθέτει δική του σκηνή αλλά έχει 3D αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου.
- Αν το σχήμα δεν έχει καθόλου 3D εφέ, θεωρείται επίπεδο και το 3D εφέ εφαρμόζεται μόνο στο κείμενο.

Αυτές οι συμπεριφορές σχετίζονται με τις μεθόδους [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getLightRig--) και [ThreeDFormat::getCamera](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Για περισσότερα παραδείγματα 3D μορφοποίησης, δείτε το [Δημιουργία 3D Εφέ σε Παρουσιάσεις με PHP](/slides/el/php-java/3d-presentation/).

## **Συχνές Ερωτήσεις**

**Μπορώ να χρησιμοποιήσω εφέ WordArt με διαφορετικές γραμματοσειρές ή συστήματα γραφής (π.χ. Αραβικά, Κινέζικα);**

Ναι, το Aspose.Slides for PHP via Java υποστηρίζει Unicode και λειτουργεί με όλες τις κύριες γραμματοσειρές και συστήματα γραφής. Τα εφέ WordArt όπως σκιά, γέμισμα και περίγραμμα μπορούν να εφαρμοστούν ανεξάρτητα από τη γλώσσα, αν και η διαθεσιμότητα των γραμματοσειρών και η απόδοση ενδέχεται να εξαρτώνται από τις γραμματοσειρές του συστήματος.

**Μπορώ να εφαρμόσω εφέ WordArt σε στοιχεία του master διαφάνειας;**

Ναι, μπορείτε να εφαρμόσετε εφέ WordArt σε σχήματα στις master διαφάνειες, συμπεριλαμβανομένων των placeholders τίτλου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές που γίνονται στη διάταξη του master αντικατοπτρίζονται σε όλες τις σχετικές διαφάνειες.

**Επηρεάζουν τα εφέ WordArt το μέγεθος του αρχείου παρουσίασης;**

Λίγο. Τα εφέ WordArt όπως σκιές, λάμψεις και γεμώσεις με διαβαθμίσεις μπορεί να αυξήσουν ελαφρώς το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, αλλά η διαφορά είναι συνήθως αμελητέα.

**Μπορώ να προεγγυάσω το αποτέλεσμα των εφέ WordArt χωρίς να αποθηκεύσω την παρουσίαση;**

Ναι, μπορείτε να αποδώσετε τις διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ. PNG, JPEG) χρησιμοποιώντας τη μέθοδο [Slide::getImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/#getImage--), ή να αποδώσετε μεμονωμένα σχήματα με τη μέθοδο [Shape::getImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getImage--). Αυτό σας επιτρέπει να προεγγυάσετε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξάγετε ολόκληρη την παρουσίαση.