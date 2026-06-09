---
title: Δημιουργία 3Δ Εφέ σε Παρουσιάσεις Χρησιμοποιώντας Java
linktitle: 3Δ Παρουσίαση
type: docs
weight: 232
url: /el/java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3Δ εφέ για σχήματα και κείμενο PowerPoint σε Java με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3Δ κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides for Java μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει μορφοποίηση 3Δ σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφή, εξώθηση, λοξές άκρες, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα εικόνας, και κείμενο 3Δ.

{{% alert color="primary" %}}
Αυτό το άρθρο αφορά εφέ μορφοποίησης 3Δ σε σχήματα και κείμενο PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία ανεξάρτητων αρχείων μοντέλων 3Δ. Όταν εξάγετε μια διαφάνεια ως εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3Δ στην εξαγόμενη έξοδο 2Δ.
{{% /alert %}}

## **Έννοιες μορφοποίησης 3Δ**

Χρησιμοποιήστε το [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/).`getThreeDFormat()` για να εφαρμόσετε μορφοποίηση 3Δ σε ένα σχήμα. Το επιστρεφόμενο αντικείμενο μορφοποίησης ελέγχει τη σκηνή 3Δ για εκείνο το σχήμα.

Για κείμενο, χρησιμοποιήστε το [ITextFrameFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. Αυτό εφαρμόζει μορφοποίηση 3Δ στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Τα πιο σημαντικά μέλη του API είναι:

| Μέλος API | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getCamera--) | Σημείο θέασης, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε χώρο 3Δ ή ταιριάξτε με προεπιλεγμένη περιστροφή 3Δ του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getLightRig--) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε πώς εμφανίζονται οι αντανακλάσεις και οι σκιές στην επιφάνεια 3Δ. |
| [getMaterial](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, μαλακότερη, γυαλιστερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από το μπροστινό του πρόσωπο. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατά παχύ 3Δ αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Χρώμα των εκθλιμένων πλευρών. | Κάντε το βάθος ορατό ή εναρμονίστε το χρώμα των πλευρών με το γέμισμα του μπροστινού. |
| [getDepth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Επιπρόσθετο 3Δ βάθος που χρησιμοποιείται από τη μορφοποίηση 3Δ του PowerPoint. | Ρυθμίστε ακριβεία το βάθος για σχήματα ή κείμενο, ειδικά μαζί με ρυθμίσεις λοξής άκρης και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Ανασηκωμένες ή στρογγυλεμένες άκρες στα εμπρός και πίσω πρόσωπα. | Προσθέστε μια μαλακωμένη ή διαμορφωμένη άκρη αντί για μια οξεία επίπεδη όψη. |
| [getContourColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getContourWidth--), and [setContourWidth](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Περίγραμμα γύρω από το 3Δ αντικείμενο. | Τονίστε το όριο του αντικειμένου στην αποδοθείσα έξοδο. |

## **Δημιουργία σχήματος 3Δ**

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές ευανάγνωστες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην εμπρός του όψη, εφαρμόζει μορφοποίηση 3Δ, αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σε εικόνα PNG.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

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

Η αποδοθείσα εικόνα της διαφάνειας δείχνει το ορθογώνιο ως ένα παχύ 3Δ μπλόκ:

![Απόδοση μπλε 3Δ ορθογωνίου με λευκό 3Δ κείμενο στην εμπρός όψη](img_01_01.png)

## **Περιστροφή σχήματος με την κάμερα**

Στο PowerPoint, η περιστροφή 3Δ ρυθμίζεται από το πλαίσιο 3‑Δ Περιστροφή. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Πλαίσιο 3‑Δ Περιστροφής του PowerPoint με επισημασμένες τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, ορίστε τον τύπο κάμερας και την περιστροφή μέσω της μορφοποίησης 3Δ που επιστρέφει `shape.getThreeDFormat()`:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2Δ σχήματος στη διαφάνεια. Αλλάζει το 3Δ σημείο θέασης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη εξώθησης και βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντας το πίσω από την εμπρός όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint αντιστοιχισμένοι με τις ιδιότητες χρώματος εξώθησης και ύψους εξώθησης](img_02_02.png)

Ορίστε το ύψος εξώθησης για το πάχος και το χρώμα εξώθησης για το χρώμα των πλευρών:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Χρησιμοποιήστε τη ρύθμιση βάθους όταν χρειάζεται να δουλέψετε απευθείας με την τιμή βάθους του PowerPoint ή να συνδυάσετε το βάθος με λοξή άκρη, υλικό και εφέ κειμένου. Σε πολλές περιπτώσεις σχήματος, το ύψος εξώθησης είναι η πιο ξεκάθαρη ρύθμιση επειδή εκφράζει άμεσα την ορατή εξώθηση.

## **Χρήση διαβάθμισης ή γεμίσματος εικόνας με εφέ 3Δ**

Η μορφοποίηση 3Δ είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην εμπρός όψη και να διατηρήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει διαβάθμιση στο σχήμα και πιο σκούρο χρώμα εξώθησης στις πλευρές:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

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

![Απόδοση 3Δ ορθογωνίου με γέμισμα διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για χρήση γεμίσματος εικόνας, προσθέστε την εικόνα στην παρουσίαση και αναθέστε την στο γέμισμα του σχήματος:

```java
java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

Color extrusionColor = new Color(255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

![Απόδοση 3Δ ορθογωνίου με γέμισμα φωτογραφίας στην εμπρός όψη και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή μορφοποίησης 3Δ σε κείμενο**

Η μορφοποίηση 3Δ σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3Δ κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με γέμισμα μοτίβου, εφαρμόζει μετασχηματισμό WordArt και διαμορφώνει τις ρυθμίσεις 3Δ στο [ITextFrameFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/):

```java
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

![Απόδοση 3Δ κειμένου με καμπυλωτό μετασχηματισμό WordArt, πορτοκαλί γέμισμα μοτίβου και σκούρα εξώθηση](img_02_05.png)

## **Συμπεριφορά εξαγωγής και απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3Δ κατά την αποθήκευση σε μορφές PowerPoint όπως PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερής διάταξης, η σκηνή 3Δ μετατρέπεται σε bitmap ή ενσωματώνεται στην έξοδο ως αποτέλεσμα 2Δ. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/java/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/java/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/java/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [video conversion](/slides/el/java/convert-powerpoint-to-video/).

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό κάμερας, φωτιστικού, υλικού, εξώθησης, γέμισματος και κλίμακας διαφάνειας.
- Αν χρειάζεται να εξετάσετε κληρονομημένες ή βασισμένες σε θέμα τιμές μορφοποίησης, διαβάστε τις [αποτελεσματικές ιδιότητες σχήματος](/slides/el/java/shape-effective-properties/).
- Μερικές μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3Δ του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμο 3Δ.

## **FAQ**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3Δ παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3Δ του PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή HTML σε διαδραστικές 3Δ σκηνές που ο θεατής μπορεί να περιστρέψει. Σε PPTX, η μορφοποίηση 3Δ παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή το υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ ενός 3Δ μοντέλου και ενός 3Δ εφέ;**

Ένα 3Δ μοντέλο είναι ένα ξεχωριστό 3Δ αντικείμενο που εισάγεται στην παρουσίαση. Ένα 3Δ εφέ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, λοξή άκρη, φωτισμός και υλικό. Αυτό το άρθρο καλύπτει εφέ 3Δ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3Δ σχήμα;**

Ως ελάχιστο, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτιστικό και υλικό ώστε οι αποδοθείσες όψεις να έχουν σαφείς αντανακλάσεις και σκιές.

**Μπορώ να εφαρμόσω εφέ 3Δ σε σχήματα και κείμενο;**

Ναι. Χρησιμοποιήστε το [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/).`getThreeDFormat()` για το σώμα του σχήματος και το [ITextFrameFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` για το κείμενο.

**Θα εμφανιστούν τα 3Δ εφέ κατά την εξαγωγή σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει εφέ 3Δ κατά την δημιουργία εικόνων διαφανειών, εξόδου PDF, εξόδου HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδιδόμενη εμφάνιση, όχι ένα επεξεργάσιμο 3Δ αντικείμενο.

**Μπορώ να διαβάσω τις τελικές τιμές 3Δ μετά την κληρονομιά και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στο [Ιδιότητες Σχήματος](/slides/el/java/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτιστικού, λοξής άκρης και σχετικές τιμές 3Δ.