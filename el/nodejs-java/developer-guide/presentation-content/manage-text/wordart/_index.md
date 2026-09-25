---
title: Δημιουργία και Εφαρμογή Εφέ WordArt σε Node.js
linktitle: WordArt
type: docs
weight: 110
url: /el/nodejs-java/wordart/
keywords:
- WordArt
- δημιουργία WordArt
- πρότυπο WordArt
- εφέ WordArt
- εφέ σκιάς
- εφέ αντανάκλασης
- εφέ λάμψης
- μετασχηματισμός WordArt
- 3Δ εφέ
- εξωτερικό εφέ σκιάς
- εσωτερικό εφέ σκιάς
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε εφέ WordArt στο Aspose.Slides για Node.js μέσω Java. Αυτός ο οδηγός βήμα‑βήμα βοηθά τους προγραμματιστές να βελτιώσουν τις παρουσιάσεις με επαγγελματικό κείμενο σε Node.js."
---
## **Επισκόπηση**

Οι εφέ WordArt σάς επιτρέπουν να μορφοποιήσετε το κείμενο με γεμίσματα, περιγράμματα, σκιές, αντανακλάσεις, λάμψη, μετασχηματισμούς και 3Δ μορφοποίηση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να προσαρμόσετε αυτά τα εφέ σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides for Node.js via Java, χωρίς εγκατεστημένο το Microsoft Office.

## **Δημιουργήστε ένα Απλό Πρότυπο WordArt και Εφαρμόστε το σε Κείμενο**

Τα παρακάτω παραδείγματα δημιουργούν ένα απλό στυλ WordArt ορίζοντας το κείμενο, τη γραμματοσειρά, το γεμίσμα μοτίβου και το περίγραμμα.

Κάθε παράδειγμα δημιουργεί μια νέα παρουσίαση και προσθέτει ένα ορθογώνιο στη πρώτη διαφάνεια· δεν απαιτείται αρχείο εισόδου. Το πρώτο παράδειγμα ορίζει το κείμενο σε "Aspose.Slides". Η θέση και οι διαστάσεις του σχήματος μετρώνται σε σημεία:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();

    const portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Ορίστε τη γραμματοσειρά σε Arial Black στα 36 σημεία ώστε η μορφοποίηση να είναι πιο εμφανής:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Εφαρμόστε ένα [SmallGrid](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/patternstyle/#SmallGrid) μοτίβο με προβάση σκούρου πορτοκαλιού και λευκό φόντο, έπειτα προσθέστε μαύρο περίγραμμα κειμένου με πλάτος 1 σημείο:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
} finally {
    presentation.dispose();
}
```

Το προκύπτον κείμενο:

![Το απλό πρότυπο WordArt](WordArt_template.png)

## **Εφαρμόστε Άλλα Εφέ WordArt**

Τα παρακάτω παραδείγματα δείχνουν πώς να εφαρμόσετε σκιές, αντανακλάσεις, λάμψη, μετασχηματισμούς και 3Δ εφέ σε κείμενο.

### **Εφαρμόστε Εξωτερικές Σκιές**

Μια εξωτερική σκιά προσθέτει βάθος τοποθετώντας μια σκιά πίσω από το κείμενο. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση, την ακτίνα θολώματος, την κλίμακα και την παραμόρφωση.

Αυτό το παράδειγμα καλεί [enableOuterShadowEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect) και ορίζει μια μαύρη σκιά με ακτίνα θολώματος 4 σημείων, κατεύθυνση 230 μοιρών και απόσταση 30 σημείων. Οι τιμές κλίμακας 100 διατηρούν το μέγεθος της σκιάς, ενώ η οριζόντια παραμόρφωση την κλίνει κατά 20 μοίρες. Η μετατροπή άλφα ορίζει τη διαφάνειά της στο 32%:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.32));
} finally {
    presentation.dispose();
}
```

Το προκύπτον κείμενο:

![Το εφέ Εξωτερικής Σκιάς](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Όταν χρησιμοποιούνται ταυτόχρονα εξωτερικές και προεπιλεγμένες σκιές, εφαρμόζεται μόνο η εξωτερική σκιά.
- Εάν χρησιμοποιηθούν ταυτόχρονα εξωτερικές και εσωτερικές σκιές, το τελικό αποτέλεσμα εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013 το εφέ διπλασιάζεται, ενώ στο PowerPoint 2007 εφαρμόζεται μόνο η εξωτερική σκιά.
{{% /alert %}}

### **Εφαρμόστε Εφέ Αντανάκλασης**

Μια αντανάκλαση δημιουργεί ένα κατοπτρισμένο αντίγραφο του κειμένου. Ρυθμίστε τη θέση, την κλίμακα, το θόλωμα και τη διαφάνεια για να ελέγξετε την εμφάνισή του.

Αυτό το παράδειγμα καλεί [enableReflectionEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect) και αναστρέφει την αντανάκλαση κατακόρυφα με κλίμακα -100%. Χρησιμοποιεί ακτίνα θολώματος 0,5 σημείου και απόσταση 4,72 σημείου. Η διαφάνεια μειώνεται από 60% σε 0,9% μεταξύ θέσεων 0% και 60% κατά μήκος της αντανάκλασης:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(java.newFloat(0));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(java.newFloat(0.9));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.BottomLeft));
} finally {
    presentation.dispose();
}
```

Το προκύπτον κείμενο:

![Το εφέ Αντανάκλασης](reflection_effect.png)

### **Εφαρμόστε Εφέ Λάμψης**

Η λάμψη προσθέτει ένα απαλό χρωματιστό περίγραμμα γύρω από το κείμενο. Ρυθμίστε το χρώμα, τη διαφάνεια και την ακτίνα για να ελέγξετε το εφέ.

Αυτό το παράδειγμα καλεί [enableGlowEffect](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/effectformat/#enableGlowEffect) και εφαρμόζει κόκκινη λάμψη με διαφάνεια 54% και ακτίνα 7 σημείων:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.54));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Το προκύπτον κείμενο:

![Το εφέ Λάμψης](glow_effect.png)

### **Εφαρμόστε Μετασχηματισμούς WordArt**

Οι μετασχηματισμοί WordArt λυγίζουν, τεντώσουν ή παραμορφώνουν ένα μπλοκ κειμένου.

Ορίστε [setTransform](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#setTransform) σε [ArchUpPour](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textshapetype/#ArchUpPour) για να καμπυλώσετε ολόκληρο το πλαίσιο κειμένου προς τα πάνω:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
} finally {
    presentation.dispose();
}
```

Το προκύπτον κείμενο:

![Ο μετασχηματισμός WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Το Aspose.Slides for Node.js via Java παρέχει ένα σύνολο προεπιλεγμένων [τύπων μετασχηματισμού](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Εφαρμόστε 3Δ Εφέ σε Σχήματα και Κείμενο**

Μπορείτε να εφαρμόσετε 3Δ εφέ σε ένα σχήμα ή στο κείμενό του. Οι τεχνικές λοξοτομίας, εξώθησης, φωτισμού και ρυθμίσεις κάμερας ελέγχουν την τελική εμφάνιση.

Το παρακάτω παράδειγμα χρησιμοποιεί [ThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/) για να προσθέσει κυκλικές λοξοτομίες, πορτοκαλί εξώθηση και σκοτεινό κόκκινο περίγραμμα στο ορθογώνιο. Οι διαστάσεις λοξοτομίας, το ύψος εξώθησης, το πλάτος περιγράμματος και το βάθος μετρώνται σε σημεία. Υλικό πλαστικό, ισοζυγισμένος φωτισμός που περιστρέφεται 40 μοίρες γύρω από τον άξονα Z και προοπτική κάμερα ορίζουν την εμφάνιση:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Το προκύπτον σχήμα:

![Το 3Δ εφέ του σχήματος](shape_3D_effect.png)

Το παράδειγμα εφαρμόζει παρόμοια 3Δ μορφοποίηση στο κείμενο μέσω [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Μικρότερες λοξοτομίες διαμορφώνουν τις άκρες των γραμμάτων, ενώ η εξώθηση και ο φωτισμός δίνουν βάθος στο κείμενο:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Το προκύπτον κείμενο:

![Το 3Δ εφέ του κειμένου](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Η εφαρμογή 3Δ εφέ σε κείμενο ή στα σχήματά του—και η αλληλεπίδραση μεταξύ αυτών των εφέ—ρυθμίζεται από συγκεκριμένους κανόνες. Σκεφτείτε μια σκηνή που περιλαμβάνει τόσο το κείμενο όσο και το σχήμα που το περιέχει. Ένα 3Δ εφέ περιλαμβάνει την 3Δ αναπαράσταση του αντικειμένου και τη σκηνή στην οποία τοποθετείται.

- Εάν έχει οριστεί σκηνή για το σχήμα και για το κείμενο, η σκηνή του σχήματος έχει προτεραιότητα και η σκηνή του κειμένου αγνοείται.
- Εάν το σχήμα δεν έχει τη δική του σκηνή αλλά διαθέτει 3Δ αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου.
- Εάν το σχήμα δεν έχει καθόλου 3Δ εφέ, θεωρείται επίπεδο και το 3Δ εφέ εφαρμόζεται μόνο στο κείμενο.

Αυτές οι συμπεριφορές σχετίζονται με τις μεθόδους [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getLightRig) και [ThreeDFormat.getCamera](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

Για να κρατήσετε το κείμενο επίπεδο και αναγνώσιμο ενώ διατηρείτε τη 3Δ μορφοποίηση του σχήματος, δείτε [Keep Text Flat on a 3D Shape](/slides/el/nodejs-java/3d-presentation/) για σύγκριση και ένα πλήρες παράδειγμα JavaScript.

## **Συχνές Ερωτήσεις**

**Μπορώ να χρησιμοποιήσω εφέ WordArt με διαφορετικές γραμματοσειρές ή σκριπτάκια (π.χ., Αραβικά, Κινέζικα);**

Ναι, το Aspose.Slides for Node.js via Java υποστηρίζει Unicode και λειτουργεί με όλες τις βασικές γραμματοσειρές και σκριπτάκια. Τα εφέ WordArt όπως σκιά, γέμισμα και περίγραμμα μπορούν να εφαρμοστούν ανεξάρτητα από τη γλώσσα, αν και η διαθεσιμότητα της γραμματοσειράς και η απόδοση ενδέχεται να εξαρτώνται από τις γραμματοσειρές του συστήματος.

**Μπορώ να εφαρμόσω εφέ WordArt σε στοιχεία του master slide;**

Ναι, μπορείτε να εφαρμόσετε εφέ WordArt σε σχήματα στις κύριες διαφάνειες, συμπεριλαμβανομένων των περιοχών κράτησης τίτλου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές στο master layout θα αντικατοπτρίζονται σε όλες τις σχετικές διαφάνειες.

**Επηρεάζουν τα εφέ WordArt το μέγεθος του αρχείου παρουσίασης;**

Λίγο. Εφέ όπως σκιές, λάμψεις και διαβαθμιζόμενα γεμίσματα μπορεί να αυξήσουν ελαφρά το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, αλλά η διαφορά είναι συνήθως αμελητέα.

**Μπορώ να προεπισκοπήσω το αποτέλεσμα των εφέ WordArt χωρίς αποθήκευση της παρουσίασης;**

Ναι, μπορείτε να αποδώσετε τις διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ., PNG, JPEG) χρησιμοποιώντας [Slide.getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/#getImage), ή να αποδώσετε μεμονωμένα σχήματα με [Shape.getImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/#getImage). Αυτό σας επιτρέπει να προεπισκοπήσετε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξάγετε ολόκληρη την παρουσίαση.