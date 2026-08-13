---
title: Δημιουργία και Εφαρμογή Εφέ WordArt σε Java
linktitle: WordArt
type: docs
weight: 110
url: /el/java/wordart/
keywords:
- WordArt
- Δημιουργία WordArt
- Πρότυπο WordArt
- Εφέ WordArt
- Εφέ σκιάς
- Εφέ εμφάνισης
- Εφέ λάμψης
- Μετασχηματισμός WordArt
- Εφέ 3Δ
- Εφέ εξωτερικής σκιάς
- Εφέ εσωτερικής σκιάς
- PowerPoint
- Παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε εφέ WordArt στο Aspose.Slides για Java. Αυτός ο οδηγός βήμα προς βήμα βοηθά τους προγραμματιστές να ενισχύσουν τις παρουσιάσεις με επαγγελματικό κείμενο σε Java."
---
## **Επισκόπηση**

Τα εφέ WordArt σάς επιτρέπουν να προσθέτετε οπτικά ελκυστικό, στιλιζαρισμένο κείμενο στις παρουσιάσεις PowerPoint. Με το Aspose.Slides, οι προγραμματιστές μπορούν προγραμματιστικά να δημιουργούν, να προσαρμόζουν και να διαχειρίζονται WordArt όπως στο Microsoft PowerPoint—χωρίς ανάγκη εγκατάστασης του Office. Αυτό το άρθρο παρέχει μια επισκόπηση της εργασίας με WordArt, συμπεριλαμβανομένου του πώς να εφαρμόζετε μετασχηματισμούς κειμένου, στυλ γεμίσματος, γραμμές περιγράμματος, σκιές και άλλες επιλογές μορφοποίησης για να κάνετε το περιεχόμενο της παρουσίασής σας πιο εκφραστικό και ελκυστικό. Το WordArt σας επιτρέπει να αντιμετωπίζετε το κείμενο ως γραφικό αντικείμενο. Αποτελείται από εφέ ή ειδικές τροποποιήσεις που εφαρμόζονται στο κείμενο ώστε να είναι πιο ελκυστικό ή εμφανές.

## **Δημιουργία μιας απλής προτύπου WordArt και εφαρμογή του σε κείμενο**

**Χρήση Aspose.Slides** 

Πρώτα, δημιουργούμε ένα απλό κείμενο χρησιμοποιώντας αυτόν τον κώδικα Java: 

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
Τώρα, ορίζουμε το ύψος γραμματοσειράς του κειμένου σε μεγαλύτερη τιμή για να είναι πιο εμφανές το εφέ μέσω αυτού του κώδικα:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}
```

**Χρήση Microsoft PowerPoint**

Μεταβείτε στο μενού εφέ WordArt στο Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Από το μενού στα δεξιά, μπορείτε να επιλέξετε ένα προ‑ορισμένο εφέ WordArt. Από το μενού στα αριστερά, μπορείτε να ορίσετε τις ρυθμίσεις για ένα νέο WordArt. 

Αυτά είναι μερικά από τα διαθέσιμα παραμέτρους ή επιλογές:

![todo:image_alt_text](image-20200930114015-3.png)

**Χρήση Aspose.Slides**

Εδώ, εφαρμόζουμε το χρώμα προτύπου [SmallGrid](https://reference.aspose.com/slides/el/java/com.aspose.slides/PatternStyle#SmallGrid) στο κείμενο και προσθέτουμε ένα μαύρο περίγραμμα κειμένου πλάτους 1 χρησιμοποιώντας αυτόν τον κώδικα:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

Το προκύπτον κείμενο:

![todo:image_alt_text](image-20200930114108-4.png)

## **Εφαρμογή άλλων εφέ WordArt**

**Χρήση Microsoft PowerPoint**

Από τη διεπαφή του προγράμματος, μπορείτε να εφαρμόσετε αυτά τα εφέ σε κείμενο, μπλοκ κειμένου, σχήμα ή παρόμοιο στοιχείο:

![todo:image_alt_text](image-20200930114129-5.png)

Για παράδειγμα, τα εφέ Σκιά, Αντανάκλαση και Λάμψη μπορούν να εφαρμοστούν σε κείμενο· τα εφέ 3D Format και 3D Rotation μπορούν να εφαρμοστούν σε μπλοκ κειμένου· η ιδιότητα Soft Edges μπορεί να εφαρμοστεί σε αντικείμενο σχήματος (έχει ακόμη αποτέλεσμα όταν δεν έχει οριστεί ιδιότητα 3D Format). 

### **Εφαρμογή εφέ Σκιάς**

Εδώ, προορίζουμε να ορίσουμε ιδιότητες που αφορούν μόνο το κείμενο. Εφαρμόζουμε το εφέ σκιάς σε κείμενο χρησιμοποιώντας αυτόν τον κώδικα Java:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

Με το PresetShadow, μπορείτε να εφαρμόσετε μια σκιά σε κείμενο (χρησιμοποιώντας προκαθορισμένες τιμές). 

**Χρήση Microsoft PowerPoint**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε έναν τύπο σκιάς. Να ένα παράδειγμα:

![todo:image_alt_text](image-20200930114225-6.png)

**Χρήση Aspose.Slides**

Το Aspose.Slides επιτρέπει στην πραγματικότητα την ταυτόχρονη εφαρμογή δύο τύπων σκιών: InnerShadow και PresetShadow.

**Σημειώσεις:**

- Όταν χρησιμοποιούνται μαζί OuterShadow και PresetShadow, εφαρμόζεται μόνο το εφέ OuterShadow. 
- Αν τα OuterShadow και InnerShadow χρησιμοποιηθούν ταυτόχρονα, το αποτέλεσμα ή το εφαρμοσμένο εφέ εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013 το εφέ διπλασιάζεται. Στο PowerPoint 2007 εφαρμόζεται το εφέ OuterShadow. 

### **Εφαρμογή εμφάνισης σε κείμενα**

Προσθέτουμε εμφάνιση στο κείμενο μέσω αυτού του δείγματος κώδικα Java:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

### **Εφαρμογή εφέ Λάμψης σε κείμενα**

Εφαρμόζουμε το εφέ λάμψης στο κείμενο ώστε να λάμπει ή να ξεχωρίζει χρησιμοποιώντας αυτόν τον κώδικα:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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
Μπορείτε να αλλάξετε τις παραμέτρους για σκιά, εμφάνιση και λάμψη. Οι ιδιότητες των εφέ ορίζονται ξεχωριστά για κάθε τμήμα του κειμένου. 
{{% /alert %}} 

### **Χρήση Μετασχηματισμών στο WordArt**

Χρησιμοποιούμε την ιδιότητα Transform (εφαρμοζόμενη σε ολόκληρο το μπλοκ κειμένου) μέσω αυτού του κώδικα:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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
Τanto το Microsoft PowerPoint όσο και το Aspose.Slides for Java παρέχουν έναν αριθμό προ‑ορισμένων τύπων μετασχηματισμού. 
{{% /alert %}} 

**Χρήση PowerPoint**

Για πρόσβαση στους προ‑ορισμένους τύπους μετασχηματισμού, μεταβείτε σε: **Format** -> **TextEffect** -> **Transform**

**Χρήση Aspose.Slides**

Για επιλογή τύπου μετασχηματισμού, χρησιμοποιήστε το enum TextShapeType. 

### **Εφαρμογή 3D εφέ σε κείμενα και σχήματα**

Ορίζουμε ένα 3D εφέ σε σχήμα κειμένου χρησιμοποιώντας αυτό το δείγμα κώδικα:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

Το προκύπτον κείμενο και το σχήμα του:

![todo:image_alt_text](image-20200930114816-9.png)

Εφαρμόζουμε 3D εφέ στο κείμενο με αυτόν τον κώδικα Java:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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
Η εφαρμογή 3D εφέ σε κείμενα ή τα σχήματά τους και οι αλληλεπιδράσεις μεταξύ εφέ βασίζονται σε συγκεκριμένους κανόνες. 

Σκεφτείτε μια σκηνή για ένα κείμενο και το σχήμα που το περιέχει. Το 3D εφέ περιλαμβάνει την αναπαράσταση 3D αντικειμένου και τη σκηνή στην οποία το αντικείμενο τοποθετήθηκε. 

- Όταν η σκηνή ορίζεται τόσο για το σχήμα όσο και για το κείμενο, η σκηνή του σχήματος παίρνει υψηλότερη προτεραιότητα—η σκηνή του κειμένου αγνοείται. 
- Όταν το σχήμα δεν διαθέτει δική του σκηνή αλλά έχει 3D αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου. 
- Διαφορετικά—όταν το σχήμα αρχικά δεν έχει 3D εφέ—το σχήμα παραμένει επίπεδο και το 3D εφέ εφαρμόζεται μόνο στο κείμενο. 

Αυτές οι περιγραφές συνδέονται με τις μεθόδους ThreeDFormat.getLightRig() και ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Εφαρμογή εφέ Outer Shadow σε κείμενα**
Το Aspose.Slides for Java παρέχει τις κλάσεις [**IOuterShadow**](https://reference.aspose.com/slides/el/java/com.aspose.slides/ioutershadow/) και [**IInnerShadow**](https://reference.aspose.com/slides/el/java/com.aspose.slides/iinnershadow/) που επιτρέπουν την εφαρμογή εφέ σκιάς σε κείμενο που φιλοξενείται από το [TextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/textframe/). Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation). 
2. Λάβετε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της. 
3. Προσθέστε AutoShape τύπου Rectangle στη διαφάνεια. 
4. Πρόσβαση στο TextFrame που συνδέεται με το AutoShape. 
5. Ορίστε το FillType του AutoShape σε NoFill. 
6. Δημιουργήστε αντικείμενο OuterShadow. 
7. Ορίστε το BlurRadius της σκιάς. 
8. Ορίστε την Direction της σκιάς. 
9. Ορίστε το Distance της σκιάς. 
10. Ορίστε το RectanglelAlign σε TopLeft. 
11. Ορίστε το PresetColor της σκιάς σε Black. 
12. Αποθηκεύστε την παρουσία ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Αυτό το δείγμα κώδικα Java—μια υλοποίηση των παραπάνω βημάτων—δείχνει πώς να εφαρμόσετε το εφέ outer shadow σε κείμενο:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Λάβετε τη αναφορά της διαφάνειας
    ISlide sld = pres.getSlides().get_Item(0);

    // Πρόσθεσε AutoShape τύπου Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Πρόσθεσε TextFrame στο Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // Απενεργοποίησε το γέμισμα σχήματος σε περίπτωση που θέλουμε τη σκιά του κειμένου
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Πρόσθεσε εξωτερική σκιά και όρισε όλες τις απαραίτητες παραμέτρους
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Γράψε την παρουσίαση στο δίσκο
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εφαρμογή εφέ Inner Shadow σε σχήματα**
Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation). 
2. Λάβετε την αναφορά της διαφάνειας. 
3. Προσθέστε AutoShape τύπου Rectangle. 
4. Ενεργοποιήστε InnerShadowEffect. 
5. Ορίστε όλες τις απαραίτητες παραμέτρους. 
6. Ορίστε το ColorType ως Scheme. 
7. Ορίστε το Scheme Color. 
8. Αποθηκεύστε την παρουσία ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Αυτό το δείγμα κώδικα (βάσει των παραπάνω βημάτων) δείχνει πώς να εφαρμόσετε το εφέ inner shadow στο κείμενο μέσα σε σχήμα σε Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Λάβετε τη αναφορά της διαφάνειας
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

    // Ορίστε όλες τις απαραίτητες παραμέτρους
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Ορίστε ColorType ως Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Ορίστε Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Αποθήκευση Παρουσίασης
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές Ερωτήσεις**

### Μπορώ να χρησιμοποιήσω εφέ WordArt με διαφορετικές γραμματοσειρές ή γραφές (π.χ., Αραβική, Κινεζική);

Ναι, το Aspose.Slides υποστηρίζει Unicode και λειτουργεί με όλες τις κυριότερες γραμματοσειρές και γραφές. Εφέ WordArt όπως σκιά, γέμισμα και περίγραμμα μπορούν να εφαρμοστούν ανεξάρτητα από τη γλώσσα, αν και η διαθεσιμότητα γραμματοσειράς και η απόδοση μπορεί να εξαρτώνται από τις γραμματοσειρές του συστήματος.

### Μπορώ να εφαρμόσω εφέ WordArt σε στοιχεία του slide master;

Ναι, μπορείτε να εφαρμόσετε εφέ WordArt σε σχήματα στις διαφάνειες master, συμπεριλαμβανομένων των placeholders τίτλου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές στο master layout αντικατοπτρίζονται σε όλες τις σχετικές διαφάνειες.

### Επηρεάζουν τα εφέ WordArt το μέγεθος του αρχείου παρουσίασης;

Κατά κάποιο τρόπο. Εφέ WordArt όπως σκιές, λάμψεις και γεμίσματα διαβάσματος μπορεί να αυξήσουν ελαφρώς το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, αλλά η διαφορά είναι συνήθως αμελητέα.

### Μπορώ να προεπισκοπήσω το αποτέλεσμα των εφέ WordArt χωρίς αποθήκευση της παρουσίασης;

Ναι, μπορείτε να αποδώσετε διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ., PNG, JPEG) χρησιμοποιώντας τη μέθοδο `getImage` από τις διεπαφές [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) ή [ISlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/). Αυτό σας επιτρέπει να προεπισκοπήσετε το αποτέλεσμα εν ενσωμάτωση ή στην οθόνη πριν αποθηκεύσετε ή εξάγετε ολόκληρη την παρουσίαση.