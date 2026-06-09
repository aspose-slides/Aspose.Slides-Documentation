---
title: Δημιουργία και Εφαρμογή Επιδράσεων WordArt σε Java
linktitle: WordArt
type: docs
weight: 110
url: /el/java/wordart/
keywords:
- WordArt
- Δημιουργία WordArt
- Πρότυπο WordArt
- Επίδραση WordArt
- Επίδραση Σκιάς
- Επίδραση Εμφάνισης
- Επίδραση Λάμψης
- Μετασχηματισμός WordArt
- 3Δ Επίδραση
- Εξωτερική Επίδραση Σκιάς
- Εσωτερική Επίδραση Σκιάς
- PowerPoint
- Παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε τις επιδράσεις WordArt στο Aspose.Slides για Java. Αυτός ο οδηγός βήμα προς βήμα βοηθά τους προγραμματιστές να ενισχύσουν τις παρουσιάσεις με επαγγελματικό κείμενο σε Java."
---
## **Επισκόπηση**

Οι επιδράσεις WordArt σάς επιτρέπουν να προσθέτετε οπτικά ελκυστικό, στιλιζαρισμένο κείμενο στις παρουσιάσεις PowerPoint σας. Με το Aspose.Slides, οι προγραμματιστές μπορούν να δημιουργούν, να προσαρμόζουν και να διαχειρίζονται προγραμματιστικά το WordArt όπως στο Microsoft PowerPoint — χωρίς να απαιτείται εγκατάσταση του Office. Αυτό το άρθρο παρέχει μια επισκόπηση της εργασίας με το WordArt, συμπεριλαμβανομένου του πώς να εφαρμόζετε μετασχηματισμούς κειμένου, στυλ γεμίσματος, περιγράμματα, σκιές και άλλες επιλογές μορφοποίησης για να κάνετε το περιεχόμενο της παρουσίασής σας πιο εκφραστικό και ελκυστικό. Το WordArt σας επιτρέπει να αντιμετωπίζετε το κείμενο ως γραφικό αντικείμενο. Αποτελείται από επιδράσεις ή ειδικές τροποποιήσεις που εφαρμόζονται στο κείμενο ώστε να το κάνει πιο ελκυστικό ή εμφανές.

## **Δημιουργία ενός Απλού Προτύπου WordArt και Εφαρμογή του σε Κείμενο**

**Χρήση Aspose.Slides** 

Αρχικά, δημιουργούμε ένα απλό κείμενο χρησιμοποιώντας αυτόν τον κώδικα Java: 

``` java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
Τώρα, ορίζουμε το ύψος γραμματοσειράς του κειμένου σε μεγαλύτερη τιμή ώστε η επίδραση να είναι πιο εμφανής μέσω αυτού του κώδικα:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Χρήση Microsoft PowerPoint**

Μεταβείτε στο μενού επιδράσεων WordArt στο Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Από το μενού στα δεξιά, μπορείτε να επιλέξετε μια προεπιλεγμένη επίδραση WordArt. Από το μενού στα αριστερά, μπορείτε να ορίσετε τις ρυθμίσεις για ένα νέο WordArt. 

Αυτά είναι μερικά από τα διαθέσιμα παραμέτρους ή επιλογές:

![todo:image_alt_text](image-20200930114015-3.png)

**Χρήση Aspose.Slides**

Εδώ, εφαρμόζουμε το χρώμα μοτίβου [SmallGrid](https://reference.aspose.com/slides/el/java/com.aspose.slides/PatternStyle#SmallGrid) στο κείμενο και προσθέτουμε ένα μαύρο περίγραμμα κειμένου πλάτους 1 χρησιμοποιώντας αυτόν τον κώδικα:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

Το προκύπτον κείμενο:

![todo:image_alt_text](image-20200930114108-4.png)

## **Εφαρμογή Άλλων Επιδράσεων WordArt**

**Χρήση Microsoft PowerPoint**

Από τη διεπαφή του προγράμματος, μπορείτε να εφαρμόσετε αυτές τις επιδράσεις σε κείμενο, μπλοκ κειμένου, σχήμα ή παρόμοιο στοιχείο:

![todo:image_alt_text](image-20200930114129-5.png)

Για παράδειγμα, οι επιδράσεις Σκία, Αντανάκλαση και Λάμψη μπορούν να εφαρμοστούν σε κείμενο· οι επιδράσεις 3Δ Μορφή και 3Δ Περιστροφή μπορούν να εφαρμοστούν σε μπλοκ κειμένου· η ιδιότητα Μαλακά Άκρα μπορεί να εφαρμοστεί σε αντικείμενο Σχήμα (παραμένει ενεργή ακόμη και όταν δεν έχει οριστεί ιδιότητα 3Δ Μορφή).

### **Εφαρμογή Επιδράσεων Σκιάς**

Εδώ, θέλουμε να ορίσουμε μόνο τις ιδιότητες που σχετίζονται με κείμενο. Εφαρμόζουμε την επίδραση σκιάς σε κείμενο χρησιμοποιώντας αυτόν τον κώδικα σε Java:

``` java
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
```

Το API Aspose.Slides υποστηρίζει τρεις τύπους σκιών: OuterShadow, InnerShadow και PresetShadow. 

Με το PresetShadow, μπορείτε να εφαρμόσετε σκιά σε κείμενο (χρησιμοποιώντας προορισμένες τιμές). 

**Χρήση Microsoft PowerPoint**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε έναν τύπο σκιάς. Εδώ ένα παράδειγμα:

![todo:image_alt_text](image-20200930114225-6.png)

**Χρήση Aspose.Slides**

Το Aspose.Slides, στην πραγματικότητα, σας επιτρέπει να εφαρμόσετε δύο τύπους σκιών ταυτόχρονα: InnerShadow και PresetShadow.

**Σημειώσεις:**

- Όταν χρησιμοποιούνται μαζί OuterShadow και PresetShadow, εφαρμόζεται μόνο η επίδραση OuterShadow. 
- Εάν χρησιμοποιηθούν ταυτόχρονα OuterShadow και InnerShadow, η τελική ή εφαρμοσμένη επίδραση εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013, η επίδραση διπλασιάζεται. Στο PowerPoint 2007 εφαρμόζεται η επίδραση OuterShadow. 

### **Εφαρμογή Εμφάνισης σε Κείμενα**

Προσθέτουμε εμφάνιση στο κείμενο μέσω αυτού του παραδείγματος κώδικα σε Java:

``` java
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);   
```

### **Εφαρμογή Επίδρασης Λάμψης σε Κείμενα**

Εφαρμόζουμε την επίδραση λάμψης στο κείμενο ώστε να λάμπει ή να ξεχωρίζει χρησιμοποιώντας αυτόν τον κώδικα:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Το αποτέλεσμα της λειτουργίας:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Μπορείτε να αλλάξετε τις παραμέτρους για σκιές, εμφάνιση και λάμψη. Οι ιδιότητες των επιδράσεων ορίζονται ξεχωριστά για κάθε τμήμα του κειμένου. 

{{% /alert %}} 

### **Χρήση Μετασχηματισμών στο WordArt**

Χρησιμοποιούμε την ιδιότητα Transform (ενσωματωμένη σε ολόκληρο το μπλοκ του κειμένου) μέσω αυτού του κώδικα:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Το αποτέλεσμα:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Τanto Microsoft PowerPoint όσο και Aspose.Slides για Java παρέχουν έναν ορισμένο αριθμό προεπιλεγμένων τύπων μετασχηματισμού. 

{{% /alert %}} 

**Χρήση PowerPoint**

Για να προσπελάσετε τα προεπιλεγμένα είδη μετασχηματισμού, μεταβείτε: **Format** -> **TextEffect** -> **Transform**

**Χρήση Aspose.Slides**

Για να επιλέξετε έναν τύπο μετασχηματισμού, χρησιμοποιήστε το enum TextShapeType. 

### **Εφαρμογή 3Δ Επιδράσεων σε Κείμενα και Σχήματα**

Ορίζουμε μια 3Δ επίδραση σε σχήμα κειμένου χρησιμοποιώντας αυτό το δείγμα κώδικα:

``` java
autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);

autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
autoShape.getThreeDFormat().setExtrusionHeight(6);

autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
autoShape.getThreeDFormat().setContourWidth(1.5);

autoShape.getThreeDFormat().setDepth(3);

autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

Το προκύπτον κείμενο και το σχήμα του:

![todo:image_alt_text](image-20200930114816-9.png)

Εφαρμόζουμε μια 3Δ επίδραση στο κείμενο με αυτόν τον κώδικα Java:

``` java
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

Το αποτέλεσμα της λειτουργίας:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Η εφαρμογή 3Δ επιδράσεων σε κείμενα ή τα σχήματά τους και η αλληλεπίδραση μεταξύ των επιδράσεων βασίζονται σε ορισμένους κανόνες. 

Σκεφτείτε μια σκηνή για ένα κείμενο και το σχήμα που το περιέχει. Η 3Δ επίδραση περιλαμβάνει την αναπαράσταση 3Δ αντικειμένου και τη σκηνή στην οποία το αντικείμενο τοποθετείται. 

- Όταν η σκηνή ορίζεται τόσο για το σχήμα όσο και για το κείμενο, η σκηνή του σχήματος έχει προτεραιότητα — η σκηνή του κειμένου αγνοείται. 
- Όταν το σχήμα δεν έχει δική του σκηνή αλλά διαθέτει 3Δ αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου. 
- Διαφορετικά — όταν το σχήμα αρχικά δεν έχει 3Δ επίδραση — το σχήμα είναι επίπεδο και η 3Δ επίδραση εφαρμόζεται μόνο στο κείμενο. 

Αυτές οι περιγραφές συνδέονται με τις μεθόδους ThreeDFormat.getLightRig() και ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Εφαρμογή Εξωτερικών Σκιών σε Κείμενα**
Το Aspose.Slides για Java παρέχει τις κλάσεις [**IOuterShadow**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ioutershadow/) και [**IInnerShadow**](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinnershadow/) που σας επιτρέπουν να εφαρμόσετε επιδράσεις σκιάς σε κείμενο που περιέχεται σε [TextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/textframe/). Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) .
2. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα AutoShape τύπου Rectangle στη διαφάνεια.
4. Προσπελάστε το TextFrame που συσχετίζεται με το AutoShape.
5. Ορίστε το FillType του AutoShape σε NoFill.
6. Δημιουργήστε ένα αντικείμενο της κλάσης OuterShadow.
7. Ορίστε το BlurRadius της σκιάς.
8. Ορίστε την Direction της σκιάς.
9. Ορίστε το Distance της σκιάς.
10. Ορίστε το RectanglelAlign σε TopLeft.
11. Ορίστε το PresetColor της σκιάς σε Black.
12. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/) .

```java
Presentation pres = new Presentation();
try {
    // Λάβε αναφορά της διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Πρόσθεσε AutoShape τύπου Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Πρόσθεσε TextFrame στο Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // Απενεργοποίησε το γέμισμα του σχήματος σε περίπτωση που θέλουμε τη σκιά του κειμένου
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Πρόσθεσε εξωτερική σκιά και ορίστε όλες τις απαραίτητες παραμέτρους
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Αποθήκευσε την παρουσίαση στον δίσκο
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εφαρμογή Εσωτερικής Σκιάς σε Σχήματα**
Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα παράδειγμα της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) .
2. Λάβετε μια αναφορά της διαφάνειας.
3. Προσθέστε ένα AutoShape τύπου Rectangle.
4. Ενεργοποιήστε το InnerShadowEffect.
5. Ορίστε όλες τις απαραίτητες παραμέτρους.
6. Ορίστε το ColorType ως Scheme.
7. Ορίστε το Scheme Color.
8. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/) .

```java
Presentation pres = new Presentation();
try {
    // Λάβε αναφορά της διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);

    // Πρόσθεσε AutoShape τύπου Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Πρόσθεσε TextFrame στο Rectangle
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Ενεργοποίηση InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Ορισμός όλων των απαραίτητων παραμέτρων
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Ορισμός ColorType ως Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Ορισμός Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Αποθήκευση παρουσίασης
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να χρησιμοποιήσω τις επιδράσεις WordArt με διαφορετικές γραμματοσειρές ή γραφές (π.χ., Αραβική, Κινική);**

Ναι, το Aspose.Slides υποστηρίζει Unicode και λειτουργεί με όλες τις κύριες γραμματοσειρές και γραφές. Οι επιδράσεις WordArt όπως σκιά, γέμισμα και περίγραμμα μπορούν να εφαρμοστούν ανεξαρτήτως γλώσσας, αν και η διαθεσιμότητα γραμματοσειρών και η απόδοση μπορεί να εξαρτάται από τις γραμματοσειρές του συστήματος.

**Μπορώ να εφαρμόσω τις επιδράσεις WordArt σε στοιχεία του master slide;**

Ναι, μπορείτε να εφαρμόσετε τις επιδράσεις WordArt σε σχήματα στα master slides, συμπεριλαμβανομένων των placeholders τίτλου, υποσέλιδα ή κειμένου φόντου. Οι αλλαγές που γίνονται στη διάταξη του master θα αντικατοπτρίζονται σε όλες τις συνδεδεμένες διαφάνειες.

**Επηρεάζουν οι επιδράσεις WordArt το μέγεθος του αρχείου παρουσίασης;**

Ελαφρώς. Οι επιδράσεις WordArt όπως σκιές, λάμψεις και διαβαθμισμένα γεμίσματα μπορεί να αυξήσουν ελαφρώς το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, αλλά η διαφορά είναι συνήθως αμελητέα.

**Μπορώ να προεπισκοπήσω το αποτέλεσμα των επιδράσεων WordArt χωρίς να αποθηκεύσω την παρουσίαση;**

Ναι, μπορείτε να αποδώσετε τις διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ., PNG, JPEG) χρησιμοποιώντας τη μέθοδο `getImage` από τις διεπαφές [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) ή [ISlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/). Αυτό σας επιτρέπει να προεπισκοπήσετε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξάγετε ολόκληρη την παρουσίαση.