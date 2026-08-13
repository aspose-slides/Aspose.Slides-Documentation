---
title: Δημιουργία και Εφαρμογή Εφέ WordArt σε Android
linktitle: WordArt
type: docs
weight: 110
url: /el/androidjava/wordart/
keywords:
- WordArt
- δημιουργία WordArt
- πρότυπο WordArt
- εφέ WordArt
- εφέ σκιής
- εφέ εμφάνισης
- εφέ λάμψης
- μετασχηματισμός WordArt
- 3Δ εφέ
- εφέ εξωτερικής σκιάς
- εφέ εσωτερικής σκιάς
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε εφέ WordArt στο Aspose.Slides για Android. Αυτός ο οδηγός βήμα προς βήμα βοηθά τους προγραμματιστές να ενισχύσουν τις παρουσιάσεις με επαγγελματικό κείμενο σε Java."
---
## **Επισκόπηση**

Τα εφέ WordArt σας επιτρέπουν να προσθέτετε οπτικά ελκυστικό, στιλιζαρισμένο κείμενο στις παρουσιάσεις PowerPoint σας. Με το Aspose.Slides, οι προγραμματιστές μπορούν να δημιουργούν, προσαρμόζουν και να διαχειρίζονται WordArt προγραμματιστικά, όπως στο Microsoft PowerPoint—χωρίς να χρειάζεται εγκατάσταση του Office. Αυτό το άρθρο παρέχει μια επισκόπηση της εργασίας με το WordArt, συμπεριλαμβανομένου του πώς να εφαρμόζετε μετασχηματισμούς κειμένου, στιλ γεμίσματος, περιγράμματα, σκιές και άλλες επιλογές μορφοποίησης ώστε το περιεχόμενο της παρουσίασής σας να είναι πιο εκφραστικό και ελκυστικό. Το WordArt επιτρέπει την αντιμετώπιση του κειμένου ως γραφικού αντικειμένου. Αποτελείται από εφέ ή ειδικές τροποποιήσεις που εφαρμόζονται στο κείμενο για να το κάνουν πιο ελκυστικό ή εμφανές.

## **Δημιουργία ενός Απλού Προτύπου WordArt και Εφαρμογή του σε Κείμενο**

**Using Aspose.Slides**

Αρχικά, δημιουργούμε ένα απλό κείμενο χρησιμοποιώντας αυτόν τον κώδικα Java:

``` java
import com.aspose.slides.*;

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
Τώρα, ορίζουμε το ύψος γραμματοσειράς του κειμένου σε μεγαλύτερη τιμή για να γίνει το εφέ πιο εμφανές με τον παρακάτω κώδικα:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**Using Microsoft PowerPoint**

Μεταβείτε στο μενού εφέ WordArt στο Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Από το μενού στα δεξιά, μπορείτε να επιλέξετε ένα προεγκατεστημένο εφέ WordArt. Από το μενού στα αριστερά, μπορείτε να καθορίσετε τις ρυθμίσεις για ένα νέο WordArt.

Αυτές είναι μερικές από τις διαθέσιμες παραμέτρους ή επιλογές:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

Εδώ, εφαρμόζουμε το χρώμα προτύπου [SmallGrid](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/PatternStyle#SmallGrid) στο κείμενο και προσθέτουμε ένα μαύρο περίγραμμα κειμένου με πλάτος 1 χρησιμοποιώντας αυτόν τον κώδικα:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}

```

Το αποτέλεσμα του κειμένου:

![todo:image_alt_text](image-20200930114108-4.png)

## **Εφαρμογή Άλλων Εφέ WordArt**

**Using Microsoft PowerPoint**

Από τη διεπαφή του προγράμματος, μπορείτε να εφαρμόσετε αυτά τα εφέ σε κείμενο, μπλοκ κειμένου, σχήμα ή παρόμοιο στοιχείο:

![todo:image_alt_text](image-20200930114129-5.png)

Για παράδειγμα, εφέ Σκιάς, Αντανάκλασης και Λάμψης μπορούν να εφαρμοστούν σε κείμενο· εφέ 3Δ Μορφοποίησης και 3Δ Περιστροφής μπορούν να εφαρμοστούν σε μπλοκ κειμένου· η ιδιότητα Μαλακών Άκρων μπορεί να εφαρμοστεί σε Σχήμα (παραμένει ενεργή ακόμη και αν δεν έχει οριστεί ιδιότητα 3Δ Μορφοποίησης).

### **Εφαρμογή Σκιάς**

Εδώ, σκοπός μας είναι να ορίσουμε ιδιότητες μόνο για κείμενο. Εφαρμόζουμε το εφέ σκιάς σε κείμενο με τον ακόλουθο κώδικα Java:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Το API του Aspose.Slides υποστηρίζει τρεις τύπους σκιών: OuterShadow, InnerShadow και PresetShadow.

Με το PresetShadow, μπορείτε να εφαρμόσετε μια σκιά για κείμενο (χρησιμοποιώντας προκαθορισμένες τιμές).

**Using Microsoft PowerPoint**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε έναν τύπο σκιάς. Να ένα παράδειγμα:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Το Aspose.Slides στην πραγματικότητα επιτρέπει την εφαρμογή δύο τύπων σκιών ταυτόχρονα: InnerShadow και PresetShadow.

**Notes:**
- Όταν χρησιμοποιούνται μαζί OuterShadow και PresetShadow, εφαρμόζεται μόνο το εφέ OuterShadow.
- Εάν χρησιμοποιηθούν ταυτόχρονα OuterShadow και InnerShadow, το αποτέλεσμα ή το εφέ που εφαρμόζεται εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013 το εφέ διπλασιάζεται. Στο PowerPoint 2007 εφαρμόζεται το εφέ OuterShadow.

### **Εφαρμογή Επιδράσεων Αντανάκλασης σε Κείμενο**

Προσθέτουμε αντανάκλαση στο κείμενο μέσω αυτού του δείγματος κώδικα Java:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

### **Εφαρμογή Λάμψης σε Κείμενο**

Εφαρμόζουμε το εφέ λάμψης στο κείμενο ώστε να λάμψει ή να ξεχωρίσει χρησιμοποιώντας αυτόν τον κώδικα:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

Το αποτέλεσμα της λειτουργίας:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 
Μπορείτε να αλλάξετε τις παραμέτρους για σκιά, αντανάκλαση και λάμψη. Οι ιδιότητες των εφέ ορίζονται ξεχωριστά για κάθε τμήμα του κειμένου. 
{{% /alert %}} 

### **Χρήση Μετασχηματισμών σε WordArt**

Χρησιμοποιούμε την ιδιότητα Transform (εφαρμοζόμενη σε ολόκληρο το μπλοκ κειμένου) με τον παρακάτω κώδικα:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}

```

Το αποτέλεσμα:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 
Τanto το Microsoft PowerPoint όσο και το Aspose.Slides for Android μέσω Java παρέχουν έναν ορισμένο αριθμό προεγκατεστημένων τύπων μετασχηματισμού. 
{{% /alert %}} 

**Using PowerPoint**

Για πρόσβαση στους προεγκατεστημένους τύπους μετασχηματισμού, μεταβείτε στο: **Format** -> **TextEffect** -> **Transform**

**Using Aspose.Slides**

Για επιλογή τύπου μετασχηματισμού, χρησιμοποιήστε το enum TextShapeType. 

### **Εφαρμογή 3Δ Εφέ σε Κείμενο και Σχήματα**

Ορίζουμε ένα 3Δ εφέ σε σχήμα κειμένου με τον παρακάτω κώδικα δείγματος:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Το παραγόμενο κείμενο και το σχήμα του:

![todo:image_alt_text](image-20200930114816-9.png)

Εφαρμόζουμε ένα 3Δ εφέ στο κείμενο με αυτόν τον κώδικα Java:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Το αποτέλεσμα της λειτουργίας:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 
Η εφαρμογή 3Δ εφέ σε κείμενα ή τα σχήματά τους και οι αλληλεπιδράσεις μεταξύ των εφέ βασίζονται σε ορισμένους κανόνες. 
Θεωρήστε μια σκηνή για ένα κείμενο και το σχήμα που το περιέχει. Το 3Δ εφέ περιλαμβάνει την 3Δ αναπαράσταση του αντικειμένου και τη σκηνή στην οποία τοποθετείται το αντικείμενο. 
- Όταν η σκηνή οριστεί τόσο για το σχήμα όσο και για το κείμενο, η σκηνή του σχήματος παίρνει προτεραιότητα—η σκηνή του κειμένου αγνοείται. 
- Όταν το σχήμα δεν έχει τη δική του σκηνή αλλά έχει 3Δ αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου. 
- Διαφορετικά—όταν το σχήμα αρχικά δεν έχει 3Δ εφέ—το σχήμα παραμένει επίπεδο και το 3Δ εφέ εφαρμόζεται μόνο στο κείμενο. 
Αυτές οι περιγραφές σχετίζονται με τις μεθόδους ThreeDFormat.getLightRig() και ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Εφαρμογή Εξωτερικής Σκιάς σε Κείμενο**
Το Aspose.Slides for Android μέσω Java παρέχει τις κλάσεις [**IOuterShadow**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ioutershadow/) και [**IInnerShadow**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iinnershadow/) που επιτρέπουν την εφαρμογή σκιών σε κείμενο μέσα σε [TextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframe/). Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας τον δείκτη της.
3. Προσθέστε μια AutoShape τύπου Rectangle στη διαφάνεια.
4. Πρόσβαση στο TextFrame που συσχετίζεται με την AutoShape.
5. Ορίστε το FillType της AutoShape σε NoFill.
6. Δημιουργήστε μια παρουσία της κλάσης OuterShadow.
7. Ορίστε το BlurRadius της σκιάς.
8. Ορίστε την Direction της σκιάς.
9. Ορίστε το Distance της σκιάς.
10. Ορίστε το RectangleAlign σε TopLeft.
11. Ορίστε το PresetColor της σκιάς σε Black.
12. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/) .

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Λάβετε αναφορά της διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Προσθέστε AutoShape τύπου Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Προσθέστε TextFrame στο Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // Απενεργοποιήστε το γέμισμα του σχήματος σε περίπτωση που θέλετε τη σκιά του κειμένου
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Προσθέστε εξωτερική σκιά και ορίστε όλες τις απαιτούμενες παραμέτρους
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Write την παρουσίαση στο δίσκο
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εφαρμογή Εσωτερικής Σκιάς σε Σχήματα**
Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
2. Λάβετε μια αναφορά της διαφάνειας.
3. Προσθέστε μια AutoShape τύπου Rectangle.
4. Ενεργοποιήστε το InnerShadowEffect.
5. Ορίστε όλες τις απαραίτητες παραμέτρους.
6. Ορίστε το ColorType ως Scheme.
7. Ορίστε το Scheme Color.
8. Αποθηκεύστε την παρουσίαση ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/) .

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Πάρτε την αναφορά της διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);

    // Προσθέστε AutoShape τύπου Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Προσθέστε TextFrame στο Rectangle
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Ενεργοποίηση InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Ορισμός όλων των απαιτούμενων παραμέτρων
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

### Μπορώ να χρησιμοποιήσω εφέ WordArt με διαφορετικές γραμματοσειρές ή συστήματα γραφής (π.χ. Αραβικά, Κινέζικα);
Ναι, το Aspose.Slides υποστηρίζει Unicode και λειτουργεί με όλες τις κύριες γραμματοσειρές και συστήματα γραφής. Τα εφέ WordArt όπως σκιά, γέμισμα και περίγραμμα μπορούν να εφαρμοστούν ανεξάρτητα από τη γλώσσα, αν και η διαθεσιμότητα της γραμματοσειράς και η απόδοση μπορεί να εξαρτώνται από τις γραμματοσειρές του συστήματος.

### Μπορώ να εφαρμόσω εφέ WordArt σε στοιχεία του master των διαφανειών;
Ναι, μπορείτε να εφαρμόσετε εφέ WordArt σε σχήματα στις κύριες διαφάνειες, συμπεριλαμβανομένων των placeholders τίτλου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές που γίνονται στη διάταξη master αντικατοπτρίζονται σε όλες τις σχετικές διαφάνειες.

### Επηρεάζουν τα εφέ WordArt το μέγεθος του αρχείου της παρουσίασης;
Ελαφρώς. Εφέ όπως σκιές, λάμψεις και διαβαθμισμένα γεμίσματα μπορούν να αυξήσουν ελαφρώς το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, αλλά η διαφορά είναι συνήθως αμελητέα.

### Μπορώ να προεπισκοπήσω το αποτέλεσμα των εφέ WordArt χωρίς να αποθηκεύσω την παρουσίαση;
Ναι, μπορείτε να αποδώσετε διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ. PNG, JPEG) χρησιμοποιώντας τη μέθοδο `getImage` από τις διεπαφές [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) ή [ISlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/). Αυτό σας επιτρέπει να προεπισκοπήσετε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξάγετε ολόκληρη την παρουσίαση.