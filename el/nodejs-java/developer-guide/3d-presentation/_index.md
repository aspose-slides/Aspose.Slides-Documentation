---
title: Δημιουργία 3Δ εφέ σε παρουσιάσεις χρησιμοποιώντας Node.js
linktitle: 3Δ Παρουσίαση
type: docs
weight: 232
url: /el/nodejs-java/3d-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3Δ εφέ για σχήματα και κείμενο PowerPoint σε Node.js με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3Δ κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides για Node.js μέσω Java μπορεί να δημιουργήσει, να επεξεργαστεί, να διατηρήσει και να αποδώσει μορφοποίηση 3Δ σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφή, εξώθηση, κλίκωση, φωτισμό, υλικό, γεμίσματα διαβάθμισης ή εικόνας και κείμενο 3Δ.

{{% alert color="primary" %}}
Αυτό το άρθρο αφορά εφέ μορφοποίησης 3Δ σε σχήματα και κείμενο PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία ανεξάρτητων αρχείων μοντέλων 3Δ. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3Δ στην εξαγόμενη 2Δ έξοδο.
{{% /alert %}}

## **Αρχές Μορφοποίησης 3Δ**

Χρησιμοποιήστε το [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` για να εφαρμόσετε μορφοποίηση 3Δ σε ένα σχήμα. Το επιστρεφόμενο αντικείμενο [ThreeDFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/) ελέγχει τη σκηνή 3Δ για εκείνο το σχήμα.

Για το κείμενο, χρησιμοποιήστε το [TextFrameFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()`. Αυτό εφαρμόζει μορφοποίηση 3Δ στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Τα πιο σημαντικά μέλη του API είναι:

| Μέλος API | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getCamera) | Οπτική γωνία, προκαθορισμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο στο χώρο 3Δ ή ταιριάξτε με μια προκαθορισμένη περιστροφή 3Δ του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getLightRig) | Προκαθορισμένο φως, κατεύθυνση και περιστροφή φωτός. | Αλλαγή του τρόπου με τον οποίο εμφανίζονται οι αντανακλάσεις και οι σκιές στην επιφάνεια 3Δ. |
| [getMaterial](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#setMaterial) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, μαλακότερη, γυαλιστερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Πόσο μακριά επεκτείνεται το σχήμα προς τα πίσω από την μπρούμυρη πλευρά του. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατά παχύ 3Δ αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος εμφανές ή συντονίστε το χρώμα των πλευρών με τη γέμιση της μπροστινής πλευράς. |
| [getDepth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#setDepth) | Πρόσθετο βάθος 3Δ που χρησιμοποιείται από τη μορφοποίηση 3Δ του PowerPoint. | Ρυθμίστε με ακρίβεια το βάθος για σχήματα ή κείμενο, ιδίως σε συνδυασμό με ρυθμίσεις κλίκωσης και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Ανασηκωμένα ή στρογγυλεμένα άκρα στις μπροστινές και πίσω πλευρές. | Προσθέστε ένα μαλακό ή καλυμμένο άκρο αντί για μια αιχμηρή επίπεδη πλευρά. |
| [getContourColor](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Περίγραμμα γύρω από το αντικείμενο 3Δ. | Τονίστε το όριο του αντικειμένου στην αποτυπωμένη έξοδο. |

## **Δημιουργία Σχήματος 3Δ**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν φαίνεται πεπειστικά 3Δ:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη μπροστινή προβολή μπορεί να κρύψει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις πλευρές και τα πρόσωπα ευανάγνωστα.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στη μπροστινή του πλευρά, εφαρμόζει μορφοποίηση 3Δ, αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σε εικόνα PNG.

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αποδομένη εικόνα της διαφάνειας δείχνει το ορθογώνιο ως ένα παχύ 3Δ μπλοκ:

![Αποδομένο μπλε 3Δ ορθογώνιο με λευκό 3Δ κείμενο στη μπροστινή επιφάνεια](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η περιστροφή 3Δ ρυθμίζεται από το παράθυρο 3‑Δ Περιστροφή. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Παράθυρο 3‑Δ Περιστροφή του PowerPoint με επισημασμένες τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, ορίστε τον τύπο κάμερας και την περιστροφή μέσω της μορφοποίησης 3Δ που επιστρέφεται από `shape.getThreeDFormat()`:

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία 2Δ του σχήματος στη διαφάνεια. Αλλάζει την 3Δ οπτική γωνία που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από τη μπροστινή πλευρά. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών επιφανειών.

![Έλεγχοι βάθους του PowerPoint χαρτογραφημένοι σε ιδιότητες χρώματος εξώθησης και ύψους εξώθησης](img_02_02.png)

Ορίστε το ύψος εξώθησης για το πάχος και το χρώμα εξώθησης για το χρώμα των πλευρών:

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Χρησιμοποιήστε τη ρύθμιση βάθους όταν χρειάζεται να δουλέψετε απευθείας με την τιμή βάθους του PowerPoint ή να συνδυάσετε το βάθος με κλίκωση, υλικό και εφέ κειμένου. Σε πολλές περιπτώσεις σχήματος, το ύψος εξώθησης είναι η πιο σαφής ρύθμιση επειδή εκφράζει άμεσα την ορατή εξώθηση.

## **Χρήση Γεμισμάτων Διαβάθμισης ή Εικόνας με Εφέ 3Δ**

Η μορφοποίηση 3Δ είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε σταθερό χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στη μπροστινή πλευρά και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει γέμισμα διαβάθμισης στο σχήμα και πιο σκούρο χρώμα εξώθησης στις πλευρές:

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Η αποδομένη έξοδος διατηρεί τη διαβάθμιση στη μπροστινή πλευρά και αποδίδει την εξώθηση ξεχωριστά:

![Αποδομένο 3Δ ορθογώνιο με γέμισμα διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και αναθέστε τη στο γέμισμα του σχήματος:

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

![Αποδομένο 3Δ ορθογώνιο με γέμισμα φωτογραφίας στη μπροστινή πλευρά και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3Δ σε Κείμενο**

Η μορφοποίηση 3Δ του σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3Δ του κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα απαιτούν εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με γέμισμα μοτίβου, εφαρμόζει μετασχηματισμό WordArt και διαμορφώνει τις ρυθμίσεις 3Δ στο [TextFrameFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/):

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Αποδομένο 3Δ κείμενο με κυρτό μετασχηματισμό WordArt, πορτοκαλί γέμισμα μοτίβου και σκούρα εξώθηση](img_02_05.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3Δ κατά την αποθήκευση σε μορφές PowerPoint όπως το PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερού layout, η σκηνή 3Δ μετατρέπεται σε raster ή σχεδιάζεται στην έξοδο ως αποτέλεσμα 2Δ. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/nodejs-java/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/nodejs-java/convert-powerpoint-to-html/), ή δημιουργείτε πλαίσια για [μετατροπή βίντεο](/slides/el/nodejs-java/convert-powerpoint-to-video/).

Διατηρήστε τα παρακάτω σημεία στο μυαλό σας:

- Οι εικόνες και τα PDFs που εξάγονται δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από τον συνδυασμό κάμερας, φωτιστικού, υλικού, εξώθησης, γεμίσματος και κλιμάκωσης διαφάνειας.
- Εάν χρειάζεται να ελέγξετε κληρονομημένες ή θεματικές τιμές μορφοποίησης, διαβάστε τις [αποτελεσματικές ιδιότητες σχήματος](/slides/el/nodejs-java/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3Δ του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3Δ.

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3Δ παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3Δ του PowerPoint για σχήματα και κείμενο. Δεν καθιστά τις εξαγόμενες εικόνες, PDFs ή σελίδες HTML διαδραστικές σκηνές 3Δ που ένας θεατής μπορεί να περιστρέψει. Σε PPTX, η μορφοποίηση 3Δ παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή την υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ μοντέλου 3Δ και εφέ 3Δ;**

Ένα μοντέλο 3Δ είναι ένα ξεχωριστό αντικείμενο 3Δ που εισάγεται σε μια παρουσίαση. Ένα εφέ 3Δ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, κλίκωση, φωτισμός και υλικό. Αυτό το άρθρο καλύπτει εφέ 3Δ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό σχήμα 3Δ;**

Ελάχιστο, ορίστε περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτιστικό και υλικό ώστε οι αποδομένες πλευρές να έχουν σαφείς αντανακλάσεις και σκιές.

**Μπορώ να εφαρμόσω εφέ 3Δ τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` για το σώμα του σχήματος και το [TextFrameFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` για το κείμενο.

**Θα εμφανιστούν τα εφέ 3Δ κατά την εξαγωγή σε εικόνες, PDF, HTML ή πλαίσια βίντεο;**

Ναι. Το Aspose.Slides αποδίδει εφέ 3Δ όταν παράγει εικόνες διαφανειών, έξοδο PDF, έξοδο HTML και πλαίσια που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδομένη εμφάνιση, όχι ένα επεξεργάσιμο αντικείμενο 3Δ.

**Μπορώ να διαβάσω τις τελικές τιμές 3Δ μετά την εφαρμογή κληρονομικών και θεματικών ρυθμίσεων;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στο [Αποτελεσματικές Ιδιότητες Σχήματος](/slides/el/nodejs-java/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτιστικού, κλίκωσης και σχετικές τιμές 3Δ.