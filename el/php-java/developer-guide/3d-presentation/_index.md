---
title: Δημιουργία 3D Εφέ σε Παρουσιάσεις με PHP
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
description: "Εφαρμόστε και αποδώστε 3D εφέ για σχήματα και κείμενο PowerPoint σε PHP με Aspose.Slides. Παραμετροποιήστε την κάμερα, το φωτισμό, το υλικό, την εξώθηση, τις γεμίσεις και το 3D κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides για PHP μέσω Java μπορεί να δημιουργεί, επεξεργάζεται, διατηρεί και αποδίδει μορφοποίηση 3D σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3D όπως περιστροφή, εξωθήρηση, λοξά ακμές, φωτισμό, υλικό, διαβάθμιση ή γέμιση με εικόνα, και 3D κείμενο.

{{% alert color="info" title="Note" %}}
Αυτό το άρθρο αφορά εφέ μορφοποίησης 3D σε σχήματα και κείμενο στο PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία αυτόνομων αρχείων 3D μοντέλου. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3D στην εξαγόμενη 2D έξοδο.
{{% /alert %}}

## **Έννοιες Μορφοποίησης 3D**

Χρησιμοποιήστε τη μέθοδο [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) για να εφαρμόσετε μορφοποίηση 3D σε ένα σχήμα. Η μέθοδος επιστρέφει το [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/), το οποίο ελέγχει τη σκηνή 3D για το συγκεκριμένο σχήμα.

Για κείμενο, χρησιμοποιήστε τη μέθοδο [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). Αυτό εφαρμόζει μορφοποίηση 3D στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Τα πιο σημαντικά μέλη του API είναι:

| Μέλος API | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | Σημείο θέσης, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε χώρο 3D ή ταιριάξτε μια προεπιλογή περιστροφής 3D του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | Προεπιλογή φωτός, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο εμφάνισης των ανταυγών και σκιών στην επιφάνεια 3D. |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) και [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, μαλακή, γυαλιστερή ή μεταλλική. |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) και [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | Πόσο μακριά το σχήμα επεκτείνεται πίσω από την μπροστινή του πλευρά. | Μετατρέψτε ένα επίπεδο σχήμα σε ορατά παχύ 3D αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | Χρώμα των εξωθημένων πλευρών. | Κάντε τη βάθος ορατή ή συντονίστε το χρώμα των πλευρών με τη γέμιση του μπροστινού. |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) και [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | Επιπλέον βάθος 3D που χρησιμοποιείται από τη μορφοποίηση 3D του PowerPoint. | Ρυθμίστε ακριβώς το βάθος για σχήματα ή κείμενο, ειδικά σε συνδυασμό με ρυθμίσεις λοξών ακμών και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) και [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | Αυξημένα ή στρογγυλεμένα άκρα στις εμπρός και πίσω πλευρές. | Προσθέστε ένα μαλακό ή χωνευμένο άκρο αντί για μια αιχμηρή επίπεδη πλευρά. |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) και [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) και [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | Περίγραμμα γύρω από το 3D αντικείμενο. | Δώστε έμφαση στο όριο του αντικειμένου στην παραγόμενη έξοδο. |

## **Δημιουργία 3D Σχήματος**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων προτού να φαίνεται πειστικά 3D:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εξωθήρηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις πλευρές και τις όψεις αναγνώσιμες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξωγήρησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην εμπρόσθια πλευρά του και εφαρμόζει μορφοποίηση 3D. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες και το ύψος εξωθήρησης είναι 100 points. Το παράδειγμα αποδίδει τη διαφάνεια σε εικόνα PNG με διπλάσια προεπιλεγμένη διάσταση και αποθηκεύει την παρουσίαση ως PPTX.

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

Η παραγόμενη εικόνα της διαφάνειας δείχνει το ορθογώνιο ως παχιά 3D μπλοκ:

![Απόδοση μπλε 3D ορθογωνίου με λευκό 3D κείμενο στην εμπρόσθια πλευρά](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3D περιστροφή ρυθμίζεται από το παράθυρο 3-D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Παράθυρο 3-D Rotation του PowerPoint με επισημασμένες τις τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, αποκτήστε πρόσβαση στην κάμερα μέσω του [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera). Αυτό το παράδειγμα δημιουργεί ένα ορθογώνιο, επιλέγει ορθογραφική προοπτική από εμπρός, και θέτει τις περιστροφές X, Y, Z σε 20, 30 και 40 μοίρες, αντίστοιχα. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

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

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2D σχήματος στη διαφάνεια. Αλλάζει το 3D σημείο θέασης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

### **Αντιγραφή Προσανατολισμού Κάμερας από Σχήμα Προτύπου**

Για να ταιριάξετε τον προσανατολισμό ενός σχήματος προτύπου, διαβάστε την προεπιλογή κάμερας του με [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) και τις γωνίες περιστροφής του με [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation). Το παράδειγμα ανοίγει `template.pptx` και αντιγράφει τον προσανατολισμό της κάμερας από το πρώτο σχήμα στην πρώτη διαφάνεια στο δεύτερο σχήμα. Και τα δύο σχήματα έχουν ήδη 3D φωτισμό, και το δεύτερο σχήμα δεν έχει ρητή περιστροφή κάμερας.

Οι γωνίες είναι σε μοίρες. Ο δείκτης `0` είναι γεωγραφικό πλάτος, ο δείκτης `1` είναι γεωγραφικό μήκος, και ο δείκτης `2` είναι επανάληψη. Περάστε τις σε [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) με αυτή τη σειρά. Αν η πηγή επιστρέψει `null`, δεν έχει ρητή περιστροφή, οπότε αφήστε τις γωνίες του δεύτερου σχήματος αμετάβλητες. Μια ρητή περιστροφή του `(0, 0, 0)` επιστρέφει τρία μηδενικά και πρέπει να αντιγραφεί.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Όταν ανοίξετε ξανά το `camera-copy.pptx` στο PowerPoint, το βέλος στα δεξιά έχει την ίδια προεπιλογή κάμερας και περιστροφή με το ορθογώνιο στα αριστερά. Και τα δύο σχήματα χρησιμοποιούν τον ίδιο φωτισμό και βάθος εξωθήρησης.

![Ένα μπλε 3D ορθογώνιο και ένα δεξί βέλος με αντιστοίχιο προσανατολισμό κάμερας, εμφανιζόμενα από πάνω και δεξιά](camera-orientation.png)

## **Προσθήκη Εξωθήρησης και Βάθους**

Η εξωθήρηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από την εμπρόσθια πλευρά. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτή τη ορατή πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Ρυθμιστικά βάθους του PowerPoint συνδεδεμένα με τις ιδιότητες χρώματος εξωθήρησης και ύψους εξωθήρησης](img_02_02.png)

Χρησιμοποιήστε το [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) για να ορίσετε το πάχος και το [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) για να έχετε πρόσβαση στο χρώμα των πλευρών. Αυτό το παράδειγμα δίνει στο ορθογώνιο εξωθήρηση 100 points με μωβ πλευρές και περιστρέφει την κάμερα για να αποκαλύψει το πάχος του. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

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

Η μέθοδος [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) ορίζει το βάθος ενός 3D σχήματος. Η μέθοδος [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) ελέγχει το ύψος του εφέ εξωθήρησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση Διαβάθμισης ή Γέμισης Εικόνας με Εφέ 3D**

Η μορφοποίηση 3D είναι ανεξάρτητη από τη γέμιση του σχήματος. Μπορείτε να εφαρμόσετε συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμιση με εικόνα στην εμπρόσθια πλευρά και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξωθήρησης.

Αυτό το παράδειγμα εφαρμόζει διαβάθμιση από μπλε σε πορτοκαλί στην εμπρόσθια πλευρά και σκούρο πορτοκαλί χρώμα στην εξωθήρηση 150 points. Τα σημεία διαβάθμισης στο 0 και 100 σηματοδοτούν την αρχή και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες. Η διαφάνεια αποδίδεται σε εικόνα PNG με διπλάσια προεπιλεγμένη διάσταση:

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

Η παραγόμενη έξοδος διατηρεί τη διαβάθμιση στην εμπρόσθια πλευρά και αποδίδει την εξωθήρηση ξεχωριστά:

![Παραγόμενο 3D ορθογώνιο με γέμιση διαβάθμισης μπλε-πορτοκαλί και πορτοκαλί εξωθήρηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμιση με εικόνα, προσθέστε την εικόνα στην παρουσίαση και εκχωρήστε την στη γέμιση του σχήματος. Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο με όνομα `image.jpg` στον τρέχοντα φάκελο. Τεντώνει την εικόνα ώστε να καλύψει το ορθογώνιο, εφαρμόζει εξωθήρηση 150 points και ορίζει την περιστροφή της κάμερας σε μοίρες. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

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

Η εικόνα αποδίδεται στην εμπρόσθια πλευρά, ενώ η εξωθήρηση αποδίδεται ως η 3D πλευρική επιφάνεια:

![Παραγόμενο 3D ορθογώνιο με γέμιση φωτογραφίας στην εμπρόσθια πλευρά και πορτοκαλί εξωθήρηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3D σε Κείμενο**

Η μορφοποίηση 3D σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3D κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξωθήρηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με μοτίβο πλέγματος πορτοκαλί-λευκό, εφαρμόζει ένα ανωδικό τόξο και διαμορφώνει ρυθμίσεις 3D μέσω του [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). Το ύψος εξωθήρησης και το βάθος είναι σε points, και η περιστροφή φωτός σε μοίρες. Η γέμιση και το περίγραμμα του σχήματος είναι κρυμμένα ώστε να φαίνεται μόνο το κείμενο. Το παράδειγμα αποδίδει μια εικόνα PNG με διπλάσια προεπιλεγμένη διάσταση της διαφάνειας και αποθηκεύει την παρουσίαση ως PPTX:

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

![Παραγμένο 3D κείμενο με καμπυλωμένο μετασχηματισμό WordArt, γέμιση με πορτοκαλί μοτίβο και σκούρα εξωθήρηση](img_02_05.png)

## **Διατήρηση Κειμένου Επίπεδου σε 3D Σχήμα**

Για να διατηρήσετε το κείμενο αναγνώσιμο ενώ διατηρείτε την 3D εμφάνιση του σχήματος, καλέστε το [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) μέσω του [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat). Όταν η τιμή είναι `true`, το κείμενο παραμένει έξω από τη 3D σκηνή. Όταν είναι `false`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί τον 3D προσανατολισμό.

Αυτή η ρύθμιση δεν αφαιρεί τη μορφοποίηση 3D του σχήματος: η κάμερα, ο φωτισμός, το υλικό και η εξωθήρηση παραμένουν ρυθμισμένα μέσω του [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat). Είναι επίσης διαφορετική από την απλή περιστροφή. Το [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ το [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου μέσα στο πλαίσιο του. Η διατήρηση του κειμένου εκτός της 3D σκηνής δεν επαναφέρει καμία από αυτές τις γωνίες.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το κλωνοποιεί δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια 3D μορφοποίηση· μόνο η ρύθμιση κειμένου διαφέρει: `false` αριστερά και `true` δεξιά. Οι γωνίες της κάμερας είναι σε μοίρες, και το ύψος εξωθήρησης είναι 40 points. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σύγκρισης σε PNG με διπλάσια προεπιλεγμένη διάσταση.

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

Στα αριστερά, το κείμενο ακολουθεί τον 3D προσανατολισμό. Στα δεξιά, παραμένει επίπεδο και πιο ευανάγνωστο. Και τα δύο ορθογώνια διατηρούν το ίδιο ορατό πάχος εξωθήρησης και 3D προσανατολισμό.

![Δύο 3D ορθογώνια δίπλα-δίπλα: το κείμενο ακολουθεί τον 3D προσανατολισμό στα αριστερά και παραμένει επίπεδο στα δεξιά](keep_text_flat.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3D κατά την αποθήκευση σε μορφές PowerPoint όπως το PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερού σχεδίου, η 3D σκηνή rasterizes ή σχεδιάζεται στην έξοδο ως 2D αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/php-java/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/php-java/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/php-java/convert-powerpoint-to-html/), ή δημιουργείτε πλαίσια για [video conversion](/slides/el/php-java/convert-powerpoint-to-video/).

Λάβετε υπόψη τα παρακάτω:

- Οι εξαγόμενες εικόνες και PDF δεν είναι διαδραστικές. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από τον συνδυασμό κάμερας, φωτισμού, υλικού, εξωθήρησης, γέμισης και κλιμάκωσης της διαφάνειας.
- Αν χρειάζεται να επιθεωρήσετε κληρονομημένες ή βασισμένες σε θέμα τιμές μορφοποίησης, διαβάστε τις [αποτελεσματικές ιδιότητες σχήματος](/slides/el/php-java/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3D του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες 3D ρυθμίσεις.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3D παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3D του PowerPoint για σχήματα και κείμενο. Δεν δημιουργεί διαδραστικές 3D σκηνές σε εξαγόμενες εικόνες, PDF ή HTML που o θεατής να μπορεί να περιστρέψει. Σε PPTX, η μορφοποίηση 3D παραμένει επεξεργάσιμη στο PowerPoint όταν η μορφή την υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ 3D μοντέλου και 3D εφέ;**

Ένα 3D μοντέλο είναι ξεχωριστό 3D αντικείμενο που εισάγεται σε μια παρουσίαση. Ένα 3D εφέ είναι μορφοποίηση που εφαρμόζεται σε κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξωθήρηση, λοξά ακμές, φωτισμός και υλικό. Αυτό το άρθρο καλύπτει 3D εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ένα εμφανές 3D σχήμα;**

Στο ελάχιστο, ορίστε μια περιστροφή κάμερας και είτε εξωθήρηση είτε βάθος. Συνήθως, ορίζετε επίσης φωτισμό και υλικό ώστε οι αποδιδόμενες όψεις να έχουν σαφείς ανταύγες και σκιές.

**Μπορώ να εφαρμόσω 3D εφέ σε σχήματα και κείμενο;**

Ναι. Χρησιμοποιήστε το [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) για το σώμα του σχήματος και το [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) για το κείμενο.

**Θα εμφανιστούν τα 3D εφέ όταν εξάγονται σε εικόνες, PDF, HTML ή πλαίσια βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα 3D εφέ όταν παράγει εικόνες διαφανειών, PDF, HTML και πλαίσια που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδοθείσα εμφάνιση, όχι ένα επεξεργάσιμο 3D αντικείμενο.

**Μπορώ να διαβάσω τις τελικές 3D τιμές μετά την κληρονομικότητα και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [αποτελεσματικές ιδιότητες σχήματος](/slides/el/php-java/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, λοξών ακμών και σχετικών 3D τιμών.