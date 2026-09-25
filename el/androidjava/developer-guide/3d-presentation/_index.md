---
title: Δημιουργία 3D Εφέ σε Παρουσιάσεις στο Android
linktitle: 3D Παρουσίαση
type: docs
weight: 232
url: /el/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Εφαρμόζετε και αποδίδετε 3D εφέ για σχήματα και κείμενο PowerPoint στο Android με το Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γέμισμα και 3D κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides για Android μέσω Java μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει 3D μορφοποίηση σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει 3D εφέ όπως περιστροφή, εξώθηση, λοξά, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα εικόνας, και 3D κείμενο.

{{% alert color="info" title="Note" %}}
Αυτό το άρθρο αφορά τις 3D μορφοποιήσεις σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή την επεξεργασία ανεξάρτητων αρχείων 3D μοντέλων. Όταν εξάγετε μια διαφάνεια ως εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα 3D εφέ στην εξαγόμενη 2D έξοδο.
{{% /alert %}}

## **Έννοιες 3D Μορφοποίησης**

Χρησιμοποιήστε τη μέθοδο [IShape.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) για να εφαρμόσετε 3D μορφοποίηση σε ένα σχήμα. Η μέθοδος επιστρέφει το [IThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/), το οποίο ελέγχει τη 3D σκηνή για εκείνο το σχήμα.

Για το κείμενο, χρησιμοποιήστε τη μέθοδο [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Αυτό εφαρμόζει 3D μορφοποίηση στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Τα πιο σημαντικά μέλη του API είναι:

| Μέλος API | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Οπτικό σημείο, προεγκατεστημένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε 3D χώρο ή ταιριάξτε ένα προεγκατεστημένο preset περιστροφής του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Προεγκατεστημένος φωτισμός, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε την εμφάνιση των ανάγλυφων και σκιών στην 3D επιφάνεια. |
| [getMaterial](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) και [setMaterial](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, πιο μαλακή, γυαλιστερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) και [setExtrusionHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από την μπροστινή του πλευρά. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατά παχύ 3D αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με το γέμισμα του προσώπου. |
| [getDepth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getDepth--) και [setDepth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Πρόσθετο 3D βάθος που χρησιμοποιείται από τη 3D μορφοποίηση του PowerPoint. | Ρυθμίστε ακριβεία το βάθος για σχήματα ή κείμενο, ειδικά μαζί με ρυθμίσεις λοξών και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) και [getBevelBottom](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Αναγλυφα ή στρογγυλεμένα άκρα στις μπροστινές και πίσω πλευρές. | Προσθέστε ένα μαλακωμένο ή διαμορφωμένο άκρο αντί για μια αιχμηρή επίπεδη πλευρά. |
| [getContourColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) και [getContourWidth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) και [setContourWidth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Περίγραμμα γύρω από το 3D αντικείμενο. | Τονίστε το όριο του αντικειμένου στην αποδοθείσα έξοδο. |

## **Δημιουργία 3D Σχήματος**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων προτού φαίνεται πειστικά 3D:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προβολή από μπροστά μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις πλευρές και τους όρθιους προσώπους αναγνώσιμους.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην μπροστινή του πλευρά και εφαρμόζει 3D μορφοποίηση. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες, και το ύψος εξώθησης είναι 100 points. Το παράδειγμα αποδίδει τη διαφάνεια σε εικόνα PNG με διπλάσιο μέγεθος από το προεπιλεγμένο και αποθηκεύει την παρουσίαση ως PPTX.

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

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

Η αποδοθείσα εικόνα της διαφάνειας δείχνει το ορθογώνιο ως ένα παχύ 3D μπλοκ:

![Αποδοθείσα μπλε 3D ορθογώνια με λευκό 3D κείμενο στην μπροστινή πλευρά](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3D περιστροφή ρυθμίζεται από το παράθυρο 3-D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στη περιστροφή που ορίζετε μέσω του API της κάμερας.

![Παράθυρο 3-D Rotation του PowerPoint με επισημασμένες τις τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, προσπελάστε την κάμερα μέσω του [IThreeDFormat.getCamera](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getCamera--). Αυτό το παράδειγμα δημιουργεί ένα ορθογώνιο, επιλέγει ορθογραφική προβολή από μπροστά και ορίζει τις περιστροφές X, Y και Z του σε 20, 30 και 40 μοίρες, αντίστοιχα. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

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

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2D σχήματος στη διαφάνεια. Αλλάζει το 3D σημείο θέασης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ, επεκτείνοντας το πίσω από την μπροστινή πλευρά. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint αντιστοιχισμένοι στις ιδιότητες χρώματος και ύψους εξώθησης](img_02_02.png)

Χρησιμοποιήστε το [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) για να ορίσετε το πάχος και το [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) για να προσπελάσετε το χρώμα των πλευρών. Αυτό το παράδειγμα δίνει σε ένα ορθογώνιο εξώθηση 100 points με μωβ πλευρές και περιστρέφει την κάμερα για να αποκαλύψει το πάχος του. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

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

Η μέθοδος [IThreeDFormat.setDepth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) ορίζει το βάθος ενός 3D σχήματος. Η μέθοδος [setExtrusionHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ελέγχει το ύψος του εφέ εξώθησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση Διαβάθμισης ή Γεμίσματος Εικόνας με 3D Εφέ**

Η 3D μορφοποίηση είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε ένα ενιαίο χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην μπροστινή πλευρά και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει μια διαβάθμιση από μπλε σε πορτοκαλί στην μπροστινή πλευρά και ένα σκούρο πορτοκαλί χρώμα στην εξώθηση 150 points. Οι στάσεις της διαβάθμισης στο 0 και 100 σηματοδοτούν την έναρξη και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες. Η διαφάνεια αποδίδεται σε εικόνα PNG με διπλάσιο μέγεθος από το προεπιλεγμένο:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    int extrusionColor = Color.rgb(255, 140, 0);
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

![Αποδοθείσα 3D ορθογώνια με γέμισμα διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και εκχωρήστε την στο γέμισμα του σχήματος. Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο με όνομα "image.jpg" στον τρέχοντα φάκελο. Τεντώνει την εικόνα ώστε να γεμίσει το ορθογώνιο, εφαρμόζει εξώθηση 150 points και ορίζει την περιστροφή της κάμερας σε μοίρες. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
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

![Αποδοθείσα 3D ορθογώνια με γέμισμα φωτογραφίας στην μπροστινή πλευρά και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή 3D Μορφοποίησης σε Κείμενο**

Η 3D μορφοποίηση σχήματος επηρεάζει το σώμα του σχήματος. Η 3D μορφοποίηση κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ παρόμοια με WordArt, όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με μοτίβο πλέγματος πορτοκαλί-λευκό, εφαρμόζει ένα ανώτερο τόξο και ρυθμίζει τις 3D ρυθμίσεις μέσω του [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Το ύψος εξώθησης και το βάθος είναι σε points, και η περιστροφή του φωτός σε μοίρες. Το γέμισμα και το περίγραμμα του σχήματος κρύβονται ώστε να είναι ορατό μόνο το κείμενο. Το παράδειγμα αποδίδει μια εικόνα PNG με διπλάσιο μέγεθος από το προεπιλεγμένο και αποθηκεύει την παρουσίαση ως PPTX:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

![Αποδοθείσες 3D κείμενο με τόξο WordArt, γέμισμα μοτίβου πορτοκαλί και σκούρα εξώθηση](img_02_05.png)

## **Διατήρηση Κειμένου Επίπεδου σε 3D Σχήμα**

Για να διατηρήσετε το κείμενο αναγνώσιμο ενώ διατηρείται η 3D εμφάνιση του σχήματος, καλέστε το [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) μέσω του [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). Όταν η τιμή είναι `true`, το κείμενο παραμένει εκτός της 3D σκηνής. Όταν είναι `false`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί τον 3D προσανατολισμό του.

Αυτή η ρύθμιση δεν αφαιρεί τη 3D μορφοποίηση του σχήματος: η κάμερα, ο φωτισμός, το υλικό και η εξώθηση παραμένουν ρυθμισμένα μέσω του [IShape.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). Είναι επίσης διαφορετική από την κοινή περιστροφή. Το [IShape.setRotation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#setRotation-float-) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ το [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου μέσα στο πλαίσιο του. Η διατήρηση του κειμένου εκτός της 3D σκηνής δεν επαναφέρει κανένα από αυτά τα γωνίες.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το κλωνοποιεί δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια 3D μορφοποίηση· μόνο η ρύθμιση κειμένου διαφέρει: `false` στα αριστερά και `true` στα δεξιά. Οι γωνίες της κάμερας είναι σε μοίρες, και το ύψος εξώθησης είναι 40 points. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σύγκρισης σε PNG με διπλάσιο μέγεθος από το προεπιλεγμένο.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
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

![Δύο 3D ορθογώνια δίπλα-δίπλα: το κείμενο ακολουθεί τον 3D προσανατολισμό στα αριστερά και παραμένει επίπεδο στα δεξιά](keep_text_flat.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη 3D μορφοποίηση κατά την αποθήκευση σε μορφές PowerPoint όπως PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερού layout, η 3D σκηνή ραστεροποιείται ή σχεδιάζεται στην έξοδο ως 2D αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/androidjava/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/androidjava/convert-powerpoint-to-html/), ή δημιουργείτε πλαίσια για [video conversion](/slides/el/androidjava/convert-powerpoint-to-video/).

Λάβετε υπόψη τα ακόλουθα:

- Οι εξαγώμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό κάμερας, φωτιστικού, υλικού, εξώθησης, γέμισματος και κλιμάκωσης διαφάνειας.
- Εάν χρειάζεται να εξετάσετε κληρονομημένες ή βασισμένες σε θέμα τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/androidjava/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη 3D μορφοποίηση PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες 3D ρυθμίσεις.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3D παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει 3D εφέ PowerPoint για σχήματα και κείμενο. Δεν μετατρέπει τις εξαγόμενες εικόνες, PDF ή σελίδες HTML σε διαδραστικές 3D σκηνές που μπορεί να περιστρέψει ο θεατής. Στο PPTX, η 3D μορφοποίηση παραμένει επεξεργάσιμη στο PowerPoint όταν η μορφή το υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ 3D μοντέλου και 3D εφέ;**

Ένα 3D μοντέλο είναι ένα ξεχωριστό 3D αντικείμενο που εισάγεται σε μια παρουσίαση. Ένα 3D εφέ είναι μορφοποίηση που εφαρμόζεται σε κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, λοξά, φωτισμός και υλικό. Αυτό το άρθρο καλύπτει τα 3D εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3D σχήμα;**

Τουλάχιστον, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτιστικό και υλικό ώστε οι αποδοθέντες όψεις να έχουν σαφείς αναδείξεις και σκιές.

**Μπορώ να εφαρμόσω 3D εφέ τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [IShape.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) για το σώμα του σχήματος και το [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) για το κείμενο.

**Θα εμφανίζονται τα 3D εφέ όταν εξάγονται σε εικόνες, PDF, HTML ή πλαίσια βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα 3D εφέ όταν δημιουργεί εικόνες διαφανειών, εξαγωγή σε PDF, εξαγωγή σε HTML και πλαίσια που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδοθείσα εμφάνιση, όχι ένα επεξεργάσιμο 3D αντικείμενο.

**Μπορώ να διαβάσω τις τελικές 3D τιμές μετά την κληρονόμηση και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/androidjava/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτιστικού, λοξού και σχετικές 3D τιμές.