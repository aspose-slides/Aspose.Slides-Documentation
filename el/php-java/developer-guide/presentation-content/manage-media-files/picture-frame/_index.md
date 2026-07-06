---
title: Διαχειριστείτε τα Πλαίσια Εικόνας σε Παρουσιάσεις με PHP
linktitle: Πλαίσιο Εικόνας
type: docs
weight: 10
url: /el/php-java/picture-frame/
keywords:
- πλαίσιο εικόνας
- προσθήκη πλαισίου εικόνας
- δημιουργία πλαισίου εικόνας
- προσθήκη εικόνας
- δημιουργία εικόνας
- εξαγωγή εικόνας
- ραστέρ εικόνα
- διανυσματική εικόνα
- περικοπή εικόνας
- περιοχή περικοπής
- ιδιότητα StretchOff
- μορφοποίηση πλαισίου εικόνας
- ιδιότητες πλαισίου εικόνας
- σχετική κλίμακα
- εφέ εικόνας
- αναλογία διαστάσεων
- διαφάνεια εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Προσθέστε πλαίσια εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για PHP μέσω Java. Απλοποιήστε τη ροή εργασίας σας και βελτιώστε το σχεδιασμό των διαφανειών."
---
## **Εισαγωγή**

Ένα πλαίσιο εικόνας είναι ένα σχήμα που περιέχει μια εικόνα—είναι σαν μια φωτογραφία μέσα σε ένα πλαίσιο. 

Μπορείτε να προσθέσετε μια εικόνα σε μια διαφάνεια μέσω ενός πλαίσιου εικόνας. Με αυτόν τον τρόπο, μορφοποιείτε την εικόνα μορφοποιώντας το πλαίσιο εικόνας.

{{% alert  title="Συμβουλή" color="primary" %}} 

Η Aspose παρέχει δωρεάν μετατροπείς—[JPEG to PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG to PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν τη γρήγορη δημιουργία παρουσιάσεων από εικόνες. 

{{% /alert %}} 

## **Δημιουργία Πλαισίου Εικόνας**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη [ImageCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/) που σχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για τη γέμιση του σχήματος.
4. Καθορίστε το πλάτος και το ύψος της εικόνας.
5. Δημιουργήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) με βάση το πλάτος και το ύψος της εικόνας μέσω της μεθόδου `addPictureFrame` που εκτίθεται από το αντικείμενο σχήματος που σχετίζεται με τη διαφάνεια.
6. Προσθέστε ένα πλαίσιο εικόνας (που περιλαμβάνει την εικόνα) στη διαφάνεια.
7. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας:

```php
  # Δημιουργεί την κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
  $pres = new Presentation();
  try {
    # Λαμβάνει την πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Δημιουργεί την κλάση Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Προσθέτει ένα πλαίσιο εικόνας με το ισοδύναμο ύψος και πλάτος της εικόνας
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Γράφει το αρχείο PPTX στο δίσκο
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

Τα πλαίσια εικόνας σας επιτρέπουν να δημιουργείτε γρήγορα διαφάνειες παρουσίασης βασισμένες σε εικόνες. Όταν συνδυάζετε το πλαίσιο εικόνας με τις επιλογές αποθήκευσης του Aspose.Slides, μπορείτε να χειριστείτε τις λειτουργίες εισόδου/εξόδου για να μετατρέψετε εικόνες από τη μια μορφή στην άλλη. Ίσως θέλετε να δείτε αυτές τις σελίδες: μετατροπή [image to JPG](https://products.aspose.com/slides/el/php-java/conversion/image-to-jpg/); μετατροπή [JPG to image](https://products.aspose.com/slides/el/php-java/conversion/jpg-to-image/); μετατροπή [JPG to PNG](https://products.aspose.com/slides/el/php-java/conversion/jpg-to-png/), μετατροπή [PNG to JPG](https://products.aspose.com/slides/el/php-java/conversion/png-to-jpg/); μετατροπή [PNG to SVG](https://products.aspose.com/slides/el/php-java/conversion/png-to-svg/), μετατροπή [SVG to PNG](https://products.aspose.com/slides/el/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Δημιουργία Πλαισίου Εικόνας με Σχετική Κλίμακα**

Αλλάζοντας τη σχετική κλιμάκωση μιας εικόνας, μπορείτε να δημιουργήσετε ένα πιο σύνθετο πλαίσιο εικόνας. 

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε μια εικόνα στη συλλογή εικόνων της παρουσίασης.
4. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη [ImageCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/) που σχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για τη γέμιση του σχήματος.
5. Καθορίστε το σχετικό πλάτος και ύψος της εικόνας στο πλαίσιο εικόνας.
6. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα πλαίσιο εικόνας με σχετική κλίμακα:

```php
  # Δημιουργεί την κλάση Presentation που αντιπροσωπεύει το PPTX
  $pres = new Presentation();
  try {
    # Λαμβάνει την πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Δημιουργεί την κλάση Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Προσθέτει Πλαίσιο Εικόνας με ύψος και πλάτος ίσα με την Εικόνα
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Ορίζει σχετική κλίμακα πλάτους και ύψους
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Γράφει το αρχείο PPTX στο δίσκο
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Εξαγωγή Ράστερ Εικόνων από Πλαίσια Εικόνας**

Μπορείτε να εξάγετε ραστές εικόνες από αντικείμενα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) και να τις αποθηκεύσετε σε PNG, JPG και άλλες μορφές. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε μια εικόνα από το έγγραφο "sample.pptx" και να την αποθηκεύσετε σε μορφή PNG.

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **Εξαγωγή SVG Εικόνων από Πλαίσια Εικόνας**

Όταν μια παρουσίαση περιέχει γραφικά SVG τοποθετημένα μέσα σε σχήματα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/), το Aspose.Slides για PHP μέσω Java σάς επιτρέπει να ανακτήσετε τις αρχικές διανυσματικές εικόνες με πλήρη ακεραιότητα. Διασχίζοντας τη συλλογή σχημάτων της διαφάνειας, μπορείτε να εντοπίσετε κάθε [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/), να ελέγξετε αν το υποκείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) περιέχει περιεχόμενο SVG, και στη συνέχεια να αποθηκεύσετε αυτή την εικόνα σε δίσκο ή ροή στη φυσική της μορφή SVG.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε μια εικόνα SVG από ένα πλαίσιο εικόνας:

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Λήψη Διαφάνειας Εικόνας**

Το Aspose.Slides σας επιτρέπει να λάβετε το εφέ διαφάνειας που εφαρμόζεται σε μια εικόνα. Αυτός ο κώδικας PHP δείχνει τη λειτουργία:

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **Λήψη Φωτεινότητας και Αντίθεσης Εικόνας**

Το Aspose.Slides σας επιτρέπει να λάβετε τις ρυθμίσεις φωτεινότητας και αντίθεσης που εφαρμόζονται σε μια εικόνα. Η κλάση [Luminance](https://reference.aspose.com/slides/el/php-java/aspose.slides/luminance/) αντιπροσωπεύει αυτό το εφέ μετασχηματισμού εικόνας.

Αυτός ο κώδικας PHP δείχνει πώς να λάβετε τις ρυθμίσεις φωτεινότητας και αντίθεσης από ένα πλαίσιο εικόνας:

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **Μορφοποίηση Πλαισίου Εικόνας**

Το Aspose.Slides παρέχει πολλές επιλογές μορφοποίησης που μπορούν να εφαρμοστούν σε ένα πλαίσιο εικόνας. Χρησιμοποιώντας αυτές τις επιλογές, μπορείτε να τροποποιήσετε ένα πλαίσιο εικόνας ώστε να ταιριάζει με συγκεκριμένες απαιτήσεις.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της. 
3. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη [ImageCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/) που σχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για τη γέμιση του σχήματος.
4. Καθορίστε το πλάτος και το ύψος της εικόνας.
5. Δημιουργήστε ένα `PictureFrame` με βάση το πλάτος και το ύψος της εικόνας μέσω της μεθόδου [addPictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addpictureframe/) που εκτίθεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/) που σχετίζεται με τη συγκεκριμένη διαφάνεια.
6. Προσθέστε το πλαίσιο εικόνας (που περιλαμβάνει την εικόνα) στη διαφάνεια.
7. Ορίστε το χρώμα γραμμής του πλαισίου εικόνας.
8. Ορίστε το πλάτος γραμμής του πλαισίου εικόνας.
9. Περιστρέψτε το πλαίσιο εικόνας δίνοντάς του είτε θετική είτε αρνητική τιμή.
   * Μια θετική τιμή περιστρέφει την εικόνα δεξιόστροφα. 
   * Μια αρνητική τιμή περιστρέφει την εικόνα αριστερόστροφα.
10. Προσθέστε το πλαίσιο εικόνας (που περιλαμβάνει την εικόνα) στη διαφάνεια.
11. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει τη διαδικασία μορφοποίησης πλαισίου εικόνας:

```php
  # Δημιουργεί την κλάση Presentation που αντιπροσωπεύει το PPTX
  $pres = new Presentation();
  try {
    # Λαμβάνει την πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Δημιουργεί την κλάση Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Προσθέτει Πλαίσιο Εικόνας με ύψος και πλάτος ίσα με την Εικόνα
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Εφαρμόζει κάποια μορφοποίηση στο PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Γράφει το αρχείο PPTX στο δίσκο
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Συμβουλή" color="primary" %}}

Η Aspose ανέπτυξε πρόσφατα ένα [free Collage Maker](https://products.aspose.app/slides/el/collage). Αν χρειαστεί ποτέ να [merge JPG/JPEG](https://products.aspose.app/slides/el/collage/jpg) ή PNG εικόνες, [create grids from photos](https://products.aspose.app/slides/el/collage/photo-grid), μπορείτε να χρησιμοποιήσετε αυτή την υπηρεσία. 

{{% /alert %}}

## **Προσθήκη Εικόνας ως Σύνδεσμος**

Για να αποφύγετε μεγάλου μεγέθους παρουσιάσεις, μπορείτε να προσθέτετε εικόνες (ή βίντεο) μέσω συνδέσμων αντί να ενσωματώνετε τα αρχεία άμεσα στις παρουσιάσεις. Αυτός ο κώδικας PHP δείχνει πώς να προσθέσετε μια εικόνα και βίντεο σε έναν placeholder:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Περικοπή Εικόνων**

Αυτός ο κώδικας PHP δείχνει πώς να περικόψετε μια υπάρχουσα εικόνα σε μια διαφάνεια:

```php
  $pres = new Presentation();
  # Δημιουργεί νέο αντικείμενο εικόνας
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Προσθέτει Πλαίσιο Εικόνας σε μια Διαφάνεια
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Κόβει την εικόνα (τιμές σε ποσοστά)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Αποθηκεύει το αποτέλεσμα
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Διαγραφή Περιοχών Περικοπής Εικόνας**

Αν θέλετε να διαγράψετε τις περιοχές περικοπής μιας εικόνας που βρίσκεται σε ένα πλαίσιο, μπορείτε να χρησιμοποιήσετε τη μέθοδο [deletePictureCroppedAreas()](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Αυτή η μέθοδος επιστρέφει την περικομμένη εικόνα ή την αρχική εικόνα αν η περικοπή δεν είναι απαραίτητη.

Αυτός ο κώδικας PHP δείχνει τη λειτουργία:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Λαμβάνει το PictureFrame από την πρώτη διαφάνεια
    $picFrame = $slide->getShapes()->get_Item(0);
    # Διαγράφει περιοχές περικοπής της εικόνας του PictureFrame και επιστρέφει την περικομμένη εικόνα
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Αποθηκεύει το αποτέλεσμα
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Η μέθοδος [deletePictureCroppedAreas()](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) προσθέτει την περικομμένη εικόνα στη συλλογή εικόνων της παρουσίασης. Αν η εικόνα χρησιμοποιείται μόνο στο επεξεργασμένο [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/), αυτή η ρύθμιση μπορεί να μειώσει το μέγεθος της παρουσίασης. Διαφορετικά, ο αριθμός των εικόνων στην τελική παρουσίαση θα αυξηθεί.

Η μέθοδος αυτή μετατρέπει αρχεία WMF/EMF σε ραστερ PNG εικόνα κατά τη λειτουργία περικοπής. 

{{% /alert %}}

## **Συμπίεση Εικόνων**

Μπορείτε να συμπιέσετε μια εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_). Αυτή η μέθοδος συμπιέζει μια εικόνα μειώνοντας το μέγεθός της βάσει του μεγέθους του σχήματος και της καθορισμένης ανάλυσης, με την επιλογή διαγραφής των περιοχών περικοπής.

Προσαρμόζει το μέγεθος και την ανάλυση της εικόνας παρόμοια με τη λειτουργία **Picture Format -> Compress Pictures -> Resolution** του PowerPoint.

Τα παρακάτω παραδείγματα PHP δείχνουν πώς να συμπιέσετε μια εικόνα σε μια παρουσίαση ορίζοντας την στοχευόμενη ανάλυση και προαιρετικά αφαιρώντας περιοχές περικοπής:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Συμπιέζει την εικόνα με στόχο ανάλυση 150 DPI (ανάλυση web) και αφαιρεί τις περιοχές περικοπής.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Ελέγχει το αποτέλεσμα της συμπίεσης.
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ή χρησιμοποιώντας απευθείας μια προσαρμοσμένη τιμή DPI:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Συμπιέζει την εικόνα σε 150 DPI (ανάλυση web), αφαιρώντας τις περιοχές περικοπής.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Η μέθοδος μετατρέπει την εικόνα σε χαμηλότερη ανάλυση βάσει του μεγέθους του σχήματος και του παρεχόμενου DPI. Οι περιοχές περικοπής μπορούν επίσης να διαγραφούν για βελτιστοποίηση του μεγέθους του αρχείου.  
Αν η εικόνα είναι μετααρχείο (WMF/EMF) ή SVG, η συμπίεση δεν θα εφαρμοστεί. Επιπλέον, η ποιότητα JPEG διατηρείται ή μειώνεται ελαφρώς ανάλογα με την ανάλυση, όπως συμβαίνει στο PowerPoint με εικόνες υψηλής ανάλυσης.

{{% /alert %}}

## **Κλείδωμα Αναλογίας Διαστάσεων**

Αν θέλετε ένα σχήμα που περιέχει μια εικόνα να διατηρεί την αναλογία διαστάσεων ακόμα και μετά την αλλαγή των διαστάσεων της εικόνας, μπορείτε να χρησιμοποιήσετε τη μέθοδο [setAspectRatioLocked](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) για να ορίσετε τη ρύθμιση *Lock Aspect Ratio*.

Αυτός ο κώδικας PHP δείχνει πώς να κλειδώσετε την αναλογία διαστάσεων ενός σχήματος:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # ορίστε το σχήμα ώστε να διατηρεί την αναλογία διαστάσεων κατά την αλλαγή μεγέθους
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Αυτή η ρύθμιση *Lock Aspect Ratio* διατηρεί μόνο την αναλογία διαστάσεων του σχήματος και όχι της εικόνας που περιέχει.

{{% /alert %}}

## **Χρήση της Ιδιότητας StretchOff**

Χρησιμοποιώντας τις μεθόδους [setStretchOffsetLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) και [setStretchOffsetBottom](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/), μπορείτε να ορίσετε ένα ορθογώνιο γέμισης.

Όταν καθορίζεται τέντωμα για μια εικόνα, ένα πηγαίο ορθογώνιο κλιμακώνεται ώστε να ταιριάζει με το καθορισμένο ορθογώνιο γέμισης. Κάθε πλευρά του ορθογωνίου γέμισης ορίζεται από ένα ποσοστό μετατόπισης από την αντίστοιχη πλευρά του περιγράμματος του σχήματος. Ένα θετικό ποσοστό ορίζει εσοχή, ενώ ένα αρνητικό ποσοστό ορίζει έξοδο.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Αποκτήστε την αναφορά μιας διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο `AutoShape`. 
4. Δημιουργήστε μια εικόνα.
5. Ορίστε τον τύπο γέμισης του σχήματος.
6. Ορίστε τη λειτουργία γέμισης εικόνας του σχήματος.
7. Προσθέστε ένα σύνολο εικόνων για γέμισμα του σχήματος.
8. Καθορίστε τις μετατοπίσεις εικόνας από την αντίστοιχη πλευρά του περιγράμματος του σχήματος
9. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει μια διαδικασία όπου χρησιμοποιείται η ιδιότητα StretchOff:

```php
  # Δημιουργεί την κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
  $pres = new Presentation();
  try {
    # Λαμβάνει την πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Δημιουργεί την κλάση ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Προσθέτει AutoShape ορισμένο σε Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Ορίζει τον τύπο γέμισης του σχήματος
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Ορίζει τη λειτουργία γέμισης εικόνας του σχήματος
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Ορίζει την εικόνα για να γεμίσει το σχήμα
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Καθορίζει τις μετατοπίσεις εικόνας από την αντίστοιχη πλευρά του περιγράμματος του σχήματος
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Γράφει το αρχείο PPTX στο δίσκο
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να μάθω ποιες μορφές εικόνας υποστηρίζονται για το PictureFrame;**

Το Aspose.Slides υποστηρίζει τόσο ραστές εικόνες (PNG, JPEG, BMP, GIF κ.ά.) όσο και διανυσματικές εικόνες (π.χ., SVG) μέσω του αντικειμένου εικόνας που ανατίθεται σε ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/). Η λίστα των υποστηριζόμενων μορφών γενικά συμπίπτει με τις δυνατότητες του κινητήρα μετατροπής διαφάνειας και εικόνας.

**Πώς θα επηρεάσει η προσθήκη δεκάδων μεγάλων εικόνων το μέγεθος και την απόδοση του PPTX;**

Η ενσωμάτωση μεγάλων εικόνων αυξάνει το μέγεθος του αρχείου και τη χρήση μνήμης· η σύνδεση εικόνων βοηθάει στη μείωση του μεγέθους της παρουσίασης, αλλά απαιτεί τα εξωτερικά αρχεία να παραμένουν προσβάσιμα. Το Aspose.Slides παρέχει τη δυνατότητα προσθήκης εικόνων μέσω συνδέσμου για μείωση του μεγέθους του αρχείου.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο εικόνας ώστε να μην μετακινείται/αναπροσαρμόζεται τυχαία;**

Χρησιμοποιήστε τα [shape locks](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/getpictureframelock/) για ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) (π.χ., απενεργοποίηση μετακίνησης ή αλλαγής μεγέθους). Ο μηχανισμός κλειδώματος υποστηρίζεται για διάφορους τύπους σχημάτων, συμπεριλαμβανομένου του [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/).

**Διατηρείται η ακεραιότητα του διανύσματος SVG κατά την εξαγωγή μιας παρουσίασης σε PDF/εικόνες;**

Το Aspose.Slides επιτρέπει την εξαγωγή ενός SVG από ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) ως το αρχικό διάνυσμα. Όταν γίνεται [εξαγωγή σε PDF](/slides/el/php-java/convert-powerpoint-to-pdf/) ή [σε ραστές μορφές](/slides/el/php-java/convert-powerpoint-to-png/), το αποτέλεσμα μπορεί να γίνει ραστερο ανάλογα με τις ρυθμίσεις εξαγωγής· το γεγονός ότι το αρχικό SVG αποθηκεύεται ως διάνυσμα επιβεβαιώνεται από τη συμπεριφορά εξαγωγής.