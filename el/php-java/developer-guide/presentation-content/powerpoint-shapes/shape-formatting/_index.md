---
title: Μορφοποίηση Σχημάτων PowerPoint σε PHP
linktitle: Μορφοποίηση Σχήματος
type: docs
weight: 20
url: /el/php-java/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκίτσο
- γραμμή σχήματος σκίτσο
- μορφοποίηση στυλ σύνδεσης
- γέμισμα διαβάθμισης
- γέμισμα μοτίβου
- γέμισμα εικόνας
- γέμισμα υφής
- γέμισμα στερεού χρώματος
- διαφάνεια σχήματος
- απόδοση σχήματος σε ασπρόμαυρο
- απόδοση σχήματος σε γκρι κλίμακα
- περιστροφή σχήματος
- 3Δ εφέ ακμής
- 3Δ εφέ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε PHP χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γέμισης, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Δεδομένου ότι τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα ορίζοντας ρυθμίσεις που ελέγχουν το πώς γεμίζουν τα εσωτερικά τους.

![Διαμόρφωση Σχήματος PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides για PHP μέσω Java παρέχει κλάσεις και μεθόδους που σας επιτρέπουν να διαμορφώνετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Διαμόρφωση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να ορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/el/php-java/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/el/php-java/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα της γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας PHP δείχνει πώς να διαμορφώσετε ένα ορθογώνιο `AutoShape`:

```php
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για το σχήμα rectangle.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Εφαρμόστε μορφοποίηση στις γραμμές του rectangle.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Ορίστε το χρώμα της γραμμής του rectangle.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Οι διαμορφωμένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Εφαρμογή Σκετς Εφέ στις Γραμμές Σχήματος**

Ένα σκετς εφέ κάνει τη γραμμή του σχήματος να φαίνεται χειροποίητη. Χρησιμοποιήστε [Shape.getLineFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) για πρόσβαση στις ρυθμίσεις της γραμμής, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/lineformat/) για πρόσβαση στις ρυθμίσεις του σκετς και [SketchFormat.setSketchType](https://reference.aspose.com/slides/el/php-java/aspose.slides/sketchformat/) για επιλογή μια τιμής από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/el/php-java/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας PHP δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/el/php-java/aspose.slides/linesketchtype/), να διαβάσετε την ρητά ορισμένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType.None](https://reference.aspose.com/slides/el/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Πρόσβαση στη μορφοποίηση γραμμής του σχήματος και στη μορφοποίηση σκίτσου.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Εφαρμογή εφέ σκίτσου.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Ανάγνωση του εφέ σκίτσου που έχει οριστεί απευθείας στο σχήμα.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Αφαίρεση του εφέ σκίτσου.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Η τιμή που επιστρέφει το [SketchFormat.getSketchType](https://reference.aspose.com/slides/el/php-java/aspose.slides/sketchformat/) αντιπροσωπεύει τη ρύθμιση που έχει οριστεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής κληρονομείται από θέμα, κύρια διαφάνεια ή διάταξη, χρησιμοποιήστε το [LineFormat.getEffective](https://reference.aspose.com/slides/el/php-java/aspose.slides/lineformat/), αποκτήστε τη μέθοδο `getSketchFormat` του επιστρεφόμενου αντικειμένου και διαβάστε την τιμή `getSketchType`. Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομίας:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Διαμόρφωση Στυλ Ένωσης**

Αυτές είναι οι τρεις επιλογές τύπου σύμμεσης:

* Round
* Miter
* Bevel

Από προεπιλογή, όταν το PowerPoint ενώνει δύο γραμμές σε γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Round**. Ωστόσο, εάν σχεδιάζετε σχήμα με έντονες γωνίες, ίσως προτιμήσετε την επιλογή **Miter**.

![Το στυλ ένωσης στην παρουσίαση](join-style-powerpoint.png)

Ο παρακάτω κώδικας PHP δείχνει πώς τρία ορθογώνια (όπως φαίνονται στην παραπάνω εικόνα) δημιουργήθηκαν χρησιμοποιώντας τις ρυθμίσεις τύπου ένωσης Miter, Bevel και Round:

```php
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε τρία αυτόματα σχήματα τύπου Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για κάθε σχήμα rectangle.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Ορίστε το πάχος της γραμμής.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Ορίστε το χρώμα της γραμμής για κάθε rectangle.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Ορίστε το στυλ σύνδεσης.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Προσθέστε κείμενο σε κάθε rectangle.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Γέμιση Διαβάθμισης**

Στο PowerPoint, η Γέμιση Διαβάθμισης είναι μια επιλογή μορφοποίησης που επιτρέπει την εφαρμογή ενός συνεχούς μίγματος χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τρόπο που το ένα να εξασθένει απαλά στο άλλο.

Ακολουθήστε τα βήματα για να εφαρμόσετε γέμιση διαβάθμισης σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής διακοπτών διαβάθμισης που εκτίθεται από την κλάση [GradientFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/gradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας PHP εφαρμόζει γέμιση διαβάθμισης σε μια έλλειψη:

```php
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Εφαρμόστε μορφοποίηση διαβάθμισης στο σχήμα Ellipse.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Ορίστε την κατεύθυνση της διαβάθμισης.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Προσθέστε δύο σημεία διαβάθμισης.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η έλλειψη με γέμιση διαβάθμισης](gradient-fill.png)

## **Γέμιση Μοτίβου**

Στο PowerPoint, η Γέμιση Μοτίβου είναι μια επιλογή μορφοποίησης που επιτρέπει την εφαρμογή ενός σχεδίου δύο χρωμάτων—όπως κουκκίδες, λωρίδες, σταυροειδή ή καρό σχέδια—σ' ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το παρασκήνιο του μοτίβου.

Το Aspose.Slides παρέχει πάνω από 45 προεγκατεστημένα στυλ μοτίβου που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική απήχηση των παρουσιάσεών σας. Ακόμη και αφού επιλέξετε ένα προεγκατεστημένο μοτίβο, μπορείτε να καθορίσετε τις ακριβείς χρωματικές τιμές που θα χρησιμοποιήσει.

Ακολουθήστε τα βήματα για να εφαρμόσετε γέμιση μοτίβου σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ μοτίβου από τις προεγκατεστημένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/el/php-java/aspose.slides/patternformat/#getBackColor) του μοτίβου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/el/php-java/aspose.slides/patternformat/#getForeColor) του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας PHP εφαρμόζει γέμιση μοτίβου σε ένα ορθογώνιο:

```php
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Ορίστε το στυλ μοτίβου.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Ορίστε τα χρώματα παρασκηνίου και προσκηνίου του μοτίβου.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμιση μοτίβου](pattern-fill.png)

## **Γέμιση Εικόνας**

Στο PowerPoint, η Γέμιση Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να ενσωματώσετε μια εικόνα μέσα σε ένα σχήμα—χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθήστε τα βήματα για να χρησιμοποιήσετε το Aspose.Slides ώστε να εφαρμόσετε γέμιση εικόνας σε σχήμα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία γέμισης εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Περνάτε την εικόνα στη μέθοδο `SlidesPicture.setImage`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ας υποθέσουμε ότι έχουμε το αρχείο "lotus.png" με την παρακάτω εικόνα:

![Η εικόνα λωτού](lotus.png)

Ο παρακάτω κώδικας PHP γεμίζει ένα σχήμα με την εικόνα:

```php
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Ορίστε τον τύπο γεμίσματος σε Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Ορίστε τη λειτουργία γέμισης εικόνας.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Φορτώστε μια εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Ορίστε την εικόνα.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με γέμιση εικόνας](picture-fill.png)

### **Τοποθέτηση Εικόνας ως Υφή**

Αν θέλετε να ορίσετε μια παρατεταμένη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά της επικάλυψης, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Ορίζει τη λειτουργία γέμισης εικόνας—είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#setTileAlignment): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#setTileFlip): Ελέγχει αν το πλακίδιο θα αντιστραφεί οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε points) από το αρχικό σημείο του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Ορίζει τη κάθετη μετατόπιση του πλακιδίου (σε points) από το αρχικό σημείο του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#setTileScaleX): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#setTileScaleY): Ορίζει τη κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με γέμιση εικόνας σε πλακίδια και να διαμορφώσετε τις επιλογές πλακιδίου:

```php
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα Rectangle.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Ορίστε τον τύπο γεμίσματος του σχήματος σε Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Φορτώστε την εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Αναθέστε την εικόνα στο σχήμα.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Διαμορφώστε τη λειτουργία γέμισης εικόνας και τις ιδιότητες επικάλυψης.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίου](tile-options.png)

## **Γέμιση Σταθερού Χρώματος**

Στο PowerPoint, η Γέμιση Σταθερού Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή μοτίβα.

Για να εφαρμόσετε γέμιση σταθερού χρώματος σε σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Αναθέστε το προτιμώμενο χρώμα γέμισης στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας PHP εφαρμόζει γέμιση σταθερού χρώματος σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

```php
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Ορίστε το χρώμα γεμίσματος.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με γέμιση σταθερού χρώματος](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε γέμιση σταθερού χρώματος, διαβάθμισης, εικόνας ή υφής σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια της γέμισης. Μία υψηλότερη τιμή διαφάνειας κάνει το σχήμα πιο διαυγές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να είναι εν μέρει ορατά.

Το Aspose.Slides σάς επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για τη γέμιση. Ακολουθήστε τα εξής βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε την κλάση `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το συστατικό `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας PHP εφαρμόζει διαφανές χρώμα γέμισης σε ένα ορθογώνιο:

```php
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα στερεό αυτόματο σχήμα Rectangle.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Προσθέστε ένα διαφανές αυτόματο σχήμα Rectangle πάνω από το στερεό σχήμα.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σας επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένη στοίχιση ή σχεδιαστικές ανάγκες.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας PHP περιστρέφει ένα σχήμα κατά 5 μοίρες:

```php
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Περιστρέψτε το σχήμα κατά 5 μοίρες.
    $shape->setRotation(5);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη 3Δ Εφέ Ακμής**

Το Aspose.Slides επιτρέπει την εφαρμογή 3Δ εφέ ακμής σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/).

Για να προσθέσετε 3Δ εφέ ακμής σε ένα σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Διαμορφώστε το [ThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις ακμής.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας PHP εφαρμόζει 3Δ εφέ ακμής σε σχήμα:

```php
// Δημιουργήστε μια παρουσία της κλάσης Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα σχήμα στη διαφάνεια.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Ορίστε τις ιδιότητες ThreeDFormat του σχήματος.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το 3Δ εφέ ακμής](3D-bevel-effect.png)

## **Προσθήκη 3Δ Εφέ Περιστροφής**

Το Aspose.Slides επιτρέπει την εφαρμογή 3Δ εφέ περιστροφής σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/).

Για να εφαρμόσετε 3Δ περιστροφή σε σχήμα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τις μεθόδους [setCameraType](https://reference.aspose.com/slides/el/php-java/aspose.slides/camera/#setCameraType) και [setLightType](https://reference.aspose.com/slides/el/php-java/aspose.slides/lightrig/#setLightType) για να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας PHP εφαρμόζει 3Δ εφέ περιστροφής σε σχήμα:

```php
// Δημιουργήστε μια παρουσία της κλάσης Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το 3Δ εφέ περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Μαυρό-Λευκής Απόδοσης για Σχήματα**

Η μέθοδος [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/#setBlackWhiteMode) ορίζει πώς θα αποδίδεται ένα μεμονωμένο σχήμα όταν η παρουσίαση προβάλλεται ή επεξεργάζεται σε μαυρό-λευκό τρόπο. Δεν ενεργοποιεί αυτόματα τη μαυρό-λευκή προβολή και δεν αλλάζει τη γέμιση, τη γραμμή ή άλλες μορφές σε κανονική χρωματική λειτουργία.

Χρησιμοποιήστε μια τιμή από την κλάση [BlackWhiteMode](https://reference.aspose.com/slides/el/php-java/aspose.slides/blackwhitemode/) για να επιλέξετε τη ζητούμενη συμπεριφορά. Για παράδειγμα, το `Automatic` αφήνει την εφαρμογή απόφασης να επιλέξει τη μετατροπή, τα `Gray` και `LightGray` χρησιμοποιούν γκρι χρώματα, το `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, τα `Black` και `White` επιβάλλουν ένα ενιαίο χρώμα, το `Color` διατηρεί το κανονικό χρώμα, και το `Hidden` αποκρύπτει το σχήμα σε μαυρό-λευκή λειτουργία. Το `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

Ο παρακάτω κώδικας PHP δημιουργεί ένα χρωματιστό σχήμα και το κάνει γκρι σε μαυρό-λευκή λειτουργία:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // Διατηρήστε το πορτοκαλί γέμισμα σε χρωματική λειτουργία, αλλά αποδώστε το σχήμα με γκρι χρώμα σε μαυρό-λευκή λειτουργία.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Σε κανονική χρωματική λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμα του. Σε μαυρό-λευκή ροή εργασίας, χρησιμοποιεί γκρι χρώμα επειδή η λειτουργία του έχει οριστεί σε `Gray`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρως χρωματιστή διαφάνεια ενώ ορίζετε διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις μαυρό-λευκής προβολής.

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας Java δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στη [LayoutSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Επαναφέρετε κάθε σχήμα στη διαφάνεια που έχει placeholder στη διάταξη.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση των σχημάτων το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν πρακτικά κανένα πρόσθετο μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν ταυτόμορφη μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις κύριες ιδιότητες μορφοποίησης κάθε σχήματος—γέμιση, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε τα στυλ ως ταυτόσημα και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχημάτων σε ξεχωριστό αρχείο για χρήση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε μια πρότυπη παρουσίαση ή σε αρχείο .POTX. Όταν δημιουργείτε νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλσυγκεκριμένα σχήματα που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.