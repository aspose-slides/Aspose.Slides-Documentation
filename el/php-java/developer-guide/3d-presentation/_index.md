---
title: Δημιουργία 3D εφέ σε παρουσιάσεις με χρήση PHP
linktitle: Παρουσίαση 3D
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
description: "Εφαρμόστε και αποδώστε 3D εφέ για σχήματα και κείμενο PowerPoint σε PHP με το Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3D κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides for PHP μέσω Java μπορεί να δημιουργήσει, να επεξεργαστεί, να διατηρήσει και να αποδώσει μορφοποίηση 3D σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3D όπως περιστροφή, εξώθηση, κλίσεις, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα εικόνας, και κείμενο 3D.

{{% alert color="primary" %}}
Αυτό το άρθρο αφορά τα εφέ μορφοποίησης 3D σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή την επεξεργασία ανεξάρτητων αρχείων μοντέλων 3D. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3D στην εξαγόμενη 2Δ έξοδο.
{{% /alert %}}

## **Έννοιες μορφοποίησης 3D**

Χρησιμοποιήστε την κλάση [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) και τη μέθοδο της [Shape::getThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getThreeDFormat--) για να εφαρμόσετε μορφοποίηση 3D σε ένα σχήμα. Η μέθοδος επιστρέφει το [ThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/), το οποίο ελέγχει τη σκηνή 3D για εκείνο το σχήμα.

Για κείμενο, χρησιμοποιήστε την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/) και τη μέθοδο της [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#getThreeDFormat--) . Αυτό εφαρμόζει μορφοποίηση 3D στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Οι πιο σημαντικές ρυθμίσεις είναι:

| Μέθοδος ή ρύθμιση | Τι ελέγχει | Πότε να τη χρησιμοποιήσετε |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getCamera--) | Οπτική γωνία, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο στον τρισδιάστατο χώρο ή ταιριάξτε με προεπιλογή περιστροφής 3D του PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getLightRig--) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε πώς εμφανίζονται τα φωτεινά σημεία και οι σκιές στην 3D επιφάνεια. |
| [setMaterial](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, μαλακή, γυαλιστερή ή μεταλλική. |
| [setExtrusionHeight](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Πόσο μακριά το σχήμα επεκτείνεται προς τα πίσω από το μπροστινό του πρόσωπο. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατό παχύ 3D αντικείμενο. |
| [getExtrusionColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με το γέμισμα του προσώπου. |
| [setDepth](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#setDepth-double-) | Επιπλέον 3D βάθος που χρησιμοποιείται από τη μορφοποίηση 3D του PowerPoint. | Ρυθμίστε το βάθος για σχήματα ή κείμενο, ιδίως μαζί με ρυθμίσεις κλίσης και υλικού. |
| [getBevelTop](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getBevelTop--) και [getBevelBottom](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getBevelBottom--) | Ανασηκωμένες ή στρογγυλεμένες άκρες στα μπροστινά και πίσω πρόσωπα. | Προσθέστε μια μαλακότερη ή διαμορφωμένη άκρη αντί για μια αιχμηρή επίπεδη επιφάνεια. |
| [getContourColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getContourColor--) και [setContourWidth](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Περίγραμμα γύρω από το 3D αντικείμενο. | Τονίστε το όριο του αντικειμένου στο αποδοθέν αποτέλεσμα. |

## **Δημιουργία 3D σχήματος**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν εμφανιστεί πειστικά 3D:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις πλευρές και τις όψεις ευανάγνωστες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει πώς αποδίδεται το φως.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα παραλληλόγραμμο, προσθέτει κείμενο στο μπροστινό του πρόσωπο, εφαρμόζει μορφοποίηση 3D, αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σε εικόνα PNG.

```php
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

Η αποδοθείσα εικόνα της διαφάνειας δείχνει το παραλληλόγραμμο ως ένα παχύ 3D μπλοκ:

![Αποδοθείσα μπλε 3D παραλληλόγραμμο με λευκό 3D κείμενο στο μπροστινό πρόσωπο](img_01_01.png)

## **Περιστροφή σχήματος με την κάμερα**

Στο PowerPoint, η περιστροφή 3D ρυθμίζεται από το παράθυρο 3-D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Παράθυρο 3-D Rotation του PowerPoint με επισημασμένες τις τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, ορίστε τον τύπο κάμερας και τη περιστροφή μέσω του [ThreeDFormat::getCamera](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getCamera--):

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2Δ σχήματος στη διαφάνεια. Αλλάζει την 3D οπτική γωνία που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη εξώθησης και βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από το μπροστινό πρόσωπο. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint που αντιστοιχούν στο χρώμα εξώθησης και στις ιδιότητες ύψους εξώθησης](img_02_02.png)

Ορίστε το [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) για το πάχος και το [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#getExtrusionColor--) για το χρώμα των πλευρών:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

Χρησιμοποιήστε το [ThreeDFormat::setDepth](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/#setDepth-double-) όταν χρειάζεται να εργαστείτε άμεσα με την τιμή βάθους του PowerPoint ή να συνδυάσετε το βάθος με κλίση, υλικό και εφέ κειμένου. Σε πολλές περιπτώσεις σχήματος, το `setExtrusionHeight` είναι η πιο σαφής ρύθμιση επειδή εκφράζει άμεσα την ορατή εξώθηση.

## **Χρήση γεμίσματος διαβάθμισης ή εικόνας με εφέ 3D**

Η μορφοποίηση 3D είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε ένα στερεό χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στο μπροστινό πρόσωπο και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτός, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει ένα γέμισμα διαβάθμισης στο σχήμα και ένα πιο σκούρο χρώμα εξώθησης στις πλευρές:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

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

![Αποδοθείσα 3D παραλληλόγραμμο με γέμισμα διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και αντιστοιχίστε την στο γέμισμα του σχήματος:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

![Αποδοθείσα 3D παραλληλόγραμμο με γέμισμα φωτογραφίας στο μπροστινό πρόσωπο και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή μορφοποίησης 3D σε κείμενο**

Η μορφοποίηση 3D του σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3D του κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ παρόμοια με WordArt, όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με γέμισμα μοτίβου, εφαρμόζει μετασχηματισμό WordArt και ρυθμίζει τις ρυθμίσεις 3D στο [TextFrameFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/):

```php
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
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
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

![Αποδοθείσες 3D κείμενο με καμπύλο μετασχηματισμό WordArt, πορτοκαλί γέμισμα μοτίβου και σκούρα εξώθηση](img_02_05.png)

## **Συμπεριφορά εξαγωγής και απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3D κατά την αποθήκευση σε μορφές PowerPoint όπως το PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερής διάταξης, η σκηνή 3D rasterizes ή σχεδιάζεται στο αποτέλεσμα ως 2Δ αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/php-java/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/php-java/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/php-java/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [μετατροπή βίντεο](/slides/el/php-java/convert-powerpoint-to-video/).

Λάβετε υπόψη τα ακόλουθα σημεία:

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό της κάμερας, του φωτιστικού, του υλικού, της εξώθησης, του γεμίσματος και της κλιμάκωσης της διαφάνειας.
- Εάν χρειάζεται να εξετάσετε κληρονομημένες ή βασισμένες σε θέμα τιμές μορφοποίησης, διαβάστε τις [ιδιότητες αποτελεσματικού σχήματος](/slides/el/php-java/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3D του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμο 3D.

## **FAQ**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3D παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3D του PowerPoint για σχήματα και κείμενο. Δεν μετατρέπει τις εξαγόμενες εικόνες, PDF ή σελίδες HTML σε διαδραστικές σκηνές 3D που ο θεατής μπορεί να περιστρέψει. Στο PPTX, η μορφοποίηση 3D παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή την υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ ενός 3D μοντέλου και ενός 3D εφέ;**

Ένα 3D μοντέλο είναι ένα ξεχωριστό 3D αντικείμενο που εισάγεται στην παρουσίαση. Ένα 3D εφέ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, κλίση, φωτισμό και υλικό. Αυτό το άρθρο καλύπτει εφέ 3D.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3D σχήμα;**

Ως ελάχιστο, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτισμό και υλικό ώστε οι αποδοθείσες όψεις να έχουν καθαρά highlights και σκιές.

**Μπορώ να εφαρμόσω εφέ 3D τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [Shape::getThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#getThreeDFormat--) για το σώμα του σχήματος και το [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/textframeformat/#getThreeDFormat--) για το κείμενο.

**Θα εμφανιστούν τα εφέ 3D όταν εξάγονται σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει εφέ 3D όταν παράγει εικόνες διαφανειών, έξοδο PDF, έξοδο HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδοθείσα εμφάνιση, όχι ένα επεξεργάσιμο 3D αντικείμενο.

**Μπορώ να διαβάσω τις τελικές τιμές 3D μετά την κληρονομιά και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα API αποτελεσματικής μορφοποίησης που περιγράφονται στις [Effective Shape Properties](/slides/el/php-java/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, κλίσης και σχετικών 3D τιμών.