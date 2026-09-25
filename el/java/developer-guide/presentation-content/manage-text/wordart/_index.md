---
title: Δημιουργία και Εφαρμογή Εφέ WordArt σε Java
linktitle: WordArt
type: docs
weight: 110
url: /el/java/wordart/
keywords:
- WordArt
- δημιουργία WordArt
- πρότυπο WordArt
- εφέ WordArt
- εφέ σκιάς
- εφέ αντανάκλασης
- εφέ λάμψης
- μετασχηματισμός WordArt
- 3D εφέ
- εξωτερικό εφέ σκιάς
- εσωτερικό εφέ σκιάς
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε εφέ WordArt στο Aspose.Slides για Java. Αυτός ο οδηγός βήμα προς βήμα βοηθά τους προγραμματιστές να βελτιώσουν τις παρουσιάσεις με επαγγελματικό κείμενο σε Java."
---
## **Επισκόπηση**

Οι εφέ WordArt σάς επιτρέπουν να μορφοποιείτε κείμενο με γεμίσματα, περιγράμματα, σκιές, αντανακλάσεις, λάμψη, μετασχηματισμούς και 3D μορφοποίηση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να προσαρμόσετε αυτά τα εφέ σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides for Java, χωρίς εγκατεστημένο το Microsoft Office.

## **Δημιουργία ενός Απλού Προτύπου WordArt και Εφαρμογή του σε Κείμενο**

Τα παρακάτω παραδείγματα δημιουργούν ένα απλό στυλ WordArt ορίζοντας το κείμενο, τη γραμματοσειρά, το γεμάτο μοτίβο και το περίγραμμα.

Κάθε παράδειγμα δημιουργεί μια νέα παρουσίαση και προσθέτει ένα ορθογώνιο στο πρώτο της διαφάνεια· δεν απαιτείται αρχείο εισόδου. Το πρώτο παράδειγμα ορίζει το κείμενο στο "Aspose.Slides". Η θέση και οι διαστάσεις του σχήματος μετρώνται σε μονάδες (points):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Ορίστε τη γραμματοσειρά σε Arial Black με μέγεθος 36 points ώστε η μορφοποίηση να είναι πιο εμφανής:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Εφαρμόστε ένα μοτίβο [SmallGrid](https://reference.aspose.com/slides/el/java/com.aspose.slides/patternstyle/#SmallGrid) με προσοχή σκουρόλεπτο πορτοκαλί στο προσκήνιο και λευκό φόντο, έπειτα προσθέστε μαύρο περίγραμμα κειμένου με πλάτος 1 point:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color darkOrange = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

Το απλό πρότυπο WordArt:

![Το απλό πρότυπο WordArt](WordArt_template.png)

## **Εφαρμογή Άλλων Εφέ WordArt**

Τα παρακάτω παραδείγματα δείχνουν πώς να εφαρμόζετε σκιές, αντανακλάσεις, λάμψη, μετασχηματισμούς και 3D εφέ στο κείμενο.

### **Εφαρμογή Εξωτερικών Σκιών**

Μια εξωτερική σκιά προσθέτει βάθος τοποθετώντας μια σκιά πίσω από το κείμενο. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση, την ακτίνα θολώματος, την κλίμακα και την παραμόρφωση.

Αυτό το παράδειγμα καλεί την [enableOuterShadowEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--) και ορίζει μια μαύρη σκιά με ακτίνα θολώματος 4 points, κατεύθυνση 230 μοίρες και απόσταση 30 points. Οι τιμές κλίμακας 100 διατηρούν το μέγεθος της σκιάς, ενώ η οριζόντια παραμόρφωση την κλίνει κατά 20 μοίρες. Η μετασχηματισμός άλφα ορίζει την αδιαφάνεια της στο 32%:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

Το εφέ Εξωτερικής Σκιάς:

![Το εφέ Εξωτερικής Σκιάς](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Όταν χρησιμοποιούνται ταυτόχρονα εξωτερικές και προεγκατεστημένες σκιές, εφαρμόζεται μόνο η εξωτερική σκιά.
- Εάν χρησιμοποιηθούν ταυτόχρονα εξωτερικές και εσωτερικές σκιές, το αποτέλεσμα εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013 το εφέ διπλασιάζεται, ενώ στο PowerPoint 2007 εφαρμόζεται μόνο η εξωτερική σκιά.
{{% /alert %}}

### **Εφαρμογή Εφέ Αντανάκλασης**

Μία αντανάκλαση δημιουργεί ένα καθρέφτη του κειμένου. Ρυθμίστε τη θέση, την κλίμακα, το θόλωμα και τη διαφάνεια για να ελέγξετε την εμφάνισή της.

Αυτό το παράδειγμα καλεί την [enableReflectionEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/effectformat/#enableReflectionEffect--) και αναστρέφει την αντανάκλαση κατακόρυφα με κλίμακα -100%. Χρησιμοποιεί ακτίνα θολώματος 0,5 point και απόσταση 4,72 point. Η διαφάνεια μειώνεται από 60% σε 0,9% μεταξύ θέσεων 0% και 60% κατά μήκος της αντανάκλασης:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

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
    presentation.dispose();
}
```

Το εφέ Αντανάκλασης:

![Το εφέ Αντανάκλασης](reflection_effect.png)

### **Εφαρμογή Εφέ Λάμψης**

Η λάμψη προσθέτει ένα απαλό πολύχρωμο περίγραμμα γύρω από το κείμενο. Ρυθμίστε το χρώμα, τη διαφάνεια και την ακτίνα για να ελέγξετε το εφέ.

Αυτό το παράδειγμα καλεί την [enableGlowEffect](https://reference.aspose.com/slides/el/java/com.aspose.slides/effectformat/#enableGlowEffect--) και εφαρμόζει κόκκινη λάμψη με διαφάνεια 54% και ακτίνα 7 points:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Το εφέ Λάμψης:

![Το εφέ Λάμψης](glow_effect.png)

### **Εφαρμογή Μετασχηματισμών WordArt**

Οι μετασχηματισμοί WordArt λυγίζουν, τεντώνονται ή παραμορφώνουν ένα σύνολο κειμένου.

Ορίστε το [setTransform](https://reference.aspose.com/slides/el/java/com.aspose.slides/textframeformat/#setTransform-int-) στην τιμή [ArchUpPour](https://reference.aspose.com/slides/el/java/com.aspose.slides/textshapetype/#ArchUpPour) ώστε να καμπυλώσετε το σύνολο του πλαισίου κειμένου προς τα πάνω:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

Ο μετασχηματισμός WordArt:

![Ο μετασχηματισμός WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Το Aspose.Slides for Java παρέχει ένα σύνολο προορισμένων τύπων [transformation types](https://reference.aspose.com/slides/el/java/com.aspose.slides/textshapetype/).
{{% /alert %}}

### **Εφαρμογή 3D Εφέ σε Σχήματα και Κείμενο**

Μπορείτε να εφαρμόσετε 3D εφέ σε ένα σχήμα ή στο κείμενό του. Οι λοξότητες, η εξώθηση, ο φωτισμός και οι ρυθμίσεις κάμερας ελέγχουν την τελική εμφάνιση.

Το παρακάτω παράδειγμα χρησιμοποιεί το [ThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/threedformat/) για να προσθέσει κυκλικές λοξότητες, πορτοκαλί εξώθηση και σκούρο κόκκινο περίγραμμα στο ορθογώνιο. Οι διαστάσεις των λοξοτήτων, το ύψος εξώθησης, το πάχος περιγράμματος και το βάθος μετρώνται σε points. Ένα πλαστικό υλικό, ισορροπημένος φωτισμός περιστρεφόμενος 40 μοίρες γύρω από τον άξονα Z, και μια κάμερα προοπτικής καθορίζουν την εμφάνισή του:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    Color orange = new Color(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Το 3D εφέ του σχήματος:

![Το 3D εφέ του σχήματος](shape_3D_effect.png)

Αυτό το παράδειγμα εφαρμόζει παρόμοια 3D μορφοποίηση στο κείμενο μέσω του [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/textframeformat/#getThreeDFormat--). Οι μικρότερες λοξότητες διαμορφώνουν τις άκρες των γραμμάτων, ενώ η εξώθηση και ο φωτισμός προσδίδουν βάθος στο κείμενο:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    Color orange = new Color(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Το 3D εφέ του κειμένου:

![Το 3D εφέ του κειμένου](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Η εφαρμογή 3D εφέ σε κείμενο ή στα σχήματά τους — και η αλληλεπίδραση μεταξύ αυτών των εφέ — διέπεται από συγκεκριμένους κανόνες. Σκεφτείτε μια σκηνή που περιλαμβάνει τόσο το κείμενο όσο και το σχήμα που το περιέχει. Ένα 3D εφέ περιλαμβάνει την 3D αναπαράσταση του αντικειμένου και τη σκηνή στην οποία τοποθετείται.

- Εάν έχει οριστεί σκηνή τόσο για το σχήμα όσο και για το κείμενο, η σκηνή του σχήματος έχει προτεραιότητα και η σκηνή του κειμένου αγνοείται.
- Εάν το σχήμα δεν έχει τη δική του σκηνή αλλά διαθέτει 3D αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου.
- Εάν το σχήμα δεν έχει καθόλου 3D εφέ, αντιμετωπίζεται ως επίπεδο και το 3D εφέ εφαρμόζεται μόνο στο κείμενο.

Αυτές οι συμπεριφορές σχετίζονται με τις μεθόδους [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/el/java/com.aspose.slides/threedformat/#getLightRig--) και [ThreeDFormat.getCamera](https://reference.aspose.com/slides/el/java/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Για να διατηρήσετε το κείμενο επίπεδο και αναγνώσιμο ενώ διατηρείτε τη 3D μορφοποίηση του σχήματος, δείτε το [Keep Text Flat on a 3D Shape](/slides/el/java/3d-presentation/) για μια σύγκριση των δύο ρυθμίσεων και ένα πλήρες παράδειγμα Java.

## **Συχνές Ερωτήσεις**

**Μπορώ να χρησιμοποιήσω εφέ WordArt με διαφορετικές γραμματοσειρές ή γραφικά (π.χ., αραβικά, κινέζικα);**

Ναι, το Aspose.Slides for Java υποστηρίζει Unicode και λειτουργεί με όλες τις κύριες γραμματοσειρές και γραφικά. Εφέ WordArt όπως σκιά, γέμισμα και περίγραμμα μπορούν να εφαρμοστούν ανεξαρτήτως της γλώσσας, αν και η διαθεσιμότητα της γραμματοσειράς και η απόδοση μπορεί να εξαρτώνται από τις γραμματοσειρές του συστήματος.

**Μπορώ να εφαρμόσω εφέ WordArt σε στοιχεία του master slide;**

Ναι, μπορείτε να εφαρμόσετε εφέ WordArt σε σχήματα στα master slides, συμπεριλαμβανομένων των placeholders τίτλου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές που γίνονται στη διάταξη του master θα αντικατοπτρίζονται σε όλες τις σχετικές διαφάνειες.

**Επηρεάζουν τα εφέ WordArt το μέγεθος του αρχείου παρουσίασης;**

Ελαφρώς. Τα εφέ WordArt όπως σκιές, λάμψεις και διαβαθμισμένα γεμίσματα μπορεί να αυξήσουν ελαφρώς το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, αλλά η διαφορά είναι συνήθως αμελητέα.

**Μπορώ να προεπισκοπήσω το αποτέλεσμα των εφέ WordArt χωρίς να αποθηκεύσω την παρουσίαση;**

Ναι, μπορείτε να αποδώσετε τις διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ., PNG, JPEG) χρησιμοποιώντας την [ISlide.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/#getImage--), ή να αποδώσετε μεμονωμένα σχήματα με την [IShape.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getImage--). Αυτό σας επιτρέπει να προεπισκοπήσετε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξάγετε ολόκληρη την παρουσίαση.