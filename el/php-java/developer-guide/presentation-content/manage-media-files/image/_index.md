---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις με χρήση PHP
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/php-java/image/
keywords:
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- προσθήκη bitmap
- αντικατάσταση εικόνας
- αντικατάσταση φωτογραφίας
- από το διαδίκτυο
- φόντο
- προσθήκη PNG
- προσθήκη JPG
- προσθήκη SVG
- προσθήκη EMF
- προσθήκη WMF
- προσθήκη TIFF
- PowerPoint
- OpenDocument
- παρουσίαση
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Βελτιώστε τη διαχείριση εικόνων σε PowerPoint και OpenDocument με το Aspose.Slides για PHP μέσω Java, βελτιώνοντας την απόδοση και αυτοματοποιώντας τη ροή εργασίας σας."
---
## **Εισαγωγή**

Οι εικόνες κάνουν τις παρουσιάσεις πιο ελκυστικές και ενδιαφέρουσες. Στο Microsoft PowerPoint, μπορείτε να εισαγάγετε εικόνες από αρχείο, το διαδίκτυο ή άλλες τοποθεσίες στις διαφάνειες. Αντίστοιχα, το Aspose.Slides σας επιτρέπει να προσθέσετε εικόνες στις διαφάνειες των παρουσιάσεών σας μέσω διαφορετικών διαδικασιών. 

{{% alert  title="Tip" color="primary" %}} 

Το Aspose παρέχει δωρεάν μετατροπείς —[JPEG σε PowerPoint](https://products.aspose.app/slides/el/import/jpg-to-ppt) και [PNG σε PowerPoint](https://products.aspose.app/slides/el/import/png-to-ppt)—που επιτρέπουν στους χρήστες να δημιουργούν παρουσιάσεις γρήγορα από εικόνες. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Αν θέλετε να προσθέσετε μια εικόνα ως αντικείμενο πλαισίου —ιδιαίτερα αν σκοπεύετε να χρησιμοποιήσετε τυπικές επιλογές μορφοποίησης για να αλλάξετε το μέγεθός της, να προσθέσετε εφέ κλπ—δείτε τη σελίδα [Picture Frame](/slides/el/php-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Μπορείτε να χειριστείτε λειτουργίες εισόδου/εξόδου που αφορούν εικόνες και παρουσιάσεις PowerPoint για να μετατρέψετε μια εικόνα από τη μια μορφή στην άλλη. Δείτε αυτές τις σελίδες: μετατροπή [εικόνα σε JPG](https://products.aspose.com/slides/el/php-java/conversion/image-to-jpg/); μετατροπή [JPG σε εικόνα](https://products.aspose.com/slides/el/php-java/conversion/jpg-to-image/); μετατροπή [JPG σε PNG](https://products.aspose.com/slides/el/php-java/conversion/jpg-to-png/), μετατροπή [PNG σε JPG](https://products.aspose.com/slides/el/php-java/conversion/png-to-jpg/); μετατροπή [PNG σε SVG](https://products.aspose.com/slides/el/php-java/conversion/png-to-svg/), μετατροπή [SVG σε PNG](https://products.aspose.com/slides/el/php-java/conversion/svg-to-png/).

{{% /alert %}}

Το Aspose.Slides υποστηρίζει λειτουργίες με εικόνες σε αυτές τις δημοφιλείς μορφές: JPEG, PNG, GIF και άλλα. 

## **Προσθήκη Εικόνων που Αποθηκεύονται Τοπικά σε Διαφάνειες**

Μπορείτε να προσθέσετε μία ή πολλές εικόνες από τον υπολογιστή σας σε μια διαφάνεια σε μια παρουσίαση. Αυτό το παράδειγμα κώδικα σας δείχνει πώς να προσθέσετε μια εικόνα σε μια διαφάνεια:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Προσθήκη Εικών από τον Ιστό σε Διαφάνειες**

Αν η εικόνα που θέλετε να προσθέσετε σε μια διαφάνεια δεν είναι διαθέσιμη στον υπολογιστή σας, μπορείτε να προσθέσετε την εικόνα απευθείας από το διαδίκτυο.

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να προσθέσετε μια εικόνα από το διαδίκτυο σε μια διαφάνεια:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Προσθήκη Εικόνων σε Master Slides**

Ένα master slide είναι η κορυφαία διαφάνεια που αποθηκεύει και ελέγχει πληροφορίες (θέμα, διάταξη κ.λπ.) για όλες τις διαφάνειες που το ακολουθούν. Έτσι, όταν προσθέτετε μια εικόνα σε ένα master slide, η εικόνα αυτή εμφανίζεται σε κάθε διαφάνεια που βασίζεται σε αυτό το master slide.

Αυτό το παράδειγμα κώδικα Java σας δείχνει πώς να προσθέσετε μια εικόνα σε ένα master slide:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Προσθήκη Εικόνων ως Φόντο Διαφάνειας**

Μπορείτε να αποφασίσετε να χρησιμοποιήσετε μια εικόνα ως φόντο για μια συγκεκριμένη διαφάνεια ή για πολλές διαφάνειες. Σε αυτήν την περίπτωση, δείτε πώς να [Set an Image as a Slide Background](/slides/el/php-java/presentation-background/#set-an-image-as-a-slide-background).

## **Προσθήκη SVG σε Παρουσιάσεις**

Μπορείτε να προσθέσετε ή να εισάγετε οποιαδήποτε εικόνα σε μια παρουσίαση χρησιμοποιώντας τη μέθοδο [addPictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addpictureframe/) που ανήκει στην κλάση [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/).

Για να δημιουργήσετε ένα αντικείμενο εικόνας βασισμένο σε SVG εικόνα, μπορείτε να το κάνετε με τον εξής τρόπο:

1. Δημιουργήστε αντικείμενο SvgImage για να το εισάγετε στο ImageShapeCollection
2. Δημιουργήστε αντικείμενο PPImage από το ISvgImage
3. Δημιουργήστε αντικείμενο PictureFrame χρησιμοποιώντας την κλάση PPImage

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να υλοποιήσετε τα παραπάνω βήματα για να προσθέσετε μια SVG εικόνα σε μια παρουσίαση:
```php
  # Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο PPTX
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Μετατροπή SVG σε Σύνολο Σχημάτων**

Η μετατροπή SVG σε σύνολο σχημάτων του Aspose.Slides είναι παρόμοια με τη λειτουργικότητα του PowerPoint που χρησιμοποιείται για εργασία με εικόνες SVG:

![PowerPoint Popup Menu](img_01_01.png)

Η λειτουργικότητα παρέχεται από μία από τις υπερφορτωμένες εκδοχές της μεθόδου [addGroupShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/addgroupshape/) της κλάσης [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/) που δέχεται ένα αντικείμενο [SvgImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/svgimage/) ως πρώτο όρισμα.

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να χρησιμοποιήσετε τη περιγραφόμενη μέθοδο για να μετατρέψετε ένα αρχείο SVG σε σύνολο σχημάτων:

```php
  # Δημιουργία νέας παρουσίασης
  $presentation = new Presentation();
  try {
    # Ανάγνωση περιεχομένου αρχείου SVG
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # Δημιουργία αντικειμένου SvgImage
    $svgImage = new SvgImage($svgContent);
    # Λήψη μεγέθους διαφάνειας
    $slideSize = $presentation->getSlideSize()->getSize();
    # Μετατροπή εικόνας SVG σε ομάδα σχημάτων κλιμακώνοντάς την στο μέγεθος της διαφάνειας
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Αποθήκευση παρουσίασης σε μορφή PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Προσθήκη Εικόνων ως EMF σε Διαφάνειες**

Το Aspose.Slides for PHP μέσω Java σας επιτρέπει να δημιουργείτε εικόνες EMF από φύλλα Excel και να προσθέτετε τις εικόνες ως EMF σε διαφάνειες με το Aspose.Cells. 

Αυτό το παράδειγμα κώδικα σας δείχνει πώς να εκτελέσετε την περιγραφόμενη εργασία:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Αποθήκευση του βιβλίου εργασίας σε ροή
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Αντικατάσταση Εικόνων στη Συλλογή Εικόνων**

Το Aspose.Slides σας επιτρέπει να αντικαθιστάτε εικόνες που είναι αποθηκευμένες στη συλλογή εικόνων μιας παρουσίασης (συμπεριλαμβανομένων αυτών που χρησιμοποιούνται από σχήματα διαφανειών). Αυτή η ενότητα παρουσιάζει αρκετές προσεγγίσεις για την ενημέρωση εικόνων στη συλλογή. Το API παρέχει απλές μεθόδους για την αντικατάσταση μιας εικόνας χρησιμοποιώντας αμιγδα δεδομένων byte, ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/), ή άλλη εικόνα που ήδη υπάρχει στη συλλογή.

Ακολουθήστε τα παρακάτω βήματα:

1. Φορτώστε το αρχείο παρουσίασης που περιέχει εικόνες χρησιμοποιώντας την κλάση [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
2. Φορτώστε μια νέα εικόνα από αρχείο σε έναν πίνακα byte.
3. Αντικαταστήστε την εικόνα-στόχο με τη νέα εικόνα χρησιμοποιώντας τον πίνακα byte.
4. Στη δεύτερη προσέγγιση, φορτώστε την εικόνα σε αντικείμενο [IImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/iimage/) και αντικαταστήστε την εικόνα-στόχο με αυτό το αντικείμενο.
5. Στην τρίτη προσέγγιση, αντικαταστήστε την εικόνα-στόχο με μια εικόνα που ήδη υπάρχει στη συλλογή εικόνων της παρουσίασης.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
// Δημιουργία του αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation("sample.pptx");
try {
    // Ο πρώτος τρόπος.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Ο δεύτερος τρόπος.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // Ο τρίτος τρόπος.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // Αποθήκευση της παρουσίασης σε αρχείο.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

Χρησιμοποιώντας το ΔΩΡΕΑΝ μετατροπέα Aspose [Text to GIF](https://products.aspose.app/slides/el/text-to-gif), μπορείτε εύκολα να δημιουργήσετε κινούμενα κείμενα, GIF από κείμενα κλπ. 

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Παραμένει η αρχική ανάλυση της εικόνας ανέπαφη μετά την εισαγωγή;**

Ναι. Τα αρχικά pixel διατηρούνται, αλλά η τελική εμφάνιση εξαρτάται από το πώς η [picture](/slides/el/php-java/picture-frame/) κλιμακώνεται στη διαφάνεια και τυχόν συμπίεση που εφαρμόζεται κατά την αποθήκευση.

**Ποιος είναι ο καλύτερος τρόπος για να αντικαταστήσετε το ίδιο λογότυπο σε δεκάδες διαφάνειες ταυτόχρονα;**

Τοποθετήστε το λογότυπο στο master slide ή σε μια διάταξη και αντικαταστήστε το στη συλλογή εικόνων της παρουσίασης — οι ενημερώσεις θα διανεμηθούν σε όλα τα στοιχεία που χρησιμοποιούν αυτόν τον πόρο.

**Μπορεί ένα εισαχθέν SVG να μετατραπεί σε επεξεργάσιμα σχήματα;**

Ναι. Μπορείτε να μετατρέψετε ένα SVG σε ομάδα σχημάτων, μετέπειτα τα επιμέρους μέρη γίνονται επεξεργάσιμα με τις τυπικές ιδιότητες σχήματος.

**Πώς μπορώ να ορίσω μια εικόνα ως φόντο για πολλές διαφάνειες ταυτόχρονα;**

[Assign the image as the background](/slides/el/php-java/presentation-background/) στο master slide ή στη σχετική διάταξη — οποιεσδήποτε διαφάνειες που χρησιμοποιούν αυτό το master/layout θα κληρονομήσουν το φόντο.

**Πώς μπορώ να αποτρέψω την παρουσίαση από το «φούσκωμα» σε μέγεθος λόγω πολλών εικόνων;**

Επαναχρησιμοποιήστε έναν ενιαίο πόρο εικόνας αντί για αντίγραφα, επιλέξτε λογικές αναλύσεις, εφαρμόστε συμπίεση κατά την αποθήκευση και διατηρήστε τα επαναλαμβανόμενα γραφικά στο master όπου είναι κατάλληλο.