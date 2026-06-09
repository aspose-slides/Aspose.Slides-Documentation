---
title: Διαχειριστείτε Πλαίσια Εικόνας σε Παρουσιάσεις χρησιμοποιώντας PHP
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
- ράστερ εικόνα
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
description: "Προσθέστε πλαίσια εικόνας σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για PHP μέσω Java. Βελτιώστε τη ροή εργασίας σας και ενισχύστε το σχεδιασμό των διαφανειών."
---
## **Εισαγωγή**

Ένα πλαίσιο εικόνας είναι ένα σχήμα που περιέχει μια εικόνα—είναι σαν μια εικόνα μέσα σε πλαίσιο.  

Μπορείτε να προσθέσετε μια εικόνα σε μια διαφάνεια μέσω ενός πλαισίου εικόνας. Με αυτόν τον τρόπο, μπορείτε να μορφοποιήσετε την εικόνα μορφοποιώντας το πλαίσιο εικόνας.

{{% alert  title="Συμβουλή" color="primary" %}} 

Η Aspose παρέχει δωρεάν μετατροπείς—[JPEG to PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG to PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν στους χρήστες να δημιουργούν παρουσιάσεις γρήγορα από εικόνες. 

{{% /alert %}} 

## **Δημιουργία Πλαισίου Εικόνας**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).  
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.  
3. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη [ImageCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/) που συσχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για την γεμίσματος του σχήματος.  
4. Καθορίστε το πλάτος και το ύψος της εικόνας.  
5. Δημιουργήστε ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) βάσει του πλάτους και του ύψους της εικόνας μέσω της μεθόδου `addPictureFrame` που εκτίθεται από το αντικείμενο σχήματος που συσχετίζεται με τη διαφάνεια.  
6. Προσθέστε ένα πλαίσιο εικόνας (που περιλαμβάνει την εικόνα) στη διαφάνεια.  
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.  

```php
  # Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Λαμβάνει την πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Δημιουργεί μια παρουσία της κλάσης Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Προσθέτει ένα πλαίσιο εικόνας με το αντίστοιχο ύψος και πλάτος της εικόνας
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

Τα πλαίσια εικόνας σάς επιτρέπουν να δημιουργείτε γρήγορα διαφάνειες παρουσίασης με βάση εικόνες. Όταν συνδυάσετε το πλαίσιο εικόνας με τις επιλογές αποθήκευσης του Aspose.Slides, μπορείτε να διαχειριστείτε τις λειτουργίες εισόδου/εξόδου για να μετατρέψετε εικόνες από τη μια μορφή στην άλλη. Μπορείτε να δείτε αυτές τις σελίδες: μετατροπή [image to JPG](https://products.aspose.com/slides/el/php-java/conversion/image-to-jpg/); μετατροπή [JPG to image](https://products.aspose.com/slides/el/php-java/conversion/jpg-to-image/); μετατροπή [JPG to PNG](https://products.aspose.com/slides/el/php-java/conversion/jpg-to-png/), μετατροπή [PNG to JPG](https://products.aspose.com/slides/el/php-java/conversion/png-to-jpg/); μετατροπή [PNG to SVG](https://products.aspose.com/slides/el/php-java/conversion/png-to-svg/), μετατροπή [SVG to PNG](https://products.aspose.com/slides/el/php-java/conversion/svg-to-png/). 

{{% /alert %}}

## **Δημιουργία Πλαισίου Εικόνας με Σχετική Κλίμακα**

Αλλάζοντας τη σχετική κλιμάκωση μιας εικόνας, μπορείτε να δημιουργήσετε ένα πιο σύνθετο πλαίσιο εικόνας.  

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).  
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.  
3. Προσθέστε μια εικόνα στη συλλογή εικόνων της παρουσίασης.  
4. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη [ImageCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/) που συσχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για το γέμισμα του σχήματος.  
5. Καθορίστε το σχετικό πλάτος και ύψος της εικόνας στο πλαίσιο εικόνας.  
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.  

```php
  # Δημιουργεί μια παρουσία κλάσης Presentation που αντιπροσωπεύει το PPTX
  $pres = new Presentation();
  try {
    # Λαμβάνει την πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Δημιουργεί μια παρουσία της κλάσης Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Προσθέτει πλαίσιο εικόνας με ύψος και πλάτος ισοδύναμα της εικόνας
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Ορισμός σχετικής κλίμακας πλάτους και ύψους
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

Μπορείτε να εξάγετε ράστερ εικόνες από αντικείμενα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) και να τις αποθηκεύσετε σε PNG, JPG και άλλες μορφές. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε μια εικόνα από το έγγραφο «sample.pptx» και να την αποθηκεύσετε σε μορφή PNG.  

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

Όταν μια παρουσίαση περιέχει γραφικά SVG τοποθετημένα μέσα σε σχήματα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/), το Aspose.Slides for PHP via Java σάς επιτρέπει να ανακτήσετε τις αρχικές διανυσματικές εικόνες με πλήρη πιστότητα. Διασχίζοντας τη συλλογή σχημάτων της διαφάνειας, μπορείτε να εντοπίσετε κάθε [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/), να ελέγξετε εάν το υποκείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) περιέχει περιεχόμενο SVG και, στη συνέχεια, να αποθηκεύσετε αυτή την εικόνα στο δίσκο ή σε ροή στη φυσική της μορφή SVG.  

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να εξάγετε μια SVG εικόνα από ένα πλαίσιο εικόνας:  

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

Το Aspose.Slides σάς επιτρέπει να λάβετε το εφέ διαφάνειας που εφαρμόζεται σε μια εικόνα. Αυτός ο κώδικας PHP δείχνει τη λειτουργία:  

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

## **Μορφοποίηση Πλαισίου Εικόνας**

Το Aspose.Slides παρέχει πολλές επιλογές μορφοποίησης που μπορούν να εφαρμοστούν σε ένα πλαίσιο εικόνας. Χρησιμοποιώντας αυτές τις επιλογές, μπορείτε να τροποποιήσετε ένα πλαίσιο εικόνας ώστε να ταιριάζει σε συγκεκριμένες απαιτήσεις.  

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).  
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.  
3. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη [ImageCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/) που συσχετίζεται με το αντικείμενο παρουσίασης και θα χρησιμοποιηθεί για γέμισμα του σχήματος.  
4. Καθορίστε το πλάτος και το ύψος της εικόνας.  
5. Δημιουργήστε ένα `PictureFrame` βάσει του πλάτους και του ύψους της εικόνας μέσω της μεθόδου [addPictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addpictureframe/) που εκτίθεται από το αντικείμενο [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/) που συνδέεται με τη διαφάνεια.  
6. Προσθέστε το πλαίσιο εικόνας (που περιλαμβάνει την εικόνα) στη διαφάνεια.  
7. Ορίστε το χρώμα της γραμμής του πλαισίου εικόνας.  
8. Ορίστε το πάχος της γραμμής του πλαισίου εικόνας.  
9. Περιστρέψτε το πλαίσιο εικόνας δίνοντάς του είτε θετική είτε αρνητική τιμή.  
   * Μια θετική τιμή περιστρέφει την εικόνα δεξιόστροφα.  
   * Μια αρνητική τιμή περιστρέφει την εικόνα αριστερόστροφα.  
10. Προσθέστε το πλαίσιο εικόνας (που περιλαμβάνει την εικόνα) στη διαφάνεια.  
11. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.  

```php
  # Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει το PPTX
  $pres = new Presentation();
  try {
    # Λαμβάνει την πρώτη διαφάνεια
    $sld = $pres->getSlides()->get_Item(0);
    # Δημιουργεί μια παρουσία της κλάσης Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Προσθέτει πλαίσιο εικόνας με ύψος και πλάτος ισοδύναμα της εικόνας
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

Η Aspose ανέπτυξε πρόσφατα ένα [δωρεάν Collage Maker](https://products.aspose.app/slides/el/collage). Αν χρειαστεί ποτέ να [συνδυάσετε JPG/JPEG](https://products.aspose.app/slides/el/collage/jpg) ή PNG εικόνες, ή να [δημιουργήσετε πλέγματα από φωτογραφίες](https://products.aspose.app/slides/el/collage/photo-grid), μπορείτε να χρησιμοποιήσετε αυτή την υπηρεσία. 

{{% /alert %}}

## **Προσθήκη Εικόνας ως Σύνδεσμο**

Για να αποφύγετε μεγάλες διαστάσεις παρουσίασης, μπορείτε να προσθέτετε εικόνες (ή βίντεο) μέσω συνδέσμων αντί να ενσωματώνετε τα αρχεία απευθείας στις παρουσιάσεις. Αυτός ο κώδικας PHP δείχνει πώς να προσθέσετε μια εικόνα και ένα βίντεο σε έναν σύνθετο τύπο:  

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
    # Προσθέτει ένα Πλαίσιο Εικόνας σε μια Διαφάνεια
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Περικόπτει την εικόνα (τιμές ποσοστών)
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

## **Διαγραφή Περιοχών Περικοπής από Πλαίσιο**

Αν θέλετε να διαγράψετε τις περιοχές που έχουν περικοπεί από μια εικόνα που περιλαμβάνεται σε ένα πλαίσιο, μπορείτε να χρησιμοποιήσετε τη μέθοδο [deletePictureCroppedAreas()](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Αυτή η μέθοδος επιστρέφει την περικομμένη εικόνα ή την αρχική εικόνα εάν η περικοπή δεν είναι απαραίτητη.  

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Λαμβάνει το PictureFrame από την πρώτη διαφάνεια
    $picFrame = $slide->getShapes()->get_Item(0);
    # Διαγράφει τις περικομμένες περιοχές της εικόνας του PictureFrame και επιστρέφει την περικομμένη εικόνα
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

Η μέθοδος [deletePictureCroppedAreas()](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) προσθέτει την περικομμένη εικόνα στη συλλογή εικόνων της παρουσίασης. Εάν η εικόνα χρησιμοποιείται μόνο στο επεξεργασμένο [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/), αυτή η ρύθμιση μπορεί να μειώσει το μέγεθος της παρουσίασης. Σε αντίθετη περίπτωση, ο αριθμός των εικόνων στην τελική παρουσίαση θα αυξηθεί.  

Η μέθοδος μετατρέπει αρχεία WMF/EMF σε ράστερ PNG κατά τη διαδικασία περικοπής. 

{{% /alert %}}

## **Συμπίεση Εικόνων**

Μπορείτε να συμπιέσετε μια εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_). Αυτή η μέθοδος συμπιέζει μια εικόνα μειώνοντας το μέγεθός της βάσει του μεγέθους του σχήματος και της καθορισμένης ανάλυσης, με δυνατότητα διαγραφής περιοχών περικοπής.  

Ρυθμίζει το μέγεθος και την ανάλυση της εικόνας παρόμοια με τη λειτουργία **Picture Format -> Compress Pictures -> Resolution** του PowerPoint.  

Τα παρακάτω PHP παραδείγματα δείχνουν πώς να συμπιέσετε μια εικόνα σε μια παρουσίαση ορίζοντας στόχο ανάλυσης και προαιρετικά διαγράφοντας περιοχές περικοπής:  

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Συμπιέζει την εικόνα με στόχο ανάλυση 150 DPI (ανάλυση Web) και αφαιρεί τις περικομμένες περιοχές.
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

Ή χρησιμοποιώντας άμεσα μια προσαρμοσμένη τιμή DPI:  

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Συμπιέζει την εικόνα σε 150 DPI (ανάλυση web), αφαιρώντας τις περικομμένες περιοχές.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="ΣΗΜΕΙΩΣΗ" color="warning" %}} 

Η μέθοδος μετατρέπει την εικόνα σε χαμηλότερη ανάλυση βάσει του μεγέθους του σχήματος και του παρεχόμενου DPI. Οι περικομμένες περιοχές μπορούν επίσης να διαγραφούν για βελτιστοποίηση του μεγέθους του αρχείου.  
Εάν η εικόνα είναι μετααρχείο (WMF/EMF) ή SVG, η συμπίεση δεν θα εφαρμοστεί. Επίσης, η ποιότητα JPEG διατηρείται ή μειώνεται ελαφρώς ανάλογα με την ανάλυση, όπως συμβαίνει στο PowerPoint για υψηλής ανάλυσης JPEG. 

{{% /alert %}}

## **Κλείδωμα Αναλογίας Διαστάσεων**

Εάν θέλετε ένα σχήμα που περιέχει εικόνα να διατηρεί την αναλογία διαστάσεων ακόμα και μετά την αλλαγή των διαστάσεων της εικόνας, μπορείτε να χρησιμοποιήσετε τη μέθοδο [setAspectRatioLocked](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) για να ορίσετε τη ρύθμιση *Lock Aspect Ratio*.  

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
    # ορίζει το σχήμα να διατηρεί την αναλογία διαστάσεων κατά την αλλαγή μεγέθους
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

Χρησιμοποιώντας τις μεθόδους [setStretchOffsetLeft](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) και [setStretchOffsetBottom](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) από την κλάση [PictureFillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/), μπορείτε να ορίσετε ένα ορθογώνιο γεμίσματος.  

Όταν καθορίζεται τάνυση για μια εικόνα, ένα πηγαίο ορθογώνιο κλιμακώνεται ώστε να ταιριάζει στο καθορισμένο ορθογώνιο γεμίσματος. Κάθε άκρο του ορθογωνίου γεμίσματος ορίζεται από ποσοστιαία μετατόπιση από το αντίστοιχο άκρο του περιβλήματος του σχήματος. Μια θετική τιμή καθορίζει εσωτερική μετατόπιση, ενώ μια αρνητική τιμή καθορίζει εξωτερική μετατόπιση.  

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).  
2. Αποκτήστε μια αναφορά σε μια διαφάνεια μέσω του δείκτη της.  
3. Προσθέστε ένα ορθογώνιο `AutoShape`.  
4. Δημιουργήστε μια εικόνα.  
5. Ορίστε τον τύπο γεμίσματος του σχήματος.  
6. Ορίστε τη λειτουργία γεμίσματος εικόνας του σχήματος.  
7. Προσθέστε μια εικόνα για να γεμίσετε το σχήμα.  
8. Καθορίστε τις μετατοπίσεις της εικόνας από το αντίστοιχο άκρο του περιβλήματος του σχήματος.  
9. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.  

```php
  # Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX
  $pres = new Presentation();
  try {
    # Λαμβάνει την πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);
    # Δημιουργεί μια παρουσία της κλάσης ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Προσθέτει ένα AutoShape με τύπο Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Ορίζει τον τύπο γεμίσματος του σχήματος
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Ορίζει τη λειτουργία γεμίσματος εικόνας του σχήματος
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Ορίζει την εικόνα για γέμισμα του σχήματος
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Καθορίζει τις μετατοπίσεις της εικόνας από το αντίστοιχο άκρο του περιοριστικού πλαισίου του σχήματος
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

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να μάθω ποιες μορφές εικόνας υποστηρίζονται για το PictureFrame;**

Το Aspose.Slides υποστηρίζει τόσο ράστερ εικόνες (PNG, JPEG, BMP, GIF κ.λπ.) όσο και διανυσματικές εικόνες (π.χ. SVG) μέσω του αντικειμένου εικόνας που εκχωρείται σε ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/). Η λίστα των υποστηριζόμενων μορφών γενικά επικαλύπτεται με τις δυνατότητες του κινητήρα μετατροπής διαφάνειας και εικόνας.

**Πώς θα επηρεάσει η προσθήκη δεκάδων μεγάλων εικόνων το μέγεθος και την απόδοση του PPTX;**

Η ενσωμάτωση μεγάλων εικόνων αυξάνει το μέγεθος του αρχείου και τη χρήση μνήμης· η σύνδεση εικόνων βοηθά στη μείωση του μεγέθους της παρουσίασης, αλλά απαιτεί τα εξωτερικά αρχεία να παραμένουν προσβάσιμα. Το Aspose.Slides παρέχει τη δυνατότητα προσθήκης εικόνων μέσω συνδέσμου για μείωση του μεγέθους του αρχείου.

**Πώς μπορώ να κλειδώσω ένα αντικείμενο εικόνας από τυχαία μετακίνηση ή αλλαγή μεγέθους;**

Χρησιμοποιήστε τις [κλειδώσεις σχήματος](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/getpictureframelock/) για ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) (π.χ. απενεργοποίηση μετακίνησης ή αλλαγής μεγέθους). Ο μηχανισμός κλειδώματος υποστηρίζεται για διάφορους τύπους σχημάτων, συμπεριλαμβανομένου του [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/).

**Διατηρείται η πιστότητα του διανύσματος SVG όταν εξάγεται μια παρουσίαση σε PDF/εικόνες;**

Το Aspose.Slides επιτρέπει την εξαγωγή ενός SVG από ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) ως το αρχικό διάνυσμα. Κατά την [εξαγωγή σε PDF](/slides/el/php-java/convert-powerpoint-to-pdf/) ή σε [ράστερ μορφές](/slides/el/php-java/convert-powerpoint-to-png/), το αποτέλεσμα μπορεί να ραστεροποιηθεί ανάλογα με τις ρυθμίσεις εξαγωγής· το γεγονός ότι το αρχικό SVG αποθηκεύεται ως διάνυσμα επιβεβαιώνεται από τη συμπεριφορά εξαγωγής.