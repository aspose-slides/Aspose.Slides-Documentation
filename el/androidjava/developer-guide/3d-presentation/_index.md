---
title: Δημιουργία 3Δ Εφέ σε Παρουσιάσεις στο Android
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
description: "Εφαρμόστε και αποδώστε 3Δ εφέ για σχήματα και κείμενο PowerPoint σε Android με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3Δ κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides για Android μέσω Java μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει μορφοποίηση 3Δ παρόμοια με το PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφή, εξώθηση, χωνευτές, φωτισμό, υλικό, διαβάθμιση ή γεμίσματος εικόνας και 3Δ κείμενο.

{{% alert color="primary" %}}
Αυτό το άρθρο αφορά τα εφέ μορφοποίησης 3Δ σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία ανεξαρτήτων αρχείων 3Δ μοντέλων. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3Δ στην εξαγόμενη 2Δ έξοδο.
{{% /alert %}}

## **Έννοιες μορφοποίησης 3Δ**

Χρησιμοποιήστε τη μέθοδο [IShape.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) για να εφαρμόσετε μορφοποίηση 3Δ σε ένα σχήμα. Η μέθοδος επιστρέφει το [IThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/), το οποίο ελέγχει τη σκηνή 3Δ για εκείνο το σχήμα.

Για κείμενο, χρησιμοποιήστε τη μέθοδο [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Αυτό εφαρμόζει μορφοποίηση 3Δ στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Τα πιο σημαντικά μέλη API είναι:

| Μέλος API | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Σημείο θέασης, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε τρισδιάστατο χώρο ή ταιριάξτε με προεπιλεγμένη περιστροφή 3Δ του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο που εμφανίζονται τα φωτισμένα σημεία και οι σκιές στην τρισδιάστατη επιφάνεια. |
| [getMaterial](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) και [setMaterial](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, πιο μαλακή, λαμπερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) και [setExtrusionHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Πόσο πολύ το σχήμα εκτείνεται προς τα πίσω από την μπροσινή του πλευρά. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατά παχύ 3Δ αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με τη γεμίσματος μπροστά. |
| [getDepth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getDepth--) και [setDepth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Επιπλέον τρισδιάστατο βάθος που χρησιμοποιείται από τη μορφοποίηση 3Δ του PowerPoint. | Ρυθμίστε ακριβώς το βάθος για σχήματα ή κείμενο, ιδίως μαζί με τις ρυθμίσεις χωνεύτη και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) και [getBevelBottom](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Ανασηκωμένα ή στρογγυλεμένα άκρα στις μπροστινές και πίσω όψεις. | Προσθέστε ένα μαλακό ή μορφοποιημένο άκρο αντί για μια κοφτερή επίπεδη όψη. |
| [getContourColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), και [setContourWidth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Περίγραμμα γύρω από το 3Δ αντικείμενο. | Τονίστε το όριο του αντικειμένου στην αποδοθείσα έξοδο. |

## **Δημιουργία σχήματος 3Δ**

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές ευδιάκριτες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην μπροστινή του πλευρά, εφαρμόζει μορφοποίηση 3Δ, αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σε εικόνα PNG.

```java
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

Η αποδιδόμενη εικόνα της διαφάνειας δείχνει το ορθογώνιο ως ένα παχύ 3Δ μπλοκ:

![Αποδιδόμενο μπλε 3Δ ορθογώνιο με λευκό 3Δ κείμενο στην μπροστινή πλευρά](img_01_01.png)

## **Περιστροφή σχήματος με την κάμερα**

Στο PowerPoint, η 3Δ περιστροφή ρυθμίζεται από το τμήμα 3‑Δ Περιστροφής. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Πάνελ 3‑Δ Περιστροφής του PowerPoint με επισημασμένες τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, ορίστε τον τύπο κάμερας και την περιστροφή μέσω του [IThreeDFormat.getCamera](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία 2Δ του σχήματος στη διαφάνεια. Αλλάζει το 3Δ σημείο θέασης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη εξώθησης και βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από την μπροστινή πλευρά. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint συνδεδεμένοι με τις ιδιότητες χρώματος εξώθησης και ύψους εξώθησης](img_02_02.png)

Ορίστε το [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) για το πάχος και το [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) για το χρώμα των πλευρών:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

Χρησιμοποιήστε το [IThreeDFormat.setDepth](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) όταν χρειάζεται να εργαστείτε άμεσα με την τιμή βάθους του PowerPoint ή να συνδυάσετε το βάθος με χωνεύτη, υλικό και εφέ κειμένου. Σε πολλές περιπτώσεις σχήματος, το `setExtrusionHeight` είναι η πιο ξεκάθαρη ρύθμιση επειδή εκφράζει άμεσα την ορατή εξώθηση.

## **Χρήση γεμίσματος διαβάθμισης ή εικόνας με εφέ 3Δ**

Η μορφοποίηση 3Δ είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε ένα συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην μπροστινή πλευρά και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτός, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει γέμισμα διαβάθμισης στο σχήμα και πιο σκούρο χρώμα εξώθησης στις πλευρές:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

Η αποδιδόμενη έξοδος διατηρεί τη διαβάθμιση στην μπροστινή πλευρά και αποδίδει την εξώθηση ξεχωριστά:

![Αποδιδόμενο 3Δ ορθογώνιο με γέμισμα διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και αναθέστε τη στο γέμισμα του σχήματος:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

![Αποδιδόμενο 3Δ ορθογώνιο με γέμισμα φωτογραφίας στην μπροστινή πλευρά και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή μορφοποίησης 3Δ σε κείμενο**

Η μορφοποίηση 3Δ του σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3Δ του κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με γέμισμα μοτίβου, εφαρμόζει μετασχηματισμό WordArt και διαμορφώνει ρυθμίσεις 3Δ στο [ITextFrameFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/):

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
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

![Αποδιδόμενο 3Δ κείμενο με κυρτό μετασχηματισμό WordArt, γέμισμα μοτίβου πορτοκαλί και σκούρα εξώθηση](img_02_05.png)

## **Συμπεριφορά εξαγωγής και απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3Δ κατά την αποθήκευση σε μορφές PowerPoint όπως PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερής διάταξης, η σκηνή 3Δ μετατρέπεται σε bitmap ή σχεδιάζεται στην έξοδο ως αποτέλεσμα 2Δ. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/androidjava/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/androidjava/convert-powerpoint-to-html/), ή δημιουργείτε πλαίσια για [video conversion](/slides/el/androidjava/convert-powerpoint-to-video/).

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από τον συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γεμίσματος και κλιμάκωσης διαφάνειας.
- Αν χρειάζεστε να ελέγξετε τις κληρονομημένες ή βάση θέματος τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/androidjava/shape-effective-properties/).
- Κάποιες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3Δ του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3Δ.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3Δ παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3Δ του PowerPoint για σχήματα και κείμενο. Δεν μετατρέπει τις εξαγόμενες εικόνες, τα PDF ή τις σελίδες HTML σε διαδραστικές 3Δ σκηνές που ο θεατής μπορεί να περιστρέψει. Σε PPTX, η μορφοποίηση 3Δ παραμένει επεξεργάσιμη στο PowerPoint όταν η μορφή τη υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ ενός 3Δ μοντέλου και ενός 3Δ εφέ;**

Ένα 3Δ μοντέλο είναι ένα ξεχωριστό τρισδιάστατο αντικείμενο που εισάγεται σε μια παρουσίαση. Ένα 3Δ εφέ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, χωνευτή, φωτισμό και υλικό. Αυτό το άρθρο καλύπτει εφέ 3Δ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό σχήμα 3Δ;**

Τελάχιστα, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτισμό και υλικό ώστε οι αποδιδόμενες όψεις να έχουν ξεκάθαρα φωτισμένα σημεία και σκιές.

**Μπορώ να εφαρμόσω εφέ 3Δ σε σχήματα και κείμενο;**

Ναι. Χρησιμοποιήστε το [IShape.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) για το σώμα του σχήματος και το [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) για το κείμενο.

**Θα εμφανίζονται τα εφέ 3Δ κατά την εξαγωγή σε εικόνες, PDF, HTML ή πλαίσια βίντεο;**

Ναι. Το Aspose.Slides αποδίδει εφέ 3Δ κατά τη δημιουργία εικόνων διαφανειών, εξόδου PDF, εξόδου HTML και πλαισίων που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδιδόμενη εμφάνιση, όχι ένα επεξεργάσιμο αντικείμενο 3Δ.

**Μπορώ να διαβάσω τις τελικές τιμές 3Δ μετά την κληρονομική και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα API αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/androidjava/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, χωνεύτη και συναφείς τιμές 3Δ.