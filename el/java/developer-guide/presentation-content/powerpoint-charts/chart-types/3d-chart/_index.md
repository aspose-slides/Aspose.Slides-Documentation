---
title: Προσαρμογή 3Δ Διαγραμμάτων σε Παρουσιάσεις Χρησιμοποιώντας Java
linktitle: 3Δ Διάγραμμα
type: docs
url: /el/java/3d-chart/
keywords:
- 3Δ διάγραμμα
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε 3Δ διαγράμματα σε παρουσιάσεις PowerPoint με το Aspose.Slides for Java. Ρυθμίστε την περιστροφή, τις αναλογίες ύψους, το βάθος του διαγράμματος και το κενό μεταξύ των σειρών με παραδείγματα Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Java σας επιτρέπει να προσαρμόζετε την προβολή ενός 3Δ διαγράμματος μέσω της μεθόδου [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . Αυτό το άρθρο δείχνει πώς να ρυθμίσετε την περιστροφή, τις αναλογίες ύψους, το βάθος, τους άξονες ορθής γωνίας και το κενό μεταξύ των σειρών, και στη συνέχεια να αποθηκεύσετε την παρουσίαση σε μορφή PPTX.

## **Ορισμός της Περιστροφής και του Βυθού ενός 3Δ Διαγράμματος**

Το παρακάτω παράδειγμα δημιουργεί μια [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) και χρησιμοποιεί την [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) για να προσθέσει ένα συσσωρευμένο 3Δ διάγραμμα στηλών στην πρώτη διαφάνειά της. Αντικαθιστά τις προεπιλεγμένες σειρές και κατηγορίες με δύο σειρές που περιέχουν τρεις τιμές η καθεμία. Ο δείκτης φύλλου εργασίας `0` εντοπίζει το πρώτο φύλλο δεδομένων του διαγράμματος· η γραμμή `0` περιέχει τα ονόματα σειρών και η στήλη `0` περιέχει τις ετικέτες κατηγοριών.

Οι μέθοδοι [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) και [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) θέτουν την περιστροφή του διαγράμματος σε 40 και 270 μοίρες αντίστοιχα. Η μέθοδος [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) ορίζει το βάθος του σε 150 % του πλάτους του, ενώ η [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) ενεργοποιεί άξονες ορθής γωνίας αντί για προοπτική. Η προκύπτουσα παρουσίαση περιέχει το πλήρες διάγραμμα με αυτές τις ρυθμίσεις προβολής 3Δ.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Εφαρμογή Γέμισης Εικόνας στην Επιφάνεια ενός 3Δ Διαγράμματος**

Ένα 3Δ διάγραμμα διαθέτει τρεις επιφάνειες που μπορείτε να γεμίσετε ανεξάρτητα: τον [side wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--), τον [back wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) και το [floor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) . Ορίστε τον [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) της επιφάνειας σε `Picture` και ορίστε μια εικόνα. Ορίστε τόσο τον [picture fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) όσο και τον [picture type](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-) της επιφάνειας σε `Stretch` ώστε η εικόνα να τεντώνεται για να καλύψει ολόκληρη την επιφάνεια.

Αποθηκεύστε το αρχείο [arrow.png](arrow.png) στον τρέχοντα φάκελο. Το παράδειγμα περιστρέφει το διάγραμμα και αυξάνει τη μέγιστη τιμή του κατακόρυφου άξονα ώστε το πάτωμα να είναι ορατό μεταξύ των στηλών. Στη συνέχεια κλωνοποιεί τη διαφάνεια δύο φορές και εφαρμόζει το βέλος σε διαφορετική επιφάνεια σε κάθε διαφάνεια. Και τα τρία διαγράμματα διατηρούν τα ίδια δεδομένα, την ίδια γωνία θέασης και το ίδιο φόντο.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το Microsoft PowerPoint εμφανίζει τις τρεις διαφάνειες ως εξής.

| Πλευρική τοιχοποιία | Πίσω τοιχοποιία | Πάτωμα |
| --- | --- | --- |
| ![Βέλος που δείχνει στο διάγραμμα κατά μήκος του πλευρικού τοίχου](side-wall.png) | ![Βέλος που δείχνει δεξιά κατά μήκος του πίσω τοίχου](back-wall.png) | ![Βέλος που δείχνει δεξιά κατά μήκος του πατώματος μεταξύ των στηλών](floor.png) |

## **Ρύθμιση των Αναλογιών Ύψους ενός 3Δ Διαγράμματος**

Χρησιμοποιήστε την [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) για να ορίσετε το ύψος ενός 3Δ διαγράμματος ως ποσοστό του πλάτους του. Αυτό αλλάζει τις αναλογίες της 3Δ σκηνής χωρίς να αλλάζει το μέγεθος του αντικειμένου διαγράμματος στη διαφάνεια.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) με τα προεπιλεγμένα δεδομένα: τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει τρεις παρουσιάσεις με αναλογίες ύψους 50 %, 100 % και 200 %. Η θέση, το πλάτος και το ύψος του διαγράμματος παραμένουν σταθερά. Τα δεδομένα, η περιστροφή, το βάθος, το κενό μεταξύ σειρών και η μορφοποίηση είναι τα ίδια σε όλα τα αρχεία· μόνο το ποσοστό ύψους αλλάζει.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Οι παρακάτω εικόνες απεικονίζουν τις ίδιες ρυθμίσεις ύψους στο αντίστοιχο παράδειγμα .NET και έχουν εξαχθεί με το Microsoft PowerPoint. Ένα μικρότερο ποσοστό δημιουργεί πιο επίπεδη σκηνή, ενώ ένα μεγαλύτερο ποσοστό δημιουργεί πιο ψηλή σκηνή μέσα στο ίδιο αντικείμενο διαγράμματος. Το PowerPoint μπορεί επίσης να προσαρμόσει τα διαστήματα των σημείων των αξόνων και τη θέση των ετικετών για να ταιριάζει στη σκηνή.

| Ύψος: 50 % | Ύψος: 100 % | Ύψος: 200 % |
| --- | --- | --- |
| ![3Δ διάγραμμα στηλών με ύψος 50 % του πλάτους του](height_percent_50.png) | ![3Δ διάγραμμα στηλών με ύψος 100 % του πλάτους του](height_percent_100.png) | ![3Δ διάγραμμα στηλών με ύψος 200 % του πλάτους του](height_percent_200.png) |

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Ύψος της 3Δ σκηνής ως ποσοστό του πλάτους της. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Ύψος του αντικειμένου διαγράμματος στη διαφάνεια, σε points. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Βάθος της 3Δ σκηνής ως ποσοστό του πλάτους της. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |

Η ρύθμιση του ύψους επηρεάζει διαγράμματα 3Δ στηλών και ράβδων, συμπεριλαμβανομένων των κυλινδρικών, κωνικών και πυραμιδικών παραλλαγών, καθώς και διαγράμματα 3Δ γραμμής, επιφάνειας, πίτας και επιφάνειας. Η σύγκριση παραπάνω χρησιμοποιεί τον επαληθευμένο τύπο `Column3D`. Η ρύθμιση δεν αλλάζει την εμφάνιση ενός 2Δ διαγράμματος `ClusteredColumn` ή ενός διαγράμματος `BubbleWith3D`· αυτά τα ονόματα είναι μέλη της κλάσης [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Για άλλες ρυθμίσεις εμφάνισης διαγράμματος, δείτε την [Μορφοποίηση Διαγράμματος](/slides/el/java/chart-formatting/).

## **Ρύθμιση του Χάσματος μεταξύ Σειρών**

Χρησιμοποιήστε το [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) για να ελέγξετε την απόσταση μεταξύ σειρών δεδομένων κατά τον άξονα βάθους ενός 3Δ διαγράμματος, εκφρασμένη ως ποσοστό του πλάτους του δείκτη. Χρησιμοποιήστε τιμές από **0 έως 500**, συμπεριλαμβανομένου: `0` αφαιρεί το κενό, ενώ μεγαλύτερες τιμές αυξάνουν το κενό. Με σταθερό βάθος διαγράμματος, η αύξηση του κενάλυσης κάνει τα δείκτες πιο λεπτά κατά τον άξονα βάθους.

Πρόσβαση στην ομάδα μέσω του [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) . Η ρύθμιση ισχύει για κάθε σειρά σε αυτήν την ομάδα, όχι μόνο για τη σειρά που χρησιμοποιήθηκε για την πρόσβαση. Το [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) επιστρέφει το κενό βάθους και αντικατοπτρίζει τη ρύθμιση της γονικής ομάδας.

Αυτή η ρύθμιση επηρεάζει διαγράμματα 3Δ στηλών και ράβδων, συμπεριλαμβανομένων των κυλινδρικών, κωνικών και πυραμιδικών παραλλαγών, καθώς και διαγράμματα 3Δ γραμμής και επιφάνειας. Η εμφάνιση εξαρτάται από το εάν οι σειρές είναι τοποθετημένες σε βάθος, συγκεντρωμένες ή συσσωρευμένες. Για σαφή σύγκριση των κενών μεταξύ ξεχωριστών σειρών, χρησιμοποιήστε `ChartType.Column3D` από την κλάση [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/).

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Απόσταση μεταξύ γειτονικών συσσωματώσεων ράβδων ή στηλών, ως ποσοστό του πλάτους της ράβδου ή της στήλης. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Συνολικό βάθος διαγράμματος, ως ποσοστό του πλάτους του διαγράμματος. |

Το παρακάτω αυτόνομα παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα του διαγράμματος, τα οποία περιέχουν τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει δύο παρουσιάσεις με τα ίδια δεδομένα, την ίδια περιστροφή, το ίδιο κενό πλάτους και το ίδιο βάθος διαγράμματος· μόνο το κενό βάθους αλλάζει.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Οι παρακάτω εικόνες απεικονίζουν τις ίδιες ρυθμίσεις κενού βάθους στο αντίστοιχο παράδειγμα .NET και έχουν εξαχθεί με το Microsoft PowerPoint.

| Κενό βάθους: 0 % | Κενό βάθους: 500 % |
| --- | --- |
| ![3Δ διάγραμμα στηλών χωρίς κενό μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_0.png) | ![3Δ διάγραμμα στηλών με κενό 500 % μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_500.png) |

## **Αλλαγή του Τύπου Σειράς 3Δ και του Σχήματος Ράβδου**

Σε ένα συγκεντρωτικό κυλινδρικό διάγραμμα, η πρώτη σειρά ξεκινάει με κυλινδρικό σχήμα ράβδου. Το παράδειγμα εκτυπώνει τις ακέραιες τιμές που επιστρέφουν οι μέθοδοι [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) και [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) πριν και μετά από κάθε αλλαγή. Ο πίνακας δίνει τα αντίστοιχα ονόματα σταθερών.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Αλλαγή στην πρώτη σειρά | Τύπος σειράς | Σχήμα ράβδου |
| --- | --- | --- |
| Δημιουργία του διαγράμματος | `ClusteredCylinder` | `Cylinder` |
| Ορισμός τύπου σειράς σε `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ορισμός σχήματος ράβδου σε `Box` | `ClusteredColumn3D` | `Box` |

Ο ορισμός του σχήματος σε `Box` αλλάζει επίσης τον τύπο σειράς σε `ClusteredColumn3D`. Εάν ο κώδικάς σας ελέγχει τον τύπο σειράς, καλέστε `series.getType()` μετά την αλλαγή του σχήματος. Μια τιμή που είχε αποθηκευτεί πριν την ανάθεση θα συνέχιζε να επιλέγει το κλαδί `ClusteredCone`.

![Σύγκριση PowerPoint που δείχνει την πρώτη σειρά ως κυλίνδρους, κώνο και ορθογώνιες στήλες από αριστερά προς δεξιά](series-shapes.png)

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν τη λειτουργία 3Δ στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3Δ παραλλαγές των στηλών, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100 % Stacked Column 3D, καθώς και σχετικούς 3Δ τύπους που εκτίθενται μέσω της κλάσης [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Για ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη του [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) στην τεκμηρίωση της έκδοσής σας.

**Μπορώ να λάβω μια ραστροειδική εικόνα ενός 3Δ διαγράμματος για αναφορά ή το web;**

Ναι. Μπορείτε να εξάγετε ένα διάγραμμα σε εικόνα με τη μέθοδο [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) ή να [αποδώσετε ολόκληρη τη διαφάνεια](/slides/el/java/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια ραστροειδική προεπισκόπηση ή θέλετε να ενσωματώσετε το διάγραμμα σε έγγραφα, πίνακες ελέγχου ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και η απόδοση μεγάλων 3Δ διαγραμμάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και την οπτική πολυπλοκότητα. Για βέλτιστα αποτελέσματα, περιορίζετε τα 3Δ εφέ, αποφεύγετε βαριές υφές στους τοίχους και τις περιοχές σχεδίασης, μειώνετε τον αριθμό σημείων δεδομένων ανά σειρά όποτε είναι εφικτό και αποδίδετε σε κατάλληλο μέγεθος εξόδου (ανάλυση και διαστάσεις) ώστε να ταιριάζει στην προβολή ή το εκτυπωτικό μέσο.