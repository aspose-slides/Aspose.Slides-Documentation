---
title: Διαχείριση ετικετών δεδομένων διαγράμματος σε παρουσιάσεις χρησιμοποιώντας Java
linktitle: Ετικέτα δεδομένων
type: docs
url: /el/java/chart-data-label/
keywords:
- διάγραμμα
- ετικέτα δεδομένων
- ακρίβεια δεδομένων
- ποσοστό
- απόσταση ετικέτας
- θέση ετικέτας
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε να προσθέτετε και να μορφοποιείτε ετικέτες δεδομένων διαγράμματος σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για Java για πιο ελκυστικές διαφάνειες."
---
## **Εισαγωγή**

Οι ετικέτες δεδομένων εμφανίζουν πληροφορίες σχετικά με τις σειρές του διαγράμματος και τα μεμονωμένα σημεία δεδομένων, βοηθώντας τους αναγνώστες να προσδιορίζουν τις τιμές και να κατανοούν το διάγραμμα. Αυτό το άρθρο εξηγεί πώς να μορφοποιήσετε τιμές, να εμφανίσετε ποσοστά, να διαβάσετε το κείμενο της ετικέτας, να ελέγξετε τις ετικέτες πέραν του μέγιστου άξονα, να προσαρμόσετε το κενό των ετικετών του άξονα κατηγοριών και να τοποθετήσετε τις ετικέτες του κυκλικού διαγράμματος.

## **Ορισμός ακρίβειας δεδομένων στις ετικέτες δεδομένων του διαγράμματος**

Χρησιμοποιήστε [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) για να μορφοποιήσετε τις τιμές των σειρών. Αυτό το παράδειγμα δημιουργεί ένα διαγραμμα γραμμής με προεπιλεγμένα δεδομένα, εμφανίζει τον πίνακα δεδομένων του και ενεργοποιεί τις ετικέτες τιμών για την πρώτη σειρά. Η μορφή `#,##0.00` εμφανίζει διαχωριστικό χιλιάδων και δύο δεκαδικά ψηφία χωρίς να αλλάζει τις υποκείμενες τιμές.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για να μορφοποιήσετε τα αριθμητικά κελιά σε ενσωματωμένο βιβλίο εργασίας του διαγράμματος, δείτε [Set Custom Number Formats for Workbook Cells](/slides/el/java/chart-workbook/#set-custom-number-formats-for-workbook-cells). Αυτό το παράδειγμα δείχνει επίσης τις ετικέτες τιμών που ακολουθούν τις μορφές των πηγαίων κελιών, διατηρώντας τις αποθηκευμένες αριθμητικές τιμές.

## **Εμφάνιση ποσοστού ως ετικέτες**

Για ένα στοίβαγμα στήλης, υπολογίστε κάθε τιμή ως ποσοστό του συνολικού όγκου της κατηγορίας της και αντιστοιχίστε το κείμενο στο πλαίσιο κειμένου που επιστρέφεται από το [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). Αυτό το παράδειγμα χρησιμοποιεί τα προεπιλεγμένα δεδομένα του διαγράμματος και εμφανίζει τα ποσοστά με δύο δεκαδικά ψηφία σε γραμματοσειρά 8 σημείων. Οι κατηγορίες με συνολικό μηδέν παραλείπονται για αποφυγή διαίρεσης με το μηδέν. Επανυπολογίστε το προσαρμοσμένο κείμενο ετικέτας εάν τα δεδομένα του διαγράμματος αλλάξουν.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός συμβόλου ποσοστού με τις ετικέτες δεδομένων του διαγράμματος**

Όταν οι τιμές αποθηκεύονται ως κλάσματα, χρησιμοποιήστε [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) για να εμφανίσετε ποσοστά. Περάστε `false` στη [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) για να εφαρμόσετε τη μορφή ετικέτας ανεξάρτητα από τα πηγαία κελιά.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα στοίβασης 100% με κόκκινη και μπλε σειρά σε τέσσερις κατηγορίες. Κάθε ζεύγος τιμών αθροίζει στο 1. Η μορφή ετικέτας `0.0%` εμφανίζει το 0.30 ως 30.0%, ενώ ο κάθετος άξονας χρησιμοποιεί δύο δεκαδικά ψηφία. Και οι δύο σειρές χρησιμοποιούν λευκό κείμενο ετικέτας 10 σημείων.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    Color[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ανάγνωση του πραγματικού κειμένου των ετικετών δεδομένων**

Χρησιμοποιήστε το [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) για να ανακτήσετε το κείμενο που παράγεται από τις ρυθμίσεις μιας ετικέτας δεδομένων. Αυτό είναι χρήσιμο κατά την εξαγωγή ετικετών για αναφορές, την αναζήτηση περιεχομένου παρουσίασης ή την επικύρωση παραγόμενων διαγραμμάτων. Στο παρακάτω παράδειγμα, η προεπιλεγμένη [data label format](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) συνδυάζει το όνομα κάθε κατηγορίας, το όνομα σειράς και την τιμή. Ένα σημείο μορφοποιεί την τιμή του ως ποσοστό, και ένα άλλο χρησιμοποιεί προσαρμοσμένο κείμενο από το [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

Ο αριθμός που αποθηκεύεται σε ένα σημείο δεδομένων παραμένει `0.75`, ακόμη και όταν η ετικέτα του εμφανίζει `75%` μαζί με τα ονόματα κατηγορίας και σειράς. Το προσαρμοσμένο κείμενο αντικαθιστά το παραγόμενο κείμενο ετικέτας. Το [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) επιστρέφει τη συμβολοσειρά ετικέτας σε κάθε περίπτωση. Ελέγξτε το [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) ξεχωριστά, όπως φαίνεται παραπάνω, όταν θέλετε να εξάγετε μόνο τις ορατές ετικέτες.

## **Έλεγχος ετικετών δεδομένων πέραν του μέγιστου αξόνων**

Όταν περιορίζετε χειροκίνητα την περιοχή ενός άξονα, ορισμένα σημεία δεδομένων μπορεί να υπερβαίνουν το μέγιστο. Χρησιμοποιήστε το [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) για να ελέγξετε αν εμφανίζονται οι ετικέτες τους. Αυτή η ρύθμιση αλλάζει την ορατότητα της ετικέτας· δεν αλλάζει το εύρος του άξονα ή τις υποκείμενες τιμές δεδομένων.

Το παρακάτω παράδειγμα δημιουργεί ένα 2D διαστρωματικό γράφημα στήλης με τιμές 60 και 120. Περνά `false` στο [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) και θέτει το μέγιστο σε 100 με το [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) στον κάθετο άξονα. Η πρώτη διαφάνεια επιτρέπει τις ετικέτες πέραν του μέγιστου· ένα αντίγραφο της διαφάνειας τις απενεργοποιεί. Και οι δύο διαφάνειες αποθηκεύονται στο `DataLabelsOverMaximum.pptx`.

Ενεργοποιήστε τις ετικέτες τιμών με το [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Η ρύθμιση σε επίπεδο διαγράμματος δεν ενεργοποιεί μόνο την εμφάνιση τιμών ούτε παρακάμπτει την απενεργοποίηση της εμφάνισης τιμής σε μεμονωμένη ετικέτα. Αυτό το παράδειγμα ενεργοποιεί τις τιμές για όλη τη σειρά και χρησιμοποιεί το [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) για να τοποθετήσει τις ετικέτες στο εξωτερικό άκρο κάθε στήλης.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Οι παρακάτω εικόνες δείχνουν τις αποθηκευμένες διαφάνειες που αποδίδονται από το Microsoft PowerPoint. Με `true`, η ετικέτα **120** είναι ορατή στο άνω όριο· με `false`, είναι κρυφή. Η ετικέτα **60** παραμένει ορατή, το μέγιστο του άξονα παραμένει **100**, και το δεύτερο σημείο δεδομένων παραμένει **120** και στις δύο περιπτώσεις.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Διάγραμμα PowerPoint που εμφανίζει την ετικέτα τιμής 120 με μέγιστο άξονα 100](data-labels-over-maximum-true.png) | ![Διάγραμμα PowerPoint που κρύβει την ετικέτα τιμής 120 με μέγιστο άξονα 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Αυτό το παράδειγμα χρησιμοποιεί ένα 2D διάγραμμα στήλης με άξονα τιμών. Διαγράμματα χωρίς άξονα τιμών, όπως τα κυκλικά και δακτυλιδένια διαγράμματα, δεν διαθέτουν μέγιστο άξονα που μπορεί να περιοριστεί με αυτόν τον τρόπο.
{{% /alert %}}

## **Ορισμός απόστασης ετικέτας από άξονα**

Χρησιμοποιήστε το [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) για να ελέγξετε την απόσταση μεταξύ των ετικετών του άξονα κατηγοριών και του άξονα. Η τιμή είναι ποσοστό του μέγιστου μεγέθους γραμματοσειράς των ετικετών του άξονα. Αυτό το παράδειγμα δημιουργεί ένα διαστρωματικό γράφημα στήλης και ορίζει την απόσταση ετικέτας του οριζόντιου άξονα σε 500. Αυτή η ρύθμιση επηρεάζει τις ετικέτες του άξονα κατηγοριών και όχι τις ετικέτες που προσαρτώνται σε μεμονωμένα σημεία δεδομένων.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Προσαρμογή θέσης ετικέτας**

Σε ένα κυκλικό διάγραμμα, προσαρμόστε τις θέσεις των ετικετών δεδομένων για να βελτιώσετε το διάστημα και να δημιουργήσετε χώρο για τις γραμμές οδηγού.

Αυτό το παράδειγμα εμφανίζει την τιμή του πρώτου σημείου δεδομένων, τοποθετεί την ετικέτα του έξω από το τμήμα και προσαρμόζει τις οριζόντιες και κάθετες μετατοπίσεις χρησιμοποιώντας τα [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) και [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-). Αυτές οι μετατοπίσεις είναι σχετικές με το πλάτος και το ύψος του διαγράμματος, αντίστοιχα.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Κυκλικό διάγραμμα με προσαρμοσμένη θέση ετικέτας δεδομένων](pie-chart-adjusted-label.png)

## **Μορφοποίηση γραμμών οδηγού**

Όταν οι ετικέτες του κυκλικού διαγράμματος βρίσκονται έξω από τα τμήματά τους, οι γραμμές οδηγού βοηθούν τους αναγνώστες να αντιστοιχίσουν κάθε τιμή στο σωστό τμήμα. Ένα αντίθετο χρώμα και μια ελαφρώς παχύτερη γραμμή μπορούν να κάνουν αυτές τις συνδέσεις πιο εύκολες στην παρακολούθηση, ενώ η διαφάνεια και το διακεκομμένο στυλ διατηρούν τις γραμμές οπτικά ανεπαίσθητες.

Χρησιμοποιήστε το [getLeaderLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelcollection/#getLeaderLinesFormat--) για να μορφοποιήσετε τις γραμμές οδηγού σε επίπεδο συλλογής ετικετών δεδομένων της σειράς. Οι ρυθμίσεις στο `series.getLabels().getLeaderLinesFormat().getLine()` εφαρμόζονται στη συλλογή, όχι σε μεμονωμένη ετικέτα.

Αυτό το παράδειγμα δημιουργεί ένα κυκλικό διάγραμμα με προεπιλεγμένα δεδομένα, εμφανίζει τις τιμές έξω από τα τμήματα και ενεργοποιεί το [setShowLeaderLines](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowLeaderLines-boolean-). Μετακινεί δύο ετικέτες πιο μακριά από τα τμήματά τους χρησιμοποιώντας τις μετατοπίσεις [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) και [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-), εκφρασμένες ως κλάσματα του πλάτους και του ύψους του διαγράμματος. Δεν απαιτείται εισερχόμενη παρουσίαση.

Το [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) της γραμμής ορίζει ένα συμπαγές μπλε χρώμα με τιμή άλφα 191 από 255, παρέχοντας περίπου 25% διαφάνεια. Το [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) ορίζει το πάχος στα 2 σημεία, και το [setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) κάνει τη γραμμή διακεκομμένη.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400);
    chart.setLegend(false);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
    labelFormat.setShowValue(true);
    labelFormat.setPosition(LegendDataLabelPosition.OutsideEnd);
    labelFormat.setShowLeaderLines(true);

    // Μετακινήστε δύο ετικέτες πιο μακριά από τα τμήματά τους.
    series.getLabels().get_Item(0).setX(0.10f);
    series.getLabels().get_Item(0).setY(-0.05f);
    series.getLabels().get_Item(1).setX(-0.10f);
    series.getLabels().get_Item(1).setY(0.05f);

    ILineFormat line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(FillType.Solid);
    line.getFillFormat().getSolidFillColor().setColor(new Color(30, 90, 160, 191));
    line.setWidth(2);
    line.setDashStyle(LineDashStyle.Dash);

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η ενεργοποίηση των γραμμών οδηγού δεν εγγυάται ότι θα εμφανιστεί γραμμή για κάθε ετικέτα. Η ορατότητα εξαρτάται από τη θέση της ετικέτας και τη συμπεριφορά διάταξης του διαγράμματος. Σε αυτό το παράδειγμα, οι δύο απομακρυσμένες ετικέτες έχουν ορατές γραμμές οδηγού· οι ετικέτες που παραμένουν κοντά στα τμήματά τους δεν τις χρειάζονται.

Η παρακάτω εικόνα δείχνει το αποθηκευμένο `FormattedLeaderLines.pptx` αποδοσμένο με το Aspose.Slides:

![Κυκλικό διάγραμμα με μπλε, ημιδιαφανείς διακεκομμένες γραμμές οδηγού που συνδέουν δύο εξωτερικές ετικέτες με τα τμήματά τους](formatted-leader-lines.png)

## **Προσθήκη πολλαπλών σειρών ετικετών δεδομένων πάνω από ένα διάγραμμα στήλης**

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα στήλης με δύο σειρές ετικετών δεδομένων πάνω από την περιοχή σχεδίασης. Η Σειρά A εμφανίζει τις ορατές στήλες, ενώ οι Σειρές B και C παρέχουν τις πρόσθετες ετικέτες. Οι στήλες τους κρύβονται αφαιρώντας το γέμισμα και το περίγραμμα. Η μέθοδος [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) ευθυγραμμίζει και τις τρεις σειρές με τα ίδια κέντρα κατηγοριών.

Οι ρυθμίσεις του [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) διατηρούν χώρο για τις σειρές ετικετών. Μετά ο υπολογισμός των προεπιλεγμένων θέσεων από το [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/), τα [DataLabel.setX and DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) διατηρούν την οριζόντια στοίχιση και εφαρμόζουν κάθετες μετατοπίσεις για τη διάταξη των ετικετών σε δύο σειρές. Οι αριθμοί παραμένουν ετικέτες δεδομένων συνδεδεμένες με τις τιμές των σειρών· μόνο οι επικεφαλίδες των σειρών είναι ξεχωριστά σχήματα κειμένου.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    String[] categories = {"North", "South", "East", "West"};
    String[] seriesNames = {"Series A", "Series B", "Series C"};
    double[][] seriesValues = {
            {35, 42, 28, 47},
            {22, 31, 19, 26},
            {12, 16, 14, 18}
    };

    for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        chart.getChartData().getCategories().add(
                workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]));
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().add(
                workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]),
                ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            series.getDataPoints().addDataPointForBarSeries(workbook.getCell(
                    0, categoryIndex + 1, seriesIndex + 1,
                    seriesValues[seriesIndex][categoryIndex]));
        }

        if (seriesIndex > 0) {
            // Απόκρυψη των στηλών του B και του C, αλλά διατήρηση των ετικετών δεδομένων τους.
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(java.awt.Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(
                    LegendDataLabelPosition.InsideBase);
        }
    }

    // Στοίχιση όλων των τριών σειρών με τα ίδια κέντρα κατηγοριών.
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // Χρησιμοποιήστε λιγότερες γραμμές πλέγματος για αυτό το συμπαγές παράδειγμα.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Δεσμεύστε χώρο πάνω από την περιοχή σχεδίασης για δύο σειρές ετικετών δεδομένων.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);
    chart.getPlotArea().setX(0.15f);
    chart.getPlotArea().setY(0.32f);
    chart.getPlotArea().setWidth(0.80f);
    chart.getPlotArea().setHeight(0.48f);
    chart.validateChartLayout();

    for (int seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IDataLabel dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // Διατήρηση της προεπιλεγμένης οριζόντιας θέσης. Το Y είναι μια μετατόπιση από
            // την προεπιλεγμένη θέση ετικέτας, εκφρασμένη ως κλάσμα του ύψους του διαγράμματος.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // Μόνο η επικεφαλίδα της σειράς είναι ένα ξεχωριστό σχήμα κειμένου.
        IAutoShape rowHeading = slide.getShapes().addAutoShape(
                ShapeType.Rectangle, chart.getX(),
                chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs()
                .get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(java.awt.Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Διάγραμμα στήλης με δύο σειρές ετικετών δεδομένων πάνω από την περιοχή σχεδίασης](multiple-rows-of-labels.png)

## **FAQ**

**Πώς μπορώ να αποτρέψω την επικάλυψη ετικετών δεδομένων σε πυκνά διαγράμματα;**

Συνδυάστε την αυτόματη τοποθέτηση ετικετών, τις γραμμές οδηγού και τη μείωση του μεγέθους γραμματοσειράς· αν χρειάζεται, κρύψτε ορισμένα πεδία (π.χ. την κατηγορία) ή εμφανίστε ετικέτες μόνο για ακραίες τιμές ή βασικά σημεία.

**Πώς μπορώ να απενεργοποιήσω τις ετικέτες μόνο για μηδενικές, αρνητικές ή κενές τιμές;**

Φιλτράρετε τα σημεία δεδομένων πριν ενεργοποιήσετε τις ετικέτες και απενεργοποιήστε την εμφάνιση για τιμές 0, αρνητικές τιμές ή ελλιπείς τιμές σύμφωνα με έναν καθορισμένο κανόνα.

**Πώς μπορώ να εξασφαλίσω συνεπή στυλ ετικετών κατά την εξαγωγή σε PDF/εικόνες;**

Ορίστε ρητά την οικογένεια γραμματοσειράς και το μέγεθος και βεβαιωθείτε ότι η γραμματοσειρά είναι διαθέσιμη στο περιβάλλον απόδοσης ώστε να αποφευχθεί η εναλλακτική.