---
title: Διαχείριση Zoom παρουσίασης σε PHP
linktitle: Διαχείριση Zoom
type: docs
weight: 60
url: /el/php-java/manage-zoom/
keywords:
- ζουμ
- πλαίσιο ζουμ
- ζουμ διαφάνειας
- ζουμ ενότητας
- ζουμ σύνοψης
- προσθήκη ζουμ
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε το Zoom με Aspose.Slides για PHP μέσω Java — μεταβείτε μεταξύ ενοτήτων, προσθέστε μικρογραφίες και μεταβάσεις σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Τα Zoom στο PowerPoint σας επιτρέπουν να μεταβαίνετε σε συγκεκριμένες διαφάνειες, ενότητες και τμήματα μιας παρουσίασης και πίσω. Κατά την παρουσίαση, αυτή η δυνατότητα γρήγορης περιήγησης στο περιεχόμενο μπορεί να αποδειχθεί πολύ χρήσιμη. 

![overview_image](overview.png)

* Για να συνοψίσετε ολόκληρη την παρουσίαση σε μία μόνο διαφάνεια, χρησιμοποιήστε ένα [Zoom Σύνοψη](#Summary-Zoom).
* Για να εμφανίσετε μόνο επιλεγμένες διαφάνειες, χρησιμοποιήστε ένα [Zoom Διαφάνειας](#Slide-Zoom).
* Για να εμφανίσετε μόνο μία ενότητα, χρησιμοποιήσετε ένα [Zoom Ενότητας](#Section-Zoom).

## **Zoom Διαφάνειας**
Το Zoom διαφάνειας μπορεί να κάνει την παρουσίασή σας πιο δυναμική, επιτρέποντας ελεύθερη περιήγηση μεταξύ των διαφανειών με τη σειρά που επιλέγετε χωρίς να διακόπτετε τη ροή της παρουσίασης. Τα Zoom διαφάνειας είναι ιδανικά για σύντομες παρουσιάσεις χωρίς πολλές ενότητες, αλλά μπορείτε ακόμη να τα χρησιμοποιήσετε σε διαφορετικά σενάρια παρουσίασης.

Τα Zoom διαφάνειας σας βοηθούν να εμβαθύνετε σε πολλαπλά τμήματα πληροφορίας ενώ αισθάνεστε ότι βρίσκεστε σε ένα ενιαίο καμβά. 

![overview_image](slidezoomsel.png)

Για αντικείμενα Zoom διαφάνειας, το Aspose.Slides παρέχει την αρίθμηση [ZoomImageType](https://reference.aspose.com/slides/el/php-java/aspose.slides/zoomimagetype/) , την κλάση [ZoomFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/zoomframe/) και κάποιες μεθόδους κάτω από την κλάση [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/) .

### **Δημιουργία Πλαισίων Zoom**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom σε μια διαφάνεια ως εξής:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Δημιουργήστε νέες διαφάνειες στις οποίες σκοπεύετε να συνδέσετε τα πλαίσια zoom. 
3. Προσθέστε κείμενο αναγνώρισης και φόντο στις δημιουργημένες διαφάνειες.
4. Προσθέστε πλαίσια zoom (που περιέχουν τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom σε μια διαφάνεια:

```php
  $pres = new Presentation();
  try {
    # Προσθέτει νέες διαφάνειες στην παρουσίαση
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Δημιουργεί πλαίσιο κειμένου για τη δεύτερη διαφάνεια
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Δημιουργεί φόντο για την τρίτη διαφάνεια
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Προσθέτει αντικείμενα ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Αποθηκεύει την παρουσίαση
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Δημιουργία Πλαισίων Zoom με Προσαρμοσμένες Εικόνες**
Με το Aspose.Slides για PHP μέσω Java, μπορείτε να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική προεπισκόπηση διαφάνειας ως εξής:
1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Δημιουργήστε μια νέα διαφάνεια στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
3. Προσθέστε κείμενο αναγνώρισης και φόντο στη διαφάνεια.
4. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) που θα χρησιμοποιηθεί για τη γέμισμα του πλαισίου.
5. Προσθέστε πλαίσια zoom (που περιέχουν την αναφορά στη δημιουργημένη διαφάνεια) στην πρώτη διαφάνεια.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική εικόνα:

```php
  $pres = new Presentation();
  try {
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Δημιουργεί νέα εικόνα για το αντικείμενο Zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Προσθέτει το αντικείμενο ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # Αποθηκεύει την παρουσίαση
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Μορφοποίηση Πλαισίων Zoom**
Στις προηγούμενες ενότητες, σας δείξαμε πώς να δημιουργήσετε απλά πλαίσια zoom. Για να δημιουργήσετε πιο σύνθετα πλαίσια zoom, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν διάφορες επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο zoom. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός πλαισίου zoom σε μια διαφάνεια ως εξής:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Δημιουργήστε νέες διαφάνειες στις οποίες σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
3. Προσθέστε κάποιο κείμενο αναγνώρισης και φόντο στις δημιουργημένες διαφάνειες.
4. Προσθέστε πλαίσια zoom (που περιέχουν τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) που θα χρησιμοποιηθεί για τη γέμισμα του πλαισίου.
6. Ορίστε προσαρμοσμένη εικόνα για το πρώτο αντικείμενο πλαισίου zoom.
7. Αλλάξτε τη μορφοποίηση της γραμμής για το δεύτερο αντικείμενο πλαισίου zoom.
8. Αφαιρέστε το φόντο από μια εικόνα του δεύτερου αντικειμένου πλαισίου zoom.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να αλλάξετε τη μορφοποίηση ενός πλαισίου zoom σε μια διαφάνεια:

```php
  $pres = new Presentation();
  try {
    # Προσθέτει νέες διαφάνειες στην παρουσίαση
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Δημιουργεί πλαίσιο κειμένου για τη δεύτερη διαφάνεια
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Δημιουργεί φόντο για την τρίτη διαφάνεια
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Προσθέτει αντικείμενα ZoomFrame
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Δημιουργεί νέα εικόνα για το αντικείμενο zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Ορίζει προσαρμοσμένη εικόνα για το αντικείμενο zoomFrame1
    $zoomFrame1->setImage($picture);
    # Ορίζει μορφοποίηση πλαισίου zoom για το αντικείμενο zoomFrame2
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # Ρύθμιση για μη εμφάνιση φόντου για το αντικείμενο zoomFrame2
    $zoomFrame2->setShowBackground(false);
    # Αποθηκεύει την παρουσίαση
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zoom Ενότητας**

Το Zoom ενότητας είναι ένας σύνδεσμος σε μια ενότητα της παρουσίασής σας. Μπορείτε να χρησιμοποιήσετε τα Zoom ενότητας για να επιστρέψετε σε ενότητες που θέλετε να τονίσετε. Ή μπορείτε να τα χρησιμοποιήσετε για να επισημάνετε πώς συγκεκριμένα τμήματα της παρουσίασής σας συνδέονται. 

![overview_image](seczoomsel.png)

Για αντικείμενα Zoom ενότητας, το Aspose.Slides παρέχει την κλάση [SectionZoomFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/sectionzoomframe/) και κάποιες μεθόδους κάτω από την κλάση [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/) .

### **Δημιουργία Πλαισίων Zoom Ενότητας**

Μπορείτε να προσθέσετε ένα πλαίσιο Zoom ενότητας σε μια διαφάνεια ως εξής:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Δημιουργήστε μια νέα διαφάνεια. 
3. Προσθέστε φόντο αναγνώρισης στην δημιουργημένη διαφάνεια.
4. Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5. Προσθέστε ένα πλαίσιο Zoom ενότητας (που περιέχει αναφορές στην δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom σε μια διαφάνεια:

```php
  $pres = new Presentation();
  try {
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    $pres->getSections()->addSection("Section 1", $slide);
    # Προσθέτει αντικείμενο SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Αποθηκεύει την παρουσίαση
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Δημιουργία Πλαισίων Zoom Ενότητας με Προσαρμοσμένες Εικόνες**

Χρησιμοποιώντας το Aspose.Slides για PHP μέσω Java, μπορείτε να δημιουργήσετε ένα πλαίσιο Zoom ενότητας με διαφορετική προεπισκόπηση διαφάνειας ως εξής:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Δημιουργήστε μια νέα διαφάνεια.
3. Προσθέστε φόντο αναγνώρισης στην δημιουργημένη διαφάνεια.
4. Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) που θα χρησιμοποιηθεί για τη γέμισμα του πλαισίου.
5. Προσθέστε ένα πλαίσιο Zoom ενότητας (που περιέχει μια αναφορά στην δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική εικόνα:

```php
  $pres = new Presentation();
  try {
    # Προσθέτει νέα διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    $pres->getSections()->addSection("Section 1", $slide);
    # Δημιουργεί νέα εικόνα για το αντικείμενο zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Προσθέτει αντικείμενο SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # Αποθηκεύει την παρουσίαση
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Μορφοποίηση Πλαισίων Zoom Ενότητας**

Για να δημιουργήσετε πιο σύνθετα πλαίσια Zoom ενότητας, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν διάφορες επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο Zoom ενότητας. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός πλαισίου Zoom ενότητας σε μια διαφάνεια ως εξής:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Δημιουργήστε μια νέα διαφάνεια.
3. Προσθέστε φόντο αναγνώρισης στην δημιουργημένη διαφάνεια.
4. Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5. Προσθέστε ένα πλαίσιο Zoom ενότητας (που περιέχει αναφορές στην δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6. Αλλάξτε το μέγεθος και τη θέση του δημιουργημένου αντικειμένου Zoom ενότητας.
7. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) που θα χρησιμοποιηθεί για τη γέμισμα του πλαισίου.
8. Ορίστε προσαρμοσμένη εικόνα για το δημιουργημένο αντικείμενο Zoom ενότητας.
9. Ορίστε τη δυνατότητα *επιστροφής στην αρχική διαφάνεια από την συνδεδεμένη ενότητα*. 
10. Αφαιρέστε το φόντο από μια εικόνα του αντικειμένου Zoom ενότητας.
11. Αλλάξτε τη μορφοποίηση της γραμμής για το δεύτερο πλαίσιο zoom.
12. Αλλάξτε τη διάρκεια της μετάβασης.
13. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να αλλάξετε τη μορφοποίηση ενός πλαισίου Zoom ενότητας:

```php
  $pres = new Presentation();
  try {
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    $pres->getSections()->addSection("Section 1", $slide);
    # Προσθέτει αντικείμενο SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Μορφοποίηση για SectionZoomFrame
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # Αποθηκεύει την παρουσίαση
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zoom Σύνοψης**

Το Zoom σύνοψης είναι σαν μια αρχική σελίδα όπου όλα τα τμήματα της παρουσίασής σας εμφανίζονται ταυτόχρονα. Κατά τη διάρκεια της παρουσίασης, μπορείτε να χρησιμοποιήσετε το zoom για να μεταβείτε από ένα σημείο της παρουσίασης σε άλλο με την σειρά που θέλετε. Μπορείτε να είστε δημιουργικοί, να παραλείψετε μέρη ή να επιστρέψετε σε τμήματα της παρουσίασης χωρίς να διακόπτετε τη ροή.

![overview_image](sumzoomsel.png)

Για αντικείμενα Zoom σύνοψης, το Aspose.Slides παρέχει τις κλάσεις [SummaryZoomFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/el/php-java/aspose.slides/summaryzoomsection/) και [SummaryZoomSectionCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/summaryzoomsectioncollection/) και κάποιες μεθόδους κάτω από την κλάση [ShapeCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/shapecollection/) .

### **Δημιουργία Zoom Σύνοψης**

Μπορείτε να προσθέσετε ένα πλαίσιο Zoom σύνοψης σε μια διαφάνεια ως εξής:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Δημιουργήστε νέες διαφάνειες με φόντο αναγνώρισης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3. Προσθέστε το πλαίσιο Zoom σύνοψης στην πρώτη διαφάνεια.
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να δημιουργήσετε ένα πλαίσιο Zoom σύνοψης σε μια διαφάνεια:

```php
  $pres = new Presentation();
  try {
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    $pres->getSections()->addSection("Section 1", $slide);
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    $pres->getSections()->addSection("Section 2", $slide);
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    $pres->getSections()->addSection("Section 3", $slide);
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    $pres->getSections()->addSection("Section 4", $slide);
    # Προσθέτει αντικείμενο SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Αποθηκεύει την παρουσίαση
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Προσθήκη και Αφαίρεση Ενότητας Zoom Σύνοψης**

Όλες οι ενότητες σε ένα πλαίσιο Zoom σύνοψης αντιπροσωπεύονται από αντικείμενα [SummaryZoomSection](https://reference.aspose.com/slides/el/php-java/aspose.slides/summaryzoomsection/) , τα οποία αποθηκεύονται στην συλλογή [SummaryZoomSectionCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/summaryzoomsectioncollection/) . Μπορείτε να προσθέσετε ή να αφαιρέσετε ένα αντικείμενο ενότητας Zoom σύνοψης μέσω της κλάσης [SummaryZoomSectionCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/summaryzoomsectioncollection/) ως εξής:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Δημιουργήστε νέες διαφάνειες με φόντο αναγνώρισης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3. Προσθέστε ένα πλαίσιο Zoom σύνοψης στην πρώτη διαφάνεια.
4. Προσθέστε μια νέα διαφάνεια και ενότητα στην παρουσίαση.
5. Προσθέστε τη δημιουργημένη ενότητα στο πλαίσιο Zoom σύνοψης.
6. Αφαιρέστε την πρώτη ενότητα από το πλαίσιο Zoom σύνοψης.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να προσθέσετε και να αφαιρέσετε ενότητες σε ένα πλαίσιο Zoom σύνοψης:

```php
  $pres = new Presentation();
  try {
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    $pres->getSections()->addSection("Section 1", $slide);
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    $pres->getSections()->addSection("Section 2", $slide);
    # Προσθέτει αντικείμενο SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Προσθέτει μια ενότητα στο Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Αφαιρεί ενότητα από το Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Αποθηκεύει την παρουσίαση
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Μορφοποίηση Ενοτήτων Zoom Σύνοψης**

Για να δημιουργήσετε πιο σύνθετα αντικείμενα ενότητας Zoom σύνοψης, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν διάφορες επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα αντικείμενο ενότητας Zoom σύνοψης. 

Μπορείτε να ελέγξετε τη μορφοποίηση μιας ενότητας Zoom σύνοψης σε ένα πλαίσιο Zoom σύνοψης ως εξής:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) .
2. Δημιουργήστε νέες διαφάνειες με φόντο αναγνώρισης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3. Προσθέστε ένα πλαίσιο Zoom σύνοψης στην πρώτη διαφάνεια.
4. Παίρετε ένα αντικείμενο ενότητας Zoom σύνοψης για το πρώτο αντικείμενο από το `SummaryZoomSectionCollection`.
7. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) προσθέτοντας μια εικόνα στη συλλογή images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) που θα χρησιμοποιηθεί για τη γέμισμα του πλαισίου.
8. Ορίστε προσαρμοσμένη εικόνα για το δημιουργημένο αντικείμενο Zoom ενότητας.
9. Ορίστε τη δυνατότητα *επιστροφής στην αρχική διαφάνεια από την συνδεδεμένη ενότητα*. 
11. Αλλάξτε τη μορφοποίηση της γραμμής για το δεύτερο πλαίσιο zoom.
12. Αλλάξτε τη διάρκεια της μετάβασης.
13. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας PHP δείχνει πώς να αλλάξετε τη μορφοποίηση ενός αντικειμένου ενότητας Zoom σύνοψης:

```php
  $pres = new Presentation();
  try {
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    $pres->getSections()->addSection("Section 1", $slide);
    # Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Προσθέτει μια νέα Ενότητα στην παρουσίαση
    $pres->getSections()->addSection("Section 2", $slide);
    # Προσθέτει αντικείμενο SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Παίρνει το πρώτο αντικείμενο SummaryZoomSection
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # Μορφοποίηση για το αντικείμενο SummaryZoomSection
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # Αποθηκεύει την παρουσίαση
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την επιστροφή στη «γονική» διαφάνεια μετά την εμφάνιση του στόχου;**

Ναι. Το [Zoom frame](https://reference.aspose.com/slides/el/php-java/aspose.slides/zoomframe/) ή το [section](https://reference.aspose.com/slides/el/php-java/aspose.slides/sectionzoomframe/) διαθέτει τη συμπεριφορά `ReturnToParent` που, όταν ενεργοποιηθεί, επιστρέφει τους θεατές στην αρχική διαφάνεια μετά την επίσκεψη στο περιεχόμενο-στόχο.

**Μπορώ να ρυθμίσω την «ταχύτητα» ή την διάρκεια της μετάβασης Zoom;**

Ναι. Το Zoom υποστηρίζει τον καθορισμό μιας `TransitionDuration` ώστε να μπορείτε να ελέγξετε πόσο χρόνο διαρκεί η κίνηση.

**Υπάρχουν περιορισμοί στον αριθμό των αντικειμένων Zoom που μπορεί να περιέχει μια παρουσίαση;**

Δεν υπάρχει σκληρός περιορισμός API που να τεκμηριώνεται. Οι πρακτικοί περιορισμοί εξαρτώνται από τη συνολική πολυπλοκότητα της παρουσίασης και την απόδοση του θεατή. Μπορείτε να προσθέσετε πολλά πλαίσια Zoom, αλλά λάβετε υπόψη το μέγεθος του αρχείου και τον χρόνο απόδοσης.