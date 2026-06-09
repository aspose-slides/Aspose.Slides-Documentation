---
title: Δημιουργία και Εφαρμογή Επιδράσεων WordArt σε JavaScript
linktitle: WordArt
type: docs
weight: 110
url: /el/nodejs-java/wordart/
keywords:
- WordArt
- δημιουργία WordArt
- πρότυπο WordArt
- επίδραση WordArt
- επίδραση σκιάς
- επίδραση εμφάνισης
- επίδραση λάμψης
- μετασχηματισμός WordArt
- 3Δ επίδραση
- εξωτερική σκιά
- εσωτερική σκιά
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε τις επιδράσεις WordArt στο Aspose.Slides για Node.js. Αυτός ο οδηγός βήμα προς βήμα βοηθά τους προγραμματιστές να ενισχύσουν τις παρουσιάσεις με επαγγελματικό κείμενο."
---
## **Επισκόπηση**

Οι επιδράσεις WordArt σας επιτρέπουν να προσθέσετε οπτικά ελκυστικό, στυλιζαρισμένο κείμενο στις παρουσιάσεις PowerPoint. Με το Aspose.Slides, οι προγραμματιστές μπορούν να δημιουργούν, προσαρμόζουν και διαχειρίζονται το WordArt προγραμματιστικά, όπως στο Microsoft PowerPoint—χωρίς να χρειάζεται εγκατάσταση του Office. Αυτό το άρθρο παρέχει μια επισκόπηση της εργασίας με το WordArt, περιλαμβάνοντας πώς να εφαρμόζετε μετασχηματισμούς κειμένου, στυλ γεμίσματος, περιγράμματα, σκιές και άλλες επιλογές μορφοποίησης για να κάνετε το περιεχόμενο της παρουσίασής σας πιο εκφραστικό και ελκυστικό. Το WordArt σας επιτρέπει να αντιμετωπίζετε το κείμενο ως γραφικό αντικείμενο. Αποτελείται από επιδράσεις ή ειδικές τροποποιήσεις που εφαρμόζονται στο κείμενο ώστε να το κάνουν πιο ελκυστικό ή εμφανές.

## **Δημιουργία ενός Απλού Προτύπου WordArt και Εφαρμογή του σε Κείμενο**

**Χρήση Aspose.Slides**

Αρχικά, δημιουργούμε ένα απλό κείμενο χρησιμοποιώντας αυτόν τον κώδικα JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
Τώρα, ορίζουμε το ύψος γραμματοσειράς του κειμένου σε μεγαλύτερη τιμή για να κάνουμε την επίδραση πιο εμφανή με αυτόν τον κώδικα:

```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Χρήση Microsoft PowerPoint**

Μεταβείτε στο μενού επιδράσεων WordArt στο Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Από το μενού στα δεξιά, μπορείτε να επιλέξετε μια προ‑ορισμένη επίδραση WordArt. Από το μενού στα αριστερά, μπορείτε να καθορίσετε τις ρυθμίσεις για ένα νέο WordArt.

Αυτά είναι μερικά από τα διαθέσιμα παραμέτρους ή επιλογές:

![todo:image_alt_text](image-20200930114015-3.png)

**Χρήση Aspose.Slides**

Εδώ, εφαρμόζουμε το χρώμα προτύπου [SmallGrid](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PatternStyle#SmallGrid) στο κείμενο και προσθέτουμε ένα μαύρο περίγραμμα κειμένου πλάτους 1 χρησιμοποιώντας αυτόν τον κώδικα:

```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```
Το προκύπτον κείμενο:

![todo:image_alt_text](image-20200930114108-4.png)

## **Εφαρμογή Άλλων Επιδράσεων WordArt**

**Χρήση Microsoft PowerPoint**

Από την κλάση του προγράμματος, μπορείτε να εφαρμόσετε αυτές τις επιδράσεις σε κείμενο, τμήμα κειμένου, σχήμα ή παρόμοιο στοιχείο:

![todo:image_alt_text](image-20200930114129-5.png)

Για παράδειγμα, οι επιδράσεις Σκιά, Αντανάκλαση και Λάμψη μπορούν να εφαρμοστούν σε κείμενο· οι επιδράσεις 3D Format και 3D Rotation μπορούν να εφαρμοστούν σε τμήμα κειμένου· η ιδιότητα Soft Edges μπορεί να εφαρμοστεί σε αντικείμενο Shape (παραμένει ενεργή ακόμη και όταν δεν έχει οριστεί ιδιότητα 3D Format).

### **Εφαρμογή Σκιών**

Εδώ, σκοπεύουμε να ορίσουμε μόνο τις ιδιότητες που αφορούν σε κείμενο. Εφαρμόζουμε την επίδραση σκιάς σε κείμενο χρησιμοποιώντας αυτόν τον κώδικα JavaScript:

```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```
Το API του Aspose.Slides υποστηρίζει τρεις τύπους σκιών: OuterShadow, InnerShadow και PresetShadow.

Με το PresetShadow, μπορείτε να εφαρμόσετε σκιά σε κείμενο (χρησιμοποιώντας προεπιλεγμένες τιμές).

**Χρήση Microsoft PowerPoint**

Στο PowerPoint, μπορείτε να χρησιμοποιήσετε έναν τύπο σκιάς. Ακολουθεί ένα παράδειγμα:

![todo:image_alt_text](image-20200930114225-6.png)

**Χρήση Aspose.Slides**

Το Aspose.Slides επιτρέπει στην πραγματικότητα την ταυτόχρονη εφαρμογή δύο τύπων σκιών: InnerShadow και PresetShadow.

**Σημειώσεις:**
- Όταν χρησιμοποιούνται μαζί OuterShadow και PresetShadow, εφαρμόζεται μόνο η επίδραση OuterShadow.
- Εάν χρησιμοποιηθούν ταυτόχρονα OuterShadow και InnerShadow, η τελική ή εφαρμόσιμη επίδραση εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013 η επίδραση διπλασιάζεται. Στο PowerPoint 2007 εφαρμόζεται η επίδραση OuterShadow.

### **Εφαρμογή Εμφάνισης σε Κείμενα**

Προσθέτουμε εμφάνιση στο κείμενο μέσω αυτού του παραδείγματος κώδικα JavaScript:

```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```

### **Εφαρμογή Επίδρασης Λάμψης σε Κείμενα**

Εφαρμόζουμε την επίδραση λάμψης στο κείμενο ώστε να λάμπει ή να ξεχωρίζει χρησιμοποιώντας αυτόν τον κώδικα:

```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```
Το αποτέλεσμα της λειτουργίας:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Μπορείτε να αλλάξετε τις παραμέτρους για σκιά, εμφάνιση και λάμψη. Οι ιδιότητες των επιδράσεων ορίζονται ξεχωριστά για κάθε τμήμα του κειμένου.
{{% /alert %}} 

### **Χρήση Μετασχηματισμών στο WordArt**

Χρησιμοποιούμε την ιδιότητα Transform (ενσωματωμένη σε ολόκληρο το τμήμα κειμένου) μέσω αυτού του κώδικα:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```
Το αποτέλεσμα:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Τanto το Microsoft PowerPoint όσο και το Aspose.Slides για Node.js μέσω Java παρέχουν έναν ορισμένο αριθμό προ‑ορισμένων τύπων μετασχηματισμού.
{{% /alert %}} 

**Χρήση PowerPoint**

Για να αποκτήσετε πρόσβαση σε προ‑ορισμένους τύπους μετασχηματισμού, μεταβείτε: **Format** -> **TextEffect** -> **Transform**

**Χρήση Aspose.Slides**

Για να επιλέξετε τύπο μετασχηματισμού, χρησιμοποιήστε το enum TextShapeType.

### **Εφαρμογή 3D Επιδράσεων σε Κείμενα και Σχήματα**

Ορίζουμε μια 3D επίδραση σε σχήμα κειμένου χρησιμοποιώντας αυτό το παράδειγμα κώδικα:

```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```
Το προκύπτον κείμενο και το σχήμα του:

![todo:image_alt_text](image-20200930114816-9.png)

Εφαρμόζουμε μια 3D επίδραση στο κείμενο με αυτόν τον κώδικα JavaScript:

```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```
Το αποτέλεσμα της λειτουργίας:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Η εφαρμογή 3D επιδράσεων σε κείμενα ή στα σχήματά τους και οι αλληλεπιδράσεις μεταξύ των επιδράσεων βασίζονται σε ορισμένους κανόνες.

Θεωρήστε μια σκηνή για ένα κείμενο και το σχήμα που το περιέχει. Η 3D επίδραση περιλαμβάνει την αναπαράσταση 3D αντικειμένου και τη σκηνή στην οποία το αντικείμενο τοποθετήθηκε.

- Όταν η σκηνή έχει οριστεί τόσο για το σχήμα όσο και για το κείμενο, η σκηνή του σχήματος έχει προτεραιότητα—η σκηνή του κειμένου αγνοείται.
- Όταν το σχήμα δεν έχει τη δική του σκηνή αλλά έχει 3D αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου.
- Διαφορετικά—όταν το σχήμα αρχικά δεν έχει 3D επίδραση—το σχήμα είναι επίπεδο και η 3D επίδραση εφαρμόζεται μόνο στο κείμενο.

Αυτές οι περιγραφές σχετίζονται με τις μεθόδους ThreeDFormat.getLightRig() και ThreeDFormat.getCamera().
{{% /alert %}} 

## **Εφαρμογή Εξωτερικών Σκιών σε Κείμενα**

Το Aspose.Slides για Node.js μέσω Java παρέχει τις κλάσεις [**OuterShadow**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/outershadow/) και [**InnerShadow**](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/innershadow/) που σας επιτρέπουν να εφαρμόζετε σκιές σε κείμενο που περιέχεται σε [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/). Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
2. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το δείκτη της.
3. Προσθέστε ένα AutoShape τύπου Rectangle στη διαφάνεια.
4. Πρόσβαση στο TextFrame που συνδέεται με το AutoShape.
5. Ορίστε το FillType του AutoShape σε NoFill.
6. Δημιουργήστε μια παρουσία της κλάσης OuterShadow
7. Ορίστε το BlurRadius της σκιάς.
8. Ορίστε την Direction της σκιάς
9. Ορίστε το Distance της σκιάς.
10. Ορίστε το RectanglelAlign σε TopLeft.
11. Ορίστε το PresetColor της σκιάς σε Black.
12. Αποθηκεύστε την παρουσία ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Αυτός ο κώδικας δειγματοληπτικής υλοποίησης σε Java—που ακολουθεί τα παραπάνω βήματα—δείχνει πώς να εφαρμόσετε την εξωτερική σκιά σε κείμενο:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Λάβετε αναφορά της διαφάνειας
    var sld = pres.getSlides().get_Item(0);
    // Προσθέστε AutoShape τύπου Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Προσθέστε TextFrame στο Rectangle
    ashp.addTextFrame("Aspose TextBox");
    // Απενεργοποίηση γεμίσματος σχήματος σε περίπτωση που θέλουμε τη σκιά του κειμένου
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Προσθέστε εξωτερική σκιά και ορίστε όλες τις απαραίτητες παραμέτρους
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // Αποθήκευση της παρουσίασης στο δίσκο
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Εφαρμογή Εσωτερικής Σκιάς σε Σχήματα**

Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
2. Λάβετε μια αναφορά της διαφάνειας.
3. Προσθέστε ένα AutoShape τύπου Rectangle.
4. Ενεργοποιήστε το InnerShadowEffect.
5. Ορίστε όλες τις απαραίτητες παραμέτρους.
6. Ορίστε το ColorType ως Scheme.
7. Ορίστε το Scheme Color.
8. Αποθηκεύστε την παρουσία ως αρχείο [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Αυτός ο κώδικας δειγμάτων (βασισμένος στα παραπάνω βήματα) δείχνει πώς να προσθέσετε έναν σύνδεσμο μεταξύ δύο σχημάτων σε JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Λάβετε αναφορά της διαφάνειας
    var slide = pres.getSlides().get_Item(0);
    // Προσθέστε AutoShape τύπου Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Προσθέστε TextFrame στο Rectangle
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // Ενεργοποίηση InnerShadowEffect
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // Ορίστε όλες τις απαραίτητες παραμέτρους
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // Ορίστε ColorType ως Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Ορίστε Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // Αποθήκευση παρουσίασης
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Μπορώ να χρησιμοποιήσω τις επιδράσεις WordArt με διαφορετικές γραμματοσειρές ή συστήματα γραφής (π.χ., Αραβική, Κινέζικη);**

Ναι, το Aspose.Slides υποστηρίζει Unicode και λειτουργεί με όλες τις κύριες γραμματοσειρές και συστήματα γραφής. Οι επιδράσεις WordArt όπως σκιά, γέμισμα και περίγραμμα μπορούν να εφαρμοστούν ανεξάρτητα από τη γλώσσα, αν και η διαθεσιμότητα της γραμματοσειράς και η απόδοση ενδέχεται να εξαρτώνται από τις γραμματοσειρές του συστήματος.

**Μπορώ να εφαρμόσω τις επιδράσεις WordArt σε στοιχεία του slide master;**

Ναι, μπορείτε να εφαρμόσετε τις επιδράσεις WordArt σε σχήματα στις κύριες διαφάνειες (master slides), συμπεριλαμβανομένων των θέσεων κειμένου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές που γίνονται στη διάταξη του master θα αντικατοπτρίζονται σε όλες τις σχετικές διαφάνειες.

**Επηρεάζουν οι επιδράσεις WordArt το μέγεθος του αρχείου παρουσίασης;**

Λίγα. Οι επιδράσεις WordArt όπως σκιές, λάμψεις και διαβαθμισμένα γεμίσματα μπορεί να αυξήσουν ελαφρώς το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, αλλά η διαφορά είναι συνήθως αμελητέα.

**Μπορώ να προεγγυάσω το αποτέλεσμα των επιδράσεων WordArt χωρίς να αποθηκεύσω την παρουσίαση;**

Ναι, μπορείτε να αποδώσετε τις διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ., PNG, JPEG) χρησιμοποιώντας τη μέθοδο `getImage` των κλάσεων [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/) ή [Slide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/). Αυτό σας επιτρέπει να προεπισκοπήσετε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξάγετε ολόκληρη την παρουσίαση.