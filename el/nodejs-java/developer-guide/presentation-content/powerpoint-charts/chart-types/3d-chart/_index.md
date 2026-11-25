---
title: Προσαρμογή 3D Διαγραμμάτων σε Παρουσιάσεις με JavaScript
linktitle: 3D Διάγραμμα
type: docs
url: /el/nodejs-java/3d-chart/
keywords:
- 3D διάγραμμα
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε 3D διαγράμματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για Node.js μέσω Java. Ρυθμίστε την περιστροφή, τις αναλογίες ύψους, το βάθος του διαγράμματος και την απόσταση μεταξύ σειρών με παραδείγματα JavaScript."
---
## **Επισκόπηση**

Aspose.Slides for Node.js via Java σας επιτρέπει να προσαρμόσετε την προβολή ενός 3D διαγράμματος μέσω της μεθόδου [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) . Αυτό το άρθρο δείχνει πώς να ρυθμίσετε την περιστροφή, τις αναλογίες ύψους, το βάθος, τους άξονες ορθής γωνίας και την απόσταση μεταξύ σειρών, και στη συνέχεια να αποθηκεύσετε την παρουσίαση σε μορφή PPTX.

## **Ορισμός της Περιστροφής και του Βαθμού σε ένα 3D Διάγραμμα**

Το παρακάτω παράδειγμα δημιουργεί ένα [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) και χρησιμοποιεί το [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) για να προσθέσει ένα στοιβαγμένο 3D στήλης διάγραμμα στην πρώτη του διαφάνεια. Αντικαθιστά τις προεπιλεγμένες σειρές και κατηγορίες με δύο σειρές που περιέχουν τρεις τιμές η καθεμία. Ο δείκτης φύλλου εργασίας `0` προσδιορίζει το πρώτο φύλλο δεδομένων του διαγράμματος· η γραμμή `0` περιέχει τα ονόματα των σειρών, και η στήλη `0` περιέχει τις ετικέτες των κατηγοριών.

Οι μέθοδοι [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) και [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) ορίζουν την περιστροφή του διαγράμματος σε 40 και 270 μοίρες αντίστοιχα. Η μέθοδος [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) θέτει το βάθος του στο 150 % του πλάτους του, ενώ η [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) ενεργοποιεί άξονες ορθής γωνίας αντί για προοπτική. Η προκύπτουσα παρουσίαση περιέχει το γεμάτο διάγραμμα με αυτές τις ρυθμίσεις 3D προβολής.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εφαρμογή Εικόνας Γέμισματος στην Επιφάνεια ενός 3D Διαγράμματος**

Μπορείτε να γεμίσετε ανεξάρτητα τον [πλευρικό τοίχο](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), τον [πίσω τοίχο](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/) και το [δωμάτιο](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) ενός 3D διαγράμματος. Ορίστε τον [τύπο γεμίσματος](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) σε `Picture` και ορίστε μια εικόνα. Ορίστε τόσο το [λειτουργία γεμίσματος εικόνας](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) όσο και τον [τύπο εικόνας](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) της επιφάνειας σε `Stretch` για να τεντωθεί ένα αντίτυπο της εικόνας σε όλη την επιφάνεια.

Αποθηκεύστε το αρχείο [arrow.png](arrow.png) στον τρέχοντα φάκελο. Το παράδειγμα περιστρέφει το διάγραμμα και αυξάνει τη μέγιστη τιμή στον κατακόρυφο άξονα ώστε να είναι ορατός ο πάτος μεταξύ των στηλών. Στη συνέχεια κλωνοποιεί τη διαφάνεια δύο φορές και εφαρμόζει το βέλος σε διαφορετική επιφάνεια σε κάθε διαφάνεια. Και τα τρία διαγράμματα διατηρούν τα ίδια δεδομένα, γωνία θέασης και φόντο.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το Microsoft PowerPoint εμφανίζει τις τρεις διαφάνειες ως εξής.

| Πλευρικός τοίχος | Πίσω τοίχος | Δάπεδο |
| --- | --- | --- |
| ![Βέλος που δείχνει στο διάγραμμα κατά μήκος του πλευρικού τοίχου](side-wall.png) | ![Βέλος που δείχνει δεξιά διαμέσου του πίσω τοίχου](back-wall.png) | ![Βέλος που δείχνει δεξιά διαμέσου του δαπέδου μεταξύ των στηλών](floor.png) |

## **Ρύθμιση των Αναλογιών Ύψους ενός 3D Διαγράμματος**

Χρησιμοποιήστε το [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) για να ορίσετε το ύψος ενός 3D διαγράμματος ως ποσοστό του πλάτους του. Αυτό αλλάζει τις αναλογίες της 3D σκηνής χωρίς να αλλάζει το μέγεθος του αντικειμένου διαγράμματος στη διαφάνεια.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) με τα προεπιλεγμένα δεδομένα: τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει τρεις παρουσιάσεις με αναλογίες ύψους 50 %, 100 % και 200 %. Η θέση, το πλάτος και το ύψος του διαγράμματος παραμένουν σταθερά. Τα δεδομένα, η περιστροφή, το βάθος, η απόσταση σειρών και η μορφοποίηση είναι τα ίδια σε όλα τα αρχεία· μόνο το ποσοστό ύψους αλλάζει.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Οι παρακάτω εικόνες απεικονίζουν τις ίδιες ρυθμίσεις ύψους στο ισοδύναμο παράδειγμα .NET και εξήχθησαν με το Microsoft PowerPoint. Ένα μικρότερο ποσοστό δημιουργεί μια πιο επίπεδη σκηνή, ενώ ένα μεγαλύτερο ποσοστό δημιουργεί μια πιο ψηλή σκηνή εντός του ίδιου αντικειμένου διαγράμματος. Το PowerPoint μπορεί επίσης να προσαρμόσει τα διαστήματα των τιμών του άξονα και τη θέση των ετικετών ώστε να ταιριάζουν στη σκηνή.

| Ύψος: 50% | Ύψος: 100% | Ύψος: 200% |
| --- | --- | --- |
| ![Διάγραμμα 3D στήλης με ύψος 50 % του πλάτους του](height_percent_50.png) | ![Διάγραμμα 3D στήλης με ύψος 100 % του πλάτους του](height_percent_100.png) | ![Διάγραμμα 3D στήλης με ύψος 200 % του πλάτους του](height_percent_200.png) |

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Ύψος της 3D σκηνής ως ποσοστό του πλάτους της. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Ύψος του αντικειμένου διαγράμματος στη διαφάνεια, σε σημεία. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Βάθος της 3D σκηνής ως ποσοστό του πλάτους της. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |

Η ρύθμιση του ύψους επηρεάζει διαγράμματα στήλης και ράβδου 3D, συμπεριλαμβανομένων των κυλίνδρων, κώνων και πυραμίδων, καθώς και γραμμικά, περιοχής, πίτας και επιφάνειας 3D διαγράμματα. Η σύγκριση παραπάνω χρησιμοποιεί τον επαληθευμένο τύπο `Column3D`. Η ρύθμιση δεν αλλάζει την εμφάνιση ενός 2D διαγράμματος `ClusteredColumn` ή ενός διαγράμματος `BubbleWith3D`; αυτά τα ονόματα είναι μέλη της κλάσης [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Για άλλες ρυθμίσεις εμφάνισης, δείτε [Chart Formatting](/slides/el/nodejs-java/chart-formatting/).

## **Ρύθμιση του Κενού μεταξύ Σειρών**

Χρησιμοποιήστε το [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) για να ελέγξετε την απόσταση μεταξύ σειρών δεδομένων κατά τον άξονα βάθους ενός 3D διαγράμματος, εκφρασμένη ως ποσοστό του πλάτους του δείκτη. Χρησιμοποιήστε τιμές από **0 έως 500**, συμπεριλαμβανομένου: `0` αφαιρεί το κενό, ενώ μεγαλύτερες τιμές αυξάνουν την απόσταση. Με σταθερό βάθος διαγράμματος, η αύξηση του κενού κάνει τους δείκτες πιο λεπτούς κατά τον άξονα βάθους.

Πρόσβαση στην ομάδα μέσω του [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). Η ρύθμιση εφαρμόζεται σε κάθε σειρά της ομάδας, όχι μόνο στη σειρά που χρησιμοποιήθηκε για την πρόσβαση. Η μέθοδος [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) επιστρέφει το κενό βάθους και αντανακλά τη ρύθμιση της γονικής ομάδας.

Αυτή η ρύθμιση επηρεάζει διαγράμματα στήλης και ράβδου 3D, συμπεριλαμβανομένων των κυλίνδρων, κώνων και πυραμίδων, καθώς και διαγράμματα γραμμής και περιοχής 3D. Η εμφάνιση εξαρτάται από το αν οι σειρές είναι ταξινομημένες κατά βάθος, ομαδοποιημένες ή στοιβαγμένες. Για καθαρή σύγκριση κενού μεταξύ ξεχωριστών σειρών, χρησιμοποιήστε το `ChartType.Column3D` από την κλάση [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Απόσταση μεταξύ γειτονικών ομάδων στηλών ή ράβδων, ως ποσοστό του πλάτους της στήλης ή ράβδου. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Συνολικό βάθος διαγράμματος, ως ποσοστό του πλάτους του διαγράμματος. |

Το παρακάτω αυτόνομο παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα διαγράμματος, που περιέχουν τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει δύο παρουσιάσεις με ίδια δεδομένα, περιστροφή, πλάτος κενού και βάθος διαγράμματος· μόνο το κενό βάθους διαφέρει.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Οι παρακάτω εικόνες απεικονίζουν τις ίδιες ρυθμίσεις κενού βάθους στο ισοδύναμο παράδειγμα .NET και εξήχθησαν με το Microsoft PowerPoint.

| Βάθος κενό: 0% | Βάθος κενό: 500% |
| --- | --- |
| ![Διάγραμμα 3D στήλης χωρίς κενό μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_0.png) | ![Διάγραμμα 3D στήλης με κενό 500 % μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_500.png) |

## **Αλλαγή του 3D Τύπου Σειράς και του Σχήματος Ράβδου**

Σε ένα ομαδοποιημένο κυλινδρικό διάγραμμα, η πρώτη σειρά ξεκινά με σχήμα ράβδου κυλινδρικό. Το παράδειγμα εκτυπώνει τις ακέραιες τιμές που επιστρέφουν τα [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) και [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) πριν και μετά από κάθε αλλαγή. Ο πίνακας δείχνει τα αντίστοιχα ονόματα σταθερών.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Αλλαγή στην πρώτη σειρά | Τύπος σειράς | Σχήμα ράβδου |
| --- | --- | --- |
| Δημιουργία διαγράμματος | `ClusteredCylinder` | `Cylinder` |
| Ορισμός τύπου σειράς σε `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ορισμός σχήματος ράβδου σε `Box` | `ClusteredColumn3D` | `Box` |

Ο ορισμός του σχήματος σε `Box` αλλάζει επίσης τον τύπο σειράς σε `ClusteredColumn3D`. Εάν ο κώδικάς σας εξαρτάται από τον τύπο σειράς, καλέστε το `series.getType()` μετά την αλλαγή του σχήματος. Μια τιμή που είχε κρυφτεί πριν την ανάθεση θα συνέχιζε να επιλέγει την διακλάδωση `ClusteredCone`.

![Σύγκριση PowerPoint που δείχνει την πρώτη σειρά ως κυλίνδρο, κώνοι και ορθογώνιες στήλες από αριστερά προς τα δεξιά](series-shapes.png)

## **Συχνές Ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν λειτουργία 3D στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3D παραλλαγές των διαγραμμάτων στήλης, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100 % Stacked Column 3D, καθώς και σχετικούς 3D τύπους που εκτίθενται μέσω της κλάσης [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Για μια ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη του [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) στην αναφορά API της εγκατεστημένης έκδοσής σας.

**Μπορώ να λάβω μια ραστερ εικόνα ενός 3D διαγράμματος για αναφορά ή το διαδίκτυο;**

Ναι. Μπορείτε να εξαγάγετε ένα διάγραμμα σε εικόνα με τη μέθοδο [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) ή να [σχεδιάσετε ολόκληρη τη διαφάνεια](/slides/el/nodejs-java/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια ραστερ προεπισκόπηση ή θέλετε να ενσωματώσετε το διάγραμμα σε έγγραφα, ταμπλό ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και η απόδοση μεγάλων 3D διαγραμμάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και την οπτική πολυπλοκότητα. Για βέλτιστο αποτέλεσμα, περιορίστε τα εφέ 3D, αποφύγετε βαριές υφές στους τοίχους και τις περιοχές σχεδίασης, περιορίστε τον αριθμό των σημείων δεδομένων ανά σειρά όπου είναι δυνατόν, και αποδομήστε την έξοδο σε κατάλληλο μέγεθος (ανάλυση και διαστάσεις) ώστε να ταιριάζει με την προβλεπόμενη οθόνη ή εκτύπωση.