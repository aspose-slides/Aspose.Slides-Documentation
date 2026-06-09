---
title: Δημιουργία και εφαρμογή εφέ WordArt σε Android
linktitle: WordArt
type: docs
weight: 110
url: /el/androidjava/wordart/
keywords:
- WordArt
- δημιουργία WordArt
- πρότυπο WordArt
- εφέ WordArt
- εφέ σκιάς
- εφέ εμφάνισης
- εφέ λάμψης
- μετασχηματισμός WordArt
- εφέ 3Δ
- εξωτερικό εφέ σκιάς
- εσωτερικό εφέ σκιάς
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε εφέ WordArt στο Aspose.Slides για Android. Αυτός ο οδηγός βήμα-βήμα βοηθά τους προγραμματιστές να ενισχύσουν τις παρουσιάσεις με επαγγελματικό κείμενο σε Java."
---
## **Επισκόπηση**

Οι εφέ WordArt σάς επιτρέπουν να προσθέτετε οπτικά ελκυστικό, στιλιζαρισμένο κείμενο στις παρουσιάσεις PowerPoint σας. Με το Aspose.Slides, οι προγραμματιστές μπορούν να δημιουργούν, προσαρμόζουν και διαχειρίζονται προγραμματιστικά το WordArt όπως στο Microsoft PowerPoint—χωρίς να χρειάζεται εγκατάσταση του Office. Αυτό το άρθρο παρέχει μια επισκόπηση της εργασίας με το WordArt, συμπεριλαμβανομένου του πώς να εφαρμόζετε μετασχηματισμούς κειμένου, στυλ γεμίσματος, περιγράμματα, σκιές και άλλες επιλογές μορφοποίησης για να κάνετε το περιεχόμενο της παρουσίασής σας πιο εκφραστικό και ελκυστικό. Το WordArt σας επιτρέπει να αντιμετωπίζετε το κείμενο ως γραφικό αντικείμενο. Αποτελείται από εφέ ή ειδικές τροποποιήσεις που εφαρμόζονται στο κείμενο για να το κάνουν πιο ελκυστικό ή αξιοσημείωτο.

## **Δημιουργία ενός απλού προτύπου WordArt και εφαρμογή του σε κείμενο**

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
Τώρα, ορίζουμε το ύψος γραμματοσειράς του κειμένου σε μεγαλύτερη τιμή ώστε το εφέ να είναι πιο εμφανές μέσω αυτού του κώδικα:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Χρήση Microsoft PowerPoint**

Μεταβείτε στο μενού εφέ WordArt στο Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Από το μενού στα δεξιά, μπορείτε να επιλέξετε ένα προορισμένο εφέ WordArt. Από το μενού στα αριστερά, μπορείτε να ορίσετε τις ρυθμίσεις για ένα νέο WordArt. 

Αυτά είναι μερικά από τα διαθέσιμα παραμέτρων ή επιλογές:

![todo:image_alt_text](image-20200930114015-3.png)

**Χρήση Aspose.Slides**

Εδώ, εφαρμόζουμε το χρώμα μοτίβου [SmallGrid](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/PatternStyle#SmallGrid) στο κείμενο και προσθέτουμε ένα μαύρο περίγραμμα κειμένου πλάτους 1 χρησιμοποιώντας αυτόν τον κώδικα:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

Το παραγόμενο κείμενο:

![todo:image_alt_text](image-20200930114108-4.png)

## **Εφαρμογή άλλων εφέ WordArt**

**Χρήση Microsoft PowerPoint**

Από τη διεπαφή του προγράμματος, μπορείτε να εφαρμόσετε αυτά τα εφέ σε κείμενο, μπλοκ κειμένου, σχήμα ή παρόμοιο στοιχείο:

![todo:image_alt_text](image-20200930114129-5.png)

Για παράδειγμα, εφέ Σκιάς, Αντανάκλασης και Λάμψης μπορούν να εφαρμοστούν σε κείμενο· εφέ 3D Format και 3D Rotation μπορούν να εφαρμοστούν σε μπλοκ κειμένου· η ιδιότητα Soft Edges μπορεί να εφαρμοστεί σε αντικείμενο σχήματος (διατηρείται το εφέ ακόμα και αν δεν έχει οριστεί η ιδιότητα 3D Format).

### **Εφαρμογή Εφέ Σκιάς**

Εδώ, προτιθέμεθα να ορίσουμε τις ιδιότητες που αφορούν μόνο σε κείμενο. Εφαρμόζουμε το εφέ σκιάς στο κείμενο χρησιμοποιώντας αυτόν τον κώδικα σε Java:

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

Το API του Aspose.Slides υποστηρίζει τρεις τύπους σκιών: OuterShadow, InnerShadow και PresetShadow. 

Με το PresetShadow, μπορείτε να εφαρμόσετε σκιά σε κείμενο (χρησιμοποιώντας προεπιλεγμένες τιμές). 

**Χρήση Microsoft PowerPoint**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε έναν τύπο σκιάς. Ακολουθεί ένα παράδειγμα:

![todo:image_alt_text](image-20200930114225-6.png)

**Χρήση Aspose.Slides**

Το Aspose.Slides επιτρέπει στην πραγματικότητα την ταυτόχρονη εφαρμογή δύο τύπων σκιών: InnerShadow και PresetShadow.

- Όταν χρησιμοποιούνται μαζί OuterShadow και PresetShadow, εφαρμόζεται μόνο το εφέ OuterShadow. 
- Εάν χρησιμοποιηθούν ταυτόχρονα OuterShadow και InnerShadow, το αποτέλεσμα ή το εφαρμοσθέν εφέ εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013 το εφέ διπλασιάζεται. Στο PowerPoint 2007 εφαρμόζεται το εφέ OuterShadow. 

### **Εφαρμογή Εφέ Αντανάκλασης σε Κείμενο**

Προσθέτουμε εμφάνιση στο κείμενο μέσω αυτού του δείγματος κώδικα σε Java:

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

### **Εφαρμογή Εφέ Λάμψης σε Κείμενο**

Εφαρμόζουμε το εφέ λάμψης στο κείμενο ώστε να λάμπει ή να ξεχωρίζει χρησιμοποιώντας αυτόν τον κώδικα:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Το αποτέλεσμα της λειτουργίας:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Μπορείτε να αλλάξετε τις παραμέτρους για τη σκιά, την εμφάνιση και τη λάμψη. Οι ιδιότητες των εφέ ορίζονται ξεχωριστά για κάθε τμήμα του κειμένου. 
{{% /alert %}} 

### **Χρήση Μετασχηματισμών στο WordArt**

Χρησιμοποιούμε την ιδιότητα Transform (ενσωματωμένη σε ολόκληρο το μπλοκ κειμένου) μέσω αυτού του κώδικα:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Το αποτέλεσμα:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Τanto το Microsoft PowerPoint όσο και το Aspose.Slides για Android μέσω Java παρέχουν έναν ορισμένο αριθμό προκαθορισμένων τύπων μετασχηματισμών. 
{{% /alert %}} 

**Χρήση PowerPoint**

Για να αποκτήσετε πρόσβαση στους προκαθορισμένους τύπους μετασχηματισμών, μεταβείτε: **Format** -> **TextEffect** -> **Transform**

**Χρήση Aspose.Slides**

Για να επιλέξετε τύπο μετασχηματισμού, χρησιμοποιήστε την enum TextShapeType. 

### **Εφαρμογή 3Δ Εφέ σε Κείμενο και Σχήματα**

Ορίζουμε ένα 3Δ εφέ σε σχήμα κειμένου χρησιμοποιώντας αυτό το δείγμα κώδικα:

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

Εφαρμόζουμε ένα 3Δ εφέ στο κείμενο με αυτόν τον κώδικα Java:

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
Η εφαρμογή 3Δ εφέ σε κείμενα ή στα σχήματά τους και οι αλληλεπιδράσεις μεταξύ των εφέ βασίζονται σε ορισμένους κανόνες. 
Θεωρήστε μια σκηνή για ένα κείμενο και το σχήμα που περιέχει το κείμενο. Το 3Δ εφέ περιλαμβάνει την αναπαράσταση αντικειμένου 3Δ και τη σκηνή στην οποία το αντικείμενο τοποθετείται. 
 - Όταν η σκηνή ορίζεται τόσο για το σχήμα όσο και για το κείμενο, η σκηνή του σχήματος έχει προτεραιότητα· η σκηνή του κειμένου αγνοείται. 
 - Όταν το σχήμα δεν έχει τη δική του σκηνή αλλά έχει 3Δ αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου. 
 - Διαφορετικά—όταν το σχήμα αρχικά δεν έχει 3Δ εφέ—το σχήμα είναι επίπεδο και το 3Δ εφέ εφαρμόζεται μόνο στο κείμενο. 
Αυτές οι περιγραφές συνδέονται με τις μεθόδους ThreeDFormat.getLightRig() και ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Εφαρμογή Εξωτερικής Σκιάς σε Κείμενο**
Το Aspose.Slides for Android μέσω Java παρέχει τις κλάσεις [**IOuterShadow**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ioutershadow/) και [**IInnerShadow**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinnershadow/) που σας επιτρέπουν να εφαρμόσετε εφέ σκιάς σε κείμενο που περιέχεται σε [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframe/). Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).  
2. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.  
3. Προσθέστε ένα AutoShape τύπου Rectangle στη διαφάνεια.  
4. Προσπελάστε το TextFrame που συνδέεται με το AutoShape.  
5. Ορίστε το FillType του AutoShape σε NoFill.  
6. Δημιουργήστε μια παρουσία της κλάσης OuterShadow.  
7. Ορίστε το BlurRadius της σκιάς.  
8. Ορίστε την Direction της σκιάς.  
9. Ορίστε το Distance της σκιάς.  
10. Ορίστε το RectanglelAlign σε TopLeft.  
11. Ορίστε το PresetColor της σκιάς σε Black.  
12. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/) .  

Αυτό το δείγμα κώδικα σε Java—μια υλοποίηση των παραπάνω βημάτων—δείχνει πώς να εφαρμόσετε το εφέ εξωτερικής σκιάς σε κείμενο:

```java
Presentation pres = new Presentation();
try {
    // Λάβετε την αναφορά της διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθέστε ένα AutoShape τύπου Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Προσθέστε TextFrame στο Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // Απενεργοποιήστε το γέμισμα του σχήματος σε περίπτωση που θέλουμε τη σκιά του κειμένου
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Προσθέστε εξωτερική σκιά και ορίστε όλες τις απαιτούμενες παραμέτρους
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Αποθηκεύστε την παρουσίαση στο δίσκο
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εφαρμογή Εσωτερικής Σκιάς σε Σχήματα**
Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).  
2. Αποκτήστε μια αναφορά της διαφάνειας.  
3. Προσθέστε ένα AutoShape τύπου Rectangle.  
4. Ενεργοποιήστε το InnerShadowEffect.  
5. Ορίστε όλες τις απαραίτητες παραμέτρους.  
6. Ορίστε το ColorType ως Scheme.  
7. Ορίστε το Scheme Color.  
8. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/) .  

Αυτό το δείγμα κώδικα (με βάση τα παραπάνω βήματα) δείχνει πώς να προσθέσετε έναν σύνδεσμο μεταξύ δύο σχημάτων σε Java:

```java
Presentation pres = new Presentation();
try {
    // Λάβετε την αναφορά της διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθέστε ένα AutoShape τύπου Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Προσθέστε TextFrame στο Rectangle
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Ενεργοποιήστε InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Ορίστε όλες τις απαιτούμενες παραμέτρους
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Ορίστε ColorType ως Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Ορίστε Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Αποθηκεύστε την παρουσίαση
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να χρησιμοποιήσω εφέ WordArt με διαφορετικές γραμματοσειρές ή γλώσσες (π.χ., Αραβικά, Κινέζικα);**

Ναι, το Aspose.Slides υποστηρίζει Unicode και λειτουργεί με όλες τις κύριες γραμματοσειρές και γλώσσες. Τα εφέ WordArt όπως σκιά, γέμισμα και περίγραμμα μπορούν να εφαρμοστούν ανεξαρτήτως γλώσσας, αν και η διαθεσιμότητα των γραμματοσειρών και η απόδοση ενδέχεται να εξαρτώνται από τις γραμματοσειρές του συστήματος.

**Μπορώ να εφαρμόσω εφέ WordArt σε στοιχεία του slide master;**

Ναι, μπορείτε να εφαρμόσετε εφέ WordArt σε σχήματα στις κύριες διαφάνειες (master slides), συμπεριλαμβανομένων των placeholders τίτλου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές που γίνονται στη διάταξη του master θα αντικατοπτρίζονται σε όλες τις σχετικές διαφάνειες.

**Επηρεάζουν τα εφέ WordArt το μέγεθος του αρχείου παρουσίασης;**

Σε μικρό βαθμό. Εφέ WordArt όπως σκιές, λάμψη και διαβαθμισμένα γεμίσματα μπορεί να αυξήσουν ελαφρώς το μέγεθος του αρχείου εξαιτίας των επιπλέον μεταδεδομένων μορφοποίησης, αλλά η διαφορά είναι συνήθως αμελητέα.

**Μπορώ να προβάλλω το αποτέλεσμα των εφέ WordArt χωρίς να αποθηκεύσω την παρουσίαση;**

Ναι, μπορείτε να αποδώσετε (render) τις διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ., PNG, JPEG) χρησιμοποιώντας τη μέθοδο `getImage` από τις διεπαφές [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) ή [ISlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/). Αυτό σας επιτρέπει να προβάλετε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξάγετε ολόκληρη την παρουσίαση.