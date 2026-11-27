---
title: Εφαρμογή εφέ σχήματος σε παρουσιάσεις στο Android
linktitle: Εφέ σχήματος
type: docs
weight: 30
url: /el/androidjava/shape-effect/
keywords:
- εφέ σχήματος
- εφέ σκιάς
- εφέ αντανακλαστικότητας
- εφέ λάμψης
- εφέ μαλακών άκρων
- μορφή εφέ
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μετατρέψτε τα αρχεία PPT και PPTX σας με προχωρημένα εφέ σχήματος χρησιμοποιώντας το Aspose.Slides for Android via Java—δημιουργήστε εντυπωσιακές, επαγγελματικές διαφάνειες σε δευτερόλεπτα."
---
## **Εισαγωγή**

Ενώ τα εφέ στο PowerPoint μπορούν να χρησιμοποιηθούν για να κάνετε ένα σχήμα να ξεχωρίζει, διαφέρουν από τα [fills](/slides/el/androidjava/shape-formatting/#gradient-fill) ή τα περιγράμματα. Χρησιμοποιώντας τα εφέ του PowerPoint, μπορείτε να δημιουργήσετε πειστικές αντανακλάσεις σε ένα σχήμα, να διαχέσετε το φως ενός σχήματος κ.λπ.

![Εφέ σχήματος](shape-effect.png)

Το PowerPoint παρέχει έξι εφέ που μπορούν να εφαρμοστούν σε σχήματα. Μπορείτε να εφαρμόσετε ένα ή περισσότερα εφέ σε ένα σχήμα.

Κάποιους συνδυασμούς εφέ φαίνονται καλύτεροι από άλλους. Για αυτό το λόγο, το PowerPoint προσφέρει επιλογές κάτω από **Preset**. Οι επιλογές Preset είναι συνδυασμοί δύο ή περισσότερων εφέ που είναι γνωστό ότι φαίνονται καλά. Με αυτόν τον τρόπο, επιλέγοντας ένα preset, δεν θα χρειαστεί να ξοδέψετε χρόνο δοκιμάζοντας ή συνδυάζοντας διαφορετικά εφέ για να βρείτε έναν καλό συνδυασμό.

Aspose.Slides παρέχει ιδιότητες και μεθόδους στην κλάση [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) που σάς επιτρέπουν να εφαρμόζετε τα ίδια εφέ σε σχήματα σε παρουσιάσεις PowerPoint.

## **Εφαρμογή εφέ σκιάς**

Aspose.Slides for Android via Java υποστηρίζει εξωτερικές και εσωτερικές σκιές για σχήματα. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θολώσεως ώστε να ταιριάζουν με το σχέδιο της παρουσίασής σας.

### **Εφαρμογή εξωτερικής σκιάς**

Χρησιμοποιήστε μια εξωτερική σκιά για να κάνετε μια κάρτα ή έναν πίνακα να ξεχωρίζει από το φόντο της διαφάνειας. Η σκιά εκτείνεται πέρα από τις άκρες του σχήματος, δημιουργώντας την εντύπωση ότι το σχήμα είναι ανασηκωμένο πάνω από τη διαφάνεια. Ρυθμίστε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θολώσεως ώστε να ταιριάζουν με το φωτισμό και το στυλ του προτύπου σας.

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το [outer shadow effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) σε ένα ορθογώνιο:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Εφέ σκιάς](shadow_effect.png)

#### **Έλεγχος της κατεύθυνσης της σκιάς όταν το σχήμα περιστρέφεται**

Από προεπιλογή, η εξωτερική σκιά περιστρέφεται μαζί με το σχήμα. Για να φαίνονται σχήματα με διαφορετικές περιστροφές φωτισμένα από την ίδια κατεύθυνση, καλέστε το [setRotateShadowWithShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) με `false` και χρησιμοποιήστε το [setDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setDirection-float-) για να δώσετε στις σκιές την ίδια κατεύθυνση.

Το παράδειγμα δημιουργεί δύο μπλε βέλη με γκρι σκιές μετατοπισμένες 42 σημεία προς τα δεξιά (0°). Στη συνέχεια αντιγράφει τη διαφάνεια και περιστρέφει και τα δύο βέλη κατά 90° δεξιόστροφα.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(128, 128, 128));
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    IShape right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    ISlide after = presentation.getSlides().addClone(before);
    for (IShape arrow : after.getShapes()) {
        arrow.setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Στη δεύτερη διαφάνεια, το αριστερό βέλος ρίχνει τη σκιά του προς τα κάτω, ενώ το δεξιό βέλος συνεχίζει να ρίχνει τη σκιά του προς τα δεξιά. Η ρυθμισμένη κατεύθυνση παραμένει 0° και για τις δύο σκιές.

![Απόδοση PowerPoint πριν και μετά από περιστροφή 90°. Και οι δύο σκιές ξεκινούν στα δεξιά. Μετά την περιστροφή, η σκιά μετακινείται κάτω από το αριστερό βέλος και παραμένει δεξιά του δεξιού βέλους.](arrow-shadow-rotation.png)

### **Εφαρμογή εσωτερικής σκιάς**

Κατά την αναπαραγωγή του οπτικού στυλ ενός προτύπου, χρησιμοποιήστε μια εσωτερική σκιά για να δώσετε σε μια κάρτα ή έναν πίνακα μια εσοπτική εμφάνιση. Μια εξωτερική σκιά εκτείνεται έξω από το σχήμα και το κάνει να φαίνεται ανασηκωμένο, ενώ μια εσωτερική σκιά σκιάζει το εσωτερικό των άκρων του.

Καλέστε το [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--), έπειτα διαμορφώστε τη σκιά που επιστρέφεται από το [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). Μεγαλύτερες τιμές ακτίνας θολώσεως παράγουν πιο απαλές άκρες.

Αυτό το παράδειγμα Java δημιουργεί μια ανοιχτό μπλε κάρτα με μια σκούρα γκρι εσωτερική σκιά και την αποθηκεύει ως αρχείο PPTX. Η κατεύθυνση της σκιάς είναι 225 μοίρες, η απόσταση είναι 7 σημεία και η ακτίνα θολώσεως είναι 6 σημεία:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Ανοιχτό μπλε ορθογώνιο με εσωτερική σκιά](inner_shadow_effect.png)

Για να αφαιρέσετε την εσωτερική σκιά, καλέστε το [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) στη μορφή εφέ του σχήματος.

### **Εφαρμογή, αλλαγή και αφαίρεση προεπιλεγμένης σκιάς**

Καλέστε το [enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) και χρησιμοποιήστε το [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) για να επιλέξετε έναν [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/). Για να αλλάξετε στυλ, τροποποιήστε το preset στο ίδιο σχήμα. Καλέστε το [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) για να αφαιρέσετε τη σκιά διατηρώντας το γέμισμα και το περίγραμμα.

Αυτό το παράδειγμα δείχνει τέσσερις φάσεις δίπλα-δίπλα σε μία διαφάνεια. Και οι δύο σκιές είναι μετατοπισμένες κατά 10 σημεία. Μια κατεύθυνση 225° τοποθετεί τη πρώτη σκιά πάνω και αριστερά του ορθογωνίου, και 45° τοποθετεί τη δεύτερη κάτω και δεξιά.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Αρχικό | Πρώτο προεπιλεγμένο | Δεύτερο προεπιλεγμένο | Μετά την αφαίρεση |
| :---: | :---: | :---: | :---: |
| ![Χωρίς σκιά](preset_shadow_original.png) | ![Σκιά επάνω αριστερά](preset_shadow_top_left.png) | ![Σκιά κάτω δεξιά](preset_shadow_bottom_right.png) | ![Χωρίς σκιά μετά την αφαίρεση](preset_shadow_removed.png) |

## **Εφαρμογή εφέ αντανακλαστικής**

Για να εφαρμόσετε ένα εφέ αντανακλαστικής σε Aspose.Slides for Android via Java, μπορείτε να προσθέσετε μια καθρέπτική αντανακλαστική εικόνα σε σχήματα, ρυθμίζοντας παραμέτρους όπως απόσταση, διαφάνεια και μέγεθος. Αυτό το εφέ ενισχύει την αισθητική των παρουσιάσεών σας δίνοντας στα σχήματα μια πιο καλοσχεδιασμένη και πολυτελή εμφάνιση. Είναι εύκολο στην υλοποίηση με απλό κώδικα, επιτρέποντας γρήγορη εφαρμογή σε πολλά στοιχεία για ομοιόμορφο σχεδιασμό.

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το [reflection effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) σε ένα σχήμα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Εφέ αντανακλαστικής](reflection_effect.png)

## **Εφαρμογή εφέ λάμψης**

Για να εφαρμόσετε ένα εφέ λάμψης σε ένα σχήμα σε Aspose.Slides for Android via Java, μπορείτε να προσθέσετε μια απαλή, φωτεινή αύρα γύρω από τα σχήματα, ρυθμίζοντας ιδιότητες όπως χρώμα και μέγεθος. Αυτό το εφέ βοηθά τα σχήματα να ξεχωρίζουν και προσθέτει ένα ελκυστικό, εντυπωσιακό οπτικό στοιχείο στην παρουσίασή σας. Είναι εύκολο στην υλοποίηση με ελάχιστο κώδικα, βελτιώνοντας τη συνολική εμφάνιση των διαφανειών σας.

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το [glow effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) σε ένα σχήμα:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Εφέ λάμψης](glow_effect.png)

## **Εφαρμογή εφέ μαλακών άκρων**

Για να εφαρμόσετε ένα εφέ μαλακών άκρων σε Aspose.Slides for Android via Java, μπορείτε να δημιουργήσετε μια ομαλή, θολή μετάβαση γύρω από τις άκρες ενός σχήματος. Αυτό το εφέ προσθέτει μια πιο διακριτική και εκλεπτυσμένη εμφάνιση, ιδανική για σχέδια που χρειάζονται ήπια, απαλή εμφάνιση. Μπορείτε εύκολα να ρυθμίσετε παραμέτρους όπως η ακτίνα για να πετύχετε το επιθυμητό αποτέλεσμα σε διάφορα σχήματα της παρουσίασής σας.

Αυτός ο κώδικας Java δείχνει πώς να εφαρμόσετε το [soft edges effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) σε ένα σχήμα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Εφέ μαλακών άκρων](soft_edges_effect.png)

## **Εφαρμογή εφέ θολώσεως**

Χρησιμοποιήστε θόλωση σχήματος για να απαλύνει το γέμισμα και το περίγραμμα ενός σχήματος, διατηρώντας το σχήμα επεξεργάσιμο. Καλέστε το [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) στη μορφή εφέ του σχήματος. Η ακτίνα μετράται σε σημεία (1/72 ίντσα): χρησιμοποιήστε μη αρνητική τιμή· μεγαλύτερες τιμές παράγουν ισχυρότερη θόλωση. Μια ακτίνα μηδέν αφήνει την εμφάνιση αμετάβλητη.

Η ρύθμιση [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) ελέγχει τα ορατά όρια του εφέ. Με `false`, η θόλωση περιορίζεται στα αρχικά χρωματισμένα όρια, συμπεριλαμβανομένου του περιγράμματος. Με `true`, η θόλωση μπορεί να εκτείνεται πέρα από αυτά τα όρια. Κανένα από τα δύο δεν αλλάζει τη θέση ή τις διαστάσεις του σχήματος.

Η σύγκριση παρακάτω χρησιμοποιεί το ίδιο γέμισμα, περίγραμμα και διαστάσεις σχήματος σε όλη τη διάρκεια. Η πρώτη σειρά χρησιμοποιεί `grow = false`; η δεύτερη σειρά χρησιμοποιεί `grow = true`.

![Αρχικό ορθογώνιο συγκρινόμενο με ακτίνες θολώσεως 5 και 15 σημείων, με grow απενεργοποιημένο και ενεργοποιημένο](shape_blur_comparison.png)

Αυτό το παράδειγμα Java δημιουργεί ένα πορτοκαλί ορθογώνιο με σκούρο μπλε περίγραμμα, εφαρμόζει θόλωση 5 σημείων, και στη συνέχεια το ενημερώνει σε θόλωση 15 σημείων καλώντας ξανά το [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Αποθηκεύει και τις δύο θολωμένες καταστάσεις, μετά καλεί το [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) και αποθηκεύει το σχήμα χωρίς θόλωση.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η θόλωση σχήματος επηρεάζει ταυτόχρονα το γέμισμα και το περίγραμμα. Το εφέ μαλακών άκρων ξεθωριάζει τις άκρες του σχήματος, ενώ η θόλωση σκιάς απαλύνει μόνο τη σκιά. Τα εφέ μετασχηματισμού εικόνας λειτουργούν πάνω στο περιεχόμενο της εικόνας· αυτό το παράδειγμα εφαρμόζει θόλωση απευθείας στη μορφή εφέ του σχήματος χωρίς μετατροπή του σχήματος σε εικόνα.

## **Συχνές ερωτήσεις**

**Μπορώ να εφαρμόσω πολλαπλά εφέ στο ίδιο σχήμα;**

Ναι, μπορείτε να συνδυάσετε διαφορετικά εφέ, όπως σκιά, αντανακλαστική και λάμψη, σε ένα μόνο σχήμα για να δημιουργήσετε μια πιο δυναμική εμφάνιση.

**Σε ποια σχήματα μπορώ να εφαρμόσω εφέ;**

Μπορείτε να εφαρμόζετε εφέ σε διάφορα σχήματα, συμπεριλαμβανομένων των αυτόματων σχημάτων, γραφημάτων, πινάκων, εικόνων, αντικειμένων SmartArt, αντικειμένων OLE και άλλα.

**Μπορώ να εφαρμόσω εφέ σε ομαδοποιημένα σχήματα;**

Ναι, μπορείτε να εφαρμόσετε εφέ σε ομαδοποιημένα σχήματα. Το εφέ θα εφαρμοστεί σε ολόκληρη την ομάδα.