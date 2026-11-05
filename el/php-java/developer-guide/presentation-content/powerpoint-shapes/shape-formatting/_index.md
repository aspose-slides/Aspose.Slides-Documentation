---
title: Διαμόρφωση Σχημάτων PowerPoint σε PHP
linktitle: Διαμόρφωση Σχήματος
type: docs
weight: 20
url: /el/php-java/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σχεδίου
- γραμμή σχήματος σχεδίου
- μορφοποίηση στυλ σύνδεσης
- γέμισμα διαβάθμισης
- γέμισμα μοτίβου
- γέμισμα εικόνας
- γέμισμα υφής
- γέμισμα μονής χρώματος
- διαφάνεια σχήματος
- απεικόνιση σχήματος ασπρόμαυρο
- απεικόνιση σχήματος σε γκρι κλίμακα
- περιστροφή σχήματος
- εφέ λοξόκολου 3Δ
- εφέ περιστροφής 3Δ
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε PHP χρησιμοποιώντας το Aspose.Slides—ορίστε γέμισμα, γραμμή και στυλ εφέ για αρχεία PPT και PPTX με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Διαμορφώστε σχήματα στο PowerPoint τροποποιώντας τα περιγράμματά τους, τις γεμίσεις και τα εφέ. Το Aspose.Slides for PHP μέσω Java σας επιτρέπει να ελέγχετε αυτές τις ρυθμίσεις προγραμματιστικά, συμπεριλαμβανομένης της διαφάνειας, της περιστροφής και της τρισδιάστατης μορφοποίησης.

![Επιλογές μορφοποίησης σχήματος στο PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides for PHP μέσω Java παρέχει κλάσεις και μεθόδους που σας επιτρέπουν να μορφοποιείτε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιήστε [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) για να ελέγξετε το περίγραμμα ενός σχήματος. Αυτό το παράδειγμα δημιουργεί ένα άκυκλο ορθογώνιο με μπλε, διακεκομμένο περίγραμμα. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) επιλέγει ένα σύνθετο γραμμή παχύ‑λέπια, ενώ [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) ορίζει το πλάτος του σε 7 μονάδες και [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) επιλέγει το μοτίβο γραμμής.

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

### **Ορισμός Προσαρμοσμένων Μοτίβων Διακεκομμένων Γραμμών**

Χρησιμοποιήστε [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) όταν οι προεπιλεγμένα στυλ γραμμής δεν παρέχουν τα μήκη και τα κενά που χρειάζεστε, για παράδειγμα για εμπορικά περιγράμματα ή τεχνικά διαγράμματα. Η ανάθεση ενός μοτίβου αλλάζει αυτόματα το στυλ διακεκομμένης γραμμής σε [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/).

Οι καταχωρίσεις του πίνακα εναλλάσσονται μεταξύ μήκους γραμμής και κενών, ξεκινώντας με γραμμή. Κάθε τιμή είναι πολλαπλάσιο του πλάτους της γραμμής: `[4, 2]` σε πλάτος 3 μονάδων παράγει γραμμή 12 μονάδων ακολουθούμενη από κενό 6 μονάδων. Χρησιμοποιήστε ζεύγη πεπερασμένων, μη αρνητικών τιμών για να ορίσετε πλήρη τμήματα γραμμής‑κενό. Το παράδειγμα χρησιμοποιεί θετικές τιμές ώστε κάθε γραμμή και κενό να είναι ορατά.

Αυτό το παράδειγμα δημιουργεί πέντε μπλε γραμμές με το ίδιο μήκος και επίπεδα άκρα. Οι πρώτες τρεις συγκρίνουν μοτίβα σε πλάτος 3 μονάδων. Η τέταρτη επαναλαμβάνει το πρώτο μοτίβο στο διπλάσιο του πλάτους, διπλασιάζοντας τόσο το μήκος της γραμμής όσο και του κενού. Η πέμπτη μεταβαίνει από προσαρμοσμένο μοτίβο σε στερεή γραμμή.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // Επιστρέψτε την τελευταία γραμμή σε στερεό στυλ.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Για να επιστρέψετε σε προεπιλεγμένο στυλ διακεκομμένης γραμμής, περάστε το [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) στη [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle). Το επιλεγμένο στυλ ελέγχει την εμφάνιση της γραμμής.

Το αποτέλεσμα στο PowerPoint, από πάνω προς τα κάτω: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; και **Solid, 3 pt**.

![Τρία προσαρμοσμένα μοτίβα διακεκομμένων, μια πιο πλατιά γραμμή που χρησιμοποιεί το πρώτο μοτίβο, και μια στερεή γραμμή στο PowerPoint](custom-dash-patterns.png)

### **Ορισμός Άκρων Γραμμής**

Χρησιμοποιήστε [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) για να ορίσετε τα άκρα μιας ανοιχτής γραμμής. Η κλάση [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) παρέχει τρία ρητά στυλ άκρων:

- `Flat`: Η γραμμή σταματά στο άκρο.
- `Round`: Ένα ημικυκλικό άκρο εκτείνεται πέρα από το άκρο κατά το ήμισε του πλάτους της γραμμής.
- `Square`: Ένα τετράγωνο άκρο εκτείνεται πέρα από το άκρο κατά το ήμισε του πλάτους της γραμμής.

Η κλάση περιλαμβάνει επίσης το `NotDefined`, που σημαίνει ότι δεν έχει οριστεί ρητά κάποιο στυλ άκρου.

Τα άκρα διαφέρουν από τα βέλη, που προσθέτουν σύμβολα στα άκρα της γραμμής, και από τις ενώσεις, που ελέγχουν τις γωνίες μεταξύ τμημάτων γραμμής. Αυτό το παράδειγμα απενεργοποιεί τα βελάκια μέσω των [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) και [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) ώστε να συγκριθούν μόνο τα σχήματα άκρων.

Το ακόλουθο παράδειγμα δημιουργεί τρεις παρόμοιες οριζόντιες γραμμές, 20 μονάδες πλάτος. Από πάνω προς τα κάτω, χρησιμοποιούν επίπεδα, στρογγυλεμένα και τετράγωνα άκρα. Τα άκρα τους έχουν τις ίδιες οριζόντιες συντεταγμένες· τα στρογγυλεμένα και τετράγωνα άκρα εκτείνεται 10 μονάδες πέρα από κάθε άκρο.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα στο PowerPoint, από πάνω προς τα κάτω: **Flat**, **Round**, και **Square**.

![Flat, round, and square caps on identical thick lines in PowerPoint](line-caps.png)

## **Εφαρμογή Εφέ Σχεδίου σε Γραμμές Σχήματος**

Ένα εφέ σχεδίου κάνει τη γραμμή σχήματος να φαίνεται χειροποίητη. Χρησιμοποιήστε [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) για να αποκτήσετε πρόσβαση στις ρυθμίσεις γραμμής, [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) για τις ρυθμίσεις σχεδίου, και [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) για να επιλέξετε μια τιμή από την κλάση [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας PHP δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/), να διαβάσετε τη ρητά ανατεθειμένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Η τιμή που επιστρέφει το [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) αντιπροσωπεύει τη ρύθμιση που έχει ανατεθεί άμεσα στο σχήμα. Εάν η μορφοποίηση γραμμής μπορεί να κληθεί από θέμα, κύρια διαφάνεια ή διάταξη, χρησιμοποιήστε το [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective), αποκτήστε το αντικείμενο `getSketchFormat` και διαβάστε τη τιμή `getSketchType`. Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται μετά την επίλυση της κληρονομικότητας. Το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με τουλάχιστον ένα σχήμα στην πρώτη διαφάνεια και εκτυπώνει και τις δύο τιμές:

```php
use aspose\slides\Presentation;

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

* Round
* Miter
* Bevel

Το στυλ σύνδεσης ελέγχει πώς δύο τμήματα περιγράμματος συναντώνται σε μια γωνία. Χρησιμοποιήστε **Round** για στρογγυλεμένες γωνίες, **Miter** για οξείες γωνίες ή **Bevel** για επίπεδες γωνίες.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Το παράδειγμα δημιουργεί τρία μαύρα ορθογώνια με μπλε περιγράμματα 15 μονάδων πλάτος. Ορίζει το [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) στις τιμές miter, bevel και round της κλάσης [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/), αντίστοιχα, για να συγκρίνει πώς σχεδιάζονται οι γωνίες.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Περιορισμός Συνδέσεων Miter σε Οξέες Γωνίες**

Χρησιμοποιήστε το [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) μαζί με το [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) ορισμένο σε [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) για να περιορίσετε το πόσο πολύ μπορεί να εκτείνεται μια οξεία γωνία.

Το όριο είναι ένας λόγος της απόστασης μεταξύ των εσωτερικών και εξωτερικών γωνιών της σύνδεσης προς το πλάτος της γραμμής. Για παράδειγμα, τιμή `8` επιτρέπει μήκος miter μέχρι οκτώ φορές το πλάτος της γραμμής· δεν είναι μέτρηση σε μονάδες. Εάν η γωνία υπερβαίνει το όριο, το PowerPoint χρησιμοποιεί λοξόκολο στην εν λόγω γωνία. Μεγαλύτερο όριο δίνει πιο οξείς άκρες. Η ρύθμιση επηρεάζει μόνο τις συνδέσεις miter και δεν έχει ορατό αποτέλεσμα όταν η γωνία παραμένει εντός των ορίων.

Το παράδειγμα δημιουργεί δύο ταυτόσημα, άκυκλα τρίγωνα με περιγράμματα 20 μονάδων πλάτος. Το αριστερό τρίγωνο χρησιμοποιεί όριο `2`, το δεξί `8`. Κάθε τρίγωνο έχει πλάτος 80 μονάδες και ύψος 160 μονάδων, δίνοντας στην άνω γωνία λόγο περίπου `4.12`. Συνεπώς, το PowerPoint λοξοκοπεί το αριστερό άκρο και διατηρεί το δεξί.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα στο PowerPoint: **Miter limit 2** στα αριστερά και **miter limit 8** στα δεξιά.

![A beveled apex with miter limit 2 and a pointed apex with miter limit 8 in PowerPoint](miter-limits.png)

## **Γέμισμα Διαβάθμισης**

Ένα γέμισμα διαβάθμισης αναμειγνύει χρώματα σε όλο το σχήμα. Αυτό το παράδειγμα γεμίζει ένα έλλειψη με γραμμική διαβάθμιση 45 μοιρών από το κόκκινο στο μωβ χρησιμοποιώντας το [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat). Η μέθοδος [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) τοποθετεί τα χρώματα στα 0 και 1, την αρχή και το τέλος της διαβάθμισης. Η εκκαθάριση των υπαρχουσών στάσεων εξασφαλίζει ότι χρησιμοποιούνται μόνο αυτά τα δύο χρώματα.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το έλλειψη με γέμισμα διαβάθμισης](gradient-fill.png)

Εάν μια διαβάθμιση φαίνεται διαφορετική σε εξαγόμενο εικόνα από ό,τι στο PowerPoint, δείτε [Choose a Gradient Rendering Style](/slides/el/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε στυλ απόδοσης χωρίς να αλλάξετε τη διαβάθμιση αποθηκευμένη στην παρουσίαση.

### **Ορισμός Γωνίας Γραμμικού Διαβάθμισης**

Χρησιμοποιήστε [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) για να ελέγξετε τον προσανατολισμό μιας γέμισης [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/). Η γωνία μετράται σε μοίρες και αυξάνεται δεξιόστροφα: `0` τρέχει από αριστερά προς δεξιά, `90` από πάνω προς τα κάτω, `180` από δεξιά προς αριστερά, και `270` από κάτω προς πάνω. Υποστηρίζονται κλασματικές γωνίες. Οι γωνίες εκτός του εύρος `[0, 360)` κανονικοποιούνται σε μία πλήρη περιστροφή· για παράδειγμα, `-45` γίνεται `315` και `360` γίνεται `0`.

Το παράδειγμα δημιουργεί έξι ορθογώνια με τα ίδια κόκκινα, πράσινα και μπλε στάσεις στις θέσεις `0`, `0.5`, και `1`. Η κλιμάκωση είναι απενεργοποιημένη ώστε η γωνία να συγκρίνεται ανεξάρτητα από τις propor tions των ορθογωνίων. Οι γωνίες, από αριστερά προς δεξιά, είναι `0`, `45`, και `90` στην πρώτη σειρά, και `135`, `180`, και `270` στη δεύτερη σειρά.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα στο PowerPoint:

![Linear gradients at 0, 45, and 90 degrees in the top row, and 135, 180, and 270 degrees in the bottom row](linear-gradient-angles.png)

### **Κλιμάκωση Γραμμικής Διαβάθμισης με το Σχήμα**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) δέχεται μια τιμή [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/). Ορίστε την ρητά σε `False` για να διατηρήσετε τη γεωμετρική γωνία διαβάθμισης όταν οι αναλογίες του σχήματος αλλάζουν, ή σε `True` για να κλιμακώσετε τη διαβάθμιση με το πλάτος και το ύψος του σχήματος. Με την κλιμάκωση ενεργοποιημένη, η ορατή γωνία μπορεί να διαφέρει από την ανατεθειμένη γωνία σε σχήμα που δεν είναι τετράγωνο.

Το παρακάτω παράδειγμα χρησιμοποιεί γωνία `45` μοιρών και τις ίδιες στάσεις χρώματος όπως στην σύγκριση γωνιών. Η αριστερή στήλη χρησιμοποιεί `False`; η δεξιά `True`. Κάθε στήλη περιλαμβάνει ένα πλατύ ορθογώνιο πάνω από ένα ψηλό ορθογώνιο. Και οι δύο ξεκινούν με τις ίδιες πλατιές διαστάσεις· η αλλαγή του πλάτους και του ύψους του δεύτερου ορθογωνίου δείχνει πώς η γέμιση αντιδρά στην αλλαγή μεγέθους χωρίς να αλλάζει τις ρυθμίσεις διαβάθμισης.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα στο PowerPoint, με την κλιμάκωση απενεργοποιημένη στα αριστερά και ενεργοποιημένη στα δεξιά:

![Wide and tall rectangles with a 45-degree gradient, comparing LinearGradientScaled False on the left with True on the right](linear-gradient-scaling.png)

Με την κλιμάκωση απενεργοποιημένη, οι διαγώνιες λωρίδες χρώματος διατηρούν τον ίδιο προσανατολισμό και στα δύο ορθογώνια. Με την κλιμάκωση ενεργοποιημένη, οι λωρίδες τεντώνονται με τις αναλογίες του σχήματος. Αυτό βοηθά στην αναπαραγωγή μιας διαβάθμισης προτύπου όταν προσαρμόζουμε το σχήμα σε διαφορετικό μέγεθος. Σε τετράγωνο σχήμα, η ενεργοποίηση της κλιμάκωσης δεν αλλάζει την εμφάνιση της διαβάθμισης `45` μοιρών.

Τanto η γωνία όσο και η κλιμάκωση ισχύουν για γραμμικές διαβάθμισες. Δεν ελέγχουν τις γέμισης [GradientShape::Radial or GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/).

### **Συνδυασμός Γωνίας με Κατεύθυνση Διαβάθμισης**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) επιλέγει στυλ διαβάθμισης από την κλάση [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/); δεν αντικαθιστά μια αριθμητική γωνία. Για μια γραμμική διαβάθμιση, τα στυλ γωνίας μπορούν να αλλάξουν την περιοχή όπου διανέμονται τα χρώματα χωρίς να αλλάζουν τη γωνία που έχει οριστεί μέσω του [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle). Κρατήστε την κατεύθυνση αμετάβλητη όταν συγκρίνετε γωνίες ή κλιμάκωση.

Το παρακάτω παράδειγμα εφαρμόζει τις ίδιες ρυθμίσεις με αντίστροφη σειρά. Τα δύο ορθογώνια έχουν την ίδια εμφάνιση: η ανάθεση της κατεύθυνσης πριν ή μετά τη γωνία δεν αλλάζει το αποτέλεσμα.

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Γέμισμα Μοτίβου**

Ένα γέμισμα μοτίβου εφαρμόζει ένα σχέδιο δύο χρωμάτων, όπως κουκίδες, λωρίδες ή σκαλοπάτια. Αυτό το παράδειγμα χρησιμοποιεί το [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) για να επιλέξει ένα μοτίβο πλέγματος. Το [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) παρέχει το ανοιχτό γκρι φόντο, και το [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) παρέχει το κίτρινο χρώμα του μοτίβου.

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμισμα μοτίβου](pattern-fill.png)

## **Γέμισμα Εικόνας**

Ένα γέμισμα εικόνας χρησιμοποιεί μια εικόνα μέσα σε σχήμα. Αυτό το παράδειγμα απαιτεί τοπική εικόνα και χρησιμοποιεί το [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) για να τη φορτώσει στη συλλογή εικόνων της παρουσίασης. Ορίζοντας το [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) στη λειτουργία πλακίδων, η εικόνα επαναλαμβάνεται μέσα στο ορθογώνιο. Η πηγή εικόνας που χρησιμοποιείται παρακάτω φαίνεται παρακάτω:

![Η εικόνα λωτού](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με γέμισμα εικόνας](picture-fill.png)

### **Τοποθέτηση Εικόνας σε Υφή Πλακίδιων**

Εάν θέλετε να ορίσετε μια εικόνα σε υφή πλακίδων και να προσαρμόσετε τη συμπεριφορά της επικάλυψης, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Ορίζει τη λειτουργία γέμισματος εικόνας — είτε `Tile` είτε `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Ελέγχει εάν το πλακίδιο θα αναστραφεί οριζόντια, κάθετα ή και τα δύο.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε μονάδες) από το σημείο αναφοράς του σχήματος.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε μονάδες) από το σημείο αναφοράς του σχήματος.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Αυτό το παράδειγμα απαιτεί τοπική εικόνα και ρυθμίζει το [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) ώστε να την επαναλάβει στο 50 % του αρχικού μεγέθους. Μετατοπίσεις `−32` μονάδων μετατοπίζουν τα πλακίδια οριζόντια και κάθετα· η στοίχιση κάτω‑δεξιά και η αναστροφή και στις δύο κατευθύνσεις καθορίζουν πώς θα διαταχθεί η επαναλαμβανόμενη υφή.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίων](tile-options.png)

## **Γέμισμα Μονής Χρώματος**

Ένα γέμισμα μονής χρώματος δίνει στο σχήμα ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το παράδειγμα ορίζει το [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) στη λειτουργία γεμίσματος μονής χρώματος και αντιστοιχίζει το κίτρινο μέσω του [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor), μετά αποθηκεύει το ορθογώνιο στην παρουσίαση.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το σχήμα με γέμισμα μονής χρώματος](solid-color-fill.png)

### **Αντιγραφή Χρωμάτων Διατηρώντας Αναφορές Θέματος**

Χρησιμοποιήστε το [ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom) για να αντιγράψετε έναν ορισμό χρώματος, συμπεριλαμβανομένου του τύπου χρώματος, της αναφοράς θέματος και των μετασχηματισμών. Αυτό είναι χρήσιμο όταν μεταφέρετε ένα χρώμα γεμίσματος μεταξύ σχημάτων που πρέπει να συνεχίσουν να ακολουθούν το θέμα της παρουσίασης. Η μέθοδος αντιγράφει μόνο το χρώμα: δεν αντιγράφει τον τύπο γεμίσματος, το περίγραμμα ή άλλες μορφοποιήσεις σχήματος. Ορίστε ρητά τον τύπο γεμίσματος του προορισμού με το [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType).

Το παράδειγμα δημιουργεί τρία ορθογώνια, από αριστερά προς δεξιά: την πηγή, ένα αντίγραφο που λαμβάνει υπόψη το θέμα, και ένα σταθερό αντίγραφο RGB. Η πηγή χρησιμοποιεί το [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor) για να αναφερθεί στο πρώτο χρώμα έμφασης και προσθέτει απόχρωση μέσω του [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add). Το αντίγραφο RGB χρησιμοποιεί το αποτελεσματικό χρώμα γεμίσματος της πηγής ώστε τα τρία αρχικά να φαίνονται τα ίδια. Καλώντας το [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) ορίζεται μια σταθερή τιμή RGB και αφαιρούνται τυχόν υπάρχουσες μετατροπές χρώματος.

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // Οι αναφορές θέματος ακολουθούν το νέο χρώμα έμφασης· η σταθερή τιμή RGB δεν το κάνει.
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Πριν την αλλαγή θέματος, όλα τα τρία γέμισματα ταιριάζουν:

![Πηγή, copyFrom προορισμός, και σταθερός RGB προορισμός με ταυτοτικά μπλε γέμισματα](color-copy-before.png)

Μετά την αλλαγή θέματος, η πηγή και το αντίγραφο που λαμβάνει υπόψη το θέμα ακολουθούν το νέο χρώμα έμφασης και διατηρούν την απόχρωση τους. Το σταθερό αντίγραφο RGB παραμένει μπλε:

![Πηγή και copyFrom προορισμός με πορτοκαλί γέμισμα, ενώ ο σταθερός RGB προορισμός παραμένει μπλε](color-copy-after.png)

Ο αντίγραφος ορισμός είναι ανεξάρτητος από την πηγή. Η επακόλουθη αλλαγή της αναφοράς θέματος της πηγής, η ανάθεση άλλου χρώματος ή η προσθήκη/αφαίρεση των μετασχηματισμών δεν αλλάζει τον προορισμό. Μια αλλαγή θέματος εξακολουθεί να επηρεάζει και τα δύο σχήματα επειδή κάθε ένα αναφέρεται ανεξάρτητα στο ίδιο χρώμα θέματος.

Η αποθήκευση και επανέναρξη του PPTX διατηρεί τον τύπο του αντιγραμμένου χρώματος που επιστρέφεται από το [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType), την αναφορά θέματος και τη συλλογή μετασχηματισμών που επιστρέφεται από το [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform); δεν επίπεδωση το ορισμό σε RGB.

Κατά την αντιγραφή μεταξύ διαφορετικών πλαισίων θέματος, όπως παρουσιάσεις με διαφορετικές παλέτες έμφασης, η αντιγραμμένη αναφορά επιλύεται έναντι του θέματος του προορισμού. Η ίδια αναφορά και οι μετασχηματισμοί μπορούν επομένως να παράγουν διαφορετικό ορατό χρώμα. Δείτε την [Θέμα Παρουσίασης](/slides/el/php-java/presentation-theme/) για περισσότερα σχετικά με τη ρύθμιση χρωμάτων θέματος.

## **Χρήση Φόντου Διαφάνειας της Διαφάνειας ως Γέμισμα Σχήματος**

Χρησιμοποιήστε το [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) όταν ένα σχήμα πρέπει να ταιριάζει με το φόντο της διαφάνειας, για παράδειγμα σε πρότυπο παρουσίασης. Ορίστε τον τύπο γεμίσματος με το [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) στο [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) πρώτα για να αφαιρέσετε τυχόν ρητό γέμισμα. Με αυτόν τον συνδυασμό, το σχήμα χρησιμοποιεί το φόντο της διαφάνειας αντί για το δικό του γέμισμα. Η ενεργοποίηση του σημαδιού από μόνη της δεν αφαιρεί υπάρχον ρητό γέμισμα.

Αυτό διαφέρει από το [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/): το γέμισμα φόντου καλύπτει αντικείμενα πίσω από το σχήμα με την αντίστοιχη περιοχή του φόντου της διαφάνειας, ενώ το NoFill αφήνει αυτά τα αντικείμενα ορατά. Μια διαβάθμιση παραμένει ευθυγραμμισμένη με τη διαφάνεια αντί να επανεκκινείται μέσα σε κάθε σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα κύριο φόντο που κληρονομείται από τη διαφάνεια και τοποθετεί μια ματζέντα λωρίδα πίσω από τρία ορθογώνια. Το αριστερό ορθογώνιο χρησιμοποιεί το φόντο, το μεσαίο δεν έχει γέμισμα, και το δεξιό εναλλάσσει από γέμισμα φόντου σε ρητό πορτοκαλί γέμισμα.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // Κληρονόμηση της διαβάθμισης από το master.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // Προσθέστε αυτό το αντικείμενο πρώτο ώστε να εμφανίζεται πίσω από τα ορθογώνια.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // Απενεργοποιήστε το γέμισμα φόντου πριν εφαρμόσετε ένα ρητό γέμισμα.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα, από αριστερά προς δεξιά: **background fill**, **no fill**, και **explicit fill**. Η ματζέντα λωρίδα κρύβεται από τα αριστερά και δεξιά ορθογώνια αλλά παραμένει ορατή μέσω του μεσαίου ορθογωνίου.

![Background fill, no fill, and explicit orange fill over a magenta band](background-fill.png)

Η ίδια συμπεριφορά ισχύει για φόντο που ορίζεται απευθείας στη διαφάνεια ή κληρονομείται από διάταξη. Το σχήμα χρησιμοποιεί το επιλυμένο φόντο της διαφάνειας· το παράδειγμα αφήνει τα φόντα της διαφάνειας και της διάταξης αορισμένα ώστε το κύριο να το παρέχει.

## **Ορισμός Διαφάνειας**

Για ένα στερεό γέμισμα, το συστατικό άλφα του χρώματος ελέγχει την αδιαφάνεια: 0 είναι πλήρως διαφανές και 255 πλήρως αδιαφανές. Αυτό το παράδειγμα χρησιμοποιεί τιμή άλφα 128 για ένα κίτρινο ορθογώνιο, καθιστώντας το περίπου 50 % διαφανές ώστε το ορθογώνιο από κάτω να παραμένει ορατό. Το χρώμα ανατίθεται μέσω του [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor).

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Χρησιμοποιήστε το [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) για να περιστρέψετε ένα σχήμα στο επίπεδο της διαφάνειας. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα περιστρέφει ένα ορθογώνιο 5 μοίρες δεξιόστροφα και αποθηκεύει την παρουσίαση.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη Εφέ Λοξόκολου 3Δ**

Χρησιμοποιήστε το [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) για να δώσετε βάθος και λοξόκολες ακμές σε σχήμα. Αυτό το παράδειγμα δημιουργεί μια πράσινη έλλειψη με πορτοκαλί περίγραμμα, ορίζει το [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) σε 4 μονάδες και εφαρμόζει λοξόκολο πάνω με πλάτος και ύψος 6 μονάδες μέσω του [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop). Μια κάμερα ορθογραφική που κοιτάζει προς τα εμπρός και φωτισμός τριών σημείων κάνουν το λοξόκολο ορατό.

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![The 3D bevel effect](3D-bevel-effect.png)

## **Προσθήκη Εφέ 3Δ Περιστροφής**

Η 3Δ άποψη ενός σχήματος ελέγχεται από τις ρυθμίσεις κάμερας. Αυτό το παράδειγμα χρησιμοποιεί το [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) με γωνίες γεωγραφικού πλάτους, μήκους και επανάληψης 40, 35 και 20 μοιρών αντίστοιχα. Επιλέγει ισομετρική κάμερα μέσω του [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) και ισορροπημένο φωτισμό μέσω του [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType), μετά αποθηκεύει το μορφοποιημένο ορθογώνιο.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το αποτέλεσμα:

![The 3D rotation effect](3D-rotation-effect.png)

## **Έλεγχος Μετατροπής Μαύρο‑Άσπρο για Σχήματα**

Η μέθοδος [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) καθορίζει πώς ένα μεμονωμένο σχήμα αποδίδεται όταν μια παρουσίαση προβλέπεται ή υποβάλλεται σε λειτουργία μαύρο‑ασπρό. Δεν ενεργοποιεί από μόνη της την εμφάνιση μαύρο‑ασπρό και δεν αλλάζει το γέμισμα, το περίγραμμα ή άλλες μορφοποιήσεις σε κανονική χρωματική λειτουργία.

Χρησιμοποιήστε μια τιμή από την κλάση [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) για να επιλέξετε την επιθυμητή συμπεριφορά. Για παράδειγμα, `Automatic` αφήνει την εφαρμογή απόφασης μετατροπής, `Gray` και `LightGray` χρησιμοποιούν γκρι χρώματα, `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, `Black` και `White` εξαναγκάζουν ένα χρώμα, `Color` διατηρεί το κανονικό χρώμα, και `Hidden` παραλείπει το σχήμα σε λειτουργία μαύρο‑ασπρό. `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

Αυτό το παράδειγμα δημιουργεί ένα πορτοκαλί ορθογώνιο και ορίζει το [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) σε γκρι. Το αποθηκευμένο σχήμα διατηρεί το πορτοκαλί γέμισμα στην κανονική χρωματική προβολή και ζητά γκρι χρώμα από εφαρμογές που σέβονται τις ρυθμίσεις εμφάνισης μαύρο‑ασπρό.

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
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Σε κανονική χρωματική λειτουργία, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμα. Σε ροή εργασίας με εμφάνιση μαύρο‑ασπρό, χρησιμοποιεί γκρι χρώμα επειδή η λειτουργία του έχει οριστεί σε `Gray`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρως χρωματιστή διαφάνεια ενώ ορίζετε διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις εμφάνισης μαύρο‑ασπρό της παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Χρησιμοποιήστε το [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) για να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση των δεσμευτικών σημειωμάτων διαφάνειας από τα αντίστοιχα δεσμευτικά σημειώματα διάταξης. Αυτό το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με δεσμευτικά σημειώματα που συνδέονται με διάταξη και επαναφέρει κάθε διαφάνεια πριν την αποθήκευση. Τα σχήματα χωρίς αντίστοιχο δεσμευτικό σημείωμα διάταξης δεν επαναφέρονται.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Επηρεάζει η μορφοποίηση σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Τα χρώματα, τα στυλ γραμμής και οι ρυθμίσεις εφέ προσθέτουν γενικά λίγα δεδομένα σε σχέση με τις ενσωματωμένες εικόνες και τα πολυμέσα. Τα γέμισματα εικόνας μπορούν να αυξήσουν το μέγεθος του αρχείου επειδή οι εικόνες τους αποθηκεύονται στην παρουσίαση.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος — γέμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε τα στυλ τους ως ίδια και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για χρήση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγμα σχήματος με τα επιθυμητά στυλ σε ένα σύνολο διαφανειών προτύπου ή σε αρχείο προτύπου .POTX. Κατά τη δημιουργία νέας παρουσίασης, ανοίξτε το πρότυπο, κλωνοποιήστε τα σχήματα που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.