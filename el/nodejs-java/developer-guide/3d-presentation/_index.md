---
title: Δημιουργία 3D Εφέ σε Παρουσιάσεις με Node.js
linktitle: 3D Παρουσίαση
type: docs
weight: 232
url: /el/nodejs-java/3d-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3D εφέ για σχήματα και κείμενο PowerPoint σε Node.js με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3D κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides για Node.js μέσω Java μπορεί να δημιουργεί, επεξεργάζεται, διατηρεί και αποδίδει μορφοποίηση 3D στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3D όπως περιστροφή, εξώθηση, πλάγια άκρα, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα εικόνας, και κείμενο 3D.

{{% alert color="info" title="Note" %}}
Αυτό το άρθρο αφορά εφέ μορφοποίησης 3D σε σχήματα και κείμενο PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία ανεξάρτητων αρχείων μοντέλου 3D. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3D στην εξαγόμενη 2D έξοδο.
{{% /alert %}}

## **Έννοιες Μορφοποίησης 3D**

Χρησιμοποιήστε τη μέθοδο [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) για να εφαρμόσετε μορφοποίηση 3D σε ένα σχήμα. Η μέθοδος επιστρέφει το [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/), το οποίο ελέγχει τη σκηνή 3D για εκείνο το σχήμα.

Για κείμενο, χρησιμοποιήστε τη μέθοδο [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Αυτό εφαρμόζει μορφοποίηση 3D στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Τα πιο σημαντικά μέλη του API είναι:

| Μέλος API | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | Σημείο θέσης, προκαθορισμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο στον 3D χώρο ή ταιριάξτε με μια προεπιλεγμένη περιστροφή 3D του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | Προεπιλογή φωτός, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο με τον οποίο εμφανίζονται οι αντανακλάσεις και οι σκιές στην 3D επιφάνεια. |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) και [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, πιο απαλό, λαμπρό ή μεταλλικό. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) και [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Πόσο μακριά εκτείνεται το σχήμα προς τα πίσω από το μπροστινό του πρόσωπο. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατά παχύ 3D αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με το γέμισμα του μπροστινού. |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) και [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | Πρόσθετο 3D βάθος που χρησιμοποιείται από τη μορφοποίηση 3D του PowerPoint. | Ρυθμίστε με ακρίβεια το βάθος για σχήματα ή κείμενο, ειδικά μαζί με ρυθμίσεις πλάγια άκρα και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) και [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Ανασηκωμένα ή στρογγυλεμένα άκρα στα μπροστινά και πίσω πρόσωπα. | Προσθέστε ένα μαλακό ή χυλωμένο άκρο αντί ενός κόψιμου επίπεδου προσώπου. |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth) και [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Περιγράμμιση γύρω από το 3D αντικείμενο. | Τονίστε το περίγραμμα του αντικειμένου στην αποδοθείσα έξοδο. |

## **Δημιουργία 3D Σχήματος**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν εμφανιστεί πειστικά 3D:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη μπροστινή όψη μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις πλευρές και τις όψεις αναγνώσιμες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει το πώς αποδίδεται το φως.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην μπροστινή του όψη και εφαρμόζει μορφοποίηση 3D. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες και το ύψος εξώθησης είναι 100 points. Το παράδειγμα αποδίδει τη διαφάνεια σε εικόνα PNG με διπλό μέγεθος από το προεπιλεγμένο και αποθηκεύει την παρουσίαση ως PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

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

Η αποδοθείσα εικόνα της διαφάνειας δείχνει το ορθογώνιο ως παχύ 3D μπλοκ:

![Αποδοθείσα μπλε 3D ορθογώνιο με λευκό 3D κείμενο στο μπροστινό πρόσωπο](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3D περιστροφή ρυθμίζεται από το παράθυρο 3‑Δ Περιστροφής. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Παράθυρο 3‑Δ Περιστροφής του PowerPoint με επισημασμένες τις τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, προσπελάστε την κάμερα μέσω του [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera). Το παράδειγμα αυτό δημιουργεί ένα ορθογώνιο, επιλέγει μια ορθογώνια μπροστινή όψη και ορίζει τις περιστροφές X, Y, Z σε 20, 30 και 40 μοίρες αντίστοιχα. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2D σχήματος στη διαφάνεια. Αλλάζει το 3D σημείο θέσης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

### **Αντιγραφή Προσανατολισμού Κάμερας από Σχήμα Προτύπου**

Για να ταιριάξετε τον προσανατολισμό ενός σχήματος προτύπου, διαβάστε το προεπιλεγμένο της κάμερας με [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) και τις γωνίες περιστροφής του με [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation). Το παράδειγμα ανοίγει `template.pptx` και αντιγράφει τον προσανατολισμό της κάμερας από το πρώτο σχήμα στην πρώτη διαφάνεια στο δεύτερο σχήμα. Και τα δύο σχήματα έχουν ήδη 3D φωτισμό, ενώ στο δεύτερο σχήμα δεν υπάρχει ρητή περιστροφή κάμερας.

Οι γωνίες είναι σε μοίρες. Ο δείκτης `0` είναι γεωγραφικό πλάτος, ο δείκτης `1` είναι γεωγραφικό μήκος και ο δείκτης `2` είναι περιστροφή. Περάστε τα στο [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) με αυτή τη σειρά. Αν η πηγή επιστρέψει `null`, δεν έχει ρητή περιστροφή, οπότε αφήστε τις γωνίες του δεύτερου σχήματος ακαθορισμένες. Μια ρητή περιστροφή `(0, 0, 0)` επιστρέφει τρία μηδέν και πρέπει να αντιγραφεί.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    const destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    const angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Όταν ανοίξετε ξανά το `camera-copy.pptx` στο PowerPoint, το βέλος δεξιά έχει την ίδια προεπιλογή κάμερας και περιστροφή με το ορθογώνιο αριστερά. Και τα δύο σχήματα χρησιμοποιούν τον ίδιο φωτισμό και το βάθος εξώθησης.

![Μπλε 3D ορθογώνιο και δεξιός βέλος με αντίστοιχο προσανατολισμό κάμερας, απεικόνιση από πάνω και δεξιά](camera-orientation.png)

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από το μπροστινό πρόσωπο. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτή τη ορατή πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους PowerPoint συνδεδεμένοι με τις ιδιότητες χρώματος εξώθησης και ύψους εξώθησης](img_02_02.png)

Χρησιμοποιήστε το [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) για να ορίσετε το πάχος και το [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) για πρόσβαση στο χρώμα των πλευρών. Το παράδειγμα αυτό δίνει στο ορθογώνιο εξώθηση 100 points με μωβ πλευρές και περιστρέφει την κάμερα ώστε να φαίνεται το πάχος. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Η μέθοδος [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) ορίζει το βάθος ενός 3D σχήματος. Η μέθοδος [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) ελέγχει το ύψος του εφέ εξώθησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση Διαβαθμίσεων ή Γεμίσματος Εικόνας με Εφέ 3D**

Η μορφοποίηση 3D είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε ένα συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στο μπροστινό πρόσωπο και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Το παράδειγμα αυτό εφαρμόζει διαβάθμιση μπλε‑πορτοκαλί στο μπροστινό πρόσωπο και χρώμα σκούρου πορτοκαλί στην εξώθηση 150 points. Τα σημεία διαβάθμισης στα 0 και 100 σηματοδοτούν την αρχή και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες. Η διαφάνεια αποδίδεται σε εικόνα PNG με διπλό μέγεθος από το προεπιλεγμένο:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

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

Η αποδοθείσα έξοδος διατηρεί τη διαβάθμιση στο μπροστινό πρόσωπο και αποδίδει την εξώθηση ξεχωριστά:

![Αποδοθείσα 3D ορθογώνιο με γέμισμα διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και αναθέστε την στο γέμισμα του σχήματος. Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο με το όνομα "image.jpg" στον τρέχοντα φάκελο. Τεντώνει τη φωτογραφία ώστε να γεμίσει το ορθογώνιο, εφαρμόζει εξώθηση 150 points και ορίζει την περιστροφή της κάμερας σε μοίρες. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Η φωτογραφία αποδίδεται στο μπροστινό πρόσωπο, ενώ η εξώθηση αποδίδεται ως η 3D πλευρική επιφάνεια:

![Αποδοθείσα 3D ορθογώνιο με γέμισμα φωτογραφίας στο μπροστινό πρόσωπο και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3D σε Κείμενο**

Η 3D μορφοποίηση σχήματος επηρεάζει το σώμα του σχήματος. Η 3D μορφοποίηση κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με μοτίβο πλέγματος πορτοκαλί‑λευκό, εφαρμόζει μια αψιοειδή καμάρα και διαμορφώνει τις ρυθμίσεις 3D μέσω του [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Το ύψος εξώθησης και το βάθος είναι σε points, και η περιστροφή του φωτός σε μοίρες. Το γέμισμα του σχήματος και το περίγραμμα είναι κρυμμένα ώστε να είναι ορατό μόνο το κείμενο. Το παράδειγμα αποδίδει εικόνα PNG με διπλό μέγεθος από την προεπιλεγμένη διάσταση της διαφάνειας και αποθηκεύει την παρουσίαση ως PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

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
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
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

Το κείμενο αποδίδεται ως καμπυλωτά, εξωθημένα 3D γράμματα:

![Αποδομένο 3D κείμενο με καμπυλωτή μετατροπή WordArt, γέμισμα μοτίβου πορτοκαλί και σκούρα εξώθηση](img_02_05.png)

## **Διατήρηση Κειμένου Επίπεδου σε 3D Σχήμα**

Για να διατηρήσετε το κείμενο αναγνώσιμο ενώ διατηρείτε την 3D εμφάνιση του σχήματος, καλέστε το [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) μέσω του [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). Όταν η τιμή είναι `true`, το κείμενο παραμένει εκτός της 3D σκηνής. Όταν είναι `false`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί τον 3D προσανατολισμό.

Αυτή η ρύθμιση δεν αφαιρεί τη 3D μορφοποίηση του σχήματος: η κάμερα, ο φωτισμός, το υλικό και η εξώθηση παραμένουν ρυθμισμένα μέσω του [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat). Είναι επίσης διαφορετικό από την απλή περιστροφή. Το [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ το [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου μέσα στο πλαίσιο του. Η διατήρηση του κειμένου εκτός της 3D σκηνής δεν επαναπροσδιορίζει καμία από αυτές τις γωνίες.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το κλωνοποιεί δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια 3D μορφοποίηση· μόνο η ρύθμιση κειμένου διαφέρει: `false` στα αριστερά και `true` στα δεξιά. Οι γωνίες της κάμερας είναι σε μοίρες και το ύψος εξώθησης είναι 40 points. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σύγκρισης σε PNG με διπλό μέγεθος από το προεπιλεγμένο.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Αριστερά, το κείμενο ακολουθεί τον 3D προσανατολισμό. Δεξιά, παραμένει επίπεδο και πιο εύκολο στην ανάγνωση. Και τα δύο ορθογώνια διατηρούν την ίδια ορατή εξώθηση και 3D προσανατολισμό.

![Παρτεντέ 3D ορθογώνια: το κείμενο ακολουθεί τον 3D προσανατολισμό στα αριστερά και παραμένει επίπεδο στα δεξιά](keep_text_flat.png)

## **Εξαγωγή και Συμπεριφορά Απόδοσης**

Το Aspose.Slides διατηρεί τη 3D μορφοποίηση κατά την αποθήκευση σε μορφές PowerPoint όπως PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές στατικού layout, η 3D σκηνή ραστεροποιείται ή σχεδιάζεται στην έξοδο ως 2D αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/nodejs-java/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/nodejs-java/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [video conversion](/slides/el/nodejs-java/convert-powerpoint-to-video/).

Λάβετε υπόψη τα εξής σημεία:

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γέμισης και κλιμάκωσης διαφάνειας.
- Αν χρειάζεστε να εξετάσετε κληρονομημένες ή θεματικές τιμές μορφοποίησης, διαβάστε τις [αποτελεσματικές ιδιότητες σχήματος](/slides/el/nodejs-java/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη 3D μορφοποίηση PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες 3D ρυθμίσεις.

## **FAQ**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3D παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3D του PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή HTML σε διαδραστικές 3D σκηνές που ένας θεατής μπορεί να περιστρέψει. Σε PPTX, η μορφοποίηση 3D παραμένει επεξεργάσιμη στο PowerPoint όπου το φορμάτ το υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ ενός 3D μοντέλου και ενός 3D εφέ;**

Ένα 3D μοντέλο είναι ένα ξεχωριστό 3D αντικείμενο που εισάγεται σε μια παρουσίαση. Ένα 3D εφέ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, πλάγιο άκρο, φωτισμός και υλικό. Αυτό το άρθρο καλύπτει τα 3D εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3D σχήμα;**

Ως ελάχιστο, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης ένα σύστημα φωτισμού και υλικό ώστε οι αποδιδόμενες όψεις να έχουν σαφείς αντανακλάσεις και σκιές.

**Μπορώ να εφαρμόσω 3D εφέ τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) για το σώμα του σχήματος και το [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) για το κείμενο.

**Θα εμφανιστούν τα 3D εφέ κατά την εξαγωγή σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα 3D εφέ όταν δημιουργεί εικόνες διαφανειών, έξοδο PDF, έξοδο HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδιδόμενη εμφάνιση, όχι ένα επεξεργάσιμο 3D αντικείμενο.

**Μπορώ να διαβάσω τις τελικές 3D τιμές μετά την κληρονομιά και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [αποτελεσματικές ιδιότητες σχήματος](/slides/el/nodejs-java/shape-effective-properties/).