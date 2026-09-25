---
title: Δημιουργία 3D εφέ σε παρουσιάσεις με PHP
linktitle: 3D Παρουσίαση
type: docs
weight: 232
url: /el/php-java/3d-presentation/
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
- PHP
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3D εφέ για σχήματα και κείμενο PowerPoint σε PHP με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3D κείμενο."
---
## **Επισκόπηση**

Aspose.Slides for PHP via Java μπορεί να δημιουργήσει, να επεξεργαστεί, να διατηρήσει και να αποδώσει 3D μορφοποίηση τύπου PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει 3D εφέ όπως περιστροφή, εξώθηση, λείες άκρες, φωτισμό, υλικό, γεμίσματα διαβάθμισης ή εικόνας και 3D κείμενο.

{{% alert color="info" title="Σημείωση" %}}

Αυτό το άρθρο αφορά τα 3D εφέ μορφοποίησης σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία αυτόνομων αρχείων 3D μοντέλων. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα 3D εφέ στην εξαγόμενη 2D έξοδο.

{{% /alert %}}

## **Έννοιες 3D Μορφοποίησης**

Χρησιμοποιήστε τη μέθοδο [Shape::getThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getThreeDFormat--) για να εφαρμόσετε 3D μορφοποίηση σε ένα σχήμα. Η μέθοδος επιστρέφει το αντικείμενο [ThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/), το οποίο ελέγχει τη 3D σκηνή για εκείνο το σχήμα.

Για κείμενο, χρησιμοποιήστε τη μέθοδο [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#getThreeDFormat--) . Αυτό εφαρμόζει 3D μορφοποίηση στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Τα πιο σημαντικά μέλη του API είναι:

| Μέλος API | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getCamera--) | Σημείο θέας, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε 3D χώρο ή ταιριάξτε μια προεπιλογή περιστροφής 3D του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getLightRig--) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε την εμφάνιση των αντανακλασμάτων και των σκιών στην 3D επιφάνεια. |
| [getMaterial](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getMaterial--) και [setMaterial](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Υλικό επιφάνειας, π.χ. επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε τη γεωμετρία πιο επίπεδη, μαλακότερη, γυαλιστερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getExtrusionHeight--) και [setExtrusionHeight](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από την πρόσθια όψη. | Μετατρέψτε ένα επίπεδο σχήμα σε ορατά παχύ 3D αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Χρώμα των εξωτερικών πλευρών. | Κάντε το βάθος ορατό ή εναρμονίστε το χρώμα των πλευρών με το γέμισμα του προσώπου. |
| [getDepth](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getDepth--) και [setDepth](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#setDepth-double-) | Πρόσθετο 3D βάθος που χρησιμοποιείται από τη μορφοποίηση 3D του PowerPoint. | Ρυθμίστε ακριβώς το βάθος για σχήματα ή κείμενο, ειδικά μαζί με τις ρυθμίσεις λείων άκρων και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getBevelTop--) και [getBevelBottom](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getBevelBottom--) | Αναγράμμιση ή στρογγυλεμένες άκρες στις πρόσθιες και οπίσθιες όψεις. | Προσθέστε μια μαλακή ή χωνευμένη άκρη αντί για μια αιχμηρή επίπεδη όψη. |
| [getContourColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getContourColor--) και [getContourWidth](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getContourWidth--) και [setContourWidth](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Περίγραμμα γύρω από το 3D αντικείμενο. | Τονίστε τα όρια του αντικειμένου στην αποδιδόμενη έξοδο. |

## **Δημιουργία 3D Σχήματος**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν φαίνεται πειστικά 3D:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές αναγνώσιμες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην πρόσθια όψη του και εφαρμόζει 3D μορφοποίηση. Οι τιμές περιστροφής της κάμερας δίνονται σε μοίρες και το ύψος εξώθησης είναι 100 μονάδες. Το παράδειγμα αποδίδει τη διαφάνεια σε εικόνα PNG με διπλάσια διάσταση από την προεπιλογή και αποθηκεύει την παρουσίαση ως PPTX.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Η αποδομένη εικόνα της διαφάνειας δείχνει το ορθογώνιο ως παχύ 3D μπλοκ:

![Απόδοση μπλε 3D ορθογωνίου με λευκό 3D κείμενο στην πρόσθια όψη](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3D περιστροφή ρυθμίζεται από το παράθυρο 3‑D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στη περιστροφή που ορίζετε μέσω του API κάμερας.

![Παράθυρο 3‑D Rotation του PowerPoint με επισημασμένες τιμές X, Y και Z](img_02_01.png)

Στο Aspose.Slides, αποκτήστε πρόσβαση στην κάμερα μέσω του [ThreeDFormat::getCamera](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getCamera--) . Αυτό το παράδειγμα δημιουργεί ένα ορθογώνιο, επιλέγει ορθογραφική προοπτική μπροστά και ορίζει τις περιστροφές X, Y και Z στις 20, 30 και 40 μοίρες αντίστοιχα. Διαμορφώνει το σχήμα στη μνήμη χωρίς να αποθηκεύει αρχείο:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2D σχήματος στη διαφάνεια. Αλλάζει το 3D σημείο θέας που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντας το πίσω από την πρόσθια όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint αντιστοιχούμενοι σε ιδιότητες χρώματος και ύψους εξώθησης](img_02_02.png)

Χρησιμοποιήστε τη μέθοδο [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) για να ορίσετε το πάχος και τη μέθοδο [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getExtrusionColor--) για πρόσβαση στο χρώμα των πλευρών. Αυτό το παράδειγμα δίνει σε ένα ορθογώνιο εξώθηση 100 μονάδων με μοβ πλευρές και περιστρέφει την κάμερα ώστε να εμφανιστεί το πάχος. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

Η μέθοδος [ThreeDFormat::setDepth](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#setDepth-double-) ορίζει το βάθος ενός 3D σχήματος. Η μέθοδος [setExtrusionHeight](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) ελέγχει το ύψος του εφέ εξώθησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση Γεμίσματος Διαβάθμισης ή Εικόνας με 3D Εφέ**

Η 3D μορφοποίηση είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην πρόσθια όψη και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτός, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει διαβάθμιση από μπλε σε πορτοκαλί στην πρόσθια όψη και ένα σκοτεινό πορτοκαλί χρώμα στην εξώθηση 150 μονάδων. Τα σημεία διαβάθμισης στο 0 και 100 υποδεικνύουν την αρχή και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες. Η διαφάνεια αποδίδεται σε εικόνα PNG με διπλάσια διάσταση από την προεπιλογή:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Η αποδομένη έξοδος διατηρεί τη διαβάθμιση στην πρόσθια όψη και αποδίδει την εξώθηση ξεχωριστά:

![Απόδοση 3D ορθογωνίου με διαβάθμιση μπλε‑πορτοκαλί και εξώθηση πορτοκαλί](img_02_03.png)

Για χρήση γεμίσματος εικόνας, προσθέστε την εικόνα στην παρουσίαση και εκχωρήστε την στο γέμισμα του σχήματος. Αυτό το παράδειγμα απαιτεί υπάρχον αρχείο με όνομα "image.jpg" στον τρέχοντα φάκελο. Επεκτείνει την εικόνα ώστε να καλύψει το ορθογώνιο, εφαρμόζει εξώθηση 150 μονάδων και ορίζει την περιστροφή της κάμερας σε μοίρες. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

Η εικόνα αποδίδεται στην πρόσθια όψη, ενώ η εξώθηση αποδίδεται ως η 3D πλευρική επιφάνεια:

![Απόδοση 3D ορθογωνίου με γέμισμα φωτογραφίας στην πρόσθια όψη και εξώθηση πορτοκαλί](img_02_04.png)

## **Εφαρμογή 3D Μορφοποίησης σε Κείμενο**

Η 3D μορφοποίηση σχήματος επηρεάζει το σώμα του σχήματος. Η 3D μορφοποίηση κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το ακόλουθο παράδειγμα δημιουργεί κείμενο με μοτίβο πορτοκαλί‑λευκού πλέγματος, εφαρμόζει ένα ανώτερο τόξο και διαμορφώνει 3D ρυθμίσεις μέσω του [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Το ύψος εξώθησης και το βάθος δίνονται σε μονάδες, η περιστροφή φωτός σε μοίρες. Το γέμισμα και το περίγραμμα του σχήματος κρύβονται έτσι ώστε να φαίνεται μόνο το κείμενο. Το παράδειγμα αποδίδει μια PNG εικόνα με διπλάσια διάσταση από την προεπιλογή και αποθηκεύει την παρουσίαση ως PPTX:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το κείμενο αποδίδεται ως καμπυλωτά, εξωθήματα 3D γράμματα:

![Απόδοση 3D κειμένου με καμπυλωτό WordArt, γεμισμα μοτίβου πορτοκαλί και σκούρα εξώθηση](img_02_05.png)

## **Διατήρηση Καθολικού Κειμένου σε 3D Σχήμα**

Για να διατηρήσετε το κείμενο αναγνώσιμο ενώ διατηρείτε την 3D εμφάνιση του σχήματος, καλέστε το [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setKeepTextFlat-boolean-) μέσω του [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframe/#getTextFrameFormat--) . Όταν η τιμή είναι `true`, το κείμενο παραμένει εκτός της 3D σκηνής. Όταν είναι `false`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί τον 3D προσανατολισμό.

Αυτή η ρύθμιση δεν αφαιρεί τη 3D μορφοποίηση του σχήματος: η κάμερα, ο φωτισμός, το υλικό και η εξώθηση παραμένουν ρυθμισμένα μέσω του [Shape::getThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getThreeDFormat--) . Διαφέρει επίσης από τη συνηθισμένη περιστροφή. Η [Shape::setRotation](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#setRotation-float-) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ η [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#setRotationAngle-float-) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου μέσα στο πλαίσιο του. Η διατήρηση του κειμένου εκτός της 3D σκηνής δεν επαναφέρει κανένα από αυτά τα γωνία.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το κλωνοποιεί δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια 3D μορφοποίηση· μόνο η ρύθμιση κειμένου διαφέρει: `false` στα αριστερά και `true` στα δεξιά. Οι γωνίες της κάμερας είναι σε μοίρες και το ύψος εξώθησης είναι 40 μονάδες. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σύγκρισης σε PNG με διπλάσια διάσταση από την προεπιλογή.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Στα αριστερά, το κείμενο ακολουθεί τον 3D προσανατολισμό. Στα δεξιά, παραμένει επίπεδο και πιο εύκολα αναγνώσιμο. Και τα δύο ορθογώνια διατηρούν την ίδια ορατή εξώθηση και 3D προσανατολισμό.

![Δίπλα‑πλάι 3D ορθογώνια: κείμενο ακολουθεί τον 3D προσανατολισμό στα αριστερά και παραμένει επίπεδο στα δεξιά](keep_text_flat.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη 3D μορφοποίηση κατά την αποθήκευση σε μορφές PowerPoint όπως το PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερής διάταξης, η 3D σκηνή ραστεριώνεται ή σχεδιάζεται στην έξοδο ως 2D αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/php-java/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/php-java/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/php-java/convert-powerpoint-to-html/), ή δημιουργείτε πλαίσια για [μετατροπή βίντεο](/slides/el/php-java/convert-powerpoint-to-video/).

Λάβετε υπόψη τα εξής:

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γεμίσματος και κλιμάκωσης διαφάνειας.
- Αν χρειάζεστε να εξετάσετε κληρονομημένες ή βασισμένες στο θέμα τιμές μορφοποίησης, διαβάστε τις [ιδιότητες αποτελεσματικού σχήματος](/slides/el/php-java/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη 3D μορφοποίηση PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες 3D ρυθμίσεις.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3D παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει 3D εφέ PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή HTML σελίδες διαδραστικές 3D σκηνές που ο θεατής μπορεί να περιστρέψει. Σε PPTX, η 3D μορφοποίηση παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή το υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ 3D μοντέλου και 3D εφέ;**

Ένα 3D μοντέλο είναι ξεχωριστό 3D αντικείμενο που εισάγεται σε παρουσίαση. Ένα 3D εφέ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, λείο άκρο, φωτισμός και υλικό. Αυτό το άρθρο καλύπτει 3D εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3D σχήμα;**

Ελάχιστα, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτισμό και υλικό ώστε οι αποδομένες όψεις να έχουν σαφή αντανακλάσματα και σκιές.

**Μπορώ να εφαρμόσω 3D εφέ σε σχήματα και κείμενο;**

Ναι. Χρησιμοποιήστε το [Shape::getThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getThreeDFormat--) για το σώμα του σχήματος και το [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#getThreeDFormat--) για το κείμενο.

**Θα εμφανιστούν τα 3D εφέ όταν εξάγω σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα 3D εφέ όταν δημιουργεί εικόνες διαφανειών, PDF, HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδομένη εμφάνιση, όχι ένα επεξεργάσιμο 3D αντικείμενο.

**Μπορώ να διαβάσω τις τελικές 3D τιμές μετά την κληρονομικότητα και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [ιδιότητες αποτελεσματικού σχήματος](/slides/el/php-java/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, λείων άκρων και σχετικές 3D τιμές.