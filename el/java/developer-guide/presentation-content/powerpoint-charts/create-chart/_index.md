---
title: Δημιουργία ή Ενημέρωση Διαγραμμάτων Παρουσίασης PowerPoint σε Java
linktitle: Δημιουργία ή Ενημέρωση Διαγραμμάτων
type: docs
weight: 10
url: /el/java/create-chart/
keywords:
- προσθήκη διαγράμματος
- δημιουργία διαγράμματος
- επεξεργασία διαγράμματος
- αλλαγή διαγράμματος
- ενημέρωση διαγράμματος
- διασκορπισμένο διάγραμμα
- διάγραμμα πίτας
- γραμμικό διάγραμμα
- διάγραμμα χάρτη δέντρου
- διάγραμμα μετοχών
- διάγραμμα κουτί‑κασέ
- διάγραμμα χωνιού
- διάγραμμα ηλιοστάσιου
- ιστογράφημα
- διάγραμμα ραδιογραφίας
- πολυκατηγορικό διάγραμμα
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Java. Προσθέστε, μορφοποιήστε και επεξεργαστείτε διαγράμματα με πρακτικά παραδείγματα κώδικα σε Java."
---
## **Επισκόπηση**

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να δημιουργείτε και να προσαρμόζετε διαγράμματα χρησιμοποιώντας το Aspose.Slides for Java. Θα μάθετε πώς να προσθέτετε προγραμματιστικά ένα διάγραμμα σε μια διαφάνεια, να το γεμίζετε με δεδομένα και να εφαρμόζετε διάφορες επιλογές μορφοποίησης για να ταιριάζει με τις συγκεκριμένες απαιτήσεις σχεδίασής σας. Σε όλο το άρθρο, λεπτομερή παραδείγματα κώδικα απεικονίζουν κάθε βήμα, από την αρχικοποίηση της παρουσίασης και του αντικειμένου διαγράμματος μέχρι τη διαμόρφωση σειρών, αξόνων και υπομνημάτων. Ακολουθώντας αυτόν τον οδηγό, θα αποκτήσετε καλή κατανόηση του πώς να ενσωματώνετε δυναμική δημιουργία διαγραμμάτων στις εφαρμογές Java, βελτιώνοντας τη διαδικασία δημιουργίας παρουσιάσεων βασισμένων σε δεδομένα.

## **Δημιουργία Διαγράμματος**

Τα διαγράμματα βοηθούν τους ανθρώπους να οπτικοποιούν γρήγορα δεδομένα και να εξάγουν συμπεράσματα που μπορεί να μην είναι άμεσα εμφανή από έναν πίνακα ή λογιστικό φύλλο.

**Γιατί να Δημιουργούμε Διαγράμματα;**

Με τα διαγράμματα μπορείτε:

* να συγκεντρώσετε, συμπιέσετε ή συνοψίσετε μεγάλες ποσότητες δεδομένων σε μία διαφάνεια της παρουσίασης·
* να αποκαλύψετε μοτίβα και τάσεις στα δεδομένα·
* να καταλάβετε τη κατεύθυνση και την ορμή των δεδομένων με την πάροδο του χρόνου ή ως προς μια συγκεκριμένη μονάδα μέτρησης·
* να εντοπίσετε ακραίες τιμές, αποκλίσεις, σφάλματα και άσχετα δεδομένα·
* να επικοινωνήσετε ή να παρουσιάσετε πολύπλοκα δεδομένα.

Στο PowerPoint μπορείτε να δημιουργήσετε διαγράμματα μέσω της λειτουργίας *Insert*, η οποία παρέχει πρότυπα για τον σχεδιασμό πολλών τύπων διαγραμμάτων. Χρησιμοποιώντας το Aspose.Slides, μπορείτε να δημιουργήσετε τόσο κανονικά διαγράμματα (βασισμένα σε δημοφιλείς τύπους) όσο και προσαρμοσμένα διαγράμματα.

{{% alert color="info" title="Note" %}}

Χρησιμοποιήστε την απαρίθμηση [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) στο πακέτο [com.aspose.slides](https://reference.aspose.com/slides/java/com.aspose.slides/). Οι τιμές σε αυτή την απαρίθμηση αντιστοιχούν σε διαφορετικούς τύπους διαγραμμάτων.

{{% /alert %}}

### **Δημιουργία Σωρευμένων Στήλων (Clustered Column)**

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) για να δημιουργήσει ένα διάγραμμα σωρευμένων στηλών που συγκρίνει δύο σειρές σε τρεις κατηγορίες. Οι σειρές χρησιμοποιούν κόκκινο και πράσινο γέμισμα, και οι ετικέτες δείχνουν τα ονόματα κατηγοριών, των σειρών και τις τιμές. Ο δείκτης φύλλου εργασίας 0 αναφέρεται στο πρώτο φύλλο του ενσωματωμένου βιβλίου διαγραμμάτων.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());
    seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    IChartDataCell categoryCell = workbook.getCell(worksheetIndex, 1, 0, "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 2, 0, "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 3, 0, "Category 3");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 1, 20);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 50);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    series = chart.getChartData().getSeries().get_Item(1);

    valueCell = workbook.getCell(worksheetIndex, 1, 2, 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 2, 10);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 2, 60);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(new Color(0, 128, 0));

    IDataLabel label = series.getDataPoints().get_Item(0).getLabel();
    label.getDataLabelFormat().setShowCategoryName(true);

    label = series.getDataPoints().get_Item(1).getLabel();
    label.getDataLabelFormat().setShowSeriesName(true);

    label = series.getDataPoints().get_Item(2).getLabel();
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setShowSeriesName(true);
    label.getDataLabelFormat().setSeparator("/");

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The Clustered Column chart](clustered_column_chart.png)

### **Δημιουργία Διασκορπισμένων Διαγραμμάτων (Scatter)**

Τα διασκορπισμένα διαγράμματα (γνωστά και ως scatter plots ή διαγράμματα x‑y) χρησιμοποιούνται συχνά για τον έλεγχο μοτίβων ή τη βολή συσχετισμών μεταξύ δύο μεταβλητών.

Χρησιμοποιήστε scatter διάγραμμα όταν:

* Διαθέτετε ζευγαρωμένα αριθμητικά δεδομένα·
* Διαθέτετε δύο μεταβλητές που ταιριάζουν καλά μεταξύ τους·
* Θέλετε να διαπιστώσετε εάν οι δύο μεταβλητές σχετίζονται·
* Έχετε ανεξάρτητη μεταβλητή που έχει πολλαπλές τιμές για μια εξαρτημένη μεταβλητή.

Αυτό το παράδειγμα σχεδιάζει δύο σύνολα τιμών x‑y. Η πρώτη σειρά χρησιμοποιεί ευθείες γραμμές με αστέρια ως σημεία, ενώ η δεύτερη χρησιμοποιεί ομαλές γραμμές με κύκλους· και οι δύο χρησιμοποιούν μέγεθος δείκτη 10, ρυθμισμένο με τη μέθοδο [setSize](https://reference.aspose.com/slides/java/com.aspose.slides/imarker/#setSize-int-). Η μέθοδος [setSymbol](https://reference.aspose.com/slides/java/com.aspose.slides/imarker/#setSymbol-int-) ελέγχει το σχήμα του δείκτη.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 1, 1, "Series 1");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());
    seriesNameCell = workbook.getCell(worksheetIndex, 1, 3, "Series 2");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IChartDataCell xValueCell = workbook.getCell(worksheetIndex, 2, 1, 1);
    IChartDataCell yValueCell = workbook.getCell(worksheetIndex, 2, 2, 3);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 3, 1, 2);
    yValueCell = workbook.getCell(worksheetIndex, 3, 2, 10);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);

    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);

    series = chart.getChartData().getSeries().get_Item(1);

    xValueCell = workbook.getCell(worksheetIndex, 2, 3, 5);
    yValueCell = workbook.getCell(worksheetIndex, 2, 4, 2);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 3, 3, 3);
    yValueCell = workbook.getCell(worksheetIndex, 3, 4, 1);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 4, 3, 2);
    yValueCell = workbook.getCell(worksheetIndex, 4, 4, 2);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 5, 3, 5);
    yValueCell = workbook.getCell(worksheetIndex, 5, 4, 1);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The Scatter chart](scatter_chart.png)

### **Δημιουργία Πιταγώων (Pie)**

Τα διαγράμματα πίτας είναι ιδανικά για την απεικόνιση της σχέσης μέρος‑σε‑ολόστα σε δεδομένα, ιδιαίτερα όταν τα δεδομένα περιέχουν κατηγοριοποιημένες ετικέτες με αριθμητικές τιμές. Ωστόσο, εάν τα δεδομένα σας περιέχουν πολλά τμήματα ή ετικέτες, ίσως θελήσετε να χρησιμοποιήσετε αντί αυτού ένα ραβδογράφημα.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα πίτας με τρεις τριμηνιαίες τιμές. Κάθε φέτα έχει προσαρμοσμένο γέμισμα και περίγραμμα, και οι ετικέτες εμφανίζουν διαφορετικούς συνδυασμούς τιμών, ποσοστών και πληροφοριών σειράς. Η μέθοδος [setFirstSliceAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setFirstSliceAngle-int-) ορίζει την πρώτη φέτα να ξεκινάει από 180 μοίρες.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 20, 20, 500, 300);

    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataCell categoryCell = workbook.getCell(0, 1, 0, "1st Qtr");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 2, 0, "2nd Qtr");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 3, 0, "3rd Qtr");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 1, 20);
    series.getDataPoints().addDataPointForPieSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 50);
    series.getDataPoints().addDataPointForPieSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 30);
    series.getDataPoints().addDataPointForPieSeries(valueCell);

    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);

    IChartDataPoint firstSlice = series.getDataPoints().get_Item(0);
    firstSlice.getFormat().getFill().setFillType(FillType.Solid);
    firstSlice.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);

    firstSlice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    firstSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    firstSlice.getFormat().getLine().setWidth(3.0);
    firstSlice.getFormat().getLine().setStyle(LineStyle.ThinThick);
    firstSlice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDash);

    IChartDataPoint secondSlice = series.getDataPoints().get_Item(1);
    secondSlice.getFormat().getFill().setFillType(FillType.Solid);
    secondSlice.getFormat().getFill().getSolidFillColor().setColor(new Color(165, 42, 42));

    secondSlice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    secondSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    secondSlice.getFormat().getLine().setWidth(3.0);
    secondSlice.getFormat().getLine().setStyle(LineStyle.Single);
    secondSlice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);

    IChartDataPoint thirdSlice = series.getDataPoints().get_Item(2);
    thirdSlice.getFormat().getFill().setFillType(FillType.Solid);
    thirdSlice.getFormat().getFill().getSolidFillColor().setColor(new Color(255, 127, 80));

    thirdSlice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    thirdSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    thirdSlice.getFormat().getLine().setWidth(2.0);
    thirdSlice.getFormat().getLine().setStyle(LineStyle.ThinThin);
    thirdSlice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);

    IDataLabel firstLabel = series.getDataPoints().get_Item(0).getLabel();
    firstLabel.getDataLabelFormat().setShowValue(true);

    IDataLabel secondLabel = series.getDataPoints().get_Item(1).getLabel();
    secondLabel.getDataLabelFormat().setShowValue(true);
    secondLabel.getDataLabelFormat().setShowLegendKey(true);
    secondLabel.getDataLabelFormat().setShowPercentage(true);

    IDataLabel thirdLabel = series.getDataPoints().get_Item(2).getLabel();
    thirdLabel.getDataLabelFormat().setShowSeriesName(true);
    thirdLabel.getDataLabelFormat().setShowPercentage(true);

    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);

    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);

    presentation.save("PieChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The Pie chart](pie_chart.png)

Για να βελτιώσετε την αναγνωσιμότητα των ετικετών εκτός της πίτας, δείτε το [Format Leader Lines](/slides/el/java/chart-data-label/#format-leader-lines) για ένα παράδειγμα που τοποθετεί τις ετικέτες και προσαρμόζει το χρώμα, το πλάτος, τη διαφάνεια και το στυλ διακεκομμένων γραμμών.

### **Δημιουργία Γραμμικών Διαγραμμάτων (Line)**

Τα γραμμικά διαγράμματα (γνωστά και ως line graphs) είναι ιδανικά όταν θέλετε να παρουσιάσετε αλλαγές σε τιμές με την πάροδο του χρόνου. Με ένα γραμμικό διάγραμμα, μπορείτε να συγκρίνετε μεγάλα σύνολα δεδομένων ταυτόχρονα, να παρακολουθείτε αλλαγές και τάσεις, να επισημαίνετε ανωμαλίες σε σειρές και πολλά άλλα.

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) για να δημιουργήσει ένα γραμμικό διάγραμμα με τις προεπιλεγμένες σειρές και κατηγορίες, και στη συνέχεια αποθηκεύει την παρουσίαση ως PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart lineChart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300);

    presentation.save("lineChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Από προεπιλογή, τα σημεία σε ένα γραμμικό διάγραμμα συνδέονται με συνεχόμενες ευθείες γραμμές. Εάν θέλετε τα σημεία να συνδέονται με παύλες, καλέστε τη μέθοδο [setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) με τιμή από την [LineDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart lineChart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
}
finally
{
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The Line chart](line_chart.png)

### **Δημιουργία Διάγραμμα Δέντρου (Tree Map)**

Τα διαγράμματα δέντρου (tree map) είναι ιδανικά για δεδομένα πωλήσεων όταν θέλετε να δείξετε το σχετικό μέγεθος των κατηγοριών και να εστιάσετε γρήγορα στα στοιχεία που συνεισφέρουν περισσότερο σε κάθε κατηγορία.

Αυτό το παράδειγμα δημιουργεί ένα tree map με οκτώ φύλλα ομαδοποιημένα σε τέσσερις κορμούς και δύο κλαδιά. Η μέθοδος [setGroupingItem](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) εκχωρεί κορμούς στο επίπεδο ομαδοποίησης 1 και κλαδιά στο επίπεδο 2. Οι τιμές καθορίζουν το σχετικό μέγεθος των ορθογωνίων, ενώ οι ετικέτες κατηγοριών και οι επικάλυπτες γονικές ετικέτες προσδιορίζουν την ιεραρχία.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Treemap, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Κλαδί 1
    IChartDataCell categoryCell = workbook.getCell(0, "C1", "Leaf1");
    IChartCategory leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    categoryCell = workbook.getCell(0, "C2", "Leaf2");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C3", "Leaf3");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    categoryCell = workbook.getCell(0, "C4", "Leaf4");
    chart.getChartData().getCategories().add(categoryCell);

    // Κλαδί 2
    categoryCell = workbook.getCell(0, "C5", "Leaf5");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    categoryCell = workbook.getCell(0, "C6", "Leaf6");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C7", "Leaf7");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    categoryCell = workbook.getCell(0, "C8", "Leaf8");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    IChartDataCell valueCell = workbook.getCell(0, "D1", 4);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D2", 5);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D3", 3);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D4", 6);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D5", 9);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D6", 9);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D7", 4);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D8", 3);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    presentation.save("Treemap.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The Treemap chart](treemap_chart.png)

### **Δημιουργία Διάγραμμα Καταρράκτη (Waterfall)**

Ένα διάγραμμα καταρράκτη δείχνει πώς θετικές και αρνητικές αλλαγές συνεισφέρουν σε μια τελική τιμή. Για παράδειγμα, η ανάλυση κέρδους μπορεί να ξεκινά με τα έσοδα, να αφαιρεί τα κόστη και να προσθέτει άλλα έσοδα. Τα στήματα αλλαγής «πλέουν» μεταξύ των προηγούμενων και των νέων τρεχουσών τιμών, ενώ τα συνολικά στήματα εκτείνονται από το μηδέν μέχρι τη συσσωρευμένη τιμή.

Η παρακάτω παράδειγμα χρησιμοποιεί ποσά χιλιάδων δολαρίων ΗΠΑ:

| Category | Workbook value | Column type |
| --- | ---: | --- |
| Revenue | 1000 | Increase |
| Cost of sales | -400 | Decrease |
| Gross profit | 600 | Intermediate total |
| Operating expenses | -200 | Decrease |
| Other income | 50 | Increase |
| Net profit | 450 | Final total |

Για να σημειώσετε ένα σημείο ως ενδιάμεσο ή τελικό σύνολο, καλέστε τη μέθοδο [setSetAsTotal](https://reference.aspose.com/slides/java/com.aspose.slides/chartdatapoint/#setSetAsTotal-boolean-) με `true`. Παραχωρήστε το πραγματικό συσσωρευμένο ποσό στο κελί του βιβλίου εργασίας: `600` για το μικτό κέρδος (`1000 - 400`) και `450` για το καθαρό κέρδος (`600 - 200 + 50`). Η μέθοδος σημαδεύει τη στήλη ως σύνολο· δεν υπολογίζει ή γεμίζει την τιμή του κελιού. Μη χρησιμοποιείτε το μηδέν ως placeholder ή άλλες αλλαγές για σημείο συνόλου. Μια στήλη συνόλου εμφανίζει τη συσσωρευμένη τιμή χωρίς να την προσθέτει ξανά στην τρέχουσα τιμή.

Αυτό το πλήρες παράδειγμα Java δημιουργεί ένα διάγραμμα χρησιμοποιώντας το μέλος `Waterfall` του [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/), καθαρίζει τα προεπιλεγμένα δεδομένα και γεμίζει το ενσωματωμένο βιβλίο εργασίας. Ο δείκτης φύλλου `0` επιλέγει το πρώτο φύλλο εργασίας· η στήλη A περιέχει τα ονόματα κατηγοριών και η στήλη B τις τιμές. Κάθε κελί τιμής προστίθεται με τη μέθοδο [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#addDataPointForWaterfallSeries-com.aspose.slides.IChartDataCell-). Οι μηδενικοί δείκτες σημείων `2` και `5` προσδιορίζουν τα ενδιάμεσα και τελικά σύνολα. Καλώντας τη μέθοδο [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) με `true` εμφανίζονται τα ποσά στις στήλες. Δεν απαιτείται εισαγωγική παρουσίαση ή βιβλίο εργασίας.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Waterfall, 20, 20, 680, 200);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Profit breakdown (USD thousands)");
    chart.getChartTitle().setOverlay(false);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    workbook.clear(worksheetIndex);

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Profit");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Waterfall);
    String[] categories = new String[] { "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" };
    double[] values = new double[] { 1000, -400, 600, -200, 50, 450 };

    for (int i = 0; i < categories.length; i++)
    {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categories[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForWaterfallSeries(valueCell);
    }

    // Το τρίτο και το έκτο σημείο αντιπροσωπεύουν σύνολα, όχι πρόσθετες αλλαγές.
    series.getDataPoints().get_Item(2).setSetAsTotal(true);
    series.getDataPoints().get_Item(5).setSetAsTotal(true);
    series.setShowConnectorLines(true);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("WaterfallChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Καλέστε τη μέθοδο σειράς [setShowConnectorLines](https://reference.aspose.com/slides/java/com.aspose.slides/chartseries/#setShowConnectorLines-boolean-) με `true` για να εμφανίσετε γραμμές σύνδεσης διαδοχικών στηλών και να διευκολύνετε την παρακολούθηση της τρέχουσας τιμής. Για απόκρυψη των γραμμών, αντικαταστήστε την κλήση με `series.setShowConnectorLines(false);` πριν αποθηκεύσετε. Αυτό αλλάζει μόνο την ορατότητα των γραμμών, όχι τα δεδομένα ή τα σύνολα.

Η αποθηκευμένη παρουσίαση δείχνει το μικτό κέρδος 600 και το καθαρό κέρδος 450, με τα δύο σύνολα να ξεκινούν από το μηδέν:

![Waterfall chart showing revenue, costs, gross profit of 600, and net profit of 450, with value labels and connector lines](waterfall_chart.png)

### **Δημιουργία Διαγραμμάτων Μετοχών (Stock)**

Τα διαγράμματα μετοχών χρησιμοποιούνται για την εμφάνιση χρηματοοικονομικών δεδομένων όπως τιμές ανοίγματος, υψηλής, χαμηλής και κλεισίματος, βοηθώντας στην ανάλυση τάσεων αγοράς και μεταβλητότητας. Παρέχουν ουσιώδεις πληροφορίες για την απόδοση των μετοχών, βοηθώντας επενδυτές και αναλυτές σε ενημερωμένες αποφάσεις.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα open‑high‑low‑close με τέσσερις σειρές με αυτή τη σειρά και τρεις κατηγορίες. Η μέθοδος [setUpDownBars](https://reference.aspose.com/slides/java/com.aspose.slides/iupdownbarsmanager/#setUpDownBars-boolean-) ενεργοποιεί τις μπάρες ανοδικής/καθοδικής κίνησης, και η μέθοδος [getHiLowLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getHiLowLinesFormat--) ελέγχει τις γραμμές υψηλής‑χαμηλής που δείχνουν το εύρος τιμών, ενώ οι γραμμές των επιμέρους σειρών και οι μικρές οριζόντιες γραμμές πλέγματος κρύβονται.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell categoryCell = workbook.getCell(0, 1, 0, "A");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 2, 0, "B");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 3, 0, "C");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Open");
    chart.getChartData().getSeries().add(seriesNameCell, ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 2, "High");
    chart.getChartData().getSeries().add(seriesNameCell, ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 3, "Low");
    chart.getChartData().getSeries().add(seriesNameCell, ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 4, "Close");
    chart.getChartData().getSeries().add(seriesNameCell, ChartType.OpenHighLowClose);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataCell valueCell = workbook.getCell(0, 1, 1, 72);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 1, 25);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 1, 38);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(1);
    valueCell = workbook.getCell(0, 1, 2, 172);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 2, 57);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 2, 57);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(2);
    valueCell = workbook.getCell(0, 1, 3, 12);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 3, 12);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 3, 13);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(3);
    valueCell = workbook.getCell(0, 1, 4, 25);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 4, 38);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 4, 50);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries stockSeries : chart.getChartData().getSeries())
    {
        stockSeries.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    presentation.save("Stock-chart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The Stock chart](stock_chart.png)

### **Δημιουργία Διαγραμμάτων Κουτί‑Κασέ (Box and Whisker)**

Τα διαγράμματα κουτί‑κασέ χρησιμοποιούνται για την παρουσίαση της κατανομής των δεδομένων συνοψίζοντας βασικά στατιστικά μέτρα, όπως η διάμεσος, τα τεταρτημόρια και πιθανά ακραία σημεία. Είναι ιδιαίτερα χρήσιμα στην εξερευνητική ανάλυση δεδομένων και στις στατιστικές μελέτες για τη γρήγορη κατανόηση της μεταβλητότητας και την ταυτοποίηση ανωμαλιών.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα κουτί‑κασέ από έξι τιμές. Η μέθοδος [setQuartileMethod](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setQuartileMethod-int-) επιλέγει την αποκλειστική μέθοδο υπολογισμού τεταρτημορίων. Το παράδειγμα ενεργοποιεί επίσης γραμμές μέσου όρου, δείκτες μέσου, εσωτερικά σημεία και σημεία ακραίων τιμών.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A1", "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A2", "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A3", "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A4", "Category 4");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A5", "Category 5");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A6", "Category 6");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);

    IChartDataCell valueCell = workbook.getCell(0, "B1", 15);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B2", 41);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B3", 16);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B4", 10);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B5", 23);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B6", 16);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

### **Δημιουργία Διάγραμμα Στωκ (Funnel)**

Τα διαγράμματα στωκ χρησιμοποιούνται για την οπτικοποίηση διαδικασιών που περιλαμβάνουν διαδοχικά στάδια, όπου ο όγκος των δεδομένων μειώνεται καθώς προχωρά από το ένα βήμα στο επόμενο. Είναι ιδιαίτερα χρήσιμα για την ανάλυση ποσοστών μετατροπής, την ταυτοποίηση bottleneck και την παρακολούθηση της αποδοτικότητας διαδικασιών πωλήσεων ή μάρκετινγκ.

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) για να προσθέσει ένα διάγραμμα στωκ στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Αντικαθιστά τα προεπιλεγμένα δεδομένα με έξι κατηγορίες και τιμές από 50 έως 500, έπειτα αποθηκεύει την ενημερωμένη παρουσίαση. Η εισαγόμενη παρουσίαση πρέπει να περιέχει τουλάχιστον μία διαφάνεια.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A1", "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A2", "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A3", "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A4", "Category 4");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A5", "Category 5");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A6", "Category 6");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    IChartDataCell valueCell = workbook.getCell(0, "B1", 50);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B2", 100);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B3", 200);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B4", 300);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B5", 400);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B6", 500);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);

    presentation.save("Funnel.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The Funnel chart](funnel_chart.png)

### **Δημιουργία Ηλιοστάσιων Διαγραμμάτων (Sunburst)**

Τα ηλιοστάσια διαγράμματα χρησιμοποιούνται για την οπτικοποίηση ιεραρχικών δεδομένων, εμφανίζοντας επίπεδα ως κυκλικές εσοχές. Βοηθούν να απεικονιστούν σχέσεις μέρος‑σε‑ολόστα και είναι ιδανικά για την παρουσίαση ένθετων κατηγοριών και υποκατηγοριών με σαφή, συμπαγή μορφή.

Αυτό το παράδειγμα δημιουργεί ένα ηλιοστάσιο διάγραμμα με οκτώ φύλλα ομαδοποιημένα σε τέσσερις κορμούς και δύο κλαδιά. Η μέθοδος [setGroupingItem](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) εκχωρεί κορμούς στο επίπεδο 1 και κλαδιά στο επίπεδο 2. Οι ετικέτες κατηγοριών προσδιορίζουν τα τμήματα, και οι τιμές καθορίζουν το σχετικό μέγεθος.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Sunburst, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Κλαδί 1
    IChartDataCell categoryCell = workbook.getCell(0, "C1", "Leaf1");
    IChartCategory leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    categoryCell = workbook.getCell(0, "C2", "Leaf2");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C3", "Leaf3");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    categoryCell = workbook.getCell(0, "C4", "Leaf4");
    chart.getChartData().getCategories().add(categoryCell);

    // Κλαδί 2
    categoryCell = workbook.getCell(0, "C5", "Leaf5");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    categoryCell = workbook.getCell(0, "C6", "Leaf6");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C7", "Leaf7");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    categoryCell = workbook.getCell(0, "C8", "Leaf8");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    IChartDataCell valueCell = workbook.getCell(0, "D1", 4);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D2", 5);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D3", 3);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D4", 6);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D5", 9);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D6", 9);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D7", 4);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D8", 3);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);

    presentation.save("Sunburst.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The Sunburst chart](sunburst_chart.png)

### **Δημιουργία Ιστογράμματος (Histogram)**

Τα ιστογράμματα δείχνουν πώς οι αριθμητικές τιμές κατανέμονται σε διαστήματα (bins). Για μηνιαίες αναφορές χρόνου επεξεργασίας παραγγελιών, χρησιμοποιήστε το ίδιο πλάτος bin και τα όρια για να διατηρήσετε συνεπή τα διαστήματα και να κάνετε τις κατανομές πιο συγκρίσιμες.

Καλέστε τη μέθοδο [setAggregationType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAggregationType-int-) στον οριζόντιο άξονα με λειτουργία από την [AxisAggregationType](https://reference.aspose.com/slides/java/com.aspose.slides/axisaggregationtype/). Η μέθοδος [setBinWidth](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setBinWidth-double-) εφαρμόζεται μόνο σε `ByBinWidth`; η μέθοδος [setNumberOfBins](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberOfBins-long-) εφαρμόζεται μόνο σε `ByNumberOfBins`. Χρησιμοποιήστε `Automatic` για να αφήσετε το διάγραμμα να επιλέξει τα bins.

#### **Χρήση Σταθερού Πλάτους Bin**

Αυτό το παράδειγμα ομαδοποιεί χρόνους επεξεργασίας σε διαστήματα 10 λεπτών, με ξεχωριστά bins για χρόνους ≤10 λεπτά και >40 λεπτά. Ενεργοποιήστε αυτά τα bins με τις μεθόδους [setUnderflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setUnderflowBin-boolean-) και [setOverflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setOverflowBin-boolean-). Όταν παρέχετε ρητά όρια μέσω των μεθόδων [setUnderflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setUnderflowBin-double-) και [setOverflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setOverflowBin-double-), καλέστε τις μεθόδους [setAutomaticUnderflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticUnderflowBin-boolean-) και [setAutomaticOverflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticOverflowBin-boolean-) με `false`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200);

    chart.setLegend(false);
    chart.setTitle(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
    for (int i = 0; i < values.length; i++)
    {
        IChartDataCell valueCell = workbook.getCell(0, i, 0, values[i]);
        series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setAggregationType(AxisAggregationType.ByBinWidth);
    axis.setBinWidth(10);
    axis.setUnderflowBin(true);
    axis.setAutomaticUnderflowBin(false);
    axis.setUnderflowBin(10);
    axis.setOverflowBin(true);
    axis.setAutomaticOverflowBin(false);
    axis.setOverflowBin(40);

    presentation.save("Histogram-bin-width.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Η παρουσίαση στο PowerPoint δείχνει μετρήσεις bins **3, 4, 4, 4, και 2**. Το bin υποροής περιλαμβάνει `5, 10, 10`, οπότε το όριο του είναι περιληπτικό. Το bin υπερχείλισης περιλαμβάνει μόνο `41, 50`, οπότε το όριό του είναι αποκλειστικό· και οι τιμές ίσες του `40` παραμένουν στο προηγούμενο διάστημα. Τα εσωτερικά bins περιέχουν τιμές μεγαλύτερες από το κατώτερο όριο και μικρότερες ή ίσες με το ανώτερο όριο.

![Histogram with 10-minute bins and explicit underflow and overflow thresholds](histogram_bin_width.png)

#### **Καθορισμός Αριθμού Bins**

Για ένα σταθερό επίπεδο λεπτομέρειας αντί για σταθερά διαστήματα, ζητήστε πέντε bins για τα ίδια δεδομένα. Αυτό το παράδειγμα αφήνει τα bins υποροής και υπερχείλισης απενεργοποιημένα. Το διάγραμμα καθορίζει το πλάτος από το εύρος των δεδομένων, οπότε τα όρια μπορούν να αλλάξουν μεταξύ των αναφορών.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200);

    chart.setLegend(false);
    chart.setTitle(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
    for (int i = 0; i < values.length; i++)
    {
        IChartDataCell valueCell = workbook.getCell(0, i, 0, values[i]);
        series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setAggregationType(AxisAggregationType.ByNumberOfBins);
    axis.setNumberOfBins(5);

    presentation.save("Histogram-bin-count.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Τα πέντε bins έχουν μετρήσεις **4, 4, 4, 4, και 1**. Συγκρίνετε αυτή τη κατανομή με το αποτέλεσμα σταθερού πλάτους παραπάνω: τα εισαγόμενα δεδομένα είναι ίδια, αλλά τα όρια διαφέρουν.

![Histogram with five bins calculated from the same data](histogram_bin_count.png)

### **Δημιουργία Διαγραμμάτων Ραδιογραφίας (Radar)**

Τα διαγράμματα ραδιογραφίας χρησιμοποιούνται για την εμφάνιση πολυμεταβλητών δεδομένων σε δισδιάστατη μορφή, επιτρέποντας εύκολη σύγκριση πολλαπλών μεταβλητών ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα για την ταυτοποίηση μοτίβων, δυνάμεων και αδυναμιών σε πολλαπλούς δείκτες απόδοσης ή χαρακτηριστικά.

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) για να δημιουργήσει ένα radar διάγραμμα με τις προεπιλεγμένες σειρές και κατηγορίες, και στη συνέχεια αποθηκεύει την παρουσίαση ως PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addChart(ChartType.Radar, 20, 20, 500, 300);

    presentation.save("Radar-chart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The Radar chart](radar_chart.png)

### **Δημιουργία Πολυκατηγορικών Διαγραμμάτων**

Τα πολυκατηγορικά διαγράμματα χρησιμοποιούνται για την παρουσίαση δεδομένων που αφορούν περισσότερες από μία κατηγοριοποιημένες ομαδοποιήσεις, επιτρέποντάς σας να συγκρίνετε τιμές σε πολλές διαστάσεις ταυτόχρονα. Είναι ιδιαίτερα χρήσιμα όταν πρέπει να αναλύσετε τάσεις και σχέσεις σε σύνθετα, πολυεπίπεδα σύνολα δεδομένων.

Αυτό το παράδειγμα δημιουργεί ένα σωρευμένο διάγραμμα στήλης με οκτώ κατηγορίες, τοποθετημένες σε τέσσερα ζεύγη. Η μέθοδος [setGroupingItem](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) δίνει σε κάθε ζεύγος μια κοινή ετικέτα στο επίπεδο ομαδοποίησης 1, παράγοντας έναν άξονα κατηγοριών με τόσο ατομικές όσο και ομαδικές ετικέτες.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    int worksheetIndex = 0;

    IChartDataCell categoryCell = workbook.getCell(0, "c2", "A");
    IChartCategory category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    categoryCell = workbook.getCell(0, "c3", "B");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c4", "C");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    categoryCell = workbook.getCell(0, "c5", "D");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c6", "E");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    categoryCell = workbook.getCell(0, "c7", "F");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c8", "G");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    categoryCell = workbook.getCell(0, "c9", "H");
    category = chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell seriesNameCell = workbook.getCell(0, "D1", "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    IChartDataCell valueCell = workbook.getCell(worksheetIndex, "D2", 10);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D3", 20);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D4", 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D5", 40);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D6", 50);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D7", 60);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D8", 70);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D9", 80);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The multi category chart](multi_category_chart.png)

### **Δημιουργία Χάρτες Διαγράμματα (Map)**

Τα διαγράμματα χάρτη χρησιμοποιούνται για την οπτικοποίηση γεωγραφικών δεδομένων χαρτογραφώντας πληροφορίες σε συγκεκριμένες τοποθεσίες όπως χώρες, πολιτείες ή πόλεις. Είναι ιδιαίτερα χρήσιμα για την ανάλυση περιφερειακών τάσεων, δημογραφικών δεδομένων και χωρικών κατανομών με σαφή, ελκυστική οπτική μορφή.

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) για να δημιουργήσει ένα χάρτη διάγραμμα με τα προεπιλεγμένα γεωγραφικά δεδομένα και το αποθηκεύει για προβολή στο PowerPoint.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Map, 20, 20, 500, 300);

    presentation.save("mapChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The Map chart](map_chart.png)

{{% alert color="info" title="Note" %}}

Η εικόνα παραπάνω δείχνει την αποθηκευμένη παρουσίαση ανοιγμένη στο PowerPoint. Το Aspose.Slides γράφει σωστά το διάγραμμα χάρτη και τα δεδομένα του, αλλά δεν σχεδιάζει τα διαγράμματα χάρτη από μόνο του: όταν μια διαφάνεια που περιέχει ένα τέτοιο διάγραμμα αποδοθεί ως εικόνα ή μετατραπεί σε PDF ή SVG, η περιοχή του διαγράμματος εμφανίζεται κενή. Τα άλλα σχήματα στην ίδια διαφάνεια δεν επηρεάζονται.

{{% /alert %}}

### **Δημιουργία Συνδυαστικών Διαγραμμάτων**

Ένα συνδυαστικό διάγραμμα (ή combo chart) συνδυάζει δύο ή περισσότερους τύπους διαγραμμάτων σε ένα γράφημα. Αυτό το διάγραμμα σάς επιτρέπει να τονίσετε, συγκρίνετε ή εξετάσετε διαφορές μεταξύ δύο ή περισσότερων συνόλων δεδομένων, βοηθώντας να εντοπίσετε σχέσεις μεταξύ τους.

![The combination chart](combination_chart.png)

Αυτό το παράδειγμα συνδυάζει δύο σειρές σωρευμένων στηλών με μια σειρά γραμμής σε τέσσερις κατηγορίες. Οι στήλες χρησιμοποιούν τον κύριο κατακόρυφο άξονα, ενώ η μέθοδος [setPlotOnSecondAxis](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setPlotOnSecondAxis-boolean-) τοποθετεί τη γραμμή σε δευτερεύον κατακόρυφο άξονα στα δεξιά. Οι βοηθητικές συναρτήσεις διαμορφώνουν τον τίτλο, το υπόμνημα, τις ετικέτες άξονα και τις γραμμές πλέγματος.

```java
import com.aspose.slides.*;
import java.awt.Color;

class ComboChartExample
{
    void createComboChart()
    {
        Presentation presentation = new Presentation();
        try
        {
            IChart chart = createChartWithFirstSeries(presentation.getSlides().get_Item(0));

            addSecondSeriesToChart(chart);
            addThirdSeriesToChart(chart);

            setPrimaryAxesFormat(chart);
            setSecondaryAxesFormat(chart);

            presentation.save("combo-chart.pptx", SaveFormat.Pptx);
        }
        finally
        {
            presentation.dispose();
        }
    }

    IChart createChartWithFirstSeries(ISlide slide)
    {
        IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

        chart.setTitle(true);
        chart.getChartTitle().addTextFrameForOverriding("Chart Title");
        chart.getChartTitle().setOverlay(false);
        IPortionFormat portionFormat = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
        portionFormat.setFontBold(NullableBool.False);
        portionFormat.setFontHeight(18f);

        chart.getLegend().setPosition(LegendPositionType.Bottom);
        chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

        chart.getChartData().getSeries().clear();
        chart.getChartData().getCategories().clear();

        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        int worksheetIndex = 0;

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, 1, 0, "Category 1");
        chart.getChartData().getCategories().add(categoryCell);
        categoryCell = workbook.getCell(worksheetIndex, 2, 0, "Category 2");
        chart.getChartData().getCategories().add(categoryCell);
        categoryCell = workbook.getCell(worksheetIndex, 3, 0, "Category 3");
        chart.getChartData().getCategories().add(categoryCell);
        categoryCell = workbook.getCell(worksheetIndex, 4, 0, "Category 4");
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
        IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

        series.getParentSeriesGroup().setOverlap((byte) -25);
        series.getParentSeriesGroup().setGapWidth(220);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 1, 4.3);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 2, 1, 2.5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 3, 1, 3.5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 4, 1, 4.5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);

        return chart;
    }

    void addSecondSeriesToChart(IChart chart)
    {
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        final int worksheetIndex = 0;

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
        IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

        series.getParentSeriesGroup().setOverlap((byte) -25);
        series.getParentSeriesGroup().setGapWidth(220);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 2, 2.4);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 2, 2, 4.4);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 3, 2, 1.8);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 4, 2, 2.8);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    void addThirdSeriesToChart(IChart chart)
    {
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        final int worksheetIndex = 0;

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
        IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 3, 2.0);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 2, 3, 2.0);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 3, 3, 3.0);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 4, 3, 5.0);
        series.getDataPoints().addDataPointForLineSeries(valueCell);

        series.setPlotOnSecondAxis(true);
    }

    void setPrimaryAxesFormat(IChart chart)
    {
        IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
        horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
        horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

        setAxisTitle(horizontalAxis, "X Axis");

        IAxis verticalAxis = chart.getAxes().getVerticalAxis();
        verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
        verticalAxis.getFormat().getLine().setFillType(FillType.NoFill);

        setAxisTitle(verticalAxis, "Y Axis 1");

        ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
        majorGridLinesFormat.setFillType(FillType.Solid);
        majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
    }

    void setSecondaryAxesFormat(IChart chart)
    {
        IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
        secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
        secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
        secondaryHorizontalAxis.setVisible(false);
        secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
        secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

        IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
        secondaryVerticalAxis.setPosition(AxisPositionType.Right);
        secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
        secondaryVerticalAxis.getFormat().getLine().setFillType(FillType.NoFill);
        secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
        secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

        setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
    }

    void setAxisTitle(IAxis axis, String axisTitle)
    {
        axis.setTitle(true);
        axis.getTitle().setOverlay(false);
        IPortionFormat titlePortionFormat = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
        titlePortionFormat.setFontBold(NullableBool.False);
        titlePortionFormat.setFontHeight(12f);
    }
}

ComboChartExample example = new ComboChartExample();
example.createComboChart();
```

## **Ενημέρωση Διαγραμμάτων**

Το Aspose.Slides for Java σας επιτρέπει να ενημερώνετε διαγράμματα PowerPoint τροποποιώντας τα δεδομένα, τη μορφή και το στυλ του διαγράμματος. Αυτή η λειτουργικότητα απλοποιεί τη διαδικασία διατήρησης των παρουσιάσεων ενημερωμένων με δυναμικό περιεχόμενο και διασφαλίζει ότι τα διαγράμματα αντανακλούν ακριβώς τα τρέχοντα δεδομένα και τα οπτικά πρότυπα.

Αυτό το παράδειγμα ενημερώνει το διάγραμμα με όνομα «My chart» στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης. Απαιτεί δύο σειρές στηλών με τρία σημεία δεδομένων η κάθε μια, με ετικέτες κατηγοριών στη στήλη A και ονόματα σειρών στην πρώτη γραμμή του πρώτου φύλλου εργασίας. Το παράδειγμα χρησιμοποιεί τη μέθοδο [getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-java.lang.Object-) για να αλλάξει τα κελιά του βιβλίου, ενημερώνει τις τιμές των σειρών, προσθέτει μια τρίτη σειρά και αλλάζει το διάγραμμα σε σωρευμένους κυλίνδρους μέσω της μεθόδου [setType](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setType-int-).

```java
import com.aspose.slides.*;

final String chartName = "My chart";

Presentation presentation = new Presentation("ExistingChart.pptx");
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes())
    {
        if (shape instanceof IChart && chartName.equals(shape.getName()))
        {
            IChart chart = (IChart) shape;
            int worksheetIndex = 0;

            IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

            workbook.getCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.getCell(worksheetIndex, 2, 0, "Modified Category 2");

            IChartSeries series = chart.getChartData().getSeries().get_Item(0);

            workbook.getCell(worksheetIndex, 0, 1, "New_Series 1");
            series.getDataPoints().get_Item(0).getValue().setData(90);
            series.getDataPoints().get_Item(1).getValue().setData(123);
            series.getDataPoints().get_Item(2).getValue().setData(44);

            series = chart.getChartData().getSeries().get_Item(1);

            workbook.getCell(worksheetIndex, 0, 2, "New_Series 2");
            series.getDataPoints().get_Item(0).getValue().setData(23);
            series.getDataPoints().get_Item(1).getValue().setData(67);
            series.getDataPoints().get_Item(2).getValue().setData(99);

            IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
            series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

            IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 3, 20);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
            valueCell = workbook.getCell(worksheetIndex, 2, 3, 50);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
            valueCell = workbook.getCell(worksheetIndex, 3, 3, 30);
            series.getDataPoints().addDataPointForBarSeries(valueCell);

            chart.setType(ChartType.ClusteredCylinder);
        }
    }

    presentation.save("AsposeChartModified.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **Ορισμός Περιοχής Δεδομένων για Διάγραμμα**

Για να ελέγξετε την περιοχή που χρησιμοποιείται ήδη από ένα υπάρχον διάγραμμα, δείτε το [Retrieve a Chart's Data Range](/slides/el/java/chart-workbook/#retrieve-a-charts-data-range).

Το Aspose.Slides for Java παρέχει την ευελιξία να ορίσετε μια συγκεκριμένη περιοχή δεδομένων από ένα φύλλο εργασίας ως πηγή για τα δεδομένα του διαγράμματός σας. Αυτό σημαίνει ότι μπορείτε να αντιστοιχίσετε απευθείας ένα τμήμα του φύλλου σας στο διάγραμμα, ελέγχοντας ποια κελιά συνεισφέρουν στις σειρές και τις κατηγορίες του διαγράμματος. Ως αποτέλεσμα, μπορείτε εύκολα να ενημερώνετε και να συγχρονίζετε τα διαγράμματά σας με τις τελευταίες αλλαγές στα δεδομένα, εξασφαλίζοντας ότι οι παρουσιάσεις PowerPoint αντικατοπτρίζουν πληροφορίες ακριβείς και ενημερωμένες.

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) για να ορίσει την πηγή δεδομένων του διαγράμματος με όνομα «My chart» στην πρώτη διαφάνεια μιας υπάρχουσας παρουσίασης σε `Sheet1!A1:B4`. Το βιβλίο διαγράμματος πρέπει να περιέχει αυτό το φύλλο και μια πληθυσμένη περιοχή με επικεφαλίδα σειράς στην πρώτη γραμμή, ετικέτες κατηγοριών στη στήλη A και τρεις τιμές στη στήλη B.

```java
import com.aspose.slides.*;

final String chartName = "My chart";

Presentation presentation = new Presentation("ExistingChart.pptx");
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes())
    {
        if (shape instanceof IChart && chartName.equals(shape.getName()))
        {
            IChart chart = (IChart) shape;
            chart.getChartData().setRange("Sheet1!A1:B4");
        }
    }

    presentation.save("SetDataRange.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **Χρήση Προεπιλεγμένων Δεικτών σε Διαγράμματα**

Όταν χρησιμοποιείτε προεπιλεγμένους δείκτες σε διαγράμματα, κάθε σειρά διαγράμματος λαμβάνει αυτόματα διαφορετικό προεπιλεγμένο σύμβολο δείκτη.

Αυτό το παράδειγμα χρησιμοποιεί τη μέθοδο [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) για να δημιουργήσει ένα διάγραμμα με δύο σειρές γραμμής και υπόμνημα. Οι ρυθμίσεις του δείκτη που προσπελαύνονται μέσω της μεθόδου [getMarker](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getMarker--) διατηρούν τα αυτόματα εκχωρημένα σύμβολα δεικτών. Η πρώτη σειρά περιλαμβάνει μια αρνητική τιμή και μια ελλιπή τιμή, που αντιπροσωπεύεται από `null`, ενώ η δεύτερη έχει τιμή για κάθε κατηγορία.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    IChartDataCell categoryCell = workbook.getCell(0, 1, 0, "C1");
    chart.getChartData().getCategories().add(categoryCell);
    IChartDataCell valueCell = workbook.getCell(0, 1, 1, 24);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 2, 0, "C2");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 2, 1, 23);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 3, 0, "C3");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 3, 1, -10);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 4, 0, "C4");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 4, 1, null);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    seriesNameCell = workbook.getCell(0, 0, 2, "Series 2");
    IChartSeries secondSeries = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    valueCell = workbook.getCell(0, 1, 2, 30);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 2, 10);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 2, 60);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 4, 2, 40);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις (FAQ)**

**Τι τύποι διαγραμμάτων υποστηρίζει το Aspose.Slides for Java;**

Το Aspose.Slides for Java υποστηρίζει ευρύ φάσμα τύπων διαγραμμάτων, συμπεριλαμβανομένων bar, line, pie, area, scatter, histogram, radar και πολλών άλλων. Αυτή η ευελιξία σας επιτρέπει να επιλέξετε τον πιο κατάλληλο τύπο διάγραμμα για τις ανάγκες οπτικοποίησης των δεδομένων σας.

**Πώς προσθέτω νέο διάγραμμα σε μια διαφάνεια;**

Για να προσθέσετε διάγραμμα, πρώτα δημιουργείτε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), ανακτάτε τη ζητούμενη διαφάνεια με το δείκτη της και, στη συνέχεια, καλείτε τη μέθοδο για προσθήκη διαγράμματος, καθορίζοντας τον τύπο διαγράμματος και τα αρχικά δεδομένα. Αυτή η διαδικασία ενσωματώνει το διάγραμμα απευθείας στην παρουσίασή σας.

**Πώς μπορώ να ενημερώσω τα δεδομένα που προβάλλονται σε ένα διάγραμμα;**

Μπορείτε να ενημερώσετε τα δεδομένα ενός διαγράμματος προσπελάζοντας το βιβλίο δεδομένων του ([IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/)), καθαρίζοντας τυχόν προεπιλεγμένες σειρές και κατηγορίες, και προσθέτοντας τα προσαρμοσμένα σας δεδομένα. Αυτό σας επιτρέπει να ανανεώσετε προγραμματιστικά το διάγραμμα ώστε να αντανακλά τα τελευταία δεδομένα.

**Μπορώ να προσαρμόσω την εμφάνιση του διαγράμματος;**

Ναι, το Aspose.Slides for Java παρέχει εκτενείς επιλογές προσαρμογής. Μπορείτε να τροποποιήσετε χρώματα, γραμματοσειρές, ετικέτες, υπομνήματα και άλλα στοιχεία μορφοποίησης για να προσαρμόσετε την εμφάνιση του διαγράμματος στις συγκεκριμένες απαιτήσεις σχεδίασής σας.