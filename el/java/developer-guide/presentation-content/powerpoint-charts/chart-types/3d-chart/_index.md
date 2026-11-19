---
title: Προσαρμογή 3D διαγραμμάτων σε παρουσιάσεις με Java
linktitle: Διάγραμμα 3D
type: docs
url: /el/java/3d-chart/
keywords:
- Διάγραμμα 3D
- περιστροφή
- βάθος
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε 3D διαγράμματα σε παρουσιάσεις PowerPoint με το Aspose.Slides για Java. Προσαρμόστε την περιστροφή, τις αναλογίες ύψους, το βάθος του διαγράμματος και το διάστημα μεταξύ σειρών με παραδείγματα Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Java σας επιτρέπει να προσαρμόσετε την προβολή ενός 3D διαγράμματος μέσω της μεθόδου [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . Αυτό το άρθρο δείχνει πώς να ρυθμίσετε την περιστροφή, τις αναλογίες ύψους, το βάθος, τους άξονες ορθής γωνίας και το διαχωρισμό μεταξύ σειρών, και στη συνέχεια να αποθηκεύσετε την παρουσίαση σε μορφή PPTX.

## **Ορισμός της Περιστροφής και του Βάθους ενός 3D Διαγράμματος**

Το παρακάτω παράδειγμα δημιουργεί ένα [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) και χρησιμοποιεί το [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) για να προσθέσει ένα στοίβαγμα 3D στήλης διάγραμμα στην πρώτη του διαφάνεια. Αντικαθιστά τις προεπιλεγμένες σειρές και κατηγορίες με δύο σειρές που περιέχουν τρεις τιμές η καθεμία. Ο δείκτης φύλλου εργασίας `0` προσδιορίζει το πρώτο φύλλο δεδομένων του διαγράμματος· η γραμμή `0` περιέχει τα ονόματα των σειρών, και η στήλη `0` περιέχει τις ετικέτες των κατηγοριών.

Οι μέθοδοι [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) και [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) ορίζουν την περιστροφή του διαγράμματος στα 40 και 270 μοίρες, αντίστοιχα. Η [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) ορίζει το βάθος του στο 150 % του πλάτους του, ενώ η [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) ενεργοποιεί άξονες ορθής γωνίας αντί για προοπτική. Η τελική παρουσίαση περιέχει το γεμάτο διάγραμμα με αυτές τις ρυθμίσεις 3D προβολής.

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

## **Ρύθμιση των Αναλογιών Ύψους ενός 3D Διαγράμματος**

Χρησιμοποιήστε την [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) για να ορίσετε το ύψος ενός 3D διαγράμματος ως ποσοστό του πλάτους του. Αυτό αλλάζει τις αναλογίες της 3D σκηνής χωρίς να αλλάζει το μέγεθος του αντικειμένου διαγράμματος στη διαφάνεια.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) με τα προεπιλεγμένα δεδομένα: τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει τρεις παρουσιάσεις με αναλογίες ύψους 50 %, 100 % και 200 %. Η θέση, το πλάτος και το ύψος του διαγράμματος παραμένουν σταθερά. Τα δεδομένα, η περιστροφή, το βάθος, το διάστημα μεταξύ σειρών και η μορφοποίηση είναι τα ίδια στα τρία αρχεία· μόνο το ποσοστό ύψους αλλάζει.

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

Οι παρακάτω εικόνες απεικονίζουν τις ίδιες ρυθμίσεις ύψους στο ισοδύναμο παράδειγμα .NET και εξήχθησαν με το Microsoft PowerPoint. Ένα μικρότερο ποσοστό δημιουργεί μια πιο επίπεδη σκηνή, ενώ ένα μεγαλύτερο ποσοστό δημιουργεί μια πιο ψηλή σκηνή εντός του ίδιου αντικειμένου διαγράμματος. Το PowerPoint μπορεί επίσης να προσαρμόσει τα διαστήματα των σημείων των αξόνων και τη θέση των ετικετών ώστε να ταιριάζουν στη σκηνή.

| Ύψος: 50% | Ύψος: 100% | Ύψος: 200% |
| --- | --- | --- |
| ![Διάγραμμα 3Δ στήλης με ύψος ορισμένο στο 50% του πλάτους του](height_percent_50.png) | ![Διάγραμμα 3Δ στήλης με ύψος ορισμένο στο 100% του πλάτους του](height_percent_100.png) | ![Διάγραμμα 3Δ στήλης με ύψος ορισμένο στο 200% του πλάτους του](height_percent_200.png) |

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Ύψος της 3Δ σκηνής ως ποσοστό του πλάτους της. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Ύψος του αντικειμένου διαγράμματος στη διαφάνεια, σε μονάδες points. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Βάθος της 3Δ σκηνής ως ποσοστό του πλάτους της. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |

Η ρύθμιση ύψους επηρεάζει τα 3D διαγράμματα στήλης και ραβδού, συμπεριλαμβανομένων των κυλίνδρων, κώνων και πυραμίδων, καθώς και τα 3D διαγράμματα γραμμής, περιοχής, πίτας και επιφάνειας. Η παραπάνω σύγκριση χρησιμοποιεί τον επαληθευμένο τύπο `Column3D`. Η ρύθμιση δεν αλλάζει την εμφάνιση ενός 2D διαγράμματος `ClusteredColumn` ή ενός διαγράμματος `BubbleWith3D`; αυτά τα ονόματα είναι μέλη της κλάσης [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Για άλλες ρυθμίσεις εμφάνισης διαγράμματος, δείτε [Διαμόρφωση Διαγράμματος](/slides/el/java/chart-formatting/).

## **Ρύθμιση του Κενού Μεταξύ Σειρών**

Χρησιμοποιήστε το [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) για να ελέγξετε την απόσταση μεταξύ σειρών δεδομένων κατά τον άξονα βάθους ενός 3D διαγράμματος, εκφρασμένη ως ποσοστό του πλάτους του δείκτη. Χρησιμοποιήστε τιμές από **0 έως 500**, συμπεριλαμβανομένου: `0` αφαιρεί το κενό, ενώ μεγαλύτερες τιμές αυξάνουν το διάστημα. Με ένα σταθερό βάθος διαγράμματος, η αύξηση του κενού κάνει τους δείκτες πιο λεπτούς κατά τον άξονα βάθους.

Πρόσβαση στην ομάδα μέσω του [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--). Η ρύθμιση εφαρμόζεται σε κάθε σειρά σε αυτήν την ομάδα, όχι μόνο στη σειρά που χρησιμοποιήθηκε για την πρόσβαση. Η [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) επιστρέφει το κενό βάθους και αντανακλά τη ρύθμιση της γονικής ομάδας.

Αυτή η ρύθμιση επηρεάζει τα 3D διαγράμματα στήλης και ραβδού, συμπεριλαμβανομένων των παραλλαγών κυλίνδρου, κώνου και πυραμίδας, καθώς και τα 3D διαγράμματα γραμμής και περιοχής. Η εμφάνιση εξαρτάται από το αν οι σειρές είναι διατεταγμένες κατά βάθος, σε ομάδες ή στοίβαγμα. Για σαφή σύγκριση των κενών μεταξύ ξεχωριστών σειρών, χρησιμοποιήστε το `ChartType.Column3D` από την κλάση [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/).

Αυτές οι μέθοδοι ελέγχουν διαφορετικές πτυχές του διαγράμματος:

| Μέθοδος | Αποτέλεσμα |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Απόσταση μεταξύ σειρών κατά τον άξονα βάθους, ως ποσοστό του πλάτους του δείκτη. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Απόσταση μεταξύ παρακείμενων ομάδων ράβδων ή στηλών, ως ποσοστό του πλάτους της ράβδου ή της στήλης. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Συνολικό βάθος του διαγράμματος, ως ποσοστό του πλάτους του διαγράμματος. |

Το παρακάτω αυτόνομο παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα διαγράμματος, τα οποία περιέχουν τρεις σειρές και τέσσερις κατηγορίες. Αποθηκεύει δύο παρουσιάσεις με ταυτοπαθή δεδομένα, περιστροφή, εύρος κενού και βάθος διαγράμματος· μόνο το βάθος κενού αλλάζει.

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

Οι παρακάτω εικόνες απεικονίζουν τις ίδιες ρυθμίσεις βάθους κενού στο ισοδύναμο παράδειγμα .NET και εξήχθησαν με το Microsoft PowerPoint.

| Βάθος κενό: 0% | Βάθος κενό: 500% |
| --- | --- |
| ![Διάγραμμα 3Δ στήλης χωρίς κενό μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_0.png) | ![Διάγραμμα 3Δ στήλης με κενό 500% μεταξύ σειρών κατά τον άξονα βάθους](gap_depth_500.png) |

## **Αλλαγή του Τύπου Σειράς 3D και του Σχήματος Ράβδου**

Σε ένα διάγραμμα ομάδας κυλίνδρων, η πρώτη σειρά ξεκινά με σχήμα κυλινδρικής ράβδου. Το παράδειγμα εκτυπώνει τις ακέραιες τιμές που επιστρέφουν οι [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) και [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) πριν και μετά από κάθε αλλαγή. Ο πίνακας παρέχει τα αντίστοιχα ονόματα στα constants.

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
| Ορισμός του τύπου σειράς σε `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ορισμός του σχήματος ράβδου σε `Box` | `ClusteredColumn3D` | `Box` |

Ο ορισμός του σχήματος σε `Box` αλλάζει επίσης τον τύπο σειράς σε `ClusteredColumn3D`. Εάν ο κώδικάς σας εκτελεί διακλάδωση με βάση τον τύπο σειράς, καλέστε το `series.getType()` μετά την αλλαγή του σχήματος. Μια τιμή που είχε αποθηκευτεί πριν από την ανάθεση θα συνέχιζε να επιλέγει το κλαδί `ClusteredCone`.

![Σύγκριση PowerPoint που δείχνει την πρώτη σειρά ως κυλίνδρους, κώνους και ορθογώνιες στήλες από αριστερά προς δεξιά](series-shapes.png)

## **Συχνές Ερωτήσεις**

**Ποιοι τύποι διαγραμμάτων υποστηρίζουν τη λειτουργία 3D στο Aspose.Slides;**

Το Aspose.Slides υποστηρίζει παραλλαγές 3D των διαγραμμάτων στήλης, συμπεριλαμβανομένων των Column 3D, Clustered Column 3D, Stacked Column 3D και 100 % Stacked Column 3D, καθώς και σχετικούς 3D τύπους που εκτίθενται μέσω της κλάσης [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Για μια ακριβή, ενημερωμένη λίστα, ελέγξτε τα μέλη της [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) στην τεκμηρίωση API της εγκατεστημένης έκδοσής σας.

**Μπορώ να λάβω μια ραστρική εικόνα ενός 3D διαγράμματος για αναφορά ή το Web;**

Ναι. Μπορείτε να εξάγετε ένα διάγραμμα σε εικόνα με τη μέθοδο [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) , ή να [αποδώσετε ολόκληρη τη διαφάνεια](/slides/el/java/convert-powerpoint-to-png/) σε μορφές όπως PNG ή JPEG. Αυτό είναι χρήσιμο όταν χρειάζεστε μια ραστρική προεπισκόπηση ή θέλετε να ενσωματώσετε το διάγραμμα σε έγγραφα, πίνακες ελέγχου ή ιστοσελίδες χωρίς να απαιτείται το PowerPoint.

**Πόσο αποδοτική είναι η δημιουργία και η απόδοση μεγάλων 3D διαγραμμάτων;**

Η απόδοση εξαρτάται από τον όγκο των δεδομένων και την οπτική πολυπλοκότητα. Για τα καλύτερα αποτελέσματα, διατηρήστε τα 3D εφέ στο ελάχιστο, αποφύγετε βαριές υφές σε τοίχους και περιοχές σχεδίασης, περιορίστε τον αριθμό των σημείων δεδομένων ανά σειρά όποτε είναι δυνατόν, και αποδώστε σε μια έξοδο κατάλληλου μεγέθους (ανάλυση και διαστάσεις) ώστε να ταιριάζει στην επιθυμητή οθόνη ή εκτύπωση.