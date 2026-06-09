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
- Εφέ εμφάνισης
- Εφέ λάμψης
- Μετασχηματισμός WordArt
- 3D εφέ
- Εξωτερικό εφέ σκιάς
- Εσωτερικό εφέ σκιάς
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε εφέ WordArt στο Aspose.Slides για PHP μέσω Java. Αυτός ο οδηγός βήμα-βήμα βοηθά τους προγραμματιστές να βελτιώσουν τις παρουσιάσεις με επαγγελματικό κείμενο."
---
## **Επισκόπηση**

Τα εφέ WordArt σας επιτρέπουν να προσθέτετε οπτικά ελκυστικό, στυλιζαρισμένο κείμενο στις παρουσιάσεις PowerPoint. Με το Aspose.Slides, οι προγραμματιστές μπορούν να δημιουργούν, να προσαρμόζουν και να διαχειρίζονται WordArt προγραμματιστικά όπως στο Microsoft PowerPoint — χωρίς να απαιτείται εγκατάσταση του Office. Αυτό το άρθρο παρέχει μια επισκόπηση της εργασίας με το WordArt, συμπεριλαμβανομένου του πώς να εφαρμόζετε μετασχηματισμούς κειμένου, στυλ γεμίσματος, περιγράμματα, σκιές και άλλες επιλογές μορφοποίησης ώστε το περιεχόμενο της παρουσίασής σας να γίνει πιο εκφραστικό και ελκυστικό. Το WordArt σας επιτρέπει να αντιμετωπίζετε το κείμενο ως γραφικό αντικείμενο. Αποτελείται από εφέ ή ειδικές τροποποιήσεις που εφαρμόζονται στο κείμενο για να το κάνουν πιο ελκυστικό ή εμφανές.

## **Δημιουργήστε ένα Απλό Πρότυπο WordArt και Εφαρμόστε το σε Κείμενο**

**Χρήση Aspose.Slides** 

Πρώτα, δημιουργούμε ένα απλό κείμενο με αυτόν τον κώδικα PHP:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
Τώρα, ορίζουμε το ύψος γραμματοσειράς του κειμένου σε μεγαλύτερη τιμή ώστε το εφέ να είναι πιο εμφανές με αυτόν τον κώδικα:

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**Χρήση Microsoft PowerPoint**

Μεταβείτε στο μενού εφέ WordArt στο Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Από το δεξιό μενού μπορείτε να επιλέξετε ένα προεπιλεγμένο εφέ WordArt. Από το αριστερό μενού μπορείτε να καθορίσετε τις ρυθμίσεις για ένα νέο WordArt.

Αυτές είναι μερικές από τις διαθέσιμες παραμέτρους ή επιλογές:

![todo:image_alt_text](image-20200930114015-3.png)

**Χρήση Aspose.Slides**

Εδώ, εφαρμόζουμε το πρότυπο χρώματος [SmallGrid](https://reference.aspose.com/slides/el/php-java/aspose.slides/patternstyle/#SmallGrid) στο κείμενο και προσθέτουμε περιθώριο κειμένου μαύρου χρώματος πλάτους 1 με αυτόν τον κώδικα:

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

```

Το παραγόμενο κείμενο:

![todo:image_alt_text](image-20200930114108-4.png)

## **Εφαρμογή Άλλων Εφέ WordArt**

**Χρήση Microsoft PowerPoint**

Από τη διεπαφή του προγράμματος, μπορείτε να εφαρμόσετε αυτά τα εφέ σε κείμενο, μπλοκ κειμένου, σχήμα ή παρόμοιο στοιχείο:

![todo:image_alt_text](image-20200930114129-5.png)

Για παράδειγμα, τα εφέ Σκιά, Αντανάκλαση και Λάμψη μπορούν να εφαρμοστούν σε κείμενο· τα εφέ 3D Μορφή και 3D Περιστροφή μπορούν να εφαρμοστούν σε μπλοκ κειμένου· η ιδιότητα Μαλακές Άκρες μπορεί να εφαρμοστεί σε Σχήμα (παραμένει ενεργή ακόμη και όταν δεν έχει οριστεί ιδιότητα 3D Μορφή).

### **Εφαρμογή Σκιαρτικών Εφέ**

Εδώ, θέλουμε να ορίσουμε ιδιότητες που αφορούν μόνο το κείμενο. Εφαρμόζουμε το εφέ σκιά σε κείμενο με αυτόν τον κώδικα:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);
```

Το API του Aspose.Slides υποστηρίζει τρεις τύπους σκιών: OuterShadow, InnerShadow και PresetShadow.

Με το PresetShadow, μπορείτε να εφαρμόσετε μια σκιά σε κείμενο (χρησιμοποιώντας προεπιλεγμένες τιμές).

**Χρήση Microsoft PowerPoint**

Στο PowerPoint μπορείτε να χρησιμοποιήσετε έναν τύπο σκιάς. Δείτε ένα παράδειγμα:

![todo:image_alt_text](image-20200930114225-6.png)

**Χρήση Aspose.Slides**

Το Aspose.Slides επιτρέπει την ταυτόχρονη εφαρμογή δύο τύπων σκιών: InnerShadow και PresetShadow.

**Σημειώσεις:**

- Όταν χρησιμοποιούνται μαζί OuterShadow και PresetShadow, εφαρμόζεται μόνο το εφέ OuterShadow. 
- Αν χρησιμοποιηθούν ταυτόχρονα OuterShadow και InnerShadow, το αποτέλεσμα ή το εφέ εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013 το εφέ διπλασιάζεται. Στο PowerPoint 2007 εφαρμόζεται το εφέ OuterShadow. 

### **Εφαρμογή Εφέ Αντανάκλασης σε Κείμενο**

Προσθέτουμε αντανάκλαση στο κείμενο με αυτό το παράδειγμα κώδικα:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);
```

### **Εφαρμογή Εφέ Λάμψης σε Κείμενο**

Εφαρμόζουμε το εφέ λάμψης στο κείμενο ώστε να λαμπει ή να ξεχωρίζει με αυτόν τον κώδικα:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```

Το αποτέλεσμα της ενέργειας:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Μπορείτε να αλλάξετε τις παραμέτρους για σκιά, αντανάκλαση και λάμψη. Οι ιδιότητες των εφέ ορίζονται ξεχωριστά για κάθε τμήμα του κειμένου. 

{{% /alert %}} 

### **Χρήση Μετασχηματισμών στο WordArt**

Χρησιμοποιούμε την ιδιότητα Transform (εφαρμόζεται σε ολόκληρο το μπλοκ κειμένου) με αυτόν τον κώδικα:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```

Το αποτέλεσμα:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Τanto το Microsoft PowerPoint όσο και το Aspose.Slides για PHP μέσω Java παρέχουν ορισμένο αριθμό προεπιλεγμένων τύπων μετασχηματισμού.

{{% /alert %}} 

**Χρήση PowerPoint**

Για πρόσβαση στα προεπιλεγμένα τύπους μετασχηματισμού, μεταβείτε σε: **Format** -> **TextEffect** -> **Transform**

**Χρήση Aspose.Slides**

Για επιλογή τύπου μετασχηματισμού, χρησιμοποιήστε το enum TextShapeType. 

### **Εφαρμογή 3D Εφέ σε Κείμενο και Σχήματα**

Ορίζουμε ένα 3D εφέ σε σχήμα κειμένου με το ακόλουθο δείγμα κώδικα:

```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Το παραγόμενο κείμενο και το σχήμα του:

![todo:image_alt_text](image-20200930114816-9.png)

Εφαρμόζουμε 3D εφέ στο κείμενο με αυτόν τον κώδικα PHP:

```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Το αποτέλεσμα της ενέργειας:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Η εφαρμογή 3D εφέ σε κείμενα ή τα σχήματά τους και οι αλληλεπιδράσεις μεταξύ εφέ βασίζονται σε ορισμένους κανόνες. 

Σκεφτείτε μια σκηνή για το κείμενο και το σχήμα που περιέχει το κείμενο. Το 3D εφέ περιλαμβάνει την αναπαράσταση 3D αντικειμένου και τη σκηνή στην οποία τοποθετείται το αντικείμενο. 

- Όταν η σκηνή ορίζεται τόσο για το σχήμα όσο και για το κείμενο, η σκηνή του σχήματος λαμβάνει προτεραιότητα — η σκηνή του κειμένου αγνοείται. 
- Όταν το σχήμα δεν διαθέτει δική του σκηνή αλλά έχει 3D αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου. 
- Διαφορετικά — όταν το σχήμα αρχικά δεν έχει 3D εφέ — το σχήμα παραμένει επίπεδο και το 3D εφέ εφαρμόζεται μόνο στο κείμενο. 

Αυτές οι περιγραφές συνδέονται με τις μεθόδους ThreeDFormat.getLightRig() και ThreeDFormat.getCamera().

{{% /alert %}} 

## **Εφαρμογή Εφέ Εξωτερικής Σκιάς σε Κείμενο**
Το Aspose.Slides για PHP μέσω Java παρέχει τις κλάσεις [OuterShadow](https://reference.aspose.com/slides/el/php-java/aspose.slides/outershadow/) και [InnerShadow](https://reference.aspose.com/slides/el/php-java/aspose.slides/innershadow/) που επιτρέπουν την εφαρμογή σκιών σε κείμενο μέσω του [TextFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/). Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).  
2. Λάβετε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.  
3. Προσθέστε ένα AutoShape τύπου Rectangle στη διαφάνεια.  
4. Πρόσβαση στο TextFrame που συνδέεται με το AutoShape.  
5. Ορίστε το FillType του AutoShape σε NoFill.  
6. Δημιουργήστε μια εμφάνιση της κλάσης OuterShadow.  
7. Ορίστε το BlurRadius της σκιάς.  
8. Ορίστε την Direction της σκιάς.  
9. Ορίστε το Distance της σκιάς.  
10. Ορίστε το RectanglelAlign σε TopLeft.  
11. Ορίστε το PresetColor της σκιάς σε Black.  
12. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/).

Αυτό το παράδειγμα κώδικα — μια υλοποίηση των παραπάνω βημάτων — δείχνει πώς να εφαρμόσετε το εφέ εξωτερικής σκιάς σε κείμενο:

```php
  $pres = new Presentation();
  try {
    # Λάβετε την αναφορά της διαφάνειας
    $sld = $pres->getSlides()->get_Item(0);
    # Προσθέστε AutoShape τύπου Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Προσθέστε TextFrame στο Rectangle
    $ashp->addTextFrame("Aspose TextBox");
    # Απενεργοποιήστε το γέμισμα του σχήματος για να πάρουμε σκιά του κειμένου
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Προσθέστε εξωτερική σκιά και ορίστε όλες τις απαραίτητες παραμέτρους
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Αποθηκεύστε την παρουσίαση στο δίσκο
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Εφαρμογή Εφέ Εσωτερικής Σκιάς σε Σχήματα**
Ακολουθήστε τα βήματα:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).  
2. Λάβετε μια αναφορά της διαφάνειας.  
3. Προσθέστε ένα AutoShape τύπου Rectangle.  
4. Ενεργοποιήστε το InnerShadowEffect.  
5. Ορίστε όλες τις απαραίτητες παραμέτρους.  
6. Ορίστε το ColorType ως Scheme.  
7. Ορίστε το Scheme Color.  
8. Αποθηκεύστε την παρουσίαση ως [PPTX](https://docs.fileformat.com/presentation/pptx/) αρχείο.

Αυτό το παράδειγμα κώδικα (βασισμένο στα παραπάνω βήματα) δείχνει πώς να προσθέσετε έναν σύνδεσμο μεταξύ δύο σχημάτων:

```php
  $pres = new Presentation();
  try {
    # Λάβετε την αναφορά της διαφάνειας
    $slide = $pres->getSlides()->get_Item(0);
    # Προσθέστε AutoShape τύπου Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Προσθέστε TextFrame στο Rectangle
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # Ενεργοποίηση InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Ορίστε όλες τις απαραίτητες παραμέτρους
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # Ορίστε ColorType ως Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Ορίστε Scheme Color
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Αποθηκεύστε την παρουσίαση
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Μπορώ να χρησιμοποιήσω τα εφέ WordArt με διαφορετικές γραμματοσειρές ή γραφές (π.χ. αραβικά, κινέζικα);**

Ναι, το Aspose.Slides υποστηρίζει Unicode και λειτουργεί με όλες τις κύριες γραμματοσειρές και γραφές. Τα εφέ WordArt όπως σκιά, γέμισμα και περίγραμμα μπορούν να εφαρμοστούν ανεξάρτητα από τη γλώσσα, αν και η διαθεσιμότητα της γραμματοσειράς και η απόδοση μπορεί να εξαρτώνται από τις γραμματοσειρές του συστήματος.

**Μπορώ να εφαρμόσω εφέ WordArt σε στοιχεία του master slide;**

Ναι, μπορείτε να εφαρμόσετε εφέ WordArt σε σχήματα των master slides, συμπεριλαμβανομένων των placeholders τίτλου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές στο master layout θα αντικατοπτριστούν σε όλες τις σχετικές διαφάνειες.

**Επηρεάζουν τα εφέ WordArt το μέγεθος του αρχείου παρουσίασης;**

Λίγο. Εφέ όπως σκιές, λάμψεις και διαβαθμίσεις γεμίσματος μπορεί να αυξήσουν ελαφρώς το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, αλλά η διαφορά είναι συνήθως αμελητέα.

**Μπορώ να προεπισκοπήσω το αποτέλεσμα των εφέ WordArt χωρίς να αποθηκεύσω την παρουσίαση;**

Ναι, μπορείτε να αποδώσετε διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ. PNG, JPEG) χρησιμοποιώντας τη μέθοδο `getImage` των κλάσεων [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) ή [Slide](https://reference.aspose.com/slides/el/php-java/aspose.slides/slide/). Αυτό σας επιτρέπει να προεπισκοπήσετε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξάγετε την πλήρη παρουσίαση.