---
title: Προσαρμογή 3D γραφημάτων σε παρουσιάσεις στο Android
linktitle: 3D γράφημα
type: docs
url: /el/androidjava/3d-chart/
keywords:
- 3D γράφημα
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε 3D γραφήματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για Android μέσω Java. Προσαρμόστε την περιστροφή, τις αναλογίες ύψους, το βάθος του γραφήματος και την απόσταση μεταξύ των σειρών με παραδείγματα Java."
---
## **Επισκόπηση**

Aspose.Slides for Android via Java σας επιτρέπει να προσαρμόσετε την προβολή ενός 3D γραφήματος μέσω της μεθόδου [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) . Αυτό το άρθρο δείχνει πώς να ρυθμίσετε την περιστροφή, τις αναλογίες ύψους, το βάθος, τους άξονες ορθής γωνίας και την απόσταση μεταξύ των σειρών, και στη συνέχεια να αποθηκεύσετε την παρουσίαση σε μορφή PPTX.

## **Ορισμός της Περιστροφής και του Βάθους ενός 3D Γραφήματος**

Το παρακάτω παράδειγμα δημιουργεί μια [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) και χρησιμοποιεί το [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) για να προσθέσει ένα στοίβαγμα 3D column γράφημα στην πρώτη του διαφάνεια. Αντικαθιστά τις προεπιλεγμένες σειρές και κατηγορίες με δύο σειρές που περιέχουν τρεις τιμές η καθεμία. Ο δείκτης φύλλου εργασίας `0` καθορίζει το πρώτο φύλλο δεδομένων του γραφήματος· η γραμμή `0` περιέχει τα ονόματα των σειρών, και η στήλη `0` περιέχει τις ετικέτες των κατηγοριών.

Οι μέθοδοι [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) και [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) θέτουν την περιστροφή του γραφήματος στα 40 και 270 μοίρες αντίστοιχα. Η [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) ορίζει το βάθος του στο 150 % του πλάτους του, ενώ η [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) ενεργοποιεί άξονες ορθής γωνίας αντί για προοπτική. Η τελική παρουσίαση περιέχει το γεμισμένο γράφημα με αυτές τις ρυθμίσεις προβολής 3D.

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

## **Εφαρμογή Γέμισης Εικόνας στην Επιφάνεια ενός 3D Γραφήματος**

Ένα 3D γράφημα έχει τρεις επιφάνειες που μπορείτε να γεμίσετε ανεξάρτητα: τον [side wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--), τον [back wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) και το [floor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) . Ορίστε τον [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) της επιφάνειας σε `Picture` και αντιστοιχίστε μια εικόνα. Ορίστε τόσο το [picture fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) όσο και τον [picture type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) της επιφάνειας σε `Stretch` ώστε να ταιριάζει ένα αντίγραφο της εικόνας σε όλη την επιφάνεια.

Αποθηκεύστε το αρχείο [arrow.png](arrow.png) στον τρέχοντα φάκελο εργασίας. Το παράδειγμα περιστρέφει το γράφημα και αυξάνει τη μέγιστη τιμή στον κάθετο άξονα ώστε το πάτωμα να φαίνεται μεταξύ των στηλών. Στη συνέχεια κλωνοποιεί τη διαφάνεια δύο φορές και εφαρμόζει το βέλος σε διαφορετική επιφάνεια σε κάθε διαφάνεια. Και τα τρία γραφήματα διατηρούν τα ίδια δεδομένα, γωνία θέασης και φόντο.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
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

    IPPImage arrow = presentation.getImages().addImage(image);

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

| Πλευρικός τοίχος | Πίσω τοίχος | Πάτωμα |
| --- | --- | --- |
| ![Βέλος που δείχνει μέσα στο γράφημα κατά μήκος του πλευρικού τοίχου](side-wall.png) | ![Βέλος που δείχνει δεξιά κατά μήκος του πίσω τοίχου](back-wall.png) | ![Βέλος που δείχνει δεξιά κατά μήκος του πατώματος μεταξύ των στηλών](floor.png) |

## **Ρυθμιση των Αναλογιών Ύψους ενός 3D Γραφήματος**

Χρησιμοποιήστε τη [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) για να ορίσετε το ύψος ενός 3D γραφήματος ως ποσοστό του πλάτους του. Αυτό αλλάζει τις αναλογίες της 3D σκηνής χωρίς να αλλάζει το μέγεθος του αντικειμένου του γραφήματος στη διαφάνεια.

Το παρακάτω παράδειγμα δημιουργεί ένα γράφημα [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) με τα προεπιλεγμένα δεδομένα: τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει τρεις παρουσιάσεις με αναλογίες ύψους 50 %, 100 % και 200 %. Η θέση, το πλάτος και το ύψος του γραφήματος παραμένουν σταθερά. Τα δεδομένα, η περιστροφή, το βάθος, η απόσταση σειρών και η μορφοποίηση είναι ίδια σε όλα τα αρχεία· μόνο το ποσοστό ύψους αλλάζει.

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

Οι παρακάτω εικόνες απεικονίζουν τις ίδιες ρυθμίσεις ύψους στο αντίστοιχο παράδειγμα .NET και εξήχθησαν με το Microsoft PowerPoint. Ένα μικρότερο ποσοστό δημιουργεί πιο επίπεδη σκηνή, ενώ ένα μεγαλύτερο ποσοστό δημιουργεί ψηλότερη σκηνή εντός του ίδιου αντικειμένου του γραφήματος. Το PowerPoint μπορεί επίσης να προσαρμόσει τα διαστήματα των τιμών των αξόνων και την τοποθέτηση των ετικετών ώστε να ταιριάζει η σκηνή.

| Ύψος: 50% | Ύψος: 100% | Ύψος: 200% |
| --- | --- | --- |
| ![3D στήλη με ύψος 50% του πλάτους της](height_percent_50.png) | ![3D στήλη με ύψος 100% του πλάτους της](height_percent_100.png) | ![3D στήλη με ύψος 200% του πλάτους της](height_percent_200.png) |

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του γραφήματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Ύψος της 3D σκηνής ως ποσοστό του πλάτους της. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | Ύψος του αντικειμένου γραφήματος στη διαφάνεια, σε points. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Βάθος της 3D σκηνής ως ποσοστό του πλάτους της. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Απόσταση μεταξύ σειρών κατά μήκος του άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |

Η ρύθμιση του ύψους επηρεάζει γραφήματα στήλης και ράβδου 3D, συμπεριλαμβανομένων των κυλινδρικών, κωνικών και πυραμιδικών παραλλαγών, καθώς και γραφήματα γραμμής, περιοχής, πίτας και επιφάνειας 3D. Η σύγκριση παραπάνω χρησιμοποιεί τον επαληθευμένο τύπο `Column3D`. Η ρύθμιση δεν αλλάζει την εμφάνιση ενός 2D γραφήματος `ClusteredColumn` ή ενός γραφήματος `BubbleWith3D`· αυτά τα ονόματα ανήκουν στην κλάση [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Για άλλες ρυθμίσεις εμφάνισης γραφήματος, δείτε [Chart Formatting](/slides/el/androidjava/chart-formatting/).

## **Ρύθμιση του Κενού Μεταξύ Σειρών**

Χρησιμοποιήστε το [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) για να ελέγξετε την απόσταση μεταξύ σειρών δεδομένων κατά μήκος του άξονα βάθους ενός 3D γραφήματος, εκφρασμένη ως ποσοστό του πλάτους του δείκτη. Χρησιμοποιήστε τιμές από **0 έως 500**, συμπεριλαμβανομένων: το `0` αφαιρεί το κενό, ενώ μεγαλύτερες τιμές αυξάνουν την απόσταση. Με σταθερό βάθος γραφήματος, η αύξηση του κενού κάνει τα δείκτες πιο λεπτά κατά μήκος του άξονα βάθους.

Πρόσβαση στην ομάδα γίνεται μέσω του [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) . Η ρύθμιση εφαρμόζεται σε κάθε σειρά της ομάδας, όχι μόνο στην σειρά που χρησιμοποιήθηκε για την πρόσβαση. Η μέθοδος [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) επιστρέφει το κενό βάθους και αντανακλά τη ρύθμιση της γονικής ομάδας.

Η ρύθμιση αυτή επηρεάζει γραφήματα στήλης και ράβδου 3D, συμπεριλαμβανομένων των κυλινδρικών, κωνικών και πυραμιδικών παραλλαγών, καθώς και γραφήματα γραμμής και περιοχής 3D. Η εμφάνιση εξαρτάται από το αν οι σειρές είναι διατεταγμένες σε βάθος, σε ομάδες ή στοίβαγες. Για σαφή σύγκριση των κενών μεταξύ ξεχωριστών σειρών, χρησιμοποιήστε το `ChartType.Column3D` από την κλάση [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του γραφήματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Απόσταση μεταξύ σειρών κατά μήκος του άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Απόσταση μεταξύ διαδοχικών ομάδων ράβδων ή στηλών, ως ποσοστό του πλάτους της ράβδου ή της στήλης. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Συνολικό βάθος γραφήματος, ως ποσοστό του πλάτους του γραφήματος. |

Το παρακάτω αυτοτελές παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα γραφήματος, που περιέχουν τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει δύο παρουσιάσεις με ίδια δεδομένα, περιστροφή, πλάτος κενού και βάθος γραφήματος· μόνο το κενό βάθους διαφέρει.

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

Οι παρακάτω εικόνες απεικονίζουν τις ίδιες ρυθμίσεις κενού βάθους στο αντίστοιχο παράδειγμα .NET και εξήχθησαν με το Microsoft PowerPoint.

| Κενό βάθους: 0% | Κενό βάθους: 500% |
| --- | --- |
| ![3D στήλη χωρίς κενό μεταξύ σειρών κατά μήκος του άξονα βάθους](gap_depth_0.png) | ![3D στήλη με κενό 500 % μεταξύ σειρών κατά μήκος του άξονα βάθους](gap_depth_500.png) |

## **Αλλαγή του Τύπου Σειράς 3D και του Σχήματος Ράβδου**

Σε ένα γράφημα ομάδων κυλίνδρων, η πρώτη σειρά ξεκινάει με σχήμα ράβδου κύλινδρο. Το παράδειγμα εκτυπώνει τις ακεραίες τιμές που επιστρέφουν οι [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) και [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) πριν και μετά από κάθε αλλαγή. Ο πίνακας δίνει τα αντίστοιχα ονόματα σταθερών.

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
| Δημιουργία γραφήματος | `ClusteredCylinder` | `Cylinder` |
| Ορισμός τύπου σειράς σε `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ορισμός σχήματος ράβδου σε `Box` | `ClusteredColumn3D` | `Box` |

Ο ορισμός του σχήματος σε `Box` αλλάζει επίσης τον τύπο σειράς σε `ClusteredColumn3D`. Εάν ο κώδικάς σας ελέγχει τον τύπο της σειράς, καλέστε το `series.getType()` μετά την αλλαγή του σχήματος. Μια τιμή που αποθηκεύτηκε πριν την ανάθεση θα συνέχιζε να επιλέγει τον κλάδο `ClusteredCone`.

![Σύγκριση PowerPoint που δείχνει την πρώτη σειρά ως κυλίνδρους, κώνοι και ορθογώνιες στήλες από αριστερά προς δεξιά](series-shapes.png)

## **FAQ**

**Ποιοι τύποι γραφημάτων υποστηρίζουν λειτουργία 3D στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει 3D παραλλαγές των γραφημάτων στήλης, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100 % Stacked Column 3D, καθώς και σχετικούς 3D τύπους που εκτίθενται μέσω της κλάσης [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Για ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη του [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) στην τεκμηρίωση API της εγκατεστημένης έκδοσής σας.

**Μπορώ να λάβω μια ραστερ εικόνα ενός 3D γραφήματος για αναφορά ή το Web;**

Ναι. Μπορείτε να εξάγετε ένα γράφημα σε εικόνα με τη μέθοδο [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) ή να [απεικονίσετε ολόκληρη τη διαφάνεια](/slides/el/androidjava/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια ραστερ προεπισκόπηση ή θέλετε να ενσωματώσετε το γράφημα σε έγγραφα, πίνακες εργαλείων ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και η απόδοση μεγάλων 3D γραφημάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και την οπτική πολυπλοκότητα. Για βέλτιστα αποτελέσματα, διατηρήστε τις 3D επιδράσεις στο ελάχιστο, αποφύγετε βαριές υφές στους τοίχους και τις περιοχές σχεδίασης, περιορίστε τον αριθμό των σημείων δεδομένων ανά σειρά όταν είναι δυνατόν και αποδώστε σε κατάλληλο μέγεθος εξόδου (ανάλυση και διαστάσεις) ώστε να ταιριάζει με την προοριζόμενη οθόνη ή εκτύπωση.