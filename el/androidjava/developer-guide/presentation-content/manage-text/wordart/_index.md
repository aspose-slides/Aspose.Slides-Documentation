---
title: Δημιουργία και Εφαρμογή Εφέ WordArt σε Android
linktitle: WordArt
type: docs
weight: 110
url: /el/androidjava/wordart/
keywords:
- WordArt
- δημιουργία WordArt
- Πρότυπο WordArt
- Εφέ WordArt
- Εφέ σκιάς
- Εφέ αντανάκλασης
- Εφέ λάμπης
- Μετασχηματισμός WordArt
- εφέ 3Δ
- Εφέ εξωτερικής σκιάς
- Εφέ εσωτερικής σκιάς
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε εφέ WordArt στο Aspose.Slides για Android μέσω Java. Αυτός ο βήμα-βήμα οδηγός βοηθά τους προγραμματιστές να ενισχύσουν τις παρουσιάσεις με επαγγελματικό κείμενο στο Android."
---
## **Επισκόπηση**

Τα εφέ WordArt επιτρέπουν να μορφοποιήσετε το κείμενο με γεμίσεις, περιγράμματα, σκίες, αντανακλάσεις, λάμψη, μετασχηματισμούς και 3D μορφοποίηση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να προσαρμόσετε αυτά τα εφέ σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides for Android via Java, χωρίς να είναι εγκατεστημένο το Microsoft Office.

## **Δημιουργία ενός Απλού Προτύπου WordArt και Εφαρμογή του σε Κείμενο**

Τα παρακάτω παραδείγματα δημιουργούν ένα απλό στυλ WordArt ορίζοντας το κείμενο, τη γραμματοσειρά, τη γεμιστική μορφή και το περίγραμμα.

Κάθε παράδειγμα δημιουργεί μια νέα παρουσίαση και προσθέτει ένα ορθογώνιο στη πρώτη διαφάνειά της· δεν απαιτείται αρχείο εισόδου. Το πρώτο παράδειγμα ορίζει το κείμενο σε "Aspose.Slides". Η θέση και οι διαστάσεις του σχήματος μετρώνται σε σημεία:

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

Ορίστε τη γραμματοσειρά σε Arial Black σε μέγεθος 36 σημείων για να γίνει η μορφοποίηση πιο εμφανής:

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

Εφαρμόστε ένα μοτίβο [SmallGrid](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/patternstyle/#SmallGrid) με σκοτεινό πορτοκαλί προσκήνιο και λευκό φόντο, στη συνέχεια προσθέστε ένα μαύρο περίγραμμα κειμένου με πλάτος 1 σημείου:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int darkOrange = Color.rgb(255, 140, 0);
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

Το προκύπτον κείμενο:

![Το απλό πρότυπο WordArt](WordArt_template.png)

## **Εφαρμογή Άλλων Εφέ WordArt**

Τα παρακάτω παραδείγματα δείχνουν πώς να εφαρμόζετε σκίες, αντανακλάσεις, λάμψη, μετασχηματισμούς και 3D εφέ σε κείμενο.

### **Εφαρμογή Εξωτερικών Σκιών**

Μια εξωτερική σκιά προσθέτει βάθος τοποθετώντας μια σκιά πίσω από το κείμενο. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση, την ακτίνα θώματος, την κλίμακα και την κλίση της.

Αυτό το παράδειγμα καλεί τη μέθοδο [enableOuterShadowEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effectformat/#enableOuterShadowEffect--) και ορίζει μια μαύρη σκιά με ακτίνα θώματος 4 σημείου, κατεύθυνση 230 μοιρών και απόσταση 30 σημείων. Τιμές κλίμακας 100 διατηρούν το μέγεθος της σκιάς, ενώ η οριζόντια κλίση την κλίνει κατά 20 μοίρες. Η μετατροπή άλφα ορίζει τη διαφάνειά της στο 32%:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Το προκύπτον κείμενο:

![Το εφέ εξωτερικής σκιάς](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Όταν χρησιμοποιούνται μαζί εξωτερικές και προκαθορισμένες σκιές, εφαρμόζεται μόνο η εξωτερική σκιά.
- Αν χρησιμοποιούνται ταυτόχρονα εξωτερικές και εσωτερικές σκιές, το αποτέλεσμα εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013, το εφέ διπλασιάζεται, ενώ στο PowerPoint 2007 εφαρμόζεται μόνο η εξωτερική σκιά.
{{% /alert %}}

### **Εφαρμογή Εφέ Αντανάκλασης**

Μια αντανάκλαση δημιουργεί ένα κατοπτρικό αντίγραφο του κειμένου. Ρυθμίστε τη θέση, την κλίμακα, την θόλωση και τη διαφάνεια για να ελέγξετε την εμφάνισή της.

Αυτό το παράδειγμα καλεί τη μέθοδο [enableReflectionEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effectformat/#enableReflectionEffect--) και αναστρέφει την αντανάκλαση κατακόρυφα με κλίμακα -100%. Χρησιμοποιεί ακτίνα θώματος 0,5 σημείου και απόσταση 4,72 σημείου. Η διαφάνεια μειώνεται από 60% σε 0,9% μεταξύ θέσεων 0% και 60% κατά μήκος της αντανάκλασης:

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

Το προκύπτον κείμενο:

![Το εφέ αντανάκλασης](reflection_effect.png)

### **Εφαρμογή Εφέ Λάμψης**

Μια λάμψη προσθέτει ένα απαλό χρωματιστό περίγραμμα γύρω από το κείμενο. Ρυθμίστε το χρώμα, τη διαφάνεια και την ακτίνα για να ελέγξετε το εφέ.

Αυτό το παράδειγμα καλεί τη μέθοδο [enableGlowEffect](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/effectformat/#enableGlowEffect--) και εφαρμόζει κόκκινη λάμψη με διαφάνεια 54% και ακτίνα 7 σημείων:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Το προκύπτον κείμενο:

![Το εφέ λάμψης](glow_effect.png)

### **Εφαρμογή Μετασχηματισμών WordArt**

Οι μετασχηματισμοί WordArt λυγίζουν, τεντώνουν ή παραμορφώνουν ένα τμήμα κειμένου.

Ορίστε το [setTransform](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframeformat/#setTransform-int-) σε [ArchUpPour](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textshapetype/#ArchUpPour) για να κυρτώνετε το πλήρες πλαίσιο κειμένου προς τα πάνω:

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

Το προκύπτον κείμενο:

![Ο μετασχηματισμός WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Το Aspose.Slides for Android via Java παρέχει ένα σύνολο προεπιλεγμένων [τύποι μετασχηματισμού](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textshapetype/).
{{% /alert %}}

### **Εφαρμογή 3D Εφέ σε Σχήματα και Κείμενο**

Μπορείτε να εφαρμόσετε 3D εφέ σε ένα σχήμα ή στο κείμενό του. Οι γωνίες, η εξώθηση, ο φωτισμός και οι ρυθμίσεις κάμερας ελέγχουν την τελική εμφάνιση.

Το παρακάτω παράδειγμα χρησιμοποιεί το [ThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/threedformat/) για να προσθέσει κυκλικές γωνίες, πορτοκαλί εξώθηση και σκούρο κόκκινο περίγραμμα στο ορθογώνιο. Οι διαστάσεις των γωνιών, το ύψος εξώθησης, το πλάτος και το βάθος του περιγράμματος μετρώνται σε σημεία. Ένα πλαστικό υλικό, ισορροπημένο φωτισμό με περιστροφή 40 μοιρών γύρω από τον άξονα Z, και μια προοπτική κάμερα ορίζουν την εμφάνιση του:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int orange = Color.rgb(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
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

Το προκύπτον σχήμα:

![Το 3D εφέ του σχήματος](shape_3D_effect.png)

Αυτό το παράδειγμα εφαρμόζει παρόμοια 3D μορφοποίηση στο κείμενο μέσω του [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textframeformat/#getThreeDFormat--). Μικρότερες γωνίες διαμορφώνουν τις άκρες των γραμμάτων, ενώ η εξώθηση και ο φωτισμός δίνουν βάθος στο κείμενο:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int orange = Color.rgb(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
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

Το προκύπτον κείμενο:

![Το 3D εφέ του κειμένου](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Η εφαρμογή 3D εφέ σε κείμενο ή στα σχήματά τους —και η αλληλεπίδραση μεταξύ αυτών των εφέ— διέπεται από συγκεκριμένους κανόνες. Σκεφτείτε μια σκηνή που περιλαμβάνει τόσο το κείμενο όσο και το σχήμα που το περιέχει. Ένα 3D εφέ περιλαμβάνει την 3D αναπαράσταση του αντικειμένου και τη σκηνή στην οποία τοποθετείται.

- Αν οριστεί σκηνή τόσο για το σχήμα όσο και για το κείμενο, η σκηνή του σχήματος έχει προτεραιότητα και η σκηνή του κειμένου αγνοείται.
- Αν το σχήμα δεν έχει τη δική του σκηνή αλλά έχει 3D αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου.
- Αν το σχήμα δεν έχει καθόλου 3D εφέ, θεωρείται επίπεδο και το 3D εφέ εφαρμόζεται μόνο στο κείμενο.

Αυτές οι συμπεριφορές σχετίζονται με τις μεθόδους [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/threedformat/#getLightRig--) και [ThreeDFormat.getCamera](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Για να κρατήσετε το κείμενο επίπεδο και ευανάγνωστο διατηρώντας ταυτόχρονα τη 3D μορφοποίηση του σχήματος, δείτε το [Keep Text Flat on a 3D Shape](/slides/el/androidjava/3d-presentation/) για σύγκριση των δύο ρυθμίσεων και ένα πλήρες παράδειγμα Java.

## **Συχνές Ερωτήσεις**

**Μπορώ να χρησιμοποιήσω εφέ WordArt με διαφορετικές γραμματοσειρές ή σύμβολα (π.χ. αραβικά, κινέζικα);**

Ναι, το Aspose.Slides for Android via Java υποστηρίζει Unicode και λειτουργεί με όλες τις κύριες γραμματοσειρές και σύμβολα. Τα εφέ WordArt όπως σκιά, γέμισμα και περίγραμμα μπορούν να εφαρμοστούν ανεξαρτήτως γλώσσας, αν και η διαθεσιμότητα γραμματοσειράς και η απόδοση μπορεί να εξαρτώνται από τις γραμματοσειρές του συστήματος.

**Μπορώ να εφαρμόσω εφέ WordArt σε στοιχεία του master slide;**

Ναι, μπορείτε να εφαρμόσετε εφέ WordArt σε σχήματα των master slides, συμπεριλαμβανομένων των θέσεων τίτλου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές στο master layout αντικατοπτρίζονται σε όλες τις σχετικές διαφάνειες.

**Επηρεάζουν τα εφέ WordArt το μέγεθος του αρχείου παρουσίασης;**

Λίγο. Τα εφέ WordArt όπως σκιές, λάμψεις και γεμίσματα διαβάθμισης μπορεί να αυξήσουν ελαφρώς το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, αλλά η διαφορά συνήθως είναι αμελητέα.

**Μπορώ να προεπισκοπήσω το αποτέλεσμα των εφέ WordArt χωρίς να αποθηκεύσω την παρουσίαση;**

Ναι, μπορείτε να αποδώσετε τις διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ. PNG, JPEG) χρησιμοποιώντας το [ISlide.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/#getImage--), ή να αποδώσετε μεμονωμένα σχήματα με το [IShape.getImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getImage--). Αυτό σας επιτρέπει να προεπισκοπήσετε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξάγετε ολόκληρη την παρουσίαση.