---
title: Δημιουργία 3D εφέ σε παρουσιάσεις με Java
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
description: "Εφαρμόστε και αποδώστε 3D εφέ για σχήματα και κείμενο PowerPoint σε Java με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3D κείμενο."
---
## **Επισκόπηση**

Aspose.Slides for Java μπορεί να δημιουργήσει, επεξεργαστεί, διατηρήσει και αποδώσει 3D μορφοποίηση σε σχήματα και κείμενο με στυλ PowerPoint. Αυτό το άρθρο καλύπτει εφέ 3D όπως περιστροφές, εξώθηση, λοξά, φωτισμό, υλικό, διαβαθμίσεις ή γεμίσματα εικόνας, και 3D κείμενο.

{{% alert color="info" title="Note" %}}

Αυτό το άρθρο αφορά τα εφέ μορφοποίησης 3D σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία ανεξάρτητων αρχείων 3D μοντέλου. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3D στην εξαγόμενη 2D έξοδο.

{{% /alert %}}

## **Αρχές 3D Μορφοποίησης**

Χρησιμοποιήστε τη μέθοδο [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) για να εφαρμόσετε 3D μορφοποίηση σε ένα σχήμα. Η μέθοδος επιστρέφει το [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/), το οποίο ελέγχει τη σκηνή 3D για εκείνο το σχήμα.

Για κείμενο, χρησιμοποιήστε τη μέθοδο [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Αυτό εφαρμόζει 3D μορφοποίηση στο πλαίσιο κειμένου αντί για το σώμα του σχήματος.

Οι πιο σημαντικά μέλη του API είναι:

| Μέλος API | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | Σημείο θέασης, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε 3D χώρο ή ταιριάξτε μια προεπιλογή περιστροφής 3D του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε πώς εμφανίζονται οι αποχρώσεις και οι σκιές στην 3D επιφάνεια. |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) και [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, μαλακότερη, λαμπερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) και [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Πόσο βαθιά το σχήμα εκτείνεται προς τα πίσω από το μπροστινό του πρόσοψη. | Μετατρέψτε ένα επίπεδο σχήμα σε εμφανώς παχύ 3D αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με το μπροστινό γέμισμα. |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) και [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Πρόσθετο 3D βάθος που χρησιμοποιείται από τη μορφοποίηση 3D του PowerPoint. | Ρυθμίστε ακριβώς το βάθος για σχήματα ή κείμενο, ιδιαίτερα μαζί με ρυθμίσεις λοξού και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) και [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Ανυψωμένες ή στρογγυλεμένες άκρες στις μπροστινές και πίσω όψεις. | Προσθέστε μια μαλακότερη ή μορφοποιημένη άκρη αντί για μια απότομη επίπεδη όψη. |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) και [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) και [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Περίγραμμα γύρω από το 3D αντικείμενο. | Τονίστε τα όρια του αντικειμένου στην αποδομένη έξοδο. |

## **Δημιουργία 3D Σχήματος**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν φαίνεται πειστικά 3D:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη άποψη εμπρόσθιας όψης μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές ορατές.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει πώς αποδίδεται το φως.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην εμπρός όψη του και εφαρμόζει 3D μορφοποίηση. Οι τιμές περιστροφής της κάμερας δίνονται σε μοίρες και το ύψος εξώθησης είναι 100 μονάδες. Το παράδειγμα αποδίδει τη διαφάνεια σε εικόνα PNG διπλάσιας του προεπιλεγμένου μεγέθους και αποθηκεύει την παρουσίαση ως PPTX.

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

Η αποδομένη εικόνα της διαφάνειας δείχνει το ορθογώνιο ως παχύ 3D μπλοκ:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3D περιστροφή ρυθμίζεται από το πλαίσιο 3‑D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στη περιστροφή που ορίζετε μέσω του API της κάμερας.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Στο Aspose.Slides, προσπελάστε την κάμερα μέσω του [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--). Αυτό το παράδειγμα δημιουργεί ένα ορθογώνιο, επιλέγει μια ορθογραφική προβολή εμπρός και θέτει τις περιστροφές X, Y, Z σε 20, 30 και 40 μοίρες αντίστοιχα. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

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

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε την προβολή του αντικειμένου από την πλευρά του θεατή. Δεν αλλάζει τη γεωμετρία του 2D σχήματος στη διαφάνεια. Αλλάζει το 3D σημείο θέασης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

### **Αντιγραφή Προσανατολισμού Κάμερας από Σχήμα Προτύπου**

Για να ταιριάξετε τον προσανατολισμό ενός σχήματος προτύπου, διαβάστε την προεπιλογή κάμερας του μέσω του [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) και τις γωνίες περιστροφής του με το [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--). Το παράδειγμα ανοίγει το `template.pptx` και αντιγράφει τον προσανατολισμό της κάμερας από το πρώτο σχήμα της πρώτης διαφάνειας στο δεύτερο σχήμα. Και τα δύο σχήματα έχουν ήδη 3D φωτισμό, ενώ το δεύτερο σχήμα δεν έχει ρητή περιστροφή κάμερας.

Οι γωνίες δίνονται σε μοίρες. Το ευρετήριο `0` είναι γεωγραφικό πλάτος, το `1` είναι γεωγραφικό μήκος και το `2` είναι περιφορά. Περάστε τα στο [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) με αυτή τη σειρά. Αν η πηγή επιστρέφει `null`, δεν υπάρχει ρητή περιστροφή, οπότε αφήστε τις γωνίες του δεύτερου σχήματος ακαθορισμένες. Μια ρητή περιστροφή `(0, 0, 0)` επιστρέφει τρία μηδενικά και πρέπει να αντιγραφεί.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Όταν ανοίξετε ξανά το `camera-copy.pptx` στο PowerPoint, το βέλος δεξιά θα έχει την ίδια προεπιλογή κάμερας και περιστροφή με το ορθογώνιο αριστερά. Και τα δύο σχήματα χρησιμοποιούν τον ίδιο φωτισμό και βάθος εξώθησης.

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από την εμπρός όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, ενώ ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Χρησιμοποιήστε το [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) για να ορίσετε το πάχος και το [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) για να προσπελάσετε το χρώμα των πλευρών. Το παράδειγμα δίνει σε ένα ορθογώνιο εξώθηση 100 μονάδων με μωβ πλευρές και περιστρέφει την κάμερα για να αποκαλύψει το πάχος. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

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

Η μέθοδος [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) ορίζει το βάθος ενός 3D σχήματος. Η μέθοδος [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ελέγχει το ύψος του εφέ εξώθησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση Διαβαθμίσεων ή Γεμίσματος Εικόνας με Εφέ 3D**

Η 3D μορφοποίηση είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε ένα συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην εμπρός όψη και να διατηρήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει μια διαβάθμιση από μπλε σε πορτοκαλί στην εμπρός όψη και ένα σκούρο πορτοκαλί χρώμα στην εξώθηση 150 μονάδων. Τα σημεία διαβάθμισης στο 0 και 100 σηματοδοτούν την έναρξη και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας δίνονται σε μοίρες. Η διαφάνεια αποδίδεται σε εικόνα PNG διπλάσιας του προεπιλεγμένου μεγέθους:

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

Η αποδομένη έξοδος διατηρεί τη διαβάθμιση στην εμπρός όψη και αποδίδει την εξώθηση χωριστά:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και αναθέστε την στο γέμισμα του σχήματος. Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο με όνομα "image.jpg" στον τρέχοντα φάκελο. Τεντώνει την εικόνα ώστε να γεμίσει το ορθογώνιο, εφαρμόζει εξώθηση 150 μονάδων και θέτει τη περιστροφή της κάμερας σε μοίρες. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

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

Η εικόνα αποδίδεται στην εμπρός όψη, ενώ η εξώθηση αποδίδεται ως η 3D πλευρική επιφάνεια:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Εφαρμογή 3D Μορφοποίησης σε Κείμενο**

Η 3D μορφοποίηση σχήματος επηρεάζει το σώμα του σχήματος. Η 3D μορφοποίηση κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με μοτίβο πλέγματος πορτοκαλί‑λευκό, εφαρμόζει ένα αψίδα προς τα πάνω και διαμορφώνει ρυθμίσεις 3D μέσω του [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Το ύψος εξώθησης και το βάθος δίνονται σε μονάδες, και η περιστροφή του φωτός σε μοίρες. Το γέμισμα και το περίγραμμα του σχήματος είναι κρυμμένα ώστε να φαίνεται μόνο το κείμενο. Το παράδειγμα αποδίδει μια εικόνα PNG διπλάσιων διαστάσεων της προεπιλογής και αποθηκεύει την παρουσίαση ως PPTX:

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

Το κείμενο αποδίδεται ως καμπυλωτά, εξωθήμενα 3D γράμματα:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Διατήρηση του Κειμένου Επίπεδου σε 3D Σχήμα**

Για να διατηρήσετε το κείμενο ευανάγνωστο ενώ διατηρείτε την 3D εμφάνιση του σχήματος, καλέστε το [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) μέσω του [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--). Όταν η τιμή είναι `true`, το κείμενο παραμένει έξω από τη 3D σκηνή. Όταν είναι `false`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί τον 3D προσανατολισμό της.

Αυτή η ρύθμιση δεν αφαιρεί τη 3D μορφοποίηση του σχήματος: η κάμερα, ο φωτισμός, το υλικό και η εξώθηση παραμένουν ρυθμισμένα μέσω του [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--). Είναι επίσης διαφορετική από την κοινή περιστροφή. Το [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ το [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου μέσα στο πλαίσιο του. Η διατήρηση του κειμένου εκτός της 3D σκηνής δεν μηδενίζει καμία από τις δύο γωνίες.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το κλωνοποιεί δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια 3D μορφοποίηση· μόνο η ρύθμιση κειμένου διαφέρει: `false` στα αριστερά και `true` στα δεξιά. Οι γωνίες κάμερας δίνονται σε μοίρες, και το ύψος εξώθησης είναι 40 μονάδες. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σύγκρισης σε PNG διπλάσιας του προεπιλεγμένου μεγέθους.

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

Στα αριστερά, το κείμενο ακολουθεί τον 3D προσανατολισμό. Στα δεξιά, παραμένει επίπεδο και πιο εύκολο στην ανάγνωση. Και τα δύο ορθογώνια διατηρούν την ίδια ορατή εξώθηση και 3D προσανατολισμό.

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη 3D μορφοποίηση κατά την αποθήκευση σε μορφές PowerPoint όπως το PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές στατικού layout, η 3D σκηνή κατευθύνεται ή σχεδιάζεται στην έξοδο ως 2D αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/java/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/java/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/java/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [μετατροπή σε βίντεο](/slides/el/java/convert-powerpoint-to-video/).

Να θυμάστε τα εξής:

- Οι εξαγόμενες εικόνες και PDF δεν είναι διαδραστικές. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από τον συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γεμίσματος και κλιμακώσεων διαφάνειας.
- Αν χρειάζεστε να εξετάσετε κληρονομημένες ή θεματικές τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/java/shape-effective-properties/).
- Κάποιες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη 3D μορφοποίηση PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3D.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3D παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει τις 3D επιδράσεις PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή HTML σελίδες διαδραστικές 3D σκηνές που ο θεατής μπορεί να περιστρέψει. Σε PPTX, η 3D μορφοποίηση παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή το υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ 3D μοντέλου και 3D εφέ;**

Ένα 3D μοντέλο είναι ξεχωριστό 3D αντικείμενο που εισάγεται σε μια παρουσίαση. Ένα 3D εφέ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, λοξό, φωτισμό και υλικό. Αυτό το άρθρο καλύπτει 3D εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3D σχήμα;**

Ελάχιστα, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης ένα σύνολο φωτισμού και υλικό ώστε οι αποδιδόμενες όψεις να έχουν καθαρές αναδράσεις και σκιές.

**Μπορώ να εφαρμόσω 3D εφέ σε σχήματα και κείμενο;**

Ναι. Χρησιμοποιήστε το [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) για το σώμα του σχήματος και το [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) για το κείμενο.

**Θα εμφανιστούν τα 3D εφέ όταν εξάγω σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα 3D εφέ όταν παράγει εικόνες διαφανειών, PDF, HTML και καρέ που χρησιμοποιούνται για μετατροπή σε βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδομένη εμφάνιση, όχι ένα επεξεργάσιμο 3D αντικείμενο.

**Μπορώ να διαβάσω τις τελικές 3D τιμές μετά την κληρονομιά και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/java/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, λοξών και συναφών 3D τιμών.