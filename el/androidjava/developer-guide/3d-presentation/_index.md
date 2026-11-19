---
title: Δημιουργία 3Δ εφέ σε παρουσιάσεις στο Android
linktitle: Παρουσίαση 3Δ
type: docs
weight: 232
url: /el/androidjava/3d-presentation/
keywords:
- 3Δ PowerPoint
- Παρουσίαση 3Δ
- Περιστροφή 3Δ
- Βάθος 3Δ
- Εξώθηση 3Δ
- Διαβάθμιση 3Δ
- Κείμενο 3Δ
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε εφέ 3Δ για σχήματα και κείμενο PowerPoint σε Android με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσεις και κείμενο 3Δ."
---
## **Επισκόπηση**

Το Aspose.Slides for Android μέσω Java μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει μορφοποίηση 3Δ σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφή, εξώθηση, χωνεύσεις, φωτισμό, υλικό, γεωμετρικές ή εικόνα γεμίσεις, και κείμενο 3Δ.

{{% alert color="info" title="Note" %}}
Αυτό το άρθρο αφορά τα εφέ μορφοποίησης 3Δ σε σχήματα και κείμενο PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία ξεχωριστών αρχείων μοντέλων 3Δ. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3Δ στην εξαγόμενη 2Δ έξοδο.
{{% /alert %}}

## **Αρχές Μορφοποίησης 3Δ**

Χρησιμοποιήστε τη μέθοδο [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) για να εφαρμόσετε μορφοποίηση 3Δ σε ένα σχήμα. Η μέθοδος επιστρέφει το [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/), το οποίο ελέγχει τη σκηνή 3Δ για εκείνο το σχήμα.

Για κείμενο, χρησιμοποιήστε τη μέθοδο [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Αυτό εφαρμόζει μορφοποίηση 3Δ στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Τα πιο σημαντικά μέλη του API είναι:

| API member | What it controls | When to use it |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Οπτικό σημείο, προρυθμισμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστροφή του αντικειμένου σε χώρο 3Δ ή ταιριάξτε μια προρυθμιζόμενη περιστροφή 3Δ του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Προρύθμιση φωτός, κατεύθυνση και περιστροφή φωτός. | Αλλαγή του τρόπου εμφάνισης των ανταυγών και σκιών στην επιφάνεια 3Δ. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, πιο ήπια, λαμπερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από το μπροστινό του πρόσωπο. | Μετατρέψτε ένα επίπεδο σχήμα σε ορατά παχύ αντικείμενο 3Δ. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με τη γεμιστική μπροστινή πλευρά. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Επιπλέον βάθος 3Δ που χρησιμοποιείται από τη μορφοποίηση 3Δ του PowerPoint. | Ρυθμίστε προσεκτικά το βάθος για σχήματα ή κείμενο, ιδιαίτερα μαζί με ρυθμίσεις χωνεύσεων και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Ανασηκωμένα ή στρογγυλεμένα άκρα στις μπροστινές και πίσω επιφάνειες. | Προσθέστε απαλό ή καλυμμένο άκρο αντί για ένα οξύ επίπεδο πρόσοψη. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) and [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) and [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Περίγραμμα γύρω από το αντικείμενο 3Δ. | Τονίστε το σύνορο του αντικειμένου στην αποδοθέντα έξοδο. |

## **Δημιουργία Σχήματος 3Δ**

Ένα σχήμα συνήθως χρειάζεται τέσσερα είδη ρυθμίσεων πριν φαίνεται πειστικά 3Δ:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπροστά μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές αναγνώσιμες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην μπροστινή του πλευρά και εφαρμόζει μορφοποίηση 3Δ. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες και το ύψος εξώθησης είναι 100 μονάδες. Το παράδειγμα αποδίδει τη διαφάνεια σε εικόνα PNG στο διπλάσιο των προεπιλεγμένων διαστάσεων και αποθηκεύει την παρουσίαση ως PPTX.

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

Η αποδοθέντη εικόνα της διαφάνειας εμφανίζει το ορθογώνιο ως παχύ 3Δ μπλοκ:

![Απόδοση μπλε 3Δ ορθογωνίου με λευκό 3Δ κείμενο στην μπροστινή πλευρά](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η περιστροφή 3Δ ρυθμίζεται από το παράθυρο 3‑Δ Περιστροφή. Οι τιμές περιστροφής X, Y, Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API κάμερας.

![Παράθυρο 3‑Δ Περιστροφή του PowerPoint με τις τιμές περιστροφής X, Y, Z επισημασμένες](img_02_01.png)

Στο Aspose.Slides, αποκτήστε πρόσβαση στην κάμερα μέσω του [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--). Αυτό το παράδειγμα δημιουργεί ένα ορθογώνιο, επιλέγει μια ορθογραφική προοπτική μπροστά και ορίζει τις περιστροφές X, Y, Z στα 20, 30 και 40 μοίρες αντίστοιχα. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

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

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2Δ σχήματος στη διαφάνεια. Αλλάζει το 3Δ οπτικό σημείο που χρησιμοποιείται από το PowerPoint και το Aspose.Slides κατά την απόδοση.

### **Αντιγραφή Προσανατολισμού Κάμερας από Σχήμα Προτύπου**

Για να ταιριάξετε τον προσανατολισμό ενός σχήματος προτύπου, διαβάστε την προρύθμιση κάμερας του με το [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) , και τις γωνίες περιστροφής του με το [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--). Το παράδειγμα ανοίγει το `template.pptx` και αντιγράφει τον προσανατολισμό κάμερας από το πρώτο σχήμα στην πρώτη διαφάνεια στο δεύτερο σχήμα. Και τα δύο σχήματα διαθέτουν ήδη φωτισμό 3Δ, ενώ το δεύτερο σχήμα δεν έχει ρητή περιστροφή κάμερας.

Οι γωνίες είναι σε μοίρες. Δείκτης `0` είναι το γεωγραφικό πλάτος, δείκτης `1` το γεωγραφικό μήκος και δείκτης `2` η περιδρόπηση. Π pass τις στο [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) με αυτή τη σειρά. Εάν η πηγή επιστρέψει `null`, δεν έχει ρητή περιστροφή, έτσι αφήστε τις γωνίες του δεύτερου σχήματος ακαθορισμένες. Μια ρητή περιστροφή `(0, 0, 0)` επιστρέφει τρία μηδενικά και πρέπει να αντιγραφεί.

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

Όταν ξανανοίξετε το `camera-copy.pptx` στο PowerPoint, το βέλος δεξιά έχει την ίδια προρύθμιση κάμερας και περιστροφή με το ορθογώνιο αριστερά. Και τα δύο σχήματα χρησιμοποιούν τον ίδιο φωτισμό και βάθος εξώθησης.

![Ένα μπλε 3Δ ορθογώνιο και ένα δεξιό βέλος με αντίστοιχο προσανατολισμό κάμερας, προβλεπόμενα από πάνω και δεξιά](camera-orientation.png)

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ, επεκτείνοντας το πίσω από την μπροστινή όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint συνδεδεμένοι με τις ιδιότητες χρώματος και ύψους εξώθησης](img_02_02.png)

Χρησιμοποιήστε το [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) για να ορίσετε το πάχος και το [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) για να προσπελάσετε το χρώμα των πλευρών. Αυτό το παράδειγμα δίνει σε ένα ορθογώνιο εξώθηση 100 μονάδων με μωβ πλευρές και περιστρέφει την κάμερα για να εμφανίσει το πάχος του. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

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

Η μέθοδος [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) ορίζει το βάθος ενός σχήματος 3Δ. Η μέθοδος [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ελέγχει το ύψος του εφέ εξώθησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση Διαβάθμισης ή Γεμίσεων Εικόνας με Εφέ 3Δ**

Η μορφοποίηση 3Δ είναι ανεξάρτητη από τη γέμιση του σχήματος. Μπορείτε να εφαρμόσετε ένα συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμιση εικόνας στην μπροστινή όψη και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει διαβάθμιση από το μπλε στο πορτοκαλί στην μπροστινή όψη και σκούρο πορτοκαλί χρώμα στην εξώθηση 150 μονάδων. Οι στάσεων της διαβάθμισης στο 0 και 100 σηματοδοτούν την αρχή και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες. Η διαφάνεια αποδίδεται σε εικόνα PNG στο διπλάσιο των προεπιλεγμένων διαστάσεων:

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

Η αποδοθείσα έξοδος διατηρεί τη διαβάθμιση στην μπροστινή όψη και αποδίδει την εξώθηση χωριστά:

![Απόδοση 3Δ ορθογωνίου με γέμιση διαβάθμισης μπλε-πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμιση εικόνας αντί αυτού, προσθέστε την εικόνα στην παρουσίαση και την εκχωρήστε στη γέμιση του σχήματος. Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο με όνομα "image.jpg" στον τρέχοντα φάκελο. Τεντώνει την εικόνα ώστε να γεμίσει το ορθογώνιο, εφαρμόζει εξώθηση 150 μονάδων και ορίζει την περιστροφή της κάμερας σε μοίρες. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

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

Η εικόνα αποδίδεται στην μπροστινή όψη, ενώ η εξώθηση αποδίδεται ως η 3Δ πλευρική επιφάνεια:

![Απόδοση 3Δ ορθογωνίου με γέμιση φωτογραφίας στην μπροστινή όψη και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3Δ σε Κείμενο**

Η μορφοποίηση 3Δ του σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3Δ του κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα απαιτούν εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με μοτίβο πλέγματος πορτοκαλί‑λευκό, εφαρμόζει μια ανοδική καμπύλη και διαμορφώνει τις ρυθμίσεις 3Δ μέσω του [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Το ύψος εξώθησης και το βάθος είναι σε μονάδες, και η περιστροφή φωτός είναι σε μοίρες. Η γέμιση και το περίγραμμα του σχήματος είναι κρυμμένα ώστε να είναι ορατό μόνο το κείμενο. Το παράδειγμα αποδίδει μια εικόνα PNG στο διπλάσιο των προεπιλεγμένων διαστάσεων της διαφάνειας και αποθηκεύει την παρουσίαση ως PPTX:

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

Το κείμενο αποδίδεται ως καμπυλωτά, εξωθημένα 3Δ γράμματα:

![Απόδοση 3Δ κειμένου με καμπυλωτό WordArt μετασχηματισμό, γέμιση μοτίβου πορτοκαλί και σκούρα εξώθηση](img_02_05.png)

## **Διατήρηση Κειμένου Επίπεδου σε Σχήμα 3Δ**

Για να διατηρήσετε το κείμενο αναγνώσιμο ενώ διατηρείτε την 3Δ εμφάνιση ενός σχήματος, καλέστε το [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) μέσω του [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). Όταν η τιμή είναι `true`, το κείμενο παραμένει εκτός της 3Δ σκηνής. Όταν είναι `false`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί την 3Δ προσανατολισμό της.

Αυτή η ρύθμιση δεν αφαιρεί τη μορφοποίηση 3Δ του σχήματος: η κάμερα, ο φωτισμός, το υλικό και η εξώθηση παραμένουν ρυθμισμένα μέσω του [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). Επίσης διαφέρει από την κοινή περιστροφή. Το [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ το [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου εντός του πλαισίου του. Η διατήρηση του κειμένου εκτός της 3Δ σκηνής δεν επαναφέρει καμία από αυτές τις γωνίες.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το κλωνοποιεί δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια μορφοποίηση 3Δ· μόνο η ρύθμιση κειμένου διαφέρει: `false` στα αριστερά και `true` στα δεξιά. Οι γωνίες της κάμερας είναι σε μοίρες και το ύψος εξώθησης είναι 40 μονάδες. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σύγκρισης σε PNG στο διπλάσιο των προεπιλεγμένων διαστάσεων.

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

Στα αριστερά, το κείμενο ακολουθεί την 3Δ προσανατολισμό. Στα δεξιά, παραμένει επίπεδο και πιο εύκολο στην ανάγνωση. Και τα δύο ορθογώνια διατηρούν την ίδια ορατή εξώθηση και 3Δ προσανατολισμό.

![Δύο 3Δ ορθογώνια δίπλα-δίπλα: το κείμενο ακολουθεί την 3Δ προσανατολίση στα αριστερά και παραμένει επίπεδο στα δεξιά](keep_text_flat.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3Δ κατά την αποθήκευση σε μορφές PowerPoint όπως το PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερής διάταξης, η σκηνή 3Δ μετατρέπεται σε ραστερ ή σχεδιάζεται στην έξοδο ως αποτέλεσμα 2Δ. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/androidjava/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/androidjava/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [μετατροπή βίντεο](/slides/el/androidjava/convert-powerpoint-to-video/).

Λάβετε υπόψη τα εξής σημεία:

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από τον συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γέμισις και κλιμάκωσης διαφάνειας.
- Εάν χρειάζεστε να εξετάσετε κληρονομημένες ή βασισμένες σε θέμα τιμές μορφοποίησης, διαβάστε τις [αποτελεσματικές ιδιότητες σχήματος](/slides/el/androidjava/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3Δ του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3Δ.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3Δ παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3Δ PowerPoint για σχήματα και κείμενο. Δεν μετατρέπει τις εξαγόμενες εικόνες, PDF ή σελίδες HTML σε διαδραστικές 3Δ σκηνές που μπορεί να περιστρέψει ο θεατής. Σε PPTX, η μορφοποίηση 3Δ παραμένει επεξεργάσιμη στο PowerPoint εφόσον η μορφή το υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ μοντέλου 3Δ και εφέ 3Δ;**

Ένα μοντέλο 3Δ είναι ένα ξεχωριστό αντικείμενο 3Δ που εισάγεται στην παρουσίαση. Ένα εφέ 3Δ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο PowerPoint, όπως περιστροφή, εξώθηση, χωνεύση, φωτισμός και υλικό. Αυτό το άρθρο καλύπτει εφέ 3Δ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό σχήμα 3Δ;**

Ως ελάχιστο, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτισμό και υλικό ώστε οι αποδοθείσες όψεις να έχουν σαφείς ανταύγεις και σκιές.

**Μπορώ να εφαρμόσω εφέ 3Δ τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) για το σώμα του σχήματος και το [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) για το κείμενο.

**Θα εμφανίζονται τα εφέ 3Δ κατά την εξαγωγή σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει εφέ 3Δ όταν παράγει εικόνες διαφανειών, εξαγωγή σε PDF, εξαγωγή σε HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδοθείσα εμφάνιση, όχι ένα επεξεργάσιμο αντικείμενο 3Δ.

**Μπορώ να διαβάσω τις τελικές τιμές 3Δ μετά την εφαρμογή κληρονομιών και ρυθμίσεων θέματος;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/androidjava/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, χωνεύσεων και σχετιζόμενα 3Δ δεδομένα.