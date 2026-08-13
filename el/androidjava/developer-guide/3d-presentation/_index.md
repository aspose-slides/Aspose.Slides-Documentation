---
title: Δημιουργία εφέ 3Δ σε παρουσιάσεις στο Android
linktitle: 3Δ Παρουσίαση
type: docs
weight: 232
url: /el/androidjava/3d-presentation/
keywords:
- 3Δ PowerPoint
- 3Δ παρουσίαση
- 3Δ περιστροφή
- 3Δ βάθος
- 3Δ εξώθηση
- 3Δ διαβάθμιση
- 3Δ κείμενο
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε εφέ 3Δ για σχήματα και κείμενο PowerPoint σε Android με το Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και κείμενο 3Δ."
---
## **Επισκόπηση**

Το Aspose.Slides για Android μέσω Java μπορεί να δημιουργήσει, να επεξεργαστεί, να διατηρήσει και να αποδώσει μορφοποίηση 3Δ σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφή, εξώθηση, λοβώματα, φωτισμό, υλικό, γεμίσματα διαβάθμισης ή εικόνας και κείμενο 3Δ.

{{% alert color="info" %}}
Αυτό το άρθρο αφορά εφέ μορφοποίησης 3Δ σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή την επεξεργασία ανεξάρτητων αρχείων 3Δ μοντέλου. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3Δ στην εξαχθείσα 2Δ έξοδο.
{{% /alert %}}

## **Έννοιες Μορφοποίησης 3Δ**

Χρησιμοποιήστε τη μέθοδο [IShape.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) για να εφαρμόσετε μορφοποίηση 3Δ σε ένα σχήμα. Η μέθοδος επιστρέφει το [IThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/), το οποίο ελέγχει τη σκηνή 3Δ για εκείνο το σχήμα.

Για κείμενο, χρησιμοποιήστε τη μέθοδο [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Αυτό εφαρμόζει μορφοποίηση 3Δ στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Τα πιο σημαντικά μέλη του API είναι:

| Μέλος API | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Οπτική γωνία, προκαθορισμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε χώρο 3Δ ή ταιριάξτε με προεπιλογή περιστροφής 3Δ του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Προεπιλογή φωτός, κατεύθυνση και περιστροφή φωτός. | Αλλάζει πώς εμφανίζονται οι αντανακλάσεις και οι σκιές στην επιφάνεια 3Δ. |
| [getMaterial](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) και [setMaterial](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάνει την ίδια γεωμετρία να φαίνεται πιο επίπεδη, απαλύτερη, γυαλιστερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) και [setExtrusionHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Πόσο μακριά επεκτείνεται το σχήμα προς τα πίσω από το μπροστινό του πρόσωπο. | Μετατρέπει ένα επίπεδο σχήμα σε ένα ορατά παχύ 3Δ αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Χρώμα των εξελασμένων πλευρών. | Κάνει το βάθος ορατό ή συντονίζει το χρώμα των πλευρών με τη γέμιση του μπροστινού. |
| [getDepth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getDepth--) και [setDepth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Επιπλέον βάθος 3Δ που χρησιμοποιείται από τη μορφοποίηση 3Δ του PowerPoint. | Ρυθμίζει ακριβώς το βάθος για σχήματα ή κείμενο, ειδικά σε συνδυασμό με ρυθμίσεις λοβώματος και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) και [getBevelBottom](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Ανεβασμένα ή στρογγυλεμένα άκρα στις μπροστινές και πίσω όψεις. | Προσθέτει ένα μαλακό ή διαμορφωμένο άκρο αντί για μια αιχμηρή επίπεδη όψη. |
| [getContourColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), και [setContourWidth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Περιγράμμμα γύρω από το 3Δ αντικείμενο. | Τονίζει το σύνορο του αντικειμένου στην αποδοθείσα έξοδο. |

## **Δημιουργία Σχήματος 3Δ**

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη μπροστινή προβολή μπορεί να κρύβει την εξώθηση.  
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές αναγνώσιμες.  
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.  
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην μπροστινή όψη, εφαρμόζει μορφοποίηση 3Δ, αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σε εικόνα PNG.

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

Η αποδοθείσα εικόνα της διαφάνειας δείχνει το ορθογώνιο ως ένα παχύ 3Δ μπλοκ:

![Αποδιδόμενο μπλε 3Δ ορθογώνιο με λευκό 3Δ κείμενο στην μπροστινή όψη](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3Δ περιστροφή ρυθμίζεται από το παράθυρο 3‑Δ Περιστροφής. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Παράθυρο 3‑Δ Περιστροφής του PowerPoint με επισημασμένες τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, ορίστε τον τύπο της κάμερας και την περιστροφή μέσω του [IThreeDFormat.getCamera](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

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

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2Δ σχήματος στη διαφάνεια. Αλλάζει το 3Δ σημείο θέασης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από τη μπροστινή όψη. Στο PowerPoint, ο έλεγχος βάθους καθορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος καθορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint συνδεδεμένοι με τις ιδιότητες χρώματος εξώθησης και ύψους εξώθησης](img_02_02.png)

Ορίστε το [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) για το πάχος και το [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) για το χρώμα των πλευρών:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε το [IThreeDFormat.setDepth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) όταν χρειάζεται να εργαστείτε απευθείας με την τιμή βάθους του PowerPoint ή να συνδυάσετε το βάθος με λοβώματα, υλικό και εφέ κειμένου. Σε πολλές περιπτώσεις σχήματος, το `setExtrusionHeight` είναι η πιο σαφής ρύθμιση, επειδή εκφράζει άμεσα την ορατή εξώθηση.

## **Χρήση Γεμίσματος Διαβάθμισης ή Εικόνας με Εφέ 3Δ**

Η μορφοποίηση 3Δ είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε ένα συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στη μπροστινή όψη και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτός, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει γέμισμα διαβάθμισης στο σχήμα και πιο σκούρο χρώμα εξώθησης στις πλευρές:

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
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

Η αποδοθείσα εικόνα διατηρεί τη διαβάθμιση στη μπροστινή όψη και αποδίδει την εξώθηση ξεχωριστά:

![Αποδιδόμενο 3Δ ορθογώνιο με γέμισμα διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και την αναθέστε στο γέμισμα του σχήματος:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

Η εικόνα αποδίδεται στη μπροστινή όψη, ενώ η εξώθηση αποδίδεται ως η 3Δ πλευρική επιφάνεια:

![Αποδιδόμενο 3Δ ορθογώνιο με γέμισμα φωτογραφίας στην μπροστινή όψη και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3Δ σε Κείμενο**

Η μορφοποίηση 3Δ σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3Δ κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ παρόμοια με WordArt όπου τα γράμματα απαιτούν εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με γέμισμα μοτίβου, εφαρμόζει μετασχηματισμό WordArt και διαμορφώνει τις ρυθμίσεις 3Δ στο [ITextFrameFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/):

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

![Αποδιδόμενο 3Δ κείμενο με καμπυλωτό μετασχηματισμό WordArt, πορτοκαλί γέμισμα μοτίβου και σκούρα εξώθηση](img_02_05.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3Δ όταν αποθηκεύει σε μορφές PowerPoint όπως το PPTX. Όταν αποδίδει ή εξάγει σε μορφές σταθερής διάταξης, η σκηνή 3Δ ραστεροποιείται ή σχεδιάζεται στην έξοδο ως αποτέλεσμα 2Δ. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/androidjava/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/androidjava/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [video conversion](/slides/el/androidjava/convert-powerpoint-to-video/).

Λάβετε υπόψη τα εξής:

- Τα εξαγόμενα εικόνες και PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.  
- Η τελική εμφάνιση εξαρτάται από τον συνδυασμό κάμερας, φωτιστικού, υλικού, εξώθησης, γεμίσματος και κλιμάκωσης της διαφάνειας.  
- Εάν χρειάζεται να ελέγξετε κληρονομημένες ή θεματικές τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/androidjava/shape-effective-properties/).  
- Κάποιες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3Δ του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3Δ.

## **Συχνές Ερωτήσεις**

### Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3Δ παρουσιάσεις;

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3Δ του PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή σελίδες HTML διαδραστικές σκηνές 3Δ που ένας θεατής μπορεί να περιστρέψει. Σε PPTX, η μορφοποίηση 3Δ παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή το υποστηρίζει.

### Ποια είναι η διαφορά μεταξύ μοντέλου 3Δ και εφέ 3Δ;

Ένα μοντέλο 3Δ είναι ένα ξεχωριστό αντικείμενο 3Δ που εισάγεται σε παρουσίαση. Ένα εφέ 3Δ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, λοβώμα, φωτισμός και υλικό. Αυτό το άρθρο καλύπτει εφέ 3Δ.

### Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3Δ σχήμα;

Κατ' ελάχιστο, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτιστικό και υλικό ώστε οι αποδοθείσες όψεις να έχουν σαφείς αντανακλάσεις και σκιές.

### Μπορώ να εφαρμόσω εφέ 3Δ τόσο σε σχήματα όσο και σε κείμενο;

Ναι. Χρησιμοποιήστε το [IShape.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) για το σώμα του σχήματος και το [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) για το κείμενο.

### Θα εμφανίζονται τα εφέ 3Δ κατά την εξαγωγή σε εικόνες, PDF, HTML ή καρέ βίντεο;

Ναι. Το Aspose.Slides αποδίδει τα εφέ 3Δ όταν παράγει εικόνες διαφανειών, έξοδο PDF, έξοδο HTML και καρέ που χρησιμοποιούνται για μετατροπή σε βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδοθείσα εμφάνιση, όχι ένα επεξεργάσιμο αντικείμενο 3Δ.

### Μπορώ να διαβάσω τις τελικές τιμές 3Δ μετά την εφαρμογή των κληρονομημένων και των ρυθμίσεων θέματος;

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/androidjava/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές της κάμερας, του φωτιστικού, του λοβώματος και των σχετικών ρυθμίσεων 3Δ.