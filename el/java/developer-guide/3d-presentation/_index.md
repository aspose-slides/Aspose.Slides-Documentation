---
title: Δημιουργία 3D Εφέ σε Παρουσιάσεις με Χρήση Java
linktitle: 3D Παρουσίαση
type: docs
weight: 232
url: /el/java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D παρουσίαση
- 3D περιστροφή
- 3D βάθος
- 3D εξώθηση
- 3D διαβάθμιση
- 3D κείμενο
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3D εφέ για σχήματα και κείμενο PowerPoint σε Java με το Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3D κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides for Java μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει διαμορφώσεις 3D σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3D όπως περιστροφή, εξώθηση, λοξοτομή, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα εικόνας, και κείμενο 3D.

{{% alert color="info" title="Note" %}}
Αυτό το άρθρο αφορά εφέ διαμόρφωσης 3D σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία ανεξάρτητων αρχείων 3D μοντέλου. Όταν εξάγετε μια διαφάνεια ως εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3D στην εξαγόμενη 2D έξοδο.
{{% /alert %}}

## **Έννοιες Διαμόρφωσης 3D**

Χρησιμοποιήστε τη μέθοδο [IShape.getThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getThreeDFormat--) για να εφαρμόσετε διαμόρφωση 3D σε ένα σχήμα. Η μέθοδος επιστρέφει το [IThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/), το οποίο ελέγχει τη σκηνή 3D για αυτό το σχήμα.

Για κείμενο, χρησιμοποιήστε τη μέθοδο [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Αυτό εφαρμόζει διαμόρφωση 3D στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Τα πιο σημαντικά μέλη του API είναι:

| Μέλος API | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getCamera--) | Προβολή, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο στο 3D χώρο ή ταιριάξτε μια προεπιλογή περιστροφής 3D του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getLightRig--) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε πώς εμφανίζονται οι αντανακλάσεις και οι σκιές στην επιφάνεια 3D. |
| [getMaterial](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getMaterial--) και [setMaterial](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, πιο μαλακή, γυαλιστερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) και [setExtrusionHeight](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Πόσο μακριά εκτείνεται το σχήμα προς τα πίσω από την μπροστινή του πλευρά. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατά παχύ 3D αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Χρώμα των εξωτερικών πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με το μπροστινό γέμισμα. |
| [getDepth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getDepth--) και [setDepth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Επιπλέον βάθος 3D που χρησιμοποιείται από τη διαμορφωση 3D του PowerPoint. | Ρυθμίστε το βάθος για σχήματα ή κείμενο, ιδίως μαζί με ρυθμίσεις λοξοτομίας και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getBevelTop--) και [getBevelBottom](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Ύψωμα ή στρογγυλεμένες άκρες στην μπροστινή και πίσω πλευρά. | Προσθέστε μια μαλακωμένη ή υψωμένη άκρη αντί για μια αιχμηρή επίπεδη πλευρά. |
| [getContourColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getContourColor--) και [getContourWidth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getContourWidth--) και [setContourWidth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Περίγραμμα γύρω από το 3D αντικείμενο. | Τονίστε το όριο του αντικειμένου στην αποδομένη έξοδο. |

## **Δημιουργία Σχήματος 3D**

Ένα σχήμα συνήθως χρειάζεται τέσσερα είδη ρυθμίσεων πριν φαίνεται πειστικά 3D:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προβολή από μπροστά μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις πλευρές και τις όψεις αναγώσιμες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει πώς αποδίδεται το φως.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην μπροστινή του πλευρά και εφαρμόζει διαμορφωση 3D. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες, και το ύψος εξώθησης είναι 100 μονάδες. Το παράδειγμα αποδίδει τη διαφάνεια ως εικόνα PNG δύο φορές τις προεπιλεγμένες διαστάσεις της και αποθηκεύει την παρουσίαση ως PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αποδομένη εικόνα της διαφάνειας δείχνει το ορθογώνιο ως ένα παχύ 3D μπλοκ:

![Αποδομένο μπλε 3D ορθογώνιο με λευκό 3D κείμενο στην μπροστινή πλευρά](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η περιστροφή 3D ρυθμίζεται από το πλαίσιο 3-D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στις περιστροφές που ορίζετε μέσω του API της κάμερας.

![Πλαίσιο 3-D Rotation του PowerPoint με επισημασμένες τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, προσπελάστε την κάμερα μέσω του [IThreeDFormat.getCamera](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getCamera--). Αυτό το παράδειγμα δημιουργεί ένα ορθογώνιο, επιλέγει ορθογραφική προοπτική από μπροστά, και θέτει τις περιστροφές X, Y, Z σε 20, 30 και 40 μοίρες, αντίστοιχα. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2D σχήματος στη διαφάνεια. Αλλάζει την 3D προοπτική που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από τη μπροστινή πλευρά. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint συνδεδεμένοι με τις ιδιότητες χρώματος και ύψους εξώθησης](img_02_02.png)

Χρησιμοποιήστε το [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) για να ορίσετε το πάχος και το [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) για να έχετε πρόσβαση στο χρώμα των πλευρών. Αυτό το παράδειγμα δίνει στο ορθογώνιο εξώθηση 100 μονάδων με μώβ πλευρές και περιστρέφει την κάμερα για να αποκαλύψει το πάχος του. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Η μέθοδος [IThreeDFormat.setDepth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#setDepth-double-) ορίζει το βάθος ενός 3D σχήματος. Η μέθοδος [setExtrusionHeight](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ελέγχει το ύψος του εφέ εξώθησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση Διαβαθμίσεων ή Γεμίσματος Εικόνας με Εφέ 3D**

Η διαμόρφωση 3D είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε μονόχρωμο γέμισμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην μπροστινή πλευρά και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Το παράδειγμα αυτό εφαρμόζει μια διαβάθμιση από μπλε σε πορτοκαλί στην μπροστινή πλευρά και ένα σκούρο πορτοκαλί χρώμα στην εξώθηση 150 μονάδων. Οι στάσεις της διαβάθμισης στα 0 και 100 υποδεικνύουν την αρχή και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες. Η διαφάνεια αποδίδεται ως εικόνα PNG δύο φορές τις προεπιλεγμένες διαστάσεις:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Αποδομένο 3D ορθογώνιο με γέμισμα διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση:

![Αποδομένο 3D ορθογώνιο με γέμισμα διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και ορίστε τη ως γέμισμα του σχήματος. Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο με όνομα "image.jpg" στον τρέχοντα φάκελο. Επεκτείνει την εικόνα ώστε να γεμίσει το ορθογώνιο, εφαρμόζει εξώθηση 150 μονάδων, και θέτει την περιστροφή της κάμερας σε μοίρες. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Αποδομένο 3D ορθογώνιο με γέμισμα φωτογραφίας στην μπροστινή πλευρά και πορτοκαλί εξώθηση:

![Αποδομένο 3D ορθογώνιο με γέμισμα φωτογραφίας στην μπροστινή πλευρά και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Διαμόρφωσης 3D σε Κείμενο**

Η διαμόρφωση 3D του σχήματος επηρεάζει το σώμα του σχήματος. Η διαμόρφωση 3D του κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ παρόμοια με WordArt όπου τα γράμματα απαιτούν εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με μοτίβο πλέγματος πορτοκαλί-λευκό, εφαρμόζει ένα ανοδικό τόξο, και διαμορφώνει τις ρυθμίσεις 3D μέσω του [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Το ύψος εξώθησης και το βάθος είναι σε μονάδες, και η περιστροφή φωτός σε μοίρες. Το γέμισμα και το περίγραμμα του σχήματος είναι κρυμμένα ώστε μόνο το κείμενο να είναι ορατό. Το παράδειγμα αποδίδει μια εικόνα PNG δύο φορές τις προεπιλεγμένες διαστάσεις της διαφάνειας και αποθηκεύει την παρουσίαση ως PPTX:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αποδομένο 3D κείμενο με καμπύλο μετασχηματισμό WordArt, γέμισμα μοτίβου πορτοκαλί και σκούρα εξώθηση:

![Αποδομένο 3D κείμενο με καμπύλο μετασχηματισμό WordArt, γέμισμα μοτίβου πορτοκαλί και σκούρα εξώθηση](img_02_05.png)

## **Διατήρηση Κειμένου Επίπεδου σε Σχήμα 3D**

Για να διατηρήσετε το κείμενο αναγνώσιμο ενώ διατηρείται η 3D εμφάνιση του σχήματος, καλέστε το [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) μέσω του [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#getTextFrameFormat--). Όταν η τιμή είναι `true`, το κείμενο παραμένει εκτός της σκηνής 3D. Όταν είναι `false`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί τον 3D προσανατολισμό της.

Αυτή η ρύθμιση δεν αφαιρεί τη διαμόρφωση 3D του σχήματος: την κάμερα, τον φωτισμό, το υλικό και την εξώθηση παραμένουν ρυθμισμένα μέσω του [IShape.getThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getThreeDFormat--). Είναι επίσης διαφορετική από την κανονική περιστροφή. Το [IShape.setRotation](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#setRotation-float-) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ το [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου μέσα στο πλαίσιο του. Η διατήρηση του κειμένου εκτός της σκηνής 3D δεν επαναφέρει κανένα από αυτά τα άκρα.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το κλωνοποιεί δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια διαμόρφωση 3D· μόνο η ρύθμιση κειμένου διαφέρει: `false` στα αριστερά και `true` στα δεξιά. Οι γωνίες της κάμερας είναι σε μοίρες, και το ύψος εξώθησης είναι 40 μονάδες. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σύγκρισης ως PNG δύο φορές τις προεπιλεγμένες διαστάσεις.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Παρτίδες 3D ορθογωνίων: το κείμενο ακολουθεί την 3D προσανατολισμό στα αριστερά και παραμένει επίπεδο στα δεξιά:

![Παρτίδες 3D ορθογωνίων: το κείμενο ακολουθεί την 3D προσανατολισμό στα αριστερά και παραμένει επίπεδο στα δεξιά](keep_text_flat.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη διαμόρφωση 3D κατά την αποθήκευση σε μορφές PowerPoint όπως PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερού layout, η σκηνή 3D ραστεροποιείται ή σχεδιάζεται στην έξοδο ως 2D αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/java/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/java/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/java/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [video conversion](/slides/el/java/convert-powerpoint-to-video/).

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γεμίσματος και κλιμάκωσης της διαφάνειας.
- Αν χρειάζεται να ελέγξετε τις κληρονομημένες ή βασισμένες στο θέμα τιμές διαμόρφωσης, διαβάστε τις [effective shape properties](/slides/el/java/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη διαμόρφωση 3D του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3D.

## **FAQ**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3D παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3D του PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή HTML σελίδες διαδραστικές 3D σκηνές που ο θεατής να μπορεί να τις περιστρέψει. Στο PPTX, η διαμόρφωση 3D παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή τη υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ ενός 3D μοντέλου και ενός 3D εφέ;**

Ένα 3D μοντέλο είναι ένα ξεχωριστό αντικείμενο 3D που εισάγεται στην παρουσίαση. Ένα 3D εφέ είναι διαμορφωση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, λοξοτομή, φωτισμό και υλικό. Αυτό το άρθρο καλύπτει εφέ 3D.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό σχήμα 3D;**

Ελάχιστα, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτισμό και υλικό ώστε οι αποδομένες όψεις να έχουν καθαρούς αντανακλάσεις και σκιές.

**Μπορώ να εφαρμόσω εφέ 3D τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [IShape.getThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/#getThreeDFormat--) για το σώμα του σχήματος και το [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) για το κείμενο.

**Θα εμφανιστούν τα εφέ 3D κατά την εξαγωγή σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα εφέ 3D όταν παράγει εικόνες διαφανειών, εξαγόμενο PDF, HTML, και καρέ για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδομένη εμφάνιση, όχι ένα επεξεργάσιμο αντικείμενο 3D.

**Μπορώ να διαβάσω τις τελικές τιμές 3D μετά την κληρονόμηση και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής διαμόρφωσης που περιγράφονται στο [Shape Effective Properties](/slides/el/java/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, λοξοτομίας και σχετικών 3D τιμών.