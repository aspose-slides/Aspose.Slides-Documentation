---
title: Προσαρμογή 3D Διαγραμμάτων σε Παρουσιάσεις με PHP
linktitle: 3D Διάγραμμα
type: docs
url: /el/php-java/3d-chart/
keywords:
- 3D διάγραμμα
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε 3D διαγράμματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για PHP μέσω Java. Ρυθμίστε την περιστροφή, τις αναλογίες ύψους, το βάθος του διαγράμματος και την απόσταση μεταξύ σειρών με παραδείγματα PHP."
---
## **Επισκόπηση**

Το Aspose.Slides για PHP μέσω Java σας επιτρέπει να προσαρμόσετε την προβολή ενός 3D διαγράμματος μέσω της μεθόδου [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D). Αυτό το άρθρο δείχνει πώς να ρυθμίσετε την περιστροφή, τις αναλογίες ύψους, το βάθος, τους άξονες ορθής γωνίας και την απόσταση μεταξύ σειρών, και στη συνέχεια να αποθηκεύσετε την παρουσίαση σε μορφή PPTX.

## **Ορισμός της Περιστροφής και του Βάθους ενός 3D Διαγράμματος**

Το παρακάτω παράδειγμα δημιουργεί ένα [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) και χρησιμοποιεί το [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) για να προσθέσει ένα στοίβαγμα 3D ραβδικού διαγράμματος στην πρώτη του διαφάνεια. Αντικαθιστά τις προεπιλεγμένες σειρές και κατηγορίες με δύο σειρές που περιέχουν τρεις τιμές η κάθε μία. Ο δείκτης φύλλου εργασίας `0` προσδιορίζει το πρώτο φύλλο δεδομένων του διαγράμματος· η γραμμή `0` περιέχει τα ονόματα των σειρών και η στήλη `0` περιέχει τις ετικέτες των κατηγοριών.

Οι μέθοδοι [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) και [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) ορίζουν την περιστροφή του διαγράμματος σε 40 και 270 μοίρες, αντίστοιχα. Η μέθοδος [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) ορίζει το βάθος του σε 150 % του πλάτους του, ενώ η [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) ενεργοποιεί άξονες ορθής γωνίας αντί για προοπτική. Η προκύπτουσα παρουσίαση περιέχει το γεμάτο διάγραμμα με αυτές τις ρυθμίσεις 3D προβολής.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Εφαρμογή Εικόνας Γέμισης στην Επιφάνεια ενός 3D Διαγράμματος**

Μπορείτε να γεμίσετε ανεξάρτητα τον [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/), τον [back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/) και το [floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) ενός 3D διαγράμματος. Ορίστε τον [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) της επιφάνειας σε `Picture` και ορίστε μια εικόνα. Ορίστε τόσο τη [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) όσο και τον [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) της επιφάνειας σε `Stretch` ώστε να ταιριάζει ένα αντίγραφο της εικόνας σε όλη την επιφάνεια.

Αποθηκεύστε το αρχείο [arrow.png](arrow.png) δίπλα στο script PHP. Το παράδειγμα περιστρέφει το διάγραμμα και αυξάνει τη μέγιστη τιμή στον κατακόρυφο άξονα ώστε το πάτωμα να είναι ορατό μεταξύ των ραβδών. Στη συνέχεια κλωνοποιεί τη διαφάνεια δύο φορές και εφαρμόζει το βέλος σε διαφορετική επιφάνεια σε κάθε διαφάνεια. Και τα τρία διαγράμματα διατηρούν τα ίδια δεδομένα, γωνία θέασης και φόντο.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το Microsoft PowerPoint εμφανίζει τις τρεις διαφάνειες ως εξής.

| Πλευρικός τοίχος | Οπισθός τοίχος | Δάπεδο |
| --- | --- | --- |
| ![Βέλος που δείχνει στο διάγραμμα κατά μήκος του πλευρικού τοίχου](side-wall.png) | ![Βέλος που δείχνει προς τα δεξιά κατά μήκος του οπισθίου τοίχου](back-wall.png) | ![Βέλος που δείχνει προς τα δεξιά κατά μήκος του δαπέδου μεταξύ των ραβδών](floor.png) |

## **Ρύθμιση των Αναλογιών Ύψους ενός 3D Διαγράμματος**

Χρησιμοποιήστε το [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) για να ορίσετε το ύψος ενός 3D διαγράμματος ως ποσοστό του πλάτους του. Αυτό αλλάζει τις αναλογίες της 3D σκηνής χωρίς να αλλάζει το μέγεθος του αντικειμένου διαγράμματος στη διαφάνεια.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) με τα προεπιλεγμένα δεδομένα: τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει τρεις παρουσιάσεις με αναλογίες ύψους 50 %, 100 % και 200 %. Η θέση, το πλάτος και το ύψος του διαγράμματος παραμένουν σταθερά. Τα δεδομένα, η περιστροφή, το βάθος, η απόσταση σειρών και η μορφοποίηση είναι τα ίδια σε όλα τα αρχεία· μόνο το ποσοστό ύψους αλλάζει.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Οι παρακάτω εικόνες απεικονίζουν τις ίδιες ρυθμίσεις ύψους στο ισοδύναμο παράδειγμα .NET και εξήχθησαν με το Microsoft PowerPoint. Ένα μικρότερο ποσοστό παράγει πιο επίπεδη σκηνή, ενώ ένα μεγαλύτερο ποσοστό παράγει υψηλότερη σκηνή εντός του ίδιου αντικειμένου διαγράμματος. Το PowerPoint μπορεί επίσης να προσαρμόσει τα διαστήματα των σημείων των αξόνων και την τοποθέτηση των ετικετών ώστε να ταιριάζουν στη σκηνή.

| Ύψος: 50% | Ύψος: 100% | Ύψος: 200% |
| --- | --- | --- |
| ![3D ραβδικό διάγραμμα με ύψος 50 % του πλάτους του](height_percent_50.png) | ![3D ραβδικό διάγραμμα με ύψος 100 % του πλάτους του](height_percent_100.png) | ![3D ραβδικό διάγραμμα με ύψος 200 % του πλάτους του](height_percent_200.png) |

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Ύψος της 3D σκηνής ως ποσοστό του πλάτους της. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Ύψος του αντικειμένου διαγράμματος στη διαφάνεια, σε points. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Βάθος της 3D σκηνής ως ποσοστό του πλάτους της. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |

Η ρύθμιση του ύψους επηρεάζει 3D στήλες και ράβδους, συμπεριλαμβανομένων των κυλίνδρων, κώνων και πυραμίδων, καθώς και 3D γραμμές, περιοχές, πίτες και επιφάνειες. Η παραπάνω σύγκριση χρησιμοποιεί τον επαληθευμένο τύπο `Column3D`. Η ρύθμιση δεν αλλάζει την εμφάνιση ενός 2D διαγράμματος `ClusteredColumn` ή ενός διαγράμματος `BubbleWith3D`; αυτά τα ονόματα είναι μέλη της κλάσης [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Για άλλες ρυθμίσεις εμφάνισης διαγράμματος, δείτε [Chart Formatting](/slides/el/php-java/chart-formatting/).

## **Ρύθμιση του Κενού μεταξύ Σειρών**

Χρησιμοποιήστε το [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) για να ελέγξετε την απόσταση μεταξύ σειρών δεδομένων κατά τον άξονα βάθους ενός 3D διαγράμματος, εκφρασμένη ως ποσοστό του πλάτους του δείκτη. Χρησιμοποιήστε τιμές από **0 έως 500**, συμπεριλαμβανομένου: `0` αφαιρεί το κενό, ενώ μεγαλύτερες τιμές αυξάνουν την απόσταση. Με σταθερό βάθος διαγράμματος, η αύξηση του κενού κάνει τα σύμβολα πιο λεπτά κατά τον άξονα βάθους.

Αποκτήστε την ομάδα μέσω του [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). Η ρύθμιση εφαρμόζεται σε κάθε σειρά της ομάδας, όχι μόνο στη σειρά που χρησιμοποιήθηκε για την πρόσβαση. Η μέθοδος [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) επιστρέφει το κενό βάθους και αντανακλά τη ρύθμιση της γονικής ομάδας.

Αυτή η ρύθμιση επηρεάζει 3D στήλες και ράβδους, συμπεριλαμβανομένων των κυλίνδρων, κώνων και πυραμίδων, καθώς και 3D γραμμές και περιοχές. Η εμφάνιση εξαρτάται από το αν οι σειρές είναι διατεταγμένες σε βάθος, ομαδοποιημένες ή στοίβαγμενες. Για σαφή σύγκριση κενών μεταξύ ξεχωριστών σειρών, χρησιμοποιήστε το `ChartType::Column3D` από την κλάση [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Απόσταση μεταξύ γειτονικών ομάδων ράβδων ή στηλών, ως ποσοστό του πλάτους της ράβδου ή της στήλης. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Συνολικό βάθος διαγράμματος, ως ποσοστό του πλάτους του διαγράμματος. |

Το παρακάτω αυτόνομο παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα διαγράμματος, που περιλαμβάνουν τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει δύο παρουσιάσεις με τα ίδια δεδομένα, περιστροφή, πλάτος κενού και βάθος διαγράμματος· μόνο το κενό βάθους διαφέρει.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Οι παρακάτω εικόνες απεικονίζουν τις ίδιες ρυθμίσεις κενού βάθους στο ισοδύναμο παράδειγμα .NET και εξήχθησαν με το Microsoft PowerPoint.

| Κενό βάθους: 0% | Κενό βάθους: 500% |
| --- | --- |
| ![3D ραβδικό διάγραμμα χωρίς κενό μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_0.png) | ![3D ραβδικό διάγραμμα με κενό 500 % μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_500.png) |

## **Αλλαγή του Τύπου Σειράς 3D και του Σχήματος Ράβδου**

Σε ένα στοίβαγμα κυλινδρικού διαγράμματος, η πρώτη σειρά ξεκινά με σχήμα ράβδου κυλίνδρου. Το παράδειγμα εκτυπώνει τις ακέραιες τιμές που επιστρέφουν τα [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) και [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) πριν και μετά από κάθε αλλαγή. Ο πίνακας δίνει τα αντίστοιχα ονόματα σταθερών.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Αλλαγή στην πρώτη σειρά | Τύπος σειράς | Σχήμα ράβδου |
| --- | --- | --- |
| Δημιουργία του διαγράμματος | `ClusteredCylinder` | `Cylinder` |
| Ορισμός τύπου σειράς σε `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ορισμός σχήματος ράβδου σε `Box` | `ClusteredColumn3D` | `Box` |

Ο ορισμός του σχήματος σε `Box` αλλάζει επίσης τον τύπο σειράς σε `ClusteredColumn3D`. Εάν ο κώδικάς σας ελέγχει τον τύπο σειράς, καλέστε το [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) μετά την αλλαγή του σχήματος. Μια τιμή που είχε αποθηκευτεί πριν την ανάθεση θα εξακολουθήσει να επιλέγει τον κλάδο `ClusteredCone`.

![Σύγκριση PowerPoint που δείχνει την πρώτη σειρά ως κυλίνδρους, κώναδες και ορθογώνιες στήλες από αριστερά προς δεξιά](series-shapes.png)

## **Συχνές Ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν λειτουργία 3D στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3D παραλλαγές των ραβδικών διαγραμμάτων, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100 % Stacked Column 3D, καθώς και σχετικούς 3D τύπους που εκτίθενται μέσω της κλάσης [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Για ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη του [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) στην αναφορά API της εγκατεστημένης έκδοσης.

**Μπορώ να λάβω μια ραστική εικόνα ενός 3D διαγράμματος για αναφορά ή τον ιστό;**

Ναι. Μπορείτε να εξάγετε ένα διάγραμμα σε εικόνα με τη [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) ή να [αποδώσετε ολόκληρη τη διαφάνεια](/slides/el/php-java/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια ραστική προεπισκόπηση ή θέλετε να ενσωματώσετε το διάγραμμα σε έγγραφα, ταμπλό ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και απόδοση μεγάλων 3D διαγραμμάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και την οπτική πολυπλοκότητα. Για καλύτερα αποτελέσματα, κρατήστε τα 3D εφέ στο ελάχιστο, αποφύγετε βαριά υφάσματα στους τοίχους και τις περιοχές σχεδίασης, περιορίστε τον αριθμό των σημείων δεδομένων ανά σειρά όταν είναι δυνατόν και αποδώστε σε κατάλληλο μέγεθος εξόδου (ανάλυση και διαστάσεις) ώστε να ταιριάζει στην τελική οθόνη ή εκτύπωση.