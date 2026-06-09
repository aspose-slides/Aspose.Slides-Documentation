---
title: Διαμόρφωση Σχημάτων PowerPoint σε PHP
linktitle: Διαμόρφωση Σχήματος
type: docs
weight: 20
url: /el/php-java/shape-formatting/
keywords:
- διαμόρφωση σχήματος
- διαμόρφωση γραμμής
- διαμόρφωση στυλ σύνδεσης
- συμπλήρωση διαβάθμισης
- συμπλήρωση μοτίβου
- συμπλήρωση εικόνας
- συμπλήρωση υφής
- συμπλήρωση στερεού χρώματος
- διαφάνεια σχήματος
- περιστροφή σχήματος
- εφέ 3D αποχρωμής
- εφέ 3D περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε PHP χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT, PPTX και ODP με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα σε διαφάνειες. Καθώς τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στα περίγραμμα τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζουν οι εσωτερικοί τους χώροι.

![format-shape-powerpoint](format-shape-powerpoint.png)

Το Aspose.Slides για PHP μέσω Java παρέχει κλάσεις και μεθόδους που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να καθορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/)​.
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/el/php-java/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/el/php-java/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας PHP δείχνει πώς να μορφοποιήσετε ένα ορθογώνιο `AutoShape`:

```php
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
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

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Μορφοποίηση Στυλ Συνδέσεων**

Αυτές είναι οι τρεις επιλογές τύπου σύνδεσης:

* Round
* Miter
* Bevel

Από προεπιλογή, όταν το PowerPoint συνδέει δύο γραμμές σε γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Round**. Ωστόσο, εάν σχεδιάζετε σχήμα με έντονες γωνίες, μπορεί να προτιμήσετε την επιλογή **Miter**.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Ο παρακάτω κώδικας PHP δείχνει πώς δημιουργήθηκαν τρία ορθογώνια (όπως φαίνεται στην παραπάνω εικόνα) χρησιμοποιώντας τις ρυθμίσεις τύπου σύνδεσης Miter, Bevel και Round:

```php
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
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

    // Ορίστε το χρώμα για τη γραμμή κάθε rectangle.
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

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Γραμμική Συμπλήρωση (Gradient Fill)**

Στο PowerPoint, η Γραμμική Συμπλήρωση είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα συνεχές μείγμα χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τρόπο που το ένα εξασθενίζει σταδιακά στο άλλο.

Ακολουθεί η διαδικασία για την εφαρμογή γραμμικής συμπλήρωσης σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/)​.
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `add` της συλλογής σημείων διαβάθμισης που εκτίθεται από την κλάση [GradientFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/gradientformat/)​.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας PHP δείχνει πώς να εφαρμόσετε το εφέ γραμμικής συμπλήρωσης σε μια έλλειψη:

```php
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Εφαρμόστε μορφοποίηση διαβάθμισης στην έλλειψη.
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

![Η έλλειψη με γραμμική συμπλήρωση](gradient-fill.png)

## **Συμπλήρωση Μοτίβου (Pattern Fill)**

Στο PowerPoint, η Συμπλήρωση Μοτίβου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχέδιο δύο χρωμάτων—όπως κουκκίδες, λωρίδες, διαγώνιες γραμμές ή σκαλοπάτια—σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το παρασκήνιο του μοτίβου.

Το Aspose.Slides παρέχει πάνω από 45 προ‑ορισμένα στυλ μοτίβου που μπορείτε να εφαρμόσετε σε σχήματα για να βελτιώσετε την οπτική εμφάνιση των παρουσιάσεων σας. Ακόμη και μετά την επιλογή ενός προ‑ορισμένου μοτίβου, μπορείτε να ορίσετε ακριβώς τα χρώματα που θα χρησιμοποιηθούν.

Ακολουθεί η διαδικασία για την εφαρμογή συμπλήρωσης μοτίβου σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/)​.
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ μοτίβου από τις προ‑ορισμένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/el/php-java/aspose.slides/patternformat/#getBackColor) του μοτίβου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/el/php-java/aspose.slides/patternformat/#getForeColor) του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας PHP δείχνει πώς να εφαρμόσετε συμπλήρωση μοτίβου σε ένα ορθογώνιο:

```php
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Ορίστε το στυλ μοτίβου.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Ορίστε τα χρώματα φόντου και προσκηνίου του μοτίβου.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με συμπλήρωση μοτίβου](pattern-fill.png)

## **Συμπλήρωση Εικόνας (Picture Fill)**

Στο PowerPoint, η Συμπλήρωση Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα μέσα σε ένα σχήμα—χρησιμοποιώντας ουσιαστικά την εικόνα ως παρασκήνιο του σχήματος.

Ακολουθεί η διαδικασία για την εφαρμογή συμπλήρωσης εικόνας σε σχήμα με το Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/)​.
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία συμπλήρωσης εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Περάστε την εικόνα στη μέθοδο `SlidesPicture.setImage`.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ας υποθέσουμε ότι διαθέτουμε το αρχείο «lotus.png» με την παρακάτω εικόνα:

![Η εικόνα lotus](lotus.png)

Ο παρακάτω κώδικας PHP δείχνει πώς να γεμίσετε ένα σχήμα με την εικόνα:

```php
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Ορίστε τον τύπο γεμίσματος σε Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Ορίστε τη λειτουργία συμπλήρωσης εικόνας.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Φορτώστε μια εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Ορίστε την εικόνα.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με συμπλήρωση εικόνας](picture-fill.png)

### **Εικόνα Πλακιδίου Ως Υφή**

Εάν θέλετε να ορίσετε μια πλακιδική εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά της τοποθέτησης, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/)​:

- [setPictureFillMode](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Ορίζει τη λειτουργία συμπλήρωσης εικόνας—είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#setTileAlignment): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#setTileFlip): Ελέγχει αν το πλακίδιο θα αντιστραφεί οριζόντια, κατακόρυφα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Ορίζει τη οριζόντια μετατόπιση του πλακιδίου (σε points) από την αρχή του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Ορίζει τη κάθετη μετατόπιση του πλακιδίου (σε points) από την αρχή του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#setTileScaleX): Καθορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/el/php-java/aspose.slides/picturefillformat/#setTileScaleY): Καθορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με πλακιδική συμπλήρωση εικόνας και να ρυθμίσετε τις επιλογές πλακιδίων:

```php
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
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

    // Ρυθμίστε τη λειτουργία συμπλήρωσης εικόνας και τις ιδιότητες τοποθέτησης πλακιδίων.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίων](tile-options.png)

## **Συμπλήρωση Στερεού Χρώματος (Solid Color Fill)**

Στο PowerPoint, η Συμπλήρωση Στερεού Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα μόνο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς γραμμικές διαβαθμίσεις, υφές ή μοτίβα.

Για να εφαρμόσετε συμπλήρωση στερεού χρώματος σε σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/)​.
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Αναθέστε το προτιμώμενο χρώμα γεμίσματος στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας PHP δείχνει πώς να εφαρμόσετε συμπλήρωση στερεού χρώματος σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

```php
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Ορίστε το χρώμα γεμίσματος.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με στερεό χρώμα γεμίσματος](solid-color-fill.png)

## **Ορισμός Διαφάνειας (Set Transparency)**

Στο PowerPoint, όταν εφαρμόζετε γεμίσμα στερεού χρώματος, γραμμικής διαβάθμισης, εικόνας ή υφής σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε τη διαφάνειά του. Μια υψηλότερη τιμή διαφάνειας κάνει το σχήμα πιο διαυγές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να διακρίνονται εν μέρει.

Το Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γεμίσμα. Δείτε πώς:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/)​.
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε το `Color` για να ορίσετε ένα χρώμα με διαφάνεια (το συστατικό `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας PHP δείχνει πώς να εφαρμόσετε χρώμα γεμίσματος με διαφάνεια σε ένα ορθογώνιο:

```php
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα ορθογωνίου στερεού γεμίσματος.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Προσθέστε ένα διαφανές αυτόματο σχήμα ορθογωνίου πάνω από το στερεό σχήμα.
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

## **Περιστροφή Σχημάτων (Rotate Shapes)**

Το Aspose.Slides σας επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να αποδειχθεί χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένες ευθυγραμμίσεις ή απαιτήσεις σχεδίασης.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/)​.
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα περιστροφής του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας PHP δείχνει πώς να περιστρέψετε ένα σχήμα κατά 5 μοίρες:

```php
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
$presentation = new Presentation();
try {
    // Αποκτήστε την πρώτη διαφάνεια.
    $slide = $presentation->getSlides()->get_Item(0);

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Περιστρέψτε το σχήμα κατά 5 μοίρες.
    $shape->setRotation(5);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη 3D Αποχρώσεων (Add 3D Bevel Effects)**

Το Aspose.Slides σας επιτρέπει να εφαρμόσετε 3D αποχρώσεις σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/)​.

Για να προσθέσετε 3D αποχρώσεις σε σχήμα, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/)​.
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Ρυθμίστε το [ThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις αποχρώσεων.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας PHP δείχνει πώς να εφαρμόσετε 3D αποχρώσεις σε σχήμα:

```php
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
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

![Το εφέ 3D αποχρώσεων](3D-bevel-effect.png)

## **Προσθήκη 3D Εφέ Περιστροφής (Add 3D Rotation Effects)**

Το Aspose.Slides σας επιτρέπει να εφαρμόσετε 3D εφέ περιστροφής σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/threedformat/)​.

Για να εφαρμόσετε 3D περιστροφή σε σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/)​.
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) στη διαφάνεια.
1. Χρησιμοποιήστε τις μεθόδους [setCameraType](https://reference.aspose.com/slides/el/php-java/aspose.slides/camera/#setCameraType) και [setLightType](https://reference.aspose.com/slides/el/php-java/aspose.slides/lightrig/#setLightType) για να ορίσετε την 3D περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας PHP δείχνει πώς να εφαρμόσετε 3D εφέ περιστροφής σε σχήμα:

```php
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
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

![Το εφέ 3D περιστροφής](3D-rotation-effect.png)

## **Επαναφορά Μορφοποίησης (Reset Formatting)**

Ο παρακάτω κώδικας Java δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στο [LayoutSlide](https://reference.aspose.com/slides/el/php-java/aspose.slides/layoutslide/)​ στις προεπιλεγμένες ρυθμίσεις τους:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Επαναφορά κάθε σχήματος στην διαφάνεια που έχει placeholder στη διάταξη.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Συχνές Ερωτήσεις (FAQ)**

**Επηρεάζει η μορφοποίηση σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν ουσιαστικά επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος—συμπλήρωση, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε τα στυλ ως ταυτόσημα και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο παρουσίασης ή σε αρχείο .POTX. Όταν δημιουργείτε μια νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλσχημάτων που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίηση όπου απαιτείται.