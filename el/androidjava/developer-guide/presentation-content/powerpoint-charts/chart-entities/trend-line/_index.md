---
title: Προσθήκη Γραμμών Τάσης σε Διαγράμματα Παρουσίασης σε Android
linktitle: Γραμμή Τάσης
type: docs
url: /el/androidjava/trend-line/
keywords:
- διάγραμμα
- γραμμή τάσης
- εκθετική γραμμή τάσης
- γραμμική γραμμή τάσης
- λογαριθμική γραμμή τάσης
- γραμμή κινητού μέσου
- πολυωνυμική γραμμή τάσης
- γραμμή τάσης δύναμης
- προσαρμοσμένη γραμμή τάσης
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Προσθέστε και προσαρμόστε γρήγορα γραμμές τάσης σε διαγράμματα PowerPoint με το Aspose.Slides για Android μέσω Java — ένας πρακτικός οδηγός για να εντυπωσιάσετε το κοινό σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε γραμμές τάσης σε διαγράμματα παρουσιάσεων χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσθέσετε γραμμές τάσης σε σειρές διαγράμματος και να εργαστείτε με πολλούς τύπους γραμμών τάσης, συμπεριλαμβανομένων των εκθετικών, γραμμικών, λογαριθμικών, κινητού μέσου, πολυωνυμικών και δύναμης.

Επιπλέον, περιγράφει πώς να προσθέσετε μια προσαρμοσμένη γραμμή σε ένα διάγραμμα εισάγοντας ένα σχήμα γραμμής, και περιλαμβάνει μια σύντομη Συχνές Ερωτήσεις σχετικά με τις τιμές προβολής της γραμμής τάσης προς εμπρός και προς τα πίσω και το αν οι γραμμές τάσης διατηρούνται κατά την εξαγωγή σε PDF ή SVG και κατά την απόδοση των διαγραμμάτων ως εικόνες.

## **Προσθήκη Γραμμής Τάσης**

Χρησιμοποιήστε [ITrendlineCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendlinecollection/#add-int-) για να προσθέσετε μια γραμμή τάσης σε μια σειρά διαγράμματος, επιλέγοντας τον τύπο της με το [TrendlineType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendlinetype/). Το παράδειγμα δημιουργεί ένα σύμπλεγμα στηλών με προεπιλεγμένα δεδομένα και προσθέτει δύο γραμμές τάσης σε καθεμία από τις τρεις σειρές του.

Η εκθετική γραμμή τάσης κρύβει την εξίσωση και την τιμή R‑τετράγωνο μέσω του [setDisplayEquation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) και του [setDisplayRSquaredValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), ενώ η γραμμική γραμμή τάσης είναι κόκκινη. Η λογαριθμική γραμμή τάσης χρησιμοποιεί το [addTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) για προσαρμοσμένη ετικέτα. Η μέση κινητή χρησιμοποιεί ένα [setPeriod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setPeriod-byte-) τριών σημείων δεδομένων και ένα προσαρμοσμένο [setTrendlineName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-).

Η πολυωνυμική γραμμή τάσης έχει [setOrder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setOrder-byte-) τριών και επεκτείνει μία κατηγορία προς τα εμπρός μέσω του [setForward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setForward-double-). Η γραμμή τάσης δύναμης επεκτείνεται μία κατηγορία προς τα πίσω μέσω του [setBackward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Τομής Γραμμής Τάσης**

Χρησιμοποιήστε το [setIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#setIntercept-double-) για να ορίσετε την τιμή Y μιας γραμμής τάσης στο X = 0. Αυτή η ρύθμιση υποστηρίζεται για γραμμικές, εκθετικές και πολυωνυμικές γραμμές τάσης.

Για παράδειγμα, ένα μοντέλο κόστους παραγωγής ενδέχεται να πρέπει να ξεκινά με γνωστά σταθερά κόστη 100, ακόμα και όταν μετρήσεις σε μη μηδενικούς όγκους παραγωγής υποδηλώνουν διαφορετική βάση. Για μια γραμμική γραμμή τάσης, ο καθορισμός της τομής περιορίζει την εξίσωση `y = ax + b` στο `b = 100`; η κλίση προσαρμόζεται στα δεδομένα υπό αυτήν την περιοριστική συνθήκη. Δεν μετακινεί απλώς μια ήδη προσαρμοσμένη γραμμή. Οι ρυθμίσεις διασταύρωσης αξόνων ελέγχουν πού συναντιούνται οι άξονες του διαγράμματος, όχι τους συντελεστές της προσαρμοσμένης γραμμής τάσης.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα διασποράς (XY) με όγκους παραγωγής από 1 έως 4 και κόστη 170, 200, 230 και 260. Αποθηκεύει το διάγραμμα με την προεπιλεγμένη αυτόματη τομή, ορίζει την τομή στο 100 και αποθηκεύει ένα δεύτερο PPTX. Τα δύο αρχεία διαφέρουν μόνο στη ρύθμιση της τομής. Η γραμμή τάσης εμφανίζει την εξίσωσή της και επεκτείνεται πίσω στο X = 0.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Με αυτόματο υπολογισμό, αυτά τα δεδομένα παράγουν `y = 30x + 140`. Ο ορισμός της τομής στο 100 δημιουργεί περίπου `y = 43.33x + 100`: η προσαρμοσμένη τιμή στο μηδέν ταιριάζει με τη γνωστή βάση, ενώ η γραμμή δεν περνά πλέον από κάθε σημείο δεδομένων.

| Αυτόματη τομή | Σταθερή τομή 100 |
| --- | --- |
| ![Γραμμική γραμμή τάσης με αυτόματα υπολογισμένη τομή 140](intercept-automatic.png) | ![Γραμμική γραμμή τάσης με σταθερή τομή 100](intercept-fixed.png) |

Και οι δύο εικόνες χρησιμοποιούν τα ίδια δεδομένα και κλίμακες αξόνων. Οι γραμμές τάσης επεκτείνονται πίσω στο X = 0 για να εμφανίσουν τις τομές τους.

Από προεπιλογή, το [getIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#getIntercept--) επιστρέφει `Double.NaN`, που αντιπροσωπεύει μια ακαθορισμένη τομή αντί για μηδέν. Η τομή υπολογίζεται στη συνέχεια αυτόματα από τα δεδομένα.

## **Προσθήκη Προσαρμοσμένης Γραμμής**

Μια προσαρμοσμένη γραμμή είναι ένα σχήμα σχεδιασμένο πάνω από το διάγραμμα, αντί για γραμμή τάσης που υπολογίζεται από τα δεδομένα της σειράς. Αυτό το παράδειγμα χρησιμοποιεί το [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) για να προσθέσει μια οριζόντια γραμμή στη διαφάνεια πάνω από το διάγραμμα. Η θέση της γραμμής καθορίζεται στις συντεταγμένες της διαφάνειας, μετρημένες σε points, έτσι ώστε να ξεκινά στο αριστερό άκρο του διαγράμματος και να βρίσκεται στη μέση του ύψους του διαγράμματος. Το πλάτος της ταιριάζει με το πλάτος του διαγράμματος. Το [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) δίνει στη γραμμή ένα συμπαγές κόκκινο χρώμα.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Τι σημαίνουν οι όροι 'forward' και 'backward' για μια γραμμή τάσης;**

Αποτελούν τα μήκη της γραμμής τάσης που προβάλλονται προς τα εμπρός/προς τα πίσω: για διαγράμματα διασποράς (XY) — σε μονάδες άξονα· για μη διαγράμματα διασποράς — σε αριθμό κατηγοριών. Επιτρέπονται μόνο μη αρνητικές τιμές.

**Θα διατηρηθεί η γραμμή τάσης κατά την εξαγωγή της παρουσίασης σε PDF ή SVG, ή κατά την απόδοση μιας διαφάνειας σε εικόνα;**

Ναι. Το Aspose.Slides μετατρέπει τις παρουσιάσεις σε [PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/) ή [SVG](/slides/el/androidjava/render-a-slide-as-an-svg-image/) και αποδίδει τα διαγράμματα σε εικόνες· οι γραμμές τάσης, ως μέρος του διαγράμματος, διατηρούνται κατά αυτές τις λειτουργίες. Διατίθεται επίσης μια μέθοδος για [εξάγετε εικόνα του διαγράμματος](/slides/el/androidjava/create-shape-thumbnails/).