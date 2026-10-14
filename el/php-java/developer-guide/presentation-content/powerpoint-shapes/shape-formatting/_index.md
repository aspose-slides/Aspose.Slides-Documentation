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
  - γέμισμα σταθερού χρώματος
  - διαφάνεια σχήματος
  - αποτύπωση σχήματος σε ασπρόμαυρο
  - αποτύπωση σχήματος σε γκρι κλίμακα
  - περιστροφή σχήματος
  - εφέ 3Δ λεπίδας
  - εφέ 3Δ περιστροφής
  - επαναφορά μορφοποίησης
  - PowerPoint
  - παρουσίαση
  - PHP
  - Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε PHP χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Δεδομένου ότι τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματα τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζουν τα εσωτερικά τους.

![μορφοποίηση-σχήματος-powerpoint](format-shape-powerpoint.png)

Το Aspose.Slides for PHP via Java παρέχει κλάσεις και μεθόδους που σας επιτρέπουν να μορφοποιείτε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να καθορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε μια παρουσίαση κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε τη πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για το σχήμα rectangle.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Εφαρμόστε μορφοποίηση στις γραμμές του rectangle.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Ορίστε το χρώμα για τη γραμμή του rectangle.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Αποθηκεύστε το αρχείο PPTX στο δίσκο.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Εφαρμογή Σχεδίασης Εφέ στις Γραμμές Σχήματος**

Ένα εφέ σκίτσο κάνει τη γραμμή ενός σχήματος να φαίνεται σχεδιασμένη με το χέρι. Χρησιμοποιήστε [Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) για πρόσβαση στις ρυθμίσεις γραμμής, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) για πρόσβαση στις ρυθμίσεις σκίτσο, και [SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) για να επιλέξετε μια τιμή από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

Ο ακόλουθος κώδικας PHP δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) , να διαβάσετε την ρητά ορισμένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Πρόσβαση στη μορφή γραμμής του σχήματος και στη μορφή σκίτσου.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Εφαρμογή εφέ σκίτσου.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Ανάγνωση του εφέ σκίτσου που έχει οριστεί άμεσα στο σχήμα.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Αφαίρεση του εφέ σκίτσου.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Η τιμή που επιστρέφει το [SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) αντιπροσωπεύει τη ρύθμιση που έχει ανατεθεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληρονομηθεί από ένα θέμα, κύρια διαφάνεια ή διαφάνεια διάταξης, χρησιμοποιήστε το [LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/), προσπελάστε τη μέθοδο `getSketchFormat` του επιστρεφόμενου αντικειμένου και διαβάστε την τιμή `getSketchType`. Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομιάς:

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

## **Μορφοποίηση Στυλ Συνδέσεων**

Αυτές είναι οι τρεις επιλογές τύπου σύνδεσης:

* Στρογγυλό
* Γωνιακό
* Κωνικό

Από προεπιλογή, όταν το PowerPoint συνδέει δύο γραμμές υπό γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλό**. Ωστόσο, εάν σχεδιάζετε ένα σχήμα με κοφτές γωνίες, μπορεί να προτιμάτε την επιλογή **Γωνιακό**.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Ο ακόλουθος κώδικας PHP δείχνει πώς δημιουργήθηκαν τρία ορθογώνια (όπως φαίνεται στην παραπάνω εικόνα) χρησιμοποιώντας τις ρυθμίσεις τύπου σύνδεσης Γωνιακό, Κωνικό και Στρογγυλό:

```php
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθήκη τριών αυτόματων σχημάτων τύπου Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Ορισμός του χρώματος γεμίσματος για κάθε σχήμα rectangle.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Ορισμός του πλάτους της γραμμής.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Ορισμός του χρώματος για τη γραμμή κάθε rectangle.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Ορισμός του στυλ σύνδεσης.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Προσθήκη κειμένου σε κάθε rectangle.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Γέμισμα Διαβάθμισης**

Στο PowerPoint, το Γέμισμα Διαβάθμισης είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόζετε μια συνεχόμενη ανάμειξη χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τρόπο που το ένα χρώμα να εξασθενεί σταδιακά στο άλλο.

Ακολουθεί πώς να εφαρμόσετε γέμισμα διαβάθμισης σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε μια παρουσίαση κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής gradient stop που εκτίθενται από την κλάση [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Εφαρμογή διαβαθμισμένης μορφοποίησης στην Ellipse.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Ορισμός της κατεύθυνσης του διαβάθμισης.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Προσθήκη δύο στάσεων διαβάθμισης.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η έλλειψη με γέμισμα διαβάθμισης](gradient-fill.png)

Εάν ένα gradient φαίνεται διαφορετικό σε μια εξαχθείσα εικόνα σε σχέση με το PowerPoint, δείτε [Επιλογή Στυλ Απόδοσης Διαβάθμισης](/slides/el/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε ένα στυλ απόδοσης χωρίς να αλλάξετε το γέμισμα διαβάθμισης που αποθηκεύεται στην παρουσίαση.

## **Γέμισμα Σχεδίου**

Στο PowerPoint, το Γέμισμα Σχεδίου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόζετε ένα σχέδιο δύο χρωμάτων — όπως κουκίδες, πιτόγυρα, διαγώνιες λωρίδες ή σκαλί — σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το φόντο του σχεδίου.

Το Aspose.Slides παρέχει περισσότερα από 45 προεπιλεγμένους στυλ μοτίβων που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμα και αφού επιλέξετε ένα προεπιλεγμένο μοτίβο, μπορείτε ακόμη να καθορίσετε τα ακριβή χρώματα που πρέπει να χρησιμοποιήσει.

Ακολουθεί πώς να εφαρμόσετε ένα γέμισμα μοτίβου σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε μια παρουσίαση κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ μοτίβου από τις προεπιλεγμένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) του μοτίβου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ορισμός του τύπου γεμίσματος σε Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Ορισμός του στυλ μοτίβου.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Ορισμός των χρωμάτων φόντου και προσκηνίου του μοτίβου.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμισμα μοτίβου](pattern-fill.png)

## **Γέμισμα Εικόνας**

Στο PowerPoint, το Γέμισμα Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα εντός ενός σχήματος — χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθεί πώς να χρησιμοποιήσετε το Aspose.Slides για να εφαρμόσετε γέμισμα εικόνας σε ένα σχήμα:

1. Δημιουργήστε μια παρουσίαση κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία γέμισματος εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Μεταβιβάστε την εικόνα στη μέθοδο `SlidesPicture.setImage`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

![Η εικόνα λωτού](lotus.png)

```php
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Ορισμός του τύπου γεμίσματος σε Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Ορισμός της λειτουργίας γέμισης εικόνας.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Φόρτωση εικόνας και προσθήκη της στους πόρους της παρουσίασης.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Ορισμός της εικόνας.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με γέμισμα εικόνας](picture-fill.png)

### **Πλακάκια Εικόνας Ως Υφή**

Εάν θέλετε να ορίσετε μια εικόνα σε μορφή πλακιδίων ως υφή και να προσαρμόσετε τη συμπεριφορά των πλακιδίων, μπορείτε να χρησιμοποιήσετε τις ακόλουθες μεθόδους της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Ορίζει τη λειτουργία γέμισης εικόνας — είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Καθορίζει την ευθυγράμμιση των πλακιδίων εντός του σχήματος.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Ελέγχει εάν το πλακίδιο θα αναστραφεί οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Ορίζει τη οριζόντια μετατόπιση του πλακιδίου (σε σημεία) από το σημείο εκκίνησης του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Ορίζει τη κάθετη μετατόπιση του πλακιδίου (σε σημεία) από το σημείο εκκίνησης του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Καθορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Καθορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο ακόλουθος κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με γέμισμα εικόνας σε μορφή πλακιδίων και να ρυθμίσετε τις επιλογές πλακιδίων:

```php
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Προσθήκη αυτόματου σχήματος Rectangle.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Ορισμός του τύπου γεμίσματος του σχήματος σε Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Φόρτωση της εικόνας και προσθήκη της στους πόρους της παρουσίασης.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Ανάθεση της εικόνας στο σχήμα.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Διαμόρφωση της λειτουργίας γέμισης εικόνας και των ιδιοτήτων πλακιδίων.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίου](tile-options.png)

## **Γέμισμα Σταθερού Χρώματος**

Στο PowerPoint, το Γέμισμα Σταθερού Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό φόντο εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή μοτίβα.

Για να εφαρμόσετε γέμισμα σταθερού χρώματος σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσίαση κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Αναθέστε το προτιμώμενο χρώμα γέμισης στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```php
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ορισμός του τύπου γεμίσματος σε Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Ορισμός του χρώματος γεμίσματος.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με γέμισμα σταθερού χρώματος](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε γέμισμα σταθερού χρώματος, διαβάθμισης, εικόνας ή υφής σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνειά του. Ένα υψηλότερο επίπεδο διαφάνειας κάνει το σχήμα πιο διαφανές, επιτρέποντας στο παρασκήνιο ή στα υποκείμενα αντικείμενα να φαίνονται εν μέρει.

Το Aspose.Slides σάς επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γέμισμα. Ακολουθεί η διαδικασία:

1. Δημιουργήστε μια παρουσίαση κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το συστατικό `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

```php
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθήκη αυτόματου σχήματος Rectangle με συμπαγές γέμισμα.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Προσθήκη διαφανούς αυτοσχήματος Rectangle πάνω από το συμπαγές σχήμα.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σάς επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένη ευθυγράμμιση ή απαιτήσεις σχεδίασης.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα βήματα:

1. Δημιουργήστε μια παρουσίαση κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσίαση.

```php
// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Λάβετε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Περιστροφή του σχήματος κατά 5 μοίρες.
    $shape->setRotation(5);

    // Αποθήκευση του αρχείου PPTX στο δίσκο.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη 3D Εφέ Λεπίδας**

Το Aspose.Slides σάς επιτρέπει να εφαρμόζετε 3D εφέ λεπίδας σε σχήματα διαμορφώνοντας τις ιδιότητες [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) τους.

Για να προσθέσετε 3D εφέ λεπίδας σε ένα σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε μία παρουσίαση κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Διαμορφώστε το [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις λεπίδας.
1. Αποθηκεύστε την παρουσίαση.

```php
// Δημιουργία μιας παρουσίας της κλάσης Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθήκη σχήματος στη διαφάνεια.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Ορισμός των ιδιοτήτων ThreeDFormat του σχήματος.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το 3D εφέ λεπίδας](3D-bevel-effect.png)

## **Προσθήκη 3D Εφέ Περιστροφής**

Το Aspose.Slides σάς επιτρέπει να εφαρμόζετε 3D εφέ περιστροφής σε σχήματα διαμορφώνοντας τις ιδιότητες [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) τους.

Για την εφαρμογή 3D περιστροφής σε σχήμα:

1. Δημιουργήστε μία παρουσίαση κλάσης [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τις μεθόδους [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) και [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) για να ορίσετε την 3D περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

```php
// Δημιουργία μιας παρουσίας της κλάσης Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το 3D εφέ περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Μονόχρωμης Απόδοσης για Σχήματα**

Η μέθοδος [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) καθορίζει πώς αποδίδεται ένα μεμονωμένο σχήμα όταν η παρουσίαση προβάλλεται ή επεξεργάζεται σε μονόχρωμη (μαύρο‑άσπρο) λειτουργία. Δεν ενεργοποιεί την εμφάνιση σε μαύρο‑άσπρο από μόνη της και δεν αλλάζει το γέμισμα, τη γραμμή ή άλλες μορφοποιήσεις του σχήματος σε κανονική χρωματιστή λειτουργία.

Χρησιμοποιήστε μια τιμή από την κλάση [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) για να επιλέξετε τη ζητούμενη συμπεριφορά. Για παράδειγμα, το `Automatic` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, τα `Gray` και `LightGray` χρησιμοποιούν γκρι απόχρωση, το `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, τα `Black` και `White` επιβάλλουν ένα ενιαίο χρώμα, το `Color` διατηρεί το κανονικό χρώμα, και το `Hidden` παραλείπει το σχήμα σε μονόχρωμη λειτουργία. Το `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

Ο ακόλουθος κώδικας PHP δημιουργεί ένα χρωματιστό σχήμα και το κάνει να φαίνεται γκρι σε λειτουργία μαύρο‑άσπρο:

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

    // Διατηρήστε το πορτοκαλί γέμισμα σε χρωματική λειτουργία, αλλά αποδώστε το σχήμα με γκρι χρωματισμό σε λειτουργία μαύρο-ασπρο.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Σε κανονική χρωματιστή λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμά του. Σε ροή εργασίας μαύρο‑άσπρο, χρησιμοποιεί γκρι απόχρωση επειδή η λειτουργία του έχει οριστεί σε `Gray`. Αυτό σας επιτρέπει να διατηρείτε μια πλήρη‑χρωματιστή διαφάνεια ενώ ορίζετε διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που λαμβάνουν υπόψη τις ρυθμίσεις μονόχρωμης εμφάνισης της παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Ο ακόλουθος κώδικας Java δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στη [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) στις προεπιλεγμένες τους ρυθμίσεις:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Επαναφορά του κάθε σχήματος στη διαφάνεια που έχει placeholder στην διάταξη.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Επηρεάζει η μορφοποίηση των σχημάτων το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι των σχημάτων όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν ουσιαστικά κανένα επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν τα ίδια χαρακτηριστικά μορφοποίησης ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος — τις ρυθμίσεις γέμισης, γραμμής και εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε το στυλ τους ως ταυτόσημο και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη διαχείριση στυλ αργότερα.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχημάτων σε ξεχωριστό αρχείο για να τα χρησιμοποιήσω σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε τα δείγμα σχήματα με τα επιθυμητά στυλ σε ένα πρότυπο παρουσίασης ή σε αρχείο .POTX. Όταν δημιουργείτε μια νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα σχήματα που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.