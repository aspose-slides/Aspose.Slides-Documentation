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
description: "Δημιουργήστε και προσαρμόστε το Zoom με το Aspose.Slides για PHP μέσω Java — μεταβείτε μεταξύ ενοτήτων, προσθέστε μικρογραφίες και μεταβάσεις σε παρουσιάσεις PowerPoint."
---
## **Εισαγωγή**

Τα zoom του PowerPoint σάς επιτρέπουν να πλοηγηθείτε μεταξύ συγκεκριμένων διαφανειών και ενοτήτων κατά τη διάρκεια μιας παρουσίασης. Με το Aspose.Slides for PHP via Java, μπορείτε να δημιουργήσετε zoom διαφάνειας, ενότητας και σύνοψης και να προσαρμόσετε τις προεπισκοπήσεις, τα σύνορα και τις μεταβάσεις τους.

![Επισκόπηση ζουμ PowerPoint](overview.png)

* Για να συνοψίσετε ολόκληρη την παρουσίαση σε μία διαφάνεια, χρησιμοποιήστε ένα [Summary Zoom](#summary-zoom).
* Για να εμφανίσετε μόνο επιλεγμένες διαφάνειες, χρησιμοποιήστε ένα [Slide Zoom](#slide-zoom).
* Για να εμφανίσετε μόνο μία ενότητα, χρησιμοποιήστε ένα [Section Zoom](#section-zoom).

## **Slide Zoom**

Ένα zoom διαφάνειας μπορεί να κάνει την παρουσίασή σας πιο δυναμική, επιτρέποντάς σας να πλοηγηθείτε ελεύθερα μεταξύ των διαφανειών με τη σειρά που επιθυμείτε χωρίς να διακόπτετε τη ροή της παρουσίασης. Τα zoom διαφάνειας είναι ιδανικά για σύντομες παρουσιάσεις χωρίς πολλές ενότητες, αλλά μπορείτε να τα χρησιμοποιήσετε και σε διαφορετικά σενάρια παρουσίασης.

Τα zoom διαφάνειας σας επιτρέπουν να εξερευνήσετε σχετικές πληροφορίες από μία ενιαία διαφάνεια επισκόπησης.

![Επιλογή διαφανειών για zoom διαφάνειας](slidezoomsel.png)

Για αντικείμενα zoom διαφάνειας, το Aspose.Slides παρέχει την απαρίθμηση [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/zoomimagetype/), την κλάση [ZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) και μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **Δημιουργία πλαισίων Zoom**

Χρησιμοποιήστε το [ShapeCollection::addZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addZoomFrame) για να τοποθετήσετε συνδέσμους σε μεμονωμένες διαφάνειες σε μια διαφάνεια επισκόπησης. Αυτό το παράδειγμα δημιουργεί δύο διαφάνειες-στόχους με διαφορετικά φόντα και ετικέτες, προσθέτει μια προεπισκόπηση της κάθε μιας στη πρώτη διαφάνεια και αποθηκεύει την παρουσίαση ως PPTX. Οι θέσεις και οι διαστάσεις των πλαισίων ορίζονται σε σημεία.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $secondSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $thirdSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());

    $secondSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $secondSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $secondSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");

    $thirdSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $thirdSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 189, 183, 107);
    $thirdSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

    $textBox = $thirdSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Third Slide");

    $overviewSlide->getShapes()->addZoomFrame(20, 20, 250, 200, $secondSlide);
    $overviewSlide->getShapes()->addZoomFrame(200, 250, 250, 200, $thirdSlide);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Δημιουργία πλαισίων Zoom με προσαρμοσμένες εικόνες**

Περάστε μια προσαρμοσμένη εικόνα στο [ShapeCollection::addZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addZoomFrame) για να αντικαταστήσετε την προεπιλεγμένη προεπισκόπηση της διαφάνειας-στόχου. Αυτό το παράδειγμα απαιτεί μια τοπική εικόνα, τη φορτώνει με το [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) και την προσθέτει στην παρουσίαση χρησιμοποιώντας το [ImageCollection::addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/#addImage). Το τελικό πλαίσιο εμφανίζει εκείνη την εικόνα ενώ εξακολουθεί να συνδέεται με τη δεύτερη διαφάνεια.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $overviewSlide->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $previewImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Διαμόρφωση πλαισίων Zoom**

Αυτό το παράδειγμα προσαρμόζει δύο πλαίσια zoom διαφάνειας. Αναθέτει μια τοπική εικόνα στο πρώτο πλαίσιο μέσω του [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage) και δίνει στο δεύτερο πλαίσιο ένα 5‑σημείων, παύλα‑κουκκίδα ροζ περίγραμμα μέσω του [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat). ΠPassing `false` στο [ZoomObject::setShowBackground](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setShowBackground) κρύβει το φόντο του δεύτερου πλαισίου. Απαιτείται τοπική εικόνα για την προσαρμοσμένη προεπισκόπηση· και τα δύο πλαίσια διατηρούν τους στόχους διαφάνειας στο αποθηκευμένο PPTX.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $secondSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $thirdSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());

    $secondSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $secondSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $secondSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");

    $thirdSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $thirdSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 189, 183, 107);
    $thirdSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

    $textBox = $thirdSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Third Slide");

    $firstZoomFrame = $overviewSlide->getShapes()->addZoomFrame(20, 20, 250, 200, $secondSlide);
    $secondZoomFrame = $overviewSlide->getShapes()->addZoomFrame(200, 250, 250, 200, $thirdSlide);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $firstZoomFrame->setZoomImage($previewImage);

    $secondZoomFrame->getLineFormat()->setWidth(5);
    $secondZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 105, 180);
    $secondZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($color);
    $secondZoomFrame->getLineFormat()->setDashStyle(LineDashStyle::DashDot);

    $secondZoomFrame->setShowBackground(false);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Section Zoom**

Ένα zoom ενότητας συνδέεται με μια ενότητα στην παρουσίασή σας. Χρησιμοποιήστε το για να επιστρέψετε σε ένα θέμα ή να δείξετε πώς διαφορετικά τμήματα της παρουσίασης συνδέονται μεταξύ τους.

![Επιλογή ενότητας για zoom ενότητας](seczoomsel.png)

Για αντικείμενα zoom ενότητας, το Aspose.Slides παρέχει την κλάση [SectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) και μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **Δημιουργία πλαισίων Section Zoom**

Δημιουργήστε μια ενότητα με το [SectionCollection::addSection](https://reference.aspose.com/slides/php-java/aspose.slides/sectioncollection/#addSection) και στη συνέχεια περάστε την επιστρεφόμενη ενότητα στο [ShapeCollection::addSectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSectionZoomFrame). Αυτό το παράδειγμα τοποθετεί ένα zoom ενότητας στην πρώτη διαφάνεια και το συνδέει με μια ενότητα που αρχίζει με μια χρωματιστή διαφάνεια. Η θέση και οι διαστάσεις του πλαισίου ορίζονται σε σημεία και η παρουσίαση αποθηκεύεται ως PPTX.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $section = $presentation->getSections()->addSection("Section 1", $slide);
    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Δημιουργία πλαισίων Section Zoom με προσαρμοσμένες εικόνες**

Η υπερφόρτωση εικόνας του [ShapeCollection::addSectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSectionZoomFrame) σας επιτρέπει να εμφανίσετε μια προσαρμοσμένη προεπισκόπηση χωρίς να αλλάζετε την προορισμένη ενότητα. Αυτό το παράδειγμα απαιτεί μια τοπική εικόνα, η οποία φορτώνεται με το [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) και προστίθεται μέσω του [ImageCollection::addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/#addImage). Η αποθηκευμένη παρουσίαση περιέχει ένα zoom ενότητας στην πρώτη διαφάνεια που συνδέεται με τη νεόσυστατη ενότητα.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $section = $presentation->getSections()->addSection("Section 1", $slide);
    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section, $previewImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Αλλαγή της ενότητας-στόχου ενός Section Zoom**

Χρησιμοποιήστε το [SectionZoomFrame::setTargetSection](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/#setTargetSection) για να μετατοπίσετε ένα υπάρχον zoom ενότητας χωρίς να το ξαναδημιουργήσετε. Επιλέξτε μια γεμάτη ενότητα από τη συλλογή [Presentation::getSections](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSections) της ίδιας παρουσίασης. Η ανάθεση κενής ενότητας αφήνει αμετάβλητο τον τρέχοντα στόχο, επομένως ελέγξτε το [Section::getSlidesListOfSection](https://reference.aspose.com/slides/php-java/aspose.slides/section/#getSlidesListOfSection) πριν την ανάθεση. Δείτε τη σελίδα [Manage Slide Sections](/slides/el/php-java/slide-section/) για περισσότερες πληροφορίες σχετικά με τις ενότητες.

Το παρακάτω παράδειγμα φορτώνει ένα αρχείο παρουσίασης που πρέπει να περιέχει πολλαπλές γεμάτες ενότητες, ένα υπάρχον zoom ενότητας με όνομα `Section navigation` και μια ενότητα με το μοναδικό όνομα `Results`. Αναζητά όλες τις διαφάνειες για το zoom και βρίσκει τον προορισμό με βάση το όνομα αντί για τον δείκτη της συλλογής, ο οποίος μπορεί να αλλάξει όταν οι ενότητες αναδιατάσσονται. Εάν τα ονόματα δεν είναι μοναδικά, χρησιμοποιήστε το [Section::getSectionId](https://reference.aspose.com/slides/php-java/aspose.slides/section/#getSectionId) για να εντοπίσετε τον προορισμό.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("section-zoom.pptx");
try {
    $zoom = null;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($i = 0; $i < $slideCount; $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($j = 0; $j < $shapeCount; $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISectionZoomFrame")) && java_values($shape->getName()) === "Section navigation") {
                $zoom = $shape;
                break;
            }
        }
        if ($zoom != null) {
            break;
        }
    }

    $targetSection = null;
    $sectionCount = java_values($presentation->getSections()->size());
    for ($i = 0; $i < $sectionCount; $i++) {
        $section = $presentation->getSections()->get_Item($i);
        if (java_values($section->getName()) === "Results") {
            $targetSection = $section;
            break;
        }
    }

    if ($zoom == null || $targetSection == null) {
        echo "The section zoom or destination section was not found.", PHP_EOL;
    } else if (java_values($targetSection->getSlidesListOfSection()->size()) == 0) {
        echo "The destination section is empty.", PHP_EOL;
    } else {
        $currentSection = $zoom->getTargetSection();
        echo "Current section: " . (java_is_null($currentSection) ? "" : java_values($currentSection->getName())), PHP_EOL;
        $zoom->setTargetSection($targetSection);
        $presentation->save("section-zoom-updated.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

### **Διαμόρφωση πλαισίων Section Zoom**

Αυτό το παράδειγμα μετακινεί και αλλάζει το μέγεθος ενός zoom ενότητας σε 100 × 75 σημεία, αναθέτει μια τοπική εικόνα μέσω του [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage) και εφαρμόζει ένα 2,5‑σημείων, παύλα‑κουκκίδα καστανό περίγραμμα. Ενεργοποιεί το [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) για επιστροφή στη διαφάνεια προέλευσης μετά την ενότητα, απενεργοποιεί το [ZoomObject::setShowBackground](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setShowBackground) και ορίζει το [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) σε 1,5 δευτερόλεπτα. Απαιτείται τοπική εικόνα για την προσαρμοσμένη προεπισκόπηση.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $section = $presentation->getSections()->addSection("Section 1", $slide);

    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section);
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $sectionZoomFrame->setZoomImage($previewImage);

    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);

    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($color);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle::DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);

    $sectionZoomFrame->setTransitionDuration(1.5);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Summary Zoom**

Ένα summary zoom παρέχει μια επισκόπηση των ενοτήτων της παρουσίασης. Κατά τη διάρκεια μιας παρουσίασης, μπορείτε να το χρησιμοποιήσετε για να μεταβείτε σε μια ενότητα, να παραλείψετε προς τα εμπρός ή να επανεξετάσετε ένα θέμα χωρίς να ακολουθείτε τη σειρά των διαφανειών.

![Επιλογή ενοτήτων για summary zoom](sumzoomsel.png)

Για αντικείμενα summary zoom, το Aspose.Slides παρέχει τις κλάσεις [SummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/) και [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) και μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **Δημιουργία Summary Zoom**

Χρησιμοποιήστε το [ShapeCollection::addSummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSummaryZoomFrame) για να δημιουργήσετε μια επισκόπηση των ενοτήτων της παρουσίασης. Αυτό το παράδειγμα δημιουργεί τέσσερις ενότητες με διαφορετικά φόντα διαφανειών και προσθέτει ένα summary zoom στην πρώτη διαφάνεια. Η θέση και οι διαστάσεις του πλαισίου ορίζονται σε σημεία και η τελική επισκόπηση αποθηκεύεται σε μια παρουσίαση PPTX.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 127, 255, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 3", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 100, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 4", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Προσθήκη και αφαίρεση Section σε Summary Zoom**

Ένα summary zoom αποθηκεύει τα αντικείμενα [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/) στο [SummaryZoomFrame::getSummaryZoomCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection). Αυτό το παράδειγμα δημιουργεί μια επισκόπηση δύο ενοτήτων, προσθέτει μια τρίτη ενότητα χρησιμοποιώντας το [SummaryZoomSectionCollection::addSummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) και αφαιρεί την καταχώρηση της πρώτης ενότητας με το [SummaryZoomSectionCollection::removeSummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection). Η αφαίρεση διατηρεί την ενότητα της παρουσίασης και τις διαφάνειές της ανέπαφες.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $firstSection = $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 127, 255, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $thirdSection = $presentation->getSections()->addSection("Section 3", $slide);

    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($thirdSection);

    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($firstSection);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Διαμόρφωση Section σε Summary Zoom**

Αυτό το παράδειγμα μορφοποιεί την πρώτη καταχώρηση στο [SummaryZoomFrame::getSummaryZoomCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection), χρησιμοποιώντας τον μηδενικό δείκτη `0`. Απαιτεί τοπική εικόνα για το [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage), εφαρμόζει ένα 1,5‑σημείων, παύλα‑κουκκίδα μαύρο περίγραμμα και ορίζει το [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) σε 1,5 δευτερόλεπτα. ΠPassing `false` στο [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) απενεργοποιεί την αυτόματη επιστροφή στη διαφάνεια σύνοψης για αυτήν την καταχώρηση.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $summarySection->setZoomImage($previewImage);
    $summarySection->setReturnToParent(false);

    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle::DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);

    $summarySection->setTransitionDuration(1.5);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Μπορώ να ελέγξω την επιστροφή στη «γονική» διαφάνεια μετά την εμφάνιση του στόχου;**

Ναι. Καλέστε το [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) με `true` για να επιστρέψετε στη διαφάνεια προέλευσης μετά την εμφάνιση του περιεχομένου-στόχου.

**Μπορώ να ρυθμίσω την «ταχύτητα» ή τη διάρκεια της μετάβασης του Zoom;**

Ναι. Χρησιμοποιήστε το [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) για να ελέγξετε τη διάρκεια της μετάβασης σε δευτερόλεπτα.

**Υπάρχουν περιορισμοί στον αριθμό των αντικειμένων Zoom που μπορεί να περιέχει μια παρουσίαση;**

Δεν υπάρχει σκληρός περιορισμός API που να τεκμηριώνεται. Οι πρακτικοί περιορισμοί εξαρτώνται από τη συνολική πολυπλοκότητα της παρουσίασης και τις επιδόσεις του προγράμματος προβολής. Μπορείτε να προσθέσετε πολλά πλαίσια Zoom, αλλά λάβετε υπόψη το μέγεθος του αρχείου και το χρόνο απόδοσης.